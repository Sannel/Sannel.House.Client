using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public enum LoginStatus
	{
		Unknown,
		ServerUriNotSet,
		UsernameIsNull,
		PasswordIsNull,
		ServerUriIsNotValid,
		UnableToConnectToServer,
		Exception,
		Success,
		Error
	}

	public enum TemperatureSettingStatus
	{
		Unknown,
		Error,
		ServerUriNotSet,
		NotLoggedIn,
		Exception,
		ServerUriInvalid,
		UnableToConnectToServer,
		Success,
		IdCannotBeDefault
	}
}
