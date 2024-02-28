using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class AllotteeReservationMoneyPayOld : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        public string ServiceReqNo;
        public string IAName;
        public string PlotNo;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReqNo = Request.QueryString["ServiceReqNo"];
            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();


            }

            if (ServiceReqNo != null)
            {
                if (ServiceReqNo.Length > 0)
                {
                    Filter_Div.Visible = false;
                    BindAllotteeRecord();
                    GetApplicantDetails();
                }

            }
            else
            {
                Filter_Div.Visible = true;
            }
        }


        private void BindAllotteeRecord()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotteeRecordToBind(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string IAID = dt.Rows[0][0].ToString();
                    PlotNo = dt.Rows[0][1].ToString();
                    IAName = dt.Rows[0][2].ToString();
                  
                    //radioByPlotNo.Checked = true;
                    //drpIndusrialArea.SelectedValue = IAID;

                    //drpIndusrialArea_SelectedIndexChanged(null, null);
                    //drpPlotNo.SelectedValue = PlotNo.Trim();

                //    drpPlotNo_SelectedIndexChanged(null, null);

                }

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

        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetailSelected(objServiceTimelinesBEL);
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
            string Paid = "";
            try
            {
                if (ServiceReqNo == null)
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
                }
                else
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = IAName.Trim();
                    objServiceTimelinesBEL.PlotNo = PlotNo.Trim();
                }

                ds = objServiceTimelinesBLL.GetDetailsWithReservationMoney(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt1.Rows.Count > 0)
                {
                    Paid = dt1.Rows[0]["Paid"].ToString();

                }

                if (dt.Rows.Count > 0)
                {
                    string Days = dt.Rows[0]["DateDiff"].ToString();
                    string prevrate = dt.Rows[0]["PrevRate"].ToString();
                    string currentrate = dt.Rows[0]["CurrentRate"].ToString();


                    if (Paid == "True")
                    {
                        Div1.Visible = true;
                        lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                        lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                        lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
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
                        if (Convert.ToInt32(Days) <= 60)
                        {

                            if (Convert.ToInt32(Days) <= 30)
                            {
                                Div1.Visible = true;
                                lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                                lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                                lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
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
                                if (prevrate == currentrate)
                                {
                                    Div1.Visible = true;
                                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                                    lblPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();
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
                                    div2.Visible = false;
                                    Div1.Visible = false;
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('You are not eligible for this service as rates are changed');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            div2.Visible = false;
                            Div1.Visible = false;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('You are not eligible for this service as your servicetimeline is passed. Kindly contact regional office');", true);
                            return;
                        }
                    }
                }
                else
                {
                    div2.Visible = false;
                    Div1.Visible = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Records are not found kindly contact regional office');", true);
                    return;
                }
                if (dt1.Rows.Count > 0)
                {
                    div2.Visible = true;
                    lblServiceRefNo.Text = dt1.Rows[0]["ServiceRefNo"].ToString();
                    lblAmount.Text = dt1.Rows[0]["ReservationAmount"].ToString();
                    lblReservationMoneyDueDate.Text = dt1.Rows[0]["ReservationMoneydueDate"].ToString();
                    lblPaymentStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                    lblTransactionAmount.Text = dt1.Rows[0]["TransactionAmount"].ToString();
                    lblTransactionDate.Text = dt1.Rows[0]["TransactionDate"].ToString();
                    LblPaymentMode.Text = dt1.Rows[0]["PaymentMode"].ToString();
                    lblTransactionRefNo.Text = dt1.Rows[0]["TraID"].ToString();
                    lblStatus.Text = dt1.Rows[0]["PaymentStatus"].ToString();
                    if (lblTransactionRefNo.Text.Length > 0)
                    {
                        Tr2.Visible = true;
                    }
                    else
                    {
                        Tr2.Visible = false;
                    }
                    if (lblPaymentStatus.Text == "Completed")
                    {
                        tr3.Visible = true;
                        btnPay.Text = "Paid";
                        btnPay.Enabled = false;
                    }
                    else
                    {
                        tr3.Visible = false;
                        btnPay.Text = "Pay Now";
                        btnPay.Enabled = true;
                    }


                }
                if (dt2.Rows.Count > 0)
                {
                    decimal total = 0;
                    GridPayment.DataSource = dt2;
                    GridPayment.DataBind();
                    if (dt2.Rows[0]["Amount"].ToString().Length > 0)
                    {
                        total = dt2.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                    }
                    else
                    {
                        total = 0;
                    }
                    GridPayment.FooterRow.Cells[1].Text = "Total";
                    GridPayment.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridPayment.FooterRow.Cells[2].Text = total.ToString("N2");
                }
                else
                {
                    GridPayment.DataSource = null;
                    GridPayment.DataBind();
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
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                div2.Visible = false;
                Div1.Visible = false;
                ds = objServiceTimelinesBLL.ListOfPlotForReservationMoney(objServiceTimelinesBEL);
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
            String js = "window.open('DocViewerDemand.aspx?DemandID=" + lblServiceRefNo.Text.Trim() + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerDemand.aspx", js, true);
        }

        //protected void btnPay_Click(object sender, EventArgs e)
        //{
        //    decimal TotalCharges;
        //    DataSet dsR = new DataSet();
        //    DataTable dt_Fee = new DataTable();

        //    GeneralMethod gm = new GeneralMethod();
        //    string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(lblServiceRefNo.Text, "UPSIDC");

        //    if (TransactionId_UPSIDC == "Failed")
        //    {
        //        string Message = "Failed In Processing";
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
        //    }
        //    else
        //    {
        //        dsR = objServiceTimelinesBLL.GetReservationAmount(lblServiceRefNo.Text);

        //        if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
        //        if (dt_Fee.Rows.Count > 0)
        //        {

        //            try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

        //            gm = new GeneralMethod();
        //            string PaymentGetwayURL = gm.SendToPaymentGetwayHDFC(TotalCharges, TransactionId_UPSIDC, lblServiceRefNo.Text, "Reservation Money", lblAllotteeName.Text, lblEmail.Text, lblPhoneNo.Text);

        //            if (PaymentGetwayURL == "Failed")
        //            {

        //                string Message = "Errro Ocured In Processing !";

        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
        //            }
        //            else
        //            {
        //                Response.Redirect(PaymentGetwayURL);
        //            }
        //        }
        //    }
        //}

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            String js = "window.open('ReservationMoneyPaymentAck.aspx?ServiceReqNo=" + lblServiceRefNo.Text.Trim() + "&TraId=" + lblTransactionRefNo.Text + "', '_blank');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReservationMoneyPaymentAck.aspx", js, true);
        }
    }


}