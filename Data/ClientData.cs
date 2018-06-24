using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClientData
    {
        private String connectionString;

        public ClientData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public String addToCart(String clientName, String itemID)
        {
            return "";
        }
    }
}
