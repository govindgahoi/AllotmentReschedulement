using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

using ClosedXML.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;


namespace UpsidaAllottee.RMPanel
{
    public partial class DashBoardApproved : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection();
        string States = "", Searchs = "", ROs = "", subject = "", query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (lblname.Text == "")
            //{
            //    Response.Redirect("/loginpage.aspx");
            //}
            //else
            //{
            //    lblname.Text = Convert.ToString(Session["UserName"]);
            //}            

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string level = Convert.ToString(Session["Level"]);

            if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
            {
                if (!IsPostBack)
                {
                    //DdlRegOfficeBind();
                    // GetGridData2();
                    // bindRegionalOffice_RM(Convert.ToString(Session["UserName"]), level);
                    GetGridData2();
                }
            }
            else
            {
                Response.Redirect("RMLogin.aspx");
            }


        }
        protected void GetGridData2()
        {
            try
            {

                string userids = Session["UserName"].ToString();

                SqlCommand cmd = new SqlCommand("[ZNK_GetGrievanceDetails] '" + userids + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];
                DataTable dt6 = ds.Tables[6];
                DataTable dt7 = ds.Tables[7];
                DataTable dt8 = ds.Tables[8];

                //if (dt.Rows.Count > 0)
                //{
                //    lblTResolved.Text = dt.Rows[0][0].ToString();
                //}
                //else
                //{
                //    lblTResolved.Text = "0";
                //}
                //-------Pending Grievance -----------------
                if (dt.Rows.Count > 0)
                {
                    lblPGrievance.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lblPGrievance.Text = "0";
                }

                //-------Pending KYA -----------------
                if (dt1.Rows.Count > 0)
                {
                    lblKYAPending.Text = dt1.Rows[0][0].ToString();
                    lblPendingKYAS.Text = dt1.Rows[0][0].ToString();
                }
                else
                {
                    lblKYAPending.Text = "0";
                    lblPendingKYAS.Text = "0";
                }

                //-------Outstanding Dues -----------------
                if (dt2.Rows.Count > 0)
                {
                    lblOutstandingDues.Text = dt2.Rows[0][0].ToString();
                }
                else
                {
                    lblOutstandingDues.Text = "0";
                }

                if (dt3.Rows.Count > 0)
                {
                    grdGreStatus.DataSource = dt3;
                    grdGreStatus.DataBind();
                    lblCPGrv.Text = dt3.Rows.Count.ToString();
                }
                else
                {
                    grdGreStatus.DataSource = null;
                    grdGreStatus.DataBind();
                    lblCPGrv.Text = "0";
                }
                //-------Approved KYA -----------------
                if (dt4.Rows.Count > 0)
                {
                    lblApprovedKYA.Text = dt4.Rows[0][0].ToString();
                }
                else
                {
                    lblApprovedKYA.Text = "0";
                }
                //-------Rejected KYA -----------------
                if (dt5.Rows.Count > 0)
                {
                    lblRejectedKYA.Text = dt5.Rows[0][0].ToString();
                }
                else
                {
                    lblRejectedKYA.Text = "0";
                }
                if (dt7.Rows.Count > 0)
                {
                    GridViewKYA.DataSource = dt7;
                    GridViewKYA.DataBind();
                }
                else
                {
                    GridViewKYA.DataSource = null;
                    GridViewKYA.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        protected void grdGreStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGreStatus.PageIndex = e.NewPageIndex;
            //grdViewNews.PageSize = 5;
            GetGridData2();
        }

        protected void GridViewKYA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewKYA.PageIndex = e.NewPageIndex;
            //grdViewNews.PageSize = 5;
            GetGridData2();
        }
        protected void btnXport2XLPendingGrievanceSummary_Click(object sender, EventArgs e)
        {
            Export2Excel("PendingGrievance");
        }

        protected void btnXport2XLKYAApprovalSummary_Click(object sender, EventArgs e)
        {
            Export2Excel("KYAApproval");
        }

        protected void Export2Excel(string rptType)
        {

            string userids = Session["UserName"].ToString();
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                con.Open();
                // Create a command to execute the stored procedure
                using (SqlCommand command = new SqlCommand("[ZNK_GetGrievanceDetails]", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Userids", userids);

                    //SqlDataAdapter adp = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                    if (rptType == "PendingGrievance")
                    {
                        dt = ds.Tables[9];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=PendingGrievance.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    if (rptType == "KYAApproval")
                    {
                        dt = ds.Tables[11];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=KYAApproval.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }
            }

        }
    }
}