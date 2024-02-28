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

namespace Allotment
{
    public partial class UC_Document_Report_VG : System.Web.UI.UserControl
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

                if (ServiceID == 4)
                {
                    try
                    {

                        SqlCommand cmd2 = new SqlCommand("Select *  From ServiceCustomSetApplicantData where ServiceRequestNO='" + SerRequestNo + "'", con);
                        SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            string LevyType = dt2.Rows[0]["LeavyType"].ToString();
                            if (LevyType == "LumpSum")
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowLumpSum();", true);
                            }
                            else if (LevyType == "Installment")
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowInstallment();", true);
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }


                GetAllotteeDetail(SerRequestNo);
            }

        }


        private void checkAllotment()
        {
            string[] SerArray = SerRequestNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                if (ServiceID == 1 || ServiceID == 2)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='BuildingPlan'", con);
                }
                if (ServiceID == 1000)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Allotment'", con);
                }
                if (ServiceID == 4)
                {
                    cmd1 = new SqlCommand("Select *  From Repository where ServiceRequestNO='" + SerRequestNo + "' and DocType='Transfer'", con);
                }
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
            ServiceID = int.Parse(SerArray[1]);
            if (ServiceID == 1000)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=AL");
            }
            if (ServiceID == 4)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=TR");
            }
            if (ServiceID == 1 || ServiceID == 2)
            {
                Response.Redirect("UploadSignedCopy.aspx?ServiceReqNo=" + SerRequestNo + "&Type=BP");
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


            // Building Plan Construction
            if (ServiceID == 1 || ServiceID == 2)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_BP_ConstructioAndComplition", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();


                        transaction.Commit();

                        //if (ControlID.Length > 0)
                        //{
                        //    SWCControlID = ControlID;
                        //    SWCUnitID = UnitId;
                        //    SWCServiceID = ServiceID;                              
                        //    Status_Code = "15";
                        //    NOC_Certificate_Number = letterNo.Trim();
                        //    NOC_URL = "";
                        //    ISNOC_URL_ActiveYesNO = "Yes";

                        //    if (ServiceID.Trim() == "SC21002")
                        //    {
                        //        Remarks = "Building Plan Approval Process Completed";
                        //        NOC_URL = "http://eservices.onlineupsidc.com/LetterView_ByServiceRequestNo.aspx?ServiceRequestNo=" + SerRequestNo.Trim()+"DocType=BuildingPlan";
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


            // Transfer Case
            if (ServiceID == 1000)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {


                    SqlCommand cmmd = new SqlCommand("validatemarkings '" + SerRequestNo + "'", con, transaction);
                    SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
                    DataSet dss = new DataSet();
                    adpp.Fill(dss);
                    DataTable dt1 = dss.Tables[1];
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0][1].ToString() == "False")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application Is Still pending for account clearance');", true);
                            return;
                        }
                    }

                    SqlCommand cmd = new SqlCommand("create_plot_Allotment_Data_MoveNew", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string ControlID = dt.Rows[0]["ControlId"].ToString();
                        string UnitId = dt.Rows[0]["UnitId"].ToString();
                        string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        string letterNo = dt.Rows[0]["Allotmentletterno"].ToString();

                        transaction.Commit();
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
            if (ServiceID == 4)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("[create_plot_Allotment_Data_Move_New]", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
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
                        transaction.Rollback();
                        string message = "Report couldnt be  Save ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);



                    //Response.Redirect("" + ex.StackTrace + "");
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

                finally
                {

                    transaction.Dispose();
                    con.Close();
                }
            }





            // Plot Cancelation

            if (ServiceID == 1001)
            {
                con.Open();
                command = con.CreateCommand();
                transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;

                try
                {

                    SqlCommand cmd = new SqlCommand("ReportGenration_plot_Cancelation", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Service_Request_No", SerRequestNo);
                    cmd.Parameters.AddWithValue("@ContentType", "application/pdf");
                    cmd.Parameters.AddWithValue("@DocumentInByte", PdfInBytes);
                    cmd.Parameters.AddWithValue("@UserId", UserId);


                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        transaction.Commit();
                        string message = "Report Generated ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
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


            // Building Plan Construction
            if (ServiceID == 1)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Building_Plan_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForBuildingPlanLetter '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

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
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
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



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }


            // Building Plan Complition
            if (ServiceID == 2)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Building_Plan_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();


                try
                {

                    SqlCommand cmd = new SqlCommand("DetailsForBuildingPlanLetter '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt7 = ds.Tables[2];


                    if (dt0.Rows.Count > 0)
                    {
                        string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                        string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                        string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["Address"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();

                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                        htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);

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
                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:BuildingPlan";
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


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
            }

            // Transfer Case
            if (ServiceID == 4)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Transfer_Letter.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    SqlCommand cmd = new SqlCommand("GetTransferLetterNew '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];
                    DataTable dt7 = ds.Tables[6];


                    string txtVerifiedPlot = "";
                    if (dt0.Rows.Count > 0)
                    {

                         txtVerifiedPlot = dt0.Rows[0]["PlotNo"].ToString();
                        string txtPlotSizeVerify = dt0.Rows[0]["PlotSize"].ToString();
                        string txtRateOfPlotVerified = dt0.Rows[0]["RateofPlot"].ToString();
                        string txtInterestRateVerified = dt0.Rows[0]["InterestRate"].ToString();

                        string txtTransferLevyVerified = dt0.Rows[0]["Transfer_Levy_Percentage"].ToString();
                        string txtPremiumVerified = dt0.Rows[0]["Premium"].ToString();
                        string txtIntOnPremiumVerified = dt0.Rows[0]["IntOnPremium"].ToString();
                        string txtMaintenanceChargeVerified = dt0.Rows[0]["MaintenanceCharge"].ToString();
                        string txtIntOnMaintenanceCharge = dt0.Rows[0]["IntOnMaintenanceCharge"].ToString();
                        string txtLeaseRentVerified = dt0.Rows[0]["LeaseRent"].ToString();
                        string txtGSTOnLeaseRentVerified = dt0.Rows[0]["GSTOnLeaseRent"].ToString();
                        string txtTEFVerified = dt0.Rows[0]["TEF"].ToString();
                        string txtIntOnTEFVerified = dt0.Rows[0]["IntOnTEF"].ToString();
                        string TotalDue = dt0.Rows[0]["TotalBalanceDues"].ToString();

                        string lbblPlotNo = dt0.Rows[0]["PlotNo"].ToString();
                        string lbblPlotSize = dt0.Rows[0]["PlotSize"].ToString();
                        string lblRateOfPlot = dt0.Rows[0]["RateofPlot"].ToString();
                        string lblInterestRate = dt0.Rows[0]["InterestRate"].ToString();
                        string lblTransferLevy = dt0.Rows[0]["Transfer_Levy_Percentage"].ToString();

                        string txtAgreementDateVerified= dt0.Rows[0]["AgreementDate"].ToString();
                        string txtPossessionDateVerified = dt0.Rows[0]["PossessionDate"].ToString();
                        string txtLeaseDeedDateVerified = dt0.Rows[0]["LeaseDeedDate"].ToString();
                        string txtLeaseRent1 = dt0.Rows[0]["LeaseRent1"].ToString();
                        string txtLeaseRent2 = dt0.Rows[0]["LeaseRent2"].ToString();
                        string txtLeaseRent3 = dt0.Rows[0]["LeaseRent3"].ToString();
                        string txtTreasuryNameVerified = dt0.Rows[0]["TreasuryName"].ToString();
                        string txtAllotmentDateVerified = dt0.Rows[0]["AllotmentDate"].ToString();

                        htmlContent = htmlContent.Replace("{{lblInterestPerAnnum}}", txtInterestRateVerified);
                        htmlContent = htmlContent.Replace("{{LeaseRent1}}", txtLeaseRent1);
                        htmlContent = htmlContent.Replace("{{LeaseRent2}}", txtLeaseRent2);
                        htmlContent = htmlContent.Replace("{{LeaseRent3}}", txtLeaseRent3);
                        htmlContent = htmlContent.Replace("{{DistTreasury}}", txtTreasuryNameVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_Intt_TEF}}", txtIntOnTEFVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_TEF}}", txtTEFVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_GST_Lease}}", txtGSTOnLeaseRentVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_Lease}}", txtLeaseRentVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_Intt_Maint}}", txtIntOnMaintenanceCharge);
                        htmlContent = htmlContent.Replace("{{lblDue_Maint}}", txtMaintenanceChargeVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_Intt_Premium}}", txtIntOnPremiumVerified);
                        htmlContent = htmlContent.Replace("{{lblDue_Premium}}", txtPremiumVerified);
                        htmlContent = htmlContent.Replace("{{lblTotalBalanceDues}}", TotalDue);
                        htmlContent = htmlContent.Replace("{{lblPlotSize}}", lbblPlotSize);
                        htmlContent = htmlContent.Replace("{{lblPlotRate}}", lblRateOfPlot);
                        htmlContent = htmlContent.Replace("{{lblTransferLevyPer}}", lblTransferLevy);
                        htmlContent = htmlContent.Replace("{{lblPlotNo}}", txtVerifiedPlot);
                        htmlContent = htmlContent.Replace("{{lbl_existing_allotment_transfer_dated}}", txtAllotmentDateVerified);
                        htmlContent = htmlContent.Replace("{{lbl_Agreement_dated}}", txtAgreementDateVerified);
                        htmlContent = htmlContent.Replace("{{lbl_Possession_Memo_dated}}", txtPossessionDateVerified);
                        htmlContent = htmlContent.Replace("{{lbl_Lease_Deed_dated}}", txtLeaseDeedDateVerified);
                    }


                    if (dt1.Rows.Count > 0)
                    {
                        string transfreeName = dt1.Rows[0]["TransfreeName"].ToString();
                        string transfreeAddress = dt1.Rows[0]["SignatoryAddress"].ToString();
                        string transferarAddress = dt1.Rows[0]["TransferorAddress"].ToString();
                        string refno = dt1.Rows[0]["ServiceReqNo"].ToString();
                        string IANAme = dt1.Rows[0]["IndustrialArea"].ToString();
                        string IssueDate = dt1.Rows[0]["IssueDate"].ToString();
                        string AppDate = dt1.Rows[0]["ApplicationDate"].ToString();
                        string IndustryType = dt1.Rows[0]["IndustryType"].ToString();
                        string RMName = dt1.Rows[0]["RMName"].ToString();
                        string AllotmentLetter = dt1.Rows[0]["AllotmentletterNo"].ToString();              
                        string TransferorName = dt1.Rows[0]["TransferorName"].ToString();
                        string FirstAllotmentDate = dt1.Rows[0]["FirstAllotmentDate"].ToString();

                        htmlContent = htmlContent.Replace("{{lblTransfereeAddress}}", transfreeAddress);
                        htmlContent = htmlContent.Replace("{{lblRefno}}", refno);
                        htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                        htmlContent = htmlContent.Replace("{{lblDocumentIssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{lblRefDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                        htmlContent = htmlContent.Replace("{{lblIndustryType}}", IndustryType);
                        htmlContent = htmlContent.Replace("{{lblRMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{lbl_first_allotment_dated}}", FirstAllotmentDate);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{lblTransfereename}}", transfreeName);
                        htmlContent = htmlContent.Replace("{{lblTransferorname}}", TransferorName);
                        htmlContent = htmlContent.Replace("{{lblTransfereeAddress}}", transfreeAddress);
                        htmlContent = htmlContent.Replace("{{lblTransferarAddress}}", transferarAddress);
                        htmlContent = htmlContent.Replace("{{lblRefno}}", refno);
                        htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                        htmlContent = htmlContent.Replace("{{lblDocumentIssueDate}}", IssueDate);
                        htmlContent = htmlContent.Replace("{{lblRefDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                        htmlContent = htmlContent.Replace("{{lblIndustryType}}", IndustryType);
                        htmlContent = htmlContent.Replace("{{lblRMName}}", RMName);
                        htmlContent = htmlContent.Replace("{{lblallotmentletterno}}", AllotmentLetter);
                      


                        string code = "ApplicationNo:" + SerRequestNo + "|Transfree:" + transfreeName + "|IAName:" + IANAme + "|PlotNo:" + txtVerifiedPlot + "|DocType:PlotTransfer";
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


                    if (dt2.Rows.Count > 0)
                    {
                        string RegionalOffice = dt2.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt2.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt2.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt2.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt2.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
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

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }


            }


            // Land Allotment
            if (ServiceID == 1000)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Allotment_Letter_View.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("GetAllotmentLetterNew'" + SerRequestNo + "'", con);
                    //if (StrSender == "NewSystem") { cmd = new SqlCommand("GetAllotmentLetterNew'" + SerRequestNo + "'", con); } else { cmd = new SqlCommand("GetAllotmentLetter'" + SerRequestNo + "'", con); }

                    //cmd = new SqlCommand("GetAllotmentLetter '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];
                    DataTable dt4 = ds.Tables[4];
                    DataTable dt6 = ds.Tables[6];
                    DataTable dt7 = ds.Tables[7];


                    if (dt0.Rows.Count > 0)
                    {
                        string RegionalOffice = dt0.Rows[0]["RegionalOffice"].ToString();
                        string RefNo = dt0.Rows[0]["ServiceReqNo"].ToString();
                        string AllotmentDate = dt0.Rows[0]["AllotmentDate"].ToString();
                        string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                        string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                        string product = dt0.Rows[0]["IndustryType"].ToString();
                        string PlotArea = dt0.Rows[0]["PlotSize"].ToString();
                        string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                        string Address = dt0.Rows[0]["SignatoryAddress"].ToString();
                        string RMName = dt0.Rows[0]["RMName"].ToString();
                        
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);

                        htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                        htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                        htmlContent = htmlContent.Replace("{{Product}}", product);
                        htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                        htmlContent = htmlContent.Replace("{{Address}}", Address);
                        htmlContent = htmlContent.Replace("{{RMName}}", RMName);


                        string code = "ApplicationNo:" + SerRequestNo + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:LandAllotment";
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

                    if (dt4.Rows.Count > 0)
                    {
                        string Chooseplot = dt4.Rows[0]["PlotNo"].ToString();
                        string ChoosePlotArea = dt4.Rows[0]["PlotSize"].ToString();
                        string PlotRateVerified = dt4.Rows[0]["RateOfPlot"].ToString();
                        string FirstInstallmentDate = dt4.Rows[0]["FirstInstallmentDate"].ToString();
                        string ConstructionValueVerified = dt4.Rows[0]["ConstructionValue"].ToString();
                        string ReservationMoneyVerified = dt4.Rows[0]["RegistrationMoneyRate"].ToString();
                        string EmdRatePerVerified = dt4.Rows[0]["EMDRate"].ToString();
                        string EmdDepositDaysVerified = dt4.Rows[0]["EMDDepositDays"].ToString();
                        string LocationChargeRateVerified = dt4.Rows[0]["LocationChargeRs"].ToString();
                        string ChargePerVerified = dt4.Rows[0]["LocationChage"].ToString();
                        string RemPremiumPerVerified = dt4.Rows[0]["RemPremiumPer"].ToString();
                        string Installment = dt4.Rows[0]["NoofInstallments"].ToString();
                        string Rebate = dt4.Rows[0]["Rebate"].ToString();
                        string InterestRate = dt4.Rows[0]["InterestRate"].ToString();
                        string Depreciation = dt4.Rows[0]["DepreciationonShed"].ToString();
                        string CoveredArea = dt4.Rows[0]["CoveredArea"].ToString();
                        string LeaseRent1 = dt4.Rows[0]["LeaseRent1"].ToString();
                        string LeaseRent2 = dt4.Rows[0]["LeaseRent2"].ToString();
                        string LeaseRent3 = dt4.Rows[0]["LeaseRent3"].ToString();
                        string ReservationAmount = dt4.Rows[0]["ReservationAmount"].ToString();
                        string EMDAmount = dt4.Rows[0]["EMDAmount"].ToString();
                        string EMDDepositDays = dt4.Rows[0]["EMD_Deposit_Days"].ToString();
                        string AllotmentDate = dt4.Rows[0]["AllotmentDate"].ToString();
                        string ProdcutionStart = dt4.Rows[0]["ProductionStarPeriod"].ToString();
                        string ResEmd = (Convert.ToDecimal(ReservationMoneyVerified) + Convert.ToDecimal(EmdRatePerVerified)).ToString();

                        htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllotmentDate);
                        htmlContent = htmlContent.Replace("{{PlotNo}}", Chooseplot);
                        htmlContent = htmlContent.Replace("{{lblPlotSize}}", ChoosePlotArea);
                        htmlContent = htmlContent.Replace("{{FirstInstallmentDate}}", FirstInstallmentDate);
                        htmlContent = htmlContent.Replace("{{ExistingConstructionValue}}", ConstructionValueVerified);
                        htmlContent = htmlContent.Replace("{{ReservationAmount}}", ReservationAmount);
                        htmlContent = htmlContent.Replace("{{EMDAmount}}", EMDAmount);
                        htmlContent = htmlContent.Replace("{{EmdAmountDate}}", EMDDepositDays);
                        htmlContent = htmlContent.Replace("{{TotalReservationMoneyPer}}", ResEmd);
                        htmlContent = htmlContent.Replace("{{lblPlotRate}}", PlotRateVerified);
                        htmlContent = htmlContent.Replace("{{LocationChargeRate}}", LocationChargeRateVerified);
                        htmlContent = htmlContent.Replace("{{ChargePer}}", ChargePerVerified);
                        htmlContent = htmlContent.Replace("{{RemPremiumPer}}", RemPremiumPerVerified);
                        htmlContent = htmlContent.Replace("{{lblNoInstallment}}", Installment);
                        htmlContent = htmlContent.Replace("{{lblInterestPerAnnum}}", InterestRate);
                        htmlContent = htmlContent.Replace("{{lblRebatePer}}", Rebate);
                        htmlContent = htmlContent.Replace("{{Depreciation}}", Depreciation);
                        htmlContent = htmlContent.Replace("{{LeaseRent1}}", LeaseRent1);
                        htmlContent = htmlContent.Replace("{{LeaseRent2}}", LeaseRent2);
                        htmlContent = htmlContent.Replace("{{LeaseRent3}}", LeaseRent3);
                        htmlContent = htmlContent.Replace("{{CoveredArea}}", CoveredArea);
                        htmlContent = htmlContent.Replace("{{ProductionStart}}", ProdcutionStart);
                        htmlContent = htmlContent.Replace("{{lblRebate}}", Rebate);

                    }
                    string html1 = "";

                    if (dt6.Rows.Count > 0)
                    {

                        html1 = @"<table   Class='table table-hover table-bordered' style='width:100%;'>
                                <tr style='border-bottom:1px solid #000;'><th align='center' style='border-bottom:1px solid #000;'>Installment No.</th><th align='center' style='border-bottom:1px solid #000;'> Due Date Of Installment </th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (Without Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Premium Due</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (Without Rebate)</th></tr>";
                        foreach (DataRow dr in dt6.Rows)
                        {

                            html1 += "<tr><td align='center'>" + dr["S_no"].ToString() + "</td><td align='center'>" + dr["Duedate"].ToString() + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithoutRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["PremiumDue"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithoutRebate"]).ToString("N2") + "</td></tr>";
                        }


                        html1 += "</table>";
                        htmlContent = htmlContent.Replace("{{Installments}}", html1);
                    }
                    if (dt7.Rows.Count > 0)
                    {

                        string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms of allotment and binding on you.";
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

                        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", html);
                    }
                    else
                    {
                        htmlContent = htmlContent.Replace("{{ListofAnnexres}}", "");
                        htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                    }



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }

            }


            // Plot Cancelation
            if (ServiceID == 1001)
            {
                StreamReader reader = new StreamReader(Server.MapPath("/html/Plot_Cancelation.html"));
                htmlContent = reader.ReadToEnd();
                reader.Close();

                try
                {
                    int i = 0;
                    int j = 0;
                    string html = "";
                    string html1 = "";
                    SqlCommand cmd = new SqlCommand("DetailsForPlotCancellation '" + SerRequestNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt0 = ds.Tables[0];

                    DataTable dt1 = ds.Tables[1];
                    DataTable dt2 = ds.Tables[2];
                    DataTable dt3 = ds.Tables[3];


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
                        string AllotmentLetterNo = dt0.Rows[0]["AllotmentLetterNo"].ToString();

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
                                <tr><th> S.NO </th><th> Notice Ref No </th><th>Notice Date</th></tr>";
                        foreach (DataRow dr in dt2.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["NoticeRefNo"].ToString() + "</td><td>" + dr["IssueDate"] + "</td></tr>";
                        }


                        html += "</table>";


                        html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>";

                        foreach (DataRow dr in dt3.Rows)
                        {
                            j++;
                            html1 += "<tr><td style='width: 4 %;'>" + j.ToString() + "</td><td>" + dr["Clause"].ToString() + "</td></tr>";
                        }


                        html1 += "</table>";

                        htmlContent = htmlContent.Replace("{{ListofNotices}}", html);
                        htmlContent = htmlContent.Replace("{{ListofClause}}", html1);



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