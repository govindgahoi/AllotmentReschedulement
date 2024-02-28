using System;
//using System.Web.UI.Page;


namespace Allotment
{

    public class BasePage : System.Web.UI.Page
    {

        public BasePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected override void OnError(EventArgs e)
        {
            //Report Error
            Exception ex = Server.GetLastError();
            //ErrorHandler.ReportError(ex);
            Server.ClearError();
            Response.Redirect(string.Format
            ("Error.aspx?aspxerrorpath={0}", Request.Url.PathAndQuery));
        }
    }
}