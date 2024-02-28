<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MDAppointmentRegistration.aspx.cs" Inherits="Allotment.MDAppointmentRegistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <link href="css/Footer.css" rel="stylesheet" />
    
  
    <style>
        .ui-dialog .ui-dialog-titlebar {
            padding : .4em 1em;
            position: relative;
            background: #D8D8D8 !important;
            border-color: #D8D8D8 !important;
        }

        .ui-dialog .ui-dialog-title {
            font-family: serif !important;
            color: black;
        }

        .ui-dialog {
            top: 130% !important;
        }

            .ui-dialog .ui-dialog-buttonpane button {
                background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#4c5568), to(#414959)) !important;
                border: 1px solid #fff !important;
                font-weight: normal !important;
                padding: 5px 10px !important;
                font-size: 12px !important;
                line-height: 1.5 !important;
                color: #fff !important;
            }




            .ui-dialog .ui-dialog-titlebar-close span {
                color: black !important;
            }

            textarea.similar-select1 {
            margin: 0px 0px 0px 0px !important;
            }
    </style>

     

    <script type="text/javascript">     
       
  
        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                alert('Invalid Email Address');
                return false;
            }

            return true;

        }
        function MsgAndRedirect() {
            alert('OTP Verified Succesfully. Your registration is completed & confirmation mail has been sent to your email id.');
            window.location.href = 'MDAppointmentRegistration.aspx';
           
        }
    </script>
 
</head>
<body id="pagewrap">
    <div id="dialog" style="display: none">
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       
        
        <div class="container">
             
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand" style="width:100%;">
                            <div class="col-md-8">
                                <img class="img-responsive" src="http://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <div class="col-md-4" style="margin-top: 2px;">
                                <img class="img-responsive" src="images/image4.png" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
              
            <div class="row" id="SideDiv">
                <div class="col-md-12">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row well well-large offset4">
                                <div class="panel panel-default">
                                   
                                    <div class="clearfix"></div>
                                    <p class="panel-heading text-center" style="font-size:12px"><b>Registration for Appointment With CEO UPSIDA</b></p>
                                    <div class="panel-body">
                                        <div id="tblallotteeinf">
                                          
                                            <div class="form-group">
                                                <div class="row">
                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Name Of the Person :
                                                    </label>
                                                    <div class="col-md-8">
                                                      <asp:TextBox ID="txtName" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                   
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                         Address :
                                                    </label>
                                                    <div class="col-md-8">
                                                      <asp:TextBox ID="txtAddress" runat="server" CssClass="similar-select1 input-sm" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Mobile No.:
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="similar-select1 input-sm" MaxLength="10"  onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        E-mail :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="similar-select1 input-sm" onblur="validateEmail(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                               <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                            <div class="form-group">
                                                <div class="row">
                                                    <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Purpose of Appointment :
                                                    </label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtAppPurpose" runat="server" TextMode="MultiLine" Rows="4" CssClass="similar-select1 input-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                       
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />                              
                                              <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Concern District :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" ></asp:DropDownList>
															                            </div>
														                            </div>
													                            </div>
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />                              
                                              <div class="form-group">
														                            <div class="row">
															                            <label class="col-md-4 col-sm-6 col-xs-6 text-right">
																                            <span style="color: Red">*</span>
																                            Concern Industrial Area :
															                            </label>
															                            <div class="col-md-8 col-sm-6 col-xs-6">
																                            <asp:DropDownList ID="ddlIA" runat="server" CssClass="similar-select1 margin-left-z dropdown-toggle input-sm" ></asp:DropDownList>
															                            </div>
														                            </div>
													                            </div>
													                            <div class="clearfix"></div>
													                            <hr class="myhrline" />
                                            <div class="form-group">
                                                 
                                                <div class="row">
                                                   <asp:UpdatePanel ID="pnlFileUpload" runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-4 text-right">
                                                        <span style="color: Red">*</span>
                                                        Document (Upload) :
                                                    </label>
                                                    <div class="col-md-4">
                                                       <asp:FileUpload ID="FileUploadLoaction" runat="server"  CssClass="input-sm similar-select"  ToolTip="Upload" accept=".pdf" ></asp:FileUpload>
                                                     </div>
                                                     <div class="col-md-4">
                                                    <span>
                                                        <asp:Button ID="btnUpload" runat="server"   CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Upload" OnClick="btnupload_Click" />
                                                        
                                                        <asp:Label ID="lbluploadingMsg" runat="server" Visible="false"></asp:Label>
                                                    </span>  
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                                   
                                                     
                                            </div>     
                                                 <div class="clearfix"></div>
                                                  <hr class="myhrline" />
                                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12 text-center" style="margin-top:9px;margin-bottom:9px;">
                                           <asp:Button ID="btnSubmit" runat="server"   CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 82px;" Text="Submit" OnClick="btnSubmit_Click" />    
                                             <asp:Button ID="btn_Clear" runat="server"   CssClass="btn btn-primary ey-bg btn-sm" Style="margin: 0 1px 0 0; width: 65px;" Text="Clear" OnClick="btnReset_Click" />
                                        </div>
                                    </div>
                                </div>
                                                 <div class="clearfix"></div>
                                            <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                           
                                         
                                            <div class="clearfix"></div>
                                            <hr class="myhrline" />
                                                
                                        </div>
                                        <div id="otp_div" runat="server" visible="true">
                                             <div class="form-group" style="margin-top:15px;">
                                              
                                    <div class="col-md-12 col-sm-12 col-xs-12" runat="server" id="Otp_MobileDiv" visible="false" >
                                        <div class="col-md-4 col-sm-4 col-xs-4 text-right">
                                            Enter OTP for Verification
                                            </div>
                                        <div class="col-md-4 col-sm-4 col-xs-4">
                                            <asp:TextBox runat="server" ID="txtMobOtp" CssClass="similar-select1 input-sm"></asp:TextBox>
                                            </div>
                                       <div class="col-md-4 col-sm-4 col-xs-4">
                                            <asp:Button runat="server" Text="Submit" class="btn-primary btn-sm ey-bg" ID="btn_EnterMobileOtp" OnClick="btn_EnterMobileOtp_Click"  />
                                            </div>
                                    </div>
                                  
                                                 
                                </div>
                                              <div class="clearfix"></div>
                                      
                                    </div>
                                            </div>
                                 

                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                    </div>
                
                </div></div>
            <div class="container">
                <div class="row" >
                <footer class="nb-footer">
                    
                        <div class="row">
                     
                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">PUBLIC FORUM</h2>
                                    <ul class="list-unstyled">
                                     
                                        <li><a href="Inspection.aspx" title=""><i class="fa fa-angle-double-right"></i>View Inspection Detail</a></li>
                                        <li><a href="BuldingPlanDetail.aspx" title=""><i class="fa fa-angle-double-right"></i>Approved Building Plan</a></li>
                                        <li><a href="PviewAllottes.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Allotment Document</a></li>
                                        <li><a href="ViewInspectionDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View Inspection Document</a></li>
                                        <li><a href="ViewBuildingPlanDocument.aspx" target="_blank" title=""><i class="fa fa-angle-double-right"></i>View BuildingPlan Document </a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">UP SIDA</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UP Industial Development Act</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>UPSIDA Byelaws</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Construction Permit</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>Inspection Format For Completion</a></li>
                                        <li><a href="#" title=""><i class="fa fa-angle-double-right"></i>SOP For Computerised Allocation of Inspectors</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Security & privacy</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Terms Of Use</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Privacy Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Return / Refund Policy</a></li>
                                        <li><a href="http://www.nextbootstrap.com/" title=""><i class="fa fa-angle-double-right"></i>Store Locations</a></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-6">
                                <div class="footer-info-single">
                                    <h2 class="title">Payment</h2>
                                    <ul class="list-unstyled">
                                        <li><a href="PaymentRequest.aspx" title=""><i class="fa fa-angle-double-right"></i>Quick Pay</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                  

                    <section class="copyright">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Copyright © 2017. UPSIDC Product Version Alpha 1.0 Release</p>
                                </div>
                                <div class="col-sm-6"></div>
                            </div>
                        </div>
                    </section>
                </footer>
                              </div>
                        
      
                
        </div>

    </form>
 

</body >
</html >
