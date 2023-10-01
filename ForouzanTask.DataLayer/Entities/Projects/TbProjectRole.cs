using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectRole : BaseEntity
    {
        public TbProjectRole()
        {

        }
        public string? Title { get; set; }
        public Guid ProjectId { get; set; }
        public bool HasAccessForView { get; set; }
        public bool HasAccessForEdit { get; set; }
        public bool HasAccessForDelete { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
    }
}
