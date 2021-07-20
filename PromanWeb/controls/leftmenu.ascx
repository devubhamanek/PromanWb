<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftmenu.ascx.cs" Inherits="PromanWeb.controls.leftmenu" %>
<ul runat="server" id="LeftmenuControl">
    <%--<li><a id="Role" runat="server" href="~/role/role.aspx"><span>Role Management</span></a></li>
    <li><a id="Activity" runat="server" href="~/role/activity.aspx"><span>Activity Management</span></a></li>--%>
    <li><a id="ProjectQueue" runat="server" href='~/project-queue.aspx'><span>Active Projects</span></a></li>
    <li><a id="ProjectQueueClosed" runat="server" href="~/project-queue-closed.aspx"><span>Closed Projects</span></a></li>
    <li><a id="ProjectCreator" runat="server" href='~/project-creator.aspx'><span>Create New Project</span></a></li>
    <li><a id="ProjectTaskQueue" runat="server" href='~/task-list.aspx'><span>All Project Tasks</span></a></li>
    <li><a id="CreateNewTask" runat="server" href='~/create-task.aspx'><span>Create New Task</span></a></li>
    <li><a id="MyPrivateTasks" runat="server" href='~/my-private-task.aspx'><span>My Private Tasks</span></a></li>
    <li><a id="UserManager" runat="server" href='~/user-management.aspx'><span>User Management</span></a></li>
    <li><a id="Closedtasks" runat="server" href='~/closed-tasks.aspx'><span>Closed Tasks</span></a></li>
    <li><a id="Searchtask" runat="server" href="~/Search-task.aspx"><span>Search Tasks</span></a></li>
    <li><a id="MyDesktop" runat="server" href="~/mydesktop.aspx"><span>My Desktop</span></a></li>
   <%-- <li><a id="Lead" runat="server" visible="false" href='~/lead.aspx'><span>Lead</span></a></li>--%>
    <li><a id="SignOut" runat="server" href='~/account/signout.aspx'><span>SignOut</span></a></li>
</ul>
