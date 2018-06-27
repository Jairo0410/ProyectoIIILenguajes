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
    public partial class ManageItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ItemBusiness itemBusiness = new ItemBusiness(connectionString);

            LinkedList<Item> items = itemBusiness.getItems(Util.getAppDate());

            if (items.Count == 0)
            {
                itemsHolder.Controls.Add(new LiteralControl("<h2 class=\"text-center bg-warning\">"));
                itemsHolder.Controls.Add(new LiteralControl("No hay articulos para administrar"));
                itemsHolder.Controls.Add(new LiteralControl("<h2>"));
                return;
            }

            Button btnAddDicount = new Button();
            btnAddDicount.PostBackUrl = "AddOffer.aspx";
            btnAddDicount.CssClass = "btn btn-primary pull-right";
            btnAddDicount.Text = "Añadir Oferta";

            itemsHolder.Controls.Add(btnAddDicount);

            itemsHolder.Controls.Add(new LiteralControl("<table class=\"table table-hover text-center\">"));

            itemsHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Nombre")));
            itemsHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Precio")));
            itemsHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Descuento")));
            itemsHolder.Controls.Add(new LiteralControl(
                MyControl.TableHeader("Eliminar articulo")
                ));

            foreach (Item item in items)
            {
                itemsHolder.Controls.Add(new LiteralControl("<tr>"));

                itemsHolder.Controls.Add(new LiteralControl(MyControl.TableItem(item.Name)));

                itemsHolder.Controls.Add(new LiteralControl(MyControl.TableItem(
                    "¢" + item.Price.ToString()
                    )));
                
                String discount;

                if(item.Discount > 0)
                {
                    discount = item.Discount.ToString();
                }
                else
                {
                    discount = "No tiene";
                }

                itemsHolder.Controls.Add(new LiteralControl(MyControl.TableItem(discount)));

                Button btnDelete = new Button();
                btnDelete.ID = item.Code.ToString();
                btnDelete.Click += btnDeleteClicked;
                btnDelete.CssClass = "btn btn-danger";
                btnDelete.Text = "Remover";

                itemsHolder.Controls.Add(new LiteralControl("<td>"));
                itemsHolder.Controls.Add(btnDelete);
                itemsHolder.Controls.Add(new LiteralControl("</td>"));

                itemsHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            itemsHolder.Controls.Add(new LiteralControl("</table>"));

        }

        public void btnDeleteClicked(object sender, EventArgs e)
        {
            int ID = int.Parse((sender as Button).ID);

            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ItemBusiness itemBusiness = new ItemBusiness(connectionString);

            String result = itemBusiness.removeItem(ID);

            if(result == "OK")
            {
                Server.Transfer("ManageItems.aspx");
            }
            else
            {
                itemsHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage(result))
                    );
            }

            
        }

    }

}