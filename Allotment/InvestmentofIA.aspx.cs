using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class InvestmentofIA : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        SqlConnection con = new SqlConnection();

        string UserName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }


            if (!IsPostBack)
            {
                GetNewAllotteeDetails();
                UserSpecificBinding();


            }
        }





        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

            string IndustrialArea = (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).SelectedValue.Trim();
            string name = (Allottee_master_grid.FooterRow.FindControl("txtname") as TextBox).Text;
            string plotNo = (Allottee_master_grid.FooterRow.FindControl("txtplotNo") as TextBox).Text;
            string plotareaSize = (Allottee_master_grid.FooterRow.FindControl("txtplotareaSize") as TextBox).Text;

            string project_cost = (Allottee_master_grid.FooterRow.FindControl("txtproject_cost") as TextBox).Text;
            string current_cost = (Allottee_master_grid.FooterRow.FindControl("txtcurrent_cost") as TextBox).Text;
            string empl_projected = (Allottee_master_grid.FooterRow.FindControl("txtempl_projected") as TextBox).Text;
            string empl_generated = (Allottee_master_grid.FooterRow.FindControl("txtempl_generated") as TextBox).Text;


            string Investment_Type = (Allottee_master_grid.FooterRow.FindControl("drpdInvestment_Type") as DropDownList).SelectedValue.Trim();


            if (IndustrialArea.Length > 0 || name.Length > 0 || plotareaSize.Length > 0 || project_cost.Length > 0 || current_cost.Length > 0 || empl_projected.Length > 0 || empl_generated.Length > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Check All Data !');", true);
                return;
            }


            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.IndustrialArea = IndustrialArea;
                objServiceTimelinesBEL.ApplicantName = name;
                objServiceTimelinesBEL.PlotNo = (plotNo);
                objServiceTimelinesBEL.plotSize = plotareaSize;
                objServiceTimelinesBEL.Price = decimal.Parse(project_cost);
                objServiceTimelinesBEL.CaseType = Investment_Type;
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName;

                objServiceTimelinesBEL.ProjectCurrentCost = decimal.Parse(current_cost);
                objServiceTimelinesBEL.EmploymentProjected = decimal.Parse(empl_projected);
                objServiceTimelinesBEL.EmploymentGenerated = decimal.Parse(empl_generated);


                int retVal = objServiceTimelinesBLL.InsertUpdate_MasterInvestment(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Investment Updated/Inserted Successfully.');", true);
                    GetNewAllotteeDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Investment Updated/Inserted could not be saved');", true);
                }
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured11 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
            ///////////////////////   End Of Insert   ///////////////////////////// 


            //DataRow dr = dt.NewRow();
            //dr["PaymentReicvedDate"] =Convert.ToDateTime(colPaymentReceivedDate);
            //dr["PaymentAmount"] = Amount;
            //dr["PaymentDescription"] = Description;




            //dt.Rows.Add(dr);
            //dt.AcceptChanges();


            //ViewState["CurrentTable"] = dt;

            //            GetAllAllotteeDetailsFilledById(int.Parse(allotteeID.Text));
            //  gridviewpayment.DataSource = dt;
            //  gridviewpayment.DataBind();
        }








        protected void Allottee_master_grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["AllotteeMaster"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }

                Allottee_master_grid.DataSource = dtrslt;
                Allottee_master_grid.DataBind();
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Allottee_master_grid.PageIndex = e.NewPageIndex;
            GetNewAllotteeDetails();
        }
        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));
            bindDDLRegion(ddloffice.SelectedItem.Value, null);
        }


        protected void OnDataBound_investment(object sender, EventArgs e)
        {
            //   DropDownList ddlCountries = Allottee_master_grid.FooterRow.FindControl("ddlCountries") as DropDownList;
            //  ddlCountries.DataSource = GetData("SELECT DISTINCT Country FROM Customers");
            //   ddlCountries.DataTextField = "Country";
            //   ddlCountries.DataValueField = "Country";
            //  ddlCountries.DataBind();
            //   ddlCountries.Items.Insert(0, new ListItem("Select Country", "0"));
            bindIndustrialAreaDetail();


        }



        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).DataSource = ds;
                //drpIndustrialArea.DataSource = ds;
                (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).DataTextField = "IAName";
                (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).DataValueField = "Id";
                (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).DataBind();
                (Allottee_master_grid.FooterRow.FindControl("drpIndustrialArea") as DropDownList).Items.Insert(0, new ListItem("--Select--", "0"));
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




        protected void BindRegionalOffice()
        {
            //conenction path for database

            DataSet dsR = new DataSet();
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR;
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                // ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));

                Regional_Changed(null, null);
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


        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
        }

        public void GetNewAllotteeDetails()
        {
            //   BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            //   string Parameter = drpdwnIA.SelectedItem.Text.ToString();
            DataSet dsAllottee = new DataSet();
            try
            {

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.UserName = UserName;
                objServiceTimelinesBEL.searchText = txtsearch1.Text;
                ds = objServiceTimelinesBLL.GetInvestmentdata(objServiceTimelinesBEL);

                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];

                gridsummary.DataSource = dt1; gridsummary.DataBind();


                StringBuilder str = new StringBuilder();
                str.Append(@" <script type='text/javascript'>
                              google.charts.load('current', { packages: ['corechart'] });
                              google.charts.setOnLoadCallback(drawChart);
                function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                  ['Projected Investment', 'In'],");

                int count = dt1.Rows.Count - 1;
                for (int i = 0; i <= count; i++)
                {
                    if (i == count) { str.Append("['" + dt1.Rows[i]["Projected Investment"].ToString() + "'," + Convert.ToDouble(dt1.Rows[i]["Project Cost"].ToString()) + "]]);"); }
                    else { str.Append("['" + dt1.Rows[i]["Projected Investment"].ToString() + "'," + Convert.ToDouble(dt1.Rows[i]["Project Cost"].ToString()) + "],"); }
                }

                str.Append(@" var options = {  is3D: true};
                              var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
                              chart.draw(data, options); } 
                    </script>");

                lt.Text = str.ToString();



                StringBuilder str1 = new StringBuilder();
                str1.Append(@" <script type='text/javascript'>
                              google.charts.load('current', { 'packages': ['bar'] } );
                              google.charts.setOnLoadCallback(drawChart);
                function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                  ['Regional Office', 'Project Cost In Crores','Current Investment'],");

                int count1 = dt2.Rows.Count - 1;
                for (int i = 0; i <= count1; i++)
                {
                    if (i == count1) { str1.Append("['" + dt2.Rows[i]["RegionalOffice"].ToString() + "'," + Convert.ToDouble(dt2.Rows[i]["projectedinvestment"].ToString()) + " , " + Convert.ToDouble(dt2.Rows[i]["currentinvestment"].ToString()) + "] ]);"); }
                    else { str1.Append("['" + dt2.Rows[i]["RegionalOffice"].ToString() + "', " + Convert.ToDouble(dt2.Rows[i]["projectedinvestment"].ToString()) + ", " + Convert.ToDouble(dt2.Rows[i]["currentinvestment"].ToString()) + "],"); }
                }

                str1.Append(@" var options = {
                                                chart: {
                                                title: 'Investment Status By Regional Offices (In Crores)',
                                              //  subtitle: 'Sales, Expenses, and Profit: 2014-2017',
                                                },
                                                bars: 'horizontal' // Required for Material Bar Charts.
                                              };

                                var chart = new google.charts.Bar(document.getElementById('dual_x_div'));
                                chart.draw(data, google.charts.Bar.convertOptions(options));
                           } 
                    </script>");

                lt1.Text = str1.ToString();

                //  con.Open();
                string SearchString = txtSearch.Text;
                SqlCommand cmd2 = new SqlCommand("select b.[RegionalOffice], b.[IAName], " +
                                                 " a.[name], a.[plot_no], a.[area], " +
                                                 " (case when a.[project_type] = 'T' THEN 'Transfer' else case when a.[project_type] = 'A' THEN 'Approved' else case when a.[project_type] = 'P' THEN 'In Process' end end   end) 'InvestmentType'  " +
                                                 " from[dbo].[Master_Investment] a,[dbo].[IndustrialArea] b " +
                                                 " where a.IAID =b.[Id] " +
                                                 " order by b.[RegionalOffice], b.[IAName], a.[project_type]", con);

                SqlDataAdapter adp1 = new SqlDataAdapter(cmd2); DataTable dt11 = new DataTable(); adp1.Fill(dt11);
                Allottee_master_grid.DataSource = dt3; Allottee_master_grid.DataBind();
                ViewState["AllotteeMaster"] = dt11; ViewState["sortdr"] = "Asc"; Allottee_master_grid.PageIndex = 0; //con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                //   drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));
                if (pIAName != null)
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                //GetNewAllotteeDetails();
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
        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {

            ViewState["Filter"] = drpdwnIA.SelectedItem.Text;
            //GetNewAllotteeDetails();
            //MultiView1.Visible = true;
            //Wizard1.Enabled = true;

            //ResetControl();

        }
        protected void UserSpecificBinding()
        {
            //conenction path for database

            DataSet dsR = new DataSet();
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR;
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                // ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));
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

    }
}