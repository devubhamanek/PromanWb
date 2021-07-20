using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromanWeb.controls
{
    public partial class clientHeaderControl : System.Web.UI.UserControl  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcomeName.Text = "Welcome Back, "+ SessionData.FirstName;
        }

        protected void btnNewTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("client_opentask.aspx?status=open");
        }

        protected void btnCloseTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("client_opentask.aspx?status=closed");
        }
    }
}