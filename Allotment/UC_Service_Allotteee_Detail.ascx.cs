using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;




namespace Allotment
{
    public partial class UC_Service_Allotteee_Detail : System.Web.UI.UserControl
    {

        SqlConnection con = new SqlConnection();

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";

        public Label AllotmentNo
        {
            get
            {
                return lblAllotmentNo;
            }
            set
            {
                lblAllotmentNo = value;
            }
        }

        public string AllotteeId { get; set; }
        public string ServiceReqNo { get; set; }





        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }





            if (string.IsNullOrEmpty(AllotteeId)) { AllotteeId = ""; }


            if (AllotmentNo.Text.Length > 0 || AllotteeId.Length > 0)
            {
                uc_alloottee_details.Visible = true;
                bindUserData(AllotmentNo.Text, AllotteeId);
            }
            else
            {
                uc_alloottee_details.Visible = false;
            }
        }

        private void Objections()
        {
            SqlCommand cmd = new SqlCommand("GetBPobjection '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                clearence4.DataSource = dt;
                clearence4.DataBind();
            }
            else
            {
                clearence4.DataSource = null;
                clearence4.DataBind();
            }

        }



        public void bindUserData(string allottee, string allotteeId)
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                objServiceTimelinesBEL.AllotmentNo = lblAllotmentNo.Text;


                if (!string.IsNullOrEmpty(AllotteeId))
                {
                    objServiceTimelinesBEL.AllotteeID = int.Parse(AllotteeId);

                }


                ds = objServiceTimelinesBLL.GetAllAllotteeDetailsFilledById(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];
                DataTable dt4 = ds.Tables[3];
                DataTable dt5 = ds.Tables[4];
                DataTable dt6 = ds.Tables[6];
                DataTable dt7 = ds.Tables[7];

                if (dt1.Rows.Count > 0)
                {





                    lblApplicationLetter.Text = dt1.Rows[0]["ref_AllotmentNo"].ToString().Trim();
                    lblALlotmentDate.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();
                    lblAllotmentNo.Text = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();


                    lblAllotteeRegionalOffice.Text = dt1.Rows[0]["RegionalOffice"].ToString().Trim();
                    lblIndustrialArea.Text = dt1.Rows[0]["IndustrialArea"].ToString().Trim();
                    lblPlotNo.Text = dt1.Rows[0]["PlotNo"].ToString().Trim();



                    SqlCommand cmd11 = new SqlCommand("select IssueID, Description, IssueDate, CurrentStatus, ClearenceStatus, PlotNo, SectionID from [Plot_Clearence] where  PlotNo = '" + lblPlotNo.Text + "' ", con);
                    SqlDataAdapter adp1 = new SqlDataAdapter(cmd11);
                    DataTable dtclearence = new DataTable();
                    adp1.Fill(dtclearence);



                    string sortOrder = "IssueDate ASC";
                    string query = "";


                    DataTable dtclearence1, dtclearence2, dtclearence3, dtclearence4, dtclearence5, dtclearence6;

                    query = "SectionID = 1";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence1 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence1 = null; }


                    query = "SectionID = 2";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence2 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence2 = null; }


                    query = "SectionID = 3";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence3 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence3 = null; }



                    query = "SectionID = 4";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence4 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence4 = null; }


                    query = "SectionID = 5";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence5 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence5 = null; }



                    query = "SectionID = 6";
                    if (dtclearence.Select(query, sortOrder).Count() > 0)
                    {
                        dtclearence6 = dtclearence.Select(query, sortOrder).CopyToDataTable();
                    }
                    else { dtclearence6 = null; }








                    clearence1.DataSource = dtclearence1; clearence1.DataBind();
                    clearence2.DataSource = dtclearence2; clearence2.DataBind();
                    clearence3.DataSource = dtclearence3; clearence3.DataBind();
                    //clearence4.DataSource = dtclearence4; clearence4.DataBind();
                    clearence5.DataSource = dtclearence5; clearence5.DataBind();
                    clearence6.DataSource = dtclearence6; clearence6.DataBind();



                    lblPossessionDate.Text = dt2.Rows[0]["DateOfPossession"].ToString();
                    lblPossessionArea.Text = dt2.Rows[0]["PossessionArea"].ToString();

                    lblLeaseDeedDate.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();
                    lblLeaseDeedExecutionDate.Text = dt2.Rows[0]["LeaseAgreementExecDate"].ToString();










                    lblAllottedinNameof.Text = dt1.Rows[0]["AllotteeName"].ToString();
                    lblAuthorizedUser.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                    lblAllottedArea.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();

                    lblFirmCompanyConstruction.Text = dt1.Rows[0]["CompanyName"].ToString();
                    lblFirmConstitution.Text = dt1.Rows[0]["CompanyType"].ToString();
                    lblCINNo.Text = dt1.Rows[0]["CinNo"].ToString();
                    lblPANNo.Text = dt1.Rows[0]["PanNo"].ToString();
                    lblEmail.Text = dt1.Rows[0]["emailID"].ToString();
                    lblPhoneNo.Text = dt1.Rows[0]["PhoneNo"].ToString();
                    //lblCorAddress.Text =
                    //lblApplicationId.Text =

                }

                Objections();
                //                if (dt1.Rows.Count > 0)
                //                {

                //                    //      ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(dt1.Rows[0]["IndustrialArea"].ToString().Trim()));


                //                    ddlcompanytype.SelectedValue = dt1.Rows[0]["FirmConstitution"].ToString().Trim();

                //                    lblSector.Text = dt1.Rows[0]["Sector"].ToString().Trim();
                //                    lblSector1.Text = dt1.Rows[0]["Sector"].ToString().Trim();

                //                    lblAuthoriseduseremail.Text = dt1.Rows[0]["SignatoryEmail"].ToString().Trim();
                //                    lblAuthoriseduseraddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString().Trim();
                //                    lblfileNo.Text = dt1.Rows[0]["FileNo"].ToString().Trim();
                //                    LblFileNo1.Text = dt1.Rows[0]["FileNo"].ToString().Trim();

                //                    if (dt5.Rows.Count > 0)
                //                    {


                //                    lblletterno.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                //                    lblAuthorisedSignatory.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                //                    lblCompany.Text = dt1.Rows[0]["CompanyName"].ToString();
                //                    lblConstitution.Text = dt1.Rows[0]["CompanyType"].ToString();

                //                    lblmobile.Text = dt1.Rows[0]["SignatoryPhone"].ToString();

                //                    lblPan.Text = dt1.Rows[0]["PanNo"].ToString();
                //                    lblCin.Text = dt1.Rows[0]["CinNo"].ToString();
                //                    lblPlotno.Text = dt1.Rows[0]["PlotNo"].ToString();
                //                    lblindarea.Text = dt1.Rows[0]["IndustrialArea"].ToString();

                //                    lblallotmentdate.Text = dt1.Rows[0]["AllotmenttLetterApplicationDate"].ToString();



                //                    Label27.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                //                    Label23.Text = dt1.Rows[0]["CompanyName"].ToString();
                //                    Label24.Text = dt1.Rows[0]["CompanyType"].ToString();
                //                    Label29.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                //                    Label28.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                //                    Label30.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
                //                    Label25.Text = dt1.Rows[0]["PanNo"].ToString();
                //                    Label26.Text = dt1.Rows[0]["CinNo"].ToString();
                //                    Label13.Text = dt1.Rows[0]["PlotNo"].ToString();
                //                    Label14.Text = dt1.Rows[0]["IndustrialArea"].ToString();





                //                }



                //                if (dt2.Rows.Count > 0)
                //                {


                //                    lbl_manufactured_product.Text = dt2.Rows[0]["ProductManufactured"].ToString();
                //                    lbl_alloted_parea.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();




                //;

                //                    lbl_date_of_bps.Text = dt2.Rows[0]["DateOfBuldingPlanSubmission"].ToString();

                //                    lbl_date_of_roc.Text = dt2.Rows[0]["DateOfReleaseForOccupancyCertificate"].ToString();
                //                    lbl_date_of_rel_completion.Text = dt2.Rows[0]["DateOfReleaseForCompletion"].ToString();


                //                    lbl_inspection_date_for_complition.Text = dt2.Rows[0]["InspectionDateForComplition"].ToString();
                //                    lbl_inspection_date.Text = dt2.Rows[0]["InspectionDateForConstructionPermit"].ToString();

                //                    lblRestorationRefDate.Text = dt2.Rows[0]["RestorationRefDate"].ToString();
                //                    lblRestorationRefNo.Text = dt2.Rows[0]["RestorationRefNo"].ToString();
                //                    Label92.Text = dt2.Rows[0]["RestorationRefNo"].ToString();
                //                    Label93.Text = dt2.Rows[0]["RestorationRefDate"].ToString();
                //                    Label90.Text = dt2.Rows[0]["DateOfPossession"].ToString();
                //                    Label91.Text = dt2.Rows[0]["PossessionArea"].ToString();
                //                    Label52.Text = dt2.Rows[0]["ConstructionValueAtTimeofAllotment"].ToString();
                //                    Label89.Text = dt2.Rows[0]["ConstructionValueAtTimeofAllotment"].ToString();
                //                    lblCertificateNo.Text = dt2.Rows[0]["CertificateNo"].ToString();
                //                    Label47.Text = dt2.Rows[0]["CertificateNo"].ToString();
                //                    lblIssueDate.Text = dt2.Rows[0]["IssueDate"].ToString();
                //                    Label48.Text = dt2.Rows[0]["IssueDate"].ToString();
                //                    lblStampDutyAmount.Text = dt2.Rows[0]["StampDutyAmount"].ToString();
                //                    Label49.Text = dt2.Rows[0]["StampDutyAmount"].ToString();
                //                    lblAccountReference.Text = dt2.Rows[0]["AccountReferenceNo"].ToString();
                //                    Label50.Text = dt2.Rows[0]["AccountReferenceNo"].ToString();
                //                    lblUniqueDocReference.Text = dt2.Rows[0]["UniqueDocRef"].ToString();
                //                    Label51.Text = dt2.Rows[0]["UniqueDocRef"].ToString();
                //                    lblGuaranteeNo.Text = dt2.Rows[0]["GuaranteNo"].ToString();
                //                    Label53.Text = dt2.Rows[0]["GuaranteNo"].ToString();
                //                    lblGuaranteeAmount.Text = dt2.Rows[0]["GuaranteAmount"].ToString();
                //                    Label82.Text = dt2.Rows[0]["GuaranteAmount"].ToString();

                //                    lblCoverFrom.Text = dt2.Rows[0]["GuarnteeCoverFrom"].ToString();

                //                    Label83.Text = dt2.Rows[0]["GuarnteeCoverFrom"].ToString();

                //                    lblCoverTo.Text = dt2.Rows[0]["GuaranteeCoverTo"].ToString();
                //                    Label84.Text = dt2.Rows[0]["GuaranteeCoverTo"].ToString();
                //                    lblLastDateOfClaim.Text = dt2.Rows[0]["LastDateOfClaim"].ToString();
                //                    Label85.Text = dt2.Rows[0]["LastDateOfClaim"].ToString();
                //                    lblBankProposalLetter.Text = dt2.Rows[0]["BankProposalLetter"].ToString();
                //                    Label45.Text = dt2.Rows[0]["BankProposalLetter"].ToString();
                //                    lblBankSanctionLetter.Text = dt2.Rows[0]["BankSanctionLetter"].ToString();
                //                    Label46.Text = dt2.Rows[0]["BankSanctionLetter"].ToString();
                //                    lblSanctionLetterUpsidc.Text = dt2.Rows[0]["SanctionLetterUPSIDC"].ToString();
                //                    Label86.Text = dt2.Rows[0]["SanctionLetterUPSIDC"].ToString();
                //                    lblNoOfStamp.Text = dt2.Rows[0]["NoOfStamp"].ToString();
                //                    Label87.Text = dt2.Rows[0]["NoOfStamp"].ToString();
                //                    Label88.Text = dt2.Rows[0]["TotalStampDuty"].ToString();
                //                    lblTotalStampDuty.Text = dt2.Rows[0]["TotalStampDuty"].ToString();


                //                    lblBookNo.Text = dt2.Rows[0]["Lease_bookno"].ToString();
                //                    LblBookBinding.Text = dt2.Rows[0]["Lease_bookbinding"].ToString();

                //                    LblSNo.Text = dt2.Rows[0]["Lease_srno"].ToString();



                //                    Label31.Text = dt2.Rows[0]["ProductManufactured"].ToString();
                //                    Label32.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                //                    Label33.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();

                //                    Label36.Text = dt2.Rows[0]["DateOfBuldingPlanSubmission"].ToString();
                //                    Label37.Text = dt2.Rows[0]["DateOfReleaseForCompletion"].ToString();
                //                    Label38.Text = dt2.Rows[0]["DateOfReleaseForOccupancyCertificate"].ToString();
                //                    Label39.Text = dt2.Rows[0]["InspectionDateForConstructionPermit"].ToString();
                //                    Label40.Text = dt2.Rows[0]["InspectionDateForComplition"].ToString();
                //                    Label41.Text = dt2.Rows[0]["Lease_bookno"].ToString();
                //                    Label42.Text = dt2.Rows[0]["Lease_bookbinding"].ToString();
                //                    Label43.Text = dt2.Rows[0]["Lease_srno"].ToString();

                //                    lblChangeofPlotRefNo.Text = dt2.Rows[0]["ChangeOfPlotRefNo"].ToString();
                //                    lblChangeOfPlotRefNo1.Text = dt2.Rows[0]["ChangeOfPlotRefNo"].ToString();
                //                    lblChangeofPlotRefDate.Text = dt2.Rows[0]["ChangeOfPlotRefDate"].ToString();
                //                    lblChangeOfPlotRefDate1.Text = dt2.Rows[0]["ChangeOfPlotRefDate"].ToString();
                //                    lblChangeofProjectRefNo.Text = dt2.Rows[0]["ChangeOfProjectRefNo"].ToString();
                //                    lblChangeOfProjectRefNo1.Text = dt2.Rows[0]["ChangeOfProjectRefNo"].ToString();
                //                    lblChangeofProjectRefDate.Text = dt2.Rows[0]["ChangeOfProjectRefDate"].ToString();
                //                    lblChangeOfProjectRefDate1.Text = dt2.Rows[0]["ChangeOfProjectRefDate"].ToString();
                //                    lblAmalgamationRefNo.Text = dt2.Rows[0]["AmagaRefNo"].ToString();
                //                    lblAmalgamationRefNo1.Text = dt2.Rows[0]["AmagaRefNo"].ToString();
                //                    lblAmalgamationDate.Text = dt2.Rows[0]["AmagaRefDate"].ToString();
                //                    lblAmalgamationRefDate1.Text = dt2.Rows[0]["AmagaRefDate"].ToString();
                //                    lblSubDivRefNo.Text = dt2.Rows[0]["SubDivRefNo"].ToString();
                //                    lblSubDivRefNo1.Text = dt2.Rows[0]["SubDivRefNo"].ToString();
                //                    lblSubDivRefDate.Text = dt2.Rows[0]["SubDivRefDate"].ToString();
                //                    lblSubDivRefDate1.Text = dt2.Rows[0]["SubDivRefDate"].ToString();
                //                    lblSublettingRefNo.Text = dt2.Rows[0]["SublettingRefNo"].ToString();
                //                    lblSublettingRefNo1.Text = dt2.Rows[0]["SublettingRefNo"].ToString();
                //                    lblSublettingRefDate.Text = dt2.Rows[0]["SublettingRefDate"].ToString();
                //                    lblSublettingRefDate1.Text = dt2.Rows[0]["SublettingRefDate"].ToString();
                //                    lblDateOfAgreement.Text = dt2.Rows[0]["DateOfAgreement"].ToString();
                //                    lblAgreementDate1.Text = dt2.Rows[0]["DateOfAgreement"].ToString();
                //                    lblDateOfAgreementExec.Text = dt2.Rows[0]["DateOfExecutionAgreement"].ToString();
                //                    lblAgreementExecDate1.Text = dt2.Rows[0]["DateOfExecutionAgreement"].ToString();
                //                    lblAgreementOnPlotSize.Text = dt2.Rows[0]["AgreementOnPlotSize"].ToString();
                //                    lblAgreementOn.Text = dt2.Rows[0]["AgreementOnPlotSize"].ToString();
                //                    lblSublettingPartyName.Text = dt2.Rows[0]["SublettingPartyName"].ToString();
                //                    lblSublettingPartyName1.Text = dt2.Rows[0]["SublettingPartyName"].ToString();
                //                    lblSubleetingArea.Text = dt2.Rows[0]["SublettingArea"].ToString();
                //                    lblSublettingArea1.Text = dt2.Rows[0]["SublettingArea"].ToString();
                //                    lblSublettingYears.Text = dt2.Rows[0]["SublettingYear"].ToString();
                //                    lblSublettingYears1.Text = dt2.Rows[0]["SublettingYear"].ToString();
                //                    lblSublettingProjectName.Text = dt2.Rows[0]["SublettingProjectName"].ToString();
                //                    lblSublettingProjectName1.Text = dt2.Rows[0]["SublettingProjectName"].ToString();
                //                    lblCaseType.Text = dt2.Rows[0]["CaseType"].ToString();
                //                    lblCaseType1.Text = dt2.Rows[0]["CaseType"].ToString();

                //                        if (lblCaseType.Text == "Transfer Case")
                //                    {

                //                        bindTransfercase();



                //                            if (dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == "0" || dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == "" || dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == null)
                //                        {
                //                            ddlTranserCase.SelectedIndex = 0;
                //                        }
                //                        else
                //                        {
                //                            ddlTranserCase.SelectedValue = dt2.Rows[0]["TransferLevyCase"].ToString().Trim();
                //                        }
                //                        LblTransferCase1.Text = dt2.Rows[0]["TransferLevyCase1"].ToString().Trim();
                //                        lblTransferLevy.Text = dt2.Rows[0]["TransferLevyCase1"].ToString().Trim();
                //                        lblPendingdues.Text = dt2.Rows[0]["PrevAlloteeDues"].ToString().Trim();
                //                        lblPendingDues1.Text = dt2.Rows[0]["PrevAlloteeDues"].ToString().Trim();
                //                        }
                //                    else
                //                    {

                //                        ddlTranserCase.ClearSelection();
                //                        LblTransferCase1.Text = "";
                //                        lblTransferLevy.Text = "";
                //                        lblPendingdues.Text = "";
                //                        lblPendingDues1.Text = "";
                //                    }







                //                }


                //                if (dt3.Rows.Count > 0)
                //                {

                //                    lbl_rate_of_interest.Text = dt3.Rows[0]["InterestRate"].ToString();
                //                    lbl_rate_time_of_allotment.Text = dt3.Rows[0]["RateatTimeAllotment"].ToString();
                //                    lbl_Rebate_For_Non_Defaulters.Text = dt3.Rows[0]["NondefaulterRebate"].ToString();
                //                    lbl_No_Of_Installment.Text = dt3.Rows[0]["NoOfInstallment"].ToString();
                //                    lbl_Location_Charges.Text = dt3.Rows[0]["LocationCharges"].ToString();
                //                    lbl_Earnest_Money_Rate.Text = dt3.Rows[0]["RegistrationMoneyRate"].ToString();
                //                    lbl_Reservation_Money_Paid_witin_30_days.Text = dt3.Rows[0]["AdditionalPay"].ToString();
                //                    lbl_Demant_Notice_Date1.Text = dt3.Rows[0]["DemandNoticeDate1"].ToString();
                //                    lbl_Demant_Notice_Date2.Text = dt3.Rows[0]["DemandNoticeDate2"].ToString();
                //                }
                //                if (dt6.Rows.Count > 0)
                //                {




                //                    lblTypeOfIndustry.Text = dt6.Rows[0]["IndustryType"].ToString();
                //                    Label55.Text = dt6.Rows[0]["IndustryType"].ToString();
                //                    lblestimatedcost.Text = dt6.Rows[0]["EstimatedCostOfProject"].ToString();
                //                    Label56.Text = dt6.Rows[0]["EstimatedCostOfProject"].ToString();
                //                    lblestimatedemployment.Text = dt6.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                //                    Label57.Text = dt6.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                //                    lblcoveredarea.Text = dt6.Rows[0]["CoveredArea"].ToString();
                //                    Label58.Text = dt6.Rows[0]["CoveredArea"].ToString();
                //                    lblopenarea.Text = dt6.Rows[0]["OpenAreaRequired"].ToString();
                //                    Label59.Text = dt6.Rows[0]["OpenAreaRequired"].ToString();
                //                    lblland.Text = dt6.Rows[0]["LandDetails"].ToString();
                //                    Label60.Text = dt6.Rows[0]["LandDetails"].ToString();
                //                    lblbuilding.Text = dt6.Rows[0]["BuildingDetails"].ToString();
                //                    Label61.Text = dt6.Rows[0]["BuildingDetails"].ToString();
                //                    lblMachinery.Text = dt6.Rows[0]["MachineryEquipmentsDetails"].ToString();
                //                    Label62.Text = dt6.Rows[0]["MachineryEquipmentsDetails"].ToString();
                //                    lblFixedAssets.Text = dt6.Rows[0]["OtherFixedAssets"].ToString();
                //                    Label63.Text = dt6.Rows[0]["OtherFixedAssets"].ToString();
                //                    lblOtherExpenses.Text = dt6.Rows[0]["OtherExpenses"].ToString();
                //                    Label64.Text = dt6.Rows[0]["OtherExpenses"].ToString();
                //                    lblEffluentSolidQty.Text = dt6.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                //                    Label67.Text = dt6.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                //                    lblEffluentSolidComposition.Text = dt6.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                //                    Label68.Text = dt6.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                //                    lblEffluentLiquidQty.Text = dt6.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                //                    Label69.Text = dt6.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                //                    lblEffluentLiquidComposition.Text = dt6.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                //                    Label70.Text = dt6.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                //                    lblEffluentGaseousQty.Text = dt6.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                //                    Label71.Text = dt6.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                //                    lblEffluentGaseousComposition.Text = dt6.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                //                    Label72.Text = dt6.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                //                    if (dt6.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                //                    {
                //                        fume_span.InnerText = "Yes";
                //                        fumeDiv1.Visible = true;
                //                        lblFumeQty.Text = dt6.Rows[0]["FumeQuantity"].ToString();
                //                        lblFumeNature.Text = dt6.Rows[0]["FumeNature"].ToString();
                //                        Div1.Visible = true;
                //                        Span1.InnerText = "Yes"; ;
                //                        Label66.Text = dt6.Rows[0]["FumeQuantity"].ToString();
                //                        Label65.Text = dt6.Rows[0]["FumeNature"].ToString();

                //                    }
                //                    else
                //                    {
                //                        fume_span.InnerText = "No";
                //                        fumeDiv1.Visible = false;
                //                        lblFumeQty.Text = "";
                //                        lblFumeNature.Text = "";
                //                        Div1.Visible = false;
                //                        Span1.InnerText = "No"; ;
                //                        Label66.Text = "";
                //                        Label65.Text = "";
                //                    }

                //                    lblEffluentMeasure1.Text = dt6.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                //                    Label73.Text = dt6.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                //                    lblEffluentMeasure2.Text = dt6.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                //                    Label74.Text = dt6.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                //                    lblEffluentMeasure3.Text = dt6.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                //                    Label75.Text = dt6.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                //                    lblPowerReq.Text = dt6.Rows[0]["PowerReqInKW"].ToString();
                //                    Label76.Text = dt6.Rows[0]["PowerReqInKW"].ToString();
                //                    lblTReq1.Text = dt6.Rows[0]["TelephoneReqFirstYear1"].ToString();
                //                    Label77.Text = dt6.Rows[0]["TelephoneReqFirstYear1"].ToString();
                //                    lblTReq2.Text = dt6.Rows[0]["TelephoneReqFirstYear2"].ToString();
                //                    Label78.Text = dt6.Rows[0]["TelephoneReqFirstYear2"].ToString();
                //                    lblTUReq1.Text = dt6.Rows[0]["TelephoneReqUltimate1"].ToString();
                //                    Label79.Text = dt6.Rows[0]["TelephoneReqUltimate1"].ToString();
                //                    lblTUReq2.Text = dt6.Rows[0]["TelephoneReqUltimate2"].ToString();
                //                    Label80.Text = dt6.Rows[0]["TelephoneReqUltimate2"].ToString();


                //                    if (dt6.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                //                    {
                //                        priority_span.InnerText = "Yes";
                //                        Prioritydiv1.Visible = true;
                //                        lblspec.Text = dt6.Rows[0]["ApplicantPrioritySpecification"].ToString();
                //                        Span2.InnerText = "Yes";
                //                        Div2.Visible = true;
                //                        Label81.Text = dt6.Rows[0]["ApplicantPrioritySpecification"].ToString();
                //                    }
                //                    else
                //                    {
                //                        priority_span.InnerText = "No";
                //                        Prioritydiv1.Visible = false;
                //                        lblspec.Text = "";
                //                        Span2.InnerText = "No";
                //                        Div2.Visible = false;
                //                        Label81.Text = "";
                //                    }

                //                }





                //                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-d :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }






    }
}