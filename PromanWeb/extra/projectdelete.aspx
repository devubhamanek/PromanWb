<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true"
    CodeBehind="projectdelete.aspx.cs" Inherits="PromanWeb.extra.projectdelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    Project ID :
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
        onclick="btnDelete_Click" />
</asp:Content>
