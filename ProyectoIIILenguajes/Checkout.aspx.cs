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
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ClientBusiness clientBusiness = new ClientBusiness(connectionString);

            String clientName = (String)Session["name"];

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
                MyControl.TableHeader("Cantidad a comprar")
                ));

            foreach (Item item in cart)
            {
                cartHolder.Controls.Add(new LiteralControl("<tr>"));

                cartHolder.Controls.Add(new LiteralControl(MyControl.TableItem(item.Name)));
                cartHolder.Controls.Add(new LiteralControl(MyControl.TableItem("¢" + item.Price.ToString())));

                cartHolder.Controls.Add(new LiteralControl("<td>"));

                TextBox tbQuantity = new TextBox();
                tbQuantity.ID = item.Code.ToString();
                tbQuantity.CssClass = "form-control";

                cartHolder.Controls.Add(tbQuantity);

                cartHolder.Controls.Add(new LiteralControl("</td>"));

                cartHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            cartHolder.Controls.Add(new LiteralControl("</table>"));

            Button btnCheckout = new Button();
            btnCheckout.CssClass = "btn btn-primary pull-right";
            btnCheckout.Text = "Comprar";

            cartHolder.Controls.Add(btnCheckout);
        }
    }
}