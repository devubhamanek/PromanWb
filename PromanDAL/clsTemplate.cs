using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Proman.DAL
{
    /// <summary>
    /// Data access class for Template table.
    /// </summary>
    public sealed class clsTemplate
    {
        public clsTemplate() { }

        /// <summary>
        /// Inserts a record into the Template table.
        /// <summary>
        /// <param name="uniqueName"></param>
        /// <param name="templateName"></param>
        /// <param name="subject"></param>
        /// <param name="templateContent"></param>
        /// <param name="approvalStatus"></param>
        /// <param name="approvedBy"></param>
        /// <param name="approvalDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Insert(string uniqueName, string templateName, string subject, string templateContent, bool approvalStatus, Int64 approvedBy, DateTime approvalDate, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateInsert");

            db.AddInParameter(dbCommand, "UniqueName", DbType.String, uniqueName);
            db.AddInParameter(dbCommand, "TemplateName", DbType.String, templateName);
            db.AddInParameter(dbCommand, "Subject", DbType.String, subject);
            db.AddInParameter(dbCommand, "TemplateContent", DbType.String, templateContent);
            db.AddInParameter(dbCommand, "ApprovalStatus", DbType.Boolean, approvalStatus);
            db.AddInParameter(dbCommand, "ApprovedBy", DbType.Int64, approvedBy);
            db.AddInParameter(dbCommand, "ApprovalDate", DbType.DateTime, approvalDate);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, status);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Template table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet Select(int templateId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateSelect");

            db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Template table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Template table.
        /// <summary>
        /// <param name="templateId"></param>
        /// <param name="uniqueName"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContent"></param>
        /// <param name="approvalStatus"></param>
        /// <param name="approvedBy"></param>
        /// <param name="approvalDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        /// <param name="status"></param>
        public void Update(int templateId, string uniqueName, string templateName, string subject, string templateContent, bool approvalStatus, Int64 approvedBy, DateTime approvalDate, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateUpdate");

            db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);
            db.AddInParameter(dbCommand, "UniqueName", DbType.String, uniqueName);
            db.AddInParameter(dbCommand, "TemplateName", DbType.String, templateName);
            db.AddInParameter(dbCommand, "Subject", DbType.String, subject);
            db.AddInParameter(dbCommand, "TemplateContent", DbType.String, templateContent);
            db.AddInParameter(dbCommand, "ApprovalStatus", DbType.Boolean, approvalStatus);
            db.AddInParameter(dbCommand, "ApprovedBy", DbType.Int64, approvedBy);
            db.AddInParameter(dbCommand, "ApprovalDate", DbType.DateTime, approvalDate);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "CreatedDate", DbType.DateTime, createdDate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, status);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Template table by a composite primary key.
        /// <summary>
        public void Delete(int templateId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateDelete");

            db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Template table by UniqueName
        /// <summary>
        /// <returns>DataSet</returns>
        /// 
        public DataSet SelectByUniqueNameDue(string uniqueName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateSelectByUniqueName");
            db.AddInParameter(dbCommand, "UniqueName", DbType.String, uniqueName);
            return db.ExecuteDataSet(dbCommand);
        }
        public DataSet SelectByUniqueName(string uniqueName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TemplateSelectByUniqueName");

            db.AddInParameter(dbCommand, "UniqueName", DbType.String, uniqueName);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
