using ForouzanTask.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Services.Interfaces
{
	public interface IAccountService
	{
		Task<UserLoginedDto?> GetUserForLogin(string username , string password );
	}
}
