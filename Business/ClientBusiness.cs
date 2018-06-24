using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClientBusiness
    {

        private ClientData clientData;

        public ClientBusiness(String connString)
        {
            this.clientData = new ClientData(connString);
        }

        public String addToCart(String clientName, String itemID)
        {
            return this.clientData.addToCart(clientName, itemID);
        }


    }
}
