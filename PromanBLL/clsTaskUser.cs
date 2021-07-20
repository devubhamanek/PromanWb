using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman.DAL;

namespace Proman.BLL
{
    public sealed class clsTaskUser
    {
        Proman.DAL.clsTaskUser objTaskUser = new DAL.clsTaskUser();
        #region Fields
        private Int64 taskId;
        private Int64 userId;
        private Int64 createdBy;
        private DateTime createdDate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool isActive;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TaskUser class.
        /// </summary>
        public clsTaskUser()
        {
        }


        public clsTaskUser(Int64 taskId)
        {
            MakeTaskUser(Select(taskId));
        }

        /// <summary>
        /// Initializes a new instance of the TaskUser class.
        /// </summary>
        public clsTaskUser(Int64 taskId, Int64 userId, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskId = taskId;
            this.userId = userId;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the TaskId value.
        /// </summary>
        public Int64 TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        /// <summary>
        /// Gets or sets the UserId value.
        /// </summary>
        public Int64 UserId
        {
            get { return userId; }
            set { userId = value; }
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
        /// Saves a record to the TaskUser table.
        /// </summary>
        public void Insert()
        {

            objTaskUser.Insert(taskId, userId, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Selects a single record from the TaskUser table.
        /// </summary>
        public DataSet Select(Int64 taskId)
        {
            return objTaskUser.Select(taskId);
        }

        /// <summary>
        /// Selects all records from the TaskUser table.
        /// </summary>
        public DataSet SelectAll(Int64 taskId)
        {
            return objTaskUser.SelectAll(taskId);
        }

        /// <summary>
        /// Select Client From TaskID.
        /// </summary>
        public DataSet TaskUserSelectClientFromTaskID(Int64 taskId)
        {
            return objTaskUser.TaskUserSelectClientFromTaskID(taskId);
        }

        /// <summary>
        /// Deletes a record from the TaskUser table by a composite primary key.
        /// <summary>
        public void Delete(Int64 taskId)
        {
            objTaskUser.Delete(taskId);
        }

        /// <summary>
        /// Creates a new instance of the Project class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeTaskUser(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;
            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
            }
            if (ds.Tables[0].Rows[0]["UserId"] != DBNull.Value)
            {
                this.UserId = Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedDate"] != DBNull.Value)
            {
                this.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
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
    }
        #endregion
}

