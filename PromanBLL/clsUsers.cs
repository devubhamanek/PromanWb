using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL
{
    public sealed class clsUsers
    {
        #region Fields
        DAL.clsUsers objUsers = new DAL.clsUsers();
        private Int64 userId;
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private int roleId;
        private string imageName;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        private bool isActive;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public clsUsers()
        {
        }
        public clsUsers(Int64 userId)
        {
            MakeUser(Select(userId));
        }
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public clsUsers(string firstName, string lastName, string userName, string password, int roleId,string imageName ,Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.roleId = roleId;
            this.ImageName = imageName;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public clsUsers(Int64 userId, string firstName, string lastName, string userName, string password, int roleId,string imageName ,Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, bool isActive)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.roleId = roleId;
            this.ImageName = imageName;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
            this.isActive = isActive;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the UserId value.
        /// </summary>
        public Int64 UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// Gets or sets the FirstName value.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Gets or sets the LastName value.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Gets or sets the UserName value.
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Gets or sets the Password value.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets or sets the RoleId value.
        /// </summary>
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        /// <summary>
        /// Gets or sets the FirstName value.
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

        /// <summary>
        /// Gets or sets the IsActive value.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the Users table.
        /// </summary>
        public Int64 Insert()
        {
            return objUsers.Insert(firstName, lastName, userName, password, roleId, imageName ,createdBy, createddate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Updates a record in the Users table.
        /// </summary>
        public void Update()
        {
            objUsers.Update(userId, firstName, lastName, userName, password, roleId,imageName , createdBy, createddate, modifiedBy, modifiedDate, isActive);
        }

        /// <summary>
        /// Deletes a record from the Users table by its primary key.
        /// </summary>
        public void Delete()
        {
            objUsers.Delete(userId);
        }

        /// <summary>
        /// Deletes a record from the Users table by a foreign key.
        /// </summary>
        public void DeleteAllByRoleId(int roleId)
        {
            objUsers.DeleteByRoleId(roleId);
        }

        /// <summary>
        /// Selects a single record from the Users table.
        /// </summary>
        public DataSet Select(Int64 userId)
        {
            return objUsers.Select(userId);
        }


        /// <summary>
        /// Selects all records from the Users table.
        /// </summary>
        public DataSet SelectAll(Int64 roleId)
        {
            return objUsers.SelectAll(roleId);
        }

        /// <summary>
        /// Selects all records from the Users table.
        /// </summary>
        public DataSet SelectAllUsers()
        {
            return objUsers.SelectAllUsers();
        }

        /// <summary>
        /// Selects all records from the Users table by a foreign key.
        /// </summary>
        public DataSet SelectAllByRoleId(int roleId)
        {
            return objUsers.SelectByRoleId(roleId);
        }

        /// <summary>
        /// Selects a single record from the Users table.
        /// </summary>
        public DataSet SelectAllByRoleId(Int32 superAdminRoleId, Int32 projectManagerRoleId)
        {
            return objUsers.SelectByRoleId(superAdminRoleId, projectManagerRoleId);
        }
        /// <summary>
        /// Selects single record from table using username and password
        /// </summary>
        public DataSet SelectByUsernameandPassword(string userName, string password)
        {
            return objUsers.SelectByUsernameandPassword(userName, password);
        }

        /// <summary>
        /// Creates a new instance of the Users class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeUser(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["UserId"] != DBNull.Value)
            {
                this.UserId = Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]);
            }
            if (ds.Tables[0].Rows[0]["FirstName"] != DBNull.Value)
            {
                this.FirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
            }
            if (ds.Tables[0].Rows[0]["LastName"] != DBNull.Value)
            {
                this.LastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
            }
            if (ds.Tables[0].Rows[0]["UserName"] != DBNull.Value)
            {
                this.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            }
            if (ds.Tables[0].Rows[0]["Password"] != DBNull.Value)
            {
                this.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
            }
            if (ds.Tables[0].Rows[0]["RoleId"] != DBNull.Value)
            {
                this.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"]);
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
            if (ds.Tables[0].Rows[0]["IsActive"] != DBNull.Value)
            {
                this.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
            }
        }
        /// <summary>
        /// This function check in database if username is exists or not in database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Exists(string userName, Int64 userId)
        {
            return objUsers.Exists(userName, userId);
        }


        public void UpdateProfileImage(Int64 userid, string image)
        {
            objUsers.UpdateProfileImage(userid, image);
        }
        /// <summary>
        /// This function check in database if username is exists or not in database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Exists(string userName)
        {
            return objUsers.Exists(userName);
        }
        /// <summary>
        /// This function check in database if user is exists or not in any project or task.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string CheckUser(Int64 userId)
        {
            return objUsers.CheckUser(userId);
        }
        #endregion
    }
}
