using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class DocViewer : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo, DocumentID;
        int ServiceId, ServiceTimeLinesID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                ServiceId = Convert.ToInt32(Request.QueryString["ServiceId"]);
                ServiceTimeLinesID = Convert.ToInt32(Request.QueryString["ServiceTimeLinesID"]);
                DocumentID = Request.QueryString["DocumentID"];
                ViewDoc();
            }
            catch
            {


            }

        }


        private void ViewDoc()
        {

            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            objServiceTimelinesBEL.ServiceCheckListsID = ServiceId;
            objServiceTimelinesBEL.ServiceTimeLinesID = ServiceTimeLinesID;

            objServiceTimelinesBEL.DocumentID = DocumentID;

            ds = objServiceTimelinesBLL.GetTempCheckListDocument(objServiceTimelinesBEL);

            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                ltEmbed.Text = string.Format(embed, ResolveUrl("/TempDocViewer.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&ServiceCheckListsID=" + ServiceId + "&ServiceTimeLinesID=" + ServiceTimeLinesID + "&DocId=" + DocumentID + ""));

            }



        }

    }
}






