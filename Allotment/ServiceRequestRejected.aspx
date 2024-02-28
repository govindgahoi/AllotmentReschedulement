<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ServiceRequestRejected.aspx.cs" Inherits="Allotment.ServiceRequestRejected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>
            .content {
                    background: #e2e2e2;
            }
        .bg-mywhite 
        {
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



                #myModal1 {          
            left: -27% !important;
            top: 0px !important;
          }
    #myModal {          
            left: -27% !important;
            top: 0px !important;
          }
    #Action {          
            left: -27% !important;
            top: 0px !important;
          }
          #Action {          
            left: -27% !important;
            top: 0px !important;
          }
          .modal-open .modal {
            overflow-y:hidden !important;
          }
          #ModalViewGroup .modal-dialog
          {
              width: 529px !important;
              margin: 178px 871px !important;
          }

          #ModalGrid .modal-dialog
          {
              width: 529px !important;
              margin: 178px 871px !important;
          }
    #Action .modal-dialog
          {
              width: 596px !important;
              margin: 178px 871px !important;
          }
          .input-search1
          {
              width:90%;
          }
          .modal-backdrop {
    
    z-index: 0 !important;
  
}
.modal-backdrop.in {
    opacity: -0.5 !important;
    
}

       #ModalGridchange .modal-header {
                padding: 0px 12px;
                background: #e4e4e4;
                border-bottom: 1px solid #ccc;  
              }
              #ModalGridchange .modal-footer {
                padding:0;
              }
              #ModalGridchange button {
                margin-top:1px;
              }
              @media only screen and (min-width: 768px) {
                  #ModalGridchange .modal-dialog {
                      margin: 17% 56% !important;
                      width: 35% !important;
                  }
                  #ModalGridchange {
                    right:21%;
                    top:10%;
                  }
                  .modal-dialog
                  {
                      width: 389px !important;
                      margin-left: 55% !important;
                      margin-top: 22% !important;
                  }
              }
          @media only screen and (max-width: 768px) {
               .modal-dialog
                  {
                        width: 389px !important;
                        margin-left: 55% !important;
                        margin-top: 22% !important;
                  }
          
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
        $('[id*=Grid_PostSubDivision]').prepend($("<thead></thead>").append($('[id*=Grid_PostSubDivision]').find("tr:first"))).DataTable({
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
      <%--  <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
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


                <%-- Modal Section Start --%>
     <div class="modal fade" id="ModalGridchange" style="left:-522px !important;top:-105px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Land Allotment Refund Clearance"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Service Request No :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtSerNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
              <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                  Applicant Name:
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtApplicant" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
               <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Refund Amount :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtReceivedAmt" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Refund Date :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRefundDate" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Refund Mode :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRefundMode" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Refund Transaction Ref No :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRefNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Refund Account Number :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRefundAccNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                   IFSC Code :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtIFSCCode" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Bank Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Branch Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
             <hr class="myhrline" />
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /><asp:HiddenField  runat="server"  ID="change_id" />
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>



    
<%-- Modal Section End --%>

<input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
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

              <asp:View runat="server" ID="AllotmentView">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                            <asp:GridView ID="GridView2" runat="server"
                             ClientIDMode="Static"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal"
            OnRowDataBound="GridView1_RowDataBound"
            OnRowCommand="GridView1_RowCommand"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="S.NO" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         
                 <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="NewAssessmentUnderProcess.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
     
                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" SortExpression="ApplicantName" />
                <asp:BoundField DataField="IAName" HeaderText="Concern IA" SortExpression="ServiceRequestDepartMent" />
                <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" DataFormatString="{0:dd-M-yyyy}"  HeaderText="Rejected On" SortExpression="RejectedOn" />
                <asp:BoundField DataField="RefundStatus" ItemStyle-HorizontalAlign="Justify"  HeaderText="Refund Status" SortExpression="RefundStatus" />
                <asp:TemplateField HeaderText="RefundDate" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblRefundDate" runat="server" Text='<%# Eval("RefundOnDate") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RefundMode" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblRefundMode" runat="server" Text='<%# Eval("RefundMode") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="RefundAmount" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblRefundAmount" runat="server" Text='<%# Eval("RefundAmount") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RefundTraRefNo" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblRefundTraRefNo" runat="server" Text='<%# Eval("RefundTraRefNo") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AccountNumber" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblAccountNumber" runat="server" Text='<%# Eval("AccountNumber") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IFSCCode" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblIFSCCode" runat="server" Text='<%# Eval("IFSCCode") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BankName" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BranchName" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>' />
                </ItemTemplate>
                </asp:TemplateField>
           

                             <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper2" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Rejection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>


<%--                <asp:TemplateField HeaderText="Upload Your Signed Document" ItemStyle-HorizontalAlign="Center" >
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

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

              <asp:View runat="server" ID="BuildingView">
         <div  class="table-responsive" style="overflow-y: auto; max-height: 390px;">
        <asp:GridView ID="GridView1" runat="server" ClientIDMode="Static"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO"
            GridLines="Horizontal"
            OnRowDataBound="GridView2_RowDataBound"
            OnRowCommand="GridView1_RowCommand"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
         
                 <ASP:HYPERLINKFIELD text="View" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="BuildingPlanAssessmentView.aspx?ServiceReqNo={0}"></ASP:HYPERLINKFIELD>  
     
                  <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                  <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                  <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" SortExpression="AllotteeName" />
                  <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                  <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="AppDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="IAName" HeaderText="Concern IA" SortExpression="ServiceRequestDepartMent" />
                  <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                  <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" DataFormatString="{0:dd-M-yyyy}"  HeaderText="Rejected On" SortExpression="RejectedOn" />
                
           

                             <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Rejection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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

              <asp:View runat="server" ID="TransferView">
                       <div  class="table-responsive" style="overflow-y: auto; max-height: 390px;">
        <asp:GridView ID="GridView3" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowPaging="True"
            AllowSorting="True"
             ClientIDMode="Static"
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
                  <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                  <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                  <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" SortExpression="AllotteeName" />
                  <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                  <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="AppDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="IAName" HeaderText="Concern IA" SortExpression="ServiceRequestDepartMent" />
                  <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                  <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" DataFormatString="{0:dd-M-yyyy}"  HeaderText="Rejected On" SortExpression="RejectedOn" />
                      <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Rejection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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

                <asp:View runat="server" ID="AmalgamationView">
                       <div  class="table-responsive" style="overflow-y: auto; max-height: 390px;">
        <asp:GridView ID="GridView4" runat="server"
             CssClass="table table-striped table-bordered table-hover request-table request-table"
            AllowPaging="True"
            AllowSorting="True"
             ClientIDMode="Static"
            AutoGenerateColumns="False"
            DataKeyNames="ServiceRequestNO,UnitID"
            GridLines="Horizontal"
            
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Number" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
               <asp:HYPERLINKFIELD  Visible="true" Text="View" datanavigateurlfields="ServiceRequestNO" datanavigateurlformatstring="IAServicesAssessmentView.aspx?ServiceReqNo={0}" ></asp:HYPERLINKFIELD>
                  <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                  <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                  <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" SortExpression="AllotteeName" />
                  <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                  <asp:BoundField DataField="AppRecDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="AppDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                  <asp:BoundField DataField="IAName" HeaderText="Concern IA" SortExpression="ServiceRequestDepartMent" />
                  <asp:BoundField DataField="ServiceRequestActivity" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                  <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" DataFormatString="{0:dd-M-yyyy}"  HeaderText="Rejected On" SortExpression="RejectedOn" />
                      <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Rejection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
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
                              
                               <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request" SortExpression="ServiceRequestNO" />
                                   <asp:BoundField DataField="UnitId" HeaderText="Nivesh Mitra ID" SortExpression="UnitId" />
                              <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" />
                              <asp:BoundField DataField="PlotNo" HeaderText="Plot No" SortExpression="PlotNo" />
                               <asp:BoundField DataField="CreatedDate" HeaderText="First Application Date" DataFormatString="{0:dd-M-yyyy}" />
                               <asp:BoundField DataField="Modifiedby" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />
                             <asp:BoundField DataField="IAName" HeaderText="Concern IA" SortExpression="IAName" />

                             <%-- <asp:BoundField DataField="ModifiedDate" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" />--%>
                             <%-- <asp:BoundField DataField="LastObjectionDate" HeaderText="Objection Last Date" DataFormatString="{0:dd-M-yyyy}" />--%>
                               <asp:BoundField DataField="ApplicationType" ItemStyle-HorizontalAlign="Justify" HeaderText="Request Regarding" SortExpression="ServiceRequestActivity" />
                               <asp:BoundField DataField="RejectedOn" ItemStyle-HorizontalAlign="Justify" DataFormatString="{0:dd-M-yyyy}"  HeaderText="Rejected On" SortExpression="RejectedOn" />
                               <asp:TemplateField HeaderText="View">
                                <HeaderStyle  />
                                <HeaderTemplate   >
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:HyperLink runat="server" ID="Hyper1" Target="_blank" NavigateUrl='<%# string.Format("~/SignedLetterView.aspx?ServiceRequestNo={0}&DocType=Rejection",HttpUtility.UrlEncode(Eval("ServiceRequestNO").ToString())) %>'  Text ='<i class="fa fa-eye" aria-hidden="true"></i>' > </asp:HyperLink>
                                    </ItemTemplate>
                            </asp:TemplateField>
                               <%--<asp:TemplateField HeaderText="TimeLine For Approval" HeaderStyle-CssClass="text-center-imp" ItemStyle-CssClass="text-center-imp" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                  <ItemTemplate>
                                      <asp:HiddenField ID="DaysStatus" runat="server" Value='<%# Eval("DaysStatus").ToString()%>' />

                                      <asp:Label ID="IsPositive" runat="server" Text='<%# Eval("DaysLeft").ToString()%>' CssClass='<%# (Eval("DaysStatus").ToString())=="False" ? "Red"  : "Green" %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>--%>
                              <asp:BoundField DataField="ServiceRequestDepartMent" Visible="false" HeaderText="Concern Department" SortExpression="ServiceRequestDepartMent" />
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

       <%--                
       	   </ContentTemplate>
		 </asp:UpdatePanel>
    --%>
            <script  type="text/javascript">


                $("[src*=plus]").live("click", function () {
                    $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                    $(this).attr("src", "images/minus.png");
                });
                $("[src*=minus]").live("click", function () {
                    $(this).attr("src", "images/plus.png");
                    $(this).closest("tr").next().remove();
                });



                $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

                function ShowPopup(msg) {

                    alert(msg);
                    $("#btnModalGridchange").click();
                }


                function ShowPopupChange(val1, val2, val3, val4,val5,val6,val7,val8,val9,val10,val11) {


                    $('#<%= txtSerNo.ClientID %>').val(val1);
                    $('#<%= change_title.ClientID %>').text(val2);
                    $('#<%= change_title1.ClientID %>').val(val2);                
                    $('#<%= txtApplicant.ClientID %>').val(val3);
                    $('#<%= txtRefundDate.ClientID %>').val(val4);
                    $('#<%= txtRefundMode.ClientID %>').val(val5);
                    $('#<%= txtReceivedAmt.ClientID %>').val(val6);
                    $('#<%= txtRefNo.ClientID %>').val(val7);
                    $('#<%= txtRefundAccNo.ClientID %>').val(val8);
                    $('#<%= txtIFSCCode.ClientID %>').val(val9);
                    $('#<%= txtBankName.ClientID %>').val(val10);
                    $('#<%= txtBranchName.ClientID %>').val(val11);

                 
                    $("#btnModalGridchange").click();
                }





                

                function isDecimalKey(evt) {
                    var charCode = (evt.which) ? evt.which : evt.keyCode
                    if (charCode != 46 && charCode > 31
                        && (charCode < 48 || charCode > 57)) {
                        return false;
                    } else {


                    }
                }




                function PrintElem() {

                    Popup($('#PrintDiv').html());
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



                $("#btnExport").click(function () {
                    window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#PrintDiv').html()));
                    e.preventDefault();

                });


</script>
</asp:Content>
