using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_UploadLOALaw : System.Web.UI.UserControl
    {
        SqlConnection con;

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
        public string DocID { get; set; }

        string UserName = "";

        int UserId = 0;
        public string Level = "";
        public string DataManager = "";
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

        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RegisterPostBackControl();

                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void ddlreason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlreason.SelectedValue.Trim() == "2943")
                {
                    txtOtherreason.Visible = true;
                }
                else
                {
                    txtOtherreason.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string msg = "Wrong Input";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                return;
            }


        }

        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnupload);

        }

        protected void ddlLetterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (ddlLetterType.SelectedValue.Trim() == "3")
                {
                    using (con)
                    {
                        resontab.Visible = false;
                        lblUid.Text = "";
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                        SqlCommand cmd = new SqlCommand("SELECT UniqueID, UID, ApplicationId, IsActive, IssueDate, StatuID FROM LogisticWarehousingRegisterUID WHERE ApplicationId ='" + ServiceReqNo + "'", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            lblUid.Text = string.Concat("<strong>UNIQUE ID:</strong> ", dt.Rows[0][1].ToString());
                        }
                        else
                        {
                            SqlCommand cmd2 = new SqlCommand("SELECT ApplicantName FROM LogisticWarehousingRegister WHERE ApplicationId ='" + ServiceReqNo + "'", con);
                            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                            DataTable dt2 = new DataTable();
                            adp2.Fill(dt2);
                            if (dt2.Rows.Count > 0)
                            {
                                try { con.Open(); } catch { }
                                SqlCommand command = con.CreateCommand();
                                command.Connection = con;
                                command.CommandText = ("insert into LogisticWarehousingRegisterUID (UID, ApplicationId, IsActive, IssueDate, StatuID) values ( CONCAT('UID/WL22/', '" + dt2.Rows[0][0].ToString() + "', '/', (select REPLACE(STR(max(RIGHT(StatuID, 3)) + 1,3),' ', '0') from LogisticWarehousingRegisterUID)), '" + ServiceReqNo + "', '1', getdate(), (select max(StatuID) + 1 from LogisticWarehousingRegisterUID))");
                                if (command.ExecuteNonQuery() > 0)
                                {

                                    SqlCommand cmd1 = new SqlCommand("SELECT UniqueID, UID, ApplicationId, IsActive, IssueDate, StatuID FROM LogisticWarehousingRegisterUID WHERE ApplicationId ='" + ServiceReqNo + "'", con);
                                    SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                                    DataTable dt1 = new DataTable();
                                    adp1.Fill(dt1);
                                    if (dt1.Rows.Count > 0)
                                    {
                                        lblUid.Text = string.Concat("<strong>UNIQUE ID:</strong> ", dt1.Rows[0][1].ToString());
                                    }
                                }
                            }
                        }
                        
                    }

                }
                else if (ddlLetterType.SelectedValue.Trim() == "2")
                {
                    resontab.Visible = true;
                    lblUid.Text = "";

                }
                else
                {
                    resontab.Visible = false;
                    lblUid.Text = "";
                }
            }
            catch (Exception ex)
            {
                string msg = "Wrong Input";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                return;
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

                    bool exist = Directory.EnumerateFiles(Server.MapPath("LAWCorrespondenceLetters/MeetingMinutes"), filename).Any();

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
                        //fileupload1.SaveAs(Server.MapPath("~/LAWCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"])));
                        string filename1 = Path.GetFileName(fileupload1.PostedFile.FileName);
                        fileupload1.PostedFile.SaveAs(Server.MapPath("~/LAWCorrespondenceLetters/LOA/" + filename1));
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
        string Update_Result = "";
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



                if (txtLoaDate.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Enter Issue Date");
                    return;
                }

                if (Convert.ToString(Session["Name"]).Length <= 0)
                {
                    string msg = "Kindly upload copy of letter in pdf format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }
                // Session["Name"] = "CRM letter.pdf";
                string filePath = "~/LAWCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                string date_to_be = DateTime.ParseExact(txtLoaDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                niveshmitrastatusupdate();
                objServiceTimelinesBEL.LetterFrom = ddlLetterType.SelectedValue.Trim();
                objServiceTimelinesBEL.LetterDate = Convert.ToDateTime((date_to_be));
                objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                objServiceTimelinesBEL.CreatedBy = UserName.Trim();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                int retVal = objServiceTimelinesBLL.IssueLetterLAW(objServiceTimelinesBEL);
                //  int retVal = 0;
                if (Update_Result == "SUCCESS")
                {
                    if (retVal > 0)
                    {

                        //  File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);
                        Response.Redirect("~/PIPInbox.aspx", false);

                    }
                    else
                    {
                        // niveshmitrastatusupdate();
                        string msg = "Details couldn't be saved";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }

                }
                else
                {
                    Response.Write(Update_Result);
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());

                MessageBox1.ShowWarning(ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        //  string Status_Code, Remarks, NOC_URL, Objection_Rejection_Code,
        public void fetchNMdetails()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LogisticWarehousingRegister WHERE ApplicationId ='" + ServiceReqNo + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        ControlID = sdr["ControlID"].ToString();
                        UnitID = sdr["UnitId"].ToString();
                        ServiceID = sdr["ServiceId"].ToString();

                        RequestID = sdr["RequestID"].ToString();
                        DocPath = sdr["DocPath"].ToString();
                    }
                    con.Close();
                }
            }
        }
        bool check = false;
        public void niveshmitrastatusupdate()
        {
            // ddlLetterType
            try
            {


                fetchNMdetails();
                if (ddlLetterType.SelectedValue.Trim() == "1")
                {
                    Status_Code = "15";
                    // Remarks = "Warehouse Form Submitted";
                    Remarks = "Nodal Officer Approved Application and Issued LOC to | Applicant";
                    NOC_URL = "http://services.stagingupsida.com/LAWCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                }
                else if (ddlLetterType.SelectedValue.Trim() == "3")
                {
                    Status_Code = "15";
                    // Remarks = "Warehouse Form Submitted";
                    Remarks = "Nodal Officer Approved Application and Issued UID to | Applicant";
                    NOC_URL = "http://services.stagingupsida.com/LAWCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                }
                else if (ddlLetterType.SelectedValue.Trim() == "2")
                {

                    if (ddlreason.SelectedValue.Trim() == "0000")
                    {

                        string msg = "Please Select A Reason";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;


                    }

                    if (ddlreason.SelectedValue.Trim() == "2943")
                    {
                        if (string.IsNullOrEmpty(txtOtherreason.Text.Trim()))

                        {
                            string msg = "Please Enter Reason For Rejection";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            return;
                        }

                    }


                    Status_Code = "07";
                    Objection_Rejection_Code = ddlreason.SelectedValue.Trim();
                    //Objection_Rejection_Code = "486";
                    //      if (txtOtherreason.Text.Trim() == "" && ddlreason.SelectedValue.Trim() == "2943")

                    //Remarks = "Application Rejected | Applicant";
                    if (txtOtherreason.Text.Trim() == "" && ddlreason.SelectedValue.Trim() != "2943")
                    {
                        Remarks = ddlreason.SelectedItem.Text.Trim();
                    }
                    else if (ddlreason.SelectedValue.Trim() == "2943" && txtOtherreason.Text.Trim() != "")
                    {
                        Remarks = ddlreason.SelectedItem.Text.Trim() + "   " + txtOtherreason.Text;
                    }
                    else
                    {
                        Remarks = ddlreason.SelectedItem.Text.Trim();
                    }
                    NOC_URL = "http://services.stagingupsida.com/LAWCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                }
                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                Update_Result = webService.WReturn_CUSID_STATUS(
                 ControlID,
                 UnitID,
                 ServiceID,
                 ProcessIndustryID,
                 ApplicationID,
                 Status_Code,
                 Remarks,
                 "",
                 Fee_Amount,
                 Fee_Status,
                 Transaction_ID,
                 Transaction_Date,
                 Transaction_Date_Time,
                 ServiceReqNo,
                 NOC_URL,
                 ISNOC_URL_ActiveYesNO,
                 passsalt,
                 RequestID,
                 Objection_Rejection_Code,
                 "Yes",
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

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }


    }
}