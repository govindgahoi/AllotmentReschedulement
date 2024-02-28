using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ProcessApplicationApproval : System.Web.UI.UserControl
    {
        SqlConnection con;
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

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
        public string AllotteeID { get; set; }
        string UserName = "";
        int UserId = 0, IAID = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {

                string[] SerIdarray = ServiceReqNo.Split('/');
                AllotteeID = SerIdarray[2].ToString();
                Page.Form.Enctype = "multipart/form-data";

                this.RegisterPostBackControl();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and ActiveStatus=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();

                    if (DataManager == "CMIA")
                    {
                        UploadTB.Visible = true;
                    }
                    else
                    {
                        UploadTB.Visible = false;
                    }


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

                SqlCommand cmd1 = new SqlCommand("Select SWCControlId,SWCUnitId,SWCServiceId,SWCRequestID from ApplicationRegister where ApplicationID='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    ViewState["ControlID"] = dt1.Rows[0]["SWCControlId"].ToString();
                    ViewState["UnitID"] = dt1.Rows[0]["SWCUnitId"].ToString();
                    ViewState["ServiceID"] = dt1.Rows[0]["SWCServiceId"].ToString();
                    ViewState["RequestID"] = dt1.Rows[0]["SWCRequestID"].ToString();
                }
            }
            catch (Exception ex) { }


            BindTransferToDdl();
        }

        private void BindTransferToDdl()
        {
            SqlCommand cmd = new SqlCommand("service_request_track_Allotment '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[1];
            DataTable dt2 = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString().Trim() == DataManager.Trim())
                {
                    drpSendto.DataSource = dt;
                    drpSendto.DataBind();
                    drpSendto.DataTextField = "drp_text";
                    drpSendto.DataValueField = "drp_value";
                    drpSendto.DataBind();
                    drpSendto.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    drpSendto.DataSource = null;
                    drpSendto.DataBind();
                    drpSendto.Items.Insert(0, new ListItem("Application Is Transfered", "0"));
                }

            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                string Forwarded = "";
                string filePath  = "";
                string to = drpSendto.SelectedValue.Trim();
                GeneralMethod gm = new GeneralMethod();

                SqlCommand cmd = new SqlCommand("validatemarkings '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                adp.Fill(dss);
                int retVal = 0;

                DataTable dt = dss.Tables[0];
                DataTable dt1 = dss.Tables[1];


                if (Convert.ToInt32(dt.Rows[0][0].ToString()) < 10)
                {
                    MessageBox1.ShowInfo("Please Verify Marking Details Properly");
                    return;
                }

                if (DataManager == "Data Approver")
                {
                    if (dt1.Rows[0][0].ToString() == "NotUploaded")
                    {
                        MessageBox1.ShowInfo("Please Upload Committee Minutes");
                        return;
                    }
                    if (drpSendto.SelectedValue.Trim() == "CMIA")
                    {
                        if (dt1.Rows[0][1].ToString() == "False")
                        {
                            MessageBox1.ShowInfo("Application Is Still Pending For Account Clearance");
                            return;
                        }
                    }
                }
                if (DataManager == "CMIA")
                {
                    if (dt1.Rows[0][3].ToString() == "NotUploaded")
                    {
                        MessageBox1.ShowInfo("Please Upload Head Office Committee Minutes");
                        return;
                    }
                }

                if (drpSendto.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please select to whom you want to send the file");
                    return;
                }

                if (drpSendto.SelectedItem.Text == "Application Is Transfered")
                {
                    MessageBox1.ShowInfo("Application Is Transfered cannot be edited");
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
                if (!string.IsNullOrEmpty(Session["Name"] as string))
                {
                    filePath = "~/ProceedingDocuments/Allotments/" + AllotteeID.Trim() + "/" + Convert.ToString(Session["Name"]);
                }
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TransferFrom = DataManager.Trim();
                objServiceTimelinesBEL.TransferTo = drpSendto.SelectedValue.Trim();
                objServiceTimelinesBEL.FromUser = UserName.Trim();
                objServiceTimelinesBEL.RecStatus = drpRecommendation.SelectedValue.Trim();
                objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                objServiceTimelinesBEL.DocPath = filePath.Trim();

                retVal = objServiceTimelinesBLL.TransferApplication(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    if (filePath.Length > 0)
                    {
                        string folderPath = Server.MapPath("~/ProceedingDocuments/Allotments/" + AllotteeID.Trim() + "/");

                        //Check whether Directory (Folder) exists.
                        if (!Directory.Exists(folderPath))
                        {
                            //If Directory (Folder) does not exists. Create it.
                            Directory.CreateDirectory(folderPath);
                        }
                        //fu.SaveAs(folderPath + Path.GetFileName(fu.FileName));
                        File.WriteAllBytes(folderPath + Session["Name"].ToString(), Session["Doc"] as byte[]);
                    }
                    switch (to.Trim())
                    {
                        case "Data Verifier":
                            Forwarded = "Data Verifier";
                            break;
                        case "Data Approver":
                            Forwarded = "Regional Manager";
                            break;
                        case "CMIA":
                            Forwarded = "Chief Manager IA";
                            break;
                        case "JMD":
                            Forwarded = "Joint Managing director";
                            break;
                        case "Final Approver":
                            Forwarded = "Managing director";
                            break;
                        default:
                            Forwarded = "";
                            break;
                    }
                    if (DataManager == "Final Approver")
                    {

                        string res = "";
                        res = drpRecommendation.SelectedValue.Trim();
                        if (res == "Approve")
                        {
                            Status_Code = "05";
                            Remarks = "Application Is Forwarded to " + Forwarded + " (" + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + ") for Allotment";
                        }
                        else if (res == "Not Approve")
                        {
                            Status_Code = "05";
                            Remarks = "Application Is Forwarded to " + Forwarded + " (" + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + ") for Rejection";
                        }
                        else
                        {
                            Status_Code = "05";
                            Remarks = "Application Is Forwarded to " + Forwarded + " (" + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + ")";
                        }

                    }
                    else
                    {
                        Status_Code = "05";
                        Remarks = "Application Is Forwarded to " + Forwarded + " (" + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + ")";
                    }

                    if (ViewState["ControlID"].ToString().Length > 0)
                    {
                        ControlID = ViewState["ControlID"].ToString();
                        UnitID = ViewState["UnitID"].ToString();
                        ServiceID = ViewState["ServiceID"].ToString();
                        Request_ID = ViewState["RequestID"].ToString();
                        Pendancy_level = Forwarded + " (" + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + ")";
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        string Update_Result = webService.WReturn_CUSID_STATUS(
                         ControlID,
                         UnitID,
                         ServiceID,
                         ProcessIndustryID,
                         ApplicationID,
                         Status_Code,
                         Remarks,
                         Pendancy_level,
                         Fee_Amount,
                         Fee_Status,
                         Transaction_ID,
                         Transaction_Date,
                         Transaction_Date_Time,
                         NOC_Certificate_Number,
                         NOC_URL,
                         ISNOC_URL_ActiveYesNO,
                         passsalt,
                         Request_ID,
                         Objection_Rejection_Code,
                         Is_Certificate_Valid_Life_Time,
                         Certificate_EXP_Date_DDMMYYYY,
                         D1,
                         D2,
                         D3,
                         D4,
                         D5,
D6,
D7
                       );
                    }
                    this.Page.GetType().InvokeMember("AllertRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { "Application Transferred To " + drpSendto.SelectedValue.Trim() });
                }
                else
                {
                    MessageBox1.ShowSuccess("Erron In Transferring Application");
                    return;
                }



            }
            catch (Exception ex)
            {

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
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnUpload);
                scriptManager.RegisterPostBackControl(btnSend);
                scriptManager.RegisterPostBackControl(btnLetterUpload);


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

                    retval = objServiceTimelinesBLL.UploadHeadOfficeCommitteeMinutes(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Head Office Committee Minutes Uploaded Successfully !");
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
                    MessageBox1.ShowError("Please Upload Committee Minutes");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnHeadMinutes_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNO='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["HeadOfficeCommitteeDoc"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerHeadMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerHeadMinutes.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Head Office Committee Minutes Not Uploaded Yet");
                }
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