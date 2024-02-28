using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;


namespace Allotment
{
    public partial class UC_ProcessApplicationService : System.Web.UI.UserControl
    {
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string IAID { get; set; }
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
        string ServiceID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";
        string AvailRebate = "";
        string gmidc = "";
        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                this.RegisterPostBackControl();
                string[] SerIdarray = ServiceReqNo.Split('/');

                AllotteeID = SerIdarray[2].Trim();
                ServiceID  = SerIdarray[1].Trim();
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID  = NMSWP.Rows[0][0].ToString();
                SWCUnitID     = NMSWP.Rows[0][1].ToString();
                SWCServiceID  = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();
                //Page.Form.Enctype = "multipart/form-data";



                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId   = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();


                    if (DataManager == "Final Approver")
                    {
                        drpRecommendation.Items.Clear();
                        drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
                        drpRecommendation.Items.Insert(1, new ListItem("Approve", "Approve"));
                        drpRecommendation.Items.Insert(2, new ListItem("Not Approve", "Not Approve"));
                        drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
                        drpRecommendation.DataBind();
                    }
                    else
                    {
                        drpRecommendation.Items.Clear();
                        drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
                        drpRecommendation.Items.Insert(1, new ListItem("Recommended", "Recommended"));
                        drpRecommendation.Items.Insert(2, new ListItem("Not Recommended", "Not Recommended"));
                        drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
                        drpRecommendation.DataBind();
                    }


                }

                HideShow();


            }
            catch (Exception ex) { }


            BindTransferToDdl();
        }

        private void BindTransferToDdl()
        {
            SqlCommand cmd = new SqlCommand("service_request_track_Lease '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[1];
            DataTable dt2 = ds.Tables[0];
            string role = dt2.Rows[0]["role"].ToString().Trim();
            string inbound = dt2.Rows[0]["inbound"].ToString().Trim();
            if (dt.Rows.Count > 0)
            {

                drpSendto.DataSource = dt;
                drpSendto.DataBind();
                drpSendto.DataTextField = "drp_text";
                drpSendto.DataValueField = "drp_value";
                drpSendto.DataBind();
                drpSendto.Items.Insert(0, new ListItem("--Select--", "0"));


            }

        }

        private void HideShow()
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AvailRebate = dt.Rows[0]["AvailRebate"].ToString();
                gmidc = dt.Rows[0]["GMIDCLetter"].ToString();
                if (Level == "RM")
                {
                    if (AvailRebate == "True")
                    {
                        UploadTB.Visible = true;
                    }
                    else
                    {
                        UploadTB.Visible = false;
                    }
                }
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                string DocReceived = "", Objection = "", InspectionDoc = "", LeaseDeedExecuted = "", POAAssigned = "", LeaseRegistered = "", JEInspectionDate = "" ;
                SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNo='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DocReceived       = dt.Rows[0]["DocumentSubmitted"].ToString();
                    Objection         = dt.Rows[0]["UnderObjection"].ToString();
                    InspectionDoc     = dt.Rows[0]["InspectionReport"].ToString();
                    LeaseDeedExecuted = dt.Rows[0]["LeaseDeedExecuted"].ToString();
                    POAAssigned       = dt.Rows[0]["POAAssigned"].ToString();
                    LeaseRegistered   = dt.Rows[0]["LeaseDeedRegistered"].ToString();
                    JEInspectionDate  = dt.Rows[0]["JEInsppectionDate"].ToString();

                }

                if (Level == "DA")
                {
                    if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                    {
                        if (DocReceived == "False" || DocReceived == "")
                        {
                            if (drpSendto.SelectedValue.Trim() == "RM")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not submitted his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (Objection == "True")
                        {
                            MessageBox1.ShowWarning("Cannot Forward this application as allottee has not resolved the objection yet");
                            return;
                        }
                        if (drpSendto.SelectedValue.Trim() == "RM")
                        {
                            if (LeaseDeedExecuted == "False" || LeaseDeedExecuted == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not signed his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (InspectionDoc.Length > 0)
                        {
                            if (POAAssigned == "False" || POAAssigned == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as no POA is assigned to this application yet");
                                return;
                            }
                        }
                    }
                }
                if (Level == "Accountant")
                {
                    if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                    {
                        if (DocReceived == "False" || DocReceived == "")
                        {
                            if (drpSendto.SelectedValue.Trim() == "RM")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not submitted his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (Objection == "True")
                        {
                            MessageBox1.ShowWarning("Cannot Forward this application as allottee has not resolved the objection yet");
                            return;
                        }
                        if (drpSendto.SelectedValue.Trim() == "RM")
                        {
                            if (LeaseDeedExecuted == "False" || LeaseDeedExecuted == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not signed his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (InspectionDoc.Length > 0)
                        {
                            if (POAAssigned == "False" || POAAssigned == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as no POA is assigned to this application yet");
                                return;
                            }
                        }
                    }
                }
                if (Level == "MO")
                {
                    if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                    {
                        if (DocReceived == "False" || DocReceived == "")
                        {
                            if (drpSendto.SelectedValue.Trim() == "RM")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not submitted his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (Objection == "True")
                        {
                            MessageBox1.ShowWarning("Cannot Forward this application as allottee has not resolved the objection yet");
                            return;
                        }
                        if (drpSendto.SelectedValue.Trim() == "RM")
                        {
                            if (LeaseDeedExecuted == "False" || LeaseDeedExecuted == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not signed his document for lease deed execution yet");
                                return;
                            }
                        }
                        if (InspectionDoc.Length > 0)
                        {
                            if (POAAssigned == "False" || POAAssigned == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as no POA is assigned to this application yet");
                                return;
                            }
                        }
                    }
                }
                if (Level == "JE")
                {
                    if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                    {
                        if (InspectionDoc.Length <= 0)
                        {
                            MessageBox1.ShowWarning("Kindly Update Site Visit Details First");
                            return;
                        }
                        if (JEInspectionDate.Length <= 0)
                        {
                            MessageBox1.ShowWarning("Kindly Update Site Visit Details First");
                            return;
                        }
                        if (drpSendto.SelectedValue.Trim() == "RM")
                        {
                            if (LeaseDeedExecuted == "False" || LeaseDeedExecuted == "")
                            {
                                MessageBox1.ShowWarning("Cannot Forward this application as allottee has not signed his document for lease deed execution yet");
                                return;
                            }
                        }

                    }
                    
                }

                if (Level == "RM")
                {
                    if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                    {
                        if (drpSendto.SelectedValue.Trim() == "DA")
                        {
                            if (LeaseDeedExecuted == "False" || LeaseDeedExecuted == "")
                            {
                                MessageBox1.ShowWarning("Lease Deed has not executed hence cannot be approved.");
                                return;
                            }
                            if (AvailRebate == "True")
                            {
                                if (gmidc.Length <= 0)
                                {
                                    MessageBox1.ShowWarning("As Allottee wants to avail rebate on stamp duty hence gmidc letter is must");
                                    return;
                                }
                            }
                        }

                    }

                }

                string Forwarded = "";
                string to = drpSendto.SelectedValue.Trim();
                switch (to.Trim())
                {
                    case "DA":
                        Forwarded = "Dealing Assistant";
                        break;
                    case "JE":
                        Forwarded = "Junior Engineer";
                        break;
                    case "RM":
                        Forwarded = "Regional Manager";
                        break;
                    case "EE":
                        Forwarded = "Executive Engineer";
                        break;
                    case "Accountant":
                        Forwarded = "Accountant";
                        break;
                    case "MO":
                        Forwarded = "Middle Officer";
                        break;
                    default:
                        Forwarded = "";
                        break;
                }
                GeneralMethod gm = new GeneralMethod();
                int retVal = 0;
                if (drpSendto.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please select to whom you want to send the file");
                    return;
                }

                if (drpRecommendation.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please Select Recommendation");
                    return;
                }
                if (txtComment.Text == "")
                {
                    MessageBox1.ShowInfo("Please enter your valuable comments");
                    return;
                }

                SqlCommand cmd1 = new SqlCommand("CheckReceipient '" + IAID + "','1001','" + drpSendto.SelectedValue.Trim() + "'", con);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataTable dttt = new DataTable();
                adp1.Fill(dttt);
                if (dttt.Rows.Count > 0)
                {
                    if (dttt.Rows.Count > 1)
                    {
                        MessageBox1.ShowInfo("More than one " + Forwarded + " associated in this industrial area");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowInfo("No " + Forwarded + " associated in this industrial area");
                    return;
                }



                if (!string.IsNullOrEmpty(Session["Name"] as string))
                {
                    filePath = "~/ProceedingDocuments/" + ServiceID.Trim() + "/" + AllotteeID.Trim() + "/" + Convert.ToString(Session["Name"]);
                }

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TransferFrom = Level.Trim();
                objServiceTimelinesBEL.TransferTo = drpSendto.SelectedValue.Trim();
                objServiceTimelinesBEL.FromUser = UserName.Trim();
                objServiceTimelinesBEL.RecStatus = drpRecommendation.SelectedValue.Trim();
                objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                objServiceTimelinesBEL.DocPath    = filePath.Trim();
                retVal = objServiceTimelinesBLL.TransferApplicationLease(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    if (filePath.Length > 0)
                    {
                        string folderPath = Server.MapPath("~/ProceedingDocuments/" + ServiceID.Trim() + "/" + AllotteeID.Trim() + "/");

                        //Check whether Directory (Folder) exists.
                        if (!Directory.Exists(folderPath))
                        {
                            //If Directory (Folder) does not exists. Create it.
                            Directory.CreateDirectory(folderPath);
                        }
                        //fu.SaveAs(folderPath + Path.GetFileName(fu.FileName));
                        File.WriteAllBytes(folderPath + Session["Name"].ToString(), Session["Doc"] as byte[]);
                    }
                    if (Level == "RM")
                    {
                        if (drpRecommendation.SelectedValue.Trim() == "Recommended")
                        {
                            if (drpSendto.SelectedValue.Trim() == "DA")
                            {
                                if (LeaseRegistered == "False")
                                {
                                    if (LeaseDeedExecuted == "True")
                                    {
                                        AllotteeMailForRegistrarAppointment();
                                    }
                                }
                            }

                        }

                    }
                    if (SWCControlID.Length > 0)
                    {
                        string Status = "05";
                        string Remarks = Level.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + " Forwarded Application To | " + drpSendto.SelectedValue.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo);
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status, Remarks, SWCRequest_ID, drpSendto.SelectedValue.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                        Response.Redirect("ServiceRequestInboxNewLeaseDeed.aspx");                       
                    }
                    else
                    {
                        Response.Redirect("ServiceRequestInboxNewLeaseDeed.aspx");
                    }

                   
                }
                else
                {
                    MessageBox1.ShowSuccess("Erron In Transferring Application");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileupload.HasFile)
                {
                    string filePath = fileupload.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileupload.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    int fileSize = fileupload.PostedFile.ContentLength;
                    if (fileSize > (1 * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileupload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadGMIDCLetter(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("GMIDC Letter Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Inspection Report");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnGMIDC);
                scriptManager.RegisterPostBackControl(btnLetterUpload);

        }
        protected void btnInspectionReport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNO='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["GMIDCLetter"].ToString().Length > 0)
                {


                    String js = "window.open('GMIDCDocViewer.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "GMIDCDocViewer.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("GMIDC Letter Has Not Uploaded Yet");
                }
            }
        }

        protected void drpRecommendation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRecommendation.SelectedIndex == 1 || drpRecommendation.SelectedIndex == 2)
            {
                drpSendto.SelectedIndex = 1;
                drpSendto.Enabled = false;
            }
            else
            {
                drpSendto.Enabled = true;
            }
        }


        private void AllotteeMailForRegistrarAppointment()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunication '" + ServiceReqNo.Trim() + "',3", con);
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
                    string POAName = dt.Rows[0]["POAName"].ToString();
                    string POAMobile = dt.Rows[0]["POAMobile"].ToString();




                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;
                    //Attachment att = new Attachment(Server.MapPath("PDF/DocViewerMinutes.pdf"));
                    //newmsg.Attachments.Add(att);
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/AppointmentMailForRegistrarDate.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{DAName}", POAName);
                    StrContent = StrContent.Replace("{ContactNo}", POAMobile);
                    StrContent = StrContent.Replace("{Address}", OfficeAddress);
                    StrContent = StrContent.Replace("{regionaloffice}", RegionalOffice);
                    StrContent = StrContent.Replace("{Date}", Date);
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo);
                    StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);



                    newmsg.Subject = "UPSIDAeService: Intimation to take appointment at the concerned registrar office for registration of lease deed";
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string s = gm.SendSMS("LeaseDeed", PhoneNo, ApplicantName, "Dear Applicant Please update date of appointment in registrar office against your application for Lease Deed ref no " + ServiceReqNo + ".");



                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void btnLetterUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int maxFileSize = 3;

                if (fileupload2.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath = fileupload2.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = fileupload2.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                        return;
                    }

                    //bool exist = Directory.EnumerateFiles(Server.MapPath("LAWCorrespondenceLetters"), filename).Any();

                    //if (exist == true)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Letter with same file name already exists');", true);
                    //    return;
                    //}

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

                        Stream fs = fileupload2.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        Session["Name"] = filename;
                        Session["Ext"] = contenttype;
                        Session["Doc"] = bytes;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;
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
    }
}