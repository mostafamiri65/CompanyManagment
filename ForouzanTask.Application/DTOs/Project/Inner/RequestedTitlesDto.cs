using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class RequestedTitlesDto
    {
        public Guid Id { get; set; }
      
        public string? RequestedTitle { get; set; }
    }
}
