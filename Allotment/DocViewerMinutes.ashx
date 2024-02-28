<%@ WebHandler Language="C#"  Class="Viewer" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using BEL_Allotment;
using BLL_Allotment;


public class Viewer : IHttpHandler
{

    belBookDetails objServiceTimelinesBEL = new belBookDetails();
    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

    public void ProcessRequest(HttpContext context)
    {
        string ServiceRequestNO = (context.Request.QueryString["ServiceRequestNO"]);


        SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNO='" + ServiceRequestNO + "'", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dtDoc = new DataTable();
        adp.Fill(dtDoc);

        if (dtDoc.Rows.Count > 0)
        {
            if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
            {
                Byte[] bytes = (Byte[])dtDoc.Rows[0]["Documents"];
                string filename = dtDoc.Rows[0]["DocName"].ToString().Trim();

                context.Response.Buffer = true;
                context.Response.Charset = "";

                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                }

                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = dtDoc.Rows[0]["contentType"].ToString().Trim();
                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
                context.Response.End();
            }
        }
    }


    public bool IsReusable { get { return false; } }

}