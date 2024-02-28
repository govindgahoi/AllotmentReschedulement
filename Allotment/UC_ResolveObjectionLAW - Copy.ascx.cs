using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_ResolveObjectionLAW : System.Web.UI.UserControl
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
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";
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
                
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
               
                BindCurrentDues();
                RegisterPostBackControl();
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
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata5
        {
            get; set;
        }
        private DataTable Getdata6
        {
            get; set;
        }
      
   
     
     
        private void RegisterPostBackControl()
        {
         
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpload);         
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkView1);
            
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                
                int maxFileSize = 1;

                if (fileupload.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath    = fileupload.PostedFile.FileName;
                    string filename    = Path.GetFileName(filePath);
                    string ext         = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = fileupload.PostedFile.ContentLength;
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

                        Stream fs = fileupload.PostedFile.InputStream;
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

     
        protected void lnkView1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("[sp_GetCurrentPendingObjection] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    string filePath = dt.Rows[0]["UserDocPath"].ToString();
                    Response.Write("<script>window.open ('" + filePath.Trim().Remove(0, 2) + "','_blank');</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void BindCurrentDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_GetCurrentPendingObjection] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                    if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtclarification.Text = Getdata1.Rows[0]["Desc"].ToString();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            GridView1.DataSource = Getdata2;
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        txtclarification.Text = "";
                    }
                }
                

            }
            catch (Exception)
            {
                throw;
            }

        }
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
        public void niveshmitrastatusupdate()
        {
            // ddlLetterType
            try
            {


                fetchNMdetails();

                Status_Code = "14";

                Remarks = "Form Re-Submitted & Pending At Nodal Officer WareHousing";
                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                Update_Result = webService.WReturn_CUSID_STATUS(
                ControlID,
                UnitID,
                ServiceID,
                ProcessIndustryID,
                ApplicationID,
                Status_Code,
                Remarks,
                "Nodal Office Level",
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

            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string filePath = "~/LogisticAndWareHousing/Objections/" + Convert.ToString(Session["Name"]);

                niveshmitrastatusupdate();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                objServiceTimelinesBEL.responseMessage = txtResponse.Text.Trim();
                objServiceTimelinesBEL.filename = Session["Name"].ToString();
                objServiceTimelinesBEL.content = Session["Ext"].ToString();
                objServiceTimelinesBEL.LAWDocPath = filePath.Trim();
                if(Update_Result== "SUCCESS")
                { 
                int retval = objServiceTimelinesBLL.SaveObjectionResponseLAW(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    File.WriteAllBytes(Server.MapPath(filePath), Session["Doc"] as byte[]);

                    //this.Page.GetType().InvokeMember("Redirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { ServiceReqNo });
                    Response.Redirect("https://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx");

                }
              }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
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

    }
}