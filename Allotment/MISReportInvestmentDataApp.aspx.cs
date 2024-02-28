using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidcApi
{
    public partial class MISReportInvestmentData : System.Web.UI.Page
    {

        SqlConnection con;
        string token = string.Empty;
        //  string ModeType = string.Empty;
        string RegionalOffice = string.Empty;
        string IndustrialArea = string.Empty;
        string ReportType = string.Empty;
        string ServiceName = string.Empty;
        string FromDate = string.Empty;
        string ToDate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            token = Request.QueryString["token"];
            RegionalOffice = Request.QueryString["RegionalOffice"];
            IndustrialArea = Request.QueryString["IndustrialArea"];
            ReportType = Request.QueryString["ReportType"];
            ServiceName = Request.QueryString["ServiceName"];
            FromDate = Request.QueryString["FromDate"];
            ToDate = Request.QueryString["ToDate"];
            if (token != string.Empty && RegionalOffice != string.Empty && ServiceName != string.Empty && IndustrialArea != string.Empty)
            {

                bindgridwithdb();

                //if (ReportType == "1")
                //{

                //}
                //else if (ModeType == "2")
                //{

                //}
                //else if (ModeType == "3")
                //{

                //}

            }

        }
        public void bindgridwithdb()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "GetListOfInvestmentAllotteeWise";

            cmd.Parameters.Add("@RegionalOffice", SqlDbType.VarChar).Value = RegionalOffice;
            cmd.Parameters.Add("@IndustrialArea", SqlDbType.VarChar).Value = IndustrialArea;
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar).Value = ReportType;
            cmd.Parameters.Add("@Service", SqlDbType.VarChar).Value = ServiceName;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;


            cmd.Connection = con;

            try
            {

                con.Open();

                AllGrid.EmptyDataText = "No Records Found";

                AllGrid.DataSource = cmd.ExecuteReader();

                AllGrid.DataBind();

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