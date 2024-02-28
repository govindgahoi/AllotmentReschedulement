using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PIPInbox : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Application for Issuance of Unique ID for PIP" });
                sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Application for Financial Disbursement for PIPFIN" });
                
                sub_menu.DataBind();
                BindAlertServiceRequestGridView();
                BindServiceRequestGridView();


                if (ApplicationView.ActiveViewIndex <= 0)
                {
                    ApplicationView.ActiveViewIndex = 0;

                }
            }
        }
        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }

        #region "Bind ServiceRequest in Private Industrial Parks"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                Mbal objMbal = new Mbal();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfPIPInBox(objServiceTimelinesBEL);
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
                ds1 = objMbal.GetApplicationOfPIPFINInBox(objServiceTimelinesBEL);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ChangeOfProject_Grid.DataSource = ds1.Tables[0];
                    ChangeOfProject_Grid.DataBind();
                }
                else
                {
                    ChangeOfProject_Grid.DataSource = null;
                    ChangeOfProject_Grid.DataBind();
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

        private void BindAlertServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetAlertApplicationOfPIPInBox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid_Announcement_List.DataSource = ds;
                    grid_Announcement_List.DataBind();
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
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

    }
}