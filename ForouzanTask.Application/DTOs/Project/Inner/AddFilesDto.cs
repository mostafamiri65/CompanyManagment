using Microsoft.AspNetCore.Http;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class AddFilesDto
    {
        public Guid ProjectId { get; set; }
        public IFormFile? file { get; set; }
        public string? Description { get; set; }
    }
}
