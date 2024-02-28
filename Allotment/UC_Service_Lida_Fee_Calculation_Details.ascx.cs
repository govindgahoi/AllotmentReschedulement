using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class UC_Service_Lida_Fee_Calculation_Details : System.Web.UI.UserControl
    {
        string service_num = "";
        public string ServiceRequestNo { get; set; }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //if (!IsPostBack)
                //{
                //    if (Request.QueryString["service_num"] != null && Request.QueryString["service_num"] != string.Empty)
                //    {
                //        service_num = Request.QueryString["service_num"].ToString();
                //    }
                //    // lblName.Text = Request.QueryString["Name"];
                //    service_num = Request.Cookies["service_num"].Value;

                //}

                paymentinfo(ServiceRequestNo);
                bindfeecalculation(ServiceRequestNo);
                bindfeecalculation1(ServiceRequestNo);
            }
            catch (Exception ex)
            {

            }

        }
        public void paymentinfo(string service_num)
        {
           // SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_LIDA_ApplicantTransactionDetails";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            con.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblapprefno.Text = dr["ServiceNo"].ToString();

                //     .Text =dr["clnt_txn_ref"].ToString();
                //.Text = dr["rqst_amnt"].ToString();

                lbldt.Text = DateTime.Parse(dr["TransactioncreateDate"].ToString()).ToString("dd-MM-yyyy");
                // lblnameof.Text = dr["cust_name"].ToString();
                //.Text = dr["cust_mobno"].ToString();
                //.Text = dr["customer_unique_id"].ToString();
                //.Text = dr["checksum"].ToString();
                //string mercode = dr["merchantcode"].ToString();
                lblpaystatus.Text = dr["GatewayResponse"].ToString();
                // .Text = dr["desc_error"].ToString();
                lbltxnrefno.Text = dr["EazypayRefNo"].ToString();
                string bankcode = dr["PayMode"].ToString();

                string paidamt = dr["TotalAmount"].ToString();
                lbltxndt.Text = dr["TransactionDate"].ToString();
            }
            con.Close();
        }



        public void bindfeecalculation(string service_num)
        {
            //ReInspectionFee
            //SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Lida_FeeCalculationDetails";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            con.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblpermitfee.Text = dr["ReInspectionFee"].ToString();

                lblpermitfeefortemp.Text = dr["PermissiveFee"].ToString();
                lbllabourfree.Text = dr["LabourAccomatdationFee"].ToString();


                lblfeeoncoveredarea.Text = dr["InspectionFee"].ToString();

            }
            con.Close();

        }

        public void bindfeecalculation1(string service_num)
        {
            //ReInspectionFee
            //SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Lida_FeeCalculationDetails1";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            con.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblplotarea.Text = dr["TotalArea"].ToString();

                lblcoveredarea.Text = dr["CoveredArea"].ToString();
                lbltotalfee.Text = dr["TotalFeeWithoutGST"].ToString();


                lblgstwithfee.Text = dr["TotalFeeWithGST"].ToString();

            }
            con.Close();
        }
    }
}
