<%@ WebHandler Language="C#"  Class="ViewerUploadMap" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using BEL_Allotment;
using BLL_Allotment;


public class ViewerUploadMap : IHttpHandler
{

    belBookDetails objServiceTimelinesBEL = new belBookDetails();
    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

    public void ProcessRequest(HttpContext context)
    {
        string ID = (context.Request.QueryString["ID"]);
       
        DataSet ds = new DataSet();
        objServiceTimelinesBEL.ID = Convert.ToInt32(ID);
        ds = objServiceTimelinesBLL.GetgridLetterUpload(objServiceTimelinesBEL);

        DataTable dtDoc = ds.Tables[0];
        if (dtDoc != null)
        {
            Byte[] bytes    = (Byte[])dtDoc.Rows[0]["SignedMap"];
            string filename = dtDoc.Rows[0]["DocName"].ToString().Trim();

            context.Response.Buffer = true;
            context.Response.Charset = "";

            if (context.Request.QueryString["download"] == "1")
            {
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            }

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = dtDoc.Rows[0]["SignedMapContent"].ToString().Trim();
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }

    }


    public bool IsReusable { get { return false; } }

}