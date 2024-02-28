using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class LAWEvaluationSheetPrint : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        SqlConnection con;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            ServiceReqNo = Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"])); ;
            GetApplicantDetails();
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private void GetApplicantDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_LAWApplicantDataForEvaluation '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                if (dt.Rows.Count > 0)
                {
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblApplicantNameAuth.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblCompanyConsitution.Text = dt.Rows[0]["Consitution"].ToString();
                    lblGSTINNumber.Text = dt.Rows[0]["GSTNo"].ToString();
                    lblAuthorisedPersonAddress.Text = dt.Rows[0]["Address1"].ToString();
                    lblCompanyAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
                    lblAuthorisedPerson.Text = dt.Rows[0]["ApplicantName"].ToString();
                    lblApplicantName.Text = dt.Rows[0]["ApplicantName"].ToString();
                    lblProjectLocationAddress.Text = dt.Rows[0]["Address2"].ToString();
                    lblProjectLocation.Text = dt.Rows[0]["Address2"].ToString();
                    lblLand.Text = dt.Rows[0]["CostoftheLand"].ToString();
                    lblCostEstimate.Text = dt.Rows[0]["Costofinfrastructures"].ToString();
                    lblBuildingWorks.Text = dt.Rows[0]["CostofthePlantMachinery"].ToString();
                    lblOtherFacilities.Text = dt.Rows[0]["OtherCost"].ToString();
                    lblProposedCapitalInvestment.Text = dt.Rows[0]["ProposedInvestment"].ToString();
                    lblTotalAmountrequested.Text = dt.Rows[0]["TotalAmountrequestedbyApplicant"].ToString();
                    lblRebateonStampDuty.Text = dt.Rows[0]["RebateonStampDuty"].ToString();
                    lblEPFReimbursement.Text = dt.Rows[0]["EPFReimbursement"].ToString();
                    lblAdditionalEPFReimbursement.Text = dt.Rows[0]["AdditionalEPFReimbursement"].ToString();
                    lblCapitalInterestSubsidy.Text = dt.Rows[0]["CapitalInterestSubsidy"].ToString();
                    lblInfrastructureInterestSubsidy.Text = dt.Rows[0]["InfrastructureInterestSubsidy"].ToString();
                    lblRebateonLanduseconversioncharges.Text = dt.Rows[0]["RebateonLanduseconversioncharges"].ToString();
                    lblExemptionfromdevelopmentcharges.Text = dt.Rows[0]["Exemptionfromdevelopmentcharges"].ToString();
                    lblElectricityRebate.Text = dt.Rows[0]["ElectricityRebate"].ToString();
                    lblWarehousingqualitycertificationreimbursement.Text = dt.Rows[0]["Warehousingqualitycertificationreimbursement"].ToString();
                    lblpayrollofdisabledworkers.Text = dt.Rows[0]["assistanceforpayrollofdisabledworkers"].ToString();
                    lblSkilldevelopmentpromotion.Text = dt.Rows[0]["Skilldevelopmentpromotion"].ToString();
                    lblIntelligentLogisticIncentives.Text = dt.Rows[0]["IntelligentLogisticIncentives"].ToString();
                    lblTypeofProject.Text = dt.Rows[0]["TypeOfProject"].ToString();
                    lblCategoryProject.Text = dt.Rows[0]["CategoryOfProject"].ToString();
                    lblRegistrationPermit.Text = dt.Rows[0]["LAWRegistrationNo"].ToString();
                    lblProposeddateforsettinguplogisticunit.Text = dt.Rows[0]["Proposeddateforsettinguplogisticunit1"].ToString();
                    lblProposedCapitalInvestment.Text = dt.Rows[0]["ProposedInvestment"].ToString();
                    lblinvestmentstarted.Text = dt.Rows[0]["DatewhenCapitalInvestmentStarted1"].ToString();
                }
                if (dt1.Rows.Count > 0)
                {
                    lblConstitutionPeople.Text = dt1.Rows[0][0].ToString().Trim();
                }
                if (dt2.Rows.Count > 0)
                {
                    txtTotalArea.Text = dt2.Rows[0]["TotalArea"].ToString();
                    txtTotalCoveredArea.Text = dt2.Rows[0]["CoveredArea"].ToString();
                   
                    txtAreaComments.Text = dt2.Rows[0]["Comment3.2.3"].ToString().Trim();
                    txtLand.Text = dt2.Rows[0]["Investment_Land"].ToString().Trim();
                    txtBuildingWorks.Text = dt2.Rows[0]["Investment_BuildingWorks"].ToString().Trim();
                    txtCostEstimate.Text = dt2.Rows[0]["Investment_Infrastructure"].ToString().Trim();
                    txtOtherFacilities.Text = dt2.Rows[0]["Investment_OtherFacilities"].ToString().Trim();
                    txtInvestmentCompliance.Text = dt2.Rows[0]["Investment_Compliance"].ToString().Trim();
                    txtApplicantName.Text = dt2.Rows[0]["ApplicantName"].ToString().Trim();
                    txtApplicantNameRemarks.Text = dt2.Rows[0]["ApplicantName_Remarks"].ToString().Trim();
                    txtCompanyVerified.Text = dt2.Rows[0]["CompanyName"].ToString().Trim();
                    txtCompanyAddressVerified.Text = dt2.Rows[0]["CompanyAddress"].ToString().Trim();
                    txtAuthorisedPersonVerified.Text = dt2.Rows[0]["AuthorisedUser"].ToString().Trim();
                    txtAuthorisedPersonAddressVerified.Text = dt2.Rows[0]["AuthorisedUserAddress"].ToString().Trim();
                    txtAddressRemarks.Text = dt2.Rows[0]["Address_Remarks"].ToString().Trim();
                    txtCompanyConstitutionVerified.Text = dt2.Rows[0]["CompanyConstitution"].ToString().Trim();
                    txtCompanyConstitutionRemarks.Text = dt2.Rows[0]["CompanyConstitution_Remarks"].ToString().Trim();
                    txtProjectLocationVerified.Text = dt2.Rows[0]["Investment_BuildingWorks"].ToString().Trim();
                    txtProjectLocationRemarks.Text = dt2.Rows[0]["ProjectLocation"].ToString().Trim();
                    txtNameofPromotersVerified.Text = dt2.Rows[0]["NamesofPromoters"].ToString().Trim();
                    txtNameofPromotersRemarks.Text = dt2.Rows[0]["NameofPromoters_Remarks"].ToString().Trim();
                    txtGSTINNumberVerified.Text = dt2.Rows[0]["GSTIN_Number"].ToString().Trim();
                    txtGSTINNumberRemarks.Text = dt2.Rows[0]["GSTIN_Number_Remarks"].ToString().Trim();
                    txtTypeofProjectVerified.Text = dt2.Rows[0]["Type_of_Project"].ToString().Trim();
                    txtTypeofProjectRemarks.Text = dt2.Rows[0]["Type_of_Project_Remarks"].ToString().Trim();
                    txtCategoryProjectVerified.Text = dt2.Rows[0]["Category_of_project"].ToString().Trim();
                    txtCategoryProjectRemarks.Text = dt2.Rows[0]["Category_of_project_Remarks"].ToString().Trim();
                    txtRegistrationPermitVerified.Text = dt2.Rows[0]["RegistrationPermit_for_setting_Logistic"].ToString().Trim();
                    txtRegistrationPermitRemarks.Text = dt2.Rows[0]["RegistrationPermit_for_setting_Logistic_Remaks"].ToString().Trim();
                    txtProposeddateforsettinguplogisticunitVerified.Text = dt2.Rows[0]["Proposed_date_for_setting_up_logistic_unit"].ToString().Trim();
                    txtProposeddateforsettinguplogisticunitRemarks.Text = dt2.Rows[0]["Proposed_date_for_setting_up_logistic_unit_Remarks"].ToString().Trim();
                    txtProposedCapitalInvestmentVerified.Text = dt2.Rows[0]["ProposedCapitalInvestment"].ToString().Trim();
                    txtProposedCapitalInvestmentRemarks.Text = dt2.Rows[0]["ProposedCapitalInvestment_Remarks"].ToString().Trim();
                    txtdatewhencapitalinvestmentstartedVerified.Text = dt2.Rows[0]["date_capital_investment_started"].ToString().Trim();
                    txtdatewhencapitalinvestmentstartedReamrks.Text = dt2.Rows[0]["date_capital_investment_started_Remarks"].ToString().Trim();
                    txtTotalAmountrequestedVerified.Text = dt2.Rows[0]["Total_Amount_by_Applicant"].ToString().Trim();
                    txtTotalAmountrequestedRemarks.Text = dt2.Rows[0]["Total_Amount_by_Applicant_Remarks"].ToString().Trim();
                    txtRebateonStampDutyVerified.Text = dt2.Rows[0]["RebateonStampDuty"].ToString().Trim();
                    txtRebateonStampDutyRemarks.Text = dt2.Rows[0]["RebateonStampDuty_Remarks"].ToString().Trim();
                    txtEPFReimbursementVerified.Text = dt2.Rows[0]["EPFReimbursement"].ToString().Trim();
                    txtEPFReimbursementRemarks.Text = dt2.Rows[0]["EPFReimbursement_Remarks"].ToString().Trim();
                    txtAdditionalEPFReimbursementVerified.Text = dt2.Rows[0]["Additional_EPF_Reimbursement"].ToString().Trim();
                    txtAdditionalEPFReimbursementRemarks.Text = dt2.Rows[0]["Additional_EPF_Reimbursement_Remarks"].ToString().Trim();
                    txtCapitalInterestSubsidyVerified.Text = dt2.Rows[0]["Capital_Interest_Subsidy"].ToString().Trim();
                    txtCapitalInterestSubsidyRemarks.Text = dt2.Rows[0]["Capital_Interest_Subsidy_Remarks"].ToString().Trim();
                    txtInfrastructureInterestSubsidyVerified.Text = dt2.Rows[0]["InfrastructureInterestSubsidy"].ToString().Trim();
                    txtInfrastructureInterestSubsidyRemarks.Text = dt2.Rows[0]["InfrastructureInterestSubsidy_Remarks"].ToString().Trim();
                    txtRebateonLanduseconversionchargesVerfied.Text = dt2.Rows[0]["RebateonLanduseconversioncharges"].ToString().Trim();
                    txtRebateonLanduseconversionchargesRemarks.Text = dt2.Rows[0]["RebateonLanduseconversioncharges_Remarks"].ToString().Trim();
                    txtExemptionfromdevelopmentchargesVerified.Text = dt2.Rows[0]["Exemptionfromdevelopmentcharges"].ToString().Trim();
                    txtExemptionfromdevelopmentchargesRemarks.Text = dt2.Rows[0]["Exemptionfromdevelopmentcharges_Remarks"].ToString().Trim();
                    txtElectricityRebateVerified.Text = dt2.Rows[0]["ElectricityRebate"].ToString().Trim();
                    txtElectricityRebateRemarks.Text = dt2.Rows[0]["ElectricityRebate_Remarks"].ToString().Trim();
                    txtWarehousingqualitycertificationreimbursementVerified.Text = dt2.Rows[0]["Warehousingqualitycertificationreimbursement"].ToString().Trim();
                    txtWarehousingqualitycertificationreimbursementRemarks.Text = dt2.Rows[0]["Warehousingqualitycertificationreimbursement_remarks"].ToString().Trim();
                    txtpayrollofdisabledworkersVerified.Text = dt2.Rows[0]["monthassistanceforpayrollofdisabledworkers"].ToString().Trim();
                    txtpayrollofdisabledworkersRemarks.Text = dt2.Rows[0]["monthassistanceforpayrollofdisabledworkers_Remarks"].ToString().Trim();
                    txtSkilldevelopmentpromotionVerified.Text = dt2.Rows[0]["Skilldevelopmentpromotion"].ToString().Trim();
                    txtSkilldevelopmentpromotionRemarks.Text = dt2.Rows[0]["Skilldevelopmentpromotion_Remarks"].ToString().Trim();
                    txtIntelligentLogisticIncentivesVerified.Text = dt2.Rows[0]["IntelligentLogisticIncentives"].ToString().Trim();
                    txtIntelligentLogisticIncentivesRemarks.Text = dt2.Rows[0]["IntelligentLogisticIncentives_Remarks"].ToString().Trim();
                    txtRegistrationCertificateRemarks.Text = dt2.Rows[0]["Compliance_1"].ToString().Trim();
                    txtAuditedbalancesheetRemarks.Text = dt2.Rows[0]["Compliance_2"].ToString().Trim();
                    txtDetailedProjectReportRemarks.Text = dt2.Rows[0]["Compliance_3"].ToString().Trim();
                    txtMoARemarks.Text = dt2.Rows[0]["Compliance_4"].ToString().Trim();
                    txtEngineercertificateRemarks.Text = dt2.Rows[0]["Compliance_5"].ToString().Trim();
                    txtAffidavitRemarks.Text = dt2.Rows[0]["Compliance_6"].ToString().Trim();




                }
                if (dt3.Rows.Count > 0)
                {
                    Grid_Comments.DataSource = dt3;
                    Grid_Comments.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


}