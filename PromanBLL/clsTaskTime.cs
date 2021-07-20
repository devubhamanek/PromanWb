using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL
{
    public sealed class clsTaskTime
    {
        #region Fields
        DAL.clsTaskTime objTaskTime = new DAL.clsTaskTime();
        private Int64 taskTimeId;
        private Int64 taskStatus;
        private Int64 taskId;
        private Int64 userId;
        private DateTime timeEntryDate;
        private DateTime fromTime;
        private DateTime toTime;
        private Int64 createdBy;
        private DateTime createdDate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private Int64 projectId;
        private string comment;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TaskTime class.
        /// </summary>
        public clsTaskTime()
        {
        }

        public clsTaskTime(Int64 taskTimeId)
        {
            MakeTask(Select(taskTimeId));
        }

        /// <summary>
        /// Initializes a new instance of the TaskTime class.
        /// </summary>
        public clsTaskTime(Int64 taskId, Int64 userId, DateTime timeEntryDate, DateTime fromTime, DateTime toTime, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskId = taskId;
            this.userId = userId;
            this.timeEntryDate = timeEntryDate;
            this.fromTime = fromTime;
            this.toTime = toTime;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }

        /// <summary>
        /// Initializes a new instance of the TaskTime class.
        /// </summary>
        public clsTaskTime(Int64 taskTimeId, Int64 taskId, Int64 userId, DateTime timeEntryDate, DateTime fromTime, DateTime toTime, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskTimeId = taskTimeId;
            this.taskId = taskId;
            this.userId = userId;
            this.timeEntryDate = timeEntryDate;
            this.fromTime = fromTime;
            this.toTime = toTime;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the TaskTimeId value.
        /// </summary>
        public Int64 TaskTimeId
        {
            get { return taskTimeId; }
            set { taskTimeId = value; }
        }
        /// <summary>
        /// Gets or sets the Task Status value.
        /// </summary>
        public Int64 TaskStatus
        {
            get { return taskStatus; }
            set { taskStatus = value; }
        }
        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public Int64 ProjectId
        {
            get { return projectId ; }
            set { projectId = value; }
        }
        /// <summary>
        /// Gets or sets the Comment value.
        /// </summary>
        public string Comment
        {
            get { return comment ; }
            set { comment  = value; }
        }
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
        /// Gets or sets the TimeEntryDate value.
        /// </summary>
        public DateTime TimeEntryDate
        {
            get { return timeEntryDate; }
            set { timeEntryDate = value; }
        }

        /// <summary>
        /// Gets or sets the FromTime value.
        /// </summary>
        public DateTime FromTime
        {
            get { return fromTime; }
            set { fromTime = value; }
        }

        /// <summary>
        /// Gets or sets the ToTime value.
        /// </summary>
        public DateTime ToTime
        {
            get { return toTime; }
            set { toTime = value; }
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
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the TaskTime table.
        /// </summary>
        public Int64 Insert()
        {
            return objTaskTime.Insert(taskId, userId, timeEntryDate, fromTime, toTime, createdBy, createdDate, modifiedBy, modifiedDate,projectId,comment);
        }

        /// <summary>
        /// Updates a record in the TaskTime table.
        /// </summary>
        public void Update()
        {
            objTaskTime.Update(taskTimeId, taskId, userId, timeEntryDate, fromTime, toTime, modifiedBy, modifiedDate,projectId,comment);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by its primary key.
        /// </summary>
        public void Delete()
        {
            objTaskTime.Delete(taskTimeId);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by a foreign key.
        /// </summary>
        public void DeleteAllByUserId(Int64 userId)
        {
            objTaskTime.DeleteByUserId(userId);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by a foreign key.
        /// </summary>
        public void DeleteAllByTaskTimeId(Int64 taskTimeId)
        {
            objTaskTime.DeleteByTaskTimeId(taskTimeId);
        }

        /// <summary>
        /// Selects a single record from the TaskTime table.
        /// </summary>
        public DataSet Select(Int64 taskTimeId)
        {
            return objTaskTime.Select(taskTimeId);
        }

        /// <summary>
        /// Selects all records from the TaskTime table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objTaskTime.SelectAll();
        }

        /// <summary>
        /// Selects all records from the TaskTime table by a foreign key.
        /// </summary>
        public DataSet SelectAllByUserId(Int64 userId)
        {
            return objTaskTime.SelectByUserId(userId);
        }

        /// <summary>
        /// Selects all records from the TaskTime table by EntryDate
        /// </summary>
        public DataSet SelectByEntryDate(DateTime entryDate,Int64 userId)
        {
            return objTaskTime.SelectByEntryDate(entryDate,userId); 
        }
        /// <summary>
        /// Selects all records from the TaskTime table by a foreign key.
        /// </summary>
        public DataSet SelectAllByTaskId(Int64 taskId)
        {
            return objTaskTime.SelectByTaskId(taskId);
        }
        /// <summary>
        /// Check whether Time entry already exist or not.
        /// <summary>
        /// <returns>bool</returns>
        public bool ExistsTimeEntry(DateTime startTime, DateTime endTime,Int64 userId)
        {
            return objTaskTime.ExistsTimeEntry(startTime, endTime,userId);
        }
        /// <summary>
        /// Creates a new instance of the Task class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeTask(DataSet ds)
        {

            if (ds.Tables[0].Rows.Count == 0)
                return;
            if (ds.Tables[0].Rows[0]["TaskTimeId"] != DBNull.Value)
            {
                this.TaskTimeId  = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskTimeId"]);
            }
            if (ds.Tables[0].Rows[0]["TimeEntryDate"] != DBNull.Value)
            {
                this.TimeEntryDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["TimeEntryDate"]);
            }
            if (ds.Tables[0].Rows[0]["FromTime"] != DBNull.Value)
            {
                this.FromTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["FromTime"]);
            }
            if (ds.Tables[0].Rows[0]["ToTime"] != DBNull.Value)
            {
                this.ToTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ToTime"]);
            }
            if (ds.Tables[0].Rows[0]["ProjectId"] != DBNull.Value)
             {
               this.ProjectId  = Convert.ToInt64(ds.Tables[0].Rows[0]["ProjectId"]);
             }
             if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
             {
                 this.TaskId  = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
             }
             if (ds.Tables[0].Rows[0]["Comment"] != DBNull.Value)
             {
                 this.Comment  = Convert.ToString(ds.Tables[0].Rows[0]["Comment"]);
             }
             if (ds.Tables[0].Rows[0]["TaskStatus"] != DBNull.Value)
             {
                 this.TaskStatus  = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskStatus"]);
             }
          }
        #endregion
    }
}
