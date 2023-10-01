using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectNote : BaseEntity
    {
        public TbProjectNote()
        {

        }
        public Guid ProjectId { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
    }
}
