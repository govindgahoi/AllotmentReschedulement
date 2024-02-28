using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{

    public partial class ViewCompletionCertificate : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            GetLeaseDeedDocumentDetail();
        }

        private void GetLeaseDeedDocumentDetail()
        {
            string Parameter = txtSearch.Text;
            ViewState["Parameter"] = txtSearch.Text.Trim();
            string DocumentType = "Completion Certificate";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotetmentLetterDocument(Parameter, DocumentType);
                DataTable dt = ds.Tables[0];
                GridViewDocument.DataSource = dt;
                GridViewDocument.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void GridViewDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                string Parameter = (ViewState["Parameter"]).ToString();
                string DocumentType = "Completion Certificate";
                //int Parameter = Convert.ToInt32(ViewState["allotteeid"]);
                //int ID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllotetmentLetterDocument(Parameter, DocumentType);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }
        private void download(DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["contentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        protected void OnPagingChange(object sender, GridViewPageEventArgs e)
        {
            GridViewDocument.PageIndex = e.NewPageIndex;
            this.GetLeaseDeedDocumentDetail();
        }
    }
}