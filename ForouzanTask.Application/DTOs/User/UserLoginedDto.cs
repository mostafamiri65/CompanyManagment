using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.User
{
	public class UserLoginedDto
	{
		public Guid Id { get; set; }
		public string? FullName { get; set; }
		public string? UserName { get; set; }
	}
}
