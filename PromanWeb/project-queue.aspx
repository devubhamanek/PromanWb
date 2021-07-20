<%@ Page Title="Project Queue | Project Task Manager" Language="C#" MasterPageFile="~/masterpages/default.Master"
    AutoEventWireup="true" CodeBehind="project-queue.aspx.cs" Inherits="PromanWeb.project_queue" %>

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
 
    <script type="text/javascript">


        function ReLoadGridStyles(s, e) {
            //            alert($("#ctl00_cphAdmin_gvProjects_DX-GSDT-col2 table td:nth-child(1)"));
            $("#cphAdmin_gvProjects_DX-GSDT-col2 table td:nth-child(1)").next().remove();

        }
    </script>
    <style type="text/css">
        .taskimage
        {
            padding: 10px;
        }
        .taskimagesajax
        {
            height: 90px;
            width: 90px;
            margin-right: 10px;
            margin-bottom: 10px;
        }
        .divcontent
        {
            width: 640px;
            height: 550px;
            overflow-y: scroll;
        }
        .comment
        {
            margin-left: 17px;
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
        #message_box
        {
            position: absolute;
            top: 87%;
            left: 87%;
            z-index: 10;
            background: white;
            padding: 5px;
            border: 1px solid #CCCCCC;
            text-align: center;
            font-weight: bold;
            width: 12%;
        }
        #cphAdmin_taskView img
        {
            cursor: pointer;
        }
        .commentseparator
        {
            width: 600px;
            height: 1px;
            background: gray;
            margin-bottom: 3px;
        }
    </style>
    <script type="text/javascript" src="scripts/jquery.js"></script>
    <script type="text/javascript" src="scripts/jquery.printElement.min.js"></script>
    <%--    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnDownload').click(function () {
                alert('');
                $('.project-view').printArea();
                alert('');
            });

        });
    </script>--%>
    <script type="text/javascript">

        var taskID = 0;
        var percentageComplete = 0;
        var userid = <%=this.UserID%>;
        var projectid= <%=this.ProjectID%>;
        var taskcomment="";
     var taskdescription="";
     var Data;

     
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
            var maxLength = 750;
            SetMaxLength(memo, maxLength);
        }


       $(document).ready(function () {
       //SEND TASK COMMENT
//     

       //SEND TASK COMMENT
       $('.send-message').click(function(){
        var row="";
      taskcomment = $('#cphAdmin_ASPxPopupControl1_txtComment_I').val();
 if(taskcomment=="")
 { alert('Comment cannot left blank.');return;}
                  $.ajax({
                type: "POST",
                url: "ServiceUpdateTaskStatus.asmx/InsertTaskComment",
                data: '{"taskID":"'+taskID+'","comment":"'+ taskcomment+'","userID":"'+ userid+'","projectID":"'+projectid+'"}',
 
                contentType: "application/json; charset=utf-8",
                
                dataType: "json",
                success: successcomment1
            });
            function successcomment1(data){
         
              var object = JSON.parse(data.d);
             
              for(var post in object)
              {
              row +='<tr><td style="color:gray; font-size:11px;"><div class="commentseparator">&nbsp;</div>Updated:'+object[post].Createddate+'</td></tr><tr><td style="color:gray; font-size:11px;">Updated By:'+object[post].FullName+'<br><br></td></tr>';
              row += '<tr><td>'+object[post].ImageString+'</td></tr>';
              row +='<tr><td>'+object[post].Comment+'</br></br></br></td></tr>';
              }
            
              row = '<table>'+row+'</table>';
               $('#cphAdmin_ASPxPopupControl1_txtComment_I').val("");
              $(".divinnercontent").html("");
              $(".divinnercontent").html(row);
              $('.loadingimagepp').hide();
              $('.lbl-message').show();
            }
       });

       //Remove Task
       $('.delete').click(function(){
    
       
          //Set TaskID
                $(this).parent().parent().find('td').each(function () {
                    //Set Taskid variable which is supplied to the service
                  if($(this).find('a').text() != "")
                   { taskID = $(this).find('a').text(); tasktitle = $(this).find('a').parent().next().html(); }              
                });
                      var v=  confirm('Are you sure you want to delete task no. #'+taskID+'?');
                        if(!v)
         {return;}
                     $.ajax({
                type: "POST",
                url: "ServiceUpdateTaskStatus.asmx/DeleteTask",
                data: '{"taskID":"'+taskID+'"}',
 
                contentType: "application/json; charset=utf-8",
                
                dataType: "json",
                success: $(this).parent().parent().remove()
            });

          
       });


       //VIEW TASK COMMENT
        $("#cphAdmin_taskView .comment").click(function(){
      taskdescription =$(this).parent().parent().find('.lbldescription').text();
              $('.taskdescription').text(taskdescription);      
        $('.lbl-message').hide();
        $(".divinnercontent").html("");
        $(".taskimage").html("");
          pploading.Show();
          $('.loadingimagepp').show();
        var row="";
        var tasktitle="";
          //Set TaskID
                $(this).parent().parent().find('td').each(function () {
                    //Set Taskid variable which is supplied to the service
                  if($(this).find('a').text() != "")
                   { taskID = $(this).find('a').text(); tasktitle = $(this).find('a').parent().next().html(); }
                
                });

                //Set TaskID
                $('#taskid').html('Task: #'+ taskID);
                $('#tasktitle').html('Title: '+ tasktitle);


                //Get Task Comment
                  $.ajax({
                type: "POST",
                url: "ServiceUpdateTaskStatus.asmx/GetTaskComment",
                data: '{"taskID":"'+taskID+'"}',
 
                contentType: "application/json; charset=utf-8",
                
                dataType: "json",
                success: successcomment
            });
            function successcomment(data){
              var object = JSON.parse(data.d);
             
              for(var post in object)
              {
              row +='<tr><td style="color:gray; font-size:11px;"><div class="commentseparator">&nbsp;</div>Updated:'+object[post].Createddate+'</td></tr><tr><td style="color:gray; font-size:11px;">Updated By:'+object[post].FullName+'<br><br></td></tr>';
              row += '<tr><td>'+object[post].ImageString+'</td></tr>';
              row +='<tr><td>'+object[post].Comment+'</br></br></br></td></tr>';
              }
              row = '<table>'+row+'</table>';
           
              $(".divinnercontent").html(row);
              $('.loadingimagepp').hide();

              
            //Get Task Image
                              $.ajax({
                type: "POST",
                url: "ServiceUpdateTaskStatus.asmx/GetTaskImage",
                data: '{"taskID":"'+taskID+'"}',
 
                contentType: "application/json; charset=utf-8",
                
                dataType: "json",
                success: successcomment
            });
            function successcomment(data){
  var object = JSON.parse(data.d);
  var str="";
          for(var post in object)
          {
         str+= object[post].ImageURL;
          }
          $(".taskimage").html(str);
         
            }
            }



                   });




       //UPDATE TASK STATUS
            $("#cphAdmin_taskView .bubblestatus").click(function () {
            var v=  confirm('Are you sure you want to update status of this task ?');
         if(!v)
         {return;}
                //Get the ALT attribute from clicked image it will be from (14,28,42,56,70,84,100)
                var imageNumber = $(this).attr("alt");

                //Set Percentage Complete variable it is parameter to pass in web service
                percentageComplete = imageNumber;

                //Set TaskID
                $(this).parent().parent().find('td').each(function () {
                    //Set Taskid variable which is supplied to the service
                  if($(this).find('a').text() != "")
                    taskID = $(this).find('a').text();
                      
                });
           
              
 Data = '{"taskID": "' + taskID + '","userID": "' + userid + '","percentage":"'+percentageComplete+'","projectID":"'+projectid+'"}';      
     
            $.ajax({
                type: "POST",
                url: "ServiceUpdateTaskStatus.asmx/UpdateStatus",
                data: Data,
 
                contentType: "application/json; charset=utf-8",
                
                dataType: "json",
                success: OnSuccess
            });
             function OnSuccess(response) {
         
             }

                //set color according to image number
                var color = "";
                switch (imageNumber) {
                    case '14':
                        color = "black";
                        break;
                    case '28':
                        color = "DarkGoldenRod";
                        break;
                    case '42':
                        color = "blue";
                        break;
                    case '56':
                        color = "purple";
                        break;
                    case '70':
                        color = "red";
                        break;
                    case '84':
                        color = "brown";
                        break;
                    case '100':
                        color = "green";
                        break;
                    default:
                        color = "black";
                        break;
                }

                //Find <Tr> Tag and then find all the <TD> tag from >TR
                $(this).parent().parent().find('td').each(function () {

                    //Find First Column Which is task number Change its color according to bubble position
                    $(this).find('a').removeAttr('style');
                    $(this).find('a').css('color', color);

                    //Find the Second column which is <TD> remove its style first and then set its color according to bubble position
                    $(this).removeAttr('style');
                    $(this).css('color', color);

                    //Change all the Bubble to No image first
                    var commentimage = $(this).find('img').attr("src"); 
                    if(commentimage != "images/comment.png" && commentimage != "images/closeMark1.png")
                    $(this).find('img').attr("src", "images/noimage.png");

                });

                //Set the Green Bubble at the position where image is clicked
                $(this).attr("src", "images/bullet_green.png");

            });
        });


        $(document).ready(function () {
         

         //Hide Popup when MouseOut
//          $("#ctl00_cphAdmin_taskView .bubblestatus").mouseout(function(){
//         $('#popup').hide(300);
//         });


            $('#popup').hide();
            $('#message_box').animate({ top: $(window).scrollTop() + "px" }, { queue: false, duration: 0 });
          
            //scroll the message box to the top offset of browser's scrool bar
            $(window).scroll(function () {
                $('#message_box').animate({ top: $(window).scrollTop() + "px" }, { queue: false, duration: 700 });
            
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
            setTimeout(function(){$('#popup').hide();},4000);
            //popup.Show();

        }

        function btndownloadpdfclick(s,e){
        
    
    //$('.module-detail').css('padding','0px');
         //var stringHtml = $('#ctl00_cphAdmin_divProjectView').html();
        
   $('.task-table td:nth-child(12)').css("display","none");
   $('.task-table td:nth-child(11)').css("display","none");
   $('.task-table td:nth-child(10)').css("display","none");
     
                           
          var stringHtml=  $('#cphAdmin_divProjectView').html();
          //alert(stringHtml);
                    while (stringHtml.search('–') >= 0) {
                stringHtml = stringHtml.replace('–', '-');
            }
           
            $('#cphAdmin_hdnHtml').val(stringHtml);

          $('.task-table td:nth-child(10)').css("display","table-cell");
          $('.task-table td:nth-child(11)').css("display","table-cell");
          $('.task-table td:nth-child(12)').css("display","table-cell");
            
          
          $.ajax({

                type: "POST",
                url: "project-queue.aspx/downloadPdf",
                data: "{'s':'" + stringHtml.toString().trim() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
              success: OnSuccess

            });
        }

          function OnSuccess(response) {
           

                }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <div class="project-queue">
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="pploading"
            AllowDragging="True" Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            ModalBackgroundStyle-BackColor="Black" EnableAnimation="true" HeaderText="Task Comment"
            HeaderStyle-Font-Bold="true" Width="600px">
            <HeaderStyle Font-Bold="True"></HeaderStyle>
            <ModalBackgroundStyle BackColor="Black">
            </ModalBackgroundStyle>
            <ContentCollection>
                <dx:PopupControlContentControl ID="test">
                    <div class="divcontent">
                        <asp:Label ID="Label1" Text="Task comment added successfully" CssClass="lbl-message"
                            runat="server" EnableViewState="false"></asp:Label>
                        <table>
                            <tr>
                                <td align="left" valign="top">
                                    <span style="font-weight: bold;" id="taskid"></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <span style="font-weight: bold;" id="tasktitle"></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <table cellpadding="2" cellspacing="3" border="0">
                                        <tr>
                                            <td align="left" valign="top">
                                                <img src='/images/comment.jpg' alt="flag" />
                                            </td>
                                            <td align="left" valign="middle">
                                                <span class="add-comment" style="cursor: pointer; color: Blue; font-weight: bold;">Add
                                                    a Comment</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <div class="comment-box">
                                        <dx:ASPxMemo ID="txtComment" runat="server" Height="110px" Width="263px" ClientInstanceName="memo">
                                            <ClientSideEvents KeyUp="function(s,e){var ele = s.GetText(); lblCommentCharRemain.SetText(750 - ele.length); OnMaxLengthChanged(s,e)} " />
                                        </dx:ASPxMemo>
                                        <div class="send-message" style="color: Blue; cursor: pointer; font-weight: bold;">
                                            Send Message
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <table cellpadding="2" cellspacing="3" border="0">
                                        <tr>
                                            <td align="left" valign="top">
                                                <div class="char-remain-box">
                                                    <dx:ASPxLabel ID="lblCommentCharRemain" runat="server" Text="750" ClientInstanceName="lblCommentCharRemain">
                                                    </dx:ASPxLabel>
                                                </div>
                                            </td>
                                            <td align="left" valign="middle">
                                                Characters remaining
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <div class="taskimage">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <span style="color: gray; font-size: 11px;">Task Description:<br />
                        </span>
                        <br />
                        <div class="taskdescription">
                        </div>
                        <br />
                        <div class="divinnercontent">
                        </div>
                        <img src="images/loadingpage.gif" class="loadingimagepp" />
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <div id="message_box" style="display: none;">
            <table>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" ID="lnklegendimage1" OnCommand="lnklegendimage_Click"
                            CommandArgument="14" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="searchimg1" ImageUrl="~/images/t14.png" Height="20px"
                                            Width="19px" AlternateText="14" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: Black;" class="taskdetailcolorlegendtext">
                                        Open
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton1"
                            CommandArgument="28" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/images/t28.png" Height="20px"
                                            Width="19px" AlternateText="28" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: DarkGoldenRod;" class="taskdetailcolorlegendtext">
                                        Discussion
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton2"
                            CommandArgument="42" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/images/t42.png" Height="20px"
                                            Width="19px" AlternateText="42" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: Blue;" class="taskdetailcolorlegendtext">
                                        In Programming
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton3"
                            CommandArgument="56" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/images/t56.png" Height="20px"
                                            Width="19px" AlternateText="56" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: Purple;" class="taskdetailcolorlegendtext">
                                        Ready For Test
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton4"
                            CommandArgument="70" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton4" ImageUrl="~/images/t70.png" Height="20px"
                                            Width="19px" AlternateText="70" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: Red;" class="taskdetailcolorlegendtext">
                                        Bug Found
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton5"
                            CommandArgument="84" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/images/t84.png" Height="20px"
                                            Width="19px" AlternateText="84" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: brown;" class="taskdetailcolorlegendtext">
                                        Bug Fixed
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton Font-Underline="false" OnCommand="lnklegendimage_Click" ID="LinkButton6"
                            CommandArgument="100" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton6" ImageUrl="~/images/t100.png" Height="20px"
                                            Width="19px" AlternateText="100" />
                                    </td>
                                    <td style="text-align: left; padding-left: 5px; color: Green;" class="taskdetailcolorlegendtext">
                                        Closed
                                    </td>
                                </tr>
                            </table>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="heading">
            <h2>
                Active Projects (<asp:Label ID="lblActiveProjectCount" runat="server"></asp:Label>)
            </h2>
        </div>
        <div class="div-message default-padding-left">
            <asp:Label ID="lblStatus" runat="server" EnableViewState="false"></asp:Label>
        </div>
        <div class="Projects-list">
            <dx:ASPxGridView ID="gvProjects" ClientInstanceName="grid" runat="server" KeyFieldName="ProjectId"
                Width="910px" AutoGenerateColumns="False" OnRowCommand="gvProjects_RowCommand">
                <Columns>
                    <dx:GridViewDataColumn Caption="View" Width="50">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" CausesValidation="false"
                                CommandArgument='<%# Eval("ProjectId") %>'>
                                <img id="Img1" runat="server" src="~/images/view.png" alt="View" style="border: 0px;"
                                    title="View" /></asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Project Name" FieldName="ProjectName" Width="300">
                        <DataItemTemplate>
                            <a class="projectlink" style="color: Blue; text-decoration: underline;" href='task-detail.aspx?projectid=<%# Eval("ProjectId") %>'>
                                <%# Eval("ProjectName") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Proj. ID" FieldName="ProjectId">
                        <DataItemTemplate>
                            <%--  <div style="background: url('images/folder.jpg') no-repeat scroll top left; width: 100%;
                                height: 100%">--%>
                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" CausesValidation="false"
                                PostBackUrl='<%#"component-queue.aspx?pid=" + Convert.ToString(Eval("ProjectId"))%>'
                                CssClass="folder">
                                <div style="background: url('images/folder.jpg') no-repeat scroll top left; width: 32px;
                                height: 20px;font-size: 15px;font-weight: bold;padding: 7px 0 0 7px;text-align: left;"><%# Eval("ProjectId") %>
                                </div>
                            </asp:LinkButton>
                            <%--</div>--%>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataColumn Caption="Open Tasks" FieldName="OpenTask" Width="20">
                        <DataItemTemplate>
                            <%#Eval("OpenTask")%>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Modules" FieldName="Modules" Width="60" />
                    <%--        <dx:GridViewDataColumn Caption="Status" FieldName="ProjectStatus" Width="50">
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
                            <asp:LinkButton ForeColor='<%#PromanWeb.Helper.DisableLinkColor(Convert.ToInt64(Eval("TaskCount")))%>'
                                Enabled='<%#PromanWeb.Helper.IsEnableDeleteLink(Convert.ToInt64(Eval("TaskCount")))%>'
                                ID="lnkEdit" Font-Underline="true" runat="server" CommandName="DeleteProject"
                                OnClientClick='<%#PromanWeb.Helper.DisableLinkConfirmation(Convert.ToInt64(Eval("TaskCount")))%>'
                                CausesValidation="false" CommandArgument='<%# Eval("ProjectId") %>'>
                             Delete</asp:LinkButton>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>
                <Settings ShowFilterRow="True" />
                <ClientSideEvents EndCallback="function(s,e){ReLoadGridStyles(s,e);}" />
            </dx:ASPxGridView>
        </div>
        <div style="padding: 10px 0 15px 0">
            <div style="float: left; width: 370px; text-align: right; font-family: Arial,Helvetica,sans-serif;
                font-weight: bold; color: Black; font-size: 14px;">
                Total
            </div>
            <div style="float: left; text-align: right; width: 115px; font-weight: bold; color: Black;
                font-size: 14px;">
                <asp:Label ID="lblOpenTaskCount" Text="546" runat="server"></asp:Label>
            </div>
            <div style="float: left; width: 70px; text-align: right; font-weight: bold; font-size: 14px;
                color: Black">
                <asp:Label ID="lblModuleCount" Text="56" runat="server"></asp:Label>
            </div>
            <div style="float: left; padding: 0px 0 0px 15px; font-weight: bold; font-size: 14px;
                color: Blue">
                Company Wide % Rate:
                <asp:Label ID="lblprojectStatus" runat="server"></asp:Label>%
            </div>
        </div>
        <div class="project-view" runat="server" id="divProjectView" visible="false" style=" position:static;  margin: 5px;    width: 900px;    border: 1px solid #000000;">
            <table id="llogo" style=" display:none;">
                <tr>
                    <td>
                        <img style="margin-top: 5px; margin-left: 5px;" height="70px" src='<%= PromanWeb.AppSetting.GetSetting("ApplicationURL", PromanWeb.AppSettingCategory.General) %>/images/logo.png'
                            alt="Logo" title="Project Task Manager" />
                    </td>
                    <td>
                        <h2 style="color: #3366FF;">
                            WorkVue</h2>
                    </td>
                </tr>
            </table>
            <div class="sub-heading" style="background-color: #99CCFF; height: 20px; padding-bottom: 0;
                padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: left; vertical-align: middle;
                width: 890px;">
                <div class="project-name" style="float:left; margin-left:15px; font-size:13px;">
                    <h2>
                        <span id="spanProjectName" runat="server"></span>
                    </h2>
                </div>
                <div class="day-to-project-due" style="float:right;font-size:13px;">
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
                        <dx:ASPxProgressBar ID="pbOverall" runat="server" Height="21px" Width="290px">
                        </dx:ASPxProgressBar>
                    </td>
                </tr>
            </table>
            <div style="width: 500px; padding-left: 15px">
                <hr class="hr" style="width: 875px;    border-color: Gray;    border: solid 1px gray;" id="Hr1" runat="server" />
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
                <hr class="hr" style="width: 875px;    border-color: Gray;    border: solid 1px gray;" id="hr2" runat="server" />
                <br />
            </div>
            <table runat="server" id="colordot" class="colordot">
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
            </table>
            <div class="hideprint">
                <table>
                    <tr>
                        <td colspan="7" style="padding-left:13px;">
                            <hr class="hr" id="hr3" runat="server" style="width:875px;" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td style="padding-left: 13px;">
                                        <img src="images/t14.png" height="20" width="19" />
                                    </td>
                                    <td style="color: Black; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Open
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <img src="images/t28.png" height="20" width="19" />
                                    </td>
                                    <td style="color: DarkGoldenRod; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Discussion
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <img src="images/t42.png" height="20" width="19" />
                                    </td>
                                    <td style="color: blue; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        In Programming
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <img src="images/t56.png" height="20" width="19" />
                                    </td>
                                    <td style="color: purple; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Ready For Test
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <img src="images/t70.png" height="20" width="19" />
                                    </td>
                                    <td style="color: red; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Bug Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <img src="images/t84.png" height="20" width="19" />
                                    </td>
                                    <td style="color: brown; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Bug Fixed
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImageButton7" ImageUrl="~/images/t100.png" Height="20px"
                                            Width="19px" AlternateText="100" />
                                    </td>
                                    <td style="color: green; text-decoration: none;" class="taskdetailcolorlegendtext">
                                        Closed
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="module-detail">
                <div id="taskView" class="taskview" runat="server" style="padding:7px;">
                </div>
                <div id="popup" style="height: 40px;">
                    <div id="date" style="height: 35px; padding-top: 5px;">
                        &nbsp;</div>
                </div>
                <div id="divButtons" class="buttons">
                    <table cellpadding="2" cellspacing="3">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnViewTasks" runat="server" Text="View Tasks" OnClick="btnViewTasks_Click">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnEditProject" runat="server" Text="Edit Project" OnClick="btnProjectEdit_Click">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <a href="#" onclick="javascript:$('#llogo').css('display','block');$('#divButtons,.hideprint').css('display','none');$('.project-view').printElement();$('#llogo').css('display','none');$('#divButtons,.hideprint').css('display','block');return false;"
                                    class="printform">Download Report</a>&nbsp;&nbsp;
                                <dx:ASPxButton AutoPostBack="false" ID="btndownloadpdf" Visible="false" ClientInstanceName="btndownloadpdf"
                                    runat="server" Text="Download Report" OnClick="btndownloadpdf_Click">
                                    <ClientSideEvents Click="btndownloadpdfclick" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnHtml" runat="server" />
</asp:Content>
