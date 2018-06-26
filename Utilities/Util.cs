using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Utilities
{
    public class Util
    {
        private static Boolean isset = false;

        private static String year;
        private static String month;
        private static String day;

        private static void setDate()
        {
            if (!isset)
            {
                year = format(DateTime.Today.Year);
                month = format(DateTime.Today.Month);
                day = format(DateTime.Today.Day);
            }
        }

        public static String getAppDate()
        {
            setDate();
            return dateBySeparator();
        }

        public static String getRawAppDate()
        {
            return dateBySeparator("-");
        }

        public static String format(String value)
        {
            return value.Replace("-", "");
        }

        private static String dateBySeparator(String separator = "")
        {
            setDate();
            return year + separator + month + separator + day;
        }

        private static String format(int value)
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
            String[] datePieces = date.Split('-');

            // if all places of date are set
            if(datePieces.Length >= 3)
            {
                year = datePieces[0];
                month = datePieces[1];
                day = datePieces[2];
            }
        }

        public static String md5(String cadena)
        {
            return cadena;
        }

        public static float getExchange()
        {
            cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos client = new cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos();
            String date = dateBySeparator("/");
            DataSet response = client.ObtenerIndicadoresEconomicos("317", date, date, "Jairo Calderon", "N");

            String exchange = response.Tables[0].Rows[0].ItemArray[2].ToString();

            return float.Parse(exchange);
        }
    }
}
