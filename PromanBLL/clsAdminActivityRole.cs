using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman.DAL;

namespace Proman.BLL
{
    public sealed class clsAdminActivityRole
    {
        Proman.DAL.clsAdminActivityRole objActivityRole = new DAL.clsAdminActivityRole();
        #region Fields
        private Int64 roleID;
        private Int64 activityID;
        private bool view;
        private bool insert1;
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
        /// Initializes a new instance of the AdminActivityRole class.
        /// </summary>
        public clsAdminActivityRole()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AdminActivityRole class.
        /// </summary>
        public clsAdminActivityRole(Int64 roleID, Int64 activityID, bool view, bool insert, bool edit, bool delete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.roleID = roleID;
            this.activityID = activityID;
            this.view = view;
            this.insert1 = insert;
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
        /// Gets or sets the RoleID value.
        /// </summary>
        public Int64 RoleID
        {
            get { return roleID; }
            set { roleID = value; }
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
        /// Gets or sets the Insert value.
        /// </summary>
        public bool Insert1
        {
            get { return insert1; }
            set { insert1 = value; }
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
        /// Saves a record to the AdminActivityRole table.
        /// </summary>
        public void Insert()
        {
            objActivityRole.Insert(roleID, activityID, view, insert1, edit, delete, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Selects all records from the AdminActivityRole table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objActivityRole.SelectAll();
        }

        /// <summary>
        /// Deletes a record from the ActivityRole table by a foreign key.
        /// </summary>
        public void DeleteByActivityID(Int64 activityID)
        {
            objActivityRole.DeleteByActivityID(activityID); 
        }

        /// <summary>
        /// Deletes a record from the ActivityRole table by a foreign key.
        /// </summary>
        public void DeleteByRoleID(Int64 roleID)
        {
            objActivityRole.DeleteByRoleID(roleID);
        }

        /// <summary>
        /// Selects all records from the ActivityRole table by a foreign key.
        /// </summary>
        public DataSet SelectByRoleID(Int64 roleID)
        {
            return objActivityRole.SelectByRoleID(roleID);
        }
        /// <summary>
        /// Creates a new instance of the ActivityRole class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeActivityRole(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;
            if (ds.Tables[0].Rows[0]["ActivityID"] != null)
            {
                this.ActivityID = Convert.ToInt64(ds.Tables[0].Rows[0]["ActivityID"]);
            }
            if (ds.Tables[0].Rows[0]["RoleID"] != null)
            {
                this.RoleID = Convert.ToInt64(ds.Tables[0].Rows[0]["RoleID"]);
            }
            if (ds.Tables[0].Rows[0]["View"] != null)
            {
                this.View = Convert.ToBoolean(ds.Tables[0].Rows[0]["View"]);
            }
            if (ds.Tables[0].Rows[0]["Edit"] != null)
            {
                this.Edit = Convert.ToBoolean(ds.Tables[0].Rows[0]["Edit"]);
            }
            if (ds.Tables[0].Rows[0]["Insert"] != null)
            {
                //this.Insert = Convert.ToBoolean(ds.Tables[0].Rows[0]["Insert"]);
            }
            if (ds.Tables[0].Rows[0]["Delete"] != null)
            {
                this.Delete = Convert.ToBoolean(ds.Tables[0].Rows[0]["Delete"]);
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
