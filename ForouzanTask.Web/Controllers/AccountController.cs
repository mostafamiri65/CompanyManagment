using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.Services.Interfaces;

namespace ForouzanTask.Web.Controllers
{
	public class AccountController : BaseController
	{
		#region Ctor
		private IAccountService _accountService;
		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		#endregion

		#region LogIn

		[HttpGet("Login")]
		public IActionResult Login(string returnUrl = "")
		{
			var result = new LoginViewModel();
			if (!string.IsNullOrEmpty(returnUrl))
			{
				result.ReturnUrl = returnUrl;
			}
			return View(result);
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginViewModel login)
		{
			if (!ModelState.IsValid)
			{
				return View(login);
			}

			if (!string.IsNullOrEmpty(login.UserName) && !string.IsNullOrEmpty(login.Password))
			{
				var user = await _accountService.GetUserForLogin(login.UserName, login.Password);
				if (user == null)
				{
					var result = new LoginViewModel();
					if (!string.IsNullOrEmpty(login.ReturnUrl))
					{
						result.ReturnUrl = login.ReturnUrl;
					}
					TempData[ErrorMessage] = "اطلاعات وارده اشتباه است";
					return View(login);
				}

				if (user.UserName != null)
				{
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name,user.UserName)

					};
					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					var principal = new ClaimsPrincipal(identity);

					var properties = new AuthenticationProperties
					{
						IsPersistent = login.RememberMe
					};

					await HttpContext.SignInAsync(principal, properties);
				}
			}

			if (!string.IsNullOrEmpty(login.ReturnUrl))
			{
				return Redirect(login.ReturnUrl);
			}
			return Redirect("/Admin/Project");
		}

		#endregion

		#region Logout

		[HttpGet("Logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}


		#endregion
	}
}
