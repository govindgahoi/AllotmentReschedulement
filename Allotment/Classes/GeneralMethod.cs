using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace Allotment
{
    public class GeneralMethod
    {

        SqlConnection con;
        #region "Logistic & warehousing"
        public DataTable EvaluationCheklistBindLAW(string ServicereqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetServiceChecklists_LAW_Main] '" + ServicereqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable EvaluationCheklistBindPIP(string ServicereqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetServiceChecklists_PIP_Main] '" + ServicereqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }



        #endregion 

        #region "Plot Advertise"

        public DataTable GetPlotDisplayDate()
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[sp_getplotdisplaydate]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region "NMSWP Status Code"
        public DataTable GetServiceReqNoMain(string ServiceReqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(@"[GetLAMainServiceReqnoTable_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }

        }
        public string GetNMSWPRejectionID(string ServiceReqNo)
        {
            GetConnection();
            string NMSWPIDs = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDRejectionType] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    NMSWPIDs = dt.Rows[0][0].ToString();
                }

                return NMSWPIDs;
            }
            catch (Exception ex)
            {
                return "failed";
            }
            finally
            {
                con.Close();
            }

        }
        public string SendSMS(string Service, string PhoneNo, string Name, string Message)
        {

            try
            {
                WebClient client = new WebClient();
                string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=DhirendP&password=69525868&sendername=APSIDA&mobileno=" + PhoneNo.Trim() + "&message=" + Message.Trim() + "";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (Exception)
            {
                return "Error";
            }


        }
        public string SendOTP(string Service, string PhoneNo, string Name, string Message)
        {

            try
            {
                WebClient client = new WebClient();
                string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=DhirendP&password=69525868&sendername=APSIDA&mobileno=" + PhoneNo.Trim() + "&message=" + Message.Trim() + "";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (Exception)
            {
                return "Error";
            }


        }
        public string CreateTransactionDataBeforePaymentGetewayHDFCNMSWP(string ServiceRequestNo, string requesterMode)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[CreateTransactionDataBeforeGetewayForHDFC]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RequesterMode", requesterMode);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string UpdateNMSWPFeePaid(string TransactionID, string TransactionDate, string TransactionDatetime, string ServiceReqNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[UpdateNMSWPFeePAid]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                cmd.Parameters.AddWithValue("@TransactionDatetime", TransactionDatetime);
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }



        public string UpdateNMSWPFeePaidLAW(string TransactionID, string TransactionDate, string TransactionDatetime, string ServiceReqNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[UpdateNMSWPFeePAidLAW]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                cmd.Parameters.AddWithValue("@TransactionDatetime", TransactionDatetime);
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string UpdateNMSWPFeePaidPIP(string TransactionID, string TransactionDate, string TransactionDatetime, string ServiceReqNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[UpdateNMSWPFeePAidPIP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                cmd.Parameters.AddWithValue("@TransactionDatetime", TransactionDatetime);
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0][0].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string CreateTransactionDataBeforeNMSWP(string ServiceRequestNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[CreateTransactionDataBeforeGetewayNMSWP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }
        public string UpdateTraStatusNMSWP(string ServiceRequestNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[UpdateTraNMSWP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }
        public string UpdateNOCStatusAtNMSWP(string ControlID, string UnitID, string ServiceID, string Status_Code, string Remarks, string NOC_URL, string Certificate_Number, string Request_ID, string Objection_Rejection_Code)
        {

            string ProcessIndustryID = "";
            string ApplicationID = "";
            string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            string Fee_Amount = "";
            string Fee_Status = "";
            string Transaction_ID = "";
            string Transaction_Date = "";
            string Transaction_Date_Time = "";
            string NOC_Certificate_Number = Certificate_Number;
            string ISNOC_URL_ActiveYesNO = "Yes";
            string Update_Result = "";

            string Certificate_EXP_Date_DDMMYYYY = "";

            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D4 = "";
            string D5 = "";
            string D6 = "";
            string D7 = "";

            try
            {
                if (ControlID.Length > 0)
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    Update_Result = webService.WReturn_CUSID_STATUS(
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
                    NOC_Certificate_Number,
                    NOC_URL,
                    ISNOC_URL_ActiveYesNO,
                    passsalt,
                    Request_ID,
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
                }

                return Update_Result;
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }

        public string UpdateStatusAtNMSWP(string ControlID, string UnitID, string ServiceID, string Status_Code, string Remarks, string Request_ID, string Pendancy_level, string Objection_Rejection_Code)
        {

            string ProcessIndustryID = "";
            string ApplicationID = "";
            string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            string Fee_Amount = "";
            string Fee_Status = "";
            string Transaction_ID = "";
            string Transaction_Date = "";
            string Transaction_Date_Time = "";
            string NOC_Certificate_Number = "";
            string NOC_URL = "";
            string ISNOC_URL_ActiveYesNO = "";
            string Update_Result = "";

            string Certificate_EXP_Date_DDMMYYYY = "";
            string Is_Certificate_Valid_Life_Time = "";
            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D4 = "";
            string D5 = "";
            string D6 = "";
            string D7 = "";
            try
            {
                if (ControlID.Length > 0)
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    Update_Result = webService.WReturn_CUSID_STATUS(
                    ControlID,
                    UnitID,
                    ServiceID,
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

                return Update_Result;
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }

        public string UpdateFeeAtNMSWP(string ControlID, string UnitID, string ServiceID, string Status_Code, string Remarks, string Fee_Amount, string Request_ID, string Pendancy_level)
        {

            string ProcessIndustryID = "";
            string ApplicationID = "";
            string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            string Fee_Status = "UB";
            string Transaction_ID = "";
            string Transaction_Date = "";
            string Transaction_Date_Time = "";
            string NOC_Certificate_Number = "";
            string NOC_URL = "";
            string ISNOC_URL_ActiveYesNO = "";
            string Update_Result = "";

            string Objection_Rejection_Code = "";
            string Certificate_EXP_Date_DDMMYYYY = "";
            string Is_Certificate_Valid_Life_Time = "";
            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D4 = "";
            string D5 = "";
            string D6 = "";
            string D7 = "";
            try
            {
                if (ControlID.Length > 0)
                {
                  ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                  Update_Result = webService.WReturn_CUSID_STATUS(
                  ControlID,
                  UnitID,
                  ServiceID,
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

                return Update_Result;
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }


        public DataTable GetNMSWP_Details(string ControlID, string UnitID, string ServiceID, string Request_ID)
        {
            DataTable dt = new DataTable();
            GetConnection();
            try
            {
                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                DataSet dss = webService.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, "p5632aa8a5c915ba4b896325bc5baz8k", Request_ID);
                dt = dss.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }



        public string GetNMSWPIDs(string ServiceReqNo)
        {
            GetConnection();
            string NMSWPIDs = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDs_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    NMSWPIDs = dt.Rows[0][0].ToString();
                }

                return NMSWPIDs;
            }
            catch (Exception ex)
            {
                return "failed";
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetNMSWPIDNews(string ServiceReqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDsTable_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetNMSWPIDForBP(string ServiceReqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDsForBuildingPlanTable_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable GetNMSWPIDsFromTRAIDTable(string ServiceReqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDsFormTRAIDTable_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }

        }


        public string GetNMSWPIDsFromTRAID(string ServiceReqNo)
        {
            GetConnection();
            string NMSWPIDs = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDsFormTRAID_Sp] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    NMSWPIDs = dt.Rows[0][0].ToString();
                }

                return NMSWPIDs;
            }
            catch (Exception ex)
            {
                return "failed";
            }
            finally
            {
                con.Close();
            }

        }


        public string GetNMSWPIDsFromTRAIDDues(string TraID)
        {
            GetConnection();
            string NMSWPIDs = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetNMSWPIDsFormTRAIDDem_Sp] '" + TraID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    NMSWPIDs = dt.Rows[0][0].ToString();
                }

                return NMSWPIDs;
            }
            catch (Exception ex)
            {
                return "failed";
            }
            finally
            {
                con.Close();
            }

        }
        #endregion


        public string GetServiceRequestNoFromTraRefNo(string DemandRefNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("select ServiceNo 'ServiceRequestNo' from DemandServiceHeader where TransactionId_UPSIDC='" + DemandRefNo + "'", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["ServiceRequestNo"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception ex)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string GetServiceRequestNoFromDemandRefNo(string DemandRefNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("select ServiceRequestNo from DemandNoteHeader where DemandNo='" + DemandRefNo + "'", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["ServiceRequestNo"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception ex)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }
        public SqlConnection GetConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try { con.Open(); } catch { };
            return con;
        }

        public string Get_Approval_Rejection_Status(string id)
        {
            string return_string = "";
            try
            {

                GetConnection();
                SqlCommand cmd = new SqlCommand(@"select case when isnull(isCompleted,0)=1 then 'Completed' else 'Rejected' end 'Status' from ServiceRequests where ServiceRequestNO='" + id + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = dt.Rows[0]["Status"].ToString();
                }



                return return_string;
            }
            catch
            {
                return "";
            }
        }

        public string SendToPaymentGetwayHDFCNew(decimal AmountPayble, string CustUnique_Id, string ServicesRequestNumber, string Shopping_CartDetails, string Cust_Name, string Cust_Emailid, string Cust_Mobno, string Type)
        {
         //  string rtrn_url = "http://localhost:50610/HDFCresponse.aspx/";

          string rtrn_url = "https://eservices.onlineupsidc.com/HDFCresponse.aspx";

            string rqst_type = "T";
            //test URL
            //string instId = "4042";
            //string merchant_id = "4042";
          // string instId = "4038";
            // string merchant_id = "4038";

            //Live URL
            string instId = "UPLK";
           string merchant_id = "UPLK";
            string clnt_txn_ref = CustUnique_Id;
           // string rqst_amnt = "5000";
            string rqst_amnt = AmountPayble.ToString();
            string rqst_crncy = "INR";
            string itc = "Test";
            //string cart_dtls = "Other Fee" + rqst_amnt + "_0.00";
            string cart_dtls = "TOTAL FEES_" + rqst_amnt + "_0.00";

            //string clnt_dt_tm = "30-08-2018";
            string clnt_dt_tm = DateTime.Now.ToString("dd-MM-yyyy");
            string pymt_mode = "";
            if (Type == "One")
            {
                pymt_mode = "";
            }
            else
            {
                pymt_mode = "";
            }
            string tpsl_bank_cd = "";
            string cust_name = Cust_Name;
            string cust_emailid = Cust_Emailid;
            string cust_mobno = Cust_Mobno;
            string cust_unique_id = ServicesRequestNumber;
            string tran_id = "";

            string Key = "1989083233a696819f2623039a9f8adf";

            string message;
            message = "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" + "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                   + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                   + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                   + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id;

            //message = "rqst_type=T|merchant_id=4042|clnt_txn_ref=BIMCA1014424211|rqst_amnt=1|rqst_crncy=INR|itc=Test|rtrn_url=http://localhost:6611/response.aspx|cart_dtls=Totalfees_1.00_0.00|clnt_dt_tm=24-08-2018 12:56:15|pymt_mode=|tpsl_bank_cd=|cust_name=Manish Shukla|cust_emailid=manish.ims08@gmail.com|cust_mobno=9650425760|cust_unique_id=TRAA1000/1878|tran_id=";//plain string before the encryption;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(Key);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            string finalstr = ByteToString(hashmessage);
            string Checksum = finalstr.ToLower();

            string encryptredirecturl = "";
            // string Reference_no = IN_Reference;


            //  string pgamount = 1.ToString();



            try
            {
                encryptredirecturl += "https://smarthubgovernment.hdfcbank.com/SmartHubGovt/InstituteURL.action?";
                //encryptredirecturl += "https://www.tecprocesssolution.com/SmartHubGovt_UAT/InstituteURL.action?";
                encryptredirecturl += "instId=" + instId;
                encryptredirecturl += "&data=" + "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" +
                                    "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                    + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                    + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                    + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id + "|" + "Checksum=" + Checksum;

                return encryptredirecturl;
            }
            catch
            {
                return "Failed";
            }

            // Response.Redirect(encryptredirecturl);

        }

        public string GetBPfeePaidStatus(string ID)
        {

            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand(" sp_getFeePaidStatus '" + ID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string FeePaid = dt.Rows[0][0].ToString();
                return FeePaid;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string GetObjectionStatus(string ID)
        {

            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand(" sp_getObjectionStatus '" + ID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string FeePaid = dt.Rows[0][0].ToString();
                return FeePaid;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string GetRejectionStatus(string ID)
        {

            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand(" sp_getrejectionStatus '" + ID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string FeePaid = dt.Rows[0][0].ToString();
                return FeePaid;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string GetServiceDate(string ID)
        {

            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand(" sp_getServiceDate '" + ID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string FeePaid = dt.Rows[0][0].ToString();
                return FeePaid;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string SendToPaymentGetwayHDFC(decimal AmountPayble, string CustUnique_Id, string ServicesRequestNumber, string Shopping_CartDetails, string Cust_Name, string Cust_Emailid, string Cust_Mobno)
        {

           // string rtrn_url = "http://localhost:50610/HDFCresponse.aspx/";
            string rtrn_url = "https://eservices.onlineupsidc.com/HDFCresponse.aspx";
            //string rtrn_url = "http://test.onlineupsidc.com/HDFCresponse.aspx";
            //string rtrn_url = "http://services.stagingupsida.com/HDFCresponse.aspx";

            string rqst_type = "T";
            //test URL
            //string instId = "4042";
            //string merchant_id = "4042";
             // string instId = "4038";
              //string merchant_id = "4038";

            //Live URL
            string instId = "UPLK";
           string merchant_id = "UPLK";
            string clnt_txn_ref = CustUnique_Id;
            //  string rqst_amnt = "10";
            string rqst_amnt = AmountPayble.ToString();
            string rqst_crncy = "INR";
            string itc = "Test";
            //string cart_dtls = "Other Fee" + rqst_amnt + "_0.00";
            string cart_dtls = "TOTAL FEES_" + rqst_amnt + "_0.00";

            //string clnt_dt_tm = "30-08-2018";
            string clnt_dt_tm = DateTime.Now.ToString("dd-MM-yyyy");
            string pymt_mode = "";
            string tpsl_bank_cd = "";
            string cust_name = Cust_Name;
            string cust_emailid = Cust_Emailid;
            string cust_mobno = Cust_Mobno;
            string cust_unique_id = ServicesRequestNumber;
            string tran_id = "";

            string Key = "1989083233a696819f2623039a9f8adf";

            string message;
            message = "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" + "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                   + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                   + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                   + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id;

            //message = "rqst_type=T|merchant_id=4042|clnt_txn_ref=BIMCA1014424211|rqst_amnt=1|rqst_crncy=INR|itc=Test|rtrn_url=http://localhost:6611/response.aspx|cart_dtls=Totalfees_1.00_0.00|clnt_dt_tm=24-08-2018 12:56:15|pymt_mode=|tpsl_bank_cd=|cust_name=Manish Shukla|cust_emailid=manish.ims08@gmail.com|cust_mobno=9650425760|cust_unique_id=TRAA1000/1878|tran_id=";//plain string before the encryption;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(Key);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            string finalstr = ByteToString(hashmessage);
            string Checksum = finalstr.ToLower();

            string encryptredirecturl = "";
            // string Reference_no = IN_Reference;
            //  string pgamount = 1.ToString();



            try
            {
                encryptredirecturl += "https://smarthubgovernment.hdfcbank.com/SmartHubGovt/InstituteURL.action?";
            //   encryptredirecturl += "https://www.tecprocesssolution.com/SmartHubGovt_UAT/InstituteURL.action?";
                encryptredirecturl += "instId=" + instId;
                encryptredirecturl += "&data=" + "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" +
                                    "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                    + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                    + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                    + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id + "|" + "Checksum=" + Checksum;

                return encryptredirecturl;
            }
            catch
            {
                return "Failed";
            }


        }

        public string SendToPaymentGetway(decimal AmountPayble, string IN_Reference, string IN_Reference1, string IN_Reference2, string IN_Reference3)
        {

            // string returnurl = "http://localhost:2524/response.aspx";
            string returnurl = "http://services.onlineupsidc.com/response.aspx";
            string ASEKEY = "1362881115605021";
            string merchantid = "131561";
            string paymode = "9";
            string sub_merchant_id = "1";
            string encryptredirecturl = "";
            string Reference_no = IN_Reference;
            string Reference_no1 = IN_Reference1;
            string Reference_no2 = IN_Reference2;
            string pgamount = AmountPayble.ToString();

            //  string pgamount = 1.ToString();


            try
            {
                encryptredirecturl += "https://eazypay.icicibank.com/EazyPG?";
                encryptredirecturl += "merchantid=" + merchantid;
                encryptredirecturl += "&mandatory fields=" + encryptFile(Reference_no + "|" + sub_merchant_id + "|" + pgamount, ASEKEY);
                encryptredirecturl += "&optional fields=" + encryptFile(IN_Reference3, ASEKEY);
                encryptredirecturl += "&returnurl=" + encryptFile(returnurl, ASEKEY);
                encryptredirecturl += "&Reference No=" + encryptFile(Reference_no, ASEKEY);
                encryptredirecturl += "&submerchantid=" + encryptFile(sub_merchant_id, ASEKEY);
                encryptredirecturl += "&transaction amount=" + encryptFile(pgamount, ASEKEY);
                encryptredirecturl += "&paymode=" + encryptFile(paymode, ASEKEY);

                return encryptredirecturl;
            }
            catch
            {
                return "Failed";
            }

            // Response.Redirect(encryptredirecturl);

        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }

        public static string encryptFile(string textToEncrypt, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.ECB;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) { len = keyBytes.Length; }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        public DataTable GetPlotAndLetterNoUsingControlID(string ControlID, string UnitID)
        {

            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("Select *,B.RegionalOffice, B.ID 'INDUID' from AllotteeMaster A, IndustrialArea B where A.IndustrialArea=B.IAName and  A.ControlID='" + ControlID + "' and A.UnitID='" + UnitID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string CreateTransactionDataBeforePaymentGetewayHDFCrevisedBp(string ServiceRequestNo, string requesterMode)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[CreateTransactionDataBeforeGetewayForHDFCRevised]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RequesterMode", requesterMode);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }
        }

        public string CreateTransactionDataBeforBeforePaymentGeteway(string ServiceRequestNo)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("CreateTransactionDataBeforeGeteway", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string CreateTransactionDataBeforePaymentGeteway(string ServiceRequestNo, string requesterMode)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("CreateTransactionDataBeforeGeteway", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RequesterMode", requesterMode);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception ex)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string CreateTransactionDataBeforePaymentGetewayHDFC(string ServiceRequestNo, string requesterMode)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[CreateTransactionDataBeforeGetewayForHDFC]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RequesterMode", requesterMode);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }
        public string CreateTransactionDataBeforePaymentGetewayHDFC_ForOTS(string ServiceRequestNo, string requesterMode, int flag)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("CreateTransactionDataBeforeGetewayForHDFC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RequesterMode", requesterMode);
                cmd.Parameters.AddWithValue("@flagCount", flag);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["TransactionId_UPSIDC"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }

        }

        public string GetDataManagerType(int userId, int IAID, int ServiceId)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("GetDataManagerType " + userId + "," + IAID + "," + ServiceId, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["DataManager"].ToString().Trim()).Trim();

                }

                return return_string;
            }
            catch
            {
                return "";
            }
            finally
            {
                con.Close();
            }

        }

        public string GetUserDesignation(int userId)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("[GetUserDesignationByUserID] " + userId, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["Level"].ToString().Trim()).Trim();

                }

                return return_string;
            }
            catch
            {
                return "";
            }
            finally
            {
                con.Close();
            }

        }


        public string GetUserDepartment1(int userId)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("Select Department from tbl_LidaUser where UserID='" + userId+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["Department"].ToString().Trim()).Trim();

                }

                return return_string;
            }
            catch
            {
                return "";
            }
            finally
            {
                con.Close();
            }

        }
        public string GetUserDepartment(int userId)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("Select Department from UPSIDCUser where UserID='" + userId + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["Department"].ToString().Trim()).Trim();

                }

                return return_string;
            }
            catch
            {
                return "";
            }
            finally
            {
                con.Close();
            }

        }

        public string GetServiceTicketStatusByUser(int userId, int PacketId, string ServiceRequestNo)
        {
            string return_string = "Close";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand(@"select * from ServiceTicket
                                                    where
                                                    PacketID = " + PacketId + @" and
                                                    ServiceName = '" + ServiceRequestNo + @"' and
                                                    TicketResponderID = " + userId + @" and
                                                    TicketStatus not in (7, 8) ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = "Open";
                }

                return return_string;
            }
            catch
            {
                return "";
            }
        }

        public string GetServiceTicketFor(string TicketId)
        {
            string return_string = "";
            try
            {
                if (TicketId.Length > 0)
                {
                    GetConnection();
                    SqlCommand cmd = new SqlCommand(@"select * from ServiceTicket where
                                                  ServiceTicketId = " + TicketId + @"  
                                                 ", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return_string = dt.Rows[0]["TicketDescription"].ToString();
                    }
                }


                return return_string;
            }
            catch
            {
                return "";
            }
        }

        public string GetDataManagerByPacketAndStage(int PacketId, int ServiceStage)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("GetDataManagerByPacketAndStage " + PacketId + "," + ServiceStage + ", NULL ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["DataManager"].ToString().Trim()).Trim();
                }

                return return_string;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public int Get_IAID_ByServiceRequstNonew(string ServiceRequestNo)
        {
            int IAID = 0;

            GetConnection();
            using (SqlCommand cmd = new SqlCommand("Get_IAID_ByServiceRequstNonew ", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNO", ServiceRequestNo);
                cmd.Parameters.Add("@IAID", SqlDbType.Int);
                cmd.Parameters["@IAID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                con.Close();

                //IAID = int.Parse(cmd.Parameters["@IAID"].Value.ToString());
            }

            return IAID;
        }

        public int Get_IAID_ByServiceRequstNo(string ServiceRequestNo)
        {
            int IAID = 0;

            GetConnection();
            using (SqlCommand cmd = new SqlCommand("Get_IAID_ByServiceRequstNo ", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceRequestNO", ServiceRequestNo);
                cmd.Parameters.Add("@IAID", SqlDbType.Int);
                cmd.Parameters["@IAID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                con.Close();

                IAID = int.Parse(cmd.Parameters["@IAID"].Value.ToString());
            }

            return IAID;
        }

        public string Get_IAName_ByServiceRequstNo(string ServiceRequestNo)
        {
            string return_string = "";
            try
            {

                GetConnection();
                SqlCommand cmd = new SqlCommand(@"Get_IAName_ByServiceRequstNo '" + ServiceRequestNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = dt.Rows[0]["IAName"].ToString();
                }



                return return_string;
            }
            catch
            {
                return "";
            }
        }

        public string Get_IAName_ByID(int id)
        {
            string return_string = "";
            try
            {

                GetConnection();
                SqlCommand cmd = new SqlCommand(@"Select IAName from IndustrialArea where Id= " + id + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = dt.Rows[0]["IAName"].ToString();
                }



                return return_string;
            }
            catch
            {
                return "";
            }
        }

        public DataTable EvaluationCheklistBind(int ServiceID, string ServicereqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetServiceChecklists_Allotment_Main] '" + ServiceID + "','" + ServicereqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable EvaluationCheklistBuildingPlan(int ServiceID, string ServicereqNo)
        {
            GetConnection();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(@"[GetServiceChecklistsBuildingPlan] '" + ServiceID + "','" + ServicereqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable bind_IndustryPriorityCategoryMaster()
        {
            DataTable dt = new DataTable();
            GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from IndustryPriorityCategoryMaster", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);

                return dt;


            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable bind_Inspector(string ServiceRequestNo)
        {
            DataTable dt = new DataTable();
            GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(@" SELECT DISTINCT DD.[userId], dd.[UserName] ,  dbo.[FUN_EmployeeName_ByUserID](DD.[userId]) EmployeeName
		                                            FROM (
	                                              	SELECT  [userId],[UserName],EE.Level, EE.IAID, EE.[Services] ,  EE.Role , AA.VALUE 'Service',				    EE.DataManager , EE.RegionalOffice
		                                            FROM 
			                                        (
			SELECT DISTINCT D.[userId], D.[UserName] ,D.Level , D.[Services], ST.VALUE 'IAID'   , D.Role , D.DataManager ,		d.RegionalOffice 
				FROM [UserAssociationMaster] AS D
				CROSS APPLY SPLIT(',',D.[IndustrialArea]) AS ST ) AS EE
				CROSS APPLY SPLIT(',',EE.[Services]) AS AA 
			) as DD  
				 WHERE DD.RegionalOffice    = [dbo].FUN_RegionalOffice_ByIAID( [dbo].[FUN_IAID_ByServiceReqNo]('" + ServiceRequestNo + @"'))    AND   
					   dd.Level = 'JE'

", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                con.Close();
            }
        }

        public string ServiceTicketCreationForSpecificService(int PacketId, string ServiceRequestNo, int TicketResponderId, int ServiceStage)
        {
            string return_string = "";
            try
            {
                GetConnection();
                SqlCommand cmd = new SqlCommand("ServiceTicketCreationForSpecificService", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PacketID", PacketId);
                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo);
                cmd.Parameters.AddWithValue("@RespondentID", TicketResponderId);
                cmd.Parameters.AddWithValue("@ServiceStage", ServiceStage);


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                }
                else
                {
                    return_string = "Ticket Creation Failed";
                }


                return return_string;
            }
            catch (Exception e)
            {
                return "Ticket Creation Failed !";
            }
            finally
            {
                con.Close();
            }

        }

        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

    }
}