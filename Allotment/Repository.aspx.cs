using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class Repository : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        string allotmentNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            allotmentNo = Session["UserName"].ToString();
            if (!Page.IsPostBack)
            {
                BindGridView();
                //  BindDemandNoticeGridView();
            }
        }



        public void BindGridView()
        {

            SqlCommand cmd = new SqlCommand(@"SELECT  A.[ServiceId], B.ServiceTimeLinesActivity, A.[ServiceRequestNo], A.CreatedOn,
                                                      A.[Document],  A.[ContentType]
                                                FROM [dbo].[Repository] A, [dbo].[ServiceTimeLines] B
                                                where A.[AllotmentLetterNo] = '" + allotmentNo + @"' AND
                                                ISNULL(A.[IsActive], 0) = 1    AND
                                                A.ServiceId = B.[ServiceTimeLinesID]   ", con);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);


            if (ds.Tables[0].Rows.Count > 0)
            {
                All_Repository.DataSource = ds.Tables[0];
                All_Repository.DataBind();
            }





            //SqlCommand cmd = new SqlCommand("get_repositories '" + allotmentNo + "'", con);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    AllotmentGrid.DataSource = ds.Tables[0];
            //    AllotmentGrid.DataBind();
            //}
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    BuildingGrid.DataSource = ds.Tables[1];
            //    BuildingGrid.DataBind();
            //}



        }





        protected void All_Repository_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }




        public void BindDemandNoticeGridView()
        {


            try
            {
                SqlCommand cmd = new SqlCommand("GetRepository_SP '" + allotmentNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtDoc = ds.Tables[0];
                    GridView2.DataSource = dtDoc;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtDoc1 = ds.Tables[1];
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataTable dtDoc2 = ds.Tables[2];
                    GridView3.DataSource = dtDoc2;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataTable dtDoc3 = ds.Tables[3];
                    GridView4.DataSource = dtDoc3;
                    GridView4.DataBind();
                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "selectDocument")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                int rowid = Convert.ToInt32(commandArgs[0]);
                string allotmentid = commandArgs[1];
                try
                {
                    SqlCommand cmd = new SqlCommand("[GetRepositoryDoc_SP] " + rowid + ", '" + allotmentid + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }



        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "selectDocument")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                int rowid = Convert.ToInt32(commandArgs[0]);
                string allotmentid = commandArgs[1];
                try
                {
                    SqlCommand cmd = new SqlCommand("[GetRepositoryDoc_SP] " + rowid + ", '" + allotmentid + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }



        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "selectDocument")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                int rowid = Convert.ToInt32(commandArgs[0]);
                string allotmentid = commandArgs[1];
                try
                {
                    SqlCommand cmd = new SqlCommand("[GetRepositoryDoc_SP] " + rowid + ", '" + allotmentid + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }



        }
        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "selectDocument")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                int rowid = Convert.ToInt32(commandArgs[0]);
                string allotmentid = commandArgs[1];
                try
                {
                    SqlCommand cmd = new SqlCommand("[GetRepositoryDoc_SP] " + rowid + ", '" + allotmentid + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }



        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }
        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Document"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "inline; filename="
                + dt.Rows[0]["FileName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindDemandNoticeGridView();

        }
        protected void OnPageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDemandNoticeGridView();

        }
        protected void OnPageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            BindDemandNoticeGridView();

        }
        protected void OnPageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            BindDemandNoticeGridView();

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lbView");
                linkButton.Attributes.Add("target", "_blank");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lbView");
                linkButton.Attributes.Add("target", "_blank");
            }
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lbView");
                linkButton.Attributes.Add("target", "_blank");
            }
        }
        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lbView");
                linkButton.Attributes.Add("target", "_blank");
            }
        }


    }
}