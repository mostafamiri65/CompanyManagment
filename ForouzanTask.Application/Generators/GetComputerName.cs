using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmSoft.Application.Generators
{
    public static class GetComputerName
    {
        public static string GetCoputerName()
        {
            return Environment.MachineName.ToString();
        }
    }
}
