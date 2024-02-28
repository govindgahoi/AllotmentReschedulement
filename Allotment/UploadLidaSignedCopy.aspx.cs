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
    public partial class UploadLidaSignedCopy : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        #endregion
        SqlConnection con;


        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        string SerReqNo;
        string Type = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SerReqNo = Request.QueryString["ServiceReqNo"];
            Type = Request.QueryString["Type"];

            //DataTable NMSWP = gm.GetNMSWPIDNews(SerReqNo);
            //SWCControlID = NMSWP.Rows[0][0].ToString();
            //SWCUnitID = NMSWP.Rows[0][1].ToString();
            //SWCServiceID = NMSWP.Rows[0][2].ToString();
            //Request_ID = NMSWP.Rows[0][3].ToString();

            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }


        public void BindGridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("GetSignedChecklist '" + Type + "','" + SerReqNo + "'", con);


            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }

        }



        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

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
                    DataRowView rowView = (DataRowView)e.Row.DataItem;
                    string ReqNo = rowView["ServiceRequestNO"].ToString();
                    string Service = rowView["Service"].ToString();

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ReqNo.Trim();
                    objServiceTimelinesBEL.Doctype = Service.Trim();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {

                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                            e.Row.FindControl("lbDelete").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                            e.Row.FindControl("lbDelete").Visible = true;
                        }
                    }

                }
            }
            catch
            {

            }


        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            string NewAllotteeID = "";
            string ControlID = "";
            string UnitID = "";
            string ServiceID = "";
            string AllotteeID = "";
            string status = "";
            string Flag = "";
            string DocType = "";
            string Reason = "";
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % GridView2.PageSize;
            string SerReqNo = GridView2.DataKeys[index].Values[0].ToString();
            string Service = GridView2.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "Upload")
            {
                try
                {



                    switch (Type)
                    {

                        case "LDR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "LBP":
                            Flag = "Completed";
                            break;
                        case "LBPR":
                            Flag = "Rejected";
                            break;
                        case "AL":
                            Flag = "Completed";
                            break;
                        case "AR":
                            Flag = "Rejected";
                            break;
                        case "TR":
                            Flag = "Completed";
                            DocType = "Transfer";
                            break;
                        case "TRR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "COPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "COP":
                            Flag = "Completed";
                            DocType = "ChangeOfProject";
                            break;
                        case "AOPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "AOP":
                            Flag = "Completed";
                            DocType = "AdditionOfProduct";
                            break;
                        case "CC":
                            Flag = "Completed";
                            break;
                        case "CCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "OC":
                            Flag = "Completed";
                            break;
                        case "OCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "MO":
                            Flag = "Completed";
                            DocType = "Jointmortgage";
                            break;
                        case "MOR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "NM":
                            Flag = "Completed";
                            DocType = "nocmortgage";
                            break;
                        case "NMR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "TLD":
                            Flag = "Completed";
                            DocType = "transferofleasedeed";
                            break;
                        case "TLDR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "TEF":
                            Flag = "Completed";
                            DocType = "Timeextensionfee";
                            break;
                        case "TEFR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "SC":
                            Flag = "Completed";
                            DocType = "secondcharge";
                            break;
                        case "SCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "NDC":
                            Flag = "Completed";
                            DocType = "NoDues";
                            break;
                        case "NDCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "ODC":
                            Flag = "Completed";
                            DocType = "OutstandingDues";
                            break;
                        case "ODCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "LDER":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;

                        #region Add by manish Rastogi
                        case "RF":
                            Flag = "Completed";
                            DocType = "ReconstitutionOfCompany";
                            break;
                        case "RFR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;

                        case "HLD":
                            Flag = "Completed";
                            DocType = "HandOverleasedeed";
                            break;
                        case "HLDR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "WC":
                            Flag = "Completed";
                            break;
                        case "WCR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "RLF":
                            Flag = "Completed";
                            DocType = "Reconstitutionforlegalheir";
                            break;
                        case "RLFR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        #endregion
                        #region ManishShuklacode
                        case "SOP":
                            Flag = "Completed";
                            DocType = "surrender";
                            break;
                        case "SOPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "ROP":
                            Flag = "Completed";
                            DocType = "Restoration";
                            break;
                        case "ROPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "STOP":
                            Flag = "Completed";
                            DocType = "startofproduction";
                            break;
                        case "STOPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "ADOP":
                            Flag = "Completed";
                            DocType = "Additional";
                            break;
                        case "ADOPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "SUOP":
                            Flag = "Completed";
                            DocType = "Subleting";
                            break;
                        case "SUOPR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                        case "APA":
                            Flag = "Completed";
                            DocType = "AmalgamationPostAllotment";
                            break;
                        case "APAR":
                            Flag = "Rejected";
                            DocType = "Rejection";
                            break;
                            #endregion
                    }

                    if (Service == "Letter")
                    {
                        if (Type == "APA" || Type == "LBP" || Type== "LBPR" || Type == "APAR" || Type == "ADOPR" || Type == "SOPR" || Type == "STOPR" || Type == "SUOPR" || Type == "COPR" || Type == "COP" || Type == "AOPR" || Type == "AOP" || Type == "CC" || Type == "CCR" || Type == "OC" || Type == "OCR" || Type == "TEFR" || Type == "TEF" || Type == "SCR" || Type == "SC" || Type == "NMR" || Type == "NM" || Type == "TLDR" || Type == "TLD" || Type == "MOR" || Type == "MO" || Type == "NDCR" || Type == "NDC" || Type == "TR" || Type == "TRR" || Type == "RF" || Type == "RFR" || Type == "WC" || Type == "WCR" || Type == "RLF" || Type == "RLFR" || Type == "HLD" || Type == "HLDR" || Type == "ROPR" || Type == "ROP" || Type == "SOP" || Type == "ADOP" || Type == "SUOP" || Type == "STOP" || Type == "ODCR" || Type == "ODC" || Type == "LDER")
                        {


                            LinkButton bts = e.CommandSource as LinkButton;
                            FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;

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
                                }
                                if (contenttype != String.Empty)
                                {
                                    Stream fs = fu.PostedFile.InputStream;
                                    BinaryReader br = new BinaryReader(fs);
                                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                    objServiceTimelinesBEL.filename = filename;
                                    objServiceTimelinesBEL.content = contenttype;
                                    objServiceTimelinesBEL.Uploadfile = bytes;
                                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;
                                    objServiceTimelinesBEL.Doctype = Service;
                                    objServiceTimelinesBEL.Flag = Flag;

                                    try
                                    {

                                        int retVal = objServiceTimelinesBLL.UploadSignedCopyLetter(objServiceTimelinesBEL);
                                        if (retVal > 0)
                                        {


                                            if (Flag == "Completed")
                                            {
                                                Status_Code = "15";
                                                Remarks = "RM Approved Application and Issued NOC to | Applicant";
                                                NOC_Certificate_Number = SerReqNo;
                                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=" + DocType + "";
                                            }
                                            if (Flag == "Rejected")
                                            {
                                                Objection_Rejection_Code = gm.GetNMSWPRejectionID(SerReqNo);
                                                Status_Code = "07";
                                                Remarks = "RM Rejected Application and Issued Rejection Letter to | Applicant";
                                                NOC_Certificate_Number = SerReqNo;
                                                NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                                            }
                                            //string NMSWP_Result = gm.UpdateNOCStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status_Code, Remarks, NOC_URL, NOC_Certificate_Number, Request_ID, Objection_Rejection_Code);
                                            //string message = "File  Uploaded SucessFully ";
                                            //string script = "window.onload = function(){ alert('";
                                            //script += NMSWP_Result;
                                            //script += "')};";
                                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                                            BindGridView();
                                            DataSet ds = new DataSet();
                                            objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                                            objServiceTimelinesBEL.Doctype = Service;
                                            ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);

                                            DataTable dtDoc = ds.Tables[0];

                                            if (dtDoc != null)
                                            {

                                                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                                                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                                                ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                                            }
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

                                        string message = ex.ToString();
                                        string script = "window.onload = function(){ alert('";
                                        script += message;
                                        script += "')};";
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
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



                        else
                        {
                            SqlCommand cmd = new SqlCommand("GetNiveshMitraIDFromSerReqNo '" + SerReqNo + "'", con);
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                ControlID = dt.Rows[0]["ControlId"].ToString();
                                UnitID = dt.Rows[0]["UnitId"].ToString();
                                ServiceID = dt.Rows[0]["ServiceId"].ToString();
                                Request_ID = dt.Rows[0]["NMRequestID"].ToString();
                                AllotteeID = dt.Rows[0]["AllotteeID"].ToString();
                                status = dt.Rows[0]["Status"].ToString();
                                Reason = dt.Rows[0]["Reason"].ToString();
                                LinkButton bts = e.CommandSource as LinkButton;
                                FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;
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
                                    }
                                    if (contenttype != String.Empty)
                                    {
                                        Stream fs = fu.PostedFile.InputStream;
                                        BinaryReader br = new BinaryReader(fs);
                                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                        objServiceTimelinesBEL.filename = filename;
                                        objServiceTimelinesBEL.content = contenttype;
                                        objServiceTimelinesBEL.Uploadfile = bytes;
                                        objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;
                                        objServiceTimelinesBEL.Doctype = Service;
                                        objServiceTimelinesBEL.Flag = Flag;

                                        try
                                        {

                                            int retVal = objServiceTimelinesBLL.UploadSignedCopyLetter(objServiceTimelinesBEL);
                                            if (retVal > 0)
                                            {


                                                NOC_Certificate_Number = AllotteeID.Trim();
                                                NOC_URL = "";
                                                ISNOC_URL_ActiveYesNO = "Yes";

                                                if (ServiceID.Trim() == "SC21002" || ServiceID == "SC21003")
                                                {
                                                    if (Flag == "Completed")
                                                    {
                                                        Objection_Rejection_Code = "";
                                                        Status_Code = "15";
                                                        Remarks = "Building Plan Approval Process Completed.";
                                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=BuildingPlan";
                                                    }
                                                    if (Flag == "Rejected")
                                                    {
                                                        Objection_Rejection_Code = gm.GetNMSWPRejectionID(SerReqNo);
                                                        Status_Code = "07";
                                                        Remarks = "Application Rejected | Applicant";
                                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                                                    }
                                                }
                                                if (ServiceID.Trim() == "SC21001")
                                                {
                                                    if (Flag == "Completed")
                                                    {
                                                        NewAllotteeID = dt.Rows[0]["NewAllotteeID"].ToString();
                                                        Status_Code = "15";
                                                        Remarks = "Land Allotment Process Completed. Your AllotteeID is " + NewAllotteeID + ". Use this ID for application of building plan | Applicant";
                                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Allotment";
                                                    }
                                                    if (Flag == "Rejected")
                                                    {
                                                        Objection_Rejection_Code = gm.GetNMSWPRejectionID(SerReqNo);
                                                        Status_Code = "07";
                                                        Remarks = "Application Rejected | Applicant";
                                                        NOC_URL = "https://eservices.onlineupsidc.com/SignedLetterView.aspx?ServiceRequestNo=" + SerReqNo.Trim() + "&DocType=Rejection";
                                                    }
                                                }



                                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();

                                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                                ControlID,
                                                UnitID,
                                                ServiceID,
                                                ProcessIndustryID,
                                                ApplicationID,
                                                Status_Code,
                                                Remarks,
                                                "Applicant",
                                                Fee_Amount,
                                                Fee_Status,
                                                Transaction_ID,
                                                Transaction_Date,
                                                Transaction_Date_Time,
                                                NOC_Certificate_Number,
                                                NOC_URL,
                                                ISNOC_URL_ActiveYesNO,
                                                passsalt,
                                                Request_ID,
                                                Objection_Rejection_Code,
                                                "Yes",
                                                Certificate_EXP_Date_DDMMYYYY,
    D1,
    D2,
    D3,
    D4,
    D5,
    D6,
    D7
                                                );

                                                if (ServiceID == "SC21001")
                                                {
                                                    string Update2 = webService.WReturn_CUSID_ISLandPurchased(ControlID, UnitID, ServiceID, "Yes", passsalt);
                                                }

                                                string message = "File  Uploaded SucessFully ";
                                                string script = "window.onload = function(){ alert('";
                                                script += message;
                                                script += "')};";
                                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                                                BindGridView();
                                                DataSet ds = new DataSet();
                                                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                                                objServiceTimelinesBEL.Doctype = Service;
                                                ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);

                                                DataTable dtDoc = ds.Tables[0];

                                                if (dtDoc != null)
                                                {

                                                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                                                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                                                    ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                                                }


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

                                            string message = ex.ToString();
                                            string script = "window.onload = function(){ alert('";
                                            script += message;
                                            script += "')};";
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
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
                                else
                                {
                                    string message = "Please choose file to upload";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    return;
                                }


                            }

                        }


                    }
                    if (Service == "Map")
                    {
                        LinkButton bts = e.CommandSource as LinkButton;
                        FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;

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
                            }
                            if (contenttype != String.Empty)
                            {
                                Stream fs = fu.PostedFile.InputStream;
                                BinaryReader br = new BinaryReader(fs);
                                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                objServiceTimelinesBEL.filename = filename;
                                objServiceTimelinesBEL.content = contenttype;
                                objServiceTimelinesBEL.Uploadfile = bytes;
                                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;
                                objServiceTimelinesBEL.Doctype = Service;
                                objServiceTimelinesBEL.Flag = Flag;

                                try
                                {

                                    int retVal = objServiceTimelinesBLL.UploadSignedCopyLetter(objServiceTimelinesBEL);
                                    if (retVal > 0)
                                    {

                                        string message = "File  Uploaded SucessFully ";
                                        string script = "window.onload = function(){ alert('";
                                        script += message;
                                        script += "')};";
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                                        BindGridView();
                                        DataSet ds = new DataSet();
                                        objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                                        objServiceTimelinesBEL.Doctype = Service;
                                        ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);

                                        DataTable dtDoc = ds.Tables[0];

                                        if (dtDoc != null)
                                        {

                                            string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                                            string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                                            ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                                        }


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
                                string message = "File format not recognised." +
                                  " Upload PDF formats";
                                string script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                            }
                        }
                        else
                        {
                            string message = "Please choose file to upload";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.Doctype = Service.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer1.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&DocType=" + Service + ""));

                }

            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.Doctype = Service.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyLetter(objServiceTimelinesBEL);
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
            if (e.CommandName == "Delete")
            {
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo;


                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteSignedCopyLetter(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = " Document deleted successfully ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        BindGridView();
                    }
                    else
                    {
                        string message = "Document couldn't be deleted";
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
                + dt.Rows[0]["DocName"].ToString() + ".pdf");
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