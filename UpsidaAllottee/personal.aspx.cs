using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;

namespace UpsidaAllottee
{

    public partial class personal : System.Web.UI.Page
    {
        String ServiceRequestNo = "";
        String TraID = "";
        SqlConnection con;
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
            //string Result = UpdateStatusAtNMSWP("UPSWP200001687", "UPSWP20000168798", "SC21034", "05", "Application Forwarded to Concern Regional Office | DA Chinhat " , "20000168798210340001", "DA Chinhat","");
            //StatusUpdateOnWith();
            //MailToAllotteeAfterPaid("UPSWP21000297517", "SC21033", "2022011401", "2022-01-14 20:20:00.000", "24617.00",1);
            //MailToAllotteeAfterPaid("UPSWP21251481601", "SC21033", "56686970", "2022-02-01 18:10:54.000", "9", 0);
            //NOC_OTS_Update();
            //UpdateLedger();
            //Offline_ReqID("UPSWP20000168798", 1);
            //InstalmentNOC();
            //ToBeUpdateledger();
            abc();
            //OTS_BalPending_NOC();
            //OTS_Instalment_NOC();
            //ControlID = "UPSWP212514816";
            //UnitID = "UPSWP21251481601";
            //ServiceID = "SC21033";
            //string serviceReqNo = "SER20220328/2000/12896/46987";

            //for One Time, NOC send to Niveshmitra against NMRequestID
            //Is_Certificate_Valid_Life_Time = "Yes";
            //Remarks = "NOC Certificate Issued";
            //string noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
            //string noc_status = StatusUpdateOnWithNOC("UPSWP200211093", "UPSWP20021109302", "SC21033", "20021109302210330001", "1040.00", noc_url, Remarks);
            //if (noc_status == "SUCCESS")
            //{
            //    WriteToFile("NOC Status Updated" + serviceReqNo + "/" + ControlID + "/" + UnitID + "/" + ServiceID + "/" + Request_ID + "/" + DateTime.Now);
            //    MailToAllotteeAfterPaid("UPSWP20050530702", "SC21033", "57056075", "2022-02-08 15:47:05.000", "833", 0);
            //}

            //for Instalment, NOC send to Niveshmitra against NMRequestID
            //Is_Certificate_Valid_Life_Time = "NO";
            //Remarks = "25% Upfront Paid Successfully";
            //Certificate_EXP_Date_DDMMYYYY = "18-03-2022";
            //string noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
            //string noc_status = StatusUpdateOnWithNOC("UPSWP180196083", "UPSWP18019608306", "SC21033", "18019608306210330001", "256139.00", noc_url, Remarks);
            //if (noc_status == "SUCCESS")
            //{
            //    WriteToFile("NOC Status for Instalment Updated" + serviceReqNo + "/" + "UPSWP180196083" + "/" + "UPSWP18019608306" + "/" + "SC21033" + "/" + "18019608306210330001" + "/" + DateTime.Now);
            //    //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
            //}
            //MailToAllotteeAfterPaid("UPSWP20138604201", "SC21033", "56182496", "2022-01-21 14:58:51.000", "145430", 1);
            //   con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
            //if (NMSWP_Result == "SUCCESS")
            //{
            //var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
            //var script = string.Format("alert({0});window.location ='http://72.167.225.87/testing_nmswp/nmmasters/Entrepreneur_Dashboard.aspx';", message);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
            //MailToAllotteeAfterApplied(ds.Tables[0]);
            //}
            //else
            //{
            //    string message1 = "Error Occured while updating status at NMSWP";
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
            //}
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

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DFView", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "DFView");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ExportpaymentJournal(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("PaymentJournalReport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "PaymentJournal");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=PaymentJournal.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void altMastr(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_altMastr", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "altMastr");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=altMastrExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void MaintenanceDefaulter(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Maintenance_Defaulter", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "MaintenanceDefaulter");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=TotalDuesExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void altMastr1(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_altMastr", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Response.ClearContent();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "altMastrExport.xls"));
                            Response.ContentType = "application/ms-excel";
                            string str = string.Empty;
                            foreach (DataColumn dtcol in dt.Columns)
                            {
                                Response.Write(str + dtcol.ColumnName);
                                str = "\t";
                            }
                            Response.Write("\n");
                            foreach (DataRow dr in dt.Rows)
                            {
                                str = "";
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    Response.Write(str + Convert.ToString(dr[j]));
                                    str = "\t";
                                }
                                Response.Write("\n");
                            }
                            Response.End();
                            //using (XLWorkbook wb = new XLWorkbook())
                            //{
                            //    wb.Worksheets.Add(dt, "altMastr");

                            //    Response.Clear();
                            //    Response.Buffer = true;
                            //    Response.Charset = "";
                            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            //    Response.AddHeader("content-disposition", "attachment;filename=altMastrExport.xlsx");
                            //    using (MemoryStream MyMemoryStream = new MemoryStream())
                            //    {
                            //        wb.SaveAs(MyMemoryStream);
                            //        MyMemoryStream.WriteTo(Response.OutputStream);
                            //        Response.Flush();
                            //        Response.End();
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        protected void PremiumDefaulter(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Prem_Defaulter_2015", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "PremDefaulter");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=PremiumDefaulterExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void AllotmentAfter2019(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from allotteeMaster where leaseDeedDate >= Convert(datetime,'2019-01-01') order by leaseDeedDate desc", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        //sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Response.ClearContent();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "leaseDeedAfter2019.xls"));
                            Response.ContentType = "application/ms-excel";
                            string str = string.Empty;
                            foreach (DataColumn dtcol in dt.Columns)
                            {
                                Response.Write(str + dtcol.ColumnName);
                                str = "\t";
                            }
                            Response.Write("\n");
                            foreach (DataRow dr in dt.Rows)
                            {
                                str = "";
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    Response.Write(str + Convert.ToString(dr[j]));
                                    str = "\t";
                                }
                                Response.Write("\n");
                            }
                            Response.End();
                            //using (XLWorkbook wb = new XLWorkbook())
                            //{
                            //    wb.Worksheets.Add(DynamicSource);
                            //    wb.SaveAs(@"C:\Work\Grid1.xlsx");
                            //    wb.Worksheets.Add(dt, "leaseDeedAfter2019");

                            //    Response.Clear();
                            //    Response.Buffer = true;
                            //    Response.Charset = "";
                            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            //    Response.AddHeader("content-disposition", "attachment;filename=AllotmentDetailExport.xlsx");
                            //    using (MemoryStream MyMemoryStream = new MemoryStream())
                            //    {
                            //        wb.SaveAs(MyMemoryStream);
                            //        MyMemoryStream.WriteTo(Response.OutputStream);
                            //        Response.Flush();
                            //        Response.End();
                            //    }
                            //}
                        }
                    }
                }
            }
        }
        protected void ExportDataFromSQLServer(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))

            {
                con.Open();

                // Define the query to be performed to export desired data
                SqlCommand command = new SqlCommand("select IA.RegionalOffice,AM.IndustrialArea, ONT.* from OTS_NMSWPTransactionDetail ONT join AllotteeMaster AM on AM.AllotteeID=try_cast(ONT.AllotteeID as int) join IndustrialArea IA on AM.IndustrialArea=try_cast(IA.IAName as varchar(MAX)) order by ApplicationDate desc ", con);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);

                var excelApplication = new Excel.Application();

                var excelWorkBook = excelApplication.Application.Workbooks.Add(Type.Missing);

                DataColumnCollection dataColumnCollection = dataTable.Columns;

                for (int i = 1; i <= dataTable.Rows.Count + 1; i++)
                {
                    for (int j = 1; j <= dataTable.Columns.Count; j++)
                    {
                        if (i == 1)
                            excelApplication.Cells[i, j] = dataColumnCollection[j - 1].ToString();
                        else
                            excelApplication.Cells[i, j] = dataTable.Rows[i - 2][j - 1].ToString();
                    }
                }
                if (File.Exists(@"D:\OTS_Transaction_Data.xlsx"))
                {
                    File.Delete(@"D:\OTS_Transaction_Data.xlsx");
                }
                // Save the excel file at specified location
                excelApplication.ActiveWorkbook.SaveCopyAs(@"D:\OTS_Transaction_Data.xlsx");

                excelApplication.ActiveWorkbook.Saved = true;

                // Close the Excel Application
                excelApplication.Quit();

                con.Close();

                //Release or clear the COM object
                //releaseObject(excelWorkBook);
                //releaseObject(excelApplication);

                //MessageBox.Show("Your data is exported Successfully into Excel File.");
            }
            // return dataTable;
        }

        public void abc()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_GetTodayIssueNOC", con);
                //SqlCommand cmd = new SqlCommand("select * from ", con);
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
                        string Requestid="" ;
                        string fee_Amount_Paid = dtRow["Fee_Amount_Paid"].ToString();
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        int flg = Convert.ToInt32(dtRow["Flag"]);

                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        DataTable dtt = new DataTable();
                        DataSet dss;
                        if (schemeType == 0)
                        {
                            if (fee_Amount_Paid == "Paid")
                            {
                                Requestid = dtRow["Bal_RequestID_1"].ToString();
                            }
                            else {
                                Requestid = dtRow["RequestID"].ToString();
                            }
                        }
                        else
                        {
                            switch (flg.ToString())
                            {
                                case "0":
                                    Requestid = dtRow["RequestID"].ToString();
                                    break;
                                case "1":
                                    if (string.IsNullOrEmpty(dtRow["Transaction_ID"].ToString()) == false)
                                    {
                                        Requestid = dtRow["Inst_RequestID_1"].ToString();
                                    }
                                    break;
                                case "2":
                                    if (string.IsNullOrEmpty(dtRow["Inst_Trans_ID1"].ToString()) == false)
                                    {
                                        Requestid = dtRow["Inst_RequestID_2"].ToString();
                                    }
                                    break;
                                case "3":
                                    if (string.IsNullOrEmpty(dtRow["Inst_Trans_ID2"].ToString()) == false)
                                    {
                                        Requestid = dtRow["Inst_RequestID_3"].ToString();
                                    }
                                    break;
                            }
                        }

                        if ((webService.WGetUBPaymentDetails(controlid, unitID, serviceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid)) != null)
                        {

                            dss = webService.WGetUBPaymentDetails(controlid, unitID, serviceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid);
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
                                    SqlCommand cmd20 = new SqlCommand("usp_updateNMSWPFeeStatus", con);
                                    cmd20.CommandType = CommandType.StoredProcedure;
                                    cmd20.Parameters.AddWithValue("@ControlID", controlid);
                                    cmd20.Parameters.AddWithValue("@UnitID", unitID);
                                    cmd20.Parameters.AddWithValue("@ServiceID ", serviceID);
                                    cmd20.Parameters.AddWithValue("@RequestID", Requestid);
                                    cmd20.Parameters.AddWithValue("@TransactionID", Transaction_ID);
                                    cmd20.Parameters.AddWithValue("@Fee_Amount", Fee_Amount);
                                    cmd20.Parameters.AddWithValue("@Transaction_Date", TrnDate);
                                    cmd20.Parameters.AddWithValue("@Flag", flg);

                                    SqlDataAdapter adp20 = new SqlDataAdapter(cmd20);

                                    DataSet dt20 = new DataSet();
                                    adp20.Fill(dt20);
                                    if (dt20.Tables.Count > 0)
                                    {
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
                                                    SqlCommand cmd5 = new SqlCommand("usp_OTSAdjustmentAmount", con);
                                                    cmd5.CommandType = CommandType.StoredProcedure;
                                                    cmd5.Parameters.AddWithValue("@pendingAmount", amount2);
                                                    cmd5.Parameters.AddWithValue("@ControlID", controlid);
                                                    cmd5.Parameters.AddWithValue("@UnitID", unitID);
                                                    cmd5.Parameters.AddWithValue("@ServiceID", serviceID);
                                                    cmd5.Parameters.AddWithValue("@RequestID", Requestid);

                                                    SqlDataAdapter adp5 = new SqlDataAdapter(cmd5);
                                                    DataTable dt7 = new DataTable();
                                                    adp5.Fill(dt7);
                                                    if (dt7.Rows.Count > 0)
                                                    {
                                                        Is_Certificate_Valid_Life_Time = "NO";
                                                        Remarks = "NOC Certificate Issued";
                                                        Certificate_EXP_Date_DDMMYYYY = "20/02/2022";
                                                       //noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                        if (noc_status == "SUCCESS")
                                                        {
                                                            WriteToFile("NOC Status Updated with Balanced Amount " + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                            //    UpdateLedger();
                                                           // MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                                                        }
                                                        //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Is_Certificate_Valid_Life_Time = "Yes";
                                                Remarks = "NOC Certificate Issued";
                                               // noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                if (noc_status == "SUCCESS")
                                                {
                                                    WriteToFile("NOC Status Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                   UpdateLedger(unitID, Requestid);
                                                    //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                                                }
                                            }
                                        }
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
                                                    SqlCommand cmd5 = new SqlCommand("usp_OTSAdjustmentAmount", con);
                                                    cmd5.CommandType = CommandType.StoredProcedure;
                                                    cmd5.Parameters.AddWithValue("@pendingAmount", amount2);
                                                    cmd5.Parameters.AddWithValue("@ControlID", controlid);
                                                    cmd5.Parameters.AddWithValue("@UnitID", unitID);
                                                    cmd5.Parameters.AddWithValue("@ServiceID", serviceID);
                                                    cmd5.Parameters.AddWithValue("@RequestID", Requestid);
                                                    SqlDataAdapter adp5 = new SqlDataAdapter(cmd5);
                                                    DataTable dt7 = new DataTable();
                                                    adp5.Fill(dt7);
                                                    if (dt7.Rows.Count > 0)
                                                    {
                                                        Is_Certificate_Valid_Life_Time = "NO";
                                                        Remarks = "25% Upfront Paid Successfully";
                                                        Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dt7.Rows[0]["DueDate-1"]).ToString("dd/MM/yyyy");
                                                        //noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                        if (noc_status == "SUCCESS")
                                                        {
                                                            WriteToFile("NOC Status for Instalment Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                            //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable Dt = isEligible(unitID);
                                                if (Dt.Rows.Count > 0)
                                                {
                                                    if(Dt.Rows[0]["Status_For_Instalment"].ToString() != "Ineligible")
                                                    {
                                                        Is_Certificate_Valid_Life_Time = "NO";
                                                        int flag = Convert.ToInt32(Dt.Rows[0]["Flag"]);
                                                        switch (flag)
                                                        {
                                                            case 1:
                                                                Remarks = "25% Upfront Paid Successfully";
                                                                Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-1"]).ToString("dd/MM/yyyy");
                                                                break;
                                                            case 2:
                                                                Remarks = "1st Instalment Paid Successfully";
                                                                Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-2"]).ToString("dd/MM/yyyy");
                                                                break;
                                                            case 3:
                                                                Remarks = "2nd Instalment Paid Successfully";
                                                                Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-3"]).ToString("dd/MM/yyyy");
                                                                break;
                                                            case 4:
                                                                Is_Certificate_Valid_Life_Time = "Yes";
                                                                Remarks = "3rd Instalment Paid Successfully";
                                                                //Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-3"]).ToString("dd/MM/yyyy");
                                                                break;
                                                        }
                                                        
                                                        //noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                        string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                        if (noc_status == "SUCCESS")
                                                        {
                                                            WriteToFile("NOC Status for DownPayment Instalment Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                                                            //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                                                        }
                                                    }
                                                }
                                                
                                            }
                                        }

                                    }

                                    WriteToFile(serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + status);
                                }

                            }

                        }
                    }
                }
                else {
                    WriteToFile("Else Part");
                }

            }

            catch (Exception ex)
            {

            }
        }
        protected DataTable isEligible(string unitid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Flag, Status_For_Instalment from OTS_NMSWPTransactionDetail where  UnitID='" + unitid + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
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
            NOC_Certificate_Number = "NOC-" + Request_ID + "";
            Is_Certificate_Valid_Life_Time = "Yes";
            //Remarks = "NOC Certificate Issued";
            //NOC_URL = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo='SER20220225/2000/26961/21311'";

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
        protected void MailToAllotteeAfterPaid(string unitid, string serviceid,  string transID, string transDate, string transAmount, int schemeType)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select AM.AllotteeName, AM.AllotteeID,AM.PhoneNo, ONT.*,OT.* from OTS_NMSWPTransactionDetail ONT join AllotteeMaster AM on AM.AllotteeID = Try_Cast(ONT.AllotteeID as int) join OTS_NMSWPInstalmentTransactionDetail OT on ONT.UnitID=OT.UnitID where  ONT.UnitID='" + unitid + "' and ONT.ServiceID='" + serviceid + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string remainingAmount;
                string paidAmount; 
                string allotteeName = dt.Rows[0]["AllotteeName"].ToString();
                string allotteeID = dt.Rows[0]["AllotteeID"].ToString();
                string contactNo = dt.Rows[0]["PhoneNo"].ToString();
                string applicationDate = (Convert.ToDateTime(dt.Rows[0]["ApplicationDate"])).ToString("dd/MM/yyyy");
                string totalDues = (Convert.ToDouble(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDouble(dt.Rows[0]["InterestOnMCUpto"])).ToString();
                string PayableAmount=(Convert.ToDouble(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDouble(dt.Rows[0]["InterestOnMCUpto"]) - Convert.ToDouble(dt.Rows[0]["Waive_Off"])).ToString();
                string waiver = dt.Rows[0]["Waive_Off"].ToString();
                string downpayment = dt.Rows[0]["DownPayment"].ToString();
                string lblFirstInstalmentAmount = dt.Rows[0]["Installment-1"].ToString();
                string lblSecInstalmentAmount = dt.Rows[0]["Installment-2"].ToString();
                string lblThirdInstalmentAmount = dt.Rows[0]["Installment-3"].ToString();
                string lblDownPaymentStatus;
                string lblDownPaymentDate="";
                string lblFirstStatus;
                string lblFirstInstDate="";
                string lblSecStatus;
                string lblSecInstDate="";
                string lblThirdStatus;
                string lblThirdInstDate="";
                #region schemeType=0
                if (Convert.ToInt32(dt.Rows[0]["Fee_Amount"])== Convert.ToInt32(transAmount))
                {
                    paidAmount = dt.Rows[0]["Fee_Amount"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["Balance_Amount"].ToString()) == false)
                    {
                        remainingAmount = dt.Rows[0]["Balance_Amount"].ToString();
                    }
                    else
                    {
                        remainingAmount = "Nil";
                    }
                }
                else
                {
                    paidAmount =(Convert.ToDecimal(dt.Rows[0]["Fee_Amount"])+ Convert.ToDecimal(transAmount)).ToString();
                    remainingAmount = "Nil";
                }
                #endregion
                #region schemeType=1
                if (string.IsNullOrEmpty(dt.Rows[0]["Transaction_ID"].ToString()) == false)
                {
                    lblDownPaymentStatus = "Paid";
                    lblDownPaymentDate= Convert.ToDateTime(dt.Rows[0]["Transaction_Date"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblDownPaymentStatus = "Pending";

                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-1"].ToString()) == false)
                {
                    lblFirstStatus = "Paid";
                    lblFirstInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date1"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblFirstStatus = "Pending";
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-2"].ToString()) == false)
                {
                    lblSecStatus = "Paid";
                    lblSecInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date2"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblSecStatus = "Pending";
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-3"].ToString()) == false)
                {
                    lblThirdStatus = "Paid";
                    lblThirdInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date3"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblThirdStatus = "Pending";
                }

                #endregion



                string emailID = detailOfAllotteeForMail1(allotteeID);
                MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                MailAddress mailto = new MailAddress(emailID);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                newmsg.IsBodyHtml = true;

                string StrContent = "";
                //StreamReader reader = new StreamReader(Server.MapPath("~/OTSPaidStatusMail.html"));
                StreamReader reader ;
                if (schemeType == 0)
                {
                    reader = new StreamReader(Server.MapPath("~/OTSSchemePaymentDoneMail.html"));
                    StrContent = reader.ReadToEnd();
                }
                else if(schemeType == 1)
                {
                    reader = new StreamReader(Server.MapPath("~/OTSPaidStatusMail.html"));
                    StrContent = reader.ReadToEnd();
                }

                StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
                StrContent = StrContent.Replace("{TransactionID}", transID.Trim());
                StrContent = StrContent.Replace("{DateOfTransaction}", transDate.Trim());
                StrContent = StrContent.Replace("{emailID}", emailID.Trim());
                StrContent = StrContent.Replace("{contactNo}", contactNo.Trim());
                StrContent = StrContent.Replace("{TotalDues}", totalDues.Trim());
                StrContent = StrContent.Replace("{Waiver}", waiver.Trim());
                StrContent = StrContent.Replace("{PayableAmount}", PayableAmount.Trim());
                StrContent = StrContent.Replace("{downpayment}", downpayment.Trim());
                StrContent = StrContent.Replace("{AmountPaid}", paidAmount.Trim());
                StrContent = StrContent.Replace("{RemainingAmount}", remainingAmount.Trim());
                StrContent = StrContent.Replace("{transAmount}", transAmount.Trim());
                StrContent = StrContent.Replace("{DownPaymentAmount}", downpayment.Trim());
                StrContent = StrContent.Replace("{lblFirstInstalmentAmount}", lblFirstInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblSecInstalmentAmount}", lblSecInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblThirdInstalmentAmount}", lblThirdInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblDownPaymentStatus}", lblDownPaymentStatus.Trim());
                StrContent = StrContent.Replace("{lblFirstStatus}", lblFirstStatus.Trim());
                StrContent = StrContent.Replace("{lblSecStatus}", lblSecStatus.Trim());
                StrContent = StrContent.Replace("{lblThirdStatus}", lblThirdStatus.Trim());
                StrContent = StrContent.Replace("{lblDownPaymentDate}", lblDownPaymentDate);
                StrContent = StrContent.Replace("{lblFirstInstDate}", lblFirstInstDate.Trim());
                StrContent = StrContent.Replace("{lblSecInstDate}", lblSecInstDate.Trim());
                StrContent = StrContent.Replace("{lblThirdInstDate}", lblThirdInstDate.Trim());
                //StrContent = StrContent.Replace("{ComplaintID}", complaintId);


                newmsg.Subject = "Thank you for your Application under OTS Scheme for Maintenance Dues";
                newmsg.Body = StrContent;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");

                smtp.EnableSsl = true;
                smtp.Send(newmsg);
            }
        }
        protected string detailOfAllotteeForMail1(string AllotteeID)
        {
            DataTable dt;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end from AllotteeMaster  where AllotteeID='" + AllotteeID + "' and IsCompleted=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

                return dt.Rows[0][0].ToString().Trim();
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
        protected void NOC_OTS_Update()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where IsCompleted = 1 and Schemetype = 0", con);
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
                    string Requestid = dtRow["RequestID"].ToString();
                    string Fee_Amount = dtRow["Fee_Amount"].ToString();
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    int flg = Convert.ToInt32(dtRow["Flag"]);

                    Is_Certificate_Valid_Life_Time = "Yes";
                    Remarks = "NOC Certificate Issued";
                    string noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                    string noc_status= StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                    if (noc_status == "SUCCESS")
                    {
                        WriteToFile("NOC Status Updated"+serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                    }

                }
            }
        }
        //protected void UpdateLedger(string unitID, string reqID)
        protected void ToBeUpdateledger()
        {
            try
            {
                //select * from OTS_NMSWPTransactionDetail where IsCompleted=1 and Schemetype=1 and Ledger_Flag='Not Updated'
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand com = new SqlCommand("select * from OTS_NMSWPTransactionDetail where  IsCompleted=1 and Ledger_Flag='Not Updated'", con);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        string controlid = dtRow["ControlID"].ToString();
                        string unitID = dtRow["UnitID"].ToString();
                        string serviceID = dtRow["ServiceID"].ToString();
                        string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        int flg = Convert.ToInt32(dtRow["Flag"]);
                        string fee_Amount_Paid = dtRow["Fee_Amount_Paid"].ToString();
                        string Requestid = dtRow["RequestID"].ToString();

                        if (schemeType == 0)
                        {
                            if (fee_Amount_Paid == "Paid")
                            {
                                Requestid = dtRow["Bal_RequestID_1"].ToString();
                            }
                            else {
                                Requestid = dtRow["RequestID"].ToString();
                            }
                        }
                        UpdateLedger(unitID, Requestid);
                    }
                }
            }
            catch
            {

            }
        }
        protected void UpdateLedger(string unitID, string reqID)
        {
            //usp_Update_OTS_Ledger 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where isCompleted=1 and isActive=0 and Ledger_Flag='Not Updated'", con);
            SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Ledger_Flag='Not Updated' and UnitID='" + unitID+"'", con);
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
                    decimal Interest =0; //Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    decimal MaintenanceCharge = Convert.ToDecimal(dtRow["MaintenanceCharge"]);
                    decimal Fee_Amount = Convert.ToDecimal(dtRow["Fee_Amount"]);
                    decimal restInstPayment = Convert.ToDecimal(dtRow["Installment-1"]);
                    decimal Waive_Off = Convert.ToDecimal(dtRow["Waive_Off"]);
                    decimal IntuptoJune = Convert.ToDecimal(dtRow["InterestOnMaintenanceChargeUpTo30-06-21"]);
                    decimal Intupto = Convert.ToDecimal(dtRow["InterestOnMCUpto"]);
                    DateTime DownPaymentDat = Convert.ToDateTime(dtRow["DownPaymentDueDate"]);
                    int AllotteeID = Convert.ToInt32(dtRow["AllotteeID"]);
                    DateTime Transaction_Date = Convert.ToDateTime(dtRow["Transaction_Date"]);
                    string Ledger_Flag = dtRow["Ledger_Flag"].ToString();
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    int flg = Convert.ToInt32(dtRow["Flag"]);
                    decimal AccessInterest = Intupto - IntuptoJune;
                    decimal Bal_amount = 0;
                    decimal OfflineAccessAmount = (String.IsNullOrEmpty(dtRow["OfflineAccessAmount"].ToString())) ? 0 : Convert.ToDecimal(dtRow["OfflineAccessAmount"]);
                    if (schemeType == 0)
                        {
                        if (string.IsNullOrEmpty(dtRow["Balance_Amount"].ToString()) == false)
                        {
                            Bal_amount = Convert.ToDecimal(dtRow["Balance_Amount"]);
                        }
                        
                        Interest = (Fee_Amount - MaintenanceCharge + Bal_amount) * 2;
                        Waive_Off = (Fee_Amount - MaintenanceCharge) + Bal_amount;
                        if (reqID.Trim() == dtRow["Bal_RequestID_1"].ToString().Trim())
                        {

                        }
                        if (string.IsNullOrEmpty(dtRow["Bal_Trans_Date"].ToString()) == false)
                        {
                            Transaction_Date = Convert.ToDateTime(dtRow["Bal_Trans_Date"]);
                        }
                    }else if (schemeType == 1)
                    {
                        //decimal AccessInterest = Intupto - IntuptoJune;
                        Interest = (Fee_Amount + (restInstPayment*3) - MaintenanceCharge) * 2;
                        Waive_Off = (Fee_Amount + (restInstPayment * 3) - MaintenanceCharge);
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
                        cmd_Bal.Parameters.AddWithValue("@DownpaymentDate", DownPaymentDat); //("@OfflineAccessAmount", OfflineAccessAmount);
                        cmd_Bal.Parameters.AddWithValue("@OfflineAccessAmount", OfflineAccessAmount);//
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
        protected void OTS_Instalment_NOC()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Schemetype=1 and Flag=1 '", con);
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
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        string TrnDate = dtRow["Transaction_Date"].ToString();

                        Is_Certificate_Valid_Life_Time = "NO";
                        Remarks = "25% Upfront Paid Successfully";
                        Certificate_EXP_Date_DDMMYYYY = Convert.ToDateTime(dtRow["DueDate-1"]).ToString("dd/MM/yyyy");
                        string noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                        string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                        if (noc_status == "SUCCESS")
                        {
                            WriteToFile("NOC Status for DownPayment Instalment Updated" + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);
                            MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void OTS_BalPending_NOC()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where Schemetype = 0 and Fee_Amount_Paid = 'Paid' and Balance_Amount is not null", con);
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
                        Remarks = "NOC Certificate Issued";
                        Certificate_EXP_Date_DDMMYYYY = "20/02/2022";
                        string noc_url = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                        string noc_status = StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                        if (noc_status == "SUCCESS")
                        {
                            WriteToFile("NOC Status Updated with Balanced Amount " + serviceReqNo + "/" + controlid + "/" + unitID + "/" + serviceID + "/" + Requestid + "/" + DateTime.Now);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void InstalmentNOC()
        {
            ControlID = "UPSWP220574317";
            UnitID = "UPSWP22057431701";
            ServiceID = "SC21033";
            Request_ID = "22057431701210330001";
            ServiceRequestNo = "SER20220325/2000/40807/46802";
            Is_Certificate_Valid_Life_Time = "Yes";
            //Remarks = "3rd Instalment Paid Successfully";
            Remarks = "Down payment Paid Successfully";

           //string noc_url = "https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + ServiceRequestNo.Trim() + "";
            string noc_url1 = "https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + ServiceRequestNo.Trim() + "";
            string noc_status = StatusUpdateOnWithNOC(ControlID, UnitID, ServiceID, Request_ID, Fee_Amount.ToString(), noc_url1, Remarks);
            if (noc_status == "SUCCESS")
            {
                WriteToFile("NOC Status for DownPayment Instalment Updated" + ServiceRequestNo + "/" + ControlID + "/" + UnitID + "/" + ServiceID + "/" + Request_ID + "/" + DateTime.Now);
                //MailToAllotteeAfterPaid(unitID, serviceID, Transaction_ID, TrnDate, Fee_Amount.ToString(), schemeType);
            }

        }
        
        //protected void xyz()
        //{
            
        //        Status_Code = "12";
        //        Fee_Amount = "2360";
        //        Fee_Status = "UB";
        //        Remarks = "Fee Paid at UPSIDA. Kindly pay nivesh mitra processing fee for final Submission | Applicant";
        //        Pendancy_level = "Applicant";
        //    string res= FeeStatusNM_Click("UPSWP210002975", "UPSWP21000297526", "SC21034", "2360",)
        //        //NiveshMitra.upswp_niveshmitraservicesSoapClient webService1 = new NiveshMitra.upswp_niveshmitraservicesSoapClient();
        //        string Update_Result = webService1.WReturn_CUSID_STATUS(
        //         controlid,
        //         unitid,
        //         serviceid,
        //         ProcessIndustryID,
        //         ApplicationID,
        //         Status_Code,
        //         Remarks,
        //         Pendancy_level,
        //         Fee_Amount,
        //         Fee_Status,
        //         Transaction_ID,
        //         Transaction_Date,
        //         Transaction_Date_Time,
        //         NOC_Certificate_Number,
        //         NOC_URL,
        //         ISNOC_URL_ActiveYesNO,
        //         "p5632aa8a5c915ba4b896325bc5baz8k",
        //         Request_ID,
        //        Objection_Rejection_Code,
        //        Is_Certificate_Valid_Life_Time,
        //        Certificate_EXP_Date_DDMMYYYY,
        //        D1,
        //        D2,
        //        D3,
        //        D4,
        //        D5,
        //        D6,
        //        D7
        //       );
        //    }

        //}
    }
}