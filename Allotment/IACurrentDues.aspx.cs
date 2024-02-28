using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;
using System.Windows.Input;
using System.Drawing;
using System.Collections.Specialized;

namespace Allotment
{
    public partial class IACurrentDues : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        public string AllotteeID;
        public string ServiceReqNo;
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        string TraID = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                string[] SerIdarray = ServiceReqNo.Split('/');
                AllotteeID = SerIdarray[2].ToString();
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID    = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();
                if (SWCControlID.Length>0)
                {
                    CheckNMSWPFeePaid();
                }
                GetApplicantDetails();
                BindAllotteePaymentSummary(AllotteeID);
            }
            catch(Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

 
        }

        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";

            try
            {
               
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
         
                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindDuesPayment(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text    = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text    = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text      = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text   = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    TraID = dt.Rows[0]["TraID"].ToString();
                    Paid = dt.Rows[0]["NMStatus"].ToString();

                    if (Paid == "Pending")
                    {
                        btn_PayNow.Text = "Submitted";
                        btn_PayNow.Enabled = false;
                        btn_Receipt.Visible = false;
                    }
                    else
                    {
                        btn_PayNow.Text = "Submit";
                        btn_PayNow.Enabled = true;
                        btn_Receipt.Visible = false;
                    }
                    if (TraID.Length>0)
                    {
                        btn_PayNow.Text = "Paid";
                        btn_PayNow.Enabled = false;
                        btn_Receipt.Visible = true;
                    }
                    

                   
                }
                else
                {
                    AllotteeDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void BindAllotteePaymentSummary(string AllotteeID)
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + Convert.ToInt32(AllotteeID) + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteePaymentSummaruGrid.DataSource = dt;
                AllotteePaymentSummaruGrid.DataBind();
                decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("Demanded"));
                decimal tot_Paid = dt.AsEnumerable().Sum(row => row.Field<decimal>("Paid"));
                decimal tot_Outstanding = dt.AsEnumerable().Sum(row => row.Field<decimal>("Outstanding"));
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].Text = "Total";
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                AllotteePaymentSummaruGrid.FooterRow.Cells[2].Text = tot_Demanded.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[3].Text = tot_Paid.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[4].Text = tot_Outstanding.ToString("N2");
                btn_PayNow.Visible = true;
            }
            else
            {
                AllotteePaymentSummaruGrid.DataSource = null;
                AllotteePaymentSummaruGrid.DataBind();
                btn_PayNow.Visible = false;
            }
        }


        protected void AllotteePaymentSummaruGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteePaymentSummaruGrid.Rows.Count - 1; i++)
            {
                string Amount = AllotteePaymentSummaruGrid.Rows[i].Cells[4].Text;
                if (Convert.ToDecimal(Amount) > 0)
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                else
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Green;
                }

            }


        }

        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            { 


                string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
                string UnitID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
                string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
                string DeptID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt  = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
                NameValueCollection collections = new NameValueCollection();
                collections.Add("Dept_Code", DeptID.Trim());
                collections.Add("ControlID", ControlID.Trim());
                collections.Add("UnitID", UnitID.Trim());
                collections.Add("ServiceID", ServiceID.Trim());
                collections.Add("PassSalt", PassSalt.Trim());

                string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_PayNow_Click(object sender, EventArgs e)
        {



            try
            {


                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                GeneralMethod gm = new GeneralMethod();
                
                dsR = objServiceTimelinesBLL.GetOutstandingDuesAmountNMSWP(ServiceReqNo);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {

                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                    gm = new GeneralMethod();
                    if (TotalCharges > 0)
                    {
                        string ReturnMsg = gm.CreateTransactionDataBeforeNMSWP(ServiceReqNo);
                        if (ReturnMsg.Trim() == "Success")
                        {
                            string NMSWP_Result = gm.UpdateFeeAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "12", "Applicant Request Submitted, Fee Payment is Pending kindly pay fees for the final submission | Applicant", (TotalCharges).ToString(), SWCRequest_ID, "Applicant");

                            if (NMSWP_Result.Trim() == "SUCCESS")
                            {
                                string ReturnMsg1 = gm.UpdateTraStatusNMSWP(ServiceReqNo);
                                if (ReturnMsg1 == "Success")
                                {
                                    string Message = "Request is submitted successfully. Kindly pay amount from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetApplicantDetails();
                                    return;
                                }
                                else
                                {
                                    string Message = "Request is submitted successfully. Kindly pay amount from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetApplicantDetails();
                                    return;
                                }

                            }
                            else
                            {
                                string Message = NMSWP_Result;
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                                return;
                            }
                        }
                        else
                        {
                            string Message = "Server not responding";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                            return;
                        }


                    }
                    else
                    {
                        string Message = "Amount is null";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        return;
                    }
                }
                else
                {
                    string Message = "There are no pending dues";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

                
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
                this.LogError(ex);
                return;
            }


        }

        protected void btn_Receipt_Click(object sender, EventArgs e)
        {
            String js = "window.open('OutstandingDuesPaymentAck.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&TraId=" + TraID.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OutstandingDuesPaymentAck.aspx", js, true);
        }

        private void CheckNMSWPFeePaid()
        {

            SqlCommand cmd = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ControlID='" + SWCControlID.Trim() + "' and UnitID='" + SWCUnitID.Trim() + "' and ServiceID='" + SWCServiceID.Trim() + "' and RequestID='" + SWCRequest_ID + "' and isnull(Fee_Status,'') in ('Pending')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {



                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID,SWCRequest_ID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "11")
                {
                    string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                    string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                    if (Dt == "Success")
                    {
                        string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                        if (Result == "SUCCESS")
                        {
                            string NOC_URL = "https://eservices.onlineupsidc.com/OutstandingDuesPaymentAck.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&TraId=" + TransactionID + "";

                            string NMSWP_Result1 = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, (15).ToString(), "Outstanding Dues Payment Receipt Generated", NOC_URL, ServiceReqNo.Trim(), SWCRequest_ID, "");

                        }
                        else
                        {

                        }
                    }
                }


            }
        }
        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}