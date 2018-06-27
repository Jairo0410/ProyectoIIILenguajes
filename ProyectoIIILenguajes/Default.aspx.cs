using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Utilities;

namespace ProyectoIIILenguajes
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["type"] != null)
            {
                String type = (String) Session["type"];
                if (type == "Client")
                {
                    Server.Transfer("ArticleList.aspx", true);
                }
                else if (type == "Admin")
                {
                    Server.Transfer("PurchaseHistory.aspx", true);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            messageHolder.Controls.Clear();

            String connectionString = WebConfigurationManager.ConnectionStrings["DBLENGUAJES"].ToString();

            SessionBusiness business = new SessionBusiness(connectionString);

            String username = tbUsername.Text;
            String password = tbPassword.Text;

            String type = business.login(username, password);

            Session["type"] = type;

            if (type == "Client")
            {
                Session.Add("name", username);
                Server.Transfer("ArticleList.aspx", true);
            }
            else if (type == "Admin")
            {
                Session.Add("name", "privileged");
                Server.Transfer("PurchaseHistory.aspx", true);
            }
            else
            {
                messageHolder.Controls.Add(
                    new LiteralControl(Message.errorMessage("Credenciales incorrectas"))
                    );
            }

        }
    }
}