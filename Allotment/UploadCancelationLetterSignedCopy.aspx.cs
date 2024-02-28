using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
//using System.Net.Mail;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UploadCancelationLetterSignedCopy : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        #endregion
        SqlConnection con;

        string SerReqNo;
        string Type = "";
        int UserId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SerReqNo = Request.QueryString["ServiceReqNo"];
            Type = Request.QueryString["Type"];
            if (!Page.IsPostBack)
            {
                BindAppointmentToDdl();
                Get_Notice_of_service(SerReqNo);
            }
        }

        private void BindAppointmentToDdl()
        {
            SqlCommand cmd = new SqlCommand("GetNoticeType", con);
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
            }

        }

        public void Get_Notice_of_service(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {

                dsR = objServiceTimelinesBLL.Get_NoticeWithAllotteeInternal(ServiceReqNo);
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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string AppointmentType1 = "";
            try
            {
                if (drpAppointmentType.SelectedValue.Trim() == "0")
                {
                    MessageBox1.ShowInfo("Kindly Select Notice Type");
                    return;
                }
                if (txtComment.Text == "")
                {
                    MessageBox1.ShowInfo("Kindly give your comments");
                    return;
                }
                foreach (ListItem drpAppointmentType in this.drpAppointmentType.Items)
                {
                    if (drpAppointmentType.Selected == true)
                    {
                        AppointmentType1 = AppointmentType1 + drpAppointmentType.Value + ",";
                    }
                }
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsToCreateNotice '" + SerReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                adp.Fill(dss);
                dt = dss.Tables[0];
                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoticeID"].ToString() == "" || dt.Rows[0]["NoticeID"].ToString() == null)
                    {
                        if (Session["FileName"].ToString() == "" || Session["FileName"].ToString() == null)
                        {
                            MessageBox1.ShowError("Please Upload Notice First");
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                            objServiceTimelinesBEL.AppointmentType = AppointmentType1.TrimEnd(',').Trim();
                            objServiceTimelinesBEL.AppointmentDesc = txtComment.Text.Trim();
                            objServiceTimelinesBEL.UserID = UserId;
                            objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
                            objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
                            objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
                            ds = objServiceTimelinesBLL.CreateNotice(objServiceTimelinesBEL);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox1.ShowInfo(ds.Tables[0].Rows[0][0].ToString());
                                drpAppointmentType.SelectedIndex = 0;
                                txtComment.Text = "";
                                //NoticeSendtoApplicant();
                                Session["File"] = "";
                                Session["FileExt"] = "";
                                Session["FileName"] = "";
                                lbluploadingMsg.Visible = false;
                                btnSend.Enabled = false;
                                return;
                            }
                            else
                            {
                                MessageBox1.ShowError("Erron In Creating Notice");
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox1.ShowError("Notice is alredy open ");
                        return;
                    }
                }
                else
                {
                    if (Session["FileName"].ToString() == "" || Session["FileName"].ToString() == null)
                    {
                        MessageBox1.ShowError("Please Upload Notice First");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                        objServiceTimelinesBEL.AppointmentType = AppointmentType1.TrimEnd(',').Trim();
                        objServiceTimelinesBEL.AppointmentDesc = txtComment.Text.Trim();
                        objServiceTimelinesBEL.UserID = UserId;
                        objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
                        objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
                        objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
                        ds = objServiceTimelinesBLL.CreateNotice(objServiceTimelinesBEL);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox1.ShowInfo(ds.Tables[0].Rows[0][0].ToString());
                            drpAppointmentType.SelectedIndex = 0;
                            txtComment.Text = "";
                            NoticeSendtoApplicant();
                            Session["File"] = "";
                            Session["FileExt"] = "";
                            Session["FileName"] = "";
                            lbluploadingMsg.Visible = false;
                            btnSend.Enabled = false;
                            return;
                        }
                        else
                        {
                            MessageBox1.ShowError("Erron In Creating Notice");
                            return;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);


        }
        protected void imgdocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (FileUpload4.HasFile)
                {
                    string filePath = FileUpload4.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUpload4.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = FileUpload4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        Session["File"] = objServiceTimelinesBEL.Uploadfile;
                        Session["FileName"] = objServiceTimelinesBEL.filename;
                        Session["FileExt"] = objServiceTimelinesBEL.content;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Plot Tracing");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_NoticeStatusMaster] where ServiceRequestNo='" + SerReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["PlotTracing"].ToString().Length > 0)
                {

                    String js = "window.open('DocViewerLease.aspx?ServiceReqNo=" + SerReqNo.Trim() + "&Type=1', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLease.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Plot Tracing Not Uploaded Yet");
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
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
                + dt.Rows[0]["DocName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NoticeSendtoApplicant()
        {

            try
            {
                string[] SerIdarray = SerReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForNoticeReply '" + SerReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

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
                    //StrContent = StrContent.Replace("{Link}", "https://http://staging.onlineupsidc.com/IAServicesApplication_Module.aspx?ServiceReqNo=" + SerReqNo);
                    StrContent = StrContent.Replace("{Link}", "http://demo.onlineupsidc.com/IAServicesApplication_Module.aspx?ServiceReqNo=" + SerReqNo);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            index = index % GridView1.PageSize;
            string SerReqNo = GridView1.DataKeys[index].Values[0].ToString();
            string NoticeID = GridView1.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer_Notice.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeId=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
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
        }

        
    }
}