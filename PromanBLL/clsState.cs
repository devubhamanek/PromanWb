using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL
{
    public sealed class clsState
    {
        #region Fields
        DAL.clsState objState = new DAL.clsState();
        private Int64 stateId;
        private Int64 countryId;
        private string name;
        private string code;
        private Int64 displayOrder;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the State class.
        /// </summary>
        public clsState()
        {
        }

        /// <summary>
        /// Initializes a new instance of the State class.
        /// </summary>
        public clsState(Int64 countryId, string name, string code, Int64 displayOrder, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.countryId = countryId;
            this.name = name;
            this.code = code;
            this.displayOrder = displayOrder;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }

        /// <summary>
        /// Initializes a new instance of the State class.
        /// </summary>
        public clsState(Int64 stateId, Int64 countryId, string name, string code, Int64 displayOrder, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.stateId = stateId;
            this.countryId = countryId;
            this.name = name;
            this.code = code;
            this.displayOrder = displayOrder;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the StateId value.
        /// </summary>
        public Int64 StateId
        {
            get { return stateId; }
            set { stateId = value; }
        }

        /// <summary>
        /// Gets or sets the CountryId value.
        /// </summary>
        public Int64 CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the Code value.
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// Gets or sets the DisplayOrder value.
        /// </summary>
        public Int64 DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
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
        /// Saves a record to the State table.
        /// </summary>
        public Int64 Insert()
        {
            return objState.Insert(countryId, name, code, displayOrder, createdBy, createddate, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Updates a record in the State table.
        /// </summary>
        public void Update()
        {
            objState.Update(stateId, countryId, name, code, displayOrder, createdBy, createddate, modifiedBy, modifiedDate);
        }

        /// <summary>
        /// Deletes a record from the State table by its primary key.
        /// </summary>
        public void Delete()
        {
            objState.Delete(stateId);
        }

        /// <summary>
        /// Deletes a record from the State table by a foreign key.
        /// </summary>
        public void DeleteByCountryId(Int64 countryId)
        {
            objState.DeleteByCountryId(countryId);
        }

        /// <summary>
        /// Selects a single record from the State table.
        /// </summary>
        public DataSet Select(Int64 stateId)
        {

            return objState.Select(stateId);
        }

        /// <summary>
        /// Selects all records from the State table.
        /// </summary>
        public DataSet SelectAll()
        {
            return objState.SelectAll();

        }

        /// <summary>
        /// Selects all records from the State table by a foreign key.
        /// </summary>
        public DataSet SelectByCountryId(Int64 countryId)
        {
            return objState.SelectByCountryId(countryId);
        }



        #endregion
    }
}
