using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Utilities
{
    public class Util
    {

        public bool anyEmpty(LinkedList<TextBox> boxes)
        {
            foreach(TextBox box in boxes)
            {
                if (box.Text.Length < 0)
                    return true;
            }

            return false;
        }

        public static String md5(String cadena)
        {
            return cadena;
        }
    }
}
