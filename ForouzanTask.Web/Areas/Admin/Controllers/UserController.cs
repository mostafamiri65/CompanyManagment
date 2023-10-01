using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
	public class UserController : BaseAdminController
    {
        private IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }
        public async Task<IActionResult> Index(string? userName, string? mobile, string? fullName)
        {
            ViewBag.Admin = await _userServices.IsAdmin(User.GetUserId());

            Guid userId = User.GetUserId();
            var list = await _userServices.GetAllUsers(userName, mobile, fullName, userId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var roles = await _userServices.GetAllRoles();
            ViewData["Roles"] = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
			if (user.Password != user.RePassword)
			{
				TempData[ErrorMessage] = "رمز عبور با تکرار آن مشابه نیست";
				var roles = await _userServices.GetAllRoles();
				ViewData["Roles"] = roles;
				return View();
			}
			if (user.Mobile!=null &&await _userServices.IsExistMobile(user.Mobile)) {
                TempData[ErrorMessage] = "شماره موبایل تکراری است";
                var roles = await _userServices.GetAllRoles();
                ViewData["Roles"] = roles;
                return View();
            }
            if (user.UserName!=null && await _userServices.IsExistUserName(user.UserName))
            {
                TempData[ErrorMessage] = "نام کاربری تکراری است";
                var roles = await _userServices.GetAllRoles();
                ViewData["Roles"] = roles;
                return View();
            }
            var isCreate = await _userServices.AddUser(user, User?.GetUserId());
            if (!isCreate)
            {
                TempData[ErrorMessage] = "در آپلود فایل مشکلی پیش آمد";
                var roles = await _userServices.GetAllRoles();
                ViewData["Roles"] = roles;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ChangeDetaile(Guid userId)
        {
            var user = await _userServices.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeDetaile(UserDto user)
        {
            var isUpdate = await _userServices.UpdateUser(user);
            if (!isUpdate)
            {
                TempData[ErrorMessage] = "مشکلی پیش آمده";          
            }
            return RedirectToAction("Index");
        }
    }
}
