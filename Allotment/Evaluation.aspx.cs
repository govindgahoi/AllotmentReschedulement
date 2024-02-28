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
    public partial class Evaluation : System.Web.UI.Page
    {
        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        int PacketId { get; set; }

        int UserId = 0;

        public void clearAll()
        {
            GridViewApplicants.Visible = false;



        }



        protected void Page_Load(object sender, EventArgs e)
        {

            string IAID = "0", ServicesId = "";

            if (!string.IsNullOrEmpty(Request.QueryString["IAID"]))
            {
                IAID = (Request.QueryString["IAID"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["ServicesId"]))
            {
                ServicesId = (Request.QueryString["ServicesId"]);
            }
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }




            try
            {
                PacketId = int.Parse(Request.QueryString["PacketId"]);
                Get_Notesheet_of_service(PacketId);
            }
            catch (Exception ex) { Response.Write("Oops! error occured -A :" + ex.Message.ToString()); }




            if (!IsPostBack)
            {

                try
                {

                    ViewState["Filter"] = "ALL";

                    //  BindEvaluationChecklistGrid(PacketId);        //Objective Criteria
                    GetevaluationData(PacketId);                  // Top Applicant Grid
                    GetcommitteeforAllotmentApproval(PacketId);

                }
                catch (Exception ex)
                {

                    Response.Write("Oops! error occured -A :" + ex.Message.ToString());
                }
            }
            else
            {

            }


            BindEvaluationChecklistGrid(PacketId);        //Objective Criteria


            #region Binddataforcommittee



            #endregion



            SqlCommand cmd = new SqlCommand("evaluation_data " + PacketId + "", con)
            {
                CommandType = CommandType.Text
            };


            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };


            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];


            if (dt1.Rows.Count > 0)
            {
                grid_Evaluation_Criteria.DataSource = dt1;
                grid_Evaluation_Criteria.DataBind();
            }



            //if (dt2.Rows.Count > 0)
            //{
            //          grid_Evaluation.DataSource = dt2;
            //          grid_Evaluation.DataBind();
            //}





        }






        protected void GridViewApplicants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select_Applicant_for_process")
            {
                string ServiceReqNo = (e.CommandArgument).ToString();
                try
                {
                    Response.Redirect("~/Assessment.aspx?ServiceReqNo=" + ServiceReqNo + "&PacketId=" + PacketId + "");
                }
                catch
                {

                }
            }


            if (e.CommandName == "Select_Applicant_for_letter_generation")
            {
                string ServiceReqNo = (e.CommandArgument).ToString();
                try
                {
                    Response.Redirect("~/ReportGenration.aspx?ServiceReqNo=" + ServiceReqNo + "&PacketId=" + PacketId + "", false);
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured -A :" + ex.Message.ToString());
                }
            }

            if (e.CommandName == "ViewMinutes")
            {
                string ServiceReqNo = (e.CommandArgument).ToString();

                SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNO='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dtDoc = new DataTable();
                adp.Fill(dtDoc);

                if (dtDoc.Rows.Count > 0)
                {
                    if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                    {

                        //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                        String js = "window.open('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "', '_blank');";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerMinutes.aspx", js, true);
                    }
                    else
                    {
                        MessageBox1.ShowError("Committee Minutes Not Uploaded Yet");
                    }
                }
            }







            if (e.CommandName == "Reject_Application")
            {



                try
                {
                    //string ServiceReqNo = (e.CommandArgument).ToString();
                    //ServiceRequestNo_lbl.Text = ServiceReqNo;
                    //string return_string = "";

                    //try { con.Open(); } catch { }

                    //SqlCommand cmd = new SqlCommand("RejectApplicationSp", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);


                    //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //adp.Fill(dt);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                    //    MessageBox1.ShowInfo(return_string);
                    //    GetevaluationData(PacketId);                  
                    //    GetcommitteeforAllotmentApproval(PacketId);
                    //    BindEvaluationChecklistGrid(PacketId);
                    //    Get_Notesheet_of_service(PacketId);
                    //}
                    //else
                    //{
                    //    return_string = "Opration Failed";
                    //    MessageBox1.ShowError(return_string);
                    //}

                    string ServiceReqNo = (e.CommandArgument).ToString();
                    try
                    {
                        Response.Redirect("~/RejectionLetterGeneration.aspx?ServiceReqNo=" + ServiceReqNo + "", false);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured -A :" + ex.Message.ToString());
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

        }

        protected void gridView_PreRender(object sender, EventArgs e)
        {
            MergeRows(grid_Evaluation_Criteria);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);

        }
        public static void MergeRows(GridView grid_Evaluation_Criteria)
        {
            int K = 0;

            for (int rowIndex = grid_Evaluation_Criteria.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = grid_Evaluation_Criteria.Rows[rowIndex];
                GridViewRow previousRow = grid_Evaluation_Criteria.Rows[rowIndex + 1];

                //   for (int i = 0; i < row.Cells.Count; i++)
                //   {

                if (row.Cells[1].Text == previousRow.Cells[1].Text)
                {


                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[0].RowSpan = row.Cells[0].RowSpan;
                    previousRow.Cells[0].Visible = false;


                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                    row.Cells[1].RowSpan = row.Cells[1].RowSpan;
                    previousRow.Cells[1].Visible = false;


                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[2].RowSpan = row.Cells[2].RowSpan;
                    previousRow.Cells[2].Visible = false;


                }


            }

            string prev_hi = "EEE";
            for (int rowIndex = 0; rowIndex < grid_Evaluation_Criteria.Rows.Count; rowIndex++)
            {

                GridViewRow row = grid_Evaluation_Criteria.Rows[rowIndex];
                if (row.Cells[3].Visible == true)
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                        prev_hi = "FFF";
                    }
                    else
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");
                        prev_hi = "EEE";
                    }
                    K++;
                    //  row.Cells[0].Text = K.ToString();
                }
                else
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");

                    }
                    else
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                    }
                }

            }


        }

        #region BindGridforEvaluation




        public void Get_Notesheet_of_service(int PacketId)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                DivNotesheet.Text = "";
                dsR = objServiceTimelinesBLL.Get_Notesheet_of_service(PacketId);
                DataTable dt_Distinct_Applicant = dsR.Tables[0];
                DataTable dt_DataManagerData = dsR.Tables[1];

                DataTable dt_DistinctCommittee = dsR.Tables[2];
                DataTable dt_CommitteeData = dsR.Tables[3];
                DataTable dataHeader = dsR.Tables[4];

                DataTable data, data1, data2, data3, data4;
                if (dataHeader.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataHeader.Rows)
                    { lblheader.Text = dr["Dataheader"].ToString(); }

                }


                if (dt_Distinct_Applicant.Rows.Count > 0)
                {

                    int i = 0;
                    DivNotesheet.Text += @"<div style=''>
                                                <div class='panel-group' id='accordion'>";

                    foreach (DataRow dr in dt_Distinct_Applicant.Rows)
                    {
                        i++;
                        string ServiceRequestNO = dr["ServiceRequestNO"].ToString();
                        string ApplicantId = dr["ApplicantId"].ToString();
                        string ApplicantName = dr["ApplicantName"].ToString();
                        data1 = null; data2 = null; data3 = null; data4 = null;


                        //data1 = dt_DataManagerData.Select("DataManagerType  = 'Data Verifier' and  ServiceRequestNO = '"+ ServiceRequestNO + "' ", "CheklistName").CopyToDataTable();
                        //data2 = dt_DataManagerData.Select("DataManagerType  = 'Data Reviewer' and  ServiceRequestNO = '" + ServiceRequestNO + "' ", "CheklistName").CopyToDataTable();
                        //data3 = dt_DataManagerData.Select("DataManagerType  = 'Data Approver' and  ServiceRequestNO = '" + ServiceRequestNO + "' ", "CheklistName").CopyToDataTable();
                        //data4 = dt_DataManagerData.Select("DataManagerType  = 'CMIA' and  ServiceRequestNO = '" + ServiceRequestNO + "' ", "CheklistName").CopyToDataTable();
                        GeneralMethod gm = new GeneralMethod();
                        string TicketStatus = gm.GetServiceTicketStatusByUser(UserId, PacketId, ServiceRequestNO);

                        if (TicketStatus != "Open")
                        {
                            DivNotesheet.Text += @"
                                               <div style='border: 15px solid #eaeaea;' class='panel panel-default'>
                                                        <div  class='panel-heading' style='font-size:15px !important;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'><a data-toggle='collapse' style='display: inline;' data-target='#accordion" + i.ToString() + "' data-parent='#accordion'><span style='cursor:pointer;font-size: 21px;font-weight: 700;' class='glyphicon glyphicon-plus'></span></a>Applicant :  " + ApplicantName + @"<ul class='list-inline pull-right' style='    margin-left: 20px;padding: 0px 10px;margin-right: 5px;border: 1px solid #797979;background: #d8d8d8;'><li title='Recommend'>Ticket Closed</i></li></ul>
                                                            <span  class='pull-right'>Service No :<span class='span" + i.ToString() + "'>" + ServiceRequestNO + @"</span></span>
                                                        </div>
                                                        <div class='panel-collapse collapse' id='accordion" + i.ToString() + @"'>
                                                        ";
                        }
                        else
                        {
                            DivNotesheet.Text += @"
                                               <div style='border: 15px solid #eaeaea;' class='panel panel-default'>
                                                        <div  class='panel-heading' style='font-size:15px !important;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'><a data-toggle='collapse' style='display: inline;' data-target='#accordion" + i.ToString() + "' data-parent='#accordion'><span style='cursor:pointer;font-size: 21px;font-weight: 700;' class='glyphicon glyphicon-plus'></span></a>Applicant :  " + ApplicantName + @"<ul class='list-inline pull-right' style='    margin-left: 20px;padding: 0px 10px;margin-right: 5px;border: 1px solid #797979;background: #d8d8d8;'><li title='Recommend'><i class='fa fa-hand-o-right recc' id='span" + i.ToString() + @"' aria-hidden='true' data-toggle='modal' data-target='#evalrecommend' ></i></li></ul>
                                                            <span  class='pull-right'>Service No :<span class='span" + i.ToString() + "'>" + ServiceRequestNO + @"</span></span>
                                                        </div>
                                                        <div class='panel-collapse collapse' id='accordion" + i.ToString() + @"'>
                                                        ";
                        }


                        if (dt_DistinctCommittee.Rows.Count > 0)
                        {
                            foreach (DataRow drP in dt_DistinctCommittee.Rows)
                            {

                                string TicketResponderID = drP["TicketResponderID"].ToString();
                                string EmployeeName = drP["EmployeeName"].ToString();
                                string Designation = drP["Designation"].ToString();


                                data1 = null;

                                data1 = dt_CommitteeData.Select("TicketResponderID  = '" + TicketResponderID + "' and ServiceRequestNO='" + ServiceRequestNO + "' ", "TicketCloseDate").CopyToDataTable();
                                DataView dv = data1.DefaultView;
                                dv.Sort = "TicketDescription";
                                data1 = dv.ToTable();

                                DivNotesheet.Text += @"<div style='border: 1px solid #ccc;padding:6px;margin:6px 0;background: #ccc;'>
                                                          <div style='border: 1px solid #ccc;' class='panel panel-default'>
                                                            <div class='panel-heading' style='font-size:15px;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'>Member :  " + EmployeeName + @"<span class='pull-right'>" + Designation + @"</span></div>";
                                DivNotesheet.Text += MakeDivByDatatable(data1, "committee");
                                DivNotesheet.Text += "</div></div>";

                            }
                        }


                        DivNotesheet.Text += MakeDivByDatatable(data1, "DataManager");
                        DivNotesheet.Text += MakeDivByDatatable(data2, "DataManager");
                        DivNotesheet.Text += MakeDivByDatatable(data3, "DataManager");
                        DivNotesheet.Text += MakeDivByDatatable(data4, "DataManager");
                        DivNotesheet.Text += "</div></div>";

                    }
                }

                DivNotesheet.Text += "</div></div><br/><br/></div></div>";

                //if (dt_DistinctCommittee.Rows.Count > 0)
                //{
                //    foreach (DataRow drP in dt_DistinctCommittee.Rows)
                //    {

                //        string TicketResponderID = drP["TicketResponderID"].ToString();
                //        string EmployeeName = drP["EmployeeName"].ToString();
                //        string Designation = drP["Designation"].ToString();


                //        data1 = null;

                //        data1 = dt_CommitteeData.Select("TicketResponderID  = '" + TicketResponderID + "' ", "TicketCloseDate").CopyToDataTable();

                //        DivNotesheet.Text += @"<div style='border: 1px solid #ccc;padding:6px;margin:15px 0;'>
                //                                          <div style='border: 1px solid #ccc;' class='panel panel-default'>
                //                                            <div class='panel-heading' style='font-size:15px;font-weight:700;background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #d8d8d8), color-stop(1, #fafafa));'>Member :  " + EmployeeName + @"<span class='pull-right'>" + Designation + @"</span></div>";
                //        DivNotesheet.Text += MakeDivByDatatable(data1, "committee");
                //        DivNotesheet.Text += "</div></div>";

                //    }
                //}


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }




        public string MakeDivByDatatable(DataTable dt, string DivType)
        {

            string returnString = "";

            //if (DivType == "DataManager")
            //{

            //    if (dt.Rows.Count > 0)
            //    {

            //        string DataManagerType = dt.Rows[0]["DataManagerType"].ToString();
            //        string EmployeeName = dt.Rows[0]["EmployeeName"].ToString();
            //        string Designation = dt.Rows[0]["Designation"].ToString();
            //        string OverallRemark = dt.Rows[0]["OverallRemark"].ToString();
            //        string TicketCloseDate = dt.Rows[0]["TicketCloseDate"].ToString();



            //        returnString += @" <div style='border: 20px solid #dedede;'>
            //                                <div class='form-group' style='background: #efefef;font-size:15px;'>
            //                                    <div class='col-md-4 col-sm-4 col-xs-4'>By: " + EmployeeName + @"(" + Designation + @")</div>
            //                                    <div class='col-md-4 col-sm-4 col-xs-4 text-center'><span class=''>" + TicketCloseDate + @" </span></div>
            //                                    <label class='col-md-4 col-sm-4 col-xs-4' style='font-size:15px;'><span class='pull-right'>" + DataManagerType + @"</span></label>
            //                                    <div class='clearfix'></div>
            //                                </div>
            //                            </div>
            //                        <div class='clearfix'></div>
            //                        <hr class='myhrline' style='margin:0;'/>

            //               ";



            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            string CheklistName = dr["CheklistName"].ToString();
            //            string Remark = dr["Remark"].ToString();
            //            string TicketStatus = dr["TicketStatus"].ToString();

            //            returnString += @"<div class='form-group'>
            //                                <label class='col-md-12 col-sm-12 col-xs-12' style='font-weight:700 !important;'>" + CheklistName + @" :</label>
            //                                 <div class='col-md-12 col-sm-12 col-xs-12'>" + Remark + @"</div>
            //                              </div>
            //                              <div class='clearfix'></div>
            //                              <hr class='myhrline' />";
            //        }


            //        returnString += @"<div class='form-group'>
            //                            <div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7; padding: 10px 13px;font-size:15px;'><b>Overall Observation: </b> " + OverallRemark + @"</div>
            //                          </div>
            //                        <div class='clearfix'></div><hr class='myhrline'/>";


            //    }
            //}




            if (DivType == "committee")
            {
                if (dt.Rows.Count > 0)
                {
                    returnString += "";


                    foreach (DataRow dr in dt.Rows)
                    {



                        string ApplicantId = dr["ApplicantId"].ToString();
                        string ApplicantName = dr["ApplicantName"].ToString();
                        string TicketStatus = dr["TicketStatus"].ToString();
                        string OverallRemark = dr["OverallRemark"].ToString();
                        string TicketCloseDate = dr["TicketCloseDate"].ToString();
                        string RecommendedStatus = dr["RecommendedStatus"].ToString();


                        //returnString += @"<div class='form-group'>
                        //                        <label class='col-md-2 col-sm-2 col-xs-2'>" + ApplicantName + @"(" + ApplicantId + @") :</label>
                        //                        <div class='col-md-8 col-sm-8 col-xs-8'>
                        //                          
                        //                        </div>

                        //                  </div>
                        //                  <div class='clearfix'></div>
                        //                  <hr class='myhrline' />";


                        returnString += @"<div class='form-group'>
                                        <div class='col-md-12 col-sm-12 col-xs-12' style='background: #f7f7f7; padding: 10px 13px;font-size:12px;'><b>Overall Observation: </b> " + OverallRemark + @"</div>
                                        <div class='clearfix'></div>
                                       <div class='col-md-12 col-sm-12 col-xs-12'style='background: #f7f7f7; padding: 10px 13px;font-size:12px;'><b>Recommendation Status: </b>" + RecommendedStatus + @"</div></div>
                                    <div class='clearfix'></div>";



                    }

                }

            }


            return returnString;


        }


        public void GetevaluationData(int PacketId)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetevaluationData(PacketId);
                DataTable dt = dsR.Tables[0];
                DataTable Dt1 = dsR.Tables[1];
                DataTable Dt2 = dsR.Tables[2];
                DataTable Dt3 = dsR.Tables[3];


                if (dt.Rows.Count > 0)
                {
                    GridViewApplicants.DataSource = dt;
                    GridViewApplicants.DataBind();
                }
                if (Dt1.Rows.Count > 0)
                {
                    GridLAPI.DataSource = Dt1;
                    GridLAPI.DataBind();
                }
                if (Dt2.Rows.Count > 0)
                {
                    GridViewca.DataSource = Dt2;
                    GridViewca.DataBind();
                }
                if (Dt3.Rows.Count > 0)
                {
                    GridViewratio.DataSource = Dt3;
                    GridViewratio.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -GetevaluationData :" + ex.Message.ToString());
            }
        }


        public void BindEvaluationChecklistGrid(int PacketId)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.BindEvaluationChecklistGrid(PacketId);
                DataTable dt = dsR.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    EvaluationChecklistGrid.DataSource = dt;
                    EvaluationChecklistGrid.DataBind();
                }



                try
                {
                    DataTable dt1 = dsR.Tables[1];
                    if (dt1.Rows.Count > 0)
                    {
                        grid_Evaluation.DataSource = dt1;
                        grid_Evaluation.DataBind();
                    }
                    else { grid_Evaluation.DataBind(); }

                }
                catch { grid_Evaluation.DataBind(); }





            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -B :" + ex.Message.ToString());
            }









        }






        public void GetcommitteeforAllotmentApproval(int PacketId)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetcommitteeforAllotmentApproval(PacketId);
                DataTable dt = dsR.Tables[0];
                GridCommittee.DataSource = dt;
                GridCommittee.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -D:" + ex.Message.ToString());
            }
        }

        #endregion

        protected void GridViewApplicants_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField field = e.Row.FindControl("IsRec") as HiddenField;

                string rec = field.Value;
                if (rec == "1")
                {
                    (e.Row.FindControl("btnSelectApplicantLetter") as LinkButton).Enabled = true;
                }
                else
                {
                    (e.Row.FindControl("btnSelectApplicantLetter") as LinkButton).Enabled = false;
                }

                SqlCommand cmd = new SqlCommand("Select level From UserAssociationMaster where UserID=" + UserId + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "RM")
                    {
                        var linkButton = e.Row.FindControl("btnSelectApplicant_Recommendation") as LinkButton;
                        var linkButton1 = e.Row.FindControl("btnSelectApplicantLetter") as LinkButton;
                        linkButton.Visible = true;
                        linkButton1.Visible = true;

                    }
                }
            }

        }



        #region bottomTicketControl

        protected void ChangeTicketStatus_Click(object sender, EventArgs e)
        {


            if (ServiceRequestNo_lbl.Text.Length > 0)
            {
                if (drp_Recommendation.SelectedValue != "")
                {
                    if (int.Parse(drpOperate.SelectedValue) > 0)
                    {
                        try
                        {

                            string return_string = "";

                            try { con.Open(); } catch { }

                            SqlCommand cmd = new SqlCommand("SetTicketStatus", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@PacketID", PacketId);
                            cmd.Parameters.AddWithValue("@ServiceRequestNo", ServiceRequestNo_lbl.Text);
                            cmd.Parameters.AddWithValue("@UserId", UserId);

                            cmd.Parameters.AddWithValue("@TicketStage", 6);
                            cmd.Parameters.AddWithValue("@TicketStatus", drpOperate.SelectedValue);
                            cmd.Parameters.AddWithValue("@Comment", txtTicketComment.Text);
                            cmd.Parameters.AddWithValue("@RecommendedStatus", drp_Recommendation.SelectedValue);


                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                return_string = (dt.Rows[0]["Message"].ToString().Trim()).Trim();
                                MessageBox1.ShowInfo(return_string);
                                Get_Notesheet_of_service(PacketId);
                                //  ServiceRequestNo_lbl.Text = "";
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
                    else
                    {
                        MessageBox1.ShowSuccess("Please Select Ticket Status !");
                    }
                }
                else
                {
                    MessageBox1.ShowSuccess("Please Select Recommendation / Approval Status !");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "ShowModel('open');", true);
                }
            }
            else
            {
                MessageBox1.ShowSuccess("Not Set Apllicant To Give Comment - Error !");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "ShowModel('open');", true);
            }

            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "ShowModel('open');", true);

        }

        #endregion




        protected void grid_Evaluation_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {



                GridView ProductGrid = (GridView)sender;

                GridViewRow gvr = e.Row;
                int Aplicant_count = (gvr.Cells.Count - 2) / 2;



                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding Year Column
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1; // For merging first, second row cells to one
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);




                TableCell Qotation = new TableCell();
                Qotation.ColumnSpan = Aplicant_count;
                Qotation.Text = "Applicant's Quote";
                HeaderRow.Cells.Add(Qotation);


                //Adding Year Column
                HeaderCell = new TableCell();
                HeaderCell.Text = "Max Marks";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1; // For merging first, second row cells to one
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);



                TableCell applicant = new TableCell();
                applicant.ColumnSpan = Aplicant_count;
                applicant.Text = "Marks Optianed";
                HeaderRow.Cells.Add(applicant);



                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);


            }
        }



        protected void grid_Evaluation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvr = e.Row;
                int Aplicant_count = (gvr.Cells.Count);

                for (int i = 0; i < Aplicant_count; i++)
                {
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("-Quote", "");
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("Max Marks", "");

                }
            }
        }




    }
}
