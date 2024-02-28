﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class NiveshMitraPendency : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string RegionalOffice;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {

                RegionalOffice = Request.QueryString["Reg"];
                string Type = Request.QueryString["ReportType"];
                if (Type == "1")
                {
                    GetReportP1();
                }
                if (Type == "2")
                {
                    GetReportP2();
                }
                if (Type == "3")
                {
                    GetReportP3();
                }
                if (Type == "4")
                {
                    GetReportP4();
                }
                if (Type == "5")
                {
                    GetReportP5();
                }
                if (Type == "6")
                {
                    GetReportP6();
                }
                if (Type == "7")
                {
                    GetReportP7();
                }
                if (Type == "8")
                {
                    GetReportP8();
                }
                if (Type == "9")
                {
                    GetReportP9();
                }
                if (Type == "10")
                {
                    GetReportP10();
                }
                if (Type == "11")
                {
                    GetReportP11();
                }
                if (Type == "12")
                {
                    GetReportP12();
                }

            }
        }

        private void GetReportP1()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllLaAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=9  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Total Received Applications Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td></tr>";

                }

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

        private void GetReportP2()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllApprovedAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Approved Applications Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Approval Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Allotted Plot</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string CompltedDate = dt.Rows[i][8].ToString();
                    string AllottedPlot = dt.Rows[i][9].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + CompltedDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AllottedPlot + "</td></tr>";

                }

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

        private void GetReportP3()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllRejectedAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=10  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Rejected Application Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Rejection Date</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string RejectedDate = dt.Rows[i][8].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + RejectedDate + "</td></tr>";

                }

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

        private void GetReportP4()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=10  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string Sincedays = dt.Rows[i][8].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Sincedays + "</td></tr>";

                }

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

        private void GetReportP5()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingWithinSLAAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=10  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Within SLA Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string Sincedays = dt.Rows[i][8].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Sincedays + "</td></tr>";

                }

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

        private void GetReportP6()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingBeyondSLAAppRegionWise '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=10  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Beyond SLA Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string Sincedays = dt.Rows[i][8].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Sincedays + "</td></tr>";

                }

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

        private void GetReportP7()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllReceivedLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'><thead syle='position:fixed;'>
<tr><th colspan=10  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Total Received Application From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th></tr></thead>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string RegionalOffice = dt.Rows[i][8].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td></tr>";

                }

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

        private void GetReportP8()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllApprovedLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=12  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Total Approved Applications Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Approval Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Allotted Plot</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string CompltedDate = dt.Rows[i][8].ToString();
                    string AllottedPlot = dt.Rows[i][9].ToString();
                    string RegionalOffice = dt.Rows[i][10].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + CompltedDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AllottedPlot + "</td></tr>";

                }

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

        private void GetReportP9()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllRejectedLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Rejected Application Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Rejection Date</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string RejectedDate = dt.Rows[i][8].ToString();
                    string RegionalOffice = dt.Rows[i][9].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + RejectedDate + "</td></tr>";

                }

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

        private void GetReportP10()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string PendingSince = dt.Rows[i][8].ToString();
                    string RegionalOffice = dt.Rows[i][9].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PendingSince + "</td></tr>";

                }

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

        private void GetReportP11()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingWithinLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"
<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Within SLA Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string PendingSince = dt.Rows[i][8].ToString();
                    string RegionalOffice = dt.Rows[i][9].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PendingSince + "</td></tr>";

                }

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

        private void GetReportP12()
        {
            try
            {
                SqlCommand cmmd;
                string html = "";

                cmmd = new SqlCommand("GetAllPendingBeyondLAApp '" + RegionalOffice + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;
                html = @"

<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan=11  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Nivesh Mitra Land Allotment Pending Application Beyond SLA Report From 01-10-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Nivesh Mitra ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Email ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Since(Days)</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string IAName = dt.Rows[i][0].ToString();
                    string ApplicationID = dt.Rows[i][1].ToString();
                    string SWPID = dt.Rows[i][2].ToString();
                    string ApplicantName = dt.Rows[i][3].ToString();
                    string PhoneNo = dt.Rows[i][4].ToString();
                    string EmailID = dt.Rows[i][5].ToString();
                    string PlotNo = dt.Rows[i][6].ToString();
                    string FinalSubDate = dt.Rows[i][7].ToString();
                    string PendingSince = dt.Rows[i][8].ToString();
                    string RegionalOffice = dt.Rows[i][9].ToString();

                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicationID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + SWPID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + EmailID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PendingSince + "</td></tr>";

                }

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
    }
}