<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalView.ascx.cs" Inherits="Allotment.UC_ApplicationFinalView" %>
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
<div class="col-md-12 col-sm-12 col-xs-12">
            <div  id="DivP" style="padding: 15px 25px; margin: 25px;background: #fbfbfb;border: 1px solid #ccc;">
                <div class="div-report" runat="server"  style="text-align: center;">

                    
	                <img src = "/images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><span style="float:right;text-align:right;"><b>Form No :</b> <asp:Label ID="lblApplicantId" runat="server">12345678</asp:Label><br /><b>Date :</b> <asp:Label ID="lblDate" runat="server">12.01.2018</asp:Label></span><br/>
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
                        <div style="text-align:center;font-size: 18px;font-weight: 600;">Application Form For Allotment of Industrial Plot/Shed</div><br />
                        <div style="clear:both;"></div>
                            <div style="width:75%;float:left;font-weight:600;" class="col-md-9">
                                To,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;The Managing Director,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;U.P. State Industrial Development Corporation Ltd.<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;A/14, Lakhanpur, KANPUR-208024<br /><br />
                                Dear Sir/Madam,<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;I apply for plot/shed in industrial area/estate of the corporation. The details are given below.<br />
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
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Particulars of the plot required</b></div><br />
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">District :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblDistrict" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Industrial Area :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblIA" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Plot Range(In Sqmt) :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPlotRange" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Plot Area(In Sqmt) :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPlotArea" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Preferred Plot :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPreferredPlot" runat="server"></asp:label></div>                                
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div style="clear:both;"></div>
                                
                                <div style="width:35%;float:left;font-size:12px" class="col-md-3">Plot Preference :</div>
                                <div style="width:15%;float:left;font-weight:700;font-size:12px" class="col-md-3">1.&nbsp;<asp:label ID="lblPlotpreference1" runat="server"></asp:label></div>
                                
                                <div style="width:25%;float:left;font-weight:700;font-size:12px" class="col-md-3">2.&nbsp;<asp:label ID="lblPlotpreference2" runat="server"></asp:label></div>
                              
                                <div style="width:25%;float:left;font-weight:700;font-size:12px" class="col-md-3">3.&nbsp;<asp:label ID="lblPlotpreference3" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div style="width:75%;float:left;display:none;" class="col-md-9"><b>Whether Application is for expansion of existing unit in same industrial area?</b></div>
                                <div style="width:25%;float:left;display:none;" class="col-md-3"><asp:label ID="lblExpansion" runat="server"></asp:label></div>
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
                                <label style="width:35%;float:left;" class="col-md-3">Provisional ID :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="provLbl" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Permanent ID :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="PermLbl" runat="server"></asp:label></div>
                                   
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div class="col-md-12"><b><asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:PlaceHolder runat="server" ID="PH1"></asp:PlaceHolder>                                                                  
                                </div>                                                     
                        <div style="clear:both;"></div>
                        </div>
                        <div style="clear:both;"></div>
                        <div class="project-detail" style="border: 2px solid #ccc;margin-top: 20px;">
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
                                <div id="ExistingUnit" runat="server" visible="false">
                                <div class="col-md-12 col-sm-12 col-xs-12"><b>Existing Unit Details</b></div><br />
                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-3">IA Name :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblIAname" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Existing Plot No</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblExisPlotNo" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Allotment Date :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblAllotmentDate" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Allotment No</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblAllotmentNo" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Allottee Name :</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblAllotteeName" runat="server"></asp:label></div>
                                <label style="width:35%;float:left;" class="col-md-3">Product Manufactured</label>
                                <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblProductManufatured" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" /></div>
                                <label style="width:60%;float:left;" class="col-md-3">Whether The Company Is 100% Export Oriented Industry :</label>
                                <div style="width:40%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblExportOrientedIndustry" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:60%;float:left;" class="col-md-3">Applicant Priority Category Specification :</label>
                                <div style="width:40%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblpriorityCategory" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>

                        </div>
                        <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>C. Payee Account Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <label style="width:35%;float:left;" class="col-md-3">Payee Name</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblPayeeName" runat="server"></asp:label></div>
                                        <label style="width:35%;float:left;" class="col-md-3">Bank Name</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblBankName" runat="server"></asp:label></div>
                                        <div style="clear:both;"></div>
                                        <hr class="myhrline" />
                                        <label style="width:35%;float:left;" class="col-md-3">Account No</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblAcctNo" runat="server"></asp:label></div>
                                        <label style="width:35%;float:left;" class="col-md-3">IFSC Code</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblIFSCCode" runat="server"></asp:label></div>
                                        <div style="clear:both;"></div>
                                        <hr class="myhrline" />
                                        <label style="width:35%;float:left;" class="col-md-3">Branch Name</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblBranchName" runat="server"></asp:label></div>
                                        <label style="width:35%;float:left;" class="col-md-3">Branch Address</label>
                                        <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblBranchAddress" runat="server"></asp:label></div>
                                        <div style="clear:both;"></div>
                                        <hr class="myhrline" />
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Documents Upload</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PH2"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        <div class="payment" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>E. Payment</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                         <asp:PlaceHolder runat="server" ID="PH3"></asp:PlaceHolder> 
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

        
</div>
