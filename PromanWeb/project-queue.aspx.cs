using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;
using System.Diagnostics;
using System.Text;
using DevExpress.Web.ASPxPanel;
using System.Web.Services;
using System.Xml;


namespace PromanWeb
{
    /// <summary>
    /// This page show all projects and it's status
    /// </summary>
    public partial class project_queue : UserBasePage
    {
        public Int64 UserID;
        public Int64 ProjectID;
        public string FirstName;
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
        public Int64 TaskId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["TaskId"])))
                { return 0; }

                return Convert.ToInt64(ViewState["TaskId"]);
            }
            set
            {
                ViewState["TaskId"] = value;
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
            UserID = SessionData.UserId;
            FirstName = SessionData.FirstName;
            //Bind Page(Data Grid)
            //if roleid is client then disable view and edit button
            if (SessionData.RoleId == Roles.Client)
            {
                btnViewTasks.Visible = false;
                btnEditProject.Visible = false;
            }

            taskView.Visible = true;

            BindPage();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["projectid"]))
                {
                    this.ProjectId = Convert.ToInt64(Request.QueryString["projectid"]);
                    divProjectView.Visible = true;
                    BindBubbleScreen(0);
                    //ImageButton imageButton = gvProjects.FindRowCellTemplateControl(e.VisibleIndex, null, "lnkView") as ImageButton;

                    // CommandEventArgs commandArgs = new CommandEventArgs("EditProject", imageButton.CommandArgument);
                    //  DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs en = new ASPxGridViewRowCommandEventArgs(e.VisibleIndex, e.KeyValue, commandArgs, null);
                    // gvProjects_RowCommand(gvProjects, en);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["taskid"]))
                {
                    this.TaskId = Convert.ToInt64(Request.QueryString["taskid"]);
                }
            }
        }
        #endregion


        protected void gvProjects_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data)
                return;

            if (this.ProjectId != 0)
            {

                //if (e.VisibleIndex > 10)
                //{
                //    int i = grdSuppliesList.VisibleRowCount;
                //    grdSuppliesList.PageIndex = e.VisibleIndex % 10;
                //}
                // Order objOrder = new Order(this.SupplyID);
                // DateTime CommandnameValue = objOrder.Createddate;
                if (Convert.ToInt64(e.KeyValue) == this.ProjectId)
                {
                    //object obj = grdSuppliesList.FindRowCellTemplateControl(e.VisibleIndex, gvimagecol, "imgSelectUnselect") as object;
                    LinkButton lnkButton = gvProjects.FindRowCellTemplateControl(e.VisibleIndex, null, "lnkView") as LinkButton;

                    if (lnkButton != null)
                    {
                        // imageButton.ImageUrl = "../images/icons/radio_selected.png";
                        // grdSuppliesList.RowCommand += new ASPxGridViewRowCommandEventHandler(grdSuppliesList_RowCommand,new DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e);
                        CommandEventArgs commandArgs = new CommandEventArgs("SendSupply", lnkButton.CommandArgument);
                        DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs en = new ASPxGridViewRowCommandEventArgs(e.VisibleIndex, e.KeyValue, commandArgs, null);
                        gvProjects_RowCommand(gvProjects, en);

                    }
                }
            }
        }










        #region Control events

        /// <summary>
        /// Row command event of gridview projects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
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

            ProjectID = Convert.ToInt64(e.KeyValue);
            divProjectView.Visible = true;

            //Bind Bubble Screen 
            BindBubbleScreen(0);
        }

        /// <summary>
        /// Legend Image Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnklegendimage_Click(object sender, CommandEventArgs e)
        {
            //Bind Bubble Grid According to Image Clicked
            BindBubbleScreen(Convert.ToInt32(e.CommandArgument));
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

        #endregion

        #region Methode

        /// <summary>
        /// Bind page detail
        /// </summary>
        private void BindPage()
        {
            clsProject objProjects = new clsProject();
            gvProjects.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
            DataSet ds = objProjects.ProjectSelectByUserId(SessionData.UserId, false);
            if (Helper.HasRow(ds))
            {
                lblOpenTaskCount.Text = ds.Tables[0].AsEnumerable().Sum(x => x.Field<int>("OpenTask")).ToString();//Sum with Linq for Open Task
                lblModuleCount.Text = ds.Tables[0].AsEnumerable().Sum(x => x.Field<int>("Modules")).ToString();//Sum with Linq for Moduls
                lblprojectStatus.Text = Convert.ToString(Math.Round(ds.Tables[0].AsEnumerable().Sum(x => x.Field<double>("ProjectCompletionStatus")) / ds.Tables[0].Rows.Count, 2));
                lblActiveProjectCount.Text = Convert.ToString(ds.Tables[0].Rows.Count);
            }
            else
            {
                lblOpenTaskCount.Text = "0";
                lblModuleCount.Text = "0";
                lblprojectStatus.Text = "0";
                lblActiveProjectCount.Text = "0";
            }
            gvProjects.DataSource = ds;
            gvProjects.DataBind();

            if (SessionData.RoleId == Roles.Client)
            {
                gvProjects.Columns["Edit"].Visible = false;
            }
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
        public void BindBubbleScreen(int status)
        {
            clsTask objTask = new clsTask();
            DataSet ds = objTask.SelectAllByComponentId(this.ProjectId, status);
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
                        thcell4.Attributes.Add("style", "color:DarkGoldenRod");
                        thcell4.Width = "20";
                        trTaskHeader.Cells.Add(thcell4);

                        //Cell5
                        HtmlTableCell thcell5 = new HtmlTableCell();
                        thcell5.InnerText = "03";
                        thcell5.Attributes.Add("class", "thhead");
                        thcell5.Attributes.Add("style", "color:blue");
                        thcell5.Width = "20";
                        trTaskHeader.Cells.Add(thcell5);

                        //Cell6
                        HtmlTableCell thcell6 = new HtmlTableCell();
                        thcell6.InnerText = "04";
                        thcell6.Attributes.Add("class", "thhead");
                        thcell6.Attributes.Add("style", "color:purple");
                        thcell6.Width = "20";
                        trTaskHeader.Cells.Add(thcell6);

                        //Cell7
                        HtmlTableCell thcell7 = new HtmlTableCell();
                        thcell7.InnerText = "05";
                        thcell7.Attributes.Add("class", "thhead");
                        thcell7.Attributes.Add("style", "color:red");
                        thcell7.Width = "20";
                        trTaskHeader.Cells.Add(thcell7);

                        //Cell8
                        HtmlTableCell thcell8 = new HtmlTableCell();
                        thcell8.InnerText = "06";
                        thcell8.Attributes.Add("class", "thhead");
                        thcell8.Attributes.Add("style", "color:brown");
                        thcell8.Width = "20";
                        trTaskHeader.Cells.Add(thcell8);

                        //Cell9
                        HtmlTableCell thcell9 = new HtmlTableCell();
                        thcell9.InnerText = "07";
                        thcell9.Attributes.Add("class", "thhead");
                        thcell9.Attributes.Add("style", "color:green");
                        thcell9.Width = "20";
                        trTaskHeader.Cells.Add(thcell9);

                        //Cell9
                        HtmlTableCell thcell10 = new HtmlTableCell();
                        thcell10.InnerText = "Comment";
                        thcell10.Attributes.Add("class", "thhead");
                        thcell10.Width = "40";
                        trTaskHeader.Cells.Add(thcell10);

                        ////Cell11
                        //HtmlTableCell thcell11 = new HtmlTableCell();
                        //thcell11.InnerText = "Delete";
                        //thcell11.Attributes.Add("class", "thhead");
                        //thcell11.Width = "40";
                        //trTaskHeader.Cells.Add(thcell11);

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

                                    #endregion

                                    #region TaskTable
                                    //Create Task Table


                                    //Create New Row
                                    HtmlTableRow trTask = new HtmlTableRow();

                                    //Create New Cell,Cell1
                                    HtmlTableCell trCell1 = new HtmlTableCell();
                                    HtmlAnchor tasklink = new HtmlAnchor();
                                    if (Convert.ToBoolean(drTask["IsHold"]) == true)
                                    {
                                        tasklink.InnerText = "(H)-" + taskID.ToString();
                                    }
                                    else
                                    {
                                        tasklink.InnerText = taskID.ToString();
                                    }
                                    tasklink.HRef = taskLink1.ToString();
                                    tasklink.Name = taskID.ToString();
                                    //tasklink.Attributes.Add("target", "_blank");
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
                                    if (Convert.ToBoolean(drTask["IsHold"]) == true)
                                    {
                                        tasklink.Attributes.Add("style", "color:DarkGoldenRod;");
                                    }
                                    if (SessionData.RoleId == Roles.Client)
                                    {
                                        tasklink.HRef = "";
                                    }
                                    trCell1.Width = "50";
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

                                    if (Convert.ToBoolean(drTask["IsHold"]) == true)
                                    {
                                        trCell2.Attributes.Add("style", "color:DarkGoldenRod;");
                                    }

                                    trTask.Cells.Add(trCell2);

                                    //Cell01
                                    HtmlTableCell trCell01 = new HtmlTableCell();
                                    Image img01 = new Image();
                                    if (percentageComplete == 14)
                                    {
                                        img01.ImageUrl = p1.ToString();
                                        img01.Attributes.Add("onmouseover", lastAccessDate.ToString());

                                        img01.Attributes.Add("alt", "14");
                                        img01.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img01.ImageUrl = "images/noimage.png"; img01.Attributes.Add("alt", "14"); img01.Attributes.Add("class", "bubblestatus"); }

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
                                        img02.Attributes.Add("alt", "28"); img02.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img02.ImageUrl = "images/noimage.png"; img02.Attributes.Add("alt", "28"); img02.Attributes.Add("class", "bubblestatus"); }
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
                                        img03.Attributes.Add("alt", "42"); img03.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img03.ImageUrl = "images/noimage.png"; img03.Attributes.Add("alt", "42"); img03.Attributes.Add("class", "bubblestatus"); }
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
                                        img04.Attributes.Add("alt", "56"); img04.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img04.ImageUrl = "images/noimage.png"; img04.Attributes.Add("alt", "56"); img04.Attributes.Add("class", "bubblestatus"); }
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
                                        img05.Attributes.Add("alt", "70"); img05.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img05.ImageUrl = "images/noimage.png"; img05.Attributes.Add("alt", "70"); img05.Attributes.Add("class", "bubblestatus"); }
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
                                        img06.Attributes.Add("alt", "84"); img06.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img06.ImageUrl = "images/noimage.png"; img06.Attributes.Add("alt", "84"); img06.Attributes.Add("class", "bubblestatus"); }
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
                                        img07.Attributes.Add("alt", "100"); img07.Attributes.Add("class", "bubblestatus");
                                    }
                                    else
                                    { img07.ImageUrl = "images/noimage.png"; img07.Attributes.Add("alt", "100"); img07.Attributes.Add("class", "bubblestatus"); }
                                    trCell07.Controls.Add(img07);
                                    trCell07.Width = "20";
                                    trTask.Cells.Add(trCell07);

                                    //Cell07
                                    HtmlTableCell trCell10 = new HtmlTableCell();
                                    Image img10 = new Image();
                                    img10.ImageUrl = "images/comment.png";
                                    //img10.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    img10.Attributes.Add("alt", "comment");
                                    img10.Attributes.Add("class", "comment");
                                    trCell10.Controls.Add(img10);

                                    Label lbldescription = new Label();
                                    lbldescription.Text = drTask["Description"].ToString();
                                    lbldescription.ID = "lbldescription";
                                    lbldescription.CssClass = "lbldescription";
                                    lbldescription.Style.Add("display", "none");
                                    trCell10.Controls.Add(lbldescription);
                                    trCell10.Width = "40";
                                    trTask.Cells.Add(trCell10);

                                    ////Cell For Delete Button
                                    //HtmlTableCell trCell11 = new HtmlTableCell();
                                    //Image img11 = new Image();
                                    //img11.ImageUrl = "images/closeMark1.png";
                                    ////img10.Attributes.Add("onmouseover", lastAccessDate.ToString());
                                    //img11.Attributes.Add("alt", "delete");
                                    //img11.Attributes.Add("class", "delete");
                                    //trCell11.Controls.Add(img11);
                                    //trTask.Cells.Add(trCell11);

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

            //string s = moduleTable.ToString();
            taskView.Controls.Add(moduleTable);
        }

        #endregion

        #region SendComment
        /// <summary>
        /// Send comment for the task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtnSendMessage_Click(object sender, EventArgs e)
        {
            //// Validation
            //if (string.IsNullOrEmpty(txtComment.Text.Trim()))
            //{
            //    Helper.ShowMessage(ref lblStatus, "Please enter comment", MessageType.Error);
            //    return;
            //}

            //// Add comment
            //clsTaskComment objTaskComment = new clsTaskComment();

            //objTaskComment.TaskId = this.TaskID;
            //objTaskComment.Comment = this.txtComment.Text.Trim();
            //objTaskComment.CreatedBy = SessionData.UserId;
            //objTaskComment.Createddate = DateTime.Now;
            //objTaskComment.ModifiedBy = 0;
            //objTaskComment.ModifiedDate = DateTime.Now;

            //objTaskComment.Insert();

            //// Bind comments
            //BindComment();

            //Helper.ShowMessage(ref lblStatus, "Comment added successfully", MessageType.Success);

            ////Send mail to the client when task is completed
            ////Retrive project related information 

            //clsProject objProjectClient = new clsProject();
            //DataSet dsProjectClient = objProjectClient.Select(Convert.ToInt64(lblProjectNo.Text));
            //clsTask objTask = new clsTask();
            //DataSet dsTask = objTask.Select(Convert.ToInt64(lblTaskNo.Text));

            ////Create mailer object and send the mail
            //Mailer objMailer = new Mailer(true);

            ////Send Update Mail To all the Group User,Select all record from task user table
            ////based on taskid
            //clsTaskUser objTaskUser = new clsTaskUser();
            //DataSet dsTaskUser = objTaskUser.SelectAll(this.TaskID);

            //foreach (DataRow drTask in dsTaskUser.Tables[0].Rows)
            //{
            //    string componentName = string.Empty;
            //    if (drTask["ComponentName"] != null)
            //    {
            //        componentName = drTask["ComponentName"].ToString();
            //    }
            //    string wfNumber = string.Empty;
            //    if (drTask["WireframeNo"] != null)
            //    {
            //        wfNumber = drTask["WireframeNo"].ToString();
            //    }

            //    if (drTask["UserName"].ToString() != string.Empty)
            //    {
            //        objMailer.SendClientTaskCommentMail(drTask["UserName"].ToString(), this.TaskID, lblProjectName.Text, rdoListTaskStatus.SelectedItem.Text, drTask["FullName"].ToString(), lblTaskTitle.Text, Convert.ToDateTime(lblDueDate.Text), lblTaskOwner.Text, SessionData.FirstName, SessionData.LastName, txtComment.Text, wfNumber, componentName);
            //    }
            //}

            //this.txtComment.Text = string.Empty;

            //////Set Comment Image For the Task
            ////insertremovecomment(this.TaskID);

            //////Bind Task Details
            ////BindTaskDetail(this.TaskID);

            //////Bind Task Grid
            ////BindTaskGrid();
        }
        #endregion

        protected void btndownloadpdf_Click(object sender, EventArgs e)
        {
            //downloadPdf(s);
            StreamReader sr;
            string strHTML;
            StreamWriter sw;
            string s = hdnHtml.Value;
            //s = s.Replace("#COMMA#", ",");  // Replace '#COMMA#' with ','
            //s = s.Replace("#DESH#", "'");  // Replace '#DESH#' with '''
            //s = s.Replace("#DBLDESH#", "\"");  // Replace '#DBLDESH#' with '"'
            //s = s.Replace("#DBBLDESH#", "/");
            //s = s.Replace("\n", " ");// Replace '#DBBLDESH#' with '"'
            finalHtml = s.Replace("View Tasks", "").Replace("Edit Project", "").Replace("Download Report", "");
            //sr = new StreamReader(finalHtml);
            //strHTML = sr.ReadToEnd();
            string date = DateTime.Now.ToShortDateString();
            date = "Date: " + date;
            string firstAppend = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> <html xmlns=\"http://www.w3.org/1999/xhtml\"><head>    <link rel=\"stylesheet\" type=\"text/css\" href=\"/DXR.axd?r=0_1894,0_1897,2_2,0_1792,0_1795,0_1800,0_1803-Lu8h5\" />    <title>Project Queue | Project Task Manager </title>    <link rel=\"Stylesheet\" href=\"App_Themes/default/style.css\" type=\"text/css\" />    <script type=\"text/javascript\">        function ReLoadGridStyles(s, e) { $(\"#ctl00_cphAdmin_gvProjects_DX-GSDT-col2 table td:nth-child(1)\").next().remove();}</script><style type=\"text/css\"> .taskimage { padding: 10px; }.taskimagesajax { height: 90px; width: 90px; margin-right: 10px; margin-bottom: 10px; }.divcontent{ width: 640px; height: 550px;overflow-y: scroll; } .comment { margin-left: 17px; } .c{background: white; border: solid 1px gray; width: 180px; height: 50px; text-align: center; vertical-align: middle; padding-top: 3px; padding-left: 5px;display: none; line-height: 16px; } #date {margin-right: 6px; margin-top: 2px; padding: 2px; }.white { background: white;} .red { background: red; }.yellow { background: yellow; }.green {background: green;} #message_box { position: absolute; top: 87%;left: 87%;z-index: 10; background: white; padding: 5px; border: 1px solid #CCCCCC;text-align: center; font-weight: bold;           width: 12%;        }        #ctl00_cphAdmin_taskView img        {            cursor: pointer;        }        .commentseparator        {            width: 600px;            height: 1px;            background: gray;            margin-bottom: 3px;        }    </style></head><body>    <!-- Start of Wrapper-->    <form id=\"form1\" runat=\"server\">    <div class=\"main\" style=\"background:none;padding-left:80px;background-color:white; \">   <div style=\"float:left;padding-bottom:20px;\"><img height=\"70px\" src=\"images/logo.png\" alt=\"\" /> </div><div class=\"website-title\" style=\"margin-left:20px;float:left;color: #3366FF;\"><h2> WorkVue</h2></div>    <div style=\"text-align: center;\">" + date + "  </div> <br/>     <div class=\"col-main\" style=\"float:none;\">            <div class=\"project-queue\"> <div id=\"ctl00_cphAdmin_divProjectView\" class=\"project-view\">";
            string finalTagEndAppend = "</div></div></div></div></form></body></html>";
            //File.Create(@"D:\\Projects\\Proman\\PromanWeb\\temp.html");

            File.WriteAllText(Server.MapPath(@"temp.html"), firstAppend + finalHtml + finalTagEndAppend);

            //sw.WriteLine(finalHtml + finalTagEndAppend);
            //sw.Close();
            finalHtml = string.Empty;
            //Response.Write(Server.MapPath("temp.html"));
            string path = Server.MapPath(@"temp.html");
            byte[] pdf = GeneratePdf(path);

            if (pdf != null)
            {
                //Response.Clear();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("Content-Disposition", "attachment; filename=workvue-Report.pdf" );
                //Response.BinaryWrite(pdf);
                //Response.End();

                //string filepath = Path.Combine(Server.MapPath("~/PDF"), "test.pdf");
                Response.Clear();
                MemoryStream ms = new MemoryStream(pdf);

                ms.Seek(0, SeekOrigin.Begin);
                byte[] rbyte = new byte[(int)ms.Length];
                ms.Read(rbyte, 0, (int)ms.Length);
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=workvue-Report.pdf");
                Response.BinaryWrite(rbyte);
                Response.End();

                //Response.Clear();

                //Response.BinaryWrite(pdf);
                //Response.End();
            }

            else
            {
                Helper.Log("Buffer Null");
            }
        }
        public static string finalHtml = string.Empty;
        public static StringBuilder sbFinal;
        [WebMethod]
        public static void downloadPdf(string s)
        {
            //s = s.Replace("#COMMA#", ",");  // Replace '#COMMA#' with ','
            //s = s.Replace("#DESH#", "'");  // Replace '#DESH#' with '''
            //s = s.Replace("#DBLDESH#", "\"");  // Replace '#DBLDESH#' with '"'
            //s = s.Replace("#DBBLDESH#", "/");
            //s = s.Replace("\n", " ");// Replace '#DBBLDESH#' with '"'
            //StringBuilder sb = new StringBuilder();
            //finalHtml = s;

        }

        private byte[] GeneratePdf(string pageUrl)
        {
            try
            {
                // StreamWriter stdin;
                // StreamReader Html = new StreamReader(@"http://www.google.com");
                //MemoryStream PDF = new MemoryStream(;
                Process p = new Process();
                // You can tell wkhtmltopdf to send it's output to sout by specifying "-" as the output file.
                string outFileName = "-";
                // get webUi physical path
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                //string exeFileName = System.IO.Path.Combine(baseDir, "bin\\wkhtmltopdf.exe");
                string exeFileName = Path.Combine(Server.MapPath("~/PDFConverter"), "wkhtmltopdf.exe");
                //string exeFileName = @"C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe";
                Helper.Log("ExeFilename = " + exeFileName.ToString());
                int waitTime = 30000;

                string switches = "";
                switches += "--print-media-type ";
                switches += "--page-size A4 ";
                // dots per inch
                switches += "--dpi 100 ";

                p.StartInfo.Arguments = switches + " " + pageUrl + " " + outFileName;

                p.StartInfo.UseShellExecute = false; // needs to be false in order to redirect output
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = exeFileName;
                p.StartInfo.WorkingDirectory = exeFileName.Substring(0, exeFileName.LastIndexOf('\\'));

                p.Start();
                Helper.Log("Process Start");
                //read output
                byte[] buffer = new byte[32768];
                byte[] file;

                p.WaitForExit(10000);

                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);

                        if (read <= 0)
                        {
                            break;
                        }
                        ms.Write(buffer, 0, read);
                    }
                    file = ms.ToArray();
                }
                Helper.Log("While End");
                // wait or exit
                p.WaitForExit(waitTime);

                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();
                Helper.Log("Process Stop");

                return (returnCode == 0 || returnCode == 2) ? file : null;
            }

            catch (Exception ex)
            {
                Helper.Log(ex.ToString());
                byte[] buffer = new byte[32768];
                return buffer;
            }

        }



    }


}