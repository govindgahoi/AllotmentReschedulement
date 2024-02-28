<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LAWEvaluation.ascx.cs" Inherits="Allotment.UC_LAWEvaluation" %>

<style>
     .MessagePennel {
            background-color: #f4e542;
            width: 100%;
        }

        .check-cross {
            color: #f70000;
            font-size: 18px;
            line-height: 0.7;
            font-weight: 100;
        }
</style>


   
<div class="panel panel-default" style="margin-left:24px;">
      
       <div class="text-center" style="font-weight:bolder;">Annexure I </div>
   
       <hr class="myhrline" />
   
       <div class="text-left" style="font-weight:bold;">Evaluation report as per “Uttar Pradesh Warehousing and Logistic Policy-2018”</div>
  <br />
       <div class="panel-body ">

                <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">1. Applicant Name :</span>
                    <asp:Label ID="lblApplicantNameAuth" runat="server" CssClass="font-12px"></asp:Label>
                </div>
               <div class="clearfix"></div>
               <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">2. Location Of Proposal :</span>
                    <asp:Label ID="lblProjectLocationAddress" runat="server" CssClass="font-12px"></asp:Label>
                </div>
               <div class="clearfix"></div>
            <br />
                <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">1. Eligibility Criteria :</span>
                </div>
            <div class="clearfix"></div>  <br />
            <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;margin-left:10px;">1.1 Area :</span>
                </div>
             <div class="clearfix"></div>
           <div>
                <table class="table table-bordered table-hover request-table" id="datatableService">
  
  <colgroup span="2">
  <col>
  <col>
  
  </colgroup>
  <colgroup span="2">
  <col>
  <col> 
  </colgroup>
  <tr>

    <th rowspan="2" style="width:10%;">Clause as per the Policy </th>
    <th rowspan="2" style="width:20%;">Clause </th>
    <th colspan="2" scope="colgroup" style="text-align:center;">Proposed Area As Per Applicant</th>
    <th colspan="2" scope="colgroup" style="text-align:center;">Proposed Area As Per UPSIDA</th>
    <th rowspan="2">Compliance</th>
    <th rowspan="2">Comment</th>
  </tr>
  <tr>
    
    <th scope="col">Total Area</th>
    <th scope="col">Covered Area</th>
    <th scope="col">Total Area</th>
    <th scope="col">Covered Area</th>
  </tr>
  
  <tr>
    <td scope="row">3.2.3</td>
    <td scope="row">Warehousing facility 
with minimum 
investment of INR 25 
crore and minimum 
area of 1 lakh sq.ft.</td>
    <td><asp:Label runat="server" ID="lblProposedArea"></asp:Label></td>
    <td><asp:Label runat="server" ID="lblProposedCoveredArea"></asp:Label></td>
    <td><asp:TextBox ID="txtTotalArea"  runat="server" class="input-sm myyellowbgsmall" style="width:60px !important;"></asp:TextBox></td>
    <td><asp:TextBox ID="txtTotalCoveredArea"  runat="server" class="input-sm myyellowbgsmall"  style="width:88px !important;"></asp:TextBox></td>
    <td><asp:DropDownList runat="server"  Class="btn btn-default dropdown-toggle" ID="drp1"><asp:ListItem Value="0">--Select--</asp:ListItem><asp:ListItem Value="Yes">Yes</asp:ListItem><asp:ListItem Value="No">No</asp:ListItem></asp:DropDownList></td>
    <td><asp:TextBox ID="txtAreaComments"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
  </tr>
  
</table>
           </div>

           <div class="clearfix"></div>
           <br />
            <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;margin-left:10px;">1.2 Investment :</span>
                </div>
             <div class="clearfix"></div>
              <div>
                  <table class="table table-bordered table-hover request-table">
                      <thead>
                          <tr>
                              <th>3.2.3</th>
                              <th style="width:25%;">Warehousing facility with minimum investment of INR 25 crore and minimum area of 1 lakh sq.ft. </th>
                              <th style="width:15%;">Cost (INR) in Crores (As Per Applicant)</th>
                              <th style="width:15%;">Cost (INR) in Crores (As Per UPSIDA)</th>
                              <th>Compliance </th>
                          </tr>
                          
                      </thead>
                      <tbody>
                          <tr>
                              <td>1</td>
                              <td>Land</td>
                              <td><asp:Label runat="server" ID="lblLand"></asp:Label></td>
                              <td><asp:TextBox ID="txtLand"  runat="server" class="input-sm myyellowbgsmall"></asp:TextBox></td>                         
                              <td rowspan="5"><asp:TextBox ID="txtInvestmentCompliance"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:100px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td>2</td>
                              <td> Construction of Building Work </td>
                              <td><asp:Label runat="server" ID="lblBuildingWorks"></asp:Label></td>
                              <td><asp:TextBox ID="txtBuildingWorks"  runat="server" class="input-sm myyellowbgsmall"></asp:TextBox></td>                              
                          </tr>
                           <tr>
                              <td>3</td>
                              <td> Infrastructure cost estimate </td>
                              <td><asp:Label runat="server" ID="lblCostEstimate" ></asp:Label></td>
                               <td><asp:TextBox ID="txtCostEstimate"  runat="server" class="input-sm myyellowbgsmall"></asp:TextBox></td>
                              
                          </tr>
                           <tr>
                              <td>3.1</td>
                              <td>&emsp;Other Facilities </td>
                              <td><asp:Label runat="server" ID="lblOtherFacilities" ></asp:Label></td>
                               <td><asp:TextBox ID="txtOtherFacilities"  runat="server" class="input-sm myyellowbgsmall"></asp:TextBox></td>
                             
                          </tr>
                           <tr>
                              <td></td>
                              <td style="font-weight:bold;"> Total </td>
                              <td style="font-weight:bold;"><asp:Label runat="server" ID="lblTotalInvestment" ></asp:Label></td>
                             <td style="font-weight:bold;"><asp:Label runat="server" ID="lblTotalInvestment1" ></asp:Label></td>
                             
                          </tr>
                      </tbody>
                      </table>
              </div>

             <br />
                <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">2. Evaluation as per Annexure 1 of Logistic and Warehousing 2018 Rules :</span>
                </div>
           <div class="clearfix"></div>
           <div>
               <table class="table table-bordered table-hover request-table">
                      <thead>
                          <tr>
                              <th>S.No</th>
                              <th style="width:25%;">Details</th>
                              <th style="width:25%;">Description</th>
                              <th style="width:25%;">Description (As Per UPSIDA)</th>
                              <th>Remarks</th>
                          </tr>
                          
                      </thead>
                      <tbody>
                          <tr>
                              <td rowspan="2">1</td>
                              <td style="font-weight:bold;" >Applicant Name</td>
                              <td><asp:Label runat="server" ID="lblApplicantName"></asp:Label></td>
                              <td><asp:TextBox ID="txtApplicantName"  runat="server"  class="input-sm myyellowbgsmall"  TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtApplicantNameRemarks"   runat="server"  class="input-sm myyellowbgsmall"  TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr><td style="font-weight:bold;">Address</td>
                              <td>
                                  <asp:Label runat="server" ID="lblCompanyName"  style="font-weight:bold;"></asp:Label>
                                  <br />
                                  Address : <asp:Label runat="server" ID="lblCompanyAddress" ></asp:Label>
                                  <br />
                                  <asp:Label runat="server" ID="lblAuthorisedPerson"  style="font-weight:bold;"></asp:Label>
                                  <br />
                                  Address : <asp:Label runat="server" ID="lblAuthorisedPersonAddress" ></asp:Label>
                                 
                              </td>
                              <td><asp:TextBox ID="txtCompanyVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:40px !important;"></asp:TextBox>
                                  <br /><asp:TextBox ID="txtCompanyAddressVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:40px !important;"></asp:TextBox>
                                  <br /><asp:TextBox ID="txtAuthorisedPersonVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:40px !important;"></asp:TextBox>
                                 <br /><asp:TextBox ID="txtAuthorisedPersonAddressVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:40px !important;"></asp:TextBox>
                              </td>
         
                              <td><asp:TextBox ID="txtAddressRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:160px !important;"></asp:TextBox></td></tr>
                    <tr><td>2</td><td style="font-weight:bold;">Company Constitution</td>
                        <td><asp:Label runat="server" ID="lblCompanyConsitution" ></asp:Label></td>
                        <td><asp:TextBox ID="txtCompanyConstitutionVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtCompanyConstitutionRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>3</td><td style="font-weight:bold;">Project Location</td>
                        <td><asp:Label runat="server" ID="lblProjectLocation" ></asp:Label></td>
                        <td><asp:TextBox ID="txtProjectLocationVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtProjectLocationRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>4</td><td style="font-weight:bold;">Names of Directors/Promoter/Partners Name of the applicant </td>

                        <td><asp:Label runat="server" ID="lblNameofPromoters" ></asp:Label><br /><asp:Label runat="server" ID="lblConstitutionPeople"></asp:Label></td>
                        <td><asp:TextBox ID="txtNameofPromotersVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtNameofPromotersRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>5</td><td style="font-weight:bold;">GSTIN Number</td>
                        <td><asp:Label runat="server" ID="lblGSTINNumber" ></asp:Label></td>
                        <td><asp:TextBox ID="txtGSTINNumberVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGSTINNumberRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>6</td><td> <span style="font-weight:bold;">Type of Project </span><br />New/Existing/Expansion/Diversified </td>
                        <td><asp:Label runat="server" ID="lblTypeofProject" ></asp:Label></td>
                        <td><asp:TextBox ID="txtTypeofProjectVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtTypeofProjectRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>7</td><td> <span style="font-weight:bold;">Category of project</span><br />a) Logistic Park<br />b) Container Freight Station<br />c) Warehousing Facility<br />d) Cold Chain Facility </td>
                        <td>As per Logistic and Warehousing Policy clause: 3.2.3 – <asp:Label runat="server" ID="lblCategoryProject" ></asp:Label></td>
                        <td><asp:TextBox ID="txtCategoryProjectVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtCategoryProjectRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                     <tr><td>8</td><td> <span style="font-weight:bold;">Registration/Permit for setting Logistic and Warehousing Unit  </span></td>
                        <td><asp:Label runat="server" ID="lblRegistrationPermit" ></asp:Label></td>
                        <td><asp:TextBox ID="txtRegistrationPermitVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRegistrationPermitRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>9</td><td> <span style="font-weight:bold;">Proposed date for setting up logistic unit  </span></td>
                        <td><asp:Label runat="server" ID="lblProposeddateforsettinguplogisticunit" ></asp:Label></td>
                        <td><asp:TextBox ID="txtProposeddateforsettinguplogisticunitVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtProposeddateforsettinguplogisticunitRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>10</td> <td> <span style="font-weight:bold;">Proposed Capital Investment</span><br /><br />
                                         <span style="font-weight:bold;">excluding ineligible capital investment on heads as described in rules clause no 2.10. </span><br /><br />
                                            a) Working capital- INR <br />
                                            b) Goodwill – INR       <br />
                                            c) Royalty – INR        <br />
                                            d) Preliminary & preoperative expenses – INR <br />
                                            e) Capitalize Interest – INR  <br />
                                            f) Exp on electricity generation other than captive/self-use – INR  <br />
                                            g) Technical knowhow fee/consultancy fee- INR  <br /><br />
                        <span>Total of A to G in INR </span><br/><br />
                        <span>So Eligible investment INR </span>
                                    </td>
                        <td><asp:Label runat="server" ID="lblProposedCapitalInvestment" ></asp:Label> Crores (including land cost)</td>
                        <td><asp:TextBox ID="txtProposedCapitalInvestmentVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtProposedCapitalInvestmentRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                    <tr><td>11</td><td> <span style="font-weight:bold;"> The date when capital investment has been started,or is proposed to be started </span></td>
                        <td><asp:Label runat="server" ID="lblinvestmentstarted" ></asp:Label></td>
                        <td><asp:TextBox ID="txtdatewhencapitalinvestmentstartedVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtdatewhencapitalinvestmentstartedReamrks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:60px !important;"></asp:TextBox></td>
                    </tr>
                          </tbody>

               </table>

           </div>
            <br />
                <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">12. Requested benefits by Applicant  :</span>
                </div>
           <div class="clearfix"></div>
           <div>
               <table class="table table-bordered table-hover request-table">
                      <thead>
                          <tr>
                              <th>S.No</th>
                              <th>Description</th>
                              <th style="width:25%;">Amount (INR) applied for (As per Applicant)</th>
                              <th style="width:25%;">Amount (INR) applied for  (As Per UPSIDA)</th>
                              <th>Remarks</th>
                          </tr>                   
                      </thead>
                      <tbody>
                          <tr>
                              <td >12.1</td>
                              <td style="font-weight:bold;" >Total Amount as requested by Applicant </td>
                              <td><asp:Label runat="server" ID="lblTotalAmountrequested"></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtTotalAmountrequestedVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtTotalAmountrequestedRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2</td>
                              <td style="font-weight:bold;"colspan="4" >Applicant Benefit Details </td>
                              
                           </tr> 
                            <tr>
                              <td >12.2.1</td>
                              <td style="font-weight:bold;" >Rebate on Stamp Duty</td>
                              <td><asp:Label runat="server" ID="lblRebateonStampDuty"></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtRebateonStampDutyVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtRebateonStampDutyRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.2</td>
                              <td style="font-weight:bold;" >EPF Reimbursement (More than 100 unskilled workers) </td>
                              <td><asp:Label runat="server" ID="lblEPFReimbursement" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtEPFReimbursementVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtEPFReimbursementRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.3</td>
                              <td style="font-weight:bold;" >10% Additional EPF Reimbursement (200 skilled and unskilled workers)</td>
                              <td><asp:Label runat="server" ID="lblAdditionalEPFReimbursement"></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtAdditionalEPFReimbursementVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtAdditionalEPFReimbursementRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.4</td>
                              <td style="font-weight:bold;" > Capital Interest Subsidy </td>
                              <td><asp:Label runat="server" ID="lblCapitalInterestSubsidy"></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtCapitalInterestSubsidyVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtCapitalInterestSubsidyRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2.5</td>
                              <td style="font-weight:bold;" >Infrastructure Interest Subsidy</td>
                              <td><asp:Label runat="server" ID="lblInfrastructureInterestSubsidy" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtInfrastructureInterestSubsidyVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtInfrastructureInterestSubsidyRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2.6</td>
                              <td style="font-weight:bold;" >Rebate on Land use conversion charges </td>
                              <td><asp:Label runat="server" ID="lblRebateonLanduseconversioncharges" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtRebateonLanduseconversionchargesVerfied"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtRebateonLanduseconversionchargesRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.7</td>
                              <td style="font-weight:bold;" >Exemption from development charges</td>
                              <td><asp:Label runat="server" ID="lblExemptionfromdevelopmentcharges" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtExemptionfromdevelopmentchargesVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtExemptionfromdevelopmentchargesRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2.8</td>
                              <td style="font-weight:bold;" > Electricity Rebate </td>
                              <td><asp:Label runat="server" ID="lblElectricityRebate" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtElectricityRebateVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtElectricityRebateRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2.9</td>
                              <td style="font-weight:bold;" >Warehousing quality certification reimbursement </td>
                              <td><asp:Label runat="server" ID="lblWarehousingqualitycertificationreimbursement" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtWarehousingqualitycertificationreimbursementVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtWarehousingqualitycertificationreimbursementRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          <tr>
                              <td >12.2.10</td>
                              <td style="font-weight:bold;" >500/- per month assistance for payroll of disabled workers </td>
                              <td><asp:Label runat="server" ID="lblpayrollofdisabledworkers" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtpayrollofdisabledworkersVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtpayrollofdisabledworkersRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.11</td>
                              <td style="font-weight:bold;" >Skill development promotion </td>
                              <td><asp:Label runat="server" ID="lblSkilldevelopmentpromotion" ></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtSkilldevelopmentpromotionVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtSkilldevelopmentpromotionRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >12.2.12</td>
                              <td style="font-weight:bold;" >Intelligent Logistic Incentives </td>
                              <td><asp:Label runat="server" ID="lblIntelligentLogisticIncentives"></asp:Label> crore</td>
                              <td><asp:TextBox ID="txtIntelligentLogisticIncentivesVerified"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>                   
                              <td><asp:TextBox ID="txtIntelligentLogisticIncentivesRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                          </tbody>
                   </table>
               </div>

            <br />
                <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">12. Requested benefits by Applicant  :</span>
                </div>
           <div class="clearfix"></div>
           <div>
           <asp:GridView ID="Grid_Comments" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table" ShowFooterWhenEmpty="true" ShowHeaderWhenEmpty="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="Grid_Comments_RowDeleting">
																	                            <Columns>

																		                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblInspectionDocument" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> </asp:Label>
																			                            </ItemTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField  HeaderText="Clause as per Policy">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClauseasperPolicy" runat="server" Text='<%#Eval("ClauseasperPolicy") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtClauseasperPolicy_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField HeaderText="Description">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtDescription_insert" runat="server" CssClass="input-sm similar-select1"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField  HeaderText="Clause Description">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClausedescription" runat="server" Text='<%#Eval("Clausedescription") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtClausedescription_insert" CssClass="input-sm similar-select1" runat="server"></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Incentives Seek as per the proposal">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblIncentivesSeekaspertheproposal" runat="server" Text='<%#Eval("IncentivesSeekaspertheproposal") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtIncentivesSeekaspertheproposal_insert" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Benefit Eligibility">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblBenefitEligibility" runat="server" Text='<%#Eval("BenefitEligibility") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:TextBox ID="txtBenefitEligibility_insert" CssClass="input-sm similar-select1" runat="server" ></asp:TextBox>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																		                            <asp:TemplateField>
																			                            <ItemTemplate>
																				                            <asp:ImageButton CommandName="Delete" CssClass="fa fa-trash-o" ToolTip="Delete" ID="btn_delete" runat="server"
																					                            ImageUrl="~/images/delete.png" Width="16px" Height="16px" OnClientClick="javascript:return confirm('Are you sure wanted to delete?');" />

																			                            </ItemTemplate>
																			                            <FooterStyle HorizontalAlign="Right" />
																			                            <FooterTemplate>
                                                                                                            
																				                               <asp:Button runat="server" ID="BtnSave" OnClientClick="return checkGrid1();" OnClick="insert_Comments_details" CssClass="btn btn-sm btn-primary" Text="Add" Style="padding: 0px 10px !important;" />

																			                            </FooterTemplate>
																		                            </asp:TemplateField>


																	                            </Columns>
																                            </asp:GridView>

           </div>



            <div style="text-align:left;">
                    <span class="font-12px" style="font-weight:bold;">13. Additional Documents as per policy rules:</span>
                </div>
           <div class="clearfix"></div>
           <div>
         <table class="table table-bordered table-hover request-table">
                      <thead>
                          <tr>
                              <th>S.No</th>
                              <th  style="width:40%;">Description</th>
                              <th>Compliance</th>                                                       
                          </tr>
                          
                      </thead>
                      <tbody>
                          <tr>
                              <td >A</td>
                              <td >Registration Certificate</td>
                              <td><asp:TextBox ID="txtRegistrationCertificateRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                              </tr>
                           <tr>
                              <td >B</td>
                              <td >List of Audited balance sheet with all annexures of current and last five financial years</td>
                              <td><asp:TextBox ID="txtAuditedbalancesheetRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >C</td>
                              <td >Detailed Project Report</td>
                              <td><asp:TextBox ID="txtDetailedProjectReportRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                              </tr>
                           <tr>
                              <td >D</td>
                              <td >CA certified MoA/Article of Association/By laws along 
                                    with CA certificate regarding applicant company/lead 
                                      member block of gross assets</td>
                              <td><asp:TextBox ID="txtMoARemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                              </tr>
                           <tr>
                              <td >E</td>
                              <td >Chartered Engineer certificate of fixed assets status out of 
                                     gross block asset of applicant company/lead member</td>
                              <td><asp:TextBox ID="txtEngineercertificateRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                           <tr>
                              <td >F</td>
                              <td >Affidavit</td>
                              <td><asp:TextBox ID="txtAffidavitRemarks"  runat="server" class="input-sm myyellowbgsmall" TextMode="MultiLine" Style="width:100%;height:50px !important;"></asp:TextBox></td>
                           </tr>
                   
                      </tbody></table>
           </div>
            <div>
															                            <div class="row">
																                            <div class="col-md-3 col-sm-6 col-xs-6">
																	                        </div>
																                            <div class="col-md-6 text-center col-sm-6 col-xs-6">
																	                        <asp:Button ID="BtnProjectInsert" Style="margin: 0 1px 0 0; width: 200px;" OnClick="BtnProjectInsert_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton"  runat="server" Text="Save" />
                                                                                                 <asp:Button ID="btnPrint" Style="margin: 0 1px 0 0; width: 200px;" OnClick="btnPrint_Click" CssClass="btn btn-primary btn-sm" ValidationGroup="ValidationButton"  runat="server" Text="Print Evaluation Sheet"  />
                                                                                                </div>
																                            <div class="col-md-3"></div>
															                            </div>
														                            </div>
       </div>
      
    </div>

<script type="text/javascript">

    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
    });

    function PageLoaded(sender, args) {
        $(".chosen").chosen();
    }


    function MsgAndRedirectModify(ID) {
        
        window.location.href = 'LAWEvaluationSheetPrint.aspx?ID=' + ID;

    }
   

</script>