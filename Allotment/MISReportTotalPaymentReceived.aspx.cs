using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class MISReportTotalPaymentReceived : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (!IsPostBack)
                {

                    UserSpecificBinding();

                }

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

        }
        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--ALL--", "All"));
               
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }
      
        protected void AllGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = e.Row.Cells[2].Text.Trim();
                var arr = value.Split('/');
                string service = arr[1].ToString();
                if (service == "1000")
                {                 
                    e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"NewAssessmentUnderProcess.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");
                }
                else if (service == "1001")
                {
                   e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"LeaseDeedAssessmentView.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");                   
                }
                else if (service == "1")
                {
                    e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"BuildingPlanAssessmentView.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");
                }
                else if (service == "1002" || service == "1003" || service == "1004" || service == "1005" || service == "1006" || service == "1007" || service == "1008" || service == "1009" || service == "1010" || service == "1011" || service == "4" || service == "1012" || service == "1013" || service == "1014" || service == "1017" || service == "1021" || service == "1023" || service == "1024" || service == "1025" || service == "1026")
                {
                    
                    e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"IAServicesAssessmentView.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");
                }
                else if (service == "200")
                {
                    e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"AllotteeReservationMoneyPayNMSWP.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");
                }
                else if (service == "1028")
                {
                    e.Row.Cells[2].Text = Convert.ToString("<a target='_blank' href=\"IACurrentDues.aspx?ServiceReqNo=" + value + "\">" + value + "</a>");
                }

            }
        }
        private void BindServiceRequestGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
                if (txtTransactionFromDate.Text == "")
                {
                    objServiceTimelinesBEL.FromDatetime = null;
                }
                else
                {
                    string FromDate = DateTime.ParseExact(txtTransactionFromDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.FromDatetime = Convert.ToDateTime(FromDate);

                }
                if (txtTransactionToDate.Text == "")
                {
                    objServiceTimelinesBEL.ToDatetime = null;
                }
                else
                {
                    string ToDate = DateTime.ParseExact(txtTransactionToDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.ToDatetime = Convert.ToDateTime(ToDate);
                }
               
                ds = objServiceTimelinesBLL.GetListOfTotalFeeReceived(objServiceTimelinesBEL);


                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                     
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
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



    
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
        }
    }
}