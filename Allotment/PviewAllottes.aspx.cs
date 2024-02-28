using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PviewAllottes : System.Web.UI.Page
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
            GetAllotteeDocumentDetail();
        }
        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            GridViewDocument.DataSource = null;
            GridViewDocument.DataBind();
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
        private void GetAllotteeDocumentDetail()
        {
            objServiceTimelinesBEL.Parameter = txtSearch.Text;
            ViewState["Parameter"] = txtSearch.Text.Trim();
            objServiceTimelinesBEL.IAID = ddlArea.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotementLetterDetail(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        GridViewDocument.DataSource = dt;
                        GridViewDocument.DataBind();
                    }
                    else
                    {
                        MessageBox1.ShowInfo("Search Criteria With Industrial Area Doesn't Match <br/> Or Document For this Particular Match is not Available .Please Confirm and enter  the Correct Search Criteria <br/> OR email Info[at]upsidc[dot]com", 100, 420);
                        GridViewDocument.DataSource = null;
                        GridViewDocument.DataBind();
                        return;

                    }
                }

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

                try
                {
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }

        protected void OnPagingChange(object sender, GridViewPageEventArgs e)
        {
            GridViewDocument.PageIndex = e.NewPageIndex;
            this.GetAllotteeDocumentDetail();
        }


    }
}