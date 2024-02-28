<%@ Page Title="" Language="C#" MasterPageFile="~/MainUserLAO.Master" AutoEventWireup="true" Debug="true" CodeBehind="LandAcquisitionRegistration.aspx.cs"
    Inherits="Allotment.LandAcquisitionRegistration" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .hideGridColumn {
            display: none;
        }

        #ContentPlaceHolder1_radio1 {
            margin-top: 0;
        }

        @media only screen and (max-width: 992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

        .form-group em span {
            color: #000000 !important;
            font-size: 12px;
            /*font-weight:500;*/
        }

        .panel .allot-heading {
            padding: 0 7px;
            background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #e2e2e2), color-stop(1, #fafafa)) !important;
            background: -ms-linear-gradient(bottom, #e2e2e2, #fafafa) !important;
            background: -moz-linear-gradient(center bottom, #e2e2e2 0%, #fafafa 100%) !important;
            background: -o-linear-gradient(bottom, #e2e2e2, #fafafa) !important;
            filter: progid:dximagetransform.microsoft.gradient(startColorStr='#e3e3e3', EndColorStr='#ffffff') !important;
        }

            .panel .allot-heading:not(.no-collapse):hover {
                background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #efefef), color-stop(1, #fafafa));
                background: -ms-linear-gradient(bottom, #efefef, #fafafa);
                background: -moz-linear-gradient(center bottom, #efefef 0%, #fafafa 100%);
                background: -o-linear-gradient(bottom, #efefef, #fafafa);
                filter: progid:dximagetransform.microsoft.gradient(startColorStr='#e3e3e3', EndColorStr='#ffffff');
                -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorStr='#fafafa',EndColorStr='#efefef')";
                box-shadow: inset 0px 1px 1px white;
            }
    </style>
    <link href="css/Wizard.css" rel="stylesheet" />
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
            $('[id*=GridView1_pending_process]').prepend($("<thead></thead>").append($('[id*=GridView1_pending_process]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'LandAcquisition_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'LandAcquisition_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'LandAcquisition_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });
            $('[id*=gvNotification]').prepend($("<thead></thead>").append($('[id*=gvNotification]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Notification_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Notification_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Notification_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvPossessionDetails]').prepend($("<thead></thead>").append($('[id*=gvPossessionDetails]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'PossessionDetails_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'PossessionDetails_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'PossessionDetails_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvAward]').prepend($("<thead></thead>").append($('[id*=gvAward]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Award_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Award_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Award_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvConveyence]').prepend($("<thead></thead>").append($('[id*=gvConveyence]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Conveyence_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Conveyence_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Conveyence_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvPaymentDetails]').prepend($("<thead></thead>").append($('[id*=gvPaymentDetails]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'PaymentDetails_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'PaymentDetails_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'PaymentDetails_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvCompansation]').prepend($("<thead></thead>").append($('[id*=gvCompansation]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Compansation_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Compansation_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Compansation_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

            $('[id*=gvLitigation]').prepend($("<thead></thead>").append($('[id*=gvLitigation]').find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                'iDisplayLength': 20,
                buttons: [
                    { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Litigation_Excel', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Litigation_Csv', exportOptions: { modifier: { page: 'all' } } },
                    { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Litigation_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                ]
            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
    --%>
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
            <div>
                <div style="width: 100px; float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    <br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li class="disabled">
                            <a runat="server" onserverclick="Home_ServerClick">
                                <i class="fa fa-home" aria-hidden="true"></i>
                                <br />
                                Home
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; font-size: 11px;" class="text-center">
                    Operate<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a runat="server" id="SaveEntry" onserverclick="SaveEntry_ServerClick">
                                <i class="fa fa-floppy-o " aria-hidden="true"></i>
                                <br />
                                Save
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="Reset_ServerClick">
                                <i class="fa fa-refresh" aria-hidden="true"></i>
                                <br />
                                Refresh
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; border-left: 1px solid #000; border-right: 1px solid #000; font-size: 11px;" class="text-center">
                    Allottee Registration<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a runat="server" onserverclick="NewAllottee_ServerClick">
                                <i class="fa fa-plus" aria-hidden="true"></i>
                                <br />
                                New
                            </a>
                        </li>
                    </ul>
                </div>
                <div style="float: left; background: #dbdbdb; font-size: 11px;" class="text-center">
                    Navigation<br />
                    <ul class="list-inline master-nav-icons master-nav-iconsbr" style="border-top: 1px solid #ccc;">
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-backward" aria-hidden="true"></i>
                                <br />
                                Last
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="prev_server_click">
                                <i class="fa fa-angle-double-left" aria-hidden="true"></i>
                                <br />
                                Previous
                            </a>
                        </li>
                        <li>
                            <a runat="server" onserverclick="next_server_click" id="sernext">
                                <i class="fa fa-angle-double-right" aria-hidden="true"></i>
                                <br />
                                Next
                            </a>
                        </li>
                        <li>
                            <a href="#" class="disable">
                                <i class="fa fa-step-forward" aria-hidden="true"></i>
                                <br />
                                Final
                            </a>
                        </li>
                        <li runat="server" id="hrefPrint" >
                            <a runat="server" onclick="PrintElem()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
                            </a>
                        </li>
                        <li runat="server" id="hrefPrint1" visible="false">
                            <a onclick="PrintElem()">
                                <i class="fa fa-print" aria-hidden="true"></i>
                                <br />
                                Print
                            </a>
                        </li>

                    </ul>
                </div>

            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <ol class="breadcrumb" style="display: none;">
        <li><a href="#">Home</a></li>
        <li><a href="#">Private</a></li>
        <li><a href="#">Pictures</a></li>
        <li><a href="#">Vacation</a></li>
    </ol>
    <div style="border-bottom-color: antiquewhite; border-bottom-width: inherit; border-width: 10px">
        <div id="divMessageError" class="MessagePennel" runat="server" style="display: none;">
            <label>
                <span class="check-cross" runat="server">✖</span>

                <asp:Label ID="lblMessageError" Text="" runat="server"></asp:Label>
            </label>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="GridDetails" runat="server">
                <div class="row" style="border: groove">
                    <div class="col-md-12 col-sm-12 col-xs-12" style="background: #dbdbdb;">
                        <div class="col-md-2 col-sm-2 col-xs-2" style="float: left;">
                            Name of District :
                        </div>
                        <div class="col-md-10 col-sm-10 col-xs-10">
                            <asp:DropDownList ID="drpDistict" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpDistict_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-sm-2 col-xs-2" style="float: left; visibility:hidden" >
                            Tehsil :
                        </div>
                        <div class="col-md-2 col-sm-2 col-xs-2" style="float: left; visibility:hidden">
                            <asp:DropDownList ID="ddlSubDistict" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDistict_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-sm-2 col-xs-2" style="float: left; visibility:hidden">
                            Industrial Area Name :
                        </div>
                        <div class="col-md-2 col-sm-2 col-xs-2" style="float: left; visibility:hidden">
                            <asp:DropDownList ID="drpdwnIA" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <hr style="margin: 15px 0; border-top: 2px solid #dedddd" />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <p class="panel-heading font-bold">
                                Land Acquisition Register
                            </p>
                            <div class="panel-body gallery  table-responsive">
                                <asp:GridView ID="GridView1_pending_process" runat="server" CssClass="table table-striped table-bordered table-hover request-table" ClientIDMode="Static" AutoGenerateColumns="false" DataKeyNames="LandID" GridLines="Horizontal"
                                    OnRowCommand="GridView1_pending_process_RowCommand"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name" SortExpression="DistrictName" />
                                        <asp:BoundField DataField="TehsilName" HeaderText="Tehsil Name" SortExpression="TehsilName" />
                                        <asp:BoundField DataField="Pargana" HeaderText="Pargana" SortExpression="Pargana" />
                                        <asp:BoundField DataField="IAName" HeaderText="IndustrialArea Name" SortExpression="IAName" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        <asp:TemplateField HeaderText="View">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnView" CssClass="fa fa-eye" aria-hidden="true" CommandName="ViewRow" CommandArgument='<%#Eval("LandID") %>' ToolTip="Click here to View Request " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Process">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Select_allotee_for_process" CommandArgument='<%#Eval("LandID") %>' ToolTip="Click here For Registrations Process " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Deactivate" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandArgument='<%#Eval("LandID") %>' CommandName="DeleteAllotteeRecords" OnClientClick="javascript:return confirm('Are you sure wanted to Deactived Records?');" ToolTip="Click here to reject" />
                                                </span>  
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
                    </div>
                </div>
            </asp:View>
            <asp:View ID="BasicDetails" runat="server">
                <a onclick="Registration1()">
                    <i class="fa fa-print" aria-hidden="true"></i>
                    <br />
                </a>
                <div class="row" id="AllotteeRegistration1">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="">
                                        <div class="col-md-3 btn-group" style="display: none;">
                                            <div class="btn-group">
                                                <asp:Button ID="btnMainGrid" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_home_Click" />
                                                <asp:Button ID="btnNextNotification" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextNotification_Click" Text="Move Next" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                            <p>LAND ACQUISITION REGISTER  (1/5)</p>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="row" style="border: groove">
                                    <div class="panel-heading">Name of District,Site & Location</div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            <span style="color: Red">*</span>
                                            Name of District :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:DropDownList ID="ddlDistrictName" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictName_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            <span style="color: Red">*</span>
                                            Tehsil :
                                        </div>

                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:DropDownList ID="ddlTehsilName" runat="server" CssClass="chosen input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDistict_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            <span style="color: Red">*</span>
                                            Industrial Area Name :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:DropDownList ID="ddlIAName" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Village Name :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:ListBox runat="server" ID="ddlVillage" CssClass="MultiSelect chosen input-sm similar-select1" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-heading">Total Area Acquired/Resumed (in hectare)</div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Private Land :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtPrivateLand" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Public Utility  Land :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtPublicUtility" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            General  Land :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtGeneralLand" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            G.S.Land :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtGSLand" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Ceiling Land :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtCeilingLand" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            ForestLand :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtForestLand" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Other :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtOtherArea" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="panel-heading">Details of Properties as per</div>
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            No of Tubewells :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtNoofTubewells" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            No of Pucca Buildings :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtNoofPuccaBuildings" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            No of Pucca Drains :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtNoofPuccaDrains" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Area of groves lands :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtAreaofgroveslands" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Nos of Worship Places :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtNosofWorshipPlaces" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Nos of Trees :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtNosofTrees" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Other :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtOther" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-4" style="float: left;">
                                            Remark :
                                        </div>
                                        <div class="col-md-8 col-sm-8 col-xs-8">
                                            <asp:TextBox ID="txtRemark" CssClass="input-sm similar-select1" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btn_first_save" OnClick="btn_first_Click" CssClass="btn btn-sm btn-primary" runat="server" Text="Save" OnClientClick="return check1()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>

                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                        </div>
                        <asp:Label ID="LandID" runat="server" Style="display: none"></asp:Label>
                    </div>

                </div>
                <asp:Label ID="lblNewButton" runat="server" Style="display: none"></asp:Label>
            </asp:View>
            <asp:View ID="NotificationDetails" runat="server">
                <div class="row">
                    <div class="panel">
                        <div class="">
                            <div class="col-md-3 btn-group" style="display: none;">
                                <div class="btn-group">
                                    <asp:Button ID="btnprevBasic" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_Basic_Click" />
                                    <asp:Button ID="btnnextResumption" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextResumption_Click" Text="Move Next" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="panel-heading font-bold" style="text-align: center;">
                                    Details of Notification/Resumption Orders                         
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Village Name :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlVilageList" runat="server" CssClass=" chosen input-sm similar-select1"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Type of Land :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:DropDownList ID="ddlTypeofland" runat="server" CssClass="input-sm dropdown-toggle similar-select1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="Private Land">Private Land</asp:ListItem>
                                                    <asp:ListItem Value="G.S.Land">G.S.Land</asp:ListItem>
                                                    <asp:ListItem Value="Ceiling Land">Ceiling Land</asp:ListItem>
                                                    <asp:ListItem Value="Forent Land">Forent Land</asp:ListItem>
                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                <span style="color: Red">*</span>
                                                Area in (Hectare ) :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                No of Proposals  :
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtNoofProposals" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                Date of Proposals:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtDateofProposals" runat="server" CssClass="date input-sm similar-select1" ToolTip="DD/MM/YYYY"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-heading font-bold" style="text-align: center;">
                                        Details of Notification/Resumption Order                          
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                   
                                    <div class="clearfix"></div>
                                   - <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                Notification/Resumption Nos:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtNotificationNo" runat="server" CssClass="similar-select1 input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                Notification/Resumption Date:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtNotificationDate" runat="server" CssClass="date input-sm similar-select1 " ToolTip="DD/MM/YYYY"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="row">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                Notification Area in (Hectare )
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtNotificationArea" runat="server" CssClass="input-sm similar-select1" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                     <div class="form-group">
                                        <div class="row" style="visibility:hidden">
                                            <label class="col-md-3 col-sm-12 text-right">
                                                U/S:
                                            </label>
                                            <div class="col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtus" runat="server" CssClass="input-sm similar-select1" ToolTip="u/s"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                                            <asp:Button ID="btnNotificationDetails" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnNotificationDetails_Click" />
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <asp:Label ID="msg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Existing Rate Record
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="ResumptionOrderIDlbl" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvNotification" runat="server" DataKeyNames="ResumptionOrderID" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table request-table"
                                    OnRowCommand="gvNotification_RowCommand" ClientIDMode="Static" OnPageIndexChanging="gvNotification_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="TypeofLand" HeaderText="TypeofLand" SortExpression="TypeofLand" />
                                        <asp:BoundField DataField="TotalArea" HeaderText="TotalArea(Hectare)" SortExpression="TotalArea" />
                                        <asp:BoundField DataField="NoofProposals" HeaderText="NoofProposals" SortExpression="NoofProposals" />
                                        <asp:BoundField DataField="DateofProposals" HeaderText="Date of Proposals" SortExpression="DateofProposals" />
                                        <asp:BoundField DataField="US" HeaderText="U/S" SortExpression="US" />
                                        <asp:BoundField DataField="ResumptionNumber" HeaderText="Resumption Number" SortExpression="ResumptionNumber" />
                                        <asp:BoundField DataField="ResumptionDate" HeaderText="Resumption Date" SortExpression="ResumptionDate" />
                                        <asp:BoundField DataField="ResumptionArea" HeaderText="ResumptionArea(Hectare)" SortExpression="ResumptionArea" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("ResumptionOrderID")+"/"+ Eval("LandID")+"/"+ Eval("NameofVillage") %>' ToolTip="Click here For Update Rate " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteNotification" CommandArgument='<%#Eval("ResumptionOrderID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="PossessionDetails" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnprevNotification" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_Notificatin_Click" />
                        <asp:Button ID="btnnextAwards" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextPossession_Click" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="Possassionlbl" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Possession                           
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Village Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlPossessionVillage" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Possession Date:
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtPossessionDate" runat="server" placeholder="dd/mm/yyyy" CssClass="date input-sm similar-select1" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Possession Area(in Hectare)
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtPossessionArea" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnPossessionDetails" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnPossessionDetails_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Details of Possession
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvPossessionDetails" DataKeyNames="PossessionID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvPossessionDetails_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvPossessionDetails_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="PossessionArea" HeaderText="Possession Area(Hectare)" SortExpression="PossessionArea" />
                                        <asp:BoundField DataField="PossessionDate" HeaderText="Possession Date" SortExpression="PossessionDate" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("PossessionID")+"/"+ Eval("LandID") +"/"+ Eval("VillageName") %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeletePossession" CommandArgument='<%#Eval("PossessionID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="AwardsDetails" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnPrePossessionDetail" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnPrePossessionDetail_Click1" />
                        <asp:Button ID="btnNextPayment" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextPayment_Click1" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="lblAwards" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Final Awards                          
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Village Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlFinalAwardsVillage" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Awards Date:
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtAwardsDate" runat="server" placeholder="dd/mm/yyyy" CssClass="date input-sm similar-select1" ToolTip="Enter Date In dd/mm/yyyy Format"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Awards Area(in Hectare)
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtAwardedArea" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Amount(₹)
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Remarks
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="input-sm similar-select1" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnAward" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnAwardDetails_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Details of Awards
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:GridView ID="gvAward" DataKeyNames="AwardsID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvAward_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvAward_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="AwardsDate" HeaderText="Awards Date" SortExpression="AwardsDate" />
                                        <asp:BoundField DataField="AwardsArea" HeaderText="Awards Area(Hectare)" SortExpression="AwardsArea" />
                                        <asp:BoundField DataField="AwardedAmount" HeaderText="AwardedAmount(₹)" SortExpression="AwardedAmount" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />


                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("AwardsID")+"/"+ Eval("LandID") +"/"+ Eval("VillageName") %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteAward" CommandArgument='<%#Eval("AwardsID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="DetailsofConveyence" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnPreAward" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="Previous_Awards_Click" />
                        <asp:Button ID="btnPayment" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextPossession_Click" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="lblConveyence" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Conveyence Deeds                          
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Village Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlConveyenceDeedVillageName" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Area(in Hectare)
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtConveyenceArea" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Execution
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtExecution" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Registration
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtRegistration" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Mutation
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtMutation" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Initial
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtInitial" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Remarks
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtConRemarks" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnConveyenceDeed" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnConveyenceDeed_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Details of Conveyence Deeds
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:GridView ID="gvConveyence" DataKeyNames="ConveyenceID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvConveyence_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvConveyence_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="Area" HeaderText="Area(Hectare)" SortExpression="Area" />
                                        <asp:BoundField DataField="Execution" HeaderText="Execution" SortExpression="Execution" />
                                        <asp:BoundField DataField="Registration" HeaderText="Registration" SortExpression="Registration" />
                                        <asp:BoundField DataField="Mutation" HeaderText="Mutation" SortExpression="Mutation" />
                                        <asp:BoundField DataField="Initial" HeaderText="Initial" SortExpression="Initial" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />

                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("ConveyenceID")+"/"+ Eval("LandID") +"/"+ Eval("VillageName") %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteConveyence" CommandArgument='<%#Eval("ConveyenceID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="PaymentDetails" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnpreConveyence" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnpreConveyence_Click" />
                        <asp:Button ID="btnNextDistoursement" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextDistoursement_Click" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="lblPaymentID" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Payment                          
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Village Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:ListBox runat="server" ID="VillageList" CssClass="MultiSelect input-sm similar-select1"  SelectionMode="Multiple"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Details:
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtDetails" runat="server" CssClass="date input-sm similar-select1" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Draft No
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtDraftNo" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Draft  Date
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtDraftDate" runat="server" CssClass="date input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Amount(₹) 
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnPaymentDetails" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnPaymentDetails_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Details of Payment
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvPaymentDetails" DataKeyNames="LAPaymentID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvPaymentDetails_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvPaymentDetails_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                                        <asp:BoundField DataField="DraftNo" HeaderText="DraftNo" SortExpression="DraftNo" />
                                        <asp:BoundField DataField="DraftDate" HeaderText="DraftDate" SortExpression="DraftDate" />
                                        <asp:BoundField DataField="DraftAmount" HeaderText="DraftAmount(₹)" SortExpression="DraftAmount" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("LAPaymentID")+"/"+ Eval("LandID") +"/"+ Eval("VillageName") %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeletePayment" CommandArgument='<%#Eval("LAPaymentID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="DistoursementofCompansation" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnPrePaymentDetails" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnPrePaymentDetails_Click" />
                        <asp:Button ID="btnNextLitigation" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextLitigation_Click" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="lblCompansationID" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Refund                           
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Village Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlVillageCompansation" runat="server" CssClass="chosen input-sm similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Amount(₹)
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtCompansationAmount" runat="server" CssClass="input-sm similar-select1" ToolTip="only Numeric Value" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnCompansation" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnCompansation_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                   Details of Refund
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvCompansation" DataKeyNames="DistbursementID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvCompansation_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvCompansation_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                        <asp:BoundField DataField="DistbursementAmount" HeaderText="Refund Amount(₹)" SortExpression="DistbursementAmount" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("DistbursementID")+"/"+ Eval("LandID") +"/"+ Eval("VillageName") %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteCompansation" CommandArgument='<%#Eval("DistbursementID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="Litigation" runat="server">
                <div class="col-md-3 btn-group" style="display: none;">
                    <div class="btn-group">
                        <asp:Button ID="btnPreDistoursementofCompansation" runat="server" CssClass="btn btn-sm btn-primary" Style="margin-right: 2px;" Text="Move Previous" OnClick="btnPreDistoursementofCompansation_Click" />
                        <asp:Button ID="btnNextFinalView" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnNextFinalView_Click" Text="Move Next" />
                    </div>
                </div>
                <asp:Label ID="lblLitigationID" runat="server" Visible="false"></asp:Label>
                <div class="panel-heading font-bold" style="text-align: center;">
                    Details of Litigation                           
                </div>
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            <span style="color: Red">*</span>
                            Case Name :
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtCaseName" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                             <span style="color: Red">*</span>
                            Case Type
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlCaseType" runat="server" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                             <span style="color: Red">*</span>
                            Court
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:DropDownList ID="ddlCourttype" runat="server" CssClass="input-sm dropdown-toggle similar-select1"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Lawyer
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtLawyer" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="row">
                        <label class="col-md-3 col-sm-12 text-right">
                            Party Name
                        </label>
                        <div class="col-md-9 col-sm-12">
                            <asp:TextBox ID="txtPartyName" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <hr class="myhrline" />
                <div class="form-group">
                    <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 0;">
                        <asp:Button ID="btnLitigation" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnLitigation_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="panel">
                        <div class="col-md-12">
                            <div class="clearfix"></div>
                            <div class="panel-heading">
                                <div class="col-md-6 font-bold" style="margin-top: 12px;">
                                    Details of Litigation
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body gallery  table-responsive">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvLitigation" DataKeyNames="LitigationID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table" OnRowCommand="gvLitigation_RowCommand"
                                    ClientIDMode="Static" OnPageIndexChanging="gvLitigation_PageIndexChanging" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CaseName" HeaderText="Case Name" SortExpression="CaseName" />
                                        <asp:BoundField DataField="Case_Type" HeaderText="Case Type" SortExpression="Case_Type" />
                                        <asp:BoundField DataField="Court_Type" HeaderText="Court Type" SortExpression="Court_Type" />
                                        <asp:BoundField DataField="Lawyer" HeaderText="Lawyer" SortExpression="Lawyer" />
                                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="PartyName" />
                                        <asp:TemplateField HeaderText="Update">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEdit" CssClass="fa fa-sign-in" CommandName="Process" CommandArgument='<%#Eval("LitigationID")+"/"+ Eval("LandID")  %>' ToolTip="Click here For Update Records " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="fa fa-trash-o" CommandName="DeleteLitigation" CommandArgument='<%#Eval("LitigationID") %>' OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" ToolTip="Click here to delete Rate" />
                                                </span>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>

            <asp:View ID="FinalView" runat="server">
                <div class="btn-group">
                </div>
                <div class="row" id="AllotteeRegistration8">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="width: 100%;">
                                <div class="row">
                                    <div class="">
                                        <div class="col-md-3" style="display: none;">
                                            <div class="btn-group">
                                                <asp:Button ID="btnPrevLitigation" runat="server" CssClass="btn btn-sm btn-primary" Text="Move Previous" OnClick="btnPrevLitigation_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body" id="DivFinalView">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                            <table class="table table-bordered table-hover request-table">
                                                <thead>
                                                    <tr>
                                                        <th colspan="2" style="width: 25%; align-content: center;" class="text-center ">
                                                            <b>Name  of District .Site & Location  </b>
                                                        </th>
                                                        <th colspan="2" style="width: 25%; align-content: center;" class="text-center">
                                                            <b>Total Area Acquired/Resumed (Hectare)  </b>
                                                        </th>
                                                        <th colspan="2" style="width: 25%; align-content: center;" class="text-center">
                                                            <b>Details of Properties as Records  </b>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td rowspan="2" class="font-bold">District: 
                                                        </td>
                                                        <td rowspan="2">
                                                            <asp:Label ID="lblDistrictName" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">Private Land :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPrivateLand" runat="server"></asp:Label>
                                                        </td>

                                                        <td class="font-bold">No of Tubewells :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTubewells" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="font-bold">G.S. Land :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblGSLand" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">No of Pucca Buildings :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPucca" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="2" class="font-bold">Tehsil Name :
                                                        </td>
                                                        <td rowspan="2">
                                                            <asp:Label ID="lblTehsilName" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">Ceiling Land :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCeilingLand" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">No of Pucca Drain :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDrain" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="font-bold">ForestLand : 
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblForestLand" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">Area of graves lands  : 
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblgravesland" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="font-bold">Industrial  Area Site Location :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndustrialArea" runat="server"></asp:Label>
                                                        </td>
                                                        <td rowspan="2" class="font-bold">Other  : 
                                                        </td>
                                                        <td rowspan="2">
                                                            <asp:Label ID="lblOther" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">No of Worship Place:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWorship" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="2" class="font-bold">Village Name :
                                                        </td>
                                                        <td rowspan="2">
                                                            <asp:Label ID="lblVillageName" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="font-bold">No of Trees:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTrees" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="font-bold">Public Utility Land Area:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPublicUtilityLandArea" runat="server"></asp:Label>
                                                        </td>
                                                        <td rowspan="4" class="font-bold">Other:
                                                        </td>
                                                        <td rowspan="4">
                                                            <asp:Label ID="lblotherDetails" runat="server"></asp:Label>
                                                        </td>
                                                         
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="3" class="font-bold">Remarks:
                                                        </td>
                                                        <td rowspan="3">
                                                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td class="font-bold">General Land Area:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblGeneralLandArea" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                         <td class="font-bold">Total  : 
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                        </td>

                                                         
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center "><b>Details of final Awards </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewAward" DataKeyNames="AwardsID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="AwardsDate" HeaderText="Awards Date" SortExpression="AwardsDate" />
                                                            <asp:BoundField DataField="AwardsArea" HeaderText="Awards Area(Hectare)" SortExpression="AwardsArea" />
                                                            <asp:BoundField DataField="AwardedAmount" HeaderText="AwardedAmount(₹)" SortExpression="AwardedAmount" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center"><b>Details of Conveyence Deeds </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewConveyenceDeed" DataKeyNames="ConveyenceID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="Area" HeaderText="Area(Hectare)" SortExpression="Area" />
                                                            <asp:BoundField DataField="Execution" HeaderText="Execution" SortExpression="Execution" />
                                                            <asp:BoundField DataField="Registration" HeaderText="Registration" SortExpression="Registration" />
                                                            <asp:BoundField DataField="Mutation" HeaderText="Mutation" SortExpression="Mutation" />
                                                            <asp:BoundField DataField="Initial" HeaderText="Initial" SortExpression="Initial" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />

                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center"><b>Details of Notification/Resumption Orders </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewNotification" runat="server" DataKeyNames="ResumptionOrderID" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        ClientIDMode="Static" PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="TypeofLand" HeaderText="TypeofLand" SortExpression="TypeofLand" />
                                                            <asp:BoundField DataField="TotalArea" HeaderText="TotalArea(Hectare)" SortExpression="TotalArea" />
                                                            <asp:BoundField DataField="NoofProposals" HeaderText="NoofProposals" SortExpression="NoofProposals" />
                                                            <asp:BoundField DataField="DateofProposals" HeaderText="Date of Proposals" SortExpression="DateofProposals" />
                                                            <asp:BoundField DataField="US" HeaderText="U/S" SortExpression="US" />
                                                            <asp:BoundField DataField="ResumptionNumber" HeaderText="Resumption Number" SortExpression="ResumptionNumber" />
                                                            <asp:BoundField DataField="ResumptionDate" HeaderText="Resumption Date" SortExpression="ResumptionDate" />
                                                            <asp:BoundField DataField="ResumptionArea" HeaderText="ResumptionArea(Hectare)" SortExpression="ResumptionArea" />

                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center"><b>Details of Possession </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalviewPossession" DataKeyNames="PossessionID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="PossessionArea" HeaderText="Possession Area(Hectare)" SortExpression="PossessionArea" />
                                                            <asp:BoundField DataField="PossessionDate" HeaderText="Possession Date" SortExpression="PossessionDate" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center"><b>Particulars of Payment </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewPayment" DataKeyNames="LAPaymentID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                                                            <asp:BoundField DataField="DraftNo" HeaderText="DraftNo" SortExpression="DraftNo" />
                                                            <asp:BoundField DataField="DraftDate" HeaderText="DraftDate" SortExpression="DraftDate" />
                                                            <asp:BoundField DataField="DraftAmount" HeaderText="DraftAmount(₹)" SortExpression="DraftAmount" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center"><b>Details of Refund  </b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewCompansation" DataKeyNames="DistbursementID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Census_VillageName" HeaderText="NameofVillage" SortExpression="Census_VillageName" />
                                                            <asp:BoundField DataField="DistbursementAmount" HeaderText="Refund Amount(₹)" SortExpression="DistbursementAmount" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="panel panel-default">
                                                <p class="panel-heading allot-heading text-center" style=""><b>Details of Litigation</b></p>
                                                <div class="panel-body gallery  table-responsive">
                                                    <asp:GridView ID="gvFinalViewLitigation" DataKeyNames="LitigationID" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table table-striped table-bordered table-hover request-table"
                                                        PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Right" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CaseName" HeaderText="Case Name" SortExpression="CaseName" />
                                                            <asp:BoundField DataField="Case_Type" HeaderText="Case Type" SortExpression="Case_Type" />
                                                            <asp:BoundField DataField="Court_Type" HeaderText="Court Type" SortExpression="Court_Type" />
                                                            <asp:BoundField DataField="Lawyer" HeaderText="Lawyer" SortExpression="Lawyer" />
                                                            <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="PartyName" />

                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Available
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <hr class="myhrline" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:View>

        </asp:MultiView>
    </div>

    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "1960:+10" }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });;

        });
    </script>
    <script type="text/javascript">

        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            } else {


            }
        }

        //PaymentGridView

        function ValidateFill(obj, txt) {
            var txtObj = document.getElementById(obj.id);
            if (txtObj.value.length > 0) {
                txtObj.style.borderColor = "";
                hideError();
                return true;
            }


        }
        function PrintElem() {

            Popup($('#DivFinalView').html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=2000,width=1000');
            mywindow.document.write('<html><head><title style="font-weight:bold;">Land Acquisition Register</title>');
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


</asp:Content>
