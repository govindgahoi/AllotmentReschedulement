﻿<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LidaServiceRequestRejected.aspx.cs" Inherits="Allotment.LidaServiceRequestRejected" %>--%>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainLidaUser.Master" CodeBehind="LidaServiceRequestRejected.aspx.cs" Inherits="Allotment.LidaServiceRequestRejected" %>

<%--<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ServiceRequestCompleted.aspx.cs" Inherits="Allotment.ServiceRequestCompleted" %>--%>

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
            'iDisplayLength': 10,
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
            'iDisplayLength': 10,
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
            'iDisplayLength': 10,
            buttons: [
                { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
            ]
        });
        $('[id*=GridView4]').prepend($("<thead></thead>").append($('[id*=GridView4]').find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
            'iDisplayLength': 10,
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
      <%-- <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
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
    <%-- <div class="row">
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
    <asp:BoundField  ItemStyle-BorderWidth="0" DataField="ALERTMESSAGE" /> 
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
    </div>--%>
   <div class="clearfix"></div>


    <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <div class="panel-heading font-bold">
                Application - (Total Rejected)
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

              <asp:View runat="server" ID="BuildingView">
              
     
            <div class="table-responsive" >
             <asp:GridView ID="GridView1" runat="server" ClientIDMode="Static"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AutoGenerateColumns="False"
            DataKeyNames="lida_allotee_id"
            GridLines="Horizontal"
            OnRowDataBound="GridView1_RowDataBound"
            OnRowCommand="GridView1_RowCommand"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         
                 <%--<ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="BuildingPlanAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD> --%> 
                <asp:HyperLinkField Text="Process" DataNavigateUrlFields="lida_allotee_id" DataNavigateUrlFormatString="LidaBuildingplanAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="project_name" HeaderText="Project Name" SortExpression="project_name" />
                <asp:BoundField DataField="plot_no" HeaderText="Plot No" SortExpression="plot_no" />
                <asp:BoundField DataField="lida_allotee_id" HeaderText="Service Request" SortExpression="lida_allotee_id" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Applicant Name" SortExpression="AllotteeName" />
                <asp:BoundField DataField="RejectedOn" HeaderText="Rejection Date" SortExpression="RejectedOn" DataFormatString="{0:dd-M-yyyy}" />


                <asp:TemplateField HeaderText="View">
                    <HeaderStyle />
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=BuildingPlan",HttpUtility.UrlEncode(Eval("lida_allotee_id").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>


                <%-- <asp:TemplateField HeaderText="Upload Your Signed Document" ItemStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
             <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/UploadSignedCopy.aspx?ServiceReqNo={0}&Type=BP",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>' > </asp:HyperLink>
                                </ItemTemplate></asp:TemplateField>--%>
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
               <asp:View runat="server" ID="BuildingplanNotApproved">
                    <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                     <asp:GridView ID="GridView2" runat="server" ClientIDMode="Static"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AutoGenerateColumns="False"
            DataKeyNames="lida_allotee_id"
            GridLines="Horizontal"
            OnRowDataBound="GridView2_RowDataBound"
            OnRowCommand="GridView2_RowCommand"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         
                 <asp:HyperLinkField Text="Process" DataNavigateUrlFields="lida_allotee_id" DataNavigateUrlFormatString="LidaBuildingplanAssessmentView.aspx?ServiceReqNo={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="service_type" HeaderText="Service Type" SortExpression="service_type" />
                <asp:BoundField DataField="land_type" HeaderText="Land Type" SortExpression="land_type" />
                <asp:BoundField DataField="layout_area" HeaderText="Total Area" SortExpression="layout_area" />
                <asp:BoundField DataField="lida_allotee_id" HeaderText="Service Request" SortExpression="lida_allotee_id" />
                <asp:BoundField DataField="AllotteeName" HeaderText="Applicant Name" SortExpression="AllotteeName" />
                <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" HeaderText="Rejection On" SortExpression="RejectedOn" />


                <asp:TemplateField HeaderText="View">
                    <HeaderStyle />
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Allotment",HttpUtility.UrlEncode(Eval("lida_allotee_id").ToString())) %>' Text='<i class="fa fa-eye" aria-hidden="true"></i>'> </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>


                <%--<asp:TemplateField HeaderText="Upload Your Signed Document" ItemStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
             <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/UploadSignedCopy.aspx?ServiceReqNo={0}&Type=AL",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-pencil-square-o" aria-hidden="true"></i>' > </asp:HyperLink>
                                </ItemTemplate></asp:TemplateField>--%>
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


              
<%--              </asp:MultiView>
    </div>
    <div class="clearfix"></div>--%>

           <%--            
       	   </ContentTemplate>
		 </asp:UpdatePanel>
--%>
</asp:Content>

