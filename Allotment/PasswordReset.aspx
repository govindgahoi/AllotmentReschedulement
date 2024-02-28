<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Allotment.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="pagewrap">
         <header>
             <h4>Have you updated your KYC with UPSIDC?</h4>
              <p>Dear User,</p>


         </header>
       
        <section id="middle">
            <h4>Have you updated your KYC with UPSIDC?</h4>
            <p>Dear User,</p>
            <p>Dear User,</p>

        </section>

        <aside id="sidebar">


            <div class="left-heading"><i class="fa fa-unlock-alt" aria-hidden="true"></i>Login</div>
            <div class="col-md-12">
                <div class="clearfix"></div>
                <div class="form-group">
                    <label class="control-label">Please Login using your Allotment Number.</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox ID="txtAllotment" runat="server">Enter your Allotment Number</asp:TextBox>

                        <%--<input id="email" class="form-control" name="email" value="" placeholder="Please enter your Allotment Number." type="email">--%>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:DropDownList ID="drpCat" runat="server"></asp:DropDownList>
                    </div>
                    <div class="text-right">
                        <a href="javascript:;" class="forget">Troubled in Login?</a>
                    </div>
                    <div class="login-btn">
                       
                    </div>
                     <div>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#FC590A"></asp:Label>
                    </div>

                </div>

            </div>

        </aside>

        <footer>
            <h4>Single Window Clearence System</h4>
            <p>The single window service is being provided in all the UPSIDC offices where the applicant can submit his/her application relating to UPSIDC work at the counter. An acknowledgement receipt is issued on receipt of application indicating the date when the final reply will be given and in case of rejection of the application the reason for rejection is also mentioned on the receipt.</p>
        </footer>

    </div>
</asp:Content>
