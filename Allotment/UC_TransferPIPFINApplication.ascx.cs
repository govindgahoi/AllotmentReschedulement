using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_TransferPIPFINApplication : System.Web.UI.UserControl
    {
        SqlConnection con;

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        Classes.Class1 cs = new Classes.Class1();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        public string UserName = "";
        public int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        GeneralMethod gm = new GeneralMethod();

        string DocPath = "";
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
        string RequestID = "";
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
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "", D2 = "", D3 = "", D4 = "", D5 = "", D6 = "", D7 = "";
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        string pendancyLevel = "";



        public void Page_Load(object sender, EventArgs e)
        {

            try
            {

                Page.Form.Enctype = "multipart/form-data";
                this.RegisterPostBackControl();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                //divDisableReminder.Visible = false;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    lblLevel.Text = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }

                BindTransferToDdl();
                BindUsersList();

                if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                {
                    ddlTransferStatus.Enabled = true;
                    OtherDept.Visible = true;
                    btnSend.Visible = true;
                    btnPIPComment.Visible = false;
                    ddlTransferStatus.Items.Add(new ListItem("Recommended", "Recommended"));
                    ddlTransferStatus.Items.Add(new ListItem("Non-Recommended", "Non-Recommended"));
                    lblUploadStatus.Text = "Upload Minute Of Meeting";
                    CommDiv.Visible = true;
                }
                else if (Convert.ToString(Session["UserName"]) == "aceo_a")
                {
                    ddlTransferStatus.Enabled = true;
                    OtherDept.Visible = true;
                    btnSend.Visible = true;
                    btnPIPComment.Visible = false;
                    ddlTransferStatus.Items.Add(new ListItem("Recommended", "Recommended"));
                    ddlTransferStatus.Items.Add(new ListItem("Non-Recommended", "Non-Recommended"));
                    lblUploadStatus.Text = "Upload Supporting Documents (If Required)";
                    CommDiv.Visible = true;
                }
                else if (Convert.ToString(Session["UserName"]) == "MD@UPSIDC")
                {
                    ddlTransferStatus.Enabled = true;
                    OtherDept.Visible = true;
                    btnSend.Visible = true;
                    btnPIPComment.Visible = false;
                    ddlTransferStatus.Items.Add(new ListItem("Approve", "Approve"));
                    ddlTransferStatus.Items.Add(new ListItem("Reject", "Reject"));
                    lblUploadStatus.Text = "Upload Supporting Documents (If Required)";
                    CommDiv.Visible = true;
                }
                else
                {
                    ddlTransferStatus.Enabled = true;
                    OtherDept.Visible = false;
                    btnSend.Visible = false;
                    btnPIPComment.Visible = true;
                    CommDiv.Visible = false;
                    ddlTransferStatus.Items.Add(new ListItem("Approve", "Approve"));
                    lblUploadStatus.Text = "Upload Digitally Signed Letter";
                }
            }
            catch (Exception ex)
            {
            }



        }


        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnupload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnReminder);
        }
        private void BindTransferToDdl()
        {
            //SqlCommand cmd = new SqlCommand("service_request_track_PIP '" + ServiceReqNo.Trim() + "'", con);

            string PIP_UserType = "";

            if (Convert.ToString(Session["UserName"]) == "aceo_a")
            {
                PIP_UserType = "7";
            }
            else if (Convert.ToString(Session["UserName"]) == "MD@UPSIDC")
            {
                PIP_UserType = "9";
            }
            else if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
            {
                PIP_UserType = "5";
            }
            else
            {
                PIP_UserType = "0";
            }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("service_request_track_PIP_UserType  '" + ServiceReqNo.Trim() + "'," + PIP_UserType + "", con);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                drpSendto.DataSource = dt;
                drpSendto.DataBind();
                drpSendto.DataTextField = "drp_text";
                drpSendto.DataValueField = "drp_value";
                drpSendto.DataBind();
            }
            else
            {
                drpSendto.ClearSelection();
                drpSendto.DataSource = dt;
                drpSendto.DataBind();
            }

        }


        private void BindReminderFor()
        {
            SqlCommand cmd = new SqlCommand("SELECT ToUser,id FROM ServiceRequest_Track_PIP WHERE isActive=1 AND ServiceId='" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                ddlFrom.DataSource = dt;
                ddlFrom.DataBind();
                ddlFrom.DataTextField = "ToUser";
                ddlFrom.DataValueField = "id";
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, "Reminder To");


            }
            else
            {
                ddlFrom.ClearSelection();
                ddlFrom.DataSource = dt;
                ddlFrom.DataBind();
            }

        }


        protected void btnPIPComment_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";

                /*
                //New - for checking file uploaded or not 
                if (Convert.ToString(Session["Name"]) == "")
                {
                    MessageBox1.ShowSuccess("Please Upload Signed MOM first");
                    return;                    
                }
                else
                {
                */
                if (Convert.ToString(Session["UserName"]) == "aceo_a" || Convert.ToString(Session["UserName"]) == "MD@UPSIDC" || Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                {
                    if (drpSendto.SelectedValue.Length <= 0)
                    {
                        MessageBox1.ShowWarning("No recipient to forward");
                        return;
                    }
                }

                /*
                if (txtComment.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Enter Comments in the comments box");
                    return;
                }
                */


                int retVal = 0;
                if (Convert.ToString(Session["Name"]).Length <= 0)
                {
                    filePath = "";

                }
                else
                {
                    filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                }

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TransferFrom = lblLevel.Text.Trim();
                objServiceTimelinesBEL.TransferTo = "MD@UPSIDC";
                objServiceTimelinesBEL.FromUser = UserName.Trim();
                objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                objServiceTimelinesBEL.TransferPIPCommStatus = ddlTransferStatus.SelectedValue.Trim();
                retVal += objServiceTimelinesBLL.TransferCommitteeApplicationPIP(objServiceTimelinesBEL);

                if (retVal > 0)
                {
                    if (filePath.Length > 0)
                    {
                        File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                    }
                    lbluploadingMsg.Text = "";

                    MessageBox1.ShowSuccess("Application Submitted successfully");
                    txtComment.Text = "";
                    Session["Name"] = "";
                    BindTransferToDdl();
                }
                else
                {
                    MessageBox1.ShowSuccess("Erron In Transferring Application");
                    return;
                }
                /*
                //New - for checking file uploaded or not 
                }*/
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                {
                    if (Convert.ToString(Session["Name"]).Length <= 0)
                    {
                        string msg = "Kindly upload copy of MOM in pdf format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }

                string filePath = "";

                if (drpSendto.SelectedValue.Length <= 0)
                {
                    MessageBox1.ShowWarning("No recipient to forward");
                    return;
                }

                if (txtComment.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Enter Comments in the comments box");
                    return;
                }


                int retVal = 0;
                int retValMOM = 0;

                if (ddlTransferStatus.SelectedValue.Trim() == "Reject")
                {
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.TransferFrom = UserName.Trim();
                    objServiceTimelinesBEL.TransferTo = "KN_Srivastava";
                    objServiceTimelinesBEL.FromUser = UserName.Trim();
                    objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                    objServiceTimelinesBEL.TransferPIPCommStatus = ddlTransferStatus.SelectedValue.Trim();
                    if (Convert.ToString(Session["Name"]).Length <= 0)
                    {
                        filePath = "";
                    }
                    else
                    {
                        filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                    }
                    objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                    retVal += objServiceTimelinesBLL.TransferApplicationPIP(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        if (filePath.Length > 0)
                        {
                            File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        }
                        lbluploadingMsg.Text = "";
                        niveshmitrastatusupdate();
                        MessageBox1.ShowSuccess("Application forwarded successfully");
                        txtComment.Text = "";
                        Session["Name"] = "";
                        BindTransferToDdl();
                        Response.Redirect("PIPInbox.aspx", false);
                    }
                    else
                    {
                        MessageBox1.ShowSuccess("Erron In Transferring Application");
                        return;
                    }
                }
                else
                {

                    foreach (ListItem drpSendto in this.drpSendto.Items)
                    {
                        if (drpSendto.Selected == true)
                        {
                            DataSet ds = new DataSet();
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                            objServiceTimelinesBEL.TransferFrom = UserName.Trim();
                            objServiceTimelinesBEL.TransferTo = drpSendto.Value.Trim();
                            objServiceTimelinesBEL.FromUser = UserName.Trim();
                            objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                            objServiceTimelinesBEL.TransferPIPCommStatus = ddlTransferStatus.SelectedValue.Trim();


                            if (Convert.ToString(Session["Name"]).Length <= 0)
                            {
                                filePath = "";

                            }
                            else
                            {
                                filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                            }
                            objServiceTimelinesBEL.LAWDocPath = filePath.Trim();

                            objServiceTimelinesBEL.LetterFrom = "Committee";
                            DateTime MOMDateTime = DateTime.Now;
                            objServiceTimelinesBEL.LetterDate = MOMDateTime;// Convert.ToDateTime((date_to_be));
                            objServiceTimelinesBEL.Remarks = "MOM Uploaded";
                            objServiceTimelinesBEL.CreatedBy = UserName.Trim();
                            if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                            {

                                retValMOM = objServiceTimelinesBLL.InsertMeetingMinutesPIP(objServiceTimelinesBEL);
                                if (retValMOM > 0)
                                {
                                    File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                                    //string msg = "Office Order details saved successfully";
                                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                                }
                                else
                                {
                                    string msg = "MOM Document No Uploaded.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                                    return;
                                }
                            }
                            if (Convert.ToString(Session["Name"]).Length <= 0)
                            {
                                filePath = "";

                            }
                            else
                            {
                                filePath = "~/PIPCorrespondenceLetters/" + Convert.ToString(Session["Name"]);
                            }
                            objServiceTimelinesBEL.LAWDocPath = filePath.Trim();

                            retVal += objServiceTimelinesBLL.TransferApplicationPIP(objServiceTimelinesBEL);
                        }
                    }


                    if (retVal > 0)
                    {
                        if (filePath.Length > 0)
                        {
                            File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        }
                        lbluploadingMsg.Text = "";

                        niveshmitrastatusupdate();

                        MessageBox1.ShowSuccess("Application forwarded successfully");
                        txtComment.Text = "";
                        Session["Name"] = "";
                        BindTransferToDdl();
                        Response.Redirect("PIPFINInbox.aspx", false);
                    }
                    else
                    {
                        MessageBox1.ShowSuccess("Erron In Transferring Application");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }

        public void fetchNMdetails()
        {
            try
            {

                using (con)
                {
                   
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceRequests WHERE ServiceRequestNO ='" + ServiceReqNo + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ControlID = sdr["NMControlID"].ToString();
                            UnitID = sdr["NMUnitId"].ToString();
                            ServiceID = sdr["NMServiceId"].ToString();

                            RequestID = sdr["NMRequestID"].ToString();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void niveshmitrastatusupdate()
        {

            try
            {
                fetchNMdetails();

                Status_Code = "05";
                if (Convert.ToString(Session["UserName"]) == "aceo_a")
                {
                    Remarks = "Application Forwarded to CEO";
                    pendancyLevel = "Pending At CEO Level";
                }
                else if (Convert.ToString(Session["UserName"]) == "MD@UPSIDC")
                {
                    if (ddlTransferStatus.SelectedValue.Trim() == "Reject")
                    {
                        Remarks = "MOM is Rejected and Forwarded to Nodal Officer";
                        pendancyLevel = "Pending At Nodal Officer";
                    }
                    else
                    {
                        Remarks = "Application Forwarded to Evalution Committee";
                        pendancyLevel = "Pending At Evalution Committee";

                    }
                }
                else if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                {
                    Remarks = "Application Forwarded to ACEO";
                    pendancyLevel = "Pending At ACEO Level";
                }
                else
                {
                    Remarks = "Application Forwarded to Nodal Officer";
                    pendancyLevel = "Pending At Nodal Officer";
                }


                string Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "05", Remarks, RequestID, pendancyLevel, "");
                if (Result == "SUCCESS")
                {

                }
                else
                {

                }
            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }


        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                int maxFileSize = 1;


                if (fileupload1.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath = fileupload1.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = fileupload1.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }

                    bool exist = Directory.EnumerateFiles(Server.MapPath("PIPCorrespondenceLetters"), filename).Any();

                    if (exist == true)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Letter with same file name already exists');", true);
                        return;
                    }

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

                        Stream fs = fileupload1.PostedFile.InputStream;
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


        private void BindUsersList()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetUserForwardedList(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["reminder1"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["Reminder1"].ToString();
                        ds.Tables[0].Rows[i]["reminder2"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["Reminder2"].ToString();
                        ds.Tables[0].Rows[i]["reminder3"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["Reminder3"].ToString();
                        ds.Tables[0].Rows[i]["reminder4"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["Reminder4"].ToString();
                        ds.Tables[0].Rows[i]["reminder5"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["Reminder5"].ToString();

                    }
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    cs.str = "SELECT top 1 isnull(remCount,0) FROM ServiceRequest_Track_PIP WHERE ServiceId='" + ServiceReqNo + "' and IsActive='1' order by id desc ";
                    int count = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                    if (count < 5)
                    {
                        BindReminderFor();
                        PanelReminder.Visible = true;
                        //FileUpload1.Visible = true;
                        //btnReminder.Visible = true;
                    }
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnUploadReminder_Click(object sender, EventArgs e)
        {
            int maxFileSize = 1;
            if (ddlFrom.SelectedIndex > 0)
            {
                if (FileUploadReminder.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath = FileUploadReminder.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = FileUploadReminder.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }
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

                        Stream fs = FileUploadReminder.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.LAName = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;

                        Session["LAFileName"] = objServiceTimelinesBEL.LAName;
                        Session["LAFileExt"] = objServiceTimelinesBEL.content;
                        Session["LAFile"] = objServiceTimelinesBEL.Uploadfile;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;

                        if (Convert.ToString(Session["LAFileName"]).Length <= 0)
                        {
                            filePath = "";

                        }
                        else
                        {
                            filePath = "~/PIP/Reminder/" + Convert.ToString(Session["LAFileName"]);

                        }
                        cs.str = "select   id,isnull(remCount,0)as remCount from ServiceRequest_Track_PIP where ServiceId='" + ServiceReqNo.Trim() + "' and id='" + ddlFrom.SelectedValue + "' and IsActive='1' order by id desc";
                        //int ids = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                        DataTable dt = new DataTable();
                        dt = cs.GetDataTable(cs.str);
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 0)
                            {
                                cs.str = "update ServiceRequest_Track_PIP set remCount=1,Reminder1='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy1='" + UserName + "',remDate1='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 1)
                            {
                                cs.str = "update ServiceRequest_Track_PIP set remCount=2,Reminder2='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy2='" + UserName + "',remDate2='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 2)
                            {
                                cs.str = "update ServiceRequest_Track_PIP set remCount=3,Reminder3='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy3='" + UserName + "',remDate3='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 3)
                            {
                                cs.str = "update ServiceRequest_Track_PIP set remCount=4,Reminder4='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy4='" + UserName + "',remDate4='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }
                            else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 4)
                            {
                                cs.str = "update ServiceRequest_Track_PIP set remCount=5,Reminder5='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy5='" + UserName + "',remDate5='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                                cs.ExecuteSql(cs.str);
                            }

                            if (filePath.Length > 0)
                            {
                                File.WriteAllBytes(Server.MapPath(filePath), Session["LAFile"] as byte[]);

                            }

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Reminder File uploaded Successfully');", true);

                            BindUsersList();

                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        return;

                    }

                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Reminder To');", true);
                lbluploadingMsg.Visible = true;
                return;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();

                SqlCommand cmd = new SqlCommand("select Comments, Convert(varchar,CommentDate,103),ToUser from ServiceRequest_Track_PIP where ID='" + ID.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {



                    if (dt.Rows[0][0].ToString().Length <= 0)
                    {
                        lblComments.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        lblComments.Text = "Comments Pending";
                    }
                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();


                }
                else
                {
                    lblComments.Text = "Comments Pending";

                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();

                }






                e.Row.Cells[4].Attributes.Add("onclick", "ShowPopup()");
                e.Row.Cells[4].Attributes.Add("style", "background: antiquewhite !important;width: 200px !important;cursor:pointer;");

            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                string ID = GridView2.DataKeys[index].Values[0].ToString();

                SqlCommand cmd = new SqlCommand("select Comments, Convert(varchar,CommentDate,103),ToUser from ServiceRequest_Track_PIP where ID='" + ID.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {



                    if (dt.Rows[0][0].ToString().Length <= 0)
                    {
                        lblComments.Text = "Comments Pending";
                    }
                    else
                    {
                        lblComments.Text = dt.Rows[0][0].ToString();

                    }
                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();


                }
                else
                {
                    lblComments.Text = "Comments Pending";

                    change_title.Text = "Comments Received From " + dt.Rows[0][2].ToString();

                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowPopup()", true);

            }
        }
    }
}