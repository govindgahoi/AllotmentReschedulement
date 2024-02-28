using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class DuesHistory : System.Web.UI.Page
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
                GetPayHistory(allotmentNo);
                BindDemandNoticeGridView();
            }
        }





        public void BindDemandNoticeGridView()
        {


            try
            {
                SqlCommand cmd = new SqlCommand("GetAllotteeTransaction_SP '" + allotmentNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtDoc = ds.Tables[0];
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
                // Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "selectDocument")
            {


                int rowid = Convert.ToInt32(e.CommandArgument);

                try
                {
                    SqlCommand cmd = new SqlCommand("GetAllotteeTransactionDetails_SP " + rowid + " ", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable objdt = ds.Tables[0];
                    if (objdt.Rows.Count > 0)
                    {
                        TransationDetailGrid.DataSource = objdt;
                        TransationDetailGrid.DataBind();

                    }
                    else
                    {
                        TransationDetailGrid.DataSource = null;
                        TransationDetailGrid.DataBind();
                    }

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowGroups();", true);
                }
                catch (Exception ex)
                {
                    //        Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "ViewNotice")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string TransactionId = commandArgs[0];
                string AllotteeId = commandArgs[1];

                string pageurl = "DemandNotice1.aspx ? ID = " + TransactionId + " & AllotteeId = " + AllotteeId;
                string script = "window.open('" + pageurl + "','')";
                Response.Redirect("~/DemandNotice1.aspx?ID=" + TransactionId + "&AllotteeId=" + AllotteeId);


            }



        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }

        //private void download(DataTable dt)
        //{
        //    try
        //    {
        //        Byte[] bytes = (Byte[])dt.Rows[0]["DemandNotice"];
        //        Response.Buffer = true;
        //        Response.Charset = "";
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.ContentType = dt.Rows[0]["contentType"].ToString();
        //        Response.AddHeader("content-disposition", "inline; filename="
        //        + dt.Rows[0]["FileName"].ToString());
        //        Response.BinaryWrite(bytes);
        //        Response.Flush();
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void GetPayHistory(string allotementNo)
        {
            SqlCommand cmd = new SqlCommand("spc_GetAlloteeedashboardDetails '" + allotementNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt1 = ds.Tables[5];
            AllotteePaymentGrid.DataSource = dt1; AllotteePaymentGrid.DataBind();

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindDemandNoticeGridView();

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //Label lbl = (Label)e.Row.FindControl("lblstatus");
                //if ( lbl.Text == "False")
                //{
                //    e.Row.FindControl("lblpay").Visible = true;
                //}else
                //{
                //    e.Row.FindControl("lblpay").Visible = false;
                //}

            }
        }
    }
}