<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTSDashboard.aspx.cs" Inherits="UpsidaAllottee.OTSDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uttar Pradesh Industrial Development Authority</title>
    <link rel="icon" href="images\upsidclogo.png" />

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <style>
        .request-table tr th {
            font-size: 12px;
            background-color: #006699 !important;
            color:white;
        }
        .DaysRemaining{
            color:green;
        }
        .Red{
            color:red;
        }
        .Green{
            color:green;
        }
        .navbar-inverse .navbar-nav > .active > a, .navbar-inverse .navbar-nav > .active > a:focus, .navbar-inverse .navbar-nav > .active > a:hover {
    color: #efefef;
    background-color: #08080861!important;
}
        .mainnavbar {
            height: 38px !important;
        }
        .navbar-nav .dropdown {
    padding: 0px 10px;
    border-radius: 13px 13px 2px 14px;
    background: #08080861;
}
        .col-md-2.col-lg-2.xyz.text-left {
    padding-top: 4px;
}
    @media screen and (min-width: 768px){
.jumbotron {
    padding-top:15px !important;
    padding-bottom:15px !important;
}
}
        .jumbotron {
    padding-top: 10px !important;
    padding-bottom: 10px !important;
    margin-bottom: 30px;
    background-color: #f3e7ff;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="navbar-header pull-left top-head-bg">
                <a href="Default.aspx" class="navbar-brand" style="width: 100%;">
                    <div class="col-md-8">
                        <img class="img-responsive" src="images/upsida-logo-name.png" />
                    </div>
                    <div class="col-md-4" style="margin-top: 2px;">
                        <img class="img-responsive" src="images/image4.png" />
                    </div>
                </a>
            </div>
        </div>
        <div class="clearfix"></div>
        <nav class="navbar navbar-inverse navbar-dark bg-dark" style="background-color: #006699;">
            <div class="container-fluid">
                <%--<div id="navbar" class="navbar-collapse collapse">--%>
                <ul class="nav navbar-nav nav-tabs" role="tablist">
                    <li role="presentation"><a href="/UpdateAllotmentDetails.aspx"><b>Interest Rate</b></a></li>
                    <%--<li role="presentation"><a href="#"><b>Balance Premium</b></a></li>--%>
                    <%--<li role="presentation" ><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>--%>
                    <li role="presentation"><a href="/OTSGrievancesMIS.aspx"><b>OTS Grievances MIS</b></a></li>
                    <li role="presentation"><a href="/OTSDashboard.aspx"><b>OTS Dashboard</b></a></li>
                    <li role="presentation" class="active"><a href="/OTSAllotteeLedgerSummary.aspx"><b>Allottee Ledger Summary</b></a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <span style="position: relative; top: 3px;"><b>Welcome </b>
                                <asp:Label ID="lblname" runat="server"></asp:Label></span>
                            <i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="./">My Account</a></li>
                            <li class="divider"></li>
                            <li><a tabindex="-1" href="/Default.aspx?logout=true">Logout</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="row" style="margin-left:5px;margin-right:5px;margin-top:10px" >
            <div class="col-lg-4 col-md-4 ">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Paid Amount (In Lacs)"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" Text="One Time Payment"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" ID="lblOneTimePayment"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" Text="Instalment Amounts"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" ID="lblInstalment"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Number of Applications"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Allottees applied for One Time Payment"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblAppliedOneTime"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Allottees applied for Instalment-wise Payment"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblAppliedInstalment"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
            <%--<div class="col-lg-4 col-md-4">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Total Grievances"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 24px; font-weight: 600; margin-bottom: 5px">
                            <asp:Label runat="server" ID="lblTotalGrievance"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="col-lg-4 col-md-4">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="No. of Applications in terms of Transaction Mode"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Online :"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblOnline"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Offline :"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblOffline"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div style="margin-left:5px;margin-right:5px;margin-top:10px" >
            <div class="row">
                <div class="col-md-3 col-lg-3 text-left">
                     <asp:Button ID="btnTransactionExport" runat="server" Text="Download Report" class="btn btn-info btn-sm" OnClick="Click_TransactionExport" />
                     <asp:Button ID="btnPayOffline" runat="server" Text="Pay Offline" class="btn btn-info btn-sm" OnClick="Click_PayOffline" />
                 </div>
                <div class="col-md-6 col-lg-6 text-center">
                     <asp:Label  runat="server" Text="OTS-TRANSACTION-DETAILS" style="font-size:16px;font-weight:600" />
                 </div>
                <div class="col-md-3 col-lg-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Class="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="Onddl_Changed" Width="40%">
                        <asp:ListItem Text="--All Type--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Online" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Offline" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox type="date" ID="txtDate" runat="server" AutoPostBack="true"  OnTextChanged="OnDateChange" Class="chosen input-sm similar-select1 margin-left-z" width="55%"></asp:TextBox>
                    <%--<div class="row">
                        <div class="col-lg-6 col-md-6">
                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            
                        </div>
                    </div>--%>
                </div>
                 
            </div>
            
            <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
            <%--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
            
        </div>


          <div class="table-responsive" style="overflow-y: auto;  max-height: 390px;">
                      <asp:GridView ID="GridView_TransactionReport" runat="server" BackColor="#ffe6e6"
                          CssClass="table table-striped table-bordered table-hover request-table "
                          HeaderStyle-CssClass="FixedHeader"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="AllotteeID"
                          GridLines="Horizontal"
                          OnRowDataBound="Grid_TransactionReport_RowDataBound"
                          Width="100%"
                          AllowPaging="true"
                          PageSize="50"
                          OnPageIndexChanging="OnPageIndexChanging_TransactionReport"
                          PagerStyle-CssClass="pagination-ys"
                          PagerStyle-HorizontalAlign="Right">
                          <HeaderStyle 
                                BackColor="Crimson" 
                                Font-Italic="false" 
                                ForeColor="Snow" 
                            />
                          <Columns>
                              <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                      </asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              
                              <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office"  />
                              <asp:BoundField DataField="IAName" HeaderText="IA Name" />
                              <%--<asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />--%>
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot NO." />
                              <%--<asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge (In Rs.)" />--%>
                              <%--<asp:BoundField DataField="InterestOnMaintenanceChargeUpTo30-06-21" HeaderText="Interest On Maintenance Charge UpTo 30-06-2021 (In Rs.)" HeaderStyle-Width="15%" />--%>
                              <%--<asp:BoundField DataField="InterestOnMCUpto" HeaderText="Total Interest (In Rs.)"  />--%>
                              <asp:BoundField DataField="ToBePaid" HeaderText="To Be Paid (In Rs.)"  />
                              <asp:BoundField DataField="Waive_Off" HeaderText="Waive_Off (In Rs.)"  />
                              <asp:BoundField DataField="Fee_Amount" HeaderText="Paid (In Rs.)"  />
                              <asp:BoundField DataField="TransactionDate" HeaderText="PT Date" DataFormatString="{0:d}" />
                              <%--<asp:BoundField DataField="Fee_Amount_Paid" HeaderText="Fee Amount Paid"  />--%>
                              <asp:BoundField DataField="Balance_Amount" HeaderText="Balance Amount (In Rs.)"  />
                              <asp:BoundField DataField="Bal_Trans_Date" HeaderText="BT Date" DataFormatString="{0:d}" />
                              <asp:BoundField DataField="Inst_Fee_Amount1" HeaderText="1st Instalment (In Rs.)"  />
                              <asp:BoundField DataField="Inst_Fee_Amount2" HeaderText="2nd Instalment (In Rs.)"  />
                              <asp:BoundField DataField="Inst_Fee_Amount3" HeaderText="3rd Instalment (In Rs.)"  />
                              <asp:BoundField DataField="TransMode" HeaderText="Transaction Mode" />
                              <asp:BoundField DataField="PaymentType" HeaderText="Payment Type"  />
                             </Columns>
                          <EmptyDataTemplate>
                              No Record Available
                          </EmptyDataTemplate>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <%--//<HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#003399" />--%>
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                          <HeaderStyle CssClass="GridViewHeaderStyle"/>
                      </asp:GridView>
                  </div>

</div>
    </form>
</body>
</html>
