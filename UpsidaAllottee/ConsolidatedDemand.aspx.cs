using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;


namespace UpsidaAllottee
{
    public partial class ConsolidatedDemand : System.Web.UI.Page
    {
        decimal TotalRecoverable = 0;
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRegionalOffice();
                bindIndustrialArea();
                Label1.Visible = false;
                //DlIA.Enabled = false;
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

                DlIA.Enabled = false;
                //Label2.Visible = false;
                lblRecoverable.Text = "";
            }
            else
            {
                bindIndustrialArea();
                DlIA.Enabled = true;
               
                //Label2.Visible = false;
            }


        }

        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel.Visible = false;
            if (DlIA.SelectedIndex == 0)
            {
                
            }
            else
            {
                //Label2.Visible = false;
            }
        }
        
        //protected void Demand_Click(object sender, EventArgs e)
        //{

        //}
        protected void Demand_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (dlRO.SelectedIndex == 0 && DlIA.SelectedIndex == 0)
            {

                SqlCommand cmd = new SqlCommand("usp_Total_ConsolidatedDemand", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Label2.Visible = false;
                    //GridViewledger.Visible = false;
                    gridTotalDetail.Visible = true;
                    gridTotalDetail.DataSource = dt;
                    gridTotalDetail.DataBind();
                    Label1.Visible = true;
                    lblRecoverable.Visible = true;

                }
                else
                {
                    lblRecoverable.Visible = false;
                    Label1.Visible = false;
                    gridTotalDetail.Visible = false;

                }
            }
            else if(dlRO.SelectedIndex != 0 && DlIA.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("usp_Regional_ConsolidatedDemand", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@regionalOffice", dlRO.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Label2.Visible = false;
                    //GridViewledger.Visible = false;
                    gridTotalDetail.Visible = true;
                    gridTotalDetail.DataSource = dt;
                    gridTotalDetail.DataBind();
                    Label1.Visible = true;
                    lblRecoverable.Visible = true;

                }
                else 
                {
                    lblRecoverable.Visible = false;
                    Label1.Visible = false;
                    gridTotalDetail.Visible = false;
                }

            }
            else if (dlRO.SelectedIndex != 0 && DlIA.SelectedIndex != 0)
            {
                SqlCommand cmd = new SqlCommand("usp_IA_ConsolidatedDemand", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IAName", DlIA.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Label2.Visible = false;
                    //GridViewledger.Visible = false;
                    gridTotalDetail.Visible = true;
                    gridTotalDetail.DataSource = dt;
                    gridTotalDetail.DataBind();
                    Label1.Visible = true;
                    lblRecoverable.Visible = true;

                }
                else
                {
                    Label1.Visible = false;
                    lblRecoverable.Visible = false;
                    gridTotalDetail.Visible = false;
                }

            }
            else
            {
                lblRecoverable.Text = "**Please select Regional Office too.";
                //lblRecoverable.ForeColor= System.Drawing.Color.Red;
                Label1.Visible = false;
                gridTotalDetail.Visible = false;
            }
        }

        decimal Total_demand=0;
        decimal Total_Paid=0;
        protected void gridTotalDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = e.Row.Cells[1].Text + " (In Lacs)";
                e.Row.Cells[2].Text = e.Row.Cells[2].Text + " (In Lacs)";
                //e.Row.Cells[3].Text = e.Row.Cells[3].Text + " (In Lacs)";
                e.Row.Cells[0].Font.Size = 18;
                e.Row.Cells[1].Font.Size = 18;
                e.Row.Cells[2].Font.Size = 18;
            }
                if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Font.Size = 17;
                object value1 = DataBinder.Eval(e.Row.DataItem, "Demand");
                if(value1 != DBNull.Value)
                {
                    Total_demand += Convert.ToDecimal(value1);
                    e.Row.Cells[1].Text = string.Format("{0:N}", value1);
                    e.Row.Cells[1].Font.Size = 17;
                }
                
                object value2 = DataBinder.Eval(e.Row.DataItem, "Paid");
                if (value2 != DBNull.Value)
                {
                    Total_Paid += Convert.ToDecimal(value2);
                    e.Row.Cells[2].Text = string.Format("{0:N}", value2);
                    e.Row.Cells[2].Font.Size = 17;
                }
               
            }
            else if(e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.Aquamarine;
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].Font.Size = 18;

                e.Row.Cells[1].Text = string.Format("{0:N}", Total_demand);
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 18;

                e.Row.Cells[2].Text = string.Format("{0:N}", Total_Paid);
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[2].Font.Size = 18;
            }
            TotalRecoverable = Total_demand - Total_Paid;
            lblRecoverable.Text = string.Format("{0:c}", TotalRecoverable) + " Lacs";

        }
    }
}