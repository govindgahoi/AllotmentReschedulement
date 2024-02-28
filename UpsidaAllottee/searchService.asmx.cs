using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

namespace UpsidaAllottee
{
    /// <summary>
    /// Summary description for searchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class searchService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetAutoCompleteData(string txtSearch, string IAName)
        {
            //string alpha = "Incorrect response";
            
                List<string> result = new List<string>();
                
                    //string IndustrialArea = DlIA.SelectedValue;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("usp_getPlotNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@IAName", IAName);
                    cmd.Parameters.AddWithValue("@PlotNo", txtSearch);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["PlotNo"].ToString().Trim());
                    }
               
                return result;
        }

        [WebMethod]
        public List<string> GetAutoCompletePlot(string txtSearch1, string IAName)
        {
             List<string> result = new List<string>();
                //string IndustrialArea = DlIA.SelectedValue;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_getPlotNo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@IAName", IAName);
                cmd.Parameters.AddWithValue("@PlotNo", txtSearch1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["PlotNo"].ToString().Trim());
                }
                return result;
          
        }
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> UserDetail(string UserName)
        {
            List<string> result = new List<string>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select Level from UserAssociationMaster where UserID=(Select A.userId  from UPSIDCUser A LEFT JOIN[dbo].[EmpDesignation] B ON A.[DesignationID] = B.[DesignationID] where UserName ='" + UserName + "') and isNull(ActiveStatus,0)=1", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(dr["Level"].ToString().Trim());
            }
            return result;

        }

    }
}
