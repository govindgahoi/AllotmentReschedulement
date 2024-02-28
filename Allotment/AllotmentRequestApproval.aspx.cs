using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class AllotmentRequestApproval : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {



                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "New Allotments" });
                sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Plot Transfer" });
                sub_menu.DataBind();
                BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
                BindServiceRequestGridViewTransfer();
                BindTotalCount();
                if (ApplicationView.ActiveViewIndex <= 0)
                {
                    ApplicationView.ActiveViewIndex = 0;

                }

            }
        }

        private DataTable Getdata2
        {
            get; set;
        }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }


        #region "Bind ServiceRequest in GridView Building Plan"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfBuildingPlanInBox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                if (CategoryID == 2)

                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }
        #endregion




        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;


                ds = objServiceTimelinesBLL.Get_Announcement_ListNew_HO(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[1];
                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }


        private void BindTotalCount()
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.BindTotalCountInboxHOLA(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {

                    grid_Announcement_List.DataSource = ds.Tables[0];
                    grid_Announcement_List.DataBind();

                    TotalPending.Text = ds.Tables[1].Rows[0][0].ToString();

                }
                else
                {
                    grid_Announcement_List.DataSource = null;
                    grid_Announcement_List.DataBind();

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
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //DateTime WeakStartDate = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString()).AddDays(-1);
                    //DateTime WeakEndDate   = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[1].ToString());
                    //string IAID            = GridView2.DataKeys[e.Row.RowIndex].Values[2].ToString();

                    //DataRow[] dr  = Getdata1.Select("IAID = '"+IAID+"' and RequestedDate>='"+WeakStartDate+"' and RequestedDate<='"+WeakEndDate+"'");
                    //DataTable dt1 = dr.CopyToDataTable();

                    //GridView grdview   = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                    //grdview.DataSource = dt1;
                    //grdview.DataBind();

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DateTime WeakStartDate = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString()).AddDays(0);
                        DateTime WeakEndDate = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[1].ToString()).AddDays(0);
                        string IAID = GridView2.DataKeys[e.Row.RowIndex].Values[2].ToString();
                        string Row = GridView2.DataKeys[e.Row.RowIndex].Values[3].ToString();
                        var Values = (from r in Getdata2.AsEnumerable()
                                      select r["IAID"]).Distinct().ToList();
                        var x = (from r in Getdata2.AsEnumerable()
                                 select r["IAID"]).Distinct().ToList();

                        DataRow[] dr = Getdata1.Select("IAID = '" + IAID + "' and RequestedDate>='" + WeakStartDate + "' and RequestedDate<='" + WeakEndDate + "'");
                        DataTable dt1 = dr.CopyToDataTable();


                        GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                        grdview.DataSource = dt1;
                        grdview.DataBind();


                        foreach (GridViewRow item in grdview.Rows)
                        {

                            if (Row == "1")
                            {
                                HyperLink asp = item.FindControl("Hyper1") as HyperLink;
                                asp.Attributes.Add("Style", "color:green !important");
                                asp.Enabled = true;
                            }
                            else
                            {
                                HyperLink asp = item.FindControl("Hyper1") as HyperLink;
                                asp.Attributes.Add("Style", "color:#2d2d2d; !important");
                                asp.Enabled = false;
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #region "Transfer Of Plot"

        private void BindServiceRequestGridViewTransfer()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfTransferPlotInBox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
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
        //--Test--
        protected void grid_Announcement_List_PageIndexChanging(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = GridView3.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string NM = GridView3.DataKeys[e.Row.RowIndex].Values[1].ToString();
                if (NM.Length > 0)
                {
                    lnkd.NavigateUrl = "~/IAServicesAssessmentApp.aspx?ServiceReqNo=" + ReqNo + "";

                }
                else
                {
                    lnkd.NavigateUrl = "~/BPServiceRequestInbox.aspx?ServiceID=" + ReqNo + "";
                }
            }
        }

        #endregion

    }
}