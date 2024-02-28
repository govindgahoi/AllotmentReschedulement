using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class DataFieldStatistics : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                zRecords.Visible = false;
                //panel.Visible = false;
                btnsubmit.Enabled = false;
                dlRO.Enabled = false;
                bindRegionalOffice();
                dlDatafield.Items.Add("----Select----");
                dlDatafield.Items.Add("Interestrateapplicable");
                dlDatafield.Items.Add("emailID");
                dlDatafield.Items.Add("PhoneNo");
            }
            
        }
        private void bindRegionalOffice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            ListItem liRegional = new ListItem("---Select All---", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panel.Visible = false;
            if (dlRO.SelectedIndex == 0)
            {
                tblName.InnerHtml = "-----";
                colOptional.InnerHtml = "-----";
                colType.InnerHtml = "-----";
                zeroValue.InnerHtml = "-----";
                nullValue.InnerHtml = "-----";
                filledValue.InnerHtml = "-----";
                totalValue.InnerHtml = "-----";
                tblNamePer.InnerHtml = "-----";
                colOptionalPer.InnerHtml = "-----";
                colTypePer.InnerHtml = "-----";
                zeroValuePer.InnerHtml = "-----";
                nullValuePer.InnerHtml = "-----";
                filledValuePer.InnerHtml = "-----";
                totalValuePer.InnerHtml = "-----";
            }
            else
            {
                tblName.InnerHtml = "-----";
                colOptional.InnerHtml = "-----";
                colType.InnerHtml = "-----";
                zeroValue.InnerHtml = "-----";
                nullValue.InnerHtml = "-----";
                filledValue.InnerHtml = "-----";
                totalValue.InnerHtml = "-----";
                tblNamePer.InnerHtml = "-----";
                colOptionalPer.InnerHtml = "-----";
                colTypePer.InnerHtml = "-----";
                zeroValuePer.InnerHtml = "-----";
                nullValuePer.InnerHtml = "-----";
                filledValuePer.InnerHtml = "-----";
                totalValuePer.InnerHtml = "-----";
            }
        }

        protected void dlDatafield_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlDatafield.SelectedIndex == 0)
            {
                Label2.Text = "DATA FIELDS STATISTICS";
                btnsubmit.Enabled = false;
                dlRO.SelectedIndex = 0;
                dlRO.Enabled = false;
                getNullStatus();
            }
            else
            {
                Label2.Text = "DATA FIELDS STATISTICS";
                dlRO.SelectedIndex = 0;
                dlRO.Enabled = true;
                btnsubmit.Enabled = true;
                getNullStatus();
            }
        }


        protected void GetStatistic_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (dlDatafield.SelectedIndex == 1)
            {
                GetInterestRateApplicable();
            }
            else if (dlDatafield.SelectedIndex == 2)
            {
                GetEmailID();
            }
            else if (dlDatafield.SelectedIndex == 3)
            {
                GetPhoneNo();
            }
        }

        protected void GetInterestRateApplicable()
        {
            wRecords.Visible = false;
            if (dlRO.SelectedIndex == 0)
            {

                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics", con);
                string col_Option = "";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@columnName", dlDatafield.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "INTEREST RATE APPLICABLE STATISTICS";
                    zRecords.Visible = true;
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["ZeroValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();

                    zeroValuePer.InnerHtml = dt2.Rows[0]["ZeroValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "INTEREST RATE APPLICABLE STATISTICS";
                    zRecords.Visible = true;
                    getNullStatus();
                }
            }

            else
            {
                string col_Option = "";
                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics_regional", con);

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@columnName", dlDatafield.Text);
                cmd.Parameters.AddWithValue("@regionaloffice", dlRO.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "INTEREST RATE APPLICABLE STATISTICS";
                    zRecords.Visible = true;
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["ZeroValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();

                    zeroValuePer.InnerHtml = dt2.Rows[0]["ZeroValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "INTEREST RATE APPLICABLE STATISTICS";
                    zRecords.Visible = true;
                    getNullStatus();
                }
            }
        }

        protected void GetEmailID()
        {
            zRecords.Visible = false;
            if (dlRO.SelectedIndex == 0)
            {

                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics_emailID", con);
                string col_Option = "";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "EMAIL STATISTICS";
                    wRecords.Visible = true;
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["WrongValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();
                    //colTypePer.InnerHtml = "-----";
                    zeroValuePer.InnerHtml = dt2.Rows[0]["WrongValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "EMAIL STATISTICS";
                    wRecords.Visible = true;
                    getNullStatus();
                }
            }

            else
            {
                string col_Option = "";
                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics_emailID_RO", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@regionaloffice", dlRO.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "EMAIL STATISTICS";
                    wRecords.Visible = true;
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["WrongValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();

                    zeroValuePer.InnerHtml = dt2.Rows[0]["WrongValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "EMAIL STATISTICS";
                    wRecords.Visible = true;
                    getNullStatus();
                }
            }
        }

        protected void GetPhoneNo()
        {
            if (dlRO.SelectedIndex == 0)
            {

                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics_PhoneNo", con);
                string col_Option = "";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "PHONE NO. STATISTICS";
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["ZeroValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();

                    zeroValuePer.InnerHtml = dt2.Rows[0]["ZeroValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "PHONE NO. STATISTICS";
                    wRecords.Visible = true;
                    getNullStatus();
                }
            }

            else
            {
                string col_Option = "";
                SqlCommand cmd = new SqlCommand("usp_DataFieldStatistics_PhoneNo_RO", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@regionaloffice", dlRO.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    Label2.Text = "PHONE NO. STATISTICS";
                    tblName.InnerHtml = dt.Rows[0]["TABLE_NAME"].ToString();
                    col_Option = dt.Rows[0]["IS_NULLABLE"].ToString();
                    if (col_Option == "YES")
                    {
                        colOptional.InnerHtml = "Optional";
                    }
                    else
                    {
                        colOptional.InnerHtml = "Mandatory";
                    }
                    colType.InnerHtml = dt.Rows[0]["DATA_TYPE"].ToString();
                    zeroValue.InnerHtml = dt1.Rows[0]["ZeroValue"].ToString();
                    nullValue.InnerHtml = dt1.Rows[0]["NullValue"].ToString();
                    filledValue.InnerHtml = dt1.Rows[0]["FillValue"].ToString();
                    totalValue.InnerHtml = dt1.Rows[0]["TotalValue"].ToString();

                    zeroValuePer.InnerHtml = dt2.Rows[0]["ZeroValue"].ToString();
                    nullValuePer.InnerHtml = dt2.Rows[0]["NullValue"].ToString();
                    filledValuePer.InnerHtml = dt2.Rows[0]["FillValue"].ToString();
                    totalValuePer.InnerHtml = "100";
                }
                else
                {
                    Label2.Text = "PHONE NO. STATISTICS";
                    wRecords.Visible = true;
                    getNullStatus();
                }
            }
        }
        protected void getNullStatus()
        {
            tblName.InnerHtml = "-----";
            colOptional.InnerHtml = "-----";
            colType.InnerHtml = "-----";
            zeroValue.InnerHtml = "-----";
            nullValue.InnerHtml = "-----";
            filledValue.InnerHtml = "-----";
            totalValue.InnerHtml = "-----";
            tblNamePer.InnerHtml = "-----";
            colOptionalPer.InnerHtml = "-----";
            colTypePer.InnerHtml = "-----";
            zeroValuePer.InnerHtml = "-----";
            nullValuePer.InnerHtml = "-----";
            filledValuePer.InnerHtml = "-----";
            totalValuePer.InnerHtml = "-----";
        }

    }
}