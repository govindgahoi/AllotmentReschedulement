<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Allotment.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" />
    <%-- <style>
		body {
			font: 15px/1.5 arial, helvetica, sans-serif;
		}
		p1:first-letter {
			float: left;
			font-size: 45px;
			line-height: 1;
			font-weight: bold;
			margin-right: 9px;
			color: #9c0;
			font-family: "Times New Roman", Times, serif;
			text-shadow: #690 .05em .05em;
		}
	</style>--%>
    <style type="text/css">
        .item {
            height: 307px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="pagewrap">
        <section id="content">
            <div class="item">
                <img alt="" title="" src="images/upsidc1.png" />
            </div>
        </section>
        <section id="middle">
            <div class="left-heading">
                <br />
                May I help You?  
            </div>
            <div style="height: 228px">
                <ul>
                    <li><a href="../RegisterNewUser.aspx">New User? Get User ID</a>
                        <img src="images/user_add.png" alt="New User" style="width: 10px; height: 10px;" /></li>
                    <li><a href="Masters/ServiceTimelinesCreate.aspx">Forgot Password? Get Password</a>
                        <img src="images/email.png" alt="New User" style="width: 10px; height: 10px;" /></li>
                    <li><a href="PlotAllotment.aspx">Trouble Logging in?</a>
                        <img src="images/unlock.png" alt="New User" style="width: 10px; height: 10px;" /></li>
                    <li><a href="Index.aspx">View Online Demo</a>
                        <img src="images/movie.png" alt="Demo" style="width: 10px; height: 10px;" /></li>
                </ul>
                <br />
                <br />
                <br />
                <br />
                <br />
                 <br />
            </div>
        </section>

        <aside id="sidebar" >
            <div class="left-heading"><i class="fa fa-unlock-alt" aria-hidden="true"></i>Login</div>
            <div class="col-md-12">
                <div class="clearfix"></div>
                <div class="form-group">
                    <label class="control-label">Please Login using your Allotment Number.</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" Width="140px">Enter your Allotment Number</asp:TextBox>
                        <br />
                    </div>
                     <div class="input-group" style="margin-top:10px">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control"  Width="140px">Enter Password</asp:TextBox>
                         
                    </div>
                    <div class="input-group" style="margin-top:10px">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:DropDownList ID="drpCat" CssClass="btn btn-default dropdown-toggle" runat="server"  Width="140px"></asp:DropDownList>
                    </div>
                
                    <div class="login-btn">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>
                    </div>
                    <br /> <br /> 
                </div>
                
            </div>

        </aside>

        <footer>
            <h4>Important security information:</h4>
            <p>The single window service is being provided in all the UPSIDC offices where the applicant can submit his/her application relating to UPSIDC work at the counter. An acknowledgement receipt is issued on receipt of application indicating the date when the final reply will be given and in case of rejection of the application the reason for rejection is also mentioned on the receipt.</p>
            <p>Never provide your User ID or password to any one on phone or in response to a mail.Report a suspicious mail.</p>
            <p>Do not enter login or other sensitive information in any pop up window.</p>
        </footer>

    </div>



</asp:Content>
