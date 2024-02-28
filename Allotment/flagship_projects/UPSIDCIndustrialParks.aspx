<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UPSIDCIndustrialParks.aspx.cs" Inherits="Allotment.UPSIDCIndustrialParks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/Footer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div>
                    <div class="navbar-header pull-left top-head-bg">
                        <a href="../Default.aspx" class="navbar-brand">
                            <div class="col-md-8">
                                <img class="img-responsive" src="logo.jpg" />
                            </div>
                            <div class="col-md-4">
                                <img class="img-responsive" src="Image.jpg" />
                            </div>
                        </a>

                    </div>
                </div>
                <div id="top_button" runat="server"><% Response.WriteFile("FlagshipProjectMenus.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                    <h2 class="text-center main-heading-grey">UPSIDC Flagship Projects</h2>
                    <hr class="myhrline" />
                    <hr style="margin:10px 0;"/>
                    <table class="table table-bordered table-hover request-table" style="width:100%;">
                        <tr class="active">
                            <th>Sl. No.</th>
                            <th>District</th>
                            <th>Flagship Projects</th>
                            <th>Total Available Areas(in acres)</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Unnao</td>
                            <td><a href="TransGangaCity.aspx">Trans-Ganga Hitech  City</a></td>
                            <td>1144.1</td>
                        </tr>
                        <tr class="active">
                            <td>2</td>
                            <td>Allahabad</td>
                            <td><a href="SaraswatiCity.aspx">Saraswati Hitech City</a></td>
                            <td>1138.78</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Bhaupur</td>
                            <td><a href="IMCBhaupur.aspx">IMC Bhaupur Project</a></td>
                            <td>2211</td>
                        </tr>
                        <tr class="active">
                            <td>4</td>
                            <td>Auraiya</td>
                            <td><a href="PlasticCity.aspx">Dibiyapur Plastic Park</a></td>
                            <td>367.73</td>
                        </tr>
                        <tr class="active">
                            <td>5</td>
                            <td>Ghaziabad</td>
                            <td><a href="tronica.aspx">Trans-Delhi Signature City(Tronica)</a></td>
                            <td>2821.72</td>
                        </tr>
                        <tr class="active">
                            <td>6</td>
                            <td>Kannuaj</td>
                            <td><a href="PerfumePark.aspx">Perfume Park</a></td>
                            <td>100</td>
                        </tr>
                        <tr>
                            <td>7</td>
                            <td>Bareilly</td>
                            <td><a href="BaheriIndustrialArea.aspx">Baheri Industrial Area</a></td>
                            <td>251</td>
                        </tr>
                        <tr class="active">
                            <td>8</td>
                            <td>Ramaipur, Kanpur</td>
                            <td><a href="MegaLeatherCluster.aspx">Mega Leather Cluster (MLC) Project</a></td>
                            <td>103</td>
                        </tr>
                        <tr>
                            <td>9</td>
                            <td>Moradabad</td>
                            <td><a href="MoradabadSEZ.aspx">Moradabad Special Economic Zone (SEZ)</a></td>
                            <td>467</td>
                        </tr>
                        <tr>
                            <td>10</td>
                            <td>Kanpur</td>
                            <td><a href="#">Mandhana</a></td>
                            <td>464.28</td>
                        </tr>
                        <tr>
                            <td>11</td>
                            <td>Agra</td>
                            <td><a href="ThemePark.aspx">Theme Park Seven Cities</a></td>
                            <td>1060.80</td>
                        </tr>
                    </table>



                     <h2 class="text-center main-heading-grey">Industrial Areas of UPSIDC</h2>
                    <hr class="myhrline" />

                       <asp:GridView ID="Allottee_master_grid" 
                                 runat="server"  ShowFooter="true"
                                 CssClass="request-table table table-striped table-bordered table-hover"                              
                                 AutoGenerateColumns="true" 
                                >
                     </asp:GridView>
                  
                    <hr class="myhrline" />
                    <div id="footer_id" runat="server"><% Response.WriteFile("/public_footer.aspx"); %> </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
