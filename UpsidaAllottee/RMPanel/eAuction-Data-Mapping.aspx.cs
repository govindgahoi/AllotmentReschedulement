using System;
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
using System.Drawing;

namespace UpsidaAllottee.RMPanel
{
    public partial class eAuction_Data_Mapping : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection();
        string States = "", Searchs = "", ROs = "", subject = "", query = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string level = Convert.ToString(Session["Level"]);

            if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
            {
                if (!IsPostBack)
                {
                    //DdlRegOfficeBind();
                    GetGridData2();
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]), level);
                }
            }
            else
            {
                Response.Redirect("RMLogin.aspx");
            }

        }

        protected void grdGreStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= grdGreStatus.Rows.Count - 1; i++)
            {
                string Amount = grdGreStatus.Rows[i].Cells[13].Text.Trim();
                //Amount = Amount.Replace("&nbsp;", "");

            if (Amount == "Not Mapped")
                {
                    grdGreStatus.Rows[i].Cells[13].BackColor = Color.Yellow;
                    grdGreStatus.Rows[i].Cells[13].ForeColor = Color.White;
                    //grdGreStatus.Rows[i].Cells[12].Text = "Mapped";
                }
                else
                {
                    //grdGreStatus.Rows[i].Cells[12].BackColor = Color.Green;
                    //grdGreStatus.Rows[i].Cells[12].ForeColor = Color.White;

                    grdGreStatus.Rows[i].Cells[13].BackColor = Color.Green;
                    grdGreStatus.Rows[i].Cells[13].ForeColor = Color.White;

                    //grdGreStatus.Rows[i].Cells[12].Text = "Not Mapped";
                }

            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                string userids = Session["UserName"].ToString();
                string Regional_Office;
                string CurrentStatus;
                string Grievance_Ref_ID;

                if (ddlRegOffice.SelectedValue != "01")
                {
                    Regional_Office = ddlRegOffice.SelectedItem.Text.Trim();
                }
                else
                {
                    Regional_Office = "";
                }

                if (ddlGreStatus.SelectedValue != "01")
                {
                    CurrentStatus = ddlGreStatus.SelectedItem.Text.Trim();
                }
                else
                {
                    CurrentStatus = "";
                }

                if (txtGrievanceId.Text != "")
                {
                    Grievance_Ref_ID = txtGrievanceId.Text.Trim();
                }
                else
                {
                    Grievance_Ref_ID = "";
                }

                SqlCommand cmd = new SqlCommand("[ZNK_GetGrievanceDetails_search]   '" + userids + "','" + Regional_Office + "','" + CurrentStatus + "','" + Grievance_Ref_ID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt3 = ds.Tables[3];
                grdGreStatus.DataSource = null;
                grdGreStatus.DataBind();
                /*
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                //DataTable dt4 = ds.Tables[4];

                if (dt.Rows.Count > 0)
                {
                    lblTResolved.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lblTResolved.Text = "0";
                }
                if (dt1.Rows.Count > 0)
                {
                    lblInProg.Text = dt1.Rows[0][0].ToString();
                }
                else
                {
                    lblInProg.Text = "0";
                }
                if (dt2.Rows.Count > 0)
                {
                    lblTGrRej.Text = dt2.Rows[0][0].ToString();
                }
                else
                {
                    lblTGrRej.Text = "0";
                }
                */
                if (dt3.Rows.Count > 0)
                {
                    grdGreStatus.DataSource = dt3;
                    grdGreStatus.DataBind();
                }
                else
                {
                    grdGreStatus.DataSource = null;
                    grdGreStatus.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void GetGridData2()
        {
            try
            {

                string userids = Session["UserName"].ToString();
                string Regional_Office;
                string CurrentStatus;
                string Grievance_Ref_ID;

                if (ddlRegOffice.SelectedValue == "")
                {
                    Regional_Office = "";
                }
                else if (ddlRegOffice.SelectedValue != "01")
                {
                    Regional_Office = ddlRegOffice.SelectedItem.Text.Trim();
                }
                else
                {
                    Regional_Office = "";
                }

                if (ddlGreStatus.SelectedValue == "")
                {
                    CurrentStatus = "";
                }
                else if (ddlGreStatus.SelectedValue != "01")
                {
                    CurrentStatus = ddlGreStatus.SelectedItem.Text.Trim();
                }
                else
                {
                    CurrentStatus = "";
                }

                if (txtGrievanceId.Text != "")
                {
                    Grievance_Ref_ID = txtGrievanceId.Text.Trim();
                }
                else
                {
                    Grievance_Ref_ID = "";
                }

                SqlCommand cmd = new SqlCommand("[ZNK_GetAuctionDetails_search]   '" + userids + "','" + Regional_Office + "','" + CurrentStatus + "','" + Grievance_Ref_ID + "'", con);


                //SqlCommand cmd = new SqlCommand("[ZNK_GetGrievanceDetails] '" + userids + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];

                DataTable dt7 = ds.Tables[7];
                DataTable dt8 = ds.Tables[8];
                DataTable dt9 = ds.Tables[9];

                if (dt7.Rows.Count > 0)
                {
                    lblTResolved.Text = dt7.Rows[0][0].ToString();
                }
                else
                {
                    lblTResolved.Text = "0";
                }
                if (dt8.Rows.Count > 0)
                {
                    lblInProg.Text = dt8.Rows[0][0].ToString();
                }
                else
                {
                    lblInProg.Text = "0";
                }

                if (dt9.Rows.Count > 0)
                {
                    lblTGrRej.Text = dt9.Rows[0][0].ToString();
                }
                else
                {
                    lblTGrRej.Text = "0";
                }
                if (dt3.Rows.Count > 0)
                {
                    grdGreStatus.DataSource = dt3;
                    grdGreStatus.DataBind();
                }
                else
                {
                    grdGreStatus.DataSource = null;
                    grdGreStatus.DataBind();
                }



            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        private void bindRegionalOffice_RM(string userName, string level)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            if (level == "RM")
            {
                cmd = new SqlCommand("usp_Regional_Office_RM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userName);
            }
            else
            {
                cmd = new SqlCommand("usp_Regional_Office", con);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlRegOffice.DataSource = dt;
            ddlRegOffice.DataTextField = "RegionalOffice";
            ddlRegOffice.DataValueField = "RegionalOffice";
            ddlRegOffice.DataBind();
            ddlRegOffice.Items.Insert(0, new ListItem("--Select--", "01"));

            //System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            //dlRO.Items.Insert(-1, "--Select--");

        }
        protected void grdGreStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGreStatus.PageIndex = e.NewPageIndex;
            //grdPlotData.PageSize = Convert.ToInt16(ddlSelPage.SelectedItem.Text);
            GetGridData2();
        }

        protected void btnXport2XLGrievanceRedressal_Click(object sender, EventArgs e)
        {
            Export2Excel("GrievanceRedressal");
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
                    if (rptType == "GrievanceRedressal")
                    {
                        dt = ds.Tables[3];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=GrievanceRedressal.xlsx");
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