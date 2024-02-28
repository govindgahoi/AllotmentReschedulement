<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAServicesApplication_Module.aspx.cs" Inherits="Allotment.IAServicesApplication_Module" %>

<%@ Register Src="~/ucAllotmentDeposits.ascx" TagPrefix="uc1" TagName="ucAllotmentDeposits" %>

<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="s" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>

    <%--<link href="css/bootstrap.min.css" rel="stylesheet" />
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
    <script src="js/chosen.jquery.min.js"></script>--%>

    <script type="text/javascript">




        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }


    </script>


    <script type="text/javascript">

        function FinalMsg(par) {
            alert("Form Submitted Successfully");
            window.location.href = 'IAServicesApplication_Module.aspx?ServiceReqNo=' + par;
        }
        function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted successfully");
            window.location.href = 'IAServicesApplication_Module.aspx?ServiceReqNo=' + par;
        }
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            var newLine = "\r\n"
            var message = "Dear Applicant"
            message += newLine;
            message += "Please Check All the Data Entered By You.Once Finalised Cannot Be Edited";
            if (confirm(message)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ShowMessage(msg) {
            alert(msg);

        }


        function ShowFinalMsg() {

            //var txt;
            //var r = confirm("Please Confirm Your Data Before Finalising. After Finalising Data Cannot Be Edited");
            //if (r == true) {
            $("#btnModal").click();
            // } 
        }

        function ShowFinalMsgUPSIDC() {

            //var txt;
            //var r = confirm("Please Confirm Your Data Before Finalising. After Finalising Data Cannot Be Edited");
            //if (r == true) {
            $("#btnModalUPSIDC").click();
            //   } 


        }


    </script>
    <style>
        .modal-open {
            overflow: auto !important;
        }

        .nav-pills {
            margin-left: 0 !important;
        }

            .nav-pills > li + li {
                margin-left: 0px !important;
            }

        .pad-lt0 {
            padding-left: 0 !important;
        }

        .pad-rt0 {
            padding-right: 0 !important;
        }

        @media only screen and (max-width: 768px) {
            .form-group label.text-right {
                text-align: left !important;
            }

            .form-group .col-sm-6 {
                width: 50% !important;
            }

            .right-niveshban {
                text-align: center;
            }

            .left-niveshban {
                text-align: center;
            }
        }

        @media only screen and (min-width: 768px) {
            .right-niveshban {
                text-align: right;
            }

            .left-niveshban {
                text-align: left;
            }
        }

        .form-group label {
            font-weight: 700 !important;
        }

        .modal-open {
            overflow: auto;
        }

        input[type=file] {
            margin: 0 !important;
            width: 207px;
        }

        .hide {
            display: none;
        }

        .show {
            display: block;
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
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }

        .MessagePennel {
            background-color: #f4e542;
            width: 100%;
        }

        .check-cross {
            color: #f70000;
            font-size: 18px;
            line-height: 0.7;
            font-weight: 100;
        }

        .nav-pills > li + li {
            margin-left: 0px;
        }

        .myul-tabs {
            margin-left: 0 !important;
        }

            .myul-tabs li {
                width: 100%;
                border-top: 1px solid #fff;
            }

                .myul-tabs li a:after {
                    display: none;
                }

                .myul-tabs li a:before {
                    display: none;
                }

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
                margin-top: 11%;
            }

            .pad-rt0 {
                padding-right: 0;
            }

            .pad-lt0 {
                padding-left: 0;
            }
        }

        .modal-header {
            padding: 2px !important;
        }

        .myreq-col tr td {
            font-size: 12px;
            color: #2d2d2d;
            border: 1px solid #fff !important;
            text-align: left;
            background: #e0e0e0;
            padding: 1px 6px !important;
            font-weight: bold;
        }

        .myreq-col tr th {
            font-size: 12px;
            background-color: #ffe600;
        }

        .myreq-col tr td a {
            color: #337ab7;
            font-weight: bold;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
            <Triggers>
            <asp:PostBackTrigger ControlID="btn_backNmswp" />       
            </Triggers>
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf">
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                            </div>
                        </div>
                    </ProgressTemplate>



                </asp:UpdateProgress>
                <cc1:MessageBox ID="MessageBox1" runat="server" />
                <div>
                    <div class="container">

                        <div class="row" id="SideDiv">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel panel-default">
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
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">

                                                <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>

                                            </div>

                                            <div class="clearfix"></div>
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
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">
                                        <asp:Label runat="server" ID="lblFormName"></asp:Label>
                                        </span></div>
                                    <div class="row">
                                        <div class="col-md-2">

                                            <style>
                                                #sub_menu ul {
                                                    margin-left: 0 !important;
                                                }
                                                 .myul-tabs > li .selected {
                                                        background:#c7b42a !important;
                                                    }
                                            </style>
                                             
                                                    
                                                   

                                            <asp:Menu
                                                ID="sub_menu"
                                                Orientation="Vertical"
                                                OnMenuItemClick="Menu1_MenuItemClick"
                                                StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                StaticSelectedStyle-CssClass="active selected highlighted"
                                                runat="server" Style="margin-left: 0; font: x-small">

                                                <Items>
                                                    <asp:MenuItem Text="<span style='color:red;font-weight:800;font-size:larger;'>Objections</span>" Value="10" />
                                                    <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                    <asp:MenuItem Text="Project Details" Value="1" />
                                                    <asp:MenuItem Text="Second Charge Details" Value="7" />
                                                    <asp:MenuItem Text="Joint Mortgage Details" Value="6" />
                                                    <asp:MenuItem Text="Noc Mortgage Details" Value="8" />
                                                    <asp:MenuItem Text="Transfer of lease deed" Value="9" />
                                                    <asp:MenuItem Text="Time extension fee" Value="11" />
                                                    <asp:MenuItem Text="Start of Production Certificate" Value="14" />
                                                    <asp:MenuItem Text="New Product Details" Value="5" />
                                                    <asp:MenuItem Text="Upload Document " Value="2" />
                                                    <asp:MenuItem Text="Make Payment" Value="3" />
                                                    <asp:MenuItem Text="Final Submission" Value="15" />
                                                    <asp:MenuItem Text="Final Form" Value="4" />


                                                </Items>

                                            </asp:Menu>
                                        </div>
                                        <div class="col-md-10" style="border-left: 1px solid #ccc;">

                                            <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                                                <label>
                                                    <span class="check-cross" runat="server">✖</span>

                                                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                </label>
                                            </div>

                                            <asp:MultiView runat="server" ID="Allotment">
                                                <asp:View runat="server" ID="View1">
                                                    <asp:PlaceHolder ID="PH_AllotteeDetails" runat="server"></asp:PlaceHolder>
                                                </asp:View>


                                                <asp:View runat="server" ID="View2">
                                                    <p class="panel-heading"><b>Applicant Project Details</b></p>
                                                    <p class="panel-heading font-bold">Type of industry to be set up</p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Type Of Industry :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">

                                                                <asp:DropDownList ID="ddlTypeOfIndustry" runat="server" CssClass="chosen margin-left-z input-sm similar-select1"></asp:DropDownList>


                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Proposed Product :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txttypeofindustry" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <p class="panel-heading font-bold">Project Costing Details</p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Estimated Cost of the project(In Lacs):
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr"></i>
                                                                <asp:TextBox ID="txtestimatedcost" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Estimated Cost of the project');"></asp:TextBox>
                                                            </div>
                                                            <div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>

                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Estimated Employment Generation(In Nos) :
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtestimatedemployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Estimated Employment Generation');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Estimated Project Start Period(In Months)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtProjectStartMonths" runat="server" CssClass="input-sm similar-select1" MaxLength="2" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Estimated Project Start Period(In Months)');"></asp:TextBox>
                                                            </div>
                                                            <div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>

                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Related Work Experience(In Years)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" MaxLength="4" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Related Work Experience(In Months)');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <p class="panel-heading font-bold">Layout plan of land</p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Covered Area&nbsp;(In %)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtcoveredarea" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Covered Area');"></asp:TextBox>
                                                            </div>
                                                            <div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>

                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Open Area &nbsp;(In %)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtopenarearequired" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Open Area');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <p class="panel-heading font-bold">Details of the investment(in Rs)</p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right" title="date ofsubmission">
                                                                <span style="color: Red">*</span>
                                                                Investment In Land&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr"></i>
                                                                <asp:TextBox ID="txtland" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Land');"></asp:TextBox>
                                                            </div>
                                                            <div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>

                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Investment In Building&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr"></i>
                                                                <asp:TextBox ID="txtbuilding" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Building');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Investment In Machinery & Equipments&nbsp;(In Lacs)&nbsp;:
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr"></i>
                                                                <asp:TextBox ID="txtmachinery" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Machinery & Equipments');"></asp:TextBox>
                                                            </div>
                                                            <div class="hidden-lg hidden-md">
                                                                <div class="clearfix"></div>
                                                            </div>

                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                Investment In Other Fixed Assets&nbsp;(In Lacs):
                                                            </label>
                                                            <div class="col-md-2 col-sm-6 col-xs-6">
                                                                <i class="fa fa-inr"></i>
                                                                <asp:TextBox ID="txtFixedAssets" MaxLength="5" CssClass="input-sm similar-select1" Width="93%" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    Investment In Other Expenses&nbsp;(In Lacs)&nbsp;:
                                                           
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <div style="float: left; width: 2%;"><i class="fa fa-inr"></i></div>
                                                                    <div style="float: left; width: 98%;">
                                                                        <asp:TextBox ID="txtOtherExpenses" MaxLength="5" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <p class="panel-heading">
                                                            Any fumes generated in the process of manufacture if so, their nature and quantity &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
                                                                <asp:CheckBox runat="server" ID="chkfumes" AutoPostBack="true" OnCheckedChanged="chkfumes_CheckedChanged" /></span>
                                                        </p>
                                                        <div id="fumesdiv" runat="server" visible="false">
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                        Nature&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtfumenature" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                        Quantity&nbsp;:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtfumeqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                        </div>

                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    Industrial category:
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList runat="server" ID="drpIACategory" CssClass="chosen margin-left-z input-sm similar-select1" OnSelectedIndexChanged="drpIACategory_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <div id="ETP" runat="server" visible="false">
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading font-bold">Industrial Effluents </div>
                                                                <div class="panel-body" style="padding: 0px !important;">

                                                                    <table class="table table-bordered table-hover request-table">
                                                                        <tr>
                                                                            <th>Name</th>
                                                                            <th>Quantity</th>
                                                                            <th>Chemical Composition</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><span class="pull-right">(i)&nbsp;Solid :</span></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentsolidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentsolidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 33.7%;"><span class="pull-right">(ii)&nbsp;Liquid :</span></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentliquidqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentliquidcomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><span class="pull-right">(iii)&nbsp;Gaseous :</span></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentgaseousqty" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txteffluentgaseouscomposition" CssClass="input-sm similar-select1" runat="server"></asp:TextBox></td>
                                                                        </tr>

                                                                    </table>

                                                                </div>
                                                            </div>



                                                            <div class="panel panel-default">

                                                                <div class="panel-body" style="padding: 0px !important;">



                                                                    <div class="form-group">
                                                                        <div class="row">
                                                                            <label class="col-md-4 col-sm-6 col-xs-12 text-right">
                                                                                Effluent Treatment Plant Required :
                                                                            </label>
                                                                            <div class="col-md-8 col-sm-6 col-xs-12 form-inline font-12px">
                                                                                <asp:DropDownList ID="drpreqETp" runat="server" CssClass="chosen margin-left-z input-sm similar-select1" OnSelectedIndexChanged="drpreqETp_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem>--select--</asp:ListItem>
                                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix"></div>

                                                                    <div id="MeasureDiv" class="form-group" runat="server" visible="false">
                                                                        <div class="row">
                                                                            <label class="col-md-4 col-sm-6 col-xs-12 text-right">
                                                                                Effluent Treatment Measures :
                                                                            </label>
                                                                            <div class="col-md-8 col-sm-6 col-xs-12 form-inline font-12px">
                                                                                <asp:TextBox ID="txteffluenttreatmentmeasure1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                                                                <hr class="myhrline" />
                                                                                <asp:TextBox ID="txteffluenttreatmentmeasure2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                                                                <hr class="myhrline" />
                                                                                <asp:TextBox ID="txteffluenttreatmentmeasure3" CssClass="input-sm similar-select1" runat="server"></asp:TextBox><br />
                                                                                <hr class="myhrline" />
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading font-bold">Power Requirement (in KW)</div>
                                                            <div class="panel-body" style="padding: 0px !important;">
                                                                <div class="row aks-row">
                                                                    <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                        <span style="color: Red">*</span>
                                                                        Units &nbsp;:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtpowerreq" CssClass="input-sm similar-select1" runat="server" onblur="ValidateRequired(this,'Power Requirement (in KW)');"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <p class="panel-heading font-bold">Other Relevant Information</p>
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Net Worth(In Lac):
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <div style="float: left; width: 2%;"><i class="fa fa-inr"></i></div>
                                                                    <div style="float: left; width: 98%;">
                                                                        <asp:TextBox ID="txtNetWorth" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Net Worth');"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Net Turn Over(In Lac):
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <div style="float: left; width: 2%;"><i class="fa fa-inr"></i></div>
                                                                    <div style="float: left; width: 98%;">
                                                                        <asp:TextBox ID="txtTurnover" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Net Worth Turnover');"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Whether The Company Is 100% Export Oriented Industry:
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList runat="server" ID="Drop1" CssClass="chosen similar-select1 margin-left-z dropdown-toggle input-sm">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                Is the applicant under priority category ? Please specify clearly &nbsp; <span class="checkbox-inline" style="padding-bottom: 20px;">
                                                                    <asp:CheckBox runat="server" ID="chkpriority" AutoPostBack="true" OnCheckedChanged="chkpriority_CheckedChanged" /></span>
                                                            </div>
                                                            <div id="prioritydiv" class="panel-body" style="padding: 0px !important;" runat="server" visible="false">
                                                                <div class="row aks-row">
                                                                    <div class="col-md-4 col-sm-6 col-xs-6">
                                                                        Specification&nbsp;:
                                                                    </div>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:DropDownList runat="server" ID="ddlPriority" CssClass="chosen similar-select1 margin-left-z dropdown-toggle input-sm"></asp:DropDownList>
                                                                        <asp:TextBox ID="txtapplicantpriorityspecification" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group" style="margin-top: 15px;">
                                                            <div class="row">
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                                </div>
                                                                <div class="col-md-4 text-center col-sm-6 col-xs-6">
                                                                    <asp:Button ID="BtnProjectInsert" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtnProjectInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" Text="Save" OnClientClick="return ccheck2();" />
                                                                </div>
                                                                <div class="col-md-4"></div>
                                                            </div>
                                                        </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View3">

                                     <asp:HiddenField ID="hfName" runat="server" />
                                                                 <div class="panel panel-default">
														                            <div class="panel-heading font-bold">
															                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                                            <span style="color: Red" class="">Please upload all document before final submission</span>
                                                                                        </div>
                                                           
                                                                                        <div class="clearfix"></div>
														                            </div>
													<div class="text-left">

                                                            <%-- <asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />  --%>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <ul class="nav nav-pills myul-tabs" style="margin-left: 0;">
                                                                <asp:Panel ID="pnlDemo" runat="server"></asp:Panel>
                                                            </ul>

                                                        </div>
                                     
                                     
                                                                 <asp:GridView ID="GridView2" runat="server" 
                                                    CssClass="table table-striped table-bordered table-hover request-table"
                                                   
                                                    AutoGenerateColumns="False"
                                                    DataKeyNames="ServiceCheckListsID,DocumentID"
                                                    GridLines="Horizontal" 
                                                    OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                                                    Width="100%"
                                                    OnRowDeleting="GridView2_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblServiceCheckLists" Text='<%#Eval("ServiceCheckListsID") %>'></asp:Label>
                                                            <asp:Label runat="server" ID="DocumentID"  Text='<%#Eval("DocumentID") %>'></asp:Label>
                        
                                                                </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblServiceTimeLines" Text='<%#Eval("ServiceTimeLinesID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" />
                                                        <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />
                           
                            
                            
                                                        <asp:TemplateField HeaderText="Action">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle  />
                                                            <ItemTemplate>
                                   
                                 <span class="col-md-10"><asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>                                         


                                                            </ItemTemplate>
                                                        </asp:TemplateField>




                                                        <asp:TemplateField ItemStyle-Width="8%">
                                                            <HeaderStyle />
                                                            <HeaderTemplate>
                                                                <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbView"     runat="server"  CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument"  usesubmitbehavior="true" Text='' ><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton> / 
                                                                <asp:LinkButton ID="lbView1"     runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument"  OnClientClick="return NewWindow();"   usesubmitbehavior="true"  Text =''><i class="fa fa-file-pdf-o" aria-hidden="true"></i></asp:LinkButton> /
                                                                  <asp:LinkButton ID="lbDelete"   runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete"       usesubmitbehavior="true"    Text='<i class="fa fa-times" aria-hidden="true"></i>' />
                           
                                                                </ItemTemplate>
                                                        </asp:TemplateField>




                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Available
                                                    </EmptyDataTemplate>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
<asp:Label ID="DocDisable" runat="server" Visible="false"></asp:Label>
                                                                    <div class="text-center">
                                                                        </div>
                                                                 </div>
													
													


                                                             </asp:View>

                                                <asp:View runat="server" ID="View4">

                                                    <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                                    <div style="background: #e2e2e2; text-align: right; padding: 10px 0; border: 1px solid #cacaca;">
                                                        <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" />

                                                    </div>
                                                    <div id="Payment_Div">
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                    </div>

                                                    <asp:Label ID="lblControlId" runat="server" Visible="false"></asp:Label>
                                                </asp:View>

                                                <asp:View runat="server" ID="View5">
                                                    <div class="clearfix"></div>
                                                    <div id="FinalPrint">
                                                        <asp:PlaceHolder ID="PH_FinalView" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <div class="text-center">
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View6">
                                                    <p class="panel-heading"><b>Applicant New Product Details</b></p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Proposed Product :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Product Description :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" Style="margin-top: 3px;" CssClass="btn-sm btn-primary ey-bg" />
                                                            </div>
                                                        </div>
                                                    </div>






                                                </asp:View>

                                                <asp:View runat="server" ID="View_JointMortgage">
                                                    <p class="panel-heading"><b>Joint Mortgage</b></p>
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                            <span style="color: Red">*</span>
                                                            Paid outstanding balance :
                                                        </label>
                                                        <div class="col-md-8 col-sm-6 col-xs-6">
                                                            <asp:DropDownList runat="server" ID="ddlpaymentstatus" CssClass="similar-select1 input-sm dropdown-toggle">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                            <span style="color: Red">*</span>
                                                            Bank Sanction letter no :
                                                        </label>
                                                        <div class="col-md-8 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtSanctionletternumber" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter no');"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                            <span style="color: Red">*</span>
                                                            Bank Sanction letter Date :
                                                        </label>
                                                        <div class="col-md-8 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtletterDate" runat="server" CssClass=" date input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter Date');"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <hr class="myhrline" />
                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                            <span style="color: Red">*</span>
                                                            Premium Amount bank agreed to pay :
                                                        </label>
                                                        <div class="col-md-8 col-sm-6 col-xs-6">
                                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Premium Amount bank agreed to pay');"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <hr class="myhrline" />
                                                    <div class="panel-heading">Details of Bank/Financial Institution :</div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gridviewBank" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="gridviewBank_Click">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Bank Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("BankName") %>' placeholder="dd/mm/yyyy"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtBankName_insert" CssClass="input-sm similar-select1" runat="server" Width="150px"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Branch Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtBranchName_insert" runat="server" CssClass="txtclass1 form-control input-sm" Width="150px"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtAddress_insert" CssClass="txtclass3 form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Mobile Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMobileNumber" runat="server" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtMobileNumber_insert" CssClass="txtclass2 form-control input-sm" runat="server" Width="150px" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtemail_insert" CssClass="form-control input-sm" runat="server" Width="150px"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Percentage of amount">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPercentage" CssClass="lblClass2" runat="server" Text='<%#Eval("Percentage") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtPercentage_insert" CssClass="form-control input-sm" runat="server" onkeypress="return isDecimalKey(event);" Width="150px"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Lead/Other Bank">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLeadBank" CssClass="lblClass2" runat="server" Text='<%#Eval("Bankstatus") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList runat="server" ID="ddlbankstatus" CssClass="similar-select1 input-sm dropdown-toggle">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="Lead Bank">Lead Bank</asp:ListItem>
                                                                            <asp:ListItem Value="Other Bank">Supporting Bank</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_Bank_details"
                                                                            ImageUrl="~/images/add.png" Width="16px" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                    <div class="btn-group pull-right">
                                                        <asp:Button ID="btnBankSave" runat="server" CssClass="btn btn-sm btn-primary" Text="Save" OnClick="btnBankSave_Click" OnClientClick="return ccheck_JointMortgage();" />
                                                    </div>


                                                </asp:View>

                                                <asp:View runat="server" ID="View_SecondCharge">
                                                    <p class="panel-heading"><b>Details of Bank/Financial Institution (First Charge)</b></p>
                                                    <div>
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Paid outstanding balance :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:DropDownList runat="server" ID="ddlispaidfull" CssClass="similar-select1 input-sm dropdown-toggle">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="False">No</asp:ListItem>
                                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />

                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Bank Sanction letter no :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtSanctionletterno" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter no');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Bank Sanction letter Date :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtSanctionletterDate" runat="server" CssClass=" date input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter Date');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Premium Amount bank agreed to pay  :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtPremimAmount" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Premium Amount bank agreed to pay');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Interest on premium Amount bank agreed to pay :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtInterestAmount" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Interest on premium Amount agreed to pay');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Loan Sanction  Amount :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtAmountFinance" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Amount First Charge');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Bank Name :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Bank Name');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Branch Name :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Branch Name');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Authorized Signatory :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtAuthorizedSignatory1" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Authorized Signatory');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Address :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Address');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Mobile Number :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Mobile Number');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    EmailID :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtemailID" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'EmailID');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                        </div>
                                                    </div>
                                                    <p class="panel-heading"><b>Details of Bank/Financial Institution (Second Charge)</b></p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Sanction letter no :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtSanctionletternoSecond" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter no');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Sanction letter Date :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtSanctionletterDatesecond" runat="server" CssClass=" date input-sm similar-select1" onblur="ValidateRequired(this,'Sanction letter Date');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Premium Amount bank agreed to pay :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtPremimAmountSecond" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Premium Amount bank agreed to pay');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Interest on premium Amount agreed to pay :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtInterestSecond" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Interest on premium Amount agreed to pay');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Loan Sanction Amount :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtAmountsecond" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Amount');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Name :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtName" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Bank Name');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Branch Name :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtBranchNamesecond" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Branch Name');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Authorized Signatory :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtAuthorizedSignatory" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Authorized Signatory');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Address :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtAddresssecond" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Address');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Mobile Number :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtMobileNumbersecond" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Mobile Number');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                EmailID :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtemailIDsecond" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'EmailID');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                    <div class="form-group" style="margin-top: 15px;">
                                                        <div class="row">
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                            </div>
                                                            <div class="col-md-4 text-center col-sm-6 col-xs-6">
                                                                <asp:Button ID="Secondcharge" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtnSecondchargeInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" Text="Save" OnClientClick="return ccheck_secondcharge();" />
                                                            </div>
                                                            <div class="col-md-4"></div>
                                                        </div>
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_Nocmortgage">
                                                    <p class="panel-heading"><b>Letter from Bank Seeking NOC</b></p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Paid outstanding balance :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:DropDownList runat="server" ID="ddlpaidnocmortgage" CssClass="similar-select1 input-sm dropdown-toggle">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Premium Amount bank agreed to pay :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtPremiumAmounts" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Premium Amount bank agreed to pay');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Interest on premium Amount agreed to pay :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtInterestAmounts" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Interest on premium Amount agreed to pay');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Bank Name :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtNocBankName" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Bank Name');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Branch Name :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtNocBranchName" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Branch Name');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Letter No :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtLetterNo" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Letter No');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Date :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="date input-sm similar-select1" onblur="ValidateRequired(this,'Date');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Letter From (Name/Designation) :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtLetterFrom" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Letter From');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Address :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtAddressBank" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Address');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    Mobile Number :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtMobileNumbers" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Mobile Number');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                            <div class="row">
                                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                    <span style="color: Red">*</span>
                                                                    EmailID :
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtemailids" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'EmailID');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr class="myhrline" />
                                                        </div>
                                                        <div class="form-group" style="margin-top: 15px;">
                                                            <div class="row">
                                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                                    <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                                </div>
                                                                <div class="col-md-4 text-center col-sm-6 col-xs-6">
                                                                    <asp:Button ID="NocMortgage" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtnNocMortgageInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" Text="Save" OnClientClick="return ccheck_Nocmortgage();" />
                                                                </div>
                                                                <div class="col-md-4"></div>
                                                            </div>
                                                        </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_TransferofLeasedeed">
                                                    <p class="panel-heading"><b>Letter from Bank </b></p>
                                                    <div class="form-group">
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Paid outstanding balance :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:DropDownList runat="server" ID="ddlispaidTransferofLeasedeed" CssClass="similar-select1 input-sm dropdown-toggle">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Sanction letter no :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtLeasedeedletter" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Letter No');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Sanction letter Date
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="textletterdate" runat="server" CssClass="date input-sm similar-select1" onblur="ValidateRequired(this,'Date');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Premium Amount bank agreed to pay :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtPremiumAmountbank" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Premium Amount bank agreed to pay');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Interest on premium Amount agreed to pay :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtInterestonpremium" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Interest on premium Amount agreed to pay');"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Bank Name :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtBankNameFI" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Bank Name');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Branch Name :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtBranchNameFI" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Branch Name');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Authorized Signatory :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtLetterFromleasedeed" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Letter From');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Address :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtAddressleasedeed" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Address');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Mobile Number :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtMobileno" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur="ValidateRequired(this,'Mobile Number');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                EmailID :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtemailidleasedeed" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'EmailID');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                    </div>
                                                    <div class="form-group" style="margin-top: 15px;">
                                                        <div class="row">
                                                            <div class="col-md-4 col-sm-6 col-xs-6">
                                                                <span style="color: blue" class="pull-left">Field marked with <span style="color: Red">* </span>are mandatory</span>
                                                            </div>
                                                            <div class="col-md-4 text-center col-sm-6 col-xs-6">
                                                                <asp:Button ID="transferofleasedeed" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtntransferofleasedeedInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton" runat="server" Text="Save" OnClientClick="return ccheck_TransferofLeasedeed();" />
                                                            </div>
                                                            <div class="col-md-4"></div>
                                                        </div>
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_Objection">
                                                    <div class="clearfix"></div>
                                                    <div id="Objection_Div">
                                                        <asp:PlaceHolder ID="PH_Objection" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <div class="text-center">
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_TimeExtensionfee">
                                                    <div id="Div2" runat="server">
                                                        <div class="form-group col-md-12 col-sm-12 col-xs-12">
                                                            <label for="PossessionLetter" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                                Do You want to avail free 6 Month Time Extension due to  Covid 19 Pandemic-Lockdown:
                                                            </label>
                                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                                <asp:DropDownList runat="server" ID="ddlCovid19" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlCovid19_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="form-group col-md-12 col-sm-12 col-xs-12">
                                                            <label for="PossessionLetter" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                                Time extension applicable as per Allotmentletter/transferletter/leesedeed(TEF Applicable on )
                                                            </label>
                                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                                <asp:DropDownList runat="server" ID="ddlapplicableonAllotmentletter" CssClass="similar-select1 input-sm dropdown-toggle" >
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="TEFddlgrid" runat="server">
                                                        <div class="form-group col-md-12 col-sm-12 col-xs-12">
                                                            <label for="PossessionLetter" class="col-md-3 col-sm-12 col-xs-12 text-right">
                                                                Time Extension Availed in Past :
                                                            </label>
                                                            <div class="col-md-9 col-sm-12 col-xs-12">
                                                                <asp:DropDownList runat="server" ID="ddltef" CssClass="similar-select1 input-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddltef_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="False">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>

                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="DivTEF">
                                                        <div class="panel-heading">Previous Time Extension Details</div>
                                                        <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="TEFGrid" ViewStateMode="Enabled" DataKeyNames="Id" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TEFDelete_Click">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTEFID" runat="server" Text='<%#Eval("Id") %>' CssClass="hidden"> </asp:Label>

                                                                            <asp:Label ID="lblTEFDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Reference Number">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTEFReff" runat="server" Text='<%#Eval("TEFRefferenceNumber") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtTEFReff_insert" CssClass="input-sm similar-select1" runat="server" onkeypress="return Validate_director_name(event);"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Approval Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTEFApprovalDate" runat="server" Text='<%#Eval("TEFApprovalDate") %>' placeholder="dd/mm/yyyy"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtTEFApprovalDate_insert" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Period (In Month)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTEFPeriod" runat="server" Text='<%#Eval("TEFPeriod") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="drpdTEFPeriod" CssClass="input-sm similar-select1" runat="server">
                                                                                <asp:ListItem Text="3 Month" Value="3"></asp:ListItem>
                                                                                <asp:ListItem Text="6 Month" Value="6"></asp:ListItem>
                                                                                <asp:ListItem Text="9 Month" Value="9"></asp:ListItem>
                                                                                <asp:ListItem Text="12 Month" Value="12"></asp:ListItem>

                                                                            </asp:DropDownList>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Fees">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTEFFees" runat="server" Text='<%#Eval("TEFFees") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtTEFFees_insert" CssClass="input-sm similar-select1" MaxLength="15" runat="server" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
                                                                                ImageUrl="~/images/delete.png" Width="16px" Height="16px" />

                                                                        </ItemTemplate>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <FooterTemplate>
                                                                            <asp:ImageButton ToolTip="Add" CssClass="fa fa-plus-square" ID="ButtonAdd" runat="server" Height="16px" OnClick="insert_TEF_details"
                                                                                ImageUrl="~/images/add.png" Width="16px" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <!--<hr class="separation" />-->
                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <div class="form-group">
                                                            <label class="col-md-3 col-sm-4 col-xs-6">
                                                                Select Time Period (In month) :
                                                            </label>
                                                            <div class="col-md-9 col-sm-8 col-xs-6">
                                                                <asp:DropDownList runat="server" ID="ddlSelectTimePeriod" Style="background: #fff;" CssClass="chosen input-sm similar-select1 margin-left-z">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="panel-heading font-bold text-center">
                                                                Application Description :
                                                            </div>
                                                            <div>
                                                                <CKEditor:CKEditorControl ID="txtApplicationDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                        <div class="panel panel-default" style="border: 1px solid #ccc;" runat="server" id="DivDoc">
                                                            <div class="clearfix"></div>
                                                            <hr class="separation" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12 pad-rt0 pad-lt0">
                                                                <div class="">
                                                                    <div class="panel-heading font-bold text-center">
                                                                        Documents to be Acknowledged                        
                                                                    </div>
                                                                    <div class="panel-body" style="padding: 0px !important;">
                                                                        <div class="div-companydetail" style="background: #ececec;">
                                                                            <asp:GridView ID="GridView_timeextension" runat="server"
                                                                                CssClass="table table-striped table-bordered table-hover request-table"
                                                                                AutoGenerateColumns="False"
                                                                                DataKeyNames="ServiceCheckListsID"
                                                                                GridLines="Horizontal"
                                                                                Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                            </asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:BoundField DataField="ServiceTimeLinesCondition" HeaderText="Checklist" SortExpression="ServiceTimeLinesCondition" Visible="false" />
                                                                                    <asp:BoundField DataField="ServiceTimeLinesDocuments" HeaderText="Checklist Description" SortExpression="ServiceTimeLinesDocuments" />



                                                                                    <asp:TemplateField HeaderText="Acknowledge">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle />
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkAck" runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No Record Available
                                                                                </EmptyDataTemplate>
                                                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
                                                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                                            </asp:GridView>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="clearfix"></div>

                                                        <div class="col-md-2 col-sm-4 col-xs-12">
                                                            <asp:HiddenField runat="server" ID="hidAmt" />
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />
                                                    <div class="col-md-12 col-sm-12 col-xs-12 ">
                                                        <asp:Button ID="btntimeextension" CssClass="btn-sm btn-primary ey-bg pull-right" Style="margin-top: 3px; padding: 0px 10px;" Text="Save" runat="server" OnClick="btntimeextension_Click" OnClientClick="return" />
                                                    </div>
                                                    <div id="DepositeDetails" runat="server" visible="false">
                                                        <div class="clearfix"></div>
                                                        <div class="panel-heading font-bold">Fee Details</div>
                                                        <div style="border: 1px solid #ccc;">
                                                            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_Provisionalletter">
                                                    <div class="clearfix"></div>
                                                    <div id="Provisionalletter_Div">
                                                        <asp:PlaceHolder ID="PH_Provisionalletter" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <div class="text-center">
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="RejectView">

                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">

                                                            <div class="panel panel-default">
                                                                <div class="clearfix"></div>
                                                                <div class="panel-heading font-bold">
                                                                    <div class="col-md-8 col-sm-4 col-xs-12" style="margin-top: 6px; padding: 0px !important;">
                                                                        Letter View  <%--(<code style="color: #00bd00;font-weight: bold;">Total available records</code>)--%>
                                                                    </div>
                                                                    <div class="col-md-12 col-sm-12 col-xs-12">

                                                                        <asp:GridView ID="GridView1" runat="server"
                                                                            CssClass="table table-striped table-bordered table-hover request-table"
                                                                            AllowPaging="True"
                                                                            AutoGenerateColumns="False"
                                                                            DataKeyNames="ServiceRequestNO,Service"
                                                                            GridLines="Horizontal" PageSize="10"
                                                                            OnRowCommand="GridView3_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>


                                                                                <asp:BoundField DataField="ServiceRequestNo" HeaderText="ServiceRequestNo" SortExpression="ServiceRequestNo" />
                                                                                <asp:BoundField DataField="Name" HeaderText="Doc Name" SortExpression="Name" />



                                                                                <asp:TemplateField HeaderText="Action" ControlStyle-Width="30%">


                                                                                    <ItemTemplate>

                                                                                        <asp:LinkButton ID="lbView13" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='Download' />


                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="clearfix"></div>

                                                                </div>

                                                                <div class="panel-body">

                                                                    <asp:Literal ID="ltEmbed" runat="server" />
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

                                                </asp:View>

                                                <asp:View runat="server" ID="View_Startofproduction">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <div class="form-group">
                                                                <label class="col-md-4 col-sm-4 col-xs-6">
                                                                    Production Start Date:
                                                                </label>
                                                                <div class="col-md-8 col-sm-6 col-xs-6">
                                                                    <asp:TextBox ID="txtProductionStartDate" runat="server" CssClass=" date input-sm similar-select1" onblur="ValidateRequired(this,'Production Start Date');"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />
                                                        <div class="form-group">
                                                            <div class="panel-heading font-bold text-center">
                                                                Application Description :
                                                            </div>
                                                            <div>
                                                                <CKEditor:CKEditorControl ID="txtApplicationstartofproductionDescription" BasePath="/ckeditor/" runat="server" ></CKEditor:CKEditorControl>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-sm-12 col-xs-12 ">
                                                            <asp:Button ID="btnStartofProduction"  Style="margin-top: 3px; padding: 0px 10px;" Text="Save" runat="server" OnClick="BtnStartofProductiondInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton"  OnClientClick="return ccheck_StartofProduction();"/>
                                                        </div>
                                                    </div>
                                                </asp:View>

                                                <asp:View runat="server" ID="View_FinalSubmission">
                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <div class="panel panel-default">
                                                            <asp:CheckBox
                                                                ID="CheckBox_Final"
                                                                runat="server"
                                                                Text="&nbsp;&nbsp;I hereby Declared & certify that the Above Record are true and correct to the best of my knowledge."
                                                                OnCheckedChanged="Confirm_CheckBox_final"
                                                                AutoPostBack="true"
                                                                Font-Names="Serif"
                                                                Font-Size="14px" /><br />
                                                            <span style="text-align: center">
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <label class="col-md-4 col-sm-6 col-xs-6 text-left">
                                                            Click on for Final Submission :
                                                        </label>
                                                        <div class="col-md-8 col-sm-6 col-xs-6">
                                                            <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btn_Submit" Text="Submit" CssClass="btn btn-sm btn-primary" OnClick="btn_Submit_Click" Visible="false" />
                                                        </div>
                                                    </div>
                                                </asp:View>
                                                <asp:View runat="server" ID="View_NoticeDetails">
                                                    <input type="button" value="Click Me" style="display: none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange">
                                                    <div class="row">
                                                        <div id="divreply" runat="server" visible="false">
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Notice ID:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtNoticeID" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Service Request NO:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtServiceRequestNO" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Notice Type:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtNoticeType" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-4 col-sm-4 col-xs-6">
                                                                        Notice Description:
                                                                    </label>
                                                                    <div class="col-md-8 col-sm-6 col-xs-6">
                                                                        <asp:TextBox ID="txtNoticeDescription" runat="server" CssClass=" date input-sm similar-select1" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                            <div class="col-md-12 col-sm-12 col-xs-12" id="Divwe">
                                                                <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">

                                                                            <div class="row">
                                                                                <label class="col-md-3 col-sm-12 text-right">
                                                                                    <span style="color: Red">*</span>
                                                                                    Notice Reply Document :
                                                                                </label>
                                                                                <div class="col-md-5 col-sm-12">
                                                                                    <span class="col-md-10">
                                                                                        <asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2">
                                                                                            <asp:LinkButton ID="imgdocuments" runat="server" OnClick="imgdocuments_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>
                                                                                </div>
                                                                                <div class="col-md-4 col-sm-12">
                                                                                    <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="imgdocuments" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <div class="panel-heading font-bold text-center">
                                                                        Application Description :
                                                                    </div>
                                                                    <div>
                                                                        <CKEditor:CKEditorControl ID="CKEditorControl_PlotCancelation" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 col-sm-12 col-xs-12 ">
                                                                    <asp:Button ID="btnPlotCancelation" CssClass="btn-sm btn-primary ey-bg pull-right" Style="margin-top: 3px; padding: 0px 10px;" Text="Save" runat="server" OnClick="BtnPlotCancelationInsert_Click" OnClientClick="return" />
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <hr class="myhrline" />
                                                        </div>
                                                        <div class="panel-heading font-bold text-center">
                                                            Privious Notice Details :
                                                        </div>
                                                        <asp:GridView ID="gvNotice" runat="server"
                                                            CssClass="table table-striped table-bordered table-hover request-table request-table"
                                                            OnRowCommand="gvNotice_RowCommand"
                                                            AllowSorting="True"
                                                            AutoGenerateColumns="False"
                                                            DataKeyNames="ServiceRequestNO,NoticeID"
                                                            GridLines="Horizontal"
                                                            Width="100%" OnRowDataBound="gvNotice_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NoticeID" HeaderText="Notice ID" SortExpression="NoticeID" />
                                                                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request NO" SortExpression="ServiceRequestNO" />
                                                                <asp:BoundField DataField="Noticetype" HeaderText="Notice Type" SortExpression="Noticetype" />
                                                                <asp:BoundField DataField="AppointmentDesc" HeaderText="Notice Description" SortExpression="AppointmentDesc" />
                                                                <asp:BoundField DataField="NoticeReplyDetails" HeaderText="Notice Reply Details" SortExpression="NoticeReplyDetails" />
                                                                <asp:TemplateField HeaderText="Allottee ID" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lblNoticeID" Text='<%#Eval("NoticeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="CreatedOn" />
                                                                <asp:TemplateField>
                                                                    <HeaderStyle />
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="hlblimg" runat="server" Text="Applicant Document"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblApplicantDoc" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocumentApplicant" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                                                                        <asp:LinkButton ID="lbApplicantDocdownload" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocumentApplicant" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle />
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="hlblimg" runat="server" Text="Notice Letter"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text='<i class="fa fa-download" aria-hidden="true"></i>' />/ 
                                                                        <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" usesubmitbehavior="true" Text=''><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No Record Available
                                                            </EmptyDataTemplate>
                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                            <RowStyle ForeColor="#000066" />
                                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        </asp:GridView>
                                                        <div class="panel-body">
                                                            <asp:Literal ID="ltviewer" runat="server" />
                                                        </div>
                                                    </div>
                                                </asp:View>


                                            </asp:MultiView>
                                        </div>
                                    </div>
                                    <asp:Label ID="lblAllotteeID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAllotmentLetterNo" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblRegionalOffice" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIndustrialArea" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblindustrialid" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblplotno" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAllotteeName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblFirmCompanyName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSignatoryMobile" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSIgnatoryEmail" runat="server" Visible="false"></asp:Label>

                                    <asp:Label ID="lblapplicationname" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script>


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

        });



        function Redirect(parameter) {

            window.location.href = 'LandAllottmentApplication.aspx?ServiceReqNo=' + parameter;

        }

        function showError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

            }

        }
        function hideError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'block') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'none';
            }
            return false;
        }

        function ccheck_TimeExtensionfee() {
            var remark = true;

            var txtApplicationDescription = document.getElementById("<%= txtApplicationDescription.ClientID %>");
            if (txtApplicationDescription.value.length <= 0) {
                txtApplicationDescription.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtApplicationDescription.style.borderColor = "";
            }

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }



        function ccheck_TransferofLeasedeed() {
            var remark = true;

            var txtPremiumAmountbank = document.getElementById("<%= txtPremiumAmountbank.ClientID %>");
            if (txtPremiumAmountbank.value.length <= 0) {
                txtPremiumAmountbank.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPremiumAmountbank.style.borderColor = "";
            }
            var txtInterestonpremium = document.getElementById("<%= txtInterestonpremium.ClientID %>");
            if (txtInterestonpremium.value.length <= 0) {
                txtInterestonpremium.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtInterestonpremium.style.borderColor = "";
            }
            var txtBankNameFI = document.getElementById("<%= txtBankNameFI.ClientID %>");
            if (txtBankNameFI.value.length <= 0) {
                txtBankNameFI.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBankNameFI.style.borderColor = "";
            }
            var txtBranchNameFI = document.getElementById("<%= txtBranchNameFI.ClientID %>");
            if (txtBranchNameFI.value.length <= 0) {
                txtBranchNameFI.style.borderColor = '#e52213';
                remark = false;
            }
            var txtLeasedeedletter = document.getElementById("<%= txtLeasedeedletter.ClientID %>");
            if (txtLeasedeedletter.value.length <= 0) {
                txtLeasedeedletter.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtLeasedeedletter.style.borderColor = "";
            }

            var textletterdate = document.getElementById("<%= textletterdate.ClientID %>");

            if (textletterdate.value.length <= 0) {
                textletterdate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                textletterdate.style.borderColor = "";
            }

            var txtLetterFromleasedeed = document.getElementById("<%= txtLetterFromleasedeed.ClientID %>");
            if (txtLetterFromleasedeed.value.length <= 0) {
                txtLetterFromleasedeed.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtLetterFromleasedeed.style.borderColor = "";
            }

            var txtAddressleasedeed = document.getElementById("<%= txtAddressleasedeed.ClientID %>");
            if (txtAddressleasedeed.value.length <= 0) {
                txtAddressleasedeed.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddressleasedeed.style.borderColor = "";
            }

            var txtMobileno = document.getElementById("<%= txtMobileno.ClientID %>");
            if (txtMobileno.value.length <= 0) {
                txtMobileno.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtMobileno.style.borderColor = "";
            }
            var txtemailidleasedeed = document.getElementById("<%= txtemailidleasedeed.ClientID %>");
            if (txtemailidleasedeed.value.length <= 0) {
                txtemailidleasedeed.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtemailidleasedeed.style.borderColor = "";
            }


            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }
        }

        function ccheck_Nocmortgage() {
            var remark = true;

            var txtPremiumAmounts = document.getElementById("<%= txtPremiumAmounts.ClientID %>");
            if (txtPremiumAmounts.value.length <= 0) {
                txtPremiumAmounts.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPremiumAmounts.style.borderColor = "";
            }
            var txtInterestAmounts = document.getElementById("<%= txtInterestAmounts.ClientID %>");
            if (txtInterestAmounts.value.length <= 0) {
                txtInterestAmounts.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtInterestAmounts.style.borderColor = "";
            }
            var txtNocBankName = document.getElementById("<%= txtNocBankName.ClientID %>");
            if (txtNocBankName.value.length <= 0) {
                txtNocBankName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNocBankName.style.borderColor = "";
            }
            var txtNocBranchName = document.getElementById("<%= txtNocBranchName.ClientID %>");
            if (txtNocBranchName.value.length <= 0) {
                txtNocBranchName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNocBranchName.style.borderColor = "";
            }
            var txtLetterNo = document.getElementById("<%= txtLetterNo.ClientID %>");
            if (txtLetterNo.value.length <= 0) {
                txtLetterNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtLetterNo.style.borderColor = "";
            }
            var txtDate = document.getElementById("<%= txtDate.ClientID %>");

            if (txtDate.value.length <= 0) {
                txtDate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtDate.style.borderColor = "";
            }
            var txtLetterFrom = document.getElementById("<%= txtLetterFrom.ClientID %>");
            if (txtLetterFrom.value.length <= 0) {
                txtLetterFrom.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtLetterFrom.style.borderColor = "";
            }

            var txtAddressBank = document.getElementById("<%= txtAddressBank.ClientID %>");
            if (txtAddressBank.value.length <= 0) {
                txtAddressBank.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddressBank.style.borderColor = "";
            }

            var txtMobileNumbers = document.getElementById("<%= txtMobileNumbers.ClientID %>");
            if (txtMobileNumbers.value.length <= 0) {
                txtMobileNumbers.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtMobileNumbers.style.borderColor = "";
            }
            var txtemailids = document.getElementById("<%= txtemailids.ClientID %>");
            if (txtemailids.value.length <= 0) {
                txtemailids.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtemailids.style.borderColor = "";
            }


            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }
        function ccheck_StartofProduction() {
            var remark = true;

            var txtProductionStartDate = document.getElementById("<%= txtProductionStartDate.ClientID %>");
            if (txtProductionStartDate.value.length <= 0) {
                txtProductionStartDate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtProductionStartDate.style.borderColor = "";
            }


            

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }

        function ccheck_JointMortgage() {
            var remark = true;
            var txtSanctionletternumber = document.getElementById("<%= txtSanctionletternumber.ClientID %>");
            var txtletterDate = document.getElementById("<%= txtletterDate.ClientID %>");
            var txtAmount = document.getElementById("<%= txtAmount.ClientID %>");

            if (txtSanctionletternumber.value.length <= 0) {
                txtSanctionletternumber.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSanctionletternumber.style.borderColor = "";
            }
            if (txtletterDate.value.length <= 0) {
                txtletterDate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtletterDate.style.borderColor = "";
            }
            if (txtAmount.value.length <= 0) {
                txtAmount.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAmount.style.borderColor = "";
            }

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }
        }

        function ccheck_secondcharge() {
            var remark = true;

            var txtSanctionletterno = document.getElementById("<%= txtSanctionletterno.ClientID %>");
            if (txtSanctionletterno.value.length <= 0) {
                txtSanctionletterno.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSanctionletterno.style.borderColor = "";
            }
            var txtSanctionletterDate = document.getElementById("<%= txtSanctionletterDate.ClientID %>");
            if (txtSanctionletterDate.value.length <= 0) {
                txtSanctionletterDate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSanctionletterDate.style.borderColor = "";
            }
            var txtPremimAmount = document.getElementById("<%= txtPremimAmount.ClientID %>");
            if (txtPremimAmount.value.length <= 0) {
                txtPremimAmount.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPremimAmount.style.borderColor = "";
            }
            var txtInterestAmount = document.getElementById("<%= txtInterestAmount.ClientID %>");

            if (txtInterestAmount.value.length <= 0) {
                txtInterestAmount.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtInterestAmount.style.borderColor = "";
            }
            var txtAmountFinance = document.getElementById("<%= txtAmountFinance.ClientID %>");
            if (txtAmountFinance.value.length <= 0) {
                txtAmountFinance.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAmountFinance.style.borderColor = "";
            }

            var txtBankName = document.getElementById("<%= txtBankName.ClientID %>");
            if (txtBankName.value.length <= 0) {
                txtBankName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBankName.style.borderColor = "";
            }

            var txtBranchName = document.getElementById("<%= txtBranchName.ClientID %>");
            if (txtBranchName.value.length <= 0) {
                txtBranchName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBranchName.style.borderColor = "";
            }
            var txtAuthorizedSignatory1 = document.getElementById("<%= txtAuthorizedSignatory1.ClientID %>");
            if (txtAuthorizedSignatory1.value.length <= 0) {
                txtAuthorizedSignatory1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAuthorizedSignatory1.style.borderColor = "";
            }
            var txtAddress = document.getElementById("<%= txtAddress.ClientID %>");
            if (txtAddress.value.length <= 0) {
                txtAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress.style.borderColor = "";
            }
            var txtMobileNumber = document.getElementById("<%= txtMobileNumber.ClientID %>");
            if (txtMobileNumber.value.length <= 0) {
                txtMobileNumber.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtMobileNumber.style.borderColor = "";
            }
            var txtemailID = document.getElementById("<%= txtemailID.ClientID %>");
            if (txtemailID.value.length <= 0) {
                txtemailID.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtemailID.style.borderColor = "";
            }
            var txtSanctionletternoSecond = document.getElementById("<%= txtSanctionletternoSecond.ClientID %>");
            if (txtSanctionletternoSecond.value.length <= 0) {
                txtSanctionletternoSecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSanctionletternoSecond.style.borderColor = "";
            }

            var txtSanctionletterDatesecond = document.getElementById("<%= txtSanctionletterDatesecond.ClientID %>");

            if (txtSanctionletterDatesecond.value.length <= 0) {
                txtSanctionletterDatesecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSanctionletterDatesecond.style.borderColor = "";
            }

            var txtPremimAmountSecond = document.getElementById("<%= txtPremimAmountSecond.ClientID %>");
            if (txtPremimAmountSecond.value.length <= 0) {
                txtPremimAmountSecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPremimAmountSecond.style.borderColor = "";
            }

            var txtInterestSecond = document.getElementById("<%= txtInterestSecond.ClientID %>");
            if (txtInterestSecond.value.length <= 0) {
                txtInterestSecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtInterestSecond.style.borderColor = "";
            }

            var txtAmountsecond = document.getElementById("<%= txtAmountsecond.ClientID %>");
            if (txtAmountsecond.value.length <= 0) {
                txtAmountsecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAmountsecond.style.borderColor = "";
            }
            var txtName = document.getElementById("<%= txtName.ClientID %>");
            if (txtName.value.length <= 0) {
                txtName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtName.style.borderColor = "";
            }

            var txtBranchNamesecond = document.getElementById("<%= txtBranchNamesecond.ClientID %>");
            if (txtBranchNamesecond.value.length <= 0) {
                txtBranchNamesecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtBranchNamesecond.style.borderColor = "";
            }
            var txtAddresssecond = document.getElementById("<%= txtAddresssecond.ClientID %>");
            if (txtAddresssecond.value.length <= 0) {
                txtAddresssecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddresssecond.style.borderColor = "";
            }
            var txtAuthorizedSignatory = document.getElementById("<%= txtAuthorizedSignatory.ClientID %>");
            if (txtAuthorizedSignatory.value.length <= 0) {
                txtAuthorizedSignatory.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAuthorizedSignatory.style.borderColor = "";
            }
            var txtMobileNumbersecond = document.getElementById("<%= txtMobileNumbersecond.ClientID %>");
            if (txtMobileNumbersecond.value.length <= 0) {
                txtMobileNumbersecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtMobileNumbersecond.style.borderColor = "";
            }
            var txtemailIDsecond = document.getElementById("<%= txtemailIDsecond.ClientID %>");
            if (txtemailIDsecond.value.length <= 0) {
                txtemailIDsecond.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtemailIDsecond.style.borderColor = "";
            }

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }


        function ccheck2() {
            var remark = true;
            var txttypeofindustry = document.getElementById("<%= txttypeofindustry.ClientID %>");
            var txtestimatedcost = document.getElementById("<%= txtestimatedcost.ClientID %>");
            var txtestimatedemployment = document.getElementById("<%= txtestimatedemployment.ClientID %>");
            var txtcoveredarea = document.getElementById("<%= txtcoveredarea.ClientID %>");
            var txtopenarearequired = document.getElementById("<%= txtopenarearequired.ClientID %>");
            var txtland = document.getElementById("<%= txtland.ClientID %>");
            var txtbuilding = document.getElementById("<%= txtbuilding.ClientID %>");
            var txtmachinery = document.getElementById("<%= txtmachinery.ClientID %>");
            var txtOtherExpenses = document.getElementById("<%= txtOtherExpenses.ClientID %>");
            var txtFixedAssets = document.getElementById("<%= txtFixedAssets.ClientID %>");
            var txtpowerreq = document.getElementById("<%= txtpowerreq.ClientID %>");
            var txtNetWorth = document.getElementById("<%= txtNetWorth.ClientID %>");


            var Drop1 = document.getElementById("<%= Drop1.ClientID %>");
            var workExp = document.getElementById("<%= txtWorkExperience.ClientID %>");

            if (txttypeofindustry.value.length <= 0) {
                txttypeofindustry.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txttypeofindustry.style.borderColor = "";
            }
            if (workExp.value.length <= 0) {
                workExp.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                workExp.style.borderColor = "";
            }

            if (txtestimatedcost.value.length <= 0) {
                txtestimatedcost.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtestimatedcost.style.borderColor = "";
            }
            if (txtestimatedemployment.value.length <= 0) {
                txtestimatedemployment.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtestimatedemployment.style.borderColor = "";
            }

            if (txtcoveredarea.value.length <= 0) {
                txtcoveredarea.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtcoveredarea.style.borderColor = "";
            }
            if (txtopenarearequired.value.length <= 0) {
                txtopenarearequired.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtopenarearequired.style.borderColor = "";
            }
            if (txtland.value.length <= 0) {
                txtland.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtland.style.borderColor = "";
            }
            if (txtbuilding.value.length <= 0) {
                txtbuilding.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtbuilding.style.borderColor = "";
            }
            if (txtmachinery.value.length <= 0) {
                txtmachinery.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtmachinery.style.borderColor = "";
            }

            if (txtpowerreq.value.length <= 0) {
                txtpowerreq.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtpowerreq.style.borderColor = "";
            }
            if (txtNetWorth.value.length <= 0) {
                txtNetWorth.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNetWorth.style.borderColor = "";
            }

            if (Ddl_Expansion.selectedIndex == 0) {
                Ddl_Expansion.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Ddl_Expansion.style.borderColor = "";
            }
            if (Drop1.selectedIndex == 0) {
                Drop1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Drop1.style.borderColor = "";
            }

            if (txtExistingPlotNo.value.length <= 0) {
                txtExistingPlotNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtExistingPlotNo.style.borderColor = "";
            }


            if (txtAllotmentNo.value.length <= 0) {
                txtAllotmentNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAllotmentNo.style.borderColor = "";
            }


            if (txtAllotteeExisName.value.length <= 0) {
                txtAllotteeExisName.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAllotteeExisName.style.borderColor = "";
            }
            if (txtManufacturedProduct.value.length <= 0) {
                txtManufacturedProduct.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtManufacturedProduct.style.borderColor = "";
            }
            if (txtAllotmentDate.value.length <= 0) {
                txtAllotmentDate.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAllotmentDate.style.borderColor = "";
            }

            if (remark == false) {


                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                return false;
            }
            else {
                hideError();
                return true;
            }


        }



        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }





        function ValidateRequired(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }
            else {
                txtObj.style.borderColor = "Red";
                txtObj.focus();
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = txt + " " + "Is required Field";

                return false;
            }

        }

        function ValidateFill(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }


        }
        function PrintElem() {

            Popup($('#Payment_Div').html());
        }


        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }


    </script>
    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;

        });
    </script>

</body>
</html>






