using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;



namespace Proman.BLL
{
    public sealed class clsProject
    {
        #region Fields
        DAL.clsProject objProject = new DAL.clsProject();
        private Int64 projectId;
        private string projectName;
        private Int64 owner;
        private Int64 clientId;
        private string description;
        private DateTime dueDate;
        private string avatar;
        private string companyName;
        private int projectStatus;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private string managerUserName;


        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Project class.
        /// </summary>
        public clsProject()
        {
        }

        public clsProject(Int64 projectId)
        {
            MakeProject(Select(projectId));
        }

        /// <summary>
        /// Initializes a new instance of the Project class.
        /// </summary>
        public clsProject(string projectName, Int64 owner, Int64 clientId, string description, DateTime dueDate, string avatar, string companyName, int projectStatus, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.projectName = projectName;
            this.owner = owner;
            this.description = description;
            this.dueDate = dueDate;
            this.avatar = avatar;
            this.companyName = companyName;
            this.projectStatus = projectStatus;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.clientId = clientId;
        }

        /// <summary>
        /// Initializes a new instance of the Project class.
        /// </summary>
        public clsProject(Int64 projectId, string projectName, Int64 owner, Int64 clientId, string description, DateTime dueDate, string avatar, string companyName, int projectStatus, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.projectId = projectId;
            this.projectName = projectName;
            this.owner = owner;
            this.description = description;
            this.dueDate = dueDate;
            this.avatar = avatar;
            this.companyName = companyName;
            this.projectStatus = projectStatus;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.clientId = clientId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public Int64 ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        /// <summary>
        /// Gets or sets the ProjectName value.
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public string ManagerUserName
        {
            get { return managerUserName ; }
            set { managerUserName = value; }
        }
        /// <summary>
        /// Gets or sets the Owner value.
        /// </summary>
        public Int64 Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        /// <summary>
        /// Get or set ClientID
        /// </summary>
        public Int64 ClientId
        {
            get
            { return clientId; }
            set
            { clientId = value; }
        }
        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Gets or sets the DueDate value.
        /// </summary>
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        /// <summary>
        /// Gets or sets the Avatar value.
        /// </summary>
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        /// <summary>
        /// Gets or sets the CompanyName value.
        /// </summary>
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        /// <summary>
        /// Gets or sets the ProjectStatus value.
        /// </summary>
        public int ProjectStatus
        {
            get { return projectStatus; }
            set { projectStatus = value; }
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
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the Project table.
        /// </summary>
        public Int64 Insert()
        {
            return objProject.Insert(projectName, owner, clientId, description, dueDate, avatar, companyName, projectStatus, createdBy, createddate, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Updates a record in the Project table.
        /// </summary>
        public void Update()
        {
            objProject.Update(projectId, projectName, owner, clientId, description, dueDate, avatar, companyName, projectStatus, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Update Project avator image
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="avator"></param>
        public void UpdateProjectAvatorImage(Int64 projectId, string avator)
        {
            objProject.UpdateProjectAvatorImage(projectId, avator);
        }

        /// <summary>
        /// Deletes a record from the Project table by its primary key.
        /// </summary>
        public void Delete()
        {
            objProject.Delete(projectId);
        }

        public void DeleteProjectWhole(Int64 projectID)
        {
            objProject.DeleteProjectWhole(projectID);
        }

        /// <summary>
        /// Deletes a record from the Project table by a foreign key.
        /// </summary>
        public void DeleteAllByOwner(Int64 owner)
        {
            objProject.DeleteByOwner(owner);
        }

        /// <summary>
        /// Selects a single record from the Project table.
        /// </summary>
        public DataSet Select(Int64 projectId)
        {
            return objProject.Select(projectId);
        }

        /// <summary>
        /// Selects a single record from the Project table by project and user id
        /// <summary>
        public DataSet SelectByProjectIdAndUserId(Int64 userId, Int64 projectId)
        {
            return objProject.SelectByProjectIdAndUserId(userId, projectId);
        }

        /// <summary>
        /// Deletes a record from the Project table by a composite primary key.
        /// <summary>
        public void DeleteManual(Int64 projectId)
        {
            objProject.DeleteManual(projectId);
        }

        /// <summary>
        /// Selects a single record from the Project table by user id
        /// <summary>
        public DataSet ProjectSelectByUserId(Int64 userId,bool isClosed)
        {
            return objProject.ProjectSelectByUserId(userId,isClosed);
        }

        /// <summary>
        /// Selectsmodule wise status from the Project table.
        /// <summary>
        public DataSet SelectByModuleStatus(Int64 projectId)
        {
            return objProject.SelectByModuleStatus(projectId);
        }


        /// <summary>
        /// Selectsmodule wise status from the Project table.
        /// <summary>
        public DataSet SelectByComponentStatus(Int64 projectId,Int64 moduleId)
        {
            return objProject.SelectByComponentStatus(projectId, moduleId);
        }

        /// <summary>
        /// Selects all records from the Project table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objProject.SelectAll();
        }
        /// <summary>
        /// Selects all Project Name from the Project table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet ProjectNameSelectByUserId(Int64 userId, Int64 roleId)
        {
            return objProject.ProjectNameSelectByUserId(userId, roleId);
        }
        /// <summary>
        /// Selects all records from the Project table by a foreign key.
        /// </summary>
        public DataSet SelectAllByOwner(Int64 owner)
        {
            return objProject.SelectByOwner(owner);
        }

        /// <summary>
        /// Creates a new instance of the Project class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeProject(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;
            if (ds.Tables[0].Rows[0]["ClientId"] != DBNull.Value)
            {
                this.ClientId = Convert.ToInt64(ds.Tables[0].Rows[0]["ClientId"]);
            }
            if (ds.Tables[0].Rows[0]["ProjectId"] != DBNull.Value)
            {
                this.ProjectId = Convert.ToInt64(ds.Tables[0].Rows[0]["ProjectId"]);
            }
            if (ds.Tables[0].Rows[0]["ProjectName"] != DBNull.Value)
            {
                this.ProjectName = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
            }
            if (ds.Tables[0].Rows[0]["Owner"] != DBNull.Value)
            {
                this.Owner = Convert.ToInt64(ds.Tables[0].Rows[0]["Owner"]);
            }
            if (ds.Tables[0].Rows[0]["Description"] != DBNull.Value)
            {
                this.Description = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
            }
            if (ds.Tables[0].Rows[0]["DueDate"] != DBNull.Value)
            {
                this.DueDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
            }
            if (ds.Tables[0].Rows[0]["Avatar"] != DBNull.Value)
            {
                this.Avatar = Convert.ToString(ds.Tables[0].Rows[0]["Avatar"]);
            }
            if (ds.Tables[0].Rows[0]["CompanyName"] != DBNull.Value)
            {
                this.CompanyName = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
            }
            if (ds.Tables[0].Rows[0]["ManagerUserName"] != DBNull.Value)
            {
                this.ManagerUserName = Convert.ToString(ds.Tables[0].Rows[0]["ManagerUserName"]);
            }
            if (ds.Tables[0].Rows[0]["ProjectStatus"] != DBNull.Value)
            {
                this.ProjectStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectStatus"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["Createddate"] != DBNull.Value)
            {
                this.Createddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Createddate"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }
        }

        public string SelectMaxProjectId()
        {
            return objProject.SelectMaxProjectId();
        }
        #endregion
    }
}
