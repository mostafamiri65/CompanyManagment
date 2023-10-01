using ForouzanTask.DataLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class TaskListDto
    {
        public TbProject? Project { get; set; }
        public Guid UserId { get; set; }
        public TbProjectTask? ProjectTask { get; set; }
        public List<TbProjectTaskDetails>? ProjectTaskDetails { get; set; }
    }
}
