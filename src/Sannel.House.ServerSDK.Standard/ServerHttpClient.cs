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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if STANDARD
using System.Net.Http;
using System.Net;
#else
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
#endif

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// The client to use with ServerContext
	/// </summary>
	/// <seealso cref="Sannel.House.ServerSDK.IHttpClient" />
	/// <seealso cref="System.IDisposable" />
	public sealed class ServerHttpClient : IHttpClient, IDisposable
	{
#if STANDARD
		private HttpClientHandler httpFilter = new HttpClientHandler();
#else
		private HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
#endif
		private HttpClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerHttpClient"/> class.
		/// </summary>
		public ServerHttpClient()
		{
			client = new HttpClient(httpFilter);
		}

		public void Dispose()
		{
			client?.Dispose();
		}

		/// <summary>
		/// Does a Get request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <returns></returns>
		public
#if STANDARD
			async Task<HttpClientResult>
#else
			IAsyncOperation<HttpClientResult>
#endif
			GetAsync(Uri requestUri)
		{
#if !STANDARD
			return Task.Run(async () =>
			{
#endif
				var result = await client.GetAsync(requestUri);
				var data = await result.Content.ReadAsStringAsync();
				return new HttpClientResult()
				{
					StatusCode = result.StatusCode,
					Content = data
				};
#if !STANDARD
			}).AsAsyncOperation();
#endif
		}

		/// <summary>
		/// Does a Post request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <param name="data">The data allowed to be null</param>
		/// <returns></returns>
		public
#if STANDARD
			async Task<HttpClientResult>
#else
			IAsyncOperation<HttpClientResult>
#endif
			PostAsync(Uri requestUri, IDictionary<string, string> data)
		{
#if STANDARD
			FormUrlEncodedContent content;
			if(data != null)
			{
				content = new FormUrlEncodedContent(data);
			}
			else
			{
				content = new FormUrlEncodedContent(new Dictionary<String, String>());
			}
#else
			return Task.Run(async () =>
			{
				HttpFormUrlEncodedContent content;
				if (data != null)
				{
					content = new HttpFormUrlEncodedContent(data);
				}
				else
				{
					content = new HttpFormUrlEncodedContent(new Dictionary<String, String>());
				}
#endif

			var result = await client.PostAsync(requestUri, content);
				var rdata = await result.Content.ReadAsStringAsync();

				return new HttpClientResult()
				{
					StatusCode = result.StatusCode,
					Content = rdata
				};
#if !STANDARD
			}).AsAsyncOperation();
#endif
		}

		/// <summary>
		/// Gets the cookie value.
		/// </summary>
		/// <param name="uri">The URI of the cookie.</param>
		/// <param name="cookieName">Name of the cookie.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public string GetCookieValue(Uri uri, string cookieName)
		{
#if STANDARD
			var cookies = httpFilter.CookieContainer.GetCookies(uri);
			Cookie c = null;
			foreach(Cookie cc in cookies)
#else
			var cookies = httpFilter.CookieManager.GetCookies(uri);
			HttpCookie c = null;
			foreach(HttpCookie cc in cookies)
#endif
			{
				if(String.Compare(cc.Name, cookieName, true) == 0)
				{
					c = cc;
					break;
				}
			}

			if(c != null)
			{
				return c.Value;
			}

			return null;
		}
	}
}
