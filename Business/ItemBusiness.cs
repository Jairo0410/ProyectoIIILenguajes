using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Business
{
    public class ItemBusiness
    {
        private ItemData itemData;

        public ItemBusiness(String connectionString)
        {
            this.itemData = new ItemData(connectionString);
        }

        public String addCategory(String categoryName)
        {
            return this.itemData.addCategory(categoryName);
        }

        public LinkedList<String> getCategories()
        {
            return this.itemData.getCategories();
        }

        public String addItem(String name, float price, String description, byte[] image, String category)
        {
            return this.itemData.addItem(name, price, description, image, category);
        }

        public LinkedList<Item> getItems(String date)
        {
            return this.itemData.getItems(date);
        }

        public String addOfferItems(DataTable items, float discount, String initDate, String endDate)
        {
            if(discount <= 0)
            {
               return "El porcentaje de descuento debe ser mayor a 0";
            }

            if(Util.compare(initDate, Util.getAppDate()) < 0)
            {
                return "La fecha de inicio de la oferta no puede ser menor a la de hoy";
            }

            if(Util.compare(initDate, endDate) > 0)
            {
                return "La fecha de fin no puede ser menor de la de inicio";
            }

            return this.itemData.addOfferItems(items, discount, initDate, endDate);
        }

        public String removeItem(int code)
        {
            return this.itemData.removeItem(code);
        }
    }
}
