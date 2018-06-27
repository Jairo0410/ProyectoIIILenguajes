using Business;
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

                itemsHolder.Controls.Add(new LiteralControl("<td class=\"col-lg-" + 12 / columnCount + " text-center\">"));

                Image image = new Image();
                image.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String(item.Image);
                image.CssClass = "img-responsive img-fluid";

                Button addToCart = new Button();
                addToCart.Text = "Añadir a carrito";
                addToCart.CssClass = "btn btn-default";
                addToCart.Click += addToCartClicked;
                addToCart.ID = item.Code.ToString();

                Button buyDirectly = new Button();
                buyDirectly.Text = "Comprar";
                buyDirectly.CssClass = "btn btn-primary";
                buyDirectly.Click += buyDirectlyClicked;
                buyDirectly.ID = item.Code.ToString();

                Button addToFav = new Button();
                addToFav.Text = "Favorito";
                addToFav.CssClass = "btn btn-info";
                addToFav.Click += addToFavClicked;
                addToFav.ID = item.Code.ToString();

                Label lbName = new Label();
                lbName.Text = item.Name;
                lbName.ForeColor = System.Drawing.Color.DeepSkyBlue;

                Label lbPrice = new Label();
                float normalPrice = item.Price * dollarPrice;
                lbPrice.Text = "Precio: ¢" + normalPrice + " ($" + item.Price + ")";
                lbPrice.CssClass = "text-center";

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
                    float offerPrice = item.Price * (1 - item.Discount / 100);
                    float convertedPrice = offerPrice * dollarPrice;
                    lbSalePrice.Text = "Oferta: ¢" + convertedPrice + " ($" + offerPrice + ")";
                    lbSalePrice.ForeColor = System.Drawing.Color.Red;
                    lbSalePrice.CssClass = "text-center";

                    itemsHolder.Controls.Add(new LiteralControl("<div>"));
                    itemsHolder.Controls.Add(lbSalePrice);
                    itemsHolder.Controls.Add(new LiteralControl("</div>"));
                }

                itemsHolder.Controls.Add(new LiteralControl("<div>"));
                itemsHolder.Controls.Add(addToCart);
                itemsHolder.Controls.Add(new LiteralControl("</div>"));

                itemsHolder.Controls.Add(new LiteralControl("<div class=\"d-inline-block\">"));


                itemsHolder.Controls.Add(addToFav);

                itemsHolder.Controls.Add(buyDirectly);


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

        public void addToFavClicked(object sender, EventArgs e)
        {
            //messageHolder.Controls.Clear();
            messageHolder.Controls.Add(
                new LiteralControl("Annadir a Favoritos: "+(sender as Button).ID)
                );
        }

        public void buyDirectlyClicked(object sender, EventArgs e)
        {
            //messageHolder.Controls.Clear();
            messageHolder.Controls.Add(
                new LiteralControl("Comprar directamente: " +(sender as Button).ID)
                );
        }

        public void addToCartClicked(object sender, EventArgs e)
        {
            //messageHolder.Controls.Clear();

            int itemID = int.Parse((sender as Button).ID);
            String clientName = (String) Session["name"];

            if(clientName != null)
            {
                String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
                ClientBusiness itemBusiness = new ClientBusiness(connectionString);

                String result = itemBusiness.addToCart(clientName, itemID);

                if(result == "OK")
                {
                    messageHolder.Controls.Add(
                        new LiteralControl(Message.successMessage("Exito al agregar el item al carrito"))
                        );
                }
                else
                {
                    messageHolder.Controls.Add(
                        new LiteralControl(Message.errorMessage(result))
                        );
                }
            }
            
        }

    }
}