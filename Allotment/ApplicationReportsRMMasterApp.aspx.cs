using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidcApi
{
    public partial class ApplicationReportsRMMaster : System.Web.UI.Page
    {

        SqlConnection con;
        string token = string.Empty;
        //  string ModeType = string.Empty;
        string RegionalOffice = string.Empty;
        string IndustrialArea = string.Empty;
         string FromDate = string.Empty;
        string ToDate = string.Empty;
        string PaymentMode = string.Empty;
        string ServiceType = string.Empty;
        string searchText = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            token = Request.QueryString["token"];
            RegionalOffice = Request.QueryString["RegionalOffice"];
            IndustrialArea = Request.QueryString["IndustrialArea"];
            FromDate = Request.QueryString["FromDate"];
            ToDate = Request.QueryString["ToDate"];
            PaymentMode = Request.QueryString["PaymentMode"];
            ServiceType = Request.QueryString["ServiceType"];
            searchText = Request.QueryString ["searchText"];
            if (token != string.Empty && RegionalOffice != string.Empty && PaymentMode != string.Empty && IndustrialArea != string.Empty)
            {
                try
                {
                    BindServiceRequestGrid();
                }
                catch (Exception ex)
                {

                }

            }
        }
        private void BindServiceRequestGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

                SqlConnection con = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetListOfApplicationIndustrialArea";

                cmd.Parameters.Add("@RegionalOffice", SqlDbType.VarChar).Value = RegionalOffice;
                cmd.Parameters.Add("@IndustrialArea", SqlDbType.VarChar).Value = IndustrialArea;
                cmd.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = PaymentMode;
                cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar).Value = "1000";
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                cmd.Parameters.Add("@searchText", SqlDbType.VarChar).Value = searchText;


                cmd.Connection = con;


                
                //ApplicationCleared.DataSource = ds;
                //ApplicationCleared.DataBind();

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                try
                {
                    dt = ds.Tables[0];
                    //dt1 = ds.Tables[1];
                }
                catch { }
                int i = 0;
                int j = 0;
                ph.Controls.Clear();
                DateTime date_today = DateTime.Now;
                string region_prev = "", region_cur = "";
                string industrial_prev = "", industrial_cur = "";
                string htmldata = "";
                decimal total_count = 0, pre_sum = 0, pre_totalArea = 0;
                htmldata = "";

                if (dt.Rows.Count > 0)
                {
                    total_count = Convert.ToDecimal(dt.Compute("SUM(CreatedTransactionAmount)", string.Empty));
                    string report_date = date_today.ToString("MMMM d, yyyy");
                    htmldata = @"<h2 style = ""text-decoration:underline;"" >List of Applications<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span></h2>
                      <table class=""table table-bordered table-hover request-table"">
                        ";

                    foreach (DataRow dr in dt.Rows)
                    {
                        region_cur = dr["RegionalOffice"].ToString();
                        industrial_cur = dr["IAName"].ToString();
                        i++;

                        if (region_cur == region_prev)
                        {

                            if (industrial_cur == industrial_prev)
                            {
                                DateTime date = Convert.ToDateTime(dr["TransactioncreateDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"
                                    <tr> <td>" + i.ToString() + "</td>  " +
                                    "<td>" + dr["ServiceRequestNO"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentBank"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TransactionRefNo"].ToString() + @"</td>
                                <td class='text-center-imp'>" + transation_date + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CreatedTransactionAmount"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentStatus"].ToString() + @"</td>
                                </tr>";
                            }
                            else
                            {

                                DateTime date = Convert.ToDateTime(dr["TransactioncreateDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr><th class='head-region' colspan=""9"">" + dr["IAName"].ToString() + @"</th></tr>
                                <tr style='background:#f7f7f7;'>
                            <th>S.NO</th>
                            <th>ServiceRequestNO</th>
                            <th>ApplicantName</th>
                            <th>PaymentBank</th>
                            <th>Payment ID</th>
                            <th>Date</th>
                            <th>PlotSize(In SQmts)</th>
                            <th>Amount</th>
                            <th>Account Clearance</th>
                        </tr>
                                <tr> 
                                 <td> " + i.ToString() + " </td >  <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentBank"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TransactionRefNo"].ToString() + @"</td>
                                <td class='text-center-imp'>" + transation_date + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CreatedTransactionAmount"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentStatus"].ToString() + @"</td>
                         </tr>";
                            }

                        }
                        else
                        {
                            if (i == 1)
                            {
                                DateTime date = Convert.ToDateTime(dr["TransactioncreateDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr><th class='head-region' colspan=""9"">" + dr["RegionalOffice"].ToString() + @"</th></tr> 
                                <tr><th class='head-IAname' colspan=""9"">" + dr["IAName"].ToString() + @"</th></tr> 
                                <tr style='background:#f7f7f7;'>
                            <th>S.NO</th>
                            <th>ServiceRequestNO</th>
                            <th>ApplicantName</th>
                            <th>PaymentBank</th>
                            <th>Payment ID</th>
                            <th>Date</th>
                            <th>PlotSize(In SQmts)</th>
                            <th>Amount</th>
                            <th>Account Clearance</th>
                        </tr>
                          <tr> 
                          <td> " + i.ToString() + " </td >  <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                            <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentBank"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TransactionRefNo"].ToString() + @"</td>
                                <td class='text-center-imp'>" + transation_date + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CreatedTransactionAmount"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentStatus"].ToString() + @"</td>
                         </tr>";

                            }
                            else
                            {
                                DateTime date = Convert.ToDateTime(dr["TransactioncreateDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr  style='background:#f7f7f7;'>
                                          <th class='head-total' colspan=""6""><span class=""pull-right"">Total " + region_prev + @"</span></th>
                                            <th class='text-center-imp head-total'>" + pre_totalArea + @"</th>
                                          <th class='text-center-imp head-total'>" + pre_sum + @"</th>
                                           <th class='head-total'></th>
                                          </tr>
                                          <tr style='background:#f7f7f7;' class='tr-region'><th colspan=""9""class='head-region'>" + dr["RegionalOffice"].ToString() + @"</th></tr>
                                            <tr style='background:#f7f7f7;'><th colspan=""9"" class='head-IAname'>" + dr["IAName"].ToString() + @"</th></tr>
                                            <tr style='background:#f7f7f7;'>
                            <th>S.NO</th>
                            <th>ServiceRequestNO</th>
                            <th>ApplicantName</th>
                            <th>PaymentBank</th>
                            <th>Payment ID</th>
                            <th>Date</th>
                            <th>PlotSize(In SQmts)</th>
                            <th>Amount</th>
                            <th>Account Clearance</th>
                        </tr>
                          <tr> 
                           <td> " + i.ToString() + " </td >  <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                             <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentBank"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TransactionRefNo"].ToString() + @"</td>
                                <td class='text-center-imp'>" + transation_date + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CreatedTransactionAmount"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PaymentStatus"].ToString() + @"</td>
                         </tr>";
                                pre_sum = 0;
                                pre_totalArea = 0;
                            }
                        }
                        pre_sum = pre_sum + Convert.ToDecimal(dr["CreatedTransactionAmount"].ToString());
                        pre_totalArea = pre_totalArea + Convert.ToDecimal(dr["PlotSize"].ToString());
                        region_prev = region_cur;
                        industrial_prev = industrial_cur;
                    }
                    htmldata += @"<tr style='background:#f7f7f7;'>
                                          <th colspan=""6""class='head-total'><span class=""pull-right"">Total " + @"</span></th>
                                           <th class='text-center-imp head-total'>" + pre_totalArea + @"</th>
                                          <th class='text-center-imp head-total'>" + pre_sum + @"</th>
                                            <th class='head-total'></th>
                                          </tr>";

                    htmldata += " </table>";

                    Literal loLit = new Literal();
                    loLit.Text = (htmldata);
                    ph.Controls.Add(loLit);


                }

                //if (dt.Rows.Count > 0)
                //{

                //    string report_date = date_today.ToString("MMMM d, yyyy hh:mm:ss tt");
                //    string prev_report_date = DateTime.Now.AddDays(-1).ToString("MMM d");
                //    string report_date_f1 = date_today.ToString("MMM d");
                //    htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><h2 style = ""text-decoration:underline;"" >List of Application</h2> 
                //                <table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
                //                <tr style='background:#f7f7f7;'> 
                //                </tr></table><br />

                //      <table class=""table table-bordered table-hover request-table"">
                //        <tr style='background:#f7f7f7;'>
                //            <th style=""width:2%;"">S.NO</th>
                //            <th style=""width:4%;"">Regional Office</th>
                //            <th style=""width:5%;"">Industrial Area</th>
                //            <th style=""width:12%;"">ServiceRequestNO</th>
                //            <th style=""width:10%;"">Applicant Name</th>
                //            <th class=""text-center"" style=""width:8%;"">GST On Application Fees</th>
                //            <th class=""text-center"" style=""width:8%;"">GST On Processing Charges</th>
                //            <th class=""text-center"" style=""width:6%;"">Total</th>
                //        </tr>";

                //    i = 0;
                //    foreach (DataRow dr in dt.Rows)
                //    {

                //        region_cur = dr["RegionalOffice"].ToString();
                //        i++;
                //        if (region_cur == region_prev)
                //        {
                //            htmldata += @"
                //          <tr> 
                //          <td> " + i.ToString() + "</td >" +
                //          " <td> " + dr["RegionalOffice"].ToString() + @" </td> 
                //            <td> " + dr["IANAme"].ToString() + @"  </td>
                //            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                //          <td> " + dr["ApplicantName"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                //         </tr>";

                //        }
                //        else
                //        {

                //            if (i == 1)
                //            {
                //                htmldata += @"
                //          <tr> 
                //        <td> " + i.ToString() + "</td >" +
                //          "<td> " + dr["RegionalOffice"].ToString() + @" </td> 
                //            <td> " + dr["IANAme"].ToString() + @"  </td>
                //            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                //          <td> " + dr["ApplicantName"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                //         </tr>";

                //            }
                //            else
                //            {
                //                htmldata += @"
                //          <tr> 
                //         <td> " + i.ToString() + "</td >" +
                //          " <td> " + dr["RegionalOffice"].ToString() + @" </td> 
                //            <td> " + dr["IANAme"].ToString() + @"  </td>
                //            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                //          <td> " + dr["ApplicantName"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                //          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                //         </tr>";
                //            }
                //        }
                //    }

                //    htmldata += " </table>";
                //    Literal loLit = new Literal();
                //    loLit.Text = (htmldata);
                //    ph.Controls.Add(loLit);
                //}
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



    }
}