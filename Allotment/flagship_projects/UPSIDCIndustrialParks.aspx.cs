using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace Allotment
{
    public partial class UPSIDCIndustrialParks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();


        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);



            SqlCommand cmd2 = new SqlCommand("SELECT [id] 'Sr. No',[IANAME]  'Name of Industrial Area',[TotalLandAcquired ]  'Total Land for Acquired' ,  " +
                                             " [TotalLand] 'Total Land for Allotment',[AllotedLand] 'Alloted Land', " +
                                             " [BalanceLand] 'Balance Land available for Allotment', [Rate] 'Rate (Rs. Per sq.mtr.)' " +
                                             " FROM [dbo].[IAPlotPosition]", con);
            //,[PerLandAllotted],[TotalRevnue]
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd2); DataTable dt11 = new DataTable(); adp1.Fill(dt11);
            Allottee_master_grid.DataSource = dt11; Allottee_master_grid.DataBind();


        }
    }
}