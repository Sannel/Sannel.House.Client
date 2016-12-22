using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#if STANDARD
using System.Net;
#else
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
#endif
namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// This class is used to connect and make calls to the server.
	/// </summary>
	public sealed partial class ServerContext : IDisposable
	{
		private String cookieValue;
		private IServerSettings settings;
		private ICreateHelper helper;
		private IHttpClient client;
		private String authzCookieName;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerContext" /> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="helper">The helper.</param>
		/// <param name="client">The client.</param>
		/// <exception cref="ArgumentNullException"></exception>
		public ServerContext(IServerSettings settings, ICreateHelper helper, IHttpClient client)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			if (helper == null)
			{
				throw new ArgumentNullException(nameof(helper));
			}

			if (client == null)
			{
				throw new ArgumentNullException(nameof(client));
			}

			this.authzCookieName = "authz";
			this.settings = settings;
			this.helper = helper;
			this.client = client;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerContext"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="helper">The helper.</param>
		public ServerContext(IServerSettings settings, ICreateHelper helper) : this(settings, helper, new ServerHttpClient())
		{
		}

		public void Dispose()
		{
			client?.Dispose();
		}

		/// <summary>
		/// Gets a value indicating whether this instance is authenticated.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
		/// </value>
		public bool IsAuthenticated
		{
			get
			{
				return cookieValue != null;
			}
		}

		/// <summary>
		/// Logins to the server asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns>First part of the Tuple is true if authenticated false if unable to authenticate for some reason
		/// The second part of the Tuple is a String the represents the authz token value if we were able to login to the server
		///		or The error message if we were unable to authenticate to the server.</returns>
#if STANDARD
		public async Task<LoginResult> LoginAsync(String username, String password)
		{
#else
		public IAsyncOperation<LoginResult> LoginAsync(String username, String password)
		{
			return Task.Run(async () =>
			{
#endif
			if (settings.ServerUri == null)
			{
				return new LoginResult(LoginStatus.ServerUriNotSet, "Server Uri is not set");
			}
			if (username == null)
			{
				return new LoginResult(LoginStatus.UsernameIsNull, "Username cannot be null");
			}
			if (password == null)
			{
				return new LoginResult(LoginStatus.PasswordIsNull, "Password cannot be null");
			}
			UriBuilder builder;
			try
			{
				builder = new UriBuilder(settings.ServerUri);
			}
			catch
			{
				return new LoginResult(LoginStatus.ServerUriIsNotValid, "Server Uri is not valid");
			}

			builder.Path = "/Account/LoginFromDevice";

			HttpClientResult result = null;
			try
			{
				var dict = new Dictionary<String, String>();
				dict.Add("Email", username);
				dict.Add("Password", password);
				dict.Add("RememberMe", "true");
				result = await client.PostAsync(builder.Uri, dict);
			}
#if STANDARD
			catch(Exception e)
			{
				return new LoginResult(LoginStatus.Exception, e.ToString());
			}
#else
			catch (COMException ce)
			{
				if (ce.HResult == -2147012867)
				{
					return new LoginResult(LoginStatus.UnableToConnectToServer, "Unable to connect to server");
				}

				return new LoginResult(LoginStatus.Exception, ce.ToString());
			}
#endif
#if STANDARD
			if(result.StatusCode == HttpStatusCode.OK)
#else
			if (result.StatusCode == HttpStatusCode.Ok)
#endif
			{
				var value = client.GetCookieValue(new Uri($"{builder.Scheme}://{builder.Host}:{builder.Port}"), authzCookieName);

				cookieValue = value;

				if (value != null)
				{
					return new LoginResult(LoginStatus.Success, cookieValue);
				}
				else
				{
					return new LoginResult(LoginStatus.Error, "Error Authenticating");
				}
			}
			return new LoginResult(LoginStatus.Error, "Request Error");
#if STANDARD
		}
#else
		}).AsAsyncOperation();
		}
#endif

		private Tuple<RequestStatus, UriBuilder> checkCommon()
		{
			if(settings.ServerUri == null)
			{
				return new Tuple<RequestStatus, UriBuilder>(RequestStatus.ServerUriNotSet, null);
			}

			if (!IsAuthenticated)
			{
				return new Tuple<RequestStatus, UriBuilder>(RequestStatus.NotLoggedIn, null);
			}

			UriBuilder builder;
			try
			{
				builder = new UriBuilder(settings.ServerUri);
			}
			catch (InvalidOperationException)
			{
				return new Tuple<RequestStatus, UriBuilder>(RequestStatus.ServerUriIsNotValid, null);
			}
			catch
			{
				return new Tuple<RequestStatus, UriBuilder>(RequestStatus.ServerUriIsNotValid, null);
			}

			return new Tuple<RequestStatus, UriBuilder>(RequestStatus.Success, builder);
		}

	}
}
