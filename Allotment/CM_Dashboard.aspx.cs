using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class LandingPage : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";



        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            if (!IsPostBack)
            {
                lblUsername.Text = Session["UserName"].ToString();
                lblCompanyId.Text = Session["Companyid"].ToString();
                lblCompanyName.Text = Session["CompanyName"].ToString();
            }


            if (!IsPostBack)
            {
                bindCompanyName();
                GetNewAllotteeDetails();

                GetunallottedplotList("", "", "");
                GetProductionNotStarted("", "", "");
                GetSickUnits("", "", "");
            }

        }

        public void GetunallottedplotList(string inCorporationID, string inCorporationName, string insearchText)
        {
            DataSet dsR = new DataSet();
            try
            {

                if (!string.IsNullOrEmpty(inCorporationID.ToString()))
                {
                    objServiceTimelinesBEL.CorporationID = inCorporationID;
                }

                if (!string.IsNullOrEmpty(insearchText))
                {
                    objServiceTimelinesBEL.searchText = insearchText;
                }


                if (!string.IsNullOrEmpty(inCorporationName))
                {
                    objServiceTimelinesBEL.CorporationName = inCorporationName;
                }



                dsR = objServiceTimelinesBLL.GetVacentPlotDetailForCM(objServiceTimelinesBEL);
                DataTable dt = dsR.Tables[0];
                gridlistunallottedplot.DataSource = dt;
                gridlistunallottedplot.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        public void GetProductionNotStarted(string inCorporationID, string inCorporationName, string insearchText)
        {
            DataSet dsR = new DataSet();
            try
            {

                if (!string.IsNullOrEmpty(inCorporationID.ToString()))
                {
                    objServiceTimelinesBEL.CorporationID = inCorporationID;
                }

                if (!string.IsNullOrEmpty(insearchText))
                {
                    objServiceTimelinesBEL.searchText = insearchText;
                }

                if (!string.IsNullOrEmpty(inCorporationName))
                {
                    objServiceTimelinesBEL.CorporationName = inCorporationName;
                }



                dsR = objServiceTimelinesBLL.GetProductionNotStarted(objServiceTimelinesBEL);
                DataTable dt = dsR.Tables[0];
                grdProductionNotStarted.DataSource = dt;
                grdProductionNotStarted.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        public void GetSickUnits(string inCorporationID, string inCorporationName, string insearchText)
        {
            DataSet dsR = new DataSet();
            try
            {

                if (!string.IsNullOrEmpty(inCorporationID.ToString()))
                {
                    objServiceTimelinesBEL.CorporationID = inCorporationID;
                }

                if (!string.IsNullOrEmpty(insearchText))
                {
                    objServiceTimelinesBEL.searchText = insearchText;
                }


                if (!string.IsNullOrEmpty(inCorporationName))
                {
                    objServiceTimelinesBEL.CorporationName = inCorporationName;
                }



                dsR = objServiceTimelinesBLL.GetSickUnits(objServiceTimelinesBEL);
                DataTable dt = dsR.Tables[0];
                grdSickUnits.DataSource = dt;
                grdSickUnits.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text.Trim() == "UPSIDC") { e.Row.CssClass = "tr-upsidc"; }
                else if (e.Row.Cells[0].Text.Trim() == "GNIDA") { e.Row.CssClass = "tr-gnida"; }
                else if (e.Row.Cells[0].Text.Trim() == "YEIDA") { e.Row.CssClass = "tr-yeida"; }
                else if (e.Row.Cells[0].Text.Trim() == "NOIDA") { e.Row.CssClass = "tr-noida"; }
                else if (e.Row.Cells[0].Text.Trim() == "TOTAL") { e.Row.CssClass = "tr-total"; }
            }
        }

        protected void GridView_UnAllotted_plot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewRow")
            {
                string inCorporationCode = (e.CommandArgument).ToString().Trim();
                string search_sting = "";

                if (inCorporationCode == "TOTAL") { inCorporationCode = ""; }

                GetunallottedplotList("", inCorporationCode, search_sting);
            }

        }

        protected void GridView_sickunit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewRow")
            {
                string inCorporationCode = (e.CommandArgument).ToString().Trim();
                string search_sting = "";

                if (inCorporationCode == "TOTAL") { inCorporationCode = ""; }
                GetSickUnits("", inCorporationCode, search_sting);
            }

        }

        protected void GridView_production_notstarted_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewRow")
            {
                string inCorporationCode = (e.CommandArgument).ToString().Trim();
                string search_sting = "";
                if (inCorporationCode == "TOTAL") { inCorporationCode = ""; }
                GetProductionNotStarted("", inCorporationCode, search_sting);
            }

        }

        public void GetNewAllotteeDetails()
        {

            Literal1.Text = "";

            DataSet dsAllottee = new DataSet();
            try
            {

                DataSet ds = new DataSet();
                objServiceTimelinesBEL.UserName = UserName;
                objServiceTimelinesBEL.searchText = "";
                objServiceTimelinesBEL.Companyid = "";

                ds = objServiceTimelinesBLL.GetCMDashboard(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];
                DataTable dt4 = ds.Tables[3];



                DataTable dt5 = ds.Tables[4];
                DataTable dt6 = ds.Tables[5];
                DataTable dt7 = ds.Tables[6];
                DataTable dt8 = ds.Tables[7];




                //                gridsummary.DataSource = dt1; gridsummary.DataBind();

                StringBuilder str1 = new StringBuilder();
                StringBuilder str2 = new StringBuilder();
                StringBuilder str3 = new StringBuilder();
                StringBuilder str4 = new StringBuilder();


                StringBuilder str5 = new StringBuilder();
                StringBuilder str6 = new StringBuilder();
                StringBuilder str7 = new StringBuilder();
                StringBuilder str8 = new StringBuilder();


                DataTable dt_UnAllotted_plot = ds.Tables[8];
                DataTable dt_land_use = ds.Tables[9];
                DataTable dt_production_notstarted = ds.Tables[10];
                DataTable dt_sickunit = ds.Tables[11];
                DataTable dt_Industrial = ds.Tables[12];

                GridView_UnAllotted_plot.DataSource = dt_UnAllotted_plot;
                GridView_UnAllotted_plot.DataBind();

                GridView_land_use_1.DataSource = dt_land_use;
                GridView_land_use_2.DataSource = dt_land_use;
                GridView_land_use_3.DataSource = dt_land_use;
                GridView_land_use_4.DataSource = dt_land_use;

                GridView_land_use_1.DataBind();
                GridView_land_use_2.DataBind();
                GridView_land_use_3.DataBind();
                GridView_land_use_4.DataBind();



                GridView_production_notstarted.DataSource = dt_production_notstarted;
                GridView_production_notstarted.DataBind();

                GridView_sickunit.DataSource = dt_sickunit;
                GridView_sickunit.DataBind();

                GridlistIndustrial.DataSource = dt_Industrial;
                GridlistIndustrial.DataBind();

                sum_unalloted_plot.Text = dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
                sum_production_not_started.Text = dt_production_notstarted.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
                sum_sick_unit.Text = dt_sickunit.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();


                //   sum_unalloted_plot.Text = dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
                //   dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();



                land_use_upsid.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["UPSIDC"])).ToString();
                land_use_noida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["GNIDA"])).ToString();
                land_use_gnida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["NOIDA"])).ToString();
                land_use_yeida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["YEIDA"])).ToString();

                land_use_all.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["UPSIDC"]) + Convert.ToDecimal(x["GNIDA"]) + Convert.ToDecimal(x["NOIDA"]) + Convert.ToDecimal(x["YEIDA"])).ToString();



                if (dt1.Rows.Count > 0)
                {
                    int count_dashboard = dt1.Rows.Count - 1;

                    str1.Append(@"<script type=""text/javascript"">
                         // Create the chart
                        Highcharts.chart('container1', {
                        chart:{type: 'column'},
                    title:
                        { text: ''
                         },
                    subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
                        },
                    xAxis:{type: 'category'},
                    yAxis:{title:{text: 'Plot Area In Acre'}},
                    legend: {enabled: false},
                    plotOptions:
                        {
                            series: 
                            { borderWidth: 0,
                            dataLabels:  { enabled: true, format: '{point.y:.1f}'  }
                            }
                        },

                    tooltip:
                        {
                            headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
                            pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres  <br/>'
                         },

                    series: [{  name: 'Corporation/Authority', colorByPoint: true,

                        data: [ ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {

                        string company_str = dt1.Rows[i]["name"].ToString().Trim();

                        if (company_str == "UPSIDC")
                        {
                            if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "NOIDA")
                        {
                            if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "GNIDA")
                        {
                            if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "YEIDA")
                        {
                            if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }


                    }

                    str1.Append(@" ]  }],  drilldown: { series: [  ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt1.Rows[i]["data"].ToString()) + " ]}"); }
                        else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt1.Rows[i]["data"].ToString()) + "]}, "); }
                    }

                    str1.Append(@" ] }}); </script>");

                    Literal1.Text = str1.ToString();

                }





                if (dt2.Rows.Count > 0)
                {
                    int count_dashboard = dt2.Rows.Count - 1;

                    str2.Append(@"<script type=""text/javascript"">
                         // Create the chart
                        Highcharts.chart('container2', {
                        chart:{type: 'column'},
                    title:
                        { text: ''},
                    subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
                        },
                    xAxis:{type: 'category'},
                    yAxis:{title:{text: 'Plot Area In Acre'}},
                    legend: {enabled: false},
                    plotOptions:
                        {
                            series: 
                            { borderWidth: 0,
                            dataLabels:  { enabled: true, format: '{point.y:.1f}'  }
                            }
                        },

                    tooltip:
                        {
                            headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
                            pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres <br/>'
                         },

                    series: [{  name: 'Corporation/Authority', colorByPoint: true,

                        data: [ ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {


                        string company_str = dt2.Rows[i]["name"].ToString().Trim();

                        if (company_str == "UPSIDC")
                        {
                            if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "NOIDA")
                        {
                            if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "GNIDA")
                        {
                            if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "YEIDA")
                        {
                            if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                    }

                    str2.Append(@" ]  }],  drilldown: { series: [  ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt2.Rows[i]["data"].ToString()) + " ]}"); }
                        else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt2.Rows[i]["data"].ToString()) + "]}, "); }
                    }

                    str2.Append(@" ] }}); </script>");

                    Literal2.Text = str2.ToString();

                }




                if (dt3.Rows.Count > 0)
                {
                    int count_dashboard = dt3.Rows.Count - 1;

                    str3.Append(@"<script type=""text/javascript"">
                         // Create the chart
                        Highcharts.chart('container3', {
                        chart:{type: 'column'},
                    title:
                        { text: ''},
                    subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
                        },
                    xAxis:{type: 'category'},
                    yAxis:{title:{text: 'Plot Area In Acre'}},
                    legend: {enabled: false},
                    plotOptions:
                        {
                            series: 
                            { borderWidth: 0,
                            dataLabels:  { enabled: true, format: '{point.y}'  }
                            }
                        },

                    tooltip:
                        {
                            headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
                            pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres <br/>'
                         },

                    series: [{  name: 'Corporation/Authority', colorByPoint: true,

                        data: [ ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {



                        string company_str = dt3.Rows[i]["name"].ToString().Trim();

                        if (company_str == "UPSIDC")
                        {
                            if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "NOIDA")
                        {
                            if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "GNIDA")
                        {
                            if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }

                        else if (company_str == "YEIDA")
                        {
                            if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
                            else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
                        }


                    }

                    str3.Append(@" ]  }],  drilldown: { series: [  ");


                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt3.Rows[i]["data"].ToString()) + " ]}"); }
                        else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt3.Rows[i]["data"].ToString()) + "]}, "); }
                    }

                    str3.Append(@" ] }}); </script>");

                    Literal3.Text = str3.ToString();

                }





                if (dt4.Rows.Count > 0)
                {
                    // int count_dashboard = dt4.Rows.Count - 1;

                    Allottee_master_grid.DataSource = dt4; Allottee_master_grid.DataBind();


                    //str4.Append(@"<script type=""text/javascript"">
                    //     // Create the chart
                    //    Highcharts.chart('container4', {
                    //    chart:{type: 'column'},
                    //title:
                    //    { text: ''},
                    //subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
                    //    },
                    //xAxis:{type: 'category'},
                    //yAxis:{title:{text: 'Plot Area In Acre'}},
                    //legend: {enabled: false},
                    //plotOptions:
                    //    {
                    //        series: 
                    //        { borderWidth: 0,
                    //        dataLabels:  { enabled: true, format: '{point.y}'  }
                    //        }
                    //    },

                    //tooltip:
                    //    {
                    //        headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
                    //        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres  <br/>'
                    //     },

                    //series: [{  name: 'Corporation/Authority', colorByPoint: true,

                    //    data: [ ");


                    //for (int i = 0; i <= count_dashboard; i++)
                    //{
                    //    if (i == count_dashboard) { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["value"].ToString()).Trim() + "}"); }
                    //    else { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["value"].ToString()).Trim() + "}, "); }
                    //}

                    //str4.Append(@" ]  }],  drilldown: { series: [  ");


                    //for (int i = 0; i <= count_dashboard; i++)
                    //{
                    //    if (i == count_dashboard) { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + " ]}"); }
                    //    else { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + "]}, "); }
                    //}

                    //str4.Append(@" ] }}); </script>");

                    //Literal4.Text = str4.ToString();

                }
                if (dt5.Rows.Count > 0)
                {
                    int count_dashboard = dt5.Rows.Count - 1;

                    str5.Append(@"<script>
        Highcharts.chart('GUAGE_UPSIDC', {
        chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        title: {
        text: 'Browser<br>shares<br>2015',
        align: 'center',
        verticalAlign: 'middle',
        y: 40
               },
    tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
    plotOptions: {
        pie: {
            dataLabels: {
                enabled: true,
                distance: -10,
                style: { fontWeight: 'bold', color: 'white'}
            },
            startAngle: -90, endAngle: 90,  center: ['75%', '75%']
        }
    },
    series: [{
        type: 'pie',
        name: 'Browser share',
        innerSize: '30%',
        data: [");

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        str5.Append("" + (dt5.Rows[i]["data"].ToString()) + ", ");
                    }

                    str5.Append(@" {
                            name: 'Proprietary or Undetectable',
                            y: 0.2,
                            dataLabels: {
                            enabled: false
                }
            }
        ]
    }]
        });</script>");

                    Literal5.Text = str5.ToString();
                }

                if (dt6.Rows.Count > 0)
                {
                    int count_dashboard = dt6.Rows.Count - 1;

                    str6.Append(@"<script>
        Highcharts.chart('GUAGE_NOIDA', {
        chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        title: {
        text: 'Browser<br>shares<br>2015',
        align: 'center',
        verticalAlign: 'middle',
        y: 40
               },
    tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
    plotOptions: {
        pie: {
            dataLabels: {
                enabled: true,
                distance: -50,
                style: { fontWeight: 'bold', color: 'white'}
            },
            startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        }
    },
    series: [{
        type: 'pie',
        name: 'Browser share',
        innerSize: '50%',
        data: [");

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        str6.Append("" + (dt6.Rows[i]["data"].ToString()) + ", ");
                    }

                    str6.Append(@" {
                            name: 'Proprietary or Undetectable',
                            y: 0.2,
                            dataLabels: {
                            enabled: false
                }
            }
        ]
    }]
        });</script>");

                    Literal6.Text = str6.ToString();
                }

                if (dt7.Rows.Count > 0)
                {
                    int count_dashboard = dt7.Rows.Count - 1;

                    str7.Append(@"<script>
        Highcharts.chart('GUAGE_GNIDA', {
        chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        title: {
        text: 'Browser<br>shares<br>2015',
        align: 'center',
        verticalAlign: 'middle',
        y: 40
               },
    tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
    plotOptions: {
        pie: {
            dataLabels: {
                enabled: true,
                distance: -50,
                style: { fontWeight: 'bold', color: 'white'}
            },
            startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        }
    },
    series: [{
        type: 'pie',
        name: 'Browser share',
        innerSize: '50%',
        data: [");

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        str7.Append("" + (dt7.Rows[i]["data"].ToString()) + ", ");
                    }

                    str7.Append(@" {
                            name: 'Proprietary or Undetectable',
                            y: 0.2,
                            dataLabels: {
                            enabled: false
                }
            }
        ]
    }]
        });</script>");

                    Literal7.Text = str7.ToString();
                }

                if (dt8.Rows.Count > 0)
                {
                    int count_dashboard = dt8.Rows.Count - 1;

                    str8.Append(@"<script>
        Highcharts.chart('GUAGE_YAMUNA', {
        chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        title: {
        text: 'Browser<br>shares<br>2015',
        align: 'center',
        verticalAlign: 'middle',
        y: 40
               },
    tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
    plotOptions: {
        pie: {
            dataLabels: {
                enabled: true,
                distance: -50,
                style: { fontWeight: 'bold', color: 'white'}
            },
            startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        }
    },
    series: [{
        type: 'pie',
        name: 'Browser share',
        innerSize: '50%',
        data: [");

                    for (int i = 0; i <= count_dashboard; i++)
                    {
                        str8.Append("" + (dt8.Rows[i]["data"].ToString()) + ", ");
                    }

                    str8.Append(@" {
                            name: 'Proprietary or Undetectable',
                            y: 0.2,
                            dataLabels: {
                            enabled: false
                }
            }
        ]
    }]
        });</script>");

                    Literal8.Text = str8.ToString();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        public void ClearAll()
        {
            //lblMessage.Text = string.Empty;
            //txtUserName.Text = string.Empty;
        }
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
        //    objServiceTimelinesBEL.Password = txtPwd.Text.Trim();

        //    if (!string.IsNullOrEmpty(txtPwd.Text.Trim()) && !string.IsNullOrEmpty(txtPwd.Text.Trim()))
        //    {
        //        int retVal = objServiceTimelinesBLL.CM_CheckLogin(objServiceTimelinesBEL);

        //        if ((retVal == 0) & (objServiceTimelinesBEL.responseMessage.ToString() == "User successfully logged in"))
        //        {

        //            DataSet dsR = new DataSet();
        //            try
        //            {
        //                objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
        //                dsR = objServiceTimelinesBLL.GetCMUserCompany(objServiceTimelinesBEL);
        //                DataTable dt = dsR.Tables[0];
        //                if (dt.Rows.Count > 0)
        //                {
        //                    string UserName = dt.Rows[0]["UserName"].ToString();
        //                    string Companyid = dt.Rows[0]["CorporationID"].ToString();
        //                    string CompanyName = dt.Rows[0]["AuthortyName"].ToString();
        //                    LoginInfo _objLoginInfo = new LoginInfo(UserName, Companyid);
        //                    Session["objLoginInfo"] = _objLoginInfo;

        //                    Session["UserName"] = UserName;
        //                    Session["Companyid"] = Companyid;
        //                    Session["CompanyName"] = CompanyName;

        //                    Response.Redirect("CM_Dashboard.aspx", false);


        //                }



        //            }
        //            catch (Exception ex)
        //            {
        //                Response.Write("Oops! error occured :" + ex.Message.ToString());
        //            }

        //        }
        //        else
        //        {
        //            lblMessage.Text = objServiceTimelinesBEL.responseMessage.ToString();
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //        }

        //    }

        //}

        private void bindCompanyName()
        {
            DataSet dsR = new DataSet();
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


                SqlCommand cmd = new SqlCommand("[spGetAuthorityDetail] 'Admin' , '1' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlAuthority.DataSource = dt;
                ddlAuthority.DataTextField = "code";
                ddlAuthority.DataValueField = "id";
                ddlAuthority.DataBind();
                ddlAuthority.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlAuthorityName.DataSource = dt;
                ddlAuthorityName.DataTextField = "code";
                ddlAuthorityName.DataValueField = "id";
                ddlAuthorityName.DataBind();
                ddlAuthorityName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {




            DataSet dsAllottee = new DataSet();


            DataSet ds = new DataSet();

            objServiceTimelinesBEL.UserName = UserName;
            objServiceTimelinesBEL.searchText = "";
            objServiceTimelinesBEL.Companyid = ddlAuthority.SelectedValue.ToString().Trim();


            ds = objServiceTimelinesBLL.GetCMDashboard(objServiceTimelinesBEL);


            DataTable dt4 = ds.Tables[3];

            if (dt4.Rows.Count > 0)
            {
                Allottee_master_grid.DataSource = dt4; Allottee_master_grid.DataBind();

            }
            else
            {
                Allottee_master_grid.DataBind();

            }

        }

        protected void ddlAuthorityName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsAllottee = new DataSet();
            DataSet ds = new DataSet();
            objServiceTimelinesBEL.UserName = UserName;
            objServiceTimelinesBEL.searchText = "";
            objServiceTimelinesBEL.Companyid = ddlAuthorityName.SelectedValue.ToString().Trim();
            ds = objServiceTimelinesBLL.GetCMDashboard(objServiceTimelinesBEL);
            DataTable dt12 = ds.Tables[12];
            if (dt12.Rows.Count > 0)
            {
                GridlistIndustrial.DataSource = dt12;
                GridlistIndustrial.DataBind();

            }
            else
            {
                GridlistIndustrial.DataBind();

            }

        }

        protected void gridlistunallottedplot_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdSickUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        //    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            if (e.Row.Cells[0].Text.Trim() == "UPSIDC") { e.Row.CssClass = "tr-upsidc"; }
        //            else if (e.Row.Cells[0].Text.Trim() == "GNIDA") { e.Row.CssClass = "tr-gnida"; }
        //            else if (e.Row.Cells[0].Text.Trim() == "YEIDA") { e.Row.CssClass = "tr-yeida"; }
        //            else if (e.Row.Cells[0].Text.Trim() == "NOIDA") { e.Row.CssClass = "tr-noida"; }
        //            else if (e.Row.Cells[0].Text.Trim() == "TOTAL") { e.Row.CssClass = "tr-total"; }
        //        }
        //    }

        //    public void GetNewAllotteeDetails()
        //    {

        //        Literal1.Text = "";

        //        DataSet dsAllottee = new DataSet();
        //        try
        //        {

        //            DataSet ds = new DataSet();
        //            objServiceTimelinesBEL.UserName = UserName;
        //            objServiceTimelinesBEL.searchText = "";
        //            objServiceTimelinesBEL.Companyid = "";

        //            ds = objServiceTimelinesBLL.GetCMDashboard(objServiceTimelinesBEL);
        //            DataTable dt1 = ds.Tables[0];
        //            DataTable dt2 = ds.Tables[1];
        //            DataTable dt3 = ds.Tables[2];
        //            DataTable dt4 = ds.Tables[3];



        //            DataTable dt5 = ds.Tables[4];
        //            DataTable dt6 = ds.Tables[5];
        //            DataTable dt7 = ds.Tables[6];
        //            DataTable dt8 = ds.Tables[7];




        //            //                gridsummary.DataSource = dt1; gridsummary.DataBind();

        //            StringBuilder str1 = new StringBuilder();
        //            StringBuilder str2 = new StringBuilder();
        //            StringBuilder str3 = new StringBuilder();
        //            StringBuilder str4 = new StringBuilder();


        //            StringBuilder str5 = new StringBuilder();
        //            StringBuilder str6 = new StringBuilder();
        //            StringBuilder str7 = new StringBuilder();
        //            StringBuilder str8 = new StringBuilder();


        //            DataTable dt_UnAllotted_plot = ds.Tables[8];
        //            DataTable dt_land_use = ds.Tables[9];
        //            DataTable dt_production_notstarted = ds.Tables[10];
        //            DataTable dt_sickunit = ds.Tables[11];


        //            GridView_UnAllotted_plot.DataSource = dt_UnAllotted_plot;
        //            GridView_UnAllotted_plot.DataBind();

        //            GridView_land_use_1.DataSource = dt_land_use;
        //            GridView_land_use_2.DataSource = dt_land_use;
        //            GridView_land_use_3.DataSource = dt_land_use;
        //            GridView_land_use_4.DataSource = dt_land_use;

        //            GridView_land_use_1.DataBind();
        //            GridView_land_use_2.DataBind();
        //            GridView_land_use_3.DataBind();
        //            GridView_land_use_4.DataBind();



        //            GridView_production_notstarted.DataSource = dt_production_notstarted;
        //            GridView_production_notstarted.DataBind();

        //            GridView_sickunit.DataSource = dt_sickunit;
        //            GridView_sickunit.DataBind();


        //            sum_unalloted_plot.Text = dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
        //            sum_production_not_started.Text = dt_production_notstarted.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
        //            sum_sick_unit.Text = dt_sickunit.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();


        //            //   sum_unalloted_plot.Text = dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();
        //            //   dt_UnAllotted_plot.AsEnumerable().Sum(x => Convert.ToDecimal(x["In Acres"])).ToString();



        //            land_use_upsid.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["UPSIDC"])).ToString();
        //            land_use_noida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["GNIDA"])).ToString();
        //            land_use_gnida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["NOIDA"])).ToString();
        //            land_use_yeida.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["YEIDA"])).ToString();

        //            land_use_all.Text = dt_land_use.AsEnumerable().Sum(x => Convert.ToDecimal(x["UPSIDC"]) + Convert.ToDecimal(x["GNIDA"]) + Convert.ToDecimal(x["NOIDA"]) + Convert.ToDecimal(x["YEIDA"])).ToString();



        //            if (dt1.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt1.Rows.Count - 1;

        //                str1.Append(@"<script type=""text/javascript"">
        //                     // Create the chart
        //                    Highcharts.chart('container1', {
        //                    chart:{type: 'column'},
        //                title:
        //                    { text: ''
        //                     },
        //                subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
        //                    },
        //                xAxis:{type: 'category'},
        //                yAxis:{title:{text: 'Plot Area In Acre'}},
        //                legend: {enabled: false},
        //                plotOptions:
        //                    {
        //                        series: 
        //                        { borderWidth: 0,
        //                        dataLabels:  { enabled: true, format: '{point.y:.1f}'  }
        //                        }
        //                    },

        //                tooltip:
        //                    {
        //                        headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
        //                        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres  <br/>'
        //                     },

        //                series: [{  name: 'Corporation/Authority', colorByPoint: true,

        //                    data: [ ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {

        //                    string company_str = dt1.Rows[i]["name"].ToString().Trim();

        //                    if (company_str == "UPSIDC")
        //                    {
        //                        if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "NOIDA")
        //                    {
        //                        if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "GNIDA")
        //                    {
        //                        if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "YEIDA")
        //                    {
        //                        if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt1.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }


        //                }

        //                str1.Append(@" ]  }],  drilldown: { series: [  ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    if (i == count_dashboard) { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt1.Rows[i]["data"].ToString()) + " ]}"); }
        //                    else { str1.Append("{ name: '" + dt1.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt1.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt1.Rows[i]["data"].ToString()) + "]}, "); }
        //                }

        //                str1.Append(@" ] }}); </script>");

        //                Literal1.Text = str1.ToString();

        //            }





        //            if (dt2.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt2.Rows.Count - 1;

        //                str2.Append(@"<script type=""text/javascript"">
        //                     // Create the chart
        //                    Highcharts.chart('container2', {
        //                    chart:{type: 'column'},
        //                title:
        //                    { text: ''},
        //                subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
        //                    },
        //                xAxis:{type: 'category'},
        //                yAxis:{title:{text: 'Plot Area In Acre'}},
        //                legend: {enabled: false},
        //                plotOptions:
        //                    {
        //                        series: 
        //                        { borderWidth: 0,
        //                        dataLabels:  { enabled: true, format: '{point.y:.1f}'  }
        //                        }
        //                    },

        //                tooltip:
        //                    {
        //                        headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
        //                        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres <br/>'
        //                     },

        //                series: [{  name: 'Corporation/Authority', colorByPoint: true,

        //                    data: [ ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {


        //                    string company_str = dt2.Rows[i]["name"].ToString().Trim();

        //                    if (company_str == "UPSIDC")
        //                    {
        //                        if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "NOIDA")
        //                    {
        //                        if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "GNIDA")
        //                    {
        //                        if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "YEIDA")
        //                    {
        //                        if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt2.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                }

        //                str2.Append(@" ]  }],  drilldown: { series: [  ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    if (i == count_dashboard) { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt2.Rows[i]["data"].ToString()) + " ]}"); }
        //                    else { str2.Append("{ name: '" + dt2.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt2.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt2.Rows[i]["data"].ToString()) + "]}, "); }
        //                }

        //                str2.Append(@" ] }}); </script>");

        //                Literal2.Text = str2.ToString();

        //            }




        //            if (dt3.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt3.Rows.Count - 1;

        //                str3.Append(@"<script type=""text/javascript"">
        //                     // Create the chart
        //                    Highcharts.chart('container3', {
        //                    chart:{type: 'column'},
        //                title:
        //                    { text: ''},
        //                subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
        //                    },
        //                xAxis:{type: 'category'},
        //                yAxis:{title:{text: 'Plot Area In Acre'}},
        //                legend: {enabled: false},
        //                plotOptions:
        //                    {
        //                        series: 
        //                        { borderWidth: 0,
        //                        dataLabels:  { enabled: true, format: '{point.y}'  }
        //                        }
        //                    },

        //                tooltip:
        //                    {
        //                        headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
        //                        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres <br/>'
        //                     },

        //                series: [{  name: 'Corporation/Authority', colorByPoint: true,

        //                    data: [ ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {



        //                    string company_str = dt3.Rows[i]["name"].ToString().Trim();

        //                    if (company_str == "UPSIDC")
        //                    {
        //                        if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#368EE0' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "NOIDA")
        //                    {
        //                        if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#F8A31F' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "GNIDA")
        //                    {
        //                        if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#00ABA9' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }

        //                    else if (company_str == "YEIDA")
        //                    {
        //                        if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                        else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', color:'#E671B8' , drilldown: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt3.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                    }


        //                }

        //                str3.Append(@" ]  }],  drilldown: { series: [  ");


        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    if (i == count_dashboard) { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt3.Rows[i]["data"].ToString()) + " ]}"); }
        //                    else { str3.Append("{ name: '" + dt3.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt3.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt3.Rows[i]["data"].ToString()) + "]}, "); }
        //                }

        //                str3.Append(@" ] }}); </script>");

        //                Literal3.Text = str3.ToString();

        //            }





        //            if (dt4.Rows.Count > 0)
        //            {
        //                // int count_dashboard = dt4.Rows.Count - 1;

        //                Allottee_master_grid.DataSource = dt4; Allottee_master_grid.DataBind();


        //                //str4.Append(@"<script type=""text/javascript"">
        //                //     // Create the chart
        //                //    Highcharts.chart('container4', {
        //                //    chart:{type: 'column'},
        //                //title:
        //                //    { text: ''},
        //                //subtitle: {//text: 'Click the columns to view versions. Source: <a href=""http://netmarketshare.com"">netmarketshare.com</a>.'
        //                //    },
        //                //xAxis:{type: 'category'},
        //                //yAxis:{title:{text: 'Plot Area In Acre'}},
        //                //legend: {enabled: false},
        //                //plotOptions:
        //                //    {
        //                //        series: 
        //                //        { borderWidth: 0,
        //                //        dataLabels:  { enabled: true, format: '{point.y}'  }
        //                //        }
        //                //    },

        //                //tooltip:
        //                //    {
        //                //        headerFormat: '<span style=""font-size:11px"">{series.name}</span><br>',
        //                //        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}</b> in Acres  <br/>'
        //                //     },

        //                //series: [{  name: 'Corporation/Authority', colorByPoint: true,

        //                //    data: [ ");


        //                //for (int i = 0; i <= count_dashboard; i++)
        //                //{
        //                //    if (i == count_dashboard) { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["value"].ToString()).Trim() + "}"); }
        //                //    else { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', drilldown: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , y:" + (dt4.Rows[i]["value"].ToString()).Trim() + "}, "); }
        //                //}

        //                //str4.Append(@" ]  }],  drilldown: { series: [  ");


        //                //for (int i = 0; i <= count_dashboard; i++)
        //                //{
        //                //    if (i == count_dashboard) { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id: '" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + " ]}"); }
        //                //    else { str4.Append("{ name: '" + dt4.Rows[i]["name"].ToString().Trim() + "', id:'" + (dt4.Rows[i]["name"].ToString()).Trim() + "' , data: [" + (dt4.Rows[i]["data"].ToString()) + "]}, "); }
        //                //}

        //                //str4.Append(@" ] }}); </script>");

        //                //Literal4.Text = str4.ToString();

        //            }





        //            if (dt5.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt5.Rows.Count - 1;

        //                str5.Append(@"<script>
        //    Highcharts.chart('GUAGE_UPSIDC', {
        //    chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        //    title: {
        //    text: 'Browser<br>shares<br>2015',
        //    align: 'center',
        //    verticalAlign: 'middle',
        //    y: 40
        //           },
        //tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
        //plotOptions: {
        //    pie: {
        //        dataLabels: {
        //            enabled: true,
        //            distance: -10,
        //            style: { fontWeight: 'bold', color: 'white'}
        //        },
        //        startAngle: -90, endAngle: 90,  center: ['75%', '75%']
        //    }
        //},
        //series: [{
        //    type: 'pie',
        //    name: 'Browser share',
        //    innerSize: '30%',
        //    data: [");

        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    str5.Append("" + (dt5.Rows[i]["data"].ToString()) + ", ");
        //                }

        //                str5.Append(@" {
        //                        name: 'Proprietary or Undetectable',
        //                        y: 0.2,
        //                        dataLabels: {
        //                        enabled: false
        //            }
        //        }
        //    ]
        //}]
        //    });</script>");

        //                Literal5.Text = str5.ToString();
        //            }




        //            if (dt6.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt6.Rows.Count - 1;

        //                str6.Append(@"<script>
        //    Highcharts.chart('GUAGE_NOIDA', {
        //    chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        //    title: {
        //    text: 'Browser<br>shares<br>2015',
        //    align: 'center',
        //    verticalAlign: 'middle',
        //    y: 40
        //           },
        //tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
        //plotOptions: {
        //    pie: {
        //        dataLabels: {
        //            enabled: true,
        //            distance: -50,
        //            style: { fontWeight: 'bold', color: 'white'}
        //        },
        //        startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        //    }
        //},
        //series: [{
        //    type: 'pie',
        //    name: 'Browser share',
        //    innerSize: '50%',
        //    data: [");

        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    str6.Append("" + (dt6.Rows[i]["data"].ToString()) + ", ");
        //                }

        //                str6.Append(@" {
        //                        name: 'Proprietary or Undetectable',
        //                        y: 0.2,
        //                        dataLabels: {
        //                        enabled: false
        //            }
        //        }
        //    ]
        //}]
        //    });</script>");

        //                Literal6.Text = str6.ToString();
        //            }







        //            if (dt7.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt7.Rows.Count - 1;

        //                str7.Append(@"<script>
        //    Highcharts.chart('GUAGE_GNIDA', {
        //    chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        //    title: {
        //    text: 'Browser<br>shares<br>2015',
        //    align: 'center',
        //    verticalAlign: 'middle',
        //    y: 40
        //           },
        //tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
        //plotOptions: {
        //    pie: {
        //        dataLabels: {
        //            enabled: true,
        //            distance: -50,
        //            style: { fontWeight: 'bold', color: 'white'}
        //        },
        //        startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        //    }
        //},
        //series: [{
        //    type: 'pie',
        //    name: 'Browser share',
        //    innerSize: '50%',
        //    data: [");

        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    str7.Append("" + (dt7.Rows[i]["data"].ToString()) + ", ");
        //                }

        //                str7.Append(@" {
        //                        name: 'Proprietary or Undetectable',
        //                        y: 0.2,
        //                        dataLabels: {
        //                        enabled: false
        //            }
        //        }
        //    ]
        //}]
        //    });</script>");

        //                Literal7.Text = str7.ToString();
        //            }








        //            if (dt8.Rows.Count > 0)
        //            {
        //                int count_dashboard = dt8.Rows.Count - 1;

        //                str8.Append(@"<script>
        //    Highcharts.chart('GUAGE_YAMUNA', {
        //    chart: { plotBackgroundColor: null,  plotBorderWidth: 0,  plotShadow: false },
        //    title: {
        //    text: 'Browser<br>shares<br>2015',
        //    align: 'center',
        //    verticalAlign: 'middle',
        //    y: 40
        //           },
        //tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},
        //plotOptions: {
        //    pie: {
        //        dataLabels: {
        //            enabled: true,
        //            distance: -50,
        //            style: { fontWeight: 'bold', color: 'white'}
        //        },
        //        startAngle: -90, endAngle: 90,  center: ['50%', '75%']
        //    }
        //},
        //series: [{
        //    type: 'pie',
        //    name: 'Browser share',
        //    innerSize: '50%',
        //    data: [");

        //                for (int i = 0; i <= count_dashboard; i++)
        //                {
        //                    str8.Append("" + (dt8.Rows[i]["data"].ToString()) + ", ");
        //                }

        //                str8.Append(@" {
        //                        name: 'Proprietary or Undetectable',
        //                        y: 0.2,
        //                        dataLabels: {
        //                        enabled: false
        //            }
        //        }
        //    ]
        //}]
        //    });</script>");

        //                Literal8.Text = str8.ToString();
        //            }















        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured :" + ex.Message.ToString());
        //        }

        //    }

        //    private void bindCompanyName()
        //    {
        //        DataSet dsR = new DataSet();
        //        try
        //        {

        //            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


        //            SqlCommand cmd = new SqlCommand("[spGetAuthorityDetail] 'Admin' , '1' ", con);
        //            SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            adp.Fill(dt);
        //            ddlAuthority.DataSource = dt;
        //            ddlAuthority.DataTextField = "AuthortyName";
        //            ddlAuthority.DataValueField = "id";
        //            ddlAuthority.DataBind();
        //            ddlAuthority.Items.Insert(0, new ListItem("--Select--", "0"));
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured :" + ex.Message.ToString());
        //        }

        //    }

        //    protected void ddlAuthority_SelectedIndexChanged(object sender, EventArgs e)
        //    {




        //        DataSet dsAllottee = new DataSet();


        //        DataSet ds = new DataSet();

        //        objServiceTimelinesBEL.UserName = UserName;
        //        objServiceTimelinesBEL.searchText = "";
        //        objServiceTimelinesBEL.Companyid = ddlAuthority.SelectedValue.ToString().Trim();


        //        ds = objServiceTimelinesBLL.GetCMDashboard(objServiceTimelinesBEL);


        //        DataTable dt4 = ds.Tables[3];

        //        if (dt4.Rows.Count > 0)
        //        {
        //            Allottee_master_grid.DataSource = dt4; Allottee_master_grid.DataBind();

        //        }
        //        else
        //        {
        //            Allottee_master_grid.DataBind();

        //        }

        //    }






    }

}






