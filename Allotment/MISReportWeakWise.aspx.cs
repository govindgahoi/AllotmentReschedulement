using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Allotment
{
    public partial class MISReportWeakWise : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "",IAName="",Weakstart="",WeakEnd="";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
            IAName = Request.QueryString["IAName"];
            Weakstart = Request.QueryString["Weakstart"];
            WeakEnd = Request.QueryString["WeakEnd"];
            if (!IsPostBack)
            {

                BindServiceRequestGrid(); 

            }
        }
   
        protected void AllGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = e.Row.Cells[3].Text.Trim();
              
                
            }
        }
   
        private void BindServiceRequestGrid()
        {
            try
            {
                lblStartDate.Text = Weakstart;
                lblEndDate.Text = WeakEnd;
                DateTime WeakStartDate = Convert.ToDateTime(Weakstart).AddDays(0);
                DateTime WeakEndDate = Convert.ToDateTime(WeakEnd).AddDays(0);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("[GetAllLAMISWeakWise] '"+UserName+"'",con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = new DataTable();
               
                dt = ds.Tables[1];
                DataRow[] dr = dt.Select("IAName = '" + IAName + "' and FinalSubmitDate>='" + WeakStartDate + "' and FinalSubmitDate<='" + WeakEndDate + "'");
                DataTable dt1 = dr.CopyToDataTable();

                if (ds.Tables.Count > 0)
                {
                   
                    if (dt1.Rows.Count > 0)
                    {
                        AllGrid.DataSource = dt1;
                        AllGrid.DataBind();
                    }
                    else
                    {
                        AllGrid.DataSource = null;
                        AllGrid.DataBind();
                    }
                }
                else
                {
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }
  
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}