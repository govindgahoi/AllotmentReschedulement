using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_DAUploadLease : System.Web.UI.UserControl
    {
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();


        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequestID = "";

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
        public string IAIDs { get; set; }
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
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID    = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequestID = NMSWP.Rows[0][3].ToString();
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
                GetDetails();

            }
            catch (Exception ex)
            {

            }

        }



        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnTracing);
                scriptManager.RegisterPostBackControl(LinkButton1);
        }

        protected void imgdocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (FileUploadLease.HasFile)
                {
                    string filePath = FileUploadLease.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUploadLease.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    int fileSize = FileUploadLease.PostedFile.ContentLength;
                    if (fileSize > (3 * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                        return;
                    }
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
                        Stream fs = FileUploadLease.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename         = filename;
                        objServiceTimelinesBEL.content          = contenttype;
                        objServiceTimelinesBEL.Uploadfile       = bytes;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.UserName         = UserName;
                        objServiceTimelinesBEL.UserId           = UserId;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadPlotLeaseDeed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                       
                        MessageBox1.ShowSuccess("Lease Deed Uploaded Successfully !");
                        GetDetails();
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
                    MessageBox1.ShowError("Please Upload Lease Deed");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int retval = 0;

                SqlCommand cmd = new SqlCommand("sp_SignedDocUploded '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string Tracing = dt.Rows[0]["SignedLease"].ToString();
                    string RegisteredLease = dt.Rows[0]["RegisteredLease"].ToString();
                    if (Tracing.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Please upload Signed Lease Deed");
                        return;
                    }
                    if (RegisteredLease.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Please upload Registered Lease Deed");
                        return;
                    }

                    if (txtRDate.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Registry Date");
                        return;
                    }
                    if(txtLeaseBookNo.Text=="")
                    {
                        MessageBox1.ShowWarning("Please Enter Book No");
                        return;
                    }
                    if (txtBindingNo.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Book Binding No");
                        return;
                    }
                    if (txtPageFrom.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Page From");
                        return;
                    }
                    if (txtPageTo.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Page To");
                        return;
                    }
                    if (txtSerialNo.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Serial No");
                        return;
                    }
                    string Date = DateTime.ParseExact(txtRDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.LeaseRegistryDate = Convert.ToDateTime(Date);
                    objServiceTimelinesBEL.ServiceRequestNO  = ServiceReqNo;
                    objServiceTimelinesBEL.LeaseBahi         = txtLeaseBookNo.Text;
                    objServiceTimelinesBEL.LeaseJild         = txtBindingNo.Text;
                    objServiceTimelinesBEL.LeasePageFrom     = txtPageFrom.Text;
                    objServiceTimelinesBEL.LeasePageTo       = txtPageTo.Text;
                    objServiceTimelinesBEL.LeaseSrNo         = txtSerialNo.Text;
                    retval = objServiceTimelinesBLL.SaveLeaseDetails(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        //if (SWCControlID.Length > 0)
                        //{
                        //    string NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + ServiceReqNo.Trim() + "&DocType=Registered Lease";
                        //    string NMSWP_Result = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, (15).ToString(), "RM Approved Application and Issued NOC to | Applicant", NOC_URL, ServiceReqNo, SWCRequestID, "");
                        //}
                        MessageBox1.ShowSuccess("Lease Deed Process Completed Successfully. kindly Transfer File to JE Scheduling appointment for possession !!!");
                        GetDetails();
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowWarning("Please upload Registered Lease Deed");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }

        }

        private void GetDetails()
        {
            SqlCommand cmd = new SqlCommand("GetdetailsRegistrationLeaseDeed '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();         
            adp.Fill(ds);
            DataTable dt  = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                string LeaseRegistryDate = dt.Rows[0]["LeaseRegistryDate"].ToString();
                string Doc = dt.Rows[0]["Document"].ToString();
                if (LeaseRegistryDate.Length > 0)
                {
                    btnSave.Text = "Locked";
                    btnSave.Enabled = false;
                    txtRDate.Text = LeaseRegistryDate;
                    FileUploadLease.Visible = false;
                    btnTracing.Visible = false;
                    FileUpload1.Visible = false;
                    LinkButton1.Visible = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }

                if(dt1.Rows.Count>0)
                {
                    txtLeaseBookNo.Text = dt1.Rows[0]["Lease_bookno"].ToString();
                    txtBindingNo.Text   = dt1.Rows[0]["Lease_bookbinding"].ToString();
                    txtPageFrom.Text    = dt1.Rows[0]["Lease_pagefrom"].ToString();
                    txtPageTo.Text      = dt1.Rows[0]["Lease_pageto"].ToString();
                    txtSerialNo.Text    = dt1.Rows[0]["Lease_srno"].ToString();
                    
                }


            }
        }

        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo='" + ServiceReqNo + "' and ServiceID=1001 and DocType='Registered Lease'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Document"].ToString().Length > 0)
                {
                    String js = "window.open('DocViewerRegisteredLease.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Type=1', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerRegisteredLease.aspx", js, true);
                }

            }
            else
            {
                MessageBox1.ShowError("Plot Registered Lease Deed Not Uploaded Yet");
            }
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GetdetailsRegistrationLeaseDeed '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string SignedLease = dt.Rows[0]["SignedLeaseDeedDoc"].ToString();
                if (SignedLease.Length > 0)
                {
                    Response.Write("<script>window.open ('" + SignedLease.Trim().Remove(0, 2) + "','_blank');</script>");
                }
                else
                {

                    MessageBox1.ShowError("Plot Signed Lease Deed Not Uploaded Yet");

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (FileUpload1.HasFile)
                {
                    Byte[] bytes = null;
                    string filePath = FileUpload1.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUpload1.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    if (fileSize > (3 * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                        return;
                    }
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
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.UserName = UserName;
                        objServiceTimelinesBEL.UserId = UserId;
                        objServiceTimelinesBEL.DocPath = "~/SignedLeaseDeed/" + AllotteeID + "/" + filename;

                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadSignedLeaseDeed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        if (SWCControlID.Length > 0)
                        {

                            SqlCommand cmd = new SqlCommand("GetdetailsRegistrationLeaseDeed '" + ServiceReqNo.Trim() + "'", con);
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string SignedLease = dt.Rows[0]["SignedLeaseDeedDoc"].ToString();

                                if (SignedLease.Length > 0)
                                {
                                    string NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + ServiceReqNo.Trim() + "&DocType=SignedLease";

                                    string NMSWP_Result = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, (15).ToString(), "RM Approved Application and Issued NOC to | Applicant", NOC_URL, ServiceReqNo, SWCRequestID, "");
                                }
                                string folderPath = Server.MapPath("~/SignedLeaseDeed/" + AllotteeID + "/");

                                //Check whether Directory (Folder) exists.
                                if (!Directory.Exists(folderPath))
                                {
                                    //If Directory (Folder) does not exists. Create it.
                                    Directory.CreateDirectory(folderPath);
                                }
                                //fu.SaveAs(folderPath + Path.GetFileName(fu.FileName));
                                File.WriteAllBytes(folderPath + filename, bytes);


                            }
                            MessageBox1.ShowSuccess("Signed Lease Deed Uploaded Successfully !");
                            GetDetails();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Signed Lease Deed");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }
    }
}