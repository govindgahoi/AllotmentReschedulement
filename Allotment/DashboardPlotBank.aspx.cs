using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class DashboardPlotBank : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {


            #region "Create and Initialize objects "
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            #endregion


            if (!IsPostBack)
            {
                try
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string UserName = _objLoginInfo.userName;
                    GetIndustrialAreaDetailsHODashboard();



                }
                catch
                {
                    Response.Redirect("/default.aspx");
                }

            }


        }

        public void GetIndustrialAreaDetailsHODashboard()
        {


            DataSet ds = new DataSet();

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            decimal subTotalArea = 0;
            lblIndustrial.Text = "0.00";
            lblCommercial.Text = "0.00";
            lblInstitutional.Text = "0.00";
            lblFacilitiesOthers.Text = "0.00";
            lblGreenZone.Text = "0.00";
            lblResidential.Text = "0.00";



            try
            {

                ds = objServiceTimelinesBLL.GetIndustrialAreaDetailsHODashboard();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata = ds.Tables[0];
                    subTotalArea = Convert.ToDecimal(Getdata.Compute("SUM(PLOTAREA)", string.Empty));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[1];
                    //subTotalArea = Convert.ToDecimal(Getdata.Compute("SUM(PLOTAREA)", string.Empty));
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    Getdata2 = ds.Tables[2];
                    //subTotalArea = Convert.ToDecimal(Getdata.Compute("SUM(PLOTAREA)", string.Empty));
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    Getdata3 = ds.Tables[3];

                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    Getdata4 = ds.Tables[4];

                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    Getdata5 = ds.Tables[5];

                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    Getdata6 = ds.Tables[6];

                }

                if (ds.Tables[0].Rows.Count > 0)
                {


                    foreach (DataRow dr in Getdata.Rows)
                    {

                        int rowIndex = (int)Getdata.Rows.IndexOf(dr);

                        if (dr[2].ToString() == "Industrial") { lblIndustrial.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                        if (dr[2].ToString() == "Commercial") { lblCommercial.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                        if (dr[2].ToString() == "Institutional") { lblInstitutional.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                        if (dr[2].ToString() == "Facilities") { lblFacilitiesOthers.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                        if (dr[2].ToString() == "Green Zone") { lblGreenZone.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                        if (dr[2].ToString() == "Residential") { lblResidential.Text = Getdata.Rows[rowIndex]["PLOTAREA"].ToString(); }
                    }

                    lblgtotal.Text = subTotalArea.ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    grtindview.DataSource = Getdata1;
                    grtindview.DataBind();


                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    GridPlotSummary.DataSource = Getdata2;
                    GridPlotSummary.DataBind();


                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    GridViewroPlotSummary.DataSource = Getdata3;
                    GridViewroPlotSummary.DataBind();


                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    GridViewplots.DataSource = Getdata4;
                    GridViewplots.DataBind();


                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    GridViewadv.DataSource = Getdata5;
                    GridViewadv.DataBind();


                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    // var getname=Getdata1.Select(X=>X.RegionalOffice)
                    GridViewadvdetails.DataSource = Getdata6;
                    GridViewadvdetails.DataBind();


                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }


        }

        private DataTable Getdata
        {
            get; set;
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
        private DataTable Getdata6
        {
            get; set;
        }

        protected void grtindview_DataBound(object sender, EventArgs e)
        {
            //Get the target row
            GridViewRow IndustrialGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            //Build the cell to be splitted             
            TableHeaderCell ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Regional Office",
                RowSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);


            //Build the cell to be splitted             
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Industrial Area",
                RowSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);



            //Build the cell to be splitted             
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Industrial",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);










            //Build the cell to be splitted            
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Residential",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);


            //Build the cell to be splitted            
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Commercial",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);

            //Build the cell to be splitted            
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Institutional",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);


            //Build the cell to be splitted            
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Facilities",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);


            //Build the cell to be splitted            
            ThisHeaderCell = new TableHeaderCell()
            {
                Text = "Green Zone",
                ColumnSpan = 2
            };

            //Add the above cell to the target row
            IndustrialGridViewRow.Controls.Add(ThisHeaderCell);

            //Add the target row to the grid
            grtindview.HeaderRow.Parent.Controls.AddAt(0, IndustrialGridViewRow);
        }

        protected void grtindview_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
            }
        }
    }
}




