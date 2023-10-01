using ForouzanTask.DataLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.DataLayer.Entities.CompanyClass
{
    public class TbOurProject : BaseEntity
    {
        public TbOurProject() { }
        [MaxLength(500)]
        public string? Title { get; set; }
        [MaxLength(5000)]
        public string? Description { get; set; }
        [MaxLength(500)]
        public string? Image { get; set; }

    }
}
