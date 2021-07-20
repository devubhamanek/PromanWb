<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true"
    CodeBehind="Search-task.aspx.cs" Inherits="PromanWeb.Search_task" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function OnSelectedIndexChanged(ddlProjectName) {
            if (ddlProjectName.GetSelectedIndex() == 0) {
                ddlComp.SetSelectedIndex(0);
                ddlComp.SetValue(null);
                ddlComp.ClearItems()
                ddlModule.SetSelectedIndex(0);
                ddlModule.SetValue(null);
                ddlModule.ClearItems();
            }
            else {
                ddlModule.PerformCallback(ddlProjectName.GetValue().toString());
                ddlComp.SetSelectedIndex(0);
                ddlComp.SetValue(null);
                ddlComp.ClearItems();
            }
            //ddlComp.SetEnabled(false);
        }

        function OnSelectedIndexChanged1(ddlModule) {
            if (ddlModule.GetSelectedIndex() == 0) {
                ddlComp.SetSelectedIndex(0);
                ddlComp.SetValue(null);
                ddlComp.ClearItems();
            }
            else {
                ddlComp.PerformCallback(ddlModule.GetValue().toString());
                //ddlComp.SetEnabled(true);
            }
        }
        function bye() {
            window.close();
        }

        //Below script is for Change the color into Project's Combobox;
        var per = new Array();
        per = '<%=ProjectPercet%>'
        per = per.split(',');
        function OnclientComboBox_Init(s, e) {
            ChangeColors();
        }
        function ChangeColors() {
            var item;
            var v = 0;
            //            alert(per);
            for (var j = 0; j < per.length; j++) {
                if (per[j] == "100") {
                    if (ASPxClientUtils.chrome || ASPxClientUtils.safari) {
                        item = ddlProjectName.listBox.GetItemElement(j);
                        v = 0;
                    }
                    else {
                        item = ddlProjectName.listBox.GetItemElement(j).firstElementChild;
                        v = 0;
                    }
                }
                else {
                    if (ASPxClientUtils.chrome || ASPxClientUtils.safari) {
                        item = ddlProjectName.listBox.GetItemElement(j);
                        v = 1;
                    }
                    else {
                        item = ddlProjectName.listBox.GetItemElement(j).firstElementChild;
                        v = 1;
                    }

                }
                item.style.color = (v == 0) ? "Green" : "Black";
            }
        }
        function OnSelectedIndexChangedColor() {

            var v = ddlProjectName.GetSelectedIndex();

            var item;

            if (per[v] == '100') {

                ddlProjectName.GetInputElement().style.color = "Green";
            }
            else {
                ddlProjectName.GetInputElement().style.color = "Black";
            }
        }

        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function ProcessKeyPress(s, evt) {
            var charCode = (evt.htmlEvent.which) ? evt.htmlEvent.which : event.keyCode

            if (charCode > 31 && (charCode < 48 || charCode > 57))

                _aspxPreventEvent(evt.htmlEvent);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="Search-task">
        <div class="heading">
            <h2>
                Search
            </h2>
        </div>
        <div class="maindiv">
            <div class="subdiv">
                <div class="div-message default-padding-left">
                    <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
                </div>
                <table cellpadding="2" cellspacing="3" border="0" width="100%">
                    <tr>
                        <td align="right" valign="top">
                            Select Project Name:
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxComboBox ID="ddlProjectName" runat="server" DropDownStyle="DropDownList"
                                ClientInstanceName="ddlProjectName" IncrementalFilteringMode="StartsWith" EnableSynchronization="False"
                                Width="300px">
                                <ClientSideEvents Init="OnclientComboBox_Init" SelectedIndexChanged="function(s, e) { OnSelectedIndexChanged(s);OnSelectedIndexChangedColor(); }" />
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Select Module:
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxComboBox ID="ddlModule" runat="server" ClientInstanceName="ddlModule" OnCallback="ddlModule_Callback"
                                Width="300px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnSelectedIndexChanged1(s); }" />
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Component :
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxComboBox ID="ddlComponent" ClientInstanceName="ddlComp" runat="server" Width="300px"
                                OnCallback="ddlComponent_Callback">
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Task Number:
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxTextBox ID="txtTaskNumber" runat="server" CssClass="input-txt" Width="150px">
                                <ClientSideEvents KeyPress="function(s,e) {ProcessKeyPress(s, e);}" />
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Task Status:
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="ddlTaskStatus" runat="server" SelectedIndex="1" ValueType="System.String"
                                Width="150px">
                                <Items>
                                    <dx:ListEditItem Text="--Select Status--" Value="-1" />
                                    <dx:ListEditItem Text="All" Value="0" />
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
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Wireframe Number:
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxTextBox ID="txtWireFrameNo" runat="server" CssClass="input-txt" Width="150px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Task Description:
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxMemo ID="txtTaskDescription" runat="server" Height="175px" Width="425px">
                            </dx:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <dx:ASPxButton ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_OnClick">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </div>
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
                        <asp:LinkButton OnCommand="searchimagelegend_Click" runat="server" ID="LinkButton1"
                            CommandArgument="28" Font-Underline="false">
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
                        <asp:LinkButton OnCommand="searchimagelegend_Click" runat="server" ID="LinkButton2"
                            CommandArgument="42" Font-Underline="false">
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
                        <asp:LinkButton OnCommand="searchimagelegend_Click" runat="server" ID="LinkButton3"
                            CommandArgument="56" Font-Underline="false">
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
                        <asp:LinkButton OnCommand="searchimagelegend_Click" runat="server" ID="LinkButton4"
                            CommandArgument="70" Font-Underline="false">
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
                        <asp:LinkButton OnCommand="searchimagelegend_Click" runat="server" ID="LinkButton5"
                            CommandArgument="84" Font-Underline="false">
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
                        <asp:LinkButton runat="server" ID="LinkButton6" CommandArgument="100" OnCommand="searchimagelegend_Click"
                            Font-Underline="false">
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
        <div class="search">
            <div class="task-list-grid">
                <dx:ASPxGridView ID="gvTaskList" ClientInstanceName="gvTaskList" runat="server" KeyFieldName="TaskId"
                    AutoGenerateColumns="False" Width="910px" OnHtmlRowCreated="gvTaskList_HtmlRowCreated"
                    Visible="true">
                    <Columns>
                        <dx:GridViewDataColumn Caption="View" Width="25px" VisibleIndex="0">
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
                        <dx:GridViewDataColumn Caption="IsHold" FieldName="Hold" Visible="false" />
                        <dx:GridViewDataComboBoxColumn Caption="Project Name" FieldName="ProjectName" VisibleIndex="3">
                            <PropertiesComboBox IncrementalFilteringMode="StartsWith" DropDownStyle="DropDown" />
                            <DataItemTemplate>
                                <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>' class="project-name"
                                    style='color: <%#GetColorForLink(Convert.ToInt32(Eval("PercentageComplete")))%>;
                                    display: <%#Convert.ToBoolean(Eval("Hold"))? "none" :"block"%>;'>
                                    <%# Eval("ProjectName")%></a> <a href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>'
                                        class="project-name" style='color: DarkGoldenRod; display: <%#Convert.ToBoolean(Eval("Hold"))? "block" :"none"%>;'>
                                        <%# Eval("ProjectName")%></a>
                            </DataItemTemplate>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataColumn Caption="Status" FieldName="TaskStatus" Width="50" VisibleIndex="4">
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Due In" FieldName="DueIn" Width="55px" VisibleIndex="5" />
                        <dx:GridViewDataColumn Caption="Assigned By" FieldName="AssignByName" Width="100px"
                            VisibleIndex="6" />
                        <dx:GridViewDataColumn Caption="WF ID" FieldName="WireframeNo" Width="60px" VisibleIndex="6" />
                        <dx:GridViewDataColumn Caption="Days Open" FieldName="DaysOpen" Width="35px" VisibleIndex="7" />
                        <dx:GridViewDataColumn Caption="Task ID" FieldName="TaskId" Width="55px" VisibleIndex="8">
                            <DataItemTemplate>
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
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
