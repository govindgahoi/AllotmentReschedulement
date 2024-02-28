<%@ Page Title="" Language="C#" MasterPageFile="~/RMPanel/RM.Master" AutoEventWireup="true" CodeBehind="TrackMou.aspx.cs" Inherits="UpsidaAllottee.RMPanel.TrackMou" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
 
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=GridView1]').prepend($("<thead></thead>").append($('[id*=GridView1]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                   /* { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },*/
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                    { extend: 'csv', text: 'Download Report A', className: 'exportExcel', filename: 'AllotteeLedgerSummary', exportOptions: { modifier: { page: 'all' } } }
                    /*, { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }*/
                ]
            });
        });
    </script>
        <%--<script src="vendors/jquery-1.9.1.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="vendors/easypiechart/jquery.easy-pie-chart.js"></script>
    <script src="assets/scripts.js"></script>--%>

 <script type="text/javascript">
     function openModal() {
        // alert("HI");
         //$('#ExtralargeModal').modal('show');
         $("#ExtralargeModal").modal('show');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <main id="main" class="main">
        <section class="section dashboard">
            <div class="card info-card sales-card">
                <div class="container-fluid recent-sales">
                    <div class="row">
                        <div class="nine">
                            <h1>Track MoU<span>Details of MoU</span></h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5 col-md-5">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <p class="float-end col-form-label">Regional Office</p>
                                        
                                    </div>
                                    <div class="col-lg-6 col-md-6">

                                        <asp:DropDownList ID="dlRO" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="dlRO_SelectedIndexChanged"></asp:DropDownList>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 col-md-5 ">
                            <div class="mou-summary">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 text-center">
                                        <span class="card-title">MoU Summary</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <span>Total MOU Regional Office Wise </span>
                                    </div>
                                    <div class="col-lg-6 col-md-6">
                                        <span>=
                                            <asp:Label ID="lblTotalPlot" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <span>Total MOU</span>
                                    </div>
                                    <div class="col-lg-6 col-md-6">
                                        <span>= 0</span>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6">
                                        <p class="float-end col-form-label">
                                            Office Location (State)
                                        </p>
                                    </div>
                                    <div class="col-lg-6 col-md-6">
                                      <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" >
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Andhra Pradesh </asp:ListItem>
                                             <asp:ListItem>Arunachal Pradesh </asp:ListItem>
                                            <asp:ListItem>Assam </asp:ListItem>
                                            <asp:ListItem>Bihar </asp:ListItem>
                                           <asp:ListItem>Chhattisgarh </asp:ListItem>
                                           <asp:ListItem>Goa </asp:ListItem>
                                            <asp:ListItem>Gujarat</asp:ListItem>
                                          <asp:ListItem>Haryana </asp:ListItem>
                                           <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                           <asp:ListItem>Jharkhand</asp:ListItem>
                                           <asp:ListItem>Karnataka </asp:ListItem>
                                           <asp:ListItem>Kerala </asp:ListItem>
                                           <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                           <asp:ListItem>Maharashtra </asp:ListItem>
                                            <asp:ListItem>Manipur </asp:ListItem>
                                           <asp:ListItem>Meghalaya</asp:ListItem>
                                           <asp:ListItem>Mizoram</asp:ListItem>
                                            <asp:ListItem>Nagaland </asp:ListItem>
                                            <asp:ListItem>Odisha</asp:ListItem>
                                           <asp:ListItem>Punjab </asp:ListItem>
                                           <asp:ListItem>Rajasthan</asp:ListItem>
                                           <asp:ListItem>Sikkim</asp:ListItem>
                                           <asp:ListItem>Tamil Nadu </asp:ListItem>
                                           <asp:ListItem>Telangana</asp:ListItem>
                                            <asp:ListItem>Tripura </asp:ListItem>
                                            <asp:ListItem>Uttar Pradesh </asp:ListItem>
                                           <asp:ListItem>Uttarakhand </asp:ListItem>
                                           <asp:ListItem>West Bengal</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 col-md-5 ">
                            <div class="offices">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3">
                                        <p class="float-end col-form-label">Search</p>
                                    </div>
                                    <div class="col-lg-9 col-md-9">
                                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" placeholder="Project Name, Sector, Investor Name"></asp:TextBox>
                                         
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <div class="offices float-end">
                              <%--<span><a href="AddMou.aspx" class="save text-white">Add MoU</a></span>--%>
                                <asp:Button ID="Button3" runat="server" Text="Search" CssClass="save text-white" OnClick="Button3_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <div class="offices float-start">
                                <input id="Button1" type="button" class="approve" value="Download Report" />
                            </div>
                        </div>


                        <div class="col-lg-6 col-md-6">
                            <div class="offices float-end">
                                <input id="Button1" type="button" class="save text-white" value="Print PDF" />

                            </div>
                        </div>
                    </div>
                    <div class="table-responsive" style="overflow-y: auto; max-height: 590px;">
                         
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" BackColor="#ffe6e6"
                            CssClass="mGrid2"
                            ClientIDMode="Static"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="MID"
                            GridLines="Horizontal"
                            PagerStyle-CssClass="pagination-ys"
                            PagerStyle-HorizontalAlign="Right">

                            <Columns>


                                <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="MID" HeaderText="MID" />
                                <asp:BoundField DataField="IntentID" HeaderText="Intent ID" />
                                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />

                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="OfficeLocation" HeaderText="Office Location" />
                                <asp:BoundField DataField="Email" HeaderText="Investor Email " />


                                <asp:BoundField DataField="InvestorName" HeaderText="Investor Name" />
                                <asp:BoundField DataField="Desination" HeaderText="Designation" />
                                <asp:BoundField DataField="InvestorMobile" HeaderText="Investor Mobile" />

                                <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                <%-- <asp:BoundField DataField="ProjectDetails" HeaderText="Project Details"  />--%>
                                <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                <asp:BoundField DataField="Investment" HeaderText="Investment(in Crore INR)" />
                                <asp:BoundField DataField="Employment" HeaderText="Employment" />

                                <asp:BoundField DataField="PreferredLocation" HeaderText="Preferred Location" />
                                <asp:BoundField DataField="Regionaloffice" HeaderText="Regional office" />

                                <asp:TemplateField HeaderText="Edit/View" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <a href="AddMou.aspx?MOU=<%# Eval("MID") %>" class="btn btn-info btn-sm"><i class="bi bi-pencil-square"></i></a>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Followup" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
<%--                                 <span class="btn btn-success btn-sm" data-bs-toggle="modal" data-bs-target="#ExtralargeModal"><i class="bi bi-hand-index-thumb"></i>--%>
                             <asp:ImageButton ID="imgbtn" CssClass="btn btn-success btn-sm" ImageUrl="Edit.jpeg" runat="server" Width="25" Height="25" onclick="imgbtn_Click" > </asp:ImageButton>
                                     </ItemTemplate>
                                </asp:TemplateField>
                                      </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>

                        </asp:GridView>
                                </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger ControlID="GridView2" />--%>
                               <%-- <asp:AsyncPostBackTrigger  ControlID="imgbtn"  EventName="imgbtn_Click"/>--%>
                            </Triggers>
                            </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>--%>
            <%--  poup modlal box Start--%>
            <%--<asp:Panel ID="pnlpopup" runat="server"   style="display:none">--%>
            <div class="modal fade" id="ExtralargeModal" tabindex="-1">
                
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Track  Details</h5>
                            <div class="close-hearbar">
                                <button type="button" class="popup-close-btn" data-bs-dismiss="modal" aria-label="Close"><i class="bi bi-x"></i></button>
                            </div>

                        </div>
                        <div class="modal-body">
                            <%--<div class="row mt-2 mb-3">
                                <div class="col-md-3 col-lg-3 col-sm-12"></div>
                                <div class="col-md-4 col-lg-4 col-sm-12">
                                    <div class="offices">
                                        <input id="Text1" type="text" class="form-control" placeholder="Enter Your Email Id" />
                                    </div>
                                </div>
                                <div class="col-md-2 col-lg-2 col-sm-12">
                                    <button class="save">Submit</button>
                                </div>
                                <div class="col-md-3 col-lg-3 col-sm-12"></div>
                            </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <div class="row">
                                <div class="table-responsive">
                                      <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                    <asp:GridView ID="GridView2" runat="server" BackColor="#ffe6e6"
                            CssClass="mGrid2"
                            ClientIDMode="Static"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            
                            GridLines="Horizontal"
                            PagerStyle-CssClass="pagination-ys"
                            PagerStyle-HorizontalAlign="Right">

                            <Columns>


                                <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IntentID" HeaderText="Intent ID" />
                                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />

                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="OfficeLocation" HeaderText="Office Location" />
                                <asp:BoundField DataField="Email" HeaderText="Investor Email " />


                                <asp:BoundField DataField="InvestorName" HeaderText="Investor Name" />
                                <asp:BoundField DataField="Desination" HeaderText="Designation" />
                                <asp:BoundField DataField="InvestorMobile" HeaderText="Investor Mobile" />

                                <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                <%-- <asp:BoundField DataField="ProjectDetails" HeaderText="Project Details"  />--%>
                                <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                <asp:BoundField DataField="Investment" HeaderText="Investment(in Crore INR)" />
                                <asp:BoundField DataField="Employment" HeaderText="Employment" />

                                <asp:BoundField DataField="PreferredLocation" HeaderText="Preferred Location" />
                                <asp:BoundField DataField="Regionaloffice" HeaderText="Regional office" />

                                 
                                      </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>

                        </asp:GridView>

                                  
                                </div>
                            </div>

                            <div class="row">
                                <div class="table-responsive">
                                      
                                    <asp:GridView ID="GridView3" runat="server" BackColor="#ffe6e6"
                            CssClass="mGrid2"
                            ClientIDMode="Static"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            
                            GridLines="Horizontal"
                            PagerStyle-CssClass="pagination-ys"
                            PagerStyle-HorizontalAlign="Right">

                            <Columns>


                                <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication1" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fdate" HeaderText="Followup Date" />
                                <asp:BoundField DataField="remark" HeaderText="Remark" />
                                <asp:BoundField DataField="status" HeaderText="Status" />
 
                                      </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>

                        </asp:GridView>

                                   
                                </div>
                            </div>

                                </ContentTemplate>
                          
                            </asp:UpdatePanel>
                            <div class="row mt-3">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">Follow up</h5>
                                        <div class="table-responsive">
                                            <table class="table table-bordered table-hover mytable2 mb-2">
                                                <thead>
                                                    <tr>
                                                        <th>S.No.</th>
                                                        <th>Follow up Date</th>
                                                        <th>Remark</th>
                                                        <th>Status</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>1.</td>
                                                        <td>
                                                            <%--<input id="Text12" type="date" class="form-control" /></td>--%>
                                                        <asp:TextBox ID="txtdate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <td>
                                                            <%--<input id="Text4" type="text" class="form-control" />--%>
                                                            <asp:TextBox ID="txtremark" type="text" CssClass="form-control" runat="server"></asp:TextBox>


                                                        </td>
                                                        <td>
                                                            <%--<select class="form-select">
                                                                <option selected="selected" value="-1">--Select--</option>--%>
                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" >
                                                               <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem>Need land</asp:ListItem>
                                                                <asp:ListItem>Need approval</asp:ListItem>
                                                               <asp:ListItem>Allotment under process</asp:ListItem>
                                                               <asp:ListItem>Allotment completed </asp:ListItem>
                                                               <asp:ListItem>Lease deed</asp:ListItem>
                                                               <asp:ListItem>Possession </asp:ListItem>
                                                              <asp:ListItem>Construction</asp:ListItem>
                                                              <asp:ListItem>Other</asp:ListItem>
                                                            </asp:DropDownList>
                                                                
                                                                </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblMID" runat="server" Visible="false"></asp:Label>
                            <button type="button" class="cancel" data-bs-dismiss="modal">Cancel</button>
                            <%--<button type="button" class="save">Save</button>--%>
                            <asp:Button ID="Button2" runat="server" Text="Save" CssClass="save" OnClick="btnSubmit_Click"/>
                        </div>
                    </div>
                </div>
            </div>
               <%-- </asp:Panel>--%>
            <%--  poup modlal box End--%>
        </section>
    </main>

</asp:Content>
