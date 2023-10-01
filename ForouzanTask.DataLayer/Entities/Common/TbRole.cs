using System.ComponentModel.DataAnnotations;

namespace ForouzanTask.DataLayer.Entities.Common
{
    public class TbRole
    {
        public TbRole(string name)
        {
            Name = name;
        }
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsManager { get; set; } 
        public bool IsEmployee { get; set; }


        public virtual List<TbUserRole>? TbUserRoles { get; set; }
    }
}
