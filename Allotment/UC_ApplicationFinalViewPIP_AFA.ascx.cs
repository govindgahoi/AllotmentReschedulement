using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewPIP_AFA : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        public string ServiceRequestNo { get; set; }

        public string ControlID { get; set; }
        public string Parameter { get; set; }
        public string TranID { get; set; }
        public string TLExemption { get; set; }
        public string TLExemptionCase { get; set; }
        #endregion


        private DataTable Getdata1
        {
            get; set;
        }

        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }

        public void Page_Load(object sender, EventArgs e)
        {
            GetPIPApplicantDetails(ServiceRequestNo);
        }


        private void GetPIPApplicantDetails(String ID)
        {
            Mpropertymodel objServiceTimelinesBEL = new Mpropertymodel();
            Mbal objServiceTimelinesBLL = new Mbal();
            DataSet ds = new DataSet();
            try
            {
                string html = "";
                string html1 = "";
                string html3 = "";
                int i = 0;
                int j = 0;
                int k = 0;
                int l = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ID;
                ds = objServiceTimelinesBLL.GetPIP_AFA_ProjectDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable dt_Obj = ds.Tables[4];
                DataTable dt_Land = ds.Tables[5];
                DataTable dtService = ds.Tables[6];

                if (dt.Rows.Count > 0)
                {
                    //grddirector.DataSource = dt1;
                    //grddirector.DataBind();

                    string AllotteeID = dt.Rows[0]["AllotteeID"].ToString();
                    lblApplicantId.Text = dt.Rows[0]["FormNo"].ToString();
                    if (!string.IsNullOrEmpty(dtService.Rows[0]["ServiceSubmitDate"].ToString()))
                    {
                       lblDate.Text = Convert.ToDateTime(dtService.Rows[0]["ServiceSubmitDate"].ToString()).ToShortDateString();
                        //lblDate.Text = dtService.Rows[0]["ServiceSubmitDate"].ToString();
                    }

                    Name.Text = dt.Rows[0]["AllotteeName"].ToString();
                    Email.Text = dt.Rows[0]["emailID"].ToString();
                    Designation.Text = dt.Rows[0]["Designation"].ToString();
                    MobileNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    PAN.Text = dt.Rows[0]["PanNo"].ToString();
                    Address.Text = dt.Rows[0]["Address1"].ToString();
                    SPV.Text = dt.Rows[0]["SPV"].ToString();
                    PersonContactNo.Text = dt.Rows[0]["DeveloperpmtrMobile"].ToString();
                    Website.Text = dt.Rows[0]["Website"].ToString();
                    Address2.Text = dt.Rows[0]["Address"].ToString();
                    ConstitutionoftheFirm.Text = dt.Rows[0]["companyName"].ToString();
                    BeneficiaryName.Text = dt.Rows[0]["BeneficiaryName"].ToString();
                    BankAccountNo.Text = dt.Rows[0]["BankAccountNo"].ToString();
                    dpsvName.Text = dt.Rows[0]["Developerpmtrname"].ToString();
                    dpsvEmail.Text = dt.Rows[0]["DeveloperpmtrEmail"].ToString();
                    TypeofAccount.Text = dt.Rows[0]["TypeOfAccount"].ToString();
                    NameofBank.Text = dt.Rows[0]["NameofBank"].ToString();
                    BranchAddress.Text = dt.Rows[0]["BranchAddress"].ToString();
                    //DirectorName1.Text = dt.Rows[0]["DirectorName1"].ToString();
                    //DirectorName2.Text = dt.Rows[0]["DirectorName2"].ToString();
                    //DirectorName3.Text = dt.Rows[0]["DirectorName3"].ToString();
                    //CategoryOfDirectorship1.Text = dt.Rows[0]["CategoryOfDirectorship1"].ToString();
                    //CategoryOfDirectorship2.Text = dt.Rows[0]["CategoryOfDirectorship2"].ToString();
                    //CategoryOfDirectorship3.Text = dt.Rows[0]["CategoryOfDirectorship3"].ToString();
                    string Imagetype = dt.Rows[0]["AllotteeImageType"].ToString().Trim();
                    string ImageName = dt.Rows[0]["AllotteeSignName"].ToString().Trim();
                    string img = dt.Rows[0]["AllotteeImage"].ToString();
                    string signimg = dt.Rows[0]["AllotteeSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);
                    }
                    if (signimg.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeSign"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Img2.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);
                    }

                    if (dt_project.Rows.Count > 0)
                    {
                        ExemptiononStampDutyinCr.Text = dt_project.Rows[0]["ExemptiononStampDutyinCr"].ToString().Trim();
                        CapitalSubsidyonEligibleFixedCapitalInvestmentinCr.Text = dt_project.Rows[0]["CapitalSubsidyonEligibleFixedCapitalInvestmentinCr"].ToString().Trim();
                        CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr.Text = dt_project.Rows[0]["CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr"].ToString().Trim();
                        TotalAmountofFinancialAssistanceSoughtinCr.Text = dt_project.Rows[0]["TotalAmountofFinancialAssistanceSoughtinCr"].ToString().Trim();
                        NameofIndustrialPark.Text = dt_project.Rows[0]["PANameofIndustrialPark"].ToString().Trim();
                        PAAreaofIndustrialParkinAcres.Text = dt_project.Rows[0]["PAAreaofIndustrialParkinAcres"].ToString().Trim();
                        FarIndustrialAsPerGuidelines.Text = dt_project.Rows[0]["FarIndustrialAsPerGuidelines"].ToString();
                        FarIndustrialAsPerGuidelines.Text = dt_project.Rows[0]["FarIndustrialAsPerGuidelines"].ToString();
                        FarCommercialAsPerGuidelines.Text = dt_project.Rows[0]["FarCommercialAsPerGuidelines"].ToString();
                        FarRoadsAsPerGuidelines.Text = dt_project.Rows[0]["FarRoadsAsPerGuidelines"].ToString();
                        FarGreenandOpenSpacesAsPerGuidelines.Text = dt_project.Rows[0]["FarGreenandOpenSpacesAsPerGuidelines"].ToString();
                        FarUtilitiesAsPerGuidelines.Text = dt_project.Rows[0]["FarUtilitiesAsPerGuidelines"].ToString();
                        FarHostelDormitoryAsPerGuidelines.Text = dt_project.Rows[0]["FarHostelDormitoryAsPerGuidelines"].ToString();
                        IRoadsStreetlightingAreainAcres.Text = dt_project.Rows[0]["IRoadsStreetlightingAreainAcres"].ToString();
                        IRoadsStreetlightingCostinCr.Text = dt_project.Rows[0]["IRoadsStreetlightingCostinCr"].ToString();
                        IWaterAreainAcres.Text = dt_project.Rows[0]["IWaterAreainAcres"].ToString();
                        IWaterCostinCr.Text = dt_project.Rows[0]["IWaterCostinCr"].ToString();
                        ISewerageDrainageAreainAcres.Text = dt_project.Rows[0]["ISewerageDrainageAreainAcres"].ToString();
                        ISewerageDrainageCostinCr.Text = dt_project.Rows[0]["ISewerageDrainageCostinCr"].ToString();
                        IPowerSupplyAreainAcres.Text = dt_project.Rows[0]["IPowerSupplyAreainAcres"].ToString();
                        IPowerSupplyCostinCr.Text = dt_project.Rows[0]["IPowerSupplyCostinCr"].ToString();
                        IWarehousingAreainAcres.Text = dt_project.Rows[0]["IWarehousingAreainAcres"].ToString();
                        IWarehousingCostinCr.Text = dt_project.Rows[0]["IWarehousingCostinCr"].ToString();
                        IParkingTruckingBaysAreainAcres.Text = dt_project.Rows[0]["IParkingTruckingBaysAreainAcres"].ToString();
                        IParkingTruckingBaysCostinCr.Text = dt_project.Rows[0]["IParkingTruckingBaysCostinCr"].ToString();
                        CFWeightBridgeAreainAcres.Text = dt_project.Rows[0]["CFWeightBridgeAreainAcres"].ToString();
                        CFWeightBridgeCostinCr.Text = dt_project.Rows[0]["CFWeightBridgeCostinCr"].ToString();
                        CFSkillDevelopmentCentreAreainAcres.Text = dt_project.Rows[0]["CFSkillDevelopmentCentreAreainAcres"].ToString();
                        CFSkillDevelopmentCentreCostinCr.Text = dt_project.Rows[0]["CFSkillDevelopmentCentreCostinCr"].ToString();
                        CFComputerCentreAreainAcres.Text = dt_project.Rows[0]["CFComputerCentreAreainAcres"].ToString();
                        CFComputerCentreCostinCr.Text = dt_project.Rows[0]["CFComputerCentreCostinCr"].ToString();
                        CFProductDevelopmentCentreAreainAcres.Text = dt_project.Rows[0]["CFProductDevelopmentCentreAreainAcres"].ToString();
                        CFProductDevelopmentCentreCostinCr.Text = dt_project.Rows[0]["CFProductDevelopmentCentreCostinCr"].ToString();
                        CFTestingCentreAreainAcres.Text = dt_project.Rows[0]["CFTestingCentreAreainAcres"].ToString();
                        CFTestingCentreCostinCr.Text = dt_project.Rows[0]["CFTestingCentreCostinCr"].ToString();
                        CFRandDCentreAreainAcres.Text = dt_project.Rows[0]["CFRandDCentreAreainAcres"].ToString();
                        CFRandDCentreCostinCr.Text = dt_project.Rows[0]["CFRandDCentreCostinCr"].ToString();
                        CFContainerFreightStationAreainAcres.Text = dt_project.Rows[0]["CFContainerFreightStationAreainAcres"].ToString();
                        CFContainerFreightStationCostinCr.Text = dt_project.Rows[0]["CFContainerFreightStationCostinCr"].ToString();
                        CFRepairworkshopforVehiclesAreainAcres.Text = dt_project.Rows[0]["CFRepairworkshopforVehiclesAreainAcres"].ToString();
                        CFRepairworkshopforVehiclesCostinCr.Text = dt_project.Rows[0]["CFRepairworkshopforVehiclesCostinCr"].ToString();
                        BCFFacilitiesCanteenAreainAcres.Text = dt_project.Rows[0]["BCFFacilitiesCanteenAreainAcres"].ToString();
                        BCFFacilitiesCanteenCostinCr.Text = dt_project.Rows[0]["BCFFacilitiesCanteenCostinCr"].ToString();
                        BCFMedicalCentreAreainAcres.Text = dt_project.Rows[0]["BCFMedicalCentreAreainAcres"].ToString();
                        BCFMedicalCentreCostinCr.Text = dt_project.Rows[0]["BCFMedicalCentreCostinCr"].ToString();
                        BCFPetrolPumpAreainAcres.Text = dt_project.Rows[0]["BCFPetrolPumpAreainAcres"].ToString();
                        BCFPetrolPumpCostinCr.Text = dt_project.Rows[0]["BCFPetrolPumpCostinCr"].ToString();
                        BCFBankingandFinanceAreainAcres.Text = dt_project.Rows[0]["BCFBankingandFinanceAreainAcres"].ToString();
                        BCFBankingandFinanceCostinCr.Text = dt_project.Rows[0]["BCFBankingandFinanceCostinCr"].ToString();
                        BCFOfficeSpaceAreainAcres.Text = dt_project.Rows[0]["BCFOfficeSpaceAreainAcres"].ToString();
                        BCFOfficeSpaceCostinCr.Text = dt_project.Rows[0]["BCFOfficeSpaceCostinCr"].ToString();
                        BCFHotelRestaurantsAreainAcres.Text = dt_project.Rows[0]["BCFHotelRestaurantsAreainAcres"].ToString();
                        BCFHotelRestaurantsCostinCr.Text = dt_project.Rows[0]["BCFHotelRestaurantsCostinCr"].ToString();
                        BCFHospitalDispensaryAreainAcres.Text = dt_project.Rows[0]["BCFHospitalDispensaryAreainAcres"].ToString();
                        BCFHospitalDispensaryCostinCr.Text = dt_project.Rows[0]["BCFHospitalDispensaryCostinCr"].ToString();
                        BCFAdministrationOfficeAreainAcres.Text = dt_project.Rows[0]["BCFAdministrationOfficeAreainAcres"].ToString();
                        BCFAdministrationOfficeCostinCr.Text = dt_project.Rows[0]["BCFAdministrationOfficeCostinCr"].ToString();
                        BCFWarehousingFacilitiesAreainAcres.Text = dt_project.Rows[0]["BCFWarehousingFacilitiesAreainAcres"].ToString();
                        BCFWarehousingFacilitiesCostinCr.Text = dt_project.Rows[0]["BCFWarehousingFacilitiesCostinCr"].ToString();
                        BCFHousingDormitoryHostelforDomicileWorkeAreainAcres.Text = dt_project.Rows[0]["BCFHousingDormitoryHostelforDomicileWorkeAreainAcres"].ToString();
                        BCFHousingDormitoryHostelforDomicileWorkeCostinCr.Text = dt_project.Rows[0]["BCFHousingDormitoryHostelforDomicileWorkeCostinCr"].ToString();
                        OtherAreainAcres.Text = dt_project.Rows[0]["OtherAreainAcres"].ToString().Trim();
                        OtherCostinCr.Text = dt_project.Rows[0]["OtherCostinCr"].ToString().Trim();
                        udunitname1.Text = dt_project.Rows[0]["udunitname1"].ToString().Trim();
                        udunitnametype1.Text = dt_project.Rows[0]["udunitnametype1"].ToString().Trim();
                        udunitname2.Text = dt_project.Rows[0]["udunitname2"].ToString().Trim();
                        udunitnametype2.Text = dt_project.Rows[0]["udunitnametype2"].ToString().Trim();
                        udunitname3.Text = dt_project.Rows[0]["udunitname3"].ToString().Trim();
                        udunitnametype3.Text = dt_project.Rows[0]["udunitnametype3"].ToString().Trim();
                        udunitname4.Text = dt_project.Rows[0]["udunitname4"].ToString().Trim();
                        udunitnametype4.Text = dt_project.Rows[0]["udunitnametype4"].ToString().Trim();
                        udunitname5.Text = dt_project.Rows[0]["udunitname5"].ToString().Trim();
                        udunitnametype5.Text = dt_project.Rows[0]["udunitnametype5"].ToString().Trim();
                        Dateofacquiringlandyear1.Text = dt_project.Rows[0]["Dateofacquiringlandyear1"].ToString().Trim();
                        StartofConstructionDateyear1.Text = dt_project.Rows[0]["StartofConstructionDateyear1"].ToString().Trim();
                        CompletionofInfrastructureDateyear1.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear1"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear1.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear1"].ToString().Trim();
                        InstallationErectionDateyear1.Text = dt_project.Rows[0]["InstallationErectionDateyear1"].ToString().Trim();
                        Proposeddateforcompletionyear1.Text = dt_project.Rows[0]["Proposeddateforcompletionyear1"].ToString().Trim();
                        Dateofacquiringlandyear2.Text = dt_project.Rows[0]["Dateofacquiringlandyear2"].ToString().Trim();
                        StartofConstructionDateyear2.Text = dt_project.Rows[0]["StartofConstructionDateyear2"].ToString().Trim();
                        CompletionofInfrastructureDateyear2.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear2"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear2.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear2"].ToString().Trim();
                        InstallationErectionDateyear2.Text = dt_project.Rows[0]["InstallationErectionDateyear2"].ToString().Trim();
                        Proposeddateforcompletionyear2.Text = dt_project.Rows[0]["Proposeddateforcompletionyear2"].ToString().Trim();
                        Dateofacquiringlandyear3.Text = dt_project.Rows[0]["Dateofacquiringlandyear3"].ToString().Trim();
                        StartofConstructionDateyear3.Text = dt_project.Rows[0]["StartofConstructionDateyear3"].ToString().Trim();
                        CompletionofInfrastructureDateyear3.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear3"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear3.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear3"].ToString().Trim();
                        InstallationErectionDateyear3.Text = dt_project.Rows[0]["InstallationErectionDateyear3"].ToString().Trim();
                        Proposeddateforcompletionyear3.Text = dt_project.Rows[0]["Proposeddateforcompletionyear3"].ToString().Trim();



                        Dateofacquiringlandyear4.Text = dt_project.Rows[0]["Dateofacquiringlandyear4"].ToString().Trim();
                        StartofConstructionDateyear4.Text = dt_project.Rows[0]["StartofConstructionDateyear4"].ToString().Trim();
                        CompletionofInfrastructureDateyear4.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear4"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear4.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear4"].ToString().Trim();
                        InstallationErectionDateyear4.Text = dt_project.Rows[0]["InstallationErectionDateyear4"].ToString().Trim();
                        Proposeddateforcompletionyear4.Text = dt_project.Rows[0]["Proposeddateforcompletionyear4"].ToString().Trim();



                        Dateofacquiringlandyear5.Text = dt_project.Rows[0]["Dateofacquiringlandyear5"].ToString().Trim();
                        StartofConstructionDateyear5.Text = dt_project.Rows[0]["StartofConstructionDateyear5"].ToString().Trim();
                        CompletionofInfrastructureDateyear5.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear5"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear5.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear5"].ToString().Trim();
                        InstallationErectionDateyear5.Text = dt_project.Rows[0]["InstallationErectionDateyear5"].ToString().Trim();
                        Proposeddateforcompletionyear5.Text = dt_project.Rows[0]["Proposeddateforcompletionyear5"].ToString().Trim();
                        //



                        Dateofacquiringlandyear6.Text = dt_project.Rows[0]["Dateofacquiringlandyear6"].ToString().Trim();
                        StartofConstructionDateyear6.Text = dt_project.Rows[0]["StartofConstructionDateyear6"].ToString().Trim();

                        CompletionofInfrastructureDateyear6.Text = dt_project.Rows[0]["CompletionofInfrastructureDateyear6"].ToString().Trim();
                        DateofPlacingorderforPlantandMachineryyear6.Text = dt_project.Rows[0]["DateofPlacingorderforPlantandMachineryyear6"].ToString().Trim();

                        InstallationErectionDateyear6.Text = dt_project.Rows[0]["InstallationErectionDateyear6"].ToString().Trim();
                        Proposeddateforcompletionyear6.Text = dt_project.Rows[0]["Proposeddateforcompletionyear6"].ToString().Trim();

                        //
                        if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                        {

                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt1.Rows)
                            {
                                i++;
                                html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ApplicantName"].ToString() + "</td><td>" + dr["Address1"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["emailID"] + "</td></tr>";
                            }

                            PH1.Controls.Clear();
                            html += "</table>";
                            Literal loLit = new Literal();
                            loLit.Text = (html);
                            PH1.Controls.Add(loLit);

                            Headerlbl.Text = "Individual/Sole Proprietorship firm Details";

                        }

                        if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                        {

                            Headerlbl.Text = "Directors Details";

                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Din/Pan</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt1.Rows)
                            {
                                i++;
                                html += "<tr><td>" + i.ToString() + "</td><td>" + dr["DirectorName"].ToString() + "</td><td>" + dr["DIN_PAN"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                            }

                            PH1.Controls.Clear();
                            html += "</table>";
                            Literal loLit = new Literal();
                            loLit.Text = (html);
                            PH1.Controls.Add(loLit);
                        }

                        //if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                        //{

                        //    Headerlbl.Text = "ShareHolders Details";


                        //    html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                        //        <tr><th> S.NO </th><th> Name </th><th>Shares (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        //    foreach (DataRow dr in dt1.Rows)
                        //    {
                        //        i++;
                        //        html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ShareholderName"].ToString() + "</td><td>" + dr["SharePer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        //    }

                        //    PH1.Controls.Clear();
                        //    html += "</table>";
                        //    Literal loLit = new Literal();
                        //    loLit.Text = (html);
                        //    PH1.Controls.Add(loLit);
                        //}

                        if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                        {

                            Headerlbl.Text = "Partners Details";
                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Partnership (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt1.Rows)
                            {
                                i++;
                                html += "<tr><td>" + i.ToString() + "</td><td>" + dr["PartnerName"].ToString() + "</td><td>" + dr["PartnershipPer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                            }

                            PH1.Controls.Clear();
                            html += "</table>";
                            Literal loLit = new Literal();
                            loLit.Text = (html);
                            PH1.Controls.Add(loLit);
                        }

                        if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                        {

                            Headerlbl.Text = "Trustee Details";


                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt1.Rows)
                            {
                                i++;
                                html += "<tr><td>" + i.ToString() + "</td><td>" + dr["TrusteeName"].ToString() + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                            }

                            PH1.Controls.Clear();
                            html += "</table>";
                            Literal loLit = new Literal();
                            loLit.Text = (html);
                            PH1.Controls.Add(loLit);
                        }






                        if (dt_project.Rows[0]["EnvironmentalClearances"].ToString().Trim()=="1")
                        {
                            EnvironmentalClearances.Text = "Yes";
                        }
                        else
                        {
                            EnvironmentalClearances.Text = "NO";
                        }
                        //EnvironmentalClearances.Text = dt_project.Rows[0]["EnvironmentalClearances"].ToString().Trim();
                        OperationsandMaintenancetobeTakenupby.Text = dt_project.Rows[0]["OperationsandMaintenancetobeTakenupby"].ToString().Trim();
                        CashFlowProjections.Text = dt_project.Rows[0]["CashFlowProjections"].ToString().Trim();


                        ProjectedInflowinCrYear1.Text = dt_project.Rows[0]["ProjectedInflowinCrYear1"].ToString().Trim();
                        ProjectedOutflowinCrYear1.Text = dt_project.Rows[0]["ProjectedOutflowinCrYear1"].ToString().Trim();

                        ProjectedInflowinCrYear2.Text = dt_project.Rows[0]["ProjectedInflowinCrYear2"].ToString().Trim();
                        ProjectedOutflowinCrYear2.Text = dt_project.Rows[0]["ProjectedOutflowinCrYear2"].ToString().Trim();



                        ProjectedInflowinCrYear3.Text = dt_project.Rows[0]["ProjectedInflowinCrYear3"].ToString().Trim();
                        ProjectedOutflowinCrYear3.Text = dt_project.Rows[0]["ProjectedOutflowinCrYear3"].ToString().Trim();



                        ProjectedInflowinCrYear4.Text = dt_project.Rows[0]["ProjectedInflowinCrYear4"].ToString().Trim();
                        ProjectedOutflowinCrYear4.Text = dt_project.Rows[0]["ProjectedOutflowinCrYear4"].ToString().Trim();


                        ProjectedInflowinCrYear5.Text = dt_project.Rows[0]["ProjectedInflowinCrYear5"].ToString().Trim();
                        ProjectedOutflowinCrYear5.Text = dt_project.Rows[0]["ProjectedOutflowinCrYear5"].ToString().Trim();


                        BuildingPlanApprovalStatus.Text = dt_project.Rows[0]["BuildingPlanApprovalStatus"].ToString().Trim();
                        BuildingPlanApprovedfromAuthority.Text = dt_project.Rows[0]["BuildingPlanApprovedfromAuthority"].ToString().Trim();
                        BuildingPlanApplicationIdOBPAS.Text = dt_project.Rows[0]["BuildingPlanApplicationIdOBPAS"].ToString().Trim();
                        OwnershipofHostelDormitoryCompany.Text = dt_project.Rows[0]["OwnershipofHostelDormitoryCompany"].ToString().Trim();
                        AnyOtherInformation.Text = dt_project.Rows[0]["AnyOtherInformation"].ToString().Trim();

                    }

                    if (dt_doc.Rows.Count > 0)
                    {

                        html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>CheckList </th><th>Checklist Description</th><th>Document uploaded</th></tr>";
                        foreach (DataRow dr in dt_doc.Rows)
                        {
                            j++;
                            string founder = dr["Path"].ToString();
                            // Remove all characters after first 25 chars
                            string first25 = founder.Remove(0, 1);
                            html1 += "<tr><td>" + j.ToString() + "</td><td>" + dr["ServiceTimeLinesCondition"].ToString() + "</td><td>" + dr["ServiceTimeLinesDocuments"] + "</td><td><a href='" + first25 + "' target='_blank'>View Document</a></td></tr>";
                        }

                        PH2.Controls.Clear();
                        html1 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html1);
                        PH2.Controls.Add(loLit1);
                    }
                    //if (dt_doc.Rows.Count > 0)
                    //{

                    //    html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                    //            <tr><th> S.NO </th><th>CheckList </th><th>Checklist Description</th><th>Document uploaded</th></tr>";
                    //    foreach (DataRow dr in dt_doc.Rows)
                    //    {
                    //        j++;

                    //        //html1 += "<tr><td>" + j.ToString() + "</td><td>" + dr["ServiceTimeLinesCondition"].ToString() + "</td><td>" + dr["ServiceTimeLinesDocuments"] + "</td><td>" + dr["Name"] + "</td></tr>";
                    //    }

                    //    PH2.Controls.Clear();
                    //    html1 += "</table>";
                    //    Literal loLit1 = new Literal();
                    //    loLit1.Text = (html1);
                    //    PH2.Controls.Add(loLit1);
                    //}



                    if (dt_Land.Rows.Count > 0)
                    {

                        html3 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr>          
<th> S.NO </th>
<th>Area Details (District, Tehsil, Village)</th>
<th>Land Details (Deed Date), Khasra Number</th>
<th>Land Area (In Hectare)</th>
<th>Value of land (inr cr)</th>
<th>Stamp Duty Paid (inr cr)</th>
<th>Existing Project area land Use</th>
<th>Project area land contiguous</th>
<th>Gram sabha/ government land Involvement</th>
<th>Requirement of Land Exchange</th>
<th>Other Details</th>
<th>Land Conversion Charges Paid, if any (in Cr):</th>
<th>Registration Fees Paid (in Cr):</th>


                       </tr>";
                        foreach (DataRow dr in dt_Land.Rows)
                        {
                            l++;
                            html3 += "<tr><td>" + l.ToString() + "</td><td>" + dr["District"].ToString() + ", " +  dr["Tehsil"].ToString() + ", " + dr["Village"].ToString() + "</td><td>" +   dr["LandDeedDate1"].ToString() + ", " + dr["KhasraNumber"] + "</td><td>" + dr["LandArea"] + "</td><td>" + dr["LandValue"] + "</td><td>" + dr["StampDutyPaid"] + "</td><td>" + dr["ExistingLand"] + "<br></td><td>" + dr["LandContiguousStatus"] + "<br>" + dr["LandContiguous"] + "</td><td>" + dr["GramGovStatus"] + "<br>" + dr["GramGov"] + "</td><td>" + dr["LandExchangeStatus"] + "<br>" + dr["LandExchange"] + "</td><td>" + "<br>" + dr["AnyOtherDetails"] + "</td><td>" + "<br>" + dr["LandConversionChargesPaidifanyinCr"] + "</td><td>" + "<br>" + dr["RegistrationFeesPaidinCr"] + "</td></tr>";
                        }
                        string LandArea = dt_Land.Compute("Sum(LandArea)", string.Empty).ToString();
                        string LandValue = dt_Land.Compute("Sum(LandValue)", string.Empty).ToString();
                        string StampDutyPaid = dt_Land.Compute("Sum(StampDutyPaid)", string.Empty).ToString();
                        html3 += "<tr style='background-color: #ccc;'><td colspan='3' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandArea + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandValue + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + StampDutyPaid + "</td><td colspan='5' style='text-align: left;padding:  0 5px;border:1px solid #797979;'></td></tr>";

                        PH3.Controls.Clear();
                        html3 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html3);
                        PH3.Controls.Add(loLit1);
                    }


                    if (dt_Obj.Rows.Count > 0)
                    {
                        ObjectionDiv.Visible = true;
                        string html2 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>Objection</th><th>Objection Date</th><th>Response</th><th>Response Date</th></tr>";
                        foreach (DataRow dr in dt_Obj.Rows)
                        {
                            k++;
                            html2 += "<tr><td>" + k.ToString() + "</td><td>" + dr["Objection"].ToString() + "</td><td>" + dr["RaisedOnDate"] + "</td><td>" + dr["Response"] + "</td><td>" + dr["ResponseOnDate"] + "</td></tr>";
                        }

                        PHObjection.Controls.Clear();
                        html2 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html2);
                        PHObjection.Controls.Add(loLit1);
                    }
                    else
                    {
                        ObjectionDiv.Visible = false;
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }

        }

    }
}