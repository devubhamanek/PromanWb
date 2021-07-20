<%@ Page Title="Project Creator | Project Task Manager" Language="C#" MasterPageFile="~/masterpages/default.Master"
    AutoEventWireup="true" CodeBehind="project-creator.aspx.cs" Inherits="PromanWeb.project_creator" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v10.2.Web, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SetMaxLength(memo, maxLength) {
            if (!memo)
                return;
            if (typeof (maxLength) != "undefined" && maxLength >= 0) {
                memo.maxLength = maxLength;
                memo.maxLengthTimerToken = window.setInterval(function () {
                    var text = memo.GetText();
                    if (text && text.length > memo.maxLength)
                        memo.SetText(text.substr(0, memo.maxLength));
                }, 10);
            } else if (memo.maxLengthTimerToken) {
                window.clearInterval(memo.maxLengthTimerToken);
                delete memo.maxLengthTimerToken;
                delete memo.maxLength;
            }
        }
        function OnMaxLengthChanged(s, e) {

            var maxLength = 1000;
            SetMaxLength(s, maxLength);


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="project-creator">
        <div class="heading">
            <h2>
                <span id="spanHeading" runat="server"></span>
            </h2>
        </div>
        <div class="maindiv">
            <div class="subdiv">
                <div class="div-message default-padding-left">
                    <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
                </div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="mandatory" colspan="2">
                            <span>*Indicates Mandatory Response</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>Project Number : </span>
                        </td>
                        <td class="enter-project-name">
                            <span id="spanProjectNumber" runat="server" class="enter-project-number"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>*Enter Project Name : </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxTextBox ID="txtProjectName" runat="server" CssClass="input-txt" MaxLength="200">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                    ValidationGroup="Project">
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>*Who is Project Owner? </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxComboBox ID="ddlProjectOwner" runat="server" CssClass="project-owner">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                    ValidationGroup="Project">
                                </ValidationSettings>
                                <ClientSideEvents Validation="function(s, e) {
                                              e.isValid = s.GetValue() != '-Select Project Owner-';
                            }" />
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>Who is Client? </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxComboBox ID="ddlProjectClient" runat="server" CssClass="project-owner">
                               
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-description">
                            <span>*Project Description : </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxMemo ID="txtProjectDescription" runat="server" Height="150px" Width="420px">
                                <ValidationSettings SetFocusOnError="True" ErrorFrameStyle-VerticalAlign="Top" ErrorDisplayMode="ImageWithTooltip"
                                    ValidationGroup="Project">
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                                <ClientSideEvents KeyUp="function(s,e){OnMaxLengthChanged(s,e)}" />
                            </dx:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>*Project Due Date? </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxDateEdit ID="txtDueDate" runat="server" CssClass="due-date">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                    ValidationGroup="Project">
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                        </td>
                        <td class="enter-project-name">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" class="heading-avtar-img">
                                        <span>Upload Project Avator Image</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxUploadControl ID="filelAvatorImage" runat="server" Width="300px">
                                        </dx:ASPxUploadControl>
                                    </td>
                                    <td class="upload-btn">
                                        <dx:ASPxButton ID="btnUpload" runat="server" Text="Upload" CausesValidation="false"
                                            OnClick="btnUpload_Click">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <dx:ASPxLabel ID="lblFileStatus" runat="server">
                                        </dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <img id="imgAvtar" runat="server" alt="" src="" height="115" width="170" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lnkAvtarImageDelete" runat="server" OnClick="lnkAvtarImageDelete_Click"
                                            ToolTip="Delete project avator image" OnClientClick="return confirm('Are you sure want to delete project avator image?');">Delete</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="avtar-width-height">
                                        <span id="spanAvtarvalidation" runat="server"></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="project-name">
                            <span>*Enter Company Name : </span>
                        </td>
                        <td class="enter-project-name">
                            <dx:ASPxTextBox ID="txtCompanyName" runat="server" CssClass="input-txt" MaxLength="200">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                    ValidationGroup="Project">
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <div class="sub-heading">
                    <h2>
                        Modules
                    </h2>
                </div>
                <div class="module-txt">
                    <span>Name each of the modules associated with the project.</span>
                </div>
                <div class="modules">
                    <dx:ASPxGridView ID="gvModules" ClientInstanceName="grid" runat="server" KeyFieldName="ModuleId"
                        Width="610px" AutoGenerateColumns="False" OnRowCommand="gvModules_RowCommand"
                        OnHtmlRowCreated="gvModules_HtmlRowCreated">
                        <Columns>
                            <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="50">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" CausesValidation="false"
                                        CommandArgument='<%# Eval("ModuleId") %>'>
                                        <img id="Img1" runat="server" src="~/images/img_Search.png" alt="View" style="border: 0px;"
                                            title="View" /></asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn Caption="ModuleId" FieldName="ModuleId" VisibleIndex="1"
                                Width="70" />
                            <dx:GridViewDataTextColumn Caption="Module Name" FieldName="ModuleName" VisibleIndex="2"
                                Width="390" />
                            <dx:GridViewDataColumn Caption="Created date" FieldName="Createddate" VisibleIndex="3"
                                Width="100" />
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="NextColumn" />
                        <SettingsPager PageSize="10" Position="Bottom" SEOFriendly="Disabled">
                            <FirstPageButton Visible="True">
                            </FirstPageButton>
                            <LastPageButton Visible="True">
                            </LastPageButton>
                            <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Modules)" />
                        </SettingsPager>
                    </dx:ASPxGridView>
                </div>
                <div class="modules-add">
                    <table>
                        <tr>
                            <td class="project-name">
                                <span>Module Name : </span>
                            </td>
                            <td class="enter-project-name">
                                <dx:ASPxTextBox ID="txtModuleName" runat="server" CssClass="input-txt" MaxLength="200">
                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="module">
                                        <RequiredField IsRequired="True" ErrorText="Required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="project-name">
                            </td>
                            <td class="enter-project-name">
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnAddModule" runat="server" Text="Add/Update Module" ValidationGroup="module"
                                                OnClick="btnAddModule_Click">
                                            </dx:ASPxButton>
                                        </td>
                                      <%--  <td>
                                            <dx:ASPxButton ID="btnUpdateModule" runat="server" Text="Update Module" CausesValidation="false"
                                                OnClick="btnUpdateModule_Click" Visible="false">
                                            </dx:ASPxButton>
                                        </td>--%>
                                        <td>
                                            <dx:ASPxButton ID="btnDeleteModule" runat="server" Text="Delete Module" CausesValidation="false"
                                                OnClick="btnDeleteModule_Click" Visible="false">
                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure want to delete this module?'); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- COMPONENT MECHANISM--%>
                <div class="sub-heading">
                    <h2>
                        Component
                    </h2>
                </div>
                <div class="module-txt">
                    <span>Name each of the component associated with the module.</span>
                </div>
                <div class="modules">
                    <dx:ASPxGridView ID="gvComponents" ClientInstanceName="grid" runat="server" KeyFieldName="ComponentId"
                        Width="610px" AutoGenerateColumns="False" OnRowCommand="gvComponents_RowCommand">
                        <Columns>
                            <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="50">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" CausesValidation="false"
                                        CommandArgument='<%# Eval("ComponentId") %>'>
                                        <img id="Img1" runat="server" src="~/images/img_Search.png" alt="View" style="border: 0px;"
                                            title="View" /></asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn Caption="ComponentId" FieldName="ComponentId" VisibleIndex="1"
                                Width="70" />
                            <dx:GridViewDataTextColumn Caption="Component Name" FieldName="ComponentName" VisibleIndex="2"
                                Width="390" />
                            <dx:GridViewDataColumn Caption="Created date" FieldName="CreatedDate" VisibleIndex="3"
                                Width="100" />
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="NextColumn" />
                        <SettingsPager PageSize="10" Position="Bottom" SEOFriendly="Disabled">
                            <FirstPageButton Visible="True">
                            </FirstPageButton>
                            <LastPageButton Visible="True">
                            </LastPageButton>
                            <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Components)" />
                        </SettingsPager>
                    </dx:ASPxGridView>
                </div>
                <div class="modules-add">
                    <table>
                        <tr>
                            <td class="project-name">
                                <span>*Module Name : </span>
                            </td>
                            <td class="enter-project-name">
                                <dx:ASPxComboBox ID="cmbModule" runat="server" CssClass="project-owner">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True"
                                        ValidationGroup="component">
                                    </ValidationSettings>
                                    <ClientSideEvents Validation="function(s, e) {e.isValid = s.GetValue() != '0'; if(e.isValid != true) { e.errorText = 'Required';}}" />
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="project-name">
                                <span>Component : </span>
                            </td>
                            <td class="enter-project-name">
                                <dx:ASPxTextBox ID="txtComponentName" runat="server" CssClass="input-txt" MaxLength="200">
                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="component">
                                        <RequiredField IsRequired="True" ErrorText="Required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="project-name">
                            </td>
                            <td class="enter-project-name">
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnComponentAdd" runat="server" Text="Add/Update Component" ValidationGroup="component"
                                                OnClick="btnComponentAdd_Click">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnComponentDelete" runat="server" Text="Delete Component" CausesValidation="false"
                                                OnClick="btnDeleteComponent_Click" Visible="false">
                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure want to delete this component?'); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="project-name">
                            </td>
                            <td class="enter-project-name">
                                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" ValidationGroup="Project"
                                    OnClick="btnSave_Click">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--      END OF COMPONENT MECHANISUM--%>
            </div>
        </div>
    </div>
</asp:Content>
