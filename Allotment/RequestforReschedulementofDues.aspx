<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestforReschedulementofDues.aspx.cs" Inherits="Allotment.RequestforReschedulementofDues" %>

<%@ Register Src="~/ucAllotmentDeposits.ascx" TagPrefix="uc1" TagName="ucAllotmentDeposits" %>

<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="s" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
            $(".MultiSelect").chosen();
        }


    </script>

    <script type="text/javascript">

        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });

    </script>
    <script type="text/javascript">

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

        function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted successfully");
            window.location.href = 'IAServicesApplication.aspx?ServiceReqNo=' + par;
        }

        function FinalMsg(par) {
            alert("Form Submitted Successfully");
            window.location.href = 'IAServicesApplication.aspx?ServiceReqNo=' + par;
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
            height: 516px;
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
                                        </span>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-2 pad-rt0 pad-rt0">

                                            <style>
                                                #sub_menu ul {
                                                    margin-left: 0 !important;
                                                }

                                                .myul-tabs > li .selected {
                                                    background: #c7b42a !important;
                                                }
                                            </style>


                                            <asp:Menu
                                                ID="sub_menu"
                                                Orientation="Vertical"
                                                OnMenuItemClick="Menu1_MenuItemClick"
                                                StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                StaticSelectedStyle-CssClass="active selected highlighted"
                                                runat="server" Style="margin-left: 0;">

                                                <Items>
                                                    <%--<asp:MenuItem Text="<span style='color:red;font-weight:800;font-size:larger;'>Objections</span>" Value="6" />--%>
                                                    <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                    <%-- <asp:MenuItem Text="Amalgamation Details" Value="12" />
                                                    <asp:MenuItem Text="Subdivision Details" Value="13" />--%>
                                                    <%-- <asp:MenuItem Text="Project Details" Value="1" />
                                                    <asp:MenuItem Text="New Product Details" Value="5" />
                                                    <asp:MenuItem Text="Sanction Plan Details" Value="9"  />
                                                    <asp:MenuItem Text="Building Specification" Value="7" />
                                                    <asp:MenuItem Text="Documents Upload" Value="2" />--%>
                                                    <asp:MenuItem Text="Accounts Details" Value="7" />
                                                     <%--<asp:MenuItem Text="Fee Details" Value="3" />--%>
                                                    <asp:MenuItem Text="Final Submission" Value="11" />
                                                    <%-- <asp:MenuItem Text="Final Form" Value="4" />--%>
                                                </Items>

                                            </asp:Menu>
                                        </div>
                                        <div class="col-md-10 pad-lt0" style="border-left: 1px solid #ccc;">

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
                                                                <span style="color: Red" class="">Please upload all document before final submission (PDF Format Only)</span>
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
                                                                        <asp:Label runat="server" ID="DocumentID" Text='<%#Eval("DocumentID") %>'></asp:Label>

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
                                                                    <ItemStyle />
                                                                    <ItemTemplate>

                                                                        <span class="col-md-10">
                                                                            <asp:FileUpload ID="FileUpload4" runat="server" /></span><span class="col-md-2"><asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload"></i>' /></span>


                                                                    </ItemTemplate>
                                                                </asp:TemplateField>




                                                                <asp:TemplateField ItemStyle-Width="8%">
                                                                    <HeaderStyle />
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="hlblimg" runat="server" Text=""></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="selectDocument" usesubmitbehavior="true" Text=''><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>
                                                                        / 
                                                                <asp:LinkButton ID="lbView1" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="ViewDocument" OnClientClick="return NewWindow();" usesubmitbehavior="true" Text=''><i class="fa fa-file-pdf-o" aria-hidden="true"></i></asp:LinkButton>
                                                                        /
                                                                  <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Delete" usesubmitbehavior="true" Text='<i class="fa fa-times" aria-hidden="true"></i>' />

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
                                                        <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" Visible="false" />
                                                        <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btn_Submit" Text="Submit" CssClass="btn btn-sm btn-primary" OnClick="btn_Submit_Click" Visible="false" />
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
                                                                <asp:TextBox ID="txtAdditionalProduct" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                Product Description :
                                                            </label>
                                                            <div class="col-md-8 col-sm-6 col-xs-6">
                                                                <asp:TextBox ID="txtProductdescription" runat="server" CssClass="input-sm similar-select1" onblur="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <hr class="myhrline" />
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" Style="margin-top: 3px;" CssClass="btn-sm btn-primary ey-bg" OnClick="btnSave_Click" />
                                                            </div>
                                                        </div>
                                                    </div>






                                                </asp:View>

                                                <asp:View runat="server" ID="View7">
                                                    <div class="clearfix"></div>
                                                    <div id="Objection_Div">
                                                        <asp:PlaceHolder ID="PH_Objection" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <div class="text-center">
                                                    </div>
                                                </asp:View>

                                                <asp:View ID="View8" runat="server">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" style="width: 100%;">
                                                            <div class="row">
                                                                <div class="col-md-12">

                                                                    <div class="col-md-2">
                                                                    </div>
                                                                    <div class="col-md-8">
                                                                        
                                                                    </div>
                                                                    <div class="col-md-2 btn-group">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="panel-body ">
                           
                                                            <div class="table-responsive">
                                                               <asp:GridView ID="AccountsDetailsGrid" runat="server"  AutoGenerateColumns="false"  class="table table-bordered" OnPageIndexChanging="AccountsDetailsGrid_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentHeadID"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Debit"      HeaderText ="Demanded" />
                                        <asp:BoundField DataField ="Credit"          HeaderText ="Paid"/>                                      
                                       <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"/>
                                        <asp:BoundField DataField ="PaymentDate"   HeaderText ="PaymentDate"/>
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
    
                                </div>
                                    <table class="table table-bordered table-hover request-table">

                                                                                            <div>
                                                                                            
                                                                            <tr>
                                                                                <td style="text-align: center;">Reason for Non Payment </td>
                                                                                
                                                                                    
                                                                                 <td>   <asp:TextBox ID="txtNonpayment" runat="server"></asp:TextBox></td>
                                                                            </tr>
                                                                              
                                                            </div>
                                                            <div>
                                                                <tr>
                                                                    <td style="text-align: center;">How many instalments to be made?</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DrpInstalment" runat="server" Style="width: 50% !important" CssClass="chosen btn btn-default dropdown-toggle input-sm mynewselect">

                                                                            <asp:ListItem Value="0">-- Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                                            <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                                            <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                                            <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                                            <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                                            <asp:ListItem Value="6"> 6 </asp:ListItem>

                                                                        </asp:DropDownList>


                                                                    </td>
                                                                </tr>
             </div>
             </table>
        <div>
    <asp:Button runat="server" Text="Submit to view Tentative Reschedulement plan" ID="btnSaveF"  CssClass="btn-primary ey-bg" Style="text-align: right; margin: 8px 0;" />
                                                        </div>                                                                                                             <br />
     <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />
                                                                   <br />
                                                        <div class="clearfix"></div>
                                                        <hr class="myhrline" />

                                                    </div>
                                        </div>
                                    
                                    </asp:View>


                                                <asp:View runat="server" ID="View9">

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

                                    <asp:View ID="View10" runat="server">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" style="width: 100%;">
                                                <div class="row">
                                                    <div class="col-md-12">

                                                        <div class="col-md-2">
                                                        </div>
                                                        <div class="col-md-8">
                                                            <p>
                                                                <b>
                                                                    <asp:Label ID="Label1" runat="server" Text="Specification Of Constructed Building For Which Completion Certificate Is Requested"></asp:Label></b>
                                                            </p>
                                                        </div>
                                                        <div class="col-md-2 btn-group">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body ">



                                                <div class="table-responsive">
                                                    <table class="table table-bordered table-hover request-table" id="datatableService">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 250px">Description</th>
                                                                <th style="width: 50px;">Byelaws </th>
                                                                <th>Unit</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td><span style="color: Red">* </span>FAR(in Percentage)</td>
                                                                <td>
                                                                    <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFar" CssClass="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><span style="color: Red">* </span>Ground Coverage (in Percentage)</td>
                                                                <td>
                                                                    <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGroundcover" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><span style="color: Red">* </span>Total Covered Area (in SqrMts)</td>
                                                                <td>
                                                                    <asp:Label ID="lblCoveredArea" runat="server" Text="N/A"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCoveredAreaA" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><span style="color: Red">* </span>Height(In mts)</td>
                                                                <td>
                                                                    <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtHeight" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="text-align: left;"><span style="color: Red">* </span>Set Back(In mts)</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;"><span style="color: Red">* </span>front</td>
                                                                <td>
                                                                    <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSetBackFront" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;"><span style="color: Red">* </span>Rear
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSetBackRear" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;"><span style="color: Red">* </span>Side1</td>
                                                                <td>
                                                                    <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSetBackSide1" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;"><span style="color: Red">* </span>Side2</td>
                                                                <td>
                                                                    <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSetBackSide2" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="text-align: left;"><span style="color: Red">* </span>Classification of Indiustries Based on Degree of Hazard</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Classification of Hazard</td>
                                                                <td colspan="2">

                                                                    <asp:DropDownList ID="ddlNature" runat="server" Style="width: 100% !important" CssClass="chosen btn btn-default dropdown-toggle input-sm mynewselect">
                                                                    </asp:DropDownList>

                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td><span style="color: Red">* </span>Occupancy</td>
                                                                <td colspan="2">


                                                                    <asp:TextBox ID="txtOccupancy" CssClass="input-sm myyellowbgsmall" runat="server"></asp:TextBox>


                                                                </td>
                                                            </tr>


                                                        </tbody>
                                                    </table>



                                                    <table class="table table-bordered table-hover request-table">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 250px">Floors</th>
                                                                <th>Constructed </th>
                                                                <th style="display: none;">Proposed</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>BaseMent(in Sqmts)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBaseMent1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                                <td style="display: none;">
                                                                    <asp:TextBox ID="txtBaseMent2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Ground Floor(in Sqmts)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGround1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                                <td style="display: none;">
                                                                    <asp:TextBox ID="txtGround2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>First Floor(in Sqmts)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFirstfloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                                <td style="display: none;">
                                                                    <asp:TextBox ID="txtFirstfloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Second Floor(in Sqmts)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSecondFloor1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                                <td style="display: none;">
                                                                    <asp:TextBox ID="txtSecondFloor2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Mezzanine Floor(in Sqmts)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMezzanine1" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                                <td style="display: none;">
                                                                    <asp:TextBox ID="txtMezzanine2" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Stilt Floor(in Sqmts)</td>

                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtStealth" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Mumti(in Sqmts)</td>

                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtMumti" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="table table-bordered table-hover request-table" id="datatableService2">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 250px"></th>
                                                                <th></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td style="text-align: right;">Purpose for which  building Use
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" colspan="2"><b>Construction Specification</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Foundation</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFoundation" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Walls</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWalls" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Floors</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFloors" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Roofs</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRoofs" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Number of storeys</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtStories" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Number of latrines</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLatrines" onkeypress="return isDecimalKey(event);" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Any Previous Construction </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right;">Source of Water for Building Purpose </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div>
                                                        <asp:Button runat="server" Text="Save & Finalise" ID="Button1" CssClass="btn-primary ey-bg" Style="float: right; margin: 8px 0;" OnClick="btnFar_Click" />
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <hr class="myhrline" />

                                                </div>



                                            </div>
                                        </div>
                                    </asp:View>
                                        <asp:View runat="server" ID="View15">

                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">

                                                            <div class="panel panel-default">
                                                                <div class="clearfix"></div>
                                                                <div class="panel-heading font-bold">
                                                                    
                                                                    <div class="col-md-12 col-sm-12 col-xs-12">

                                                                        <asp:GridView ID="GrdReschedulement" runat="server"
                                                                            CssClass="table table-striped table-bordered table-hover request-table"
                                                                            AllowPaging="True"
                                                                            AutoGenerateColumns="False"
                                                                            DataKeyNames="ID"
                                                                            GridLines="Horizontal" PageSize="10">
                                                                       <%--  COMMENT BY G    OnRowCommand="GrdReschedulement_RowCommand"--%>
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="ID" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>


                                                                                <asp:BoundField DataField="PaymentHead" HeaderText="Payment Head" SortExpression="PaymentHead" />
                                                                                <asp:BoundField DataField="Debit" HeaderText="Demanded" SortExpression="Debit" />
                                                                                <asp:BoundField DataField="Credit" HeaderText="Paid" SortExpression="Credit" />
                                                                               <%-- <asp:BoundField DataField="Outstanding" HeaderText="Outstanding" SortExpression="Outstanding" />--%>
                                                                                <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate" />
                                                                                <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" SortExpression="PaymentDate" />



                               
                                                                            </Columns>
                                                                            
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="clearfix"></div>

                                                                </div>

                                                               
                                                            </div>

                                                        </div>

                                                    </div>

                                                </asp:View>


                                    <asp:View runat="server" ID="View11">
                                        <div class="clearfix"></div>
                                        <div id="Ledger_Div">
                                            <asp:PlaceHolder ID="ph_AllotteeLeger" runat="server"></asp:PlaceHolder>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="text-center">
                                        </div>
                                    </asp:View>

                                    <asp:View ID="View12" runat="server">
                                        <div class="clearfix"></div>
                                        <div class="form-group">
                                            <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center"><br />
                                                <tr>
                                                    <label class="col-md-8 ">
                                                    <span style="color: Red">*</span>
                                                   Undertaking to pay the dues as per the Reschedulement Plan:
                                                        
                                                </label>
                                                     <div class="col-md-2 col-md-2 col-sm-12">
                                               <asp:FileUpload ID="DuesUpload" runat="server" /> 

                                                    </div>
                                                   <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>'></asp:LinkButton>--%>
                    <%--<td> <h5>* Undertaking to pay the dues as per the Reschedulement Plan:</h5></td>--%>
                    <%--<td>--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandName="Upload" Text='<i class="fa fa-upload"></i>'></asp:LinkButton> 
                        --<asp:LinkButton ID ="LinkUpload" runat="server" OnClick="LinkUpload" CommandName="Upload" Text='<i class="fa fa-upload"></i>'/>
                        <asp:TextBox ID="txtName" ValidationGroup="LoginFrame" runat="server"></asp:TextBox>
                    </td>--%>
                   <%-- <td>
                        <asp:RequiredFieldValidator ID="Undertaking" ControlToValidate="txtName"  runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr> <br /> <br />   
                                               
                                                <asp:CheckBox
                                                    ID="Conform_CheckBox_multiview_1"
                                                    runat="server"
                                                    Text=" &nbsp;&nbsp;I hereby certify that the Above Record are true and correct to the best of my knowledge."
                                                    Font-Names="Serif"
                                                    Font-Size="14px" />
                                                
                                                    </label>
    
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="form-group">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                <asp:Button runat="server" ID="btn_WithoutFeeSubmit" Text="Final Submit" CssClass="btn btn-info" OnClick="btn_WithoutFeeSubmit_Click" />

                                            </div>
                                        </div>
                                    </asp:View>
                                    <asp:View ID="View13" runat="server">
                                        <div class="form-group">
                                            <div class="clearfix"></div>
                                            <div class="row" style="margin-top: 15px;">
                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                    <span style="color: Red">*</span>
                                                    Add Plots to Amalgamate Arun :
                                                </label>
                                                <div class="col-md-8 col-sm-6 col-xs-6">

                                                    <asp:ListBox runat="server" ID="ListPlotsForAmalgamation" CssClass="MultiSelect" SelectionMode="Multiple" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ListPlotsForAmalgamation_SelectedIndexChanged"></asp:ListBox>

                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <div class="form-group" style="padding: 7px 0; background: #ececec;">
                                                <div class="col-md-12 col-xs-12 col-sm-12">
                                                    Total Area :
                                                                <asp:Label ID="lblTotalArea" runat="server"></asp:Label>&nbsp;SqrMts
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />

                                                <div class="table-responsive" style="max-height: 117px; overflow-y: auto;">
                                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                                                        CssClass="table table-striped table-bordered table-hover request-table" EmptyDataText="No Plot Available">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentHead"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Demanded"      HeaderText ="Demanded"    />
                                        <asp:BoundField DataField ="Paid"          HeaderText ="Paid" />                                      
                                        <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"/>
                                        <asp:BoundField DataField ="DueDate"   HeaderText ="Due Date"/>
                                         <asp:BoundField DataField ="PaymentDate"   HeaderText ="Payment Date"/>
                                                            <%--<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PlotNumber" HeaderText="Selected Plot" SortExpression="PlotNumber" />
                                                            <asp:BoundField DataField="PlotArea" HeaderText="Plot Area" SortExpression="PlotArea" />

                                                            <asp:BoundField DataField="North" HeaderText="North" SortExpression="FRONTSIDE" />
                                                            <asp:BoundField DataField="South" HeaderText="South" SortExpression="FRONTSIDE" />
                                                            <asp:BoundField DataField="East" HeaderText="East" SortExpression="SIDE1" />
                                                            <asp:BoundField DataField="West" HeaderText="West" SortExpression="SIDE2" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="col-md-6 col-sm-6 col-xs-6">
                                                    Amalgamated Plots :
                                                                <asp:Label ID="lblAmalgamatedPlots" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-xs-6">
                                                    Amalgamated Area :
                                                                <asp:Label ID="lblAmalgamatedArea" runat="server"></asp:Label>&nbsp;SqrMts
                                                </div>
                                                <div class="clearfix"></div>
                                                <hr class="myhrline" />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                        <asp:Button ID="btnAmalgamationSave" runat="server" Text="Save" Style="margin-top: 3px;" CssClass="btn-sm btn-primary ey-bg" OnClick="btnAmalgamationSave_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:View>

                                    <asp:View ID="View14" runat="server">

                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                    Total Area <span>*</span>
                                                </label>
                                                <div class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                    <asp:Label ID="lblAlootedtotalarea" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblrbtnFamilySelection" runat="server"></asp:Label>
                                                </div>
                                            </div>



                                            <%-- <div class="row">
                                                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <span style="color: Red">*</span>
                                                                If Family Member :
                                                            </label>
                                                            <style>
                                                                input[type="radio"] {
                                                                    margin: 0 10px 0 10px;
                                                                }
                                                            </style>
                                                            <div class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                <asp:RadioButtonList ID="rbtnFamilySelection" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Table" OnSelectedIndexChanged="rbtnFamilySelection_SelectedIndexChanged" runat="server">

                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList>


                                                            </div>

                                                        </div>--%>
                                        </div>
                                        <asp:Panel ID="familymemarea" runat="server" Visible="false">

                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                        <span style="color: Red">*</span>
                                                        Name Of Family Members :
                                                    </label>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <asp:TextBox ID="txtmem1" runat="server" CssClass="input-sm similar-select1" placeholder="Member 1"></asp:TextBox>

                                                    </div>
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <asp:TextBox ID="txtmem2" runat="server" CssClass="input-sm similar-select1" placeholder="Member 2"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <asp:TextBox ID="txtmem3" runat="server" CssClass="input-sm similar-select1" placeholder="Member 3"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3 col-sm-6 col-xs-6 text-right">
                                                        <asp:TextBox ID="txtmem4" runat="server" CssClass="input-sm similar-select1" placeholder="Member 4"></asp:TextBox>


                                                        <%--<asp:Panel ID="pnlTextBoxes" runat="server">
                                                            </asp:Panel>--%>
                                                        <%--  <hr />--%>
                                                    </div>

                                                    <%-- <div class="col-md-2 col-sm-6 col-xs-6 text-right">
                        <asp:Button ID="btnAdd" runat="server"  class="btn btn-default btn-sm" OnClick="AddTextBox" Text="&#43;" BackColor="Yellow" visible="false"  />
                                        </div>--%>
                                                </div>
                                            </div>
                                        </asp:Panel>






                                        <div class="form-group" style="margin-top: 20px;">
                                            <div class="row">
                                                <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                    <span style="color: Red">*</span>
                                                    <%--  Enter No of units to be Subdivided :--%>Enter The Area To Subdivided(InSQMTs) 
                                                </label>
                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                    <asp:TextBox ID="txtNoofPlots" runat="server" CssClass="input-sm similar-select1" Style="border: 1px solid;"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-6">
                                                    <%-- <asp:Button ID="btn_Subdivide" runat="server" Text="Split & Save" Style="margin-top: 3px; padding: 1px 25px;" CssClass="btn-sm btn-primary ey-bg" OnClick="btn_Subdivide_Click" />--%>
                                                </div>
                                            </div>
                                            <div class="col-md-12" style="margin-top: 40px;">
                                                <div class="">

                                                    <div class="row">
                                                        <div class="col-md-4">

                                                            <label>Original Plot Area</label>
                                                            <asp:Label runat="server" ID="lblOriginalPlotArea" class="populated">
                                                                            0
                                                            </asp:Label>

                                                        </div>
                                                        <%--                                                                    <div class="col-md-8">
                                                                        <div class="Mortgaged">
                                                                            <p>
                                                                                Applicant will enter details of the Sub-divided plots including Proposed Saleable Area/
                            To be Mortgaged.
                                                                            </p>
                                                                            <p><b>* For Family,</b> only Saleable Plots are taken into consideration. </p>
                                                                            <p><b>** Area to be subdivided </b>can’t be more than 75% of <b>Original Plot Area</b></p>
                                                                            <p><b>*** Mortgaged Area</b> should be minimum 20% of Total Saleable Area</p>
                                                                        </div>
                                                                    </div>--%>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <label>Number of Plots to be subdivided </label>
                                                                    <input type="number" class="form-control" name="subdivided" id="txt_NoOfPlot" />
                                                                </div>
                                                            </div>

                                                            <%--  <div class="row">
                                                                            <div class="col-md-6">
                                                                                <label>Area to be subdivided (in sqm)**</label>&nbsp;&nbsp;
                                                                            <input type="text" id="txt-SubDivideArea" name="area" class="form-control" />
                                                                            </div>
                                                                        </div>--%>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <p class="total">(Total rows in table to be created accordingly)</p>
                                                        </div>
                                                    </div>

                                                    <div class="row" style="margin-top: 30px;">
                                                        <table class="table table-striped deatils">
                                                            <thead>
                                                                <tr>
                                                                    <th scope="col">S. No.</th>
                                                                    <th scope="col">Name of Proposed Plot</th>
                                                                    <th scope="col">Area of Sub-divided Plot (sqm)</th>
                                                                    <th scope="col">Saleable/ To be Mortgaged*</th>
                                                                    <th scope="col">Action</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="tbody">
                                                                <!--<tr>
                        <td scope="row" class="rownum">1</td>
                        <td>Text Box (Alphanumeric, Characters – and /allowed)</td>
                        <td>Min. 450 sqm</td>
                        <td>
                            <select id="saleable" class="saleable4">
                                <option>Saleable</option>
                                <option>Mortgaged</option>
                            </select>
                        <td><button type="submit" class="sub-mits">Submit</button></td>
                    </tr>-->
                                                            </tbody>
                                                        </table>
                                                    </div>

                                                    <div class="row">

                                                        <div class="col-md-6">
                                                            <div class="morer">
                                                                <button id="btn-AddMoreRow">Add More Rows</button>
                                                            </div>
                                                            <label>Total Saleable Area (in sqm)</label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <label id="lblTotalSaleableArea" class="populated4" runat="server"></label>
                                                            <label>Total Mortgaged Area (in sqm)***</label>
                                                            <label id="lblTotalMortgagedArea" class="populated4" runat="server"></label>
                                                            <%--<asp:Label ID="litTotalSaleableArea" runat="server"></asp:Label>
                                                                        <asp:Label ID="litTotalMortgagedArea" runat="server"></asp:Label>--%>
                                                            <asp:HiddenField ID="hdnTotalSaleableArea" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnTotalMortgagedArea" runat="server"></asp:HiddenField>

                                                        </div>
                                                        <%--  <div class="col-md-6">
                                                                        <p>
                                                                            <b>Total Saleable Area</b> can’t be more than <b>Area to be Subdivided. Total
                            Mortgaged Area
                                                                            </b>
                                                                            can’t be more than <b>Area to be subdivided.</b>
                                                                        </p>
                                                                        <p>
                                                                            Total of Saleable and Mortgaged Area can’t be more than Area to be subdivided.
                                                                        </p>
                                                                    </div>--%>
                                                    </div>

                                                    <div class="form-group">

                                                        <div class="clearfix"></div>

                                                        <asp:GridView ID="GridView5" runat="server" CssClass="table table-striped table-bordered table-hover request-table" ShowFooter="true" AutoGenerateColumns="false"
                                                            DataKeyNames="id" OnRowCancelingEdit="GridView5_RowCancelingEdit" OnRowEditing="GridView5_RowEditing1" OnRowUpdating="GridView5_RowUpdating" OnRowDeleting="GridView5_RowDeleting">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>" />


                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="id" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                                    <ItemTemplate>

                                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Number of Proposed Plot" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblplot" runat="server" Text='<%#Eval("Plot_name") %>'> 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPlot" runat="server" Text='<%#Eval("Plot_name") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Area of Sub-divided Plot (sqm)" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblArea" runat="server" Text='<%#Eval("Plot_Area") %>'> 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtArea" runat="server" Text='<%#Eval("Plot_Area") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Saleable/ To be Mortgaged" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSalMort" runat="server" Text='<%#Eval("Sal_mort") %>'> 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlSalMord" runat="server">
                                                                            <asp:ListItem Text="Saleable" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Mortgaged" Value="1"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>

                                                                </asp:TemplateField>
                                                                <asp:CommandField ShowEditButton="true" />
                                                                <asp:CommandField ShowDeleteButton="true" />
                                                                <%--<asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>
                                                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>

                                                    <div class="row" style="margin-bottom: 50px;">
                                                        <div class="butns">
                                                            <%--<button class="conform" type="submit">CONFIRM</button>--%>
                                                            <asp:Button ID="btn_Subdivide" runat="server" Text="Split & Save" Style="margin-top: 3px; padding: 8px 25px;" CssClass="btn-sm btn-primary ey-bg" OnClick="btn_Subdivide_Click" />
                                                        </div>
                                                    </div>

                                                </div>


                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />

                                            <div class="form-group">

                                                <div class="clearfix"></div>
                                                <asp:GridView ID="GridView4" runat="server" CssClass="table table-striped table-bordered table-hover request-table" ShowFooter="true" AutoGenerateColumns="false"
                                                    OnRowEditing="OnRowEditing">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PlotNo" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblplot" runat="server" Text='<%#Eval("PlotNo") %>'> 
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="PlotSize" HeaderText="PlotSize" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton Text="Update" runat="server" OnClick="OnUpdate" />
                                                                <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>

                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Save Details" Visible="false" Style="margin-top: 3px;" CssClass="btn-sm btn-primary ey-bg" OnClick="btnSubmit_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </asp:View>
                                    </asp:MultiView>

                                </div>
                            </div>

                            <asp:Label ID="lblAllotmentLetterNo" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblRegionalOffice" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblIndustrialArea" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblAllotteeName" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblFirmCompanyName" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblSignatoryMobile" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblSIgnatoryEmail" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblPlotSize" runat="server" Visible="false"></asp:Label>
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





        function ccheck2() {
            var remark = true;
            var ddlIndType = document.getElementById("<%= ddlTypeOfIndustry.ClientID %>");
            var ddlIAcat = document.getElementById("<%= drpIACategory.ClientID %>");
            var txttypeofindustry = document.getElementById("<%= txttypeofindustry.ClientID %>");
            var txtProjectStartMonths = document.getElementById("<%= txtProjectStartMonths.ClientID %>");
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
            var txtNetTurn = document.getElementById("<%= txtTurnover.ClientID %>");


            var Drop1 = document.getElementById("<%= Drop1.ClientID %>");
            var workExp = document.getElementById("<%= txtWorkExperience.ClientID %>");

            if (txttypeofindustry.value.length <= 0) {
                txttypeofindustry.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txttypeofindustry.style.borderColor = "";
            }
            if (txtProjectStartMonths.value.length <= 0) {
                txtProjectStartMonths.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtProjectStartMonths.style.borderColor = "";
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
            if (txtNetTurn.value.length <= 0) {
                txtNetTurn.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtNetTurn.style.borderColor = "";
            }


            if (ddlIndType.selectedIndex == 0) {
                ddlIndType.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddlIndType.style.borderColor = "";
            }
            if (ddlIAcat.selectedIndex == 0) {
                ddlIAcat.style.borderColor = '#e52213';
                remark = false;
            }
            else {



                ddlIAcat.style.borderColor = "";
                if (ddlIAcat.selectedIndex == 1 || ddlIAcat.selectedIndex == 2) {
                    var txteffluentsolidqty = document.getElementById("<%= txteffluentsolidqty.ClientID %>");
                    var txteffluentsolidcomposition = document.getElementById("<%= txteffluentsolidcomposition.ClientID %>");
                    var txteffluentliquidqty = document.getElementById("<%= txteffluentliquidqty.ClientID %>");
                    var txteffluentliquidcomposition = document.getElementById("<%= txteffluentliquidcomposition.ClientID %>");
                    var txteffluentgaseousqty = document.getElementById("<%= txteffluentgaseousqty.ClientID %>");
                    var txteffluentgaseouscomposition = document.getElementById("<%= txteffluentgaseouscomposition.ClientID %>");
                    var drpreqETp = document.getElementById("<%= drpreqETp.ClientID %>");

                    if (drpreqETp.selectedIndex == 0) {
                        drpreqETp.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        drpreqETp.style.borderColor = "";
                    }

                    if (txteffluentsolidqty.value.length <= 0) {
                        txteffluentsolidqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentsolidqty.style.borderColor = "";
                    }

                    if (txteffluentsolidcomposition.value.length <= 0) {
                        txteffluentsolidcomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentsolidcomposition.style.borderColor = "";
                    }

                    if (txteffluentliquidqty.value.length <= 0) {
                        txteffluentliquidqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentliquidqty.style.borderColor = "";
                    }

                    if (txteffluentliquidcomposition.value.length <= 0) {
                        txteffluentliquidcomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentliquidcomposition.style.borderColor = "";
                    }

                    if (txteffluentgaseousqty.value.length <= 0) {
                        txteffluentgaseousqty.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentgaseousqty.style.borderColor = "";
                    }

                    if (txteffluentgaseouscomposition.value.length <= 0) {
                        txteffluentgaseouscomposition.style.borderColor = '#e52213';
                        remark = false;
                    }
                    else {
                        txteffluentgaseouscomposition.style.borderColor = "";
                    }
                }



            }
            if (Drop1.selectedIndex == 0) {
                Drop1.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                Drop1.style.borderColor = "";
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
        function PrintElemF() {

            Popup($('#DivP').html());
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
            }, 10000);


            return true;
        }


    </script>

    <script>
        $(function () {
            function RowArrange() {
                $('#tbody tr').each(function (i, v) {
                    $(v).find('td.rownum').text((i + 1));
                });
            }
            function CalulateSaleableAndMortgaged() {
                var Saleable = 0.000;
                var Mortgaged = 0.000;
                $('#tbody tr').each(function (i, v) {
                    var sq = $(v).find('.clstxtSizeInSq').val();
                    var saleable = $(v).find('.clsSaleable').val();
                    if (saleable == 'Saleable') {
                        if (sq != '' && sq != '-' && sq != '+') {
                            Saleable += parseFloat(sq);
                        }
                    }
                    else {
                        if (sq != '' && sq != '-' && sq != '+') {
                            Mortgaged += parseFloat(sq);
                        }
                    }
                });
                $('#lblTotalSaleableArea').text(Saleable.toFixed(3));
                $('#lblTotalMortgagedArea').text(Mortgaged.toFixed(3));
                <%--$('#<%=litTotalSaleableArea.ClientID%>').text(Saleable.toFixed(3));
                $('#<%=litTotalMortgagedArea.ClientID%>').text(Mortgaged.toFixed(3));--%>
                $('#<%=hdnTotalSaleableArea.ClientID%>').val(Saleable.toFixed(3));
                $('#<%=hdnTotalMortgagedArea.ClientID%>').val(Mortgaged.toFixed(3));

            }


            function AddRow() {
                //debugger;
                //getSubdivisionData();

                var len = $('#tbody').find('tr').length + 1;
                var jj = '<tr class="data-contact-person">';
                jj += '    <td scope="row" class="rownum">' + len + '</td>';
                jj += '    <td><input type="text" class="clstxtProposedPlotName form-control" id="plotname"/></td>';
                jj += '    <td><input type="number" class="clstxtSizeInSq form-control" id="plotsize"/></td>';
                jj += '    <td>';
                jj += '        <select class="clsSaleable form-control" id="plottype' + len + '">';
                jj += '            <option value="Saleable">Saleable</option>';
                jj += '            <option value="Mortgaged">Mortgaged</option>';
                jj += '        </select>';
                //jj += '        <td><button type="button" class="sub-mits btnSubmit" id="BtnSubmit" onclick="btnSubmit();" value="Submit"></button></td>';
                jj += '        <td><button type="button" class="sub-mits btnSubmit" id="plotbutton" value="Submit">Submit</button></td>';
                jj += '<input id="myInputHidden" name="myInputName" type="hidden" value="" /></tr>';
                $('#tbody').append(jj);
                $('#txt_NoOfPlot').val(len);
                debugger;
                var lblrtypes = $('#lblrbtnFamilySelection').text();
                if (lblrtypes == 'Family')
                {
                    $('.clsSaleable').val("Saleable");
                    $(".clsSaleable").attr("disabled", true);
                }
                CalulateSaleableAndMortgaged();
            }

            function getAllEmpData() {
                var data = [];
                $('tr.data-contact-person').each(function () {
                    var PloatName = $(this).find('.clstxtProposedPlotName').val();
                    var PlotArea = $(this).find('.clstxtSizeInSq').val();
                    var Salmort = $(this).find('.clsSaleable').val();
                    var ServiceReqNo = '<%= Session["ServiceReqNo"] %>';
                    var alldata = {
                        'Plot_name': PloatName,
                        'Plot_Area': PlotArea,
                        'Sal_mort': Salmort,
                        'ServiceReqNo': ServiceReqNo
                    }
                    data.push(alldata);
                });
                console.log(data);
                return data;
            }

          <%--  function getSubdivisionData() {
                //$('.ddl_TaxType').change(function () {
                // var TaxId = $('.ddl_TaxType').val();
                debugger;
                 var ServiceReqNo = '<%= Session["ServiceReqNo"] %>';
                    //if (parseFloat(TaxId) > 0) {
                $.ajax({                   
                    type: "POST",
                    contentType: "application/json",                            
                    url: 'IAServicesApplication.aspx/getSubdivisionDetails',
                    data: "{'ServiceReqNo' : '" + ServiceReqNo + "'}",
                    dataType: "json",
                        
                    success: function (data) {
                        debugger;
                        var repo = JSON.parse(data.d);
                        //$.each(data.d, function (key, value) {
                        //$('.lblVatPer').html(value.Vat);
                        debugger;
                        for (var i = 0; i < repo.length; i++) {
                            // temp += "<tr><td align=\"center\">" + repo[i].flid + "</td>" + "<td align=\"center\">" + repo[i].fname + "</td>" + "<td align=\"center\">" + repo[i].AvailQty + "</td>" + "<td align=\"center\">" + "<input id=\"txt1\" value=\"0\"  type=\"text\" onblur=\" return Numeric(this.value);\" placeholder=\"Enter Quanty\"/>" + "</td></tr>";
                            var len = $('#tbody').find('tr').length + 1;
                            var jj = '<tr class="data-contact-person">';
                            jj += '    <td scope="row" class="rownum">' + i+1 + '</td>';
                            jj += '    <td><input type="text" class="clstxtProposedPlotName form-control" id="plotname' + i + 1 + '"/></td>';
                            jj += '    <td><input type="number" class="clstxtSizeInSq form-control" id="plotsize' + i + 1 + '"/></td>';
                            jj += '    <td>';
                            jj += '        <select class="clsSaleable form-control" id="plottype' + i+1 + '">';
                            jj += '            <option value="Saleable">Saleable</option>';
                            jj += '            <option value="Mortgaged">Mortgaged</option>';
                            jj += '        </select>';
                            //jj += '        <td><button type="button" class="sub-mits btnSubmit" id="BtnSubmit" onclick="btnSubmit();" value="Submit"></button></td>';
                            jj += '        <td><button type="button" class="sub-mits btnSubmit" id="plotbutton" value="Submit">Update</button></td>';
                            jj += '<input id="myInputHidden" name="myInputName" type="hidden" value="' + repo[i].ids + '" /></tr>';
                            $('#tbody').append(jj);
                            $('#txt_NoOfPlot').val(len);
                            debugger;
                            $('#plotname' + i + 1 + '').text(repo[i].Plot_names);
                            $('#plotsize' + i + 1 + '').text(repo[i].Plot_Areas);
                            var lblrtypes = $('#lblrbtnFamilySelection').text();
                            if (lblrtypes == 'Family') {
                                $('.clsSaleable').val(repo[i].Sal_morts);
                                $(".clsSaleable").attr("disabled", true);
                            }
                            CalulateSaleableAndMortgaged();

                        }
                        //});
                         }
                
                        });
                    
                   }--%>

            $(document).on('click', '[id*=plotbutton]', function () {
                //// $("#BtnSubmit").click(function () {
                debugger;
                var tr = $(this).closest('tr');
                var data = {};
                tr.each(function () {
                    data.Plot_name = tr.find('.clstxtProposedPlotName').val();
                    data.Plot_Area = tr.find('.clstxtSizeInSq').val();
                    data.Sal_mort = tr.find('.clsSaleable').val();
                    //data.Plot_name = $('#plotname').val();
                    //data.Plot_Area = $('#plotsize').val();
                    //data.Salmort = $('#plottype').val();
                    data.ServiceReqNo = '<%= Session["ServiceReqNo"] %>';
                    data.TotalSaleableArea = $('#lblTotalSaleableArea').text();
                    data.TotalMortgagedArea = $('#lblTotalMortgagedArea').text();
                    //$('#<%=Label1.ClientID%>').val();
                    data.OrgPloatarea = $('#txtNoofPlots').val();
                })
                //var data = JSON.stringify(getAllEmpData());
                //console.log(data);
                var x = "", grides = "";
                console.log(data);
                //alert(data);
                $.ajax({
                    type: 'POST',
                    //url: 'IAserviesapplication.asmx/SaveData',
                    url: 'IAServicesApplication.aspx/SaveData',
                    // data: JSON.stringify(data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    data: JSON.stringify({ 'data': data }),

                    success: function (response) {
                        debugger;
                        x = response.d;
                        if (x == 'Success') {
                            alert("Data Added Successfully");
                            <%--var serNo = '<%= Session["ServiceReqNo"] %>';
                            var rtype = 'Family';
                            var url = "IAServicesApplication.aspx?name=" + ServiceReqNo + "&rtype=" + rtype;
                            window.location.href = url;--%>
                        }
                        else if (x == 'Errors')
                        { alert("Name of Prpposed Plot can't be same as the name of the plot to be sub-divided or any other plot already existing in the Industrial Area. "); }
                        else if (x == 'AreaMini')
                        { alert("Subdivision Area can't less than  450 sqm."); }
                        else if (x == 'SaleableArea')
                        { alert("Saleable Area can't more than Subdivided Plot Area"); }
                        else if (x == 'AreaMortMini')
                        { alert("Mortgaged Area should be minimum 20% of Total Saleable Area"); }
                        else if (x == 'AreaToSubdivided')
                        { alert("First Enter The Area To Subdivided"); }
                    },
                    error: function (err) {
                        debugger;
                        //console.log(data);
                        // alert(err);
                        alert("Error while inserting data");
                    }
                });

                //if (x == '{"d": "1"}') {
                //    HideLoder("Name of Subdivision Plot not same Plot No ");
                //}
                //else if (x == '{"d": "1"}') {
                //    alert("Data Added Successfully");
                //}
                //else {
                //    HideLoder("Some Technical Problem.Record not save");
                //}
            });

            $(function () {// 
                $(document).on('input', '#<%=txtNoofPlots.ClientID%>', function () {

                    //$('#<%=txtNoofPlots.ClientID%>').change(function () {
                    //var numbers = /^[0-9]+$/;
                    debugger;
                    var subdivPer = 75;
                    var subdivArea = $('#<%=txtNoofPlots.ClientID%>').val();
                    var lblOrgPA = $('#lblOriginalPlotArea').text();
                    var lennum = lblOrgPA;
                    var orgPA = lennum.split(' ');
                    var orgPANu = orgPA[0];
                    //alert(gogl[1] + "  " + gogl[0])
                    var getsubdivPer = (((parseFloat(lblOrgPA) * parseFloat(subdivPer)) / 100)).toFixed(3);
                    if (parseFloat(getsubdivPer) >= parseFloat(subdivArea)) {

                    }
                    else {
                        $('#txtNoofPlots').val("0");
                        alert('The Area to subdivided can not more than  75% of Original Plot Area');
                    }
                });
            });

            function tableRowCreate() {
                // $(document).on('input', '#<%=txtNoofPlots.ClientID%>', function () {

                //$('#<%=txtNoofPlots.ClientID%>').change(function () {
                //var numbers = /^[0-9]+$/;
                debugger;
                var subdivPer = 75;
                var subdivArea = $('#<%=txtNoofPlots.ClientID%>').val();
                var lblOrgPA = $('#lblOriginalPlotArea').text();
                var lennum = lblOrgPA;
                var orgPA = lennum.split(' ');
                var orgPANu = orgPA[0];
                //alert(gogl[1] + "  " + gogl[0])
                var getsubdivPer = (((parseFloat(lblOrgPA) * parseFloat(subdivPer)) / 100)).toFixed(3);
                if (parseFloat(getsubdivPer) >= parseFloat(subdivArea)) {
                }
                else {
                    $('#txtNoofPlots').val("0");
                    alert('The Area to subdivided can not more than  75% of Original Plot Area');
                }
                //});
            }

            function submitsubdivide(e) {
                debugger;
                var lennum = e;
                var gogl = lennum.split('_');

                alert(gogl[1] + "  " + gogl[0])
            }

            $(document).on('input', '#txt_NoOfPlot', function () {
                debugger;
                $('#tbody').empty();
                if (this.value == '' || parseInt(this.value) < 1) {
                    this.value = '1';
                }
                var len = $.trim($(this).val()) != '' ? parseInt($(this).val()) : 0;
                for (var i = 0; i < len; i++) {
                    AddRow();

                }
                CalulateSaleableAndMortgaged();
            });

            var st = setInterval(function () {
                if ($('#tbody')[0] != undefined) {
                    clearInterval(st);
                    AddRow();
                }
            }, 1000);


            $(document).on('click', '#btn-AddMoreRow', function () {
                AddRow();
                return false;
            });

            $(document).on('input', '.clstxtSizeInSq', function () {
                CalulateSaleableAndMortgaged();
            });
        });
    </script>
    <style>
        .form-groups {
            padding: 5px;
            margin-bottom: 1rem;
            background-color: #faf4f4;
        }

        .populated {
            padding: 6px 36px;
            background-color: #62cca6;
            color: white;
            border: 2px solid #435ca4;
            font-style: italic;
            margin: 10px;
        }

        .populated4 {
            padding: 6px 70px;
            background-color: #62cca6;
            color: white;
            border: 2px solid #435ca4;
            font-style: italic;
            margin: 10px;
        }

        .conform {
            padding: 8px 36px;
            background-color: #62cca6;
            color: white;
            border: 2px solid #435ca4;
            font-style: italic;
            font-size: 20px;
            margin: 10px;
            font-weight: bold;
        }

        .sub-mits {
            padding: 4px 36px;
            border: 2px solid #435ca4;
            BACKGROUND-COLOR: #62cca6;
            color: white;
        }

        .Mortgaged {
            padding: 10px;
            margin: 10px;
            border: 2px solid #7f66c6;
        }

        /*     #Original input {
            margin: 10PX;
            border: 2px solid #435ca4;
            width: 471PX;
            background-color: #0062cc
            a6;
        }*/

        .total {
            margin: 10px;
        }

        #Original label {
            margin: 10PX;
        }

        .morer {
            border: NONE;
            background-color: WHITE;
            padding: 5PX 0PX;
        }

        .butns {
            margin-left: auto;
            margin-right: auto;
        }

        .deatils {
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
            border-bottom: 1px solid;
            border-top: 1px solid;
        }

        .saleable4 {
            width: 206px;
            padding: 0px 11px;
            height: 36px;
        }
    </style>
</body>
</html>






