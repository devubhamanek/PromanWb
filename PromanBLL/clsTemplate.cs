using System;
using System.Collections.Generic;
using System.Data;
using Proman.DAL;

namespace Proman.BLL
{
    /// <summary>
    /// This class handle the template details in the application
    /// </summary>
    public sealed class clsTemplate
    {
        #region Fields
        private int templateId;
        private string uniqueName;
        private string templateName;
        private string subject;
        private string templateContent;
        private bool approvalStatus;
        private Int64 approvedBy;
        private DateTime approvalDate;
        private Int64 createdBy;
        private DateTime createdDate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool status;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Template class.
        /// </summary>
        public clsTemplate()
        {
        }

        public clsTemplate(int templateId)
        {
            MakeTemplate(Select(templateId));
        }
        /// <summary>
        /// Initializes a new instance of the Template class.
        /// </summary>
        public clsTemplate(string uniqueName, string templateName, string subject, string templateContent, bool approvalStatus, Int64 approvedBy, DateTime approvalDate, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool status)
        {
            this.uniqueName = uniqueName;
            this.templateName = templateName;
            this.subject = subject;
            this.templateContent = templateContent;
            this.approvalStatus = approvalStatus;
            this.approvedBy = approvedBy;
            this.approvalDate = approvalDate;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.status = status;
        }

        /// <summary>
        /// Initializes a new instance of the Template class.
        /// </summary>
        public clsTemplate(int templateId, string uniqueName, string subject, string templateName, string templateContent, bool approvalStatus, Int64 approvedBy, DateTime approvalDate, Int64 createdBy, DateTime createdDate, Int64 modifiedBy, DateTime modifiedDate, bool status)
        {
            this.templateId = templateId;
            this.uniqueName = uniqueName;
            this.templateName = templateName;
            this.subject = subject;
            this.templateContent = templateContent;
            this.approvalStatus = approvalStatus;
            this.approvedBy = approvedBy;
            this.approvalDate = approvalDate;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.status = status;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the TemplateId value.
        /// </summary>
        public int TemplateId
        {
            get { return templateId; }
            set { templateId = value; }
        }

        /// <summary>
        /// Gets or sets the UniqueName value.
        /// </summary>
        public string UniqueName
        {
            get { return uniqueName; }
            set { uniqueName = value; }
        }

        /// <summary>
        /// Gets or sets the TemplateName value.
        /// </summary>
        public string TemplateName
        {
            get { return templateName; }
            set { templateName = value; }
        }

        /// <summary>
        /// Gets or sets the Subject value.
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// Gets or sets the TemplateContent value.
        /// </summary>
        public string TemplateContent
        {
            get { return templateContent; }
            set { templateContent = value; }
        }

        /// <summary>
        /// Gets or sets the ApprovalStatus value.
        /// </summary>
        public bool ApprovalStatus
        {
            get { return approvalStatus; }
            set { approvalStatus = value; }
        }

        /// <summary>
        /// Gets or sets the ApprovedBy value.
        /// </summary>
        public Int64 ApprovedBy
        {
            get { return approvedBy; }
            set { approvedBy = value; }
        }

        /// <summary>
        /// Gets or sets the ApprovalDate value.
        /// </summary>
        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; }
        }

        /// <summary>
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public Int64 CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets or sets the CreatedDate value.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedBy value.
        /// </summary>
        public Int64 ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedDate value.
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        /// <summary>
        /// Gets or sets the Status value.
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the Template table.
        /// </summary>
        public int Insert()
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            templateId = (int)objTemplate.Insert(uniqueName, templateName, subject, templateContent, approvalStatus, approvedBy, approvalDate, createdBy, createdDate, modifiedBy, modifiedDate, status);

            return templateId;
        }

        /// <summary>
        /// Updates a record in the Template table.
        /// </summary>
        public void Update()
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            objTemplate.Update(templateId, uniqueName, templateName, subject, templateContent, approvalStatus, approvedBy, approvalDate, createdBy, createdDate, modifiedBy, modifiedDate, status);
        }

        /// <summary>
        /// Deletes a record from the Template table by its primary key.
        /// </summary>
        public void Delete()
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            objTemplate.Delete(templateId);
        }

        /// <summary>
        /// Selects a single record from the Template table.
        /// </summary>
        public DataSet Select(int templateId)
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            return objTemplate.Select(templateId);
        }

        /// <summary>
        /// Selects all records from the Template table.
        /// </summary>
        public DataSet SelectAll()
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            return objTemplate.SelectAll();
        }

        /// <summary>
        /// Creates a new instance of the Template class and populates it with data from the specified SqlDataReader.
        /// </summary>
        /// 
        private void MakeTemplateDue(DataSet dsDue)
        {
            if (dsDue.Tables[0].Rows.Count == 0)
            {
                throw new ApplicationException("DataSource is empty");
            }
            if (dsDue.Tables[0].Rows[0]["TemplateId"] != DBNull.Value)
            {
                this.TemplateId = Convert.ToInt32(dsDue.Tables[0].Rows[0]["TemplateId"]);
            }
            if (dsDue.Tables[0].Rows[0]["UniqueName"] != DBNull.Value)
            {
                this.UniqueName = Convert.ToString(dsDue.Tables[0].Rows[0]["UniqueName"]);
            }
            if (dsDue.Tables[0].Rows[0]["TemplateName"] != DBNull.Value)
            {
                this.TemplateName = Convert.ToString(dsDue.Tables[0].Rows[0]["TemplateName"]);
            }
            if (dsDue.Tables[0].Rows[0]["Subject"] != DBNull.Value)
            {
                this.Subject = Convert.ToString(dsDue.Tables[0].Rows[0]["Subject"]);
            }
            if (dsDue.Tables[0].Rows[0]["TemplateContent"] != DBNull.Value)
            {
                this.TemplateContent = Convert.ToString(dsDue.Tables[0].Rows[0]["TemplateContent"]);
            }
            if (dsDue.Tables[0].Rows[0]["ApprovalStatus"] != DBNull.Value)
            {
                this.ApprovalStatus = Convert.ToBoolean(dsDue.Tables[0].Rows[0]["ApprovalStatus"]);
            }
            if (dsDue.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value)
            {
                this.ApprovedBy = Convert.ToInt64(dsDue.Tables[0].Rows[0]["ApprovedBy"]);
            }
            if (dsDue.Tables[0].Rows[0]["ApprovalDate"] != DBNull.Value)
            {
                this.ApprovalDate = Convert.ToDateTime(dsDue.Tables[0].Rows[0]["ApprovalDate"]);
            }
            if (dsDue.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(dsDue.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (dsDue.Tables[0].Rows[0]["CreatedDate"] != DBNull.Value)
            {
                this.CreatedDate = Convert.ToDateTime(dsDue.Tables[0].Rows[0]["CreatedDate"]);
            }
            if (dsDue.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(dsDue.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (dsDue.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(dsDue.Tables[0].Rows[0]["ModifiedDate"]);
            }
            if (dsDue.Tables[0].Rows[0]["Status"] != DBNull.Value)
            {
                this.Status = Convert.ToBoolean(dsDue.Tables[0].Rows[0]["Status"]);
            }
        }
        private void MakeTemplate(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new ApplicationException("DataSource is empty");
            }

            if (ds.Tables[0].Rows[0]["TemplateId"] != DBNull.Value)
            {
                this.TemplateId = Convert.ToInt32(ds.Tables[0].Rows[0]["TemplateId"]);
            }
            if (ds.Tables[0].Rows[0]["UniqueName"] != DBNull.Value)
            {
                this.UniqueName = Convert.ToString(ds.Tables[0].Rows[0]["UniqueName"]);
            }
            if (ds.Tables[0].Rows[0]["TemplateName"] != DBNull.Value)
            {
                this.TemplateName = Convert.ToString(ds.Tables[0].Rows[0]["TemplateName"]);
            }
            if (ds.Tables[0].Rows[0]["Subject"] != DBNull.Value)
            {
                this.Subject = Convert.ToString(ds.Tables[0].Rows[0]["Subject"]);
            }
            if (ds.Tables[0].Rows[0]["TemplateContent"] != DBNull.Value)
            {
                this.TemplateContent = Convert.ToString(ds.Tables[0].Rows[0]["TemplateContent"]);
            }
            if (ds.Tables[0].Rows[0]["ApprovalStatus"] != DBNull.Value)
            {
                this.ApprovalStatus = Convert.ToBoolean(ds.Tables[0].Rows[0]["ApprovalStatus"]);
            }
            if (ds.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value)
            {
                this.ApprovedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ApprovedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ApprovalDate"] != DBNull.Value)
            {
                this.ApprovalDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApprovalDate"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["CreatedDate"] != DBNull.Value)
            {
                this.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }
            if (ds.Tables[0].Rows[0]["Status"] != DBNull.Value)
            {
                this.Status = Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]);
            }
            
        }

        /// <summary>
        /// Selects a single record from the Template table by UniqueName
        /// </summary>
        /// 

        public void SelectByUniqueNameDue(String uniqueName)
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();
            DataSet dstemplate = objTemplate.SelectByUniqueNameDue(uniqueName);
            MakeTemplateDue(dstemplate);
        }
        public void SelectByUniqueName(string uniqueName)
        {
            DAL.clsTemplate objTemplate = new DAL.clsTemplate();

            DataSet dstemplate = objTemplate.SelectByUniqueName(uniqueName);

            MakeTemplate(dstemplate);
        }
        #endregion
    }
}