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
    public partial class UC_Service_Architect_Details : System.Web.UI.UserControl
    {
        string service_num = "";
        public string SerReqID { get; set; }
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

                architect_info(SerReqID);
                // bindnames(service_num);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void architect_info(string service_num)
        {
            SqlConnection ConnectionName = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConnectionName;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_get_Lida_architect_details";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            ConnectionName.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            lblarchitechname.Text = dr["archi_name"].ToString();
            lblarchitectcoa.Text = dr["archi_coa"].ToString();
            lblarchiaddress.Text = dr["archi_address"].ToString();
            lblArchitecheMobile.Text = dr["archi_mobile"].ToString();
            lblArchitechemail.Text = dr["archi_email"].ToString();
            lblStructuralEngineername.Text = dr["struct_name"].ToString();
            lblStructuralEngineerLicensedNo.Text = dr["struct_license_no"].ToString();
            lblStructuralEngineerRegistratinNo.Text = dr["struct_registration_no"].ToString();
            lblStructuralEngineerAddress.Text = dr["struct_engineer_address"].ToString();
            lblstructuralemail.Text = dr["struct_email"].ToString();
            lblstructurlmobile.Text = dr["struct_mob"].ToString();
            lbltownplannerEngineer.Text = dr["plannner_name"].ToString();
            lbltownplannerLicensedNo.Text = dr["planner_coa"].ToString();
            lbltownplannerAddress.Text = dr["planner_address"].ToString();
            lblplannermob.Text = dr["planner_mob"].ToString();
            lblplanneremail.Text = dr["planner_email"].ToString();
            string id = dr["lida_allotee_id"].ToString();

        }
    }
}