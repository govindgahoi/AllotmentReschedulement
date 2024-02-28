<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewLAW.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewLAW" %>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
       

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

                    
	                <img src = "/images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><span style="float:right;text-align:right;"><b>Application ID :</b> <asp:Label ID="lblApplicantId" runat="server">12345678</asp:Label><br /><b>Date :</b> <asp:Label ID="lblDate" runat="server">12.01.2018</asp:Label></span><br/>
	                <strong>U.P. STATE INDUSTRIAL DEVELOPMENT AUTHORITY, KANPUR<br>
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
                        <div style="text-align:center;font-size: 18px;font-weight: 600;">Application Under Warehousing &amp; Logistics Policy </div><br />
                        <div style="clear:both;"></div>
                            <div style="width:75%;float:left;font-weight:600;" class="col-md-9">
                                To,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;The Chief Executive Officer,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;U.P. State Industrial Development Authority.<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;A/14, Lakhanpur, KANPUR-208024<br /><br />
                                Dear Sir/Madam,<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;I apply for letter of comfort for Warehousing & Logistics Policy . The details are given below.<br />
                            </div>
                            <div style="width:25%;float:left;" class="col-md-3">
                                                          
                            </div>

                          <div style="clear:both;"></div>  
                        
                                <div class="applicant-detail" style="border: 2px solid #ccc;margin-top: 20px;">
                             
                                
                                <div style="clear:both;"></div>
                                                              
                               <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Particulars of Applicant</b></div><br />
                                <div style="clear:both;"></div> 
                                <div class="col-md-8">
                                <label style="width:35%;float:left;" class="col-md-4">Applying as SPV :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-8"><asp:label ID="lblSPV" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-4">Constitution of Firm/Company :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-8"><asp:label ID="lbl_Firm" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-9"> Firm/Company :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lbl_CompanyName" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-9"> Firm/Company Address :</label>
                                <div style="width:60%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblFirmAddress" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />

                                <div style="clear:both;"></div>
                                <label style="width:35%;float:left;" class="col-md-6">Authorised Person :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-6"><asp:label ID="lbl_AuthorisedName" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-6">Applicant Aadhar :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-6"><asp:label ID="lblApplicantaadhar" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Pan No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblPan" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">CIN No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblCin" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">UDYAM/IEM/DIC Certificate No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblUdyogAadhar" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">GSTIN No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblGSTNo" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Phone No :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblPhoneNo" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Email Id :</label>                      
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblEmailID" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Address :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblAddress" runat="server"></asp:label></div>
                                <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                <label style="width:35%;float:left;" class="col-md-3">Project Location :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="lblProjectLocation" runat="server"></asp:label></div>                                     
                              
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                              
                                <label style="width:35%;float:left;" class="col-md-3">Application ID :</label>
                                <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-9"><asp:label ID="provLbl" runat="server"></asp:label></div>                                     
                              
                                <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div class="col-md-12"><b><asp:Label runat="server" ID="Label17"></asp:Label></b></div>
                                </div>
                                <div class="col-md-4 text-center">  <img src = "" runat="server" id="ImageSrc" style="max-height:150px;max-width:160px;" />    </div>
                                      <div style="clear:both;"></div>
                                <div class="col-md-12"><b><asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                                        <div style="clear:both;"></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:PlaceHolder runat="server" ID="PHH2"></asp:PlaceHolder>                                                                  
                                </div>                                                     
                        <div style="clear:both;"></div>
                        </div>
                        <div style="clear:both;"></div>  
                         <div style="clear:both;"></div>
                        <div class="project-detail" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Project Details</b></div><br />
                                    <div style="clear:both;"></div>
                           
                                    <label style="width:65%;float:left;" class="col-md-3">Type Of Project :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTypeProject" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Category Of Project :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblCategoryProject" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Proposed date for setting up logistic unit :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblDateofSettingUnit" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">The date when capital investment has been started, or is proposed to be started :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblDateCapitalInvestment" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Proposed Investment (In Cr) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblProposedInvestment" runat="server"></asp:label></div>
                                     <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="display:none;">
                                    <label style="width:65%;float:left;" class="col-md-3">Registration/Permit for setting Logistic and Warehousing Unit :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblLAWRegistrationNo" runat="server"></asp:label></div>
                                   
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" /></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Proposed Land Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Total Land (In SqrFt) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblTotalArea" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Covered Area  (In SqrFt) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="lblCoveredArea" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Investment Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Cost of the Land(In Cr) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblCostofland" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Cost of Infrastructures(In Cr) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblCostofinfrastructure" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3"> Cost of the Plant & Machinery(In Cr) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblcostofPlantMachinery" runat="server"></asp:label></div>
                                    <label style="width:35%;float:left;" class="col-md-3">Other Cost(In Cr) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblothercost" runat="server"></asp:label></div>
                                    
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3"> Building Cost (In Cr): :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblBuildingCost" runat="server"></asp:label></div>
                                    <%--<label style="width:35%;float:left;" class="col-md-3">Other Cost(In Cr) :</label>
                                    <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="Label2" runat="server"></asp:label></div>--%>
                                    
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Requested benefits by Applicant</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:65%;float:left;" class="col-md-3">Total Amount as requested by Applicant (In Cr) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblTotalAmountRequested" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div class="col-md-12 col-sm-12 col-xs-12"><b>Applicant Benefit Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <label style="width:65%;float:left;" class="col-md-3">Rebate on Stamp Duty (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblRebateOnStamp" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">EPF Reimbursement (More than 100 unskilled workers) (In Cr) (For 2018) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblEPFReimbursement" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">10% Additional EPF Reimbursement (200 skilled and unskilled workers) (In Cr)(For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblAdditionalEPFReimbursement" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Capital Interest Subsidy (In Cr) (For 2018) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblCapitalInterestSubsidy" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Infrastructure Interest Subsidy (In Cr) (For 2018) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblInfrastructureInterestSubsidy" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Rebate on Land use conversion charges (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblRebateLandUseConversion" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <label style="width:65%;float:left;" class="col-md-3">Exemption from development charges (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblExemptionDevelopmentCharges" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Electricity Rebate (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblElectricityRebate" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Warehousing quality certification reimbursement (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblWarehousingCertification" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">500/- per month assistance for payroll of disabled workers (In Cr) (For 2018) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblAssistanceForPayroll" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Skill development promotion (In Cr) (For 2018 or 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblSkillDevelopmentPromotion" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Intelligent Logistic Incentives (In Cr) (For 2018) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblIntelligentLogisticIncentives" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:65%;float:left;" class="col-md-3">Capital Subsidy (In Cr)(For 2022) :</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3">&#x20B9;<asp:label ID="lblCapitalSubsidy" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <div style="clear:both;"></div>

                        </div>
                       
                        <div style="clear:both;"></div>
                        <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>C. Documents Uploaded</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PH2"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        <div style="clear:both;"></div>
                        <div class="Land-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Land Breakup Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PH3"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        <div style="clear:both;"></div>
                        <div runat="server" id="ObjectionDiv" visible="false">
                        <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Documents Uploaded</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         <asp:PlaceHolder runat="server" ID="PHObjection"></asp:PlaceHolder> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div></div>
                        <div style="clear:both;"></div>
                          
                          <div class="payment" style="border: 2px solid #ccc;margin-top: 20px;">
                                    
                                    <div style="clear:both;"></div>
                                    <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                     </div>
                               <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                         <img src = "" runat="server" id="Img2" style="max-height:150px;max-width:195px;" />  <br /><br /><p>Applicant Signature</p> 
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
              </div>
                

                    <div class="div-report" runat="server"  style="text-align: center;">
                    <br />
                    <div style = "border-top:3px solid #ffc511;">&nbsp;</div> 	
                    <div class="mail-disclaimer">
	                <p class="text-justify"><strong>Disclaimer:</strong>The information given in the above applicationis true to the best of my knowledge and belief. I further agree to abide by any and all changes made in the general conditions by the corporation from time to time.</p>
                    </div>
                </div>
                <div class="clearfix" style="clear:both;"></div>
            </div>

        
</div>
