<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemePark.aspx.cs" Inherits="Allotment.ThemePark" %>

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
                <div id="main_menu" runat="server"><% Response.WriteFile("FlagshipProjectMenus.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="text-center park-main-heading" style="font-size: 25px;">Theme Park Seven Cities, Agra</h4>
                        </div>
                    </div>
                    <div class="row">  
                        <div class="col-md-4">
                            <img src="images/themepark1.jpg" class="img-responsive" alt="Theme Park"/>
                        </div>
                        <div class="col-md-8"> 
                            <h4 class="park-inner-heading">Theme Park Seven Cities, Agra</h4>
                            <p class="text-justify font-12px"><a href="https://www.google.co.in/maps/place/Trans+Ganga+City/@26.5290289,80.3421807,17z/data=!3m1!4b1!4m5!3m4!1s0x399c393d42bdebd9:0x565ca2daa4b7e02!8m2!3d26.5290241!4d80.3443694?hl=en" target="_blank">Latitude, Longitude - 23.43718, 87.25307</a> (Click to view map)</p>
                            <p class="font-12px">Theme Park Seven Cities, Agra is spread over 1000 Acres of Agra.</p>                            
                            
                            <p class="text-justify font-12px">Theme Park Seven Cities is being developed to facilitated Hotels, Restaurent and Gaming zone centres in the city of Agra.</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> This project was a flagship project to promote tourism. </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Project to be developed as theme park depicting the history and culture of different  eras based on Indian Mythology. </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The project is to developed in Public-Private-Partnership Model (PPP).</p>
                                </li>
                            </ul>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>                    
                    <div class="row">                        
                        <div class="col-md-8">
                            <h4 class="park-inner-heading">Facilities and infrastructure</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The park will facilitate seven star luxury hotels, small hotels.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The park will facilitate restaurants.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Additional facilities include modern and a convention centre, gaming zones.</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading" style="font-size:13px;background:#e8e8e8;padding:6px 3px;">Details of acquired and developed lands</h4> 
                            <p class="font-12px">Acquired by UPSIDC 476-00 Acres and 584.80 acres handed over by Agra Development Authority </p>
                        </div> 
                        <div class="col-md-4">
                            <img src="images/themepark2.jpg" class="img-responsive" style="" alt="themepark1"/>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-8">
                            
                        </div> 
                        
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Theme Park Seven Cities Layout</h4> 
                            <img src="images/themeparklayout.jpg" class="img-responsive" alt="Theme Park Seven Cities"/>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">                          
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Location Advantage</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Villages Raghu bans Pura, Naglaa Nathauli and Rahankalan dist.-Agra.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Adjacent to Agra Ring Road, which connects the Yamuna Expressway and Lucknow – Agra Expressway.</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading">Details of allotted and vacant plots</h4> 
                            
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Theme Park City on Google Map</h4> 
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46060.01622291967!2d77.97977184499963!3d27.178942425213574!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x39740d857c2f41d9%3A0x784aef38a9523b42!2sAgra%2C+Uttar+Pradesh!5e0!3m2!1sen!2sin!4v1511850706517" width="100%" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    
                    <div class="row"> 
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Functional Units</h4>                             
                        </div>                          
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">   
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Expected Employment</h4>                             
                        </div>                                                 
                    </div>
                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Allotment of Land</h4> 
                            <p class="font-12px"><a href="#">Procedure of allotment of Land</a></p>
                            <p class="font-12px"><a href="#">Location of Vacant Plots</a></p>
                            <p class="font-12px"><a href="#">Terms & Conditions of Allotment</a></p>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Interested Investors may contact:</h4>                             
                            <p class="font-12px">1. <span class="font-bold">Shri Ranvir Prasad IAS</span><br />Managing Director, UPSIDC Complex<br />A-1/4 Lakhanpur, Kanpur<br />Phone: 0512-2582851, 2582852, 2582853<br />Email: md[at]upsidc[dot]com</p><br />
                            <p class="font-12px">2. <span class="font-bold">Shri Vinod Kumar</span><br />Regional Office, Agra<br />Administrative Building, EPIP, Shastripuram, Agra<br />Phone: 0562-2641924<br />Email: rmagra[at]upsidc[dot]com</p>   
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    <div id="footer_id" runat="server"><% Response.WriteFile("/public_footer.aspx"); %> </div>
                </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
