using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class TracingDocViewer : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string PlotID, DocType;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PlotID = Request.QueryString["PlotID"];
                DocType = Request.QueryString["DocType"];

                ViewDoc();
            }
            catch
            {


            }

        }


        private void ViewDoc()
        {

            DataSet ds = new DataSet();
            objServiceTimelinesBEL.PlotID = Convert.ToInt32(PlotID.Trim());
            objServiceTimelinesBEL.Doctype = DocType;

            ds = objServiceTimelinesBLL.GetTracingDocView(objServiceTimelinesBEL);

            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0][1].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""650px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                ltEmbed.Text = string.Format(embed, ResolveUrl("/TracingDocViewer.ashx?PlotID=" + PlotID.Trim() + "&DocType=" + DocType + ""));

            }



        }

    }
}






