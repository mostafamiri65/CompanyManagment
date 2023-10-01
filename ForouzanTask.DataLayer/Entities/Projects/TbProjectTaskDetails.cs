using ForouzanTask.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectTaskDetails : BaseEntity
    {
        public TbProjectTaskDetails()
        {

        }
        public Guid TaskId { get; set; }
        public string? Desctiption { get; set; }
        public string? DocumentFileName { get; set; }
        public string? FileDescription { get; set; }
        [ForeignKey("TaskId")]public virtual TbProjectTask? TbProjectTask { get; set; }
    }
}
