using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectTask : BaseEntity
    {
        public TbProjectTask()
        {

        }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        

        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
        public virtual List<TbProjectTaskDetails>? TbProjectTaskDetails { get; set; }
    }
}
