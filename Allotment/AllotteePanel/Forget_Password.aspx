<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget_Password.aspx.cs" Inherits="Allotment.AllotteePanel.Forget_Password" %>


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
        function MsgRegistrationRedirect() {
            alert('Allottee password  save Successfully');
            window.location.href='AllotteeLogin.aspx';
        }

      
    </script>
<%-- <script type="text/javascript">
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
     </script>--%>
    <style>
        label {
    width: 100% !important;
    text-align: left !important;
}
        .modal-content .modal-body input {
    width: 100% !important;
}
    </style>
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
                                    <h1>Allottee Forget Password</h1>
                                     <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
                                                <label>
                                                    <span class="check-cross" runat="server">✖</span>

                                                    <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
                                                </label>
                                            </div>
                           
                                    <div class="form-group has-feedback">
                                        <asp:RegularExpressionValidator ID="reg" runat="server" ControlToValidate="txtEmail" ForeColor="Red"
                                            ValidationExpression="^\S+@\S+$"
                                            Text="Input value is an invalid email address!"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtEmail" placeholder="Enter Your Email id" runat="server"></asp:TextBox>

                                        <span class="fa fa-envelope form-control-feedback"></span>

                                    </div>
                                    
                              
                                    <div class="form-group">
                                        <%--<asp:Button ID="btnSubmit" CssClass="btn9" runat="server" Text="Submit" OnClick="ShowPopup" />--%>
                                        <asp:Button ID="btnSubmit" CssClass="save_btn" runat="server" Text="Submit" OnClientClick="return userValid();" OnClick="ShowPopup_Click" />
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
                                <h4 class="modal-title"><label id="lblmessage" runat="server"></label> </h4>
                            </div>
                            <div class="bg-gradient-green">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label></div>
                         
                   
                            <div class="modal-body" id="veryfy" runat="server">
                                <asp:TextBox ID="txtVerifyOTP" placeholder="Place your OTP here.." runat="server"></asp:TextBox>
                               
        
                                <%-- <asp:TextBox ID="TextBox1" placeholder="Place your OTP here.." runat="server"></asp:TextBox>--%>
                            </div>
                                    <div class="modal-body" id="confirmpassword" visible="false" runat="server">
                                        <div style="    text-align: left;    font-weight: 600;">
                                <asp:Label runat="server">Password</asp:Label>
                                 <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="padding-right:100px;"></asp:TextBox></div>
                                     <div style="    text-align: left;    font-weight: 600;"> <asp:Label runat="server">Confirm Password</asp:Label>
                                   <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password"></asp:TextBox></div>

 <div style="  padding: 5px;    margin-top: 10px;    color: red;    font-weight: 600;">
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"   
        ErrorMessage="Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character"   
       
        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"   
        ControlToValidate="txtPassword" ForeColor="Red"></asp:RegularExpressionValidator> </div>


                                        <div style="  padding: 5px;    margin-top: 10px;    color: red;    font-weight: 600;">
                                          <asp:comparevalidator runat="server" id="numbers" controltovalidate="txtpassword" controltocompare="txtconfirmpassword" class=""  errormessage="Password and confirm password does not match" />
                               </div>
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


<%--<html xmlns="http://www.w3.org/1999/xhtml">
     <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
      <link href="dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/main.css" rel="stylesheet" />
    <link href="dist/css/responsive.css" rel="stylesheet" />
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: "Montserrat", sans-serif;
            font-size: 12px;
            background-image: url("./dist/img/advertisement-bg1.jpg");
            color: #a0a5a8;
            background-repeat: no-repeat;
            background-size: cover;
        }



        .container {
            position:relative;
            text-align: center;
            border-radius: 20px;
            width: 411px;
            height: 100%;
            padding: 25px;
            background-color: #ecf0f3d1;
            transition: 1.25s;
            margin-left: auto;
            margin-right: auto;
            margin-top: 109PX;
        }

        .button {
            width: 125px;
            height: 35px;
            border-radius: 25px;
            margin-top: 50px;
            font-weight: 700;
            font-size: 14px;
            letter-spacing: 1.15px;
            background-color: #4B70E2;
            color: white;
            box-shadow: 8px 8px 16px #d1d9e6, -8px -8px 16px #f9f9f9;
            border: none;
            outline: none;
            cursor:pointer;
        }


        input::placeholder {
            color: black !important;
        }

        .form__input {
            width: 81%;
            height: 40px;
            padding-left: 25px;
            font-size: 13px;
            letter-spacing: 0.15px;
            border: none;
            color: black;
            outline: none;
            font-family: "Montserrat", sans-serif;
            background-color: #ecf0f3;
            transition: 0.25s ease;
            border-radius: 8px;
            box-shadow: inset 2px 2px 4px #d1d9e6, inset -2px -2px 4px #f9f9f9;
        }

        .title {
            font-size: 25px;
            font-weight: 700;
            line-height: 30px;
            color: #143260;
        }
        .allotee-Email-icon98{
            position: absolute;
    left: 13%;
    bottom: 29%;
    color: black;
        }
        .back-pass{
             margin-right: 46px;
    border: none;
    padding: 9px 53px;
    border-radius: 24px;
    cursor: pointer;
    font-size: 14px;
    background-color: white;
    font-weight: 600;
    text-decoration: none;
           }      
    </style>
</head>
<body id="page">
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <img src="dist/img/logo-login.png" />
            <h2 class="form_title title">Forget Password</h2>
              <span class="allotee-Email-icon98"><i class="fa fa-envelope" aria-hidden="true"></i></span>
       
            <asp:TextBox ID="txtemail" runat="server" class="form__input" type="text" placeholder="Enter Your Email id" ></asp:TextBox>
          <a href="AllotteeLogin.aspx" class="back-pass">Back</a>
                
            <asp:Button ID="btnforgateemail" class="form__button button submit" runat="server" Text="Submit" OnClick="btnforgateemail_Click" />
            <%--<button class="form__button button submit">
                Submit
            </button>--%>
             
        </div>
    </form>

</body>
</html>--%>

