<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NOC_OneForthUpfront_Payment.aspx.cs" Inherits="UpsidaAllottee.NOC_OneForthUpfront_Payment" %>
<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />

  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div style="text-align: center">
                <img class="image-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
            </div>
            <div class="container-fluid">
            <div style="margin-top:8vh">
                Dear <asp:Label runat="server" ID="lblallottee"></asp:Label>,<br />
                This is to inform you that UPSIDA has received your payment.<br />
                Please find below, the receipt for the same.
            </div>
            <asp:Panel runat="server" style="margin-top:10px">
            <div class="row">
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" Text="TransactionID :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" ID="lblTransactionID" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" Text="Date :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" ID="lblDate" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" Text="Email :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" ID="lblEmail" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" Text="Phone Number :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4">
                    <asp:Label runat="server" ID="lblPhoneNo" Text=""></asp:Label>
                </div>
            </div>
            </asp:Panel>
            <asp:Panel runat="server" style="margin-top:10px">
                <div class="row">
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server">As on<i>&nbsp; Date of Application</i> :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server" ID="lblApplicationDate" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server">Total Dues :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server" ID="lblTotalDues" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server">50% Waiver in Interest under OTS Scheme<span style="color:red">*</span> :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server" ID="lblWaiver" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server">Payable Amount :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <asp:Label runat="server" ID="lblPayableAmount" Text=""></asp:Label>
                    </div>
                </div>
            </asp:Panel>
                <div class="row" style="padding-left:50px;padding-right:50px;width:70em">
                    <div class="col"></div>
               
            <table class="table table-responsive table-hover table-bordered table-myspacing-top" runat="server">
                <thead>
                    <tr>
                        <td style="width:180px">Payable</td>
                        <td>Amount</td>
                        <td>Status</td>
                        <td>Date</td>
                        <td>Action</td>
                        
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><asp:Label runat="server">Down Payment</asp:Label></td>
                        <td><asp:Label runat="server" ID="lblDownPaymentAmount"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblDownPaymentStatus"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblDownPaymentDate"></asp:Label></td>
                        <td><%--<asp:Button runat="server" ID="lblDownPaymentDate"></asp:Button>--%></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server">1st Instalment</asp:Label></td>
                        <td><asp:Label runat="server" ID="lblFirstInstalmentAmount"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblFirstStatus"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblFirstInstDate"></asp:Label></td>
                        <td><asp:Button runat="server" ID="btnPayFirstInstalment" Text="Pay Now" Style="border: 1px solid #ccc;color: #000;font-size: 14px;" CssClass="btn-info"  OnClick="btnPay_Click1"></asp:Button></td>

                    </tr>
                    <tr>
                        <td><asp:Label runat="server">2nd Instalment</asp:Label></td>
                        <td><asp:Label runat="server" ID="lblSecInstalmentAmount"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblSecStatus"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblSecInstDate"></asp:Label></td>
                        <td><asp:Button runat="server" ID="btnPaySecInstalment" Text="Pay Now" CssClass="btn-info" Style="border: 1px solid #ccc;color: #000;font-size: 14px;"  OnClick="btnPay_Click2"></asp:Button></td>

                    </tr>
                    <tr>
                        <td><asp:Label runat="server">3rd Instalment</asp:Label></td>
                        <td><asp:Label runat="server" ID="lblThirdInstalmentAmount"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblThirdStatus"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblThirdInstDate"></asp:Label></td>
                        <td><asp:Button runat="server" ID="btnPayThirdInstalment" Text="Pay Now" CssClass="btn-info" Style="border: 1px solid #ccc;color: #000;font-size: 14px;"  OnClick="btnPay_Click3"></asp:Button></td>

                    </tr>
                </tbody>
            </table>
                     </div>
            <div><span style="color:red">*</span><i>Terms And Conditions applied.</i></div>
            <div><i style="margin-left:5px">This is an electronically generated slip.</i></div>
                </div>
        </div>
    </form>
</body>
</html>

