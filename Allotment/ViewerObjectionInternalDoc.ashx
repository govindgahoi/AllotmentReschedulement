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
        string ID = (context.Request.QueryString["ID"]);
        string Type = (context.Request.QueryString["Type"]);


        SqlCommand cmd = new SqlCommand("Select * from ApplicationObjectionLookUp where ID='"+ID+"'", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dtDoc = new DataTable();
        adp.Fill(dtDoc);

        if (dtDoc.Rows.Count > 0)
        {

            if (dtDoc.Rows[0]["InternalObjDoc"].ToString().Length > 0)
            {
                Byte[] bytes = (Byte[])dtDoc.Rows[0]["InternalObjDoc"];
                string filename = dtDoc.Rows[0]["InternalObjDocName"].ToString();

                context.Response.Buffer = true;
                context.Response.Charset = "";

                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                }

                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = dtDoc.Rows[0]["InternalObjDocContent"].ToString().Trim();
                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
                context.Response.End();

            }
        }
    }


    public bool IsReusable { get { return false; } }

}