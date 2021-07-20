using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromanWeb
{
    /// <summary>
    /// This class hold the Component of project 
    /// </summary>
    [Serializable()]

    public class ComponentEntiry
    {
        #region Fileds
        private Int64 componentId;
        private string componentName;
        private Int64  moduleId;
        private DateTime createddate;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ComponentID value.
        /// </summary>
        public Int64 ComponentId
        {
            get { return componentId ; }
            set { componentId  = value; }
        }

        /// <summary>
        /// Gets or sets the moduleId value.
        /// </summary>
        public Int64 ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        /// <summary>
        /// Gets or sets the componentName value.
        /// </summary>
        public string ComponentName
        {
            get { return componentName ; }
            set { componentName = value; }
        }

        /// <summary>
        /// Gets or sets the createdDate value.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return createddate; }
            set { createddate = value; }
        }
        #endregion
    }
}