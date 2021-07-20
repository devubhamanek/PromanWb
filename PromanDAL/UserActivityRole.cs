using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for UserActivityRole table.
	/// </summary>
	public sealed class UserActivityRole
	{
		public UserActivityRole() {}

		/// <summary>
		/// Inserts a record into the UserActivityRole table.
		/// <summary>
		/// <param name="userID"></param>
		/// <param name="activityID"></param>
		/// <param name="view"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public Int64 Insert(Int64 userID, Int64 activityID, bool view, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserActivityRoleInsert");

			db.AddInParameter(dbCommand, "UserID", DbType.Int64, userID);
			db.AddInParameter(dbCommand, "ActivityID", DbType.Int64, activityID);
			db.AddInParameter(dbCommand, "View", DbType.Boolean, view);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			Int64 returnValue=Convert.ToInt64(db.ExecuteNonQuery(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Selects records from the UserActivityRole table by a foreign key.
		/// <summary>
		/// <param name="userID"></param>
		/// <returns>DataSet</returns>
		public  DataSet SelectByUserID(Int64 userID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserActivityRoleSelectByUserID");

			db.AddInParameter(dbCommand, "UserID", DbType.Int64, userID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the UserActivityRole table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserActivityRoleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the UserActivityRole table by a foreign key.
		/// <summary>
		public void DeleteByUserID(Int64 userID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserActivityRoleDeleteByUserID");

			db.AddInParameter(dbCommand, "UserID", DbType.Int64, userID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
