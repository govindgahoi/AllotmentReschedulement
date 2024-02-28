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

    public void ProcessRequest(HttpContext context)
    {
        string NoticeID = (context.Request.QueryString["NoticeID"]);
       
        DataSet ds = new DataSet();
        objServiceTimelinesBEL.NoticeID = NoticeID;
        ds = objServiceTimelinesBLL.GetNoticesServedDoc(objServiceTimelinesBEL);

        DataTable dtDoc = ds.Tables[0];
        if (dtDoc != null)
        {
            Byte[] bytes    = (Byte[])dtDoc.Rows[0]["NoticeContent"];
            string filename = dtDoc.Rows[0]["NoticeName"].ToString().Trim();

            context.Response.Buffer = true;
            context.Response.Charset = "";

            if (context.Request.QueryString["download"] == "1")
            {
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            }

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = dtDoc.Rows[0]["NoticeExtn"].ToString().Trim();
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }

    }


    public bool IsReusable { get { return false; } }

}