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
	public interface IServerContext : IDisposable
	{
#if STANDARD
		Task<LoginResult>
#else
		IAsyncOperation<LoginResult>
#endif
		LoginAsync(String username, String password);

		bool IsAuthenticated
		{
			get;
		}
	}
}
