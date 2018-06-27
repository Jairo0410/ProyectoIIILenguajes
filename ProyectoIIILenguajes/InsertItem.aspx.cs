using System;
using System.Collections.Generic;
using System.Diagnostics; // getTimestamp
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Utilities;

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
                categoryHolder.Controls.Add(
                    new LiteralControl(Message.successMessage("Exito al guardar la categoria"))
                    );
            }
            else
            {
                categoryHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage(result))
                    );
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
                itemHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage("El precio debe ser un valor numerico"))
                    );
                return;
            }

            if (!ImageUpload.HasFile)
            {
                itemHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage("La imagen no fue seleccionada"))
                    );
                return;
            }

            HttpPostedFile postedFile = ImageUpload.PostedFile;
            Stream stream = postedFile.InputStream;
            BinaryReader reader = new BinaryReader(stream);

            byte[] imageBytes = reader.ReadBytes((int) stream.Length);

            String name = tbName.Text;

            String description = tbDescription.Text;
            String category = ddlCategory.SelectedValue;

            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();

            ItemBusiness business = new ItemBusiness(connectionString);

            String result = business.addItem(name, price, description, imageBytes, category);

            if (result == "OK")
            {
                itemHolder.Controls.Add(
                    new LiteralControl(Message.successMessage("Exito al insertar el articulo nuevo"))
                    );
            }
            else
            {
                itemHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage(result))
                    );
            }
        }
    }
}