using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskReopenReason table.
	/// </summary>
	public sealed class clsTaskReopenReason
	{
		public clsTaskReopenReason() {}

		/// <summary>
		/// Inserts a record into the TaskReopenReason table.
		/// <summary>
		/// <param name="description"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public static int Insert(string description, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskReopenReasonInsert");

			db.AddInParameter(dbCommand, "Description", DbType.String, description);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the TaskReopenReason table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(Int64 taskReopenReasonID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskReopenReasonSelect");

			db.AddInParameter(dbCommand, "TaskReopenReasonID", DbType.Int64, taskReopenReasonID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaskReopenReason table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskReopenReasonSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the TaskReopenReason table.
		/// <summary>
		/// <param name="taskReopenReasonID"></param>
		/// <param name="description"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		public static void Update(Int64 taskReopenReasonID, string description, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskReopenReasonUpdate");

			db.AddInParameter(dbCommand, "TaskReopenReasonID", DbType.Int64, taskReopenReasonID);
			db.AddInParameter(dbCommand, "Description", DbType.String, description);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskReopenReason table by a composite primary key.
		/// <summary>
		public static void Delete(Int64 taskReopenReasonID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskReopenReasonDelete");

			db.AddInParameter(dbCommand, "TaskReopenReasonID", DbType.Int64, taskReopenReasonID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
