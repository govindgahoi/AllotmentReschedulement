<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteeLogin.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeLoginNew" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Allottee Dashboard Login </title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="shortcut icon" type="dist/img/favicon-32x32.png" href="dist/img/favicon-32x32.png" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome Icons -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Theme style -->
    <link href="dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/main.css" rel="stylesheet" />
    <link href="dist/css/responsive.css" rel="stylesheet" />
</head>
<body class="bg-banner-2">
    <form id="form1" runat="server">
        <div class="container">
            <div class="main-login-21">
                <div class="row">
                    <div class="col-md-7 col-lg-7 col-sm-12 col-xs-12"></div>
                    <div class="col-md-5 col-lg-5 col-sm-12 col-xs-12">
                        <%-- Allottee Login Start--%>
                        <div class="login-left welcome2">
                            <img src="dist/img/logo-login.png" class="img-fluid" alt="logo-login" />
                            <h1>Allottee Login</h1>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="txtUserid" placeholder="Enter Your Email id" runat="server"></asp:TextBox>
                                <span class="fa fa-user form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="******************" runat="server"></asp:TextBox>
                                <span class="fa fa-lock form-control-feedback"></span>
                            </div>
                           <div class="form-group">
                            <div class="row ">
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 text-left has-feedback">
                                    
                                        <asp:Image ImageUrl="ghCaptcha.ashx"   runat="server" ID="imgCaptcha"  class="img-fluid"/>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 has-feedback-captch">
                                    <asp:TextBox ID="txtCode" placeholder="Captcha" runat="server"></asp:TextBox>
                                      <span class="fa fa-qrcode form-control-feedback"></span>
                                </div>
                                </div>
                            </div>
                            <div class="form-group forgetpass91">
                            <div class="row ">
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 text-left has-feedback">
                                  <a href="Forget_password.aspx"><i class="fas fa-key"></i> Forget Password?</a>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 has-feedback-captch">
                                    <a href="AllotteeRegistration.aspx"><i class="fas fa-user-plus"></i> Sign up</a>
                                </div>
                                </div>
                            </div>
                            <asp:Button ID="btnLogin" CssClass="save_btn" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                        </div>
                        <%-- Allottee Login End--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

