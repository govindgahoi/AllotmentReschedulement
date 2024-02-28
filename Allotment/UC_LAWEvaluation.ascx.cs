using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_LAWEvaluation : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        public string ServiceReqNo { get; set; }
        public string HiddenClassNameEx { get; private set; }
        public string HiddenClassNamePr { get; private set; }
        #endregion
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);            
            BindDetails();
            BindEvaluationData();
        }
    
        protected void Grid_Comments_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Comments_and_description"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_Comments_and_description"] = dt;
            dt.AcceptChanges();

            temp_Comments_details_DataBind();
        }
      
        protected void insert_Comments_details(object sender, EventArgs e)
        {
           
            DataTable dt = (DataTable)ViewState["temp_Comments_and_description"];

            string ClauseasperPolicy              = (Grid_Comments.FooterRow.FindControl("txtClauseasperPolicy_insert") as TextBox).Text;
            string Description                    = (Grid_Comments.FooterRow.FindControl("txtDescription_insert") as TextBox).Text;
            string Clausedescription              = (Grid_Comments.FooterRow.FindControl("txtClausedescription_insert") as TextBox).Text;
            string IncentivesSeekaspertheproposal = (Grid_Comments.FooterRow.FindControl("txtIncentivesSeekaspertheproposal_insert") as TextBox).Text;
            string BenefitEligibility             = (Grid_Comments.FooterRow.FindControl("txtBenefitEligibility_insert") as TextBox).Text;


            if (ClauseasperPolicy != "")
            {
                if (Description != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ClauseasperPolicy"] = ClauseasperPolicy;
                    dr["Description"] = Description;
                    dr["Clausedescription"] = Clausedescription;
                    dr["IncentivesSeekaspertheproposal"] = IncentivesSeekaspertheproposal;
                    dr["BenefitEligibility"] = BenefitEligibility;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_Comments_and_description"] = dt;
                    temp_Comments_details_DataBind();

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide ShareHolder Name');", true);
                return;
            }

        }

        public void temp_Comments_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_Comments_and_description"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Grid_Comments.DataSource = dt;
                Grid_Comments.DataBind();
                Grid_Comments.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Grid_Comments.DataSource = dt;
                Grid_Comments.DataBind();
            }


        }

        private void BindDetails()
        {
            SqlCommand cmd = new SqlCommand("sp_getLAWEvaluationDetails '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            if (dt.Rows.Count >= 0)
            {
                if (ViewState["temp_Comments_and_description"] == null || ViewState["temp_Comments_and_description"].Equals(""))
                {
                    DataTable temp_Comments_and_description = new DataTable();
                    temp_Comments_and_description.TableName = "temp_Comments_and_description";
                    temp_Comments_and_description.Columns.Add(new DataColumn("Annexures", typeof(string)));
                    ViewState["temp_Comments_and_description"] = temp_Comments_and_description;
                    temp_Comments_and_description.Columns.Add(new DataColumn("ClauseasperPolicy", typeof(string)));
                    temp_Comments_and_description.Columns.Add(new DataColumn("Description", typeof(decimal)));
                    temp_Comments_and_description.Columns.Add(new DataColumn("Clausedescription", typeof(string)));
                    temp_Comments_and_description.Columns.Add(new DataColumn("IncentivesSeekaspertheproposal", typeof(string)));
                    temp_Comments_and_description.Columns.Add(new DataColumn("BenefitEligibility", typeof(string)));
                    ViewState["temp_Comments_and_description"] = dt;
                    temp_Comments_details_DataBind();
                }
            }
           
        }

        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                objServiceTimelinesBEL.ServiceRequestNO                                           = ServiceReqNo.Trim();
                objServiceTimelinesBEL.VerifiedArea                                               = txtTotalArea.Text.Trim();
                objServiceTimelinesBEL.VerifiedCoveredArea                                        = txtTotalCoveredArea.Text.Trim();
                objServiceTimelinesBEL.Compliance3_2_3                                            = drp1.SelectedValue.Trim();
                objServiceTimelinesBEL.Commment3_2_3                                              = txtAreaComments.Text.Trim();
                objServiceTimelinesBEL.Investment_Land                                            = txtLand.Text.Trim();
                objServiceTimelinesBEL.Investment_BuildingWorks                                   = txtBuildingWorks.Text.Trim();
                objServiceTimelinesBEL.Investment_Infrastructure                                  = txtCostEstimate.Text.Trim();
                objServiceTimelinesBEL.Investment_OtherFacilities                                 = txtOtherFacilities.Text.Trim();
                objServiceTimelinesBEL.Investment_Compliance                                      = txtInvestmentCompliance.Text.Trim();
                objServiceTimelinesBEL.ApplicantNameVerified                                      = txtApplicantName.Text.Trim();
                objServiceTimelinesBEL.ApplicantName_Remarks                                      = txtApplicantNameRemarks.Text.Trim();
                objServiceTimelinesBEL.CompanyNameVerified                                        = txtCompanyVerified.Text.Trim();
                objServiceTimelinesBEL.CompanyAddressVerified                                     = txtCompanyAddressVerified.Text.Trim();
                objServiceTimelinesBEL.AuthorisedUserVerified                                     = txtAuthorisedPersonVerified.Text.Trim();
                objServiceTimelinesBEL.AuthorisedUserAddressVerified                              = txtAuthorisedPersonAddressVerified.Text.Trim();
                objServiceTimelinesBEL.Address_Remarks                                            = txtAddressRemarks.Text.Trim();
                objServiceTimelinesBEL.CompanyConstitutionVerified                                = txtCompanyConstitutionVerified.Text.Trim();
                objServiceTimelinesBEL.CompanyConstitution_Remarks                                = txtCompanyConstitutionRemarks.Text.Trim();
                objServiceTimelinesBEL.ProjectLocationVerified                                    = txtProjectLocationVerified.Text.Trim();
                objServiceTimelinesBEL.ProjectLocationRemarks                                     = txtProjectLocationRemarks.Text.Trim();
                objServiceTimelinesBEL.NamesofPromotersVerified                                   = txtNameofPromotersVerified.Text.Trim();
                objServiceTimelinesBEL.NameofPromoters_Remarks                                    = txtNameofPromotersRemarks.Text.Trim();
                objServiceTimelinesBEL.GSTIN_NumberVerified                                       = txtGSTINNumberVerified.Text.Trim();
                objServiceTimelinesBEL.GSTIN_Number_Remarks                                       = txtGSTINNumberRemarks.Text.Trim();
                objServiceTimelinesBEL.Type_of_ProjectVerified                                    = txtTypeofProjectVerified.Text.Trim();
                objServiceTimelinesBEL.Type_of_Project_Remarks                                    = txtTypeofProjectRemarks.Text.Trim();
                objServiceTimelinesBEL.Category_of_projectVerified                                = txtCategoryProjectVerified.Text.Trim();
                objServiceTimelinesBEL.Category_of_project_Remarks                                = txtCategoryProjectRemarks.Text.Trim();
                objServiceTimelinesBEL.RegistrationPermit_for_setting_LogisticVerified            = txtRegistrationPermitVerified.Text.Trim();
                objServiceTimelinesBEL.RegistrationPermit_for_setting_Logistic_Remarks            = txtRegistrationPermitRemarks.Text.Trim();
                objServiceTimelinesBEL.Proposed_date_for_setting_up_logistic_unitVerified         = txtProposeddateforsettinguplogisticunitVerified.Text.Trim();
                objServiceTimelinesBEL.Proposed_date_for_setting_up_logistic_unit_Remarks         = txtProposeddateforsettinguplogisticunitRemarks.Text.Trim();
                objServiceTimelinesBEL.ProposedCapitalInvestmentVerified                          = txtProposedCapitalInvestmentVerified.Text.Trim();
                objServiceTimelinesBEL.ProposedCapitalInvestment_Remarks                          = txtProposedCapitalInvestmentRemarks.Text.Trim();
                objServiceTimelinesBEL.date_capital_investment_startedVerified                    = txtdatewhencapitalinvestmentstartedVerified.Text.Trim();
                objServiceTimelinesBEL.date_capital_investment_started_Remarks                    = txtdatewhencapitalinvestmentstartedReamrks.Text.Trim();
                objServiceTimelinesBEL.Total_Amount_by_ApplicantVerified                          = txtTotalAmountrequestedVerified.Text.Trim();
                objServiceTimelinesBEL.Total_Amount_by_Applicant_Remarks                          = txtTotalAmountrequestedRemarks.Text.Trim();
                objServiceTimelinesBEL.RebateonStampDutyVerified                                  = txtRebateonStampDutyVerified.Text.Trim();
                objServiceTimelinesBEL.RebateonStampDuty_Remarks                                  = txtRebateonStampDutyRemarks.Text.Trim();
                objServiceTimelinesBEL.EPFReimbursementVerified                                   = txtEPFReimbursementVerified.Text.Trim();
                objServiceTimelinesBEL.EPFReimbursement_Remarks                                   = txtEPFReimbursementRemarks.Text.Trim();
                objServiceTimelinesBEL.Additional_EPF_ReimbursementVerified                       = txtAdditionalEPFReimbursementVerified.Text.Trim();
                objServiceTimelinesBEL.Additional_EPF_Reimbursement_Remarks                       = txtAdditionalEPFReimbursementRemarks.Text.Trim();
                objServiceTimelinesBEL.Capital_Interest_SubsidyVerified                           = txtCapitalInterestSubsidyVerified.Text.Trim();
                objServiceTimelinesBEL.Capital_Interest_Subsidy_Remarks                           = txtCapitalInterestSubsidyRemarks.Text.Trim();
                objServiceTimelinesBEL.InfrastructureInterestSubsidyVerified                      = txtInfrastructureInterestSubsidyVerified.Text.Trim();
                objServiceTimelinesBEL.InfrastructureInterestSubsidy_Remarks                      = txtInfrastructureInterestSubsidyRemarks.Text.Trim();
                objServiceTimelinesBEL.RebateonLanduseconversionchargesVerified                   = txtRebateonLanduseconversionchargesVerfied.Text.Trim();
                objServiceTimelinesBEL.RebateonLanduseconversioncharges_Remarks                   = txtRebateonLanduseconversionchargesRemarks.Text.Trim();
                objServiceTimelinesBEL.ExemptionfromdevelopmentchargesVerified                    = txtExemptionfromdevelopmentchargesVerified.Text.Trim();
                objServiceTimelinesBEL.Exemptionfromdevelopmentcharges_Remarks                    = txtExemptionfromdevelopmentchargesRemarks.Text.Trim();
                objServiceTimelinesBEL.ElectricityRebateVerified                                  = txtElectricityRebateVerified.Text.Trim();
                objServiceTimelinesBEL.ElectricityRebate_Remarks                                  = txtElectricityRebateRemarks.Text.Trim();
                objServiceTimelinesBEL.WarehousingqualitycertificationreimbursementVerified       = txtWarehousingqualitycertificationreimbursementVerified.Text.Trim();
                objServiceTimelinesBEL.Warehousingqualitycertificationreimbursement_remarks       = txtWarehousingqualitycertificationreimbursementRemarks.Text.Trim();
                objServiceTimelinesBEL.monthassistanceforpayrollofdisabledworkersVerified         = txtpayrollofdisabledworkersVerified.Text.Trim();
                objServiceTimelinesBEL.monthassistanceforpayrollofdisabledworkers_Remarks         = txtpayrollofdisabledworkersRemarks.Text.Trim();
                objServiceTimelinesBEL.SkilldevelopmentpromotionVerified                          = txtSkilldevelopmentpromotionVerified.Text.Trim();
                objServiceTimelinesBEL.Skilldevelopmentpromotion_Remarks                          = txtSkilldevelopmentpromotionRemarks.Text.Trim();
                objServiceTimelinesBEL.IntelligentLogisticIncentivesVerified                      = txtIntelligentLogisticIncentivesVerified.Text.Trim();
                objServiceTimelinesBEL.IntelligentLogisticIncentives_Remarks                      = txtIntelligentLogisticIncentivesRemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_1                                               = txtRegistrationCertificateRemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_2                                               = txtAuditedbalancesheetRemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_3                                               = txtDetailedProjectReportRemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_4                                               = txtMoARemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_5                                               = txtEngineercertificateRemarks.Text.Trim();
                objServiceTimelinesBEL.Compliance_6                                               = txtAffidavitRemarks.Text.Trim();
                retval = objServiceTimelinesBLL.UpdateEvaluationDetailsLAW(objServiceTimelinesBEL);
                if (retval >= 0)
                {
                    objServiceTimelinesBEL.LAWID = ServiceReqNo.Trim();
                    int retVal2 = objServiceTimelinesBLL.ClearCommentsDescriptionLAW(objServiceTimelinesBEL);
                    if (retVal2 >= 0)
                    {

                        DataTable temp = (DataTable)ViewState["temp_Comments_and_description"];
                        if (temp.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in temp.Rows)
                            {

                                string ClauseasperPolicy              = dr1["ClauseasperPolicy"].ToString();
                                string Description                    = dr1["Description"].ToString();
                                string Clausedescription              = dr1["Clausedescription"].ToString();
                                string IncentivesSeekaspertheproposal = dr1["IncentivesSeekaspertheproposal"].ToString();
                                string BenefitEligibility             = dr1["BenefitEligibility"].ToString();

                                objServiceTimelinesBEL.ClauseasperPolicy              = ClauseasperPolicy.Trim();
                                objServiceTimelinesBEL.Description                    = Description.Trim();
                                objServiceTimelinesBEL.Clausedescription              = Clausedescription.Trim();
                                objServiceTimelinesBEL.IncentivesSeekaspertheproposal = IncentivesSeekaspertheproposal.Trim();
                                objServiceTimelinesBEL.BenefitEligibility             = BenefitEligibility;

                                retval = objServiceTimelinesBLL.SaveCommentsDescriptionLAW(objServiceTimelinesBEL);

                            }

                        }
                        if (retval >= 0)
                        {
                            string message = "Applicant Details Saved Successfully";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                }



               

            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
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


        private void BindEvaluationData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_LAWApplicantDataForEvaluation '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                
                DataTable dt  = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                if (dt.Rows.Count > 0)
                {
                    lblCompanyName.Text                                  = dt.Rows[0]["CompanyName"].ToString();
                    lblApplicantNameAuth.Text                            = dt.Rows[0]["CompanyName"].ToString();
                    lblCompanyConsitution.Text                           = dt.Rows[0]["Consitution"].ToString();
                    lblGSTINNumber.Text                                  = dt.Rows[0]["GSTNo"].ToString();
                    lblAuthorisedPersonAddress.Text                      = dt.Rows[0]["Address1"].ToString();
                    lblCompanyAddress.Text                               = dt.Rows[0]["CompanyAddress"].ToString();
                    lblAuthorisedPerson.Text                             = dt.Rows[0]["ApplicantName"].ToString();
                    lblApplicantName.Text                                = dt.Rows[0]["ApplicantName"].ToString();
                    lblProjectLocationAddress.Text                       = dt.Rows[0]["Address2"].ToString();
                    lblProjectLocation.Text                              = dt.Rows[0]["Address2"].ToString();
                    lblLand.Text                                         = dt.Rows[0]["CostoftheLand"].ToString();
                    lblCostEstimate.Text                                 = dt.Rows[0]["Costofinfrastructures"].ToString();
                    lblBuildingWorks.Text                                = dt.Rows[0]["CostofthePlantMachinery"].ToString();
                    lblOtherFacilities.Text                              = dt.Rows[0]["OtherCost"].ToString();
                    lblProposedCapitalInvestment.Text                    = dt.Rows[0]["ProposedInvestment"].ToString();
                    lblTotalAmountrequested.Text                         = dt.Rows[0]["TotalAmountrequestedbyApplicant"].ToString();
                    lblRebateonStampDuty.Text                            = dt.Rows[0]["RebateonStampDuty"].ToString();
                    lblEPFReimbursement.Text                             = dt.Rows[0]["EPFReimbursement"].ToString();
                    lblAdditionalEPFReimbursement.Text                   = dt.Rows[0]["AdditionalEPFReimbursement"].ToString();
                    lblCapitalInterestSubsidy.Text                       = dt.Rows[0]["CapitalInterestSubsidy"].ToString();
                    lblInfrastructureInterestSubsidy.Text                = dt.Rows[0]["InfrastructureInterestSubsidy"].ToString();
                    lblRebateonLanduseconversioncharges.Text             = dt.Rows[0]["RebateonLanduseconversioncharges"].ToString();
                    lblExemptionfromdevelopmentcharges.Text              = dt.Rows[0]["Exemptionfromdevelopmentcharges"].ToString();
                    lblElectricityRebate.Text                            = dt.Rows[0]["ElectricityRebate"].ToString();
                    lblWarehousingqualitycertificationreimbursement.Text = dt.Rows[0]["Warehousingqualitycertificationreimbursement"].ToString();
                    lblpayrollofdisabledworkers.Text                     = dt.Rows[0]["assistanceforpayrollofdisabledworkers"].ToString();
                    lblSkilldevelopmentpromotion.Text                    = dt.Rows[0]["Skilldevelopmentpromotion"].ToString();
                    lblIntelligentLogisticIncentives.Text                = dt.Rows[0]["IntelligentLogisticIncentives"].ToString();
                    lblTypeofProject.Text                                = dt.Rows[0]["TypeOfProject"].ToString();
                    lblCategoryProject.Text                              = dt.Rows[0]["CategoryOfProject"].ToString();
                    lblRegistrationPermit.Text                           = dt.Rows[0]["UdyogAadhaarNo"].ToString();
                    lblProposeddateforsettinguplogisticunit.Text         = dt.Rows[0]["Proposeddateforsettinguplogisticunit1"].ToString();
                    lblProposedCapitalInvestment.Text                    = dt.Rows[0]["ProposedInvestment"].ToString();
                    lblinvestmentstarted.Text                            = dt.Rows[0]["DatewhenCapitalInvestmentStarted1"].ToString();

                     lblProposedArea.Text =  dt.Rows[0]["TotalArea"].ToString();
                    lblProposedCoveredArea.Text = dt.Rows[0]["CoveredArea"].ToString();
                }
                if(dt1.Rows.Count>0)
                {
                    lblConstitutionPeople.Text = dt1.Rows[0][0].ToString().Trim();
                }
                if(dt2.Rows.Count>0)
                {
                    txtTotalArea.Text         = dt2.Rows[0]["TotalArea"].ToString();
                    txtTotalCoveredArea.Text  = dt2.Rows[0]["CoveredArea"].ToString();
                    drp1.SelectedValue        = dt2.Rows[0]["Compliance3.2.3"].ToString().Trim();
                    txtAreaComments.Text      = dt2.Rows[0]["Comment3.2.3"].ToString().Trim();
                    txtLand.Text              = dt2.Rows[0]["Investment_Land"].ToString().Trim();
                    txtBuildingWorks.Text     = dt2.Rows[0]["Investment_BuildingWorks"].ToString().Trim();
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
                if(dt3.Rows.Count>0)
                {
                    ViewState["temp_Comments_and_description"] = dt3;
                    temp_Comments_details_DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo.Trim()));
            Response.Write("<script>window.open ('LAWEvaluationSheetPrint.aspx?ID="+ID+"','_blank');</script>");


        }
    }
}