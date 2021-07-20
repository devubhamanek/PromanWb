using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlTypes;

namespace Proman.DAL
{
    /// <summary>
    /// Data access class for Task table.
    /// </summary>
    public sealed class clsTask
    {
        public clsTask() { }

        /// <summary>
        /// Inserts a record into the Task table.
        /// <summary>
        /// <param name="projectId"></param>
        /// <param name="moduleId"></param>
        /// <param name="wireframeNo"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="taskHours"></param>
        /// <param name="assignTo"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskStatus"></param>
        /// <param name="createdBy"></param>
        /// <param name="createddate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        /// <returns></returns>
        public Int64 Insert(Int64 projectId, Int64 moduleId, string componentNumber, string componentName, string wireframeNo, string title, string urlAddress, string description, double taskHours, Int64 assignTo, DateTime dueDate, int taskStatus, string audioFileName, string audioOriginalFileName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, Int64 taskCategoryID,bool isUrgent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskInsert");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);
            db.AddInParameter(dbCommand, "ComponentNumber", DbType.String, componentNumber);
            db.AddInParameter(dbCommand, "ComponentName", DbType.String, componentName);
            db.AddInParameter(dbCommand, "WireframeNo", DbType.String, wireframeNo);
            db.AddInParameter(dbCommand, "Title", DbType.String, title);
            db.AddInParameter(dbCommand, "URLAddress", DbType.String, urlAddress);
            db.AddInParameter(dbCommand, "Description", DbType.String, description);
            db.AddInParameter(dbCommand, "TaskHours", DbType.Double, taskHours);
            db.AddInParameter(dbCommand, "AssignTo", DbType.Int64, assignTo);
            db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, dueDate);
            db.AddInParameter(dbCommand, "TaskStatus", DbType.Int32, taskStatus);
            db.AddInParameter(dbCommand, "AudioFileName", DbType.String, audioFileName);
            db.AddInParameter(dbCommand, "AudioOriginalFileName", DbType.String, audioOriginalFileName);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "TaskCategoryID", DbType.Int64, taskCategoryID);
            db.AddInParameter(dbCommand, "IsUrgent", DbType.Boolean, isUrgent);

            // Execute the query and return the new identity value
            return Convert.ToInt64(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Selects a single record from the Task table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet Select(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelect");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="moduleId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByModuleId(Int64 moduleId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByModuleId");

            db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectByComponentId(Int64 componentId, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByComponentId");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, componentId);
            db.AddInParameter(dbCommand, "Status", DbType.Int64, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Task table by a foreign key.
        /// </summary>
        public DataSet SelectByComponentIdForComponentFolder(Int64 projectId,Int64 componentId, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByComponentIdForCompFolder");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "ComponentId", DbType.Int64, componentId);
            db.AddInParameter(dbCommand, "Status", DbType.Int64, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="projectId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByProjectId(Int64 projectId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByProjectId");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="projectId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectAllByClientId(Int64 clientID, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByClientId");

            db.AddInParameter(dbCommand, "UserId", DbType.Int64, clientID);
            db.AddInParameter(dbCommand, "status", DbType.Int16, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="projectId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByProjectIdBySort(Int64 projectId, int taskCompetionPercentage, int sortOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByProjectIdBySort");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "TaskCompletionPercentage", DbType.Int16, taskCompetionPercentage);
            db.AddInParameter(dbCommand, "SortOrder", DbType.Int32, sortOrder);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="projectId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByProjectIdAndUserId(Int64 userId, Int64 projectId,Int64 compID, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByProjectIdAndUserId");

            
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "ComponentId", DbType.Int64, compID);
            db.AddInParameter(dbCommand, "Status", DbType.Int16, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="userId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByUserId(Int64 userId, DateTime startDate, DateTime endDate, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByUserId");
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            if (startDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "startDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "startDate", DbType.DateTime, startDate);
            if (endDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "endDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "endDate", DbType.DateTime, endDate);
            db.AddInParameter(dbCommand, "status", DbType.Int16, status);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="userId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectSearchByUserId(Int64 userId, Int64 projectId, Int64 moduleId, string componentNumb, Int64 taskId, string wireframNo, string description, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSearchByUserId");
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);
            db.AddInParameter(dbCommand, "ComponentNumb", DbType.String, componentNumb);
            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "WireframNo", DbType.String, wireframNo);
            db.AddInParameter(dbCommand, "Description", DbType.String, description);
            db.AddInParameter(dbCommand, "status", DbType.Int16, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects my private tasks records from the Task table by a foreign key.
        /// <summary>
        /// <param name="userId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectMyPrivateTask(Int64 userId, DateTime startDate, DateTime endDate, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectMyPrivateTask");
            db.AddInParameter(dbCommand, "UserId", DbType.Int64, userId);
            if (startDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "startDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "startDate", DbType.DateTime, startDate);
            if (endDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "endDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "endDate", DbType.DateTime, endDate);
            db.AddInParameter(dbCommand, "status", DbType.Int16, status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select All task Category
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAllTaskCategory()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskCategorySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects task details from the Task table by a primary key.
        /// <summary>
        /// <param name="taskId"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectDetails(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectDetails");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Task table by a foreign key.
        /// <summary>
        /// <param name="assignTo"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectByAssignTo(Int64 assignTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectByAssignTo");

            db.AddInParameter(dbCommand, "AssignTo", DbType.Int64, assignTo);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Task table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects max TaskId from the Task table.
        /// <summary>
        /// <returns>DataSet</returns>
        public Int64 SelectMaxId()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectMaxId");

            return Convert.ToInt64(db.ExecuteScalar(dbCommand));
        }
        /// <summary>
        /// Selects Daily Task Update from the Task,Task Status And Task Comment Table.
        /// <summary>
        /// <returns>DataSet</returns>
        public DataSet SelectDaliyTaskUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectDailyTaskUpdate");
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Updates a record in the Task table.
        /// <summary>
        /// <param name="taskId"></param>
        /// <param name="projectId"></param>
        /// <param name="moduleId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="taskHours"></param>
        /// <param name="assignTo"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskStatus"></param>
        /// <param name="createdBy"></param>
        /// <param name="createddate"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void Update(Int64 taskId, Int64 projectId, Int64 moduleId, string componentNumber, string componentName, string wireframeNo, string title, string urlAddress, string description, double taskHours, Int64 assignTo, DateTime dueDate, int taskStatus, string audioFileName, string audioOriginalFileName, Int64 createdBy, DateTime createddate, Int64 modifiedBy, DateTime modifiedDate, Int64 taskCategoryID,bool isUrgent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskUpdate");


            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);
            db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);

            db.AddInParameter(dbCommand, "ComponentNumber", DbType.String, componentNumber);
            db.AddInParameter(dbCommand, "ComponentName", DbType.String, componentName);
            db.AddInParameter(dbCommand, "WireframeNo", DbType.String, wireframeNo);
            db.AddInParameter(dbCommand, "Title", DbType.String, title);
            db.AddInParameter(dbCommand, "URLAddress", DbType.String, urlAddress);
            db.AddInParameter(dbCommand, "Description", DbType.String, description);
            db.AddInParameter(dbCommand, "TaskHours", DbType.Double, taskHours);
            db.AddInParameter(dbCommand, "AssignTo", DbType.Int64, assignTo);
            db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, dueDate);
            db.AddInParameter(dbCommand, "TaskStatus", DbType.Int32, taskStatus);
            db.AddInParameter(dbCommand, "AudioFileName", DbType.String, audioFileName);
            db.AddInParameter(dbCommand, "AudioOriginalFileName", DbType.String, audioOriginalFileName);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int64, createdBy);
            db.AddInParameter(dbCommand, "Createddate", DbType.DateTime, createddate);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);
            db.AddInParameter(dbCommand, "TaskCategoryID", DbType.Int64, taskCategoryID);
            db.AddInParameter(dbCommand, "IsUrgent", DbType.Boolean, isUrgent);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Task table.
        /// <summary>
        /// <param name="taskId"></param>
        /// <param name="IsHold"></param>
        public void UpdateIsHold(Int64 taskId, bool isHold)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateTaskHoldStatus");


            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            db.AddInParameter(dbCommand, "IsHold", DbType.Int64, isHold);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record statuc and due date in the Task table.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskStatus"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void UpdateStatusAndDueDate(Int64 taskId, DateTime dueDate, int taskStatus, Int64 modifiedBy, DateTime modifiedDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskUpdateStatusAndDueDate");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);
            if (dueDate.Equals(DateTime.MinValue))
                db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, SqlDateTime.Null);
            else
                db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, dueDate);

            db.AddInParameter(dbCommand, "TaskStatus", DbType.Int32, taskStatus);
            db.AddInParameter(dbCommand, "ModifiedBy", DbType.Int64, modifiedBy);
            db.AddInParameter(dbCommand, "ModifiedDate", DbType.DateTime, modifiedDate);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Task table by a composite primary key.
        /// <summary>
        public void Delete(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskDelete");

            db.AddInParameter(dbCommand, "TaskId", DbType.Int64, taskId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Task table by a composite primary key.
        /// <summary>
        public void DeleteByService(Int64 taskId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskDeleteManual");

            db.AddInParameter(dbCommand, "TaskID", DbType.Int64, taskId);

            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// <summary>
        public void DeleteByModuleId(Int64 moduleId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskDeleteByModuleId");

            db.AddInParameter(dbCommand, "ModuleId", DbType.Int64, moduleId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// <summary>
        public void DeleteByProjectId(Int64 projectId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskDeleteByProjectId");

            db.AddInParameter(dbCommand, "ProjectId", DbType.Int64, projectId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Task table by a foreign key.
        /// <summary>
        public void DeleteByAssignTo(Int64 assignTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskDeleteByAssignTo");

            db.AddInParameter(dbCommand, "AssignTo", DbType.Int64, assignTo);

            db.ExecuteNonQuery(dbCommand);
        }

        ///<summary>
        ///get records for due mail
        ///<summary>
        public DataSet SelectPastDueDate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaskSelectPastDueDate");

            return db.ExecuteDataSet(dbCommand);
        }



    }
}
