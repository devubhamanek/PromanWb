using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Proman.BLL 
{
    /// <summary>
    /// Bussiness logic class for TaskStatus Table
    /// </summary>
	public sealed class clsTaskStatus 
    {
		#region Fields
        DAL.clsTaskStatus objTaskStatus = new DAL.clsTaskStatus();

		private Int64 taskStatusId;
		private Int64 taskId;
		private int percentComplete;
		private Int64 createdBy;
		private DateTime createdDate;
		private Int64 modifiedBy;
		private DateTime modifiedDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the TaskStatu class.
		/// </summary>
		public clsTaskStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskStatu class.
		/// </summary>
		public clsTaskStatus(Int64 taskId, int percentComplete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate) {
			this.taskId = taskId;
			this.percentComplete = percentComplete;
			this.createdBy = createdBy;
			this.createdDate = createdDate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskStatu class.
		/// </summary>
        public clsTaskStatus(Int64 taskStatusId, Int64 taskId, int percentComplete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
        {
			this.taskStatusId = taskStatusId;
			this.taskId = taskId;
			this.percentComplete = percentComplete;
			this.createdBy = createdBy;
			this.createdDate = createdDate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TaskStatusId value.
		/// </summary>
		public Int64 TaskStatusId {
			get { return taskStatusId; }
			set { taskStatusId = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaskId value.
		/// </summary>
		public Int64 TaskId {
			get { return taskId; }
			set { taskId = value; }
		}
		
		/// <summary>
		/// Gets or sets the PercentComplete value.
		/// </summary>
		public int PercentComplete {
			get { return percentComplete; }
			set { percentComplete = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Int64 CreatedBy {
			get { return createdBy; }
			set { createdBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedBy value.
		/// </summary>
		public Int64 ModifiedBy {
			get { return modifiedBy; }
			set { modifiedBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedDate value.
		/// </summary>
		public DateTime ModifiedDate {
			get { return modifiedDate; }
			set { modifiedDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the TaskStatus table.
		/// </summary>
		public Int64 Insert() {
			return objTaskStatus.Insert(taskId, percentComplete, createdBy, createdDate, modifiedBy, modifiedDate);
		}
		
		/// <summary>
		/// Updates a record in the TaskStatus table.
		/// </summary>
		public void Update() {
			objTaskStatus.Update(taskStatusId, taskId, percentComplete, createdBy, createdDate, modifiedBy, modifiedDate);
		}
		
		/// <summary>
		/// Deletes a record from the TaskStatus table by its primary key.
		/// </summary>
		public void Delete() {
			objTaskStatus.Delete(taskStatusId);
		}
		
		/// <summary>
		/// Selects a single record from the TaskStatus table.
		/// </summary>
		public DataSet Select(Int64 taskStatusId) {
            return objTaskStatus.Select(taskStatusId);

		}

        /// <summary>
        /// Selects task completion status record from the TaskStatus table.
        /// <summary>
        public Int32 SelectTaskStatus(Int64 taskId)
        {
            return objTaskStatus.SelectTaskStatus(taskId);
        }
		
		/// <summary>
		/// Selects all records from the TaskStatus table.
		/// </summary>
		public DataSet SelectAll() {
            return objTaskStatus.SelectAll();
		}
		
		/// <summary>
		/// Creates a new instance of the TaskStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private void MakeTaskStatu(DataSet ds) {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["TaskStatusId"] != DBNull.Value)
            {
                this.TaskStatusId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskStatusId"]);
            }
            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
            }
            if (ds.Tables[0].Rows[0]["PercentComplete"] != DBNull.Value)
            {
                this.PercentComplete = Convert.ToInt32(ds.Tables[0].Rows[0]["PercentComplete"]);
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
		#endregion
	}
}
