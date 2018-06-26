﻿using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace ProyectoIIILenguajes
{
    public partial class ArticleList : System.Web.UI.Page
    {
        private LinkedList<Item> items = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            LinkedList <Item> items = new LinkedList<Item>();

            if (this.items == null)
            {
                String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
                ItemBusiness itemBusiness = new ItemBusiness(connectionString);
                items = itemBusiness.getItems(Util.getAppDate());
            }
            else
            {
                items = this.items;
            }

            displayItems(items);

            lblMessage.Text = Util.getExchange().ToString();
            
        }

        public void displayItems(LinkedList<Item> items)
        {
            itemsHolder.Controls.Add(new LiteralControl("<table class=\"table-responsive\">"));

            int columnCount = 3;
            int count = 1;
            bool rowClosed = true;

            foreach (Item item in items)
            {
                float dollarPrice = Util.getExchange();
                // if the element is the first in the row, then open a new row
                if (count % columnCount == 1)
                {
                    itemsHolder.Controls.Add(new LiteralControl("<tr>"));
                    rowClosed = false;
                }

                itemsHolder.Controls.Add(new LiteralControl("<td class=\"col-lg-" + 12 / columnCount + "\">"));

                Image image = new Image();
                image.ImageUrl = item.Image_route;
                image.CssClass = "img-responsive img-fluid";

                Button addToCart = new Button();
                addToCart.Text = "Add to cart";
                addToCart.CssClass = "btn btn-primary";
                addToCart.Click += addToCartClicked;
                addToCart.ID = item.Code.ToString();

                Label lbName = new Label();
                lbName.Text = item.Name;

                Label lbPrice = new Label();
                float price = item.Price * dollarPrice;
                lbPrice.Text = "Precio: ¢" + price.ToString();

                // add elements from each item to the column-row. Order matters

                itemsHolder.Controls.Add(new LiteralControl("<div>"));
                itemsHolder.Controls.Add(image);
                itemsHolder.Controls.Add(new LiteralControl("</div>"));

                itemsHolder.Controls.Add(new LiteralControl("<div>"));
                itemsHolder.Controls.Add(lbName);
                itemsHolder.Controls.Add(new LiteralControl("</div>"));

                itemsHolder.Controls.Add(new LiteralControl("<div>"));
                itemsHolder.Controls.Add(lbPrice);
                itemsHolder.Controls.Add(new LiteralControl("</div>"));

                if (item.Discount > 0)
                {
                    lbPrice.Font.Strikeout = true;
                    lbPrice.ForeColor = System.Drawing.Color.LightGray;

                    Label lbSalePrice = new Label();
                    float convertedPrice = item.Price*(1 - item.Discount/100) * dollarPrice;
                    lbSalePrice.Text = "Oferta: ¢" + convertedPrice.ToString();
                    lbSalePrice.ForeColor = System.Drawing.Color.Red;

                    itemsHolder.Controls.Add(new LiteralControl("<div>"));
                    itemsHolder.Controls.Add(lbSalePrice);
                    itemsHolder.Controls.Add(new LiteralControl("</div>"));
                }

                itemsHolder.Controls.Add(new LiteralControl("<div>"));
                itemsHolder.Controls.Add(addToCart);
                itemsHolder.Controls.Add(new LiteralControl("</div>"));


                itemsHolder.Controls.Add(new LiteralControl("</td>"));

                // if the element is the last in the row, then close the current row
                if (count % columnCount == 0)
                {
                    itemsHolder.Controls.Add(new LiteralControl("</tr>"));
                    rowClosed = true;
                }

                count++;
            }

            if (!rowClosed)
            {
                itemsHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            itemsHolder.Controls.Add(new LiteralControl("</table>"));
        }

        public void addToCart(String id)
        {
            lblMessage.Text = "Este es el id del elemento seleccionado: " + id;
        }

        public void addToCartClicked(object sender, EventArgs e)
        {
            int itemID = int.Parse((sender as Button).ID);
            String clientName = (String) Session["name"];

            if(clientName != null)
            {
                String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
                ClientBusiness itemBusiness = new ClientBusiness(connectionString);

                String result = itemBusiness.addToCart(clientName, itemID);

                if(result == "OK")
                {
                    lblMessage.Text = "Exito al agregar el item al carrito";
                }
                else
                {
                    lblMessage.Text = result;
                }
            }
            else
            {
                lblMessage.Text = itemID.ToString();
            }
            
        }

    }
}