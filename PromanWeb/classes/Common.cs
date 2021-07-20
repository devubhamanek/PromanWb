using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proman.BLL;
using System.Data;
using DevExpress.Web.ASPxEditors;

namespace PromanWeb
{
    /// <summary>
    /// This class hold all the function which comonly used in the application
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Fill role in dropdownlist
        /// </summary>
        public void FillRole(DevExpress.Web.ASPxEditors.ASPxComboBox ddlRole, bool addSelect)
        {
            // Clear old values
            ddlRole.Items.Clear();

            // Get data from the database
            clsRoles objclsRole = new clsRoles();
            DataSet dsRole = new DataSet();
            if (Convert.ToInt32(SessionData.RoleId) == Convert.ToInt32(Roles.SuperAdmin))
            {
                dsRole = objclsRole.SelectAll();
            }

            if (Helper.HasRow(dsRole))
            {
                // set drop down property
                ddlRole.DataSource = dsRole.Tables[0];
                ddlRole.TextField = "RoleName";
                ddlRole.ValueField = "RoleId";
                ddlRole.DataBind();

                if (addSelect)
                {
                    // Add the select state item

                    ddlRole.Items.Insert(0, new ListEditItem("-Select-"));
                }

                if (ddlRole.Items.Count > 0)
                {
                    ddlRole.SelectedIndex = 0;
                }
            }
        }


        /// <summary>
        /// This function Fill project  dropdown list
        /// </summary>
        public void FillProject(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsProject objProject = new clsProject();

            DataSet ds = objProject.ProjectNameSelectByUserId(SessionData.UserId, Convert.ToInt64(SessionData.RoleId));

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "ProjectName";
            dropDownList.ValueField = "ProjectId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select Project", "0"));

            dropDownList.SelectedIndex = 0;
        }


        /// <summary>
        /// This function Fill project  dropdown list
        /// </summary>
        public void FillProjectByClientID(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsProject objProject = new clsProject();

            DataSet ds = objProject.ProjectSelectByUserId(SessionData.UserId, false);

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "ProjectName";
            dropDownList.ValueField = "ProjectId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select Project", "0"));

            dropDownList.SelectedIndex = 0;
        }

        /// <summary>
        /// This function Fill module  dropdown list
        /// </summary>
        public void FillModule(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, Int64 projectId, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsModule objModule = new clsModule();

            DataSet ds = objModule.SelectAllByProjectId(projectId);

            if (!Helper.HasRow(ds))
            {
                dropDownList.Items.Insert(0, new ListEditItem("Select Module", "0"));
                dropDownList.SelectedIndex = 0;
                return;
            }

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "ModuleName";
            dropDownList.ValueField = "ModuleId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select Module", "0"));

            dropDownList.SelectedIndex = 0;
        }

        /// <summary>
        /// This function Fill Component  dropdown list
        /// </summary>
        public void FillComponent(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, Int64 moduleId, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsComponent objComp = new clsComponent();

            DataSet ds = objComp.SelectAllByModuleId(moduleId);

            if (!Helper.HasRow(ds))
            {
                dropDownList.Items.Insert(0, new ListEditItem("Select Component", "0"));
                dropDownList.SelectedIndex = 0;
                return;
            }

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "ComponentName";
            dropDownList.ValueField = "ComponentId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select Component", "0"));

            dropDownList.SelectedIndex = 0;
        }

        /// <summary>
        /// This function Fill Task dropdown list(fill all the task of appropriate project) 
        /// </summary>
        public void FillTask(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, Int64 projectId, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsTask objTask = new clsTask();

            DataSet ds = objTask.SelectAllByProjectId(projectId);

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "Title";
            dropDownList.ValueField = "TaskId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select Task", "0"));

            dropDownList.SelectedIndex = 0;
        }

        /// <summary>
        /// This function Fill Projectowner  dropdown list
        /// </summary>
        public void FillProjectOwner(DevExpress.Web.ASPxEditors.ASPxComboBox ddlProjectOwner, bool addSelect)
        {
            // Clear old values
            ddlProjectOwner.Items.Clear();

            // Get data from the database
            clsUsers objUsers = new clsUsers();
            DataSet dsUsers = new DataSet();
            if (Convert.ToInt32(SessionData.RoleId) == Convert.ToInt32(Roles.SuperAdmin))
            {
                dsUsers = objUsers.SelectAllByRoleId(Convert.ToInt32(Roles.SuperAdmin), Convert.ToInt32(Roles.ProjectManager));
            }


            if (Helper.HasRow(dsUsers))
            {
                // set drop down property
                ddlProjectOwner.DataSource = dsUsers.Tables[0];
                ddlProjectOwner.TextField = "OwnerName";
                ddlProjectOwner.ValueField = "UserId";
                ddlProjectOwner.DataBind();

                if (addSelect)
                {
                    // Add the select state item

                    ddlProjectOwner.Items.Insert(0, new ListEditItem(AppSetting.ProjectOwner));
                }

                if (ddlProjectOwner.Items.Count > 0)
                {
                    ddlProjectOwner.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// This function Fill ProjectClient dropdown list
        /// </summary>
        public void FillProjectClient(DevExpress.Web.ASPxEditors.ASPxComboBox ddlProjectClient, bool addSelect)
        {
            // Clear old values
            ddlProjectClient.Items.Clear();

            // Get data from the database
            clsUsers objUsers = new clsUsers();
            DataSet dsUsers = new DataSet();
            if (Convert.ToInt32(SessionData.RoleId) == Convert.ToInt32(Roles.SuperAdmin))
            {
                dsUsers = objUsers.SelectAllByRoleId(Convert.ToInt32(Roles.Client), Convert.ToInt32(Roles.Client));
            }


            if (Helper.HasRow(dsUsers))
            {
                // set drop down property
                ddlProjectClient.DataSource = dsUsers.Tables[0];
                ddlProjectClient.TextField = "OwnerName";
                ddlProjectClient.ValueField = "UserId";
                ddlProjectClient.DataBind();

                if (addSelect)
                {
                    // Add the select state item

                    ddlProjectClient.Items.Insert(0, new ListEditItem(AppSetting.ProjectClient, 0));
                }

                if (ddlProjectClient.Items.Count > 0)
                {
                    ddlProjectClient.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// This function Fill Users dropdown list
        /// </summary>
        public void FillUser(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, bool addSelect, Int64 roleId)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsUsers objUser = new clsUsers();

            DataSet ds = objUser.SelectAll(roleId);

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "FullName";
            dropDownList.ValueField = "UserId";
            dropDownList.DataBind();

            if (addSelect)
                // Add the select state item
                dropDownList.Items.Insert(0, new ListEditItem("Select User", "0"));

            dropDownList.SelectedIndex = 0;
        }
        /// <summary>
        /// This function Fill Country dropdown list
        /// </summary>
        public void FillCountry(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsCountry objCountry = new clsCountry();
            DataSet ds = objCountry.SelectAll();

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "Name";
            dropDownList.ValueField = "CountryId";
            dropDownList.DataBind();

            if (addSelect)
            // Add the select state item
            {
                dropDownList.Items.Insert(0, new ListEditItem("Select Country", "0"));
                dropDownList.SelectedIndex = 0;
            }

        }
        /// <summary>
        /// This function Fill Designation dropdown list
        /// </summary>
        public void FillDesignation(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, bool addSelect)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsDesignation objDesignation = new clsDesignation();
            DataSet ds = objDesignation.SelectAll();

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "Name";
            dropDownList.ValueField = "DesignationId";
            dropDownList.DataBind();

        }

        /// <summary>
        /// This function Fill State dropdown list
        /// </summary>
        public void FillState(ref DevExpress.Web.ASPxEditors.ASPxComboBox dropDownList, Int64 CountryId)
        {
            // Clear old values
            dropDownList.Items.Clear();

            // Get data from the database
            clsState objState = new clsState();
            DataSet ds = objState.SelectByCountryId(CountryId);

            if (!Helper.HasRow(ds))
                return;

            // set drop down property
            dropDownList.DataSource = ds.Tables[0];
            dropDownList.TextField = "Name";
            dropDownList.ValueField = "StateId";
            dropDownList.DataBind();

        }

        /// <summary>
        /// This Function insert session Histroy and Login detail in database.
        /// </summary>
        public void InsertLoginLog()
        {
            //create an object of clsLoginLog class
            clsLoginLog objLoginLog = new clsLoginLog();

            //call insert methode of clsLoginLog . 
            //clsLoginLog methode will inseart record in database.

            objLoginLog.UserId = SessionData.UserId;
            objLoginLog.LoginDatetime = DateTime.Now;
            objLoginLog.LogOutDateTime = DateTime.MaxValue;
            objLoginLog.IPAddress = HttpContext.Current.Request.UserHostAddress;
            objLoginLog.Insert();

        }

        /// <summary>
        /// This methode Update Login Log In database
        /// </summary>
        public void UpdateLoginLog()
        {
            clsLoginLog objLoginLog = new clsLoginLog();
            objLoginLog.UserId = SessionData.UserId;
            objLoginLog.LogOutDateTime = DateTime.Now;
            objLoginLog.Update();
        }

        /// <summary>
        /// This Function Match Page name with switch case 
        /// and insert detail in Activity log table.
        /// </summary>
        /// <param name="pageName"></param>
        public void ActivityLog(string pageName)
        {

            switch (pageName)
            {
                case "signin.aspx":
                    InsertActivityLog(ActiVityLog.Sign_In.ToString());
                    break;

                case "user-management.aspx":
                    InsertActivityLog(ActiVityLog.User_Management.ToString());
                    break;

                case "signout.aspx":
                    InsertActivityLog(ActiVityLog.Sign_Out.ToString());
                    break;

                case "SessionStart":
                    InsertActivityLog(ActiVityLog.SessionStart.ToString());
                    break;
            }
        }
        /// <summary>
        /// this function insert Activity record in Activity log table.
        /// </summary>
        /// <param name="pageName"></param>
        private void InsertActivityLog(string pageName)
        {
            clsActivityLog objActivityLog = new clsActivityLog();
            objActivityLog.SessionId = HttpContext.Current.Session.SessionID;
            objActivityLog.UserId = SessionData.UserId;
            objActivityLog.Category = pageName;
            objActivityLog.Activity = "View";
            objActivityLog.PageName = pageName;
            objActivityLog.PageURL = Convert.ToString(HttpContext.Current.Request.Url);
            objActivityLog.StartDateTime = DateTime.Now;
            objActivityLog.EndDateTime = DateTime.MaxValue;
            objActivityLog.IPAddress = HttpContext.Current.Request.UserHostAddress;
            objActivityLog.Browser = Convert.ToString(HttpContext.Current.Request.Browser.Browser);
            objActivityLog.Country = null;
            objActivityLog.Status = true;
            objActivityLog.Referer = Convert.ToString(HttpContext.Current.Request.UrlReferrer);

            objActivityLog.UserAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            objActivityLog.IsBot = AppSetting.UserAgent.Contains(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);


            //Call insert methode 
            objActivityLog.Insert();


        }

        /// <summary>
        /// Get diffrence between 2 dates
        /// </summary>
        /// <param name="modifiedDate"></param>
        /// <returns>string</returns>
        public string GetDateDifference(DateTime modifiedDate)
        {

            // End date
            DateTime endDate = DateTime.Now;
            // Time span
            TimeSpan diffDate = endDate.Subtract(modifiedDate);
            // Spit it out

            if (diffDate.TotalMinutes < 60)
            {
                return Convert.ToString((int)(diffDate.TotalMinutes)) + " min";
            }

            else if (diffDate.TotalHours < 24)
            {
                return Convert.ToString((int)(diffDate.TotalHours)) + " hrs";
            }

            else if (diffDate.Days < 30)
            {
                if (diffDate.Days == 7)
                {
                    return "1 week(s)";
                }
                else if (diffDate.Days == 14)
                {
                    return "2 week(s)";
                }
                else if (diffDate.Days == 21)
                {
                    return "3 week(s)";
                }
                else if (diffDate.Days == 28)
                {
                    return "4 week(s)";
                }

                return Convert.ToString(diffDate.Days) + " days";
            }

            else if (diffDate.Days < 365)
            {
                return Convert.ToString(diffDate.Days / 30) + " month(s)";
            }

            return Convert.ToString(diffDate.Days / 365) + " year(s)";




        }


    }
}