using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Sannel.House.ServerSDK.Tests
{
	[TestClass]
	public partial class ServerContextTests
	{
		[TestMethod]
		public async Task LoginAsyncTest()
		{
			var sett = new StubIServerSettings();
			sett.ServerUri_Get(() => null);
			var create = new StubICreateHelper();
			var serverContext = new ServerContext(sett, create);
			var result = await serverContext.LoginAsync(null, null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.ServerUriNotSet, result.Status);
			Assert.AreEqual("Server Uri is not set", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5020/"));
			result = await serverContext.LoginAsync(null, null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.UsernameIsNull, result.Status);
			Assert.AreEqual("Username cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.PasswordIsNull, result.Status);
			Assert.AreEqual("Password cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.UnableToConnectToServer, result.Status);
			Assert.AreEqual("Unable to connect to server", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtst");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.Error, result.Status);
			Assert.AreEqual("Error Authenticating", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.Success, result.Status);
			Assert.IsNotNull(result.Message);
		}
	}
}
