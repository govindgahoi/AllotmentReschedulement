using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class AllotteeReservationMoneyPayNMSWP : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        SqlConnection con;
        public string ServiceReqNo;
        string SWCControlID  = "";
        string SWCUnitID     = "";
        string SWCServiceID  = "";
        string SWCRequest_ID = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            ServiceReqNo = Request.QueryString["ServiceReqNo"];
          

            if (ServiceReqNo != null)
            {
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID    = NMSWP.Rows[0][0].ToString();
                SWCUnitID       = NMSWP.Rows[0][1].ToString();
                SWCServiceID    = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID   = NMSWP.Rows[0][3].ToString();
                if (ServiceReqNo.Length > 0)
                {
                    BindAllotteeRecord();
                }

                if (SWCControlID.Length > 0)
                {
                    CheckNMSWPFeePaid();
                }
            }
        }


        private void BindAllotteeRecord()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotteeRecordToBind(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string IAID = dt.Rows[0][0].ToString();
                    string PlotNo = dt.Rows[0][1].ToString();
                  

                    GetApplicantDetails(IAID,PlotNo);

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }
 

        private void GetApplicantDetails(string IAID, string PlotNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {          
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                ds = objServiceTimelinesBLL.GetDetailsWithReservationMoneyNew(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt1.Rows.Count > 0)
                {
                    Paid = dt1.Rows[0]["Paid"].ToString();

                }

                if (dt.Rows.Count > 0)
                {
                    string Days = dt.Rows[0]["DateDiff"].ToString();
                    string prevrate = dt.Rows[0]["PrevRate"].ToString();
                    string currentrate = dt.Rows[0]["CurrentRate"].ToString();


                    if (Paid == "True")
                    {
                        Div1.Visible = true;
                        lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                        lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                        lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
                        lblLetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                        lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                        lblProduct.Text = dt.Rows[0]["IndustryType"].ToString();
                        lblAddress.Text = dt.Rows[0]["Address"].ToString();
                        lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                        lblEmail.Text = dt.Rows[0]["Email"].ToString();
                        lblAllotmentDate.Text = dt.Rows[0]["AllottmentDate"].ToString();
                        lblIndustrialArea.Text = dt.Rows[0]["IndustrialArea"].ToString();
                    }
                    else
                    {
                        if (Convert.ToInt32(Days) <= 60)
                        {

                            if (Convert.ToInt32(Days) <= 30)
                            {
                                Div1.Visible = true;
                                lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                                lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                                lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
                                lblLetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                                lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                                lblProduct.Text = dt.Rows[0]["IndustryType"].ToString();
                                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                                lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                                lblEmail.Text = dt.Rows[0]["Email"].ToString();
                                lblAllotmentDate.Text = dt.Rows[0]["AllottmentDate"].ToString();
                                lblIndustrialArea.Text = dt.Rows[0]["IndustrialArea"].ToString();
                            }
                            else
                            {
                                if (prevrate == currentrate)
                                {
                                    Div1.Visible = true;
                                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                                    lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
                                    lblLetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                                    lblProduct.Text = dt.Rows[0]["IndustryType"].ToString();
                                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                                    lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                                    lblEmail.Text = dt.Rows[0]["Email"].ToString();
                                    lblAllotmentDate.Text = dt.Rows[0]["AllottmentDate"].ToString();
                                    lblIndustrialArea.Text = dt.Rows[0]["IndustrialArea"].ToString();
                                }
                                else
                                {
                                    div2.Visible = false;
                                    Div1.Visible = false;
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('You are not eligible for this service as rates are changed');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            div2.Visible = false;
                            Div1.Visible = false;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('You are not eligible for this service as your servicetimeline is passed. Kindly contact regional office');", true);
                            return;
                        }
                    }
                }
                else
                {
                    div2.Visible = false;
                    Div1.Visible = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Records are not found kindly contact regional office');", true);
                    return;
                }
                if (dt1.Rows.Count > 0)
                {
                    div2.Visible = true;
                    lblServiceRefNo.Text = dt1.Rows[0]["ServiceRefNo"].ToString();
                    lblAmount.Text = dt1.Rows[0]["ReservationAmount"].ToString();
                    lblReservationMoneyDueDate.Text = dt1.Rows[0]["ReservationMoneydueDate"].ToString();
                    lblPaymentStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                    lblTransactionAmount.Text = dt1.Rows[0]["TransactionAmount"].ToString();
                    lblTransactionDate.Text = dt1.Rows[0]["TransactionDate"].ToString();
                    LblPaymentMode.Text = dt1.Rows[0]["PaymentMode"].ToString();
                    lblTransactionRefNo.Text = dt1.Rows[0]["TraID"].ToString();
                    lblStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                    if (lblTransactionRefNo.Text.Length > 0)
                    {
                        Tr2.Visible = true;
                    }
                    else
                    {
                        Tr2.Visible = false;
                    }
                    if (lblPaymentStatus.Text == "Paid")
                    {
                        tr3.Visible = true;
                        btnPay.Text = "Paid";
                        btnPay.Enabled = false;
                    }
                    else if(lblPaymentStatus.Text == "Pending")
                    {
                        tr3.Visible = false;
                        btnPay.Text = "Submitted";
                        btnPay.Enabled = false;
                    }
                    else
                    {
                        btnPay.Text = "Submit";
                        btnPay.Enabled = true;
                        tr3.Visible = false;
                    }


                }
                if (dt2.Rows.Count > 0)
                {
                    decimal total = 0;
                    GridPayment.DataSource = dt2;
                    GridPayment.DataBind();
                    if (dt2.Rows[0]["Amount"].ToString().Length > 0)
                    {
                        total = dt2.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                    }
                    else
                    {
                        total = 0;
                    }
                    GridPayment.FooterRow.Cells[1].Text = "Total";
                    GridPayment.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridPayment.FooterRow.Cells[2].Text = total.ToString("N2");
                }
                else
                {
                    GridPayment.DataSource = null;
                    GridPayment.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

    
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            String js = "window.open('DocViewerDemand.aspx?DemandID=" + lblServiceRefNo.Text.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerDemand.aspx", js, true);
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {


            try
            {


                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforeNMSWP(lblServiceRefNo.Text);

                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                }
                else
                {
                    dsR = objServiceTimelinesBLL.GetReservationAmount(lblServiceRefNo.Text);

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
                                        BindAllotteeRecord();
                                        return;
                                    }
                                    else
                                    {
                                        string Message = "Request is submitted successfully. Kindly pay amount from nivesh mitra portal for the final submission of your application.";
                                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                        BindAllotteeRecord();
                                        return;
                                    }

                                }
                                else
                                {
                                    string Message = "Error At NMSWP";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                                    return;
                                }
                            }


                        }
                        else
                        {
                            string Message = "Amount is null";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            String js = "window.open('ReservationMoneyPaymentAck.aspx?ServiceReqNo=" + lblServiceRefNo.Text.Trim() + "&TraId=" + lblTransactionRefNo.Text + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReservationMoneyPaymentAck.aspx", js, true);
        }

        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            {


                string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
                string UnitID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
                string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
                string DeptID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
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
                        string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + lblIndustrialArea.Text, SWCRequest_ID, "DA " + lblIndustrialArea.Text, "");
                        if (Result == "SUCCESS")
                        {
                            string NOC_URL = "http://eservices.onlineupsidc.com/ReservationMoneyPaymentAck.aspx?ServiceReqNo=" + ServiceReqNo + "&TraId=" + lblTransactionRefNo.Text + "";

                            string NMSWP_Result1 = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, (15).ToString(), "Reservation Money Payment Receipt Generated | Applicant", NOC_URL, ServiceReqNo, SWCRequest_ID, "");

                        }
                        else
                        {

                        }
                    }
                }


            }
        }

    }


}