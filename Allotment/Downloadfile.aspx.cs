using System;

namespace Allotment
{
    public partial class Downloadfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!this.IsPostBack)
                {
                    string fileName = Request.QueryString["pdffile"];
                    string path = Server.MapPath("~//Image//") + fileName;
                    Response.ContentType = "application/pdf";
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                    Response.TransmitFile(path);
                    Response.Flush();
                    //Response.End();
                }
            }

        }
    }
}