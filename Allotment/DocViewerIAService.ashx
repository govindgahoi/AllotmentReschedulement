﻿<%@ WebHandler Language="C#"  Class="Viewer" %>

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
        string ServiceID = (context.Request.QueryString["ServiceID"]);
        string DocType = (context.Request.QueryString["DocType"]);


        SqlCommand cmd = new SqlCommand("Select * from [Repository] where ServiceRequestNo='" + ServiceRequestNO + "' and ServiceID='"+ServiceID+"' and DocType='"+DocType+"'", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dtDoc = new DataTable();
        adp.Fill(dtDoc);

        if (dtDoc.Rows.Count > 0)
        {

            if (dtDoc.Rows[0]["Document"].ToString().Length > 0)
            {
                byte[] Document = (byte[])dtDoc.Rows[0]["SignedDocument"];
                string filename = dtDoc.Rows[0]["DocType"].ToString();

                context.Response.Buffer = true;
                context.Response.Charset = "";

                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                }

                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = dtDoc.Rows[0]["SignedDocumentContent"].ToString().Trim();
                context.Response.BinaryWrite(Document);
                context.Response.Flush();
                context.Response.End();

            }
        }
    }


    public bool IsReusable { get { return false; } }

}