using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class LandAllotmentReport : System.Web.UI.Page
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
                UserSpecificBinding(UserName);
            }
        }
        protected void UserSpecificBinding(string UserName)
        {

            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetAllRegionalOffice(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--All--", "All"));
                bindDDLRegion(ddloffice.SelectedItem.Value, null);

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
                ds = objServiceTimelinesBLL.GetIAregionalOfficeWise(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "IAName";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--All--", "All"));
                BindServiceRequestGrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            try
            {

                bindDDLRegion(ddloffice.SelectedItem.Value, null);
                BindServiceRequestGrid();
            }
            catch (Exception ex)
            {

            }

        }
        private void BindServiceRequestGrid()
        {
            int total;
            objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
            objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
            objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetLandAllotmentReports(objServiceTimelinesBEL);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                try
                {
                    dt = ds.Tables[0];

                    //dt1 = ds.Tables[1];
                }
                catch { }
                string htmldata = "";

                ph.Controls.Clear();
                int i = 0;
                string region_prev = "", region_cur = "";
                string comment_strDate1 = "", comment_strDate2 = "";
                decimal total_count = 0, pre_sum = 0, sum_yesterday = 0, sum_today = 0, total_count_today = 0, total_count_yesterday = 0;
                decimal pre_TotalApplication = 0, pre_PendingAtAccounts = 0, pre_PendingAtVerifier = 0, pre_PendingAtRM = 0, pre_PendingAtCMIA = 0, pre_PendingAtMD = 0, pre_PendingForAllotment = 0, pre_Completed = 0, pre_Rejected = 0;


                htmldata = "";
                DateTime date_today = DateTime.Now;
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows.Count;
                    total_count = Convert.ToDecimal(dt.Compute("SUM(TotalApplication)", string.Empty));
                    string report_date = date_today.ToString("MMMM d, yyyy");
                    string from_date = date_today.ToString("MMMM d, yyyy");
                    string To_date = date_today.ToString("MMMM d, yyyy");
                    if (txtTransactionFromDate.Text == "" || txtTransactionToDate.Text == "")
                    {
                        from_date = "";
                        To_date = date_today.ToString("MMMM d, yyyy");
                    }
                    else
                    {
                        from_date = txtTransactionFromDate.Text;
                        To_date = txtTransactionToDate.Text;
                    }

                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span>
                    <br /><br /><h2 style = ""text-decoration:underline;"" > STATEMENT SHOWING STATUS OF ALLOTMENT APPLICATION</h2><br /><br />
                     <h6 style = ""text-decoration:underline;"" > (" + from_date + @"To" + To_date + @")</h2>
                      <span class=""pull-right font-bold"">Total Application:  " + total_count.ToString() + @"</span><br /><br />
                      <table class=""table table-bordered table-hover request-table"">
                        <tr style='background:#f7f7f7;'>
                            <th style='width:5%;'>S.NO</th>
                            <th class='text-center-imp'>Industrial Area</th>
                            <th class='text-center-imp'>IA Category</th>
                            <th class='text-center-imp'>Total Application</th>
                            <th class='text-center-imp' colspan=6 >Total Application in Pending Status(In Nos)</th>
                            <th class='text-center-imp' colspan=2>Total Application</th>
                        </tr>
                            <tr style='background:#f7f7f7;'>
                            <th class='text-center-imp'></th>
                            <th class='text-center-imp'></th>
                            <th class='text-center-imp'></th>
                            <th class='text-center-imp'></th>
                            <th class='text-center-imp'>Accounts</th>
                            <th class='text-center-imp'>Verifier</th>
                            <th class='text-center-imp'>Regional Manager</th>
                            <th class='text-center-imp'>CMIA</th>
                            <th class='text-center-imp'>Final Approval</th>
                            <th >Allotment</th>
                            <th >Completed</th>
                            <th >Rejected</th>
                        </tr>";


                    i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        region_cur = dr["RegionalOffice"].ToString();
                        comment_strDate1 = ""; comment_strDate2 = "";
                        i++;
                        if (region_cur == region_prev)
                        {
                            htmldata += @"<tr> <td>" + i.ToString() + "</td>  " +
                                "<td style='width:70%'>" + dr["IAName"].ToString() + @"</td> 
                                <td class='text-center-imp'>" + dr["IAStatus"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TotalApplication"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtAccounts"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtVerifier"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtRM"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtCMIA"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingForAllotment"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Completed"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Rejected"].ToString() + @"</td>
                                </tr>";
                        }
                        else
                        {
                            if (i == 1)
                            {
                                htmldata += @"<tr><th colspan=""13"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
                       
                          <tr> 
                          <td> " + i.ToString() + " </td >  " +
                          "<td style='width:70%'>" + dr["IAName"].ToString() + @"</td> 
                                <td class='text-center-imp'>" + dr["IAStatus"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TotalApplication"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtAccounts"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtVerifier"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtRM"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtCMIA"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingForAllotment"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Completed"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Rejected"].ToString() + @"</td> 
                         </tr>";

                            }
                            else
                            {
                                htmldata += @"<tr  style='background:#f7f7f7;'>
                                          <th colspan=""2""><span class=""pull-right"">Total </span></th>
                                          <th ><span class=""pull-right""> " + region_prev + @"</span></th>
                                          
                                          <th class='text-center-imp'>" + pre_TotalApplication + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtAccounts + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtVerifier + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtRM + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtCMIA + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtMD + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingForAllotment + @"</th>
                                          <th class='text-center-imp'>" + pre_Completed + @"</th>
                                          <th class='text-center-imp'>" + pre_Rejected + @"</th> 
                                          </tr>
                                          <tr style='background:#f7f7f7;'><th colspan=""13"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
                          <tr> 
                          <td> " + i.ToString() + " </td >  " +
                          "<td style='width:70%'>" + dr["IAName"].ToString() + @"</td> 
                                <td class='text-center-imp'>" + dr["IAStatus"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["TotalApplication"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtAccounts"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtVerifier"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtRM"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtCMIA"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingAtMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PendingForAllotment"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Completed"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Rejected"].ToString() + @"</td> 
                         </tr>";
                                pre_sum = 0;
                                pre_TotalApplication = 0;
                                pre_PendingAtAccounts = 0;
                                pre_PendingAtVerifier = 0;
                                pre_PendingAtRM = 0;
                                pre_PendingAtCMIA = 0;
                                pre_PendingAtMD = 0;
                                pre_PendingForAllotment = 0;
                                pre_Completed = 0;
                                pre_Rejected = 0;
                            }
                        }
                        pre_TotalApplication = pre_TotalApplication + Convert.ToDecimal(dr["TotalApplication"].ToString());
                        pre_PendingAtAccounts = pre_PendingAtAccounts + Convert.ToDecimal(dr["PendingAtAccounts"].ToString());
                        pre_PendingAtVerifier = pre_PendingAtVerifier + Convert.ToDecimal(dr["PendingAtVerifier"].ToString());
                        pre_PendingAtRM = pre_PendingAtRM + Convert.ToDecimal(dr["PendingAtRM"].ToString());
                        pre_PendingAtCMIA = pre_PendingAtCMIA + Convert.ToDecimal(dr["PendingAtCMIA"].ToString());
                        pre_PendingAtMD = pre_PendingAtMD + Convert.ToDecimal(dr["PendingAtMD"].ToString());
                        pre_PendingForAllotment = pre_PendingForAllotment + Convert.ToDecimal(dr["PendingForAllotment"].ToString());
                        pre_Completed = pre_Completed + Convert.ToDecimal(dr["Completed"].ToString());
                        pre_Rejected = pre_Rejected + Convert.ToDecimal(dr["Rejected"].ToString());
                        region_prev = region_cur;
                    }
                    htmldata += @"<tr style='background:#f7f7f7;'>
                                          <th colspan=""2""><span class=""pull-right"">Total </span></th>
                                          <th ><span class=""pull-right""> " + region_prev + @"</span></th>
                                          <th class='text-center-imp'>" + pre_TotalApplication + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtAccounts + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtVerifier + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtRM + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtCMIA + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingAtMD + @"</th>
                                          <th class='text-center-imp'>" + pre_PendingForAllotment + @"</th>
                                          <th class='text-center-imp'>" + pre_Completed + @"</th>
                                          <th class='text-center-imp'>" + pre_Rejected + @"</th>
                                          </tr>";

                    htmldata += " </table>";

                    Literal loLit = new Literal();
                    loLit.Text = (htmldata);
                    ph.Controls.Add(loLit);


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }





        //protected void drpReportName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (drpReportName.SelectedValue.ToString().Trim().Length > 0)
        //    {
        //        call_function(drpReportName.SelectedValue.ToString().Trim());
        //    }
        //}

        //protected void call_function(string report_name)
        //{
        //    SqlCommand cmd2 = new SqlCommand("GetAllotteeMigrationCount_SP  NULL", con);
        //    SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
        //    DataSet ds = new DataSet();

        //    adp1.Fill(ds);


        //    DataTable dt = new DataTable();
        //    DataTable dt1 = new DataTable();

        //    try
        //    {
        //        dt = ds.Tables[0];
        //        dt1 = ds.Tables[1];
        //    }
        //    catch { }



        //    int i = 0;
        //    int comment1 = 6, comment2 = 6;
        //    string region_prev = "", region_cur = "";
        //    string comment_strDate1 = "", comment_strDate2 = "";
        //    string htmldata = "";

        //    ph.Controls.Clear();





        //    decimal total_count = 0, pre_sum = 0, sum_yesterday = 0, sum_today = 0, total_count_today = 0, total_count_yesterday = 0;
        //    htmldata = "";
        //    DateTime date_today = DateTime.Now;
        //    if (report_name == "Regional_Office")
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            total_count = Convert.ToDecimal(dt.Compute("SUM(completed)", string.Empty));
        //            string report_date = date_today.ToString("MMMM d, yyyy");


        //            htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br /><br /><h2 style = ""text-decoration:underline;"" > Daily Status Report: Allottee Migration</h2><br /><br />
        //              <span class=""pull-right font-bold"">Total Allottee Migrated:  " + total_count + @"</span><br /><br />
        //              <table class=""table table-bordered table-hover request-table"">
        //                <tr style='background:#f7f7f7;'>
        //                    <th>S.NO</th>
        //                    <th>Industrial Area</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on Date( in Numbers)</th>
        //                </tr>";

        //            i = 0;
        //            foreach (DataRow dr in dt.Rows)
        //            {


        //                region_cur = dr["RegionalOffice"].ToString();

        //                comment_strDate1 = ""; comment_strDate2 = "";



        //                i++;


        //                if (region_cur == region_prev)
        //                {
        //                    htmldata += @"<tr> <td>" + i.ToString() + "</td>  <td style='width:70%'>" + dr["IAName"].ToString() + @"</td> <td class='text-center-imp'>" + dr["completed"].ToString() + @"</td> </tr>";
        //                }
        //                else
        //                {
        //                    if (i == 1)
        //                    {
        //                        htmldata += @"<tr><th colspan=""3"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  

        //                  <tr> 
        //                  <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["completed"].ToString() + @" </td> 
        //                 </tr>";

        //                    }
        //                    else
        //                    {
        //                        htmldata += @"<tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""2""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>



        //                                  <tr style='background:#f7f7f7;'><th colspan=""3"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td  class='text-center-imp'> " + dr["completed"].ToString() + @" </td> 
        //                 </tr>";
        //                        pre_sum = 0;



        //                    }

        //                }


        //                pre_sum = pre_sum + Convert.ToDecimal(dr["completed"].ToString());
        //                region_prev = region_cur;
        //            }
        //            htmldata += @"<tr style='background:#f7f7f7;'>
        //                                  <th colspan=""2""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>";

        //            htmldata += " </table>";

        //            Literal loLit = new Literal();
        //            loLit.Text = (htmldata);
        //            ph.Controls.Add(loLit);


        //        }
        //    }



        //    total_count = 0; pre_sum = 0; sum_yesterday = 0; sum_today = 0; total_count_today = 0; total_count_yesterday = 0;
        //    htmldata = "";

        //    if (report_name == "Employee_Wise")
        //    {
        //        if (dt1.Rows.Count > 0)
        //        {
        //            total_count = Convert.ToDecimal(dt1.Compute("SUM(CumTotal)", string.Empty));
        //            total_count_today = Convert.ToDecimal(dt1.Compute("SUM(Today)", string.Empty));
        //            total_count_yesterday = Convert.ToDecimal(dt1.Compute("SUM(CumYesterday)", string.Empty));
        //            string report_date = date_today.ToString("MMMM d, yyyy hh:mm:ss tt");
        //            string prev_report_date = DateTime.Now.AddDays(-1).ToString("MMM d");
        //            string report_date_f1 = date_today.ToString("MMM d");

        //            //htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><br /><h2 style = ""text-decoration:underline;"" > Daily Employee Wise Report: Allottee Migration</h2><br /><br />                
        //            //             <span class=""pull-right font-bold""><b>&nbsp;Total Allottee Migrated As On Date :  " + total_count + @"</b></span><br />
        //            //             <span class=""pull-right font-bold""><b>Total Allottee Migrated As On " + report_date_f1 +" :  " + total_count_today + @" </b></span><br />
        //            //             <span class=""pull-right font-bold""><b>&nbsp;&nbsp;Total Allottee Migrated As On " + prev_report_date + " :  " + total_count_yesterday + @" </b></span><br />

        //            htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><br /><h2 style = ""text-decoration:underline;"" > Daily Employee Wise Report: Allottee Migration</h2><br /><br /> 
        //                        <table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
        //                        <tr style='background:#f7f7f7;'> 
        //                        <th>Total Allottee Migrated As On Date</th><th class='text-center'>" + total_count + @"</th></tr>
        //                       <tr style='background:#f7f7f7;'> <th>Total Allottee Migrate On " + report_date_f1 + "</th><th class='text-center'>" + total_count_today + @"</th></tr>
        //                     <tr style='background:#f7f7f7;'>   <th>Total Allottee Migrated As On " + prev_report_date + "</th><th class='text-center'>" + total_count_yesterday + @"</th>
        //                        </tr></table><br /><br /><br /><br />



        //              <table class=""table table-bordered table-hover request-table"">
        //                <tr style='background:#f7f7f7;'>
        //                    <th>S.NO</th>
        //                    <th>Regional Office</th>
        //                    <th>Employee</th>
        //                    <th>Industrial Area</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on " + prev_report_date + @"</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on " + report_date_f1 + @"</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on Date</th>
        //                </tr>";

        //            i = 0;
        //            foreach (DataRow dr in dt1.Rows)
        //            {


        //                region_cur = dr["RegionalOffice"].ToString();

        //                comment_strDate1 = ""; comment_strDate2 = "";

        //                i++;
        //                if (region_cur == region_prev)
        //                {
        //                    htmldata += @"
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td style='width:17%;'> " + dr["RegionalOffice"].ToString() + @" </td> <td style='width:17%;'> " + dr["CreatedBy"].ToString() + @" </td> <td style='width:17%;'> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                }
        //                else
        //                {

        //                    if (i == 1)
        //                    {
        //                        htmldata += @"
        //                   <tr><th colspan=""7"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td style='width:17%;'> " + dr["RegionalOffice"].ToString() + @" </td> <td style='width:17%;'> " + dr["CreatedBy"].ToString() + @" </td> <td style='width:17%;'> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                    }
        //                    else
        //                    {
        //                        htmldata += @"

        //                                <tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th><th  class='text-center-imp'>" + sum_yesterday + @"</th><th  class='text-center-imp'>" + sum_today + @"</th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>

        //                  <tr><th colspan=""7"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td> " + dr["RegionalOffice"].ToString() + @" </td> <td> " + dr["CreatedBy"].ToString() + @" </td> <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                        pre_sum = 0; sum_yesterday = 0; sum_today = 0;

        //                    }




        //                }









        //                pre_sum = pre_sum + Convert.ToDecimal(dr["CumTotal"].ToString());
        //                sum_yesterday = sum_yesterday + Convert.ToDecimal(dr["CumYesterday"].ToString());
        //                sum_today = sum_today + Convert.ToDecimal(dr["Today"].ToString());
        //                region_prev = region_cur;
        //            }


        //            htmldata += @"<tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + sum_yesterday + @"</th> 
        //                                  <th class='text-center-imp'>" + sum_today + @"</th> 
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>";

        //            htmldata += " </table>";

        //            Literal loLit = new Literal();
        //            loLit.Text = (htmldata);
        //            ph.Controls.Add(loLit);


        //        }
        //    }







        //}





    }
}