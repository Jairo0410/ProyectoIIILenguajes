using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace ProyectoIIILenguajes
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();

            bool form_errors = false;

            SessionBusiness business = new SessionBusiness(connectionString);

            String username = tbName.Text;
            String password = tbPassword.Text;
            int age = 0;
            char gender = ddlGender.SelectedValue[0];

            try
            {
                age = Int32.Parse(tbAge.Text);
            }catch (Exception)
            {
                lblMessage.Text = "El valor de la edad debe ser numerico";
                form_errors = true;
            }

            if (!form_errors)
            {
                String result = business.register(username, password, age, gender);

                if (result == "OK")
                {
                    Session.Add("type", "Client");
                    Session.Add("name", username);

                    Server.Transfer("ArticleList.aspx", true);
                }
                else
                {
                    lblMessage.Text = result;
                }
            }
            
        }
    }
}