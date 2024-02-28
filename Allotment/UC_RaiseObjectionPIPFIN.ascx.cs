using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_RaiseObjectionPIPFIN : System.Web.UI.UserControl
    {
        SqlConnection con;


        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        Mdal objMdal = new Mdal();
        #endregion
        private System.Delegate _delPageMethod;
        GeneralMethod gm = new GeneralMethod();
        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }

        string UserName = "";
        string ReasonDetails;
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";
        Classes.Class1 cs = new Classes.Class1();
        #region akshat
        string Pendancy_level = "";
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
        string Update_Result = "";
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


        #endregion
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
                PreviousDues();

            }
            catch (Exception ex)
            {
            }

        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnReminder);
        }
        public void fetchNMdetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
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
                        //DocPath = sdr["DocPath"].ToString();
                    }
                    con.Close();
                }
            }
        }
        public void niveshmitrastatusupdate()
        {
            // ddlLetterType
            try
            {
                fetchNMdetails();
                //if (ddlLetterType.SelectedValue.Trim() == "1")
                //{
                //    Status_Code = "15";
                //    Remarks = "Warehouse Form Submitted";
                //    Remarks = "RM Approved Application and Issued LOC to | Applicant";
                //    NOC_URL = "http://services.stagingupsida.com/PIPCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                //}
                //else if (ddlLetterType.SelectedValue.Trim() == "2")
                //{
                //    Objection_Rejection_Code = "486";
                //    Status_Code = "07";
                //    Remarks = "Application Rejected | Applicant";
                //    NOC_URL = "http://services.stagingupsida.com/PIPCorrespondenceLetters/LOA/" + Convert.ToString(Session["Name"]);
                //}
                // GeneralMethod gm = new GeneralMethod();

                Status_Code = "08";

                Remarks = ddlReasonDetails.SelectedItem.Text.Trim() + " | Nodal Officer " + ServiceReqNo.Trim() + " raises query and objection to Applicant";
                 ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                string Result = Update_Result = webService.WReturn_CUSID_STATUS(
                ControlID,
                UnitID,
                ServiceID,
                ProcessIndustryID,
                ApplicationID,
                Status_Code,
                Remarks,
                "Pending at Applicant",
                Fee_Amount,
                Fee_Status,
                Transaction_ID,
                Transaction_Date,
                Transaction_Date_Time,
                NOC_Certificate_Number,
                NOC_URL,
                ISNOC_URL_ActiveYesNO,
                passsalt,
                RequestID,
                Objection_Rejection_Code,
                "yes",
                Certificate_EXP_Date_DDMMYYYY,
                D1,
                D2,
                D3,
                D4,
                D5,
                D6,
                D7
                     );
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
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                int retVal1 = 0;
                if (txtObjectionDesc.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Objection desription');", true);
                    return;
                }
                if (Convert.ToString(Session["LAFileName"]).Length <= 0)
                {
                    filePath = "";

                }
                else
                {
                    filePath = "~/PIP/Objections/" + Convert.ToString(Session["LAFileName"]);

                }

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.UserName = UserName;

                objServiceTimelinesBEL.PIPReasonDetails = ddlReasonDetails.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ObjectionDesc = txtObjectionDesc.Text;
                objServiceTimelinesBEL.LAName = Convert.ToString(Session["LAFileName"]);
                objServiceTimelinesBEL.LAContentType = Convert.ToString(Session["LAFileExt"]);
                objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                niveshmitrastatusupdate();

                if (Update_Result == "SUCCESS")
                {
                    retVal1 = objMdal.RaiseObjectionPIP(objServiceTimelinesBEL);
                    if (retVal1 > 0)
                    {
                        if (filePath.Length > 0)
                        {
                            File.WriteAllBytes(Server.MapPath(filePath), Session["LAFile"] as byte[]);

                        }
                        SendDuesObjectionMailGeneral();
                        Response.Redirect("~/PIPFINInbox.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private DataTable Getdata1
        {
            get; set;
        }


        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }


        private void PreviousDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetPreviousDuesPIP '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["reminder1"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["reminder1"].ToString();
                        ds.Tables[0].Rows[i]["reminder2"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["reminder2"].ToString();
                        ds.Tables[0].Rows[i]["reminder3"] = "~/PIP/Reminder/" + ds.Tables[0].Rows[i]["reminder3"].ToString();

                    }
                    GridView1.DataSource = Getdata1;
                    GridView1.DataBind();
                    cs.str = "SELECT top 1 isnull(remCount,0) FROM PIPObjectionLookUp WHERE ServiceReqNo='" + ServiceReqNo + "' and IsActive='1' order by id desc ";
                    int count = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                    if (count < 3)
                    {
                        PanelReminder.Visible = true;
                        //FileUpload1.Visible = true;
                        //btnReminder.Visible = true;
                    }
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnUploadReminder_Click(object sender, EventArgs e)
        {
            int maxFileSize = 1;

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
                    cs.str = "select  top 1 id,isnull(remCount,0)as remCount from PIPObjectionLookUp where ServiceReqNo='" + ServiceReqNo.Trim() + "' and IsActive='1' order by id desc";
                    //int ids = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                    DataTable dt = new DataTable();
                    dt = cs.GetDataTable(cs.str);
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 0)
                        {
                            cs.str = "update PIPObjectionLookUp set remCount=1,reminder1='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy='" + UserName + "',remDate='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                            cs.ExecuteSql(cs.str);
                        }
                        else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 1)
                        {
                            cs.str = "update PIPObjectionLookUp set remCount=2,reminder2='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy2='" + UserName + "',remDate2='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                            cs.ExecuteSql(cs.str);
                        }
                        else if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 2)
                        {
                            cs.str = "update PIPObjectionLookUp set remCount=3,reminder3='" + Convert.ToString(Session["LAFileName"]) + "',reminderBy3='" + UserName + "',remDate3='" + cs.getdatetime() + "' where id='" + dt.Rows[0][0].ToString() + "'";
                            cs.ExecuteSql(cs.str);
                        }


                        if (filePath.Length > 0)
                        {
                            File.WriteAllBytes(Server.MapPath(filePath), Session["LAFile"] as byte[]);

                        }

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Reminder File uploaded Successfully');", true);

                        PreviousDues();

                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                    return;

                }

            }
        }


        private void SendDuesObjectionMailGeneral()
        {

            try
            {


                string Objection = txtObjectionDesc.Text;

                SqlCommand cmd = new SqlCommand("GetApplicantDetailsForPIPFINCommunication '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();


                    MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //  newmsg.IsBodyHtml = true;

                    if (Session["LAFile"] != null)
                    {
                        newmsg.Attachments.Add(new Attachment(new MemoryStream(Session["LAFile"] as byte[]), "ObjectionDoc.pdf"));
                    }

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ObjectionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Objection}", Objection.Trim());
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo.Trim());
                    StrContent = StrContent.Replace("{ServiceName}", "Application for Issuance of Unique Id for Private Industrial Parks");
                    StrContent = StrContent.Replace("{Link}", "http://localhost:50610/ApplicationForPIP.aspx?ID=" + HttpUtility.UrlEncode(Encrypt(ServiceReqNo)));


                    newmsg.Subject = "UPSIDAeService: Intimation for objection on your application for Issuance of Unique Id for Private Industrial Parks";
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    //  string s = gm.SendOTP("OTP", PhoneNo, ApplicantName, "Dear Applicant please clear the objection raised by UPSIDA against your application ref no " + ServiceReqNo + ".");


                }
            }
            catch (Exception ex)
            {

            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int maxFileSize = 3;

            if (FileUploadLoaction.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = FileUploadLoaction.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;
                int fileSize = FileUploadLoaction.PostedFile.ContentLength;
                if (fileSize > (maxFileSize * 1024 * 1024))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
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
                    Stream fs = FileUploadLoaction.PostedFile.InputStream;
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
                        filePath = "~/PIP/Objections/" + Convert.ToString(Session["LAFileName"]);

                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                    return;

                }

            }
            else
            {

            }
        }
    }
}