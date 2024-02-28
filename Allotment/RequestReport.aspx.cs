using System;
using System.Data;
using System.Text;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class RequestReport : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string strPloatNo, strAllotmentNo, strAlloteeName, strTypeOfInspection = "";
        DataTable dtInspectionDetails;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string strParameter = Convert.ToString(Request.QueryString["IAID"]);
                int iInspectionID = Convert.ToInt32(strParameter.Split('-')[0]);
                string RequestReportType = Convert.ToString(strParameter.Split('-')[1]);

                if (RequestReportType == "Allotte")
                {
                    trAllotmentNo.Visible = false;
                    lblText.Text = "Application ID";
                    lblInspectionType.Visible = false;
                    lblApplcationID.Visible = true;
                }

                if (RequestReportType == "Inspection")
                {
                    lblText.Text = "Type Of Inspection";
                    lblInspectionType.Visible = true;
                    lblApplcationID.Visible = false;
                }

                GetInspectionDetail(iInspectionID, RequestReportType);
                FillCapctha();
            }
        }

        private void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                Session["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "Captch.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch
            {

                throw;
            }
        }


        private void GetInspectionDetail(int iInspectionID, string RequestReportType)
        {
            DataSet ds = new DataSet();
            DataRow[] dr = null;
            Session["RequestReportType"] = RequestReportType;
            try
            {
                if (RequestReportType == "Allotte")
                {
                    ds = objServiceTimelinesBLL.GetAlloteeDetail();
                    dtInspectionDetails = ds.Tables[0];
                    dr = dtInspectionDetails.Select("dbID = " + iInspectionID.ToString());
                }
                if (RequestReportType == "Inspection")
                {
                    ds = objServiceTimelinesBLL.GetInspectionDetail();
                    dtInspectionDetails = ds.Tables[0];
                    dr = dtInspectionDetails.Select("dbid = " + iInspectionID.ToString());
                }

                if (dr.Length > 0)
                {
                    Session["InspectionID"] = dr[0]["dbID"].ToString();
                    if (RequestReportType == "Inspection")
                    {

                        Session["RegionalOffice"] = dr[0]["dbRegionalOffice"].ToString();
                        Session["RegionName"] = dr[0]["dbRegionName"].ToString();
                        strPloatNo = dr[0]["dbPlotNo"].ToString();
                        strAllotmentNo = dr[0]["dbAllotmentNo"].ToString();
                        strAlloteeName = dr[0]["dbAllotteename"].ToString();
                        strTypeOfInspection = dr[0]["dbTypeofInspection"].ToString();
                        lblPlotNo.Text = strPloatNo;
                        lblAlltmentNo.Text = strAllotmentNo;
                        lblInspectionType.Text = strTypeOfInspection;
                    }
                    if (RequestReportType == "Allotte")
                    {
                        Session["RegionalOffice"] = null;
                        Session["RegionName"] = dr[0]["IAName"].ToString();
                        strPloatNo = dr[0]["AllottedPlotNO"].ToString();
                        strAlloteeName = dr[0]["ApplicantName"].ToString();
                        lblPlotNo.Text = strPloatNo;
                        lblAlltmentNo.Text = strAllotmentNo;
                        lblApplcationID.Text = dr[0]["ApplicationID"].ToString();
                    }
                }
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

        protected void btnSubmit_Clcik(object sender, EventArgs e)
        {
            if (Session["captcha"].ToString() != txtCaptcha.Text)
            {
                string message = "Invalid Captcha Code";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
            }
            else
            {
                objServiceTimelinesBEL.dbId = Convert.ToInt32(Session["InspectionID"]);
                objServiceTimelinesBEL.RequestReportType = Convert.ToString(Session["RequestReportType"]);
                objServiceTimelinesBEL.RegionalOffice = Convert.ToString(Session["RegionalOffice"]);
                objServiceTimelinesBEL.RegionName = Convert.ToString(Session["RegionName"]);
                objServiceTimelinesBEL.PlotNo = lblPlotNo.Text;
                objServiceTimelinesBEL.ApplicationID = lblApplcationID.Text;
                objServiceTimelinesBEL.AllotmentNo = lblAlltmentNo.Text;
                objServiceTimelinesBEL.TypeofInspection = lblInspectionType.Text;
                objServiceTimelinesBEL.Allotteename = txtRequestorName.Text;
                objServiceTimelinesBEL.RequestorPhone = txtReqPhone.Text;
                objServiceTimelinesBEL.RequestorEmailID = txtReqEmailID.Text;
                objServiceTimelinesBEL.RequestPurpose = txtReqPurpose.Text;
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                int iRet = objServiceTimelinesBLL.SaveRequestReport(objServiceTimelinesBEL);
                if (iRet == 1)
                {
                    string message = "Your Request submitted successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string message = "Something Went Wrong.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                }
            }
            FillCapctha();
            lblPlotNo.Text = "";
            lblAlltmentNo.Text = "";
            lblInspectionType.Text = "";
            lblApplcationID.Text = "";
            txtRequestorName.Text = "";
            txtReqPhone.Text = "";
            txtReqEmailID.Text = "";
            txtReqPurpose.Text = "";
            txtCaptcha.Text = "";
            Session.Clear();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillCapctha();
        }
    }
}