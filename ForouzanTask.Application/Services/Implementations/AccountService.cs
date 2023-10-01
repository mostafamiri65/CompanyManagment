using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.Securities;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace ForouzanTask.Application.Services.Implementations
{
	public class AccountService : IAccountService
	{
		private ForouzanTaskContext _context;
		public AccountService(ForouzanTaskContext context)
		{
			_context = context;
		}

		public async Task<UserLoginedDto?> GetUserForLogin(string username, string password)
		{
			string pass = HashEncode.GetHashCode(HashEncode.GetHashCode(password));
			var user = await _context.TbUsers.SingleOrDefaultAsync(u => u.UserName == username &&
			u.Password == pass);
			var userLogined = new UserLoginedDto();
			if (user != null && user.FullName != null)
			{
				userLogined.Id = user.Id;
				userLogined.FullName = user.FullName;
				userLogined.UserName = user.UserName;
			}
			return userLogined;
		}
	}
}
