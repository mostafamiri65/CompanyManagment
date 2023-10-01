using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectRequest : BaseEntity
    {
        public TbProjectRequest()
        {

        }
        public Guid ProjectId { get; set; }
        [MaxLength(100)]
        public string? RequesterName { get; set; }
        [MaxLength(12)]
        public string? RequesterMobile { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
    }
}
