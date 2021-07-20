using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for Users table.
	/// </summary>
	public sealed class clsUsers
	{
		public clsUsers() {}

		/// <summary>
		/// Inserts a record into the Users table.
		/// <summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="roleId"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
        public Int64 Insert(string firstName, string lastName, string userName, string password, int roleId, string ImageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersInsert");

			db.AddInParameter(dbCommand, "FirstName", DbType.String, firstName);
			db.AddInParameter(dbCommand, "LastName", DbType.String, lastName);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);
            db.AddInParameter(dbCommand, "ImageName", DbType.String, ImageName);            
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			// Execute the query and return the new identity value
			return Convert.ToInt64(db.ExecuteScalar(dbCommand));

			
		}

		/// <summary>
		/// Selects a single record from the Users table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet Select(Int64 userId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersSelect");

			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the Users table by a foreign key.
		/// <summary>
		/// <param name="roleId"></param>
		/// <returns>DataSet</returns>
		public DataSet SelectByRoleId(int roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersSelectByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);

			return db.ExecuteDataSet(dbCommand);
		}
        
            /// <summary>
		/// Selects records from the Users table by a foreign key.
		/// <summary>
		/// <param name="roleId"></param>
		/// <returns>DataSet</returns>
        public DataSet SelectByRoleId(Int32 superAdminRoleId, Int32 projectManagerRoleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UsersSelectAllByRoleId");

            db.AddInParameter(dbCommand, "SuperAdminRoleId", DbType.Int32, superAdminRoleId);
            db.AddInParameter(dbCommand, "ProjectManagerRoleId", DbType.Int32, projectManagerRoleId);

			return db.ExecuteDataSet(dbCommand);
		}
        /// <summary>
        /// Selects single record from table using username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataSet SelectByUsernameandPassword(string userName, string password)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UserSelectByUsernameandPassword");

            db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
            db.AddInParameter(dbCommand, "Password", DbType.String, password);
         
            return db.ExecuteDataSet(dbCommand);
        }
		/// <summary>
		/// Selects all records from the Users table.
		/// <summary>
		/// <returns>DataSet</returns>
		public DataSet SelectAll(Int64 roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersSelectAll");
            db.AddInParameter(dbCommand, "RoleId", DbType.Int64, roleId);
			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Users table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectAllUsers()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UsersSelectAllUsers");
            
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the Users table.
		/// <summary>
		/// <param name="userId"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="roleId"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		public void Update(Int64 userId, string firstName, string lastName, string userName, string password, int roleId,string ImageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersUpdate");

			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
			db.AddInParameter(dbCommand, "FirstName", DbType.String, firstName);
			db.AddInParameter(dbCommand, "LastName", DbType.String, lastName);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);
            db.AddInParameter(dbCommand, "ImageName", DbType.String, ImageName);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Users table by a composite primary key.
		/// <summary>
		public void Delete(Int64 userId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersDelete");

			db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Users table by a foreign key.
		/// <summary>
		public void DeleteByRoleId(int roleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UsersDeleteByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Int32, roleId);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// This function check in the database if this username exists or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Exists(string userName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UserExists");

            db.AddInParameter(dbCommand, "UserName", DbType.String, userName);

            if (db.ExecuteScalar(dbCommand) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// This function check in the database if this username exists or not
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Exists(string userName,Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UserExistsByUserIdandEmail");

            db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);

            if (db.ExecuteScalar(dbCommand) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update Project avator image in project table.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="avator"></param>
        public void UpdateProfileImage(Int64 userid, string image)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateProfileImage");

            db.AddInParameter(dbCommand, "UserID", DbType.Int64, userid);
            db.AddInParameter(dbCommand, "image", DbType.String, image);

            db.ExecuteNonQuery(dbCommand);

        }
        /// <summary>
        /// This function check in the database if this username exists or not
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string CheckUser(Int64 userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UserCheckAll");
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
             
           return Convert.ToString(db.ExecuteScalar(dbCommand));
          
        }
	}
}
