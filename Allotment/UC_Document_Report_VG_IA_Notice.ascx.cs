using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using NReco.PdfGenerator;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using QRCoder;
using System.Drawing;
using System.Globalization;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_Document_Report_VG_IA_Notice : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public string SerRequestNo { get; set; }
        public string StrSender { get; set; }
        int ServiceID, UserId = 0;
        string AppDate = "";
        string IAName = "";
        string PlotArea = "";
        string PlotNumber = "";
        string AllotteeID = "";
        string TEFTimeperiod = "";
        string TEFdate = "";
        string TEFApprovalDatee_str = "";
        decimal Totalfees = 0;
        private SqlCommand cmd1;
        string spNoticeID = "";

        public void Page_Load(object sender, EventArgs e)
        {
            StrSender = "NewSystem";

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;
            checkAllotment();
            if (SerRequestNo.Length > 0)
            {
                string[] SerArray = SerRequestNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);

                GetAllotteeDetail(SerRequestNo);
            }
        }
        private void checkAllotment()
        {
            SqlCommand cmd = new SqlCommand("DetailsForNoticeID '" + SerRequestNo.Trim() + "'", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd);
            DataSet dsNotices = new DataSet();
            adp1.Fill(dsNotices);
            DataTable dtNotice = dsNotices.Tables[0];
            if (dtNotice.Rows.Count > 0)
            {
                spNoticeID = dtNotice.Rows[0]["NoticeID"].ToString();
            }
            else
            {
                spNoticeID = "";
            }

            string[] SerArray = SerRequestNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                // Plot Notice
                if (ServiceID == 1013)
                {
                     cmd1 = new SqlCommand("CheckNoticeLetter '" + SerRequestNo.Trim() + "','" + spNoticeID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
                    else
                    {
                        btn_Sign.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btn_Sign_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadSignedCopyNotice.aspx?ServiceReqNo=" + SerRequestNo + "&NoticeID=" + spNoticeID + "");
        }

        public void GetAllotteeDetail(string SerRequestNo)
        {
            byte[] PdfInBytes = HtmlToByte();
            String base64EncodedPdf = System.Convert.ToBase64String(PdfInBytes);

            string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""110%""  height=""550px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										  </object>";


            Literal ltEmbed = new Literal();
            ltEmbed.Text = string.Format(string.Format(embed, (base64EncodedPdf)));
            Placeholder.Controls.Add(ltEmbed);
        }


        protected void btnSave_Genrate_Click(object sender, EventArgs e)
        {
            

            byte[] PdfInBytes = HtmlToByte();
            SqlCommand command;
            SqlTransaction transaction;
            bool transactionResult = true;
            // Plot Canclation Notice
            if (ServiceID == 1013)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {
                    SqlCommand cmd = new SqlCommand("ReportGenration_PlotCancelationNotice", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@NoticeID", spNoticeID);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        checkAllotment();
                        return;
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }
            }
        }

        protected byte[] HtmlToByte()
        {
            string htmlContent = "";
            //Plot Cancelation  

            if (ServiceID == 1013)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Notice_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForNoticeLetter '" + SerRequestNo.Trim() + "','" + spNoticeID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt3 = ds.Tables[3];
                    DataTable dt4 = ds.Tables[4];


                    if (dt0.Rows.Count > 0)
                    {
                        decimal Outstanding = 0;
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string DateofIssueletter = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string Allotmentletterno = dt0.Rows[0]["Allotmentletterno"].ToString();
                        string AllotmentDate = dt0.Rows[0]["AllotmentDate"].ToString();
                        string LeaseDeedDate = dt0.Rows[0]["leasedeeddate"].ToString();
                        string Clause = dt0.Rows[0]["ClauseNumber"].ToString();
                        string NoticeDescription = dt0.Rows[0]["NoticeType"].ToString();
                        string NoticeVaildity = dt0.Rows[0]["NoticeVaildDate"].ToString();
                        string NoticeRefID = dt0.Rows[0]["NoticeID"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", DateofIssueletter);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{Allotmentletterno}}", Allotmentletterno);
                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{leasedeeddate}}", LeaseDeedDate);
                        htmlContent = htmlContent.Replace("{{ClauseNumber}}", Clause);
                        htmlContent = htmlContent.Replace("{{NoticeDescription}}", NoticeDescription);
                        htmlContent = htmlContent.Replace("{{NoticeVaildDate}}", NoticeVaildity);
                        htmlContent = htmlContent.Replace("{{NoticeID}}", NoticeRefID);

                        if (dt1.Rows.Count > 0)
                        {
                            string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                            string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                            string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                            string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                            string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                            htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                            htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                            htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                            htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                            htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                        }
                        if (dt3.Rows.Count > 0)
                        {
                            Outstanding = Convert.ToDecimal(dt3.Compute("SUM(Outstanding)", string.Empty));
                            htmlContent = htmlContent.Replace("{{Outstanding}}", Convert.ToDecimal(Outstanding).ToString());
                        }
                        string code = "ApplicationNo:" + SerRequestNo.Trim() + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
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

                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                    if (dt3.Rows.Count > 0)
                    {

                        string html = @"<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> Payment Head </th><th> Demanded </th><th> Paid </th><th> Oustanding </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt3.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["PaymentName"].ToString() + " </ td><td> " + dr["Demanded"].ToString() + " </ td><td> " + dr["Paid"].ToString() + " </ td><td> " + dr["Outstanding"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";
                        htmlContent = htmlContent.Replace("{{Ledger}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{Ledger}}", "");
                    }
                    if (dt4.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Copy To.";
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                        string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered ' style='width:100%;'>";
                        int i = 0;
                        foreach (DataRow dr in dt4.Rows)
                        {
                            i++;
                            html += "<tr><td width='5%'> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofAnnexresCopy}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexresCopy}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            byte[] pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            return pdfBytes;

        }

        private void SendMailToApplicant(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("Select * from AllotteeMaster where ref_AllotmentNo= '" + SerRequestNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string EmaiID = dt.Rows[0]["SignatoryEmail"].ToString();
                string PhoneNo = dt.Rows[0]["SignatoryPhone"].ToString();
                string Name = dt.Rows[0]["AuthorisedSignatory"].ToString();
                string letterno = dt.Rows[0]["Allotmentletterno"].ToString();
                string PlotNo = dt.Rows[0]["PlotNo"].ToString();

                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(EmaiID.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ServiceReqNoMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", Name.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant Your request for plot allotment is Completed.Your Plot No is " + PlotNo + " and Allotment letter No is " + letterno + "<br/><br/>We respect your patronage with us. ");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for Land Allotment ";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + Name + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Plot No is " + PlotNo + " and Allotment letter No is " + letterno + "");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , PhoneNo},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }



                }
                catch (Exception ex)
                {

                }

            }
        }


    }
}