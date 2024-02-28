using BEL_Allotment;
using BLL_Allotment;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class Change_Of_Password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        string UserId = "";
        connectionstring obj = new connectionstring();
        Encryption enc = new Encryption();
        protected void Page_Load(object sender, EventArgs e)
        {
           // pnlatrchidetails.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                UpdateCaptchaText();
                txtConfirmPassword.Attributes["type"] = "Password";
                txtNewPassword.Attributes["type"] = "Password";
            }
        }
        //btn_verify_Click
        public static bool ReCaptchaPassed(string gRecaptchaResponse)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync("https://www.google.com/recaptcha/api/siteverify?secret=6Lfm7NUiAAAAADge6J0NFvw1kiPzsCyQ3pQQo1Kd&response=" + gRecaptchaResponse + "").Result;

            if (res.StatusCode != HttpStatusCode.OK)
                return false;

            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);

            if (JSONdata.success != "true")
                return false;

            return true;
        }
        static string otp = "";
        public void GenerateOTP()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var Charsarr = new char[6];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            otp = resultString;
            //  lblOTP.Text = otp;
        }
        private void UpdateCaptchaText()
        {
               txtCode.Text = "";

        }
        protected void btn_verify_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["Pass_OTP"] as string))
                {
                    if (txtotp.Text.Trim() == Session["Pass_OTP"].ToString().Trim())
                    {

                        //service_num = Request.Cookies["service_num"].Value;
                        pnlotpverify.Visible = false;
                        // pnlatrchidetails.Visible = true;
                        lblmsg.Text = "You may reset your password now";
                        Session["Pass_OTP"] = null;
                        // bool i = obj.g_check_data("select Username FROM [dbo].UPSIDCUser WHERE Username='" + txtUserName.Text.Trim() + "' AND isnull(TempPassword,'') = ''");

                        Response.Redirect("~/RestPassword.aspx?UserName=" + enc.Encrypt(Session["UserName"].ToString().Trim()));

                    }
                    else
                    {
                        lblmsg.Text = "Invalid OTP ...Please Try Again";
                    }

                }
            }
            catch (Exception ex)
            {
               // Response.Redirect("Error.aspx");
            }

        }

        //OnClick="btnsave_Click"

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                {
                    if (Session["Captcha"].ToString() == Uri.EscapeDataString(txtCode.Text.Trim()))
                    {

                     //   if (ReCaptchaPassed(Request.Form["g-token"]))
                        {

                            UpdateCaptchaText();

                            if (txtNewPassword.Text == txtConfirmPassword.Text)
                            {
                                objServiceTimelinesBEL.UserName = Session["UserName"].ToString().Trim();
                                objServiceTimelinesBEL.Password = Uri.EscapeDataString(txtConfirmPassword.Text.Trim());
                                int retVal = objServiceTimelinesBLL.UpdatePassword(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    //string message = "Your Password Changed Successfully";
                                    // Session.Clear();
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage();", true);
                                    Response.Write("<script language=javascript>alert('Password has been reset successfully');</script>");
                                    Response.Redirect("Default.aspx");
                                }
                                else
                                {
                                    //string message = "Your Password couldn't be changed";
                                    Response.Write("<script language=javascript>alert('Your Password couldn't be changed');</script>");
                                }
                            }
                            else
                            {
                                //string message = "New Password & Confirm Password Not Matched";
                                Response.Write("<script language=javascript>alert('New Password & Confirm Password Not Matched');</script>");
                                return;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                //  Response.Write("<script>alert('OOPS!Something went wrong')</script>");
            }
            }
        }
    }

