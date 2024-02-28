using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class ListOfNotices : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";



        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            this.RegisterPostBackControl();

            if (!IsPostBack)
            {
                BindGrid();
                UserSpecificBinding(UserName);
                BindServices();
            }
        }


        protected void UserSpecificBinding(string UserName)
        {

            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void BindServices()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetServicesForDropDown(objServiceTimelinesBEL);
                ddlService.DataSource = dsR.Tables[0];
                ddlService.DataTextField = "ServiceTimeLinesActivity";
                ddlService.DataValueField = "ServiceTimeLinesID";
                ddlService.DataBind();
                ddlService.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {

            try
            {
                lblNoticeId.Text = "";
                ddlService.SelectedIndex = 0;
                txtNoticeDescription.Text = "";
                txtNoticeIssueDate.Text = "";
                txtNoticeRefNo.Text = "";
                bindDDLRegion(ddloffice.SelectedItem.Value, null);
            }
            catch { }



        }


        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblNoticeId.Text = "";
            ddlService.SelectedIndex = 0;
            txtNoticeDescription.Text = "";
            txtNoticeIssueDate.Text = "";
            txtNoticeRefNo.Text = "";

            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForNotices(objServiceTimelinesBEL);
                ddlPlotNo.DataSource = ds;
                ddlPlotNo.DataTextField = "PlotNumber";
                ddlPlotNo.DataValueField = "PlotNumber";
                ddlPlotNo.DataBind();
                ddlPlotNo.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
            objServiceTimelinesBEL.IAName = (drpdwnIA.SelectedItem.Text.Trim());
            DataSet ds = new DataSet();
            try
            {

                lblNoticeId.Text = "";
                ddlService.SelectedIndex = 0;
                txtNoticeDescription.Text = "";
                txtNoticeIssueDate.Text = "";
                txtNoticeRefNo.Text = "";
                ds = objServiceTimelinesBLL.GetAllotteeAgainstPlot(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        txtAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                        lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    }
                    else
                    {
                        txtAllotteeName.Text = "";
                        lblAllotteeID.Text = "";
                    }
                }

                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddloffice.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Regional Office");
                    return;
                }
                if (drpdwnIA.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Industrial Area");
                    return;
                }
                if (ddlPlotNo.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Plot No");
                    return;
                }
                if (ddlService.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Notice For");
                    return;
                }
                if (txtNoticeRefNo.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Please Enter Notice Ref No");
                    return;
                }
                if (txtNoticeIssueDate.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Please Enter Notice Issue Date");
                    return;
                }
                if (txtNoticeIssueDate.Text == "" || txtNoticeIssueDate.Text == null)
                { MessageBox1.ShowInfo("Please Enter Notice Issue Date"); return; }
                else
                {
                    if (ValidateDate(txtNoticeIssueDate.Text))
                    {

                    }
                    else
                    {
                        txtNoticeIssueDate.Focus();
                        MessageBox1.ShowError("Invalid Notice Issue Date");
                        return;
                    }
                }
                string NoticeIssueDate = DateTime.ParseExact(txtNoticeIssueDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                int retval = 0;
                objServiceTimelinesBEL.PlotNo = ddlPlotNo.SelectedValue.Trim();

                objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
                objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.ServiceId = ddlService.SelectedValue.Trim();
                objServiceTimelinesBEL.NoticeRefNo = txtNoticeRefNo.Text.Trim();
                objServiceTimelinesBEL.NoticeDate = Convert.ToDateTime(NoticeIssueDate);
                objServiceTimelinesBEL.NoticeDescription = txtNoticeDescription.Text.Trim();


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


                        objServiceTimelinesBEL.NoticeContent = bytes;
                        objServiceTimelinesBEL.NoticeName = filename.Trim();
                        objServiceTimelinesBEL.NoticeExtn = contenttype.Trim();
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }


                    objServiceTimelinesBEL.CreatedBy = UserName.Trim();


                    retval = objServiceTimelinesBLL.InsertNoticesServed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Notice Saved Successfully");
                        lblNoticeId.Text = "";
                        ddlService.SelectedIndex = 0;
                        txtNoticeDescription.Text = "";
                        txtNoticeIssueDate.Text = "";
                        txtNoticeRefNo.Text = "";

                        BindGrid();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Saving Notice");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(SaveEntry);


        }


        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            if (lblNoticeId.Text.Length > 0)
            {
                btnUpdate_Click(null, null);
            }
            else
            {
                btnSubmit_Click(null, null);
            }
        }

        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }
            catch
            {
                return false;
            }
        }
        private void BindGrid()
        {

            objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfNotices(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        NoticeGrid.DataSource = dt;
                        NoticeGrid.DataBind();
                    }
                    else
                    {
                        NoticeGrid.DataSource = null;
                        NoticeGrid.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void NoticeGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {



                int index = Convert.ToInt32(e.CommandArgument);
                index = index % NoticeGrid.PageSize;
                string NoticeID = (NoticeGrid.DataKeys[index].Values[0]).ToString();
                string ServiceID = (NoticeGrid.DataKeys[index].Values[1]).ToString();
                string NoticeRefNo = (NoticeGrid.DataKeys[index].Values[2]).ToString();
                string IssueDate = (NoticeGrid.DataKeys[index].Values[3]).ToString();
                string description = (NoticeGrid.DataKeys[index].Values[4]).ToString();

                if (e.CommandName == "Process")
                {
                    txtNoticeDescription.Text = description;
                    txtNoticeRefNo.Text = NoticeRefNo;
                    txtNoticeIssueDate.Text = IssueDate;
                    ddlService.SelectedValue = ServiceID.Trim();
                    lblNoticeId.Text = NoticeID.Trim();




                }
                if (e.CommandName == "View")
                {
                    String js = "window.open ('DocViewerNotices.aspx?NoticeID=" + NoticeID.Trim() + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Open DocViewerNotices.aspx", js, true);
                }
                if (e.CommandName == "DeleteNotice")
                {
                    int retval = 0;
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();


                    retval = objServiceTimelinesBLL.DeleteNoticeServed(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Notice Deleted Successfully");
                        BindGrid();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Deleting Notice");
                        return;
                    }


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }

        }

        protected void NoticeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            NoticeGrid.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {

                if (ddloffice.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Regional Office");
                    return;
                }
                if (drpdwnIA.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Industrial Area");
                    return;
                }
                if (ddlService.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Notice For");
                    return;
                }

                if (ddlPlotNo.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Plot No");
                    return;
                }
                if (txtNoticeRefNo.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Please Enter Notice Ref No");
                    return;
                }
                if (txtNoticeIssueDate.Text.Length <= 0)
                {
                    MessageBox1.ShowWarning("Please Enter Notice Issue Date");
                    return;
                }


                int retval = 0;
                objServiceTimelinesBEL.NoticeID = lblNoticeId.Text.Trim();
                objServiceTimelinesBEL.ServiceId = ddlService.SelectedValue.Trim();
                objServiceTimelinesBEL.NoticeRefNo = txtNoticeRefNo.Text.Trim();
                objServiceTimelinesBEL.NoticeDate = Convert.ToDateTime(txtNoticeIssueDate.Text.Trim());
                objServiceTimelinesBEL.NoticeDescription = txtNoticeDescription.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = UserName.Trim();

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


                        objServiceTimelinesBEL.NoticeContent = bytes;
                        objServiceTimelinesBEL.NoticeName = filename.Trim();
                        objServiceTimelinesBEL.NoticeExtn = contenttype.Trim();
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }


                    objServiceTimelinesBEL.CreatedBy = UserName.Trim();


                    retval = objServiceTimelinesBLL.UpdateNoticServedWithFile(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Notice Updated Successfully");
                        lblNoticeId.Text = "";
                        ddlService.SelectedIndex = 0;
                        txtNoticeDescription.Text = "";
                        txtNoticeIssueDate.Text = "";
                        txtNoticeRefNo.Text = "";

                        BindGrid();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Updating Notice");
                        return;
                    }
                }
                else
                {


                    retval = objServiceTimelinesBLL.UpdateNoticServedWithoutFile(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Notice Updated Successfully");
                        lblNoticeId.Text = "";
                        ddlService.SelectedIndex = 0;
                        txtNoticeDescription.Text = "";
                        txtNoticeIssueDate.Text = "";
                        txtNoticeRefNo.Text = "";

                        BindGrid();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Updating Notice");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void refresh_ServerClick(object sender, EventArgs e)
        {
            ddloffice.SelectedIndex = 0;
            Regional_Changed(null, null);
            ddlPlotNo.SelectedIndex = -1;
            txtAllotteeName.Text = "";
            lblNoticeId.Text = "";
            lblAllotteeID.Text = "";
            BindGrid();

        }
    }
}







