using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ViewInspectionDocument : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindIndustrialAreaDetail();
            }
        }
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            GetInspectionDocumentDetail();
        }
        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            InspectionGridView.DataSource = null;
            InspectionGridView.DataBind();
        }
        private void bindIndustrialAreaDetail()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                ddlArea.DataSource = ds;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void GetInspectionDocumentDetail()
        {
            objServiceTimelinesBEL.Parameter = txtSearch.Text;
            ViewState["Parameter"] = txtSearch.Text.Trim();
            objServiceTimelinesBEL.IAName = ddlArea.SelectedItem.Text.Trim();
            //string DocumentType = "Inspection Document";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetInspectionCertificateDetail(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        InspectionGridView.DataSource = dt;
                        InspectionGridView.DataBind();
                    }
                    else
                    {
                        MessageBox1.ShowInfo("Search Criteria With Industrial Area Doesn't Match <br/> Or Document For this Particular Match is not Available .Please Confirm and enter  the Correct Search Criteria <br/> OR email Info[at]upsidc[dot]com", 100, 420);
                        InspectionGridView.DataSource = null;
                        InspectionGridView.DataBind();
                        return;

                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void InspectionGridView_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {

                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                objServiceTimelinesBEL.ID = Convert.ToInt32(arg[0]);
                //objServiceTimelinesBEL.Parameter = (ViewState["Parameter"]).ToString();
                //string DocumentType = "Inspection Document";
                //int Parameter = Convert.ToInt32(ViewState["allotteeid"]);
                //objServiceTimelinesBEL.ID  = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetInspectionCertificateBasedtoPar(objServiceTimelinesBEL);
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
            + dt.Rows[0]["ColName"].ToString() + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}