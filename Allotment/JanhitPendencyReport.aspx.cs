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
    public partial class JanhitPendencyReport : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {

                jhanhitLandAllottmentReport();

            }
        }

        private void jhanhitLandAllottmentReport()
        {

            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("[GetjanhitLandAllotmentPendencytest] ", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'>
<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>

<tr>
<tr><th colspan='18' style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;border:1px solid #797979;'>Application Status  Under  Janhit Guarantee Act In UPSIDC</th>
</tr>
<tr>
<th colspan=18  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff; border:1px solid #797979;'>
Land Allotment Application Status  " + DateTime.Now.ToString("dd-MM-yyyy") + "</th>" +
"</tr>" +
 "<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='4'> SNO </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' rowspan='4'> Regional Office </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' rowspan='4'> Service Name </th> " +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='8'> Date 01-04-2017 To 31-12-2017 </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='8'> From 01-01-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + " </th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='4'> Received Application </th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Dispose</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending%</th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='4'> Received Application </th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Dispose</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending%</th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' colspan='2'>Online</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Offline</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Total</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' colspan='2'>Online</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Offline</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Total</th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Department Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>E-Distict Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Department Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>E-Distict Portal</th>" +
  "<tr style='background-color: #ccc;'>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'></th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>1</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>2</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>3</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>4</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>5</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>6=3+4+5</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>7</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>8</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>9=8/6*100</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>10</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>11</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>12</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>13=10+11+12</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>14</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>15</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>16=15/13*100</th>" +
"</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string RegionalOffice = dt.Rows[i][0].ToString();
                    string ServiceName = dt.Rows[i][1].ToString();
                    string Department = dt.Rows[i][2].ToString();
                    string EDistictPortal = dt.Rows[i][3].ToString();
                    string Offline = dt.Rows[i][4].ToString();
                    string TotalofflineApplication = dt.Rows[i][5].ToString();
                    string TotalDispose = dt.Rows[i][6].ToString();
                    string TotalPennding = dt.Rows[i][7].ToString();
                    string TotalPercentage = dt.Rows[i][8].ToString();
                    string TotalReceived = dt.Rows[i][9].ToString();
                    string EDistictPortalonline = dt.Rows[i][10].ToString();
                    string OfflineUPSIDA = dt.Rows[i][11].ToString();
                    string TotalofflineApplicationUPSIDA = dt.Rows[i][12].ToString();
                    string TotalApproved = dt.Rows[i][13].ToString();
                    string TotalPenndingUPSIDA = dt.Rows[i][14].ToString();
                    string TotalPercentageUPSIDA = dt.Rows[i][15].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + ServiceName + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Department + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + EDistictPortal + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Offline + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalofflineApplication + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalDispose + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPennding + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPercentage + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + EDistictPortalonline + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + OfflineUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalofflineApplicationUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPenndingUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPercentageUPSIDA + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(Department)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(EDistictPortal)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(Offline)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalofflineApplication)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(TotalDispose)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(TotalPennding)", string.Empty).ToString();
                //string total7 = dt.Compute("Sum(TotalPercentage)", string.Empty).ToString();
                string total8 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(EDistictPortalonline)", string.Empty).ToString();
                string total10 = dt.Compute("Sum(OfflineUPSIDA)", string.Empty).ToString();
                string total11 = dt.Compute("Sum(TotalofflineApplicationUPSIDA)", string.Empty).ToString();
                string total12 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total13 = dt.Compute("Sum(TotalPenndingUPSIDA)", string.Empty).ToString();
                //string total14 = dt.Compute("Sum(TotalPercentageUPSIDA)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'>" +
                    "<td colspan='3' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + ((Convert.ToDecimal(total6) * 100) / Convert.ToDecimal(total4)).ToString("0.00") + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total8 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total10 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total11 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total12 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total13 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + ((Convert.ToDecimal(total13) * 100) / Convert.ToDecimal(total8)).ToString("0.00") + "</td>" +
                   "</tr>";
                html += "</table></div>";




                Literal loLit = new Literal();
                loLit.Text = (html);
                ph.Controls.Add(loLit);




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



        private void JhanhitBuildingPlanReport()
        {

            try
            {
                string html = "";

                SqlCommand cmmd;

                cmmd = new SqlCommand("[GetJanhitStatementforBuildingPlantest]", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;


                html = @"

<div  id='TableDiv' class='table table-responsive'>
<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan='18' style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Application Status  Under  Janhit Guarantee Act In UPSIDC</th></tr><tr><th colspan=18  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>
Building Plan Application Status " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
 "<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='4'> SNO </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' rowspan='4'> Regional Office </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' rowspan='4'> Service Name </th> " +
"<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='8'> Date 01-04-2017 To 31-12-2017 </th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='8'> From 01-01-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + " </th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='4'> Received Application </th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Dispose</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending%</th>" +
  "<th style='text-align: center;padding:  0 5px;border:1px solid #797979;' colspan='4'> Received Application </th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Dispose</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending</th>" +
   "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Objection</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='3'>Pending%</th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' colspan='2'>Online</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Offline</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Total</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' colspan='2'>Online</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Offline</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;' rowspan='2'>Total</th>" +
"</tr>" +
"<tr style='background-color: #ccc;'>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Department Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>E-Distict Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Department Portal</th>" +
  "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>E-Distict Portal</th>" +
"<tr style='background-color: #ccc;'>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'></th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>1</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>2</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>3</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>4</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>5</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>6=3+4+5</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>7</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>8</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>9=8/6*100</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>10</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>11</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>12</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>13=10+11+12</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>14</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>15</th>" +
     "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>16</th>" +
    "<th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>17=15/13*100</th>" +
"</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string RegionalOffice = dt.Rows[i][0].ToString();
                    string ServiceName = dt.Rows[i][1].ToString();
                    string Department = dt.Rows[i][2].ToString();
                    string EDistictPortal = dt.Rows[i][3].ToString();
                    string Offline = dt.Rows[i][4].ToString();
                    string TotalofflineApplication = dt.Rows[i][5].ToString();
                    string TotalDispose = dt.Rows[i][6].ToString();
                    string TotalPennding = dt.Rows[i][7].ToString();
                    string TotalPercentage = dt.Rows[i][8].ToString();
                    string TotalReceived = dt.Rows[i][9].ToString();
                    string EDistictPortalonline = dt.Rows[i][10].ToString();
                    string OfflineUPSIDA = dt.Rows[i][11].ToString();
                    string TotalofflineApplicationUPSIDA = dt.Rows[i][12].ToString();
                    string TotalApproved = dt.Rows[i][13].ToString();
                    string TotalPenndingUPSIDA = dt.Rows[i][14].ToString();
                    string Objection = dt.Rows[i][15].ToString();
                    string TotalPercentageUPSIDA = dt.Rows[i][16].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + ServiceName + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Department + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + EDistictPortal + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Offline + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalofflineApplication + "</td>" +
                        "<td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalDispose + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPennding + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPercentage + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + EDistictPortalonline + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + OfflineUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalofflineApplicationUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPenndingUPSIDA + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Objection + "</td>" +
                        "<td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalPercentageUPSIDA + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(Department)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(EDistictPortal)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(Offline)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalofflineApplication)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(TotalDispose)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(TotalPennding)", string.Empty).ToString();
                //string total7 = dt.Compute("Sum(TotalPercentage)", string.Empty).ToString();
                string total8 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(EDistictPortalonline)", string.Empty).ToString();
                string total10 = dt.Compute("Sum(OfflineUPSIDA)", string.Empty).ToString();
                string total11 = dt.Compute("Sum(TotalofflineApplicationUPSIDA)", string.Empty).ToString();
                string total12 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total13 = dt.Compute("Sum(TotalPenndingUPSIDA)", string.Empty).ToString();
                string total14 = dt.Compute("Sum(Objection)", string.Empty).ToString();
                //string total15 = dt.Compute("Sum(TotalPercentageUPSIDA)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'>" +
                    "<td colspan='3' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + ((Convert.ToDecimal(total6) * 100) / Convert.ToDecimal(total4)).ToString("0.00") + "</td>" +
                    "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total8 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total10 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total11 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total12 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total13 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total14 + "</td>" +
                   "<td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + ((Convert.ToDecimal(total13) * 100) / Convert.ToDecimal(total8)).ToString("0.00") + "</td>" +
                   "</tr>";
                html += "</table></div>";

                Literal loLit = new Literal();
                loLit.Text = (html);
                ph.Controls.Add(loLit);




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpReportName.SelectedValue == "LAPL")
            {
                jhanhitLandAllottmentReport();
            }
            if (drpReportName.SelectedValue == "BPSLA")
            {
                JhanhitBuildingPlanReport();
            }
        }
    }
}