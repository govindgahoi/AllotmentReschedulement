using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class AllotteeDemandPay : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindIndustrialAreaDetail();
            }
        }

        private void bindIndustrialAreaDetail()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "Id";
                drpIndusrialArea.DataBind();
                drpIndusrialArea.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();
        }

        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                if (radioByAllotmentNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtServiceReqNo.Text;
                    objServiceTimelinesBEL.IAName = "";
                    objServiceTimelinesBEL.PlotNo = "";

                }

                if (radioByPlotNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
                }

                ds = objServiceTimelinesBLL.GetDetailsWithDemand(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    Div1.Visible = true;
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblLetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblProduct.Text = dt.Rows[0]["IndustryType"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblAllotmentDate.Text = dt.Rows[0]["AllottmentDate"].ToString();




                }
                else
                {
                    Div1.Visible = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Record Exist');", true);
                    return;
                }
                if (dt1.Rows.Count > 0)
                {
                    div2.Visible = true;
                    lblAmount.Text = dt1.Rows[0]["DueAmount"].ToString();
                    lblDemandNo.Text = dt1.Rows[0]["DemandNo"].ToString();
                    lblDemandDate.Text = dt1.Rows[0]["GeneratedDate"].ToString();
                    lblDueDate.Text = dt1.Rows[0]["DueDate"].ToString();
                    lblDemandID.Text = dt1.Rows[0]["ID"].ToString();
                    lblTransactionID.Text = dt1.Rows[0]["TransactionId"].ToString();

                    lblPaymentStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                    lblTransactionDate.Text = dt1.Rows[0]["TransactionDate"].ToString();
                    lblTransactionAmount.Text = dt1.Rows[0]["TransactionAmount"].ToString();
                    lblTransactionRefNo.Text = dt1.Rows[0]["EazypayRefNo"].ToString();
                    LblPaymentMode.Text = dt1.Rows[0]["PaymentMode"].ToString();
                    lblStatus.Text = dt1.Rows[0]["PayStatus"].ToString();
                    string URN = dt1.Rows[0]["URNNumber"].ToString();



                    if (LblPaymentMode.Text == "NEFT_RTGS")
                    {
                        Tr3.Visible = true;
                    }
                    else
                    {
                        Tr3.Visible = false;
                    }

                    if (URN.Length > 0)
                    {

                        txtUTRNo.Text = dt1.Rows[0]["URNNumber"].ToString();
                        txtBankName.Text = dt1.Rows[0]["BankName"].ToString();
                        txtPaymentDate.Text = dt1.Rows[0]["PaymentDate"].ToString();
                        btnUpdateURN.Text = "Already Updated";
                        btnUpdateURN.Enabled = false;
                        tr4.Visible = true;
                    }
                    else
                    {
                        tr4.Visible = false;
                    }

                    if (lblTransactionRefNo.Text.Length > 0)
                    {
                        Tr1.Visible = true;
                        Tr2.Visible = true;
                    }
                    else
                    {
                        Tr1.Visible = false;
                        Tr2.Visible = false;
                    }

                    if (lblStatus.Text == "Completed")
                    {
                        btnPay.Enabled = false;
                        btnPay.Text = "Paid";
                    }
                }
                else
                {
                    div2.Visible = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Contact Your Concerning Regional Office For Uploading Your Demand Note');", true);
                    return;
                }
                if (dt2.Rows.Count > 0)
                {
                    GridPayment.DataSource = dt2;
                    GridPayment.DataBind();

                    decimal total = dt2.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                    GridPayment.FooterRow.Cells[1].Text = "Total";
                    GridPayment.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridPayment.FooterRow.Cells[2].Text = total.ToString("N2");
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void radioByPlotNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = true;
            DivFilterLetter.Visible = false;

        }

        protected void radioByAllotmentNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = false;
            DivFilterLetter.Visible = true;
        }

        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForNotices(objServiceTimelinesBEL);
                drpPlotNo.DataSource = ds;
                drpPlotNo.DataTextField = "PlotNumber";
                drpPlotNo.DataValueField = "PlotNumber";
                drpPlotNo.DataBind();
                drpPlotNo.Items.Insert(0, new ListItem("--Select--", ""));



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetApplicantDetails();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String js = "window.open('DocViewerDemand.aspx?DemandID=" + lblDemandID.Text.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerDemand.aspx", js, true);
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            decimal TotalCharges;
            DataSet dsR = new DataSet();
            DataTable dt_Fee = new DataTable();


            GeneralMethod gm = new GeneralMethod();
            string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGeteway(lblDemandNo.Text, "UPSIDC");


            if (TransactionId_UPSIDC == "Failed")
            {
                string Message = "Failed In Processing";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

            }
            else
            {
                dsR = objServiceTimelinesBLL.GetDemandPayAmount(lblDemandNo.Text);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {

                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(DueAmount)", string.Empty)); } catch { TotalCharges = 0; }

                    gm = new GeneralMethod();
                    string PaymentGetwayURL = gm.SendToPaymentGetway(TotalCharges, TransactionId_UPSIDC, lblDemandNo.Text, "Demand Note", lblAllotteeName.Text);

                    if (PaymentGetwayURL == "Failed")
                    {

                        string Message = "Errro Ocured In Processing !";

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    }
                    else
                    {
                        Response.Redirect(PaymentGetwayURL);
                    }
                }
            }
        }

        protected void btnUpdateURN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUTRNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide URN No');", true);
                    return;
                }
                if (txtBankName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Bank Name');", true);
                    return;
                }

                GeneralMethod gm = new GeneralMethod();
                if (gm.ValidateDate(txtPaymentDate.Text))
                {




                    objServiceTimelinesBEL.ServiceRequestNO = lblDemandNo.Text.Trim();
                    objServiceTimelinesBEL.TranID = lblTransactionID.Text.Trim();
                    objServiceTimelinesBEL.ChallanDate = Convert.ToDateTime(lblTransactionDate.Text);

                    objServiceTimelinesBEL.PayTrans_trn_amt = lblTransactionAmount.Text;
                    objServiceTimelinesBEL.URNNo = txtUTRNo.Text;
                    string date_to_be = DateTime.ParseExact(txtPaymentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.PayDate = Convert.ToDateTime(date_to_be);
                    objServiceTimelinesBEL.BankName = txtBankName.Text;

                    int result = objServiceTimelinesBLL.UpdateURN(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "AlertRedirectPaymentDemand('" + lblDemandNo.Text + "','" + lblTransactionID.Text + "');", true);

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Not Updated');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Invalid Payment Date Format');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            String js = "window.open('DemadPaymentAck.aspx?ServiceReqNo=" + lblDemandNo.Text.Trim() + "&TraId=" + lblTransactionID.Text + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DemadPaymentAck.aspx", js, true);
        }
    }


}