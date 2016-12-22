using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public sealed class LoginResult
	{
		public LoginResult(LoginStatus status, String message)
		{
			this.Status = status;
			this.Message = message;
		}

		public LoginStatus Status
		{
			get;
			set;
		}

		public String Message { get; set; }
	}
}
