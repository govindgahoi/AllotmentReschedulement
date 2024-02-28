<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="IAServiceReports.aspx.cs" Inherits="Allotment.IAServiceReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>
        .Red {
            color: red;
        }

        .Green {
            color: green;
        }

        .content {
            background: #e2e2e2;
        }

        .bg-mywhite {
            background: #fff;
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

        .performance-textdiv p.act-track-text {
            font-size: 11.3px;
        }

        .grid-div {
            min-height: 226px;
            margin-top: 20px;
        }

        .three-div6in {
            min-height: 99px;
            margin-top: 10px;
        }

        .div6-right {
            min-height: 230px;
            margin-top: 20px;
        }

            .div6-right div.announcemnt {
                color: red;
                font-weight: 500;
            }

        .six-div {
            min-height: 133px;
            margin-top: 20px;
        }

        .my-heading {
            background: #f5f5f5;
            padding: 0 5px;
            font-weight: 700;
        }

        .six-div-ul {
            margin: 0 10px;
        }

            .six-div-ul li {
                font-size: 13px;
                border-bottom: 1px solid #e8e8e8;
            }

        .current-open-color {
            color: #c59500;
        }

        .pmt-text-color-green {
            color: #28a500;
        }

        .pmt-text-color-yellow {
            color: #fd8e0e;
        }

        .pmt-text-color-red {
            color: red;
            font-weight: 800;
        }

        iframe {
            border: 0px solid #ccc;
        }

        .dash-status span {
            font-size: 42px;
        }

        .dash-status-inr span {
            font-size: 25px;
            color: #006d04;
            font-weight: 600;
        }

            .dash-status-inr span i {
                color: #006d04;
            }

        .three-div6in .dash-cost-text {
            margin-top: 9px;
        }

        .my-dash-table-status tr th {
            text-align: center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }

        .my-dash-table-status tr td {
            text-align: center;
            font-weight: 700;
            border-right: 3px solid #ccc !important;
        }

            .my-dash-table-status tr td:nth-child(1) {
                text-align: left;
                position: absolute;
                width: 13em;
                left: 28px;
            }

        .my-dash-table-status tr th:nth-child(1) {
            text-align: left;
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
            margin-top: 20px;
            padding: 20px;
        }

            .table-divinbox table tr th {
                font-size: 12px;
                font-weight: 700;
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
    <%--    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {

            $('[id*=GridView2]').prepend($("<thead></thead>").append($('[id*=GridView2]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 30,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });


        });
    </script>--%>

    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
        function PrintElem() {

            Popup($('#FinalPrint').html());
        }
        function PrintElemOffice() {

            Popup($('#PrintReginaloffice').html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Allotment Application</title>');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
            mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            setTimeout(function () {
                mywindow.print();
                mywindow.close();
            }, 1000);


            return true;
        }
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
    <div class="bg-mywhite table-divinbox">
        <div class="panel panel-default">
            <span class="pull-right">
                <a id="A1" runat="server" onclick="PrintElem()" style="cursor: pointer;">
                    <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                </a>
            </span>
        </div>
        <div style="overflow-x: auto; overflow-y: auto; max-height: 100%;" id="FinalPrint">
            <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>Consolidated Statement of UPSIDA Citizen services Period from 01-10-2019 till
                 <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
            <asp:GridView ID="GridView2" runat="server"
                CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                AutoGenerateColumns="False"
                DataKeyNames="ServiceTimeLinesID,ServiceTimelinesActivity,Total_Received,Total_Pending,Total_Completed,Total_Rejection,Total_Objection,DAPending,RMPending,AccountantPending,MOPending,CMIAPending,JMDPending,MDPending"
                GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound"
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
                                <span class="pull-right">
                                    <a id="A1" runat="server" onclick="PrintElemOffice()" style="cursor: pointer;">
                                        <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                                    </a>
                                </span>
                                <div id="PrintReginaloffice">
                                    <span class="center-block"></span>
                                    <h2 style='background-color: #4CAF50; text-align: center; font-size: 16px; color: #ffffff;'>
                                        <asp:Label ID="ServiceName" runat="server" Text=""></asp:Label>Period from 01-10-2019 till
                                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h2>
                                    <asp:GridView ID="GridViewAllotmentRequest" runat="server" AutoGenerateColumns="False" CssClass="request-table table table-hover table-bordered cm-table-heading myreq-col">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RegionalOffice" ItemStyle-Wrap="false" Visible="True" HeaderText="RegionalOffice" SortExpression="RegionalOffice" />
                                            <asp:BoundField DataField="Total_Received" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Received" SortExpression="Total_Received" />
                                            <asp:BoundField DataField="Total_Pending" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Pending" SortExpression="Total_Pending" />
                                            <asp:BoundField DataField="Total_Completed" HeaderText="Total Completed" SortExpression="Total_Completed" />
                                            <asp:BoundField DataField="Total_Rejection" HeaderText="Total Rejection" SortExpression="Total_Rejection" />
                                            <asp:BoundField DataField="Total_Objection" HeaderText="Total Objection" SortExpression="Total_Objection" />
                                            <asp:BoundField DataField="DAPending" HeaderText="Pending at DA" SortExpression="DAPending" />
                                            <asp:BoundField DataField="RMPending" HeaderText="Pending at RM" SortExpression="RMPending" />
                                            <asp:BoundField DataField="AccountantPending" HeaderText="Pending at Accountant" SortExpression="AccountantPending" />
                                            <asp:BoundField DataField="MOPending" HeaderText="Pending at MO" SortExpression="MOPending" />
                                             <asp:BoundField DataField="AMPending" HeaderText="Pending at AM" SortExpression="AMPending" />
                                             <asp:BoundField DataField="DMPending" HeaderText="Pending at DM" SortExpression="DMPending" />
                                            <asp:BoundField DataField="CMIAPending" HeaderText="Pending at CMIA" SortExpression="CMIAPending" />
                                            <asp:BoundField DataField="JMDPending" HeaderText="Pending at JMD" SortExpression="JMDPending" />
                                            <asp:BoundField DataField="MDPending" HeaderText="Pending at MD" SortExpression="MDPending" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IAID" HeaderText="IndustrialArea" Visible="false" SortExpression="IAID" />
                    <asp:BoundField DataField="ServiceTimelinesActivity" ItemStyle-Wrap="false" Visible="True" HeaderText="Service Name" SortExpression="ServiceTimelinesActivity" />
                    <asp:BoundField DataField="Total_Received" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Received" SortExpression="Total_Received" />
                    <asp:BoundField DataField="Total_Pending" ItemStyle-Wrap="false" Visible="True" HeaderText="Total Pending" SortExpression="Total_Pending" />
                    <asp:BoundField DataField="Total_Completed" HeaderText="Total Completed" SortExpression="Total_Completed" />
                    <asp:BoundField DataField="Total_Rejection" HeaderText="Total Rejection" SortExpression="Total_Rejection" />
                    <asp:BoundField DataField="Total_Objection" HeaderText="Total Objection" SortExpression="Total_Objection" />
                    <asp:BoundField DataField="DAPending" HeaderText="Pending at DA" SortExpression="DAPending" />
                    <asp:BoundField DataField="RMPending" HeaderText="Pending at RM" SortExpression="RMPending" />
                    <asp:BoundField DataField="AccountantPending" HeaderText="Pending at Accountant" SortExpression="AccountantPending" />
                    <asp:BoundField DataField="MOPending" HeaderText="Pending at MO" SortExpression="MOPending" />
                    <asp:BoundField DataField="AMPending" HeaderText="Pending at AM" SortExpression="AMPending" />
                    <asp:BoundField DataField="DMPending" HeaderText="Pending at DM" SortExpression="DMPending" />
                    <asp:BoundField DataField="CMIAPending" HeaderText="Pending at CMIA" SortExpression="CMIAPending" />
                    <asp:BoundField DataField="JMDPending" HeaderText="Pending at JMD" SortExpression="JMDPending" />
                    <asp:BoundField DataField="MDPending" HeaderText="Pending at MD" SortExpression="MDPending" />
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


    <%--   </ContentTemplate>
		 </asp:UpdatePanel>--%>
</asp:Content>
