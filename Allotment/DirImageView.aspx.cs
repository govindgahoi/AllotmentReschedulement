using System;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class DirImageView : System.Web.UI.Page
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

            }
            catch (Exception ex)
            {


            }

        }



    }
}






