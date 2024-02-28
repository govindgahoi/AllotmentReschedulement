using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment.AllotteePanel
{
    public partial class DashBoard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                if (Session["UserId"] != null)
                {
                    if (!IsPostBack)
                    {

                        BindAllotteeServiceRequest();
                    }
                }
                else
                {
                    Response.Redirect("AllotteeLogin.aspx");
                }


            }
            catch (Exception ex)
            {
                Response.Redirect("AllotteeLogin.aspx");
            }

        }

        //private void BindAllotteePaymentDues()
        //{
        //    string userids = Session["UserId"].ToString();

        //    SqlCommand cmd = new SqlCommand("[ZNK_GetAllotteePaymntDues] '" + userids + "'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblTotDues.Text = dt.Rows[0]["Outstanding"].ToString();
        //    }
        //    else
        //    {
        //        lblTotDues.Text = "0";
        //    }
        //}

        private void BindAllotteeServiceRequest()
        {
            string userids = Session["UserId"].ToString();
            SqlCommand cmd = new SqlCommand("[ZNK_GetAllotteeServiceRequest] '" + userids + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];
            DataTable dt4 = ds.Tables[3];
            if (dt1.Rows.Count > 0)
            {
                lblTotDues.Text = dt1.Rows[0][0].ToString();
            }
            else
            {
                lblTotDues.Text = "0";
            }
            if (dt2.Rows.Count > 0)
            {
                lblApplied.Text = dt2.Rows[0][0].ToString();
            }
            else
            {
                lblApplied.Text = "0";
            }
            if (dt3.Rows.Count > 0)
            {
                lblPending.Text = dt3.Rows[0][0].ToString();
            }
            else
            {
                lblPending.Text = "0";
            }
            if (dt4.Rows.Count > 0)
            {
                GridAllotteeService.DataSource = dt4;
                GridAllotteeService.DataBind();                 
            }
            else
            {
                GridAllotteeService.DataSource = null;
                GridAllotteeService.DataBind();
            }
        }

    }
}