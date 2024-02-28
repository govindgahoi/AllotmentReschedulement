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
    public partial class MISReportAllApplicationsWeakWise : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
            if (!IsPostBack)
            {

                BindServiceRequestGrid(); 

            }
        }
   
        protected void AllGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Value     = e.Row.Cells[5].Text.Trim();
                string WeakStart = e.Row.Cells[3].Text.Trim();
                string WeakEnd   = e.Row.Cells[4].Text.Trim();
                string IAName = e.Row.Cells[2].Text.Trim();

                e.Row.Cells[5].Text = Convert.ToString("<a target='_blank' href=\"MISReportWeakWise.aspx?WeakStart=" + WeakStart + "&WeakEnd="+WeakEnd+ "&IAName=" + IAName+"\">" + Value + "</a>");


            }
        }
   
        private void BindServiceRequestGrid()
        {
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("[GetAllLAMISWeakWise] '"+UserName+"'",con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (ds.Tables.Count > 0)
                {
                   
                    if (dt.Rows.Count > 0)
                    {
                        AllGrid.DataSource = dt;
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