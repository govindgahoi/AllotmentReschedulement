using System;
using System.Web.UI;
using Allotment.Classes;
namespace Allotment
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Error occurred";
                string PreviousUri = Request["aspxerrorpath"];
                if (!string.IsNullOrEmpty(PreviousUri))
                {
                    pnlError.Visible = true;
                    hlinkPreviousPage.NavigateUrl = PreviousUri;
                }
            }
            catch (Exception es)
            {
                ExceptionLogging.SendExcepToDB(es);
                Response.Redirect("error.html");
            }
        }
    }
}