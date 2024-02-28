using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class EvaluationSheetAllottee : System.Web.UI.UserControl
    {

        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        public string ServiceReqNo { get; set; }
        #endregion

        int UserId = 0;

        public void clearAll()
        {
            GridViewApplicants.Visible = false;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string IAID = "0", ServicesId = "";


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {




                ViewState["Filter"] = "ALL";

                GetevaluationData(ServiceReqNo);                  // Top Applicant Grid


            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }


            BindEvaluationChecklistGrid(ServiceReqNo);        //Objective Criteria


        }


        protected void GridViewApplicants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select_Applicant_for_process")
            {
                string ServiceReqNo = (e.CommandArgument).ToString();
                try
                {
                    Response.Redirect("~/NewAssessment.aspx?ServiceReqNo=" + ServiceReqNo);
                }
                catch (Exception ex)
                {

                }
            }


            if (e.CommandName == "Select_Applicant_for_letter_generation")
            {
                string ServiceReqNo = (e.CommandArgument).ToString();
                try
                {
                    Response.Redirect("~/ReportGenration.aspx?ServiceReqNo=" + ServiceReqNo, false);
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











        public void GetevaluationData(String ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetevaluationDataIndividual(ServiceReqNo);
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




        public void BindEvaluationChecklistGrid(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.BindEvaluationChecklistGridIndividual(ServiceReqNo);
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
                        int total = dt1.AsEnumerable().Sum(row => row.Field<int>("Max_Marks"));
                        grid_Evaluation.FooterRow.Cells[0].Text = "Total";
                        grid_Evaluation.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                        grid_Evaluation.FooterRow.Cells[1].Text = total.ToString("N2");

                        int total1 = dt1.AsEnumerable().Sum(row => row.Field<int>("Obtained_Marks"));
                        grid_Evaluation.FooterRow.Cells[3].Text = total1.ToString("N2");

                        int total2 = dt1.AsEnumerable().Sum(row => row.Field<int>("verifiedmarks"));
                        grid_Evaluation.FooterRow.Cells[5].Text = total2.ToString("N2");
                    }
                    else { grid_Evaluation.DataBind(); }

                }
                catch (Exception ex)
                {
                    grid_Evaluation.DataBind();
                }





            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -B :" + ex.Message.ToString());
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



        protected void grid_Evaluation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
        }
    }
}