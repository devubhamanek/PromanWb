using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace Proman.BLL
{
    public sealed class ProjectLoginCredential
    {

        Proman.DAL.clsProjectLoginCredential ObjProjectLoginCredential = new Proman.DAL.clsProjectLoginCredential();

        #region Fields
        private Int64 loginCredentialID;
        private Int64 projectId;
        private Int64 moduleId;
        private string loginUrl;
        private string userName;
        private string password;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool isActive;
        private string serverType;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ProjectLoginCredential class.
        /// </summary>
        public ProjectLoginCredential()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProjectLoginCredential class.
        /// </summary>
        public ProjectLoginCredential(Int64 loginCredentialID, Int64 projectId, Int64 moduleId, string loginUrl, string userName, string password, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.loginCredentialID = loginCredentialID;
            this.projectId = projectId;
            this.moduleId = moduleId;
            this.loginUrl = loginUrl;
            this.userName = userName;
            this.password = password;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the LoginCredentialID value.
        /// </summary>
        public Int64 LoginCredentialID
        {
            get { return loginCredentialID; }
            set { loginCredentialID = value; }
        }

        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public Int64 ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        /// <summary>
        /// Gets or sets the ModuleId value.
        /// </summary>
        public Int64 ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        /// <summary>
        /// Gets or sets the ModuleId value.
        /// </summary>
        public string ServerType
        {
            get { return serverType; }
            set { serverType = value; }
        }


        /// <summary>
        /// Gets or sets the LoginUrl value.
        /// </summary>
        public string LoginUrl
        {
            get { return loginUrl; }
            set { loginUrl = value; }
        }

        /// <summary>
        /// Gets or sets the UserName value.
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Gets or sets the Password value.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public Int64 CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets or sets the Createddate value.
        /// </summary>
        public DateTime Createddate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedBy value.
        /// </summary>
        public Int64 ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedDate value.
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        /// <summary>
        /// Gets or sets the IsActive value.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the ProjectLoginCredential table.
        /// </summary>
        public void Insert()
        {
            ObjProjectLoginCredential.Insert(projectId, moduleId, loginUrl, userName, password, createdBy, createddate, modifiedBy, modifiedDate, isActive,serverType);
        }

        /// <summary>
        /// Updates a record in the ProjectLoginCredential table.
        /// </summary>
        public void Update()
        {
            ObjProjectLoginCredential.Update(loginCredentialID, projectId, moduleId, loginUrl, userName, password, createdBy, createddate, modifiedBy, modifiedDate, isActive,serverType);
        }

        /// <summary>
        /// Deletes a record from the ProjectLoginCredential table by its primary key.
        /// </summary>
        public void Delete()
        {
            ObjProjectLoginCredential.Delete(loginCredentialID);
        }

        /// <summary>
        /// Deletes a record from the ProjectLoginCredential table by a foreign key.
        /// </summary>
        public void DeleteAllByProjectId(Int64 projectId)
        {
            ObjProjectLoginCredential.DeleteByProjectId(projectId);
        }

        /// <summary>
        /// Deletes a record from the ProjectLoginCredential table by a foreign key.
        /// </summary>
        public void DeleteAllByModuleId(Int64 moduleId)
        {
            ObjProjectLoginCredential.DeleteByModuleId(moduleId);
        }

        /// <summary>
        /// Selects a single record from the ProjectLoginCredential table.
        /// </summary>
        public DataSet Select(Int64 loginCredentialID)
        {
            return ObjProjectLoginCredential.Select(loginCredentialID);
        }

        /// <summary>
        /// Selects all records from the ProjectLoginCredential table.
        /// </summary>
        public DataSet SelectAll()
        {
            return ObjProjectLoginCredential.SelectAll();
        }

        /// <summary>
        /// Selects all records from the ProjectLoginCredential table by a foreign key.
        /// </summary>
        public DataSet SelectAllByProjectId(Int64 projectId)
        {
            return ObjProjectLoginCredential.SelectByProjectId(projectId);
        }

        /// <summary>
        /// Selects all records from the ProjectLoginCredential table by a foreign key.
        /// </summary>
        public DataSet SelectAllByModuleId(Int64 moduleId)
        {
            return ObjProjectLoginCredential.SelectByModuleId(moduleId);
        }

        /// <summary>
        /// Creates a new instance of the ProjectLoginCredential class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeProjectLoginCredential(DataSet ds)
        {
            ProjectLoginCredential projectLoginCredential = new ProjectLoginCredential();

            if (ds.Tables[0].Rows[0]["LoginCredentialID"] != null)
            {
                this.LoginCredentialID = Convert.ToInt64(ds.Tables[0].Rows[0]["LoginCredentialID"]);
            }
             if (ds.Tables[0].Rows[0]["ProjectId"] != null)
            {
                this.ProjectId = Convert.ToInt64(ds.Tables[0].Rows[0]["ProjectId"]);
            }
            if (ds.Tables[0].Rows[0]["ModuleId"] != null)
            {
                this.ModuleId = Convert.ToInt64(ds.Tables[0].Rows[0]["ModuleId"]);
            }
            if (ds.Tables[0].Rows[0]["LoginUrl"] != null)
            {
                this.LoginUrl = Convert.ToString(ds.Tables[0].Rows[0]["LoginUrl"]);
            }
            if (ds.Tables[0].Rows[0]["UserName"] != null)
            {
                this.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            }
            if (ds.Tables[0].Rows[0]["Password"] != null)
            {
                this.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
            }

            if (ds.Tables[0].Rows[0]["CreatedBy"] != null)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["Createddate"] != null)
            {
                this.Createddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Createddate"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedBy"] != null)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedDate"] != null)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }
            if (ds.Tables[0].Rows[0]["IsActive"] != null)
            {
                this.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
            }
        }
        #endregion
    }
}