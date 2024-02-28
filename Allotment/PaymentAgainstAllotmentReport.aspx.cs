using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PaymentAgainstAllotmentReport : System.Web.UI.Page
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
                drpdwnIA.DataValueField = "Id";
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
            objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
            objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.PaymentMode = (ddlPayMode.SelectedValue.Trim());
            objServiceTimelinesBEL.ServiceTimeLines = (1000).ToString();
            objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
            objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;
            objServiceTimelinesBEL.searchText = txtSearch.Text;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfApplicationForAccountClearanceRepots(objServiceTimelinesBEL);
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
                decimal total_count = 0, pre_sum = 0, pre_totalArea = 0,
                    Pre_SumGST = 0, Pre_SumGSTFormFees = 0, SumProcessingFees = 0, SumApplicationFees = 0, SumEMD = 0, SumTotal = 0;
                htmldata = "";

                if (dt.Rows.Count > 0)
                {
                    total_count = Convert.ToDecimal(dt.Compute("SUM(GSTFormFees)", string.Empty));
                    string report_date = date_today.ToString("MMMM d, yyyy");
                    htmldata = @"<h2 style = ""text-decoration:underline;"" >List of Applications<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span></h2>
                      <!--<div class='table-responsive'>-->
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
                                DateTime date = Convert.ToDateTime(dr["TransactionDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"
                                    <tr> <td>" + i.ToString() + "</td>  " +
                                    "<td>" + dr["ServiceRequestNO"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CompanyName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTOnProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["FormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTFormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["EMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Total"].ToString() + @"</td>
                                 <td class='text-center-imp'>" + transation_date + @"</td>
                                </tr>";
                            }
                            else
                            {

                                DateTime date = Convert.ToDateTime(dr["TransactionDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr><th colspan=""12"" class='head-IAname'>" + dr["IAName"].ToString() + @"</th></tr> 
                                <tr style='background:#f7f7f7;'>
                            <th style='width:5%;'>S.NO</th>
                            <th style='width:15%;'>Service RequestNO</th>
                            <th style='width:12%;'>Applicant Name</th>
                            <th style='width:12%;'>Company Name</th>
                            <th style='width:7%;'>PlotSize</th>
                            <th style='width:6%;'>Processing Fees</th>
                            <th style='width:6%;'>GST on Processing Fees</th>
                            <th style='width:6%;'>Application Fees</th>
                            <th style='width:7%;'>GST on Application Fees</th>
                            <th style='width:7%;'>EMD</th>
                            <th style='width:7%;'>Total</th>
                            <th style='width:14%;'>Date</th>
                        </tr>
                          <tr> 
                                 <td> " + i.ToString() + " </td >  <td>" + dr["ServiceRequestNO"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CompanyName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTOnProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["FormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTFormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["EMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Total"].ToString() + @"</td>
                                <td class='text-center-imp'>" + transation_date + @"</td>
                         </tr>";
                            }

                        }
                        else
                        {
                            if (i == 1)
                            {
                                DateTime date = Convert.ToDateTime(dr["TransactionDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr><th class='head-region' colspan=""12"">" + dr["RegionalOffice"].ToString() + @"</th></tr> 
                                <tr><th colspan=""12"" class='head-IAname'>" + dr["IAName"].ToString() + @"</th></tr> 
                                <tr style='background:#f7f7f7;'>
                            <th style='width:5%;'>S.NO</th>
                            <th style='width:15%;'>Service RequestNO</th>
                            <th style='width:12%;'>Applicant Name</th>
                            <th style='width:12%;'>Company Name</th>
                            <th style='width:7%;'>PlotSize</th>
                            <th style='width:6%;'>Processing Fees</th>
                            <th style='width:6%;'>GST on Processing Fees</th>
                            <th style='width:6%;'>Application Fees</th>
                            <th style='width:7%;'>GST on Application Fees</th>
                            <th style='width:7%;'>EMD</th>
                            <th style='width:7%;'>Total</th>
                            <th style='width:14%;'>Date</th>
                        </tr>
                          <tr> 
                          <td> " + i.ToString() + " </td >  <td>" + dr["ServiceRequestNO"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CompanyName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTOnProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["FormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTFormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["EMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Total"].ToString() + @"</td>
                                 <td class='text-center-imp'>" + transation_date + @"</td>
                         </tr>";

                            }
                            else
                            {
                                DateTime date = Convert.ToDateTime(dr["TransactionDate"].ToString());
                                string transation_date = date.ToString("MMMM d, yyyy");
                                htmldata += @"<tr  style='background:#f7f7f7;' class='head-total'>
                                          <th colspan=""4"" class='head-total'><span class=""pull-right"">Total " + region_prev + @"</span></th>
                                            <th class='text-center-imp head-total'>" + pre_totalArea + @"</th>
                                            <th class='text-center-imp head-total'>" + SumProcessingFees + @"</th>
                                          <th class='text-center-imp head-total'>" + Pre_SumGST + @"</th>
                                            <th class='text-center-imp head-total'>" + SumApplicationFees + @"</th>
                                          <th class='text-center-imp head-total'>" + Pre_SumGSTFormFees + @"</th>
                                          <th class='text-center-imp head-total'>" + SumEMD + @"</th>
                                          <th class='text-center-imp head-total'>" + SumTotal + @"</th>
                                          <th class='text-center-imp head-total'></th>
                                          </tr>
                                          <tr style='background:#f7f7f7;'><th colspan=""12"" class='head-region'>" + dr["RegionalOffice"].ToString() + @"</th></tr>
                                            <tr style='background:#f7f7f7;'><th colspan=""12"" class='head-IAname'>" + dr["IAName"].ToString() + @"</th></tr>
                                            <tr style='background:#f7f7f7;'>
                            <th style='width:5%;'>S.NO</th>
                            <th style='width:15%;'>Service RequestNO</th>
                            <th style='width:12%;'>Applicant Name</th>
                            <th style='width:12%;'>Company Name</th>
                            <th style='width:7%;'>PlotSize</th>
                            <th style='width:6%;'>Processing Fees</th>
                            <th style='width:6%;'>GST on Processing Fees</th>
                            <th style='width:6%;'>Application Fees</th>
                            <th style='width:7%;'>GST on Application Fees</th>
                            <th style='width:7%;'>EMD</th>
                            <th style='width:7%;'>Total</th>
                            <th style='width:14%;'>Date</th>
                        </tr>
                          <tr> 
                           <td> " + i.ToString() + " </td >  <td>" + dr["ServiceRequestNO"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ApplicantName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["CompanyName"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["PlotSize"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["ProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTOnProcessingFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["FormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["GSTFormFees"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["EMD"].ToString() + @"</td>
                                <td class='text-center-imp'>" + dr["Total"].ToString() + @"</td>
                                 <td class='text-center-imp'>" + transation_date + @"</td>
                         </tr>";
                                Pre_SumGST = 0;
                                Pre_SumGSTFormFees = 0;
                                pre_sum = 0;
                                SumProcessingFees = 0;
                                SumApplicationFees = 0;
                                SumEMD = 0;
                                SumTotal = 0;
                                pre_totalArea = 0;
                            }
                        }
                        pre_sum = pre_sum + Convert.ToDecimal(dr["TransactionAmount"].ToString());
                        Pre_SumGST = Pre_SumGST + Convert.ToDecimal(dr["GSTOnProcessingFees"].ToString());
                        Pre_SumGSTFormFees = Pre_SumGSTFormFees + Convert.ToDecimal(dr["GSTFormFees"].ToString());
                        SumProcessingFees = SumProcessingFees + Convert.ToDecimal(dr["ProcessingFees"].ToString());
                        SumApplicationFees = SumApplicationFees + Convert.ToDecimal(dr["FormFees"].ToString());
                        SumEMD = SumEMD + Convert.ToDecimal(dr["EMD"].ToString());
                        SumTotal = SumTotal + Convert.ToDecimal(dr["Total"].ToString());
                        pre_totalArea = pre_totalArea + Convert.ToDecimal(dr["PlotSize"].ToString());
                        region_prev = region_cur;
                        industrial_prev = industrial_cur;
                    }
                    htmldata += @"<tr style='background:#f7f7f7;' >
                                          <th colspan=""4"" class='head-total'><span class=""pull-right"">Total " + region_prev + @"</span></th>
                                          <th class='text-center-imp head-total'>" + pre_totalArea + @"</th>
                                            <th class='text-center-imp head-total'>" + SumProcessingFees + @"</th>
                                          <th class='text-center-imp head-total'>" + Pre_SumGST + @"</th>
                                            <th class='text-center-imp head-total'>" + SumApplicationFees + @"</th>
                                          <th class='text-center-imp head-total'>" + Pre_SumGSTFormFees + @"</th>
                                          <th class='text-center-imp head-total'>" + SumEMD + @"</th>
                                          <th class='text-center-imp head-total'>" + SumTotal + @"</th>
                                            <th class='text-center-imp head-total'></th>
                                          </tr>";

                    htmldata += " </table><!--</div>-->";

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

        protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
    }
}