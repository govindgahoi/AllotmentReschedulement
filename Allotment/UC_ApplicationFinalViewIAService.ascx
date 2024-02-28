<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewIAService.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewIAService" %>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
        @media only screen and (max-width:992px) {
            .form-group label.text-right {
                text-align: left !important;
            }
        }

body, h1, h2, h3, h4, h5, h6, p, a, .h1, .h2, .h3, .h4, .h5, .h6 {
    font-family: Segoe UI, Helvetica, Calibri;
}

.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
    </style>
<link type="text/css" rel="stylesheet" href="css/theme.css" />
<div class="col-md-12 col-sm-12 col-xs-12">              <div>
                        <ul class="pull-right list-inline">
                    <li>
                        <a runat="server" onclick="PrintElemF()" style="cursor:pointer;">
                            <i style="font-size: 18px;" class="fa fa-print" aria-hidden="true"></i>
                        </a>
                    </li>
                    
                </ul>
                        </div>
            <div  id="DivP" style="padding: 15px 25px; margin: 25px;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><br/>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT CORPORATION LIMITED, KANPUR<br>
	                (Head Office: A-1/4, LAKHANPUR, POSTBOX NO. 1050, KANPUR 208024)</strong><br /><br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 
                </div>
                <style>
                    .my-div-report label {
                        font-weight:600;
                    }
                    .my-div-report .col-md-3{
                        margin:0px 0;
                    }
                    .my-div-report .col-md-9{
                        margin:0px 0;
                    }
                    .my-div-report .col-md-12 {
                        margin-top:15px;
                    }
                    .main-head {
                            background: #8a8a8a;
                            color: #fff;
                            margin-top: 0 !important;
                            border-bottom: 1px solid #ccc;
                            padding: 4px 15px;
                    }
                </style>

            
                    <div class="my-div-report">
                        <div style="text-align:center;font-size: 18px;font-weight: 600;"><asp:Label runat="server" ID="lblFormName"></asp:Label></div><br />
                        <div style="clear:both;"></div>
                            <div style="width:75%;float:left;font-weight:600;" class="col-md-9">
                                To,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;The Regional Manager,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblOfficeName"></asp:Label><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAddressOffice"></asp:Label><br /><br />
                                Dear Sir/Madam,<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;I Hereby submit the request for <asp:Label runat="server" ID="lblServiceName"></asp:Label> as per the following details.<br />
                            </div>
                            <div style="width:25%;float:left;" class="col-md-3">
                                <%--<asp:Image runat="server" ID="Image1" style="max-height:190px;"/>--%>
                                 <img src = "" runat="server" id="ImageSrc" style="max-height:150px;max-width:195px;" />
                                
                            </div>

                        <div style="clear:both;"></div>
                      <!--<asp:PlaceHolder ID="ph" runat="server" />-->
                        <div class="applicant-detail" style="border: 2px solid #ccc;margin-top: 20px;">
                                <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Applicant Details</b></div><br />
                                <div style="clear:both;"></div>
             
                      
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Particulars of the Applicant</b></div><br />
                                <div style="clear:both;"></div> 
                                <label style="width:35%;float:left;" class="col-md-4">Constitution of Firm/Company :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-8"><asp:label ID="lblFirmConstitution" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-9"> Name of the Firm/Company :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblCompanyName" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div style="width:75%;float:left;display:none;" class="col-md-9"><b>Whether Application is for 100% export oriented unit?</b></div>
                                <div style="width:25%;float:left;display:none;" class="col-md-3"><asp:label ID="lblexportoriented" runat="server"></asp:label></div>
                                
                                <div class="col-md-12" style="display:none;"><b>B. Particulars of the Applicant</b></div>
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">Authorised Person :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblName" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Pan No :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPanNo" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">CIN No :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblCINNo" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />             
                                <label style="width:35%;float:left;" class="col-md-3">Phone :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTelephone" runat="server"></asp:label></div>
                                <label style="width:25%;float:left;" class="col-md-3">Email Id :</label>
                                <div style="width:25%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblEmailInd" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Address :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblAddress" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Plot No :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPlotNo" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Plot Size :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPlotSize" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Application Ref No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblServiceReqno" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                               <label style="width:35%;float:left;" class="col-md-3">Application Date :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblApplicationDate" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                               <label style="width:35%;float:left;" class="col-md-3">Application Re-submission Date :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblApplicationReDate" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                            <div class="col-md-12"><b><asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:PlaceHolder runat="server" ID="PH1"></asp:PlaceHolder>                                                                  
                                </div>                                                     
                        <div style="clear:both;"></div>
                        </div>
                        <div style="clear:both;"></div>
                        <div class="project-detail" runat="server" id="COPDetails" visible="false" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Project Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Type of industry :</label>
                                    <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTypeOfIndustryy" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3">Proposed Product :</label>
                                    <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblIndustrytype" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Project Costing Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Estimated Cost of the project(In Lacs) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblTotalProjectCost" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Estimated Employment Generation(In Nos)</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblEstimatedEmployment" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3">Estimated Project Start Period(In Months) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTimelimitSetup" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Related Work Experience(In Months) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblRelevantExperience" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="width:75%;float:left;display:none;" class="col-md-9"><b>Whether the networth/turnover of previous year is more than 10 crores?</b></div>
                                    <div style="width:25%;float:left;display:none;" class="col-md-3"><asp:label ID="lblNetworth" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <div style="width:75%;float:left;display:none;" class="col-md-9"><b></b></div>
                                    <div style="width:25%;float:left;display:none;" class="col-md-3"></div>
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Layout plan of land</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Covered area(In %) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblCoveredarea" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Open area(In %) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblOpenArea" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Details of the investment(in Rs)</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Investment In Land (In Lacs) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblLandCost" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Investment In Building (In Lacs) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblBuildingCost" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3">Investment In Machine & Equipments(In Lacs)</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblPlantMachineryCost" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Investment In Other Fixed Assets (In Lacs) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblInvestmentOtherAssets" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3">Investment In Other Expenses (In Lacs) :</label>
                                    <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblInvestmentOtherExpenses" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:80%;float:left;" class="col-md-9"><b>Will any fumes be generated in the process of manufacture and if so, their nature and quantity?</b></label>
                                    <div style="width:20%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblFumesGenerated" runat="server"></asp:label></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>
                                    <div runat="server" id="DivFume" visible="false">
                                    <label style="width:35%;float:left;" class="col-md-3">Fume Quantity :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblFumeQty" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Fume Nature :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblFumeNature" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-9"><b>Industrial Category</b></label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblIndustrialCategory" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>       
                                    <hr class="myhrline" />
                                  <div id="DivPollution" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <b>Industrial Effluents :</b> 
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <table class="table table-hover table-bordered request-table" style="width:100%;">
                                            <tr>
                                                <th>Name</th>
                                                <th>Quantity</th>
                                                <th>Chemical composition</th>
                                            </tr>
                                            <tr>
                                                <td>(i)Liquid</td>
                                                <td><asp:label ID="lblLiquidQuantity" runat="server"></asp:label></td>
                                                <td><asp:label ID="lblLiquidComposition" runat="server"></asp:label></td>
                                            </tr>
                                            <tr>
                                                <td>(ii)Solid</td>
                                                <td><asp:label ID="lblSolidQuantity" runat="server"></asp:label></td>
                                                <td><asp:label ID="lblSolidComposition" runat="server"></asp:label></td>
                                            </tr>
                                            <tr>
                                                <td>(iii)Gaseous</td>
                                                <td><asp:label ID="lblGasQuantity" runat="server"></asp:label></td>
                                                <td><asp:label ID="lblGasComposition" runat="server"></asp:label></td>
                                            </tr>
                                        </table>
                                </div>
                                <div style="clear:both;"></div>
                                     <label style="width:35%;float:left;" class="col-md-3">Is ETP Required:</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblEtp"  runat="server"></asp:label></div> 
                                          <div style="clear:both;"></div>
                                <hr class="myhrline" />
                               <div runat="server" id="MeasureDiv" visible="false">
                                      <label style="width:75%;float:left;" class="col-md-12">Proposed effluent treatment measures :</label>
                                <div style="width:25%;float:left;" class="col-md-3"></div>
                                <div style="clear:both;"></div>
                                <div style="width:25%;float:left;font-size:12px;font-weight:600;" class="col-md-3">1. <asp:label ID="lblProposedEffluents1" runat="server"></asp:label></div>
                                <div style="width:25%;float:left;font-size:12px;font-weight:600;" class="col-md-3">2. <asp:label ID="lblProposedEffluents2" runat="server"></asp:label></div>
                                <div style="width:25%;float:left;font-size:12px;font-weight:600;" class="col-md-3">3. <asp:label ID="lblProposedEffluents3" runat="server"></asp:label></div>
                      </div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" /></div>
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Power Requirement (in KW)</b></div><br />
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">In KW :</label>
                                <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPowerrequirement" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div style="display:none;">
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Telephone Requirement</b></div><br />
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">First Year :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTelephoneFirstYear" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Second Year :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTelephoneSecondYear" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" /></div>
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Other Relevant Information</b></div><br />
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">Net Worth(In Lac) :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblNetWorthTurnover" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Is Project Require Expansion :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPlotRequiredExpansion" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Net Turnover(In Lac) :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblTurnOver" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                           
                                <label style="width:60%;float:left;" class="col-md-3">Whether The Company Is 100% Export Oriented Industry :</label>
                                <div style="width:40%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblExportOrientedIndustry" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:60%;float:left;" class="col-md-3">Applicant Priority Category Specification :</label>
                                <div style="width:40%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblpriorityCategory" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>

                        </div>


                         <div class="project-detail" runat="server" id="AOPDetails" visible="false" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B.Additional Product Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Product Name :</label>
                                    <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblProductName" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Product Description :</label>
                                    <div style="width:45%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblProductDescription" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                   

                        </div>

                         <div class="project-detail" runat="server" id="Div_PostAmalgamation" visible="false" style="border: 2px solid #ccc;margin-top: 20px;">
                             <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B.Plot Amalgamation Details</b></div><br />
                                    <div style="clear:both;"></div>
                            <div class="form-group" style="padding: 7px 0; background: #ececec;">
                                                                        <div class="col-md-12 col-xs-12 col-sm-12">
                                                                            Total Area : <asp:Label ID="lblTotalArea" runat="server"></asp:Label>&nbsp;SqrMts
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                 
                                                                        <div class="table-responsive" style="max-height: 117px;overflow-y:auto;">
                                                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                                                                                CssClass="table table-striped table-bordered table-hover request-table"  EmptyDataText="No Plot Available">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                            </asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="PlotNumber" HeaderText="Selected Plot" SortExpression="PlotNumber" />
                                                                                     <asp:BoundField DataField="PlotArea" HeaderText="Plot Area" SortExpression="PlotArea" />
                                                                                   
                                                                                    <asp:BoundField DataField="North" HeaderText="North" SortExpression="FRONTSIDE" />
                                                                                     <asp:BoundField DataField="South" HeaderText="South" SortExpression="FRONTSIDE" />
                                                                                     <asp:BoundField DataField="East" HeaderText="East" SortExpression="SIDE1" />
                                                                                     <asp:BoundField DataField="West" HeaderText="West" SortExpression="SIDE2" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                        <hr class="myhrline" />
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            Amalgamated Plots : <asp:Label ID="lblAmalgamatedPlots" runat="server"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                                                            Amalgamated Area : <asp:Label ID="lblAmalgamatedArea" runat="server"></asp:Label>&nbsp;SqrMts
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                           
                                                                    </div>
                        
                        </div>

                        <div class="project-detail" runat="server" id="Div_SubdivisionDetails" visible="false" style="border: 2px solid #ccc;margin-top: 20px;">
                             <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B.Plot Subdivision Details</b></div><br />
                                    <div style="clear:both;"></div>
                            <div class="form-group" style="padding: 7px 0; background: #ececec;">
                                                                       
                                                                 
                                                                        <div class="table-responsive" style="max-height: 117px;overflow-y:auto;">
                                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                                                CssClass="table table-striped table-bordered table-hover request-table"  EmptyDataText="No Plot Available">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblApplication" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"> 
                                                                                            </asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                   
                                                                                    <asp:BoundField DataField="Plot_name" HeaderText="Name of Proposed Plot" SortExpression="PlotName" />
                                                                                     <asp:BoundField DataField="Plot_Area" HeaderText="Area of Sub-divided Plot (sqm)" SortExpression="PlotSize" />
                                                                                    <asp:BoundField DataField="Sal_mort" HeaderText="Saleable/ To be Mortgaged" SortExpression="PlotSize" />

                                                                                     
                                                                  
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                 
                                                                           
                                                                    </div>
                        
                        </div>

                               <div class="project-detail" runat="server" id="BPSpecification_Div" visible="false" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Specification Of Constructed Building For Which Completion Certificate Is Requested</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="panel-body ">

     

                <div class="table-responsive">
                    <table class="table table-bordered table-hover request-table" id="datatableService">
                        <thead>
                            <tr>
                                <th style="width: 250px">Description</th>
                                <th style="width:50px;">Byelaws </th>
                                <th>Unit</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><span style="color: Red">* </span>FAR(in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblFarByelaws" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtFar" CssClass="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Ground Coverage (in Percentage)</td>
                                <td>
                                    <asp:Label ID="lblGroundBylo" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtGroundcover" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Total Covered Area (in SqrMts)</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtCoveredAreaA" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><span style="color: Red">* </span>Height(In mts)</td>
                                <td>
                                    <asp:Label ID="lblHeight" runat="server" Text="N/A"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtHeight" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;"><span style="color: Red">* </span>Set Back(In mts)</td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>front</td>
                                <td>
                                    <asp:Label ID="lblSetBackFront" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtSetBackFront" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Rear
                                </td>
                                <td>
                                    <asp:Label ID="lblSetBackRear" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtSetBackRear" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Side1</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide1" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtSetBackSide1" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;"><span style="color: Red">* </span>Side2</td>
                                <td>
                                    <asp:Label ID="lblSetBackSide2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtSetBackSide2" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:left;"><span style="color: Red">* </span>Classification of Indiustries Based on Degree of Hazard</td>
                            </tr>
                            <tr>
                                <td>Classification of Hazard</td>
                                <td colspan="2">

                                    <asp:Label ID="ddlNature" runat="server" >
                                        
                                    </asp:Label>

                                </td>
                            </tr>


                            <tr>
                                <td><span style="color: Red">* </span>Occupancy</td>
                                <td colspan="2">


                                    <asp:Label ID="txtOccupancy" CssClass="input-sm myyellowbgsmall" runat="server"></asp:Label>


                                </td>
                            </tr>


                        </tbody>
                    </table>



                    <table class="table table-bordered table-hover request-table" >
                            <thead>
                                <tr>
                                    <th style="width:250px">Floors</th>
                                    <th>Constructed </th>
                                    <th style="display:none;">Proposed</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>BaseMent(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtBaseMent1"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display:none;">
                                        <asp:Label ID="txtBaseMent2"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ground Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtGround1"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display:none;">
                                        <asp:Label ID="txtGround2"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>First Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtFirstfloor1" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display:none;">
                                        <asp:Label ID="txtFirstfloor2"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td >Second Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtSecondFloor1"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display:none;">
                                        <asp:Label ID="txtSecondFloor2"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>                      
                                <tr>
                                    <td style="text-align:left;">Mezzanine Floor(in Sqmts)</td>
                                    <td>
                                        <asp:Label ID="txtMezzanine1"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                    <td style="display:none;">
                                        <asp:Label ID="txtMezzanine2"  class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Stilt Floor(in Sqmts)</td>
                                    
                                    <td colspan="2">
                                        <asp:Label ID="txtStealth" class="input-sm myyellowbgsmall" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Mumti(in Sqmts)</td>
                                    
                                    <td colspan="2">
                                        <asp:Label ID="txtMumti"  class="input-sm myyellowbgsmall" runat="server" ssss></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="table table-bordered table-hover request-table" id="datatableService2" >
                            <thead>
                                <tr>
                                    <th style="width:250px"></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="text-align:right;">Purpose for which  building Use
                                    </td>
                                    <td>
                                        <asp:Label ID="txtbuildingPurpose" class="input-sm myyellowbgsmall" runat="server" Text=''></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;" colspan="2"><b>Construction Specification</b></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Foundation</td>
                                    <td>
                                        <asp:Label ID="txtFoundation" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Walls</td>
                                    <td>
                                        <asp:Label ID="txtWalls" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="text-align:right;">Floors</td>
                                    <td>
                                        <asp:Label ID="txtFloors"  class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Roofs</td>
                                    <td>
                                        <asp:Label ID="txtRoofs" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of storeys</td>
                                    <td>
                                        <asp:Label ID="txtStories" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Number of latrines</td>
                                    <td>
                                        <asp:Label ID="txtLatrines"  class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">Any Previous Construction </td>
                                    <td>
                                        <asp:Label ID="txtPreviousConstruction" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right;">Source of Water for Building Purpose </td>
                                    <td>
                                        <asp:Label ID="txtWaterSource" class="input-sm myyellowbgsmall" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                        
                            <div class="clearfix"></div>
                            <hr class="myhrline" />

                </div>



            </div>
                                   

                        </div>
                        
                        <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;" runat="server" id="Doc_Div">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>C. Documents Upload</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PH2"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        <div class="payment" style="border: 2px solid #ccc;margin-top: 20px;"  runat="server" id="Payment_Div">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Payment</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                         <asp:PlaceHolder runat="server" ID="PH3"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                            <div class="Dues-details" runat="server" id="Dues_Div" style="border: 2px solid #ccc;margin-top: 20px;" visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>E. Dues Cleared</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PH_Dues"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                          <div class="Dues-details" runat="server" id="Objection_Div" style="border: 2px solid #ccc;margin-top: 20px;" visible="false">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>F. Objection Cleared</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="ph_Objection"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
              </div>


                    <div class="div-report" runat="server"  style="text-align: center;">
                    <br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information given in the above applicationis true to the best of my knowledge and belief. The general conditions for allotment of plot/shed and grant of lease indicated in this application form for allotment of plot/shed in the industrial area has been read carefully and understood by me and are fully acceptable to me. I further agree to abide by any and all changes made in the general conditions by the corporation from time to time.</p>
                    </div>
                </div>
                <div class="clearfix" style="clear:both;"></div>
            </div>

        <asp:Label ID="lblIAName" runat="server" Visible="false"></asp:Label>
</div>
