<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Allotment.PropertyHub.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>U.P. State Industrial Development Authority</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="images/fevicon.ico" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link rel="canonical" href="xyz.com" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <!--style-->
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <!--responsive-->
    <link href="css/animate.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/lightbox2/2.8.2/css/lightbox.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>

    <link rel="stylesheet" href="css/bootstrap-theme.min.css" />
    <link href="css/site.css" rel="stylesheet" type="text/css" />
    <style>
        .dt-button {
            position: relative;
            display: inline-block;
            box-sizing: border-box;
            margin-left: 5.333em;
            margin-bottom: 10px;
            padding: 0.5em 1em;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
            font-size: 0.88em;
            color: black;
            white-space: nowrap;
            overflow: hidden;
            background-color: #e9e9e9;
            background-image: -webkit-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -moz-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -ms-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -o-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: linear-gradient(to bottom, #fff 0%, #e9e9e9 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0,StartColorStr='white', EndColorStr='#e9e9e9');
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            text-decoration: none;
            outline: none;
        }

        input.search {
            width: 100%;
            height: 40px;
            padding: 10px;
            margin-bottom: 37px;
        }

        table thead th {
            background-color: #000c4e;
            color: white;
        }

        select {
            width: 100%;
            display: block;
            text-align: left;
            margin-top: 11px;
            border: 1px solid #ccc;
            padding: 5px 7px;
            text-transform: uppercase;
            font-size: 12px;
            height: 40px;
        }

        #statisticsHeader {
            background-color: #E91E63;
            color: #fff;
            padding: 5px;
            text-align: center;
            font-size: 18px;
        }

        #statisticsContent {
            padding-top: 20px;
            padding-bottom: 13px;
            background-color: white;
        }

        i.fa.fa-search {
            position: absolute;
            top: 10px;
            right: 28px;
        }
    </style>
    <!--animation-->
</head>
<%--<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>--%>
<body>
    <form runat="server">
        <div id="page-warpper">
            <header class="header fixed-top" id="myHeader">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="logo" style="padding: 0px;">
                                <a href="#" class="external selected">
                                    <img src="images/logo.png" class="img-responsive uplogo" alt="Logo of UPSIDA Department" title="Uttar Pradesh UPSIDA">
                                </a>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <nav class="navbar navbar-expand-lg navbar-light">
                                <a class="navbar-brand" href="">
                                    <img src="images/logo-2.jpg"></a>
                                <button class="navbar-toggler justify-content-left " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>

                                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                                    <ul class="navbar-nav ml-auto">
                                        <li class="nav-item active"><a class="nav-link" href="">Property <span class="sr-only">(current)</span></a> </li>

                                        <li class="nav-item"><a class="nav-link " href="https://www.onlineupsidc.com/Regionaloffice.aspx" target="_blank">Contact Us</a> </li>

                                    </ul>

                                </div>
                            </nav>
                        </div>

                    </div>
                </div>
            </header>
            <section class="slide-sec">
                <article>
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <!--<li data-target="#carouselExampleIndicators" data-slide-to="0" ></li>-->
                            <li data-target="#carouselExampleIndicators" data-slide-to="1" class="active"></li>
                        </ol>
                        <div class="carousel-inner">

                            <div class="">
                                <img class="d-block w-100" src="images/slider-1.jpg" alt="First slide">
                            </div>

                        </div>
                    </div>

                </article>
            </section>
            <main id="main">


                <section class="figure ">

                    <div class="container">
                        <div class="row" style="display: none;">
                            <div class="col-md-4 col-lg-3"></div>
                            <div class="col-md-4 col-lg-6 text-center ">
                                <asp:TextBox ID="txtsearchBox" placeholder="Search Properties By Sector / Location" class="search" runat="server"></asp:TextBox>
                                <%--            <input type="text" placeholder="Search Properties By Sector / Location" class="search"><i class="fa fa-search"></i></div>--%>
                                <div class="col-md-4 col-lg-3"></div>

                            </div>
                        </div>

                        <div class="container">

                            <div class="linkstitle1">
                                <span>EXPLORE LAND BANK OF UPSIDA<br />
                                </span>In 3 easy Steps: Select | Explore | Book
                            </div>
                            <div class="row">

                                <div class="col-md-12 col-lg-12">
                                    <ul class="impo-information">
                                        <li><a href="" class="external none"><span>
                                            <img src="images/icon-1.png" title="" alt="" class="img-responsive"></span>Proposed Sector</a>

                                            <asp:DropDownList ID="ddlpraposedSector" runat="server" aria-label="Focus Sector Filter">
                                            </asp:DropDownList>
                                        </li>
                                        <li><a href="" class="external none"><span>
                                            <img src="images/icon-3.png" title="" alt="" class="img-responsive"></span>District</a>

                                            <asp:DropDownList ID="ddldistrict" runat="server" aria-label="District Filter">
                                            </asp:DropDownList>
                                        </li>
                                        <li><a href="" class="external none"><span>
                                            <img src="images/icon-5.png" alt="" title="" class="img-responsive"></span>Estimated Price (In Cr)</a>
                                            <asp:DropDownList ID="ddlCostPrice" runat="server" aria-label="Investment Capacity Filter">
                                                <asp:ListItem Value="0" Selected="true">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">10 Lakhs to 1 Cr.</asp:ListItem>
                                                <asp:ListItem Value="2">1 Cr. to 10 Cr.</asp:ListItem>
                                                <asp:ListItem Value="3">10 Cr. to 50 Cr.</asp:ListItem>
                                                <asp:ListItem Value="4">50 Cr. to 100 Cr.</asp:ListItem>
                                                <asp:ListItem Value="5">Above 100 Cr.</asp:ListItem>
                                            </asp:DropDownList>
                                        </li>
                                        <li><a href="" class="external none"><span>
                                            <img src="images/icon-2.png" class="img-responsive" title="" alt=""></span>Plot Size
                                            (in Sqmts.)</a>
                                            <asp:DropDownList ID="ddlPlotSize" runat="server" aria-label="Plot Size Filter">
                                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">200 Sqmt to 1000 Sqmt.</asp:ListItem>
                                                <asp:ListItem Value="2">1000 Sqmt to 2000 Sqmt.</asp:ListItem>
                                                <asp:ListItem Value="3">2000 Sqmt to 5000 Sqmt.</asp:ListItem>
                                                <asp:ListItem Value="4">5000 Sqmt to 10000 Sqmt.</asp:ListItem>
                                                <asp:ListItem Value="5">Above 10000 Sqmt.</asp:ListItem>
                                            </asp:DropDownList>
                                    </ul>
                                </div>
                                <div class="col-md-4 col-lg-4"></div>
                                <div class="col-md-4 col-lg-4 text-center">
                                    <asp:Button ID="btnExplore" runat="server" Text="Explore Properties" class="btn btn-danger" OnClick="btnExplore_Click" />
                                    <%--<a href="" class="btn btn-danger">

            </a>--%>
                                </div>
                                <div class="col-md-4 col-lg-4"></div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                </section>

                <div id="statisticsContainer" class="viewContainer">
                    <div id="statisticsHeader">
                        <span>UPSIDA Land Bank Statistics</span>
                    </div>
                    <div class="container">
                    </div>

                    <div style="float: left; margin-left: 80px; align-content: space-around; display: none">
                    </div>
                    <div style="float: right; margin-right: 80px; align-content: space-around; display: none">
                    </div>
                    <div id="statisticsContent">
                        <div class="container">
                            <table style="width: 100%; align-content: space-around" class="table table-bordered" id="hdrData" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <label>Display Page</label>
                                        <asp:DropDownList ID="ddlSelPage" aria-label="Focus Sector Filter" Width="60px" OnSelectedIndexChanged="btnExplore_Click" AutoPostBack="true" runat="server">
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>100</asp:ListItem>
                                            <asp:ListItem>200</asp:ListItem>
                                            <asp:ListItem>500</asp:ListItem>
                                            <asp:ListItem>1000</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <label>Total Available Plots : <asp:Label ID="lblPlotsNo" runat="server" Text=""></asp:Label></label>
                                    </td>
                                    <td style="">
                                        <label>&nbsp;</label>
                                        <input id="expoExcle" runat="server" type="button" class="dt-button  btn btn-success" onclick="tableToExcel('statisticsContent', 'Example Table')" value="Export to Excel">
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="grdPlotData" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="grdPlotData_PageIndexChanging" class="table table-striped table-bordered table-hover request-table" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IndustrialClassificationName" HeaderText="Proposed Sector" />
                                    <asp:BoundField DataField="RegionalOffice" HeaderText="District" />
                                    <asp:BoundField DataField="IAName" HeaderText="Industrial Area Name" />
                                    <asp:BoundField DataField="IARatePerSqmt" HeaderText="Estimate Price(Per SQMTR)" />
                                    <asp:BoundField DataField="PlotNumber" HeaderText="Plot Number" />
                                    <asp:BoundField DataField="PlotArea" HeaderText="Available Plot Size (SQMTR)" />
                                    <asp:TemplateField HeaderText="Total Estimated Cost (In Rupee)">
                                        <ItemTemplate>
                                            <asp:Label ID="totalcost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Land Locator">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLandLoc" class="btn btn-primary" runat="server" OnClick="MyButtonClick1"><b >GIS</b></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Now">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBookNow" class="btn btn-success" runat="server" OnClick="MyButtonClick"><b >Nivesh Mitra</b></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                 
                                </Columns>
                            </asp:GridView>
                            <%--<table>

                        <thead>
                            <tr class="table-head3">
                        <th>Sr. No.</th>
                                <th>Name</th>
                                 <th>Designation</th>
                                <th>Mobile No.</th>
                                 <th>Email ID</th>
                    </tr>
                            
                        </thead>
                        <tbody>
                            <tr>
                                <td>1.</td>
                                <td>Mr. Lokendra Pal Singh</td>
                                 <td>Assistant General Manager</td>
                                 <td>9205691016</td>
                                 <td>-</td>
                            </tr>
                           <tr>
                                <td>1.</td>
                                <td>Mr. Lokendra Pal Singh</td>
                                 <td>Assistant General Manager</td>
                                 <td>9205691016</td>
                                 <td>-</td>
                            </tr>
                          <tr>
                                <td>1.</td>
                                <td>Mr. Lokendra Pal Singh</td>
                                 <td>Assistant General Manager</td>
                                 <td>9205691016</td>
                                 <td>-</td>
                            </tr>
                           
                        </tbody>

                    </table>
                            --%>
                        </div>
                    </div>

                </div>
            </main>
            <footer>
                <!----------close bottom header------->


                <div class="copyright text-center">
                    <div class="container-fluid">
                        <div class="col-12 col-lg-12">
                            <p>UPSIDA Complex, A-1/4 Lakhanpur, Kanpur-208024</p>
                            <p>Phone: 0512-2582851, 2582852, 2582853</p>
                            <p>Fax:0512-2580797</p>
                            <ul class="social-media-footer">

                                <li class="social-icon"><a href="https://www.facebook.com/UPSIDAGoUP" target="_blank"><i class="fa fa-facebook" title="facebook"></i></a></li>
                                <li class="social-icon"><a href="https://twitter.com/UPSIDA" target="_blank"><i class="fa  fa-twitter" title="twitter"></i></a></li>
                                <li class="social-icon"><a href="https://www.linkedin.com/company/upside-services" target="_blank"><i class="fa fa-linkedin" title="linkedin"></i></a></li>


                            </ul>
                        </div>
                    </div>
                </div>
        </div>
        <!--close page warpper-->

        <script src="js/jquery.min.js"></script>




        <script>
            // When the user scrolls the page, execute myFunction
            window.onscroll = function () { myFunction() };

            // Get the header
            var header = document.getElementById("myHeader");

            // Get the offset position of the navbar
            var sticky = header.offsetTop;

            // Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
            function myFunction() {
                if (window.pageYOffset > sticky) {
                    header.classList.add("sticky");
                } else {
                    header.classList.remove("sticky");
                }
            }
        </script>
        <%--<script type="text/javascript">
            $(document).ready(function () {
                $('[id*=grdPlotData]').prepend($("<thead></thead>").append($('[id*=grdPlotData]').find("tr:first"))).DataTable({
                    dom: 'Bfrtip',
                    'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],
                    'iDisplayLength': 20,
                    buttons: [
                        { extend: 'copy', text: 'Copy to clipboard', className: 'exportExcel', exportOptions: { modifier: { page: 'all' } } },
                        { extend: 'excel', text: 'Export to Excel', className: 'exportExcel', filename: 'Agenda_Excel', exportOptions: { modifier: { page: 'all' } } },
                        { extend: 'csv', text: 'Export to CSV', className: 'exportExcel', filename: 'Agenda_Csv', exportOptions: { modifier: { page: 'all' } } },
                        { extend: 'pdf', text: 'Export to PDF', className: 'exportExcel', filename: 'Agenda_Pdf', orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { modifier: { page: 'all' }, columns: ':visible' } }
                    ]
                });
            });
        </script>--%>


        <script type="text/javascript">
            var tableToExcel = (function () {
                var uri = 'data:application/vnd.ms-excel;base64,'
                  , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
                  , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
                  , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
                return function (table, name) {
                    if (!table.nodeType) table = document.getElementById(table)
                    var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
                    window.location.href = uri + base64(format(template, ctx))
                }
            })()
        </script>

    </form>
</body>
</html>
