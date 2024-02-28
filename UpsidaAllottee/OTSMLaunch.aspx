<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTSMLaunch.aspx.cs" Inherits="UpsidaAllottee.OTSMLaunch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet"/>
    
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />

  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <%--<script src="js/chosen.jquery.min.js"></script>--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <style>
        .sweet-alert p {
            color: darkblue !important;
            font-size: 15px;
            text-align: center;
            font-weight: 600;
            position: relative;
            text-align: inherit;
            float: none;
            margin: 0;
            padding: 0;
            line-height: normal;
        }
        .launch{
            color:darkblue;
        }
        hr{
            border-color:antiquewhite;
            width:250px
        }
        .mainnavbar {
            height: 38px !important;
        }
        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 .col-sm-6  {
                width: 50% !important;
            }
        }
        #SideDiv {
            margin-left: 0px;
        }

        Label {
            font-weight: 500;
        }
       
        .maintenacecharge {
            margin-top: 10px;
            font-size:14px !important;
        }

        .txtRed {
            color: red;
        }

        #lblTotalDues {
            color: red;
        }

        #lblInterest {
            color: red;
        }

        .txtgreen {
            color: green;
        }

        ContentTemplate {
            padding-bottom: 30px;
        }
        .payableAmount{
            padding-top:30px;
            /*visibility:hidden;*/
            display:none;
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
                top: 40%;
                margin: 0px auto;
                left: 45%;
                z-index: 999;
            }
            .ui-menu-item{
                font-size:12px!important;
                background:#fff9e7!important;
                font-family:inherit!important;
                color:#555!important;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container" style="text-align:center" >
                            <asp:Panel runat="server" ID="launch">
                            <div style="text-align: center">
                                <img class="image-responsive" src="https://www.onlineupsidc.com/OfcUser_pdf/upsida-logo-name.png" />
                            </div>
                            <hr />
                               
                            <div style="font-size:28px;font-style: italic;color:darkblue;">
                               <%-- <p style="font-family:'Times New Roman'">Launch of One Time</p>
                                <p style="font-family:'Times New Roman'">Settlement (OTS) Scheme for Maintenance Dues</p>
                                <p style="font-family:'Times New Roman'"> by UPSIDA</p>
                                <p style="font-family:'Times New Roman'">CEO Shri Mayur Maheshwari</p>--%>
                            </div>
                            <hr />
                            <p style="font-family:'Times New Roman';font-size:22px;color:darkblue;"> Date : 20<sup>th</sup> April, 2022</p>
                                <p style="font-family:'Times New Roman';font-size:22px;color:darkblue;">Time : 12:00 P.M.</p>
                            <div >
                                <%--<asp:ImageButton ID="ImageButton1" CssClass="ImageButton1"  runat="server" src="./images/launch.png" href="http://localhost:49691/OTSMLaunch.aspx" OnClick="launch_click" style="width:200px" />--%>
                                <%--<asp:img runat="server" class="image-responsive" src="./images/launch.png" />--%>
                                <%--<asp:Button ID="btnLaunch" CssClass="btn btn-success" runat="server" Text="LAUNCH OTS SCHEME" />--%>
                                <a href="http://localhost:49691/webform1.aspx">
                                        <img class="image-responsive" src="./images/launch.png" alt="HTML tutorial" >
                                </a>
                                
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            </asp:Panel>
                        </div>

                          <script type="text/javascript">
            showSwal1 = function (type) {
                'use strict';
                if (type != null || type != '') {
                    

                    swal({
                        title: 'OTS Scheme Launched!',
                        text: 'OTS Scheme is now launched by CEO - Shri Mayur Maheshwari.',
                        type: 'success',
                        showConfirmButton: true,
                        confirmButtonColor: '#ec008c',

                        padding: '3em',
                        timer: 10000,
                        background: '#fff url(bg.jpg)',
                        backdrop: 'rgba(0,0,123,0.4) center left no-repeat',

                        button: {
                            text: "Continue",
                            value: true,
                            visible: true,
                            className: "btn btn-primary"
                        }
                    }, function () {
                        window.location.href = 'AllotteePayMaintenance.aspx';
                    })

                } else {
                    swal("Error occured !");
                }
            }
        </script>
         <script>
            $(".confirm").on('click', function () {
                window.location.href = "allotteePayMaintenance.aspx";
            });
        </script>
      <%--<script type="text/javascript">
          $('#<%=ImageButton1.ClientID%>').click(function () {
              debugger;
              setInterval(function () { document.location.href = "allotteePayMaintenance.aspx"; }, 5000);
              //setInterval(makeRedirct, 5000);
              //document.location.href = "allotteePayMaintenance.aspx";
              //function makeRedirct() {
              //    debugger;
              //    document.location.href = "allotteePayMaintenance.aspx";
              //};
          });
          
      </script>--%>
    </form>
</body>
</html>
