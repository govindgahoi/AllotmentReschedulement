
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
//using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class BuildingPlanAssessment : System.Web.UI.Page
    {

        #region "Create and Initialize objects"
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;


        public string DataFactsModel_open = "";
        public string TicketStatus = "";
        public string TicketFor = "";
        public string TicketId = "";
        public string Level = "";
        public string DataManager = "";
        public int PacketID;


        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
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
                        btnClarifyM.Visible = true;
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
                                btnRejectM.Visible = true;
                                if (inbound == "NO")
                                {
                                    btnApprove.Visible = true;
                                }

                            }
                        }
                    }

                }
                string[] SerIdarray = ServiceReqNo.Split('/');

                SqlCommand cmd2 = new SqlCommand("Select ControlId,UnitId,ServiceId,NMRequestID from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
                SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    ViewState["ControlID"] = dt2.Rows[0]["ControlId"].ToString();
                    ViewState["UnitID"] = dt2.Rows[0]["UnitId"].ToString();
                    ViewState["ServiceID"] = dt2.Rows[0]["ServiceId"].ToString();
                    ViewState["RequestID"] = dt2.Rows[0]["NMRequestID"].ToString();
                }
            }
            catch (Exception ex) { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {
                drpRemarks.Text = string.Empty;
                drp_Doc_Status_Save.SelectedIndex = 0;


                ddlApplicant.Items.Insert(0, new ListItem(ServiceReqNo, ServiceReqNo));


                ServiceReqNo = ddlApplicant.SelectedValue;

                string[] SerArray = ServiceReqNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);
                ApplicantId = int.Parse(SerArray[2]);

                ddlApplicant_SelectedIndexChanged(null, null);   // also call  MenuMaker();
                sub_menu_MenuItemClick(null, null);

                BindNMObjectionType();


            }
            ControlCheck();
            ServiceReqNo = (Request.QueryString["ServiceReqNo"]);

            ServiceReqNo = ddlApplicant.SelectedValue;
            string[] SerArray1 = ServiceReqNo.Split('/');
            ServiceID = int.Parse(SerArray1[1]);
            ApplicantId = int.Parse(SerArray1[2]);

            load_UC("ALL");
         

    }



        private void ControlCheck()
        {
            string[] SerIdarray = ServiceReqNo.Split('/');

            SqlCommand cmd2 = new SqlCommand("Select TotalAllottedplotArea from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                decimal PlotArea = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                if (PlotArea >= 25000)
                {
                    if (Level == "RM")
                    {
                        SqlCommand cmd = new SqlCommand("GetStatusForApprovalATP '" + ServiceReqNo.Trim() + "'", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string status = dt.Rows[0][0].ToString();
                            if (status == "Show Approve")
                            {
                                btnRejectM.Visible = false;
                                btnApprove.Visible = true;
                            }
                            else
                            {
                                btnRejectM.Visible = true;
                                btnApprove.Visible = false;

                            }
                        }
                    }
                    else
                    {
                        btnRejectM.Visible = false;
                        btnApprove.Visible = false;
                    }
                }
                else
                {
                    if (Level == "RM")
                    {
                        btnRejectM.Visible = true;
                        btnApprove.Visible = true;
                    }
                }
            }

        }


        private void BindNMObjectionType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_GetNMobjectionType] '" + ViewState["ServiceID"].ToString() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    drp_NMObjectionType.DataSource = dt;
                    drp_NMObjectionType.DataTextField = "Reason_Details";
                    drp_NMObjectionType.DataValueField = "Reson_ID";
                    drp_NMObjectionType.DataBind();
                    drp_NMObjectionType.Items.Insert(0, new ListItem("--Select--", "0"));

                }

            }
            catch (Exception)
            {

                throw;
            }

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
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application", Text = "Process Application -->" });
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

                case "1":
                    {
                        //////// BuildingPlan //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail|", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Documents|", Text = "Documents" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Architect_Details|", Text = "Architect Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Building_Details|", Text = "Building Specification" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport",   Text = "View InspectionReport" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        sub_menu.DataBind();
                        break;
                    }
                case "2":
                    {
                        //////// BuildingPlan //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail|", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Documents|", Text = "Documents" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Architect_Details|", Text = "Architect Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Building_Details|", Text = "Building Specification" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "View InspectionReport" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        sub_menu.DataBind();
                        break;
                    }
                case "3":
                    {
                        //////// BuildingPlan //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail|", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Documents|", Text = "Documents" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Architect_Details|", Text = "Architect Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Building_Details|", Text = "Building Specification" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "View InspectionReport" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {
                        //////////////   Other ////
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


            load_UC("ALL");




        }



        protected void CheklistBind(int ServiceID, string ServicereqNo)
        {
            try
            {
                string Menu_Val = "";
                DataTable dt = new DataTable();
                dt = new GeneralMethod().EvaluationCheklistBuildingPlan(ServiceID, ServicereqNo);

                int UniqueNo = ServiceID;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //   UniqueNo++;
                        string Menu_Text = dr["ServiceTimeLinesDocuments"].ToString().Trim();
                        string ServiceCheckListsID = (dr["ServiceCheckListsID"].ToString().Trim()).Trim();

                        Menu_Val = "doc|" + ServiceCheckListsID + "|" + (dr["DocumentID"].ToString().Trim()).Trim();


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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("validatemarkings '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dss = new DataSet();
            adp.Fill(dss);
            DataTable dt1 = dss.Tables[1];
            if (dt1.Rows[0][0].ToString() == "NotUploaded")
            {
                MessageBox1.ShowInfo("Cannot Approve JE Site Inspection Report Is Missing");
                return;
            }
            else
            {
                Response.Redirect("~/ReportGenration.aspx?ServiceReqNo=" + ServiceReqNo, false);
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtReasonForRejection.Text == "")
                {
                    MessageBox1.ShowError("Please Enter Reason For Rejection");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowRejectModal();", true);
                    return;
                }

                string return_string = "";

                try { con.Open(); } catch { }

                SqlCommand cmd = new SqlCommand("RejectApplicationNewSp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);
                cmd.Parameters.AddWithValue("@RejectedBY", UserName.Trim());
                cmd.Parameters.AddWithValue("@Role", DataManager.Trim());
                cmd.Parameters.AddWithValue("@Remarks", txtReasonForRejection.Text.Trim());




                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + return_string + "');", true);

                }
                else
                {
                    return_string = "Opration Failed";
                    MessageBox1.ShowError(return_string);
                }


            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.Message.ToString());
            }
            finally
            {
                con.Close();
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

        protected void btnClarify_Click(object sender, EventArgs e)
        {
            try
            {
                if (drp_NMObjectionType.SelectedValue.Trim() == "0")
                {
                    MessageBox1.ShowError("Please choose nivesh mitra objection type");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowClarificationModal();", true);
                    return;
                }
                if (txtClarification.Text == "")
                {
                    MessageBox1.ShowError("Please Enter Clarification Required From Applicant");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowClarificationModal();", true);
                    return;
                }

                string return_string = "";

                try { con.Open(); } catch { }



                if (ViewState["ControlID"].ToString().Length > 0)
                {
                    SWCControlID = ViewState["ControlID"].ToString();
                    SWCUnitID = ViewState["UnitID"].ToString();
                    SWCServiceID = ViewState["ServiceID"].ToString();
                    Request_ID = ViewState["RequestID"].ToString();
                    Status_Code = "08";
                    Remarks = txtClarification.Text.Trim() + " | Applicant";


                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    string Update_Result = webService.WReturn_CUSID_STATUS(
                     SWCControlID,
                     SWCUnitID,
                     SWCServiceID,
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
                     drp_NMObjectionType.SelectedValue.Trim(),
                     Is_Certificate_Valid_Life_Time,
                     Certificate_EXP_Date_DDMMYYYY,
                     D1,
                     D2,
                     D3,
                     D4,
                     D5,
                     D6,
                     D7
                    );

                    if (Update_Result == "SUCCESS")
                    {
                        SqlCommand cmd = new SqlCommand("SendApplicationToAllotteeforQuerySp", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);
                        cmd.Parameters.AddWithValue("@RejectedBY", UserName.Trim());
                        cmd.Parameters.AddWithValue("@Role", Level.Trim());
                        cmd.Parameters.AddWithValue("@Reason", txtClarification.Text.Trim());
                        cmd.Parameters.AddWithValue("@ObjectionID", drp_NMObjectionType.SelectedValue.Trim());

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                            SendMailUPSIDCBuildingPlan();
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + return_string + "');", true);

                        }
                        else
                        {
                            return_string = "Opration Failed";
                            MessageBox1.ShowError(return_string);
                        }
                    }
                    else
                    {
                        MessageBox1.ShowError("Please reduce the objection text length as status is not updating at nivesh mitra");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

        }

        public void AllertRedirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + Par + "');", true);

            // MessageBox1.ShowSuccess("Hello");
        }

        protected void btnRejectM_Click(object sender, EventArgs e)
        {
            SqlCommand cmmd = new SqlCommand("GetResubmissionTimelineBuildingPlan '" + ServiceReqNo + "'", con);
            SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            adpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][1].ToString() == "Close")
                {

                    Response.Redirect("~/RejectionLetterGeneration.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }
                else if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 7)
                {

                    Response.Redirect("~/RejectionLetterGeneration.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }
                else
                {
                    MessageBox1.ShowWarning("Kindly Mark Objection before reejection as objection is still open for this applcation");
                    return;
                }
            }


        }

        protected void btnClarifyM_Click(object sender, EventArgs e)
        {
            SqlCommand cmmd = new SqlCommand("GetResubmissionTimelineBuildingPlan '" + ServiceReqNo + "'", con);
            SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            adpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][1].ToString() == "Close")
                {

                    MessageBox1.ShowWarning("Application is once been sent for clarification");
                    return;
                }
                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 7)
                {

                    MessageBox1.ShowWarning("This Window Is Closed As 7 days timeline has been Passed");
                    return;
                }


            }
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowClarificationModal();", true);
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

                if (Menu_Value1 == "InspectionReport")
                {
                    InspectionfreportViewer();
                }
                else
                {

                    string ServiceCheckListsID = Menu_Value1;
                    string doc_id = Menu_Value2;

                    if (ServiceCheckListsID.Length > 0)
                    {
                        GET_ServiceRequestDoc_Status(ServiceReqNo, ServiceCheckListsID);
                        div_doc_status.Visible = true;
                    }

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
                    UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = LoadControl("~/UC_Service_Allotteee_Detail.ascx") as UC_Service_Allotteee_Detail;
                    UC_Service_Allotteee_Detail.AllotteeId = ApplicantId.ToString();
                    UC_Service_Allotteee_Detail.ID = "UC_Service_Allotteee_DetailID";
                    UC_Service_Allotteee_Detail.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Service_Allotteee_Detail);
                }

                if (Menu_Value1 == "Comments_Detail")
                {
                    UC_Comments UC_Comments = LoadControl("~/UC_Comments.ascx") as UC_Comments;
                    UC_Comments.ID = "UC_Comments";
                    UC_Comments.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_Comments);

                }
                if (Menu_Value1 == "Comments_DetailBT")
                {
                    UC_CommentsBT UC_CommentsBT = LoadControl("~/UC_CommentsBT.ascx") as UC_CommentsBT;
                    UC_CommentsBT.ID = "UC_CommentsBT";
                    UC_CommentsBT.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_CommentsBT);

                }
                if (Menu_Value1 == "Building_Details")
                {
                    UC_BuildingDetails UC_BuildingDetails = LoadControl("~/UC_BuildingDetails.ascx") as UC_BuildingDetails;
                    UC_BuildingDetails.ID = "UC_BuildingDetails";
                    UC_BuildingDetails.SerReqID = ServiceReqNo;
                    Placeholder.Controls.Add(UC_BuildingDetails);

                }

                if (Menu_Value1 == "Process_Application")
                {
                    UC_ProcessApplicationBT UC_ProcessApplicationBT = LoadControl("~/UC_ProcessApplicationBT.ascx") as UC_ProcessApplicationBT;
                    UC_ProcessApplicationBT.ID = "UC_ProcessApplicationBT";
                    UC_ProcessApplicationBT.ServiceReqNo = ServiceReqNo;
                    UC_ProcessApplicationBT.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ProcessApplicationBT);

                }

                if (Menu_Value1 == "Documents")
                {
                    UC_Service_Doc_Upload_View UC_Service_Doc_Upload_View = LoadControl("~/UC_Service_Doc_Upload_View.ascx") as UC_Service_Doc_Upload_View;
                    UC_Service_Doc_Upload_View.ID = "UC_Service_Doc_Upload_View";
                    UC_Service_Doc_Upload_View.SerReqID = ServiceReqNo;
                    UC_Service_Doc_Upload_View.page_type = "VIEW";

                    Placeholder.Controls.Add(UC_Service_Doc_Upload_View);
                }
                if (Menu_Value1 == "Architect_Details")
                {
                    UC_ArchitectDetails UC_ArchitectDetails = LoadControl("~/UC_ArchitectDetails.ascx") as UC_ArchitectDetails;
                    UC_ArchitectDetails.ID = "UC_ArchitectDetails";
                    UC_ArchitectDetails.SerReqID = ServiceReqNo;
                    Placeholder.Controls.Add(UC_ArchitectDetails);
                }

                if (Menu_Value1 == "Payment_Details")
                {
                    SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllottee '" + ServiceReqNo + "'", con);
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
                    string TraID = dt.Rows[0]["BuildingTraID"].ToString();
                    UC_BuildingPlanFeeInternalOffice UC_BuildingPlanFeeInternalOffice = LoadControl("~/UC_BuildingPlanFeeInternalOffice.ascx") as UC_BuildingPlanFeeInternalOffice;

                    UC_BuildingPlanFeeInternalOffice.IndustrialArea = Convert.ToInt32(IAID);
                    UC_BuildingPlanFeeInternalOffice.choicearea = Convert.ToDouble(PlotArea);
                    UC_BuildingPlanFeeInternalOffice.CoveredArea = CoveredArea;
                    UC_BuildingPlanFeeInternalOffice.AllotmentLetterNo = AllottmentNo;
                    UC_BuildingPlanFeeInternalOffice.SWCControlID = ControlID;
                    UC_BuildingPlanFeeInternalOffice.SWCUnitID = UnitID;
                    UC_BuildingPlanFeeInternalOffice.SWCServiceID = ServiceID;
                    UC_BuildingPlanFeeInternalOffice.ServiceRequestNo = ServiceReqNo;
                    UC_BuildingPlanFeeInternalOffice.TranID = TraID;
                    UC_BuildingPlanFeeInternalOffice.ApplicantName = Applicantname;
                    UC_BuildingPlanFeeInternalOffice.applicantAddress = Address;
                    Placeholder.Controls.Add(UC_BuildingPlanFeeInternalOffice);

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


        private void SendMailUPSIDC()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("select * from ApplicationRegister where ApplicationId='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string TempID = dt.Rows[0]["TempApplicationID"].ToString();


                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                   // newmsg.IsBodyHtml = true;
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application is marked for clarification.Kindly check and resubmit your application with proper documents and information");
                    StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/LandAllotmentApplication.aspx?ServiceReqNo=" + TempID + "&App=Resubmit");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Land Allotment ";
                    newmsg.BodyHtml = StrContent;


                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    //smtp.EnableSsl = true;
                    //smtp.Send(newmsg);

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Application has been sent to you for resubmission kindly resubmit your application with proper documents and information.Link has been send to your registered mailid");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , "7275379286"},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SendMailUPSIDCBuildingPlan()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();



                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                   // newmsg.IsBodyHtml = true;
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application for building plan approval is marked for clarification.Kindly check and resubmit your application with proper documents and information");
                    StrContent = StrContent.Replace("{Link}", "");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Building Plan ";
                    newmsg.BodyHtml = StrContent;


                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    //smtp.EnableSsl = true;
                    //smtp.Send(newmsg);

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Application for building plan has been sent to you for resubmission kindly resubmit your application with proper documents and information");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , PhoneNo},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }

                }
            }
            catch (Exception ex)
            {

            }
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
    }
}