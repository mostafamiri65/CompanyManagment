using ForouzanTask.DataLayer.Entities.Base;
using ForouzanTask.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbUserInProject : BaseEntity
    {
        public TbUserInProject()
        {

        }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectRoleId { get; set; }
        public string? Description { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
        [ForeignKey("UserId")]
        public virtual TbUser? TbUser { get; set; }
        [ForeignKey("ProjectRoleId")]public virtual TbProjectRole TbProjectRole { get; set; }
    }
}
