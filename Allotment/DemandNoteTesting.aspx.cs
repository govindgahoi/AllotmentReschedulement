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
    public partial class DemandNoteTesting : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        public string ServiceReqNo;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
            }

            ServiceReqNo = Request.QueryString["ViewID"];
            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();

            }

            if (ServiceReqNo != null)
            {
                if (ServiceReqNo.Length > 0)
                {
                    divSearch.Visible = false;

                }

            }
            else
            {
                divSearch.Visible = true;
            }
        }

        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "Id";
                drpIndusrialArea.DataBind();
                drpIndusrialArea.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }




        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

        }


        protected void radioByPlotNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = true;
            DivFilterLetter.Visible = false;

        }

        protected void radioByAllotmentNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = false;
            DivFilterLetter.Visible = true;
        }

        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForIAServices(objServiceTimelinesBEL);
                drpPlotNo.DataSource = ds;
                drpPlotNo.DataTextField = "PlotNumber";
                drpPlotNo.DataValueField = "PlotNumber";
                drpPlotNo.DataBind();
                drpPlotNo.Items.Insert(0, new ListItem("--Select--", ""));



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();

        }


        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {
                if (radioByAllotmentNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtServiceReqNo.Text;
                    objServiceTimelinesBEL.IAName = "";
                    objServiceTimelinesBEL.PlotNo = "";

                }

                if (radioByPlotNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
                }

                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindForLeaseDeed(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();

                }
                else
                {
                    AllotteeDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        protected void btnRaise_Click(object sender, EventArgs e)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GEtdemandNoteOFAllottee(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    PreviousServiceDiv.Visible = true;
                    AllGrid.DataSource = dt;
                    AllGrid.DataBind();

                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                    AllGrid.FooterRow.Cells[1].Text = "Total";
                    AllGrid.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    AllGrid.FooterRow.Cells[2].Text = total.ToString("N2");
                }
                else
                {
                    PreviousServiceDiv.Visible = false;
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


    }
}