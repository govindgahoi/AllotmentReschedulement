using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class OTS_OfflineTransactionUpdate : System.Web.UI.Page
    {
        SqlConnection con;
        //String ServiceRequestNo = "";
        //String TraID = "";

        string ControlID = "";
        string Request_ID = "";
        string UnitID = "";
        string ServiceID = "";
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

        string emailID = "";
        string phoneNo = "";
        public string ViewID;
        public string App = "";
        string allotteeID = "";
        string regionalOffice = "", industrialArea = "", plotNo = "";
        public string SWCControlID = "";
        public string SWCUnitID = "";
        public string SWCServiceID = "";
        public string SWCRequest_ID = "";
        public int serviceID = 2000;
        public string Paid = "";
        public decimal MC;
        public decimal INTEREST;
        public decimal INTERESTONMC;
        public decimal TotDues;
        public decimal TotInt;
        public decimal InstallmentValue;
        public decimal TotalOneTimeDues;
        public decimal rebate;
        public decimal amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            Offline_Update();
        }
        protected void Offline_Update()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_GetOffline_RealisedForUpdate", con);
                //SqlCommand cmd = new SqlCommand("select * from ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)//Balance_Amount
                    {
                        string controlid = dtRow["ControlID"].ToString();
                        string unitID = dtRow["UnitID"].ToString();
                        string serviceID = dtRow["ServiceID"].ToString();
                        string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                        string Requestid = dtRow["RequestID"].ToString().Trim();
                        string Offline_Req_ID = dtRow["Offline_Req_ID"].ToString().Trim();
                        string bal_Req = dtRow["Bal_RequestID_1"].ToString().Trim();
                        string Inst_Req_1 = dtRow["Inst_RequestID_1"].ToString().Trim();
                        string Inst_Req_2 = dtRow["Inst_RequestID_2"].ToString().Trim();
                        string Inst_Req_3 = dtRow["Inst_RequestID_3"].ToString().Trim();
                        string fee_Amount_Paid = dtRow["Fee_Amount_Paid"].ToString();//DateOfReceipt
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        int flg = Convert.ToInt32(dtRow["Flag"]);
                        decimal PaymentReceived = Convert.ToDecimal(dtRow["PaymentAmount"]);
                        decimal accAmount1 ;
                        decimal accAmount;
                        if (fee_Amount_Paid == "Pending" && Requestid == Offline_Req_ID)
                        {

                            DataSet ds = new DataSet();
                            ds = GetAllotteeRecordToBindForOTSScheme(dtRow["PlotNo"].ToString().Trim(), dtRow["IndustrialArea"].ToString().Trim(), Convert.ToDateTime(dtRow["DateOfReceipt"]));
                            if (ds.Tables.Count > 0)
                            {
                                DataTable dt1 = ds.Tables[0];
                                DataTable dt2 = ds.Tables[1];
                                //AllotteeDiv.Visible = true;
                                if (dt1.Rows.Count > 0) { 
                                //allotteeID = dt1.Rows[0]["AllotteeID"].ToString();
                                allotteeID = (String.IsNullOrEmpty(dt1.Rows[0]["AllotteeID"].ToString()) ? "" : dt1.Rows[0]["AllotteeID"].ToString());
                               
                                MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);

                                INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                                string IntDues = (Convert.ToDouble(INTEREST) < 0) ? "0.00" : INTEREST.ToString();

                                INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                                string IntOnMCDues = (Convert.ToDouble(INTERESTONMC) < 0) ? "0.00" : INTERESTONMC.ToString();
                                //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";
                                TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                                TotInt = Math.Round((decimal)TotInt, 2);

                                TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(MC);
                                TotDues = Math.Round((decimal)TotDues, 2);

                                rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                                //Rebate
                                rebate = Math.Round((decimal)rebate, 2);
                                // One Time Down Payment
                                TotalOneTimeDues = (TotDues - rebate);
                                // Instalment 
                                InstallmentValue = (TotDues - rebate) / 4;
                                InstallmentValue = Math.Round((decimal)InstallmentValue, 2);

                                DateTime date1 = Convert.ToDateTime(dtRow["ApplicationDate"]);
                                DateTime date2 = Convert.ToDateTime(dtRow["DateOfReceipt"]);
                                // getting the difference
                                TimeSpan t = date2.Subtract(date1);
                                if (schemeType == 0)
                                {
                                    if ((PaymentReceived + 1) >= TotalOneTimeDues)
                                    {
                                        decimal amount = TotalOneTimeDues - PaymentReceived;


                                        SqlCommand cmd11 = new SqlCommand("[usp_update_OfflinePayment1]", con);
                                        cmd11.CommandType = CommandType.StoredProcedure;
                                        cmd11.Parameters.AddWithValue("@UnitID", unitID.Trim());
                                        cmd11.Parameters.AddWithValue("@DownPayment", PaymentReceived);
                                        cmd11.Parameters.AddWithValue("@ReceivingDate", date2);
                                        cmd11.Parameters.AddWithValue("@ReceiptNo", Convert.ToString(dtRow["ReceiptNo"]).Trim());
                                        cmd11.Parameters.AddWithValue("@balAmount", amount);
                                        cmd11.Parameters.AddWithValue("@SchemeType", schemeType);
                                        cmd11.Parameters.AddWithValue("@dayDif", t.Days);
                                        cmd11.Parameters.AddWithValue("@Instalment", InstallmentValue);
                                        cmd11.Parameters.AddWithValue("@waiveOff", rebate);
                                        //cmd11.Parameters.AddWithValue("@waiveOff", rebate);
                                        SqlDataAdapter adp11 = new SqlDataAdapter(cmd11);
                                        DataTable dt31 = new DataTable();
                                        adp11.Fill(dt31);
                                        if (dt31.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(dt31.Rows[0]["flag"]) == 1)
                                            {
                                                UpdateLedger(unitID, Requestid, amount);
                                            }
                                        }
                                        //UpdateLedger(unitID, Requestid);
                                    }
                                    if ((PaymentReceived + 1) < TotalOneTimeDues)
                                    {
                                        decimal amount = TotalOneTimeDues - PaymentReceived;

                                        SqlCommand cmd21 = new SqlCommand("[usp_update_OfflinePayment1]", con);
                                        cmd21.CommandType = CommandType.StoredProcedure;

                                        cmd21.Parameters.AddWithValue("@DownPayment", PaymentReceived);
                                        cmd21.Parameters.AddWithValue("@ReceivingDate", date2);
                                        cmd21.Parameters.AddWithValue("@ReceiptNo", Convert.ToString(dtRow["ReceiptNo"]).Trim());
                                        cmd21.Parameters.AddWithValue("@balAmount", amount);
                                        cmd21.Parameters.AddWithValue("@SchemeType", schemeType);
                                        cmd21.Parameters.AddWithValue("@dayDif", t.Days);
                                        cmd21.Parameters.AddWithValue("@Instalment", InstallmentValue);
                                        cmd21.Parameters.AddWithValue("@waiveOff", rebate);
                                        cmd21.Parameters.AddWithValue("@UnitID", unitID.Trim());
                                        SqlDataAdapter adp21 = new SqlDataAdapter(cmd21);
                                        DataTable dt21 = new DataTable();
                                        adp21.Fill(dt21);
                                        if (dt21.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(dt21.Rows[0]["flag"]) == 2)
                                            {
                                                WriteToFile("Transaction Updated -" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + Requestid + "/" + DateTime.Now);
                                            }

                                        }
                                    }
                                }
                                else if (schemeType == 1)
                                {
                                    decimal amount = InstallmentValue - PaymentReceived;

                                    SqlCommand cmd41 = new SqlCommand("[usp_update_OfflinePayment1]", con);
                                    cmd41.CommandType = CommandType.StoredProcedure;
                                    cmd41.Parameters.AddWithValue("@UnitID", unitID.Trim());
                                    cmd41.Parameters.AddWithValue("@DownPayment", PaymentReceived);
                                    cmd41.Parameters.AddWithValue("@ReceivingDate", date2);
                                    cmd41.Parameters.AddWithValue("@ReceiptNo", Convert.ToString(dtRow["ReceiptNo"]).Trim());
                                    cmd41.Parameters.AddWithValue("@balAmount", amount);
                                    cmd41.Parameters.AddWithValue("@SchemeType", schemeType);
                                    cmd41.Parameters.AddWithValue("@dayDif", t.Days);
                                    cmd41.Parameters.AddWithValue("@Instalment", InstallmentValue);
                                    cmd41.Parameters.AddWithValue("@waiveOff", rebate);
                                    //cmd41.Parameters.AddWithValue("@UnitID", unitID.Trim());
                                    SqlDataAdapter adp31 = new SqlDataAdapter(cmd41);
                                    DataTable dt41 = new DataTable();
                                    adp31.Fill(dt41);
                                    if (dt41.Rows.Count > 0)
                                    {
                                        if (Convert.ToInt32(dt41.Rows[0]["flag"]) == 2)
                                        {
                                            WriteToFile("Transaction Updated -" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + Requestid + "/" + DateTime.Now);
                                        }

                                    }
                                }
                            }
                            }
                        }

                        else if (Requestid != Offline_Req_ID)
                        {
                            DataTable dt1 = new DataTable();
                            DateTime dateOfReceipt = Convert.ToDateTime(dtRow["DateOfReceipt"]);
                            string ReceiptNo = Convert.ToString(dtRow["ReceiptNo"]).Trim();
                            if (schemeType == 0 && bal_Req == Offline_Req_ID)
                            {
                                accAmount1 = Convert.ToDecimal(dtRow["Balance_Amount"]);
                                accAmount = PaymentReceived - accAmount1;
                                if (accAmount >= 0)
                                {
                                    dt1 = Db_Update(dateOfReceipt, unitID, Offline_Req_ID, ReceiptNo, schemeType, flg, PaymentReceived, accAmount);
                                    if (dt1.Rows.Count > 0)
                                    {
                                        decimal OfflineAccessAmount = (String.IsNullOrEmpty(dt1.Rows[0]["OfflineAccessAmount"].ToString())) ? 0 : Convert.ToDecimal(dt1.Rows[0]["OfflineAccessAmount"]);
                                        UpdateLedger1(unitID, Requestid, OfflineAccessAmount);
                                    }
                                }                               

                            }

                            if (schemeType == 1)
                            {
                                if (Inst_Req_1 == Offline_Req_ID)
                                {
                                    accAmount = Convert.ToDecimal(dtRow["Installment-1"]);
                                    accAmount = PaymentReceived - accAmount;
                                    dt1 = Db_Update(dateOfReceipt, unitID, Offline_Req_ID, ReceiptNo, schemeType, flg, PaymentReceived, accAmount);
                                }
                                else if (Inst_Req_2 == Offline_Req_ID)
                                {
                                    accAmount = Convert.ToDecimal(dtRow["Installment-2"]);
                                    accAmount = PaymentReceived - accAmount;
                                    dt1 = Db_Update(dateOfReceipt, unitID, Offline_Req_ID, ReceiptNo, schemeType, flg, PaymentReceived, accAmount);
                                }
                                else if (Inst_Req_3 == Offline_Req_ID)
                                {
                                    accAmount = Convert.ToDecimal(dtRow["Installment-3"]);
                                    accAmount = PaymentReceived - accAmount;
                                    dt1 = Db_Update(dateOfReceipt, unitID, Offline_Req_ID, ReceiptNo, schemeType, flg, PaymentReceived, accAmount);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected DataTable Db_Update(DateTime receivingdate, string unitID,string reqID, string receiptNo,int schematype,int flag,decimal amount,decimal accessAmount)
        {
            //decimal amount = InstallmentValue - PaymentReceived;

            SqlCommand cmd = new SqlCommand("[usp_update_OfflinePayment2]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UnitID", unitID.Trim());
            cmd.Parameters.AddWithValue("@ReceivingDate", receivingdate);
            cmd.Parameters.AddWithValue("@ReceiptNo", receiptNo);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@SchemeType", schematype);
            cmd.Parameters.AddWithValue("@ReqID", reqID);
            cmd.Parameters.AddWithValue("@Flag", flag);
            cmd.Parameters.AddWithValue("@accAmount", accessAmount);
            //cmd41.Parameters.AddWithValue("@UnitID", unitID.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            
        }
        protected DataSet GetAllotteeRecordToBindForOTSScheme(string plotNo, string IndustrialArea, DateTime ReceivingDate)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Plot_OTSDetail_For_Offline", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlotNo", plotNo);
                cmd.Parameters.AddWithValue("@IndustrialArea", IndustrialArea);
                cmd.Parameters.AddWithValue("@ReceivingDate", ReceivingDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
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
            return ds;
        }
        protected void UpdateLedger(string unitID, string reqID, decimal balAmount)
        {
            //usp_Update_OTS_Ledger 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where isCompleted=1 and isActive=0 and Ledger_Flag='Not Updated'", con);
            SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Ledger_Flag='Not Updated' and UnitID='" + unitID + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    string controlid = dtRow["ControlID"].ToString();
                    string Requestid = dtRow["RequestID"].ToString();
                    //string unitID = dtRow["UnitID"].ToString();
                    string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                    decimal Interest; //Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    decimal MaintenanceCharge = Convert.ToDecimal(dtRow["MaintenanceCharge"]);
                    decimal Fee_Amount = Convert.ToDecimal(dtRow["Fee_Amount"]);
                    decimal Waive_Off = Convert.ToDecimal(dtRow["Waive_Off"]);
                    decimal IntuptoJune = Convert.ToDecimal(dtRow["InterestOnMaintenanceChargeUpTo30-06-21"]);
                    decimal Intupto = Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    DateTime DownPaymentDat = Convert.ToDateTime(dtRow["DownPaymentDueDate"]);
                    int AllotteeID = Convert.ToInt32(dtRow["AllotteeID"]);
                    DateTime Transaction_Date = Convert.ToDateTime(dtRow["Transaction_Date"]);
                    string Ledger_Flag = dtRow["Ledger_Flag"].ToString();
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    int flg = Convert.ToInt32(dtRow["Flag"]);
                    //decimal OfflineAccessAmount = Convert.ToDecimal(dtRow["OfflineAccessAmount"]);//OfflineAccessAmount
                    decimal OfflineAccessAmount = (String.IsNullOrEmpty(dtRow["OfflineAccessAmount"].ToString())) ? 0 : Convert.ToDecimal(dtRow["OfflineAccessAmount"]);
                    decimal Bal_amount = 0;
                    if (string.IsNullOrEmpty(dtRow["Balance_Amount"].ToString()) == false)
                    {
                        Bal_amount = Convert.ToDecimal(dtRow["Balance_Amount"]);
                    }
                    
                    Interest = (Fee_Amount - MaintenanceCharge + Bal_amount) * 2;
                    Waive_Off = (Fee_Amount - MaintenanceCharge) + Bal_amount;
                    decimal AccessInterest = Waive_Off * 2 - IntuptoJune;
                    if (reqID.Trim() == dtRow["Bal_RequestID_1"].ToString().Trim())
                    {

                    }
                    if (string.IsNullOrEmpty(dtRow["Bal_Trans_Date"].ToString()) == false)
                    {
                        Transaction_Date = Convert.ToDateTime(dtRow["Bal_Trans_Date"]);
                    }
                    SqlCommand cmd_Bal = new SqlCommand("usp_Update_OTS_Ledger", con);
                    cmd_Bal.CommandType = CommandType.StoredProcedure;
                    cmd_Bal.Parameters.AddWithValue("@AllotteeID", AllotteeID);
                    cmd_Bal.Parameters.AddWithValue("@UnitID", unitID);
                    cmd_Bal.Parameters.AddWithValue("@RequestID", Requestid);
                    cmd_Bal.Parameters.AddWithValue("@TransDate", Transaction_Date);
                    cmd_Bal.Parameters.AddWithValue("@Bal_Amount", Bal_amount);
                    cmd_Bal.Parameters.AddWithValue("@Maintenance", MaintenanceCharge);
                    cmd_Bal.Parameters.AddWithValue("@Interest", Interest);
                    cmd_Bal.Parameters.AddWithValue("@Waiver", Waive_Off);
                    cmd_Bal.Parameters.AddWithValue("@ledgerFlag", Ledger_Flag);
                    cmd_Bal.Parameters.AddWithValue("@SchemeType", schemeType);
                    cmd_Bal.Parameters.AddWithValue("@AccessInt", AccessInterest);
                    cmd_Bal.Parameters.AddWithValue("@DownpaymentDate", DownPaymentDat);
                    cmd_Bal.Parameters.AddWithValue("@OfflineAccessAmount", OfflineAccessAmount);//OfflineAccessAmount
                    SqlDataAdapter adp_Bal = new SqlDataAdapter(cmd_Bal);
                    DataTable dt_Bal = new DataTable();

                    adp_Bal.Fill(dt_Bal);
                    if (dt_Bal.Rows.Count > 0)
                    {
                        WriteToFile("Ledger Updated -" + AllotteeID + "/" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + Requestid + "/" + DateTime.Now);

                    }

                }
            }
        }
        protected void UpdateLedger1(string unitID, string reqID, decimal accAmount)
        {
            //usp_Update_OTS_Ledger 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where isCompleted=1 and isActive=0 and Ledger_Flag='Not Updated'", con);
            SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Ledger_Flag='Not Updated' and UnitID='" + unitID + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    string controlid = dtRow["ControlID"].ToString();
                    string Requestid = dtRow["RequestID"].ToString();
                    //string unitID = dtRow["UnitID"].ToString();
                    string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                    decimal Interest; //Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    decimal MaintenanceCharge = Convert.ToDecimal(dtRow["MaintenanceCharge"]);
                    decimal Fee_Amount = Convert.ToDecimal(dtRow["Fee_Amount"]);
                    decimal Waive_Off = Convert.ToDecimal(dtRow["Waive_Off"]);
                    decimal IntuptoJune = Convert.ToDecimal(dtRow["InterestOnMaintenanceChargeUpTo30-06-21"]);
                    decimal Intupto = Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    DateTime DownPaymentDat = Convert.ToDateTime(dtRow["DownPaymentDueDate"]);
                    int AllotteeID = Convert.ToInt32(dtRow["AllotteeID"]);
                    DateTime Transaction_Date = Convert.ToDateTime(dtRow["Transaction_Date"]);
                    string Ledger_Flag = dtRow["Ledger_Flag"].ToString();
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    int flg = Convert.ToInt32(dtRow["Flag"]);
                    decimal Bal_amount = 0;
                    if (string.IsNullOrEmpty(dtRow["Balance_Amount"].ToString()) == false)
                    {
                        Bal_amount = Convert.ToDecimal(dtRow["Balance_Amount"]);
                    }
                    
                    Interest = (Fee_Amount - MaintenanceCharge + Bal_amount) * 2;
                    Waive_Off = (Fee_Amount - MaintenanceCharge) + Bal_amount;
                    decimal AccessInterest = Waive_Off*2 - IntuptoJune;
                    if (reqID.Trim() == dtRow["Bal_RequestID_1"].ToString().Trim())
                    {

                    }
                    if (string.IsNullOrEmpty(dtRow["Bal_Trans_Date"].ToString()) == false)
                    {
                        Transaction_Date = Convert.ToDateTime(dtRow["Bal_Trans_Date"]);
                    }
                    SqlCommand cmd_Bal = new SqlCommand("usp_Update_OTS_Ledger1", con);
                    cmd_Bal.CommandType = CommandType.StoredProcedure;
                    cmd_Bal.Parameters.AddWithValue("@AllotteeID", AllotteeID);
                    cmd_Bal.Parameters.AddWithValue("@UnitID", unitID);
                    cmd_Bal.Parameters.AddWithValue("@RequestID", Requestid);
                    cmd_Bal.Parameters.AddWithValue("@TransDate", Transaction_Date);
                    cmd_Bal.Parameters.AddWithValue("@Bal_Amount", Bal_amount);
                    cmd_Bal.Parameters.AddWithValue("@Maintenance", MaintenanceCharge);
                    cmd_Bal.Parameters.AddWithValue("@Interest", Interest);
                    cmd_Bal.Parameters.AddWithValue("@Waiver", Waive_Off);
                    cmd_Bal.Parameters.AddWithValue("@ledgerFlag", Ledger_Flag);
                    cmd_Bal.Parameters.AddWithValue("@SchemeType", schemeType);
                    cmd_Bal.Parameters.AddWithValue("@AccessInt", AccessInterest);
                    cmd_Bal.Parameters.AddWithValue("@DownpaymentDate", DownPaymentDat);
                    cmd_Bal.Parameters.AddWithValue("@accAmount", accAmount);
                    SqlDataAdapter adp_Bal = new SqlDataAdapter(cmd_Bal);
                    DataTable dt_Bal = new DataTable();

                    adp_Bal.Fill(dt_Bal);
                    if (dt_Bal.Rows.Count > 0)
                    {
                        WriteToFile("Ledger Updated -" + AllotteeID + "/" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + Requestid + "/" + DateTime.Now);

                    }

                }
            }
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Offline_OTSServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}