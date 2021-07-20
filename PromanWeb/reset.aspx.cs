using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromanWeb
{
    /// <summary>
    /// This page used to reset the application settings
    /// </summary>
    public partial class reset : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load application setting again
            AppSetting.LoadSetting();

            // Redirect to default page
            Response.Redirect("~/task-list.aspx");
        }
    }
}