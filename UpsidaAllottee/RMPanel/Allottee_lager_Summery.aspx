<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Allottee_lager_Summery.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Allottee_lager_Summery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script type="text/javascript">
    $(document).ready(function () {
        $('[id*=GridView_TransactionReport]').prepend($("<thead></thead>").append($('[id*=GridView_TransactionReport]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 20,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });

 
    });
</script>

    <script type="text/javascript">
function PrintGridData() {
var prtGrid = document.getElementById('<%=GridView_TransactionReport.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Outstanding Dues Summary <span>details of</span></h1>
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-lg-4 col-md-4 mb-3">
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <p class="float-end col-form-label">* Regional Office</p>
                                </div>
                                <div class="col-lg-6 col-md-6">                                     
                                    <asp:DropDownList ID="dlRO" runat="server" CssClass="form-select" AutoPostBack="true" 
                                        OnSelectedIndexChanged="dlRO_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 mb-3">
                            <div class="mou-summary">
                                <h4 class="card-title text-white">Summary</h4>
                                <p class="text-white">Total Plots in System = <asp:Label runat="server" ID="lblTotalPlot"></asp:Label></p>
                               <p class="text-white">Total Allottees in System = <asp:Label runat="server" ID="lblTotalAllottee"></asp:Label></p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 mb-3">
                            <div class="mou-summary">
                                <h4 class="card-title text-white">Demand Summary (in Rs.)</h4>
                                <p class="text-white">Total Demand = <asp:Label runat="server" ID="lblTotalDemand"></asp:Label></p>
                               <p class="text-white">Total Paid = <asp:Label runat="server" ID="lblTotalPaid"></asp:Label></p>
                                <p class="text-white">Total Outstanding Dues =  <asp:Label runat="server" ID="lblTotalOutstandingDue"></asp:Label></p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 mb-2">
                            <div class="offices float-start">
                                <%--<input id="Button1" type="button" class="approve" value="Download Report" />--%>
                                 <input type="button" id="btnPrint" class="approve" value="Print" onclick="PrintGridData()" />
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 mb-2">
                            <div class="row">
                                <div class="col-3">
                                    <p class="float-end col-form-label">Search</p>
                                </div>
                                <div class="col-6">
                                    <asp:TextBox runat="server" ID="txtSearch1" class="form-control" placeholder="Search"></asp:TextBox>
                                </div>
                                <div class="col-3">
                                    <asp:Button ID="btnSearch" class="approve" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive" style="max-height:500px">
                        <asp:GridView ID="GridView_TransactionReport" runat="server"    
                          CssClass="mGrid2"
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
                          
                      </asp:GridView>
                        <%--<div class="dataTable-bottom">
                            <div class="dataTable-info">Showing 1 to 5 of 5 entries</div>
                            <nav aria-label="Page navigation example">
                                <ul class="pagination justify-content-end">
                                    <li class="page-item disabled">
                                        <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item">
                                        <a class="page-link" href="#">Next</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>--%>
                    </div>

                    <div class="panel">
                       
                            <div class="col-lg-12 col-md-12 m-3 text-center">
                                <span class="card-title">All Plots</span>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel-heading font-bold">
                                    <div class="table-responsive">
                                         <asp:GridView ID="GridView1" runat="server"  
                          CssClass="mGrid2"
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
                           
                      </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                   
                    <div class="panel">
                      
                            <div class="col-lg-12 col-md-12 m-3 text-center">
                                <span class="card-title">Industrial Plots</span>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="panel-heading font-bold ">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView3" runat="server" 
                          CssClass="mGrid2"
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
                          
                      </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                  
                </div>
            </div>
        </section>
    </main>
</asp:Content>
