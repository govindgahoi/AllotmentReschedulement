<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tronica.aspx.cs" Inherits="Allotment.tronica" %>

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
                <div id="top_button" runat="server"><% Response.WriteFile("FlagshipProjectMenus.aspx"); %> </div>
            </div>
            <div class="row" id="SideDiv">
                <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="text-center park-main-heading" style="font-size: 25px;">Trans-Delhi Signature City, Ghaziabad</h4>
                        </div>
                    </div>
                    <div class="row">                          
                        <div class="col-md-6"> 
                            <h4 class="park-inner-heading">Trans-Delhi Signature City, Ghaziabad</h4>
                            <p class="text-justify font-12px"><a href="#Google-map" target="_blank">Latitude, Longitude - 23.43718, 87.25307</a> (Click to view map)</p>
                            <p class="font-12px">Ultra-Modern Trans Delhi Signature (TDS) City has been planned as a smart self sustained City. Located in the much vaunted Ghaziabad (NCR), latest international standard development strategies will make it energy efficient by using renewable sources of energy and recycling of waste products. About 1700 acres of land has been developed so far. The driving force of economic and commercial growth, coupled with aesthetic values will mark TDS city as a milestone for development.</p>
                            
                            
                            <p class="text-justify font-12px">The Apparel Park at TDS City is one of the major attractions. Apart from the infra facilities provided by UPSIDC like road, drain, sewer line, water supply, streetlight, police station, nationalized banks, ATMs, schools and post office, the project has a number of unique features:</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Water and solid waste management through STP and CETP.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Concealed under Ground Utilities Network.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Regional Transport through multi-modal transit hub at Anand Vihar and Kashmere Gate.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Broad concrete four lane entrance road marks the entry to the industrial area.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Risk Mitigation from Natural Calamities.</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading">Facilities and infrastructure</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Situated at a distance of approx. 45 kms. from Delhi International Airport.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> State-of-the-art infrastructure with like road, drain, sewer line, water supply, streetlight, police station, nationalized banks, ATMs, schools and post office</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading" style="font-size:13px;background:#e8e8e8;padding:6px 3px;">Details of acquired and developed lands</h4> 
                            <table class="table table-hover table-bordered request-table">
                                <tr>
                                    <th class="text-center-imp">Land Use</th>
                                    <th class="text-center-imp">Area in Acers</th>
                                    <th class="text-center-imp">Land Use</th>
                                    <th class="text-center-imp">Area in Acers</th>
                                </tr>
                                <tr>
                                    <td>Residential</td>
                                    <td>752.58</td>
                                    <td>Residential</td>
                                    <td>538.88</td>
                                </tr>
                                <tr>
                                    <td>Group Housing</td>
                                    <td>93.46</td>
                                    <td>Commercial</td>
                                    <td>21.15</td>
                                </tr>
                                <tr>
                                    <td>Sector B-4 (Commercial ) </td>
                                    <td>25.69</td>
                                    <td>Institutional and Facilities</td>
                                    <td>53.02</td>
                                </tr>
                                <tr>
                                    <td>Green belt and Central Park</td>
                                    <td>60.70</td>
                                    <td>Major Roads</td>
                                    <td>110.27</td>
                                </tr>
                                <tr>
                                    <td>S.T.P./ Oxidation Pond </td>
                                    <td>44.28</td>
                                    <td>Captive Power Plant </td>
                                    <td>16.45</td>
                                </tr>
                            </table>
                        </div>  
                        <div class="col-md-6">
                            <h4 class="park-inner-heading">Trans-Delhi Signature City, Ghaziabad on Google Map</h4> 
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27974.980298370436!2d77.24921808036909!3d28.783061334391174!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x390cff15cad3ae2d%3A0xa6d5925ef63a9ca4!2sTrans+Delhi+Signature+City%2C+Ghaziabad%2C+Uttar+Pradesh+201102!5e0!3m2!1sen!2sin!4v1510824554171" width="100%" height="600" frameborder="0" style="border:0" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="clearfix"></div> 
                    <div class="row"> 
                        <div class="col-md-6"> 
                            <h4 class="park-inner-heading">USPs of the Project</h4>
                            <p class="font-12px">The project features are as follows:</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Well planned sectors for industrial, residential, group housing, institutional and commercial plots with aesthetically developed green zones as per the master plan.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Land earmarked for various public utilities like – hospital, fire station, petrol pumps, club house, community centre etc.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Uninterrupted 24 hours power supply through UPPCL and Captive Power Plant (CPP).</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The upcoming Dadri station of WDFC and Khurja station of EDFC will facilitate rail freight transfer and the industrial corridor being developed in the region, will be a major attraction for all the industries setting up their units in Tronica.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Availability of skilled manpower due to close proximity of quality educational institutions and colleges (IMT Ghaziabad, Delhi University).</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> More than 2100 industrial units and more than 4000 residential plots have been allotted by UPSIDC.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> More than 300 flats constructed in modern multi- storied residential buildings by private developers under the Group Housing category.</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Close proximity to the CONCOR depot at Dadri for convenient freight transfer.</p>
                                </li>                                
                            </ul>
                        </div>
                        <div  class="col-md-6">
                            <h4 class="park-inner-heading">Investment Opportunities</h4>
                            <b class="font-12px">Industrial</b>
                            <p class="font-12px">
                                With “Apparel Park” as the major attraction for TDS city, it will naturally spawn a huge plethora of supporting industries such as:
                            </p>
                            <ul class="list-unstyled park-inner-ul">
                                <li><p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Garments dying, bleaching and printing in the earmarked polluting zones.</p></li>
                                <li><p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Garments sewing, embroidery and knitting in the earmarked non-polluting zones.</p></li>
                            </ul>
                            <p class="font-12px">
                                TDS city also has the presence of a number on General Industries like footwear manufacturing, water packaging and so on.
                            </p>
                            <b class="font-12px">Residential Units</b>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Two types of residential zones like Group Housing and plots are available.</p>
                                </li>
                                <li>
                                    <p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> More than 4400 residential plots have been planned from 100 Sq. Mt. to 350 Sq. Mt. in size, out of which around 250 are open for allotment.</p>
                                </li>
                            </ul>
                            <b class="font-12px">Commercial </b>
                            <p class="font-12px">
                                Aims to be a self-sustained city with commercial establishments such as shopping complexes, malls, theatre, multiplexes, restaurants, auto showrooms, hotels and other commercial establishments.
                            </p>
                            <b class="font-12px">Institutional </b>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> As an integrated township the focus is on encouraging various educational institutions such as schools and colleges.</p>
                                </li>
                                <li>
                                    <p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Two well known schools have constructed their branches in TDS city.</p>
                                </li>
                                <li>
                                    <p class="font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Apparel training centre and special ITI can be established for leveraging the knitting and woollen industry.</p>
                                </li>
                            </ul>
                        </div>
                    </div>
                    
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Trans-Delhi Signature City Layout</h4> 
                            <img src="images/tronicalayout.jpg" width="100%" class="img-responsive" alt="Tronica Layout"/>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">                          
                        <div class="col-md-8">
                            <h4 class="park-inner-heading">Location Advantage</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i>  Located 2 km from Delhi border. </p>

                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Lies on Delhi Saharanpur state highway (SH 57).</p>

                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 6 km from upcoming Eastern Peripheral Expressway (encircling Delhi).</p>

                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 12 km from Kashmere Gate bus terminal.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 12 km from Shahdara Metro Station on red line of Delhi Metro.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 6 km from upcoming Shiv Vihar Metro Station of Delhi Metro.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 45 km from Delhi International Airport.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 6 km from Loni Railway Station.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> About 50 km from Dadri, upcoming Western Dedicated Freight Corridor (WDFC) station.</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> About 120 km from Khurja, upcoming Eastern Dedicated Freight Corridor (EDFC) station.</p> 
                                </li>
                            </ul>
                            <h4 class="park-inner-heading">Details of allotted and vacant plots</h4>
                        </div>  
                        <div class="col-md-4">
                            <img src="images/tronica1.jpg" class="img-responsive" alt="Tronica Location"/>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row"> 
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">UP Industrial Policy 2017 Highlights</h4> 
                            <p class="font-12px">The incentives are as follows:</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px">
                                        1. Stamp duty exemption of 75% in Madhyanchal
                                    </p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        2. EPF reimbursement facility to the extent of 50% of employer’s contribution to all such new Industrial units providing direct employment to 100 or more unskilled workers.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"> 
                                        3. Capital Interest Subsidy to the extent of 5% per annum for 5 years in the form of reimbursement on loan taken for procurement of plant & machinery, subject to an annual ceiling of INR 50 lacs. 
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        4. Infrastructure Interest Subsidy to the extent of 5% per annum for 5 years in the form of reimbursement on loan taken for development of infrastructural amenities for self-use like roads, sewer, water drainage, erection of power line, transformer and power feeder, subject to an overall ceiling of INR 1 Crore.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        5. Interest subsidy to the extent of 5% per annum for 5 years in the form of reimbursement on loan taken for industrial research, quality improvement and development of products by incurring expenditure on procurement of plant, machinery & equipment for setting up testing labs, quality certification labs and tool rooms, subject to an overall ceiling of INR 1 Crore.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        6. Exemption from electricity duty to all new industrial units set up in the state for 10 years.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        7. Exemption from electricity duty for 10 years to all new industrial units producing electricity from captive power plants for self-use.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        8. Exemption from Mandi fee for all new food processing units on purchase of raw material for 5 years.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        9. The industries which are disallowed for input tax credit under the GST regime, will be provided reimbursement of that amount of VAT/CST/GST paid on purchase of plant and machinery, building material and other capital goods during construction and commissioning period and raw materials and other inputs in respect of which input tax credit has not been allowed.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        10. Units generating minimum employment of 200 direct workers including skilled and unskilled will be provided 10% additional EPF reimbursement facility on employer’s contribution.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        11. All incentives in the form of reimbursement, subsidies, exemptions etc., will be subject to a maximum of 90% of fixed capital investment made in Madhyanchal region.
                                    </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px">
                                        12. The eligibility requirements for the respective categories are as follows:
                                    </p>
                                    <table class="table table-bordered table-hover request-table">
                                        <tr>
                                            <th>Category</th>
                                            <th>Minimum eligibility requirements (Madhyanchal)</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                Mega
                                            </td>
                                            <td>
                                                Capital investment of more than Rs.150 crore but less than Rs.300 crore OR Providing employment to more than 750 workers.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Mega Plus
                                            </td>
                                            <td>
                                                Capital investment of more than Rs.300 Crores but less than Rs.750 crore OR Providing employment to more than 1500 workers.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Super Mega
                                            </td>
                                            <td>
                                                Capital investment of more than Rs.750 Crore OR Providing employment to more than 3000 workers.
                                            </td>
                                        </tr>
                                    </table>                                    
                                    <ul class="list-unstyled park-inner-ul">
                                        <li>
                                            <p class="text-justify font-12px">
                                                A. The incentives will be applicable for new units as well as projects under expansion/diversification. Projects in the mega categories (mega, mega plus and super mega) will be processed on a case to case basis for finalising the incentive structure.
                                            </p> 
                                        </li>
                                        <li>
                                            <p class="text-justify font-12px">
                                                B. All incentives for mega investments in the form of reimbursement, subsidies, exemptions etc., will be subject to a maximum of 200% of fixed capital investment made in Madhyanchal region.
                                            </p> 
                                        </li>
                                    </ul>
                                    <p class="font-12px">The Conditions for (12.) are as follows:</p>
                                    <ul class="list-unstyled park-inner-ul">
                                        <li>
                                            <p class="text-justify font-12px">
                                                <i class="fa fa-angle-right" aria-hidden="true"></i> 
                                                Units availing incentives from any other policy or those sanctioned by the departments of the State government, will also be entitled to avail incentives/benefits mentioned in this policy provided the same kind of benefits/incentives are not being availed from any other policy. If a unit avails any incentive under industry specific policies like Agro & Food Processing Policy, IT Policy etc., it will not be provided incentive of similar nature under this policy.
                                            </p> 
                                        </li>
                                        <li>
                                            <p class="text-justify font-12px">
                                                <i class="fa fa-angle-right" aria-hidden="true"></i> 
                                                A negative list of industries will be identified which will be ineligible for any incentives mentioned in this policy. However if any package of incentives has already been committed by the state government to any such unit before the industry was declared negative, the committed incentives will not be withdrawn and the unit will continue to remain entitled to the benefits.
                                            </p> 
                                        </li>
                                    </ul>
                                </li>
                            </ul>
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
                            <p class="font-12px">2. <span class="font-bold">Shri Himanshu Mishra</span><br />Project Office,Trans Delhi Signature City<br />Trans Delhi Signature City, Ghaziabad<br />Phone: 0120-2696644<br />Email: potronica[at]upsidc[dot]com</p>   
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
