using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PaymentGSTReports : System.Web.UI.Page
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
                ds = objServiceTimelinesBLL.GetListOfApplicationForAccountClearanceGSTRepots(objServiceTimelinesBEL);
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
                ph.Controls.Clear();
                DateTime date_today = DateTime.Now;
                string region_prev = "", region_cur = "";
                string htmldata = "";
                if (dt.Rows.Count > 0)
                {

                    string report_date = date_today.ToString("MMMM d, yyyy hh:mm:ss tt");
                    string prev_report_date = DateTime.Now.AddDays(-1).ToString("MMM d");
                    string report_date_f1 = date_today.ToString("MMM d");
                    htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><h2 style = ""text-decoration:underline;"" >GST Against Allotment</h2> 
                                <table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
                                <tr style='background:#f7f7f7;'> 
                                </tr></table><br />

                      <table class=""table table-bordered table-hover request-table"">
                        <tr style='background:#f7f7f7;'>
                            <th style=""width:2%;"">S.NO</th>
                            <th style=""width:4%;"">Regional Office</th>
                            <th style=""width:5%;"">Industrial Area</th>
                            <th style=""width:12%;"">ServiceRequestNO</th>
                            <th style=""width:10%;"">Applicant Name</th>
                            <th class=""text-center"" style=""width:8%;"">GST On Application Fees</th>
                            <th class=""text-center"" style=""width:8%;"">GST On Processing Charges</th>
                            <th class=""text-center"" style=""width:6%;"">Total</th>
                        </tr>";

                    i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        i++;
                        if (region_cur == region_prev)
                        {
                            htmldata += @"
                          <tr> 
                          <td> " + i.ToString() + "</td >" +
                          " <td> " + dr["RegionalOffice"].ToString() + @" </td> 
                            <td> " + dr["IANAme"].ToString() + @"  </td>
                            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                          <td> " + dr["ApplicantName"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                         </tr>";

                        }
                        else
                        {

                            if (i == 1)
                            {
                                htmldata += @"
                          <tr> 
                        <td> " + i.ToString() + "</td >" +
                          "<td> " + dr["RegionalOffice"].ToString() + @" </td> 
                            <td> " + dr["IANAme"].ToString() + @"  </td>
                            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                          <td> " + dr["ApplicantName"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                         </tr>";

                            }
                            else
                            {
                                htmldata += @"
                          <tr> 
                         <td> " + i.ToString() + "</td >" +
                          " <td> " + dr["RegionalOffice"].ToString() + @" </td> 
                            <td> " + dr["IANAme"].ToString() + @"  </td>
                            <td> " + dr["ServiceRequestNO"].ToString() + @" </td> 
                          <td> " + dr["ApplicantName"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTFormFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["GSTOnProcessingFees"].ToString() + @" </td>
                          <td class='text-center-imp'> " + dr["Total"].ToString() + @" </td>
                         </tr>";
                            }
                        }
                    }

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