<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/default.Master" AutoEventWireup="true"
    CodeBehind="project-queue-closed.aspx.cs" Inherits="PromanWeb.project_queue_closed" %>

<%@ Register Assembly="DevExpress.Xpo.v10.2.Web, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .delete
        {
            cursor: pointer;
        }
        .c
        {
            background: white;
            border: solid 1px gray;
            width: 180px;
            height: 50px;
            text-align: center;
            vertical-align: middle;
            padding-top: 3px;
            padding-left: 5px;
            display: none;
            line-height: 16px;
        }
        #date
        {
            margin-right: 6px;
            margin-top: 2px;
            padding: 2px;
        }
        .white
        {
            background: white;
        }
        .red
        {
            background: red;
        }
        .yellow
        {
            background: yellow;
        }
        .green
        {
            background: green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <script type="text/javascript" src="scripts/jquery.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#popup').hide();
            //Remove Task
            $('.delete').click(function () {

                var taskID = 0;
                //Set TaskID
                $(this).parent().parent().find('td').each(function () {
                    //Set Taskid variable which is supplied to the service
                    if ($(this).find('a').text() != "")
                    { taskID = $(this).find('a').text(); tasktitle = $(this).find('a').parent().next().html(); }
                });
                var v = confirm('Are you sure you want to delete task no. #' + taskID + '?');
                if (!v)
                { return; }
                $.ajax({
                    type: "POST",
                    url: "ServiceUpdateTaskStatus.asmx/DeleteTask",
                    data: '{"taskID":"' + taskID + '"}',

                    contentType: "application/json; charset=utf-8",

                    dataType: "json",
                    success: $(this).parent().parent().remove()
                });


            });
        });

        var IE = document.all ? true : false;
        if (!IE) document.captureEvents(Event.MOUSEMOVE)
        document.onmousemove = getMouseXY;
        var pos_x = 0;
        var pos_y = 0;
        function getMouseXY(e) {
            if (IE) { // grab the x-y pos.s if browser is IE
                pos_x = event.clientX + document.documentElement.scrollLeft;
                pos_y = event.clientY + document.documentElement.scrollTop;
            }
            else {  // grab the x-y pos.s if browser is NS
                pos_x = e.pageX;
                pos_y = e.pageY;
            }
            if (pos_x < 0) { tempX = 0; }
            if (pos_y < 0) { tempY = 0; }


        }

        function DisableUnWantedPopUp(src) {

        }
        function OnMoreInfoClick(event, link, date, color, imageUrl, updatedby) {
            var ar = new Array(10);

            var str = imageUrl;

            var patt1 = /notaskimage.jpg/;

            ar = (str.match(patt1));
            if (ar != null)
            { return; }
            if (color == "white") {
                document.getElementById("date").style.backgroundColor = "white";
            }
            if (color == "red") {
                document.getElementById("date").style.backgroundColor = "#EE1B22";
            }
            if (color == "green") {
                document.getElementById("date").style.backgroundColor = "#03FD00";

            }
            if (color == "yellow") {
                document.getElementById("date").style.backgroundColor = "#FEF600";
            }
            //  alert("ecent=" + event + ":Link=" + link + ":Date=" + date + ":Color=" + color);
            document.getElementById("date").innerHTML = date + '<br><span style="padding-top:5px;">Updated By: ' + updatedby + '</span>';
            $('#popup').addClass('c');

            //            // $('#pp').add('Style','background:'+color+';position:absolute;left:'+(pos_x+25)+"px;top:"+(pos_y+22)+"px;");
            //            pos_x = event.offsetX ? (event.offsetX) : event.pageX - link.offsetLeft;
            //            pos_y = event.offsetY ? (event.offsetY) : event.pageY - link.offsetTop;


            document.getElementById("popup").setAttribute("Style", "position:absolute;left:" + (pos_x + 25) + "px; top:" + (pos_y + 22) + "px;");

            $('#popup').show(300);
            //popup.Show();

        }
    </script>
    <div class="project-queue">
        <div class="heading">
            <h2>
                Closed Projects
            </h2>
        </div>
        <div class="div-message default-padding-left">
            <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
            <%--    <dx:XpoDataSource ID="XpoDataSource1" ServerMode="false" runat="server" 
                TypeName="PromanWeb.Customer">
            </dx:XpoDataSource>--%>
        </div>
        <div class="Projects-list">
            <dx:aspxgridview id="gvProjects" clientinstancename="grid" runat="server" keyfieldname="ProjectId"
                width="910px" autogeneratecolumns="False" onrowcommand="gvProjects_RowCommand">
                <Columns>
                    <dx:GridViewDataColumn Caption="View" Width="50">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" CausesValidation="false"
                                CommandArgument='<%# Eval("ProjectId") %>'>
                                <img id="Img1" runat="server" src="~/images/t100.png" width="17" height="15" alt="View"
                                    style="border: 0px;" title="View" /></asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Project Name" FieldName="ProjectName" Width="300">
                        <DataItemTemplate>
                            <a class="projectlink" style="color: Blue; text-decoration: underline;" href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>&projectStatus=closed'>
                                <%# Eval("ProjectName") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataColumn Caption="Open Tasks" FieldName="OpenTask" Width="20">
                        <DataItemTemplate>
                            <%#Eval("OpenTask")%>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Modules" FieldName="Modules" Width="60" />
                    <%--                    <dx:GridViewDataColumn Caption="Status" FieldName="ProjectStatus" Width="50">
                        <DataItemTemplate>
                            <%# Enum.Parse(typeof(PromanWeb.ProjectStatus), Convert.ToString(Eval("ProjectStatus")))%>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>--%>
                    <dx:GridViewDataColumn Caption="Project Completion Rate" FieldName="ProjectCompletionStatus"
                        Width="200">
                        <DataItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td width="70%" style="text-align: left;">
                                        <%# GetProjectCompletionStatus(Convert.ToDouble(Eval("ProjectCompletionStatus")))%>
                                    </td>
                                    <td width="30%" style="color: Blue; font-weight: bold;">
                                        <%#Eval("ProjectCompletionStatus")+"%"%>
                                    </td>
                                </tr>
                            </table>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Edit" Width="50">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lnkEdit" ForeColor="Blue" Font-Underline="true" runat="server"
                                CommandName="EditProject" CausesValidation="false" CommandArgument='<%# Eval("ProjectId") %>'>
                             Edit</asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Delete" Width="50">
                        <DataItemTemplate>
                      <asp:LinkButton  ForeColor='<%#PromanWeb.Helper.DisableLinkColor(Convert.ToInt64(Eval("TaskCount")))%>' Enabled='<%#PromanWeb.Helper.IsEnableDeleteLink(Convert.ToInt64(Eval("TaskCount")))%>' ID="lnkEdit"  Font-Underline="true" runat="server"
                                CommandName="DeleteProject" OnClientClick='<%#PromanWeb.Helper.DisableLinkConfirmation(Convert.ToInt64(Eval("TaskCount")))%>'
                                CausesValidation="false" CommandArgument='<%# Eval("ProjectId") %>'>
                             Delete</asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>
                <Settings ShowFilterRow="True" />
            </dx:aspxgridview>
        </div>
        <div class="project-view" runat="server" id="divProjectView" visible="false">
            <div class="sub-heading">
                <div class="project-name">
                    <h2>
                        <span id="spanProjectName" runat="server"></span>
                    </h2>
                </div>
                <div class="day-to-project-due">
                    <h2>
                        <span id="spanDayToProjectDue" runat="server"></span>
                    </h2>
                </div>
            </div>
            <br />
            <table class="project-overallcompletion">
                <tr>
                    <td>
                        Overall Project completion Rate :
                    </td>
                    <td>
                        <dx:aspxprogressbar id="pbOverall" runat="server" height="21px" width="290px">
                        </dx:aspxprogressbar>
                    </td>
                </tr>
            </table>
            <div style="width: 500px; padding-left: 15px">
                <hr class="hr" id="Hr1" runat="server" />
                <table class="project-legend" id="legend" runat="server">
                    <tr>
                        <td>
                            <b>Legend</b>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: Black;" class="lead-align-right">
                            01-
                        </td>
                        <td style="color: Black;">
                            Open
                        </td>
                        <td style="color: red;" class="lead-marginleft">
                            05-
                        </td>
                        <td style="color: red;">
                            Bug Found
                        </td>
                    </tr>
                    <tr>
                        <td style="color: DarkGoldenRod;" class="lead-align-right">
                            02-
                        </td>
                        <td style="color: DarkGoldenRod;">
                            Discussion
                        </td>
                        <td style="color: brown;" class="lead-marginleft">
                            06-
                        </td>
                        <td style="color: brown;">
                            Bug Fixed
                        </td>
                    </tr>
                    <tr>
                        <td style="color: blue;" class="lead-align-right">
                            03-
                        </td>
                        <td style="color: blue;">
                            In Programming
                        </td>
                        <td style="color: green;" class="lead-marginleft">
                            07-
                        </td>
                        <td style="color: green;">
                            Closed
                        </td>
                    </tr>
                    <tr>
                        <td style="color: purple;" class="lead-align-right">
                            04-
                        </td>
                        <td style="color: purple;">
                            Ready For Test
                        </td>
                        <td class="lead-marginleft">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <hr class="hr" id="hr2" runat="server" />
                <br />
            </div>
            <table runat="server" id="colordot" class="colordot">
                <tr>
                    <td>
                        <dx:aspximage id="ASPxImage1" runat="server" imageurl="~/images/bullet_green.png">
                        </dx:aspximage>
                    </td>
                    <td>
                        Last activity 1-48 hours ago
                    </td>
                    <td>
                        <dx:aspximage id="ASPxImage2" runat="server" imageurl="~/images/bullet_yellow.png">
                        </dx:aspximage>
                    </td>
                    <td>
                        Last activity 49-72 hours ago
                    </td>
                    <td>
                        <dx:aspximage id="ASPxImage3" runat="server" imageurl="~/images/bullet_red.png">
                        </dx:aspximage>
                    </td>
                    <td>
                        Last activity 73-96 hours ago
                    </td>
                    <td>
                        <dx:aspximage id="ASPxImage4" runat="server" imageurl="~/images/bullet_black.png">
                        </dx:aspximage>
                    </td>
                    <td>
                        Last activity 96 or more hours ago
                    </td>
                </tr>
            </table>
            <div class="module-detail">
                <div class="grid-module-status">
                    <dx:aspxgridview visible="false" id="gvModuleStatus" clientinstancename="gvModuleStatus"
                        runat="server" keyfieldname="ModuleId" width="100%" onpageindexchanged="gvModuleStatus_PageIndexChanged"
                        autogeneratecolumns="False" clientidmode="AutoID">
                        <Border BorderStyle="None" />
                        <Columns>
                            <dx:GridViewDataColumn Caption="View" Width="58.33%" CellStyle-HorizontalAlign="Right">
                                <DataItemTemplate>
                                    <%# "Module" + (Convert.ToInt64(Container.ItemIndex)+1) + ": " + Eval("ModuleName") + " : "%>
                                    <%--<%# Convert.ToString(Eval("ModuleName")) == "Overall Project completion Rate" ? Eval("ModuleName") + ": " : "Module " + Container.ItemIndex + ": " + Eval("ModuleName") + " : "%>--%>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataProgressBarColumn FieldName="ModuleCompletionStatus" />
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <dx:ASPxGridView SettingsDetail-ShowDetailRow="true" CssClass="componentGrid" ID="componentGrid"
                                    Width="100%" runat="server" KeyFieldName="ComponentId" OnDataBinding="component_DataBinding"
                                    OnBeforePerformDataSelect="detailGrid_DataSelect">
                                    <Columns>
                                        <dx:GridViewDataColumn Width="60%" CellStyle-HorizontalAlign="Right" FieldName="ComponentName"
                                            VisibleIndex="1">
                                            <DataItemTemplate>
                                                <%# "Component " + (Convert.ToInt64(Container.ItemIndex)+1) + ": " + Eval("ComponentName") + " : "%>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataProgressBarColumn Width="40%" FieldName="ComponentCompletionStatus"
                                            VisibleIndex="2">
                                        </dx:GridViewDataProgressBarColumn>
                                    </Columns>
                                    <Templates>
                                        <DetailRow>
                                            <dx:ASPxGridView ID="taskGrid" Width="100%" runat="server" KeyFieldName="TaskId"
                                                OnDataBinding="task_DataBinding" OnRowCommand="gvTasks_RowCommand">
                                                <Columns>
                                                    <dx:GridViewDataColumn Width="20px" CellStyle-ForeColor="Blue" FieldName="TaskId"
                                                        Caption="TaskId" VisibleIndex="1">
                                                        <DataItemTemplate>
                                                            <%--  <a runat="server" style="  text-decoration:underline;color:Blue;" href='<%#Eval("Link")%>' runat="server" id="link">
                                                                <%#Eval("TaskId")%>
                                                            </a>--%>
                                                            <asp:LinkButton ID="LinkButton1" ForeColor="Blue" Font-Underline="true" Enabled='<%#ValidateLink()%>'
                                                                runat="server" PostBackUrl='<%#Eval("Link")%>'><%#Eval("TaskId")%></asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="150px" FieldName="Title" Caption="TaskTitle" VisibleIndex="2">
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" Caption="01" FieldName="TaskId" VisibleIndex="3">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("01")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="02" Caption="02" VisibleIndex="4">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("02")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="03" Caption="03" VisibleIndex="5">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("03")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="04" Caption="04" VisibleIndex="6">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("04")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="05" Caption="05" VisibleIndex="7">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("05")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="06" Caption="06" VisibleIndex="8">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("06")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="07" Caption="07" VisibleIndex="9">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("07")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="08" Caption="08" VisibleIndex="10">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("08")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="09" Caption="09" VisibleIndex="11">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("09")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="13px" FieldName="10" Caption="10" VisibleIndex="12">
                                                        <DataItemTemplate>
                                                            <img id="Img1" runat="server" src='<%#Eval("10")%>' onmouseover='<%#Eval("LastAcssesDate")%>'
                                                                style="border: 0px;" title="View" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsPager Mode="ShowAllRecords">
                                                    <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Tasks)" />
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </DetailRow>
                                    </Templates>
                                    <SettingsPager Mode="ShowAllRecords">
                                    </SettingsPager>
                                    <Settings GridLines="None" ShowColumnHeaders="false" />
                                    <SettingsDetail ShowDetailRow="true" />
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>
                        <SettingsPager PageSize="1">
                            <Summary AllPagesText="Pages: {0} - {1} ({2} P)" Text="Page {0} of {1} ({2} Modules)" />
                        </SettingsPager>
                        <SettingsDetail ShowDetailRow="true" />
                        <Settings GridLines="None" ShowColumnHeaders="false" />
                    </dx:aspxgridview>
                    <%--    <hr class="hr" id="Hr1" runat="server" />--%>
                    <%--              <table class="project-legend" id="legend" runat="server">
                        <tr>
                            <td>
                                <b>Legend</b>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="lead-align-right">
                                01-
                            </td>
                            <td>
                                Brain Storming
                            </td>
                            <td class="lead-marginleft">
                                06-
                            </td>
                            <td>
                                Testing
                            </td>
                        </tr>
                        <tr>
                            <td class="lead-align-right">
                                02-
                            </td>
                            <td>
                                Discussion
                            </td>
                            <td class="lead-marginleft">
                                07-
                            </td>
                            <td>
                                Bug Found
                            </td>
                        </tr>
                        <tr>
                            <td class="lead-align-right">
                                03-
                            </td>
                            <td>
                                Debate
                            </td>
                            <td class="lead-marginleft">
                                08-
                            </td>
                            <td>
                                Bug Fixes
                            </td>
                        </tr>
                        <tr>
                            <td class="lead-align-right">
                                04-
                            </td>
                            <td>
                                Scoping
                            </td>
                            <td class="lead-marginleft">
                                09-
                            </td>
                            <td>
                                Awaiting Client Approval
                            </td>
                        </tr>
                        <tr>
                            <td class="lead-align-right">
                                05-
                            </td>
                            <td>
                                Programming
                            </td>
                            <td class="lead-marginleft">
                                10-
                            </td>
                            <td>
                                Closed
                            </td>
                        </tr>
                    </table>--%>
                    <%--   <hr class="hr" id="hr2" runat="server" />--%>
                    <br />
                    <%--     <table runat="server" id="colordot" class="colordot">
                        <tr>
                            <td>
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="~/images/bullet_green.png">
                                </dx:ASPxImage>
                            </td>
                            <td>
                                Last activity 1-48 hours ago
                            </td>
                            <td>
                                <dx:ASPxImage ID="ASPxImage2" runat="server" ImageUrl="~/images/bullet_yellow.png">
                                </dx:ASPxImage>
                            </td>
                            <td>
                                Last activity 49-72 hours ago
                            </td>
                            <td>
                                <dx:ASPxImage ID="ASPxImage3" runat="server" ImageUrl="~/images/bullet_red.png">
                                </dx:ASPxImage>
                            </td>
                            <td>
                                Last activity 73-96 hours ago
                            </td>
                            <td>
                                <dx:ASPxImage ID="ASPxImage4" runat="server" ImageUrl="~/images/bullet_black.png">
                                </dx:ASPxImage>
                            </td>
                            <td>
                                Last activity 96 or more hours ago
                            </td>
                        </tr>
                    </table>--%>
                </div>
                <div id="taskView" class="taskview" runat="server">
                </div>
                <div id="popup" style="height: 40px;">
                    <div id="date" style="height: 35px; padding-top: 5px;">
                        &nbsp;</div>
                </div>
                <div class="buttons">
                    <table cellpadding="2" cellspacing="3">
                        <tr>
                            <td>
                                <dx:aspxbutton id="btnViewTasks" runat="server" text="View Tasks" onclick="btnViewTasks_Click">
                                </dx:aspxbutton>
                            </td>
                            <td>
                                <dx:aspxbutton id="btnEditProject" runat="server" text="Edit Project" onclick="btnProjectEdit_Click">
                                </dx:aspxbutton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
