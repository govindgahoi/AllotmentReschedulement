﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;




namespace Allotment
{
    public partial class UC_Service_Allotteee_Details_IA_ServicesRescheduelment : System.Web.UI.UserControl
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
                DataTable dt12 = ds.Tables[12];

                if (dt1.Rows.Count > 0)
                {

                    lblApplicationLetter.Text = dt1.Rows[0]["ref_AllotmentNo"].ToString().Trim();
                    lblALlotmentDate.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();
                    lblAllotmentNo.Text = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();


                    lblAllotteeRegionalOffice.Text = dt1.Rows[0]["RegionalOffice"].ToString().Trim();
                    lblIndustrialArea.Text = dt1.Rows[0]["IndustrialArea"].ToString().Trim();
                    lblPlotNo.Text = dt1.Rows[0]["PlotNo"].ToString().Trim();


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

                }
                if (dt12.Rows.Count > 0)
                {

                    TEFViewDetails.DataSource = dt12;
                    TEFViewDetails.DataBind();
                }
                else
                {
                    TEFViewDetails.DataSource = null;
                    TEFViewDetails.DataBind();
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