using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Proman.BLL
{
    public sealed class UserActivityRole
    {
        Proman.DAL.UserActivityRole ObjUserActivity = new Proman.DAL.UserActivityRole();

        #region Fields
        private Int64 userID;
        private Int64 activityID;
        private bool view;
        private Int64 createdBy;
        private DateTime createdDate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool isActive;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the UserActivityRole class.
        /// </summary>
        public UserActivityRole()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserActivityRole class.
        /// </summary>
        public UserActivityRole(Int64 userID, Int64 activityID, bool view, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.userID = userID;
            this.activityID = activityID;
            this.view = view;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the UserID value.
        /// </summary>
        public Int64 UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Gets or sets the ActivityID value.
        /// </summary>
        public Int64 ActivityID
        {
            get { return activityID; }
            set { activityID = value; }
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
        /// Saves a record to the UserActivityRole table.
        /// </summary>
        public void Insert()
        {
            ObjUserActivity.Insert(userID, activityID, view, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Deletes a record from the UserActivityRole table by a foreign key.
        /// </summary>
        public void DeleteAllByUserID(Int64 userID)
        {
            ObjUserActivity.DeleteByUserID(userID);
        }

        /// <summary>
        /// Selects all records from the UserActivityRole table.
        /// </summary>
        public DataSet SelectAll()
        {
            return ObjUserActivity.SelectAll();
        }

        /// <summary>
        /// Selects all records from the UserActivityRole table by a foreign key.
        /// </summary>
        public DataSet SelectAllByUserID(Int64 userID)
        {
            return ObjUserActivity.SelectByUserID(userID);
        }

        /// <summary>
        /// Creates a new instance of the UserActivityRole class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeUserActivityRole(DataSet ds)
        {
            UserActivityRole userActivityRole = new UserActivityRole();

            if (ds.Tables[0].Rows[0]["UserID"] != null)
            {
                this.UserID = Convert.ToInt64(ds.Tables[0].Rows[0]["UserID"]);
            }
            if (ds.Tables[0].Rows[0]["ActivityID"] != null)
            {
                this.ActivityID = Convert.ToInt64(ds.Tables[0].Rows[0]["ActivityID"]);
            }
            if (ds.Tables[0].Rows[0]["View"] != null)
            {
                this.View = Convert.ToBoolean(ds.Tables[0].Rows[0]["View"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedBy"] != null)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedDate"] != null)
            {
                this.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
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
