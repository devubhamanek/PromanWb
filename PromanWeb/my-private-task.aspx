<%@ Page Title="WorkVue | My Private Tasks" Language="C#" MasterPageFile="~/masterpages/default.Master"
    AutoEventWireup="true" CodeBehind="my-private-task.aspx.cs" Inherits="PromanWeb.my_private_task" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="task-detail">
        <div class="heading">
            <h2>
                My Private Tasks
            </h2>
        </div>
        <div class="search">
            <table>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lblStartDate" runat="server" Text="From:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxDateEdit ID="dtStartDate" runat="server" Width="100px">
                            <ValidationSettings Display="None" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" ErrorText="Required" />
                            </ValidationSettings>
                            <ClientSideEvents Validation="function(s, e) {e.isValid = s.GetValue() != '0'; if(e.isValid != true) { e.errorText = 'Required';}}" />
                        </dx:ASPxDateEdit>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lblEndDate" runat="server" Text="To:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxDateEdit ID="dtEndDate" runat="server" Width="100px">
                            <ValidationSettings Display="None" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" ErrorText="Required" />
                            </ValidationSettings>
                            <ClientSideEvents Validation="function(s, e) {e.isValid = s.GetValue() != '0'; if(e.isValid != true) { e.errorText = 'Required';}}" />
                        </dx:ASPxDateEdit>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lblTaskStatus" runat="server" Text="Task Status:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="ddlTaskStatus" runat="server" SelectedIndex="0" ValueType="System.String"
                            Width="150px">
                            <Items>
                                <dx:ListEditItem Text="--All--" Value="0" />
                                <dx:ListEditItem Text="Open" Value="14" />
                                <dx:ListEditItem Text="Discuss" Value="28" />
                                <dx:ListEditItem Text="In Programming" Value="42" />
                                <dx:ListEditItem Text="Ready for Test" Value="56" />
                                <dx:ListEditItem Text="Bug Found" Value="70" />
                                <dx:ListEditItem Text="Bug Fixed" Value="84" />
                                <dx:ListEditItem Text="Closed" Value="100" />
                                <dx:ListEditItem Text="Not Closed" Value="1" />
                                <dx:ListEditItem Text="On Hold" Value="101" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSearch" runat="server" Text="Search">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:LinkButton runat="server" Font-Underline="false" OnCommand="searchimagelegend_Click"
                            ID="lnkLegendimage1" CommandArgument="14">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td style="padding-left: 13px;">
                                                                                          <img src="images/t14.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: Black;" class="taskdetailcolorlegendtext">
                                                                                        Open
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton OnCommand="searchimagelegend_Click" Font-Underline="false" runat="server"
                            ID="LinkButton1" CommandArgument="28">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/t28.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color:DarkGoldenRod;" class="taskdetailcolorlegendtext">
                                                                                        Discussion
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="searchimagelegend_Click" runat="server"
                            ID="LinkButton2" CommandArgument="42">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                          <img src="images/t42.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: blue;" class="taskdetailcolorlegendtext">
                                                                                        In Programming
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="searchimagelegend_Click" runat="server"
                            ID="LinkButton3" CommandArgument="56">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                         <img src="images/t56.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: purple;" class="taskdetailcolorlegendtext">
                                                                                        Ready For Test
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="searchimagelegend_Click" runat="server"
                            ID="LinkButton4" CommandArgument="70">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                       <img src="images/t70.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: red;" class="taskdetailcolorlegendtext">
                                                                                        Bug Found
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="searchimagelegend_Click" runat="server"
                            ID="LinkButton5" CommandArgument="84">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/t84.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: brown;" class="taskdetailcolorlegendtext">
                                                                                        Bug Fixed
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton Font-Underline="false" runat="server" ID="LinkButton6" CommandArgument="100"
                            OnCommand="searchimagelegend_Click">
                                                                            <table cellpadding="0" cellspacing="2" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/t100.png" height="20" width="19"/>
                                                                                    </td>
                                                                                    <td style="color: green;" class="taskdetailcolorlegendtext">
                                                                                        Closed
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="maindiv">
            <div class="subdiv">
                <div class="div-message default-padding-left">
                    <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
                </div>
                <div class="task-list-grid">
                    <dx:ASPxGridView ID="gvTaskList" ClientInstanceName="gvTaskList" runat="server" KeyFieldName="TaskId"
                        AutoGenerateColumns="False" Width="910px" OnHtmlRowCreated="gvTaskList_HtmlRowCreated">
                        <Columns>
                            <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="25px">
                                <DataItemTemplate>
                                    <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>&taskid=<%# Eval("TaskId") %>'>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIsUrgent" Font-Size="16px" runat="server" Font-Bold="true" ForeColor="Red"
                                                        Visible='<%#Convert.ToBoolean(Eval("IsUrgent")) %>' Text="!"></asp:Label>
                                                </td>
                                                <td>
                                                    <img id="imgView" runat="server" width="17" height="15" visible='<%#Convert.ToBoolean(Eval("Hold")) ? false : true %>'
                                                        src='<%#GetSearchImage(Convert.ToInt32(Eval("PercentageComplete")))%>' alt="View"
                                                        style="border: 0px;" title="View" />
                                                    <img id="imgIsHold" runat="server" width="17" height="15" src="~/images/t28.png"
                                                        visible='<%#Convert.ToBoolean(Eval("Hold")) %>' alt="View" />
                                                </td>
                                                <td>
                                                    <img id="img1" runat="server" width="15" visible='<%#ShowHideCommentImage(Convert.ToInt32(Eval("CommentCount")))%>'
                                                        height="15" src='<%#GetCommentImage(Convert.ToInt32(Eval("CommentCount")),Convert.ToInt32(Eval("PercentageComplete")))%>'
                                                        alt="View" style="border: 0px;" title="View" />
                                                </td>
                                            </tr>
                                        </table>
                                    </a>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Last Name" FieldName="LastName" Width="65px" VisibleIndex="1" />
                            <dx:GridViewDataColumn Caption="First Name" FieldName="FirstName" Width="65px" VisibleIndex="2" />
                            <dx:GridViewDataColumn Caption="Project Name" Width="105px" FieldName="ProjectName"
                                VisibleIndex="3">
                                <DataItemTemplate>
                                    <%--<a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>' class="project-name"
                                        <%#"style=\"color:" +GetColorForLink(Convert.ToInt32(Eval("PercentageComplete")))+"\"" %>>
                                        <%# Eval("ProjectName")%></a>--%>
                                    <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>' class="project-name"
                                        style='color: <%#GetColorForLink(Convert.ToInt32(Eval("PercentageComplete")))%>;
                                        display: <%#Convert.ToBoolean(Eval("Hold"))? "none" :"block"%>;'>
                                        <%# Eval("ProjectName")%></a> <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>'
                                            class="project-name" style='color: DarkGoldenRod; display: <%#Convert.ToBoolean(Eval("Hold"))? "block" :"none"%>;'>
                                            <%# Eval("ProjectName")%></a>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Status" FieldName="TaskStatus" Width="45px" VisibleIndex="4">
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Due In" FieldName="DueIn" Width="45px" VisibleIndex="5" />
                            <dx:GridViewDataColumn Caption="Assigned By" FieldName="AssignByName" Width="100px"
                                VisibleIndex="6" />
                            <dx:GridViewDataColumn Caption="Days Open" FieldName="DaysOpen" Width="45px" VisibleIndex="7" />
                            <dx:GridViewDataColumn Caption="Task ID" FieldName="TaskId" Width="45px" VisibleIndex="8">
                                <DataItemTemplate>
                                    <%--<a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>&taskid=<%# Eval("TaskId") %>'
                                        class="project-name" <%#"style=\"color:" +GetColorForLink(Convert.ToInt32(Eval("PercentageComplete")))+"\"" %>>
                                        <%#Convert.ToBoolean(Eval("Hold")) ? ("H -" + Eval("TaskId")) : Eval("TaskId")%></a>--%>
                                    <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>&taskid=<%# Eval("TaskId") %>'
                                        class="project-name" style='color: <%#GetColorForLink(Convert.ToInt32(Eval("PercentageComplete")))%>;
                                        display: <%#Convert.ToBoolean(Eval("Hold"))? "none" :"block"%>;'>
                                        <%#Convert.ToBoolean(Eval("Hold")) ? ("H -" + Eval("TaskId")) : Eval("TaskId")%></a>
                                    <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>&taskid=<%# Eval("TaskId") %>'
                                        class="project-name" style='color: DarkGoldenRod; display: <%#Convert.ToBoolean(Eval("Hold"))? "block" :"none"%>;'>
                                        <%#Convert.ToBoolean(Eval("Hold")) ? ("H -" + Eval("TaskId")) : Eval("TaskId")%></a>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Task Status" FieldName="PercentageComplete" Visible="false" />
                        </Columns>
                        <Settings ShowFilterRow="True" />
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
