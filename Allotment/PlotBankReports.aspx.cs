using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class PlotBankReports : System.Web.UI.Page
    {
        SqlConnection con;
        string UserName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);



        }
        protected void drpReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpReportName.SelectedValue.ToString().Trim().Length > 0)
            {
                call_function(drpReportName.SelectedValue.ToString().Trim());
            }



        }
        protected void call_function(string report_name)
        {
            SqlCommand cmd2 = new SqlCommand("GetPlotBankMigrationCount_SP  NULL", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            try
            {
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];
            }
            catch { }



            int i = 0;
            int comment1 = 6, comment2 = 6;
            string region_prev = "", region_cur = "";
            string comment_strDate1 = "", comment_strDate2 = "";
            string htmldata = "";

            ph.Controls.Clear();





            decimal total_count = 0, pre_sum = 0, sum_yesterday = 0, sum_today = 0, total_count_today = 0, total_count_yesterday = 0;
            htmldata = "";
            DateTime date_today = DateTime.Now;
            if (report_name == "Regional_Office")
            {
                if (dt.Rows.Count > 0)
                {
                    total_count = Convert.ToDecimal(dt.Compute("SUM(Available)", string.Empty));
                    string report_date = date_today.ToString("MMMM d, yyyy");


                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br /><br /><h2 style = ""text-decoration:underline;"" >Plot Bank Reports</h2><br /><br />
                      <span class=""pull-right font-bold"">Total Plot Available:  " + total_count + @"</span><br /><br />
                      <table class=""table table-bordered table-hover request-table"">
                        <tr style='background:#f7f7f7;'>
                            <th>S.NO</th>
                            <th>Industrial Area</th>
                            <th class=""text-center"">Status</th>
                            <th class=""text-center"">Substatus</th>
                            <th class=""text-center"">Total Number</th>
                        </tr>";

                    i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {


                        region_cur = dr["RegionalOffice"].ToString();

                        comment_strDate1 = ""; comment_strDate2 = "";
                        i++;
                        if (region_cur == region_prev)
                        {
                            htmldata += @"<tr> <td>" + i.ToString() + "</td>  <td style='width:70%'>" + dr["IAName"].ToString() + @"</td> <td class='text-center-imp'>" + dr["Status"].ToString() + @"</td> <td class='text-center-imp'>" + dr["Substatus"].ToString() + @"</td> <td class='text-center-imp'>" + dr["Available"].ToString() + @"</td> </tr>";
                        }
                        else
                        {
                            if (i == 1)
                            {
                                htmldata += @"<tr><th colspan=""5"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
                       
                          <tr> 
                          <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td> 
                            <td class='text-center-imp'> " + dr["Status"].ToString() + @" </td> 
                            <td class='text-center-imp'> " + dr["Substatus"].ToString() + @" </td> 
                          <td class='text-center-imp'> " + dr["Available"].ToString() + @" </td> 
                          
                         </tr>";

                            }
                            else
                            {
                                htmldata += @"<tr  style='background:#f7f7f7;'>
                                          <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th>
                                          <th class='text-center-imp'>" + pre_sum + @"</th> 
                                          </tr>
                                          <tr style='background:#f7f7f7;'><th colspan=""5"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
                          <tr> 
                          <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td>
                           <td class='text-center-imp'> " + dr["Status"].ToString() + @" </td> 
                            <td class='text-center-imp'> " + dr["Substatus"].ToString() + @" </td> 
                          <td  class='text-center-imp'> " + dr["Available"].ToString() + @" </td> 
                         </tr>";
                                pre_sum = 0;



                            }

                        }
                        pre_sum = pre_sum + Convert.ToDecimal(dr["Available"].ToString());
                        region_prev = region_cur;
                    }
                    htmldata += @"<tr style='background:#f7f7f7;'>
                                          <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th>
                                          <th class='text-center-imp'>" + pre_sum + @"</th> 
                                          </tr>";

                    htmldata += " </table>";

                    Literal loLit = new Literal();
                    loLit.Text = (htmldata);
                    ph.Controls.Add(loLit);


                }
            }




        }
    }
}