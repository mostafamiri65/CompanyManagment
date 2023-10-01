using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectType
    {
        public TbProjectType()
        {

        }
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual List<TbProject>? TbProjects { get; set; }
    }
}
