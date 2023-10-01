using ForouzanTask.Application.DTOs.Project.Outer;
using ForouzanTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Controllers
{
    public class RequestProjectController : BaseController
    {
        #region Ctor
        private IOuterUserProjectService _outerUserProjectService;
        public RequestProjectController(IOuterUserProjectService outerUserProjectService)
        {
            _outerUserProjectService = outerUserProjectService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            var projectTypes = await _outerUserProjectService.GetAllTypesForCreate();
            ViewData["Types"] = projectTypes;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(CreateProjectDto create)
        {
          
           var result = await _outerUserProjectService.CreateProject(create);
            if (result == Guid.Empty)
            {
                TempData[ErrorMessage] = "فایل پیوستی شما با پسوند مناسب ارسال نشده است.";
                var projectTypes = await _outerUserProjectService.GetAllTypesForCreate();
                ViewData["Types"] = projectTypes;
                return View(create);
            }
            return Redirect("/");
        }
    }
}
