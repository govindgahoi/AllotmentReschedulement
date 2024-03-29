﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandAllotmentApplication.aspx.cs" Inherits="Allotment.LandAllotmentApplication" %>

<%@ Register Src="~/ucAllotmentDeposits.ascx" TagPrefix="uc1" TagName="ucAllotmentDeposits" %>

<%@ Register Src="~/UC_ApplicationFinalView.ascx" TagPrefix="uc1" TagName="UC_ApplicationFinalView" %>

<%@ Register Src="~/UC_ApplicationFinalViewHTML.ascx" TagPrefix="uc1" TagName="UC_ApplicationFinalViewHTML" %>


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
 
    <script src="assets/js/bootstrap.min.js"></script>

    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>

    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>

   
       <style>
           .modal-open{
                overflow:auto !important;
           }
           .nav-pills {
                margin-left:0 !important;
           }
           .nav-pills > li + li {
            margin-left: 0px !important;
           }
           .pad-lt0 {
                padding-left:0 !important;
           }
           .pad-rt0 {
                padding-right:0 !important;
           }
               @media only screen and (max-width: 768px) {
                    .form-group label.text-right {
                        text-align:left !important;
                    }
                    .form-group .col-sm-6 {
                        width:50% !important;
                    }
                    .right-niveshban {
                        text-align:center;
                    }
                    .left-niveshban {
                        text-align:center;
                    }
                }
               
            @media only screen and (min-width: 768px) {
                .right-niveshban {
                    text-align:right;
                }
                .left-niveshban {
                    text-align:left;
                }
            }
            .form-group label {
                font-weight:700 !important;
            }
           .modal-open {
            overflow:auto;
           }
           input[type=file] {
            margin:0 !important;
            width:207px;
           }

           .hide{
               display:none;
           }
           .show{
               display:block;
           }

           #UpdateProgress1 {
               position: fixed;
               width: 100%;
               height: 100%;
               z-index: 99999;
               background: rgba(0,0,0,0.21176470588235294);
           }
           #UpdateProgress1 .fgh{
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
                margin-left:0 !important;
           }
        .myul-tabs li {
            width: 100%;
            border-top:1px solid #fff;
        }
        .myul-tabs li a:after {
            display:none;
        }
        .myul-tabs li a:before {
            display:none;
        }
        h4.modal-title {
            margin-right:18px !important;
        }
        .mynew-panel-head {
            font-size: 14px !important; 
            font-weight: 600; 
            background: #2d2d2d; 
            color: #ffc511 !important;
            text-align: center !important;
        }
        .modal.fade.in {
            background:rgba(0, 0, 0, 0.51);
        }
        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
           .pad-rt0 {
            padding-right:0;
           }
           .pad-lt0 {
            padding-left:0;
           }
        }
        .modal-header{
            padding:2px !important;
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
                  <%-- Modal Section Start --%>
    <div class="modal fade" id="myModal" role="dialog" tabindex="-1">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Confirmation Alert</h4>
                                    </div>
                                    <div class="modal-body">
                                        <button type="button" id="btnCloseModal" class="ey-bg btn-primary pull-right" data-dismiss="modal"  data-target="#myModal" style="margin:2px 5px 0 0;display:none;">Close</button>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                             Dear Applicant,<br />
                                                We have completed and all the required information to UPSIDC and also have raised a request of <i class="fa fa-inr"></i><asp:Label ID="lblAmt" runat="server"></asp:Label> to UdhyogBandhu for payment.<br />
                                                <div class="" style="padding-top: 4px;font-weight:700;">
                                                    You may now proceed to pay the consolidated payment through Udhyog Bandhu.
                                                </div><br />
                                                <div class="note" style="    min-height: 24px; padding: 10px;"><strong>Note:</strong> The application submitted by you will be forwarded for further processing to the concerned offices of UPSIDC subject to the clearance of payment through Nivesh Mitra to UPSIDC.</div>
                                            <div class="clearfix"></div>

                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="separation" />
                                        <div style="padding:0px 0 4px 1px;">
                                            <div class="col-md-8" style="display:none;" >
                                                <asp:CheckBox ID="chkSendMail" runat="server" /> Send Application Form Through Mail
                                            </div>
                                           
                                            <div class="col-md-4">
                                                <asp:Button ID="btnIAccept" runat="server" CssClass="btn btn-sm btn-primary btn-popup pull-right" Style="float:left" Text="Close" OnClick="btnIAccept_Click"/>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>


                 <div class="modal fade" id="myModalUPSIDC" role="dialog" tabindex="-1">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title mynew-panel-head text-center">Confirmation Alert</h4>
                                    </div>
                                    <div class="modal-body">
                                        <button type="button" id="btnCloseModalUPSIDC" class="ey-bg btn-primary pull-right" data-dismiss="modal"  data-target="#myModal" style="margin:2px 5px 0 0;display:none;">Close</button>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                             Dear Applicant,<br />
                                                Your Application Is Finalised Successfully.<br />
                                                
                                                <div class="note" style="    min-height: 24px; padding: 10px;"><strong>Note:</strong> The application submitted by you will be forwarded for further processing to the concerned offices of UPSIDC subject to the clearance of payment by you to UPSIDC.</div>
                                            <div class="clearfix"></div>

                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="separation" />
                                        <div style="padding:0px 0 4px 1px;">
                                            
                                           
                                            <div class="col-md-4">
                                                <asp:Button ID="btnFinaliseUPSIDC" runat="server" CssClass="btn btn-sm btn-primary btn-popup pull-right" Style="float:left" Text="Close" OnClick="btnFinaliseUPSIDC_Click"/>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>


                        <input type="button" id="btnModal" style="display: none;" data-toggle="modal" data-target="#myModal" data-backdrop="static" /> 
                  <input type="button" id="btnModalUPSIDC" style="display: none;" data-toggle="modal" data-target="#myModalUPSIDC" data-backdrop="static" /> 
  
                 <%-- End Of Modal Section  --%>

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
						
					</div>

				
					<div class="row" id="SideDiv">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="panel panel-default">
                                <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
									<div class="row">
                                            <div class="col-md-4 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                    <li></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12 text-center">
                                                <!--<div style="font-size: 34px; font-weight: 600; margin-top: 10px;">Nivesh Mitra</div>
                                                <span style="font-size: 17px;">Single Window Portal ,Govt. of Uttar Pradesh</span>-->
                                                <img src="/images/upsidclogo.png" style="width:211px;margin-top: 12px;" alt="Goverment" />
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                                </ul>
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
                                <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">Application Form for Land Allotment <span class="pull-right">Form No.: <asp:Label runat="server" id="lblFormNo"></asp:Label> </span></div>
                               
                                
                                

                      
                                
                                <div class="row">
                                            <div class="col-md-2 pad-rt0 pad-rt0">

                                                <style>
                                                    #sub_menu ul {
                                                        margin-left:0 !important;
                                                    }
                                                </style>

                                                   <asp:Menu
                                                        id="sub_menu"
                                                        Orientation="Vertical"   
                                                        OnMenuItemClick="Menu1_MenuItemClick"
                                                        StaticMenuStyle-CssClass="nav nav-pills myul-tabs"
                                                        StaticSelectedStyle-CssClass="active selected highlighted"
                                                        Runat="server" Style="margin-left:0;">
       
                                                        <Items>
                                                        <asp:MenuItem Text="Action At Your End" Value="6" />
                                                        <asp:MenuItem Text="Applicant Detail" Value="0" />
                                                        <asp:MenuItem Text="Photo & Sign" Value="1" />
                                                        <asp:MenuItem Text="Project Details" Value="2" />
                                                        <asp:MenuItem Text="Payee Accounts Details" Value="7" />
                                                        <asp:MenuItem Text="Documents Upload" Value="3" />
                                                        <asp:MenuItem Text="Payment" Value="4" />
                                                        <asp:MenuItem Text="Final Submission" Value="5" />
                     

                                                        </Items>    

                                                    </asp:Menu>
                                            </div>
                                            <div class="col-md-10 pad-lt0" style="border-left:1px solid #ccc;">

                                                    <div id="divMessageError" class="MessagePennel" runat="server" style="display:none;">
                            <label>
                                <span class="check-cross" runat="server">✖</span>
                                
                                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                            </label>
                        </div>
                               
                                                             <asp:MultiView runat="server" ID="Allotment">  
                                     
                                    <asp:View runat="server" ID="View1">
                                                                        <asp:Label runat="server" ID="lblChosePlot" Visible="false"></asp:Label>
                                                                           <asp:HiddenField runat="server" ID="imgSrc" />
                                                                            <asp:HiddenField runat="server" ID="imgHasFile" />
                                                                            <div class="panel-heading">Basic Details</div>
                                                                            <div class="table-responsive">
                                                                           <table class="table-bordered table table table-hover request-table myreq-col">
                                                                                <tr> 
                                                                                    <td colspan="5"><b></b></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Regional Office </th>
                                                                                    <th>Industrial Area</th>
                                                                                    <th>Application No</th>
                                                                                    <th>Required Area(Sqmt)</th>
                                                                                    <th style="display:none;">Application Status </th>
                                                                                </tr>
                                                                                <tr><td><asp:Label runat="server" ID="lblRegionalOffice" ></asp:Label></td><td><asp:Label runat="server" ID="lblIndustrialArea"></asp:Label></td><td><asp:Label runat="server" ID="lblRefNo"></asp:Label></td><td><asp:Label runat="server" ID="lblRequiredArea" Text="1000 Sqr.Mtr"></asp:Label></td><td style="display:none;"><asp:Label runat="server" ID="lblApplicationStatus" Text="Not Available"></asp:Label></td></tr>
                   
                                                                            </table>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-12 col-sm-12 col-xs-12">
													                            <p class="panel-heading"><b>Particulars of the Applicant in whose name plot/shed to be Allotted</b></p>
													                            <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Constitution of Firm/Company :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="ddlcompanytype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyTypeddl_selectedindex_changed" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" ></asp:DropDownList>
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
																                            <asp:TextBox ID="txtCinNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
															                            </div>
														                            </div>
													                            </div>
                                                                                 <div class="clearfix"></div>
													                            <hr class="myhrline" />
													                            <div class="form-group">
														                            <div class="row">

															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                        
																                            GST No :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtGSTNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
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
																	                            <asp:TextBox ID="txtIndividualAddress" runat="server" CssClass="input-sm similar-select1" onblur ="ValidateRequired(this,'Individual Address');"></asp:TextBox>
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
																	                            <asp:TextBox ID="txtIndividualPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="10" onblur ="ValidateRequired(this,'Individual Phone No');" onkeypress="return isDecimalKey(event);"></asp:TextBox>
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
																	                            <asp:CheckBox ID="chk2" runat="server" Text="&nbsp;&nbsp;Check if the person who will be operating the application is same as the Allottee" OnCheckedChanged="checkbox2_checked_changed"  AutoPostBack="true" />
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
																                            <asp:TextBox ID="txtSignatoryPhone" runat="server" CssClass="input-sm similar-select1" MaxLength="10" onblur ="ValidateRequired(this,'Phone No');" onkeypress="return isDecimalKey(event);"></asp:TextBox>
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
                                                                            <div class="col-md-3 col-sm-6 col-xs-12" style="display:none;">
                                                                                <div style="border:1px solid #ccc;text-align:center;padding:5px;">
                                                                                    <table style="margin:0 auto;">
                                                                                        <tbody><tr>
                                                                                            <td>
                                                                                                <asp:Image id="ImgPrv1" runat="server" src="/images/account-icon-5.jpg" style="border: 1px solid #ccc;margin:5px 0px;max-width:153px;"/>
                                                                                                </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:FileUpload runat="server" ID="FuplodApplicantImage1" onchange="ShowImagePreview(this);" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody></table>
                                                                                      <hr class="myhrline"  style="margin:5px;"/>
                                                                                   
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clearfix"></div>
															                            <div id="tr2" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>ShareHolders Details</b></div>
													                           
																                            <asp:GridView ID="gridshareholder" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="ShareHolderDelete_Click">
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
																				                               <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid1();" OnClick="insert_shareholder_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr4" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Trustee Details</b></div>
													                           
																                            <asp:GridView ID="Trustee_details_grid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="TrusteeDelete_Click">
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
																				                           <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid2();" OnClick="insert_trustee_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr8" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Directors Details</b></div>
													                           
																                            <asp:GridView ID="DirectorsGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="DirectorDelete_Click">
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
																				                           <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid3();" OnClick="insert_Director_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
															                            <div id="tr9" runat="server" visible="false">
																                            <hr style="margin: 8px 0; border-top: 1px solid #9c9999;" />
                                                                                            <div class="panel-heading"><b>Partners Details</b></div>
													                           
																                            <asp:GridView ID="PartnershipFirmGrid" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="PartnershipDelete_Click">
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
																				                            

                                                                                                         <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid4();" OnClick="insert_Partnership_details"  CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />



																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>
															                            </div>
															                            <div class="clearfix"></div>
                                                                           <div runat="server" id="Screen11" class="col-md-12 col-sm-12 col-xs-12 text-center" visible="false"><asp:Button runat="server" ID="BtnSaveApplicant" CssClass="btn btn-sm btn-primary" Text="Proceed" Style="text-align:center;padding: 2px 10px !important;margin: 10px 0;" OnClientClick="return ccheck1();" OnClick="BtnSaveApplicant_Click" /></div>
                                                                           <div  runat="server" id="Screen12" class="col-md-12 col-sm-12 col-xs-12 text-center"  visible="false"><asp:Button runat="server" ID="BtnSaveApplicant1" CssClass="btn btn-sm btn-primary" Text="Proceed" Style="text-align:center;padding: 2px 10px !important;margin: 10px 0;" OnClientClick="return ccheck1();" OnClick="BtnSaveApplicant1_Click" /></div>
												                            <asp:Label runat="server" ID="LblAllotteeId" Visible="false"></asp:Label>
                                                                          <asp:Label runat="server" ID="LblAllotteeIdMain" Visible="false"></asp:Label>
                                                                           
                                                                          
                            

                                                                            <asp:Label id="lblImageName" runat="server" Visible="false"></asp:Label>


                                                                       </asp:View>

                                    <asp:View runat="server">


                                        <div class="row">
    <div class="panel panel-default">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-1 col-sm-12 col-xs-12"></div>
            <div class="col-md-10 col-sm-12 col-xs-12" style="margin-bottom:10px;">
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                        <div class="myborder" style="border:1px solid #ccc;">
                            <div class="panel-heading">Photograph</div>
                            <div style="height:200px;padding:5px;"><asp:Image id="ImgPrv" runat="server" src="/images/account-icon-5.jpg" class="img-sign" alt="image" style="height: 200px;margin: 0 auto;"/>
                                   <asp:Image id="Image1" runat="server" style="height: 200px;margin: 0 auto;" Visible="false"/>
                                   <asp:Label runat ="server" ID="lblImagetype" visible="false"></asp:Label>
                                                                                              
                            </div><br />   
                            <div style="border:1px solid #ccc;padding:5px;">
                                <asp:FileUpload ID="FuplodApplicantImage" onchange="ShowImagePreview(this);" Width="100%" CssClass="form-control" runat="server" />   
                                <button runat="server" id="btnSaveImage" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px;margin:5px 0;" onserverclick="btnSaveImage_ServerClick">Upload Photograph</button>
                                <div class="clearfix"></div>
                            </div>
                        </div>                        
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12 text-center">
                        <div class="myborder" style="border:1px solid #ccc;">
                            <div class="panel-heading">Signature</div>
                            <div style="height:200px;padding:5px;"><img id="ImgPrvSign" src="images/signature.png" runat="server" class="img-sign" alt="image" style="margin:50px auto 0 auto;height:100px;"/>
                                <asp:Image id="Image2" runat="server" style="margin:50px auto 0 auto;height:100px;" Visible="false"/>

                            </div><br />
                            <div style="border:1px solid #ccc;padding:5px;">
                                <asp:FileUpload ID="FuplodApplicantSign" Width="100%" onchange="ShowSignPreview(this);" CssClass="form-control" runat="server" /> 
                                <button runat="server" id="btnSaveSign" class="btn-primary btn-sm ey-bg" style="padding: 2px 6px;margin:5px 0;" onserverclick="btnSaveSign_ServerClick" >Upload Signature</button>
                                <div class="clearfix"></div>
                            </div>
                        </div> 
                    </div>  
                  
                </div>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12"></div>
        </div>
    </div>
</div>
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
																                            
                                                                                             <asp:DropDownList ID="ddlTypeOfIndustry" runat="server"  CssClass="chosen margin-left-z input-sm similar-select1" ></asp:DropDownList>
															                          
                                                                                        
                                                                                        </div>
														                            </div>
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Proposed Product :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txttypeofindustry" runat="server" CssClass="input-sm similar-select1"  onblur ="ValidateRequired(this,'Proposed Product');"></asp:TextBox>
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
																                             <i class="fa fa-inr"></i><asp:TextBox ID="txtestimatedcost" MaxLength="8" runat="server" CssClass="input-sm similar-select1" Width="93%" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Estimated Cost of the project');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                           
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Estimated Employment Generation(In Nos) :
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtestimatedemployment" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Estimated Employment Generation');"></asp:TextBox>
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
																                            <asp:TextBox ID="txtProjectStartMonths" runat="server" CssClass="input-sm similar-select1" MaxLength="2" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Estimated Project Start Period(In Months)');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                           
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Related Work Experience(In Years)&nbsp;:
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtWorkExperience" runat="server" CssClass="input-sm similar-select1" MaxLength="4" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Related Work Experience(In Years)');"></asp:TextBox>
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
																                            <asp:TextBox ID="txtcoveredarea" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Covered Area');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                            
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                            Open Area &nbsp;(In %)&nbsp;:
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <asp:TextBox ID="txtopenarearequired" runat="server" MaxLength="2" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Open Area');"></asp:TextBox>
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
																                            <i class="fa fa-inr"></i><asp:TextBox ID="txtland" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Land');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                            
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                            <span style="color: Red">*</span>
																                           Investment In Building&nbsp;(In Lacs)&nbsp;:
															                            </label>
															                            <div class="col-md-2 col-sm-6 col-xs-6">
																                            <i class="fa fa-inr"></i><asp:TextBox ID="txtbuilding" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Building');"></asp:TextBox>
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
																                            <i class="fa fa-inr"></i><asp:TextBox ID="txtmachinery" MaxLength="5" Width="93%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Machinery & Equipments');"></asp:TextBox>
															                            </div>
                                                                                        <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
														                           
														                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                       
															                          Investment In Other Fixed Assets&nbsp;(In Lacs):
														                            </label>
														                            <div class="col-md-2 col-sm-6 col-xs-6">
															                            <i class="fa fa-inr"></i><asp:TextBox ID="txtFixedAssets" MaxLength="5" CssClass="input-sm similar-select1" Width="93%" runat="server" onkeypress="return isDecimalKey(event);" ></asp:TextBox>

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
															                                <div style="float:left;width:2%;"><i class="fa fa-inr"></i></div>
                                                                                            <div style="float:left;width:98%;"><asp:TextBox ID="txtOtherExpenses" MaxLength="5" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);"  ></asp:TextBox></div>

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
																	                           <asp:DropDownList runat="server" ID="drpIACategory"  CssClass="chosen margin-left-z input-sm similar-select1" OnSelectedIndexChanged="drpIACategory_SelectedIndexChanged" AutoPostBack="true">
                                                                                                   
																	                           </asp:DropDownList>
																                            </div>
														                          
															                     </div></div> <div class="clearfix"></div>
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
                                                                                   </div></div>
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
																		                            <asp:TextBox ID="txtpowerreq" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Power Requirement (in KW)');"></asp:TextBox>
																	                            </div>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <div class="panel panel-default hide">
															                            <div class="panel-heading font-bold">Telephone Requirement</div>
															                            <div class="panel-body" style="padding: 0px !important;">
																                            <div class="row aks-row">
																	                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																		                            First Year&nbsp;:
																	                            </label>
																	                            <div class="col-md-2 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txttelephonefirstyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	                            </div>
                                                                                                <div class="hidden-lg hidden-md"><div class="clearfix"></div></div>
                                                                                                 <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																		                            Second Year&nbsp;:
																	                            </label>
																	                            <div class="col-md-2 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txttelephonefirstyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	                            </div>
																                            </div>
																                            <div class="row aks-row" style="display:none;">
																	                            <label class="col-md-4 col-sm-6 col-xs-12 text-right">
																		                            Ultimate Requirement&nbsp;:
																	                            </label>
																	                            <div class="col-md-4 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txttelephoneUltimateyearreq1" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																	                            </div>
																	                            <div class="col-md-4 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txttelephoneUltimateyearreq2" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
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
																	                            <div style="float:left;width:2%;"><i class="fa fa-inr"></i></div>
                                                                                                <div style="float:left;width:98%;"><asp:TextBox ID="txtNetWorth" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Net Worth');"></asp:TextBox></div>
																                            </div>
                                                                                            </div>
                                                                                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                                <span style="color: Red">*</span>
																	                            Net Turn Over(In Lac):
																                            </label>
																                            <div class="col-md-8 col-sm-6 col-xs-6">
																	                            <div style="float:left;width:2%;"><i class="fa fa-inr"></i></div>
                                                                                                <div style="float:left;width:98%;"><asp:TextBox ID="txtTurnover" Width="100%" CssClass="input-sm similar-select1" runat="server" onkeypress="return isDecimalKey(event);" onblur ="ValidateRequired(this,'Net Worth Turnover');"></asp:TextBox></div>
																                            </div>
															                            </div>
														                            </div>
														                            <div class="clearfix"></div>
														                            <hr class="myhrline" />
														                            <div class="form-group">
															                            <div class="row">
																                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
                                                                                                <span style="color: Red">*</span>
																	                            Is plot required for expansion of unit located in IA ?:

																                            </label>
																                            <div class="col-md-8 col-sm-6 col-xs-6">
																	                            <asp:DropDownList runat="server" ID="Ddl_Expansion" CssClass="chosen similar-select1 margin-left-z dropdown-toggle input-sm" OnSelectedIndexChanged="Ddl_Expansion_SelectedIndexChanged" AutoPostBack="true">
																		                            <asp:ListItem>--Select--</asp:ListItem>
																		                            <asp:ListItem Value="YES">YES</asp:ListItem>
																		                            <asp:ListItem Value="No">No</asp:ListItem>
																	                            </asp:DropDownList>
																                            </div>
															                            </div>
														                            </div>

                                                                                     <div id="DivExpansion" runat="server" visible="false">
													                            <div class="panel panel-default">
                                                                                       <div class="panel-heading font-bold">Existing Unit details</div>
															                            <div class="panel-body" style="padding: 0px !important;">
                                                                                             <div class="row aks-row">
																	                            <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                          IA Name&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                          <asp:Label runat="server" ID="lblIAName"></asp:Label>
																	                            </div></div>
																                            <div class="row aks-row">
																	                            <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                           Plot No&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txtExistingPlotNo" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Enter Existing Plot No');"></asp:TextBox>
																	                            </div></div>
                                                                                              <div class="row aks-row">
                                                                                                 <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                           Allotment No&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txtAllotmentNo" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Enter Allotment No');"></asp:TextBox>
																	                            </div></Div>
                                                                                             <div class="row aks-row">
                                                                                                 <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                           Allotment Date&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txtAllotmentDate" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Enter Allotment Date');" placeholder="DD/MM/YYYY"></asp:TextBox>
																	                            </div></Div>
                                                                                              <div class="row aks-row">
                                                                                                 <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                           Allottee Name&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txtAllotteeExisName" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Enter Allottee Name');"></asp:TextBox>
																	                            </div></Div>
                                                                                              <div class="row aks-row">
                                                                                                 <label class="col-md-4 col-sm-6 col-xs-6 form-inline text-right">
                                                                                                    <span style="color: Red">*</span>
																		                           Product Manufactured&nbsp;:
																	                            </label>
																	                            <div class="col-md-8 col-sm-6 col-xs-6">
																		                            <asp:TextBox ID="txtManufacturedProduct" CssClass="input-sm similar-select1" runat="server" onblur ="ValidateRequired(this,'Enter Product Manufactured');"></asp:TextBox>
																	                            </div>
																                            </div>
															                            </div>

                                                                                    </div></div>
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
																	                            <%--<span class="text-center"><a href="#" runat="server" class="btn btn-default" style="padding: 3px 6px;" onserverclick="BtnProjectInsert_Click">Save & Proceed&nbsp;<i class="fa fa-long-arrow-right" aria-hidden="true"></i></a></span>
																	                            --%><asp:Button ID="BtnProjectInsert" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtnProjectInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton"  runat="server" Text="Save" OnClientClick="return ccheck2();" />
																                            </div>
																                            <div class="col-md-4"></div>
															                            </div>
														                            </div>

                                                        </asp:View>
                                 
                                    <asp:View runat="server" ID="View3">
                                                        <div class="panel panel-default">
														                            <div class="panel-heading font-bold">
															                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                                            <span style="color: Red" class="">Please upload all document before final submission</span>
                                                                                        </div>
                                                           
                                                                                        <div class="clearfix"></div>
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
                                   
                                                    <span class="col-md-10">
                                                        <asp:FileUpload ID="FileUpload4" runat="server" />
                                                    </span>
                                                    <span class="col-md-2">
                                                        <asp:LinkButton ID="imgdocuments" runat="server" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="Upload" Text='<i class="fa fa-upload"></i>' />

                                                    </span>                                         


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
                                                                        <asp:Button runat="server" ID="btnFinalSubmit" Text="Proceed" OnClick="btnFinalSubmit_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" /> 
                                                                        <!--<asp:Button runat="server" ID="btnProceed1" Text="Proceed" CssClass="btn btn-sm btn-primary" Style="margin-left:3px;" /> -->
                                                                    </div>
                                                                 </div>
			                                          </asp:View>
                                    
                                    <asp:View runat="server" ID="View4">

                                                                 <asp:Label runat="server" ID="lblIAID" Visible="false" ></asp:Label>
                                                                 <div style="background: #e2e2e2;text-align: right;padding: 10px 0;border: 1px solid #cacaca;"><asp:Button runat="server" Style="background: #ffc511;border: 1px solid #ccc;color: #000;font-size: 14px;" ID="btnPay" Text="Pay Now" CssClass="btn btn-sm btn-primary" OnClick="btnPay_Click" /> </div>
                                                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                                                 
                                                                 <asp:Label ID="lblControlId" runat="server" Visible="false"></asp:Label>
                                                             </asp:View>
                                                             
                                    <asp:View runat="server" ID="View5">
                                     <asp:Button ID="btnPrint" runat="server" Text="Print" Style="margin: 6px 2px;" OnClick="btnPrint_Click" CssClass="btn-primary btn-sm ey-bg pull-right" /><asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" Text="Send Mail" Style="margin: 6px 2px;" CssClass="btn-primary pull-right btn-sm ey-bg"/>  
                                     <div class="clearfix"></div>
                                     <div id="FinalPrint">
                                        <asp:PlaceHolder ID="PH_FinalView" runat="server"></asp:PlaceHolder>
                                     </div>
                                     <div class="clearfix"></div>
                                     <div class="text-center" style="display:none;">
                                       <asp:Button runat="server" ID="BtnFinal" Text="Final Submit" OnClick="BtnFinal_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" OnClientClick="Confirm()"  Visible="false" /> 
                                       <asp:Button runat="server" ID="btnFinalResubmit" Text="Final Submit" OnClick="btnFinalResubmit_Click" Style="margin:3px 0;" CssClass="btn btn-sm btn-primary" OnClientClick="Confirm()" Visible="false" /> 
                                      </div>
                                 </asp:View>
                                 
                                    <asp:View runat="server" ID="View6">
                                         <div style="display:none;">   <div class="panel panel-default">
                                             <div class="panel-heading">Clarification Raised By UPSIDC</div>
                                             <asp:TextBox ID="txtclarification" CssClass="similar-select1 margin-left-z" Height="100px" Enabled="false" runat="server" TextMode="MultiLine"></asp:TextBox>
                                             <hr class="separation" />
                                             <div class="panel-heading">Your Response</div>
                                             <asp:TextBox ID="txtResponse" CssClass="similar-select1 margin-left-z" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                             <hr class="separation" />
                                         </div>
                                         <div class="form-group">
                                                <div class="col-md-6 col-sm-6 col-xs-6">
                                                    <asp:FileUpload ID="fileupload" Width="100%" CssClass="form-control" runat="server" />                                                    
                                                </div>
                                                <div class="col-md-3 col-sm-3 col-xs-3">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary ey-bg btn-sm" style="margin:0 1px 0 0;width:65px;" Text="Save" OnClick="btnUpload_Click" />
                                                        
                                                    </span>
                                                </div>
                                        </div>
                                         <div class="clearfix"></div>
                                         <hr class="separation" /></div>


                                     <div class="clearfix"></div>
                                     <div id="Objection_Div">
                                        <asp:PlaceHolder ID="PH_Objection" runat="server"></asp:PlaceHolder>
                                     </div>
                                     <div class="clearfix"></div>
                                     <div class="text-center">


                                                                             </div>

                                         </asp:View>

                                    <asp:View runat="server" ID="View7">

                                         <div class="panel panel-default">
                                             <div class="panel-heading">Enter Payee Accounts Details</div>
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Payee Name:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtPayeeName" runat="server" Enabled="false"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Payee Bank:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtPayeeBank" runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Payee Account No:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtaccntNo" runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Confirm Payee Account No:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtConfirmAccNo" runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Bank IFSC Code:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtIFSCCode" runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Branch Name:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" ID="txtBranchName" runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="form-group">
                                                 <label class="col-md-3 col-sm-3 col-xs-3 text-right">
                                                    <asp:Label runat="server">Branch Address:</asp:Label>
                                                </label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <asp:textbox CssClass="similar-select1" Style="height:50px;" ID="txtBranchAddress" runat="server" TextMode="MultiLine"></asp:textbox>
                                                </div>
                                            </div>
                                             <div class="clearfix"></div>
                                             <hr class="myhrline" />
                                             <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                <asp:Button ID="btnmySave" runat="server" CssClass="btn btn-primary ey-bg btn-sm" style="margin:7px 1px 0 0;padding: 0px 0 5px 0;width:65px;" Text="Save" OnClick="btnmySave_Click" />
                                             </div>
                                         </div>
                                       
                                         <div class="clearfix"></div>
                                         
                                        </asp:View>

                                                             </asp:MultiView>
                                
                                                        </div>
                                                </div>
                                
                               
                            </div>
                        </div>
                    </div>
                </div>
             
               </ContentTemplate></asp:UpdatePanel>
    </form>
     <script type="text/javascript">




         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
         });

         function PageLoaded(sender, args) {
             $(".chosen").chosen();
         }
    
        
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



        function CloseModal() {
            $("#btnCloseModal").click();
        }

        function CloseModalUPSIDC() {
            $("#btnCloseModalUPSIDC").click();
        }


        function ShowSignPreview(input) {

            var uploadControl = document.getElementById('FuplodApplicantSign');
            if (uploadControl.files[0].size > 512000) {
                alert('File size must be less than 500 KB');
                document.getElementById("FuplodApplicantSign").value = "";
                return false;
            }


            var val = document.getElementById("FuplodApplicantSign").value;
            var Extension = val.substring(val.lastIndexOf('.') + 1).toLowerCase();


            if (Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "jpg") {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {

                        $('#Image2').hide();
                        $('#ImgPrvSign').addClass("show");

                        $('#ImgPrvSign').prop('src', e.target.result)



                        $('#ImgPrvSign').attr('value', e.target.result);


                    };
                    reader.readAsDataURL(input.files[0]);

                }
            }
            else {
                document.getElementById("FuplodApplicantSign").value = "";
                $('#ImgPrvSign').prop('src', '../images/signature.png')

                alert('Please select correct file format(.PNG,.JPEG,.JPG)');
            }


        }



        function ShowImagePreview(input) {


            var uploadControl = document.getElementById('FuplodApplicantImage');
            if (uploadControl.files[0].size > 512000) {
                alert('File size must be less than 500 KB');
                document.getElementById("FuplodApplicantImage").value = "";
                return false;
            }




            var val = document.getElementById("FuplodApplicantImage").value;
            var Extension = val.substring(val.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "jpg") {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {

                        $('#Image1').hide();
                        $('#ImgPrv').addClass("show");

                        $('#ImgPrv').prop('src', e.target.result)



                        $('#imgSrc').attr('value', e.target.result);


                    };
                    reader.readAsDataURL(input.files[0]);

                }
            }
            else {
                document.getElementById("FuplodApplicantImage").value = "";
                $('#ImgPrv').prop('src', '../Images/account-icon-5.jpg')

                alert('Please select correct file format(.PNG,.JPEG,.JPG)');
            }

        }
         
       </script>
    <script>

         function AKS() {


             $("#btnCloseModal").click();

         }

         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_endRequest(function () {
             function AKS() {

                 
                 $("#btnCloseModal").click();

             }
         });

         function CloseModal() {
             $("#btnCloseModal").click();
         }

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

         function Validatephone()
         {

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
             var txtSignatoryEmail = document.getElementById("<%= txtSignatoryEmail.ClientID %>");
             var Ddl_Expansion = document.getElementById("<%= Ddl_Expansion.ClientID %>");
             var Drop1 = document.getElementById("<%= Drop1.ClientID %>");
             var workExp = document.getElementById("<%= txtWorkExperience.ClientID %>");
             var txtExistingPlotNo = document.getElementById("<%= txtExistingPlotNo.ClientID %>");
             var txtAllotteeExisName = document.getElementById("<%= txtAllotteeExisName.ClientID %>");
             var txtAllotmentNo = document.getElementById("<%= txtAllotmentNo.ClientID %>");
             var txtManufacturedProduct = document.getElementById("<%= txtManufacturedProduct.ClientID %>");
             var txtAllotmentDate = document.getElementById("<%= txtAllotmentDate.ClientID %>");


            




             if (txttypeofindustry.value.length <= 0) {
                 txttypeofindustry.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txttypeofindustry.style.borderColor = "";
             }
             if (workExp.value.length <= 0) {
                 workExp.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 workExp.style.borderColor = "";
             }

             if (txtestimatedcost.value.length <= 0) {
                 txtestimatedcost.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtestimatedcost.style.borderColor = "";
             }
             if (txtestimatedemployment.value.length <= 0) {
                 txtestimatedemployment.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtestimatedemployment.style.borderColor = "";
             }

             if (txtcoveredarea.value.length <= 0) {
                 txtcoveredarea.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtcoveredarea.style.borderColor = "";
             }
             if (txtopenarearequired.value.length <= 0) {
                 txtopenarearequired.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtopenarearequired.style.borderColor = "";
             }
             if (txtland.value.length <= 0) {
                 txtland.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtland.style.borderColor = "";
             }
             if (txtbuilding.value.length <= 0) {
                 txtbuilding.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtbuilding.style.borderColor = "";
             }
             if (txtmachinery.value.length <= 0) {
                 txtmachinery.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtmachinery.style.borderColor = "";
             }
               
             if (txtpowerreq.value.length <= 0) {
                 txtpowerreq.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtpowerreq.style.borderColor = "";
             }
             if (txtNetWorth.value.length <= 0)
             {
                 txtNetWorth.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                    txtNetWorth.style.borderColor = "";
             }

             if (Ddl_Expansion.selectedIndex == 0) {
                 Ddl_Expansion.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 Ddl_Expansion.style.borderColor = "";
             }
             if (Drop1.selectedIndex == 0)
             {
                 Drop1.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 Drop1.style.borderColor = "";
             }
           
             if (txtExistingPlotNo.value.length <= 0) {
                 txtExistingPlotNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtExistingPlotNo.style.borderColor = "";
             }


             if (txtAllotmentNo.value.length <= 0)
             {
                 txtAllotmentNo.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                    txtAllotmentNo.style.borderColor = "";
             }


             if (txtAllotteeExisName.value.length <= 0)
             {
                 txtAllotteeExisName.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtAllotteeExisName.style.borderColor = "";
             }
             if (txtManufacturedProduct.value.length <= 0)
             {
                 txtManufacturedProduct.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtManufacturedProduct.style.borderColor = "";
             }
             if (txtAllotmentDate.value.length <= 0)
             {
                 txtAllotmentDate.style.borderColor = '#e52213';
                 remark = false;
             }
             else
             {
                 txtAllotmentDate.style.borderColor = "";
             }

                if (remark == false) {


                    alert("Fill All Required Field");
                    showError();
                    document.getElementById("<%= lblMessageError.ClientID %>").innerText = "Fill All Required Field";

                    return false;
                }
                else
                {
                    hideError();
                    return true;
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

                Popup($('#FinalPrint').html());
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
            
        function MessageAndRedirect(par1) {
            alert("Objection cleared and form re-submitted succesfully");
            window.location.href = 'LandAllotmentApplication.aspx?ServiceReqNo=' + par1 + '&Status=F';
        }
    </script>

</body>
</html>






