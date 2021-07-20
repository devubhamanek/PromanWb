using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proman;

namespace Proman.BLL
{
    public sealed class clsTask
    {
        #region Fields
        DAL.clsTask objTask = new DAL.clsTask();

        private Int64 taskId;
        private Int64 projectId;
        private Int64 moduleId;
        private Int64 taskCategory;
        private string componentNumber;
        private string componentName;
        private string wireframeNo;
        private string title;
        private string urlAddress;
        private string description;
        private double taskHours;
        private string audiofileName;
        private string audioOriginalFileName;
        private Int64 assignTo;
        private DateTime dueDate;
        private int taskStatus;
        private bool isHold;
        private bool isUrgent;
        private Int64 createdBy;
        private DateTime createddate;
        private Int64 modifiedBy;
        private DateTime modifiedDate;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        public clsTask()
        {
        }

        public clsTask(Int64 taskId)
        {
            MakeTask(Select(taskId));
        }

        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        public clsTask(Int64 projectId, Int64 moduleId, string wireframeNo, string title, string description, double taskHours, Int64 assignTo, DateTime dueDate, int taskStatus, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.projectId = projectId;
            this.moduleId = moduleId;
            this.wireframeNo = wireframeNo;
            this.title = title;
            this.description = description;
            this.taskHours = taskHours;
            this.assignTo = assignTo;
            this.dueDate = dueDate;
            this.taskStatus = taskStatus;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }

        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        public clsTask(Int64 taskId, Int64 projectId, Int64 moduleId, string wireframeNo, string title, string description, double taskHours, Int64 assignTo, DateTime dueDate, int taskStatus, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate)
        {
            this.taskId = taskId;
            this.projectId = projectId;
            this.moduleId = moduleId;
            this.wireframeNo = wireframeNo;
            this.title = title;
            this.description = description;
            this.taskHours = taskHours;
            this.assignTo = assignTo;
            this.dueDate = dueDate;
            this.taskStatus = taskStatus;
            this.createdBy = createdBy;
            this.createddate = createddate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the audioFilename
        public string AudiofileName
        {
            get { return audiofileName; }
            set { audiofileName = value; }
        }
        /// <summary>
        /// Gets or sets the audioFilename
        public string ComponentNumber
        {
            get { return componentNumber; }
            set { componentNumber = value; }
        }
        /// <summary>
        /// Gets or sets the audioFilename
        public string ComponentName
        {
            get { return componentName; }
            set { componentName = value; }
        }
        /// <summary>
        /// Gets or sets the audioFilename
        public string URLAddress
        {
            get { return urlAddress; }
            set { urlAddress = value; }
        }

        /// <summary>
        /// Gets or sets the audioOriginalFileName value.
        /// </summary>
        public string AudioOriginalFileName
        {
            get { return audioOriginalFileName; }
            set { audioOriginalFileName = value; }
        }


        /// <summary>
        /// Gets or sets the TaskId value.
        /// </summary>
        public Int64 TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public Int64 ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        /// <summary>
        /// Gets or sets the ModuleId value.
        /// </summary>
        public Int64 ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        /// <summary>
        /// Gets or sets the WireframeNo value.
        /// </summary>
        public string WireframeNo
        {
            get { return wireframeNo; }
            set { wireframeNo = value; }
        }

        /// <summary>
        /// Gets or sets the Title value.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Gets or sets the TaskHours value.
        /// </summary>
        public double TaskHours
        {
            get { return taskHours; }
            set { taskHours = value; }
        }


        /// <summary>
        /// Gets or sets the AssignTo value.
        /// </summary>
        public Int64 AssignTo
        {
            get { return assignTo; }
            set { assignTo = value; }
        }

        /// <summary>
        /// Gets or sets the DueDate value.
        /// </summary>
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        /// <summary>
        /// Gets or sets the TaskStatus value.
        /// </summary>
        public int TaskStatus
        {
            get { return taskStatus; }
            set { taskStatus = value; }
        }


        /// <summary>
        /// Gets or sets the IsHold
        public bool IsHold
        {
            get { return isHold; }
            set { isHold = value; }
        }

        /// <summary>
        /// Gets or sets the IsHold
        public bool IsUrgent
        {
            get { return isUrgent; }
            set { isUrgent = value; }
        }

        /// <summary>
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public Int64 CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets or sets the Createddate value.
        /// </summary>
        public DateTime Createddate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedBy value.
        /// </summary>
        public Int64 ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedDate value.
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedDate value.
        /// </summary>
        public Int64 TaskCategory
        {
            get { return taskCategory; }
            set { taskCategory = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the Task table.
        /// </summary>
        public Int64 Insert()
        {
            return objTask.Insert(projectId, moduleId, componentNumber, componentName, wireframeNo, title, urlAddress, description, taskHours, assignTo, dueDate, taskStatus, audiofileName, AudioOriginalFileName, createdBy, createddate, modifiedBy, modifiedDate, taskCategory,isUrgent);
        }

        /// <summary>
        /// Updates a record in the Task table.
        /// </summary>
        public void UpdateIsHold(Int64 taskId, bool isHold)
        {
            objTask.UpdateIsHold(taskId, isHold);
        }

        /// <summary>
        /// Updates a record in the Task table and set OnHold status.
        /// </summary>
        public void Update()
        {
            objTask.Update(taskId, projectId, moduleId, componentNumber, componentName, wireframeNo, title, urlAddress, description, taskHours, assignTo, dueDate, taskStatus, audiofileName, AudioOriginalFileName, createdBy, createddate, modifiedBy, modifiedDate, taskCategory,isUrgent);
        }

        /// <summary>
        /// Updates a record statuc and due date in the Task table.
        /// </summary>
        public void UpdateStatusAndDueDate(Int64 taskId, DateTime dueDate, int taskStatus, Int64 modifiedBy, DateTime modifiedDate)
        {
            objTask.UpdateStatusAndDueDate(taskId, dueDate, taskStatus, modifiedBy, modifiedDate);
        }


        /// <summary>
        /// Deletes a record from the Task table by its primary key.
        /// </summary>
        public void Delete(Int64 taskId)
        {
            objTask.Delete(taskId);
        }


        /// <summary>
        /// Deletes a record from the Task table by a composite primary key.
        /// <summary>
        public void DeleteByService(Int64 taskId)
        {
            objTask.DeleteByService(taskId);
        }
        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// </summary>
        public void DeleteAllByModuleId(Int64 moduleId)
        {
            objTask.DeleteByModuleId(moduleId);
        }

        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// </summary>
        public void DeleteAllByProjectId(Int64 projectId)
        {
            objTask.DeleteByProjectId(projectId);
        }

        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// </summary>
        public void DeleteAllByAssignTo(Int64 assignTo)
        {
            objTask.DeleteByAssignTo(assignTo);
        }

        /// <summary>
        /// Selects a single record from the Task table.
        /// </summary>
        public DataSet Select(Int64 taskId)
        {
            return objTask.Select(taskId);

        }
        /// <summary>
        /// Selects Daily Task Update from the Task,Task Status And Task Comment Table.
        /// <summary>
        /// <returns>Int64</returns>
        public DataSet SelectDaliyTaskUpdate()
        {
            return objTask.SelectDaliyTaskUpdate();
        }
        ///<summary>
        ///Selects all records from the Task table.
        /// </summary>
        /// <returns></returns>

        public DataSet SelectAll()
        {
            return objTask.SelectAll();
        }

        /// <summary>
        /// Selects max TaskId from the Task table.
        /// <summary>
        public Int64 SelectMaxId()
        {
            return objTask.SelectMaxId();
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectAllByModuleId(Int64 moduleId)
        {
            return objTask.SelectByModuleId(moduleId);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectAllByComponentId(Int64 componentId, int status)
        {
            return objTask.SelectByComponentId(componentId, status);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectByComponentIdForComponentFolder(Int64 projectId, Int64 componentId, int status)
        {
            return objTask.SelectByComponentIdForComponentFolder(projectId,componentId,status);
        }
        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="projectId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByProjectIdBySort(Int64 projectId, int taskCompetionPercentage, int sortOrder)
        {
            return objTask.SelectByProjectIdBySort(projectId, taskCompetionPercentage, sortOrder);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectAllByProjectId(Int64 projectId)
        {
            return objTask.SelectByProjectId(projectId);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectAllByClientId(Int64 clientID, int status)
        {
            return objTask.SelectAllByClientId(clientID, status);
        }



        /// <summary>
        /// Selects task details from the Task table by a primary key.
        /// <summary>
        public DataSet SelectDetails(Int64 taskId)
        {
            return objTask.SelectDetails(taskId);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        public DataSet SelectByProjectIdAndUserId(Int64 userId, Int64 projectId,Int64 compID, int status)
        {
            return objTask.SelectByProjectIdAndUserId(userId, projectId, compID,status);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        public DataSet SelectByUserId(Int64 userId, DateTime startDate, DateTime endDate, int status)
        {
            return objTask.SelectByUserId(userId, startDate, endDate, status);
        }

        /// <summary>
        /// Search records from the Task table by a foreign key.
        /// <summary>
        public DataSet SelectSearchByUserId(Int64 userId, Int64 projectId, Int64 moduleId, string componentNumb, Int64 taskId, string wireframNo, string description, int status)
        {
            return objTask.SelectSearchByUserId(userId, projectId, moduleId, componentNumb, taskId, wireframNo, description, status);
        }

        /// <summary>
        /// Selects my private tasks records from the Task table by a foreign key.
        /// <summary>
        public DataSet SelectMyPrivateTask(Int64 userId, DateTime startDate, DateTime endDate, int status)
        {
            return objTask.SelectMyPrivateTask(userId, startDate, endDate, status);
        }

        /// <summary>
        /// Select All task Category
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAllTaskCategory()
        {
            return objTask.SelectAllTaskCategory();
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectAllByAssignTo(Int64 assignTo)
        {
            return objTask.SelectByAssignTo(assignTo);
        }

        /// <summary>
        /// Creates a new instance of the Task class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private void MakeTask(DataSet ds)
        {

            if (ds.Tables[0].Rows.Count == 0)
                return;

            if (ds.Tables[0].Rows[0]["TaskId"] != DBNull.Value)
            {
                this.TaskId = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskId"]);
            }
            if (ds.Tables[0].Rows[0]["ProjectId"] != DBNull.Value)
            {
                this.ProjectId = Convert.ToInt64(ds.Tables[0].Rows[0]["ProjectId"]);
            }
            if (ds.Tables[0].Rows[0]["TaskCategoryID"] != DBNull.Value)
            {
                this.TaskCategory = Convert.ToInt64(ds.Tables[0].Rows[0]["TaskCategoryID"]);
            }
            if (ds.Tables[0].Rows[0]["ModuleId"] != DBNull.Value)
            {
                this.ModuleId = Convert.ToInt64(ds.Tables[0].Rows[0]["ModuleId"]);
            }
            if (ds.Tables[0].Rows[0]["ComponentNumber"] != DBNull.Value)
            {
                this.ComponentNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComponentNumber"]);
            }
            if (ds.Tables[0].Rows[0]["ComponentName"] != DBNull.Value)
            {
                this.ComponentName = Convert.ToString(ds.Tables[0].Rows[0]["ComponentName"]);
            }
            if (ds.Tables[0].Rows[0]["WireframeNo"] != DBNull.Value)
            {
                this.WireframeNo = Convert.ToString(ds.Tables[0].Rows[0]["WireframeNo"]);
            }
            if (ds.Tables[0].Rows[0]["Title"] != DBNull.Value)
            {
                this.Title = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
            }
            if (ds.Tables[0].Rows[0]["URLAddress"] != DBNull.Value)
            {
                this.URLAddress = Convert.ToString(ds.Tables[0].Rows[0]["URLAddress"]);
            }
            if (ds.Tables[0].Rows[0]["Description"] != DBNull.Value)
            {
                this.Description = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
            }
            if (ds.Tables[0].Rows[0]["AudioFileName"] != DBNull.Value)
            {
                this.AudiofileName = Convert.ToString(ds.Tables[0].Rows[0]["AudioFileName"]);
            }
            if (ds.Tables[0].Rows[0]["AudioOriginalFileName"] != DBNull.Value)
            {
                this.AudioOriginalFileName = Convert.ToString(ds.Tables[0].Rows[0]["AudioOriginalFileName"]);
            }
            if (ds.Tables[0].Rows[0]["TaskHours"] != DBNull.Value)
            {
                this.TaskHours = Convert.ToDouble(ds.Tables[0].Rows[0]["TaskHours"]);
            }
            if (ds.Tables[0].Rows[0]["AssignTo"] != DBNull.Value)
            {
                this.AssignTo = Convert.ToInt64(ds.Tables[0].Rows[0]["AssignTo"]);
            }
            if (ds.Tables[0].Rows[0]["DueDate"] != DBNull.Value)
            {
                this.DueDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
            }
            if (ds.Tables[0].Rows[0]["TaskStatus"] != DBNull.Value)
            {
                this.TaskStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["TaskStatus"]);
            }

            if (ds.Tables[0].Rows[0]["IsHold"] != DBNull.Value)
            {
                this.IsHold = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHold"]);
            }

            if (ds.Tables[0].Rows[0]["IsUrgent"] != DBNull.Value)
            {
                this.IsUrgent = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsUrgent"]);
            }

            if (ds.Tables[0].Rows[0]["CreatedBy"] != DBNull.Value)
            {
                this.CreatedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["CreatedBy"]);
            }
            if (ds.Tables[0].Rows[0]["Createddate"] != DBNull.Value)
            {
                this.Createddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Createddate"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedBy"] != DBNull.Value)
            {
                this.ModifiedBy = Convert.ToInt64(ds.Tables[0].Rows[0]["ModifiedBy"]);
            }
            if (ds.Tables[0].Rows[0]["ModifiedDate"] != DBNull.Value)
            {
                this.ModifiedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModifiedDate"]);
            }


        }

        ///<summary>
        ///get a projectid,task id and username which are not completed in within due date(for sending due task mail)
        ///</summary>
        public DataSet SelectPastDueDate()
        {
            return objTask.SelectPastDueDate();
        }

        #endregion
    }
}
