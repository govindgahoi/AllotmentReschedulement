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
    public partial class UC_JEUploadPossession : System.Web.UI.UserControl
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
        public string DocID { get; set; }
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

        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnTracing);
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
                        Stream fs = FileUploadLease.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.UserName = UserName;
                        objServiceTimelinesBEL.UserId = UserId;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadPlotPossessionMemo(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Possession Memo Uploaded Successfully !");

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
                    MessageBox1.ShowError("Please Upload Possession Memo");
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

                SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo='" + ServiceReqNo + "' and ServiceID=1001 and DocType='Possession Memo'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string Tracing = dt.Rows[0]["Document"].ToString();
                    if (Tracing.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Please upload Possession Memo");
                        return;
                    }
                    if (txtRDate.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Date Of Possession Given");
                        return;
                    }
                    if (txtPossessionArea.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Enter Possession Area Given");
                        return;
                    }
                    if (txtGivenTo.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Possession Given To Whom");
                        return;
                    }

                    string Date = DateTime.ParseExact(txtRDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.PossessionGivenDate = Convert.ToDateTime(Date);
                    objServiceTimelinesBEL.PosseessionAreaGiven = Convert.ToDecimal(txtPossessionArea.Text);
                    objServiceTimelinesBEL.PosseessionGivenTo = txtGivenTo.Text;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.DocumentID = DocID;
                    objServiceTimelinesBEL.UserId = UserId;
                    retval = objServiceTimelinesBLL.SavePossessionDetails(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        this.Page.GetType().InvokeMember("AllertRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { "Process Completed Successfully." });

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }

        }
        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo='" + ServiceReqNo + "' and ServiceID=1001 and DocType='Possession Memo'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Document"].ToString().Length > 0)
                {
                    String js = "window.open('DocViewerPossession.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Type=1', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerPossession.aspx", js, true);
                }

            }
            else
            {
                MessageBox1.ShowError("Plot Registered Lease Deed Not Uploaded Yet");
            }
        }
    }
}