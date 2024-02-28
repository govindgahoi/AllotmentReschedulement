using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Allotment
{
    public partial class UC_Lida_Service_Applicant_details : System.Web.UI.UserControl
    {
        SqlConnection con;
        string service_num = "";
        //public string AllotteeId { get; set; }
        public string ServiceReqNo { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                service_num = ServiceReqNo;
                if (!IsPostBack)
                {
                    //if (Request.QueryString["service_num"] != null && Request.QueryString["service_num"] != string.Empty)
                    //{
                    //    service_num = Request.QueryString["service_num"].ToString();
                    //}
                    // lblName.Text = Request.QueryString["Name"];

                    //service_num = Request.Cookies["service_num"].Value;

                    

                }
                service_num = ServiceReqNo;
                displaydata(service_num);
                bindnames(service_num);

            }
            catch (Exception ex)
            {

            }

        }


        public void bindnames(string service_num)
        {
            //string sConstr = @"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;";
            //SqlConnection Conn = new SqlConnection(con);
            using (con)
            {
                SqlCommand command = new SqlCommand("sp_get_Lida_allotee_names", con);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                command.CommandType = CommandType.StoredProcedure; con.Open();
                command.Parameters.AddWithValue("@service_num", service_num);
                da.SelectCommand = command;
                da.Fill(dt);
                lstboxapplicants.DataSource = dt;
                // lstboxapplicants.DataValueField = "ArticleID";
                lstboxapplicants.DataTextField = "allottee_name";
                lstboxapplicants.DataBind();
            }
        }
        public void displaydata(string service_num)
        {
            //SqlConnection ConnectionName = new SqlConnection(@"Data Source=103.145.50.232,1433; Network Library=DBMSSOCN;Initial Catalog=BookDb2; User ID=sa;Password=$*su^!18#22!K@1;");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_get_lida_allotee_details";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            con.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            lbllidaserviceid.Text = dr["lida_allotee_id"].ToString();
            lblalloteeid.Text = dr["id"].ToString();
            //   dr["cust_id"].ToString();
            lblservicetype.Text = dr["service_type"].ToString();
            lblcomplextype.Text = dr["complex_type"].ToString();
            //lblcomplextype =  dr["appoved_complex_type"].ToString();
            lblsubcomplextype.Text = dr["appoved_complex_subtype"].ToString();
            lblfacilityname.Text = dr["facility_remark"].ToString();
            lblprojectname.Text = dr["project_name"].ToString();
            lbllandusetype.Text = dr["land_type"].ToString();
            lblactivityonsale.Text = dr["activity_sale_deed"].ToString();
            lblactivityoncomplete.Text = dr["activity_complete_layout"].ToString();
            lblblockno.Text = dr["block_no"].ToString();
            lblplotno.Text = dr["plot_no"].ToString();
            lblarealayout.Text = dr["layout_area"].ToString();
            lblareasaledeed.Text = dr["area_onsale_deed"].ToString();
            lblapplieddt.Text = dr["created_date"].ToString();
            //=  dr["created_by"].ToString();
            //=  dr["modified_date"].ToString();
            lblcompnum.Text = dr["completion_no"].ToString();
            lblcompdate.Text = dr["completion_date"].ToString();
            //=  dr["applying_behalf"].ToString();
            lblauthorizedpersonname.Text = dr["authorize_person_name"].ToString();
            lblownername.Text = dr["authorize_owner_name"].ToString();
            lblauthoriedletter.Text = dr["authorization_doc"].ToString();
            authoriedletter.HRef = dr["authorization_doc"].ToString();

            //=  dr["complex_selection_type"].ToString();

            //if (dr.HasRows == true)
            //{
            //    dr.Read();
            //   // Label1.Text = dr["DataField"].ToString();
            //   lbllidaserviceid.Text= dr["lida_allotee_id"].ToString();

            //    dr.Close();
            //}
        }

    }
}