<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="AllotteeKYA.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeKYA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Allottee | KYA</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper allottee-leadger">
        <section class="content">
             <div class="box">
             <div class="heading-main-top">
                    <h1 class="subtitle fancy"><span>KYA Form</span> </h1>
                  
                </div>
            <div class="allotteeKYA">
                
               <div class="form-ditails80">
                <div class="row">
                    <div class="kya">
                        <img src="dist/img/upsida-logo.png" />
                        <h2>Know Your Allottee (KYA) Form </h2>
                        <p class="entire">(Entire form is to be filled in block letters Only)</p>
                    </div>
                </div>
            <div class="row">
                <div class="form-group">

                    <div class="col-md-4 text-left">
                        <label>Allotment Id:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox1" CssClass="allotment-letter2" placeholder="Allottee Id:" runat="server"></asp:TextBox>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Name of Allottee:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox2" CssClass="allotment-letter2" placeholder="Name of Allottee:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Regional Office:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox3" CssClass="allotment-letter2" placeholder="Regional Office:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Industrial Area:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox4" CssClass="allotment-letter2" placeholder="Industrial Area:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Plot No:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox5" CssClass="allotment-letter2" placeholder="Plot No:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Email Id:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox6" CssClass="allotment-letter2" placeholder="Email Id:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Mobile No:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox7" CssClass="allotment-letter2" placeholder="Mobile No:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>GST Registration Status:</label>
                    </div>
                    <div class="col-md-8">
                        <div class=" col-md-3">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Yes" /></div>
                        <div class=" col-md-3">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="No" /></div>
                        <div class=" col-md-6"></div>
                      <%-- <asp:TextBox ID="TextBox8" CssClass="allotment-letter2" placeholder="GST Registration Status:" runat="server"></asp:TextBox>--%>
                    </div>
                </div>
            </div>
                   <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>GST Registration No:</label>
                    </div>
                    <div class="col-md-8">
                       <asp:TextBox ID="TextBox12" CssClass="allotment-letter2" placeholder="GST Registration No:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Date of GST Registration:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox9" CssClass="allotment-letter2" placeholder="Date of GST Registration:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>PAN:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox10" CssClass="allotment-letter2" placeholder="PAN:" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4 text-left">
                        <label>Aadhar Card:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox11" CssClass="allotment-letter2" placeholder="Aadhar Card" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="declaration50">
                    <h3>Declaration:</h3>

                    <p>This is to certify that I/we am/are allottee(s) of the above mentioned property and all the information provided in this “KYA Form” is correct and true to the best of my/our knowledge and belief.</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 ">
                    <asp:Button ID="Button1" CssClass="button9" runat="server" Text="Submit" />
                </div>
            </div>
                   </div>
    </div>
</div>
    </section>
    </div>
</asp:Content>


