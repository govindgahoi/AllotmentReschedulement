using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestSubmitted : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

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
                objServiceTimelinesBEL.RequestReportType = "SUBMITTED";
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
            BindServiceRequestGridView();

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
            //if (e.CommandName == "EditRow")
            //{

            //    //  pnlChecklist.Enabled = true;
            //    GridViewRow row = GridView2.SelectedRow;
            //    //  int index = e.Row.RowIndex;

            //    int index = Convert.ToInt32(e.CommandArgument);
            //    var a = GridView2.Rows[index].Cells[0].Text;
            //    var b = GridView2.Rows[index].Cells[1].Text;
            //    drplanduse.SelectedIndex = drplanduse.Items.IndexOf(drplanduse.Items.FindByText(b));
            //    txtActivity.Text = GridView2.Rows[index].Cells[2].Text;
            //    txtTimelines.Text = GridView2.Rows[index].Cells[3].Text;
            //    txtApprover.Text = GridView2.Rows[index].Cells[4].Text;
            //    lblServiceID.Text = a;
            //    pnlCheckList.Enabled = true;
            //    lnkChecklist.Visible = true;
            //    btnSubmit.Text = "Update";
            //}
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