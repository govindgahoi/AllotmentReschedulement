using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestInboxTEF_AutoApproval : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Lease Deed" });
                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Time Extension Fee" });
                sub_menu.DataBind();
                BindServiceRequestGridViewTEF();
                BindTotalCount();
                if (ApplicationView.ActiveViewIndex <= 0)
                {
                    ApplicationView.ActiveViewIndex = 0;

                }
                //BindServiceRequestGridViewLeaseDeed();
            }
        }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }
        #region "Bind ServiceRequest in GridView  TEF"
        private void BindServiceRequestGridViewTEF()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfTEFInBox_AutoApproval(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewTEF.DataSource = ds;
                    GridViewTEF.DataBind();
                }
                else
                {
                    GridViewTEF.DataSource = null;
                    GridViewTEF.DataBind();
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

        protected void GridViewTEF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                if (CategoryID == 2)

                    e.Row.BackColor = System.Drawing.Color.White;
            }
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

                ds = objServiceTimelinesBLL.BindTotalCountInboxTEFAuto(objServiceTimelinesBEL);
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
        #endregion




    }
}