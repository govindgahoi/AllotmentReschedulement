using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BEL_Allotment;
using BLL_Allotment;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class updateDarpanData : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string TEFFeeStatus;
        string ServiceReqNo;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;
        string isActive;
        GeneralMethod gm = new GeneralMethod();

        SqlConnection con;

        public string Level = "";
        public string DataManager = "";
        string DocPath = "";
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
        string RequestID = "";
        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "", D2 = "", D3 = "", D4 = "", D5 = "", D6 = "", D7 = "";
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                UpdateDarpanData();
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);
                return;
            }
        }

        private void UpdateDarpanData()
        {
            try
            {
                using (con)
                {
                    using (SqlCommand cmd9 = new SqlCommand("select Project_Code_UPSIDA, Project_Code_DARPAN From Master_ServiceId_Darpan_NM_UPSIDA where [isActive] = 1 order by Project_Code_UPSIDA asc"))
                    {
                        cmd9.CommandType = CommandType.Text;
                        cmd9.Connection = con;
                        con.Open();
                        SqlDataReader sdr1 = cmd9.ExecuteReader();
                        if (sdr1.HasRows)
                        {
                            while (sdr1.Read())
                            {
                                string ServiceID = sdr1["Project_Code_UPSIDA"].ToString();
                                string Project_Code = sdr1["Project_Code_DARPAN"].ToString();
                                if (ServiceID != "")
                                {
                                    SqlCommand command = con.CreateCommand();
                                    command.Connection = con;
                                    command.CommandText = ("insert into Darpan3 ( Instance_Code, Project_Code, Frequency_Id, Group_Id, Datadate, Seq_no, Lvl1_Code, Lvl2_Code, Lvl3_Code, KPI1_Data, KPI2_Data, KPI3_Data, KPI4_Data, KPI5_Data,kvalue,lvalue,status ) select '2', '" + Project_Code + "', '1', '1', '2024-01-31', '0', MDAA.State_Code, MDAA.Division_Code, MDAA.District_Code, coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' group by MDD.NMDistrictCode), 0) TotalApplications, coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsCompleted = '1' group by MDD.NMDistrictCode),0) Completed, coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected = '1' group by MDD.NMDistrictCode),0) Rejected, coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) >= SRT.ServiceTimeLinesNM group by MDD.NMDistrictCode),0) InTime, coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) < SRT.ServiceTimeLinesNM group by MDD.NMDistrictCode),0) OutTime, concat(MDAA.State_Code, ',', MDAA.Division_Code, ',', MDAA.District_Code), CONCAT(coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' group by MDD.NMDistrictCode), 0),',', coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsCompleted = '1' group by MDD.NMDistrictCode),0),',', coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected = '1' group by MDD.NMDistrictCode),0),',', coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) >= SRT.ServiceTimeLinesNM group by MDD.NMDistrictCode),0),',', coalesce((select count(SR.ServiceRequestID)  from Master_DistrictDarpan MDD join IndustrialArea IA on MDD.NMDistrictCode = IA.DistrictID join AllotteeMaster AM on Am.IndustrialArea = IA.IAName join ServiceRequests SR on SR.AllotteeID = AM.AllotteeID Join ServiceTimeLines SRT on SR.ServiceTimelinesId = SRT.ServiceTimelinesId where MDD.NMDistrictCode = MDAA.NMDistrictCode and SR.ServiceTimelinesId = '" + ServiceID + "' and SR.IsRejected is null and SR.IsCompleted is null AND DATEDIFF(day, SR.createdDate, GETDATE()) < SRT.ServiceTimeLinesNM group by MDD.NMDistrictCode),0) ), '0' from Master_DistrictDarpan MDAA order by MDAA.District_Name ");
                                    if (command.ExecuteNonQuery() > 0)
                                    {
                                    }
                                    else { }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}