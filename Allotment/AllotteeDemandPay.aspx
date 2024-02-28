<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteeDemandPay.aspx.cs" Inherits="Allotment.AllotteeDemandPay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
 
    <script src="assets/js/bootstrap.min.js"></script>

    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <style type="text/css">
        .form-group label{
            margin-bottom:0;
        }
        .form-group input[type='radio'] {
            margin-right:3px;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }

        #UpdateProgress1 {
            position: fixed;
            width: 100%;
            height: 100%;
            z-index: 99999;
            background: rgba(0,0,0,0.21176470588235294);
        }

            #UpdateProgress1 .fgh {
                position: absolute;
                top: 45%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }
                   h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

          @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange1 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }


           @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 11%;
            }
            #ModalGridchange2 .modal-dialog{
                top:10% !important;
                left:14% !important;
            }
        }

        .modal-header {
            padding: 2px !important;
        }
     
    </style>
        <script  type="text/javascript">

             function AlertRedirectPaymentDemand(parameter1, parameter2) {

            alert('Your URN No Updated Successfully.');
            window.location.href = 'DemadPaymentAck.aspx?ServiceReqNo=' + parameter1 + '&TraID=' + parameter2;

        }

            function ShowPopup(msg) {

                alert(msg);
                $("#btnModalGridchange2").click();
            }

</script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
  <%--     <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
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
     <div class="modal fade" id="ModalGridchange" style="left:-522px !important;top:-28px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="change_title" Text="Payment Details Head Wise"/></h4>
        </div>
        <div class="modal-body">    
             <asp:GridView ID="GridPayment" runat="server"
                    CssClass="table table-striped table-bordered table-hover request-table request-table myreq-col" AllowSorting="True"
                    AutoGenerateColumns="false" GridLines="Horizontal"  ShowFooter="true"
                    Width="100%" >
                    <Columns>
                          <asp:TemplateField HeaderText="SNO" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                         <asp:BoundField DataField="PayDesc" HeaderText="Description" SortExpression="PayDesc" />
                        <asp:BoundField DataField="Amount"  HeaderText="Amount" SortExpression="Amount" />
                       
                        </Columns>
                 </asp:GridView>
         
        </div>
   
      </div>
      
    </div>
  </div>



          <div class="modal fade" id="ModalGridchange1" style="left:-522px !important;top:-28px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label1" Text="Online Transaction Details"/></h4>
        </div>
        <div class="modal-body">    
            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                        <tr>
                                            <th style="width:50%;" colspan="2">Your Details With Us</th>
                                          
                                        </tr>
                                         <tr>
                                            <td>Transaction Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblTransactionDate"></asp:Label>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Transaction Ref No</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblTransactionRefNo"></asp:Label>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Transaction Amount</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblTransactionAmount"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:50%;">Payment Mode</td>
                                            <td style="width:50%;"><asp:Label runat="server" ID="LblPaymentMode"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td style="width:50%;">Payment Status</td>
                                            <td style="width:50%;"><asp:Label runat="server" ID="lblStatus"></asp:Label></td>
                                        </tr>
                                        
                                      <tr><td colspan="2">Note:- In case of NEFT/RTGS/Challan please update UTR Number for the payment confirmation</td></tr>
                                      
                                     
                                       
                                    </table>
   
         
        </div>
   
      </div>
      
    </div>
  </div>



           <div class="modal fade" id="ModalGridchange2" style="left:-522px !important;top:-28px !important;" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><asp:Label runat="server" ID="Label2" Text="UTR Number Updation"/></h4>
        </div>
        <div class="modal-body">    
            <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                        <tr>
                                            <th style="width:50%;" colspan="2">Update UTR No</th>
                                          
                                        </tr>
                                         <tr>
                                            <td>UTR NO</td>
                                            <td>
                                               <asp:TextBox runat="server" ID="txtUTRNo" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Bank Name</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtBankName" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Payment Date</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPaymentDate" placeholder="dd/mm/yyyy" CssClass="margin-left-z input-sm similar-select1"></asp:TextBox>
                                            </td>
                                        </tr>

                <tr runat="server" id="tr4">
                                            <td>Provisional Receipt</td>
                                            <td>
                                                <asp:button runat="server" ID="btnReceipt" Text ="Click Here" class="btn-link"  OnClick="btnReceipt_Click"/>
                                            </td>
                                        </tr>
                                        
                                        
                                      <tr><td colspan="2"> <asp:Button Style="margin:5px;" runat="server" ID="btnUpdateURN" Text="Update" CssClass="btn btn-sm btn-primary pull-right" OnClick="btnUpdateURN_Click"/></td></tr>
                                      
                                     
                                       
                                    </table>
   
         
        </div>
   
      </div>
      
    </div>
  </div>


          <%-- Modal Section Ends --%>




        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="main_menu" runat="server"><% Response.WriteFile("top_mainmenu.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-center">Pay Your Demand</div>
                        <hr class="separation" />
                        <div class="form-group" style="background: #dedede;padding: 2px 0;border: 1px solid #ccc;">
                            <label class="col-md-2">
                                Search Record:
                            </label>
                            <div class="col-md-10">
                                <asp:RadioButton Text=" By Plot No" runat="server" ID="radioByPlotNo" GroupName="radio" OnCheckedChanged="radioByPlotNo_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton Text=" By Allotment No" GroupName="radio" runat="server" ID="radioByAllotmentNo" OnCheckedChanged="radioByAllotmentNo_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div runat="server" id="DivFilterIA" visible="false">
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                        <div class="form-group">
                            <label class="col-md-2 text-right">
                                Industrial Area:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpIndusrialArea" CssClass="input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpIndusrialArea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <label class="col-md-2  text-right">
                                Plot No:
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="drpPlotNo" CssClass="input-sm similar-select1 margin-left-z" OnSelectedIndexChanged="drpPlotNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>    
                            </div>
                        </div>
                           
                        <div class="clearfix"></div>
                        <hr class="myhrline" />
                             </div>
                            <div runat="server" id="DivFilterLetter" visible="false">
                        <div class="form-group">
                            <label class="col-md-4 text-right">
                                Enter Your Allotment Letter Number:
                            </label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtServiceReqNo" runat="server" CssClass="input-sm similar-select1" OnTextChanged="txtServiceReqNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div></div>
                        <hr class="separation" />

                        <div class="col-md-6 col-sm-12 col-xs-12" style="" runat="server" id="Div1" visible="false">
                            <div class="row" style="border: 15px solid #ccc;">
                                <div class="col-md-12 col-sm-6 col-xs-12" style="border-right: 4px solid #ccc;padding: 0px !important;">
                                
                                    <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                        <tr>
                                            <th style="width:50%;" colspan="2">Your Details With Us</th>
                                          
                                        </tr>
                                         <tr>
                                            <td>Plot No</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPlotNo"></asp:Label>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Allotment Letter No</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLetterNo"></asp:Label>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>Allotment Date </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAllotmentDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:50%;">Allottee Name</td>
                                            <td style="width:50%;"><asp:Label runat="server" ID="lblAllotteeName"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Company Name</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>Product Manufactured</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblProduct"></asp:Label>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td>Address</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Phone No</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPhoneNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Email ID</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                            </td>
                                        </tr>
                                       
                                    </table>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12" runat="server" id="div2" visible="false">
                             <div class="row" style="border: 15px solid #ccc;">
                                <div class="col-md-12 col-sm-6 col-xs-12" style="border-right: 4px solid #ccc;padding: 0px !important;">
                                
                                    <table class="table table-striped table-responsive table-bordered table-hover request-table">
                                         <tr>
                                            <th style="width:50%;" colspan="2">Demand Note</th>
                                          
                                        </tr>
                                        <tr>
                                            <td style="width:50%;">Demand Ref No</td>
                                            <td style="width:50%;"><asp:Label runat="server" ID="lblDemandNo"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Due Amount</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAmount"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>Demand Note Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDemandDate"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>Demand Note Due Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDueDate"></asp:Label>
                                                 <asp:Label runat="server" ID="lblDemandID" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>View Payment Details</td>
                                            <td>
                                                
                                            <input type="button" class="btn-link"  value="Click Here" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange" >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>View Demand Note</td>
                                            <td>
                                                <asp:button runat="server" ID="btnViewDemandNote" Text ="Click Here" class="btn-link"  OnClick="Button1_Click"/>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="Tr1">
                                            <td>Payment Status</td>
                                            <td>
                                                 <asp:Label runat="server" ID="lblPaymentStatus"></asp:Label>
                                                <asp:Label runat="server" ID="lblTransactionID" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr  runat="server" id="Tr2">
                                            <td>Online Payment Details</td>
                                            <td>
                                                <input type="button" class="btn-link"  value="Click Here" id="btnModalGridchange1" data-toggle="modal" data-target="#ModalGridchange1" >
                                            </td>
                                        </tr>

                                        <tr  runat="server" id="Tr3">
                                            <td>Update UTR No</td>
                                            <td>
                                                <input type="button" class="btn-link"  value="Click Here" id="btnModalGridchange2" data-toggle="modal" data-target="#ModalGridchange2" >
                                            </td>
                                        </tr>
                                       

                                    </table>
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:5px;">                                    
                                        <asp:Button ID="btnPay" runat="server" Text="Pay Now" CssClass="btn-primary ey-bg pull-right" Width="" Style="margin:3px 0;background: #ffc71f;color: #000;" OnClick="btnPay_Click"  />                                   
                                    </div>
                                </div>
                            </div>


                        </div>

                 
                        <div class="clearfix"></div>
                        <hr class="separation" />
                   
                    </div>
                </div>
            </div>
        </div>
     <%--             </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>


</body>

</html>
