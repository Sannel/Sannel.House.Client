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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sannel.House.Devices.Client;
using Sannel.House.SensorLogging.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client
{
	public class HouseClient : ClientBase
	{
		protected readonly DevicesClient devices;
		protected readonly SensorLoggingClient sensorLogging;
		protected readonly IConfiguration configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="HouseClient"/> class.
		/// </summary>
		/// <param name="factory">The factory.</param>
		/// <param name="logger">The logger.</param>
		public HouseClient(IHttpClientFactory factory, IConfiguration configuration, ILogger logger) 
			: base(factory, 
				configuration["Client:BaseAddress"],
				logger)
		{
			devices = new DevicesClient(factory, new Uri(configuration["Client:BaseAddress"]), logger);
			sensorLogging = new SensorLoggingClient(factory, new Uri(configuration["Client:BaseAddress"]), logger);
			this.configuration = configuration;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HouseClient"/> class.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <param name="logger">The logger.</param>
		public HouseClient(HttpClient client, IConfiguration configuration, ILogger logger)
			: base(client, 
				configuration["Client:BaseAddress"],
				logger)
		{
			devices = new DevicesClient(client, new Uri(configuration["Client:BaseAddress"]), logger);
			sensorLogging = new SensorLoggingClient(client, new Uri(configuration["Client:BaseAddress"]), logger);
			this.configuration = configuration;
		}

		/// <summary>
		/// Gets the client.
		/// </summary>
		/// <returns></returns>
		protected override HttpClient GetClient()
			=> client ?? factory.CreateClient(nameof(HouseClient));

		/// <summary>
		/// Gets the devices.
		/// </summary>
		/// <value>
		/// The devices.
		/// </value>
		public DevicesClient Devices
			=> devices;

		/// <summary>
		/// Gets the sensor logging.
		/// </summary>
		/// <value>
		/// The sensor logging.
		/// </value>
		public SensorLoggingClient SensorLogging
			=> sensorLogging;

		/// <summary>
		/// Gets or sets the authentication token.
		/// </summary>
		/// <value>
		/// The authentication token.
		/// </value>
		public override string AuthToken
		{
			get => base.AuthToken;
			set
			{
				base.AuthToken = value;
				devices.AuthToken = value;
				sensorLogging.AuthToken = value;
			}
		}

		/// <summary>
		/// Gets or sets the expires at.
		/// </summary>
		/// <value>
		/// The expires at.
		/// </value>
		public DateTimeOffset ExpiresAt { get; protected set; } = DateTimeOffset.MinValue;


		/// <summary>
		/// Login to the identity server
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<LoginResults> LoginAsync(string username, string password)
		{
			var result = await PostAsync<LoginResults>("/connect/token", new
			{
				grant_type = "password",
				username,
				password,
				client_id = configuration["Client:ClientId"],
				client_secret = configuration["Client:ClientSecret"]
			});

			if(result.Success)
			{
				AuthToken = result.AccessToken;
				ExpiresAt = result.ExpiresAt;
			}

			return result;
		}

	}
}
