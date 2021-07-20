using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;

namespace Proman.BLL {
	public sealed class clsTaskReopenReason {
        Proman.DAL.clsTaskReopenReason objTaskOpeneReason = new Proman.DAL.clsTaskReopenReason();
		#region Fields
		private Int64 taskReopenReasonID;
		private string description;
		private Int64 createdBy;
		private DateTime createdDate;
		private Int64 modifiedBy;
		private DateTime modifiedDate;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the TaskReopenReason class.
		/// </summary>
		public clsTaskReopenReason() {
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskReopenReason class.
		/// </summary>
		public clsTaskReopenReason(string description, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive) {
			this.description = description;
			this.createdBy = createdBy;
			this.createdDate = createdDate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
			this.isActive = isActive;
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskReopenReason class.
		/// </summary>
		public clsTaskReopenReason(Int64 taskReopenReasonID, string description, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive) {
			this.taskReopenReasonID = taskReopenReasonID;
			this.description = description;
			this.createdBy = createdBy;
			this.createdDate = createdDate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TaskReopenReasonID value.
		/// </summary>
		public Int64 TaskReopenReasonID {
			get { return taskReopenReasonID; }
			set { taskReopenReasonID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
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
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
        ///// <summary>
        ///// Saves a record to the TaskReopenReason table.
        ///// </summary>
        //public void Insert() {
        //    taskReopenReasonID = (long) SqlClientUtility.ExecuteScalar("TaskReopenReasonInsert", description, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        //}
		
        ///// <summary>
        ///// Updates a record in the TaskReopenReason table.
        ///// </summary>
        //public void Update() {
        //    SqlClientUtility.ExecuteNonQuery("TaskReopenReasonUpdate", taskReopenReasonID, description, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
        //}
		
        ///// <summary>
        ///// Deletes a record from the TaskReopenReason table by its primary key.
        ///// </summary>
        //public void Delete() {
        //    SqlClientUtility.ExecuteNonQuery("TaskReopenReasonDelete", taskReopenReasonID);
        //}
		
        ///// <summary>
        ///// Selects a single record from the TaskReopenReason table.
        ///// </summary>
        //public static TaskReopenReason Select(Int64 taskReopenReasonID) {
        //    using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader("TaskReopenReasonSelect", taskReopenReasonID)) {
        //        if (dataReader.Read()) {
        //            return MakeTaskReopenReason(dataReader);
        //        } else {
        //            return null;
        //        }
        //    }
        //}
		
		/// <summary>
		/// Selects all records from the TaskReopenReason table.
		/// </summary>
		public DataSet  SelectAll() {
            return objTaskOpeneReason.SelectAll();
		}
		
        ///// <summary>
        ///// Creates a new instance of the TaskReopenReason class and populates it with data from the specified SqlDataReader.
        ///// </summary>
        //private static TaskReopenReason MakeTaskReopenReason(SqlDataReader dataReader) {
        //    TaskReopenReason taskReopenReason = new TaskReopenReason();
			
        //    if (dataReader.IsDBNull(0) == false) {
        //        taskReopenReason.TaskReopenReasonID = dataReader.GetInt64(0);
        //    }
        //    if (dataReader.IsDBNull(1) == false) {
        //        taskReopenReason.Description = dataReader.GetString(1);
        //    }
        //    if (dataReader.IsDBNull(2) == false) {
        //        taskReopenReason.CreatedBy = dataReader.GetInt64(2);
        //    }
        //    if (dataReader.IsDBNull(3) == false) {
        //        taskReopenReason.CreatedDate = dataReader.GetDateTime(3);
        //    }
        //    if (dataReader.IsDBNull(4) == false) {
        //        taskReopenReason.ModifiedBy = dataReader.GetInt64(4);
        //    }
        //    if (dataReader.IsDBNull(5) == false) {
        //        taskReopenReason.ModifiedDate = dataReader.GetDateTime(5);
        //    }
        //    if (dataReader.IsDBNull(6) == false) {
        //        taskReopenReason.IsActive = dataReader.GetBoolean(6);
        //    }

        //    return taskReopenReason;
        //}
		#endregion
	}
}
