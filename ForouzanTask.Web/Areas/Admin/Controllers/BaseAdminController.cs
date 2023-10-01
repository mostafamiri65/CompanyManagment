using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class BaseAdminController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string WarningMessage = "WarningMessage";
        public static string InfoMessage = "InfoMessage";
        public static string ErrorMessage = "ErrorMessage";
    }
}
