using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class MDAppointmentRegistration : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        GeneralMethod gm = new GeneralMethod();
        string ID;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RegisterPostBackControl();
                bindDDLDistict();
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnUpload);
          
        }
    
     
      
        private void download(DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["contentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["ColName"].ToString() + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your name');", true);
                    return;
                }
                if (txtAddress.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your address');", true);
                    return;
                }
                if (txtMobileNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid mobile no');", true);
                    return;
                }
                if (txtEmail.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid email ID');", true);
                    return;
                }
                if (txtAppPurpose.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter purpose for appointment');", true);
                    return;
                }
                if (ddldistrict.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose concern district. If not choose NA');", true);
                    return;
                }

                if (ddlIA.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose concern industrial area. If not choose NA');", true);
                    return;
                }

                //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                //    Match match = regex.Match(txtEmail.Text);
                //if (match.Success)
                //{

                //}
                //else
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid email id found on your record. Kindly contact concern regional office.');", true);
                //    return;
                //}
                if (btnSubmit.Text.Trim() == "Resend OTP")
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



                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(txtEmail.Text.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", txtName.Text.Trim());
                    StrContent = StrContent.Replace("{OTP}", otp.Trim());
                    StrContent = StrContent.Replace("{Service}", "registration of appointment with CEO UPSIDA");


                    newmsg.Subject = "UPSIDAeService: OTP verification for registration of appointment with CEO UPSIDA";
                    newmsg.BodyHtml = StrContent;


                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    //smtp.EnableSsl = true;
                    //smtp.Send(newmsg);

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);

                    String message = HttpUtility.UrlEncode("Dear " + txtName.Text + " OTP for registration of appointment with CEO UPSIDA is " + otp + "");
                    string s = gm.SendOTP("OTP", txtMobileNo.Text, txtName.Text.Trim(), message);


                    ViewState["OTP"] = otp;
                    string input = txtEmail.Text.Trim();
                    string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                    string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                    string Output2 = Regex.Replace(txtMobileNo.Text.Trim(), @"\d(?!\d{0,3}$)", "X");
                    string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    Otp_MobileDiv.Visible = true;
                    txtAddress.Enabled = false;
                    txtName.Enabled = false;
                    txtMobileNo.Enabled = false;
                    txtEmail.Enabled = false;
                    FileUploadLoaction.Enabled = false;
                    txtAppPurpose.Enabled = false;
                    btnUpload.Enabled = false;
                    btnSubmit.Text = "Resend OTP";
                    return;
                }
                else
                {
                    string filePath = "";
                    objServiceTimelinesBEL.ApplicantName = txtName.Text.Trim();
                    objServiceTimelinesBEL.Address       = txtAddress.Text.Trim();
                    objServiceTimelinesBEL.MobileNumber  = txtMobileNo.Text.Trim();
                    objServiceTimelinesBEL.emailID       = txtEmail.Text.Trim();
                    objServiceTimelinesBEL.Remarks       = txtAppPurpose.Text.Trim();
                    if (Convert.ToString(Session["DocName"]).Length > 0)
                    {
                        filePath = "~/CEOAppointmentDocs/" + Convert.ToString(Session["DocName"]);
                    }
                    else
                    {
                        filePath = "";
                    }
                    objServiceTimelinesBEL.DocPath       = filePath.Trim();
                    objServiceTimelinesBEL.DistrictName  = ddldistrict.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.IAName        = ddlIA.SelectedItem.Text.Trim();

                    DataSet result = objServiceTimelinesBLL.SaveCEOAppointmentDetails(objServiceTimelinesBEL);

                    if (result.Tables[0].Rows.Count > 0)
                    {
                        ViewState["ID"] = result.Tables[0].Rows[0][0].ToString();

                        if (Convert.ToString(Session["DocName"]).Length > 0)
                        {
                            File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        }
                        else
                        {
                           
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
                        MailAddress mailto = new MailAddress(txtEmail.Text.Trim());
                        MailMessage newmsg = new MailMessage(mailfrom, mailto);

                       // newmsg.IsBodyHtml = true;

                        string StrContent = "";
                        StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                        StrContent = reader.ReadToEnd();

                        StrContent = StrContent.Replace("{UserName}", txtName.Text.Trim());
                        StrContent = StrContent.Replace("{OTP}", otp.Trim());
                        StrContent = StrContent.Replace("{Service}", "registration of appointment with CEO UPSIDA");


                        newmsg.Subject = "UPSIDAeService: OTP verification for registration of appointment with CEO UPSIDA";
                        newmsg.BodyHtml = StrContent;


                        //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        //smtp.UseDefaultCredentials = false;
                        //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                        //smtp.EnableSsl = true;
                        //smtp.Send(newmsg);

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.outlook.com";
                        client.Port = 587;
                        client.Username = mailfrom.Address;
                        client.Password = "upsida12345";
                        client.ConnectionProtocols = ConnectionProtocols.Ssl;
                        client.SendOne(newmsg);



                        String message = HttpUtility.UrlEncode("Dear " + txtName.Text + " OTP for registration of appointment with CEO UPSIDA is " + otp + "");
                        string s = gm.SendOTP("OTP", txtMobileNo.Text, txtName.Text.Trim(), message);


                        ViewState["OTP"] = otp;
                        string input = txtEmail.Text.Trim();
                        string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                        string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                        string Output2 = Regex.Replace(txtMobileNo.Text.Trim(), @"\d(?!\d{0,3}$)", "X");
                        string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                        Otp_MobileDiv.Visible = true;
                        txtAddress.Enabled = false;
                        txtName.Enabled = false;
                        txtMobileNo.Enabled = false;
                        txtEmail.Enabled = false;
                        FileUploadLoaction.Enabled = false;
                        txtAppPurpose.Enabled = false;
                        btnUpload.Enabled = false;
                        btnSubmit.Text = "Resend OTP";
                        return;

                    }
                    else
                    {
                        string message1 = "Unable To send OTP Kindly Update your EmailID";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                        Otp_MobileDiv.Visible = false;
                        ViewState["OTP"] = "";
                        return;
                    }
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

 
        private void SendMailUPSIDC(string Email)
        {

            try
            {


                string Mail = Email.Trim();


              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(Mail);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;


                if (Convert.ToString(Session["DocName"]).Length > 0)
                {
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(ViewState["Docs"] as byte[]), "UploadedDocument.pdf"));
                }
                else
                {

                }

                
               

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/CEOAppointmentConfirmation.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{UserName}", txtName.Text.Trim());
                StrContent = StrContent.Replace("{id}", ViewState["ID"].ToString().Trim());


                string html = @"<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>" +
                               "<tr><td>Name of Person</td><td>" + txtName.Text + "</td></tr>"+
                               "<tr><td>Address</td><td>" + txtAddress.Text + "</td></tr>" +
                               "<tr><td>Mobile No</td><td>" + txtMobileNo.Text + "</td></tr>" +
                               "<tr><td>Email ID</td><td>" + txtEmail.Text + "</td></tr>" +
                               "<tr><td>Purpose</td><td>" + txtAppPurpose.Text + "</td></tr>" +
                               "<tr><td>Concern District</td><td>" + ddldistrict.SelectedItem.Text + "</td></tr>" +
                               "<tr><td>Concern Industrial Area</td><td>" + ddlIA.SelectedItem.Text + "</td></tr>" +
                               "</table>";
                StrContent = StrContent.Replace("{Table}", html.Trim());
                newmsg.Subject = "Intimation of Submission of Request/Registration of Appointment with CEO UPSIDA";
                newmsg.BodyHtml = StrContent;

                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                //smtp.EnableSsl = true;
                //smtp.Send(newmsg);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);

            }
            catch (Exception ex)
            {

            }
        }
        
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("MDAppointmentRegistration.aspx");
        }


        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                int maxFileSize = 1;

                if (FileUploadLoaction.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath    = FileUploadLoaction.PostedFile.FileName;
                    string filename    = Path.GetFileName(filePath);
                    string ext         = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize       = FileUploadLoaction.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }
                   

                    //Set the contenttype based on File Extension
                    switch (ext)
                    {
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;
                        case ".PDF":
                            contenttype = "application/pdf";
                            break;
                    }

                    if (contenttype != String.Empty && ext == ".pdf")
                    {

                        Stream fs = FileUploadLoaction.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.LAName     = filename;
                        objServiceTimelinesBEL.content    = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;

                        Session["DocName"]        = objServiceTimelinesBEL.LAName;
                        Session["DocExt"]         = objServiceTimelinesBEL.content;
                        Session["Doc"]            = objServiceTimelinesBEL.Uploadfile;
                        ViewState["Docs"] = objServiceTimelinesBEL.Uploadfile;
                        lbluploadingMsg.Text      = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible   = true;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        lbluploadingMsg.Visible = true;
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                    lbluploadingMsg.Visible = true;
                    return;
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btn_EnterMobileOtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMobOtp.Text.Trim() == ViewState["OTP"].ToString().Trim())
                {

                    if (txtName.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your name');", true);
                        return;
                    }
                    if (txtAddress.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your address');", true);
                        return;
                    }
                    if (txtMobileNo.Text.Trim().Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid mobile no');", true);
                        return;
                    }
                    if (txtEmail.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter valid email ID');", true);
                        return;
                    }
                    if (txtAppPurpose.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter purpose for appointment');", true);
                        return;
                    }
                    if (ddldistrict.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose concern district. If not choose NA');", true);
                        return;
                    }

                    if (ddlIA.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose concern industrial area. If not choose NA');", true);
                        return;
                    }


                    objServiceTimelinesBEL.IAID = ViewState["ID"].ToString().Trim();

                    int result = objServiceTimelinesBLL.UpdateCeoAppointmentDetails(objServiceTimelinesBEL);
                    if(result>0)
                    {
                        SendMailUPSIDC(txtEmail.Text.Trim());
                        ViewState["ID"]    = "";
                        ViewState["OTP"]   = "";
                        ViewState["Docs"]  = "";
                        Session["DocName"] = "";
                        Session["DocExt"]  = "";
                        Session["Doc"]     = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect();", true);
                      
                        
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


        private void bindDDLDistict()
        {
           
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllDistrictRecords(objServiceTimelinesBEL);
                ddldistrict.DataSource     = ds;
                ddldistrict.DataTextField  = "District";
                ddldistrict.DataValueField = "DistrictCode";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.Items.Insert(1, new ListItem("NA", "00"));
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }


        }
        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.IAID = ddldistrict.SelectedValue.Trim();
                ds = objServiceTimelinesBLL.GetAllIADistrictWise(objServiceTimelinesBEL);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "ID";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlIA.Items.Insert(1, new ListItem("NA", "00"));
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }
        }
    }
}