using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceTimelines : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindServiceTimelinesGridView();
            }

        }

        #region "Bind ServiceTimelines Records in GridView"
        private void BindServiceTimelinesGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceTimelinesRecords();
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


        #region GridView2 (BoundFields with Paging and Sorting)
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindServiceTimelinesGridView();

        }
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression.Trim() == this.SortField)
                this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
            else
                this.SortDirection = "A";

            this.SortField = e.SortExpression;
            BindServiceTimelinesGridView();

        }
        #endregion

        #region Properties for Sorting and DataTable
        string SortField
        {
            get
            {
                object o = ViewState["SortField"];
                if (o == null)
                    return String.Empty;
                else
                    return (string)o;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        string SortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                    return String.Empty;
                else
                    return (string)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        public DataTable Temp
        {
            get
            {
                object o = ViewState["Temp"];
                if (o == null)
                {
                    DataTable dt = new DataTable();
                    return dt;
                }
                else
                    return (DataTable)o;
            }
            set
            {
                ViewState["Temp"] = value;
            }
        }
        #endregion

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //int row = Convert.ToInt32(GridView2.DataKeys[e.rowIndex].Value);
            ////Reference the GridView Row.
            //GridViewRow row = GridView2.Rows[rowIndex];

            //if (string.IsNullOrWhiteSpace(e.CommandArgument.ToString()))
            //{
            //    return;
            //}


            if (e.CommandName == "ViewDoc")
            {

                //int index = e.Row.RowIndex;
                int ServiceID = Convert.ToInt32(e.CommandArgument);
                //int index = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ServicelineChecklist.aspx?id=" + ServiceID, false);
            }
            if (e.CommandName == "ApplyRow")
            {

                int ServiceID = Convert.ToInt32(e.CommandArgument);

                //if (ServiceID == 1)
                //{
                //    Response.Redirect("WaterConnection.aspx?id=" + ServiceID, false);
                //}
                //else
                //{
                Response.Redirect("BuildingPlan.aspx?id=" + ServiceID, false);
                // }
            }
        }
        //protected void OnDataBound(object sender, EventArgs e)
        //{
        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    TableHeaderCell cell = new TableHeaderCell();
        //    cell.Text = "";
        //    cell.ColumnSpan = 2;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 2;
        //    cell.Text = "Service delivery Timelines (in Number of days) ";
        //    cell.HorizontalAlign = HorizontalAlign.Center;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 2;
        //    cell.Text = "";
        //    row.Controls.Add(cell);
        //    row.BackColor = ColorTranslator.FromHtml("#efefef");
        //    GridView2.HeaderRow.Parent.Controls.AddAt(0, row);
        //}


    }
}