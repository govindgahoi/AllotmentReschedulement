<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Allottee-Kya.aspx.cs" Inherits="UpsidaAllottee.Allottee_Kya" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uttar Pradesh Industrial Development Authority - Track MoU</title>
    <link rel="icon" href="images\upsidclogo.png" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="/assets/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="/css/theme.css" rel="stylesheet" />
    <link href="/css/Wizard.css" rel="stylesheet" />
    <link href="/css/Main.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />
    <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>--%>
    <style>
        .request-table tr th {
            font-size: 12px;
            background-color: #006699 !important;
            color: white;
        }

        .DaysRemaining {
            color: green;
        }

        .Red {
            color: red;
        }

        .Green {
            color: green;
        }

        .navbar-inverse .navbar-nav > .active > a, .navbar-inverse .navbar-nav > .active > a:focus, .navbar-inverse .navbar-nav > .active > a:hover {
            color: #efefef;
            background-color: #08080861 !important;
        }

        .mainnavbar {
            height: 38px !important;
        }

        .navbar-nav .dropdown {
            padding: 0px 10px;
            border-radius: 13px 13px 2px 14px;
            background: #08080861;
        }

        .col-md-2.col-lg-2.xyz.text-left {
            padding-top: 4px;
        }

        @media screen and (min-width: 768px) {
            .jumbotron {
                padding-top: 15px !important;
                padding-bottom: 15px !important;
            }
        }

        .jumbotron {
            padding-top: 10px !important;
            padding-bottom: 10px !important;
            margin-bottom: 30px;
            background-color: #f3e7ff;
        }

        .row {
            margin-left: 0px;
            margin-right: 0px;
        }

        .kya-form {
            padding: 44px;
            width: 60%;
            background-color: #f7f2f2b5;
            margin: 30px auto;
            border-radius: 30px;
        }

            .kya-form h1 {
                text-align: center;
                font-size: 27px;
                color: #006699;
                margin-bottom: 42px;
                margin-top: 0px;
            }

            .kya-form p {
                font-weight: bold;
            }

            .kya-form .btn1 {
                border: none;
                background-color: #be2c2c;
                color: white;
                border-radius: 6px;
            }

            .kya-form .btn2 {
                border: none;
                background-color: #006699;
                color: white;
                border-radius: 6px;
            }
    </style>
    <%--   pouup modal css--%>
    <style>
        .popup-link {
            display: flex;
            flex-wrap: wrap;
            margin-top: 20px;
        }

            .popup-link a {
                background: #333;
                color: #fff;
                padding: 10px 30px;
                border-radius: 5px;
                font-size: 17px;
                cursor: pointer;
                margin: 20px;
                text-decoration: none;
            }

        .popup-container {
            visibility: hidden;
            opacity: 0;
            transition: all 0.3s ease-in-out;
            transform: scale(1.3);
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(21, 17, 17, 0.61);
            display: flex;
            align-items: center;
        }

        .popup-content {
            border-radius: 14px;
            text-align: center;
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 40%;
        }

            .popup-content p {
                font-size: 17px;
                padding: 10px;
                line-height: 20px;
            }
            .close i{
                color:white;
            }
            .popup-content a.close {
                color: #fefefe !important;
    float: right;
    font-size: 20px;
    font-weight: bold;
    background: none;
    padding: 8px 12px;
    background-color: #209509;
    border-radius: 20px;
    opacity: 1;
    margin: 0;
    text-decoration: none;
            }

                .popup-content a.close:hover {
                    color: #333;
                }

            .popup-content span:hover,
            .popup-content span:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .popup-container:target {
            visibility: visible;
            opacity: 1;
            transform: scale(1);
        }

        .popup-container h3 {
            margin: 10px;
            font-size: 33px;
            margin-bottom: 30px;
        }

        .popup-style-2 {
            transform: scale(0.3);
        }

            .popup-style-2:target {
                transform: scale(1);
            }

        .btn3 {
            border: none;
            background-color: #be2c2c;
           margin: 10px 15px;
           padding: 10px 30px;
            color: white;
            border-radius: 6px;
        }

        .btn4 {
            border: none;
            background-color: #006699;
           margin: 10px 15px;
            padding: 10px 30px;
            color: white;
            border-radius: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="navbar-header pull-left top-head-bg">
                <a href="Default.aspx" class="navbar-brand" style="width: 100%;">
                    <div class="col-md-8">
                        <img class="img-responsive" src="images/upsida-logo-name.png" />
                    </div>
                    <div class="col-md-4" style="margin-top: 2px;">
                        <img class="img-responsive" src="images/image4.png" />
                    </div>
                </a>
            </div>
        </div>
        <div class="clearfix"></div>
        <nav class="navbar navbar-inverse navbar-dark bg-dark" style="background-color: #006699;">
            <div class="container-fluid">
                <%--<div id="navbar" class="navbar-collapse collapse">--%>
                <ul class="nav navbar-nav nav-tabs" role="tablist">
                    <li role="presentation"><a href="/UpdateAllotmentDetails.aspx"><b>Interest Rate</b></a></li>
                    <%--<li role="presentation"><a href="#"><b>Balance Premium</b></a></li>--%>
                    <%--<li role="presentation" ><a href="/OTSGrievances.aspx"><b>OTS Grievances</b></a></li>--%>
                    <li role="presentation"><a href="/OTSGrievancesMIS.aspx"><b>OTS Grievances MIS</b></a></li>
                    <li role="presentation"><a href="/OTSDashboard.aspx"><b>OTS Dashboard</b></a></li>
                    <li role="presentation"><a href="/OTSAllotteeLedgerSummary.aspx"><b>Allottee Ledger Summary</b></a></li>
                    <li role="presentation"><a href="MOUTrack.aspx"><b>Track MoU</b></a></li>
                    <li role="presentation"><a href="KYA-Request.aspx"><b>KYA Approval </b></a></li>

                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <span style="position: relative; top: 3px;"><b>Welcome </b>
                                <asp:Label ID="lblname" runat="server"></asp:Label></span>
                            <i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="./">My Account</a></li>
                            <li class="divider"></li>
                            <li><a tabindex="-1" href="/Default.aspx?logout=true">Logout</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container-fluid">
            <div class="kya-form">
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12">
                        <div class="">
                            <h1>KYA Form 
                            </h1>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Allotment Id: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>RAG\3153 </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Name of Allottee: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>M/s. Gyan Agri Products </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Regional Office:</p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>Agra </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Industrial Area: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>Bhogaon </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Plot No: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>35 Acres UD Land </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Email Id: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>gyanagri.prod@gmail.com </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Mobile No: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>9457332292 </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>GST Registration Status: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>Yes </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>GST Registration No:</p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>4795-96/SIDC/RMA/UD  </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Date of GST Registration:</p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>01/01/1900 </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>PAN:</p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>ROKH389457332292</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Aadhar Card: </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <label>94573322924546456 </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                        <div class="">
                            <p>Remark </p>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-12">
                        <div class="">
                            <textarea id="TextArea1" cols="20" rows="4" placeholder="Message" class="form-control"></textarea>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="popup-link">
                        <div class="col-md-6 col-lg-6 col-sm-12 text-right" style="margin-top: 10px;">
                            <div class="">
                                <a href="#popup2" class="btn1">Reject</a>
                                <%--<input type="submit" name="Button1" value="Reject" id="Button1" class="btn1"/>--%>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                            <div class="">
                                <a href="#popup1" class="btn2">Approve</a>
                                <%-- <input type="submit" name="Button2" value="Approve" id="Button2" class="btn2"/>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--   poup Modal Box Start--%>
        <%--<div class="popup-link">
<a href="#popup1">Click Me (Style 1)</a>
<a href="#popup2">Click Me (Style 2)</a>
</div>--%>
        <!--popup1-->
        <div id="popup1" class="popup-container">
            <div class="popup-content">
                <a href="#" class="close"><i class="fa fa-times" aria-hidden="true"></i></a>
                <h3>Approve</h3>
                <p>Are you sure that you want to Approve the KYA Form?</p>
                <input type="submit" name="Button2" value="No" id="Button3" class="btn3" />
                <input type="submit" name="Button2" value="Yes" id="Button4" class="btn4" />
            </div>
        </div>

        <!--popup2-->
        <div id="popup2" class="popup-container popup-style-2">
            <div class="popup-content">
                <a href="#" class="close"><i class="fa fa-times" aria-hidden="true"></i></a>
                <h3>Rejection</h3>
                <p>Are you sure that you want to Reject the KYA Form? </p>
                <input type="submit" name="Button2" value="No" id="Button1" class="btn3" />
                <input type="submit" name="Button2" value="Yes" id="Button2" class="btn4" />
            </div>
        </div>
        <%--   poup Modal End--%>

        <%--   poup Modal Script Start--%>

        <%--   poup Modal Script End--%>
    </form>

</body>
</html>

