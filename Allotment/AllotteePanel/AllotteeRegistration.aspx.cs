using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO; 
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment.AllotteePanel
{
    public partial class AllotteeRegistration : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string Usertype = "", pwd = "", dypPwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearAll();
                UpdateCaptchaText();
                
            }
        }

        private void UpdateCaptchaText()
        {
            txtCode.Text = string.Empty;
            Random randNum = new Random();

            //Store the captcha text in session to validate  
            Session["Captcha"] = randNum.Next(10000, 99999).ToString();
            imgCaptcha.ImageUrl = "~/ghCaptcha.ashx?" + Session["Captcha"];
        }
        public void ClearAll()
        {
            //lblMessage.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompany.Text= string.Empty;
            txtCode.Text = string.Empty;
        }
        protected void ShowPopup(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
           
            try
            {
                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                {
                   if(txtName.Text.Trim()!=""&& txtPhone.Text.Trim().Length == 10 && txtEmail.Text.Trim()!="" && txtCompany.Text.Trim()!=""&& txtCode.Text.Trim()!="")
                    {
                        if (Session["Captcha"].ToString() == txtCode.Text.Trim())
                        {
                          
                            Mbal objMbal = new Mbal();
                            DataSet ds = new DataSet();

                            ds = objMbal.CheckemailidforaloteeRegister(txtEmail.Text.Trim());

                            if (ds.Tables[0].Rows[0]["Returncode"].ToString() == "0")
                            {

                                lblmsg.Text = "  Please enter the Otp (One Time Password) Sent to your registered email id </br> This OTP will expire in 15 minutes.";
                                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                                //return;



                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                                OTPMailSend();
                            }
                            else
                            {
                                

                               System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect();", true);
                                return;
                             
                            }

                         
                           
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Captcha');", true);
                            UpdateCaptchaText();
                          
                            return;
                           
                        }

                    }
                    //if (txtName.Text.Trim().Length <= 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter allottee name');", true);
                    //    return;
                    //}
                    //if (txtCompany.Text.Trim().Length <= 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your company name');", true);
                    //    return;
                    //}
                    //if (txtPhone.Text.Trim().Length == 10)
                    //{

                    //}
                    //else
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your 10 digit mobile no without zero');", true);
                    //    return;
                    //}
                    //if (txtEmail.Text.Trim().Length <= 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your email id');", true);
                    //    return;
                    //}
                   

                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                    //string message = "Message from server side";

                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                   
                   
                }
              
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", ""+ex.StackTrace+"", true);
                UpdateCaptchaText();
                return;
            }
           
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            if (Button1.Text == "Verify")
            {

                if (Session.Contents.Count == 0)
                {
                       string msg = "Otp  Expired";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                       return;
                }
                else
                {
                    if (Session["OTPR"].ToString() == txtVerifyOTP.Text.Trim())
                    {
                       // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('hide');</script>", false);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#testmodal').modal('hide');$('body').removeClass('modal-open');$('.modal-backdrop').remove(); ", true);
                        System.Threading.Thread.Sleep(1000);
                        string pwd = "";
                        try
                        {

                            pwd = CreatePassword(8);
                            //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                            //{
                            //    string msg = "Kindly upload copy of office order";
                            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            //    return;
                            //}

                            //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                            // string filePath = "~/TrackApplication/" + Convert.ToString(Session["TracingName"]);

                            objServiceTimelinesBEL.Allotteename = txtName.Text.Trim();
                            objServiceTimelinesBEL.Email = txtEmail.Text.Trim();
                            objServiceTimelinesBEL.PhoneNumber = txtPhone.Text.Trim();
                            objServiceTimelinesBEL.CompanyName = txtCompany.Text.Trim();
                            objServiceTimelinesBEL.UserIds = txtEmail.Text.Trim();
                            objServiceTimelinesBEL.Password = pwd;
                            //objServiceTimelinesBEL.PublicPrivate = drpPrivate.SelectedValue.Trim();



                            int retVal = objServiceTimelinesBLL.NewAllotteeRegistration(objServiceTimelinesBEL);
                            if (retVal > 0)
                            {
                                MailAddress mailfrom = new MailAddress("support@onlineupsidc.com");
                                //MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                                MailAddress mailto = new MailAddress(txtEmail.Text);
                                MailMessage newmsg = new MailMessage(mailfrom, mailto);
                                //newmsg.IsBodyHtml = true;

                                string StrContent = "";
                                StreamReader reader = new StreamReader(Server.MapPath("Registration.html"));
                                StrContent = reader.ReadToEnd();

                                StrContent = StrContent.Replace("{UserName}", txtName.Text.Trim());
                                StrContent = StrContent.Replace("{userid}", txtEmail.Text.Trim());
                                StrContent = StrContent.Replace("{Password}", pwd.Trim());

                                newmsg.Subject = "UPSIDA : mail for registration details";
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
                               //  client.SendOne(newmsg);
                                //File.WriteAllBytes(Server.MapPath(filePath), Session["Tracing"] as byte[]);
                                //txtVerifyOTP.Text = "";
                                //string msg = "Allottee Registration done Successfully. Details send on Your Email";
                                //lblmsg.Text = "Allottee Registration done Successfully. Details send on Your Email";
                                //Button1.Text = "Go To Login..";
                                ClearAll();
                              
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgRegistrationRedirect();", true);
                                return;

                                //Response.Redirect("AllotteeLogin.aspx");
                                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#testmodal').modal('hide');$('body').removeClass('modal-open');$('.modal-backdrop').remove(); ", true);
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);


                                //BindOfficeOrders();

                            }

                           
                            //else
                            //{
                            //string msg = "Allottee Registration couldn't be done";
                            //lblmsg.Text = "Allottee all ready Registration go to login page";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                            //return;
                            //}



                        }
                        catch (Exception ex)
                        {
                            Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
                        }
                        finally
                        {
                            objServiceTimelinesBEL = null;
                            objServiceTimelinesBLL = null;
                        }
                    }
                    else
                    {
                        //string msg = "OTP Not Matched";
                        lblmsg.Text = "OTP Not Matched";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                        // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }
               
            }
            else
            {
                Response.Redirect("AllotteeLogin.aspx");
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#^";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public void OTPMailSend()
        {
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
            Session.Timeout = 15;
            Session["OTPR"] = otp.ToString();
            MailAddress mailfrom = new MailAddress("support@onlineupsidc.com");
           // MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
            MailAddress mailto = new MailAddress(txtEmail.Text);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            //newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("OTPMail.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{UserName}", txtName.Text.Trim());
            StrContent = StrContent.Replace("{OTPFor}", "online registration");
            
            StrContent = StrContent.Replace("{OTP}", otp.Trim());

            newmsg.Subject = "UPSIDA : OTP verification for registration ";
            newmsg.BodyHtml = StrContent;

                                 SmtpClient client = new SmtpClient();
                                client.Host = "mail.onlineupsidc.com";
                                client.Port = 587;
                                client.Username = mailfrom.Address;
                                client.Password = "Edc7!RFvT@8GbYU";
                                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                                client.SendOne(newmsg);

            
           // SmtpClient client = new SmtpClient();
            //client.Host = "smtp.outlook.com";
           // client.Port = 587;
            //client.Username = mailfrom.Address;
           // client.Password = "upsida12345";
           // client.ConnectionProtocols = ConnectionProtocols.Ssl;
          //client.SendOne(newmsg);
        }

        public void RegMailSend()
        {
            
        }
    }
}
