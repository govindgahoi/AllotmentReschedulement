<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="Grievance-Redressal.aspx.cs" Inherits="UpsidaAllottee.RMPanel.Grievance_Redressal_System" %>
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
 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Grievance Redressal System<span>Details of Grievance</span></h1>
                        </div>
                    </div>
                 
                      <div class="row grievance-bg">
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <div class="card info-card sales-card">
                        
                        <div class="card-body">
                           <%-- <h5 class="card-title">Total Grievance Resolved </h5>--%>
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <div class="round-btn-green"><i class="bi bi-file-earmark-text"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Resolved </h5>
                                    <h6> <asp:Label ID="lblTResolved" runat="server" Text="0"></asp:Label> </h6>
                                  <%--  <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>--%>

                                </div>
                            </div>
                        </div>

                    </div>
                </div><!-- End Sales Card -->
                <!-- Revenue Card -->
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <div class="card info-card revenue-card">
                        <div class="card-body">
                           <%-- <h5 class="card-title">Total Grievance In-Progress</h5>--%>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                   <div class="round-btn-green"><i class="bi bi-file-earmark-medical"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Pending at RM</h5>
                                   <h6> <asp:Label ID="lblInProg" runat="server" Text="0"></asp:Label> </h6>
                                   <%-- <span class="text-success small pt-1 fw-bold">8%</span> <span class="text-muted small pt-2 ps-1">increase</span>--%>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- End Revenue Card -->
                <!-- Customers Card -->
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">

                    <div class="card info-card customers-card">
                        <div class="card-body">
                           <%-- <h5 class="card-title">Total Grievance Rejected</h5>--%>

                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <div class="round-btn-green"><i class="bi bi-file-earmark-ruled"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Pending at Head Office</h5>
                                    <h6> <asp:Label ID="lblTGrRej" runat="server" Text="0"></asp:Label> </h6>
                                    <%--<span class="text-danger small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">decrease</span>--%>

                                </div>
                            </div>

                        </div>
                    </div>

                </div><!-- End Customers Card -->
            </div>
                    
                    <div class="row mt-3 mb-3">
                        <div class="col-md-12">
                            <div class="form-group  text-end">
                                <asp:Button ID="btnXport2XLGrievanceRedressal" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLGrievanceRedressal_Click" />
                                
                                <input type="button" id="btnPrint1" class="approve" value="Print" onclick="PrintGridData()" />
                                </div>
                            </div>
                        </div>

                    <div class="row mt-3 mb-3">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Pending At </label>
                                <asp:DropDownList ID="ddlGreStatus" class="form-control" runat="server">
                                                <asp:ListItem Value="01">--Select Status--</asp:ListItem>
                                                <asp:ListItem Value="04">Pending AT Head Office</asp:ListItem>
                                                <asp:ListItem Value="02">Pending at RM</asp:ListItem>
                                                <asp:ListItem Value="03">Resolved</asp:ListItem>
                                            </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Regional Office</label>
                                <asp:DropDownList ID="ddlRegOffice" class="form-control" runat="server">
                                            </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Grievance Id</label>
                                   <asp:TextBox ID="txtGrievanceId" runat="server" class="form-control" placeholder="Grievance Id"></asp:TextBox>
                                            
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group mt-3">                                 
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" class="search " OnClick="btnSearch_Click" />                                
                                <asp:Button ID="btnReset" runat="server" Visible="false" Text="Reset" class="reset" OnClick="btnReset_Click" />

                                
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">                        
                           
                           <asp:GridView ID="grdGreStatus" DataKeyNames="Grievance_Ref_ID" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2" OnPageIndexChanging="grdGreStatus_PageIndexChanging">
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
                                                <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />
                                               <%-- <asp:TemplateField HeaderText="Current Status">
                                                    <ItemTemplate>
                                                       
                                                        <asp:Button ID="btnProgress" runat="server" PostBackUrl='<%# string.Format("~/Admin-Dashboard/ApplicantDetails.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("Grievance_Ref_ID").ToString())) %>' Text="In Progress" class="status-bg bg-secondary"></asp:Button>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Grievance-Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("grievance-details.aspx?Grievance_Ref_ID={0}",HttpUtility.UrlEncode(Eval("Grievance_Ref_ID").ToString())) %>' Text='<%# Eval("Grievance_Ref_ID").ToString()%>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="View" ></asp:TemplateField>
                                                 <asp:HyperLinkField Text="View" DataNavigateUrlFields="Grievance_Ref_ID" DataNavigateUrlFormatString="ApplicantDetails.aspx?Grievance_Ref_ID={0}">
                                                    
                                                </asp:HyperLinkField>
                                                --%>

                                                <%-- <asp:TemplateField HeaderText="View" >
                                                    <ItemTemplate >
                                                        
                                                       <a href="ApplicantDetails.aspx" class="btn btn-warning btn-xs"><i class="fa fa-eye" aria-hidden="true"></i></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>

                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
