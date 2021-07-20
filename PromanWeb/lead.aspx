<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true"
    CodeBehind="lead.aspx.cs" Inherits="PromanWeb.lead" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 10px;
        }
        .style2
        {
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
 <script type="text/javascript"  src="../scripts/jquery.js"></script>
    <script type="text/javascript">
        $(Document).ready(function () {
            $('.leadDetails').hide();
            $('#panelHideShow').click(function () {

                if (document.getElementById('imimage').title == "upimage") {
                    document.getElementById('imimage').setAttribute("title", "downimage");
                    document.getElementById('imimage').setAttribute("src", "images/arrow-down.jpg")
                }
                else {
                    document.getElementById('imimage').setAttribute("title", "upimage");
                    document.getElementById('imimage').setAttribute("src", "images/arrow-up.jpg")
                }

                $('.leadDetails').toggle(500);
            });
        });
        $(Document).ready(function () {
            $('.secondaryEmail').hide();
            $('#imageEmail').click(function () {

                if (document.getElementById('imageEmail').title == "upimage") {
                    document.getElementById('imageEmail').setAttribute("title", "downimage");
                    document.getElementById('imageEmail').setAttribute("src", "images/arrow-down.jpg")
                }
                else {
                    document.getElementById('imageEmail').setAttribute("title", "upimage");
                    document.getElementById('imageEmail').setAttribute("src", "images/arrow-up.jpg")
                }

                $('.secondaryEmail').toggle(500);
            });
        });
        function OnCountryChanged(cmbCountry) {
            cmbState.PerformCallback(cmbCountry.GetValue().toString());
        }
    </script>
    <div class="lead">
        <div class="heading">
            <h2>
                Lead
            </h2>
        </div>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <div class="search">
            <table>
                <tr>
                    <td>
                        Country:
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="ddlSearchCountry" runat="server" Width="150px">
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click">
                        </dx:ASPxButton>
                    </td>
                    <td>
                    </td>
                    <td class="addnewrecord">
                        <dx:ASPxButton ID="addNewRecord" CssClass="addnewrecord" runat="server" Text="Add New Record"
                            OnClick="addNewRecord_Click" Width="150px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="maindiv">
            <div class="subdiv">
                <div class="task-list-grid">
                    <dx:ASPxGridView ID="gvLeadList" ClientInstanceName="gvClosedTaskList" runat="server"
                        KeyFieldName="TaskId" AutoGenerateColumns="False" Width="777px">
                        <Columns>
                            <dx:GridViewDataColumn Caption="View" VisibleIndex="0" Width="25px">
                                <DataItemTemplate>
                                    <a href='lead.aspx?leadid=<%# Eval("LeadId") %>'>
                                        <img id="imgView" runat="server" src="~/images/view.png" alt="View" style="border: 0px;"
                                            title="View" /></a>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="CompanyName" FieldName="CompanyName" Width="65px"
                                VisibleIndex="1" />
                            <dx:GridViewDataColumn Caption="Email" FieldName="Email" Width="65px" VisibleIndex="2" />
                            <dx:GridViewDataColumn Caption="ContactPerson" Width="105px" FieldName="ContactPerson"
                                VisibleIndex="3">
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="PhoneNo" FieldName="PhoneNo1" Width="45px" VisibleIndex="5" />
                            <dx:GridViewDataColumn Caption="IsCompany" FieldName="IsCompany" Width="45px" VisibleIndex="7" />
                        </Columns>
                        <Settings ShowFilterRow="True"  />
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
        <dx:ASPxPopupControl CssClass="pcaddrecord" ID="pcAddNewRecord" runat="server" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="Above" Width="600px"
            HeaderText="Lead" CloseAction="CloseButton" PopupVerticalOffset="25" 
            ShowPageScrollbarWhenModal="True">
            <ContentCollection>
                <dx:PopupControlContentControl>
                    <center>
                        <asp:Label ID="lblemailwebsitecheck" runat="server" Text="">
                        </asp:Label>
                        <table>
                            <tr>
                                <td class="pclefttd">
                                    Lead ID:
                                </td>
                                <td colspan="3">
                                    <dx:ASPxLabel ID="lblMaxLeadId" runat="server" Font-Bold="True" ForeColor="#6600FF">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    Comany Name:
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="365px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    Email:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="225px">
                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                            <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            <RegularExpression ValidationExpression="\w+([-+.&#39;]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                            </RegularExpression>
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <img alt="" class="imImage"  title="downimage" id="imageEmail" 
                                        src="images/arrow-down.jpg" height="20" width="20" />
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnChkEmail" runat="server" Text="Check" Width="35px" OnClick="btnChkEmail_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                            <tr class="secondaryEmail"><td class="align-right">Email2:</td><td>    <dx:ASPxTextBox ID="txtEmail2" runat="server" Width="225px">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    </ValidationSettings>
                                    </dx:ASPxTextBox></td></tr>
                            <tr class="secondaryEmail"><td class="align-right">Email3:</td><td>    <dx:ASPxTextBox ID="txtEmail3" runat="server" Width="225px">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    </ValidationSettings>
                                    </dx:ASPxTextBox></td></tr>
                            <tr>
                                <td class="pclefttd">
                                    WebSite:
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="txtWebsite" runat="server" Width="225px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnChkWebsite" runat="server" Text="Check" Width="35px" OnClick="btnChkWebsite_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                IM Details:
                                </td>
                                <td colspan="3" id="panelHideShow" >    <img alt="" class="imImage"  title="downimage" id="imimage" src="images/arrow-down.jpg" height="20 width="20" /></td>
                            </tr>
                         
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        GTalk:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtGtalk" runat="server" Width="225px">
                                            <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        Yahoo:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtYahoo" runat="server" Width="225px">
                                            <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        Skype:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtSkype" runat="server" Width="225px">
                                            <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        Aim:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtAim" runat="server" Width="225px">
                                            <ValidationSettings EnableCustomValidation="True" 
                                                ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        Icq:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtIcq" runat="server" Width="225px">
                                            <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr class="leadDetails">
                                    <td class="pclefttd">
                                        Msn:
                                    </td>
                                    <td colspan="3">
                                        <dx:ASPxTextBox ID="txtMsn" runat="server" Width="225px">
                                            <ValidationSettings EnableCustomValidation="True" 
                                                ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            
                            <tr>
                                <td class="pclefttd">
                                    ContactPerson
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtContactPerson" runat="server" Width="365px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    Designation:
                                </td>
                                <td colspan="3">
                                    <dx:ASPxComboBox ID="ddlDesignation" runat="server" Width="365px">
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    PhoneNo1:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtPhone1" runat="server" Width="200px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="style1">
                                    Ext:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtPhone1Ext" runat="server" Width="72px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    PhoneNo2:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtPhone2" runat="server" Width="200px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="align-right" style="width: 3px">
                                    Ext:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtPhone2Ext" runat="server" Width="72px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    Mobile Number1:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMobile1" runat="server" Width="200px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile Number2:
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="txtMobile2" runat="server" Width="200px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="address">
                                    Address 1:
                                </td>
                                <td colspan="3">
                                    <dx:ASPxMemo ID="txtAddress1" runat="server" Height="50px" Width="365px">
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                            <tr>
                                <td class="address">
                                    Address 2:</td>
                                <td colspan="3">
                                    <dx:ASPxMemo ID="txtAddress2" runat="server" Height="50px" Width="365px">
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table width="465" class="tableleftmargin">
                            <tr>
                                <td class="pclefttd">
                                    City:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtCity" runat="server" Width="150px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="pclefttd">
                                    Zip Code:
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtZipCode" runat="server" Width="90px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="pclefttd">
                                    Country:
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="ddlCountry" IncrementalFilteringMode="StartsWith" runat="server"
                                        ValueType="System.String" Width="150px" DropDownStyle="DropDown">
                                        <ValidationSettings EnableCustomValidation="True" ErrorText="*">
                                            <RequiredField ErrorText="" IsRequired="True" />
                                        </ValidationSettings>
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }" />
                                    </dx:ASPxComboBox>
                                </td>
                                <td class="align-right" style="width: 5px">
                                    State:
                                </td>
                                <td>
                                    <dx:ASPxComboBox IncrementalFilteringMode="StartsWith" ID="ddlState" OnCallback="CmbState_Callback"
                                        ClientInstanceName="cmbState" runat="server" ValueType="System.String" Width="90px"
                                        DropDownStyle="DropDown">
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="address">
                                    Do Not Call:
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="chkDoNotCall" runat="server">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td class="style2">
                                    IsCompany:
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="chkIsCompany" runat="server">
                                    </dx:ASPxCheckBox>
                                </td>
                            </tr>
                              <tr>
                                <td class="address">
                                    &nbsp; IsClient:
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="chkIsClient" runat="server">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td class="address">
                                    IsProspect:
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="chkIsProspect" runat="server">
                                    </dx:ASPxCheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <br />
                                        <dx:ASPxButton ID="submit" runat="server" Text="Save" OnClick="submit_Click">
                                        </dx:ASPxButton>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <div class="searchandadd">
        </div>
    </div>
</asp:Content>
