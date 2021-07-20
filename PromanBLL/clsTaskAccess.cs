using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL 
{
	public sealed class clsTaskAccess 
    {
		#region Fields
        DAL.clsTaskAccess objTaskAccess = new DAL.clsTaskAccess();
		private Int64 taskId;
		private int roleId;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the TaskAccess class.
		/// </summary>
		public clsTaskAccess() {
		}
		
		/// <summary>
		/// Initializes a new instance of the TaskAccess class.
		/// </summary>
        public clsTaskAccess(Int64 taskId, int roleId)
        {
			this.taskId = taskId;
			this.roleId = roleId;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TaskId value.
		/// </summary>
		public Int64 TaskId {
			get { return taskId; }
			set { taskId = value; }
		}
		
		/// <summary>
		/// Gets or sets the RoleId value.
		/// </summary>
		public int RoleId {
			get { return roleId; }
			set { roleId = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the TaskAccess table.
		/// </summary>
		public void Insert() {
			objTaskAccess.Insert(taskId, roleId);
		}
		
        /// <summary>
        /// Inserts multiple record into the TaskAccess table.
        /// <summary>
        public void InsertMultiple(Int64 taskId, string roleIds)
        {
            objTaskAccess.InsertMultiple(taskId, roleIds);
        }
		/// <summary>
		/// Deletes a record from the TaskAccess table by a foreign key.
		/// </summary>
		public  void DeleteAllByTaskId(Int64 taskId) {
            objTaskAccess.DeleteByTaskId(taskId); 
		}
		
		/// <summary>
		/// Deletes a record from the TaskAccess table by a foreign key.
		/// </summary>
		public void DeleteAllByRoleId(int roleId) {
            objTaskAccess.DeleteByRoleId(roleId); 
		}
		
		/// <summary>
		/// Selects all records from the TaskAccess table by a foreign key.
		/// </summary>
		public DataSet SelectAllByTaskId(Int64 taskId) {
            return objTaskAccess.SelectByTaskId(taskId);  
		}
		
		/// <summary>
		/// Selects all records from the TaskAccess table by a foreign key.
		/// </summary>
		public DataSet SelectAllByRoleId(int roleId) {
            return objTaskAccess.SelectByRoleId(roleId); 
		}
		
		/// <summary>
		/// Creates a new instance of the TaskAccess class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private void MakeTaskAccess(DataSet ds) {

            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
			}
            if (ds.Tables[0].Rows[0]["RoleId"] != DBNull.Value)
            {
                  this.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"]);
			}
		}
		#endregion
	}
}
