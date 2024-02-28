<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="AllotteeDues.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeDues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="card-solid">
                <div class="card-body pb-0">
                    <div class="box">
                        <%-- Outstanding Dues Start--%>
                        <div class="heading-main-top">
                            <h1 class="subtitle fancy"><span>Outstanding Dues </span></h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <h4>Allottment No:</h4>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <asp:DropDownList ID="ddlAlotmentNo" runat="server" CssClass="allotment-letter2" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2 col-lg-2 col-xl-2 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <asp:Button ID="btnSearch" CssClass="button9" runat="server" Text="Search." OnClick="btnSearch_Click"   />
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2 col-lg-2 col-xl-2 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <asp:Button ID="btnPaynow" CssClass="approve" runat="server" Text="Pay Now" OnClick="btnPaynow_Click"  Visible="false"   />
                            </div>
                        </div>
                    </div>
                   <%-- <div class="row">
                        <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 d-flex align-items-stretch flex-column">
                            <div id="example1_length" class="dataTables_length">
                                <label>
                                    <select size="1" name="example1_length" aria-controls="example1">
                                        <option value="10" selected="selected">1</option>
                                        <option value="25">25</option>
                                        <option value="50">50</option>
                                        <option value="100">100</option>
                                    </select>
                                    Records per page</label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 d-flex align-items-stretch flex-column text-right">
                            <div class="dataTables_filter" id="example1_filter">
                                <asp:TextBox ID="TextBox2" CssClass="allotment-letter22" placeholder="Search......." runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>

                    <%--  Existing Outstanding Dues Tables Start--%>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Existing Outstanding Dues</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div id="example2_wrapper" class="dataTables_wrapper dt-bootstrap4">

                                <div class="row">
                                    <div class="table-responsive">
                                         <asp:GridView ID="AllotteePaymentSummaruGrid" runat="server" ShowFooter="true" AutoGenerateColumns="false" 
                                  CssClass= "mGrid2" >
                                 <%-- OnRowDataBound="AllotteePaymentSummaruGrid_RowDataBound">--%>
                                    <Columns>

                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField ="PaymentName"   HeaderText ="Payment Head"/>
                                        <asp:BoundField DataField ="Demanded"      HeaderText ="Demanded"    />
                                        <asp:BoundField DataField ="Paid"          HeaderText ="Paid"     />                                      
                                        <asp:BoundField DataField ="Outstanding"   HeaderText ="Outstanding"           />
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>

                                    </div>
                                </div>
                               <%-- <div class="paginate">
                                    <div class="card-header">
                                        <h3 class="card-title">Showing 1 to 10 of 57 entries</h3>

                                        <div class="card-tools">
                                            <ul class="pagination pagination-sm float-right">
                                                <li class="page-item"><a class="page-link" href="#">«</a></li>
                                                <li class="page-item"><a class="page-link" href="#">1</a></li>
                                                <li class="page-item"><a class="page-link" href="#">2</a></li>
                                                <li class="page-item"><a class="page-link" href="#">3</a></li>
                                                <li class="page-item"><a class="page-link" href="#">»</a></li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>--%>

                            </div>
                        </div>
                    </div>
                    <%--  Existing Outstanding Dues Tables End--%>
                </div>
            </div>
        </section>
    </div>
 
</asp:Content>

