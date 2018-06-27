using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

        LinkedList<TextBox> textboxes = new LinkedList<TextBox>();

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


                TextBox tbQuantity = new TextBox();
                tbQuantity.ID = item.Code.ToString();
                tbQuantity.TextMode = TextBoxMode.Number;
                tbQuantity.Text = "0";
                tbQuantity.CssClass = "form-control";

                this.textboxes.AddLast(tbQuantity);

                cartHolder.Controls.Add(new LiteralControl("<td>"));
                cartHolder.Controls.Add(tbQuantity);
                cartHolder.Controls.Add(new LiteralControl("</td>"));

                cartHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            cartHolder.Controls.Add(new LiteralControl("</table>"));

            cartHolder.Controls.Add(new LiteralControl("\n <button type=\"button\" class=\"btn btn-primary\" data-target=\"#checkModal\" data-toggle=\"modal\">"));
            cartHolder.Controls.Add(new LiteralControl("Comprar"));
            cartHolder.Controls.Add(new LiteralControl("</button>"));
        }

        public void btnCheckoutClicked(object sender, EventArgs e)
        {
            DataTable items = new DataTable();

            items.Columns.Add("cod_item");
            items.Columns.Add("quantity");

            foreach(TextBox box in textboxes)
            {
                int code = int.Parse(box.ID);
                int quantity = 0;

                try
                {
                    quantity = int.Parse(box.Text);
                }
                catch (Exception)
                {
                    messageHolder.Controls.Add(
                        new LiteralControl(Message.errorMessage("Las cantidades deben ser valores numericos")
                        ));
                    return;
                }

                if(quantity > 0)
                {
                    items.Rows.Add(code, quantity);
                }
            }

            if(items.Rows.Count == 0)
            {
                messageHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage("No hay itemes seleccionados a comprar")
                    ));
                return;
            }
            
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ClientBusiness clientBusiness = new ClientBusiness(connectionString);

            String result = clientBusiness.doPurchase(items, Session["name"].ToString(), Util.getAppDate());

            messageHolder.Controls.Clear();

            if(result == "OK")
            {
                cartHolder.Controls.Clear();
                messageHolder.Controls.Add(
                    new LiteralControl(Message.successMessage("<h2>La compra fue realizada con exito<h2>"))
                    );
            }
            else
            {
                messageHolder.Controls.Add(new LiteralControl(Message.errorMessage(result)));
            }
            
        }
    }
}