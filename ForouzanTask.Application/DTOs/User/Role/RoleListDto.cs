using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.User.Role
{
    public class RoleListDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
    }
}
