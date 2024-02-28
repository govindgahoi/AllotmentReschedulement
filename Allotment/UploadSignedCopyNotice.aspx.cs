using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
//using System.Net.Mail;
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
    public partial class UploadSignedCopyNotice : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        #endregion
        SqlConnection con;

        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";

        string SerReqNo;
        string NoticeID = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SerReqNo = Request.QueryString["ServiceReqNo"];
            NoticeID = Request.QueryString["NoticeID"];

            //DataTable NMSWP = gm.GetNMSWPIDNews(SerReqNo);
            //SWCControlID = NMSWP.Rows[0][0].ToString();
            //SWCUnitID = NMSWP.Rows[0][1].ToString();
            //SWCServiceID = NMSWP.Rows[0][2].ToString();
            //Request_ID = NMSWP.Rows[0][3].ToString();


            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }


        public void BindGridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("GetSignedChecklistNotice '" + SerReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }

        }



        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ltEmbed.Text = "";
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView rowView = (DataRowView)e.Row.DataItem;

                    string ReqNo = rowView["ServiceRequestNO"].ToString();
                    string Service = rowView["Service"].ToString();
                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ReqNo.Trim();
                    objServiceTimelinesBEL.Doctype = Service.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {

                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                            e.Row.FindControl("lbDelete").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                            e.Row.FindControl("lbDelete").Visible = true;
                        }
                    }

                }
            }
            catch
            {

            }


        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            string NewAllotteeID = "";
            string ControlID = "";
            string UnitID = "";
            string ServiceID = "";
            string AllotteeID = "";
            string status = "";
            string Flag = "";
            string DocType = "";
            string Reason = "";
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % GridView2.PageSize;
            string SerReqNo = GridView2.DataKeys[index].Values[0].ToString();
            string Service = GridView2.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "Upload")
            {

                if (Service == "Letter")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;
                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {

                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;
                            objServiceTimelinesBEL.Doctype = Service;
                            objServiceTimelinesBEL.Flag = Flag;
                            objServiceTimelinesBEL.NoticeID = NoticeID;
                            try
                            {
                                int retVal = objServiceTimelinesBLL.UploadNotice(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    SendMailToApplicantforPlotCanclation(bytes);
                                    BindGridView();
                                    DataSet ds = new DataSet();
                                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                                    objServiceTimelinesBEL.Doctype = Service;
                                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                                    DataTable dtDoc = ds.Tables[0];
                                    if (dtDoc != null)
                                    {

                                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                                        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                                    }
                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }

                            }
                            catch (Exception ex)
                            {

                                string message = ex.ToString();
                                string script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                            }
                            finally
                            {
                                objServiceTimelinesBEL = null;
                                objServiceTimelinesBLL = null;
                            }

                        }
                        else
                        {
                            string message = "File format not recognised." +
                              " Upload PDF formats";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                    }

                }
            }
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.Doctype = Service.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                }

            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.Doctype = Service.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);
                    DataTable dtDoc1 = ds.Tables[0];

                    if (dtDoc1.Rows.Count > 0)
                    {
                        download(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "Delete")
            {
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;


                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteSignedCopyLetter(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = " Document deleted successfully ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        BindGridView();
                    }
                    else
                    {
                        string message = "Document couldn't be deleted";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["DocName"].ToString() + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        private void SendMailToApplicantforPlotCanclation(byte[] bytes)
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForNoticeReply '" + SerReqNo.Trim() + "'", con);
            //SqlCommand cmd = new SqlCommand("Select * from AllotteeMaster where ref_AllotmentNo= '" + SerReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                //string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                string ApplicantEmail = "manish.ims08@gmail.com";
                //string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                string PhoneNo = "9650425760";
                string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                string Date = dt.Rows[0]["Date"].ToString();
                string  PlotNumber= dt.Rows[0]["PlotNo"].ToString();
                string letterno = dt.Rows[0]["Allotmentletterno"].ToString();
                string NoticeDescription = dt.Rows[0]["Noticetype"].ToString();


              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(ApplicantEmail);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/NoticeMailToPlotCancelation.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                StrContent = StrContent.Replace("{Address}", OfficeAddress);
                StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                StrContent = StrContent.Replace("{Date}", Date);
                StrContent = StrContent.Replace("{SerNo}", SerReqNo);
                //StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/IAServicesApplication_Module.aspx?ViewID=" + ServiceReqNo);
                //StrContent = StrContent.Replace("{Link}", "https://demo.onlineupsidc.com/IAServicesApplication_PlotCancelation.aspx?ServiceReqNo=" + SerReqNo);
                StrContent = StrContent.Replace("{Link}", "https://localhost:50610/IAServicesApplication_PlotCancelation.aspx?ServiceReqNo=" + SerReqNo);

                //newmsg.Subject = "UPSIDAeService: " + drpAppointmentType.SelectedItem.Text.Trim();
                newmsg.Subject = " Notice for Cancelation  Plot No " + PlotNumber + " with Allotment letter No " + letterno + "and Your Notice Description "+ NoticeDescription + "";
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
                    MailAddress mailto = new MailAddress("manish.ims08@gmail.com@gmail.com");
                   // MailAddress mailto = new MailAddress(EmaiID.Trim());
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/NoticeMailToPlotCancelation.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", Name.Trim());
                    StrContent = StrContent.Replace("{Description}", "Cancelation Notice . ");

                    newmsg.Subject = " Notice for Cancelation  Plot No " + PlotNo + " with Allotment letter No " + letterno + "";
                    newmsg.BodyHtml = StrContent;
                    //newmsg.IsBodyHtml = true;
                    //For File Attachment, more file can also be attached
                    newmsg.Attachments.Add(new Attachment(new MemoryStream(bytes), "" + Name + ".pdf"));
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