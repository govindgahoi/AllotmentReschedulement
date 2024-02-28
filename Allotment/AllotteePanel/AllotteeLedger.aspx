<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="AllotteeLedger.aspx.cs" Inherits="Allotment.AllotteePanel.AllotteeLedger" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Allottee | Ledger</title>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper allottee-leadger">
        <section class="content">
              
            <%--<div class="row">
               
                    <div class="col-md-4 text-right ">
                        <h1>Allottment Letter No:</h1>
                    </div>
                    <div class="col-md-4 ">
                        <asp:TextBox ID="TextBox1" CssClass="allotment-letter2" placeholder="Allottment No:" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4 ">
                          <asp:Button ID="Button1" CssClass="button9" runat="server" Text="Add." OnClick="ShowPopup" />
                    </div>
                
            </div>--%>

            <div class="box">
               <div class="heading-main-top">
                <h1 class="subtitle fancy"> <span>Allottee Ledger </span> </h1>
            </div>

                <div class="box-header">
                    <h3 class="box-title">Existing Allottees record</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <%--<div class="row">
                             <div class="col-md-12">
                            <div class="col-md-6 text-left">
                                <div id="example1_length" class="dataTables_length">
                                    <label>
                                        <select size="1" name="example1_length" aria-controls="example1">
                                            <option value="10" selected="selected">1</option>
                                            <option value="25">25</option>
                                            <option value="50">50</option>
                                            <option value="100">100</option>
                                        </select>
                                        Records per page</label></div>
                            </div>
                                 <div class="col-md-3"></div>
                            <div class="col-md-3 text-right">
                                <div class="dataTables_filter" id="example1_filter">
                                  
                                    <asp:TextBox ID="TextBox2" CssClass="allotment-letter22" placeholder="Search......." runat="server"></asp:TextBox>
                                </div>
                            </div>
                          </div>
                        </div>--%>
                        <div class="table-responsive">

                            <asp:GridView ID="Allotmentgrid" runat="server" ClientIDMode="Static"
                                            CssClass="table table-hover table-bordered table-striped  allotee-mains"
                                              AutoGenerateColumns="false" DataKeyNames="AllotteeID"  >
                                            <Columns>
                                                 <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                <asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" SortExpression="AllotteeID" Visible="false" />
                                                <asp:BoundField DataField="RegionalOffice" HeaderText="Regional Office" SortExpression="RegionalOffice" />
                                                <asp:BoundField DataField="IAName" HeaderText="IndustrialArea" SortExpression="IAName" />
                                                <asp:BoundField DataField="AllotteeName" HeaderText="Company Name" SortExpression="AllotteeName" />
                                                <asp:BoundField DataField="AllotmentNo" HeaderText="Allotment No" SortExpression="AllotmentNo" />
                                                <asp:BoundField DataField="PlotNo" HeaderText="PlotNo" SortExpression="PlotNo" />
                                                <asp:BoundField DataField="FileNo" HeaderText="File No" SortExpression="FileNo" />
                                                <asp:BoundField DataField="TotalAllottedplotArea" HeaderText="TotalPlotArea" SortExpression="TotalAllottedplotArea" />
                                                <%--<asp:BoundField DataField="IndustryType" HeaderText="IndustryType" SortExpression="IndustryType" />--%>
                                                <asp:BoundField DataField="AllotmentDate" HeaderText="AllotmentDate" SortExpression="AllotmentDate" />
                                                <asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID" />
                                                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <%--<asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" SortExpression="AllotteeID" Visible="false" />
                                                <asp:BoundField DataField="Plot No" HeaderText="Plot No" SortExpression="Plot No" />
                                                <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                                <asp:BoundField DataField="File No" HeaderText="File No" SortExpression="File No" />
                                                <asp:BoundField DataField="Allotment No" HeaderText="Applicant Id" SortExpression="Allotment No" />
                                                <asp:BoundField DataField="Company Name" HeaderText="Company Name" SortExpression="Company Name" />
                                                <asp:BoundField DataField="Authorised Signatory" HeaderText="Authorised Signatory" SortExpression="Authorised Signatory" />
                                                <asp:BoundField DataField="Allotment Date" HeaderText="Allotment Date" SortExpression="Allotment Date" />--%>
                                                <asp:TemplateField HeaderText="View">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton3" CssClass="viewbtn0" runat="server" ImageUrl="dist/img/view2.png" CommandName="ViewRow" CommandArgument='<%#Eval("AllotteeID") %>'/>
<%--                                                        <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("AllotteeID") %>' ToolTip="Click here to View Request " />--%>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="Revert" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnUnFinalized" CssClass="fa fa-mail-forward" aria-hidden="true" CommandName="Unfinalized" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to Revert Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UnLock" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnUnlok" CssClass="fa fa-unlock" aria-hidden="true" CommandName="Unlock" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to Unlock Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lock" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnlock" CssClass="fa fa-lock" aria-hidden="true" CommandName="lock" CommandArgument='<%#Eval("AllotteeID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to lock Record?');" ToolTip="Click here to View Request " />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Record Available
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                         
                        <%--<div class="row">
                                <div class="col-md-12">
                            <div class="col-md-6 text-left">
                                <div class="dataTables_info" id="example1_info">Showing 1 to 10 of 57 entries</div>
                            </div>
                            <div class="col-md-6 text-right">
                                <div class="dataTables_paginate paging_bootstrap">
                                    <ul class="pagination">
                                        <li class="prev disabled"><a href="#">← Previous</a></li>
                                        <li class="active"><a href="#">1</a></li>
                                        <li><a href="#">2</a></li>
                                        <li><a href="#">3</a></li>
                                        <li><a href="#">4</a></li>
                                        <li><a href="#">5</a></li>
                                        <li class="next"><a href="#">Next → </a></li>
                                    </ul>
                                </div>
                            </div>
                                    </div>
                        </div>--%>
                            </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

  <%--   <div id="MyPopup" class="modal fade" role="dialog">
            <div class="modal-dialog ">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">Verify OTP</h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="txtVerifyOTP" placeholder="Place Your OTP Here.." runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn fearrs" data-dismiss="modal">
                            Verify</button>
                        <p>Didn't receive OTP?</p>
                        <a href="#">Resend</a>
                    </div>
                </div>
            </div>
        </div>--%>

       <%-- <script type="text/javascript">
            function ShowPopup(title) {
                $("#MyPopup");
                $("#MyPopup").modal("show");
            }
        </script>--%>

</asp:Content>


