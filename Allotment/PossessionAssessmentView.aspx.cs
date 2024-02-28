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
    public partial class PossessionAssessmentView : System.Web.UI.Page
    {

        #region "Create and Initialize objects"
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        GeneralMethod gm = new GeneralMethod();
        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";


        public string Level = "";
        public string DataManager = "";


        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Form.Enctype = "multipart/form-data";
            try
            {
                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                    if (DataManager == "Data Approver")
                    {

                        SqlCommand cmd1 = new SqlCommand("service_request_track '" + ServiceReqNo + "'", con);
                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        DataSet ds = new DataSet();
                        adp1.Fill(ds);
                        dt1 = ds.Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            string role = dt1.Rows[0]["role"].ToString().Trim();
                            string inbound = dt1.Rows[0]["inbound"].ToString().Trim();
                            if (role == "RM")
                            {

                                if (inbound == "NO")
                                {

                                }

                            }
                        }
                    }

                }
                string[] SerIdarray = ServiceReqNo.Split('/');

                //SqlCommand cmd2 = new SqlCommand("Select ControlId,UnitId,ServiceId from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
                //SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                //DataTable dt2 = new DataTable();
                //adp2.Fill(dt2);
                //if (dt2.Rows.Count > 0)
                //{
                //    ViewState["ControlID"] = dt2.Rows[0]["ControlId"].ToString();
                //    ViewState["UnitID"]    = dt2.Rows[0]["UnitId"].ToString();
                //    ViewState["ServiceID"] = dt2.Rows[0]["ServiceId"].ToString();
                //}
            }
            catch (Exception ex) { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {


                ddlApplicant.Items.Insert(0, new ListItem(ServiceReqNo, ServiceReqNo));


                ServiceReqNo = ddlApplicant.SelectedValue;

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
            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string RODate = dt.Rows[0]["DateOFAppointmentRO"].ToString();
            string SiteInspection = dt.Rows[0]["InspectionReport"].ToString();
            string Tracing = dt.Rows[0]["PlotTracing"].ToString();
            string GMIDC = dt.Rows[0]["GMIDCLetter"].ToString();
            string LeaseRegistered = dt.Rows[0]["LeaseDeedRegistered"].ToString();
            string PossessionCompleted = dt.Rows[0]["PossessionCompleted"].ToString();


            sub_menu.Items.Clear();

            switch (ServiceID.ToString())
            {

                case "1001":
                    {
                        ////////  Plot Allotement 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details", Text = "Payment Details" });
                        if (Level == "RM" || Level == "JE")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Appointment_Detail", Text = "Appointment Detail" });
                        }


                        sub_menu.Items.Add(new MenuItem { Value = "page|View_POA", Text = "POA Details" });

                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Apphistory", Text = "Process History" });

                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|SiteInspection", Text = "Site Inspection Report" });
                        }
                        if (Tracing.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|PlotTracing", Text = "Plot Tracing" });
                        }
                        if (GMIDC.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|GMIDC", Text = "GMIDC Letter" });
                        }
                        if (LeaseRegistered == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|RegisteredLease", Text = "Registered Lease Deed" });
                        }
                        if (PossessionCompleted == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|PossessionMemo", Text = "Possession Memo" });
                        }

                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {
                        //////////////   Other ////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });

                        sub_menu.DataBind();
                        break;
                    }

            }


        }

        protected void LeaseDocViewer(int I)
        {



            SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo = '" + ServiceReqNo + "' and ServiceID = 1001 and DocType = 'Registered Lease'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {

                string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(embed, ResolveUrl("/DocViewerRegisteredLease.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&Type=" + I + ""));
                Placeholder.Controls.Add(ltEmbed);
            }

        }
        protected void PossessionDocViewer(int I)
        {



            SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo = '" + ServiceReqNo + "' and ServiceID = 1001 and DocType = 'Possession Memo'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {

                string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(embed, ResolveUrl("/DocViewerPossession.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&Type=" + I + ""));
                Placeholder.Controls.Add(ltEmbed);
            }

        }

        protected void SiteDocViewer(int I)
        {



            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {

                string contype = dtDoc.Rows[0]["PlotTracingContent"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(embed, ResolveUrl("/DocViewerLease.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&Type=" + I + ""));
                Placeholder.Controls.Add(ltEmbed);
            }

        }
        protected void DocumentViewer()
        {

            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNO='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {



                string contype = dtDoc.Rows[0]["LetterContent"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(embed, ResolveUrl("/GMIDCDocViewer.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + ""));
                Placeholder.Controls.Add(ltEmbed);
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
            if ((string)ViewState["sub_menu"] != string_val)
            {

            }

            foreach (MenuItem item in sub_menu.Items)
            {
                if (string_text == item.Text)
                {
                    item.Selected = true;
                }
            }


            load_UC("ALL");




        }




        #endregion

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

                if (Menu_Value1 == "GMIDC")
                {
                    DocumentViewer();
                }
                if (Menu_Value1 == "SiteInspection")
                {
                    SiteDocViewer(2);
                }
                if (Menu_Value1 == "PlotTracing")
                {
                    SiteDocViewer(1);
                }
                if (Menu_Value1 == "RegisteredLease")
                {
                    LeaseDocViewer(1);
                }
                if (Menu_Value1 == "PossessionMemo")
                {
                    PossessionDocViewer(1);
                }
            }

            if (Menu_Type == "page")
            {

                if (Menu_Value1 == "Allottee_Detail")
                {
                    UC_Service_Allotteee_Detail_Lease UC_Service_Allotteee_Detail_Lease = LoadControl("~/UC_Service_Allotteee_Detail_Lease.ascx") as UC_Service_Allotteee_Detail_Lease;
                    UC_Service_Allotteee_Detail_Lease.AllotteeId = ApplicantId.ToString();
                    UC_Service_Allotteee_Detail_Lease.ID = "UC_Service_Allotteee_Detail_Lease_ID";
                    UC_Service_Allotteee_Detail_Lease.ServiceReqNo = ServiceReqNo;
                    // UC_Service_Allotteee_Detail.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Service_Allotteee_Detail_Lease);
                }
                if (Menu_Value1 == "Appointment_Detail")
                {
                    UC_Appontments UC_Appontments = LoadControl("~/UC_Appontments.ascx") as UC_Appontments;
                    UC_Appontments.ID = "UC_Appontments";
                    UC_Appontments.ServiceReqNo = ServiceReqNo;
                    //UC_Appontments.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Appontments);
                }
                if (Menu_Value1 == "Comments_Detail")
                {
                    UC_CommentsBT UC_CommentsBT = LoadControl("~/UC_CommentsBT.ascx") as UC_CommentsBT;
                    UC_CommentsBT.ID = "UC_CommentsBT";
                    UC_CommentsBT.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_CommentsBT);


                }
                if (Menu_Value1 == "Apphistory")
                {
                    UC_ApplicationStatusHistoryLease UC_ApplicationStatusHistoryLease = LoadControl("~/UC_ApplicationStatusHistoryLease.ascx") as UC_ApplicationStatusHistoryLease;
                    UC_ApplicationStatusHistoryLease.ID = "UC_ApplicationStatusHistoryLease";
                    UC_ApplicationStatusHistoryLease.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_ApplicationStatusHistoryLease);


                }
                if (Menu_Value1 == "Select_POA")
                {
                    SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeLeaseDeed '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    string IAID = dt.Rows[0]["IAID"].ToString();
                    UC_ListOfPOA UC_ListOfPOA = LoadControl("~/UC_ListOfPOA.ascx") as UC_ListOfPOA;
                    UC_ListOfPOA.ID = "UC_Appontments";
                    UC_ListOfPOA.ServiceReqNo = ServiceReqNo;
                    UC_ListOfPOA.IAIDs = IAID;
                    // UC_ListOfPOA.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ListOfPOA);
                }
                if (Menu_Value1 == "View_POA")
                {
                    SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeLeaseDeed '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    string IAID = dt.Rows[0]["IAID"].ToString();
                    UC_ViewPOA UC_ViewPOA = LoadControl("~/UC_ViewPOA.ascx") as UC_ViewPOA;
                    UC_ViewPOA.ID = "UC_ViewPOA";
                    UC_ViewPOA.ServiceReqNo = ServiceReqNo;
                    UC_ViewPOA.IAIDs = IAID;
                    // UC_ListOfPOA.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ViewPOA);
                }


                if (Menu_Value1 == "Payment_Details")
                {
                    SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeLeaseDeed '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    string Applicantname = dt.Rows[0]["ApplicantName"].ToString();
                    string Address = dt.Rows[0]["Address"].ToString();
                    string IAID = dt.Rows[0]["IAID"].ToString();
                    string PlotArea = dt.Rows[0]["PlotArea"].ToString();
                    string CoveredArea = dt.Rows[0]["CoveredArea"].ToString();
                    string AllottmentNo = dt.Rows[0]["Allotmentletterno"].ToString();
                    string ControlID = dt.Rows[0]["ControlId"].ToString();
                    string UnitID = dt.Rows[0]["UnitId"].ToString();
                    string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                    string TraID = dt.Rows[0]["LATraID"].ToString();


                    UC_IAServiceProcessFee UC_IAServiceProcessFee = LoadControl("~/UC_IAServiceProcessFee.ascx") as UC_IAServiceProcessFee;
                    UC_IAServiceProcessFee.IndustrialArea = Convert.ToInt32(IAID);
                    UC_IAServiceProcessFee.choicearea = Convert.ToDouble(PlotArea);
                    UC_IAServiceProcessFee.CoveredArea = CoveredArea;
                    UC_IAServiceProcessFee.AllotmentLetterNo = AllottmentNo;
                    UC_IAServiceProcessFee.SWCControlID = SWCControlID;
                    UC_IAServiceProcessFee.SWCUnitID = SWCUnitID;
                    UC_IAServiceProcessFee.SWCServiceID = SWCServiceID;
                    UC_IAServiceProcessFee.ServiceRequestNo = ServiceReqNo;
                    UC_IAServiceProcessFee.TranID = TraID;
                    UC_IAServiceProcessFee.ApplicantName = Applicantname;
                    UC_IAServiceProcessFee.applicantAddress = Address;
                    Placeholder.Controls.Add(UC_IAServiceProcessFee);

                }
                if (Menu_Value1 == "SendApplication")
                {
                    SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeLeaseDeed '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    string IAIDs = dt.Rows[0]["IAID"].ToString();
                    UC_ProcessApplicationService UC_ProcessApplicationService = LoadControl("~/UC_ProcessApplicationService.ascx") as UC_ProcessApplicationService;
                    UC_ProcessApplicationService.ID = "UC_ProcessApplicationService";
                    UC_ProcessApplicationService.ServiceReqNo = ServiceReqNo;
                    UC_ProcessApplicationService.IAID = IAIDs;
                    UC_ProcessApplicationService.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ProcessApplicationService);
                }

                if (Menu_Value1 == "Appointment")
                {
                    UC_CreateAppointments UC_CreateAppointments = LoadControl("~/UC_CreateAppointments.ascx") as UC_CreateAppointments;
                    UC_CreateAppointments.ID = "UC_CreateAppointments";
                    UC_CreateAppointments.ServiceReqNo = ServiceReqNo;

                    UC_CreateAppointments.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_CreateAppointments);
                }
                if (Menu_Value1 == "JE_Doc")
                {
                    UC_JEDocUpload UC_JEDocUpload = LoadControl("~/UC_JEDocUpload.ascx") as UC_JEDocUpload;
                    UC_JEDocUpload.ID = "UC_JEDocUpload";
                    UC_JEDocUpload.ServiceReqNo = ServiceReqNo;

                    UC_JEDocUpload.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_JEDocUpload);
                }
                if (Menu_Value1 == "UploadLease")
                {
                    UC_DAUploadLease UC_DAUploadLease = LoadControl("~/UC_DAUploadLease.ascx") as UC_DAUploadLease;
                    UC_DAUploadLease.ID = "UC_DAUploadLease";
                    UC_DAUploadLease.ServiceReqNo = ServiceReqNo;

                    UC_DAUploadLease.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_DAUploadLease);
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




        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }


        //private void SendMailUPSIDC()
        //{

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("select * from ApplicationRegister where ApplicationId='" + ServiceReqNo + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            string ApplicantName  = dt.Rows[0]["ApplicantName"].ToString();
        //            string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
        //            string PhoneNo        = dt.Rows[0]["PhoneNo"].ToString();
        //            string TempID         = dt.Rows[0]["TempApplicationID"].ToString();


        //          MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
        //            MailAddress mailto   = new MailAddress("priyu.7nov@gmail.com");
        //            MailMessage newmsg   = new MailMessage(mailfrom, mailto);

        //            newmsg.IsBodyHtml = true;
        //            string StrContent = "";
        //            StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
        //            StrContent = reader.ReadToEnd();

        //            StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
        //            StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application is marked for clarification.Kindly check and resubmit your application with proper documents and information");
        //            StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LandAllotmentApplication.aspx?ServiceReqNo=" + TempID + "&App=Resubmit");



        //            newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Land Allotment ";
        //            newmsg.Body = StrContent;


        //            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //            smtp.UseDefaultCredentials = false;
        //            smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
        //            smtp.EnableSsl = true;
        //            smtp.Send(newmsg);


        //            string resultmsg = "";

        //            String message = HttpUtility.UrlEncode("Dear Applicant Your Application has been sent to you for resubmission kindly resubmit your application with proper documents and information.Link has been send to your registered mailid");
        //            using (var wb = new WebClient())
        //            {
        //                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
        //                                {
        //                                {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
        //                                {"numbers" , "7275379286"},
        //                                {"message" , message}
        //                //              {"sender" , "UPSIDC"}
        //                                });
        //                resultmsg = System.Text.Encoding.UTF8.GetString(response);

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void SendMailUPSIDCBuildingPlan()
        //{

        //    try
        //    {
        //        string[] SerIdarray = ServiceReqNo.Split('|');
        //        SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            string ApplicantName  = dt.Rows[0]["AllotteeName"].ToString();
        //            string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
        //            string PhoneNo        = dt.Rows[0]["PhoneNo"].ToString();



        //          MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
        //            MailAddress mailto = new MailAddress("priyu.7nov@gmail.com");
        //            MailMessage newmsg = new MailMessage(mailfrom, mailto);

        //            newmsg.IsBodyHtml = true;
        //            string StrContent = "";
        //            StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
        //            StrContent = reader.ReadToEnd();

        //            StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
        //            StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application for building plan approval is marked for clarification.Kindly check and resubmit your application with proper documents and information");
        //            StrContent = StrContent.Replace("{Link}", "");



        //            newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Land Allotment ";
        //            newmsg.Body = StrContent;


        //            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //            smtp.UseDefaultCredentials = false;
        //            smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
        //            smtp.EnableSsl = true;
        //            smtp.Send(newmsg);


        //            string resultmsg = "";

        //            String message = HttpUtility.UrlEncode("Dear Applicant Your Application for building plan has been sent to you for resubmission kindly resubmit your application with proper documents and information");
        //            using (var wb = new WebClient())
        //            {
        //                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
        //                                {
        //                                {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
        //                                {"numbers" , "7275379286"},
        //                                {"message" , message}
        //                //              {"sender" , "UPSIDC"}
        //                                });
        //                resultmsg = System.Text.Encoding.UTF8.GetString(response);

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
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


        public void Redirect(string Par, string ID)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Redirect('" + Par + "','" + ServiceReqNo + "','" + ID + "');", true);
        }
        public void AllertRedirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + Par + "');", true);
        }
    }
}