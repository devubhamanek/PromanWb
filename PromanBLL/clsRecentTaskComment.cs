using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman.DAL;

namespace Proman.BLL
{
    public sealed class clsRecentTaskComment
    {
        #region Fields
        Proman.DAL.clsRecentTaskComment objTask = new DAL.clsRecentTaskComment();
        private Int64 recentTaskCommentID;
        private Int64 taskID;
        private DateTime createdDate;
        private Int64 createdBy;
        private DateTime modifiedDate;
        private Int64 modifedBy;
        private bool isActive;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the RecentTaskCommentID value.
        /// </summary>
        public Int64 RecentTaskCommentID
        {
            get { return recentTaskCommentID; }
            set { recentTaskCommentID = value; }
        }

        /// <summary>
        /// Gets or sets the TaskID value.
        /// </summary>
        public Int64 TaskID
        {
            get { return taskID; }
            set { taskID = value; }
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
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public Int64 CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
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
        /// Gets or sets the ModifedBy value.
        /// </summary>
        public Int64 ModifedBy
        {
            get { return modifedBy; }
            set { modifedBy = value; }
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
        /// Saves a record to the RecentTaskComment table.
        /// </summary>
        public void Insert()
        {
            objTask.Insert(taskID, createdDate, createdBy, modifiedDate, modifedBy, isActive);
        }

        /// <summary>
        /// Updates a record in the RecentTaskComment table.
        /// </summary>
        public void Update()
        {
            objTask.Update(recentTaskCommentID, taskID, createdDate, createdBy, modifiedDate, modifedBy, isActive);
        }

        /// <summary>
        /// Deletes a record from the RecentTaskComment table by its primary key.
        /// </summary>
        public void Delete()
        {
            objTask.Delete(taskID);
        }

        /// <summary>
        /// Selects a single record from the RecentTaskComment table.
        /// </summary>
        public DataSet Select(Int64 recentTaskCommentID)
        {
            return objTask.Select(recentTaskCommentID);
        }

        /// <summary>
        /// Selects all records from the RecentTaskComment table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objTask.SelectAll();
        }
        #endregion
    }
}
