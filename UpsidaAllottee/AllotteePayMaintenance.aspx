<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteePayMaintenance.aspx.cs" Inherits="UpsidaAllottee.AllotteePayMaintenance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />

  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <%--<script src="js/chosen.jquery.min.js"></script>--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
   
    <style>
        .sweet-alert p {
            color: darkblue !important;
            font-size: 15px;
            text-align: center;
            font-weight: 600;
            position: relative;
            text-align: inherit;
            float: none;
            margin: 0;
            padding: 0;
            line-height: normal;
        }
        .launch{
            color:darkblue;
        }
        /*hr{
            border-color:antiquewhite;
            width:250px
        }*/
        .mainnavbar {
            height: 38px !important;
        }
        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 .col-sm-6  .col-md-12 .col-lg-3 {
                width: 50% !important;
            }
            .col-lg-3 {
                width: 50% !important;
            }
        }
        #SideDiv {
            margin-left: 0px;
        }

        Label {
            font-weight: 500;
        }
       
        .maintenacecharge {
            margin-top: 10px;
            font-size:14px !important;
        }

        .txtRed {
            color: red;
        }

        #lblTotalDues {
            color: red;
        }

        #lblInterest {
            color: red;
        }

        .txtgreen {
            color: green;
        }

        ContentTemplate {
            padding-bottom: 30px;
        }
        .payableAmount{
            padding-top:30px;
            /*visibility:hidden;*/
            display:none;
        }
         #UpdateProgress1 {
            position: fixed;
            width: 100%;
            height: 100%;
            z-index: 99999;
            background: rgba(0,0,0,0.21176470588235294);
        }

            #UpdateProgress1 .fgh {
                position: absolute;
                top: 40%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }
            .ui-menu-item{
                font-size:12px!important;
                background:#fff9e7!important;
                font-family:inherit!important;
                color:#555!important;
            }
    </style>
    
</head>
<body >
    
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
               <Triggers>
            <asp:PostBackTrigger ControlID="btnOffline" />
             <%--<asp:PostBackTrigger ControlID="proceedAnchor" />--%>
         
        </Triggers>
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                                
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><br />
                                <span style="font-size: 25px; font-weight: bold;">Please Wait...</span>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                
                    <div class="">

                        <button type="button" id="btnSleepModal" class="ey-bg btn-primary pull-right" data-toggle="modal" data-target="#myModalSleep" data-backdrop="static" style="margin: 2px 5px 0 0; display: none;">Heading</button>

                        <!-- Modal -->
                        <div class="modal fade" id="myModalSleep" role="dialog">
                            <div class="modal-dialog">
                                <style>
                                    .row {
                                        margin-right: 0px !important;
                                    }

                                    .abc {
                                        border: 1px solid black;
                                    }

                                    .xyz {
                                        text-align: right;
                                    }

                                    .mynewpanelhead {
                                        font-size: 14px !important;
                                        font-weight: 600;
                                        background: #2d2d2d;
                                        color: #ffc511 !important;
                                    }

                                    #myModalSleep h4.modal-title {
                                        margin-right: 18px;
                                        text-align: center;
                                    }

                                    #myModalSleep.modal .modal-body {
                                        padding: 3px 3px 0 0 !important;
                                        background: #000;
                                        color: #10ce10;
                                        min-height: 100px;
                                    }

                                    #myModalSleep {
                                        background: rgba(0, 0, 0, 0.1);
                                    }

                                    .modal-backdrop {
                                        background: none !important;
                                    }

                                    @media only screen and (min-width: 920px) {
                                        #myModalSleep .modal-dialog {
                                            top: 38%;
                                            width: 900px;
                                        }
                                    }
                                </style>
                                <!-- Modal content-->
                                <div class="modal-content">

                                    <div class="modal-body">
                                        <div style="padding: 0 15px; max-height: 600px; overflow-y: auto">
                                            <span class="message">Connecting To Nivesh Mitra</span>
                                            <asp:HiddenField runat="server" ID="HidFieldSuccessFail" />

                                            <button type="button" id="btnCloseModal" class="ey-bg btn-primary pull-right" data-dismiss="modal" data-target="#myModalSleep" style="margin: 2px 5px 0 0; display: none;">Close</button>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>

                        <div class="modal fade" id="PlotModal" role="dialog" style="overflow: hidden;">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Select Your Preferences</h4>
                                    </div>
                                    <div class="modal-body" style="overflow: scroll;">
                                        <div class="col-md-12" style="font-size: 12px; padding: 4px 15px; height: 300px;">
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="PlotSpan"><span runat="server" id="lblmsgSpan" style="float: left; font-size: 14px; background: #ffe9e9; padding: 8px;" visible="false"></span></div>
                                        <div class="pull-right border-buttons">

                                            <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;" onclick="Uncheckedterms()">Hide</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal fade" id="myModal" role="dialog" tabindex="-1">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Terms and Conditions</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="scr" id="agreement" style="font-size: 12px; padding: 4px 15px; overflow: auto; height: 321px;" onscroll="scrollFunction()">

                                         

                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="pull-left">Note : Please scroll down to read & accept all terms & Conditions</div>
                                        <div class="pull-right border-buttons">
                                            <asp:Button ID="btnIAccept" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Style="margin-right: 3px; display: none;" Text="I Accept" />
                                            <button type="button" id="closeBtn" class="btn btn-primary btn-popup" data-dismiss="modal" style="margin-right: 0;">Cancel</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <input type="button" id="btnModalTerms" style="display: none;" data-toggle="modal" data-target="#myModal" data-backdrop="static" />


                        <%-- End Of Modal Section  --%>
                       

                        
                        <div class="panel panel-default " >
                            <asp:Panel  ID="ots" runat="server" >
                            <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
                                <div class="row">
                                    <div class="col-md-3 col-sm-4 col-xs-12 left-niveshban">
                                        <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                            <li>
                                                <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                            <li></li>
                                        </ul>
                                    </div>
                                    <div class="col-md-6 col-sm-4 col-xs-12 text-center">

                                        <h2 id="chg_head">Nivesh Mitra</h2>
                                        <p><span style="font-size: 20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                    </div>
                                    <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                        <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px; margin-left: 170px;">
                                            <li>
                                                <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                        </ul>
                                    </div>
                                    <%--<div class="clearfix"></div>--%>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 text-center">

                                        <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>

                                    </div>

                                    <%--<div class="clearfix"></div>--%>    
    
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;">
                                <div class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 600;" OnClick="btn_backNmswp_Click" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <asp:HiddenField runat="server" ClientIDMode="Static" EnableViewState="true" ID="HidStatus" />
                            <div class="panel-heading font-bold text-center" style="font-size: 20px !important; font-weight: 600; background: #006699; color: #fdeec2 !important;"><span id="PageHeadingLbl"><marquee>OTS Scheme - Pay Maintenance Dues</marquee></span></div>
                                    
                            <div class="row" runat="server" id="SideDiv" style="padding-left: 30px; padding-right: 30px; padding-top: 30px; padding-bottom: 30px;margin-top:0px;">

                                <div class="panel panel-default" runat="server" id="FilterDiv" style="margin-top: 12px;">
                                    <div class="form-group">
                                         
                                        <label class="col-md-1 col-sm-6 text-right">
                                            Plot Type:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:DropDownList runat="server" ID="drpPlotType" CssClass="chosen input-sm similar-select1 margin-left-z form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 col-sm-6 text-right">
                                            Industrial Area:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:DropDownList runat="server" ID="drpIndusrialArea" CssClass="chosen input-sm similar-select1 margin-left-z form-control"></asp:DropDownList>
                                        </div>
                                        
                                        <label class="col-md-1 col-sm-6 text-right">
                                            Plot No:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:TextBox runat="server" ID="txtsearch" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control" OnTextChanged="text_Change" ></asp:TextBox>
                                        </div>

                                        <div class="col-md-2 col-sm-10">
                                            <asp:Button runat="server" ID="btnfind" Text="Find" CssClass="btn-group-lg alert-success" OnClick="btnfind_Click" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div id="DivOTP" runat="server" visible="false">
                                        <div class="form-group" style="margin-top: 1px;">
                                            <label class="col-md-4 text-right">
                                                Enter OTP:
                                            </label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" ID="txtOTP" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox>
                                                <div>Time left = <span id="timer"></span></div>
                                            </div>

                                            <div class="col-md-4">
                                                <asp:Button runat="server" ID="Button3" Text="Verify" CssClass="btn-group-lg alert-success" OnClick="Button1_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    <br />
                                <asp:Panel ID="AllotteeMaintenanceDetain"  runat="server">
                                    <div style="background:#ececec;margin-top:0px;padding:10px 0;">

                                
                                <div  class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom:10px;font-size:16px">

                                    <div class="row maintenacecharge">
                                        <div class="col-md-2 col-lg-2 col-sm-6 col-xs-1 text-right">
                                            <asp:Label ID="label1" runat="server" Text="Regional Office :"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-6 col-sm-4 col-xs-4">
                                            <asp:Label ID="lblregion" runat="server" Text=""></asp:Label>
                                        </div>
										<div class="col-md-8 col-lg-4 col-sm-2 col-xs-4 text-right">
                                           <%--<asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="Raise Grievance" onClick="Click_Query" />--%>
                                            <%--<asp:Label ID="btnQuery" runat="server" Text=""></asp:Label>--%>
                                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-info" Text="GO BACK" onClick="Click_Back" />
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-2 col-lg-2 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label2" runat="server" Text="Industrial Area :"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblIA" runat="server"  ></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-2 col-lg-2 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label3" runat="server"  Text="Plot Number :"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-6 col-sm-6 col-xs-6">
                                            <asp:Label ID="LblPlot" runat="server" ></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-2 col-lg-2 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label7" runat="server" Text="Allottee Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-6 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblallotteeName" runat="server"  Text=""></asp:Label>
                                        </div>
                                    </div>
                                   <asp:Panel runat="server" ID="payableAmount">
                                        <div class="row maintenacecharge ">
                                            <div class="col-md-2 col-lg-2 col-sm-6 col-xs-6 text-right" style="font-size: 14px; font-weight: 600">
                                                <asp:Label ID="lblQueryPayable" runat="server"  Text="PAYABLE AMOUNT :"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-6 col-sm-6 col-xs-6">
                                                <asp:Label ID="lblQueryPayAmount" runat="server"  Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row maintenacecharge ">
                                            <div class="col-md-2 col-lg-2 col-sm-5 col-xs-5 text-right" style="font-size: 14px; font-weight: 600">
                                                <asp:Label ID="lblIssue" runat="server" Text="Select Issue :"></asp:Label>
                                            </div>
                                            <div class="col-md-4 col-lg-5 col-sm-5 col-xs-5">
                                                <asp:DropDownList ID="DropDownList1" CssClass=" chosen input-sm similar-select1 margin-left-z" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem Value="">---Please Select---</asp:ListItem>
                                                    <asp:ListItem>Incorrect Maintenance Charge </asp:ListItem>
                                                    <asp:ListItem>Incorrect Maintenance Charge due to difference in Plot Area </asp:ListItem>
                                                    <asp:ListItem>Incorrect Interest on Maintenance Charge</asp:ListItem>
                                                    <asp:ListItem>Incorrect Maintenance Charge and Interest on Maintenance Charge</asp:ListItem>
                                                    <asp:ListItem>Maintenance Charge Not Applicable </asp:ListItem>
                                                    <asp:ListItem>Already Deposited</asp:ListItem>
                                                    <asp:ListItem>Disputed due to Court Case</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            
                                        </div>
                                       <div class="row maintenacecharge ">
                                            <div class="col-md-2 col-lg-2 col-sm-5 col-xs-5 text-right" style="font-size: 14px; font-weight: 600">
                                                <asp:Label ID="Label9" runat="server" Text="Description :"></asp:Label>
                                            </div>
                                            <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5">
                                               <asp:TextBox ID="txtDescription" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtDescription" CssClass=" chosen input-sm similar-select1 margin-left-z" 
                                                        ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{20,1000}$" runat="server" 
                                                        ErrorMessage="Minimum 20 and Maximum 1000 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                       
                                       <asp:Panel runat="server" ID="fLoad" class="row maintenacecharge" >
                                           <div class="col-md-2 col-lg-2 col-sm-5 col-xs-5 text-right" style="font-size: 14px; font-weight: 600">
                                               <asp:Label ID="Label11" runat="server"  Text="Attach Relevent Document :"></asp:Label>
                                           </div>
                                           <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5" style="padding-bottom:10px;height: 29px !important;">
                                               <asp:FileUpload ID="FileUpload1" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px" />
                                           </div>
                                       
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 text-center" style="margin-top:20px">
                                                <asp:Button ID="btnSubmit" runat="server" autopostback="true" CssClass="btn btn-success" Text="Submit" OnClick="click_ComSubmit" />
                                            </div>
                                        </asp:Panel>
                                       
                                </asp:Panel>

                                    <asp:Panel runat="server" ID="QueryInfo">
                                        <div class="row maintenacecharge">

                                            <div class="col-md-offset-3 col-md-5 col-lg-5 col-sm-6 text-right">
                                                <asp:Label ID="label4" runat="server" Text="Maintenance Charge Due upto 30-06-2021 :"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 txtRed">
                                                <asp:Label ID="lblMaintenanceCharge" runat="server" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row maintenacecharge">
                                            <div class="col-md-offset-3 col-md-5 col-lg-5 col-sm-6 text-right">
                                                <asp:label id="Label6" runat="server" >Interest on Maintenance Charge upto <%= DateTime.Now.ToString("dd/MM/yyyy") %> :</asp:label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 txtRed">
                                                <asp:Label ID="lblInterest" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row maintenacecharge">
                                            <div class="col-md-offset-3 col-md-5 col-lg-5 col-sm-6 text-right">
                                                <asp:Label ID="Label8" runat="server" Text="Total Dues :"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 txtRed">
                                                <asp:Label ID="lblTotalDues" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row maintenacecharge">
                                            <div class="col-md-offset-3 col-md-5 col-lg-5 col-sm-6 text-right">
                                                <asp:Label ID="Label10" runat="server" Text="50% waiver in interest under OTS Scheme :"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 txtgreen">
                                                <asp:Label ID="lblRebate" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row maintenacecharge">
                                            <div class="col-md-offset-3 col-md-5 col-lg-5 col-sm-6 text-right" style="font-weight: 600">
                                                <asp:Label ID="Label12" runat="server" Text="PAYABLE AMOUNT :"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2">
                                                <asp:Label ID="lblPayAmount" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="TnC" >
                                        <div style="padding-bottom: 20px; padding-top: 20px; margin-left: 190px;">

                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckedChanged" />
                                            <asp:Label ID="Label5" runat="server">
                                                Click here to indicate that you have read and agree to the 
                                            </asp:Label>
                                            <asp:HyperLink ID="HyperLink1" href="images/tNc.jpg" target="_blank" runat="server"><u style="font-size:18px;font-weight:600;">Terms and Conditions</u></asp:HyperLink>

                                        </div>
                                        <div style="text-align: center; padding-top: 10px; padding-bottom: 10px">
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Proceed" OnClick="Click_Proceed" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="payPanel" runat="server">
                                        <div class="col-md-offset-3 col-md-5">
                                            <div class="row" style="padding-top: 10px">
                                                <div class="form-check">
                                                    <asp:RadioButton ID="RadioOneTime" runat="server" class="form-check-input"
                                                        GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                        AutoPostBack="true" />&nbsp;
                                                        <label class="" for="option1">One Time Payment</label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-check">
                                                    <asp:RadioButton ID="RadioInstallment" runat="server" class="form-check-input"
                                                        GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                        AutoPostBack="true" />&nbsp;
                                                <label class="" for="option2">Pay 25% Dues Now + 3 Equal Monthly Installments</label>
                                                </div>
                                            </div>
                                            <asp:Panel ID="panel1" runat="server">
                                                <div class="row" style="margin-top: 20px; font-weight: 600; font-size: 15px;">
                                                    <div class="col-md-8" style="margin-left: inherit; font-size: 17px; font-weight: 600">
                                                        Total Amount To Be Paid Now
                                                    </div>
                                                    <div class="col-md-4 xyz">
                                                        <asp:Label ID="lblInst" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="panelOneTime" runat="server">
                                                <div class="row" style="margin-top: 20px; font-weight: 600; font-size: 15px;">
                                                    <div class="col-md-8" style="margin-left: inherit; font-size: 17px; font-weight: 600">
                                                        Total Amount To Be Paid Now
                                                    </div>
                                                    <div class="col-md-4 xyz">
                                                        <asp:Label ID="lblTobePaid" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                        </div>
                                        <asp:Panel ID="installPanel" runat="server">
                                            <div class="col-md-4 abc">
                                                <div class="row" style="font-weight: 500; font-size: 13px; margin-top: 7px; margin-bottom: 7px">
                                                    <div class="col-md-7">
                                                        Tentative Installment Date<span style="color: Red">*</span>
                                                    </div>
                                                    <div class="col-md-5 xyz">
                                                        Amount(In Rs.)
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                       <asp:Label ID="lblInsDate1" runat="server"><%=DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy") %></asp:Label>
                                                    </div>
                                                    <div class="col-md-6 xyz">
                                                        <asp:Label ID="lblIns1" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lblInsDate2" runat="server"><%=DateTime.Now.AddMonths(2).ToString("dd/MM/yyyy") %></asp:Label>
                                                    </div>
                                                    <div class="col-md-6 xyz">
                                                        <asp:Label ID="lblIns2" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lblInsDate3" runat="server"><%=DateTime.Now.AddMonths(3).ToString("dd/MM/yyyy") %></asp:Label>
                                                    </div>
                                                    <div class="col-md-6 xyz">
                                                        <asp:Label ID="lblIns3" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div style="padding-top: 10px; text-align: center">
                                                    <span style="color: Red">*</span>
                                                    <small>Installment Date is calculated from the date, Payable Amount is received by UPSIDA.
                                                    </small>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </asp:Panel>
                                    </div>
                                        <%--Test--%>
                                        <asp:Panel ID="PanelPayMode" runat="server">
                                            <div style="text-align: center; font-size: 16px; font-weight: 600; padding-top: 10px">Please choose Payment Mode</div>
                                            <div class="col-md-offset-3 col-md-8 col-lg-8">
                                                <%--<div class="radioClass" style="text-align: center; padding-top: 30px; padding-bottom: 6vh;"></div>--%>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="form-check">
                                                        <asp:RadioButton ID="RadioOnline" runat="server" class="form-check-input"
                                                            GroupName="paymentMode" OnCheckedChanged="RadioButton_CheckedPayMD"
                                                            AutoPostBack="true" />&nbsp;
                                                        <label class="" for="opt1"><span style="font-size: 14px; font-weight: 600">Online</span> - Payment through Nivesh Mitra- only Netbanking, Debit and Credit Card (No NEFT/ RTGS available) </label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-check">
                                                        <asp:RadioButton ID="RadioOffline" runat="server" class="form-check-input"
                                                            GroupName="paymentMode" OnCheckedChanged="RadioButton_CheckedPayMD" AutoPostBack="true" />&nbsp;
                                                <label class="" for="opt2"><span style="font-size: 14px; font-weight: 600">Offline</span> - Demand Draft or Challan to be submitted in RM office</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:panel ID="PanelUTR" runat="server">
                                            <div class="col-md-offset-3 col-md-8 col-lg-8">

                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-3">
                                                        <%--<asp:Label ID="Label13" runat="server"><span style="color:red;">*</span>Upload receipt of transaction along with UTR No, Bank name and Transaction Date in PDF format.</asp:Label>--%>
                                                        <asp:Label ID="lblUTR" runat="server"><span style="color:red;">*</span>Enter UTR No : </asp:Label>
                                                    </div>
                                                    <div class="col-md-3 col-lg-3" >
                                                       <%-- <asp:FileUpload ID="FileUpload2" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="height: 31px;padding-bottom:24px"/>
                                                        <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="FileUpload2" runat="server" Display="Dynamic" ForeColor="Red" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                                            ControlToValidate="FileUpload2" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File."
                                                            Display="Dynamic" />--%>
                                                    <asp:TextBox ID="txtUTR" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtUTR" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtUTR" 
                                                        ID="RegularExpressionValidator1" ValidationExpression = "^[0-9][0-9]*$" runat="server" 
                                                        ErrorMessage="Enter only numbers." ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </div>
                                                </div>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-3">
                                                        <asp:Label ID="lblBankName" runat="server"><span style="color:red;">*</span>Enter Bank name : </asp:Label>
                                                    </div>
                                                    <div class="col-md-3 col-lg-3" >
                                                    <asp:TextBox ID="txtBankName" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtBankName" runat="server" Display="Dynamic" ForeColor="Red" />
                                                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtBankName" 
                                                        ID="RegularExpressionValidator2" ValidationExpression="^[a-zA-Z ]+$" runat="server"
                                                        ErrorMessage="Enter only character." ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </div>
                                                </div>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-3">
                                                        <asp:Label ID="Label14" runat="server"><span style="color:red;">*</span>Enter Transaction Date : </asp:Label>
                                                    </div>
                                                    <div class="col-md-3 col-lg-3">
                                                    <asp:TextBox ID="txtDate" TextMode="Date" runat="server" Class="chosen input-sm similar-select1 margin-left-z"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ErrorMessage="please select a date!" ControlToValidate="txtDate" runat="server" Display="Dynamic" ForeColor="Red" />
                                                </div>
                                                    </div>
                                            </div>
                                        </asp:panel>
                                       <div style="text-align:center;margin-top:20px">
                                        <%--<asp:Button ID="btnpay" CssClass="btn btn-info" runat="server" Text="Continue to Nivesh Mitra to Complete Payment" OnClick="Apply_Click" />--%>
                                        </div>
                                        <div class="row">
                                       <div style="text-align:center;margin-top:20px">
                                        <%--<asp:Button ID="btnOffline" CssClass="btn btn-info" runat="server" Text="Apply for Offline Payment" OnClick="Apply_OfflineClick" />--%>
                                        </div>
                                        </div>
                                   
                                </asp:Panel >
                                <asp:Panel ID="PanelApplied" runat="server">
                                    <div class="row">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2"></div>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                                            <%--<div class="row">--%>
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label runat="server">Applied for OTS Scheme on : </asp:Label>
                                                    </div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                                        <asp:Label runat="server" ID="lblApplicationDate"> ApplicationDate </asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Button runat="server" CssClass="btn btn-sm btn-success" ID="btnviewStatus" OnClick="View_Status" Text="View Current Status & Pay" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label runat="server">Payment Type Selected : </asp:Label>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                                        <asp:Label runat="server" ID="lblpaymentType">Instalment-wise</asp:Label><asp:LinkButton runat="server" ID="linkEdit" Style="font-size: 16px; color: lightseagreen" class="fa fa-edit" OnClick="PaymentSchemeEdit_click" /><br />
                                                        <asp:Label runat="server" ID="lblConfirmation" Style="color: dodgerblue" Visible="false">Do you want to update payment type?</asp:Label>&nbsp;<br />
                                                        <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OptionSelect_click" RepeatDirection="Horizontal" Visible="false">
                                                <asp:ListItem>Yes&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>--%>
                                                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" OnCheckedChanged="OptionSelect_click" GroupName="Option" AutoPostBack="true" Visible="false" />
                                                        <asp:RadioButton ID="RadioButton2" runat="server" Text="No" OnCheckedChanged="OptionSelect_click" GroupName="Option" AutoPostBack="true" Visible="false" />
                                                        <asp:Button runat="server" ID="btnschemeChange" Text="OK" OnClick="PaymentSchemeChange_click" Visible="false" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label runat="server">Total Dues : </asp:Label>
                                                    </div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                                        <asp:Label runat="server" ID="lblDues"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label runat="server">50% Waiver in interest under OTS Scheme : </asp:Label>
                                                    </div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                                        <asp:Label runat="server" ID="lblWvr"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label runat="server" ID="lbl1">Payable Amount as on (date of Application) : </asp:Label>
                                                    </div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                                        <asp:Label runat="server" ID="lblpayableamnt"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        <%--</div>--%>
                                    </div>
                                </asp:Panel>
                              <asp:Panel runat="server" ID="panelTable">
                                  <div class="row">
                                      <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2"></div>
                                      <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                                           <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <asp:Label runat="server">25% Upfront to be paid before 20-02-2022 :</asp:Label>
                                        </div>
                                         <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                                            <asp:Label runat="server" ID="lbl25"></asp:Label>
                                        </div>
                                         </div>
                                      </div>
                                  </div>
                                    
                                        <div class="container " >
                                            <table class="table table-responsive table-hover table-myspacing-z" id="Table1" runat="server" style="margin-bottom:15px;margin-top:15px">
                                                <thead>
                                                    <tr>
                                                        <td>Instalment date</td>
                                                        <td>Amount (in Rs.)</td>
                                                        <td>Status</td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="intlDate1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="instl1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="status1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="intlDate2"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="instl2"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="status2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label runat="server" ID="intlDate3"></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="instl3"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="status3"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    <label><b>Instructions : </b></label>
                                  <span>Please pay the dues on Nivesh Mitra before 20<sup>th</sup> Feb 2022 to avail the benefit of OTS scheme.</sup></span>

                                </asp:Panel>
                                
                                </div>
                              </asp:Panel>
                                
                               </div>
                        <asp:Panel runat="server" ID="lbllauchedmsg" Style="text-align:center;padding-top:5vh;" Visible="false"> 
                            <asp:Label runat="server" Style ="font-size:26px;font-family:'Times New Roman';color:darkblue" >
                                Please login from NIVESH MITRA to avail the benefit of the OTS Scheme.
                            </asp:Label>
                        </asp:Panel>   
                         </div>
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
       
        

       <script type="text/javascript" lang="javascript">
           $(document).ready(function () {
               debugger
               $('#<%=txtsearch.ClientID%>').autocomplete(
                   {
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/GetAutoCompleteData") %>',
                        data: "{" +
                        "'txtSearch':'" + request.term + "'," +
                        "'IAName':'" + $('#<%= drpIndusrialArea.ClientID %>').val() + "'" +
                      
                        "}",
                        dataType: "json",
                        //async:false,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                //    select: function (e, i) {
                //    $("[id$=hfCustomerId]").val(i.item.val);
                //},
                minLength: 1
            });
        });
        $("input[type=text]").keyup(function () {
            $("#gridView").hide();
            $("#warningmsg").hide();
        });
    </script>
          
       
        <script type="text/javascript">
            
            let timerOn = true;

            function timer(remaining) {
                
                var m = Math.floor(remaining / 60);
                var s = remaining % 60;

                m = m < 10 ? '0' + m : m;
                s = s < 10 ? '0' + s : s;
                document.getElementById('timer').innerHTML = m + ':' + s;
                remaining -= 1;

                if (remaining >= 0 && timerOn) {
                    $("#btnfind").hide();
                    setTimeout(function () {
                        timer(remaining);
                    }, 1000);
                    return;
                }

                if (!timerOn) {
                    // Do validate stuff here
                    return;
                }
                $("#DivOTP").hide();
                $("#btnfind").show();
                // Do timeout stuff here
                alert('Timeout for OTP');
            }

            timer(20);
        </script>
        <script type="text/javascript">
            showSwal = function (type) {
                'use strict';
                if (type != null || type!='') {
                    swal({
                        title: 'Submitted!',
                        text: 'Your Complaint Id is "' + type + '"  - You will receive an acknowledgement on your registered Email ID.',
                        type: 'success',
                        button: {
                            text: "Continue",
                            value: true,
                            visible: true,
                            className: "btn btn-primary"
                        }
                    })

                } else {
                    swal("Error occured !");
                }
            }
        </script>
           
   </form>
</body>
</html>
 
