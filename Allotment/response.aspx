<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="response.aspx.cs" Inherits="Allotment.PaymentResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Page-Enter" content="Alpha(opacity=100)" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/font-awesome.min.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.3.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <link href="/css/CssManu.css" rel="stylesheet" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Footer.css" rel="stylesheet" />
    <style>
        /**/
        * {
            box-sizing: border-box;
        }

        .mySlides {
            display: none;
        }

        /* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
        }

        /* Caption text */

        .active {
            background-color: #717171;
        }

        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .text {
                font-size: 11px;
            }
        }
    </style>

     <script type="text/javascript">     
         function redirect(msg,msg1) {
            
             window.location.href = 'LandAllotmentApplication.aspx?ServiceReqNo=' + msg + '&Status=F&TranID=' + msg1;


         }
         function redirectC(msg, msg1) {


             alert("After the successFull payment against this challan.Please Update UTR No against your application for final submission")

             //window.location.href = 'LandAllotmentApplication.aspx?ServiceReqNo=' + msg + '&Status=C&TranID=' + msg1;


         }

          function redirectDemand(msg,msg1) {
            
             window.location.href = 'DemadPaymentAck.aspx?ServiceReqNo=' + msg + '&TraID=' + msg1;


         }
</script>
</head>
<body id="pagewrap">


    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="index.html" class="navbar-brand">
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
                <div class="col-md-12">


                    <div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">

                            <div class="row well well-large offset4">
                                <div class="col-md-12 well well-large offset4">
                                    <div class="main-container ace-save-state" id="main-container">
                                        <div class="main-content">
                                            <div class="main-content-inner">
                                                <div class="page-content">



                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <div id="DivP" style="padding: 15px 25px; margin: 25px 10%; background: #fbfbfb; border: 1px solid #ccc;">
                                                            <div class="watermark"></div>
                                                            <div class="div-report" runat="server" style="">
                                                                <div class="text-center" style="text-align:center;">
                                                                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;" /><br>
                                                                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
                                                                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br />
                                                                    <br />
                                                                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>
                                                                </div>
                                                                <!--<asp:PlaceHolder ID="ph" runat="server" />-->
                                                                <asp:Label ID="lt" runat="server"></asp:Label>

                                                                <%--  <div class="payment-success"><i class="fa fa-check-square-o" aria-hidden="true"></i> <span>Payment Successful</span></div>--%>
                                                                <!--<div class="payment-fail"><i class="fa fa-times-circle-o" aria-hidden="true"></i> <span>Transaction Failed</span></div>-->
                                                                <hr class="payment-hr" />
                                                                <div class="payment-details-if" style="border: 1px solid #ccc !important;padding:5px;">
                                                                    <table style="width: 100%;margin-bottom:0;" class="table table-bordered table-hover">

                                                                       
                                                                        <tr class="active">
                                                                            <td><span class="detail-left">UPSIDC Refrence No</span q></td>
                                                                            <td><span class="detail-right pull-right">
                                                                                <asp:Label ID="UPSIDCRefrence" runat="server"></asp:Label></span></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 40%"><span class="detail-left">Transaction Amount</span></td>
                                                                            <td style="width: 60%"><span class="detail-right pull-right">
                                                                                <asp:Label ID="lblAmmount" runat="server"></asp:Label></span></td>
                                                                        </tr>

                                                                        <tr class="active">
                                                                            <td><span class="detail-left">Transaction Date</span></td>
                                                                            <td><span class="detail-right pull-right">
                                                                                <asp:Label ID="tranjectionDate" runat="server"></asp:Label></span></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><span class="detail-left">Bank Transaction No</span></td>
                                                                            <td><span class="detail-right pull-right">
                                                                                <asp:Label ID="banktransactionNo" runat="server"></asp:Label></span></td>
                                                                        </tr>
                                                                        <tr class="active">
                                                                            <td><span class="detail-left">Pay Status</span></td>
                                                                            <td><span class="detail-right pull-right">
                                                                                <asp:Label ID="lblPayStatus" runat="server"></asp:Label></span></td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td><span class="detail-left">Payment Mode</span></td>
                                                                            <td><span class="detail-right pull-right">
                                                                                <asp:Label ID="lblPaymode" runat="server"></asp:Label></span></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="" style="padding: 5px;border: 1px solid #ccc;margin-top: 15px;background: #efefef;text-align: justify;">
                                                                    <strong>Note:</strong> Please note the payment is subject to the clearance of bank to UPSIDC. Account that have received the payment status as above by bank as of now. You can take the print out of this page and please refer the above ref. no. & Transaction date for any further communication.
                                                                </div>
                                                                

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Label runat="server" ID="lblServiceReqNo" Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblServiceID"    Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblResponseCode" Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblUPSIDCTran"   Visible="false"></asp:Label>

                                                <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" Enabled="false"  />



                                                <asp:Label ID="msg" runat="server" />


                                                <div class="row">
                                                    <div class="col-md-2"></div>
                                                    <div class="col-md-8">
                                                        <div class="panel panel-default">

                                                            <%-- 
            payment-success
            payment-fail
                                                            --%>




                                                            
                                                            <%-- <p class="text-center payment-confirm message">We will Send Acknolgement Of Reciving Payment.</p>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2"></div>
                                                </div>



                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- PAGE CONTENT ENDS -->
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->
                                        </div>
                                        <!-- /.page-content -->
                                    </div>
                                </div>
                                <!-- /.main-content -->

                            </div>
                        </div>
                    </div>
                </div>
                <div id="footer_id" runat="server"><% Response.WriteFile("public_footer.aspx"); %> </div>
            </div>


        </div>



        </div>
    </form>
    <!-- inline scripts related to this page -->

</body>
</html>
