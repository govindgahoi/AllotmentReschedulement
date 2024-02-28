using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class OTSMLaunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void launch_click(object sender, EventArgs e)
        {
            //string za = "123";
            launch.Visible = false;
            //lbllauchedmsg.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal1('" + za + "');", true);
            Response.Redirect("http://localhost:49691/OTSMLaunch.aspx");
            //ots.Visible = true;

        }

    }
}