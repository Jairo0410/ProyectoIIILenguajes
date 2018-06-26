using Data;
using Domain;
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

        public String addToCart(String clientName, int itemID)
        {
            return this.clientData.addToCart(clientName, itemID);
        }

        public String removeFromCart(String clientName, int itemID)
        {
            return this.clientData.removeFromCart(clientName, itemID);
        }

        public LinkedList<Item> getCart(String clientName, String date)
        {
            return this.clientData.getCart(clientName, date);
        }
    }
}
