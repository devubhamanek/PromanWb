using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace PromanWeb.account
{
    /// <summary>
    /// Signout user from system.
    /// </summary>
    public partial class signout : System.Web.UI.Page
    {
        #region PageEvents
        /// <summary>
        /// Page Load events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("ucleftmenu").Visible = false;

            //now update record in Loginlog table
            Common objCommon = new Common();
            objCommon.UpdateLoginLog();

            //dispose or clear all session
            SessionData.UserId = 0; 
            FormsAuthentication.SignOut();
        }
        #endregion
    }
}