using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Allotment
{
    public partial class MISReportInvestmentFeedback : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetGridData("");
                    Bind_ddlRegionalOffice();
                    //UserSpecificBinding();
                }

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }
        string query = "";
        string subject = "";
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            if (ddlPageIndex.SelectedValue != "0")
            {
                AllGrid.PageSize = Convert.ToInt16(ddlPageIndex.SelectedItem.Text);
                GetGridData(subject);
            }
            if (ddloffice.SelectedValue != "0")
            {
                subject += "and Inv_district like '%" + ddloffice.SelectedItem.Text.Trim() + "%'";
                GetGridData(subject);
            }
        }

        
        protected void GetGridData(string subject)
        {
            try
            {

                if (subject == "")
                {

                    query = "select * from UPSIDA_InvestorFeedBack where isActive=1 ";

                }
                else
                {
                    query = "select * from UPSIDA_InvestorFeedBack where isActive=1 "+subject.ToString().Trim()+"";
                    //query = "select * from WebAdmin_GRS_NewsLetters where Id !=000 and Status=1 and Upload_Doc !=''  " + subject.Trim();
                }
                
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(query, con);
                
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    AllGrid.PageSize = Convert.ToInt16(ddlPageIndex.SelectedItem.Text);
                    AllGrid.DataSource = dt;
                    AllGrid.DataBind();
                    
                }
                else
                {
                    this.AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }

        protected void AllGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AllGrid.PageSize = Convert.ToInt16(ddlPageIndex.SelectedItem.Text);
            AllGrid.PageIndex = e.NewPageIndex;
            GetGridData("");
        }

        public void Bind_ddlRegionalOffice()
        {

            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand command = new SqlCommand("[spGetRegionalDetail]", con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", "Admin1");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ddloffice.DataSource = dt;
            ddloffice.DataTextField = "a";
            ddloffice.DataValueField = "b";
            ddloffice.DataBind();
            ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));

        }

       
    }
}