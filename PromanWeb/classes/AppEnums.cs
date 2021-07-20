using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromanWeb
{
    // All application level enums are stored here

    // <summary>
    /// Type of the message to be disp
    /// </summary>
    public enum MessageType
    {
        Information = 0,
        Warning = 1,
        Error = 2,
        Success = 3
    }

    // <summary>
    /// Set Roles of Admin and NormalUser
    /// </summary>
    public enum Roles
    {
        SuperAdmin = 1,
        ProjectManager = 2,
        TaskOwner = 3,
        Client = 4,
        Marketing=5
    }

    // <summary>
    /// Set Roles of Admin and NormalUser
    /// </summary>
    public enum DTask
    {
        Open = 1,
        Close = 2,
    }

    /// <summary>
    /// Set ActiVityLog name for all pages of website
    /// </summary>
    public enum ActiVityLog
    {
        Sign_In = 1,
        Sign_Out = 2,
        User_Management = 3,
        SessionStart = 4
    }

    /// <summary>
    /// Status of the project
    /// </summary>
    public enum ProjectStatus
    {
        Open = 1,
        Close = 2,
        Pending = 3
    }

    /// <summary>
    /// Status of the task
    /// </summary>
    public enum TaskStatus
    {
        Open = 14,
        Discuss = 28,
        InProgramming = 42,
        ReadyforTest = 56,
        BugFound =70,
        BugFixed=84,
        Closed=100
    }

    /// <summary>
    /// Templates ued in the application mostly mail template
    /// </summary>
    public enum Templates
    {
        // When new task assigned to user this mail is generated
        TASK_ASSIGNMENT_MAIL = 0,
        TASK_DUE_MAIL = 1,
        CLIENT_STARTTASK_MAIL=2,
        CLIENT_ENDTASK_MAIL=3,
        DAILY_UPDATE_MAIL=4,
        CLIENT_TASKCOMMENT_MAIL=5,
        TASK_STATUS_UPDATE_MAIL=6,
        UPDATE_MAIL=7,
        Client_Pm_OpenTask=8,
        CLIENT_TASK_UPDATE_MAIL=9,
        SEND_MAIL_OF_COMMENT_TO_CLIENT=25,
        SEND_MAIL_TO_PARTICIPANT = 26

    }
}