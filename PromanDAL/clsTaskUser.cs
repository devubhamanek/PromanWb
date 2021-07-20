using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskUser table.
	/// </summary>
	public sealed class clsTaskUser
	{
		public clsTaskUser() {}

		/// <summary>
		/// Inserts a record into the TaskUser table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="userId"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public  void Insert(Int64 taskId, Int64 userId, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskUserInsert");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Selects a single record from the TaskUser table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet Select(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskUserSelect");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaskUser table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet SelectAll(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskUserSelectAll");
            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			return db.ExecuteDataSet(dbCommand);
		}
        /// <summary>
		/// Selects all records from the TaskUser table.
		/// <summary>
		/// <returns>DataSet</returns>
        public DataSet TaskUserSelectClientFromTaskID(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskUserSelectClientFromTaskID");
            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			return db.ExecuteDataSet(dbCommand);
		}
        
		/// <summary>
		/// Updates a record in the TaskUser table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="userId"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		public  void Update(Int64 taskId, Int64 userId, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskUserUpdate");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskUser table by a composite primary key.
		/// <summary>
		public  void Delete(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskUserDelete");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
