using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for AdminActivityRole table.
	/// </summary>
	public sealed class clsAdminActivityRole
	{
        public clsAdminActivityRole() { }

		/// <summary>
		/// Inserts a record Int64o the AdminActivityRole table.
		/// <summary>
		/// <param name="roleID"></param>
		/// <param name="activityID"></param>
		/// <param name="view"></param>
		/// <param name="insert"></param>
		/// <param name="edit"></param>
		/// <param name="delete"></param>
		/// <param name="createdBy"></param>
		/// <param name="createdDate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public void Insert(Int64 roleID, Int64 activityID, bool view, bool insert, bool edit, bool delete, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleInsert");

			db.AddInParameter(dbCommand, "RoleID", DbType.Int64, roleID);
			db.AddInParameter(dbCommand, "ActivityID", DbType.Int64, activityID);
			db.AddInParameter(dbCommand, "View", DbType.Boolean, view);
			db.AddInParameter(dbCommand, "Insert", DbType.Boolean, insert);
			db.AddInParameter(dbCommand, "Edit", DbType.Boolean, edit);
			db.AddInParameter(dbCommand, "Delete", DbType.Boolean, delete);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the ActivityRole table by a foreign key.
        /// </summary>
        public void DeleteByActivityID(Int64 activityID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleDeleteByActivityID");
            db.AddInParameter(dbCommand, "ActivityID", DbType.Int64, activityID);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the ActivityRole table by a foreign key.
        /// </summary>
        public void DeleteByRoleID(Int64 roleID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleDeleteByRoleID");

            db.AddInParameter(dbCommand, "RoleID", DbType.Int64, roleID);

            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Selects all records from the AdminActivityRole table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the ActivityRole table by a foreign key.
        /// </summary>
        public DataSet SelectByActivityID(Int64 activityID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleSelectByActivityID");
            db.AddInParameter(dbCommand, "ActivityID", DbType.Int64, activityID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the ActivityRole table by a foreign key.
        /// </summary>
        public DataSet SelectByRoleID(Int64 roleID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdminActivityRoleSelectByRoleID");
            db.AddInParameter(dbCommand, "RoleID", DbType.Int64, roleID);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
