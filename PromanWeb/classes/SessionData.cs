using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PromanWeb
{
    public class SessionData
    {
        #region Property

        /// <summary>
        /// Authorization Role For User
        /// </summary>
        public static DataSet authorizationRules
        {
            get
            {
                if (HttpContext.Current.Session["authorizationRules"] == null)
                {
                    return null;
                }
                return (DataSet)(HttpContext.Current.Session["authorizationRules"]);
            }
            set { HttpContext.Current.Session["authorizationRules"] = value; }
        }

        /// <summary>
        /// Id of the user
        /// </summary>
        public static Int64 UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                {
                    return 0;
                }
                return Convert.ToInt64(HttpContext.Current.Session["UserId"]);
            }
            set { HttpContext.Current.Session["UserId"] = value; }
        }

        /// <summary>
        /// First name of the user
        /// </summary>
        public static string FirstName
        {
            get
            {
                if (HttpContext.Current.Session["FirstName"] == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(HttpContext.Current.Session["FirstName"]);
            }
            set { HttpContext.Current.Session["FirstName"] = value; }
        }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public static string LastName
        {
            get
            {
                if (HttpContext.Current.Session["LastName"] == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(HttpContext.Current.Session["LastName"]);
            }
            set { HttpContext.Current.Session["LastName"] = value; }
        }

        /// <summary>
        /// Email of the user
        /// </summary>
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    return string.Empty;
                }
                return Convert.ToString(HttpContext.Current.Session["UserName"]);
            }
            set { HttpContext.Current.Session["UserName"] = value; }
        }

        /// <summary>
        /// RoleId of the user
        /// </summary>
        public static Roles RoleId
        {
            get
            {
                if (HttpContext.Current.Session["RoleId"] == null)
                {
                    return 0;
                }
                return (Roles)Enum.Parse(typeof(Roles), Convert.ToString(HttpContext.Current.Session["RoleId"]));
            }
            set { HttpContext.Current.Session["RoleId"] = value; }
        }

    #endregion
    }
}