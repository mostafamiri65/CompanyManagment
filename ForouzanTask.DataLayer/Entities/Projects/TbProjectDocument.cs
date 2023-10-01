using ForouzanTask.DataLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbProjectDocument : BaseEntity
    {
        public TbProjectDocument()
        {

        }
        public Guid ProjectId { get; set; }
        [MaxLength(120)]
        public string? DocumentName { get; set; }
        [MaxLength(2000)]
        public string? DocumentDescription { get; set;}
        [ForeignKey("ProjectId")]
        public virtual TbProject? TbProject { get; set; }
    }
}
