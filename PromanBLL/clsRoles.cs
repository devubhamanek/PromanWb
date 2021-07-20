using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL 
{
	public sealed class clsRoles 
    {
		#region Fields
        DAL.clsRoles objRoles  = new DAL.clsRoles();  
		private int roleId;
		private string roleName;
		private int displayOrder;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the Role class.
		/// </summary>
		public clsRoles(Int32 roleID) {
            MakeRole(Select(roleID));
		}

        public clsRoles()
        { }
		/// <summary>
		/// Initializes a new instance of the Role class.
		/// </summary>
		public clsRoles(string roleName, int displayOrder) {
			this.roleName = roleName;
			this.displayOrder = displayOrder;
		}
		
		/// <summary>
		/// Initializes a new instance of the Role class.
		/// </summary>
        public clsRoles(int roleId, string roleName, int displayOrder)
        {
			this.roleId = roleId;
			this.roleName = roleName;
			this.displayOrder = displayOrder;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the RoleId value.
		/// </summary>
		public int RoleId {
			get { return roleId; }
			set { roleId = value; }
		}
		
		/// <summary>
		/// Gets or sets the RoleName value.
		/// </summary>
		public string RoleName {
			get { return roleName; }
			set { roleName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayOrder value.
		/// </summary>
		public int DisplayOrder {
			get { return displayOrder; }
			set { displayOrder = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the Roles table.
		/// </summary>
		public Int32 Insert() {
            return objRoles.Insert(roleName, displayOrder);
		}
		
		/// <summary>
		/// Updates a record in the Roles table.
		/// </summary>
		public void Update() {
			objRoles.Update(roleId, roleName, displayOrder);
		}
		
		/// <summary>
		/// Deletes a record from the Roles table by its primary key.
		/// </summary>
		public void Delete() {
            objRoles.Delete(roleId);
		}
		
		/// <summary>
		/// Selects a single record from the Roles table.
		/// </summary>
		public DataSet Select(int roleId) {
            return objRoles.Select(roleId);
		}
		
		/// <summary>
		/// Selects all records from the Roles table.
		/// </summary>
		public DataSet SelectAll() {
            return objRoles.SelectAll(); 
		}
		
		/// <summary>
		/// Creates a new instance of the Roles class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private void  MakeRole(DataSet ds) {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["RoleId"] != DBNull.Value)
            {
                this.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"]);
			}
            if (ds.Tables[0].Rows[0]["RoleName"] != DBNull.Value)
            {
                this.RoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
			}
            if (ds.Tables[0].Rows[0]["DisplayOrder"] != DBNull.Value)
            {
                this.DisplayOrder = Convert.ToInt32(ds.Tables[0].Rows[0]["DisplayOrder"]);
			}

			
		}
		#endregion
	}
}
