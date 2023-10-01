using ForouzanTask.Application.DTOs.Project.Inner;
using ForouzanTask.Application.DTOs.Project.Outer;
using ForouzanTask.DataLayer.Entities.Projects;

namespace ForouzanTask.Application.Services.Interfaces
{
    public interface IProjectService
    {
        #region GetAll - GetById
        Task<List<ProjectListDto>?> GetAll(Guid userId);
        Task<List<ProjectListDto>?> GetAllApproved(Guid userId);
        Task<List<OuterProjectTypeDto>> GetAllTypesForCreate();
        Task<ProjectDetailsDto> GetProjectById(Guid projectId);
        Task<TbProjectDocument?> GetDocumentById(Guid documentId);
        Task<List<DefaultTitlesDto>> GetAllDefaultTitles();
        Task<List<UserListForTasksDto>> GetUserswithRoles(Guid userId);
        Task<List<ProjectRolesListDto>> GetAllRoles(Guid projectId);
        Task<ProjectTaskDetailsForAdminDto> GetAllDetailsForAdmin(Guid taskId);
        Task<ChangeProjectDto> GetProjectForChanging(Guid projectId);
        Task<bool> ChangeProject(ChangeProjectDto changeProject,Guid userId);
        #endregion
        Task<bool> IsAdmin(Guid userId);
        #region Add For Admin
        Task<Guid> AddProject(CreateProjectInnerDto createProject, Guid userId);
        Task<bool> AddFileToProject(AddFilesDto addFiles, Guid userId);
        Task<bool> AddNoteToProject(AddNoteDto addnote, Guid userId);
        Task<bool> AddRoleToProject(AddRolesDto addRole, Guid userId);
        Task<bool> AddTaskToProject(AddTaskDto addTask, Guid userId);

        #endregion
        #region Employee
        Task<List<TaskListDto>> GetAllTasks(Guid userId);
        Task<TaskListDto> GetTaskById(Guid taskId);
        Task<TbProjectDocument?> GetDocumentByName(string documentName);
        Task<bool> AddTaskDetails(AddTaskDetailsDto taskDetails);
        Task<List<RequestedTitlesDto>?> GetRequestedTitles(Guid taskId);
        Task<bool> AddRequestedValue(List<string> requestedTitles,Guid taskId);
        #endregion

    }
}
