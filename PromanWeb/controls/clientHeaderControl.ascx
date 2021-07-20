<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="clientHeaderControl.aspx.cs"
    Inherits="PromanWeb.controls.clientHeaderControl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<table width="700px" class="clientHeader" cellpadding="0" cellspacing="0">
    <tr>
        <td class="tdalign-top" width="145px">
            <dx:ASPxLabel ID="lblWelcomeName" CssClass="fontbold" runat="server" Text="Welcome Back, ">
            </dx:ASPxLabel>
        </td>
        <td width="175px">
            <asp:ImageButton ID="btnNewTask" ImageUrl="~/images/newTask.png" OnClick="btnNewTask_Click" Width="160px" runat="server" />
        </td>
        <td style="text-align:left;" width="350px">
        <asp:ImageButton ID="btnClosedTask" ImageUrl="~/images/closeTask.png" OnClick="btnCloseTask_Click" Width="160px" runat="server" />
        </td>
    </tr>
</table>
