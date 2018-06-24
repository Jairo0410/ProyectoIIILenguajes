using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item
    {
        private int code;
        private String name;
        private float price;
        private String description;
        private String category;
        private String image_route;
        private float discount;

        public Item()
        {
            this.code = 0;
            this.name = "no name";
            this.price = 0;
            this.description = "no description";
            this.category = "no category";
            this.image_route = "no route";
            this.discount = 0;
        }

        public Item(int code, string name, float price, string description, string category, string image_route, float discount)
        {
            this.code = code;
            this.name = name;
            this.price = price;
            this.description = description;
            this.category = category;
            this.image_route = image_route;
            this.discount = discount;
        }

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public string Image_route { get => image_route; set => image_route = value; }
        public float Discount { get => discount; set => discount = value; }
        public int Code { get => code; set => code = value; }
    }
}
