using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlTypes;
namespace Proman.DAL
{
    /// <summary>
    /// Data access class for TaskTime table.
    /// </summary>
    public sealed class clsTaskTime
    {
        public clsTaskTime() { }

        /// <summary>
        /// Inserts a record into the TaskTime table.
        /// <summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="timeEntryDate"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        /// <returns></returns>
        public Int64 Insert(Int64 taskId, Int64 userId, DateTime timeEntryDate, DateTime fromTime, DateTime toTime, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, Int64 projectId, string comment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeInsert");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            db.AddInParameter(dbCommand, "TimeEntryDate", DbType.DateTime, timeEntryDate);
            db.AddInParameter(dbCommand, "FromTime", DbType.DateTime, fromTime);
            db.AddInParameter(dbCommand, "ToTime", DbType.DateTime, toTime);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "Comment", DbType.String, comment);
            // Execute the query and return the new identity value

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Selects a single record from the TaskTime table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet Select(Int64 taskTimeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeSelect");

            db.AddInParameter(dbCommand, "TaskTimeId", DbType.Int64, taskTimeId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the TaskTime table by a foreign key.
        /// <summary>
        /// <param name="userId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByUserId(Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeSelectByUserId");

            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects All records from the TaskTime table by a EntryDate
        /// <summary>
        /// <param name="userId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByEntryDate(DateTime entryDate, Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeSelectAllByEntryDate");
            if (entryDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "EntryDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "EntryDate", DbType.DateTime,entryDate);
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects records from the TaskTime table by a foreign key.
        /// <summary>
        /// <param name="taskId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByTaskId(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeSelectByTaskId");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the TaskTime table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Check whether Time entry already exist or not.
        /// <summary>
        /// <returns>bool</returns>
        public bool ExistsTimeEntry(DateTime startTime, DateTime endTime, Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ExistTImeEntry");
            db.AddInParameter(dbCommand, "startTime", DbType.DateTime, startTime);
            db.AddInParameter(dbCommand, "endTime", DbType.DateTime, endTime);
            db.AddInParameter(dbCommand, "userId", DbType.Int64, userId);
            if (Convert.ToInt64(db.ExecuteScalar(dbCommand)) > 0)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Updates a record in the TaskTime table.
        /// <summary>
        /// <param name="taskTimeId"></param>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="timeEntryDate"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void Update(Int64 taskTimeId, Int64 taskId, Int64 userId, DateTime timeEntryDate, DateTime fromTime, DateTime toTime, Int64 modifiedBy, DateTime modifiedDate, Int64 projectId, string comment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeUpdate");

            db.AddInParameter(dbCommand, "TaskTimeId", DbType.Int64, taskTimeId);
            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            db.AddInParameter(dbCommand, "TimeEntryDate", DbType.DateTime, timeEntryDate);
            db.AddInParameter(dbCommand, "FromTime", DbType.DateTime, fromTime);
            db.AddInParameter(dbCommand, "ToTime", DbType.DateTime, toTime);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "Comment", DbType.String, comment);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by a composite primary key.
        /// <summary>
        public void Delete(Int64 taskTimeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeDelete");

            db.AddInParameter(dbCommand, "TaskTimeId", DbType.Int64, taskTimeId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by a foreign key.
        /// <summary>
        public void DeleteByUserId(Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeDeleteByUserId");

            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the TaskTime table by a foreign key.
        /// <summary>
        public void DeleteByTaskTimeId(Int64 taskTimeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskTimeDeleteAllByTaskTimeId");

            db.AddInParameter(dbCommand, "TaskTimeId", DbType.Int64, taskTimeId);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
