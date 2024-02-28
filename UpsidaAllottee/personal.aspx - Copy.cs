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
            ControlID = "UPSWP210002975";
            UnitID = "UPSWP21000297504";
            ServiceID = "SC21033";
            double amount = 12947993147.5;
            Request_ID = "21000297504210330001";

               con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
            if (NMSWP_Result == "SUCCESS")
            {
                //var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                //var script = string.Format("alert({0});window.location ='http://72.167.225.87/testing_nmswp/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                //MailToAllotteeAfterApplied(ds.Tables[0]);
            }
            else
            {
                string message1 = "Error Occured while updating status at NMSWP";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
            }
            //abc();
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
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        int flg = Convert.ToInt32(dtRow["Flag"]);
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
                                                Decimal amount2 = (amt2 - amt1);
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
                                                    if (dt7.Rows.Count > 0) { 

                                                    
                                                    Is_Certificate_Valid_Life_Time = "NO";
                                                    Remarks = "NOC Certificate Issued";
                                                    Certificate_EXP_Date_DDMMYYYY = "20/02/2022";
                                                    noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                    //MailToAllotteeAfterPaid(controlid, unitID, serviceID, Requestid);
                                                    //StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                       
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                

                                                Is_Certificate_Valid_Life_Time = "Yes";
                                                Remarks = "NOC Certificate Issued";
                                                noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                //StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                //MailToAllotteeAfterPaid(controlid, unitID, serviceID, Requestid);
                                               
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
                                                Decimal amount2 = (amt2 - amt1);
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
                                                }
                                            }
                                            else
                                            {
                                                SqlCommand cmd30 = new SqlCommand("Select * from OTS_NMSWPTransactionDetail where RequestID='"+ Requestid + "'", con);
                                                SqlDataAdapter sda = new SqlDataAdapter(cmd30);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                string Flag = dtRow["Flag"].ToString();
                                                string NOC_Valid_Date1 = (Convert.ToDateTime(dtRow["DueDate-1"])).ToString("dd/MM/yyy");
                                                string NOC_Valid_Date2 = (Convert.ToDateTime(dtRow["DueDate-1"])).ToString("dd/MM/yyy");
                                                string NOC_Valid_Date3 = (Convert.ToDateTime(dtRow["DueDate-1"])).ToString("dd/MM/yyy");
                                                DateTime date = Convert.ToDateTime(dtRow["DueDate-3"]);
                                                if (Flag == "0")
                                                {
                                                    Certificate_EXP_Date_DDMMYYYY = NOC_Valid_Date1;
                                                }
                                                else if (Flag == "1")
                                                {
                                                    Certificate_EXP_Date_DDMMYYYY = NOC_Valid_Date2;
                                                }
                                                else if (Flag == "2")
                                                {
                                                    Certificate_EXP_Date_DDMMYYYY = NOC_Valid_Date3;
                                                }
                                                else if (Flag == "3")
                                                {

                                                    var startDate = new DateTime(date.Year, date.Month, 1);
                                                    var endDate = startDate.AddMonths(1).AddDays(-1);
                                                    Certificate_EXP_Date_DDMMYYYY = endDate.ToString("dd/MM/yyyy");
                                                }
                                                Is_Certificate_Valid_Life_Time = "NO";
                                                Remarks = "25% Upfront Paid Successfully";
                                                noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                               // StatusUpdateOnWithNOC(controlid, unitID, serviceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                //MailToAllotteeAfterPaid(controlid, unitID, serviceID, Requestid);
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

        protected void StatusUpdateOnWithNOC(string controlid, string unitid, string serviceid, string requestid, string amount, string noc_url, string remarks)
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

            Console.WriteLine(Update_Result);
        }
        protected void MailToAllotteeAfterPaid(string controlid, string unitid, string serviceid, string requestid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            DataTable DT = new DataTable();
            SqlCommand cmd = new SqlCommand("select AM.AllotteeName, AM.AllotteeID from OTS_NMSWPTransactionDetail ONT join AllotteeMaster AM on AM.AllotteeID = Try_Cast(ONT.AllotteeID as int) where ONT.ControlID='" + controlid + "' and ONT.UnitID='" + unitid + "' and ONT.ServiceID='" + serviceid + "' and ONT.RequestID='" + requestid + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(DT);
            if (DT.Rows.Count > 0)
            {
                string allotteeName = DT.Rows[0]["AllotteeName"].ToString();
                string allotteeID = DT.Rows[0]["AllotteeID"].ToString();

                string emailID = detailOfAllotteeForMail1(allotteeID);
                MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                MailAddress mailto = new MailAddress(emailID);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/OTSPaidStatusMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
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

    }
}