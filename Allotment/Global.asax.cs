using System;
using System.Web;
using WebCAD;


namespace Allotment
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            DrawingManager.Engine = DrawingEngine.CADNET;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Response.Redirect("~/Default.aspx");


        }

        protected void Application_BeginRequest(object sender, EventArgs e)

        {
            HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //ErrorHandler.ReportError(ex); //Notifies technical team about the error
            //Server.ClearError();
            //Response.Redirect(string.Format
            //  ("Error.aspx?aspxerrorpath={0}", Request.Url.PathAndQuery));
        }





        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}