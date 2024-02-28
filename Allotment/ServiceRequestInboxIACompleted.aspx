<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestInboxIACompleted.aspx.cs" Inherits="Allotment.ServiceRequestInboxIACompleted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>
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
                padding-right: 5px !important;
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
        $('[id*=ChangeOfProject_Grid]').prepend($("<thead></thead>").append($('[id*=ChangeOfProject_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=AdditionOfProduct_Grid]').prepend($("<thead></thead>").append($('[id*=AdditionOfProduct_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=CompletionCertificate_Grid]').prepend($("<thead></thead>").append($('[id*=CompletionCertificate_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=OccupancyCertificate_Grid]').prepend($("<thead></thead>").append($('[id*=OccupancyCertificate_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=SecondCharge_Grid]').prepend($("<thead></thead>").append($('[id*=SecondCharge_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=JointMortgage_Grid]').prepend($("<thead></thead>").append($('[id*=JointMortgage_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=NocMortgage_Grid]').prepend($("<thead></thead>").append($('[id*=NocMortgage_Grid]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=transferofleasedeed]').prepend($("<thead></thead>").append($('[id*=transferofleasedeed]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all'}} },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible'} }
            ]
        });
        $('[id*=GridViewTEF]').prepend($("<thead></thead>").append($('[id*=GridViewTEF]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0]}],
            'iDisplayLength': 10,
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
        <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
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
            
                <div class="col-md-6 text-center col-sm-4 col-xs-12">
                    <div class="bg-mywhite three-div6in" style="    padding-top: 15px;">
                        <div class="dash-status-inr"><span><asp:Label runat="server" ID="TotalPending"></asp:Label></span></div>
                        <div class="dash-cost-text"><b>Total Approved</b></div>
                    </div>
                </div>
                <div class="col-md-6 text-center col-sm-4 col-xs-12">
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



              <asp:GridView ID="grid_Announcement_List" runat="server"    CssClass="table table-striped table-bordered table-hover request-table request-table" OnPageIndexChanging="grid_Announcement_List_PageIndexChanging" PageSize="9" AllowPaging="true"  ShowHeader="true" AutoGenerateColumns="false"  BorderWidth="0" >
                   <Columns>
                <asp:BoundField DataField="ID" HeaderText="Sr.No" />
                <asp:BoundField DataField="Title" HeaderText="Application For" />
                <asp:BoundField DataField="AppCount" HeaderText="No Of Applications"/>
              
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
    </div>
   <div class="clearfix"></div>


    <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <div class="panel-heading font-bold">
                Application - (Approved)
            </div>
        </div>
        <div class="">
            <asp:Menu
								ID="sub_menu"
								Orientation="Horizontal"
							 OnMenuItemClick="sub_menu_MenuItemClick"
								CssClass="ist-inline iadsashboard-dayul-inbox"
								StaticSelectedStyle-CssClass="sub_menu_active"
								
								runat="server">
               
                
							</asp:Menu>
        </div>

          <asp:MultiView runat="server" ID="ApplicationView">

             
         <asp:View runat="server" ID="ChangeOfProject_View">
        <div class="col-md-12">
        <asp:GridView ID="ChangeOfProject_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                 <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                 <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=ChangeOfProject",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
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

              <asp:View runat="server" ID="AdditionOfProduct_View">
        <div class="col-md-12">
        <asp:GridView ID="AdditionOfProduct_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                 <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=AdditionOfProduct",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
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

                 <asp:View runat="server" ID="CompletionCertificate_Div">
        <div class="col-md-12">
        <asp:GridView ID="CompletionCertificate_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
               <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=CompletionCertificate",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField> 
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

                 <asp:View runat="server" ID="OccupancyCertificate_Div">
        <div class="col-md-12">
        <asp:GridView ID="OccupancyCertificate_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
             <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=OccupancyCertificate",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>       
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

              <asp:View runat="server" ID="SecondCharge_Div">
        <div class="col-md-12">
        <asp:GridView ID="SecondCharge_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
             <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=OccupancyCertificate",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>       
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
              <asp:View runat="server" ID="NocMortgage_Div">
        <div class="col-md-12">
        <asp:GridView ID="NocMortgage_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                 <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                 <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=ChangeOfProject",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
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
              <asp:View runat="server" ID="JointMortgage_Div">
        <div class="col-md-12">
        <asp:GridView ID="JointMortgage_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
             <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=OccupancyCertificate",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>       
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
              <asp:View runat="server" ID="transferofleasedeed_Div">
        <div class="col-md-12">
        <asp:GridView ID="transferofleasedeed" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
             <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=OccupancyCertificate",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>       
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
              <asp:View runat="server" ID="TEF_Div">
        <div class="col-md-12">
        <asp:GridView ID="GridViewTEF" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
             <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Timeextensionfee",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>       
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
                 <asp:View runat="server" ID="Startofproduction_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvStartofproduction" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=startofproduction",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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

            <asp:View runat="server" ID="PlotCancelation_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvPlotCancelation" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=plotcancelation",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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


            <asp:View runat="server" ID="reconstitution_View">
                <div class="col-md-12">
                    <asp:GridView ID="GridViewreconstitution" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Requestforreconstitutionallotte",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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
            <asp:View runat="server" ID="handoverofleasedeedtolease_View1">
                <div class="col-md-12">
                    <asp:GridView ID="Gridhandoverofleasedeedtolease" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Requestforhandoverofleasedeedtolease",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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
            <asp:View runat="server" ID="Reconstitutionlegalheir_View">
                <div class="col-md-12">
                    <asp:GridView ID="Reconstitutionlegalheir_GridView" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Requestforreconstitutionoflegalheirafterdeath",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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
            <asp:View runat="server" ID="WaterConnection_View">
                <div class="col-md-12">
                    <asp:GridView ID="WaterConnection_GridView" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=RequestforWaterConnection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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



            <asp:View runat="server" ID="Restoration_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvRestoration" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Restoration",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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

            <asp:View runat="server" ID="Surrender_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvSurrender" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Surrender",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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

            <asp:View runat="server" ID="Additional_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvAdditional" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Additional",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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

            <asp:View runat="server" ID="Subletting_View">
                <div class="col-md-12">
                    <asp:GridView ID="gvSubletting" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                            <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                            <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                            <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                            <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                            <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                            <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                            <asp:TemplateField HeaderText="View Letter">
                                <HeaderStyle />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Subletting",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
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

               <asp:View runat="server" ID="NoDues_View">
        <div class="col-md-12">
        
                            <asp:GridView ID="NoDues_Grid" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:HyperLinkField Text="Process" DataNavigateUrlFields="ServiceRequestNO" DataNavigateUrlFormatString="IAServicesAssessment.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                                    <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                                    <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                                    <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                                    <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                                    <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                                    <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                                    <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                                    <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />

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

                            <asp:View runat="server" ID="View_OutStandingDues">
        <div class="col-md-12">
        <asp:GridView ID="Grid_OutStandingDues" runat="server"
                                CssClass="table table-striped table-bordered table-hover request-table request-table"
                                ClientIDMode="Static"
                                AutoGenerateColumns="False"
                                DataKeyNames="ServiceRequestNO"
                                GridLines="Horizontal"
                                OnRowDataBound="GridView1_RowDataBound"
                                Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
       <ASP:HYPERLINKFIELD text="Process" datanavigateurlfields="ServiceRequestNO"  datanavigateurlformatstring="IAServicesAssessment.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
      <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                
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

              </asp:MultiView>
    </div>
    <div class="clearfix"></div>

                       
       	  <%-- </ContentTemplate>
		 </asp:UpdatePanel>--%>

</asp:Content>
