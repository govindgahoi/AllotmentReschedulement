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
    public partial class UC_JEDocUpload : System.Web.UI.UserControl
    {
        SqlConnection con;
     
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
            scriptManager.RegisterPostBackControl(btnInspection);
        }

        protected void imgdocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (FileUpload4.HasFile)
                {
                    string filePath = FileUpload4.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUpload4.FileName.ToString());
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
                        Stream fs = FileUpload4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    }
                    else
                    {
                        MessageBox1.ShowError("File should be in pdf format only");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadPlotTracingLeaseDeed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Plot Tracing Uploaded Successfully !");
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
                    MessageBox1.ShowError("Please Upload Plot Tracing");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
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

                    retval = objServiceTimelinesBLL.UploadInspectionReportLeaseDeed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Site Inspection Report Uploaded Successfully !");
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
                    MessageBox1.ShowError("Please Upload Site Inspection Report");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void chkAnyConst_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnyConst.Checked)
            {
                constrUnitDiv.Visible = true;
            }
            else
            { constrUnitDiv.Visible = false; }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int retval = 0;

                SqlCommand cmd = new SqlCommand("select *, convert(varchar(10),JEInsppectionDate,103) 'JEDate' from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNO='" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string Tracing = dt.Rows[0]["PlotTracingDocName"].ToString();
                    if (Tracing.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Please upload Plot Tracing");
                        return;
                    }

                    string InspectionReport = dt.Rows[0]["InspectionReportName"].ToString();
                    if (InspectionReport.Length <= 0)
                    {
                        MessageBox1.ShowWarning("Please upload Site Inspection Report");
                        return;
                    }

                    if (chkAnyConst.Checked)
                    {
                        if (txtValueConst.Text == "")
                        {
                            MessageBox1.ShowWarning("Value of Construction is required");
                            return;
                        }
                    }
                    else
                    {
                        objServiceTimelinesBEL.AnyConstruction = "0";
                    }

                    if (txtArea.Text == "")
                    {
                        MessageBox1.ShowWarning("Area Under Possession is required");
                        return;
                    }
                    if (txtSiteDate.Text == "")
                    {
                        MessageBox1.ShowWarning("Inspection Date is required");
                        return;
                    }
                    if (txtDimension.Text == "")
                    {
                        MessageBox1.ShowWarning("Plot Dimension is required");
                        return;
                    }
                    if (drp_PlotDirection.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Plot Direction is required");
                        return;
                    }

                    if (chkAnyConst.Checked)
                    {
                        objServiceTimelinesBEL.AnyConstruction = "1";
                    }
                    else
                    {
                        objServiceTimelinesBEL.AnyConstruction = "0";
                    }

                    if (chkAnyConst.Checked)
                    {
                        objServiceTimelinesBEL.ConstructionValue = Convert.ToDecimal(txtValueConst.Text);
                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructionValue = Convert.ToDecimal("0.00");
                    }
                    objServiceTimelinesBEL.PosseessionAreaLease = Convert.ToDecimal(txtArea.Text);
                    string Date = DateTime.ParseExact(txtSiteDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.InspectionDateLease = Convert.ToDateTime(Date);
                    objServiceTimelinesBEL.PlotDirection = drp_PlotDirection.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotDimension = txtDimension.Text.Trim();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    retval = objServiceTimelinesBLL.SaveJESiteLeaseDetails(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Site Inspection Details Completed Successfully. kindly Transfer File to Dealing Assistant for further processing !!!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.ToString());
            }

        }

        private void GetDetails()
        {
            SqlCommand cmd = new SqlCommand("select *, convert(varchar(10),JEInsppectionDate,103) 'JEDate' from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNO='" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string IsAnyConstruction = dt.Rows[0]["IsAnyConstruction"].ToString();
                string ConstructionValue = dt.Rows[0]["ValueOfConstruction"].ToString();
                if (IsAnyConstruction == "True")
                {
                    chkAnyConst.Checked = true;
                    constrUnitDiv.Visible = true;
                }
                else
                {
                    chkAnyConst.Checked = false;
                    constrUnitDiv.Visible = false;
                }
                txtSiteDate.Text = dt.Rows[0]["JEDate"].ToString();
                txtValueConst.Text = dt.Rows[0]["ValueOfConstruction"].ToString();
                txtArea.Text = dt.Rows[0]["AreaUnderPossession"].ToString();
                string LeaseSigned = dt.Rows[0]["LeaseDeedExecuted"].ToString();
                txtDimension.Text = dt.Rows[0]["PlotDimension"].ToString();
                drp_PlotDirection.SelectedValue = dt.Rows[0]["PlotDirection"].ToString();
                if (LeaseSigned == "True")
                {
                    txtArea.Enabled = false;
                    txtValueConst.Enabled = false;
                    txtSiteDate.Enabled = false;
                    chkAnyConst.Enabled = false;
                    btnSave.Text = "Locked";
                    btnSave.Enabled = false;
                }
                else
                {
                    txtArea.Enabled = true;
                    txtValueConst.Enabled = true;
                    txtSiteDate.Enabled = true;
                    chkAnyConst.Enabled = true;
                    btnSave.Text = "Save";
                    btnSave.Enabled = true;
                }
                string Tracing = dt.Rows[0]["PlotTracingDocName"].ToString();
                if (Tracing.Length > 0)
                {
                    bttnTracing.Visible = true;
                }
                else
                {
                    bttnTracing.Visible = false;
                }
                string InspectionReport = dt.Rows[0]["InspectionReportName"].ToString();
                if (InspectionReport.Length > 0)
                {
                    btnInspectionReport.Visible = true;
                }
                else
                {
                    btnInspectionReport.Visible = false;
                }
            }
        }

        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_LeaseDeedApplicationStatusMaster] where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["PlotTracing"].ToString().Length > 0)
                {

                    String js = "window.open('DocViewerLease.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Type=1', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLease.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Plot Tracing Not Uploaded Yet");
                }
            }
        }

        protected void btnInspectionReport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_LeaseDeedApplicationStatusMaster] where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["InspectionReport"].ToString().Length > 0)
                {

                    String js = "window.open('DocViewerLease.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Type=2', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLease.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Site Inspection Report Not Uploaded Yet");
                }
            }
        }
    }
}