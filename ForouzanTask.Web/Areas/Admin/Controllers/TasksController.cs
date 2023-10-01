using ForouzanTask.Application.DTOs.Project.Inner;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
    public class TasksController : BaseAdminController
    {
        private readonly IProjectService _projectService;
        public TasksController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _projectService.GetAllTasks(User.GetUserId());
            return View(list);
        }

        public async Task<IActionResult> ShowDetails(Guid id)
        {
            var task = await _projectService.GetTaskById(id);
            return View(task);
        }

        public async Task<IActionResult> AddTaskDetails(Guid id)
        {
            var titles = await _projectService.GetRequestedTitles(id);
            ViewData["Titles"] = titles;
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTaskDetails(AddTaskDetailsDto taskDetails, List<string> value)
        {
            taskDetails.UserId = User.GetUserId();
            var result = await _projectService.AddTaskDetails(taskDetails);
            var values = await _projectService.AddRequestedValue(value, taskDetails.TaskId);
            if (result && values)
            {
                return RedirectToAction("ShowDetails", new { id = taskDetails.TaskId });
            }
            TempData[ErrorMessage] = "در انجام عملیات مشکلی پیش آمده است. عملیات انجام نشد";
            return RedirectToAction("ShowDetails", new { id = taskDetails.TaskId });

        }

        #region Download Files
        public async Task<IActionResult> DownloadFile(string documentName)
        {
            var uploadFile = await _projectService.GetDocumentByName(documentName);
            if (uploadFile != null && uploadFile.DocumentName != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), PathTools.ProjectDocumentServerPath,
                    uploadFile.DocumentName);
                string fileName = uploadFile.DocumentName;
                byte[] file = System.IO.File.ReadAllBytes(filePath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
        #endregion


    }
}
