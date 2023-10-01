using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.DataLayer.Entities.Projects
{
    public class TbTaskRequestedValue
    {
        public Guid Id { get; set; }
        public Guid RequestedId { get; set; }
        public string? Value { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ForeignKey("RequestedId")]public TbTaskRequested? TbTaskRequested { get; set; }
    }
}
