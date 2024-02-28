<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestInboxNew.aspx.cs" Inherits="Allotment.ServiceRequestInboxNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>
        .Red{
            color:red;
        }
        .Green{
            color:green;
        }
        .content {
                background: #e2e2e2;
        }
        .bg-mywhite {
            background:#fff;
        }
        .performance-textdiv {
                        min-height: 111px;
    margin-top: 20px;
    padding: 0px 0 0 7px;
    font-weight: 500;
    color: #636262;
        }
        .pmt-text-color {
            color: #fd8e0e;
        }
       
        .performance-textdiv p.pmt-text {
                font-size: 34px;
    
    margin-bottom: 4px;
    margin-top: 20px;
    line-height: 1;
    padding-top: 3px;
        }
            .performance-textdiv p.pmt-text sup {
                    font-size: 10px;
    top: -20px;
            }
        .performance-textdiv p.act-track-text{
                font-size: 11.3px;
            }
        .grid-div {
            min-height:226px;
            margin-top:20px;
        }
        .three-div6in {
            min-height:99px;
            margin-top:10px;
        }
        .div6-right {
            min-height:230px;
            margin-top:20px;
        }
            .div6-right div.announcemnt {
                color: red;
                font-weight: 500;
            }
        .six-div {
            min-height:133px;
            margin-top: 20px;
        }
        .my-heading {
                background: #f5f5f5;
                padding: 0 5px;
                    font-weight: 700;
        }
        .six-div-ul {
            margin:0 10px;
        }
        .six-div-ul li{
            font-size: 13px;
            border-bottom: 1px solid #e8e8e8;
        }
        .current-open-color {
            color:#c59500;
        }
        .pmt-text-color-green {
               color: #28a500;
        }
         .pmt-text-color-yellow {
            color: #fd8e0e;
        }
        .pmt-text-color-red {
            color:red;
            font-weight: 800;
        }
        iframe {
            border: 0px solid #ccc;
        }
        .dash-status span{
                font-size: 42px;
        }
         .dash-status-inr span {
            font-size:25px;
                color: #006d04;
    font-weight: 600;
        }
         .dash-status-inr span i{
                color: #006d04;
        }
        .three-div6in .dash-cost-text{
            margin-top: 9px;
        }
        .my-dash-table-status tr th {
            text-align:center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }
        .my-dash-table-status tr td {
            text-align:center;
            font-weight:700;
            border-right: 3px solid #ccc !important;
        }
        .my-dash-table-status tr td:nth-child(1) {
            text-align:left;                
            position: absolute;
            width: 13em;
            left: 28px;
        }
        .my-dash-table-status tr th:nth-child(1) {
            text-align:left;                
            position: absolute;
            width: 13em;
            left: 28px;
        }
        a.static.selected {
			text-decoration: none;
			border-style: none;
			color: #000000 !important;
            background: #ffdb6d;
		}
        .iadsashboard-dayul-inbox ul li a {
            text-decoration: none;
            white-space: nowrap;
            display: block;
            padding: 4px 6px;
            color: #2b2b2b;
        }
        .table-divinbox {
            margin-top:20px;
            padding:20px;
        }
        .table-divinbox table tr th{
            font-size:12px;
            font-weight:700;
        }
        .iadsashboard-dayul-inbox {
            margin: 7px 7px 10px 0;
            padding: 3px 0;
        }
        #ContentPlaceHolder1_sub_menu a.static {
                padding-left: 10px !important;
                padding-right: 10px !important;
        }
            .iadsashboard-dayul-inbox li {
                /* padding-left: 5px; */
                /* padding-right: 5px; */
                background: #ffc511;
                text-align: center;
                margin: 0px 2px;
                /* width: 127px; */
                /* height: 21px; */
                font-size: 13px;
                font-weight: 600;
                box-shadow: 7px 0 16px #ccc;
                color: #000000;
                border: 1px solid #8e8e8e;
            }
    </style>
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
        $('[id*=GridView1]').prepend($("<thead></thead>").append($('[id*=GridView1]').find("tr:first"))).DataTable({
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


 
        $('[id*=GridView2]').prepend($("<thead></thead>").append($('[id*=GridView2]').find("tr:first"))).DataTable({
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


        $('[id*=GridView3]').prepend($("<thead></thead>").append($('[id*=GridView3]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
            'iDisplayLength': 20,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
            ]
        });


    });
</script>
        <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
 <%--       <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                    <ProgressTemplate>
                        <div class="fgh">
                            <div class="hgf text-center">
                              <span style="font-size:25px;font-weight:bold;">Please Wait...</span><br /> <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
    <div class="row">
        <div class="col-md-6 col-sm-12 col-xs-12">   
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="bg-mywhite performance-textdiv">
                        <p class="pmt-text pmt-text-color">Industrial Area Activity Tracker</p>
                        <p class="act-track-text">Track & Monitor activities across UPSIDC business processs</p>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <div class="bg-mywhite three-div6in">
                        <div class="my-heading font-bold"></div>
                    </div>
                </div>
                <div class="col-md-4 text-center col-sm-4 col-xs-12">
                    <div class="bg-mywhite three-div6in" style="    padding-top: 15px;">
                        <div class="dash-status-inr"><span><i class="fa fa-inr"></i> 0.00</span></div>
                        <div class="dash-cost-text"><b>Expected Revenue</b></div>
                    </div>
                </div>
                <div class="col-md-4 text-center col-sm-4 col-xs-12">
                    <div class="bg-mywhite three-div6in dash-status">
                        <span class="pmt-text-color-yellow" aria-hidden="true">▶</span><span class="pmt-text-color-green" aria-hidden="true">▲</span><span class="pmt-text-color-red" aria-hidden="true">▼</span>                          
                        <div class="dash-status-text"><b>Status</b></div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-6 col-sm-12 col-xs-12"> 
            <div class="div6-right bg-mywhite">
                <div class="red announcemnt my-heading">Alerts -</div>



<%--    <asp:BoundField  ItemStyle-BorderWidth="0" DataField="ALERTMESSAGE" />  --%>



               <asp:GridView ID="grid_Announcement_List" runat="server"   ShowHeader="false" AutoGenerateColumns="false"  BorderWidth="0" >
                   <Columns>
          <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDetails" runat="server" Text='<%# Eval("ALERTMESSAGE") %>' PostBackUrl='<%# "~/Evaluation.aspx?IAOFFICE="+ Eval("IAOFFICE")+"&ServicesId="+ Eval("ServicesId") +"&IAID="+ Eval("IAID")  %>'>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                   </Columns>
                   </asp:GridView>



            </div>
        </div>
    </div>
   <div class="clearfix"></div>


    <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <div class="panel-heading font-bold">
                Application - (Pending At You)
            </div>
        </div>
        <div class="">
            <asp:Menu
								ID="sub_menu"
								Orientation="Horizontal"
							    OnMenuItemClick="sub_menu_MenuItemClick"
								CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
								StaticSelectedStyle-CssClass="sub_menu_active"
								
								runat="server">
               
                
							</asp:Menu>
        </div>

          <asp:MultiView runat="server" ID="ApplicationView">

              <asp:View runat="server" ID="AllotmentView">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridView2" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
                           ClientIDMode="Static"
                           
                            AutoGenerateColumns="False"
                            DataKeyNames="WEEKSTARTDATE,WEEKENDDATE,IAID,row"
                            GridLines="Horizontal"  OnRowDataBound="GridView2_RowDataBound"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

  <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Style="cursor: pointer" ImageUrl="~/images/plus.png" />
                                
                                        <asp:Panel ID="pnlAllotmentRequest" runat="server" Style="display: none">


                                            <asp:GridView ID="GridViewAllotmentRequest" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col" >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="ReQ#">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="Hyper1" NavigateUrl='<%# string.Format("~/NewAssessment.aspx?ServiceReqNo={0}",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<%# Eval("ServiceRequestNO").ToString()%>' Enabled="false"> </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        

                        <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                                                    <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />
                                                    <asp:BoundField DataField="APPLICANTNAME" ItemStyle-Wrap="false" HeaderStyle-CssClass="text-center-imp" Visible="True" HeaderText="Applicant" SortExpression="APPLICANTNAME" ItemStyle-Width="6%"/>
                                                      <asp:BoundField DataField="Preference1" HeaderText="Plot No" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference1" ItemStyle-Width="6%" />
                                                    <%--<asp:BoundField DataField="Preference2" HeaderText="Plot Preference2" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference2" ItemStyle-Width="6%" />
                                                    <asp:BoundField DataField="Preference3" HeaderText="Plot Preference3" HeaderStyle-CssClass="text-center-imp" Visible="True"  SortExpression="Preference3" ItemStyle-Width="6%" />--%>
                                                    <asp:BoundField DataField="RequestedDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-CssClass="text-center-imp" HeaderText="Application Date" SortExpression="RequestedDate" ItemStyle-Width="5%"/>
                                                     <asp:BoundField DataField="PrescribedDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-CssClass="text-center-imp" HeaderText="Approval Date" SortExpression="PrescribedDate" ItemStyle-Width="5%"/>
                                                  <%--  <asp:BoundField DataField="ObjectionDate" ItemStyle-Wrap="false" DataFormatString="{0:dd-M-yyyy}" HeaderStyle-CssClass="text-center-imp" HeaderText="Last Date For Objection" SortExpression="ObjectionDate" ItemStyle-Width="5%"/>
                                                  --%> 
                                                     <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />
                                                            
                                                            <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>'   CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                                                 </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="STATUS" ItemStyle-Wrap="false" HeaderText="Current Status" Visible="false" SortExpression="STATUS" />
                                                 

                                                    <asp:TemplateField HeaderText="Data Verified" SortExpression="IsDataVerified" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataVerifiedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataVerifiedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataVerified").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                               
                                                    <asp:TemplateField HeaderText="Data Approved" SortExpression="IsDataApproved" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isdatatapprovedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isdataapprovedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="CMIA Approved" SortExpression="IsDataReviewed" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsDataReviewedtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsDataReviewedfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsDataReviewed").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    
                                                    <asp:TemplateField HeaderText="JMD Approved" Visible="false" SortExpression="JMDApproved" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isJMDtrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("JMDApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isJMDfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("JMDApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="MD Approved" SortExpression="IsFinalApproved" HeaderStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="isfinaltrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="isfinalfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsFinalApproved").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Accounts Clearance" SortExpression="IsAccountClear" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="IsAccountClear" runat="server" Value='<%# Eval("IsAccountClear").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataVerified" runat="server" Value='<%# Eval("IsDataVerified").ToString().ToLower()%>' />
                                                            <asp:HiddenField ID="IsDataReviewed" runat="server" Value='<%# Eval("IsDataReviewed").ToString().ToLower()%>' />

                                                            <asp:Label ID="IsAccountCleartrue" runat="server" Text="<i class='fa fa-check'  style='color:green;'  ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="false" ? "hide"  : "" %>'></asp:Label>
                                                            <asp:Label ID="IsAccountClearfalse" runat="server" Text="<i class='fa fa-times' style='color:red;' ></i>" CssClass='<%# (Eval("IsAccountClear").ToString().ToLower())=="true" ? "hide"  : "" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />


                                <asp:BoundField DataField="IANAME" ItemStyle-Wrap="false" Visible="True" HeaderText="Concerned IndustrialArea" SortExpression="IANAME" />
                                <asp:BoundField DataField="WEEKSTARTDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week Start" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKSTARTDATE" />
                                <asp:BoundField DataField="WEEKENDDATE" ItemStyle-Wrap="false" Visible="True" HeaderText="Week End" DataFormatString="{0:dd-M-yyyy}" SortExpression="WEEKENDDATE" />
                                <asp:BoundField DataField="NOOFREQUEST" HeaderText="No of Application" SortExpression="NOOFREQUEST" />
                             
                           
                               
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

              <asp:View runat="server" ID="BuildingView">
        <div  class="table-responsive" style="overflow-y: auto; max-height: 390px;">
        <asp:GridView ID="GridView1" runat="server" ClientIDMode="Static"
             CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal"
            OnRowDataBound="GridView1_RowDataBound"
            
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
        <ASP:HYPERLINKFIELD text="Process" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="BuildingPlanAssessment.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                 <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                 <asp:BoundField DataField="AppRecDate" HeaderText="Approval Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />
                   <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />
                                                            
                                                            <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>'   CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                                                 </ItemTemplate>
                                                    </asp:TemplateField>


                <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="CaseType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                

             
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        </div>
        
        <div class="clearfix"></div>
                  </asp:View>

                <asp:View runat="server" ID="TransferView">
                     <div  class="table-responsive" style="overflow-y: auto; max-height: 390px;">
        <asp:GridView ID="GridView3" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
           ClientIDMode="Static"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO,UnitID"
            GridLines="Horizontal"
            OnRowDataBound="GridView3_RowDataBound"
            
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
               <asp:HyperLink ID="hlnkView" Visible="true" Text="View" runat="server" ></asp:HyperLink>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="PrescribedDate" HeaderText="Approval Date" SortExpression="PrescribedDate" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />
                   <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />
                                                            
                                                            <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>'   CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                                                 </ItemTemplate>
                                                    </asp:TemplateField>


                <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" /> 
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        </div>
     
        <div class="clearfix"></div>
                    </asp:View>
              <asp:View runat="server" ID="PostAmalgamation">
                  <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                      <asp:GridView ID="Grid_PostAmalgamation" runat="server"
                          CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="ServiceRequestNO"
                          GridLines="Horizontal"
                          OnRowDataBound="Grid_PostAmalgamation_RowDataBound"
                          Width="100%">
                          <Columns>
                              <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                      </asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:HyperLink ID="hlnkView" Visible="true" Text="View" runat="server"></asp:HyperLink>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                              <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                              <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />

                              <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                  <ItemTemplate>
                                      <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />

                                      <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>' CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                              <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                          </Columns>
                          <EmptyDataTemplate>
                              No Record Available
                          </EmptyDataTemplate>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <HeaderStyle Font-Bold="True" ForeColor="Black" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                      </asp:GridView>
                  </div>

                  <div class="clearfix"></div>
              </asp:View>

             <%-- //--------Test---------%>

                 <asp:View runat="server" ID="PostSubDividion">
                  <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                      <asp:GridView ID="Grid_PostSubDivision" runat="server"
                          CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="ServiceRequestNO"
                          GridLines="Horizontal"
                          OnRowDataBound="Grid_PostSubDivision_RowDataBound"
                          Width="100%">
                          <Columns>
                              <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                      </asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:HyperLink ID="hlnkView" Visible="true" Text="View" runat="server"></asp:HyperLink>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                              <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                              <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />

                              <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                  <ItemTemplate>
                                      <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />

                                      <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>' CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                              <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                          </Columns>
                          <EmptyDataTemplate>
                              No Record Available
                          </EmptyDataTemplate>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <HeaderStyle Font-Bold="True" ForeColor="Black" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                      </asp:GridView>
                  </div>

                  <div class="clearfix"></div>
              </asp:View>

             <%-- <asp:View runat="server" ID="LidaAllotment">
                  <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                      <asp:GridView ID="Grid_LidaAllotment" runat="server"
                          CssClass="table table-striped table-bordered table-hover request-table "
                                BackColor="#ffe6e6"
                          ClientIDMode="Static"
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="ServiceRequestNO"
                          GridLines="Horizontal"
                          OnRowDataBound="Grid_LidaAllotment_RowDataBound"
                          Width="100%">
                          <Columns>
                              <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                      </asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:HyperLink ID="hlnkView" Visible="true" Text="View" runat="server"></asp:HyperLink>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                              <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                              <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                              <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />
                              <asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                  <ItemTemplate>
                                      <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />

                                      <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>' CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                              <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                          </Columns>
                          <EmptyDataTemplate>
                              No Record Available
                          </EmptyDataTemplate>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <HeaderStyle Font-Bold="True" ForeColor="Black" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                      </asp:GridView>
                  </div>

                  <div class="clearfix"></div>
              </asp:View>--%>
              </asp:MultiView>
    </div>
    <div class="clearfix"></div>

                       
       	<%--   </ContentTemplate>
		 </asp:UpdatePanel>--%>

</asp:Content>
