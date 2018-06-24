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
        private static String appDate = null;

        public static String getAppDate()
        {
            if(appDate == null)
            {
                String year = format(DateTime.Today.Year);
                String month = format(DateTime.Today.Month);
                String day = format(DateTime.Today.Day);

                appDate = year + month + day;
            }
            return appDate;
        }

        public static String format(int value)
        {
            String result = "";

            if(value < 10)
            {
                result = result + "0";
            }

            return result + value.ToString();
        }

        public static void setAppDate(String date)
        {
            appDate = date.Replace("-", "");
        }

        public static String md5(String cadena)
        {
            return cadena;
        }
    }
}
