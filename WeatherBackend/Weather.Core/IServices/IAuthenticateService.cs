using System;
using Weather.Core.Models;
using Weather.Messages.Requests;

namespace Weather.Core.IServices
{
	public interface IAuthenticateService
	{
		Task<AspNetUser> Register(RegisterRequest request);

		Task DeleteUser(DeleteUserRequest request);

    }
}

