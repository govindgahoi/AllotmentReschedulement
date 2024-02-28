<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlasticCity.aspx.cs" Inherits="Allotment.PlasticCity" %>

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
                            <h4 class="text-center park-main-heading" style="font-size: 25px;">Dibiyapur Plastic Park, Auraiya</h4>
                        </div>
                    </div>
                    <div class="row">  
                        <div class="col-md-4">
                            <img src="images/plasticpark.jpg" class="img-responsive" alt="plasticpark"/>
                        </div>
                        <div class="col-md-8"> 
                            <h4 class="park-inner-heading">Dibiyapur Plastic Park, Auraiya</h4>
                            <p class="text-justify font-12px"><a href="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d28574.458150907627!2d79.49582617197026!3d26.461940782705028!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x399df3adae51a67b%3A0x8fdd186745eedbe5!2sAuraiya%2C+Uttar+Pradesh+206122!5e0!3m2!1sen!2sin!4v1510463797100" target="_blank">Latitude, Longitude - 23.43718, 87.25307</a> (Click to view map)</p>
                            <p class="font-12px">Dibiyapur Plastic Park, Auraiya is spread over 274.45 Acres of Land.</p>                            
                            
                            <p class="text-justify font-12px">Integrated Plastic Park in coordination with the, GAIL, NTPC, CIPET, MSME-DI & financial institutions (HUDCO, SIDBI and NABARD and others) is being set up.</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Park to be developed for distillation & manufacturing of Perfumes.  </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The perfume park will also house a special attar manufacturing zone in Kannuaj for modern distillation and extraction units. </p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> The project is to developed for setting up of international perfume museum..</p>
                                </li>
                            </ul>
                        </div>                        
                    </div>
                    <div class="clearfix"></div> 
                    <div class="row"> 
                        <div class="col-md-6"> 
                            <h4 class="park-inner-heading">USPs of the Project</h4>
                            <p class="font-12px">The project features are as follows:</p>
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 274.4 acres will be developed with industrial units and 84.93 acres is for  residential units and infrastructure development</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> GAIL has setup a petro-Chemical complex at Auraiya with expected production of 1,00,000 TPA of HDPE and 1,60,000 TPA of LDP</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 7 acres reserved for specialized facilities of which 5 acres earmarked CIPET, free of cost</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 1.5 acres earmarked, free of cost, for Skill development center by GAIL to meet the demand for skilled personnel in plastic industry</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Eastern Dedicated Freight Corridor (EDFC) will be passing through Auraiya, providing the much-needed rail connectivity to the plastic city</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Land and infrastructure for warehouse and container depot</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> NTPC has a Power Plant in Auraiya</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Existing Petrochemical plant of GAIL</p>
                                </li>                                
                            </ul>
                            <h4 class="park-inner-heading">Facilities and infrastructure</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Proximity to NH-2 &  state highway 21 (Approx. 15 kms)</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 8 km from Fafund railway station</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 10 km from GAIL & NTPC limited</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Proximity to CUGL pipeline which can be utilized for setting up captive power plant</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading" style="font-size:13px;background:#e8e8e8;padding:6px 3px;">Details of acquired and developed lands</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Allotted plots (Nos.) : Industrial -108 , Individual housing Plots- 109</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Vacant plots (Nos): Industrial 224, Individual housing plots-513</p>
                                </li>
                            </ul>
                        </div>
                        <div class="col-md-6">
                           <h4 class="park-inner-heading">Dibiyapur Plastic Park, Auraiya on Google Map</h4> 
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d28574.458150907627!2d79.49582617197026!3d26.461940782705028!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x399df3adae51a67b%3A0x8fdd186745eedbe5!2sAuraiya%2C+Uttar+Pradesh+206122!5e0!3m2!1sen!2sin!4v1510463797100" width="100%" height="550" frameborder="0" style="border:0" allowfullscreen></iframe> 
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    
                    <div class="row">                        
                        <div class="col-md-12">
                         <h4 class="park-inner-heading">Investment Opportunities</h4>
                            <b class="font-12px">Industrial</b>
                            <p class="font-12px">
                                175.02 Acres of land is earmarked for the Industrial sector. A total of 223 plots are available with plot sizes varying from 450 Sq. Mt. to about 36,000 Sq. Mt. Plastic Park provides manufacturing and export opportunity for wide range of products like plastic-moulded extruded goods, polyester films and so on.
                            </p>
                            <b class="font-12px">Residential Units</b>
                            <p class="font-12px">
                                Housing scheme at Plastic City, has 84.93 Acres earmarked for the residential sector, including group housing and individual housing plots. A total of 622 housing plots of sizes 112.5 Sq. Mt. to 300 Sq. Mt. are proposed out of which 480 plots are available. Four plots with a total size of 17.79 acres of land are available for Group Housing. The residential zones will have a number of support factors like retail shops and adequate earmarked green zones.
                            </p>
                            <b class="font-12px">Commercial </b>
                            <p class="font-12px">
                                Plastic City Aims to be a self-sustained city with commercial establishments such as shops, hostel, petrol pumps, restaurants, auto showrooms, hotels, warehousing space and other facilities.
                            </p>
                            <b class="font-12px">Institutions </b>
                            <p class="font-12px">
                                As an integrated township, the focus is on encouraging various institutions such as schools, colleges, & vocational training centres. This will cater to the educational needs of the working population, as well as ensure steady supply of trained manpower to the industry.
                            </p>   
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Dibiyapur Plastic Park, Auraiya Layout</h4> 
                            <img src="images/plasticparklayout.jpg" class="img-responsive" alt="Plastic City, Auraiya"/>
                        </div>                        
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">                          
                        <div class="col-md-12">
                            <h4 class="park-inner-heading">Location Advantage</h4> 
                            <ul class="list-unstyled park-inner-ul">
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Auraiya town is situated on NH2 (between Etawah and Kanpur)</p> 
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> Auraiya is located on the Howrah-Delhi route (Phaphund Rly. Stn.)</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 120 Kms from Kanpur</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 181 Kms from Lucknow</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 370 Kms from Delhi</p>
                                </li>
                                <li>
                                    <p class="text-justify font-12px"><i class="fa fa-angle-right" aria-hidden="true"></i> 1000 Kms from Kolkata</p>
                                </li>
                            </ul>
                            <h4 class="park-inner-heading">Details of allotted and vacant plots</h4> 
                            
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
                            <p class="font-12px">2. <span class="font-bold">Shri Girish Kumar Shakya</span><br />Regional Office, Jhansi<br />Admn. Building, Growth center Bijuali, Jhansi<br />Phone: 9719468346<br />Email: rmjhansi[at]upsidc[dot]com</p>   
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
