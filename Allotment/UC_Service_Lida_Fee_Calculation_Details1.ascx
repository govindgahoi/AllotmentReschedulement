<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Service_Lida_Fee_Calculation_Details1.ascx.cs" Inherits="Allotment.UC_Service_Lida_Fee_Calculation_Details1" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlreadyAppliedFeeCalculationDetails.aspx.cs" Inherits="LidaApplication.AlreadyAppliedFeeCalculationDetails" %>--%>

    <style>

        .table1 td {
            padding-top: 1px;
            padding-bottom: 1px;
        }

        .buttonN {
            padding: 1px 10px;
            font-size: 12px;
            text-align: center;
            cursor: pointer;
            outline: none;
            color: #fff;
            background-color: #4CAF50;
            border: none;
            border-radius: 5px;
            box-shadow: 0 2px #999;
        }

            .buttonN:hover {
                background-color: #3e8e41;
            }

            .buttonN:active {
                background-color: #3e8e41;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
            }

        .bg-mywhite {
            background: #fff;
        }

        .performance-textdiv {
            min-height: 111px;
            margin-top: 20px;
            padding: 0px 0 0 7px;
            font-weight: 500;
            color: #636262;
        }

        .performance-textdiv1 {
            min-height: 250px;
            margin-top: 20px;
            padding: 0px 0 0 7px;
            font-weight: 500;
            color: #636262;
        }


        #myBtn {
            display: none;
            position: fixed;
            bottom: 20px;
            right: 30px;
            z-index: 99;
            font-size: 18px;
            border: none;
            outline: none;
            background-color: red;
            color: white;
            cursor: pointer;
            padding: 15px;
            border-radius: 4px;
        }

            #myBtn:hover {
                background-color: #555;
            }

        * {
            box-sizing: border-box;
        }

        .btn-primary {
            background-color: #f3cc48;
            background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ffe034), to(#e4b306));
            border: 1px solid #e9bb0e;
            font-weight: 500;
            color: #000;
        }

        .dash {
            border: 0 none;
            border-top: 1px dashed #FFD200;
            background: none;
            height: 0;
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

        td > input, td > select {
            width: 150px !important;
            margin: 0 0 0 0;
            background: #fff9e7 !important;
            width: 100%;
            height: 23px !important;
            border-radius: 0px !important;
            height: 22px;
            border: 1px solid #fff;
        }

        #btnAddrow {
            margin-top: 3vh;
            background-color: mediumslateblue;
            color: white;
            font-weight: bold;
            font-size: 12px;
            margin-left: 10px;
        }

        hr {
            text-align: center;
            /*width:1000px;*/
            margin-top: 1vh;
            border-top: 2px solid #d4e1df;
            border-bottom: 2px solid #eaf9f7;
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .text {
                font-size: 11px;
            }
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 600px;
                /* height: 300px; */
                margin-top: 11%;
            }
        }

        #ac-wrapper {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(255, 255, 255, .6);
            z-index: 1001;
        }

        #popup {
            width: 880px;
            height: 480px;
            background: #FFFFFF;
            border: 5px solid #000;
            border-radius: 25px;
            -moz-border-radius: 25px;
            -webkit-border-radius: 25px;
            box-shadow: #64686e 0px 0px 3px 3px;
            -moz-box-shadow: #64686e 0px 0px 3px 3px;
            -webkit-box-shadow: #64686e 0px 0px 3px 3px;
            position: relative;
            top: 150px;
            left: 375px;
            transition: width 2s;
        }
    </style>
    <style>
        .row {
            margin-left: 0px;
            margin-right: 0px;
        }

        a.static.selected {
            text-decoration: none;
            border-style: none;
            color: #000000 !important;
            background: #ffdb6d;
        }

        .iadsashboard-dayul-inbox ul li a {
            text-decoration: none !important;
            white-space: nowrap;
            display: block;
            padding: 4px 6px;
            color: #2b2b2b;
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

        #ContentPlaceHolder1_sub_menu a {
            padding: 3px 8px;
        }

        #ContentPlaceHolder1_sub_menu ul {
            list-style-type: none !important;
            list-style: none !important;
            margin: 0;
            background: #e2e2e2;
            padding: 0;
            width: auto;
        }



        .sub_menu li {
            position: relative;
            font-size: 12px;
            color: #2d2d2d;
            border-bottom: 1px solid #ffffff;
            padding: 1px 1px !important;
            font-weight: 500;
        }

        #Service_Building_Plan_sub_menu a.static {
            padding-left: 1.15em !important;
            padding-right: 1.15em !important;
        }

        ul, menu, dir {
            list-style-type: none !important;
        }
    </style>
   
          

                                        <style>
                                            .row {
                                                margin-left: 0px;
                                                margin-right: 0px;
                                            }

                                            a.static.selected {
                                                text-decoration: none;
                                                border-style: none;
                                                color: #000000 !important;
                                                background: #ffdb6d;
                                            }

                                            .iadsashboard-dayul-inbox ul li a {
                                                text-decoration: none !important;
                                                white-space: nowrap;
                                                display: block;
                                                padding: 4px 6px;
                                                color: #2b2b2b;
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

                                            #ContentPlaceHolder1_sub_menu a {
                                                padding: 3px 8px;
                                            }

                                            #ContentPlaceHolder1_sub_menu ul {
                                                list-style-type: none !important;
                                                list-style: none !important;
                                                margin: 0;
                                                background: #e2e2e2;
                                                padding: 0;
                                                width: auto;
                                            }



                                            .sub_menu li {
                                                position: relative;
                                                font-size: 12px;
                                                color: #2d2d2d;
                                                border-bottom: 1px solid #ffffff;
                                                padding: 1px 1px !important;
                                                font-weight: 500;
                                            }

                                            #Service_Building_Plan_sub_menu a.static {
                                                padding-left: 1.15em !important;
                                                padding-right: 1.15em !important;
                                            }

                                            ul, menu, dir {
                                                list-style-type: none !important;
                                            }
                                        </style>
                                        <style>
                                            @media only screen and (max-width:992px) {
                                                .form-group label.text-right {
                                                    text-align: left !important;
                                                }

                                                .ey-payment {
                                                    background: #ff6a00;
                                                }
                                            }
                                        </style>



<div class="panel panel-default">
    <div style="background: #e2e2e2; text-align: right; padding: 10px 0; border: 1px solid #cacaca;"></div>



    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div id="DivP" style="text-align: center; padding: 15px 25px; margin: 25px 10%; background: #fbfbfb; border: 1px solid #ccc;">
                <div class="div-report" style="text-align: center;">


                    <img src="images/upsidclogo.png" class="header-logo" style="border-top: none; height: 40px; margin-bottom: 0;"><br>
                    <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
                        (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br>
                    <br />
                    <div style="border-top: 3px solid #ffc511;">&nbsp;</div>

                    <span class="pull-right font-bold">Dated: 
                                                                <td>
                                                                    <asp:Label ID="lbldt" runat="server" Text=""></asp:Label>
                                                                </td>
                    </span>
                    <br />
                    <h2 style="text-decoration: underline;">Statement of Estimated Deposits</h2>
                    <br />
                    <div class="col- md-6">
                        <table class="table-bordered pull-left" width="41%" style="font-size: 12px;">
                            <tbody>
                                <tr style="background: #f7f7f7;">
                                    <th>Application Reference Number</th>
                                    <th class="text-left">
                                        <asp:Label ID="lblapprefno" runat="server" Text=""></asp:Label><%--SER20220208/1/39921/39739--%></th>
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Payment Mode </th>
                                    <th class="text-left">
                                        <asp:Label ID="lblpaymode" runat="server" Text=" 	HDFC Bank Retail"></asp:Label></th>
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Transaction Ref No </th>
                                    <th class="text-left">
                                        <asp:Label ID="lbltxnrefno" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Transaction Date </th>
                                    <th class="text-left">
                                        <asp:Label ID="lbltxndt" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Payment Status </th>
                                    <th class="text-left">
                                        <asp:Label ID="lblpaystatus" runat="server" Text=""></asp:Label></th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <table class="table table-bordered table-hover request-table">
                            <tbody>
                                <tr style="background: #f7f7f7;">
                                    <td colspan="2" style="text-align: center">—————— ✂ Option : Based on Entered Plot Size  ✂ ——————  </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <label class="col-md-12 col-sm-12 col-xs-12 text-center" style="border-top: dashed"></label>
                    </div>
                    <br />
                    <div class="col- md-6">
                        <table class="table-bordered pull-left" width="41%" style="font-size: 12px;">
                            <tbody>
                                <tr style="background: #f7f7f7;">
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Plot Area </th>
                                    <th class="text-left">
                                        <asp:Label ID="lblplotarea" runat="server" Text=""></asp:Label>
                                        SQmts</th>
                                </tr>
                                <tr style="background: #f7f7f7;">
                                    <th>Builtup/Ground Coverage Area </th>
                                    <th class="text-left">
                                        <asp:Label ID="lblcoveredarea" runat="server" Text=""></asp:Label>
                                        SQmts</th>
                                </tr>


                            </tbody>
                        </table>
                    </div>
                    <br />
                    <br />
                    <br />

                    <table class="table table-bordered table-hover request-table">

                        <tbody>
                            <tr style="background: #f7f7f7;">
                                <th>S.NO </th>
                                <th>Description </th>
                                <th class="text-center">Amount</th>
                            </tr>
                            <%--    <tr>
                                                                        <td colspan="3">A. Applicable Fees</td>
                                                                    </tr>--%>
                            <tr>
                                <td class="text-center">1</td>
                                <td class="text-center">Building Permit Fees</td>
                                <td class="text-center">
                                    <asp:Label ID="lblpermitfee" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="text-center">2</td>
                                <td class="text-center">Permissive Fee For Temporary Construction</td>
                                <td class="text-center">
                                    <asp:Label ID="lblpermitfeefortemp" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="text-center">3</td>
                                <td class="text-center">Labour Accommodation Fee</td>
                                <td class="text-center">
                                    <asp:Label ID="lbllabourfree" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="text-center">4</td>
                                <td class="text-center">Inspection Fee on Ground Coverage Area</td>
                                <td class="text-center">
                                    <asp:Label ID="lblfeeoncoveredarea" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2" class="text-center">Total Applicable Fees</td>
                                <th class="text-left"><i class="fa fa-inr"></i>
                                    <asp:Label ID="lbltotalfee" runat="server" Text=""></asp:Label></th>
                            </tr>
                            <tr>
                                <th colspan="2" class="text-center">Total Payable(with 18 % GST)</th>
                                <th class="text-left"><i class="fa fa-inr"></i>
                                    <asp:Label ID="lblgstwithfee" runat="server" Text=""></asp:Label></th>
                            </tr>


                        </tbody>
                    </table>




                    <br />

                    <asp:Button ID="btnpay" Enabled="true" CssClass="btn btn-primary ey-bg pull-right" runat="server" Text="Pay Now" OnClick="btnpay_Click" />

                    <br />
                    <br />
                    <br />
                    <div class="row">
                        <label class="col-md-12 col-sm-12 col-xs-12 text-center" style="border-top: dashed"></label>
                    </div>

                    <div class="row">
                        <table class="table table-bordered table-hover request-table">

                            <tbody>
                                <tr style="background: #f7f7f7;">
                                    <th colspan="2" style="text-align: center">—————— ✂ For Office Use Only ✂ ——————  </th>
                                </tr>

                            </tbody>

                        </table>
                    </div>
                    <br />

                    <br />
                </div>
            </div>
        </div>
    </div>
</div>

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
<script type="text/javascript">
    $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });

    function ShowMessage() {
        alert('Your Application Is submitted Successfully');
        window.location.href = 'ServiceRequestSubmitted.aspx';

    }
    function ShowGroups() {

        $("#btnNewGroup").click();
    }

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function (sender, e) {
        $(".date").datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd M yy" });


        function ShowMessage() {
            alert('Your Application Is submitted Successfully');
            window.location.href = 'ServiceRequestSubmitted.aspx';

        }
        function ShowGroups() {

            $("#btnNewGroup").click();
        }

    });
       </script>

