using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class VanvibhaagReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {

                BindVanVibhagGridView();
            }

        }

        #region "Bind ServiceTimelines Records in GridView"
        private void BindVanVibhagGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.SearchRecord = txtSearch1.Text;
                ds = objServiceTimelinesBLL.GetBindVanVibhagGridView(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindVanVibhagGridView();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string DocType = (DataBinder.Eval(e.Row.DataItem, "Industrial Area").ToString());

                    //int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    //int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());

                    try
                    {
                        DataSet ds1 = new DataSet();
                        objServiceTimelinesBEL.IndustrialArea = DocType;
                        ds1 = objServiceTimelinesBLL.GetPlatationDocument(objServiceTimelinesBEL);
                        DataTable dtDoc = ds1.Tables[0];
                        if (dtDoc.Rows.Count > 0)
                        {
                            e.Row.FindControl("LinkButton1").Visible = true;
                            //e.Row.FindControl("lbDelete").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("LinkButton1").Visible = false;
                            //e.Row.FindControl("lbDelete").Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }

                }
            }
            catch
            {

            }

        }
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            BindVanVibhagGridView();
        }
        protected void gridView_PreRender(object sender, EventArgs e)
        {
            MergeRows(GridView2);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);


        }
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = new string[1];
            arg = e.CommandArgument.ToString().Split(';');
            string DocType = arg[0];
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.IndustrialArea = DocType;
                    ds = objServiceTimelinesBLL.GetPlatationDocument(objServiceTimelinesBEL);
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
        public static void MergeRows(GridView GridView2)
        {
            int K = 0;

            for (int rowIndex = GridView2.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = GridView2.Rows[rowIndex];
                GridViewRow previousRow = GridView2.Rows[rowIndex + 1];

                //   for (int i = 0; i < row.Cells.Count; i++)
                //   {

                if (row.Cells[2].Text == previousRow.Cells[2].Text)
                {


                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[1].RowSpan = row.Cells[2].RowSpan;
                    previousRow.Cells[1].Visible = false;
                }
                if (row.Cells[3].Text == previousRow.Cells[3].Text)
                {
                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;
                }

            }

            string prev_hi = "EEE";
            for (int rowIndex = 0; rowIndex < GridView2.Rows.Count; rowIndex++)
            {

                GridViewRow row = GridView2.Rows[rowIndex];
                if (row.Cells[3].Visible == true)
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                        prev_hi = "FFF";
                    }
                    else
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");
                        prev_hi = "EEE";
                    }
                    K++;
                    //  row.Cells[0].Text = K.ToString();
                }
                else
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");

                    }
                    else
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                    }
                }

            }


        }
        #endregion
    }
}