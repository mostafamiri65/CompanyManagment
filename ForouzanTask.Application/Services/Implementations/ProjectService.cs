using ForouzanTask.Application.DTOs.Project.Inner;
using ForouzanTask.Application.DTOs.Project.Outer;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Generators;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using ForouzanTask.DataLayer.Context;
using ForouzanTask.DataLayer.Entities.Common;
using ForouzanTask.DataLayer.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        #region Ctor
        private readonly ForouzanTaskContext _context;
        public ProjectService(ForouzanTaskContext context)
        {
            _context = context;
        }

        #endregion
        #region GetAll - GetById
        public async Task<List<ProjectListDto>?> GetAll(Guid userId)
        {
            var userRole = await _context.TbUserRoles.Where(x => x.UserId == userId)
                .Select(r => r.RoleId).ToListAsync();
            var manager = await _context.TbRoles.SingleOrDefaultAsync(r => r.IsManager);

            List<ProjectListDto> result = new List<ProjectListDto>();
            if (manager != null && userRole.Contains(manager.Id))
            {
                var projectlist = await _context.TbProjects
                    .Include(p => p.TbProjectType)
                    .Where(p => !p.IsDelete && !p.IsApproved).ToListAsync();
                var requester = await _context.TbProjectRequests
                    .Where(r => !r.IsDelete).ToListAsync();

                foreach (var project in projectlist)
                {
                    ProjectListDto dto = new ProjectListDto();
                    dto.Id = project.Id;
                    dto.CreateDate = project.CreateDate;
                    dto.Title = project.Title;
                    dto.Description = project.Description;
                    dto.ProjectTypeName = project.TbProjectType?.Name;
                    dto.TrackingCode = project.TrackingCode;
                    dto.IsApproved = project.IsApproved;
                    dto.RequesterName = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.RequesterName;
                    dto.RequesterMobile = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.RequesterMobile;
                    dto.RequesterDescription = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.Description;
                    result.Add(dto);
                }
            }

            return result;
        }
        public async Task<ProjectTaskDetailsForAdminDto> GetAllDetailsForAdmin(Guid taskId)
        {
            ProjectTaskDetailsForAdminDto dto = new ProjectTaskDetailsForAdminDto();
            var taskDetails = await _context.TbProjectTaskDetails
                .Where(t => t.TaskId == taskId).ToListAsync();
            dto.ProjectTaskDetails = taskDetails;
            var tasks = await _context.TbProjectTasks.SingleAsync(t => t.Id == taskId);
            dto.ProjectTask = tasks;
            var project = await _context.TbProjects.SingleAsync(t => t.Id == tasks.ProjectId);
            dto.Project = project;

            var values = await _context.TbTaskRequestedValues.Include(d => d.TbTaskRequested)
                .Where(v => v.TbTaskRequested != null && v.TbTaskRequested.TaskId == taskId).ToListAsync();
            dto.RequestedValues = values;

            return dto;
        }
        public async Task<List<OuterProjectTypeDto>> GetAllTypesForCreate()
        {
            var projectTypes = await _context.TbProjectTypes.ToListAsync();
            List<OuterProjectTypeDto> outerList = new List<OuterProjectTypeDto>();
            foreach (var type in projectTypes)
            {
                OuterProjectTypeDto projectTypeDto = new OuterProjectTypeDto();
                projectTypeDto.Id = type.Id;
                projectTypeDto.Name = type.Name;
                outerList.Add(projectTypeDto);
            }
            return outerList;
        }
        public async Task<List<ProjectListDto>?> GetAllApproved(Guid userId)
        {
            var userRole = await _context.TbUserRoles.Where(x => x.UserId == userId)
                .Select(r => r.RoleId).ToListAsync();
            var manager = await _context.TbRoles.SingleOrDefaultAsync(r => r.IsManager);
            List<ProjectListDto> result = new List<ProjectListDto>();
            if (manager != null && userRole.Contains(manager.Id))
            {
                var projectlist = await _context.TbProjects
                   .Include(p => p.TbProjectType)
                   .Where(p => !p.IsDelete && p.IsApproved).ToListAsync();
                var requester = await _context.TbProjectRequests
                   .Where(r => !r.IsDelete).ToListAsync();

                foreach (var project in projectlist)
                {
                    ProjectListDto dto = new ProjectListDto();
                    dto.Id = project.Id;
                    dto.CreateDate = project.CreateDate;
                    dto.Title = project.Title;
                    dto.Description = project.Description;
                    dto.ProjectTypeName = project.TbProjectType?.Name;
                    dto.TrackingCode = project.TrackingCode;
                    dto.IsApproved = project.IsApproved;
                    dto.RequesterName = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.RequesterName;
                    dto.RequesterMobile = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.RequesterMobile;
                    dto.RequesterDescription = requester.FirstOrDefault(r => r.ProjectId == project.Id)?.Description;
                    var responsUser = await _context.TbUserInProjects
                        .Where(r => r.ProjectId == project.Id).ToListAsync();
                    List<TbUser> users = new List<TbUser>();
                    foreach (var us in responsUser)
                    {
                        var user = await _context.TbUsers.SingleOrDefaultAsync(u => u.Id == us.UserId);
                        if (user != null) users.Add(user);
                    }
                    dto.ResponsUsers = users;
                    result.Add(dto);
                }
            }
            else
            {
                var projectList = await _context.TbUserInProjects
                    .Include(p => p.TbProject).Where(u => u.UserId == userId).ToListAsync();
                var requester = await _context.TbProjectRequests
                 .Where(r => !r.IsDelete).ToListAsync();
                foreach (var project in projectList)
                {
                    ProjectListDto dto = new ProjectListDto();
                    if (project.TbProject != null)
                    {
                        dto.Id = project.TbProject.Id;
                        dto.CreateDate = project.TbProject.CreateDate;
                        dto.Title = project.TbProject.Title;
                        dto.Description = project.TbProject.Description;
                        dto.ProjectTypeName = project.TbProject.TbProjectType?.Name;
                        dto.TrackingCode = project.TbProject.TrackingCode;
                        dto.IsApproved = project.TbProject.IsApproved;
                        dto.RequesterName = requester.FirstOrDefault(r => r.ProjectId == project.TbProject.Id)?.RequesterName;
                        dto.RequesterMobile = requester.FirstOrDefault(r => r.ProjectId == project.TbProject.Id)?.RequesterMobile;
                        dto.RequesterDescription = requester.FirstOrDefault(r => r.ProjectId == project.TbProject.Id)?.Description;
                        dto.ResponsibleUser = await _context.TbUsers.SingleOrDefaultAsync(u =>
                        u.Id == project.UserId);
                        result.Add(dto);
                    }
                }
            }
            return result;
        }
        public async Task<ProjectDetailsDto> GetProjectById(Guid projectId)
        {
            var project = await _context.TbProjects.SingleOrDefaultAsync(p => p.Id == projectId);
            var documents = await _context.TbProjectDocuments.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var notes = await _context.TbProjectNotes.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var requesters = await _context.TbProjectRequests.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var roles = await _context.TbProjectRoles.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var users = await _context.TbUserInProjects.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var tasks = await _context.TbProjectTasks.Where(d => !d.IsDelete && d.ProjectId == projectId).ToListAsync();
            var taskDetails = await _context.TbProjectTaskDetails
                .Where(d => !d.IsDelete && d.TbProjectTask != null && d.TbProjectTask.ProjectId == projectId).ToListAsync();

            ProjectDetailsDto dto = new ProjectDetailsDto();
            if (project != null)
            {
                dto.Id = project.Id;
                dto.Title = project.Title;
                dto.Description = project.Description;
                dto.IsApproved = project.IsApproved;
                dto.CreateDate = project.CreateDate.ToShamsi();
                dto.ProjectType = await _context.TbProjectTypes.SingleAsync(t => t.Id == project.ProjectTypeId);
                dto.Documents = documents;
                dto.Notes = notes;
                dto.Requesters = requesters;
                dto.Roles = roles;
                dto.Users = users;
                dto.Tasks = tasks;
                dto.TaskDetails = taskDetails;
            }

            return dto;
        }

        public async Task<TbProjectDocument?> GetDocumentById(Guid documentId)
        {
            var document = await _context.TbProjectDocuments.SingleOrDefaultAsync(d => d.Id == documentId);
            return document;
        }

        public async Task<List<DefaultTitlesDto>> GetAllDefaultTitles()
        {
            List<DefaultTitlesDto> list = new List<DefaultTitlesDto>();
            var titles = await _context.TbProjectTaskTitleDefaults.ToListAsync();
            foreach (var title in titles)
            {
                list.Add(new DefaultTitlesDto()
                {
                    Id = title.Id,
                    DefaultTitle = title.DefaultTitle,
                    DefaultDescription = title.DefaultDescription
                });

            }
            return list;
        }
        public async Task<List<UserListForTasksDto>> GetUserswithRoles(Guid userId)
        {
            var users = await _context.TbUsers.Where(u => u.Id != userId).ToListAsync();
            List<UserListForTasksDto> list = new List<UserListForTasksDto>();
            foreach (var user in users)
            {
                UserListForTasksDto dto = new UserListForTasksDto();
                dto.Id = user.Id;
                if (user.FullName != null) dto.FullName = user.FullName;
                var roles = await _context.TbUserRoles.Where(r => r.UserId == user.Id)
                    .Select(r => r.RoleId).ToListAsync();
                var admin = await _context.TbRoles.SingleAsync(r => r.IsManager);
                var employee = await _context.TbRoles.SingleAsync(r => r.IsEmployee);

                if (roles.Contains(admin.Id)) dto.RoleName = admin.Name;
                if (roles.Contains(employee.Id)) dto.RoleName = employee.Name;
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<ProjectRolesListDto>> GetAllRoles(Guid projectId)
        {
            var projectRoles = await _context.TbProjectRoles
                 .Where(r => r.ProjectId == projectId).ToListAsync();
            List<ProjectRolesListDto> list = new List<ProjectRolesListDto>();
            foreach (var role in projectRoles)
            {
                ProjectRolesListDto r = new ProjectRolesListDto()
                {
                    Id = role.Id,
                    Name = role.Title
                };
                list.Add(r);
            }
            return list;
        }

        #endregion

        public async Task<bool> IsAdmin(Guid userId)
        {
            var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            var admin = await _context.TbRoles.SingleAsync(r => r.IsManager);
            if (userRole.RoleId == admin.Id)
                return true;
            return false;
        }

        #region ADD For ADMIN   
        public async Task<Guid> AddProject(CreateProjectInnerDto createProject, Guid userId)
        {
            TbProject project = new TbProject
            {
                Id = Guid.NewGuid(),
                ProjectTypeId = createProject.ProjectTypeId,
                Title = createProject.Title,
                Description = createProject.Description,
                TrackingCode = NameGenerator.GenrateTrackingCode(),
                IsApproved = true,
                CreateUserId = userId,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            };
            await _context.TbProjects.AddAsync(project);

            TbProjectRequest request = new TbProjectRequest
            {
                Id = Guid.NewGuid(),
                ProjectId = project.Id,
                RequesterName = "پروژه داخلی شرکت",
                RequesterMobile = "0000000000",
                Description = createProject.Description,
                CreateUserId = userId,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            };
            await _context.TbProjectRequests.AddAsync(request);

            if (createProject.DocumentFile != null)
            {

                TbProjectDocument document = new TbProjectDocument
                {
                    Id = Guid.NewGuid(),
                    ProjectId = project.Id,
                    DocumentName = NameGenerator.GenerateUniqCode() + Path.GetExtension(createProject.DocumentFile.FileName),
                    DocumentDescription = createProject.DocumentDescription,
                    CreateUserId = userId,
                    LastModifiedUserIp = GetIpAddress.GetIp(),
                    LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
                };
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg",
                ".pdf",
                ".rar",
                ".zip"
                };

                var result = createProject.DocumentFile.UploadFile(document.DocumentName, PathTools.ProjectDocumentServerPath, validFormats);
                if (!result)
                {
                    return Guid.Empty;
                }
                await _context.TbProjectDocuments.AddAsync(document);
            }



            await _context.SaveChangesAsync();
            return project.Id;
        }


        public async Task<bool> AddFileToProject(AddFilesDto addFiles, Guid userId)
        {
            if (addFiles.file != null)
            {
                TbProjectDocument document = new TbProjectDocument
                {
                    Id = Guid.NewGuid(),
                    ProjectId = addFiles.ProjectId,
                    DocumentName = NameGenerator.GenerateUniqCode() + Path.GetExtension(addFiles.file.FileName),
                    DocumentDescription = addFiles.Description,
                    CreateUserId = userId,
                    LastModifiedUserIp = GetIpAddress.GetIp(),
                    LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
                };
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg",
                ".pdf",
                ".rar",
                ".zip"
                };

                var result = addFiles.file.UploadFile(document.DocumentName, PathTools.ProjectDocumentServerPath, validFormats);
                if (result)
                {
                    await _context.TbProjectDocuments.AddAsync(document);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            return false;
        }

        public async Task<bool> AddNoteToProject(AddNoteDto addnote, Guid userId)
        {
            TbProjectNote note = new TbProjectNote()
            {
                Id = Guid.NewGuid(),
                ProjectId = addnote.ProjectId,
                CreateDate = DateTime.Now,
                Description = addnote.Description,
                CreateUserId = userId,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            };
            await _context.TbProjectNotes.AddAsync(note);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRoleToProject(AddRolesDto addRole, Guid userId)
        {
            TbProjectRole role = new TbProjectRole()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                CreateUserId = userId,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp()),
                Title = addRole.RoleTitle,
                ProjectId = addRole.ProjectId,
                HasAccessForDelete = addRole.HasAccessForDelete,
                HasAccessForEdit = addRole.HasAccessForEdit,
                HasAccessForView = addRole.HasAccessForView,
                IsDelete = false
            };
            await _context.TbProjectRoles.AddAsync(role);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddTaskToProject(AddTaskDto addTask, Guid userId)
        {
            TbProjectTask task = new TbProjectTask();
            task.Id = Guid.NewGuid();
            task.CreateUserId = userId;
            task.LastModifiedUserIp = GetIpAddress.GetIp();
            task.LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp());
            if (addTask.DoingUserId != null) task.UserId = (Guid)addTask.DoingUserId;
            if (addTask.Title != null) task.TaskTitle = addTask.Title;
            if (addTask.IsUsedDefaults)
            {
                var defaultTitle = await _context.TbProjectTaskTitleDefaults.SingleOrDefaultAsync(d =>
                d.Id == addTask.ProjectTaskTitleId);
                task.TaskTitle = defaultTitle.DefaultTitle;
                task.TaskDescription = defaultTitle.DefaultDescription;
            }
            task.ProjectId = addTask.ProjectId;
            task.ExpireDate = DateTime.Now.AddDays(addTask.NumberOfDaysHasTime);
            if (addTask.Description != null) task.TaskDescription = addTask.Description;
            await _context.TbProjectTasks.AddAsync(task);
            if (addTask.RequestedTitles != null)
            {
                List<string> requestedList = addTask.RequestedTitles.Split("-").ToList();
                foreach (string title in requestedList)
                {
                    TbTaskRequested req = new TbTaskRequested();
                    req.TaskId = task.Id;
                    req.Id = Guid.NewGuid();
                    req.RequestedTitle = title;
                    await _context.TbTaskRequesteds.AddAsync(req);

                }
            }

            TbUserInProject user = new TbUserInProject();
            user.UserId = (Guid)addTask.DoingUserId;
            user.ProjectId = addTask.ProjectId;
            user.ProjectRoleId = addTask.RoleId;
            user.Description = task.TaskDescription;
            user.Id = Guid.NewGuid();
            user.CreateUserId = userId;
            user.LastModifiedUserIp = GetIpAddress.GetIp();
            user.LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp());
            await _context.TbUserInProjects.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }



        #endregion

        #region Employee
        public async Task<List<TaskListDto>> GetAllTasks(Guid userId)
        {
            var tasks = await _context.TbProjectTasks.Where(p => p.UserId == userId).ToListAsync();
            List<TaskListDto> list = new List<TaskListDto>();
            foreach (var task in tasks)
            {
                TaskListDto dto = new TaskListDto();
                dto.Project = await _context.TbProjects.SingleAsync(p => p.Id == task.ProjectId);
                dto.UserId = task.UserId;
                dto.ProjectTask = task;
                dto.ProjectTaskDetails = await _context.TbProjectTaskDetails
                    .Where(t => t.TaskId == task.Id).ToListAsync();
                list.Add(dto);
            }
            return list;
        }

        public async Task<TaskListDto> GetTaskById(Guid taskId)
        {
            var contextTask = await _context.TbProjectTasks.SingleOrDefaultAsync(d => d.Id == taskId);
            TaskListDto dto = new TaskListDto();
            if (contextTask != null)
            {
                dto.Project = await _context.TbProjects
                    .SingleAsync(p => p.Id == contextTask.ProjectId);
                dto.UserId = contextTask.UserId;
                dto.ProjectTask = contextTask;
                dto.ProjectTaskDetails = await _context.TbProjectTaskDetails
                    .Where(t => t.TaskId == contextTask.Id).ToListAsync();
            }
            return dto;
        }

        public async Task<TbProjectDocument?> GetDocumentByName(string documentName)
        {
            var document = await _context.TbProjectDocuments
                .SingleOrDefaultAsync(d => d.DocumentName == documentName);
            return document;
        }

        public async Task<bool> AddTaskDetails(AddTaskDetailsDto taskDetails)
        {
            var task = await _context.TbProjectTasks
                .SingleOrDefaultAsync(t => t.Id == taskDetails.TaskId);
            var project = await _context.TbProjects.SingleOrDefaultAsync(p => p.Id == task.ProjectId);
            TbProjectTaskDetails details = new TbProjectTaskDetails();
            details.TaskId = taskDetails.TaskId;
            details.Desctiption = taskDetails.Desctiption;
            details.CreateUserId = taskDetails.UserId;
            details.LastModifiedUserIp = GetIpAddress.GetIp();
            details.LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp());
            details.CreateDate = DateTime.Now;

            if (taskDetails.file != null)
            {
                var documentName = NameGenerator.GenerateUniqCode() + Path.GetExtension(taskDetails.file.FileName);
                details.DocumentFileName = documentName;
                details.FileDescription = taskDetails.FileDescription;
                TbProjectDocument document = new TbProjectDocument
                {
                    Id = Guid.NewGuid(),
                    ProjectId = project.Id,
                    DocumentName = documentName,
                    DocumentDescription = taskDetails.FileDescription,
                    CreateUserId = taskDetails.UserId,
                    LastModifiedUserIp = GetIpAddress.GetIp(),
                    LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
                };
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg",
                ".pdf",
                ".rar",
                ".zip"
                };

                var result = taskDetails.file.UploadFile(document.DocumentName, PathTools.ProjectDocumentServerPath, validFormats);
                if (!result)
                {
                    return false;
                }
                await _context.TbProjectDocuments.AddAsync(document);
            }
            await _context.TbProjectTaskDetails.AddAsync(details);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<RequestedTitlesDto>?> GetRequestedTitles(Guid taskId)
        {
            var list = new List<RequestedTitlesDto>();
            var titles = await _context.TbTaskRequesteds.Where(t => t.TaskId == taskId).ToListAsync();
            foreach (var title in titles)
            {
                RequestedTitlesDto dto = new RequestedTitlesDto();
                dto.Id = title.Id;
                dto.RequestedTitle = title.RequestedTitle;
                list.Add(dto);
            }
            return list;
        }

        public async Task<bool> AddRequestedValue(List<string> requestedTitles, Guid taskId)
        {
            var requesteds = await _context.TbTaskRequesteds
                 .Where(r => r.TaskId == taskId).ToListAsync();
            for (int i = 0; i < requesteds.Count; i++)
            {
                DateTime create = DateTime.Now;
                TbTaskRequestedValue value = new TbTaskRequestedValue();
                value.Id = Guid.NewGuid();
                value.RequestedId = requesteds[i].Id;
                value.Value = requestedTitles[i];
                value.CreateDate = create;
                await _context.TbTaskRequestedValues.AddAsync(value);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<ChangeProjectDto> GetProjectForChanging(Guid projectId)
        {
            var project = await _context.TbProjects.Include(p => p.TbProjectType)
                    .SingleOrDefaultAsync(p => p.Id == projectId);
            ChangeProjectDto dto = new ChangeProjectDto()
            {
                Id = projectId,
                Title = project.Title,
                ProjectType = project.ProjectTypeId
            };
            return dto;
        }

        public async Task<bool> ChangeProject(ChangeProjectDto changeProject, Guid userId)
        {
            var project = await _context.TbProjects.SingleOrDefaultAsync(p =>
            p.Id == changeProject.Id);
            project.Title = changeProject.Title;
            project.ProjectTypeId = changeProject.ProjectType;
            project.ModifiedUserId = userId;
            _context.TbProjects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }


        #endregion


    }
}
