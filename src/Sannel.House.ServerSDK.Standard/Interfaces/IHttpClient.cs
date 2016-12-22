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
#if !STANDARD
using Windows.Foundation;
#endif

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// Represents the client used to call to the server.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IHttpClient : IDisposable
	{
		/// <summary>
		/// Gets the cookie value.
		/// </summary>
		/// <param name="uri">The URI of the cookie.</param>
		/// <param name="cookieName">Name of the cookie.</param>
		/// <returns></returns>
		String GetCookieValue(Uri uri, String cookieName);

		/// <summary>
		/// Does a Get request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <returns></returns>
#if STANDARD
		Task<HttpClientResult> GetAsync(Uri requestUri);
#else
		IAsyncOperation<HttpClientResult> GetAsync(Uri requestUri);
#endif

		/// <summary>
		/// Does a Post request asynchronous.
		/// </summary>
		/// <param name="requestUri">The request URI.</param>
		/// <param name="data">The data allowed to be null</param>
		/// <returns></returns>
#if STANDARD
		Task<HttpClientResult> PostAsync(Uri requestUri, IDictionary<String, String> data);
#else
		IAsyncOperation<HttpClientResult> PostAsync(Uri requestUri, IDictionary<String, String> data);
#endif
	}
}
