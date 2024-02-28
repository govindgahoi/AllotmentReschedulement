using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{
    public partial class LandAcquisitionview : System.Web.UI.Page
    {
        string UserName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;

            if (!IsPostBack)
            {
                bindgrid();
                mask.Visible = false;
            }
        }
        public void bindgrid()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridLAP();
                if (ds != null)
                {
                    gridLAP.DataSource = ds;
                    gridLAP.DataBind();
                }
                else
                {
                    gridLAP.DataSource = null;
                    gridLAP.DataBind();
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


        protected void gridLAP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridLAP.PageIndex = e.NewPageIndex;
                bindgrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridforSearch(txtSearch.Text);
                if (ds != null)
                {
                    gridLAP.DataSource = ds;
                    gridLAP.DataBind();
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


        //private void get_detals(string id)
        //{
        //    belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetgridforLandoffred(id);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {

        //            txtVillage.Text = ds.Tables[0].Rows[0]["Village"].ToString();
        //            txtFatherHusbandName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();                  
        //            txtGataArea.Text = ds.Tables[0].Rows[0]["GataArea"].ToString();
        //            txtGataNo.Text = ds.Tables[0].Rows[0]["GataNo"].ToString();
        //            txtKhataNo.Text = ds.Tables[0].Rows[0]["KhataNo"].ToString();
        //            txtKhatedarName.Text = ds.Tables[0].Rows[0]["KhatedarName"].ToString();
        //            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        //        }
        //        else
        //        {

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
        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
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

            //Response.End();
        }
        protected void gridLAP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                RegisterPostBackControl();
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                DataSet ds = new DataSet();

                if (e.CommandName == "selectDocument")
                {




                    //GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //int rowIndex = gvr.RowIndex;
                    //string rowid = e.CommandArgument.ToString();
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //index = index % gridLAP.PageSize;
                    //int Service_Id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LandAcquisitionID"));
                    //string rowid = (gridLAP.Rows[rowIndex].FindControl("lbhyper") as HyperLink).Text;
                    //string rowid = Convert.ToString(gridLAP.Rows[index].Cells[0].Text);
                    //string Service_TimeLine_ID = Convert.ToString(gridLAP.Rows[index].Cells[2].Text);
                    string rowid = e.CommandArgument.ToString();
                    // string rowid = e.CommandArgument.ToString();
                    //  string rowid=Convert.ToString(ViewState["ID"]);
                    int rowids = Convert.ToInt32(rowid);
                    ds = objServiceTimelinesBLL.GetgridforLandoffred(rowids);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }

                }
                if (e.CommandName == "Document")
                {
                    string rowid = e.CommandArgument.ToString();
                    int rowids = Convert.ToInt32(rowid);
                    ds = objServiceTimelinesBLL.GetgridforLandoffred1(rowids);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void RegisterPostBackControl()
        {

            foreach (GridViewRow row in gridLAP.Rows)
            {
                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);



            }
        }

        protected void gridLAP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    //string AllottementLetterNo = _objLoginInfo.userName;
                    //objServiceTimelinesBEL.UserName = AllottementLetterNo;
                    int Service_Id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LandAcquisitionID"));
                    DataSet ds1 = new DataSet();

                    ds1 = objServiceTimelinesBLL.GetgridforLandoffred(Service_Id);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
    }
}