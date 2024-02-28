using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace UpsidaAllottee
{
    public partial class NOC_OneTimeScheme : System.Web.UI.Page
    {
        SqlConnection con;
        String ServiceRequestNo = "";
        String RequestID = "";
        String ControlID = "";
        String UnitID = "";
        String ServiceID = "";
        string NM_DistrictID = "";
        string ProcessIndustryID = "";
        string ApplicationID = "";
        string Pendancy_level = "";
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
        string Is_Certificate_Valid_Life_Time = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                ServiceRequestNo = Request.QueryString["ServiceRequestNo"];
                RequestID = Request.QueryString["ReqNo"];
                if(Request.QueryString["ReqNo"]==null || Request.QueryString["ReqNo"] == "")
                {
                    lblPay.Visible = false;
                }
                if (!IsPostBack)
                {
                    DataTable dt = new DataTable();
                    if (ServiceRequestNo != "")
                    {
                        SqlCommand cmd = new SqlCommand("usp_Get_Detail_for_NOC", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@servicerequestNo", ServiceRequestNo);
                        SqlDataAdapter sda= new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            lblallottee.Text = dt.Rows[0]["AllotteeName"].ToString();
                            lblTransactionID.Text = dt.Rows[0]["Transaction_ID"].ToString();
                            lblDate.Text = dt.Rows[0]["Transaction_Date"].ToString();
                            lblEmail.Text = dt.Rows[0]["emailID"].ToString();
                            lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                            lblApplicationDate.Text = (Convert.ToDateTime(dt.Rows[0]["ApplicationDate"])).ToString("dd/MM/yyyy");
                            lblTotalDues.Text = (Convert.ToDouble(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDouble(dt.Rows[0]["InterestOnMCUpto"])).ToString();
                            lblWaiver.Text = dt.Rows[0]["Waive_Off"].ToString();
                            lblPayableAmount.Text = dt.Rows[0]["DownPayment"].ToString();
                            lblPaid.Text = dt.Rows[0]["Fee_Amount"].ToString();
                            
                            if (string.IsNullOrEmpty(dt.Rows[0]["Balance_Amount"].ToString()) == false )
                            {
                                lblRemaining.Text = dt.Rows[0]["Balance_Amount"].ToString();
                                lblPay.Enabled = true;
                            }
                            else
                            {
                                lblRemaining.Text = "Nil";
                                lblPay.Visible = false;
                            }
                           var today = DateTime.Today;
                           var dat = Convert.ToDateTime("2022-06-30");
                            if (today > dat)
                            {
                                lblPay.Visible = false;
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
        protected void click_Pay(object sender, EventArgs e)
        {
            //string TransactionId_UPSIDC = CreateTransactionDataBeforePaymentGetewayHDFC(ServiceRequestNo, "UPSIDC");
            DataTable dt = new DataTable();
            try
            {
                lblPay.Visible = false;
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where ServiceRequestNo='" + ServiceRequestNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if(string.IsNullOrEmpty(dt.Rows[0]["Bal_RequestID_1"].ToString()) == true && dt.Rows[0]["RequestID"].ToString()!= RequestID)
                    {
                        ControlID = dt.Rows[0]["ControlID"].ToString();
                        UnitID = dt.Rows[0]["UnitID"].ToString();
                        ServiceID = dt.Rows[0]["ServiceID"].ToString();
                        int SchemeType = Convert.ToInt32(dt.Rows[0]["SchemeType"]);
                        if (SchemeType == 0)
                        {
                            DataTable DT = new DataTable();
                            try
                            {
                                lblPay.Visible = true;
                                SqlCommand cmd1 = new SqlCommand("Update OTS_NMSWPTransactionDetail set Bal_RequestID_1='" + RequestID + "' where ServiceRequestNo='" + ServiceRequestNo + "'", con);
                                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                                adp1.Fill(DT);
                                string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, lblRemaining.Text, "UB", "OTS Balance Fee Pending", "Applicant", RequestID);
                                if (NMSWP_Result == "SUCCESS")
                                {
                                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + ServiceRequestNo + " \r\n Kindly Note Down This No For Future Reference.");
                                    var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                                    MailToAllotteeAfterApplied(dt);
                                }
                                else
                                {
                                    string message1 = "Error Occured while updating status at NMSWP";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        string message1 = "You have already applied. Please pay balance amount before 21st Mar 2022";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected string FeeStatusNM_Click(string ControlID, string UnitID, string ServiceID, string Fee_Amount, string Fee_Status, string Remarks, string Pendancy_level, string Request_ID)
        {
            string Update_Result = "";
            Status_Code = "12";
            try
            {
                if (ControlID.Length > 0)
                {
                    UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
        protected void MailToAllotteeAfterApplied(DataTable data)
        {
            // string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = lblallottee.Text;
            string allotteeID = data.Rows[0]["AllotteeID"].ToString();
            string emailID = lblEmail.Text;
            MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
            MailAddress mailto = new MailAddress(emailID);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);

            //newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("~/OTSAppliedRemainingMail.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
            StrContent = StrContent.Replace("{RemainingAmount}", lblRemaining.Text);


            newmsg.Subject = "Payment dues under your OTS Scheme";
            newmsg.BodyHtml = StrContent;


            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");

            //smtp.EnableSsl = true;
            //smtp.Send(newmsg);
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.outlook.com";
            client.Port = 587;
            client.Username = mailfrom.Address;
            client.Password = "upsida12345";
            client.ConnectionProtocols = ConnectionProtocols.Ssl;
            client.SendOne(newmsg);
        }
        public string CreateTransactionDataBeforePaymentGetewayHDFC(string ServiceRequestNo, string requesterMode)
        {
            string return_string = "";
            try
            {
                //GetConnection();
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
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
    }
}