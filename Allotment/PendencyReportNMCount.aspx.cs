using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PendencyReportNMCount : System.Web.UI.Page
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

        
        protected void drpReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            NMSLA();
        }

        private void NMSLA()
        {
            try
            {
                string html = "";

                SqlCommand cmmd;
                cmmd = new SqlCommand("[GetBifiractedFilterWiseReportIAandCount] '"+ drpReportName.SelectedValue.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                int j = 0;


                html = @"
<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
<tr><tr><th colspan=12  style='background-color: #4CAF50;text-align: center;font-size: 16px;color: #ffffff;'> Pendency Report of "+drpReportName.SelectedItem.Text.Trim()+" Period from 27-04-2020 till " + DateTime.Now.ToString("dd-MM-yyyy") + "</th></tr>" +
                                 "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Regional Office</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Received</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Under Objection</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Disposed</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Disposed Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Disposed Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Approved</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Rejected</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Pending Within SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applications Pending Beyond SLA</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Total Pending Applications</th></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    j++;
                    string ServiceName       = dt.Rows[i][0].ToString();                   
                    string TotalReceived     = dt.Rows[i][1].ToString();
                    string TotalObjection    = dt.Rows[i][2].ToString();
                    string TotalDisposed     = dt.Rows[i][3].ToString();
                    string DisposedWithinSLA = dt.Rows[i][4].ToString();
                    string DisposedBeyondSLA = dt.Rows[i][5].ToString();
                    string TotalApproved     = dt.Rows[i][6].ToString();
                    string TotalRejected     = dt.Rows[i][7].ToString();
                    string TotalPending      = dt.Rows[i][8].ToString();
                    string WithingSLA        = dt.Rows[i][9].ToString();
                    string BeyondSLA         = dt.Rows[i][10].ToString();








                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + ServiceName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalReceived + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalObjection + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalDisposed + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedWithinSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DisposedBeyondSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalApproved + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalRejected + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + WithingSLA + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + BeyondSLA + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + TotalPending + "</td></tr>";
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

                html += "<tr style='background-color: #ccc;'><td colspan='2' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total1 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total9 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total10 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total11 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total12 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total2 + "</a></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total3 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total5 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total6 + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + total4 + "</td></tr>";
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