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
    /// In this Page Authorized User can Add/delete/update Roles and Can Assign Activities.
    /// User Can Not Delete His/Her Own Account.
    /// Two Role with same name Is not Valid.
    /// </summary>
    public partial class role1 : UserBasePage 
    {
        #region Properties
        ///<summary>
        /// Get / Set RoleID
        /// </summary>
        public Int32 RoleID
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["RoleID"])))
                {
                    return 0;
                }
                return Convert.ToInt32(ViewState["RoleID"]);
            }
            set { this.ViewState["RoleID"] = value; }
        }
        #endregion

        #region PageEvent

        /// <summary>
        /// Page Load Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bind Role Grid.
            BindRole();

            //Bind Activity
            BindActivity();
        }
        #endregion

        #region ControlEvent
        /// <summary>
        /// Role GridView RowCommand Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvRole_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            this.RoleID = Convert.ToInt32(e.CommandArgs.CommandArgument);
            if (e.CommandArgs.CommandName == "edit")
            {
                ////Select Record From Role Table and Populate Data and Activity GridView.
                clsRoles objRole = new clsRoles(this.RoleID);
                txtRoleName.Text = objRole.RoleName;

                //Select Activity Of Perticular Role and Bind it with Activity Grid.
                clsAdminActivityRole objActivityRole = new clsAdminActivityRole();
                DataSet ds = objActivityRole.SelectByRoleID(this.RoleID);
                gvActivity.DataSource = ds;
                gvActivity.DataBind();

                gvActivity.Visible = true;
           
            }
            if (e.CommandArgs.CommandName == "delete")
            {
                //Delete Role From Role Tabel.
                //btnDelete_Click(null, null);
            }
        }

        /// <summary>
        /// Save Buttoh Click Event.Save/Update Role.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdatetActivityRoleRecords();
            ClearPage();
            lblStatus.Visible = true;
            Helper.ShowMessage(ref lblStatus, "Role Updated successfully.", MessageType.Success);
            ////Create Object Of Role And Set the Properties.
            //clsRoles objRole = new clsRoles();

            //objRole.RoleID = this.RoleID;
            //objRole.Name = txtRoleName.Text.Trim();
            //objRole.DisplayOrder = 1;
            //objRole.CreatedBy = SessionData.MemberId;
            //objRole.Createddate = DateTime.Now;
            //objRole.ModifiedDate = DateTime.Now;
            //objRole.ModifiedBy = SessionData.MemberId;
            //objRole.IsActive = chkStatus.Checked;

            //Check if same Role Name exists or not.
            //if (checkRoleExists())
            //{
            //    //Update The Role Record in Role Table.
            //    //if (this.RoleID > 0)
            //    //{
            //    //    //objRole.Update();

            //    //    ////Insert Role-Activity Entries Into ActivityRole Table.
            //    //    //UpdatetActivityRoleRecords();

            //    //    //lblStatus.Visible = true;
            //    //    //Helper.ShowMessage(ref lblStatus, "Role updated successfully.", MessageType.Success);
            //    //}
            //    //Else Insert the Role into Role Table.
            //    //else
            //    //{
            //    //    //this.RoleID = Convert.ToInt32(objRole.Insert());

            //    //    ////Insert Role-Activity Entries Into ActivityRole Table.
            //    //    //InsertActivityRoleRecords();

            //    //    //lblStatus.Visible = true;
            //    //    //Helper.ShowMessage(ref lblStatus, "Role inserted successfully.", MessageType.Success);
            //    //}
            //    //Clear the Page and Refresh the Grid.
               
            //    BindRole();
            //}
            //else
            //{
            //    //lblStatus.Visible = true;
            //    //Helper.ShowMessage(ref lblStatus, "Role Name already exist.Please Enter another name.", MessageType.Error);
            //}
        }

        /// <summary>
        /// Cancel Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearPage();
        }

        /// <summary>
        /// Delete Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ////Delete Role From Role Table.
            //Role objRole = new Role();
            //objRole.RoleID = this.RoleID;
            //objRole.Delete();

            ////Delete RoleActivity Entries Associated with this role.
            //AdminActivityRole objActivityRole = new AdminActivityRole();
            //objActivityRole.DeleteByRoleID(this.RoleID);

            ////Clear Page and Refresh Role Grid.
            //ClearPage();
            //BindRole();

            //lblStatus.Visible = true;
            //Helper.ShowMessage(ref lblStatus, "Role deleted successfully.", MessageType.Success);
        }

        #endregion

        #region Methode
        //Bind Role Grid.
        public void BindRole()
        {
            //Select All the Records from role table and bind role grid.
            clsRoles objRole = new clsRoles();
            DataSet ds = objRole.SelectAll();
            gvRole.DataSource = ds;
            gvRole.DataBind();
        }

        //Clear Page.
        public void ClearPage()
        {
            this.RoleID = 0;
            gvActivity.Visible = false;
            txtRoleName.Text = string.Empty;
        }

        ///// <summary>
        ///// Check if Role with Same name already exists or not.
        ///// </summary>
        ///// <returns></returns>
        //public bool checkRoleExists()
        //{
        //    //Return False if Role already Exists ,else either
        //    Role objRole = new Role();
        //    return objRole.CheckExistsRole(txtRoleName.Text.Trim(), this.RoleID);
        //}

        /// <summary>
        /// Bind Activity Grid.
        /// </summary>
        public void BindActivity()
        {
            //Select All the Activity From Activity Table and Bind Activity Grid.
            //clsAdminUserActivity objUserActivity = new clsAdminUserActivity();
            //DataSet ds = objUserActivity.SelectAll();
            //gvActivity.DataSource = ds;
            //gvActivity.DataBind();
        }

        /// <summary>
        /// This Function Update Each Activity To the Perticular Role
        /// </summary>
        private void UpdatetActivityRoleRecords()
        {
            //Delete Old Role-Activity Records From ActivityRole Table.
            clsAdminActivityRole objActivityRole = new clsAdminActivityRole();
            objActivityRole.DeleteByRoleID(this.RoleID);

            //Retrive Selected Radio Button From Activity 
            for (int i = 0; i < gvActivity.VisibleRowCount; i++)
            {
                CheckBox chkView = (CheckBox)gvActivity.FindRowCellTemplateControl(i, null, "chkView");
                CheckBox chkEdit = (CheckBox)gvActivity.FindRowCellTemplateControl(i, null, "chkEdit");
                CheckBox chkDelete = (CheckBox)gvActivity.FindRowCellTemplateControl(i, null, "chkDelete");
                Label lblActivityID = (Label)gvActivity.FindRowCellTemplateControl(i, null, "lblActivityID");

                objActivityRole.ActivityID = Convert.ToInt64(lblActivityID.Text);
                objActivityRole.RoleID = this.RoleID;
                objActivityRole.Insert1 = Convert.ToBoolean(chkEdit.Checked);
                objActivityRole.View = Convert.ToBoolean(chkView.Checked);
                objActivityRole.Edit = Convert.ToBoolean(chkEdit.Checked);
                objActivityRole.Delete = Convert.ToBoolean(chkDelete.Checked);
                objActivityRole.CreatedBy = SessionData.UserId;
                objActivityRole.CreatedDate = DateTime.Now;
                objActivityRole.ModifiedBy = SessionData.UserId;
                objActivityRole.ModifiedDate = DateTime.Now;
                objActivityRole.IsActive = true;
                //Insert Activity
                objActivityRole.Insert();
            }
        }


        /// <summary>
        /// This Function Add Each Activity To the Perticular Role
        /// </summary>
        //private void InsertActivityRoleRecords()
        //{
        //    //Retrive Selected Radio Button From Activity 
        //    for (int i = 0; i < gvActivityBlank.VisibleRowCount; i++)
        //    {
        //        CheckBox chkView = (CheckBox)gvActivityBlank.FindRowCellTemplateControl(i, null, "chkView");
        //        CheckBox chkEdit = (CheckBox)gvActivityBlank.FindRowCellTemplateControl(i, null, "chkEdit");
        //        CheckBox chkDelete = (CheckBox)gvActivityBlank.FindRowCellTemplateControl(i, null, "chkDelete");
        //        Label lblActivityID = (Label)gvActivityBlank.FindRowCellTemplateControl(i, null, "lblActivityID");

        //        clsAdminActivityRole objActivityRole = new clsAdminActivityRole();
        //        objActivityRole.ActivityID = Convert.ToInt64(lblActivityID.Text);
        //        objActivityRole.RoleID = this.RoleID;
        //        objActivityRole.Insert1 = Convert.ToBoolean(chkEdit.Checked);
        //        objActivityRole.View = Convert.ToBoolean(chkView.Checked);
        //        objActivityRole.Edit = Convert.ToBoolean(chkEdit.Checked);
        //        objActivityRole.Delete = Convert.ToBoolean(chkDelete.Checked);
        //        objActivityRole.CreatedBy = SessionData.UserId;
        //        objActivityRole.CreatedDate = DateTime.Now;
        //        objActivityRole.ModifiedBy = SessionData.UserId;
        //        objActivityRole.ModifiedDate = DateTime.Now;
        //        objActivityRole.IsActive = chkStatus.Checked;

        //        //Insert Activity
        //        objActivityRole.Insert();
        //    }
        //}
        #endregion
    }
}