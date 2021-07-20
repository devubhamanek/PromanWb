using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskComment table.
	/// </summary>
	public sealed class clsTaskComment
	{
		public clsTaskComment() {}

		/// <summary>
		/// Inserts a record into the TaskComment table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="comment"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <returns></returns>
		public Int64  Insert(Int64 taskId, string comment, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentInsert");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "Comment", DbType.String, comment);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			// Execute the query and return the new identity value
			return  Convert.ToInt64(db.ExecuteScalar(dbCommand));

		
		}

        public Int64 InsertTaskHoldRemove(Int64 taskId, string comment,Int32 taskStatus,  Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InsertTaskHoldRemove");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "Comment", DbType.String, comment);
            db.AddInParameter(dbCommand, "taskStatus", DbType.Int32, taskStatus);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			// Execute the query and return the new identity value
			return  Convert.ToInt64(db.ExecuteScalar(dbCommand));

		
		}
        
		/// <summary>
		/// Selects a single record from the TaskComment table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet Select(Int64 taskCommentId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentSelect");

			db.AddInParameter(dbCommand, "TaskCommentId", DbType.Int64, taskCommentId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the TaskComment table by a foreign key.
		/// <summary>
		/// <param name="taskId"></param>
		/// <returns>DataSet</returns>
		public DataSet SelectByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentSelectByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaskComment table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the TaskComment table.
		/// <summary>
		/// <param name="taskCommentId"></param>
		/// <param name="taskId"></param>
		/// <param name="comment"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		public void Update(Int64 taskCommentId, Int64 taskId, string comment, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentUpdate");

			db.AddInParameter(dbCommand, "TaskCommentId", DbType.Int64, taskCommentId);
			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "Comment", DbType.String, comment);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskComment table by a composite primary key.
		/// <summary>
		public void Delete(Int64 taskCommentId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentDelete");

			db.AddInParameter(dbCommand, "TaskCommentId", DbType.Int64, taskCommentId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskComment table by a foreign key.
		/// <summary>
		public void DeleteByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentDeleteByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
