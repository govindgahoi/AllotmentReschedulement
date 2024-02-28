using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class CMDashboardReport : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            Bind_Announcement_List_GridView();

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


                ds = objServiceTimelinesBLL.GETDATAFORCMDASHBOARDREPORT(objServiceTimelinesBEL);



                if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata2 = ds.Tables[2]; }
                if (ds.Tables[3].Rows.Count > 0) { Getdata3 = ds.Tables[3]; }
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

                    GridView grdview = e.Row.FindControl("GridLevel1") as GridView;
                    grdview.DataSource = Getdata1;
                    grdview.DataBind();

                }

            }
            catch (Exception ex)
            {
                //  Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void GridLevel1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView grid = (GridView)sender;
                    string RegionalOffice = grid.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata2.Select("RegionalOffice = '" + RegionalOffice + "'");
                    DataTable dt1 = dr.CopyToDataTable();



                    GridView Level2 = e.Row.FindControl("GridLevel2") as GridView;

                    Level2.DataSource = dt1;
                    Level2.DataBind();


                }

            }
            catch (Exception ex)
            {
                // Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void GridLevel2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView grid = (GridView)sender;
                    string ID = grid.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata3.Select("Id = '" + ID + "'");
                    DataTable dt1 = dr.CopyToDataTable();



                    GridView Level3 = e.Row.FindControl("GridLevel3") as GridView;

                    Level3.DataSource = dt1;
                    Level3.DataBind();


                }

            }
            catch (Exception ex)
            {
                // Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 3;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Over all Time line 21 Day";
            cell.ColumnSpan = 4;
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Accounts";
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Data Verifier";
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Regional Manager";
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "CMIA";
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Managing Director ";
            cell.CssClass = "Center";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Allotment";
            cell.CssClass = "Center";
            row.Controls.Add(cell);


            GridView2.HeaderRow.Parent.Controls.AddAt(0, row);
        }

        protected void GridLevel3_DataBound(object sender, EventArgs e)
        {
            GridView grid = (GridView)sender;
            try
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "";
                cell.ColumnSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Over all Time line 21 Day";
                cell.ColumnSpan = 2;
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                cell.Text = "Accounts";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                cell.Text = "Data Verifier";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                cell.Text = "Regional Manager";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                cell.Text = "CMIA";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                cell.Text = "Managing Director ";
                cell.CssClass = "Center";
                row.Controls.Add(cell);



                grid.HeaderRow.Parent.Controls.AddAt(0, row);
            }
            catch (Exception)
            {


            }
        }

        protected void GridLevel2_DataBound(object sender, EventArgs e)
        {

            GridView grid = (GridView)sender;
            try
            {


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "";
                cell.ColumnSpan = 3;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Over all Time line 21 Day";
                cell.ColumnSpan = 4;
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Accounts";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Data Verifier";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Regional Manager";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "CMIA";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Managing Director ";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Allotment";
                cell.CssClass = "Center";
                row.Controls.Add(cell);


                grid.HeaderRow.Parent.Controls.AddAt(0, row);
            }
            catch (Exception)
            {


            }
        }

        protected void GridLevel1_DataBound(object sender, EventArgs e)
        {
            GridView grid = (GridView)sender;
            try
            {


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "";
                cell.ColumnSpan = 3;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Over all Time line 21 Day";
                cell.ColumnSpan = 4;
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Accounts";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Data Verifier";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Regional Manager";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "CMIA";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Managing Director ";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Allotment";
                cell.CssClass = "Center";
                row.Controls.Add(cell);

                grid.HeaderRow.Parent.Controls.AddAt(0, row);
            }
            catch (Exception)
            {


            }
        }
    }
}