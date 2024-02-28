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
    public partial class AllotteeDues : System.Web.UI.Page
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
                        BindAlotmentNO();
                    }
                }
                else
                {
                    Response.Redirect("AllotteeLogin.aspx");
                }
                

            }
            catch(Exception ex)
            {
                Response.Redirect("AllotteeLogin.aspx");
            }
 
        }


        private void BindAlotmentNO()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[ZNK_GetCompletedAlloteeDetail] '" + Session["AID"].ToString() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlAlotmentNo.DataSource = dt;
                ddlAlotmentNo.DataTextField = "AllotmentNo";
                ddlAlotmentNo.DataValueField = "allotteeID";
                ddlAlotmentNo.DataBind();
                ddlAlotmentNo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        protected void ShowPopup(object sender, EventArgs e)
        {

        }


        private void BindAllotteePaymentSummary()
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + ddlAlotmentNo.SelectedValue.Trim() + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteePaymentSummaruGrid.DataSource = dt;
                AllotteePaymentSummaruGrid.DataBind();
                decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("Demanded"));
                decimal tot_Paid = dt.AsEnumerable().Sum(row => row.Field<decimal>("Paid"));
                decimal tot_Outstanding = dt.AsEnumerable().Sum(row => row.Field<decimal>("Outstanding"));
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].Text = "Total";
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                AllotteePaymentSummaruGrid.FooterRow.Cells[2].Text = tot_Demanded.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[3].Text = tot_Paid.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[4].Text = tot_Outstanding.ToString("N2");
                btnPaynow.Visible = true;
            }
            else
            {
                AllotteePaymentSummaruGrid.DataSource = null;
                AllotteePaymentSummaruGrid.DataBind();
                btnPaynow.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAllotteePaymentSummary();
        }

        protected void btnPaynow_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('https://epayments.in.worldline.com/UPSIDA','_blank');</script>");
        }
    }
}