using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.IO;
using System.Data;
using DevExpress.Web.ASPxEditors;
namespace PromanWeb
{
    /// <summary>
    /// This page add/edit/delete project
    /// </summary>
    public partial class project_creator : UserBasePage
    {
        #region property
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
        /// Get or set ClientId
        /// </summary>
        public Int64 ClientId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["ClientId"])))
                { return 0; }

                return Convert.ToInt64(ViewState["ClientId"]);
            }
            set
            {
                ViewState["ClientId"] = value;
            }
        }
        /// <summary>
        /// Get or set avtar value
        /// </summary>
        public string Avtar
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["Avtar"])))
                { return null; }

                return Convert.ToString(ViewState["Avtar"]);
            }
            set
            {
                ViewState["Avtar"] = value;
            }
        }

        /// <summary>
        /// Get or set Module
        /// </summary>
        public Int64 ModuleId
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["ModuleId"])))
                { return 0; }

                return Convert.ToInt64(ViewState["ModuleId"]);
            }
            set
            {
                ViewState["ModuleId"] = value;
            }
        }


        /// <summary>
        /// Get or set Module
        /// </summary>
        public Int64 ComponentID
        {
            get
            {
                if (string.IsNullOrEmpty(Convert.ToString(ViewState["ComponentID"])))
                { return 0; }

                return Convert.ToInt64(ViewState["ComponentID"]);
            }
            set
            {
                ViewState["ComponentID"] = value;
            }
        }

        /// <summary>
        /// This is temp storage for Modules
        ///  </summary>
        public List<ModuleEntity> ListModuleName
        {
            get
            {
                if (ViewState["ModuleName"] == null)
                {
                    return null;
                }
                return (List<ModuleEntity>)ViewState["ModuleName"];
            }
            set { ViewState["ModuleName"] = value; }
        }

        public List<ComponentEntiry> ListComponentName
        {
            get
            {
                if (ViewState["ComponentName"] == null)
                {
                    return null;
                }
                return (List<ComponentEntiry>)ViewState["ComponentName"];
            }
            set { ViewState["ComponentName"] = value; }
        }

        #endregion

        #region PageEvents
        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (gvComponents.VisibleRowCount <= 0)
            { gvComponents.Visible = false; }
            else
            {
                gvComponents.Visible = true;
            }
            //if (SessionData.RoleId != Roles.SuperAdmin)
            //{
            //    Response.Redirect("~/account/signin.aspx");
            //}
            BindModulePagging();
            if (!IsPostBack)
            {
                //BindPage Detail
                BindPage();
            }
            BindComponent();
        }
        #endregion

        #region Control Events
        /// <summary>
        /// gridview HtmlRowCreated event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvModules_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
        }
        /// <summary>
        /// this function Delete project avator image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAvtarImageDelete_Click(object sender, EventArgs e)
        {
            //Now check image is uploaded or not.
            if (string.IsNullOrEmpty(this.Avtar)) return;
            //delete image
            Helper objHelper = new Helper();
            objHelper.DeleteProjectImages(this.Avtar);

            //update in project table
            clsProject objProject = new clsProject();
            objProject.UpdateProjectAvatorImage(this.ProjectId, null);

            //Update Message
            Helper.ShowMessage(ref lblStatus, "Project avator image deleted successfully", MessageType.Success);
            this.Avtar = null;
            FileStatus();
        }
        /// <summary>
        /// gridview Rowcoomand events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvModules_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            btnDeleteModule.Visible = true;
            //btnUpdateModule.Visible = true; 
            this.ModuleId = Convert.ToInt64(e.KeyValue);
            //now check projectId
            //If projectId is less then or equal to zero then fatch data from Temp storage
            if (this.ProjectId <= 0)
            {
                List<ModuleEntity> moduleImages = this.ListModuleName;
                if (moduleImages != null)
                {
                    // Find Registry Item
                    var module = from modules in moduleImages
                                 where modules.ModuleId == this.ModuleId
                                 select modules;

                    if (module.First() != null)
                    {
                        txtModuleName.Text = module.First().ModuleName;
                    }

                }

                return;
            }

            //else fatch data from storage
            clsModule objModules = new clsModule(this.ModuleId);

            if (objModules.ModuleId <= 0) return;
            txtModuleName.Text = objModules.ModuleName;
            this.ModuleId = objModules.ModuleId;

        }

        /// <summary>
        /// Component gridview Rowcoomand events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvComponents_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            btnComponentDelete.Visible = true;
            this.ComponentID = Convert.ToInt64(e.KeyValue);
            //now check projectId
            //If projectId is less then or equal to zero then fatch data from Temp storage
            if (this.ProjectId <= 0)
            {
                List<ComponentEntiry> componentImages = this.ListComponentName;
                if (componentImages != null)
                {
                    // Find Registry Item
                    var comp = from modules in componentImages
                               where modules.ComponentId == this.ComponentID
                               select modules;

                    if (comp.First() != null)
                    {
                        txtComponentName.Text = comp.First().ComponentName;
                        ListEditItem objListItem = cmbModule.Items.FindByValue(Convert.ToString(comp.First().ModuleId));
                        if (objListItem != null)
                            objListItem.Selected = true;
                    }

                    //Select Components For this Module
                    clsComponent objComponent = new clsComponent();
                    gvComponents.DataSource = this.ListComponentName;
                    gvComponents.DataBind();
                }

                return;
            }

            clsComponent objComp = new clsComponent(this.ComponentID);

            txtComponentName.Text = objComp.ComponentName;
            this.ComponentID = objComp.ComponentId;
            ListEditItem objListCompItem = cmbModule.Items.FindByValue(Convert.ToString(objComp.ModuleId));
            if (objListCompItem != null)
                objListCompItem.Selected = true;
        }

        /// <summary>
        /// This event save/update project in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!IsValid) return;
            }
            //check validation 
            if (!ValidatePage())
            {
                return;
            }

            clsProject objProject = new clsProject();
            objProject.ProjectId = this.ProjectId;
            objProject.ProjectName = txtProjectName.Text.Trim();
            objProject.Owner = Convert.ToInt64(ddlProjectOwner.SelectedItem.Value);
            objProject.Description = txtProjectDescription.Text;
            objProject.DueDate = Convert.ToDateTime(txtDueDate.Text);
            objProject.Avatar = this.Avtar;
            objProject.CompanyName = txtCompanyName.Text.Trim();
            objProject.ProjectStatus = Convert.ToInt32(ProjectStatus.Open);
            objProject.CreatedBy = SessionData.UserId;
            objProject.Createddate = DateTime.Now;
            objProject.ModifiedBy = SessionData.UserId;
            objProject.ModifiedDate = DateTime.Now;

            if (ddlProjectClient.SelectedItem != null)
            {
                objProject.ClientId = Convert.ToInt64(ddlProjectClient.SelectedItem.Value);
            }
            else
            {
                objProject.ClientId = 0;
            }
            //Now check insert or update
            //If lessthen zero means Insert else update
            if (this.ProjectId <= 0)
            {
                //Insert in database
                this.ProjectId = objProject.Insert();

                //Insert Blank Entry For All Users For Project Viewing Entry.
                InsertProjectViewingRights();

                if (this.ProjectId <= 0)
                {   //Oops some error 
                    Helper.ShowMessage(ref lblStatus, " Project  not added", MessageType.Success);
                    return;
                }
                List<ModuleEntity> moduleListItem = this.ListModuleName;
                List<ComponentEntiry> componentItems = this.ListComponentName;
                if (moduleListItem != null)
                {
                    Helper objhelper = new Helper();
                    clsModule objModule = new clsModule();

                    // Some files are in tempeory storeage
                    foreach (ModuleEntity moduleName in moduleListItem)
                    {
                        // Move from temp to registry folder
                        // objhelper.MoveFaqImages(faqImage.ImageFileName);

                        // Save into database
                        objModule.ModuleName = moduleName.ModuleName;
                        objModule.ProjectId = this.ProjectId;
                        objModule.Createddate = moduleName.Createddate;
                        objModule.CreatedBy = SessionData.UserId;
                        objModule.ModifiedBy = SessionData.UserId;
                        objModule.ModifiedDate = moduleName.Createddate;
                        Int64 temp = objModule.Insert();


                        if (componentItems != null)
                        {
                            // Find Module Item
                            var compitem = from module in componentItems
                                           where module.ModuleId == moduleName.ModuleId
                                           select module;

                            if (compitem.First() != null)
                            {
                                foreach (var v in compitem)
                                { v.ModuleId = temp; }

                                this.ListComponentName = componentItems;
                            }
                        }

                    }
                }

                List<ComponentEntiry> compListItem = this.ListComponentName;
                if (compListItem != null)
                {
                    Helper objhelper = new Helper();
                    clsComponent objComp = new clsComponent();
                    // Some files are in tempeory storeage
                    foreach (ComponentEntiry comp in componentItems)
                    {
                        // Move from temp to registry folder
                        // objhelper.MoveFaqImages(faqImage.ImageFileName);

                        // Save into database
                        objComp.ComponentName = comp.ComponentName;
                        objComp.ModuleId = comp.ModuleId;
                        objComp.ProjectId = this.ProjectId;
                        objComp.CreatedDate = comp.CreatedDate;
                        objComp.CreatedBy = SessionData.UserId;
                        objComp.ModifiedBy = SessionData.UserId;
                        objComp.ModifiedDate = DateTime.Now;
                        objComp.Insert();
                    }
                }
                Helper.ShowMessage(ref lblStatus, " Project Added successfully", MessageType.Success);
                //clear all
                ClearAll();
                return;
            }

            //else update record
            objProject.Update();
            Response.Redirect("project-queue.aspx?s=update");
            //Helper.ShowMessage(ref lblStatus, " Project updated successfully", MessageType.Success);
            ////clear all
            //ClearAll();
            ////bye bye
            //return;

        }


        /// <summary>
        /// This event add/update component in database.
        /// </summary>
        protected void btnComponentAdd_Click(object sender, EventArgs e)
        {
            //If projectId is less then zero means insert module in temp storage
            //else store it in database
            btnComponentDelete.Visible = false;
            if (this.ProjectId <= 0)
            {
                // Faq is not saved to need to save temperory storage
                List<ComponentEntiry> componentImages = this.ListComponentName;
                if (this.ComponentID <= 0)
                {
                    if (componentImages == null)
                    {
                        componentImages = new List<ComponentEntiry>();
                    }

                    // Prepare the registry image item 
                    ComponentEntiry objComponentEntity = new ComponentEntiry();

                    objComponentEntity.ModuleId = Convert.ToInt64(cmbModule.SelectedItem.Value);
                    objComponentEntity.ComponentId = componentImages.Count + 1;
                    objComponentEntity.ComponentName = txtComponentName.Text.Trim();
                    objComponentEntity.CreatedDate = DateTime.Now;

                    componentImages.Add(objComponentEntity);
                    this.ListComponentName = componentImages;
                    Helper.ShowMessage(ref lblStatus, "Component added successfully", MessageType.Success);
                    BindModule();
                    BindComponent();
                    txtComponentName.Text = string.Empty;
                    cmbModule.SelectedIndex = 0;
                    this.ComponentID = 0;
                    return;
                }

                if (componentImages != null)
                {
                    // Find Registry Item
                    var moduleId = from module in componentImages
                                   where module.ComponentId == this.ComponentID
                                   select module;

                    if (moduleId.First() != null)
                    {

                        moduleId.First().ComponentName = txtComponentName.Text.Trim();
                        moduleId.First().ModuleId = Convert.ToInt64(cmbModule.SelectedItem.Value);
                        Helper.ShowMessage(ref lblStatus, "Component updated successfully", MessageType.Success);
                        BindComponent();
                        txtComponentName.Text = string.Empty;
                        cmbModule.SelectedIndex = 0;
                        this.ComponentID = 0;
                        return;

                    }

                }
            }

            //Now check componentId
            //If it is less then or equal to zero means user is adding New component
            //else user is updating component
            clsComponent objComponent = new clsComponent();

            objComponent.ProjectId = this.ProjectId;
            objComponent.ComponentId = this.ComponentID;
            objComponent.ModuleId = Convert.ToInt64(cmbModule.SelectedItem.Value);
            objComponent.ComponentName = txtComponentName.Text;
            objComponent.CreatedBy = SessionData.UserId;
            objComponent.CreatedDate = DateTime.Now;
            objComponent.ModifiedBy = SessionData.UserId;
            objComponent.ModifiedDate = DateTime.Now;


            //Insert module
            if (this.ComponentID <= 0)
            {
                //insert component in database
                objComponent.Insert();

                //successfully inserted
                Helper.ShowMessage(ref lblStatus, "Component added successfully", MessageType.Success);
                BindModule();
                BindComponent();
                txtComponentName.Text = string.Empty;
                cmbModule.SelectedIndex = 0;
                this.ComponentID = 0;
                return;
            }

            //Update module

            objComponent.Update();
            Helper.ShowMessage(ref lblStatus, "Component updated successfully", MessageType.Success);
            BindModule();
            BindComponent();
            txtComponentName.Text = string.Empty;
            cmbModule.SelectedIndex = 0;
            this.ComponentID = 0;


        }
        /// <summary>
        /// This event add/update module in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            //If projectId is less then zero means insert module in temp storage
            //else store it in database
            btnDeleteModule.Visible = false;
            //btnUpdateModule.Visible = false;
            if (this.ProjectId <= 0)
            {
                // Faq is not saved to need to save temperory storage
                List<ModuleEntity> moduleImages = this.ListModuleName;
                if (this.ModuleId <= 0)
                {


                    if (moduleImages == null)
                    {
                        moduleImages = new List<ModuleEntity>();
                    }

                    // Prepare the registry image item 
                    ModuleEntity objModuleEntity = new ModuleEntity();

                    objModuleEntity.ModuleId = moduleImages.Count + 1;
                    objModuleEntity.ModuleName = txtModuleName.Text.Trim();
                    objModuleEntity.Createddate = DateTime.Now;


                    moduleImages.Add(objModuleEntity);
                    this.ListModuleName = moduleImages;
                    Helper.ShowMessage(ref lblStatus, "Module added successfully", MessageType.Success);
                    BindModule();
                    txtModuleName.Text = string.Empty;

                    this.ModuleId = 0;
                    return;
                }


                if (moduleImages != null)
                {
                    // Find Registry Item
                    var moduleId = from module in moduleImages
                                   where module.ModuleId == this.ModuleId
                                   select module;

                    if (moduleId.First() != null)
                    {

                        moduleId.First().ModuleName = txtModuleName.Text;
                        Helper.ShowMessage(ref lblStatus, "Module updated successfully", MessageType.Success);
                        BindModule();
                        txtModuleName.Text = string.Empty;
                        this.ModuleId = 0;
                        return;


                    }

                }
            }

            //Now check moduleId
            //If it is less then or equal to zero means user is adding New module
            //else user is updating module

            clsModule objModule = new clsModule();
            objModule.ModuleId = this.ModuleId;
            objModule.ProjectId = this.ProjectId;
            objModule.ModuleName = txtModuleName.Text;
            objModule.CreatedBy = SessionData.UserId;
            objModule.Createddate = DateTime.Now;
            objModule.ModifiedBy = SessionData.UserId;
            objModule.ModifiedDate = DateTime.Now;

            //Insert module
            if (ModuleId <= 0)
            {
                //insert module in database
                if (objModule.Insert() <= 0)
                {
                    //oops module not inserted in database. there might be some error
                    Helper.ShowMessage(ref lblStatus, "Module not added", MessageType.Error);
                    return;
                }
                //successfully inserted
                Helper.ShowMessage(ref lblStatus, "Module added successfully", MessageType.Success);
                BindModule();
                txtModuleName.Text = string.Empty;
                this.ModuleId = 0;
                return;
            }

            //Update module

            objModule.Update();
            Helper.ShowMessage(ref lblStatus, "Module updated successfully", MessageType.Success);
            BindModule();
            txtModuleName.Text = string.Empty;
            this.ModuleId = 0;

        }

        /// <summary>
        /// This function Delete Component
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            //if projectId equal to zero means delete module from Temparary storage
            if (this.ProjectId <= 0)
            {
                List<ComponentEntiry> componentItems = this.ListComponentName;
                if (componentItems != null)
                {
                    // Find Module Item
                    var compitem = from module in componentItems
                                   where module.ComponentId == this.ComponentID
                                   select module;

                    if (compitem.First() != null)
                    {
                        componentItems.Remove(compitem.First());
                        this.ListComponentName = componentItems;
                        Helper.ShowMessage(ref lblStatus, "Component deleted successfully", MessageType.Success);
                        BindComponent();
                        txtComponentName.Text = string.Empty;
                        cmbModule.SelectedIndex = 0;
                        this.ComponentID = 0;

                        btnComponentDelete.Visible = false;

                        return;
                    }
                }
            }

            //Delete from database
            clsComponent objComp = new clsComponent();
            objComp.ComponentId = this.ComponentID;
            //delete it
            string msg = objComp.Delete();
            if (string.IsNullOrEmpty(msg))
            {
                Helper.ShowMessage(ref lblStatus, "Component deleted successfully", MessageType.Success);
                BindComponent();
                txtComponentName.Text = string.Empty;
                cmbModule.SelectedIndex = 0;
                this.ComponentID = 0;
                btnComponentDelete.Visible = false;
                return;
            }

            Helper.ShowMessage(ref lblStatus, "Sorry, Task is also associated with this Component so, you can not delete it.", MessageType.Error);
            return;

        }

        /// <summary>
        /// This function Update module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateModule_Click(object sender, EventArgs e)
        {
            //if projectId equal to zero means Update module To Temparary storage
            if (this.ProjectId <= 0)
            {
                List<ModuleEntity> moduleItems = this.ListModuleName;
                if (moduleItems != null)
                {
                    // Find Module Item
                    var moduleitem = from module in moduleItems
                                     where module.ModuleId == this.ModuleId
                                     select module;

                    if (moduleitem.First() != null)
                    {
                        moduleitem.First().ModuleName = txtModuleName.Text.Trim();
                        //  moduleItems.Remove(moduleitem.First());
                        this.ListModuleName = moduleItems;
                        Helper.ShowMessage(ref lblStatus, "Module Updated successfully", MessageType.Success);
                        BindModule();
                        txtModuleName.Text = string.Empty;
                        this.ModuleId = 0;

                        //btnUpdateModule.Visible = false;
                        btnDeleteModule.Visible = false;
                        return;
                    }
                }
            }

            //Update To database
            clsModule objModules = new clsModule();
            objModules.ModuleId = this.ModuleId;
            objModules.ModuleName = txtModuleName.Text.Trim();
            objModules.ProjectId = this.ProjectId;
            objModules.ModifiedBy = SessionData.UserId;
            objModules.ModifiedDate = DateTime.Now; 
        
            //Update Module
            objModules.Update(); 
        
            Helper.ShowMessage(ref lblStatus, "Module Updated successfully", MessageType.Success);
            BindModule();
            txtModuleName.Text = string.Empty;
            this.ModuleId = 0;
            btnDeleteModule.Visible = false;
            //btnUpdateModule.Visible = false;
            return;
        }
        /// <summary>
        /// This function delete module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteModule_Click(object sender, EventArgs e)
        {
            //if projectId equal to zero means delete module from Temparary storage
            if (this.ProjectId <= 0)
            {
                List<ModuleEntity> moduleItems = this.ListModuleName;
                if (moduleItems != null)
                {
                    // Find Module Item
                    var moduleitem = from module in moduleItems
                                     where module.ModuleId == this.ModuleId
                                     select module;

                    if (moduleitem.First() != null)
                    {
                        moduleItems.Remove(moduleitem.First());
                        this.ListModuleName = moduleItems;
                        Helper.ShowMessage(ref lblStatus, "Module deleted successfully", MessageType.Success);
                        BindModule();
                        txtModuleName.Text = string.Empty;
                        this.ModuleId = 0;

                        btnDeleteModule.Visible = false;

                        return;
                    }
                }
            }

            //Delete from database
            clsModule objModules = new clsModule();
            objModules.ModuleId = this.ModuleId;
            //delete it
            string msg = objModules.Delete();
            if (string.IsNullOrEmpty(msg))
            {
                Helper.ShowMessage(ref lblStatus, "Module deleted successfully", MessageType.Success);
                BindModule();
                txtModuleName.Text = string.Empty;
                this.ModuleId = 0;
                btnDeleteModule.Visible = false;
                return;
            }


            Helper.ShowMessage(ref lblStatus, "Sorry, Component is also associated with this module so, you can not delete it.", MessageType.Error);
            return;

        }
        /// <summary>
        /// this function upload avtar image of project in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Save file
            if (SaveFile())
            { Helper.ShowMessage(ref lblStatus, "Image uploaded successfully", MessageType.Success); }
            FileStatus();

        }
        #endregion

        #region Methode
        /// <summary>
        /// Bind Page Detail
        /// </summary>
        private void BindPage()
        {
            PageStatus();
            FillDdlProjectOwner();
            FillDdlProjectClient();
            BindModule();
            BindComponent();
            BindProject();
            spanAvtarvalidation.InnerText = "Project Avtar Image must be " + AppSetting.ProjectImageWidth + " pixels in width by " + AppSetting.ProjectImageHeight + " pixels in height";
        }


        /// <summary>
        /// set page status
        /// </summary>
        private void PageStatus()
        {
            if (string.IsNullOrEmpty(Request.QueryString["ProjectId"]))
            {
                spanHeading.InnerText = "Project Creator";
                Page.Title = "Project Creator | Project Task Manager";
                return;
            }

            spanHeading.InnerText = "Project Editor";
            Page.Title = "Project Editor | Project Task Manager";
            this.ProjectId = Convert.ToInt64(Request.QueryString["ProjectId"]);
            return;

        }

        /// <summary>
        /// Insert Project Vieing Rights Entry For this Project For Each of the User
        /// By Default View Permission is Set to Flase.
        /// </summary>
        public void InsertProjectViewingRights()
        {
            //Create Object of User and Select All the User.
            clsUsers objUsers = new clsUsers();
            DataSet ds = objUsers.SelectAll(0);

            //Create Object of ProjectRights Class.
            clsProjectRight objProjectRights = new clsProjectRight();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //For each Users in the System Insert the Blank Entry Of this Project,and Set viweing Rights to False.s
                objProjectRights.ProjectID = this.ProjectId;
                objProjectRights.UserID = Convert.ToInt64(dr["UserId"]);
                objProjectRights.View = false;
                objProjectRights.CreatedBy = SessionData.UserId;
                objProjectRights.CreatedDate = DateTime.Now;
                objProjectRights.ModifiedBy = SessionData.UserId;
                objProjectRights.ModifiedDate = DateTime.Now;
                objProjectRights.IsActive = true;

                clsUsers objUsersRole = new clsUsers(Convert.ToInt64(dr["UserId"]));
                if (objUsersRole.RoleId == (int)Roles.SuperAdmin)
                {
                    objProjectRights.View = true;
                }
                if (Convert.ToInt64(ddlProjectOwner.SelectedItem.Value) == Convert.ToInt64(dr["UserID"]))
                {
                    objProjectRights.View = true;
                }

                if (ddlProjectClient.SelectedItem != null)
                {
                if (Convert.ToInt64(ddlProjectClient.SelectedItem.Value) != 0 && Convert.ToInt64(ddlProjectClient.SelectedItem.Value) == Convert.ToInt64(dr["UserID"]))
                {
                    objProjectRights.View = true;
                }
                }

                //Insert the Record
                objProjectRights.Insert();
            }
        }
        /// <summary>
        /// Validate the page before saving into database 
        /// </summary>
        /// <returns>true if ok else send false</returns>
        private bool ValidatePage()
        {
            System.Text.StringBuilder sbValidation = new System.Text.StringBuilder();
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                sbValidation.Append("- Project name cannot be left blank<br>");
            }
            if (string.IsNullOrEmpty(txtProjectDescription.Text))
            {
                sbValidation.Append("- Project description cannot be left blank<br>");
            }
            if (string.IsNullOrEmpty(txtDueDate.Text))
            {
                sbValidation.Append("- Due date cannot be left blank<br>");

            }
            if (Convert.ToDateTime(txtDueDate.Text) < DateTime.Today)
            {
                sbValidation.Append("- Due date cannot be less then currentDate<br>");
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                sbValidation.Append("- Company name cannot be left blank<br>");
            }

            if (Convert.ToString(ddlProjectOwner.SelectedItem) == AppSetting.ProjectOwner)
            {
                sbValidation.Append("- Project Owner cannot be left blank<br>");
            }

            if (sbValidation.Length > 0)
            {
                Helper.ShowMessage(ref lblStatus, "Please correct following errors: <br>" + sbValidation.ToString(), MessageType.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// This function clear all textfield and view states
        /// </summary>
        private void ClearAll()
        {
            this.ProjectId = 0;
            this.Avtar = null;
            txtProjectName.Text = string.Empty;
            txtProjectDescription.Text = string.Empty;
            txtDueDate.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            spanProjectNumber.InnerText = string.Empty;
            ddlProjectOwner.SelectedItem = ddlProjectOwner.Items.FindByValue(AppSetting.ProjectOwner);
            FileStatus();
            this.ModuleId = 0;
            this.ListModuleName = null;
            this.ListComponentName = null;
            btnDeleteModule.Visible = false;
            BindModule();
            BindComponent();
        }

        /// <summary>
        /// This function fill projectowner Dropdownlist
        /// </summary>
        private void FillDdlProjectOwner()
        {
            Common objCommon = new Common();
            objCommon.FillProjectOwner(ddlProjectOwner, true);
        }
        /// <summary>
        /// This function fill projectclient Dropdownlist
        /// </summary>
        private void FillDdlProjectClient()
        {
            Common objCommon = new Common();
            objCommon.FillProjectClient(ddlProjectClient, true);
        }

        /// <summary>
        /// Bind Component Grid.
        /// </summary>
        private void BindComponent()
        {
            //Select all the component From tempoirary storage.
            if (this.ProjectId <= 0)
            {
                gvComponents.DataSource = this.ListComponentName;
                gvComponents.DataBind();
                if (gvComponents.VisibleRowCount <= 0)
                {
                    gvComponents.Visible = false;
                    return;
                }
                gvComponents.Visible = true;
                return;
            }

            //Select all the Component Form Database.
            clsComponent objComponent = new clsComponent();
            gvComponents.DataSource = objComponent.SelectAllByProject(this.ProjectId);
            gvComponents.DataBind();
            if (gvComponents.VisibleRowCount <= 0)
            {
                gvComponents.Visible = false;
                return;
            }
            gvComponents.Visible = true;
            return;
        }
        /// <summary>
        /// Bind module 
        /// </summary>
        private void BindModule()
        {
            //Bind from temp storage
            if (this.ProjectId <= 0)
            {
                cmbModule.DataSource = gvModules.DataSource = this.ListModuleName;
                gvModules.DataBind();

                cmbModule.TextField = "ModuleName";
                cmbModule.ValueField = "ModuleId";
                cmbModule.DataBind();
                // Add the select state item
                cmbModule.Items.Insert(0, new ListEditItem("Select Component", "0"));

                cmbModule.SelectedIndex = 0;
                if (gvModules.VisibleRowCount <= 0)
                {
                    gvModules.Visible = false;
                    return;
                }
                gvModules.Visible = true;
                return;
            }

            //Bind from database
            clsModule objModule = new clsModule();

            cmbModule.DataSource = gvModules.DataSource = objModule.SelectAllByProjectId(this.ProjectId);
            cmbModule.TextField = "ModuleName";
            cmbModule.ValueField = "ModuleId";

            cmbModule.DataBind();
            // Add the select state item
            cmbModule.Items.Insert(0, new ListEditItem("Select Component", "0"));

            cmbModule.SelectedIndex = 0;
            gvModules.DataBind();
            if (gvModules.VisibleRowCount <= 0)
            {
                gvModules.Visible = false;
                return;
            }
            gvModules.Visible = true;
            return;

        }

        /// <summary>
        /// Bind module for pagging.
        /// </summary>
        private void BindModulePagging()
        {
            if (this.ProjectId <= 0)
            {
                gvModules.DataSource = this.ListModuleName;
                return;

            }

            //Bind from database
            clsModule objModule = new clsModule();
            gvModules.DataSource = objModule.SelectAllByProjectId(this.ProjectId);
        }

        private bool SaveFile()
        {
            // Make sure file is there
            if (!filelAvatorImage.HasFile)
            {
                lblStatus.Visible = true;
                Helper.ShowMessage(ref lblStatus, "Select file to upload", MessageType.Error);
                return false;
            }

            // Be sure correct extention is there
            string fileExtention = Path.GetExtension(filelAvatorImage.UploadedFiles[0].FileName).ToLower();

            if (!AppSetting.ProjectImageSupportedFormat.ToLower().Contains(fileExtention))
            {
                lblStatus.Visible = true;
                Helper.ShowMessage(ref lblStatus, "Invalid file format. Supported format:" + AppSetting.ProjectImageSupportedFormat, MessageType.Error);
                return false;
            }



            // Generate file name
            string originalfileName = filelAvatorImage.UploadedFiles[0].FileName;
            string fileName = Helper.GetFileName(fileExtention);
            string filePath = Helper.GetProjectImageFile(fileName, true);

            // Save the file
            filelAvatorImage.UploadedFiles[0].SaveAs(filePath);

            //System.Drawing.Image image = System.Drawing.Image.FromFile(Helper.GetProjectImageFile(fileName, true));

            //if (image.Width > AppSetting.ProjectImageWidth || image.Height > AppSetting.ProjectImageHeight)
            //{
            //    Helper objHelper = new Helper(); 
            //    Helper.ShowMessage(ref lblStatus, "Width and height of uploaded image is " + image.Width + " * " + image.Height + " Please,Upload image with a width of " + AppSetting.ProjectImageWidth + "  pixels and a height of " + AppSetting.ProjectImageHeight + " pixels. ", MessageType.Error);
            //    image.Dispose();
            //    objHelper.DeleteProjectImages(fileName);
            //    return false;
            //}

            //Now delete old image
            DeleteAvatorImage();

            //assign new avtar image
            this.Avtar = fileName;
            return true;
        }

        /// <summary>
        /// This function Bind project detail
        /// </summary>
        private void BindProject()
        {
            clsProject objProject = new clsProject();
            if (this.ProjectId <= 0)
            {
                spanProjectNumber.InnerText = objProject.SelectMaxProjectId();
                this.Avtar = null;
                FileStatus();
                return;
            }
            objProject = new clsProject(this.ProjectId);
            spanProjectNumber.InnerText = Convert.ToString(objProject.ProjectId);
            txtProjectName.Text = objProject.ProjectName;
            ddlProjectOwner.SelectedItem = ddlProjectOwner.Items.FindByValue(Convert.ToString(objProject.Owner));
            ddlProjectClient.SelectedItem = ddlProjectClient.Items.FindByValue(Convert.ToString(objProject.ClientId));
            txtProjectDescription.Text = objProject.Description;
            txtDueDate.Text = objProject.DueDate.ToShortDateString();
            txtCompanyName.Text = objProject.CompanyName;
            this.Avtar = objProject.Avatar;
            FileStatus();

        }

        /// <summary>
        /// Set upload file status
        /// </summary>
        private void FileStatus()
        {
            if (string.IsNullOrEmpty(this.Avtar))
            {
                lblFileStatus.Text = "[No File Uploaded]";
                lblFileStatus.CssClass = "red-color";
                imgAvtar.Visible = false;
                lnkAvtarImageDelete.Visible = false;
                return;
            }
            lblFileStatus.Text = string.Empty;
            //lblFileStatus.CssClass = "grey-color";
            imgAvtar.Visible = true;
            lnkAvtarImageDelete.Visible = true;
            imgAvtar.Src = Helper.GetProjectImageFile(this.Avtar, false);
        }
        /// <summary>
        /// This function delete avtar image from storage
        /// </summary>
        private void DeleteAvatorImage()
        {
            if (string.IsNullOrEmpty(this.Avtar)) return;
            Helper objHelper = new Helper();
            objHelper.DeleteProjectImages(this.Avtar);
            this.Avtar = null;
        }
        #endregion
    }
}