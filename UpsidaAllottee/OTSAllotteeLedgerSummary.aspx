<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTSAllotteeLedgerSummary.aspx.cs" Inherits="UpsidaAllottee.OTSAllotteeLedgerSummary" %>

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

     <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <style>
        .request-table tr th {
            font-size: 12px;
            background-color: #006699 !important;
            color:white;
        }
        .DaysRemaining{
            color:green;
            text-align:center;
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
    <script type="text/javascript">
    $(document).ready(function () {
        $('[id*=GridView_TransactionReport]').prepend($("<thead></thead>").append($('[id*=GridView_TransactionReport]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 20,
            buttons: [
               /* { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },*/
                { extend: 'csv', text: 'Download Report A', className: 'exportExcel', filename: 'AllotteeLedgerSummary', exportOptions: { modifier: { page: 'all'}} }
                /*, { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }*/
            ]
        });
    });
</script>
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
      <nav class="navbar navbar-inverse navbar-dark bg-dark" style="background-color:#006699;">
                             <div class="container-fluid">
         
          <%--<div id="navbar" class="navbar-collapse collapse">--%>
            <ul class="nav navbar-nav nav-tabs" role="tablist">
                <li role="presentation" ><a href="/UpdateAllotmentDetails.aspx" ><b>Interest Rate</b></a></li>
                <%--<li role="presentation"><a href="#"><b>Balance Premium</b></a></li>--%>
                <%--<li role="presentation" ><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>--%>
                <li role="presentation" ><a href="/OTSGrievancesMIS.aspx"><b>OTS Grievances MIS</b></a></li>
                <li role="presentation" ><a href="/OTSDashboard.aspx"><b>OTS Dashboard</b></a></li>
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
           </nav>  
        <div class="row" id="SideDiv" style="padding-top: 30px; padding-bottom: 30px; margin-top: 0px;">

            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 10px; font-size: 16px">
                <%--<div style="background: #ececec; margin-top: 0px; padding: 10px 0;">--%>
                <div style=" margin-top: 0px; padding: 10px 0;">
                    <div class="row" style="padding-left: 30px; padding-bottom: 30px; padding-right: 30px; text-align: center">
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <span style="color: Red;font-size:14px!important">*</span>
                                    Regional Office
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="dlRO" runat="server" CssClass="chosen input-sm similar-select1 margin-left-z" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                       <%-- <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <span style="color: Red">*</span>
                                    Industrial Area
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="DlIA" runat="server" AutoPostBack="true" CssClass="chosen input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="DlIA_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <span style="color: Red">*</span>
                                    Search By Plot Number
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" CssClass="chosen input-sm similar-select1 margin-left-z" Font-Size="small"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center" style="font-size:14px!important">
                                    <span style="color: Red">*</span>
                                    Search By ComplaintID
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="true" OnTextChanged="GetListSearchByComplaintID" CssClass=" chosen input-sm similar-select1 margin-left-z" Font-Size="small"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                        <div class="col-md-2 col-lg-2 col-sm-4">
                            <div class="row" style="padding-left: 10px">
                                <div class="col text-center">
                                    &nbsp;
                                </div>
                                <div class="col">
                                    <%--<asp:Button ID="btnSave" runat="server" Text="DOWNLOAD REPORT A" class="btn btn-info btn-sm" OnClick="ExportExcel" Visible="False" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                  
                    <div class="row" style="margin-left:5px;margin-right:5px;margin-top:10px" >
            <div class="col-lg-4 col-md-4 ">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Summary"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" Text="Total Plots in System"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" ID="lblTotalPlot"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" Text="Total Allottees in System"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <asp:Label runat="server" ID="lblTotalAllottee"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Demand Summary (in Rs.)"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-8 col-md-8">
                            <asp:Label runat="server" Text="Total Demand"></asp:Label>
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <asp:Label runat="server" ID="lblTotalDemand"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-8 col-md-8">
                            <asp:Label runat="server" Text="Total Paid"></asp:Label>
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <asp:Label runat="server" ID="lblTotalPaid"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-8 col-md-8">
                            <asp:Label runat="server" Text="Total Outstanding Dues "></asp:Label>
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <asp:Label runat="server" ID="lblTotalOutstandingDue"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            
            <%--<div class="col-lg-4 col-md-4">
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Allottee Ledger Summary"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Total Allottee Ledgers :"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblOnline"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 10px">
                        <div class="col-lg-9 col-md-9">
                            <asp:Label runat="server" Text="Ledgers Modified in 2022 :"></asp:Label>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:Label runat="server" ID="lblOffline"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
                    
                    
                    <div>
                       

         <div class="table-responsive" style="overflow-y: auto; ">
                      <asp:GridView ID="GridView_TransactionReport" runat="server" BackColor="#ffe6e6"
                          CssClass="table table-striped table-bordered table-hover request-table "
                          HeaderStyle-CssClass="FixedHeader"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="AllotteeID"
                          GridLines="Horizontal"
                         
                          Width="100%"
                           
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
                              <asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />
                               <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                               
                              <%--<asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge (In Rs.)" />--%>
                              <%--<asp:BoundField DataField="InterestOnMaintenanceChargeUpTo30-06-21" HeaderText="Interest On 
                                  Maintenance Charge UpTo 30-06-2021 (In Rs.)" HeaderStyle-Width="15%" />--%>
                              <%--<asp:BoundField DataField="InterestOnMCUpto" HeaderText="Total Interest (In Rs.)"  />--%>
                              <asp:BoundField DataField="Demanded" HeaderText="Total Demand(In Rs.)"  />
                              <asp:BoundField DataField="Paid" HeaderText="Total Paid(In Rs.)"  />
                              <asp:BoundField DataField="Outstanding" HeaderText="Total Outstanding Dues (In Rs.)"  />
                              <asp:BoundField DataField="ModifiedOn" HeaderText="Modified On Date" DataFormatString="{0:dd/MM/yyyy}"  />
                               
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

                 
<div class="panel">
        <div class="row">
          
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="All Plots"></asp:Label>
                        </div>
                    
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading font-bold" style="text-align: center;">
              <div class="table-responsive" style="overflow-y: auto;  max-height: 390px;">
                      <asp:GridView ID="GridView1" runat="server" BackColor="#ffe6e6"
                          CssClass="table table-striped table-bordered table-hover request-table "
                          HeaderStyle-CssClass="FixedHeader"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                         
                          GridLines="Horizontal"
                         
                          Width="100%"
                           
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
                              <%--<asp:BoundField DataField="IAName" HeaderText="IA Name" />--%>
                              <%--<asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />--%>
                              <asp:BoundField DataField="PlotNo" HeaderText="Total Plot" />
                               <asp:BoundField DataField="Allottee" HeaderText="Total Allottee" />
                               <%--<asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />--%>
                              <%--<asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge (In Rs.)" />--%>
                              <%--<asp:BoundField DataField="InterestOnMaintenanceChargeUpTo30-06-21" HeaderText="Interest On 
                                  Maintenance Charge UpTo 30-06-2021 (In Rs.)" HeaderStyle-Width="15%" />--%>
                              <%--<asp:BoundField DataField="InterestOnMCUpto" HeaderText="Total Interest (In Rs.)"  />--%>
                              <asp:BoundField DataField="Modified" HeaderText="Number of Allottee Ledgers Modified in 2022"  />
                              <asp:BoundField DataField="ModifiedREmain" HeaderText="Allottee Ledgers Remaining to be Modified"  />
                             <%-- <asp:BoundField DataField="Outstanding" HeaderText="Total Outstanding Dues (In Rs.)"  />
                              <asp:BoundField DataField="ModifiedOn" HeaderText="Modified On Date" DataFormatString="{0:d}" />--%>
                               
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

                
            </div>
        </div>
    </div>
                  <div class="clearfix"></div>
              <%--</asp:View>--%>

                     

                        <div class="panel">
        <div class="row">
          
                        <div class="col-lg-12 col-md-12 text-center" style="font-size: 17px; font-weight: 600; margin-bottom: 15px">
                            <asp:Label runat="server" Text="Industrial Plots"></asp:Label>
                        </div>
                    
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading font-bold" style="text-align: center;">
                   <div class="table-responsive" style="overflow-y: auto;  max-height: 390px;">
                      <asp:GridView ID="GridView3" runat="server" BackColor="#ffe6e6"
                          CssClass="table table-striped table-bordered table-hover request-table "
                          HeaderStyle-CssClass="FixedHeader"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                         
                          GridLines="Horizontal"
                         
                          Width="100%"
                           
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
                              <%--<asp:BoundField DataField="IAName" HeaderText="IA Name" />--%>
                              <%--<asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />--%>
                              <asp:BoundField DataField="PlotNo" HeaderText="Total Plot" />
                               <asp:BoundField DataField="Allottee" HeaderText="Total Allottee" />
                               <%--<asp:BoundField DataField="AllotteeID" HeaderText="Allottee ID" />--%>
                              <%--<asp:BoundField DataField="MaintenanceCharge" HeaderText="Maintenance Charge (In Rs.)" />--%>
                              <%--<asp:BoundField DataField="InterestOnMaintenanceChargeUpTo30-06-21" HeaderText="Interest On 
                                  Maintenance Charge UpTo 30-06-2021 (In Rs.)" HeaderStyle-Width="15%" />--%>
                              <%--<asp:BoundField DataField="InterestOnMCUpto" HeaderText="Total Interest (In Rs.)"  />--%>
                              <asp:BoundField DataField="Modified" HeaderText="Number of Allottee Ledgers Modified in 2022"  />
                              <asp:BoundField DataField="ModifiedREmain" HeaderText="Allottee Ledgers Remaining to be Modified"  />
                             <%-- <asp:BoundField DataField="Outstanding" HeaderText="Total Outstanding Dues (In Rs.)"  />
                              <asp:BoundField DataField="ModifiedOn" HeaderText="Modified On Date" DataFormatString="{0:d}" />--%>
                               
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

                <div class="bp-divviewer">
                    <asp:Literal ID="Literal2" runat="server" />
                </div>
            </div>
        </div>
    </div>

                        
                      <%--<div class="panel">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="panel-heading font-bold" style="text-align: center;">
                    Document Viewer                        
                </div>

                <div class="bp-divviewer">
                    <asp:Literal ID="ltEmbed" runat="server" />
                </div>
            </div>
        </div>
    </div>--%>
                    </div>
                </div>
            </div>
        </div>

        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>

    <%-- <script type="text/javascript">
         $(document).ready(function () {
             $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: '<%=ResolveUrl("~/searchService.asmx/GetAutoCompleteData") %>',
                        data: "{" +
                        "'txtSearch':'" + request.term + "'," +
                        "'IAName':'" + $('#<%= DlIA.ClientID %>').val() + "'" +
                      
                        "}",
                        dataType: "json",
                        //async:false,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                //    select: function (e, i) {
                //    $("[id$=hfCustomerId]").val(i.item.val);
                //},
                minLength: 1
            });
        });
        $("input[type=text]").keyup(function () {
            $("#gridView").hide();
            $("#warningmsg").hide();
          
        });

    </script>
   --%>
</body>
</html>
