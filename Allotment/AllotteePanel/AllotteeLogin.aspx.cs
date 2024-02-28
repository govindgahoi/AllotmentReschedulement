using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment.AllotteePanel
{
    public partial class AllotteeLoginNew : System.Web.UI.Page
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
        public void ClearAll()
        {
            //lblMessage.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserid.Text = string.Empty;
        }
        private void UpdateCaptchaText()
        {
            txtCode.Text = string.Empty;
            Random randNum = new Random();

            //Store the captcha text in session to validate  
            Session["Captcha"] = randNum.Next(10000, 99999).ToString();
            imgCaptcha.ImageUrl = "~/ghCaptcha.ashx?" + Session["Captcha"];
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                //string dypPwd = Decrypto(pwd.ToString());


                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                {
                    if (Session["Captcha"].ToString() == txtCode.Text.Trim())
                    {
                        string designation = "";

                        //string sIPAddress = GetUserIP();
                        objServiceTimelinesBEL.UserName = txtUserid.Text.Trim();
                        objServiceTimelinesBEL.Password = txtPassword.Text.Trim();
                        //objServiceTimelinesBEL.Password = dypPwd.Trim();

                        if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
                        {
                            int retVal = objServiceTimelinesBLL.CheckLoginAllotte(objServiceTimelinesBEL);
                            if ((retVal == 0) & (objServiceTimelinesBEL.responseMessage.ToString() == "User successfully logged in"))
                            {
                                string strName = txtUserid.Text.Trim();

                                Session["UserId"] = strName;
                                Response.Redirect("Dashboard.aspx");


                            }
                            else
                            {
                                //lblMessage.Text = objServiceTimelinesBEL.responseMessage.ToString();
                                //lblMessage.ForeColor = System.Drawing.Color.Red;
                                UpdateCaptchaText();

                            }

                        }

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Captcha');", true);
                        UpdateCaptchaText();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}