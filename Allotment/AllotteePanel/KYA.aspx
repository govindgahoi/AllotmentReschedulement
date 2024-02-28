<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="KYA.aspx.cs" Inherits="Allotment.AllotteePanel.KYA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Allottee | KYA FORM  </title>

    <style>
    .box22{
        display: none;
    }
    .no22{display:none }
    .yes22{display:block}
</style>
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script>
$(document).ready(function(){
    $('input[type="radio"]').click(function(){
        var inputValue = $(this).attr("value");
        var targetBox = $("." + inputValue);
        $(".box22").not(targetBox).hide();
        $(targetBox).show();
    });
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="card-solid">
                <div class="card-body pb-0">
                    <div class="box">
                        <%-- KYA FORM Start--%>
                        <div class="heading-main-top">
                            <h1 class="subtitle fancy"><span>KYA Form</span></h1>
                        </div>
                    </div>
                    <div class="allotteeKYA">
                        <div class="form-ditails80">
                            <div class="kya">
                                <img src="dist/img/upsida-logo.png" class="img-fluid" />
                                <h2>Know Your Allottee (KYA) Form </h2>
                                <p class="entire">(Entire form is to be filled in block letters Only)</p>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Allotment Id:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtAllotmentID" CssClass="allotment-letter2" placeholder="Allotment Id" runat="server" AutoPostBack="True" OnTextChanged="txtAllotmentID_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Name of Allottee:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtAName" CssClass="allotment-letter2" placeholder="Name of Allottee" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Regional Office:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                         
                                        <asp:TextBox ID="txtRegional" CssClass="allotment-letter2" placeholder="Regional Office" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Industrial Area:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                         
                                        <asp:TextBox ID="txtIndustrial" CssClass="allotment-letter2" placeholder="Industrial Area" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Plot No:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtPlot" CssClass="allotment-letter2" placeholder="Plot No" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Email Id:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtEmail" CssClass="allotment-letter2" placeholder="Email Id" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Mobile No:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtMobile" CssClass="allotment-letter2" placeholder="Mobile No" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>GST Registration Status:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="row">
                                         <div class="input-group parent-table">
                                        <asp:RadioButtonList ID="RadioButtonList1" CssClass="mGrid2 mb-2" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="yes22">Yes</asp:ListItem>
                                            <asp:ListItem Value="no22">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        
                                        </div>
                                        <%-- <asp:TextBox ID="TextBox8" CssClass="allotment-letter2" placeholder="GST Registration Status:" runat="server"></asp:TextBox>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12 box22 yes22">
                                    <div class="input-group ">
                                        <label>GST Registration No:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12 box22 yes22">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtGSTNO" CssClass="allotment-letter2" placeholder="GST Registration No" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12 box22 yes22">
                                    <div class="input-group ">
                                        <label>Date of GST Registration:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12 box22 yes22">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtGSTRegDate" CssClass="allotment-letter2" TextMode="Date" placeholder="Date of GST Registration" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>PAN:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtPAN" CssClass="allotment-letter2" placeholder="PAN" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Aadhar Card:</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group ">
                                        <asp:TextBox ID="txtAadhar" CssClass="allotment-letter2" placeholder="Aadhar Card" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-xl-4 col-sm-12">
                                    <div class="input-group ">
                                        <label>Attach Relevant Documents</label>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-xl-8 col-sm-12">
                                    <div class="input-group choosefile">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <span>Maximum upload size is 500kb Only .pdf file is allowed.</span>
                                    </div>
                                </div>
                            </div>
                            <div class="declaration50">
                                <h3>Declaration:</h3>
                                <p>This is to certify that I/we am/are allottee(s) of the above mentioned property and all the information provided in this “KYA Form” is correct and true to the best of my/our knowledge and belief.</p>
                            </div>
                            <div class="col-md-12 ">
                                <button type="button" class="button9" data-toggle="modal" data-target="#staticBackdrop">Submit</button>
                               <%-- <asp:Button ID="Button1" CssClass="button9" runat="server" Text="Submit" />--%>
                            </div>
                        </div>
                    </div>
                    <%--  KYA FORM End--%>
                    <!-- Button trigger modal -->
                     <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabel">Confirmation information </h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <p>I/We hereby declare that all the information provided is true and correct to the best of my/our knowledge and belief and is provided for the allottee and no other third party. I/We undertake to inform you of any changes therein, immediately. In case any of the above information is found to be false or untrue or misleading or misrepresenting, I am/we are aware that I/we may be held liable for it. I/We understand that the information provided will solely be used for communication purposes only and no other purpose.</p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                   <%-- <button type="button" class="btn btn-primary">Yes</button>--%>
                                     <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Yes" OnClick="SavePopup" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal -->
                   
                </div>
            </div>
        </section>
    </div>
</asp:Content>

