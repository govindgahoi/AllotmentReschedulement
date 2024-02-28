using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class LidaServiceRequestNew : System.Web.UI.Page
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

            //string Department = gm.GetUserDepartment(UserId);
            string Department = gm.GetUserDepartment1(UserId);

            if (!Page.IsPostBack)
            {
                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    //sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                    //sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Amalgamation Post Allotment" });
                    //----Test----

                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Building Plan - Approved" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan -Not Approved" });
                    sub_menu.DataBind();
                }
                else
                {//----Test----

                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Building Plan - Approved" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan -Not Approved" });
                    sub_menu.DataBind();
                }
                BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
                //BindServiceRequestGridViewTransfer();
                //BindServiceRequestGridViewAmalgamation();

                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 0;

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

                ds = objServiceTimelinesBLL.GetApplicationOfLidaBuildingPlanInBox(objServiceTimelinesBEL);
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
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    Getdata2 = ds.Tables[0];
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "lida_allotee_id"));
                //if (CategoryID == 2)

                //    e.Row.BackColor = System.Drawing.Color.White;
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
                //[GetApplicationForLidaBuildingPlanNotApprovedInbox]
        ds = objServiceTimelinesBLL.GetApplicationOfLidaBuildingPlanNotApprovedInBox(objServiceTimelinesBEL);
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
            //try
            //{

            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        DateTime WeakStartDate = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString()).AddDays(0);
            //        DateTime WeakEndDate = Convert.ToDateTime(GridView2.DataKeys[e.Row.RowIndex].Values[1].ToString()).AddDays(0);
            //        string IAID = GridView2.DataKeys[e.Row.RowIndex].Values[2].ToString();
            //        string Row = GridView2.DataKeys[e.Row.RowIndex].Values[3].ToString();
            //        var Values = (from r in Getdata2.AsEnumerable()
            //                      select r["IAID"]).Distinct().ToList();
            //        var x = (from r in Getdata2.AsEnumerable()
            //                 select r["IAID"]).Distinct().ToList();

            //        DataRow[] dr = Getdata1.Select("IAID = '" + IAID + "' and RequestedDate>='" + WeakStartDate + "' and RequestedDate<='" + WeakEndDate + "'");
            //        DataTable dt1 = dr.CopyToDataTable();


            //        GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
            //        grdview.DataSource = dt1;
            //        grdview.DataBind();


            //        foreach (GridViewRow item in grdview.Rows)
            //        {

            //            if (Row == "1")
            //            {
            //                HyperLink asp = item.FindControl("Hyper1") as HyperLink;
            //                asp.Attributes.Add("Style", "color:green !important");
            //                asp.Enabled = true;
            //            }
            //            else
            //            {
            //                HyperLink asp = item.FindControl("Hyper1") as HyperLink;
            //                asp.Attributes.Add("Style", "color:#2d2d2d; !important");
            //                asp.Enabled = false;
            //            }

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Oops! error occured :" + ex.Message.ToString());
            //}
        }
        #endregion



       

    }
}