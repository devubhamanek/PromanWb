using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PromanWeb.masterpages
{
    public partial class client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //now update record in Loginlog table
            Common objCommon = new Common();
            objCommon.UpdateLoginLog();

            //dispose or clear all session
            SessionData.UserId = 0;
            FormsAuthentication.SignOut();

            Response.Redirect("http://www.sofvue.com");
        }
    }
}