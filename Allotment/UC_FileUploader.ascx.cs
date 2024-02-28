using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_FileUploader : System.Web.UI.UserControl
    {

        SqlConnection con = new SqlConnection();

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        string UserName = "";


        public string CaseNo { get; set; }
        public string HearingDate { get; set; }



        public void Page_Load(object sender, EventArgs e)
        {


            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            if (!IsPostBack)
            {

            }

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (HttpPostedFile postedFile in FileUpload4.PostedFiles)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string contenttype = postedFile.ContentType;
                    if (txtReffrence.Text == "" || txtReffrence.Text == null)
                    {
                        MessageBox1.ShowInfo("Attachment Name Is Must"); return;
                    }
                    switch (filename)
                    {
                        case ".doc":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".docx":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".xls":
                            contenttype = "application/vnd.ms-excel";
                            break;
                        case ".xlsx":
                            contenttype = "application/vnd.ms-excel";
                            break;
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
                        using (Stream fs = postedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                objServiceTimelinesBEL.CaseID = CaseNo;
                                string date_to_be = DateTime.ParseExact(HearingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                                objServiceTimelinesBEL.DateOfExecutionAgreement = Convert.ToDateTime(date_to_be);
                                objServiceTimelinesBEL.ReferenceNumber = txtReffrence.Text.Trim();
                                objServiceTimelinesBEL.Remarks = txtdescription.Text.Trim();
                                objServiceTimelinesBEL.filename = filename;
                                objServiceTimelinesBEL.content = contenttype;
                                objServiceTimelinesBEL.Uploadfile = bytes;
                                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                                objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                                if (filename != String.Empty)

                                {
                                    int retVal = objServiceTimelinesBLL.SaveCaseDocument(objServiceTimelinesBEL);
                                    if (retVal > 0)
                                    {
                                        BindServiceCheckListGridView1();

                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    MessageBox1.ShowInfo("Please Select File"); return;
                                }

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        //protected void UploadFile_ServerClick(object sender, EventArgs e)
        //{
        //    Upload(null, null);
        //}

        public void BindServiceCheckListGridView1()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.CaseID = CaseNo;
                objServiceTimelinesBEL.ReferenceNumber = txtReffrence.Text.Trim();

                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetCaselistsDocument(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        GridView2.DataSource = ds;
                        GridView2.DataBind();

                    }
                    else
                    {

                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        //private void view_type(string page_type)
        //{

        //    if (page_type == "VIEW")
        //    {
        //        foreach (GridViewRow row in GridView2.Rows)
        //        {
        //            (row.FindControl("lbView") as LinkButton).Enabled = false;
        //            (row.FindControl("imgdocuments") as LinkButton).Enabled = false;
        //            (row.FindControl("FileUpload4") as FileUpload).Enabled = false;

        //        }
        //    }
        //    else
        //    {
        //        foreach (GridViewRow row in GridView2.Rows)
        //        {
        //            (row.FindControl("lbView") as LinkButton).Enabled = true;
        //            (row.FindControl("imgdocuments") as LinkButton).Enabled = true;
        //            (row.FindControl("FileUpload4") as FileUpload).Enabled = true;
        //        }
        //    }

        //}




        //private void RegisterPostBackControl()
        //{

        //    foreach (GridViewRow row in GridView2.Rows)
        //    {
        //        LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
        //        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

        //        LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
        //        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

        //        LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
        //        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);

        //    }
        //}



        //protected void view_asdf(string serviceid)
        //{

        //    string htmldata = "";
        //    try
        //    {

        //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        //        string[] SerIdarray = SerReqID.Split('/');

        //        objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];

        //        //  objServiceTimelinesBEL.ServiceChecklistCondition = serviceid;


        //        DataSet ds0 = new DataSet();
        //        try
        //        {
        //            ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
        //            if (ds0.Tables[0].Rows.Count > 0)
        //            {

        //                foreach (DataRow dr in ds0.Tables[0].Rows)
        //                {

        //                    firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
        //                    htmldata += @"<a id='KK' class='font-bold active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";

        //                    // htmldata += "<a href='javascript: void(0);' runat = 'server' onserverclick = 'GetServiceChecklists_SP_BY_Condtion_Function' class='font-bold active'>" + dr["ServiceTimeLinesCondition"].ToString() + "</a>";
        //                    // HtmlAnchor htm_anchor = new HtmlAnchor();
        //                    // htm_anchor.InnerText = dr["ServiceTimeLinesCondition"].ToString();
        //                    // htm_anchor.HRef = "#";
        //                    // htm_anchor.ID = "Anchor" + dr["ServiceTimeLinesCondition"].ToString();
        //                    // htm_anchor.Attributes.Add("runat", "sever");
        //                    // htm_anchor.Attributes.Add("class", "font-bold active");
        //                    // htm_anchor.Attributes.Add("onclick", "GetItemID('" + dr["ServiceTimeLinesCondition"].ToString() + "')");
        //                    // pnlDemo.ID = "pnl1";
        //                    // pnlDemo.Controls.Add(htm_anchor);

        //                }

        //                Literal loLit = new Literal();
        //                loLit.Text = (htmldata);
        //                pnlDemo.Controls.Add(loLit);



        //                ViewState["firstCondition"] = firstCondition;

        //                if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
        //                //  else{  }

        //                BindServiceCheckListGridView1(BY_SET_Condtion_Function);




        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //        }

        //    }
        //    catch { }
        //}





        //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView2.PageIndex = e.NewPageIndex;
        //    //this.BindServiceCheckListGridView1(BY_SET_Condtion_Function);

        //}

        //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}

        //protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}


        //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //    //ltEmbed.Text = "";
        //    //try
        //    //{
        //    //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    //    {

        //    //        LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
        //    //        string[] SerIdarray = SerReqID.Split('/');
        //    //        string AllottementLetterNo = SerIdarray[2];
        //    //        objServiceTimelinesBEL.UserName = AllottementLetterNo;


        //    //        int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
        //    //        int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
        //    //        string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();



        //    //        DataSet ds1 = new DataSet();
        //    //        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //    //        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //    //        objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();

        //    //        objServiceTimelinesBEL.DocumentID = DocumentID;



        //    //        ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
        //    //        DataTable dtDoc = ds1.Tables[0];
        //    //        if (dtDoc.Rows.Count > 0)
        //    //        {
        //    //            e.Row.FindControl("lbView").Visible = true;
        //    //            e.Row.FindControl("lbView1").Visible = true;

        //    //            e.Row.FindControl("lbDelete").Visible = true;
        //    //        }
        //    //        else
        //    //        {
        //    //            e.Row.FindControl("lbView").Visible = false;
        //    //            e.Row.FindControl("lbView1").Visible = false;
        //    //            e.Row.FindControl("lbDelete").Visible = false;
        //    //        }
        //    //    }
        //    //}
        //    //catch
        //    //{

        //    //}
        //}




        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
        //    string AllottementLetterNo = "";
        //    try
        //    {
        //        index = Convert.ToInt32(e.CommandArgument);
        //        objServiceTimelinesBEL.UserName = AllottementLetterNo;
        //        Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
        //        Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

        //        string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();

        //        if (e.CommandName == "selectDocument")
        //        {

        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                //objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
        //                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;


        //                objServiceTimelinesBEL.DocumentID = DocumentID;



        //                ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
        //                DataTable dtDoc1 = ds.Tables[0];

        //                if (dtDoc1.Rows.Count > 0)
        //                {
        //                    download(dtDoc1);
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //            }
        //        }

        //        //if (e.CommandName == "ViewDocument")
        //        //{
        //        //    DataSet ds = new DataSet();
        //        //    objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
        //        //    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //        //    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;

        //        //    objServiceTimelinesBEL.DocumentID = DocumentID;

        //        //    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

        //        //    DataTable dtDoc = ds.Tables[0];

        //        //    if (dtDoc != null)
        //        //    {

        //        //        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

        //        //        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
        //        //If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
        //        // or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
        //        //</object><br/>";

        //        //        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=" + SerReqID.Trim() + "&ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocId=" + DocumentID + ""));

        //        //    }

        //        //}

        //        //if (e.CommandName == "Delete")
        //        //{
        //        //    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //        //    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //        //    objServiceTimelinesBEL.ServiceRequestNO = SerReqID;

        //        //    objServiceTimelinesBEL.DocumentID = DocumentID;



        //        //    try
        //        //    {
        //        //        int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
        //        //        if (retVal > 0)
        //        //        {
        //        //            string message = "Checklist Document deleted successfully ";
        //        //            string script = "window.onload = function(){ alert('";
        //        //            script += message;
        //        //            script += "')};";
        //        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //        //        }
        //        //        else
        //        //        {
        //        //            string message = "Checklist Document couldn't be deleted";
        //        //            string script = "window.onload = function(){ alert('";
        //        //            script += message;
        //        //            script += "')};";
        //        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //        //        }
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        throw ex;
        //        //    }
        //        //}

        //        try
        //        {

        //            belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        //            DataSet ds1 = new DataSet();


        //            objServiceTimelinesBEL.UserName = AllottementLetterNo;

        //            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //            //objServiceTimelinesBEL.ServiceRequestNO = SerReqID;

        //            objServiceTimelinesBEL.DocumentID = DocumentID;


        //            ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
        //            DataTable dtDoc = ds1.Tables[0];

        //        }
        //        catch { }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //    }
        //}
        //private void download(DataTable dt)
        //{
        //    try
        //    {
        //        Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
        //        Response.Buffer = true;
        //        Response.Charset = "";
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.ContentType = dt.Rows[0]["contentType"].ToString();
        //        Response.AddHeader("content-disposition", "attachment;filename="
        //        + dt.Rows[0]["ColName"].ToString());
        //        Response.BinaryWrite(bytes);
        //        Response.Flush();
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}