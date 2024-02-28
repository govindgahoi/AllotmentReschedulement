<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserHO.Master" AutoEventWireup="true" CodeBehind="MISReportAllApplicationCMIA.aspx.cs" Inherits="Allotment.MISReportAllApplicationCMIA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }
           table tr th[colspan="8"]{
             background: #bfbfbf !important;
         }
         .request-table tr .head-IAname{
            background:#ccc !important;
        }
        .request-table tr .head-region{
            background:#ccc !important;
        }
        .request-table tr .head-total{
            background:#656565 !important;
            color:#fff;
        }
    </style>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
        $('[id*=AllGrid]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
            dom: 'Bfrtip',
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
            'iDisplayLength': 2,
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" >
            <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
                <div>
                <div style="width: 100px;float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li class="disabled">
                            <a runat="server"  class="disable">
                                <i class="fa fa-home" aria-hidden="true"></i><br />Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;font-size:11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">  
                        <li>
                            <a runat="server" id="SaveEntry"  class="disable" >
                                <i class="fa fa-floppy-o " aria-hidden="true"></i><br />Save
                            </a>
                        </li> 
                        <li>
                            <a runat="server"   class="disable">
                                <i class="fa fa-refresh" aria-hidden="true"></i><br />Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left;background: #dbdbdb;border-left:1px solid #000;border-right:1px solid #000;font-size:11px;" class="text-center">
                    Allottee Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-plus" aria-hidden="true"></i><br />New
                            </a>
                        </li>
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i><br />History
                            </a>
                        </li>
                       
                      </ul>
                </div>
                 <div style="float: left;background: #dbdbdb;font-size:11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top:1px solid #ccc;">
                        <li>
                                <a href="#" class="disable">
                                    <i class="fa fa-step-backward" aria-hidden="true"></i><br />Last
                                </a>                        
                        </li>
                        <li>
                            <a runat="server"  class="disable">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i><br />Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" id="sernext"  class="disable">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i><br />Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i><br />Final
                            </a>
                        </li>
                          <li runat="server" id="hrefPrint">
                            <a runat="server" onclick="PrintElem()" >
                                <i class="fa fa-print" aria-hidden="true"></i><br />Print
                            </a>
                        </li>
                         
                        
                    </ul>
                    </div>     
                    
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    <hr style="margin: 4px 0;border-top: 1px solid #d8d8d8;"  />
    <div class="row">
        <div class="form-group" style="background: #dadada;padding: 2px 0;margin-bottom: 3px;">
                <div class="">
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Regional Office :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddloffice" style="background:#fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="Regional_Changed" ></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Industrial Area :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="drpdwnIA" style="background:#fff;" CssClass="input-sm similar-select1" ></asp:DropDownList>
                    </div>
                    <label class="col-md-2 col-sm-1 col-xs-12">
                       Service Name :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:DropDownList runat="server" ID="ddlService" style="background:#fff;" CssClass="input-sm similar-select1" >
                         
                            <asp:ListItem Text="Land Allotment" Value="1000"  ></asp:ListItem>
                            <asp:ListItem Text="Building Plan"   Value="1"  ></asp:ListItem>
                             <asp:ListItem Text="Lease Deed Application"   Value="1001"  ></asp:ListItem>
                             <asp:ListItem Text="Time Extension"   Value="1002"  ></asp:ListItem>
                             <asp:ListItem Text="Change Of Project"   Value="1003"  ></asp:ListItem>
                             <asp:ListItem Text="Addition Of Product"   Value="1004"  ></asp:ListItem>
                             <asp:ListItem Text="NOC For Permission Of Mortage"   Value="1005"  ></asp:ListItem>
                             <asp:ListItem Text="NOC For Permission Of Joint Mortage"   Value="1006"  ></asp:ListItem>
                             <asp:ListItem Text="Request For Creation Of Second Charge"   Value="1007"  ></asp:ListItem>
                             <asp:ListItem Text="Request For Reconstitution of Allottee"   Value="1008"  ></asp:ListItem>
                             <asp:ListItem Text="Request For Completion Certificate"   Value="1009"  ></asp:ListItem>
                             <asp:ListItem Text="Request For Occupancy Certificate"   Value="1010"  ></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <label class="col-md-2 col-sm-2 col-xs-12">
                         From Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionFromDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        To Date :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                        <asp:TextBox runat="server" ID="txtTransactionToDate" style="background:#fff;" CssClass="date1 input-sm similar-select1"></asp:TextBox>
                    </div>
                    <label class="col-md-2 col-sm-2 col-xs-12">
                        Report Type :
                    </label>
                    <div class="col-md-2 col-sm-2 col-xs-12">
                       <asp:DropDownList runat="server" ID="ddlReportType" style="background:#fff;" CssClass="input-sm similar-select1">
                          
                           <asp:ListItem Value="1" > Total Received      </asp:ListItem>
                           <asp:ListItem Value="2" > Approved           </asp:ListItem>
                           <asp:ListItem Value="3" > Rejected          </asp:ListItem>
                           <asp:ListItem Value="4" > Pending          </asp:ListItem>
                           <asp:ListItem Value="5" > Under Objection </asp:ListItem>
                         
                        </asp:DropDownList>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="myhrline" />
                    <div class="col-md-12 col-sm-2 col-xs-12">
                        <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding:2px 27px;margin:10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                    </div>
                    
                </div>
                <div class="clearfix"></div>
            </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
           <div class="clearfix"></div>
            <hr class="myhrline" style="border-bottom:1px solid #d8d8d8;"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="text-align: center;padding: 15px 25px; margin: 25px 0%;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY LIMITED, KANPUR<br>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br />
                    
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 
                        <%-- CssClass="table table-striped table-bordered table-hover request-table request-table"--%>
                       <asp:GridView ID="AllGrid" runat="server"
        
                           CssClass="w3-table-all w3-hoverable"
            AutoGenerateColumns="true"
            DataKeyNames="Application ID"
            GridLines="Horizontal"      
            Width="100%" >
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


                    
                    
                    <br /><br /><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information contained in this Report  is intended solely for the use of the individual or entity to whom it is addressed and others authorized to receive it. It may contain confidential or legally privileged information. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this Report in error, please notify us immediately by responding at info[at]upsidc[dot]com  and then delete it from your system. In case of any query please contact us at info[at]upsidc[dot]com.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
