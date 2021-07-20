<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true" CodeBehind="activity.aspx.cs" Inherits="PromanWeb.admin.rolemanagement.activity" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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
               Activity Management
            </h2>
        </div>
        <div class="div-message">
            <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
        </div>
        <div class="sub-heading1">
            <h2>
                Activity Management</h2>
        </div>
        <div class="users">
            <dx:ASPxGridView ID="gvActivity" ClientInstanceName="grid" runat="server" KeyFieldName="ActivityID"
                Width="772px" AutoGenerateColumns="False" OnRowCommand="gvActivity_RowCommand">
                <Columns>
                    <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="50">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandName="edit" CausesValidation="false"
                                CommandArgument='<%# Eval("ActivityID") %>'>
                                <img id="Img1" runat="server" src="~/images/img_Search.png" alt="View" style="border: 0px;"
                                    title="View" /></asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
              
                    <dx:GridViewDataTextColumn Caption="Activity Name" Width="150px" FieldName="ActivityName" VisibleIndex="1"
                     />
         
                    <dx:GridViewDataColumn Caption="ActivityLink" FieldName="ActivityLink" VisibleIndex="2" Width="150px" />
                <dx:GridViewDataColumn Caption="Delete" VisibleIndex="10"
                                                        Width="25">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton ID="lbnkPromoCodeId" Width="40" OnClientClick="javascript:return confirm('Do You Want to Remove this Activity?');"
                                                                runat="server" Font-Underline="true" ForeColor="Blue" Text="Delete" CommandArgument='<%#Eval("ActivityID")%>' CommandName="delete">
                                                                </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                </Columns>
               
                <SettingsPager PageSize="10" Position="Bottom" SEOFriendly="Disabled">
                    <FirstPageButton Visible="True">
                    </FirstPageButton>
                    <LastPageButton Visible="True">
                    </LastPageButton>
                    <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Activities)" />
                </SettingsPager>
                <Settings ShowFilterRow="True"  />
            </dx:ASPxGridView>
        </div>
        <div class="sub-heading1">
            <h2>
               Activity Management </h2>
        </div>
        <div class="user-edit">
            <table width="100%">
                <tr>
                    <td width="50%" valign="top">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <span>*Indicates a mandatory response</span>
                                </td>
                                <td class="blueline">
                                </td>
                            </tr>
                            <tr>
                                <td class="firstname">
                                    <span> *Activity Name: </span>
                                </td>
                                <td class="txtfirstname">
                                    <dx:ASPxTextBox ID="txtActivityName" runat="server" CssClass="txtbox" MaxLength="50">
                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                          
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="blueline">
                                </td>
                            </tr>
                            <tr>
                                <td class="firstname">
                                    <span> *Activity Link: </span>
                                </td>
                                <td class="txtfirstname">
                                    <dx:ASPxTextBox ID="txtActivityLink" runat="server" CssClass="txtbox" MaxLength="50">
                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                          
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="blueline">
                                </td>
                            </tr>
                            <tr>
                                <td class="firstname">
                                    <span>Status: </span>
                                </td>
                                <td class="txtfirstname">
                                        <asp:CheckBox ID="chkStatus" Checked="true" runat="server"></asp:CheckBox>
                                        IsActive
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
                                                <dx:ASPxButton ID="btnDelete" runat="server" Text="Delete" CausesValidation="false"
                                                    Enabled="false" OnClick="btnDelete_Click">
                                                    <ClientSideEvents Click="function(s, e){ 
                                                            e.processOnServer = confirm('Are you sure want to remove this User?');
                                                          }" />
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
              
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
