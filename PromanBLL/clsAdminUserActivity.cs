using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Proman.BLL
{
    public sealed class clsAdminUserActivity
    {
        Proman.DAL.clsAdminUserActivity objObjUserActivity = new Proman.DAL.clsAdminUserActivity();

        #region Fields
        private Int64 activityID;
        private Int64 userID;
        private string activityName;
        private string activityLink;
        private bool view;
        private bool edit;
        private bool delete;
        private Int64 createdBy;
        private DateTime createdDate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool isActive;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the AdminUserActivity class.
        /// </summary>
        public clsAdminUserActivity()
        {
        }

        public clsAdminUserActivity(Int64 activityID)
        {
            MakeAdminUser(Select(activityID));
        }

        /// <summary>
        /// Initializes a new instance of the AdminUserActivity class.
        /// </summary>
        public clsAdminUserActivity(Int64 userID, string activityName, string activityLink, bool view, bool edit, bool delete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.userID = userID;
            this.activityName = activityName;
            this.activityLink = activityLink;
            this.view = view;
            this.edit = edit;
            this.delete = delete;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }

        /// <summary>
        /// Initializes a new instance of the AdminUserActivity class.
        /// </summary>
        public clsAdminUserActivity(Int64 activityID, Int64 userID, string activityName, string activityLink, bool view, bool edit, bool delete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.activityID = activityID;
            this.userID = userID;
            this.activityName = activityName;
            this.activityLink = activityLink;
            this.view = view;
            this.edit = edit;
            this.delete = delete;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ActivityID value.
        /// </summary>
        public Int64 ActivityID
        {
            get { return activityID; }
            set { activityID = value; }
        }

        /// <summary>
        /// Gets or sets the UserID value.
        /// </summary>
        public Int64 UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Gets or sets the ActivityName value.
        /// </summary>
        public string ActivityName
        {
            get { return activityName; }
            set { activityName = value; }
        }

        /// <summary>
        /// Gets or sets the ActivityLink value.
        /// </summary>
        public string ActivityLink
        {
            get { return activityLink; }
            set { activityLink = value; }
        }

        /// <summary>
        /// Gets or sets the View value.
        /// </summary>
        public bool View
        {
            get { return view; }
            set { view = value; }
        }

        /// <summary>
        /// Gets or sets the Edit value.
        /// </summary>
        public bool Edit
        {
            get { return edit; }
            set { edit = value; }
        }

        /// <summary>
        /// Gets or sets the Delete value.
        /// </summary>
        public bool Delete
        {
            get { return delete; }
            set { delete = value; }
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
        /// Gets or sets the CreatedDate value.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
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
        /// Saves a record to the AdminUserActivity table.
        /// </summary>
        public Int64 Insert()
        {
            return objObjUserActivity.Insert(activityName, activityLink, createdBy, createdDate, modifiedBy, modifiedDate, isActive);

        }

        /// <summary>
        /// Updates a record in the AdminUserActivity table.
        /// </summary>
        public void Update()
        {
            objObjUserActivity.Update(activityID, activityName, activityLink,createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Deletes a record from the AdminUserActivity table by its primary key.
        /// </summary>
        public void Delete1()
        {
            objObjUserActivity.Delete1(activityID);
        }

        /// <summary>
        /// Selects a single record from the AdminUserActivity table.
        /// </summary>
        public DataSet Select(Int64 activityID)
        {
            return objObjUserActivity.Select(activityID);
        }

        /// <summary>
        /// Selects all records from the AdminUserActivity table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objObjUserActivity.SelectAll();

        }

        /// <summary>
        /// Check Already Existed Activity Wityh Same Name.
        /// </summary>
        public bool CheckExistsActivity(string activityName,Int64 activityID)
        {
            return objObjUserActivity.CheckExistsActivity( activityName,activityID);
        }

        /// <summary>
        /// Creates a new instance of the AdminUser class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeAdminUser(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["ActivityID"] != DBNull.Value)
            {
                this.ActivityID = Convert.ToInt64(ds.Tables[0].Rows[0]["ActivityID"]);
            }

            if (ds.Tables[0].Rows[0]["ActivityName"] != DBNull.Value)
            {
                this.ActivityName = Convert.ToString(ds.Tables[0].Rows[0]["ActivityName"]);
            }
            if (ds.Tables[0].Rows[0]["ActivityLink"] != DBNull.Value)
            {
                this.ActivityLink = Convert.ToString(ds.Tables[0].Rows[0]["ActivityLink"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["Createddate"] != DBNull.Value)
            {
                this.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Createddate"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }
            if (ds.Tables[0].Rows[0]["IsActive"] != DBNull.Value)
            {
                this.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
            }
        }
        #endregion
    }
}
