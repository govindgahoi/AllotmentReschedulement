
using System.Web;
using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UpsidaAllottee;
using System.IO;

namespace UpsidaAllottee
{
    public class Viewer3 : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {

            string ComplaintID;
            ComplaintID = (context.Request.QueryString["ComplaintID"]);
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select Document, ContentType,AllotteeID,RMDoc,DocType from tbl_OTSDetail where ComplaintID ='" + ComplaintID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dtDoc = ds.Tables[0];
                if (dtDoc != null)
                {
                    Byte[] bytes = (Byte[])dtDoc.Rows[0]["RMDoc"];
                    
                    string filename = dtDoc.Rows[0]["AllotteeID"].ToString().Trim();

                    context.Response.Buffer = true;
                    context.Response.Charset = "";

                    if (context.Request.QueryString["download"] == "1")
                    {
                        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                    }

                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    context.Response.ContentType = dtDoc.Rows[0]["DocType"].ToString().Trim();
                    context.Response.BinaryWrite(bytes);
                    context.Response.Flush();
                    context.Response.End();
                }

            }
            catch (Exception ex)
            {

                context.Response.Write("<script type='text/javascript'>alert('Document not uploaded.');</script>");
            }

        }
        public bool IsReusable { get { return false; } }

    }
}