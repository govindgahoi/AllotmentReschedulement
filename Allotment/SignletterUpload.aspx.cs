using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class SignletterUpload : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        #endregion
        string UserName = string.Empty;
        int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;

            if (!IsPostBack)
            {
                RegisterPostBackControl();
                bindregion("");
                check_user_role();
            }
            if (!Page.IsPostBack)
            {
                binduploadletterGrid("", "");
            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(imgdocuments);
            scriptManager.RegisterPostBackControl(LinkButton1);
        }
        private void check_user_role()
        {

            binduploadletterGrid("", "");

        }
        private void gridFunc()
        {

            if (ddlIA.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand("GetIAUploadDocumentDetail_sp1 '" + ddlIA.SelectedValue.Trim() + "','S','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridPOA.DataSource = dt;
                gridPOA.DataBind();
            }
            else
            {
                binduploadletterGrid("", "");
            }

        }

        private void binduploadletterGrid(string IAId, string p)
        {
            SqlCommand cmd = new SqlCommand("GetIAUploadDocumentDetail_sp1 '" + IAId + "','" + p + "','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            gridPOA.DataSource = dt;
            gridPOA.DataBind();




        }
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            clear();
        }
        protected void ddlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            binduploadletterGrid(ddlIA.SelectedValue.Trim(), "S");
        }


        protected void drpServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpServiceName.SelectedValue == "1")
            {
                Approvalletter.Visible = true;
                map.Visible = true;
            }
            else
            {
                Approvalletter.Visible = true;
                map.Visible = false;
            }
        }
        protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpStatus.SelectedValue == "Approval")
            {
                Approvalletter.Visible = true;
                map.Visible = true;
            }
            else
            {
                Approvalletter.Visible = true;
                map.Visible = false;
            }
        }
        public void clear()
        {
            try
            {
                ddlregion.SelectedValue = "0";
                ddlIA.SelectedValue = "0";
                txtSerReqNo.Text = string.Empty;
                lbluploadingMsg.Text = string.Empty;
                lbluploadingMsgs.Text = string.Empty;
                drpServiceName.SelectedValue = "0";
                drpStatus.SelectedValue = "0";
                (Session["File"]) = "";
                Session["FileExt"] = "";
                Session["FileName"] = "";
                Session["POAFile"] = "";
                Session["POAFileName"] = "";
                Session["POAFileExt"] = "";
                btnSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlregion.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Regional Office");
                    return;
                }
                else if (ddlIA.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Industrial Area");
                    return;
                }
                else if (txtSerReqNo.Text == "" || txtSerReqNo.Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Service Request Number");
                    return;
                }
                else if (drpServiceName.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Service Name");
                    return;
                }
                else if (drpStatus.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Application Status");
                    return;
                }

                if (btnSubmit.Text == "Submit")
                {
                    //objServiceTimelinesBEL.POARegion = Convert.ToInt32(ddlregion.SelectedValue.Trim());
                    objServiceTimelinesBEL.POAIAID = Int32.Parse(ddlIA.SelectedValue.Trim());
                    objServiceTimelinesBEL.ServiceRequestNO = txtSerReqNo.Text.Trim();
                    objServiceTimelinesBEL.serviceID = drpServiceName.SelectedItem.Value.Trim();
                    objServiceTimelinesBEL.Doctype = drpStatus.SelectedItem.Value.Trim();
                    objServiceTimelinesBEL.POAPhoto = (Session["File"]) as byte[];
                    objServiceTimelinesBEL.POAPhotoContent = Convert.ToString(Session["FileExt"]);
                    objServiceTimelinesBEL.POAPhotoName = Convert.ToString(Session["FileName"]);
                    objServiceTimelinesBEL.POASign = (Session["POAFile"]) as byte[];
                    objServiceTimelinesBEL.POASignContent = Convert.ToString(Session["POAFileName"]);
                    objServiceTimelinesBEL.POASignName = Convert.ToString(Session["POAFileExt"]);
                    objServiceTimelinesBEL.UserName = System.Environment.MachineName;

                    DataSet result = objServiceTimelinesBLL.InsertletteruploadDetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        gridFunc();
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(RateIdlbl.Text);

                    objServiceTimelinesBEL.ID = ID;
                    objServiceTimelinesBEL.ServiceRequestNO = txtSerReqNo.Text.Trim();
                    objServiceTimelinesBEL.POAPhoto = (Session["File"]) as byte[];
                    objServiceTimelinesBEL.POAPhotoContent = Convert.ToString(Session["FileExt"]);
                    objServiceTimelinesBEL.POAPhotoName = Convert.ToString(Session["FileName"]);
                    objServiceTimelinesBEL.POASign = (Session["POAFile"]) as byte[];
                    objServiceTimelinesBEL.POASignContent = Convert.ToString(Session["POAFileExt"]);
                    objServiceTimelinesBEL.POASignName = Convert.ToString(Session["POAFileName"]);
                    objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                    DataSet result = objServiceTimelinesBLL.UpdateletteruploadDetails(objServiceTimelinesBEL);
                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        gridFunc();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void bindregion(string reg)
        {


            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlregion.DataSource = dt;
                ddlregion.DataTextField = "a";
                ddlregion.DataValueField = "b";
                ddlregion.DataBind();
                ddlregion.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlregion_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.RegionalOffice = (ddlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords1(objServiceTimelinesBEL);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "Id";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }


        }

        protected void imgdocuments_Click(object sender, EventArgs e)
        {

            if (POAPhotoUpload.HasFile)
            {
                // Read the file and convert it to Byte Array
                string filePath = POAPhotoUpload.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

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
                if (contenttype != String.Empty)
                {

                    Stream fs = POAPhotoUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                    objServiceTimelinesBEL.POAPhoto = bytes;
                    objServiceTimelinesBEL.POAPhotoContent = contenttype;
                    objServiceTimelinesBEL.POAPhotoName = filename;
                    Session["File"] = objServiceTimelinesBEL.POAPhoto;
                    Session["FileName"] = objServiceTimelinesBEL.POAPhotoName;
                    Session["FileExt"] = objServiceTimelinesBEL.POAPhotoContent;
                    lbluploadingMsg.Text = "File uploaded Successfully";
                    lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsg.Visible = true;


                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "File format not recognised." +
                      " Upload Image JPG formats";

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (POASignupload.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath1 = POASignupload.PostedFile.FileName;
                string filename1 = Path.GetFileName(filePath1);
                string ext = Path.GetExtension(filename1);
                string contenttype1 = String.Empty;

                //Set the contenttype based on File Extension
                switch (ext)
                {
                    case ".pdf":
                        contenttype1 = "application/pdf";
                        break;
                    case ".PDF":
                        contenttype1 = "application/pdf";
                        break;
                }
                if (contenttype1 != String.Empty)
                {

                    Stream fs = POASignupload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                    objServiceTimelinesBEL.POASign = bytes;
                    objServiceTimelinesBEL.POASignContent = contenttype1;
                    objServiceTimelinesBEL.POASignName = filename1;
                    Session["POAFile"] = objServiceTimelinesBEL.POASign;
                    Session["POAFileName"] = objServiceTimelinesBEL.POASignName;
                    Session["POAFileExt"] = objServiceTimelinesBEL.POASignContent;
                    lbluploadingMsgs.Text = "File uploaded Successfully";
                    lbluploadingMsgs.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsgs.Visible = true;


                }
                else
                {
                    lblStatus1.ForeColor = System.Drawing.Color.Red;
                    lblStatus1.Text = "File format not recognised." +
                      " Upload Image JPG formats";

                }
            }
        }

        private void get_UploadDocumentdetals(string id)
        {
            RateIdlbl.Text = "0";
            SqlCommand cmd = new SqlCommand("Select a.* from Repositoryforoldapplicant a where IAId='" + ddlIA.SelectedValue.Trim() + "' and id=" + id + "   and IsActive=1", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                RateIdlbl.Text = dt.Rows[0]["ID"].ToString();
                txtSerReqNo.Text = dt.Rows[0]["ServiceRequestNo"].ToString();
                drpServiceName.SelectedValue = dt.Rows[0]["ServiceId"].ToString().Trim();
                drpStatus.SelectedValue = dt.Rows[0]["ApplicationStatus"].ToString().Trim();

                if (drpServiceName.SelectedValue == "1")
                {
                    Approvalletter.Visible = true;
                    map.Visible = true;
                }
                else
                {
                    Approvalletter.Visible = true;
                    map.Visible = false;
                }
            }
            else
            {
                txtSerReqNo.Text = "";
                btnSubmit.Text = "Submit";
                RateIdlbl.Text = "0";
            }

        }
        protected void gridPOA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Process")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

                    string rowid = commandArgs[0];
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();
                    ddlregion.SelectedValue = regoffice;
                    ddlregion_SelectedIndexChanged(null, null);
                    ddlIA.SelectedValue = iaID.Trim();
                    get_UploadDocumentdetals(rowid);
                    btnSubmit.Text = "Update";

                }

                if (e.CommandName == "Viewletter")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

                    string rowid = commandArgs[0];
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ID = Convert.ToInt32(rowid);
                    ds = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];

                    if (dtDoc.Rows.Count > 0)
                    {

                        string contype = dtDoc.Rows[0]["SignedDocumentContent"].ToString().Trim();

                        string embed = @"<br/><object name='ViewerUploadDocument' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltviewer.Text = string.Format(embed, ResolveUrl("/ViewerUploadDocument.ashx?ID=" + Convert.ToInt32(rowid) + ""));
                    }
                }
                if (e.CommandName == "selectletter")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                    string rowid = commandArgs[0];
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();
                    DataSet ds = new DataSet();
                    try
                    {

                        objServiceTimelinesBEL.ID = Convert.ToInt32(rowid);
                        ds = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }
                if (e.CommandName == "ViewMap")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                    string rowid = commandArgs[0];
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ID = Convert.ToInt32(rowid);
                    ds = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];

                    if (dtDoc.Rows.Count > 0)
                    {

                        string contype = dtDoc.Rows[0]["SignedMapContent"].ToString().Trim();

                        string embed = @"<br/><object name='ViewerUploadMap' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltviewer.Text = string.Format(embed, ResolveUrl("/ViewerUploadMap.ashx?ID=" + Convert.ToInt32(rowid) + ""));
                    }
                }
                if (e.CommandName == "selectMap")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                    string rowid = commandArgs[0];
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ID = Convert.ToInt32(rowid);
                        ds = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            downloadApplicantDoc(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void download(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["SignedDocument"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["SignedDocumentContent"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["DocName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        private void downloadApplicantDoc(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["SignedMap"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["SignedMapContent"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["DocName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        protected void gridPOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPOA.PageIndex = e.NewPageIndex;
            gridFunc();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            binduploadletterGrid("", "");
        }

        protected void gvuploadletter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ID = Convert.ToInt32(((Label)e.Row.FindControl("DocumentID")).Text.ToString());
                    ds1 = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        if (dtDoc.Rows[0]["SignedDocumentContent"].ToString() == "" || dtDoc.Rows[0]["SignedDocumentContent"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                        }

                        if (dtDoc.Rows[0]["SignedMapContent"].ToString() == "" || dtDoc.Rows[0]["SignedMapContent"].ToString() == null)
                        {
                            e.Row.FindControl("lbViewMap").Visible = false;
                            e.Row.FindControl("lbViewMap1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbViewMap").Visible = true;
                            e.Row.FindControl("lbViewMap1").Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }


        }
    }
}