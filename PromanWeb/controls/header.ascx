
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="PromanWeb.controls.header" %>
<div class="logo">
    <img style="margin-top:5px; margin-left:5px;" height="70px"src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/logo.png' alt="Logo" title="Project Task Manager" /></div>
<div class="website-title" style="margin-left:150px;">
    <h2>
      WorkVue</h2>
</div>