using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
//using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_CreateAppointments : System.Web.UI.UserControl
    {
        SqlConnection con;

        public string IAID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RegisterPostBackControl();
                string[] SerIdarray = ServiceReqNo.Split('/');

                AllotteeID = SerIdarray[2].Trim();

                Page.Form.Enctype = "multipart/form-data";


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }

                BindAppointmentToDdl();
                Get_Notesheet_of_service(ServiceReqNo);
            }
            catch (Exception ex) 
            {
                Response.Write("Oops! error occured -B :" + ex.Message.ToString());
            }



        }


        public void Get_Notesheet_of_service(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {

                dsR = objServiceTimelinesBLL.Get_AppointmentsWithAllottee(ServiceReqNo);
                if (dsR.Tables.Count > 0)
                {
                    DataTable dt = dsR.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }

        private void BindAppointmentToDdl()
        {
            SqlCommand cmd = new SqlCommand("GetAppointmenType '" + Level + "','"+ServiceReqNo+"'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                drpAppointmentType.DataSource = dt;
                drpAppointmentType.DataBind();
                drpAppointmentType.DataTextField = "StageDescription";
                drpAppointmentType.DataValueField = "ID";
                drpAppointmentType.DataBind();
                drpAppointmentType.Items.Insert(0, new ListItem("--Select--", "0"));


            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                if (drpAppointmentType.SelectedValue.Trim() == "0")
                {
                    MessageBox1.ShowInfo("Kindly Select Appointment Type");
                    return;
                }
                if (txtComment.Text == "")
                {
                    MessageBox1.ShowInfo("Kindly give your comments");
                    return;
                }


                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsToSetupAppointment '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                adp.Fill(dss);
                dt = dss.Tables[0];
                dt1 = dss.Tables[1];
                if (dt1.Rows.Count > 0)
                {
                    string SecAllow = dt.Rows[0]["AppAllow"].ToString();
                    string InspectionDoc = dt1.Rows[0]["InspectionReport"].ToString();
                    if (drpAppointmentType.SelectedValue == "1" || drpAppointmentType.SelectedValue == "3")
                    {
                        if (InspectionDoc.Length <= 0)
                        {
                            MessageBox1.ShowWarning("JE Site Inspection Has Not Completed yet");
                            return;
                        }
                    }
                    string POA = dt1.Rows[0]["POAAssigned"].ToString();
                    if (drpAppointmentType.SelectedValue == "3")
                    {
                        if (POA == "False" || POA == "")
                        {
                            MessageBox1.ShowWarning("POA Is Not Assigned yet");
                            return;
                        }
                        if(SecAllow=="NowAllow")
                        {
                            MessageBox1.ShowWarning("Kindly create appointment for document submission or if it has already been created then please close that appointment first");
                            return;
                        }
                    }
                    if (drpAppointmentType.SelectedValue == "4")
                    {
                        if (txtAppDate.Text == "")
                        {
                            MessageBox1.ShowWarning("Please Select Appointment Date");
                            return;
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.AppointmentType = Convert.ToInt32(drpAppointmentType.SelectedValue.Trim());
                    objServiceTimelinesBEL.AppointmentDesc = txtComment.Text.Trim();
                    objServiceTimelinesBEL.UserID = UserId;
                    if (drpAppointmentType.SelectedValue == "4")
                    {
                        string Date = DateTime.ParseExact(txtAppDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                        objServiceTimelinesBEL.PossessionAppointment = Convert.ToDateTime(Date);
                    }
                    else if (drpAppointmentType.SelectedValue == "1")
                    {
                        objServiceTimelinesBEL.DMCircle = txtDMCircle.Text;
                        objServiceTimelinesBEL.StampPaperAmount = Convert.ToDecimal(txtStampAmount.Text);
                    }
                    if (drpAppointmentType.SelectedValue.Trim() == "4")
                    {

                        ds = objServiceTimelinesBLL.CreateAppointmentForPossession(objServiceTimelinesBEL);
                    }
                    else
                    {
                        ds = objServiceTimelinesBLL.CreateAppointmentForLeaseDeed(objServiceTimelinesBEL);
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (drpAppointmentType.SelectedValue == "1")
                        {
                            FirstAppointment();
                        }
                        if (drpAppointmentType.SelectedValue == "3")
                        {
                            SignAppointment();
                        }
                        if (drpAppointmentType.SelectedValue == "4")
                        {
                            PossessionAppointment();
                        }
                        if (drpAppointmentType.SelectedValue == "2")
                        {
                            ObjectionAppointment();
                        }

                        MessageBox1.ShowInfo(ds.Tables[0].Rows[0][0].ToString());
                        drpAppointmentType.SelectedIndex = 0;
                        txtComment.Text = "";
                        Get_Notesheet_of_service(ServiceReqNo);
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Erron In Creating Appointment");
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].ToolTip = (e.Row.DataItem as DataRowView)["AppointmentDesc"].ToString();
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label Status = (e.Row.FindControl("lblStatus") as Label);
                LinkButton btn = (e.Row.FindControl("lnk") as LinkButton);


                if (Status.Text == "Pending")
                {
                    btn.Enabled = true;
                }
                else
                {
                    btn.Enabled = false;
                }
            }

        }


        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string val = GridView1.DataKeys[rowIndex].Values[1].ToString();
                string ID = GridView1.DataKeys[rowIndex].Values[0].ToString();
                this.Page.GetType().InvokeMember("Redirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { val, ID });
                // Response.Write("<script>window.open ('DocAck.aspx?ServiceReqNo=" + ServiceReqNo + "&AppType="+val+"','_blank');</script>");

            }
        }
        private void FirstAppointment()
        {

            try
            {
                string OfficeAddress1 = "";
                string OfficeAddress2 = "";
                string OfficePhone = "";
                string OfficeEmailId = "";
                byte[] pdfBytes;
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "'," + drpAppointmentType.SelectedValue + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                string htmlContent = "";

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string AllotteeAddress = dt.Rows[0]["Address"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string IssueDate = dt.Rows[0]["IssueDate"].ToString();
                    string RMName = dt.Rows[0]["RMName"].ToString();
                    string DMCircle = dt.Rows[0]["DMCircle"].ToString();
                    string StampAmount = dt.Rows[0]["StampAmount"].ToString();

                    if (dt1.Rows.Count > 0)
                    {

                        OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();

                    }



                    StreamReader reader1 = new StreamReader(Server.MapPath("/html/LeaseDeedIntimationLetter.html"));
                    htmlContent = reader1.ReadToEnd();
                    reader1.Close();

                    string code = "ApplicationNo:" + ServiceReqNo + "|ApplicantName:" + ApplicantName + "|IAName:" + IAName + "|DocType:LeaseDeedIntimation";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }

                    }

                    htmlContent = htmlContent.Replace("{{StampPaperAmuont}}", StampAmount);
                    htmlContent = htmlContent.Replace("{{CircleArea}}", DMCircle);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotNo);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", ApplicantName);
                    htmlContent = htmlContent.Replace("{{Address}}", AllotteeAddress);
                    htmlContent = htmlContent.Replace("{{RefNo}}", ServiceReqNo);
                    htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                    htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                    htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                    htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                    htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);

                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), "LeaseDeedChecklist.pdf"));

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/AppointmentMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{DAName}", DAName);
                    StrContent = StrContent.Replace("{ContactNo}", DAPhone);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{Date}", Date);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: " + drpAppointmentType.SelectedItem.Text.Trim();
                    newmsg.BodyHtml = StrContent;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    //string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant Your Application for Lease deed as been received kindly visit your concerning regional office within seven days to submit documents required for the execution of lease deed otherwise your application will be auto cancelled.");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , "7275379286"},
                    //                    {"message" , message}
                    //    //              {"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        private void SignAppointment()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "'," + drpAppointmentType.SelectedValue + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();


                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/AppointmentMailToSignLeaseDoc.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{DAName}", DAName);
                    StrContent = StrContent.Replace("{ContactNo}", DAPhone);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{Date}", Date);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: " + drpAppointmentType.SelectedItem.Text.Trim();
                    newmsg.BodyHtml = StrContent;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    //string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant Your Application for Lease deed as been received kindly visit your concerning regional office within seven days to submit documents required for the execution of lease deed otherwise your application will be auto cancelled.");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , "7275379286"},
                    //                    {"message" , message}
                    //    //              {"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }


        private void ObjectionAppointment()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "'," + drpAppointmentType.SelectedValue + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string ApplicationDate = dt.Rows[0]["ApplicationDate"].ToString();
                    string Desc = dt1.Rows[0]["AppointmentDesc"].ToString();


                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;
                    //Attachment att = new Attachment(Server.MapPath("PDF/DocViewerMinutes.pdf"));
                    //newmsg.Attachments.Add(att);
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/AppointmentMailToClarObjection.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{DAName}", DAName);
                    StrContent = StrContent.Replace("{ContactNo}", DAPhone);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{Date}", Date);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Application Date}", ApplicationDate);
                    StrContent = StrContent.Replace("{PlotNo}", PlotNo);
                    StrContent = StrContent.Replace("{IAName}", IAName);
                    StrContent = StrContent.Replace("{Reason}", Desc);
                    StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: " + drpAppointmentType.SelectedItem.Text.Trim();
                    newmsg.BodyHtml = StrContent;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);

                    //string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant Your Application for Lease deed as been received kindly visit your concerning regional office within seven days to submit documents required for the execution of lease deed otherwise your application will be auto cancelled.");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , "7275379286"},
                    //                    {"message" , message}
                    //    //              {"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        private void PossessionAppointment()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "'," + drpAppointmentType.SelectedValue + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string JEName = dt.Rows[0]["JEName"].ToString();
                    string JENo = dt.Rows[0]["JENO"].ToString();
                    string PAppDate = dt.Rows[0]["PossessionAppDate"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();





                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;
                    //Attachment att = new Attachment(Server.MapPath("PDF/DocViewerMinutes.pdf"));
                    //newmsg.Attachments.Add(att);
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/AppointmentMailToTakePossession.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{JEName}", JEName);
                    StrContent = StrContent.Replace("{IAName}", IAName);
                    StrContent = StrContent.Replace("{JEContactNo}", JENo);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{PlotNo}", PlotNo);
                    StrContent = StrContent.Replace("{Appdate}", PAppDate);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: " + drpAppointmentType.SelectedItem.Text.Trim();
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    //string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant Your Application for Lease deed as been received kindly visit your concerning regional office within seven days to submit documents required for the execution of lease deed otherwise your application will be auto cancelled.");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , "7275379286"},
                    //                    {"message" , message}
                    //    //              {"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void drpAppointmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpAppointmentType.SelectedValue.Trim() == "4")
            {
                DivPossession.Visible = true;
                StampDiv.Visible = false;
            }
            else if (drpAppointmentType.SelectedValue.Trim() == "1")
            {
                StampDiv.Visible = true;
                DivPossession.Visible = false;
            }
            else
            {
                DivPossession.Visible = false;
            }
        }
    }
}