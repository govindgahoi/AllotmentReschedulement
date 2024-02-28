using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Allotment.Darpan
{
    public partial class MisDarpanReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string ServiceTimelinesId = Request.QueryString["ServiceTimelinesId"];
                //string ServiceTimelinesAll = "2658";
                string Completed = Request.QueryString["Completed"];
                string Rejected = Request.QueryString["Rejected"];
                string InTime = Request.QueryString["Intime"];
                string OutTime = Request.QueryString["Outtime"];
                string TotalApplication = Request.QueryString["All"];

                if (ServiceTimelinesId == "1004")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Addition of Product";
                }
                else if (ServiceTimelinesId == "1029")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Amalgamation of Plots";
                }
                else if (ServiceTimelinesId == "1042")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Application for Seeking Incentive";
                }
                else if (ServiceTimelinesId == "1026")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Application for subletting";
                }
                else if (ServiceTimelinesId == "1003")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Change of project within same";
                }
                else if (ServiceTimelinesId == "1025")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Establishment of Additional";
                }
                else if (ServiceTimelinesId == "1017")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Hand over of lease deed to lease";
                }
                else if (ServiceTimelinesId == "1014")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Issuance of certificate";
                }
                else if (ServiceTimelinesId == "1005")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Issuance of NOC for permission";
                }
                else if (ServiceTimelinesId == "1000")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Land Allotment System";
                }
                else if (ServiceTimelinesId == "1001")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Lease deed Execution";
                }
                else if (ServiceTimelinesId == "1021")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Legal heir after death";
                }
                else if (ServiceTimelinesId == "1023")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - No dues certificate after full";
                }
                else if (ServiceTimelinesId == "1028")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Online facility for payment";
                }
                else if (ServiceTimelinesId == "200")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Online payment of reservation";
                }
                else if (ServiceTimelinesId == "1027")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Outstanding Dues Position";
                }
                else if (ServiceTimelinesId == "1007")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Permission for creation of second";
                }
                else if (ServiceTimelinesId == "1006")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Permission for joint mortgage";
                }
                else if (ServiceTimelinesId == "1008")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Reconstitution Allottee firm";
                }
                else if (ServiceTimelinesId == "1012")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Restoration of the plot";
                }
                else if (ServiceTimelinesId == "1024")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Surrender of plot and refund";
                }
                else if (ServiceTimelinesId == "1002")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Time extension for setting";
                }
                else if (ServiceTimelinesId == "1011")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Transfer of Lease deed";
                }
                else if (ServiceTimelinesId == "4")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Transfer of Plot";
                }
                else if (ServiceTimelinesId == "1")
                {
                    lblServiceType.Text = "Service Type: UPSIDA - Building Plan Approval";
                }
                else
                {
                    lblServiceType.Text = "Service Details";
                }


                
                lblentreprenure.Text = "<h3>Entrepreneur Details</h3>";

                //if (ServiceTimelinesId != null)
                //{
                MisReportAll(ServiceTimelinesId);
                    TotalCountMisReport(ServiceTimelinesId);
                    hyperlink1.NavigateUrl = "MisDarpanReport.aspx?ServiceTimelinesId=" + ServiceTimelinesId + "&All=1";
                    hyperlink2.NavigateUrl = "MisDarpanReport.aspx?ServiceTimelinesId=" + ServiceTimelinesId + "&Completed=1";
                    hyperlink3.NavigateUrl = "MisDarpanReport.aspx?ServiceTimelinesId=" + ServiceTimelinesId + "&Rejected=1";
                    hyperlink4.NavigateUrl = "MisDarpanReport.aspx?ServiceTimelinesId=" + ServiceTimelinesId + "&Intime=1";
                    hyperlink5.NavigateUrl = "MisDarpanReport.aspx?ServiceTimelinesId=" + ServiceTimelinesId + "&Outtime=1";
                //}


                if (TotalApplication == null && Completed == null && Rejected == null && InTime == null && OutTime == null  )
                {
                    TotalApplications(ServiceTimelinesId);
                }
                else if (TotalApplication != null)
                {
                    TotalApplications(ServiceTimelinesId);                    
                }
                else if (Completed != null)
                {
                    ApplicationApproved(ServiceTimelinesId, Completed);
                }
                else if (Rejected != null)
                {
                    ApplicationRejected(ServiceTimelinesId, Rejected);
                }
                else if (InTime != null)
                {
                    ApplicationInTime(ServiceTimelinesId, InTime);
                }
                else if (OutTime != null)
                {
                    ApplicationOutTime(ServiceTimelinesId, OutTime);
                }
            }
        }

        private DataSet TotalCountMisReport(string ServiceTimelinesAll)
        {
            con.Open();
            string sql = "select top 1 coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' ),0) TotalApplications, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsCompleted = '1' ),0) Completed, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected = '1' ),0) Rejected, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) >= SRT.ServiceTimeLinesNM ),0) InTime, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) < SRT.ServiceTimeLinesNM ),0) OutTime from tbl_NM_District_Master MDAA";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            hyperlink1.Text = ds.Tables[0].Rows[0]["TotalApplications"].ToString();
            hyperlink2.Text = ds.Tables[0].Rows[0]["Completed"].ToString();
            hyperlink3.Text = ds.Tables[0].Rows[0]["Rejected"].ToString();
            hyperlink4.Text = ds.Tables[0].Rows[0]["InTime"].ToString();
            hyperlink5.Text = ds.Tables[0].Rows[0]["OutTime"].ToString();
            con.Close();
            return ds;

        }
        private void MisReportAll(string ServiceTimelinesAll)
        {
            DataSet ds = new DataSet();
            string query = "select distinct(MDAA.DistrictName), NM_District_ID, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NM_District_ID = MDAA.NM_District_ID and SR.ServiceTimelinesId = '" + ServiceTimelinesAll + "' group by MDD.NM_District_ID), 0) TotalApplications, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NM_District_ID = MDAA.NM_District_ID and SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsCompleted = '1' group by MDD.NM_District_ID),0) Completed, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NM_District_ID = MDAA.NM_District_ID and SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected = '1' group by MDD.NM_District_ID),0) Rejected, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NM_District_ID = MDAA.NM_District_ID and SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) >= SRT.ServiceTimeLinesNM group by MDD.NM_District_ID),0) InTime, coalesce((select count(SR.ServiceRequestID)  from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimeLinesId where MDD.NM_District_ID = MDAA.NM_District_ID and SR.ServiceTimelinesId = '"+ ServiceTimelinesAll + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) < SRT.ServiceTimeLinesNM group by MDD.NM_District_ID),0) OutTime from tbl_NM_District_Master MDAA order by DistrictName";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                GridMisReportAll.DataSource = ds;
                GridMisReportAll.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void TotalApplications(string ServiceTimelinesId)
        {
            DataSet ds = new DataSet();
            string query = "select ServiceRequestNO, CONVERT(VARCHAR(10),SR.ServiceSubmitDate,103) as FeeSubmitDate, AM.PlotNo, (select DistrictName from tbl_NM_District_Master NMDM where NMDM.NM_District_ID = IA.DistrictID) DistrictName, IA.RegionalOffice, IA.IAName, AllotteeName, Allotmentletterno, AM.emailID, AM.PhoneNo, CONVERT(VARCHAR(10),AM.AllotmentletterIssueDate) as AllotmentLetterIssueDate from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '" + ServiceTimelinesId + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                grdTotalApplications.DataSource = ds;
                grdTotalApplications.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void ApplicationApproved(string ServiceTimelinesId,string Completed)
        {
            DataSet ds = new DataSet();
            string query = "select ServiceRequestNO, CONVERT(VARCHAR(10),SR.ServiceSubmitDate,103) as FeeSubmitDate, AM.PlotNo, (select DistrictName from tbl_NM_District_Master NMDM where NMDM.NM_District_ID = IA.DistrictID) DistrictName, IA.RegionalOffice, IA.IAName, AllotteeName, Allotmentletterno, AM.emailID, AM.PhoneNo, CONVERT(VARCHAR(10),AM.AllotmentletterIssueDate) as AllotmentLetterIssueDate from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '" + ServiceTimelinesId + "' and SR.IsCompleted = '"+Completed+"'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                grdTotalApplications.DataSource = ds;
                grdTotalApplications.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void ApplicationRejected(string ServiceTimelinesId,string Rejected)
        {
            DataSet ds = new DataSet();
            string query = "select ServiceRequestNO,  AM.PlotNo, (select DistrictName from tbl_NM_District_Master NMDM where NMDM.NM_District_ID = IA.DistrictID) DistrictName, IA.RegionalOffice, IA.IAName, AllotteeName, Allotmentletterno, AM.emailID, AM.PhoneNo from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '" + ServiceTimelinesId + "' and SR.IsRejected = '"+ Rejected + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                grdTotalApplications.DataSource = ds;
                grdTotalApplications.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void ApplicationInTime(string ServiceTimelinesId, string InTime)
        {
            DataSet ds = new DataSet();
            string query = "select ServiceRequestNO, AM.PlotNo, (select DistrictName from tbl_NM_District_Master NMDM where NMDM.NM_District_ID = IA.DistrictID) DistrictName, IA.RegionalOffice, IA.IAName, AllotteeName, Allotmentletterno, AM.emailID, AM.PhoneNo from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '" + ServiceTimelinesId + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day,SR.createdDate,GETDATE()) >= SRT.ServiceTimeLinesNM ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                grdTotalApplications.DataSource = ds;
                grdTotalApplications.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void ApplicationOutTime(string ServiceTimelinesId, string OutTime)
        {
            DataSet ds = new DataSet();
            string query = "select ServiceRequestNO, AM.PlotNo, (select DistrictName from tbl_NM_District_Master NMDM where NMDM.NM_District_ID = IA.DistrictID) DistrictName, IA.RegionalOffice, IA.IAName, AllotteeName, Allotmentletterno, AM.emailID, AM.PhoneNo from tbl_NM_District_Master MDD join IndustrialArea IA on MDD.NM_District_ID = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where SR.ServiceTimelinesId = '" + ServiceTimelinesId + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day,SR.createdDate,GETDATE()) < SRT.ServiceTimeLinesNM ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                grdTotalApplications.DataSource = ds;
                grdTotalApplications.DataBind();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }

    }
}