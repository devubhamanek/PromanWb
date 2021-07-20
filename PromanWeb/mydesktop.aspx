<%@ Page Title="My Desktop" Language="C#" MasterPageFile="~/masterpages/default.Master"
    AutoEventWireup="true" CodeBehind="mydesktop.aspx.cs" Inherits="PromanWeb.mydesktop" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <script type="text/javascript">
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



            //ddlModule.PerformCallback(ddlProjectName.GetValue().toString());
        }
    </script>
    <style type="text/css">
        .divclosetaskheader
        {
            color: #C00000;
            font-size: 25px;
            width: 892px;
            height: 66px;
            font-weight: bold;
            font-family: Arial !important;
            border: 1px solid #8BA0BC;
            border-bottom: none;
        }
        
        .divclosetaskheader .subdiv
        {
            float: right;
            border-left: 1px solid #8BA0BC;
            width: 81px;
            height: 66px;
        }
        .divtaskdetails
        {
            width: 99%;
            border: 1px solid black;
            margin-top: 10px;
            margin-bottom: 10px;
            min-height: 300px;
        }
        
        .divtaskdetails .divtaskdetailssub
        {
            background: none repeat scroll 0 0 #99CCFF;
            font-size: 12px;
            font-weight: bold;
            height: 22px;
            padding-left: 10px;
            padding-top: 5px;
            width: 900px;
        }
        a
        {
            color: Blue !important;
            text-decoration: underline !important;
        }
        .tdright
        {
            text-align: left;
            padding-left: 5px;
        }
        .tdleft
        {
            text-align: right;
          
        }
        
        
        .tdright1
        {
            text-align: left;
            padding-left: 5px;
            font-weight: bold;
        }
        .tdleft1
        {
            text-align: right;
            width: 20%;
        }
    </style>
    <div class="task-detail">
        <div class="heading">
            <h2>
                Work Desk
            </h2>
            <br />
        </div>
        <asp:Label runat="server" EnableViewState="false" ID="lblStatus"></asp:Label>
        <div style="line-height: 15px; padding: 10px;">
            Welcome to My Desktop. Here, you can create and manage a list of a work you need
            to do. Whether it’s sending someone a longer overdue email, tackling that difficult
            algorithm you’ve been putting off, having that needed conference call, starting
            an important R&D study or validating a testing element, you can create and manage
            the task right here on your desktop.
        </div>
        <div>
            <dx:ASPxPageControl ID="pgrDesktop" runat="server" ActiveTabIndex="0" ClientInstanceName="PageControlSendPrintInvoice"
                Width="100%" ActiveTabStyle-BackColor="White" ActiveTabStyle-ForeColor="Blue"
                TabStyle-Font-Size="13px" TabStyle-Font-Names="Arial" ActiveTabStyle-Font-Bold="true"
                TabStyle-Font-Bold="true"   TabStyle-BackColor="#558ED5" TabStyle-ForeColor="White">
                <TabPages>
                    <dx:TabPage Name="OpenTask" Text="Open DeskTop Task(4)">
                        <ContentCollection>
                            <dx:ContentControl>
                                <div id="divgvAllUnsentInvoices">
                                    <dx:ASPxGridView ID="gvOpenTask" KeyFieldName="DTaskID" runat="server" Width="100%"
                                        ClientIDMode="AutoID" ClientInstanceName="gvAllUnsentInvoices" OnHtmlRowCreated="gvOpenTask_HtmlRowCreated"
                                        OnRowCommand="gvOpenTask_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="Days Open" FieldName="IsUrgent" Width="80px" VisibleIndex="0"
                                                Visible="false">
                                                <DataItemTemplate>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="View" VisibleIndex="1">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="lnkProfileID" CommandName="E" runat="server" CommandArgument='<%#Eval("DTaskID")%>'>
                                                        <img id="imgView" runat="server" src="~/images/search.png" width="20" title="View"
                                                            alt="" />
                                                    </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Date Created" FieldName="CreationDate" Width="90px"
                                                VisibleIndex="2">
                                                <DataItemTemplate>
                                                    <%# Convert.ToDateTime(Eval("CreationDate")).ToString("MM-dd-yyyy")%></DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Days Open" FieldName="DaysOpen" Width="80px" VisibleIndex="3">
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Project Name" VisibleIndex="4" FieldName="ProjectName"
                                                Width="100px">
                                                <DataItemTemplate>
                                                    <a href='<%#GetProjectLink(Convert.ToInt64(Eval("ProjectID")))%>'>
                                                        <%#Eval("ProjectName")%>
                                                    </a>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Task ID" VisibleIndex="5" FieldName="TaskNumber">
                                                <DataItemTemplate>
                                                    <a runat="server" visible='<%#VISIBLETF(Convert.ToString(Eval("TaskNumber")))%>' href='<%#GetTaskLink(Convert.ToString(Eval("TaskNumber")),Convert.ToInt64(Eval("ProjectID")))%>'>
                                                        <%#Eval("TaskNumber")%>
                                                    </a>
                                                    <asp:Label runat="server" Visible='<%#VISIBLETF1(Convert.ToString(Eval("TaskNumber")))%>' Text="--" ></asp:Label>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Task Details" Width="350px" VisibleIndex="6" FieldName="Description">
                                                <DataItemTemplate>
                                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%#GetDescription(Convert.ToString(Eval("Description")))%>'
                                                        CssClass="right_align"></asp:Label>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Delete" VisibleIndex="7">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="lnkProfileID" OnClientClick="javascript: return confirm('Once deleting a task, it cannot be recovered. Are you sure you want to permanently delete this task?');"
                                                        CommandName="D" runat="server" CommandArgument='<%#Eval("DTaskID")%>'>
                                                        <img id="imgView" runat="server" src="~/images/delete.png" width="20" title="View"
                                                            alt="" />
                                                    </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsPager PageSize="30" AlwaysShowPager="true">
                                            <Summary AllPagesText="Page {0} of {1} ( {2} Tasks )" Text="Page {0} of {1} ( {2} Tasks )">
                                            </Summary>
                                        </SettingsPager>
                                        <Settings ShowFilterRow="True" />
                                    </dx:ASPxGridView>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Name="CloseTask" Text="Closed DeskTop Task (4)">
                        <ContentCollection>
                            <dx:ContentControl>
                                <div class="divclosetaskheader">
                                    <div style="float: left; margin-top: 10px; margin-left: 152px;">
                                        My Desktop - Closed Tasks</div>
                                    <div class="subdiv">
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxCheckBox AutoPostBack="true" ID="chkSelectforDelete" ClientInstanceName="chkSelectforDelete"
                                                        runat="server" OnCheckedChanged="chkSelectforDelete_CheckedChanged">
                                                    </dx:ASPxCheckBox>
                                                </td>
                                                <td>
                                                    <img src="images/recycle.png" width="30px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:ImageButton Width="56px" Height="30px" Enabled="false" ImageUrl="~/images/btndeletedisable.png"
                                                        ID="btnimgDelete" OnClientClick="javascript : return confirm('Once deleting these tasks, they cannot be recovered. Are you sure you want to permanently delete all of these tasks?');"
                                                        runat="server" OnClick="btnimgDelete_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="div1">
                                    <dx:ASPxGridView ID="gvCloseTask" KeyFieldName="DTaskID" runat="server" Width="100%"
                                        ClientIDMode="AutoID" OnHtmlRowCreated="gvCloseTask_HtmlRowCreated" OnRowCommand="gvCloseTask_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="Days Open" FieldName="IsUrgent" Width="80px" VisibleIndex="0"
                                                Visible="false">
                                                <DataItemTemplate>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="View" VisibleIndex="1">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="lnkProfileID" CommandName="E" runat="server" CommandArgument='<%#Eval("DTaskID")%>'>
                                                        <img id="imgView" runat="server" src="~/images/search.png" width="20" height="17"
                                                            title="View" alt="" />
                                                    </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Date Closed" FieldName="CreationDate" Width="90px"
                                                VisibleIndex="2">
                                                <DataItemTemplate>
                                                    <%# Convert.ToDateTime(Eval("CloseDate")).ToString("MM-dd-yyyy")%></DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Project Name" VisibleIndex="4" FieldName="ProjectName"
                                                Width="100px">
                                                <DataItemTemplate>
                                                    <a href='<%#GetProjectLink(Convert.ToInt64(Eval("ProjectID")))%>'>
                                                        <%#Eval("ProjectName")%>
                                                    </a>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Task ID" VisibleIndex="5" FieldName="TaskNumber">
                                              <DataItemTemplate>
                                                    <a id="A1" runat="server" visible='<%#VISIBLETF(Convert.ToString(Eval("TaskNumber")))%>' href='<%#GetTaskLink(Convert.ToString(Eval("TaskNumber")),Convert.ToInt64(Eval("ProjectID")))%>'>
                                                        <%#Eval("TaskNumber")%>
                                                    </a>
                                                    <asp:Label ID="Label1" runat="server" Visible='<%#VISIBLETF1(Convert.ToString(Eval("TaskNumber")))%>' Text="--" ></asp:Label>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Task Details" Width="350px" VisibleIndex="6" FieldName="Description">
                                                <DataItemTemplate>
                                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%#GetDescription(Convert.ToString(Eval("Description")))%>'
                                                        CssClass="right_align"></asp:Label>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewCommandColumn Width="50px" VisibleIndex="7" ShowSelectCheckbox="true">
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsPager PageSize="30" AlwaysShowPager="true">
                                            <Summary AllPagesText="Page {0} of {1} ( {2} Tasks )" Text="Page {0} of {1} ( {2} Tasks )">
                                            </Summary>
                                        </SettingsPager>
                                        <Settings ShowFilterRow="True" />
                                    </dx:ASPxGridView>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Name="CreateTask" Text="Create Desktop Task">
                        <ContentCollection>
                            <dx:ContentControl>
                                <div id="div2">
                                    <table width="100%" cellpadding="0" cellspacing="5">
                                        <tr>
                                            <td colspan="2" style="padding-left:50px;">
                                                * Indicates a mandatory field
                                                <br /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft">
                                                * Creation Date:
                                            </td>
                                            <td class="tdright">
                                                <dx:ASPxDateEdit ID="dtCreationDate" runat="server" Width="100px">
                                                    <ValidationSettings Display="Dynamic" CausesValidation="false" ErrorDisplayMode="ImageWithTooltip"
                                                        SetFocusOnError="True" ValidateOnLeave="False">
                                                        <RequiredField IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft">
                                                * Project Name:
                                            </td>
                                            <td class="tdright">
                                                <dx:ASPxComboBox ID="ddlProjectName" runat="server" DropDownStyle="DropDownList"
                                                    ClientInstanceName="ddlProjectName" IncrementalFilteringMode="StartsWith" EnableSynchronization="False"
                                                    Width="300px">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Init="OnclientComboBox_Init" Validation="function(s, e) {e.isValid = s.GetValue() != '0'; if(e.isValid != true) { e.errorText = 'Required';}}" />
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft">
                                                Task Number:
                                            </td>
                                            <td class="tdright">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtTaskNumber" runat="server" CssClass="input-txt" Width="100px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            (Optional)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft" valign="top">
                                                * Task Description:
                                            </td>
                                            <td class="tdright">
                                                <dx:ASPxMemo ID="txtTaskDescription" runat="server" Height="175px" Width="425px">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                        <RequiredField IsRequired="true" ErrorText="Required" />
                                                    </ValidationSettings>
                                                </dx:ASPxMemo>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft">
                                                Urgent:
                                            </td>
                                            <td class="tdright">
                                                <dx:ASPxCheckBox ID="chkIsUrgent" runat="server" Checked="false">
                                                </dx:ASPxCheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdleft">
                                                &nbsp;
                                            </td>
                                            <td class="tdright">
                                                <dx:ASPxButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Desktop Task">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
                <ActiveTabStyle BackColor="White" Font-Bold="True" ForeColor="Blue">
                </ActiveTabStyle>
                <TabStyle BackColor="#558ED5" Font-Bold="True" Font-Names="Arial" Font-Size="13px"
                    ForeColor="White">
                </TabStyle>
            </dx:ASPxPageControl>
        </div>
        <div class="divtaskdetails" runat="server" id="divtaskdetails" visible="false">
            <div class="divtaskdetailssub">
                Task Details</div>
            <br />
            <table width="98%" cellpadding="0" cellspacing="10">
                <tr>
                    <td class="tdleft1">
                        Project Name:
                    </td>
                    <td class="tdright1">
                        <asp:Label runat="server" ID="lblProjectname"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdleft1">
                        Task Number:
                    </td>
                    <td class="tdright1">
                        <asp:Label runat="server" ID="lbltasknumber"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdleft1" valign="top">
                        Task Description:
                    </td>
                    <td>
                        <asp:Label runat="server" Width="300px" ID="lblDescription"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdleft1">
                        Creation Date:
                    </td>
                    <td class="tdright1">
                        <asp:Label runat="server" ID="lblCreationDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdleft1">
                        Is Urgent:
                    </td>
                    <td class="tdright1">
                        <asp:Label runat="server" ID="lblUrgent"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdleft1">
                        &nbsp;
                    </td>
                    <td class="tdright1">
                        <table>
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="btnClose" runat="server" CausesValidation="false" Text="Close Task"
                                        OnClick="btnClose_Click">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" Text="Cancel"
                                        OnClick="btnCancel_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
