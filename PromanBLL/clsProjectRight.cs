using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman.DAL;

namespace Proman.BLL {
	public sealed class clsProjectRight {
		#region Fields
        Proman.DAL.clsProjectRights objProjectRights=new clsProjectRights();
		private Int64 projectRightsID;
		private Int64 projectID;
		private Int64 userID;
		private bool view;
		private Int64 createdBy;
		private Int64 modifiedBy;
		private DateTime modifiedDate;
        private DateTime createdDate;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ProjectRight class.
		/// </summary>
		public clsProjectRight() {
		}
		
		/// <summary>
		/// Initializes a new instance of the ProjectRight class.
		/// </summary>
		public clsProjectRight(Int64 projectRightsID, Int64 projectID, Int64 userID, bool view, Int64 createdBy, DateTime  createdDate, Int64 modifiedBy, DateTime modifiedDate, bool isActive) {
			this.projectRightsID = projectRightsID;
			this.projectID = projectID;
			this.userID = userID;
			this.view = view;
			this.createdBy = createdBy;
			this.createdDate = createdDate;
			this.modifiedBy = modifiedBy;
			this.modifiedDate = modifiedDate;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProjectRightsID value.
		/// </summary>
		public Int64 ProjectRightsID {
			get { return projectRightsID; }
			set { projectRightsID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProjectID value.
		/// </summary>
		public Int64 ProjectID {
			get { return projectID; }
			set { projectID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public Int64 UserID {
			get { return userID; }
			set { userID = value; }
		}
		
		/// <summary>
		/// Gets or sets the View value.
		/// </summary>
		public bool View {
			get { return view; }
			set { view = value; }
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
		/// Saves a record to the ProjectRights table.
		/// </summary>
		public void Insert() {
		objProjectRights.Insert(projectID, userID, view, createdBy, createdDate, modifiedBy, modifiedDate, isActive);
		}
		
		/// <summary>
		/// Selects all records from the ProjectRights table.
		/// </summary>
		public DataSet SelectAllByUserID(Int64 userID) {
			return objProjectRights.SelectAll(userID);
		}
		
	    /// <summary>
        /// Delete all records from the ProjectRights table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet DeleteAll(Int64 userID)
        {
            return objProjectRights.DeleteAll(userID);
        }
		#endregion
	}
}
