using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.Application.DTOs.User
{
    public class CreateUserDto
    {
        [MaxLength(100)]
        public string? UserName { get; set; }
        [MaxLength(300)]
        public string? FullName { get; set; }
        public string? Password { get; set; }
        [Compare("Password")]
        public string? RePassword { get; set; }
        [MaxLength(12)]
        public string? Mobile { get; set; }
       
        public IFormFile? Avatar { get; set; }
        public Guid RoleId { get; set; }
    }
}
