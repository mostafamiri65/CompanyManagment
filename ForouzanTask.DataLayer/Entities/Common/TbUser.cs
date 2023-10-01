using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.DataLayer.Entities.Common
{
    public class TbUser : BaseEntity
    {
        public TbUser()
        {
           
        }
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
        public virtual List<TbUserRole>? TbUserRoles { get; set; }
    }
}
