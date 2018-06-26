using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MyControl
    {
        public static String TableHeader(String title)
        {
            return "<th class=\"text-center\">" + title + "</th>";
        }

        public static String TableItem(String content)
        {
            return "<td>" + content + "</td>";
        }
    }
}
