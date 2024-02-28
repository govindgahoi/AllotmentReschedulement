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
    public partial class UC_ProcessApplicationLidaBT : System.Web.UI.UserControl
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

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from tbl_LidaUserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();

                    if (Level == "PO" || Level == "JE")
                    {
                        UploadTB.Visible = true;
                        panelForm1.Visible = false;
                    }
                    else
                    {
                        UploadTB.Visible = false;
                        panelForm1.Visible = false;
                    }
                    if (DataManager == "Final Approver")
                    {
                        panelForm1.Visible = false;
                        drpRecommendation.Items.Clear();
                        drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
                        drpRecommendation.Items.Insert(1, new ListItem("Approve", "Approve"));
                        drpRecommendation.Items.Insert(2, new ListItem("Not Approve", "Not Approve"));
                        drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
                        drpRecommendation.DataBind();
                    }
                    else if (DataManager == "Accounts Manager")
                    {

                        drpRecommendation.Visible = false;
                        panelForm.Visible = false;
                        panelForm1.Visible = true;
                    }
                    else
                    {
                        panelForm1.Visible = false;
                        drpRecommendation.Items.Clear();
                        drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
                        drpRecommendation.Items.Insert(1, new ListItem("Recommended", "Recommended"));
                        drpRecommendation.Items.Insert(2, new ListItem("Not Recommended", "Not Recommended"));
                        drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
                        drpRecommendation.DataBind();
                    }


                }

            }
            catch (Exception ex) {
                throw ex;

            }


            BindTransferToDdl();
        }

        private void BindTransferToDdl()
        {
            SqlCommand cmd = new SqlCommand("service_request_track '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[1];
            DataTable dt2 = ds.Tables[0];
            string role = dt2.Rows[0]["role"].ToString().Trim();
            string inbound = dt2.Rows[0]["inbound"].ToString().Trim();
            if(DataManager!= "Accounts Manager")
            {
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
            else
            {
                drpSendto.Visible = false;
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string Forwarded = "";
                string filePath = "";
                string to = drpSendto.SelectedValue.Trim();
                switch (to.Trim())
                {
                    case "DA":
                        Forwarded = "Dealing Assistant";
                        break;
                    case "JE":
                        Forwarded = "Junior Engineer";
                        break;
                    case "PO":
                        Forwarded = "Project Officer";
                        break;
                    case "ATP":
                        Forwarded = "ATP Incharge";
                        break;
                    case "JMD":
                        Forwarded = "JMD";
                        break;
                    case "MD":
                        Forwarded = "MD";
                        break;
                    default:
                        Forwarded = "";
                        break;
                }
                GeneralMethod gm = new GeneralMethod();
                int retVal = 0;
                if (DataManager != "Accounts Manager")
                {
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
                    SqlCommand cmd = new SqlCommand("validatemarkings '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet dss = new DataSet();
                    adp.Fill(dss);



                    DataTable dt1 = dss.Tables[1];

                    if (Level == "JE")
                    {
                        if (drpRecommendation.SelectedValue == "Clarification")
                        {

                        }
                        else
                        {
                            if (dt1.Rows[0][0].ToString() == "NotUploaded")
                            {
                                MessageBox1.ShowInfo("Please Upload Inspection Report");
                                return;
                            }
                        }
                    }


                    if (!string.IsNullOrEmpty(Session["Name"] as string))
                    {
                        filePath = "~/ProceedingDocuments/LidaPlan/" + ServiceReqNo.Trim() + "/" + Convert.ToString(Session["Name"]);
                    }
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.TransferFrom = Level.Trim();
                    objServiceTimelinesBEL.TransferTo = drpSendto.SelectedValue.Trim();
                    objServiceTimelinesBEL.FromUser = UserName.Trim();
                    objServiceTimelinesBEL.RecStatus = drpRecommendation.SelectedValue.Trim();
                    objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                    objServiceTimelinesBEL.DocPath = filePath.Trim();
                    retVal = objServiceTimelinesBLL.TransferApplicationLida(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        if (filePath.Length > 0)
                        {
                            string folderPath = Server.MapPath("~/ProceedingDocuments/LidaPlan/" + ServiceReqNo.Trim() + "/");

                            //Check whether Directory (Folder) exists.
                            if (!Directory.Exists(folderPath))
                            {
                                //If Directory (Folder) does not exists. Create it.
                                Directory.CreateDirectory(folderPath);
                            }
                            //fu.SaveAs(folderPath + Path.GetFileName(fu.FileName));
                            File.WriteAllBytes(folderPath + Session["Name"].ToString(), Session["Doc"] as byte[]);
                        }
                        string res = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application Transferred To " + drpSendto.SelectedValue.Trim() + "');", true);
                        lbluploadingMsg.Visible = true;
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowSuccess("Erron In Transferring Application");
                        return;
                    }
                }
                //else
                //{
                //    SqlCommand cmd1 = new SqlCommand("update servicerequests set isAccountClear=1 where ServicerequestNo='" + ServiceReqNo.Trim() + "'", con);
                //    //cmd.CommandType=
                //    SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                //    DataTable dt1 = new DataTable();
                //    adp1.Fill(dt1);
                //    Response.Redirect("~/LidaServiceRequestNew.aspx");
                //}
            }
            catch (Exception ex)
            {
               MessageBox1.ShowError(ex.ToString());
                return;
            }
        }
        protected void btnverify_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("update servicerequests set isAccountClear=1 where ServicerequestNo='" + ServiceReqNo.Trim() + "'", con);
            //cmd.CommandType=
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            Response.Redirect("~/LidaServiceRequestNew.aspx");
        }
        protected void btnMinutes_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNO='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerMinutes.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Committee Minutes Not Uploaded Yet");
                }
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnUpload);
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

                    retval = objServiceTimelinesBLL.UploadCommitteeMinutes(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Inspection Report Uploaded Successfully !");
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

        protected void btnInspectionReport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNO='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {


                    String js = "window.open('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerMinutes.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Inspection Report Not Uploaded Yet");
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