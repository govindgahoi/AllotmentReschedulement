using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class UC_Lida_Service_Applicant_details1 : System.Web.UI.UserControl
    {
        string service_num = "";
        public string ServiceReqNo { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    //if (Request.QueryString["service_num"] != null && Request.QueryString["service_num"] != string.Empty)
                    //{
                    //    service_num = Request.QueryString["service_num"].ToString();
                    //}
                    //// lblName.Text = Request.QueryString["Name"];

                    //service_num = Request.Cookies["service_num"].Value;

                    //get_application_status();
                    //if (process_result_data != true)
                    //{
                    //    Response.Redirect("LidaIndex.aspx");
                    //}
                }
                service_num = ServiceReqNo;
                displaydata(service_num);
                bindnames(service_num);

            }

            catch (Exception ex)

            {

            }

        }

        string changearchiemail = string.Empty;
        public void bindnames(string service_num)
        {
            string sConstr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection Conn = new SqlConnection(sConstr);
            using (Conn)
            {
                SqlCommand command = new SqlCommand("sp_get_Lida_allotee_names", Conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                command.CommandType = CommandType.StoredProcedure; Conn.Open();
                command.Parameters.AddWithValue("@service_num", service_num);
                da.SelectCommand = command;
                da.Fill(dt);
                lstboxapplicants.DataSource = dt;
                StringBuilder sb = new StringBuilder();

                //for (int i = 0; i < sb.Length; i++)
                //    Console.Write(sb[i]);
                foreach (DataRow row in dt.Rows)
                {
                    lblemail.Text = row["allottee_email"].ToString();
                    changearchiemail = row["allottee_email"].ToString();
                    lblapplicantmob.Text = row["allotee_mobno"].ToString();
                    sb.Append(row["allottee_name"].ToString() + "  ,");
                    //  string icoFileName = row["iconFile"].ToString();
                    //  string installScript = row["installScript"].ToString();
                }
                lblapplicants.Text = sb.ToString();
                // lstboxapplicants.DataValueField = "ArticleID";
                lstboxapplicants.DataTextField = "allottee_name";
                lstboxapplicants.DataBind();
                Response.Cookies["ForChangeofarchiEmail"].Value = changearchiemail;
            }
        }
        string complex_type = string.Empty;

        public void displaydata(string service_num)
        {
            SqlConnection ConnectionName = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConnectionName;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_get_lida_allotee_details";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            ConnectionName.Open();

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
            lbldevelopername.Text = dr["developer_name"].ToString();
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

            complex_type = dr["complex_selection_type"].ToString();
            Khasra_gataData();
            //if (dr.HasRows == true)
            //{
            //    dr.Read();
            //   // Label1.Text = dr["DataField"].ToString();
            //   lbllidaserviceid.Text= dr["lida_allotee_id"].ToString();

            //    dr.Close();
            //}
        }





        public void Khasra_gataData()
        {
            try
            {
                if (complex_type == "No")
                {
                    pnlploatdata.Visible = false;
                    // 
                    String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

                    SqlConnection con = new SqlConnection(strConnString);

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "sp_Lida_getallotee_Khasra_gataDetails";
                    cmd.Parameters.AddWithValue("@service_num", service_num);

                    cmd.Connection = con;

                    try

                    {

                        con.Open();

                        grdview.EmptyDataText = "No Records Found";

                        grdview.DataSource = cmd.ExecuteReader();

                        grdview.DataBind();
                        grdview.AutoGenerateColumns = false;
                    }

                    catch (Exception ex)

                    {

                        throw ex;

                    }

                    finally

                    {

                        con.Close();

                        con.Dispose();

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



















        bool process_result_data;
        public void get_application_status()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_Lida_ApplicationProcessHistoryCheck";
            cmd.Parameters.AddWithValue("@service_num", service_num);
            // cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtID.Text.Trim();

            cmd.Connection = con;

            try

            {

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        process_result_data = Convert.ToBoolean(dr["ApplicationRegisterStatus"].ToString());
                        //Label1.Text = dr["FirstName"].ToString();
                        //Label2.Text = dr["LastName"].ToString();
                        //Label3.Text = dr[3].ToString();
                        //Label4.Text = dr["Email"].ToString();
                    }
                }
                // GridView1.EmptyDataText = "No Records Found";

                // GridView1.DataSource = cmd.ExecuteReader();

                //  GridView1.DataBind();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

                con.Dispose();

            }
        }

    }
}
