using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Proman.BLL;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;
namespace PromanWeb
{
    /// <summary>
    /// Summary description for ServiceUpdateTaskStatus
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceUpdateTaskStatus : System.Web.Services.WebService
    {
        [WebMethod]
        public void DeleteTask(Int64 taskID)
        {
            try
            {
                //Delete Task and its associated data First
                clsTask objTask = new clsTask();
                objTask.DeleteByService(taskID);

                //Now delete Documents attached to this task.
                if (Directory.Exists(HttpContext.Current.Server.MapPath("uploads/images/task/" + taskID)))
                {
                    try
                    {
                        string[] fileName = Directory.GetFiles(HttpContext.Current.Server.MapPath("uploads/images/task/" + taskID));
                        foreach (string name in fileName)
                        {
                            File.Delete(name);
                        }
                    }
                    //try { Directory.Delete(HttpContext.Current.Server.MapPath("uploads/images/task/" + taskID), true); }
                    catch { };
                }

                if (Directory.Exists(HttpContext.Current.Server.MapPath("uploads/audio/task/" + taskID)))
                {
                    try
                    {
                        string[] fileName = Directory.GetFiles(HttpContext.Current.Server.MapPath("uploads/images/task/" + taskID));
                        foreach (string name in fileName)
                        {
                            File.Delete(name);
                        }
                    }
                    //try { Directory.Delete(HttpContext.Current.Server.MapPath("uploads/images/task/" + taskID), true); }
                    catch { };
                }
            }
            catch { }
        }


        [WebMethod]
        public string InsertTaskComment(Int64 taskID, string comment, Int64 userID, Int64 projectID)
        {
            clsUsers objUser = new clsUsers(userID);
            // Add comment
            clsTaskComment objTaskComment = new clsTaskComment();

            objTaskComment.TaskId = taskID;
            objTaskComment.Comment = comment;
            objTaskComment.CreatedBy = userID;
            objTaskComment.Createddate = DateTime.Now;
            objTaskComment.ModifiedBy = 0;
            objTaskComment.ModifiedDate = DateTime.Now;

            objTaskComment.Insert();

            //John has userid 4 and jody has userid 5, if there is comment from this users then insert record in RecentTaskComment Table
            //If userid is not 4 or 5 then dont do anything regarding insert operation but if there are already record for this task id in RecentTaskComment
            //table then Remove all the Record from that table.

            clsRecentTaskComment objRecentComment = new clsRecentTaskComment();
            objRecentComment.TaskID = taskID;
            objRecentComment.CreatedBy = userID;
            objRecentComment.CreatedDate = DateTime.Now;
            objRecentComment.ModifedBy = userID;
            objRecentComment.ModifiedDate = DateTime.Now;
            objRecentComment.IsActive = true;

            if (userID == 4 || userID == 5)
            {    //Insert Record
                objRecentComment.Insert();
            }
            else
            {
                //Remove Record
                objRecentComment.Delete();
            }


            //Send mail to the client when task is completed
            //Retrive project related information 

            clsProject objProjectClient = new clsProject();
            DataSet dsProjectClient = objProjectClient.Select(Convert.ToInt64(projectID));
            clsTask objTask = new clsTask();
            DataSet dsTask = objTask.Select(Convert.ToInt64(taskID));

            //Create mailer object and send the mail
            Mailer objMailer = new Mailer(true);

            //Send Update Mail To all the Group User,Select all record from task user table
            //based on taskid
            clsTaskUser objTaskUser = new clsTaskUser();
            DataSet dsTaskUser = objTaskUser.SelectAll(taskID);

            foreach (DataRow drTask in dsTaskUser.Tables[0].Rows)
            {
                string componentName = string.Empty;
                if (drTask["ComponentName"] != null)
                {
                    componentName = drTask["ComponentName"].ToString();
                }
                string wfNumber = string.Empty;
                if (drTask["WireframeNo"] != null)
                {
                    wfNumber = drTask["WireframeNo"].ToString();
                }

                if (drTask["UserName"].ToString() != string.Empty)
                {
                    try
                    {
                        objMailer.SendClientTaskCommentMail(drTask["UserName"].ToString(), taskID, dsTask.Tables[0].Rows[0]["ProjectName"].ToString(), Helper.getTaskStatus(Convert.ToInt64(dsTask.Tables[0].Rows[0]["TaskStatus"])), drTask["FullName"].ToString(), dsTask.Tables[0].Rows[0]["Title"].ToString(), Convert.ToDateTime(dsTask.Tables[0].Rows[0]["DueDate"]), dsTask.Tables[0].Rows[0]["TaskOwnerName"].ToString(), objUser.FirstName, objUser.LastName, comment, wfNumber, componentName);
                    }
                    catch { }
                }
            }

            // Bind Comments
            clsTaskComment objTaskComment1 = new clsTaskComment();
            DataSet ds = objTaskComment1.SelectAllByTaskId(taskID);

            ds.Tables[0].Columns.Add("ImageString", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["ImageCount"]) != 0)
                {
                    dr["ImageString"] = GetCommentImageString(Convert.ToInt64(dr["TaskCommentId"]), taskID);
                }
            }

            string stream = GetJson(ds.Tables[0]);
            return stream;
        }

        [WebMethod]
        public string GetTaskImage(Int64 taskID)
        {
            clsTaskImages objTaskimages = new clsTaskImages();
            DataSet dsimages = objTaskimages.SelectAllByTaskId(taskID);

            string stream = GetJsonforImage(dsimages.Tables[0], taskID);
            return stream;
        }


        [WebMethod]
        public string GetTaskComment(Int64 taskID)
        {
            // Bind Comments
            clsTaskComment objTaskComment = new clsTaskComment();
            DataSet ds = objTaskComment.SelectAllByTaskId(taskID);
            ds.Tables[0].Columns.Add("ImageString", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["ImageCount"]) != 0)
                {
                    dr["ImageString"] = GetCommentImageString(Convert.ToInt64(dr["TaskCommentId"]), taskID);
                }
            }

            string stream = GetJson(ds.Tables[0]);
            return stream;
        }

        /// <summary>
        /// Get String Image Comment
        /// </summary>
        /// <returns></returns>
        public string GetCommentImageString(Int64 taskCommentID, Int64 taskID)
        {
            string imageString = string.Empty;
            clsTaskCommentImage objTaskCommentImage = new clsTaskCommentImage();
            DataSet ds = objTaskCommentImage.SelectByTaskCommentID(Convert.ToInt64(taskCommentID));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                imageString += "<a class=\"taskimagesajaxhref\" target=\"_blank\" href=\"" + Helper.GetTaskImage(taskID, dr["ImageName"].ToString()).Replace("~/", "") + "\">" + "<img class=\"taskimagesajax\" src=\"" + Helper.GetTaskImage1(taskID, dr["ImageName"].ToString()).Replace("~/", "") + "\"/>" + "</a>";
            }
            return imageString;
        }

        public string GetJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
            Dictionary<string, string> row = null;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, string>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public string GetJsonforImage(DataTable dt, Int64 taskID)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
            Dictionary<string, string> row = null;

            //foreach (DataRow dr in dsimages.Tables[0].Rows)
            //{

            //    stream += "<a href=\"" + Helper.GetTaskImage(taskID, dr["ImageName"].ToString()) + "\">" + "<img alt=\"taskimage\" src=\"" + Helper.GetTaskImage1(taskID, dr["ImageName"].ToString()) + "\">" + "</a>";

            //}

            //return stream;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, string>();
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "ImageName")
                    {
                        row.Add("ImageURL", "<a class=\"taskimagesajaxhref\" target=\"_blank\" href=\"" + Helper.GetTaskImage(taskID, dr[col].ToString()).Replace("~/", "") + "\">" + "<img class=\"taskimagesajax\" src=\"" + Helper.GetTaskImage1(taskID, dr[col].ToString()).Replace("~/", "") + "\"/>" + "</a>");
                    }
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        [WebMethod]
        public void UpdateStatus(Int64 taskID, Int64 userID, Int32 percentage, Int64 projectID)
        {
            clsTaskStatus objTaskStatus = new clsTaskStatus();
            objTaskStatus.TaskId = taskID;
            objTaskStatus.PercentComplete = percentage;
            objTaskStatus.CreatedBy = userID;
            objTaskStatus.CreatedDate = DateTime.Now;
            objTaskStatus.ModifiedDate = DateTime.Now;

            //Insert Record
            objTaskStatus.Insert();


            // Add comment regarding the status
            clsTaskComment objTaskComment = new clsTaskComment();

            objTaskComment.TaskId = taskID;
            objTaskComment.Comment = string.Format("<span class='{0}'>{1}</span>", "green-color-bold", "Task completion status: " + Helper.getTaskStatus(percentage));
            objTaskComment.CreatedBy = userID;
            objTaskComment.Createddate = DateTime.Now;
            objTaskComment.ModifiedBy = 0;
            objTaskComment.ModifiedDate = DateTime.Now;
            objTaskComment.Insert();

            //John has userid 4 and jody has userid 5, if there is comment from this users then insert record in RecentTaskComment Table
            //If userid is not 4 or 5 then dont do anything regarding insert operation but if there are already record for this task id in RecentTaskComment
            //table then Remove all the Record from that table.

            clsRecentTaskComment objRecentComment = new clsRecentTaskComment();
            objRecentComment.TaskID = taskID;
            objRecentComment.CreatedBy = userID;
            objRecentComment.CreatedDate = DateTime.Now;
            objRecentComment.ModifedBy = userID;
            objRecentComment.ModifiedDate = DateTime.Now;
            objRecentComment.IsActive = true;

            if (userID == 4 || userID == 5)
            {    //Insert Record
                objRecentComment.Insert();
            }
            else
            {
                //Remove Record
                objRecentComment.Delete();
            }



            //If User Check status to 100% then Dynamically Update Status of task to closed in database and Check the Closed radio button,and hide Task Detail Division
            //check if user ckech status to 100% or not
            if (percentage == 100)
            {

                clsTask objTask = new clsTask();


                //adding comment
                string comment = string.Format("<span class='{0}'>{1}</span>", "blue-color-bold", "Task Status changed to Closed");
                clsTaskComment objTaskComment1 = new clsTaskComment();
                objTaskComment1.TaskId = taskID;
                objTaskComment1.Comment = comment;
                objTaskComment1.CreatedBy = userID;
                objTaskComment1.Createddate = DateTime.Now;
                objTaskComment1.ModifiedBy = 0;
                objTaskComment1.ModifiedDate = DateTime.Now;
                objTaskComment1.Insert();


                //Send mail to the client when task is 100% completed

                //Retrive project related information 
                clsProject objProjectClient = new clsProject();
                DataSet dsProjectClient = objProjectClient.Select(Convert.ToInt64(projectID));

                //Retrive task related information
                clsTask objTaskClient = new clsTask();

                //Create mailer object and send the mail
                Mailer objMailer = new Mailer(true);
                DataSet dsTaskClient = objTaskClient.Select(Convert.ToInt64(taskID.ToString()));

                string compNo = string.Empty;
                if (dsTaskClient.Tables[0].Rows[0]["ComponentName"] != null)
                    compNo = dsTaskClient.Tables[0].Rows[0]["ComponentName"].ToString();
                try
                {
                    if (dsProjectClient.Tables[0].Rows[0]["UserName"].ToString() != string.Empty)
                        objMailer.SendClientEndTaskMail(dsProjectClient.Tables[0].Rows[0]["UserName"].ToString(), dsProjectClient.Tables[0].Rows[0]["ProjectName"].ToString(), taskID, dsTaskClient.Tables[0].Rows[0]["WireframeNo"].ToString(), dsTaskClient.Tables[0].Rows[0]["Title"].ToString(), dsProjectClient.Tables[0].Rows[0]["FullName"].ToString(), compNo);
                }
                catch { }


            }

            else
            {

                try
                {

                    //Retrive task related information
                    clsTask objTaskClient = new clsTask();

                    //Create mailer object and send the mail
                    DataSet dsTaskClient = objTaskClient.Select(Convert.ToInt64(taskID.ToString()));


                    //Send Update Mail To all the Group User,Select all record from task user table
                    //based on taskid
                    clsTaskUser objTaskUser = new clsTaskUser();
                    DataSet dsTaskUser = objTaskUser.SelectAll(taskID);
                    clsUsers objuser = new clsUsers(userID);
                    Mailer objMailer1 = new Mailer(true);
                    foreach (DataRow drTask in dsTaskUser.Tables[0].Rows)
                    {
                        string compno = string.Empty;
                        string wfno = string.Empty;
                        if (drTask["WireframeNo"] != null)
                        {
                            wfno = drTask["WireframeNo"].ToString();
                        }
                        if (drTask["ComponentName"] != null)
                        {
                            compno = drTask["ComponentName"].ToString();
                        }
                        if (dsTaskUser.Tables[0].Rows[0]["UserName"].ToString() != string.Empty)
                        {
                            objMailer1.SendTaskUpdateMail(drTask["UserName"].ToString(), taskID, dsTaskClient.Tables[0].Rows[0]["ProjectName"].ToString(), Helper.getTaskStatus(Convert.ToInt64(percentage)), drTask["FullName"].ToString(), dsTaskClient.Tables[0].Rows[0]["Title"].ToString(), Convert.ToDateTime(dsTaskClient.Tables[0].Rows[0]["DueDate"].ToString()), dsTaskClient.Tables[0].Rows[0]["TaskOwnerName"].ToString(), objuser.FirstName, objuser.LastName, "", wfno, compno);
                        }
                    }
                }
                catch { }
            }
        }
    }
}
