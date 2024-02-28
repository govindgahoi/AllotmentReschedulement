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
        string IAID = (context.Request.QueryString["ID"]);
        //string DocType = (context.Request.QueryString["DocType"]);

          DataSet ds = new DataSet();
          objServiceTimelinesBEL.ID = Convert.ToInt32(IAID.Trim());

        ds = objServiceTimelinesBLL.GetReleventDocView(objServiceTimelinesBEL);
        DataTable dtDoc = ds.Tables[0];
        if (dtDoc != null)
        {
            Byte[] bytes = (Byte[])dtDoc.Rows[0][2];
            string filename = dtDoc.Rows[0][0].ToString().Trim();

            context.Response.Buffer = true;
            context.Response.Charset = "";

            if (context.Request.QueryString["download"] == "1")
            {
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            }

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = dtDoc.Rows[0][1].ToString().Trim();
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }

    }


    public bool IsReusable { get { return false; } }

}