using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
//using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class RegistrationLogisticsReScDue : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        SqlConnection con;
        string checkQuery;
        GeneralMethod gm = new GeneralMethod();
        public string ServiceReqNo;
        public string SWCControlID;
        public string SWCUnitID;
        public string SWCServiceID;
        public string SWCRequest_ID;
        public string name;
        public string email;
        public string mob;
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        #endregion
        bool recordalreadyexist = false;
        string LAWID = string.Empty;
        string ApplicationID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                //SWCControlID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMControlID"]));
                //SWCUnitID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMUnitID"]));
                //SWCServiceID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMServiceID"]));
                // SWCRequest_ID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMRequestID"]));

                SWCControlID = "UOSWP230001921";
                SWCUnitID = "UPSWP23000192101";
                SWCServiceID = "SC21045";
                SWCRequest_ID = "22000066715210340001";

                if (SWCServiceID.Trim() == "SC21099")
                {
                    divpipfin.Visible = true;
                }

                // mashi

               
                // end code

                //SWCControlID = "UPSWP220000667";
                //SWCUnitID = "UPSWP22000066715";
                //SWCServiceID = "SC21034";
                //SWCRequest_ID = "22000066715210340001";

                //   name = Decrypt(HttpUtility.UrlDecode(Request.QueryString["AppName"]));
                //  email = Decrypt(HttpUtility.UrlDecode(Request.QueryString["AppEmail"]));
                //   mob = Decrypt(HttpUtility.UrlDecode(Request.QueryString["AppMobNo"]));

                if (!IsPostBack)
                {
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        // Allotment.ActiveViewIndex = 0;                      
                    }
                    fetchRecordfromdb();
                    
                    if (SWCServiceID.Trim() == "SC21099" && recordalreadyexist == false)

                    {
                        txtApplicantName.Enabled = false;
                        txtEmailID.Enabled = false;
                        txtMobileNo.Enabled = false;

                        //----NiveshMitra();
                        Allotment.ActiveViewIndex = 1;
                        divpipfin.Visible = true;
                    }

                    else
                    {
                        Allotment.ActiveViewIndex = 2;
                        txtApplicationID.Enabled = false;
                        txtApplicationID.Text = ApplicationID;
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Exception : " + ex.ToString());
            }

        }
        public void fetchRecordfromdb()
        {

            try
            {
                con.Open();
              
                if (SWCServiceID.Trim() == "SC21099")
                {
                    checkQuery = "select * from  AllotteeMaster where NMRequestID =@NMRequestID and ControlID=@ControlID";
                }

                SqlCommand cmd = new SqlCommand(checkQuery, con);

                cmd.Parameters.AddWithValue("@NMRequestID", SWCRequest_ID);
                cmd.Parameters.AddWithValue("@ControlID", SWCControlID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ApplicationID = dt.Rows[i]["serviceReqNo"].ToString();
                    }
                    recordalreadyexist = true;
                    //  Response.Redirect("LoginPage.aspx");

                }
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex);
            }

        }

        private void NiveshMitra()
        {

            if (SWCControlID.Length > 0)
            {


                try
                {

                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet ds = webService.WGetBasicDetails(SWCControlID, SWCUnitID, SWCServiceID, "", passsalt);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        //lblControlId.Text = ControlID;
                        //lblUnitId.Text = UnitID;
                        //// lblserviceid.Text = ServiceID;
                        //lblCompanyName.Text = dt.Rows[0]["Company_Name"].ToString();
                        //lblIndustryDistrict.Text = dt.Rows[0]["Industry_District"].ToString();
                        //lblIndustryAddress.Text = dt.Rows[0]["Industry_Address"].ToString();
                        //lblIndustryPincode.Text = dt.Rows[0]["Pin_Code"].ToString();
                        txtApplicantName.Text = dt.Rows[0]["Occupier_Name"].ToString();
                        txtEmailID.Text = dt.Rows[0]["Occupier_Email_ID"].ToString();
                        txtMobileNo.Text = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                        //lblOccupierPAN.Text = dt.Rows[0]["Occupier_PAN"].ToString();
                        //lblOccupierAddress.Text = dt.Rows[0]["Occupier_Address"].ToString();
                        //lblOccupierDistrictName.Text = dt.Rows[0]["Occupier_District_Name"].ToString();
                        //lblNatureofActivity.Text = dt.Rows[0]["Nature_of_Activity"].ToString();
                        //lblInstalledCapacity.Text = dt.Rows[0]["Installed_Capacity"].ToString();
                        //lblNoOfEmployee.Text = dt.Rows[0]["Employees"].ToString();
                        //lblNature_of_Operation.Text = dt.Rows[0]["Nature_of_Operation"].ToString();
                        //lblProject_Cost.Text = dt.Rows[0]["Project_Cost"].ToString();
                        //lblOrganization_Type.Text = dt.Rows[0]["Organization_Type"].ToString();
                        //lblIndustry_Type_Name.Text = dt.Rows[0]["Industry_Type_Name"].ToString();
                        //lblItems_Manufactured.Text = dt.Rows[0]["Items_Manufactured"].ToString();
                        //lblAnnual_Turnover.Text = dt.Rows[0]["Annual_Turnover"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Something Went Wrong With Nivesh Mitra Server');", true);
                    return;
                }

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtApplicantName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your name');", true);
                    return;
                }
                if (txtEmailID.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your Email ID');", true);
                    return;
                }
                if (txtMobileNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid mobile no');", true);
                    return;
                }
                if (txtServiceRequestNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid Service Request No');", true);
                    return;
                }
                
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                SqlCommand cmd = new SqlCommand("select * from ServiceRequests where ServiceRequestNO ='" + txtServiceRequestNo.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid Service Request No');", true);
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


                MailAddress mailfrom = new MailAddress("support@onlineupsidc.com");
                //MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(txtEmailID.Text.Trim());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //  newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", txtApplicantName.Text.Trim());
                StrContent = StrContent.Replace("{OTP}", otp.Trim());
                
                if (SWCServiceID.Trim() == "SC21099")
                {
                    StrContent = StrContent.Replace("{Service}", "Application for Reschedulement of Dues");
                    newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application for Reschedulement of Dues";
                }

                newmsg.BodyHtml = StrContent;

                SmtpClient client = new SmtpClient();
                client.Host = "mail.onlineupsidc.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "Edc7!RFvT@8GbYU";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);

                //SmtpClient client = new SmtpClient();
                //client.Host = "smtp.outlook.com";
                //client.Port = 587;
                //client.Username = mailfrom.Address;
                //client.Password = "upsida12345";
                //client.ConnectionProtocols = ConnectionProtocols.Ssl;
                //client.SendOne(newmsg);
                
                //String message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application Under Logistic & Warehousing Policy 2022 is " + otp + "");
                //string s = gm.SendOTP("OTP", txtMobileNo.Text, txtApplicantName.Text.Trim(), message);
                
                ViewState["OTP"] = otp;
                string input = txtEmailID.Text.Trim();
                string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                string Output2 = Regex.Replace(txtMobileNo.Text.Trim(), @"\d(?!\d{0,3}$)", "X");

                string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + ". Kindly verify OTP for the submission of your application";
                //string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                Otp_MobileDiv.Visible = true;
                txtApplicantName.Enabled = false;
                txtMobileNo.Enabled = false;
                txtEmailID.Enabled = false;
                BtnSaveApplicant.Text = "Resend OTP";
                return;


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured Exception :" + ex.Message.ToString());
                Otp_MobileDiv.Visible = false;
                ViewState["OTP"] = "";
                return;
            }
        }

        protected void btn_EnterMobileOtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMobOtp.Text.Trim() == ViewState["OTP"].ToString().Trim())
                {

                    if (txtApplicantName.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your name');", true);
                        return;
                    }

                    if (txtMobileNo.Text.Trim().Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid mobile no');", true);
                        return;
                    }
                    if (txtEmailID.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid email ID');", true);
                        return;
                    }
                    if (txtServiceRequestNo.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid Service Request No');", true);
                        return;
                    }
                    else
                    {
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                        SqlCommand cmd = new SqlCommand("select * from ServiceRequests where ServiceRequestNO ='" + txtServiceRequestNo.Text.Trim() + "'", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid Service Request No');", true);
                            return;
                        }
                    }

                    objServiceTimelinesBEL.ApplicantName = txtApplicantName.Text.Trim();
                    objServiceTimelinesBEL.MobileNumber = txtMobileNo.Text.Trim();
                    objServiceTimelinesBEL.emailID = txtEmailID.Text.Trim();
                    objServiceTimelinesBEL.ReScDueServiceRequestNo = txtServiceRequestNo.Text.Trim();

                    objServiceTimelinesBEL.MControlID = SWCControlID.Trim();
                    objServiceTimelinesBEL.MUnitId = SWCUnitID.Trim();
                    objServiceTimelinesBEL.MServiceId = SWCServiceID.Trim();
                    objServiceTimelinesBEL.MRequestID = SWCRequest_ID.Trim();

                    DataSet result = new DataSet();

                    if (SWCServiceID.Trim() == "SC21099")
                    {
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        DataSet ds = webService.WGetBasicDetails(SWCControlID, SWCUnitID, SWCServiceID, "", passsalt);
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            objServiceTimelinesBEL.CompanyName = dt.Rows[0]["Company_Name"].ToString();
                            objServiceTimelinesBEL.IndustrialArea = dt.Rows[0]["Industry_District"].ToString();
                            objServiceTimelinesBEL.ApplicationAdress1 = dt.Rows[0]["Industry_Address"].ToString();
                            objServiceTimelinesBEL.AllotteeName = dt.Rows[0]["Occupier_Name"].ToString();
                            objServiceTimelinesBEL.emailID = dt.Rows[0]["Occupier_Email_ID"].ToString();
                            objServiceTimelinesBEL.PhoneNo = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                            objServiceTimelinesBEL.PanNo = dt.Rows[0]["Occupier_PAN"].ToString();
                            objServiceTimelinesBEL.ApplicationAdress1 = dt.Rows[0]["Occupier_Address"].ToString();
                            objServiceTimelinesBEL.ApplicationAdress1 = dt.Rows[0]["Occupier_Address"].ToString();
                        }

                        result = objServiceTimelinesBLL.SaveReScDueDetails(objServiceTimelinesBEL);
                    }

                    if (result.Tables[0].Rows.Count > 0)
                    {

                        string ID = HttpUtility.UrlEncode(Encrypt(result.Tables[0].Rows[0][0].ToString()));

                        //if (SWCServiceID.Trim() == "SC21036")
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect('" + ID + "');", true);
                        //}
                        //else if (SWCServiceID.Trim() == "SC21044")
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PIPMsgAndRedirect('" + ID + "');", true);
                        //}
                        //else
                        if (SWCServiceID.Trim() == "SC21045")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PIPFinMsgAndRedirect('" + ID + "');", true);
                        }


                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('OTP Not Verified');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('OTP Not Verified');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured Exception :" + ex.Message.ToString());
                Otp_MobileDiv.Visible = false;
                ViewState["OTP"] = "";
                return;
            }
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //   Response.Redirect("RegistrationLogistics.aspx");
        }

        protected void btnproceed_Click(object sender, EventArgs e)
        {
            if (RadioUpsidc.Checked == true)
            {
                Allotment.ActiveViewIndex = 1;
            }
            else if (RadioExisting.Checked == true)
            {
                Allotment.ActiveViewIndex = 2;
            }
            else if (RadioTrackApp.Checked == true)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Featur will be live soon');", true);

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose One Option');", true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {


            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            Mpropertymodel objMpropertymodel = new Mpropertymodel();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            Mbal objMbal = new Mbal();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = txtApplicationID.Text.Trim();
                objMpropertymodel.ServiceRequestNO = txtApplicationID.Text.Trim();

                //if (SWCServiceID.Trim() == "SC21036")
                //{
                //    ds = objServiceTimelinesBLL.GetLAWDetails(objServiceTimelinesBEL);
                //}
                //else if (SWCServiceID.Trim() == "SC21044")
                //{
                //    ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);
                //}

                //else 
                if (SWCServiceID.Trim() == "SC21045")
                {
                    ds = objMbal.GetAFinancialAssistanceDetails(objMpropertymodel);
                }


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string MobileNo = dt.Rows[0]["PhoneNo"].ToString();
                    string EmailID = dt.Rows[0]["emailID"].ToString();


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

                    MailAddress mailfrom = new MailAddress("support@onlineupsidc.com");
                    //MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    //MailAddress mailto = new MailAddress(txtEmailID.Text.Trim());
                    MailAddress mailto = new MailAddress(EmailID);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //  newmsg.IsBodyHtml = true;

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", txtApplicantName.Text.Trim());
                    StrContent = StrContent.Replace("{OTP}", otp.Trim());

                    //if (SWCServiceID.Trim() == "SC21036")
                    //{
                    //    StrContent = StrContent.Replace("{Service}", "Application Under Logistic & Warehousing Policy 2022");
                    //    newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application Under Logistic & Warehousing Policy 2022";
                    //}
                    //else if (SWCServiceID.Trim() == "SC21044")
                    //{
                    //    StrContent = StrContent.Replace("{Service}", "Application for Issuance of Unique Id for Private Industrial Parks");
                    //    newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application for Issuance of Unique Id for Private Industrial Parks";
                    //}
                    //else
                    if (SWCServiceID.Trim() == "SC21045")
                    {
                        StrContent = StrContent.Replace("{Service}", "Application for Issuance of Unique Id for Financial Assistance Private Industrial Parks");
                        newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application for Issuance of Unique Id for  Financial Assistance Private Industrial Parks";
                    }
                    newmsg.BodyHtml = StrContent;

                    SmtpClient client = new SmtpClient();
                    client.Host = "mail.onlineupsidc.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "Edc7!RFvT@8GbYU";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);

                    //SmtpClient client = new SmtpClient();
                    //client.Host = "smtp.outlook.com";
                    //client.Port = 587;
                    //client.Username = mailfrom.Address;
                    //client.Password = "upsida12345";
                    //client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    //client.SendOne(newmsg);

                    String message = "";

                    //if (SWCServiceID.Trim() == "SC21036")
                    //{
                    //    message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application Under Logistic & Warehousing Policy 2022 is " + otp + "");
                    //}
                    //else if (SWCServiceID.Trim() == "SC21044")
                    //{
                    //    message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application for Issuance of Unique Id for Private Industrial Parks is " + otp + "");
                    //}
                    //else
                    if (SWCServiceID.Trim() == "SC21045")
                    {
                        message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application for Issuance of Unique Id for Financial Assistance Private Industrial Parks is " + otp + "");
                    }
                    string s = gm.SendOTP("OTP", MobileNo.Trim(), txtApplicantName.Text.Trim(), message);


                    ViewState["OTP1"] = otp;
                    string input = EmailID.Trim();
                    string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                    string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                    string Output2 = Regex.Replace(MobileNo.Trim(), @"\d(?!\d{0,3}$)", "X");
                    string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " . Kindly verify OTP for the submission of your application";
                    // string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    OtpDiv.Visible = true;

                    btnModify.Text = "Resend OTP";
                    return;


                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }            
        }

        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Trim() == ViewState["OTP1"].ToString().Trim())
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    Mbal objMbal = new Mbal();
                    Mpropertymodel objMpropertymodel = new Mpropertymodel();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    DataSet ds = new DataSet();

                    objServiceTimelinesBEL.ServiceRequestNO = txtApplicationID.Text.Trim();
                    objMpropertymodel.ServiceRequestNO = txtApplicationID.Text.Trim();

                    //if (SWCServiceID.Trim() == "SC21036")
                    //{
                    //    ds = objServiceTimelinesBLL.GetLAWDetails(objServiceTimelinesBEL);
                    //}
                    //else if (SWCServiceID.Trim() == "SC21044")
                    //{
                    //    ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);
                    //}

                    //else
                    if (SWCServiceID.Trim() == "SC21045")
                    {
                        ds = objMbal.GetAFinancialAssistanceDetails(objMpropertymodel);
                    }

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        string ApplicationID = dt.Rows[0]["serviceReqNO"].ToString();

                        string ID = HttpUtility.UrlEncode(Encrypt(ApplicationID.Trim()));

                        //if (SWCServiceID.Trim() == "SC21036")
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirectModify('" + ID + "');", true);
                        //}
                        //else if (SWCServiceID.Trim() == "SC21044")
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PIPMsgAndRedirectModify('" + ID + "');", true);
                        //}
                        //else
                        if (SWCServiceID.Trim() == "SC21045")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PIP_AfaMsgAndRedirectModify('" + ID + "');", true);
                        }

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx");
        }
    }
}
