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
    public partial class IAServiceApplicantDetails : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string RegionalOffice;
        string Type;
        string ServiceTimeLines;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {

                RegionalOffice = Request.QueryString["RegionalOffice"];
                Type = Request.QueryString["ReportType"];
                ServiceTimeLines= Request.QueryString["ServiceTimeLine"];
                BindServiceRequestGrid();
            }
        }
        private void BindServiceRequestGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                objServiceTimelinesBEL.RegionalOffice = RegionalOffice;
                objServiceTimelinesBEL.ReportType = Type;
                objServiceTimelinesBEL.ServiceTimeLines = ServiceTimeLines;
                ds = objServiceTimelinesBLL.GetListOfAllIAApplictionsDetails(objServiceTimelinesBEL);

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
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