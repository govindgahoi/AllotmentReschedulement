<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="ApplicationsCEOAppointment.aspx.cs" Inherits="Allotment.ApplicationsCEOAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Wizard.css" rel="stylesheet" />
    <style>

        .modal-backdrop {
    
    z-index: 0 !important;
  
}
.modal-backdrop.in {
    opacity: -0.5 !important;
    
}
          .ui-dialog .ui-dialog-titlebar-close span
          {
              color: black !important;
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
    function CallButtonEventReject() {

        //alert("click")
        document.getElementById("<%=btnReject1.ClientID %>").click();
    }
    function CallButtonEventApprove() {

        //alert("click")
        document.getElementById("<%=btnApprove1.ClientID %>").click();
     }

    function ShowRejectionModal() {
        alert("Please provide reason for rejection");
        $('#<%= txtApppID.ClientID %>').val('');
        $('#<%= txtApppID.ClientID %>').val(document.getElementById("<%=hfName.ClientID %>").value);
        $("#btnModalGridchange1").click();
    }
    function ShowApprovalModal(msg) {
        alert(msg);
        $('#<%= txtAppID.ClientID %>').val('');
         $('#<%= txtAppID.ClientID %>').val(document.getElementById("<%=hfName1.ClientID %>").value);
         $("#btnModalGridchange").click();
    }

    function ShowCompletionModal(msg) {
        alert(msg);
        $('#<%= txtAppppID.ClientID %>').val('');
        $('#<%= txtAppppID.ClientID %>').val(document.getElementById("<%=hfName2.ClientID %>").value);
        $("#btnModalGridchange2").click();
    }

    function ShowPopupChange(val,val1) {


        $('#<%= txtAppID.ClientID %>').val('');
        $('#<%= txtAppID.ClientID %>').val(val);
        document.getElementById("<%=hfName1.ClientID %>").value = "";
        document.getElementById("<%=hfName1.ClientID %>").value = val;
        $('#<%= txtAppName.ClientID %>').val('');
        $('#<%= txtAppName.ClientID %>').val(val1);
         $("#btnModalGridchange").click();
    }
    function ShowPopupChange2(val, val1) {


        $('#<%= txtAppppID.ClientID %>').val('');
        $('#<%= txtAppppID.ClientID %>').val(val);
        document.getElementById("<%=hfName2.ClientID %>").value = "";
        document.getElementById("<%=hfName2.ClientID %>").value = val;
        $('#<%= txtAppppName.ClientID %>').val('');
        $('#<%= txtAppppName.ClientID %>').val(val1);
        $("#btnModalGridchange2").click();
    }

    function ShowPopupChange3(val, val1,val2,val3,val4) {


        $('#<%= TextBox1.ClientID %>').val('');
        $('#<%= TextBox1.ClientID %>').val(val);
        $('#<%= TextBox2.ClientID %>').val('');
        $('#<%= TextBox2.ClientID %>').val(val1);
        $('#<%= TextBox3.ClientID %>').val('');
        $('#<%= TextBox3.ClientID %>').val(val2);
        $('#<%= TextBox4.ClientID %>').val('');
        $('#<%= TextBox4.ClientID %>').val(val3);
        $('#<%= txxtRemarks.ClientID %>').val('');
        $('#<%= txxtRemarks.ClientID %>').val(val4);
        $("#btnModalGridchange3").click();
    }

    function ShowPopupChange1(val,val1) {

        var label = document.getElementById("<%=lblRejAppID.ClientID %>");

        $('#<%= txtApppID.ClientID %>').val('');
        $('#<%= txtApppID.ClientID %>').val(val);
        document.getElementById("<%=hfName.ClientID %>").value = "";
        document.getElementById("<%=hfName.ClientID %>").value = val;
        $('#<%= txtApppName.ClientID %>').val('');
        $('#<%= txtApppName.ClientID %>').val(val1);
        $("#btnModalGridchange1").click();
    }

    $(document).ready(function () {
        $('[id*=Grid_Recieved]').prepend($("<thead></thead>").append($('[id*=Grid_Recieved]').find("tr:first"))).DataTable({
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


 
        $('[id*=Grid_Approved]').prepend($("<thead></thead>").append($('[id*=Grid_Approved]').find("tr:first"))).DataTable({
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


        $('[id*=Grid_Completed]').prepend($("<thead></thead>").append($('[id*=Grid_Completed]').find("tr:first"))).DataTable({
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

        $('[id*=Grid_Rejected]').prepend($("<thead></thead>").append($('[id*=Grid_Rejected]').find("tr:first"))).DataTable({
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
        <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
            <Triggers>
            <asp:PostBackTrigger ControlID="btnClose" />
        
        </Triggers>
            <ContentTemplate>
               

    <div class="modal fade" id="ModalGridchange" style="left:-522px !important;top:-28px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Appointment Approval"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    AppointmentID :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtAppID" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
             <asp:HiddenField ID = "hfName1" runat = "server" />
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointee Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtAppName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointment Date :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtAppDate" runat="server" CssClass="date form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointment Time :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtTime" runat="server" TextMode="Time" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Remarks :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="change_title1" /><asp:HiddenField  runat="server"  ID="change_id" /> <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Submit" OnClick="Button2_Click"   /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

    <div class="modal fade" id="ModalGridchange1" style="left:-522px !important;top:-190px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label1" Text="Appointment Rejection"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    AppointmentID :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtApppID" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" ReadOnly="true" ></asp:TextBox>
                    <asp:Label ID="lblRejAppID" runat="server" Visible="false"></asp:Label>
                    <asp:HiddenField ID = "hfName" runat = "server" />
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointee Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtApppName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Rejection Reason :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtRejReason" runat="server" TextMode="MultiLine" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            
           
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="HiddenField1" /><asp:HiddenField  runat="server"  ID="HiddenField2" /> <asp:Button ID="btnReject" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Reject" OnClick="btnReject_Click"   /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

   <div class="modal fade" id="ModalGridchange2" style="left:-522px !important;top:-190px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label2" Text="Appointment Completion"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    AppointmentID :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtAppppID" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" ReadOnly="true" ></asp:TextBox>
                   
                    <asp:HiddenField ID = "hfName2" runat = "server" />
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointee Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txtAppppName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
          
            
           
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
           <asp:HiddenField  runat="server"  ID="HiddenField4" /><asp:HiddenField  runat="server"  ID="HiddenField5" /> <asp:Button ID="btnClose" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Close Appointment" OnClick="btnClose_Click"   /> 
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>

                
    <div class="modal fade" id="ModalGridchange3" style="left:-522px !important;top:-220px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label3" Text="Appointment Details"/></h4>
        </div>
        <div class="modal-body">        
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    AppointmentID :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
             
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointee Name :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointment Date :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="date form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
            
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Appointment Time :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
             <div class="form-group">
                <label class="col-md-5 col-sm-6 col-xs-6">
                    Remarks :
                </label>
                <div class="col-md-7 col-sm-6 col-xs-6">
                    <asp:TextBox ID="txxtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                </div>
             </div>
             <div class="clearfix"></div>
            <hr class="myhrline" />
        </div>
        <div class="modal-footer">
            <div class="border-buttons pull-right">
            
          <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button></div>
        </div>
      </div>
      
    </div>
  </div>


     <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
     <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange1" data-toggle="modal" data-target="#ModalGridchange1" >
     <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange2" data-toggle="modal" data-target="#ModalGridchange2" >
    <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange3" data-toggle="modal" data-target="#ModalGridchange3" >
    
                </ContentTemplate>
		 </asp:UpdatePanel> 
    
    <asp:Button ID="btnReject1" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Reject" OnClick="btnReject1_Click" style="display:none;"  /> 
      <asp:Button ID="btnApprove1" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Reject" OnClick="btnApprove1_Click" style="display:none;"  /> 
  
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
								CssClass="ist-inline iadsashboard-dayul-inbox"
								StaticSelectedStyle-CssClass="sub_menu_active"
								
								runat="server">
               
                
							</asp:Menu>
        </div>

          <asp:MultiView runat="server" ID="ApplicationView">

              <asp:View runat="server" ID="Received">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="Grid_Recieved" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                            ClientIDMode="Static"
                           
                            AutoGenerateColumns="False"
                            DataKeyNames="ID,Doc,Name"
                            GridLines="Horizontal"  OnRowDataBound="GridView2_RowDataBound" OnRowCommand="Grid_Recieved_RowCommand"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  
                                                    <asp:BoundField DataField="ID"           HeaderText="Appointment ID" ItemStyle-Width="100"  ItemStyle-Wrap="False"  />
                                                    <asp:BoundField DataField="Name"         HeaderText="Name"            />
                                                    <asp:BoundField DataField="Address"      HeaderText="Address"         />
                                                    <asp:BoundField DataField="EmailID"      HeaderText="Email ID"        />
                                                    <asp:BoundField DataField="PhoneNo"      HeaderText="Phone No"        />                                                   
                                                    <asp:BoundField DataField="Purpose"      HeaderText="Purpose"         />
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District"        />
                                                    <asp:BoundField DataField="IAName"       HeaderText="Industrial Area" />
                                                 
                                 <asp:TemplateField HeaderText="Document" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"   ToolTip="DownloadAttached Document" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                           
                              <asp:BoundField DataField="Approve"       HeaderText="Approval" />
                                <asp:BoundField DataField="Reject"       HeaderText="Rejection" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                           
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

              <asp:View runat="server" ID="Approved">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="Grid_Approved" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                            ClientIDMode="Static"
                           
                            AutoGenerateColumns="False"
                            DataKeyNames="ID,Doc,Name"
                            GridLines="Horizontal"  OnRowDataBound="Grid_Approved_RowDataBound" OnRowCommand="Grid_Approved_RowCommand"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  
                                                    <asp:BoundField DataField="ID"           HeaderText="Appointment ID" ItemStyle-Width="100"  ItemStyle-Wrap="False"  />
                                                    <asp:BoundField DataField="Name"         HeaderText="Name"            />
                                                    <asp:BoundField DataField="Address"      HeaderText="Address"         />
                                                    <asp:BoundField DataField="EmailID"      HeaderText="Email ID"        />
                                                    <asp:BoundField DataField="PhoneNo"      HeaderText="Phone No"        />                                                   
                                                    <asp:BoundField DataField="Purpose"      HeaderText="Purpose"         />
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District"        />
                                                    <asp:BoundField DataField="IAName"       HeaderText="Industrial Area" />
                                                 
                                 <asp:TemplateField HeaderText="Document" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"   ToolTip="DownloadAttached Document" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovedOn"       HeaderText="Approved On" />
                           
                              <asp:BoundField DataField="Close"       HeaderText="Close Appointment" />
                             
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                           
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

              <asp:View runat="server" ID="Completed">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="Grid_Completed" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                            ClientIDMode="Static"
                           
                            AutoGenerateColumns="False"
                            DataKeyNames="ID,Doc,Name"
                            GridLines="Horizontal"  OnRowDataBound="Grid_Completed_RowDataBound" OnRowCommand="Grid_Completed_RowCommand"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                                                   <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  
                                                    <asp:BoundField DataField="ID"           HeaderText="Appointment ID"  />
                                                    <asp:BoundField DataField="Name"         HeaderText="Name"            />
                                                    <asp:BoundField DataField="Address"      HeaderText="Address"         />
                                                    <asp:BoundField DataField="EmailID"      HeaderText="Email ID"        />
                                                    <asp:BoundField DataField="PhoneNo"      HeaderText="Phone No"        />                                                   
                                                    <asp:BoundField DataField="Purpose"      HeaderText="Purpose"         />
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District"        />
                                                    <asp:BoundField DataField="IAName"       HeaderText="Industrial Area" />
                                                    <asp:BoundField DataField="RequestDate"       HeaderText="Request Date" />
                                                 
                                 <asp:TemplateField HeaderText="Document" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"  ToolTip="Download Attached Document" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />                                             
                                        </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:BoundField DataField="ApprovedOnn"       HeaderText="Approved On" />
                               <asp:BoundField DataField="CompletedOnn"       HeaderText="Completed On" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                           
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

              <asp:View runat="server" ID="Rejected">
                    <div style="overflow-x: auto; overflow-y: auto; max-height: 390px;">
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:GridView ID="Grid_Rejected" runat="server"
                            CssClass="table table-striped table-bordered table-hover request-table myreq-col"
                            ClientIDMode="Static"
                           
                            AutoGenerateColumns="False"
                            DataKeyNames="ID,Doc,Name"
                            GridLines="Horizontal"  OnRowDataBound="Grid_Rejected_RowDataBound" OnRowCommand="Grid_Rejected_RowCommand"
                            Width="100%"
                            ItemStyle-Width="10%">
                            <Columns>
                              <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  
                                                    <asp:BoundField DataField="ID"           HeaderText="Appointment ID" ItemStyle-Width="100"  ItemStyle-Wrap="False"  />
                                                    <asp:BoundField DataField="Name"         HeaderText="Name"            />
                                                    <asp:BoundField DataField="Address"      HeaderText="Address"         />
                                                    <asp:BoundField DataField="EmailID"      HeaderText="Email ID"        />
                                                    <asp:BoundField DataField="PhoneNo"      HeaderText="Phone No"        />                                                   
                                                    <asp:BoundField DataField="Purpose"      HeaderText="Purpose"         />
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District"        />
                                                    <asp:BoundField DataField="IAName"       HeaderText="Industrial Area" />
                                                    <asp:BoundField DataField="RequestDate"       HeaderText="Request Date" />
                                                 
                                 <asp:TemplateField HeaderText="Document" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="text-center-imp">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDownload"   ToolTip="DownloadAttached Document" Text='<i class="fa fa-download" aria-hidden="true"></i>'  CommandName="Download" CausesValidation="false" CommandArgument='<%# (Container.DataItemIndex) %>' />                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              <asp:BoundField DataField="RejectedOnn"       HeaderText="Rejected On" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                           
                        </asp:GridView>


                    </div>

                </div>
                <div class="clearfix"></div>

                  

              </asp:View>

             

              </asp:MultiView>
    </div>
    <div class="clearfix"></div>

                       
        

</asp:Content>
