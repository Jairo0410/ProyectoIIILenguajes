using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item
    {
        private String name;
        private float price;
        private String description;
        private String category;
        private String image_route;

        public Item()
        {
            this.name = "";
            this.price = 0;
            this.description = "";
            this.category = "";
            this.image_route = "";
        }

        public Item(string name, float price, string description, string category, string image_route)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.category = category;
            this.image_route = image_route;
        }

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public string Image_route { get => image_route; set => image_route = value; }
    }
}
