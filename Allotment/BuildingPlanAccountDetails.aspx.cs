using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{
    public partial class BuildingPlanAccountDetails : System.Web.UI.Page
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

                    UserSpecificBinding(UserName);

                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }
        protected void UserSpecificBinding(string UserName)
        {

            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetAllRegionalOffice(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--All--", "All"));
                bindDDLRegion(ddloffice.SelectedItem.Value, null);

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAregionalOfficeWise(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--All--", "All"));
                BindServiceRequestGrid();
                BindServiceRequestClearedGrid();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void Regional_Changed(object sender, EventArgs e)
        {
            try
            {

                bindDDLRegion(ddloffice.SelectedItem.Value, null);
                BindServiceRequestGrid();
                BindServiceRequestClearedGrid();


            }
            catch (Exception ex)
            {

            }
        }
        private void BindServiceRequestGrid()
        {
            objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
            objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.PaymentMode = (ddlPayMode.SelectedValue.Trim());

            objServiceTimelinesBEL.FromDate = txtTransactionFromDate.Text;
            objServiceTimelinesBEL.ToDate = txtTransactionToDate.Text;
            objServiceTimelinesBEL.searchText = txtSearch.Text;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfBuildingPlanAccountDetails(objServiceTimelinesBEL);
                ApplicationGrid.DataSource = ds;
                ApplicationGrid.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void BindServiceRequestClearedGrid()
        {
            objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
            objServiceTimelinesBEL.IndustrialArea = (drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.PaymentMode    = (ddlPayMode.SelectedValue.Trim());
            objServiceTimelinesBEL.FromDate       = txtTransactionFromDate.Text;
            objServiceTimelinesBEL.ToDate         = txtTransactionToDate.Text;
            objServiceTimelinesBEL.searchText     = txtSearch.Text;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfBuildingPlanAccountDetailsCleared(objServiceTimelinesBEL);
                ApplicationCleared.DataSource = ds;
                ApplicationCleared.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
            BindServiceRequestClearedGrid();
        }

        protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
            BindServiceRequestClearedGrid();
        }

        protected void ApplicationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Attributes.Add("onclick", "ShowPopupChange('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[11].Text) + "','Account Clearence','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[1].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[4].Text) + "','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[10].Text) + "'); return false;");
                e.Row.Cells[1].Attributes.Add("style",   "background: antiquewhite !important;width: 200px !important;cursor:pointer;");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceivedAmt.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Recieved Amount');", true);
                    return;
                }
                if (txtReceivedDate.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Recieval Date');", true);
                    return;
                }
                if(Convert.ToDecimal(txtBPAmount.Text)!= Convert.ToDecimal(txtReceivedAmt.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Amount Mismatch !!!');", true);

                    return;
                }

                GeneralMethod gm = new GeneralMethod();
                if (gm.ValidateDate(txtReceivedDate.Text))
                {
                    objServiceTimelinesBEL.ServiceRequestNO = change_text.Text.Trim();
                    objServiceTimelinesBEL.TranID = txtTransaction.Text.Trim();
                    objServiceTimelinesBEL.PayTrans_trn_amt = txtReceivedAmt.Text;
                    string date_to_be = DateTime.ParseExact(txtReceivedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.PayDate = Convert.ToDateTime(date_to_be);
                    int result = objServiceTimelinesBLL.UpdateApplicationAfterAccountClearenceBP(objServiceTimelinesBEL);
                    if (result > 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Verified Successfully');", true);
                        BindServiceRequestGrid();
                        BindServiceRequestClearedGrid();
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Not Updated');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Invalid Date Format');", true);

                    return;
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }

        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            BindServiceRequestGrid();
            BindServiceRequestClearedGrid();
        }




    }
}