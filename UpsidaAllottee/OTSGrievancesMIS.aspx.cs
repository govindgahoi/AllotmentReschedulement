using BEL_Allotment;
using BLL_Allotment;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace UpsidaAllottee
{
    public partial class OTSGrievancesMIS : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string level = "";
        string IndustrialArea = "";
        #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (level == "Admin1" || level=="MD" || level=="JMD")
                {
                    dlRO.Enabled = true;
                }
                else
                {
                    dlRO.Enabled = false;
                }
            }
            catch
            {
                Response.Redirect("/loginpage.aspx");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/loginpage.aspx");
            }
            else
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                if (level == "RM")
                {
                    Grid_OTSscheme1.Visible = false;
                    GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());
                    GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
                    GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }
                else
                {
                    Grid_OTSscheme.Visible = false;
                    DlIA.Enabled = false;
                    TextBox1.Enabled = false;
                    bindRegionalOffice();
                    GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }

            }


        }
        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    //lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    //lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindRegionalOffice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }

        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dlRO.SelectedIndex == 0)
            {
                DlIA.SelectedIndex = 0;
                DlIA.Enabled = false;
                TextBox1.Enabled = false;

            }
            else
            {
                TextBox1.Text = "";
                TextBox1.Enabled = false;
                DlIA.Enabled = true;
                bindIndustrialArea(dlRO.SelectedItem.ToString());
            }
        }
        protected void bindIndustrialArea(string regionaloffice)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Indust_Area", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@regionalOffice", regionaloffice);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DlIA.DataSource = dt;
            DlIA.DataTextField = "IAName";
            DlIA.DataValueField = "IAName";
            DlIA.DataBind();
            System.Web.UI.WebControls.ListItem liIAName = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            DlIA.Items.Insert(0, liIAName);
        }

        private void GetIAAssociatedWithRM(string userName, string category)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("usp_GetIAAssociatedWithRM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", category);
                cmd.Parameters.AddWithValue("@userID", userName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                DlIA.DataSource = ds;
                DlIA.DataTextField = "IAName";
                DlIA.DataValueField = "IAName";
                DlIA.DataBind();
                System.Web.UI.WebControls.ListItem liIArea = new System.Web.UI.WebControls.ListItem("--Select All--", "-1");
                DlIA.Items.Insert(0, liIArea);
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
        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DlIA.SelectedIndex == 0)
            {
                TextBox1.Text = "";
                TextBox1.Enabled = false;
            }
            else
            {
                TextBox1.Text = "";
                TextBox1.Enabled = true;
            }
        }

        public void GetApplicationOfOTSscheme(string userName, string category)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetGrievanceDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", category);
                cmd.Parameters.AddWithValue("@userID", userName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_OTSscheme.DataSource = ds;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = ds;
                    Grid_OTSscheme1.DataBind();
                }
                else
                {
                    Grid_OTSscheme.DataSource = null;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = null;
                    Grid_OTSscheme1.DataBind();
                }
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

        protected void Grid_OTSscheme_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.Cells[6].Text == "true")
                //{
                //    e.Row.Cells[5].CssClass = "DaysRemaining";
                //}
                

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ComID = Grid_OTSscheme.DataKeys[e.Row.RowIndex].Values[0].ToString();
                lnkd.NavigateUrl = "~/OTSGrievances.aspx?ComplaintID=" + ComID + "";
            }
        }
        protected void Grid_OTSscheme1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ComID;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.Cells[6].Text == "true")
                //{
                //    e.Row.Cells[5].CssClass = "DaysRemaining";
                //}
                if ( e.Row.Cells[6].Text == "Resolved")
                {
                    e.Row.Cells[5].Text = "N/A";
                    e.Row.Cells[5].CssClass = "DaysRemaining";
                }

                HyperLink lnkd = e.Row.FindControl("hlnkView1") as HyperLink;
                //ComID = Grid_OTSscheme.DataKeys[e.Row.RowIndex].Values[0].ToString();
                ComID = Grid_OTSscheme1.DataKeys[e.Row.RowIndex].Values[0].ToString();
                lnkd.NavigateUrl = "~/OTSGrievances.aspx?ComplaintID=" + ComID + "";
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_OTSscheme.PageIndex = e.NewPageIndex;
            GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
        }
        protected void OnPageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            Grid_OTSscheme1.PageIndex = e.NewPageIndex;
            GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Download_Click(object sender, EventArgs e)
        {
            GetPdf();
        }
        public void GetPdf()
        {

            //Response.ContentType = "application/DOC";
            //Response.AddHeader("content-disposition", "attachment;filename=AtulRawat.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter s_w = new StringWriter();
            //HtmlTextWriter h_w = new HtmlTextWriter(s_w);

            //Grid_OTSscheme.RenderControl(h_w);
            //StringReader sr = new StringReader(s_w.ToString());
            //iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A2, 7f, 7f, 7f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
            //Grid_OTSscheme.AllowPaging = true;
            //Grid_OTSscheme.DataBind();

            //Grid_OTSscheme.HeaderRow.Style.Add("width", "15%");
            //Grid_OTSscheme.HeaderRow.Style.Add("font-size", "10px");
            //Grid_OTSscheme.Style.Add("text-decoration", "none");
            //Grid_OTSscheme.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            //Grid_OTSscheme.Style.Add("font-size", "8px");


        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public void GetListSearchByComplaintID(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetGrievanceDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);
                cmd.Parameters.AddWithValue("@ComID", TextBox2.Text.ToString().Trim());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_OTSscheme.DataSource = ds;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = ds;
                    Grid_OTSscheme1.DataBind();
                }
                else
                {
                    Grid_OTSscheme.DataSource = null;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = null;
                    Grid_OTSscheme1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetGrievanceDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);
                cmd.Parameters.AddWithValue("@PlotNo", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@IAName", DlIA.SelectedItem.ToString());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_OTSscheme.DataSource = ds;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = ds;
                    Grid_OTSscheme1.DataBind();

                }
                else
                {
                    Grid_OTSscheme.DataSource = null;
                    Grid_OTSscheme.DataBind();
                    Grid_OTSscheme1.DataSource = null;
                    Grid_OTSscheme1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void Grid_OTSschem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string com;
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    //com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);

                    DataTable dtDoc = ds.Tables[0];
                    string dc = dtDoc.Rows[0]["Document"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {

                        string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();
                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer2.ashx?ComplaintID=" + com + ""));

                    }

                }
                catch(Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }

            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);
                    DataTable dtDoc1 = ds.Tables[0];
                    string dc = dtDoc1.Rows[0]["Document"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {
                        download(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }
            }
        }
        protected void Grid_OTSschem1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string com;
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    //com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);

                    DataTable dtDoc = ds.Tables[0];
                    string dc = dtDoc.Rows[0]["Document"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {

                        string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();
                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer3.ashx?ComplaintID=" + com + ""));

                    }

                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }

            }
            if (e.CommandName == "ViewDocument1")
            {
                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    //com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);

                    DataTable dtDoc = ds.Tables[0];
                    string dc = dtDoc.Rows[0]["RMDoc"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {

                        string contype = dtDoc.Rows[0]["DocType"].ToString().Trim();
                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer3.ashx?ComplaintID=" + com + ""));

                    }

                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }

            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    //com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);
                    DataTable dtDoc1 = ds.Tables[0];
                    string dc = dtDoc1.Rows[0]["Document"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {
                        download(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }
            }
            if (e.CommandName == "selectDocument1")
            {

                DataSet ds = new DataSet();
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % Grid_OTSscheme.PageSize;
                    //com = Grid_OTSscheme.DataKeys[index].Values[0].ToString();
                    com = Grid_OTSscheme1.DataKeys[index].Values[0].ToString();
                    ds = ViewUploadedReport(com);
                    DataTable dtDoc1 = ds.Tables[0];
                    string dc = dtDoc1.Rows[0]["RMDoc"].ToString().Trim();
                    if (dc != "" || dc != null)
                    {
                        download1(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
                }
            }
        }

        protected void Grid_OTSschem_Sorting(object sender, GridViewSortEventArgs e)
        {
           
        }

        protected DataSet ViewUploadedReport(string cmp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("select Document, ContentType, AllotteeID,RMDoc,DocType,ComplaintID from tbl_OTSDetail where ComplaintID ='" + cmp + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Document not Uploaded');", true);
            }
            return ds;
        }
        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Document"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["AllotteeID"].ToString() + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void download1(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["RMDoc"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["DocType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["ComplaintID"].ToString() + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_OTSExportExcel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@role", Session["Type"].ToString()); 
                    cmd.Parameters.AddWithValue("@userID", UserName); 
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "DFView");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=OTSReport'"+ DateTime.Now.ToString("dd/MM/yyyy") + "'.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}