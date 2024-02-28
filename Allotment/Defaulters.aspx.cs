using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Defaulters : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = string.Empty;
        decimal AreaTotal = 0;
        decimal AreaTotalAcres = 0;
        int Count = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                UserSpecificBinding();
                // BindGrid();
            }



        }

        public void BindGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                //    objServiceTimelinesBEL.RequestReportType = "INBOX";


                ds = objServiceTimelinesBLL.GetDefaultersList(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Getdata2 = ds.Tables[1];
                    GridView1.DataSource = Getdata2;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables[1].Clone(); ;
                    GridView1.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    Getdata3 = ds.Tables[2];
                    GridView3.DataSource = Getdata3;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    Getdata4 = ds.Tables[3];
                    GridView4.DataSource = Getdata4;
                    GridView4.DataBind();
                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    Getdata5 = ds.Tables[4];
                    GridView5.DataSource = Getdata5;
                    GridView5.DataBind();
                }
                else
                {
                    GridView5.DataSource = null;
                    GridView5.DataBind();
                }

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    Getdata1 = ds.Tables[0];
                //    GridView2.DataSource = Getdata1;
                //    GridView2.DataBind();
                //}
                //else
                //{
                //    GridView2.DataSource = null;
                //    GridView2.DataBind();
                //}

            }
            catch (Exception ex)
            { }

        }
        private DataTable Getdata1
        {
            get; set;
        }

        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata5
        {
            get; set;
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bind plot list box
            BindGrid();
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
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

            //   Refesh(true);
            //   ResetControl();

        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();



                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
                //      GetNewAllotteeDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double baseFactorAcre = 0.000247105;
            double AreaTotal = Getdata1.AsEnumerable().Sum(row => row.Field<double>("TotalAllottedplotArea"));
            Count = Getdata1.Rows.Count;
            AreaTotalAcres = Math.Truncate((decimal)AreaTotal * (decimal)baseFactorAcre);

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total Defaulters:" + " " + Count;
                // for the Footer, display the running totals
                e.Row.Cells[4].Text = "Total affected Area:" + " " + AreaTotal.ToString("N2") + " " + "SQMts.";
                e.Row.Cells[5].Text = "Affected Area In Acres:" + " " + AreaTotalAcres.ToString("N2") + " " + "Acres."; ;

                e.Row.Cells[3].HorizontalAlign = e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void drpdnRaiseReQ_IndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double baseFactorAcre = 0.000247105;
            double AreaTotal = Getdata2.AsEnumerable().Sum(row => row.Field<double>("TotalAllottedplotArea"));
            Count = Getdata2.Rows.Count;
            AreaTotalAcres = Math.Truncate((decimal)AreaTotal * (decimal)baseFactorAcre);

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total Defaulters:" + " " + Count;
                // for the Footer, display the running totals
                e.Row.Cells[4].Text = "Total affected Area:" + " " + AreaTotal.ToString("N2") + " " + "SQMts.";
                e.Row.Cells[5].Text = "Area affected In Acres:" + " " + AreaTotalAcres.ToString("N2") + " " + "Acres."; ;

                e.Row.Cells[3].HorizontalAlign = e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double baseFactorAcre = 0.000247105;
            double AreaTotal = Getdata3.AsEnumerable().Sum(row => row.Field<double>("TotalAllottedplotArea"));
            Count = Getdata3.Rows.Count;
            AreaTotalAcres = Math.Truncate((decimal)AreaTotal * (decimal)baseFactorAcre);

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total Defaulters:" + " " + Count;
                // for the Footer, display the running totalsF
                e.Row.Cells[4].Text = "Total affected Area:" + " " + AreaTotal.ToString("N2") + " " + "SQMts.";
                e.Row.Cells[5].Text = "Affected Area  In Acres:" + " " + AreaTotalAcres.ToString("N2") + " " + "Acres."; ;

                e.Row.Cells[3].HorizontalAlign = e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }

        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double baseFactorAcre = 0.000247105;
            double AreaTotal = Getdata4.AsEnumerable().Sum(row => row.Field<double>("TotalAllottedplotArea"));
            Count = Getdata4.Rows.Count;
            AreaTotalAcres = Math.Truncate((decimal)AreaTotal * (decimal)baseFactorAcre);

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total Defaulters:" + " " + Count;
                // for the Footer, display the running totals
                e.Row.Cells[4].Text = "Total affected Area:" + " " + AreaTotal.ToString("N2") + " " + "SQMts.";
                e.Row.Cells[5].Text = "Affected Area In Acres:" + " " + AreaTotalAcres.ToString("N2") + " " + "Acres."; ;

                e.Row.Cells[3].HorizontalAlign = e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }

        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double baseFactorAcre = 0.000247105;
            double AreaTotal = Getdata5.AsEnumerable().Sum(row => row.Field<double>("TotalAllottedplotArea"));
            Count = Getdata5.Rows.Count;
            AreaTotalAcres = Math.Truncate((decimal)AreaTotal * (decimal)baseFactorAcre);

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total Defaulters:" + " " + Count;
                // for the Footer, display the running totals
                e.Row.Cells[4].Text = "Total affected Area:" + " " + AreaTotal.ToString("N2") + " " + "SQMts.";
                e.Row.Cells[5].Text = "Affected Area In Acres:" + " " + AreaTotalAcres.ToString("N2") + " " + "Acres."; ;

                e.Row.Cells[3].HorizontalAlign = e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }

        }

        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView5.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }

        protected void GridView5_Sorting(object sender, GridViewSortEventArgs e)
        {

            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }

            Getdata5 = (DataTable)Session["Datatbl"];
            DataView sortedView = new DataView(Getdata1);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView5.DataSource = sortedView;
            GridView5.DataBind();

        }
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            BindGrid();

            DataTable dt = new DataTable();
            dt = Getdata1.Copy();

            //  dt = (DataTable)Session["GetData1"];
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView2.DataSource = sortedView;
            GridView2.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            BindGrid();

            DataTable dt = new DataTable();
            dt = Getdata2.Copy();
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView1.DataSource = sortedView;
            GridView1.DataBind();

        }

        protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            BindGrid();
            DataTable dt = new DataTable();
            dt = Getdata3.Copy();

            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView3.DataSource = sortedView;
            GridView3.DataBind();
        }

        protected void GridView4_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }


            BindGrid();
            DataTable dt = new DataTable();
            dt = Getdata4.Copy();
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GridView4.DataSource = sortedView;
            GridView4.DataBind();
        }

        protected void btnBuildingConstructionCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnProductionCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuildingapprovalCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnPossessionCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnLeaseCancel_Click(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)GridView2.HeaderRow.FindControl("chkHeader");

            foreach (GridViewRow row in GridView2.Rows)

            {

                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");

                if (chckheader.Checked == true)

                {
                    chkRow.Checked = true;
                }
                else

                {
                    chkRow.Checked = false;
                }

            }

        }
    }
}