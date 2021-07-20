using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromanWeb
{
    /// <summary>
    /// This class is responsible to hold the temp storage for images
    /// </summary>
    [Serializable()]
    public class ImageEntity
    {
        #region Fields
        private Int64 taskImagesId;
        private string originalImageFileName;
        private string imageName;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ImageID value.
        /// </summary>
        public Int64 TaskImagesId
        {
            get { return taskImagesId; }
            set { taskImagesId = value; }
        }

        /// <summary>
        /// Gets or sets the OriginalImageFileName value.
        /// </summary>
        public string OriginalImageFileName
        {
            get { return originalImageFileName; }
            set { originalImageFileName = value; }
        }

        /// <summary>
        /// Gets or sets the ImageFileName value.
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        #endregion
    }
}