using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee.RMPanel
{
    public partial class Grievance : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //btnSearch.Attributes.Add("OnClick", "return Check()");
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Admin-Dashboard/login.aspx");
            }
            else {
                if (!this.IsPostBack)
                {
                    DdlRegOfficeBind();
                    GetGridData2("");
                    //GetChartData();
                }

            }

            //Session["UserName"] = txtemail.Text.Trim();
        }

        string subject = "";
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlRegOffice.SelectedValue != "01")
            {
                subject += "and Regional_Office like '%" + ddlRegOffice.SelectedItem.Text.Trim() + "%'";
                GetGridData2(subject);
            }
            if (ddlGreStatus.SelectedValue != "01")
            {
                subject += "and CurrentStatus like '%" + ddlGreStatus.SelectedItem.Text.Trim() + "%'";
                GetGridData2(subject);
            }
            if (txtGrievanceId.Text != "")
            {
                subject += "and Grievance_Ref_ID like '%" + txtGrievanceId.Text.Trim() + "%'";
                GetGridData2(subject);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //protected void GetChartData()
        //{
        //    try
        //    {
        //        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //        SqlConnection con = new SqlConnection(constring);
        //        SqlCommand cmd = new SqlCommand("  select CurrentStatus from UPSIDA_GRS  group by CurrentStatus", con);
        //        //cmd.Parameters.AddWithValue("@GrievRef_Id", txtRefNumber.Text);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        con.Open();
        //        int i2 = cmd.ExecuteNonQuery();
        //        con.Close();
        //        string[] X = new string[dt.Rows.Count];
        //        int[] Y =new int[dt.Rows.Count];
        //        for(int i=0; i<dt.Rows.Count; i++)
        //        {
        //            X[i] = dt.Rows[i][0].ToString();
        //            Y[i] =  Convert.ToInt16(dt.Rows[i][1].ToString());
        //            Chart1.Series[0].Points.DataBindXY(X,Y);
        //            Chart1.Series[0].ChartType = SeriesChartType.Pie;
        //        }

        //        if (dt.Rows.Count > 0)
        //        {
        //            grdGreStatus.DataSource = dt;
        //            grdGreStatus.DataBind();
        //            //lblGreRefNo.Text = string.Empty;
        //        }
        //        else
        //        {
        //            //lblGreRefNo.Text = "Please check your Grievance Reference Number!";
        //            this.grdGreStatus.DataSource = null;
        //            grdGreStatus.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("" + ex.Message.ToString());
        //    }
        //}

        //protected void SearchGrevData()
        //{
        //    string query = string.Empty;
        //    string regoff = string.Empty;

        //    if (ddlRegOffice.SelectedIndex == 01)
        //    {
        //        regoff = null;
        //    }
        //    else
        //    {
        //        regoff = ddlRegOffice.SelectedItem.Text;
        //    }

        //    try
        //    {
        //        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //        SqlConnection con = new SqlConnection(constring);
        //        SqlCommand cmd = new SqlCommand("select * from UPSIDA_GRS where Regional_Office=@RegOff", con);
        //        cmd.Parameters.AddWithValue("@RegOff", regoff);
        //        //cmd.Parameters.AddWithValue("@dateTime", txt);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        con.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        con.Close();
        //        if (dt.Rows.Count > 0)
        //        {
        //            grdGreStatus.DataSource = dt;
        //            grdGreStatus.DataBind();
        //            //lblGreRefNo.Text = string.Empty;
        //        }
        //        else
        //        {
        //            //lblGreRefNo.Text = "Please check your Grievance Reference Number!";
        //            this.grdGreStatus.DataSource = null;
        //            grdGreStatus.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("" + ex.Message.ToString());
        //    }
        //}

        string query = "";
        protected void GetGridData2(string subject)
        {
            try
            {
                if (subject == "")
                {

                    query = "select * from UPSIDA_GRS";

                }
                else
                {
                    query = "select * from UPSIDA_GRS where Id !=000  " + subject.Trim();
                }

                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string totalGrevCount = string.Empty;
                    string GrevRequest = string.Empty;
                    string GrevProgress = string.Empty;
                    string GrevResolve = string.Empty;
                    grdGreStatus.DataSource = dt;
                    grdGreStatus.DataBind();



                    SqlCommand cmd2 = new SqlCommand("select Count(CurrentStatus),'Request Raised'  from UPSIDA_GRS where CurrentStatus='Request Raised'union select Count(CurrentStatus), 'Resolved' from UPSIDA_GRS where CurrentStatus = 'Resolved'union select Count(CurrentStatus), 'In Progress' from UPSIDA_GRS where CurrentStatus = 'In Progress'", con);
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    con.Open();
                    int i2 = cmd.ExecuteNonQuery();
                    con.Close();
                    if (dt2.Rows.Count > 0)
                    {
                        GrevProgress = dt2.Rows[0][0].ToString().Trim();
                        GrevRequest = dt2.Rows[1][0].ToString().Trim();
                        GrevResolve = dt2.Rows[2][0].ToString().Trim();
                        totalGrevCount += Convert.ToInt32(GrevProgress) + Convert.ToInt16(GrevRequest) + Convert.ToInt16(GrevResolve);
                        //lblTotalGriProgress.Text = GrevProgress;
                        //lblTotalGriRequest.Text = GrevRequest;
                        //lblTotalGriReceived.Text = totalGrevCount;
                        //lblGriResolved.Text = GrevResolve;

                    }
                    else
                    {
                        this.grdGreStatus.DataSource = null;
                        grdGreStatus.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }


        protected void DdlRegOfficeBind()
        {
            string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string qry = "SELECT Id As a,RegionalOffice as b FROM( SELECT RowNum=ROW_number() OVER(PARTITION BY RegionalOffice ORDER BY ID),Id,RegionalOffice FROM [dbo].[IndustrialArea] WITH(NOLOCK)) t WHERE RowNum=1 ORDER BY RegionalOffice";
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlRegOffice.DataSource = dt;
            ddlRegOffice.DataBind();
            ddlRegOffice.DataTextField = "b";
            ddlRegOffice.DataValueField = "a";
            ddlRegOffice.DataBind();
            ddlRegOffice.Items.Insert(0, new ListItem("--Select--", "01"));
        }


        protected void grdGreStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGreStatus.PageIndex = e.NewPageIndex;
            //grdPlotData.PageSize = Convert.ToInt16(ddlSelPage.SelectedItem.Text);
            GetGridData2("");
        }

    }
}