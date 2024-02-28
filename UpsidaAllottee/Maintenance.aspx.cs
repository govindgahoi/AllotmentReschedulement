using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UpsidaAllottee
{
    public partial class Maintenance : System.Web.UI.Page
    {
        decimal GrandTotal = 0;
        bool flag = false;
        
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRegionalOffice();
                bindIndustrialArea();
                DlIA.Enabled = false;
                txtSearch1.Enabled = false;
                Calendar1.SelectedDate = DateTime.Today;
                btnpay.Visible = false;
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
            ListItem liRegional = new ListItem("--Select All--", "-1");
            dlRO.Items.Insert(0, liRegional);
        }
        private void bindIndustrialArea()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("usp_Indust_Area", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@regionalOffice", dlRO.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DlIA.DataSource = dt;
            DlIA.DataTextField = "IAName";
            DlIA.DataValueField = "IAName";
            DlIA.DataBind();
            ListItem liIArea = new ListItem("--Select All--", "-1");
            DlIA.Items.Insert(0, liIArea);

        }
        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel.Visible = false;
            if (dlRO.SelectedIndex == 0)
            {
                DlIA.SelectedIndex = 0;
                txtSearch1.Text = null;
                txtSearch1.Enabled = false;
                DlIA.Enabled = false;
                btnpay.Visible = false;

            }
            else
            {
                bindIndustrialArea();
                DlIA.Enabled = true;
                txtSearch1.Text = null;
                txtSearch1.Enabled = false;
                btnpay.Visible = false;
            }


        }

        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel.Visible = false;
            if (DlIA.SelectedIndex == 0)
            {
                txtSearch1.Text = null;
                txtSearch1.Enabled = false;
                btnpay.Visible = false;
            }
            else
            {
                txtSearch1.Text = null;
                txtSearch1.Enabled = true;
                btnpay.Visible = false;

            }
        }

        protected void Demand_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (dlRO.SelectedIndex == 0 && DlIA.SelectedIndex == 0)
            {
                flag = true;
                
                string date = "";
                date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand("usp_Total_InterestAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@enddate", date);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridTotalDetail.Visible = true;
                gridTotalDetail.DataSource = dt;
                gridTotalDetail.DataBind();
                btnpay.Visible = false;
                if (dt.Rows.Count > 0) { }
                else
                {
                    gridTotalDetail.Visible = true;
                }
            }
            else if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex == 0 && (txtSearch1.Text == null || txtSearch1.Text == ""))
            {
                flag = true;
                string date = "";
                date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand("usp_Regional_InterestAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@enddate", date);
                cmd.Parameters.AddWithValue("@RegionalOffice", dlRO.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridTotalDetail.Visible = true;
                gridTotalDetail.DataSource = dt;
                gridTotalDetail.DataBind();
                btnpay.Visible = false;
                if (dt.Rows.Count > 0) { }
                else
                {
                    gridTotalDetail.Visible = true;
                }

            }
            else if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex != 0 && (txtSearch1.Text == null || txtSearch1.Text == ""))
            {
                flag = false;
                string date = "";
                date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand("usp_IA_InterestAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@enddate", date);
                cmd.Parameters.AddWithValue("@RegionalOffice", dlRO.Text);
                cmd.Parameters.AddWithValue("@IndustrialArea", DlIA.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridTotalDetail.Visible = true;
                gridTotalDetail.DataSource = dt;
                gridTotalDetail.DataBind();
                btnpay.Visible = false;
                if (dt.Rows.Count > 0) { }
                else
                {
                    gridTotalDetail.Visible = true;
                }

            }
            else if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex != 0 && (txtSearch1.Text != null || txtSearch1.Text != ""))
            {
                flag = false;
                string date = "";
                date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand("usp_Plot_InterestAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@enddate", date);
                cmd.Parameters.AddWithValue("@PlotNo", txtSearch1.Text);
                cmd.Parameters.AddWithValue("@IndustrialArea", DlIA.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridTotalDetail.Visible = true;
                gridTotalDetail.DataSource = dt;
                gridTotalDetail.DataBind();
                btnpay.Visible = true;
                if (dt.Rows.Count > 0)
                {
                    btnpay.Enabled = true;
                }
                else
                {
                    btnpay.Enabled = false;
                    gridTotalDetail.Visible = true;
                }
            }
            else
            {
                btnpay.Visible = true;
                flag = false;
                gridTotalDetail.Visible = false;
            }
        }

        decimal Total_Dues = 0;
        decimal Total_Interest = 0;
        decimal Total = 0;
        object intrstMain;
        object intrstMain1;
        object value1;
        protected void gridTotalDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (flag == true)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text + " (In Lacs)";
                    e.Row.Cells[2].Text = "INTEREST UPTO " + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + " (In Lacs)";
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + " (In Lacs)";
                    e.Row.Cells[0].Font.Size = 15;
                    e.Row.Cells[1].Font.Size = 15;
                    e.Row.Cells[2].Font.Size = 15;
                    e.Row.Cells[3].Font.Size = 15;
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text + " (In INR.)";
                    e.Row.Cells[2].Text = "INTEREST UPTO " + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + " (In INR.)";
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + " (In INR.)";
                    e.Row.Cells[0].Font.Size = 15;
                    e.Row.Cells[1].Font.Size = 15;
                    e.Row.Cells[2].Font.Size = 15;
                    e.Row.Cells[3].Font.Size = 15;
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Font.Size = 14;
                e.Row.Cells[1].Font.Size = 14;
                e.Row.Cells[2].Font.Size = 14;
                e.Row.Cells[3].Font.Size = 14;
                value1 = DataBinder.Eval(e.Row.DataItem, "Dues");

                if (value1 != DBNull.Value)
                {
                    Total_Dues += Convert.ToDecimal(value1);

                    if (Convert.ToDecimal(value1) <= 0)
                    {
                        //dues = Convert.ToInt64(dues);
                        e.Row.Cells[1].Text = "NIL";
                        e.Row.Cells[2].Text = "NIL";

                    }
                    else
                    {
                        e.Row.Cells[1].Text = string.Format("{0:N}", value1);
                    }

                }

                object value2 = DataBinder.Eval(e.Row.DataItem, "TotalInterest");
                if (value2 != DBNull.Value)
                {
                    Total_Interest += Convert.ToDecimal(value2);
                    if (Convert.ToDecimal(value2) <= 0)
                    {
                        e.Row.Cells[2].Text = "NIL";
                    }
                    else
                    {
                        e.Row.Cells[2].Text = string.Format("{0:N}", value2);
                    }
                    if (e.Row.Cells[0].Text == "Maintenance Charges")
                    {
                        intrstMain = DataBinder.Eval(e.Row.DataItem, "TotalInterest");
                        e.Row.Cells[3].Text = string.Format("{0:N}", value1);
                        e.Row.Cells[2].BackColor = System.Drawing.Color.Orange;
                        //e.Row.Cells[0].Text = "Total";
                    }
                    else {
                        intrstMain1 = DataBinder.Eval(e.Row.DataItem, "Dues");
                        e.Row.Cells[1].BackColor = System.Drawing.Color.Orange;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
                    }

                }
                if (intrstMain == DBNull.Value && intrstMain1 != DBNull.Value)
                {
                    Total += Convert.ToDecimal(intrstMain1);
                }
                else if (intrstMain != DBNull.Value && intrstMain1 == DBNull.Value)
                    {
                    Total += Convert.ToDecimal(intrstMain);
                }
                else if (intrstMain == DBNull.Value && intrstMain1 == DBNull.Value)
                {
                    Total = Total;
                }
                else 
                {
                    Total = Convert.ToDecimal(intrstMain) + Convert.ToDecimal(intrstMain1);
                }


                if (e.Row.Cells[0].Text != "Maintenance Charges")
                {
                    e.Row.Cells[3].Text = string.Format("{0:N}", Total);
                }
                else
                {
                    e.Row.Cells[3].Text = string.Format("{0:N}", value1);
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.Aquamarine;
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].Font.Size = 15;

                // e.Row.Cells[1].Text = string.Format("{0:c0}", Total_Dues); For No Decimal value
                if (Total_Dues >= 0)
                {
                    e.Row.Cells[1].Text = string.Format("{0:N}", Total_Dues);
                    e.Row.Cells[1].Font.Bold = true;
                    e.Row.Cells[1].Font.Size = 15;
                }
                else
                {
                    e.Row.Cells[1].Text = string.Format("{0:N}", Total_Dues) + " Access Payment";
                    e.Row.Cells[1].Font.Bold = true;
                    e.Row.Cells[1].Font.Size = 15;
                }

                e.Row.Cells[2].Text = string.Format("{0:N}", Total_Interest);
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[2].Font.Size = 15;

                GrandTotal = Total_Dues + Total_Interest;
               // GrandTotal = decimal.Truncate(GrandTotal);

                if (GrandTotal > 0)
                {
                    e.Row.Cells[3].Text = string.Format("{0:N}", GrandTotal);
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[3].Font.Size = 15;
                    btnpay.Enabled = true;
                }
                else if (GrandTotal < 0)
                {
                    e.Row.Cells[3].Text = string.Format("{0:N}", GrandTotal) + " Access Payment";
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[3].Font.Size = 15;
                    btnpay.Enabled = false;
                }
                else
                {
                    e.Row.Cells[3].Text = "NIL";
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[3].Font.Size = 15;
                    btnpay.Enabled = false;

                }
               
            }
          
            }
       
        protected void Calender1_OnSelectionChanged(object sender, System.EventArgs e)
        {
            panel.Visible = false;
        }
       


        protected void pageredirectToNivesh(object sender, EventArgs e)
        {
            //alert("Redirecting To Nivesh Mitra Site...");
            Response.Redirect("/AllotteePayMaintenance.aspx");
        }

    }
}