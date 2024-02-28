﻿using System;
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
    public partial class RegistrationPIP : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
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
                SWCControlID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMControlID"]));
                SWCUnitID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMUnitID"]));
                SWCServiceID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMServiceID"]));
                SWCRequest_ID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMRequestID"]));

               
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
                    if (SWCServiceID.Trim() == "SC21036" && recordalreadyexist == false)

                    //     if (SWCServiceID.Trim()== "SC21036")
                    {
                        txtApplicantName.Enabled = false;
                        txtEmailID.Enabled = false;
                        txtMobileNo.Enabled = false;
                        //txtApplicantName.Text = name;
                        //txtEmailID.Text = email;
                        //txtMobileNo.Text = mob;
                        NiveshMitra();
                        Allotment.ActiveViewIndex = 1;

                    }
                    else
                    {
                        // Response.Redirect("https://niveshmitra.up.nic.in/Testing_NMSWP/nmmasters/Entrepreneur_Dashboard.aspx");

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
                SqlCommand cmd = new SqlCommand("select * from PIPRegister where RequestID =@RequestID and ControlID=@ControlID", con);
                cmd.Parameters.AddWithValue("@RequestID", SWCRequest_ID);
                cmd.Parameters.AddWithValue("@ControlID", SWCControlID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ApplicationID = dt.Rows[i]["ApplicationId"].ToString();
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



                MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(txtEmailID.Text.Trim());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //  newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", txtApplicantName.Text.Trim());
                StrContent = StrContent.Replace("{OTP}", otp.Trim());
                StrContent = StrContent.Replace("{Service}", "Application Under Private Industrial Parks Policy");


                newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application Under Private Industrial Parks Policy";
                newmsg.BodyHtml = StrContent;


                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);



                //String message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application Under Private Industrial Parks Policy is " + otp + "");
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
               

                    objServiceTimelinesBEL.ApplicantName = txtApplicantName.Text.Trim();
                    objServiceTimelinesBEL.MobileNumber  = txtMobileNo.Text.Trim();
                    objServiceTimelinesBEL.emailID       = txtEmailID.Text.Trim();

                    objServiceTimelinesBEL.MControlID = SWCControlID.Trim();
                    objServiceTimelinesBEL.MUnitId = SWCUnitID.Trim();
                    objServiceTimelinesBEL.MServiceId = SWCServiceID.Trim();
                    objServiceTimelinesBEL.MRequestID = SWCRequest_ID.Trim();




                    DataSet result = objServiceTimelinesBLL.SaveLogisticDetails(objServiceTimelinesBEL);

                    if (result.Tables[0].Rows.Count > 0)
                    {

                        string ID = HttpUtility.UrlEncode(Encrypt(result.Tables[0].Rows[0][0].ToString()));
                        
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect('"+ ID + "');", true);

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
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = txtApplicationID.Text.Trim();
                ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string MobileNo = dt.Rows[0]["PhoneNo"].ToString();
                    string EmailID  = dt.Rows[0]["emailID"].ToString();

                    
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


                    MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    //MailAddress mailto = new MailAddress(txtEmailID.Text.Trim());
                    MailAddress mailto = new MailAddress(EmailID);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //  newmsg.IsBodyHtml = true;

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", txtApplicantName.Text.Trim());
                    StrContent = StrContent.Replace("{OTP}", otp.Trim());
                    StrContent = StrContent.Replace("{Service}", "Application Under Private Industrial Parks Policy");


                    newmsg.Subject = "UPSIDAeService: OTP verification for registration of Application Under Private Industrial Parks Policy";
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);



                    String message = HttpUtility.UrlEncode("Dear " + txtApplicantName.Text + " OTP for Application Under Private Industrial Parks Policy is " + otp + "");
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
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    DataSet ds = new DataSet();

                    objServiceTimelinesBEL.ServiceRequestNO = txtApplicationID.Text.Trim();
                    ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);


                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        string ApplicationID = dt.Rows[0]["ApplicationId"].ToString();

                        string ID = HttpUtility.UrlEncode(Encrypt(ApplicationID.Trim()));

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirectModify('" + ID + "');", true);

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