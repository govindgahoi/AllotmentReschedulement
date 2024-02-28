using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Data.SqlClient;
using System.Configuration;
using Allotment.Classes;


using ClosedXML.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;

namespace UpsidaAllottee.RMPanel
{
    public partial class KYA_request : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(); string States = "", Searchs = "", ROs = "";
        Class1 cs = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]), level);
                   // bindTypeOfIndustry();
                }
                else
                {
                    Response.Redirect("RMLogin.aspx");
                }

                btnXport2XLPending.Visible = false;
                btnXport2XLApproved.Visible = false;
                btnXport2XLRejected.Visible = false;
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
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            dlRO.Items.Insert(0, "Select");

            //System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            //dlRO.Items.Insert(-1, "--Select--");

        }


        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex > 0)
            {
                GetGridData2();
                //ddlIA.Items.Clear();
                //ddlIA.Items.Insert(0, new ListItem("Select Industrial Area", "0"));

                //try { bindDDLRegion(dlRO.SelectedItem.Value, null); } catch { }
                ////fill();
            }
        }

        protected void GetGridData2()
        {
            try
            {

                string userids = dlRO.SelectedItem.Text;

                SqlCommand cmd = new SqlCommand("[ZNK_AllotteeKYARequest]'" + userids + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                

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
                    GridKYAPending.DataSource = dt;
                    GridKYAPending.DataBind();
                    btnXport2XLPending.Visible = true;

                }
                else
                {
                    GridKYAPending.DataSource = null;
                    GridKYAPending.DataBind();
                    btnXport2XLPending.Visible = false;

                }

                if (dt1.Rows.Count > 0)
                {
                    GridKYAApproved.DataSource = dt1;
                    GridKYAApproved.DataBind();
                    btnXport2XLApproved.Visible = true;

                }
                else
                {
                    GridKYAApproved.DataSource = null;
                    GridKYAApproved.DataBind();
                    btnXport2XLApproved.Visible = false;
                }

                if (dt2.Rows.Count > 0)
                {
                    GridKYARejected.DataSource = dt2;
                    GridKYARejected.DataBind();
                    btnXport2XLRejected.Visible = true;

                }
                else
                {
                    GridKYARejected.DataSource = null;
                    GridKYARejected.DataBind();
                    btnXport2XLRejected.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        protected void GridKYARejected_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridKYARejected.PageIndex = e.NewPageIndex;
            //grdViewNews.PageSize = 5;
            GetGridData2();
        }

        protected void GridKYAPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridKYAPending.PageIndex = e.NewPageIndex;
            //grdViewNews.PageSize = 5;
            GetGridData2();
        }

        protected void GridKYAApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridKYAApproved.PageIndex = e.NewPageIndex;
            //grdViewNews.PageSize = 5;
            GetGridData2();
        }

        protected void btnXport2XLPending_Click(object sender, EventArgs e)
        {
            Export2Excel("Pending");
        }

        protected void btnXport2XLRejected_Click(object sender, EventArgs e)
        {
            Export2Excel("Rejected");
        }

        protected void btnXport2XLApproved_Click(object sender, EventArgs e)
        {
            Export2Excel("Approved");
        }

        protected void Export2Excel(string rptType)
        {

            string useridKYA = dlRO.SelectedItem.Text;
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                con.Open();
                // Create a command to execute the stored procedure
                using (SqlCommand commandKYA = new SqlCommand("[ZNK_AllotteeKYARequest]'" + useridKYA + "'", con))
                {
                    //commandKYA.CommandType = CommandType.StoredProcedure;

                    //commandKYA.Parameters.AddWithValue("@Userids", useridKYA);

                    //SqlDataAdapter adp = new SqlDataAdapter(command);
                    DataSet dsKYA = new DataSet();
                    DataTable dtKYA = new DataTable();
                    using (SqlDataAdapter adapterKYA = new SqlDataAdapter(commandKYA))
                    {
                        adapterKYA.Fill(dsKYA);
                    }
                    if (rptType == "Pending")
                    {
                        dtKYA = dsKYA.Tables[0];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtKYA, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=KYAPending.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    else if (rptType == "Approved")
                    {
                        dtKYA = dsKYA.Tables[1];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtKYA, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=KYAApproved.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    else if (rptType == "Rejected")
                    {
                        dtKYA = dsKYA.Tables[2];
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtKYA, "DFView");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=KYARejected.xlsx");
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