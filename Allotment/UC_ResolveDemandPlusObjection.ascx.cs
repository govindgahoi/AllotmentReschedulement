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
    public partial class UC_ResolveDemandPlusObjection : System.Web.UI.UserControl
    {
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
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
        public string Service = "";
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string[] SerIdarray = ServiceReqNo.Split('/');
                AllotteeID = SerIdarray[2].Trim();
                Service = SerIdarray[1].Trim();
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                if (Service == "1000")
                {
                    DataTable ServiceReq = gm.GetServiceReqNoMain(ServiceReqNo);
                    ServiceReqNo = ServiceReq.Rows[0][0].ToString();
                }
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();
                BindCurrentDues();
                BindPreviousDues();
                RegisterPostBackControl();
            }
            catch (Exception ex)
            {

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
        protected void CurrentDueGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string IAID = CurrentDueGrid.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata2.Select("DemandId = '" + IAID + "'");
                    DataTable dt1 = dr.CopyToDataTable();
                    GridView grdview = e.Row.FindControl("GridViewCurrentAmount") as GridView;
                    grdview.DataSource = dt1;
                    grdview.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void BindCurrentDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetCurrentDuePending '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                    if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                    if (ds.Tables[2].Rows.Count > 0) { Getdata5 = ds.Tables[2]; }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Text = Getdata1.Rows[0]["Desc"].ToString().Trim();
                        CurrentDueGrid.DataSource = ds.Tables[0];
                        CurrentDueGrid.DataBind();
                        CurrentObjection_Div.Visible = false;
                        CurrentDues_Div.Visible = true;
                    }
                    else
                    {
                        CurrentDueGrid.DataSource = null;
                        CurrentDueGrid.DataBind();

                        CurrentObjection_Div.Visible = true;
                        CurrentDues_Div.Visible = false;
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            lblObjID.Text         = Getdata5.Rows[0]["ID"].ToString();
                            txtclarification.Text = Getdata5.Rows[0]["Objection"].ToString();
                        }
                        else
                        {
                            txtclarification.Text = "";

                        }
                    }
                }
                else
                {
                    CurrentDueGrid.DataSource = null;
                    CurrentDueGrid.DataBind();

                    CurrentObjection_Div.Visible = true;
                    CurrentDues_Div.Visible = false;
                    txtclarification.Text = "";

                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void CurrentDueGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string val = CurrentDueGrid.DataKeys[rowIndex].Values[1].ToString();
            string AllotteeName = CurrentDueGrid.DataKeys[rowIndex].Values[2].ToString();
            string PhoneNo = CurrentDueGrid.DataKeys[rowIndex].Values[3].ToString();
            string EmailID = CurrentDueGrid.DataKeys[rowIndex].Values[4].ToString();

            if (e.CommandName == "PayAmount")
            {
                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();
                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(val, "UPSIDC");


                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                }
                else
                {
                    dsR = objServiceTimelinesBLL.GetDemandPayAmount(val);

                    if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                    if (dt_Fee.Rows.Count > 0)
                    {

                        try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(DueAmount)", string.Empty)); } catch { TotalCharges = 0; }

                        gm = new GeneralMethod();
                        string PaymentGetwayURL = gm.SendToPaymentGetwayHDFCNew(TotalCharges, TransactionId_UPSIDC, val.Trim(), "Demand", AllotteeName, EmailID, PhoneNo, "One");

                        if (PaymentGetwayURL == "Failed")
                        {
                            string Message = "Errro Ocured In Processing !";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        }
                        else
                        {
                          
                           // Response.Write($"<script>top.location='{PaymentGetwayURL}';parent.location='{PaymentGetwayURL}';</script>");
                            Response.Redirect(PaymentGetwayURL,true);
                        }
                    }
                }
            }
        }

        private void BindPreviousDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetPreviousDemandDuesIN '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata3 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata4 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata6 = ds.Tables[2]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    PreviousDuesGrid.DataSource = ds.Tables[0];
                    PreviousDuesGrid.DataBind();

                }
                else
                {
                    PreviousDuesGrid.DataSource = null;
                    PreviousDuesGrid.DataBind();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    GridView1.DataSource = Getdata6;
                    GridView1.DataBind();
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

        protected void PreviousDuesGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string IAID = PreviousDuesGrid.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata4.Select("DemandId = '" + IAID + "'");
                    DataTable dt1 = dr.CopyToDataTable();
                    GridView grdview = e.Row.FindControl("GridViewPreviousAmount") as GridView;
                    grdview.DataSource = dt1;
                    grdview.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void RegisterPostBackControl()
        {
         
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button1);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkView1);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkView2);
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
                    int maxFileSize = 3;
                    int fileSize = fileupload.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
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
                        Stream fs = fileupload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                    }
                }
                else
                {
                    objServiceTimelinesBEL.filename = String.Empty;
                    objServiceTimelinesBEL.content = String.Empty;
                    objServiceTimelinesBEL.Uploadfile = null;
                }
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                objServiceTimelinesBEL.ID = Convert.ToInt32(lblObjID.Text);

                objServiceTimelinesBEL.responseMessage = txtResponse.Text.Trim();
                retval = objServiceTimelinesBLL.SaveObjectionResponseIAServices(objServiceTimelinesBEL);
                if (retval > 0)
                {

                    if (SWCControlID.Length > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "14", "Applicant Re-Submitted the form after clearing objection to | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                    }
                    this.Page.GetType().InvokeMember("Redirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { ServiceReqNo });
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace + "");
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileupload1.HasFile)
                {
                    string filePath = fileupload1.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileupload1.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    int maxFileSize = 3;
                    int fileSize = fileupload1.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
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
                        Stream fs = fileupload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;



                    }
                }
                else
                {
                    objServiceTimelinesBEL.filename = String.Empty;
                    objServiceTimelinesBEL.content = String.Empty;
                    objServiceTimelinesBEL.Uploadfile = null;
                }
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                retval = objServiceTimelinesBLL.UploadObjectionDocOnly(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document Uploaded Succesfully !');", true);
                    return;
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
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

            Response.Write("<script>window.open ('ViewerObjectionInternalDoc.aspx?ID=" + lblObjID.Text.Trim() + "','_blank');</script>");

        }
    }
}