using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class RelevantOrderViewer : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string IAID;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IAID = Request.QueryString["ID"];

                ViewDoc();
            }
            catch
            {


            }

        }


        private void ViewDoc()
        {

            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ID = Convert.ToInt32(IAID.Trim());
            ds = objServiceTimelinesBLL.GetReleventDocView(objServiceTimelinesBEL);

            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0][1].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                ltEmbed.Text = string.Format(embed, ResolveUrl("/RelevantOrderViewer.ashx?ID=" + ID.Trim()));

            }

        }

    }
}






