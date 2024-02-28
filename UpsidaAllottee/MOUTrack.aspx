<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOUTrack.aspx.cs" Inherits="UpsidaAllottee.MOUTrack" %>

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
                    <li role="presentation" class="active"><a href="/KYA-form-Approved.aspx"><b>KYA Request</b></a></li>
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

        <div class="row" style="margin-left: 5px; margin-right: 5px; margin-top: 10px">
            <div class="col-lg-6 col-md-6 ">
                <div class="jumbotron">
                    <div class="row" style="margin-left: 10px">
                        <div class="col text-center" style="font-size: 14px!important">
                            Office Location
                        </div>
                        <div class="col">
                            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="" CssClass="chosen input-sm similar-select1 margin-left-z" Font-Size="small"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6">
                <div class="jumbotron">
                    <div class="row" style="margin-left: 10px">
                        <a href="AddMoU.aspx" class="btn btn-info btn-sm">Add MoU</a>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="table-responsive" style="overflow-y: auto; max-height: 390px;">
                <div>
                    <table class="table table-striped table-bordered table-hover request-table " cellspacing="0" rules="rows" border="1" id="" style="background-color: #FFE6E6; width: 100%; border-collapse: collapse;">
                        <tbody>
                            <tr class="GridViewHeaderStyle" style="color: Snow; background-color: Crimson; font-style: normal;">
                                <th align="center" scope="col">S.No.</th>
                                <th scope="col">Intent ID</th>
                                <th scope="col">Company Name</th>
                                <th scope="col">Address</th>
                                <th scope="col">Office Location</th>
                                <th scope="col">Email Id </th>
                                <th scope="col">Investor Name</th>
                                <th scope="col">Desination</th>
                                <th scope="col">Investor Mobile</th>
                                <th scope="col">Project Name</th>
                                <th scope="col">Project Details</th>
                                <th scope="col">Sector</th>
                                <th scope="col">Investment  (in Crore INR)</th>
                                <th scope="col">Employment</th>
                                <th scope="col">Preferred Location</th>
                                 <th scope="col">Regional office </th>
                                 <th scope="col" style="background-color: #06a353;">Edit</th>
                            </tr>
                   <tr>
                    <td>1</td>
                    <td>22001460</td>
                    <td>Avaada Ventures Pvt Ltd</td>
                    <td>
                        406, Hubtown Solaris, NS Phadke Marg, Andheri East, Mumbai 400069,Mumbai City, Maharashtra, India
                        Pin Code : 400069
                    </td>
                    <td>Maharashtra</td>
                    <td>praveen.golash@avaada.com</td>
                    <td>Praveen Golash</td>
                    <td>AVP</td>
                    <td>919711302259</td>
                    <td>Avaada Green Ammonia 0.5 MTPA</td>
                    <td>The main objective of the project is to develop a unique industrial project in Uttar Pradesh to produce 0.5 Million Tons per Annum of Green Ammonia</td>
                    <td>Chemical Manufacturing</td>
                    <td>22500</td>
                    <td>1500</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>22000164</td>
                    <td>GroupeKRS NetworKs</td>
                    <td>
                        Suite R.H.2-KRISHNA, Sukhwani Udyan, PCMC Link Road, Near Hotel Eagle, Opposite TULSIDAS MALL, Chinchwad, Pune,Pune, Maharashtra, India
                        Pin Code : 411033
                    </td>
                    <td>Maharashtra</td>
                    <td>manish@krsmatrix.com</td>
                    <td>Manishkumar Handa</td>
                    <td>Global CEO</td>
                    <td>918830981627</td>
                    <td>KSIFP - Krstal Suncity Infra Fintech Projects</td>
                    <td>NRI MIXED USE TOWNSHIP PLANNED@1000 acre , 100, to begin with, Planned Mixed use Township, with Residential &amp; Commercial-ITES,Â will attract NRIs from worldover, due to less sale price,Â good investment growth, in 3-4 years of completion &amp; also, inviting Global Fortune corporates, due toÂ being a Consortium Project, Led by GroupeKRS NetworKs &amp; Fortune 500 global MNC-REIT. Details on websites, thru emailÂ &amp; also UP State Govt earnsÂ  FEW hundred crores thru EQUITY, &amp; 10xGDP growth, thru SPVs, NOW-REIT</td>
                    <td>Private Industrial Park</td>
                    <td>10000</td>
                    <td>100000</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>22003743</td>
                    <td>Mobility Infrastructure Group</td>
                    <td>
                        9800 MacArthur Boulevard Suite 300 ,, California, United States
                        Pin Code : 92612
                    </td>
                    <td>United States </td>
                    <td>ravindraverma@mobilityinfra.com</td>
                    <td>Ravindra Verma</td>
                    <td>Founder Chairman</td>
                    <td>919495144124</td>
                    <td>Multimodal Transportation &amp; Logistics Infrastructure</td>
                    <td>MiG wishes to be involved in the development, financing, investment, ownership, management and operations of Multimodal Transportation &amp; Logistics Infrastructure including MLPs linking with railways, highways, ports, airports and inland waterways</td>
                    <td>Logistics and Warehousing </td>
                    <td>8200</td>
                    <td>100</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>`</td>
                    <td>M/s Solid ply Pvt. Ltd</td>
                    <td>
                        8 khairu place 4th floor bowbazar ST kolkata WB- 700072,Chandauli, Uttar Pradesh, India
                        Pin Code : 232104
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sahupuriproject@gmail.com</td>
                    <td>Manish kumar tripathi</td>
                    <td></td>
                    <td>919919510999</td>
                    <td>Private Industrial Park</td>
                    <td>Intergrated Township which will cover projects related to tourism policy, 2022, Logistic Policy, 2022, Industrial Policy, 2022, (Non Polluting Industry) Education, Health, Housing, PM Awas, EOW And Other.</td>
                    <td>Private Industrial Park</td>
                    <td>7000</td>
                    <td>6000</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>22000018</td>
                    <td>Mega Leather Cluster Devlopement (U.P.) Ltd</td>
                    <td>
                        Village karanu Bahadurnagar/magrasa Kanpur Sadar Ramaipur kanpur,Kanpur Nagar, Uttar Pradesh, India
                        Pin Code : 209214
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>ashraf@homeratannery.com</td>
                    <td>Ashraf Rizwan</td>
                    <td>Director SPV</td>
                    <td>919839035200</td>
                    <td>Mega Leather Cluster Park</td>
                    <td>Total Number of Industries 354 will be Established Tanneries, Leather Goods Or Footwear Accesories</td>
                    <td>Leather and Footwear</td>
                    <td>5850</td>
                    <td>250000</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>23007196</td>
                    <td>Panchwati Group</td>
                    <td>
                        545 G T Road ,Howrah, West Bengal, India
                        Pin Code : 711101
                    </td>
                    <td>West Bengal</td>
                    <td>vijay@panchwatigroup.in</td>
                    <td>Vijay Chowdhary</td>
                    <td>Director</td>
                    <td>919038082634</td>
                    <td>Panchwati Group</td>
                    <td>500 acre multi modal logistics park with Private railway siding, warehousing, and industrial plots, dedicated plots for footwear manufacturing and food manufacturing.</td>
                    <td>Logistics and Warehousing </td>
                    <td>5400</td>
                    <td>5500</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>7</td>
                    <td>23010155</td>
                    <td>Marble Rocks VCC Fund Singapore</td>
                    <td></td>
                    <td></td>
                    <td>maneesh.tripathi@delteq.com.sg</td>
                    <td>Maneesh Tripathi</td>
                    <td>Promoter CEO</td>
                    <td>6590682064</td>
                    <td>FAB-HUB a Project to setup Fabless/wafer manufacturing Plant</td>
                    <td>
                        Phase1: Setup and R&amp;D Fabless base for Wafer/Fab_x000D_
                        Phase2: 200mm Line and 1.3um to .25um, CMOS, SOL, and MEMs Cap10K
                    </td>
                    <td>Casting of metals</td>
                    <td>5400</td>
                    <td>1500</td>
                    <td>Chitrakoot</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>8</td>
                    <td>22000031</td>
                    <td>Dharitri Solutions Pvt. Ltd.</td>
                    <td>
                        #192, NFL Enclave, Sector 48 A, Chandigarh,Chandigarh, Chandigarh, India
                        Pin Code : 160047
                    </td>
                    <td>Punjab</td>
                    <td>info@dharitrisolutions.com</td>
                    <td>Meenakshi Goyal</td>
                    <td>Managing Director</td>
                    <td>919872595511</td>
                    <td>Dharitri Global Industrial Park, Partapgarh</td>
                    <td>We propose to develop a Mega Global Industrial Park in Pratapgarh. We propose that the land of about 100 Acres, of Defunct ATL Tractor factory, which is now with U.P. Government, to be allocated to us for the development of Industrial Park on PPP Model.We propose to develop Mix of Industrial Plots &amp; ready to move Industrial Sheds with well laid out roads, sewerage plant, power and water connectivity and other Modern facilities/Technology including clearances required to start an industrial unit.</td>
                    <td>Private Industrial Park</td>
                    <td>4000</td>
                    <td>35000</td>
                    <td>Pratapgarh</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>9</td>
                    <td>22000349</td>
                    <td>City Gold Industrial Private Limited</td>
                    <td>
                        5th Floor, Shaligram Corporates, Ambli-Bopal Road,,Ahmedabad, Gujarat, India
                        Pin Code : 380058
                    </td>
                    <td>Gujarat</td>
                    <td>karsanantala@gmail.com</td>
                    <td>Karsan Antala</td>
                    <td>CEO</td>
                    <td>919909951303</td>
                    <td>3 M MTPY Portland Cement Manufacturing</td>
                    <td>Portland Cement Manufacturing Plant of a Capacity of 3 Million Ton annually</td>
                    <td>Non metallic and mineral products </td>
                    <td>3000</td>
                    <td>1000</td>
                    <td>Sonbhadra</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>10</td>
                    <td>22000286</td>
                    <td>SMRM INNOVATIVE VENTURES PRIVATE LIMITED</td>
                    <td>
                        UGF-1, City Cente Mall, Dahousie Road, Pathankot,Pathankot, Punjab, India
                        Pin Code : 145001
                    </td>
                    <td>Punjab</td>
                    <td>smrminnovative@gmail.com</td>
                    <td>Sanjive Mahajan</td>
                    <td>Managing Director</td>
                    <td>919814009245</td>
                    <td>SMRM INNOVATIVE INDUSTRIAL PARK</td>
                    <td>We are proposing to build world class industrial park along with township with state-of-the-art facilities, situated at district Pratapgarh (U.P). This project will draw lot of interest and investment to this area.</td>
                    <td>Private Industrial Park</td>
                    <td>3000</td>
                    <td>10000</td>
                    <td>Pratapgarh</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>11</td>
                    <td>22002464</td>
                    <td>M/s Indorama India Pvt. Ltd. </td>
                    <td>
                        ECOCENTRE, EM4, 12TH FLOOR, UNIT NO-ESCL, 1201, SECTOR-V, SALT LAKE, KOLKATA 700091 WEST BENGAL INDIA ,Kolkata, West Bengal, India
                        Pin Code : 700091
                    </td>
                    <td>West Bengal</td>
                    <td>laddhark@gmail.com</td>
                    <td>Sri R.K. Laddha </td>
                    <td>Authorized Signatory </td>
                    <td>8417001117</td>
                    <td>Urea Plant </td>
                    <td>MANUFACTURING OF CHEMICAL FERTILISER -UREA</td>
                    <td>Chemical Manufacturing</td>
                    <td>2649</td>
                    <td>650</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>12</td>
                    <td>22000384</td>
                    <td>M/S Raj Kumar Contractor</td>
                    <td>
                        612/S, (648), Street No 1, Shakti Nagar, Bathinda,Bathinda, Punjab, India
                        Pin Code : 151001
                    </td>
                    <td>Punjab</td>
                    <td>rajtechlife@gmail.com</td>
                    <td>Anil Kumar</td>
                    <td>Partner</td>
                    <td>919814106094</td>
                    <td>Kumar Industrial Park</td>
                    <td>We propose to develop an industrial park with all modern facilities, situated in Pratapgarh District, U.P. This project will bring lot of investment and growth for business in this district.</td>
                    <td>Private Industrial Park</td>
                    <td>2500</td>
                    <td>12000</td>
                    <td>Pratapgarh</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>13</td>
                    <td>22000103</td>
                    <td>WELSPUN ONE LOGISTICS PARKS PVT. LTD.</td>
                    <td>
                        6th Floor, Dextrus, Peninsula Corporate Park,Mumbai City, Maharashtra, India
                        Pin Code : 400013
                    </td>
                    <td>Maharashtra</td>
                    <td>lokanathan_nadar@welspun.com</td>
                    <td>Lokanathan Nadar</td>
                    <td>NATIONAL HEAD-CORPORATE AFFAIRS</td>
                    <td>919892123436</td>
                    <td>Welspun One Logistics Parks</td>
                    <td>Grade-A Warehouse and Logistics Park</td>
                    <td>Logistics and Warehousing </td>
                    <td>2000</td>
                    <td>30</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>14</td>
                    <td>22005284</td>
                    <td>SHARAF GROUP</td>
                    <td>
                        Sharaf Building,, Dubai, United Arab Emirates
                        Pin Code : 576
                    </td>
                    <td>UAE</td>
                    <td>skapur@sharaf.ae</td>
                    <td>Shyam Kapur</td>
                    <td>GROUP CEO and PRESIDENT</td>
                    <td>971504549950</td>
                    <td>Logistics Park</td>
                    <td>Development of Logistics Park including ICD, Rail Siding, Cold Store, Open Depot, Steel Yard, 3PL &amp; 4Pl Warehouse in New Bhimsen, Dalpatpur, Dadri, Gorakhpur &amp; Banaras. Each project investment will be around INR 250 cr. We are looking to invest in 5 different locations &amp; develop logistics Parks.</td>
                    <td>Logistics and Warehousing </td>
                    <td>1250</td>
                    <td>1250</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>15</td>
                    <td>22002002</td>
                    <td>M/s Keshav Publication Pvt Ltd</td>
                    <td>
                        Plot No D-14, D-15 Industrial Area Mathura Site-A,Mathura, Uttar Pradesh, India
                        Pin Code : 281004
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>keshavpublication@gmail.com</td>
                    <td>Mr Amit Bansal</td>
                    <td>Director</td>
                    <td>919927871000</td>
                    <td>Prabhat Industrial Park</td>
                    <td>Stationary Goods, Products of Electrical Items, Plastic Products Molding &amp; Manufacturing Items and Publications &amp; Other many Products.</td>
                    <td>Paper Manufacturing</td>
                    <td>1250</td>
                    <td>10000</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>16</td>
                    <td>22003013</td>
                    <td>M/s Nivara Enterprises Pvt Ltd</td>
                    <td>
                        Plot No 28, Pratap Nagar,North Delhi, Delhi, India
                        Pin Code : 110007
                    </td>
                    <td>Delhi</td>
                    <td>rajeshcs2000@yahoo.com</td>
                    <td>Mr Rajesh Chandra Sharma</td>
                    <td>Managing Director</td>
                    <td>919013451577</td>
                    <td>Vodka</td>
                    <td>Manufacturing unit of Liquor (Vodka)</td>
                    <td>Food Processing</td>
                    <td>1200</td>
                    <td>5500</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>17</td>
                    <td>22003931</td>
                    <td>PRINT ADE</td>
                    <td>
                        WH-96, PHASE-1 MAYA PURI INDUSTRIAL AREA,South West Delhi, Delhi, India
                        Pin Code : 110064
                    </td>
                    <td>Delhi</td>
                    <td>printade96@gmail.com</td>
                    <td>Rajesh Pasrija</td>
                    <td>Proprietor</td>
                    <td>919810539166</td>
                    <td>PRINT ADE</td>
                    <td>PRINTING PRESS, PACKAGING, AND UV PRINTING</td>
                    <td>Printing </td>
                    <td>1011.55</td>
                    <td>147</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>18</td>
                    <td>22005041</td>
                    <td>Ascendas Firstspace Development Managment Pvt Ltd</td>
                    <td>
                        309 Inspire BKC, Third Floor Bandra Kurla Complex,Mumbai City, Maharashtra, India
                        Pin Code : 400051
                    </td>
                    <td>Maharashtra</td>
                    <td>Kartik.Shah@ascendas-firstspace.com</td>
                    <td>Kartik Shah</td>
                    <td>Associate Director</td>
                    <td>919773463359</td>
                    <td>Industrial Warehousing and logistical park</td>
                    <td>
                        We plans to setup two industrial Warehousing and logistical park with gross potential of three million square feet spread across 100-150 acres of Land._x000D_
                        The Project could cater to assembly, storage, and manufacturing space requirements of Automobile, Electronics, Engineering, E-commerce, 3PL, FMCG, clients among others. The Project is expected to generate direct employment for about ~ 3,000 people and indirect employment for about 9,000 people.
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>1000</td>
                    <td>9000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>19</td>
                    <td>22000424</td>
                    <td>Dasnac Capital Private Limited</td>
                    <td>
                        Dasnac Annexe 1, ECE House, 28A, Kasturba Gandhi Marg, Delhi, Central Delhi DL 110001,Central Delhi, Delhi, India
                        Pin Code : 110001
                    </td>
                    <td>Delhi</td>
                    <td>legal@dasnac.com</td>
                    <td>Prateek Gupta</td>
                    <td>Legal Manager</td>
                    <td>918800899431</td>
                    <td>DASNAC Industrial Park</td>
                    <td>NCR/Western UP</td>
                    <td>Private Industrial Park</td>
                    <td>1000</td>
                    <td>10000</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>20</td>
                    <td>22000393</td>
                    <td>M/s Indian Corporation</td>
                    <td>
                        5TH FLOOR, MODI HOUSE 2, ,Thane, Maharashtra, India
                        Pin Code : 400601
                    </td>
                    <td>Maharashtra</td>
                    <td>indiancorporation@yahoo.com</td>
                    <td>Rudrapratap Tripathi</td>
                    <td>CMD Indian Corporation</td>
                    <td>919619007999</td>
                    <td>LOGISTIC &amp; WAREHOUSING PARK</td>
                    <td>LOGISTIC &amp; WAREHOUSING PARK LUCKNOW- KAPUR ROAD LUCKNOW</td>
                    <td>Logistics and Warehousing </td>
                    <td>1000</td>
                    <td>10000</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>21</td>
                    <td>22000392</td>
                    <td>M/s Indian Corporation</td>
                    <td>
                        5TH FLOOR, MODI HOUSE 2, ,Thane, Maharashtra, India
                        Pin Code : 400601
                    </td>
                    <td>Maharashtra</td>
                    <td>indiancorporation@yahoo.com</td>
                    <td>Rudrapratap Tripathi</td>
                    <td>CMD Indian Corporation</td>
                    <td>919619007999</td>
                    <td>LOGISTIC &amp; WAREHOUSING COMPLEX</td>
                    <td>LOGISTIC &amp; WAREHOUSING COMPLEX AT VARANASI (NEAR BY AIRPORT ROAD)</td>
                    <td>Logistics and Warehousing </td>
                    <td>1000</td>
                    <td>10000</td>
                    <td>Varanasi</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>22</td>
                    <td>22006480</td>
                    <td>Best Bay Trucking,</td>
                    <td>
                        Fresno,CA,, , 0
                        Pin Code :
                    </td>
                    <td>United States </td>
                    <td>tej@bestbaytrucking.com</td>
                    <td>Rawinder Singh</td>
                    <td></td>
                    <td>9232077449</td>
                    <td></td>
                    <td>IT BPO for logistic at Kanpur on 100 acres land</td>
                    <td>Logistics and Warehousing </td>
                    <td>1000</td>
                    <td>10000</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>23</td>
                    <td>22006479</td>
                    <td>UV International Inc</td>
                    <td>
                        2175 S Grand AVE.Santa ana ,CA 92705 ,USA,, , 0
                        Pin Code : 92705
                    </td>
                    <td>United States </td>
                    <td>Gaurav@uvstacks.com</td>
                    <td>Gaurav Bhargava</td>
                    <td></td>
                    <td>7147275680</td>
                    <td></td>
                    <td>Logistics, Fulfillment, Dropship centers. Microws sqft constructed 15-30 acres Jevar airport</td>
                    <td>Logistics and Warehousing </td>
                    <td>1000</td>
                    <td>10000</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>24</td>
                    <td>22004120</td>
                    <td>M/S BANARAS QUIB SCRAB PVT. LTD.</td>
                    <td>
                        J-13/93D-1, ,Varanasi, Uttar Pradesh, India
                        Pin Code : 221005
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>baranwalsantosh608@gmail.com</td>
                    <td>SANTOSH BARANWAL</td>
                    <td>DIRECTOR</td>
                    <td>919415227328</td>
                    <td>PLASTIC RECLYCLINE</td>
                    <td>PLASTIC RECYCLINE AT VARANASI</td>
                    <td>Recycling </td>
                    <td>1000</td>
                    <td>5000</td>
                    <td>Varanasi</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>25</td>
                    <td>22006244</td>
                    <td>PepsiCo India Holdings Pvt Ltd</td>
                    <td>
                        PepsiCo India Holdings Pvt. Ltd.,Gurgaon, Haryana, India
                        Pin Code : 122001
                    </td>
                    <td>Haryana</td>
                    <td>rahulbmsharma@gmail.com</td>
                    <td>Rahul Sharma</td>
                    <td>Associate Director</td>
                    <td>919368333323</td>
                    <td></td>
                    <td>Concentrate Greenfield Project</td>
                    <td>Food Processing</td>
                    <td>854</td>
                    <td>500</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>26</td>
                    <td>23007062</td>
                    <td>Varun Beverages Ltd.</td>
                    <td>
                        Plot No.31, Sector-44, Institutional Area, Gurgaon, Haryana -122002,Gurgaon, Haryana, India
                        Pin Code : 122002
                    </td>
                    <td>Haryana</td>
                    <td>kamlesh.jain@rjcorp.in</td>
                    <td>Kamlesh Kumar Jain</td>
                    <td>Executive Director and COO International</td>
                    <td>919811117276</td>
                    <td>Varun Beverages Limited, Trishundi (Amethi)</td>
                    <td>Setting up State of the Art Super Mega Plant for Manufacture of Fruit Pulp / Fruit Juice Based Drinks, Carbonated Soft Drinks, Beverages Base Syrup, Packaging Products &amp; Solar Power Project</td>
                    <td>Food Processing</td>
                    <td>780</td>
                    <td>250</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>27</td>
                    <td>22004059</td>
                    <td>M/s STAR PAPERS</td>
                    <td>
                        H.No -1/11760, F/137 Sarovar Marg Panchsheel Garden, Naveen Shahdara, East Delhi 110032,North East Delhi, Delhi, India
                        Pin Code : 110032
                    </td>
                    <td>Delhi</td>
                    <td>tanmaygarg12@gmail.com</td>
                    <td>Ramesh Chand Garg</td>
                    <td>Propreitor</td>
                    <td>919599177296</td>
                    <td>M/s Star Papers</td>
                    <td>Manufacturing of Paper Converter and Allied Products</td>
                    <td>Paper Manufacturing</td>
                    <td>600</td>
                    <td>22</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>28</td>
                    <td>22002016</td>
                    <td>DND INDIA (A solar Energy EPC)</td>
                    <td>
                        138M/30, MG MARG,Prayagraj, Uttar Pradesh, India
                        Pin Code : 1
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>unboxindia70@gmail.com</td>
                    <td>kuldeep srivastava</td>
                    <td></td>
                    <td>919935097463</td>
                    <td>DND SOLAR PARK</td>
                    <td>
                        100 MW SOLAR POWER PLANT/ SOLAR PARK AT MEJA, DISTRICT PRAYAGRAJ. ORGANIK FARMING AND PARALI MANAGEMENT ALSO IN PLAN. _x000D_
                        SOLAR PARK PRODUCE 500000 UNIT ELECTRICITY PER DAY. PLANT GENERATE JOBS ANT IT MORE BENIFICIARY FOR YOUTH AND FARMERS.
                    </td>
                    <td>Renewbale Energy</td>
                    <td>600</td>
                    <td>150</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>29</td>
                    <td>22004783</td>
                    <td>Yash Pakka Limited</td>
                    <td>
                        Yash Pakka Limited , Yash Nagar, Darshan Nagar Ayodhya,Ayodhya, Uttar Pradesh, India
                        Pin Code : 224135
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>liaison@yashpakka.com</td>
                    <td>Jagdeep Hira</td>
                    <td>MD</td>
                    <td>917800008308</td>
                    <td>Yash Pakka Limited</td>
                    <td>Manufacturing of Pulp, Paper, Compostable, Tableware, Egg Tray, Pith Pellet( Bio Mass fuel for boilers) and Compostable Packaging.</td>
                    <td>Food Processing</td>
                    <td>500</td>
                    <td>300</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>30</td>
                    <td>22002185</td>
                    <td>CHITRA REALCON PVT LTD</td>
                    <td>
                        Shop No. A 202-205,first floor,RMS plaza,Ghaziabad, Uttar Pradesh, India
                        Pin Code : 201102
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>CHITRAREALCON@GMAIL.COM</td>
                    <td>Sanjay Tyagi</td>
                    <td>DIRECTOR</td>
                    <td>919311155001</td>
                    <td>Chitra realcon private limited</td>
                    <td>We, CHITRA REALCON PRIVATE LIMITED(CRPL), Delhi a company , having own and our members land in Village- Nano &amp; Mandola, Loni District Ghaziabad of around 86 acres(Approx). Out of 86 acres of land owners we have formed consortium with around 50 acres of land owners and rest of the land owners, . We will develop this area as per the guideline which is mentioned in the above said policy. Which will attract the new investment in the state and generate more employment.</td>
                    <td>Private Industrial Park</td>
                    <td>500</td>
                    <td>5000</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>31</td>
                    <td>22000465</td>
                    <td>M/S BRAHHM ARPAN ORGANIC PVT. LTD</td>
                    <td>
                        C-30 SITE-C UPSIDC SURAJPUR,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201306
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>contact@health-fields.com</td>
                    <td>Raman Prabhakar</td>
                    <td>DIRECTOR</td>
                    <td>919810533995</td>
                    <td>FOOD PROCESSING UNIT</td>
                    <td>PROCESSING AND PACKING OF PULSES AND SPICES WHICH IS VERY ESSENTIAL ITEMS .</td>
                    <td>Food Processing</td>
                    <td>500</td>
                    <td>500</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>32</td>
                    <td>22000949</td>
                    <td>Dasnac Capital Private Limited</td>
                    <td>
                        Dasnac Annexe 1, ECE House, 28A, Kasturba Gandhi Marg, Delhi, Central Delhi DL 110001,Central Delhi, Delhi, India
                        Pin Code : 110001
                    </td>
                    <td>Delhi</td>
                    <td>legal@dasnac.com</td>
                    <td>Prateek Gupta</td>
                    <td></td>
                    <td>918800899431</td>
                    <td></td>
                    <td>Industrial Park at Sector 1,2 &amp; 3, Mandola Vihar Yojna (UPAVP)</td>
                    <td>Private Industrial Park</td>
                    <td>500</td>
                    <td>10000</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>33</td>
                    <td>23008179</td>
                    <td>PULASTYA INDUSTRIAL PARK LIMITED</td>
                    <td>
                        VILLAGE RAIPUR,INDUSTRIAL AREA, BHAGWANPUR, ROORKEE, HARIDWAR(UK),Haridwar, Uttarakhand, India
                        Pin Code : 247661
                    </td>
                    <td>Uttarakhand</td>
                    <td>industrialpark@pulastya.in</td>
                    <td>SAHAB SINGH PUNDIR</td>
                    <td>Director</td>
                    <td>919891410000</td>
                    <td>Private Industrial Park</td>
                    <td>Private Industrial Area Having a Investment of Around 500 crore with minimum 50 plants.</td>
                    <td>Private Industrial Park</td>
                    <td>500</td>
                    <td>5000</td>
                    <td>Saharanpur</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>34</td>
                    <td>23009030</td>
                    <td>Scalar Group</td>
                    <td>
                        6-3-679, 1st Floor, Elite Plaza,,Hyderabad, Telangana, India
                        Pin Code : 500082
                    </td>
                    <td>Telangana</td>
                    <td>gopal@scalarspaces.com</td>
                    <td>Dr Gopal Mor</td>
                    <td></td>
                    <td>989848055751</td>
                    <td>Multi Model Logistic Park</td>
                    <td>Multi Model Logistic Park at New Noida</td>
                    <td>Logistics and Warehousing </td>
                    <td>500</td>
                    <td>1250</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>35</td>
                    <td>23007063</td>
                    <td>Varun Beverages Ltd.</td>
                    <td>
                        lot No.31, Sector-44, Institutional Area, Gurgaon, Haryana -122002,Gurgaon, Haryana, India
                        Pin Code : 122002
                    </td>
                    <td>Haryana</td>
                    <td>kamlesh.jain@rjcorp.in</td>
                    <td>Kamlesh Kumar Jain</td>
                    <td>Executive Director and COO International</td>
                    <td>919811117276</td>
                    <td>Varun Beverages Limited, Bargarh II (Chitrakoot)</td>
                    <td>Setting up State of the Art Mega Plant for Manufacture of Fruit Pulp / Fruit Juice Based Drinks, Carbonated Soft Drinks, Beverages Base Syrup, Packaging Products &amp; Solar Power Project</td>
                    <td>Food Processing</td>
                    <td>496</td>
                    <td>250</td>
                    <td>Chitrakoot</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>36</td>
                    <td>22000322</td>
                    <td>M/s Kanodia Sells Pvt. Ltd</td>
                    <td>
                        PLOT NO.A-21, SECTOR-16 NOIDA,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201301
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>eamd@kanodiagroup.co.in</td>
                    <td>Shri Gautam Kanodia</td>
                    <td>Director</td>
                    <td>919717234893</td>
                    <td>CEMENT</td>
                    <td>KANODIA GROUP is one of the pioneers in the Cement Industry &amp; Building Material Trading. The company has been in operation in the cement industry for the last 30 years. The Group has rich experience in this industry as a retailer-dealer-distributor-sole selling agent and now as a manufacturer for the last 10 years. Our major Product range includes Portland Pozzolana Cement (PPC) and Ordinary Portland Cement (OPC)&#34;</td>
                    <td>Non metallic and mineral products </td>
                    <td>450</td>
                    <td>180</td>
                    <td>Bulandshahr</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>37</td>
                    <td>23010438</td>
                    <td>Information Technology</td>
                    <td></td>
                    <td></td>
                    <td>ajay@ekuber.com</td>
                    <td>Ajay Kumar Srivastava</td>
                    <td>President</td>
                    <td>7036241480</td>
                    <td>Information Technology Park</td>
                    <td>Lucknow and its satellite cities have a concentration of Educational Institutions that produce enormous number of High-Tech talents that cannot be absorbed within the Lucknow Metropolitan area. The area needs high tech industry network to retain and grow its talent. Sadly, big firms haven&#39;t done much in the last 10 years even after significant land resource allotment from state. We want to retain, grow and export the talent and its produce significantly on the lines of Bangalore and Hyderabad</td>
                    <td>Information Technology</td>
                    <td>410</td>
                    <td>3000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>38</td>
                    <td>23010436</td>
                    <td>Information Technology</td>
                    <td></td>
                    <td></td>
                    <td>ajay@ekuber.com</td>
                    <td>Ajay Kumar Srivastava</td>
                    <td>President</td>
                    <td>7036241480</td>
                    <td>Startup Incubation Center</td>
                    <td>We plan to establish a Lucknow based Incubation center in collaboration with US based Investors, Angel Groups and Educational Institutions. We will work with local UP Incubators to source investments from US while enabling market entry for the US market for the Incubator Startups. We will leverage Israel based technology companies. eKuber Principals have years of experience with startups in high technology environments such as ; Idicio.tech, Sorcero, PathOtrak and Maxwell etc.</td>
                    <td>Information Technology</td>
                    <td>410</td>
                    <td>800</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>39</td>
                    <td>22000476</td>
                    <td>M/s Eggro Paper Moulds Ltd. </td>
                    <td>
                        SURAJDEEP 1, JOPLING ROAD LUCKNOW 226001,Lucknow, Uttar Pradesh, India
                        Pin Code : 226001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>srivastavakklko@gmail.com</td>
                    <td>Kk Srivastava </td>
                    <td>Managing Director </td>
                    <td>919838071400</td>
                    <td>PAPER MANUFUCTURING</td>
                    <td>PAPER MANUFUCTURING</td>
                    <td>Paper Manufacturing</td>
                    <td>400</td>
                    <td>1200</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>40</td>
                    <td>22000034</td>
                    <td>JAYKAYCEM (CENTRAL) LIMITED (Wholly Owned Subsidiary of JK CEMENT LIMITED)</td>
                    <td>
                        JK CEMENT LIMITED CORPORATE OFFICE: 05TH FLOOR, PRISM TOWER, GWAL PAHARI,Gurgaon, Haryana, India
                        Pin Code : 122003
                    </td>
                    <td>Haryana</td>
                    <td>arun.sharma@jkcement.com</td>
                    <td>Arun Sharma</td>
                    <td>Senior General Manager - Corporate Affairs</td>
                    <td>919650765678</td>
                    <td>JAYKAYCEM (CENTRAL) WORKS, PRAYAGRAJ (UNIT OF JAYKAYCEM (CENTRAL) L TD</td>
                    <td>Jaykaycem (Central) Limited (JCL) is a wholly owned subsidiary of JK Cement Limited, which is the Cement vertical of the industrial conglomerate JK Organisation. JCL, thus, is an affiliate of the flagship JK Organisation. JCL intend to establish a Clinker Grinding Unit having capacity of 2.50 MTPA with the investment of Rs.400 Crores (around) in Tehsil Bara, District Prayagraj (Allahabad), UP. JCL is already in the process to purchase the required land.</td>
                    <td>Non metallic and mineral products </td>
                    <td>400</td>
                    <td>250</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>41</td>
                    <td>23010171</td>
                    <td>Marble Rocks VCC Fund Singapore</td>
                    <td></td>
                    <td></td>
                    <td>maneesh.tripathi@delteq.com.sg</td>
                    <td>Maneesh Tripathi</td>
                    <td>Promoter CEO</td>
                    <td>6590682064</td>
                    <td>Agro Processing Cluster (APC) X2 plants Mini Food Park with 5units</td>
                    <td>Agro Processing Cluster (APC) X2 plants Mini Food Park with 5units with 5 acres to 10 Acres land. Agro Processing Cluster with Processing of Green Peas, Potato, Tomato, Beans, Capsicum, Carrot. Ginger and Garlic Paste and Tomato Puree, Sugar cane packaged juice and Export and Domestic Sales</td>
                    <td>Agro Processing </td>
                    <td>400</td>
                    <td>500</td>
                    <td>Jhansi</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>42</td>
                    <td>22003940</td>
                    <td>RTKP HYGIENE &amp; NATURE CARE</td>
                    <td>
                        WH-96, PHASE-1 MAYAPURI INDUATRIAL AREA,South West Delhi, Delhi, India
                        Pin Code : 110064
                    </td>
                    <td>Delhi</td>
                    <td>rtkptissues@gmail.com</td>
                    <td>Sunil Pasrija</td>
                    <td>PROPRIETOR</td>
                    <td>919810582068</td>
                    <td>RTKP HYGIENE &amp; NATURE CARE</td>
                    <td>PRINTING PRESS, PACKAGING, AND UV PRINTING</td>
                    <td>Printing </td>
                    <td>393.71</td>
                    <td>69</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>43</td>
                    <td>22006711</td>
                    <td>SHIV SHANKAR INDUSTRIES,</td>
                    <td>
                        293 M Vill. Dhinanathpur Puthi Hasanpur Road Dasna ,Ghaziabad, Uttar Pradesh, India
                        Pin Code : 201015
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sstgzb@hotmail.com</td>
                    <td>Sunil Arora</td>
                    <td></td>
                    <td>919811166256</td>
                    <td></td>
                    <td>Develop Industrial Park</td>
                    <td>Private Industrial Park</td>
                    <td>350</td>
                    <td>500</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>44</td>
                    <td>22000150</td>
                    <td>M/S APEX WELCARE TRUST</td>
                    <td>
                        N-7/2 A-5, ,Varanasi, Uttar Pradesh, India
                        Pin Code : 221005
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>apex.vns@gmail.com</td>
                    <td>Dr S K Singh</td>
                    <td>MANAGING TRUSTEE</td>
                    <td>919415304103</td>
                    <td>HOSPITAL WITH COLLEGE</td>
                    <td>HOSPITAL WITH COLLEGE</td>
                    <td>College and Hospital</td>
                    <td>325</td>
                    <td>50</td>
                    <td>Mirzapur</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>45</td>
                    <td>22005317</td>
                    <td>J R Warehousing Pvt Ltd</td>
                    <td>
                        Hapur,Hapur, Uttar Pradesh, India
                        Pin Code : 245304
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>Rahulpkw2007@rediffmail.com</td>
                    <td>Rahul Garg</td>
                    <td>Director</td>
                    <td>919012333777</td>
                    <td>J R Warehousing Pvt Ltd.</td>
                    <td>Industrial Park</td>
                    <td>Private Industrial Park</td>
                    <td>300</td>
                    <td>3000</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>46</td>
                    <td>22002498</td>
                    <td>JAI BALB COMPANI LTD</td>
                    <td>
                        HETIMPUR, DISTT- DEORIA,Deoria, Uttar Pradesh, India
                        Pin Code : 274206
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>girishchandsrivastva9@gmail.com</td>
                    <td>Grish Chandra Srivastva</td>
                    <td>DIRECTOR</td>
                    <td>919839833183</td>
                    <td>M/s JAI BULB COMPANY LTD</td>
                    <td>ELECTRONIC AND ELECTIRCAL GOODS</td>
                    <td>Electrical equipment manufacturing </td>
                    <td>300</td>
                    <td>1000</td>
                    <td>Deoria</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>47</td>
                    <td>22000025</td>
                    <td>INOX Leisure Limited</td>
                    <td>
                        5th Floor, Viraj Towers, Next to Andheri Flyover,Mumbai City, Maharashtra, India
                        Pin Code : 400093
                    </td>
                    <td>Maharashtra</td>
                    <td>rachna.garg@inoxmovies.com</td>
                    <td>Rachna Garg</td>
                    <td>AVP Finance</td>
                    <td>919873010258</td>
                    <td>Multiplexes</td>
                    <td>Multiplexes for exhibition of movies</td>
                    <td>Multiplex</td>
                    <td>300</td>
                    <td>1000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>48</td>
                    <td>22006489</td>
                    <td>Sunfab Tex Pvt Ltd</td>
                    <td>
                        Hapur,Hapur, Uttar Pradesh, India
                        Pin Code : 245304
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>goel.sandeep.mait@gmail.com</td>
                    <td>Sandeep Goel</td>
                    <td></td>
                    <td>917011599078</td>
                    <td></td>
                    <td>
                        Industrial Park
                    </td>
                    <td>Private Industrial Park</td>
                    <td>300</td>
                    <td>3000</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>49</td>
                    <td>23008191</td>
                    <td>M/s Kanchan Metals Pvt Ltd</td>
                    <td>
                        D 9/3, Site V, Surajpur Industrial area,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201310
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sanjeev@snackfoodmachines.com</td>
                    <td>Mr Sanjeev Gupta</td>
                    <td>MD</td>
                    <td>9831744707</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>300</td>
                    <td>800</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>50</td>
                    <td>23008128</td>
                    <td>PASWARA INFRASTRUCTURE PVT LTD</td>
                    <td>
                        Paswara House, Baghpat Road, Meerut ,Meerut, Uttar Pradesh, India
                        Pin Code : 250002
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>vinodadvo1947@gmail.com</td>
                    <td>ARVIND AGARWAL</td>
                    <td>Director</td>
                    <td>919193723535</td>
                    <td>Private Industrial Park</td>
                    <td>Establishment of Private Industrial Park with all Facilities under U.P. Industrial Investment &amp; Employment Promotion Policy 2022.</td>
                    <td>Private Industrial Park</td>
                    <td>300</td>
                    <td>500</td>
                    <td>Meerut</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>51</td>
                    <td>23008298</td>
                    <td>ANITA DISTILLERY PVT LTD</td>
                    <td>
                        DASIA , SADAR, BASTI,Basti, Uttar Pradesh, India
                        Pin Code : 272150
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>rohanjaiswalrb@gmail.com</td>
                    <td>Rohan jaiswal</td>
                    <td></td>
                    <td>917355396179</td>
                    <td>ANITA DISTILLERY PVT LTD</td>
                    <td>ETHANOL , ENA AND BOTTLING DDGS</td>
                    <td>Biofuel</td>
                    <td>300</td>
                    <td>1500</td>
                    <td>Basti</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>52</td>
                    <td>22003349</td>
                    <td>M/S SUNRISE ENERGY </td>
                    <td>
                        B/80, NATH NAGAR, DEORIA,Deoria, Uttar Pradesh, India
                        Pin Code : 274001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>rishabh@sunriseenergy.in</td>
                    <td>Anand Sagar Tiwari</td>
                    <td>PROPRIETOR </td>
                    <td>919450685888</td>
                    <td>SOLOR POWER PLANT</td>
                    <td>SOLAR POWER PLANT NEW UNIT SETUP IN INDUSTRIAL AREA UTELWA, AMETHI</td>
                    <td>Renewbale Energy</td>
                    <td>255</td>
                    <td>800</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>53</td>
                    <td>22000434</td>
                    <td>RACL Geartech Ltd </td>
                    <td>
                        Corporate Office: B-9, Sector-3, Noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201301
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>gsingh@raclgeartech.com</td>
                    <td>Gursharan Singh</td>
                    <td>CMD</td>
                    <td>919811072255</td>
                    <td>RACL Vision 2027</td>
                    <td>RACL Vision 2027 is an ambitious but well conceptualized expansion plan of RACL Geartech Limited to place itself in the premium league of Automobile Industry. The detailed project report is attached which explains the project requirements and projections made by the Company.</td>
                    <td>Automobile</td>
                    <td>250</td>
                    <td>2000</td>
                    <td>Amroha</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>54</td>
                    <td>22000369</td>
                    <td>SUMAN FORWARDING AGENCY PVT. LTD.</td>
                    <td>
                        76, G.T. Road (South) Howrah - 711101,Howrah, West Bengal, India
                        Pin Code : 711101
                    </td>
                    <td>West Bengal</td>
                    <td>amiteshsing@yahoo.co.in</td>
                    <td>Amitesh Singh</td>
                    <td>CEO</td>
                    <td>919836169999</td>
                    <td>PRIVATE FREIGHT TERMINAL NEAR SARASWATI HIGHTECH CITY</td>
                    <td>PROPOSED PRIVATE FREIGHT TERMINAL ALONG WITH RAILSIDE WAREHOUSES, CONTAINER STOCKYARDS, STOCKARDS, OPEN AND COVERED</td>
                    <td>Logistics and Warehousing </td>
                    <td>250</td>
                    <td>1200</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>55</td>
                    <td>22000305</td>
                    <td>Inovatiq Engineering Private Limited</td>
                    <td>
                        Plot No C 120,Baghpat, Uttar Pradesh, India
                        Pin Code : 250609
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>inovatiq@gmail.com</td>
                    <td>Ashwani Sharma</td>
                    <td>Director</td>
                    <td>919811249215</td>
                    <td>Inovatiq Engineering Private Limited</td>
                    <td>new project for manufacturing of all type of Steel Wheel Rim</td>
                    <td>Automobile</td>
                    <td>250</td>
                    <td>300</td>
                    <td>Baghpat</td>
                    <td>TDS City</td>
                </tr>
                <tr>
                    <td>56</td>
                    <td>22006083</td>
                    <td>PepsiCo India Holdings Pvt Ltd</td>
                    <td>
                        PepsiCo India Holdings Pvt. Ltd.,Gurgaon, Haryana, India
                        Pin Code : 122001
                    </td>
                    <td>Haryana</td>
                    <td>rahulbmsharma@gmail.com</td>
                    <td>Rahul Sharma</td>
                    <td>Associate Director</td>
                    <td>919368333323</td>
                    <td></td>
                    <td>Foods Expansion</td>
                    <td>Food Processing</td>
                    <td>250</td>
                    <td>350</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>57</td>
                    <td>23008197</td>
                    <td>M/s Kanchan Metals Pvt Ltd</td>
                    <td>
                        D 9/3, Site V, Surajpur Industrial area,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201310
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sanjeev@snackfoodmachines.com</td>
                    <td>Mr Sanjeev Gupta</td>
                    <td>MD</td>
                    <td>9831744707</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>250</td>
                    <td>700</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>58</td>
                    <td>22006496</td>
                    <td>PREMIER ROADLINES LIMITED</td>
                    <td>
                        B-870, NEAR CHURCH,East Delhi, Delhi, India
                        Pin Code : 110096
                    </td>
                    <td>Delhi</td>
                    <td>VIRENDERGUPTA@PRLINDIA.COM</td>
                    <td>VIRENDER GUPTA</td>
                    <td></td>
                    <td>919911665992</td>
                    <td>DIRECTOR</td>
                    <td>LOGISTICS PARK YAMUNA AUTHORITY</td>
                    <td>Logistics and Warehousing </td>
                    <td>217</td>
                    <td>464</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>59</td>
                    <td>22000248</td>
                    <td>SUKSHMATANU FMCG PRODUCTS PRIVATE LIMITED</td>
                    <td>
                        CF-187 ANGAL EAST LONI, GHAZIABAD UP 201103,Ghaziabad, Uttar Pradesh, India
                        Pin Code : 201103
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>tyagi.sachin@ymail.com</td>
                    <td>Sachin</td>
                    <td>DIRECTOR</td>
                    <td>918527858277</td>
                    <td>FMCG PRODUCTS</td>
                    <td>FMCG PRODUCTS AND OTHER ALLIED PRODUCTS</td>
                    <td>FMCG</td>
                    <td>216.93</td>
                    <td>15</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>60</td>
                    <td>22000503</td>
                    <td>RAMAYA DISTILLERIES &amp; BOTTLERS PVT. LTD </td>
                    <td>
                        VILL- LATHAUR POST- JAURA , KASIA KUSHINAGAR ,Kushinagar, Uttar Pradesh, India
                        Pin Code : 274401
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>ramayadistilleries@gmail.com</td>
                    <td>Dilip Shahi</td>
                    <td>DIRECTOR</td>
                    <td>919450165008</td>
                    <td>ETHANOL MANUFACTURING</td>
                    <td>MANUFACTURING OF ENA , ETHANOL, DDGIOUS , CO2 AND 8 LINE BOTTELING , IMFL AND CL</td>
                    <td>Biofuel</td>
                    <td>211.02</td>
                    <td>1500</td>
                    <td>Kushinagar</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>61</td>
                    <td>22004250</td>
                    <td>PREET MACHINES LIMITED</td>
                    <td>
                        64, PUSHPANJALI, KARKARDOOMA ,East Delhi, Delhi, India
                        Pin Code : 110092
                    </td>
                    <td>Delhi</td>
                    <td>sd@preetgroup.com</td>
                    <td>Gurmeet Singh Chauhan</td>
                    <td>DIRECTOR</td>
                    <td>918178381656</td>
                    <td>PREET MACHINES LIMITED</td>
                    <td>
                        MANUFACTURING OF EQUIPMENTS FOR DEFENCE, AEROSPACE, NAVAL, RAILWAYS, OIL &amp; GAS, INDUSTRIAL MACHINERY, ENERGY, STEEL ROLLING MILL PLANT &amp; EQUIPMENT SUCH AS, MANUFACTURING OF GEAR BOXES, MILL STANDS, COOLING BED, SHEARS, PINCH ROLLS, TWIN CHANNELS, ETC. AT ALIYABAD, TRANS DELHI SIGNATURE CITY, DISTT. â€“ GHAZIABAD,
                        PIN CODE - 201102
                    </td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>206</td>
                    <td>1400</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>62</td>
                    <td>23008259</td>
                    <td>DKD IKJOT UNITED PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>info@ikjotunited.com</td>
                    <td>IKJOT SINGH CHOUHAN</td>
                    <td>DIRECTOR</td>
                    <td>919311688026</td>
                    <td>DKD IKJOT UNITED PRIVATE LIMITED</td>
                    <td>
                        CNC LATHE MACHINE, VTL MACHINE, NOTCHING AND BRANDING MACHINE, CNC TURNING MACHINE CENTRE, CNC GRINDING MACHINE &amp; SPARES OF CNC MACHINE, AT ALIYABAD, TRANS DELHI SIGNATURE CITY, DISTT. â€“ GHAZIABAD, PIN CODE -
                        201102
                        1ST CHOICE - ALIYABAD, TRANS DELHI SIGNATURE CITY, DISTT. â€“ GHAZIABAD
                        2ND CHOICE - SURAJPUR INDUSTRIAL AREA, DISTT. GAUTAM BUDDHA NAGAR
                        3RD CHOICE - DHAULANA INDUSTRIAL AREA OR ANY OTHER AREA IN HAPUR DISTRICT
                    </td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>206</td>
                    <td>1400</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>63</td>
                    <td>22003445</td>
                    <td>PULASTAYA INDIA PRIVATE LIMITED</td>
                    <td>
                        KHASRA NO 197A AND 200KA MALSI POST SINOLA DEHARADUN UTTRAKHAND ,Dehradun, Uttarakhand, India
                        Pin Code : 248001
                    </td>
                    <td>Uttarakhand</td>
                    <td>pulastayaindiapvtltd5@gmail.com</td>
                    <td>Yogesh Pundir</td>
                    <td>DIRECTOR</td>
                    <td>919634026387</td>
                    <td>Mehrshi Pulastya Industrial Area</td>
                    <td>Private Industrial Area Having a Investment of Around 200 crore with minimum 50 plants.</td>
                    <td>Private Industrial Park</td>
                    <td>200</td>
                    <td>2000</td>
                    <td>Saharanpur</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>64</td>
                    <td>22002079</td>
                    <td>M/S SKYLARK FEEDS PVT LTD. </td>
                    <td>
                        VILL. &amp; POST- KHERA KHEMAWATI TEHSIL-SAFIDON, DISTT-JIND, HARYANA-126112,Jind, Haryana, India
                        Pin Code : 126112
                    </td>
                    <td>Haryana</td>
                    <td>legal@skylarkfeeds.com</td>
                    <td>Nitesh Dhull</td>
                    <td>DIRECTOR</td>
                    <td>919050012395</td>
                    <td>POULTARY FEED MILL</td>
                    <td>NEW POULTARY FEED MILL UNIT SETUP ON PLOT NO.-A-3, AREA -33673 SQM, SECTOR-22, I.A. JAGDISHPUR. AMETHI</td>
                    <td>Agro Processing </td>
                    <td>200</td>
                    <td>500</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>65</td>
                    <td>22002053</td>
                    <td>M/s Royal Height Dev. Pvt Ltd </td>
                    <td>
                        106/38, NAZAR BAGH LUCKNOW ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>farhanfarhan1713@gmail.com</td>
                    <td>Sri Aleem Ahamad </td>
                    <td>MD </td>
                    <td>919919111129</td>
                    <td>HATTECHERY CATTLE FEED MILLS AND BREIDING</td>
                    <td>HATTECHERY CATTLE FEED MILLS AND BREIDING NEW UNIT WILL BE SETUP INDUSTRIAL AREA JAGDISHPUR AMETHI</td>
                    <td>Agro Processing </td>
                    <td>200</td>
                    <td>1000</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>66</td>
                    <td>22000260</td>
                    <td>Avadh Sugar &amp; Energy Limited, Unit- new india sugar mills</td>
                    <td>
                        AVADH SUGAR AND ENERGY LMITED, UNIT- NEW INDIA SUGAR MILLS ,Kushinagar, Uttar Pradesh, India
                        Pin Code : 274207
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>goenkapg1goenka@rediffmail.com</td>
                    <td>Pankaj Kumar Goenka</td>
                    <td>Executive Vice President</td>
                    <td>919984093333</td>
                    <td>ETHANOL PRODUCING UNIT</td>
                    <td>BIOFUELS/BIOMASS</td>
                    <td>Biofuel</td>
                    <td>200</td>
                    <td>350</td>
                    <td>Kushinagar</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>67</td>
                    <td>22000249</td>
                    <td>GOPAL AGRO INDUSTRIES</td>
                    <td>
                        GOPAL AGRO INDUSTRIES, PLOT NO. D-96 AT UPSIDC INDUSTRIAL AREA KHALILABAD, SANT KABIR NAGAR-272175,Sant Kabir Nagar, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>gopalagro.santkavirnagar@gmail.com</td>
                    <td>Narayan Singh</td>
                    <td>DIRECTOR</td>
                    <td>919936402149</td>
                    <td>ETHNOL AND BOTTLING PLANT</td>
                    <td>CHEMICAL INDUSTRY</td>
                    <td>Chemical Manufacturing</td>
                    <td>200</td>
                    <td>400</td>
                    <td>Maharajganj</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>68</td>
                    <td>22006495</td>
                    <td>DP World</td>
                    <td>
                        Dubai,Dubai, Dubai, 0
                        Pin Code : 500001
                    </td>
                    <td>UAE</td>
                    <td>anil.mohta@dpworld.com</td>
                    <td>Anil Mohta</td>
                    <td></td>
                    <td>97148080708</td>
                    <td>Senior Vice President Group Corporate Finance &amp; Business Development</td>
                    <td>ICD, PFT &amp; MMLP</td>
                    <td>Logistics and Warehousing </td>
                    <td>200</td>
                    <td>1000</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>69</td>
                    <td>23010394</td>
                    <td>CITIZEN INFRAVENTURES PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>NISHITHVERMA.CITIZEN@GMAIL.COM</td>
                    <td>NISHITH VERMA</td>
                    <td>DIRECTOR</td>
                    <td>918601458555</td>
                    <td>CITIZEN SMALL SCALE INDUSTRIAL PARK</td>
                    <td>TO DEVELOP SMALL SCALE INDUSTRIAL PARK WITH THE HELP PRIVATE INVESTORS.</td>
                    <td>Private Industrial Park</td>
                    <td>200</td>
                    <td>500</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>70</td>
                    <td>22000006</td>
                    <td>S.R. CONCAST PRIVATE LIMITED</td>
                    <td>
                        D-74/2 LOHA MANDI , GHAZIABAD ,Ghaziabad, Uttar Pradesh, India
                        Pin Code : 201001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>SRCONCASTPVTLTD@GMAIL.COM</td>
                    <td>Ashish Agarwal</td>
                    <td>DIRECTOR</td>
                    <td>918527048129</td>
                    <td>S.R. CONCAST PRIVATE LIMITED</td>
                    <td>MANUFACTURING OF T.M.T BARS , STEEL LONG AND WIRE ROD THROUGH INDUCTION FURNACES AND ROLLING MILL</td>
                    <td>Casting of metals</td>
                    <td>175</td>
                    <td>550</td>
                    <td>Jalaun</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>71</td>
                    <td>22000773</td>
                    <td>Indo World Spaces</td>
                    <td>
                        Indo World Spaces Khasra No 159, Village Bahmandpur, Reliance Road,Hapur, Uttar Pradesh, India
                        Pin Code : 245304
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>data99hub@gmail.com</td>
                    <td>Saurabh Kansal</td>
                    <td>Partner</td>
                    <td>919560581849</td>
                    <td>INDO WORLD SPACES</td>
                    <td>Warehousing &amp; Logistics</td>
                    <td>Logistics and Warehousing </td>
                    <td>170</td>
                    <td>5000</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>72</td>
                    <td>22006292</td>
                    <td>DRS DEVLOPERS</td>
                    <td>
                        N 8/180 H.I.R Rajendra Vihar Colony , Sunderpur , Varanasi,Chandauli, Uttar Pradesh, India
                        Pin Code : 232104
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>Devbhattacharya1@gmail.com</td>
                    <td>Dev Bhattacharya</td>
                    <td></td>
                    <td>919415204144</td>
                    <td>Partner</td>
                    <td>FORMATION AND DEVELOPMENT OF PRIVATE INDUSTRIAL ESTATE / PARK</td>
                    <td>Private Industrial Park</td>
                    <td>169</td>
                    <td>15000</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>73</td>
                    <td>23009438</td>
                    <td>NANAK LOGISTICS PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>info@lucknowlogistics.com</td>
                    <td>ANAND KUMAR AGARWAL</td>
                    <td>DIRECTOR</td>
                    <td>919919923999</td>
                    <td>NANAK LOGISTICS</td>
                    <td>New Logistics unit to be developed at Village- Bhaukapur, Tehsil - Sarojini Nagar, Mohan Road, Lucknow. The proposed project has total land area of 131133 Sq mt with ground coverage of 77493.36 sq mt and FAR of 84994.94 Sq mt. The Total estimated Investment / cost of the proposed project is Rs 155.97 Crores.</td>
                    <td>Logistics and Warehousing </td>
                    <td>155.9</td>
                    <td>4000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>74</td>
                    <td>23010359</td>
                    <td>M/s Shanti Lal Glass Industries Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>jain.abhi1983@gmail.com</td>
                    <td>Mr Abhishek Jain</td>
                    <td>Director</td>
                    <td>919927140000</td>
                    <td>Manufacturing All Types of Glass wares etc</td>
                    <td>Manufacturing All Types of Glass wares etc</td>
                    <td>Non metallic and mineral products </td>
                    <td>155</td>
                    <td>125</td>
                    <td>Firozabad</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>75</td>
                    <td>22000261</td>
                    <td>Reliable papteq llp</td>
                    <td>
                        D2 sector 63 noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 20131
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>info@relpackaging.com</td>
                    <td>Nikhil Sipani </td>
                    <td>Partner</td>
                    <td>919871052664</td>
                    <td>Reliable Papteq LLP</td>
                    <td>
                        Name of company : Reliable Papteq LLP_x000D_
                        Name of Partner : Mr Nikhil Sipahi_x000D_
                        And Mr Yogendra Kumar Mishra._x000D_
                        Cost of project : 152 crore_x000D_
                        No of employment : 500_x000D_
                        Power requirements : 03 megawatt
                    </td>
                    <td>Packaging</td>
                    <td>152</td>
                    <td>500</td>
                    <td>Sambhal</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>76</td>
                    <td>22001923</td>
                    <td>SADAY INDUSTRIES PRIVATE LIMITED</td>
                    <td>
                        1/13/291, Civil Lines, Police Line ward, Tehseel Road,Ayodhya, Uttar Pradesh, India
                        Pin Code : 224001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sadayindustriespvtltd@gmail.com</td>
                    <td>Praveen Kumar Singh</td>
                    <td>DIRECTOR</td>
                    <td>919839949000</td>
                    <td>100 KLPD TS Grain based distillery plant</td>
                    <td>To set up a unit to manufacture Ethanol, Rectified Spirit, extra neutral alcohol, and denatured spirit.</td>
                    <td>Biofuel</td>
                    <td>150</td>
                    <td>100</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>77</td>
                    <td>22000767</td>
                    <td>LOGI INTERNATIONAL</td>
                    <td>
                        Khasra No 538, Village Madapur, Reliance Road,Hapur, Uttar Pradesh, India
                        Pin Code : 245304
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sunliteacct@gmail.com</td>
                    <td>Neeraj Goel</td>
                    <td>PARTNER</td>
                    <td>919999889355</td>
                    <td>Logi International</td>
                    <td>Warehouse Industry</td>
                    <td>Logistics and Warehousing </td>
                    <td>150</td>
                    <td>5000</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>78</td>
                    <td>22000246</td>
                    <td>SSKIA AGROTECH (OPC) PRIVATE LIMITED</td>
                    <td>
                        DUMARIA LALA, KHUSWAHAN POST-PERSIA MISHRA, DISTT.-DEORIA-274501,Deoria, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>satyaveer.1989yadav@gmail.com</td>
                    <td>Satyaveer Yadav</td>
                    <td>DIRECTOR</td>
                    <td>919867119658</td>
                    <td>SUPER FERTILIZER 202013</td>
                    <td>MANUFACTURING</td>
                    <td>Chemical Manufacturing</td>
                    <td>150</td>
                    <td>400</td>
                    <td>Maharajganj</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>79</td>
                    <td>22000002</td>
                    <td>Mirza international ltd</td>
                    <td>
                        14/6 civil lines ,Kanpur Nagar, Uttar Pradesh, India
                        Pin Code : 1
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>upadhyay@redtapeindia.com</td>
                    <td>Narandra Prasad .Upadhyay</td>
                    <td>Director</td>
                    <td>919935002205</td>
                    <td>Mirza international ltd -RED TAPE</td>
                    <td>Expansion of the capacity both for manufacturing and warehousing.</td>
                    <td>Leather and Footwear</td>
                    <td>150</td>
                    <td>1500</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>80</td>
                    <td>23008830</td>
                    <td>Jeevan Developer</td>
                    <td>
                        259/3, 259/4 Rawli village hapur,Hapur, Uttar Pradesh, India
                        Pin Code : 201015
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>ssplgroup65@gmail.com</td>
                    <td>Sanjeev Goel</td>
                    <td></td>
                    <td>919136773862</td>
                    <td>Jeevan Developer</td>
                    <td>Industrial Park</td>
                    <td>Private Industrial Park</td>
                    <td>150</td>
                    <td>500</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>81</td>
                    <td>23008808</td>
                    <td>LUCKNOW H M GREEN CITY PVT. LTD.</td>
                    <td>
                        B 3 FALAT NO. 204, SHALIMAR MANNAT SAFEDABAD BARABANKI UP ,Barabanki, Uttar Pradesh, India
                        Pin Code : 225001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>INDOSPUNTEX@GMAIL.COM</td>
                    <td>SHAHID MUKHTAR</td>
                    <td></td>
                    <td>919839055859</td>
                    <td>LUCKNOW H M GREEN CITY PVT. LTD.</td>
                    <td>Private Textiles/ Industrial Park (PPP) Site Office- Village Bhuhera, Safedabad Barabanki U.P.</td>
                    <td>Private Industrial Park</td>
                    <td>150</td>
                    <td>200</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>82</td>
                    <td>23009162</td>
                    <td>Jai Jagdamba Metalloys Ltd.</td>
                    <td></td>
                    <td></td>
                    <td>u.j1993@Yahoo.com</td>
                    <td>Utkarsh Jaiswal</td>
                    <td>Director</td>
                    <td>918299606762</td>
                    <td>Manufacturing of TMT Bar</td>
                    <td>Manufacturing of TMT Bar</td>
                    <td>Casting of metals</td>
                    <td>150</td>
                    <td>450</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>83</td>
                    <td>22003069</td>
                    <td>M/s VINDAS BIOREFINERY PRIVATE LIMITED</td>
                    <td>
                        Rajpoot Complex ICICI Bank III Floor District- Amethi ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>amantraders.amethi@gmail.com</td>
                    <td>Ashok Kumar Singh</td>
                    <td>Director </td>
                    <td>918004927200</td>
                    <td>Refinery Unit</td>
                    <td>Manufacturing of Ethanol/ENA from Gress, Sugarcane, molasses &amp; Argo base Plant, Leaf &amp; Grass</td>
                    <td>Biofuel</td>
                    <td>130</td>
                    <td>750</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>84</td>
                    <td>22000534</td>
                    <td>Sadani overseas</td>
                    <td>
                        SADANI COMPOUND,Aligarh, Uttar Pradesh, India
                        Pin Code : 202001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sadanis@hotmail.com</td>
                    <td>Pawan Sadani</td>
                    <td>Proprietor</td>
                    <td>919412239909</td>
                    <td>SADANI OVERSEAS</td>
                    <td>BRASS HARDWARE , LOCKS AND OEM PROJECTS FOR AUTO AND DEFENCE</td>
                    <td>Casting of metals</td>
                    <td>125</td>
                    <td>80</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>85</td>
                    <td>22000772</td>
                    <td>Capital logistic &amp; warehousing llp</td>
                    <td>
                        khasra no 524 villagae madapur,tehsil dhaulana hapur,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 245101
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>saurabh.k.mait@gmail.com</td>
                    <td>Saurabh Kansal</td>
                    <td>Partner</td>
                    <td>919311360880</td>
                    <td>Capital logistic &amp; warehousing</td>
                    <td>Warehousing</td>
                    <td>Logistics and Warehousing </td>
                    <td>110</td>
                    <td>2000</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>86</td>
                    <td>22000079</td>
                    <td>Shri Ji Steel</td>
                    <td>
                        5 Shyam Enclave, Near Leela Hotel, Delhi - ,Diu, Delhi, India
                        Pin Code
                    </td>
                    <td>Delhi</td>
                    <td>info@shrijistamping.com</td>
                    <td>Chavi Jain</td>
                    <td>Partner</td>
                    <td>918130031161</td>
                    <td>Motor Stampings</td>
                    <td>Manufacturing of Motor Stampings and Laminations for Motors and Pumps</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>110</td>
                    <td>300</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>87</td>
                    <td>22000804</td>
                    <td>SAGARI LEATHERS PVT. LTD.</td>
                    <td>
                        17, KUCHA CHAUDHARY,New Delhi, Delhi, India
                        Pin Code : 110006
                    </td>
                    <td>Delhi</td>
                    <td>sagari@sagarileathers.com</td>
                    <td>Prasenjit Kumar Gupta</td>
                    <td>DIRECTOR</td>
                    <td>919837054362</td>
                    <td>Finished Leather Footwear and Goods</td>
                    <td>We are Manufacturer and Exporter of Highest Level of Shoes and Shoe Uppers. Our international customers rely on more than our 40 Yrs of experience with quality footwear production for German Market. Company needs to increase the production capacity for FOOTWEAR MANUFACTURING and more towards Generating Employment.</td>
                    <td>Leather and Footwear</td>
                    <td>102</td>
                    <td>1000</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>88</td>
                    <td>22003313</td>
                    <td>M/S INTERWEAVE POLYTES PVT LTD </td>
                    <td>
                        M/s Interweave Polytex Pvt Ltd , Plot NO A-3 Sector-20 Industrial Area Jagdishpur District- Amethi ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>office.raspoly@gmail.com</td>
                    <td>Sri R K Chaudhary </td>
                    <td>PROMOTER </td>
                    <td>919415137187</td>
                    <td>P P Woven Sacks Begs</td>
                    <td>PP Woven Sacks Bags Manufacturing in Industrial Area Amethi</td>
                    <td>Plastic Manufacturing </td>
                    <td>100</td>
                    <td>480</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>89</td>
                    <td>22002306</td>
                    <td>M/S SHAKUNTALAM INDUSTRIES </td>
                    <td>
                        M/s Shakuntalam Industries 3/8 wazir Hasan Road Lucknow -226001,Lucknow, Uttar Pradesh, India
                        Pin Code : 226001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>shakuntalam.lko@gmail.com</td>
                    <td>Isha Gupata </td>
                    <td>PARTNER </td>
                    <td>919415402002</td>
                    <td>Particle Board Manufacturing</td>
                    <td>Particle Board Manufacturing unit is depending agricultural wasted &amp; Ply wasted Unit</td>
                    <td>Recycling </td>
                    <td>100</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>90</td>
                    <td>22002133</td>
                    <td>M/s Jai Dayal Packaging (P) Ltd </td>
                    <td>
                        M/s Jai Dayal Packaging (P) Ltd Plot No A-4/7 Scetor -20 I.AJagadishpur District- Amethi ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>puneet.tulsyan@gmail.com</td>
                    <td>Puneet Tulsyan </td>
                    <td>Director </td>
                    <td>919453330222</td>
                    <td>P P Bags Manufacturing</td>
                    <td>M/s Jai Dayal Pacaking Pvt Ltd unit of P P Bags Manufacturing in IA Jagadishpur Plot No A-4/7 Sector -20 Jagadishpur District- Ameth New land for setup New Unit</td>
                    <td>Plastic Manufacturing </td>
                    <td>100</td>
                    <td>350</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>91</td>
                    <td>22001911</td>
                    <td>Viraj autolink pvt ltd</td>
                    <td>
                        KHASRA NO 185 AMARPUR LODHA, TEHSIL DHAULANA DIST HAPUR,Hapur, Uttar Pradesh, India
                        Pin Code : 245101
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>apurv.kansal@poysha.in</td>
                    <td>Apurv Kansal</td>
                    <td>Director</td>
                    <td>919650299313</td>
                    <td>VIRAJ AUTOLINK PVT LTD</td>
                    <td>INDUSTRIAL PARK</td>
                    <td>Private Industrial Park</td>
                    <td>100</td>
                    <td>3500</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>92</td>
                    <td>22001882</td>
                    <td>Diyalandcraftpvt.ltd</td>
                    <td>
                        khasra no 1401/2. village khera tehsil dhaulana dist hapur,Hapur, Uttar Pradesh, India
                        Pin Code : 245101
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>shashwatgoel98@gmail.com</td>
                    <td>Shashwat Goel</td>
                    <td>Director</td>
                    <td>919999889367</td>
                    <td>Diya land craft pvt ltd</td>
                    <td>industrial park</td>
                    <td>Private Industrial Park</td>
                    <td>100</td>
                    <td>4500</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>93</td>
                    <td>22000568</td>
                    <td>M/s Rajesh Masala Udyog Pvt. Ltd </td>
                    <td>
                        RAIPUR FULWARI AMETHI,Amethi, Uttar Pradesh, India
                        Pin Code : 227405
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>mishraarun01@gmail.com</td>
                    <td>Rajesh Kumar Agrahari</td>
                    <td>Director</td>
                    <td>919792186600</td>
                    <td>MASALA UDYOG</td>
                    <td>NEW EXPENSION UNIT IN JAGDISHPUR 10 ACRE</td>
                    <td>Food Processing</td>
                    <td>100</td>
                    <td>400</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>94</td>
                    <td>22000156</td>
                    <td>M/s Gunno Knits Pvt Ltd</td>
                    <td>
                        Delhi,Faridabad, Haryana, India
                        Pin Code : 121001
                    </td>
                    <td>Delhi</td>
                    <td>sandeep@gunnoknits.com</td>
                    <td>Sandeep Goyal</td>
                    <td>Director</td>
                    <td>919899987601</td>
                    <td>Spining</td>
                    <td>Mfg of Spining</td>
                    <td>Textile </td>
                    <td>100</td>
                    <td>400</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>95</td>
                    <td>22000101</td>
                    <td>Indraprastha Gas Limited </td>
                    <td>
                        Igl bhawan, plot no 4, community centre ,New Delhi, Delhi, India
                        Pin Code : 1
                    </td>
                    <td>Delhi</td>
                    <td>santhosh.p@igl.co.in</td>
                    <td>Santhosh P </td>
                    <td>Dy.General manager </td>
                    <td>919810111095</td>
                    <td>INDRAPRASTHA GAS LIMITED CGD</td>
                    <td>CGD BUSINESS IN NOIDA, GR NOIDA MUZAFFARNAGAR,KANPUR, FATEH PUR, HAMIRPUR,</td>
                    <td>Electricity, Gas, Steam and Aircondition Supply</td>
                    <td>100</td>
                    <td>50</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>96</td>
                    <td>22000058</td>
                    <td>M/s P K LS Industries Pvt Ltd</td>
                    <td>
                        A-078, Sector-37, Greator Noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201308
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>profpksingh@gmail.com</td>
                    <td>Dr Pramod Kumar Singh</td>
                    <td>Director</td>
                    <td>919575058348</td>
                    <td>Bio CNG</td>
                    <td>BIO CNG Production from Agro waste and cow dung</td>
                    <td>Biofuel</td>
                    <td>100</td>
                    <td>200</td>
                    <td>Mainpuri</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>97</td>
                    <td>23009156</td>
                    <td>Dale promoters India pvt Ltd</td>
                    <td>
                        432/49 kala kakar coloney,Lucknow, Uttar Pradesh, India
                        Pin Code : 226007
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>dalegroup032011@gmail.com</td>
                    <td>Tushar Gupta</td>
                    <td></td>
                    <td>918090367831</td>
                    <td>Indtech park</td>
                    <td>Indtech park Lucknow</td>
                    <td>Private Industrial Park</td>
                    <td>100</td>
                    <td>3000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>98</td>
                    <td>23010258</td>
                    <td>Satvik Logistics LLP</td>
                    <td></td>
                    <td></td>
                    <td>kuldeep.bhatnagar@satviklogistics.com</td>
                    <td>Vaibhav Rathi </td>
                    <td>Executive Director</td>
                    <td>919650222823</td>
                    <td>DHARINI ESTATES</td>
                    <td>WE WILL BUILD AN AGRICULTURAL WAREHOUSE OF 50,000 SQUARE METER AND LEASE IT FOR STORING AGRICULTURAL PRODUCE</td>
                    <td>Logistics and Warehousing </td>
                    <td>100</td>
                    <td>20</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>99</td>
                    <td>22001704</td>
                    <td>GENESUS AGRO (P) LTD.</td>
                    <td>
                        C-22/25 SECTOR-57, NOIDA-201301,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>logisticsunnao@aovexports.com</td>
                    <td>Surendra Nath Sahu</td>
                    <td>VICE PRESIDENT</td>
                    <td>918081123005</td>
                    <td>SLAUGHTER HOUSE</td>
                    <td>MEAT PROCESSING UNIT</td>
                    <td>Food Processing</td>
                    <td>90</td>
                    <td>500</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>100</td>
                    <td>23008337</td>
                    <td>Apex enterprises</td>
                    <td>
                        D-35, Upper ground floor, omaxe india trade centre, Alpha-2, Greater noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201308
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>niketabhati1998@gmail.com</td>
                    <td>Niketa bhati</td>
                    <td></td>
                    <td>919891230077</td>
                    <td>APEX ENTERPRISES</td>
                    <td>Transporting, supplying and delivering goods with storage.</td>
                    <td>Logistics and Warehousing </td>
                    <td>86</td>
                    <td>98</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>101</td>
                    <td>22001638</td>
                    <td>VRY LOGISTIC PARK LLP</td>
                    <td>
                        29/2 , Vijay Enclave, Main Palam Dabri Road, ,West Delhi, Delhi, India
                        Pin Code : 110045
                    </td>
                    <td>Delhi</td>
                    <td>bishan.yadav@fws.co.in</td>
                    <td>Vikas Yadav</td>
                    <td>Partner</td>
                    <td>919899988971</td>
                    <td>FWS LOGISTIC PARK</td>
                    <td>
                        The project is conceived as a vision to develop a Logistic Park facility by VRY Logistics Park LLP. The proposed facility will have been an organized warehouse solution to cater to the emerging needs._x000D_
                        The proposed facility is located in Sikandrabad Uttar Pradesh on national highway 34. It has a good connectivity and is easily approachable from adjacent cities of NCR
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>83.16</td>
                    <td>200</td>
                    <td>Bulandshahr</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>102</td>
                    <td>22001383</td>
                    <td>KM SUGAR MILLS LIMITED</td>
                    <td>
                        II, MOTI BHAWAN COLLECTORGANJ KANPUR UP,Ayodhya, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>edkmsm@gmail.com</td>
                    <td>Subhash Chandra Aggarwala </td>
                    <td>EXECUTIVE DIRECTOR </td>
                    <td>917571000521</td>
                    <td>BIO GAS, REFINERY</td>
                    <td>SETTING UP A NEW PLANT FOR BIO GAS &amp; SETTING UP REFINERY PLANT FOR SUGUR</td>
                    <td>Biofuel</td>
                    <td>80</td>
                    <td>100</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>103</td>
                    <td>22000633</td>
                    <td>Shikhar foods pvt ltd </td>
                    <td>
                        Ward no 7, GHANSHYAM NAGAR, NAUTANWA, Maharajganj ,Maharajganj, Uttar Pradesh, India
                        Pin Code : 273164
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>nikhil.anand@hotmail.com</td>
                    <td>Nikhil Anand </td>
                    <td>CEO</td>
                    <td>918400700551</td>
                    <td>Ethanol project</td>
                    <td>Grain based ethanol plant</td>
                    <td>Biofuel</td>
                    <td>80</td>
                    <td>400</td>
                    <td>Maharajganj</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>104</td>
                    <td>22000132</td>
                    <td>M/s Plaza Crystal Industries</td>
                    <td>
                        Plot No B-2 Industrial Area UPSIDA Firozabad,Firozabad, Uttar Pradesh, India
                        Pin Code : 283203
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>2012.guddu.plaza@gmail.com</td>
                    <td>Uma Shankar Gupta</td>
                    <td>Proprietor</td>
                    <td>919412722891</td>
                    <td>Plastic manufacturing</td>
                    <td>
                        Articles made from Plastic materials are widely used in every sphere of life. It is known that the thermoplastics like polystyrene, polyethylene,_x000D_
                        polyethylene terephthalate (PET), acrylic, PVC cellulose acetate/butyrate etc. are very common nowadays and lots of articles are being manufactured_x000D_
                        from these materials.
                    </td>
                    <td>Plastic Manufacturing </td>
                    <td>80</td>
                    <td>150</td>
                    <td>Firozabad</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>105</td>
                    <td>22001366</td>
                    <td>KM PARTICAL BOARD PVT. LTD. </td>
                    <td>
                        76, ELDECO GREENS GOMITI NAGAR LUCKNOW ,Ayodhya, Uttar Pradesh, India
                        Pin Code : 224001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>gm.kmsugar@gmail.com</td>
                    <td>Vivekanand Mishra </td>
                    <td>AUTHORISED SIGNATORY </td>
                    <td>917571000526</td>
                    <td>BAGASSE BASED PARTICLE BOARD</td>
                    <td>SETTING UP PLANT FOR MANUFUCTRING OF BAGASSE BASED PARTICLE BOARD</td>
                    <td>Recycling </td>
                    <td>76</td>
                    <td>150</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>106</td>
                    <td>22000067</td>
                    <td>E-Waste Recyclers India</td>
                    <td>
                        EWRI House, A-46 Okhla Industrial Area, Phase - 1, New Delhi,South Delhi, Delhi, India
                        Pin Code : 110020
                    </td>
                    <td>Delhi</td>
                    <td>ceo@ewri.in</td>
                    <td>Sunita Arora</td>
                    <td>Proprietor</td>
                    <td>919810398787</td>
                    <td>Dairy Products &amp; Food Industry</td>
                    <td>Chips, Popcorn, Corn Snacks, Biscuit, Cheese, Butter &amp; Milk Powder etc.</td>
                    <td>Food Processing</td>
                    <td>75</td>
                    <td>470</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>107</td>
                    <td>22000061</td>
                    <td>King Solutions Pvt Ltd</td>
                    <td>
                        B-9-10 Madhuban Building, 55 Nehru Place, New Delhi ,South Delhi, Delhi, India
                        Pin Code : 110019
                    </td>
                    <td>Delhi</td>
                    <td>rent@pcrent.in</td>
                    <td>Amit Arora</td>
                    <td>Director</td>
                    <td>919810133388</td>
                    <td>Food Product Processing Unit</td>
                    <td>Manufacturing of Namkin, Chips, Kurkure, Corn Products &amp; Maida Products</td>
                    <td>Food Processing</td>
                    <td>75</td>
                    <td>500</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>108</td>
                    <td>22000130</td>
                    <td>M/s Plaza Crystal Industries</td>
                    <td>
                        Plot No B-2 Industrial Area UPSIDA Firozabad,Firozabad, Uttar Pradesh, India
                        Pin Code : 283203
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>2012.guddu.plaza@gmail.com</td>
                    <td>Uma Shankar Gupta</td>
                    <td>Proprietor</td>
                    <td>919412722891</td>
                    <td>Glass manufacturing</td>
                    <td>Glass items and Glassware manufacturing</td>
                    <td>Non metallic and mineral products </td>
                    <td>70</td>
                    <td>180</td>
                    <td>Firozabad</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>109</td>
                    <td>23010293</td>
                    <td>RECIPROCAL INDUSTRIAL PARK</td>
                    <td></td>
                    <td></td>
                    <td>reciprocalpark@outlook.com</td>
                    <td>ASHUTOSH KHARE</td>
                    <td>PARTNER</td>
                    <td>919235606061</td>
                    <td>Reciprocal Industrial Park</td>
                    <td>The project will be of 100 acres and will be developed in two phases Phase 1- (50 Acres) Phase -2 (50 Acres). This intent is for Phase -1 (50 Acres)</td>
                    <td>Private Industrial Park</td>
                    <td>70</td>
                    <td>300</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>110</td>
                    <td>22000137</td>
                    <td>LK Industries</td>
                    <td>
                        24 A, Sector 26 Noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : BBdBBdjBBdB
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>makanjameen@gmail.com</td>
                    <td>Niraj Kumar Khemka</td>
                    <td>Prop</td>
                    <td>918882110110</td>
                    <td>LK Industries</td>
                    <td>Manufacturing of plastic toyes and bottle</td>
                    <td>Plastic Manufacturing </td>
                    <td>65</td>
                    <td>20</td>
                    <td>Auraiya</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>111</td>
                    <td>22004385</td>
                    <td>Jolly Warehousing</td>
                    <td>
                        VILLAGE NEEVAGAON BIJNOR MOHANLAL GANJ,Lucknow, Uttar Pradesh, India
                        Pin Code : 226401
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>devanshjolly@gmail.com</td>
                    <td>Sunil Jolly </td>
                    <td>Proprietor</td>
                    <td>917310320333</td>
                    <td>JOLLY WAREHOUSING</td>
                    <td>JOLLY WAREHOUSING</td>
                    <td>Logistics and Warehousing </td>
                    <td>60</td>
                    <td>400</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>112</td>
                    <td>22001813</td>
                    <td>Vrindavan Developers and Industrial Promoters</td>
                    <td>
                        17,Chaitanya Vihar Phase-1,Opposite Telephone Exchange,Mathura, Uttar Pradesh, India
                        Pin Code : 281121
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>martanddev@gmail.com</td>
                    <td>Kapil Dev</td>
                    <td>Partner</td>
                    <td>919411000007</td>
                    <td>Vrindavan Industrial Area</td>
                    <td>Vrindavan and the nearby area is the Place with large amount of population and having the vast chances of development in segment of Micro industries like Silver Ornaments, Saree printing and making,Brass Crafting, Poshak and Artificial Ornaments,Bakery and Sweets Manufacturing,Electronics Manufacturing,Information Technology and many others.For all these micro industries we are planing to make a industrial Cum residential Park in the Area of 22.5 Acre approx with all modern facilities.</td>
                    <td>Private Industrial Park</td>
                    <td>60</td>
                    <td>2500</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>113</td>
                    <td>22001422</td>
                    <td>VISHAL PIPES LIMITED</td>
                    <td>
                        INDUSTRIAL AREA SIKANDRABAD,Bulandshahr, Uttar Pradesh, India
                        Pin Code : 203205
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>muneshkumar@vplgroup.org</td>
                    <td>Vishal Agarwal</td>
                    <td>DIRECTOR</td>
                    <td>917060016506</td>
                    <td>STEEL AND POLYMER PRODUCTS MANUFACTURING</td>
                    <td>OUR COMPANY IS ENGAGED IN THE BUSINESS OF MANUFACTURING OF BLACK PIPE, GI PIPE, TRANSMISSION TOWER, STEEL TUBULAR POLES, PVC AND HDPE PIPES, SOLAR STRUCTURES &amp; METAL BEAM CRASH BARRIER, STEEL BRIDGE GIRDERS. WE HAVE A PLOT NO. 15 (APPROXIMATE 33728 SQ. METER) IN SIKANDRABAD INDUSTRIAL AREA UNDER UPSIDA. BUT THE TRANSFER OF SAID PLOT IS PENDING IN UPSIDA. IF TRANSFER PROCESS OF ABOVE PLOT IS COMPLETE, THEN MANUFACTURING ACTIVITIES WILL GET START VERY SOON.</td>
                    <td>Casting of metals</td>
                    <td>60</td>
                    <td>200</td>
                    <td>Bulandshahr</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>114</td>
                    <td>22000589</td>
                    <td>AOV EXPORT (P) LTD.</td>
                    <td>
                        C-22/25, SECTOR-57,,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>snsahu@aovexports.com</td>
                    <td>Surendra Nath Sahu</td>
                    <td>VICE PRESIDENT</td>
                    <td>918081124004</td>
                    <td>SLAUGHTER HOUSE</td>
                    <td>INTEGRATED MEAT PROCESSING UNIT (SLAUGHTER HOUSE)</td>
                    <td>Leather and Footwear</td>
                    <td>60</td>
                    <td>500</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>115</td>
                    <td>22000342</td>
                    <td>M/s B K Shoes Pvt Ltd</td>
                    <td>
                        Plot No A-2 Industrial Area Sikandra Site-A,Agra, Uttar Pradesh, India
                        Pin Code : 282007
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>bkshoesprivatelimited@gmail.com</td>
                    <td>Mr Subhash Chand Middha</td>
                    <td>Director </td>
                    <td>919837014528</td>
                    <td>Manufacturing of Finished Leather Goods</td>
                    <td>Manufacturing of Finished Leather Goods</td>
                    <td>Leather and Footwear</td>
                    <td>60</td>
                    <td>150</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>116</td>
                    <td>23007349</td>
                    <td>Shree Paras Metal Industries</td>
                    <td></td>
                    <td></td>
                    <td>amarjainshamli@gmail.com</td>
                    <td>Amit Jain</td>
                    <td>Owner</td>
                    <td>919719604499</td>
                    <td>Aluminium utensils and copper brass sheet</td>
                    <td>Aluminum utensils and copper brass sheet Manufacturing</td>
                    <td>Casting of metals</td>
                    <td>60</td>
                    <td>200</td>
                    <td>Shamli</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>117</td>
                    <td>22000102</td>
                    <td>R.A.FIBER BOARDS</td>
                    <td>
                        A-4 Talkatora Industrial Area Lucknow,Lucknow, Uttar Pradesh, India
                        Pin Code : 226011
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>rafiber.lko@gmail.com</td>
                    <td>Ritu Gupta</td>
                    <td>PROPRIETOR</td>
                    <td>918009977777</td>
                    <td>PLYWOOD MANUFACTURING</td>
                    <td>Putting up Industry of Plywood Under Mega Project in your Industrial Area Jagdishpur Amethi Uttar Pradesh.</td>
                    <td>Furniture</td>
                    <td>56</td>
                    <td>200</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>118</td>
                    <td>22000105</td>
                    <td>PUSHPANJALI INFRAHEIGHT LLP</td>
                    <td>
                        266 Aishbagh Road Lucknow,Lucknow, Uttar Pradesh, India
                        Pin Code : 226004
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>anilgupta266.lko@gmail.com</td>
                    <td>Anil Kumar Gupta</td>
                    <td>PARTNER</td>
                    <td>919473777777</td>
                    <td>Laminates Industries</td>
                    <td>Putting up Industry of Laminates under Large Project in Industrial Area Jagdishpur Amethi Uttar Pradesh.</td>
                    <td>Furniture</td>
                    <td>55</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>119</td>
                    <td>22004248</td>
                    <td>DKD IKJOT UNITED PRIVATE LIMITED</td>
                    <td>
                        D-BLOCK, SECTOR A-3, TRONICA CITY IND AREA, LONI, GAZIABAD, UTTAR PRADESH 201102,Ghaziabad, Uttar Pradesh, India
                        Pin Code : 201102
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>ikjot@ikjotunited.com</td>
                    <td>Ikjot Singh Chouhan</td>
                    <td>DIRECTOR</td>
                    <td>917042261398</td>
                    <td>IKJOT UNITED PRIVATE LIMITED</td>
                    <td>
                        CNC LATHE MACHINE, VTL MACHINE, NOTCHING AND BRANDING MACHINE, CNC TURNING MACHINE CENTRE, CNC GRINDING MACHINE &amp; SPARES OF CNC MACHINE, AT ALIYABAD, TRANS DELHI SIGNATURE CITY, DISTT. â€“ GHAZIABAD, _x000D_
                        PIN CODE - 201102
                    </td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>52</td>
                    <td>600</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>120</td>
                    <td>22002045</td>
                    <td>Sparkle Logitech LLP</td>
                    <td>
                        J-26 Sector-18 Noida,Gautam Buddha Nagar, Uttar Pradesh, India
                        Pin Code : 201301
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sparklelogitech@gmail.com</td>
                    <td>Manjul Sharma</td>
                    <td>Partner</td>
                    <td>919811055505</td>
                    <td>Sparkle Logitech LLP</td>
                    <td>Logistic Facility</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>50</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>121</td>
                    <td>22002004</td>
                    <td>M/s Sonu Poultry Farms </td>
                    <td>
                        Plot No D-5 Sector -20 I.A Jagadishpur District-Amehti ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>suhelahmadsonupoultry@gmail.com</td>
                    <td>Sri Suhel Ahmad </td>
                    <td>Proprietor </td>
                    <td>918874902905</td>
                    <td>M/s Sonu Poultry Farm</td>
                    <td>M/s Sonu Poultry Farm unit have been production now expansion in unit</td>
                    <td>Agro Processing </td>
                    <td>50</td>
                    <td>650</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>122</td>
                    <td>22001752</td>
                    <td>Sara Z Tiles</td>
                    <td>
                        16 shivlok medical clinic, sherdeeh,Prayagraj, Uttar Pradesh, India
                        Pin Code : 211019
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>smartzeeshan.87@gmail.com</td>
                    <td>Zeesan Ansari</td>
                    <td>MD</td>
                    <td>919172056844</td>
                    <td>Sara Z</td>
                    <td>Tiles Manufacturing</td>
                    <td>Non metallic and mineral products </td>
                    <td>50</td>
                    <td>250</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>123</td>
                    <td>22000134</td>
                    <td>M/s G.D Industries </td>
                    <td>
                        M/S Shri G.D. Industries Plot No B-3 Sector -14 I.A Jagadishpur District- Amethi ,Amethi, Uttar Pradesh, India
                        Pin Code : 227809
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sudhir.gupta8@gmail.com</td>
                    <td>Sudhir Gupta </td>
                    <td>Proprietor </td>
                    <td>918874546162</td>
                    <td>M/s Sri G.D. Industries</td>
                    <td>M/s Sri G.D. Industries unit has bee production, Expansion in unit</td>
                    <td>Other </td>
                    <td>50</td>
                    <td>500</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>124</td>
                    <td>22000004</td>
                    <td>Siya Metals Pvt Ltd</td>
                    <td>
                        123/751, T-74 Fazalganj Factory Aera Pratapganj Gadariyanpurwa Kanpur ,Kanpur Nagar, Uttar Pradesh, India
                        Pin Code : 208012
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>himanshujainoff6969@gmail.com</td>
                    <td>Himanshu Jain</td>
                    <td>CEO</td>
                    <td>917007569327</td>
                    <td>Kanpur Industrial Park</td>
                    <td>Construction of flatted factory complex of around 325000 sq ft having around 175 flatted factory units for white goods manufacturing</td>
                    <td>Flatted Factory</td>
                    <td>50</td>
                    <td>500</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>125</td>
                    <td>22006825</td>
                    <td>IIA Private Industrial Park Varanasi</td>
                    <td>
                        Varanasi ,Varanasi, Uttar Pradesh, India
                        Pin Code : 221010
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>iiaindustrialpark@gmail.com</td>
                    <td>Rajesh Bhatia</td>
                    <td></td>
                    <td>918787030018</td>
                    <td>Director </td>
                    <td>To setup Private industrial park in 25 Acres land at Varanasi</td>
                    <td>Private Industrial Park</td>
                    <td>50</td>
                    <td>3000</td>
                    <td>Varanasi</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>126</td>
                    <td>22006488</td>
                    <td>Growth Cap Investments LLC</td>
                    <td>
                        Dubai,Dubai, Dubai, 0
                        Pin Code : 500001
                    </td>
                    <td>UAE</td>
                    <td>indu@growthcapinvestments.net</td>
                    <td>Indu Mouli Mogili</td>
                    <td></td>
                    <td>971501000000</td>
                    <td>Director</td>
                    <td>Agastya Logistic Network</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>125</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>127</td>
                    <td>22006459</td>
                    <td>VINAYAK GROUP</td>
                    <td>
                        37-39,Kanpur Nagar, Uttar Pradesh, India
                        Pin Code : 208022
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>vinayakinfrasolutionllp@gmail.com</td>
                    <td>SHIV KUMAR PALIWAL</td>
                    <td></td>
                    <td>919793346688</td>
                    <td>CHAIRMAN</td>
                    <td>
                        We are developing well planned Logistic Park namely Vinayak Logistics Park at Unnao on Lucknow-Kanpur Highway NH-25 which is major link between the capital of Uttar Pradesh and Industrial Hub of India i.e. Kanpur City.
                        We have to use high quality measures and other infrastructural facilities for serving better in line with Central Government &amp; State Government warehousing &amp; logistics policies.
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>1000</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>128</td>
                    <td>23008942</td>
                    <td>R K LAXMI LOGISTIC PRIVATE LIMITED</td>
                    <td>
                        33 KASYA ROAD GORAKHPUR,Gorakhpur, Uttar Pradesh, India
                        Pin Code : 273001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>rklaxmilogisticpvtltd@gmail.com</td>
                    <td>LAXMI KANT RAI</td>
                    <td></td>
                    <td>917800000810</td>
                    <td>R K LAXMI LOGISTIC PRIVATE LIMITED</td>
                    <td>LOGISTIC AND WAREHOUSING PROJECT</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>250</td>
                    <td>Sant Kabir Nagar</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>129</td>
                    <td>23008833</td>
                    <td>SHREE JEE CONSTRUCTION PVT. LTD.</td>
                    <td>
                        26/49 BIRHANA ROAD , KANPUR,Kanpur Nagar, Uttar Pradesh, India
                        Pin Code : 208001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>sharmaanuj142@gmail.com</td>
                    <td>JAGDISH PRASHAD GUPTA</td>
                    <td></td>
                    <td>919307605078</td>
                    <td>LOGISTIC PARK</td>
                    <td>PLANNING FOR LOGISTIC PARK AT FATEHPUR ROSNAI VILLAGE</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>30</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>130</td>
                    <td>23008785</td>
                    <td>EVERGREEN ADVERTISING PRIVATE LIMITED</td>
                    <td>
                        UNIT L 006 ROHTAS PLUMERIA HOMES ,Lucknow, Uttar Pradesh, India
                        Pin Code : 226010
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>EVERGREENADVERTISINGLKO@GMAIL.COM</td>
                    <td>SANGRAM SINGH</td>
                    <td></td>
                    <td>919670217181</td>
                    <td>EVERGREEN WAREHOSUING</td>
                    <td>PLAN TO DEVELOP A WARE HOUSE CLUSTER ON LUCKNOW KANPUR ROAD</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>50</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>131</td>
                    <td>23008348</td>
                    <td>Shree jee</td>
                    <td>
                        Pilkhuwa,Hapur, Uttar Pradesh, India
                        Pin Code : 245304
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>Anshul.mittal21@gmail.com</td>
                    <td>Anshul mittal</td>
                    <td></td>
                    <td>919927193492</td>
                    <td>Shree jee warehousing</td>
                    <td>Warehousing and logistics</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>200</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>132</td>
                    <td>23010185</td>
                    <td>PARAMPARA BUILDERS PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>PARAMPARABUILDERS@GMAIL.COM</td>
                    <td>ANURAG AGARWAL</td>
                    <td>DIRECTOR</td>
                    <td>919837090667</td>
                    <td>PARAMPARA INDUSTRIAL CUM LOGISTIC ESTATE</td>
                    <td>Moradabad popularily known as &#34;Brass city of world&#34; with export turnovers of 12000 cr is starving for well organized Industrial park since several years as there is no Private or Govt Industrial park .Now Parampara Group plan to set a Private Industrial &amp; Logistic park on NH9 Moradabad byepass -Delhi road in 40 Acres with all infrastructure &amp; amenities .</td>
                    <td>Private Industrial Park</td>
                    <td>50</td>
                    <td>300</td>
                    <td>Moradabad</td>
                    <td>SEZ Moradabad</td>
                </tr>
                <tr>
                    <td>133</td>
                    <td>23009727</td>
                    <td>RK Loaxmi Logistic Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>rklagritech@gmail.com</td>
                    <td>Abhay Rai</td>
                    <td>General Manager</td>
                    <td>918282820004</td>
                    <td>Logistics Park</td>
                    <td>Transport Hub + Logistics Park</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>50</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>134</td>
                    <td>23009550</td>
                    <td>Indian glasswool Industries</td>
                    <td></td>
                    <td></td>
                    <td>indianglasswool@gmail.com</td>
                    <td>Saurabh aggarwal</td>
                    <td>CEO</td>
                    <td>919873478320</td>
                    <td>Warehouse and logistic park</td>
                    <td>Warehouse and logistic park</td>
                    <td>Logistics and Warehousing </td>
                    <td>50</td>
                    <td>100</td>
                    <td>Amroha</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>135</td>
                    <td>23009395</td>
                    <td>Saharanpur Industrial Development Association</td>
                    <td></td>
                    <td></td>
                    <td>pankajpiousgupta@gmail.com</td>
                    <td>Pankaj Garg</td>
                    <td>Director</td>
                    <td>919528777324</td>
                    <td>Saharanpur Industrail Development Association</td>
                    <td>Private Industrial Park</td>
                    <td>Private Industrial Park</td>
                    <td>50</td>
                    <td>200</td>
                    <td>Saharanpur</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>136</td>
                    <td>22000447</td>
                    <td>SHRI RAM INDUSTRIES</td>
                    <td>
                        B-21 I.A. MALWAN FATEHPUR,Fatehpur, Uttar Pradesh, India
                        Pin Code : 212664
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>shriramindustries0106@gmail.com</td>
                    <td>Vikas Pandey</td>
                    <td>PARTNER</td>
                    <td>919627539200</td>
                    <td>TYRE PYROLISIS</td>
                    <td>TYRE PYROLISIS</td>
                    <td>Automobile</td>
                    <td>45</td>
                    <td>250</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>137</td>
                    <td>23008776</td>
                    <td>LUCKNOW H M KOHINOOR CITY</td>
                    <td>
                        B3, Flat 204, Shalimar Mannat, Safedabad, Barabanki U.P.,Barabanki, Uttar Pradesh, India
                        Pin Code : 225001
                    </td>
                    <td>Uttar Pradesh</td>
                    <td>001SYEDAKBAR@GMAIL.COM</td>
                    <td>SYED MOHD AKBAR</td>
                    <td></td>
                    <td>917985002143</td>
                    <td>LUCKNOW H M KOHINOOR CITY PVT. LTD.</td>
                    <td>Private Industrial Park (PPP) , Site Address- Village- Khaspariya, Safedabad, District- Barabanki</td>
                    <td>Private Industrial Park</td>
                    <td>45</td>
                    <td>150</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>139</td>
                    <td>22006763</td>
                    <td>BANARAS BEADS LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>prashant@banarasbead.com</td>
                    <td>PRASHANT TIWARI</td>
                    <td></td>
                    <td>919839105557</td>
                    <td>COMMERCIAL MANAGER</td>
                    <td>
                        The project is for construction of Warehouse in 28000 Square Meter to facilitate the logistics companies. Warehouses have become one of the major segments of the rapidly growing Indian logistics
                        industry. Today they do not only provide custody for goods but also offer value added services such as sorting, packing, blending and processing. Warehousing is the most important auxiliary service for development of trade and commerce.
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>41</td>
                    <td>63</td>
                    <td>Varanasi</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>140</td>
                    <td>22005313</td>
                    <td>D.K.S.M LOGISTICS PARK LLP</td>
                    <td></td>
                    <td></td>
                    <td>kapilbansal35@gmail.com</td>
                    <td>Kapil Kumar Bansal</td>
                    <td>PARTNER</td>
                    <td>919821208243</td>
                    <td>DKSM LOGISTICPARK LLP</td>
                    <td>WAREHOUSING AND LOGISTIC</td>
                    <td>Logistics and Warehousing </td>
                    <td>40</td>
                    <td>1000</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>141</td>
                    <td>22002006</td>
                    <td>Central Warehousing Corporation</td>
                    <td></td>
                    <td></td>
                    <td>rmlko@cewacor.nic.in</td>
                    <td>Shivananad Rai</td>
                    <td>Group General Manager</td>
                    <td>919423056072</td>
                    <td>Warehouse</td>
                    <td>Providing warehousing services.</td>
                    <td>Logistics and Warehousing </td>
                    <td>40</td>
                    <td>10</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>143</td>
                    <td>22000460</td>
                    <td>JDSL EDIBLE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>udaybhansahu1977@gmail.com</td>
                    <td>Uday Bhan</td>
                    <td>DIRECTOR</td>
                    <td>918756445372</td>
                    <td>EDIBLE OIL</td>
                    <td>EDIBLE OIL</td>
                    <td>Food Processing</td>
                    <td>36</td>
                    <td>124</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>144</td>
                    <td>22000456</td>
                    <td>MAROOF ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>frk.khan.303@gmail.com</td>
                    <td>Farooq Ahmad</td>
                    <td>Proprietor</td>
                    <td>918052078666</td>
                    <td>FLOUR MILL</td>
                    <td>FLOUR MILL</td>
                    <td>Food Processing</td>
                    <td>35</td>
                    <td>150</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>145</td>
                    <td>22000880</td>
                    <td>Vidhu Infracity Pvt. Ltd.</td>
                    <td></td>
                    <td></td>
                    <td>dawarinfra@gmail.com</td>
                    <td>Puran Chand Dawar</td>
                    <td>Chairman</td>
                    <td>919837339443</td>
                    <td>Vidhu Infracity</td>
                    <td>Logistic Hub Phase 1</td>
                    <td>Logistics and Warehousing </td>
                    <td>33</td>
                    <td>25</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>146</td>
                    <td>22002338</td>
                    <td>M/s Aaklan Foods Processing</td>
                    <td></td>
                    <td></td>
                    <td>Salwaagro2014@gmail.com</td>
                    <td>Sri Mahbood Ahmad Khan </td>
                    <td>Proprietor </td>
                    <td>919919132697</td>
                    <td>Food Processing</td>
                    <td>M/s Salwa Agro Group New Unit M/s Aaklan Food Processing Ltd Poultry Feeds Mill</td>
                    <td>Agro Processing </td>
                    <td>30</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>147</td>
                    <td>22000445</td>
                    <td>PINDARAN METAL &amp; ALLOYS PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>sommetal@yahoo.com</td>
                    <td>Satendra Singh</td>
                    <td>DIRECTOR</td>
                    <td>919873074010</td>
                    <td>COPPER AND COPPER ALLOYS</td>
                    <td>COPPER AND COPPER ALLOYS PRODUCT</td>
                    <td>Casting of metals</td>
                    <td>30</td>
                    <td>85</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>148</td>
                    <td>22000438</td>
                    <td>BDRD ROLLER FLOUR MILL PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>amit.parth.gupta@gmail.com</td>
                    <td>Amit Gupta</td>
                    <td>DIRECTOR</td>
                    <td>919935637554</td>
                    <td>FOOD PROCESSING</td>
                    <td>FOOD PROCESSING</td>
                    <td>Food Processing</td>
                    <td>30</td>
                    <td>100</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>149</td>
                    <td>22000216</td>
                    <td>M.I.S. PROFESSIONAL COLLEGE </td>
                    <td></td>
                    <td></td>
                    <td>aaddya@gmail.com</td>
                    <td>Salil Agarwal</td>
                    <td>MANAGER </td>
                    <td>917007526706</td>
                    <td>PROFESSIONAL COLLEGE</td>
                    <td>TO MAKE PROFESSIONAL COLLEGE ,NEED GOVERNMENT INERVENION TO RESOLVE LAND ISSUE PENDING IN SOHAVAL SDM COURT FROM 3 YEAR.</td>
                    <td>College and Hospital</td>
                    <td>30</td>
                    <td>200</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>150</td>
                    <td>23008292</td>
                    <td>B H INFINITE LOGIWARE LLP(PROPOSED)</td>
                    <td></td>
                    <td></td>
                    <td>bhtlko@gmail.com</td>
                    <td>PANKAJ AGARWAL</td>
                    <td></td>
                    <td>919415026259</td>
                    <td>BH INFINITE LOGIWARE</td>
                    <td>TO SET UP STATE OF ART LOGISTIC AND WAREHOUSE FACILITIES IN LUCKNOW DISTRICT TO PROVIDE LOGISTIC AND WAREHOUSE SUPPORT TO NATIONAL AND MULTINATIONAL COMPANIES. PROPOSED LLP WILL SET UP 150000 SQ FT WAREHOUSE ON LAND OF 25000 SQ MT (PROPOSED TO BE ACQUAIRED WITH SUPPORT OF GOVT.). PROPOSED DIRECT EMPLOYMENT IS ABOUT 100 EMPLOYEE. INDIRECT EMPLOYEMT WILL BE ARROUNT 400 PERSON. TOTAL PROPOSED INVESTMENT IN PROJECT IS ARROUND RS.30 CRORE. INVESTOR</td>
                    <td>Logistics and Warehousing </td>
                    <td>30</td>
                    <td>600</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>151</td>
                    <td>22000442</td>
                    <td>VIRENDRA SINGH</td>
                    <td></td>
                    <td></td>
                    <td>05virendra.singh@gmail.com</td>
                    <td>Virendra Singh</td>
                    <td>Proprietor</td>
                    <td>919415066022</td>
                    <td>AUTO PARTS</td>
                    <td>AUTO PARTS</td>
                    <td>Automobile</td>
                    <td>28</td>
                    <td>80</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>152</td>
                    <td>22000440</td>
                    <td>AKANSHA ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>akt399388@gmail.com</td>
                    <td>Ankit Gupta</td>
                    <td>Proprietor</td>
                    <td>919151399388</td>
                    <td>ATTA PLANT</td>
                    <td>ATTA PLANT</td>
                    <td>Food Processing</td>
                    <td>27</td>
                    <td>75</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>153</td>
                    <td>22000234</td>
                    <td>HEERA NUTRITECH PVT LTD </td>
                    <td></td>
                    <td></td>
                    <td>krishna.prasad61@gmail.com</td>
                    <td>Dr Krishna Prasas Gupta</td>
                    <td>DIRECTOR</td>
                    <td>919415213096</td>
                    <td>CATTLE FEEDS</td>
                    <td>CATTLE FEEDS AND MURGI DANA</td>
                    <td>Agro Processing </td>
                    <td>25.51</td>
                    <td>40</td>
                    <td>Deoria</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>154</td>
                    <td>22002454</td>
                    <td>M/S NASHEMAN HOSPITAL</td>
                    <td></td>
                    <td></td>
                    <td>pr.brightway@gmail.com</td>
                    <td>Imtiyaz Ahmad </td>
                    <td>PROPRIETOR</td>
                    <td>919839111236</td>
                    <td>HOSPITAL/NURSING HOME</td>
                    <td>HOSPITAL/NURSING HOME PROJECT ESTABLISH AT 2000 SQM IN UPSIDA LAND JAGDISHPUR, AMETHI</td>
                    <td>College and Hospital</td>
                    <td>25</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>155</td>
                    <td>22000784</td>
                    <td>CRESCENT TANNERS (P) LTD.</td>
                    <td></td>
                    <td></td>
                    <td>dudeajmal12@gmail.com</td>
                    <td>Mohd Khalid Sheikh</td>
                    <td>DIRECTOR</td>
                    <td>919839035437</td>
                    <td>FOOTWEAR COMPONENTS</td>
                    <td>FOOTWEAR COMPONENTS</td>
                    <td>Leather and Footwear</td>
                    <td>25</td>
                    <td>200</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>156</td>
                    <td>22000643</td>
                    <td>M/s Gorakhnath Organics </td>
                    <td></td>
                    <td></td>
                    <td>gorakhnathorg@gmail.com</td>
                    <td>Shri Shantanu Aggrawal </td>
                    <td>Partnership </td>
                    <td>919456232689</td>
                    <td>Synthetic organic chemical</td>
                    <td>Formaldehyde &amp; Formaldehyde Synthetic organic chemical 305 TPD</td>
                    <td>Chemical Manufacturing</td>
                    <td>25</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>157</td>
                    <td>22000452</td>
                    <td>ANANDESHWAR TRADING COMPANY</td>
                    <td></td>
                    <td></td>
                    <td>sheetlametal@gmail.com</td>
                    <td>Anand Gupta</td>
                    <td>Proprietor</td>
                    <td>916393402327</td>
                    <td>RICE MILL</td>
                    <td>RICE MILL</td>
                    <td>Food Processing</td>
                    <td>25</td>
                    <td>100</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>158</td>
                    <td>22000008</td>
                    <td>Kanpur Hosiery Silai Association</td>
                    <td></td>
                    <td></td>
                    <td>balram@jetknit.com</td>
                    <td>Balram Narula</td>
                    <td>Patron</td>
                    <td>919621060606</td>
                    <td>Kanpur Hosiery Silai Sector</td>
                    <td>Faltted Foctory Complex at Dada Nagar 170 Flatted Factory Units For Cutting and knitted stiching for while goods manufacturing</td>
                    <td>Flatted Factory</td>
                    <td>25</td>
                    <td>3000</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>159</td>
                    <td>23008214</td>
                    <td>RONAK JAIN</td>
                    <td></td>
                    <td></td>
                    <td>jainrahul_11@yahoo.com</td>
                    <td>RONAK JAIN</td>
                    <td></td>
                    <td>919999955903</td>
                    <td>R R INCORPORATION</td>
                    <td>PVC AND RUBBER HOSES</td>
                    <td>Plastic Manufacturing </td>
                    <td>25</td>
                    <td>25</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>160</td>
                    <td>23007591</td>
                    <td>Maheshwari Warehouse</td>
                    <td></td>
                    <td></td>
                    <td>anshulmah321@gmail.com</td>
                    <td>Anshul Maheshwari</td>
                    <td></td>
                    <td>917860594959</td>
                    <td>Establishing Warehouse of 25MT capacity</td>
                    <td>We want to establish a warehouse of 25 Metric Tonnes in lucknow district to cater the needs of storage of goods on a large scale in a systematic and orderly manner and making them conveniently when needed.</td>
                    <td>Logistics and Warehousing </td>
                    <td>25</td>
                    <td>100</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>161</td>
                    <td>23010365</td>
                    <td>M/s Reda Resources</td>
                    <td></td>
                    <td></td>
                    <td>imran@redaresources.com</td>
                    <td>Imran Khan</td>
                    <td>Partner</td>
                    <td>919568160666</td>
                    <td>All Type of Glassware Manufacturing</td>
                    <td>All Type of Glassware Manufacturing</td>
                    <td>Non metallic and mineral products </td>
                    <td>25</td>
                    <td>110</td>
                    <td>Firozabad</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>162</td>
                    <td>23009229</td>
                    <td>Tirupati Traders</td>
                    <td></td>
                    <td></td>
                    <td>kunalpandit32@gmail.com</td>
                    <td>Rupesh kumar Sharma</td>
                    <td>Proprietor</td>
                    <td>918791015705</td>
                    <td>Tirupati Traders</td>
                    <td>Warehouse</td>
                    <td>Logistics and Warehousing </td>
                    <td>25</td>
                    <td>100</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>163</td>
                    <td>22000051</td>
                    <td>Sunflowers Woven Sack Industry Pvt. Ltd. </td>
                    <td></td>
                    <td></td>
                    <td>sunflowerswovensack@gmail.com</td>
                    <td>Suhel Haider</td>
                    <td>Director</td>
                    <td>917065970022</td>
                    <td>Sunflowers Woven Sack Industry Pvt. Ltd.</td>
                    <td>Manufacturing based company of Woven Sack PP/HDPE Bags at plot no C-2 &amp; C-3 , Sector-22, I.A. Jagdispur, Distt.-Amethi</td>
                    <td>Plastic Manufacturing </td>
                    <td>23</td>
                    <td>110</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>164</td>
                    <td>23008828</td>
                    <td>SHREE JEE CONSTRUCTION PVT. LTD.</td>
                    <td></td>
                    <td></td>
                    <td>sharmaanuj142@gmail.com</td>
                    <td>JAGDISH PRASHAD GUPTA</td>
                    <td></td>
                    <td>919307605078</td>
                    <td>WARE HOUSES</td>
                    <td>WE ARE PLANNING WAREHOUSES AT VILLAGE GADENKHEDA, KANPUR</td>
                    <td>Logistics and Warehousing </td>
                    <td>21</td>
                    <td>20</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>165</td>
                    <td>22002062</td>
                    <td>M/S JAYA INDUSTRIES </td>
                    <td></td>
                    <td></td>
                    <td>brijeshverma1172@gmail.com</td>
                    <td>Brijesh Patel </td>
                    <td>PROPRIETOR </td>
                    <td>917007512482</td>
                    <td>M.S. FAN GUARD</td>
                    <td>NEW PROJECT MANUFACTURING ELECTRIC GOODS SETUP I.A. AYODHYA, DISTT-AYODHYA</td>
                    <td>Electrical equipment manufacturing </td>
                    <td>20</td>
                    <td>100</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>166</td>
                    <td>22000584</td>
                    <td>M/S EDIBLES PVT LTD. </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Shubham Bhalothia</td>
                    <td>Managing Director </td>
                    <td>917838163763</td>
                    <td>FLOUR MILL</td>
                    <td>NEW PROJECT SETUP FOR FLOUR MILL ON UPSIDA LAND IN DISTT. AMETHI. APPROX 5 ACRE LAND.</td>
                    <td>Food Processing</td>
                    <td>20</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>167</td>
                    <td>22000229</td>
                    <td>K K SERVICES</td>
                    <td></td>
                    <td></td>
                    <td>GOLDIEALLD@GMAIL.COM</td>
                    <td>Amit Kumar</td>
                    <td>PROPRITOR</td>
                    <td>919559210101</td>
                    <td>Housing Project</td>
                    <td>Group Housing in Sarswati Hitech City, Naini, Prayagraj</td>
                    <td>Group Housing </td>
                    <td>20</td>
                    <td>50</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>168</td>
                    <td>22000145</td>
                    <td>Hemraj Industies</td>
                    <td></td>
                    <td></td>
                    <td>hemraj.industriesup@gmail.com</td>
                    <td>Hema Ram Patel</td>
                    <td>Propreitor</td>
                    <td>919811269620</td>
                    <td>Tricycle, Baby Walker and Toys Manufacturing</td>
                    <td>The project includes manufacturing of Tricycles, baby walker and toys. The project employees skilled and unskilled labour cummilative of 100 labours. It requires land of 1250sq. mtr and other expenditure of 15-20cr.</td>
                    <td>Other </td>
                    <td>20</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>169</td>
                    <td>23009169</td>
                    <td>Dale promoters India pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>dalegroup032011@gmail.com</td>
                    <td>Tushar Gupta</td>
                    <td></td>
                    <td>918090367831</td>
                    <td>Indtech Park</td>
                    <td>Indtech Park Lucknow</td>
                    <td>Private Industrial Park</td>
                    <td>20</td>
                    <td>500</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>170</td>
                    <td>23010440</td>
                    <td>Vidhi exports</td>
                    <td></td>
                    <td></td>
                    <td>aj@thebrassmanindia.com</td>
                    <td>Abhishek jindal</td>
                    <td>Ceo</td>
                    <td>919910788355</td>
                    <td>Aligarh cdf</td>
                    <td>manufacture of high quality precision items</td>
                    <td>Casting of metals</td>
                    <td>20</td>
                    <td>100</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>171</td>
                    <td>23010439</td>
                    <td>Vidhi exports</td>
                    <td></td>
                    <td></td>
                    <td>aj@thebrassmanindia.com</td>
                    <td>Abhishek jindal</td>
                    <td>Ceo</td>
                    <td>919910788355</td>
                    <td>Salempur hathras</td>
                    <td>manufacture of high quality precision items</td>
                    <td>Casting of metals</td>
                    <td>20</td>
                    <td>100</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>172</td>
                    <td>22000828</td>
                    <td>Beeam Products and Services Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>shubham.bhalothia@gmail.com</td>
                    <td>Sanjog Berry</td>
                    <td>Director</td>
                    <td>919634607941</td>
                    <td>Beeam Products and Services Pvt Ltd</td>
                    <td>Warehousing and Logistics</td>
                    <td>Logistics and Warehousing </td>
                    <td>18</td>
                    <td>250</td>
                    <td>Hamirpur</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>173</td>
                    <td>22003002</td>
                    <td>R.K. AGRO HATCHERIES </td>
                    <td></td>
                    <td></td>
                    <td>aslamkhan227809@gmail.com</td>
                    <td>Mohd Aslam Khan</td>
                    <td>PROPRIETOR </td>
                    <td>918005388504</td>
                    <td>FEED MILL</td>
                    <td>FEED MILL (4000 SQM LAND) NEW UNIT SETUP IN INDUSTRIAL AREA JAGDISHPUR DSITT-AMETHI</td>
                    <td>Food Processing</td>
                    <td>15</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>174</td>
                    <td>22002372</td>
                    <td>M/s DhanLaxmi Foods Pvt Ltd </td>
                    <td></td>
                    <td></td>
                    <td>annuricemill@gmail.com</td>
                    <td>Sri Rajesh Singh </td>
                    <td>MD </td>
                    <td>919415185434</td>
                    <td>Rice Mill</td>
                    <td>Rice Mill in I,A Jagadishpur District- Ameth M/s Dhanlaxme Food Pvt Ltd unit is established now Set New Project</td>
                    <td>Food Processing</td>
                    <td>15</td>
                    <td>30</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>175</td>
                    <td>22002201</td>
                    <td>M/s Shobha Enterprises </td>
                    <td></td>
                    <td></td>
                    <td>sarojshobha963@gmail.com</td>
                    <td>Smt Shobh </td>
                    <td>Proprietor </td>
                    <td>919794141583</td>
                    <td>Warehouse</td>
                    <td>Warehouse project demand in Area District- Jagadishpur Amethi</td>
                    <td>Logistics and Warehousing </td>
                    <td>15</td>
                    <td>200</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>176</td>
                    <td>22001957</td>
                    <td>M/s Omrox Green Power Pvt Ltd </td>
                    <td></td>
                    <td></td>
                    <td>info@omrox.in</td>
                    <td>Sri Vishal Jaiswal </td>
                    <td>Director </td>
                    <td>918400920572</td>
                    <td>M/s Omrox Green Power Pvt Ltd</td>
                    <td>Lead Oxide &amp; Alloy manufacturing Battery Plate</td>
                    <td>Casting of metals</td>
                    <td>15</td>
                    <td>150</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>177</td>
                    <td>22001660</td>
                    <td>M/s Amethi Air Products Pvt Ltd </td>
                    <td></td>
                    <td></td>
                    <td>telicombaba52@gmail.com</td>
                    <td>Kutubudeen </td>
                    <td>Director </td>
                    <td>917398780029</td>
                    <td>M/s Amethi Air Products Pvt Ltd</td>
                    <td>M/s Amethi Air Products Unit will be set up in District Amethi oxygen Plant</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>15</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>178</td>
                    <td>22000444</td>
                    <td>MAHADEV INDUSTRIES</td>
                    <td></td>
                    <td></td>
                    <td>bittoosteel@gmail.com</td>
                    <td>Pragya Singh</td>
                    <td>Proprietor</td>
                    <td>919266122001</td>
                    <td>MANUFACTUING OF SS UTENSIL</td>
                    <td>SS UNTENSIL</td>
                    <td>Fabricated metal manufacturing </td>
                    <td>15</td>
                    <td>65</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>179</td>
                    <td>22000360</td>
                    <td>MAHADEV COLD STORAGE AND ICE FACTORY</td>
                    <td></td>
                    <td></td>
                    <td>rajeevdubeybotal.com@gmail.com</td>
                    <td>Rajeev Dubey</td>
                    <td>PARTNER</td>
                    <td>916307532751</td>
                    <td>ICE FACTORY</td>
                    <td>ICE FACTORY</td>
                    <td>Electricity, Gas, Steam and Aircondition Supply</td>
                    <td>15</td>
                    <td>150</td>
                    <td>Farrukhabad</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>180</td>
                    <td>22000521</td>
                    <td>RAHUL JAIN ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>rahul.jantapubl85@gmail.com</td>
                    <td>Rahul Jain</td>
                    <td>PROPRIETOR</td>
                    <td>919311801126</td>
                    <td>PRINTING PRESS AND OTHER ALLIED PRODUCTS</td>
                    <td>REQUIRED AREA OF PLOT 4000 (PRINTING PRESS AND OTHER ALLIED PRODUCTS)</td>
                    <td>Printing </td>
                    <td>14.5</td>
                    <td>180</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>181</td>
                    <td>22000486</td>
                    <td>MUKESH DHOOP INDUSTRIES</td>
                    <td></td>
                    <td></td>
                    <td>mukesh.kakkar63@gmail.com</td>
                    <td>Mukesh Kakkar</td>
                    <td>PROPRIETOR</td>
                    <td>919810100372</td>
                    <td>MFG OF DHOOP AND AGARWATTI</td>
                    <td>REQUIRED PLOT AREA 5000 SQ MTR, PROJECT NAME- MFG OF DHOOP AND AGARWATTI</td>
                    <td>Other </td>
                    <td>12.5</td>
                    <td>150</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>182</td>
                    <td>22000080</td>
                    <td>M/s Artixan Modulars LLP</td>
                    <td></td>
                    <td></td>
                    <td>artixan@outlook.in</td>
                    <td>Mohit Gupta</td>
                    <td>Partner</td>
                    <td>919872824975</td>
                    <td>MODULAR PLANT</td>
                    <td>COMPLETE MODULAR PLANT FOR HOME INTERIORS LIKE KITCHENS, WARDROBES, WINDOW SYSTEMS ETC AT PLOT RAMNAGAR, CHANDAULI</td>
                    <td>Furniture</td>
                    <td>12.5</td>
                    <td>35</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>183</td>
                    <td>22000292</td>
                    <td>J TEX INTERNATIONAL PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>jtexintlpl@gmail.com</td>
                    <td>Jinendra Kumar Jain</td>
                    <td>DIRECTOR</td>
                    <td>919999999707</td>
                    <td>Readymade Garments</td>
                    <td>Readymade Garments and other allied products</td>
                    <td>Textile </td>
                    <td>12.35</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>184</td>
                    <td>22006847</td>
                    <td>Krishna Cap Box Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>manu.rastogi@krishnacaps.in</td>
                    <td>Manu Rastogi</td>
                    <td></td>
                    <td>919897088988</td>
                    <td></td>
                    <td>Want to setup a warehousing facility at Bagp[at Road, Meerut in an area of 6000 square meters. This warehouse shall cater to high value items like electronics, pharmaceutical and other FMCG companies.</td>
                    <td>Logistics and Warehousing </td>
                    <td>12</td>
                    <td>50</td>
                    <td>Meerut</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>185</td>
                    <td>22000537</td>
                    <td>SANJAY KUMAR JAIN</td>
                    <td></td>
                    <td></td>
                    <td>sanjay.jain.rishabh@gmail.com</td>
                    <td>Sanjay Kumar Jain</td>
                    <td>PROPRIETOR</td>
                    <td>919717361362</td>
                    <td>Corrugated Boxes and other allied products</td>
                    <td>REQUIRED AREA OF PLOT NO 2000 SQ MTR (Corrugated Boxes and other allied products)</td>
                    <td>Paper Manufacturing</td>
                    <td>11.5</td>
                    <td>150</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>186</td>
                    <td>22000343</td>
                    <td>VIKAS APPAREL</td>
                    <td></td>
                    <td></td>
                    <td>vikasj725@gmail.com</td>
                    <td>Vikas Jain</td>
                    <td>PROPRIETOR</td>
                    <td>919873167016</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS AND ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>11.5</td>
                    <td>150</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>187</td>
                    <td>22000338</td>
                    <td>JAI SANMATI APPARELS</td>
                    <td></td>
                    <td></td>
                    <td>deepakjain676@gmail.com</td>
                    <td>Deepak Jain</td>
                    <td>PROPRIETOR</td>
                    <td>919899721729</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS AND OTHER ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>11.14</td>
                    <td>150</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>188</td>
                    <td>22000627</td>
                    <td>ANG Aqua Feeds</td>
                    <td></td>
                    <td></td>
                    <td>gulzar1026@gmail.com</td>
                    <td>Ang Aqua Feeds</td>
                    <td>Partnership Firm</td>
                    <td>919935627141</td>
                    <td>Poultry Feeds</td>
                    <td>Poject of Poultry Feeds</td>
                    <td>Agro Processing </td>
                    <td>11</td>
                    <td>20</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>189</td>
                    <td>22000120</td>
                    <td>M/S Enable Agro Producer Co. Ltd.</td>
                    <td></td>
                    <td></td>
                    <td>shrikantrai1960@gmail.com</td>
                    <td>Anju Rai</td>
                    <td>DIRECTOR</td>
                    <td>919118001122</td>
                    <td>ENABLE AGRO PRODUCER</td>
                    <td>FRUIT &amp; VEGETABLE PRESERVATION &amp; MARKETING</td>
                    <td>Food Processing</td>
                    <td>11</td>
                    <td>5</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>190</td>
                    <td>22000504</td>
                    <td>VASHU ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>vashuenterprises77@gmail.com</td>
                    <td>Dinesh Chaudhary</td>
                    <td>PROPRIETOR</td>
                    <td>919818622908</td>
                    <td>Fabrication and Electrical Works</td>
                    <td>Fabrication and Electrical Works (Required Area of plot 2000 sq. Mtr.)</td>
                    <td>Electrical equipment manufacturing </td>
                    <td>10.5</td>
                    <td>150</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>191</td>
                    <td>22002188</td>
                    <td>M/s Neha Singh Enterprises </td>
                    <td></td>
                    <td></td>
                    <td>upendrasingh762@gmail.com</td>
                    <td>Neha Singh </td>
                    <td>Proprietorship </td>
                    <td>919792581111</td>
                    <td>Warehouse</td>
                    <td>warehouse project in Industrial Area Jagadishpur District- Amethi</td>
                    <td>Logistics and Warehousing </td>
                    <td>10</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>192</td>
                    <td>22002148</td>
                    <td>M/s Shiv Shakti Hospital</td>
                    <td></td>
                    <td></td>
                    <td>shivshaktihospital2012@gmail.com</td>
                    <td>Sushila Yadav </td>
                    <td>Managing Dictator </td>
                    <td>919935561639</td>
                    <td>Hospital</td>
                    <td>M/s Shiv Shakti Hospital in Jagadishpur Distt- Ameth is running position no new Set up Hospital in Jagadishpur Amehti</td>
                    <td>College and Hospital</td>
                    <td>10</td>
                    <td>100</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>193</td>
                    <td>22001922</td>
                    <td>M/S TATA AGRO FEED </td>
                    <td></td>
                    <td></td>
                    <td>taraagrofeed@gmail.com</td>
                    <td>Smt Uma Singh </td>
                    <td>PROPRIETOR</td>
                    <td>918429347300</td>
                    <td>POULTRY FEED</td>
                    <td>POULTRY FEED UNIT SETUP IN UPSIDA LAND INDUSTRIA AREA JAGDISHPUR, AMETHI</td>
                    <td>Agro Processing </td>
                    <td>10</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>194</td>
                    <td>22001879</td>
                    <td>M/S GITANSHI PACKAGING PVT. LTD. </td>
                    <td></td>
                    <td></td>
                    <td>gitanshipack@gmail.com</td>
                    <td>Ramesh Chandra Jaiswal</td>
                    <td>DIRECTOR </td>
                    <td>919956139455</td>
                    <td>Bagasse Pulp Made Tableware</td>
                    <td>Bagasse Pulp Made Tableware project setup in UPSIDA Land I.A. Jagdishpur, Amethi</td>
                    <td>Recycling </td>
                    <td>10</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>195</td>
                    <td>22000337</td>
                    <td>M/s Mani Abhraj Oxygen Windows</td>
                    <td></td>
                    <td></td>
                    <td>manojchaudhary.cmi@gmail.com</td>
                    <td>Mr Manoj Singh</td>
                    <td>Partner</td>
                    <td>919555597879</td>
                    <td>Zinc Ingot Zinc Alloys Ingot Aluminum Ingot Brass Ingot</td>
                    <td>Manufacturing of Zinc Ingot Zinc Alloys Ingot Aluminum Ingot Brass Ingot</td>
                    <td>Casting of metals</td>
                    <td>10</td>
                    <td>100</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>196</td>
                    <td>22000291</td>
                    <td>DAVENDRA KUMAR</td>
                    <td></td>
                    <td></td>
                    <td>davendrakumar508@gmail.com</td>
                    <td>Davendra Kumar</td>
                    <td>Proprietorship</td>
                    <td>919810552886</td>
                    <td>Readymade Garments</td>
                    <td>Readymade Garments And Other Allied Products</td>
                    <td>Textile </td>
                    <td>10</td>
                    <td>45</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>197</td>
                    <td>22000230</td>
                    <td>SSKIA AGROTECH (OPC) PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>satyaveer.1989yadav@gmail.com</td>
                    <td>Satyaveer Yadav</td>
                    <td>DIRECTOR</td>
                    <td>919867119658</td>
                    <td>PROM FERTILIZER</td>
                    <td>PROM FERTILIZERS ETC.</td>
                    <td>Chemical Manufacturing</td>
                    <td>10</td>
                    <td>40</td>
                    <td>Deoria</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>198</td>
                    <td>22000226</td>
                    <td>SURPLUS PLASTIC PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>radha.rungta@gmail.com</td>
                    <td>Prateek Rungta</td>
                    <td>DIRECTOR</td>
                    <td>919919805061</td>
                    <td>PLASTIC INDUSTRY</td>
                    <td>PLASTIC MOLDED FURNITURE AND PIPE</td>
                    <td>Plastic Manufacturing </td>
                    <td>10</td>
                    <td>40</td>
                    <td>Maharajganj</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>199</td>
                    <td>22000166</td>
                    <td>Ujjal associate</td>
                    <td></td>
                    <td></td>
                    <td>shashiranjansingh94@gmail.com</td>
                    <td>Shashi Ranjan Singh</td>
                    <td>Partnor</td>
                    <td>919889999945</td>
                    <td>UJJAL ASSOCIATES</td>
                    <td>Alcohol bottling unit</td>
                    <td>Food Processing</td>
                    <td>10</td>
                    <td>25</td>
                    <td>Hardoi</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>200</td>
                    <td>22000136</td>
                    <td>GERMINATE INFRA ENERGY </td>
                    <td></td>
                    <td></td>
                    <td>germinateinfraenergy@gmail.com</td>
                    <td>Anurag Kumar Gauri Shankar Sachan </td>
                    <td>Partner </td>
                    <td>919426995901</td>
                    <td>GROUP HOUSING</td>
                    <td>GROUP HOUSING JHANSI AREA REQUIRED 20000 SQFEET</td>
                    <td>Group Housing </td>
                    <td>10</td>
                    <td>30</td>
                    <td>Jhansi</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>201</td>
                    <td>22000097</td>
                    <td>Shanti nath manufacturers</td>
                    <td></td>
                    <td></td>
                    <td>snmsupreme@gmail.com</td>
                    <td>Ravi Jain</td>
                    <td>Proprietor </td>
                    <td>919811558264</td>
                    <td>Shanti Nath Manufacturers New Unit</td>
                    <td>Setup of an integrated manufacturing facility having complete in house processes from casting, machining, plating , testing and assembly of bathroom and kitchen faucets and acessories.</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>10</td>
                    <td>200</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>202</td>
                    <td>22000093</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>info@restorehealthmedicare.com</td>
                    <td>Dr Pranjal Patel</td>
                    <td>Director</td>
                    <td>918795886699</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td>Authorized Vehicle Scrap Facility (AVSF) by Restorehealth Medicare Private Limited</td>
                    <td>Recycling </td>
                    <td>10</td>
                    <td>100</td>
                    <td>Auraiya</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>203</td>
                    <td>22000089</td>
                    <td>SHREE UDYOG</td>
                    <td></td>
                    <td></td>
                    <td>shreeudyog1@gmail.com</td>
                    <td>Prem Chand Jain</td>
                    <td>Partner</td>
                    <td>919336505518</td>
                    <td>SHREE UDYOG</td>
                    <td>MANUFACTURING OF EDIBLE OIL AND NON EDIBLE OIL AND INDUSTRIAL CHEMICAL</td>
                    <td>Food Processing</td>
                    <td>10</td>
                    <td>15</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>204</td>
                    <td>22000081</td>
                    <td>SHREE ASR MOTOCORP PVT. LTD.</td>
                    <td></td>
                    <td></td>
                    <td>ashishsttspl@gmail.com</td>
                    <td>Ashish Gupta</td>
                    <td>DIRECTOR</td>
                    <td>919839034662</td>
                    <td>AUTOMOBILE PRODUCTS</td>
                    <td>Rubber Tyre and Other product manufacturing</td>
                    <td>Automobile</td>
                    <td>10</td>
                    <td>75</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>205</td>
                    <td>22000054</td>
                    <td>M/S SAURABH INDUSTRIES</td>
                    <td></td>
                    <td></td>
                    <td>agarwal.saurabh43@yahoo.com</td>
                    <td>Sanjay Kumar Agarwal</td>
                    <td>PARTNER</td>
                    <td>919415047906</td>
                    <td>PLYWOOD &amp; VENEER</td>
                    <td>PLYWOOD &amp; VENEER</td>
                    <td>Furniture</td>
                    <td>10</td>
                    <td>60</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>206</td>
                    <td>23008218</td>
                    <td>RONAK JAIN</td>
                    <td></td>
                    <td></td>
                    <td>jainrahul_11@yahoo.com</td>
                    <td>RONAK JAIN</td>
                    <td></td>
                    <td>919999955903</td>
                    <td>SUNRISE IMPEX INDIA</td>
                    <td>TRADING OF INDUSTRIAL HOSES</td>
                    <td>Other </td>
                    <td>10</td>
                    <td>25</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>207</td>
                    <td>22000115</td>
                    <td>Sudarshan Minchem Limited </td>
                    <td></td>
                    <td></td>
                    <td>niketsaraf@sudarshangroup.net</td>
                    <td>Niket Saraf</td>
                    <td>Manager</td>
                    <td>919925207570</td>
                    <td>Sodium Silicate and Mineral Manufacturing Plant</td>
                    <td>
                        Our Group of Companies is manufacturing Dolomite, Calcite, China Clay, Talk, Various Minerals and Sodium Silicate Liquid,_x000D_
                        _x000D_
                        At Sumerpur we will start Sodium Silicate and Minerals Manufacturing unit
                    </td>
                    <td>Non metallic and mineral products </td>
                    <td>9</td>
                    <td>50</td>
                    <td>Hamirpur</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>208</td>
                    <td>22005188</td>
                    <td>Gee Kay Leisures</td>
                    <td></td>
                    <td></td>
                    <td>varunagarwals@gmail.com</td>
                    <td>Varun Agarwal</td>
                    <td>Partner</td>
                    <td>919919229966</td>
                    <td>GEE KAY WAREHOUSING</td>
                    <td>Proposed project is for building green and modern warehousing</td>
                    <td>Logistics and Warehousing </td>
                    <td>8</td>
                    <td>10</td>
                    <td>Sitapur</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>209</td>
                    <td>22000258</td>
                    <td>RAM RAJ GASES PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>rajiv22singh@gmail.com</td>
                    <td>Rajiv Prakash Singh</td>
                    <td>DIRECTOR</td>
                    <td>919839510144</td>
                    <td>OXYGEN GAS PLANT</td>
                    <td>GAS PLANT</td>
                    <td>Electricity, Gas, Steam and Aircondition Supply</td>
                    <td>8</td>
                    <td>50</td>
                    <td>Mau</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>210</td>
                    <td>22000086</td>
                    <td>ONE STOP SCRAP</td>
                    <td></td>
                    <td></td>
                    <td>anand@pitstopmechatronics.com</td>
                    <td>Aaditya Singh</td>
                    <td>PARTNER</td>
                    <td>918826999336</td>
                    <td>METAL ALLOYS PRODUCTION &amp; SCRAP RECYCLING</td>
                    <td>The company will produce metal alloys from raw material ingots of lead ,aluminum , copper which will be used by lead battery , cable industry... It will also be involved in recycling of plastic and making PET , PPCP chips and daana</td>
                    <td>Casting of metals</td>
                    <td>8</td>
                    <td>35</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>211</td>
                    <td>22000228</td>
                    <td>K K SERVICES</td>
                    <td></td>
                    <td></td>
                    <td>GOLDIEALLD@GMAIL.COM</td>
                    <td>Amit Kumar</td>
                    <td>PROPRITOR</td>
                    <td>919559210101</td>
                    <td>Ware House</td>
                    <td>50000 Sq Feet covered Area plus utility</td>
                    <td>Logistics and Warehousing </td>
                    <td>7</td>
                    <td>20</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>212</td>
                    <td>22001498</td>
                    <td>M/s Harit Agrovet India </td>
                    <td></td>
                    <td></td>
                    <td>vimal_tripathi2000@yahoo.com</td>
                    <td>Dr Vimal Kumar Tripathi </td>
                    <td>Proprietor </td>
                    <td>919628312019</td>
                    <td>M/s Harit Agrovet India</td>
                    <td>Poultry feed &amp; cattle Feed unit setup in I.A Jagadishpur District- Amehti</td>
                    <td>Agro Processing </td>
                    <td>6.5</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>213</td>
                    <td>22000118</td>
                    <td>MS VIJAYA INDUSTRIES</td>
                    <td></td>
                    <td></td>
                    <td>himanshubahalvns@gmail.com</td>
                    <td>Himanshu Bahal</td>
                    <td>PROPRIETORSHIP</td>
                    <td>919307273690</td>
                    <td>WRITING BOARD &amp; PAPER STATIONARY</td>
                    <td>SETTING UP WRITING BOARD &amp; PAPER STATIONARY AT I.A. IIDC, CHANDAULI</td>
                    <td>Paper Manufacturing</td>
                    <td>6.46</td>
                    <td>10</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>214</td>
                    <td>22000530</td>
                    <td>M/S G S FASHION</td>
                    <td></td>
                    <td></td>
                    <td>aftabkhan25785@gmail.com</td>
                    <td>Aftab Alam</td>
                    <td>PROPRIETOR</td>
                    <td>919910562909</td>
                    <td>READYMADE GARMENTS</td>
                    <td>ALL TYPES OF GENTS, LADIES AND KIDS GARMENTS AND OTHER ALLIED PRODUCT</td>
                    <td>Textile </td>
                    <td>6</td>
                    <td>80</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>215</td>
                    <td>22000528</td>
                    <td>M/S SHAHANSHAH FABRICATION</td>
                    <td></td>
                    <td></td>
                    <td>focjeans@yahoo.com</td>
                    <td>Shahanshah Alam</td>
                    <td>PROPRIETOR</td>
                    <td>919313240239</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS AND ALL OTHER ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>6</td>
                    <td>80</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>216</td>
                    <td>22000422</td>
                    <td>M/S PRESIDENT INTERNATIONAL</td>
                    <td></td>
                    <td></td>
                    <td>umesh@presidentbag.in</td>
                    <td>J K Khurana</td>
                    <td>PROPRIETOR</td>
                    <td>919811508028</td>
                    <td>ALL TYPES OF BAGS AND READYMADE GARMENTS</td>
                    <td>ALL TYPES OF SCHOOL. CANVAS, WOVEN BAGS AND ALL KINDS OF READYMADE GARMENTS</td>
                    <td>Textile </td>
                    <td>6</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>217</td>
                    <td>22000401</td>
                    <td>M/S KRISHI TRACTORS</td>
                    <td></td>
                    <td></td>
                    <td>shalinigandhi213@yahoo.in</td>
                    <td>Pavnish Chander Gandhi</td>
                    <td>PROPRIETOR</td>
                    <td>919811066992</td>
                    <td>MANUFACTURING OF TRACTORS AND AUTO PARTS</td>
                    <td>MANUFACTURING OF ALL TYPES OF TRACTORS AND AUTO PARTS AND ALL OTHER ALLIED PRODUCTS</td>
                    <td>Automobile</td>
                    <td>6</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>218</td>
                    <td>22000063</td>
                    <td>PIT STOP MECHATRONICS LLP</td>
                    <td></td>
                    <td></td>
                    <td>anand197637@rediffmail.com</td>
                    <td>Anand Prashant P Singh</td>
                    <td>PARTNER</td>
                    <td>917011580221</td>
                    <td>Scrap lead acid battery smelting plant</td>
                    <td>This plant is part of recycling industry where in scrap lead acid batteries will be smelted and lead ingots will be extracted from them , which will be raw material for new lead acid battery manufacturing industry in market.. This industry will help in reducing pollution of earth by avoiding land fills of these scrap material and getting best out of waste there by saving our limited national lead resource. It will require investment about 6 Cr and employ 30 people.</td>
                    <td>Recycling </td>
                    <td>6</td>
                    <td>30</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>219</td>
                    <td>22000524</td>
                    <td>BHARAT AUTO ELECTRICALS</td>
                    <td></td>
                    <td></td>
                    <td>bharatindicator@gmail.com</td>
                    <td>Rakesh Sahni</td>
                    <td>PROPRIETOR</td>
                    <td>919999490066</td>
                    <td>AUTO MOBILE PART AND ALLIED PRODUCTS</td>
                    <td>REQUIRED AREA OF PLOT 1200 SQ MTR. (AUTO MOBILE PART AND ALLIED PRODUCTS)</td>
                    <td>Automobile</td>
                    <td>5.9</td>
                    <td>50</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>220</td>
                    <td>22000535</td>
                    <td>PIYUSH JAIN</td>
                    <td></td>
                    <td></td>
                    <td>piyushjain22@gmail.com</td>
                    <td>Piyush Jain</td>
                    <td>Proprietor</td>
                    <td>919891693040</td>
                    <td>CORRUGATED BOXES</td>
                    <td>REQUIRED AREA OF PLOT 1250 (CORRUGATED BOXES)</td>
                    <td>Paper Manufacturing</td>
                    <td>5.5</td>
                    <td>80</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>221</td>
                    <td>22005755</td>
                    <td>SHUPSH FEEDS PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>shwetasultanpa@gmail.com</td>
                    <td>Pawan Singh</td>
                    <td>Dirctor</td>
                    <td>919795633330</td>
                    <td>Warehouse / Silo</td>
                    <td>Here we will store grains, seeds, mustard oils, Fruits ad Etc.</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>20</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>222</td>
                    <td>22002324</td>
                    <td>M/s Subhra Hospital Orthopedic Center </td>
                    <td></td>
                    <td></td>
                    <td>santoshsingh887@gmail.com</td>
                    <td>Dr Santosh Singh </td>
                    <td>Proprietor </td>
                    <td>919415300281</td>
                    <td>M/s Subhra Hospital Training Center</td>
                    <td>M/s Subhra Hospital Training Center is set up in Industrial Area Jagadishpur District- Amethi New Hospital Project in the Region</td>
                    <td>College and Hospital</td>
                    <td>5</td>
                    <td>25</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>223</td>
                    <td>22001910</td>
                    <td>MAA TARA IRON AND STEEL WORKS</td>
                    <td></td>
                    <td></td>
                    <td>BHARATBHUSHAN448@GMAIL.COM</td>
                    <td>Bharat Bhushan Gupta</td>
                    <td>PARTNER</td>
                    <td>919838000040</td>
                    <td>S V B ENTERPRISES</td>
                    <td>WE ARE INTENDED TO SET UP A WAREHOUSE FOR STORAGE AND LOGISTICS</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>10</td>
                    <td>Varanasi</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>224</td>
                    <td>22001872</td>
                    <td>B R INFRAPROMOTERS PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>brinfra1@gmail.com</td>
                    <td>Vivekaditya Singh</td>
                    <td>DIRECTOR</td>
                    <td>917467805319</td>
                    <td>WAREHOUSING</td>
                    <td>WAREHOUSING</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>27</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>225</td>
                    <td>22001714</td>
                    <td>M/s Bhanu Enterprises </td>
                    <td></td>
                    <td></td>
                    <td>tejpratapsingh552@gmail.com</td>
                    <td>Kismati Singh </td>
                    <td>Proprietor </td>
                    <td>919721798892</td>
                    <td>Steel Almira</td>
                    <td>M/s Bhanu Enterprises unit of Steel Almira all ready production. Now Expansion in the unit</td>
                    <td>Basic Metal Manufacturing </td>
                    <td>5</td>
                    <td>25</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>226</td>
                    <td>22000527</td>
                    <td>Friends Associates</td>
                    <td></td>
                    <td></td>
                    <td>mayank7malik@gmail.com</td>
                    <td>Komal Kumar Malik</td>
                    <td>Partner</td>
                    <td>919999739579</td>
                    <td>READYMADE GARMENTS</td>
                    <td>ALL TYPES OF READYMADE GARMENTS</td>
                    <td>Textile </td>
                    <td>5</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>227</td>
                    <td>22000496</td>
                    <td>Mushiruddin</td>
                    <td></td>
                    <td></td>
                    <td>jamalindustries786@gmail.com</td>
                    <td>Mushiruddin</td>
                    <td>Prop</td>
                    <td>918738046828</td>
                    <td>Leather Goods</td>
                    <td>New Unit of Project Leather Goods</td>
                    <td>Leather and Footwear</td>
                    <td>5</td>
                    <td>30</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>228</td>
                    <td>22000449</td>
                    <td>M/s J.S. Enterprieses</td>
                    <td></td>
                    <td></td>
                    <td>rajeshmishra8550@gmail.com</td>
                    <td>Rajesh Kumar Mishra </td>
                    <td>Prop </td>
                    <td>919453768550</td>
                    <td>Interlocking Bricks</td>
                    <td>Interlocking Bricks</td>
                    <td>Non metallic and mineral products </td>
                    <td>5</td>
                    <td>150</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>229</td>
                    <td>22000425</td>
                    <td>M/S PRESIDENT BAGS</td>
                    <td></td>
                    <td></td>
                    <td>presidentbags@gmail.com</td>
                    <td>Kunal Khurana</td>
                    <td>PROPRIETOR</td>
                    <td>919811448028</td>
                    <td>ALL TYPES OF BAGS AND READYMADE GARMETNS</td>
                    <td>ALL TYPES OF SCHOOL BAGS, LAPTOP BAGS, CANVAS, WOVEN BAGS AND ALL TYPES OF LADIES, GENTS AND KIDS READYMADE GARMENTS</td>
                    <td>Textile </td>
                    <td>5</td>
                    <td>100</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>230</td>
                    <td>22000213</td>
                    <td>One Stop Professional Servies</td>
                    <td></td>
                    <td></td>
                    <td>siddhantupadhyaya2906@gmail.com</td>
                    <td>Siddhant Upadhyaya</td>
                    <td>Proprietor</td>
                    <td>919582085402</td>
                    <td>Readymade Garments And All Other Allied Products</td>
                    <td>Readymade Garments and all other allied products, all types of Ladies, Gents and Kids Garments.</td>
                    <td>Textile </td>
                    <td>5</td>
                    <td>70</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>231</td>
                    <td>22000088</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>info@restorehealthmedicare.com</td>
                    <td>Dr Pranjal Patel</td>
                    <td>Director</td>
                    <td>918795886699</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td>Common Bio Medical Waste Treatment Facility (CBWTF) by Restorehealth Medicare Private Limited</td>
                    <td>Waste processing </td>
                    <td>5</td>
                    <td>100</td>
                    <td>Maharajganj</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>232</td>
                    <td>22000087</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>info@restorehealthmedicare.com</td>
                    <td>Dr Pranjal Patel</td>
                    <td>Director</td>
                    <td>918795886699</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td>Common Bio Medical Waste Treatment Facility by Restorehealth Medicare Private Limited</td>
                    <td>Waste processing </td>
                    <td>5</td>
                    <td>100</td>
                    <td>Deoria</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>233</td>
                    <td>22000085</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>info@restorehealthmedicare.com</td>
                    <td>Dr Pranjal Patel</td>
                    <td>Director</td>
                    <td>918795886699</td>
                    <td>Restorehealth Medicare Private Limited</td>
                    <td>Common Bio Medical Waste Treatment Facility (CBWTF) by Restorehealth Medicare Private Limited</td>
                    <td>Waste processing </td>
                    <td>5</td>
                    <td>100</td>
                    <td>Jalaun</td>
                    <td>Jhansi</td>
                </tr>
                <tr>
                    <td>234</td>
                    <td>22000083</td>
                    <td>Ms Param Food products</td>
                    <td></td>
                    <td></td>
                    <td>paramfoods1991@gmail.com</td>
                    <td>Mukesh Kumar Tolani</td>
                    <td>Proprieter</td>
                    <td>919140670059</td>
                    <td>Param Food Products</td>
                    <td>Plot No E-17 Unit Has Been Production Other Plots Expansion new Unit</td>
                    <td>Food Processing</td>
                    <td>5</td>
                    <td>150</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>235</td>
                    <td>22006260</td>
                    <td>M/S K.A.G.S Reality Pvt. Ltd</td>
                    <td></td>
                    <td></td>
                    <td>gulabrailko@gmail.com</td>
                    <td>Gulab Rai</td>
                    <td></td>
                    <td>919415070046</td>
                    <td>Director </td>
                    <td>Petrol Diesel Pump Setup in Trishundi District- Amethi</td>
                    <td>Electricity, Gas, Steam and Aircondition Supply</td>
                    <td>5</td>
                    <td>10</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>236</td>
                    <td>23008432</td>
                    <td>AGASTYA COLD STORAGE AND AGRO INDUSTRIES LLP</td>
                    <td></td>
                    <td></td>
                    <td>chatwithpiyush@gmail.com</td>
                    <td>PIYUSH KUMAR</td>
                    <td></td>
                    <td>919838679464</td>
                    <td>AGASTYA COLD STORAGE AND AGRO INDUSTRIES LLP</td>
                    <td>COLD STORAGE</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>12</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>237</td>
                    <td>23008316</td>
                    <td>RAJESH KUMAR AGRAWAL</td>
                    <td></td>
                    <td></td>
                    <td>RAJESHKARWI61@GMAIL.COM</td>
                    <td>RAJESH KUMAR AGRAWAL</td>
                    <td></td>
                    <td>919415143585</td>
                    <td>BANARSI WAREHOUSE</td>
                    <td>SETUP TWO UNITS OF WAREHOUSE HAVING SIZE OF 20000/- SQUARE FEET EACH HAVING PROPER ROAD CONNECTIVITY AND PROPER PARKING AVAILABILITY.</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>15</td>
                    <td>Chitrakoot</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>238</td>
                    <td>23007257</td>
                    <td>SHUPSH FEEDS PRIVATE LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>ps2162479@gmail.com</td>
                    <td>Pawan Singh</td>
                    <td></td>
                    <td>917753816121</td>
                    <td>Warehouse / Silo</td>
                    <td>
                        Here we will store grains, seeds,_x000D_
                        mustard oils, Fruits ad Etc
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>20</td>
                    <td>Sultanpur</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>239</td>
                    <td>23010423</td>
                    <td>INDIAN LEHAR GOLD PVC PIPES</td>
                    <td></td>
                    <td></td>
                    <td>rohanjain207001@gmail.com</td>
                    <td>ROHAN JAIN</td>
                    <td>PARTNER</td>
                    <td>918447373033</td>
                    <td>INDIAN LEHAR GOLD PVC PIPES</td>
                    <td>MANUFACTURING OF PVC PIPES</td>
                    <td>Plastic Manufacturing </td>
                    <td>5</td>
                    <td>15</td>
                    <td>Etah</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>240</td>
                    <td>23010234</td>
                    <td>Ashvi Services</td>
                    <td></td>
                    <td></td>
                    <td>mahendra.kesarwani7@gmail.com</td>
                    <td>Mahendra Kesarwani</td>
                    <td>Director</td>
                    <td>919936972424</td>
                    <td>Ashvi Area Solutions</td>
                    <td>The manufacturers, distributors, exporters, transport companies use warehouses to store their products in one place so we basically provide them the Space for Warehouses and godown spaces. We have Planned to give huge hub of Godowns and Warehouses for companies .</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>35</td>
                    <td>Prayagraj</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>241</td>
                    <td>23010077</td>
                    <td>Septem Digisolutions pvt. Ltd.</td>
                    <td></td>
                    <td></td>
                    <td>sumit@septem.in</td>
                    <td>Sumit Maheshwari</td>
                    <td>Director</td>
                    <td>918795819912</td>
                    <td>Logistics and Warehouse</td>
                    <td>Logistics and Warehouse</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>20</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>242</td>
                    <td>22000523</td>
                    <td>LEELAY KHAN</td>
                    <td></td>
                    <td></td>
                    <td>jkprinter1987@gmail.com</td>
                    <td>Leelay Khan</td>
                    <td>PROPRIETOR</td>
                    <td>919312540383</td>
                    <td>CORRUGATED BOXES AND ALLIED PRODUCTS</td>
                    <td>REQUIRED AREA OF PLOT 600 SQ MTR. (CORRUGATED BOXES AND ALLIED PRODUCTS)</td>
                    <td>Paper Manufacturing</td>
                    <td>4.5</td>
                    <td>45</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>243</td>
                    <td>22000293</td>
                    <td>N.G WASH</td>
                    <td></td>
                    <td></td>
                    <td>Prahlad27july@gmail.com</td>
                    <td>Prahlad Singh Jangid</td>
                    <td>PROPRIETOR</td>
                    <td>919958558383</td>
                    <td>N.G WASH</td>
                    <td>READYMADE GARMENTS MANUFACTURING WASHING &amp; DYEING</td>
                    <td>Textile </td>
                    <td>4.5</td>
                    <td>75</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>244</td>
                    <td>22000289</td>
                    <td>FUNKYY </td>
                    <td></td>
                    <td></td>
                    <td>Funkyytronicacity@gmail.com</td>
                    <td>Ram Charan Khandelwal</td>
                    <td>PROPRIETOR</td>
                    <td>919811607771</td>
                    <td>READYMADE GARMENTS DYEING &amp; MANUFACTURING</td>
                    <td>FUNKYY READYMADE GARMENTS DYEING &amp; MANUFACTURING</td>
                    <td>Textile </td>
                    <td>4</td>
                    <td>70</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>245</td>
                    <td>22000071</td>
                    <td>M-Square Enterprises</td>
                    <td></td>
                    <td></td>
                    <td>darpanverma@optusnet.com.au</td>
                    <td>Darpan Verma</td>
                    <td>Proprietor</td>
                    <td>919711912876</td>
                    <td>M-Square Enterprises</td>
                    <td>Mining and Agriculture machinery parts</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>3.39</td>
                    <td>20</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>246</td>
                    <td>22000268</td>
                    <td>BHUMI GARMENTS</td>
                    <td></td>
                    <td></td>
                    <td>bgpl666@gmail.com</td>
                    <td>Jitender Kumar Kwatra</td>
                    <td>PROPRIETOR</td>
                    <td>919818409055</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS</td>
                    <td>Textile </td>
                    <td>3.23</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>247</td>
                    <td>22000266</td>
                    <td>DHANI CREATIONS</td>
                    <td></td>
                    <td></td>
                    <td>sandeepkwatra25@gmail.com</td>
                    <td>Sandeep Kwatra</td>
                    <td>PROPRIETOR</td>
                    <td>919871653050</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS</td>
                    <td>Textile </td>
                    <td>3.23</td>
                    <td>28</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>248</td>
                    <td>22000525</td>
                    <td>JAVED KHAN</td>
                    <td></td>
                    <td></td>
                    <td>uniqueprinter747@gmail.com</td>
                    <td>Javed Khan</td>
                    <td>PROPRIETOR</td>
                    <td>919899952505</td>
                    <td>CORRUGATED BOX AND OTHER ALLIED PRODUCTS</td>
                    <td>REQURIED AREA OF PLOT 450 SQ. MTR. (CORRUGATED BOX AND OTHER ALLIED PRODUCTS)</td>
                    <td>Paper Manufacturing</td>
                    <td>3</td>
                    <td>30</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>249</td>
                    <td>22000439</td>
                    <td>Kali Charan Industries</td>
                    <td></td>
                    <td></td>
                    <td>dude1dhsam@gmail.com</td>
                    <td>Sameer Gaurav</td>
                    <td>Partner</td>
                    <td>919986350555</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>Food Processing</td>
                    <td>3</td>
                    <td>25</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>250</td>
                    <td>22000133</td>
                    <td>M/s Artika Food Products </td>
                    <td></td>
                    <td></td>
                    <td>maheshkumar91389@gmail.com</td>
                    <td>Mahesh Kumar Agrawal </td>
                    <td>Proprietor </td>
                    <td>917985250143</td>
                    <td>M/s Artika Foods Products</td>
                    <td>Plot No 13/32 I.A Jagadishpur District- Amethi unit have been Production expansion in unit</td>
                    <td>Food Processing</td>
                    <td>3</td>
                    <td>60</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>251</td>
                    <td>23008744</td>
                    <td>NANHA BIBIPUR, FARMER PRODUCER COMPANY LIMITED</td>
                    <td></td>
                    <td></td>
                    <td>chauhanbks@gmail.com</td>
                    <td>BRAJESH KUMAR SINGH</td>
                    <td></td>
                    <td>918765180208</td>
                    <td>NANHA BIBIPUR FARMER PRODUCER COMPANY LIMITED</td>
                    <td>LOGISTIC</td>
                    <td>Logistics and Warehousing </td>
                    <td>3</td>
                    <td>50</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>252</td>
                    <td>22000347</td>
                    <td>JANARDAN</td>
                    <td></td>
                    <td></td>
                    <td>newvishwakarma516@gmail.com</td>
                    <td>Janardan</td>
                    <td>PROPRIETOR</td>
                    <td>919958861897</td>
                    <td>READYMADE GARMENTS AND ALLIED PRODUCTS</td>
                    <td>READYMADE GARMENTS AND ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>2.34</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>253</td>
                    <td>22000345</td>
                    <td>PAMS FASHION</td>
                    <td></td>
                    <td></td>
                    <td>larryjeans69@yahoo.com</td>
                    <td>Yash Pal Khurana</td>
                    <td>PROPRIETOR</td>
                    <td>919999709609</td>
                    <td>Readymade garments</td>
                    <td>READYMADE GAREMTNS AND OTHER ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>2.34</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>254</td>
                    <td>22000298</td>
                    <td>GURU TRADING CO</td>
                    <td></td>
                    <td></td>
                    <td>vikrambansal9555@gmail.com</td>
                    <td>Vikram</td>
                    <td>PROPRIETORSHIP</td>
                    <td>919555266677</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMETNS AND OTHER ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>2.34</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>255</td>
                    <td>22000287</td>
                    <td>S K DAYING</td>
                    <td></td>
                    <td></td>
                    <td>driveprasu@gmail.com</td>
                    <td>Dharmendra Kumar</td>
                    <td>PROPRIETORSHIP</td>
                    <td>919899828319</td>
                    <td>READYMADE GARMENTS</td>
                    <td>READYMADE GARMENTS AND OTHER ALLIED PRODUCTS</td>
                    <td>Textile </td>
                    <td>2.34</td>
                    <td>20</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>256</td>
                    <td>22000301</td>
                    <td>SONU BANSAL</td>
                    <td></td>
                    <td></td>
                    <td>sonubnsl9555@gmail.com</td>
                    <td>Sonu Bansal</td>
                    <td>Proprietorship</td>
                    <td>919555812211</td>
                    <td>Readymade Garments</td>
                    <td>Readymade garments and other allied products</td>
                    <td>Textile </td>
                    <td>2.26</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>257</td>
                    <td>22000072</td>
                    <td>Anchor India Automations</td>
                    <td></td>
                    <td></td>
                    <td>saomitra@gmail.com</td>
                    <td>Saumitra Mishra</td>
                    <td>Partner</td>
                    <td>919984886655</td>
                    <td>Anchor India Automations</td>
                    <td>Manufacturing of Rotogravure Printing cylinders and printing material</td>
                    <td>Printing </td>
                    <td>2.25</td>
                    <td>9</td>
                    <td>Kanpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>258</td>
                    <td>22002413</td>
                    <td>M/s Gupta Handicraft &amp; Sons</td>
                    <td></td>
                    <td></td>
                    <td>sanjay_carpet@yahoo.com</td>
                    <td>Mr Sanjay Kumar Gupta</td>
                    <td>Proprietor</td>
                    <td>919193572697</td>
                    <td>Gupta Handicraft &amp; Sons</td>
                    <td>Manufacturing of Hand knotted Woollen carpet and Durrie and marble Items</td>
                    <td>Textile </td>
                    <td>2</td>
                    <td>25</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>259</td>
                    <td>22002312</td>
                    <td>M/s M.K.General Engineering </td>
                    <td></td>
                    <td></td>
                    <td>krishnasingh.lic@gmail.com</td>
                    <td>Krishna Bahadur Singh </td>
                    <td>Proprietor </td>
                    <td>919450940813</td>
                    <td>General Engineering</td>
                    <td>M/s M.K.General Engineering . Unit all work of Iran like that gate, greeal jali etc.</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>2</td>
                    <td>15</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>260</td>
                    <td>22001970</td>
                    <td>M/s Raj Production </td>
                    <td></td>
                    <td></td>
                    <td>rp4528309@gmail.com</td>
                    <td>Sri Rajendra Prasad </td>
                    <td>Proprietor </td>
                    <td>918381839797</td>
                    <td>M/s Raj Production</td>
                    <td>Plot No F-24 Sector -21 I.A. Jagadishpur District- Amethi Unit of M/s Raj Production as been production now expansion in the unit</td>
                    <td>Other </td>
                    <td>2</td>
                    <td>20</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>261</td>
                    <td>22001962</td>
                    <td>M/S MG OIL</td>
                    <td></td>
                    <td></td>
                    <td>mgbd.vinay@gmail.com</td>
                    <td>Vinay Mishra </td>
                    <td>PROPREITOR</td>
                    <td>917565033333</td>
                    <td>MUSTERED OIL</td>
                    <td>MUSTERED OIL NEW PROJECT SETUP UPSIDA LAND JAGDISHPUR, AMETHI</td>
                    <td>Food Processing</td>
                    <td>2</td>
                    <td>20</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>262</td>
                    <td>22001806</td>
                    <td>M/s K.T,L Automobile Pvt Ltd </td>
                    <td></td>
                    <td></td>
                    <td>anshum1984rai@gmail.com</td>
                    <td>Sri Anshuman Rai </td>
                    <td>AGM</td>
                    <td>919839945294</td>
                    <td>M/s K.T.L.Automobile Pvt Ltd</td>
                    <td>Plot No E-32 I.A. Tikaria District Amethi unit have bee ruing now Expansion in unit</td>
                    <td>Automobile</td>
                    <td>2</td>
                    <td>15</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>263</td>
                    <td>22000474</td>
                    <td>M/s Geeta Machinery Stores</td>
                    <td></td>
                    <td></td>
                    <td>geeta.machinery1905@gmail.com</td>
                    <td>Sri Eshan Chopra</td>
                    <td>Proprietor</td>
                    <td>919919347778</td>
                    <td>Agriculture Machinery</td>
                    <td>Agri Papies and other machine tools</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>2</td>
                    <td>50</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>264</td>
                    <td>22000463</td>
                    <td>NAINCY ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>akumar570089@gmail.com</td>
                    <td>Ajay Kumar</td>
                    <td>Proprietor</td>
                    <td>917558644054</td>
                    <td>PLASTIC RECYCLINGH</td>
                    <td>PLASTIC RECYCLING</td>
                    <td>Recycling </td>
                    <td>2</td>
                    <td>15</td>
                    <td>Fatehpur</td>
                    <td>Kanpur</td>
                </tr>
                <tr>
                    <td>265</td>
                    <td>22000184</td>
                    <td>Sri Rishabhdev Industries Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>rishabhdevindustries@gmail.com</td>
                    <td>Ankur Jain</td>
                    <td>Director</td>
                    <td>919899044503</td>
                    <td>All Kind of Ferrous and Non Ferrous Metal Recovery and Segregation</td>
                    <td>To recovery and segregation of Ferrous and Non Ferrous metals</td>
                    <td>Casting of metals</td>
                    <td>2</td>
                    <td>10</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>266</td>
                    <td>22000062</td>
                    <td>JVKS AGROTECH PVT</td>
                    <td></td>
                    <td></td>
                    <td>JVKSAG@GMAIL.COM</td>
                    <td>Kamini Singh</td>
                    <td>DIRECTOR</td>
                    <td>918009271230</td>
                    <td>Moranga Based Nutrascuticals and Harbal Products</td>
                    <td>Moringa is a super nutritious food, but people do not eat it due to lack of information. Moringa has high antifungal, antiviral, antidepressant, and anti-inflammatory properties thus making it of high commercial value along with its nutritional advantage. Our JVKS Agrotech Pvt. Ltd. company processes integrated Moringa farming and value addition of Moringa based products so that people become aware of its benefits and they can improve their health, add necessary nutrition in childrenâ€™s diet.</td>
                    <td>Food Processing</td>
                    <td>2</td>
                    <td>20</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>267</td>
                    <td>22000060</td>
                    <td>M/S LIFE LINE NURSING HOME </td>
                    <td></td>
                    <td></td>
                    <td>qamer.khan1981@gmail.com</td>
                    <td>Sri Qamrul Hasan</td>
                    <td>Proprietor </td>
                    <td>919120604793</td>
                    <td>NURSING HOME</td>
                    <td>ESTABLISHING OF NURSING HOME</td>
                    <td>College and Hospital</td>
                    <td>2</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>268</td>
                    <td>22000049</td>
                    <td>M/S S.K. FOODS</td>
                    <td></td>
                    <td></td>
                    <td>vishen.bunty@gmail.com</td>
                    <td>Surabh Kumar Singh </td>
                    <td>PROPEIOTOR</td>
                    <td>917007049740</td>
                    <td>BAKERY</td>
                    <td>DIFFRIENT TYPE BAKERY PRODUCT</td>
                    <td>Food Processing</td>
                    <td>2</td>
                    <td>20</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>269</td>
                    <td>22005383</td>
                    <td>M/S LOKESH MALHOTRA INDUSTRIAL</td>
                    <td></td>
                    <td></td>
                    <td>lokesh.malhotra05@gmail.com</td>
                    <td>LOKESH MALHOTRA</td>
                    <td></td>
                    <td>919891111682</td>
                    <td>M/S Lokesh Malhotra Industrial</td>
                    <td>Machining Engineering Works</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>2</td>
                    <td>10</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>270</td>
                    <td>23009487</td>
                    <td>SURAJ FLOUR MILLS AND COMPANY</td>
                    <td></td>
                    <td></td>
                    <td>surajflourmills109@gmail.com</td>
                    <td>SANJAY KUMAR SINGHAL </td>
                    <td>PARTNER </td>
                    <td>919415048109</td>
                    <td>SURAJ FLOUR MILLS AND COMPANY</td>
                    <td>WAREHOUSING</td>
                    <td>Logistics and Warehousing </td>
                    <td>2</td>
                    <td>20</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>271</td>
                    <td>23009297</td>
                    <td>CCR PRINTING AND PACKEGING</td>
                    <td></td>
                    <td></td>
                    <td>sandeepkhari.dscb@gmail.com</td>
                    <td>SANEEP KHARI</td>
                    <td>PROPRIETOR</td>
                    <td>919873740077</td>
                    <td>CCR PRINTING AND PACKEGING</td>
                    <td>PAPER PRINTING AND PACKING</td>
                    <td>Paper Manufacturing</td>
                    <td>2</td>
                    <td>6</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>272</td>
                    <td>22001609</td>
                    <td>M/S GOOD LIFE BAKER </td>
                    <td></td>
                    <td></td>
                    <td>goodlifebaker2019@gmail.com</td>
                    <td>Naseem Ahmad</td>
                    <td>PROPRIETOR </td>
                    <td>916394282308</td>
                    <td>Bakery</td>
                    <td>Unit has been setup in plot No D-21.Sector-21 I.A Jagdadishpur Now expansion in Unit</td>
                    <td>Food Processing</td>
                    <td>1.7</td>
                    <td>15</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>273</td>
                    <td>23007116</td>
                    <td>Bhanauli warehouse</td>
                    <td></td>
                    <td></td>
                    <td>shamim.comsamim@gmail.com</td>
                    <td>Najiya rahman</td>
                    <td></td>
                    <td>919936737207</td>
                    <td>BHANAULI WAREHOUSE</td>
                    <td>WAREHOUSE IS PROPOSED FOR STORAGE OF FOOD GRAINS.</td>
                    <td>Logistics and Warehousing </td>
                    <td>1.6</td>
                    <td>8</td>
                    <td>Barabanki</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>274</td>
                    <td>22001759</td>
                    <td>M/s YASHIKA ENTERPRISES </td>
                    <td></td>
                    <td></td>
                    <td>pc.care@hotmail.com</td>
                    <td>Raj Kumar Yadav</td>
                    <td>Proprietor </td>
                    <td>919873110932</td>
                    <td>M/s Yashika Enterprises</td>
                    <td>M/s YASHIKA ENTERPRISES Unit of Coler Moter</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>1.5</td>
                    <td>20</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>275</td>
                    <td>22001729</td>
                    <td>RAM SAHAI MISHRA</td>
                    <td></td>
                    <td></td>
                    <td>mishraramsahai@gmail.com</td>
                    <td>Ram Sahai Mishra</td>
                    <td>Owner</td>
                    <td>919839042947</td>
                    <td>POULTRY FEEDS SUPPLEMENT</td>
                    <td>My Project of POULTRY FEEDS SUPPLEMENT</td>
                    <td>Agro Processing </td>
                    <td>1.5</td>
                    <td>30</td>
                    <td>Unnao</td>
                    <td>PO Trans Ganga</td>
                </tr>
                <tr>
                    <td>276</td>
                    <td>22001629</td>
                    <td>M/S I K BAG INDUSTRIES</td>
                    <td></td>
                    <td></td>
                    <td>i.k.bagindustries@gmail.com</td>
                    <td>Israr Ahmad </td>
                    <td>PROPRIETOR </td>
                    <td>919517043454</td>
                    <td>I.K. BAG INDUSTRIES</td>
                    <td>M/S I.K. BAG INDUSTRIES UNIT HAS BEEN PRODUCTION IN PLOT NO C-179 IA UTELWA DISTRICT- AMETHI</td>
                    <td>Textile </td>
                    <td>1.5</td>
                    <td>15</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>277</td>
                    <td>22000461</td>
                    <td>Neo Machine Tools Craft</td>
                    <td></td>
                    <td></td>
                    <td>ashadsaif407@gmail.com</td>
                    <td>Arshad</td>
                    <td>Proprietor</td>
                    <td>918010605297</td>
                    <td>Neo Machine Tools Craft</td>
                    <td>Neo Machine Tools Craft</td>
                    <td>Machinery and Equipment Manufacturing </td>
                    <td>1.5</td>
                    <td>22</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>278</td>
                    <td>23007184</td>
                    <td>M.F. TRADING COMPANY</td>
                    <td></td>
                    <td></td>
                    <td>ankit1991mittal@gmail.com</td>
                    <td>Ankit mittal</td>
                    <td></td>
                    <td>919759277089</td>
                    <td>LOGISTICS AND WAREHOUSE</td>
                    <td>
                        NEW WAREHOUSE DEVELOPMENT FOR STORAGE. (AREA - 25000 SQFT)_x000D_
                        SMALL COLD STORAGE CONSTRUCTION (AREA- 2000SQ FT)
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>1.5</td>
                    <td>15</td>
                    <td>Meerut</td>
                    <td>Meerut</td>
                </tr>
                <tr>
                    <td>279</td>
                    <td>22000129</td>
                    <td>M/S Surya Polytube Industries</td>
                    <td></td>
                    <td></td>
                    <td>raviprakash0001@gmail.com</td>
                    <td>Ravi Prakash</td>
                    <td>Partner</td>
                    <td>919839264440</td>
                    <td>PVC SUCTION PIPE &amp; PVC GARDEN PIPE, LAY FLAT TUBE</td>
                    <td>PVC SUCTION PIPE &amp; PVC GARDEN PIPE, LAY FLAT TUBE(AGRICULTURE FILE)</td>
                    <td>Plastic Manufacturing </td>
                    <td>1.32</td>
                    <td>12</td>
                    <td>Chandauli</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>280</td>
                    <td>23009496</td>
                    <td>NA</td>
                    <td></td>
                    <td></td>
                    <td>pandit.sharma3392@gmail.com</td>
                    <td>NEERAJ SHARMA</td>
                    <td>PROPRIETOR</td>
                    <td>919410224095</td>
                    <td>ALL TYPES OF FABRICATION WORK AND JOB WORK ALSO</td>
                    <td>ALL TYPES OF FABRICATION WORK AND JOB WORK ALSO</td>
                    <td>Casting of metals</td>
                    <td>1.25</td>
                    <td>25</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>281</td>
                    <td>22006732</td>
                    <td>Pyarelal Murarilal</td>
                    <td></td>
                    <td></td>
                    <td>pyarelalmurarilal@gmail.com</td>
                    <td>Ranjeet Agarwal</td>
                    <td></td>
                    <td>917983271611</td>
                    <td>Proprietor</td>
                    <td>M/s Pyarelal Murarilal since its inception (in 1988) has been working in field of metal sheet cutting and processing mainly in CR, HR and GALUM Sheets for local Locks, Hardware, Buckle and Toys industries. Our focus was to reuse the waste sheet metal cutting which was economical and viable option in competitive market and process it to make it reusable. Our process is eco-friendly and comes under non-polluting unit, we would like to step up in Warehousing &amp; Processing of sheet metal that would cater defence industries, Electrical components industries, local lock and hardware industries and auto industries, for that we require Hi-tech machinery for better quality and 2000 Square Meter of land in Aligarh</td>
                    <td>Basic Metal Manufacturing </td>
                    <td>1.15</td>
                    <td>12</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>282</td>
                    <td>23009891</td>
                    <td>P M Electronics</td>
                    <td></td>
                    <td></td>
                    <td>pmelectronicsalg@gmail.com</td>
                    <td>Meena Agarwal</td>
                    <td>Proprietor</td>
                    <td>919897021715</td>
                    <td>Warehousing of Commercial Freezer and Refrigeration</td>
                    <td>M/s P.M Electronics since it&#39;s inception in 2007 is Retailer and wholesaler of Commercial Freezer and Refrigeration, the product is bulky and weighted to be stored in small space for which we require proper warehousing for storage of commercial freezer and refrigeration in safe and secured environment for that we need 1000 sq meter of land space with all necessary amenities like road , water supply and electricity for our required project.</td>
                    <td>Logistics and Warehousing </td>
                    <td>1.01</td>
                    <td>10</td>
                    <td>Aligarh</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>283</td>
                    <td>22002164</td>
                    <td>THE HERMAIN</td>
                    <td></td>
                    <td></td>
                    <td>atiqus83@gmail.com</td>
                    <td>Atiq Ahmad</td>
                    <td>Proprietor</td>
                    <td>918874257918</td>
                    <td>Ware housr</td>
                    <td>ware house</td>
                    <td>Logistics and Warehousing </td>
                    <td>1</td>
                    <td>20</td>
                    <td>Gonda</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>284</td>
                    <td>22001986</td>
                    <td>M/s Meena Agrovate &amp; Feeds </td>
                    <td></td>
                    <td></td>
                    <td>dmsolanki8104@gmail.com</td>
                    <td>Smt Azra Hayat </td>
                    <td>Proprietor </td>
                    <td>918317040519</td>
                    <td>M/s Meena Agrovate &amp; Feeds</td>
                    <td>Feed Mill Hatchery</td>
                    <td>Agro Processing </td>
                    <td>1</td>
                    <td>50</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>285</td>
                    <td>22000753</td>
                    <td>RABIA KHATOON</td>
                    <td></td>
                    <td></td>
                    <td>anwarrabia1479@gmail.com</td>
                    <td>Rabia Khatoon</td>
                    <td>PROPRIETOR</td>
                    <td>918299203030</td>
                    <td>WASHING POWDER</td>
                    <td>WASHING POWDER UNIT SETUP ON UPSIDA LAND, AMETHI</td>
                    <td>Chemical Manufacturing</td>
                    <td>1</td>
                    <td>20</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>286</td>
                    <td>22000435</td>
                    <td>Industry</td>
                    <td></td>
                    <td></td>
                    <td>majmabegum9102@gmail.com</td>
                    <td>Najma Begum</td>
                    <td>Tronica city gaziyabad</td>
                    <td>918920888795</td>
                    <td>Na book binding</td>
                    <td>Binding of books</td>
                    <td>Other </td>
                    <td>1</td>
                    <td>8</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>287</td>
                    <td>22000389</td>
                    <td>Vaishno Enterpr</td>
                    <td></td>
                    <td></td>
                    <td>anamikagupta.ag55@gmail.com</td>
                    <td>Poonam Gupta</td>
                    <td>Proprietor</td>
                    <td>919311851351</td>
                    <td>Lamination and Printing of school book</td>
                    <td>Vaishno Enterprises</td>
                    <td>Printing </td>
                    <td>1</td>
                    <td>9</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>288</td>
                    <td>22000386</td>
                    <td>Uma printers</td>
                    <td></td>
                    <td></td>
                    <td>zerk0795@gmail.com</td>
                    <td>Ashish Kumar</td>
                    <td>Propritor</td>
                    <td>919711065999</td>
                    <td>UMA PRINTERS</td>
                    <td>PRINTINGS OF SCHOOL BOOKS</td>
                    <td>Printing </td>
                    <td>1</td>
                    <td>6</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>289</td>
                    <td>22000277</td>
                    <td>RED REEF DESIGN STUDIO</td>
                    <td></td>
                    <td></td>
                    <td>shambhu16682ster@gmail.com</td>
                    <td>Arvind Singh Negi</td>
                    <td>PARTNER</td>
                    <td>919891272494</td>
                    <td>RED REEF DESIGN STUDIO</td>
                    <td>DESIGN AND PRINTING</td>
                    <td>Printing </td>
                    <td>1</td>
                    <td>15</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>290</td>
                    <td>22000142</td>
                    <td>Lovely Beverages </td>
                    <td></td>
                    <td></td>
                    <td>akshayrajpathak@gmail.com</td>
                    <td>Akshay Kumar </td>
                    <td>Director</td>
                    <td>917678017405</td>
                    <td>LOVELY BEVERAGES</td>
                    <td>Mfg and bottling of packaged drinking water and related goods</td>
                    <td>Food Processing</td>
                    <td>1</td>
                    <td>10</td>
                    <td>Hardoi</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>291</td>
                    <td>22000127</td>
                    <td>M/s Khushboo Agro Foods </td>
                    <td></td>
                    <td></td>
                    <td>ashishtiloi78@gmail.com</td>
                    <td>Ashish Jaiswal</td>
                    <td>Proprietor </td>
                    <td>918400877777</td>
                    <td>Bakery</td>
                    <td>Bakery unit all ready production expansion</td>
                    <td>Food Processing</td>
                    <td>1</td>
                    <td>15</td>
                    <td>Amethi</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>292</td>
                    <td>22000106</td>
                    <td>Nra excel products India pvt ltd. </td>
                    <td></td>
                    <td></td>
                    <td>nraexcelproductsindiapvtltd@gmail.com</td>
                    <td>Rakhi Pandey</td>
                    <td>Director</td>
                    <td>919811570771</td>
                    <td>Nra excel projects India pvt ltd</td>
                    <td>Food processing</td>
                    <td>Food Processing</td>
                    <td>1</td>
                    <td>20</td>
                    <td>Ghaziabad</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>293</td>
                    <td>23008505</td>
                    <td>SHAILENDRA MOHAN MISHRA</td>
                    <td></td>
                    <td></td>
                    <td>mishra.sm15@gmail.com</td>
                    <td>SHAILENDRA MOHAN MISHRA</td>
                    <td></td>
                    <td>919670475000</td>
                    <td>SHAILENDRA MOHAN MISHRA</td>
                    <td>WAREHOUSE</td>
                    <td>Logistics and Warehousing </td>
                    <td>1</td>
                    <td>20</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>294</td>
                    <td>23012285</td>
                    <td>SEEDHESHWARI PROMOTER AND BUILDERS PVT LTD</td>
                    <td></td>
                    <td></td>
                    <td>seedheshwari@gmail.com</td>
                    <td>INDU MAHESHWARI</td>
                    <td>DIRECTOR</td>
                    <td>917982866332</td>
                    <td>Warehouse and Godown</td>
                    <td>Project Details to be submitted later</td>
                    <td>Other </td>
                    <td>600</td>
                    <td>250</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>295</td>
                    <td>23012279</td>
                    <td>King Solutions Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>rent@pcrent.in</td>
                    <td>Amit Arora</td>
                    <td>Director</td>
                    <td>919810133388</td>
                    <td>E-Vehicles</td>
                    <td>Manufacturing of Electric Vehicles</td>
                    <td>Automobile</td>
                    <td>115</td>
                    <td>700</td>
                    <td>Mathura</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>296</td>
                    <td>23012267</td>
                    <td>Verticon Infrastructure Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>mereamit@yahoo.com</td>
                    <td>Amit Arora</td>
                    <td>Director</td>
                    <td>919810133387</td>
                    <td>Bevereges &amp; Fruit Products</td>
                    <td>Juice, Pulp, Mineral Water, Soda &amp; Shikanji Etc.</td>
                    <td>Food Processing</td>
                    <td>26</td>
                    <td>270</td>
                    <td>Sambhal</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>297</td>
                    <td>23012259</td>
                    <td>E-Waste Recyclers India</td>
                    <td></td>
                    <td></td>
                    <td>ceo@ewri.in</td>
                    <td>Sunita Arora</td>
                    <td>Proprietor</td>
                    <td>919810398787</td>
                    <td>Dairy Products &amp; Food Industry</td>
                    <td>Chips, Popcorn, Snacks, Biscuits, Cheese, Butter &amp; Milk Products</td>
                    <td>Food Processing</td>
                    <td>30</td>
                    <td>300</td>
                    <td>Sambhal</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>298</td>
                    <td>23012208</td>
                    <td>E-Waste Recyclers India</td>
                    <td></td>
                    <td></td>
                    <td>ceo@ewri.in</td>
                    <td>Sunita Arora</td>
                    <td>Proprietor</td>
                    <td>919810398787</td>
                    <td>Dairy Products &amp; Food Industry</td>
                    <td>Chips, Popcorn, Corn Snacks, Biscuit, Cheese, Butter &amp; Milk Powder etc.</td>
                    <td>Food Processing</td>
                    <td>75</td>
                    <td>470</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>299</td>
                    <td>23012182</td>
                    <td>King Solutions Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>rent@pcrent.in</td>
                    <td>Amit Arora</td>
                    <td>Director</td>
                    <td>919810133388</td>
                    <td>Food Product Processing Unit</td>
                    <td>Manufacturing of Namkin, Chips, Kurkure, Corn Products &amp; Maida Products</td>
                    <td>Food Processing</td>
                    <td>75</td>
                    <td>500</td>
                    <td>Hathras</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>300</td>
                    <td>23012026</td>
                    <td>SHRI VIJAY TRADING COMPANY</td>
                    <td></td>
                    <td></td>
                    <td>singhalsanjay261@gmail.com</td>
                    <td>RAJAT SINGHAL </td>
                    <td>PARTNER </td>
                    <td>919953859955</td>
                    <td>SHRI VIJAY TRADING COMPANY</td>
                    <td>WAREHOUSING</td>
                    <td>Logistics and Warehousing </td>
                    <td>2</td>
                    <td>25</td>
                    <td>Ayodhya</td>
                    <td>Ayodhya</td>
                </tr>
                <tr>
                    <td>301</td>
                    <td>23012019</td>
                    <td>IIA Industrial park</td>
                    <td></td>
                    <td></td>
                    <td>jpkaushik@gmail.com</td>
                    <td>JP kaushik </td>
                    <td>CEO</td>
                    <td>919810477766</td>
                    <td>IIA Industrial park</td>
                    <td>private industrial park</td>
                    <td>Private Industrial Park</td>
                    <td>1000</td>
                    <td>500</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>302</td>
                    <td>23011730</td>
                    <td>Umeandus</td>
                    <td></td>
                    <td></td>
                    <td>rajeev@umeandus.in</td>
                    <td>Ms Rajeev Chanan</td>
                    <td>N/A</td>
                    <td>9594988046</td>
                    <td>Logistics Infrastructure</td>
                    <td>Freight &amp; Logistics infra to connect MMLP Industrial Corridor to DFC with New Infrastructure</td>
                    <td>Logistics and Warehousing </td>
                    <td>10000</td>
                    <td>5000</td>
                    <td>Basti</td>
                    <td>Gorakhpur</td>
                </tr>
                <tr>
                    <td>303</td>
                    <td>23011718</td>
                    <td>REC Ltd</td>
                    <td></td>
                    <td></td>
                    <td>cmd@recl.in</td>
                    <td>Mr Vivek Kumar Dewangan</td>
                    <td>N/A</td>
                    <td>8130009976</td>
                    <td>Infra &amp; Logistics</td>
                    <td>Infra &amp; Logistics</td>
                    <td>Logistics and Warehousing </td>
                    <td>20000</td>
                    <td>3000</td>
                    <td>Bareilly</td>
                    <td>Bareilly</td>
                </tr>
                <tr>
                    <td>304</td>
                    <td>23011663</td>
                    <td>Omkiran Logistics Park (Phase 2)- A unit of SMC Enterprises Private Limited </td>
                    <td></td>
                    <td></td>
                    <td>amitmittal@smcenterprises.in</td>
                    <td>AMIT MITTAL</td>
                    <td>Director</td>
                    <td>919891966700</td>
                    <td>Om Kiran Logistics Park Phase 2</td>
                    <td>
                        OM KIRAN LOGISTICS PARK -PHASE 2_x000D_
                        _x000D_
                        Name of the Applicant: Om Kiran Logistics Park â€“ Phase II _x000D_
                        A Unit of SMC Enterprises Pvt Ltd_x000D_
                        Address: Om Kiran Building, A 10, sector 19, Noida 201301 Uttar Pradesh_x000D_
                        Chairman: B K Mittal_x000D_
                        Directors: Sudhir Agarwal_x000D_
                        Amit Mittal_x000D_
                        Summary: _x000D_
                        Mr B K Mittal the Chairman of the Group â€“ SMC Enterprises Private Limited, a 36-year-old company that has interests in Warehousing, distribution, eCommerce, business support services, market development and shared office. _x000D_
                        _x000D_
                        Om Kiran Logistics â€“ A unit of SMC Enterprises Private Limited, is into the business of developing warehouse parks for around 2 decades and owns a 4.5-lacs square feet area spread across multiple buildings as well as open yard storage space in Ghaziabad. The group intends to expand in the same logistics and warehousing line and wants to enter the logistics market near the upcoming Jewar Airport area._x000D_
                        Now that the Government of Uttar Pradesh has launched a scheme under the name â€œInvest UPâ€ Promoted by the Investment Promotion and Facilitation Agency of the Government of Uttar Pradesh We, the group are keen to participate in Invest UP scheme and like to apply for a 50-acre land parcel suitable for setting up a distribution warehouse and logistics Park._x000D_
                        Logistics Park shall have dry space as well as temperature-controlled facilities and intend to cater for the storage and warehousing of the following products_x000D_
                        1.	Agro &amp; Food_x000D_
                        2.	Textiles &amp; Garments_x000D_
                        3.	Beverages â€“ Alcoholic &amp; Non-alcoholic_x000D_
                        4.	White goods_x000D_
                        5.	Automobile spare parts_x000D_
                        6.	FMCG products_x000D_
                        7.	Sports goods_x000D_
                        8.	Pharmaceuticals_x000D_
                        9.	Material handling equipment_x000D_
                        10.	Automation products and many more_x000D_
                        _x000D_
                        Details_x000D_
                        1.	Area: approx. 50 acres ( 202343sqm) (1 acre-4046.86Sqm) _x000D_
                        2.	Application: Logistics and Warehouse Park _x000D_
                        Location Preference: (Paschimanchal) any area Near the Upcoming JEWAR AIRPORT_x000D_
                        1st Preference-Gautam Budh Nagar, _x000D_
                        2nd Preference- Hapur, _x000D_
                        3rd preference - Bulandshahr _x000D_
                        Capital Investment_x000D_
                        Super Mega Project- Rs.500Cr (Proposed)_x000D_
                        Employment Generation _x000D_
                        We expect to generate employment upwards of 600 people out of which a minimum 30% employment is earmarked for females.
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>512</td>
                    <td>599</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>306</td>
                    <td>23011475</td>
                    <td>Avani Paridhi Mining And Minerals Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>info@avaniparidhi.com</td>
                    <td>Agyat Gupta</td>
                    <td>Director</td>
                    <td>919415144445</td>
                    <td>Private Freight Terminal</td>
                    <td>
                        Willing to Establish the Private freight terminal in District Gazipur Teshil Saidpur village_x000D_
                        Gopalpur in sequence of Warehouse and Logistic Policy 2023 of Uttar Pradesh Government
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>150</td>
                    <td>300</td>
                    <td>Ghazipur</td>
                    <td>Varanasi</td>
                </tr>
                <tr>
                    <td>307</td>
                    <td>23011419</td>
                    <td>Ravi Rajan Infraventure (OPC) Private Limited</td>
                    <td></td>
                    <td></td>
                    <td>ravirajinfraventure@gmail.com</td>
                    <td>Ravindra Mohan Pachori</td>
                    <td>Director</td>
                    <td>919927700753</td>
                    <td>RAVI RAJANI INFRAVENTURES (OPC) PRIVATE LIMITED</td>
                    <td>Promoter is investing in Warehouse Business in Agra .</td>
                    <td>Logistics and Warehousing </td>
                    <td>20</td>
                    <td>40</td>
                    <td>Agra</td>
                    <td>Agra</td>
                </tr>
                <tr>
                    <td>308</td>
                    <td>23011350</td>
                    <td>WOCAL FOR LOCAL</td>
                    <td></td>
                    <td></td>
                    <td>founder@wocalforlocal.com</td>
                    <td>Dipinti Rajput</td>
                    <td>Co Founder</td>
                    <td>919793238432</td>
                    <td>WOCAL FOR LOCAL</td>
                    <td>We are running E-commerce startup , Required 10000 Square feet Land for warehouse &amp; office . Our startup providing online market place to msme, sme &amp; micro manufacturers. Our Concept is promoting ODOP &amp; make In India Products. Current now we have 28000+ Pin codes pickup &amp; drop services.</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>75</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                <tr>
                    <td>309</td>
                    <td>23011242</td>
                    <td>SBR motors pvt ltd.</td>
                    <td></td>
                    <td></td>
                    <td>tyagi.ashish35@gmail.com</td>
                    <td>Budh Prakash tyagi</td>
                    <td>MD</td>
                    <td>919761800252</td>
                    <td>FARMHOUSE</td>
                    <td>warehouse</td>
                    <td>Logistics and Warehousing </td>
                    <td>5</td>
                    <td>20</td>
                    <td>Hapur</td>
                    <td>Ghaziabad</td>
                </tr>
                <tr>
                    <td>310</td>
                    <td>23010937</td>
                    <td>Edugayn Infotech Pvt Ltd</td>
                    <td></td>
                    <td></td>
                    <td>edugyaninfotech@gmail.com</td>
                    <td>Slok Kumar</td>
                    <td>CEO</td>
                    <td>919311033026</td>
                    <td>Sonbhadra Energy Park</td>
                    <td>
                        In the association of RECS Incubation &amp; Innovation Foundation, Edugyan Infotech Pvt Ltd and its team of Industrialist, are planning to
                        develop this proposed Energy Park along with Common Facility Center, the park will facilitate ready-to-move workspace backed up
                        essential High Tech Quality Control Lab, ESTP, Power, Road, Waiting Lounges, Cafeteria, Open Gym and Park.
                    </td>
                    <td>Private Industrial Park</td>
                    <td>375</td>
                    <td>2450</td>
                    <td>Sonbhadra</td>
                    <td>Prayagraj</td>
                </tr>
                <tr>
                    <td>311</td>
                    <td>23010919</td>
                    <td>ATAS IMPEX</td>
                    <td></td>
                    <td></td>
                    <td>anujjain519@gmail.com</td>
                    <td>ANUJ JAIN</td>
                    <td>PROPRIETOR</td>
                    <td>917017983709</td>
                    <td>ATAS IMPEX</td>
                    <td>MANUFACTURING IF PAVING BLOCKS</td>
                    <td>Non metallic and mineral products </td>
                    <td>2</td>
                    <td>15</td>
                    <td>Etah</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>312</td>
                    <td>23010874</td>
                    <td>Fastflow polymers</td>
                    <td></td>
                    <td></td>
                    <td>rohanjain282@gmail.com</td>
                    <td>Rohan jain</td>
                    <td>Proprietor</td>
                    <td>918938994752</td>
                    <td>Fastflow polymer</td>
                    <td>manufacturing of pvc pipes</td>
                    <td>Plastic Manufacturing </td>
                    <td>4</td>
                    <td>15</td>
                    <td>Etah</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>313</td>
                    <td>23010864</td>
                    <td>ANUJ ENTERPRISES</td>
                    <td></td>
                    <td></td>
                    <td>anujenterprises1205@gmail.com</td>
                    <td>ANUJ JAIN </td>
                    <td>PROPRIETOR</td>
                    <td>919412430900</td>
                    <td>ANUJ ENTERPRISES</td>
                    <td>PROCESSING OF CHICORY</td>
                    <td>Food Processing</td>
                    <td>5</td>
                    <td>15</td>
                    <td>Etah</td>
                    <td>Aligarh</td>
                </tr>
                <tr>
                    <td>314</td>
                    <td>23010694</td>
                    <td>Falcon Moovers</td>
                    <td></td>
                    <td></td>
                    <td>falconcargomovers53@gmail.com</td>
                    <td>Naresh Kumar</td>
                    <td>Proprietor </td>
                    <td>919891185431</td>
                    <td>Logistic work land allotment</td>
                    <td>
                        Falcon Moovers has proposed to construct a warehouse near International Airport being constructed near Jawar in Gautam Buddha Nagar District_x000D_
                        Uttar Pradesh.
                    </td>
                    <td>Logistics and Warehousing </td>
                    <td>2</td>
                    <td>30</td>
                    <td>Gautam Buddha Nagar</td>
                    <td>Surajpur</td>
                </tr>
                <tr>
                    <td>315</td>
                    <td>23010637</td>
                    <td>WAREKART LOGISTICS LLP</td>
                    <td></td>
                    <td></td>
                    <td>warekartlogistics@gmail.com</td>
                    <td>PRANAY GUPTA</td>
                    <td>AUTHORISED SIGNATORY</td>
                    <td>918188054013</td>
                    <td>WAREKART LOGISTICS</td>
                    <td>New Logistics Unit to be developed at Village - Bhaundari, Tehsil - Mohanlal Ganj, Lucknow. The proposed project has total land area of 127877 Sq Mt with ground coverage of 63554.49 sq mt and FAR of 79516.45 sq mt. The total estimated Investment / Cost of the proposed project is Rs 125 Crores (approx).</td>
                    <td>Logistics and Warehousing </td>
                    <td>125</td>
                    <td>1000</td>
                    <td>Lucknow</td>
                    <td>Lucknow</td>
                </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
