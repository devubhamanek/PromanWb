using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

namespace PromanWeb
{
    /// <summary>
    /// This page serve the base page for user pages
    /// </summary>
    public class UserBasePage : System.Web.UI.Page   
    {
        override protected void OnInit(EventArgs e)
        {
            //initialize our base class (System.Web,UI.Page)
            base.OnInit(e);

            if (this.DesignMode)
            {
                return;
            }

             //User is not logged in so, need to redirect to sign in
            if (SessionData.UserId == 0)
            {
                Response.Redirect("~/account/signin.aspx");
            }

            string pathString = Request.Path;
            DataSet ds = SessionData.authorizationRules;
            if (ds != null)
            {
                //Check if Activity Dataset Contains Name Of Requested Page,Then Check Is it Authorized Page?
                Boolean isAuthorized = false;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        if (pathString.Contains(dr["ActivityLink"].ToString()) && Convert.ToBoolean(dr["View"]) == true)
                        {
                            isAuthorized = true;
                        }
                    }
                    catch
                    { }
                }

                //If User Is not Authorized for this Page then Redirect him to error page.
                if (!isAuthorized)
                {
                    if (Convert.ToInt16(AppSetting.GetSetting("EnableAccessControl", AppSettingCategory.General)) == 1)
                    {
                        Response.Redirect("~/errorpages/401.aspx");
                    }
                    else
                    {
                    }

                }
            }

            //now insert record in activity Log table
            if (!IsPostBack)
            {
                Common objCommon = new Common();
                objCommon.ActivityLog(Convert.ToString(Path.GetFileName(Request.Path)));
            }

        }
    }
}