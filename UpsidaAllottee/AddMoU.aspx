<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoU.aspx.cs" Inherits="UpsidaAllottee.AddMoU" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                    <li role="presentation" class="active"><a href="/OTSAllotteeLedgerSummary.aspx"><b>Allottee Ledger Summary</b></a></li>
                    <li role="presentation"><a href="MOUTrack.aspx"><b>Track MoU</b></a></li>
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

            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>Regional Office</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
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
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>AGRA </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>ALIGARH </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>AYODHYA</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>BAREILLY </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>GHAZIABAD</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>GNEPIP</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>GORAKHPUR</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>JHANSI</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>KANPUR</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>LUCKNOW</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>MEERUT</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>PRAYAGRAJ</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>SEZ MORADABAD </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>SURAJPUR </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>VARANASI </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox15" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>PO TDS CITY</label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox16" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-12" style="margin-top: 10px;">
                    <div class="form-control">
                        <label>PO TRANS GANGA </label>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-12">
                    <div class="form-control">
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="autosuggest form-control ui-autocomplete-input"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12">
                    <div class="form-control">
                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Button" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

