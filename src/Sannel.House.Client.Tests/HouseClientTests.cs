/* Copyright 2019 Sannel Software, L.L.C.
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
      http://www.apache.org/licenses/LICENSE-2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Client.Tests
{
	public class HouseClientTests : TestBase
	{
		[Fact]
		public async Task LoginAsyncTest()
		{
			var clientFactory = new Mock<IHttpClientFactory>();
			var client = new Mock<HttpMessageHandler>(MockBehavior.Strict);

			var httpClient = new HttpClient(client.Object)
			{
			};
			clientFactory.Setup(i => i.CreateClient(nameof(HouseClient))).Returns(httpClient);
			clientFactory.Setup(i => i.CreateClient(nameof(Devices.Client.DevicesClient))).Returns(httpClient);
			clientFactory.Setup(i => i.CreateClient(nameof(SensorLogging.Client.SensorLoggingClient))).Returns(httpClient);
			var log = CreateLogger<HouseClient>();
			var configuration = LoadConfiguration();


			var houseClient = new HouseClient(clientFactory.Object, configuration, log);

			var token = "jwt access token";
			var expiresIn = 3600;
			var ttype = "Bearer";
			var username = "test@test.com";
			var password = "pass1";
			var min = DateTimeOffset.Now.AddSeconds(expiresIn);


			client.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			).ReturnsAsync((HttpRequestMessage r, CancellationToken c) =>
			{
				Assert.Equal(new Uri("https://gateway.dev.local/connect/token"), r.RequestUri);

				var obj = JObject.Parse(r.Content.ReadAsStringAsync().Result);
				Assert.Equal("password", obj["grant_type"]);
				Assert.Equal(username, obj["username"]);
				Assert.Equal(password, obj["password"]);
				Assert.Equal(configuration["Client:ClientId"], obj["client_id"]);
				Assert.Equal(configuration["Client:ClientSecret"], obj["client_secret"]);

				return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(
						new
						{
							access_token = token,
							expires_in = expiresIn,
							token_type = ttype
						}
					))
				};
			});

			var response = await houseClient.LoginAsync(username, password);
			Assert.True(response.Success);
			Assert.Equal(token, response.AccessToken);
			Assert.Equal(token, houseClient.AuthToken);
			Assert.Equal(token, houseClient.Devices.AuthToken);
			Assert.Equal(token, houseClient.SensorLogging.AuthToken);
			Assert.Equal(expiresIn, response.ExpiresIn);
			Assert.True(response.ExpiresAt > min &&
				response.ExpiresAt < DateTimeOffset.Now.AddSeconds(expiresIn));
			Assert.Equal(houseClient.ExpiresAt, response.ExpiresAt);

		}

		[Fact]
		public async Task LoginAsync2Test()
		{
			var clientFactory = new Mock<IHttpClientFactory>();
			var client = new Mock<HttpMessageHandler>(MockBehavior.Strict);

			var httpClient = new HttpClient(client.Object)
			{
			};
			clientFactory.Setup(i => i.CreateClient(nameof(HouseClient))).Returns(httpClient);
			clientFactory.Setup(i => i.CreateClient(nameof(Devices.Client.DevicesClient))).Returns(httpClient);
			clientFactory.Setup(i => i.CreateClient(nameof(SensorLogging.Client.SensorLoggingClient))).Returns(httpClient);
			var log = CreateLogger<HouseClient>();
			var configuration = LoadConfiguration();


			var houseClient = new HouseClient(clientFactory.Object, configuration, log);

			var error = "invalid_grant";
			var errorDescription = "invalid_username_or_password";
			var username = "test@test.com";
			var password = "pass1";


			client.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			).ReturnsAsync((HttpRequestMessage r, CancellationToken c) =>
			{
				Assert.Equal(new Uri("https://gateway.dev.local/connect/token"), r.RequestUri);

				var obj = JObject.Parse(r.Content.ReadAsStringAsync().Result);
				Assert.Equal("password", obj["grant_type"]);
				Assert.Equal(username, obj["username"]);
				Assert.Equal(password, obj["password"]);
				Assert.Equal(configuration["Client:ClientId"], obj["client_id"]);
				Assert.Equal(configuration["Client:ClientSecret"], obj["client_secret"]);

				return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
				{
					Content = new StringContent(JsonConvert.SerializeObject(
						new
						{
							error,
							error_description = errorDescription
						}
					))
				};
			});

			var response = await houseClient.LoginAsync(username, password);
			Assert.False(response.Success);
			Assert.Equal(error, response.Error);
			Assert.Equal(errorDescription, response.ErrorDescription);

		}

		[Fact]
		public async Task LoginAsync3Test()
		{
			var client = new Mock<HttpMessageHandler>(MockBehavior.Strict);

			var httpClient = new HttpClient(client.Object)
			{
			};

			var log = CreateLogger<HouseClient>();
			var configuration = LoadConfiguration();


			var houseClient = new HouseClient(httpClient, configuration, log);

			var token = "jwt access token";
			var expiresIn = 3600;
			var ttype = "Bearer";
			var username = "test@test.com";
			var password = "pass1";
			var min = DateTimeOffset.Now.AddSeconds(expiresIn);


			client.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			).ReturnsAsync((HttpRequestMessage r, CancellationToken c) =>
			{
				Assert.Equal(new Uri("https://gateway.dev.local/connect/token"), r.RequestUri);

				var obj = JObject.Parse(r.Content.ReadAsStringAsync().Result);
				Assert.Equal("password", obj["grant_type"]);
				Assert.Equal(username, obj["username"]);
				Assert.Equal(password, obj["password"]);
				Assert.Equal(configuration["Client:ClientId"], obj["client_id"]);
				Assert.Equal(configuration["Client:ClientSecret"], obj["client_secret"]);

				return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(
						new
						{
							access_token = token,
							expires_in = expiresIn,
							token_type = ttype
						}
					))
				};
			});

			var response = await houseClient.LoginAsync(username, password);
			Assert.True(response.Success);
			Assert.Equal(token, response.AccessToken);
			Assert.Equal(token, houseClient.AuthToken);
			Assert.Equal(token, houseClient.Devices.AuthToken);
			Assert.Equal(token, houseClient.SensorLogging.AuthToken);
			Assert.Equal(expiresIn, response.ExpiresIn);
			Assert.True(response.ExpiresAt > min &&
				response.ExpiresAt < DateTimeOffset.Now.AddSeconds(expiresIn));

		}

		[Fact]
		public async Task LoginAsync4Test()
		{
			var client = new Mock<HttpMessageHandler>(MockBehavior.Strict);

			var httpClient = new HttpClient(client.Object)
			{
			};

			var log = CreateLogger<HouseClient>();
			var configuration = LoadConfiguration();


			var houseClient = new HouseClient(httpClient, configuration, log);

			var error = "invalid_grant";
			var errorDescription = "invalid_username_or_password";
			var username = "test@test.com";
			var password = "pass1";


			client.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			).ReturnsAsync((HttpRequestMessage r, CancellationToken c) =>
			{
				Assert.Equal(new Uri("https://gateway.dev.local/connect/token"), r.RequestUri);

				var obj = JObject.Parse(r.Content.ReadAsStringAsync().Result);
				Assert.Equal("password", obj["grant_type"]);
				Assert.Equal(username, obj["username"]);
				Assert.Equal(password, obj["password"]);
				Assert.Equal(configuration["Client:ClientId"], obj["client_id"]);
				Assert.Equal(configuration["Client:ClientSecret"], obj["client_secret"]);

				return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
				{
					Content = new StringContent(JsonConvert.SerializeObject(
						new
						{
							error,
							error_description = errorDescription
						}
					))
				};
			});

			var response = await houseClient.LoginAsync(username, password);
			Assert.False(response.Success);
			Assert.Equal(error, response.Error);
			Assert.Equal(errorDescription, response.ErrorDescription);

		}
	}
}
