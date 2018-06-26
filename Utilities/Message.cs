using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Message
    {
        public static String errorMessage(String message)
        {
            String openTag = "<div class=\"alert alert-danger\">";
            String closeTag = "</div>";
            return openTag + message + closeTag;
        }

        public static String infoMessage(String message)
        {
            String openTag = "<div class=\"alert alert-info\">";
            String closeTag = "</div>";
            return openTag + message + closeTag;
        }

        public static String successMessage(String message)
        {
            String openTag = "<div class=\"alert alert-success\">";
            String closeTag = "</div>";
            return openTag + message + closeTag;
        }

        public static String warningMessage(String message)
        {
            String openTag = "<div class=\"alert alert-success\">";
            String closeTag = "</div>";
            return openTag + message + closeTag;
        }
    }
}
