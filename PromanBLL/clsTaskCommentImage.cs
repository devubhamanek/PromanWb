using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman.DAL;
namespace Proman.BLL {
	public sealed class clsTaskCommentImage {
		#region Fields
        Proman.DAL.clsTaskCommentImage objTaskCommentImage = new DAL.clsTaskCommentImage();
		private Int64 taskCommentImageID;
		private Int64 taskCommentID;
		private Int64 taskID;
		private string imageOriginalName;
		private string imageName;
		private Int64 createdBy;
		private DateTime createdDate;
		private Int64 modifiedBy;
		private DateTime modifiedDate;
		private bool isActive;
		#endregion

		
		#region Properties
		/// <summary>
		/// Gets or sets the TaskCommentImageID value.
		/// </summary>
		public Int64 TaskCommentImageID {
			get { return taskCommentImageID; }
			set { taskCommentImageID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaskCommentID value.
		/// </summary>
		public Int64 TaskCommentID {
			get { return taskCommentID; }
			set { taskCommentID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaskID value.
		/// </summary>
		public Int64 TaskID {
			get { return taskID; }
			set { taskID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImageOriginalName value.
		/// </summary>
		public string ImageOriginalName {
			get { return imageOriginalName; }
			set { imageOriginalName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImageName value.
		/// </summary>
		public string ImageName {
			get { return imageName; }
			set { imageName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Int64 CreatedBy {
			get { return createdBy; }
			set { createdBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedBy value.
		/// </summary>
		public Int64 ModifiedBy {
			get { return modifiedBy; }
			set { modifiedBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedDate value.
		/// </summary>
		public DateTime ModifiedDate {
			get { return modifiedDate; }
			set { modifiedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the TaskCommentImage table.
		/// </summary>
		public void Insert() {
	      objTaskCommentImage.Insert(taskCommentID, taskID, imageOriginalName, imageName, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
		}
		
		/// <summary>
		/// Updates a record in the TaskCommentImage table.
		/// </summary>
		public void Update() {
		 objTaskCommentImage.Update(taskCommentImageID, taskCommentID, taskID, imageOriginalName, imageName, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
		}
		
		/// <summary>
		/// Deletes a record from the TaskCommentImage table by its primary key.
		/// </summary>
		public void Delete() {
            objTaskCommentImage.Delete(taskCommentImageID);
		}
		
		/// <summary>
		/// Selects a single record from the TaskCommentImage table.
		/// </summary>
		public  DataSet  Select(Int64 taskCommentImageID) {
            return objTaskCommentImage.Select(taskCommentID);
            		}
		
		/// <summary>
		/// Selects all records from the TaskCommentImage table.
		/// </summary>
		public  DataSet SelectAll() {
          return  objTaskCommentImage.SelectAll();
		}
		/// <summary>
		/// Selects records from the TaskCommentImage table by a foreign key.
		/// <summary>
		/// <param name="taskCommentID"></param>
		/// <returns>DataSet</returns>
        public DataSet SelectByTaskCommentID(Int64 taskCommentID)
        {
            return objTaskCommentImage.SelectByTaskCommentID(taskCommentID);
        }
		#endregion
	}
}
