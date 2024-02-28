using BEL_Allotment;
using BLL_Allotment;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
 
using System.Reflection;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace UpsidaAllottee.RMPanel
{
    public partial class Allottee_lager_Summery : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string level = "";
        string IndustrialArea = "";
        #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");
        Hashtable htControls = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            htControls.Add("LinkButton", "Text");
            htControls.Add("HyperLink", "Text");
            htControls.Add("DropDownList", "SelectedItem");
            htControls.Add("CheckBox", "Checked");
            try
            {
                //lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                //LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                //UserName = _objLoginInfo.userName;
                if (level == "Admin1" || level == "MD" || level == "JMD")
                {
                    dlRO.Enabled = true;
                }
                else
                {
                    dlRO.Enabled = true;
                    //dlRO.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string st = ex.StackTrace;
                Response.Redirect("RMLogin.aspx");
            }


            if (!IsPostBack)
            {
                if (level == "RM")
                {
                    //Grid_OTSscheme1.Visible = false;
                    GetUserRecord(Convert.ToString(Session["UserName"]), Session["Type"].ToString().Trim());
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]));
                    // GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
                    //GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }
                else
                {
                    //Grid_OTSscheme.Visible = false;

                    bindRegionalOffice();
                    //GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                }

            }


        }

        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    //lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    //lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bindRegionalOffice_RM(string userName)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office_RM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userName);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        private void bindRegionalOffice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex > 0)
            {
                ViewTEFApprovalLetter();
            }

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                string userids = dlRO.SelectedValue;
                string txtSearch = txtSearch1.Text;

                SqlCommand cmd = new SqlCommand("[ZNK_GetOTSAllotteeLedgerSummary_search]  '" + userids + "','" + txtSearch + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];

                if (dt.Rows.Count > 0)
                {
                    lblTotalDemand.Text = dt.Rows[0][0].ToString();
                    lblTotalPaid.Text = dt.Rows[0][1].ToString();
                    lblTotalOutstandingDue.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    lblTotalDemand.Text = "0";
                    lblTotalPaid.Text = "0";
                    lblTotalOutstandingDue.Text = "0";
                }
                if (dt1.Rows.Count > 0)
                {
                    GridView_TransactionReport.DataSource = dt1;
                    GridView_TransactionReport.DataBind();
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }
                if (dt2.Rows.Count > 0)
                {
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                if (dt3.Rows.Count > 0)
                {
                    GridView3.DataSource = dt3;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
                if (dt4.Rows.Count > 0)
                {
                    lblTotalPlot.Text = dt4.Rows[0][0].ToString();

                }
                else
                {
                    lblTotalPlot.Text = "0";

                }
                if (dt5.Rows.Count > 0)
                {
                    lblTotalAllottee.Text = dt5.Rows[0][0].ToString();

                }
                else
                {
                    lblTotalAllottee.Text = "0";

                }

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        private void ViewTEFApprovalLetter()
        {
            try
            {

                string userids = dlRO.SelectedValue;

                SqlCommand cmd = new SqlCommand("[ZNK_GetOTSAllotteeLedgerSummary] '" + userids + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];

                if (dt.Rows.Count > 0)
                {
                    lblTotalDemand.Text = dt.Rows[0][0].ToString();
                    lblTotalPaid.Text = dt.Rows[0][1].ToString();
                    lblTotalOutstandingDue.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    lblTotalDemand.Text = "0";
                    lblTotalPaid.Text = "0";
                    lblTotalOutstandingDue.Text = "0";
                }
                if (dt1.Rows.Count > 0)
                {
                    GridView_TransactionReport.DataSource = dt1;
                    GridView_TransactionReport.DataBind();
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }
                if (dt2.Rows.Count > 0)
                {
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                if (dt3.Rows.Count > 0)
                {
                    GridView3.DataSource = dt3;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
                if (dt4.Rows.Count > 0)
                {
                    lblTotalPlot.Text = dt4.Rows[0][0].ToString();

                }
                else
                {
                    lblTotalPlot.Text = "0";

                }
                if (dt5.Rows.Count > 0)
                {
                    lblTotalAllottee.Text = dt5.Rows[0][0].ToString();

                }
                else
                {
                    lblTotalAllottee.Text = "0";

                }

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Product List.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView_TransactionReport.AllowPaging = false;
            ViewTEFApprovalLetter();
            GridView_TransactionReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int a = 0; a < GridView_TransactionReport.HeaderRow.Cells.Count; a++)
            {
                GridView_TransactionReport.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            foreach (GridViewRow gvrow in GridView_TransactionReport.Rows)
            {
                gvrow.BackColor = System.Drawing.Color.White;
                if (j <= GridView_TransactionReport.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            GridView_TransactionReport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}