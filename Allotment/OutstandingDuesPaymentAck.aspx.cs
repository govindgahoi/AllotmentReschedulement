using System;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class OutstandingDuesPaymentAck : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo, TraID;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReqNo = Request.QueryString["ServiceReqNo"];
            TraID = Request.QueryString["TraID"];
            Bind();
        }

        private void Bind()
        {
            UC_OutstandingDuesPayAck UC_OutstandingDuesPayAck = LoadControl("~/UC_OutstandingDuesPayAck.ascx") as UC_OutstandingDuesPayAck;
            UC_OutstandingDuesPayAck.ServiceRequestNo = ServiceReqNo;
            UC_OutstandingDuesPayAck.TranID = TraID;
            PH.Controls.Add(UC_OutstandingDuesPayAck);
        }


    }


}