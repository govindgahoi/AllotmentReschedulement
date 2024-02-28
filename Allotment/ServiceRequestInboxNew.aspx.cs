using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestInboxNew : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
        string UserName = "";
        int UserId = 0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;
            }
            catch (Exception)
            {

                Response.Redirect("/Default.aspx");
            }

            string Department = gm.GetUserDepartment(UserId);

            if (!Page.IsPostBack)
            {
                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                    sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Amalgamation Post Allotment" });
                    //----Test----
                    //sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Lida Land Allotment" });
                    sub_menu.DataBind();
                }
                else
                {
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "New Allotments" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                    sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Plot Transfer" });
                    sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Amalgamation Post Allotment" });
                    sub_menu.Items.Add(new MenuItem { Value = "4", Text = "SubDivision Post Allotment" });
                    sub_menu.DataBind();
                }
                BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
                BindServiceRequestGridViewTransfer();
                BindServiceRequestGridViewAmalgamation();
                BindServiceRequestGridViewSubdividion();
                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 1;
                    }
                }
                else
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 0;

                    }
                }
            }
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



        #region "Land Allotment Code"
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }


        private DataTable Getdata2
        {
            get; set;
        }
        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
             {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.Get_Announcement_ListNew(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }

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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

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
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        #endregion
        
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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = GridView3.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string NM = GridView3.DataKeys[e.Row.RowIndex].Values[1].ToString();
                if (NM.Length > 0)
                {
                    lnkd.NavigateUrl = "~/IAServicesAssessment.aspx?ServiceReqNo=" + ReqNo + "";

                } else
                {
                    lnkd.NavigateUrl = "~/BPServiceRequestInbox.aspx?ServiceID=" + ReqNo + "";
                }
            }
        }

        #endregion
        
        #region "Amalgamation Post Allotment"

        private void BindServiceRequestGridViewAmalgamation()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfAmalgamationPostAllotment(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_PostAmalgamation.DataSource = ds;
                    Grid_PostAmalgamation.DataBind();
                }
                else
                {
                    Grid_PostAmalgamation.DataSource = null;
                    Grid_PostAmalgamation.DataBind();
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



        protected void Grid_PostAmalgamation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = Grid_PostAmalgamation.DataKeys[e.Row.RowIndex].Values[0].ToString();


                lnkd.NavigateUrl = "~/IAServicesAssessment.aspx?ServiceReqNo=" + ReqNo + "";


            }
        }


        #endregion

        #region "SubDivision Post Allotment"

        private void BindServiceRequestGridViewSubdividion()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfSubDivisionPostAllotment(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_PostSubDivision.DataSource = ds;
                    Grid_PostSubDivision.DataBind();
                }
                else
                {
                    Grid_PostSubDivision.DataSource = null;
                    Grid_PostSubDivision.DataBind();
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

        protected void Grid_PostSubDivision_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = Grid_PostSubDivision.DataKeys[e.Row.RowIndex].Values[0].ToString();


                lnkd.NavigateUrl = "~/IAServicesAssessment.aspx?ServiceReqNo=" + ReqNo + "";


            }
        }

        #endregion


    }
}
