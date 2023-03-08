using System;
using Microsoft.AspNetCore.Identity;

namespace Weather.Messages.Requests
{
	public class RegisterRequest 
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }


	}
}

