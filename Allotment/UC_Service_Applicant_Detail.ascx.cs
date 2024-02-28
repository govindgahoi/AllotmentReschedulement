using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class UC_Service_Applicant_Detail : System.Web.UI.UserControl
    {

        SqlConnection con = new SqlConnection();

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion



        public string AllotteeId { get; set; }
        public string ServiceReqNo { get; set; }
        public string sender { get; set; }


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
            if (string.IsNullOrEmpty(ServiceReqNo)) { ServiceReqNo = ""; }


            if (AllotteeId.Length > 0 || ServiceReqNo.Length > 0)
            {
                uc_alloottee_details.Visible = true;
                view(ServiceReqNo);

            }
            else
            {
                uc_alloottee_details.Visible = false;
            }
        }



        public void view(string ServiceReqNo)
        {
            SqlCommand cmd = new SqlCommand();

            if (sender == "Assesment")
            {
                cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByServiceReqNo_New", con);
            }
            else { cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByServiceReqNo", con); }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceReqNo", ServiceReqNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];

            if (dt1.Rows.Count > 0)
            {

                lblAuthorisedSignatory.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                lblFirmCompanyName.Text = dt1.Rows[0]["CompanyName"].ToString();
                lblCompanyConstitution.Text = dt1.Rows[0]["FirmConstitution"].ToString();
                lblSIgnatoryEmail.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                lblSignatoryMobile.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                lblAddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
                //        lblPanNo.Text = dt1.Rows[0]["PanNo"].ToString();
                lblCinNo.Text = dt1.Rows[0]["CinNo"].ToString();
                lblRequiredplot.Text = dt1.Rows[0]["PlotSize"].ToString();
                lblIndustrialArea.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                lblStatusAsonDate.Text = dt1.Rows[0]["Status_Name"].ToString();
                lblDateofApplication.Text = dt1.Rows[0]["DateofAllotmentNo"].ToString();
                lblRegionalOffice.Text = dt1.Rows[0]["RegionalOffice"].ToString();
                lblApplicationNo.Text = dt1.Rows[0]["AllotteeID"].ToString();




                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Individual/Sole Proprietorship firm")
                {
                    GridView6.Visible = true;
                    P2.InnerText = "Individual/Sole Proprietorship firm Details";
                    GridView6.DataSource = dt2; GridView6.DataBind();
                }
                else
                {
                    GridView6.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Public Limited")
                {
                    GridView7.Visible = true;
                    P2.InnerText = "Directors Details";
                    GridView7.DataSource = dt2; GridView7.DataBind();
                }
                else
                {
                    GridView7.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Private Limited")
                {
                    GridView8.Visible = true;
                    P2.InnerText = "ShareHolders Details";
                    GridView8.DataSource = dt2; GridView8.DataBind();
                }
                else
                {
                    GridView8.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Partnership Firm")
                {
                    GridView9.Visible = true;
                    P2.InnerText = "Partners Details";
                    GridView9.DataSource = dt2; GridView9.DataBind();
                }
                else
                {
                    GridView9.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Society & Trust")
                {
                    GridView10.Visible = true;
                    P2.InnerText = "Trustee Details";
                    GridView10.DataSource = dt2; GridView10.DataBind();
                }
                else
                {
                    GridView10.Visible = false;
                }


            }
            if (dt3.Rows.Count > 0)
            {
                lblDescription.Text = dt3.Rows[0]["IndustryType"].ToString();
                lblEstimatedCost.Text = dt3.Rows[0]["EstimatedCostOfProject"].ToString();
                LabelblEstimatedEmployment.Text = dt3.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                lblCoveredArea.Text = dt3.Rows[0]["CoveredArea"].ToString();
                lblOpenArea.Text = dt3.Rows[0]["OpenAreaRequired"].ToString();
                lblLand.Text = dt3.Rows[0]["LandDetails"].ToString();
                lblBuilding.Text = dt3.Rows[0]["BuildingDetails"].ToString();
                lblMachineryEquipment.Text = dt3.Rows[0]["MachineryEquipmentsDetails"].ToString();
                lblOtherAssets.Text = dt3.Rows[0]["OtherFixedAssets"].ToString();
                lblOtherExpenses.Text = dt3.Rows[0]["OtherExpenses"].ToString();
                lblQtySolid.Text = dt3.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                lblChemicalSolid.Text = dt3.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                lblQtyLiquid.Text = dt3.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                lblChemicalLiquid.Text = dt3.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                lblQtyGaseous.Text = dt3.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                lblChemicalGaseous.Text = dt3.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                if (dt3.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                {
                    Span1.InnerText = "Yes";
                    //     Div1.Visible = true;
                    lblQuantity.Text = dt3.Rows[0]["FumeQuantity"].ToString();
                    lblNature.Text = dt3.Rows[0]["FumeNature"].ToString();
                }
                else
                {
                    Span1.InnerText = "No";
                    //    Div1.Visible = false;
                    lblNature.Text = "";
                    lblQuantity.Text = "";
                }
                lblmeasure1.Text = dt3.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                lblmeasure2.Text = dt3.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                lblmeasure3.Text = dt3.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                lblUnits.Text = dt3.Rows[0]["PowerReqInKW"].ToString();
                lblFirstYear1.Text = dt3.Rows[0]["TelephoneReqFirstYear1"].ToString();
                lblFirstYear2.Text = dt3.Rows[0]["TelephoneReqFirstYear2"].ToString();
                lblUltimateRequirement1.Text = dt3.Rows[0]["TelephoneReqUltimate1"].ToString();
                lblUltimateRequirement2.Text = dt3.Rows[0]["TelephoneReqUltimate2"].ToString();
                if (dt3.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                {
                    Span2.InnerText = "Yes";
                    //  Div2.Visible = true;
                    lblSpecification.Text = dt3.Rows[0]["ApplicantPrioritySpecification"].ToString();
                }
                else
                {
                    Span2.InnerText = "No";
                    //   Div2.Visible = false;
                    lblSpecification.Text = "";
                }

                lblNetworth.Text = dt3.Rows[0]["NetTurnOver"].ToString();
                lblExpansionland.Text = dt3.Rows[0]["ExpansionOfLand"].ToString();
                lblExportOriented.Text = dt3.Rows[0]["ExportOriented"].ToString();
            }


            cmd.Dispose();




        }




















        public void bindUserData(string allottee, string allotteeId)
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                objServiceTimelinesBEL.AllotmentNo = "";


                if (!string.IsNullOrEmpty(AllotteeId))
                {
                    objServiceTimelinesBEL.AllotteeID = int.Parse(AllotteeId);

                }










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