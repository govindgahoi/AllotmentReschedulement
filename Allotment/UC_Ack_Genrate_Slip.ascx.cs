using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
//using System.Net.Mail;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_Ack_Genrate_Slip : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        public string SerRequestNo { get; set; }
        public string AppTypeID { get; set; }
        public string StrSender { get; set; }
        public string DocID { get; set; }
        int ServiceID, UserId = 0;
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }
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

            if (SerRequestNo.Length > 0)
            {
                string[] SerArray = SerRequestNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);


                GetAllotteeDetail(SerRequestNo);
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
        }




        protected void btnSave_Genrate_Click(object sender, EventArgs e)
        {
            byte[] PdfInBytes = HtmlToByte();

            SqlCommand command;
            SqlTransaction transaction;
            bool transactionResult = true;


            if (AppTypeID == "1")
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_CloseAppointment", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@AppType", AppTypeID);
                    cmd.Parameters.AddWithValue("@DocID", DocID);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();
                        SendMailToApplicant(PdfInBytes);
                        this.Page.GetType().InvokeMember("MessagePlusRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { SerRequestNo, "Appointment Closed Successfully" });

                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        MessageBox1.ShowWarning(message);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.Message.ToString());

                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }

            }

            if (AppTypeID == "3")
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_CloseAppointment", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@AppType", AppTypeID);
                    cmd.Parameters.AddWithValue("@DocID", DocID);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();
                        SendMailToApplicant3(PdfInBytes);
                        this.Page.GetType().InvokeMember("MessagePlusRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { SerRequestNo, "Appointment Closed Successfully" });
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        MessageBox1.ShowWarning(message);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.Message.ToString());

                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }

            }

            if (AppTypeID == "2")
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_CloseAppointment", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@AppType", AppTypeID);
                    cmd.Parameters.AddWithValue("@DocID", DocID);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();
                        SendMailToApplicantObj(PdfInBytes);
                        this.Page.GetType().InvokeMember("MessagePlusRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { SerRequestNo, "Appointment Closed Successfully" });
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        MessageBox1.ShowWarning(message);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.Message.ToString());

                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }

            }
            if (AppTypeID == "5")
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_CloseAppointment_Transfer", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@AppType", AppTypeID);
                    cmd.Parameters.AddWithValue("@DocID", DocID);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        transaction.Commit();
                        SendMailToApplicantTransferar(PdfInBytes);
                        this.Page.GetType().InvokeMember("MessagePlusRedirectTransfer", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { SerRequestNo, "Appointment Closed Successfully" });
                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        MessageBox1.ShowWarning(message);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.Message.ToString());

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


            if (AppTypeID == "1")
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/DocAck.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();


                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForLeaseAck '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["Date"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string DAName = dt0.Rows[0]["DAName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{DAName}}", DAName);

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
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Lease Deed Document Acknowledgement Receipt";
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
                                <tr><th width='10%'> S.NO </th><th> Document description </th></tr>";
                        int i = 0;
                        foreach (DataRow dr in dt7.Rows)
                        {
                            i++;
                            html += "<tr><td> " + i.ToString() + " </td><td> " + dr["CheckListDesc"].ToString() + " </ td></tr> ";
                        }
                        html += "</table>";

                        htmlContent = htmlContent.Replace("{{DocList}}", html);
                    }
                    else
                    {

                        htmlContent = htmlContent.Replace("{{DocList}}", "No Record Found");

                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }
            if (AppTypeID == "3")
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/LeaseSigningAck.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();


                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForLeaseAck '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["Date"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string DAName = dt0.Rows[0]["DAName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{DAName}}", DAName);

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
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Lease Deed Execution Acknowledgement Receipt";
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
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }
            if (AppTypeID == "2")
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/LeaseObjectionClearAck.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();


                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForLeaseAck '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt2 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["Date"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string DAName = dt0.Rows[0]["DAName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{DAName}}", DAName);

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

                        if (dt2.Rows.Count > 0)
                        {
                            string Reason = dt2.Rows[0]["AppointmentDesc"].ToString();
                            string ObjDate = dt2.Rows[0]["CreationDate"].ToString();
                            htmlContent = htmlContent.Replace("{{Reason}}", Reason);
                            htmlContent = htmlContent.Replace("{{ObjDate}}", ObjDate);
                        }
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Acknowledgement Receipt of clearing objection for lease Deed execution";
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
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }
            if (AppTypeID == "5")
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/TransferAck.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();


                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForLeaseAck '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];
                    DataTable dt2 = ds.Tables[3];



                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["Date"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string DAName = dt0.Rows[0]["DAName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{DAName}}", DAName);

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

                        if (dt2.Rows.Count > 0)
                        {
                            string Reason = dt2.Rows[0]["AppointmentDesc"].ToString();
                            string ObjDate = dt2.Rows[0]["CreationDate"].ToString();
                            htmlContent = htmlContent.Replace("{{Reason}}", Reason);
                            htmlContent = htmlContent.Replace("{{ObjDate}}", ObjDate);
                        }
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Verification Acknowledgement for Trasnfer of Plot";
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
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            byte[] pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            return pdfBytes;

        }
        private void SendMailToApplicantTransferar(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + SerRequestNo + "', " + AppTypeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
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
                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/TransferVerificationAckSendMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{SerNo}", SerRequestNo.Trim());
                    StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IATransferOfPlotApplication.aspx?ServiceReqNo=" + SerRequestNo);

                    newmsg.Subject = "UPSIDCeServe: Acknowledgement for completion of physical verification of documents of transferar & transfree";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + ApplicantName + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant your documents for lease deed execution against service request no " + SerRequestNo + " has been received.For details please check your registered email id");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , PhoneNo},
                    //                    {"message" , message},
                    //                    //{"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}



                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.ToString());
                }

            }
        }
        private void SendMailToApplicant(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + SerRequestNo + "', " + AppTypeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
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
                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/DocAckSendMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{SerNo}", SerRequestNo.Trim());
                    StrContent = StrContent.Replace("{Link}", "http://localhost:2524/LeaseDeedApplication.aspx?ViewID=" + SerRequestNo);

                    newmsg.Subject = "UPSIDCeServe: Acknowledgement Receipt of documents for Lease Deed Execution ";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + ApplicantName + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant your documents for lease deed execution against service request no " + SerRequestNo + " has been received.For details please check your registered email id");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , PhoneNo},
                    //                    {"message" , message},
                    //                    //{"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}



                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.ToString());
                }

            }
        }

        private void SendMailToApplicant3(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + SerRequestNo + "', " + AppTypeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
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
                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/LeaseExecutionAckSendMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{SerNo}", SerRequestNo.Trim());
                    StrContent = StrContent.Replace("{Link}", "http://localhost:2524/LeaseDeedApplication.aspx?ViewID=" + SerRequestNo);

                    newmsg.Subject = "UPSIDCeServe: Acknowledgement for Lease Deed Execution ";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + ApplicantName + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);

                    string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant your documents for lease deed execution against service request no " + SerRequestNo + " has been received.For details please check your registered email id");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , PhoneNo},
                    //                    {"message" , message},
                    //                    //{"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}



                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.ToString());
                }

            }
        }

        private void SendMailToApplicantObj(byte[] PdfInBytes)
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + SerRequestNo + "', " + AppTypeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
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
                try
                {

                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);


                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ObjectionResolvedSendMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{SerNo}", SerRequestNo.Trim());
                    StrContent = StrContent.Replace("{Link}", "http://localhost:2524/LeaseDeedApplication.aspx?ViewID=" + SerRequestNo);

                    newmsg.Subject = "UPSIDCeServe: Acknowledgement of clearing objection raised on application";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(PdfInBytes), "" + ApplicantName + ".pdf"));
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    //String message = HttpUtility.UrlEncode("Dear Applicant your documents for lease deed execution against service request no " + SerRequestNo + " has been received.For details please check your registered email id");
                    //using (var wb = new WebClient())
                    //{
                    //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    //                    {
                    //                    {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                    //                    {"numbers" , PhoneNo},
                    //                    {"message" , message},
                    //                    //{"sender" , "UPSIDC"}
                    //                    });
                    //    resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    //}



                }
                catch (Exception ex)
                {
                    MessageBox1.ShowWarning(ex.ToString());
                }

            }
        }


    }
}