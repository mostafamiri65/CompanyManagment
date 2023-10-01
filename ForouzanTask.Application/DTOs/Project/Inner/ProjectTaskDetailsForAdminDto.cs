using ForouzanTask.DataLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class ProjectTaskDetailsForAdminDto
    {
        public TbProject? Project { get; set; }
        public TbProjectTask? ProjectTask { get; set; }
        public List<TbProjectTaskDetails>? ProjectTaskDetails { get; set; }
         public List<TbTaskRequestedValue>? RequestedValues { get; set; }

    }
}
