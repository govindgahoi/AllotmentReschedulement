using System;

namespace BEL_Allotment
{
    public class belBookDetails
    {
        public string SharePer { get; set; }
    public string Phone { get; set; }

    public int subdivision_serviceid { get; set; }

    public string subdivision_TypeOfApplication { get; set; }
    public decimal AmalgamatedArea { get; set; }

    #region " Land Acquisition Regisrtration"
    public decimal PrivateLand { get; set; }
    public decimal GSLand { get; set; }
    public decimal CeilingLand { get; set; }
    public decimal ForestLand { get; set; }
    public decimal OtherArea { get; set; }
    public decimal NoofPuccaDrains { get; set; }
    public decimal Areaofgroveslands { get; set; }
    public decimal NoofTubewells { get; set; }
    public decimal NoofPuccaBuildings { get; set; }
    public decimal NosofWorshipPlaces { get; set; }
    public decimal NosofTrees { get; set; }
    public string Other { get; set; }
    public string anyOther { get; set; }
    public string BuildingCostforConstruction { get; set; }
    public string CapitalSubsidy { get; set; }

    public string SelectSubsidyFront { get; set; }

    public string SelectSubsidyBack { get; set; }
    public int PossessionID { get; set; }
    public int ResumptionOrderID { get; set; }
    public int VillageID { get; set; }
    public string TypeofLand { get; set; }
    public decimal Area { get; set; }
    public string NoofProposals { get; set; }
    public DateTime? DateofProposals { get; set; }
    public string NotificationNo { get; set; }
    public decimal NotificationArea { get; set; }
    public int PossessionVillage { get; set; }
    public int AwardsVillageID { get; set; }
    public decimal AwardedArea { get; set; }
    public decimal AwardedAmount { get; set; }
    public DateTime? DateofAwards { get; set; }
    public int AwardID { get; set; }
    public int ConveyenceDeedVillageID { get; set; }
    public decimal ConveyenceArea { get; set; }
    public string Registration { get; set; }
    public string Initial { get; set; }
    public string ConRemarks { get; set; }
    public int ConveyenceID { get; set; }
    public string Details { get; set; }
    public string DraftNo { get; set; }
    public DateTime DraftDate { get; set; }
    public decimal PaymentTotalAmount { get; set; }
    public int PaymentsID { get; set; }
    public int CompansationVillageID { get; set; }
    public decimal CompansationAmount { get; set; }
    public int CompansationID { get; set; }
    public int CourtType { get; set; }
    public string CaseName { get; set; }
    public string PartyName { get; set; }
    public string Lawyer { get; set; }
    public int LitigationID { get; set; }
    public int LandIDs { get; set; }
    public int LAPaymentID { get; set; }
    public int DistbursementID { get; set; }
    public decimal GeneralLand { get; set; }
    public decimal PublicUtility { get; set; }
    #endregion

    #region "Logistic & Warehousing"

    public string MControlID { get; set; }
    public string MUnitId { get; set; }
    public string MServiceId { get; set; }
    public string MRequestID { get; set; }
    public string DescriptionLAW { get; set; }
    public string ClauseasperPolicy { get; set; }
    public string Clausedescription { get; set; }
    public string IncentivesSeekaspertheproposal { get; set; }
    public string BenefitEligibility { get; set; }
    public string VerifiedArea { get; set; }
    public string VerifiedCoveredArea { get; set; }
    public string Compliance3_2_3 { get; set; }
    public string Commment3_2_3 { get; set; }
    public string Investment_Land { get; set; }
    public string Investment_BuildingWorks { get; set; }
    public string Investment_Infrastructure { get; set; }
    public string Investment_OtherFacilities { get; set; }
    public string Investment_Compliance { get; set; }
    public string ApplicantNameVerified { get; set; }
    public string ApplicantName_Remarks { get; set; }
    public string CompanyNameVerified { get; set; }
    public string CompanyAddressVerified { get; set; }
    public string AuthorisedUserVerified { get; set; }
    public string AuthorisedUserAddressVerified { get; set; }
    public string Address_Remarks { get; set; }
    public string CompanyConstitutionVerified { get; set; }
    public string CompanyConstitution_Remarks { get; set; }
    public string ProjectLocationVerified { get; set; }

    public string ProjectLocationRemarks { get; set; }
    public string NamesofPromotersVerified { get; set; }
    public string NameofPromoters_Remarks { get; set; }
    public string GSTIN_NumberVerified { get; set; }
    public string GSTIN_Number_Remarks { get; set; }
    public string Type_of_ProjectVerified { get; set; }
    public string Type_of_Project_Remarks { get; set; }
    public string Category_of_projectVerified { get; set; }
    public string Category_of_project_Remarks { get; set; }
    public string RegistrationPermit_for_setting_LogisticVerified { get; set; }
    public string RegistrationPermit_for_setting_Logistic_Remarks { get; set; }
    public string Proposed_date_for_setting_up_logistic_unitVerified { get; set; }
    public string Proposed_date_for_setting_up_logistic_unit_Remarks { get; set; }
    public string ProposedCapitalInvestmentVerified { get; set; }
    public string ProposedCapitalInvestment_Remarks { get; set; }
    public string date_capital_investment_startedVerified { get; set; }
    public string date_capital_investment_started_Remarks { get; set; }
    public string Total_Amount_by_ApplicantVerified { get; set; }
    public string Total_Amount_by_Applicant_Remarks { get; set; }
    public string RebateonStampDutyVerified { get; set; }
    public string RebateonStampDuty_Remarks { get; set; }
    public string EPFReimbursementVerified { get; set; }
    public string EPFReimbursement_Remarks { get; set; }
    public string Additional_EPF_ReimbursementVerified { get; set; }
    public string Additional_EPF_Reimbursement_Remarks { get; set; }
    public string Capital_Interest_SubsidyVerified { get; set; }
    public string Capital_Interest_Subsidy_Remarks { get; set; }
    public string InfrastructureInterestSubsidyVerified { get; set; }
    public string InfrastructureInterestSubsidy_Remarks { get; set; }
    public string RebateonLanduseconversionchargesVerified { get; set; }
    public string RebateonLanduseconversioncharges_Remarks { get; set; }
    public string ExemptionfromdevelopmentchargesVerified { get; set; }
    public string Exemptionfromdevelopmentcharges_Remarks { get; set; }
    public string ElectricityRebateVerified { get; set; }
    public string ElectricityRebate_Remarks { get; set; }
    public string WarehousingqualitycertificationreimbursementVerified { get; set; }
    public string Warehousingqualitycertificationreimbursement_remarks { get; set; }
    public string monthassistanceforpayrollofdisabledworkersVerified { get; set; }
    public string monthassistanceforpayrollofdisabledworkers_Remarks { get; set; }
    public string SkilldevelopmentpromotionVerified { get; set; }
    public string Skilldevelopmentpromotion_Remarks { get; set; }
    public string IntelligentLogisticIncentivesVerified { get; set; }
    public string IntelligentLogisticIncentives_Remarks { get; set; }
    public string Compliance_1 { get; set; }
    public string Compliance_2 { get; set; }
    public string Compliance_3 { get; set; }
    public string Compliance_4 { get; set; }
    public string Compliance_5 { get; set; }
    public string Compliance_6 { get; set; }
    public string ProposedArea { get; set; }
    public string CompanyAddress { get; set; }
    public object KYCID;
    public string IsSPV { get; set; }

    public string ProposedCoveredArea { get; set; }
    public string LAWRegistrationNo { get; set; }
    public DateTime? LandDeedDate { get; set; }
    public string LandArea { get; set; }
    public string KhasraNumber { get; set; }
    public string LandValue { get; set; }
    public string StampDutyPaid { get; set; }
    public string LAWDistrict { get; set; }
    public string LAWTehsil { get; set; }
    public string LAWVillage { get; set; }
    public string LAWID { get; set; }
    public string LAWLandID { get; set; }
    public string TypeOfProject { get; set; }
    public string CategoryOfProject { get; set; }
    public string ProposedInvestment { get; set; }
    public DateTime? Proposeddateforsettinguplogisticunit { get; set; }
    public DateTime? datewhencapitalinvestmentstarted { get; set; }
    public string CostoftheLand { get; set; }
    public string CostofInfrastructures { get; set; }
    public string CostofthePlantMachinery { get; set; }
    public string OtherCost { get; set; }
    public string TotalAmountrequestedbyApplicant { get; set; }
    public string RebateonStampDuty { get; set; }
    public string EPFReimbursement { get; set; }
    public string AdditionalEPFReimbursement { get; set; }
    public string CapitalInterestSubsidy { get; set; }
    public string InfrastructureInterestSubsidy { get; set; }
    public string RebateonLanduseconversioncharges { get; set; }
    public string Exemptionfromdevelopmentcharges { get; set; }
    public string ElectricityRebate { get; set; }
    public string Warehousingqualitycertificationreimbursement { get; set; }
    public string assistanceforpayrollofdisabledworkers { get; set; }
    public string Skilldevelopmentpromotion { get; set; }
    public string IntelligentLogisticIncentives { get; set; }
    public string LAWDocPath { get; set; }

    public string IsRegionPIP { get; set; }
    public string ProposedPIP { get; set; }
    public string DateofCompletion { get; set; }
    public string DistanceFromRailway { get; set; }
    public string ProposedDirectEmployment { get; set; }
    public string DistanceFromBus { get; set; }
    public string ProposedIndirectEmployment { get; set; }
    public string DistanceFromAirport { get; set; }
    public string ExemptionOnStamp { get; set; }
    public string SubsidyFixedCapitalInvestment { get; set; }
    public string SubsidyHostelDormitory { get; set; }
    public string PIPOtherDetails { get; set; }
    public string PIPRegistrationNo { get; set; }

    public string anyOtherExistingProject { get; set; }

    #endregion

    public string FreeStatus { get; set; }
    #region "MiS Investment"

    public DateTime? FromDatetime { get; set; }
    public DateTime? ToDatetime { get; set; }
    #endregion
    public string HSProductCategory { get; set; }
    public string HSProductSubCategory { get; set; }
    public string HSProductName { get; set; }
    #region "MD Appointment"
    public TimeSpan AppointmentTime;
    #endregion

        #region "Track Application"

        public Int32 LTID { get; set; }
        public string LtApplicationType { get; set; }
        public string LtSubject { get; set; }
        public DateTime? LtIssuedDate { get; set; }
        public string LtLetterNo { get; set; }
        public string LtForwardedTo { get; set; }
        public string LtRemark { get; set; }
        //public string PublicPrivate { get; set; }
        public string LtServiceRequestNo { get; set; }


        public string LtFilePath { get; set; }
        public DateTime? LGrivenceRDate { get; set; }

        //public string OfficeOrderID { get; set; }

        #endregion

        #region "Office Order Master"
        public string OrderRefNo { get; set; }
        public string SubjectOrder { get; set; }
        public string IssuedBy { get; set; }
        public string Description { get; set; }
        public string PublicPrivate { get; set; }
        public string Section { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string OrderFilePath { get; set; }
        public string OfficeOrderID { get; set; }

        #endregion
        #region "Facility Master"
        public string FacilityPlotNo { get; set; }
        public string FacilityName { get; set; }
        public string FacilityDesc { get; set; }
        public string FacilityUniqueID { get; set; }
        public int FacilityType { get; set; }
        public string FacilityCapacity { get; set; }
        public string FacilityID { get; set; }

        public string NorthID { get; set; }
        public string SouthID { get; set; }
        public string EastID { get; set; }
        public string WestID { get; set; }



        #endregion

  
      
        #region  IAMaster
        public int SubDistict { get; set; }
        public string TypeofindustrialArea { get; set; }
        public string MixedSector { get; set; }

        public string parksd { get; set; }
        public string SubSector { get; set; }
        public string NHighway { get; set; }
        public string DistNH { get; set; }
        public string SHighway { get; set; }
        public string DistSH { get; set; }
        public string RStation { get; set; }
        public string DistRS { get; set; }
        public string Airport { get; set; }
        public string DistAir { get; set; }
        public string Seaport { get; set; }
        public string Distport { get; set; }
        public string DryPort { get; set; }
        public string Distdryport { get; set; }
        public string DistRailS { get; set; }
        public string Zonal { get; set; }
        public string DistZonal { get; set; }
        public string PoliceSt { get; set; }
        public string DistPolice { get; set; }
        public string FireSt { get; set; }
        public string DistFire { get; set; }
        public string Bank { get; set; }
        public string DistBank { get; set; }
        public string Hospital { get; set; }
        public string DistHosp { get; set; }
        public string ElectA { get; set; }
        public string ElectC { get; set; }
        public string ElectU { get; set; }
        public string WaterA { get; set; }
        public string WaterC { get; set; }
        public string WaterU { get; set; }
        public string GasLine { get; set; }
        public string GasC { get; set; }
        public string GasU { get; set; }
        public string STP { get; set; }
        public string STPC { get; set; }
        public string STPU { get; set; }
        public string EPoleA { get; set; }
        public string PowerSSA { get; set; }
        public string PowerSSC { get; set; }
        public string PowerSSU { get; set; }
        public string WTP { get; set; }
        public string WTPC { get; set; }
        public string WTPU { get; set; }
        public string ICT { get; set; }
        public string ICTS { get; set; }
        public string SWDA { get; set; }
        public string SWDC { get; set; }
        public string SWDU { get; set; }
        public string DhA { get; set; }
        public string PtA { get; set; }
        public string OtherInformation { get; set; }
        public string EnvtClOb { get; set; }
        public string Village { get; set; }
        public string TruckparkingCapecity { get; set; }
        public string DormitoriesCapecity { get; set; }
        public string ApprovalReffno { get; set; }
        #endregion

        #region "Transfer Of Plot"
        public string TLLevyType { get; set; }
        public string TLCaseType { get; set; }
        public string HOApproval { get; set; }
        public DateTime? DeathDate { get; set; }

        public DateTime? SubdivisionDate { get; set; }
        public string UnitUnderProductionStatus { get; set; }
        public string UnitUnderProductionMoreThenTwoYearStatus { get; set; }
        public string CoveredAreaTransfer { get; set; }
        public string TLExemption { get; set; }
        public string TLExemptionCase { get; set; }
        public string TLExemptionCaseName { get; set; }

        public string TLCaseName { get; set; }


        #endregion
        #region by manish Rastogi  "Reconsititution"
        public string AllotteeName { get; set; }
        public string PhoneNo { get; set; }
        public string NewAllottedID { get; set; }

        #endregion
        #region "waterConnection"
        public int TypeofConnection { get; set; }
        public string Waterrequirement { get; set; }
        public string WaterMeterSize { get; set; }
        #endregion

        #region New Service
        public string ProductionstartDate { get; set; }
        public string ApplicationPlotCancelationDescription { get; set; }
        #endregion
        public string ApplicationSurrenderofPlotDescription { get; set; }
        public string ApplicationAdditionalUnitDescription { get; set; }

        public string ApplicationRestorationofplotDescription;

        public DateTime buildingDate;

        public DateTime ProductionDate { get; set; }

        public decimal Restorationlevypercentage { get; set; }

        public string ApplicationSublettingDescription { get; set; }

        #region Subletting
        public decimal presentrates;
        public decimal totalSublettingCharge;
        public DateTime leasedeeddate;
        public int SublettingYear { get; set; }
        public decimal SubLettingCharges { get; set; }

        #endregion

        #region "change In BP"
        public string MalbaPaid { get; set; }
        public string InfraPaid { get; set; }
        public string BPCaseType { get; set; }
        public int BPType { get; set; }
        public string AreaStatus { get; set; }
        public string PrevAppCoveredArea { get; set; }
        #endregion

        #region"QPR"
        public int QPRLandtype { get; set; }

        public int QuarterEndDate { get; set; }
        public int QPRyear { get; set; }
        public int AllotedLandunit { get; set; }
        public int AllotedLandPlot { get; set; }
        public decimal AllotedLandArea { get; set; }
        public int TotalLandforAllotmentPlots { get; set; }
        public decimal TotalLandforAllotmentArea { get; set; }
        public int LandNotAvlDueToLitigationPlot { get; set; }
        public decimal LandNotAvlDueToLitigationArea { get; set; }
        public int BalLandForAllotmentPlot { get; set; }
        public decimal BalLandForAllotmentArea { get; set; }
        public int UnderConstructionUnit { get; set; }
        public decimal UnderConstructionArea { get; set; }
        public int ConstructedFunctionalUnit { get; set; }
        public decimal ConstructedFunctionalArea { get; set; }
        public int SickClosedUnit { get; set; }
        public decimal SickClosedArea { get; set; }
        public int NotStartedEvenconstructionUnit { get; set; }
        public decimal NotStartedEvenconstructionArea { get; set; }
        public int QPRCategory { get; set; }
        public int QPRID { get; set; }
        #endregion
        #region "LandAcquisitionProposalfromLandOwner"

        public string LANameOfLandOwner { get; set; }
        public string LAMobileNo { get; set; }
        public string LAEmail { get; set; }
        public int LADistrictID { get; set; }
        public string LASubDistrict { get; set; }
        public int LAlandownerType { get; set; }
        public int LAlandType { get; set; }
        public string LAName { get; set; }
        public string LAContentType { get; set; }
        public byte[] LADocumentsMap { get; set; }
        public string LASignedConsentlatterName { get; set; }
        public string LASignedConsentlatterContentType { get; set; }
        public byte[] LASignedConsentlatterDocumentsMap { get; set; }
        public string LATotalLand { get; set; }
        public int LARoadConnectivity { get; set; }
        public string LARoadwidth { get; set; }
        public string LADistancefromnearestexpressway { get; set; }
        public string LANearestRailwayStationName { get; set; }
        public string LADistancefromnearestRailwayStation { get; set; }
        public int LAsurcefreshwater { get; set; }
        public string LAdepthofsourcewater { get; set; }
        public string LACirclerateperhectare { get; set; }
        public string LAProposeofferedrateperhectare { get; set; }
        public int LAalllandowners { get; set; }
        #endregion
        #region "LandAssessment"
        public int LandDistrictID { get; set; }
        public string LandSubDistrict { get; set; }
        //public string LandAssessmentRequestNO { get; set; }
        public string LandNameofInvestor { get; set; }
        public string LandAddressDetails { get; set; }
        public int LandCountry { get; set; }
        public int LandState { get; set; }
        public string LandCity { get; set; }
        public string LandMobileNo { get; set; }
        public string LandMail { get; set; }
        public string LandAddressofPresentunit { get; set; }
        public string LandAnnualTurnover { get; set; }
        public string LandPlotareaofunit { get; set; }
        public string LandFSIConsumed { get; set; }
        public string LandWaterConsumed { get; set; }
        public string LandEmploymentGenerated { get; set; }
        public string LandRemarks { get; set; }
        public string LandNatureofProject { get; set; }
        public string LandRawMaterial { get; set; }
        public string LandParposedProduct { get; set; }
        public string LandFinanceAgreement { get; set; }
        public string LandTotalProjectCost { get; set; }
        public string LandBuiltupArea { get; set; }
        public string LandWaterrequirement { get; set; }
        public string LandTotalNoofEmployees { get; set; }
        public string LandIndustryType { get; set; }
        public string LandManufacturingActivity { get; set; }
        public string LandPreferredLocation { get; set; }
        public string LandRequiredLandSize { get; set; }

        #endregion

        #region"POA"
        public int PID { get; set; }
        public string POAName { get; set; }
        public string POAEmailID { get; set; }
        public string POAMobileNo { get; set; }
        public string POARegion { get; set; }
        public int POAIAID { get; set; }
        public byte[] POAPhoto { get; set; }
        public string POAPhotoContent { get; set; }
        public string POAPhotoName { get; set; }
        public byte[] POASign { get; set; }
        public string POASignContent { get; set; }
        public string POASignName { get; set; }
        #endregion



        #region "RoadMaster"
        public string RoadNo { get; set; }
        public string RoadWidth { get; set; }
        public string RoadLength { get; set; }
        public string Row { get; set; }
        public string RoadType { get; set; }
        public string Median { get; set; }
        public string MedianWidth { get; set; }
        public string GreenBelt { get; set; }
        public string StreetLight { get; set; }
        public string NoOfStreetLight { get; set; }
        public string StormWaterDrainage { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime RetirementDate { get; set; }
        public string FootPath { get; set; }
        public string CycleTrack { get; set; }
        public string RoadBegPoint { get; set; }
        public string RoadEndPoint { get; set; }
        public string IndustrialDrainage { get; set; }
        #endregion


        #region AllotteeMasterPlotNumberUpdate
        public string PlotUniqueID;
        public string MasterPlotNumber;

        #endregion

        #region IndustrialAreaMaster

        public string IACategory;
        public int pollutionCategory;
        public decimal TotalLandAcquired { get; set; }
        public decimal TotIALandForAllotment { get; set; }
        public int TotIAPlotsForAllotment { get; set; }
        public decimal IARatePerSqmt { get; set; }
        public decimal TotResLandForAllotment { get; set; }
        public int TotResPlotForAllotment { get; set; }
        public decimal ResRatePerSqmt { get; set; }
        public decimal TotCommLandForAllotment { get; set; }
        public int TotCommPlotsForAllotment { get; set; }
        public decimal CommRatePerSqmt { get; set; }
        public decimal TotInstLandForAllotment { get; set; }
        public int TotInstPlotsForAllotment { get; set; }
        public decimal InstRatePerSqmt { get; set; }
        public decimal LandForFacilities { get; set; }
        public decimal LandForRoad { get; set; }
        public decimal LandUnderGreenBelt { get; set; }
        public decimal LandForPark { get; set; }
        public decimal BulkLand { get; set; }
        public decimal OtherLandArea { get; set; }
        public string IndustriesAllowed { get; set; }
        public string FacilitiesAvailable { get; set; }
        public string OtherLandDesc { get; set; }
        public int PollutionCategory { get; set; }
        public int Distict { get; set; }
        #endregion


        #region AccountClearence
        public int ticketID { get; set; }
        public string SWCControlId { get; set; }
        public string SWCUnitId { get; set; }
        public string SWCRequestID { get; set; }
        public string SWCServiceId { get; set; }
        public string SWCProcessIndustryId { get; set; }
        public string SWCApplicationId { get; set; }
        public decimal SWCFeeAmount { get; set; }
        public string SWCFeeStatus { get; set; }
        public string SWCTransactionId { get; set; }
        public string SWCTransactionDate { get; set; }
        public string SWCTransactionTime { get; set; }
        public string SWCTransactionDatetime { get; set; }
        public string SWCStatusCode { get; set; }
        public string SWCRemarks { get; set; }
        public string upsidcAmtCreditConfirmation { get; set; }
        public string modeofPaymentConfirmation { get; set; }
        public string gateway { get; set; }
        public string OnlineOffline { get; set; }
        public string TransDateConfirmation { get; set; }
        public string PaymethodConfirmation { get; set; }
        public string TransID { get; set; }
        public decimal TransAmountConfirmation { get; set; }
        public string TransrefnoConfirmation { get; set; }
        public decimal amtreceivedConfirmation { get; set; }
        public int CurrentStatus { get; set; }

        #endregion

        #region Tickets

        public string UsepermisesCode { get; set; }
        public string Permissibility { get; set; }
        #endregion

        #region "ticketpackets"
        public int packetID { get; set; }
        public int operationID { get; set; }
        public string ticketDescription { get; set; }
        #endregion


        #region "allotmentParamters"

        public double choicearea { get; set; }
        public double choiceareap1 { get; set; }
        public double choiceareap2 { get; set; }
        public double choiceareap3 { get; set; }
        public string choiceP1 { get; set; }
        public string choiceP2 { get; set; }
        public string choiceP3 { get; set; }
        public string companyName { get; set; }
        public string swcApplicantName { get; set; }
        public string applicantAddress { get; set; }
        public string SWCControlID { get; set; }
        public string SWCUnitID { get; set; }
        public string SWCServiceID { get; set; }
        public string SWCStatus { get; set; }
        public string SWCPayMode { get; set; }
        public byte[] ApplicantImageByte { get; set; }
        public string ApplicantImageName { get; set; }
        public string ImageContent { get; set; }
        public byte[] ApplicationForm { get; set; }
        public string FormName { get; set; }
        public string FormContent { get; set; }
        public decimal NiveshMitraAmt { get; set; }
        #endregion


        #region "ShareHolderPattern"
        public string ShareHolderName { get; set; }
        public string ShareHolderAddress { get; set; }
        public string ShareHolderPhone { get; set; }
        public string ShareHolderEmail { get; set; }
        public decimal ShareHolderPer { get; set; }


        public string DirectorName { get; set; }
        public string DirectorAddress { get; set; }
        public string DirectorPhone { get; set; }
        public string DirectorEmail { get; set; }
        public string DirectorDinPan { get; set; }

        public string TrusteeName { get; set; }
        public string TrusteeAddress { get; set; }
        public string TrusteePhone { get; set; }
        public string TrusteeEmail { get; set; }


        public string PartnerName { get; set; }
        public string PartnerAddress { get; set; }
        public string PartnerPhone { get; set; }
        public string PartnerEmail { get; set; }
        public decimal PartnerPer { get; set; }


        #endregion

        #region "PayeeDetails"
        public string PayeeName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string PayeeBankName { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }

        #endregion
        #region "Applicant Project Details"

        public string IndustryType { get; set; }
        public decimal EstimatedCostOfProject { get; set; }
        public string EstimatedEmploymentGeneration { get; set; }
        public string CoveredArea { get; set; }
        public string OpenAreaRequired { get; set; }
        public string LandDetails { get; set; }
        public string BuildingDetails { get; set; }
        public string MachineryEquipmentsDetails { get; set; }
        public string IndustrialEffluentSolidqty { get; set; }
        public string IndustrialEffluentSolidComposition { get; set; }
        public string IndustrialEffluentLiquidqty { get; set; }
        public string IndustrialEffluentLiquidComposition { get; set; }
        public string IndustrialEffluentGaseousqty { get; set; }
        public string IndustrialEffluentGaseousComposition { get; set; }
        public string FumeGenerationStatus { get; set; }
        public string FumeQuantity { get; set; }
        public string FumeNature { get; set; }
        public string EffluentTreatmentMeasure1 { get; set; }
        public string EffluentTreatmentMeasure2 { get; set; }
        public string EffluentTreatmentMeasure3 { get; set; }
        public string PowerReqInKW { get; set; }
        public string TelephoneReqFirstYear1 { get; set; }
        public string TelephoneReqFirstYear2 { get; set; }
        public string TelephoneReqUltimate1 { get; set; }
        public string TelephoneReqUltimate2 { get; set; }
        public string ApplicantPriorityStatus { get; set; }
        public string ApplicantPrioritySpecification { get; set; }
        public string OtherFixedAssets { get; set; }
        public string OtherExpenses { get; set; }
        public string projectstartmonths { get; set; }
        public string workexperience { get; set; }
        public string NetTurnOver { get; set; }
        public string Networth { get; set; }
        public string ExpansionOfLand { get; set; }
        public string ExportOriented { get; set; }
        public int IAType { get; set; }
        public string EtpRequired { get; set; }
        public string ExistingPlotNo { get; set; }
        public DateTime? AllotmentDate { get; set; }
        public string ExistingAllotteeName { get; set; }
        public int IAcategory { get; set; }



        #endregion

        #region "PlotMasterParameter"
     
        public int LandUse { get; set; }
        public int Category { get; set; }
        public int PlotStatus { get; set; }
        public int PlotSubStatus { get; set; }
        public int PremisesUse { get; set; }
        public int ApplicableLocCharge { get; set; }
        public int LockStatus { get; set; }
        public string FrontSide { get; set; }
        public string BackSide { get; set; }
        public string Side1 { get; set; }
        public string Side2 { get; set; }
        public string PlotRemark { get; set; }
        public string AssetDesc { get; set; }
        public string AssetValue { get; set; }
        public string AssetStatus { get; set; }
        #endregion

        #region "UpcomingIndustrialArea"
        public string NameofScheme { get; set; }
        public string Location { get; set; }
        public string SponsorAgency { get; set; }
        public string NumberofArea { get; set; }
        public string ProjectDetail { get; set; }
        public string Developed { get; set; }
        public string LandStatus { get; set; }
        public string WebURL { get; set; }
        public string RequestReportCondition { get; set; }
        public float RequestReportConditionVal { get; set; }
        public string CorporationID { get; set; }
        #endregion


        #region "UpcomingIndustrialArea"

        public string ProjectIdentification { get; set; }
        public string NameClearance { get; set; }
        public DateTime DateOfClearance { get; set; }
        public string DetailsOfIncentive { get; set; }
        public string PresentImplementStatsu { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string CapitaloftheLandDPR { get; set; }
        public string CapitaloftheLandAEI { get; set; }
        public string CapitaloftheBuildingDPR { get; set; }
        public string CapitaloftheBuildingAEI { get; set; }
        public string CapitalofthePlantMachineryDPR { get; set; }
        public string CapitalofthePlantMachineryAEI { get; set; }
        public string OtherCapitalDPR { get; set; }
        public string OtherCapitalAEI { get; set; }
        public string TotalCapitalDPR { get; set; }
        public string TotalCapitalAEI { get; set; }
        public string MeanOfFinance { get; set; }
        public string Reason { get; set; }
        public string WantToMigrate { get; set; }
        public string Place { get; set; }

        public DateTime Dates { get; set; }

        #endregion

        public string ExistingLand { get; set; }

        public string LandContiguousStatus { get; set; }
        public string LandContiguous { get; set; }

        public string GramGovStatus { get; set; }

        public string GramGov { get; set; }

        public string LandExchangeStatus { get; set; }

        public string LandExchange { get; set; }
        public string Doctype { get; set; }
        public string Flag { get; set; }
        public string OTP { get; set; }
        public string OTPFor { get; set; }
        public string CaseID { get; set; }
        public string ReferenceNumber { get; set; }
        public string CaseStatus { get; set; }
        public string Weare { get; set; }
        public string LtPartyName { get; set; }
        public string Jurisdiction { get; set; }
        public string CourtDetails { get; set; }
        public string InCourtof { get; set; }
        public string MatterDetails { get; set; }
        public string LitigatingParty { get; set; }
        public string PetAdvocateName { get; set; }
        public string PetAddress { get; set; }
        public string PetContactNo { get; set; }
        public string ResAdvocateName { get; set; }
        public string ResAddress { get; set; }
        public string legalcase { get; set; }
        public string ResContact { get; set; }
        public string GSTStatus { get; set; }
        public DateTime GSTDate { get; set; }
        public string KYAdoc { get; set; }
        public string plotSize;
        public string searchText;
        public int UserID;
        public int PlotID;
        public int CancellationGround;
        public int RegulationID;
        public decimal PlotArea;
        public object SectorID;
        public string TransferFrom;
        public string TransferTo;
        public string RecStatus;
        public string Comments;
        public int MainAllotteeID;
        public string FromUser { get; set; }

        #region "Engineering"
        public string JobNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CBNO { get; set; }
        public DateTime ExDate { get; set; }
        public decimal ExAmount { get; set; }
        public string AgencyName { get; set; }
        public string Statusofwork { get; set; }
        public string Statusofwork1 { get; set; }
        public string PaymentDate { get; set; }
        public decimal AreaDeveloped { get; set; }
        public int ConstructionID { get; set; }
        public string ConstructionName { get; set; }
        public string Remark { get; set; }
        public string GrossWork { get; set; }
        public string Nameofwork { get; set; }
        public string CDID { get; set; }
        public string Financialyear { get; set; }


        #endregion
        #region "PlotsVacantDetail"
        public int TotalVacantPlots { get; set; }
        public int VacantID { get; set; }
        public string VacantType { get; set; }
        public string CorporationName { get; set; }
        #endregion
        #region "ProductionDetail"
        public string NameofUnit { get; set; }
        public string NameofOwner { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Companyid { get; set; }

        #endregion
        #region "LandAcquistionDetail"
        public decimal GSLandNew { get; set; }
        public decimal GovtLandNew { get; set; }
        public decimal TotalAreaNew { get; set; }
        public decimal PrivateacquisitionLand { get; set; }
        public DateTime NotificationDate { get; set; }
        public decimal AwardArea { get; set; }
        public DateTime AwardDate { get; set; }
        public decimal PossessionArea { get; set; }
        public DateTime PossessionDate { get; set; }
        public decimal ExpenditureofLA { get; set; }
        #endregion



        #region "Digitization"
        public string NameofSection { get; set; }
        public int TotalNumberoffile { get; set; }
        public int DocumentA4 { get; set; }
        public int DocumentLegal { get; set; }
        public int DocumentA0 { get; set; }
        public int DocumentA1 { get; set; }
        public int DocumentA3 { get; set; }
        public int other { get; set; }
        public string BookMarks { get; set; }
        public string Maintenance { get; set; }
        #endregion

        public byte[] pdf { get; set; }
        public byte[] UploadAllotmentLetter { get; set; }
        public byte[] ArchitectFile { get; set; }
        public byte[] UploadLeaseDeed { get; set; }
        public byte[] Uploadfile { get; set; }
        public string LeaseDeedVersion { get; set; }
        public byte[] InspectionLetter { get; set; }
        public byte[] BuildingPlanDocument { get; set; }
        public byte[] CompletionCertificate { get; set; }
        public byte[] OccupancyCertificate { get; set; }
        public string AllotmentletterVersion { get; set; }
        public string AllotmentLetterFile { get; set; }
        public string AllotmentLetterExt { get; set; }
        public string BuildingPlanDocumentExt { get; set; }
        public string CompletionCertificateExt { get; set; }
        public string OccupancyCertificateExt { get; set; }
        public string InsepectionfilenameExt { get; set; }
        public string LeaseDeedFile { get; set; }
        public DateTime? AllotmentIssueDate { get; set; }
        public DateTime? BuldingPlanSubmissionDate { get; set; }
        public DateTime? LeaseDeedDate { get; set; }
        public DateTime? LeaseAgrementExecDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? ReleaseofCompletionDate { get; set; }
        public DateTime? RequestofOccupancyCertificateDate { get; set; }
        public DateTime? ReleaseofOccupancyCertificateDate { get; set; }
        public string LeaseDeedExt { get; set; }
        public string DocumentName { get; set; }
        public string SearchRecord { get; set; }
        public int dbId { get; set; }
        public int Action { get; set; }
        public int IAId { get; set; }
        public string RegionalOffice { get; set; }
        public string RegionName { get; set; }
        public string PlotNo { get; set; }
        //public string AllotmentNo { get; set; }
        public string Allotteename { get; set; }
        public string TypeofInspection { get; set; }
        public string filename { get; set; }
        public DateTime InspectionDate { get; set; }
        public string IAName { get; set; }
        public int IsActive { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        public string Roll { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string IPAddress { get; set; }
        public string responseMessage { get; set; }

        public string content { get; set; }

        public int ServiceTimeLinesID { get; set; }
        public string ServiceTimeLinesDepartMent { get; set; }
        public string ServiceTimeLinesActivity { get; set; }
        public string ServiceTimeLines { get; set; }
        public string ServiceTimeLinesHOLevel { get; set; }
        public string ServiceTimeLinesApprovingLevel { get; set; }

        public string OrderCategory { get; set; }
        public string ServiceChecklistId { get; set; }



        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int ServiceCheckListsID { get; set; }
        public string ServiceTimeLinesCondition { get; set; }
        public string ServiceTimeLinesDocuments { get; set; }

        public string RequestorPhone { get; set; }
        public string RequestorEmailID { get; set; }
        public string RequestPurpose { get; set; }
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string RequestReportType { get; set; }
        public string ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationAdress1 { get; set; }
        public string ApplicationAdress2 { get; set; }
        public string Remarks { get; set; }
        public float ToatalPlotedArea { get; set; }

        public string ApplicationType { get; set; }
        public string CaseType { get; set; }
        public string IndustrialArea { get; set; }
        public string ServiceRequest { get; set; }

        public string SurveyNo { get; set; }
        //  public string PlotNo { get; set; }
        public string BuildingNo { get; set; }
        public string NameofArchitect { get; set; }
        public string ArchitectLicenseNo { get; set; }
        public string ArchitectRegistrationNo { get; set; }
        public string ArchitectAddress { get; set; }
        public float totalPlotArea { get; set; }
        public string ExistingBasement { get; set; }
        public string ExistingGroundFloor { get; set; }
        public string ExistingFirstFloor { get; set; }
        public string ExistingSecondFloor { get; set; }
        public string ExistingMezzanineFloor { get; set; }
        public string ProposedBasement { get; set; }
        public string ProposedGroundFloor { get; set; }
        public string ProposedFirstFloor { get; set; }
        public string ProposedSecondFloor { get; set; }
        public string ProposedMezzanineFloor { get; set; }
        public string Foundation { get; set; }
        public string Floors { get; set; }
        public string NoofStories { get; set; }
        public string NoofLatrines { get; set; }
        public string Walls { get; set; }
        public string Roofs { get; set; }
        public float Occupancy { get; set; }
        public string StiltFloor { get; set; }
        public string Mumti { get; set; }
        public string LabourHutmentArea { get; set; }
        public string AreaOtherUse { get; set; }
        public string TemporaryStructExists { get; set; }







        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string AddharNo { get; set; }
        public DateTime? DateofAllottementNo { get; set; }

        public decimal AID { get; set; }
        public int AllotteeID { get; set; }
        public int AllotteeRegisterID { get; set; }

        public string ProductManufactured { get; set; }
        public DateTime? DateOfBuldingPlanSubmission { get; set; }
        public DateTime? BuildingPlanApprovedRejectedDate { get; set; }

        public DateTime? DateOfRequestForCompletion { get; set; }
        public DateTime? DateOfReleaseForCompletion { get; set; }

        public DateTime? PaymentReicvedDate { get; set; }

        public float PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }

        public float RateofInterest { get; set; }

        public float TotalPrimiumAmount { get; set; }

        public float RebateNonDefaulters { get; set; }

        public float NoInstallments { get; set; }

        public float LocationCharges { get; set; }
        public float RateatTimeAllotment { get; set; }
        public float EarnestMoneyRate { get; set; }

        public float ReservationMoneyPaidwitin30days { get; set; }
        public DateTime? DemantNoticeDate1 { get; set; }
        public DateTime? DemantNoticeDate2 { get; set; }

        public string RateOfPlot { get; set; }
        public DateTime EffectiveFromDate { get; set; }
        public DateTime EffectiveToDate { get; set; }
        public DateTime? AllotmenttLetterApplicationDate { get; set; }

        public float ConstructionValueAtTimeofAllotment { get; set; }
        public string ref_AllotmentNo { get; set; }
        public string ref_LeaseDeed { get; set; }
        public string ref_BuildingPlan { get; set; }
        public string ref_CompletionCertificate { get; set; }
        public string ref_OccupancyCertificate { get; set; }
        public string ref_ConstructionInspection { get; set; }
        public string ref_CompletionInspection { get; set; }

        public DateTime? InspectionDateForConstructionPermit { get; set; }
        public DateTime? InspectionDateForComplition { get; set; }
        public DateTime PaymentIssueDate { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentDraftNo { get; set; }
        public string PaymentTransactionNo { get; set; }
        public string PaymentChequeNo { get; set; }
        public string PaymentBank { get; set; }






        public string StructuralEngineer { get; set; }
        public string StructuralEngineerLicensedNo { get; set; }
        public string StructuralEngineerRegistratinNo { get; set; }
        public string StructuralEngineerAddress { get; set; }



        public string Parameter { get; set; }
        public int ID { get; set; }

        public string Type { get; set; }

        public string Clause { get; set; }



        public float Far { get; set; }
        public float Groundcover { get; set; }
        public float SetBackFront { get; set; }
        public float SetBackRear { get; set; }
        public float SetBackSide1 { get; set; }
        public float SetBackSide2 { get; set; }
        public float Height { get; set; }
        public float AreaofParking { get; set; }
        public string NatureofOccupancy { get; set; }
        public string ServiceRequestNO { get; set; }
        public string AllotmentNo { get; set; }
        public string Lease_bookno { get; set; }
        public string Lease_bookbinding { get; set; }
        public string Lease_pagefrom { get; set; }
        public string Lease_pageto { get; set; }
        public string Lease_srno { get; set; }
        public string userlevel { get; set; }
        public string LocationAddress { get; set; }
        public string SpeciesofTrees { get; set; }
        public string NoOfTrees { get; set; }
        public string UploadedFileName { get; set; }
        public byte[] UploadedFile { get; set; }
        public string UploadedFileExt { get; set; }
        public string PayTrans_response_code { get; set; }
        public string PayTrans_unique_ref { get; set; }
        public string PayTrans_service_tax { get; set; }
        public string PayTrans_total_amt { get; set; }
        public string PayTrans_rs { get; set; }
        public string PayTrans_tdr { get; set; }
        public string PayTrans_trn_amt { get; set; }
        public string PayTrans_trn_date { get; set; }
        public string PayTrans_processing_fee_amt { get; set; }
        public string PayTrans_submer { get; set; }
        public string PayTrans_interchange_val { get; set; }
        public string PayTrans_id { get; set; }
        public string PayTrans_tps { get; set; }
        public string PayTrans_ref_no { get; set; }
        public string GatewayResponse { get; set; }
        public string ApplicantName { get; set; }
        public string URNNo { get; set; }
        public DateTime? PayDate { get; set; }
        public string BankName { get; set; }
        public decimal ProjectCurrentCost { get; set; }
        public decimal EmploymentProjected { get; set; }
        public decimal EmploymentGenerated { get; set; }



        public string CertificateNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public float StampDutyAmount { get; set; }
        public string AccountRefrenceNo { get; set; }
        public string UniqueDocRef { get; set; }
        public string BankGuaranteeNo { get; set; }
        public float GuaranteeAmount { get; set; }
        public DateTime? GuaranteeCoverFrom { get; set; }
        public DateTime? GuaranteeCoverTo { get; set; }
        public DateTime? LastDateOfClaim { get; set; }
        public string BankProposalLetter { get; set; }
        public string BankSanctionLetter { get; set; }
        public string SanctionLetterOfUPSIDC { get; set; }
        public int NoOfStamp { get; set; }
        public float StampAmount { get; set; }
        public float TotalStampDuty { get; set; }
        public string Region { get; set; }
        public string IAIdParam { get; set; }
        public string ParamType { get; set; }
        public int RateID { get; set; }
        public int IndustrialAreaId { get; set; }
        public DateTime Effective_To { get; set; }
        public int MinPeriod { get; set; }
        public decimal LeaseRate { get; set; }
        public int MaxPeriod { get; set; }
        public DateTime Effective_From { get; set; }
        public int LeaseRateId { get; set; }
        public int LeaseRateIdParam { get; set; }
        public DateTime? Possessiondate { get; set; }
        public DateTime? RestorationRefDate { get; set; }
        //   public float PossessionArea { get; set; }
        public string RestorationRefNo { get; set; }
        public string ChangeOfPlotRefNo { get; set; }
        public DateTime? ChangeOfPlotRefDate { get; set; }
        public string ChangeOfProjectRefNo { get; set; }
        public DateTime? ChangeOfProjectRefDate { get; set; }
        public string AmagaRefNo { get; set; }
        public DateTime? AmagaRefDate { get; set; }
        public string SubDivRefNo { get; set; }
        public DateTime? SubDivRefDate { get; set; }
        public string SublettingRefNo { get; set; }
        public DateTime? SublettingRefDate { get; set; }
        public DateTime? DateOfAgreement { get; set; }
        public DateTime? DateOfExecutionAgreement { get; set; }
        public decimal AgreementOnPlotSize { get; set; }
        public string SublettingPartyName { get; set; }
        public decimal SublettingArea { get; set; }
        public decimal SublettingForYears { get; set; }
        public string SublettingProjectName { get; set; }


        public string AllotmentCaseType { get; set; }
        public int TransferLevyCaseType { get; set; }
        public decimal AllotteePrevDues { get; set; }

        public object ServiceChecklistCondition { get; set; }

        public string AuthorisedSignatory { get; set; }
        public string SignatoryAddress { get; set; }
        public string SignatoryPhone { get; set; }
        public string SignatoryEmail { get; set; }
        public string CompanyName { get; set; }
        public string FirmConstitution { get; set; }
        public string PanNo { get; set; }
        public string CinNo { get; set; }
        public string ControlId { get; set; }
        public string ServiceId { get; set; }
        public string UnitId { get; set; }
        public int Status { get; set; }
        public string Preference1 { get; set; }
        public string Preference2 { get; set; }
        public string Preference3 { get; set; }
        public string PurposeofBuildingUse { get; set; }
        public string PreviousConstruction { get; set; }
        public string SourceofWater { get; set; }
        public string DocumentID { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string diffproarea;
        public decimal possessionareadiff;
        public decimal Amountrecover { get; set; }
        #region Tickets
        public string serviceID { get; set; }
        public int industrialAreaID { get; set; }
        public int RespondentID { get; set; }
        public int ticketOwnerID { get; set; }
        public int caseType { get; set; }
        public string ReQFor { get; set; }
        public string PayTrans_unique_ref_UPSIDC { get; set; }
        public int UserId { get; set; }

        public string UserIds { get; set; }

        #endregion


        #region 'List Of Notices'

        public string NoticeRefNo { get; set; }

        public DateTime NoticeDate { get; set; }
        public string NoticeDescription { get; set; }
        public byte[] NoticeContent { get; set; }
        public string NoticeName { get; set; }
        public string NoticeExtn { get; set; }
        public string NoticeID { get; set; }

        public string AlloteeId { get; set; }
        public string IAID { get; set; }

        #endregion


        #region "DuesClearence"

        public float TowardsPremium { get; set; }
        public float InterestOnPremium { get; set; }
        public float MaintenanceCharge { get; set; }
        public float InterestOnMaintenanceCharge { get; set; }
        public float LeaseRent { get; set; }
        public float GSTOnLeaseRent { get; set; }
        public float TimeExtensionFee { get; set; }
        public float InterestOnTimeExtension { get; set; }
        public float RemainingLeasePeriod { get; set; }
        public string PaymentID { get; set; }
        public string DuesID { get; set; }
        public string TranID { get; set; }





        #endregion



        #region "demandnote"

        public string AllotmentLetterno { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DemandDate { get; set; }
        public decimal DueAmount { get; set; }
        public int demandID { get; set; }
        public int paymentID { get; set; }
        public string PayDesc { get; set; }



        #endregion


        #region HDFCGateWay
        public string PayTrans_MerchantId;
        public string PayMode;
        public string PayTrans_trn_date_hdfc { get; set; }
        #endregion

        #region NewCode by Manish Shukla


        public DateTime? PaymentRecivedDate { get; set; }
        public decimal PaymentRecivedAmount { get; set; }


        public string btnText;
        public float ReservationPaymentAmount { get; set; }
        public DateTime? PhysicalPossessionDate { get; set; }
        public DateTime? ReservationPaymentDate { get; set; }





        public string DemandID { get; set; }

        public string ReservationmoneyStatus { get; set; }
        public string LeaseDeedSignedStatus { get; set; }
        public string PossessionLetterStatus { get; set; }
        public string PhysicalPossessionStatus { get; set; }
        public string BuildingPlanStatus { get; set; }
        public string RestorationStatus { get; set; }
        public string ChangeofPlotStatus { get; set; }
        public string ChangeofProjectStatus { get; set; }
        public string AmalgamationStatus { get; set; }
        public string SubDivisionStatus { get; set; }
        public string SublettingStatus { get; set; }
        public string AgreementStatus { get; set; }
        public string EStampStatus { get; set; }
        public string BankGuaranteeStatus { get; set; }
        public string MortgageStatus { get; set; }
        public string PayRecivedDescription { get; set; }
        public int PaymentRecivedID { get; set; }
        public DateTime? DueDateofInstallment { get; set; }
        public decimal InterestDue { get; set; }
        public decimal InterestDuewithout { get; set; }
        public decimal PremiumDue { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountRebate { get; set; }
        public int Priority { get; set; }

        public float CompoundingCharges { get; set; }
        public float NoofPlotCreated { get; set; }

        public decimal SubDivCharges { get; set; }
        public decimal ExtensionCharges { get; set; }
        public decimal SublettingCharge { get; set; }
        public decimal UsabilityFees { get; set; }
        public decimal AmalgamationFees { get; set; }
        public DateTime? RectificationDeedDate { get; set; }
        public string SubDivType { get; set; }
        public decimal AdditionalChargesforplot { get; set; }
        public string DeedafterChangeofPlot { get; set; }
        public decimal ChangeforChanges { get; set; }
        public string DeedafterRestoration { get; set; }
        public string RestorationLevy { get; set; }
        public decimal Payment { get; set; }
        public decimal MaintenanceChargesWaiver { get; set; }
        public decimal Inttonbalancedues { get; set; }
        public decimal InttonTimeextension { get; set; }
        public decimal TimeextensionWaiver { get; set; }
        public DateTime? TimeextensionWaiverTo { get; set; }
        public DateTime? TimeextensionWaiverfrom { get; set; }
        public DateTime PaymentReciveddate { get; set; }
        public string parkDeveloped { get; set; }
        public string South { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public int Nooftrees { get; set; }
        public string MaintainedBy { get; set; }
        public string PlotNumber { get; set; }

        //PIP By Sunil
        public string ReasonDetails { get; set; }


        public float othercharges;
        public float increaseofFAR;
        public string excutionofdeed;
        public decimal changesinfar;
        public DateTime? letterdate;
        public string letternumber;
        public DateTime? dateofIncreaseinfar;
        public decimal timePeriod;
        public string linterestWaiver;
        public string increaseinfar;
        public string installmentStatus;
        public string North;
        public string PaymentTableID;
        public string username;
        public string phoneNo;
        public object paidStatus;
        public object emailID;
        public object emailIDsecond;
        public object emailids;
        public int pollutionCategorystatus;
        public object districtID;
        public string DocPath;
        public string DistrictName;
        public decimal locationcharge;
        public DateTime firstAllotmentDate;
        public string applicableonAllotmentletter;
        public string us;

        public string TEFRefferenceNumber { get; set; }
        public DateTime? TEFApprovalDate { get; set; }
        public int TEFPeriod { get; set; }
        public decimal TEFFees { get; set; }
        public string TEFStatus { get; set; }
        public string Operationalmaintenancecharges { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Designation { get; set; }
        public string Qualification { get; set; }
        public string Employee { get; set; }
        public int Empcode { get; set; }
        public string ContractType { get; set; }
        public string AdditionalProduct { get; set; }
        public string ProductDescription { get; set; }
        public object TEFTimeperiod { get; set; }
        public object TEFID { get; set; }
        public object AppointmentType { get; set; }
        public object AppointmentDesc { get; set; }
        public object StampPaperAmount { get; set; }
        public object DMCircle { get; set; }
        public object ServiceChecklistDesc { get; set; }
        public object Amountfirstcharge { get; set; }
        public object BankNamefirstcharge { get; set; }
        public object AuthorizedSignatoryfirstcharge { get; set; }
        public object MobileNumber { get; set; }
        public object Amountsecond { get; set; }
        public object BranchNamesecond { get; set; }
        public object Addresssecond { get; set; }
        public object AuthorizedSignatorysecond { get; set; }
        public object MobileNumbersecond { get; set; }
        public object PremimAmount { get; set; }
        public object InterestAmount { get; set; }
        public object PremimAmountSecond { get; set; }
        public object InterestSecond { get; set; }
        public object SanctionletternoSecond { get; set; }
        public object SanctionletterDatesecond { get; set; }
        public object SanctionletterDate { get; set; }
        public object Sanctionletterno { get; set; }
        public object ROAppointmentDate { get; set; }
        public object ROAllotteeRemarks { get; set; }
        public object LetterNo { get; set; }
        public object LetterDate { get; set; }
        public object MobileNumbers { get; set; }
        public object AddressBank { get; set; }
        public object LetterFrom { get; set; }
        public object ConstructionValue { get; set; }
        public object PosseessionAreaLease { get; set; }
        public object InspectionDateLease { get; set; }
        public object AnyConstruction { get; set; }
        public object PlotDimension { get; set; }
        public object PlotDirection { get; set; }
        public object LeaseRegistryDate { get; set; }
        public object LeaseBahi { get; set; }
        public object LeaseJild { get; set; }
        public object LeasePageFrom { get; set; }
        public object LeasePageTo { get; set; }
        public object LeaseSrNo { get; set; }
        public object EligibleRebate { get; set; }
        public string TransferCondition { get; set; }

        public string GSTNo { get; set; }
        public object AvailRebate { get; set; }
        public object POAID { get; set; }
        public object PossessionAppointment { get; set; }
        public object PosseessionGivenTo { get; set; }
        public object PosseessionAreaGiven { get; set; }
        public object PossessionGivenDate { get; set; }
        public object ObjectionDesc { get; set; }
        public object ObjectionType { get; set; }
        public object MortgageID { get; set; }
        public object Percentage { get; set; }
        public object MobileNo { get; set; }
        public object BankAddress { get; set; }
        public object LetterFromleasedeed { get; set; }
        public object ApplicationDescription { get; set; }
        public object FirmType { get; set; }
        public string InstantAllotmentStatus { get; set; }
        public string UseZone { get; set; }
        public int InstantAllotment { get; set; }
        public string NocBankName { get; set; }
        public string NocBranchName { get; set; }
        public string ReportType { get; set; }
        public string NMObjectionRejectionType { get; set; }
        public string FileNo { get; set; }
        public string SectorName { get; set; }
        public decimal AllotmentRate { get; set; }
        public decimal InterestRateApplicable { get; set; }
        public decimal GroundCoverage { get; set; }
        public decimal PermisableFAR { get; set; }
        public int TranserLevyCase { get; set; }
        public decimal PrevDues { get; set; }
        public string Allotmentreferencenumber { get; set; }
        public int Newstatus { get; set; }
        public string GstNo { get; set; }
        public string UdyogAadharNo { get; set; }
        public string AadharNo { get; set; }
        public decimal OwnResources { get; set; }
        public decimal FI { get; set; }
        public string FAR { get; set; }
        public DateTime NoticeVaildUpto { get; set; }
        public string NoticeTypes { get; set; }
        public int District { get; set; }
        public int LandID { get; set; }
        public string Execution { get; set; }
        public string Mutation { get; set; }
        public int SubDistrict { get; set; }
        public string PIPReasonDetails { get; set; }
        public object TransferStatus { get; set; }
        public object TransferPIPCommStatus { get; set; }
        public object UID { get; set; }

        public object ReScDueServiceRequestNo { get; set; }
        
        #endregion

        public string LandConversionChargesPaidifanyinCr { get; set; }
        public string RegistrationFeesPaidinCr { get; set; }
        public string AnyOtherDetails { get; set; }

    }
  }