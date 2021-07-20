using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromanWeb
{
    /// <summary>
    /// This class hold the Module of project 
    /// </summary>
    [Serializable()]
    public class ModuleEntity
    {
        #region Fields
        private Int64 moduleId;
        private string moduleName;
        private DateTime createdDate;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the moduleId value.
        /// </summary>
        public Int64 ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        /// <summary>
        /// Gets or sets the moduleName value.
        /// </summary>
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        /// <summary>
        /// Gets or sets the createdDate value.
        /// </summary>
        public DateTime Createddate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }


        #endregion

    }
}