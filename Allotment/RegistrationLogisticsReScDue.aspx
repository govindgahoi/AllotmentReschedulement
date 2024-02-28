<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationLogisticsReScDue.aspx.cs" Inherits="Allotment.RegistrationLogisticsReScDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css"    rel="stylesheet" />
    <link href="/css/Wizard.css"   rel="stylesheet" />
    <link href="/css/Main.css"     rel="stylesheet" />
    <link href="css/style4.css"    rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
   <script type="text/javascript">
        function disableBack() { window.history.forward(); }
        setTimeout("disableBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
        .form-group label{
            margin-bottom:0;
        }
        .form-group input[type='radio'] {
            margin-right:3px;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
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
            #ModalGridchange .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

          @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange1 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }


           @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange2 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

        .modal-header {
            padding: 2px !important;
        }
     
    </style>
    
    <script type="text/javascript">

        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                alert('Invalid Email Address');
                return false;
            }

            return true;

        }

     function MsgAndRedirect(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to fill complete details & documents');
            window.location.href = 'ApplicationForLAW.aspx?ID=' + ID;
           
        }
        function MsgAndRedirectModify(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to modify your application');
            window.location.href = 'ApplicationForLAW.aspx?ID=' + ID;

        }

        function PIPMsgAndRedirect(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to fill complete details & documents');
            window.location.href = 'ApplicationForPIP.aspx?ID=' + ID;

        }
        function PIPMsgAndRedirectModify(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to modify your application');
            window.location.href = 'ApplicationForPIP.aspx?ID=' + ID;

        }

        function PIPFinMsgAndRedirect(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to fill complete details & documents');
            window.location.href = 'ApplicationForAvailingFinancialAssistanceForPIP.aspx?ID=' + ID;

        }
        function PIPFinMsgAndRedirectModify(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to modify your application');
            window.location.href = 'ApplicationForAvailingFinancialAssistanceForPIP.aspx?ID=' + ID;

        }
        function PIP_AfaMsgAndRedirectModify(ID) {
            alert('OTP Verified Succesfully. Kindly proceed to modify your application');
            window.location.href = 'ApplicationForAvailingFinancialAssistanceForPIP.aspx?ID=' + ID;

        }

        
    </script>
        
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            
  <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">
  
            <ContentTemplate>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:25px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                          <div class="panel panel-default">
                                      <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                    <li>


                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col-md-6 col-sm-4 col-xs-12 text-center">
                                              
                                                 <img src="/images/upsidclogo.png" style="width:211px;margin-top: 12px;" alt="Goverment" />  </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;margin-left:150px;">
                                                    <li>
                                                        <%--<img src="/images/logo-img/govt_up.png" alt="Goverment" />--%>
                                                        <img src="images/investup.png" /></li>

                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> <div class="clearfix"></div>
                                     <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div1">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-12 col-xs-12 text-left">
                                                
                                                    <asp:Button runat="server" ID="Button1" style="font-size: 12px;margin: 16px 10px;" CssClass="btn-primary" Text="Back to home page" OnClick="Button1_Click" /> 
                                                  
                                            </div>
                                            <div class="col-md-6 col-sm-12 col-xs-12 text-center">
                                                
                                                     <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>
                                                  
                                            </div>
                                           <div class="col-md-3 col-sm-12 col-xs-12 text-center">
                                                
                                                    
                                                  
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> 
                                <div class="clearfix"></div>
                                    <div class="clearfix"></div>
                                    
                                        <div class="col-md-12 col-sm-12 col-xs-12 text-center" runat="server" id="divpipfin" visible="true">
                                        <div class="panel-heading font-bold text-center" style="font-size: 14px !important; font-weight: 600; background: #2d2d2d; color: #ffc511 !important;">Application for Reschedulement of Dues</div>
                                    </div>


                                    </div>
                    </div>
                </div>
         
            </div>         
             <div class="clearfix"></div>
           
       </div>

                <div class="container">


                     <asp:MultiView runat="server" ID="Allotment">
<asp:View ID="View1" runat="server">
      <div class="col-md-12 col-sm-12 col-xs-12">
                        <div style="border:1px solid #e0e0e0;padding:10px;">
                                                                <div style="border:3px solid #ccc;padding: 10px 0px;">
                                                                    
                                                                    <div class="form-group">
                                                                        <div class="col-md-12 col-sm-12 col-xs-12" style="font-size: 18px;margin-bottom: 6px;">
                                                                            <asp:RadioButton ID="RadioUpsidc" GroupName="Grp1" Style="margin-right: 3px;" runat="server" /> Apply through UPSIDA In-house System 
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" style="border-top: 1px solid #646464;"/>
                                                                        <div class="text-justify" style="padding: 10px 20px;">
                                                                            Applicant can make their Application Under Logistic & Warehousing Policy 2018
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                    <hr class="separation" style="border-top: 6px solid #e8e8e8;"/>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12 col-sm-12 col-xs-12" style="font-size: 18px;margin-bottom: 6px;">
                                                                            <asp:RadioButton ID="RadioExisting" GroupName="Grp1" Style="margin-right: 3px;" runat="server" /> Modify/View the existing Application
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" style="border-top: 1px solid #646464;"/>
                                                                        <div class="text-justify" style="padding: 10px 20px;">
                                                                            Applicant can modify/view its application.
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                     <hr class="separation" style="border-top: 6px solid #e8e8e8;"/>
                                                                       <div class="form-group">
                                                                        <div class="col-md-12 col-sm-12 col-xs-12" style="font-size: 18px;margin-bottom: 6px;">
                                                                            <asp:RadioButton ID="RadioTrackApp" GroupName="Grp1" Style="margin-right: 3px;" runat="server" />Track Your Application
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" style="border-top: 1px solid #646464;"/>
                                                                        <div class="text-justify" style="padding: 10px 20px;">
                                                                            Applicant can track the status of their application.
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                 </div>
                                                            </div>
                                                            <div class="col-md-12 col-sm-12 col-xs-12">
                                                                <asp:Button ID="btnproceed" CssClass="btn-sm btn-primary ey-bg pull-right" Style="margin-top:5px;" Text="Proceed" runat="server" OnClick="btnproceed_Click" />
                                                            
                                                                <asp:HiddenField runat="server" id="hidAmt" />
                                                            </div>
                </div>
               
    </asp:View>

              <asp:View ID="View2" runat="server">
                <h2>Register Yourself</h2>
      <div class="panel panel-default">
      <div class="panel-body">
      <div class="form-group">
    <label for="exampleInputEmail1">Applicant Name</label>
    <asp:TextBox ID="txtApplicantName" runat="server" CssClass="form-control" placeholder="Enter Your Name"></asp:TextBox>														                             
    
    
  </div>
   <div class="form-group">
    <label>Applicant Email ID</label>
    <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder="Enter Your Email ID" onblur="validateEmail(this);"></asp:TextBox>														                              
    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
  </div>
  <div class="form-group">
    <label>Enter Mobile No</label>
    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Your Mobile No"></asp:TextBox>
      <small id="mobileHelp" class="form-text text-muted">We'll never share your mobile no with anyone else.</small>
  </div>
  <div class="form-group">
    <label>Service Request Number</label>
    <asp:TextBox ID="txtServiceRequestNo" runat="server" CssClass="form-control"  placeholder="Enter Service Request No."></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtServiceRequestNo" runat="server"  style="color:Red" ErrorMessage="Please Service Request No."></asp:RequiredFieldValidator>

  </div>
  <div class="form-group text-right">
   <asp:Button runat="server" ID="BtnSaveApplicant" CssClass="btn btn-primary" Text="Confirm & Submit" OnClick="btnSubmit_Click"/> <asp:Button runat="server" ID="Button2" CssClass="btn btn-primary" Text="Clear" Visible="false" OnClick="Button2_Click"/>
  </div>



            <div  runat="server" id="Otp_MobileDiv" visible="false">
                                             <div class="form-group" style="margin-top:15px;">
                                              
                                    <div class="col-md-12 col-sm-12 col-xs-12" runat="server"  >
                                        <div class="col-md-4 col-sm-4 col-xs-4 text-right">
                                            Enter OTP for Verification
                                            </div>
                                        <div class="col-md-4 col-sm-4 col-xs-4">
                                            <asp:TextBox runat="server" ID="txtMobOtp" CssClass="form-control"></asp:TextBox>
                                            </div>
                                       <div class="col-md-4 col-sm-4 col-xs-4">
                                            <asp:Button runat="server" Text="Submit" class="btn-primary btn-sm ey-bg" ID="btn_EnterMobileOtp" OnClick="btn_EnterMobileOtp_Click"   />
                                            </div>
                                    </div>
                                  
                                                 
                                </div>
                                              <div class="clearfix"></div>
                                      
                                    </div>

      </div>
      </div>
               </asp:View>

      <asp:View ID="View3" runat="server">
      <h2>Modify Your Application</h2>
      <div class="panel panel-default">
      <div class="panel-body">
      <div class="form-group">
      <label for="exampleInputEmail1">Enter your Application No</label>
      <asp:TextBox ID="txtApplicationID" runat="server" CssClass="form-control" placeholder="Enter Your Application No"></asp:TextBox>														                              
      </div>
          <div class="clearfix"></div>
          <div class="form-group text-right">
          <asp:Button runat="server" ID="btnModify" CssClass="btn btn-primary" Text="Proceed" OnClick="btnModify_Click"/>  
          </div>

         <div class="clearfix"></div>

<div  runat="server" id="OtpDiv" visible="false">
    <div class="form-group" style="margin-top:15px;">
        <div class="col-md-12 col-sm-12 col-xs-12" runat="server"  >
            <div class="col-md-4 col-sm-4 col-xs-4 text-right">Enter OTP for Verification</div>
            <div class="col-md-4 col-sm-4 col-xs-4">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-4">
                <asp:Button runat="server" Text="Verify OTP" class="btn-primary btn-sm ey-bg" ID="btnVerifyOtp" OnClick="btnVerifyOtp_Click"   />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>                                  
</div>
         
         </asp:View>

                          </asp:MultiView>
                </div>

              
           </ContentTemplate>
        </asp:UpdatePanel>
    </form>

   
</body>

</html>