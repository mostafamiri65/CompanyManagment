using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectTaskTitleDefault
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string? DefaultTitle { get; set; }
        [MaxLength(2000)]
        public string? DefaultDescription { get; set; }

    }
}
