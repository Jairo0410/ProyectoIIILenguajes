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
    public partial class AddOffer : System.Web.UI.Page

    {
        LinkedList<CheckBox> checkBoxes;

        private TextBox tbInitDate;
        private TextBox tbEndDate;

        private TextBox tbPercentage;

        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ItemBusiness itemBusiness = new ItemBusiness(connectionString);

            LinkedList<Item> items = itemBusiness.getItems(Util.getAppDate());

            if (items.Count == 0)
            {
                itemsHolder.Controls.Add(new LiteralControl(
                    Message.warningMessage("<h2> No hay articulos insertados </h2>")
                    ));
                return;
            }

            // init table and othercomponents

            this.tbPercentage = new TextBox();
            this.tbPercentage.ID = "tbPercentage";
            this.tbPercentage.CssClass = "form-control";
            this.tbPercentage.TextMode = TextBoxMode.Number;
            this.tbPercentage.Text = "0";

            itemsHolder.Controls.Add(new LiteralControl("<div class=\"col-lg-4 pull-right\">"));
            itemsHolder.Controls.Add(this.tbPercentage);
            itemsHolder.Controls.Add(new LiteralControl("</div>"));

            itemsHolder.Controls.Add(new LiteralControl("<table class=\"table table-hover text-center\">"));

            itemsHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Nombre")));
            itemsHolder.Controls.Add(new LiteralControl(MyControl.TableHeader("Precio")));
            itemsHolder.Controls.Add(new LiteralControl(
                MyControl.TableHeader("Aplicar descuento")
                ));

            this.checkBoxes = new LinkedList<CheckBox>();

            foreach (Item item in items)
            {
                itemsHolder.Controls.Add(new LiteralControl("<tr>"));

                itemsHolder.Controls.Add(new LiteralControl(MyControl.TableItem(item.Name)));

                itemsHolder.Controls.Add(new LiteralControl(MyControl.TableItem(
                    "¢" + item.Price.ToString()
                    )));

                CheckBox chbxOffer = new CheckBox();
                chbxOffer.ID = item.Code.ToString();
                chbxOffer.CssClass = "form-check-input";
                checkBoxes.AddLast(chbxOffer);

                itemsHolder.Controls.Add(new LiteralControl("<td>"));
                itemsHolder.Controls.Add(chbxOffer);
                itemsHolder.Controls.Add(new LiteralControl("</td>"));

                itemsHolder.Controls.Add(new LiteralControl("</tr>"));
            }

            itemsHolder.Controls.Add(new LiteralControl("</table>"));

            footerHolder.Controls.Add(new LiteralControl("<div class=\"col-lg-12\">"));

            this.tbInitDate = new TextBox();
            this.tbInitDate.TextMode = TextBoxMode.Date;
            this.tbInitDate.Text = Util.getRawAppDate();

            footerHolder.Controls.Add(new LiteralControl("<div class=\"col-lg-4\">"));
            footerHolder.Controls.Add(new LiteralControl("Fecha de inicio: "));
            footerHolder.Controls.Add(this.tbInitDate);
            footerHolder.Controls.Add(new LiteralControl("</div>"));

            this.tbEndDate = new TextBox();
            this.tbEndDate.TextMode = TextBoxMode.Date;
            this.tbEndDate.Text = Util.getRawAppDate();

            footerHolder.Controls.Add(new LiteralControl("<div class=\"col-lg-4\">"));
            footerHolder.Controls.Add(new LiteralControl("Fecha de fin: "));
            footerHolder.Controls.Add(this.tbEndDate);
            footerHolder.Controls.Add(new LiteralControl("</div>"));

            Button btnAddOffer = new Button();
            btnAddOffer.Text = "Aplicar descuento";
            btnAddOffer.CssClass = "btn btn-primary pull-right";
            btnAddOffer.Click += btnAddOfferClicked;

            footerHolder.Controls.Add(new LiteralControl("<div class=\"col-lg-4\">"));
            footerHolder.Controls.Add(btnAddOffer);
            footerHolder.Controls.Add(new LiteralControl("</div>"));

            footerHolder.Controls.Add(new LiteralControl("</div>"));
        }

        public void btnAddOfferClicked(object sender, EventArgs e)
        {

            DataTable selectedITems = new DataTable();
            selectedITems.Columns.Add("cod_item");

            foreach (CheckBox box in this.checkBoxes)
            {
                if (box.Checked)
                {
                    int code = int.Parse(box.ID);
                    selectedITems.Rows.Add(code);
                }
            }

            Messages.Controls.Clear();

            // if it's worth to go to the database, go
            if (selectedITems.Rows.Count > 0)
            {
                String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
                ItemBusiness itemBusiness = new ItemBusiness(connectionString);

                String initDate = Util.format(tbInitDate.Text);
                String endDate = Util.format(tbEndDate.Text);
                float percentage = float.Parse(tbPercentage.Text);

                String result = itemBusiness.addOfferItems(selectedITems, percentage, initDate, endDate);

                if(result == "OK")
                {
                    Messages.Controls.Add(
                        new LiteralControl(Message.successMessage("Exito al aplicar descuentos"))
                        );
                }
                else
                {
                    Messages.Controls.Add(
                        new LiteralControl(Message.errorMessage("El siguiente error ocurrio:\n"+result)));
                }
            }
            else
            {
                Messages.Controls.Add(
                    new LiteralControl(Message.errorMessage("No hay itemes seleccionados"))
                    );
            }
        }
    }
}