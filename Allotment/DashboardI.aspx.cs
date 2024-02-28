using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{

    public partial class DashboardI : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection();
        #endregion

        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

            
                GetInternalUserPersonalDetails(UserName);
                if (!IsPostBack)
                {
                    GetNewAllotteeDetails();
                    GetEmploymentDetails();
                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

        }


        #region GetInternalUserPersonalDetails
        public void GetInternalUserPersonalDetails(string strName)
        {
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetInternalUserPersonalDetails(strName);

                DataTable dt = dsR.Tables[0];
                DataTable dt1 = dsR.Tables[1];
                DataTable dt2 = dsR.Tables[2];
                DataTable dt3 = dsR.Tables[3];
                DataTable dt4 = dsR.Tables[4];
                DataTable dt5 = dsR.Tables[5];

                if (dt.Rows.Count > 0)
                {
                    lblName.Text = dt.Rows[0]["EMPLOYEENAME"].ToString();
                    lbldesignation.Text = dt.Rows[0]["Designation"].ToString();
                    lblGrade.Text = dt.Rows[0]["Grade"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["phoneNo"].ToString();
                    lblEmail.Text = dt.Rows[0]["emailID"].ToString();
                    //lblnew.Text              = dt.Rows[0]["New_Signup_Request"].ToString();
                    //lblnewsigPending.Text    = dt.Rows[0]["Pending_In_Process"].ToString();
                    //lblNewSignActivated.Text = dt.Rows[0]["Rejected"].ToString();
                    //lblnewsignRejected.Text  = dt.Rows[0]["Active"].ToString();
                    //lblnewsignCompleted.Text = dt.Rows[0]["Completed"].ToString();
                    lblnew.Text = dt.Rows[0]["AllotmentRequest"].ToString();
                    lblnewsigPending.Text = dt.Rows[0]["AllotmentRequestActive"].ToString();
                    lblNewSignActivated.Text = dt.Rows[0]["AllotmentRequestActivated"].ToString();
                    lblnewsignRejected.Text = dt.Rows[0]["AllotmentRequestRejected"].ToString();
                    lblnewsignCompleted.Text = dt.Rows[0]["AllotmentRequestCompleted"].ToString();
                    lblserreqnew.Text = dt.Rows[0]["Service_Request"].ToString();
                    lblserpend.Text = dt.Rows[0]["Service_Pending_At_You"].ToString();
                    lblserProcessed.Text = dt.Rows[0]["Service_In_Process"].ToString();
                    lblserrej.Text = dt.Rows[0]["Service_Rejected"].ToString();
                    lblserComp.Text = dt.Rows[0]["Service_Complete"].ToString();



                }
                if (dt1.Rows.Count > 0) { LblAllotteeRequest.Text = dt1.Rows[0][0].ToString(); }
                if (dt2.Rows.Count > 0) { LblAllotteeReqNotInCon.Text = dt2.Rows[0][0].ToString(); }
                LblAllotteeReqPending.Text = (Convert.ToInt32(dt1.Rows[0][0].ToString()) + Convert.ToInt32(dt4.Rows[0][0].ToString())).ToString();
                if (dt3.Rows.Count > 0) { LblReqAccepted.Text = dt3.Rows[0][0].ToString(); }
                if (dt5.Rows.Count > 0) { LblAllotteeReqCompleted.Text = dt5.Rows[0][0].ToString(); }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        #endregion

        #region Investment
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
            GetEmploymentDetails();
        }


        protected void OnDataBound_investment(object sender, EventArgs e)
        {

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



        public void GetNewAllotteeDetails()
        {
            lt.Text = "";
            lt1.Text = "";
            lt0.Text = "";

            DataSet dsAllottee = new DataSet();
            try
            {

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.UserName = UserName;
                objServiceTimelinesBEL.searchText = txtsearch.Text;
                ds = objServiceTimelinesBLL.GetInvestmentdata(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];
                DataTable dt4 = ds.Tables[3];


                gridsummary.DataSource = dt1; gridsummary.DataBind();

                if (dt1.Rows.Count > 0)
                {

                    StringBuilder str0 = new StringBuilder();

                    int count_dashboard = dt4.Rows.Count - 1;



                    str0.Append(@"<script type=""text/javascript"">
                // Create the chart
                        Highcharts.chart('container', {
                        chart:
                        {
                            type: 'column'
                        },
                    title:
                        {
                            text: 'Employment'
                    },
                    subtitle:
                        {
                            //text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
                        },
                    xAxis:
                        {
                            type: 'category'
                    },
                    yAxis:
                        {
                            title:
                            {
                                text: 'Total percent market share'
                            }

                        },
                    legend:
                        {
                            enabled: false
                    },
                    plotOptions:
                        {
                            series:
                            {
                            borderWidth: 0,
                            dataLabels:
                                {
                                enabled: true,
                                format: '{point.y:.1f}'
                                }
                            }
                        },

                    tooltip:
                        {
                            headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
                        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y:.2f}</b> <br/>'
                    },

                    series: [{
                            name: 'Region Wise',
                            colorByPoint: true,

                        data: [ ");


                    //    {
                    //    name: 'Proprietary or Undetectable',
                    //    y: 0.2,
                    //    drilldown: null
                    //    }

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        if (i == count_dashboard) { str0.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["id"].ToString()).Trim() + "}"); }
                        else { str0.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["id"].ToString()).Trim() + "}, "); }
                    }

                    str0.Append(@" ]  }],  drilldown: { series: [  ");


                    //{
                    //name: 'Opera',
                    //id: 'Opera',
                    //data: [['v12.x',0.34],['v28',0.24]]
                    //}

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        if (i == count_dashboard) { str0.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + " ]}"); }
                        else { str0.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + "]}, "); }
                    }



                    str0.Append(@" ] }}); </script>");



                    lt0.Text = str0.ToString();



















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
                                                hAxis: {
                                                    textStyle : {
                                                            fontSize: 12 // or the number you want
                                                        },
                                                    direction:-1, 
                                                    slantedText:true,
                                                    slantedTextAngle:90
                                                 },
                                                legend: { position: 'right', maxLines: 1 },
                                                chart: {
                                                //title: 'Investment Status By Regional Offices (In Crores)',
                                              //  subtitle: 'Sales, Expenses, and Profit: 2014-2017',
                                                },
                                                bars: 'vertical' // Required for Material Bar Charts.
                                              };

                                var chart = new google.charts.Bar(document.getElementById('dual_x_div'));
                                chart.draw(data, google.charts.Bar.convertOptions(options));
                           } 
                    </script>");

                    lt1.Text = str1.ToString();


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
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        public void GetEmploymentDetails()
        {

            DataSet dsAllottee = new DataSet();
            try
            {

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.UserName = UserName;
                ds = objServiceTimelinesBLL.GetEmploymentData(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];

                if (dt1.Rows.Count > 0)
                {

                    StringBuilder str = new StringBuilder();
                    str.Append(@" <script type='text/javascript'>
                               google.charts.load('current', { 'packages': ['bar'] });
                                  google.charts.setOnLoadCallback(drawStuff);
                function drawStuff() {
            var data = new google.visualization.arrayToDataTable([
                  ['" + dt1.Rows[0][3].ToString() + "', 'Proposed Employment', 'Current Employment'],");



                    int count1 = dt1.Rows.Count - 1;
                    if (dt1.Rows[0][3].ToString() == "Regional Office")
                    {
                        for (int i = 0; i <= count1; i++)
                        {
                            if (i == count1) { str.Append("['" + dt1.Rows[i]["RegionalOffice"].ToString() + "'," + Convert.ToDouble(dt1.Rows[i]["projectedemployment"].ToString()) + " , " + Convert.ToDouble(dt1.Rows[i]["currentemployment"].ToString()) + "] ]);"); }
                            else { str.Append("['" + dt1.Rows[i]["RegionalOffice"].ToString() + "', " + Convert.ToDouble(dt1.Rows[i]["projectedemployment"].ToString()) + ", " + Convert.ToDouble(dt1.Rows[i]["currentemployment"].ToString()) + "],"); }
                        }
                    }

                    else if (dt1.Rows[0][3].ToString() == "Industrial Area")
                    {
                        for (int i = 0; i <= count1; i++)
                        {
                            if (i == count1) { str.Append("['" + dt1.Rows[i]["IAName"].ToString() + "'," + Convert.ToDouble(dt1.Rows[i]["projectedemployment"].ToString()) + " , " + Convert.ToDouble(dt1.Rows[i]["currentemployment"].ToString()) + "] ]);"); }
                            else { str.Append("['" + dt1.Rows[i]["IAName"].ToString() + "', " + Convert.ToDouble(dt1.Rows[i]["projectedemployment"].ToString()) + ", " + Convert.ToDouble(dt1.Rows[i]["currentemployment"].ToString()) + "],"); }
                        }
                    }
                    str.Append(@" var options = {
                hAxis: {
                    title: 'Departamentos',
                    titleTextStyle: {
                        color: '#FF0000',
                    },

                    slantedText: true,
                    slantedTextAngle: 45,

                },
                vAxis: {
                    title: 'Kits'
                },
                chart: {
                    
                },
                bars: 'vertical', // Required for Material Bar Charts.
                bar: {groupWidth: '45%'},
                series: {
                    0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
                    1: { axis: 'brightness' } // Bind series 1 to an axis named 'brightness'.
                },
                axes: {
                    x: {
                        distance: { label: 'parsecs' }, // Bottom x-axis.
                        brightness: { side: 'top', label: 'apparent magnitude' } // Top x-axis.
                    }
                }
            };

            var chart = new google.charts.Bar(document.getElementById('dual_x_div1'));
            chart.draw(data, options);
        };
    </script>");

                    lt2.Text = str.ToString();


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        #endregion

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Regex.Replace(e.Row.Cells[1].Text, txtsearch.Text.Trim(), delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }


    }
}