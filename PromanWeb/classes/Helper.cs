using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Proman.BLL;


namespace PromanWeb
{
    /// <summary>
    /// This class holds the helper functions used in the application
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// This is for Project Delete,Disable Link if There is task associated with this Project
        /// </summary>
        /// <param name="taskCount"></param>
        /// <returns></returns>
        public static bool IsEnableDeleteLink(Int64 taskCount)
        {
            if (taskCount > 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This is for Project Delete,Disable Link if There is task associated with this Project
        /// </summary>
        /// <param name="taskCount"></param>
        /// <returns></returns>
        public static System.Drawing.Color DisableLinkColor(Int64 taskCount)
        {
            if (taskCount > 0)
                return System.Drawing.Color.Gray;
            else
              return System.Drawing.Color.Blue;
        }

        /// <summary>
        /// This is for Project Delete,Disable Link if There is task associated with this Project
        /// </summary>
        /// <param name="taskCount"></param>
        /// <returns></returns>
        public static string DisableLinkConfirmation(Int64 taskCount)
        {
            if (taskCount > 0)
                return "return false;";
            else
                return "return confirm('Are you sure you want to delete this project?');";
        }


        /// <summary>
        /// Show message to user
        /// </summary>
        /// <param name="messageToShow"></param>
        /// <param name="messageType"></param>
        public static void ShowMessage(ref Label lblStatus, string messageToShow, MessageType messageType)
        {
            lblStatus.Text = messageToShow;
            if (messageType == MessageType.Information)
            {
                lblStatus.CssClass = "lbl-info";

            }
            else if (messageType == MessageType.Success)
            {
                lblStatus.CssClass = "lbl-message";
            }
            else
            {
                lblStatus.CssClass = "lbl-error";
            }
        }

        public static string clientDateFormate(DateTime dt)
        {
            return dt.ToString("MM-dd-yyyy hh:mm tt");
        }

        public static string getTaskStatus(Int64 percentageComplete)
        {
            switch (percentageComplete)
            {
                case 0:
                    return "Open";


                case 14:
                    return "Open";


                case 28:
                    return "Discuss";


                case 42:
                    return "In Programming";


                case 56:
                    return "Ready For Test";


                case 70:
                    return "Bug Found";


                case 84:
                    return "Bug Fixed";


                case 100:
                    return "Closed";


                default:
                    return "Open";


            }
        }
        /// <summary>
        /// This function check if the dataset has the row or not
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool HasRow(DataSet ds)
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This function return the file name based on date
        /// </summary>
        /// <returns></returns>
        public static string GetFileName(string fileExtention)
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtention;
        }

        /// <summary>
        /// This function return the file name based on date
        /// </summary>
        /// <returns></returns>
        public static string GetTaskAudioFileName(string fileExtention)
        {
            return "a" + DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtention;
        }

        /// <summary>
        /// return path of project images
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="wantAbsolutePath"></param>
        /// <returns></returns>
        public static string GetProjectImageFile(string fileName, bool wantAbsolutePath)
        {

            if (wantAbsolutePath)
            {
                return Path.Combine(AppSetting.ProjectImageDirectoryAbsolutePath, fileName);
            }
            else
            {
                return string.Format("{0}/{1}", AppSetting.ProjectImageDirectory, fileName);
            }
        }
        /// <summary>
        /// return path of project images
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="wantAbsolutePath"></param>
        /// <returns></returns>
        public static string GetProfileImageFile(string fileName, bool wantAbsolutePath)
        {

            if (wantAbsolutePath)
            {
                return Path.Combine(AppSetting.ProfileImageDirectoryAbsolutePath, fileName);
            }
            else
            {
                return string.Format("{0}/{1}", AppSetting.ProfileImageDirectory, fileName);
            }
        }



        /// <summary>
        /// Delete project image
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteProjectImages(string fileName)
        {
            string path = GetProjectImageFile(fileName, true);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        } 

        /// <summary>
        /// Delete project image
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteProfileImages(string fileName)
        {
            string path = GetProfileImageFile(fileName, true);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }

        /// <summary>
        /// Get Task Image
        /// </summary>
        /// <param name="taskId">ID of the task</param>
        /// <param name="imageName">Name of the image</param>
        /// <returns></returns>
        public static string GetTaskImage(Int64 taskId, string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                return string.Empty;

            //string path = string.Format("{0}/{1}", AppSetting.GetSetting("UploadTaskImageDirectory", AppSettingCategory.General), taskId);
            //if (!Directory.Exists(path))
            //{ Directory.CreateDirectory(path); }
            if (taskId > 0)
            {
                return string.Format("{0}/{1}/{2}", AppSetting.GetSetting("UploadTaskImageDirectory", AppSettingCategory.General), taskId, imageName);
            }
            else
            {
                return string.Format("{0}/{1}", AppSetting.GetSetting("UploadTempDirectory", AppSettingCategory.General), imageName);
            }
        }

        /// <summary>
        /// Get Task Image
        /// </summary>
        /// <param name="taskId">ID of the task</param>
        /// <param name="imageName">Name of the image</param>
        /// <returns></returns>
        public static string GetTaskImageFolderForDelete(Int64 taskId)
        {
            if (taskId > 0)
            {
               return string.Format("{0}/{1}",AppSetting.GetSetting("UploadTaskImageDirectory", AppSettingCategory.General), taskId);
            }
            else
            {
                return string.Format("{0}/{1}", AppSetting.GetSetting("UploadTempDirectory", AppSettingCategory.General));
            }
        }


        public static void DeleteProject(Int64 ProjectId)
        {
            //Delete Document related to Project 
            //Delete Project Image First
            clsProject objProject = new clsProject(ProjectId);
            string path = Helper.GetProjectImageFile(objProject.Avatar, true);
            if (File.Exists(path))
                File.Delete(path);

            //Delete TaskImages
            clsTask objTask = new clsTask();
            DataSet ds = objTask.SelectAllByProjectId(ProjectId);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string pathTask =  Helper.GetTaskImageFolderForDelete(Convert.ToInt64(dr["TaskId"])).Replace("~/","");
                //if (Directory.Exists(pathTask))
                try { Directory.Delete(pathTask); }
                catch { }
                string pathAudio = pathTask.Replace("images", "audio");
                if (Directory.Exists(pathAudio))
                    Directory.Delete(pathAudio);
            }

            //Delete All the Records From Database for that Project
           // objProject.DeleteManual(ProjectId);
        }
        /// <summary>
        /// Get Task Image
        /// </summary>
        /// <param name="taskId">ID of the task</param>
        /// <param name="imageName">Name of the image</param>
        /// <returns></returns>
        public static string GetTaskImage1(Int64 taskId, string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                return string.Empty;

            if (imageName.Contains(".pdf"))
            {
                return "images/pdficon.png";
            }
            else if (imageName.Contains(".doc") || imageName.Contains(".docx"))
            {
               return "images/wordIcon.jpg";
            }

            else if (imageName.Contains(".xls") || imageName.Contains(".xlsx"))
            {
                return "images/excelicon.jpg";
            }
            else if (!imageName.Contains(".jpeg") && !imageName.Contains(".jpg") && !imageName.Contains(".png"))
            {
                return "images/psdicon.png";
            }
            else
                return string.Format("{0}/{1}/{2}", AppSetting.GetSetting("UploadTaskImageDirectory", AppSettingCategory.General), taskId, imageName);

        }

        /// <summary>
        /// Get Task Audio
        /// </summary>
        /// <param name="taskId">ID of the task</param>
        /// <param name="imageName">Name of the image</param>
        /// <returns></returns>
        public static string GetTaskAudio(string audioName)
        {
            if (string.IsNullOrEmpty(audioName))
                return string.Empty;

            return string.Format("{0}/{1}", AppSetting.GetSetting("UploadTempDirectory", AppSettingCategory.General), audioName);
        }
  /// <summary>
    /// Write a log file
    /// </summary>
    /// <param name="messageToLog"></param>
    public static void Log(string messageToLog)
    {
        StreamWriter streamWriter = null;

        try
        {
            string strPath = HttpContext.Current.Server.MapPath(Convert.ToString(AppSetting.GetSetting("LogFilePath", AppSettingCategory.General)));

            if (!File.Exists(strPath))
                streamWriter = new StreamWriter(strPath);
            else
                streamWriter = File.AppendText(strPath);

            streamWriter.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(AppSetting.GetSetting("LongDateFormat", AppSettingCategory.General)), messageToLog) + Environment.NewLine);
        }
        catch (Exception)
        {
            // Do nothing if any error occur as error can be occur if 
            // Code that runs when an unhandled error occurs
            //Exception objErr = HttpContext.Current.Server.GetLastError().GetBaseException();

            ////Insert Error Log in DB
            //Common objCommon = new Common();
            //objCommon.ErrorLog(HttpContext.Current.Request.Url.ToString(), objErr.Message, "Source: " + objErr.Source + " StackTrace: " + objErr.StackTrace, "Application_Error");

            //Mailer objMailer = new Mailer(true);
            //objMailer.SendMailWhenErrorOccured("<b>URL:</b>" + HttpContext.Current.Request.Url.ToString() + "<br><br> <b>Message:</b> " + objErr.Message + " <br> " + "<br><br><b>Source:</b> " + objErr.Source + " <br>" + "<br><br><b>StackTrace:</b> " + objErr.StackTrace);
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }
    }

    }
}