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
    public partial class UC_Service_Doc_Upload_View : System.Web.UI.UserControl
    {
        public string HiddenClassRM { get; private set; }
        public string HiddenClassAssistence { get; private set; }
        public string HiddenClassDraftMan { get; private set; }
        public string HiddenClassAssistenceManager { get; private set; }
        public string HiddenClassManager { get; private set; }

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion


        SqlConnection con;
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        public string SerReqID { get; set; }

        public string checklistid { get; set; }

        // "ENTRY", "VIEW"
        public string page_type { get; set; }


        public void Page_Load(object sender, EventArgs e)

        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            // if (string.IsNullOrEmpty(page_type)) { page_type = "VIEW"; } else { page_type = "ENTRY"; }

            view_type(page_type);

            //Page.ClientScript.GetPostBackEventReference(this, string.Empty);
            if (Request.Form["__EVENTTARGET"] == "GetServiceChecklists_SP_BY_Condtion_Function")
            {
                string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                GetServiceChecklists_SP_BY_Condtion_Function(passedArgument);
            }

            firstCondition = (string)ViewState["firstCondition"];
            BY_Condtion_Function = (string)ViewState["BY_Condtion_Function"];

            if (string.IsNullOrEmpty(BY_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
            else { BY_SET_Condtion_Function = BY_Condtion_Function; }

            if (checklistid == "" || checklistid == null)
            { view_asdf(SerReqID); }
            else { view_asdf1(checklistid); }

            this.RegisterPostBackControl();

        }

        private void view_type(string page_type)
        {

            if (page_type == "VIEW")
            {
                foreach (GridViewRow row in GridView2.Rows)
                {
                    (row.FindControl("lbView") as LinkButton).Enabled = false;
                    (row.FindControl("imgdocuments") as LinkButton).Enabled = false;
                    (row.FindControl("FileUpload4") as FileUpload).Enabled = false;

                }
            }
            else
            {
                foreach (GridViewRow row in GridView2.Rows)
                {
                    (row.FindControl("lbView") as LinkButton).Enabled = true;
                    (row.FindControl("imgdocuments") as LinkButton).Enabled = true;
                    (row.FindControl("FileUpload4") as FileUpload).Enabled = true;
                }
            }

        }




        private void RegisterPostBackControl()
        {

            foreach (GridViewRow row in GridView2.Rows)
            {
                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

                LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);

            }
        }



        protected void view_asdf(string serviceid)
        {

            //   checklisttabs.Text = "";


            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = SerReqID.Split('/');

                objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {
                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            htmldata += @"<a id='KK' class='font-bold' StaticSelectedStyle-CssClass='sub_menu_active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";
                        }

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit);
                        ViewState["firstCondition"] = firstCondition;
                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                        BindServiceCheckListGridView1(BY_SET_Condtion_Function);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
        }
        protected void view_asdf1(string ChecklistId)
        {

            //   checklisttabs.Text = "";
            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = SerReqID.Split('/');

                objServiceTimelinesBEL.ServiceChecklistId = ChecklistId;


                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {

                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            htmldata += @"<a id='KK' class='font-bold'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";



                        }

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit);



                        ViewState["firstCondition"] = firstCondition;

                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }

                        BindServiceCheckListGridView1(BY_SET_Condtion_Function);




                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
        }



        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)

        {

            hfName.Value = asdf;

            ViewState["BY_Condtion_Function"] = hfName.Value;
            BY_SET_Condtion_Function = hfName.Value;

            BindServiceCheckListGridView1(hfName.Value);
        }

       


        public void BindServiceCheckListGridView1(string condition)
        {


            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = SerReqID.Split('/');
                if (checklistid == "" || checklistid == null)
                { objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1]; }
                else { objServiceTimelinesBEL.ServiceTimeLines = (1000).ToString(); }

                objServiceTimelinesBEL.ServiceChecklistCondition = condition;
                objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();


                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetServiceChecklists1(objServiceTimelinesBEL);
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




        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindServiceCheckListGridView1(BY_SET_Condtion_Function);

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            ltEmbed.Text = "";
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string[] SerIdarray = SerReqID.Split('/');
                    string AllottementLetterNo = SerIdarray[2];
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;


                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();



                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;

                        e.Row.FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                        e.Row.FindControl("lbDelete").Visible = false;
                    }

                    if (page_type == "VIEW")
                    {
                        e.Row.Cells[5].Visible = false;
                    }

                }
            }
            catch
            {

            }
        }




        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            int CheckId = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);


                string[] SerIdarray = SerReqID.Split('/');
                if (checklistid == "" || checklistid == null)
                {
                    AllottementLetterNo = SerIdarray[2];
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Select AllotteeID from AllotteeApplicationRegister where ApplicationId='" + SerReqID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        AllottementLetterNo = dt.Rows[0]["AllotteeID"].ToString();
                    }

                }


                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();
                CheckId = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());





                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    // Response.Write(bts.Parent.Parent.GetType().ToString());
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                    int maxFileSize = 3;
                    //FileUpload fu = row.FindControl("FileUpload4") as FileUpload;//here 
                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {

                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                            case ".dwg":
                                contenttype = "dwg";
                                break;
                            case ".DWG":
                                contenttype = "dwg";
                                break;
                            case ".DXF":
                                contenttype = "DXF";
                                break;
                            case ".dxf":
                                contenttype = "dxf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {

                            if (CheckId == 9 || CheckId == 10 || CheckId == 1193 || CheckId == 1195 || CheckId == 1197 || CheckId == 1199 || CheckId == 1201 || CheckId == 1191)
                            {
                                if (contenttype == "DWG" || contenttype == "dwg")
                                {

                                }
                                else
                                {
                                    string message = "This document should be in dwg format only";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    return;
                                }
                            }
                            else
                            {
                                if (contenttype == "application/pdf" || contenttype == "application/PDF")
                                {

                                }
                                else
                                {
                                    string message = "This document should be in pdf format only";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    return;
                                }

                                int fileSize = fu.PostedFile.ContentLength;
                                if (fileSize > (maxFileSize * 1024 * 1024))
                                {
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                                    return;
                                }
                            }


                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID  = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename    = filename;
                            objServiceTimelinesBEL.content     = contenttype;
                            objServiceTimelinesBEL.Uploadfile  = bytes;
                            objServiceTimelinesBEL.CreatedBy   = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = SerReqID;
                            try
                            {
                                int retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string message = "File Uploaded SucessFully";
                                    string script  = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    BindServiceCheckListGridView1(BY_SET_Condtion_Function);
                                    this.RegisterPostBackControl();
                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
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
                        else
                        {
                            string message = "File format not recognised." +
                              " Upload PDF formats";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                    }
                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                        objServiceTimelinesBEL.DocumentID = DocumentID;
                        ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
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

                if (e.CommandName == "ViewDocument")
                {

                    // if (Service_Id == 9||Service_Id==10)
                    //  {
                    // Response.Write("<script>window.open ('Default1.aspx?ServiceReqNo=" + SerReqID.Trim() + "&ServiceId=" + Service_Id + "','_blank');</script>");
                    //    }

                    // else
                    //  {
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.DocumentID = DocumentID;

                    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];

                    if (dtDoc != null)
                    {

                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();


                        if (contype == "dwg")
                        {
                            Response.Write("<script>window.open ('http://eservices.onlineupsidc.com/Default1.aspx?ServiceReqNo=" + SerReqID.Trim() + "&ServiceId=" + Service_Id + "','_blank');</script>");
                        }
                        else
                        {

                            string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                        If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                        or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                        </object><br/>";

                            ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=" + SerReqID.Trim() + "&ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocId=" + DocumentID + ""));
                        }
                    }
                    //}
                }




                if (e.CommandName == "Delete")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID;

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "Checklist Document deleted successfully ";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                        else
                        {
                            string message = "Checklist Document couldn't be deleted";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                //    BindServiceCheckListGridView1(hfName.Value);
                try
                {

                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                    DataSet ds1 = new DataSet();


                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID;

                    objServiceTimelinesBEL.DocumentID = DocumentID;


                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];

                    //if (dtDoc.Rows.Count > 0)
                    //{
                    //    GridView2.Rows[index].FindControl("lbView").Visible = true;
                    //    GridView2.Rows[index].FindControl("lbView1").Visible = true;
                    //    GridView2.Rows[index].FindControl("lbDelete").Visible = true;
                    //}
                    //else
                    //{
                    //    GridView2.Rows[index].FindControl("lbView").Visible = false;
                    //    GridView2.Rows[index].FindControl("lbView1").Visible = true;
                    //    GridView2.Rows[index].FindControl("lbDelete").Visible = false;
                    //}
                }
                catch { }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }




        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







    }
}






