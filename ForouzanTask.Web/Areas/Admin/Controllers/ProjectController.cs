using ForouzanTask.Application.DTOs.Project.Inner;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Services.Implementations;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using Microsoft.AspNetCore.Mvc;

namespace ForouzanTask.Web.Areas.Admin.Controllers
{
    public class ProjectController : BaseAdminController
    {
        #region Ctor
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        #endregion

        #region Lists
        public async Task<IActionResult> Index()
        {
            var list = await _projectService.GetAll(User.GetUserId());
            return View(list);
        }
        public async Task<IActionResult> GetApprovedList()
        {
            ViewBag.IsAdmin = await _projectService.IsAdmin(User.GetUserId());
            var list = await _projectService.GetAllApproved(User.GetUserId());
            return View(list);
        }
        #endregion

        #region Create Project
        [HttpGet]
        public async Task<IActionResult> CreateInner()
        {
            var projectTypes = await _projectService.GetAllTypesForCreate();
            ViewData["Types"] = projectTypes;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInner(CreateProjectInnerDto create)
        {
            var project = await _projectService.AddProject(create, User.GetUserId());
            if (project == Guid.Empty)
            {
                TempData[ErrorMessage] = "فایل ارسالی با پسوند غیر قابل قبولی ارسال شده است";
                var projectTypes = await _projectService.GetAllTypesForCreate();
                ViewData["Types"] = projectTypes;
                return View();
            }
            return RedirectToAction("GetApprovedList");
        }

        #endregion

        #region ShowDetails
        public async Task<IActionResult> ShowDetails(Guid id)
        {
            var project = await _projectService.GetProjectById(id);
            return View(project);
        }
        public async Task<IActionResult> ShowTaskDetails(Guid id)
        {
            var details = await _projectService.GetAllDetailsForAdmin(id);
            return View(details);
        }
        #endregion

        #region Download Files
        public async Task<IActionResult> DownloadFile(Guid documentId)
        {
            var uploadFile = await _projectService.GetDocumentById(documentId);
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

        #region Ajax On Details
        public IActionResult AddFile(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(AddFilesDto addFiles)
        {
            var result = await _projectService.AddFileToProject(addFiles, User.GetUserId());
            if (result)
                return RedirectToAction("ShowDetails", new { id = addFiles.ProjectId });
            TempData[ErrorMessage] = "فایل با پسوند اشتباه ارسال شده است. عملیات انجام نشد";
            return RedirectToAction("ShowDetails", new { id = addFiles.ProjectId });

        }
        public IActionResult AddNote(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNote(AddNoteDto addNote)
        {
            var result = await _projectService.AddNoteToProject(addNote, User.GetUserId());
            if (result)
                return RedirectToAction("ShowDetails", new { id = addNote.ProjectId });
            TempData[ErrorMessage] = "مشکلی پیش آمده است. عملیات انجام نشد";
            return RedirectToAction("ShowDetails", new { id = addNote.ProjectId });

        }
        public IActionResult AddRoles(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoles(AddRolesDto addRole)
        {
            var result = await _projectService.AddRoleToProject(addRole, User.GetUserId());
            if (result)
                return RedirectToAction("ShowDetails", new { id = addRole.ProjectId });
            TempData[ErrorMessage] = "مشکلی پیش آمده است. عملیات انجام نشد";
            return RedirectToAction("ShowDetails", new { id = addRole.ProjectId });

        }
        public async Task<IActionResult> AddTask(Guid id)
        {
            var titles = await _projectService.GetAllDefaultTitles();
            ViewData["Title"] = titles;
            ViewData["Roles"] = await _projectService.GetAllRoles(id);
            ViewBag.Id = id;
            var users = await _projectService.GetUserswithRoles(User.GetUserId());
            ViewData["Users"] = users;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskDto addTask)
        {
            var result = await _projectService.AddTaskToProject(addTask, User.GetUserId());
            if (result)
                return RedirectToAction("ShowDetails", new { id = addTask.ProjectId });
            TempData[ErrorMessage] = "مشکلی پیش آمده است. عملیات انجام نشد";
            return RedirectToAction("ShowDetails", new { id = addTask.ProjectId });
        }
        #endregion

        #region AjaxInLists
        public async Task<IActionResult> Change(Guid id)
        {
            var projectTypes = await _projectService.GetAllTypesForCreate();
            ViewData["Types"] = projectTypes;
            var project = await _projectService.GetProjectForChanging(id);
            return View(project);
        }
        [HttpPost]
        public async Task<IActionResult> Change(ChangeProjectDto change)
        {
           await _projectService.ChangeProject(change, User.GetUserId());
            return RedirectToAction("GetApprovedList");
        }
        #endregion
    }
}
