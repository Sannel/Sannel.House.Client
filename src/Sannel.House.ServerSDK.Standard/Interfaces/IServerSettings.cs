using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// Gives the information needed for the sdk to connect to the server
	/// </summary>
	public interface IServerSettings
	{
		/// <summary>
		/// Gets or sets the server URI used as the base uri to connect to the server
		/// </summary>
		/// <value>
		/// The server URI.
		/// </value>
		Uri ServerUri
		{
			get;
			set;
		}
	}
}
