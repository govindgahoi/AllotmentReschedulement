<%@ Page Title="" Language="C#" MasterPageFile="~/AllotteePanel/Allottee_Master.Master" AutoEventWireup="true" CodeBehind="AddAllotmentNo.aspx.cs" Inherits="Allotment.AllotteePanel.AddAllotmentNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

 
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

    <div class="content-wrapper allottee-leadger">
        <section class="content">
            <div class="card-solid">
                <div class="card-body pb-0">
                    <div class="box">
                        <%-- Outstanding Dues Start--%>
                        <div class="heading-main-top">
                            <h1 class="subtitle fancy"><span>Add Allotment No </span></h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-2 col-lg-2 col-xl-2 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <h5>Allottment Letter:</h5>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3 col-xl-3 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <asp:TextBox ID="txtAllotmentNo" CssClass="allotment-letter2" placeholder="Allottment No" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2 col-lg-2 col-xl-2 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <h5>Mobile No:</h5>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3 col-xl-3 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                <asp:TextBox ID="txtmob" CssClass="allotment-letter2" placeholder="Allottment Mobile No" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2 col-lg-2 col-xl-2 d-flex align-items-stretch flex-column">
                            <div class="findnumber">
                                 <asp:Button ID="Button2" CssClass="button9" runat="server" Text="Add." OnClick="ShowPopup" />
                                 <asp:Label ID="lblAllotteeNO" runat="server" Visible="False"></asp:Label>
                                <%--<input type="submit" name="ctl00$ContentPlaceHolder1$btnSearch" value="Add." id="ContentPlaceHolder1_btnSearch" class="save" data-toggle="modal" data-target="#staticBackdrop"/>--%>
                            </div>
                        </div>
                    </div>
                   <%-- <div class="row">
                        <div class="col-12 col-sm-6 col-md-6 d-flex align-items-stretch flex-column">
                            <div id="example1_length" class="dataTables_length">
                                <label>
                                    <select size="1" name="example1_length" aria-controls="example1">
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="10" selected="selected">1</option>
                            <option value="100">100</option>
                        </select>Records per page</label>
                            </div>
                        </div>
                        <div class="col-12 col-sm-6 col-md-6 d-flex align-items-stretch flex-column text-right">
                            <div class="dataTables_filter" id="example1_filter">
                                <asp:TextBox ID="TextBox2" CssClass="allotment-letter22" placeholder="Search......." runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>

                    <%--  Existing Outstanding Dues Tables Start--%>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Existing Allottees record</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div id="example2_wrapper" class="dataTables_wrapper dt-bootstrap4">

                                <div class="row">
                                    <div class="table-responsive">
                                        <asp:GridView ID="Allotmentgrid" runat="server" ClientIDMode="Static"
                                            CssClass="mGrid2"
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
                                               <%-- <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />--%>
                                                <%--<asp:BoundField DataField="AllotteeID" HeaderText="AllotteeID" SortExpression="AllotteeID" Visible="false" />
                                                <asp:BoundField DataField="Plot No" HeaderText="Plot No" SortExpression="Plot No" />
                                                <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                                <asp:BoundField DataField="File No" HeaderText="File No" SortExpression="File No" />
                                                <asp:BoundField DataField="Allotment No" HeaderText="Applicant Id" SortExpression="Allotment No" />
                                                <asp:BoundField DataField="Company Name" HeaderText="Company Name" SortExpression="Company Name" />
                                                <asp:BoundField DataField="Authorised Signatory" HeaderText="Authorised Signatory" SortExpression="Authorised Signatory" />
                                                <asp:BoundField DataField="Allotment Date" HeaderText="Allotment Date" SortExpression="Allotment Date" />--%>
                                                <%--<asp:TemplateField HeaderText="View">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("AllotteeID") %>' ToolTip="Click here to View Request " />
                                                    </ItemTemplate>

                                                </asp:TemplateField>--%>
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
                                    </div>
                                </div>
                                <%--<div class="paginate">
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
    <!-- Button trigger modal -->
     


         <%--  Popup modal dialog Box Start--%>
        <div id="testmodal" class="modal fade" role="dialog">
             
            <div class="modal-dialog ">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" id="btnClose" class="close " data-dismiss="modal" >
                            &times;</button>
                        <h4 class="modal-title">Verify OTP</h4>
                        
                    </div>
                    <div class="bg-danger"><asp:Label ID="lblmsg" runat="server" ></asp:Label></div>
                    <div class="modal-body">
                       <asp:TextBox ID="txtVerifyOTP" placeholder="Place Your OTP Here.." runat="server"></asp:TextBox>
                        <%-- <asp:TextBox ID="TextBox1" placeholder="Place your OTP here.." runat="server"></asp:TextBox>--%>
                    </div>
                    <div class="modal-footer">
                      <%--  <button type="button" class="btn fearrs" data-dismiss="modal">
                            Verify</button>--%>
                       <asp:Button ID="Button1" runat="server" CssClass="btn fearrs" Text="Verify" OnClick="btnSubmit_Click" />
                   
                        <p>Didn't receive OTP?</p>
                        <a href="#">Resend</a>
                    </div>
                </div>
            </div>
        </div>
        <%--  Popup modal dialog Box End--%>
    <!-- Modal -->
         <script>
        $(document).ready(function()
        {
            $( "#btnClose" ).click(function() {
                //<%--alert( "Handler for .click() called." --%>
                $('#testmodal').modal('hide');
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
            }); 
        })

 </script>   
     </ContentTemplate>

    </asp:UpdatePanel> 
</asp:Content>


