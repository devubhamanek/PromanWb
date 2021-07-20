using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Proman.BLL;
namespace PromanWeb.controls
{
    /// <summary>
    /// Left menu of system
    /// </summary>
    public partial class leftmenu : System.Web.UI.UserControl
    {
        #region pageevents
        /// <summary>
        /// Page Load events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            clsDTask objTask = new clsDTask();
            Int64 openTask = objTask.GetOpenTaskCount(SessionData.UserId);
            MyDesktop.InnerHtml = "<span>" + "My Desktop (" + openTask.ToString() +")</span>";

            if (!IsPostBack)
            {
                // Check Role wise Access to left menu
                CheckRoleAccess();
            }
        }
        #endregion

        #region Methode
        /// <summary>
        /// Check access to the left menu based on the role
        /// </summary>
        public void CheckRoleAccess()
        {
            if (SessionData.authorizationRules != null)
            {
                foreach (DataRow dr in SessionData.authorizationRules.Tables[0].Rows)
                {
                    string ActivityName = dr["ActivityName"].ToString();
                    bool permission = Convert.ToBoolean(dr["View"]);
                    foreach (Control item in LeftmenuControl.Controls)
                    {
                        if (item is System.Web.UI.HtmlControls.HtmlAnchor)
                        {
                            if (item.ID == ActivityName)
                            {
                                if (permission == true)
                                { item.Visible = true; }
                                else
                                { item.Visible = false; }
                            }
                        }
                    }
                }
            }

          
            //if (SessionData.RoleId == Roles.ProjectManager)
            //{
            //    UserManager.Visible = false;
            //    ProjectCreator.Visible = false;
            //    Lead.Visible = false;
            //}
            //else if (SessionData.RoleId == Roles.TaskOwner)
            //{
            //    CreateNewTask.Visible = false;
            //    UserManager.Visible = false;
            //    UserManager.Visible = false;
            //    ProjectCreator.Visible = false;
            //    ProjectQueue.Visible = false;
            //    Lead.Visible = false;
            //}
            //else if (SessionData.RoleId == Roles.Client)
            //{
            //    CreateNewTask.Visible = false;
            //    UserManager.Visible = false;
            //    Closedtasks.Visible = false;
            //    ProjectCreator.Visible = false;
            //    ProjectTaskQueue.Visible = false;
            //    MyPrivateTasks.Visible = false;
            //    Lead.Visible = false;
            //}
        }

        #endregion
    }
}