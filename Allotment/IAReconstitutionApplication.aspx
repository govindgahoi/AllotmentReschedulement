<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAReconstitutionApplication.aspx.cs" Inherits="Allotment.IAReconstitutionApplication" %>

<%@ Register Src="~/ucAllotmentDeposits.ascx" TagPrefix="uc1" TagName="ucAllotmentDeposits" %>

<%@ Register Src="~/UC_Service_Allotteee_Detail.ascx" TagPrefix="uc1" TagName="s" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
 
    <%--<script src="assets/js/bootstrap.min.js"></script>--%>
    <script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js'></script>
    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>

    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>

    <script type="text/javascript">




        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }

        function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted succesfully");
            window.location.href = 'IAReconstitutionApplication.aspx?ServiceReqNo=' + par;
        }
    </script>


    <script type="text/javascript">
         function MessageAndRedirect(par) {
            alert("Objection cleared and form re-submitted succesfully");
            window.location.href = 'IAReconstitutionApplication.aspx?ServiceReqNo=' + par;
        }

        function FinalMsg(par) {
            alert("Form Submitted Successfully");
            window.location.href = 'IAReconstitutionApplication.aspx?ServiceReqNo=' + par;
        }
         




      <%--  function ccheck1() {
             var remark = true;
             var ddlcompany = document.getElementById("<%= ddlcompanytype.ClientID %>");
             var txtCompanyname = document.getElementById("<%= txtCompanyname.ClientID %>");
             var txtPanNo = document.getElementById("<%= txtPanNo.ClientID %>");
             var txtIndividualName = document.getElementById("<%= txtIndividualName.ClientID %>");
             var txtIndividualAddress = document.getElementById("<%= txtIndividualAddress.ClientID %>");
             var txtIndividualPhone = document.getElementById("<%= txtIndividualPhone.ClientID %>");
             var txtIndividualEmail = document.getElementById("<%= txtIndividualEmail.ClientID %>");
             var txtAuthorisedSignatory = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
             var txtSignatoryAddress = document.getElementById("<%= txtSignatoryAddress.ClientID %>");
             var txtSignatoryPhone = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
             var txtSignatoryEmail = document.getElementById("<%= txtSignatoryEmail.ClientID %>");

             if (ddlcompany.selectedIndex == 0) {
                 ddlcompany.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 ddlcompany.style.borderColor = "";
             }
             if (txtCompanyname.value.length <= 0) {
                 txtCompanyname.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtCompanyname.style.borderColor = "";
             }
             if (txtPanNo.value.length <= 0) {
                 txtPanNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtPanNo.style.borderColor = "";
             }

             if (txtAuthorisedSignatory.value.length <= 0) {
                 txtAuthorisedSignatory.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtAuthorisedSignatory.style.borderColor = "";
             }
             if (txtSignatoryAddress.value.length <= 0) {
                 txtSignatoryAddress.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtSignatoryAddress.style.borderColor = "";
             }
             if (txtSignatoryPhone.value.length <= 0) {
                 txtSignatoryPhone.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtSignatoryPhone.style.borderColor = "";
             }
             if (txtSignatoryEmail.value.length <= 0) {
                 txtSignatoryEmail.style.borderColor = '#e52213';
                 remark = false;
             }
             else {
                 txtSignatoryEmail.style.borderColor = "";
             }
             if (ddlcompany.selectedIndex == 1) {
                 if (txtIndividualName.value.length <= 0) {
                     txtIndividualName.style.borderColor = '#e52213';
                     remark = false;
                 }
                 else {
                     txtIndividualName.style.borderColor = "";
                 }
                 if (txtIndividualAddress.value.length <= 0) {
                     txtIndividualAddress.style.borderColor = '#e52213';
                     remark = false;
                 }
                 else {
                     txtIndividualAddress.style.borderColor = "";
                 }
                 if (txtIndividualPhone.value.length <= 0) {
                     txtIndividualPhone.style.borderColor = '#e52213';
                     remark = false;
                 }
                 else {
                     txtIndividualPhone.style.borderColor = "";
                 }
                 if (txtIndividualEmail.value.length <= 0) {
                     txtIndividualEmail.style.borderColor = '#e52213';
                     remark = false;
                 }
                 else {
                     txtIndividualEmail.style.borderColor = "";
                 }

             }

             if (remark == false) {

                 alert("Fill All Required Field");
                 showError();
                 document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

              return false;
             } else {
                 hideError();
                 return true;
             }

         }--%>
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
                                                <p><span style="font-size:20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> <div class="clearfix"></div>
                                     <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                
                                                     <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>
                                                  
                                            </div>
                                           
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> 
                                <div class="clearfix"></div>
                              <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;"><div  class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                      <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" Style="background-color:#02486d;color:#fff;font-weight:600;" OnClick="btn_backNmswp_Click"  />
                    </div></div>
                                    <div class="clearfix"></div>
                                    <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">
                                        <asp:Label runat="server" ID="lblFormName"></asp:Label>
                                        </span></div>






                                    <div class="row">
                                        <div class="col-md-2 pad-rt0 pad-rt0">

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
                                                runat="server" Style="margin-left: 0;">

                                                <Items>
                                                    <asp:MenuItem Text="<span style='color:red;font-weight:800;font-size:larger;'>Objections</span>" Value="6" />
                                                    <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                    <asp:MenuItem Text="Reconstitution Details"  Value="1" />
                                                     <asp:MenuItem Text="Application of leasse deed"  Value="5" />
                                                    <asp:MenuItem Text="Recognition for legal heir"  Value="1" />
                                                    <%--<asp:MenuItem Text="Water Connection" Value="8" />--%>
                                                    <asp:MenuItem Text="Documents Upload" Value="2" />
                                                    <asp:MenuItem Text="Payment Details" Value="3" />
                                                    <asp:MenuItem Text="Final Submission" Value="8" />
                                                    <asp:MenuItem Text="Final Form" Value="4" />

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
                                                <asp:View runat="server" ID="Allotee_View">


                                                    <asp:PlaceHolder ID="PH_AllotteeDetails" runat="server"></asp:PlaceHolder>
                                                </asp:View>


                                              <asp:View runat="server" ID="Reconstitution_View">
                                          
                                                                            <div class="panel-heading">Applicant Basic Details</div>
                                                                    
                                                                        <div class="row">
                                                                            <div class="col-md-12 col-sm-12 col-xs-12">
													                            <p class="panel-heading"><b>Particulars of the Applicant</b></p>
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Constitution of Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed"  CssClass="similar-select1 margin-left-z dropdown-toggle input-sm"  ></asp:DropDownList>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Name of the Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtCompanyname" runat="server" CssClass="similar-select1 input-sm" onblur="ValidateRequired(this,'Name of the Firm/Company');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Pan No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtPanNo" runat="server" CssClass="similar-select1 input-sm" Style="text-transform:uppercase;" onblur="validatepan(this,'Pan No');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">

															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                        
																                            CIN No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtCinNo" runat="server" CssClass="input-sm similar-select1 validate[required]"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div id="tr5" runat="server" visible="false">
														                            <div class="form-group">
															                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																	                            <span style="color: Red">*</span>
																	                            <asp:Label ID="lblnameremark" runat="server" />
																                            </label>
																                            <div class="col-md-1 col-sm-2 col-xs-2">
																	                          <asp:DropDownList runat="server" ID="drpTitle" Width="155%" style="margin-left:1px;"><asp:ListItem>Mr.</asp:ListItem><asp:ListItem>Miss</asp:ListItem><asp:ListItem>Mrs</asp:ListItem></asp:DropDownList> 
																                            </div>
                                                                                            <div class="col-md-7 col-sm-6 col-xs-6">
																	                           <asp:TextBox ID="txtIndividualName" runat="server" CssClass="similar-select1 input-sm" Width="100%"  onkeypress="return Validate_individual_name(event);" onblur="ValidateRequired(this,'Individual/Sole Proprientary Name');"></asp:TextBox>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
														                            <div class="form-group">
															                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																	                            <span style="color: Red">*</span>
																	                            Address :
																                            </label>
																                            <div class="col-md-8 col-sm-6 col-xs-6">
																	                            <asp:TextBox ID="txtIndividualAddress" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
													                            </div>
													                            <div id="tr6" runat="server" visible="false">
														                            <div class="form-group">
															                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																	                            <span style="color: Red">*</span>
																	                            Phone :
																                            </label>
																                            <div class="col-md-8 col-sm-6 col-xs-6">
																	                            <asp:TextBox ID="txtIndividualPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="15"  onkeypress="return isDecimalKey(event);"></asp:TextBox>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
														                            <div class="form-group">
															                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																	                            <span style="color: Red">*</span>
																	                            Email Id :
																                            </label>
																                            <div class="col-md-8 col-sm-6 col-xs-6">
																	                            <asp:TextBox ID="txtIndividualEmail" runat="server" CssClass="input-sm similar-select1"  onblur="return ValidateIndividualEmail();"></asp:TextBox>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
													                            </div>
													                            <div id="tr7" runat="server">
														                            <div class="form-group">
															                            <div class="row">
																                            <div class="col-md-12 col-sm-12 col-xs-12">
																	                            <asp:CheckBox ID="chk2" runat="server" Text="&nbsp;&nbsp;Check if the person who will be operating the application is same as the Allottee"  AutoPostBack="true" OnCheckedChanged="checkbox2_checked_changed" />
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
													                            </div>

													                            <div class="form-group">
                                                                                   
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Name of the authorised representative :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtAuthorisedSignatory" runat="server" CssClass="input-sm similar-select1" onblur ="ValidateRequired(this,'Name of the person who  will operate');" ></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Address :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtSignatoryAddress" runat="server" CssClass="input-sm similar-select1" onblur ="ValidateRequired(this,'Address');"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Phone :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtSignatoryPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="15" onblur ="ValidateRequired(this,'Phone No');" onkeypress="return isDecimalKey(event);"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Email Id :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtSignatoryEmail" runat="server" CssClass="input-sm similar-select1" onblur="return ValidateSignatoryEmail();"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                                                            </div>
                                                                         
                                                                        </div>
                                                                        <div class="clearfix"></div>
															                            <div id="tr2" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>ShareHolders Details</b></div>
													                           
																                            <asp:GridView ID="gridshareholder" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" >
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Shareholder Name">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblShareholderName" runat="server" Text='<%#Eval("ShareHolderName") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtShareholderName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" onkeypress="return Validate_shareholder_name(event);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Share (In %)">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblShareper" runat="server" Text='<%#Eval("SharePer") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtShareper_insert" runat="server" CssClass="input-sm similar-select1" MaxLength="3" onblur ="ValidateFill(this);" onkeypress="return isDecimalKey(event);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPhone_insert" CssClass="input-sm similar-select1" MaxLength="15" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateShareHolderEmail();"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField>
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                               <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid1();" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" OnClick="insert_shareholder_details" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr4" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Trustee Details</b></div>
													                           
																                            <asp:GridView ID="Trustee_details_grid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Trustee Name">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblTrusteeName" runat="server" Text='<%#Eval("TrusteeName") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtTrusteeName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>

																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Address">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblTAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtTAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Phone No">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblTPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtTPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server"  onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Email ID">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblTEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtTEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateTrusteeEmail();"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField>
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                           <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid2();" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" OnClick="insert_trustee_details" />
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr8" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Directors Details</b></div>
													                           
																                            <asp:GridView ID="DirectorsGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Director Name">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblDirectorName" runat="server" Text='<%#Eval("DirectorName") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDirectorName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" ></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Din/Pan">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblDIN_PAN" runat="server" Text='<%#Eval("DIN_PAN") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDIN_PAN_insert" runat="server" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblDirectorAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDirectorAddress_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDirectorPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDirectorEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidateDirectorEmail();"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField>
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                           <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid3();" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" OnClick="insert_Director_details" />
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr9" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Partners Details</b></div>
													                           
																                            <asp:GridView ID="PartnershipFirmGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" >
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partner Name">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPartnerName" runat="server" Text='<%#Eval("PartnerName") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPartnerName_insert" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateFill(this);" ></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Partnership (In %)">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPartnershipPer" runat="server" Text='<%#Eval("PartnershipPer") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPartnershipPer_insert" runat="server" MaxLength="3" onblur ="ValidateFill(this);" onkeypress="return isDecimalKey(event);" CssClass="input-sm similar-select1"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Address">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPartnerAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPartnerAddress_insert" CssClass="input-sm similar-select1" onblur ="ValidateFill(this);" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Phone No">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPartnerPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPartnerPhone_insert" CssClass="input-sm similar-select1" MaxLength="10" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateFill(this);"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Email ID">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblPartnerEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtPartnerEmail_insert" CssClass="input-sm similar-select1" runat="server" onblur="return ValidatePartnerEmail();"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField>
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px"  OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
																				                            

                                                                                                         <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid4();"  CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" OnClick="insert_Partnership_details" />



																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
                                                                           <div runat="server" id="Screen11" class="col-md-12 col-sm-12 col-xs-12 text-center"></div>
                                                                        <div class="clearfix"></div>
                                                                               <div class="form-group" style="margin-top: 15px;">
															                            <div class="row">
																                           
																                            <div class="col-md-12 text-center col-sm-12 col-xs-12">
																	                        <asp:Button runat="server" ID="BtnSaveApplicant" CssClass="btn btn-primary btn-sm" Text="Save & Proceed"  OnClientClick="return ccheck1();" OnClick="BtnSaveApplicant_Click"   />
																                            </div>
																                          
															                            </div>
														                            </div>
												                            <asp:Label runat="server" ID="Label4" Visible="false"></asp:Label>
                                                                          <asp:Label runat="server" ID="LblAllotteeIdMain" Visible="false"></asp:Label>
                                                                           
                                                                           

                          </asp:View>

                                                <asp:View runat="server" ID="Documents_View">

                                                   

                                                        <asp:HiddenField ID="hfName" runat="server" />
                                            <div class="panel panel-default">
                                                <div class="panel-heading font-bold">
                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <span style="color: Red" class="">Please upload all document before final submission</span>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                                <div class="text-left">

                                                             <%--<asp:Button runat="server" Visible="false" ID="btnSample" Text="" OnClick="GetServiceChecklists_SP_BY_Condtion_Function" />--%>  
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

                                                <asp:View runat="server" ID="Payment_View">

                                                    <asp:Label runat="server" ID="lblIAID" Visible="false"></asp:Label>
                                                    <div style="background: #e2e2e2; text-align: right; padding: 10px 0; border: 1px solid #cacaca;">
                                                        <%--<asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" />--%>
                                                        <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" /><asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btn_Submit" Text="Submit" CssClass="btn btn-sm btn-primary" OnClick="btn_Submit_Click" Visible="false" />
                                                    </div>
                                                    <div id="Payment_Div">
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                    </div>

                                                    <asp:Label ID="lblControlId" runat="server" Visible="false"></asp:Label>
                                                </asp:View>

                                                <asp:View runat="server" ID="Final_View">
                                                    <div class="clearfix"></div>
                                                    <div id="FinalPrint">
                                                        <asp:PlaceHolder ID="PH_FinalView" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                    <div class="text-center">
                                                    </div>
                                                </asp:View>
                                                <asp:View runat="server" ID="View_leasedeedtolease">                                                                                       
                                            <div class="clearfix"></div>                                           
                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                

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
                                                <asp:Button ID="btnSubmitnew" CssClass="btn-sm btn-primary ey-bg pull-right" Style="margin-top: 3px; padding: 0px 10px;" Text="Save" OnClick="btnSubmitnew_Click" runat="server" OnClientClick="return" />
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
                                                                    GridLines="Horizontal" PageSize="10" OnRowCommand="GridView3_RowCommand"
                                                                    >
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
                                                             <asp:Button runat="server" Style="background: #ffc511; border: 1px solid #ccc; color: #000; font-size: 14px;" ID="btn_SubmitWithoutFees" Text="Submit" CssClass="btn btn-sm btn-primary" OnClick="btn_SubmitWithoutFees_Click" Visible="false" />
                                                        </div>
                                                    </div>
                                                </asp:View>

                                            </asp:MultiView>
                                             
                                        </div>
                                    </div>
                            <asp:Label ID="lblAllotteeID"  runat = "server" Visible="false"></asp:Label>
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
                                   <%-- <asp:Label ID="lblAllotmentLetterNo" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblRegionalOffice" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIndustrialArea" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAllotteeName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblFirmCompanyName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSignatoryMobile" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSIgnatoryEmail" runat="server" Visible="false"></asp:Label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

      <script>     


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


          function validatepan() {

              var panVal = document.getElementById("<%= txtPanNo.ClientID %>").value;
            var lblMessageError = document.getElementById("<%= lblMessageError.ClientID %>");
            var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
            if (panVal.length > 0) {
                if (panVal != "") {
                    if (regpan.test(panVal)) {
                        document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "";
                        hideError();
                        return true;
                    } else {

                        document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "Red";
                        document.getElementById("<%= txtPanNo.ClientID %>").value = "";
                        document.getElementById("<%= txtPanNo.ClientID %>").focus();
                        showError();
                        document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Pan Card";
                        return false;
                    }
                }
            } else {
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Pan Card Is Required Field";
                document.getElementById("<%= txtPanNo.ClientID %>").style.borderColor = "Red";

                document.getElementById("<%= txtPanNo.ClientID %>").focus();
                  return false;
              }
          }

      

          function ccheck1() {
              var remark = true;
              var ddlcompany = document.getElementById("<%= ddlcompanytype.ClientID %>");
            var txtCompanyname = document.getElementById("<%= txtCompanyname.ClientID %>");
            var txtPanNo = document.getElementById("<%= txtPanNo.ClientID %>");
            var txtIndividualName = document.getElementById("<%= txtIndividualName.ClientID %>");
            var txtIndividualAddress = document.getElementById("<%= txtIndividualAddress.ClientID %>");
            var txtIndividualPhone = document.getElementById("<%= txtIndividualPhone.ClientID %>");
            var txtIndividualEmail = document.getElementById("<%= txtIndividualEmail.ClientID %>");
            var txtAuthorisedSignatory = document.getElementById("<%= txtAuthorisedSignatory.ClientID %>");
            var txtSignatoryAddress = document.getElementById("<%= txtSignatoryAddress.ClientID %>");
            var txtSignatoryPhone = document.getElementById("<%= txtSignatoryPhone.ClientID %>");
            var txtSignatoryEmail = document.getElementById("<%= txtSignatoryEmail.ClientID %>");

            if (ddlcompany.selectedIndex == 0) {
                ddlcompany.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                ddlcompany.style.borderColor = "";
            }
            if (txtCompanyname.value.length <= 0) {
                txtCompanyname.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtCompanyname.style.borderColor = "";
            }
            if (txtPanNo.value.length <= 0) {
                txtPanNo.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPanNo.style.borderColor = "";
            }

            if (txtAuthorisedSignatory.value.length <= 0) {
                txtAuthorisedSignatory.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAuthorisedSignatory.style.borderColor = "";
            }
            if (txtSignatoryAddress.value.length <= 0) {
                txtSignatoryAddress.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSignatoryAddress.style.borderColor = "";
            }
            if (txtSignatoryPhone.value.length <= 0) {
                txtSignatoryPhone.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSignatoryPhone.style.borderColor = "";
            }
            if (txtSignatoryEmail.value.length <= 0) {
                txtSignatoryEmail.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtSignatoryEmail.style.borderColor = "";
            }
            if (ddlcompany.selectedIndex == 1) {
                if (txtIndividualName.value.length <= 0) {
                    txtIndividualName.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtIndividualName.style.borderColor = "";
                }
                if (txtIndividualAddress.value.length <= 0) {
                    txtIndividualAddress.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtIndividualAddress.style.borderColor = "";
                }
                if (txtIndividualPhone.value.length <= 0) {
                    txtIndividualPhone.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtIndividualPhone.style.borderColor = "";
                }
                if (txtIndividualEmail.value.length <= 0) {
                    txtIndividualEmail.style.borderColor = '#e52213';
                    remark = false;
                }
                else {
                    txtIndividualEmail.style.borderColor = "";
                }

            }

            if (remark == false) {

                alert("Fill All Required Field");
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                  return false;
              } else {
                  hideError();
                  return true;
              }

          }


          function IsValidEmail(email) {
              var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
              return expr.test(email);
          };
          function ValidateSignatoryEmail() {
              var email = document.getElementById("<%= txtSignatoryEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").value = "";
                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").focus();
                    return false;
                }
                else {

                    document.getElementById("<%= txtSignatoryEmail.ClientID %>").style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";

                    return true;
                }
            }
            else {

                document.getElementById("<%= txtSignatoryEmail.ClientID %>").style.borderColor = "#e52213";
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Signatory Email Id Is Required Field";
                document.getElementById("<%= txtSignatoryEmail.ClientID %>").focus();
                  return false;
              }
          }

          function ValidateShareHolderEmail() {
              var email = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtEmail_insert")).ClientID %>');

            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                      email.focus();
                      return false;
                  }
                  else {

                      email.style.borderColor = "";
                      hideError();
                      email.innerText = "";

                      return true;
                  }
              }
          }
          function ValidatePartnerEmail() {
              var email = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert")).ClientID %>');

            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                      return true;
                  }

              }

          }
          function ValidateTrusteeEmail() {
              var email = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txttEmail_insert")).ClientID %>');


            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                      return true;
                  }

              }
          }
          function ValidateDirectorEmail() {
              var email = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert")).ClientID %>');


            if (email.value.length > 0) {
                if (!IsValidEmail(email.value)) {

                    email.value = "";
                    email.style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    return false;

                }
                else {

                    email.style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                      return true;
                  }

              }

          }
          function ValidateIndividualEmail() {
              var email = document.getElementById("<%= txtIndividualEmail.ClientID %>").value;
            if (email.length > 0) {
                if (!IsValidEmail(email)) {

                    document.getElementById("<%= txtIndividualEmail.ClientID %>").value = "";
                    document.getElementById("<%= txtIndividualEmail.ClientID %>").style.borderColor = '#e52213';
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Invalid Email Id";
                    document.getElementById("<%= txtIndividualEmail.ClientID %>").focus();
                    return false;

                }
                else {

                    document.getElementById("<%= txtIndividualEmail.ClientID %>").style.borderColor = "";
                    hideError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "";
                    return true;
                }

            }
            else {

                document.getElementById("<%= txtIndividualEmail.ClientID %>").style.borderColor = "#e52213";
                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Individual Email Id Is Required Field";
                document.getElementById("<%= txtIndividualEmail.ClientID %>").focus();
                  return false;
              }
          }

          function validate_shareper(evt) {
              var charCode = (evt.which) ? evt.which : evt.keyCode
              if (charCode != 46 && charCode > 31
                  && (charCode < 48 || charCode > 57)) {
                  return false;
              } else {

                  var txt = document.getElementById('<%#((TextBox)gridshareholder.FooterRow.FindControl("txtShareper_insert")).ClientID %>');

                  if (txt.value.length > 0) {

                      txt.style.borderColor = "";
                      return true;

                  }
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
          function checkGrid1() {
              var remark = true;
              var txtShareholderName_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtShareholderName_insert")).ClientID %>');
            var txtShareper_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtShareper_insert")).ClientID %>');
            var txtAddress_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtAddress_insert")).ClientID %>');
            var txtPhone_insert = document.getElementById('<%=((TextBox)gridshareholder.FooterRow.FindControl("txtPhone_insert")).ClientID %>');

            if (txtShareholderName_insert.value.length <= 0) {
                txtShareholderName_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareholderName_insert.style.borderColor = "";
            }
            if (txtShareper_insert.value.length <= 0) {
                txtShareper_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareper_insert.style.borderColor = "";
            }
            if (txtAddress_insert.value.length <= 0) {
                txtAddress_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress_insert.style.borderColor = "";
            }
            if (txtPhone_insert.value.length <= 0) {
                txtPhone_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPhone_insert.style.borderColor = "";
            }

            if (remark == false) {

                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                  return false;
              } else {
                  hideError();
                  return true;
              }

          }
          function checkGrid2() {
              var remark = true;
              var txtShareholderName_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert")).ClientID %>');
            var txtAddress_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert")).ClientID %>');
            var txtPhone_insert = document.getElementById('<%=((TextBox)Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert")).ClientID %>');

            if (txtShareholderName_insert.value.length <= 0) {
                txtShareholderName_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareholderName_insert.style.borderColor = "";
            }

            if (txtAddress_insert.value.length <= 0) {
                txtAddress_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress_insert.style.borderColor = "";
            }
            if (txtPhone_insert.value.length <= 0) {
                txtPhone_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPhone_insert.style.borderColor = "";
            }

            if (remark == false) {

                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                  return false;
              } else {
                  hideError();
                  return true;
              }

          }


          function checkGrid3() {
              var remark = true;
              var txtShareholderName_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert")).ClientID %>');
            var txtShareper_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert")).ClientID %>');
            var txtAddress_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert")).ClientID %>');
            var txtPhone_insert = document.getElementById('<%=((TextBox)DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert")).ClientID %>');

            if (txtShareholderName_insert.value.length <= 0) {
                txtShareholderName_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareholderName_insert.style.borderColor = "";
            }
            if (txtShareper_insert.value.length <= 0) {
                txtShareper_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareper_insert.style.borderColor = "";
            }

            if (txtAddress_insert.value.length <= 0) {
                txtAddress_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress_insert.style.borderColor = "";
            }
            if (txtPhone_insert.value.length <= 0) {
                txtPhone_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPhone_insert.style.borderColor = "";
            }

            if (remark == false) {

                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                  return false;
              } else {
                  hideError();
                  return true;
              }

          }
          function checkGrid4() {
              var remark = true;
              var txtShareholderName_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert")).ClientID %>');
            var txtShareper_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert")).ClientID %>');

            var txtAddress_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert")).ClientID %>');
            var txtPhone_insert = document.getElementById('<%=((TextBox)PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert")).ClientID %>');

            if (txtShareholderName_insert.value.length <= 0) {
                txtShareholderName_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareholderName_insert.style.borderColor = "";
            }
            if (txtShareper_insert.value.length <= 0) {
                txtShareper_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtShareper_insert.style.borderColor = "";
            }

            if (txtAddress_insert.value.length <= 0) {
                txtAddress_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtAddress_insert.style.borderColor = "";
            }
            if (txtPhone_insert.value.length <= 0) {
                txtPhone_insert.style.borderColor = '#e52213';
                remark = false;
            }
            else {
                txtPhone_insert.style.borderColor = "";
            }

            if (remark == false) {

                showError();
                document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Value";

                  return false;
              } else {
                  hideError();
                  return true;
              }

          }

          function dosomething(obj) {
              var txtObj = document.getElementById(obj.id);
              alert(txtObj);
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

              Popup($('#FinalPrint').html());
          }


          function Popup(data) {
              var mywindow = window.open('', 'my div');
              mywindow.document.write('<html><head><title style="font-weight:bold;">Application For Transfer Of Plot</title>');
              mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
              mywindow.document.write('<link href="css/bootstrap.min.css" rel="stylesheet" />');

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
    

</body>
</html>
