using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;
namespace Allotment
{
    public partial class HDFCresponse : System.Web.UI.Page
    {
        SqlConnection con;
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
        public string PaymentAmount = "";
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
        string Request_ID = "";
        string Pendancy_level = "";
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
        string SWCRequest_ID = "";
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {      
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                if (Request.QueryString != null & Request.QueryString.Count > 0)
                {
                        //string controlid = "UPSWP190641863";
                        //string unitid = "UPSWP19064186301";
                        //string serviceid = "SC21001";
                        //string ID = "SER20190902/1000/5/135";
                        //string Request_ID = "19064186301210010001";

                    string queryStrings = HttpUtility.UrlDecode(Request.QueryString.ToString());
                    string Key = "1989083233a696819f2623039a9f8adf";
                    var arrQueryStrings = queryStrings.Split('|');
                    string MerchantCode = arrQueryStrings[0];//x=1,2
                    string Status = arrQueryStrings[1];//x=1,2
                    string Desc = arrQueryStrings[2];//x=1,2
                    string MerchantTxnRefNumber = arrQueryStrings[3];//x=1,2
                    string BankCode = arrQueryStrings[4];//x=1,2
                    string TPSLTransactionId = arrQueryStrings[5];//x=1,2
                    string Amount = arrQueryStrings[6];//x=1,2
                    string ProcessingDateTime = arrQueryStrings[7];//x=1,2
                    string Checksum = arrQueryStrings[8];//x=1,2
                    string message;
                    message = MerchantCode + "|" + Status + "|" + Desc + "|" + MerchantTxnRefNumber + "|" + BankCode + "|" + TPSLTransactionId + "|" + Amount + "|" + ProcessingDateTime;
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    byte[] keyByte = encoding.GetBytes(Key);
                    HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
                    byte[] messageBytes = encoding.GetBytes(message);
                    byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                    string finalstr = ByteToString(hashmessage);
                    string Checksum1 = finalstr.ToLower();
                    string MerchantCodes = MerchantCode.Split('=')[1].ToString();
                    string CodeStatus = Status.Split('=')[1].ToString();
                    string CodesDesc = Desc.Split('=')[1].ToString();
                    string MerchantTxnRefNumbers = MerchantTxnRefNumber.Split('=')[1].ToString();
                    string BankCodes = BankCode.Split('=')[1].ToString();
                    string TPSLTransactionIds = TPSLTransactionId.Split('=')[1].ToString();
                    string Amounts = Amount.Split('=')[1].ToString();
                    string ProcessingDateTimes = ProcessingDateTime.Split('=')[1].ToString();
                    string Checksums = Checksum.Split('=')[1].ToString();
                    PaymentAmount = Amounts;
                    if (Checksum1 == Checksums)
                    {
                        string msg = "";
                        try
                        {
                            objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC = MerchantTxnRefNumbers;
                            lblUPSIDCTran.Text = MerchantTxnRefNumbers;
                        }
                        catch (Exception ex) { Response.Write(ex.ToString()); }
                        objServiceTimelinesBEL.PayTrans_unique_ref = TPSLTransactionIds;
                        try
                        {
                            objServiceTimelinesBEL.PayTrans_response_code = CodeStatus;
                            lblResponseCode.Text = CodeStatus;
                        }
                        catch (Exception ex) { Response.Write(ex.ToString()); }

                        if (!string.IsNullOrEmpty(Amounts))
                        {
                            objServiceTimelinesBEL.PayTrans_trn_amt = Amounts;
                        }
                        if (!string.IsNullOrEmpty(Amounts))
                        {
                            objServiceTimelinesBEL.PayTrans_total_amt = Amounts;
                        }
                        if (!string.IsNullOrEmpty(ProcessingDateTimes))
                        {
                            objServiceTimelinesBEL.PayTrans_trn_date_hdfc = DateTime.Now.ToString();
                        }
                        if (!string.IsNullOrEmpty(TPSLTransactionIds))
                        {
                            objServiceTimelinesBEL.PayTrans_ref_no = TPSLTransactionIds;
                        }
                        if (!string.IsNullOrEmpty(MerchantCodes))
                        {
                            objServiceTimelinesBEL.PayTrans_id = "9399";
                        }
                        if (!string.IsNullOrEmpty(MerchantCodes))
                        {
                            objServiceTimelinesBEL.PayTrans_MerchantId = MerchantCodes;
                        }
                        if (!string.IsNullOrEmpty(Checksums))
                        {
                            objServiceTimelinesBEL.PayTrans_rs = Checksums;
                        }
                        string GatewayResponse = "";
                        if (objServiceTimelinesBEL.PayTrans_response_code == "S") { GatewayResponse = "Payment Completed & Form Submitted"; }
                        if (objServiceTimelinesBEL.PayTrans_response_code == "F") { GatewayResponse = "Transaction Failed"; }
                        if (objServiceTimelinesBEL.PayTrans_response_code == "P") { GatewayResponse = "HDFC Challan Generated Successfully"; }
                        if (objServiceTimelinesBEL.PayTrans_response_code == "U") { GatewayResponse = "Payment Under clearance"; }
                        objServiceTimelinesBEL.GatewayResponse = GatewayResponse;
                        try
                        {
                            objServiceTimelinesBEL.PaymentMode = BankCodes;
                            string PaymentModeResponse = "";
                            lblPaymode.Text = PaymentModeResponse;
                            if (objServiceTimelinesBEL.PaymentMode == "470") { if (objServiceTimelinesBEL.PayTrans_response_code == "P") { PaymentModeResponse = "NEFT_RTGS"; } else { PaymentModeResponse = "Online"; } }
                            if (objServiceTimelinesBEL.PaymentMode == "10850") { PaymentModeResponse = "Credit Card"; }
                            if (objServiceTimelinesBEL.PaymentMode == "C") { PaymentModeResponse = "Cash"; }
                            if (objServiceTimelinesBEL.PaymentMode == "H") { PaymentModeResponse = "Cheque"; }
                            if (objServiceTimelinesBEL.PaymentMode == "D") { PaymentModeResponse = "DD"; }
                            if (objServiceTimelinesBEL.PaymentMode == "N") { PaymentModeResponse = "NEFT_RTGS"; }


                            switch (objServiceTimelinesBEL.PaymentMode)
                            {
                                case "340":
                                    PaymentModeResponse = "Bank of Bahrain and Kuwait";
                                    break;
                                case "310":
                                    PaymentModeResponse = "Bank of Baroda";
                                    break;
                                case "750":
                                    PaymentModeResponse = "Bank of Maharashtra";
                                    break;
                                case "930":
                                    PaymentModeResponse = "Canara Bank";
                                    break;
                                case "1130":
                                    PaymentModeResponse = "Catholic Syrian Bank";
                                    break;
                                case "740":
                                    PaymentModeResponse = "Central Bank of India";
                                    break;
                                case "370":
                                    PaymentModeResponse = "Dhanlaxmi Bank";
                                    break;
                                case "270":
                                    PaymentModeResponse = "Federal Bank";
                                    break;
                                case "490":
                                    PaymentModeResponse = "Indian Bank";
                                    break;
                                case "420":
                                    PaymentModeResponse = "Indian Overseas NetBanking";
                                    break;
                                case "350":
                                    PaymentModeResponse = "J&K Bank";
                                    break;
                                case "140":
                                    PaymentModeResponse = "Karnataka Bank";
                                    break;
                                case "760":
                                    PaymentModeResponse = "Karur Vysya Bank";
                                    break;
                                case "910":
                                    PaymentModeResponse = "Kotak Mahindra Bank";
                                    break;
                                case "1220":
                                    PaymentModeResponse = "Punjab National Bank";
                                    break;
                                case "180":
                                    PaymentModeResponse = "South Indian Bank";
                                    break;
                                case "450":
                                    PaymentModeResponse = "Standard Chartered Bank";
                                    break;
                                case "620":
                                    PaymentModeResponse = "Tamilnad Mercantile Bank";
                                    break;
                                case "190":
                                    PaymentModeResponse = "Union Bank of India";
                                    break;
                                case "570":
                                    PaymentModeResponse = "United Bank Of India";
                                    break;
                                case "200":
                                    PaymentModeResponse = "Vijaya Bank";
                                    break;
                                case "1500":
                                    PaymentModeResponse = "Ratnakar Bank";
                                    break;
                                case "1700":
                                    PaymentModeResponse = "SVC BANK";
                                    break;
                                case "160":
                                    PaymentModeResponse = "Oriental Bank Of Commerce";
                                    break;
                                case "230":
                                    PaymentModeResponse = "Citi Bank";
                                    break;
                                case "860":
                                    PaymentModeResponse = "Indusind Bank";
                                    break;
                                case "830":
                                    PaymentModeResponse = "ING Vysya Bank";
                                    break;
                                case "330":
                                    PaymentModeResponse = "Deustche Bank";
                                    break;
                                case "50":
                                    PaymentModeResponse = "Axis Bank";
                                    break;
                                case "240":
                                    PaymentModeResponse = "Bank of India";
                                    break;
                                case "10":
                                    PaymentModeResponse = "ICICI Bank";
                                    break;
                                case "440":
                                    PaymentModeResponse = "City Union Bank";
                                    break;
                                case "540":
                                    PaymentModeResponse = "DCB BANK Personal";
                                    break;
                                case "280":
                                    PaymentModeResponse = "Allahabad Bank";
                                    break;
                                case "120":
                                    PaymentModeResponse = "Corporation Bank";
                                    break;
                                case "300":
                                    PaymentModeResponse = "HDFC Bank Retail";
                                    break;
                                case "410":
                                    PaymentModeResponse = "HDFC Bank NetBanking";
                                    break;
                                case "520":
                                    PaymentModeResponse = "IDBI Bank";
                                    break;
                                case "950":
                                    PaymentModeResponse = "State Bank Of Bikaner and Jaipur";
                                    break;
                                case "560":
                                    PaymentModeResponse = "State Bank of Hyderabad";
                                    break;
                                case "530":
                                    PaymentModeResponse = "State Bank of India";
                                    break;
                                case "550":
                                    PaymentModeResponse = "State Bank of Mysore";
                                    break;
                                case "880":
                                    PaymentModeResponse = "State Bank of Patiala";
                                    break;
                                case "680":
                                    PaymentModeResponse = "State Bank of Travencore";
                                    break;
                                case "130":
                                    PaymentModeResponse = "Yes Bank";
                                    break;
                                case "1340":
                                    PaymentModeResponse = "VISA MASTER CREDIT CARD";
                                    break;
                                case "1350":
                                    PaymentModeResponse = "VISA MASTER DEBIT CARDS";
                                    break;
                                case "1590":
                                    PaymentModeResponse = "Rupay Card";
                                    break;
                                case "N":
                                    PaymentModeResponse = "NEFT_RTGS";
                                    break;


                            }
                            objServiceTimelinesBEL.PayMode = PaymentModeResponse;

                        }
                        catch (Exception ex) { Response.Write(ex.ToString()); }
                        if (!string.IsNullOrEmpty(objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC))
                        {
                            if (objServiceTimelinesBEL.PayTrans_response_code == "S" || objServiceTimelinesBEL.PaymentMode == "C" || objServiceTimelinesBEL.PaymentMode == "H" || objServiceTimelinesBEL.PaymentMode == "N" || objServiceTimelinesBEL.PayTrans_response_code == "P")
                            {
                                if (objServiceTimelinesBEL.PayTrans_response_code == "S")
                                {
                                    lt.Text = "<div class='payment-success'><i class='fa fa-check-square-o' aria-hidden='true'></i> <span>Payment Successful</span></div>";
                                }
                                else
                                {
                                    lt.Text = "<div class='payment-success'><i class='fa fa-check-square-o' aria-hidden='true'></i> <span>" + GatewayResponse + "</span></div>";
                                }
                            }
                            else
                            {
                                lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + GatewayResponse + " </span></div>";
                            }
                            string retVal = objServiceTimelinesBLL.UpdateHDFCAllotteTransaction(objServiceTimelinesBEL);
                            if (retVal == "Failed")
                            {
                                lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + GatewayResponse + " </span></div>";
                            }
                            else
                            {
                                //lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + retVal + " </span></div>";
                                if (objServiceTimelinesBEL.PayTrans_response_code == "S" || objServiceTimelinesBEL.PaymentMode == "N" || objServiceTimelinesBEL.PaymentMode == "C" || objServiceTimelinesBEL.PayTrans_response_code == "P")
                                {
                                    btnContinue.Enabled = true;
                                }


                                UPSIDCRefrence.Text = objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC;
                                banktransactionNo.Text = objServiceTimelinesBEL.PayTrans_unique_ref;
                                tranjectionDate.Text = objServiceTimelinesBEL.PayTrans_trn_date_hdfc.ToString();
                                lblAmmount.Text = objServiceTimelinesBEL.PayTrans_trn_amt;
                                lblPayStatus.Text = objServiceTimelinesBEL.GatewayResponse;
                                lblPaymode.Text = objServiceTimelinesBEL.PayMode;
                                var arr = UPSIDCRefrence.Text.Split('/');
                                string service = arr[0].Substring(4);
                                 
                                    if (service.Trim() == "100")
                                    {
                                        GeneralMethod gm = new GeneralMethod();
                                        string[] NMSWP = gm.GetNMSWPIDsFromTRAIDDues(UPSIDCRefrence.Text).Split('|');
                                        string SWCControlID = NMSWP[0].Trim();
                                        string SWCUnitID = NMSWP[1].Trim();
                                        string SWCServiceID = NMSWP[2].Trim();
                                        string SWCRequest_ID = NMSWP[3].Trim();
                                        string lblServiceReqNo = gm.GetServiceRequestNoFromTraRefNo(UPSIDCRefrence.Text);
                                        if (objServiceTimelinesBEL.PayTrans_response_code == "S")
                                        {
                                            int result = 0;
                                            objServiceTimelinesBEL.ServiceRequestNO = UPSIDCRefrence.Text;
                                            result = objServiceTimelinesBLL.SetServiceRequestFinishIAServiceDues(objServiceTimelinesBEL);

                                            if (SWCControlID.Length > 0)
                                            {
                                                string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "14", "Applicant Re-Submitted the form after clearing objection to | DA " + gm.Get_IAName_ByServiceRequstNo(lblServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(lblServiceReqNo), "");

                                            }
                                            SendPaymentConfirmationMail();
                                        }

                                    }
                                    else if (service.Trim() == "1009" || service.Trim() == "1010" || service.Trim() == "1029" || service.Trim() == "1030")
                                    {
                                        if (objServiceTimelinesBEL.PayTrans_response_code == "S")
                                        {
                                            int result = 0;
                                            objServiceTimelinesBEL.ServiceRequestNO = UPSIDCRefrence.Text;
                                            result = objServiceTimelinesBLL.SetServiceRequestFinishIAService(objServiceTimelinesBEL);
                                            SendPaymentConfirmationMail();
                                        }
                                    }
                                    else
                                    {

                                        if (objServiceTimelinesBEL.PayTrans_response_code == "P")
                                        {
                                            SqlCommand cmd = new SqlCommand("GetNiveshMitraID '" + UPSIDCRefrence.Text + "'", con);
                                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                            DataTable dt = new DataTable();
                                            adp.Fill(dt);
                                            if (dt.Rows.Count > 0)
                                            {
                                                string controlid = dt.Rows[0]["SWCControlId"].ToString();
                                                string unitid = dt.Rows[0]["SWCUnitId"].ToString();
                                                string serviceid = dt.Rows[0]["SWCServiceId"].ToString();
                                                Request_ID = dt.Rows[0]["SWCRequestId"].ToString();
                                                if (serviceid == "SC21001")
                                                {
                                                    Status_Code = "10";
                                                    Remarks = "EMD Payment Pending | Applicant";
                                                    Pendancy_level = "Applicant";
                                                }
                                                if (serviceid == "SC21002")
                                                {
                                                    Status_Code = "10";
                                                    Remarks = "Building Plan Approval Fee Pending | Applicant";
                                                    Pendancy_level = "Applicant";
                                                }
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

                                        if (objServiceTimelinesBEL.PayTrans_response_code == "F")
                                        {
                                            SqlCommand cmd = new SqlCommand("GetNiveshMitraID '" + UPSIDCRefrence.Text + "'", con);
                                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                            DataTable dt = new DataTable();
                                            adp.Fill(dt);
                                            if (dt.Rows.Count > 0)
                                            {
                                                string controlid = dt.Rows[0]["SWCControlId"].ToString();
                                                string unitid = dt.Rows[0]["SWCUnitId"].ToString();
                                                string serviceid = dt.Rows[0]["SWCServiceId"].ToString();
                                                Request_ID = dt.Rows[0]["SWCRequestId"].ToString();
                                                if (serviceid == "SC21001")
                                                {
                                                    Status_Code = "10";
                                                    Remarks = "Transaction Failed at UPSIDA | Applicant.";
                                                    Pendancy_level = "Applicant";
                                                }
                                                if (serviceid == "SC21002")
                                                {
                                                    Status_Code = "10";
                                                    Pendancy_level = "Applicant";
                                                    Remarks = "Transaction Failed at UPSIDA | Applicant";
                                                }
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

                                        if (objServiceTimelinesBEL.PayTrans_response_code == "S")
                                        {
                                            
                                            GeneralMethod gm1 = new GeneralMethod();
                                            SqlCommand cmd = new SqlCommand("GetNiveshMitraID '" + UPSIDCRefrence.Text + "'", con);
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
                                                Request_ID = dt.Rows[0]["SWCRequestId"].ToString();
                                                objServiceTimelinesBEL.ServiceRequestNO = ID;

                                                if (serviceid == "SC21001")
                                                {
                                                    result = objServiceTimelinesBLL.MoveTemppplicationDataToMainTable(objServiceTimelinesBEL);
                                                    if (result > 0)
                                                    {

                                                        Status_Code = "13";
                                                        Remarks = "EMD Payment Paid & Form Submitted | DA " + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                        Pendancy_level = "DA" + gm1.Get_IAName_ByServiceRequstNo(ID);

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
                                                if (serviceid == "SC21002")
                                                {
                                                    GeneralMethod gm = new GeneralMethod();
                                                    string Objection = gm.GetObjectionStatus(ID);
                                                    string Rejected = gm.GetRejectionStatus(ID);
                                                    DateTime ServiceDate = Convert.ToDateTime(gm.GetServiceDate(ID));
                                                    if (Objection == "True" || Rejected == "True")
                                                    {
                                                        result = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
                                                        if (result > 0)
                                                        {
                                                            if (Rejected == "True")
                                                            {
                                                                Status_Code = "13";
                                                                Remarks = "Form Re-Submitted | DA" + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                                Pendancy_level = "DA" + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                            }
                                                            else
                                                            {
                                                                Status_Code = "14";
                                                                Pendancy_level = "DA" + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                                Remarks = "Form Re-Submitted | DA" + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                            }
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
                                                  
                                                    else
                                                    {
                                                        //---------------------------SKU-CodeBlockType----------
                                                        decimal TotalCharges = 0;
                                                        SqlCommand cmmd = new SqlCommand("GetNiveshMitraProcessingFeeBP '" + ID + "'", con);
                                                        SqlDataAdapter addp = new SqlDataAdapter(cmmd);
                                                        DataTable dtt = new DataTable();
                                                        addp.Fill(dtt);
                                                        if (dtt.Rows.Count > 0)
                                                        {
                                                            TotalCharges = Convert.ToDecimal(dtt.Compute("SUM(applicablecharge)", string.Empty));

                                                            Status_Code = "12";
                                                            Fee_Amount = TotalCharges.ToString();
                                                            Fee_Status = "UB";
                                                            Remarks = "Document Submitted & Fee Paid at UPSIDA. Kindly pay nivesh mitra processing fee for final Submission | Applicant";
                                                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                                            string Update_Result = webService.WReturn_CUSID_STATUS(
                                                            controlid,
                                                            unitid,
                                                            serviceid,
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

                                                if (serviceid == "SC21003")
                                                {

                                                    result = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
                                                    if (result > 0)
                                                    {

                                                        Status_Code = "13";
                                                        Remarks = "Building Plan Rejected Application Resubmitted | DA " + gm1.Get_IAName_ByServiceRequstNo(ID);
                                                        Pendancy_level = "DA" + gm1.Get_IAName_ByServiceRequstNo(ID);
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
                                    }
                            }
                        }
                     
                    }
                    else
                    {
                        string Message = "Errro Ocured In Processing !";
                        lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + Message + " </span></div>";
                    }
                }
            }
            }
            catch (Exception ex)
            {

                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();

                Response.Write("Oops! error occured : Line :" + line +"|Col :"+col+"|Method : "+methodName+"|File : "+fileName);
            }
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

   
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            string lblServiceReqNo = gm.GetServiceRequestNoFromTraRefNo(UPSIDCRefrence.Text);
            string[] SerIdarray = lblServiceReqNo.Split('/');
            string IAService  = SerIdarray[1].ToString();

            if (IAService == "1002")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1001")
            {
                Response.Redirect("~/LeaseDeedApplication.aspx?ViewID=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1003")
            {
                Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1004")
            {
                Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1005")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1006")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1007")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1011")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1009")
            {
                Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1010")
            {
                Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }
            if (IAService == "1029")
            {
                Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);
            }           
            if (IAService == "1030")
            {
                Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim() + "&rtype=" + Session["rtype"].ToString(), false);
            }
            if (IAService == "200") 
            {
                if (lblResponseCode.Text == "P")
                {
                    string Message = "After the successFull payment against this challan.Your Application will be submitted automatically !";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                }
                if (lblResponseCode.Text == "S")
                {
                    Response.Redirect("~/AllotteeReservationMoneyPayNMSWP.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);

                }
            }
            if (IAService == "1028")
            {
                if (lblResponseCode.Text == "P")
                {
                    string Message = "After the successFull payment against this challan.Your Application will be submitted automatically !";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                }
                if (lblResponseCode.Text == "S")
                {
                    Response.Redirect("~/IACurrentDues.aspx?ServiceReqNo=" + lblServiceReqNo.Trim(), false);

                }
            }

            if (IAService == "100")
            {
                string ReqNo = gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim());
                var arr = ReqNo.Split('/');
                string service = arr[1].ToString();
                if (service == "1002" || service == "1005" || service == "1006" || service == "1011" || service == "1007")
                {
                    Response.Redirect("~/IAServicesApplication_Module.aspx?ServiceReqNo=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim()), false);
                }
                else if (service == "1012" || service == "1024" || service == "1025" || service == "1026" || service == "1007")
                {
                    Response.Redirect("~/IAServicesApplication_Module1.aspx?ViewID=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim()), false);
                }
                else if (service == "1008" || service == "1021" || service == "1022" || service == "1017")
                {
                    Response.Redirect("~/IAReconstitutionApplication.aspx?ViewID=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim()), false);
                }
                else if (service == "1001")
                { Response.Redirect("~/LeaseDeedApplication.aspx?ViewID=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim()), false); }
                else
                {
                    Response.Redirect("~/IAServicesApplication.aspx?ServiceReqNo=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo.Trim()), false);
                }
            }

            if (IAService == "1000")
            {
                if (lblResponseCode.Text == "P")
                {
                    string Message = "After the successFull payment against this challan.Please final submit your application through nivesh mitra !";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                }
                if (lblResponseCode.Text == "S")
                {
                    Response.Redirect("~/LandAllotmentApplication.aspx?ServiceReqNo=" + lblServiceReqNo.Trim() + "&Status=F&TranID=" + lblUPSIDCTran.Text.Trim(), false);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirect('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }


            }
            if (IAService == "1" || IAService == "2" || IAService == "3")
            {
                if (lblResponseCode.Text == "P")
                {
                    string Message = "After the successFull payment against this challan.Your Application will be submitted automatically !";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                }
                if (lblResponseCode.Text == "S")
                {
                    Response.Redirect("~/AllotteeApplication.aspx?ViewID=" + lblServiceReqNo.Trim(), false);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirect('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }
            }

        }
        private void SendPaymentConfirmationMail()
        {

            try
            {
                GeneralMethod gm = new GeneralMethod();
                string lblServiceReqNo = gm.GetServiceRequestNoFromTraRefNo(UPSIDCRefrence.Text);
                string[] SerIdarray = lblServiceReqNo.Split('/');
                string Service = SerIdarray[1].ToString();
                string ServiceName = "";
                switch (Service)
                {
                    case "100":
                        ServiceName = "Demand Payment";
                        break;
                    case "1":
                        ServiceName = "Building Plan";
                        break;
                    case "2":
                        ServiceName = "Building Plan";
                        break;

                    case "1000":
                        ServiceName = "Land Allotment";
                        break;
                    case "1001":
                        ServiceName = "Lease Deed";
                        break;
                    case "1003":
                        ServiceName = "Change Of Project";
                        break;
                    case "1004":
                        ServiceName = "Addition Of Product";
                        break;
                    case "1009":
                        ServiceName = "Completion Certificate";
                        break;
                    case "1010":
                        ServiceName = "Occupancy Certificate";
                        break;

                    case "1002":
                        ServiceName = "Time Extension";
                        break;

                    case "1005":
                        ServiceName = "Noc Mortgage";
                        break;
                    case "1007":
                        ServiceName = "Second Charge";
                        break;
                    case "1006":
                        ServiceName = "Joint Mortgage";
                        break;
                    case "1028":
                        ServiceName = "Outstanding Dues Payment";
                        break;


                }

                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunicationMail '" + lblServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    TextWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);

                    DivP.RenderControl(hw);
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    byte[] pdfBytes = htmlToPdf.GeneratePdf(tw.ToString());
                    hw.Close();
                    tw.Close();

                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string ApplicationDate = dt.Rows[0]["ApplicationDate"].ToString();


                    MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                   // newmsg.IsBodyHtml = true;
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), "PaymentAck.pdf"));


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/PaymentConfirmation.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{amount}", PaymentAmount.Trim());
                    StrContent = StrContent.Replace("{SerNo}", lblServiceReqNo.Trim());
                    StrContent = StrContent.Replace("{ServiceName}", ServiceName.Trim());


                    if (Service == "100")
                    {
                        if (ServiceName == "Lease Deed")
                        {
                            StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ServiceReqNo=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo));

                        }
                        else
                        {
                            StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication.aspx?ServiceReqNo=" + gm.GetServiceRequestNoFromDemandRefNo(lblServiceReqNo));
                        }
                    }
                    else
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication.aspx?ServiceReqNo=" + lblServiceReqNo);
                    }


                    newmsg.Subject = "UPSIDAeService: Intimation for payment confirmation against application for " + ServiceName;
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
                    //string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant Your Application for Lease deed as been received kindly visit your concerning regional office within seven days to submit documents required for the execution of lease deed otherwise your application will be auto cancelled.");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , "7275379286"},
                    //                    {"message" , message}
                    //    //              {"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}