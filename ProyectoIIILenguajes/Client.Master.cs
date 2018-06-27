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
            if (!IsPostBack)
            {
                tbDate.Text = Util.getRawAppDate();
            }
        }

        public void btnChange_Click(object sender, EventArgs e)
        {
            bool changed = Util.setAppDate(tbDate.Text);

            if (changed)
            {
                Server.Transfer(Request.RawUrl);
            }
        }
    }
}