using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Allotment
{
    public class connectionstring
    {
        public connectionstring()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        SqlConnection g_sqcn = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        //  SqlConnection g_sqcn = new SqlConnection(@"Data Source=DESKTOP-V98NCKJ;Initial Catalog=HkantiLalJain;Integrated Security=True;MultipleActiveResultSets=true;");
        public int g_dml_query(string g_sql)
        {

            SqlCommand g_cm = new SqlCommand();
            g_cm.Connection = g_sqcn;
            g_cm.CommandType = CommandType.Text;
            g_cm.CommandText = g_sql;
            int g_a = 0;
            if (g_sqcn.State == ConnectionState.Open)
            {
                g_sqcn.Close();
            }
            g_sqcn.Open();
            g_a = g_cm.ExecuteNonQuery();
            g_sqcn.Close();
            return g_a;
        }
        public DataTable g_fetch_data(string g_sql)
        {
            SqlDataAdapter g_da = new SqlDataAdapter(g_sql, g_sqcn);
            DataSet g_ds = new DataSet();
            g_da.Fill(g_ds);
            DataTable g_dt = g_ds.Tables[0];
            return g_dt;
        }
        public DataSet g_grid_data(string g_sql)
        {
            SqlDataAdapter g_da = new SqlDataAdapter(g_sql, g_sqcn);
            DataSet g_ds = new DataSet();
            g_da.Fill(g_ds, "a");
            return g_ds;
        }
    }

}