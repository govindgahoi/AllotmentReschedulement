using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ViewBuildingPlanDocument : System.Web.UI.Page
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
            GetBuildingPlanDocumentDetail();
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

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BuildingPlanGridView.DataSource = null;
            //BuildingPlanGridView.Rows.Clear();
            BuildingPlanGridView.DataBind();
        }
        private void GetBuildingPlanDocumentDetail()
        {

            objServiceTimelinesBEL.Parameter = txtSearch.Text;
            ViewState["Parameter"] = txtSearch.Text.Trim();
            objServiceTimelinesBEL.IAName = ddlArea.SelectedItem.Text.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetBuildingPlanCertificateDetail(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        BuildingPlanGridView.DataSource = dt;
                        BuildingPlanGridView.DataBind();
                    }
                    else
                    {
                        MessageBox1.ShowInfo("Search Criteria With Industrial Area Doesn't Match <br/> Or Document For this Particular Match is not Available .Please Confirm and enter  the Correct Search Criteria <br/> OR email Info[at]upsidc[dot]com", 100, 420);
                        BuildingPlanGridView.DataSource = null;
                        BuildingPlanGridView.DataBind();
                        return;

                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void ResetRecord()
        {
            ddlArea.SelectedIndex = 0;
            txtSearch.Text = "";
        }

        protected void BuildingPlanGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                //string Parameter = (ViewState["Parameter"]).ToString();
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                objServiceTimelinesBEL.ID = Convert.ToInt32(arg[0]);
                string DocType = arg[1];
                if (DocType == "BuildingPlan Letter")
                {
                    objServiceTimelinesBEL.Type = "B";
                }
                else if (DocType == "Completion Certificate")
                {
                    objServiceTimelinesBEL.Type = "C";
                }
                else if (DocType == "Occupancy Certificate")
                {
                    objServiceTimelinesBEL.Type = "O";
                }
                //string DocumentType = "BuildingPlan Letter";
                //int Parameter = Convert.ToInt32(ViewState["Parameter"]);
                //int Parameter = Convert.ToInt32(ViewState["allotteeid"]);
                //int ID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetBuildingPlanCertificateDetailBasedtoPar(objServiceTimelinesBEL);
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