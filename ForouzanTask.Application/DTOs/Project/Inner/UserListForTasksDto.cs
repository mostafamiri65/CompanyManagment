using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    public class UserListForTasksDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
