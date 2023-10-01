using Microsoft.AspNetCore.Http;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class AddTaskDetailsDto
    {
        public Guid TaskId { get; set; }
        public string? Desctiption { get; set; }
        public IFormFile? file { get; set; }
        public string? FileDescription { get; set; }

        public Guid UserId { get; set; }


    }
}
