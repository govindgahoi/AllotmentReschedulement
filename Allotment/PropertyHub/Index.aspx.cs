using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Data.SqlClient;
using System.Data;

namespace Allotment.PropertyHub
{
    public partial class Index : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        Classes.Class1 cs = new Classes.Class1();
        DataTable table = new DataTable();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DdlSectorBind();
                DdldistictBind();
            }
            expoExcle.Visible = false;
            ddlSelPage.Visible = false;
            hdrData.Visible = false;
        }

        string query = string.Empty;
        //string plots = string.Empty;
        public void BindGrid()
        {
            grdPlotData.PageSize = Convert.ToInt16(ddlSelPage.SelectedItem.Text);
            if (ddlpraposedSector.SelectedIndex == 0)           //--For Sector
            {
                sector = null;
            }
            else
            {
                sector = ddlpraposedSector.SelectedValue.ToString();
            }

            if (ddldistrict.SelectedIndex == 0)                 //--For District/RegionalOffice
            {
                district = null;
            }
            else
            {
                district = ddldistrict.SelectedItem.ToString();
            }


            if (ddlPlotSize.SelectedIndex == 0)                 //--For Plot Size
            {
                plotsize = null;
            }
            else if (ddlPlotSize.SelectedIndex == 1)
            {
                plotsize = "and PlotArea between 200 and 1000 ";
            }
            else if (ddlPlotSize.SelectedIndex == 2)
            {
                plotsize = "and PlotArea between 1000 and 2000 ";
            }
            else if (ddlPlotSize.SelectedIndex == 3)
            {
                plotsize = "and PlotArea between 2000 and 5000 ";
            }
            else if (ddlPlotSize.SelectedIndex == 4)
            {
                plotsize = "and PlotArea  between 5000 and 10000 ";
            }
            else if (ddlPlotSize.SelectedIndex == 5)
            {
                plotsize = "and PlotArea > 10000 ";
            }

            if (ddlCostPrice.SelectedIndex == 0)                        //--For Cost Price
            {
                plotcost = null;
            }
            else if (ddlCostPrice.SelectedIndex == 1)
            {
                plotcost = "AND(Master_IARates.RateofPlot * PlotMaster.PlotArea) between 1000000 and 10000000 ";
            }
            else if (ddlCostPrice.SelectedIndex == 2)
            {
                plotcost = "AND(Master_IARates.RateofPlot * PlotMaster.PlotArea) between 10000000 and 100000000 ";
            }
            else if (ddlCostPrice.SelectedIndex == 3)
            {
                plotcost = "AND(Master_IARates.RateofPlot * PlotMaster.PlotArea) between 100000000 and 500000000 ";
            }
            else if (ddlCostPrice.SelectedIndex == 4)
            {
                plotcost = "AND(Master_IARates.RateofPlot * PlotMaster.PlotArea) between 500000000 and 1000000000 ";
            }
            else if (ddlCostPrice.SelectedIndex == 5)
            {
                plotcost = "AND(Master_IARates.RateofPlot * PlotMaster.PlotArea) > 1000000000 ";
            }

            //query = "select PlotMaster.IAId,PlotNumber,IndustrialArea.IARatePerSqmt,PlotArea,RegionalOffice,RegionName,IAName,IndustriesAllowed, TotalLandAcquired,TotIALandForAllotment,Master_IARates.RateofPlot*PlotMaster.PlotArea as TotalCost from PlotMaster join IndustrialArea on PlotMaster.IAId=IndustrialArea.Id Join Master_IARates on Master_IARates.IAId=IndustrialArea.Id where RegionalOffice = '" + district + "' and(EXISTS(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "')) " + plotsize + plotcost + "";
            
          //  query = "select IndustrialArea.RegionalOffice,PlotMaster.IAId,IndustrialArea.IARatePerSqmt, PlotNumber,PlotArea,RegionalOffice,RegionName,(SELECT IndustrialClassificationName from Industrial_Classifications WHERE ClassificationID = '" + sector+"')As IndustrialClassificationName , IAName,IndustriesAllowed, TotalLandAcquired,TotIALandForAllotment,Master_IARates.RateofPlot*PlotMaster.PlotArea as TotalCost from PlotMaster join IndustrialArea on PlotMaster.IAId=IndustrialArea.Id Join Master_IARates on Master_IARates.IAId=IndustrialArea.Id join Industrial_Classifications on Industrial_Classifications.ClassificationID=(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '"+sector+"') where Plotmaster.IsActive='1' and RegionalOffice = '" + district + "' and(EXISTS(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "')) " + plotsize + plotcost + "";


            query = "select IndustrialArea.RegionalOffice,PlotMaster.IAId,IndustrialArea.IARatePerSqmt, PlotNumber,PlotArea,(SELECT SUM(PlotArea) from PlotMaster) AS TotalSumArea,RegionalOffice,RegionName,(SELECT IndustrialClassificationName from Industrial_Classifications WHERE ClassificationID = '" + sector + "')As IndustrialClassificationName , IAName,IndustriesAllowed, TotalLandAcquired,TotIALandForAllotment,Master_IARates.RateofPlot*PlotMaster.PlotArea as TotalCost from PlotMaster join IndustrialArea on PlotMaster.IAId=IndustrialArea.Id Join Master_IARates on Master_IARates.IAId=IndustrialArea.Id join Industrial_Classifications on Industrial_Classifications.ClassificationID=(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "') where Master_IARates.RateID in (select  top 1 RateID from Master_IARates where IAId=IndustrialArea.Id order by RateID desc) and Plotmaster.status='1' and(EXISTS(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "')) ";

            if(ddldistrict.SelectedIndex!=0)
            {
                query += "and RegionalOffice = '" + district + "'";
                
            }
            if(ddlPlotSize.SelectedIndex!=0)
            {
                query += plotsize;
            }
            if(ddlCostPrice.SelectedIndex!=0)
            {
                query += plotcost;
            }
            if (sector == null)
            {
                cs.str = "SELECT ClassificationID FROM Industrial_Classifications ";
                dt = cs.GetDataTable(cs.str);
                if (dt.Rows.Count > 0)
                {
                    string str = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sector = dt.Rows[i][0].ToString();
                        if (str == "")
                        {
                            str = "select IndustrialArea.RegionalOffice,PlotMaster.IAId,IndustrialArea.IARatePerSqmt, PlotNumber,PlotArea,(SELECT SUM(PlotArea) from PlotMaster) AS TotalSumArea,RegionalOffice,RegionName,(SELECT IndustrialClassificationName from Industrial_Classifications WHERE ClassificationID = '" + sector + "')As IndustrialClassificationName , IAName,IndustriesAllowed, TotalLandAcquired,TotIALandForAllotment,Master_IARates.RateofPlot*PlotMaster.PlotArea as TotalCost from PlotMaster join IndustrialArea on PlotMaster.IAId=IndustrialArea.Id Join Master_IARates on Master_IARates.IAId=IndustrialArea.Id join Industrial_Classifications on Industrial_Classifications.ClassificationID=(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "') where Master_IARates.RateID in (select  top 1 RateID from Master_IARates where IAId=IndustrialArea.Id order by RateID desc) and Plotmaster.status='1' and(EXISTS(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "')) "+ plotsize + " "+plotcost+"";

                        }
                        else
                        {
                            str = str+ " Union " + "select IndustrialArea.RegionalOffice,PlotMaster.IAId,IndustrialArea.IARatePerSqmt, PlotNumber,PlotArea,(SELECT SUM(PlotArea) from PlotMaster) AS TotalSumArea,RegionalOffice,RegionName,(SELECT IndustrialClassificationName from Industrial_Classifications WHERE ClassificationID = '" + sector + "')As IndustrialClassificationName , IAName,IndustriesAllowed, TotalLandAcquired,TotIALandForAllotment,Master_IARates.RateofPlot*PlotMaster.PlotArea as TotalCost from PlotMaster join IndustrialArea on PlotMaster.IAId=IndustrialArea.Id Join Master_IARates on Master_IARates.IAId=IndustrialArea.Id join Industrial_Classifications on Industrial_Classifications.ClassificationID=(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "') where Master_IARates.RateID in (select  top 1 RateID from Master_IARates where IAId=IndustrialArea.Id order by RateID desc) and Plotmaster.status='1' and(EXISTS(SELECT TOP 1 1 FROM dbo.Split(',', IndustriesAllowed) WHERE Value = '" + sector + "')) " + plotsize + " " + plotcost + "";
                            
                        }
                       
                    }
                    if (str != "")
                    {
                        query = str;
                    }
                }


            }
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(table);
            grdPlotData.DataSource = table;
            grdPlotData.DataBind();

            if (table.Rows.Count == 0)
            {
                Response.Write("<script>alert('No Plots Found. Please change search criteria!')</script>");
            }
            else
            {
                expoExcle.Visible = true;
                ddlSelPage.Visible = true;
                hdrData.Visible = true;
                lblPlotsNo.Text = Convert.ToString(table.Rows.Count);
            }
        }


        string sector = "", district = "", plotsize = "", plotcost = "";
        protected void btnExplore_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Generated. Details: " + Ex.ToString());
            }
        }
        
        protected void grdPlotData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //BindGrid();
            grdPlotData.PageIndex = e.NewPageIndex;

            grdPlotData.PageSize = Convert.ToInt16(ddlSelPage.SelectedItem.Text);
            BindGrid();
        }

        protected void DdldistictBind()
        {
            string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string qry = "SELECT Id As a,RegionalOffice as b FROM( SELECT RowNum=ROW_number() OVER(PARTITION BY RegionalOffice ORDER BY ID),Id,RegionalOffice FROM [dbo].[IndustrialArea] WITH(NOLOCK)) t WHERE RowNum=1 ORDER BY RegionalOffice";
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddldistrict.DataSource = dt;
            ddldistrict.DataBind();
            ddldistrict.DataTextField = "b";
            ddldistrict.DataValueField = "a";
            ddldistrict.DataBind();
            ddldistrict.Items.Insert(0, new ListItem("--Select--"));
        }
        protected void DdlSectorBind()
        {
            string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string qry = "Select * from Industrial_Classifications order by IndustrialClassificationName ";
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlpraposedSector.DataSource = dt;
            ddlpraposedSector.DataBind();
            ddlpraposedSector.DataTextField = "IndustrialClassificationName";
            ddlpraposedSector.DataValueField = "ClassificationID";
            ddlpraposedSector.DataBind();
            ddlpraposedSector.Items.Insert(0, new ListItem("--Select--"));
        }


        protected void MyButtonClick1(object sender, System.EventArgs e)
        {
            //Get the button that raised the event
            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Redirect("https://gis.onlineupsidc.com/");
        }

        protected void MyButtonClick(object sender, System.EventArgs e)
        {
            //Get the button that raised the event
            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Redirect("http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx"); 
        }
    }
}