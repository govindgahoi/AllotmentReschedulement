<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KYA-Request.aspx.cs" Inherits="UpsidaAllottee.KYA_Request" %>

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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
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
                padding: 6px 16px;
                color: white;
                border-radius: 6px;
            }

            .kya-form .btn2 {
                border: none;
                background-color: #006699;
                padding: 6px 16px;
                color: white;
                border-radius: 6px;
            }
    </style>
    <%--   pouup modal css--%>
    <style>
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
                    <li role="presentation" class="active"><a href="KYA-Request.aspx"><b>KYA Approval </b></a></li>
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
            <div class="row" style="margin-left: 5px; margin-right: 5px; margin: 20px 0px">
                <div class="col-lg-4 col-md-4 text-left">
                    <div class="offices">
                        <div class="row" style="margin-left: 10px">
                            <div class="col-lg-6 col-md-6  text-right" style="font-size: 14px!important">
                                Regional Office
                            </div>
                            <div class="col-lg-6 col-md-6">
                                <select class="form-control">
                                    <option selected="selected" value="-1">--Select All--</option>
                                    <option value="1">AGRA </option>
                                    <option value="1">ALIGARH </option>
                                    <option value="1">AYODHYA </option>
                                    <option value="1">BAREILLY </option>
                                    <option value="1">GHAZIABAD </option>
                                    <option value="1">GNEPIP </option>
                                    <option value="1">GORAKHPUR</option>
                                    <option value="1">JHANSI </option>
                                    <option value="1">KANPUR</option>
                                    <option value="1">LUCKNOW</option>
                                    <option value="1">MEERUT </option>
                                    <option value="1">PRAYAGRAJ </option>
                                    <option value="1">SEZ MORADABAD </option>
                                    <option value="1">SURAJPUR </option>
                                    <option value="1">VARANASI </option>
                                    <option value="1">PO TDS CITY</option>
                                    <option value="1">PO TRANS GANGA</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4"></div>
                <div class="col-lg-4 col-md-4"></div>
            </div>
            <div class="row">
                <h3>Pending Requests</h3>
            </div>
                <div class="table-responsive" style="overflow-y: auto; max-height: 690px;">
                    <div>
                        <table class="table table-striped table-bordered table-hover request-table " cellspacing="0" rules="rows" border="1" id="" style="background-color: #FFE6E6; width: 100%; border-collapse: collapse;">
                            <tbody>
                                <tr class="GridViewHeaderStyle" style="color: Snow; background-color: Crimson; font-style: normal;">
                                    <th scope="col">S.No.</th>
                                    <th scope="col">Allotment Id</th>
                                    <th scope="col">Name of Allottee</th>
                                    <th scope="col">Regional Office</th>
                                    <th scope="col">Industrial Area</th>
                                    <th scope="col">Plot No </th>
                                    <th scope="col">Email Id</th>
                                    <th scope="col">Mobile No</th>
                                    <th scope="col">GST Registration Status</th>
                                    <th scope="col">GST Registration No</th>
                                    <th scope="col">Date of GST Registration</th>
                                    <th scope="col">PAN</th>
                                    <th scope="col">Aadhar Card</th>
                                    <th scope="col">Remark</th>
                                    <th scope="col" style="background-color: #06a353;">View</th>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                     <td><a href="Allottee-Kya.aspx" class="btn btn-info">View</a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
          
        <div class="row">
                <h3>Approved Requests</h3>
            </div>
                <div class="table-responsive" style="overflow-y: auto; max-height: 690px;">
                    <div>
                        <table class="table table-striped table-bordered table-hover request-table " cellspacing="0" rules="rows" border="1" id="" style="background-color: #FFE6E6; width: 100%; border-collapse: collapse;">
                            <tbody>
                                <tr class="GridViewHeaderStyle" style="color: Snow; background-color: Crimson; font-style: normal;">
                                    <th scope="col">S.No.</th>
                                    <th scope="col">Allotment Id</th>
                                    <th scope="col">Name of Allottee</th>
                                    <th scope="col">Regional Office</th>
                                    <th scope="col">Industrial Area</th>
                                    <th scope="col">Plot No </th>
                                    <th scope="col">Email Id</th>
                                    <th scope="col">Mobile No</th>
                                    <th scope="col">GST Registration Status</th>
                                    <th scope="col">GST Registration No</th>
                                    <th scope="col">Date of GST Registration</th>
                                    <th scope="col">PAN</th>
                                    <th scope="col">Aadhar Card</th>
                                    <th scope="col">Remark</th>
                                    <th scope="col" style="background-color: #06a353;">View</th>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                      <td><a href="Allottee-Kya.aspx" class="btn btn-info">View</a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
             <div class="row">
                <h3>Rejected Requests</h3>
            </div>
                <div class="table-responsive" style="overflow-y: auto; max-height: 690px;">
                    <div>
                        <table class="table table-striped table-bordered table-hover request-table " cellspacing="0" rules="rows" border="1" id="" style="background-color: #FFE6E6; width: 100%; border-collapse: collapse;">
                            <tbody>
                                <tr class="GridViewHeaderStyle" style="color: Snow; background-color: Crimson; font-style: normal;">
                                    <th scope="col">S.No.</th>
                                    <th scope="col">Allotment Id</th>
                                    <th scope="col">Name of Allottee</th>
                                    <th scope="col">Regional Office</th>
                                    <th scope="col">Industrial Area</th>
                                    <th scope="col">Plot No </th>
                                    <th scope="col">Email Id</th>
                                    <th scope="col">Mobile No</th>
                                    <th scope="col">GST Registration Status</th>
                                    <th scope="col">GST Registration No</th>
                                    <th scope="col">Date of GST Registration</th>
                                    <th scope="col">PAN</th>
                                    <th scope="col">Aadhar Card</th>
                                    <th scope="col">Remark</th>
                                    <th scope="col" style="background-color: #06a353;">View</th>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>RAG\3153</td>
                                    <td>M/s. Gyan Agri Products</td>
                                    <td>Agra</td>
                                    <td>Bhogaon</td>
                                    <td>35 Acres UD Land</td>
                                    <td>gyanagri.prod@gmail.com</td>
                                    <td>9457332292</td>
                                    <td>Yes</td>
                                    <td>4795-96/SIDC/RMA/UD</td>
                                    <td>01/01/1900</td>
                                    <td>ROKH38945733229</td>
                                    <td>94573322924546456</td>
                                    <td>Remark</td>
                                    <td><a href="Allottee-Kya.aspx" class="btn btn-info">View</a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>

