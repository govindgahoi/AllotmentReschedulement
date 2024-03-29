﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class NewAssessmentApproval : System.Web.UI.Page
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
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;

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

            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

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
                    if (DataManager == "Data Approver")
                    {
                        btnClarify.Visible = true;
                        btnReject.Visible = true;
                        btnApprove.Visible = true;
                    }

                }


            }
            catch { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {
                drpRemarks.Text = string.Empty;
                drp_Doc_Status_Save.SelectedIndex = 0;

                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
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
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application", Text = "Process Application" });

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
            gridRequestDoc_Status.DataBind();
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
                drpRemarks.Text = "";
            }



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

        #region DocumentReletedProcessing&View

        protected void GET_ServiceRequestDoc_Status(string ServiceReqNo, string ServiceCheckListsID)
        {
            gridRequestDoc_Status.DataBind();

            SqlCommand cmd = new SqlCommand("GET_ServiceRequestProcessDoc  '" + ServiceReqNo + "'," + ServiceCheckListsID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridRequestDoc_Status.DataSource = dt;
                gridRequestDoc_Status.DataBind();

            }
            else
            {
                gridRequestDoc_Status.DataSource = null;
                gridRequestDoc_Status.DataBind();
            }

        }



        protected void DocumentViewer(string DocumentID)
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.DocumentID = DocumentID;
            ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""500px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=&ServiceCheckListsID=&ServiceTimeLinesID=&DocId=" + DocumentID + "")));

                //    Placeholder.Controls.Clear();
                Placeholder.Controls.Add(ltEmbed);
            }


        }



        protected void btn_Doc_Status_Save_Click(object sender, EventArgs e)
        {
            string[] SerIdarray = ((string)ViewState["sub_menu"]).Split('|');
            string Menu_Type = "";
            string ServiceCheckListsID = "";
            string doc_id = "";

            try
            {
                Menu_Type = SerIdarray[0];
                ServiceCheckListsID = SerIdarray[1];
                doc_id = SerIdarray[2];

            }
            catch { }


            if (ServiceCheckListsID == "")
            {
                MessageBox1.ShowWarning("Error Not Found Correct Checklist Id");
                return;
            }


            if (Menu_Type == "doc" && ServiceCheckListsID.Length > 0)
            {

                if (drp_Doc_Status_Save.SelectedValue.Trim() == "2")
                {
                    MessageBox1.ShowInfo("Please Select Status Dropdown !");
                    return;
                }
                else
                {
                    try { con.Open(); } catch { }
                    try
                    {
                        SqlCommand command = con.CreateCommand();
                        command.Connection = con;
                        command.CommandText = ("Set_ServiceRequestProcessDocnew  '" + ServiceReqNo + "', " + ServiceCheckListsID + " ,  '" + doc_id + "' , " + UserId + ", " + drp_Doc_Status_Save.SelectedValue.Trim() + " ,  '" + drpRemarks.Text.Trim() + "'");
                        if (command.ExecuteNonQuery() > 0)
                        {
                            MessageBox1.ShowSuccess("Updated successfully");

                            GET_ServiceRequestDoc_Status(ServiceReqNo, ServiceCheckListsID);

                        }
                        else
                        {
                            MessageBox1.ShowSuccess("Error Occured !");
                            return;
                        }
                    }
                    catch (Exception ex) { MessageBox1.ShowError(ex.Message.ToString()); }
                    finally
                    {

                        drpRemarks.Text = string.Empty;
                        drp_Doc_Status_Save.SelectedIndex = 0;
                        con.Close();
                    }
                }
            }
            else
            {

            }

        }

        #endregion



        protected void load_UC(string AllOrFirst)
        {

            Placeholder.Controls.Clear();
            div_doc_status.Visible = false;


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
                    ///div_doc_status.Visible = true;
                }

                if (Menu_Value1 == "Marking_Detail")
                {
                    EvaluationSheet UC_EvaluationSheet = LoadControl("~/EvaluationSheet.ascx") as EvaluationSheet;
                    UC_EvaluationSheet.ID = "UC_EvaluationSheet";

                    UC_EvaluationSheet.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_EvaluationSheet);
                    ///div_doc_status.Visible = true;
                }

                if (Menu_Value1 == "Comments_Detail")
                {
                    UC_Comments UC_Comments = LoadControl("~/UC_Comments.ascx") as UC_Comments;
                    UC_Comments.ID = "UC_Comments";

                    UC_Comments.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_Comments);
                    ///div_doc_status.Visible = true;
                }

                if (Menu_Value1 == "Process_Application")
                {
                    UC_ProcessApplicationApproval UC_ProcessApplicationApproval = LoadControl("~/UC_ProcessApplicationApproval.ascx") as UC_ProcessApplicationApproval;
                    UC_ProcessApplicationApproval.ID = "UC_ProcessApplicationApproval";

                    UC_ProcessApplicationApproval.ServiceReqNo = ServiceReqNo;
                    UC_ProcessApplicationApproval.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ProcessApplicationApproval);
                    ///div_doc_status.Visible = true;
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
        public void AllertRedirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + Par + "');", true);

            // MessageBox1.ShowSuccess("Hello");
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

    }
}