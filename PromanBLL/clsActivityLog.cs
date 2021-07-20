using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL 
{
	public sealed class clsActivityLog 
    {
		#region Fields
        DAL.clsActivityLog objActivityLog = new DAL.clsActivityLog();
        private string sessionId;
		private Int64 activityId;
		private Int64 userId;
		private string category;
		private string activity;
		private string pageName;
		private string pageURL;
		private DateTime startDateTime;
		private DateTime endDateTime;
		private string iPAddress;
		private string browser;
		private string country;
		private bool status;
		private string referer;
		private string userAgent;
		private bool isBot;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ActivityLog class.
		/// </summary>
		public clsActivityLog() {
		}
		
		/// <summary>
		/// Initializes a new instance of the ActivityLog class.
		/// </summary>
		public clsActivityLog(string sessionId,Int64 userId, string category, string activity, string pageName, string pageURL, DateTime startDateTime, DateTime endDateTime, string iPAddress, string browser, string country, bool status, string referer, string userAgent, bool isBot) {
            this.sessionId = sessionId;
            this.userId = userId;
			this.category = category;
			this.activity = activity;
			this.pageName = pageName;
			this.pageURL = pageURL;
			this.startDateTime = startDateTime;
			this.endDateTime = endDateTime;
			this.iPAddress = iPAddress;
			this.browser = browser;
			this.country = country;
			this.status = status;
			this.referer = referer;
			this.userAgent = userAgent;
			this.isBot = isBot;
		}
		
		/// <summary>
		/// Initializes a new instance of the ActivityLog class.
		/// </summary>
        public clsActivityLog(Int64 activityId,string sessionId, Int64 userId, string category, string activity, string pageName, string pageURL, DateTime startDateTime, DateTime endDateTime, string iPAddress, string browser, string country, bool status, string referer, string userAgent, bool isBot)
        {
			this.activityId = activityId;
            this.sessionId = sessionId;
			this.userId = userId;
			this.category = category;
			this.activity = activity;
			this.pageName = pageName;
			this.pageURL = pageURL;
			this.startDateTime = startDateTime;
			this.endDateTime = endDateTime;
			this.iPAddress = iPAddress;
			this.browser = browser;
			this.country = country;
			this.status = status;
			this.referer = referer;
			this.userAgent = userAgent;
			this.isBot = isBot;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ActivityId value.
		/// </summary>
		public Int64 ActivityId {
			get { return activityId; }
			set { activityId = value; }
		}

        /// <summary>
        /// Gets or sets the SessionId value.
        /// </summary>
        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
		/// <summary>
		/// Gets or sets the UserId value.
		/// </summary>
		public Int64 UserId {
			get { return userId; }
			set { userId = value; }
		}
		
		/// <summary>
		/// Gets or sets the Category value.
		/// </summary>
		public string Category {
			get { return category; }
			set { category = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity value.
		/// </summary>
		public string Activity {
			get { return activity; }
			set { activity = value; }
		}
		
		/// <summary>
		/// Gets or sets the PageName value.
		/// </summary>
		public string PageName {
			get { return pageName; }
			set { pageName = value; }
		}
		
		/// <summary>
		/// Gets or sets the PageURL value.
		/// </summary>
		public string PageURL {
			get { return pageURL; }
			set { pageURL = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDateTime value.
		/// </summary>
		public DateTime StartDateTime {
			get { return startDateTime; }
			set { startDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDateTime value.
		/// </summary>
		public DateTime EndDateTime {
			get { return endDateTime; }
			set { endDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IPAddress value.
		/// </summary>
		public string IPAddress {
			get { return iPAddress; }
			set { iPAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Browser value.
		/// </summary>
		public string Browser {
			get { return browser; }
			set { browser = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country value.
		/// </summary>
		public string Country {
			get { return country; }
			set { country = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public bool Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
		/// Gets or sets the Referer value.
		/// </summary>
		public string Referer {
			get { return referer; }
			set { referer = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserAgent value.
		/// </summary>
		public string UserAgent {
			get { return userAgent; }
			set { userAgent = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBot value.
		/// </summary>
		public bool IsBot {
			get { return isBot; }
			set { isBot = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the ActivityLog table.
		/// </summary>
		public Int64 Insert() {
            return objActivityLog.Insert(sessionId,userId, category, activity, pageName, pageURL, startDateTime, endDateTime, iPAddress, browser, country, status, referer, userAgent, isBot);
		}
		
		/// <summary>
		/// Updates a record in the ActivityLog table.
		/// </summary>
		public void Update() {
			objActivityLog.Update(activityId,sessionId, userId, category, activity, pageName, pageURL, startDateTime, endDateTime, iPAddress, browser, country, status, referer, userAgent, isBot);
		}
		
		/// <summary>
		/// Deletes a record from the ActivityLog table by its primary key.
		/// </summary>
		public void Delete() {
			objActivityLog.Delete(activityId);
		}
		
		/// <summary>
		/// Selects a single record from the ActivityLog table.
		/// </summary>
		public DataSet Select(Int64 activityId) {
            return objActivityLog.Select(activityId);
		}
		
		/// <summary>
		/// Selects all records from the ActivityLog table.
		/// </summary>
		public DataSet SelectAll() {
            return objActivityLog.SelectAll();
		}
		
		/// <summary>
		/// Creates a new instance of the ActivityLog class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private void MakeActivityLog(DataSet ds) {
           
            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["ActivityId"] != DBNull.Value)
            {
                this.ActivityId = Convert.ToInt64(ds.Tables[0].Rows[0]["ActivityId"]);
			}
            if (ds.Tables[0].Rows[0]["SessionId"] != DBNull.Value)
            {
                this.SessionId  = Convert.ToString(ds.Tables[0].Rows[0]["SessionId"]);
            }
            if (ds.Tables[0].Rows[0]["UserId"] != DBNull.Value)
            {
                this.UserId = Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]);
			}
            if (ds.Tables[0].Rows[0]["ContactUsId"] != DBNull.Value)
            {
                this.Category = Convert.ToString(ds.Tables[0].Rows[0]["ContactUsId"]);
			}
            if (ds.Tables[0].Rows[0]["Category"] != DBNull.Value)
            {
                this.Activity = Convert.ToString(ds.Tables[0].Rows[0]["Category"]);
			}
            if (ds.Tables[0].Rows[0]["PageName"] != DBNull.Value)
            {
                this.PageName = Convert.ToString(ds.Tables[0].Rows[0]["PageName"]);
			}
            if (ds.Tables[0].Rows[0]["ContactUsId"] != DBNull.Value)
            {
                this.PageURL = Convert.ToString(ds.Tables[0].Rows[0]["ContactUsId"]);
			}
            if (ds.Tables[0].Rows[0]["StartDateTime"] != DBNull.Value)
            {
                this.StartDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDateTime"]);
			}
            if (ds.Tables[0].Rows[0]["EndDateTime"] != DBNull.Value)
            {
                this.EndDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDateTime"]);
			}
            if (ds.Tables[0].Rows[0]["IPAddress"] != DBNull.Value)
            {
                this.IPAddress = Convert.ToString(ds.Tables[0].Rows[0]["IPAddress"]);
			}
            if (ds.Tables[0].Rows[0]["Browser"] != DBNull.Value)
            {
                this.Browser = Convert.ToString(ds.Tables[0].Rows[0]["Browser"]);
			}
            if (ds.Tables[0].Rows[0]["Country"] != DBNull.Value)
            {
                this.Country = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
			}
            if (ds.Tables[0].Rows[0]["Status"] != DBNull.Value)
            {
                this.Status = Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]);
			}
            if (ds.Tables[0].Rows[0]["Referer"] != DBNull.Value)
            {
                this.Referer = Convert.ToString(ds.Tables[0].Rows[0]["Referer"]);
			}
            if (ds.Tables[0].Rows[0]["UserAgent"] != DBNull.Value)
            {
                this.UserAgent = Convert.ToString(ds.Tables[0].Rows[0]["UserAgent"]);
			}
            if (ds.Tables[0].Rows[0]["IsBot"] != DBNull.Value)
            {
                this.IsBot = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsBot"]);
			}

			
		}
		#endregion
	}
}
