using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;
using Proman.BLL;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

namespace PromanWeb
{
    public partial class project_queue_closed : UserBasePage
    {
        #region Property

        /// <summary>
        /// TasK ID used in the application
        /// </summary>
        public Int64 ComponentTern
        {
            get
            {
                if (this.ViewState["ComponentTern"] == null)
                    return 0;

                return Convert.ToInt64(this.ViewState["ComponentTern"]);
            }
            set { this.ViewState["ComponentTern"] = value; }
        }
        /// <summary>
        /// TasK ID used in the application
        /// </summary>
        public Int64 TaskTern
        {
            get
            {
                if (this.ViewState["TaskTern"] == null)
                    return 0;

                return Convert.ToInt64(this.ViewState["TaskTern"]);
            }
            set { this.ViewState["TaskTern"] = value; }
        }
        /// <summary>
        /// Get or set ProjectId
        /// </summary>
        public Int64 ProjectId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["ProjectId"])))
                { return 0; }

                return Convert.ToInt64(ViewState["ProjectId"]);
            }
            set
            {
                ViewState["ProjectId"] = value;
            }
        }

        /// <summary>
        /// Get or set ProjectId
        /// </summary>
        public Int32 TaskCompletionPercentage
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["TaskCompletionPercentage"])))
                { return -1; }

                return Convert.ToInt32(ViewState["TaskCompletionPercentage"]);
            }
            set
            {
                ViewState["TaskCompletionPercentage"] = value;
            }
        }


        /// <summary>
        /// Get or set Count
        /// </summary>
        public int Count
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(Session["Count"])))
                { return 0; }

                return Convert.ToInt32(Session["Count"]);
            }
            set
            {
                Session["Count"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder1
        /// </summary>
        public int SortOrder1
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder1"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder1"]);
            }
            set
            {
                ViewState["SortOrder1"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder2
        /// </summary>
        public int SortOrder2
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder2"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder2"]);
            }
            set
            {
                ViewState["SortOrder2"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder3
        /// </summary>
        public int SortOrder3
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder3"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder3"]);
            }
            set
            {
                ViewState["SortOrder3"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder4
        /// </summary>
        public int SortOrder4
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder4"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder4"]);
            }
            set
            {
                ViewState["SortOrder4"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder5
        /// </summary>
        public int SortOrder5
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder5"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder5"]);
            }
            set
            {
                ViewState["SortOrder5"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder6
        /// </summary>
        public int SortOrder6
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder6"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder6"]);
            }
            set
            {
                ViewState["SortOrder6"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder7
        /// </summary>
        public int SortOrder7
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder7"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder7"]);
            }
            set
            {
                ViewState["SortOrder7"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder8
        /// </summary>
        public int SortOrder8
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder8"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder8"]);
            }
            set
            {
                ViewState["SortOrder8"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder9
        /// </summary>
        public int SortOrder9
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder9"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder9"]);
            }
            set
            {
                ViewState["SortOrder9"] = value;
            }
        }

        /// <summary>
        /// Get or set SortOrder10
        /// </summary>
        public int SortOrder10
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["SortOrder10"])))
                { return 0; }

                return Convert.ToInt32(ViewState["SortOrder10"]);
            }
            set
            {
                ViewState["SortOrder10"] = value;
            }
        }

        #endregion

        #region Page Events
        /// <summary>
        /// Page Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {


            //Bind Page(Data Grid)
            //if roleid is client then disable view and edit button
            if (SessionData.RoleId == Roles.Client)
            {
                btnViewTasks.Visible = false;
                btnEditProject.Visible = false;
            }
            //if (SessionData.RoleId != Roles.Client)
            //{
            taskView.Visible = true;
            //legend.Visible = true;
            //colordot.Visible = true;
            //Hr1.Visible = true;
            //hr2.Visible = true;
            //}
            BindPage();
            if (IsPostBack)
            {

            }
            //  BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, 0);
        }
        #endregion

        #region Control events
        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {

            (sender as ASPxGridView).DetailRows.ExpandAllRows();
        }
        /// <summary>
        /// Component DataGridView Binding Event//Bind Component Of perticular Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void component_DataBinding(object sender, EventArgs e)
        {
            //Retrive moduleId from Module GridView 
            Int64 moduleId = Convert.ToInt64((sender as ASPxGridView).GetMasterRowKeyValue());
            //Create Object of Component Class 
            clsProject objProject = new clsProject();
            (sender as ASPxGridView).DataSource = objProject.SelectByComponentStatus(this.ProjectId, moduleId);

            //This Event Fires many we need only one time to fiure this event,,so we user below mechanisum 
            //So event only fires one time.
            if (this.ComponentTern == 0)
            {
                this.ComponentTern = 1;

                (sender as ASPxGridView).DataBind();
                (sender as ASPxGridView).DetailRows.ExpandAllRows();
            }
            else
            {


            }

        }
        /// <summary>
        /// Task DataGridView Binding Event//Bind Task Of perticular Component
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void task_DataBinding(object sender, EventArgs e)
        {

            //Retrive moduleId from Module GridView 
            Int64 componentId = Convert.ToInt64((sender as ASPxGridView).GetMasterRowKeyValue());

            //Create Object of Component Class 
            clsTask objTask = new clsTask();
            DataSet ds = objTask.SelectAllByComponentId(componentId, 0);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(dr["01"].ToString()))
                    dr["01"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["02"].ToString()))
                    dr["02"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["03"].ToString()))
                    dr["03"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["04"].ToString()))
                    dr["04"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["05"].ToString()))
                    dr["05"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["06"].ToString()))
                    dr["06"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["07"].ToString()))
                    dr["07"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["08"].ToString()))
                    dr["08"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["09"].ToString()))
                    dr["09"] = "~/images/notaskimage.jpg";
                if (string.IsNullOrEmpty(dr["10"].ToString()))
                    dr["10"] = "~/images/notaskimage.jpg";

            }
            (sender as ASPxGridView).DataSource = ds;

            //This Event Fires many we need only one time to fiure this event,,so we user below mechanisum 
            //So event only fires one time.
            if (this.TaskTern == 0)
            {

                this.TaskTern = 1;
                (sender as ASPxGridView).DataBind();
                if ((sender as ASPxGridView).VisibleRowCount == 0)
                {
                    (sender as ASPxGridView).Settings.GridLines = GridLines.None;
                    (sender as ASPxGridView).Settings.ShowColumnHeaders = false;
                }
                else
                {
                    (sender as ASPxGridView).Settings.GridLines = GridLines.Both;
                    (sender as ASPxGridView).Settings.ShowColumnHeaders = true;
                }

            }
            else
            { }
        }

        /// <summary>
        /// Redirect User to Task Detail When they click the task link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTasks_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            //Response.Redirect(e.CommandArgs.CommandArgument.ToString());
        }
        /// <summary>
        /// Row command event of gridview projects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProjects_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {

            this.ProjectId = Convert.ToInt64(e.KeyValue);
            if (e.CommandArgs.CommandName == "EditProject")
            {
                Response.Redirect("project-creator.aspx?ProjectId=" + this.ProjectId);
            }

            if (e.CommandArgs.CommandName == "DeleteProject")
            {
                //Delete Document related to Project 
                //Delete Project Image First
                clsProject objProject = new clsProject();
                
                //If there is any tasl associated with this Project then User cant delete Project
                clsTask objTask = new clsTask();
                DataSet dsTask = objTask.SelectAllByProjectId(this.ProjectId);
                if (Helper.HasRow(dsTask))
                { Helper.ShowMessage(ref lblStatus, "There are some tasks associated with this project. Please delete those task first to remove this project.", MessageType.Success); return; }

                //Delete All the Records From Database for that Project
                objProject.DeleteManual(this.ProjectId);
                Helper.ShowMessage(ref lblStatus, "Project removed successfully.", MessageType.Success);
                BindPage();
                divProjectView.Visible = false;
                return;
            }


            divProjectView.Visible = true;

            BindBubbleScreen();

            #region Comment
            ////Get Projectname and remaining day from Project


            //clsProject objProject = new clsProject(this.ProjectId);
            //spanProjectName.InnerText = "Project Name : " + objProject.ProjectName;

            //// End date
            //DateTime endDate = DateTime.Now;
            //// Time span
            //TimeSpan diffDate = objProject.DueDate.Subtract(endDate);

            //spanDayToProjectDue.InnerText = "Days to Project Due : " + Convert.ToString(diffDate.Days);

            ////Bind Module List
            //DataSet ds = objProject.SelectByModuleStatus(this.ProjectId);
            //gvModuleStatus.DataSource = ds.Tables[0];
            //gvModuleStatus.DataBind();

            //if (Helper.HasRow(ds))
            //    pbOverall.Position = Convert.ToInt32(ds.Tables[1].Rows[0][2]);
            ////If role is client then bind limited task details
            ////if (SessionData.RoleId == Roles.Client)
            ////{
            ////colordot.Visible = true;
            ////  BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, 0);
            ////}
            ////else
            ////{ colordot.Visible = false; }
            //gvModuleStatus.DetailRows.ExpandAllRows();

            ////int count= gvModuleStatus.DetailRows.VisibleCount;
            ////for (int i = 0; i < count; i++)
            ////{
            ////    ASPxGridView gv = (ASPxGridView)gvModuleStatus.FindDetailRowTemplateControl(i, "componentGrid");
            ////    gv.DetailRows.ExpandAllRows();
            ////}
            #endregion
        }

        /// <summary>
        /// this event redirect this page to edit project page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProjectEdit_Click(object sender, EventArgs e)
        {
            if (!IsCallback)
                Response.Redirect("project-creator.aspx?ProjectId=" + this.ProjectId);
            else
                ASPxWebControl.RedirectOnCallback("project-creator.aspx?ProjectId=" + this.ProjectId);

        }

        /// <summary>
        /// this event redirect this page to edit project page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewTasks_Click(object sender, EventArgs e)
        {
            if (!IsCallback)
                Response.Redirect("task-detail.aspx?projectId=" + this.ProjectId);
            else
                ASPxWebControl.RedirectOnCallback("task-detail.aspx?projectId=" + this.ProjectId);
        }

        /// <summary>
        /// this event sort the Task Complition Table 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbkBtnProjetctCompletionLink_Click(object sender, CommandEventArgs e)
        {
            ////Bind Task Complition Details
            //int PercentageComplete = Convert.ToInt16(e.CommandArgument);
            //this.TaskCompletionPercentage = PercentageComplete;
            //int CompletionNumber = this.TaskCompletionPercentage / 10;
            //switch (CompletionNumber)
            //{
            //    case 1:
            //        if (this.SortOrder1 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder1);
            //            this.SortOrder1 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder1);
            //            this.SortOrder1 = 0;
            //        }
            //        break;
            //    case 2:
            //        if (this.SortOrder2 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder2);
            //            this.SortOrder2 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder2);
            //            this.SortOrder2 = 0;
            //        }
            //        break;
            //    case 3:
            //        if (this.SortOrder3 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder3);
            //            this.SortOrder3 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder3);
            //            this.SortOrder3 = 0;
            //        }
            //        break;
            //    case 4:
            //        if (this.SortOrder4 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder4);
            //            this.SortOrder4 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder4);
            //            this.SortOrder4 = 0;
            //        }
            //        break;
            //    case 5:
            //        if (this.SortOrder5 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder5);
            //            this.SortOrder5 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder5);
            //            this.SortOrder5 = 0;
            //        }
            //        break;
            //    case 6:
            //        if (this.SortOrder6 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder6);
            //            this.SortOrder6 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder6);
            //            this.SortOrder6 = 0;
            //        }
            //        break;
            //    case 7:
            //        if (this.SortOrder7 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder7);
            //            this.SortOrder7 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder7);
            //            this.SortOrder7 = 0;
            //        }
            //        break;
            //    case 8:
            //        if (this.SortOrder8 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder8);
            //            this.SortOrder8 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder8);
            //            this.SortOrder8 = 0;
            //        }
            //        break;
            //    case 9:
            //        if (this.SortOrder9 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder9);
            //            this.SortOrder9 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder9);
            //            this.SortOrder9 = 0;
            //        }
            //        break;
            //    case 10:
            //        if (this.SortOrder10 == 0)
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder10);
            //            this.SortOrder10 = 1;
            //            lbkBtnProjetctCompletionLink_Click(sender, e);
            //        }
            //        else
            //        {
            //            BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, this.SortOrder10);
            //            this.SortOrder10 = 0;
            //        }
            //        break;
            //}
        }
        protected void gvModuleStatus_PageIndexChanged(object sender, EventArgs e)
        {
            this.ComponentTern = 0;
            BindModules();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methode

        public void BindModules()
        {
            divProjectView.Visible = true;

            //Get Projectname and remaining day from Project
            clsProject objProject = new clsProject(this.ProjectId);
            spanProjectName.InnerText = "Project Name : " + objProject.ProjectName;

            // End date
            DateTime endDate = DateTime.Now;
            // Time span
            TimeSpan diffDate = objProject.DueDate.Subtract(endDate);

            spanDayToProjectDue.InnerText = "Days to Project Due : " + Convert.ToString(diffDate.Days);

            //Bind Module List
            DataSet ds = objProject.SelectByModuleStatus(this.ProjectId);
            gvModuleStatus.DataSource = ds.Tables[0];
            gvModuleStatus.DataBind();

            //  if (Helper.HasRow(ds))
            //   pbOverall.Position = Convert.ToInt32(ds.Tables[1].Rows[0][2]);
            //If role is client then bind limited task details
            //if (SessionData.RoleId == Roles.Client)
            //{
            //colordot.Visible = true;
            //  BindClientTaskDetail(this.ProjectId, this.TaskCompletionPercentage, 0);
            //}
            //else
            //{ colordot.Visible = false; }
            gvModuleStatus.DetailRows.ExpandAllRows();
            //try
            //{
            //    int count = gvModuleStatus.DetailRows.VisibleCount;
            //    for (int i = 0; i < count; i++)
            //    {
            //        ASPxGridView gv = (ASPxGridView)gvModuleStatus.FindDetailRowTemplateControl(i, "componentGrid");
            //        gv.DetailRows.ExpandAllRows();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }
        public void GetAcssesDate(string date)
        {

        }
        /// <summary>
        /// If role is client then disable the link./Else enable it
        /// </summary>
        public bool ValidateLink()
        {
            if (SessionData.RoleId == Roles.Client)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Bind page detail
        /// </summary>
        private void BindPage()
        {
            clsProject objProjects = new clsProject();
            gvProjects.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
            gvProjects.DataSource = objProjects.ProjectSelectByUserId(SessionData.UserId, true);
            gvProjects.DataBind();

            if (SessionData.RoleId == Roles.Client)
            {
                gvProjects.Columns["Edit"].Visible = false;
            }
        }
        /// <summary>
        ///Get the date difference and according to it set the color of the task to red,green,yellow or white 
        /// </summary>
        private string getImageCodeForTask(DateTime dtTime)
        {
            //We want to trace activity of the task only during past 1-96 hrs.,and All Task that has duration more than 96 hrs. are set to white,so we 
            //only needs 4 days(96hrs) history,so If ther is major difference then set it white
            if (DateTime.Now.Year - dtTime.Year == 0)
            {
                if (DateTime.Now.Month - dtTime.Month == 0)
                {
                    DateTime startLimit = dtTime;
                    DateTime endLimit = dtTime;

                    //Set start and end time limits to check that is this task is touched during last 1-48 hr.?
                    endLimit = endLimit.AddHours(48);
                    //If task is touched during last 1-48 hr. then return Green color
                    if (startLimit <= DateTime.Now && endLimit >= DateTime.Now)
                        return "green";

                    //Reset start and end time limits
                    startLimit = dtTime;
                    endLimit = dtTime;

                    //Set start and end time limits to check that is this task is touched during last 49-72 hr.?
                    startLimit = startLimit.AddHours(72);
                    endLimit = endLimit.AddHours(49);
                    //If task is touched during last 49-72 hr. then return Yellow color
                    if (startLimit >= DateTime.Now && endLimit <= DateTime.Now)
                        return "yellow";

                    //reset start and end time limits
                    startLimit = dtTime;
                    endLimit = dtTime;

                    //Set start and end time limits to check that is this task is touched during last 93-97 hr.?
                    startLimit = startLimit.AddHours(96);
                    endLimit = endLimit.AddHours(73);

                    //If task is touched during last 93-96 hr. then return Red color
                    if (startLimit >= DateTime.Now && endLimit <= DateTime.Now)
                        return "red";
                    //If all condition doesnt setisfied then default return the white color 
                    if (dtTime < DateTime.Now)
                        return "white";
                }
                else
                    return "white";
            }
            //Set white background with dot
            else
                return "white";

            return string.Empty;
        }
        /// <summary>
        /// Bind Limited Task detail if role is client
        /// </summary>
        //private void BindClientTaskDetail(Int64 projectId, int taskCompletionPercentare, int SortOrder)
        //{
        //    if (this.ProjectId != 0)
        //    {
        //        taskView.InnerHtml = "";
        //        Table tt = (Table)taskView.FindControl("taskTable");
        //        //Retrive all the task and its details based on project id 
        //        clsTask objTask = new clsTask();
        //        DataSet dsTaskDetail = new DataSet();
        //        dsTaskDetail = objTask.SelectByProjectIdBySort(projectId, taskCompletionPercentare, SortOrder);

        //        //create dynamica html table
        //        HtmlTable tlb = new HtmlTable();
        //        tlb.Attributes.Add("class", "progress-table");
        //        tlb.Attributes.Add("id", "taskTable");
        //        tlb.Attributes.Add("runate", "server");

        //        //create header row and set its style
        //        HtmlTableRow trHeading = new HtmlTableRow();
        //        HtmlTableCell thTaskId = new HtmlTableCell();
        //        trHeading.Attributes.Add("class", "trHeading");
        //        thTaskId.InnerText = "TaskId";
        //        thTaskId.Attributes.Add("class", "tdheading");
        //        trHeading.Cells.Add(thTaskId);
        //        HtmlTableCell thDescription = new HtmlTableCell();
        //        trHeading.Attributes.Add("class", "trHeading");
        //        thDescription.InnerText = "TaskTitle";
        //        thDescription.Attributes.Add("class", "tdheading");
        //        trHeading.Cells.Add(thDescription);

        //        int Count = 0;
        //        #region Comment
        //        ////create 10 header field for the status,each field represent 10% completion of task
        //        //for (int i = 1; i <= 10; i++)
        //        //{
        //        //    HtmlTableCell tdCount = new HtmlTableCell();
        //        //    if (i != 10)
        //        //    {
        //        //        string CommandArgs = (i * 10).ToString();
        //        //        LinkButton lnk = new LinkButton();
        //        //        lnk.Attributes.Add("runat", "server");
        //        //        lnk.Command += new CommandEventHandler(lbkBtnProjetctCompletionLink_Click);
        //        //        lnk.CommandArgument = CommandArgs;
        //        //        lnk.Text = "0" + i.ToString();
        //        //        tdCount.Controls.Add(lnk);

        //        //        ImageButton img = new ImageButton();
        //        //        img.Attributes.Add("runat", "server");
        //        //        img.Command += new CommandEventHandler(lbkBtnProjetctCompletionLink_Click);
        //        //        img.CommandArgument = CommandArgs;

        //        //        if (i == 1 && this.SortOrder1 == 0 && TaskCompletionPercentage == 10)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 10 && this.SortOrder1 == 1 && i == 1)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 20 && this.SortOrder2 == 0 && i == 2)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 20 && this.SortOrder2 == 1 && i == 2)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 30 && this.SortOrder3 == 0 && i == 3)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 30 && this.SortOrder3 == 1 && i == 3)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 40 && this.SortOrder4 == 0 && i == 4)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 40 && this.SortOrder4 == 1 && i == 4)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 50 && this.SortOrder5 == 0 && i == 5)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 50 && this.SortOrder5 == 1 && i == 5)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 60 && this.SortOrder6 == 0 && i == 6)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 60 && this.SortOrder6 == 1 && i == 6)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 70 && this.SortOrder7 == 0 && i == 7)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 70 && this.SortOrder7 == 1 && i == 7)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 80 && this.SortOrder8 == 0 && i == 8)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 80 && this.SortOrder8 == 1 && i == 8)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 90 && this.SortOrder9 == 0 && i == 9)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }
        //        //        else if (taskCompletionPercentare == 90 && this.SortOrder9 == 1 && i == 9)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //            Count = 1;
        //        //        }


        //        //        tdCount.Attributes.Add("class", "tdheading");
        //        //        //tdCount.InnerText = "0" + i.ToString();
        //        //        trHeading.Cells.Add(tdCount);
        //        //    }
        //        //    else
        //        //    {
        //        //        String CommandArgs = (i * 10).ToString();
        //        //        LinkButton lnk = new LinkButton();
        //        //        lnk.Command += new CommandEventHandler(lbkBtnProjetctCompletionLink_Click);
        //        //        lnk.CommandArgument = CommandArgs;
        //        //        lnk.Attributes.Add("runat", "server");
        //        //        lnk.Text = i.ToString();

        //        //        ImageButton img = new ImageButton();
        //        //        img.Attributes.Add("runat", "server");
        //        //        img.Command += new CommandEventHandler(lbkBtnProjetctCompletionLink_Click);
        //        //        img.CommandArgument = CommandArgs;
        //        //        tdCount.Controls.Add(lnk);

        //        //        img.Style.Add("margin-top", "5px");
        //        //        if (taskCompletionPercentare == i * 10 && this.SortOrder10 == 0)
        //        //        {
        //        //            img.ImageUrl = "~/images/DownArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //        }

        //        //        else if (taskCompletionPercentare == i * 10 && this.SortOrder10 == 1)
        //        //        {
        //        //            img.ImageUrl = "~/images/UpArrow.png";
        //        //            tdCount.Controls.Add(img);
        //        //        }

        //        //        //tdCount.InnerText = i.ToString();
        //        //        tdCount.Attributes.Add("class", "tdheading");
        //        //        trHeading.Cells.Add(tdCount);
        //        //    }

        //        //    this.Count = 0;
        //        //}
        //        ////add the header row to the table
        //        //tlb.Rows.Add(trHeading);
        //        #endregion
        //        //create rows in html table from the dataset and set the appropriate value in fields
        //        foreach (DataRow dtRow in dsTaskDetail.Tables[0].Rows)
        //        {
        //            //create new row
        //            HtmlTableRow tr = new HtmlTableRow();

        //            //create cell and fill data in it from dataset and add it to the row
        //            HtmlTableCell tdTaskId = new HtmlTableCell();
        //            //Add link in TaskId so on click user can nevigate to task detail page for that task
        //            if (SessionData.RoleId != Roles.Client)
        //            {
        //                LinkButton lnkbtn = new LinkButton();
        //                lnkbtn.PostBackUrl = "~/task-detail.aspx?projectid=" + projectId.ToString() + " &taskid=" + dtRow["TaskId"].ToString();
        //                lnkbtn.Text = dtRow["TaskId"].ToString();
        //                tdTaskId.Controls.Add(lnkbtn);
        //            }
        //            else
        //            {
        //                Label lbl = new Label();
        //                lbl.Text = dtRow["TaskId"].ToString();
        //                tdTaskId.Controls.Add(lbl);
        //            }

        //            tdTaskId.Attributes.Add("class", "tdDescription");
        //            tr.Cells.Add(tdTaskId);
        //            HtmlTableCell tdDescription = new HtmlTableCell();
        //            tdDescription.InnerText = dtRow["Title"].ToString();
        //            tdDescription.Attributes.Add("class", "tdDescription");
        //            tr.Cells.Add(tdDescription);

        //            //Now from 10 colums of completion status fill appropriate collumn with appropriate image(ex.if task is 80% completed then fill 8th column with image)
        //            for (int i = 1; i <= 10; i++)
        //            {
        //                //Create cell
        //                HtmlTableCell tdPercentageComplete = new HtmlTableCell();
        //                tdPercentageComplete.Attributes.Add("class", "tdPercentageComplete");

        //                //Create html link so when user click on the link it can see the popup which contain Last Acsses date and Time of the task
        //                HtmlAnchor lnk = new HtmlAnchor();

        //                //Create Image that Represent the task activity.
        //                //If task is active during past 1-48 hours then Display green with black dot image
        //                //If task is inactive during last 49-72 hours then Display yellow black dot image
        //                //If task is inactive during last 93-96 hr. then Display red black dot image
        //                //If task is inactive more then last 96 hr then Display white black dot image
        //                //If task is 0% completed then Display only Blank White background in appropriate column without black dot
        //                Image image = new Image();
        //                image.ImageUrl = "~/images/notaskimage.jpg";
        //                if (dtRow["PercentComplete"] != DBNull.Value)
        //                {

        //                    if (Convert.ToInt64(dtRow["PercentComplete"]) == i * 10)
        //                    {
        //                        //Get the color code for the image Based on task activity(based on last accsesdate)
        //                        string colorCode = getImageCodeForTask(Convert.ToDateTime(dtRow["lastAcssesDate"]));
        //                        if (colorCode == "green")
        //                        {
        //                            //Set Green image with black dot
        //                            image.ImageUrl = "~/images/bullet_green.png";
        //                            string date = Convert.ToDateTime(dtRow["lastAcssesDAte"]).DayOfWeek.ToString() + ", " + Convert.ToDateTime(dtRow["lastAcssesDAte"]).ToShortDateString().ToString();
        //                            lnk.Attributes.Add("onmouseover", "javascript:OnMoreInfoClick(event,this,'" + date + "'," + "'green')");
        //                        }
        //                        else if (colorCode == "yellow")
        //                        {
        //                            //Set yellow image with black dot
        //                            image.ImageUrl = "~/images/bullet_yellow.png";
        //                            string date = Convert.ToDateTime(dtRow["lastAcssesDAte"]).DayOfWeek.ToString() + ", " + Convert.ToDateTime(dtRow["lastAcssesDAte"]).ToShortDateString().ToString();
        //                            lnk.Attributes.Add("onmouseover", "javascript:OnMoreInfoClick(event,this,'" + date + "'," + "'yellow')");
        //                        }
        //                        else if (colorCode == "red")
        //                        {
        //                            //Set Red image with black dot
        //                            image.ImageUrl = "~/images/bullet_red.png";
        //                            string date = Convert.ToDateTime(dtRow["lastAcssesDAte"]).DayOfWeek.ToString() + ", " + Convert.ToDateTime(dtRow["lastAcssesDAte"]).ToShortDateString().ToString();
        //                            lnk.Attributes.Add("onmouseover", "javascript:OnMoreInfoClick(event,this,'" + date + "'," + "'red')");
        //                        }
        //                        else if (colorCode == "white")
        //                        {
        //                            //Set White image with black dot
        //                            image.ImageUrl = "~/images/bullet_black.png";
        //                            string date = Convert.ToDateTime(dtRow["lastAcssesDAte"]).DayOfWeek.ToString() + ", " + Convert.ToDateTime(dtRow["lastAcssesDAte"]).ToShortDateString().ToString();
        //                            lnk.Attributes.Add("onmouseover", "javascript:OnMoreInfoClick(event,this,'" + date + "'," + "'white')");
        //                        }

        //                    }
        //                }
        //                lnk.Controls.Add(image);
        //                tdPercentageComplete.Controls.Add(lnk);
        //                tr.Cells.Add(tdPercentageComplete);
        //            }
        //            tlb.Rows.Add(tr);
        //        }
        //        taskView.Controls.Add(tlb);

        //        if (this.ProjectId == 0)
        //        {
        //            taskView.Visible = false;
        //        }
        //        else
        //        {
        //            taskView.Visible = true;
        //        }
        //    }
        //}

        /// <summary>
        /// set page status
        /// </summary>
        private void PageStatus()
        {
            if (string.IsNullOrEmpty(Request.QueryString["s"]))
            {
                return;
            }
            Helper.ShowMessage(ref lblStatus, " Project updated successfully", MessageType.Success);
        }

        /// <summary>
        /// Get project completion status table
        /// </summary>
        /// <param name="ProjectCompletionStatus"></param>
        /// <returns></returns>

        protected string GetProjectCompletionStatus(double projectCompletionStatus)
        {
            // Build the table
            HtmlTable table = new HtmlTable();
            table.CellPadding = 0;
            table.CellSpacing = 0;
            HtmlTableRow tr = new HtmlTableRow();


            for (int i = 10; i <= 100; i += 10)
            {
                HtmlTableCell td = new HtmlTableCell();
                HtmlImage image = new HtmlImage();

                if (projectCompletionStatus >= i)
                    image.Src = AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) + "/images/barfull.jpg";
                else
                    image.Src = AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) + "/images/barempty.jpg";
                if (projectCompletionStatus == 100)
                { image.Src = AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) + "/images/bargreen.jpg"; }
                td.Controls.Add(image);

                tr.Cells.Add(td);
            }

            table.Rows.Add(tr);

            // Render the HTML table as html
            StringWriter writer = new StringWriter();
            Html32TextWriter htmlWriter = new Html32TextWriter(writer);
            table.RenderControl(htmlWriter);
            return writer.ToString();
        }

        #endregion

        #region Create BubbleScreen
        /// <summary>
        /// This Function Bind the Bubble Screen.Retrive all the Data about Modules,Component,Project and task
        /// And parse this table and dynamically create html table and add it to the page.
        /// </summary>
        public void BindBubbleScreen()
        {
            clsTask objTask = new clsTask();
            DataSet ds = objTask.SelectAllByComponentId(this.ProjectId, 0);
            DataTable dtModule = ds.Tables[2];
            DataTable dtComponent = ds.Tables[3];

            //Get Projectname and remaining day from Project
            clsProject objProject = new clsProject(this.ProjectId);
            spanProjectName.InnerText = "Project Name : " + objProject.ProjectName;

            pbOverall.Value = ds.Tables[1].Rows[0][0];

            // End date
            DateTime endDate = DateTime.Now;
            // Time span
            TimeSpan diffDate = objProject.DueDate.Subtract(endDate);

            spanDayToProjectDue.InnerText = "Days to Project Due : " + Convert.ToString(diffDate.Days);


            //Create Module Table
            HtmlTable moduleTable = new HtmlTable();
            moduleTable.Attributes.Add("class", "module-table");
            moduleTable.Attributes.Add("id", "moduleTable");
            moduleTable.Attributes.Add("runate", "server");
            moduleTable.Attributes.Add("cellspacing", "0");
            moduleTable.Attributes.Add("cellpadding", "0");
            Int64 Module = 1;

            //Main foreach loop for select each of module.
            foreach (DataRow dr in dtModule.Rows)
            {

                Int64 moduleID = Convert.ToInt64(dr["ModuleId"]);
                Int64 moduleCompletion = Convert.ToInt64(dr["ModuleCompletion"]);
                string moduleName = dr["ModuleName"].ToString();

                //Create Row for Module Table
                HtmlTableRow moduleRow = new HtmlTableRow();
                moduleRow.Attributes.Add("class", "module-table-tr");
                //Create First Cell(MODULE NAME) and add it to moduleRow
                HtmlTableCell modulecell0 = new HtmlTableCell();
                HtmlImage img = new HtmlImage();
                img.Src = "images/downdetailarrow.png";
                img.Width = 10;
                img.Height = 8;
                modulecell0.Controls.Add(img);
                modulecell0.Attributes.Add("class", "module-table-firstimagetd");
                moduleRow.Cells.Add(modulecell0);


                HtmlTableCell modulecell1 = new HtmlTableCell();
                modulecell1.InnerText = "Module " + Module.ToString() + " : " + moduleName;
                modulecell1.Attributes.Add("class", "module-table-lefttd");
                moduleRow.Cells.Add(modulecell1);

                //Create Second Cell(ASPX PROGRESS BAR)and add it to moduleRow
                HtmlTableCell modulecell2 = new HtmlTableCell();
                ASPxProgressBar modulePb = new ASPxProgressBar();
                modulePb.Width = 200;
                modulecell2.Attributes.Add("class", "module-table-righttd");
                modulePb.Value = moduleCompletion;

                modulecell2.Controls.Add(modulePb);
                moduleRow.Cells.Add(modulecell2);

                //Add row to the moduletable
                moduleTable.Rows.Add(moduleRow);



                Int64 Component = 1;

                //Second foreach loop For the Component.
                //Select Component as per ModuleID
                foreach (DataRow drcomponent in dtComponent.Rows)
                {

                    Int64 componentID = Convert.ToInt64(drcomponent["componentid"]);
                    Int64 componentModuleID = Convert.ToInt64(drcomponent["ModuleID"]);
                    string componentName = drcomponent["ComponentName"].ToString();
                    Int64 componentComplition = Convert.ToInt64(drcomponent["ComponentCompletion"]);


                    //Check whethere this component belongs to this module or not.
                    if (componentModuleID == moduleID)
                    {
                        //Create Row for Module Table
                        HtmlTableRow moduleRow2 = new HtmlTableRow();
                        HtmlTableCell modulecell3 = new HtmlTableCell();
                        modulecell3.InnerText = "";
                        /*change colspan 3 rather than 2*/
                        modulecell3.ColSpan = 3;
                        modulecell3.Attributes.Add("class", "componentprogressbartd1");
                        moduleRow2.Cells.Add(modulecell3);

                        //HtmlTableCell modulecell4 = new HtmlTableCell();
                        //modulecell4.Attributes.Add("class", "componentprogressbartd1"); 
                        //Create Module Table
                        HtmlTable componentTable = new HtmlTable();
                        componentTable.Attributes.Add("class", "component-table");
                        componentTable.Attributes.Add("cellspacing", "0");
                        componentTable.Attributes.Add("cellpadding", "0");
                        componentTable.Attributes.Add("runate", "server");

                        #region CreateComponentTable
                        //Create Row for Module Table
                        HtmlTableRow componentRow = new HtmlTableRow();

                        //Create First Cell(MODULE NAME) and add it to moduleRow
                        HtmlTableCell componentcell00 = new HtmlTableCell();
                        HtmlImage img1 = new HtmlImage();
                        img1.Src = "images/downdetailarrow.png";
                        img1.Width = 10;
                        img1.Height = 8;
                        componentcell00.Controls.Add(img1);
                        componentcell00.Attributes.Add("class", "component-table-lefttd");
                        componentRow.Cells.Add(componentcell00);


                        //Create First Cell(MODULE NAME) and add it to moduleRow
                        HtmlTableCell componentcell1 = new HtmlTableCell();
                        componentcell1.InnerText = "Component " + Component.ToString() + " : " + componentName;
                        componentcell1.Attributes.Add("class", "component-table-lefttd1");
                        componentRow.Cells.Add(componentcell1);

                        //Create Second Cell(ASPX PROGRESS BAR)and add it to moduleRow
                        HtmlTableCell componentcell2 = new HtmlTableCell();
                        ASPxProgressBar componentPb = new ASPxProgressBar();
                        componentPb.Width = 150;
                        componentPb.Value = componentComplition;
                        componentcell2.Controls.Add(componentPb);
                        componentcell2.Attributes.Add("class", "component-table-righttd");
                        componentRow.Cells.Add(componentcell2);

                        //Add row to the moduletable
                        componentTable.Rows.Add(componentRow);
                        modulecell3.Controls.Add(componentTable);

                        moduleRow2.Cells.Add(modulecell3);
                        moduleTable.Rows.Add(moduleRow2);
                        //taskView.Controls.Add(componentTable);
                        #endregion

                        HtmlTable taskTable = new HtmlTable();
                        taskTable.Attributes.Add("class", "task-table");
                        taskTable.Attributes.Add("id", "taskTable");
                        taskTable.CellPadding = 0;
                        taskTable.CellSpacing = 0;
                        taskTable.Border = 1;
                        taskTable.BorderColor = "#CFDDEE";

                        #region HeaderRow
                        //Create New  Row
                        HtmlTableRow trTaskHeader = new HtmlTableRow();

                        //Cell1
                        HtmlTableCell thcell1 = new HtmlTableCell();
                        thcell1.InnerText = "Task ID";
                        thcell1.Attributes.Add("class", "thhead");
                        thcell1.Width = "40";
                        thcell1.BorderColor = "gray";
                        trTaskHeader.Cells.Add(thcell1);

                        //Cell2
                        HtmlTableCell thcell2 = new HtmlTableCell();
                        thcell2.InnerText = "Task Title";
                        thcell2.Attributes.Add("class", "thhead");
                        thcell2.Width = "250";
                        trTaskHeader.Cells.Add(thcell2);

                        //Cell3
                        HtmlTableCell thcell3 = new HtmlTableCell();
                        thcell3.InnerText = "01";
                        thcell3.Attributes.Add("class", "thhead");
                        thcell3.Width = "20";
                        trTaskHeader.Cells.Add(thcell3);

                        //Cell4
                        HtmlTableCell thcell4 = new HtmlTableCell();
                        thcell4.InnerText = "02";
                        thcell4.Attributes.Add("class", "thhead");
                        thcell4.Width = "20";
                        trTaskHeader.Cells.Add(thcell4);

                        //Cell5
                        HtmlTableCell thcell5 = new HtmlTableCell();
                        thcell5.InnerText = "03";
                        thcell5.Attributes.Add("class", "thhead");
                        thcell5.Width = "20";
                        trTaskHeader.Cells.Add(thcell5);

                        //Cell6
                        HtmlTableCell thcell6 = new HtmlTableCell();
                        thcell6.InnerText = "04";
                        thcell6.Attributes.Add("class", "thhead");
                        thcell6.Width = "20";
                        trTaskHeader.Cells.Add(thcell6);

                        //Cell7
                        HtmlTableCell thcell7 = new HtmlTableCell();
                        thcell7.InnerText = "05";
                        thcell7.Attributes.Add("class", "thhead");
                        thcell7.Width = "20";
                        trTaskHeader.Cells.Add(thcell7);

                        //Cell8
                        HtmlTableCell thcell8 = new HtmlTableCell();
                        thcell8.InnerText = "06";
                        thcell8.Attributes.Add("class", "thhead");
                        thcell8.Width = "20";
                        trTaskHeader.Cells.Add(thcell8);

                        //Cell9
                        HtmlTableCell thcell9 = new HtmlTableCell();
                        thcell9.InnerText = "07";
                        thcell9.Attributes.Add("class", "thhead");
                        thcell9.Width = "20";
                        trTaskHeader.Cells.Add(thcell9);


                        //Cell11
                        HtmlTableCell thcell11 = new HtmlTableCell();
                        thcell11.InnerText = "Delete";
                        thcell11.Attributes.Add("class", "thhead");
                        thcell11.Width = "40";
                        trTaskHeader.Cells.Add(thcell11);
                        ////Cell10
                        //HtmlTableCell thcell10 = new HtmlTableCell();
                        //thcell10.InnerText = "08";
                        //thcell10.Attributes.Add("class", "thhead");
                        //thcell10.Width = "20";
                        //trTaskHeader.Cells.Add(thcell10);

                        ////Cell11
                        //HtmlTableCell thcell11 = new HtmlTableCell();
                        //thcell11.InnerText = "09";
                        //thcell11.Attributes.Add("class", "thhead");
                        //thcell11.Width = "20";
                        //trTaskHeader.Cells.Add(thcell11);

                        ////Cell12
                        //HtmlTableCell thcell12 = new HtmlTableCell();
                        //thcell12.InnerText = "10";
                        //thcell12.Attributes.Add("class", "thhead");
                        //thcell12.Width = "20";
                        //trTaskHeader.Cells.Add(thcell12);

                        taskTable.Rows.Add(trTaskHeader);
                        #endregion

                        taskTable.Attributes.Add("runate", "server");
                        #region TASKGRID
                        HtmlTableRow componentRow3 = new HtmlTableRow();
                        HtmlTableCell componentcell5 = new HtmlTableCell();
                        componentcell5.Attributes.Add("class", "componentbackground");
                        componentcell5.ColSpan = 3;
                        #region NoRecordFound
                        HtmlTableRow trTaskNodata = new HtmlTableRow();

                        //Create New Cell,Cell1

                        bool isRecord = false;
                        #endregion
                        foreach (DataRow drTask in ds.Tables[0].Rows)
                        {


                            if (!String.IsNullOrEmpty(drTask["TaskId"].ToString()))
                            {
                                Int64 taskcomponentID = Convert.ToInt64(drTask["ComponentId"]);
                                if (taskcomponentID == componentID)
                                {
                                    isRecord = true;

                                    #region Parameter

                                    Int64 taskID = Convert.ToInt64(drTask["TaskId"]);
                                    Int64 percentageComplete = 0;
                                    if (!String.IsNullOrEmpty(drTask["PercentComplete"].ToString()))
                                        percentageComplete = Convert.ToInt64(drTask["PercentComplete"]);
                                    string p1, p2, p3, p4, p5, p6, p7, lastAccessDate, taskLink1, taskTitle;
                                    p1 = p2 = p3 = p4 = p5 = p6 = p7 = lastAccessDate = taskLink1 = taskTitle = string.Empty;

                                    if (!String.IsNullOrEmpty(drTask["Title"].ToString()))
                                        taskTitle = drTask["Title"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["Link"].ToString()))
                                        taskLink1 = drTask["Link"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["LastAcssesDate"].ToString()))
                                        lastAccessDate = drTask["LastAcssesDate"].ToString();

                                    if (!String.IsNullOrEmpty(drTask["01"].ToString()))
                                        p1 = drTask["01"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["02"].ToString()))
                                        p2 = drTask["02"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["03"].ToString()))
                                        p3 = drTask["03"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["04"].ToString()))
                                        p4 = drTask["04"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["05"].ToString()))
                                        p5 = drTask["05"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["06"].ToString()))
                                        p6 = drTask["06"].ToString();
                                    if (!String.IsNullOrEmpty(drTask["07"].ToString()))
                                        p7 = drTask["07"].ToString();
                                    //if (!String.IsNullOrEmpty(drTask["08"].ToString()))
                                    //    p8 = drTask["08"].ToString();
                                    //if (!String.IsNullOrEmpty(drTask["09"].ToString()))
                                    //    p9 = drTask["09"].ToString();
                                    //if (!String.IsNullOrEmpty(drTask["10"].ToString()))
                                    //    p10 = drTask["10"].ToString();

                                    #endregion

                                    #region TaskTable
                                    //Create Task Table


                                    //Create New Row
                                    HtmlTableRow trTask = new HtmlTableRow();

                                    //Create New Cell,Cell1
                                    HtmlTableCell trCell1 = new HtmlTableCell();
                                    HtmlAnchor tasklink = new HtmlAnchor();
                                    tasklink.InnerText = taskID.ToString();
                                    tasklink.HRef = taskLink1.ToString();
                                    switch (percentageComplete)
                                    {
                                        case 14:
                                            tasklink.Attributes.Add("style", "color:black;");
                                            break;
                                        case 28:
                                            tasklink.Attributes.Add("style", "color:DarkGoldenRod;");
                                            break;
                                        case 42:
                                            tasklink.Attributes.Add("style", "color:blue;");
                                            break;
                                        case 56:
                                            tasklink.Attributes.Add("style", "color:purple;");
                                            break;
                                        case 70:
                                            tasklink.Attributes.Add("style", "color:red;");
                                            break;
                                        case 84:
                                            tasklink.Attributes.Add("style", "color:brown;");
                                            break;
                                        case 100:
                                            tasklink.Attributes.Add("style", "color:green;");
                                            break;
                                        default:
                                            tasklink.Attributes.Add("style", "color:black;");
                                            break;
                                    }


                                    if (SessionData.RoleId == Roles.Client)
                                    {
                                        tasklink.HRef = "";
                                    }
                                    trCell1.Width = "40";
                                    trCell1.Controls.Add(tasklink);
                                    trTask.Cells.Add(trCell1);

                                    //Cell2
                                    HtmlTableCell trCell2 = new HtmlTableCell();
                                    trCell2.InnerText = taskTitle.ToString();
                                    trCell2.Width = "250";
                                    switch (percentageComplete)
                                    {
                                        case 14:
                                            trCell2.Attributes.Add("style", "color:black;");
                                            break;
                                        case 28:
                                            trCell2.Attributes.Add("style", "color:DarkGoldenRod;");
                                            break;
                                        case 42:
                                            trCell2.Attributes.Add("style", "color:blue;");
                                            break;
                                        case 56:
                                            trCell2.Attributes.Add("style", "color:purple;");
                                            break;
                                        case 70:
                                            trCell2.Attributes.Add("style", "color:red;");
                                            break;
                                        case 84:
                                            trCell2.Attributes.Add("style", "color:brown;");
                                            break;
                                        case 100:
                                            trCell2.Attributes.Add("style", "color:green;");
                                            break;
                                        default:
                                            trCell2.Attributes.Add("style", "color:black;");
                                            break;
                                    }

                                    trTask.Cells.Add(trCell2);

                                    //Cell01
                                    HtmlTableCell trCell01 = new HtmlTableCell();
                                    Image img01 = new Image();
                                    if (percentageComplete == 14)
                                    {
                                        img01.ImageUrl = p1.ToString();
                                        img01.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img01.ImageUrl = "images/noimage.png";
                                    trCell01.Controls.Add(img01);
                                    trCell01.Width = "20";
                                    trTask.Cells.Add(trCell01);


                                    //Cell02
                                    HtmlTableCell trCell02 = new HtmlTableCell();
                                    Image img02 = new Image();
                                    if (percentageComplete == 28)
                                    {
                                        img02.ImageUrl = p2.ToString();
                                        img02.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img02.ImageUrl = "images/noimage.png";
                                    trCell02.Controls.Add(img02);
                                    trCell02.Width = "20";
                                    trTask.Cells.Add(trCell02);

                                    //Cell03
                                    HtmlTableCell trCell03 = new HtmlTableCell();
                                    Image img03 = new Image();
                                    if (percentageComplete == 42)
                                    {
                                        img03.ImageUrl = p3.ToString();
                                        img03.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img03.ImageUrl = "images/noimage.png";
                                    trCell03.Controls.Add(img03);
                                    trCell03.Width = "20";
                                    trTask.Cells.Add(trCell03);


                                    //Cell04
                                    HtmlTableCell trCell04 = new HtmlTableCell();
                                    Image img04 = new Image();
                                    if (percentageComplete == 56)
                                    {
                                        img04.ImageUrl = p4.ToString();
                                        img04.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img04.ImageUrl = "images/noimage.png";
                                    trCell04.Width = "20";
                                    trCell04.Controls.Add(img04);
                                    trTask.Cells.Add(trCell04);


                                    //Cell05
                                    HtmlTableCell trCell05 = new HtmlTableCell();
                                    Image img05 = new Image();
                                    if (percentageComplete == 70)
                                    {
                                        img05.ImageUrl = p5.ToString();
                                        img05.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img05.ImageUrl = "images/noimage.png";
                                    trCell05.Controls.Add(img05);
                                    trCell05.Width = "20";
                                    trTask.Cells.Add(trCell05);


                                    //Cell06
                                    HtmlTableCell trCell06 = new HtmlTableCell();
                                    Image img06 = new Image();
                                    if (percentageComplete == 84)
                                    {
                                        img06.ImageUrl = p6.ToString();
                                        img06.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img06.ImageUrl = "images/noimage.png";
                                    trCell06.Controls.Add(img06);
                                    trCell06.Width = "20";
                                    trTask.Cells.Add(trCell06);


                                    //Cell07
                                    HtmlTableCell trCell07 = new HtmlTableCell();
                                    Image img07 = new Image();
                                    if (percentageComplete == 100)
                                    {
                                        img07.ImageUrl = p7.ToString();
                                        img07.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    }
                                    else
                                        img07.ImageUrl = "images/noimage.png";
                                    trCell07.Controls.Add(img07);
                                    trCell07.Width = "20";
                                    trTask.Cells.Add(trCell07);

                                    //Cell For Delete Button
                                    HtmlTableCell trCell11 = new HtmlTableCell();
                                    Image img11 = new Image();
                                    img11.ImageUrl = "images/closeMark1.png";
                                    //img10.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    img11.Attributes.Add("alt", "delete");
                                    img11.Attributes.Add("class", "delete");
                                    trCell11.Controls.Add(img11);
                                    trTask.Cells.Add(trCell11);
                                    ////Cell08
                                    //HtmlTableCell trCell08 = new HtmlTableCell();
                                    //Image img08 = new Image();
                                    //if (percentageComplete == 84)
                                    //{
                                    //    img08.ImageUrl = p8.ToString();
                                    //    img08.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    //}
                                    //else
                                    //    img08.ImageUrl = "images/noimage.png";
                                    //trCell08.Controls.Add(img08);
                                    //trCell08.Width = "20";
                                    //trTask.Cells.Add(trCell08);


                                    ////Cell09
                                    //HtmlTableCell trCell09 = new HtmlTableCell();
                                    //Image img09 = new Image();
                                    //if (percentageComplete == 90)
                                    //{
                                    //    img09.ImageUrl = p9.ToString();
                                    //    img09.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    //}
                                    //else
                                    //    img09.ImageUrl = "images/noimage.png";
                                    //trCell09.Controls.Add(img09);
                                    //trCell09.Width = "20";
                                    //trTask.Cells.Add(trCell09);


                                    ////Cell010
                                    //HtmlTableCell trCell010 = new HtmlTableCell();
                                    //Image img010 = new Image();

                                    //if (percentageComplete == 100)
                                    //{
                                    //    img010.ImageUrl = p10.ToString();
                                    //    img010.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    //}
                                    //else
                                    //    img010.ImageUrl = "images/noimage.png";
                                    //trCell010.Controls.Add(img010);
                                    //trCell010.Width = "20";

                                    //trTask.Cells.Add(trCell010);

                                    taskTable.Rows.Add(trTask);
                                    #endregion

                                    //Add row and cell to the module table.

                                }
                            }
                        }
                        if (!isRecord)
                        {
                            //If there is no task in component then Show the message in grid that "No Record Found"
                            HtmlTableCell trCellNodata = new HtmlTableCell();
                            trCellNodata.ColSpan = 12;
                            trCellNodata.InnerText = "No Record Found";
                            trCellNodata.Attributes.Add("class", "nodatafound");
                            trCellNodata.Height = "30";
                            trTaskNodata.Cells.Add(trCellNodata);
                            taskTable.Rows.Add(trTaskNodata);

                        }
                        componentcell5.Controls.Add(taskTable);
                        componentRow3.Cells.Add(componentcell5);
                        componentTable.Rows.Add(componentRow3);
                        #endregion
                        Component++;
                    }


                }
                Component = 1;
                Module++;

            }

            taskView.Controls.Add(moduleTable);
        }

        public void GetBubbleColorImage()
        {

        }
        #endregion
    }
}