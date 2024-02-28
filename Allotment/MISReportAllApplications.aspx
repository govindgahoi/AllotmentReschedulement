<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="MISReportAllApplications.aspx.cs" Inherits="Allotment.MISReportAllApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        table tr th[colspan="8"] {
            background: #bfbfbf !important;
        }

        .request-table tr .head-IAname {
            background: #ccc !important;
        }

        .request-table tr .head-region {
            background: #ccc !important;
        }

        .request-table tr .head-total {
            background: #656565 !important;
            color: #fff;
        }
    </style>
    <%--  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager  ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <hr style="margin: 4px 0; border-top: 1px solid #d8d8d8;" />
    <div class="row">
        <div class="form-group" style="background: #dadada; padding: 2px 0; margin-bottom: 3px;">
            <div class="">
                <label class="col-md-2 col-sm-2 col-xs-12">
                    Regional Office :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddloffice" Style="background: #fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed"></asp:DropDownList>
                </div>
                <label class="col-md-2 col-sm-2 col-xs-12">
                    Industrial Area :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="drpdwnIA" Style="background: #fff;" CssClass="input-sm similar-select1"></asp:DropDownList>
                </div>
                <label class="col-md-2 col-sm-1 col-xs-12">
                    Service Name :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddlService" Style="background: #fff;" CssClass="input-sm similar-select1">

                        <asp:ListItem Text="Land Allotment" Value="1000"></asp:ListItem>
                        <asp:ListItem Text="Building Plan" Value="1"></asp:ListItem>
                        <asp:ListItem Value="1003">Change Of Project</asp:ListItem>
                        <asp:ListItem Value="1004">Addition Of Product</asp:ListItem>
                        <asp:ListItem Value="1001">Request For Execution & Registration of Lease Deed </asp:ListItem>
                        <asp:ListItem Value="10001">Request for Possession of Plot </asp:ListItem>
                        <asp:ListItem Value="200">Online Payment of Reservation Money</asp:ListItem>
                        <asp:ListItem Value="1005">Request For Issuance Of NOC For Mortage</asp:ListItem>
                        <asp:ListItem Value="1006">Request For Issuance Of NOC For Joint Mortgage</asp:ListItem>
                        <asp:ListItem Value="1007">Request For Permission For Creation Of Second Charge</asp:ListItem>
                        <asp:ListItem Value="1011">Application for  Transfer of lease deed</asp:ListItem>
                        <asp:ListItem Value="1002">Application for  Time Extenstion Fee</asp:ListItem>
                        <asp:ListItem Value="4">Request for Transfer of Plot</asp:ListItem>
                        <asp:ListItem Value="1023">Request for No Dues Certificate</asp:ListItem>
                        <asp:ListItem Value="1027">Request for Outstanding dues position</asp:ListItem>
                        <asp:ListItem Value="1028">Online Payment of Outstanding Dues</asp:ListItem>
                        <asp:ListItem Value="1021">Request for legal heir after death</asp:ListItem>
                        <asp:ListItem Value="1017">Request for handover of lease deed to the lessee</asp:ListItem>
                        <asp:ListItem Value="1008">Request for reconstitution allottee firm / company</asp:ListItem>
                        <asp:ListItem Value="1014">Application for  Start of Production Certificate</asp:ListItem>
                        <asp:ListItem Value="1012">Application for Restoration of plot</asp:ListItem>
                        <asp:ListItem Value="1024">Request for Surrender of Plot</asp:ListItem>
                        <asp:ListItem Value="1025">Request for Establishment of Additional Unit</asp:ListItem>
                        <asp:ListItem Value="1026">Request for Subletting of Plot </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <label class="col-md-2 col-sm-2 col-xs-12">
                    From Date :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:TextBox runat="server" ID="txtTransactionFromDate" Style="background: #fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                </div>
                <label class="col-md-2 col-sm-2 col-xs-12">
                    To Date :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:TextBox runat="server" ID="txtTransactionToDate" Style="background: #fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                </div>
                <label class="col-md-2 col-sm-2 col-xs-12">
                    Report Type :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddlReportType" Style="background: #fff;" CssClass="input-sm similar-select1">

                        <asp:ListItem Value="1"> Total Received      </asp:ListItem>
                        <asp:ListItem Value="2"> Approved           </asp:ListItem>
                        <asp:ListItem Value="3"> Rejected          </asp:ListItem>
                        <asp:ListItem Value="4"> Pending          </asp:ListItem>
                        <asp:ListItem Value="5"> Under Objection </asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="col-md-12 col-sm-2 col-xs-12">
                    <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding: 2px 27px; margin: 10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                </div>

            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom: 1px solid #d8d8d8;" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 0%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" runat="server" style="text-align: center;">

                    <%-- CssClass="table table-striped table-bordered table-hover request-table request-table"--%>
                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                    <br />

                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="table-responsive" style="overflow-y: auto; max-height: 590px;">
                        <asp:GridView ID="AllGrid" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            OnRowDataBound="AllGrid_RowDataBound"
                            ClientIDMode="Static"
                            AutoGenerateColumns="true"
                            DataKeyNames="ApplicationID"
                            GridLines="Horizontal"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
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




                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="mail-disclaimer">
                        <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=AllGrid]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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

        function PrintElem() {

            Popup($('#DivP').html());
        }


        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Allottee Details</title>');
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
