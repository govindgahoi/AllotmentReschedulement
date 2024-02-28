<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
</head>
<body class="login-bg">
    <form id="form1" runat="server">
     <main>
        <div class="container">
            <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                <div class="container">

                    <div class="row login-main justify-content-center">
                        <div class="col-lg-6 col-md-6 col-xl-6 col-xxl-6 col-sm-12">
                            <div class="d-flex left justify-content-center py-4">
                                <a href="pages-login.html" class="d-flex align-items-center w-auto">
                                    <img src="assets/img/login-left.png" alt="login left" class="img-fluid" />
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-xl-6 col-xxl-6 col-sm-12">
                            <div class="card login-card mb-3">
                                <div class="card-body">
                                    <div class="pb-2">
                                        <div class="d-flex justify-content-center py-4">
                                            <a href="#" class="logo d-flex align-items-center w-auto">
                                                <img src="assets/img/logo.png" alt="logo" class="img-fluid">
                                            </a>
                                        </div>
                                        <h5 class="card-title text-center pb-3 fs-4"> RM Login</h5>
                                    </div>
                                    <div class="row g-3 needs-validation">
                                        <div class="row py-3">
                                            <div class="col-6">
                                                <input id="Radio1" type="radio" />
                                                <span class="fw-bold">UPSIDA User </span>
                                            </div>
                                            <div class="col-6">
                                                <input id="Radio2" type="radio" />
                                                <span class="fw-bold">Other Dept </span>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <label for="yourUsername" class="form-label">Username</label>
                                            <div class="input-group has-validation">
                                                <span class="input-group-text" id="inputGroupPrepend"><i class="bi bi-person-circle"></i></span>
                                               <%-- <input type="text" name="username" class="form-control" id="yourUsername" required=""/>--%>
                                                 <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" " Placeholder="Enter User Name" ToolTip="UserName"></asp:TextBox>
                                                <div class="invalid-feedback">Please enter your username.</div>
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <label for="yourPassword" class="form-label">Password</label>
                                            <div class="input-group has-validation">
                                                <span class="input-group-text"><i class="bi bi-key"></i></span>
                                                <input type="password" name="password" class="form-control" required="" />
                                                <div class="invalid-feedback">Please enter your password!</div>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <label for="yourPassword" class="form-label">Captcha</label>
                                            <div class="input-group has-validation">
                                                <span class="input-group-text" ><i class="bi bi-upc-scan"></i></span>
                                                <input type="password" name="password" class="form-control" required=""/>
                                                <div class="invalid-feedback">Please enter your Captcha!</div>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="row">
                                                <div class="col-6">
                                                    <div class="form-check">
                                                <input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe"/>
                                                <label class="form-check-label" for="rememberMe">Remember me</label>
                                            </div>
                                            </div>
                                                <div class="col-6">
                                                     <p class="small mb-0"><a href="#">Forgot password</a></p>
                                            </div>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <button class="btn btn-primary w-100" type="submit">Login</button>
                                        </div>
                                      <%--  <div class="col-12">
                                            <p class="small mb-0">Don't have account? <a href="#">Create an account</a></p>
                                        </div>--%>
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
    </form>

</body>
</html>
