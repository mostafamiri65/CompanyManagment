using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Common
{
    public class TbUserRole : BaseEntity
    {
        public TbUserRole()
        {
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual TbUser? TbUser { get; set; }
        [ForeignKey("RoleId")]
        public virtual TbRole? TbRole { get; set; }
    }
}
