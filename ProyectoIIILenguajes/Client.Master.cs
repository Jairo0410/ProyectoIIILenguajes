using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace ProyectoIIILenguajes
{
    public partial class Client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
            Util.setAppDate(tbDate.Text);

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Show Message",
                "alert('" + Util.getAppDate() + "');", true);
            //lblMessage.Text = Util.getAppDate();
        }
    }
}