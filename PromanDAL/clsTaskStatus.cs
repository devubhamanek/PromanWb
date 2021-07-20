using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskStatus table.
	/// </summary>
	public sealed class clsTaskStatus
	{
        public clsTaskStatus() { }

		/// <summary>
		/// Inserts a record into the TaskStatus table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="percentComplete"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <returns></returns>
        public Int64 Insert(Int64 taskId, int percentComplete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusInsert");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "PercentComplete", DbType.Int32, percentComplete);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			// Execute the query and return the new identity value
			Int64 id=  Convert.ToInt64(db.ExecuteScalar(dbCommand));
            return id;
		}

		/// <summary>
		/// Selects a single record from the TaskStatus table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet Select(Int64 taskStatusId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusSelect");

			db.AddInParameter(dbCommand, "TaskStatusId", DbType.Int64, taskStatusId);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects task completion status record from the TaskStatus table.
        /// <summary>
        /// <returns>DataSet</returns>
        public Int32 SelectTaskStatus(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusSelectTaskStatus");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

           return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

		/// <summary>
		/// Selects all records from the TaskStatus table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the TaskStatus table.
		/// <summary>
		/// <param name="taskStatusId"></param>
		/// <param name="taskId"></param>
		/// <param name="percentComplete"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		public void Update(Int64 taskStatusId, Int64 taskId, int percentComplete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusUpdate");

			db.AddInParameter(dbCommand, "TaskStatusId", DbType.Int64, taskStatusId);
			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "PercentComplete", DbType.Int32, percentComplete);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskStatus table by a composite primary key.
		/// <summary>
		public void Delete(Int64 taskStatusId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskStatusDelete");

			db.AddInParameter(dbCommand, "TaskStatusId", DbType.Int64, taskStatusId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
