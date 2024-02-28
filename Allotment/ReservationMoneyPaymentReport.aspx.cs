using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ReservationMoneyPaymentReport : System.Web.UI.Page
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



                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

                if (UserName == null)
                {
                    Response.Redirect("Default.aspx", false);
                }

                if (!IsPostBack)
                {
                    LAPL1();
                }

            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx", false);
            }

        }



        //        private void LAPL()
        //        {

        //            try
        //            {
        //                string html = "";
        //                SqlCommand cmmd = new SqlCommand("[sp_GetReservationMoneyPaymentReport] '" + UserName + "'", con);
        //                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
        //                DataTable dt = new DataTable();
        //                adp.Fill(dt);

        //                int j = 0;
        //                html = @"

        //<div  id='TableDiv'><table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>
        //<tr><th colspan=16  style='background-color: #4CAF50;text-align: center;font-size: 20px;color: #ffffff;'>Reservation Money Payment Report As On " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "</th></tr>" +
        //                            "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Regional Office </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> Industrial Area </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Allottee Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot Size</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Phone No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Reservation Money Amount</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Payment Initiation Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Bank Confirmation Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Service Ref No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Transaction Ref No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Accounts Confirmation</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Accounts Confirmation Date</th></tr>";
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    j++;
        //                    string RegionalOffice = dt.Rows[i][0].ToString();
        //                    string IndustrialArea = dt.Rows[i][1].ToString();
        //                    string AllotteeName = dt.Rows[i][2].ToString();
        //                    string PlotNo = dt.Rows[i][3].ToString();
        //                    string TotalAllottedplotArea = dt.Rows[i][4].ToString();
        //                    string EmailID = dt.Rows[i][5].ToString();
        //                    string PhoneNo = dt.Rows[i][6].ToString();
        //                    string ReservationAmount = dt.Rows[i][7].ToString();
        //                    string PaymentDate = dt.Rows[i][8].ToString();
        //                    string ServiceRefNo = dt.Rows[i][9].ToString();
        //                    string TraID = dt.Rows[i][10].ToString();
        //                    string EazypayRefNo = dt.Rows[i][11].ToString();
        //                    string Initiatedate = dt.Rows[i][12].ToString();
        //                    string AccStatus = dt.Rows[i][13].ToString();
        //                    string AccConDate = dt.Rows[i][14].ToString();

        //                    html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + j.ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RegionalOffice + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IndustrialArea + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AllotteeName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TotalAllottedplotArea + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PhoneNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ReservationAmount + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Initiatedate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PaymentDate + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ServiceRefNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + TraID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AccStatus + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + AccConDate + "</td></tr>";

        //                }

        //                html += "</table></div>";




        //                Literal loLit = new Literal();
        //                loLit.Text = (html);
        //                ph.Controls.Add(loLit);




        //            }
        //            catch (Exception ex)
        //            {
        //                Response.Write("Oops! error occured :" + ex.Message.ToString());
        //            }
        //        }

        private void LAPL1()
        {

            try
            {
                
                SqlCommand cmmd = new SqlCommand("[sp_GetReservationMoneyPaymentReport] '" + UserName + "'", con);
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