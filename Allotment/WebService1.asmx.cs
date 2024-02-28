using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
namespace Allotment
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://eservices.onlineupsidc.com/WebService1")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection con;

        [WebMethod]
        public DataTable PlotDt(int ID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select * From PlotMaster where IAId=" + ID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table");
            adp.Fill(dt);
            return dt;



        }
    }
}
