using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
    public class TaskManagmentController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
