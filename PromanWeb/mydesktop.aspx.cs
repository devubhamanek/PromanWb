using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proman.BLL;
using DevExpress.Web.ASPxEditors;

namespace PromanWeb
{
    public partial class mydesktop : System.Web.UI.Page
    {
        #region
        /// <summary>
        /// TasK ID used in the application
        /// </summary>
        public Int64 DTaskID
        {
            get
            {
                if (this.ViewState["DTaskID"] == null)
                    return 0;

                return Convert.ToInt64(this.ViewState["DTaskID"]);
            }
            set { this.ViewState["DTaskID"] = value; }
        }
        #endregion
        #region PageEvent
        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFillDropDownList();
                dtCreationDate.Value = DateTime.Now;
            }

            //Bind Open and Close Task
            BindOpenTask();
            BindCloseTask();
        }
        #endregion

        #region Control Event

        /// <summary>
        /// Open Task grid view Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOpenTask_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            btnClose.Visible = true;

            this.DTaskID = Convert.ToInt64(e.CommandArgs.CommandArgument);
            clsDTask objTask = new clsDTask(this.DTaskID);

            //Edit Mode
            if (e.CommandArgs.CommandName == "E")
            {
                lblProjectname.Text = objTask.ProjectName;

                if (!string.IsNullOrEmpty(objTask.TaskNumber))
                    lbltasknumber.Text = objTask.TaskNumber;
                else
                    lbltasknumber.Text = "--";
                lblDescription.Text = objTask.Description;
                lblCreationDate.Text = objTask.CreationDate.ToString("MM-dd-yyyy");
                if (objTask.IsUrgent)
                    lblUrgent.Text = "Yes";
                else
                    lblUrgent.Text = "No";

                divtaskdetails.Visible = true;

            }
            else if (e.CommandArgs.CommandName == "D")
            {
                objTask.Delete();
                Helper.ShowMessage(ref lblStatus, "Task has been deleted successfully.", MessageType.Success);
                BindOpenTask();
            }
        }


        /// <summary>
        /// Open Task grid view Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCloseTask_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            btnClose.Visible = false;

            this.DTaskID = Convert.ToInt64(e.CommandArgs.CommandArgument);
            clsDTask objTask = new clsDTask(this.DTaskID);

            //Edit Mode
            if (e.CommandArgs.CommandName == "E")
            {
                lblProjectname.Text = objTask.ProjectName;

                if (!string.IsNullOrEmpty(objTask.TaskNumber))
                    lbltasknumber.Text = objTask.TaskNumber;
                else
                    lbltasknumber.Text = "--";
                lblDescription.Text = objTask.Description;
                lblCreationDate.Text = objTask.CreationDate.ToString("MM-dd-yyyy");
                if (objTask.IsUrgent)
                    lblUrgent.Text = "Yes";
                else
                    lblUrgent.Text = "No";

                divtaskdetails.Visible = true;

            }
            else if (e.CommandArgs.CommandName == "D")
            {
                objTask.Delete();
                Helper.ShowMessage(ref lblStatus, "Task has been deleted successfully.", MessageType.Success);
                BindOpenTask();
            }
        }

        /// <summary>
        /// Save DeskTop Task Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Create object of class DTask
            clsDTask objTask = new clsDTask();

            objTask.CreationDate = Convert.ToDateTime(dtCreationDate.Text);
            objTask.ProjectID = Convert.ToInt64(ddlProjectName.SelectedItem.Value);
            objTask.ProjectName = ddlProjectName.SelectedItem.Text;
            if (string.IsNullOrEmpty(txtTaskNumber.Text))
            { objTask.TaskNumber = "--"; }
            else
                objTask.TaskNumber = txtTaskNumber.Text.Trim();
            objTask.TaskStatus = Convert.ToString(DTask.Open);
            objTask.Description = txtTaskDescription.Text.Trim();
            objTask.IsUrgent = chkIsUrgent.Checked;
            objTask.CreatedDate = DateTime.Now;
            objTask.ModifiedDate = DateTime.Now;
            objTask.CreatedBy = SessionData.UserId;
            objTask.ModifiedBy = SessionData.UserId;
            objTask.IsActive = true;

            //Insert Task
            objTask.Insert();

            Helper.ShowMessage(ref lblStatus, "Task has been created successfully.", MessageType.Success);

            //Clear Fields
            ClearCreateTask();

            //Bind Open Task Grid
            BindOpenTask();

            dtCreationDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Cancel Task Details Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divtaskdetails.Visible = false;
        }
        #endregion

        #region Methode
        /// <summary>
        /// This methode will bind open task grid
        /// </summary>
        public void BindOpenTask()
        {
            clsDTask objTask = new clsDTask();
            DataSet ds = objTask.SelectAllByStatus(Convert.ToString(DTask.Open), SessionData.UserId);
            gvOpenTask.DataSource = ds;
            gvOpenTask.DataBind();

            pgrDesktop.TabPages[0].Text = "Open Desktop Tasks (" + ds.Tables[0].Rows.Count + ")";
        }

        /// <summary>
        /// This methode will bind close task grid
        /// </summary>
        public void BindCloseTask()
        {
            clsDTask objTask = new clsDTask();
            DataSet ds = objTask.SelectAllByStatus(Convert.ToString(DTask.Close), SessionData.UserId);
            gvCloseTask.DataSource = ds;
            gvCloseTask.DataBind();

            pgrDesktop.TabPages[1].Text = "Closed Desktop Tasks (" + ds.Tables[0].Rows.Count + ")";
        }

        /// <summary>
        /// This methode will bind close task grid
        /// </summary>
        public void ClearCreateTask()
        {
            dtCreationDate.Text = string.Empty;
            ddlProjectName.SelectedIndex = 0;
            txtTaskNumber.Text = "";
            txtTaskDescription.Text = "";
            chkIsUrgent.Checked = false;
            this.DTaskID = 0;
            divtaskdetails.Visible = false;
        }

        public string GetProjectLink(Int64 projectID)
        {
            if (projectID == -1)
            { return "#"; }
            else
            { return "task-detail.aspx?projectid=" + projectID; }
        }

        public string GetDescription(string desc)
        {
            if (desc.Length > 45)
            { desc = desc.Substring(0, 45) + "..."; }

            return desc;
        }
        public bool GetVisibleStatus1(string tasknumber)
        {
            if (string.IsNullOrEmpty(tasknumber))
            { return false; }
            else
            { return true; }
        }

        public bool GetVisibleStatus(string tasknumber)
        {
            if (string.IsNullOrEmpty(tasknumber))
            { return true; }
            else
            { return false; }
        }

        public string GetTaskLink(string tasknumber, Int64 projectID)
        {
            if (string.IsNullOrEmpty(tasknumber))
            { return "#"; }
            else
            { return "task-detail.aspx?projectid=" + projectID + "&taskid=" + tasknumber; }
        }

        public bool VISIBLETF(string tasknum)
        {
            if (tasknum == "--")
            { return false; }
            else
            { return true; }
        }

        public bool VISIBLETF1(string tasknum)
        {
            if (tasknum == "--")
            { return true
                ; }
            else
            { return false
                ; }
        }
        public string ProjectPercet = string.Empty;
        /// <summary>
        /// Fill Drop Down Authorised Signature data and set data
        /// </summary>
        public void BindFillDropDownList()
        {
            //code for bind dropdown button
            DataSet ds = BindArrayPRojectID();
            ddlProjectName.DataSource = ds;
            ddlProjectName.TextField = "ProjectName";
            ddlProjectName.ValueField = "ProjectId";
            ddlProjectName.DataBind();

            // Add the select state item
            ddlProjectName.SelectedIndex = 0;
            ddlProjectName.Items.Insert(ds.Tables[0].Rows.Count, new ListEditItem("Other", "-1"));
        }

        public DataSet BindArrayPRojectID()
        {
            //code for bind dropdown button
            clsProject objProject = new clsProject();
            DataSet ds = objProject.ProjectNameSelectByUserId(SessionData.UserId, Convert.ToInt64(SessionData.RoleId));

            DataRow newCustomersRow = ds.Tables[0].NewRow();
            newCustomersRow["ProjectId"] = Convert.ToInt64(0);
            newCustomersRow["ProjectName"] = "--Select Project--";
            newCustomersRow["ProjectPercent"] = Convert.ToInt64(0);
            ds.Tables[0].Rows.InsertAt(newCustomersRow, 0);

            if (string.IsNullOrEmpty(ProjectPercet))
            {
                if (Helper.HasRow(ds))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ProjectPercet = ProjectPercet + ds.Tables[0].Rows[i]["ProjectPercent"].ToString() + ",";
                    }

                    ProjectPercet = ProjectPercet.Remove(ProjectPercet.Length - 1);
                }
            }
            return ds;
        }
        #endregion

        /// <summary>
        /// Html Row Created Event of Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOpenTask_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                return;



            bool isUrgent = (bool)gvOpenTask.GetRowValues(e.VisibleIndex, "IsUrgent");

            if (isUrgent)
            {
                e.Row.Style.Add("background", "#F2DCDB");
                e.Row.Style.Add("font-weight", "bold");
                e.Row.Style.Add("color", "#F83100");
            }
        }

        /// <summary>
        /// Html Row Created Event of Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCloseTask_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                return;

            bool isUrgent = (bool)gvCloseTask.GetRowValues(e.VisibleIndex, "IsUrgent");

            if (isUrgent)
            {
                e.Row.Style.Add("background", "#F2DCDB");
                e.Row.Style.Add("font-weight", "bold");
                e.Row.Style.Add("color", "#F83100");
            }
        }

        /// <summary>
        /// Close the Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            //Update Task Status
            clsDTask objTask = new clsDTask();
            objTask.UpdateTaskStatus(this.DTaskID, Convert.ToString(DTask.Close));
            objTask.UpdateCloseDate(this.DTaskID, DateTime.Now);

            //Clear page details
            ClearCreateTask();

            Helper.ShowMessage(ref lblStatus, "Task has been closed successfully.", MessageType.Success);

            BindOpenTask();
            BindCloseTask();
        }

        /// <summary>
        /// Check UnCkech Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkSelectforDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectforDelete.Checked)
            {
                btnimgDelete.Enabled = true;
                btnimgDelete.ImageUrl = "~/images/btndeleteenable.png";
                gvCloseTask.Selection.SelectAll();
            }
            else
            {
                btnimgDelete.Enabled = false;
                btnimgDelete.ImageUrl = "~/images/btndeletedisable.png";
                gvCloseTask.Selection.UnselectAll();
            }
        }

       
        /// <summary>
        /// Delete selected rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgDelete_Click(object sender, ImageClickEventArgs e)
        {
            // Get select Rows
            List<object> selection = gvCloseTask.GetSelectedFieldValues(gvCloseTask.KeyFieldName);

            //  gvcityQueue.Selection.SelectAll();

            if (selection.Count <= 0)
            {
                //Show Message 
                Helper.ShowMessage(ref lblStatus, "Please select at least one item.", MessageType.Error);
                return;
            }

            foreach (object key in selection)
            {
                clsDTask objTask = new clsDTask();
                objTask.DTaskID = Convert.ToInt64(key);
                objTask.Delete();
            }

            Helper.ShowMessage(ref lblStatus, "Tasks have been deleted successfully.", MessageType.Success);

            //Bind Close Task Grid
            BindCloseTask();

            btnimgDelete.ImageUrl = "~/images/btndeletedisable.png";
            btnimgDelete.Enabled = false;
            chkSelectforDelete.Checked = false;
        }
    }
}