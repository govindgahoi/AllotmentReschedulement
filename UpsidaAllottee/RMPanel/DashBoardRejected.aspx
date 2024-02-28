<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="DashBoardRejected.aspx.cs" Inherits="UpsidaAllottee.RMPanel.DashBoardRejected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
function PrintGridData() {
var prtGrid = document.getElementById('<%=grdGreStatus.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}

         function PrintGridData1() {
var prtGrid = document.getElementById('<%=GridViewKYA.ClientID %>');
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
             <div class="row summery-off-dashboard">
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <%--<div class="card info-card sales-card">
                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>
                                <li><a class="dropdown-item" href="#">One Time Payment</a></li>
                                <li><a class="dropdown-item" href="#">4776.69</a></li>
                                <li><a class="dropdown-item" href="#">Instalment Amounts</a></li>
                                <li><a class="dropdown-item" href="#">1852.75</a></li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title">Paid Amount (In Lacs) <span>| Today</span></h5>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-cart"></i>
                                </div>
                                <div class="ps-3">
                                    <h6><i class="bi bi-currency-rupee"></i> 145</h6>
                                    <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                </div>
                            </div>
                        </div>

                    </div>--%>
                     <div class="card info-card sales-card">
                        
                        <div class="card-body">
                            <%--<h5 class="card-title">Pending Grievance </h5>--%>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-file-earmark-medical-fill"></i>
                                </div>
                                <div class="ps-3">
                                    <h5 class="card-title">Pending Grievance </h5>
                                    <h6><asp:Label ID="lblPGrievance" runat="server" Text="0"></asp:Label></h6>
                                  <%--  <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>--%>

                                </div>
                            </div>
                        </div>

                    </div>
                </div><!-- End Sales Card -->
                <!-- Revenue Card -->
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <%--<div class="card info-card revenue-card">

                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>

                                <li><a class="dropdown-item" href="#">Allottees applied for One Time Payment</a></li>
                                <li><a class="dropdown-item" href="#">2372</a></li>
                                <li><a class="dropdown-item" href="#">Allottees applied for Instalment-wise Payment</a></li>
                                <li><a class="dropdown-item" href="#">777</a></li>
                            </ul>
                        </div>

                        <div class="card-body">
                            <h5 class="card-title">Number of Applications <span>| Today</span></h5>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-currency-rupee"></i>
                                </div>
                                <div class="ps-3">
                                    <h6><i class="bi bi-currency-rupee"></i> 3,264</h6>
                                    <span class="text-success small pt-1 fw-bold">8%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                </div>
                            </div>
                        </div>

                    </div>--%>
                     <div class="card info-card revenue-card">
                        <div class="card-body">
                            <%--<h5 class="card-title">MoU Request for GBC</h5>--%>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-file-earmark-text"></i>
                                </div>
                                <div class="ps-3">
                                    <h5 class="card-title">Pending KYA Requests</h5>
                                    <h6><asp:Label ID="lblKYAPending" runat="server" Text="0"></asp:Label></h6>
                                   <%-- <span class="text-success small pt-1 fw-bold">8%</span> <span class="text-muted small pt-2 ps-1">increase</span>--%>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- End Revenue Card -->
                <!-- Customers Card -->
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">

                    <%--<div class="card info-card customers-card">

                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>

                                <li><a class="dropdown-item" href="#">Online</a></li>
                                <li><a class="dropdown-item" href="#">2663</a></li>
                                <li><a class="dropdown-item" href="#">Offline</a></li>
                                <li><a class="dropdown-item" href="#">486</a></li>
                            </ul>
                        </div>

                        <div class="card-body">
                            <h5 class="card-title">Transaction Mode <span>| Today</span></h5>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-people"></i>
                                </div>
                                <div class="ps-3">
                                    <h6><i class="bi bi-currency-rupee"></i> 1244</h6>
                                    <span class="text-danger small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">decrease</span>

                                </div>
                            </div>

                        </div>
                    </div>--%>

                     <div class="card info-card customers-card">
                        <div class="card-body">
                            <%--<h5 class="card-title">Pending E-Auction Mapping</h5>--%>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <i class="bi bi-file-earmark-plus-fill"></i>
                                </div>
                                <div class="ps-3">
                                    <h5 class="card-title">Outstanding Dues</h5>
                                    <h6>Rs.<asp:Label ID="lblOutstandingDues" runat="server" Text="0"></asp:Label></h6>
                                    <%--<span class="text-danger small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">decrease</span>--%>

                                </div>
                            </div>

                        </div>
                    </div>

                </div><!-- End Customers Card -->
            </div>

            <div class="row">
                <!-- Reports -->
                <div class="col-xl-12 col-lg-12 col-md-6 col-sm-12">
                    <%--<div class="card">

                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>

                                <li><a class="dropdown-item" href="#">Today</a></li>
                                <li><a class="dropdown-item" href="#">This Month</a></li>
                                <li><a class="dropdown-item" href="#">This Year</a></li>
                            </ul>
                        </div>

                        <div class="card-body recent-sales">
                            <h5 class="card-title">Grievance summary <span>/Today</span></h5>
                            <div class="row">
                                <div class="col-md-6">
                                    <p>Pending Grievance</p>
                                </div>
                                <div class="col-md-6 text-end">
                                    <span>Total = 30</span>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="mGrid2">
                                    <thead>
                                        <tr>
                                            <th scope="col">S.No.</th>
                                            <th scope="col">Allotment Id</th>
                                            <th scope="col">Allottee Name</th>
                                            <th scope="col">Regional Office</th>
                                            <th scope="col">Industrial Area</th>
                                            <th scope="col">Grievance Type</th>
                                            <th scope="col">Grievance Description</th>
                                            <th scope="col">Pending At (level)</th>
                                            <th scope="col">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                          <td>#123</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-success">Approved</span></td>

                                        </tr>
                                        <tr>
                                            <td>#124</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-warning">Pending</span></td>

                                        </tr>
                                        <tr>
                                         <td>#125</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park	</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-danger">Rejected</span></td>

                                        </tr>
                                        <tr>
                                           <td>#126</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-warning">Pending</span></td>

                                        </tr>
                                        <tr>
                                           <td>#126</td>
                                             <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-warning">Pending</span></td>

                                        </tr>
                                        <tr>
                                           <td>#126</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge bg-warning">Pending</span></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>--%>

                     <div class="card">
                        <div class="card-body recent-sales">
                        <%--    <h5 class="card-title">Grievance summary</h5>--%>
                            <div class="row">
                                <div class="col-md-6">
                                   <h5 class="card-title p-0">Pending Grievance Summary</h5>
                                </div>
                                <div class="col-md-6 text-end">

                                    <asp:Button ID="btnXport2XLPendingGrievanceSummary" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLPendingGrievanceSummary_Click" />
                                

                                    <input type="button" id="btnPrint" class="approve" value="Print" onclick="PrintGridData()" /><span>Total : <asp:Label ID="lblCPGrv" runat="server" Text="0"></asp:Label></span>
                                </div>
                            </div>
                            <div class="table-responsive">
                               <%-- <table class="mGrid2">
                                    <thead>
                                        <tr>
                                            <th scope="col">S.No.</th>
                                            <th scope="col">Allotment Id</th>
                                            <th scope="col">Allottee Name</th>
                                            <th scope="col">Regional Office</th>
                                            <th scope="col">Industrial Area</th>
                                            <th scope="col">Grievance Type</th>
                                            <th scope="col">Grievance Description</th>
                                            <th scope="col">Pending At (level)</th>
                                            <th scope="col">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                          <td>#123</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge status bg-success">Approved</span></td>

                                        </tr>
                                        <tr>
                                            <td>#124</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge status bg-warning">Pending</span></td>

                                        </tr>
                                        <tr>
                                         <td>#125</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park	</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge status bg-danger">Rejected</span></td>

                                        </tr>
                                        <tr>
                                           <td>#126</td>
                                            <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge status bg-warning">Pending</span></td>

                                        </tr>
                                        <tr>
                                           <td>#126</td>
                                             <td>LUCKNOW</td>
                                            <td>Agro Park</td>
                                            <td>9457332292</td>
                                            <td>gyanagri.prod@gmail.com</td>
                                            <td>Gyan Agri Products</td>
                                            <td>Outstanding dues related</td>
                                            <td>Bhogaon</td>
                                            <td><span class="badge status bg-warning">Pending</span></td>

                                        </tr>
                                    </tbody>
                                </table>--%>

                                <asp:GridView ID="grdGreStatus" DataKeyNames="Grievance_Ref_ID" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2"
                                    OnPageIndexChanging="grdGreStatus_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
                                                <asp:BoundField DataField="Mobile_No" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="Email_ID" HeaderText="Email-Id" />

                                                <asp:BoundField DataField="Grievance_Type" HeaderText="Grievance Type" />
                                                <asp:BoundField DataField="Regional_Office" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="CurrentStatus" HeaderText="Status" />
                                               
                                                <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("grievance-details.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("Grievance_Ref_ID").ToString())) %>' Text='<%# Eval("Grievance_Ref_ID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                

                                               
                                            </Columns>
                                        </asp:GridView>

                            </div>


                        </div>

                    </div>

                     <%--<div class="card">
                        <div class="card-body recent-sales">
                           <%-- <h5 class="card-title">Track MOU Summary</h5>
                            <div class="row">
                                <div class="col-md-6">
                                     <h5 class="card-title p-0">Track MOU Summary</h5>
                                </div>
                                <div class="col-md-6 text-end">
                                    <span>Total : 30</span>
                                </div>
                            </div>
                            <div class="table-responsive">
                                 <table class="mGrid2">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Intent ID</th>
                                    <th>Company Name</th>
                                    <th>Address</th>
                                    <th>Office Location</th>
                                    <th>Investor Email Id </th>
                                    <th>Investor Name</th>
                                    <th>Designation</th>
                                    <th>Investor Mobile</th>
                                    <th>Project Name</th>
                                    <th>Project Details</th>
                                    <th>Sector</th>
                                    <th>Investment  (in Crore INR)</th>
                                    <th>Employment</th>
                                    <th>Preferred Location</th>
                                    <th>Regional office </th>
                                    <th>Edit</th>
                                    <th>Follow up tracker</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>22001460</td>
                                    <td>Avaada Ventures Pvt Ltd</td>
                                    <td>406, Hubtown Solaris, NS Phadke Marg, Andheri East, Mumbai 400069,Mumbai City, Maharashtra, India
                                                Pin Code : 400069
                                    </td>
                                    <td>Maharashtra</td>
                                    <td>praveen.golash@avaada.com</td>
                                    <td>Praveen Golash</td>
                                    <td>AVP</td>
                                    <td>919711302259</td>
                                    <td>Avaada Green Ammonia 0.5 MTPA</td>
                                    <td>The main objective of the project is to develop a unique industrial project in Uttar Pradesh to produce 0.5 Million Tons per Annum of Green Ammonia</td>
                                    <td>Chemical Manufacturing</td>
                                    <td>22500</td>
                                    <td>1500</td>
                                    <td>Prayagraj</td>
                                    <td>Prayagraj</td>
                                    <td><a href="AddMou.aspx" class="save"><i class="bi bi-pencil-square"></i></a></td>
                                    <td>
                                       <span class="approve" data-bs-toggle="modal" data-bs-target="#ExtralargeModal">
                                             <img src="assets/img/follow-up.png"/>
                                    </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>22000164</td>
                                    <td>GroupeKRS NetworKs</td>
                                    <td>Suite R.H.2-KRISHNA, Sukhwani Udyan, PCMC Link Road, Near Hotel Eagle, Opposite TULSIDAS MALL, Chinchwad, Pune,Pune, Maharashtra, India
                                                Pin Code : 411033
                                    </td>
                                    <td>Maharashtra</td>
                                    <td>manish@krsmatrix.com</td>
                                    <td>Manishkumar Handa</td>
                                    <td>Global CEO</td>
                                    <td>918830981627</td>
                                    <td>KSIFP - Krstal Suncity Infra Fintech Projects</td>
                                    <td>NRI MIXED USE TOWNSHIP PLANNED@1000 acre , 100, to begin with, Planned Mixed use Township, with Residential &amp; Commercial-ITES,Â will attract NRIs from worldover, due to less sale price,Â good investment growth, in 3-4 years of completion &amp; also, inviting Global Fortune corporates, due toÂ being a Consortium Project, Led by GroupeKRS NetworKs &amp; Fortune 500 global MNC-REIT. Details on websites, thru emailÂ &amp; also UP State Govt earnsÂ  FEW hundred crores thru EQUITY, &amp; 10xGDP growth, thru SPVs, NOW-REIT</td>
                                    <td>Private Industrial Park</td>
                                    <td>10000</td>
                                    <td>100000</td>
                                    <td>Ghaziabad</td>
                                    <td>Ghaziabad</td>
                                    <td><a href="AddMou.aspx" class="save"><i class="bi bi-pencil-square"></i></a></td>
                                    <td>
                                     <span class="approve" data-bs-toggle="modal" data-bs-target="#ExtralargeModal">
                                             <img src="assets/img/follow-up.png"/>
                                    </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>22003743</td>
                                    <td>Mobility Infrastructure Group</td>
                                    <td>9800 MacArthur Boulevard Suite 300 ,, California, United States
                                                Pin Code : 92612
                                    </td>
                                    <td>United States </td>
                                    <td>ravindraverma@mobilityinfra.com</td>
                                    <td>Ravindra Verma</td>
                                    <td>Founder Chairman</td>
                                    <td>919495144124</td>
                                    <td>Multimodal Transportation &amp; Logistics Infrastructure</td>
                                    <td>MiG wishes to be involved in the development, financing, investment, ownership, management and operations of Multimodal Transportation &amp; Logistics Infrastructure including MLPs linking with railways, highways, ports, airports and inland waterways</td>
                                    <td>Logistics and Warehousing </td>
                                    <td>8200</td>
                                    <td>100</td>
                                    <td>Gautam Buddha Nagar</td>
                                    <td>Surajpur</td>
                                     <td><a href="AddMou.aspx" class="save"><i class="bi bi-pencil-square"></i></a></td>
                                    <td>
                                        <span class="approve" data-bs-toggle="modal" data-bs-target="#ExtralargeModal">
                                       <img src="assets/img/follow-up.png"/>
                                    </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>22003743</td>
                                    <td>M/s Solid ply Pvt. Ltd</td>
                                    <td>8 khairu place 4th floor bowbazar ST kolkata WB- 700072,Chandauli, Uttar Pradesh, India
                                                Pin Code : 232104
                                    </td>
                                    <td>Uttar Pradesh</td>
                                    <td>sahupuriproject@gmail.com</td>
                                    <td>Manish kumar tripathi</td>
                                    <td></td>
                                    <td>919919510999</td>
                                    <td>Private Industrial Park</td>
                                    <td>Intergrated Township which will cover projects related to tourism policy, 2022, Logistic Policy, 2022, Industrial Policy, 2022, (Non Polluting Industry) Education, Health, Housing, PM Awas, EOW And Other.</td>
                                    <td>Private Industrial Park</td>
                                    <td>7000</td>
                                    <td>6000</td>
                                    <td>Chandauli</td>
                                    <td>Varanasi</td>
                                    <td><a href="AddMou.aspx" class="save"><i class="bi bi-pencil-square"></i></a></td>
                                    <td>
                                        <span class="approve" data-bs-toggle="modal" data-bs-target="#ExtralargeModal">
                                             <img src="assets/img/follow-up.png"/>
                                    </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td>22000018</td>
                                    <td>Mega Leather Cluster Devlopement (U.P.) Ltd</td>
                                    <td>Village karanu Bahadurnagar/magrasa Kanpur Sadar Ramaipur kanpur,Kanpur Nagar, Uttar Pradesh, India
                                                Pin Code : 209214
                                    </td>
                                    <td>Uttar Pradesh</td>
                                    <td>ashraf@homeratannery.com</td>
                                    <td>Ashraf Rizwan</td>
                                    <td>Director SPV</td>
                                    <td>919839035200</td>
                                    <td>Mega Leather Cluster Park</td>
                                    <td>Total Number of Industries 354 will be Established Tanneries, Leather Goods Or Footwear Accesories</td>
                                    <td>Leather and Footwear</td>
                                    <td>5850</td>
                                    <td>250000</td>
                                    <td>Kanpur</td>
                                    <td>Kanpur</td>
                                  <td><a href="AddMou.aspx" class="save"><i class="bi bi-pencil-square"></i></a></td>
                                    <td>
                                        <span class="approve" data-bs-toggle="modal" data-bs-target="#ExtralargeModal">
                                             <img src="assets/img/follow-up.png"/>
                                    </span>
                                    </td>
                                </tr>
                                </tbody>
                                </table>
                            </div>
                        </div>

                    </div>--%>
                </div><!-- End Reports -->
                <!-- Recent Sales -->
                <!-- Website Traffic -->
                <%--<div class="col-lg-6 col-xl-6 col-xxl-4 col-md-6 col-sm-12">
                    <div class="card">
                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>

                                <li><a class="dropdown-item" href="#">Today</a></li>
                                <li><a class="dropdown-item" href="#">This Month</a></li>
                                <li><a class="dropdown-item" href="#">This Year</a></li>
                            </ul>
                        </div>

                        <div class="card-body pb-0">
                            <h5 class="card-title">MoU Summary <span>| Today</span></h5>

                            <div id="trafficChart" class="echart">
                            </div>

                            <script>
                                document.addEventListener("DOMContentLoaded", () => {
                                    echarts.init(document.querySelector("#trafficChart")).setOption({
                                        tooltip: {
                                            trigger: 'item'
                                        },
                                        legend: {
                                            top: '0%',
                                            left: 'center',
                                            
                                        },
                                        series: [{
                                            name: 'Regional Office',
                                            type: 'pie',
                                            radius: ['15%', '60%'],
                                            avoidLabelOverlap: false,
                                            label: {
                                                show: false,
                                                position: 'center'
                                            },
                                            emphasis: {
                                                label: {
                                                    show: true,
                                                    fontSize: '18',
                                                    fontWeight: 'bold'
                                                }
                                            },
                                            labelLine: {
                                                show: false
                                            },
                                            data: [{
                                                value: 10,
                                                name: 'AGRA'
                                            },
                                              {
                                                  value: 15,
                                                  name: 'ALIGARH'
                                              },
                                              {
                                                  value: 20,
                                                  name: 'AYODHYA'
                                              },
                                              {
                                                  value: 25,
                                                  name: 'BAREILLY'
                                              },
                                              {
                                                  value: 30,
                                                  name: 'GHAZIABAD'
                                              },
                                              {
                                                  value: 35,
                                                  name: 'GNEPIP'
                                              },
                                              {
                                                  value: 40,
                                                  name: 'GORAKHPUR'
                                              },
                                              {
                                                  value: 45,
                                                  name: 'JHANSI'
                                              },
                                              {
                                                  value: 20,
                                                  name: 'KANPUR'
                                              },
                                              {
                                                  value: 25,
                                                  name: 'LUCKNOW'
                                              },
                                              {
                                                  value: 36,
                                                  name: 'MEERUT'
                                              },
                                              {
                                                  value: 30,
                                                  name: 'PRAYAGRAJ'
                                              },
                                              {
                                                  value: 10,
                                                  name: 'SEZ MORADABAD'
                                              },
                                               {
                                                   value: 30,
                                                   name: 'SURAJPUR'
                                               },
                                               {
                                                   value: 20,
                                                   name: 'VARANASI'
                                               },
                                               {
                                                   value: 16,
                                                   name: 'PO TDS'
                                               },
                                               {
                                                   value: 10,
                                                   name: 'PO TRANS'
                                               }
                                            ]
                                        }]
                                    });
                                });
                            </script>

                        </div>
                    </div>
                </div>--%>
                <!-- End Website Traffic -->
            </div>
            <div class="row">
                <!-- Sales Card -->
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                    <%--<div class="card recent-sales overflow-auto">
                        <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>
                                <li><a class="dropdown-item" href="#">Today</a></li>
                                <li><a class="dropdown-item" href="#">This Month</a></li>
                                <li><a class="dropdown-item" href="#">This Year</a></li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <h3 class="card-title">KYA form approval summary<span> / Today</span></h3>
                            <div class="row mb-3">
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row pending2">
                                        <div class="col-md-7">
                                            <div><span>Pending Request</span></div>
                                            <span>Total= 30</span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="KYA-request.aspx">View All</a></span></div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row approved2">
                                        <div class="col-md-7">
                                            <div><span>Approved Request</span></div>
                                                <span>Total= 30</span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="KYA-request.aspx">View All</a></span></div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row rejected2">
                                        <div class="col-md-7">
                                            <div><span>Rejected Request</span></div>
                                            <span>Total= 30</span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="KYA-request.aspx">View All</a></span></div>
                                    </div>
                                </div>
                            </div>
                           <div class="table-responsive">
                                <table class="mGrid2">
                                <thead>
                                    <tr>
                                        <th>S.No.</th>
                                        <th>Allotment Id</th>
                                        <th>Allottee Name</th>
                                        <th>Regional Office</th>
                                        <th>Industrial Area</th>
                                        <th>Plot No</th>
                                        <th>Email Id</th>
                                        <th>Mobile No</th>
                                        <th>Remark</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>#123</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge bg-warning">Pending</span></td>
                                    </tr>
                                    <tr>
                                        <td>#124</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge bg-warning">Pending</span></td>
                                    </tr>
                                    <tr>
                                       <td>#125</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge bg-warning">Pending</span></td>
                                    </tr>
                                </tbody>
                            </table>
                           </div>
                        </div>
                    </div>--%>

                    <div class="card recent-sales overflow-auto">
                      <%--  <div class="filter">
                            <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                            <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                <li class="dropdown-header text-start">
                                    <h6>Filter</h6>
                                </li>
                                <li><a class="dropdown-item" href="#">Today</a></li>
                                <li><a class="dropdown-item" href="#">This Month</a></li>
                                <li><a class="dropdown-item" href="#">This Year</a></li>
                            </ul>
                        </div>--%>
                        <div class="card-body">
                            <h3 class="card-title">KYA Form Approval Summary</h3>
                            <div class="row mb-3">
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row pending2">
                                        <div class="col-md-7">
                                            <div><span>Pending Request</span></div>
                                            <span>Total= <asp:Label ID="lblPendingKYAS" runat="server" Text="Label"></asp:Label></span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="DashBoard.aspx">View All</a></span></div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row approved2">
                                        <div class="col-md-7">
                                            <div><span>Approved Request</span></div>
                                                <span>Total= <asp:Label ID="lblApprovedKYA" runat="server" Text="Label"></asp:Label></span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="DashBoardApproved.aspx">View All</a></span></div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-6 col-sm-12">
                                    <div class="row rejected2">
                                        <div class="col-md-7">
                                            <div><span>Rejected Request</span></div>
                                            <span>Total= <asp:Label ID="lblRejectedKYA" runat="server" Text="Label"></asp:Label></span>
                                        </div>
                                        <div class="col-md-5 text-end"><span class="approval-btn"><a href="DashBoardRejected.aspx">View All</a></span></div>
                                    </div>
                                </div>
                            </div>
                           <div class="table-responsive">
                                <%--<table class="mGrid2">
                                <thead>
                                    <tr>
                                        <th>S.No.</th>
                                        <th>Allotment Id</th>
                                        <th>Allottee Name</th>
                                        <th>Regional Office</th>
                                        <th>Industrial Area</th>
                                        <th>Plot No</th>
                                        <th>Email Id</th>
                                        <th>Mobile No</th>
                                        <th>Remark</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>#123</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge status bg-warning">Pending</span></td>
                                    </tr>
                                    <tr>
                                        <td>#124</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge status bg-warning">Pending</span></td>
                                    </tr>
                                    <tr>
                                       <td>#125</td>
                                        <td>RAG\3153</td>
                                        <td>M/s. Gyan Agri Products</td>
                                        <td>Agra</td>
                                        <td>Bhogaon</td>
                                        <td>35 Acres UD Land</td>
                                        <td>gyanagri.prod@gmail.com</td>
                                        <td>9457332292</td>
                                        <td>Remark</td>
                                        <td><span class="badge status bg-warning">Pending</span></td>
                                    </tr>
                                </tbody>
                            </table>--%>
                               
                               <div class="col-md-12 text-end">
                                  
                                   <asp:Button ID="btnXport2XLKYAApprovalSummary" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLKYAApprovalSummary_Click" />
                                
                               <input type="button" id="btnPrint1" class="approve" value="Print" onclick="PrintGridData1()" />

                               </div>
                               <asp:GridView ID="GridViewKYA" DataKeyNames="KID" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2"  OnPageIndexChanging="GridViewKYA_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                 
                                                <asp:BoundField DataField="AllotmentLetterNo" HeaderText="Allotment Id" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" />
                                                <asp:BoundField DataField="IndustrialArea" HeaderText="Plolt No" />
                                                <asp:BoundField DataField="PloltNo" HeaderText="Industrial Area" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Mobile No" />
                                                <asp:BoundField DataField="EmailID" HeaderText="Email-Id" /> 
                                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                               
                                               <%-- <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("grievance-details.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("KID").ToString())) %>' Text='<%# Eval("KID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>                                               

                                               
                                            </Columns>
                                        </asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>