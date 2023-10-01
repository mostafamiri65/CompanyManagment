using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Outer
{
    public class CreateProjectDto
    {
        public Guid ProjectTypeId { get; set; }
        public string? Title { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? RequesterName { get; set; }
        [MaxLength(12)]
        public string? RequesterMobile { get; set; }
        public IFormFile? DocumentFile { get; set; }
        public string? DocumentDescription { get; set; }

    }
}
