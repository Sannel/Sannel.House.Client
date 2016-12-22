/* Copyright 2016 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Runtime.InteropServices;

namespace Sannel.House.ServerSDK.Tests
{
	public partial class ServerContextTests
	{
#region Devices
		[TestMethod]
		public async Task GetDeviceAsyncTest()
		{
			Int32 _Id = 0;
			String _Name = String.Empty;
			String _Description = String.Empty;
			Int32 _DisplayOrder = 0;
			DateTimeOffset _DateCreated = DateTimeOffset.MinValue;
			Boolean _IsReadOnly = false;
			// Setup Stub
			var stub = new StubIDevice();
			stub.Id_Get(() => _Id);
			stub.Id_Set((v) => _Id = v);
			stub.Name_Get(() => _Name);
			stub.Name_Set((v) => _Name = v);
			stub.Description_Get(() => _Description);
			stub.Description_Set((v) => _Description = v);
			stub.DisplayOrder_Get(() => _DisplayOrder);
			stub.DisplayOrder_Set((v) => _DisplayOrder = v);
			stub.DateCreated_Get(() => _DateCreated);
			stub.DateCreated_Set((v) => _DateCreated = v);
			stub.IsReadOnly_Get(() => _IsReadOnly);
			stub.IsReadOnly_Set((v) => _IsReadOnly = v);
			// create helper
			var create = new StubICreateHelper();
			create.CreateDevice(() => stub);
			// settings 
			var settings = new StubIServerSettings();
			settings.ServerUri_Get(() => null);
			// Http Client
			var httpClient = new StubIHttpClient();
			// Server 
			var serverContext = new ServerContext(settings, create, httpClient);
			Int32 key = 179;
			// leading
			var results = await serverContext.GetDeviceAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriNotSet, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(0, results.Key);
			// login exception
			settings.ServerUri_Get(() => new Uri("http://test"));
			httpClient.PostAsync((uri, d) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = ""};
				}

				).AsAsyncOperation();
			}

			);
			httpClient.GetCookieValue((u, name) => "Value");
			await serverContext.LoginAsync("user", "pass");
			settings.ServerUri_Get(() => new Uri("/cheese", UriKind.Relative));
			// invalid uri
			results = await serverContext.GetDeviceAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriIsNotValid, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(0, results.Key);
			// Unable to connect to server
			key = 137;
			settings.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/Device/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetDeviceAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.UnableToConnectToServer, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// COMException 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetDeviceAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Exception 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetDeviceAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Unauthorized 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{StatusCode = HttpStatusCode.Unauthorized, Content = "{Test: 'cheese'"};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetDeviceAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Error, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.IsInstanceOfType(results.Exception, typeof (JsonReaderException));
			// Success Test
			var exp = new StubIDevice();
			exp.Id_Get(() => key);
			exp.Name_Get(() => "gntloguqyqftfqllcsrkqtoyosk");
			exp.Description_Get(() => "oexoalbgrnxhwvgkvhvchtgve");
			exp.DisplayOrder_Get(() => 56);
			exp.DateCreated_Get(() => new DateTimeOffset(1987, 6, 26, 20, 53, 50, TimeSpan.FromHours(-5)));
			exp.IsReadOnly_Get(() => false);
			IDevice expected = exp;
			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.Name), expected.Name));
			jobj.Add(new JProperty(nameof(expected.Description), expected.Description));
			jobj.Add(new JProperty(nameof(expected.DisplayOrder), expected.DisplayOrder));
			jobj.Add(new JProperty(nameof(expected.DateCreated), expected.DateCreated));
			jobj.Add(new JProperty(nameof(expected.IsReadOnly), expected.IsReadOnly));
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = jobj.ToString()};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetDeviceAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Success, results.Status);
			Assert.AreEqual(key, results.Key);
			Assert.IsNull(results.Exception, "Exception should be null");
			Assert.IsNotNull(results.Data, "Data should not be null");
			var actual = results.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.Name, actual.Name);
			Assert.AreEqual(expected.Description, actual.Description);
			Assert.AreEqual(expected.DisplayOrder, actual.DisplayOrder);
			Assert.AreEqual(expected.DateCreated, actual.DateCreated);
			Assert.AreEqual(expected.IsReadOnly, actual.IsReadOnly);
		}
#endregion

#region TemperatureSettings
		[TestMethod]
		public async Task GetTemperatureSettingAsyncTest()
		{
			Int64 _Id = 0;
			Int32? _DayOfWeek = 0;
			Int32? _Month = 0;
			Boolean _IsTimeOnly = false;
			DateTimeOffset? _StartTime = DateTimeOffset.MinValue;
			DateTimeOffset? _EndTime = DateTimeOffset.MinValue;
			Double _HeatTemperatureC = 0;
			Double _CoolTemperatureC = 0;
			DateTimeOffset _DateCreated = DateTimeOffset.MinValue;
			DateTimeOffset _DateModified = DateTimeOffset.MinValue;
			// Setup Stub
			var stub = new StubITemperatureSetting();
			stub.Id_Get(() => _Id);
			stub.Id_Set((v) => _Id = v);
			stub.DayOfWeek_Get(() => _DayOfWeek);
			stub.DayOfWeek_Set((v) => _DayOfWeek = v);
			stub.Month_Get(() => _Month);
			stub.Month_Set((v) => _Month = v);
			stub.IsTimeOnly_Get(() => _IsTimeOnly);
			stub.IsTimeOnly_Set((v) => _IsTimeOnly = v);
			stub.StartTime_Get(() => _StartTime);
			stub.StartTime_Set((v) => _StartTime = v);
			stub.EndTime_Get(() => _EndTime);
			stub.EndTime_Set((v) => _EndTime = v);
			stub.HeatTemperatureC_Get(() => _HeatTemperatureC);
			stub.HeatTemperatureC_Set((v) => _HeatTemperatureC = v);
			stub.CoolTemperatureC_Get(() => _CoolTemperatureC);
			stub.CoolTemperatureC_Set((v) => _CoolTemperatureC = v);
			stub.DateCreated_Get(() => _DateCreated);
			stub.DateCreated_Set((v) => _DateCreated = v);
			stub.DateModified_Get(() => _DateModified);
			stub.DateModified_Set((v) => _DateModified = v);
			// create helper
			var create = new StubICreateHelper();
			create.CreateTemperatureSetting(() => stub);
			// settings 
			var settings = new StubIServerSettings();
			settings.ServerUri_Get(() => null);
			// Http Client
			var httpClient = new StubIHttpClient();
			// Server 
			var serverContext = new ServerContext(settings, create, httpClient);
			Int64 key = 51;
			// leading
			var results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriNotSet, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(0, results.Key);
			// login exception
			settings.ServerUri_Get(() => new Uri("http://test"));
			httpClient.PostAsync((uri, d) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = ""};
				}

				).AsAsyncOperation();
			}

			);
			httpClient.GetCookieValue((u, name) => "Value");
			await serverContext.LoginAsync("user", "pass");
			settings.ServerUri_Get(() => new Uri("/cheese", UriKind.Relative));
			// invalid uri
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriIsNotValid, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(0, results.Key);
			// Unable to connect to server
			key = 76;
			settings.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/TemperatureSetting/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.UnableToConnectToServer, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// COMException 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Exception 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Unauthorized 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{StatusCode = HttpStatusCode.Unauthorized, Content = "{Test: 'cheese'"};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Error, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.IsInstanceOfType(results.Exception, typeof (JsonReaderException));
			// Success Test
			var exp = new StubITemperatureSetting();
			exp.Id_Get(() => key);
			exp.DayOfWeek_Get(() => 9);
			exp.Month_Get(() => 131);
			exp.IsTimeOnly_Get(() => true);
			exp.StartTime_Get(() => new DateTimeOffset(2007, 8, 16, 6, 43, 26, TimeSpan.FromHours(-6)));
			exp.EndTime_Get(() => new DateTimeOffset(2003, 7, 27, 5, 23, 23, TimeSpan.FromHours(-5)));
			exp.HeatTemperatureC_Get(() => 0.29844863586986842);
			exp.CoolTemperatureC_Get(() => 0.8659522150950284);
			exp.DateCreated_Get(() => new DateTimeOffset(2002, 2, 7, 8, 52, 43, TimeSpan.FromHours(-6)));
			exp.DateModified_Get(() => new DateTimeOffset(1985, 4, 19, 19, 36, 22, TimeSpan.FromHours(-7)));
			ITemperatureSetting expected = exp;
			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.DayOfWeek), expected.DayOfWeek));
			jobj.Add(new JProperty(nameof(expected.Month), expected.Month));
			jobj.Add(new JProperty(nameof(expected.IsTimeOnly), expected.IsTimeOnly));
			jobj.Add(new JProperty(nameof(expected.StartTime), expected.StartTime));
			jobj.Add(new JProperty(nameof(expected.EndTime), expected.EndTime));
			jobj.Add(new JProperty(nameof(expected.HeatTemperatureC), expected.HeatTemperatureC));
			jobj.Add(new JProperty(nameof(expected.CoolTemperatureC), expected.CoolTemperatureC));
			jobj.Add(new JProperty(nameof(expected.DateCreated), expected.DateCreated));
			jobj.Add(new JProperty(nameof(expected.DateModified), expected.DateModified));
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = jobj.ToString()};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureSettingAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Success, results.Status);
			Assert.AreEqual(key, results.Key);
			Assert.IsNull(results.Exception, "Exception should be null");
			Assert.IsNotNull(results.Data, "Data should not be null");
			var actual = results.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.DayOfWeek, actual.DayOfWeek);
			Assert.AreEqual(expected.Month, actual.Month);
			Assert.AreEqual(expected.IsTimeOnly, actual.IsTimeOnly);
			Assert.AreEqual(expected.StartTime, actual.StartTime);
			Assert.AreEqual(expected.EndTime, actual.EndTime);
			Assert.AreEqual(expected.HeatTemperatureC, actual.HeatTemperatureC);
			Assert.AreEqual(expected.CoolTemperatureC, actual.CoolTemperatureC);
			Assert.AreEqual(expected.DateCreated, actual.DateCreated);
			Assert.AreEqual(expected.DateModified, actual.DateModified);
		}
#endregion

#region ApplicationLogEntries
		[TestMethod]
		public async Task GetApplicationLogEntryAsyncTest()
		{
			Guid _Id = Guid.Empty;
			Int32? _DeviceId = 0;
			String _ApplicationId = String.Empty;
			String _Message = String.Empty;
			String _Exception = String.Empty;
			DateTimeOffset _CreatedDate = DateTimeOffset.MinValue;
			// Setup Stub
			var stub = new StubIApplicationLogEntry();
			stub.Id_Get(() => _Id);
			stub.Id_Set((v) => _Id = v);
			stub.DeviceId_Get(() => _DeviceId);
			stub.DeviceId_Set((v) => _DeviceId = v);
			stub.ApplicationId_Get(() => _ApplicationId);
			stub.ApplicationId_Set((v) => _ApplicationId = v);
			stub.Message_Get(() => _Message);
			stub.Message_Set((v) => _Message = v);
			stub.Exception_Get(() => _Exception);
			stub.Exception_Set((v) => _Exception = v);
			stub.CreatedDate_Get(() => _CreatedDate);
			stub.CreatedDate_Set((v) => _CreatedDate = v);
			// create helper
			var create = new StubICreateHelper();
			create.CreateApplicationLogEntry(() => stub);
			// settings 
			var settings = new StubIServerSettings();
			settings.ServerUri_Get(() => null);
			// Http Client
			var httpClient = new StubIHttpClient();
			// Server 
			var serverContext = new ServerContext(settings, create, httpClient);
			Guid key = Guid.NewGuid();
			// leading
			var results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriNotSet, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// login exception
			settings.ServerUri_Get(() => new Uri("http://test"));
			httpClient.PostAsync((uri, d) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = ""};
				}

				).AsAsyncOperation();
			}

			);
			httpClient.GetCookieValue((u, name) => "Value");
			await serverContext.LoginAsync("user", "pass");
			settings.ServerUri_Get(() => new Uri("/cheese", UriKind.Relative));
			// invalid uri
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriIsNotValid, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// Unable to connect to server
			key = Guid.NewGuid();
			settings.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/ApplicationLogEntry/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.UnableToConnectToServer, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// COMException 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Exception 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Unauthorized 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{StatusCode = HttpStatusCode.Unauthorized, Content = "{Test: 'cheese'"};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Error, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.IsInstanceOfType(results.Exception, typeof (JsonReaderException));
			// Success Test
			var exp = new StubIApplicationLogEntry();
			exp.Id_Get(() => key);
			exp.DeviceId_Get(() => 18);
			exp.ApplicationId_Get(() => "nvnwjccgmexjlorqhcvhqlunp");
			exp.Message_Get(() => "hjfspsjidfohinbkfoyjixrgh");
			exp.Exception_Get(() => "btdbbagourasnfyckmcyt");
			exp.CreatedDate_Get(() => new DateTimeOffset(1991, 3, 7, 7, 15, 33, TimeSpan.FromHours(-7)));
			IApplicationLogEntry expected = exp;
			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.DeviceId), expected.DeviceId));
			jobj.Add(new JProperty(nameof(expected.ApplicationId), expected.ApplicationId));
			jobj.Add(new JProperty(nameof(expected.Message), expected.Message));
			jobj.Add(new JProperty(nameof(expected.Exception), expected.Exception));
			jobj.Add(new JProperty(nameof(expected.CreatedDate), expected.CreatedDate));
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = jobj.ToString()};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetApplicationLogEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Success, results.Status);
			Assert.AreEqual(key, results.Key);
			Assert.IsNull(results.Exception, "Exception should be null");
			Assert.IsNotNull(results.Data, "Data should not be null");
			var actual = results.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.DeviceId, actual.DeviceId);
			Assert.AreEqual(expected.ApplicationId, actual.ApplicationId);
			Assert.AreEqual(expected.Message, actual.Message);
			Assert.AreEqual(expected.Exception, actual.Exception);
			Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
		}
#endregion

#region TemperatureEntries
		[TestMethod]
		public async Task GetTemperatureEntryAsyncTest()
		{
			Guid _Id = Guid.Empty;
			Int32 _DeviceId = 0;
			Double _TemperatureCelsius = 0;
			Double _Humidity = 0;
			Double _Pressure = 0;
			DateTimeOffset _CreatedDateTime = DateTimeOffset.MinValue;
			// Setup Stub
			var stub = new StubITemperatureEntry();
			stub.Id_Get(() => _Id);
			stub.Id_Set((v) => _Id = v);
			stub.DeviceId_Get(() => _DeviceId);
			stub.DeviceId_Set((v) => _DeviceId = v);
			stub.TemperatureCelsius_Get(() => _TemperatureCelsius);
			stub.TemperatureCelsius_Set((v) => _TemperatureCelsius = v);
			stub.Humidity_Get(() => _Humidity);
			stub.Humidity_Set((v) => _Humidity = v);
			stub.Pressure_Get(() => _Pressure);
			stub.Pressure_Set((v) => _Pressure = v);
			stub.CreatedDateTime_Get(() => _CreatedDateTime);
			stub.CreatedDateTime_Set((v) => _CreatedDateTime = v);
			// create helper
			var create = new StubICreateHelper();
			create.CreateTemperatureEntry(() => stub);
			// settings 
			var settings = new StubIServerSettings();
			settings.ServerUri_Get(() => null);
			// Http Client
			var httpClient = new StubIHttpClient();
			// Server 
			var serverContext = new ServerContext(settings, create, httpClient);
			Guid key = Guid.NewGuid();
			// leading
			var results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriNotSet, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// login exception
			settings.ServerUri_Get(() => new Uri("http://test"));
			httpClient.PostAsync((uri, d) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = ""};
				}

				).AsAsyncOperation();
			}

			);
			httpClient.GetCookieValue((u, name) => "Value");
			await serverContext.LoginAsync("user", "pass");
			settings.ServerUri_Get(() => new Uri("/cheese", UriKind.Relative));
			// invalid uri
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriIsNotValid, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// Unable to connect to server
			key = Guid.NewGuid();
			settings.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/TemperatureEntry/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.UnableToConnectToServer, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// COMException 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Exception 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Unauthorized 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{StatusCode = HttpStatusCode.Unauthorized, Content = "{Test: 'cheese'"};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Error, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.IsInstanceOfType(results.Exception, typeof (JsonReaderException));
			// Success Test
			var exp = new StubITemperatureEntry();
			exp.Id_Get(() => key);
			exp.DeviceId_Get(() => 18);
			exp.TemperatureCelsius_Get(() => 0.781149737434997);
			exp.Humidity_Get(() => 0.52534901980559756);
			exp.Pressure_Get(() => 0.857609007906918);
			exp.CreatedDateTime_Get(() => new DateTimeOffset(1999, 10, 10, 3, 7, 15, TimeSpan.FromHours(-6)));
			ITemperatureEntry expected = exp;
			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.DeviceId), expected.DeviceId));
			jobj.Add(new JProperty(nameof(expected.TemperatureCelsius), expected.TemperatureCelsius));
			jobj.Add(new JProperty(nameof(expected.Humidity), expected.Humidity));
			jobj.Add(new JProperty(nameof(expected.Pressure), expected.Pressure));
			jobj.Add(new JProperty(nameof(expected.CreatedDateTime), expected.CreatedDateTime));
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult{StatusCode = HttpStatusCode.Ok, Content = jobj.ToString()};
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Success, results.Status);
			Assert.AreEqual(key, results.Key);
			Assert.IsNull(results.Exception, "Exception should be null");
			Assert.IsNotNull(results.Data, "Data should not be null");
			var actual = results.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.DeviceId, actual.DeviceId);
			Assert.AreEqual(expected.TemperatureCelsius, actual.TemperatureCelsius);
			Assert.AreEqual(expected.Humidity, actual.Humidity);
			Assert.AreEqual(expected.Pressure, actual.Pressure);
			Assert.AreEqual(expected.CreatedDateTime, actual.CreatedDateTime);
		}
#endregion
	}
}