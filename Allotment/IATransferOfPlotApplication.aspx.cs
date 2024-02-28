
using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Allotment
{
    public partial class IATransferOfPlotApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        string ServiceReqNo;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;
        string TypeID;
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string checklistid { get; set; }

        SqlConnection con;

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
                SWCControlID    = NMSWP.Rows[0][0].ToString();
                SWCUnitID       = NMSWP.Rows[0][1].ToString();
                SWCServiceID    = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID   = NMSWP.Rows[0][3].ToString();
              
                PH_AllotteeDetails.Controls.Clear();
               
                if (SWCControlID.Length > 0)
                {
                    CheckNMSWPFeePaid();
                }

                RegisterPostBackControl();
                UC_Service_Allotteee_Details_IA_Services UC_Service_Allotteee_Details_IA_Services = LoadControl("~/UC_Service_Allotteee_Details_IA_Services.ascx") as UC_Service_Allotteee_Details_IA_Services;
                UC_Service_Allotteee_Details_IA_Services.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Service_Allotteee_Details_IA_Services.AllotteeId = SerIdarray[2];
                PH_AllotteeDetails.Controls.Add(UC_Service_Allotteee_Details_IA_Services);
               
                if (!IsPostBack)
                {

                    DataTable temp_shareholder_details = new DataTable();
                    temp_shareholder_details.TableName = "temp_shareholder_details";
                    temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_shareholder_details"] = temp_shareholder_details;
                    temp_shareholder_details_DataBind();


                    DataTable temp_trustee_details = new DataTable();
                    temp_trustee_details.TableName = "temp_trustee_details";
                    temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_trustee_details"] = temp_trustee_details;
                    temp_trustee_details_DataBind();


                    DataTable temp_directors_details = new DataTable();
                    temp_directors_details.TableName = "temp_directors_details";
                    temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_directors_details"] = temp_directors_details;
                    temp_director_details_DataBind();


                    DataTable temp_partnership_details = new DataTable();
                    temp_partnership_details.TableName = "temp_partnership_details";
                    temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                    temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_partnership_details"] = temp_partnership_details;
                    temp_partnership_details_DataBind();
                    if (TypeID=="4")
                    {
                        lblFormName.Text = "Application For Transfer of Plot";
                    }
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;
                    }
                   

                  
                    GetApplicationDetails();
                    
                    BindTransferarDocument();
                    BindTransfreeDocument();
                    BindTransferApplicableCase();
                    CheckAck();
                    bindCompanytypeddl();
                    bindPriorityDdl();
                    bindTypeOfIndustry();
                    bindIACategory();
                    GetApplicantDetails(ServiceReqNo);
                    
                }
                BindObjection();
                if (SWCControlID.Length > 0)
                {
                    btn_Submit.Visible = true;
                    btnPay.Visible = false;
                }
                else
                {
                    btn_Submit.Visible = false;
                    btnPay.Visible = true;
                }
               
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }

        }
       
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
      
            if (index == 0)
            {

            }
            if (index == 7)
            {
                BindTransfreeDocument();
            }
            if (index == 9)
            {
                GetPaymentDetails();
            }
            if(index==10)
            {
                GetFinalView();
            }

            if (index == 12)
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
                    if (TypeID == "1003")
                    {
                        DocType = "ChangeOfProject";
                    }
                    if (TypeID == "1004")
                    {
                        DocType = "AdditionOfProduct";
                    }
                    if (TypeID == "1009")
                    {
                        DocType = "CompletionCertificate";
                    }
                    if (TypeID == "1010")
                    {
                        DocType = "OccupancyCertificate";
                    }
                    if (TypeID == "1023")
                    {
                        DocType = "NoDues";
                    }
                    if (TypeID == "1027")
                    {
                        DocType = "OutstandingDues";
                    }
                    if (TypeID == "4")
                    {
                        DocType = "Transfer";
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
                if (dt.Rows.Count > 0)
                {
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    this.RegisterPostBackControl();
                }
                else
                {

                    GridView3.DataSource = dt;
                    GridView3.DataBind();

                }


            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveImage);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveSign);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_TransferarPhoto);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_TransferarSign);

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
            foreach (GridViewRow row in GridView1.Rows)
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
            foreach (GridViewRow row in GridView3.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("lbView13") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);
            }
        }
        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
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

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView3.PageSize;
                string DocType = "";
                GeneralMethod gm = new GeneralMethod();
                string Status = gm.Get_Approval_Rejection_Status(ServiceReqNo);

                if (Status == "Completed")
                {
                    if (TypeID == "1003")
                    {
                        DocType = "ChangeOfProject";
                    }
                    if (TypeID == "1004")
                    {
                        DocType = "AdditionOfProduct";
                    }
                    if (TypeID == "1009")
                    {
                        DocType = "CompletionCertificate";
                    }
                    if (TypeID == "1010")
                    {
                        DocType = "OccupancyCertificate";
                    }
                    if (TypeID == "1023")
                    {
                        DocType = "NoDues";
                    }
                    if (TypeID == "1027")
                    {
                        DocType = "OustandingDues";
                    }
                    if (TypeID == "4")
                    {
                        DocType = "Transfer";
                    }
                }
                else
                {
                    DocType = "Rejection";
                }
                string SerReqNo = GridView3.DataKeys[index].Values[0].ToString();
                string Service = GridView3.DataKeys[index].Values[1].ToString();

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
                        if (Service == "Map")
                        {
                            cmd = new SqlCommand("select AllotmentLetterNo,SignedMap 'Letter',SignedMapContent 'ContentType',DocType from Repository where ServiceRequestNo='" + ServiceReqNo + "'and DocType='" + DocType + "' ", con);
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
        #region "Transferar Document Code"
        private void BindTransferApplicableCase()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTransferApplicableCase();
                drp_TransferApplicableCase.DataSource = ds;
                drp_TransferApplicableCase.DataTextField = "TransferLevyCaseType";
                drp_TransferApplicableCase.DataValueField = "ID";
                drp_TransferApplicableCase.DataBind();
                drp_TransferApplicableCase.Items.Insert(0, new ListItem("--Select--", "0"));
                
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        public void BindTransferarDocument()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray                     = ServiceReqNo.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1];
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetTransferarDocuments(objServiceTimelinesBEL);
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
                    Response.Write("Oops! error occured in (BindTransferarDocument) :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured in (BindTransferarDocument) :" + ex.Message.ToString());
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



                    ds1 = objServiceTimelinesBLL.GetTransferarDocumentsView(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;
}
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                       
                    }

                    LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

                    if (DocDisable.Text == "Lock")
                    {

                        
                        lnk2.Visible = false;

                    }

                }
            }
            catch(Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
                        int maxFileSize = 3;
                        int fileSize = fu.PostedFile.ContentLength;
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



                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);


                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();

                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID  = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename            = filename;
                            objServiceTimelinesBEL.content             = contenttype;
                            objServiceTimelinesBEL.Uploadfile          = bytes;
                            objServiceTimelinesBEL.CreatedBy           = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate         = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO    = ServiceReqNo;
                            try
                            {
                                int retVal;

                                retVal = objServiceTimelinesBLL.SaveTransferarChecklistDocument(objServiceTimelinesBEL);
                                

                                if (retVal > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transferar document uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                                    
                                    BindTransferarDocument();

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
                            string message = "Invalid File Format.Please Upload Only pdf files Only";
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



                        ds = objServiceTimelinesBLL.GetTempCheckListDocument(objServiceTimelinesBEL);
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

        #endregion

        #region "Transfree Document Code"

        public void BindTransfreeDocument()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = ServiceReqNo.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = (1000).ToString();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetTransfreeDocuments(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                    this.RegisterPostBackControl();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured in (BindTransfreeDocument) :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured in (BindTransfreeDocument) :" + ex.Message.ToString());
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    objServiceTimelinesBEL.ServiceTimeLinesID = 1000;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetTransferarDocumentsView(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;

                    }

                    LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

                    if (DocDisable.Text == "Lock")
                    {


                        lnk2.Visible = false;

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);


                string[] SerIdarray = ServiceReqNo.Split('/');

                AllottementLetterNo = SerIdarray[2];

                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView1.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView1.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());
                string DocumentID = ((Label)GridView1.Rows[index].FindControl("DocumentID")).Text.ToString();

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
                        int maxFileSize = 3;
                        int fileSize = fu.PostedFile.ContentLength;
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



                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);


                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();

                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = 1000;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            try
                            {
                                int retVal;
                                retVal = objServiceTimelinesBLL.SaveTransferarChecklistDocument(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Document uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    BindTransfreeDocument();

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
                            string message = "Invalid File Format.Please Upload Only pdf files Only";
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



                        ds = objServiceTimelinesBLL.GetTempCheckListDocument(objServiceTimelinesBEL);
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


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

        #endregion

        #region "Transfree Basic Details Bind"
        private void bindPriorityDdl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPriorityCategory();
                ddlPriority.DataSource = ds;
                ddlPriority.DataTextField = "Category";
                ddlPriority.DataValueField = "Category";
                ddlPriority.DataBind();
                ddlPriority.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void bindTypeOfIndustry()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTypeoFIndustry();
                ddlTypeOfIndustry.DataSource = ds;
                ddlTypeOfIndustry.DataTextField = "IndustrialClassificationName";
                ddlTypeOfIndustry.DataValueField = "ClassificationID";
                ddlTypeOfIndustry.DataBind();
                ddlTypeOfIndustry.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void bindIACategory()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIACategory();
                drpIACategory.DataSource = ds;
                drpIACategory.DataTextField = "PollutionCategory";
                drpIACategory.DataValueField = "ID";
                drpIACategory.DataBind();
                drpIACategory.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        protected void chkfumes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfumes.Checked == true)
            {
                fumesdiv.Visible = true;
            }
            else
            {
                txtfumeqty.Text = "";
                txtfumenature.Text = "";
                fumesdiv.Visible = false;
            }


        }
        private void bindCompanytypeddl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompanyType();
                ddlcompanytype.DataSource = ds;
                ddlcompanytype.DataTextField = "company_type";
                ddlcompanytype.DataValueField = "id";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
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
        private void GetApplicantDetails(String ID)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetTransfreeBasicDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_Transferar_Photo = ds.Tables[4];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID      = dt.Rows[0]["ApplicantId"].ToString();            
                    LblAllotteeId.Text     = dt.Rows[0]["ApplicantId"].ToString();
                    LblAllotteeIdMain.Text = dt.Rows[0]["MainID"].ToString();
                    lblAllotteeName.Text   = dt.Rows[0]["ApplicantName"].ToString();
                    string Objection       = dt.Rows[0]["Objection"].ToString();

                    //if(Objection=="True")
                    if ("True" == "True")
                    {
                        Allotment.ActiveViewIndex = 11;
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }
                    else
                    {
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Value == "11")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }


                   

                    if (dt.Rows[0]["FirmConstitution"].ToString() == "" || dt.Rows[0]["FirmConstitution"].ToString() == null)
                    {
                        ddlcompanytype.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcompanytype.SelectedValue = dt.Rows[0]["FirmConstitution"].ToString().Trim();
                    }
                    lblRegionalOffice.Text = dt.Rows[0]["District"].ToString().Trim();
                    lblIAID.Text           = dt.Rows[0]["IndustrialArea"].ToString().Trim();
                    lblIndustrialArea.Text = dt.Rows[0]["IndustrialAreaName"].ToString().Trim();
                    lblIAName.Text         = dt.Rows[0]["IndustrialAreaName"].ToString().Trim();
                    lblRefNo.Text          = dt.Rows[0]["ApplicationId"].ToString().Trim();
                    lblRequiredArea.Text   = dt.Rows[0]["PlotSize"].ToString().Trim();
                    txtCompanyname.Text    = dt.Rows[0]["CompanyName"].ToString().Trim();                   
                    txtPanNo.Text          = dt.Rows[0]["PanNo"].ToString().Trim();
                    lblFormNo.Text         = dt.Rows[0]["FormNo"].ToString().Trim();
                    txtCinNo.Text          = dt.Rows[0]["CinNo"].ToString().Trim();
                    txtGSTNo.Text          = dt.Rows[0]["GSTNo"].ToString().Trim();
                    lblChosePlot.Text      = dt.Rows[0]["PlotNo"].ToString().Trim();
                    txtPayeeName.Text      = dt.Rows[0]["CompanyName"].ToString().Trim();
                    txtPayeeBank.Text      = dt.Rows[0]["BankName"].ToString().Trim();
                    txtaccntNo.Text        = dt.Rows[0]["AccountNumber"].ToString().Trim();
                    txtConfirmAccNo.Text   = dt.Rows[0]["AccountNumber"].ToString().Trim();
                    txtIFSCCode.Text       = dt.Rows[0]["IFSCCode"].ToString().Trim();
                    txtBranchName.Text     = dt.Rows[0]["BranchName"].ToString().Trim();
                    txtBranchAddress.Text  = dt.Rows[0]["BranchAddress"].ToString().Trim();
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {

                        tr2.Visible = true;
                        ViewState["temp_shareholder_details"] = dt1;
                        temp_shareholder_details_DataBind();
                    }
                    else
                    {
                        tr2.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {

                        tr9.Visible = true;
                        ViewState["temp_partnership_details"] = dt1;
                        temp_partnership_details_DataBind();
                    }
                    else
                    {
                        tr9.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {

                        tr4.Visible = true;
                        ViewState["temp_trustee_details"] = dt1;
                        temp_trustee_details_DataBind();
                    }
                    else
                    {
                        tr4.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {

                        tr8.Visible = true;

                        ViewState["temp_directors_details"] = dt1;
                        temp_director_details_DataBind();
                    }
                    else
                    {
                        tr8.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        tr5.Visible = true;
                        tr6.Visible = true;
                        tr7.Visible = false;

                        txtIndividualName.Text    = dt.Rows[0]["ApplicantName"].ToString().Trim();
                        txtPayeeName.Text         = dt.Rows[0]["ApplicantName"].ToString().Trim();
                        txtIndividualAddress.Text = dt.Rows[0]["Address1"].ToString().Trim();
                        txtIndividualEmail.Text   = dt.Rows[0]["emailID"].ToString().Trim();
                        txtIndividualPhone.Text   = dt.Rows[0]["PhoneNo"].ToString().Trim();

                        lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";
                    }
                    else
                    {
                        txtIndividualName.Text = "";
                        txtIndividualAddress.Text = "";
                        txtIndividualEmail.Text = "";
                        txtIndividualPhone.Text = "";
                        chk2.Checked = false;
                        tr5.Visible = false;
                        tr6.Visible = false;
                        tr7.Visible = false;

                    }
                    txtAuthorisedSignatory.Text = dt.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                    txtSignatoryAddress.Text = dt.Rows[0]["SignatoryAddress"].ToString().Trim();
                    txtSignatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString().Trim();
                    txtSignatoryPhone.Text = dt.Rows[0]["SignatoryPhone"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                    txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();

                    lblSignatoryMobile.Text = dt.Rows[0]["SignatoryPhone"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString();
                    string Imagetype  = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    lblImagetype.Text = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    lblImageName.Text = dt.Rows[0]["ApplicantImageName"].ToString().Trim();
                    string img        = dt.Rows[0]["ApplicantImage"].ToString();
                    string imgSign    = dt.Rows[0]["ApplicantSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantImage"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrv.Attributes.Add("class", "hide");
                        Image1.Visible = true;
                        Image1.ImageUrl = "data:" + Imagetype + ";base64," + base64String;
                    }

                    if (imgSign.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantSign"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrvSign.Attributes.Add("class", "hide");
                        Image2.Visible = true;
                        Image2.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                    return;
                }
                if (dt_project.Rows.Count > 0)
                {
                    if (dt_project.Rows[0]["IAType"].ToString().Length > 0)
                    {
                        ddlTypeOfIndustry.SelectedValue = dt_project.Rows[0]["IAType"].ToString();
                    }
                    txttypeofindustry.Text             = dt_project.Rows[0]["IndustryType"].ToString();
                    txtestimatedcost.Text              = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text        = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtcoveredarea.Text                = dt_project.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text           = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    txtland.Text                       = dt_project.Rows[0]["LAIN"].ToString();
                    txtbuilding.Text                   = dt_project.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text                  = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text                = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text              = dt_project.Rows[0]["OtherExpenses"].ToString();
                    txteffluentsolidqty.Text           = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    txteffluentsolidcomposition.Text   = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    txteffluentliquidqty.Text          = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    txteffluentliquidcomposition.Text  = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    txteffluentgaseousqty.Text         = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    txteffluentgaseouscomposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    txtProjectStartMonths.Text         = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    txtWorkExperience.Text             = dt_project.Rows[0]["WorkExperience"].ToString();
                    if (dt_project.Rows[0]["IAcategory"].ToString().Trim().Length > 0)
                    {
                        drpIACategory.SelectedValue = dt_project.Rows[0]["IAcategory"].ToString().Trim();
                    }
                    if (dt_project.Rows[0]["EtpRequired"].ToString().Trim().Length > 0)
                    {
                        drpreqETp.SelectedValue = dt_project.Rows[0]["EtpRequired"].ToString().Trim();
                    }
                    if (drpreqETp.SelectedValue == "Yes")
                    {
                        MeasureDiv.Visible = true;
                    }
                    else
                    {
                        MeasureDiv.Visible = false;
                    }
                    txtExistingPlotNo.Text       = dt_project.Rows[0]["ExistingPlotNo"].ToString().Trim();
                    txtAllotmentNo.Text          = dt_project.Rows[0]["AllotmentNo"].ToString().Trim();
                    txtAllotmentDate.Text        = dt_project.Rows[0]["AllotmentDateS"].ToString().Trim();
                    txtAllotteeExisName.Text     = dt_project.Rows[0]["AllotteeName"].ToString().Trim();
                    txtManufacturedProduct.Text  = dt_project.Rows[0]["ProductManufactured"].ToString().Trim();
                    if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
                    {
                        ETP.Visible = true;
                    }
                    else
                    {
                        ETP.Visible = false;
                    }
                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        chkfumes.Checked = true;
                        fumesdiv.Visible = true;
                        txtfumeqty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                        txtfumenature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        chkfumes.Checked = false;
                        fumesdiv.Visible = false;
                        txtfumeqty.Text = "";
                        txtfumenature.Text = "";
                    }
                    txteffluenttreatmentmeasure1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    txteffluenttreatmentmeasure2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    txteffluenttreatmentmeasure3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    txtpowerreq.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();
                    txttelephonefirstyearreq1.Text = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    txttelephonefirstyearreq2.Text = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    txttelephoneUltimateyearreq1.Text = dt_project.Rows[0]["TelephoneReqUltimate1"].ToString();
                    txttelephoneUltimateyearreq2.Text = dt_project.Rows[0]["TelephoneReqUltimate2"].ToString();

                    if (dt_project.Rows[0]["ApplicantPriorityStatus"].ToString() == "True")
                    {
                        chkpriority.Checked = true;
                        prioritydiv.Visible = true;
                        bindPriorityDdl();
                        ddlPriority.SelectedValue = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString().Trim();
                    }
                    else
                    {
                        chkpriority.Checked = false;
                        prioritydiv.Visible = false;
                        ddlPriority.SelectedIndex = -1;
                    }
                    txtNetWorth.Text = dt_project.Rows[0]["NetWorth"].ToString().Trim();

                    txtTurnover.Text = dt_project.Rows[0]["NetTurnOver"].ToString().Trim();

                    if (dt_project.Rows[0]["ExpansionOfLand"].ToString() == "" || dt_project.Rows[0]["ExpansionOfLand"].ToString() == null)
                    { Ddl_Expansion.SelectedIndex = -1; }
                    else { Ddl_Expansion.SelectedValue = dt_project.Rows[0]["ExpansionOfLand"].ToString().Trim(); }
                    Ddl_Expansion_SelectedIndexChanged(null, null);
                    if (dt_project.Rows[0]["ExportOriented"].ToString() == "" || dt_project.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt_project.Rows[0]["ExportOriented"].ToString().Trim(); }




                }


                if(dt_Transferar_Photo.Rows.Count>0)
                {

                    string Imagetype = dt_Transferar_Photo.Rows[0]["AllotteeImageType"].ToString().Trim();
                    
                    string img = dt_Transferar_Photo.Rows[0]["AllotteeImage"].ToString();
                    string imgSign = dt_Transferar_Photo.Rows[0]["AllotteeSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt_Transferar_Photo.Rows[0]["AllotteeImage"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrv1.Attributes.Add("class", "hide");
                        Image4.Visible = true;
                        Image4.ImageUrl = "data:" + Imagetype + ";base64," + base64String;
                    }

                    if (imgSign.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt_Transferar_Photo.Rows[0]["AllotteeSign"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrvSign1.Attributes.Add("class", "hide");
                        Image5.Visible = true;
                        Image5.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void chkpriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpriority.Checked == true)
            {
                prioritydiv.Visible = true;
                bindPriorityDdl();
            }
            else
            {
                txtapplicantpriorityspecification.Text = "";
                prioritydiv.Visible = false;
            }


        }
        protected void Ddl_Expansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddl_Expansion.SelectedValue == "YES")
            {
                DivExpansion.Visible = true;
            }
            else
            {
                txtAllotmentDate.Text = "";
                txtAllotmentNo.Text = "";
                txtAllotteeExisName.Text = "";
                txtManufacturedProduct.Text = "";
                txtExistingPlotNo.Text = "";
                DivExpansion.Visible = false;
            }
        }
        protected void drpreqETp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpreqETp.SelectedValue == "Yes")
            {
                MeasureDiv.Visible = true;
            }
            else
            {
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                MeasureDiv.Visible = false;
            }
        }

        #endregion

        #region "ShareHolderPattern"
        public void temp_shareholder_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
                gridshareholder.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
            }


        }
        public void temp_partnership_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
                PartnershipFirmGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
            }


        }
        public void temp_trustee_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
                Trustee_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
            }


        }
        public void temp_director_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
                DirectorsGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
            }


        }
        protected void insert_shareholder_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            string shareholdername = (gridshareholder.FooterRow.FindControl("txtShareholderName_insert") as TextBox).Text;
            string shareper = (gridshareholder.FooterRow.FindControl("txtShareper_insert") as TextBox).Text;
            string address = (gridshareholder.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string email = (gridshareholder.FooterRow.FindControl("txtEmail_insert") as TextBox).Text;
            string phone = (gridshareholder.FooterRow.FindControl("txtPhone_insert") as TextBox).Text;


            if (shareholdername != "")
            {
                if (shareper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ShareHolderName"] = shareholdername;
                    dr["SharePer"] = shareper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_shareholder_details"] = dt;
                    temp_shareholder_details_DataBind();

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide ShareHolder Name');", true);
                return;
            }

        }
        protected void insert_Partnership_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];


            string Partnershipname = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert") as TextBox).Text;
            string partnershipper = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert") as TextBox).Text;
            string address = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert") as TextBox).Text;
            string email = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert") as TextBox).Text;
            string phone = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert") as TextBox).Text;


            if (Partnershipname != "")
            {
                if (partnershipper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["PartnerName"] = Partnershipname;
                    dr["PartnershipPer"] = partnershipper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_partnership_details"] = dt;

                    temp_partnership_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
                return;
            }

        }
        protected void insert_trustee_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];


            string trusteename = (Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert") as TextBox).Text;
            string address = (Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert") as TextBox).Text;
            string email = (Trustee_details_grid.FooterRow.FindControl("txtTEmail_insert") as TextBox).Text;
            string phone = (Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert") as TextBox).Text;


            if (trusteename != "")
            {


                DataRow dr = dt.NewRow();
                dr["TrusteeName"] = trusteename;
                dr["Address"] = address;
                dr["Email"] = email;
                dr["Phone"] = phone;

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_trustee_details"] = dt;

                temp_trustee_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Trustee Name');", true);
                return;
            }

        }
        protected void insert_Director_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];


            string Directorname = (DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert") as TextBox).Text;
            string din_pan = (DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert") as TextBox).Text;
            string address = (DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert") as TextBox).Text;
            string phone = (DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert") as TextBox).Text;
            string email = (DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert") as TextBox).Text;


            if (Directorname != "")
            {
                if (din_pan != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["DirectorName"] = Directorname;
                    dr["Din_Pan"] = din_pan;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_directors_details"] = dt;

                    temp_director_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Din/Pan');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Director Name');", true);
                return;
            }

        }
        protected void ShareHolderDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_shareholder_details"] = dt;

            dt.AcceptChanges();


            temp_shareholder_details_DataBind();


        }
        protected void PartnershipDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_partnership_details"] = dt;

            dt.AcceptChanges();


            temp_partnership_details_DataBind();


        }
        protected void TrusteeDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_trustee_details"] = dt;

            dt.AcceptChanges();


            temp_trustee_details_DataBind();


        }
        protected void DirectorDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_directors_details"] = dt;

            dt.AcceptChanges();


            temp_director_details_DataBind();


        }
        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            ddlcompanytype.Style.Clear();
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                //   txtCompanyname.Enabled = false;
                // txtCinNo.Enabled = false;


            }

            if (ddlcompanytype.SelectedValue == "1")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = true;
                tr6.Visible = true;
                tr7.Visible = true;
                tr8.Visible = false;
                tr9.Visible = false;
                //  txtCompanyname.Enabled = false;
                //  txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
                tr9.Visible = false;
            }
            if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
            }
            if (ddlcompanytype.SelectedValue == "4")
            {

                tr2.Visible = false;
                tr4.Visible = true;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;

                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "5")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = true;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }

        }
        protected void checkbox2_checked_changed(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                txtAuthorisedSignatory.Text = txtIndividualName.Text;
                txtSignatoryAddress.Text = txtIndividualAddress.Text;
                txtSignatoryPhone.Text = txtIndividualPhone.Text;
                txtSignatoryEmail.Text = txtIndividualEmail.Text;
            }
            else
            {
                txtAuthorisedSignatory.Text = "";
                txtSignatoryAddress.Text = ""; ;
                txtSignatoryPhone.Text = "";
                txtSignatoryEmail.Text = "";
            }
        }


        #endregion

        #region "Transfree Button Code"
        protected void BtnSaveApplicant_Click(object sender, EventArgs e)
        {

            try
            {
                int retval = 0, retVal2 = 0;

                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Add Shareholder Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.GSTNo = txtGSTNo.Text.Trim();


                ds = objServiceTimelinesBLL.UpdateTransfreeDetails(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());



                        retVal2 = objServiceTimelinesBLL.ClearFirmConstitution(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedIndex == 1)
                            {
                                string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Details Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                Allotment.ActiveViewIndex = 5;
                            }

                            if (ddlcompanytype.SelectedIndex == 2)
                            {
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.ShareHolderName = ShareholderName.Trim();
                                        objServiceTimelinesBEL.ShareHolderAddress = Address.Trim();
                                        objServiceTimelinesBEL.ShareHolderPhone = phone.Trim();
                                        objServiceTimelinesBEL.ShareHolderEmail = email.Trim();
                                        objServiceTimelinesBEL.ShareHolderPer = shareper;

                                        retval = objServiceTimelinesBLL.SaveShareHolderDetailsTransfree(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Details Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 5;
                                }
                            }
                            if (ddlcompanytype.SelectedIndex == 3)

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;

                                        retval = objServiceTimelinesBLL.SaveDirectorsDetailsTransfree(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Details Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 5;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();



                                        objServiceTimelinesBEL.TrusteeName = TrusteeName.Trim();
                                        objServiceTimelinesBEL.TrusteeAddress = Address.Trim();
                                        objServiceTimelinesBEL.TrusteePhone = phone.Trim();
                                        objServiceTimelinesBEL.TrusteeEmail = email.Trim();

                                        retval = objServiceTimelinesBLL.SaveTrusteeDetailsTransfree(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Details Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 5;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.PartnerName = PartnerName.Trim();
                                        objServiceTimelinesBEL.PartnerAddress = Address.Trim();
                                        objServiceTimelinesBEL.PartnerPhone = phone.Trim();
                                        objServiceTimelinesBEL.PartnerEmail = email.Trim();
                                        objServiceTimelinesBEL.PartnerPer = Partnershipper;

                                        retval = objServiceTimelinesBLL.SavePartnerDetailsTransfree(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Details Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Transfree Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 5;
                                }
                            }

                           
                        }


                    }
                }
                else
                {
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }



            catch (Exception ex)
            {


                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }
        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string AllotmentDate = "";
                int retval = 0, retVal2 = 0;

                int fume_status = 0; int priority_status = 0;

                //if (ddlTypeOfIndustry.SelectedIndex == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry');", true);
                //    return;
                //}
                //if (drpIACategory.SelectedIndex == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry category');", true);
                //    return;
                //}
                //if (Ddl_Expansion.SelectedIndex == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select wether company require expansion of unit');", true);
                //    return;
                //}
                //if (Drop1.SelectedIndex == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select wether company is 100% export oriented');", true);
                //    return;
                //}
                if (Ddl_Expansion.SelectedValue == "YES")
                {
                    if (ValidateDate(txtAllotmentDate.Text.Trim()))
                    {
                        AllotmentDate = DateTime.ParseExact(txtAllotmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        txtAllotmentDate.Focus();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Date');", true);
                        return;
                    }
                }
                else
                {

                }


                if (chkfumes.Checked == true)
                {

                    fume_status = 1;

                }
                else
                {
                    fume_status = 0;
                }
                if (chkpriority.Checked == true)
                {
                    if (ddlPriority.SelectedItem.Text.Trim() == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select priority category');", true);
                        return;
                    }
                    else
                    {
                        priority_status = 1;
                    }
                }
                else
                {
                    priority_status = 0;
                }

                objServiceTimelinesBEL.AllotteeID                           = Convert.ToInt32(LblAllotteeId.Text.Trim());
                objServiceTimelinesBEL.IndustryType                         = txttypeofindustry.Text.Trim();
                objServiceTimelinesBEL.EstimatedCostOfProject               = Convert.ToDecimal(txtestimatedcost.Text.Trim());
                objServiceTimelinesBEL.EstimatedEmploymentGeneration        = txtestimatedemployment.Text.Trim();
                objServiceTimelinesBEL.CoveredArea                          = txtcoveredarea.Text.Trim();
                objServiceTimelinesBEL.OpenAreaRequired                     = txtopenarearequired.Text.Trim();
                objServiceTimelinesBEL.LandDetails                          = txtland.Text.Trim();
                objServiceTimelinesBEL.BuildingDetails                      = txtbuilding.Text.Trim();
                objServiceTimelinesBEL.MachineryEquipmentsDetails           = txtmachinery.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidqty           = txteffluentsolidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidComposition   = txteffluentsolidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidqty          = txteffluentliquidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidComposition  = txteffluentliquidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousqty         = txteffluentgaseousqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousComposition = txteffluentgaseouscomposition.Text.Trim();
                objServiceTimelinesBEL.FumeGenerationStatus                 = fume_status.ToString().Trim();
                objServiceTimelinesBEL.FumeQuantity                         = txtfumeqty.Text.Trim();
                objServiceTimelinesBEL.FumeNature                           = txtfumenature.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure1            = txteffluenttreatmentmeasure1.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure2            = txteffluenttreatmentmeasure2.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure3            = txteffluenttreatmentmeasure3.Text.Trim();
                objServiceTimelinesBEL.PowerReqInKW                         = txtpowerreq.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqFirstYear1               = txttelephonefirstyearreq1.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqFirstYear2               = txttelephonefirstyearreq2.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqUltimate1                = txttelephoneUltimateyearreq1.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqUltimate2                = txttelephoneUltimateyearreq2.Text.Trim();
                objServiceTimelinesBEL.ApplicantPriorityStatus              = priority_status.ToString().Trim();
                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();

                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience     = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver        = txtNetWorth.Text.Trim();
                objServiceTimelinesBEL.ExpansionOfLand    = Ddl_Expansion.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ExportOriented     = Drop1.SelectedItem.Text.Trim();

                if (Ddl_Expansion.SelectedValue == "YES")
                {
                    objServiceTimelinesBEL.AllotmentDate = Convert.ToDateTime(DateTime.ParseExact(txtAllotmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                }

                objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text.Trim();
                objServiceTimelinesBEL.ExistingAllotteeName = txtAllotteeExisName.Text.Trim();
                objServiceTimelinesBEL.ExistingPlotNo = txtExistingPlotNo.Text.Trim();
                objServiceTimelinesBEL.IAcategory = Convert.ToInt32(drpIACategory.SelectedValue.Trim());
                objServiceTimelinesBEL.IAType = Convert.ToInt32(ddlTypeOfIndustry.SelectedValue.Trim());
                objServiceTimelinesBEL.ProductManufactured = txtManufacturedProduct.Text;
                objServiceTimelinesBEL.EtpRequired = drpreqETp.SelectedValue.Trim();
                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets   = txtFixedAssets.Text.Trim();
                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience     = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver        = txtTurnover.Text.Trim();
                objServiceTimelinesBEL.ExpansionOfLand    = Ddl_Expansion.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ExportOriented     = Drop1.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Networth           = txtNetWorth.Text.Trim();


                retval = objServiceTimelinesBLL.UpdateTransfreeProjectDetails(objServiceTimelinesBEL);
                
                if (retval > 0)
                {
                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree project details uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                    string message = "Applicant Project Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 7;
                }


            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }

        }
        protected void drpIACategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
            {
                ETP.Visible = true;
            }
            else
            {
                drpreqETp.SelectedIndex = 0;
                txteffluentgaseouscomposition.Text = "";
                txteffluentgaseousqty.Text = "";
                txteffluentliquidqty.Text = "";
                txteffluentliquidcomposition.Text = "";
                txteffluentsolidcomposition.Text = "";
                txteffluentsolidqty.Text = "";
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                ETP.Visible = false;
            }
        }

        protected void btnSaveImage_ServerClick(object sender, EventArgs e)
        {

            if (FuplodApplicantImage.HasFile)
            {
                string filePath = FuplodApplicantImage.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantImage.FileName.ToString());
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
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantImage.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;


                    int result;

                     result = objServiceTimelinesBLL.SaveApplicantImageTransfree(objServiceTimelinesBEL); 

                    if (result > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree Photo uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                        string message = "Image Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }
        protected void btnSaveSign_ServerClick(object sender, EventArgs e)
        {
            if (FuplodApplicantSign.HasFile)
            {
                string filePath = FuplodApplicantSign.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantSign.FileName.ToString());
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
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantSign.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO   = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent       = contenttype;

                    int result;
                    result = objServiceTimelinesBLL.SaveApplicantSignTransfree(objServiceTimelinesBEL); 

                    if (result > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfree signature uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                        string message = "Signature Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }
        protected void btnmySave_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0, retVal2 = 0;

                if (txtPayeeName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee name');", true);
                    return;
                }

                if (txtPayeeBank.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee bank name');", true);
                    return;
                }
                if (txtaccntNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee account number');", true);
                    return;
                }
                if (txtConfirmAccNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee confirm account number');", true);
                    return;
                }

                if (txtIFSCCode.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter ifsc code');", true);
                    return;
                }

                if (txtBranchName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter branch name');", true);
                    return;
                }

                if (txtBranchAddress.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter branch address');", true);
                    return;
                }



                if (txtaccntNo.Text == txtConfirmAccNo.Text)
                {

                    objServiceTimelinesBEL.AllotteeID    = Convert.ToInt32(LblAllotteeId.Text.Trim());
                    objServiceTimelinesBEL.PayeeName     = txtPayeeName.Text.Trim();
                    objServiceTimelinesBEL.PayeeBankName = txtPayeeBank.Text.Trim();
                    objServiceTimelinesBEL.AccountNo     = txtConfirmAccNo.Text.Trim();
                    objServiceTimelinesBEL.IFSCCode      = txtIFSCCode.Text.Trim();
                    objServiceTimelinesBEL.BranchName    = txtBranchName.Text.Trim();
                    objServiceTimelinesBEL.BranchAddress = txtBranchAddress.Text.Trim();



                
                    retval = objServiceTimelinesBLL.UpdateTransferarAccountsDetails(objServiceTimelinesBEL);
                    
                    if (retval > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Accounts Details Entered and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                        string message = "Transferar Accounts Details Saved Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetPaymentDetails();
                        Allotment.ActiveViewIndex = 9;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Account No and Confirm Account Does not Matched');", true);
                    return;
                }




            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        #endregion


        #region "Acknowledgement"
        private void CheckAck()
        {

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                DataSet ds = new DataSet();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.CheckTransferPlotAcknowledgement(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string UP                  = dt.Rows[0]["UnitUnderProduction"].ToString();
                    string UP2                 = dt.Rows[0]["UnitUProductionMoreThanTwoYear"].ToString();
                    string CoveredArea         = dt.Rows[0]["CoveredAreaCurrent"].ToString();
                    string TLExemption         = dt.Rows[0]["TLExempted"].ToString();
                    string TLExemptionCase     = dt.Rows[0]["TLCaseType"].ToString();
                    string TLExemptionCaseName = dt.Rows[0]["TLCaseTypeName"].ToString();
                    string LevyCase            = dt.Rows[0]["TLLevyType"].ToString();
                    string SubDate             = dt.Rows[0]["SubDivisionDate"].ToString();
                    string DeathDate           = dt.Rows[0]["DeathDate"].ToString();

                    if (UP2.Length<=0)
                    {
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);

                        MenuItemCollection menuItems1 = sub_menu.Items;
                        MenuItem menuItem1 = new MenuItem();
                        foreach (MenuItem item in menuItems1)
                        {
                            if (item.Text == "Transferar Documents")
                                menuItem1 = item;
                        }
                        menuItems1.Remove(menuItem1);

                        MenuItemCollection menuItems2 = sub_menu.Items;
                        MenuItem menuItem2 = new MenuItem();
                        foreach (MenuItem item in menuItems2)
                        {
                            if (item.Text == "Transfree Account Details")
                                menuItem2 = item;
                        }
                        menuItems2.Remove(menuItem2);

                        MenuItemCollection menuItems3 = sub_menu.Items;
                        MenuItem menuItem3 = new MenuItem();
                        foreach (MenuItem item in menuItems3)
                        {
                            if (item.Text == "Transfree Details")
                                menuItem3 = item;
                        }
                        menuItems3.Remove(menuItem3);

                        MenuItemCollection menuItems4 = sub_menu.Items;
                        MenuItem menuItem4 = new MenuItem();
                        foreach (MenuItem item in menuItems4)
                        {
                            if (item.Text == "Transfree Photo & Sign")
                                menuItem4 = item;
                        }
                        menuItems4.Remove(menuItem4);

                        MenuItemCollection menuItems5 = sub_menu.Items;
                        MenuItem menuItem5 = new MenuItem();
                        foreach (MenuItem item in menuItems5)
                        {
                            if (item.Text == "Transfree Project Details")
                                menuItem5 = item;
                        }
                        menuItems5.Remove(menuItem5);

                        MenuItemCollection menuItems6 = sub_menu.Items;
                        MenuItem menuItem6 = new MenuItem();
                        foreach (MenuItem item in menuItems6)
                        {
                            if (item.Text == "Transfree Documents")
                                menuItem6 = item;
                        }
                        menuItems6.Remove(menuItem6);

                        MenuItemCollection menuItems7 = sub_menu.Items;
                        MenuItem menuItem7 = new MenuItem();
                        foreach (MenuItem item in menuItems7)
                        {
                            if (item.Text == "Fee Details")
                                menuItem7 = item;
                        }
                        menuItems7.Remove(menuItem7);
                        MenuItemCollection menuItems8 = sub_menu.Items;
                        MenuItem menuItem8 = new MenuItem();
                        foreach (MenuItem item in menuItems8)
                        {
                            if (item.Text == "Transferar Photo & Sign")
                                menuItem8 = item;
                        }
                        menuItems8.Remove(menuItem8);
                    }
                    else
                    {
                        drp_TransferApplicableCase.SelectedValue = TLExemptionCase;
                        if (TLExemptionCase == "1")
                        {
                            DeathDetailsDiv.Visible = true;
                            SubdivisionDiv.Visible = false;
                            AckDiv.Visible = false;


                        }
                        if (TLExemptionCase == "2")
                        {
                            DeathDetailsDiv.Visible = false;
                            SubdivisionDiv.Visible = true;
                            AckDiv.Visible = false;
                        }
                        if (TLExemptionCase == "3")
                        {
                            DeathDetailsDiv.Visible = false;
                            SubdivisionDiv.Visible = false;
                            AckDiv.Visible = true;
                        }

                        if (UP == "True")
                        {

                        }
                        else
                        {

                        }

                        FeeDiv.Visible = false;
                        if (UP2 == "True")
                        {
                            ProRataDiv.Visible = true;
                            DropDownList2.SelectedValue = "1";
                            if (LevyCase == "1")
                            {
                                RadioProRata.SelectedValue = "1";
                            }
                            else
                            {
                                RadioProRata.SelectedValue = "2";
                            }
                        }
                        else
                        {
                            ProRataDiv.Visible = false;
                            DropDownList2.SelectedValue = "0";
                        }
                        if (TLExemption == "True")
                        {

                        }
                        else
                        {

                        }

                        txtDateofDeath.Text = DeathDate.Trim();
                        txtSubdivisionDate.Text = SubDate.Trim();
                        txtDateofDeath.Enabled = false;
                        txtSubdivisionDate.Enabled = false;
                        drp_TransferApplicableCase.Enabled = false;
                        txtCoveredAreaT.Text = CoveredArea.Trim();
                        btn_Ack.Text = "Acknowledged";
                        btn_Ack.Enabled = false;
                        RadioProRata.Enabled = false;
                        DropDownList2.Enabled = false;
                        btnViewLevy.Text = "Acknowledged";
                        btnViewLevy.Enabled = false;
                        txtCoveredAreaT.Enabled = false;

                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void btn_Ack_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;





                objServiceTimelinesBEL.TLCaseType = drp_TransferApplicableCase.SelectedValue.Trim();
                objServiceTimelinesBEL.UnitUnderProductionMoreThenTwoYearStatus = DropDownList2.SelectedValue.Trim();
                objServiceTimelinesBEL.CoveredAreaTransfer = (string.IsNullOrEmpty(txtCoveredAreaT.Text.Trim()) ? "0" : txtCoveredAreaT.Text.Trim());
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TLLevyType = RadioProRata.SelectedValue.Trim();
                objServiceTimelinesBEL.TLCaseName = drp_TransferApplicableCase.SelectedItem.Text.Trim();
                if (RadioProRata.SelectedValue == "1")
                {
                    objServiceTimelinesBEL.HOApproval = "1";
                }
                else
                {
                    objServiceTimelinesBEL.HOApproval = "0";
                }
                if (drp_TransferApplicableCase.SelectedValue == "1")
                {
                    string date_to_be = DateTime.ParseExact(txtDateofDeath.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.DeathDate = Convert.ToDateTime((date_to_be));
                }
                if (drp_TransferApplicableCase.SelectedValue == "2")
                {
                    string date_to_be = DateTime.ParseExact(txtSubdivisionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.SubdivisionDate = Convert.ToDateTime((date_to_be));
                }
                retval = objServiceTimelinesBLL.UpdateAcknowledgementTransferNew(objServiceTimelinesBEL);

                if (retval > 0)
                {
                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Acknowledge the terms and condition and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                    string message = "Now Proceed to fill rest of the form";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect('" + message + "','" + ServiceReqNo + "');", true);
                }


            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
                return;
            }
        }
   
        #endregion

        #region "Fee Details"

        private void GetPaymentDetails()
        {

            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;
            string companyName = string.Empty;
            string ApplicantName = string.Empty;
            string applicantAddress = string.Empty;
            string SWCControlID = String.Empty;
            string SWCUnitID = String.Empty;
            string SWCServiceID = String.Empty;
            string SWCStatus = String.Empty;
            string SWCPayMode = String.Empty;

            try
            {

                GeneralMethod gm = new GeneralMethod();
                SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeIAService '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string Applicantname = dt.Rows[0]["ApplicantName"].ToString();
                string Address       = dt.Rows[0]["Address"].ToString();
                string IAID          = dt.Rows[0]["IAID"].ToString();
                string PlotArea      = dt.Rows[0]["PlotArea"].ToString();
                string CoveredArea   = dt.Rows[0]["CoveredArea"].ToString();
                string AllottmentNo  = dt.Rows[0]["Allotmentletterno"].ToString();
                string ControlID     = dt.Rows[0]["ControlId"].ToString();
                string UnitID        = dt.Rows[0]["UnitId"].ToString();
                string ServiceID     = dt.Rows[0]["ServiceId"].ToString();
                string TraID         = dt.Rows[0]["TraID"].ToString();


                UC_IAServiceProcessFeeNMSWP UC_IAServiceProcessFeeNMSWP = LoadControl("~/UC_IAServiceProcessFeeNMSWP.ascx") as UC_IAServiceProcessFeeNMSWP;

                UC_IAServiceProcessFeeNMSWP.IndustrialArea = Convert.ToInt32(IAID);
                UC_IAServiceProcessFeeNMSWP.choicearea = Convert.ToDouble(PlotArea);
                UC_IAServiceProcessFeeNMSWP.AllotmentLetterNo = AllottmentNo;
                UC_IAServiceProcessFeeNMSWP.SWCControlID = ControlID;
                UC_IAServiceProcessFeeNMSWP.SWCUnitID = UnitID;
                UC_IAServiceProcessFeeNMSWP.SWCServiceID = ServiceID;
                UC_IAServiceProcessFeeNMSWP.ServiceRequestNo = ServiceReqNo;
                UC_IAServiceProcessFeeNMSWP.TranID = TraID;
                UC_IAServiceProcessFeeNMSWP.ApplicantName = Applicantname;
                UC_IAServiceProcessFeeNMSWP.applicantAddress = Address;
                PlaceHolder1.Controls.Add(UC_IAServiceProcessFeeNMSWP);
            }
            catch (Exception ex)
            { 
            
            }

        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            if (btnPay.Text == "Print")
            {
                GetPaymentDetails();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

            }
            else
            {

                int Count1 = 0;
                //SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocuments '" + ServiceReqNo.Trim() + "'", con);
                //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //DataSet dss = new DataSet();
                //adp.Fill(dss);
                //if (dss.Tables.Count > 0)
                //{
                //    DataTable dt1 = dss.Tables[0];
                //    DataTable dt2 = dss.Tables[1];
                //    string Message = "";


                //    if (dt1.Rows.Count <= 0)
                //    {

                //        if (TypeID == "1003")
                //        {
                //            Message = "Project Details are Mandatory";
                //        }
                //        if (TypeID == "1004")
                //        {
                //            Message = "Product details are Mandatory";
                //        }
                //        if (TypeID == "1009")
                //        {
                //            Message = "Building Specifications are Mandatory";
                //        }
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                //        GetPaymentDetails();
                //        return;
                //    }
                //    else
                //    {
                //        string Project = dt1.Rows[0][0].ToString();
                //        if (Project == "Pending")
                //        {

                //            if (TypeID == "1003")
                //            {
                //                Message = "Project Details are Mandatory";
                //            }
                //            if (TypeID == "1004")
                //            {
                //                Message = "Product details are Mandatory";
                //            }
                //            if (TypeID == "1009")
                //            {
                //                Message = "Building Specifications are Mandatory";
                //            }
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                //            GetPaymentDetails();
                //            return;
                //        }

                //    }
                //    if (dt2.Rows.Count > 0)
                //    {
                //        int count = Convert.ToInt32(dt2.Rows[0][0].ToString());
                //        string firmType = dt2.Rows[0][1].ToString();

                //        switch (firmType)
                //        {
                //            case "1003":
                //                Count1 = 2;
                //                break;
                //            case "1004":
                //                Count1 = 2;
                //                break;
                //            case "1009":
                //                Count1 = 7;
                //                break;
                //            case "1010":
                //                Count1 = 7;
                //                break;
                //            case "1023":
                //                Count1 = 0;
                //                break;

                //        }

                //        if (count < Count1)
                //        {
                //            Message = "Please upload all mandatory documents";
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                //            GetPaymentDetails();
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        Message = "There is Problem with server please try again after sometime";
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                //        GetPaymentDetails();
                //        return;
                //    }
                //}

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(ServiceReqNo, "UPSIDC");

                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    dsR = objServiceTimelinesBLL.GetapplicableChargesforTransferPlotAmount(objServiceTimelinesBEL);

                    if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                    if (dt_Fee.Rows.Count > 0)
                    {

                        try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                        gm = new GeneralMethod();
                        string NewString = Regex.Replace(lblAllotteeName.Text, @"[^0-9a-zA-Z]+", "");
                        string PaymentGetwayURL = gm.SendToPaymentGetwayHDFCNew(1, TransactionId_UPSIDC, ServiceReqNo, "Transfer Of Plot", NewString.Trim(), lblSIgnatoryEmail.Text, lblSignatoryMobile.Text, "One");

                        if (PaymentGetwayURL == "Failed")
                        {

                            string Message = "Errro Ocured In Processing !";

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        }
                        else
                        {
                            Response.Redirect(PaymentGetwayURL);
                        }
                    }
                }
            }

        }

        #endregion


        #region "Final View"
        private void GetApplicationDetails()
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
                    string NMSWPFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
                    string Status = dt.Rows[0]["FinalSubmission"].ToString();



                    if (Objection == "True")
                    {
                        Allotment.ActiveViewIndex = 11;
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);

                    }
                    else
                    {
                        if (NMSWPFee == "Paid")
                        {
                            DocDisable.Text = "Lock";
                            DisableAllControl();
                        }
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Value == "11")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }


                    if (NMSWPFee == "Paid")
                    {
                        btn_Submit.Text = "Print";
                    }
                    else if (NMSWPFee == "Pending")
                    {
                        btn_Submit.Text = "Print";
                        DocDisable.Text = "Lock";
                        DisableAllControl();
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }
                    else
                    {
                        DocDisable.Text = "UnLock";
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }
                    if (Rejected == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "12", Text = "Rejection Letter" });
                    }
                    if (Completed == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "12", Text = "Approval Letter" });
                    }


                }

            }

        }
        private void GetFinalView()
        {
            
                UC_ApplicationFinalViewTransferPlot UC_ApplicationFinalViewTransferPlot = LoadControl("~/UC_ApplicationFinalViewTransferPlot.ascx") as UC_ApplicationFinalViewTransferPlot;
                UC_ApplicationFinalViewTransferPlot.ID = "UC_ApplicationFinalViewTransferPlot";
                UC_ApplicationFinalViewTransferPlot.ControlID = SWCUnitID;
                UC_ApplicationFinalViewTransferPlot.ServiceRequestNo = ServiceReqNo;
                PH_FinalView.Controls.Add(UC_ApplicationFinalViewTransferPlot);
            

        }


        #endregion

        #region  "Transferar Photo & sign"
        
        protected void btn_TransferarPhoto_ServerClick(object sender, EventArgs e)
        {
            if (FuplodApplicantImage1.HasFile)
            {
                string filePath = FuplodApplicantImage1.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantImage1.FileName.ToString());
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
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantImage1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO   = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent       = contenttype;


                    int result;
                    result = objServiceTimelinesBLL.SaveImageTransferar(objServiceTimelinesBEL);

                    if (result > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transferar Photo uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                        string message = "Image Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }

        protected void btn_TransferarSign_ServerClick(object sender, EventArgs e)
        {
            if (FuplodApplicantSign1.HasFile)
            {
                string filePath = FuplodApplicantSign1.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantSign1.FileName.ToString());
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
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantSign1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;

                    int result;
                    result = objServiceTimelinesBLL.SaveSignTransferar(objServiceTimelinesBEL);

                    if (result > 0)
                    {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transferar Signature uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                        string message = "Signature Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }

        #endregion

        protected void btn_ViewBack_Click(object sender, EventArgs e)
        {
            Allotment.ActiveViewIndex = 0;
        }

        protected void btn_AckViewNext_Click(object sender, EventArgs e)
        {
            Allotment.ActiveViewIndex = 2;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (btn_Submit.Text == "Print")
            {
                GetPaymentDetails();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

            }
            else
            {

                int Count1 = 0;
                SqlCommand cmd = new SqlCommand("[ValidateDetailsAndDocumentsTransfer] '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                adp.Fill(dss);
                if (dss.Tables.Count > 0)
                {
                    DataTable Transferar = dss.Tables[0];
                    DataTable Transfree = dss.Tables[1];
                    

                    if(Transferar.Rows.Count>0)
                    {
                        string Image    = Transferar.Rows[0][0].ToString();
                        string Sign     = Transferar.Rows[0][1].ToString();
                        string DocCount = Transferar.Rows[0][2].ToString();
                        string DocNo = Transferar.Rows[0][3].ToString();
                        if (Image.Length<=0)
                        {
                            string Message = "Kindly upload transferar image";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Sign.Length <= 0)
                        {
                            string Message = "Kindly upload transferar signature";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Convert.ToInt32(DocCount)< Convert.ToInt32(DocNo))
                        {
                            string Message = "Kindly upload all required transferar documents";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                    }
                    if (Transfree.Rows.Count > 0)
                    {
                        string Applicant = Transfree.Rows[0][0].ToString();
                        string Image = Transfree.Rows[0][1].ToString();
                        string Sign = Transfree.Rows[0][2].ToString();
                        string Account = Transfree.Rows[0][3].ToString();
                        string FirmType = Transfree.Rows[0][4].ToString();
                        string DocCount = Transfree.Rows[0][5].ToString();
                        string Project = Transfree.Rows[0][6].ToString();
                        if (Applicant.Length <= 0)
                        {
                            string Message = "Kindly enter transfree basic details";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Image.Length <= 0)
                        {
                            string Message = "Kindly upload transfree image";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Sign.Length <= 0)
                        {
                            string Message = "Kindly upload transfree signature";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Project.Length <= 0)
                        {
                            string Message = "Kindly enter complete project deatils of transfree";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                        if (Account.Length <= 0)
                        {
                            string Message = "Kindly enter transfree account details";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }

                     
                        switch (FirmType)
                        {
                            case "1":
                                Count1 = 4;
                                break;
                            case "2":
                                Count1 = 11;
                                break;
                            case "3":
                                Count1 = 11;
                                break;
                            case "4":
                                Count1 = 7;
                                break;
                            case "5":
                                Count1 = 5;
                                break;
                        }

                        if (Convert.ToInt32(DocCount) < Count1)
                        {
                            string Message = "Please upload all mandatory documents of transfree";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }


                    }




                }
                else { }

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                GeneralMethod gm = new GeneralMethod();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                dsR = objServiceTimelinesBLL.GetApplicableChargesIAServicesNMSWPPay(objServiceTimelinesBEL);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {

                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                    if (TotalCharges > 0)
                    {

                        string ReturnMsg = gm.CreateTransactionDataBeforeNMSWP(ServiceReqNo);
                        if (ReturnMsg.Trim() == "Success")
                        {
                            string NMSWP_Result = gm.UpdateFeeAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "12", "Applicant Request Submitted, Fee Payment is Pending kindly pay fees for the final submission | Applicant", (TotalCharges).ToString(), SWCRequest_ID, "Applicant");

                            if (NMSWP_Result.Trim() == "SUCCESS")
                            {
                                string ReturnMsg1 = gm.UpdateTraStatusNMSWP(ServiceReqNo);
                                if (ReturnMsg1 == "Success")
                                {
                                    string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetPaymentDetails();
                                    GetApplicationDetails();
                                    return;
                                }
                                else
                                {
                                    string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetPaymentDetails();
                                    GetApplicationDetails();
                                    return;
                                }

                            }
                        }


                    }
                    else
                    {
                        string Message = "Amount is null";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                }

            }
        }
        private void CheckNMSWPFeePaid()
        {

            SqlCommand cmd = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ControlID='" + SWCControlID.Trim() + "' and UnitID='" + SWCUnitID.Trim() + "' and ServiceID='" + SWCServiceID.Trim() + "' and RequestID='" + SWCRequest_ID + "' and isnull(Fee_Status,'') in ('Pending')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID,SWCRequest_ID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "11")
                {
                    string TransactionDate     = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID       = dt.Rows[0]["Transaction_ID"].ToString();
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

                string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

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

        private void DisableAllControl()
        {
            txttypeofindustry.Enabled = false;
            txtWorkExperience.Enabled = false;

            txtProjectStartMonths.Enabled = false;
            txtpowerreq.Enabled = false;
            txtOtherExpenses.Enabled = false;
            txtland.Enabled = false;
            txtmachinery.Enabled = false;
            txtopenarearequired.Enabled = false;
            txtcoveredarea.Enabled = false;
            txteffluentgaseouscomposition.Enabled = false;
            txteffluentgaseousqty.Enabled = false;
            txteffluentliquidqty.Enabled = false;
            txteffluentsolidcomposition.Enabled = false;
            txteffluentsolidqty.Enabled = false;
            txteffluentliquidcomposition.Enabled = false;
            txtestimatedcost.Enabled = false;
            txtFixedAssets.Enabled = false;
            txtfumeqty.Enabled = false;
            txtfumenature.Enabled = false;
            txtbuilding.Enabled = false;
            txtapplicantpriorityspecification.Enabled = false;
            ddlPriority.Enabled = false;

            Drop1.Enabled = false;
            txteffluenttreatmentmeasure1.Enabled = false;
            txteffluenttreatmentmeasure2.Enabled = false;
            txteffluenttreatmentmeasure3.Enabled = false;
            BtnProjectInsert.Text = "Saved";
            BtnProjectInsert.Enabled = false;
            BtnSaveApplicant.Enabled = false;
            BtnSaveApplicant.Text = "Saved";
            btnmySave.Text = "Saved";
            btnmySave.Enabled = false;
            btnSaveImage.Enabled = false;
            btnSaveImage.Enabled = false;
            btnSaveSign.Enabled = false;
            btn_TransferarPhoto.Enabled = false;
            btn_TransferarSign.Enabled = false;
        }

        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveDemandPlusObjection UC_ResolveDemandPlusObjection = LoadControl("~/UC_ResolveDemandPlusObjection.ascx") as UC_ResolveDemandPlusObjection;
            UC_ResolveDemandPlusObjection.ID = "UC_ResolveDemandPlusObjection";
            UC_ResolveDemandPlusObjection.ServiceReqNo = ServiceReqNo;
            PH_Objection.Controls.Add(UC_ResolveDemandPlusObjection);
        }

        protected void drp_TransferApplicableCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Ack.Visible = false;
            FeeDiv.Visible = false;
            txtCoveredAreaT.Text = "";
            txtSubdivisionDate.Text = "";
            txtDateofDeath.Text = "";
            if (drp_TransferApplicableCase.SelectedValue.Trim() == "1")
            {
                DeathDetailsDiv.Visible = true;
                SubdivisionDiv.Visible = false;
                AckDiv.Visible = false;
            }
            else if (drp_TransferApplicableCase.SelectedValue.Trim() == "2")
            {
                DeathDetailsDiv.Visible = false;
                SubdivisionDiv.Visible = true;
                AckDiv.Visible = false;
            }
            else if (drp_TransferApplicableCase.SelectedValue.Trim() == "3")
            {
                DeathDetailsDiv.Visible = false;
                SubdivisionDiv.Visible = false;
                AckDiv.Visible = true;
            }
            else
            {
                DeathDetailsDiv.Visible = false;
                SubdivisionDiv.Visible = false;
                AckDiv.Visible = false;
            }

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Ack.Visible = false;
            FeeDiv.Visible = false;
            if (DropDownList2.SelectedValue == "1")
            {
                ProRataDiv.Visible = true;
                LevyDiv.Visible = false;

            }
            else if (DropDownList2.SelectedValue == "0")
            {
                ProRataDiv.Visible = false;
                LevyDiv.Visible = true;
            }
            else
            {
                ProRataDiv.Visible = false;
                LevyDiv.Visible = false;
            }

        }

        protected void btnViewLevy_Click(object sender, EventArgs e)
        {

            if (drp_TransferApplicableCase.SelectedValue == "0")
            {
                
                    string Message = "Please select applicable case";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
              
            }
            if (drp_TransferApplicableCase.SelectedValue == "1")
            {
                if (txtDateofDeath.Text == "")
                {
                    string Message = "Please enter death/disablement date";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
            }
            if (drp_TransferApplicableCase.SelectedValue == "2")
            {
                if (txtSubdivisionDate.Text == "")
                {
                    string Message = "Please enter subdivision date";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
            }
            if (drp_TransferApplicableCase.SelectedValue == "3")
            {
                if (txtCoveredAreaT.Text == "")
                {
                    string Message = "Please enter covered area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (DropDownList2.SelectedIndex == 0)
                {
                    string Message = "Please verify unit is in production for more than two year or not";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

            }


            BindTLApplicableFees();
        }

        public void BindTLApplicableFees()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dschoicearea = new DataSet();
            DataSet dschoiceP1 = new DataSet();
            DataSet dschoiceP2 = new DataSet();
            DataSet dschoiceP3 = new DataSet();
            DataSet Pay_Ds = new DataSet();
            DataTable Paymentdt = new DataTable();
            string htmldata = "";
            DateTime date_today = DateTime.Now;
            decimal subTotalApplicableFees = 0;
            decimal TotalCharges = 0;
            string appliedthrough = string.Empty;
            string industrialarea = string.Empty;
            string plotsize = string.Empty;
            string PayMode = string.Empty;

            try
            {
                GeneralMethod gm = new GeneralMethod();


                objServiceTimelinesBEL.TLCaseType = drp_TransferApplicableCase.SelectedValue.Trim();
                objServiceTimelinesBEL.UnitUnderProductionMoreThenTwoYearStatus = DropDownList2.SelectedValue.Trim();
                objServiceTimelinesBEL.CoveredAreaTransfer = (string.IsNullOrEmpty(txtCoveredAreaT.Text.Trim()) ? "0" : txtCoveredAreaT.Text.Trim());
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.TLLevyType = RadioProRata.SelectedValue.Trim();

                dschoicearea = objServiceTimelinesBLL.GetTransferLevyCalculation(objServiceTimelinesBEL);

                // for Option 1 : Based on Selected Plot Area 
                DataTable Getdata1 = new DataTable();
                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));

                        TotalCharges = subTotalApplicableFees;



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            industrialarea = Convert.ToString(industrialarea);

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {
                                btn_Ack.Visible = true;
                                FeeDiv.Visible = true;

                                htmldata += @"
                                    <div class='col- md-6'><table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">                                 
                                    <tr style = 'background:#f7f7f7;'>
                                    <th>Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";

                                // htmldata += @"
                                //<tr style = 'background:#f7f7f7;'> <th> B. Applicable Deposits" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";

                                htmldata += @"

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges " + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + TotalCharges + @"</th>
                                    </tr>
                                </table></div><br /><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                                htmldata += @"
                               <tr><td colspan=""3"">" + "A. Applicable Fees" + @"</td></tr>";

                                //Building the Data rows for Applicable fees.
                                foreach (DataRow row in Getdata1.Rows)
                                {
                                    htmldata += @" <tr> ";
                                    foreach (DataColumn column in Getdata1.Columns)
                                    {
                                        htmldata += @"<td class='text-center'> ";
                                        htmldata += @row[column.ColumnName];
                                        // html.Append(row[column.ColumnName]);
                                        htmldata += @"</td> ";
                                    }
                                    htmldata += @"</tr> ";
                                }

                                htmldata += @"
                              <tr><td colspan=""2"" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</td></tr>";



                                htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";



                                htmldata += " </table>";

                            }
                            else
                            {
                                btn_Ack.Visible = false;
                                FeeDiv.Visible = false;
                            }

                        }

                    }



                }
                else
                {
                    btn_Ack.Visible = false;
                    FeeDiv.Visible = false;
                    string Message = "Required covered area is less than 5% of plot size. Hence not allowed";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                PlaceHolder2.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void RadioProRata_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Ack.Visible = false;
            FeeDiv.Visible = false;
        }
        protected void txtCoveredAreaT_TextChanged(object sender, EventArgs e)
        {
            btn_Ack.Visible = false;
            FeeDiv.Visible = false;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            BindTLApplicableFees();
            if (CheckBox1.Checked == true)
            {
                btn_Ack.Enabled = true;
            }
            else
            {
                btn_Ack.Enabled = false;
            }
        }
    }

}