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
    public partial class UC_Service_Building_Plan_Specifications_details : System.Web.UI.UserControl
    {
        string service_num = "";
        public string SerReqID { get; set; }
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
                service_num = SerReqID;
                buldingplaninfo(service_num);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void buldingplaninfo(string service_num)
        {
           // SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Lida_Building_plan_details";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            con.Open();

            dr = comm.ExecuteReader();

            dr.Read();

            lblactivitytype.Text = dr["ActivityType"].ToString();
            lblFAR.Text = dr["FAR"].ToString();
            lblGroundCoverage.Text = dr["GroundCoverage"].ToString();
            lblTotalCoverageArea.Text = dr["TotalCoveredArea"].ToString();
            lblHeight.Text = dr["Height"].ToString();
            lblsetback.Text = dr["SetBack"].ToString();
            lblfont.Text = dr["Front"].ToString();
            lblRear.Text = dr["Rear"].ToString();
            lblSide1.Text = dr["Side1"].ToString();
            lblSide2.Text = dr["Side2"].ToString();

            con.Close();

        }
    }
}