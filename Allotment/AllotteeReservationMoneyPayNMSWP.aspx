<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotteeReservationMoneyPayNMSWP.aspx.cs" Inherits="Allotment.AllotteeReservationMoneyPayNMSWP" %>

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
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
  
    
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    
        
    </script>

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
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            $(".chosen").chosen();
        }
    
        
    </script>
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
    <%-- <asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Always">
               

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
                                        
                                      <tr><td colspan="2">Note:- In case of NEFT/RTGS/Challan please wait for T+2 days for payment confirmation.Kindly pay challan in the HDFC bank for fast reconcillation</td></tr>
                                             
                                    </table>
   
         
        </div>
   
      </div>
      
    </div>
  </div>




          <%-- Modal Section Ends --%>




        <div class="container">
      <div class="row" id="SideDiv">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
           <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="BannerDiv">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-4 col-xs-12 left-niveshban">
                                                <ul class="mylogo-ul list-inline " style="margin: 0; padding: 6px 0 9px 155px;">
                                                    <li>
                                                        <img src="/images/logo-img/govt_up.png" alt="Goverment" /></li>
                                                    <li></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-6 col-sm-4 col-xs-12 text-center">
                                              
                                                <h2 id="chg_head">Nivesh Mitra</h2>
                                                <p><span style="font-size:20px;">Single Window Portal</span> ,Govt. of Uttar Pradesh</p>
                                            </div>
                                            <div class="col-md-3 col-sm-4 col-xs-12 right-niveshban">
                                                <ul class="mylogo-ul list-inline" style="margin: 0; padding: 6px 0 9px 1px;">
                                                    <li>
                                                        <img src="/images/logo-img/logo_udhyog_bandu_b.jpg" alt="Goverment" /></li>

                                                </ul>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> <div class="clearfix"></div>
                                     <div class="" style="border: 1px solid #cccccc; margin-bottom: 8px; background: #fdfdfd;" runat="server" id="Div3">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                                
                                                     <h3 id="H1">Uttar Pradesh State Industrial Development Authority</h3>
                                                  
                                            </div>
                                           
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> 
                                <div class="clearfix"></div>
                              <div class="panel-heading col-md-12 font-bold" style="font-size: 14px !important; font-weight: 600;"><div  class="col-md-6 col-sm-6 col-xs-6 text-left">उत्तर प्रदेश सरकार &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GOVERNMENT OF UTTAR PRADESH</div>
                                  <div class="col-md-6 col-sm-6 col-xs-6 text-right">
                      <asp:Button runat="server" ID="btn_backNmswp" Text="⇦ Go Back" CssClass="pull-right btn btn-info" OnClick ="btn_backNmswp_Click" Style="background-color:#02486d;color:#fff;font-weight:600;"   />
                    </div></div>
                                    <div class="clearfix"></div>
           
                        <div class="panel-heading text-center">Pay Your Reservation Money</div>
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
                                            <td>Plot Size</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPlotSize"></asp:Label>
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
                                            <th style="width:50%;" colspan="2">Reservation Money Details</th>
                                          
                                        </tr>
                                        <tr>
                                            <td style="width:50%;">Service Ref No</td>
                                            <td style="width:50%;"><asp:Label runat="server" ID="lblServiceRefNo"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Reservation Amount</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAmount"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>Reservation Money Due Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblReservationMoneyDueDate"></asp:Label>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td>Payment Status</td>
                                            <td>
                                                 <asp:Label runat="server" ID="lblPaymentStatus"></asp:Label>
                                                <asp:Label runat="server" ID="lblTransactionID" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                         
                                         <tr  runat="server" id="Tr1">
                                            <td>View Payment Details</td>
                                            <td>                                               
                                            <input type="button" class="btn-link"  value="Click Here" id="btnModalGridchange" data-toggle="modal" data-target="#ModalGridchange">
                                            </td>
                                        </tr>
                                       
                                        <tr  runat="server" id="Tr2">
                                            <td>Online Payment Details</td>
                                            <td>
                                                <input type="button" class="btn-link"  value="Click Here" id="btnModalGridchange1" data-toggle="modal" data-target="#ModalGridchange1" >
                                            </td>
                                        </tr>
                                   
                                         <tr runat="server" id="tr3">
                                            <td>Provisional Receipt</td>
                                            <td>
                                                <asp:button runat="server" ID="btnReceipt" Text ="Download" class="btn-link"  OnClick="btnReceipt_Click"/>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:5px;">                                    
                                        <asp:Button ID="btnPay" runat="server" Text="Submit" CssClass="btn-primary ey-bg pull-right" Width="" Style="margin:3px 0;background: #ffc71f;color: #000;" OnClick="btnPay_Click"  />                                   
                                    </div>
                                </div>
                            </div>


                        </div>
                        <asp:Label runat="server" ID="lblIndustrialArea" Visible="false"></asp:Label>
                 
                        <div class="clearfix"></div>
                        <hr class="separation" />
                   
                    </div>
                </div>
            </div>
        </div>
        </div>
        </div>

                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>


</body>

</html>
