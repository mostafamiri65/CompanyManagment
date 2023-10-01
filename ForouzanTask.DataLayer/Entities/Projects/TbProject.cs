using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProject : BaseEntity
    {
        public TbProject()
        {

        }
        public string? Title { get; set; }
        public Guid ProjectTypeId { get; set; }
        public string? Description { get; set; }
        public string? TrackingCode { get; set; }
        public bool IsApproved { get; set; }

        [ForeignKey("ProjectTypeId")]
        public virtual TbProjectType? TbProjectType { get; set; }
        public virtual List<TbProjectRole>? TbProjectRoles { get; set; }
        public virtual List<TbProjectTask>? TbProjectTasks { get; set; }
    }
}
