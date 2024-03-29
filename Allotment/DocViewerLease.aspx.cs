﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class DocViewerLease : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo, DocumentID, Type;
        int ServiceId, ServiceTimeLinesID;
        SqlConnection con;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                Type = Request.QueryString["Type"];
                ViewDoc();
            }
            catch
            {


            }

        }


        private void ViewDoc()
        {

            SqlCommand cmd = new SqlCommand("Select * from tbl_LeaseDeedApplicationStatusMaster where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {

                string contype = "";
                if (Type == "1")
                {
                    contype = dtDoc.Rows[0]["PlotTracingContent"].ToString().Trim();
                }
                else if (Type == "2")
                {
                    contype = dtDoc.Rows[0]["InspectionReportContent"].ToString().Trim();
                }

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                ltEmbed.Text = string.Format(embed, ResolveUrl("/DocViewerLease.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&Type=" + Type + ""));

            }



        }

    }
}






