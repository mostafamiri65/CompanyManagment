using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Generators
{
    public static class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        public static string GenratePersonalCode()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999).ToString();
        }
        public static string GenrateTrackingCode()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999).ToString();
        }
    }
}
