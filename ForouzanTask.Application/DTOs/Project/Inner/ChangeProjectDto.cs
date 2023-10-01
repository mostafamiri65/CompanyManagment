using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class ChangeProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid ProjectType { get; set; }
    }
}
