using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Data;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;

namespace PromanWeb
{
    public partial class Search_task : UserBasePage
    {
        #region Properties
        public Int64 projectId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["projectId"])))
                {
                    return 0;
                }
                return Convert.ToInt64(ViewState["projectId"]);
            }
            set { this.ViewState["projectId"] = value; }
        }
        public Int64 moduleId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["moduleId"])))
                {
                    return 0;
                }
                return Convert.ToInt64(ViewState["moduleId"]);
            }
            set { this.ViewState["moduleId"] = value; }
        }
        public Int64 taskId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["taskId"])))
                {
                    return 0;
                }
                return Convert.ToInt64(ViewState["taskId"]);
            }
            set { this.ViewState["taskId"] = value; }
        }

        public string componentNumb
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["componentNumb"])))
                { return Convert.ToString(0); }

                return Convert.ToString(ViewState["componentNumb"]);
            }
            set
            {
                ViewState["componentNumb"] = value;
            }
        }

        public string wireframNo
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["wireframNo"])))
                { return string.Empty; }

                return Convert.ToString(ViewState["wireframNo"]);
            }
            set
            {
                ViewState["wireframNo"] = value;
            }
        }

        public string description
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["description"])))
                { return string.Empty; }

                return Convert.ToString(ViewState["description"]);
            }
            set
            {
                ViewState["description"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind Project Dropdown
                BindFillDropDownList();
                ddlTaskStatus.SelectedIndex = 1;
            }

            if(IsPostBack)
                BindTask();
            BindArrayPRojectID();
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "ChangeColors('Server');", true);
        }

        protected void btnsearch_OnClick(object sender, EventArgs e)
        {
            //gvTaskList.Visible = true;

            this.projectId = Convert.ToInt64(ddlProjectName.Value.ToString());


            if (projectId == 0)
            {
                this.moduleId = 0;
                this.componentNumb = "0";
            }
            else
            {
                this.moduleId = Convert.ToInt64(ddlModule.Value.ToString());
                if (this.moduleId == 0)
                {
                    this.componentNumb = "0";
                }
                else
                {
                    this.componentNumb = ddlComponent.Value.ToString();
                }
            }



            if (string.IsNullOrEmpty(txtTaskNumber.Text.Trim()))
            {
                this.taskId = 0;
            }
            else
            {
                this.taskId = Convert.ToInt64(txtTaskNumber.Text.Trim());
            }

            this.wireframNo = txtWireFrameNo.Text.Trim().ToLower();
            this.description = txtTaskDescription.Text.Trim().ToLower();

            BindTask();

            


        }

        public void BindTask()
        {
            if (this.taskId != 0)
            {
                clsTask objTask1 = new clsTask(this.taskId);
               
                Response.Redirect("~/task-detail.aspx?projectid="+objTask1.ProjectId+"&taskid="+this.taskId);
            }
            else
            {
                clsTask objTask = new clsTask();
                //DataSet ds = objTask.SelectByUserId();
                DataSet ds = objTask.SelectSearchByUserId(SessionData.UserId, this.projectId, this.moduleId, this.componentNumb, this.taskId, this.wireframNo, this.description, Convert.ToInt32(ddlTaskStatus.SelectedItem.Value));
                gvTaskList.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
                gvTaskList.DataSource = ds;
                gvTaskList.DataBind();
            }
            
        }

        /// <summary>
        /// Search Legend Image Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchimagelegend_Click(object sender, CommandEventArgs e)
        {

            switch (Convert.ToInt32(e.CommandArgument))
            {
                case 14:
                    ddlTaskStatus.SelectedIndex = 2;
                    BindTask();
                    break;
                case 28:
                    ddlTaskStatus.SelectedIndex = 3;
                    BindTask();
                    break;
                case 42:
                    ddlTaskStatus.SelectedIndex = 4;
                    BindTask();
                    break;
                case 56:
                    ddlTaskStatus.SelectedIndex = 5;
                    BindTask();
                    break;
                case 70:
                    ddlTaskStatus.SelectedIndex = 6;
                    BindTask();
                    break;
                case 84:
                    ddlTaskStatus.SelectedIndex = 7;
                    BindTask();
                    break;
                case 100:
                    ddlTaskStatus.SelectedIndex = 8;
                    BindTask();
                    break;
            }
        }
        /// <summary>
        ///gvTaskList HtmlRowCreated event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskList_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                return;

            clsTask objTask = new clsTask(Convert.ToInt32(e.KeyValue));
            Int32 dueIn = (Int32)gvTaskList.GetRowValues(e.VisibleIndex, "DueIn");
            //bool Hold = Convert.ToBoolean(gvTaskList.GetRowValues(e.VisibleIndex, "IsHold"));
            //if (Hold == true)
            //{
            //    e.Row.Cells[9].Text = Convert.ToString("H") + "TaskId";
            //}
            e.Row.Cells[5].Text = Convert.ToString(dueIn) + " days";
            if (dueIn < 0)
            {
                // e.Row.Cells[5].Style.Add("color", "#FF0000");
            }

            Int32 taskStatus = (Int32)gvTaskList.GetRowValues(e.VisibleIndex, "PercentageComplete");

            if (taskStatus == 28)
            {
                e.Row.Cells[9].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[8].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[7].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[6].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[5].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[4].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[3].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[2].Style.Add("color", "DarkGoldenRod ");
                e.Row.Cells[1].Style.Add("color", "DarkGoldenRod ");
            }
            if (taskStatus == 42)
            {
                e.Row.Cells[9].Style.Add("color", "Blue");
                e.Row.Cells[8].Style.Add("color", "Blue");
                e.Row.Cells[7].Style.Add("color", "Blue");
                e.Row.Cells[6].Style.Add("color", "Blue");
                e.Row.Cells[5].Style.Add("color", "Blue");
                e.Row.Cells[4].Style.Add("color", "Blue");
                e.Row.Cells[3].Style.Add("color", "Blue");
                e.Row.Cells[2].Style.Add("color", "Blue");
                e.Row.Cells[1].Style.Add("color", "Blue");
            }
            if (taskStatus == 56)
            {
                e.Row.Cells[9].Style.Add("color", "Purple");
                e.Row.Cells[8].Style.Add("color", "Purple");
                e.Row.Cells[7].Style.Add("color", "Purple");
                e.Row.Cells[6].Style.Add("color", "Purple");
                e.Row.Cells[5].Style.Add("color", "Purple");
                e.Row.Cells[4].Style.Add("color", "Purple");
                e.Row.Cells[3].Style.Add("color", "Purple");
                e.Row.Cells[2].Style.Add("color", "Purple");
                e.Row.Cells[1].Style.Add("color", "Purple");
            }
            if (taskStatus == 70)
            {
                e.Row.Cells[9].Style.Add("color", "Red");
                e.Row.Cells[8].Style.Add("color", "Red");
                e.Row.Cells[7].Style.Add("color", "Red");
                e.Row.Cells[6].Style.Add("color", "Red");
                e.Row.Cells[5].Style.Add("color", "Red");
                e.Row.Cells[4].Style.Add("color", "Red");
                e.Row.Cells[3].Style.Add("color", "Red");
                e.Row.Cells[2].Style.Add("color", "Red");
                e.Row.Cells[1].Style.Add("color", "Red");
            }
            if (taskStatus == 84)
            {
                e.Row.Cells[9].Style.Add("color", "Brown");
                e.Row.Cells[8].Style.Add("color", "Brown");
                e.Row.Cells[7].Style.Add("color", "Brown");
                e.Row.Cells[6].Style.Add("color", "Brown");
                e.Row.Cells[5].Style.Add("color", "Brown");
                e.Row.Cells[4].Style.Add("color", "Brown");
                e.Row.Cells[3].Style.Add("color", "Brown");
                e.Row.Cells[2].Style.Add("color", "Brown");
                e.Row.Cells[1].Style.Add("color", "Brown");
            }
            if (taskStatus == 100)
            {
                e.Row.Cells[9].Style.Add("color", "Green");
                e.Row.Cells[8].Style.Add("color", "Green");
                e.Row.Cells[7].Style.Add("color", "Green");
                e.Row.Cells[6].Style.Add("color", "Green");
                e.Row.Cells[5].Style.Add("color", "Green");
                e.Row.Cells[4].Style.Add("color", "Green");
                e.Row.Cells[3].Style.Add("color", "Green");
                e.Row.Cells[2].Style.Add("color", "Green");
                e.Row.Cells[1].Style.Add("color", "Green");
            }

            if (objTask.IsHold)
            {
                e.Row.Cells[9].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[8].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[7].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[6].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[5].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[4].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[3].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[2].Style.Add("color", "DarkGoldenRod");
                e.Row.Cells[1].Style.Add("color", "DarkGoldenRod");
            }
        }
        /// <summary>
        /// Module dropdown callback event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void ddlModule_Callback(object source, CallbackEventArgsBase e)
        {
            if (e.Parameter == "0") return;

            Common objCommon = new Common();
            objCommon.FillModule(ref ddlModule, Convert.ToInt64(e.Parameter), true);

        }

        /// <summary>
        /// Module dropdown callback event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void ddlComponent_Callback(object source, CallbackEventArgsBase e)
        {
            if (e.Parameter == "0") return;

            Common objCommon = new Common();
            objCommon.FillComponent(ref ddlComponent, Convert.ToInt64(e.Parameter), true);
        }


        public string ProjectPercet = string.Empty;
        /// <summary>
        /// Fill Drop Down Authorised Signature data and set data
        /// </summary>
        public void BindFillDropDownList()
        {
            DataSet ds = BindArrayPRojectID();

            ddlProjectName.DataSource = ds;
            ddlProjectName.TextField = "ProjectName";
            ddlProjectName.ValueField = "ProjectId";
            ddlProjectName.DataBind();

            // Add the select state item
            ddlProjectName.SelectedIndex = 0;
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
        /// <summary>
        /// Get Colored Image For the Task
        /// </summary>
        public string GetSearchImage(int status)
        {
            switch (status)
            {
                case 14:
                    return "~/images/t14.png";
                    break;
                case 28:
                    return "~/images/t28.png";
                    break;
                case 42:
                    return "~/images/t42.png";
                    break;
                case 56:
                    return "~/images/t56.png";
                    break;
                case 70:
                    return "~/images/t70.png";
                    break;
                case 84:
                    return "~/images/t84.png";
                    break;
                case 100:
                    return "~/images/t100.png";
                    break;
                default:
                    return "~/images/t14.png";
                    break;
            }
        }
        /// <summary>
        /// Show Hide Comment Image
        /// </summary>
        public bool ShowHideCommentImage(int commentCount)
        {
            if (SessionData.UserId == 4 || SessionData.UserId == 5 || SessionData.UserId == 30)
            { return false; }
            else
            {
                if (commentCount == 0)
                { return false; }
                else
                { return true; }
            }
        }
        /// <summary>
        /// Get Colored Image For Comment
        /// </summary>
        public string GetCommentImage(int commentcount, int status)
        {
            if (commentcount != 0)
            {
                return "~/images/comment.png";
            }
            else
            { return string.Empty; }
        }

        public string GetColorForLink(int status)
        {
            switch (status)
            {
                case 14:
                    return "black";
                    break;
                case 28:
                    return "DarkGoldenRod";
                    break;
                case 42:
                    return "blue";
                    break;
                case 56:
                    return "purple";
                    break;
                case 70:
                    return "red";
                    break;
                case 84:
                    return "brown";
                    break;
                case 100:
                    return "green";
                    break;
                case 101:
                    return "DarkGoldenRod";
                    break;
                default:
                    return "black";
                    break;
            }
        }
    }
}