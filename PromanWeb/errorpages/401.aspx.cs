using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromanWeb.errorpages
{
    public partial class _401 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helper.ShowMessage(ref lblStatus, "Sorry !!! You Are not Authorized to view this page!!", MessageType.Error);
            PromanWeb.controls.leftmenu leftmenu = new controls.leftmenu();
            leftmenu.Visible = false;
        }
    }
}