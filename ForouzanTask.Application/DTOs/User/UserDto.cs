using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(100)]
        public string? UserName { get; set; }
        [MaxLength(300)]
        public string? FullName { get; set; }
        public string? Password { get; set; }
        [MaxLength(12)]
        public string? Mobile { get; set; }
        [MaxLength(10)]
        public string? PersonalId { get; set; }
        [MaxLength(100)]
        public string? Avatar { get; set; }
        [MaxLength(30)]
        public string? LastModifiedUserIp { get; set; }
        [MaxLength(30)]
        public string? LastModifiedUserMac { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public Guid? CreateUserId { get; set; }
        public bool IsDelete { get; set; } 
    }
}
