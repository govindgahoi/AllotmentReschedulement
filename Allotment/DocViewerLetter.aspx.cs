using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class DocViewerLetter : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string AllotteeID, DocumentID;
        int ServiceId, ServiceTimeLinesID;
        SqlConnection con;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                AllotteeID = Request.QueryString["Allottee"];
                DocumentID = Request.QueryString["DocID"];
                ViewDoc();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }

        }


        private void ViewDoc()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + AllotteeID + "'," + DocumentID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";
                //Response.Redirect("~/AllotmentAssessment.aspx?ServiceReqNo=" + ServiceReqNo + "&PacketId=" + PacketId + "");
                ltDocument.Text = string.Format(embed, ResolveUrl("/DocViewerLetter.ashx?AllotteeID=" + AllotteeID + "&DocID=" + DocumentID + ""));

            }



        }

    }
}






