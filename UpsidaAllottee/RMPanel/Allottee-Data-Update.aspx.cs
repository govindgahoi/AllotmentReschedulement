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
using Allotment.Classes;

namespace UpsidaAllottee.RMPanel
{
    public partial class Allottee_Data_Update : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con; string States = "", Searchs = "", ROs = "";
        Class1 cs = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]), level);
                    bindTypeOfIndustry();
                }
                else
                {
                    Response.Redirect("RMLogin.aspx");
                }



            }

        }

        private void bindRegionalOffice_RM(string userName, string level)
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
            dlRO.Items.Insert(0, "Select");

            //System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            //dlRO.Items.Insert(-1, "--Select--");

        }

        protected void dlRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlRO.SelectedIndex > 0)
            {
                ddlIA.Items.Clear();
                ddlIA.Items.Insert(0, new ListItem("Select Industrial Area", "0"));

                try { bindDDLRegion(dlRO.SelectedItem.Value, null); } catch { }
                //fill();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //warningmsg.Visible = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_getAllotteDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IAName", ddlIA.SelectedValue);
            cmd.Parameters.AddWithValue("@PlotNo", "");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //gr.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = true;
            }
        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "IAName";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, "Select");

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        private void bindTypeOfIndustry()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTypeoFIndustry();
                ddlTypeOfIndustry.DataSource = ds;
                ddlTypeOfIndustry.DataTextField = "IndustrialClassificationName";
                ddlTypeOfIndustry.DataValueField = "ClassificationID";
                ddlTypeOfIndustry.DataBind();
                ddlTypeOfIndustry.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        protected void Edit(object sender, EventArgs e)
        {
            try
            {
                
                LinkButton btndetails = sender as LinkButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                string MID = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
                string ALTNOS = gvrow.Cells[3].Text;
                cs.str = "SELECT emailID,PhoneNo,AllotteeName, Allotmentletterno,convert(VARCHAR,DateofProductionStart,101) as DateofProductionStart FROM AllotteeMaster WHERE Allotmentletterno='" + ALTNOS + "'";
                DataTable dt = new DataTable(); DataTable dt1 = new DataTable();
                dt = cs.GetDataTable(cs.str);
                if (dt.Rows.Count > 0)
                {
                    lblAName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblALetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                    txtEmail.Text = dt.Rows[0]["emailID"].ToString();
                    txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtDate.Text = dt.Rows[0]["DateofProductionStart"].ToString();

                    cs.str = "SELECT count(*)  FROM AllotteeProjectDetails WHERE ApplicantId='" + lblALetterNo.Text + "'";
                    int counts = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                    if (counts > 0)
                    {
                        cs.str = "SELECT *  FROM AllotteeProjectDetails WHERE ApplicantId='" + lblALetterNo.Text + "'";
                        dt1 = cs.GetDataTable(cs.str);
                        {
                            txtEmployment.Text = dt1.Rows[0]["EmploymentGenerated"].ToString();
                            ddlTypeOfIndustry.SelectedItem.Text = dt1.Rows[0]["IndustryType"].ToString();
                            txtInvestment.Text = dt1.Rows[0]["EstimatedCostOfProject"].ToString();
                            txtUnit.Text = dt1.Rows[0]["PowerReqInKW"].ToString();
                        }
                    }
                    if (txtDate.Text != "01/01/1900")
                    {
                        btnUpdate.Enabled = false;
                    }
                    //else
                    //{
                    //    btnUpdate.Enabled = true;
                    //}
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.StackTrace;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cs.str = "UPDATE dbo.AllotteeMaster SET DateofProductionStart='" + txtDate.Text + "',emailID = '" + txtEmail.Text.Trim() + "',PhoneNo='" + txtPhone.Text.Trim() + "' WHERE Allotmentletterno = '" + lblALetterNo.Text + "' ";
                cs.ExecuteSql(cs.str);
                cs.str = "SELECT count(*)  FROM AllotteeProjectDetails WHERE ApplicantId='" + lblALetterNo.Text + "'";
                int counts = Convert.ToInt32(cs.ExecuteScaler(cs.str));
                if (counts > 0)
                {
                    cs.str = "UPDATE dbo.AllotteeProjectDetails SET EmploymentGenerated = '" + txtEmployment.Text + "',IndustryType='" + ddlTypeOfIndustry.SelectedItem.Text + "',EstimatedCostOfProject='" + txtInvestment.Text + "' ,PowerReqInKW='" + txtUnit.Text + "' WHERE ApplicantId = '" + lblALetterNo.Text + "' ";
                    cs.ExecuteSql(cs.str);
                }
                else
                {
                    cs.str = "INSERT INTO dbo.AllotteeProjectDetails (EstimatedCostOfProject, PowerReqInKW, EmploymentGenerated, IndustryType,ApplicantId) VALUES ('" + txtInvestment.Text + "','" + txtUnit.Text + "', '" + txtEmployment.Text + "', '" + ddlTypeOfIndustry.SelectedItem.Text + "','" + lblALetterNo.Text + "')";
                    cs.ExecuteSql(cs.str);
                }
                lblmsg.Text = "Record Updated.. ";
                Response.Redirect("Allottee-Data-Update.aspx");
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.StackTrace;
            }
            
        }
    }
}