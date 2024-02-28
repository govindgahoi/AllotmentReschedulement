using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
//using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace UpsidaAllottee.RMPanel
{
    public partial class EAuction_UC_Document_Report_VG : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public string SerRequestNo { get; set; }


        public string StrSender { get; set; }
        int ServiceID, UserId = 0;

        public void Page_Load(object sender, EventArgs e)
        {
            StrSender = "NewSystem";

            try
            {
                //LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                //UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;


            checkAllotment();

            if (SerRequestNo.Length > 0)
            {
                GetAllotteeDetail(SerRequestNo);
                string[] SerArray = SerRequestNo.Split('/');
                //GetAllotteeDetail(SerRequestNo);
            }

        }


        private void checkAllotment()
        {
            string[] SerArray = SerRequestNo.Split('/');
            //ServiceID = int.Parse(SerArray[1]);
            try
            {
                SqlCommand cmd1 = new SqlCommand();

                cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='SER/EAUC/" + SerRequestNo + "' and DocType='Allotment'", con);

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
            catch (Exception)
            {

                throw;
            }

        }
        protected void btn_Sign_Click(object sender, EventArgs e)
        {

            string[] SerArray = SerRequestNo.Split('/');
            //ServiceID = int.Parse(SerArray[1]);
            //if (ServiceID == 1000)
            //{
            //    Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=AL");
            //}

          
                Response.Redirect("UploadSignedCopySbiEauction.aspx?ServiceReqNo=" + SerRequestNo + "&Type=AL");
            
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


            // Transfer Case
            if (true)
            {
                con.Open();
                command = con.CreateCommand();
                //transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                //command.Transaction = transaction;

                try
                {


                    //SqlCommand cmmd = new SqlCommand("validatemarkings '" + SerRequestNo + "'", con, transaction);
                    //SqlCommand cmmd = new SqlCommand("validatemarkings '" + "SER20190908/1000/3/199" + "'", con, transaction);
                    //SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
                    //DataSet dss = new DataSet();
                    //adpp.Fill(dss);
                    //DataTable dt1 = dss.Tables[1];
                    //if (dt1.Rows.Count > 0)
                    //{
                    //    if (dt1.Rows[0][1].ToString() == "False")
                    //    {
                    //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application Is Still pending for account clearance');", true);
                    //        return;
                    //    }
                    //}

                    //SqlCommand cmd = new SqlCommand("create_plot_Allotment_Data_MoveNew", con, transaction);
                    //create_plot_Allotment_Data_MoveNewEAuction12DecMashihuzzama
                    //create_plot_Allotment_Data_MoveNewSBI_EAuction

                    SqlCommand cmd = new SqlCommand("create_plot_Allotment_Data_MoveNewSBI_EAuction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                   if (!string.IsNullOrEmpty(SerRequestNo))
                   
                    {
                        //string ControlID = dt.Rows[0]["ControlId"].ToString();
                        //string UnitId = dt.Rows[0]["UnitId"].ToString();
                        //string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        //string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();

                        //transaction.Commit();
                        //if (ControlID.Length > 0)
                        //{
                        //    SWCControlID = ControlID;
                        //    SWCUnitID = UnitId;
                        //    SWCServiceID = ServiceID;

                        //    Status_Code = "15";
                        //    NOC_Certificate_Number = letterNo.Trim();
                        //    NOC_URL = "";
                        //    ISNOC_URL_ActiveYesNO = "Yes";

                        //    if (ServiceID.Trim() == "SC21001")
                        //    {
                        //        Remarks = "Land Allotment Process Completed";
                        //        NOC_URL = "http://eservices.onlineupsidc.com/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo=" + SerRequestNo.Trim()+"&DocType=Allotment";
                        //    }


                        //    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        //    string Update_Result = webService.WReturn_CUSID_STATUS(
                        //     SWCControlID,
                        //     SWCUnitID,
                        //     SWCServiceID,
                        //     ProcessIndustryID,
                        //     ApplicationID,
                        //     Status_Code,
                        //     Remarks,
                        //     Fee_Amount,
                        //     Fee_Status,
                        //     Transaction_ID,
                        //     Transaction_Date,
                        //     Transaction_Date_Time,
                        //     NOC_Certificate_Number,
                        //     NOC_URL,
                        //     ISNOC_URL_ActiveYesNO,
                        //     passsalt
                        //     );
                        //}
                        string message = "Allotment Letter Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        if (chkmail.Checked == true)
                        {
                            SendMailToApplicant(PdfInBytes);
                        }
                       checkAllotment();
                        return;
                    }
                    else
                    {
                      //  transaction.Rollback();
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

                    //transaction.Dispose();
                     Dispose();
                    con.Close();
                }
            }

        }






        protected byte[] HtmlToByte()
        {
            string htmlContent = "";


            // Land Allotment

            StreamReader reader = new StreamReader(Server.MapPath("/RMPanel/html/Allotment_Letter_View.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Sp_RMofficedetails'" + SerRequestNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                if (dt1.Rows.Count > 0)
                {

                    string RegionalOffice = dt1.Rows[0]["RegionalOffice"].ToString();
                    string IAName = dt1.Rows[0]["IAName"].ToString();


                    string RefNo = dt1.Rows[0]["Auction_Id"].ToString();
                    string PlotArea = dt1.Rows[0]["PlotArea"].ToString();
                    string AllotteeName = dt1.Rows[0]["Auction_brief"].ToString();
                    string PlotRate = dt1.Rows[0]["Winner_Price"].ToString();

                    htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);

                    string RegionalOfficee = dt0.Rows[0]["OfficeName"].ToString();
                    string OfficeAddress1 = dt0.Rows[0]["OfficeAddress1"].ToString();
                    string OfficeAddress2 = dt0.Rows[0]["OfficeAddress2"].ToString();
                    string OfficePhone = dt0.Rows[0]["OfficePhoneNo"].ToString();
                    string OfficeEmailId = dt0.Rows[0]["OfficeEmailId"].ToString();
                    string AppDate = dt1.Rows[0]["ApplicationDate"].ToString();
                    //string Rebate = dt1.Rows[0]["Rebate"].ToString();
                    htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOfficee);
                    htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                    htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                    htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                    htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    //lblRebate.Text = txtRebate.Text;



                    string AllotmentDate = dt1.Rows[0]["AllotmentDate"].ToString();
                    htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllotmentDate);









                    string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Allotment";
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
            }




            //    string html1 = "";

            //    if (dt1.Rows.Count > 0)
            //    {

            //        html1 = @"<table   Class='table table-hover table-bordered' style='width:100%;'>
            //            <tr style='border-bottom:1px solid #000;'><th align='center' style='border-bottom:1px solid #000;'>Installment No.</th><th align='center' style='border-bottom:1px solid #000;'> Due Date Of Installment </th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (Without Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Premium Due</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (Without Rebate)</th></tr>";
            //        foreach (DataRow dr in dt1.Rows)
            //        {

            //            html1 += "<tr><td align='center'>" + dr["S_no"].ToString() + "</td><td align='center'>" + dr["Duedate"].ToString() + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithoutRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["PremiumDue"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithoutRebate"]).ToString("N2") + "</td></tr>";
            //        }


            //        html1 += "</table>";
            //        htmlContent = htmlContent.Replace("{{Installments}}", html1);
            //    }
            //    if (dt1.Rows.Count > 0)
            //    {

            //        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms of allotment and binding on you.";
            //        htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
            //        string html = @"

            //<style>
            //.request-table tr{
            //    font-size: 12px;
            //    color: #2d2d2d;
            //    border: 1px solid #fff !important;
            //    text-align: left;
            //    font-weight:600;
            //    background: #e0e0e0;
            //    padding: 1px 6px !important;
            //}

            //.request-table tr th {
            //    font-size: 12px;
            //    background-color: #ffe600;
            //}

            //.request-table tr td a {
            //    color: #337ab7;
            //    font-weight: bold;
            //}
            //</style>
            //<table Class='table table-hover table-bordered request-table' style='width:100%;'>
            //                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
            //        int i = 0;
            //        foreach (DataRow dr in dt1.Rows)
            //        {
            //            i++;
            //            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
            //        }
            //        html += "</table>";

            //        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", html);
            //    }
            //    else
            //    {
            //        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", "");
            //        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
            //    }

            //}



            catch (Exception ex)
            {
                Response.Write(ex.Message);

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