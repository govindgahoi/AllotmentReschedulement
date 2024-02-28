using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{




    public partial class Tickets : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {


                BindTicketGridView();


            }

        }


        private void BindTicketGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserId = _objLoginInfo.userid;
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";



                ds = objServiceTimelinesBLL.BindTicketGridView(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }
                if (ds.Tables[3].Rows.Count > 0) { Getdata4 = ds.Tables[3]; }


                string sortOrder = "ReceivedDate ASC";
                string query = "";
                int cnt = 0;

                DataTable dtOpenTicket = null;
                DataTable dtCloseicket = null;


                try
                {

                    if (ds.Tables[2].Rows.Count > 0)
                    {

                        GridViewInProcess.DataSource = Getdata3;
                        GridViewInProcess.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {

                        GridTicketClose.DataSource = Getdata4;
                        GridTicketClose.DataBind();
                    }



                }
                catch { Exception ex; }




                if (ds.Tables[1].Rows.Count > 0)
                {

                    GridviewTicketOwned.DataSource = ds.Tables[1];
                    GridviewTicketOwned.DataBind();

                }
                else
                {
                    GridviewTicketOwned.DataSource = null;
                    GridviewTicketOwned.DataBind();
                }





                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    Getdata1 = ds.Tables[1];
                //}



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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Select_Applicant_for_process")
            {

                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview

                string ServiceTicketId = myGrid.DataKeys[myRow.RowIndex].Values[0].ToString();
                string ServiceReqNo = myGrid.DataKeys[myRow.RowIndex].Values[1].ToString();
                string ServiceStage = myGrid.DataKeys[myRow.RowIndex].Values[2].ToString();
                string PacketID = myGrid.DataKeys[myRow.RowIndex].Values[3].ToString();



                try
                {

                    if (ServiceStage == "2")
                    {
                        Response.Redirect("~/AccountClearence.aspx?ServicesId=" + ServiceReqNo + "&TicketDescription=" + ServiceStage + "&TicketID=" + ServiceTicketId + "&PacketID=" + PacketID, false);
                    }


                    if (ServiceStage == "3" || ServiceStage == "4" || ServiceStage == "5" || ServiceStage == "10")
                    {
                        Response.Redirect("~/Assessment.aspx?ServiceReqNo=" + ServiceReqNo + "&PacketId=" + PacketID + "&TicketId=" + ServiceTicketId + " ");
                    }

                    if (ServiceStage == "6" || ServiceStage == "7" || ServiceStage == "8" || ServiceStage == "9")
                    {
                        Response.Redirect("~/Evaluation.aspx?PacketID=" + PacketID + "");
                    }


                    //if (ServiceStage == "10" )
                    //  {
                    //    Response.Redirect("~/Inspection_Page.aspx?ServiceReqNo=" + ServiceReqNo + "&PacketId=" + PacketID + "&TicketId=" + ServiceTicketId + "");
                    //  }


                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }




        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridviewTicketOwned_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridviewTicketOwned_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridviewTicketOwned_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridviewTicketOwned_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridviewTicketOwned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView_TicketClosed_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView_TicketClosed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView_TicketClosed_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView_TicketClosed_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void GridViewInProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                try
                {
                    string id1 = GridViewInProcess.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    string PacketID = GridViewInProcess.DataKeys[e.Row.RowIndex].Values[1].ToString();

                    if (Getdata1 != null)
                    {

                        string sortOrder = "ReceivedDate ASC";
                        string query = "";
                        int cnt = 0;

                        DataTable dtOpenTicket = null;
                        DataTable dtCloseicket = null;

                        if (Getdata1.Rows.Count > 0)
                        {

                            cnt = Getdata1.Select("TicketStage not in ('7','8')", sortOrder).Count();

                            if (cnt > 0)
                            {
                                dtOpenTicket = Getdata1.Select("TicketStage not in ('7','8') and PacketID=" + PacketID + "", sortOrder).CopyToDataTable();
                            }
                            else { dtOpenTicket = Getdata1.Clone(); }







                            GridView grdview = e.Row.FindControl("GridView2") as GridView;
                            if (dtOpenTicket.Rows.Count > 0)
                            {
                                grdview.DataSource = dtOpenTicket;
                                grdview.DataBind();
                            }
                            else
                            {
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }
                    }
                }

                catch { }
            }
        }

        protected void GridTicketClose_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    string id1 = GridTicketClose.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    string PacketID = GridTicketClose.DataKeys[e.Row.RowIndex].Values[1].ToString();

                    if (Getdata1 != null)
                    {

                        string sortOrder = "ReceivedDate ASC";
                        string query = "";
                        int cnt = 0;

                        DataTable dtOpenTicket = null;
                        DataTable dtCloseicket = null;

                        if (Getdata1.Rows.Count > 0)
                        {

                            cnt = Getdata1.Select("TicketStage  in ('7','8')", sortOrder).Count();

                            if (cnt > 0)
                            { dtCloseicket = Getdata1.Select("TicketStage  in ('7','8') and PacketID=" + PacketID + "", sortOrder).CopyToDataTable(); }
                            else { dtCloseicket = Getdata1.Clone(); }










                            GridView grdview = e.Row.FindControl("GridView_TicketClosed") as GridView;
                            if (dtCloseicket.Rows.Count > 0)
                            {
                                grdview.DataSource = dtCloseicket;
                                grdview.DataBind();
                            }
                            else
                            {
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }
                    }
                }

                catch { }
            }
        }
    }
}

