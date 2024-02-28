﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="MISReportInvestmentFeedback.aspx.cs" Inherits="Allotment.MISReportInvestmentFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .modal{
           width:500px;
           margin-left:auto;
           margin-right:auto;
           text-align:center;
           background-color:lightyellow;
           z-index:9999;
           margin-top:100px;
           margin-bottom:200px;
       }
       .modal-backdrop{
           position:relative;
       }
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
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="form-group" style="background: #dadada; padding: 2px 0; margin-bottom: 3px;">
            <div class="">
                <label class="col-md-2 col-sm-1 col-xs-12">
                    Page Index :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddlPageIndex" OnSelectedIndexChanged="btnFetch_Click" AutoPostBack="true" Style="background: #fff;" CssClass="input-sm similar-select1">
                        <asp:ListItem Text="10" Value="0"></asp:ListItem>
                        <asp:ListItem Text="20" Value="1"></asp:ListItem>
                        <asp:ListItem Text="50" Value="2"></asp:ListItem>
                        <asp:ListItem Text="100" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label class="col-md-2 col-sm-2 col-xs-12">
                    Regional Office :
                </label>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <asp:DropDownList runat="server" ID="ddloffice" Style="background: #fff;" CssClass="input-sm similar-select1"></asp:DropDownList>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="col-md-12 col-sm-2 col-xs-12">
                    <asp:Button ID="btnFetch" runat="server" OnClick="btnFetch_Click" Text="Fetch" Style="padding: 2px 27px; margin: 10px 0;" CssClass="btn-primary ey-bg pull-right" />

                </div>

            </div>
            <div class="clearfix"></div>
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
                        <asp:GridView ID="AllGrid" runat="server" AllowPaging="true" OnPageIndexChanging="AllGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static"
                            AutoGenerateColumns="false"
                            DataKeyNames="Id"
                            GridLines="Horizontal"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Inv_Name" HeaderText="Investor Name" />
                                <asp:BoundField DataField="Inv_CompanyName" HeaderText="Company Name" />
                                <asp:BoundField DataField="Inv_Mobile" HeaderText="Mobile No" />
                                <asp:BoundField DataField="Inv_district" HeaderText="District" />
                                <asp:BoundField DataField="Inv_RegionalOffice" HeaderText="Regional Office" />
                                <asp:BoundField DataField="Inv_PraposedProject" HeaderText="Proposed Project" />
                                <asp:BoundField DataField="Inv_ProjectCost" HeaderText="Project Cost (in Rs)" />
                                <asp:BoundField DataField="Inv_Area" HeaderText="Required Area (in sqmtr)" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#myModal" role="button" class="btn" data-toggle="modal">View</a>

                                        <!-- Modal -->
                                        <div id="myModal" class="modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                <h3 id="myModalLabel">Investor Detail</h3>
                                            </div>
                                            <div class="modal-body">
                                                <p>
                                                    Investor Name : <asp:Label ID="Label0" runat="server" Text='<%# Eval("Inv_Name") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Company Name : <asp:Label ID="Label1" runat="server" Text='<%# Eval("Inv_CompanyName") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Mobile No : <asp:Label ID="Label2" runat="server" Text='<%# Eval("Inv_Mobile") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Email-Id : <asp:Label ID="Label3" runat="server" Text='<%# Eval("Inv_Email") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Postal Address : <asp:Label ID="Label4" runat="server" Text='<%# Eval("Inv_PostalAdd") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    District : <asp:Label ID="Label5" runat="server" Text='<%# Eval("Inv_district") %>'></asp:Label>
                                                </p>
                                                <%--<p>
                                                    Regional Office : <asp:Label ID="Label6" runat="server" Text='<%# Eval("Inv_RegionalOffice") %>'></asp:Label>
                                                </p>--%>
                                                <p>
                                                    Proposed Project : <asp:Label ID="Label7" runat="server" Text='<%# Eval("Inv_PraposedProject") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Required Area(in sqmtr) : <asp:Label ID="Label10" runat="server" Text='<%# Eval("Inv_Area") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Proposed Project Cost (in Rs) : <asp:Label ID="Label8" runat="server" Text='<%# Eval("Inv_ProjectCost") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    Comments : <asp:Label ID="Label9" runat="server" Text='<%# Eval("Inv_Comment") %>'></asp:Label>
                                                </p>
                                            </div>
                                            <div class="modal-footer" >
                                                <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                                                <button class="btn btn-primary" style="display:none">Save changes</button>
                                            </div>
                                        </div>
                                      
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