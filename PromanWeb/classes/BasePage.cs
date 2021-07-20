using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PromanWeb
{
    /// <summary>
    /// This page serve the base page for normal pages which can be accessed from public
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //Insert Record in Activity Log table
            if (!IsPostBack)
            {
                Common objCommon = new Common();
                objCommon.ActivityLog(Convert.ToString(Path.GetFileName(Request.Path)));
            }
        }
    }
}