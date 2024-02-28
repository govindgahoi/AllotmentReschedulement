<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IDALogin.aspx.cs" Inherits="Allotment.IDALogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-12">
            <div class="col-md-9"></div>
            <div class="col-md-3 well well-large offset6">
                                <div class="clearfix"></div>
                                <div class="form-group" style="border: 1px solid #ccc;padding: 20px;">
                               
                                    <div class="input-group" style="margin-top: 10px">
                                         <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                        <asp:TextBox ID="txtUserName" CssClass="form-control margin-left-z" runat="server" Width="250px" ToolTip="UserName"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div class="input-group" style="margin-top: 10px">
                                        <span class="input-group-addon"><i class="fa fa-unlock-alt"></i></span>
                                        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control margin-left-z" Width="250px" ToolTip="Password" type="password"></asp:TextBox>

                                    </div>
                                    <div class="login-btn" style="margin-top: 10px">
                                        <asp:Button ID="btnLogin" runat="server" Width="80px" class="btn btn-primary ey-bg" style="margin-left:0;" Text="Login" OnClick="btnLogin_Click" />
                                        <asp:HyperLink ID="lnkforgetPwd" runat="server">Forgot Password</asp:HyperLink>
                                    </div>
                                     <div>
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>
                                    </div>
                                    <!--<hr class="dash" />-->
                             

                                
                             
                                </div>



                            </div>
        </div>
        <div class="col-md-12" style="margin-top:9%;">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="border-bottom:3px solid #ffc511">
                <h3 style="text-align:center; font-weight:600; font-size:30px;">IDA Dashboard</h3>
            </div>
            <div class="col-md-4"></div>
        </div>
    </form>
</body>
</html>
