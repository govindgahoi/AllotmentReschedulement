<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Allotment.AllotteePanel.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <!--<section class="content-header">
          <h1>
            Dashboard
            <small>Version 2.0</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Dashboard</li>
          </ol>
        </section>-->

        <!-- Main content -->
        <section class="content">
              <div class="row" >
            <div class="col-md-12">
            <div class="main-login-21">
                <div class="row industries-service">
                    <div class="col-md-6 industries-service-stretch gutter20">
                        <div class="login-left welcome1">
                           <h1>Welcome Back !</h1>
                            <p class="paragraph">To keep connected with us please login with your personal info</p>
                            <a href="AllotteeRegistration.aspx" class="btn9"> Sign UP</a>
                            <%--<asp:Button ID="Button1" CssClass="btn9" runat="server" Text="Sign UP" />--%>
                        </div>
                    </div>
                     <div class="col-md-6 industries-service-stretch gutter20">
                        <div class="login-left welcome2">
                            <img src="dist/img/logo-login.png" />
                             <h1>Allottee Login</h1>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="txtUserid" placeholder="Enter Your Email id" runat="server"></asp:TextBox>
                                <span class="glyphicon glyphicon-user form-control-feedback"></span>
                            </div>
                             <div class="form-group has-feedback">
                                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="**************" runat="server"></asp:TextBox>
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                            <div class="col-md-12">
                                <div class="col-md-6">
                           <%-- <label style="float: left;">Captcha :</label>--%>
                            <asp:Image ImageUrl="ghCaptcha.ashx" Width="120px" runat="server" ID="imgCaptcha" />
                                    </div>
                                <div class="col-md-6">
                            <asp:TextBox ID="txtCode" placeholder="Captcha"  runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                          <div class="form-group forgetpass91">
                                <a href="Forget_password.aspx">Forget Password</a>
                          </div>
                             <asp:Button ID="btnLogin" CssClass="btn9" runat="server" Text="Login"   />
                        </div>
                     </div>
                 </div>
             </div>
                </div>
            </div>
            </section>
         </div>
</asp:Content>
