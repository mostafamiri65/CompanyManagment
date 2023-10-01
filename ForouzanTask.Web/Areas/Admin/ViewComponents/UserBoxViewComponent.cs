using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.ViewComponents
{
    public class UserBoxViewComponent : ViewComponent
    {
        private IUserService _userService;
        public UserBoxViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserById(HttpContext.User.GetUserId());
            return View(user);
        }
    }
}
