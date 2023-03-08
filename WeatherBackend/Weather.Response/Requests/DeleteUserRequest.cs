using System;
using Microsoft.AspNetCore.Identity;

namespace Weather.Messages.Requests
{
	public class DeleteUserRequest 
	{
		public string Username { get; set; }

	}
}

