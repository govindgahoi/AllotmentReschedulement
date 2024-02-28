using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
//using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Collections.Specialized;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;
namespace Allotment
{
    public partial class LeaseDeedApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string ServiceReqNo;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {

            }

            ServiceReqNo = Request.QueryString["ViewID"];
            DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
            SWCControlID = NMSWP.Rows[0][0].ToString();
            SWCUnitID = NMSWP.Rows[0][1].ToString();
            SWCServiceID = NMSWP.Rows[0][2].ToString();
            SWCRequest_ID = NMSWP.Rows[0][3].ToString();
            if (SWCControlID.Length > 0)
            {
                btn_Submit.Visible = true;
                btnPay.Visible = false;
               
                CheckNMSWPFeePaid();
            }
            else
            {
                btn_Submit.Visible = false;
                btnPay.Visible = true;
               
            }
            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();
                BindServiceCheckListGridViewDocument();
            }

            if (ServiceReqNo != null)
            {
                if (ServiceReqNo.Length > 0)
                {
                    divSearch.Visible = false;
                    GetApplicationDetails();
                }

            }
            else
            {
                divSearch.Visible = true;
            }
        }



        private void GetApplicationDetails()
        {
            string Objection = "";
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsLeaseDeedAll '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    DivDoc.Visible = false;
                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    string Payment = dt.Rows[0]["PaymentStatus"].ToString();
                    lblServiceRefNo.Text = ServiceReqNo.Trim();
                    Objection = dt.Rows[0]["Objection"].ToString();
                    lblAmount.Text = dt.Rows[0]["FeeAmount"].ToString();
                    lblGSTAmount.Text = dt.Rows[0]["GSTAmount"].ToString();
                    string NMFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
                    lbl_TotalAmount.Text = (Convert.ToDecimal(dt.Rows[0]["FeeAmount"].ToString()) + Convert.ToDecimal(dt.Rows[0]["GSTAmount"].ToString())).ToString();

                    if (SWCControlID.Length > 0) 
                    {
                        if (NMFee == "Pending")
                        {
                            DivApply.Visible = false;
                        }
                        else if(NMFee == "Paid")
                        {
                            DivApply.Visible = false;
                        }else
                        {
                            DivApply.Visible = true;
                        }
                       
                    }
                    else
                    {
                        if (Payment == "Paid")
                        {
                            DivApply.Visible = false;
                        }
                        else
                        {
                            DivApply.Visible = true;
                        }
                    }
                   
                    if (Objection == "True")
                    {
                        Objection_Div.Visible = true;
                        BindObjection();
                    }
                    else
                    {
                        Objection_Div.Visible = false;
                    }
                }
                if (SWCControlID.Length > 0)
                {
                    if (dt4.Rows.Count > 0)
                    {
                        DivPayment.Visible = true;

                        lblServiceNo.Text = dt4.Rows[0]["ServiceNo"].ToString();
                        lblTraRefNo.Text = dt4.Rows[0]["TransactionRefNo"].ToString();
                        lblTraAmount.Text = dt4.Rows[0]["TransactionAmount"].ToString();
                        lblTraDate.Text = dt4.Rows[0]["TransactionDate"].ToString();
                        lblBankRefNo.Text = dt4.Rows[0]["EazypayRefNo"].ToString();
                        lblPaymentStatus.Text = dt4.Rows[0]["PaymentStatus"].ToString();
                        lblPaymentMode.Text = dt4.Rows[0]["PaymentMode"].ToString();
                    }
                }
                else
                {
                    if (dt1.Rows.Count > 0)
                    {
                        DivPayment.Visible = true;

                        lblServiceNo.Text = dt1.Rows[0]["ServiceNo"].ToString();
                        lblTraRefNo.Text = dt1.Rows[0]["TransactionRefNo"].ToString();
                        lblTraAmount.Text = dt1.Rows[0]["TransactionAmount"].ToString();
                        lblTraDate.Text = dt1.Rows[0]["TransactionDate"].ToString();
                        lblBankRefNo.Text = dt1.Rows[0]["EazypayRefNo"].ToString();
                        lblPaymentStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                        lblPaymentMode.Text = dt1.Rows[0]["PaymentMode"].ToString();
                    }
                }

                if (dt2.Rows.Count > 0)
                {
                    Div_Appointment.Visible = true;
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
                else
                {
                    Div_Appointment.Visible = false;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                if (dt3.Rows.Count > 0)
                {
                    EligibleDiv.Visible = false;
                    AvailDiv.Visible = true;
                    string ChkEligible = dt3.Rows[0]["EligibleForRebate"].ToString();
                    string ChkAvail = dt3.Rows[0]["AvailRebate"].ToString();
                    string RMApproved = dt3.Rows[0]["RMVerified"].ToString();
                    string RODate = dt3.Rows[0]["RODate"].ToString();
                    string RORemarks = dt3.Rows[0]["AllotteeRORemarks"].ToString();
                    string LeaseRegistered = dt3.Rows[0]["LeaseRegistered"].ToString();
                    string PossessionCompleted = dt3.Rows[0]["PossessionCompleted"].ToString();

                    if (RMApproved == "True")
                    {
                        RODiv.Visible = true;

                    }
                    else
                    { RODiv.Visible = false; }
                    if (ChkEligible == "True")
                    {
                        eligiblelbl.Text = "Yes";
                    }
                    else
                    {
                        eligiblelbl.Text = "No";
                    }
                    if (ChkAvail == "True")
                    {
                        lblAvail.Text = "Yes";
                    }
                    else
                    {
                        lblAvail.Text = "No";
                    }
                    if (RODate.Length > 0)
                    {
                        RODiv.Visible = false;
                        RODeatailDiv.Visible = true;
                        lblRoDate.Text = RODate;
                        lblRemarks.Text = RORemarks;
                    }
                    if (LeaseRegistered == "True")
                    {
                        Button1.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;

                    }
                    if (PossessionCompleted == "True")
                    {
                        Button2.Visible = true;
                    }
                    else
                    {
                        Button2.Visible = false;

                    }

                }
            }

        }

        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveDemandPlusObjection UC_ResolveDemandPlusObjection = LoadControl("~/UC_ResolveDemandPlusObjection.ascx") as UC_ResolveDemandPlusObjection;
            UC_ResolveDemandPlusObjection.ID = "UC_ResolveDemandPlusObjection";
            UC_ResolveDemandPlusObjection.ServiceReqNo = ServiceReqNo;
            PH_Objection.Controls.Add(UC_ResolveDemandPlusObjection);
        }
        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetailSelected(objServiceTimelinesBEL);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "Id";
                drpIndusrialArea.DataBind();
                drpIndusrialArea.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

        }


        protected void radioByPlotNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = true;
            DivFilterLetter.Visible = false;

        }

        protected void radioByAllotmentNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = false;
            DivFilterLetter.Visible = true;
        }

        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForNotices(objServiceTimelinesBEL);
                drpPlotNo.DataSource = ds;
                drpPlotNo.DataTextField = "PlotNumber";
                drpPlotNo.DataValueField = "PlotNumber";
                drpPlotNo.DataBind();
                drpPlotNo.Items.Insert(0, new ListItem("--Select--", ""));



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();
        }

        public void BindServiceCheckListGridViewDocument()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



                objServiceTimelinesBEL.ServiceTimeLines = "1001";
                objServiceTimelinesBEL.FirmType = "1";




                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetDocumentChecklistLeaseDeed(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
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
                if (radioByAllotmentNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtServiceReqNo.Text;
                    objServiceTimelinesBEL.IAName = "";
                    objServiceTimelinesBEL.PlotNo = "";

                }

                if (radioByPlotNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
                }

                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindForLeaseDeed(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    DivDoc.Visible = true;

                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    string RefNo = dt.Rows[0]["ServiceRefNo"].ToString();

                    AvailDiv.Visible = false;
                    EligibleDiv.Visible = true;
                    if (RefNo.Length > 0)
                    {
                        Response.Redirect("~/LeaseDeedApplication.aspx?ViewID=" + RefNo);
                    }
                    if (lblSIgnatoryEmail.Text.Length > 0)
                    {
                        EmailDiv.Visible = false;
                    }
                    else
                    {
                        EmailDiv.Visible = true;
                    }
                    if (lblSignatoryMobile.Text.Length > 0)
                    {
                        MobileDiv.Visible = false;
                    }
                    else
                    {
                        MobileDiv.Visible = true;
                    }

                }
                else
                {
                    DivDoc.Visible = false;
                    AllotteeDiv.Visible = false;

                }




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        protected void btnLeaseDeed_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            if (lblSIgnatoryEmail.Text == "")
            {
                if (txtemail.Text == "")
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Email ID is not with us kindly enter email id before proceeding.");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }

            }
            if (lblSignatoryMobile.Text == "")
            {
                if (txtmobile.Text == "")
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Mobile No is not with us kindly enter mobile no before proceeding.");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
            }
            int count = 0;
            foreach (GridViewRow gvrow in GridView2.Rows)
            {


                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkAck");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }

            }
            if (count < 4)
            {
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n You have to acknowledge all the documents before applying.");
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            }

            objServiceTimelinesBEL.IndustrialArea = lblIAID.Text;
            objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
            objServiceTimelinesBEL.ServiceTimeLinesID = 1001;
            objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
            objServiceTimelinesBEL.Email = txtemail.Text;
            objServiceTimelinesBEL.PhoneNumber = txtmobile.Text;
            if (StampChk1s.Checked == true)
            {
                objServiceTimelinesBEL.EligibleRebate = "1";
            }
            else
            {
                objServiceTimelinesBEL.EligibleRebate = "0";
            }
            if (AvailChk.Checked == true)
            {
                objServiceTimelinesBEL.AvailRebate = "1";
            }
            else
            {
                objServiceTimelinesBEL.AvailRebate = "0";
            }
            try
            {
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.SetServiceRequestLeaseDeed(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string RefNo = ds.Tables[0].Rows[0][0].ToString().Trim();

                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Please Keep this referrence safe for future communication with UPSIDA.");
                        var script = string.Format("alert({0});window.location ='LeaseDeedApplication.aspx?ViewId=" + RefNo + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                }
                else
                {
                    string message = "Record couldnt be  Save ";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }

        }
        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {


            decimal TotalCharges;
            DataSet dsR = new DataSet();
            DataTable dt_Fee = new DataTable();


            GeneralMethod gm = new GeneralMethod();
            string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(ServiceReqNo, "UPSIDC");


            if (TransactionId_UPSIDC == "Failed")
            {
                string Message = "Failed In Processing";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                return;
            }
            else
            {
                dsR = objServiceTimelinesBLL.GetApplicableChargesLeaseDeed(ServiceReqNo);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {

                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                    gm = new GeneralMethod();
                    string PaymentGetwayURL = gm.SendToPaymentGetwayHDFCNew(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Lease Deed", lblAllotteeName.Text, lblSIgnatoryEmail.Text, lblSignatoryMobile.Text, "One");

                    if (PaymentGetwayURL == "Failed")
                    {

                        string Message = "Errro Ocured In Processing !";

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    }
                    else
                    {
                        Response.Redirect(PaymentGetwayURL);
                    }
                }
            }
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            String js = "window.open('PaymentAck.aspx?ServiceReqNo=" + lblServiceRefNo.Text.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PaymentAck.aspx", js, true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            if (TextBox1.Text == "")
            {
                string Message = "Please Enter Appointment Date";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
            }
            if (TextBox2.Text == "")
            {
                string Message = "Please Enter Your Remarks";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
            }

            string Date = DateTime.ParseExact(TextBox1.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

            objServiceTimelinesBEL.ROAppointmentDate = Convert.ToDateTime(Date);
            objServiceTimelinesBEL.ROAllotteeRemarks = TextBox2.Text;

            try
            {
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.UpdateROAppoitmentDetails(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string RefNo = ds.Tables[0].Rows[0][0].ToString().Trim();
                        RODetailsIntimationtoAll();
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Details Appointment in Registrar Office has been saved.");
                        var script = string.Format("alert({0});window.location ='LeaseDeedApplication.aspx?ViewId=" + ServiceReqNo + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                }
                else
                {
                    string message = "Record couldnt be  Save ";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
        }

        protected void StampChk1s_CheckedChanged(object sender, EventArgs e)
        {
            if (StampChk1s.Checked == true)
            {
                RebateDiv.Visible = true;
            }
            else
            {
                RebateDiv.Visible = false;
            }
        }
        private void RODetailsIntimationtoAll()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "',1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string RMEmail = dt.Rows[0]["RMEmail"].ToString();
                    string RMNO = dt.Rows[0]["RMNO"].ToString();
                    string DAEmail = dt.Rows[0]["DAEmail"].ToString();
                    string POAEmail = dt.Rows[0]["POAEmail"].ToString();
                    string POANO = dt.Rows[0]["POAMobile"].ToString();


                    var EmailList = new List<string>();

                    // Add items to the list
                    EmailList.Add(DAEmail);
                    EmailList.Add(RMEmail);
                    EmailList.Add(POAEmail);

                    // Convert to array
                    var myArray = EmailList.ToArray();

                    foreach (string s in myArray)
                    {
                        bool Z = SendEmail(s);
                    }




                }

            }
            catch (Exception ex)
            {

            }
        }
        private bool SendEmail(string recipient)
        {
            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "',1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string Plotarea = dt.Rows[0]["TotalAllottedPlotArea"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string RMEmail = dt.Rows[0]["RMEmail"].ToString();
                    string RMNO = dt.Rows[0]["RMNO"].ToString();
                    string DAEmail = dt.Rows[0]["DAEmail"].ToString();
                    string POAEmail = dt.Rows[0]["POAEmail"].ToString();
                    string POANO = dt.Rows[0]["POAMobile"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string RODate = dt.Rows[0]["RODate"].ToString();
                    string Remarks = dt.Rows[0]["AllotteeRORemarks"].ToString();




                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(recipient);

                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                   //newmsg.IsBodyHtml = true;
                    //Attachment att = new Attachment(Server.MapPath("PDF/DocViewerMinutes.pdf"));
                    //newmsg.Attachments.Add(att);
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ROAppointmentIntimation.html"));
                    StrContent = reader.ReadToEnd();
                    StrContent = StrContent.Replace("{User}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{PlotNo}", PlotNo.Trim());
                    StrContent = StrContent.Replace("{PlotArea}", Plotarea.Trim());
                    StrContent = StrContent.Replace("{DAName}", DAName);
                    StrContent = StrContent.Replace("{ContactNo}", PhoneNo);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{IAName}", IAName);
                    StrContent = StrContent.Replace("{RODate}", RODate);
                    StrContent = StrContent.Replace("{Remarks}", Remarks);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Link}", "~/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: Intimation to all concerned officer about the appointment in the registrar office of Applicant" + ApplicantName;
                    newmsg.BodyHtml = StrContent;
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);

                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    //smtp.EnableSsl = true;
                    //smtp.Send(newmsg);


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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String js = "window.open('DocViewerPossession.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerPossession.aspx", js, true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String js = "window.open('DocViewerRegisteredLease.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerRegisteredLease.aspx", js, true);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            decimal TotalCharges;
            DataSet dsR = new DataSet();
            DataTable dt_Fee = new DataTable();

            GeneralMethod gm = new GeneralMethod();

            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            dsR = objServiceTimelinesBLL.GetApplicableChargesIAServices(objServiceTimelinesBEL);

            if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
            if (dt_Fee.Rows.Count > 0)
            {

                try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

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
                                string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                                GetApplicationDetails();
                                return;
                            }
                            else
                            {
                                string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                                GetApplicationDetails();
                                return;
                            }

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

                        }
                        else
                        {

                        }
                    }
                }


            }
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

    }


}