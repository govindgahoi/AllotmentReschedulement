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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
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
        protected void Page_Load(object sender, EventArgs e)
        {
           // OTS_Instalment_NOC();
            //UpdateLedger();
            //FeeStatusNM_Click("UPSWP210002975", "UPSWP21000297504", "SC21033", "10900", "UB", "1st Instalment Pending", "Applicant", "21000297504210330001");
            // Is_Certificate_Valid_Life_Time = "NO";
            // Remarks = "Ist Instalment Paid Successfully";
            // Certificate_EXP_Date_DDMMYYYY = "05-01-2022";
            //string noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=SER20211221/2000/27234/21234";
            //string noc_status = StatusUpdateOnWithNOC("UPSWP210002975", "UPSWP21000297503", "SC21033", "21000297503210330001", "15000", noc_url, Remarks);
        }
        protected void btnRaise_Click(object sender, EventArgs e)
        {

            //byte[] PdfInBytes = HtmlToByte();
            //if (PdfInBytes != null)
            //{
            //    String base64EncodedPdf = System.Convert.ToBase64String(PdfInBytes);

            //    string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""550px"">
										  //If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  //or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										  //</object>";


            //    Literal ltEmbed = new Literal();
            //    ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
            //    Placeholder.Controls.Add(ltEmbed);
               
            //}
            //else
            //{
            //    //Label1.Visible = true;
            //    //Label1.Text = "Invalid Details.";
            //    //lblDemandNote.Visible = false;
            //    //lblMsg.Visible = true;
            //    //lblMsg.Text = "Invalid Details.";
            //}
        }
        //protected byte[] HtmlToByte()
        //{
        //    //string htmlContent = "";
        //    //byte[] pdfBytes = null;

        //    //DataSet ds = new DataSet();
        //    //try
        //    //{
        //    //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        //    //    SqlCommand cmd = new SqlCommand("pdfDoc", con);
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    cmd.Parameters.AddWithValue("@serviceReqID", TextBox1.Text); //usp_demo_demand usp_demandNote
        //    //    cmd.Parameters.AddWithValue("@documentID", TextBox2.Text);
        //    //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    //    DataTable dt = new DataTable();
        //    //    adp.Fill(dt);
        //    //    //cmd.Dispose();
        //    //    //DataTable dt = ds.Tables[0];


        //    //    if (dt.Rows.Count > 0)
        //    //    {
        //    //        //GridViewledger.Visible = false;
        //    //        //lblLedger.Visible = false;
        //    //        Placeholder.Visible = true;
        //    //        //lblDemandNote.Visible = true;
        //    //        pdfBytes = (Byte[])dt.Rows[0]["Documents"];
        //    //        PreviousServiceDiv.Visible = true;
        //    //        //lbldebit.Visible = false;
        //    //        //lblcredit.Visible = false;
        //    //        //totransection.Visible = false;
        //    //        //GridViewledger

        //    //    }
        //    //    else
        //    //    {
        //    //        //lblDemandNote.Visible = false;
        //    //        //GridViewledger.Visible = false;
        //    //        //lblLedger.Visible = false;
        //    //        //var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
        //    //        //pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
        //    //        PreviousServiceDiv.Visible = true;
                   

        //    //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    //}

        //    //return pdfBytes;
        //}

        protected void TransactionStatus()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_GetTodayIssueNOC", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        string controlid = dtRow["ControlID"].ToString();
                        string unitID = dtRow["UnitID"].ToString();
                        string serviceID = dtRow["ServiceID"].ToString();
                        string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                        string DownPaymentStatus = dtRow["Fee_Amount_Paid"].ToString();
                        string Requestid = dtRow["RequestID"].ToString();
                        string Instalment = dtRow["Installment-1"].ToString();
                        string Bal_Status = "";
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        int flg = Convert.ToInt32(dtRow["Flag"]);
                        if (string.IsNullOrEmpty(dtRow["Bal_Trans_Amount_Status"].ToString()) == false)
                        {
                            Bal_Status = dtRow["Bal_Trans_Amount_Status"].ToString();
                        }
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        if ((webService.WGetUBPaymentDetails(controlid, unitID, serviceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid)) != null)
                        {
                            DataSet dss = webService.WGetUBPaymentDetails(controlid, unitID, serviceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid);
                            DataTable dtt = new DataTable();
                            dtt = dss.Tables[0];
                            if (dtt.Rows.Count > 0)
                            {
                                string status = dtt.Rows[0]["status_code"].ToString();
                                if (status == "11")
                                {
                                    string Transaction_ID = dtt.Rows[0]["Transaction_ID"].ToString();
                                    char[] charsToTrim2 = { '{', '}' };
                                    string TrnDate = (dtt.Rows[0]["Transaction_DateTime"].ToString()).Trim(charsToTrim2);
                                    decimal Fee_Amount = Convert.ToDecimal(dtt.Rows[0]["Fee_Amount"]);
                                    string noc_url = "";

                                    if (DownPaymentStatus == "Pending" && Bal_Status != "Pending")
                                    {
                                        DataSet dt20 = UpdateNMSWPFeeStatus(controlid, unitID, serviceID, Requestid, Transaction_ID, Fee_Amount, TrnDate, flg);
                                        if (dt20.Tables.Count > 0)
                                        {
                                            #region Schemetype=OTS
                                            if (schemeType == 0)
                                            {
                                                if (dt20.Tables.Count > 1)
                                                {
                                                    DataTable dt5 = new DataTable();
                                                    DataTable dt6 = new DataTable();
                                                    dt5 = dt20.Tables[0];
                                                    dt6 = dt20.Tables[1];
                                                    decimal amt1 = Convert.ToDecimal(dt5.Rows[0]["TotalInterest"]);
                                                    decimal amt2 = Convert.ToDecimal(dt6.Rows[0]["TotalInterest"]);
                                                    decimal amount2 = (amt2 - amt1);
                                                    if (amount2 > 1)
                                                    {
                                                        DataTable dt7 = OTSAdjestmentAmount(amount2, controlid, unitID, serviceID, Requestid);
                                                        if (dt7.Rows.Count > 0)
                                                        {
                                                            Is_Certificate_Valid_Life_Time = "NO";
                                                            Remarks = "NOC Certificate Issued";
                                                            Certificate_EXP_Date_DDMMYYYY = "20/02/2022";
                                                            noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                            string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                            if (noc_status == "SUCCESS")
                                                            {
                                                                WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                                string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, dt7.Rows[0]["Balance_Amount"].ToString(), "UB", "OTS Balance Interest Pending", "Applicant", Request_ID);
                                                                if (NMSWP_Result == "SUCCESS")
                                                                {
                                                                    WriteToFile("Balance Payment Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                                else
                                                                {
                                                                    WriteToFile("Balance Payment Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                            }
                                                            //MailToAllotteeAfterPaid(controlid, unitID, serviceID, Requestid);
                                                            //StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Is_Certificate_Valid_Life_Time = "Yes";
                                                    Remarks = "NOC Certificate Issued";
                                                    noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                    string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                    if (noc_status == "SUCCESS")
                                                    {
                                                        WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                    }
                                                }
                                            }
                                            #endregion
                                            #region SchemeType=Instalment
                                            if (schemeType == 1)
                                            {
                                                if (dt20.Tables.Count > 1)
                                                {
                                                    DataTable dt5 = new DataTable();
                                                    DataTable dt6 = new DataTable();
                                                    dt5 = dt20.Tables[0];
                                                    dt6 = dt20.Tables[1];
                                                    decimal amt1 = Convert.ToDecimal(dt5.Rows[0]["TotalInterest"]);
                                                    decimal amt2 = Convert.ToDecimal(dt6.Rows[0]["TotalInterest"]);
                                                    decimal amount2 = (amt2 - amt1);
                                                    if (amount2 > 1)
                                                    {
                                                        DataTable dt7 = OTSAdjestmentAmount(amount2, controlid, unitID, serviceID, Requestid);
                                                        if (dt7.Rows.Count > 0)
                                                        {
                                                            Is_Certificate_Valid_Life_Time = "NO";
                                                            Remarks = "25% Upfront Paid Successfully";
                                                            Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dt7.Rows[0]["DueDate-1"]).ToString("dd/MM/yyyy");
                                                            noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                            string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                            if (noc_status == "SUCCESS")
                                                            {
                                                                WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                                string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, dt7.Rows[0]["Installment-1"].ToString(), "UB", "1st Instalment Pending", "Applicant", Request_ID);
                                                                if (NMSWP_Result == "SUCCESS")
                                                                {
                                                                    WriteToFile("1st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                                else
                                                                {
                                                                    WriteToFile("1st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    Is_Certificate_Valid_Life_Time = "NO";
                                                    Remarks = "25% Upfront Paid Successfully";
                                                    Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-1"]).ToString("dd/MM/yyyy");
                                                    noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                    string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                    if (noc_status == "SUCCESS")
                                                    {
                                                        WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                        string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, dtRow["Installment-1"].ToString(), "UB", "1st Instalment Pending", "Applicant", Request_ID);
                                                        if (NMSWP_Result == "SUCCESS")
                                                        {
                                                            WriteToFile("1st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                        }
                                                        else
                                                        {
                                                            WriteToFile("1st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                    else if (DownPaymentStatus == "Paid" && Bal_Status == "Pending")
                                    {
                                        if (schemeType == 0)
                                        {
                                            #region schemeType=OTS

                                            DataTable dt_Bal = UpdateOTSBalAmount(controlid, unitID, serviceID, Requestid, Transaction_ID, Fee_Amount, TrnDate);
                                            if (dt_Bal.Rows.Count > 0)
                                            {

                                                if (dt_Bal.Rows[0]["Bal_Trans_Amount_Status"].ToString() == "Paid" && dt_Bal.Rows[0]["Status_For_OTS"].ToString() != "Rejected Due To Late Payment")
                                                {
                                                    // Send NOC and Update Ledger and Send Mail to Allottee
                                                    Is_Certificate_Valid_Life_Time = "Yes";
                                                    Remarks = "NOC Certificate Issued";
                                                    noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                    string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                    if (noc_status == "SUCCESS")
                                                    {
                                                        WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                    }
                                                }
                                                if(dt_Bal.Rows[0]["Status_For_OTS"].ToString() == "Rejected Due To Late Payment")
                                                {
                                                    //Update Status as rejection in NiveshMitra
                                                }

                                            }
                                            #endregion
                                        }
                                        else if (schemeType == 1)
                                        {
                                            #region SchemeType= Instalment
                                            if (dtRow["Status_For_Instalment"].ToString() != "Ineligible")
                                            {
                                                DataTable dt_inst = UpdateInstalmentAmount(controlid, unitID, serviceID, Requestid, Transaction_ID, Fee_Amount, TrnDate, flg);
                                                if (dt_inst.Rows.Count > 0)
                                                {
                                                    string noc_status = "";
                                                    string NMSWP_Result = "";
                                                    switch (dt_inst.Rows[0]["Flag"].ToString())
                                                    {
                                                        case "2":
                                                            Is_Certificate_Valid_Life_Time = "NO";
                                                            Remarks = "Ist Instalment Paid Successfully";
                                                            Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-2"]).ToString("dd/MM/yyyy");
                                                            noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                            noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                            if (noc_status == "SUCCESS")
                                                            {
                                                                NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, dt_inst.Rows[0]["Installment-2"].ToString(), "UB", "2nd Instalment Pending", "Applicant", Request_ID);
                                                                if (NMSWP_Result == "SUCCESS")
                                                                {
                                                                    WriteToFile("2nd Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                                else
                                                                {
                                                                    WriteToFile("1st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                            } 
                                                            break;
                                                        case "3":
                                                            Is_Certificate_Valid_Life_Time = "NO";
                                                            Remarks = "2nd Instalment Paid Successfully";
                                                            Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-3"]).ToString("dd/MM/yyyy");
                                                            noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                            noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                            if (noc_status == "SUCCESS")
                                                            {
                                                                NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, dt_inst.Rows[0]["Installment-3"].ToString(), "UB", "3rd Instalment Pending", "Applicant", Request_ID);
                                                                if (NMSWP_Result == "SUCCESS")
                                                                {
                                                                    WriteToFile("3rd Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                                else
                                                                {
                                                                    WriteToFile("2st Instalment Pending Status on Nivesh Mitra" + NMSWP_Result + "/" + serviceReqNo + "/");
                                                                }
                                                            }
                                                            break;
                                                        case "4":
                                                            Is_Certificate_Valid_Life_Time = "Yes";
                                                            Remarks = "NOC Certificate Issued";
                                                            noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                            noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                            if (noc_status == "SUCCESS")
                                                            {
                                                                WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                            }
                                                            else
                                                            {

                                                            }
                                                            break;
                                                    }
                                                    }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                            }
                            ///////Else
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\NiveshMitraOTSServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
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

        protected DataSet UpdateNMSWPFeeStatus(string controlid, string unitid, string serviceid,string requestid, string transID, decimal amount, string transdate,int flag)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd20 = new SqlCommand("usp_updateNMSWPFeeStatus", con);
            cmd20.CommandType = CommandType.StoredProcedure;
            cmd20.Parameters.AddWithValue("@ControlID", controlid);
            cmd20.Parameters.AddWithValue("@UnitID", unitid);
            cmd20.Parameters.AddWithValue("@ServiceID ", serviceid);
            cmd20.Parameters.AddWithValue("@RequestID", requestid);
            cmd20.Parameters.AddWithValue("@TransactionID", transID);
            cmd20.Parameters.AddWithValue("@Fee_Amount", amount);
            cmd20.Parameters.AddWithValue("@Transaction_Date", transdate);
            cmd20.Parameters.AddWithValue("@Flag", flag);

            SqlDataAdapter adp20 = new SqlDataAdapter(cmd20);

            DataSet dt20 = new DataSet();
            adp20.Fill(dt20);
            return dt20;
        }
        protected DataTable OTSAdjestmentAmount(decimal amount, string controlid, string unitid, string serviceid, string requestid)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd5 = new SqlCommand("usp_OTSAdjustmentAmount", con);
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd5.Parameters.AddWithValue("@pendingAmount", amount);
            cmd5.Parameters.AddWithValue("@ControlID", controlid);
            cmd5.Parameters.AddWithValue("@UnitID", unitid);
            cmd5.Parameters.AddWithValue("@ServiceID", serviceid);
            cmd5.Parameters.AddWithValue("@RequestID", requestid);

            SqlDataAdapter adp5 = new SqlDataAdapter(cmd5);
            DataTable dt7 = new DataTable();
            adp5.Fill(dt7);
            return dt7;
        }
        protected string StatusUpdateOnWithNOC(string controlid, string unitid, string serviceid, string requestid, string amount, string noc_url, string remarks)
        {
            ControlID = controlid;
            UnitID = unitid;
            ServiceID = serviceid;
            Status_Code = "15";
            Request_ID = requestid;
            Fee_Amount = amount;
            Remarks = remarks;
            NOC_URL = noc_url;
            NOC_Certificate_Number = "NOC-" + requestid + "";

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
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

            return Update_Result;
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
        protected DataTable UpdateOTSBalAmount(string controlid, string unitid, string serviceid, string requestid, string transID, decimal amount, string transdate)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd_Bal = new SqlCommand("usp_UpdateOTSBal_Amount", con);
            cmd_Bal.CommandType = CommandType.StoredProcedure;
            cmd_Bal.Parameters.AddWithValue("@ControlID", controlid);
            cmd_Bal.Parameters.AddWithValue("@UnitID", unitid);
            cmd_Bal.Parameters.AddWithValue("@ServiceID ", serviceid);
            cmd_Bal.Parameters.AddWithValue("@RequestID", requestid);
            cmd_Bal.Parameters.AddWithValue("@TransactionID", transID);
            cmd_Bal.Parameters.AddWithValue("@Fee_Amount", amount);
            cmd_Bal.Parameters.AddWithValue("@Transaction_Date", transdate);
            SqlDataAdapter adp_Bal = new SqlDataAdapter(cmd_Bal);
            DataTable dt_Bal = new DataTable();
            adp_Bal.Fill(dt_Bal);
            return dt_Bal;
        }
        protected DataTable UpdateInstalmentAmount(string controlid, string unitid, string serviceid, string requestid, string transID, decimal amount, string transdate, int flag)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd_Inst = new SqlCommand("usp_UpdateInstalment_Amount", con);
            cmd_Inst.CommandType = CommandType.StoredProcedure;
            cmd_Inst.Parameters.AddWithValue("@ControlID", controlid);
            cmd_Inst.Parameters.AddWithValue("@UnitID", unitid);
            cmd_Inst.Parameters.AddWithValue("@ServiceID ", serviceid);
            cmd_Inst.Parameters.AddWithValue("@RequestID", requestid);
            cmd_Inst.Parameters.AddWithValue("@TransactionID", transID);
            cmd_Inst.Parameters.AddWithValue("@Fee_Amount", amount);
            cmd_Inst.Parameters.AddWithValue("@Transaction_Date", transdate);
            cmd_Inst.Parameters.AddWithValue("@Flag", flag);
            SqlDataAdapter adp_inst = new SqlDataAdapter(cmd_Inst);
            DataTable dt_inst = new DataTable();
            adp_inst.Fill(dt_inst);
            return dt_inst;
        }
        protected void UpdateLedger()
        {
            //usp_Update_OTS_Ledger 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where isCompleted=1 and isActive=0 and Ledger_Flag='Not Updated'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    string controlid = dtRow["ControlID"].ToString();
                    string unitID = dtRow["UnitID"].ToString();
                    string Requestid = dtRow["RequestID"].ToString();
                    string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                    decimal Interest = Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    decimal MaintenanceCharge = Convert.ToDecimal(dtRow["MaintenanceCharge"]);
                    decimal Waive_Off = Convert.ToDecimal(dtRow["Waive_Off"]);
                    int AllotteeID = Convert.ToInt32(dtRow["AllotteeID"]);
                    DateTime Transaction_Date = Convert.ToDateTime(dtRow["Transaction_Date"]);
                    string Ledger_Flag = dtRow["Ledger_Flag"].ToString();
                    decimal Bal_amount =0;
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    int flg = Convert.ToInt32(dtRow["Flag"]);
                    if (string.IsNullOrEmpty(dtRow["Balance_Amount"].ToString()) == false)
                    {
                        Bal_amount = Convert.ToDecimal(dtRow["Balance_Amount"]);
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
                    //var output = cmd.Parameters.Add("@new_identity", SqlDbType.Int);
                    //output.Direction = ParameterDirection.Output;
                    SqlDataAdapter adp_Bal = new SqlDataAdapter(cmd_Bal);
                    DataTable dt_Bal = new DataTable();
                    
                    adp_Bal.Fill(dt_Bal);
                    //int identity = Convert.ToInt32(output.Value);
                    if (dt_Bal.Rows.Count > 0)
                    {
                        WriteToFile("Ledger Updated -" + AllotteeID + "/" + serviceReqNo + "/" + controlid + "/" + unitID + "/"  + Requestid + "/" + DateTime.Now);

                    }
                }
            }
        }
        protected void OTS_Instalment_NOC()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Schemetype=1 and Flag=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        string controlid = dtRow["ControlID"].ToString();
                        string unitID = dtRow["UnitID"].ToString();
                        string serviceID = dtRow["ServiceID"].ToString();
                        string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                        string Fee_Amount = dtRow["Fee_Amount"].ToString();
                        string Requestid = dtRow["RequestID"].ToString();

                        Is_Certificate_Valid_Life_Time = "NO";
                        Remarks = "25% Upfront paid successfully";
                        Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-1"]).ToString("dd/MM/yyyy");
                       string noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                       string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                        if (noc_status == "SUCCESS")
                        {

                        }
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}