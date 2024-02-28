<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ApplicationFinalViewPIP_AFA.ascx.cs" Inherits="Allotment.UC_ApplicationFinalViewPIP_AFA" %>
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

                    
	                <img src = "/images/upsidclogo.png" class="header-logo" style="border-top:none;height: 40px;margin-bottom:0;" /><span style="float:right;text-align:right;"><b>Application ID :</b> <asp:Label ID="lblApplicantId" runat="server">12345678</asp:Label><br /><b>Date :</b> <asp:Label ID="lblDate" runat="server"></asp:Label></span><br/>
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
            <div style="text-align: center; font-size: 18px; font-weight: 600;">Application for Issuance of Unique Id for Private Industrial Parks </div>
            <br />
            <div style="clear: both;"></div>
            <div style="width: 100%; float: left; font-weight: 600;" class="col-md-12">
                To,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;The Chief Executive Officer,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;U.P. State Industrial Development Authority.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;A/14, Lakhanpur, KANPUR-208024<br />
                <br />
                Dear Sir/Madam,<br />
                &nbsp;&nbsp;&nbsp;&nbsp;I apply for letter of comfort for Issuance of Unique Id for Private Industrial Parks . The details are given below.<br />
            </div>


            <div style="clear: both;"></div>

            <div class="applicant-detail" style="border: 2px solid #ccc; margin-top: 20px;">

               
                <div style="clear: both;"></div>
                     <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Particulars of Applicant</b></div><br />
              <%--  <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>A. Applicant Detail</b></div>--%>
               
                <div style="width: 70%; float:left;">
                     <div class="col-md-12 col-sm-12 col-xs-12"><b>Authorized Signatory Details</b></div>
              
                    <label style="width: 35%; float:left;" class="col-md-2">Name :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Name" runat="server"></asp:Label>

                    </div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-2">Email :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Email" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-9">Designation :</label>
                    <div style="width: 60%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Designation" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-9">Mobile No :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="MobileNo" runat="server"></asp:Label></div>
                      <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-6">PAN :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="PAN" runat="server"></asp:Label></div>
                     <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Address :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Address" runat="server"></asp:Label></div>
                                 </div>
              
                       <div style="width: 30%; float:left;">
                    <img src="" runat="server" id="ImageSrc" style="max-height: 150px; max-width: 160px;" />
                </div>
                     
                <div style="clear: both;"></div>
                    <hr class="myhrline" />
                       <div class="col-md-12 col-sm-12 col-xs-12"><b>Developer/ Promoter/ SPV Details </b></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Name :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="dpsvName" runat="server"></asp:Label></div>


                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-6">Email :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="dpsvEmail" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">SPV :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="SPV" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Person Contact No :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="PersonContactNo" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Website :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Website" runat="server"></asp:Label></div>

                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Address  :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="Address2" runat="server"></asp:Label></div>

                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Constitution of the Firm :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="ConstitutionoftheFirm" runat="server"></asp:Label></div>

                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                             <div class="col-md-12 col-sm-12 col-xs-12"><b>Beneficiary Bank Details for Disbursal of Incentives</b></div>

                              <div style="clear: both;"></div>
                    <hr class="myhrline" />

                    <label style="width: 35%; float: left;" class="col-md-3">Beneficiary Name :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="BeneficiaryName" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Bank Account No :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="BankAccountNo" runat="server"></asp:Label></div>

                             <div style="clear: both;"></div>
                    <hr class="myhrline" />

               <%--     <div class="col-md-12"><b>
                        <asp:Label runat="server" ID="Label1"></asp:Label></b></div>
                    <div style="clear: both;"></div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                    </div>--%>




                    <label style="width: 35%; float: left;" class="col-md-3">Type of Account :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="TypeofAccount" runat="server"></asp:Label></div>


                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width:35%; float:left;" class="col-md-3">Name of Bank :</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="NameofBank" runat="server"></asp:Label></div>

                    <div style="clear: both;"></div>
                    <hr class="myhrline" />
                    <label style="width: 35%; float: left;" class="col-md-3">Branch Address:</label>
                    <div style="width: 65%; float: left; font-size: 12px; font-weight: 700;" class="col-md-8">
                        <asp:Label ID="BranchAddress" runat="server"></asp:Label></div>

                         <div style="clear:both;"></div>
                                <hr class="myhrline" />
                                <div class="col-md-12"><b><asp:Label runat="server" ID="Headerlbl"></asp:Label></b></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:PlaceHolder runat="server" ID="PH1"></asp:PlaceHolder>                                                                  
                                </div>    

       
        
            
                



                  <div style="clear:both;"></div>
              

               
                <div class="Applicant Project Details">

                         <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>B. Project Details</b></div>

                       <div style="clear:both;"></div>
                                 
                                    <label style="width:35%;float:left;" class="col-md-3">Name of Industrial Park   :</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="NameofIndustrialPark" runat="server"></asp:label></div>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:35%;float:left;" class="col-md-3"> Area of Industrial Park (in Acres) :</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="PAAreaofIndustrialParkinAcres" runat="server"></asp:label></div>
                                 
                                         <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                      
                              <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3">FAR</div>
                              <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3"> As Per Guidelines</div>
                            <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3">Utilized</div>
                              <%--   <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                           <div class="col-md-4"><b>FAR</b></div>
                                <div class="col-md-4"><b> As Per Guidelines</b></div>
                                <div class="col-md-4"><b>Utilized</b></div>--%>
                        
                          <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                 <div style="width:33%;float:left;font-size:12px;" class="col-md-3">Idustrial:</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3"> 5</div>
                                <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:Label ID="FarIndustrialAsPerGuidelines" runat="server"></asp:Label></div>
           
                      
                                    <div style="clear:both;"></div>
                          <hr class="myhrline" />
                                 <div style="width:33%;float:left;font-size:12px;" class="col-md-3">Commercial:</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3"> 4</div>
                                <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3"> <asp:Label ID="FarCommercialAsPerGuidelines" runat="server"></asp:Label> </div>
                    
                       
                                    <div style="clear:both;"></div>
                          <hr class="myhrline" />
                                 <div style="width:33%;float:left;font-size:12px;" class="col-md-3">Roads</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3">3</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3" font-weight:700;><asp:Label ID="FarRoadsAsPerGuidelines" runat="server"></asp:Label></div>
                     
                          
                                    <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                 <div style="width:33%;float:left;font-size:12px;" class="col-md-3">Green and Open Spaces:</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3">2</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3" font-weight:700;><asp:Label ID="FarGreenandOpenSpacesAsPerGuidelines" runat="server"></asp:Label></div>
                      
                          
                                    <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                    <div style="width:33%;float:left;font-size:12px;" class="col-md-3">Utilities:</div>
                                <div style="width:33%;float:left;font-size:12px;"class="col-md-3">1</div>
                                <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3"> <asp:Label ID="FarUtilitiesAsPerGuidelines" runat="server"></asp:Label></div>
                          

                          
                                    <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                    <div style="width:33%;float:left;font-size:12px;" class="col-md-3"> Hostel/ Dormitory:</div>
                                <div style="width:33%;float:left;font-size:12px;" class="col-md-3">7</div>
                                <div style="width:33%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:Label ID="FarHostelDormitoryAsPerGuidelines" runat="server" ></asp:Label></div>
                      
                               
              

              
                  
                                    <div style="clear:both;"></div>
                   <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3"> Exemption on Stamp Duty (in Cr):</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="ExemptiononStampDutyinCr" runat="server"></asp:label></div> 
                          
                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3">Capital Subsidy on Eligible Fixed Capital Investment (in Cr) :</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="CapitalSubsidyonEligibleFixedCapitalInvestmentinCr" runat="server"></asp:label></div>

                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3">Capital Subsidy on Cost of Building Hostel/ Dormitory Housing (in Cr):</label>
                                    <div style="width:35%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr" runat="server"></asp:label></div>

                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3">Total Amount of Financial Assistance Sought (in Cr):</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="TotalAmountofFinancialAssistanceSoughtinCr" runat="server"></asp:label></div>

                                    <div style="clear:both;"></div>
                                   <hr class="myhrline" />
                     
                              
                                   
                          <div class="col-md-12 col-sm-12 col-xs-12"><b>Fixed Capital Investment</b></div>
                            
                           
                     <div style="clear:both;"></div>
                            <hr class="myhrline" />
                    
                             
                         <div style="width:10%;float:left;font-size:12px;font-weight:700;" class="col-md-3"> <b>S.No</b></div>          
                     <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"> <b>Infrastructure</b></div>
                             <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><b>Area(in Acres)</b></div>
                          <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><b>Cost(in Cr.)</b></div>
                            
                     <div style="clear:both;"></div>
                            <hr class="myhrline" />
                       
                              
                                 
                                <div style="width:10%;float:left;font-size:12px;" class="col-md-3">1</div>
                              <div style="width:30%;float:left;font-size:12px;"" class="col-md-3">Roads & Streetlighting</div>
                       <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="IRoadsStreetlightingAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="IRoadsStreetlightingCostinCr" runat="server"></asp:label></div>

                   
                     <div style="clear:both;"></div>
                          <hr class="myhrline" />
                          
                              
                                   
                              <div style="width:10%;float:left;font-size:12px;" class="col-md-3">2</div>
                            
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Water</div>
                     <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="IWaterAreainAcres" runat="server"></asp:label></div>
                                <div style="width:30%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="IWaterCostinCr" runat="server"></asp:label></div>

                    
                     <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                              
                                
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">3</div>
                            
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Sewerage & Drainage</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="ISewerageDrainageAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="ISewerageDrainageCostinCr" runat="server"></asp:label></div>

                      
                     <div style="clear:both;"></div>
                          <hr class="myhrline" />
                    
                              
                                   
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">4</div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3">  Power Supply</div>
                        <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IPowerSupplyAreainAcres" runat="server"></asp:label></div>
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IPowerSupplyCostinCr" runat="server"></asp:label></div>

                     <div style="clear:both;"></div>
                     <hr class="myhrline" />

                          
                                 
                              <div style="width:10%;float:left;font-size:12px;" class="col-md-3">5</div>
                           
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"> Warehousing</div>
                     <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IWarehousingAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IWarehousingCostinCr" runat="server"></asp:label></div>

                 
                           <div style="clear:both;"></div>
                     <hr class="myhrline" />

                       
                              
                                  
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">6</div>
                               
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Parking & Trucking Bays</div>
                     <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IParkingTruckingBaysAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="IParkingTruckingBaysCostinCr" runat="server"></asp:label></div>

                 

                      
                                      <div style="clear:both;"></div>
                     <hr class="myhrline" />

                            
                           
                               <div class="col-md-12 col-sm-12 col-xs-12"><b>Common Facilities</b></div>
                               
                     
               
                               <div style="clear:both;"></div>
                     <hr class="myhrline" />

                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">7</div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Weight Bridge</div>
                        <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFWeightBridgeAreainAcres" runat="server"></asp:label></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFWeightBridgeCostinCr" runat="server"></asp:label></div>

              
                          <div style="clear:both;"></div>
                     <hr class="myhrline" />

                    
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">8</div>
                             
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Skill Development Centre</div>
                         <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFSkillDevelopmentCentreAreainAcres" runat="server"></asp:label></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFSkillDevelopmentCentreCostinCr" runat="server"></asp:label></div>

                    
                      
                          <div style="clear:both;"></div>
                     <hr class="myhrline" />
                      
                                <div style="width:10%;float:left;font-size:12px;" class="col-md-3">9</div>
                            
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Computer Centre</div>
                         <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFComputerCentreAreainAcres" runat="server"></asp:label></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFComputerCentreCostinCr" runat="server"></asp:label></div>

               

                    
                          <div style="clear:both;"></div>
                     <hr class="myhrline" />
                        
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">10</div>
                              
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Product Development Centre</div>
                       <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFProductDevelopmentCentreAreainAcres" runat="server"></asp:label></div>
                            <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFProductDevelopmentCentreCostinCr" runat="server"></asp:label></div>

                 

                       
                          <div style="clear:both;"></div>
                     <hr class="myhrline" />
                        
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">11</div>
                             
                                  <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Testing Centre</div>
                         <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFTestingCentreAreainAcres" runat="server"></asp:label></div>
                                  <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFTestingCentreCostinCr" runat="server"></asp:label></div>

                     

                       
                          <div style="clear:both;"></div>
                     <hr class="myhrline" />

                        
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">12</div>
                             
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3">R & D Centre</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFRandDCentreAreainAcres" runat="server"></asp:label></div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFRandDCentreCostinCr" runat="server"></asp:label></div>

                    

                         <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                      
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">13</div>
                              
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Container Freight Station</div>
                        <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFContainerFreightStationAreainAcres" runat="server"></asp:label></div>
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFContainerFreightStationCostinCr" runat="server"></asp:label></div>



                          <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                      
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">14</div>
                           <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Repair workshop for Vehicles</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFRepairworkshopforVehiclesAreainAcres" runat="server"></asp:label></div>
                            <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="CFRepairworkshopforVehiclesCostinCr" runat="server"></asp:label></div>

                  


                       <%--   <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                       --%>
                             
                           <%--    <div class="col-md-12"><b>Business & Commercial Facilities</b></div>--%>
                           

                    
                            <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                     
                              <div style="width:10%;float:left;font-size:12px;" class="col-md-3">15</div>
                          <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Canteen</div>
                    <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFFacilitiesCanteenAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFFacilitiesCanteenCostinCr" runat="server"></asp:label></div>

                     <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                          <div style="width:10%;float:left;font-size:12px;" class="col-md-3">16</div>
                           
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Medical Centre</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFMedicalCentreAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFMedicalCentreCostinCr" runat="server"></asp:label></div>

                     
                        <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">17</div>
                  
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Petrol Pump</div>
                        <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFPetrolPumpAreainAcres" runat="server"></asp:label></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFPetrolPumpCostinCr" runat="server"></asp:label></div>

                    

                    <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">18</div>
                        
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Banking & Finance</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFBankingandFinanceAreainAcres" runat="server"></asp:label></div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFBankingandFinanceCostinCr" runat="server"></asp:label></div>

                       <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                              <div style="width:10%;float:left;font-size:12px;" class="col-md-3">19</div>
                       
                            <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Office Space</div>
                        <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFOfficeSpaceAreainAcres" runat="server"></asp:label></div>
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFOfficeSpaceCostinCr" runat="server"></asp:label></div>

                         <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                            <div style="width:10%;float:left;font-size:12px;" class="col-md-3">20</div>
                          
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Hotel/ Restaurants</div>
                         <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHotelRestaurantsAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHotelRestaurantsCostinCr" runat="server"></asp:label></div>

                     <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">21</div>
               
                            <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Hospital/Dispensary</div>
                      <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHospitalDispensaryAreainAcres" runat="server"></asp:label></div>
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHospitalDispensaryCostinCr" runat="server"></asp:label></div>

                        <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">22</div>
                        
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3">Administration Office	</div>
                     <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFAdministrationOfficeAreainAcres" runat="server"></asp:label></div>
                          <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFAdministrationOfficeCostinCr" runat="server"></asp:label></div>

                         <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                               <div style="width:10%;float:left;font-size:12px;" class="col-md-3">23</div>
                         
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3">	Warehousing Facilities</div>
              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFWarehousingFacilitiesAreainAcres" runat="server"></asp:label></div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFWarehousingFacilitiesCostinCr" runat="server"></asp:label></div>

                    <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                      <div style="width:10%;float:left;font-size:12px;" class="col-md-3">24</div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>Housing/ Dormitory/ Hostel for Domicile Worke</b></div>
                              
                     <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHousingDormitoryHostelforDomicileWorkeAreainAcres" runat="server"></asp:label></div>
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="BCFHousingDormitoryHostelforDomicileWorkeCostinCr" runat="server"></asp:label></div>

                         <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                       
                                <div style="width:10%;float:left;font-size:12px;" class="col-md-3">25</div>
                    <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>Other</b></div>
                <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="OtherAreainAcres" runat="server"></asp:label></div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:label ID="OtherCostinCr" runat="server"></asp:label></div>

                   


                            <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         
                           <div class="col-md-12 col-sm-12 col-xs-12"> <b>  Unit Details</b></div>
                               <div style="clear:both;"></div>
                           
                             <hr class="myhrline" />
                       
                        
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>S.No</b></div>
                            <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>Unit Name</b></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>Type</b></div>
                           
                           <div style="clear:both;"></div>
                             <hr class="myhrline" />
                   
                               <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>1</b></div>
                           <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitname1" runat="server"></asp:Label></div>
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitnametype1" runat="server"></asp:Label></div>
                           
                      <div style="clear:both;"></div>
                             <hr class="myhrline" />
                        
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>2</b></div>
                             <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitname2" runat="server"></asp:Label></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitnametype2" runat="server"></asp:Label></div>
                           
                      <div style="clear:both;"></div>
                             <hr class="myhrline" />
                          <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>3</b></div>
                                <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitname3" runat="server"></asp:Label></div>
                                   <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitnametype3" runat="server"></asp:Label></div>
                            
                      <div style="clear:both;"></div>
                             <hr class="myhrline" />

                     
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>4</b></div>
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitname4" runat="server"></asp:Label></div>
                                   <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitnametype4" runat="server"></asp:Label></div>
                               <div style="clear:both;"></div>
                             <hr class="myhrline" />
                              <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><b>5</b></div>
                                 <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitname5" runat="server"></asp:Label></div>
                                   <div style="width:30%;float:left;font-size:12px;" class="col-md-3"><asp:Label ID="udunitnametype5" runat="server"></asp:Label></div>
                             <div style="clear:both;"></div>
                             <hr class="myhrline" />
                         <div class="col-md-12 col-sm-12 col-xs-12"> <b>Implementation Schedule</b></div>
                             
                       <div style="clear:both;"></div>
                             <hr class="myhrline" />
                        
                        <div style="width:100%;float:left;">
                                                              <div style="width:5%;float:left;font-size:12px;font-weight:700;" class="col-md-1">
                                                                Year
                                                          </div>
                                                           <div style="width:10%;float:left;font-size:12px;font-weight:700;" class="col-md-1">
                                                                Date of acquiring  land
                                                            </div>
                                                             <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-2">
                                                                Start of Construction Date
                                                             </div>
                                                           <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-2">
                                                                Completion of Infrastructure Date  
                                                             </div>

                                                               <div style="width:25%;float:left;font-size:12px;font-weight:700;" class="col-md-2">
                                                                Date of Placing order for Plant & Machinery    
                                                          </div>
                                                             <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-2">
                                                                Installation/Erection Date    
                                                          </div>
                                                              <div style="width:15%;float:left;font-size:12px;font-weight:700;" class="col-md-2">
                                                                Date of Commercial Operation
                                                              </div>


                                                        </div>
                         <div style="clear:both;"></div>
                             <hr class="myhrline" />
                      <div style="width:100%;float:left;">
                                                            
                                                       <label class="col-sm-1  col-xs-6" style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>1</b> </label>       
                                                            <div class="col-md-1 col-sm-6 col-xs-6" style="width:10%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Dateofacquiringlandyear1" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear1" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear1" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear1" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear1" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 " style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                        <div style="clear:both;"></div>
                             <hr class="myhrline" />
                        
                                         <div style="width:100%;float:left;">
                                                            
                                                       <label class="col-sm-1  col-xs-6"style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>2</b> </label>       
                                                            <div class="col-md-1 col-sm-6 col-xs-6 "style="width:10%;float:left;font-size:12px;font-weight:700;" >
                                                                <asp:Label ID="Dateofacquiringlandyear2" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear2" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear2" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear2" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear2" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear2" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
              
                           <div style="clear:both;"></div>
                             <hr class="myhrline" />

                                  <div style="width:100%;float:left;">
                                                            
                                                       <label class="col-sm-1  col-xs-6 "style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>3</b> </label>       
                                                            <div class="col-md-1 col-sm-6 col-xs-6  "style="width:10%;float:left;font-size:12px;font-weight:700;" >
                                                                <asp:Label ID="Dateofacquiringlandyear3" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear3" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear3" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear3" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear3" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6" style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear3" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
            
                          <div style="clear:both;"></div>
                             <hr class="myhrline" />

                                       <div style="width:100%;float:left;">
                                                            
                                                       <label class="col-sm-1  col-xs-6" style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>4</b> </label>       
                                                            <div class="col-md-1 col-sm-6 col-xs-6" style="width:10%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Dateofacquiringlandyear4" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6  "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear4" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear4" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 " style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear4" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 " style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear4" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 " style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear4" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
               
                    <div style="clear:both;"></div>
                             <hr class="myhrline" />

                             <div style="width:100%;float:left;">
                                                            
                                                       <label class="col-sm-1  col-xs-6" style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>5</b> </label>       
                                                            <div class="col-md-1 col-sm-6 col-xs-6"style="width:10%;float:left;font-size:12px;font-weight:700;" >
                                                                <asp:Label ID="Dateofacquiringlandyear5" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear5" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear5" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear5" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear5" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear5" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                          <div style="clear:both;"></div>
                             <hr class="myhrline" />

                      <div style="width:100%;float:left;">
                   
          
                                                       <label class="col-md-2 col-sm-6 col-xs-6 "style="width:5%;float:left;font-size:12px;font-weight:700;">
                                                             <b>6</b> </label>       
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:10%;float:left;font-size:12px;font-weight:700;" >
                                                                <asp:Label ID="Dateofacquiringlandyear6" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="StartofConstructionDateyear6" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="CompletionofInfrastructureDateyear6" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:25%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="DateofPlacingorderforPlantandMachineryyear6" runat="server" ></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="InstallationErectionDateyear6" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-2 col-sm-6 col-xs-6 "style="width:15%;float:left;font-size:12px;font-weight:700;">
                                                                <asp:Label ID="Proposeddateforcompletionyear6" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                            <div style="clear:both;"></div>
                             <hr class="myhrline" />


              
                         <div class="col-md-12 col-sm-12 col-xs-12"><b> Other Details</b></div>
                             
                           
                
                       <div style="clear:both;"></div>
                             <hr class="myhrline" />



                                    <label style="width:33%;float:left;" class="col-md-3"> Environmental Clearances:</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="EnvironmentalClearances" runat="server"></asp:label></div> 
                                    

                                  <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3">Operations and Maintenance to be Taken up by:</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="OperationsandMaintenancetobeTakenupby" runat="server"></asp:label></div>
                                        <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3"><b>Detailed Project Report Summary</b></label>
                                    <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                                    <label style="width:33%;float:left;" class="col-md-3">Cash Flow Projections:</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="CashFlowProjections" runat="server"></asp:label></div>
                                     <div style="clear:both;"></div>
                                    <hr class="myhrline" />




                           <div  style="width:100%;float:left;">
                                                            <label class="col-md-4 col-xs-6 " style="width:33%;float:left;">
                                                                Year
                                                            </label>
                                                            <label class="col-md-4 col-xs-6" style="width:33%;float:left;">
                                                                Projected Inflow (in Cr)
                                                            </label>
                                                           
                                                                    <label class="col-md-4 col-xs-6"  style="width:33%;float:left;">
                                                            Projected Outflow (in Cr) </label>
                                                         
                                                                     
                                                        </div>

                                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />


                                                            <label class="col-md-4 col-xs-6"  style="width:33%;float:left;" >
                                                                1
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6"  style="width:33%;float:left;">
                                                                <asp:Label runat="server" ID="ProjectedInflowinCrYear1"></asp:Label>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6"  style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedOutflowinCrYear1"  runat="server"></asp:Label>

                                                            </div>
                                                  
                                                        <hr class="myhrline" />
                                                        <div  style="width:100%;float:left;">


                                                            <label class="col-md-4 col-xs-6 "  style="width:33%;float:left;">
                                                                2
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6"  style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedInflowinCrYear2"  runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6"  style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedOutflowinCrYear2" runat="server"></asp:Label>

                                                            </div>




                                                        </div>







                                                 <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                                        <div  style="width:100%;float:left;">


                                                            <label class="col-md-4 col-xs-6 " style="width:33%;float:left;">
                                                                3
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6" style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedInflowinCrYear3" runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6 " style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedOutflowinCrYear3"  runat="server"></asp:Label>

                                                            </div>
                                                        </div>

                                                   <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                                        <div  style="width:100%;float:left;">


                                                            <label class="col-md-4 col-xs-6 " style="width:33%;float:left;">
                                                                4
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6 " style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedInflowinCrYear4"  runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6 " style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedOutflowinCrYear4"  runat="server"></asp:Label>

                                                            </div>
                                                        </div>

                                                       <div style="clear:both;"></div>
                             <hr class="myhrline" />
                                                                <div  style="width:100%;float:left;">


                                                            <label class="col-md-4 col-xs-6 text-left " style="width:33%;float:left;">
                                                                5
                                                            </label>
                                                            <div class="col-md-4 col-sm-6 col-xs-6" style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedInflowinCrYear5"  runat="server"></asp:Label>

                                                            </div>
                                                            <div class="col-md-4 col-sm-6 col-xs-6" style="width:33%;float:left;">
                                                                <asp:Label ID="ProjectedOutflowinCrYear5" runat="server"></asp:Label>

                                                            </div>
                                                        </div>
                            <div style="clear:both;"></div>
                          <hr class="myhrline" />

                                    <label style="width:33%;float:left;" class="col-md-3">Building Plan Approval Status:</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="BuildingPlanApprovalStatus" runat="server"></asp:label></div>
                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />

                             <label style="width:33%;float:left;" class="col-md-3">Building Plan Approved from (Authority):</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="BuildingPlanApprovedfromAuthority" runat="server"></asp:label></div>
                                     <div style="clear:both;"></div>
                                    <hr class="myhrline" />

                        
                             <label style="width:33%;float:left;" class="col-md-3"> Building Plan Application Id (OBPAS):</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="BuildingPlanApplicationIdOBPAS" runat="server"></asp:label></div>
                                    
                                      <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                            <label style="width:33%;float:left;" class="col-md-3"> Ownership of Hostel/ Dormitory (Company):</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="OwnershipofHostelDormitoryCompany" runat="server"></asp:label></div>
                                  
                                   

                        <div style="clear:both;"></div>
                                    <hr class="myhrline" />
                            <label style="width:33%;float:left;" class="col-md-3"> Any Other Information:</label>
                                    <div style="width:65%;float:left;font-size:12px;font-weight:700;" class="col-md-3"><asp:label ID="AnyOtherInformation" runat="server"></asp:label></div>
                                     <div style="clear:both;"></div>
                          
                                    
                       </div>
                     
                    




                  
                 </div>


                

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
                        <div class="payment-upload" style="border: 2px solid #ccc;margin-top: 20px; display:none" >
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>E. Payments Details</b></div><br />
                                    <div style="clear:both;"></div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        
                                         


                    <div class="div-report" runat="server"  style="text-align: center;">                 
	                    <h2 style = "text-decoration:underline;" >  Statement of Estimated Deposits</h2><br/>
                        <div class='col- md-6'>
                            <table class="table-bordered pull-left" width="100%" style="Font-Size:12px;">
                                <tr> 
                                    <th style='background:#f7f7f7;'>Application Reference Number</th>
                                    <td class='text-left'><asp:Label ID="lblSERviceNo" runat="server" Text="Label"></asp:Label></td>
                                    <th>Applied in the name of </th>
                                    <td class='text-left'><asp:Label ID="lblAName" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <th style='background:#f7f7f7;'> Address </th>
                                    <td class='text-left'><asp:Label ID="lblPAddress" runat="server" ></asp:Label></td>
                                    <th style='background:#f7f7f7;'> Transaction Ref No </th>
                                    <td class='text-left'><asp:Label ID="lblTransactionNo" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <th> Payment Received Date </th>
                                    <td class='text-left'><asp:Label ID="lblPayDate" runat="server" ></asp:Label></td>
                                    <th style='background:#f7f7f7;'> Payment Status </th>
                                    <td class='text-left'><asp:Label ID="lblPaystatus" runat="server" ></asp:Label></td>
                                </tr>
                            </table>
                        </div><br/><br/><br/><br/>
                        <div class='row'><label class="col-md-12 col-sm-12 col-xs-12 text-center" style='border-top:dashed'> </label></div>
                        <br/>
                        <div class='col- md-6'>
                            <table class="table-bordered pull-right" width="41%" style="Font-Size:12px;">                                 
                                <tr style = 'background:#f7f7f7;'>
                                    <th>Applicable Fees</th>
                                    <th class='text-center'><i class='fa fa-inr'></i>10000</th>
                                </tr>
                                <tr style = 'background:#f7f7f7;'>
                                    <th> Total Applicable Charges </th>
                                    <th class='text-center'><i class='fa fa-inr'></i>11800</th>
                                </tr>
                            </table>
                        </div><br /><br/><br/>
                    
                        <table class="table table-bordered table-hover request-table">
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class="text-center">Amount</th>
                            </tr>
                            <tr>
                                <td colspan="3">A. Applicable Fees</td>
                            </tr>
                            <tr>
                                <td class='text-center'> 1 </td>
                                <td class='text-center'> Processing Fess Against Application for Issuance of Unique Id for Private Industrial Parks </td>
                                <td class='text-center'> 10000</td>
                            </tr>
                            <tr> 
                                <td class='text-center'> 2 </td> 
                                <td class='text-center'> GST 18% </td> 
                                <td class='text-center'> 1800</td>
                            </tr>
                            <tr>
                                <td colspan="2" class='text-center'>Total Applicable Fees</td>
                                <th class='text-left'><i class='fa fa-inr'></i>10000</th>
                            </tr>
                            <tr>
                                <th colspan="2" class='text-center'> Total Payable</th>
                                <th class='text-left'><i class='fa fa-inr'></i>11800</th>
                            </tr>
                        </table>
                    </div>
                
                                      
                                    </div>
                                    <div style="clear:both;"></div>
                        </div>
                        
                        
                        <div style="clear:both;"></div>
                        
                        <!--
                        <div runat="server" id="ObjectionDiv" visible="false">
                            <div class="document-upload" style="border: 2px solid #ccc;margin-top: 20px;">
                            <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>D. Documents Uploaded</b></div><br />
                            <div style="clear:both;"></div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:PlaceHolder runat="server" ID="PHObjection"></asp:PlaceHolder> 
                            </div>
                            <div style="clear:both;"></div>
                            </div>

                        </div>
                        -->
                        

  <div style="clear:both;"></div>  
                         <div style="clear:both;"></div>
                        <div class="project-detail" style="border: 2px solid #ccc;margin-top: 20px;">
                                    <div class="col-md-12 col-sm-12 col-xs-12 main-head"><b>Sign</b></div><br />
                                    <div style="clear:both;"></div>

                       

                            <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                </div>
                          <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                         <img src = "" runat="server" id="Img2" style="max-height:150px;max-width:195px;" />  <br /><br /><p>Applicant Signature</p> 
                                    </div>


<%--
                                      <div style="clear:both;"></div>
                            
                                        <div style="clear:both;"></div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:PlaceHolder runat="server" ID="PHH2"></asp:PlaceHolder>                                                                  
                                </div>  --%>                                                   
                        <div style="clear:both;"></div>
                        </div>


                        
                        <div style="clear:both;"></div>
                          
                          <div class="payment" style="border: 2px solid #ccc;margin-top: 20px;">
                                    
                                    <div style="clear:both;"></div>
                                    <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                     </div>
                           <%--    <div class="col-md-6 col-sm-6 col-xs-6 text-center">
                                         <img src = "" runat="server" id="Img2" style="max-height:150px;max-width:195px;" />  <br /><br /><p>Applicant Signature</p> 
                                    </div>--%>
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

        
  