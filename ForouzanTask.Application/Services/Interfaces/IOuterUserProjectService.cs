using ForouzanTask.Application.DTOs.Project.Outer;

namespace ForouzanTask.Application.Services.Interfaces
{
    public interface IOuterUserProjectService
    {
        Task<Guid> CreateProject(CreateProjectDto createProject);
        Task<List<OuterProjectTypeDto>> GetAllTypesForCreate();
    }
}
