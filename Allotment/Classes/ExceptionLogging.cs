using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using context = System.Web.HttpContext;
namespace Allotment.Classes
{
    public class ExceptionLogging
    {

        private static String exepurl;
        static SqlConnection con;
        private static void connecttion()
        {
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            con = new SqlConnection(constr);
            con.Open();
        }
        public static void SendExcepToDB(Exception exdb)
        {
            try
            {
                connecttion();
                exepurl = context.Current.Request.Url.ToString();
                SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
                com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
                com.Parameters.AddWithValue("@ExceptionURL", exepurl);
                com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
                com.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
               
            }
        }
    }
}