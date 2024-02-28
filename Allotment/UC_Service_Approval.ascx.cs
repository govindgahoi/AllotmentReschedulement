using System;

namespace Allotment
{
    public partial class UC_Service_Approval : System.Web.UI.UserControl
    {

        public string SerReqID { get; set; }
        public string SerReq_C_Tab { get; set; }
        public string SerReq_C_SubTab { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            lblServiceID.Text = SerReqID;
        }
    }
}