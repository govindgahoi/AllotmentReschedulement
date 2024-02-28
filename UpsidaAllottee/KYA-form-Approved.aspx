<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KYA-form-Approved.aspx.cs" Inherits="UpsidaAllottee.KYA_form_Approved" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uttar Pradesh Industrial Development Authority- KYA Form Approved</title>
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
                    <li role="presentation"><a href="KYA-form-Approved.aspx"><b>KYA Approved</b></a></li>
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
            <div class="addmou-form">
           
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Allotment Id: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Name of Allottee: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Regional Office:</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Industrial Area: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Plot No: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Email Id: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Mobile No: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>GST Registration Status: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>GST Registration No:</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Date of GST Registration:</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>PAN:</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Aadhar Card: </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <label>Remark </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="">
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="UnApproved" />
                    </div>
                </div>
                 <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="">
                        <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Approved" />
                    </div>
                </div>
            </div>
                </div>
        </div>
    </form>
</body>
</html>

