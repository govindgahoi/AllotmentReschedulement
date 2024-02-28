using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allotment
{
    public class Mpropertymodel
    {
        //04/10/2023
        public string ControlID { get; set; }
        public string UnitID { get; set; }
        public string ServiceID { get; set; }
        public string RequestID { get; set; }
        // 03/10/2023
        public string Dateofacquiringlandyear6 { get; set; }
        public string StartofConstructionDateyear6 { get; set; }
        public string CompletionofInfrastructureDateyear6 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear6 { get; set; }
        public string InstallationErectionDateyear6 { get; set; }
        public string Proposeddateforcompletionyear6 { get; set; }

        //
        #region director details
        public int AllotteeID { get; set; }
        public string DirectorName { get; set; }
        public string CategoryofDirectorship { get; set; }
        #endregion
        #region mashi  Applicant Details


        //01/09/2023
        public string ApplicationId { get; set; }
        public string Developerpmtrname { get; set; }
        public string DeveloperpmtrEmail { get; set; }
        public string DeveloperpmtrMobile { get; set; }
        public string Website { get; set; }
        public string Address2 { get; set; }
        public string BeneficiaryName { get; set; }
        public string finDesignation { get; set; }
        public string BankAccountNo { get; set; }
        public string TypeOfAccount { get; set; }
        public string NameofBank { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string phoneNo { get; set; }
        public string PanNo { get; set; }
        public string Address { get; set; }
        public string ServiceRequestNO { get; set; }
        public string IsSPV { get; set; }
        public string companyName { get; set; }
        public string FirmConstitution { get; set; }
        public string IFSCCode { get; set; }
        public string BranchAddress { get; set; }
        public DateTime ApplicationSubmissionDate { get; set; }
        public byte[] ApplicantImageByte { get; set; }
        public string ApplicantImageName { get; set; }
        public string ImageContent { get; set; }
        #endregion


        #region Project details
        public string PANameofIndustrialPark { get; set; }
        public string PAAreaofIndustrialParkinAcres { get; set; }
        public string FarIndustrialAsPerGuidelines { get; set; }
        public string FarCommercialAsPerGuidelines { get; set; }
        public string FarGreenandOpenSpacesAsPerGuidelines { get; set; }
        public string FarUtilitiesAsPerGuidelines { get; set; }
        public string FarHostelDormitoryAsPerGuidelines { get; set; }

        public string ExemptiononStampDutyinCr { get; set; }
        public string CapitalSubsidyonEligibleFixedCapitalInvestmentinCr { get; set; }
        public string CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr { get; set; }
        public string TotalAmountofFinancialAssistanceSoughtinCr { get; set; }
        public string IRoadsStreetlightingAreainAcres { get; set; }
        public string IRoadsStreetlightingCostinCr { get; set; }
        public string IWaterAreainAcres { get; set; }
        public string IWaterCostinCr { get; set; }
        public string ISewerageDrainageAreainAcres { get; set; }
        public string ISewerageDrainageCostinCr { get; set; }
        public string IPowerSupplyAreainAcres { get; set; }
        public string IPowerSupplyCostinCr { get; set; }
        public string IWarehousingAreainAcres { get; set; }
        public string IWarehousingCostinCr { get; set; }
        public string IParkingTruckingBaysAreainAcres { get; set; }
        public string IParkingTruckingBaysCostinCr { get; set; }
        public string CFWeightBridgeAreainAcres { get; set; }
        public string CFWeightBridgeCostinCr { get; set; }
        public string CFSkillDevelopmentCentreAreainAcres { get; set; }
        public string CFSkillDevelopmentCentreCostinCr { get; set; }
        public string CFComputerCentreAreainAcres { get; set; }
        public string CFComputerCentreCostinCr { get; set; }
        public string CFProductDevelopmentCentreAreainAcres { get; set; }
        public string CFProductDevelopmentCentreCostinCr { get; set; }
        public string CFTestingCentreAreainAcres { get; set; }
        public string CFTestingCentreCostinCr { get; set; }
        public string CFRandDCentreAreainAcres { get; set; }
        public string CFRandDCentreCostinCr { get; set; }
        public string CFContainerFreightStationAreainAcres { get; set; }
        public string CFContainerFreightStationCostinCr { get; set; }
        public string CFRepairworkshopforVehiclesAreainAcres { get; set; }
        public string CFRepairworkshopforVehiclesCostinCr { get; set; }
        public string BCFFacilitiesCanteenAreainAcres { get; set; }
        public string BCFFacilitiesCanteenCostinCr { get; set; }
        public string BCFMedicalCentreAreainAcres { get; set; }
        public string BCFMedicalCentreCostinCr { get; set; }
        public string BCFPetrolPumpAreainAcres { get; set; }
        public string BCFPetrolPumpCostinCr { get; set; }
        public string BCFBankingandFinanceAreainAcres { get; set; }
        public string BCFBankingandFinanceCostinCr { get; set; }
        public string BCFOfficeSpaceAreainAcres { get; set; }
        public string BCFOfficeSpaceCostinCr { get; set; }
        public string BCFHotelRestaurantsAreainAcres { get; set; }
        public string BCFHotelRestaurantsCostinCr { get; set; }
        public string BCFHospitalDispensaryAreainAcres { get; set; }
        public string BCFHospitalDispensaryCostinCr { get; set; }
        public string BCFAdministrationOfficeAreainAcres { get; set; }
        public string BCFAdministrationOfficeCostinCr { get; set; }
        public string BCFWarehousingFacilitiesAreainAcres { get; set; }
        public string BCFWarehousingFacilitiesCostinCr { get; set; }
        public string BCFHousingDormitoryHostelforDomicileWorkeAreainAcres { get; set; }
        public string BCFHousingDormitoryHostelforDomicileWorkeCostinCr { get; set; }
        public string OtherAreainAcres { get; set; }
        public string OtherCostinCr { get; set; }
        public string udunitname1 { get; set; }
        public string udunitnametype1 { get; set; }
        public string udunitname2 { get; set; }
        public string udunitnametype2 { get; set; }
        public string udunitname3 { get; set; }
        public string udunitnametype3 { get; set; }
        public string udunitname4 { get; set; }
        public string udunitnametype4 { get; set; }
        public string udunitname5 { get; set; }
        public string udunitnametype5 { get; set; }
        public string Dateofacquiringlandyear1 { get; set; }
        public string StartofConstructionDateyear1 { get; set; }
        public string CompletionofInfrastructureDateyear1 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear1 { get; set; }
        public string InstallationErectionDateyear1 { get; set; }
        public string Proposeddateforcompletionyear1 { get; set; }
        public string Dateofacquiringlandyear2 { get; set; }
        public string StartofConstructionDateyear2 { get; set; }
        public string CompletionofInfrastructureDateyear2 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear2 { get; set; }
        public string InstallationErectionDateyear2 { get; set; }
        public string Proposeddateforcompletionyear2 { get; set; }
        public string Dateofacquiringlandyear3 { get; set; }
        public string StartofConstructionDateyear3 { get; set; }
        public string CompletionofInfrastructureDateyear3 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear3 { get; set; }
        public string InstallationErectionDateyear3 { get; set; }
        public string Proposeddateforcompletionyear3 { get; set; }
        public string Dateofacquiringlandyear4 { get; set; }
        public string StartofConstructionDateyear4 { get; set; }
        public string CompletionofInfrastructureDateyear4 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear4 { get; set; }
        public string InstallationErectionDateyear4 { get; set; }
        public string Proposeddateforcompletionyear4 { get; set; }
        public string Dateofacquiringlandyear5 { get; set; }
        public string StartofConstructionDateyear5 { get; set; }
        public string CompletionofInfrastructureDateyear5 { get; set; }
        public string DateofPlacingorderforPlantandMachineryyear5 { get; set; }
        public string InstallationErectionDateyear5 { get; set; }
        public string Proposeddateforcompletionyear5 { get; set; }
        public string EnvironmentalClearances { get; set; }
        public string OperationsandMaintenancetobeTakenupby { get; set; }
        public string CashFlowProjections { get; set; }
        public string ProjectedInflowinCrYear1 { get; set; }
        public string ProjectedOutflowinCrYear1 { get; set; }
        public string ProjectedInflowinCrYear2 { get; set; }
        public string ProjectedOutflowinCrYear2 { get; set; }
        public string ProjectedInflowinCrYear3 { get; set; }
        public string ProjectedOutflowinCrYear3 { get; set; }
        public string ProjectedInflowinCrYear4 { get; set; }
        public string ProjectedOutflowinCrYear4 { get; set; }
        public string ProjectedInflowinCrYear5 { get; set; }
        public string ProjectedOutflowinCrYear5 { get; set; }
        public string BuildingPlanApprovalStatus { get; set; }
        public string BuildingPlanApprovedfromAuthority { get; set; }
        public string BuildingPlanApplicationIdOBPAS { get; set; }
        public string OwnershipofHostelDormitoryCompany { get; set; }
        public string AnyOtherInformation { get; set; }
        public string FarRoadsAsPerGuidelines { get; set; }
        #endregion

    }
}