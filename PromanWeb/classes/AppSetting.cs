using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Proman.BLL;
using System.Data;
using System.IO;

namespace PromanWeb
{

    #region Enum
    /// <summary>
    /// Application Setting category
    /// </summary>
    public enum AppSettingCategory
    {
        General = 1,
        Mail = 2
    }
    #endregion

    /// <summary>
    /// This class handle all global application level settings
    /// </summary>
    public class AppSetting
    {
        #region Fields

        // Application Setting list
        private static List<AppSettingEntity> listAppSetting = null; 

        // Name of the application
        private static string applicationName = string.Empty;
        private static string applicationURL = string.Empty;
        private static string encryptionKey = string.Empty;

        // Datetime format to apply in the application
        private static string shortDateFormat = string.Empty;
        private static string longDateFormat = string.Empty;
        

        //user agent
       private static string userAgent = string.Empty; 

        //Default value of dropdownlists
        private static string projectOwner = "-Select Project Owner-";
        private static string projectClient = "-Select Project Client-";
        //Project image directory
        private static string projectImageDirectory = "~/projectimages";
        private static string profileImageDirectory = "~/profileimages";        
        private static string projectImageDirectoryAbsolutePath = string.Empty;
        private static string profileImageDirectoryAbsolutePath = string.Empty;         
        private static string projectImageSupportedFormat = ".jpeg,.jpg,.pdf";
        private static string profileImageSupportedFormat = ".jpeg,.jpg";
        private static string audioSupportedFormate = ".mp3";
        private static Int32 projectImageWidth = 150;
        private static Int32 projectImageHeight = 100;
        #endregion

        #region Properties
        /// <summary>
        /// Get name of the application
        /// </summary>
        public static string ApplicationName
        {
            get { return applicationName; }
        }

        /// <summary>
        /// Get name of the application url
        /// </summary>
        public static string ApplicationURL
        {
            get { return applicationURL; }
        }

        /// <summary>
        /// Get name of the application url
        /// </summary>
        public static string AudioSupportedFormate
        {
            get { return audioSupportedFormate; }
        }


        /// <summary>
        /// Get name of the Encryption Key
        /// </summary>
        public static string EncryptionKey
        {
            get { return encryptionKey; }
        }

        /// <summary>
        /// Get Short date time format
        /// </summary>
        public static string ShortDateFormat
        {
            get { return shortDateFormat; }
        }
       
      
        /// <summary>
        /// Get Long date time format
        /// </summary>
        public static string LongDateFormat
        {
            get { return longDateFormat; }
        }

        /// <summary>
        /// Get userAgent
        /// </summary>
        public static string UserAgent
        {
            get { return userAgent; }
        }
        /// <summary>
        /// Set ProjectOwner Default value
        /// </summary>
        public static string ProjectOwner
        {
            get { return projectOwner; }
        }
        ///<summary>
        ///Set ProjectClient Default Value
        /// </summary>
        public static string ProjectClient
        {
            get { return projectClient; }
        }

        /// <summary>
        /// Set projectImageDirectory Default value
        /// </summary>
        public static string ProjectImageDirectory
        {
            get { return projectImageDirectory; }
        }

         /// <summary>
        /// Set projectImageDirectory Default value
        /// </summary>
        public static string ProfileImageDirectory
        {
            get { return profileImageDirectory; }
        }
        
        /// <summary>
        /// Set projectImageDirectoryAbsolutePath Default value
        /// </summary>
        public static string ProjectImageDirectoryAbsolutePath
        {
            get { return projectImageDirectoryAbsolutePath; }
        }

        /// <summary>
        /// Set projectImageDirectoryAbsolutePath Default value
        /// </summary>
        public static string ProfileImageDirectoryAbsolutePath
        {
            get { return profileImageDirectoryAbsolutePath; }
        }
        /// <summary>
        /// Set projectImageSupportedFormat Default value
        /// </summary>
        public static string ProjectImageSupportedFormat
        {
            get { return projectImageSupportedFormat; }
        }
        /// <summary>
        /// Set projectImageSupportedFormat Default value
        /// </summary>
        public static string ProfileImageSupportedFormat
        {
            get { return profileImageSupportedFormat; }
        }
        /// <summary>
        /// Set projectImageWidth Default value
        /// </summary>
        public static Int32 ProjectImageWidth
        {
            get { return projectImageWidth; }
        }

        /// <summary>
        /// Set projectImageHeight Default value
        /// </summary>
        public static Int32 ProjectImageHeight
        {
            get { return projectImageHeight; }
        }
  
        #endregion

        #region Methodes
         /// <summary>
        /// Load application setting 
        /// </summary>
        public static bool LoadSetting()
        {
            // Name of the application
            applicationName = Convert.ToString(ConfigurationManager.AppSettings["ApplicationName"]);
            applicationURL = Convert.ToString(ConfigurationManager.AppSettings["ApplicationURL"]);
            encryptionKey = Convert.ToString(ConfigurationManager.AppSettings["EncryptionKey"]);

            // Datetime format used in the application
            longDateFormat = Convert.ToString(ConfigurationManager.AppSettings["LongDateFormat"]);
            shortDateFormat = Convert.ToString(ConfigurationManager.AppSettings["ShortDateFormat"]);
               
            //project image default values
            projectImageDirectory = Convert.ToString(ConfigurationManager.AppSettings["ProjectImageDirectory"]);
            projectImageDirectoryAbsolutePath = HttpContext.Current.Server.MapPath(projectImageDirectory);

            profileImageDirectory = Convert.ToString(ConfigurationManager.AppSettings["ProfileImageDirectory"]);
            profileImageDirectoryAbsolutePath = HttpContext.Current.Server.MapPath(ProfileImageDirectory);

            projectImageSupportedFormat = Convert.ToString(ConfigurationManager.AppSettings["ProjectImageSupportedFormat"]);
            projectImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ProjectImageWidth"]);
            projectImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["projectImageHeight"]);
             
            //Useragent
            userAgent = Convert.ToString(ConfigurationManager.AppSettings["UserAgent"]);

            // Load setting from database to application
            clsAppSetting objAppSetting = new clsAppSetting();

            DataSet ds = objAppSetting.SelectAll();

            if (Helper.HasRow(ds))
            {
                listAppSetting = null;
                listAppSetting = new List<AppSettingEntity>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listAppSetting.Add(new AppSettingEntity(Convert.ToInt32(dr["AppSettingId"]),
                                                            Convert.ToString(dr["Parameter"]),
                                                            Convert.ToString(dr["ParameterValue"]),
                                                            Convert.ToString(dr["Category"]),
                                                            Convert.ToString(dr["Description"])));
                }
            }

            ////Generate required folders
            //string path = GetSetting("UploadDirectory", AppSettingCategory.General);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //path = GetSetting("UploadTempDirectory", AppSettingCategory.General);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //path = GetSetting("UploadImageDirectory", AppSettingCategory.General);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //path = GetSetting("UploadTaskImageDirectory", AppSettingCategory.General);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            return true;
        }

        /// <summary>
        /// Get application level setting
        /// </summary>
        /// <returns></returns>
        public static string GetSetting(string parameter, AppSettingCategory category)
        {
            if (listAppSetting != null)
            {
                // Find Setting
                var appSetting = from setting in listAppSetting
                                 where setting.Parameter == parameter && setting.Category == Convert.ToString(category)
                                 select setting;

                // return the setting
                if (appSetting.First() != null)
                {
                    return appSetting.First().ParameterValue;
                }
            }
            
            // return details value
            return string.Empty;
        }

        #endregion
    }

    /// <summary>
    /// Application Setting Entity to hold each parameter values
    /// </summary>
    public class AppSettingEntity
    {
        #region Fields
        private Int32 appSettingId;
        private string parameter;
        private string parameterValue;
        private string category;
        private string description;
        #endregion

        #region Contructor
        /// <summary>
        /// Initializes a new instance of the clsAppSetting class.
		/// </summary>
        public AppSettingEntity(Int32 appSettingId, string parameter, string parameterValue, string category, string description)
        {
            this.appSettingId = appSettingId;
			this.parameter = parameter;
			this.parameterValue = parameterValue;
			this.category = category;
			this.description = description;
		}
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the appSettingId value.
        /// </summary>
        public Int32 AppSettingId
        {
            get { return appSettingId; }
            set { appSettingId = value; }
        }

        /// <summary>
        /// Gets or sets the Parameter value.
        /// </summary>
        public string Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        /// <summary>
        /// Gets or sets the ParameterValue value.
        /// </summary>
        public string ParameterValue
        {
            get { return parameterValue; }
            set { parameterValue = value; }
        }

        /// <summary>
        /// Gets or sets the Category value.
        /// </summary>
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        #endregion
        //end
    }
}