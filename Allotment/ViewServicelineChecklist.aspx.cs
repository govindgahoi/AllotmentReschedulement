using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ViewServicelineChecklist : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindServiceCheckListGridView();
            }
        }
        #region "Bind ServicelineCheckList Records in GridView"

        //protected void ShowCheckList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "selectDocument")
        //    {
        //        int Parameter = 0;
        //        //int Parameter = Convert.ToInt32(ViewState["allotteeid"]);
        //        int ID = Convert.ToInt32(e.CommandArgument.ToString());
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            ds = objServiceTimelinesBLL.GetAllotteesDocumenttBasedtooPar(Parameter, ID);
        //            DataTable dtDoc = ds.Tables[0];
        //            if (dtDoc != null)
        //            {
        //                download(dtDoc);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured :" + ex.Message.ToString());
        //        }
        //    }
        //}
        //private void download(DataTable dt)
        //{
        //    Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = dt.Rows[0]["contentType"].ToString();
        //    Response.AddHeader("content-disposition", "attachment;filename="
        //    + dt.Rows[0]["ColName"].ToString());
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();
        //}

        #region BindServiceCheckList
        public void BindServiceCheckListGridView()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            string SerReqID = Request.QueryString["id"];
            objServiceTimelinesBEL.ServiceChecklistId = SerReqID;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceChecklists(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtDoc = ds.Tables[0];
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
        #endregion

        //public void BindServiceCheckListGridView()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        objServiceTimelinesBEL.ServiceChecklistId = Request.QueryString["id"];
        //        ds = objServiceTimelinesBLL.GetServiceChecklists(objServiceTimelinesBEL);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ShowCheckList.DataSource = ds;
        //            ShowCheckList.DataBind();
        //        }
        //        else
        //        {
        //            ShowCheckList.DataSource = null;
        //            ShowCheckList.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        objServiceTimelinesBEL = null;
        //        objServiceTimelinesBLL = null;
        //    }

        //}

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                        if (dtDoc.Rows[0]["ColName"].ToString() == "" || dtDoc.Rows[0]["ColName"].ToString() == null)
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
            catch(Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];
            int Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
            int Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());
            if (e.CommandName == "ViewDocument")
            {
                Response.Write("<script>window.open ('CheckListViewer.aspx?ServiceCheckListsID=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID +  "','_blank');</script>");

               
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
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
            try
            {
                DataSet ds1 = new DataSet();
                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                ds1 = objServiceTimelinesBLL.GetCheckListDocumentList(objServiceTimelinesBEL);
                DataTable dtDoc = ds1.Tables[0];
                if (dtDoc.Rows.Count > 0)
                {
                    GridView2.Rows[index].FindControl("lbView").Visible = true;
                    GridView2.Rows[index].FindControl("lbView1").Visible = true;
                }
                else
                {
                    GridView2.Rows[index].FindControl("lbView").Visible = false;
                    GridView2.Rows[index].FindControl("lbView1").Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        
        private void download(DataTable dt)
        {
            try
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
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindServiceCheckListGridView();

        }


        protected void ShowCheckList_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void ShowCheckList_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ShowCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Conform_CheckBox_multiview_1_CheckChanged(object sender, EventArgs e)
        //{
        //    if (Conform_CheckBox_multiview_1.Checked == true) { btnApply.Enabled = true; }
        //    else { btnApply.Enabled = false; }
        //}

        protected void ShowCheckList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgDownload = (ImageButton)e.Row.FindControl("imgDownload");
                string fileExtension = e.Row.Cells[0].Text;
                if (fileExtension.Contains(".txt"))
                {
                    imgDownload.ImageUrl = "Images/Text.jpg";
                }
                if (fileExtension.Contains(".pdf"))
                {
                    imgDownload.ImageUrl = "Images/pdf.jpg";
                }
                if (fileExtension.Contains(".zip"))
                {
                    imgDownload.ImageUrl = "Images/zip.jpg";
                }
            }
        }

        #endregion
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string ServiceID = Request.QueryString["id"];
        //    Response.Redirect("BuildingPlan.aspx?id=" + ServiceID, false);
        //}
    }
}