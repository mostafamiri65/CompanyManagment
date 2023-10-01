using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.User
{
    public class DeleteUser
    {
        public Guid Id { get; set; }
        public string? LastModifiedUserIp { get; set; }
        [MaxLength(30)]
        public string? LastModifiedUserMac { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool IsDelete { get; set; } 

    }
}
