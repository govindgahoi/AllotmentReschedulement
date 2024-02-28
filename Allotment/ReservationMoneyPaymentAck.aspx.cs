using System;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ReservationMoneyPaymentAck : System.Web.UI.Page
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
            UC_ReservationMoneyPayAck UC_ReservationMoneyPayAck = LoadControl("~/UC_ReservationMoneyPayAck.ascx") as UC_ReservationMoneyPayAck;


            UC_ReservationMoneyPayAck.ServiceRequestNo = ServiceReqNo;
            UC_ReservationMoneyPayAck.TranID = TraID;

            PH.Controls.Add(UC_ReservationMoneyPayAck);
        }


    }


}