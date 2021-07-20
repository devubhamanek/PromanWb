using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Data;

namespace PromanWeb
{
    /// <summary>
    /// This page use to view private task of the user
    /// </summary>
    public partial class my_private_task : UserBasePage
    {
        #region Page events
        /// <summary>
        /// Page Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind Page Details
            if (!IsPostBack)
            { ddlTaskStatus.SelectedIndex = 8; }
            BindPage();
        }
        #endregion

        #region Events
        /// <summary>
        ///gvTaskList HtmlRowCreated event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskList_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                return;

            Int32 dueIn = (Int32)gvTaskList.GetRowValues(e.VisibleIndex, "DueIn");

            e.Row.Cells[5].Text = Convert.ToString(dueIn) + " days";
            if (dueIn < 0)
            {
                //  e.Row.Cells[5].Style.Add("color", "#FF0000");
            }

            Int32 taskStatus = (Int32)gvTaskList.GetRowValues(e.VisibleIndex, "PercentageComplete");

            if (taskStatus == 28)
            {

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

                e.Row.Cells[8].Style.Add("color", "Green");
                e.Row.Cells[7].Style.Add("color", "Green");
                e.Row.Cells[6].Style.Add("color", "Green");
                e.Row.Cells[5].Style.Add("color", "Green");
                e.Row.Cells[4].Style.Add("color", "Green");
                e.Row.Cells[3].Style.Add("color", "Green");
                e.Row.Cells[2].Style.Add("color", "Green");
                e.Row.Cells[1].Style.Add("color", "Green");
            }
            clsTask objTask = new clsTask(Convert.ToInt32(e.KeyValue));
            if (objTask.IsHold)
            {

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
        /// Search Legend Image Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchimagelegend_Click(object sender, CommandEventArgs e)
        {

            switch (Convert.ToInt32(e.CommandArgument))
            {
                case 14:
                    ddlTaskStatus.SelectedIndex = 1;
                    BindPage();
                    break;
                case 28:
                    ddlTaskStatus.SelectedIndex = 2;
                    BindPage();
                    break;
                case 42:
                    ddlTaskStatus.SelectedIndex = 3;
                    BindPage();
                    break;
                case 56:
                    ddlTaskStatus.SelectedIndex = 4;
                    BindPage();
                    break;
                case 70:
                    ddlTaskStatus.SelectedIndex = 5;
                    BindPage();
                    break;
                case 84:
                    ddlTaskStatus.SelectedIndex = 6;
                    BindPage();
                    break;
                case 100:
                    ddlTaskStatus.SelectedIndex = 7;
                    BindPage();
                    break;

            }
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
        #endregion

        #region Methods

        /// <summary>
        /// Bind Page Detail
        /// </summary>
        private void BindPage()
        {
            //Set Null values for empty fields
            DateTime dateStart = DateTime.MinValue;
            DateTime dateEnd = DateTime.MinValue;

            if (dtStartDate.Date != DateTime.MinValue)
                dateStart = dtStartDate.Date;

            if (dtEndDate.Date != DateTime.MinValue)
                dateEnd = dtEndDate.Date;

            // Bind project related data
            clsTask objTask = new clsTask();

            if (ddlTaskStatus.SelectedItem != null)
            {
                DataSet dsTask = objTask.SelectMyPrivateTask(SessionData.UserId, dateStart, dateEnd, Convert.ToInt32(ddlTaskStatus.SelectedItem.Value));

                gvTaskList.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
                gvTaskList.DataSource = dsTask;
                gvTaskList.DataBind();
            }
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
            //staticpty
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
        #endregion
    }
}