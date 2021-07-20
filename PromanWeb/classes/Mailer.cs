using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using Proman.BLL;
using System.Data;
using System.Net;
using System.Net.Mime;
using System.IO;
using System.Collections;

namespace PromanWeb
{
    /// <summary>
    /// Send mail using SMTP server
    /// </summary>
    public class Mailer
    {
        // Properties
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public Int32 SmtpPort { get; set; }
        public bool IsBodyHtml { get; set; }
        public string[] Attachments { get; set; }

        public bool IsMailSent { get; set; }
        public string ErrorMessage { get; set; }

        public Mailer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Mailer(bool useAppSetting)
        {
            // Load application level settings
            if (useAppSetting)
            {
                this.From = AppSetting.GetSetting("MailFrom", AppSettingCategory.Mail);
                this.To = AppSetting.GetSetting("MailTo", AppSettingCategory.Mail);
                this.SmtpServer = AppSetting.GetSetting("SmtpServer", AppSettingCategory.Mail);
                this.SmtpUserName = AppSetting.GetSetting("SmtpUserName", AppSettingCategory.Mail);
                this.SmtpPassword = AppSetting.GetSetting("SmtpPassword", AppSettingCategory.Mail);
                this.SmtpPort = Convert.ToInt32(AppSetting.GetSetting("SmtpPort", AppSettingCategory.Mail));
                this.IsBodyHtml = true;
            }
        }

        /// <summary>
        /// Function to send mail
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Receiver Address</param>
        /// <param name="subject">Subject of the mail</param>
        /// <param name="body">Body of the mail</param>
        /// <param name="smtpServer">SMTP server name</param>
        /// <param name="smtpUserName">Username of SMTP server</param>
        /// <param name="smtpPassword">Password of SMTP Server</param>
        /// <param name="smtpPort">Port on which SMTP server is running</param>
        /// <param name="isBodyHtml">Format of the mail - Text or HTML</param>
        /// <returns></returns>
        public bool SendMail(string from, string to, string subject, string body, string smtpServer, string smtpUserName, string smtpPassword, Int32 smtpPort = 25, bool isBodyHtml = true)
        {
            // Set properties
            this.From = from;
            this.To = to;
            this.Subject = subject;
            this.Body = body;
            this.IsBodyHtml = isBodyHtml;
            this.SmtpServer = smtpServer;
            this.SmtpUserName = smtpUserName;
            this.SmtpPassword = smtpPassword;
            this.SmtpPort = smtpPort;

            // Send mail
            return SendMail();
        }

        /// <summary>
        /// Function to send mail
        /// </summary>
        /// <returns></returns>
        public bool SendMail()
        {
            //try
            //{
            // Prepare Mail Message object
            MailMessage mailMessage = new MailMessage(this.From, this.To, this.Subject, this.Body);
            mailMessage.IsBodyHtml = this.IsBodyHtml;

            // Add attachments
            if (this.Attachments != null)
            {
                foreach (string file in Attachments)
                {
                    if (File.Exists(file))
                    {
                        // Add the file attachment to this e-mail message.
                        mailMessage.Attachments.Add(new Attachment(file, MediaTypeNames.Application.Octet));
                    }
                }
            }

            // Set SMTP client properties
            SmtpClient smtpClient = new SmtpClient(this.SmtpServer);
            smtpClient.Port = this.SmtpPort;
            smtpClient.EnableSsl = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            if (this.SmtpUserName.Trim().Length > 0)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(this.SmtpUserName, this.SmtpPassword);
               // smtpClient.UseDefaultCredentials = false;
            }

            // Send mail
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch(Exception ex)
            { 
            
            }
            // Set Staus
            this.IsMailSent = true;
            //}
            //catch (Exception ex)
            //{
            //    // Opps! Error Occured
            //    this.ErrorMessage = ex.ToString();
            //    this.IsMailSent = false;
            //}
            return this.IsMailSent;
        }
        /// <summary>
        /// This function send welcome mail to user
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool Client_Pm_OpenTaskMail(string projectName, string mailTo,string clientName,string PmfullName, string taskNo,string module,string componentName,string wireframeNo, string title, string description,string reason)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.Client_Pm_OpenTask.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#TASKTITLE#]", title);
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", PmfullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#MODULENO#]", module);
            sbtemplate.Replace("[#ComponentName#]", componentName);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#ClientName#]", clientName);
            sbtemplate.Replace("[#PROJECT#]", projectName);
            sbtemplate.Replace("[#TASKDESCRIPTION#]", description);
            sbtemplate.Replace("[#REASON#]", reason);
            this.Body = sbtemplate.ToString();

            // Send the mail
            SendMail();

            return true;
        }

        /// <summary>
        /// This function send welcome mail to user
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool Client_UpdateTask_OpenTaskMail(string projectName, string mailTo, string clientName, string PmfullName, string taskNo, string module,string ComponentName, string wireframeNo, string title, string description, string reason,string comment)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.CLIENT_TASK_UPDATE_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            //this.Subject = this.Subject.Replace("[#TASKTITLE#]", title);
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", PmfullName);
            sbtemplate.Replace("[#COMMENT#]", comment);
            sbtemplate.Replace("[#ComponentName#]", ComponentName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#MODULENO#]", module);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#ClientName#]", clientName);
            sbtemplate.Replace("[#PROJECT#]", projectName);
            sbtemplate.Replace("[#TASKDESCRIPTION#]", description);
            sbtemplate.Replace("[#REASON#]", reason);
            this.Body = sbtemplate.ToString();

            // Send the mail
            SendMail();

            return true;
        }
        /// <summary>
        /// This function send welcome mail to user
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        /// 
        public bool SendDueMail(string mailTo, string fullName, Int64 taskNo, string project, int project_id, string module, string wireframeNo, string title, string description, double hoursToComplete, string owner, DateTime dueDate, string DueIN)
        {

            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.TASK_DUE_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#TASKTITLE#]", title);
            this.Subject = this.Subject.Replace("[#ProjectName#]", project);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#DueDay#]", DueIN);
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECT#]", project);
            sbtemplate.Replace("[#MODULENO#]", module);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#TASKDESCRIPTION#]", description);
           // sbtemplate.Replace("[#HOURSTOCOMPLETE#]", Convert.ToString(hoursToComplete));
            sbtemplate.Replace("[#OWNER#]", owner);
            sbtemplate.Replace("[#TASKDUEDATE#]", dueDate.ToString(AppSetting.GetSetting("ShortDateFormat", AppSettingCategory.General)));
            sbtemplate.Replace("[#APPLICATIONLINK#]", Convert.ToString(ConfigurationManager.AppSettings["ApplicationURL"] + "?projectid=" + project_id + "&taskid=" + taskNo + "&redirect_page=task_details.aspx"));
            this.Body = sbtemplate.ToString();

            // Send the Due In mail
            SendMail();

            return true;

        }

        /// <summary>
        /// This function send welcome mail to user
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendNewTaskAssignmentMail(string projectName, string mailTo, string fullName, Int64 taskNo, string project, int project_id, string module, string wireframeNo, string title, string description, double hoursToComplete, string owner, DateTime dueDate,string componentName)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.TASK_ASSIGNMENT_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#TASKTITLE#]", title);
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECT#]", project);
            sbtemplate.Replace("[#MODULENO#]", module);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#COMPONTNTNUMBER#]", componentName);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#TASKDESCRIPTION#]", description);
            //sbtemplate.Replace("[#HOURSTOCOMPLETE#]", Convert.ToString(hoursToComplete));
            sbtemplate.Replace("[#OWNER#]", owner);
            sbtemplate.Replace("[#TASKDUEDATE#]", dueDate.ToString(AppSetting.GetSetting("ShortDateFormat", AppSettingCategory.General)));
            sbtemplate.Replace("[#APPLICATIONLINK#]", Convert.ToString(ConfigurationManager.AppSettings["ApplicationURL"] + "?projectid=" + project_id + "&taskid=" + taskNo + "&redirect_page=task_details.aspx"));
            this.Body = sbtemplate.ToString();

            // Send the mail
            SendMail();

            return true;
        }

        /// <summary>
        /// This function send welcome mail to user
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendNewTaskAssignmentMail(string projectName, string mailTo, string fullName, Int64 taskNo, string project, int project_id, string module, string wireframeNo, string title, string description, double hoursToComplete, string owner, DateTime dueDate, string componentName,bool isTaskOwner)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.TASK_ASSIGNMENT_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#TASKTITLE#]", title);
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            if (!isTaskOwner)
            {
                this.Subject = this.Subject.Replace("Assigned to you", "has been added.");
            }
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECT#]", project);
            sbtemplate.Replace("[#MODULENO#]", module);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#COMPONTNTNUMBER#]", componentName);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#TASKDESCRIPTION#]", description);
            //sbtemplate.Replace("[#HOURSTOCOMPLETE#]", Convert.ToString(hoursToComplete));
            sbtemplate.Replace("[#OWNER#]", owner);
            sbtemplate.Replace("[#TASKDUEDATE#]", dueDate.ToString(AppSetting.GetSetting("ShortDateFormat", AppSettingCategory.General)));
            sbtemplate.Replace("[#APPLICATIONLINK#]", Convert.ToString(ConfigurationManager.AppSettings["ApplicationURL"] + "?projectid=" + project_id + "&taskid=" + taskNo + "&redirect_page=task_details.aspx"));
            this.Body = sbtemplate.ToString();
            if (!isTaskOwner)
            {
                this.Body = this.Body.Replace("assigned to you", "has been added.");
            }
            // Send the mail
            SendMail();

            return true;
        }

        /// <summary>
        /// This function send mail to client when new task is added to his project
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendClientStartTaskMail(string projectName, string mailTo, string project, Int64 taskNo, string wireframeNo, string title, string fullName,string compno)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.CLIENT_STARTTASK_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECT#]", project);
            sbtemplate.Replace("[#COMPONENTNO#]", compno);       
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#CREATEDDATE#]", DateTime.Now.ToShortDateString());
            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();

            return true;
        }

        /// <summary>
        /// This function send mail to client when new task is added to his project
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendMailToParticipent(string mailTo,string fromName, string receipentName, string projectName, Int64 taskNo,string taskDesc,string message)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.SEND_MAIL_TO_PARTICIPANT.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject.Replace("[#FromName#]", fromName);
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields

            sbtemplate.Replace("[#RECIPIENTNAME#]", receipentName);
            sbtemplate.Replace("[#PROJECTNAME#]", projectName);
            sbtemplate.Replace("[#TASKID#]", taskNo.ToString());
            sbtemplate.Replace("[#DESCRIPTION#]", taskDesc);
            sbtemplate.Replace("[#MESSAGE#]", message);
           
            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();

            return true;
        }

        /// <summary>
        /// This function send mail to client when task is finished 
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendClientEndTaskMail(string mailTo, string project, Int64 taskNo, string wireframeNo, string title, string fullName,string componentName)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.CLIENT_ENDTASK_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;
            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#ProjectName#]", project);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECT#]", project);
            sbtemplate.Replace("[#WIREFRAMENO#]", wireframeNo);
            sbtemplate.Replace("[#COMPONENTNAME#]", componentName);
            sbtemplate.Replace("[#TASKTITLE#]", title);
            sbtemplate.Replace("[#CREATEDDATE#]", DateTime.Now.ToShortDateString());
            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();

            return true;
        }

        // ********************************************************* //
        public bool SendClientTaskCommentMail(string mailTo, Int64 taskNo, string projectName, string taskStatus, string fullName, string title, DateTime dueDate, string taskOwner, string commentByfn, string commentByln, string commentMsg,string wfnumber,string componentName)
        {

            // Select mail Template from Database
            clsTemplate objTemplate = new clsTemplate();
            objTemplate.SelectByUniqueName(Templates.CLIENT_TASKCOMMENT_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;
            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECTNAME#]", projectName);
            sbtemplate.Replace("[#TASKSTATUS#]", taskStatus);
            sbtemplate.Replace("[#TITLE#]", title);
            sbtemplate.Replace("[#WIREFRAMNO#]", wfnumber);
            sbtemplate.Replace("[#COMPONENTNUMBER#]", componentName);
            sbtemplate.Replace("[#DUEDATE#]", Convert.ToString(dueDate));
            sbtemplate.Replace("[#TASKOWNER#]", taskOwner);
            sbtemplate.Replace("[#COMMENTBY#]", (commentByfn + " " + commentByln));
            sbtemplate.Replace("[#COMMENTDATE#]", Convert.ToString(DateTime.Now.ToShortDateString()));
            sbtemplate.Replace("[#COMMENT#]", commentMsg);

            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();
            return true;
        }


        // *************************New Send Mail To Comment******************************** //
        public bool SendClientTaskCommentMailNew(string mailTo, Int64 taskNo, string projectName, string taskDescription, string taskComment,DateTime dateInsert,string recipientname)
        {

            // Select mail Template from Database
            clsTemplate objTemplate = new clsTemplate();
            objTemplate.SelectByUniqueName(Templates.SEND_MAIL_OF_COMMENT_TO_CLIENT.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            
            this.Subject = objTemplate.Subject;
            this.Subject = this.Subject.Replace("[#Task#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#RECIPIENTNAME#]", recipientname);
            sbtemplate.Replace("[#TASKID#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECTNAME#]", projectName);
            sbtemplate.Replace("[#COMMENT#]", taskComment);
            sbtemplate.Replace("[#DESCRIPTION#]", taskDescription);
         //   sbtemplate.Replace("[#WIREFRAMNO#]", wfnumber);
         //   sbtemplate.Replace("[#COMPONENTNUMBER#]", componentName);
          //  sbtemplate.Replace("[#DUEDATE#]", Convert.ToString(dueDate));
          //  sbtemplate.Replace("[#TASKOWNER#]", taskOwner);
           // sbtemplate.Replace("[#COMMENTBY#]", (commentByfn + " " + commentByln));
            sbtemplate.Replace("[#DATE#]", Convert.ToString(DateTime.Now.ToShortDateString()));
           // sbtemplate.Replace("[#COMMENT#]", commentMsg);

            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();
            return true;
        }


        // ********************************************************* //
        ///<summary>
        ///This Function Send Mail to User Group When Task Is Updated
        /// </summary>
        public bool SendTaskUpdateMail(string mailTo, Int64 taskNo, string projectName, string taskStatus, string fullName, string title, DateTime dueDate, string taskOwner, string commentByfn, string commentByln, string commentMsg,string wfno,string compno)
        {

            // Select mail Template from Database
            clsTemplate objTemplate = new clsTemplate();
            objTemplate.SelectByUniqueName(Templates.UPDATE_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;
            this.Subject = this.Subject.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            this.Subject = this.Subject.Replace("[#ProjectName#]", projectName);
            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#FULLNAME#]", fullName);
            sbtemplate.Replace("[#TASKNO#]", Convert.ToString(taskNo));
            sbtemplate.Replace("[#PROJECTNAME#]", projectName);
            sbtemplate.Replace("[#TASKSTATUS#]", taskStatus);
            sbtemplate.Replace("[#WIREFRAMNO#]", wfno);
            sbtemplate.Replace("[#COMPONENTNUMBER#]", compno);
   
            sbtemplate.Replace("[#TITLE#]", title);
            sbtemplate.Replace("[#DUEDATE#]", Convert.ToString(dueDate));
            sbtemplate.Replace("[#TASKOWNER#]", taskOwner);

            this.Body = sbtemplate.ToString();
            // Send the mail
            SendMail();
            return true;
        }
        /// <summary>
        /// This function send mail to client every day,containing information about number of updates in his/her project on last day
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool SendDailyUpdateMail(string mailTo, int updateCount, string projectName)
        {
            // First select mail template from database
            clsTemplate objTemplate = new clsTemplate();

            objTemplate.SelectByUniqueName(Templates.DAILY_UPDATE_MAIL.ToString());

            if (Convert.ToString(objTemplate.UniqueName).Equals(string.Empty))
            {
                throw new ApplicationException("Mail template not found");
            }

            // Now we have the mail template, so replace it with the content
            System.Text.StringBuilder sbtemplate = new System.Text.StringBuilder();

            // Get subject
            this.To = mailTo;
            this.Subject = objTemplate.Subject;

            this.Subject = this.Subject.Replace("[#PROJECTNAME#]", projectName);
            this.Subject = this.Subject.Replace("[#UPDATECOUNT#]", updateCount.ToString());

            // Get body
            sbtemplate.Append(objTemplate.TemplateContent);

            // Replace the fields
            sbtemplate.Replace("[#PROJECTNAME#]", projectName);
            sbtemplate.Replace("[#UPDATECOUNT#]", updateCount.ToString());

            this.Body = sbtemplate.ToString();

            // Send the mail
            SendMail();

            return true;
        }
    }
}