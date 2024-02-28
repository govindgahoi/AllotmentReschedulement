
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Collections.Specialized;
using System.Text;
using System.Security.Cryptography;


namespace Allotment
{
    public partial class IAServicesApplication_PlotCancelation : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        string App;
        string TypeID;
        SqlConnection con;
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";

        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string checklistid { get; set; }
        GeneralMethod gm = new GeneralMethod();


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                string[] SerIdarray = ServiceReqNo.Split('/');
                TypeID = SerIdarray[1].ToString();

                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();

                PH_AllotteeDetails.Controls.Clear();
                //RegisterPostBackControl();
                UC_Service_Allotteee_Details_IA_Services UC_Service_Allotteee_Details_IA_Services = LoadControl("~/UC_Service_Allotteee_Details_IA_Services.ascx") as UC_Service_Allotteee_Details_IA_Services;
                UC_Service_Allotteee_Details_IA_Services.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Service_Allotteee_Details_IA_Services.AllotteeId = SerIdarray[2];
                PH_AllotteeDetails.Controls.Add(UC_Service_Allotteee_Details_IA_Services);
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
                { view_asdf(ServiceReqNo); }
                else { view_asdf1(checklistid); }

                if (!IsPostBack)
                {
                    if (TypeID == "1013")
                    {
                        lblFormName.Text = "Plot Cancelation ";
                    }
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;
                    }

                    if (TypeID == "1013")
                    {
                        Get_Notice_of_service();
                    }
                    GetApplicationDetails();
                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            // BindServiceCheckListGridViewDocument(hfName.Value);
            if (index == 0)
            {

            }
            if (index == 3)
            {
                GetDetails();
            }

            Allotment.ActiveViewIndex = index;
        }
        private void GetDetails()
        {

            try
            {
                string DocType = "";
                GeneralMethod gm = new GeneralMethod();
                string Status = gm.Get_Approval_Rejection_Status(ServiceReqNo);

                if (Status == "Completed")
                {
                    if (TypeID == "1013")
                    {
                        DocType = "plotcancelation";
                    }

                }
                else
                {
                    DocType = "Rejection";
                }

                SqlCommand cmd = new SqlCommand("GetSignedLetters '" + DocType + "','" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        protected void DocumentViewer(string ServiceRequestNo, string DocType, string type)
        {
            SqlCommand cmd = new SqlCommand();
            if (type == "Letter")
            {
                cmd = new SqlCommand(@"select Id , SignedDocumentContent , SignedDocument from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);

            }
            if (type == "Map")
            {
                cmd = new SqlCommand(@"select Id ,SignedMapContent 'SignedDocumentContent' , SignedMap 'SignedDocument' from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);

            }

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SignedDocument"].ToString().Length > 0)
                    {

                        byte[] Document = (byte[])dt.Rows[0]["SignedDocument"];
                        String base64EncodedPdf = System.Convert.ToBase64String(Document);
                        string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";


                        ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerIAService.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&DocType=" + DocType + "&ServiceID=" + TypeID + "")));

                    }
                }
            }
        }
        public void BindServiceCheckListGridViewDocument(string condition)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                string[] SerIdarray = ServiceReqNo.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1];
                objServiceTimelinesBEL.ServiceChecklistCondition = condition;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                if (App == "Resubmit")
                {
                    objServiceTimelinesBEL.Status = 0;
                }
                else
                {
                    objServiceTimelinesBEL.Status = 1;
                }

                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllServiceChecklistsIAServices(objServiceTimelinesBEL);
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
                    this.RegisterPostBackControl();
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
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //this.RegisterPostBackControl();
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView1.PageSize;
                string DocType = "";
                GeneralMethod gm = new GeneralMethod();
                string Status = gm.Get_Approval_Rejection_Status(ServiceReqNo);

                if (Status == "Completed")
                {
                    if (TypeID == "1013")
                    {
                        DocType = "PlotCancelation";
                    }
                }
                else
                {
                    DocType = "Rejection";
                }
                string SerReqNo = GridView1.DataKeys[index].Values[0].ToString();
                string Service = GridView1.DataKeys[index].Values[1].ToString();

                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        if (Service == "Letter")
                        {
                            cmd = new SqlCommand("select AllotmentLetterNo,SignedDocument 'Letter', SignedDocumentContent 'ContentType',DocType from Repository where ServiceRequestNo='" + ServiceReqNo + "' and DocType='" + DocType + "' ", con);
                        }
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download1(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {
                    DocumentViewer(ServiceReqNo, DocType, Service);

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string[] SerIdarray = ServiceReqNo.Split('/');
                    string AllottementLetterNo = SerIdarray[2];
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
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
                    LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

                    if (DocDisable.Text == "Lock")
                    {

                        e.Row.FindControl("lbDelete").Visible = false;
                        lnk2.Visible = false;

                    }
                }
            }
            catch
            {

            }
        }

        private void RegisterPostBackControl()
        {
            // ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSubmit);

            foreach (GridViewRow row in GridView2.Rows)
            {
                LinkButton imgdocuments = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(imgdocuments);

                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

                LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);
            }
        }

        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)

        {

            hfName.Value = asdf;

            ViewState["BY_Condtion_Function"] = hfName.Value;
            BY_SET_Condtion_Function = hfName.Value;

            BindServiceCheckListGridViewDocument(hfName.Value);
        }
        protected void view_asdf(string serviceid)
        {

            //   checklisttabs.Text = "";


            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = ServiceReqNo.Split('/');

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
                        hfName.Value = firstCondition;
                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                        BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
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


                string[] SerIdarray = ServiceReqNo.Split('/');

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

                        BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);




                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.RegisterPostBackControl();
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);


                string[] SerIdarray = ServiceReqNo.Split('/');

                AllottementLetterNo = SerIdarray[2];



                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();






                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        int fileSize = fu.PostedFile.ContentLength;
                        if (fileSize > (3 * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                            return;
                        }
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



                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);


                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();

                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            objServiceTimelinesBEL.UserName = AllottementLetterNo;
                            try
                            {
                                int retVal;

                                retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);


                                if (retVal > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Documents Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "PDF File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                                    BindServiceCheckListGridViewDocument(hfName.Value);

                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
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
                            string message = "Invalid File Format.Please Upload Only pdf/Jpeg/Jpg/Png files Only";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        string message = "Please Select file Then Upload";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }



                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;


                        objServiceTimelinesBEL.DocumentID = DocumentID;



                        ds = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
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
                    Response.Write("<script>window.open ('DocViewer.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&ServiceId=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocumentID=" + DocumentID + "','_blank');</script>");
                }

                if (e.CommandName == "Delete")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
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


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        private void download(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        private void View(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "inline;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
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

        private void DisableAllControl()
        {

        }

        private void GetApplicationDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsIAService '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                        lblindustrialid.Text = dt.Rows[0]["IAID"].ToString();
                        lblplotno.Text = dt.Rows[0]["PlotNo"].ToString();
                        lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                        lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                        lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                        lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                        lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                        lblAddress.Text = dt.Rows[0]["Address"].ToString();
                        lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                        lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                        string Payment = dt.Rows[0]["PaymentStatus"].ToString();
                        string Objection = dt.Rows[0]["Objection"].ToString();
                        string Rejected = dt.Rows[0]["Rejected"].ToString();
                        string Completed = dt.Rows[0]["Completed"].ToString();
                        string AutoApprovalRejected = dt.Rows[0]["AutoApprovalRejected"].ToString();
                        string AutoApprovalApproved = dt.Rows[0]["AutoApprovalApproved"].ToString();
                        string NMSWPFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
                        string Status = dt.Rows[0]["Status"].ToString();
                        if (Rejected == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Rejection Letter" });
                        }
                        if (Completed == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Approval Letter" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }

        private void download1(DataTable dt)
        {
            try
            {
                if (dt.Rows[0]["Letter"].ToString().Length > 0)
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType"].ToString();
                    Response.AddHeader("content-disposition", "attachment;filename="
                    + dt.Rows[0]["DocType"].ToString() + ".pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region codebymanish
        #region NewService
        private void downloadApplicantDoc(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["ApplicantDoc"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["ApplicantDocContent"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ApplicantDocName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        #region Plot Cancelation

        public void Get_Notice_of_service()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.Get_NoticeWithAllottee(ServiceReqNo);
                DataTable dt_timeextensionfee = dsR.Tables[0];
                DataTable dt_PriviousNotice = dsR.Tables[1];
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    divreply.Visible = true;
                    CKEditorControl_PlotCancelation.Text = dt_timeextensionfee.Rows[0]["NoticeReplyDetails"].ToString();
                    txtNoticeID.Text = dt_timeextensionfee.Rows[0]["NoticeID"].ToString();
                    txtServiceRequestNO.Text = dt_timeextensionfee.Rows[0]["ServiceRequestNo"].ToString();
                    // txtNoticeDescription.Text = dt_timeextensionfee.Rows[0]["AppointmentDesc"].ToString();
                    txtNoticeType.Text = dt_timeextensionfee.Rows[0]["Noticetype"].ToString();
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = dt_timeextensionfee.Rows[0]["NoticeID"].ToString();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();
                        string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                        Literal1.Text = string.Format(embed, ResolveUrl("/Viewer_Notice.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&NoticeId=" + txtNoticeID.Text.Trim() + ""));
                    }
                }
                else
                {
                    divreply.Visible = false;
                    divpendding.Visible = true;
                    DocDisable.Text = "Lock";
                    DisableAllControl();

                }
                if (dt_PriviousNotice.Rows.Count > 0)
                {
                    gvNotice.DataSource = dt_PriviousNotice;
                    gvNotice.DataBind();
                    NoticeDoc.Visible = true;

                }
                else
                {
                    NoticeDoc.Visible = false;
                    gvNotice.DataSource = null;
                    gvNotice.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }

        protected void gvNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = ((Label)e.Row.FindControl("lblNoticeID")).Text.ToString();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        if (dtDoc.Rows[0]["ApplicantDocName"].ToString() == "" || dtDoc.Rows[0]["ApplicantDocName"].ToString() == null)
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = false;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = true;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = true;
                        }

                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
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

        protected void gvNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            index = index % gvNotice.PageSize;
            string SerReqNo = gvNotice.DataKeys[index].Values[0].ToString();
            string NoticeID = gvNotice.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_Notice.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
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
            if (e.CommandName == "ViewDocumentApplicant")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["ApplicantDocContent"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_NoticeApplicantDoc.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocumentApplicant")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
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

        protected void BtnPlotCancelationInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (CKEditorControl_PlotCancelation.Text.Length <= 0)
                {
                    MessageBox1.ShowError("Please Enter Application Description");
                    return;
                }
                int retval = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                string str = CKEditorControl_PlotCancelation.Text.Trim();
                string str2 = Server.HtmlDecode(str);
                objServiceTimelinesBEL.ApplicationPlotCancelationDescription = str2;
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
                objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
                objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
                objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
                objServiceTimelinesBEL.NoticeID = txtNoticeID.Text;

                retval = objServiceTimelinesBLL.InsertPlotCancelationDetails(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    Session["File"] = "";
                    Session["FileExt"] = "";
                    Session["FileName"] = "";
                    lbluploadingMsg.Visible = false;
                    string message = "Applicant Plot Cancelation  Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    btnPlotCancelation.Enabled = false;
                    CKEditorControl_PlotCancelation.Enabled = false;
                    imgdocuments.Visible = true;
                    Get_Notice_of_service();
                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        private void GetPlotCancelationDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.PlotCancelationApplicantDetails(objServiceTimelinesBEL);

                DataTable dt_timeextensionfee = ds.Tables[0];
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    CKEditorControl_PlotCancelation.Text = dt_timeextensionfee.Rows[0]["description"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void imgdocuments_Click(object sender, EventArgs e)
        {
            try
            {
                //this.RegisterPostBackControl();
                int retval = 0;
                if (FileUpload4.HasFile)
                {
                    string filePath = FileUpload4.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUpload4.FileName.ToString());
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
                        Stream fs = FileUpload4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        Session["File"] = objServiceTimelinesBEL.Uploadfile;
                        Session["FileName"] = objServiceTimelinesBEL.filename;
                        Session["FileExt"] = objServiceTimelinesBEL.content;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
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

        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_NoticeStatusMaster] where ServiceRequestNo='" + ServiceReqNo + "'", con);
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
        #endregion



        #endregion


        #endregion

        #region NiveshMitra


        private void CheckNMSWPFeePaid()
        {

            SqlCommand cmd = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ControlID='" + SWCControlID.Trim() + "' and UnitID='" + SWCUnitID.Trim() + "' and ServiceID='" + SWCServiceID.Trim() + "' and RequestID='" + SWCRequest_ID + "' and isnull(Fee_Status,'') in ('Pending')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {


                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "11")
                {
                    string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                    string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                    if (Dt == "Success")
                    {
                        string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                        if (Result == "SUCCESS")
                        {

                        }
                        else
                        {

                        }
                    }



                }
            }
        }


        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            {


                string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
                string UnitID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
                string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
                string DeptID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
                NameValueCollection collections = new NameValueCollection();
                collections.Add("Dept_Code", DeptID.Trim());
                collections.Add("ControlID", ControlID.Trim());
                collections.Add("UnitID", UnitID.Trim());
                collections.Add("ServiceID", ServiceID.Trim());
                collections.Add("PassSalt", PassSalt.Trim());
                string remoteUrl = "http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Bck_page.aspx";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}