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
    public partial class updatePaymentStatus : System.Web.UI.Page
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

                CheckNMSWPFeePaidPIP();
                CheckNMSWPFeePaidLAW();
                CheckNMSWPFeePaidAll();

                CheckNMSWPNOCAll();
                CheckNMSWPREJECTAll();




                //checkLandAllotmentStatus();
                //CheckNMSWPFeePaidEX();
                //CheckNMSWPObjectionAll();
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);
                return;
            }
        }

        /// <summary>
        /// For PIP transfer from Fee Paid to Forward
        /// </summary>


        private void CheckNMSWPFeePaidPIP()
        {
            try
            {
                try { con.Open(); } catch { }
                SqlCommand cmd9 = new SqlCommand("select * from tbl_NMSWPTransactionDetails where ServiceID = 'SC21044' and isnull(Fee_Status,'') in ('Pending')", con);
                SqlDataReader sdr = cmd9.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string ControlID = sdr["ControlID"].ToString();
                        string UnitID = sdr["UnitId"].ToString();
                        string ServiceID = sdr["ServiceId"].ToString();
                        string RequestID = sdr["RequestID"].ToString();
                        string ServiceReqNo = sdr["ServiceRequestNo"].ToString();

                        DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, RequestID);
                        string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                        if (StatusCode == "11")
                        {
                            int retVal11 = objServiceTimelinesBLL.SaveTransactionDetailsNMSWPPIPCom(objServiceTimelinesBEL);
                            if (retVal11 > 0)
                            {
                                //lblPaystatus.Text = "Payment Completed";
                            }
                            Status_Code = "05";
                            Remarks = "Application Forwarded to Nodal Officer PIP";

                            string Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "05", "Application Forwarded to Nodal Officer PIP", RequestID, "Pending At Nodal Officer PIP", "");
                            if (Result == "SUCCESS")
                            {
                                string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                                string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                                string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                                string Dt = gm.UpdateNMSWPFeePaidPIP(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                                int retVal2 = 0;
                                objServiceTimelinesBEL.KYCID = ServiceReqNo;
                                retVal2 = objServiceTimelinesBLL.FormFinalSubmissionPIP(objServiceTimelinesBEL);
                                if (retVal2 >= 0)
                                {
                                    //string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo));
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

        /// <summary>
        /// For Logistic ware housing transfer from Fee Paid to Forward
        /// </summary>
        private void CheckNMSWPFeePaidLAW()
        {
            try
            {
                try { con.Open(); } catch { }
                SqlCommand cmd9 = new SqlCommand("Select * from tbl_NMSWPTransactionDetailsLAW where ServiceID = 'SC21036' ", con);
                SqlDataReader sdr = cmd9.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string SWCControlID = sdr["ControlID"].ToString();
                        string SWCUnitID = sdr["UnitId"].ToString();
                        string SWCServiceID = sdr["ServiceId"].ToString();
                        string SWCRequest_ID = sdr["RequestID"].ToString();
                        string ServiceReqNo = sdr["ServiceRequestNo"].ToString();

                        DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                        string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                        if (StatusCode == "11")
                        {
                            string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                            string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                            string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                            string Dt = gm.UpdateNMSWPFeePaidLAW(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                            if (Dt == "Success")
                            {
                                string ResultAll = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Nodal Officer WareHousing", RequestID, "Pending At Nodal Officer WareHousing", "");
                                if (ResultAll == "SUCCESS")
                                {

                                }
                                else
                                {

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

        /// <summary>
        /// For Forward to Nodal Officer or RM from Fee Paid
        /// </summary>
        private void CheckNMSWPFeePaidAll()
        {
            try
            {
                try { con.Open(); } catch { }
                SqlCommand cmd9 = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ServiceID in ('SC21025','SC21015','SC21013') and isnull(Fee_Status,'') in ('Pending')", con);
                SqlDataReader sdr = cmd9.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string SWCControlID = sdr["ControlID"].ToString();
                        string SWCUnitID = sdr["UnitId"].ToString();
                        string SWCServiceID = sdr["ServiceId"].ToString();
                        string SWCRequest_ID = sdr["RequestID"].ToString();
                        string ServiceReqNo = sdr["ServiceRequestNo"].ToString();

                        DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                        string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                        if (StatusCode == "11")
                        {
                            string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                            string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                            string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                            string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                            if (Dt == "Success")
                            {
                                string ResultAll = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                                if (ResultAll == "SUCCESS")
                                {

                                }
                                else
                                {

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
                
        private void CheckNMSWPNOCAll()
        {
            try
            {
                try { con.Open(); } catch { }
                SqlCommand cmd9 = new SqlCommand("SELECT * FROM ServiceRequests WHERE IsCompleted= 1 AND  CompletedOn >= DATEADD(MONTH, -1, GETDATE()) AND CompletedOn <= GETDATE()", con);
                SqlDataReader sdr = cmd9.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string SWCControlID = sdr["ControlID"].ToString();
                        string SWCUnitID = sdr["UnitId"].ToString();
                        string SWCServiceID = sdr["ServiceId"].ToString();
                        string SWCRequest_ID = sdr["RequestID"].ToString();
                        string ServiceReqNo = sdr["ServiceRequestNo"].ToString();

                        DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                        string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                        if (StatusCode != "15")
                        {
                            Status_Code = "15";
                            /*
                            if (ServiceID == "SC21038")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wNS8yNS9TLzYxNjc=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21002")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER201812131359/1/24118/7380" + ServiceReqNo.Trim() + "&DocType=BuildingPlan";
                            }
                            else if (ServiceID == "SC21001")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20190805/1000/20478/1779" + ServiceReqNo.Trim() + "&DocType=Allotment";
                            }
                            else if (ServiceID == "SC21027")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=SER20220829/1028/17379/57646&TraId=95586333" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21022")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/ReservationMoneyPaymentAck.aspx?ServiceReqNo=SER20201109/200/28747/9063&TraId=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21033")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=SER20220217/2000/5313/41529" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21003")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200529/1/25191/5078&DocType=BuildingPlan" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21043")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wOS8xMy9TLzI4NTE=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21012")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210304/1004/23909/14034&DocType=AdditionOfProduct" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21041")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_amalgation_certificate.php?cid=MjAyMy8wNy8yNy9BTS81MjIz" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21031")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20221018/1026/17396/60632&DocType=Subleting" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21013")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200706/1003/5812/6069&DocType=ChangeOfProject" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21030")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20201130/1025/24924/9769&DocType=AdditionOfProduct" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21032")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210212/1017/30249/13179&DocType=HandOverleasedeed" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21020")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20201122/1014/22090/9504&DocType=startofproduction" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21016")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210909/1005/11330/20905&DocType=nocmortgage" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21014")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210124/1001/30371/12305&DocType=SignedLease" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21039")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wOC8xOS9TLzQwMjc=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21029")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200709/1023/25191/6135&DocType=NoDues" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21028")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230522/1027/19082/72834&DocType=OutstandingDues" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21017")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20231007/1007/7478/84508&DocType=secondcharge" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21018")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20211029/1006/10495/26980&DocType=Jointmortgage" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21023")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20211023/1021/9326/26688&DocType=Reconstitutionforlegalheir" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21024")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200822/1008/18430/6926&DocType=ReconstitutionOfCompany" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21021")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230516/1012/46269/72636&DocType=NOC%20Issued" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21026")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20220304/1024/21420/44674&DocType=surrender" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21015")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20210122/1002/22090/12179&DocType=Timeextensionfee" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21019")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20230216/1011/12383/68392&DocType=transferofleasedeed" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21025")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=SER20200620/4/11915/5476&DocType=Transfer" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            else if (ServiceID == "SC21040")
                            {
                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                NOC_URL = "https://upsida.obpas.up.gov.in/nivesh_mitra/download_approved_sanction_certificate.php?cid=MjAyMy8wNi8yNy9TLzU0OTY=" + ServiceReqNo.Trim() + "&DocType=" + txtRemarks.Text;
                            }
                            */

                        }

                        /*
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        string Update_Result = webService.WReturn_CUSID_STATUS(
                        ControlID,
                        UnitID,
                        ServiceID,
                        ProcessIndustryID,
                        ApplicationID,
                        Status_Code,
                        Remarks,
                        "Applicant",
                        Fee_Amount,
                        Fee_Status,
                        Transaction_ID,
                        Transaction_Date,
                        Transaction_Date_Time,
                        ServiceReqNo,
                        NOC_URL,
                        ISNOC_URL_ActiveYesNO,
                        passsalt,
                        //txtRequestID.Text,
                        Objection_Rejection_Code,
                        "Yes",
                        Certificate_EXP_Date_DDMMYYYY,
                        D1,
                        D2,
                        D3,
                        D4,
                        D5,
                        D6,
                        D7
                        );
                        */
                        string ResultAll = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                        if (ResultAll == "SUCCESS")
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CheckNMSWPREJECTAll()
        {
            try
            {
                try { con.Open(); } catch { }
                SqlCommand cmd9 = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ServiceID in ('SC21025','SC21015','SC21013') and isnull(Fee_Status,'') in ('Pending')", con);
                SqlDataReader sdr = cmd9.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string SWCControlID = sdr["ControlID"].ToString();
                        string SWCUnitID = sdr["UnitId"].ToString();
                        string SWCServiceID = sdr["ServiceId"].ToString();
                        string SWCRequest_ID = sdr["RequestID"].ToString();
                        string ServiceReqNo = sdr["ServiceRequestNo"].ToString();

                        DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                        string StatusCode = dt.Rows[0]["Status_Code"].ToString();
                        if (StatusCode == "11")
                        {
                            string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                            string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                            string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                            string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                            if (Dt == "Success")
                            {
                                string ResultAll = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                                if (ResultAll == "SUCCESS")
                                {

                                }
                                else
                                {

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










        private void CheckNMSWPFeePaidEX()
        {
            string SWCControlID = "UPSWP190386786";
            string SWCUnitID = "UPSWP19038678601";
            string SWCServiceID = "SC21027";
            string SWCRequest_ID = "19038678601210270001";
            string ServiceReqNo = "SER20231009/1028/15692/84575";


            SqlCommand cmd = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ControlID='" + SWCControlID.Trim() + "' and UnitID='" + SWCUnitID.Trim() + "' and ServiceID='" + SWCServiceID.Trim() + "' and RequestID='" + SWCRequest_ID + "' ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {



                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "05")
                {
                    string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                    //string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                    //if (Dt == "Success")
                    //{
                    string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                    if (Result == "SUCCESS")
                    {
                        string NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&TraId=" + TransactionID + "";

                        string NMSWP_Result1 = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, (15).ToString(), "Outstanding Dues Payment Receipt Generated", NOC_URL, ServiceReqNo.Trim(), SWCRequest_ID, "");

                    }
                    else
                    {

                    }
                    //}
                }


            }
        }



        /// <summary>
        /// For Land allotment transfer from temp to Main
        /// </summary>
        private void checkLandAllotmentStatus()
        {
            //SER20231013/1000/2885/84983
            string UPSIDCRefrence = "TRAN1000/26743";
            GeneralMethod gm1 = new GeneralMethod();
            SqlCommand cmd = new SqlCommand("GetNiveshMitraID '" + UPSIDCRefrence + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int result = 0;
                string controlid = dt.Rows[0]["SWCControlId"].ToString();
                string unitid = dt.Rows[0]["SWCUnitId"].ToString();
                string serviceid = dt.Rows[0]["SWCServiceId"].ToString();
                string ID = dt.Rows[0]["ApplicationId"].ToString();
                string Request_ID = dt.Rows[0]["SWCRequestId"].ToString();
                string Is_Certificate_Valid_Life_Time = "";
                objServiceTimelinesBEL.ServiceRequestNO = ID;

                if (serviceid == "SC21001")
                {
                    result = objServiceTimelinesBLL.MoveTemppplicationDataToMainTable(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        Status_Code = "13";
                        Remarks = "EMD Payment Paid & Form Submitted | DA " + gm1.Get_IAName_ByServiceRequstNo(ID);
                        string Pendancy_level = "DA " + gm1.Get_IAName_ByServiceRequstNo(ID);

                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        string Update_Result = webService.WReturn_CUSID_STATUS(
                        controlid,
                        unitid,
                        serviceid,
                        ProcessIndustryID,
                        ApplicationID,
                        Status_Code,
                        Remarks,
                        Pendancy_level,
                        Fee_Amount,
                        Fee_Status,
                        Transaction_ID,
                        Transaction_Date,
                        Transaction_Date_Time,
                        NOC_Certificate_Number,
                        NOC_URL,
                        ISNOC_URL_ActiveYesNO,
                        passsalt,
                        Request_ID,
                        Objection_Rejection_Code,
                        Is_Certificate_Valid_Life_Time,
                        Certificate_EXP_Date_DDMMYYYY,
                        D1,
                        D2,
                        D3,
                        D4,
                        D5,
                        D6,
                        D7
                      );


                    }
                }

            }


        }

        

        /// <summary>
        /// For Clarification or Objection
        /// </summary>
        private void CheckNMSWPObjectionAll()
        {
            try
            {
                using (con)
                {
                    using (SqlCommand cmdObj = new SqlCommand("Select SR.IsClarificationReq, SR.ServiceRequestNO, SR.NMControlID, SR.NMUnitID, SR.NMRequestID,SR.NMServiceID, OLU.Objection, OLU.ObjectionType from ServiceRequests SR, ApplicationObjectionLookUp OLU where SR.ServiceRequestNO = OLU.ServiceReqNo and  SR.IsClarificationReq = '1' and SR.NMControlID != ''"))
                    {
                        cmdObj.CommandType = CommandType.Text;
                        cmdObj.Connection = con;
                        con.Open();
                        SqlDataReader sdr = cmdObj.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                string SWCControlID = sdr["NMControlID"].ToString();
                                string SWCUnitID = sdr["NMUnitID"].ToString();
                                string SWCServiceID = sdr["NMServiceID"].ToString();
                                string SWCRequest_ID = sdr["NMRequestID"].ToString();
                                string ServiceReqNo = sdr["ServiceRequestNO"].ToString();
                                string ObjectionVal = sdr["Objection"].ToString();
                                string ObjectionType = sdr["ObjectionType"].ToString();

                                if (SWCControlID.Length > 0)
                                {
                                    string Status = "08";
                                    string Remarks = ObjectionVal + " | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + " raises query and objection to Applicant";
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status, Remarks, SWCRequest_ID, "Applicant", ObjectionType);
                                    if (NMSWP_Result == "SUCCESS")
                                    {
                                        string result = NMSWP_Result;
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

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



        public void fetchNMdetails()
        {
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("select * from ServiceRequests where ServiceRequestNO ='" + ServiceReqNo + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ControlID = sdr["NMControlID"].ToString();
                            UnitID = sdr["NMUnitId"].ToString();
                            ServiceID = sdr["NMServiceId"].ToString();
                            RequestID = sdr["NMRequestID"].ToString();
                            //DocPath = sdr["DocPath"].ToString();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void niveshmitrastatusupdate(string ControlID, string UnitID, string ServiceID, string RequestID)
        {
            try
            {
                fetchNMdetails();

                Status_Code = "05";
                Remarks = "Application Forwarded to Nodal Officer PIP";

                string Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "05", "Application Forwarded to Nodal Officer PIP", RequestID, "Pending At Nodal Officer PIP", "");
                if (Result == "SUCCESS")
                {

                }
                else
                {

                }
            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }
    }
}