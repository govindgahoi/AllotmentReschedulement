using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using System.Configuration;

namespace Allotment
{
    public partial class UC_Service_Document_CheckList_Details : System.Web.UI.UserControl
    {
        string service_num = "";
        public string SerReqID { get; set; }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                service_num = SerReqID;
                //if (!IsPostBack)
                //{
                //    if (Request.QueryString["service_num"] != null && Request.QueryString["service_num"] != string.Empty)
                //    {
                //        service_num = Request.QueryString["service_num"].ToString();
                //    }
                //    // lblName.Text = Request.QueryString["Name"];
                //}
                //service_num = Request.Cookies["service_num"].Value;
                bindgrid(service_num);
                lbllidaserviceid.Text = SerReqID;
                // bindnames(service_num);

            }

            catch (Exception ex)

            {
                throw ex;
            }

        }


        public void bindgrid(string service_num)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_lida_doc_checklist";
            cmd.Parameters.AddWithValue("@service_num", service_num);
            // cmd.Parameters.Add("@service_id", SqlDbType.Int).Value = txtID.Text.Trim();

            cmd.Connection = con;

            try

            {

                con.Open();

                grdview.EmptyDataText = "No Records Found";

                grdview.DataSource = cmd.ExecuteReader();

                grdview.DataBind();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

                con.Dispose();

            }

        }



        protected void imgview_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                string fileext = "";
                fileext = Path.GetExtension(filePath);
                string extfilepath = filePath.Substring(filePath.LastIndexOf("/") + 1);
                // string FileExtension = System.IO.Path.GetExtension(filePath);

                filePath = filePath.Replace('~', '/');
                Response.Redirect("http://eservices.onlineupsidc.com" + filePath);
                //Response.Redirect("<script>window.open('http://services.stagingupsida.com" + filePath + "','_blank');</script>");
                //  Response.Write("<script>window.open('http://eservices.onlineupsidc.com" + filePath + "','_blank');</script>");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void imgDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                filePath = filePath.Replace('~', '/');
                filePath = "http://eservices.onlineupsidc.com" + filePath;
                //Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(Server.MapPath(filePath));
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void grdImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview.PageIndex = e.NewPageIndex;
            bindgrid(service_num);
        }


        protected void getpathimg(string imgfile)

        {
            try
            {
                Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                // string pdfFilePath = Server.MapPath(".") + "/PDFFiles";
                //string pdfFilePath = Server.MapPath(".") + "/PDFFiles";
                string datetime = DateTime.Now.ToString("ddMMyyyyHHmmss");
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, Response.OutputStream);
                //    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath + "/" + datetime, FileMode.Create));

                doc.Open();

                try

                {

                    Paragraph paragraph = new Paragraph("");

                    //  string imageURL = Server.MapPath(".") + "/image2.jpg";

                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(".") + "/" + imgfile);

                    //Resize image depend upon your need
                    jpg.ScaleToFit(40f, 20f);
                    //jpg.ScaleToFit(140f, 120f);
                    jpg.SetAbsolutePosition(0, 0); // set the position to bottom left corner of pdf
                    jpg.ScaleAbsolute(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height); // set the height and width of image to PDF page size
                    //Give space before image

                    jpg.SpacingBefore = 5f;

                    //Give some space after the image

                    jpg.SpacingAfter = 5f;

                    jpg.Alignment = Element.ALIGN_JUSTIFIED_ALL;
                    // jpg.Alignment = Element.ALIGN_LEFT;



                    doc.Add(paragraph);

                    doc.Add(jpg);

                    pdfWriter.CloseStream = false;
                    doc.Close();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=D" + datetime + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(doc);
                    Response.End();

                }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

                { }

                finally

                {

                    doc.Close();

                }

            }
            catch (Exception ex)
            {
                Response.Write("Error:  " + ex.Message.ToString());
            }
        }
    }
}