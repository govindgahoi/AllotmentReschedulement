using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class NewAssessmentUnderProcessApp : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail;
        UC_Service_Applicant_Detail UC_Service_Applicant_Detail;
        //UC_Assesment_Entry_AllotmentNew UC_Assesment_Entry_AllotmentNew;
        UC_Assesment_Entry_BP UC_Assesment_Entry_BP;
        UC_Assesment_Entry_Inspection UC_Assesment_Entry_Inspection;
        EvaluationSheet UC_EvaluationSheet;


        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0,
            PacketId = 0;

        public string DataFactsModel_open = "";
        public string TicketStatus = "";
        public string TicketFor = "";
        public string TicketId = "";
        public string Level = "";
        public string DataManager = "";
        public int PacketID;

        #endregion


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();

                }


            }
            catch { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {

                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
                ddlApplicant.Items.Insert(0, new ListItem(ServiceReqNo, ServiceReqNo));


                ServiceReqNo = ddlApplicant.SelectedValue;

                SqlCommand cmd2 = new SqlCommand("Select SWCControlId,SWCUnitId,SWCServiceId,case when datediff(day,(DATEADD(DAY, 7 - DATEPART(WEEKDAY, FinalSubmissionDate), CAST(FinalSubmissionDate AS DATE))),GetDate())>0 then 'Open' else 'Close' end 'Status' from ApplicationRegister where ApplicationID='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    string status = dt2.Rows[0]["Status"].ToString();
                    if (UserName != "Admin1")
                    {
                        if (status == "Close")
                        {
                            Response.Redirect("ServiceRequestUnderProcess_CMIA.aspx", false);
                        }
                    }

                }
                string[] SerArray = ServiceReqNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);
                ApplicantId = int.Parse(SerArray[2]);

                ddlApplicant_SelectedIndexChanged(null, null);   // also call  MenuMaker();
                sub_menu_MenuItemClick(null, null);




            }






            ServiceReqNo = (Request.QueryString["ServiceReqNo"]);



            ServiceReqNo = ddlApplicant.SelectedValue;
            string[] SerArray1 = ServiceReqNo.Split('/');
            ServiceID = int.Parse(SerArray1[1]);
            ApplicantId = int.Parse(SerArray1[2]);



            load_UC("ALL");

        }



        #region LeftMenu
        protected void MenuMaker()
        {
            sub_menu.Items.Clear();

            switch (ServiceID.ToString())
            {

                case "1000":
                    {
                        ////////  Plot Allotement 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });

                        CheklistBind(1000, ServiceReqNo);

                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Marking_Verification", Text = "Verify Markings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Marking_Detail", Text = "View Evaluation Sheet" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|Minutes", Text = "View Committee Minutes" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|CoverLetter", Text = "View Cover Letter" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|HeadOfficeMinutes", Text = "View HeadOffice Minutes" });
                        //  sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application", Text = "Process Application" });

                        break;
                    }


                case "4":
                    {
                        //////// Plot Transfer 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Transferor Detail" });
                        CheklistBind(4, ServiceReqNo);

                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Transfree Detail", NavigateUrl = "" });
                        CheklistBind(1000, ServiceReqNo);

                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {
                        //////////////   Other 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        CheklistBind(ServiceID, ServiceReqNo);

                        sub_menu.DataBind();
                        break;
                    }

            }


        }


        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {

            string string_val = "";
            string string_text = "";

            try
            {

                string_val = (e.Item.Value.Trim());
                string_text = (e.Item.Text);
            }
            catch
            {
                string_val = sub_menu.Items[0].Value;
                string_text = sub_menu.Items[0].Text;
            }


            ViewState["sub_menu"] = string_val;
            ViewState["sub_menu_text"] = string_text;


            string[] SerIdarray = string_val.Split('|');




            foreach (MenuItem item in sub_menu.Items)
            {
                if (string_text == item.Text)
                {
                    item.Selected = true;
                }
            }


            load_UC("First");

        }



        protected void CheklistBind(int ServiceID, string ServicereqNo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new GeneralMethod().EvaluationCheklistBind(ServiceID, ServicereqNo);

                int UniqueNo = ServiceID;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //   UniqueNo++;
                        string Menu_Text = dr["ServiceTimeLinesDocuments"].ToString().Trim();
                        string ServiceCheckListsID = (dr["ServiceCheckListsID"].ToString().Trim()).Trim();

                        string Menu_Val = "doc|" + ServiceCheckListsID + "|" + (dr["DocumentID"].ToString().Trim()).Trim();
                        sub_menu.Items.Add(new MenuItem { Value = Menu_Val, Text = Menu_Text });
                    }
                }
            }


            catch { }
        }



        #endregion




        protected void DocumentViewer(string DocumentID)
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.DocumentID = DocumentID;
            ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=&ServiceCheckListsID=&ServiceTimeLinesID=&DocId=" + DocumentID + "")));

                //    Placeholder.Controls.Clear();
                Placeholder.Controls.Add(ltEmbed);
            }


        }









        protected void load_UC(string AllOrFirst)
        {

            Placeholder.Controls.Clear();



            string string_val = (string)ViewState["sub_menu"];
            string[] SerIdarray = string_val.Split('|');
            string Menu_Type = "";
            string Menu_Value1 = "";
            string Menu_Value2 = "";

            try
            {

                Menu_Type = SerIdarray[0];
                Menu_Value1 = SerIdarray[1];
                Menu_Value2 = SerIdarray[2];

            }
            catch (Exception ex)
            {

            }


            if (Menu_Type == "doc")
            {
                if (Menu_Value1 == "Minutes")
                {
                    InspectionfreportViewer();
                }
                else if (Menu_Value1 == "CoverLetter")
                {
                    CoverLetterViewer();
                }
                else if (Menu_Value1 == "HeadOfficeMinutes")
                {
                    HeadOfficeMinutesViewer();
                }
                else
                {

                    string ServiceCheckListsID = Menu_Value1;
                    string doc_id = Menu_Value2;



                    if (doc_id.Length > 0)
                    {
                        DocumentViewer(doc_id);
                    }
                    else
                    {
                        Literal ltEmbed = new Literal();
                        ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                        Placeholder.Controls.Add(ltEmbed);
                    }
                }
            }




            if (Menu_Type == "page")
            {

                if (Menu_Value1 == "Allottee_Detail")
                {
                    UC_Service_Allotteee_Detail = LoadControl("~/UC_Service_Allotteee_Detail.ascx") as UC_Service_Allotteee_Detail;
                    UC_Service_Allotteee_Detail.AllotteeId = ApplicantId.ToString();
                    UC_Service_Allotteee_Detail.ID = "UC_Service_Allotteee_DetailID";
                    Placeholder.Controls.Add(UC_Service_Allotteee_Detail);
                }

                if (Menu_Value1 == "Applicant_Detail")
                {
                    UC_ApplicationFinalViewInternal UC_ApplicationFinalViewInternal = LoadControl("~/UC_ApplicationFinalViewInternal.ascx") as UC_ApplicationFinalViewInternal;
                    UC_ApplicationFinalViewInternal.ID = "UC_ApplicationFinalViewInternalID";

                    UC_ApplicationFinalViewInternal.ServiceRequestNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewInternal);

                }

                if (Menu_Value1 == "Marking_Detail")
                {
                    EvaluationSheet UC_EvaluationSheet = LoadControl("~/EvaluationSheet.ascx") as EvaluationSheet;
                    UC_EvaluationSheet.ID = "UC_EvaluationSheet";

                    UC_EvaluationSheet.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_EvaluationSheet);

                }

                if (Menu_Value1 == "Comments_Detail")
                {
                    UC_Comments UC_Comments = LoadControl("~/UC_Comments.ascx") as UC_Comments;
                    UC_Comments.ID = "UC_Comments";

                    UC_Comments.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_Comments);

                }
                if (Menu_Value1 == "Marking_Verification")
                {
                    UC_MarkingsVerification UC_MarkingsVerification = LoadControl("~/UC_MarkingsVerification.ascx") as UC_MarkingsVerification;
                    UC_MarkingsVerification.ID = "UC_MarkingsVerification";

                    UC_MarkingsVerification.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_MarkingsVerification);
                }

            }

        }

        protected void HeadOfficeMinutesViewer()
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            ds = objServiceTimelinesBLL.GetHeadOfficeMinute(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {
                if (dtDoc.Rows[0]["HeadOfficeCommitteeDoc"].ToString().Length > 0)
                {

                    string contype = dtDoc.Rows[0]["HeadOfficeCommitteeDocType"].ToString().Trim();

                    string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerHeadMinutes.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "")));

                    //    Placeholder.Controls.Clear();
                    Placeholder.Controls.Add(ltEmbed);
                }
                else
                {
                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                    Placeholder.Controls.Add(ltEmbed);
                }
            }
        }
        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue);

            ServiceReqNo = ddlApplicant.SelectedValue.Trim();
            MenuMaker();
            sub_menu.Items[0].Selected = true;
        }


        protected void InspectionfreportViewer()
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            ds = objServiceTimelinesBLL.GetInspectionReport(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();

                    string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerMinutes.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "")));

                    //    Placeholder.Controls.Clear();
                    Placeholder.Controls.Add(ltEmbed);
                }
                else
                {
                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                    Placeholder.Controls.Add(ltEmbed);
                }
            }
        }


        protected void CoverLetterViewer()
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            ds = objServiceTimelinesBLL.GetCoverLetter(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {
                if (dtDoc.Rows[0]["CoverLetter"].ToString().Length > 0)
                {

                    string contype = dtDoc.Rows[0]["CoverContentType"].ToString().Trim();

                    string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerCoverLetter.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "")));

                    //    Placeholder.Controls.Clear();
                    Placeholder.Controls.Add(ltEmbed);
                }
                else
                {
                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                    Placeholder.Controls.Add(ltEmbed);
                }
            }
        }


    }
}