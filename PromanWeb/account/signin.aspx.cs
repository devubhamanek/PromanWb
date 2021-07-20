using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proman.BLL;
using System.Web.Security;

namespace PromanWeb.account
{
    /// <summary>
    /// User can login from this page. this page compare the login detail with database
    /// and if it is match then it allows user to tour whole website else Give it error 
    /// message
    /// </summary>
    public partial class signin : BasePage
    {
        #region Properties
        /// <summary>
        /// Get/Set QueryStringProfileID
        /// </summary>
        public String SofvueRedirectedPassword
        {
            get
            {
                if (Request.Form["txtPass"] == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(Request.Form["txtPass"]);
            }
        }

        /// <summary>
        /// Get/Set QueryStringProfileID
        /// </summary>
        public String SofvueRedirectedUName
        {
            get
            {
                if (Request.Form["txtUserName"] == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(Request.Form["txtUserName"]);
            }
        }
        #endregion
        #region Page Events
        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.UserId == 0)
            { 
            
            }
            if (!string.IsNullOrEmpty(this.SofvueRedirectedPassword) && !string.IsNullOrEmpty(this.SofvueRedirectedUName))
            {
            Response.Redirect("~/client_opentask.aspx");
            }
            //Hide the Left Menu
            this.Master.FindControl("ucleftmenu").Visible = false;
        }
        #endregion

        #region Control Events
        /// <summary>
        /// This event check entered username and password in Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // Check page is valid
                if (!Page.IsValid)
                    return;
            }

            // Perform validation
            if (!ValidatePage())
                return;

            //check in database if this User
            clsUsers objUsers = new clsUsers();
            DataSet ds = objUsers.SelectByUsernameandPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            //check dataset rows
            if (!Helper.HasRow(ds))
            {
                Helper.ShowMessage(ref lblStatus, "Invalid user name or password", MessageType.Error);
                return;
            }

            //check user is active or not
            if (!Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]))
            {
                Helper.ShowMessage(ref lblStatus, "Your account is not active", MessageType.Information);
                return;
            }

            // All goes well, Set session values
            SessionData.UserId = Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]);
            SessionData.FirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
            SessionData.LastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
            SessionData.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            SessionData.RoleId = (Roles)Enum.Parse(typeof(Roles), Convert.ToString(ds.Tables[0].Rows[0]["RoleId"]));

            //Retrive Authorization Rules For this User
            RetriveRules();

            //Now save Login record in Loginlog table.
            Common objCommon = new Common();
            objCommon.InsertLoginLog();

            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text,false);

            //check the role,if role is client then redirect them to project-queue.aspx page
            if (SessionData.RoleId == Roles.Client)
                Response.Redirect("~/project-queue.aspx");
            // Now Bye bye this page and go to task-detail page page

            if (Request.QueryString["redirect_page"] != null && Request.QueryString["project_id"] != null)
                Response.Redirect("~/" + Request.QueryString["redirect_page"] + "?projectid=" + Request.QueryString["projectid"] + "&taskid=" + Request.QueryString["taskid"]);
            else if (Request.QueryString["redirect_page"] != null && Request.QueryString["project_id"] == null)
                Response.Redirect("~/" + Request.QueryString["redirect_page"]);
            else
                Response.Redirect("~/project-queue.aspx");
        }
        #endregion

        #region Methodes
        /// <summary>
        /// This function bind the details for the page like combobox and other required controls
        /// </summary>
        private void RetriveRules()
        {
            //Retrive Authorization rules and store it in the session data.
            //clsAdminActivityRole objUserActivity = new clsAdminActivityRole();
            //DataSet dsActivity = objUserActivity.SelectByRoleID((int)SessionData.RoleId);
            UserActivityRole objUserActivity = new UserActivityRole();
            DataSet dsActivity = objUserActivity.SelectAllByUserID(SessionData.UserId);
            SessionData.authorizationRules = dsActivity;
        }
        /// <summary>
        /// Validate the page before saving into database 
        /// </summary>
        /// <returns>true if ok else send false</returns>
        private bool ValidatePage()
        {
            System.Text.StringBuilder sbValidation = new System.Text.StringBuilder();

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                sbValidation.Append("- User name cannot be left blank<br>");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                sbValidation.Append("- Password cannot be left blank<br>");
            }

            if (sbValidation.Length > 0)
            {
                Helper.ShowMessage(ref lblStatus, "Please correct following errors: <br>" + sbValidation.ToString(), MessageType.Error);
                return false;
            }
            return true;
        }

        #endregion
    }
}