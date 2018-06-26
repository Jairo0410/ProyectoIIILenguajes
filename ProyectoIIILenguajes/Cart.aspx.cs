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
    public partial class Cart : System.Web.UI.Page
    {

        private class ItemSt
        {
            private String name;
            private float price;

            public ItemSt(String name, float price)
            {
                this.name = name;
                this.price = price;
            }

            public string Name { get => name; set => name = value; }
            public float Price { get => price; set => price = value; }

            override
            public String ToString()
            {
                return this.name + " " + this.price;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ClientBusiness clientBusiness = new ClientBusiness(connectionString);

            String clientName = (String) Session["name"];

            LinkedList<Item> cart = clientBusiness.getCart(clientName, Util.getAppDate());

            if (cart.Count == 0)
            {
                cartHolder.Controls.Add(new LiteralControl("<h2 class=\"text-center bg-warning\">"));
                cartHolder.Controls.Add(new LiteralControl("No hay articulos en el carrito"));
                cartHolder.Controls.Add(new LiteralControl("<h2>"));
                return;
            }

            cartHolder.Controls.Add(new LiteralControl("<table class=\"table table-hover text-center\">"));

            cartHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Nombre")));
            cartHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Precio")));
            cartHolder.Controls.Add(new LiteralControl(
                MyControl.TableHeader("Remover del carrito")
                ));

            foreach (Item item in cart)
            {
                cartHolder.Controls.Add(new LiteralControl("<tr>"));

                cartHolder.Controls.Add(new LiteralControl(MyControl.TableItem(item.Name)));
                cartHolder.Controls.Add(new LiteralControl(MyControl.TableItem( "¢" + item.Price.ToString() )));

                cartHolder.Controls.Add(new LiteralControl("<td>"));

                Button botonBorrar = new Button();
                botonBorrar.ID = item.Code.ToString();
                botonBorrar.Click += btnBorrarClicked;
                botonBorrar.CssClass = "btn btn-danger";
                botonBorrar.Text = "Remover";

                cartHolder.Controls.Add(botonBorrar);

                cartHolder.Controls.Add(new LiteralControl("</td>"));

                cartHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            cartHolder.Controls.Add(new LiteralControl("</table>"));

            Button btnCheckout = new Button();
            btnCheckout.Click += btnCheckoutClicked;
            btnCheckout.CssClass = "btn btn-primary pull-right";
            btnCheckout.Text = "Proceder a checkout";

            cartHolder.Controls.Add(btnCheckout);
        }

        public void btnCheckoutClicked(object sender, EventArgs e)
        {
            Server.Transfer("Checkout.aspx");
        }

        public void btnBorrarClicked(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ClientBusiness clientBusiness = new ClientBusiness(connectionString);

            String clientName = (String)Session["name"];

            int cod_item = int.Parse((sender as Button).ID);

            String result = clientBusiness.removeFromCart(clientName, cod_item);

            if(result == "OK")
            {
                Server.Transfer("Cart.aspx");
            }
            else
            {
                lblMessage.Text = result;
            }
        }
    }
}