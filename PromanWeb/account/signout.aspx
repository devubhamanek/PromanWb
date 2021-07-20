<%@ Page Title="SignOut | Project Task Manager" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true" CodeBehind="signout.aspx.cs" Inherits="PromanWeb.account.signout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
 <div class="sign-out">
        <div class="heading">
            <h2>LogOut</h2>
        </div>
     
        <div class="msg">
            <p>
                You have been successfully logged out from the system
            </p>
            <p>
                To login again please click on this link:&nbsp;<a href="signin.aspx">Login</a>
            </p>
        </div>
    </div>
</asp:Content>
