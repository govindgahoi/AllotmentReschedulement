using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{
    public partial class CheckListViewer : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        int ServiceCheckListsID ;
        int ServiceTimeLinesID ;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
                try
                {
                    ServiceCheckListsID = int.Parse(Request.QueryString["ServiceCheckListsID"]);
                    ServiceTimeLinesID = int.Parse(Request.QueryString["ServiceTimeLinesID"]);
                }
                catch { }
                ViewDoc();
            }
            catch
            {


            }

        }


        private void ViewDoc()
        {

            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceCheckListsID = ServiceCheckListsID;
            objServiceTimelinesBEL.ServiceTimeLinesID = ServiceTimeLinesID;
            ds = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];
            if (dtDoc.Rows.Count > 0)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                ltEmbed.Text = string.Format(embed, ResolveUrl("/ViewerCheckList.ashx?ServiceCheckListsID=" + ServiceCheckListsID + "&ServiceTimeLinesID=" + ServiceTimeLinesID + ""));
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
            }
        }

    }
}






