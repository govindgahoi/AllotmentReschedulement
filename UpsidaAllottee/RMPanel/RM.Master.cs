using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee.RMPanel
{
    public partial class RM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            try
            {
                
                if (!IsPostBack)
                {
                    lblname.Text = Convert.ToString(Session["UserName"]);
                    //if (lblname.Text == "")
                    //{
                    //    Response.Redirect("/Default.aspx");
                    //}
                    //else
                    //{
                    //    lblname.Text = Convert.ToString(Session["UserName"]);



                    //}
                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}