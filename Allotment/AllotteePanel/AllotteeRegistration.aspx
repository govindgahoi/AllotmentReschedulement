<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteeRegistration.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Allottee Dashboard Registration </title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="shortcut icon" type="dist/img/favicon-32x32.png" href="dist/img/favicon-32x32.png" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome Icons -->
    <link href="dist/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Theme style -->
    <link href="dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/main.css" rel="stylesheet" />
    <link href="dist/css/responsive.css" rel="stylesheet" />
 <script type="text/javascript">
        function MsgAndRedirect() {
            alert('Already Registered User? Click here to login.');
            window.location.href = 'AllotteeLogin.aspx';

        }
        function MsgRegistrationRedirect() {
            alert('Allottee Registration done Successfully. Details send on Your Email');
            window.location.href = 'AllotteeLogin.aspx';

        }
       function showError() {
            if (document.getElementById("<%= divMessageError.ClientID %>").style.display == 'none') {
                document.getElementById("<%= divMessageError.ClientID %>").style.display = 'block';

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
     function userValid() {
         var remark = true;

         if (txtPhone.value.length <= 0) {
             txtPhone.style.borderColor = '#e52213';
             remark = false;
         }
         else {
             txtApplicantMobileNo.style.borderColor = "";
         }
     }
     </script>

</head>
<body class="bg-banner-2">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <div class="container">
                    <div class="main-login-21">
                        <%--Allottee Registration Satrt--%>
                        <div class="row">
                            <div class="col-md-7 col-lg-7 col-sm-12 col-xs-12"></div>
                            <div class="col-md-5 col-lg-5 col-sm-12 col-xs-12">
                                <div class="ragistratin-left welcome1">
                                    <img src="dist/img/logo-login.png" class="img-fluid" alt="logo-login" />
                                    <h1>Allottee Registration</h1>
                                     <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                                                <label>
                                                    <span class="check-cross" runat="server">✖</span>

                                                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                </label>
                                            </div>
                                    <div class="form-group has-feedback">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ErrorMessage="Please enter your Allottee Name" ControlToValidate="txtName" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtName" placeholder="Allottee Name" runat="server"></asp:TextBox>
                                        <span class="fa fa-user form-control-feedback"></span>
                                    </div>
                                    <div class="form-group has-feedback">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ErrorMessage="Please enter your Firm / Company" ControlToValidate="txtCompany" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtCompany" placeholder="Firm / Company" runat="server"></asp:TextBox>
                                        <span class="fa fa-list-alt form-control-feedback"></span>
                                    </div>
                                    <div class="form-group has-feedback">
                                        <asp:RegularExpressionValidator ID="rev" runat="server" ForeColor="Red" ErrorMessage="The PhoneNumber field is not a valid phone number." ControlToValidate="txtPhone" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtPhone" placeholder="Enter Phone"  MaxLength="10" onkeypress="return isDecimalKey(event);"  runat="server"></asp:TextBox>
                                        <span class="fa fa-phone fa-rotate-90 form-control-feedback"></span>


                                    </div>
                                    <div class="form-group has-feedback">
                                        <asp:RegularExpressionValidator ID="reg" runat="server" ControlToValidate="txtEmail" ForeColor="Red"
                                            ValidationExpression="^\S+@\S+$"
                                            Text="Input value is an invalid email address!"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtEmail" placeholder="Enter Your Email id" runat="server"></asp:TextBox>

                                        <span class="fa fa-envelope form-control-feedback"></span>

                                    </div>
                                    <div class="form-group">
                                        <div class="row ">
                                            <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 text-left has-feedback">
                                                <%--<label>
                                            <img id="imgCaptcha" src="https://eservices.onlineupsidc.com/ghCaptcha.ashx" class="img-fluid" /></label>--%>
                                                <asp:Image ImageUrl="ghCaptcha.ashx" class="img-fluid" runat="server" ID="imgCaptcha" />
                                            </div>
                                            <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 has-feedback-captch">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ErrorMessage="Captcha code" ControlToValidate="txtCompany" runat="server">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtCode" placeholder="Captcha" runat="server"></asp:TextBox>
                                                <span class="fa fa-qrcode form-control-feedback"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group forgetpass91">
                                        <div class="row ">
                                            <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 text-left has-feedback">
                                                <%--  <a href="Forget_password.aspx"><i class="fas fa-key"></i> Forget Password?</a>--%>
                                            </div>
                                            <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 has-feedback-captch">

                                                <a href="AllotteeLogin.aspx"><i class="fas fa-user-plus"></i>Login</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <%--<asp:Button ID="btnSubmit" CssClass="btn9" runat="server" Text="Submit" OnClick="ShowPopup" />--%>
                                        <asp:Button ID="btnSubmit" CssClass="save_btn" runat="server" Text="Submit" OnClientClick="return userValid();" OnClick="ShowPopup" />
                                    </div>

                                </div>
                            </div>

                        </div>
                        <%-- Allottee Registration End--%>
                    </div>
                </div>
                <%-- <div id="element" class="btn btn-default show-modal">show modal</div>--%>
                <%--  Popup modal dialog Box Start--%>
                <div id="testmodal" class="modal fade" role="dialog">

                    <div class="modal-dialog ">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;</button>
                                <h4 class="modal-title">Verify OTP</h4>
                            </div>
                            <div class="bg-gradient-green">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label></div>
                         
                      
                            <div class="modal-body">
                                <asp:TextBox ID="txtVerifyOTP" placeholder="Place your OTP here.." runat="server"></asp:TextBox>
                                <%-- <asp:TextBox ID="TextBox1" placeholder="Place your OTP here.." runat="server"></asp:TextBox>--%>
                            </div>
                            <div class="modal-footer">
                                <%--  <button type="button" class="btn fearrs" data-dismiss="modal">
                            Verify</button>--%>
                                <asp:Button ID="Button1" runat="server" CssClass="btn fearrs" Text="Verify" OnClick="btnSubmit_Click" />


                            </div>
                            <div class="mb-2">
                                <p>Didn't receive OTP?</p>
                                <a href="#">Resend</a>
                            </div>
                        </div>
                    </div>
                </div>
                <%--  Popup modal dialog Box End--%>
            </ContentTemplate>

        </asp:UpdatePanel>

    </form>
    <script src="plugins/jquery/jquery.min.js"></script>
    <script src="plugins/jquery/jquery-ui.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- overlayScrollbars -->
    <script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- allottee App -->
    <script src="dist/js/allottee.js"></script>
    <script src="plugins/jquery-mousewheel/jquery.mousewheel.js"></script>
    <script src="plugins/raphael/raphael.min.js"></script>
    <script src="plugins/jquery-mapael/jquery.mapael.min.js"></script>
    <script src="plugins/jquery-mapael/maps/usa_states.min.js"></script>
    <!-- ChartJS -->
    <script src="plugins/chart.js/Chart.min.js"></script>
    <!-- allottee for demo purposes -->
    <script src="dist/js/demo.js"></script>
    <!-- allottee dashboard demo (This is only for demo purposes) -->
    <%--<script src="dist/js/pages/dashboard2.js"></script>--%>
    <%--  Popup modal dialog Box Script Start--%>
    <%--<script type="text/javascript">

        
        $(document).ready(function () {
            var show_btn = $('.show-modal');
            var show_btn = $('.show-modal');
            //$("#testmodal").modal('show');

            show_btn.click(function () {
                $("#testmodal").modal('show');
            })
        });

    </script>--%>


    <%--  Popup modal dialog Box Script End--%>
</body>
</html>

