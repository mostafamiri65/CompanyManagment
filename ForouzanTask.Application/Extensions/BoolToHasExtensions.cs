using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Extensions
{
    public static class BoolToHasExtensions
    {
        public static string BoolToString(this bool value)
        {
            if(value) { return "دارد"; }
            return "ندارد";
        }
    }
}
