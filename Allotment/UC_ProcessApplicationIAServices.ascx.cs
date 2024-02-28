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
    public partial class UC_ProcessApplicationIAServices : System.Web.UI.UserControl
    {
        SqlConnection con;
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string IAID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
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
        public string ServiceID = "";

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RegisterPostBackControl();
                string[] SerIdarray = ServiceReqNo.Split('/');

                AllotteeID = SerIdarray[2].Trim();
                ServiceID = SerIdarray[1].Trim();

                Page.Form.Enctype = "multipart/form-data";


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();
                decimal plotArea = Convert.ToDecimal(NMSWP.Rows[0][4]);
                int landuseCode = Convert.ToInt32(NMSWP.Rows[0][5]);
                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                    if (Level == "JE")
                    {
                        UploadTB.Visible = true;
                    }
                    else
                    {
                        UploadTB.Visible = false;
                    }
                    //if (Level == "CMIA")
                    //{
                    //    drpRecommendation.Items.Clear();
                    //    drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
                    //    drpRecommendation.Items.Insert(1, new ListItem("Approve", "Approve"));
                    //    drpRecommendation.Items.Insert(2, new ListItem("Not Approve", "Not Approve"));
                    //    drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
                    //    drpRecommendation.DataBind();
                    //}
                    #region Faizan

                    if (Level == "CMIA")
                    {
                        if (ServiceID == "1012")
                        {
                            if (landuseCode == 2)
                            {
                                if (plotArea > 500 && plotArea < 20235)
                                {
                                    isApprover();
                                }
                                else
                                {
                                    isRecommender();
                                }
                            }
                            else
                            {
                                if (plotArea < 20235)
                                {
                                    isApprover();
                                }
                                else
                                {
                                    isRecommender();
                                }
                            }
                        }
                        else
                        {
                            isApprover();
                        }

                    }

                    else if (Level == "JMD")
                    {
                        if (ServiceID == "1012")
                        {
                            if (plotArea > 20234 && plotArea < 60703)
                            {
                                isApprover();
                            }
                            else
                            {
                                isRecommender();
                            }
                        }
                        else
                        {
                            isApprover();
                        }
                    }
                    #endregion

                    #region 4 Service ID 1002 by Gorakh
                    else if (Level == "RM" && ServiceID == "1002")
                    {
                        if (GetTime4ServiceID1002ByReqNo() <= 12)
                        {
                            isApprover();
                        }
                        else
                        {
                            isRMApprover();
                        }
                           

                    }
                    #endregion
                    else if (DataManager == "Final Approver")
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

                SqlCommand cmd1 = new SqlCommand("Select A.ControlId, A.UnitId, A.ServiceId, B.Id from AllotteeMaster A , IndustrialArea B where A.AllotteeID = '" + AllotteeID + "' and A.IndustrialArea = B.IAName", con);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    ViewState["ControlID"] = dt1.Rows[0]["ControlId"].ToString();
                    ViewState["UnitID"] = dt1.Rows[0]["UnitId"].ToString();
                    ViewState["ServiceID"] = dt1.Rows[0]["ServiceId"].ToString();
                    IAID = dt1.Rows[0]["Id"].ToString();
                }

            }
            catch (Exception ex) { }
            BindTransferToDdl();
        }
        protected void isApprover()
        {
            drpRecommendation.Items.Clear();
            drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
            drpRecommendation.Items.Insert(1, new ListItem("Approve", "Approve"));
            drpRecommendation.Items.Insert(2, new ListItem("Not Approve", "Not Approve"));
            drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
            drpRecommendation.DataBind();
        }

        protected void isRMApprover()
        {
            drpRecommendation.Items.Clear();
            drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
            drpRecommendation.Items.Insert(1, new ListItem("Approve", "Approve"));
            drpRecommendation.Items.Insert(1, new ListItem("Recommended", "Recommended"));
            drpRecommendation.Items.Insert(2, new ListItem("Not Approve", "Not Approve"));
            drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
            drpRecommendation.DataBind();
        }
        protected void isRecommender()
        {
            drpRecommendation.Items.Clear();
            drpRecommendation.Items.Insert(0, new ListItem("--Select--", "0"));
            drpRecommendation.Items.Insert(1, new ListItem("Recommended", "Recommended"));
            drpRecommendation.Items.Insert(2, new ListItem("Not Recommended", "Not Recommended"));
            drpRecommendation.Items.Insert(3, new ListItem("Clarification", "Clarification"));
            drpRecommendation.DataBind();
        }
        #region Gorakh 4 Service ID 1002

        private int GetTime4ServiceID1002ByReqNo()
        {
            //[GetNewTEFValidation] 25308,'SER20201202/1002/25308/9802','','','','',''
            int Applied4Time = 0;
            con.Open();
            //SqlCommand cmd = new SqlCommand("[GetNewTEFValidation] " + AllotteeID.Trim() + ", '" + ServiceReqNo.Trim() + "', '','','','',''", con);
            //SqlDataAdapter adp1 = new SqlDataAdapter(cmd);
            //DataTable dt1 = new DataTable();
            //adp1.Fill(dt1);
            //if (dt1.Rows.Count > 0)
            //{
            //    int.TryParse(dt1.Rows[0][3].ToString(), out Applied4Time);
            //}
            using (SqlCommand cmd = new SqlCommand("GetNewTEFValidation", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input Parameters
                cmd.Parameters.AddWithValue("@AllotteeID", AllotteeID.Trim());
                cmd.Parameters.AddWithValue("@ServiceReqNo", ServiceReqNo.Trim());

                // Output Parameters
                SqlParameter tefLeasedeedsignParam = new SqlParameter("@TefLeasedeedsign", SqlDbType.Bit);
                tefLeasedeedsignParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(tefLeasedeedsignParam);

                SqlParameter tefPossessionParam = new SqlParameter("@Tefpossession", SqlDbType.Bit);
                tefPossessionParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(tefPossessionParam);

                SqlParameter tefBuildingPlanApplicationParam = new SqlParameter("@Tefbuildingplanapplication", SqlDbType.Bit);
                tefBuildingPlanApplicationParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(tefBuildingPlanApplicationParam);

                SqlParameter tefTimePeriodParam = new SqlParameter("@Timeperiod", SqlDbType.Int);
                tefTimePeriodParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(tefTimePeriodParam);

                SqlParameter covidStatusParam = new SqlParameter("@CovidStatus", SqlDbType.Bit);
                covidStatusParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(covidStatusParam);

                // Execute the stored procedure
                cmd.ExecuteNonQuery();

                // Retrieve the output parameter values
                if (tefTimePeriodParam.Value != DBNull.Value)
                {
                    Applied4Time = Convert.ToInt32(tefTimePeriodParam.Value);
                }
            }

            return Applied4Time;
        }

        #endregion  
        private void BindTransferToDdl()
        {
            SqlCommand cmd = new SqlCommand("service_request_track_IA'" + ServiceReqNo.Trim() + "'", con);
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
                    case "RM":
                        Forwarded = "Regional Manager";
                        break;
                    case "Draftman_ATP":
                        Forwarded = "Draftman ATP";
                        break;
                    case "ATP":
                        Forwarded = "Incharge ATP";
                        break;
                    case "DM_ATP":
                        Forwarded = "Deputy Manager ATP";
                        break;
                    case "Accountant":
                        Forwarded = "Accountant";
                        break;
                    case "MO":
                        Forwarded = "Middle Officer";
                        break;
                    case "JMD":
                        Forwarded = "Joint MD";
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


                string[] SerIdarray = ServiceReqNo.Split('/');

                string Service = SerIdarray[1].Trim();
                SqlCommand cmd1 = new SqlCommand("CheckReceipient '" + IAID + "','" + Service + "','" + drpSendto.SelectedValue.Trim() + "'", con);
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


                SqlCommand cmd = new SqlCommand("validatemarkings '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                adp.Fill(dss);



                DataTable dt1 = dss.Tables[1];

                if (Level == "JE")
                {
                    if (drpRecommendation.SelectedValue == "Clarification")
                    { }
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
                    filePath = "~/ProceedingDocuments/" + ServiceID.Trim() + "/" + AllotteeID.Trim() + "/" + Convert.ToString(Session["Name"]);
                }

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TransferFrom = Level.Trim();
                objServiceTimelinesBEL.TransferTo = drpSendto.SelectedValue.Trim();
                objServiceTimelinesBEL.FromUser = UserName.Trim();
                objServiceTimelinesBEL.RecStatus = drpRecommendation.SelectedValue.Trim();
                objServiceTimelinesBEL.Comments = txtComment.Text.Trim();
                objServiceTimelinesBEL.DocPath = filePath.Trim();
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

                    if (SWCControlID.Length > 0)
                    {
                        string Status = "05";
                        string Remarks = Level.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + " Forwarded Application To | " + drpSendto.SelectedValue.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo);

                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status, Remarks, SWCRequest_ID, drpSendto.SelectedValue.Trim() + " " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");

                        //if (NMSWP_Result == "SUCCESS")
                        //{
                        if (ServiceID == "4")
                        {
                            if (Level == "CMIA" || Level == "MD" || Level == "JMD")
                            {
                                Response.Redirect("AllotmentRequestApproval.aspx");
                            }
                            else
                            {
                                Response.Redirect("ServiceRequestInboxNew.aspx");
                            }

                        }
                        else
                        {
                            if (Level == "CMIA" || Level == "MD" || Level == "JMD")
                            {
                                Response.Redirect("ServiceRequestInboxIAApp.aspx");
                            }
                            else
                            {
                                Response.Redirect("ServiceRequestInboxIA.aspx");
                            }

                        }
                        //}
                        //else
                        //{
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + NMSWP_Result + "');", true);
                        //    return;
                        //}
                    }
                    else
                    {
                        if (Level == "CMIA" || Level == "MD" || Level == "JMD")
                        {
                            Response.Redirect("ServiceRequestInboxIAApp.aspx");
                        }
                        else
                        {
                            Response.Redirect("ServiceRequestInboxIA.aspx");
                        }
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