using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment.AllotteePanel
{
    public partial class AllotteeServiceTrack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowPopup(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }
    }
}