using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PendencyReportCMIANew : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
        }

        private void LAPL()
        {

            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("[GetPendencyReportLandAllotmentLevelWise]", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
               <tr><th colspan=14  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pendency Report From 01-09-2019 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
               "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Accounts Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Data Verification Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>RM Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>CMIA Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>JMD Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>MD Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>RM Pending (Letter Issuance)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string RegionalOffice  = dt.Rows[i][0].ToString();
                    string TotalReceived   = dt.Rows[i][1].ToString();
                    string TotalObjection  = dt.Rows[i][2].ToString();
                    string TotalApproved   = dt.Rows[i][3].ToString();
                    string TotalRejected   = dt.Rows[i][4].ToString();
                    string TotalPending    = dt.Rows[i][5].ToString();
                    string AccountsPending = dt.Rows[i][6].ToString();
                    string DataPending     = dt.Rows[i][7].ToString();
                    string RMPending       = dt.Rows[i][8].ToString();
                    string CMIAPending     = dt.Rows[i][9].ToString();
                    string MDPending       = dt.Rows[i][10].ToString();
                    string LetterPending   = dt.Rows[i][11].ToString();
                    string JMDPending      = dt.Rows[i][12].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalObjection + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalRejected + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AccountsPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DataPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + RMPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + CMIAPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + JMDPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + MDPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + LetterPending + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(TotalRejected)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalPending)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(AccountsPending)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(DataVerificationPending)", string.Empty).ToString();
                string total7 = dt.Compute("Sum(RMPending)", string.Empty).ToString();
                string total8 = dt.Compute("Sum(CMIAPending)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(MDPending)", string.Empty).ToString();
                string total10 = dt.Compute("Sum(LetterIssuancePending)", string.Empty).ToString();
                string total11 = dt.Compute("Sum(TotalObjection)", string.Empty).ToString();
                string total12 = dt.Compute("Sum(JMDPending)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'><td colspan='2' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total11 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total7 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total8 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total12 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total10 + "</td></tr>";
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
        private void LAPSLA()
        {

            try
            {
                string html = "";
                SqlCommand cmmd;

                cmmd = new SqlCommand("[GetStatementforLandAllotment13]", con);


                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;


                html = @"

<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Status Report From 01-09-2019 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicaton Received On " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application Disposed On " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string RegionalOffice = dt.Rows[i][0].ToString();

                    string TotalReceived = dt.Rows[i][1].ToString();
                    string TotalObjection = dt.Rows[i][2].ToString();
                    string TotalApproved = dt.Rows[i][3].ToString();
                    string TotalRejected = dt.Rows[i][4].ToString();
                    string TotalPending = dt.Rows[i][5].ToString();
                    string WithingSLA = dt.Rows[i][6].ToString();
                    string BeyondSLA = dt.Rows[i][7].ToString();
                    string ReceivedToday = dt.Rows[i][8].ToString();
                    string DisposedToday = dt.Rows[i][9].ToString();






                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=1&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalReceived + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalObjection + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=2&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalApproved + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=3&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalRejected + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=4&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalPending + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=5&Reg=" + RegionalOffice + "' Target='_blank'>" + WithingSLA + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendency.aspx?ReportType=6&Reg=" + RegionalOffice + "' Target='_blank'>" + BeyondSLA + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ReceivedToday + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedToday + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(TotalRejected)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalPending)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(PendingWithinSLA)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(PendingBeyondSLA)", string.Empty).ToString();
                string total7 = dt.Compute("Sum(ApplicationReceivedToday)", string.Empty).ToString();
                string total8 = dt.Compute("Sum(ApplicationDisposedToday)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(TotalObjection)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'><td colspan='2' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=7&Reg=ALL' Target='_blank'>" + total1 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=8&Reg=ALL' Target='_blank'>" + total2 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=9&Reg=ALL' Target='_blank'>" + total3 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=10&Reg=ALL' Target='_blank'>" + total4 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=11&Reg=ALL' Target='_blank'>" + total5 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendency.aspx?ReportType=12&Reg=ALL' Target='_blank'>" + total6 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total7 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total8 + "</td></tr>";
                html += "</table>";


                Literal loLit = new Literal();
                loLit.Text = (html);
                ph.Controls.Add(loLit);




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void BPSLA()
        {
            try
            {
                string html = "";

                SqlCommand cmmd;



                cmmd = new SqlCommand("[GetStatementforBuildingPlan13]", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;


                html = @"

<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Building Plan Status Report From 01-09-2019 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                             "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicaton Received On " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application Disposed On " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string RegionalOffice = dt.Rows[i][0].ToString();

                    string TotalReceived = dt.Rows[i][1].ToString();
                    string TotalObjection = dt.Rows[i][2].ToString();
                    string TotalApproved = dt.Rows[i][3].ToString();
                    string TotalRejected = dt.Rows[i][4].ToString();
                    string TotalPending = dt.Rows[i][5].ToString();
                    string WithingSLA = dt.Rows[i][6].ToString();
                    string BeyondSLA = dt.Rows[i][7].ToString();
                    string ReceivedToday = dt.Rows[i][8].ToString();
                    string DisposedToday = dt.Rows[i][9].ToString();








                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=1&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalReceived + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=13&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalObjection + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=2&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalApproved + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=3&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalRejected + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=4&Reg=" + RegionalOffice + "' Target='_blank'>" + TotalPending + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=5&Reg=" + RegionalOffice + "' Target='_blank'>" + WithingSLA + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=6&Reg=" + RegionalOffice + "' Target='_blank'>" + BeyondSLA + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'><a href='NiveshMitraPendencyBP.aspx?ReportType=15&Reg=" + RegionalOffice + "' Target='_blank'>" + ReceivedToday + "</a></td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedToday + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(TotalRejected)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalPending)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(PendingWithinSLA)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(PendingBeyondSLA)", string.Empty).ToString();
                string total7 = dt.Compute("Sum(ApplicationReceivedToday)", string.Empty).ToString();
                string total8 = dt.Compute("Sum(ApplicationDisposedToday)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(TotalObjection)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'><td colspan='2' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=7&Reg=ALL' Target='_blank'>" + total1 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=14&Reg=ALL' Target='_blank'>" + total9 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=8&Reg=ALL' Target='_blank'>" + total2 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=9&Reg=ALL' Target='_blank'>" + total3 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=10&Reg=ALL' Target='_blank'>" + total4 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=11&Reg=ALL' Target='_blank'>" + total5 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=12&Reg=ALL' Target='_blank'>" + total6 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'><a href='NiveshMitraPendencyBP.aspx?ReportType=16&Reg=ALL' Target='_blank'>" + total7 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total8 + "</td></tr>";
                html += "</table>";


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
                LAPL();
            }
            if (drpReportName.SelectedValue == "LAPSLA")
            {
                LAPSLA();
            }
            if (drpReportName.SelectedValue == "BPSLA")
            {
                BPSLA();
            }
            if (drpReportName.SelectedValue == "NMSLA")
            {
                NMSLA();
            }
        }

        private void NMSLA()
        {
            try
            {
                string html = "";

                SqlCommand cmmd;
                cmmd = new SqlCommand("[GetAllDetailsServiceWiseNMWise]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;


                html = @"

<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><tr><th colspan=13  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra & IA Service Pendency Report Period from 27-04-2020 till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                                 "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Service Name </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Timeline</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Under Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Disposed</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Disposed Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Disposed Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Pending Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Pending Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending Applications</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string ServiceName = dt.Rows[i][1].ToString();
                    string Timelines = dt.Rows[i][2].ToString();
                    string TotalReceived = dt.Rows[i][3].ToString();
                    string TotalObjection = dt.Rows[i][4].ToString();
                    string TotalDisposed = dt.Rows[i][5].ToString();
                    string DisposedWithinSLA = dt.Rows[i][6].ToString();
                    string DisposedBeyondSLA = dt.Rows[i][7].ToString();
                    string TotalApproved = dt.Rows[i][8].ToString();
                    string TotalRejected = dt.Rows[i][9].ToString();
                    string TotalPending = dt.Rows[i][10].ToString();
                    string WithingSLA = dt.Rows[i][11].ToString();
                    string BeyondSLA = dt.Rows[i][12].ToString();








                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + ServiceName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Timelines + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalObjection + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalDisposed + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedWithinSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedBeyondSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalRejected + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + WithingSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + BeyondSLA + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalPending + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(TotalRejected)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalPending)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(PendingWithinSLA)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(PendingBeyondSLA)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(TotalObjection)", string.Empty).ToString();
                string total10 = dt.Compute("Sum(TotalDisposed)", string.Empty).ToString();
                string total11 = dt.Compute("Sum(DisposedWithinSLA)", string.Empty).ToString();
                string total12 = dt.Compute("Sum(DisposedBeyondSLA)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'><td colspan='3' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total10 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total11 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total12 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td></tr>";
                html += "</table>";


                Literal loLit = new Literal();
                loLit.Text = (html);
                ph.Controls.Add(loLit);




            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}