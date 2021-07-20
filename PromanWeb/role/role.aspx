<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true"
    CodeBehind="role.aspx.cs" Inherits="PromanWeb.admin.rolemanagement.role1" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="user-management">
        <div class="heading">
            <h2>
                Role Management
            </h2>
        </div>
        <div class="div-message">
            <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
        </div>
        <div class="sub-heading">
            <h2>
                Role Management</h2>
        </div>
        <div class="users">
            <dx:ASPxGridView ID="gvRole" ClientInstanceName="grid" runat="server" KeyFieldName="RoleId"
                Width="772px" AutoGenerateColumns="False" OnRowCommand="gvRole_RowCommand">
                <Columns>
                    <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="25">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandName="edit" CausesValidation="false"
                                CommandArgument='<%# Eval("RoleId") %>'>
                                <img id="Img1" runat="server" src="~/images/img_Search.png" alt="View" style="border: 0px;"
                                    title="View" /></asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Role Name" Width="400" FieldName="RoleName" VisibleIndex="1" />
                </Columns>
                <SettingsPager PageSize="10" Position="Bottom" SEOFriendly="Disabled">
                    <FirstPageButton Visible="True">
                    </FirstPageButton>
                    <LastPageButton Visible="True">
                    </LastPageButton>
                    <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Roles)" />
                </SettingsPager>
            </dx:ASPxGridView>
        </div>
        <div class="sub-heading">
            <h2>
                Role Management
            </h2>
        </div>
        <div class="user-edit">
            <table width="100%">
                <tr>
                    <td width="50%" valign="top">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="firstname">
                                    <span>Role Name: </span>
                                </td>
                                <td class="txtfirstname">
                                    <dx:ASPxTextBox ReadOnly="true" ID="txtRoleName" runat="server" CssClass="txtbox"
                                        MaxLength="50">
                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="blueline">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table cellpadding="2" cellspacing="3" class="btn">
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" CausesValidation="true" OnClick="btnSave_Click"
                                                    ToolTip="Save">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                                    ToolTip="Cancel" OnClick="btnCancel_Click">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="50%" style="padding-left: 11px;">
                        <dx:ASPxGridView ID="gvActivity" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
                            KeyFieldName="ActivityID" Visible="false" Width="98%">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Activity" FieldName="ActivityName" ShowInCustomizationForm="True"
                                    VisibleIndex="1" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Link" FieldName="ActivityLink" ShowInCustomizationForm="True"
                                    VisibleIndex="2" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Caption="View" FieldName="View" VisibleIndex="3" Width="50px">
                                    <DataItemTemplate>
                                        <asp:CheckBox ID="chkView" runat="server" Checked='<%#Convert.ToBoolean(Eval("View"))%>' />
                                        <asp:Label runat="server" Text='<%#Eval("ActivityID")%>' ID="lblActivityID" Visible="false"></asp:Label>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <%--      <dx:GridViewDataColumn Caption="Edit" FieldName="Edit" VisibleIndex="4" Width="50px">
                                                <DataItemTemplate>
                                                    <asp:LinkButton runat="server" ID="btnEdit" CommandName="Edit">
                                                        <asp:CheckBox ID="chkEdit" Checked='<%# Convert.ToBoolean(Eval("Edit"))%>' runat="server" />
                                                    </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Delete" FieldName="Delete" VisibleIndex="5" Width="50px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" Checked='<%# Convert.ToBoolean(Eval("Delete"))%>' runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>--%>
                            </Columns>
                            <SettingsPager PageSize="100" AlwaysShowPager="True">
                                <Summary AllPagesText="Page {0} of {1} ( {2} Activities )" Text="Page {0} of {1} ( {2} Activities )" />
                            </SettingsPager>
                        </dx:ASPxGridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
