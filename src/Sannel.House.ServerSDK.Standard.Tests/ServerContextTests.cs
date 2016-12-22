using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.ServerSDK.Tests
{
	public partial class ServerContextTests
	{
		[Fact]
		public async Task LoginAsyncTest()
		{
			var sett = new StubIServerSettings();
			sett.ServerUri_Get(() => null);
			var create = new StubICreateHelper();
			var serverContext = new ServerContext(sett, create);
			var result = await serverContext.LoginAsync(null, null);
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.ServerUriNotSet, result.Status);
			Assert.Equal("Server Uri is not set", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5020/"));
			result = await serverContext.LoginAsync(null, null);
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.UsernameIsNull, result.Status);
			Assert.Equal("Username cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", null);
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.PasswordIsNull, result.Status);
			Assert.Equal("Password cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.UnableToConnectToServer, result.Status);
			Assert.Equal("Unable to connect to server", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtst");
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.Error, result.Status);
			Assert.Equal("Error Authenticating", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.NotNull(result);
			Assert.Equal(LoginStatus.Success, result.Status);
			Assert.NotNull(result.Message);
		}
	}
}
