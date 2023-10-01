using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class CreateProjectInnerDto
    {
        public Guid ProjectTypeId { get; set; }
        public string? Title { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
    
        public IFormFile? DocumentFile { get; set; }
        public string? DocumentDescription { get; set; }
    }
}
