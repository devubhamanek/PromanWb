using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Proman.BLL;
using System.Data;



namespace PromanWeb
{

    public partial class send_duein_mail : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //Select All The records from the Tables
            clsTask objTask = new clsTask();
            DataSet dsTask = objTask.SelectPastDueDate();
            //Check if dataset contain rows
            if (Helper.HasRow(dsTask))
            {
                Mailer objMailer = new Mailer(true);
                //For each task send the mail to its task owner,reminding the due date
                foreach (DataRow drTask in dsTask.Tables[0].Rows)
                {
                    objMailer.SendDueMail(drTask["UserName"].ToString(), drTask["FirstName"].ToString() + drTask.Table.Rows[0]["LastName"].ToString(), Convert.ToInt64(drTask["TaskId"]), (drTask["ProjectName"]).ToString(), Convert.ToInt16(drTask["ProjectId"]), drTask["ModuleId"].ToString(), drTask["WireframeNo"].ToString(), drTask["Title"].ToString(), drTask["Description"].ToString(), Convert.ToDouble(drTask["TaskHours"]), Convert.ToString(drTask["AssignByName"]), Convert.ToDateTime(drTask["DueDate"]), drTask["DueIn"].ToString());

                }
            }

        }



    }
}