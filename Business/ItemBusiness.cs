using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public String addItem(String name, float price, String description, String imageRoute, String category)
        {
            return this.itemData.addItem(name, price, description, imageRoute, category);
        }

        public LinkedList<Item> getItems()
        {
            return this.itemData.getItems();
        }
    }
}
