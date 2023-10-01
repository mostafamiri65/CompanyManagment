using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Extensions
{
    public static class StringExtensions
    {
        public static string ShowInMainPage(this string text)
        {
            if (text.Length > 100)
            {
                var result = text.Substring(0,100);
                return result + "...";
            }
            return text;

        }
    }
}
