using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;

namespace Allotment
{
    public partial class UC_NoticeDetails : System.Web.UI.UserControl
    {
        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        public string ServiceReqNo { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            Get_ApplicantNoticeReply_of_service();
        }


        public void Get_ApplicantNoticeReply_of_service()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            DataSet dsR = new DataSet();
            try
            {
              
                dsR = objServiceTimelinesBLL.PlotCancelationApplicantDetails(objServiceTimelinesBEL);
                DataTable dt_PriviousNotice = dsR.Tables[0];
                if (dt_PriviousNotice.Rows.Count > 0)
                {
                    gvNotice.DataSource = dt_PriviousNotice;
                    gvNotice.DataBind();

                }
                else
                {
                    gvNotice.DataSource = null;
                    gvNotice.DataBind();
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }

        protected void gvNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = ((Label)e.Row.FindControl("lblNoticeID")).Text.ToString();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        if (dtDoc.Rows[0]["ApplicantDocName"].ToString() == "" || dtDoc.Rows[0]["ApplicantDocName"].ToString() == null)
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = false;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = true;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = true;
                        }

                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }


        }

        protected void gvNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % gvNotice.PageSize;
            string SerReqNo = gvNotice.DataKeys[index].Values[0].ToString();
            string NoticeID = gvNotice.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_Notice.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc1 = ds.Tables[0];

                    if (dtDoc1.Rows.Count > 0)
                    {
                        download(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "ViewDocumentApplicant")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["ApplicantDocContent"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_NoticeApplicantDoc.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocumentApplicant")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc1 = ds.Tables[0];

                    if (dtDoc1.Rows.Count > 0)
                    {
                        downloadApplicantDoc(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
            }
        }
        private void downloadApplicantDoc(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["ApplicantDoc"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["ApplicantDocContent"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ApplicantDocName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }

        private void download(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }

       
    }
}