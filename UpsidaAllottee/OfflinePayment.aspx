<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfflinePayment.aspx.cs" Inherits="UpsidaAllottee.OfflinePayment" %>

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
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
               <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
             <asp:PostBackTrigger ControlID="btnfind" />
         
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
                                <div class="row">
            <div class="navbar-header pull-left top-head-bg">
                <a href="Default.aspx" class="navbar-brand" style="width: 100%;">
                    <div class="col-md-8">
                        <img class="img-responsive" src="images/upsida-logo-name.png" />
                    </div>
                    <div class="col-md-4" style="margin-top: 2px;">
                        <img class="img-responsive" src="images/image4.png" />
                    </div>
                </a>
            </div>
        </div>
                            <%--<div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
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
                                </div>
                            </div>--%>
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
                                    <%--<asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color: #02486d; color: #fff; font-weight: 600;" OnClick="btn_backNmswp_Click" />--%>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                                <div class="row" runat="server" id="SideDiv" style="padding-left: 30px; padding-right: 30px; padding-top: 30px; padding-bottom: 30px; margin-top: 0px;">
                                    <div style="text-align: center; padding-bottom: 3vh; font-size: 16px; font-weight: 600">
                                        <asp:Label runat="server">OTS Scheme - Offline Payment Details Data Entry</asp:Label>
                                    </div>
                                    <div class="form-group" style="padding-bottom:10vh">

                                        <label class="col-md-3 col-sm-6 text-right">
                                            <span style="color:red;">*</span>Enter Nivesh Mitra UnitID of Allottee:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:TextBox runat="server" ID="txtUnitID" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ErrorMessage="Please enter UnitID" ControlToValidate="txtUnitID" runat="server" Display="Dynamic" ForeColor="Red" />
                                        </div>


                                        <label class="col-md-3 col-sm-6 text-right">
                                            <span style="color:red;">*</span>Enter Nivesh Mitra RequestID of Allottee:
                                        </label>
                                        <div class="col-md-2 col-sm-6">
                                            <asp:TextBox runat="server" ID="txtReqID" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ErrorMessage="Please enter RequestID" ControlToValidate="txtReqID" runat="server" Display="Dynamic" ForeColor="Red" />
                                        </div>
                                       <%-- <div>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>--%>
                                        <div class="col-md-2 col-sm-10">
                                            <asp:Button runat="server" ID="btnfind" Text="OK" CssClass="btn-group-lg alert-success" onClick="Click_OK"/>
                                        </div>
                                    </div>

                                    <asp:Panel runat="server"  ID="Panel1">
                                        <div class="row" style="text-align:center">
                                            <div class="col-md-12 col-lg-12">Maintenance Dues under OTS Scheme Paid By DD though Challan</div>
                                            <%--<div class="col-md-6">
                                                <div class="radioClass" >
                                                <div class="form-check">
                                                    <asp:RadioButton ID="RadioDD" runat="server" class="form-check-input" GroupName="paymentScheme"/>&nbsp;
                                                        <label class="" for="option1">Demand Draft</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="RadioChallan" runat="server" class="form-check-input" GroupName="paymentScheme" />&nbsp;
                                                         <label class="" for="option2">Challan</label>
                                                </div>
                                                </div>padding-top:8px;height:40px
                                            </div>--%>
                                        </div>
                                        <asp:Panel ID="Panel5" runat="server">
                                        <div class="row" style="margin-top:10px;" >
                                            
                                            <div class="col-md-offset-2 col-md-2">
                                                Payment Type :
                                            </div>
                                            <div class="col-md-2">
                                                <asp:label runat="server" ID="lblPaymentType"></asp:label>
                                            </div>
                                            <%--<div class="col-md-2"><span style="color:red;">*</span>Select Payment :</div>
                                            <div class="col-md-2">--%>
                                                <%--<asp:dropdownlist runat="server" id="ddlInst" CssClass="chosen input-sm similar-select1 margin-left-z form-control" ValidationGroup="g1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> 
                                                    <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Down Payment" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-1" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-2" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-3" Value="4"></asp:ListItem>
                                                </asp:dropdownlist>
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID"  ValidationGroup="g1" runat="server" ControlToValidate="ddlInst"
                                                 ErrorMessage="Please select Payment"></asp:RequiredFieldValidator>

                                                <asp:DropDownList runat="server" ID="drpPay" CssClass="chosen input-sm similar-select1 margin-left-z form-control" ValidationGroup="g2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Down Payment" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Balance Amount" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID1"  ValidationGroup="g2" runat="server" ControlToValidate="drpPay"
                                                 ErrorMessage="Please select Payment"></asp:RequiredFieldValidator>--%>
                                            <%--</div>--%>
                                        </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel3" runat="server" style="margin-top:2px;background-color:azure;padding-top:10px;padding-bottom:4px">
                                            <div class="row" >
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Select Payment :</div>
                                            <div class="col-md-2" >
                                                <asp:dropdownlist runat="server" id="ddlInst" CssClass="chosen input-sm similar-select1 margin-left-z form-control"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> 
                                                    <asp:ListItem Text="--Select Payment--" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Down Payment" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-1" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-2" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Instalment-3" Value="4"></asp:ListItem>
                                                </asp:dropdownlist>
                                                <%--<asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1"  ValidationGroup="g1" runat="server" ControlToValidate="ddlInst"
                                                 ErrorMessage="Please select Payment"></asp:RequiredFieldValidator>--%>

                                                <asp:DropDownList runat="server" ID="drpPay" CssClass="chosen input-sm similar-select1 margin-left-z form-control" ValidationGroup="g2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select Payment--" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Down Payment" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Balance Amount" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2"  ValidationGroup="g2" runat="server" ControlToValidate="drpPay"
                                                 ErrorMessage="Please select Payment"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="row" >
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Date of Receipt as per bank (seal with data) :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtRecDate" TextMode="Date" runat="server"  Class="chosen input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="please select a date!" ControlToValidate="txtRecDate" runat="server" Display="Dynamic" ForeColor="Red" />
                                                </div>
                                        </div>
                                        <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Amount Paid (In Rs) :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" ID="txtAmountPaid" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtAmountPaid" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtAmountPaid" CssClass=" chosen input-sm similar-select1 margin-left-z" 
                                                        ID="RegularExpressionValidator3" ValidationExpression = "^[1-9][0-9]*$" runat="server" 
                                                        ErrorMessage="Incorrect Amount" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>DD No :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" ID="txtChallanNo" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtChallanNo" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtChallanNo" CssClass=" chosen input-sm similar-select1 margin-left-z" 
                                                        ID="RegularExpressionValidator1" ValidationExpression = "^[0-9][0-9]*$" runat="server" 
                                                        ErrorMessage="Enter only numbers." ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>DD Date :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtDDate" TextMode="Date" runat="server"  Class="chosen input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="please select a date!" ControlToValidate="txtDDate" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <%--<asp:TextBox runat="server" ID="txtDate" OnTextChanged="OnDateChange" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Name of Bank :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" ID="txtBankName" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtBankName" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtBankName" CssClass=" chosen input-sm similar-select1 margin-left-z" 
                                                        ID="RegularExpressionValidator2" ValidationExpression = "^[a-zA-Z ]+$" runat="server" 
                                                        ErrorMessage="Enter only character." ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:10px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Upload Challan/DD Copy :</div>
                                            <div class="col-md-2">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px" />
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="FileUpload1" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                                    ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File."
                                                    Display="Dynamic" />
                                                <%--<asp:FileUpload ID="FileUpload11" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px" />--%>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Upload NoteSheet Copy :</div>
                                            <div class="col-md-2">
                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px" />
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="FileUpload2" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                                    ControlToValidate="FileUpload2" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File."
                                                    Display="Dynamic" />
                                                <%--<asp:FileUpload ID="FileUpload12" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px" />--%>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:20px">
                                            <div class="col-md-offset-2 col-md-10">
                                                <asp:CheckBox ID="CheckBox1" runat="server"  />
                                            <asp:Label ID="Label5" runat="server">&nbsp;&nbsp;
                                                Payment deposited by the allottee against the dues of OTS is subject to realisation. 
                                            </asp:Label>
                                            </div>
                                        </div>
                                            <div style="text-align:center;margin-top:30px;margin-bottom:30px">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btn_Click" CssClass="btn-group-lg alert-success" />
                                            <%--<asp:Button ID="Button2" runat="server" Text="Submit" OnClick="btn_RealisedClick" CssClass="btn-group-lg alert-success" />--%>
                                        </div>
                                            </asp:Panel>
                                        
                                        <asp:Panel ID="Panel4" runat="server" Style="margin-top:30px">
                                            <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Payment Realised :</div>
                                            <div class="col-md-4">
                                                <div class="radioClass" >
                                                <div class="form-check">
                                                    <asp:RadioButton ID="RadioYes" runat="server" class="form-check-input" GroupName="paymentScheme" AutoPostBack="true" OnCheckedChanged="Click_Radio"/>&nbsp;
                                                        <label class="" for="option1">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="RadioNo" runat="server" class="form-check-input" GroupName="paymentScheme" AutoPostBack="true" OnCheckedChanged="Click_Radio"/>&nbsp;
                                                         <label class="" for="option2">No</label>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                            <div class="row" style="margin-top:2px">
                                            <div class="col-md-offset-2 col-md-3"><span style="color:red;">*</span>Enter Date of Realisation in Bank :</div>
                                            <div class="col-md-2">
                                                <asp:TextBox TextMode="Date" ID="txtRelDate" runat="server"  Class="chosen input-sm similar-select1 margin-left-z" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="please select a date!" ControlToValidate="txtRelDate" runat="server" Display="Dynamic" ForeColor="Red" />
                                                <%--<asp:TextBox runat="server" ID="txtDate" OnTextChanged="OnDateChange" CssClass="autosuggest chosen input-sm similar-select1 margin-left-z form-control"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                            <div style="text-align:center;margin-top:30px;margin-bottom:30px">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btn_Click" CssClass="btn-group-lg alert-success" />--%>
                                            <asp:Button ID="btnRel" runat="server" Text="Submit" OnClick="btn_RealisedClick" CssClass="btn-group-lg alert-success" />
                                        </div>
                                        </asp:Panel>
                                        
                                    </asp:Panel>
                                    
                                </div>
                            </asp:Panel>
                        </div> 
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btnSubmit" />--%>
            </Triggers>
        </asp:UpdatePanel>
        <script>
function setUploadButtonState() {

    var maxFileSize = 4*1024*1024; // 4MB -> 4 * 1024 * 1024
   var fileUpload = $('#FileUpload1');
   var fileUpload1 = $('#FileUpload2');
   if (fileUpload.val() == '') {
    return false;
   }
   else {
      if (fileUpload[0].files[0].size < maxFileSize) {
          $('#btnSubmit').prop('disabled', false);
          $('#lbl_uploadMessage').text()='';
         return true;
      }else{
         $('#lbl_uploadMessage').text('File is too big !')
         return false;
      }
   }
   if (fileUpload1.val() == '') {
       return false;
   }
   else {
       if (fileUpload1[0].files[0].size < maxFileSize) {
           $('#btnSubmit').prop('disabled', false);
           $('#lbl_uploadMessage1').hide();
           return true;
       } else {
           $('#lbl_uploadMessage1').text('File is too big !')
           return false;
       }
   }
}
            </script>
      <%-- <script type="text/javascript" lang="javascript">
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
        </script>--%>
           
   </form>
</body>
</html>
 

