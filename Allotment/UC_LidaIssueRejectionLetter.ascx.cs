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
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;


namespace Allotment
{
    public partial class UC_LidaIssueRejectionLetter : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public string Level = "";
        public string DataManager = "";

        public string SerRequestNo { get; set; }
        public string StrSender { get; set; }
        int ServiceID, UserId = 0;

        public void Page_Load(object sender, EventArgs e)
        {
            StrSender = "NewSystem";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserId = _objLoginInfo.userid;

                SqlCommand cmmd = new SqlCommand("Select Level,DataManager from tbl_LidaUserAssociationMaster where UserID=" + UserId + " and Isnull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }
            }
            catch { Response.Redirect("Default.aspx", false); }
            if (SerRequestNo.Length > 0)
            {
                string[] SerArray = SerRequestNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);

                GetAllotteeDetail(SerRequestNo);
                checkRejection();
                //    if (ServiceID == 1000)
                //    {
                //        SqlCommand cmd1 = new SqlCommand("Select SWCControlId,SWCUnitId,SWCServiceId from ApplicationRegister where ApplicationID='" + SerRequestNo + "'", con);
                //        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                //        DataTable dt1 = new DataTable();
                //        adp1.Fill(dt1);
                //        if (dt1.Rows.Count > 0)
                //        {
                //            ViewState["ControlID"] = dt1.Rows[0]["SWCControlId"].ToString();
                //            ViewState["UnitID"] = dt1.Rows[0]["SWCUnitId"].ToString();
                //            ViewState["ServiceID"] = dt1.Rows[0]["SWCServiceId"].ToString();
                //        }
                //    }
                //    if (ServiceID == 1 || ServiceID == 2 || ServiceID == 3)
                //    {
                //        SqlCommand cmd1 = new SqlCommand("Select ControlId,UnitId,ServiceId from AllotteeMaster where AllotteeID=" + SerArray[2].Trim() + "", con);
                //        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                //        DataTable dt1 = new DataTable();
                //        adp1.Fill(dt1);
                //        if (dt1.Rows.Count > 0)
                //        {
                //            ViewState["ControlID"] = dt1.Rows[0]["ControlId"].ToString();
                //            ViewState["UnitID"] = dt1.Rows[0]["UnitId"].ToString();
                //            ViewState["ServiceID"] = dt1.Rows[0]["ServiceId"].ToString();
                //        }
                //    }
                }
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
            // Placeholder.Controls.Add(imgBarCode);
        }




        protected void btnSave_Genrate_Click(object sender, EventArgs e)
        {
            SqlCommand cmod = new SqlCommand("Select * from tbl_AllotmentRejectionReason where servicerequestno='" + SerRequestNo + "'", con);
            SqlDataAdapter adop = new SqlDataAdapter(cmod);
            DataTable dto = new DataTable();
            adop.Fill(dto);

            if (dto.Rows.Count > 0)
            {
                byte[] PdfInBytes = HtmlToByte();

                // Allotment Rejection Case
                if (ServiceID == 3001 || ServiceID == 4002 || ServiceID == 5003)
                {
                    try
                    {

                        string return_string = "";

                        try { con.Open(); } catch { }

                        SqlCommand cmd = new SqlCommand("LidaRejectApplicationNewSp", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ServiceRequestNo", SerRequestNo);
                        cmd.Parameters.AddWithValue("@RejectedBY", UserId.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Role", DataManager.Trim());
                        cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                        cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            //if (ViewState["ControlID"].ToString().Length > 0)
                            //{
                            //    SWCControlID = ViewState["ControlID"].ToString();
                            //    SWCUnitID = ViewState["UnitID"].ToString();
                            //    SWCServiceID = ViewState["ServiceID"].ToString();
                            //    Status_Code = "07";
                            //    NOC_Certificate_Number = SerRequestNo.Trim();
                            //    NOC_URL = "";
                            //    ISNOC_URL_ActiveYesNO = "Yes";


                            //    Remarks = "Land Allotment Application Rejected";
                            //    NOC_URL = "http://eservices.onlineupsidc.com/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo=" + SerRequestNo.Trim() + "&DocType = Rejection";


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
                            //   );
                            //}
                            return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                            MessageBox1.ShowSuccess(return_string);
                            btnSave_Genrate.Enabled = false;
                            if (chkmail.Checked == true)
                            {
                                SendMailToApplicant(PdfInBytes);
                            }
                            checkRejection();
                            return;
                        }
                        else
                        {
                            return_string = "Opration Failed";
                            MessageBox1.ShowError(return_string);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox1.ShowError(ex.Message.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }

                }

                if (ServiceID == 1 || ServiceID == 2 || ServiceID == 3)
                {
                    try
                    {

                        string return_string = "";

                        try { con.Open(); } catch { }

                        SqlCommand cmd = new SqlCommand("RejectApplicationBuildngPlan_Sp", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ServiceRequestNo", SerRequestNo);
                        cmd.Parameters.AddWithValue("@RejectedBY", UserId.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Role", Level.Trim());
                        cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                        cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);




                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            //if (ViewState["ControlID"].ToString().Length > 0)
                            //{
                            //    SWCControlID = ViewState["ControlID"].ToString();
                            //    SWCUnitID = ViewState["UnitID"].ToString();
                            //    SWCServiceID = ViewState["ServiceID"].ToString();
                            //    Status_Code = "07";
                            //    NOC_Certificate_Number = SerRequestNo.Trim();
                            //    NOC_URL = "";
                            //    ISNOC_URL_ActiveYesNO = "Yes";


                            //    Remarks = "Application for Building Plan Rejected";
                            //    NOC_URL = "http://eservices.onlineupsidc.com/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo=" + SerRequestNo.Trim() + "&DocType = Rejection";


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
                            //   );
                            //}
                            return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                            MessageBox1.ShowSuccess(return_string);
                            btnSave_Genrate.Enabled = false;
                            if (chkmail.Checked == true)
                            {
                                SendMailToApplicant(PdfInBytes);
                            }
                            checkRejection();
                            return;
                        }
                        else
                        {
                            return_string = "Opration Failed";
                            MessageBox1.ShowError(return_string);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox1.ShowError(ex.Message.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }

                }


                
                if (ServiceID == 1001)
                {
                    try
                    {

                        string return_string = "";

                        try { con.Open(); } catch { }

                        SqlCommand cmd = new SqlCommand("RejectIAServiceApplication_Sp", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ServiceRequestNo", SerRequestNo);
                        cmd.Parameters.AddWithValue("@RejectedBY", UserId.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Role", Level.Trim());
                        cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                        cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);




                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            //if (ViewState["ControlID"].ToString().Length > 0)
                            //{
                            //    SWCControlID = ViewState["ControlID"].ToString();
                            //    SWCUnitID = ViewState["UnitID"].ToString();
                            //    SWCServiceID = ViewState["ServiceID"].ToString();
                            //    Status_Code = "07";
                            //    NOC_Certificate_Number = SerRequestNo.Trim();
                            //    NOC_URL = "";
                            //    ISNOC_URL_ActiveYesNO = "Yes";


                            //    Remarks = "Application for Building Plan Rejected";
                            //    NOC_URL = "http://eservices.onlineupsidc.com/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo=" + SerRequestNo.Trim() + "&DocType = Rejection";


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
                            //   );
                            //}
                            return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                            MessageBox1.ShowSuccess(return_string);
                            btnSave_Genrate.Enabled = false;
                            if (chkmail.Checked == true)
                            {
                                SendMailToApplicant(PdfInBytes);
                            }
                            checkRejection();
                            return;
                        }
                        else
                        {
                            return_string = "Opration Failed";
                            MessageBox1.ShowError(return_string);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox1.ShowError(ex.Message.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox1.ShowError("Kindly Mention Reason for Rejection");
                return;

            }
        }






        protected byte[] HtmlToByte()
        {
            string htmlContent = "";


            // Building Plan Construction
            if (ServiceID == 3001 || ServiceID == 4002 || ServiceID == 5003)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/LIdaTransferRejection.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    int i = 0;
                    int j = 0;
                    string html = "";
                    string html1 = "";
                    SqlCommand cmd = new SqlCommand("DetailsForLidaBuildingPlanRejection '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ServiceRequestNO"].ToString();
                        string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string project_name = dt0.Rows[0]["project_name"].ToString();
                        string block_no = dt0.Rows[0]["block_no"].ToString();
                        string plot_no = dt0.Rows[0]["plot_no"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        //string Address = dt0.Rows[0]["Address"].ToString();
                        string POName = dt0.Rows[0]["POName"].ToString();
                        string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{BlockNo}}", block_no);
                        htmlContent = htmlContent.Replace("{{ProjectName}}", project_name);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", plot_no);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        //htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{POName}}", POName);
                        htmlContent = htmlContent.Replace("{{AllotmentLetterNo}}", AllotmentLetterNo);

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


                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|ProjectName:" + project_name + "|DocType:Rejection";
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
                        html = @"

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
                                <tr><th width='10%'> S.NO </th><th> Reasons </th></tr>";

                        foreach (DataRow dr in dt2.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Clause"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";




                        htmlContent = htmlContent.Replace("{{ListofClause}}", html);
                    }





                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }

            

            if (ServiceID == 1026)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/SublettingofPlotRejection.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    int i = 0;
                    int j = 0;
                    string html = "";
                    string html1 = "";
                    SqlCommand cmd = new SqlCommand("DetailsForBuildingPlanRejection '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ServiceRequestNO"].ToString();
                        string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        string AllotmentLetterNo = dt0.Rows[0]["ApplicationID"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{AllotmentLetterNo}}", AllotmentLetterNo);

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


                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Rejection";
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
                        html = @"

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
                                <tr><th width='10%'> S.NO </th><th> Reasons </th></tr>";

                        foreach (DataRow dr in dt2.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Clause"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";




                        htmlContent = htmlContent.Replace("{{ListofClause}}", html);
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
            SqlCommand cmd = new SqlCommand();

            string[] SerIdarray = SerRequestNo.Split('|');
            string AllotteeID = SerIdarray[2].Trim();

            if (ServiceID == 1 || ServiceID == 2 || ServiceID == 3)
            {
                cmd = new SqlCommand("Select * from AllotteeMaster where AllotteeID= " + AllotteeID + "", con);
            }
            else if (ServiceID == 1000)
            {
                cmd = new SqlCommand("Select * from ApplicationRegister where ApplicationID= '" + SerRequestNo + "'", con);
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string EmaiID = dt.Rows[0]["SignatoryEmail"].ToString();
                string PhoneNo = dt.Rows[0]["SignatoryPhone"].ToString();
                string Name = dt.Rows[0]["AuthorisedSignatory"].ToString();

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
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant Your application no " + SerRequestNo + " for plot allotment has been rejected.<br/><br/>We respect your patronage with us. ");



                    newmsg.Subject = "UPSIDCeServe: Rejection of Land Allotment application";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + Name + "_Rejection" + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Application No " + SerRequestNo + " for land allotment in UPSIDC has been rejected");
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

        protected void btn_Sign_Click(object sender, EventArgs e)
        {

            SqlCommand cmod = new SqlCommand("Select * from tbl_AllotmentRejectionReason where servicerequestno='" + SerRequestNo + "'", con);
            SqlDataAdapter adop = new SqlDataAdapter(cmod);
            DataTable dto = new DataTable();
            adop.Fill(dto);

            if (dto.Rows.Count > 0)
            {

                string[] SerArray = SerRequestNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);
                if (ServiceID == 3001 || ServiceID == 4002 || ServiceID == 5003)
                {
                    Response.Redirect("UploadLidaSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=LBPR");
                }
            }
            else
            {
                MessageBox1.ShowError("Kindly Mention Reason for Rejection");
                return;
            }
        }

        private void checkRejection()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("Select * From Repository where  ServiceRequestNO='" + SerRequestNo + "' and DocType='Rejection'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string Bit = dt.Rows[0]["Generatedbit"].ToString();
                    if (ServiceID == 1 || ServiceID == 2)
                    {
                        if (Bit == "True")
                        {
                            btnSave_Genrate.Text = "Already Generated";
                            btnSave_Genrate.Enabled = false;
                            btn_Sign.Visible = true;
                        }
                        else
                        {
                            btnSave_Genrate.Enabled = true;

                        }
                    }
                    else
                    {
                        btnSave_Genrate.Text = "Already Generated";
                        btnSave_Genrate.Enabled = false;
                        btn_Sign.Visible = true;
                    }
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
    }
}