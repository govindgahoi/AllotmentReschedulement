using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace Allotment
{
    /// <summary>
    /// Summary description for PlotService
    /// </summary>
    [WebService(Namespace = "http://eservices.onlineupsidc.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PlotService : System.Web.Services.WebService
    {
        SqlConnection con;


        [WebMethod]
        public DataTable PlotDetails(int IAID, String PlotNo)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetPlotDetailsForGISNew] " + IAID + ",'" + PlotNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable IADetails(int IAID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetIADetailsForGisNew " + IAID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetAllPlotIAWise(int IAID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetAllPlotIAWise " + IAID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetAllAllotteeDetails(int IAID, String PlotNo)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetAllotteedetails " + IAID + ",'" + PlotNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataTable GetAdvertisedPlotRMWise()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetAdvertised_Plot_RM_Wise]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetStateDetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetStateDetails]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetZoneDetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetZoneDetails]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetDistrictDetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetDistrictDetails]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetSectorDetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetSectorDetails]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable GetIndustrialAreaDetails()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[GetIndustrialAreaDetails]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;
        }
    }
}
