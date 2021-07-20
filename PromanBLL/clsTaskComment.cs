using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL 
{
	public sealed class clsTaskComment 
    {
		#region Fields
        DAL.clsTaskComment objTaskComment = new DAL.clsTaskComment(); 
		private Int64 taskCommentId;
		private Int64 taskId;
		private string comment;
		private Int64 createdBy;
		private DateTime createddate;
		private Int64 modifiedBy;
		private DateTime modifiedDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the TaskComment class.
		/// </summary>
		public clsTaskComment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskComment class.
		/// </summary>
		public clsTaskComment(Int64 taskId, string comment, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate) {
			this.taskId = taskId;
			this.comment = comment;
			this.createdBy = createdBy;
			this.createddate = createddate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskComment class.
		/// </summary>
        public clsTaskComment(Int64 taskCommentId, Int64 taskId, string comment, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
			this.taskCommentId = taskCommentId;
			this.taskId = taskId;
			this.comment = comment;
			this.createdBy = createdBy;
			this.createddate = createddate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TaskCommentId value.
		/// </summary>
		public Int64 TaskCommentId {
			get { return taskCommentId; }
			set { taskCommentId = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaskId value.
		/// </summary>
		public Int64 TaskId {
			get { return taskId; }
			set { taskId = value; }
		}
		
		/// <summary>
		/// Gets or sets the Comment value.
		/// </summary>
		public string Comment {
			get { return comment; }
			set { comment = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Int64 CreatedBy {
			get { return createdBy; }
			set { createdBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the Createddate value.
		/// </summary>
		public DateTime Createddate {
			get { return createddate; }
			set { createddate = value; }
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
		/// Saves a record to the TaskComment table.
		/// </summary>
		public Int64  Insert() {
           return objTaskComment.Insert(taskId, comment, createdBy, createddate, modifiedBy, modifiedDate);
		}

        /// <summary>
        /// Saves a record to the TaskComment table.
        /// </summary>
        public Int64 InsertTaskHoldRemove(Int64 taskId,string comment,Int32 Taskstatus,Int64 createdBy,DateTime createddate,Int64 modifiedBy,DateTime modifiedDate)
        {
            return objTaskComment.InsertTaskHoldRemove(taskId, comment, Taskstatus, createdBy, createddate, modifiedBy, modifiedDate);
        }
		
		/// <summary>
		/// Updates a record in the TaskComment table.
		/// </summary>
		public void Update() {
			objTaskComment.Update(taskCommentId, taskId, comment, createdBy, createddate, modifiedBy, modifiedDate);
		}
		
		/// <summary>
		/// Deletes a record from the TaskComment table by its primary key.
		/// </summary>
		public void Delete() {
            objTaskComment.Delete(taskCommentId);
		}
		
		/// <summary>
		/// Deletes a record from the TaskComment table by a foreign key.
		/// </summary>
		public  void DeleteAllByTaskId(Int64 taskId) {
            objTaskComment.DeleteByTaskId(taskId);
		}
		
		/// <summary>
		/// Selects a single record from the TaskComment table.
		/// </summary>
		public DataSet Select(Int64 taskCommentId) {
            return objTaskComment.Select(taskCommentId);
		}
		
		/// <summary>
		/// Selects all records from the TaskComment table.
		/// </summary>
		public DataSet SelectAll() {
            return objTaskComment.SelectAll(); 
		}
		
		/// <summary>
		/// Selects all records from the TaskComment table by a foreign key.
		/// </summary>
		public DataSet SelectAllByTaskId(Int64 taskId) {
            return objTaskComment.SelectByTaskId(taskId);  
		}
		
		/// <summary>
		/// Creates a new instance of the TaskComment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private void MakeTaskComment(DataSet ds) {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["TaskCommentId"] != DBNull.Value)
            {
                this.TaskCommentId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskCommentId"]);
			}
            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
			}
            if (ds.Tables[0].Rows[0]["Comment"] != DBNull.Value)
            {
                this.Comment = Convert.ToString(ds.Tables[0].Rows[0]["Comment"]);
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
		#endregion
	}
}
