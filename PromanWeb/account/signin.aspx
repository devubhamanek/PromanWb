<%@ Page Title="SignIn | Project Task Manager" Language="C#" MasterPageFile="~/masterpages/default.Master"
    AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="PromanWeb.account.signin" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="signin">
        <div class="heading">
            <h2>
                Administrator Login</h2>
        </div>
        <div class="banner">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_1.jpg' alt="Banner1" />
                    </td>
                    <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_2.jpg' alt="Banner2" />
                    </td>
                    <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_3.jpg' alt="Banner3" />
                    </td>
                    <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_4.jpg' alt="Banner4" />
                    </td>
                    <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_5.jpg' alt="Banner5" />
                    </td>
                     <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_3.jpg' alt="Banner3" />
                    </td>
                     <td class="banner-img">
                        <img src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/banner_1.jpg' alt="Banner3" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div-message">
            <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
        </div>
        <div class="login-box">
            <div class="topbigheight">
            </div>
            <div class="field">
                <table>
                    <tr>
                        <td class="username">
                            User Name :
                        </td>
                        <td class="username-txtbox">
                            <dx:ASPxTextBox runat="server" EnableClientSideAPI="True" Width="120px" ID="txtUserName"
                                ClientInstanceName="txtUsername" CssClass="fontfamily">
                                <ValidationSettings SetFocusOnError="True" Display="Static">
                                    <RegularExpression ErrorText="Invalid user name" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="username">
                            Password :
                        </td>
                        <td class="username-txtbox">
                            <dx:ASPxTextBox runat="server" EnableClientSideAPI="True" Width="120px" ID="txtPassword"
                                ClientInstanceName="txtPassword" Password="true" CssClass="fontfamily">
                                <ValidationSettings SetFocusOnError="True" Display="Static">
                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsubmit">
                            <dx:ASPxButton ID="btnsubmit" runat="server" OnClick="btnSubmit_Click">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
