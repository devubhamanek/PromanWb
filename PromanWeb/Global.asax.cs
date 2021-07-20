using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using DevExpress.Xpo;
using System.IO;

namespace PromanWeb
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            AppSetting.LoadSetting();

            StreamWriter streamWriter = null;

            try
            {
                string strPath = HttpContext.Current.Server.MapPath("uploads/log.txt");

                if (!File.Exists(strPath))
                    streamWriter = new StreamWriter(strPath);
                else
                    streamWriter = File.AppendText(strPath);

                streamWriter.WriteLine("Application Start :"+DateTime.Now.ToString());
            }
            catch (Exception)
            {
                // Do nothing if any error occur as error can be occur if 
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            //string conn = System.Configuration.ConfigurationManager.ConnectionStrings["PromanConnectionString"].ConnectionString;
            //DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            //dict.GetDataStoreSchema(typeof(ProjectSelectByModuleStatus).Assembly);
            //DevExpress.Xpo.DB.IDataStore store =
            //DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn, DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly);
            //DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(dict, store);

            //// Code that runs on application startup
            //// Load application level settings

            //// Code that runs on the application startup 
            //// Specify the connection string, which is used to open a database.  
            //// It's supposed that you've already created the Comments database within the App_Data folder. 
            //string conn = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString(
            //  Server.MapPath("~\\App_Data\\Customer.mdb"));
            //DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            //// Initialize the XPO dictionary. 
            //dict.GetDataStoreSchema(typeof(Customer).Assembly);
            //DevExpress.Xpo.XpoDefault.Session = null;
            //DevExpress.Xpo.DB.IDataStore store =
            //DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn,
            //DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            //DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(dict, store);

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            StreamWriter streamWriter = null;

            try
            {
                string strPath = HttpContext.Current.Server.MapPath("uploads/log.txt");

                if (!File.Exists(strPath))
                    streamWriter = new StreamWriter(strPath);
                else
                    streamWriter = File.AppendText(strPath);

                streamWriter.WriteLine("Application End :" + DateTime.Now.ToString());
            }
            catch (Exception)
            {
                // Do nothing if any error occur as error can be occur if 
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

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            StreamWriter streamWriter = null;

            try
            {
                string strPath = HttpContext.Current.Server.MapPath("uploads/log.txt");

                if (!File.Exists(strPath))
                    streamWriter = new StreamWriter(strPath);
                else
                    streamWriter = File.AppendText(strPath);

                streamWriter.WriteLine("Application Error :" + DateTime.Now.ToString());
            }
            catch (Exception)
            {
                // Do nothing if any error occur as error can be occur if 
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

        void Session_Start(object sender, EventArgs e)
        {
            StreamWriter streamWriter = null;

            try
            {
                string strPath = HttpContext.Current.Server.MapPath("uploads/log.txt");

                if (!File.Exists(strPath))
                    streamWriter = new StreamWriter(strPath);
                else
                    streamWriter = File.AppendText(strPath);

                streamWriter.WriteLine("Session Start :" + DateTime.Now.ToString());
            }
            catch (Exception)
            {
                // Do nothing if any error occur as error can be occur if 
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            try
            {
                Common objCommon = new Common();
                objCommon.ActivityLog("SessionStart");
            }
            catch { }


        }


        void Application_Request(object sender, EventArgs e)
        {
             
            //// Read the cookie
            //HttpCookie cookie = FormsAuthentication.GetAuthCookie(Convert.ToString(SessionData.UserName), true);
            //// Decrypt the cookie to get ticket
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            //// Create new ticket from old and update roles
            //FormsAuthenticationTicket newticket = new FormsAuthenticationTicket(
            //       (ticket.Version, // Ticket version
            //  ticket.Name, // Username associated with ticket
            //        ticket.IssueDate, // Date/time issued
            //        ticket.Expiration, // Date/time to expire                    
            //        false, //"true" for a persistent user cookie                    
            //        DropDownListRole.SelectedItem.Text, //User-data, in this case the roles from a dropdown                    
            //        ticket.CookiePath);

            //// Encrypt the ticket and store it in the cookie
            //cookie.Value = FormsAuthentication.Encrypt(newticket);

            //// Set the cookie's expiration time to the tickets expiration time
            //if (ticket.IsPersistent) cookie.Expires = newticket.Expiration;

            //// Add the cookie to the list for outgoing response
            //HttpContext.Current.Response.Cookies.Add(cookie);
        }

        void Session_End(object sender, EventArgs e)
        {
            StreamWriter streamWriter = null;

            try
            {
                string strPath = HttpContext.Current.Server.MapPath("uploads/log.txt");

                if (!File.Exists(strPath))
                    streamWriter = new StreamWriter(strPath);
                else
                    streamWriter = File.AppendText(strPath);

                streamWriter.WriteLine("Session End :" + DateTime.Now.ToString());
            }
            catch (Exception)
            {
                // Do nothing if any error occur as error can be occur if 
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
