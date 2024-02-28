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
    public partial class LandAllottementCompleted : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
            //UserID = _objLoginInfo.userid;
            if (!Page.IsPostBack)
            {
                UserSpecificBinding();
                BindServiceRequestGridView();
            }
        }
        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = UserName;
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                //ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));
                Regional_Changed(null, null);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAregionalOfficeWise(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                //drpdwnIA.Items.Insert(0, new ListItem("--All--", "All"));
                BindServiceRequestGridView();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGridView();
        }
        protected void Regional_Changed(object sender, EventArgs e)
        {
            try
            {

                bindDDLRegion(ddloffice.SelectedItem.Value, null);
                BindServiceRequestGridView();
            }
            catch (Exception ex)
            {

            }

        }


        //protected void UserSpecificBinding()
        //{
        //    objServiceTimelinesBEL.UserName = UserName;
        //    DataSet dsR = new DataSet();
        //    try
        //    {
        //        dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
        //        ddloffice.DataSource = dsR.Tables[0];
        //        ddloffice.DataTextField = "a";
        //        ddloffice.DataValueField = "b";
        //        ddloffice.DataBind();
        //        //ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));
        //        Regional_Changed(null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured111 :" + ex.Message.ToString());
        //    }
        //}

        //protected void Regional_Changed(object sender, EventArgs e)

        //{
        //    drpdwnIA.Items.Clear();
        //    drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

        //    try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

        //    //   Refesh(true);
        //    //   ResetControl();

        //}

        //private void bindDDLRegion(string pOffice, string pIAName)
        //{
        //    objServiceTimelinesBEL.RegionalOffice = (pOffice);
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
        //        drpdwnIA.DataSource = ds;
        //        drpdwnIA.DataTextField = "IAName";
        //        drpdwnIA.DataValueField = "Id";
        //        drpdwnIA.DataBind();
        //        //drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));
        //        if (!string.IsNullOrEmpty(pIAName))
        //        {
        //            drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
        //        }

        //        try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
        //        //      GetNewAllotteeDetails();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured111 :" + ex.Message.ToString());
        //    }

        //}
        //protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Bind plot list box
        //    BindServiceRequestGridView();

        //}
        #region "Bind ServiceRequest  in GridView"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
                objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.ServiceTimeLines = (1000).ToString();
                objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
                objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;
                objServiceTimelinesBEL.searchText = txtSearch.Text;
                ds = objServiceTimelinesBLL.GetLandAllottementCompletedRecords(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdCompleted.DataSource = ds;
                    gvdCompleted.DataBind();
                }
                else
                {
                    gvdCompleted.DataSource = null;
                    gvdCompleted.DataBind();
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

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGridView();
        }
        protected void gvdCompleted_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvdCompleted.PageIndex = e.NewPageIndex;
            //this.BindServiceCheckListGridView();

        }
        protected void gvdCompleted_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void gvdCompleted_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        //protected void gvdCompleted_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    int index = e.Row.RowIndex;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // determine the value of the UnitsInStock field
        //        int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
        //        if (CategoryID == 2)
        //            // color the background of the row yellow
        //            e.Row.BackColor = System.Drawing.Color.White;
        //    }
        //}
    }
}