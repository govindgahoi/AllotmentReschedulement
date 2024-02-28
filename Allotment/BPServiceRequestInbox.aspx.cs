using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    public partial class BPServiceRequestInbox : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string role = ""; string inbound = "";
        string AllottementLetterNo = ""; string role_byLogin = "", service_id = "", UserName = "";

        UC_Service_Building_Plan UC_Service_Building_Plan;
        UC_Service_WaterConnection UC_Service_WaterConnection;
        UC_Service_Plot_Transfer UC_Service_Plot_Transfer;


        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
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
        string IANAME = "";
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
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            AllottementLetterNo = (string)ViewState["AllottementLetterNo"];
            string SerReqID_in = Request.QueryString["serviceId"];
            string SerID_in = Request.QueryString["id"];
            string SerReqID = HttpUtility.HtmlDecode(SerReqID_in);

            lblserRequest.Text = SerReqID_in;

            if (string.IsNullOrEmpty(SerReqID))
            {
                lblserRequest.Text = SerID_in;
            }
            else
            {
                lblserRequest.Text = SerReqID;
                string[] SerIdarray = lblserRequest.Text.Split('/');
                string alloteeid = SerIdarray[2];
                service_id = SerIdarray[1];
                //   lbl_service_no.Text = lblserRequest.Text;

                GetAllotteeDetail(SerReqID);

                if (service_id == "1000")
                {

                    try
                    {

                        SqlCommand cmd = new SqlCommand("select  ControlId, UnitId , (select top 1 [IAName] from[dbo].[IndustrialArea] b where b.[Id] = IndustrialArea) 'IndustrialArea'   from [dbo].[AllotteeApplicationRegister] where [AllotteeID] = '" + alloteeid + "' ", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        AllottementLetterNo = "";
                        ViewState["AllottementLetterNo"] = AllottementLetterNo;

                        ControlID = dt.Rows[0]["ControlId"].ToString();
                        UnitID = dt.Rows[0]["UnitId"].ToString();

                        IANAME = dt.Rows[0]["IndustrialArea"].ToString();

                        if (service_id.Trim() == "1" || service_id.Trim() == "2")
                        {
                            ServiceID = "SC21002";
                        }
                        else
                        {
                            ServiceID = "SC21001";
                        }
                    }
                    catch { }

                }
                else
                {


                    try
                    {

                        SqlCommand cmd = new SqlCommand("select Allotmentletterno, ControlId, UnitId , ServiceId, IndustrialArea   from [dbo].[AllotteeMaster] where [AllotteeID] = '" + alloteeid + "' ", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        AllottementLetterNo = dt.Rows[0]["Allotmentletterno"].ToString().Trim();
                        ViewState["AllottementLetterNo"] = AllottementLetterNo;

                        ControlID = dt.Rows[0]["ControlId"].ToString();
                        UnitID = dt.Rows[0]["UnitId"].ToString();


                        IANAME = dt.Rows[0]["IndustrialArea"].ToString();

                        if (service_id.Trim() == "1" || service_id.Trim() == "2")
                        {
                            ServiceID = "SC21002";
                        }
                        else
                        {
                            ServiceID = dt.Rows[0]["ServiceId"].ToString();
                        }


                    }
                    catch (Exception ex) { }
                }


            }




            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

                SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string rolelevel = dt.Rows[0]["Level"].ToString().Trim();
                role_byLogin = rolelevel.Trim();



                //   if (AllottementLetterNo == "Jayant.Kabir") { role_byLogin = "RM"; }
                //   if(AllottementLetterNo == "Rama.Kant") { role_byLogin = "AM"; }
                //   if (AllottementLetterNo == "Pradeep.Kumar") { role_byLogin = "EE"; }
                //   if (AllottementLetterNo == "Ashwani.Kumar") { role_byLogin = "JE"; }


            }
            catch { Response.Redirect("Default.aspx", false); }


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


            GetServiceRequestBPDetail(lblserRequest.Text);
            if (!IsPostBack)
            {
                GetServiceRequestBPDetail(lblserRequest.Text);
                BindServiceCheckListGridView();
                check();
                BindInsepectorRequestGridView();
            }


            this.RegisterPostBackControl();



            switch (service_id.ToString())
            {

                case "1":
                    {
                        UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                        Placeholder1.Controls.Add(UC_Service_Building_Plan);
                        UC_Service_Building_Plan.SerReqID = SerReqID;
                        UC_Service_Building_Plan.SerID_in = SerID_in;
                        UC_Service_Building_Plan.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "View";
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;

                        UC_Service_Approval.SerReqID = SerReqID;
                        UC_Service_Approval.SerReq_C_Tab = UC_Service_Building_Plan.SerReq_C_Tab;
                        UC_Service_Approval.SerReq_C_SubTab = UC_Service_Building_Plan.SerReq_C_SubTab;

                        break;
                    }

                case "2":
                    {
                        UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                        Placeholder1.Controls.Add(UC_Service_Building_Plan);
                        UC_Service_Building_Plan.SerReqID = SerReqID;
                        UC_Service_Building_Plan.SerID_in = SerID_in;
                        UC_Service_Building_Plan.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "View";
                        UC_Service_Building_Plan.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }

                case "3":
                    {
                        UC_Service_WaterConnection = LoadControl("~/UC_Service_WaterConnection.ascx") as UC_Service_WaterConnection;
                        Placeholder1.Controls.Add(UC_Service_WaterConnection);
                        UC_Service_WaterConnection.SerReqID = SerReqID;
                        UC_Service_WaterConnection.SerID_in = SerID_in;
                        UC_Service_WaterConnection.UserBy = UserName;
                        UC_Service_Building_Plan.page_type = "View";
                        UC_Service_WaterConnection.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }

                case "4":
                    {
                        UC_Service_Plot_Transfer = LoadControl("~/UC_Service_Plot_Transfer.ascx") as UC_Service_Plot_Transfer;
                        Placeholder1.Controls.Add(UC_Service_Plot_Transfer);
                        UC_Service_Plot_Transfer.SerReqID = SerReqID;
                        UC_Service_Plot_Transfer.SerID_in = SerID_in;
                        UC_Service_Plot_Transfer.UserBy = UserName;
                        UC_Service_Plot_Transfer.page_type = "View";
                        UC_Service_Plot_Transfer.AllottementLetterNo = AllottementLetterNo;
                        break;
                    }
            }

        }



        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in GridViewService.Rows)
            {
                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);

            }


            foreach (GridViewRow row in GridView2.Rows)
            {
                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }






        public void check()
        {
            try
            {
                string[] SerIdarray = lblserRequest.Text.Split('/');

                if (SerIdarray[1] == "2" || SerIdarray[1] == "1")
                {
                    datatableService.Visible = false;
                    headertext.Text = "Building Plan";
                }

                if (SerIdarray[1] == "3")
                {
                    datatableService.Visible = false;
                    headertext.Text = "Water Connection";
                }

                if (SerIdarray[1] == "4")
                {
                    datatableService.Visible = false;
                    headertext.Text = "Transfer Of Plot";
                    transferDataDiv.Visible = false;
                    GetServiceRequestTRDetail(lblserRequest.Text);
                }

                if (SerIdarray[1] == "1000")
                {
                    datatableService.Visible = false;
                    headertext.Text = "Plot Allotment";
                    plot_allotment.Visible = true;
                    view(SerIdarray[2]);
                }

            }
            catch { }

            SqlCommand cmd = new SqlCommand("service_request_track '" + lblserRequest.Text + "'  ", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            // DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];
            DataTable dt4 = ds.Tables[3];


            role = dt1.Rows[0]["role"].ToString().Trim();
            inbound = dt1.Rows[0]["inbound"].ToString().Trim();


            if (role_byLogin.Trim() != role.Trim())
            {
                foreach (GridViewRow row in GridViewService.Rows)
                {
                    ((DropDownList)row.FindControl("ddlVerifiedRM")).Enabled = false;
                    ((DropDownList)row.FindControl("ddlVerifiedAM")).Enabled = false;
                    ((DropDownList)row.FindControl("ddlVerifiedJE")).Enabled = false;

                }
                btnInspection.Visible = false; btnApprove.Visible = false; btnReject.Visible = false;
                submit.Visible = false;
                //    MessageBox1.ShowSuccess("Pending at "+ role);
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "ShowMessage('ServiceRequestInbox.aspx','Pending at "+ role + "')", true);
                //    Response.Redirect("ServiceRequestInbox.aspx", false);

                return;
            }

            if (role.Trim() == "RM")
            {
                try
                {
                    string[] SerIdarray = lblserRequest.Text.Split('/');

                    if (SerIdarray[1] == "2" || SerIdarray[1] == "1")
                    {
                        btnInspection.Enabled = true;
                        inspector_div.Visible = true;
                        btnQuery.Visible = true;
                    }
                    if (SerIdarray[1] == "4")
                    {
                        officeTransferDiv.Visible = true;
                    }
                }
                catch { }


                if (inbound == "NO")
                {
                    btnApprove.Visible = true;

                    string[] SerIdarray = lblserRequest.Text.Split('/');


                    if (SerIdarray[1] == "4")
                    {
                        btnApprove.Text = "Accepte & Issue Transfer Letter";
                    }


                    else if (SerIdarray[1] == "1000")
                    {
                        btnApprove.Text = "Accepte & Issue Allootment Letter";
                    }


                    btnReject.Visible = true;
                }
                else { btnApprove.Visible = false; btnReject.Visible = true; }
            }
            else
            {
                btnInspection.Enabled = false; btnApprove.Visible = false; btnReject.Visible = false; btnQuery.Visible = false;
            }


            lblRole.Text = role.Trim();
            ddlTransfer.DataSource = dt2;
            ddlTransfer.DataBind();
            ddlTransfer.DataTextField = "drp_text";
            ddlTransfer.DataValueField = "drp_value";
            ddlTransfer.DataBind();




            foreach (GridViewRow row in GridViewService.Rows)
            {

                // DropDownList ddls = (DropDownList)row.FindControl("ddlVerified");
                // ddls.Visible = false;

                int rowIndex = row.RowIndex;
                int val = (int)GridViewService.DataKeys[rowIndex]["ServiceCheckListsID"];
                try
                {
                    foreach (DataRow dr in dt3.Rows)
                    {
                        if (val == Convert.ToInt32(dr["ServiceCheckListsID"].ToString()))
                        {
                            string roletemp = dr["CheckedBy"].ToString().Trim();

                            if (roletemp == "RM") { ((DropDownList)row.FindControl("ddlVerifiedRM")).SelectedValue = dr["CheckedStatus"].ToString().Trim(); }
                            if (roletemp == "AM" || roletemp == "EE") { ((DropDownList)row.FindControl("ddlVerifiedAM")).SelectedValue = dr["CheckedStatus"].ToString().Trim(); }
                            if (roletemp == "JE") { ((DropDownList)row.FindControl("ddlVerifiedJE")).SelectedValue = dr["CheckedStatus"].ToString().Trim(); }

                        }

                    }
                }
                catch (Exception ex) { throw ex; }


                ((DropDownList)row.FindControl("ddlVerifiedRM")).Enabled = false;
                ((DropDownList)row.FindControl("ddlVerifiedAM")).Enabled = false;
                ((DropDownList)row.FindControl("ddlVerifiedJE")).Enabled = false;


                if (inbound == "NO")
                {
                    if (role.Trim() == "RM") { ((DropDownList)row.FindControl("ddlVerifiedRM")).Enabled = true; }
                    if (role.Trim() == "AM" || role.Trim() == "EE") { ((DropDownList)row.FindControl("ddlVerifiedAM")).Enabled = true; }
                    if (role.Trim() == "JE" || role.Trim() == "DM") { ((DropDownList)row.FindControl("ddlVerifiedJE")).Enabled = true; }
                }






            }






            if (dt4.Rows.Count > 0)
            {
                if (dt4.Rows[0]["IsRejected"].ToString().Trim() == "True")
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnInspection.Visible = false;
                    submit.Visible = false;



                    foreach (GridViewRow row in GridViewService.Rows)
                    {
                        ((DropDownList)row.FindControl("ddlVerifiedRM")).Enabled = false;
                        ((DropDownList)row.FindControl("ddlVerifiedAM")).Enabled = false;
                        ((DropDownList)row.FindControl("ddlVerifiedJE")).Enabled = false;

                    }


                }
            }



        }



        public void BindServiceCheckListGridView()
        {


            SqlCommand cmd = new SqlCommand("select [Transfer_From] 'From', [Transfer_To] 'Transfer To' ,Remark , Entry_Time 'Date & Time' from [ServiceRequest_Track] where ServiceId ='" + lblserRequest.Text.Trim() + "' order by Entry_Time ", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();



            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            string[] SerIdarray = lblserRequest.Text.Split('/');



            objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceChecklists(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewService.DataSource = ds;
                    GridViewService.DataBind();
                }
                else
                {
                    GridViewService.DataSource = null;
                    GridViewService.DataBind();
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




        protected void Reset_Click(object sender, EventArgs e)
        {
            //  ResetControl();
        }



        #region Save Record

        #endregion


        protected void submit_Click(object sender, EventArgs e)
        {
            try { con.Open(); } catch { }
            SqlCommand command = con.CreateCommand();
            command.Connection = con;

            command.CommandText = ("insert into ServiceRequest_Track(ServiceId, Transfer_From, Transfer_To, Remark, Entry_Time) values( '" + lblserRequest.Text + "','" + lblRole.Text.Trim() + "','" + ddlTransfer.SelectedValue.Trim() + "','" + Remark.Text + "', getdate() )");
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox1.ShowSuccess("Transfer successfully");

                NOC_Certificate_Number = AllottementLetterNo.Trim();

                if (ControlID.Length > 0)
                {

                    if (ServiceID.Trim() == "SC21001")
                    {
                        Status_Code = "05";
                        Remarks = "Request is Forwarded by |" + lblRole.Text.Trim() + "(" + IANAME + ") To " + ddlTransfer.SelectedValue.Trim() + "(" + IANAME + ")";

                    }


                    if (ServiceID.Trim() == "SC21002")
                    {
                        Status_Code = "05";
                        Remarks = "Request is Forwarded by |" + lblRole.Text.Trim() + "(" + IANAME + ") To " + ddlTransfer.SelectedValue.Trim() + "(" + IANAME + ")";
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
                     Pendancy_level,
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

                }


            }
            else
            {
                MessageBox1.ShowWarning("Failed in Transfer");
                return;
            }


            GetServiceRequestBPDetail(lblserRequest.Text);
            BindServiceCheckListGridView();
            check();
        }





        protected void Approve_Click(object sender, EventArgs e)
        {
            try { con.Open(); } catch { }
            SqlCommand command = con.CreateCommand();
            command.Connection = con;
            string[] SerIdarray = lblserRequest.Text.Split('/');


            // Land Allotment
            if (SerIdarray[1] == "1000")
            {
                try
                {
                    command.CommandText = ("update a set a.isActive=1 , a.IsFinalApproved= 1 from ServiceRequests a where a.ServiceRequestNO='" + lblserRequest.Text + "' ");
                    if (command.ExecuteNonQuery() > 0)
                    {

                        SqlCommand cmd = new SqlCommand("create_plot_allotmet_from_application", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Service_Request_No", lblserRequest.Text);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        DataSet ds = new DataSet();

                        string AllotteeId = "";


                        AllotteeId = (dt.Rows[0][0].ToString());
                        if (AllotteeId.Length > 0)
                        {
                            command.CommandText = ("insert into ServiceRequest_Track(ServiceId, Transfer_From, Transfer_To, Remark, Entry_Time) values( '" + lblserRequest.Text + "','" + lblRole.Text.Trim() + "','RM','Approved', getdate() )");
                            if (command.ExecuteNonQuery() > 0)
                            {
                                // send_mail(AllotteeId, SerIdarray[1]);
                                MessageBox1.ShowSuccess("Request Approved");
                            }
                            else
                            {
                                MessageBox1.ShowWarning("Failed in Approve");
                            }


                        }



                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            // Building Plan Approval
            else if (SerIdarray[1] == "1")
            {
                Response.Redirect("ReportGenration.aspx?ServiceReqNo=" + lblserRequest.Text);
            }

            // Building Plan Complition Approval
            else if (SerIdarray[1] == "2")
            {
                Response.Redirect("ReportGenration.aspx?ServiceReqNo=" + lblserRequest.Text);

            }

            // Plot Transfer
            else if (SerIdarray[1] == "4")
            {
                Response.Redirect("ReportGenrationT.aspx?ServiceReqNo=" + lblserRequest.Text);
            }





            if (ControlID.Length > 0)
            {
                Status_Code = "15";
                NOC_Certificate_Number = AllottementLetterNo.Trim();
                NOC_URL = "";
                ISNOC_URL_ActiveYesNO = "Yes";


                if (ServiceID.Trim() == "SC21001")
                {
                    Remarks = "Plot Allotment Process Completed , Now You can avial Eservices By Login to Upsidc";
                    NOC_URL = "http://eservices.onlineupsidc.com/AllotmentLetterView.aspx?AllotteeId=" + AllottementLetterNo.Trim();
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService_1 = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    string Update_Result_1 = webService_1.WReturn_CUSID_ISLandPurchased(
                     ControlID,
                     UnitID,
                     ServiceID,
                    "Yes",
                     passsalt
                     );
                }


                if (ServiceID.Trim() == "SC21002")
                {
                    Remarks = "Building Plan Approval Process Completed";
                    NOC_URL = "http://eservices.onlineupsidc.com/BuildingPlanLetterView.aspx?AllotteeId=" + AllottementLetterNo.Trim();




                    command.CommandText = ("update a set a.DateOfBuldingPlanSubmission=Getdate() from AllotteeMaster a where a.Allotmentletterno='" + AllottementLetterNo + "' ");
                    if (command.ExecuteNonQuery() > 0)
                    {

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
                 Pendancy_level,
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

            }




            Response.Redirect("ServiceRequestInbox.aspx", false);




            GetServiceRequestBPDetail(lblserRequest.Text);
            BindServiceCheckListGridView();
            check();
        }







        protected void Reject_Click(object sender, EventArgs e)
        {


            Response.Redirect("RejectionLetterGeneration.aspx?ServiceReqNo=" + lblserRequest.Text);
            //con.Open();
            //SqlCommand command = con.CreateCommand();
            //command.Connection = con;

            //String[] Arr = lblserRequest.Text.Trim().Split('/');

            //command.CommandText = ("insert into ServiceRequest_Track(ServiceId, Transfer_From, Transfer_To, Remark, Entry_Time) values( '" + lblserRequest.Text + "','" + lblRole.Text.Trim() + "','RM','Rejected', getdate() )");
            //if (command.ExecuteNonQuery() > 0)
            //{
            //    command.CommandText = ("update a set a.IsRejected=1 from ServiceRequests a where a.ServiceRequestNO='" + lblserRequest.Text + "' ");
            //    if (command.ExecuteNonQuery() > 0)
            //    {

            //        Remarks = "Request is Rejected | By Regional manager (" + IANAME + ")";
            //        Status_Code = "07";

            //        if (ServiceID.Trim() == "SC21001")
            //        {
            //            NOC_URL = "http://eservices.onlineupsidc.com/AllotmentRejectLetterView.aspx?AllotteeId=" + Arr[2].Trim();

            //        }
            //        else if (ServiceID.Trim() == "SC21002")
            //        {

            //            NOC_URL = "http://eservices.onlineupsidc.com/BuildingPlanRejectLetterView.aspx?AllotteeId=" + lblserRequest.Text.Trim();

            //        }

            //        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            //        string Update_Result = webService.WReturn_CUSID_STATUS(
            //         ControlID,
            //         UnitID,
            //         ServiceID,
            //         ProcessIndustryID,
            //         ApplicationID,
            //         Status_Code,
            //         Remarks,
            //         Fee_Amount,
            //         Fee_Status,
            //         Transaction_ID,
            //         Transaction_Date,
            //         Transaction_Date_Time,
            //         NOC_Certificate_Number,
            //         NOC_URL,
            //         ISNOC_URL_ActiveYesNO,
            //         passsalt
            //         );


            //        MessageBox1.ShowSuccess("Request Rejected");
            //        Response.Redirect("ServiceRequestInbox.aspx", false);





            //    }

            //}
            //else
            //{
            //    MessageBox1.ShowWarning("Failed");
            //    return;
            //}

            //GetServiceRequestBPDetail(lblserRequest.Text);
            //BindServiceCheckListGridView();
            //check();
        }




        protected void lblRisk_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowInfo(riskDetail.Text);
        }



        protected void InspectorSelecor_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.Connection = con;

                SqlCommand cmd = new SqlCommand("GETRANDOMINSPECTOR ", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                //   DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt1 = ds.Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    string InspectorId = dt1.Rows[0]["USERNAME"].ToString().Trim();
                    command.CommandText = ("insert into ServiceRequest_Inspection(ServiceId, InspectorId, Entry_Time, Modify_Time) values( '" + lblserRequest.Text + "','" + InspectorId.Trim() + "', getdate() , getdate()  )");
                    if (command.ExecuteNonQuery() > 0)
                    {
                        lbl_Inspection.Text = dt1.Rows[0]["EMPLOYEENAME"].ToString().Trim();
                        btnInspection.Text = "Initiate Inspection";
                        btnInspection.Enabled = false;



                        MessageBox1.ShowSuccess("Inspection Assigned To (" + dt1.Rows[0]["EMPLOYEENAME"].ToString().Trim() + ")");
                        BindInsepectorRequestGridView();
                    }
                    else
                    {
                        MessageBox1.ShowWarning("Failed in Transfer");
                        return;
                    }

                }
                else
                {
                    MessageBox1.ShowWarning("Failed TO Allocate Inspector");
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl_status = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl_status.Parent.Parent;
                int index = row.RowIndex;

                int Service_Id = Convert.ToInt32(GridViewService.DataKeys[index][0].ToString());
                int Service_TimeLine_ID = Convert.ToInt32(GridViewService.DataKeys[index][1].ToString());




                con.Open();
                SqlCommand command = con.CreateCommand();
                command.Connection = con;

                command.CommandText = ("Set_ServiceRequestProcessData  '" + lblserRequest.Text + "','" + Service_Id + "','" + lblRole.Text.Trim() + "','" + ddl_status.SelectedValue.Trim() + "' ");
                if (command.ExecuteNonQuery() > 0)
                {
                    //        MessageBox1.ShowSuccess("Updated successfully");
                }
                else
                {
                    MessageBox1.ShowWarning("Failed");
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        public void GetServiceRequestBPDetail(string servicereqid)
        {


            riskDetail.Text = "";
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



            objServiceTimelinesBEL.ServiceRequest = servicereqid;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceRequestBPDetail(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblPlotSize.Text = ds.Tables[0].Rows[0]["totalPlotArea"].ToString();
                    txtFar.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = ds.Tables[0].Rows[0]["GroundCoverage"].ToString().Trim();
                    txtSetBackFront.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();
                    txtHeight.Text = ds.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtOccupancy.Text = ds.Tables[0].Rows[0]["Occupancy"].ToString().Trim();

                    ///////////////  Updated by Mr Manish
                    txtBaseMent1.Text = ds.Tables[0].Rows[0]["ExistingBasement"].ToString().Trim();
                    txtBaseMent2.Text = ds.Tables[0].Rows[0]["ProposedBasement"].ToString().Trim();
                    txtGround1.Text = ds.Tables[0].Rows[0]["ExistingGroundFloor"].ToString().Trim();
                    txtGround2.Text = ds.Tables[0].Rows[0]["ProposedGroundFloor"].ToString().Trim();
                    txtFirstfloor1.Text = ds.Tables[0].Rows[0]["ExistingFirstFloor"].ToString().Trim();
                    txtFirstfloor2.Text = ds.Tables[0].Rows[0]["ProposedFirstFloor"].ToString().Trim();
                    txtSecondFloor1.Text = ds.Tables[0].Rows[0]["ExistingSecondFloor"].ToString().Trim();
                    txtSecondFloor2.Text = ds.Tables[0].Rows[0]["ProposedSecondFloor"].ToString().Trim();

                    txtMezzanine1.Text = ds.Tables[0].Rows[0]["ExistingMezzanineFloor"].ToString().Trim();
                    txtMezzanine2.Text = ds.Tables[0].Rows[0]["ProposedMezzanineFloor"].ToString().Trim();
                    txtFoundation.Text = ds.Tables[0].Rows[0]["Foundation"].ToString().Trim();
                    txtWalls.Text = ds.Tables[0].Rows[0]["Walls"].ToString().Trim();
                    txtFloors.Text = ds.Tables[0].Rows[0]["Floors"].ToString().Trim();
                    txtRoofs.Text = ds.Tables[0].Rows[0]["Roofs"].ToString().Trim();

                    txtStories.Text = ds.Tables[0].Rows[0]["NoofStories"].ToString().Trim();
                    txtLatrines.Text = ds.Tables[0].Rows[0]["NoofLatrines"].ToString().Trim();


                    txtbuildingPurpose.Text = ds.Tables[0].Rows[0]["PurposeofBuildingUse"].ToString().Trim();
                    txtPreviousConstruction.Text = ds.Tables[0].Rows[0]["PreviousConstruction"].ToString().Trim();
                    txtWaterSource.Text = ds.Tables[0].Rows[0]["SourceofWater"].ToString().Trim();
                    ///////////////////////////////





                    int risk0 = 0; int risk1 = 0; int risk2 = 0; int risk = 0;


                    try
                    {

                        if (ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim().Length > 0)
                        {
                            SqlCommand cmd = new SqlCommand("select ID , Classification ,HazardStatus from   Master_IndustryBasedHazard  where ID = '" + ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim() + "'  ", con);
                            cmd.CommandType = CommandType.Text;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            string HazardStatus = "";
                            if (dt.Rows.Count > 0) { HazardStatus = dt.Rows[0]["HazardStatus"].ToString(); }


                            if (HazardStatus == "Low") { risk2 = 0; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: Low Risk<br/>"; }
                            else if (HazardStatus == "Moderate") { risk2 = 1; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: Moderate Risk<br/>"; }
                            else if (HazardStatus == "High") { risk2 = 2; riskDetail.Text = riskDetail.Text + "Degree Of Hazards: High Risk<br/>"; }


                            ddlNature.DataSource = dt;
                            ddlNature.DataBind();
                            ddlNature.DataTextField = "Classification";
                            ddlNature.DataValueField = "ID";
                            ddlNature.DataBind();

                            //try
                            //{
                            //    ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                            //}
                            //catch { }


                        }
                    }
                    catch { }



                    try
                    {
                        if (Convert.ToDecimal(txtHeight.Text) <= 10)
                        {
                            risk0 = 0;
                            riskDetail.Text = riskDetail.Text + "Height: Low Risk<br/>";
                        }
                        else if (Convert.ToDecimal(txtHeight.Text) <= 15)
                        {
                            risk0 = 1;

                            riskDetail.Text = riskDetail.Text + "Height: Moderate Risk<br/>";
                        }
                        else if (Convert.ToDecimal(txtHeight.Text) > 15)
                        {
                            risk0 = 2;

                            riskDetail.Text = riskDetail.Text + "Height: High Risk<br/>";
                        }

                    }
                    catch { }

                    try
                    {
                        if (Convert.ToDecimal(txtOccupancy.Text) <= 50)
                        {
                            risk1 = 0;
                            riskDetail.Text = riskDetail.Text + "Occupency: Low Risk<br/>";
                        }
                        else if (Convert.ToDecimal(txtHeight.Text) <= 100)
                        {
                            risk1 = 1;
                            riskDetail.Text = riskDetail.Text + "Occupency: Moderate Risk<br/>";
                        }
                        else if (Convert.ToDecimal(txtHeight.Text) > 100)
                        {
                            risk1 = 2;
                            riskDetail.Text = riskDetail.Text + "Occupency: High Risk<br/>";
                        }

                    }
                    catch { }





                    risk = Math.Max(risk0, risk1);

                    risk = Math.Max(risk, risk2);

                    if (risk == 0) { lblRisk.Text = "Low Risk"; riskcolor.Attributes.Add("style", "background-color:green;height:27px;"); }
                    if (risk == 1) { lblRisk.Text = "Medium Risk"; riskcolor.Attributes.Add("style", "background-color:yellow;height:27px;"); }
                    if (risk == 2) { lblRisk.Text = "High Risk"; riskcolor.Attributes.Add("style", "background-color:red;height:27px;"); }


                }

                if (ds.Tables[1].Rows.Count > 0)
                {

                    lblFarByelaws.Text = ds.Tables[1].Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = ds.Tables[1].Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = ds.Tables[1].Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = ds.Tables[1].Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = ds.Tables[1].Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = ds.Tables[1].Rows[0]["side2"].ToString().Trim();

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





        protected void GridViewService_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewService.Rows[Convert.ToInt32(e.CommandArgument)];

            string DocumentID = "";
            int Service_Id = Convert.ToInt32(GridViewService.DataKeys[index][0].ToString());
            int Service_TimeLine_ID = Convert.ToInt32(GridViewService.DataKeys[index][1].ToString());
            string[] Arr = lblserRequest.Text.Trim().Split('/');

            SqlCommand cmd = new SqlCommand("select DocumentID from CheckListDocument where ServiceReqId='" + lblserRequest.Text.Trim() + "' and ServiceTimeLinesID=" + Service_TimeLine_ID + " and ServiceCheckListsID=" + Service_Id + " and Allotmentletterno='" + Arr[2] + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                DocumentID = dt.Rows[0]["DocumentID"].ToString().Trim();
            }

            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                //try
                //{

                objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text.Trim();
                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                objServiceTimelinesBEL.UserName = Arr[2];
                objServiceTimelinesBEL.DocumentID = DocumentID;
                ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                if (dtDoc != null)
                {

                    download(dtDoc);
                }
                //}
                //catch (Exception ex)
                //{
                //    Response.Write("Oops! error occured :" + ex.Message.ToString());
                //}



            }



            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                // objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text.Trim();
                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                objServiceTimelinesBEL.UserName = Arr[2];
                objServiceTimelinesBEL.DocumentID = DocumentID;
                ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc != null)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""300px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltEmbed.Text = string.Format(embed, ResolveUrl("/Viewer.ashx?serviceRequestNO=" + lblserRequest.Text.Trim() + "&ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocId=" + DocumentID + ""));

                }
            }
        }
        public void GetAllotteeDetail(string req)
        {
            lblallotteName.Text = "";
            lblAllotteeAddress.Text = "";
            LblallotteeIA.Text = "";
            LblallotteeReg.Text = "";
            LblallotteePlotNo.Text = "";

            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForMail '" + req + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblallotteName.Text = dt.Rows[0]["AllotteeName"].ToString();
                lblAllotteeAddress.Text = dt.Rows[0]["Address"].ToString();
                LblallotteeIA.Text = dt.Rows[0]["IndustrialArea"].ToString();
                LblallotteeReg.Text = dt.Rows[0]["RegionName"].ToString();
                LblallotteePlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                lblEmailId.Text = dt.Rows[0]["SignatoryEmail"].ToString();
                lblPhoneNo.Text = dt.Rows[0]["SignatoryPhone"].ToString();
                lblRMName.Text = dt.Rows[0]["RMName"].ToString();
                lblServiceNAme.Text = dt.Rows[0]["ServiceName"].ToString();

            }
        }



        private void download(DataTable dt)
        {
            try
            {

                Response.Clear();
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();
                Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString().Trim());
                string filename = dt.Rows[0]["ColName"].ToString().Trim();


                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        protected void GridViewService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    string[] SerIdarray = lblserRequest.Text.Split('/');

                    if (SerIdarray[1] == "2" || SerIdarray[1] == "1")
                    {
                        e.Row.Cells[3].Text = "AM";
                    }
                    if (SerIdarray[1] == "4")
                    {
                        e.Row.Cells[5].Text = "DM";
                    }

                    if (SerIdarray[1] == "3")
                    {
                        e.Row.Cells[3].Text = "EE";
                    }
                }
            }
            catch { }




            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    int Service_Id = Convert.ToInt32(GridViewService.DataKeys[e.Row.RowIndex][0].ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(GridViewService.DataKeys[e.Row.RowIndex][1].ToString());
                    string DocumentID = "";
                    string[] Arr = lblserRequest.Text.Trim().Split('/');
                    SqlCommand cmd = new SqlCommand("select DocumentID from CheckListDocument where ServiceReqId='" + lblserRequest.Text.Trim() + "' and ServiceTimeLinesID=" + Service_TimeLine_ID + " and ServiceCheckListsID=" + Service_Id + " and Allotmentletterno='" + Arr[2] + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        DocumentID = dt.Rows[0]["DocumentID"].ToString().Trim();
                    }



                    objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text.Trim();
                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.UserName = Arr[2];
                    objServiceTimelinesBEL.DocumentID = DocumentID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
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


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void BindInsepectorRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                objServiceTimelinesBEL.RequestReportType = "View";
                objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text;


                ds = objServiceTimelinesBLL.GetInspectorRequestRecords(objServiceTimelinesBEL);
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


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                    int total_len = 0;
                    try
                    {
                        total_len = Convert.ToInt32(((Label)e.Row.FindControl("file_name")).Text.ToString().Length);
                    }
                    catch { }


                    if (total_len > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                    }
                }
            }
            catch
            {

            }

        }



        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewService.Rows[Convert.ToInt32(e.CommandArgument)];




            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {

                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                    objServiceTimelinesBEL.RequestReportType = "View";
                    objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text;

                    ds = objServiceTimelinesBLL.GetInspectorRequestRecords(objServiceTimelinesBEL);

                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Remarks = "Query is asked from applicant | By Regional manager (" + IANAME + ")";
            Status_Code = "08";
            NOC_URL = "http://eservices.onlineupsidc.com/BuildingPlanClarifyLetterView.aspx?AllotteeId=" + lblserRequest.Text.Trim();

            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
            string Update_Result = webService.WReturn_CUSID_STATUS(
             ControlID,
             UnitID,
             ServiceID,
             ProcessIndustryID,
             ApplicationID,
             Status_Code,
             Remarks,
             Pendancy_level,
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


            MessageBox1.ShowSuccess("Queried From Applicant");
        }

        public void GetServiceRequestTRDetail(string servicereqid)
        {

            SqlCommand cm = new SqlCommand(@"select [CircleRate] 'Circle Rate' ,[Rate] 'Levy Percentage' ,TotalAllottedplotArea  'Plot Area',
                 ((([CircleRate] * [Rate])/100) * [TotalAllottedplotArea] ) 'Levy Amount' 
from [dbo].[Master_IARates]a , [dbo].[Master_Industrial_Area_Transfer_Levy] b , [dbo].[AllotteeMaster] c, [dbo].[IndustrialArea] d,
[dbo].[ServiceRequests] e 
where a.[IAId] = b.[IndustrialArea] and c.[IndustrialArea] = d.[IAName] and a.[IAId] = d.[Id] and c.[AllotteeID] = e.[AllotteeID]
and  (datediff(year, c.[AllotmentletterIssueDate],getdate()) between [MinPeriod] and [MaxPeriod]) and e.[ServiceRequestNO] = '" + servicereqid + "' ", con);
            SqlDataAdapter ad = new SqlDataAdapter(cm);
            DataTable dt11 = new DataTable();
            ad.Fill(dt11);

            LevyGrid.DataSource = dt11; LevyGrid.DataBind();


            SqlCommand cmd = new SqlCommand("select * from PlotTransferDetails  where ServiceRequestNo = '" + servicereqid + "' ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                lblAreaName.Text = dt.Rows[0]["IAName"].ToString();
                lblNameofAllottee.Text = dt.Rows[0]["AllotteeName"].ToString();
                lblTelNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                lblPanNo.Text = dt.Rows[0]["Pan"].ToString();
                txtProposedTransfereeName.Text = dt.Rows[0]["TransfereeName"].ToString();
                txtProposedTransfereeAddress.Text = dt.Rows[0]["AddressTransferee"].ToString();
                txtTransfereeTelNo.Text = dt.Rows[0]["TransferreePhone"].ToString();
                txtTransfereePan.Text = dt.Rows[0]["TransfereePanNo"].ToString();
                txtReasonofTransfer.Text = dt.Rows[0]["TransferReason"].ToString();

            }





            SqlCommand cmd1 = new SqlCommand("select * from  FROM AllotteeApplicationTransferProjectDetails WHERE ServiceRequestNo = '" + servicereqid + "' ", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {


                //   txtServiceRequestNo.Text = dt1.Rows[0]["ServiceRequestNo"].ToString();
                txttypeofindustry.Text = dt1.Rows[0]["IndustryType"].ToString();
                txtestimatedcost.Text = dt1.Rows[0]["EstimatedCostOfProject"].ToString();
                txtestimatedemployment.Text = dt1.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                txtcoveredarea.Text = dt1.Rows[0]["CoveredArea"].ToString();
                txtopenarearequired.Text = dt1.Rows[0]["OpenAreaRequired"].ToString();
                txtland.Text = dt1.Rows[0]["LandDetails"].ToString();
                txtbuilding.Text = dt1.Rows[0]["BuildingDetails"].ToString();
                txtmachinery.Text = dt1.Rows[0]["MachineryEquipmentsDetails"].ToString();
                txtFixedAssets.Text = dt1.Rows[0]["OtherFixedAssets"].ToString();
                txtOtherExpenses.Text = dt1.Rows[0]["OtherExpenses"].ToString();


                txtfumeqty.Text = dt1.Rows[0]["FumeQuantity"].ToString();
                txtfumenature.Text = dt1.Rows[0]["FumeNature"].ToString();


                txteffluentsolidqty.Text = dt1.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                txteffluentsolidcomposition.Text = dt1.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                txteffluentliquidqty.Text = dt1.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                txteffluentliquidcomposition.Text = dt1.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                txteffluentgaseousqty.Text = dt1.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                txteffluentgaseouscomposition.Text = dt1.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                //  .Text = dt1.Rows[0]["FumeGenerationStatus"].ToString();

                txteffluenttreatmentmeasure1.Text = dt1.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                txteffluenttreatmentmeasure2.Text = dt1.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                txteffluenttreatmentmeasure3.Text = dt1.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                txtpowerreq.Text = dt1.Rows[0]["PowerReqInKW"].ToString();
                //    chkpriority.Text = dt1.Rows[0]["ApplicantPriorityStatus"].ToString();
                txtapplicantpriorityspecification.Text = dt1.Rows[0]["ApplicantPrioritySpecification"].ToString();



            }








        }




        public void send_mail(string AllotteeId, string ServiceId)
        {
            if (ServiceId == "1000")
            {
                objServiceTimelinesBEL.Parameter = AllotteeId.ToString();

                DataSet ds;
                ds = objServiceTimelinesBLL.GetAllotteeloginDetails(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];
                AllottementLetterNo = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                string uid = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                string Email = dt1.Rows[0]["emailID"].ToString().Trim();
                string name = dt1.Rows[0]["AllotteeName"].ToString().Trim();
              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(Email.Trim());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);
                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/AcknowledgeMent1.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{UserName}", name);
                StrContent = StrContent.Replace("{Description}", "Your UPSIDC EServices Account Has Been Activated! </br>You Can Now Avail The Services By Below Credentials");
                StrContent = StrContent.Replace("{UserId}", uid);
                StrContent = StrContent.Replace("{Password}", "12345");
                StrContent = StrContent.Replace("{url}", "http://eservices.onlineupsidc.com/");
                newmsg.Subject = "UPSIDCeServe: Acknowledgement-Login Credentials for eService ";
                newmsg.BodyHtml = StrContent;
               // newmsg.IsBodyHtml = true;
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

            }

        }




        public void view(string id)
        {
            SqlCommand cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByIdTemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AllotteeID", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];
            // DataTable dt4 = ds.Tables[3];
            if (dt1.Rows.Count > 0)
            {

                Label28.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                Label24.Text = dt1.Rows[0]["CompanyName"].ToString();
                Label25.Text = dt1.Rows[0]["FirmConstitution"].ToString();
                Label30.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                Label29.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                Label31.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
                Label26.Text = dt1.Rows[0]["PanNo"].ToString();
                Label27.Text = dt1.Rows[0]["CinNo"].ToString();
                Label14.Text = dt1.Rows[0]["PlotSize"].ToString();
                Label23.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                Label1.Text = dt1.Rows[0]["Status_Name"].ToString();
                Label13.Text = dt1.Rows[0]["DateofAllotmentNo"].ToString();




                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Individual/Sole Proprietorship firm")
                {
                    GridView6.Visible = true;
                    P2.InnerText = "Individual/Sole Proprietorship firm Details";
                    GridView6.DataSource = dt2; GridView6.DataBind();
                }
                else
                {
                    GridView6.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Public Limited")
                {
                    GridView7.Visible = true;
                    P2.InnerText = "Directors Details";
                    GridView7.DataSource = dt2; GridView7.DataBind();
                }
                else
                {
                    GridView7.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Private Limited")
                {
                    GridView8.Visible = true;
                    P2.InnerText = "ShareHolders Details";
                    GridView8.DataSource = dt2; GridView8.DataBind();
                }
                else
                {
                    GridView8.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Partnership Firm")
                {
                    GridView9.Visible = true;
                    P2.InnerText = "Partners Details";
                    GridView9.DataSource = dt2; GridView9.DataBind();
                }
                else
                {
                    GridView9.Visible = false;
                }
                if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Society & Trust")
                {
                    GridView10.Visible = true;
                    P2.InnerText = "Trustee Details";
                    GridView10.DataSource = dt2; GridView10.DataBind();
                }
                else
                {
                    GridView10.Visible = false;
                }




                Label12.Text = dt3.Rows[0]["IndustryType"].ToString();
                Label33.Text = dt3.Rows[0]["EstimatedCostOfProject"].ToString();
                Label34.Text = dt3.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                Label35.Text = dt3.Rows[0]["CoveredArea"].ToString();
                Label36.Text = dt3.Rows[0]["OpenAreaRequired"].ToString();
                Label37.Text = dt3.Rows[0]["LandDetails"].ToString();
                Label38.Text = dt3.Rows[0]["BuildingDetails"].ToString();
                Label39.Text = dt3.Rows[0]["MachineryEquipmentsDetails"].ToString();
                Label40.Text = dt3.Rows[0]["OtherFixedAssets"].ToString();
                Label41.Text = dt3.Rows[0]["OtherExpenses"].ToString();
                Label44.Text = dt3.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                Label45.Text = dt3.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                Label46.Text = dt3.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                Label47.Text = dt3.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                Label48.Text = dt3.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                Label49.Text = dt3.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                if (dt3.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                {
                    Span1.InnerText = "Yes";
                    Div1.Visible = true;
                    Label43.Text = dt3.Rows[0]["FumeQuantity"].ToString();
                    Label42.Text = dt3.Rows[0]["FumeNature"].ToString();
                }
                else
                {
                    Span1.InnerText = "No";
                    Div1.Visible = false;
                    Label43.Text = "";
                    Label42.Text = "";
                }
                Label50.Text = dt3.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                Label51.Text = dt3.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                Label52.Text = dt3.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                Label53.Text = dt3.Rows[0]["PowerReqInKW"].ToString();
                Label54.Text = dt3.Rows[0]["TelephoneReqFirstYear1"].ToString();
                Label55.Text = dt3.Rows[0]["TelephoneReqFirstYear2"].ToString();
                Label56.Text = dt3.Rows[0]["TelephoneReqUltimate1"].ToString();
                Label57.Text = dt3.Rows[0]["TelephoneReqUltimate2"].ToString();
                if (dt3.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                {
                    Span2.InnerText = "Yes";
                    Div2.Visible = true;
                    Label58.Text = dt3.Rows[0]["ApplicantPrioritySpecification"].ToString();
                }
                else
                {
                    Span2.InnerText = "No";
                    Div2.Visible = false;
                    Label58.Text = "";
                }


            }

            cmd.Dispose();

        }
        private void send_mail_bulding(string name, string mailid)
        {
            try
            {

                if (mailid.Trim() == "" || mailid.Trim() == null)
                {
                    MessageBox1.ShowError("Mail Id Is Not Present!");
                    return;
                }


              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(mailid);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);


                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/BuildingPlanAcknowledge.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("[Date]", DateTime.Now.ToString("dd MMM yyyy"));
                StrContent = StrContent.Replace("[Allottee Name]", lblallotteName.Text);
                StrContent = StrContent.Replace("[Regional Office]", LblallotteeReg.Text.Trim());
                StrContent = StrContent.Replace("[IA]", LblallotteeIA.Text.Trim());
                StrContent = StrContent.Replace("[Plot No]", LblallotteePlotNo.Text.Trim());
                StrContent = StrContent.Replace("[Allottee Address]", lblAllotteeAddress.Text.Trim());
                StrContent = StrContent.Replace("[Allottee Email]", lblEmailId.Text.Trim());
                StrContent = StrContent.Replace("[Allottee Phone]", lblPhoneNo.Text.Trim());
                StrContent = StrContent.Replace("[Service Request No]", lblserRequest.Text.Trim());
                StrContent = StrContent.Replace("[Request For]", lblServiceNAme.Text.Trim());
                StrContent = StrContent.Replace("[RM Name]", lblRMName.Text.Trim());
                StrContent = StrContent.Replace("[Service Type]", "Erect/Re-Erect New Building");


                newmsg.Subject = "Acknowledge : " + lblserRequest.Text + " : Application For " + lblServiceNAme.Text;
                newmsg.BodyHtml = StrContent;
                // newmsg.Attachments.Add(new Attachment(Server.MapPath("doc/Inspection_Procedure.pdf")));

                //  newmsg.IsBodyHtml = true;
                //For File Attachment, more file can also be attached
                //Attachment att = new Attachment("");
                //newmsg.Attachments.Add(att);

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

                MessageBox1.ShowSuccess("Mail Send Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }








        }


        protected void btnMail_Click(object sender, EventArgs e)
        {
            send_mail_bulding("", lblEmailId.Text);
        }

    }
}