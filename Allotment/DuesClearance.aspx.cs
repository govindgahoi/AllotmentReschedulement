using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class DuesClearance : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
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

                UserSpecificBinding(UserName);

            }
        }
        protected void UserSpecificBinding(string UserName)
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
                ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));

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
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));

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
                ClearTextBoxes();
                GetDuesAndPayments();
            }
            catch
            {

            }



        }


        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {



            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForNotices(objServiceTimelinesBEL);
                ddlPlotNo.DataSource = ds;
                ddlPlotNo.DataTextField = "PlotNumber";
                ddlPlotNo.DataValueField = "PlotNumber";
                ddlPlotNo.DataBind();
                ddlPlotNo.Items.Insert(0, new ListItem("--Select--", "0"));
                ClearTextBoxes();
                GetDuesAndPayments();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnsavedues_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                objServiceTimelinesBEL.PlotNo = ddlPlotNo.SelectedValue.Trim();
                objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.TowardsPremium = float.Parse(txtDuesPremium.Text.Trim());
                objServiceTimelinesBEL.InterestOnPremium = float.Parse(txtDuesInterestOnPremium.Text.Trim());
                objServiceTimelinesBEL.MaintenanceCharge = float.Parse(txtDuesMaintenanceCharge.Text.Trim());
                objServiceTimelinesBEL.InterestOnMaintenanceCharge = float.Parse(txtDuesIntOnMaintenanceCharge.Text.Trim());
                objServiceTimelinesBEL.LeaseRent = float.Parse(txtDuesLeaseRent.Text.Trim());
                objServiceTimelinesBEL.GSTOnLeaseRent = float.Parse(txtDuesGSTOnLeaseRent.Text.Trim());
                objServiceTimelinesBEL.TimeExtensionFee = float.Parse(txtDuesTEF.Text.Trim());
                objServiceTimelinesBEL.InterestOnTimeExtension = float.Parse(txtDuesIntOnTEF.Text.Trim());
                objServiceTimelinesBEL.RemainingLeasePeriod = float.Parse(txtDuesLeasePeriod.Text.Trim());
                objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = UserName.Trim();





                retval = objServiceTimelinesBLL.InsertDuesAgainstPlot(objServiceTimelinesBEL);
                if (retval > 0)
                {

                    MessageBox1.ShowSuccess("Dues Saved Successfully");
                    GetDuesAndPayments();
                }
                else
                {
                    MessageBox1.ShowError("Error In Saving Dues");
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void ddlPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
            objServiceTimelinesBEL.IAName = (drpdwnIA.SelectedItem.Text.Trim());
            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetAllotteeAgainstPlot(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                        lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                        lblDateOFAllotment.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                        lblDateOfPossession.Text = dt.Rows[0]["DateOfPossession"].ToString();
                        lblLeasedeedDate.Text = dt.Rows[0]["LeaseDeedDate"].ToString();
                        lblAddress.Text = dt.Rows[0]["Address"].ToString();
                        lblEmailID.Text = dt.Rows[0]["Email"].ToString();
                        lblPhoneNo.Text = dt.Rows[0]["Phone"].ToString();
                        lblFirmConstitution.Text = dt.Rows[0]["FirmType"].ToString();
                        lblProduct.Text = dt.Rows[0]["Product"].ToString();
                        lblPanNo.Text = dt.Rows[0]["Email"].ToString();
                        lblCinNo.Text = dt.Rows[0]["Email"].ToString();
                        lblSignatoryName.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    }
                    else
                    {

                        lblAllotteeID.Text = "";
                    }
                }
                ClearTextBoxes();
                GetDuesAndPayments();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        private void GetDuesAndPayments()
        {

            objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetDuesAndPayment(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        DuesGrid.DataSource = dt;
                        DuesGrid.DataBind();
                    }
                    else
                    {

                        DuesGrid.DataSource = null;
                        DuesGrid.DataBind();
                    }

                    if (dt1.Rows.Count > 0)
                    {
                        PaymentGrid.DataSource = dt1;
                        PaymentGrid.DataBind();
                    }
                    else
                    {
                        PaymentGrid.DataSource = null;
                        PaymentGrid.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }




        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                objServiceTimelinesBEL.PlotNo = ddlPlotNo.SelectedValue.Trim();
                objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.TowardsPremium = float.Parse(txtPaymentPremium.Text.Trim());
                objServiceTimelinesBEL.InterestOnPremium = float.Parse(txtPaymentInterestOnPremium.Text.Trim());
                objServiceTimelinesBEL.MaintenanceCharge = float.Parse(txtPaymentMaintenanceCharge.Text.Trim());
                objServiceTimelinesBEL.InterestOnMaintenanceCharge = float.Parse(txtPaymentIntOnMaintenanceCharge.Text.Trim());
                objServiceTimelinesBEL.LeaseRent = float.Parse(txtPaymentLeaseRent.Text.Trim());
                objServiceTimelinesBEL.GSTOnLeaseRent = float.Parse(txtPaymentGSTOnLeaseRent.Text.Trim());
                objServiceTimelinesBEL.TimeExtensionFee = float.Parse(txtPaymentTEF.Text.Trim());
                objServiceTimelinesBEL.InterestOnTimeExtension = float.Parse(txtPaymentIntOnTEF.Text.Trim());
                objServiceTimelinesBEL.RemainingLeasePeriod = float.Parse(txtPaymentLeasePeriod.Text.Trim());
                objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = UserName.Trim();





                retval = objServiceTimelinesBLL.InsertPaymentAgainstPlot(objServiceTimelinesBEL);
                if (retval > 0)
                {

                    MessageBox1.ShowSuccess("Payments Saved Successfully");
                    GetDuesAndPayments();
                }
                else
                {
                    MessageBox1.ShowError("Error In Saving Payments");
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void DuesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DuesGrid.PageIndex = e.NewPageIndex;
            GetDuesAndPayments();
        }

        protected void DuesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {



                int index = Convert.ToInt32(e.CommandArgument);
                index = index % DuesGrid.PageSize;
                string DuesID = (DuesGrid.DataKeys[index].Values[0]).ToString();
                string TowardsPremium = (DuesGrid.DataKeys[index].Values[1]).ToString();
                string InterestOnPremium = (DuesGrid.DataKeys[index].Values[2]).ToString();
                string MaintenanceCharge = (DuesGrid.DataKeys[index].Values[3]).ToString();
                string InterestOnMaintenanceCharge = (DuesGrid.DataKeys[index].Values[4]).ToString();
                string LeaseRent = (DuesGrid.DataKeys[index].Values[5]).ToString();
                string GSTOnLeaseRent = (DuesGrid.DataKeys[index].Values[6]).ToString();
                string TimeExtensionFee = (DuesGrid.DataKeys[index].Values[7]).ToString();
                string InterestOnTimeExtension = (DuesGrid.DataKeys[index].Values[8]).ToString();
                string RemainingLeasePeriod = (DuesGrid.DataKeys[index].Values[9]).ToString();

                if (e.CommandName == "Process")
                {
                    txtDuesPremium.Text = TowardsPremium;
                    txtDuesInterestOnPremium.Text = InterestOnPremium;
                    txtDuesMaintenanceCharge.Text = MaintenanceCharge;
                    txtDuesIntOnMaintenanceCharge.Text = InterestOnMaintenanceCharge;
                    txtDuesLeaseRent.Text = LeaseRent;
                    txtDuesGSTOnLeaseRent.Text = GSTOnLeaseRent;
                    txtDuesTEF.Text = TimeExtensionFee;
                    txtDuesIntOnTEF.Text = InterestOnTimeExtension;
                    txtDuesLeasePeriod.Text = RemainingLeasePeriod;




                }

                if (e.CommandName == "DeleteDues")
                {
                    int retval = 0;

                    objServiceTimelinesBEL.DuesID = DuesID.Trim();
                    retval = objServiceTimelinesBLL.DeleteDuesAgainstPlot(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Dues Deleted Successfully");
                        GetDuesAndPayments();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Deleting Dues");
                        return;
                    }


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }

        protected void PaymentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PaymentGrid.PageIndex = e.NewPageIndex;
            GetDuesAndPayments();
        }

        protected void PaymentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {



                int index = Convert.ToInt32(e.CommandArgument);
                index = index % PaymentGrid.PageSize;
                string PaymentID = (PaymentGrid.DataKeys[index].Values[0]).ToString();
                string TowardsPremium = (PaymentGrid.DataKeys[index].Values[1]).ToString();
                string InterestOnPremium = (PaymentGrid.DataKeys[index].Values[2]).ToString();
                string MaintenanceCharge = (PaymentGrid.DataKeys[index].Values[3]).ToString();
                string InterestOnMaintenanceCharge = (PaymentGrid.DataKeys[index].Values[4]).ToString();
                string LeaseRent = (PaymentGrid.DataKeys[index].Values[5]).ToString();
                string GSTOnLeaseRent = (PaymentGrid.DataKeys[index].Values[6]).ToString();
                string TimeExtensionFee = (PaymentGrid.DataKeys[index].Values[7]).ToString();
                string InterestOnTimeExtension = (PaymentGrid.DataKeys[index].Values[8]).ToString();
                string RemainingLeasePeriod = (PaymentGrid.DataKeys[index].Values[9]).ToString();

                if (e.CommandName == "Process")
                {
                    txtPaymentPremium.Text = TowardsPremium;
                    txtPaymentInterestOnPremium.Text = InterestOnPremium;
                    txtPaymentMaintenanceCharge.Text = MaintenanceCharge;
                    txtPaymentIntOnMaintenanceCharge.Text = InterestOnMaintenanceCharge;
                    txtPaymentLeaseRent.Text = LeaseRent;
                    txtPaymentGSTOnLeaseRent.Text = GSTOnLeaseRent;
                    txtPaymentTEF.Text = TimeExtensionFee;
                    txtPaymentIntOnTEF.Text = InterestOnTimeExtension;
                    txtPaymentLeasePeriod.Text = RemainingLeasePeriod;




                }

                if (e.CommandName == "DeletePayment")
                {
                    int retval = 0;

                    objServiceTimelinesBEL.PaymentID = PaymentID.Trim();
                    retval = objServiceTimelinesBLL.DeletePaymentAgainstPlot(objServiceTimelinesBEL);
                    if (retval > 0)
                    {

                        MessageBox1.ShowSuccess("Payment Deleted Successfully");
                        GetDuesAndPayments();
                    }
                    else
                    {
                        MessageBox1.ShowError("Error In Deleting Payment");
                        return;
                    }


                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }


        private void ClearTextBoxes()
        {
            txtPaymentPremium.Text = "";
            txtPaymentInterestOnPremium.Text = "";
            txtPaymentMaintenanceCharge.Text = "";
            txtPaymentIntOnMaintenanceCharge.Text = "";
            txtPaymentLeaseRent.Text = "";
            txtPaymentGSTOnLeaseRent.Text = "";
            txtPaymentTEF.Text = "";
            txtPaymentIntOnTEF.Text = "";
            txtPaymentLeasePeriod.Text = "";

            txtDuesPremium.Text = "";
            txtDuesInterestOnPremium.Text = "";
            txtDuesMaintenanceCharge.Text = "";
            txtDuesIntOnMaintenanceCharge.Text = "";
            txtDuesLeaseRent.Text = "";
            txtDuesGSTOnLeaseRent.Text = "";
            txtDuesTEF.Text = "";
            txtDuesIntOnTEF.Text = "";
            txtDuesLeasePeriod.Text = "";

        }
    }
}