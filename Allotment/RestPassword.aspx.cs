using Allotment.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class RestPassword : System.Web.UI.Page
    {
        string NewPassword = string.Empty;
        string ConfirmNewPassword = string.Empty;
        string username = "";
        string usernamefromquery = "";
        connectionstring obj = new connectionstring();
        //Encryption enc = new Encryption();
        Encryption Enc = new Encryption();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    UpdateCaptchaText();
                   
                }

                if (Request.QueryString.HasKeys() == true)
                {
                    username = Session["UserName"].ToString().Trim();
                    usernamefromquery = Enc.Decrypt(Request.QueryString["UserName"].ToString());
                }
                else
                {
                      Response.Redirect("/Default.aspx");
                }
            }
            catch (Exception ex)
            {

            }

        }
    
       
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HashSalt hashSalt = HashSalt.GenerateSaltedHash(64, txtpassword1.Text);


                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
            {
                if (Session["Captcha"].ToString() == Uri.EscapeDataString(txtCode.Text.Trim()))
                {

                  //  if (ReCaptchaPassed(Request.Form["g-token"]))
                    {

                        UpdateCaptchaText();
                        NewPassword = txtpassword1.Text.Trim();
                        ConfirmNewPassword = txtpassword2.Text.Trim();
                        if (!string.IsNullOrEmpty(NewPassword) && !string.IsNullOrEmpty(ConfirmNewPassword) && NewPassword.Equals(ConfirmNewPassword))
                        {
                                int i =obj.g_dml_query("update UPSIDCUser set TempPassword='" + txtpassword1.Text.Trim()+ "',salted='"+txtpassword2.Text.Trim()+"' where UserName='"+ Session["UserName"].ToString().Trim() + "'");
                            if(i != 0 && i > 0)
                             {
                                Response.Redirect("/Default.aspx");
                              }
                            else
                                {
                                    Response.Write("<script>alert('Somthing Went Wrong');</script>");
                                }
                        }
                    }
                }
                else
                    {
                        UpdateCaptchaText();
                    }
            }
            else
                {
                    UpdateCaptchaText();
                }
            }
            catch (Exception ex) { }
        }

        protected void txtpassword2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["TempPassWord1"])))
            {
               // Session["TempPassWord1"] = txtpassword1.Text;
               // txtpassword1.Text = enc_data(txtpassword1.Text);
              //  txtpassword2.Text = enc_data(txtpassword2.Text);
            }
        }
    }
}