using System.ComponentModel.DataAnnotations.Schema;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbTaskRequested
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string? RequestedTitle { get; set; }

        [ForeignKey("TaskId")]
        public TbProjectTask? TbProjectTask { get; set; }
        public virtual List<TbTaskRequestedValue> TbTaskRequestedValues { get; set; }
    }
}
