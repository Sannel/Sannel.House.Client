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
using Newtonsoft.Json.Linq;
using Windows.Foundation;
using System.Runtime.InteropServices;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Sannel.House.ServerSDK
{
	public partial class ServerContext
	{
#region Device
		public IAsyncOperation<DeviceResult> GetDeviceAsync(Int32 key)
		{
			return Task.Run(async () =>
			{
				var check = checkCommon();
				if (check.Item1 != RequestStatus.Success)
				{
					return new DeviceResult(check.Item1, null, key);
				}

				var builder = check.Item2;
				builder.Path = $"/api/Device/{key}";
				HttpClientResult result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new DeviceResult(RequestStatus.UnableToConnectToServer, null, key, ce);
					}

					return new DeviceResult(RequestStatus.Exception, null, key, ce);
				}
				catch (Exception ce)
				{
					return new DeviceResult(RequestStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = result.Content;
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateDevice();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Int32>(nameof(item.Id));
							item.Name = token.GetPropertyValue<String>(nameof(item.Name));
							item.Description = token.GetPropertyValue<String>(nameof(item.Description));
							item.DisplayOrder = token.GetPropertyValue<Int32>(nameof(item.DisplayOrder));
							item.DateCreated = token.GetPropertyValue<DateTimeOffset>(nameof(item.DateCreated));
							item.IsReadOnly = token.GetPropertyValue<Boolean>(nameof(item.IsReadOnly));
						}

						return new DeviceResult(RequestStatus.Success, item, item.Id);
					}
					catch (Exception ex)
					{
						return new DeviceResult(RequestStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new DeviceResult(RequestStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
#endregion

#region TemperatureSetting
		public IAsyncOperation<TemperatureSettingResult> GetTemperatureSettingAsync(Int64 key)
		{
			return Task.Run(async () =>
			{
				var check = checkCommon();
				if (check.Item1 != RequestStatus.Success)
				{
					return new TemperatureSettingResult(check.Item1, null, key);
				}

				var builder = check.Item2;
				builder.Path = $"/api/TemperatureSetting/{key}";
				HttpClientResult result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new TemperatureSettingResult(RequestStatus.UnableToConnectToServer, null, key, ce);
					}

					return new TemperatureSettingResult(RequestStatus.Exception, null, key, ce);
				}
				catch (Exception ce)
				{
					return new TemperatureSettingResult(RequestStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = result.Content;
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateTemperatureSetting();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Int64>(nameof(item.Id));
							item.DayOfWeek = token.GetPropertyValue<System.Int32? >(nameof(item.DayOfWeek));
							item.Month = token.GetPropertyValue<System.Int32? >(nameof(item.Month));
							item.IsTimeOnly = token.GetPropertyValue<Boolean>(nameof(item.IsTimeOnly));
							item.StartTime = token.GetPropertyValue<System.DateTimeOffset? >(nameof(item.StartTime));
							item.EndTime = token.GetPropertyValue<System.DateTimeOffset? >(nameof(item.EndTime));
							item.HeatTemperatureC = token.GetPropertyValue<Double>(nameof(item.HeatTemperatureC));
							item.CoolTemperatureC = token.GetPropertyValue<Double>(nameof(item.CoolTemperatureC));
							item.DateCreated = token.GetPropertyValue<DateTimeOffset>(nameof(item.DateCreated));
							item.DateModified = token.GetPropertyValue<DateTimeOffset>(nameof(item.DateModified));
						}

						return new TemperatureSettingResult(RequestStatus.Success, item, item.Id);
					}
					catch (Exception ex)
					{
						return new TemperatureSettingResult(RequestStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new TemperatureSettingResult(RequestStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
#endregion

#region ApplicationLogEntry
		public IAsyncOperation<ApplicationLogEntryResult> GetApplicationLogEntryAsync(Guid key)
		{
			return Task.Run(async () =>
			{
				var check = checkCommon();
				if (check.Item1 != RequestStatus.Success)
				{
					return new ApplicationLogEntryResult(check.Item1, null, key);
				}

				var builder = check.Item2;
				builder.Path = $"/api/ApplicationLogEntry/{key}";
				HttpClientResult result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new ApplicationLogEntryResult(RequestStatus.UnableToConnectToServer, null, key, ce);
					}

					return new ApplicationLogEntryResult(RequestStatus.Exception, null, key, ce);
				}
				catch (Exception ce)
				{
					return new ApplicationLogEntryResult(RequestStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = result.Content;
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateApplicationLogEntry();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Guid>(nameof(item.Id));
							item.DeviceId = token.GetPropertyValue<System.Int32? >(nameof(item.DeviceId));
							item.ApplicationId = token.GetPropertyValue<String>(nameof(item.ApplicationId));
							item.Message = token.GetPropertyValue<String>(nameof(item.Message));
							item.Exception = token.GetPropertyValue<String>(nameof(item.Exception));
							item.CreatedDate = token.GetPropertyValue<DateTimeOffset>(nameof(item.CreatedDate));
						}

						return new ApplicationLogEntryResult(RequestStatus.Success, item, item.Id);
					}
					catch (Exception ex)
					{
						return new ApplicationLogEntryResult(RequestStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new ApplicationLogEntryResult(RequestStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
#endregion

#region TemperatureEntry
		public IAsyncOperation<TemperatureEntryResult> GetTemperatureEntryAsync(Guid key)
		{
			return Task.Run(async () =>
			{
				var check = checkCommon();
				if (check.Item1 != RequestStatus.Success)
				{
					return new TemperatureEntryResult(check.Item1, null, key);
				}

				var builder = check.Item2;
				builder.Path = $"/api/TemperatureEntry/{key}";
				HttpClientResult result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new TemperatureEntryResult(RequestStatus.UnableToConnectToServer, null, key, ce);
					}

					return new TemperatureEntryResult(RequestStatus.Exception, null, key, ce);
				}
				catch (Exception ce)
				{
					return new TemperatureEntryResult(RequestStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = result.Content;
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateTemperatureEntry();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Guid>(nameof(item.Id));
							item.DeviceId = token.GetPropertyValue<Int32>(nameof(item.DeviceId));
							item.TemperatureCelsius = token.GetPropertyValue<Double>(nameof(item.TemperatureCelsius));
							item.Humidity = token.GetPropertyValue<Double>(nameof(item.Humidity));
							item.Pressure = token.GetPropertyValue<Double>(nameof(item.Pressure));
							item.CreatedDateTime = token.GetPropertyValue<DateTimeOffset>(nameof(item.CreatedDateTime));
						}

						return new TemperatureEntryResult(RequestStatus.Success, item, item.Id);
					}
					catch (Exception ex)
					{
						return new TemperatureEntryResult(RequestStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new TemperatureEntryResult(RequestStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
#endregion
	}
}