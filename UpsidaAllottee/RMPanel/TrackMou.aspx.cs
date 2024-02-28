using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Data.SqlClient;
using System.Configuration;

namespace UpsidaAllottee.RMPanel
{
    public partial class TrackMou : System.Web.UI.Page
    {
       
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;string States = "", Searchs = "", ROs="";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]),level);
                }
                else 
                {
                    Response.Redirect("RMLogin.aspx");
                }

                 

            }

        }
        private void bindRegionalOffice_RM(string userName,string level)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            if (level == "RM")
            {
                cmd = new SqlCommand("usp_Regional_Office_RM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userName);
            }
            else
            {
                cmd = new SqlCommand("usp_Regional_Office", con);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();
            //dlRO.Items.Insert(0, "All");
            fill();
            //System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            //dlRO.Items.Insert(-1, "--Select--");

        }

        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex > 0)
            {
                fill();
            }
        }

        protected void fill()
        {
            DataSet ds1 = new DataSet();
            //if()
           // ROs = "and Regionaloffice   ='" + RegOff + "'";
            ds1 = ViewFillPlots(dlRO.SelectedValue,"","");
            DataTable dtDoc1 = ds1.Tables[0];
            //lblTotalPlot.Text = dtDoc1.Rows[0]["PlotNumber"].ToString().Trim();


            if (dtDoc1.Rows.Count > 0)
            {
                GridView1.DataSource = dtDoc1;
                GridView1.DataBind();
                //btnSave.Visible = true;
                lblTotalPlot.Text = dtDoc1.Rows.Count.ToString();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected DataSet ViewFillPlots(string RegOff , string States, string Searchs)
        {
            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM MOUTracker WHERE Regionaloffice!='Z' and Regionaloffice   ='" + RegOff + "' "+States+" "+Searchs+" ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record not Exist');", true);
            }
            return ds;
        }

        protected DataSet ViewFillFollowup(string MID)
        {
            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM MOUTracker WHERE  MID   ='" + MID + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record not Exist');", true);
            }
            return ds;
        }

        protected DataSet ViewFollowupDetails(string MID)
        {
            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM MOUTFollowup WHERE  MID   ='" + MID + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record not Exist');", true);
            }
            return ds;
        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
           
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string MID = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            string MIDS = gvrow.Cells[1].Text;

            lblMID.Text = MIDS;
            DataSet ds1 = new DataSet();
            ds1 = ViewFillFollowup(MIDS); 
            DataTable dtDoc1 = ds1.Tables[0];
            //lblTotalPlot.Text = dtDoc1.Rows[0]["PlotNumber"].ToString().Trim();


            if (dtDoc1.Rows.Count > 0)
            {
                GridView2.DataSource = dtDoc1;
                GridView2.DataBind();
                //btnSave.Visible = true;
                
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }

            DataSet ds3 = new DataSet();
            ds3= ViewFollowupDetails(MIDS);
            DataTable dtDoc3 = ds3.Tables[0];
            //lblTotalPlot.Text = dtDoc1.Rows[0]["PlotNumber"].ToString().Trim();


            if (dtDoc3.Rows.Count > 0)
            {
                GridView3.DataSource = dtDoc3;
                GridView3.DataBind();
                //btnSave.Visible = true;

            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
            //txtfname.Text = gvrow.Cells[2].Text;
            //txtlname.Text = gvrow.Cells[3].Text;
            //txtCity.Text = gvrow.Cells[4].Text;
            //txtDesg.Text = gvrow.Cells[5].Text;
            //this.ModalPopupExtender1.Show();
            // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString); ;
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.Connection = con;
                    command.CommandText = ("INSERT INTO dbo.MOUTFollowup (mid,status, remark, fdate, cdate, CreateBy) values( '" + lblMID.Text + "','" + ddlStatus.SelectedItem.Text + "','" +  txtremark.Text.Trim() + "','" + txtdate.Text.Trim() + "', getdate(),'" + Session["UserName"].ToString() + "' )");
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Followup Added Successfully');", true);
                        con.Close();
                        //reset();
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);

                }
            
             
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ddlState.SelectedIndex > 0)
            {
                States = " and OfficeLocation ='"+ ddlState.SelectedItem.Text+ "'";
            }
            if (txtsearch.Text != "")
            {
                Searchs = "and ( ProjectName Like '" + txtsearch.Text + "%' or InvestorName Like '" + txtsearch.Text + "%' or  Sector Like '" + txtsearch.Text + "%')";
            }
            DataSet ds1 = new DataSet();
            ds1 = ViewFillPlots(dlRO.SelectedValue, States, Searchs);
            DataTable dtDoc1 = ds1.Tables[0];
            //lblTotalPlot.Text = dtDoc1.Rows[0]["PlotNumber"].ToString().Trim();


            if (dtDoc1.Rows.Count > 0)
            {
                GridView1.DataSource = dtDoc1;
                GridView1.DataBind();
                //btnSave.Visible = true;
                lblTotalPlot.Text = dtDoc1.Rows.Count.ToString();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }
}