<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemadPaymentAck.aspx.cs" Inherits="Allotment.DemadPaymentAck" %>
<%@ Register Src="~/UC_DemandPayAck.ascx" TagPrefix="uc1" TagName="UC_DemandPayAck" %>


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

        .modal-header {
            padding: 2px !important;
        }
     
    </style>
        <script  type="text/javascript">
            function ShowPopup() {

                //alert("Helloo");
                $("#btnModalGridchange").click();
            }

</script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>


     




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
                 <div class="" style="padding: 4px 9px 33px 0;background: #e0e0e0;border: 1px solid #ccc;display: block;"><span><i class="fa fa-print pull-right" style="font-size: 20px;border: 1px solid #8e8e8e;padding: 3px;background: #ccc;" onclick="PrintElem()"></i></span></div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                   <div id="FinalPrint">
                      <asp:PlaceHolder ID="PH" runat="server"></asp:PlaceHolder>
                   </div>
                </div>
            </div>
        </div>
</form>     
    <script>
           function PrintElem() {

                Popup($('#FinalPrint').html());
            }


            function Popup(data) {
                var mywindow = window.open('', 'my div', 'height=2000,width=1000');
                mywindow.document.write('<html><head><title style="font-weight:bold;">Payment Acknowledgement</title>');
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

</body>

</html>
