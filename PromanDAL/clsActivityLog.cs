using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlTypes;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for ActivityLog table.
	/// </summary>
	public sealed class clsActivityLog
	{
		public clsActivityLog() {}

		/// <summary>
		/// Inserts a record into the ActivityLog table.
		/// <summary>
		/// <param name="userId"></param>
		/// <param name="category"></param>
		/// <param name="activity"></param>
		/// <param name="pageName"></param>
		/// <param name="pageURL"></param>
		/// <param name="startDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <param name="iPAddress"></param>
		/// <param name="browser"></param>
		/// <param name="country"></param>
		/// <param name="status"></param>
		/// <param name="referer"></param>
		/// <param name="userAgent"></param>
		/// <param name="isBot"></param>
		/// <returns></returns>
		public Int64  Insert(string sessionId,Int64 userId, string category, string activity, string pageName, string pageURL, DateTime startDateTime, DateTime endDateTime, string iPAddress, string browser, string country, bool status, string referer, string userAgent, bool isBot)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ActivityLogInsert");
            db.AddInParameter(dbCommand, "SessionId", DbType.String, sessionId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
			db.AddInParameter(dbCommand, "Category", DbType.String, category);
			db.AddInParameter(dbCommand, "Activity", DbType.String, activity);
			db.AddInParameter(dbCommand, "PageName", DbType.String, pageName);
			db.AddInParameter(dbCommand, "PageURL", DbType.String, pageURL);
			db.AddInParameter(dbCommand, "StartDateTime", DbType.DateTime, startDateTime);
            if (endDateTime.Equals(DateTime.MaxValue))
            {
                db.AddInParameter(dbCommand, "EndDateTime", DbType.DateTime, SqlDateTime.Null);
            }
            else
            {
                db.AddInParameter(dbCommand, "EndDateTime", DbType.DateTime, endDateTime);
            }
           
			db.AddInParameter(dbCommand, "IPAddress", DbType.String, iPAddress);
			db.AddInParameter(dbCommand, "Browser", DbType.String, browser);
			db.AddInParameter(dbCommand, "Country", DbType.String, country);
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, status);
			db.AddInParameter(dbCommand, "Referer", DbType.String, referer);
			db.AddInParameter(dbCommand, "UserAgent", DbType.String, userAgent);
			db.AddInParameter(dbCommand, "IsBot", DbType.Boolean, isBot);

			// Execute the query and return the new identity value
			return  Convert.ToInt64(db.ExecuteScalar(dbCommand));

		
		}

		/// <summary>
		/// Selects a single record from the ActivityLog table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet Select(Int64 activityId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ActivityLogSelect");

			db.AddInParameter(dbCommand, "ActivityId", DbType.Int64, activityId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ActivityLog table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ActivityLogSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the ActivityLog table.
		/// <summary>
		/// <param name="activityId"></param>
		/// <param name="userId"></param>
		/// <param name="category"></param>
		/// <param name="activity"></param>
		/// <param name="pageName"></param>
		/// <param name="pageURL"></param>
		/// <param name="startDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <param name="iPAddress"></param>
		/// <param name="browser"></param>
		/// <param name="country"></param>
		/// <param name="status"></param>
		/// <param name="referer"></param>
		/// <param name="userAgent"></param>
		/// <param name="isBot"></param>
		public  void Update(Int64 activityId,string sessionId, Int64 userId, string category, string activity, string pageName, string pageURL, DateTime startDateTime, DateTime endDateTime, string iPAddress, string browser, string country, bool status, string referer, string userAgent, bool isBot)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ActivityLogUpdate");

			db.AddInParameter(dbCommand, "ActivityId", DbType.Int64, activityId);
            db.AddInParameter(dbCommand, "SessionId", DbType.String, sessionId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
			db.AddInParameter(dbCommand, "Category", DbType.String, category);
			db.AddInParameter(dbCommand, "Activity", DbType.String, activity);
			db.AddInParameter(dbCommand, "PageName", DbType.String, pageName);
			db.AddInParameter(dbCommand, "PageURL", DbType.String, pageURL);
			db.AddInParameter(dbCommand, "StartDateTime", DbType.DateTime, startDateTime);
			db.AddInParameter(dbCommand, "EndDateTime", DbType.DateTime, endDateTime);
			db.AddInParameter(dbCommand, "IPAddress", DbType.String, iPAddress);
			db.AddInParameter(dbCommand, "Browser", DbType.String, browser);
			db.AddInParameter(dbCommand, "Country", DbType.String, country);
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, status);
			db.AddInParameter(dbCommand, "Referer", DbType.String, referer);
			db.AddInParameter(dbCommand, "UserAgent", DbType.String, userAgent);
			db.AddInParameter(dbCommand, "IsBot", DbType.Boolean, isBot);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the ActivityLog table by a composite primary key.
		/// <summary>
		public  void Delete(Int64 activityId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ActivityLogDelete");

			db.AddInParameter(dbCommand, "ActivityId", DbType.Int64, activityId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
