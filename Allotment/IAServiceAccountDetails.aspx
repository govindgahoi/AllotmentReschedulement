<%@ Page Title="" Language="C#" MasterPageFile="~/MainUser.Master" AutoEventWireup="true" CodeBehind="IAServiceAccountDetails.aspx.cs" Inherits="Allotment.IAServiceAccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
          
          .request-table tr th
          {
              white-space:nowrap;
              }
              .request-table tr td
          {
              white-space:nowrap;
              }
          .request-table tr table tr th{
            background:#c5c5c5 !important;
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
            .request-table tr td {
                padding: 0px 4px !important;
            }


                 .fgh{position:fixed;height:100%;width:100%;top:0}.hgf{z-index:1000;margin:300px auto;padding:10px;width:75px;background-color:White;border-radius:10px;filter:alpha(opacity=100);opacity:1;-moz-opacity:1}
 
        .ui-dialog .ui-dialog-titlebar {
    padding: .4em 1em;
    position: relative;
    background: #D8D8D8 !important;
    border-color: #D8D8D8 !important;
}

        .ui-dialog .ui-dialog-title {
    font-family: serif !important;
    color: black;
}


        .ui-dialog .ui-dialog-buttonpane button {
          
    background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#4c5568), to(#414959)) !important;
    border: 1px solid #fff !important;
    font-weight: normal !important;
     padding: 5px 10px !important;
    font-size: 12px !important;
    line-height: 1.5 !important;
    color: #fff !important;

  
}
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
          .input-search1
          {
              width:90%;
          }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
                <ProgressTemplate>
                    <div class="fgh">
                        <div class="hgf">
                            <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row">
                <div class="panel panel-default">
                    <div class="text-center my-new-heading" style="margin-bottom: 2px;"></div>
                    <%-- Modal Section Start --%>
                    <div class="modal fade" id="ModalGridchange" style="left: -522px !important; top: -28px !important;" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label runat="server" ID="change_title" Text="Account Clearance" /></h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Service Request No :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="change_text" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Transaction Ref No :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtTransaction" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
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
                                            Received Amount :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtReceivedAmt" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" onkeypress="return isDecimalKey(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Received Date :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                </div>
                                <div class="modal-footer">
                                    <div class="border-buttons pull-right">
                                        <asp:HiddenField runat="server" ID="change_title1" />
                                        <asp:HiddenField runat="server" ID="change_id" />
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm btn-primary btn-popup" Text="Submit" OnClick="Button2_Click" />
                                        <button type="button" class="btn btn-primary btn-popup" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="modal fade" id="ModalChallan" style="left: -522px !important; top: -28px !important;" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label runat="server" ID="Label1" Text="NEFT/RTGS Challan Details" /></h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Service Request No :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtReqNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Transaction Ref No :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtRefNo" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Applicant Name:
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtApplicantName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            URN Number :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtURNNumber" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Payment Date :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtPaymentDate" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                    <div class="form-group">
                                        <label class="col-md-5 col-sm-6 col-xs-6">
                                            Bank Name :
                                        </label>
                                        <div class="col-md-7 col-sm-6 col-xs-6">
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control input-sm similar-select1 margin-left-z"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr class="myhrline" />
                                </div>

                            </div>

                        </div>
                    </div>




                    <%-- Modal Section End --%>



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
                                <asp:DropDownList runat="server" ID="drpdwnIA" Style="background: #fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="drpdwnIA_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <label class="col-md-2 col-sm-1 col-xs-12">
                                Payment Mode :
                            </label>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <asp:DropDownList runat="server" ID="ddlPayMode" Style="background: #fff;" CssClass="input-sm similar-select1" AutoPostBack="true" OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged">
                                    <asp:ListItem Value="All">--All--</asp:ListItem>
                                    <asp:ListItem Value="HDFC">HDFC</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <label class="col-md-2 col-sm-2 col-xs-12">
                                Transaction From Date :
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
                                Search Keyword :
                            </label>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <asp:TextBox runat="server" ID="txtSearch" Style="background: #fff;" CssClass="input-sm similar-select1"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <hr class="myhrline" />
                            <div class="col-md-12 col-sm-2 col-xs-12">
                                <asp:Button ID="btnFetch" runat="server" Text="Fetch" Style="padding: 2px 27px; margin: 10px 0;" CssClass="btn-primary ey-bg pull-right" OnClick="btnFetch_Click" />
                            </div>

                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="separation" />
                    <div class="panel-heading">IA Service Application Details</div>
                    <asp:HiddenField ID="hfCurrentRowIndex" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hfParentContainer" runat="server"></asp:HiddenField>
                    <div class="table-responsive" style="overflow-y: auto; max-height: 400px;">
                         <input type="button" value="Click Me" style="display:none;" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
                     <input type="button" value="Click Me" style="display:none;" id="btnModalChallan" data-toggle="modal" data-target="#ModalChallan" >
                        <asp:GridView ID="ApplicationGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="ServiceRequestNO" CssClass="table table-striped table-bordered table-hover request-table" OnRowDataBound="ApplicationGrid_RowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request NO" SortExpression="ServiceRequestNO" />
                                <asp:BoundField DataField="ServiceName" HeaderText="Service Name" SortExpression="ServiceName" />
                                <asp:BoundField DataField="RegionalOffice" HeaderText="RegionalOffice" SortExpression="RegionalOffice" />
                                
                                <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                                <asp:BoundField DataField="AllotteeName" HeaderText="Applicant Name" SortExpression="AllotteeName" />
                                <asp:BoundField DataField="Allotmentletterno" HeaderText="Allotment letter No" SortExpression="Allotmentletterno" />
                                <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" SortExpression="PaymentMode" />
                                <asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="TransactionAmount" />
                                <asp:BoundField DataField="TransactionRefNo" HeaderText="Transaction Ref No" SortExpression="TransactionRefNo" />
                                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <div class="clearfix"></div>
                    <hr class="separation" />
                    <div class="clearfix"></div>
                    <hr class="separation" />
                    <div class="panel-heading">
                        Cleared By You
                <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElem()" style="cursor: pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    <li>
                        <a href="#" id="btnExport">
                            <i style="font-size: 18px;" class="fa fa-file-excel-o fa-fw"></i>
                        </a>
                    </li>
                </ul>
                    </div>
                    <div class="table-responsive" id="PrintDiv" style="overflow-y: auto; max-height: 400px;">
                        <asp:GridView ID="ApplicationCleared" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover request-table">
                            <Columns>


                                <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ServiceRequestNO" HeaderText="Service Request NO" SortExpression="ServiceRequestNO" />
                                <asp:BoundField DataField="ServiceName" HeaderText="Service Name" SortExpression="ServiceName" />
                                <asp:BoundField DataField="RegionalOffice" HeaderText="RegionalOffice" SortExpression="RegionalOffice" />
                                <asp:BoundField DataField="IAName" HeaderText="IA Name" SortExpression="IAName" />
                                <asp:BoundField DataField="AllotteeName" HeaderText="Applicant Name" SortExpression="AllotteeName" />
                                <asp:BoundField DataField="Allotmentletterno" HeaderText="Allotment letter No" SortExpression="Allotmentletterno" />
                                <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" SortExpression="PaymentMode" />
                                <asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="TransactionAmount" />
                                <asp:BoundField DataField="TransactionRefNo" HeaderText="Transaction Ref No" SortExpression="TransactionRefNo" />
                                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                                <asp:BoundField DataField="ReceiverPostConfirmAmount" HeaderText="Confirm Amount" SortExpression="TransactionDate" />
                                <asp:BoundField DataField="ReceiverPoatConfirmDate" HeaderText="Confirm Date" SortExpression="TransactionDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

         function ShowPopupChange(val, val1, val2, val3) {


                    $('#<%= txtReceivedAmt.ClientID %>').val('');
                    $('#<%= txtReceivedDate.ClientID %>').val('');
                    $('#<%= txtTransaction.ClientID %>').val(val);
                    $('#<%= txtApplicant.ClientID %>').val(val3);

                    $('#<%= change_title.ClientID %>').text(val1);
                    $('#<%= change_title1.ClientID %>').val(val1);

                    $('#<%= change_text.ClientID %>').val(val2);
                    $("#btnModalGridchange").click();
                }


                function ShowPopupChallan(val, val1, val2, val3) {


                  
                    $('#<%= txtRefNo.ClientID %>').val(val);
                    $('#<%= txtApplicantName.ClientID %>').val(val1);
                    $('#<%= txtReqNo.ClientID %>').text(val2);
                    $('#<%= txtURNNumber.ClientID %>').val(val3);
                 
                    $("#btnModalChallan").click();
                  }



        var prevRowIndex;
        function ChangeRowColor(row, rowIndex) {
            var parent = document.getElementById(row);
            var currentRowIndex = parseInt(rowIndex) + 1;

            if (prevRowIndex == currentRowIndex) {
                return;
            }
            else if (prevRowIndex != null) {
                parent.rows[prevRowIndex].style.backgroundColor = "#FFFFFF";
            }

            parent.rows[currentRowIndex].style.backgroundColor = "#FFFFD6";
            prevRowIndex = currentRowIndex;



            $('#<%= hfParentContainer.ClientID %>').val(row);
            $('#<%= hfCurrentRowIndex.ClientID %>').val(rowIndex);
        }

        $(function () {
            RetainSelectedRow();
        });

        function RetainSelectedRow() {
            var parent = $('#<%= hfParentContainer.ClientID %>').val();
            var currentIndex = $('#<%= hfCurrentRowIndex.ClientID %>').val();
            if (parent != null) {
                ChangeRowColor(parent, currentIndex);
            }
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
