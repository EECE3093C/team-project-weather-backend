using System;
using Microsoft.AspNetCore.Identity;

namespace Weather.Messages.Requests
{
	public class LoginRequest 
	{
		public string Username { get; set; }

		public string Password { get; set; }

	}
}

