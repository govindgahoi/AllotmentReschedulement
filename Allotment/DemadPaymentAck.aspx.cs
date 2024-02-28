using System;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class DemadPaymentAck : System.Web.UI.Page
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
            UC_DemandPayAck UC_DemandPayAck = LoadControl("~/UC_DemandPayAck.ascx") as UC_DemandPayAck;


            UC_DemandPayAck.ServiceRequestNo = ServiceReqNo;
            UC_DemandPayAck.TranID = TraID;

            PH.Controls.Add(UC_DemandPayAck);
        }


    }


}