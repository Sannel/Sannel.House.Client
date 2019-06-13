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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Client
{
	public class LoginResults : Sannel.House.Client.Results<string>
	{
		/// <summary>
		/// Gets or sets the access token.
		/// </summary>
		/// <value>
		/// The access token.
		/// </value>
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		/// <summary>
		/// Gets or sets the type of the token.
		/// </summary>
		/// <value>
		/// The type of the token.
		/// </value>
		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		private long expiresIn = 0;
		/// <summary>
		/// Gets or sets the expires in.
		/// </summary>
		/// <value>
		/// The expires in.
		/// </value>
		[JsonProperty("expires_in")]
		public long ExpiresIn
		{
			get => expiresIn;
			set
			{
				expiresIn = value;
				ExpiresAt = DateTimeOffset.Now.AddSeconds(value);
			}
		}

		/// <summary>
		/// Gets the expires.
		/// </summary>
		/// <value>
		/// The expires.
		/// </value>
		public DateTimeOffset ExpiresAt
		{
			get;
			private set;
		}

		[JsonProperty("error")]
		public string Error
		{
			get;
			set;
		}

		[JsonProperty("error_description")]
		public string ErrorDescription { get; set;}
	}
}
