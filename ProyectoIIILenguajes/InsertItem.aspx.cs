using System;
using System.Collections.Generic;
using System.Diagnostics; // getTimestamp
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace ProyectoIIILenguajes
{
    public partial class InsertItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            ItemBusiness business = new ItemBusiness(connectionString);

            LinkedList<String> categories = business.getCategories();

            /* We proceed to clean up the current categories in the dropdown
             * menu and then insert the ones that come from database
             */
            ddlCategory.Items.Clear();

            foreach (String category in categories)
            {
                ddlCategory.Items.Add(new ListItem(category));
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            String categoryName = tbCategoryName.Text;

            ItemBusiness business = new ItemBusiness(connectionString);

            String result = business.addCategory(categoryName);

            if(result == "OK")
            {
                ddlCategory.Items.Add(new ListItem(categoryName));
            }
            else
            {
                lblMessageCategoria.Text = result;
            }

            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            float price;
            try
            {
                price = float.Parse(tbPrice.Text);
            } catch (Exception)
            {
                lblMessageAdd.Text = "El precio debe ser un valor numerico";
                return;
            }

            String imageRoute;

            if (ImageUpload.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ImageUpload.FileName);
                imageRoute = "~/img/" + DateTime.Now.Ticks + fileExtension;

                String rootedRoute = Server.MapPath(imageRoute);

                //ImageUpload.SaveAs(imageRoute);
                lblMessageAdd.Text = "La ruta a guardar es: " + rootedRoute;

                return;
            }
            else
            {
                lblMessageAdd.Text = "La imagen no fue seleccionada";
                return;
            }

            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();
            String name = tbName.Text;

            String description = tbDescription.Text;
            String category = ddlCategory.SelectedValue;

            
            
            ItemBusiness business = new ItemBusiness(connectionString);

            String result = business.addItem(name, price, description, imageRoute, category);

            if (result == "OK")
            {
                lblMessageAdd.Text = "Articulo insertado con exito";
            }
            else
            {
                lblMessageAdd.Text = result;
            }
        }
    }
}