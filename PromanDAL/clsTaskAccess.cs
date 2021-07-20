using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for TaskAccess table.
	/// </summary>
	public sealed class clsTaskAccess
	{
		public clsTaskAccess() {}

		/// <summary>
		/// Inserts a record into the TaskAccess table.
		/// <summary>
		/// <param name="taskId"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public void Insert(Int64 taskId, int roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessInsert");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Inserts multiple record into the TaskAccess table.
        /// <summary>
        /// <param name="taskId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void InsertMultiple(Int64 taskId, string roleIds)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessInsertMultiple");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "RoleIds", DbType.String, roleIds);

            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Selects records from the TaskAccess table by a foreign key.
		/// <summary>
		/// <param name="taskId"></param>
		/// <returns>DataSet</returns>
		public DataSet SelectByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessSelectByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the TaskAccess table by a foreign key.
		/// <summary>
		/// <param name="roleId"></param>
		/// <returns>DataSet</returns>
		public DataSet SelectByRoleId(int roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessSelectByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskAccess table by a foreign key.
		/// <summary>
		public void DeleteByTaskId(Int64 taskId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessDeleteByTaskId");

			db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the TaskAccess table by a foreign key.
		/// <summary>
		public void DeleteByRoleId(int roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaskAccessDeleteByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
