using System;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PaymentAck : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo, TraID, ServiceID;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReqNo = Request.QueryString["ServiceReqNo"];
            TraID = Request.QueryString["TraID"];
            var arr = ServiceReqNo.Split('/');
            ServiceID = arr[1].ToString();
            Bind();
        }

        private void Bind()
        {
            if (ServiceID == "1001")
            {
                UC_LeaseDeedFeePayAck UC_LeaseDeedFeePayAck = LoadControl("~/UC_LeaseDeedFeePayAck.ascx") as UC_LeaseDeedFeePayAck;
                UC_LeaseDeedFeePayAck.ServiceRequestNo = ServiceReqNo;
                UC_LeaseDeedFeePayAck.TranID = TraID;
                PH.Controls.Add(UC_LeaseDeedFeePayAck);
            }
        }


    }


}