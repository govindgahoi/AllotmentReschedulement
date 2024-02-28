﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsolidatedDemand.aspx.cs" Inherits="UpsidaAllottee.ConsolidatedDemand" Culture="en-IN" UICulture="en-IN" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllotteeDemandNLedger.aspx.cs" Inherits="Allotment.ViewAllotteeDemandNLedger" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
    <script type="text/javascript"  lang="js">  
        $(function()  
        {
            $("input[type=text]").keyup(function () {
                
                $("#btnLedger").hide();
                $("#lblLedger").hide();
                $("#gridAllotDetail").hide();
                $("#lblMsg").hide();
                $("#btnDemand").hide();
                $("#GridViewledger").hide();
                $("#totransection").hide();
                $("#lbldebit").hide();
                $("#lblcredit").hide();
                $("#Label1").hide();
                $("#lblDemandNote").hide();
                $("#PreviousServiceDiv").hide();
            });  
           
        });  
    </script> 
    <title></title>
     <style type="text/css">
        
        h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 1%;
            }
        }
        .fill-view-mytable td {
            font-size:16px !important;
        }
        .modal-header {
            padding: 2px !important;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }


            .my-app-status li:after{
               content: "\f178";
               font-family: FontAwesome;
               font-weight: 800;
               font-style: normal;
               margin:0 0 0px 5px;
               text-decoration:none;

            }
            .my-app-status {
                    margin: 10px auto;
                    border: 1px solid #ccc;
                    padding: 14px 0px;
                    text-align: center;
                    background: #dfdfdf;
                    border: 1px solid #ccc;
            }
            .my-app-status li span{
                border:1px solid #ccc;
                padding: 8px 6px;
                font-size: 11px;
                background: #f4cd4c;
            }
             .my-app-status li:nth-last-child(1):after{
                 display:none !important;
             }
            .my-app-status li{
                margin: 10px 0;
                padding: 0;
             }
            .my-app-status li span.orange{
                background: orange;
                color: #fff;
            }
            .my-app-status li span.red{
                background: red;
                color: #fff;
            }
            .my-app-status li span.green{
                background: green;
                color: #fff;
            }
            .row{
                margin-bottom: 10px;
            }
            .lblmessage{
                background-color:gainsboro;
                width:100%;
                text-align:center;
                margin-top:10PX;
                margin-bottom:10PX;

            }
            .btnledger{
                text-align:center;
                margin-top:15px;
                margin-bottom:10px;
            }
            .GridViewledger1{
                text-align:center;
                margin-bottom:15px;
            }
            .lblViewledger{
                background-color:ghostwhite;
                width:100%;
                text-align:center;
                margin-top:20PX;
                margin-bottom:5PX;
                font-size:larger;
                font-weight:600;
            }
            .col-sm-9{
                margin-right:20px
            }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row table-responsive" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">CONSOLIDATED DEMAND</div>
                        <hr class="separation" />  
                       
                        

                        
                         <div class="row">
                             
                            <div class="col-md-2 col-lg-2 col-sm-2 ">
                            <span style="color: Red">*</span>
                               Regional Office
                            </div>
                             <div class="col-md-3 col-lg-3 col-sm-8" >
                                 <asp:DropDownList ID="dlRO" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged" ></asp:DropDownList>
                             </div>

                              <div class="col-md-2 col-lg-2 col-sm-2 ">
                            <span style="color: Red">*</span>
                               Industrial Area
                            </div>
                             <div class="col-lg-3 col-md-3 col-sm-8 ">
                                 <asp:DropDownList ID="DlIA" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DlIA_SelectedIndexChanged"></asp:DropDownList>
                             </div>
                         </div>
                        
                         </div>
                        
                           
                        <div class="row" style="margin-top:10px">
                            <div class="col-md-12 col-sm-12 text-center">
                                <asp:Button ID="btnsubmit" runat="server"  CssClass="btn btn-sm btn-primary" Text="Consolidated Demand" OnClick="Demand_Click" />
                                </div>
                            </div>
                    </div>
                     <div class="panel panel-default" runat="server" id="panel">
                    <%--<hr class="separation" />--%>
                    <div class="">
                    <asp:GridView ID="gridTotalDetail" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="gridTotalDetail_RowDataBound">

                        <Columns>
                            <asp:BoundField ItemStyle-Width="200px" DataField="Head" HeaderText="Head Description" />
                            <asp:BoundField ItemStyle-Width="30px" DataField="Demand" HeaderText="Demand" />
                            <asp:BoundField ItemStyle-Width="30px" DataField="Paid" HeaderText="Paid" />
                        </Columns>
                    </asp:GridView>

                    </div>
                         <div style="font-weight:600;font-size:18px; background-color:#edefee;padding-left:5px">
                             <asp:Label ID="Label1" runat="server" Text=" Total Recoverable : " CssClass="margin-left-5px"></asp:Label>&nbsp;
                             <asp:Label ID="lblRecoverable" runat="server" Text=""></asp:Label>
                         </div>
                        
            </div>
                    </div>
               </div>
            
        </div>
    </form>
</body>

</html>
