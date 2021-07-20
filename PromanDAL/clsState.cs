using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
    /// <summary>
    /// Data access class for State table.
    /// </summary>
    public sealed class clsState
    {
        public clsState() { }

        /// <summary>
        /// Inserts a record Int64o the State table.
        /// <summary>
        /// <param name="countryId"></param>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="displayOrder"></param>
        /// <param name="createdBy"></param>
        /// <param name="createddate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        /// <returns></returns>
        public Int64 Insert(Int64 countryId, string name, string code, Int64 displayOrder, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateInsert");

            db.AddInParameter(dbCommand, "CountryId", DbType.Int64, countryId);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Code", DbType.String, code);
            db.AddInParameter(dbCommand, "DisplayOrder", DbType.Int64, displayOrder);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

            // Execute the query and return the new identity value


            return Convert.ToInt64(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Selects a single record from the State table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet Select(Int64 stateId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelect");

            db.AddInParameter(dbCommand, "StateId", DbType.Int64, stateId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the State table by a foreign key.
        /// <summary>
        /// <param name="countryId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByCountryId(Int64 countryId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectByCountryId");

            db.AddInParameter(dbCommand, "CountryId", DbType.Int64, countryId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the State table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the State table.
        /// <summary>
        /// <param name="stateId"></param>
        /// <param name="countryId"></param>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="displayOrder"></param>
        /// <param name="createdBy"></param>
        /// <param name="createddate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void Update(Int64 stateId, Int64 countryId, string name, string code, Int64 displayOrder, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateUpdate");

            db.AddInParameter(dbCommand, "StateId", DbType.Int64, stateId);
            db.AddInParameter(dbCommand, "CountryId", DbType.Int64, countryId);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Code", DbType.String, code);
            db.AddInParameter(dbCommand, "DisplayOrder", DbType.Int64, displayOrder);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the State table by a composite primary key.
        /// <summary>
        public void Delete(Int64 stateId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateDelete");

            db.AddInParameter(dbCommand, "StateId", DbType.Int64, stateId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the State table by a foreign key.
        /// <summary>
        public void DeleteByCountryId(Int64 countryId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateDeleteByCountryId");

            db.AddInParameter(dbCommand, "CountryId", DbType.Int64, countryId);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
