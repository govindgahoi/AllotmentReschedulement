using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace UpsidcApi
{
    public partial class ReservationMoneyPaymentReport : System.Web.UI.Page
    {

        SqlConnection con;
        string token = string.Empty;
        string ModeType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                token = Request.QueryString["token"];
                ModeType = Request.QueryString["ModeType"];
                if (token != string.Empty && ModeType != string.Empty)
                {
                    if (ModeType == "1")
                    {
                        LAPL1();
                    }

                }

            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx", false);
            }

        }
        private void LAPL1()
        {
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


                SqlCommand cmmd = new SqlCommand("[sp_GetReservationMoneyPaymentReport] '" + "Admin1" + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    AllGrid.DataSource = dt;
                    AllGrid.DataBind();
                }
                else
                {
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
           // GridView1.PageIndex = e.NewPageIndex;
            AllGrid.PageIndex = e.NewPageIndex;
            this.LAPL1();
        }


        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)

        {

            if (e.Row.RowType == DataControlRowType.Header)
            {

                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();

                HeaderCell2.Text = "Personal Details";

                HeaderCell2.ColumnSpan = 11;

                HeaderRow.Cells.Add(HeaderCell2);

                AllGrid.Controls[0].Controls.AddAt(0, HeaderRow);

            }
        }
    }
}