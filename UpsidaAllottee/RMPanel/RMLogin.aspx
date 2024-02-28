<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RMLogin.aspx.cs" Inherits="RMPanel.RMLogin" %>

<!DOCTYPE html>

 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta content="width=device-width, initial-scale=1.0" name="viewport"/>

    <title>RM- Login</title>
    <meta content="" name="description"/>
    <meta content="" name="keywords"/>

    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon"/>
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon"/>

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet"/>

    <!-- custom CSS Files -->
    <link href="assets/custom/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="assets/custom/bootstrap-icons/bootstrap-icons.css" rel="stylesheet"/>
    <link href="assets/custom/boxicons/css/boxicons.min.css" rel="stylesheet"/>
    <link href="assets/custom/quill/quill.snow.css" rel="stylesheet"/>
    <link href="assets/custom/quill/quill.bubble.css" rel="stylesheet"/>
    <link href="assets/custom/remixicon/remixicon.css" rel="stylesheet"/>
    <link href="assets/custom/simple-datatables/style.css" rel="stylesheet"/>
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-bg">
    <form id="form1" runat="server">
     <main>
        <div class="container">
            <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                <div class="container">
                    <div class="row login-main justify-content-center">
                       <div class="col-lg-6 col-md-6 position-farmet col-xl-6 col-xxl-6 col-sm-12">
                                <div class="pb-2">
                                    <div class="d-flex justify-content-center py-3">
                                        <a href="#" class="logo d-flex align-items-center w-auto">
                                            <img src="assets/img/logo.png" alt="logo" class="img-fluid"/>
                                        </a>
                                    </div>
                                    <h5 class="card-title text-center pb-3 fs-4"> Uttar Pradesh State industrial Development Authority</h5>
                                </div>
                                <div class="d-flex mb-3 justify-content-center">
                                    <img src="assets/img/login-bg22.png" class="img-fluid"/>
                                    <!--<a href="#" class="d-flex align-items-center w-auto">
                                        <img src="assets/img/login-left.png" alt="login left" class="img-fluid" />
                                    </a>-->
                                </div>
                            </div>
                        <div class="col-lg-6 col-md-6 col-xl-6 col-xxl-6 col-sm-12">
                            <div class="login-card mb-0">
                                    <div class="card-body">
                                        <h5 class="card-title text-center pb-3 text-white fs-4"> LOGIN FOR RM</h5>
                                        <div class="row g-3 needs-validation">
                                           <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Text="UPSIDA User &nbsp;&nbsp;&nbsp;" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Other Dept &nbsp;&nbsp;&nbsp;" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                            <div class="col-12">
                                                <label for="yourUsername" class="form-label"> Username</label>
                                                <div class="input-group has-validation">
                                                    <span class="input-group-text" id="inputGroupPrepend"><i class="bi bi-person-circle"></i></span>
                                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" Placeholder="Enter User Name" ToolTip="UserName"></asp:TextBox>
                                                    <div class="invalid-feedback">Please enter your username.</div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <label for="yourPassword" class="form-label">Password</label>
                                                <div class="input-group has-validation">
                                                    <span class="input-group-text"><i class="bi bi-key"></i></span>
                                                     <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control " Placeholder="Enter Password" ToolTip="Password" type="password"></asp:TextBox>
                                                    <div class="invalid-feedback">Please enter your password!</div>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="row">
                                                    <div class="col-md-6">
                                               <!-- <label for="yourPassword" class="form-label">Captcha</label>-->
                                                        <asp:Image ImageUrl="ghCaptcha.ashx" runat="server" ID="imgCaptcha" Height="40px" />
                                                        </div>
                                                     <div class="col-md-6">
                                                <div class="input-group has-validation">
                                                    <span class="input-group-text"><i class="bi bi-upc-scan"></i></span>
                                                   <asp:TextBox ID="txtCode" runat="server" CssClass="form-control margin-left-z" Placeholder="Enter Captcha"  ToolTip="Enter Captcha" AutoComplete="off"></asp:TextBox>
                                                    <div class="invalid-feedback">Please enter your Captcha!</div>
                                                </div>
                                                         </div>
                                                    </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe" />
                                                            <label class="form-check-label" for="rememberMe">Remember me</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 text-end">
                                                        <p class="small mb-0"><a href="#">Forgot password</a></p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-12 text-center">

                                                <asp:Button ID="btnLogin" runat="server"   class="save"  Text="Login" OnClick="btnLogin_Click" OnClientClick="javascript:return ChkValidVal();" />
                                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>
                                            </div>
                                          
                                        </div>

                                    </div>
                                </div>
                        </div>
                    </div>

                </div>
            </section>

        </div>
    </main>
         <!-- custom JS Files -->
    <script src="assets/custom/apexcharts/apexcharts.min.js"></script>
    <script src="assets/custom/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="assets/custom/chart.js/chart.min.js"></script>
    <script src="assets/custom/echarts/echarts.min.js"></script>
    <script src="assets/custom/quill/quill.min.js"></script>
    <script src="assets/custom/simple-datatables/simple-datatables.js"></script>
    <script src="assets/custom/tinymce/tinymce.min.js"></script>
    <script src="assets/custom/php-email-form/validate.js"></script>

    <!-- Template Main JS File -->
    <script src="assets/js/main.js"></script>
         <script src="assets/js/main.js"></script>
    </form>


     <script type="text/ecmascript">
        function ErrorClose() {
            var divError = document.getElementById("divError");
            divError.style.display = "none";
        }

        function ChkValidVal() {

            var user_email = document.getElementById("txtUserName");
            var user_password = document.getElementById("txtPwd");
            var IsvalidEmail = 1;

            if (user_email.value == "") {

                alert("Please User ID.")
                return false;
            }

            if (user_password.value == "") {
                alert("Please enter password.");
                return false;
            }
        }
        function LABP() {
            top.window.location.href = 'https://niveshmitra.up.nic.in/';
        }

        function RTI() {
            top.window.location.href = 'http://upsidaservices.onlineupsidc.com';
        }
        function comingsoon() {
            top.window.location.href = 'comingsoon.htm';
        }
        function IAService() {
            top.window.location.href = 'IAServices.aspx';
        }

        function ShowTermsAndCondition() {
            $('input:radio[name=Radio]').each(function () { $(this).prop('checked', false); });
            $("#btnModalTerms").click();
        }
        function LAW() {
            //window.location.href = 'RegistrationLogistics.aspx';
            alert("Will be live soon")
        }



    </script>
    <script type="text/javascript">
        $(function () {
            $("#nav .dropdown").hover(
                function () {
                    $('#products-menu.dropdown-menu', this).stop(true, true).fadeIn("fast");
                    $(this).toggleClass('open');
                },
                function () {
                    $('#products-menu.dropdown-menu', this).stop(true, true).fadeOut("fast");
                    $(this).toggleClass('open');
                });
        });
        $(function () {
            $("#nav .dropdown1").hover(
                function () {
                    $('#products-menu1.dropdown-menu1', this).stop(true, true).fadeIn("fast");
                    $(this).toggleClass('open');
                },
                function () {
                    $('#products-menu1.dropdown-menu1', this).stop(true, true).fadeOut("fast");
                    $(this).toggleClass('open');
                });
        });

    </script>
    <script>
        // When the user scrolls down 20px from the top of the document, show the button
        window.onscroll = function () { scrollFunction() };

        function scrollFunction() {
            if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
                document.getElementById("myBtn").style.display = "block";
            } else {
                document.getElementById("myBtn").style.display = "none";
            }
        }

        // When the user clicks on the button, scroll to the top of the document
        function topFunction() {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        }


    </script>
    
</body>
</html>
