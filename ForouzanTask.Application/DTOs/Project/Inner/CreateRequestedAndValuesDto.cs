using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.DTOs.Project.Inner
{
    internal class CreateRequestedAndValuesDto
    {
        public Guid RequestedId { get; set; }
        public string? Value { get; set; }
        public bool IsGet { get; set; }
    }
}
