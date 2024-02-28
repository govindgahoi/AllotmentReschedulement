using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestClose : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {

                BindServiceRequestGridView();
            }
        }

        #region "Bind ServiceRequest  in GridView"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.RequestReportType = "COMPLETE";

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetServiceRequestTempRecords(objServiceTimelinesBEL);

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
        #endregion


        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            //this.BindServiceCheckListGridView();

        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                if (CategoryID == 2)
                    // color the background of the row yellow
                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % GridView2.PageSize;
            string SerReqNo = (GridView2.DataKeys[index].Values[0]).ToString();
            string[] Arr = SerReqNo.Split('/');
            if (e.CommandName == "Print")
            {


                if (Arr[1] == "1")
                {
                    SqlCommand cmd = new SqlCommand("GetAllotmentletterFormSerReqNo '" + SerReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script>window.open ('BuildingPlanLetterView.aspx?AllotteeId=" + dt.Rows[0][0].ToString().Trim() + "','_blank');</script>");
                    }

                }
                else if (Arr[1] == "1000")
                {
                    SqlCommand cmd = new SqlCommand("GetAllotmentletterFormSerReqNo1 '" + SerReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script>window.open('AllotmentLetterView.aspx?AllotteeId=" + dt.Rows[0][0].ToString().Trim() + "','_blank');</script>");
                    }

                }
                else if (Arr[1] == "4")
                {

                    Response.Write("<script>window.open('TransferLetterView.aspx?AllotteeId=" + SerReqNo.Trim() + "','_blank');</script>");


                }

            }
            if (e.CommandName == "Upload")
            {

                Response.Write("<script>window.open('UploadSignedCopy.aspx?ServiceReqNo=" + SerReqNo.Trim() + "','_blank');</script>");


            }
            //if (e.CommandName == "DeleteRow")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    int Service_Id = Convert.ToInt32(GridView2.Rows[index].Cells[0].Text);
            //    objServiceTimelinesBEL.ServiceTimeLinesID = Service_Id;
            //    string confirmValue = Request.Form["confirm_value"];
            //    if (confirmValue == "Yes")
            //    {
            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            //    }
            //    else
            //    {
            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            //    }

            //    try
            //    {
            //        int retVal = objServiceTimelinesBLL.DeleteServiceRecord(objServiceTimelinesBEL);

            //        if (retVal > 0)
            //        {
            //            lblStatus.Text = "ServiceTimelines deleted successfully";
            //            lblStatus.ForeColor = System.Drawing.Color.Green;
            //            ClearAll();
            //            BindServiceTimelinesGridView();
            //            BindCategory();
            //        }
            //        else
            //        {
            //            lblStatus.Text = "ServiceTimelines couldn't be deleted";
            //            lblStatus.ForeColor = System.Drawing.Color.Red;
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

        }






    }
}