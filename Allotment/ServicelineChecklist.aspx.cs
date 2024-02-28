using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServicelineChecklist : System.Web.UI.Page
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

        protected void ShowCheckList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                int Parameter = 0;
                //int Parameter = Convert.ToInt32(ViewState["allotteeid"]);
                int ID = Convert.ToInt32(e.CommandArgument.ToString());

                //     int Service_Id = Convert.ToInt32(ShowCheckList.DataKeys[ID % ShowCheckList.PageSize][0].ToString());
                //     int Service_TimeLine_ID = Convert.ToInt32(ShowCheckList.DataKeys[ID][1].ToString());

                objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(ShowCheckList.DataKeys[ID % ShowCheckList.PageSize][1].ToString());
                objServiceTimelinesBEL.ServiceCheckListsID = Convert.ToInt32(ShowCheckList.DataKeys[ID % ShowCheckList.PageSize][0].ToString());



                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetChecklistDocumentByParmeter(objServiceTimelinesBEL);

                    DataTable dtDoc = new DataTable();
                    dtDoc = ds.Tables[0];
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
            Byte[] bytes = (Byte[])dt.Rows[0]["Documents"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["ContentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["Name"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }



        public void BindServiceCheckListGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceChecklistId = Request.QueryString["id"];

                ds = objServiceTimelinesBLL.GetServiceChecklists(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ShowCheckList.DataSource = ds;
                    ShowCheckList.DataBind();
                }
                else
                {
                    ShowCheckList.DataSource = null;
                    ShowCheckList.DataBind();
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

        protected void ShowCheckList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ShowCheckList.PageIndex = e.NewPageIndex;
            this.BindServiceCheckListGridView();
            //  ShowCheckList.DataBind();

        }

        protected void ShowCheckList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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

        protected void Conform_CheckBox_multiview_1_CheckChanged(object sender, EventArgs e)
        {
            if (Conform_CheckBox_multiview_1.Checked == true) { btnApply.Enabled = true; }
            else { btnApply.Enabled = false; }
        }

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


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //   LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    //   string AllottementLetterNo = _objLoginInfo.userName;
                    //   objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    //   int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    //   int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());

                    int Service_Id = Convert.ToInt32(ShowCheckList.DataKeys[e.Row.RowIndex][0].ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(ShowCheckList.DataKeys[e.Row.RowIndex][1].ToString());

                    string a = e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "");
                    string b = e.Row.Cells[2].Text.Trim().Replace("&nbsp;", "");
                    string c = e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "");

                    if (a.Length > 0 && b.Length > 0 && c.Length > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string ServiceID = Request.QueryString["id"];


            //if(ServiceID=="3")
            //{
            //    Response.Redirect("WaterConnection.aspx?id=" + ServiceID, false);
            //}
            //else
            //{
            Response.Redirect("BuildingPlan.aspx?id=" + ServiceID, false);
            // }

        }
    }
}