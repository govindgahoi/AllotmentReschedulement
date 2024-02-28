using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class MISReportServiceWiseAll : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BPSLA("1000");
            }
        }

        private void BPSLA(string ID)
        {

            try
            {
                string html = "";

                SqlCommand cmmd;


                int id = Convert.ToInt32(ID);
                cmmd = new SqlCommand("[GetAllDetailsServiceWiseRegionWise] " + ID + "", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;

                string Name = dt.Rows[0]["ServiceName"].ToString();


                html = @"

<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><th colspan = 9  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'>Application Status Report From 01-11-2018 Till " + DateTime.Now.ToString("dd-MM-yyyy") + " Of " + Name + "</th></tr>" +
                             "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Pending Beyond SLA</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string ServiceName = dt.Rows[i][2].ToString();

                    string TotalReceived = dt.Rows[i][3].ToString();
                    string TotalObjection = dt.Rows[i][4].ToString();
                    string TotalApproved = dt.Rows[i][5].ToString();
                    string TotalRejected = dt.Rows[i][6].ToString();
                    string TotalPending = dt.Rows[i][7].ToString();
                    string WithingSLA = dt.Rows[i][8].ToString();
                    string BeyondSLA = dt.Rows[i][9].ToString();








                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + ServiceName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalObjection + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalRejected + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalPending + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + WithingSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + BeyondSLA + "</td></tr>";
                }

                string total1 = dt.Compute("Sum(TotalReceived)", string.Empty).ToString();
                string total2 = dt.Compute("Sum(TotalApproved)", string.Empty).ToString();
                string total3 = dt.Compute("Sum(TotalRejected)", string.Empty).ToString();
                string total4 = dt.Compute("Sum(TotalPending)", string.Empty).ToString();
                string total5 = dt.Compute("Sum(PendingWithinSLA)", string.Empty).ToString();
                string total6 = dt.Compute("Sum(PendingBeyondSLA)", string.Empty).ToString();
                string total9 = dt.Compute("Sum(TotalObjection)", string.Empty).ToString();

                html += "<tr style='background-color: #ccc;'><td colspan='2' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td></tr>";
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
            BPSLA(drpReportName.SelectedValue.Trim());
        }

    }
}