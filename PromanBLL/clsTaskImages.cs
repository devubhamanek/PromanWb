using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL
{
    public sealed class clsTaskImages
    {
        #region Fields
        DAL.clsTaskImages objTaskImages = new DAL.clsTaskImages();

        private Int64 taskImagesId;
        private Int64 taskId;
        private string originalImageName;
        private string imageName;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TaskImage class.
        /// </summary>
        public clsTaskImages()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TaskImage class.
        /// </summary>
        public clsTaskImages(Int64 taskImagesId)
        {
            MakeTaskImage(Select(taskImagesId));
        }

        /// <summary>
        /// Initializes a new instance of the TaskImage class.
        /// </summary>
        public clsTaskImages(Int64 taskId, string originalImageName, string imageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskId = taskId;
            this.originalImageName = originalImageName;
            this.imageName = imageName;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }

        /// <summary>
        /// Initializes a new instance of the TaskImage class.
        /// </summary>
        public clsTaskImages(Int64 taskImagesId, Int64 taskId, string originalImageName, string imageName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskImagesId = taskImagesId;
            this.taskId = taskId;
            this.originalImageName = originalImageName;
            this.imageName = imageName;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the TaskImagesId value.
        /// </summary>
        public Int64 TaskImagesId
        {
            get { return taskImagesId; }
            set { taskImagesId = value; }
        }

        /// <summary>
        /// Gets or sets the TaskId value.
        /// </summary>
        public Int64 TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        /// <summary>
        /// Gets or sets the OriginalImageName value.
        /// </summary>
        public string OriginalImageName
        {
            get { return originalImageName; }
            set { originalImageName = value; }
        }

        /// <summary>
        /// Gets or sets the ImageName value.
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
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
        /// Gets or sets the Createddate value.
        /// </summary>
        public DateTime Createddate
        {
            get { return createddate; }
            set { createddate = value; }
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
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the TaskImages table.
        /// </summary>
        public Int64 Insert()
        {
            return objTaskImages.Insert(taskId, originalImageName, imageName, createdBy, createddate, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Updates a record in the TaskImages table.
        /// </summary>
        public void Update()
        {
            objTaskImages.Update(taskImagesId, taskId, originalImageName, imageName, createdBy, createddate, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Deletes a record from the TaskImages table by its primary key.
        /// </summary>
        public void Delete(Int64 taskImagesId)
        {
            objTaskImages.Delete(taskImagesId);
        }

        /// <summary>
        /// Deletes a record from the TaskImages table by a foreign key.
        /// </summary>
        public void DeleteAllByTaskId(Int64 taskId)
        {
            objTaskImages.DeleteByTaskId(taskId);
        }

        /// <summary>
        /// Selects a single record from the TaskImages table.
        /// </summary>
        public DataSet Select(Int64 taskImagesId)
        {
            return objTaskImages.Select(taskImagesId);
        }

        /// <summary>
        /// Selects all records from the TaskImages table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objTaskImages.SelectAll();
        }

        /// <summary>
        /// Selects all records from the TaskImages table by a foreign key.
        /// </summary>
        public DataSet SelectAllByTaskId(Int64 taskId)
        {
            return objTaskImages.SelectByTaskId(taskId);
        }

        /// <summary>
        /// Creates a new instance of the TaskImages class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeTaskImage(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["TaskImagesId"] != DBNull.Value)
            {
                this.TaskImagesId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskImagesId"]);
            }

            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
            }

            if (ds.Tables[0].Rows[0]["OriginalImageName"] != DBNull.Value)
            {
                this.OriginalImageName = Convert.ToString(ds.Tables[0].Rows[0]["OriginalImageName"]);
            }

            if (ds.Tables[0].Rows[0]["ImageName"] != DBNull.Value)
            {
                this.ImageName = Convert.ToString(ds.Tables[0].Rows[0]["ImageName"]);
            }

            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }

            if (ds.Tables[0].Rows[0]["Createddate"] != DBNull.Value)
            {
                this.Createddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Createddate"]);
            }

            if (ds.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }

            if (ds.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }
        }
        #endregion
    }
}
