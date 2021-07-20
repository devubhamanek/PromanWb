using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskCommentImage table.
	/// </summary>
	public sealed class clsTaskCommentImage
	{
		public clsTaskCommentImage() {}

		/// <summary>
		/// Inserts a record into the TaskCommentImage table.
		/// <summary>
		/// <param name="taskCommentID"></param>
		/// <param name="taskID"></param>
		/// <param name="imageOriginalName"></param>
		/// <param name="imageName"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public  Int64 Insert(Int64 taskCommentID, Int64 taskID, string imageOriginalName, string imageName, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageInsert");

			db.AddInParameter(dbCommand, "TaskCommentID", DbType.Int64, taskCommentID);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int64, taskID);
			db.AddInParameter(dbCommand, "ImageOriginalName", DbType.String, imageOriginalName);
			db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			// Execute the query and return the new identity value
			Int64 returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the TaskCommentImage table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet Select(Int64 taskCommentImageID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageSelect");

			db.AddInParameter(dbCommand, "TaskCommentImageID", DbType.Int64, taskCommentImageID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the TaskCommentImage table by a foreign key.
		/// <summary>
		/// <param name="taskCommentID"></param>
		/// <returns>DataSet</returns>
		public  DataSet SelectByTaskCommentID(Int64 taskCommentID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageSelectByTaskCommentID");

			db.AddInParameter(dbCommand, "TaskCommentID", DbType.Int64, taskCommentID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the TaskCommentImage table by a foreign key.
		/// <summary>
		/// <param name="taskID"></param>
		/// <returns>DataSet</returns>
		public  DataSet SelectByTaskID(Int64 taskID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageSelectByTaskID");

			db.AddInParameter(dbCommand, "TaskID", DbType.Int64, taskID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaskCommentImage table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the TaskCommentImage table.
		/// <summary>
		/// <param name="taskCommentImageID"></param>
		/// <param name="taskCommentID"></param>
		/// <param name="taskID"></param>
		/// <param name="imageOriginalName"></param>
		/// <param name="imageName"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		public  void Update(Int64 taskCommentImageID, Int64 taskCommentID, Int64 taskID, string imageOriginalName, string imageName, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageUpdate");

			db.AddInParameter(dbCommand, "TaskCommentImageID", DbType.Int64, taskCommentImageID);
			db.AddInParameter(dbCommand, "TaskCommentID", DbType.Int64, taskCommentID);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int64, taskID);
			db.AddInParameter(dbCommand, "ImageOriginalName", DbType.String, imageOriginalName);
			db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskCommentImage table by a composite primary key.
		/// <summary>
		public  void Delete(Int64 taskCommentImageID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageDelete");

			db.AddInParameter(dbCommand, "TaskCommentImageID", DbType.Int64, taskCommentImageID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskCommentImage table by a foreign key.
		/// <summary>
		public  void DeleteByTaskCommentID(Int64 taskCommentID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageDeleteByTaskCommentID");

			db.AddInParameter(dbCommand, "TaskCommentID", DbType.Int64, taskCommentID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskCommentImage table by a foreign key.
		/// <summary>
		public  void DeleteByTaskID(Int64 taskID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskCommentImageDeleteByTaskID");

			db.AddInParameter(dbCommand, "TaskID", DbType.Int64, taskID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
