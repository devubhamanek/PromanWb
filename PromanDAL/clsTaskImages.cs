using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskImages table.
	/// </summary>
	public sealed class clsTaskImages
	{
		public clsTaskImages() {}

		/// <summary>
		/// Inserts a record into the TaskImages table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="originalImageName"></param>
		/// <param name="imageName"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <returns></returns>
		public Int64 Insert(Int64 taskId, string originalImageName, string imageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesInsert");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "OriginalImageName", DbType.String, originalImageName);
			db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			// Execute the query and return the new identity value
			return  Convert.ToInt64(db.ExecuteScalar(dbCommand));

			
		}

		/// <summary>
		/// Selects a single record from the TaskImages table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet Select(Int64 taskImagesId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesSelect");

			db.AddInParameter(dbCommand, "TaskImagesId", DbType.Int64, taskImagesId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the TaskImages table by a foreign key.
		/// <summary>
		/// <param name="taskId"></param>
		/// <returns>DataSet</returns>
		public DataSet SelectByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesSelectByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaskImages table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the TaskImages table.
		/// <summary>
		/// <param name="taskImagesId"></param>
		/// <param name="taskId"></param>
		/// <param name="originalImageName"></param>
		/// <param name="imageName"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		public void Update(Int64 taskImagesId, Int64 taskId, string originalImageName, string imageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesUpdate");

			db.AddInParameter(dbCommand, "TaskImagesId", DbType.Int64, taskImagesId);
			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "OriginalImageName", DbType.String, originalImageName);
			db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskImages table by a composite primary key.
		/// <summary>
		public void Delete(Int64 taskImagesId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesDelete");

			db.AddInParameter(dbCommand, "TaskImagesId", DbType.Int64, taskImagesId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskImages table by a foreign key.
		/// <summary>
		public void DeleteByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskImagesDeleteByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
