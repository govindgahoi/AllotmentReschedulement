<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NOC_OneTimeScheme.aspx.cs" Inherits="UpsidaAllottee.NOC_OneTimeScheme" %>

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

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                                
                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><br />
                                <span style="font-size: 25px; font-weight: bold;">Please Wait...</span>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            <div style="text-align: center">
                <img class="image-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
            </div>
            <div class="container-fluid">
            <div style="margin-top:8vh">
                Dear <asp:Label runat="server" ID="lblallottee"></asp:Label>,<br />
                This is to inform you that UPSIDA has reveived your payment.<br />
                Please find below, the receipt for the same.
            </div>
            <asp:Panel runat="server" style="margin-top:10px">
            <div class="row">
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" Text="TransactionID :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" ID="lblTransactionID" Text=""></asp:Label>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" Text="Date :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" ID="lblDate" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" Text="Email :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" ID="lblEmail" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" Text="Phone Number :"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                    <asp:Label runat="server" ID="lblPhoneNo" Text=""></asp:Label>
                </div>
            </div>
            </asp:Panel>
            <asp:Panel runat="server" style="margin-top:10px">
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">As on<i>&nbsp; Date of Application</i> :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server" ID="lblApplicationDate" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">Total Dues :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server" ID="lblTotalDues" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">50% Waiver in Interest under OTS Scheme<span style="color:red">*</span> :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server" ID="lblWaiver" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">Payable Amount :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server" ID="lblPayableAmount" Text=""></asp:Label>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" style="margin-top:10px;margin-bottom:10px">
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">Amount Paid :</asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server" ID="lblPaid" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <asp:Label runat="server">Remaining Amount :</asp:Label>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                        <asp:Label runat="server" ID="lblRemaining" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                    <asp:Button runat="server" OnClick="click_Pay" ID="lblPay" CssClass="btn btn-success" Text="Pay Remaining Amount" />
                </div>
                </div>
            </asp:Panel>
            <div><span style="color:red">*</span><i>Terms And Conditions applied. OTS Scheme is valid till 20 Feb 2022.</i></div>
            <div><i style="margin-left:5px">This is an electronically generated slip.</i></div>
                </div>
        </div>
    </form>
</body>
</html>
