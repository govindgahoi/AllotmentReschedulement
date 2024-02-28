using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class AllotteePayMaintenance : System.Web.UI.Page
    {
        SqlConnection con;

        String ServiceRequestNo = "";
        String TraID = "";

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

        string emailID="";
        string phoneNo="";
        public string ViewID;
        public string App = "";
        string allotteeID = "";
        string regionalOffice = "", industrialArea = "", plotNo = "";
        public string SWCControlID = "UPSWP190821401";
        public string SWCUnitID = "UPSWP19082140122";
        public string SWCServiceID = "SC21033";
        public string SWCRequest_ID = "19082140122210030001";
        public int    serviceID   = 2000;
        public string Paid = "";
        public decimal MC ;
        public decimal INTEREST;
        public decimal INTERESTONMC;
        public decimal TotDues;
        public decimal TotInt;
        public decimal InstallmentValue;
        public decimal TotalOneTimeDues;
        public decimal rebate;
        public decimal amount;
        string serviceReqNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ControlID = "UPSWP210002975";
            //UnitID = "UPSWP21000297524";
            //ServiceID = "SC21033";
            //serviceReqNo = "SER20211223/2000/4934/32249";
            ////string amount = "137124.00";
            //Request_ID = "21000297524210330001";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            try
            {
                ServiceRequestNo = Request.QueryString["ServiceID"];
                TraID = Request.QueryString["TraID"];
                ViewID = Request.QueryString["ViewID"];
                App = Request.QueryString["App"];

                if (Request.Form["TxtControlID"] != null)
                {
                    ViewState["ControlID"] = Request.Form["TxtControlID"];
                    ViewState["UnitID"] = Request.Form["TxtUnitID"];
                    ViewState["ServiceID"] = Request.Form["TxtServiceID"];
                    ViewState["ProcessIndustryID"] = Request.Form["TxtProcessIndustryID"];
                    ViewState["ApplicationID"] = Request.Form["TxtApplicationID"];
                    ViewState["Request_ID"] = Request.Form["TxtRequestID"];
                    ViewState["Allotmentletterno"] = "";
                }

                if (ViewState["ControlID"] != null)
                {
                    ControlID = ViewState["ControlID"].ToString().Trim();
                    UnitID = ViewState["UnitID"].ToString().Trim();
                    ServiceID = ViewState["ServiceID"].ToString().Trim();
                    ProcessIndustryID = ViewState["ProcessIndustryID"].ToString().Trim();
                    ApplicationID = ViewState["ApplicationID"].ToString().Trim();
                    Request_ID = ViewState["Request_ID"].ToString().Trim();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //ViewState["ControlID"] = "UPSWP210002975";
            serviceID = 2000;
            payPanel.Visible = false;
            installPanel.Visible = false;
            panel1.Visible = false;
            //btnpay.Visible = false;
            //btnOffline.Visible = false;
            Button1.Enabled = false;
            panelOneTime.Visible = false;
            btnBack.Visible = false;
            PanelPayMode.Visible = false;
            PanelUTR.Visible = false;
            //
            Page.Form.Enctype = "multipart/form-data";
            try
            {
                isDownPaymentPaid(UnitID);
                if (!IsPostBack)
                {
                    //txtUTR.Text = "";
                    //txtBankName.Text = "";
                    //txtDate.Text = "";
                    //CheckBox1.Checked = false;
                    if (ViewState["ControlID"] != null)
                    {
                        BindAllotteeStatus(ControlID, UnitID, ServiceID, Request_ID);
                        lbllauchedmsg.Visible = false;
                    }
                    else
                    {
                        SideDiv.Visible = false;
                        lbllauchedmsg.Visible = true;
                    }
                    
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void BindAllotteeStatus(string controlId,string unitId,string serviceId, string reqId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where ControlID='"+ controlId + "' and UnitID='"+ unitId + "' and ServiceID='"+serviceId+"'", con);
                
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0) 
                {
                    if(Convert.ToBoolean(dt.Rows[0]["OneTimeEditScheme"]) == true)
                    {
                        linkEdit.Visible = false;

                    }
                    else
                    {
                        linkEdit.Visible = true;
                    }
                    if (Convert.ToInt32(dt.Rows[0]["SchemeType"]) == 1)
                    {
                        panelTable.Visible = true; ;
                        string DateOfApplication= Convert.ToDateTime(dt.Rows[0]["ApplicationDate"]).ToString("dd/MM/yyyy");
                        lblApplicationDate.Text = DateOfApplication;
                        lblpaymentType.Text = "Instalment-wise";
                        lblDues.Text = Math.Round(( Convert.ToDecimal(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"] )),2).ToString();
                        lblWvr.Text= Math.Round((Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"]) / 2),2).ToString();
                        lblpayableamnt.Text= Math.Round((Convert.ToDecimal(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"])/2), 2).ToString();
                        lbl1.Text = "Payable Amount as on " + Convert.ToDateTime(dt.Rows[0]["ApplicationDate"]).ToString("dd/MM/yyyy") + " :";
                        lbl25.Text = dt.Rows[0]["DownPayment"].ToString();
                        intlDate1.Text= Convert.ToDateTime(dt.Rows[0]["DueDate-1"]).ToString("dd/MM/yyyy");
                        intlDate2.Text= Convert.ToDateTime(dt.Rows[0]["DueDate-2"]).ToString("dd/MM/yyyy");
                        intlDate3.Text= Convert.ToDateTime(dt.Rows[0]["Duedate-3"]).ToString("dd/MM/yyyy");
                        
                        status1.Text= (String.IsNullOrEmpty(dt.Rows[0]["TransactionDate-1"].ToString())) ? "Pending" : "Paid";
                        status2.Text= (String.IsNullOrEmpty(dt.Rows[0]["TransactionDate-2"].ToString())) ? "Pending" : "Paid";
                        status3.Text= (String.IsNullOrEmpty(dt.Rows[0]["TransactionDate-3"].ToString())) ? "Pending" : "Paid";
                        instl1.Text= dt.Rows[0]["Installment-1"].ToString();
                        instl2.Text= dt.Rows[0]["Installment-2"].ToString();
                        instl3.Text= dt.Rows[0]["Installment-3"].ToString();
                        if (dt.Rows[0]["Status_For_Instalment"].ToString() == "Ineligible")
                        {
                            switch (dt.Rows[0]["Flag"].ToString())
                            {
                                case "1":
                                    status1.Text = "Ineligible";
                                    status2.Text = "Ineligible";
                                    status3.Text = "Ineligible";
                                    instl1.Text = "";
                                    instl2.Text="";
                                    instl3.Text="";
                                    btnviewStatus.Visible = false;
                                    break;
                                case "2":
                                    status1.Text = "Ineligible";
                                    status2.Text = "Ineligible";
                                    status3.Text = "Ineligible";
                                    instl1.Text = "";
                                    instl2.Text = "";
                                    instl3.Text = "";
                                    btnviewStatus.Visible = false;
                                    break;
                                case "3":
                                    status2.Text = "Ineligible";
                                    status3.Text = "Ineligible";
                                    instl2.Text = "";
                                    instl3.Text = "";
                                    btnviewStatus.Visible = false;
                                    break;
                                case "4":
                                    status3.Text = "Ineligible";
                                    instl3.Text = "";
                                    btnviewStatus.Visible = false;
                                    break;

                            }
                        }
                        isDownPaymentPaid(unitId);
                    }
                    else
                    {
                        panelTable.Visible = false;
                        string DateOfApplication = Convert.ToDateTime(dt.Rows[0]["ApplicationDate"]).ToString("dd/MM/yyyy");
                        lblApplicationDate.Text = DateOfApplication;
                        lblpaymentType.Text = "One Time Payment";
                        lblDues.Text = Math.Round((Convert.ToDecimal(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"])), 2).ToString();
                        lblWvr.Text = Math.Round((Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"]) / 2), 2).ToString();
                        lblpayableamnt.Text = Math.Round((Convert.ToDecimal(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDecimal(dt.Rows[0]["InterestOnMCUpto"]) / 2), 2).ToString();
                        lbl1.Text = "Payable Amount as on " + Convert.ToDateTime(dt.Rows[0]["ApplicationDate"]).ToString("dd/MM/yyyy") + " :";
                        isDownPaymentPaid(unitId);
                    }
                    AllotteeMaintenanceDetain.Visible = false;
                   
                    FilterDiv.Visible = false;
                    //Panel2.Visible = true;
                }
                else
                {
                    panelTable.Visible = false;
                    PanelApplied.Visible = false;
                    btnfind.Visible = true;
                    payableAmount.Visible = false;
                    AllotteeMaintenanceDetain.Visible = false;
                   // Panel2.Visible = false;
                    bindIndustrialAreaDetail();
                    BindLandUse();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void PaymentSchemeEdit_click(object sender, EventArgs e)
        {
            lblConfirmation.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
        }
        protected void OptionSelect_click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                btnschemeChange.Visible = true;
            }else if (RadioButton2.Checked == true)
            {
                lblConfirmation.Visible = false;
                RadioButton1.Visible = false;
                RadioButton2.Visible = false;
                btnschemeChange.Visible = false;
            }
        }
        protected void PaymentSchemeChange_click(object sender, EventArgs e)
        {
            lblConfirmation.Visible = false;
            
            DataTable dt = new DataTable();
            if (lblpaymentType.Text== "Instalment-wise")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update OTS_NMSWPTransactionDetail set SchemeType=0, DownPayment=(MaintenanceCharge+InterestOnMCUpto/2), OneTimeEditScheme=1 where ControlID='" + ControlID + "' and UnitID='" + UnitID + "' and ServiceID='" + ServiceID + "' and RequestID='" + Request_ID + "'", con);
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    
                    lblConfirmation.Visible = false;
                    RadioButton1.Visible = false;
                    RadioButton2.Visible = false;
                    btnschemeChange.Visible = false;
                    linkEdit.Visible = false;
                    PaymentFeeNMStatusInstalmentSchemeChange(Request_ID);
                    
                    
                }
                catch(Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal server error');", true);
                }
            }
            else if(lblpaymentType.Text == "One Time Payment")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update OTS_NMSWPTransactionDetail set SchemeType=1, DownPayment=(MaintenanceCharge+InterestOnMCUpto/2)/4, OneTimeEditScheme=1 where ControlID='" + ControlID + "' and UnitID='" + UnitID + "' and ServiceID='" + ServiceID + "' and RequestID='" + Request_ID + "'", con);
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                   
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Scheme has been changed successfully');", true);
                    lblConfirmation.Visible = false;
                    RadioButton1.Visible = false;
                    RadioButton2.Visible = false;
                    btnschemeChange.Visible = false;
                    linkEdit.Visible = false;
                    PaymentFeeNMStatusOnSchemeChange(Request_ID);
                    
                    

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal server error');", true);
                }
            }
            else
            {

            }
            
        }
        protected void PaymentFeeNMStatusOnSchemeChange(string Request_ID)
        {
            DataTable dtNM = new DataTable();
            SqlCommand cmdNM= new SqlCommand("select * from OTS_NMSWPTransactionDetail where RequestID='"+ Request_ID + "'", con);
            SqlDataAdapter sdaNM = new SqlDataAdapter(cmdNM);
            sdaNM.Fill(dtNM);
            if (dtNM.Rows.Count > 0)
            {
                amount = Convert.ToDecimal(dtNM.Rows[0]["DownPayment"]);
                string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
                if (NMSWP_Result == "SUCCESS")
                {
                    BindAllotteeStatus(ControlID, UnitID, ServiceID, Request_ID);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Scheme has been changed successfully');", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("Update OTS_NMSWPTransactionDetail set SchemeType=0, DownPayment=(MaintenanceCharge+InterestOnMCUpto/2), OneTimeEditScheme=1 where ControlID='" + ControlID + "' and UnitID='" + UnitID + "' and ServiceID='" + ServiceID + "' and RequestID='" + Request_ID + "'", con);
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    BindAllotteeStatus(ControlID, UnitID, ServiceID, Request_ID);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment is aleady in process. So Payment Scheme can not be changed');", true);
                }
            }
        }
        protected void PaymentFeeNMStatusInstalmentSchemeChange(string Request_ID)
        {
            DataTable dtNM = new DataTable();
            SqlCommand cmdNM = new SqlCommand("select * from OTS_NMSWPTransactionDetail where RequestID='" + Request_ID + "'", con);
            SqlDataAdapter sdaNM = new SqlDataAdapter(cmdNM);
            sdaNM.Fill(dtNM);
            if (dtNM.Rows.Count > 0)
            {
                amount = Convert.ToDecimal(dtNM.Rows[0]["DownPayment"]);
                string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
                if (NMSWP_Result == "SUCCESS")
                {
                    BindAllotteeStatus(ControlID, UnitID, ServiceID, Request_ID);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Scheme has been changed successfully');", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("Update OTS_NMSWPTransactionDetail set SchemeType=1, DownPayment=(MaintenanceCharge+InterestOnMCUpto/2)/4, OneTimeEditScheme=1 where ControlID='" + ControlID + "' and UnitID='" + UnitID + "' and ServiceID='" + ServiceID + "' and RequestID='" + Request_ID + "'", con);
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    BindAllotteeStatus(ControlID, UnitID, ServiceID, Request_ID);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment is aleady in process. So Payment Scheme can not be changed');", true);
                }
            }
        }
        private void bindIndustrialAreaDetail()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            string UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[usp_GetActiveIA]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "IAName";
                drpIndusrialArea.DataBind();
                ListItem liIArea = new ListItem("--Select All--", "-1");
                drpIndusrialArea.Items.Insert(0, liIArea);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
           
        }
        private void BindLandUse()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetPlotStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                drpPlotType.DataSource = ds.Tables[4];
                drpPlotType.DataTextField = "UseZone";
                drpPlotType.DataValueField = "Id";
                drpPlotType.DataBind();
                drpPlotType.SelectedValue = "2";
                drpPlotType.Enabled = false;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
           
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        protected void text_Change(object sender, EventArgs e)
        {
            btnfind.Visible = true;
        }
        protected void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtInterest = isInterestNullOrZero(txtsearch.Text.Trim(), drpIndusrialArea.SelectedItem.Text.Trim());
                if (dtInterest.Rows.Count > 0)
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Incomplete Details.");
                    var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                    return;
                }
                if (ViewState["ControlID"] == null)
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Control ID is not define.");
                    var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                    return;
                }
                if (drpIndusrialArea.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtsearch.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your plot number');", true);
                    return;
                }
                if (drpPlotType.SelectedValue != "2")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The Service for selected plot type will be available soon.');", true);
                    return;
                }
                    string Service = "";
                DataTable dst1 = new DataTable();
                dst1 = isAlreadyapplied(txtsearch.Text.Trim(), drpIndusrialArea.SelectedItem.Text.Trim());
                if (dst1.Rows.Count > 0)
                {
                    SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end ,case when isnull(AllotteeName,'')>'' then AllotteeName else CompanyName end,AllotteeID,case when isnull(PhoneNo,'')>'' then PhoneNo else SignatoryPhone end from AllotteeMaster  where IndustrialArea='" + drpIndusrialArea.SelectedItem.Text.Trim() + "' and PlotNo='" + txtsearch.Text.Trim().Replace("'", "''") + "' and IsCompleted=1 and exists(select * from PlotMaster where IAID=(select ID from industrialArea where IAName= '" + drpIndusrialArea.SelectedItem.Text.Trim() + "') and PlotNumber='" + txtsearch.Text.Trim().Replace("'", "''") + "' and landuseCode='" + drpPlotType.SelectedValue.Trim() + "')", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string EmailID = dt.Rows[0][0].ToString().Trim();
                        string AllotteeName = dt.Rows[0][1].ToString().Trim();
                        string AllotteeID = dt.Rows[0][2].ToString().Trim();
                        string PhoneNo = dt.Rows[0][3].ToString().Trim();

                        if (EmailID.Length <= 0 && PhoneNo.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID & Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        if (EmailID.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        if (PhoneNo.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match = regex.Match(EmailID);
                        if (match.Success)
                        {

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid email id found on your record. Kindly contact concern regional office.');", true);
                            return;
                        }

                        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
                        string numbers = "1234567890";


                        string characters = numbers;
                        int length = 5;
                        string otp = string.Empty;
                        for (int i = 0; i < length; i++)
                        {
                            string character = string.Empty;
                            do
                            {
                                int index = new Random().Next(0, characters.Length);
                                character = characters.ToCharArray()[index].ToString();
                            } while (otp.IndexOf(character) != -1);
                            otp += character;
                        }
                        //MailAddress mailfrom = new MailAddress("eodbtestingupsidc@gmail.com");
                        //MailAddress mailfrom = new MailAddress("doorcliq@gmail.com");
                        MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                        MailAddress mailto = new MailAddress(EmailID);
                        MailMessage newmsg = new MailMessage(mailfrom, mailto);

                        newmsg.IsBodyHtml = true;

                        string StrContent = "";
                        StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                        StrContent = reader.ReadToEnd();

                        StrContent = StrContent.Replace("{UserName}", AllotteeName.Trim());
                        StrContent = StrContent.Replace("{OTP}", otp.Trim());
                        StrContent = StrContent.Replace("{Service}", Service);


                        newmsg.Subject = "UPSIDAeService: OTP verification for applying UPSIDA services";
                        newmsg.Body = StrContent;


                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        //SmtpClient smtp = new SmtpClient("smtp.upsidc.com", 25);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                        //smtp.Credentials = new System.Net.NetworkCredential("fizy2k7@gmail.com", "ahmadi@786");

                        smtp.EnableSsl = true;
                        smtp.Send(newmsg);


                        //String message = HttpUtility.UrlEncode("Dear " + AllotteeName + " OTP for " + Service + " is " + otp + "");
                        //string s = SendOTP("OTP", PhoneNo, AllotteeName, message);

                        int UserId = Convert.ToInt32(AllotteeID);
                        string emailID = EmailID;
                        string OTP = otp;
                        SWCUnitID = SWCUnitID.Trim();
                        SWCServiceID = SWCServiceID.Trim();


                        int result = SaveOTPIAServicesNMSWP(UserId, emailID, OTP, SWCControlID, SWCUnitID, SWCServiceID);
                        if (result > 0)
                        {

                            string input = EmailID.Trim();
                            string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                            string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                            string Output2 = Regex.Replace(PhoneNo, @"\d(?!\d{0,3}$)", "X");
                            //string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + "timer(120);. Kindly verify OTP for the submission of your application";
                            string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + ". Kindly verify OTP for the submission of your application";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            DivOTP.Visible = true;
                            btnfind.Text = "Resend OTP";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:timer(120);", true);
                            return;

                        }
                        else
                        {
                            string message1 = "Unable To send OTP Kindly Update your EmailID";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            DivOTP.Visible = false;
                            btnfind.Text = "Find";
                            return;
                        }
                    }
                    else
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details');", true);
                        DivOTP.Visible = false;
                        btnfind.Text = "Find";
                        return;
                    }

                }
                else
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n You have already applied for the same plot.");
                    var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                }
                    
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('alpha beta gamma');", true);
                Response.Write("Oops! error occured Exception :" + ex.Message.ToString());
                DivOTP.Visible = false;
                btnfind.Text = "Find";
                return;
            }
        }
        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpIndusrialArea.SelectedIndex == 0)
            {
                


            }
            else
            {
               
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
        public Int32 SaveOTPIAServicesNMSWP(Int32 UserId, string emailID, string OTP, string SWCControlID, string SWCUnitID, string SWCServiceID)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_SaveOTPIAService]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@USERID", UserId);
                cmd.Parameters.AddWithValue("@EmailID", emailID);
                cmd.Parameters.AddWithValue("@OTP", OTP);
                cmd.Parameters.AddWithValue("@ControlID", SWCControlID);
                cmd.Parameters.AddWithValue("@UnitID", SWCUnitID);
                cmd.Parameters.AddWithValue("@ServiceID", SWCServiceID);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details  "+ex+"');", true);
                return 0;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpIndusrialArea.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtsearch.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your Plot Number');", true);
                    return;
                }
                if (txtOTP.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your OTP');", true);
                    return;
                }


                string OTP = txtOTP.Text.Trim();
                DataSet dsR = new DataSet();


                dsR = VerifyOTPIAService(OTP, SWCControlID, SWCUnitID, SWCServiceID);
                DataTable dtt = new DataTable();
                dtt = dsR.Tables[0];

                if (dtt.Rows.Count > 0)
                {
                    string message = dtt.Rows[0]["message"].ToString();
                    string status = dtt.Rows[0]["status"].ToString();

                    if (status == "2")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        AllotteeMaintenanceDetain.Visible = true;
                        FilterDiv.Visible = false;
                        GetApplicantDetails();
                        return;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid OTP. Kindly Recheck It');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        protected void GetApplicantDetails()
        {
           
            DataSet ds = new DataSet();
            
            try
            {
                string IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                string PlotNo = txtsearch.Text.Trim();
               // IsComplaintRaised(IAName, PlotNo);
                ds = GetAllotteeRecordToBindForOTSScheme(PlotNo, IAName);
                
                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];
                    //AllotteeDiv.Visible = true;
                    allotteeID= dt1.Rows[0]["AllotteeID"].ToString();
                    lblregion.Text = dt1.Rows[0]["RegionalOffice"].ToString();
                    lblIA.Text = dt1.Rows[0]["IAName"].ToString();
                    LblPlot.Text = dt1.Rows[0]["PlotNo"].ToString();
                    lblallotteeName.Text = dt1.Rows[0]["AllotteeName"].ToString();

                    MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);

                    lblMaintenanceCharge.Text = (Convert.ToDouble(MC)<0) ? "0.00" : MC.ToString();

                    INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                    string IntDues = (Convert.ToDouble(INTEREST)<0) ? "0.00" : INTEREST.ToString();

                    INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                    string IntOnMCDues = (Convert.ToDouble(INTERESTONMC)<0) ? "0.00" : INTERESTONMC.ToString();
                    //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                    TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                    TotInt = Math.Round((decimal)TotInt, 2);

                    lblInterest.Text = TotInt.ToString() + " /-";

                    TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(lblMaintenanceCharge.Text);
                    TotDues = Math.Round((decimal)TotDues, 2);
                    lblTotalDues.Text = TotDues.ToString() + " /-";

                    rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                    rebate = Math.Round((decimal)rebate, 2);
                    lblRebate.Text = rebate.ToString() + " /-";
                    TotalOneTimeDues = (TotDues - rebate);
                    lblPayAmount.Text = (TotDues - rebate).ToString() + " /-";

                    lblQueryPayAmount.Text = (TotDues - rebate).ToString();
                    lblTobePaid.Text = (TotDues - rebate).ToString() + " /-";

                    InstallmentValue = (TotDues - rebate) / 4;
                    InstallmentValue = Math.Round((decimal)InstallmentValue, 2);
                    lblInst.Text = InstallmentValue.ToString() + " /-";
                    lblIns1.Text = InstallmentValue.ToString() + " /-";
                    lblIns2.Text = InstallmentValue.ToString() + " /-";
                    lblIns3.Text = InstallmentValue.ToString() + " /-";
                    if (Convert.ToInt32(dt2.Rows[0]["Dues"]) >0 || Convert.ToInt32(dt2.Rows[0]["TotalInterest"]) > 0 || Convert.ToInt32(dt2.Rows[1]["Dues"]) > 0)
                    {
                    }
                    else
                    {
                        TnC.Visible = false;
                        payPanel.Visible = false;
                       // btnQuery.Enabled = false;
                    }

                    //FilterDiv.Visible = false;

                }
                else
                {
                    TnC.Visible = false;
                    payPanel.Visible = false;
                   // btnQuery.Enabled = false;
                    //AllotteeDiv.Visible = false;
                    string msg = "Invalid Details";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.Message + "');", true);
            }
        }
        private DataTable IsComplaintRaised(string IndustrialArea, string PlotNo)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //string Comp =""; 
                //string emailID = ""; 
                DataTable dtc = new DataTable();

                SqlCommand cmd = new SqlCommand("select * from tbl_OTSDetail where IAName = @IndustrialArea and PlotNo=@PlotNo and Status='Pending'", con);
                
                    cmd.Parameters.AddWithValue("@IndustrialArea", IndustrialArea);
                    cmd.Parameters.AddWithValue("@PlotNo", PlotNo);
                    SqlDataAdapter dr=new SqlDataAdapter(cmd);
                    dr.Fill(dtc);
                    return dtc;
                   
                
            }
        }
        protected DataSet GetAllotteeRecordToBindForOTSScheme(string plotNo,string IndustrialArea)
        {  
           DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Plot_OTSDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlotNo", plotNo);
                cmd.Parameters.AddWithValue("@IndustrialArea", IndustrialArea);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet VerifyOTPIAService(string OTP, string SWCControlID, string SWCUnitID, string SWCServiceID)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_chechOTPIAService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OTP", OTP);
                cmd.Parameters.AddWithValue("@ControlID", SWCControlID);
                cmd.Parameters.AddWithValue("@UnitID", SWCUnitID);
                cmd.Parameters.AddWithValue("@ServiceID", SWCServiceID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 6 || DropDownList1.SelectedIndex==7)
            {
               // fLoad.Visible = true;
                payPanel.Visible = false;
                //btnpay.Visible = false;
                QueryInfo.Visible = false;
                payableAmount.Visible = true;
                TnC.Visible = false;
               // btnQuery.Visible = false;
                btnBack.Visible = true;
            }
            else
            {
               // fLoad.Visible = false;
                payPanel.Visible = false;
                //btnpay.Visible = false;
                QueryInfo.Visible = false;
                payableAmount.Visible = true;
                TnC.Visible = false;
               // btnQuery.Visible = false;
                btnBack.Visible = true;
            }
        }
        protected void CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                payableAmount.Visible = false;
                Button1.Enabled = true;
                payPanel.Visible = false;
                //btnpay.Visible = false;
            }
            else
            {
                payableAmount.Visible = false;
                Button1.Enabled = false;
                payPanel.Visible = false;
                //btnpay.Visible = false;
            }
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioInstallment.Checked == true)
            {
                payPanel.Visible = true;
                installPanel.Visible = true;
                panel1.Visible = true;
                payableAmount.Visible = false;
                PanelPayMode.Visible = true;
                RadioOnline.Checked = false;
                RadioOffline.Checked = false;
            }
            else
            {
                payPanel.Visible = true;
                installPanel.Visible = false;
                panel1.Visible = false;
                payableAmount.Visible = false;
            }
            if (RadioOneTime.Checked == true)
            {
                panelOneTime.Visible = true;
                payableAmount.Visible = false;
                PanelPayMode.Visible = true;
                RadioOnline.Checked = false;
                RadioOffline.Checked = false;
            }
            else
            {
                panelOneTime.Visible = false;
                payableAmount.Visible = false;
            }
        }
        protected void RadioButton_CheckedPayMD(object sender, EventArgs e)
        {
            if (RadioOnline.Checked == true)
            {
                //btnpay.Visible = true;
                //btnOffline.Visible = false;
                if (RadioOneTime.Checked == true)
                {
                    payPanel.Visible = true;
                    RadioOneTime.Visible = true;
                    RadioInstallment.Visible = true;
                    panelOneTime.Visible = true;
                    payableAmount.Visible = false;
                    PanelPayMode.Visible = true;
                    PanelUTR.Visible = false;
                }
                if (RadioInstallment.Checked == true)
                {
                    payPanel.Visible = true;
                    installPanel.Visible = true;
                    panel1.Visible = true;
                    payableAmount.Visible = false;
                    PanelPayMode.Visible = true;
                    PanelUTR.Visible = false;
                }

            }
            else
            {
                //btnOffline.Visible = false;
                //btnpay.Visible = false;
            }
            if (RadioOffline.Checked == true)
            {
                //btnOffline.Visible = true;
                //btnpay.Visible = false;
                if (RadioOneTime.Checked == true)
                {
                    payPanel.Visible = true;
                    panelOneTime.Visible = true;
                    payableAmount.Visible = false;
                    PanelPayMode.Visible = true;
                    PanelUTR.Visible = true;
                }
                if (RadioInstallment.Checked == true)
                {
                    payPanel.Visible = true;
                    installPanel.Visible = true;
                    panel1.Visible = true;
                    payableAmount.Visible = false;
                    PanelPayMode.Visible = true;
                    PanelUTR.Visible = true;
                }
            }
            else
            {
                //btnOffline.Visible = false;
            }
        }
        protected void Click_Proceed(Object sender, EventArgs e)
        {
            payPanel.Visible = true;
            //btnpay.Visible = false;
            CheckBox1.Enabled = false;
            payableAmount.Visible = false;
        }
        protected void Click_Query(Object sender, EventArgs e)
        {
            payPanel.Visible = false;
            //btnpay.Visible = false;
            QueryInfo.Visible = false;
            payableAmount.Visible = true;
            TnC.Visible = false;
           // btnQuery.Visible = false;
            btnBack.Visible = true;

        }
        protected void Click_Back(Object sender, EventArgs e)
        {
            //payPanel.Visible = true;
            // btnpay.Visible = true;
            CheckBox1.Enabled = true;
            CheckBox1.Checked = false;
            RadioOneTime.Checked = false;
            RadioInstallment.Checked = false;
            RadioOnline.Checked = false;
            RadioOffline.Checked = false;
            QueryInfo.Visible = true;
            payableAmount.Visible = false;
            TnC.Visible = true;
           // btnQuery.Visible = true;
            btnBack.Visible = false;
            payableAmount.Visible = false;
            txtDescription.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
        protected void click_ComSubmit(Object sender, EventArgs e)
        {
            btnBack.Visible = true;
            industrialArea = lblIA.Text;
            regionalOffice = lblregion.Text;
            plotNo = LblPlot.Text;
            string description = txtDescription.Text;
            string complaint = DropDownList1.SelectedItem.Text;
            string AllotteeName = lblallotteeName.Text;
            if (description.Length < 20 || DropDownList1.SelectedIndex==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please fill all Mandatory Fields properly.');", true);
                return;
            }
            else
            {
                if (complaint == "Already Deposited" || complaint == "Disputed due to Court Case")
                {
                    DataTable DT = GrievanceSubmitted(AllotteeName, complaint, description);
                    try
                    {
                        if (DT.Rows.Count > 0)
                        {
                            string comId = DT.Rows[0]["ComplaintID"].ToString();
                            bool fg = Upload(comId);
                            if (fg == true)
                            {
                                //DivOTP.Visible = false;
                                FilterDiv.Visible = false;
                                AllotteeMaintenanceDetain.Visible = true;
                                btnSubmit.Enabled = false;
                                txtDescription.Text = "";
                                DropDownList1.SelectedIndex = 0;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + comId + "');", true);
                                MailToAllottee(DT);
                                MailToRM(DT);
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
                            }
                        }
                    }
                    catch
                    {
                        FilterDiv.Visible = false;
                        btnSubmit.Enabled = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
                    }
                }
                else {
                    DataTable DT = GrievanceSubmitted(AllotteeName, complaint, description);
                    try
                    {
                        if (DT.Rows.Count > 0)
                        {

                            string comId = DT.Rows[0]["ComplaintID"].ToString();
                            if (FileUpload1.HasFile)
                            {
                                bool fg = Upload(comId);
                            }
                            
                            //DivOTP.Visible = false;
                            FilterDiv.Visible = false;
                            AllotteeMaintenanceDetain.Visible = true;
                            btnSubmit.Enabled = false;
                            txtDescription.Text = "";
                            DropDownList1.SelectedIndex = 0;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + comId + "');", true);
                            MailToAllottee(DT);
                            MailToRM(DT);
                        }
                    }
                    catch
                    {
                        FilterDiv.Visible = false;
                        btnSubmit.Enabled = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
                    }
                }
            }
        }
        protected void MailToAllottee(DataTable data)
        {
            string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = data.Rows[0]["AllotteeName"].ToString();
            string allotteeID = data.Rows[0]["AllotteeID"].ToString();
            string emailID = detailOfAllotteeForMail(allotteeID);
            MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
            MailAddress mailto = new MailAddress(emailID);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);

            newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("~/OTSAllotteeSubmissionMail.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
            StrContent = StrContent.Replace("{ComplaintID}", complaintId);


            newmsg.Subject = "Complaint ID '"+ complaintId + "' Logged Regarding Maintenance Dues (OTS)";
            newmsg.Body = StrContent;


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
            
            smtp.EnableSsl = true;
            smtp.Send(newmsg);
        }
        protected void MailToAllotteeAfterApplied(DataTable data)
        {
           // string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = data.Rows[0]["AllotteeName"].ToString();
            string allotteeID = data.Rows[0]["AllotteeID"].ToString();
            string emailID = detailOfAllotteeForMail(allotteeID);
            MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
            MailAddress mailto = new MailAddress(emailID);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);

            newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("~/OTSAfterAppliedScheme.html"));
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
        protected void MailToRM(DataTable data)
        {
            string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = data.Rows[0]["AllotteeName"].ToString();
            string ComplaintID = data.Rows[0]["ComplaintID"].ToString();
            string ComplaintDescription = data.Rows[0]["ComplaintDescription"].ToString();
            string AllotteeComment = data.Rows[0]["AllotteeComment"].ToString();
            string regionalOffice = data.Rows[0]["RegionalOffice"].ToString();
            string DateOfComplaint = DateTime.Now.ToString("dd/MM/yyyy");

            string emailID = detailOfRMForMail(regionalOffice);
            MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
            MailAddress mailto = new MailAddress(emailID);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);

            newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("~/OTSSubmissionMailToRM.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
            StrContent = StrContent.Replace("{ComplaintID}", ComplaintID);
            StrContent = StrContent.Replace("{CurrentDate}", DateOfComplaint);
            StrContent = StrContent.Replace("{Description}", AllotteeComment);
            StrContent = StrContent.Replace("{ComplaintDescription}", ComplaintDescription);


            newmsg.Subject = "Complaint ID '"+ complaintId + "' Logged Regarding Maintenance Dues (OTS)";
            newmsg.Body = StrContent;


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //SmtpClient smtp = new SmtpClient("smtp.upsidc.com", 25);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
            //smtp.Credentials = new System.Net.NetworkCredential("fizy2k7@gmail.com", "ahmadi@786");
            smtp.EnableSsl = true;
            smtp.Send(newmsg);
        }
        protected DataTable GrievanceSubmitted(string AllotteeName, string complaint, string description)
        {
            try {
                SqlCommand cmd = new SqlCommand("usp_SetOTSService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlotNo", plotNo);
                cmd.Parameters.AddWithValue("@IndustrialArea", industrialArea);
                cmd.Parameters.AddWithValue("@serviceID", serviceID);
                cmd.Parameters.AddWithValue("@regionalOffice", regionalOffice);
                cmd.Parameters.AddWithValue("@AllotteeName", AllotteeName);
                cmd.Parameters.AddWithValue("@complaint", complaint);
                cmd.Parameters.AddWithValue("@AllotteeComment", description);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
            }
        }
        protected bool Upload(string id)
        {
            bool flag = false;
            if (FileUpload1.HasFile)
            {
                
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string contentType = FileUpload1.PostedFile.ContentType;
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string query = "update tbl_OTSDetail set ContentType=@ContentType, Document= @Data where ComplaintID=@ComplaintID";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@ComplaintID", id);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                               int count= cmd.ExecuteNonQuery();
                                con.Close();
                                if (count > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                        }
                    }
                }
                return flag;
            }
            else
            {
                return flag;
                //Mention Alert msg for File not uploaded
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        protected string detailOfRMForMail(string RO)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand("select emailID,usm.UserName from UPSIDCUser U join userAssociationMaster usm on usm.userId = U.UserID where RegionalOffice = '"+ RO + "' and level = 'RM' and ActiveStatus = 1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

                return dt.Rows[0][0].ToString().Trim();
            }

            catch (Exception ex)
            {
                throw ex;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
            }

        }
        protected string detailOfAllotteeForMail(string AllotteeID)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end from AllotteeMaster  where AllotteeID='" + AllotteeID + "' and PlotNo='" + txtsearch.Text.Trim().Replace("'", "''") + "' and IsCompleted=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);
               
                return dt.Rows[0][0].ToString().Trim();
            }
            
            catch(Exception ex)
            {
                throw ex;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
            }

        }
        private void NiveshMitra()
        {
            if (ControlID.Length > 0)
            {
                try
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet ds = webService.WGetBasicDetails(ControlID, UnitID, ServiceID, "", passsalt);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        emailID = dt.Rows[0]["Occupier_Email_ID"].ToString();
                        phoneNo = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Something Went Wrong With Nivesh Mitra Server');", true);
                    return;
                }
            }
        }
        protected void Apply_Click(object sender, EventArgs e)
        {
            //btnpay.Enabled = false;
            string Contact = "";
            string Email = "";
            int SchemeType = -1;
            //ControlID = "UPSWP210002975";
            //Request_ID = "21000297503210330001";
            //UnitID = "UPSWP21000297503";
            //ServiceID = "SC21033";

            if (ViewState["ControlID"] == null)
            {
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Control ID is not define.");
                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                return;
            }
            DataSet ds = new DataSet();
            ds = GetAllotteeRecordToBindForOTSScheme(txtsearch.Text.Trim(), drpIndusrialArea.SelectedItem.Text.Trim());

            if (ds.Tables.Count > 0)
            {
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                //AllotteeDiv.Visible = true;
                allotteeID = dt1.Rows[0]["AllotteeID"].ToString();

                MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);

                INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                string IntDues = (Convert.ToDouble(INTEREST) < 0) ? "0.00" : INTEREST.ToString();

                INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                string IntOnMCDues = (Convert.ToDouble(INTERESTONMC) < 0) ? "0.00" : INTERESTONMC.ToString();
                //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                TotInt = Math.Round((decimal)TotInt, 2);

                TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(lblMaintenanceCharge.Text);
                TotDues = Math.Round((decimal)TotDues, 2);

                rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                rebate = Math.Round((decimal)rebate, 2);
                TotalOneTimeDues = (TotDues - rebate);
                InstallmentValue = (TotDues - rebate) / 4;
                InstallmentValue = Math.Round((decimal)InstallmentValue, 2);
            }
            else
            {
                RadioOneTime.Checked = false;
                RadioInstallment.Checked = false;
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n You have already applied for the same plot.");
                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
            }
            if (RadioOneTime.Checked == true)
            { SchemeType = 0; amount = TotalOneTimeDues; }
            else if (RadioInstallment.Checked == true)
            { SchemeType = 1; amount = InstallmentValue; }
            else { SchemeType = -1; }

            if (SchemeType != -1)
            {
                DataTable dts = IsComplaintRaised(drpIndusrialArea.SelectedItem.Text.Trim(), txtsearch.Text.Trim());
                if (dts.Rows.Count > 0)
                {
                    if (allotteeID != null || allotteeID != "")
                    {
                        DataSet dst1 = SetServiceRequestForOTS(allotteeID, MC, INTEREST, TotInt, SchemeType, InstallmentValue, amount, ControlID, UnitID, ServiceID, Request_ID, rebate);
                        if (dst1.Tables.Count > 0)
                        {
                            if (dst1.Tables[0].Rows.Count > 0)
                            {
                                //btnpay.Enabled = false;

                                string RefNo = dst1.Tables[0].Rows[0][0].ToString().Trim();

                                string[] SerArray = RefNo.Split('/');
                                int Service = int.Parse(SerArray[1]);
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                                MailToAllotteeAfterApplied(ds.Tables[0]);

                                // System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.');", true);
                            }
                            else
                            {
                                string message1 = "Not Applied. Try again.";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                    }
                }
                else
                {
                    DataTable dt21 = new DataTable();
                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("select * from OTS_NMSWPTransactionDetail where UnitID='" + UnitID + "' and RequestID='" + Request_ID + "'", con);

                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                        adp1.Fill(dt21);
                        if (dt21.Rows.Count > 0) { }
                        else {

                            if (allotteeID != null || allotteeID != "")
                            {
                                DataSet ds1 = new DataSet();
                                SqlCommand cmd = new SqlCommand("[usp_SetServiceRequestForOTS_NMSWP]", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@AllotteeID", allotteeID);
                                cmd.Parameters.AddWithValue("@MaintenanceCharge", MC);
                                cmd.Parameters.AddWithValue("@InterestOnMaintenanceUpTo30621 ", INTEREST);
                                cmd.Parameters.AddWithValue("@InterestOnMCUpto", TotInt);
                                cmd.Parameters.AddWithValue("@InterestOnMCDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Schemetype", SchemeType);
                                cmd.Parameters.AddWithValue("@Installment1", InstallmentValue);
                                cmd.Parameters.AddWithValue("@Installment2", InstallmentValue);
                                cmd.Parameters.AddWithValue("@Installment3", InstallmentValue);
                                cmd.Parameters.AddWithValue("@duedate1", DateTime.Now.AddMonths(1));
                                cmd.Parameters.AddWithValue("@duedate2", DateTime.Now.AddMonths(2));
                                cmd.Parameters.AddWithValue("@duedate3", DateTime.Now.AddMonths(3));
                                cmd.Parameters.AddWithValue("@applicationSubmissionDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@downpayment", amount);
                                cmd.Parameters.AddWithValue("@downpaymentDuedate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@ServiceTimeLinesID", 2000);
                                //cmd.Parameters.AddWithValue("@CreatedBy", lblallotteeName.Text);
                                cmd.Parameters.AddWithValue("@NMControlID", ControlID);
                                cmd.Parameters.AddWithValue("@NMUnitID", UnitID);
                                cmd.Parameters.AddWithValue("@NMServiceID", ServiceID);
                                cmd.Parameters.AddWithValue("@NMRequestID", Request_ID);
                                cmd.Parameters.AddWithValue("@isActive", 1);
                                cmd.Parameters.AddWithValue("@isCompleted", 0);
                                cmd.Parameters.AddWithValue("@flag", 0);
                                cmd.Parameters.AddWithValue("@OneTimeEditScheme", 0);
                                cmd.Parameters.AddWithValue("@Waive_Off", rebate);
                                cmd.Parameters.AddWithValue("@Ledger_Flag", "Not Updated");
                                cmd.Parameters.AddWithValue("@Fee_Amount_Paid", "Pending");
                                cmd.Parameters.AddWithValue("@Email_Flag", 0);
                                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                adp.Fill(ds1);
                                if (ds1.Tables.Count > 0)
                                {
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        //btnpay.Enabled = false;

                                        string RefNo = ds1.Tables[0].Rows[0][0].ToString().Trim();

                                        string[] SerArray = RefNo.Split('/');
                                        int Service = int.Parse(SerArray[1]);
                                        if (Service == 2000)
                                        {
                                            string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
                                            if (NMSWP_Result == "SUCCESS")
                                            {
                                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                                                MailToAllotteeAfterApplied(ds.Tables[0]);
                                            }
                                            else
                                            {
                                                payPanel.Visible = true;
                                                //btnpay.Enabled = true;
                                                string message1 = "Error Occured while updating status at NMSWP";
                                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        payPanel.Visible = true;
                                        //btnpay.Enabled = true;
                                        string message1 = "Not Applied. Try again.";
                                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                    }
                                }
                            }
                            else
                            {
                                payPanel.Visible = true;
                                //btnpay.Visible = true;
                                string message = "Record couldnt be  Saved ";
                                string script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        payPanel.Visible = true;
                        //btnpay.Visible = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else {
                payPanel.Visible = true;
                //btnpay.Visible = true;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select payment scheme ');", true);
            }
        }
        protected void Apply_OfflineClick(object sender, EventArgs e)
        {
            //btnpay.Enabled = false;
            string Contact = "";
            string Email = "";
            int SchemeType = -1;
            //ControlID = "UPSWP210002975";
            //Request_ID = "21000297503210330001";
            //UnitID = "UPSWP21000297503";
            //ServiceID = "SC21033";

            if (ViewState["ControlID"] == null)
            {
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Control ID is not define.");
                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                return;
            }
            DataSet ds = new DataSet();
            ds = GetAllotteeRecordToBindForOTSScheme(txtsearch.Text.Trim(), drpIndusrialArea.SelectedItem.Text.Trim());

            if (ds.Tables.Count > 0)
            {
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                //AllotteeDiv.Visible = true;
                allotteeID = dt1.Rows[0]["AllotteeID"].ToString();

                MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);

                INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                string IntDues = (Convert.ToDouble(INTEREST) < 0) ? "0.00" : INTEREST.ToString();

                INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                string IntOnMCDues = (Convert.ToDouble(INTERESTONMC) < 0) ? "0.00" : INTERESTONMC.ToString();
                //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                TotInt = Math.Round((decimal)TotInt, 2);

                TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(lblMaintenanceCharge.Text);
                TotDues = Math.Round((decimal)TotDues, 2);

                rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                rebate = Math.Round((decimal)rebate, 2);
                TotalOneTimeDues = (TotDues - rebate);
                InstallmentValue = (TotDues - rebate) / 4;
                InstallmentValue = Math.Round((decimal)InstallmentValue, 2);
            }
            else
            {
                RadioOneTime.Checked = false;
                RadioInstallment.Checked = false;
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n You have already applied for the same plot.");
                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
            }
            if (RadioOneTime.Checked == true)
            { SchemeType = 0; amount = TotalOneTimeDues; }
            else if (RadioInstallment.Checked == true)
            { SchemeType = 1; amount = InstallmentValue; }
            else { SchemeType = -1; }

            if (SchemeType != -1)
            {
                DataTable dts = IsComplaintRaised(drpIndusrialArea.SelectedItem.Text.Trim(), txtsearch.Text.Trim());
                if (dts.Rows.Count > 0)
                {
                    string msg = "Dear Applicant \r\n Your grievance is still pending.";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    #region
                    //if (allotteeID != null || allotteeID != "")
                    //{
                    //    DataSet dst1 = SetServiceRequestForOTS_Offline(allotteeID, MC, INTEREST, TotInt, SchemeType, InstallmentValue, amount, ControlID, UnitID, ServiceID, Request_ID, rebate);
                    //    if (dst1.Tables.Count > 0)
                    //    {
                    //        if (dst1.Tables[0].Rows.Count > 0)
                    //        {
                    //            btnpay.Enabled = false;

                    //            string RefNo = dst1.Tables[0].Rows[0][0].ToString().Trim();

                    //            string[] SerArray = RefNo.Split('/');
                    //            int Service = int.Parse(SerArray[1]);
                    //            //Test
                    //            string NMSWP_Result = OTSScheme_AppliedStatus_OnNM(ControlID, UnitID, ServiceID, Request_ID);
                    //            if (NMSWP_Result == "SUCCESS")
                    //            {
                    //                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                    //                var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                    //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                    //                MailToAllotteeAfterApplied(ds.Tables[0]);
                    //            }
                    //            //var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your grievance is still pending.");
                    //            //var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                    //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                    //            //MailToAllotteeAfterApplied(ds.Tables[0]);
                    //            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.');", true);
                    //        }
                    //        else
                    //        {
                    //            string message1 = "Not Applied. Try again.";
                    //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    //        }
                    //    }
                    //}
                    #endregion
                }
                else
                {
                    DataTable dt21 = new DataTable();
                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("select * from OTS_NMSWPTransactionDetail where UnitID='" + UnitID + "' and RequestID='" + Request_ID + "'", con);
                        
                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                        adp1.Fill(dt21);
                        if (dt21.Rows.Count > 0) { }
                        else {

                            if (allotteeID != null || allotteeID != "")
                            {
                                try
                                {
                                    //if (FileUpload2.HasFile)
                                    //{
                                    //    string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                                    //    string contentType = FileUpload2.PostedFile.ContentType;
                                    //    Stream fs1 = FileUpload2.PostedFile.InputStream;
                                    //    BinaryReader br1 = new BinaryReader(fs1);
                                    //    byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
                                    
                                    DataSet ds1 = new DataSet();

                                        SqlCommand cmd = new SqlCommand("[usp_SetServiceRequestForOTS_NMSWP_Offline]", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@AllotteeID", allotteeID);
                                        cmd.Parameters.AddWithValue("@MaintenanceCharge", MC);
                                        cmd.Parameters.AddWithValue("@InterestOnMaintenanceUpTo30621 ", INTEREST);
                                        cmd.Parameters.AddWithValue("@InterestOnMCUpto", TotInt);
                                        cmd.Parameters.AddWithValue("@InterestOnMCDate", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Schemetype", SchemeType);
                                        cmd.Parameters.AddWithValue("@Installment1", InstallmentValue);
                                        cmd.Parameters.AddWithValue("@Installment2", InstallmentValue);
                                        cmd.Parameters.AddWithValue("@Installment3", InstallmentValue);
                                        cmd.Parameters.AddWithValue("@duedate1", DateTime.Now.AddMonths(1));
                                        cmd.Parameters.AddWithValue("@duedate2", DateTime.Now.AddMonths(2));
                                        cmd.Parameters.AddWithValue("@duedate3", DateTime.Now.AddMonths(3));
                                        cmd.Parameters.AddWithValue("@applicationSubmissionDate", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@downpayment", amount);
                                        cmd.Parameters.AddWithValue("@downpaymentDuedate", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@ServiceTimeLinesID", 2000);
                                        //cmd.Parameters.AddWithValue("@CreatedBy", lblallotteeName.Text);
                                        cmd.Parameters.AddWithValue("@NMControlID", ControlID);
                                        cmd.Parameters.AddWithValue("@NMUnitID", UnitID);
                                        cmd.Parameters.AddWithValue("@NMServiceID", ServiceID);
                                        cmd.Parameters.AddWithValue("@NMRequestID", Request_ID);
                                        cmd.Parameters.AddWithValue("@isActive", 1);
                                        cmd.Parameters.AddWithValue("@isCompleted", 0);
                                        cmd.Parameters.AddWithValue("@flag", 0);
                                        cmd.Parameters.AddWithValue("@OneTimeEditScheme", 0);
                                        cmd.Parameters.AddWithValue("@Waive_Off", rebate);
                                        cmd.Parameters.AddWithValue("@Ledger_Flag", "Not Updated");
                                        cmd.Parameters.AddWithValue("@Fee_Amount_Paid", "Pending");
                                        cmd.Parameters.AddWithValue("@Email_Flag", 0);
                                        cmd.Parameters.AddWithValue("@Offline_Flag", 1);
                                        cmd.Parameters.AddWithValue("@UTRNo", txtUTR.Text.Trim());
                                        cmd.Parameters.AddWithValue("@BankName", txtBankName.Text.Trim());
                                        cmd.Parameters.AddWithValue("@OfflineTransactiondate", txtDate.Text.Trim());
                                       
                                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                        adp.Fill(ds1);
                                        if (ds1.Tables.Count > 0)
                                        {
                                            if (ds1.Tables[0].Rows.Count > 0)
                                            {
                                                //btnpay.Enabled = false;

                                                string RefNo = ds1.Tables[0].Rows[0][0].ToString().Trim();

                                                string[] SerArray = RefNo.Split('/');
                                                int Service = int.Parse(SerArray[1]);
                                                if (Service == 2000)
                                                {
                                                    //Test
                                                    //string NMSWP_Result = FeeStatusNM_Click(ControlID, UnitID, ServiceID, amount.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
                                                    string NMSWP_Result = OTSScheme_AppliedStatus_OnNM(ControlID, UnitID, ServiceID, Request_ID);
                                                    if (NMSWP_Result == "SUCCESS")
                                                    {
                                                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                                        var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                                                        MailToAllotteeAfterApplied(ds.Tables[0]);
                                                    }
                                                    else
                                                    {
                                                        payPanel.Visible = true;
                                                        //btnpay.Enabled = true;
                                                        string message1 = "Error Occured while updating status at NMSWP";
                                                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                payPanel.Visible = true;
                                                //btnpay.Enabled = true;
                                                string message1 = "Not Applied. Try again.";
                                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                            }
                                        }
                                    //}
                                }
                                catch
                                {
                                    string message1 = "Please attach PDF file.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                                }
                            }
                            else
                            {
                                payPanel.Visible = true;
                                //btnpay.Visible = true;
                                string message = "Record couldnt be  Saved ";
                                string script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        payPanel.Visible = true;
                        //btnpay.Visible = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }

            else {
                payPanel.Visible = true;
                //btnpay.Visible = true;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select payment scheme ');", true);
            }
        }
        protected string FeeStatusNM_Click(string ControlID,string UnitID, string ServiceID, string Fee_Amount, string Fee_Status, string Remarks,string Pendancy_level, string Request_ID)
        {
            string Update_Result="";
            Status_Code = "12";
            try
            {
                if(ControlID.Length >0)
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
            catch(Exception ex)
            {
                return "Failed";
            }
        }
        protected DataSet SetServiceRequestForOTS_Offline(string allotteeID, decimal MC, decimal INTEREST, decimal TotInt, int SchemeType, decimal InstallmentValue, decimal amount, string ControlID, string UnitID, string ServiceID, string Request_ID, decimal rebate)
        {
            DataSet ds11 = new DataSet();
            
             SqlCommand cmd = new SqlCommand("[usp_SetServiceRequestForOTS_NMSWP_Offline]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AllotteeID", allotteeID);
            cmd.Parameters.AddWithValue("@MaintenanceCharge", MC);
            cmd.Parameters.AddWithValue("@InterestOnMaintenanceUpTo30621 ", INTEREST);
            cmd.Parameters.AddWithValue("@InterestOnMCUpto", TotInt);
            cmd.Parameters.AddWithValue("@InterestOnMCDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Schemetype", SchemeType);
            cmd.Parameters.AddWithValue("@Installment1", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment2", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment3", InstallmentValue);
            cmd.Parameters.AddWithValue("@duedate1", DateTime.Now.AddMonths(1));
            cmd.Parameters.AddWithValue("@duedate2", DateTime.Now.AddMonths(2));
            cmd.Parameters.AddWithValue("@duedate3", DateTime.Now.AddMonths(3));
            cmd.Parameters.AddWithValue("@applicationSubmissionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@downpayment", amount);
            cmd.Parameters.AddWithValue("@downpaymentDuedate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ServiceTimeLinesID", 2000);
            //cmd.Parameters.AddWithValue("@CreatedBy", lblallotteeName.Text);
            cmd.Parameters.AddWithValue("@NMControlID", ControlID);
            cmd.Parameters.AddWithValue("@NMUnitID", UnitID);
            cmd.Parameters.AddWithValue("@NMServiceID", ServiceID);
            cmd.Parameters.AddWithValue("@NMRequestID", Request_ID);
            cmd.Parameters.AddWithValue("@isActive", 1);
            cmd.Parameters.AddWithValue("@isCompleted", 0);
            cmd.Parameters.AddWithValue("@flag", 0);
            cmd.Parameters.AddWithValue("@OneTimeEditScheme", 0);
            cmd.Parameters.AddWithValue("@Waive_Off", rebate);
            cmd.Parameters.AddWithValue("@Ledger_Flag", "Not Updated"); 
            cmd.Parameters.AddWithValue("@Fee_Amount_Paid", "Pending");
            cmd.Parameters.AddWithValue("@Email_Flag", 0);
            cmd.Parameters.AddWithValue("@Offline_Flag", 1);
            //cmd.Parameters.AddWithValue("@UTRNo", txtUTR.Text.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds11);
            return ds11;
        }
        protected DataSet SetServiceRequestForOTS(string allotteeID, decimal MC, decimal INTEREST, decimal TotInt, int SchemeType, decimal InstallmentValue, decimal amount, string ControlID, string UnitID, string ServiceID, string Request_ID, decimal rebate)
        {
            DataSet ds11 = new DataSet();

            SqlCommand cmd = new SqlCommand("[usp_SetServiceRequestForOTS_NMSWP]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AllotteeID", allotteeID);
            cmd.Parameters.AddWithValue("@MaintenanceCharge", MC);
            cmd.Parameters.AddWithValue("@InterestOnMaintenanceUpTo30621 ", INTEREST);
            cmd.Parameters.AddWithValue("@InterestOnMCUpto", TotInt);
            cmd.Parameters.AddWithValue("@InterestOnMCDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Schemetype", SchemeType);
            cmd.Parameters.AddWithValue("@Installment1", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment2", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment3", InstallmentValue);
            cmd.Parameters.AddWithValue("@duedate1", DateTime.Now.AddMonths(1));
            cmd.Parameters.AddWithValue("@duedate2", DateTime.Now.AddMonths(2));
            cmd.Parameters.AddWithValue("@duedate3", DateTime.Now.AddMonths(3));
            cmd.Parameters.AddWithValue("@applicationSubmissionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@downpayment", amount);
            cmd.Parameters.AddWithValue("@downpaymentDuedate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ServiceTimeLinesID", 2000);
            //cmd.Parameters.AddWithValue("@CreatedBy", lblallotteeName.Text);
            cmd.Parameters.AddWithValue("@NMControlID", ControlID);
            cmd.Parameters.AddWithValue("@NMUnitID", UnitID);
            cmd.Parameters.AddWithValue("@NMServiceID", ServiceID);
            cmd.Parameters.AddWithValue("@NMRequestID", Request_ID);
            cmd.Parameters.AddWithValue("@isActive", 1);
            cmd.Parameters.AddWithValue("@isCompleted", 0);
            cmd.Parameters.AddWithValue("@flag", 0);
            cmd.Parameters.AddWithValue("@OneTimeEditScheme", 0);
            cmd.Parameters.AddWithValue("@Waive_Off", rebate);
            cmd.Parameters.AddWithValue("@Ledger_Flag", "Not Updated");
            cmd.Parameters.AddWithValue("@Fee_Amount_Paid", "Pending");
            cmd.Parameters.AddWithValue("@Email_Flag", 0);
            
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds11);
            return ds11;
        }

        protected void OTSApplied()
        {
            DataTable dt= new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from OTS_NMSWPTransactionDetail where ");
            }
            catch
            {

            }
        }
        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx");
        }
        protected void launch_click(object sender, EventArgs e)
        {
            string za = "123";
            //launch.Visible = false;
            lbllauchedmsg.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal1('"+ za + "');", true);
            //Response.Redirect("http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx");
            ots.Visible = true;
            
        }
        protected DataTable isAlreadyapplied(string plotNo, string industrialArea)
        {
            try
            {
                DataTable dt0 = new DataTable();
                SqlCommand cmd = new SqlCommand("isAppliedOTSByPlot", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlotNo", plotNo);
                cmd.Parameters.AddWithValue("@IndustrialArea", industrialArea);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt0);
                return dt0;
            }
            catch(Exception ex)
            {
                throw ex;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal Server Error ');", true);
            }
            
        }
        protected DataTable isInterestNullOrZero(string plotNo, string industrialArea)
        {
            DataTable dtItn = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_isInterestNullOrZero", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PlotNo", plotNo);
            cmd.Parameters.AddWithValue("@IndustrialArea", industrialArea);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtItn);
            return dtItn;
        }
        protected void isDownPaymentPaid(string unitID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Transaction_ID, Transaction_Date from OTS_NMSWPTransactionDetail where UnitID='" + unitID + "' and (Transaction_ID is null or Transaction_ID='' or Status_For_Instalment='Ineligible')", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                btnviewStatus.Enabled = false;
            }
            else
            {
                btnviewStatus.Enabled = true;
            }
        }
        public void abc()
        {
            try
            {
                WriteToFile("Tast-1 " + DateTime.Now);
                SqlCommand cmd = new SqlCommand("usp_GetTodayIssueNOC", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                WriteToFile("Tast-12 " + DateTime.Now);
                adp.Fill(dt);
                WriteToFile("Tast-2 " + DateTime.Now);
                if (dt.Rows.Count > 0)
                {
                    WriteToFile("Tast-3 " + DateTime.Now);
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        WriteToFile("Tast-4 " + DateTime.Now);
                        string controlid = dtRow["ControlID"].ToString();
                        string unitID = dtRow["UnitID"].ToString();
                        string ServiceID = dtRow["ServiceID"].ToString();
                        string serviceReqNo = dtRow["ServiceRequestNo"].ToString();
                        string Requestid = dtRow["RequestID"].ToString();
                        int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                        //string DocType = dtRow[5].ToString();
                        //string Status = dtRow[6].ToString();
                        //string RejectionCode = dtRow[7].ToString();
                        //WriteToFile("Tast-5 " + serviceReqNo + " " + DateTime.Now);
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        if ((webService.WGetUBPaymentDetails(controlid, unitID, ServiceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid)) != null)
                        {
                           // WriteToFile("Tast-6 " + serviceReqNo + " " + DateTime.Now);
                            DataSet dss = webService.WGetUBPaymentDetails(controlid, unitID, ServiceID, "p5632aa8a5c915ba4b896325bc5baz8k", Requestid);
                            DataTable dtt = new DataTable();
                            dtt = dss.Tables[0];
                           // WriteToFile("Tast-7 " + serviceReqNo + " " + DateTime.Now);
                            if (dtt.Rows.Count > 0)
                            {
                                //WriteToFile("Tast-8 " + serviceReqNo + " " + DateTime.Now);
                                string status = dtt.Rows[0]["status_code"].ToString();
                                if (status == "11")
                                {
                                    string Transaction_ID = dtt.Rows[0]["Transaction_ID"].ToString();
                                    char[] charsToTrim2 = { '{', '}' };
                                    string TrnDate = (dtt.Rows[0]["Transaction_DateTime"].ToString()).Trim(charsToTrim2);

                                    //DateTime Transaction_Date = Convert.ToDateTime(TrnDate);
                                    decimal Fee_Amount = Convert.ToDecimal(dtt.Rows[0]["Fee_Amount"]);
                                    string noc_url = "";
                                
                                    //WriteToFile("Tast-9 " + serviceReqNo + " " + DateTime.Now);
                                    
                                    SqlCommand cmd20 = new SqlCommand("usp_updateNMSWPFeeStatus", con);
                                    cmd20.CommandType = CommandType.StoredProcedure;
                                    cmd20.Parameters.AddWithValue("@ControlID", controlid);
                                    cmd20.Parameters.AddWithValue("@UnitID", unitID);
                                    cmd20.Parameters.AddWithValue("@ServiceID ", serviceID);
                                    cmd20.Parameters.AddWithValue("@RequestID", Requestid);
                                    cmd20.Parameters.AddWithValue("@TransactionID", Transaction_ID);
                                    cmd20.Parameters.AddWithValue("@Fee_Amount", Fee_Amount);
                                    cmd20.Parameters.AddWithValue("@Transaction_Date", TrnDate);

                                    SqlDataAdapter adp20 = new SqlDataAdapter(cmd20);
                                   
                                    DataSet dt20 = new DataSet();
                                    adp20.Fill(dt20);
                                    if (dt20.Tables.Count > 0)
                                    {
                                        //WriteToFile("Tast-11 " + serviceReqNo + " " + DateTime.Now);

                                        if (schemeType == 0)
                                        {
                                            //WriteToFile("Tast-12 " + serviceReqNo + " " + DateTime.Now);
                                            if (dt20.Tables.Count > 1)
                                            {
                                                //WriteToFile("Tast-13 " + serviceReqNo + " " + DateTime.Now);
                                                DataTable dt5 = new DataTable();
                                                DataTable dt6 = new DataTable();
                                                dt5 = dt20.Tables[0];
                                                dt6 = dt20.Tables[1];
                                                //WriteToFile("Tast-14 " + serviceReqNo + " " + DateTime.Now);
                                                decimal amt1 = Convert.ToDecimal(dt5.Rows[0]["TotalInterest"]);
                                                decimal amt2 = Convert.ToDecimal(dt5.Rows[0]["TotalInterest"]);
                                                Decimal amount2 = (amt2 - amt1);
                                                //WriteToFile("Tast-15 " + serviceReqNo + " " + DateTime.Now);
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

                                                    //WriteToFile("Tast-18 " + serviceReqNo + " " + DateTime.Now);
                                                    Is_Certificate_Valid_Life_Time = "NO";
                                                    Remarks = "NOC Certificate Issued";
                                                    Certificate_EXP_Date_DDMMYYYY = "20/02/2022";
                                                    //WriteToFile("Tast-19 " + serviceReqNo + " " + DateTime.Now);
                                                    noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                    MailToAllotteeAfterPaid(controlid, unitID, ServiceID, Requestid);
                                                    //WriteToFile("Tast-20 " + serviceReqNo + " " + DateTime.Now);
                                                    //StatusUpdateOnWithNOC(controlid, unitID, ServiceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                    //WriteToFile("Tast-21 " + serviceReqNo + " " + DateTime.Now);

                                                    //WriteToFile("Tast-22 " + serviceReqNo + " " + DateTime.Now);
                                                }
                                            }
                                            else
                                            {
                                                //WriteToFile("Tast-23 " + serviceReqNo + " " + DateTime.Now);
                                               
                                                    Is_Certificate_Valid_Life_Time = "Yes";
                                                Remarks = "NOC Certificate Issued";
                                                //noc_url = "http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                //StatusUpdateOnWithNOC(controlid, unitID, ServiceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                MailToAllotteeAfterPaid(controlid, unitID, ServiceID, Requestid);
                                                WriteToFile("Tast-26 " + serviceReqNo + " " + DateTime.Now);
                                            }
                                        }
                                        if (schemeType == 1)
                                        {
                                            //WriteToFile("Tast-27 " + serviceReqNo + " " + DateTime.Now);
                                            if (dt20.Tables.Count > 1)
                                            { }
                                            else
                                            {
                                                Is_Certificate_Valid_Life_Time = "NO";
                                                Remarks = "25% Upfront Paid Successfully";
                                                noc_url = "http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "";
                                                // StatusUpdateOnWithNOC(controlid, unitID, ServiceID, Requestid, Fee_Amount.ToString(), noc_url, Remarks);
                                                MailToAllotteeAfterPaid(controlid, unitID, ServiceID, Requestid);
                                             }
                                         }

                                    }
                                    WriteToFile("Tast-28 " + serviceReqNo + " " + DateTime.Now);
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
            NOC_Certificate_Number = "NOC" + noc_url + "";

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
            SqlCommand cmd = new SqlCommand("select AM.AllotteeName, AM.AllotteeID from OTS_NMSWPTransactionDetail ONT join AllotteeMaster AM on AM.AllotteeID = Try_Cast(ONT.AllotteeID as int) where ONT.ControlID='" + controlid + "' and UnitID='" + unitid + "' and ServiceID='" + serviceid + "' and RequestID='" + requestid + "' ", con);
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
        protected void View_Status(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where ControlID='" + ControlID + "' and UnitID='" + UnitID + "' and ServiceID='" + ServiceID + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string serviceReqNo = dt.Rows[0]["ServiceRequestNo"].ToString();
                    int stype = Convert.ToInt32(dt.Rows[0]["SchemeType"]);
                    if (stype == 0)
                    {
                        //Response.Redirect("http://localhost:49691/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo="+Request_ID+"");
                        //Response.Redirect("http://services.stagingupsida.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo=" + Request_ID + "");
                        Response.Redirect("https://eservices.onlineupsidc.com/NOC_OneTimeScheme.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo=" + Request_ID + "");
                    }
                    else if (stype == 1)
                    {
                        //Response.Redirect("http://localhost:49691/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo=" + Request_ID + "");
                        //Response.Redirect("http://services.stagingupsida.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo=" + Request_ID + "");
                        Response.Redirect("https://eservices.onlineupsidc.com/NOC_OneForthUpfront_Payment.aspx?ServiceRequestNo=" + serviceReqNo.Trim() + "&ReqNo=" + Request_ID + "");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Test
        protected string OTSScheme_AppliedStatus_OnNM(string controlid, string unitid, string serviceid, string requestid)
        {
            ControlID = controlid;
            UnitID = unitid;
            ServiceID = serviceid;
            Request_ID = requestid;
            Status_Code = "10";
            Remarks = "OTS Maintenance charge scheme applied";
            
            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            Request_ID
, Objection_Rejection_Code, Is_Certificate_Valid_Life_Time, Certificate_EXP_Date_DDMMYYYY,
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
        //protected void Offline_ReqID(string NMreqID)
        //{
        //    string a = "";
        //    string s = "You win some. You lose some.";

        //    string[] req = NMreqID.Split('P');
        //    a = req[2];
        //    // string[] req = s.Split(", ");
            
        //}
    }

}