using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;
using System.IO;
using System.Text;

namespace Allotment.AllotteePanel
{
    public partial class Forget_Password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           

         
            }
        }
       
        public void OTPMailSend(string emailid)
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
            MailAddress mailto = new MailAddress(emailid);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            //newmsg.IsBodyHtml = true;

            string StrContent = "";
            StreamReader reader = new StreamReader(Server.MapPath("OTPMail.html"));
            StrContent = reader.ReadToEnd();

            StrContent = StrContent.Replace("{UserName}", emailid);
            StrContent = StrContent.Replace("{OTPFor}", "forget Password");

            StrContent = StrContent.Replace("{OTP}", otp.Trim());

            newmsg.Subject = "UPSIDA : OTP verification for forget Password ";
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
           // client.ConnectionProtocols = ConnectionProtocols.Ssl;
            // client.SendOne(newmsg);
        }
        protected void ShowPopup_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtconfirmpassword.Text = "";
            string message = "";
            DataSet ds = new DataSet();
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    SqlCommand cmd = new SqlCommand("spLoginidCheckemailid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);

                    if (ds.Tables[0].Rows[0]["Returncode"].ToString() == "0")
                    {
                        lblmessage.InnerText = "Verify Otp";
                        message = "Invalid Email Id";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                        OTPMailSend(txtEmail.Text);
                        Session["email"] = txtEmail.Text;
                        confirmpassword.Visible = false;
                        lblmsg.Visible = true;
                        veryfy.Visible = true;
                        Button1.Text = "Verify";
                        lblmessage.InnerText = "Verify Otp";
                        lblmsg.Text = "  Please enter the Otp (One Time Password) Sent to your registered email id </br> This OTP will expire in 15 minutes.";

                    }
                    cmd.Dispose();
                }
                else
                {
                    message = "Please Enter Valid Email Address";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
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
                        lblmsg.Visible = false;
                        veryfy.Visible = false;
                        confirmpassword.Visible = true;
                        Button1.Text = "Save";
                        lblmessage.InnerText = "Change Password";
                        txtPassword.Text = "";
                        txtconfirmpassword.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                      
                    }

                    else
                    {
                        lblmessage.InnerText = "Verify Otp";
                        lblmsg.Text = "OTP Not Matched";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#testmodal').modal('show');</script>", false);
                        return;
                    }

                }
            }
           else if (Button1.Text == "Save")
            {
               
                    int result;
                    try
                    {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        SqlCommand cmd = new SqlCommand("[usp_updatepassword]", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@emailID", Session["email"].ToString());

                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        txtPassword.Text = "";
                        txtconfirmpassword.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgRegistrationRedirect();", true);
                  

                    }
                }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State != ConnectionState.Closed)
                        {
                            con.Close();
                        }
                    }
                }            
            }
        
    }
}   
        
