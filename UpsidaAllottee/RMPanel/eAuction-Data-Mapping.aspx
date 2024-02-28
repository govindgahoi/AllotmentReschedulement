<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="eAuction-Data-Mapping.aspx.cs" Inherits="UpsidaAllottee.RMPanel.eAuction_Data_Mapping" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>E-Auction Data Mapping <span>Details of Data Mapping</span></h1>
                        </div>
                    </div>
            
            <!--             
            <div class="row grievance-bg">
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <div class="card info-card sales-card">
                        
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <div class="round-btn-green"><i class="bi bi-file-earmark-text"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Resolved </h5>
                                    <h6> <asp:Label ID="lblTResolved" runat="server" Text="0"></asp:Label> </h6>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">
                    <div class="card info-card revenue-card">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                   <div class="round-btn-green"><i class="bi bi-file-earmark-medical"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Pending at RM</h5>
                                   <h6> <asp:Label ID="lblInProg" runat="server" Text="0"></asp:Label> </h6>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-xl-4 col-xxl-4 col-md-4 col-sm-12">

                    <div class="card info-card customers-card">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                    <div class="round-btn-green"><i class="bi bi-file-earmark-ruled"></i></div>
                                </div>
                                <div class="ps-3">
                                     <h5 class="card-title">Total Grievance Pending at Head Office</h5>
                                    <h6> <asp:Label ID="lblTGrRej" runat="server" Text="0"></asp:Label> </h6>                      
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            -->        
                    <!--
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
                        <div class="col-md-1">
                            <div class="form-group mt-3">                                 
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" class="search " OnClick="btnSearch_Click" />                                
                                <asp:Button ID="btnReset" runat="server" Visible="false" Text="Reset" class="reset" OnClick="btnReset_Click" />
                            </div>
                        </div>
                        <div class="col-md-1">
                            <div class="form-group mt-3">                                 
                                 <asp:Button ID="btnXport2XLGrievanceRedressal" class="approve" runat="server" Text="Export to Excel" OnClick="btnXport2XLGrievanceRedressal_Click" />
                            </div>
                        </div>
                        <div class="col-md-1">
                            <div class="form-group mt-3">                                 
                                <input type="button" id="btnPrint1" class="approve" value="Print" onclick="PrintGridData()" />
                            </div>
                        </div>
                    </div>
                    -->
                    <div class="table-responsive">                        
                           
                           <asp:GridView ID="grdGreStatus" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="mGrid2" OnPageIndexChanging="grdGreStatus_PageIndexChanging" OnRowDataBound="grdGreStatus_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actions" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="hlnkView"  NavigateUrl='<%# string.Format("auction-details.aspx?Id={0}",HttpUtility.UrlEncode(Eval("Id").ToString())) %>' Text='Action Id'> </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="Auction_Id" HeaderText="Auction Id" />
                                    <asp:BoundField DataField="Auction_No" HeaderText="Auction No." />
                                    <asp:BoundField DataField="Auction_brief" HeaderText="Auction brief" />
                                    <asp:BoundField DataField="Department" HeaderText="Department" />
                                    <asp:BoundField DataField="Officer" HeaderText="Officer" />
                                    <asp:BoundField DataField="Start_date_time" HeaderText="Start date and time" />
                                    <asp:BoundField DataField="End_date_time" HeaderText="End date and time" />
                                    <asp:BoundField DataField="Auction_type" HeaderText="Auction type" />
                                    <asp:BoundField DataField="Bidding_type" HeaderText="Bidding type" />
                                    <asp:BoundField DataField="Auction_base_currency" HeaderText="Auction base currency" />
                                    <asp:BoundField DataField="Auction_Variant" HeaderText="Auction Variant" />
                                    <asp:BoundField DataField="isMappedVal" HeaderText="Status" />                                               
                                </Columns>
                            </asp:GridView>
                    </div>

                    <!--
                    <div class="table-responsive">
                        <table class="mGrid2">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Auction Id</th>
                                    <th>Auction No</th>
                                    <th>Auction brief</th>
                                    <th>Department</th>
                                    <th>Officer</th>
                                    <th>Start date and time</th>
                                    <th>End date and time</th>
                                    <th>Auction type</th>
                                    <th>Bidding type</th>
                                    <th>Auction base currency</th>
                                    <th>Auction Variant</th>
                                    <th>Status</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1.</td>
                                    <td><a href="Veiw_E-Action.aspx">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                    <td><span class="approve">Mapped</span></td>
                                </tr>
                                 <tr>
                                    <td>2.</td>
                                    <td><a href="#">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                   <td><span class="pending">Not Mapped </span></td>
                                </tr>
                                 <tr>
                                    <td>3.</td>
                                   <td><a href="#">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                    <td><span class="pending">Not Mapped </span></td>
                                </tr>
                                 <tr>
                                    <td>4.</td>
                                   <td><a href="#">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                    <td><span class="pending">Not Mapped </span></td>
                                </tr>
                                 <tr>
                                    <td>5.</td>
                                   <td><a href="#">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                    <td><span class="pending">Not Mapped </span></td>
                                </tr>
                                 <tr>
                                    <td>6.</td>
                                   <td><a href="#">Auction Id</a></td>
                                    <td>Auction No</td>
                                    <td>Auction brief</td>
                                    <td>Department</td>
                                    <td>Officer</td>
                                    <td>Start date and time</td>
                                    <td>End date and time</td>
                                    <td>Auction type</td>
                                    <td>Bidding type</td>
                                    <td>Auction base currency</td>
                                    <td>Auction Variant</td>
                                    <td><span class="pending">Not Mapped </span></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    -->
                </div>
            </div>
        </section>
    </main>
</asp:Content>