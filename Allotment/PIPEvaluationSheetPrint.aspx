<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PIPEvaluationSheetPrint.aspx.cs" Inherits="Allotment.PIPEvaluationSheetPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/CssManu.css" rel="stylesheet" />
    <link href="css/Main.css" rel="stylesheet" />
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/ajax-jquery-ui.css" rel="stylesheet" />
    <link href="css/Footer.css" rel="stylesheet" />
    <script src="js/ajax-jquery-min.js"></script>
    <script src="js/ajax-jquery-ui.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="/js/jquery1.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <link href="css/chosen.min.css" rel="stylesheet" />
    <script src="js/chosen.jquery.min.js"></script>
  




    <style type="text/css">
        
        h4.modal-title {
            margin-right: 18px !important;
        }

        .mynew-panel-head {
            font-size: 14px !important;
            font-weight: 600;
            background: #2d2d2d;
            color: #ffc511 !important;
            text-align: center !important;
        }

        .modal.fade.in {
            background: rgba(0, 0, 0, 0.51);
        }

        @media screen and (min-width: 992px) {
            #myModal .modal-dialog {
                width: 800px;
                /* height: 300px; */
                margin-top: 1%;
            }
        }
        .fill-view-mytable td {
            font-size:16px !important;
        }
        .modal-header {
            padding: 2px !important;
        }

        @media screen and (max-width: 768px) {
            .form-group .col-xs-6 {
                width: 50% !important;
            }
        }

        .content {
            min-height: 600px;
        }


            .my-app-status li:after{
               content: "\f178";
               font-family: FontAwesome;
               font-weight: 800;
               font-style: normal;
               margin:0 0 0px 5px;
               text-decoration:none;

            }
            .my-app-status {
                    margin: 10px auto;
                    border: 1px solid #ccc;
                    padding: 14px 0px;
                    text-align: center;
                    background: #dfdfdf;
                    border: 1px solid #ccc;
            }
            .my-app-status li span{
                border:1px solid #ccc;
                padding: 8px 6px;
                font-size: 11px;
                background: #f4cd4c;
            }
             .my-app-status li:nth-last-child(1):after{
                 display:none !important;
             }
            .my-app-status li{
                margin: 10px 0;
                padding: 0;
             }
            .my-app-status li span.orange{
                background: orange;
                color: #fff;
            }
            .my-app-status li span.red{
                background: red;
                color: #fff;
            }
            .my-app-status li span.green{
                background: green;
                color: #fff;
            }
    </style>

     <script type="text/javascript">
         function ShowTermsAndCondition() {
             $("#btnModalTerms").click();
         }


         function PrintElem() {

             Popup($('#FinalPrint').html());
         }

         function Popup(data) {
             var mywindow = window.open('', 'my div', 'height=2000,width=1000');
             mywindow.document.write('<html><head><title style="font-weight:bold;">Evaluation Sheet</title>');
             mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/bootstrap.min.css\" type=\"text/css\" />');
             mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/theme.css\" type=\"text/css\"  />');
             mywindow.document.write('<link rel=\"stylesheet\" href=\"/css/print.css\" type=\"text/css\"  />');
             mywindow.document.write('</head><body >');
             mywindow.document.write(data);
             mywindow.document.write('</body></html>');

             setTimeout(function () {
                 mywindow.print();
                 mywindow.close();
             }, 1000);


             return true;
         }

     </script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
		<asp:UpdatePanel ID="upCrudGrid" runat="server" UpdateMode="Conditional">

			<ContentTemplate>
				<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCrudGrid">
					<ProgressTemplate>
						<div class="fgh">
							<div class="hgf">
								<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
							</div>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
        <asp:Button ID="btnPrint" runat="server" Text="Print" Style="margin: 6px 2px;" OnClientClick="PrintElem()" CssClass="btn-primary btn-sm ey-bg pull-right" />
            <div class="clearfix"></div>                           

        <div id="FinalPrint">
               
        <div class="panel panel-default" style="margin-left:24px;">
      
       <div class="text-center" style="font-weight:bolder;">Annexure I </div>
   
       <hr class="myhrline" />
   
       <div class="text-left" style="font-weight:bold;">Evaluation report as per “Uttar Pradesh Private Industrial Parks Policy”</div>
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
    <td><asp:Label ID="txtTotalArea"  runat="server" ></asp:Label></td>
    <td><asp:Label ID="txtTotalCoveredArea"  runat="server" ></asp:Label></td>
    <td><asp:Label ID="lblAreaComment"  runat="server"></asp:Label></td>
    <td><asp:Label ID="txtAreaComments"  runat="server"></asp:Label></td>
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
                              <td><asp:Label ID="txtLand"  runat="server" ></asp:Label></td>                         
                              <td rowspan="5"><asp:Label ID="txtInvestmentCompliance"  runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                              <td>2</td>
                              <td> Construction of Building Work </td>
                              <td><asp:Label runat="server" ID="lblBuildingWorks"></asp:Label></td>
                              <td><asp:Label ID="txtBuildingWorks"  runat="server" ></asp:Label></td>                              
                          </tr>
                           <tr>
                              <td>3</td>
                              <td> Infrastructure cost estimate </td>
                              <td><asp:Label runat="server" ID="lblCostEstimate" ></asp:Label></td>
                               <td><asp:Label ID="txtCostEstimate"  runat="server" ></asp:Label></td>
                              
                          </tr>
                           <tr>
                              <td>3.1</td>
                              <td>&emsp;Other Facilities </td>
                              <td><asp:Label runat="server" ID="lblOtherFacilities" ></asp:Label></td>
                               <td><asp:Label ID="txtOtherFacilities"  runat="server" ></asp:Label></td>
                             
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
                    <span class="font-12px" style="font-weight:bold;">2. Evaluation as per Annexure 1 of Private Industrial Parks Rules :</span>
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
                              <td><asp:Label ID="txtApplicantName"  runat="server"></asp:Label></td>                   
                              <td><asp:Label ID="txtApplicantNameRemarks"   runat="server" ></asp:Label></td>
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
                              <td><asp:Label ID="txtCompanyVerified"  runat="server"></asp:Label>
                                  <br /><asp:Label ID="txtCompanyAddressVerified"  runat="server" ></asp:Label>
                                  <br /><asp:Label ID="txtAuthorisedPersonVerified"  runat="server" ></asp:Label>
                                 <br /><asp:Label ID="txtAuthorisedPersonAddressVerified"  runat="server" ></asp:Label>
                              </td>
         
                              <td><asp:Label ID="txtAddressRemarks"  runat="server" ></asp:Label></td></tr>
                    <tr><td>2</td><td style="font-weight:bold;">Company Constitution</td>
                        <td><asp:Label runat="server" ID="lblCompanyConsitution" ></asp:Label></td>
                        <td><asp:Label ID="txtCompanyConstitutionVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtCompanyConstitutionRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>3</td><td style="font-weight:bold;">Project Location</td>
                        <td><asp:Label runat="server" ID="lblProjectLocation" ></asp:Label></td>
                        <td><asp:Label ID="txtProjectLocationVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtProjectLocationRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>4</td><td style="font-weight:bold;">Names of Directors/Promoter/Partners Name of the applicant </td>

                        <td><asp:Label runat="server" ID="lblNameofPromoters" ></asp:Label><br /><asp:Label runat="server" ID="lblConstitutionPeople"></asp:Label></td>
                        <td><asp:Label ID="txtNameofPromotersVerified"  runat="server"></asp:Label></td>
                        <td><asp:Label ID="txtNameofPromotersRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>5</td><td style="font-weight:bold;">GSTIN Number</td>
                        <td><asp:Label runat="server" ID="lblGSTINNumber" ></asp:Label></td>
                        <td><asp:Label ID="txtGSTINNumberVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtGSTINNumberRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>6</td><td> <span style="font-weight:bold;">Type of Project </span><br />New/Existing/Expansion/Diversified </td>
                        <td><asp:Label runat="server" ID="lblTypeofProject" ></asp:Label></td>
                        <td><asp:Label ID="txtTypeofProjectVerified"  runat="server"></asp:Label></td>
                        <td><asp:Label ID="txtTypeofProjectRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>7</td><td> <span style="font-weight:bold;">Category of project</span><br />a) Private Industrial Parks<br />b) Container Freight Station<br />c) Warehousing Facility<br />d) Cold Chain Facility </td>
                        <td>As per Private Industrial Parks Policy clause: 3.2.3 – <asp:Label runat="server" ID="lblCategoryProject" ></asp:Label></td>
                        <td><asp:Label ID="txtCategoryProjectVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtCategoryProjectRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                     <tr><td>8</td><td> <span style="font-weight:bold;">Registration/Permit for setting PIP Unit  </span></td>
                        <td><asp:Label runat="server" ID="lblRegistrationPermit" ></asp:Label></td>
                        <td><asp:Label ID="txtRegistrationPermitVerified"  runat="server"></asp:Label></td>
                        <td><asp:Label ID="txtRegistrationPermitRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>9</td><td> <span style="font-weight:bold;">Proposed date for setting up PIP unit  </span></td>
                        <td><asp:Label runat="server" ID="lblProposeddateforsettinguplogisticunit" ></asp:Label></td>
                        <td><asp:Label ID="txtProposeddateforsettinguplogisticunitVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtProposeddateforsettinguplogisticunitRemarks"  runat="server" ></asp:Label></td>
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
                        <td><asp:Label ID="txtProposedCapitalInvestmentVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtProposedCapitalInvestmentRemarks"  runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td>11</td><td> <span style="font-weight:bold;"> The date when capital investment has been started,or is proposed to be started </span></td>
                        <td><asp:Label runat="server" ID="lblinvestmentstarted" ></asp:Label></td>
                        <td><asp:Label ID="txtdatewhencapitalinvestmentstartedVerified"  runat="server" ></asp:Label></td>
                        <td><asp:Label ID="txtdatewhencapitalinvestmentstartedReamrks"  runat="server" ></asp:Label></td>
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
                              <td><asp:Label ID="txtTotalAmountrequestedVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtTotalAmountrequestedRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2</td>
                              <td style="font-weight:bold;"colspan="4" >Applicant Benefit Details </td>
                              
                           </tr> 
                            <tr>
                              <td >12.2.1</td>
                              <td style="font-weight:bold;" >Rebate on Stamp Duty</td>
                              <td><asp:Label runat="server" ID="lblRebateonStampDuty"></asp:Label> crore</td>
                              <td><asp:Label ID="txtRebateonStampDutyVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtRebateonStampDutyRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.2</td>
                              <td style="font-weight:bold;" >EPF Reimbursement (More than 100 unskilled workers) </td>
                              <td><asp:Label runat="server" ID="lblEPFReimbursement" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtEPFReimbursementVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtEPFReimbursementRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.3</td>
                              <td style="font-weight:bold;" >10% Additional EPF Reimbursement (200 skilled and unskilled workers)</td>
                              <td><asp:Label runat="server" ID="lblAdditionalEPFReimbursement"></asp:Label> crore</td>
                              <td><asp:Label ID="txtAdditionalEPFReimbursementVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtAdditionalEPFReimbursementRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.4</td>
                              <td style="font-weight:bold;" > Capital Interest Subsidy </td>
                              <td><asp:Label runat="server" ID="lblCapitalInterestSubsidy"></asp:Label> crore</td>
                              <td><asp:Label ID="txtCapitalInterestSubsidyVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtCapitalInterestSubsidyRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2.5</td>
                              <td style="font-weight:bold;" >Infrastructure Interest Subsidy</td>
                              <td><asp:Label runat="server" ID="lblInfrastructureInterestSubsidy" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtInfrastructureInterestSubsidyVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtInfrastructureInterestSubsidyRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2.6</td>
                              <td style="font-weight:bold;" >Rebate on Land use conversion charges </td>
                              <td><asp:Label runat="server" ID="lblRebateonLanduseconversioncharges" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtRebateonLanduseconversionchargesVerfied"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtRebateonLanduseconversionchargesRemarks"  runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.7</td>
                              <td style="font-weight:bold;" >Exemption from development charges</td>
                              <td><asp:Label runat="server" ID="lblExemptionfromdevelopmentcharges" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtExemptionfromdevelopmentchargesVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtExemptionfromdevelopmentchargesRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2.8</td>
                              <td style="font-weight:bold;" > Electricity Rebate </td>
                              <td><asp:Label runat="server" ID="lblElectricityRebate" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtElectricityRebateVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtElectricityRebateRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2.9</td>
                              <td style="font-weight:bold;" >Warehousing quality certification reimbursement </td>
                              <td><asp:Label runat="server" ID="lblWarehousingqualitycertificationreimbursement" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtWarehousingqualitycertificationreimbursementVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtWarehousingqualitycertificationreimbursementRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                          <tr>
                              <td >12.2.10</td>
                              <td style="font-weight:bold;" >500/- per month assistance for payroll of disabled workers </td>
                              <td><asp:Label runat="server" ID="lblpayrollofdisabledworkers" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtpayrollofdisabledworkersVerified"  runat="server"></asp:Label></td>                   
                              <td><asp:Label ID="txtpayrollofdisabledworkersRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.11</td>
                              <td style="font-weight:bold;" >Skill development promotion </td>
                              <td><asp:Label runat="server" ID="lblSkilldevelopmentpromotion" ></asp:Label> crore</td>
                              <td><asp:Label ID="txtSkilldevelopmentpromotionVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtSkilldevelopmentpromotionRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >12.2.12</td>
                              <td style="font-weight:bold;" >Intelligent Logistic Incentives </td>
                              <td><asp:Label runat="server" ID="lblIntelligentLogisticIncentives"></asp:Label> crore</td>
                              <td><asp:Label ID="txtIntelligentLogisticIncentivesVerified"  runat="server" ></asp:Label></td>                   
                              <td><asp:Label ID="txtIntelligentLogisticIncentivesRemarks"  runat="server" ></asp:Label></td>
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
           <asp:GridView ID="Grid_Comments" ViewStateMode="Enabled" CssClass="table table-striped table-responsive table-bordered table-hover request-table"  ShowHeaderWhenEmpty="true" runat="server"  AutoGenerateColumns="false">
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
																				                            <asp:Label ID="txtClauseasperPolicy_insert" CssClass="input-sm similar-select1" runat="server"></asp:Label>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField HeaderText="Description">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:Label ID="txtDescription_insert" runat="server" CssClass="input-sm similar-select1"></asp:Label>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField  HeaderText="Clause Description">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblClausedescription" runat="server" Text='<%#Eval("Clausedescription") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:Label ID="txtClausedescription_insert" CssClass="input-sm similar-select1" runat="server"></asp:Label>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Incentives Seek as per the proposal">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblIncentivesSeekaspertheproposal" runat="server" Text='<%#Eval("IncentivesSeekaspertheproposal") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:Label ID="txtIncentivesSeekaspertheproposal_insert" CssClass="input-sm similar-select1" runat="server" ></asp:Label>
																			                            </FooterTemplate>
																		                            </asp:TemplateField>
																		                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Benefit Eligibility">
																			                            <ItemTemplate>
																				                            <asp:Label ID="lblBenefitEligibility" runat="server" Text='<%#Eval("BenefitEligibility") %>'></asp:Label>
																			                            </ItemTemplate>
																			                            <FooterTemplate>
																				                            <asp:Label ID="txtBenefitEligibility_insert" CssClass="input-sm similar-select1" runat="server" ></asp:Label>
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
                              <td><asp:Label ID="txtRegistrationCertificateRemarks"  runat="server" ></asp:Label></td>
                              </tr>
                           <tr>
                              <td >B</td>
                              <td >List of Audited balance sheet with all annexures of current and last five financial years</td>
                              <td><asp:Label ID="txtAuditedbalancesheetRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >C</td>
                              <td >Detailed Project Report</td>
                              <td><asp:Label ID="txtDetailedProjectReportRemarks"  runat="server" ></asp:Label></td>
                              </tr>
                           <tr>
                              <td >D</td>
                              <td >CA certified MoA/Article of Association/By laws along 
                                    with CA certificate regarding applicant company/lead 
                                      member block of gross assets</td>
                              <td><asp:Label ID="txtMoARemarks"  runat="server" ></asp:Label></td>
                              </tr>
                           <tr>
                              <td >E</td>
                              <td >Chartered Engineer certificate of fixed assets status out of 
                                     gross block asset of applicant company/lead member</td>
                              <td><asp:Label ID="txtEngineercertificateRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                              <td >F</td>
                              <td >Affidavit</td>
                              <td><asp:Label ID="txtAffidavitRemarks"  runat="server" ></asp:Label></td>
                           </tr>
                   
                      </tbody></table>
           </div>
            <div>
															                          
														                            </div>
       </div>
      
    </div></div>
         </ContentTemplate></asp:UpdatePanel>
        
    </form>
</body>
</html>
