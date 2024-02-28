<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTSGrievances.aspx.cs" Inherits="UpsidaAllottee.OTSGrievances" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Uttar Pradesh Industrial Development Authority</title>
   <link rel="icon" href="images\upsidclogo.png" />

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <style>
        .navbar-inverse .navbar-nav > .active > a, .navbar-inverse .navbar-nav > .active > a:focus, .navbar-inverse .navbar-nav > .active > a:hover {
    color: #efefef;
    background-color: #08080861!important;
}
        .mainnavbar {
            height: 38px !important;
        }
        .navbar-nav .dropdown {
    padding: 0px 10px;
    border-radius: 13px 13px 2px 14px;
    background: #08080861;
}
        /*.panel-default{
            padding-left:10px;
            padding-right:10px;
        }*/
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
                top: 10%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }
             hr{
            margin-top:10px !important;
        }
    </style>


</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                                <span style="font-size: 25px; font-weight: bold;">Please Wait...</span><br />
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
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
                            .the-legend {
                                border-style: none;
                                border-width: 0;
                                font-size: 14px;
                                line-height: 20px;
                                margin-bottom: 0;
                            }

                            .the-fieldset {
                                border: 2px groove threedface #444;
                                -webkit-box-shadow: 0px 0px 0px 0px #000;
                                box-shadow: 0px 0px 0px 0px #000;
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

                <%--<div class="panel panel-default">--%>
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
                <div class="clearfix"></div>
                <nav class="navbar navbar-inverse navbar-dark bg-dark" style="background-color:#006699;">
                    <div class="container-fluid">


                        <ul class="nav navbar-nav nav-tabs" role="tablist">

                            <li role="presentation"><a href="/OTSGrievancesMIS.aspx">
                                <asp:Button ID="Button1" CssClass="btn btn-warning btn-sm" runat="server" Style="padding: initial" Text="&#8678;Back" OnClick="btn_Back" /></a></li>
                            <li role="presentation" class="active"><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <span style="position: relative; top: 3px;"><b>Welcome </b>
                                        <asp:Label ID="lblname" runat="server"></asp:Label></span>
                                    <i class="fa fa-caret-down"></i>
                                </a>
                                <ul class="dropdown-menu">
                                    <li><a href="./">My Account</a></li>
                                    <li class="divider"></li>
                                    <li><a tabindex="-1" href="/Default.aspx?logout=true">Logout</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <!--/.container-fluid -->
                </nav>

                <div class="row" id="SideDiv" style="padding-top: 30px; padding-bottom: 30px; margin-top: 0px;">

                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 10px; font-size: 16px">
                        <div style="background: #ececec; margin-top: 0px; padding: 10px 0;">

                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
                                    <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="label1" runat="server" Text="Regional Office :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblregion" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label2" runat="server" Text="Industrial Area :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblIA" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label3" runat="server" Text="Plot Number :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="LblPlot" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label7" runat="server" Text="Allottee Name :"></asp:Label>
                                        </div>
                                       <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblAllotteeName" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="lbl" runat="server" Text="Complaint ID :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblComplaint" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                     <div class="row maintenacecharge">
                                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                            <asp:Label ID="Label13" runat="server" Text="Complaint :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                            <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <hr />
                                    <asp:Panel ID="PanelHideForAdmin" runat="server">
                                        <div class="row maintenacecharge" runat="server" id="OptionRadio" visible="false">
                                            <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                                <asp:Label ID="lblGrievanceIssue" runat="server" Text="Please confirm, Maintenance Charge is applicable  ?"></asp:Label>
                                            </div>
                                            <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                                <div class="row">
                                                    <div class="form-check" style="font-size: 14px">
                                                        <asp:RadioButton ID="RadioOneTime" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                            GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:Label runat="server" class="" ID="lblYes" for="option1">Yes</asp:Label>&nbsp;&nbsp;
                                                    
                                                        <asp:RadioButton ID="RadioButton1" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                            GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:Label runat="server" class="" ID="lblNo" for="option1">No</asp:Label>&nbsp;&nbsp;
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row maintenacecharge" runat="server" id="OptionCourt" visible="false">
                                            <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                                <asp:Label ID="Label11" runat="server" ><span style="color:red">*</span>Please confirm ?</asp:Label>
                                            </div>
                                            <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                                <div class="row">
                                                    <div class="form-check" style="font-size: 14px">
                                                        <asp:RadioButtonList id="RadioButtonList1" runat="server" CssClass="form-check-input chosen input-sm margin-left-z">
                                                            <asp:ListItem value="Document Unclear">Document Unclear</asp:ListItem>
                                                            <asp:ListItem value="Document Not Relevant">Document Not Relevant</asp:ListItem>
                                                            <asp:ListItem value="Disputed">Disputed</asp:ListItem>
                                                            <asp:ListItem value="Maintenance Charge Not Applicable">Maintenance Charge Not Applicable</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                       <%-- <asp:RadioButton ID="rd1" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                            GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:Label runat="server" class="" ID="Label14" for="option1">Disputed</asp:Label>&nbsp;&nbsp;

                                                 <asp:RadioButton ID="rd2" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                     GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                     AutoPostBack="true" />
                                                        <asp:Label runat="server" ID="lblDocUnclear">Document Unclear</asp:Label>&nbsp;&nbsp;

                                                        <asp:RadioButton ID="rd3" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                            GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:Label runat="server" class="" ID="lblDocUnRelevent" for="option1">Document Not Relevant</asp:Label>&nbsp;&nbsp;

                                                        <asp:RadioButton ID="rd4" runat="server" CssClass="form-check-input chosen input-sm margin-left-z"
                                                            GroupName="paymentScheme" OnCheckedChanged="RadioButton_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:Label runat="server" class="" ID="lblOnHold" for="option1">Maintenance Charge Not Applicable</asp:Label>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <asp:Panel ID="MaintenanceInstruction" runat="server" Visible="false">
                                            <div class="row maintenacecharge">
                                                <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                                    <asp:Label ID="Label17" runat="server" Text="Instruction for RM :"></asp:Label>
                                                </div>
                                                <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                                    <asp:Label CssClass="chosen margin-left-z" ID="lblCharge" runat="server">
                                                Please update maintenance charge, outstanding interest and interest rate.
                                                    </asp:Label>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="NotApplicable" runat="server" Visible="false">
                                            <div class="row maintenacecharge">
                                                <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                                    <asp:Label ID="Label5" runat="server" Text="Instruction :"></asp:Label>
                                                </div>
                                                <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                                    <asp:Label CssClass="chosen   margin-left-z" ID="Label9" runat="server">
                                                Please update maintenance charge, outstanding interest and interest rate.
                                                    </asp:Label>
                                                </div>
                                            </div>  
                                        </asp:Panel>

                                        <div class="row maintenacecharge">
                                            <div class="col-md-4 col-lg-4 col-sm-6 col-xs-6 text-right">
                                                <asp:Label ID="Label18" runat="server" ><span style="color:red;">*</span>Enter Comment :</asp:Label>
                                            </div>
                                            <div class="col-md-8 col-lg-8 col-sm-6 col-xs-6">
                                                <asp:TextBox CssClass="chosen input-sm similar-select1 margin-left-z" ID="txtComment" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtComment" CssClass=" chosen input-sm similar-select1 margin-left-z" 
                                                        ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{20,1000}$" runat="server" 
                                                        ErrorMessage="Minimum 20 and Maximum 1000 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <asp:Panel runat="server" ID="fLoad" class="row maintenacecharge" >
                                           <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4 text-right" >
                                               <asp:Label ID="Label15" runat="server" ><span style="color:red;">*</span>Attach Relevant Document :</asp:Label>
                                           </div>
                                           <div class="col-md-8 col-lg-8 col-sm-6 col-xs-4" style="padding-bottom:10px;height: 29px !important;">
                                               <asp:FileUpload ID="FileUpload2" runat="server" CssClass=" chosen input-sm similar-select1 margin-left-z" style="padding-bottom:24px"/>
                                           </div>
                                            </asp:Panel>
                                        <div class="row">
                                            <div style="text-align: center; margin-top: 20px">
                                                <asp:Button ID="btnclick" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btn_Click" />
                                            </div>
                                        </div>

                                        </asp:Panel>
                                
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
                                    <div class="row maintenacecharge">
                                        <div class=" col-md-8 col-lg-8 col-sm-8 text-right">
                                            <asp:Label ID="label4" runat="server" Text="Maintenance Charge Due upto 30-06-2021 :"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4 col-sm-4 txtRed">
                                            <%--<asp:TextBox ID="txtcharge" runat="server" Enabled="false" Text="Rs 100000 /-"></asp:TextBox>--%>
                                            <asp:Label ID="lblMaintenanceCharge" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class=" col-md-8 col-lg-8 col-sm-8 text-right">
                                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4 col-sm-4 txtRed">
                                            <%--<asp:TextBox ID="txtInterest" runat="server" Enabled="false" Text="Rs 50000.04 /-"></asp:TextBox>--%>
                                            <asp:Label ID="lblInterest" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-8 col-lg-8 col-sm-8 text-right">
                                            <asp:Label ID="Label8" runat="server" Text="Total Dues :"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4 col-sm-4 txtRed">
                                            <%--<asp:TextBox ID="txtTotalDues" runat="server" Enabled="false" Text="Rs 150000.04 /-"></asp:TextBox>--%>
                                            <asp:Label ID="lblTotalDues" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-8 col-lg-8 col-sm-8 text-right">
                                            <asp:Label ID="Label10" runat="server" Text="50% waiver in interest under OTS Scheme :"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4 col-sm-4 txtgreen">
                                            <%--<asp:TextBox ID="txtRebate" runat="server" Enabled="false" Text="Rs 25000.02 /-"></asp:TextBox>--%>
                                            <asp:Label ID="lblRebate" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row maintenacecharge">
                                        <div class="col-md-8 col-lg-8 col-sm-8 text-right" style="font-weight: 600">
                                            <asp:Label ID="Label12" runat="server" Text="PAYABLE AMOUNT :"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4 col-sm-4">
                                            <%--<asp:TextBox ID="txtPayAmount" runat="server" Enabled="false" Text="Rs 125000.02 /-"></asp:TextBox>--%>
                                            <asp:Label ID="lblPayAmount" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                     <div class="row maintenacecharge" style="padding-left:2em;padding-top:1em">
                                    <legend Class="chosen input-md margin-left-z" style="font-size:14px">Complaint Description : </legend>
                                    <fieldset class="well the-fieldset" style="margin-bottom:20px">
                                        <legend class="the-legend"></legend>
                                        <asp:Label runat="server" ID="lblAllotteeComment" CssClass="chosen input-sm similar-select1 margin-left-z" >... your inputs ...</asp:Label>
                                    </fieldset>
                                         <asp:Panel runat="server" ID="RM">
                                             <legend Class="chosen input-md margin-left-z" style="font-size:14px">RM Comment : </legend>
                                        <fieldset class="well the-fieldset">
                                        <legend class="the-legend"></legend>
                                        <asp:Label runat="server" ID="lblRMComment" CssClass="chosen input-sm similar-select1 margin-left-z" >... your inputs ...</asp:Label>
                                    </fieldset>
                                         </asp:Panel>
                                    
                                </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
                                   </div>
                                <div class="col-md-6 col-lg-offset-1 col-lg-5 col-sm-12 col-xs-12">
                                    
                                        
                                </div>
                            </div>
                            <div style="margin-bottom: 10px; padding-top: 30px;margin-left:20px">
                                <span style="color: Red">**</span><small>Disclaimer : Interest on Maintenance Charge is auto-generated as per data fed in the system.</small><br />
                                <small style="padding-left: 80px;">: Queries regarding only the OTS scheme will be entertained.</small>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                        <%--</div>--%>
                    </div>
                                
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnclick" />
            </Triggers>
        </asp:UpdatePanel>

        <script>

            showSwal = function (type) {
                'use strict';
                if (type === 'Success') {
                    swal({
                        title: 'Submitted!',
                        type: 'success',
                        button: {
                            text: "Continue",
                            value: true,
                            visible: true,
                            className: "btn btn-primary"
                        }
                    },function () {
                        window.location.href = 'OTSGrievancesMIS.aspx';
                    })
                

                } else {
                    swal("Error occured !");
                }
            }


        </script>
    </form>
</body>
</html>
