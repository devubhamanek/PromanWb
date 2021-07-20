using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Data;
namespace PromanWeb.admin.rolemanagement
{
    /// <summary>
    /// In this Page Authorized User Can Create/Update/Delete Activities.
    /// User cannot create Activity with Same name.
    /// </summary>
    public partial class activity : UserBasePage
    {
        #region Properties
        ///<summary>
        /// Get / Set ActivityID
        /// </summary>
        public Int64 ActivityID
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["ActivityID"])))
                {
                    return 0;
                }
                return Convert.ToInt64(ViewState["ActivityID"]);
            }
            set { this.ViewState["ActivityID"] = value; }
        }
        #endregion

        #region PageEvent

        /// <summary>
        /// Page Init Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            //Bind Activity Grid
            BindActivityGrid();
        }

        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region ControlEvent

        /// <summary>
        /// Row Command Event Of Activity Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvActivity_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            this.ActivityID = Convert.ToInt64(e.CommandArgs.CommandArgument);
            //Populate all the Fileds.
            if (e.CommandArgs.CommandName == "edit")
            {
                //Select Record from Activity Table and Populate Fileds with data.
                clsAdminUserActivity objActivity = new clsAdminUserActivity(this.ActivityID);

                txtActivityLink.Text = objActivity.ActivityLink;
                txtActivityName.Text = objActivity.ActivityName;
                chkStatus.Checked = objActivity.IsActive;
                btnDelete.Enabled = true;
            }

            //Delete Record from Activity Table.
            if (e.CommandArgs.CommandName == "delete")
            {
                //Delete Record.
                btnDelete_Click(null, null);
            }
        }

        /// <summary>
        /// Save Button Click Event.Save/Update Activity Record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Create Object of AdminUserActivity Class.
            clsAdminUserActivity objActivity = new clsAdminUserActivity();

            objActivity.ActivityID = this.ActivityID;
            objActivity.ActivityName = txtActivityName.Text.Trim();
            objActivity.ActivityLink = txtActivityLink.Text.Trim();
            objActivity.CreatedBy = SessionData.UserId;
            objActivity.CreatedDate = DateTime.Now;
            objActivity.ModifiedBy = SessionData.UserId;
            objActivity.ModifiedDate = DateTime.Now;
            objActivity.IsActive = chkStatus.Checked;

            //Check If This Activity Name Already Exists Or Not
            if (CheckExistanceActivity(txtActivityName.Text.Trim()))
            {
                //Update Record If Activity ID greater then Zero
                if (this.ActivityID > 0)
                {
                    objActivity.Update();
                    lblStatus.Visible = true;
                    Helper.ShowMessage(ref lblStatus, "Activity updated successfully.", MessageType.Success);
                }
                //Else Insert Record
                else
                {
                    this.ActivityID = objActivity.Insert();

                    //Set the Role Entry.
                    setRoleEntry();
                    lblStatus.Visible = true;
                    Helper.ShowMessage(ref lblStatus, "Activity added successfully.", MessageType.Success);
                }

                //Clear the Page and Refresh  the activgrid.
                ClearPage();
                BindActivityGrid();
            }
            else
            {
                lblStatus.Visible = true;
                Helper.ShowMessage(ref lblStatus, "Activity Name already exist.Please enter another activity name.", MessageType.Error);
            }

        }

        /// <summary>
        /// Cancel Button Click Event.Clear All the Fileds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearPage();
        }

        /// <summary>
        /// Delete Button Click Event.Delete Activity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete Record From Activity Table.
            clsAdminUserActivity objActivity = new clsAdminUserActivity();
            objActivity.ActivityID = this.ActivityID;
            objActivity.Delete1();

            //Delete all the Entry from ActivityRole table Associated To this activity.
            clsAdminActivityRole objActivityRole = new clsAdminActivityRole();
            objActivityRole.DeleteByActivityID(this.ActivityID);

            //ClearPage and Refresh Activity Grid.
            ClearPage();
            BindActivityGrid();

            lblStatus.Visible = true;
            Helper.ShowMessage(ref lblStatus, "Activity deleted successfully.", MessageType.Success);

        }

        #endregion

        #region Methods

        //When Activity Is Created Then By Default This activity's entry is inserted with every role in Activity role table.
        public void setRoleEntry()
        {
            clsRoles objRole = new clsRoles();

            DataSet dsRole = objRole.SelectAll();
            if (Helper.HasRow(dsRole))
            {
                foreach (DataRow dr in dsRole.Tables[0].Rows)
                {
                    clsAdminActivityRole objActivityRole = new clsAdminActivityRole();
                    objActivityRole.ActivityID = this.ActivityID;
                    objActivityRole.RoleID = Convert.ToInt64(dr["RoleID"]);
                    if (objActivityRole.RoleID == (int)Roles.SuperAdmin)
                    {
                        objActivityRole.Edit = true;
                        objActivityRole.Insert1 = true;
                        objActivityRole.Delete = true;
                        objActivityRole.View = true;
                    }
                    else
                    {
                        objActivityRole.Edit = false;
                        objActivityRole.Insert1 = false;
                        objActivityRole.Delete = false;
                        objActivityRole.View = false;
                    }
                    objActivityRole.IsActive = chkStatus.Checked;
                    objActivityRole.CreatedBy = SessionData.UserId;
                    objActivityRole.CreatedDate = DateTime.Now;
                    objActivityRole.ModifiedBy = SessionData.UserId;
                    objActivityRole.ModifiedDate = DateTime.Now;
                    objActivityRole.Insert();
                }
            }

        }
        //This Function Bind Activity Grid.
        public void BindActivityGrid()
        {
            clsAdminUserActivity objActivity = new clsAdminUserActivity();
            DataSet ds = objActivity.SelectAll();
            gvActivity.DataSource = ds;
            gvActivity.DataBind();
        }

        /// <summary>
        /// Check Already Existed Activity Name
        /// </summary>
        /// <param name="actiityName"></param>
        public bool CheckExistanceActivity(string actiityName)
        {
            clsAdminUserActivity objActivity = new clsAdminUserActivity();
            return objActivity.CheckExistsActivity(actiityName, this.ActivityID);
        }

        /// <summary>
        /// Clear all the Fileds of Page
        /// </summary>
        public void ClearPage()
        {
            txtActivityLink.Text = string.Empty;
            txtActivityName.Text = string.Empty;
            chkStatus.Checked = true;
            this.ActivityID = 0;
            btnDelete.Enabled = false;
        }

        #endregion



    }
}