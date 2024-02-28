using System;
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
    public partial class UC_Service_Doc_Upload_View1 : System.Web.UI.UserControl
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


        public void Page_Load(object sender, EventArgs e)
        {


            Page.ClientScript.GetPostBackEventReference(this, string.Empty);
            //This is important to make  the "__doPostBack()" method, works properly

            if (Request.Form["__EVENTTARGET"] == "GetServiceChecklists_SP_BY_Condtion_Function")
            {
                string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                GetServiceChecklists_SP_BY_Condtion_Function(passedArgument);

                //call the method 

                // GetServiceChecklists_SP_BY_Condtion_Function(this, new EventArgs());
            }


            firstCondition = (string)ViewState["firstCondition"];
            BY_Condtion_Function = (string)ViewState["BY_Condtion_Function"];


            if (string.IsNullOrEmpty(BY_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
            else { BY_SET_Condtion_Function = BY_Condtion_Function; }


            view_asdf(SerReqID);
            this.RegisterPostBackControl();

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

                //  objServiceTimelinesBEL.ServiceChecklistCondition = serviceid;


                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {

                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            htmldata += @"<a id='KK' class='font-bold active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";

                            // htmldata += "<a href='javascript: void(0);' runat = 'server' onserverclick = 'GetServiceChecklists_SP_BY_Condtion_Function' class='font-bold active'>" + dr["ServiceTimeLinesCondition"].ToString() + "</a>";
                            // HtmlAnchor htm_anchor = new HtmlAnchor();
                            // htm_anchor.InnerText = dr["ServiceTimeLinesCondition"].ToString();
                            // htm_anchor.HRef = "#";
                            // htm_anchor.ID = "Anchor" + dr["ServiceTimeLinesCondition"].ToString();
                            // htm_anchor.Attributes.Add("runat", "sever");
                            // htm_anchor.Attributes.Add("class", "font-bold active");
                            // htm_anchor.Attributes.Add("onclick", "GetItemID('" + dr["ServiceTimeLinesCondition"].ToString() + "')");
                            // pnlDemo.ID = "pnl1";
                            // pnlDemo.Controls.Add(htm_anchor);

                        }

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit);



                        ViewState["firstCondition"] = firstCondition;

                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                        //  else{  }

                        BindServiceCheckListGridView1(BY_SET_Condtion_Function);




                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
            catch { }
        }




        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)
        //  public void GetServiceChecklists_SP_BY_Condtion_Function(object sender, EventArgs e)
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
                objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
                objServiceTimelinesBEL.ServiceChecklistCondition = condition;


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
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                    string AllottementLetterNo = _objLoginInfo.userName;
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());


                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
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
                }
            }
            catch
            {

            }

        }




        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                //       GridViewRow row = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                string[] SerIdarray = SerReqID.Split('/');
                //AllottementLetterNo = _objLoginInfo.userName;
                AllottementLetterNo = SerIdarray[2];
                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());



                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    // Response.Write(bts.Parent.Parent.GetType().ToString());
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 


                    //FileUpload fu = row.FindControl("FileUpload4") as FileUpload;//here 
                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
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
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                            case ".JPG":
                                contenttype = "image/jpg";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            try
                            {
                                //  if (btnSubmit.Text == "Save")
                                //  {
                                int retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }
                                //  }
                            }
                            catch (Exception ex)
                            {
                                //   Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                              " Upload Image/Word/PDF/Excel formats";
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
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                        ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        //      Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqID.Trim();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];

                    if (dtDoc != null)
                    {

                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""600px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqID.Trim() + "&ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + ""));

                    }

                }




                if (e.CommandName == "Delete")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
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
                        //     throw ex;
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
                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        GridView2.Rows[index].FindControl("lbView").Visible = true;
                        GridView2.Rows[index].FindControl("lbView1").Visible = true;
                        GridView2.Rows[index].FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        GridView2.Rows[index].FindControl("lbView").Visible = false;
                        GridView2.Rows[index].FindControl("lbView1").Visible = true;
                        GridView2.Rows[index].FindControl("lbDelete").Visible = false;
                    }
                }
                catch { }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                //    throw ex;
            }
        }







    }
}






