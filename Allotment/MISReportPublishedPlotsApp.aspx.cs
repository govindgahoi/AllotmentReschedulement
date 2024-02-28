using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidcApi
{
    public partial class MISReportPublishedPlots : System.Web.UI.Page
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
            if (token != string.Empty && RegionalOffice != string.Empty && ServiceName != string.Empty && IndustrialArea != string.Empty )
            {
                try
                {
                    bindgridwithdb();
                }
                catch(Exception ex)
                {

                }

            }


        }





        public void bindgridwithdb()

        {
            try
            {
                DataSet ds = new DataSet();
                String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

                SqlConnection con = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetListOfPublishedPlots";

                cmd.Parameters.Add("@RegionalOffice", SqlDbType.VarChar).Value = RegionalOffice;
                cmd.Parameters.Add("@IndustrialArea", SqlDbType.VarChar).Value = IndustrialArea;
                cmd.Parameters.Add("@ReportType", SqlDbType.VarChar).Value = ReportType;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;


                cmd.Connection = con;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt1 = ds.Tables[1];
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
                    if (dt1.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }





        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            AllGrid.PageIndex = e.NewPageIndex;
            this.bindgridwithdb();
        }




    }



    
    //con.Open();

    //AllGrid.EmptyDataText = "No Records Found";

    //AllGrid.DataSource = cmd.ExecuteReader();

    //AllGrid.DataBind();

}
    
