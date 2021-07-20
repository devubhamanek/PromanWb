using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Data;
using System.IO;

namespace PromanWeb.extra
{
    public partial class projectdelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Delete Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int64 projectID = Convert.ToInt64(TextBox1.Text.Trim());

            clsTask objTask = new clsTask();
            DataSet ds = objTask.SelectAllByProjectId(projectID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Int64 taskID = Convert.ToInt64(dr["TaskID"]);
                string folderPath = Server.MapPath("~/uploads/images/task") + "\\" + taskID.ToString();

                if (Directory.Exists(folderPath))
                    Directory.Delete(folderPath, true);
            }

            clsProject objProject = new clsProject();
            objProject.DeleteProjectWhole(projectID);
        }
    }
}