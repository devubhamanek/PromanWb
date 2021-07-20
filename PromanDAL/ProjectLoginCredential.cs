using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
	/// <summary>
	/// Data access class for ProjectLoginCredential table.
	/// </summary>
	public sealed class ProjectLoginCredential
	{
		public ProjectLoginCredential() {}

		/// <summary>
		/// Inserts a record into the ProjectLoginCredential table.
		/// <summary>
		/// <param name="loginCredentialID"></param>
		/// <param name="projectId"></param>
		/// <param name="moduleId"></param>
		/// <param name="loginUrl"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		/// <returns></returns>
		public Int64 Insert(Int64 loginCredentialID, Int64 projectId, Int64 moduleId, string loginUrl, string userName, string password, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialInsert");

			db.AddInParameter(dbCommand, "LoginCredentialID", DbType.Int64, loginCredentialID);
			db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
			db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);
			db.AddInParameter(dbCommand, "LoginUrl", DbType.String, loginUrl);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

            Int64 returnValue = Convert.ToInt64(db.ExecuteNonQuery(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Selects a single record from the ProjectLoginCredential table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet Select(Int64 loginCredentialID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialSelect");

			db.AddInParameter(dbCommand, "LoginCredentialID", DbType.Int64, loginCredentialID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the ProjectLoginCredential table by a foreign key.
		/// <summary>
		/// <param name="projectId"></param>
		/// <returns>DataSet</returns>
		public  DataSet SelectByProjectId(Int64 projectId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialSelectByProjectId");

			db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the ProjectLoginCredential table by a foreign key.
		/// <summary>
		/// <param name="moduleId"></param>
		/// <returns>DataSet</returns>
		public  DataSet SelectByModuleId(Int64 moduleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialSelectByModuleId");

			db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProjectLoginCredential table.
		/// <summary>
		/// <returns>DataSet</returns>
		public  DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the ProjectLoginCredential table.
		/// <summary>
		/// <param name="loginCredentialID"></param>
		/// <param name="projectId"></param>
		/// <param name="moduleId"></param>
		/// <param name="loginUrl"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="createdBy"></param>
		/// <param name="createddate"></param>
		/// <param name="modifiedBy"></param>
		/// <param name="modifiedDate"></param>
		/// <param name="isActive"></param>
		public void Update(Int64 loginCredentialID, Int64 projectId, Int64 moduleId, string loginUrl, string userName, string password, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialUpdate");

			db.AddInParameter(dbCommand, "LoginCredentialID", DbType.Int64, loginCredentialID);
			db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
			db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);
			db.AddInParameter(dbCommand, "LoginUrl", DbType.String, loginUrl);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
			db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
			db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
			db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, isActive);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the ProjectLoginCredential table by a composite primary key.
		/// <summary>
		public void Delete(Int64 loginCredentialID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialDelete");

			db.AddInParameter(dbCommand, "LoginCredentialID", DbType.Int64, loginCredentialID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the ProjectLoginCredential table by a foreign key.
		/// <summary>
		public void DeleteByProjectId(Int64 projectId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialDeleteByProjectId");

			db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the ProjectLoginCredential table by a foreign key.
		/// <summary>
		public void DeleteByModuleId(Int64 moduleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProjectLoginCredentialDeleteByModuleId");

			db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
