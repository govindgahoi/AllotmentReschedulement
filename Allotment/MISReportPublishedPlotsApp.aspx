<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MISReportPublishedPlotsApp.aspx.cs" Inherits="UpsidcApi.MISReportPublishedPlots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <title>Uttar Pradesh Industrial Development Authority</title>
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
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css"/>
    <link href="/css/theme.css" rel="stylesheet"/>
    <link href="/css/Wizard.css" rel="stylesheet"/>
    <link href="/css/Main.css" rel="stylesheet"/>
    <link href="css/style4.css" rel="stylesheet"/>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
     <script src="js/jquery-ui.js"></script>
    <script src="js/custumt.js"></script>

    <script src="js/chosen.jquery.min.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>

</head>
    <body>
    <form id="form1" runat="server">
        <div class="container">
              <div class="col-md-12 col-sm-12 col-xs-12">
           <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom:1px solid #d8d8d8;"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 0%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" runat="server" style="text-align: center;">

                    <%-- CssClass="table table-striped table-bordered table-hover request-table request-table"--%>
                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br />
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br/>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                    <br />
                    <div class="table">
                      <div class="table-responsive" >
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static"
                           AllowPaging="true"
                            OnPageIndexChanging="OnPaging"
                            AutoGenerateColumns="true"
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
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                    <div class="table-responsive">
                        <asp:GridView ID="AllGrid" runat="server" CssClass="table table-striped table-bordered table-hover request-table request-table"
                            ClientIDMode="Static"
                            AutoGenerateColumns="true"
                            AllowPaging="true"
                            OnPageIndexChanging="OnPaging"
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
     <script type="text/javascript">



         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
         });

         function PageLoaded(sender, args) {
             $(".chosen").chosen();

             $(".MultiSelect").chosen();
         }

     </script>
    </form>
</body>
</html>
