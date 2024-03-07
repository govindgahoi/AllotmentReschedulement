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
    public partial class AddAllotmentNo : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string Usertype = "", pwd = "", dypPwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    //ClearAll();
                    //UpdateCaptchaText();
                    GetNewAllotteeDetails();
                }
            }
            else
            {                
                Response.Redirect("AllotteeLogin.aspx");
            }
        }

        #region "Bind Allotment in GridViewn"
        public void GetNewAllotteeDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            string Parameter = Session["AID"].ToString().Trim();
            DataSet dsAllottee = new DataSet();
            try
            {
                dsAllottee = objServiceTimelinesBLL.GetAlloteeDetailwithAID(Parameter);
                DataTable dt = dsAllottee.Tables[0];
                // DataTable dt1 = dsAllottee.Tables[1];
                Allotmentgrid.DataSource = dt;
                Allotmentgrid.DataBind();
                

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #endregion
        protected void ShowPopup(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                {

                    if (txtAllotmentNo.Text.Trim().Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter Allotment No');", true);
                        return;
                    }
                    objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text.Trim();
                    objServiceTimelinesBEL.MobileNo = txtmob.Text.Trim();
                    ds = objServiceTimelinesBLL.GetCheckAllotmentNo(objServiceTimelinesBEL);

                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lblAllotteeNO.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                        OTPMailSend(dt.Rows[0]["emailID"].ToString());
                        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "staticBackdrop();", true);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);

                        //}
                        //else
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Captcha');", true);
                        //    UpdateCaptchaText();
                        //    return;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "" + ex.StackTrace + "", true);
                //UpdateCaptchaText();
                return;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (Convert.ToString(Session["OTPR"]).Length == )
            if (Session["OTPALL"].ToString() == txtVerifyOTP.Text.Trim())
            {
                string pwd = "";
                try
                {


                    //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                    //{
                    //    string msg = "Kindly upload copy of office order";
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    //    return;
                    //}
                    //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                    // string filePath = "~/TrackApplication/" + Convert.ToString(Session["TracingName"]);
                    
                    objServiceTimelinesBEL.AllotmentNo = lblAllotteeNO.Text.Trim();                   
                    objServiceTimelinesBEL.PhoneNumber = txtmob.Text.Trim();

                    objServiceTimelinesBEL.AID = Convert.ToDecimal(Session["AID"].ToString());
                    int retVal = objServiceTimelinesBLL.UpdateAllotteeMassterAID(objServiceTimelinesBEL);
                   
                    if (retVal > 0)
                    {

                        
                        string msg = "Allotment Update Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        GetNewAllotteeDetails();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#testmodal').modal('hide');$('body').removeClass('modal-open');$('.modal-backdrop').remove(); ", true);
                        //Response.Redirect("AddAllotmentNo.aspx");
                        // return;
                    }
                    else
                    {
                        string msg = "Allottee Registration couldn't be done";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
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
            else
            {
                string msg = "OTP Not Matched";
                lblmsg.Text = "OTP Not Matched";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);

                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                return;
            }
        }

        public void OTPMailSend(string email)
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
            Session["OTPALL"] = otp.ToString();
            MailAddress mailfrom = new MailAddress("support@onlineupsidc.com");
           // MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
            MailAddress mailto = new MailAddress(email);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            //newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("OTPMail.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{UserName}", Session["AllotteeName"].ToString());
            StrContent = StrContent.Replace("{OTPFor}", "Allotment No.");
            StrContent = StrContent.Replace("{OTP}", otp.Trim());

            newmsg.Subject = "UPSIDA : OTP verification for Allotment No ";
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
           // client.Port = 587;
            //client.Username = mailfrom.Address;
            //client.Password = "upsida12345";
            //client.ConnectionProtocols = ConnectionProtocols.Ssl;
            //client.SendOne(newmsg);
        }
    }
}
