using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class Allottee_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";


        public void Refesh(bool pIsOfficeCalled)
        {
            if (!pIsOfficeCalled)

                drpdwnIA.SelectedIndex = 0;
                //ddlArea.SelectedIndex = 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                this.RegisterPostBackControl();
               
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            string value = Session["AllotteeID"] as string;
            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["AllotteeID"].ToString().Length > 0)
                {
                    if (MultiView1.ActiveViewIndex == 3 || MultiView1.ActiveViewIndex == 10 || MultiView1.ActiveViewIndex == 4)
                    {
                        GetAllotteeDuesDetails();
                    }
                }
            }
            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["AllotteeID"].ToString().Length > 0)
                {
                    btn_first_save.Text = "Saved";
                    allotteeID.Text = Session["AllotteeID"].ToString();
                    btnNext.Enabled = true;
                }
                else { allotteeID.Text = ""; Session["AllotteeID"] = ""; }
            }
            else { allotteeID.Text = ""; Session["AllotteeID"] = ""; btnNext.Enabled = false; }

            allotteeID.Text = Session["AllotteeID"].ToString();

            if (allotteeID.Text == "" && MultiView1.ActiveViewIndex > 1 && MultiView1.ActiveViewIndex != 7 && MultiView1.ActiveViewIndex != 8)
            {
                MultiView1.ActiveViewIndex = 0;
                btn_first_save.Enabled = false;
                btn_first_save.Text = "Save";
                if (Conform_CheckBox_multiview_1.Checked)
                {
                    Conform_CheckBox_multiview_1.Checked = false;
                }
            }
            if (MultiView1.ActiveViewIndex == 0)
            {
                GetNewAllotteeDetails();
                Session["AllotteeID"] = "";
            }
            if (!IsPostBack)
            {
               
                DataTable temp_installment_details = new DataTable();
                temp_installment_details.TableName = "temp_installment_details";
                temp_installment_details.Columns.Add(new DataColumn("DueDateofInstallment", typeof(string)));
                temp_installment_details.Columns.Add(new DataColumn("InterestDue", typeof(decimal)));
                temp_installment_details.Columns.Add(new DataColumn("InterestDuewithout", typeof(string)));
                temp_installment_details.Columns.Add(new DataColumn("PremiumDue", typeof(string)));
                temp_installment_details.Columns.Add(new DataColumn("TotalAmount", typeof(string)));
                temp_installment_details.Columns.Add(new DataColumn("TotalAmountRebate", typeof(string)));

                ViewState["temp_installment_details"] = temp_installment_details;
                temp_installment_details_DataBind();

                DataTable temp_shareholder_details = new DataTable();
                temp_shareholder_details.TableName = "temp_shareholder_details";
                temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("EmailId", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("PhoneNo", typeof(string)));


                ViewState["temp_shareholder_details"] = temp_shareholder_details;
                temp_shareholder_details_DataBind();


                DataTable temp_trustee_details = new DataTable();
                temp_trustee_details.TableName = "temp_trustee_details";
                temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("EmailId", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_trustee_details"] = temp_trustee_details;
                temp_trustee_details_DataBind();


                DataTable temp_directors_details = new DataTable();
                temp_directors_details.TableName = "temp_trustee_details";
                temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("EmailId", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_directors_details"] = temp_directors_details;
                temp_director_details_DataBind();

                DataTable temp_partnership_details = new DataTable();
                temp_partnership_details.TableName = "temp_partnership_details";
                temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("EmailId", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("PhoneNo", typeof(string)));

                ViewState["temp_partnership_details"] = temp_partnership_details;
                temp_partnership_details_DataBind();


                DataTable temp_TEF_details = new DataTable();
                temp_TEF_details.TableName = "temp_TEF_details";
                temp_TEF_details.Columns.Add(new DataColumn("TEFRefferenceNumber", typeof(string)));
                temp_TEF_details.Columns.Add(new DataColumn("TEFApprovalDate", typeof(string)));
                temp_TEF_details.Columns.Add(new DataColumn("TEFPeriod", typeof(string)));
                temp_TEF_details.Columns.Add(new DataColumn("TEFFees", typeof(string)));


                ViewState["temp_TEF_details"] = temp_TEF_details;
                temp_TEF_details_DataBind();
                UserSpecificBinding();
                PollutionCategoryBinding();
                ViewState["Filter"] = "ALL";
                MultiView1.ActiveViewIndex = 0;
                SetInitialRow();
                //bindIndustrialAreaDetail();
                bindCompanytypeddl();
                GetNewAllotteeDetails();
                bindTypeOfIndustry();
                bindProductCategory();
                //bindPaymentRecived();
                //bind();
                //bindPaymentDetailswithAmount();
            }
        }
        #region "ADD NEW PAYMENT TAB "
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("PaymentReicvedDate", typeof(string)));
            dt.Columns.Add(new DataColumn("PaymentAmount", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("PaymentDescription", typeof(string)));//for TextBox value 

            dt.Columns.Add(new DataColumn("ModeOfPayment", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("EssueDate", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("DraftNo", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("TransactionNo", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("ChequeNo", typeof(string)));//for TextBox value 
            dt.Columns.Add(new DataColumn("BankName", typeof(string)));//for TextBox value 
            ViewState["CurrentTable"] = dt;

            gridviewpayment_DataBind();
        }

        static int indexOfL = 0;// the index of initial selected item
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;

            foreach (ListItem li in CommunicationModeChk.Items)
            {
                {
                    if (i != indexOfL && li.Selected)
                    {
                        indexOfL = i;
                        CommunicationModeChk.ClearSelection();
                        li.Selected = true;

                    }
                    i++;
                }
            }
            if (CommunicationModeChk.SelectedValue == "Email")
            {

                row1.Visible = true;
                row4.Visible = true;
            }
            else
            {
                row1.Visible = false;

            }
            if (CommunicationModeChk.SelectedValue == "Phone")
            {
                row2.Visible = true;
                row4.Visible = true;
            }
            else
            {
                row2.Visible = false;

            }
            if (CommunicationModeChk.SelectedValue == "Registered Post")
            {
                row3.Visible = true;
                row4.Visible = true;
            }
            else
            {
                row3.Visible = false;

            }
        }

        public void temp_TEF_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                TEFGrid.DataSource = dt;
                TEFGrid.DataBind();
                TEFGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                TEFGrid.DataSource = dt;
                TEFGrid.DataBind();
            }


        }
        protected void insert_TEF_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];


            string TEFReffrence = (TEFGrid.FooterRow.FindControl("txtTEFReff_insert") as TextBox).Text;
            string TEFApprovalDate_insert = (TEFGrid.FooterRow.FindControl("txtTEFApprovalDate_insert") as TextBox).Text;
            string TEFPeriod_insert = (TEFGrid.FooterRow.FindControl("drpdTEFPeriod") as DropDownList).SelectedValue.Trim();
            string TEFFees_insert = (TEFGrid.FooterRow.FindControl("txtTEFFees_insert") as TextBox).Text;

            if (TEFReffrence != "")
            {
                if (TEFReffrence != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["TEFRefferenceNumber"] = TEFReffrence;
                    dr["TEFApprovalDate"] = TEFApprovalDate_insert;
                    dr["TEFPeriod"] = TEFPeriod_insert;
                    dr["TEFFees"] = TEFFees_insert;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_TEF_details"] = dt;

                    temp_TEF_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
                return;
            }

        }
        protected void TEFDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_TEF_details"] = dt;

            dt.AcceptChanges();


            temp_TEF_details_DataBind();


        }

        public void temp_partnership_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
                PartnershipFirmGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
            }


        }
        protected void insert_Partnership_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];


            string Partnershipname = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert") as TextBox).Text;
            string partnershipper = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert") as TextBox).Text;
            string address = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert") as TextBox).Text;
            string email = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert") as TextBox).Text;
            string phone = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert") as TextBox).Text;


            if (Partnershipname != "")
            {
                if (partnershipper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["PartnerName"] = Partnershipname;
                    dr["PartnershipPer"] = partnershipper;
                    dr["Address"] = address;
                    dr["EmailId"] = email;
                    dr["PhoneNo"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_partnership_details"] = dt;

                    temp_partnership_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
                return;
            }

        }
        protected void PartnershipDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_partnership_details"] = dt;

            dt.AcceptChanges();


            temp_partnership_details_DataBind();


        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string PaymentReceivedDate = (gridviewpayment.FooterRow.FindControl("txtPaymentReceivedDate") as TextBox).Text;
            string PaymentIssueDate = (gridviewpayment.FooterRow.FindControl("txtPaymentIssueDate") as TextBox).Text;

            string Amount = (gridviewpayment.FooterRow.FindControl("txtAmount") as TextBox).Text;
            string Description = (gridviewpayment.FooterRow.FindControl("txtPaymentDescription") as TextBox).Text;
            string PaymentMode = (gridviewpayment.FooterRow.FindControl("drpdPaymentMode") as DropDownList).SelectedValue.Trim();

            string PaymentBank = (gridviewpayment.FooterRow.FindControl("txtPaymentBank") as TextBox).Text;
            string DraftNo = (gridviewpayment.FooterRow.FindControl("txtDraftNo") as TextBox).Text;
            string TransactionNo = (gridviewpayment.FooterRow.FindControl("txtTransactionNo") as TextBox).Text;
            string ChequeNo = (gridviewpayment.FooterRow.FindControl("txtChequeNo") as TextBox).Text;


            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                if (PaymentReceivedDate != "")
                {
                    DateTime dt3;
                    if (ValidateDate(PaymentReceivedDate))
                    {

                    }
                    else
                    {
                        txtLeaseDeed.Focus();
                        MessageBox1.ShowError("Invalid Payment Received Date ");

                        return;
                    }
                }
                if (PaymentIssueDate != "")
                {
                    DateTime dt3;
                    if (ValidateDate(PaymentIssueDate))
                    {

                    }
                    else
                    {
                        txtLeaseDeed.Focus();
                        MessageBox1.ShowError("Invalid Payment Issued Date ");

                        return;
                    }
                }

                objServiceTimelinesBEL.Action = 0;
                objServiceTimelinesBEL.AllotteeID = int.Parse(allotteeID.Text);


                string PaymentReceivedDate_str = DateTime.ParseExact(PaymentReceivedDate.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                string PaymentIssueDate_str = DateTime.ParseExact(PaymentIssueDate.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                //  objServiceTimelinesBEL.DateOfExecutionAgreement = Convert.ToDateTime((date_to_be));

                objServiceTimelinesBEL.PaymentReicvedDate = Convert.ToDateTime((PaymentReceivedDate_str));
                objServiceTimelinesBEL.PaymentIssueDate = Convert.ToDateTime((PaymentIssueDate_str));
                objServiceTimelinesBEL.PaymentAmount = float.Parse(Amount);
                objServiceTimelinesBEL.PaymentDescription = Description;
                objServiceTimelinesBEL.PaymentMode = PaymentMode;

                objServiceTimelinesBEL.PaymentBank = PaymentBank;
                objServiceTimelinesBEL.PaymentDraftNo = DraftNo;
                objServiceTimelinesBEL.PaymentTransactionNo = TransactionNo;
                objServiceTimelinesBEL.PaymentChequeNo = ChequeNo;


                objServiceTimelinesBEL.CreatedBy = UserName;
                objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                int retVal = objServiceTimelinesBLL.InsertUpdateAllottee_tblPaymentDetail(objServiceTimelinesBEL);
                if (retVal > 0)
                {


                    MessageBox1.ShowSuccess("Payment detail Updated/Inserted Successfully.");
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Allottee Payment details couldn't be saved');", true);

                }
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured11 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
            ///////////////////////   End Of Insert   ///////////////////////////// 



            GetAllAllotteeDetailsFilledById(int.Parse(allotteeID.Text));

        }

        protected void btnPaymentSave_Click(object sender, EventArgs e)
        {


            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                objServiceTimelinesBEL.Action = 0;
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());

                objServiceTimelinesBEL.RateofInterest = float.Parse(txtRateofInterest.Text.Trim());
                objServiceTimelinesBEL.RateatTimeAllotment = float.Parse(txtRateatTimeAllotment.Text.Trim());
                objServiceTimelinesBEL.RebateNonDefaulters = float.Parse(txtDefaulters.Text.Trim());
                objServiceTimelinesBEL.NoInstallments = float.Parse(txtInstallment.Text.Trim());
                objServiceTimelinesBEL.LocationCharges = float.Parse(txtLocationCharges.Text.Trim());
                objServiceTimelinesBEL.EarnestMoneyRate = float.Parse(txtMoneyRate.Text.Trim());
                objServiceTimelinesBEL.ReservationMoneyPaidwitin30days = float.Parse(txtReservationMoney.Text.Trim());
                objServiceTimelinesBEL.DemantNoticeDate1 = Convert.ToDateTime(txtDemantNoticeDate.Text.Trim());
                objServiceTimelinesBEL.DemantNoticeDate2 = Convert.ToDateTime(txtDemantNoticeDate2.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = UserName;
                objServiceTimelinesBEL.CreatedDate = DateTime.Now;


                int retVal = objServiceTimelinesBLL.InsertUpdateAllottee_tblPaymentHeader(objServiceTimelinesBEL);
                if (retVal > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Payment detail Updated/Inserted Successfully.');", true);

                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Allottee details couldn't be saved');", true);
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
            ///////////////////////   End Of Insert   ///////////////////////////// 





        }

        protected void LinkDelete_Click(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.Connection = con;
                string to_be_deleted_id = gridviewpayment.DataKeys[e.RowIndex].Value.ToString();


                command.CommandText = ("delete from tblPaymentDetail where Id = " + to_be_deleted_id + "");
                command.ExecuteNonQuery();


                GetAllAllotteeDetailsFilledById(int.Parse(allotteeID.Text));
                con.Close();
            }
            catch
            {
                string message = "Payment Not Deleted Error Occured ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }
        public void gridviewpayment_DataBind()
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count == 0)
            {

                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridviewpayment.DataSource = dt;
                gridviewpayment.DataBind();
                gridviewpayment.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {

            }
        }
        #endregion
        #region "Create and Wizard objects "

        private void ResetReadOnly()
        {

            txtProductManufactured.ReadOnly = false;

            txtTotalArea.ReadOnly = false;
            txtLeaseDeed.ReadOnly = false;
            txtExecLeaseDeed.ReadOnly = false;
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            TextBox grid_paydate = gridviewpayment.FooterRow.FindControl("txtPaymentReceivedDate") as TextBox;

        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnUpload);
            var scriptManager1 = ScriptManager.GetCurrent(Page);
            if (scriptManager1 != null)
                scriptManager1.RegisterPostBackControl(btnUploadLeaseDeed);
            var scriptManager2 = ScriptManager.GetCurrent(Page);
            if (scriptManager2 != null)
                scriptManager2.RegisterPostBackControl(btnUploadPossession);
            var scriptManager3 = ScriptManager.GetCurrent(Page);
            if (scriptManager3 != null)
                scriptManager3.RegisterPostBackControl(btnUploadPossessionMemo);
            var scriptManager4 = ScriptManager.GetCurrent(Page);
            if (scriptManager4 != null)
                scriptManager4.RegisterPostBackControl(btnUploadReservationMoney);

        }

        protected void btn_first_Click(object sender, EventArgs e)
        {
            int retval = 0, retVal2 = 0;
            string msg = "";
            if (!(String.IsNullOrEmpty(Session["AllotteeID"].ToString())))
            {
                if (Session["AllotteeID"].ToString().Length > 0)
                {
                    msg = "A";
                }
                else { msg = "B"; }
            }
            else
            {
                msg = "B";
            }
            if (lblNewButton.Text == "1")
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                    ds = objServiceTimelinesBLL.GetAllotmentletterDetails(objServiceTimelinesBEL);

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox1.ShowInfo("Allotment Letter Number is Alredy exists");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }

            try
            {

                if (Convert.ToInt32(ddlArea.SelectedValue.Trim()) == 0)
                {

                    MessageBox1.ShowInfo("Select Industrial Area First");
                    return;
                }
                if (drpdwnSector.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Select Industrial Area Sector");
                    return;
                }
                if (txtAllotment1.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide Applicant Id");
                    return;
                }
                if (txtPlotNo.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide Plot No");
                    return;
                }
                if (txtAllotmenttLetterApplicationDate.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide allotment Application Date");
                    return;
                }
                else
                {
                    if (ValidateDate(txtAllotmenttLetterApplicationDate.Text))
                    {

                    }
                    else
                    {
                        txtAllotmenttLetterApplicationDate.Focus();
                        MessageBox1.ShowError("Invalid Date of application");
                        return;
                    }

                }
                if (txtAllotmentRate.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide Allotted Rate ");
                    return;
                }
                if (DdlCaseType.SelectedIndex <= 0)
                {
                    MessageBox1.ShowError("Please Select Allotment Case Type");
                    return;
                }
                else
                {
                    if (DdlCaseType.SelectedIndex == 2)
                    {
                        if (ddlTranserCase.SelectedIndex <= 0)
                        {
                            MessageBox1.ShowError("Please Select Transfer Levy Type");
                            return;
                        }
                    }
                    else
                    {
                        txtCarry.Text = "";
                        ddlTranserCase.ClearSelection();
                    }
                }
                if (DdlCaseType.SelectedValue == "Change of Plot")
                {
                    if (txtChangePlotRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtChangePlotRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Change Of Plot Ref. No");
                        return;
                    }
                }
                if (txtalltLetterIssueDate.Text.ToString() == "")
                {
                    MessageBox1.ShowError("Please Select Allotment Letter Issue Date");
                    return;
                }
                else
                {
                    if (ValidateDate(txtalltLetterIssueDate.Text))
                    {

                    }
                    else
                    {
                        txtalltLetterIssueDate.Focus();
                        MessageBox1.ShowError("Invalid Allotment Letter Issue Date");

                        return;
                    }
                }
                if (txtTotalArea.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide Allotted Plot Area In Sqmts");
                    return;
                }

                if (ddlcompanytype.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Select Firm Constitution First");
                    return;
                }
                if (ddlcompanytype.SelectedValue == "2" || ddlcompanytype.SelectedValue == "3" || ddlcompanytype.SelectedValue == "4" || ddlcompanytype.SelectedValue == "5")
                {
                    if (txtAuthorisedSignatory.Text == "" || txtAuthorisedSignatory.Text == null || txtSignatoryAddress.Text == "" || txtSignatoryAddress.Text == null)
                    {

                        MessageBox1.ShowInfo("Please Provide The Name Of The Person Who Will Operate This Application And Address");
                        return;
                    }
                }
                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];
                if(ddlcompanytype.SelectedIndex == 1)
                {
                    if (txtIndividualPhone.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Mobile Number ");
                        return;
                    }
                    if (txtIndividualEmail.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Email ID ");
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (txtSignatoryPhone.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Mobile Number ");
                        return;
                    }
                    if (txtSignatoryEmail.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Email ID ");
                        return;
                    }
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Add Shareholder Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (txtSignatoryPhone.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Mobile Number ");
                        return;
                    }
                    if (txtSignatoryEmail.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Email ID ");
                        return;
                    }
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (txtSignatoryPhone.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Mobile Number ");
                        return;
                    }
                    if (txtSignatoryEmail.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Email ID ");
                        return;
                    }
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (txtSignatoryPhone.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Mobile Number ");
                        return;
                    }
                    if (txtSignatoryEmail.Text == "")
                    {
                        MessageBox1.ShowInfo("Please Provide Email ID ");
                        return;
                    }
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                objServiceTimelinesBEL.IndustrialArea = ddlArea.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = UserName;
                objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.FileNo = txtFileNo.Text.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                objServiceTimelinesBEL.totalPlotArea = float.Parse(txtTotalArea.Text.Trim());

                if(drpdwnSector.SelectedItem.Text.Trim() == "")
                {
                    objServiceTimelinesBEL.SectorName = txtSector.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.SectorName = drpdwnSector.SelectedItem.Text.Trim();
                }

                objServiceTimelinesBEL.SectorName = txtSector.Text.Trim();
                objServiceTimelinesBEL.AllotmentRate = Convert.ToDecimal(string.IsNullOrEmpty(txtAllotmentRate.Text.Trim()) ? "0" : txtAllotmentRate.Text.Trim());
                objServiceTimelinesBEL.locationcharge = Convert.ToDecimal(string.IsNullOrEmpty(txtlocationcharge.Text.Trim()) ? "0" : txtlocationcharge.Text.Trim());
                objServiceTimelinesBEL.InterestRateApplicable = Convert.ToDecimal(string.IsNullOrEmpty(txtInterestRateApplicable.Text.Trim()) ? "0" : txtInterestRateApplicable.Text.Trim());
                objServiceTimelinesBEL.GroundCoverage = Convert.ToDecimal(string.IsNullOrEmpty(txtGroundCoverage.Text.Trim()) ? "0" : txtGroundCoverage.Text.Trim());
                objServiceTimelinesBEL.PermisableFAR = Convert.ToDecimal(string.IsNullOrEmpty(txtPermisableFAR.Text.Trim()) ? "0" : txtPermisableFAR.Text.Trim());
                string AllotmenttLetterApplicationDate = DateTime.ParseExact(txtAllotmenttLetterApplicationDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.AllotmenttLetterApplicationDate = Convert.ToDateTime((AllotmenttLetterApplicationDate));
                string AllotmentIssueDate1 = DateTime.ParseExact(txtalltLetterIssueDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.AllotmentIssueDate = Convert.ToDateTime((AllotmentIssueDate1));
                objServiceTimelinesBEL.ref_AllotmentNo = txtallotment_ref_no.Text.Trim();
                objServiceTimelinesBEL.ConstructionValueAtTimeofAllotment = float.Parse(string.IsNullOrEmpty(txtConstructionValueAtTimeofAllotment.Text.Trim()) ? "0" : txtConstructionValueAtTimeofAllotment.Text.Trim());
                objServiceTimelinesBEL.CaseType = DdlCaseType.SelectedValue.Trim();
                objServiceTimelinesBEL.TranserLevyCase = Convert.ToInt32(string.IsNullOrEmpty(ddlTranserCase.SelectedValue.Trim()) ? "0" : ddlTranserCase.SelectedValue.Trim());
                objServiceTimelinesBEL.PrevDues = Convert.ToDecimal(string.IsNullOrEmpty(txtCarry.Text.Trim()) ? "0" : txtCarry.Text.Trim());
                if (txtfirstAllotmentDate.Text.Trim().Length > 0)
                {
                    string firstAllotmentDate1 = DateTime.ParseExact(txtfirstAllotmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.firstAllotmentDate = Convert.ToDateTime((firstAllotmentDate1));
                }
                else
                {
                    objServiceTimelinesBEL.firstAllotmentDate = Convert.ToDateTime("01/01/1999");
                }
                objServiceTimelinesBEL.Allotmentreferencenumber = txtAllotmentreferencenumber.Text.Trim();
                objServiceTimelinesBEL.ChangeOfPlotRefNo = txtChangePlotRefNo.Text.Trim();
                if (txtChangePlotRefDate.Text.Trim().Length > 0)
                {
                    string ChangeOfPlotRefDate1 = DateTime.ParseExact(txtChangePlotRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.ChangeOfPlotRefDate = Convert.ToDateTime((ChangeOfPlotRefDate1));
                }
                objServiceTimelinesBEL.AdditionalChargesforplot = Convert.ToDecimal(string.IsNullOrEmpty(txtAdditionalChargesforplot.Text.Trim()) ? "0" : txtAdditionalChargesforplot.Text.Trim());
                objServiceTimelinesBEL.DeedafterChangeofPlot = txtDeedafterChangeofPlot.Text.Trim();
                objServiceTimelinesBEL.Newstatus = Convert.ToInt32(lblNewButton.Text.Trim());
                objServiceTimelinesBEL.SectorID = drpdwnSector.SelectedItem.Value.Trim();
                objServiceTimelinesBEL.GstNo = txtGstNo.Text.Trim();
                objServiceTimelinesBEL.UdyogAadharNo = txtUdyogAdhar.Text.Trim();
                objServiceTimelinesBEL.AadharNo = txtAadharNo.Text.Trim();
                ds = objServiceTimelinesBLL.NewRegistrationAllotteeDetails(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                        belBookDetails objServiceTimelinesBEL = new belBookDetails();
                        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                        DataSet dsAllotteeID = new DataSet();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        dsAllotteeID = objServiceTimelinesBLL.GetAllotteeIDDetails(objServiceTimelinesBEL);
                        Session["AllotteeID"] = dsAllotteeID.Tables[0].Rows[0][0].ToString();

                        Classes.Class1 cs = new Classes.Class1();
                        cs.str = "UPDATE dbo.AllotteeMaster SET panalInterest = '"+txtPanelRateApplicable.Text+"' WHERE AllotteeID ='"+ Session["AllotteeID"].ToString() + "' ";
                        cs.ExecuteSql(cs.str);
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(dsAllotteeID.Tables[0].Rows[0][0].ToString());
                        retVal2 = objServiceTimelinesBLL.ClearAllotteeShareHolder(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedIndex == 1)
                            {
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                allotteeID.Text = Session["AllotteeID"].ToString();
                                GetAllAllotteeDetailsFilledById(Convert.ToInt32(allotteeID.Text));
                                MultiView1.ActiveViewIndex = 6;
                            }
                            if (ddlcompanytype.SelectedIndex == 2)
                            {
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["PhoneNo"].ToString();
                                        string email = dr1["EmailId"].ToString();
                                        objServiceTimelinesBEL.ShareHolderName = ShareholderName.Trim();
                                        objServiceTimelinesBEL.ShareHolderAddress = Address.Trim();
                                        objServiceTimelinesBEL.ShareHolderPhone = phone.Trim();
                                        objServiceTimelinesBEL.ShareHolderEmail = email.Trim();
                                        objServiceTimelinesBEL.ShareHolderPer = shareper;
                                        retval = objServiceTimelinesBLL.SaveAllotteeShareHolderDetails(objServiceTimelinesBEL);
                                    }
                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    MultiView1.ActiveViewIndex = 6;
                                }
                            }
                            if (ddlcompanytype.SelectedIndex == 3)

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["EmailId"].ToString();
                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;
                                        retval = objServiceTimelinesBLL.SaveAllotteeDirectorsDetails(objServiceTimelinesBEL);
                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    MultiView1.ActiveViewIndex = 6;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["EmailId"].ToString();
                                        objServiceTimelinesBEL.TrusteeName = TrusteeName.Trim();
                                        objServiceTimelinesBEL.TrusteeAddress = Address.Trim();
                                        objServiceTimelinesBEL.TrusteePhone = phone.Trim();
                                        objServiceTimelinesBEL.TrusteeEmail = email.Trim();
                                        retval = objServiceTimelinesBLL.SaveAllotteeTrusteeDetails(objServiceTimelinesBEL);
                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    MultiView1.ActiveViewIndex = 6;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["PhoneNo"].ToString();
                                        string email = dr1["EmailId"].ToString();
                                        objServiceTimelinesBEL.PartnerName = PartnerName.Trim();
                                        objServiceTimelinesBEL.PartnerAddress = Address.Trim();
                                        objServiceTimelinesBEL.PartnerPhone = phone.Trim();
                                        objServiceTimelinesBEL.PartnerEmail = email.Trim();
                                        objServiceTimelinesBEL.PartnerPer = Partnershipper;
                                        retval = objServiceTimelinesBLL.SaveAllotteePatnersDetails(objServiceTimelinesBEL);
                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    MultiView1.ActiveViewIndex = 6;
                                }
                            }
                        }
                        
                        if (Session["AllotteeID"].ToString().Length > 0)
                        {
                            btn_first_save.Text = "Saved";
                            Conform_CheckBox_multiview_1.Checked = false;
                        }
                        allotteeID.Text = Session["AllotteeID"].ToString();
                        GetAllAllotteeDetailsFilledById(Convert.ToInt32(allotteeID.Text));
                        lblNewButton.Text = "0";
                    }
                }
                else
                {
                    Session["AllotteeID"] = "";
                    btn_first_save.Text = "Save";
                    CheckBox_Final.Checked = false;
                    allotteeID.Text = "";
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #region FileUploaderCACertificate
            protected void btnUploadCACertificate_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fupcacertificate.HasFile)
                {
                    string filePath = fupcacertificate.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fupcacertificate.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fupcacertificate.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "8";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnCACertificate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 8 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 8 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion


        #region FileUploaderAllotmentLetter
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileupload.HasFile)
                {
                    string filePath = fileupload.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileupload.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileupload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "1";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnMinutes_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 1 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 1 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion

        #region FileUploaderReservationMoney
        protected void btnUploadReservationMoney_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileuploadReservation.HasFile)
                {
                    string filePath = fileuploadReservation.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileuploadReservation.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileuploadReservation.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "3";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnReservationMoney_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 3 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 3 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion
        #region FileUploaderLeaseDeed
        protected void btnUploadLeaseDeed_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileuploadLeaseDeed.HasFile)
                {
                    string filePath = fileuploadLeaseDeed.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileuploadLeaseDeed.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileuploadLeaseDeed.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "5";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnLeaseDeed_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 5 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 5 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion
        #region FileUploaderPossession
        protected void btnUploadPossession_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileuploadPossession.HasFile)
                {
                    string filePath = fileuploadPossession.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileuploadPossession.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileuploadPossession.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "6";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnPossession_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 6 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 6 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion
        #region FileUploaderPossessionMemo
        protected void btnUploadPossessionMemo_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileuploadPossessionMemo.HasFile)
                {
                    string filePath = fileuploadPossessionMemo.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileuploadPossessionMemo.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileuploadPossessionMemo.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        objServiceTimelinesBEL.AllotmentLetterno = txtAllotment1.Text.Trim();
                        objServiceTimelinesBEL.DocumentID = "7";
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }

                    retval = objServiceTimelinesBLL.UploadAllDocument(objServiceTimelinesBEL);
                    if (retval > 0)
                    {
                        MessageBox1.ShowSuccess("Document Uploaded Successfully !");
                        return;
                    }
                    else
                    {
                        MessageBox1.ShowError("Error Occured !");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Document");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnPossessionMemo_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("GET_AllDoc  '" + Session["AllotteeID"].ToString() + "'," + 7 + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                    String js = "window.open('DocViewerLetter.aspx?Allottee=" + Session["AllotteeID"].ToString() + "&DocID=" + 7 + "','_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLetter.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Document Not Uploaded Yet");
                }
            }
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ///////////////////////////   Start Of  Next button click update    //////////////////////////////

            try
            {

                if (txtPossessiondate.Text != "")
                {
                    if (ValidateDate(txtPossessiondate.Text))
                    {

                    }
                    else
                    {
                        txtPossessiondate.Focus();
                        MessageBox1.ShowError("Invalid Possession Date");
                        return;
                    }
                }
                if (txtRestorationRefDate.Text != "")
                {
                    if (ValidateDate(txtRestorationRefDate.Text))
                    {

                    }
                    else
                    {
                        txtRestorationRefDate.Focus();
                        MessageBox1.ShowError("Invalid Restoration Reference Date");
                        return;
                    }
                }
                if (txtLeaseDeed.Text != "")
                {
                    if (ValidateDate(txtLeaseDeed.Text))
                    {

                    }
                    else
                    {
                        txtLeaseDeed.Focus();
                        MessageBox1.ShowError("Invalid Date of lease deed");
                        return;
                    }
                }
                if (txtExecLeaseDeed.Text != "")
                {
                    if (ValidateDate(txtExecLeaseDeed.Text))
                    {

                    }
                    else
                    {
                        txtExecLeaseDeed.Focus();
                        MessageBox1.ShowError("Invalid Date of execution lease deed");
                        return;
                    }
                }
                if (txtChangeProjectRefDate.Text != "")
                {
                    if (ValidateDate(txtChangeProjectRefDate.Text))
                    {

                    }
                    else
                    {
                        txtChangeProjectRefDate.Focus();
                        MessageBox1.ShowError("Invalid Change Of Project Ref Date");

                        return;
                    }
                }
                if (txtAmalgamationRefDate.Text != "")
                {
                    if (ValidateDate(txtAmalgamationRefDate.Text))
                    {

                    }
                    else
                    {
                        txtAmalgamationRefDate.Focus();
                        MessageBox1.ShowError("Invalid Amalgamation Ref Date");

                        return;
                    }
                }
                if (txtSubDivRefDate.Text != "")
                {
                    if (ValidateDate(txtSubDivRefDate.Text))
                    {

                    }
                    else
                    {
                        txtSubDivRefDate.Focus();
                        MessageBox1.ShowError("Invalid Sub Div Ref Date");

                        return;
                    }
                }
                if (txtSublettingRefDate.Text != "")
                {
                    if (ValidateDate(txtSublettingRefDate.Text))
                    {

                    }
                    else
                    {
                        txtSublettingRefDate.Focus();
                        MessageBox1.ShowError("Invalid Subletting Ref Date");

                        return;
                    }
                }
                if (txtAgreementDate.Text != "")
                {

                    if (ValidateDate(txtAgreementDate.Text))
                    {

                    }
                    else
                    {
                        txtAgreementDate.Focus();
                        MessageBox1.ShowError("Invalid Agreement Date");

                        return;
                    }
                }
                if (txtAgreementExecDate.Text != "")
                {

                    if (ValidateDate(txtAgreementExecDate.Text))
                    {

                    }
                    else
                    {
                        txtAgreementExecDate.Focus();
                        MessageBox1.ShowError("Invalid Agreement Execution Date");

                        return;
                    }
                }
                if (txtIssueDate.Text != "")
                {
                    if (ValidateDate(txtIssueDate.Text))
                    {

                    }
                    else
                    {
                        txtIssueDate.Focus();
                        MessageBox1.ShowError("Invalid E Stamp Issue Date");

                        return;
                    }
                }
                if (txtLastDateClaim.Text != "")
                {
                    DateTime dt6;
                    if (ValidateDate(txtLastDateClaim.Text))
                    {

                    }
                    else
                    {
                        txtLastDateClaim.Focus();
                        MessageBox1.ShowError("Invalid Last Date Claim");

                        return;
                    }
                }
                if (txtBuildingDate.Text != "")
                {
                    DateTime dt7;
                    if (ValidateDate(txtBuildingDate.Text))
                    {

                    }
                    else
                    {
                        txtBuildingDate.Focus();
                        MessageBox1.ShowError("Invalid Date of Building plan Approval");

                        return;
                    }
                }
                if (txtcomcertificate.Text != "")
                {
                    if (ValidateDate(txtcomcertificate.Text))
                    {

                    }
                    else
                    {
                        txtcomcertificate.Focus();
                        MessageBox1.ShowError("Invalid Date of Release of Completion Certificate");

                        return;
                    }
                }
                if (txtReloccertificate.Text != "")
                {

                    if (ValidateDate(txtReloccertificate.Text))
                    {

                    }
                    else
                    {
                        txtReloccertificate.Focus();
                        MessageBox1.ShowError("Invalid Date of Release of Occupancy Certificate");

                        return;
                    }
                }
                if (txtInspectionDate.Text != "")
                {
                    if (ValidateDate(txtInspectionDate.Text))
                    {

                    }
                    else
                    {
                        txtInspectionDate.Focus();
                        MessageBox1.ShowError("Invalid Date of Inspection for construction permit");
                        return;
                    }
                }
                if (txtInspectioncompletion.Text != "")
                {
                    DateTime dt10;
                    if (ValidateDate(txtInspectioncompletion.Text))
                    {

                    }
                    else
                    {
                        txtInspectioncompletion.Focus();
                        MessageBox1.ShowError("Invalid Date of Inspection for completion");

                        return;
                    }
                }
                #region New Code By  Manish

                if (txtReservationPaymentDate.Text != "")
                {
                    DateTime dt11;
                    if (ValidateDate(txtReservationPaymentDate.Text))
                    {

                    }
                    else
                    {
                        txtReservationPaymentDate.Focus();
                        MessageBox1.ShowError("Reservation Money Payment Date");

                        return;
                    }
                }

                if (txtPhysicalPossessionDate.Text != "")
                {
                    DateTime dt12;
                    if (ValidateDate(txtPhysicalPossessionDate.Text))
                    {

                    }
                    else
                    {
                        txtPhysicalPossessionDate.Focus();
                        MessageBox1.ShowError("Invalid Physical Possession Date");

                        return;
                    }
                }

                if (ddlReservationmoney.SelectedValue == "True")
                {
                    if (txtReservationPaymentDate.Text != "")
                    {

                    }
                    else
                    {
                        txtReservationPaymentDate.Focus();
                        MessageBox1.ShowError("Please Enter Reservation Money Payment Date");
                        return;
                    }
                    if (txtReservationPaymentAmount.Text != "")
                    {

                    }
                    else
                    {
                        txtReservationPaymentAmount.Focus();
                        MessageBox1.ShowError("Please Enter Reservation Money Payment Amount");
                        return;
                    }
                }


                if (ddlLeaseDeedSigned.SelectedValue == "True")
                {
                    if (txtLeaseDeed.Text != "")
                    {

                    }
                    else
                    {
                        txtLeaseDeed.Focus();
                        MessageBox1.ShowError("Please Enter Date of Lease Deed");
                        return;
                    }
                    if (txtLeaseDeed_ref_no.Text != "")
                    {

                    }
                    else
                    {
                        txtLeaseDeed_ref_no.Focus();
                        MessageBox1.ShowError("Please Enter Lease Deed Ref. No");
                        return;
                    }
                    if (txtExecLeaseDeed.Text != "")
                    {

                    }
                    else
                    {
                        txtExecLeaseDeed.Focus();
                        MessageBox1.ShowError("Please Enter Date of execution lease deed");
                        return;
                    }
                    if (txt_Lease_bookno.Text != "")
                    {

                    }
                    else
                    {
                        txt_Lease_bookno.Focus();
                        MessageBox1.ShowError("Please Enter Book No(Bahi)");
                        return;
                    }
                    if (txt_Lease_bookbinding.Text != "")
                    {

                    }
                    else
                    {
                        txt_Lease_bookbinding.Focus();
                        MessageBox1.ShowError("Please Enter Bookbinding No(Jild)");
                        return;
                    }
                    if (txt_Lease_pagefrom.Text != "")
                    {

                    }
                    else
                    {
                        txt_Lease_pagefrom.Focus();
                        MessageBox1.ShowError("Please Enter Page From");
                        return;
                    }
                    if (txt_Lease_pageto.Text != "")
                    {

                    }
                    else
                    {
                        txt_Lease_pageto.Focus();
                        MessageBox1.ShowError("Please Enter Page To");
                        return;
                    }

                    if (txt_Lease_srno.Text != "")
                    {

                    }
                    else
                    {
                        txt_Lease_srno.Focus();
                        MessageBox1.ShowError("Please Enter S.No");
                        return;
                    }
                }

                if (ddlPossessionLetter.SelectedValue == "True")
                {
                    if (txtPossessiondate.Text != "")
                    {

                    }
                    else
                    {
                        txtPossessiondate.Focus();
                        MessageBox1.ShowError("Please Enter Date of Possession");
                        return;
                    }
                }

                if (ddlPhysicalPossession.SelectedValue == "True")
                {
                    if (txtPhysicalPossessionDate.Text != "")
                    {

                    }
                    else
                    {
                        txtPhysicalPossessionDate.Focus();
                        MessageBox1.ShowError("Please Enter Physical Possession Date");
                        return;
                    }

                    if (txtPossessionArea.Text != "")
                    {

                    }
                    else
                    {
                        txtPossessionArea.Focus();
                        MessageBox1.ShowError("Please Enter Possession Area");
                        return;
                    }

                }

                if (ddlBuildingPlan.SelectedValue == "True")
                {
                    if (txtBuildingDate.Text != "")
                    {

                    }
                    else
                    {
                        txtBuildingDate.Focus();
                        MessageBox1.ShowError("Please Enter Date of Building plan Approval");
                        return;
                    }

                    if (txtBuildingDate_ref_no.Text != "")
                    {

                    }
                    else
                    {
                        txtBuildingDate_ref_no.Focus();
                        MessageBox1.ShowError("Please Enter Building plan Ref. No");
                        return;
                    }

                }

                if (ddlRestoration.SelectedValue == "True")
                {
                    if (txtRestorationRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtRestorationRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Restoration Ref no");
                        return;
                    }

                    if (txtRestorationRefDate.Text != "")
                    {

                    }
                    else
                    {
                        txtRestorationRefDate.Focus();

                        MessageBox1.ShowError("Please Enter Restoration Ref Date");
                        return;
                    }
                }



                if (ddlChangeofProject.SelectedValue == "True")
                {
                    if (txtChangeProjectRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtChangeProjectRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Change Of Project Ref. No");
                        return;
                    }

                    if (txtChangeProjectRefDate.Text != "")
                    {

                    }
                    else
                    {
                        txtChangeProjectRefDate.Focus();
                        MessageBox1.ShowError("Please Enter Change Of Project Ref. Date");
                        return;
                    }
                }

                if (ddlAmalgamation.SelectedValue == "True")
                {
                    if (txtAmalgamationRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtAmalgamationRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Amalgamation Ref. No");
                        return;
                    }

                    if (txtAmalgamationRefDate.Text != "")
                    {

                    }
                    else
                    {
                        txtAmalgamationRefDate.Focus();
                        MessageBox1.ShowError("Please Enter Amalgamation Ref. Date");
                        return;
                    }
                }

                if (ddlSubDivision.SelectedValue == "True")
                {
                    if (txtSubDivRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtSubDivRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Sub Div Ref. No");
                        return;
                    }

                    if (txtSubDivRefDate.Text != "")
                    {

                    }
                    else
                    {
                        txtSubDivRefDate.Focus();
                        MessageBox1.ShowError("Please Enter Sub Div Ref. Date");
                        return;
                    }
                }

                if (ddlSubletting.SelectedValue == "True")
                {
                    if (txtSublettingRefNo.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingRefNo.Focus();
                        MessageBox1.ShowError("Please Enter Subletting Ref. No");
                        return;
                    }

                    if (txtSublettingRefDate.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingRefDate.Focus();
                        MessageBox1.ShowError("Please Enter Subletting Ref. Date");
                        return;
                    }

                    if (txtSublettingPartyName.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingPartyName.Focus();
                        MessageBox1.ShowError("Please Enter Subletting Party Name");
                        return;
                    }

                    if (txtSublettingArea.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingArea.Focus();
                        MessageBox1.ShowError("Please Enter Subletting Area");
                        return;
                    }

                    if (txtSublettingYears.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingYears.Focus();
                        MessageBox1.ShowError("Please Enter Subletting For Years");
                        return;
                    }
                    if (txtSublettingProjectName.Text != "")
                    {

                    }
                    else
                    {
                        txtSublettingProjectName.Focus();
                        MessageBox1.ShowError("Please Enter Subletting Project Name");
                        return;
                    }
                }

                if (ddlAgreement.SelectedValue == "True")
                {
                    if (txtAgreementDate.Text != "")
                    {

                    }
                    else
                    {
                        txtAgreementDate.Focus();
                        MessageBox1.ShowError("Please Enter Agreement Date");
                    }

                    if (txtAgreementExecDate.Text != "")
                    {

                    }
                    else
                    {
                        txtAgreementExecDate.Focus();
                        MessageBox1.ShowError("Please Enter Agreement Execution Date");
                    }

                    if (txtAgreementPlotSize.Text != "")
                    {

                    }
                    else
                    {
                        txtAgreementPlotSize.Focus();
                        MessageBox1.ShowError("Please Enter Agreement On Plot Size");
                    }

                }

                if (ddlEStamp.SelectedValue == "True")
                {
                    if (txtCertificateNo.Text != "")
                    {

                    }
                    else
                    {
                        txtCertificateNo.Focus();
                        MessageBox1.ShowError("Please Enter Certificate No");
                    }

                    if (txtIssueDate.Text != "")
                    {

                    }
                    else
                    {
                        txtIssueDate.Focus();
                        MessageBox1.ShowError("Please Enter Issue Date");
                    }
                    if (txtstampDutyAmount.Text != "")
                    {

                    }
                    else
                    {
                        txtstampDutyAmount.Focus();
                        MessageBox1.ShowError("Please Enter Stamp Duty Amount");
                    }
                }

                if (ddlBankGuarantee.SelectedValue == "True")
                {
                    if (txtGuaranteeNo.Text != "")
                    {

                    }
                    else
                    {
                        txtGuaranteeNo.Focus();
                        MessageBox1.ShowError("Please Enter Guarantee No");
                    }

                    if (txtGuaranteeAmount.Text != "")
                    {

                    }
                    else
                    {
                        txtGuaranteeAmount.Focus();
                        MessageBox1.ShowError("Please Enter Guarantee Amount");
                    }
                    if (txtGuaranteeAmount.Text != "")
                    {

                    }
                    else
                    {
                        txtGuaranteeAmount.Focus();
                        MessageBox1.ShowError("Please Enter Guarantee Amount");
                    }
                    if (txtCoverFrom.Text != "")
                    {

                    }
                    else
                    {
                        txtCoverFrom.Focus();
                        MessageBox1.ShowError("Please Enter Guarantee Cover from");
                    }
                    if (txtCoverTo.Text != "")
                    {

                    }
                    else
                    {
                        txtCoverTo.Focus();
                        MessageBox1.ShowError("Please Enter Guarantee Cover To");
                    }
                    if (txtLastDateClaim.Text != "")
                    {

                    }
                    else
                    {
                        txtLastDateClaim.Focus();
                        MessageBox1.ShowError("Please Enter Last Date Of Claim");
                    }

                }


                if (ddlMortgage.SelectedValue == "True")
                {
                    if (txtPoposalLetter.Text != "")
                    {

                    }
                    else
                    {
                        txtPoposalLetter.Focus();
                        MessageBox1.ShowError("Please Enter Bank Proposal Letter");
                    }

                    if (txtSanctionLetter.Text != "")
                    {

                    }
                    else
                    {
                        txtSanctionLetter.Focus();
                        MessageBox1.ShowError("Please Enter Bank Sanction Letter");
                    }
                    if (txtSanctionLetterUpsidc.Text != "")
                    {

                    }
                    else
                    {
                        txtSanctionLetterUpsidc.Focus();
                        MessageBox1.ShowError("Please Enter Sanction letter Of UPSIDC");
                    }
                    if (txtNoOfStamp.Text != "")
                    {

                    }
                    else
                    {
                        txtNoOfStamp.Focus();
                        MessageBox1.ShowError("Please Enter No of Stamp");
                    }
                    if (txtStampAmoount.Text != "")
                    {

                    }
                    else
                    {
                        txtStampAmoount.Focus();
                        MessageBox1.ShowError("Please Enter Stamp Amount");
                    }
                    if (txtTotalStampDuty.Text != "")
                    {

                    }
                    else
                    {
                        txtTotalStampDuty.Focus();
                        MessageBox1.ShowError("Please Enter Total Stamp Duty");
                    }

                }

                #endregion
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
                if (txtLeaseDeed.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtLeaseDeed.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.LeaseDeedDate = Convert.ToDateTime((date_to_be));
                }
                if (txtExecLeaseDeed.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtExecLeaseDeed.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.LeaseAgrementExecDate = Convert.ToDateTime((date_to_be));
                }
                if (txtBuildingDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtBuildingDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.DateOfBuldingPlanSubmission = Convert.ToDateTime((date_to_be));
                }
                if (txtReloccertificate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtReloccertificate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.ReleaseofOccupancyCertificateDate = Convert.ToDateTime((date_to_be));
                }
                if (txtDateofAllottementNo.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtDateofAllottementNo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.DateofAllottementNo = Convert.ToDateTime((date_to_be));
                }
                if (txtcomcertificate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtcomcertificate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.DateOfReleaseForCompletion = Convert.ToDateTime((date_to_be));
                }
                if (txtInspectionDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtInspectionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.InspectionDateForConstructionPermit = Convert.ToDateTime((date_to_be));
                }
                if (txtInspectioncompletion.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtInspectioncompletion.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.InspectionDateForComplition = Convert.ToDateTime((date_to_be));
                }
                objServiceTimelinesBEL.ModifiedBy = UserName;
                objServiceTimelinesBEL.ModifiedDate = DateTime.Now;
                objServiceTimelinesBEL.ref_AllotmentNo = txtallotment_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_LeaseDeed = txtLeaseDeed_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_BuildingPlan = txtBuildingDate_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_CompletionCertificate = txtcomcertificate_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_OccupancyCertificate = txtReloccertificate_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_ConstructionInspection = txtInspectionDate_ref_no.Text.Trim();
                objServiceTimelinesBEL.ref_CompletionInspection = txtInspectioncompletion_ref_no.Text.Trim();
                objServiceTimelinesBEL.Lease_bookno = txt_Lease_bookno.Text.Trim();
                objServiceTimelinesBEL.Lease_bookbinding = txt_Lease_bookbinding.Text.Trim();
                objServiceTimelinesBEL.Lease_pagefrom = txt_Lease_pagefrom.Text.Trim();
                objServiceTimelinesBEL.Lease_pageto = txt_Lease_pageto.Text.Trim();
                objServiceTimelinesBEL.Lease_srno = txt_Lease_srno.Text.Trim();
                objServiceTimelinesBEL.CertificateNo = txtCertificateNo.Text.Trim();
                if (txtIssueDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtIssueDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.IssueDate = Convert.ToDateTime((date_to_be));
                }
                if (txtstampDutyAmount.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.StampDutyAmount = float.Parse(txtstampDutyAmount.Text.Trim());
                }
                objServiceTimelinesBEL.AccountRefrenceNo = txtAccountReference.Text.Trim();
                objServiceTimelinesBEL.UniqueDocRef = txtUniqueDocReference.Text.Trim();
                objServiceTimelinesBEL.BankGuaranteeNo = txtGuaranteeNo.Text.Trim();
                if (txtGuaranteeAmount.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.GuaranteeAmount = float.Parse(txtGuaranteeAmount.Text.Trim());
                }
                if (txtCoverFrom.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtCoverFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.GuaranteeCoverFrom = Convert.ToDateTime((date_to_be));
                }
                if (txtCoverTo.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtCoverTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.GuaranteeCoverTo = Convert.ToDateTime((date_to_be));
                }
                if (txtLastDateClaim.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtLastDateClaim.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.LastDateOfClaim = Convert.ToDateTime((date_to_be));
                }
                if (txtPossessiondate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtPossessiondate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.Possessiondate = Convert.ToDateTime((date_to_be));
                }
                if (txtRestorationRefDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtRestorationRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.RestorationRefDate = Convert.ToDateTime((date_to_be));
                }
                objServiceTimelinesBEL.RestorationRefNo = txtRestorationRefNo.Text.Trim();
                objServiceTimelinesBEL.BankProposalLetter = txtPoposalLetter.Text.Trim();
                objServiceTimelinesBEL.BankSanctionLetter = txtSanctionLetter.Text.Trim();
                objServiceTimelinesBEL.SanctionLetterOfUPSIDC = txtSanctionLetterUpsidc.Text.Trim();
                if (txtNoOfStamp.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.NoOfStamp = Convert.ToInt32(txtNoOfStamp.Text.Trim());
                }
                if (txtStampAmoount.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.StampAmount = float.Parse(txtStampAmoount.Text.Trim());
                }
                if (txtTotalStampDuty.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.TotalStampDuty = float.Parse(txtTotalStampDuty.Text.Trim());
                }
                if (txtConstructionValueAtTimeofAllotment.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.ConstructionValueAtTimeofAllotment = float.Parse(txtConstructionValueAtTimeofAllotment.Text.Trim());
                }
                if (txtPossessionArea.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.PossessionArea = decimal.Parse(txtPossessionArea.Text.Trim());
                }
                if (txtAgreementPlotSize.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.AgreementOnPlotSize = decimal.Parse(txtAgreementPlotSize.Text.Trim());
                }
                //if (txtChangePlotRefDate.Text.Trim().Length > 0)
                //{
                //    string date_to_be = DateTime.ParseExact(txtChangePlotRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                //    objServiceTimelinesBEL.ChangeOfPlotRefDate = Convert.ToDateTime((date_to_be));
                //}
                if (txtChangeProjectRefDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtChangeProjectRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.ChangeOfProjectRefDate = Convert.ToDateTime((date_to_be));
                }
                if (txtAmalgamationRefDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtAmalgamationRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.AmagaRefDate = Convert.ToDateTime((date_to_be));
                }
                if (txtSubDivRefDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtSubDivRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.SubDivRefDate = Convert.ToDateTime((date_to_be));
                }
                if (txtSublettingRefDate.Text.Trim().Length > 0)
                {

                    string date_to_be = DateTime.ParseExact(txtSublettingRefDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.SublettingRefDate = Convert.ToDateTime((date_to_be));
                }
                if (txtAgreementDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtAgreementDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.DateOfAgreement = Convert.ToDateTime((date_to_be));
                }
                if (txtAgreementExecDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtAgreementExecDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.DateOfExecutionAgreement = Convert.ToDateTime((date_to_be));
                }
                //objServiceTimelinesBEL.ChangeOfPlotRefNo = txtChangePlotRefNo.Text.Trim();
                objServiceTimelinesBEL.ChangeOfProjectRefNo = txtChangeProjectRefNo.Text.Trim();
                objServiceTimelinesBEL.AmagaRefNo = txtAmalgamationRefNo.Text.Trim();
                objServiceTimelinesBEL.SubDivRefNo = txtSubDivRefNo.Text.Trim();
                objServiceTimelinesBEL.SublettingRefNo = txtSublettingRefNo.Text.Trim();
                objServiceTimelinesBEL.SublettingPartyName = txtSublettingPartyName.Text.Trim();
                if (txtSublettingArea.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.SublettingArea = decimal.Parse(txtSublettingArea.Text.Trim());
                }
                if (txtSublettingYears.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.SublettingForYears = decimal.Parse(txtSublettingYears.Text.Trim());
                }
                objServiceTimelinesBEL.SublettingProjectName = txtSublettingProjectName.Text.Trim();
                #region Code By Manish Shukla
                if (txtPhysicalPossessionDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtPhysicalPossessionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.PhysicalPossessionDate = Convert.ToDateTime((date_to_be));
                }
                if (txtReservationPaymentDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtReservationPaymentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.ReservationPaymentDate = Convert.ToDateTime((date_to_be));
                }
                if (txtReservationPaymentAmount.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.ReservationPaymentAmount = float.Parse(txtReservationPaymentAmount.Text.Trim());
                }

                objServiceTimelinesBEL.ReservationmoneyStatus = ddlReservationmoney.SelectedValue.Trim();
                objServiceTimelinesBEL.LeaseDeedSignedStatus = ddlLeaseDeedSigned.SelectedValue.Trim();
                objServiceTimelinesBEL.PossessionLetterStatus = ddlPossessionLetter.SelectedValue.Trim();
                objServiceTimelinesBEL.PhysicalPossessionStatus = ddlPhysicalPossession.SelectedValue.Trim();
                objServiceTimelinesBEL.BuildingPlanStatus = ddlBuildingPlan.SelectedValue.Trim();
                objServiceTimelinesBEL.RestorationStatus = ddlRestoration.SelectedValue.Trim();
                //objServiceTimelinesBEL.ChangeofPlotStatus = ddlChangeofPlot.SelectedValue.Trim();
                objServiceTimelinesBEL.ChangeofProjectStatus = ddlChangeofProject.SelectedValue.Trim();



                objServiceTimelinesBEL.AmalgamationStatus = ddlAmalgamation.SelectedValue.Trim();

                objServiceTimelinesBEL.SubDivisionStatus = ddlSubDivision.SelectedValue.Trim();

                objServiceTimelinesBEL.SublettingStatus = ddlSubletting.SelectedValue.Trim();

                objServiceTimelinesBEL.AgreementStatus = ddlAgreement.SelectedValue.Trim();

                objServiceTimelinesBEL.EStampStatus = ddlEStamp.SelectedValue.Trim();

                objServiceTimelinesBEL.BankGuaranteeStatus = ddlBankGuarantee.SelectedValue.Trim();

                objServiceTimelinesBEL.MortgageStatus = ddlMortgage.SelectedValue.Trim();

                objServiceTimelinesBEL.linterestWaiver = ddlinterestWaiver.SelectedValue.Trim();

                objServiceTimelinesBEL.increaseinfar = ddlincreaseinfar.SelectedValue.Trim();


                if (txtothercharges.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.othercharges = float.Parse(txtothercharges.Text.Trim());
                }
                if (txtCompoundingCharges.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.CompoundingCharges = float.Parse(txtCompoundingCharges.Text.Trim());
                }

                objServiceTimelinesBEL.RestorationLevy = txtRestorationLevy.Text.Trim();
                objServiceTimelinesBEL.DeedafterRestoration = txtDeedafterRestoration.Text.Trim();


                //objServiceTimelinesBEL.DeedafterChangeofPlot = txtDeedafterChangeofPlot.Text.Trim();

                if (txtChangeforChanges.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.ChangeforChanges = decimal.Parse(txtChangeforChanges.Text.Trim());
                }
                if (txtincreaseofFAR.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.increaseofFAR = float.Parse(txtincreaseofFAR.Text.Trim());
                }
                if (txtAmalgamationFees.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.AmalgamationFees = decimal.Parse(txtAmalgamationFees.Text.Trim());
                }
                if (txtUsabilityFees.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.UsabilityFees = decimal.Parse(txtUsabilityFees.Text.Trim());
                }
                //if (txtAdditionalChargesforplot.Text.Trim().Length > 0)
                //{
                //    objServiceTimelinesBEL.AdditionalChargesforplot = decimal.Parse(txtAdditionalChargesforplot.Text.Trim());
                //}

                if (txtRectificationDeedDate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtRectificationDeedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.RectificationDeedDate = Convert.ToDateTime((date_to_be));
                }

                objServiceTimelinesBEL.SubDivType = txtSubDivType.Text.Trim();

                if (txtNoofPlotCreated.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.NoofPlotCreated = float.Parse(txtNoofPlotCreated.Text.Trim());
                }

                if (txtSubDivCharges.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.SubDivCharges = decimal.Parse(txtSubDivCharges.Text.Trim());
                }
                if (txtExtensionCharges.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.ExtensionCharges = decimal.Parse(txtExtensionCharges.Text.Trim());
                }
                if (txtSublettingCharge.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.SublettingCharge = decimal.Parse(txtSublettingCharge.Text.Trim());
                }


                if (timePeriod.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.timePeriod = decimal.Parse(timePeriod.Text.Trim());
                }

                if (txtTimeextensionWaiverfrom.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtTimeextensionWaiverfrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.TimeextensionWaiverfrom = Convert.ToDateTime((date_to_be));
                }

                if (txtTimeextensionWaiverTo.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtTimeextensionWaiverTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.TimeextensionWaiverTo = Convert.ToDateTime((date_to_be));
                }


                //if (txtTimeextensionWaiver.Text.Trim().Length > 0)
                //{
                //    objServiceTimelinesBEL.TimeextensionWaiver = decimal.Parse(txtTimeextensionWaiver.Text.Trim());
                //}
                if (txtInttonTimeextension.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.InttonTimeextension = decimal.Parse(txtInttonTimeextension.Text.Trim());
                }

                if (txtbalancedues.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.Inttonbalancedues = decimal.Parse(txtbalancedues.Text.Trim());
                }

                if (txtMaintenanceChargesWaiver.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.MaintenanceChargesWaiver = decimal.Parse(txtMaintenanceChargesWaiver.Text.Trim());
                }
                if (dateofIncreaseinfar.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(dateofIncreaseinfar.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.dateofIncreaseinfar = Convert.ToDateTime((date_to_be));
                }

                objServiceTimelinesBEL.letternumber = txtletternumber.Text.Trim();

                if (txtletterdate.Text.Trim().Length > 0)
                {
                    string date_to_be = DateTime.ParseExact(txtletterdate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.letterdate = Convert.ToDateTime((date_to_be));
                }
                if (txtchangesinfar.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.changesinfar = decimal.Parse(txtchangesinfar.Text.Trim());
                }

                if (txtPayment.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.Payment = decimal.Parse(txtPayment.Text.Trim());
                }

                objServiceTimelinesBEL.excutionofdeed = txtexcutionofdeed.Text.Trim();
                objServiceTimelinesBEL.TEFStatus = ddltef.SelectedValue.Trim();

                objServiceTimelinesBEL.Operationalmaintenancecharges = ddlOperationalmaintenancecharges.SelectedValue.Trim();
                objServiceTimelinesBEL.diffproarea = ddlpossessionarea.SelectedValue.Trim();
                if (txtpossessionareadiff.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.possessionareadiff = decimal.Parse(txtpossessionareadiff.Text.Trim());
                }
                if (txtAmountrecover.Text.Trim().Length > 0)
                {
                    objServiceTimelinesBEL.Amountrecover = decimal.Parse(txtAmountrecover.Text.Trim());
                }

                //if (txtReservationPaymentAmount.Text.Trim().Length > 0)
                //{
                //    objServiceTimelinesBEL.ReservationPaymentAmount = float.Parse(txtReservationPaymentAmount.Text.Trim());
                //}
                #endregion
                int retVal = objServiceTimelinesBLL.InsertUpdateAllotteeDetails_step2(objServiceTimelinesBEL);
                DataTable temp = (DataTable)ViewState["temp_TEF_details"];
                if (temp.Rows.Count > 0)
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                        command.Connection = con;
                        command.Transaction = transaction;
                        bool transactionResult = true;
                        int allotteeiD = Convert.ToInt32(Session["AllotteeID"].ToString());
                        command = new SqlCommand(@"Delete from AllotteeTEFDetail where AllotteeID=" + allotteeiD + "", con, transaction);
                        transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                        if (temp.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in temp.Rows)
                            {
                                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
                                objServiceTimelinesBEL.TEFRefferenceNumber = (dr1["TEFRefferenceNumber"].ToString());
                                objServiceTimelinesBEL.TEFApprovalDate = Convert.ToDateTime(dr1["TEFApprovalDate"].ToString());

                                objServiceTimelinesBEL.TEFPeriod = Convert.ToInt32(dr1["TEFPeriod"].ToString());
                                objServiceTimelinesBEL.TEFFees = Convert.ToDecimal(dr1["TEFFees"].ToString());
                                objServiceTimelinesBEL.IsActive = 1;
                                objServiceTimelinesBEL.CreatedBy = UserName;
                                objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                                retVal = objServiceTimelinesBLL.InsertTEFDetails(objServiceTimelinesBEL);
                            }
                        }
                        if (retVal > 0)
                        {
                            if (transactionResult)
                            {
                                transaction.Commit();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('TEF detail Updated/Inserted Successfully.');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('TEF details couldn't be saved');", true);
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
                if (retVal > 0)
                {
                    string message = "Allottee detail Updated successfully.";
                    MessageBox1.ShowSuccess(message);
                    GetAllAllotteeDetailsFilledById(int.Parse(Session["AllotteeID"].ToString()));
                    MultiView1.ActiveViewIndex = 3;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Allottee details couldn't be saved');", true);

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
            // }

            ///////////////////////   End Of Update   ///////////////////////////// 
        }

        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }
            catch
            {
                return false;
            }
        }


        #region View Operation
        // First View Stage 

        #region Basic Details 
        protected void Previous_home_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        #endregion

        // Third View Stage (Allotted Plot Detail)

        #region  Allotted Plot Details
        protected void Previous_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        #endregion


        #region Project Details 

        protected void Previous5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void Next5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        #endregion

        #region Payment  Detail

        // Forth View Stage (Payment  Detail)
        protected void Previous1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void Next3_Click(object sender, EventArgs e)
        {

            //MultiView1.ActiveViewIndex = 4;
            MultiView1.ActiveViewIndex = 10;
            //bindPaymentDetailswithAmount();
            //bindPaymentRecivedwithAmount();
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        #endregion

        #region Dues Details
        protected void btnDuesPre_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void btnDuesNext_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = true;
        }

        #endregion

        #region Legal Details
        // Legal Details

        protected void btnLegalPrevious_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }

        protected void btnLegalNext_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = true;
            GetAllotteeDocumentDetail();

        }

        #endregion


        // All Information View Stage

        protected void Previous3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 10;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
            string value = Session["AllotteeID"] as string;

            if ((String.IsNullOrEmpty(value)))
            { }
            else
            {
                if (Session["AllotteeID"].ToString().Length > 0)
                {
                    GetAllAllotteeDetailsFilledById(int.Parse(Session["AllotteeID"].ToString()));
                }
                else
                {

                }
            }
        }


        // Document Details (Hidden)


        protected void Previous2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }


        protected void Next4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;

            string value = Session["AllotteeID"] as string;

            if ((String.IsNullOrEmpty(value)))
            { }
            else
            {
                if (Session["AllotteeID"].ToString().Length > 0)
                {
                    GetAllAllotteeDetailsFilledById(int.Parse(Session["AllotteeID"].ToString()));
                }
                else
                {

                }
            }

        }


        //  Project Details 

        protected void Previous4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }


        #endregion

        public void BindUploadedDocument()
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetBindUploadedDocument(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvuploaddoc.DataSource = ds;
                        gvuploaddoc.DataBind();
                    }
                    else
                    {
                        gvuploaddoc.DataSource = null;
                        gvuploaddoc.DataBind();
                    }
                    this.RegisterPostBackControl();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            temp_allotteeid_lbl.Text = "";

            if (e.CommandName == "ViewRow")
            {

                resetcom();

                int index = Convert.ToInt32(e.CommandArgument);
                temp_allotteeid_lbl.Text = index.ToString();
                SqlCommand cmd = new SqlCommand("spc_GetAllAllotteeDetailsByIdTemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AllotteeID", index);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                if (dt1.Rows.Count > 0)
                {
                    lblAllotmentLetterNo.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    lblAuthorisedSignatoryName.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                    lblCompany_firm.Text = dt1.Rows[0]["CompanyName"].ToString();
                    lblCompanyFirmConstitution.Text = dt1.Rows[0]["FirmConstitution"].ToString();
                    lblAuthorisedEmailId.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                    lblSignatoryMob.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                    LblSignatoryAddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
                    lblCompanyPan.Text = dt1.Rows[0]["PanNo"].ToString();
                    lblCompanyCin.Text = dt1.Rows[0]["CinNo"].ToString();
                    lblplot.Text = dt1.Rows[0]["PlotNo"].ToString();
                    LblindustrialArea.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                    LblallotmentLetterDate.Text = dt1.Rows[0]["DateofAllotmentNo"].ToString();

                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Individual/Sole Proprietorship firm")
                    {
                        Pgrid.Visible = true;
                        P1.InnerText = "Individual/Sole Proprietorship firm Details";
                        Pgrid.DataSource = dt2; Pgrid.DataBind();
                    }
                    else
                    {
                        Pgrid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Public Limited")
                    {
                        Dgrid.Visible = true;
                        P1.InnerText = "Directors Details";
                        Dgrid.DataSource = dt2; Dgrid.DataBind();
                    }
                    else
                    {
                        Dgrid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Private Limited")
                    {
                        Sgrid.Visible = true;
                        P1.InnerText = "ShareHolders Details";
                        Sgrid.DataSource = dt2; Sgrid.DataBind();
                    }
                    else
                    {
                        Sgrid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Partnership Firm")
                    {
                        ParGrid.Visible = true;
                        P1.InnerText = "Partners Details";
                        ParGrid.DataSource = dt2; ParGrid.DataBind();
                    }
                    else
                    {
                        ParGrid.Visible = false;
                    }

                    hrefPrint.Visible = false;
                    hrefPrint1.Visible = false;

                }

                getcommunicattiondetail();
                cmd.Dispose();

                MultiView1.ActiveViewIndex = 7;
            }




            if (e.CommandName == "EditRow")
            {

                Session["AllotteeID"] = "";
                allotteeID.Text = Session["AllotteeID"].ToString();

                GridViewRow row = GridView1.SelectedRow;
                int index = Convert.ToInt32(e.CommandArgument);
                try
                {
                    txtAllotteeRegisterID.Text = (Convert.ToInt32(GridView1.DataKeys[index].Value.ToString())).ToString();
                }
                catch
                {
                    txtAllotteeRegisterID.Text = "";
                }

                ViewState["AllotteeRegisterID"] = txtAllotteeRegisterID.Text;

                txtAllotment.Text = GridView1.Rows[index].Cells[1].Text;
                txtName.Text = GridView1.Rows[index].Cells[2].Text;
                txtEmailid.Text = GridView1.Rows[index].Cells[3].Text;
                txtPhone.Text = GridView1.Rows[index].Cells[4].Text;
                txtAllotteeAddress.Text = GridView1.Rows[index].Cells[5].Text;
                txtAllotteeAddress1.Text = GridView1.Rows[index].Cells[6].Text;
                txtFatherName.Text = GridView1.Rows[index].Cells[7].Text;
                txtPlotNo1.Text = GridView1.Rows[index].Cells[8].Text;
                txtIndustrialArea.Text = GridView1.Rows[index].Cells[9].Text;
                txtAddharcardNo.Text = GridView1.Rows[index].Cells[10].Text;
                txtDateofAllottementNo.Text = GridView1.Rows[index].Cells[11].Text;
                MultiView1.ActiveViewIndex = 1;
            }

            if (e.CommandName == "DeleteAllottee")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int AllotteeId = index;
                objServiceTimelinesBEL.dbId = AllotteeId;
                DataSet ds = new DataSet();
                ds = objServiceTimelinesBLL.GetPreServiceDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    MessageBox1.ShowInfo("Applicant Apply for Another Service so Records will not Deactivate ");
                    return;
                }
                else
                {
                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteAllotteeRecord(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Allottee Records  Deactivated ");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
                        }
                        else
                        {

                            MessageBox1.ShowError("Allottee  Cannot Be Deactivated!!!");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
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
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Allottee_master_grid.PageIndex = e.NewPageIndex;
            GetNewAllotteeDetails();
        }

        protected void gvuploaddoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string DocumentID;
                if (e.CommandName == "selectDocument")
                {
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    DataSet ds = new DataSet();
                    try
                    {
                        belBookDetails objServiceTimelinesBEL = new belBookDetails();
                        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                        objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
                        DocumentID = gvuploaddoc.DataKeys[rowIndex].Values["DocID"].ToString();
                        objServiceTimelinesBEL.DocumentID = DocumentID;
                        ds = objServiceTimelinesBLL.GetCheckListDocumentAllotteeRegistration(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];
                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }
                if (e.CommandName == "ViewDocument")
                {
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    DocumentID = gvuploaddoc.DataKeys[rowIndex].Values["DocID"].ToString();
                    Response.Write("<script>window.open ('DocViewerAllotteeDoc.aspx?AlloteeId=" + Session["AllotteeID"].ToString() + "&DocumentID=" + DocumentID +  "','_blank');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
       
        private void View(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "inline;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Bind DropDown

        protected void UserSpecificBinding()
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
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    Allottee_master_grid.Columns[14].Visible = true;
                    Allottee_master_grid.Columns[16].Visible = true;
                }
                else
                {
                    Allottee_master_grid.Columns[14].Visible = true;
                    Allottee_master_grid.Columns[15].Visible = false;
                    Allottee_master_grid.Columns[16].Visible = false;
                }
                if (dsR.Tables[3].Rows[0][0].ToString() == "unlock")
                {
                    Allottee_master_grid.Columns[15].Visible = true;
                }
                else
                {
                    Allottee_master_grid.Columns[15].Visible = false;
                }
                if (dsR.Tables[2].Rows[0][0].ToString().Trim() == "RM")
                {
                    btnLock.Visible = true;
                    btnUnlock.Visible = false;
                }
                else if (dsR.Tables[2].Rows[0][0].ToString().Trim() == "Admin1" || dsR.Tables[2].Rows[0][0].ToString().Trim() == "MD")
                {
                    btnLock.Visible = false;
                    btnUnlock.Visible = true;
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
        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            ddlArea.Items.Clear();

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }
            Refesh(true);
            
            //ddlArea.Items.Clear();           

            //try { bindDDLRegionNew(ddloffice.SelectedItem.Value, null); } catch { }

            
            ResetControl();

        }
        protected void PollutionCategoryBinding()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetPollutionCategoryBinding();
                drppollutionCategory.DataSource = dsR.Tables[0];
                drppollutionCategory.DataTextField = "PollutionCategory";
                drppollutionCategory.DataValueField = "ID";
                drppollutionCategory.DataBind();
                drppollutionCategory.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = "";
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }
                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }


                ddlArea.DataSource = ds;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                if (!string.IsNullOrEmpty(pIAName))
                {
                    ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(pIAName));
                }
                //try { ddlArea_SelectedIndexChanged(null, null); } catch { }


                GetNewAllotteeDetails();
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


        private void bindDDLRegionNew(string pOffice, string pIAName)
        {
            /*
            objServiceTimelinesBEL.RegionalOffice = "";
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet dsNew = new DataSet();
            try
            {
                dsNew = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                ddlArea.DataSource = dsNew;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                if (!string.IsNullOrEmpty(pIAName))
                {
                    ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(pIAName));
                }
                try { ddlArea_SelectedIndexChanged(null, null); } catch { }
                //GetNewAllotteeDetails();
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
            */
        }


        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Filter"] = drpdwnIA.SelectedItem.Text;
            GetNewAllotteeDetails();
            MultiView1.Visible = true;
            ResetControl();
        }
        
        private void bindSector(int IAID, string Sector)
        {
            objServiceTimelinesBEL.IAId = IAID;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSectorsIAWise(objServiceTimelinesBEL);
                drpdwnSector.DataSource = ds;
                drpdwnSector.DataTextField = "Sector_Name";
                drpdwnSector.DataValueField = "SectorID";
                drpdwnSector.DataBind();
                drpdwnSector.Items.Insert(0, new ListItem("--Select--", "0"));
                if (!string.IsNullOrEmpty(Sector))
                {
                    drpdwnSector.SelectedIndex = drpdwnSector.Items.IndexOf(drpdwnSector.Items.FindByText(Sector));
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        private void bindTypeOfIndustry()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTypeoFIndustry();
                ddlTypeOfIndustry.DataSource = ds;
                ddlTypeOfIndustry.DataTextField = "IndustrialClassificationName";
                ddlTypeOfIndustry.DataValueField = "ClassificationID";
                ddlTypeOfIndustry.DataBind();
                ddlTypeOfIndustry.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void bindProductCategory()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetProductCategory();
                ddl_ProductCategory.DataSource = ds;
                ddl_ProductCategory.DataTextField = "Product Category";
                ddl_ProductCategory.DataValueField = "HSC_2";
                ddl_ProductCategory.DataBind();
                ddl_ProductCategory.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region BindAlloteeGrid

        //public void GetNewAllotteeDetails()
        //{
        //    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        //    string Parameter = drpdwnIA.SelectedItem.Text.Trim();
        //    DataSet dsAllottee = new DataSet();
        //    try
        //    {
        //        dsAllottee = objServiceTimelinesBLL.GetNewAlloteeDetailwithParameter(Parameter);
        //        DataTable dt = dsAllottee.Tables[0];
        //        DataTable dt1 = dsAllottee.Tables[1];

        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();

        //        GridView1_pending_process.DataSource = dt1;
        //        GridView1_pending_process.DataBind();

        //        //  con.Open();
        //        string SearchString = txtSearch.Text;
        //        SqlCommand cmd2 = new SqlCommand("select AllotteeID, PlotNo as 'Plot No', FileNo as 'File No',  Allotmentletterno as 'Allotment No', CompanyName as 'Company Name' ,AuthorisedSignatory as 'Authorised Signatory', CONVERT(VARCHAR(10),AllotmentletterIssueDate, 103) as 'Allotment Date', Sector from AllotteeMaster where (Allotmentletterno like '%" + SearchString + "%' or  PlotNo	 like '%" + SearchString + "%'  or  FileNo	 like '%" + SearchString + "%'  or AuthorisedSignatory like '%" + SearchString + "%' or CompanyName like '%" + SearchString + "%' 	)  and  isnull(isCompleted,'false') = 'true' and IndustrialArea='" + Parameter + "' order by PlotNo ", con);
        //        SqlDataAdapter adp1 = new SqlDataAdapter(cmd2); DataTable dt11 = new DataTable(); adp1.Fill(dt11);
        //        Allottee_master_grid.DataSource = dt11; Allottee_master_grid.DataBind();
        //        ViewState["AllotteeMaster"] = dt11; ViewState["sortdr"] = "Asc"; //con.Close();

        //        //string SearchString = txtSearch.Text;
        //        //SqlCommand cmd2 = new SqlCommand("[spc_searchExistingAllottee] '" + drpdwnIA.SelectedValue.Trim() + "','" + txtSearch.Text.Trim() + "'", con);
        //        //SqlDataAdapter adp1 = new SqlDataAdapter(cmd2); DataTable dt11 = new DataTable(); adp1.Fill(dt11);
        //        //Allottee_master_grid.DataSource = dt11; Allottee_master_grid.DataBind();
        //        //ViewState["AllotteeMaster"] = dt11; ViewState["sortdr"] = "Asc"; //con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}
        public void GetNewAllotteeDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            string Parameter = drpdwnIA.SelectedItem.Text.Trim();
            DataSet dsAllottee = new DataSet();
            try
            {
                dsAllottee = objServiceTimelinesBLL.GetNewAlloteeDetailwithParameter(Parameter);
                DataTable dt = dsAllottee.Tables[0];
                DataTable dt1 = dsAllottee.Tables[1];
                GridView1_pending_process.DataSource = dt1;
                GridView1_pending_process.DataBind();
                objServiceTimelinesBEL.IndustrialArea = Parameter;
                DataSet dsCompletedList = new DataSet();
                dsCompletedList = objServiceTimelinesBLL.GetCompletedAlloteeDetail(objServiceTimelinesBEL);
                DataTable dt11 = dsCompletedList.Tables[0];
                Allottee_master_grid.DataSource = dt11;
                Allottee_master_grid.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
        }
       
        
        public void GetAllAllotteeDetailsFilledById(int AllotteeId)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.AllotteeID = AllotteeId;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllAllotteeDetailsFilledById(objServiceTimelinesBEL);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];
                DataTable dt4 = ds.Tables[3];
                DataTable dt5 = ds.Tables[4];
                DataTable dt6 = ds.Tables[6];
                DataTable dt7 = ds.Tables[7];
                DataTable dt9 = ds.Tables[9];
                //DataTable dt9 = ds.Tables[9];
                DataTable dt10 = ds.Tables[10];
                DataTable dt11 = ds.Tables[11];
                DataTable dt12 = ds.Tables[12];

                { GridView5.DataSource = dt4; GridView5.DataBind(); }

                { LegalGrid.DataSource = dt7; LegalGrid.DataBind(); }
                { GridView11.DataSource = dt7; GridView11.DataBind(); }
                { GridView13.DataSource = dt7; GridView13.DataBind(); }


                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {
                        Proprietar_Grid.Visible = true;
                        heading.InnerText = "Individual/Sole Proprietorship firm Details";
                        Proprietar_Grid.DataSource = dt1; Proprietar_Grid.DataBind();
                    }
                    else
                    {
                        Proprietar_Grid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {
                        Publiclimited_Grid.Visible = true;
                        heading.InnerText = "Directors Details";
                        Publiclimited_Grid.DataSource = dt5; Publiclimited_Grid.DataBind();
                    }
                    else
                    {
                        Publiclimited_Grid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {
                        PrivateGrid.Visible = true;
                        heading.InnerText = "ShareHolders Details";
                        PrivateGrid.DataSource = dt5; PrivateGrid.DataBind();
                    }
                    else
                    {
                        PrivateGrid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {
                        TrusteeGrid.Visible = true;
                        heading.InnerText = "Trustee Details";
                        TrusteeGrid.DataSource = dt5; TrusteeGrid.DataBind();
                    }
                    else
                    {
                        TrusteeGrid.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {
                        PartnershipGrid.Visible = true;
                        heading.InnerText = "Partners Details";
                        PartnershipGrid.DataSource = dt5; PartnershipGrid.DataBind();
                    }
                    else
                    {
                        PartnershipGrid.Visible = false;
                    }
                }

                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["IsLock"].ToString().Trim() == "True")
                    {

                        btnLock.Text = "Already Locked";
                        btnLock.Enabled = false;
                    }
                    else
                    {
                        btnLock.Text = "Lock Record";
                        btnLock.Enabled = true;
                    }

                    txtallotment_ref_no.Text = dt1.Rows[0]["ref_AllotmentNo"].ToString().Trim();
                    lblAllotmentRef.Text = dt1.Rows[0]["ref_AllotmentNo"].ToString().Trim();
                    lblAllotmentref1.Text = dt1.Rows[0]["ref_AllotmentNo"].ToString().Trim();
                    txtLeaseDeed_ref_no.Text = dt1.Rows[0]["ref_LeaseDeed"].ToString().Trim();
                    txtBuildingDate_ref_no.Text = dt1.Rows[0]["ref_BuildingPlan"].ToString().Trim();
                    txtcomcertificate_ref_no.Text = dt1.Rows[0]["ref_CompletionCertificate"].ToString().Trim();
                    txtReloccertificate_ref_no.Text = dt1.Rows[0]["ref_OccupancyCertificate"].ToString().Trim();
                    txtInspectionDate_ref_no.Text = dt1.Rows[0]["ref_ConstructionInspection"].ToString().Trim();
                    txtInspectioncompletion_ref_no.Text = dt1.Rows[0]["ref_CompletionInspection"].ToString().Trim();
                    txtAllotment1.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(dt1.Rows[0]["IndustrialArea"].ToString().Trim()));
                    try { bindSector(Convert.ToInt32(ddlArea.SelectedValue), null); } catch { }
                    txtAllotment1.Enabled = false;
                    ddlcompanytype.SelectedValue = dt1.Rows[0]["FirmConstitution"].ToString().Trim();
                    txtPlotNo.Text = dt1.Rows[0]["PlotNo"].ToString();
                    txtCompanyname.Text = dt1.Rows[0]["CompanyName"].ToString().Trim();
                    txtIndividualAddress.Text = dt1.Rows[0]["Address1"].ToString().Trim();
                    txtIndividualPhone.Text = dt1.Rows[0]["PhoneNo"].ToString().Trim();
                    txtIndividualEmail.Text = dt1.Rows[0]["emailID"].ToString().Trim();


                    txtFileNo.Text = dt1.Rows[0]["FileNo"].ToString().Trim();
                    txtPanNo.Text = dt1.Rows[0]["PanNo"].ToString().Trim();
                    txtCinNo.Text = dt1.Rows[0]["CinNo"].ToString().Trim();

                    txtGstNo.Text = dt1.Rows[0]["GSTNo"].ToString().Trim();
                    txtUdyogAdhar.Text = dt1.Rows[0]["UdyogAadharNo"].ToString().Trim();
                    txtAadharNo.Text = dt1.Rows[0]["AadharNo"].ToString().Trim();
                    if (dt1.Rows[0]["SectorID"].ToString().Trim() == "" || dt1.Rows[0]["SectorID"].ToString().Trim() == null)
                    {
                        drpdwnSector.SelectedIndex = 0;
                    }
                    else
                    {
                        drpdwnSector.SelectedValue = dt1.Rows[0]["SectorID"].ToString().Trim();
                        drpdwnSector_SelectedIndexChanged(null, null);

                    }
                    txtAuthorisedSignatory.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                    txtSignatoryAddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString().Trim();
                    txtSignatoryEmail.Text = dt1.Rows[0]["SignatoryEmail"].ToString().Trim();
                    txtSignatoryPhone.Text = dt1.Rows[0]["SignatoryPhone"].ToString().Trim();

                    //if (dt1.Rows[0]["Sector"].ToString().Trim() == "" || dt1.Rows[0]["Sector"].ToString().Trim() == null)
                    //{
                    //    ddlSector.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    ddlSector.SelectedValue = dt1.Rows[0]["Sector"].ToString().Trim();
                    //}
                    //if (dt1.Rows[0]["PlotNo"].ToString().Trim() == "" || dt1.Rows[0]["PlotNo"].ToString().Trim() == null)
                    //{
                    //    PlotDDl.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    PlotDDl.SelectedValue = dt1.Rows[0]["PlotNo"].ToString().Trim();
                    //}

                    lblSector.Text = dt1.Rows[0]["Sector"].ToString().Trim();
                    lblSector1.Text = dt1.Rows[0]["Sector"].ToString().Trim();
                    lblAuthoriseduseremail.Text = dt1.Rows[0]["SignatoryEmail"].ToString().Trim();
                    lblAuthoriseduseraddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString().Trim();
                    lblfileNo.Text = dt1.Rows[0]["FileNo"].ToString().Trim();
                    LblFileNo1.Text = dt1.Rows[0]["FileNo"].ToString().Trim();



                    //#region Dues Details
                    //lblAllotmentLetterNo.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    //lblLetterNumber.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    //lblIAName.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                    //lblDateofApplication.Text = dt1.Rows[0]["AllotmenttLetterApplicationDate"].ToString();
                    //lblPlotnumber.Text = dt1.Rows[0]["PlotNo"].ToString();


                    //lblAddress.Text = dt1.Rows[0]["Address"].ToString();
                    //lblSIgnatoryEmail.Text = dt1.Rows[0]["emailID"].ToString();
                    //lblSignatoryMobile.Text = dt1.Rows[0]["PhoneNo"].ToString();
                    //lblAllotteID.Text = Session["AllotteeID"].ToString();


                    //#endregion


                    if (dt5.Rows.Count > 0)
                    {

                        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                        {
                            tr2.Visible = true;
                            ViewState["temp_shareholder_details"] = dt5;
                            temp_shareholder_details_DataBind();
                        }
                        else
                        {
                            tr2.Visible = false;
                        }
                        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                        {
                            tr88.Visible = true;
                            ViewState["temp_partnership_details"] = dt5;
                            temp_partnership_details_DataBind();
                        }
                        else
                        {
                            tr88.Visible = false;
                        }
                        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                        {
                            tr4.Visible = true;
                            ViewState["temp_trustee_details"] = dt5;
                            temp_trustee_details_DataBind();
                        }
                        else
                        {
                            tr4.Visible = false;
                        }
                        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                        {
                            tr8.Visible = true;

                            ViewState["temp_directors_details"] = dt5;
                            temp_director_details_DataBind();
                        }
                        else
                        {
                            tr8.Visible = false;
                        }
                        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                        {
                            tr5.Visible = true;
                            tr6.Visible = true;
                            tr7.Visible = true;

                            txtIndividualName.Text = dt1.Rows[0]["AllotteeName"].ToString().Trim();
                            txtIndividualAddress.Text = dt1.Rows[0]["Address"].ToString().Trim();
                            txtIndividualEmail.Text = dt1.Rows[0]["emailID"].ToString().Trim();
                            txtIndividualPhone.Text = dt1.Rows[0]["PhoneNo"].ToString().Trim();

                        }
                        else
                        {
                            
                            chk2.Checked = false;
                            tr5.Visible = false;
                            tr6.Visible = false;
                            tr7.Visible = false;
                        }


                    }

                    lblletterno.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    Label11.Text = dt1.Rows[0]["Allotmentletterno"].ToString();
                    lblAuthorisedSignatory.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                    Label27.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
                    lblCompany.Text = dt1.Rows[0]["CompanyName"].ToString();
                    lblAuthorisedSignatory.Text = dt1.Rows[0]["CompanyName"].ToString();
                    Label23.Text = dt1.Rows[0]["CompanyName"].ToString();

                    lblConstitution.Text = dt1.Rows[0]["CompanyType"].ToString();
                    Label24.Text = dt1.Rows[0]["CompanyType"].ToString();

                    lblmobile.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
                    Label28.Text = dt1.Rows[0]["SignatoryPhone"].ToString();

                    Label29.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
                    lblPan.Text = dt1.Rows[0]["PanNo"].ToString();
                    lblCin.Text = dt1.Rows[0]["CinNo"].ToString();
                    lblPlotno.Text = dt1.Rows[0]["PlotNo"].ToString();
                    Label13.Text = dt1.Rows[0]["PlotNo"].ToString();
                    Label25.Text = dt1.Rows[0]["PanNo"].ToString();
                    lblindarea.Text = dt1.Rows[0]["IndustrialArea"].ToString();
                    Label14.Text = dt1.Rows[0]["IndustrialArea"].ToString();

                    lblallotmentdate.Text = dt1.Rows[0]["AllotmenttLetterApplicationDate"].ToString();
                    Label12.Text = dt1.Rows[0]["AllotmenttLetterApplicationDate"].ToString();

                    Label30.Text = dt1.Rows[0]["SignatoryAddress"].ToString();

                    Label26.Text = dt1.Rows[0]["CinNo"].ToString();
                }

                if (dt2.Rows.Count > 0)
                {
                    txtProductManufactured.Text = dt2.Rows[0]["ProductManufactured"].ToString();
                    txtTotalArea.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                    txttotalAreaPayment.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                    //lblplotarea.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                    txtalltLetterIssueDate.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();
                    txtLeaseDeed.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();




                    txtExecLeaseDeed.Text = dt2.Rows[0]["LeaseAgreementExecDate"].ToString();

                    txtBuildingDate.Text = dt2.Rows[0]["DateOfBuldingPlanSubmission"].ToString();
                    // txtReloccertificate.Text = dt2.Rows[0]["DateOfRequestForOccupancyCertificate"].ToString();
                    txtReloccertificate.Text = dt2.Rows[0]["DateOfReleaseForOccupancyCertificate"].ToString();
                    txtDateofAllottementNo.Text = dt2.Rows[0]["DateofAllotmentNo"].ToString();
                    txtDateCompletion.Text = dt2.Rows[0]["DateOfRequestForCompletion"].ToString();
                    txtcomcertificate.Text = dt2.Rows[0]["DateOfReleaseForCompletion"].ToString();


                    lbl_manufactured_product.Text = dt2.Rows[0]["ProductManufactured"].ToString();
                    lbl_alloted_parea.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                    lbltotalplotArea1.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();



                    lbl_allotment_issue_date.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();
                    lbl_lease_date.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();
                    lbl_lease_agreement_date.Text = dt2.Rows[0]["LeaseAgreementExecDate"].ToString();

                    lbl_date_of_bps.Text = dt2.Rows[0]["DateOfBuldingPlanSubmission"].ToString();

                    lbl_date_of_roc.Text = dt2.Rows[0]["DateOfReleaseForOccupancyCertificate"].ToString();
                    lbl_date_of_rel_completion.Text = dt2.Rows[0]["DateOfReleaseForCompletion"].ToString();


                    txtInspectionDate.Text = dt2.Rows[0]["InspectionDateForConstructionPermit"].ToString();
                    txtInspectioncompletion.Text = dt2.Rows[0]["InspectionDateForComplition"].ToString();
                    lbl_inspection_date_for_complition.Text = dt2.Rows[0]["InspectionDateForComplition"].ToString();
                    lbl_inspection_date.Text = dt2.Rows[0]["InspectionDateForConstructionPermit"].ToString();
                    lblPossessionDate.Text = dt2.Rows[0]["DateOfPossession"].ToString();

                    txtPossessiondate.Text = dt2.Rows[0]["DateOfPossession"].ToString();

                    txtPossessionArea.Text = dt2.Rows[0]["PossessionArea"].ToString();
                    lblPossessionArea.Text = dt2.Rows[0]["PossessionArea"].ToString();
                    lblRestorationRefDate.Text = dt2.Rows[0]["RestorationRefDate"].ToString();
                    lblRestorationRefDate1.Text = dt2.Rows[0]["RestorationRefDate"].ToString();


                    lblRestorationRefNo.Text = dt2.Rows[0]["RestorationRefNo"].ToString();
                    txtRestorationRefNo.Text = dt2.Rows[0]["RestorationRefNo"].ToString();
                    txtRestorationRefDate.Text = dt2.Rows[0]["RestorationRefDate"].ToString();
                    Label92.Text = dt2.Rows[0]["RestorationRefNo"].ToString();
                    //Label93.Text = dt2.Rows[0]["RestorationRefDate"].ToString();
                    Label90.Text = dt2.Rows[0]["DateOfPossession"].ToString();
                    Label91.Text = dt2.Rows[0]["PossessionArea"].ToString();
                    txtAllotmenttLetterApplicationDate.Text = dt2.Rows[0]["AllotmenttLetterApplicationDate"].ToString();
                    txtConstructionValueAtTimeofAllotment.Text = dt2.Rows[0]["ConstructionValueAtTimeofAllotment"].ToString();
                    Label52.Text = dt2.Rows[0]["ConstructionValueAtTimeofAllotment"].ToString();
                    Label89.Text = dt2.Rows[0]["ConstructionValueAtTimeofAllotment"].ToString();
                    txt_Lease_bookno.Text = dt2.Rows[0]["Lease_bookno"].ToString();
                    txt_Lease_bookbinding.Text = dt2.Rows[0]["Lease_bookbinding"].ToString();
                    txt_Lease_pagefrom.Text = dt2.Rows[0]["Lease_pagefrom"].ToString();
                    txt_Lease_pageto.Text = dt2.Rows[0]["Lease_pageto"].ToString();
                    txt_Lease_srno.Text = dt2.Rows[0]["Lease_srno"].ToString();
                    txtCertificateNo.Text = dt2.Rows[0]["CertificateNo"].ToString();
                    lblCertificateNo.Text = dt2.Rows[0]["CertificateNo"].ToString();
                    Label47.Text = dt2.Rows[0]["CertificateNo"].ToString();
                    txtIssueDate.Text = dt2.Rows[0]["IssueDate"].ToString();
                    lblIssueDate.Text = dt2.Rows[0]["IssueDate"].ToString();
                    Label48.Text = dt2.Rows[0]["IssueDate"].ToString();
                    txtstampDutyAmount.Text = dt2.Rows[0]["StampDutyAmount"].ToString();
                    lblStampDutyAmount.Text = dt2.Rows[0]["StampDutyAmount"].ToString();
                    Label49.Text = dt2.Rows[0]["StampDutyAmount"].ToString();
                    txtAccountReference.Text = dt2.Rows[0]["AccountReferenceNo"].ToString();
                    lblAccountReference.Text = dt2.Rows[0]["AccountReferenceNo"].ToString();
                    Label50.Text = dt2.Rows[0]["AccountReferenceNo"].ToString();
                    txtUniqueDocReference.Text = dt2.Rows[0]["UniqueDocRef"].ToString();
                    lblUniqueDocReference.Text = dt2.Rows[0]["UniqueDocRef"].ToString();
                    Label51.Text = dt2.Rows[0]["UniqueDocRef"].ToString();
                    txtGuaranteeNo.Text = dt2.Rows[0]["GuaranteNo"].ToString();
                    lblGuaranteeNo.Text = dt2.Rows[0]["GuaranteNo"].ToString();
                    Label53.Text = dt2.Rows[0]["GuaranteNo"].ToString();
                    txtGuaranteeAmount.Text = dt2.Rows[0]["GuaranteAmount"].ToString();
                    lblGuaranteeAmount.Text = dt2.Rows[0]["GuaranteAmount"].ToString();
                    Label82.Text = dt2.Rows[0]["GuaranteAmount"].ToString();

                    txtCoverFrom.Text = dt2.Rows[0]["GuarnteeCoverFrom"].ToString();
                    lblCoverFrom.Text = dt2.Rows[0]["GuarnteeCoverFrom"].ToString();

                    Label83.Text = dt2.Rows[0]["GuarnteeCoverFrom"].ToString();

                    txtCoverTo.Text = dt2.Rows[0]["GuaranteeCoverTo"].ToString();
                    lblCoverTo.Text = dt2.Rows[0]["GuaranteeCoverTo"].ToString();
                    Label84.Text = dt2.Rows[0]["GuaranteeCoverTo"].ToString();
                    txtLastDateClaim.Text = dt2.Rows[0]["LastDateOfClaim"].ToString();
                    lblLastDateOfClaim.Text = dt2.Rows[0]["LastDateOfClaim"].ToString();
                    Label85.Text = dt2.Rows[0]["LastDateOfClaim"].ToString();
                    txtPoposalLetter.Text = dt2.Rows[0]["BankProposalLetter"].ToString();
                    lblBankProposalLetter.Text = dt2.Rows[0]["BankProposalLetter"].ToString();
                    Label45.Text = dt2.Rows[0]["BankProposalLetter"].ToString();
                    txtSanctionLetter.Text = dt2.Rows[0]["BankSanctionLetter"].ToString();
                    lblBankSanctionLetter.Text = dt2.Rows[0]["BankSanctionLetter"].ToString();
                    Label46.Text = dt2.Rows[0]["BankSanctionLetter"].ToString();
                    txtSanctionLetterUpsidc.Text = dt2.Rows[0]["SanctionLetterUPSIDC"].ToString();
                    lblSanctionLetterUpsidc.Text = dt2.Rows[0]["SanctionLetterUPSIDC"].ToString();
                    Label86.Text = dt2.Rows[0]["SanctionLetterUPSIDC"].ToString();
                    txtNoOfStamp.Text = dt2.Rows[0]["NoOfStamp"].ToString();
                    lblNoOfStamp.Text = dt2.Rows[0]["NoOfStamp"].ToString();
                    Label87.Text = dt2.Rows[0]["NoOfStamp"].ToString();
                    txtStampAmoount.Text = dt2.Rows[0]["StampAmount"].ToString();
                    txtTotalStampDuty.Text = dt2.Rows[0]["TotalStampDuty"].ToString();
                    Label88.Text = dt2.Rows[0]["TotalStampDuty"].ToString();
                    lblTotalStampDuty.Text = dt2.Rows[0]["TotalStampDuty"].ToString();


                    lblBookNo.Text = dt2.Rows[0]["Lease_bookno"].ToString();
                    LblBookBinding.Text = dt2.Rows[0]["Lease_bookbinding"].ToString();

                    LblSNo.Text = dt2.Rows[0]["Lease_srno"].ToString();
                    Label31.Text = dt2.Rows[0]["ProductManufactured"].ToString();
                    //Label32.Text = dt2.Rows[0]["TotalAllottedplotArea"].ToString();
                    Label33.Text = dt2.Rows[0]["AllotmentletterIssueDate"].ToString();
                    Label34.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();
                    Label35.Text = dt2.Rows[0]["LeaseAgreementExecDate"].ToString();
                    Label36.Text = dt2.Rows[0]["DateOfBuldingPlanSubmission"].ToString();
                    Label37.Text = dt2.Rows[0]["DateOfReleaseForCompletion"].ToString();
                    Label38.Text = dt2.Rows[0]["DateOfReleaseForOccupancyCertificate"].ToString();
                    Label39.Text = dt2.Rows[0]["InspectionDateForConstructionPermit"].ToString();
                    Label40.Text = dt2.Rows[0]["InspectionDateForComplition"].ToString();
                    Label41.Text = dt2.Rows[0]["Lease_bookno"].ToString();
                    Label42.Text = dt2.Rows[0]["Lease_bookbinding"].ToString();
                    Label43.Text = dt2.Rows[0]["Lease_srno"].ToString();


                    lblChangeofProjectRefNo.Text = dt2.Rows[0]["ChangeOfProjectRefNo"].ToString();
                    lblChangeOfProjectRefNo1.Text = dt2.Rows[0]["ChangeOfProjectRefNo"].ToString();
                    txtChangeProjectRefNo.Text = dt2.Rows[0]["ChangeOfProjectRefNo"].ToString();
                    lblChangeofProjectRefDate.Text = dt2.Rows[0]["ChangeOfProjectRefDate"].ToString();
                    lblChangeOfProjectRefDate1.Text = dt2.Rows[0]["ChangeOfProjectRefDate"].ToString();
                    txtChangeProjectRefDate.Text = dt2.Rows[0]["ChangeOfProjectRefDate"].ToString();
                    lblAmalgamationRefNo.Text = dt2.Rows[0]["AmagaRefNo"].ToString();
                    lblAmalgamationRefNo1.Text = dt2.Rows[0]["AmagaRefNo"].ToString();
                    txtAmalgamationRefNo.Text = dt2.Rows[0]["AmagaRefNo"].ToString();
                    lblAmalgamationDate.Text = dt2.Rows[0]["AmagaRefDate"].ToString();
                    lblAmalgamationRefDate1.Text = dt2.Rows[0]["AmagaRefDate"].ToString();
                    txtAmalgamationRefDate.Text = dt2.Rows[0]["AmagaRefDate"].ToString();
                    lblSubDivRefNo.Text = dt2.Rows[0]["SubDivRefNo"].ToString();
                    lblSubDivRefNo1.Text = dt2.Rows[0]["SubDivRefNo"].ToString();
                    txtSubDivRefNo.Text = dt2.Rows[0]["SubDivRefNo"].ToString();
                    lblSubDivRefDate.Text = dt2.Rows[0]["SubDivRefDate"].ToString();
                    lblSubDivRefDate1.Text = dt2.Rows[0]["SubDivRefDate"].ToString();
                    txtSubDivRefDate.Text = dt2.Rows[0]["SubDivRefDate"].ToString();
                    lblSublettingRefNo.Text = dt2.Rows[0]["SublettingRefNo"].ToString();
                    lblSublettingRefNo1.Text = dt2.Rows[0]["SublettingRefNo"].ToString();
                    txtSublettingRefNo.Text = dt2.Rows[0]["SublettingRefNo"].ToString();
                    lblSublettingRefDate.Text = dt2.Rows[0]["SublettingRefDate"].ToString();
                    lblSublettingRefDate1.Text = dt2.Rows[0]["SublettingRefDate"].ToString();
                    txtSublettingRefDate.Text = dt2.Rows[0]["SublettingRefDate"].ToString();
                    lblDateOfAgreement.Text = dt2.Rows[0]["DateOfAgreement"].ToString();
                    lblAgreementDate1.Text = dt2.Rows[0]["DateOfAgreement"].ToString();
                    txtAgreementDate.Text = dt2.Rows[0]["DateOfAgreement"].ToString();
                    lblDateOfAgreementExec.Text = dt2.Rows[0]["DateOfExecutionAgreement"].ToString();
                    lblAgreementExecDate1.Text = dt2.Rows[0]["DateOfExecutionAgreement"].ToString();
                    txtAgreementExecDate.Text = dt2.Rows[0]["DateOfExecutionAgreement"].ToString();
                    lblAgreementOnPlotSize.Text = dt2.Rows[0]["AgreementOnPlotSize"].ToString();
                    lblAgreementOn.Text = dt2.Rows[0]["AgreementOnPlotSize"].ToString();
                    txtAgreementPlotSize.Text = dt2.Rows[0]["AgreementOnPlotSize"].ToString();
                    txtSublettingPartyName.Text = dt2.Rows[0]["SublettingPartyName"].ToString();
                    lblSublettingPartyName.Text = dt2.Rows[0]["SublettingPartyName"].ToString();
                    lblSublettingPartyName1.Text = dt2.Rows[0]["SublettingPartyName"].ToString();
                    txtSublettingArea.Text = dt2.Rows[0]["SublettingArea"].ToString();
                    lblSubleetingArea.Text = dt2.Rows[0]["SublettingArea"].ToString();
                    lblSublettingArea1.Text = dt2.Rows[0]["SublettingArea"].ToString();
                    txtSublettingYears.Text = dt2.Rows[0]["SublettingYear"].ToString();
                    lblSublettingYears.Text = dt2.Rows[0]["SublettingYear"].ToString();
                    lblSublettingYears1.Text = dt2.Rows[0]["SublettingYear"].ToString();
                    txtSublettingProjectName.Text = dt2.Rows[0]["SublettingProjectName"].ToString();
                    lblSublettingProjectName.Text = dt2.Rows[0]["SublettingProjectName"].ToString();
                    lblSublettingProjectName1.Text = dt2.Rows[0]["SublettingProjectName"].ToString();
                    lblCaseType.Text = dt2.Rows[0]["CaseType"].ToString();
                    lblCaseType1.Text = dt2.Rows[0]["CaseType"].ToString();
                    txtfirstAllotmentDate.Text = dt1.Rows[0]["firstAllotmentDate"].ToString().Trim();
                    txtAllotmentreferencenumber.Text = dt1.Rows[0]["Allotmentreferencenumber"].ToString().Trim();
                    #region Code By Manish

                    //if (lblPlotUniqueID.Text == "")
                    //{
                    //    GisPlotMaster.Visible = true;
                    //}
                    //else
                    //{
                    //    GisPlotMaster.Visible = false;
                    //}

                    txtAllotmentRate.Text = dt2.Rows[0]["AllotmentRate"].ToString();
                    lblAllotmentRate.Text = dt2.Rows[0]["AllotmentRate"].ToString();
                    lblAllotmentRate1.Text = dt2.Rows[0]["AllotmentRate"].ToString();

                    txtlocationcharge.Text = dt2.Rows[0]["LocationCharge"].ToString();
                    lblLocationCharge.Text = dt2.Rows[0]["LocationCharge"].ToString();
                    lblLocationCharge1.Text = dt2.Rows[0]["LocationCharge"].ToString();

                    txtInterestRateApplicable.Text = dt2.Rows[0]["InterestRateApplicable"].ToString();
                    lblInterestRateApplicable.Text = dt2.Rows[0]["InterestRateApplicable"].ToString();
                    lblInterestRateApplicable1.Text = dt2.Rows[0]["InterestRateApplicable"].ToString();

                    txtPanelRateApplicable.Text = dt2.Rows[0]["PanalInterest"].ToString();
                    lblPanelRateApplicable.Text = dt2.Rows[0]["PanalInterest"].ToString();
                    txtPanelRateApplicable.Text = lblPanelRateApplicable.Text;

                    txtGroundCoverage.Text = dt2.Rows[0]["GroundCoverage"].ToString();
                    lblGroundCoverage.Text = dt2.Rows[0]["GroundCoverage"].ToString();
                    lblGroundCoverage1.Text = dt2.Rows[0]["GroundCoverage"].ToString();


                    txtPermisableFAR.Text = dt2.Rows[0]["PermisableFAR"].ToString();
                    lblPermisableFAR.Text = dt2.Rows[0]["PermisableFAR"].ToString();

                    txtothercharges.Text = dt2.Rows[0]["OtherCharges"].ToString();
                    lblothercharges.Text = dt2.Rows[0]["OtherCharges"].ToString();
                    lblothercharges1.Text = dt2.Rows[0]["OtherCharges"].ToString();

                    txtCompoundingCharges.Text = dt2.Rows[0]["CompoundingCharges"].ToString();
                    lblCompoundingCharges.Text = dt2.Rows[0]["CompoundingCharges"].ToString();
                    lblCompoundingCharges1.Text = dt2.Rows[0]["CompoundingCharges"].ToString();

                    txtRestorationLevy.Text = dt2.Rows[0]["RestorationLevy"].ToString();
                    lblRestorationLevy.Text = dt2.Rows[0]["RestorationLevy"].ToString();
                    lblRestorationLevy1.Text = dt2.Rows[0]["RestorationLevy"].ToString();

                    txtDeedafterRestoration.Text = dt2.Rows[0]["DeedafterRestoration"].ToString();
                    lblDeedafterRestoration.Text = dt2.Rows[0]["DeedafterRestoration"].ToString();
                    lblDeedafterRestoration1.Text = dt2.Rows[0]["DeedafterRestoration"].ToString();

                    txtAdditionalChargesforplot.Text = dt2.Rows[0]["AdditionalChargesforplot"].ToString();
                    lblAdditionalChargesforplot.Text = dt2.Rows[0]["AdditionalChargesforplot"].ToString();
                    lblAdditionalChargesforplot1.Text = dt2.Rows[0]["AdditionalChargesforplot"].ToString();

                    txtDeedafterChangeofPlot.Text = dt2.Rows[0]["DeedafterChangeofPlot"].ToString();
                    lblDeedafterChangeofPlot.Text = dt2.Rows[0]["DeedafterChangeofPlot"].ToString();
                    lblDeedafterChangeofPlot1.Text = dt2.Rows[0]["DeedafterChangeofPlot"].ToString();

                    txtChangeforChanges.Text = dt2.Rows[0]["ChangeforChanges"].ToString();
                    lblChangeforChanges.Text = dt2.Rows[0]["ChangeforChanges"].ToString();
                    lblChangeforChanges1.Text = dt2.Rows[0]["ChangeforChanges"].ToString();

                    txtincreaseofFAR.Text = dt2.Rows[0]["increaseofFAR"].ToString();
                    lblincreaseofFAR.Text = dt2.Rows[0]["increaseofFAR"].ToString();
                    lblincreaseofFAR1.Text = dt2.Rows[0]["increaseofFAR"].ToString();

                    txtAmalgamationFees.Text = dt2.Rows[0]["AmalgamationFees"].ToString();
                    lblAmalgamationFees.Text = dt2.Rows[0]["AmalgamationFees"].ToString();


                    txtUsabilityFees.Text = dt2.Rows[0]["UsabilityFees"].ToString();
                    lblUsabilityFees.Text = dt2.Rows[0]["UsabilityFees"].ToString();


                    txtRectificationDeedDate.Text = dt2.Rows[0]["RectificationDeedDate"].ToString();
                    lblRectificationDeedDate.Text = dt2.Rows[0]["RectificationDeedDate"].ToString();

                    txtSubDivType.Text = dt2.Rows[0]["SubDivType"].ToString();
                    lblSubDivType.Text = dt2.Rows[0]["SubDivType"].ToString();

                    txtNoofPlotCreated.Text = dt2.Rows[0]["NoofPlotCreated"].ToString();
                    lblNoofPlotCreated.Text = dt2.Rows[0]["NoofPlotCreated"].ToString();


                    txtExtensionCharges.Text = dt2.Rows[0]["ExtensionCharges"].ToString();
                    lblExtensionCharges.Text = dt2.Rows[0]["ExtensionCharges"].ToString();

                    txtSubDivCharges.Text = dt2.Rows[0]["SubDivCharges"].ToString();
                    lblSubDivCharges.Text = dt2.Rows[0]["SubDivCharges"].ToString();

                    txtSublettingCharge.Text = dt2.Rows[0]["SublettingCharge"].ToString();
                    lblSublettingCharge.Text = dt2.Rows[0]["SublettingCharge"].ToString();

                    timePeriod.Text = dt2.Rows[0]["timePeriod"].ToString();
                    lbltimePeriod.Text = dt2.Rows[0]["timePeriod"].ToString();

                    txtTimeextensionWaiverfrom.Text = dt2.Rows[0]["TimeextensionWaiverfrom"].ToString();
                    lblTimeextensionWaiverfrom.Text = dt2.Rows[0]["TimeextensionWaiverfrom"].ToString();


                    txtTimeextensionWaiverTo.Text = dt2.Rows[0]["TimeextensionWaiverTo"].ToString();
                    lblTimeextensionWaiverTo.Text = dt2.Rows[0]["TimeextensionWaiverTo"].ToString();

                    txtInttonTimeextension.Text = dt2.Rows[0]["InttonTimeextension"].ToString();
                    lblInttonTimeextension.Text = dt2.Rows[0]["InttonTimeextension"].ToString();


                    txtbalancedues.Text = dt2.Rows[0]["Inttonbalancedues"].ToString();
                    lblbalancedues.Text = dt2.Rows[0]["Inttonbalancedues"].ToString();

                    txtMaintenanceChargesWaiver.Text = dt2.Rows[0]["MaintenanceChargesWaiver"].ToString();
                    lblMaintenanceChargesWaiver.Text = dt2.Rows[0]["MaintenanceChargesWaiver"].ToString();

                    dateofIncreaseinfar.Text = dt2.Rows[0]["dateofIncreaseinfar"].ToString();
                    lbldateofIncreaseinfar.Text = dt2.Rows[0]["dateofIncreaseinfar"].ToString();


                    txtletternumber.Text = dt2.Rows[0]["letternumber"].ToString();
                    lblfarletternumber.Text = dt2.Rows[0]["letternumber"].ToString();

                    txtletterdate.Text = dt2.Rows[0]["letterdate"].ToString();
                    lblletterdate.Text = dt2.Rows[0]["letterdate"].ToString();


                    txtchangesinfar.Text = dt2.Rows[0]["changesinfar"].ToString();
                    lblchangesinfar.Text = dt2.Rows[0]["changesinfar"].ToString();


                    txtPayment.Text = dt2.Rows[0]["increasefARPayment"].ToString();
                    lblPayment.Text = dt2.Rows[0]["increasefARPayment"].ToString();

                    txtexcutionofdeed.Text = dt2.Rows[0]["excutionofdeedafterFAR"].ToString();
                    lblexcutionofdeed.Text = dt2.Rows[0]["excutionofdeedafterFAR"].ToString();

                    txtReservationPaymentDate.Text = dt2.Rows[0]["ReservationMoneydate"].ToString();
                    lblReservationMoneyPaymentDate.Text = dt2.Rows[0]["ReservationMoneydate"].ToString();
                    lblReservationMoneyPaymentDate1.Text = dt2.Rows[0]["ReservationMoneydate"].ToString();



                    txtReservationPaymentAmount.Text = dt2.Rows[0]["ReservationAmount"].ToString();
                    lblReservationMoneyPaymentAmount.Text = dt2.Rows[0]["ReservationAmount"].ToString();
                    lblReservationMoneyPaymentAmount1.Text = dt2.Rows[0]["ReservationAmount"].ToString();


                    txtPhysicalPossessionDate.Text = dt2.Rows[0]["PhysicalPossessiondate"].ToString();

                    lblReservationMoneyStatus.Text = dt2.Rows[0]["ReservationStatus1"].ToString().Trim();
                    lblOperationalmaintenance.Text = dt2.Rows[0]["maintenancechargesApplicableStatus"].ToString().Trim();
                    lblLeaseDeedStatus.Text = dt2.Rows[0]["LeasedeedStatus1"].ToString().Trim();
                    lblPossessionLetterStatus.Text = dt2.Rows[0]["PhysicalPossessionStatus1"].ToString().Trim();
                    lbldifferentareapossession.Text = dt2.Rows[0]["possessionareadiff"].ToString().Trim();
                    lblAmountadjusted.Text = dt2.Rows[0]["Amountrecover"].ToString().Trim();
                    lblBuildingPlanStatus.Text = dt2.Rows[0]["BuildingPlanDetailsStatus1"].ToString().Trim();
                    lblChangeofProject1.Text = dt2.Rows[0]["ChangeofProjectStatus1"].ToString().Trim();
                    Label32.Text = dt2.Rows[0]["AmalgamationStatus1"].ToString().Trim();
                    Label93.Text = dt2.Rows[0]["SubDivisionStatus1"].ToString().Trim();
                    Label94.Text = dt2.Rows[0]["SublettingStatus1"].ToString().Trim();
                    Label95.Text = dt2.Rows[0]["AgreementStatus1"].ToString().Trim();
                    Label96.Text = dt2.Rows[0]["EStampStatus1"].ToString().Trim();
                    Label97.Text = dt2.Rows[0]["BankGuarantee1"].ToString().Trim();
                    Label98.Text = dt2.Rows[0]["MortgageStatus1"].ToString().Trim();

                    if (dt2.Rows[0]["maintenancechargesApplicable"].ToString().Trim() == "0" || dt2.Rows[0]["maintenancechargesApplicable"].ToString().Trim() == "" || dt2.Rows[0]["maintenancechargesApplicable"].ToString().Trim() == null)
                    {
                        ddlOperationalmaintenancecharges.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlOperationalmaintenancecharges.SelectedValue = dt2.Rows[0]["maintenancechargesApplicable"].ToString().Trim();
                    }

                    if (dt2.Rows[0]["ReservationStatus"].ToString().Trim() == "0" || dt2.Rows[0]["ReservationStatus"].ToString().Trim() == "" || dt2.Rows[0]["ReservationStatus"].ToString().Trim() == null)
                    {
                        ddlReservationmoney.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlReservationmoney.SelectedValue = dt2.Rows[0]["ReservationStatus"].ToString().Trim();
                        if (ddlReservationmoney.SelectedValue == "True")
                        {
                            ReservationMoney.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            ReservationMoney.Visible = false;
                        }
                    }
                    if (txtLeaseDeed.Text == "")
                    {
                        LeaseDeed.Visible = false;
                    }
                    else
                    {
                        ddlLeaseDeedSigned.SelectedValue = "True";
                        LeaseDeed.Visible = true;

                    }

                    if (txtPossessiondate.Text == "")
                    {
                        Possession.Visible = false;
                    }
                    else
                    {
                        ddlPossessionLetter.SelectedValue = "True";
                        Possession.Visible = true;

                    }

                    if (txtPhysicalPossessionDate.Text == "")
                    {
                        PhysicalPossession.Visible = false;
                    }
                    else
                    {
                        ddlPhysicalPossession.SelectedValue = "True";
                        PhysicalPossession.Visible = true;

                    }


                    if (txtBuildingDate.Text == "")
                    {
                        BuildingPlan.Visible = false;
                    }
                    else
                    {
                        ddlBuildingPlan.SelectedValue = "True";
                        BuildingPlan.Visible = true;

                    }
                    if (txtRestorationRefNo.Text == "")
                    {
                        Restoration.Visible = false;
                    }
                    else
                    {
                        ddlRestoration.SelectedValue = "True";
                        Restoration.Visible = true;

                    }

                    if (txtChangeProjectRefDate.Text == "")
                    {
                        ChangeofProject.Visible = false;
                    }
                    else
                    {
                        ddlChangeofProject.SelectedValue = "True";
                        ChangeofProject.Visible = true;

                    }

                    if (txtAmalgamationRefDate.Text == "")
                    {
                        Amalgamation.Visible = false;
                    }
                    else
                    {
                        ddlAmalgamation.SelectedValue = "True";
                        Amalgamation.Visible = true;

                    }

                    if (txtSubDivRefDate.Text == "")
                    {
                        SubDivision.Visible = false;
                    }
                    else
                    {
                        ddlSubDivision.SelectedValue = "True";
                        SubDivision.Visible = true;

                    }

                    if (txtSublettingRefDate.Text == "")
                    {
                        Subletting.Visible = false;
                    }
                    else
                    {
                        ddlSubletting.SelectedValue = "True";
                        Subletting.Visible = true;

                    }

                    if (txtAgreementDate.Text == "")
                    {
                        Agreement.Visible = false;
                    }
                    else
                    {
                        ddlAgreement.SelectedValue = "True";
                        Agreement.Visible = true;

                    }

                    if (txtIssueDate.Text == "")
                    {
                        EStamp.Visible = false;
                    }
                    else
                    {
                        ddlEStamp.SelectedValue = "True";
                        EStamp.Visible = true;

                    }

                    if (txtGuaranteeNo.Text == "")
                    {
                        BankGuarantee.Visible = false;
                    }
                    else
                    {
                        ddlBankGuarantee.SelectedValue = "True";
                        BankGuarantee.Visible = true;

                    }

                    if (txtPoposalLetter.Text == "")
                    {
                        Mortgage.Visible = false;
                    }
                    else
                    {
                        ddlMortgage.SelectedValue = "True";
                        Mortgage.Visible = true;

                    }

                    if (dt2.Rows[0]["LeasedeedStatus"].ToString().Trim() == "0" || dt2.Rows[0]["LeasedeedStatus"].ToString().Trim() == "" || dt2.Rows[0]["LeasedeedStatus"].ToString().Trim() == null)
                    {
                        ddlLeaseDeedSigned.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlLeaseDeedSigned.SelectedValue = dt2.Rows[0]["LeasedeedStatus"].ToString().Trim();
                        if (ddlLeaseDeedSigned.SelectedValue == "True")
                        {
                            LeaseDeed.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            LeaseDeed.Visible = false;
                        }
                    }
                    if (dt2.Rows[0]["PossessionLetterStatus"].ToString().Trim() == "0" || dt2.Rows[0]["PossessionLetterStatus"].ToString().Trim() == "" || dt2.Rows[0]["PossessionLetterStatus"].ToString().Trim() == null)
                    {
                        ddlPossessionLetter.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlPossessionLetter.SelectedValue = dt2.Rows[0]["PossessionLetterStatus"].ToString().Trim();
                        if (ddlPossessionLetter.SelectedValue == "True")
                        {
                            Possession.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            Possession.Visible = false;
                        }
                    }
                    if (dt2.Rows[0]["PhysicalPossessionStatus"].ToString().Trim() == "0" || dt2.Rows[0]["PhysicalPossessionStatus"].ToString().Trim() == "" || dt2.Rows[0]["PhysicalPossessionStatus"].ToString().Trim() == null)
                    {
                        ddlPhysicalPossession.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlPhysicalPossession.SelectedValue = dt2.Rows[0]["PhysicalPossessionStatus"].ToString().Trim();

                        if (ddlPhysicalPossession.SelectedValue == "True")
                        {
                            PhysicalPossession.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            PhysicalPossession.Visible = false;
                        }
                    }
                    if (dt2.Rows[0]["BuildingPlanDetailsStatus"].ToString().Trim() == "0" || dt2.Rows[0]["BuildingPlanDetailsStatus"].ToString().Trim() == "" || dt2.Rows[0]["BuildingPlanDetailsStatus"].ToString().Trim() == null)
                    {
                        ddlBuildingPlan.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlBuildingPlan.SelectedValue = dt2.Rows[0]["BuildingPlanDetailsStatus"].ToString().Trim();
                        if (ddlBuildingPlan.SelectedValue == "True")
                        {
                            BuildingPlan.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            BuildingPlan.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["RestorationStatus"].ToString().Trim() == "0" || dt2.Rows[0]["RestorationStatus"].ToString().Trim() == "" || dt2.Rows[0]["RestorationStatus"].ToString().Trim() == null)
                    {
                        ddlRestoration.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlRestoration.SelectedValue = dt2.Rows[0]["RestorationStatus"].ToString().Trim();
                        if (ddlRestoration.SelectedValue == "True")
                        {
                            Restoration.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            Restoration.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["ChangeofProjectStatus"].ToString().Trim() == "0" || dt2.Rows[0]["ChangeofProjectStatus"].ToString().Trim() == "" || dt2.Rows[0]["ChangeofProjectStatus"].ToString().Trim() == null)
                    {
                        ddlChangeofProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlChangeofProject.SelectedValue = dt2.Rows[0]["ChangeofProjectStatus"].ToString().Trim();
                        if (ddlChangeofProject.SelectedValue == "True")
                        {
                            ChangeofProject.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            ChangeofProject.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["AmalgamationStatus"].ToString().Trim() == "0" || dt2.Rows[0]["AmalgamationStatus"].ToString().Trim() == "" || dt2.Rows[0]["AmalgamationStatus"].ToString().Trim() == null)
                    {
                        ddlAmalgamation.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlAmalgamation.SelectedValue = dt2.Rows[0]["AmalgamationStatus"].ToString().Trim();
                        if (ddlAmalgamation.SelectedValue == "True")
                        {
                            Amalgamation.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            Amalgamation.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["SubDivisionStatus"].ToString().Trim() == "0" || dt2.Rows[0]["SubDivisionStatus"].ToString().Trim() == "" || dt2.Rows[0]["SubDivisionStatus"].ToString().Trim() == null)
                    {
                        ddlSubDivision.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlSubDivision.SelectedValue = dt2.Rows[0]["SubDivisionStatus"].ToString().Trim();
                        if (ddlSubDivision.SelectedValue == "True")
                        {
                            SubDivision.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            SubDivision.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["SublettingStatus"].ToString().Trim() == "0" || dt2.Rows[0]["SublettingStatus"].ToString().Trim() == "" || dt2.Rows[0]["SublettingStatus"].ToString().Trim() == null)
                    {
                        ddlSubletting.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlSubletting.SelectedValue = dt2.Rows[0]["SublettingStatus"].ToString().Trim();
                        if (ddlSubletting.SelectedValue == "True")
                        {
                            Subletting.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            Subletting.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["EStampStatus"].ToString().Trim() == "0" || dt2.Rows[0]["EStampStatus"].ToString().Trim() == "" || dt2.Rows[0]["EStampStatus"].ToString().Trim() == null)
                    {
                        ddlEStamp.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlEStamp.SelectedValue = dt2.Rows[0]["EStampStatus"].ToString().Trim();
                        if (ddlEStamp.SelectedValue == "True")
                        {
                            EStamp.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            EStamp.Visible = false;
                        }

                    }

                    if (dt2.Rows[0]["BankGuarantee"].ToString().Trim() == "0" || dt2.Rows[0]["BankGuarantee"].ToString().Trim() == "" || dt2.Rows[0]["BankGuarantee"].ToString().Trim() == null)
                    {
                        ddlBankGuarantee.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlBankGuarantee.SelectedValue = dt2.Rows[0]["BankGuarantee"].ToString().Trim();
                        if (ddlBankGuarantee.SelectedValue == "True")
                        {
                            BankGuarantee.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            BankGuarantee.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["MortgageStatus"].ToString().Trim() == "0" || dt2.Rows[0]["MortgageStatus"].ToString().Trim() == "" || dt2.Rows[0]["MortgageStatus"].ToString().Trim() == null)
                    {
                        ddlMortgage.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlMortgage.SelectedValue = dt2.Rows[0]["MortgageStatus"].ToString().Trim();
                        if (ddlMortgage.SelectedValue == "True")
                        {
                            Mortgage.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            Mortgage.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["InstallmentStatus"].ToString().Trim() == "0" || dt2.Rows[0]["InstallmentStatus"].ToString().Trim() == "" || dt2.Rows[0]["InstallmentStatus"].ToString().Trim() == null)
                    {
                        ddlInstalment.SelectedIndex = 0;
                        Instalmentpaid.Visible = true;
                    }
                    else
                    {
                        ddlInstalment.SelectedValue = dt2.Rows[0]["InstallmentStatus"].ToString().Trim();
                        if (ddlInstalment.SelectedValue == "True")
                        {
                            Instalmentpaid.Visible = false;
                            //bindTransfercase();
                        }
                        else
                        {
                            Instalmentpaid.Visible = true;
                        }
                    }

                    if (dt2.Rows[0]["interestWaiverStatus"].ToString().Trim() == "0" || dt2.Rows[0]["interestWaiverStatus"].ToString().Trim() == "" || dt2.Rows[0]["interestWaiverStatus"].ToString().Trim() == null)
                    {
                        ddlinterestWaiver.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlinterestWaiver.SelectedValue = dt2.Rows[0]["interestWaiverStatus"].ToString().Trim();
                        if (ddlinterestWaiver.SelectedValue == "True")
                        {
                            interestWaiver.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            interestWaiver.Visible = false;
                        }
                    }

                    if (dt2.Rows[0]["increaseinfarStatus"].ToString().Trim() == "0" || dt2.Rows[0]["increaseinfarStatus"].ToString().Trim() == "" || dt2.Rows[0]["increaseinfarStatus"].ToString().Trim() == null)
                    {
                        ddlincreaseinfar.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlincreaseinfar.SelectedValue = dt2.Rows[0]["increaseinfarStatus"].ToString().Trim();
                        if (ddlincreaseinfar.SelectedValue == "True")
                        {
                            increaseinfar.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            increaseinfar.Visible = false;
                        }
                    }
                    if (dt2.Rows[0]["tefStatus"].ToString().Trim() == "0" || dt2.Rows[0]["tefStatus"].ToString().Trim() == "" || dt2.Rows[0]["tefStatus"].ToString().Trim() == null)
                    {
                        ddltef.SelectedIndex = 0;
                    }
                    else
                    {
                        ddltef.SelectedValue = dt2.Rows[0]["tefStatus"].ToString().Trim();
                        if (ddltef.SelectedValue == "True")
                        {
                            DivTEF.Visible = true;
                            //bindTransfercase();
                        }
                        else
                        {
                            DivTEF.Visible = false;
                        }
                    }


                    #endregion


                    if (dt2.Rows[0]["CaseType"].ToString().Trim() == "0" || dt2.Rows[0]["CaseType"].ToString().Trim() == "" || dt2.Rows[0]["CaseType"].ToString().Trim() == null)
                    {
                        DdlCaseType.SelectedIndex = 0;
                    }
                    else
                    {
                        DdlCaseType.SelectedValue = dt2.Rows[0]["CaseType"].ToString().Trim();
                    }

                    if (lblCaseType.Text == "Transfer Case")
                    {

                        Case1.Visible = true;
                        Case2.Visible = true;
                        Case3.Visible = true;
                        tccase.Visible = true;
                        bindTransfercase();
                        if (dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == "0" || dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == "" || dt2.Rows[0]["TransferLevyCase"].ToString().Trim() == null)
                        {
                            ddlTranserCase.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlTranserCase.SelectedValue = dt2.Rows[0]["TransferLevyCase"].ToString().Trim();
                        }
                        LblTransferCase1.Text = dt2.Rows[0]["TransferLevyCase1"].ToString().Trim();
                        lblTransferLevy.Text = dt2.Rows[0]["TransferLevyCase1"].ToString().Trim();
                        lblPendingdues.Text = dt2.Rows[0]["PrevAlloteeDues"].ToString().Trim();
                        lblPendingDues1.Text = dt2.Rows[0]["PrevAlloteeDues"].ToString().Trim();
                        txtCarry.Text = dt2.Rows[0]["PrevAlloteeDues"].ToString().Trim();
                        lblDateofFirstAllotment.Text = dt1.Rows[0]["firstAllotmentDate"].ToString().Trim();
                        lblAllotmentreferencenumber.Text = dt1.Rows[0]["Allotmentreferencenumber"].ToString().Trim();

                    }
                    else if (lblCaseType.Text == "Change of Plot")
                    {
                        ChangeofPlot.Visible = true;
                        Changeofplot1.Visible = true;
                        Case1.Visible = false;
                        Case2.Visible = false;
                        Case3.Visible = false;
                        tccase.Visible = true;
                        ddlTranserCase.ClearSelection();
                        LblTransferCase1.Text = "";
                        lblTransferLevy.Text = "";
                        lblPendingdues.Text = "";
                        lblPendingDues1.Text = "";
                        txtCarry.Text = "";
                        lblChangeofPlotRefNo.Text = dt2.Rows[0]["ChangeOfPlotRefNo"].ToString();
                        lblChangeOfPlotRefNo1.Text = dt2.Rows[0]["ChangeOfPlotRefNo"].ToString();
                        txtChangePlotRefNo.Text = dt2.Rows[0]["ChangeOfPlotRefNo"].ToString();
                        lblChangeofPlotRefDate.Text = dt2.Rows[0]["ChangeOfPlotRefDate"].ToString();
                        lblChangeOfPlotRefDate1.Text = dt2.Rows[0]["ChangeOfPlotRefDate"].ToString();
                        txtChangePlotRefDate.Text = dt2.Rows[0]["ChangeOfPlotRefDate"].ToString();
                        lblDateofFirstAllotment1.Text = dt1.Rows[0]["firstAllotmentDate"].ToString().Trim();
                        lblAllotmentreferencenumber1.Text = dt1.Rows[0]["Allotmentreferencenumber"].ToString().Trim();
                    }
                    else
                    {

                        Case1.Visible = false;
                        Case2.Visible = false;
                        Case3.Visible = false;
                        tccase.Visible = false;
                        ddlTranserCase.ClearSelection();
                        LblTransferCase1.Text = "";
                        lblTransferLevy.Text = "";
                        lblPendingdues.Text = "";
                        lblPendingDues1.Text = "";
                        txtCarry.Text = "";
                    }
                }
                if (dt3.Rows.Count > 0)
                {

                    txtRateofInterest.Text = dt3.Rows[0]["InterestRate"].ToString();
                    txtRateatTimeAllotment.Text = dt3.Rows[0]["RateatTimeAllotment"].ToString();
                    txtDefaulters.Text = dt3.Rows[0]["NondefaulterRebate"].ToString();
                    txtInstallment.Text = dt3.Rows[0]["NoOfInstallment"].ToString();
                    txtLocationCharges.Text = dt3.Rows[0]["LocationCharges"].ToString();
                    txtMoneyRate.Text = dt3.Rows[0]["RegistrationMoneyRate"].ToString();
                    txtReservationMoney.Text = dt3.Rows[0]["AdditionalPay"].ToString();
                    txtDemantNoticeDate.Text = dt3.Rows[0]["DemandNoticeDate1"].ToString();
                    txtDemantNoticeDate2.Text = dt3.Rows[0]["DemandNoticeDate2"].ToString();

                    lbl_rate_of_interest.Text = dt3.Rows[0]["InterestRate"].ToString();
                    lbl_rate_time_of_allotment.Text = dt3.Rows[0]["RateatTimeAllotment"].ToString();
                    lbl_Rebate_For_Non_Defaulters.Text = dt3.Rows[0]["NondefaulterRebate"].ToString();
                    lbl_No_Of_Installment.Text = dt3.Rows[0]["NoOfInstallment"].ToString();
                    lbl_Location_Charges.Text = dt3.Rows[0]["LocationCharges"].ToString();
                    lbl_Earnest_Money_Rate.Text = dt3.Rows[0]["RegistrationMoneyRate"].ToString();
                    lbl_Reservation_Money_Paid_witin_30_days.Text = dt3.Rows[0]["AdditionalPay"].ToString();
                    lbl_Demant_Notice_Date1.Text = dt3.Rows[0]["DemandNoticeDate1"].ToString();
                    lbl_Demant_Notice_Date2.Text = dt3.Rows[0]["DemandNoticeDate2"].ToString();
                }

                if (dt6.Rows.Count > 0)
                {
                    if (dt6.Rows[0]["IAType"].ToString().Length > 0)
                    {
                        ddlTypeOfIndustry.SelectedValue = dt6.Rows[0]["IAType"].ToString();
                    }
                    else
                    {
                        ddlTypeOfIndustry.SelectedIndex = 0;
                    }
                    txttypeofindustry.Text = dt6.Rows[0]["IndustryType"].ToString();
                    txtestimatedcost.Text = dt6.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text = dt6.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtProjectStartPeriod.Text = dt6.Rows[0]["ProjectStartMonths"].ToString();
                    txtcoveredarea.Text = dt6.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text = dt6.Rows[0]["OpenAreaRequired"].ToString();
                    txtland.Text = dt6.Rows[0]["LandDetails"].ToString();
                    txtbuilding.Text = dt6.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text = dt6.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text = dt6.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text = dt6.Rows[0]["OtherExpenses"].ToString();
                    txteffluentsolidqty.Text = dt6.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    txteffluentsolidcomposition.Text = dt6.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    txteffluentliquidqty.Text = dt6.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    txteffluentliquidcomposition.Text = dt6.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    txteffluentgaseousqty.Text = dt6.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    txteffluentgaseouscomposition.Text = dt6.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();

                    if (dt6.Rows[0]["ExportOriented"].ToString() == "" || dt6.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt6.Rows[0]["ExportOriented"].ToString().Trim(); }

                    ddl_ProductCategory.SelectedValue = dt6.Rows[0]["HSProductCategory"].ToString();
                    ddl_ProductCategory_SelectedIndexChanged(null, null);
                    string[] HSSub = dt6.Rows[0]["HSProductSubCategory"].ToString().Split(',');
                    if (dt6.Rows[0]["HSProductSubCategory"].ToString() == "")
                    {
                        ddl_ProductSubCategory.ClearSelection();
                    }
                    else
                    {
                        for (int j = 0; j < HSSub.Length; j++)
                        {
                            ddl_ProductSubCategory.Items.FindByValue(HSSub[j]).Selected = true;
                        }
                    }
                    ddl_ProductSubCategory_SelectedIndexChanged(null, null);
                    string[] HSProductName = dt6.Rows[0]["HSProductName"].ToString().Split(',');
                    if (dt6.Rows[0]["HSProductName"].ToString() == "")
                    {
                        lst_ProductName.ClearSelection();
                    }
                    else
                    {
                        for (int j = 0; j < HSProductName.Length; j++)
                        {
                            lst_ProductName.Items.FindByValue(HSProductName[j]).Selected = true;
                        }
                    }
                    if (dt6.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        chkfumes.Checked = true;
                        fumesdiv.Visible = true;
                        txtfumeqty.Text = dt6.Rows[0]["FumeQuantity"].ToString();
                        txtfumenature.Text = dt6.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        chkfumes.Checked = false;
                        fumesdiv.Visible = false;
                        txtfumeqty.Text = "";
                        txtfumenature.Text = "";
                    }
                    if (dt6.Rows[0]["pollutionCategory"].ToString().Trim() == "0" || dt6.Rows[0]["pollutionCategory"].ToString().Trim() == "" || dt6.Rows[0]["pollutionCategory"].ToString().Trim() == null)
                    {
                        drppollutionCategory.SelectedIndex = 0;
                    }
                    else
                    {
                        drppollutionCategory.SelectedValue = dt6.Rows[0]["pollutionCategory"].ToString().Trim();
                    }
                    lblpollutionCategory1.Text = dt6.Rows[0]["pollutionCategory1"].ToString();
                    txteffluenttreatmentmeasure1.Text = dt6.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    txteffluenttreatmentmeasure2.Text = dt6.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    txteffluenttreatmentmeasure3.Text = dt6.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    txtpowerreq.Text = dt6.Rows[0]["PowerReqInKW"].ToString();
                    txttelephonefirstyearreq1.Text = dt6.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    txttelephonefirstyearreq2.Text = dt6.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    txttelephoneUltimateyearreq1.Text = dt6.Rows[0]["TelephoneReqUltimate1"].ToString();
                    txttelephoneUltimateyearreq2.Text = dt6.Rows[0]["TelephoneReqUltimate2"].ToString();

                    if (dt6.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                    {
                        chkpriority.Checked = true;
                        prioritydiv.Visible = true;
                        txtapplicantpriorityspecification.Text = dt6.Rows[0]["ApplicantPrioritySpecification"].ToString();
                    }
                    else
                    {
                        chkpriority.Checked = false;
                        prioritydiv.Visible = false;
                        txtapplicantpriorityspecification.Text = "";
                    }
                    lblTypeOfIndustry.Text = dt6.Rows[0]["IndustryType"].ToString();
                    Label55.Text = dt6.Rows[0]["IndustryType"].ToString();
                    lblHSProductCategory.Text= dt6.Rows[0]["ProductCategory"].ToString();
                    ddl_ProductCategory.SelectedValue = dt6.Rows[0]["HSProductCategory"].ToString();
                    lblHSProductSubCategory.Text = dt6.Rows[0]["ProductSubcategory"].ToString();
                    //ddl_ProductSubCategory.Text = dt6.Rows[0]["HSProductSubCategory"].ToString();
                    lblHSProductName.Text = dt6.Rows[0]["Product"].ToString();
                    lblworkexperience.Text = dt6.Rows[0]["workexperience"].ToString();
                    txtWorkExperience.Text = dt6.Rows[0]["workexperience"].ToString();
                    lblNetTurnOver.Text = dt6.Rows[0]["NetTurnOver"].ToString();
                    txtTurnover.Text = dt6.Rows[0]["NetTurnOver"].ToString();
                    lblNetWorth.Text = dt6.Rows[0]["NetWorth"].ToString();
                    txtNetWorth.Text = dt6.Rows[0]["NetWorth"].ToString();
                    lblestimatedcost.Text = dt6.Rows[0]["EstimatedCostOfProject"].ToString();
                    Label56.Text = dt6.Rows[0]["EstimatedCostOfProject"].ToString();
                    lblProjectStartPeriod.Text = dt6.Rows[0]["ProjectStartMonths"].ToString();
                    lblStartPeriod.Text = dt6.Rows[0]["ProjectStartMonths"].ToString();
                    lblestimatedemployment.Text = dt6.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    Label57.Text = dt6.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    lblcoveredarea.Text = dt6.Rows[0]["CoveredArea"].ToString();
                    Label58.Text = dt6.Rows[0]["CoveredArea"].ToString();
                    lblopenarea.Text = dt6.Rows[0]["OpenAreaRequired"].ToString();
                    Label59.Text = dt6.Rows[0]["OpenAreaRequired"].ToString();
                    lblland.Text = dt6.Rows[0]["LandDetails"].ToString();
                    Label60.Text = dt6.Rows[0]["LandDetails"].ToString();
                    lblbuilding.Text = dt6.Rows[0]["BuildingDetails"].ToString();
                    Label61.Text = dt6.Rows[0]["BuildingDetails"].ToString();
                    lblMachinery.Text = dt6.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    Label62.Text = dt6.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    lblFixedAssets.Text = dt6.Rows[0]["OtherFixedAssets"].ToString();
                    Label63.Text = dt6.Rows[0]["OtherFixedAssets"].ToString();
                    lblOtherExpenses.Text = dt6.Rows[0]["OtherExpenses"].ToString();

                    txtOwnResources.Text = dt6.Rows[0]["OwnResources"].ToString();
                    txtFI.Text = dt6.Rows[0]["FI"].ToString();
                    txtFAR.Text = dt6.Rows[0]["FAR"].ToString();
                    lblownresources.Text = dt6.Rows[0]["OwnResources"].ToString();
                    lblFI.Text = dt6.Rows[0]["FI"].ToString();
                    lblownresources1.Text = dt6.Rows[0]["OwnResources"].ToString();
                    lblFI1.Text = dt6.Rows[0]["FI"].ToString();

                    lblFAR.Text = dt6.Rows[0]["FAR"].ToString();
                    lblFAR1.Text = dt6.Rows[0]["FAR"].ToString();


                    Label64.Text = dt6.Rows[0]["OtherExpenses"].ToString();
                    lblEffluentSolidQty.Text = dt6.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    Label67.Text = dt6.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    lblEffluentSolidComposition.Text = dt6.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    Label68.Text = dt6.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    lblEffluentLiquidQty.Text = dt6.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    Label69.Text = dt6.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    lblEffluentLiquidComposition.Text = dt6.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    Label70.Text = dt6.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    lblEffluentGaseousQty.Text = dt6.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    Label71.Text = dt6.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    lblEffluentGaseousComposition.Text = dt6.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    Label72.Text = dt6.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    if (dt6.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        fume_span.InnerText = "Yes";
                        fumeDiv1.Visible = true;
                        lblFumeQty.Text = dt6.Rows[0]["FumeQuantity"].ToString();
                        lblFumeNature.Text = dt6.Rows[0]["FumeNature"].ToString();
                        Div1.Visible = true;
                        Span1.InnerText = "Yes"; ;
                        Label66.Text = dt6.Rows[0]["FumeQuantity"].ToString();
                        Label65.Text = dt6.Rows[0]["FumeNature"].ToString();

                    }
                    else
                    {
                        fume_span.InnerText = "No";
                        fumeDiv1.Visible = false;
                        lblFumeQty.Text = "";
                        lblFumeNature.Text = "";
                        Div1.Visible = false;
                        Span1.InnerText = "No"; ;
                        Label66.Text = "";
                        Label65.Text = "";
                    }
                    lblEffluentMeasure1.Text = dt6.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    Label73.Text = dt6.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    lblEffluentMeasure2.Text = dt6.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    Label74.Text = dt6.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    lblEffluentMeasure3.Text = dt6.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    Label75.Text = dt6.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    lblPowerReq.Text = dt6.Rows[0]["PowerReqInKW"].ToString();
                    Label76.Text = dt6.Rows[0]["PowerReqInKW"].ToString();
                    lblTReq1.Text = dt6.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    Label77.Text = dt6.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    lblTReq2.Text = dt6.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    Label78.Text = dt6.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    lblTUReq1.Text = dt6.Rows[0]["TelephoneReqUltimate1"].ToString();
                    Label79.Text = dt6.Rows[0]["TelephoneReqUltimate1"].ToString();
                    lblTUReq2.Text = dt6.Rows[0]["TelephoneReqUltimate2"].ToString();
                    Label80.Text = dt6.Rows[0]["TelephoneReqUltimate2"].ToString();
                    if (dt6.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
                    {
                        priority_span.InnerText = "Yes";


                        Prioritydiv1.Visible = true;


                        lblspec.Text = dt6.Rows[0]["ApplicantPrioritySpecification"].ToString();

                        Span2.InnerText = "Yes";
                        Div2.Visible = true;
                        Label81.Text = dt6.Rows[0]["ApplicantPrioritySpecification"].ToString();
                    }
                    else
                    {
                        priority_span.InnerText = "No";
                        Prioritydiv1.Visible = false;
                        lblspec.Text = "";
                        Span2.InnerText = "No";
                        Div2.Visible = false;
                        Label81.Text = "";
                    }

                }

                if (dt4.Rows.Count > 0)
                {
                    gridviewpayment.DataSource = dt4;
                    gridviewpayment.DataBind();
                    GridView6.DataSource = dt4;
                    GridView6.DataBind();
                }
                else
                {
                    gridviewpayment_DataBind();
                }


                //----------------last View--------------------

                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {
                        GridView7.Visible = true;
                        P2.InnerText = "Individual/Sole Proprietorship firm Details";
                        GridView7.DataSource = dt1; GridView7.DataBind();
                    }
                    else
                    {
                        GridView7.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {
                        GridView8.Visible = true;
                        P2.InnerText = "Directors Details";
                        GridView8.DataSource = dt5; GridView8.DataBind();
                    }
                    else
                    {
                        GridView8.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {
                        GridView9.Visible = true;
                        P2.InnerText = "ShareHolders Details";
                        GridView9.DataSource = dt5; GridView9.DataBind();
                    }
                    else
                    {
                        GridView9.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {
                        GridView10.Visible = true;
                        P2.InnerText = "Trustee Details";
                        GridView10.DataSource = dt5; GridView10.DataBind();
                    }
                    else
                    {
                        GridView10.Visible = false;
                    }
                    if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {
                        GridView12.Visible = true;
                        P2.InnerText = "Partners Details";
                        GridView12.DataSource = dt5; GridView12.DataBind();
                    }
                    else
                    {
                        GridView12.Visible = false;
                    }
                }

                if (dt9.Rows.Count > 0)
                {
                    ViewState["temp_installment_details"] = dt9;
                    temp_installment_details_DataBind();
                    gvdInstallment.DataSource = dt9;
                    gvdInstallment.DataBind();


                }
                if (dt12.Rows.Count > 0)
                {

                    DivTEF.Visible = true;
                    TEFViewDetails.DataSource = dt12;
                    TEFViewDetails.DataBind();
                }

                BindAllotteePaymentSummary(AllotteeId);
                BindAllotteeJournal(AllotteeId);
                BindUploadedDocument();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        protected void AllotteePaymentSummaruGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteePaymentSummaruGrid.Rows.Count - 1; i++)
            {
                string Amount = AllotteePaymentSummaruGrid.Rows[i].Cells[4].Text;
                if (Convert.ToDecimal(Amount) > 0)
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                else
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Green;
                }

            }
        }
        protected void AllotteeJournalGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteeJournalGrid.Rows.Count - 1; i++)
            {
                string debit = AllotteeJournalGrid.Rows[i].Cells[4].Text;
                string credit = AllotteeJournalGrid.Rows[i].Cells[5].Text;
                if (Convert.ToDecimal(debit) > 0)
                {
                    AllotteeJournalGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                if (Convert.ToDecimal(credit) > 0)
                {
                    AllotteeJournalGrid.Rows[i].Cells[5].ForeColor = Color.Green;
                }

            }
        }
        private void BindAllotteeJournal(int AllotteeID)
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteeJournal] " + AllotteeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteeJournalGrid.DataSource = dt;
                AllotteeJournalGrid.DataBind();
            }
            else
            {
                AllotteeJournalGrid.DataSource = null;
                AllotteeJournalGrid.DataBind();
            }
        }

        private void BindAllotteePaymentSummary(int AllotteeID)
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + AllotteeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteePaymentSummaruGrid.DataSource = dt;
                AllotteePaymentSummaruGrid.DataBind();
                decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("Demanded"));
                decimal tot_Paid = dt.AsEnumerable().Sum(row => row.Field<decimal>("Paid"));
                decimal tot_Outstanding = dt.AsEnumerable().Sum(row => row.Field<decimal>("Outstanding"));
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].Text = "Total";
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                AllotteePaymentSummaruGrid.FooterRow.Cells[2].Text = tot_Demanded.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[3].Text = tot_Paid.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[4].Text = tot_Outstanding.ToString("N2");
            }
            else
            {
                AllotteePaymentSummaruGrid.DataSource = null;
                AllotteePaymentSummaruGrid.DataBind();
            }
        }



        protected void GridView1_pending_process_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select_allotee_for_process")
            {

                string GridView1_pending_process_allotee_id = "";

                int index = Convert.ToInt32(e.CommandArgument);
                try
                {

                    GridView1_pending_process_allotee_id = (Convert.ToInt32(e.CommandArgument)).ToString();
                    lblNewButton.Text = "0";
                }
                catch
                {
                    txtAllotteeRegisterID.Text = "";
                }
                Session["AllotteeID"] = GridView1_pending_process_allotee_id;
                GetAllAllotteeDetailsFilledById(int.Parse(GridView1_pending_process_allotee_id));

                btn_first_save.Text = "Saved";
                Chooseplot.Visible = false;
                allotteeID.Text = Session["AllotteeID"].ToString();
                MultiView1.ActiveViewIndex = 1;
            }

            if (e.CommandName == "DeleteAllotteeRecords")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                int AllotteeId = index;
                objServiceTimelinesBEL.dbId = AllotteeId;

                DataSet ds = new DataSet();
                ds = objServiceTimelinesBLL.GetPreServiceDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    MessageBox1.ShowInfo("Applicant Apply for Another Service so Records will not Deactivate ");
                    return;
                }
                else
                {

                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteAllotteeRecords(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {

                            MessageBox1.ShowSuccess("Allottee Record Deactivated");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
                        }
                        else
                        {

                            MessageBox1.ShowError("Allottee Request Cannot Be Deleted!!!");
                            ViewState["Filter"] = drpdwnIA.SelectedValue;
                            GetNewAllotteeDetails();
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

            }

        }


        protected void New_Allottee_Registration_btn_click(object sender, EventArgs e)
        {


            Session["AllotteeID"] = "";
            allotteeID.Text = Session["AllotteeID"].ToString();
            ResetControl1();
            MultiView1.ActiveViewIndex = 1;
        }


       

        #endregion
        #region BindAlloteeDocumentGrid

        private void GetAllotteeDocumentDetail()
        {

            if (allotteeID.Text.Length > 0)
            {
                int Parameter = Convert.ToInt32(allotteeID.Text);
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAlloteeDocumentDetail(Parameter);
                    DataTable dt = ds.Tables[0];
                    GridViewDocument.DataSource = dt;
                    GridViewDocument.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
        }



        protected void GridViewDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                int Parameter = Convert.ToInt32(allotteeID.Text);

                int ID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllotteesDocumenttBasedtooPar(Parameter, ID);
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


        protected void BuildingPlanGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                int Parameter = Convert.ToInt32(allotteeID.Text);

                int ID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetBuildingPlanDocumentDetailBasedtooPar(Parameter, ID);
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

        protected void InspectionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectDocument")
            {
                int Parameter = Convert.ToInt32(allotteeID.Text);

                int ID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetInspectionDocumentDetailBasedtooPar(Parameter, ID);
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

        private void download(DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["contentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void OnPagingChange(object sender, GridViewPageEventArgs e)
        {
            GridViewDocument.PageIndex = e.NewPageIndex;
            this.GetAllotteeDocumentDetail();
        }

        private void BindCountryList(DropDownList ddlCountry)
        {
            //fill industrtial area

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetAlloteeDetail();
                DataTable dt = dsR.Tables[0];
                DataView view = new DataView(dt);
                DataTable distinctValues = view.ToTable(true, "IAName");
                ddlCountry.DataSource = distinctValues;
                ddlCountry.DataTextField = "IAName";
                ddlCountry.DataValueField = "IAName";
                ddlCountry.DataBind();
                ddlCountry.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;


            }
            catch { }

        }

        protected void AllotteeChanged(object sender, EventArgs e)
        {
            DropDownList ddlCountry = (DropDownList)sender;
            ViewState["Filter"] = ddlCountry.SelectedValue;
            this.GetNewAllotteeDetails();
        }
        #endregion
        #region UploadDocument Process

        protected void btnAllotmentLetter_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            string formattedDate = "";
            try
            {

                try
                {
                    string Datec = txtalltLetterIssueDate.Text.Trim();

                    dateTime = Convert.ToDateTime(Datec).Date;
                    formattedDate = dateTime.ToString("dd MMM yyyy");
                }
                catch
                {
                    string message = "First Save Registrations Process(2/5)";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                }


                if (FileUploadAllotmentLetter.HasFile)
                {




                    HttpPostedFile file = FileUploadAllotmentLetter.PostedFile;
                    objServiceTimelinesBEL.UploadAllotmentLetter = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.UploadAllotmentLetter, 0, file.ContentLength);
                    objServiceTimelinesBEL.AllotmentLetterFile = Path.GetFileName(FileUploadAllotmentLetter.PostedFile.FileName);
                    objServiceTimelinesBEL.AllotmentLetterExt = FileUploadAllotmentLetter.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(Session["AllotteeID"].ToString());
                    objServiceTimelinesBEL.AllotmentIssueDate = dateTime;
                    //objServiceTimelinesBEL.BookName = "Allotment Letter";
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(Session["AllotteeID"].ToString()) > 0)
                    {
                        int retVal = objServiceTimelinesBLL.UpdateAllotmentLetterFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {

                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        }
                        else
                        {
                            string message = "File Not  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Please Select Allottee from first Step for whom Allotment leter is intended to upload  ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnFuLeaseDeed_Click(object sender, EventArgs e)
        {
            try
            {
                string DateleaseDate = txtLeaseDeed.Text.Trim();
                string DateleaseExecDate = txtExecLeaseDeed.Text.Trim();

                DateTime dateTimeLease = new DateTime();
                DateTime dateTimeExeLease = new DateTime();
                dateTimeLease = Convert.ToDateTime(DateleaseDate).Date;
                dateTimeExeLease = Convert.ToDateTime(DateleaseExecDate).Date;



                if (FuLeaseDeed.HasFile)
                {


                    HttpPostedFile file = FuLeaseDeed.PostedFile;
                    objServiceTimelinesBEL.UploadLeaseDeed = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.UploadLeaseDeed, 0, file.ContentLength);
                    objServiceTimelinesBEL.LeaseDeedFile = Path.GetFileName(FileUploadAllotmentLetter.PostedFile.FileName);
                    objServiceTimelinesBEL.LeaseDeedExt = FileUploadAllotmentLetter.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(allotteeID.Text);
                    objServiceTimelinesBEL.LeaseDeedDate = dateTimeLease;
                    objServiceTimelinesBEL.LeaseAgrementExecDate = dateTimeExeLease;
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(allotteeID.Text) > 0)
                    {
                        int retVal = objServiceTimelinesBLL.UpdateLeaseDeedFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            lbluploadingMsg.Visible = true;
                            lbluploadingMsg.Text = "File uploaded Successfully.";

                        }
                        else
                        {
                            string message = "File couldn't be  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Allottee Id couldn't be  Supplied ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }


                }
            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnUploadInspection_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadInspection.HasFile)
                {
                    HttpPostedFile file = FileUploadInspection.PostedFile;
                    objServiceTimelinesBEL.InspectionLetter = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.InspectionLetter, 0, file.ContentLength);
                    objServiceTimelinesBEL.InsepectionfilenameExt = FileUploadInspection.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(allotteeID.Text);
                    objServiceTimelinesBEL.InspectionDate = Convert.ToDateTime(txtInspectionDate.Text);

                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(allotteeID.Text) > 0)
                    {
                        int retVal = objServiceTimelinesBLL.UpdateInspectionFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {

                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            lbluploadingMsg.Visible = true;
                            lbluploadingMsg.Text = "File uploaded Successfully.";
                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                        }
                        else
                        {
                            string message = "File couldn't be  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Allottee Id couldn't be  Supplied ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnBuildingPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudBuildingPlan.HasFile)
                {
                    HttpPostedFile file = FudBuildingPlan.PostedFile;
                    objServiceTimelinesBEL.BuildingPlanDocument = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.BuildingPlanDocument, 0, file.ContentLength);
                    objServiceTimelinesBEL.BuildingPlanDocumentExt = FudBuildingPlan.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(allotteeID.Text);
                    objServiceTimelinesBEL.BuldingPlanSubmissionDate = Convert.ToDateTime(txtBuildingDate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(allotteeID.Text) > 0)
                    {
                        int retVal = objServiceTimelinesBLL.UpdateBuildingPlanFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            lbluploadingMsg.Visible = true;
                            lbluploadingMsg.Text = "File uploaded Successfully.";

                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                        }
                        else
                        {
                            string message = "File couldn't be  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Allottee Id couldn't be  Supplied ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnCompletion_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudCompletion.HasFile)
                {
                    HttpPostedFile file = FudCompletion.PostedFile;
                    objServiceTimelinesBEL.CompletionCertificate = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.CompletionCertificate, 0, file.ContentLength);
                    objServiceTimelinesBEL.CompletionCertificateExt = FudCompletion.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(allotteeID.Text);
                    objServiceTimelinesBEL.CompletionDate = Convert.ToDateTime(txtDateCompletion.Text);
                    objServiceTimelinesBEL.ReleaseofCompletionDate = Convert.ToDateTime(txtcomcertificate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(allotteeID.Text) > 0)
                    {
                        int retVal = objServiceTimelinesBLL.UpdateCompletionFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            lbluploadingMsg.Visible = true;
                            lbluploadingMsg.Text = "File uploaded Successfully.";

                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                        }
                        else
                        {
                            string message = "File couldn't be  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Allottee Id couldn't be  Supplied ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnOccupancy_Click(object sender, EventArgs e)
        {
            try
            {
                if (FudOccupancy.HasFile)
                {
                    HttpPostedFile file = FudOccupancy.PostedFile;
                    objServiceTimelinesBEL.OccupancyCertificate = new byte[file.ContentLength];
                    file.InputStream.Read(objServiceTimelinesBEL.OccupancyCertificate, 0, file.ContentLength);
                    objServiceTimelinesBEL.OccupancyCertificateExt = FudOccupancy.PostedFile.ContentType;
                    objServiceTimelinesBEL.dbId = Convert.ToInt32(allotteeID.Text);
                    objServiceTimelinesBEL.RequestofOccupancyCertificateDate = Convert.ToDateTime(txtoccertificate.Text);
                    objServiceTimelinesBEL.ReleaseofOccupancyCertificateDate = Convert.ToDateTime(txtReloccertificate.Text);
                    objServiceTimelinesBEL.CreatedBy = Environment.MachineName;
                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                    if (Convert.ToInt32(allotteeID.Text) > 0)
                    {


                        int retVal = objServiceTimelinesBLL.UpdateOccupancyFile(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            // Bind the Document Grid
                            GetAllotteeDocumentDetail();

                            string message = "File uploaded Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            lbluploadingMsg.Visible = true;
                            lbluploadingMsg.Text = "File uploaded Successfully.";

                        }
                        else
                        {
                            string message = "File couldn't be  uploaded ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                        }
                    }
                    else
                    {

                        string message = "Allottee Id couldn't be  Supplied ";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                lbluploadingMsg.Visible = true;
                lbluploadingMsg.Text = ex.Message.ToString();
            }
        }

        #endregion

        #region CommentedCode
        #region Demand UserControl
        private void GetAllotteeDuesDetails()
        {
            try
            {
                UC_Allottee_Ledger UC_Allottee_Ledger = LoadControl("~/UC_Allottee_Ledger.ascx") as UC_Allottee_Ledger;
                UC_Allottee_Ledger.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Allottee_Ledger.ApplicantID = Session["AllotteeID"].ToString();
                UC_Allottee_Ledger.ButtonStatus = "Hide";
                UC_Allottee_Ledger.ServiceReqNo = "";
                PlaceHolder1.Controls.Add(UC_Allottee_Ledger);

            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }

        }

        #endregion


        //#region Dues Details

        //protected void btnsavedues_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string DemandID = "";
        //        decimal totalAmount = 0;
        //        int retVal = 0;

        //        if (lblAllotteID.Text.Length <= 0)
        //        {
        //            MessageBox1.ShowError("Please select Allotee");
        //            return;
        //        }
        //        if (txtDemandDate.Text == "" || txtDemandDate.Text == null)
        //        {
        //            MessageBox1.ShowError("Please Enter Demand Date");
        //            return;
        //        }
        //        foreach (GridViewRow row in PaymentGridView.Rows)
        //        {
        //            TextBox Amount = (TextBox)row.FindControl("txtAmount");
        //            if (Amount.Text == "")
        //            {
        //                Amount.Text = "0";
        //            }
        //            totalAmount += Convert.ToDecimal(Amount.Text);
        //        }
        //        if (totalAmount <= 0)
        //        {
        //            MessageBox1.ShowInfo("Please Enter Dues Under Demand");
        //            return;
        //        }

        //        DataSet ds = new DataSet();
        //        objServiceTimelinesBEL.btnText = btnsavedues.Text.Trim();
        //        objServiceTimelinesBEL.DemandID = lblDemandID.Text.Trim();
        //        objServiceTimelinesBEL.AlloteeId = lblAllotteID.Text.Trim();
        //        objServiceTimelinesBEL.AllotmentLetterno = lblAllotmentLetterNo.Text.Trim();
        //        objServiceTimelinesBEL.DueAmount = totalAmount;
        //        if (txtDemandDate.Text.Trim().Length > 0)
        //        {
        //            string date_to_be = DateTime.ParseExact(txtDemandDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        //            objServiceTimelinesBEL.DemandDate = Convert.ToDateTime((date_to_be));
        //        }

        //        objServiceTimelinesBEL.UserName = UserName;

        //        ds = objServiceTimelinesBLL.DuesEntry(objServiceTimelinesBEL);
        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                DemandID = ds.Tables[0].Rows[0][0].ToString();

        //                foreach (GridViewRow row in PaymentGridView.Rows)
        //                {

        //                    Label PaymentID = (Label)row.FindControl("lblID");
        //                    Label PayDesc = (Label)row.FindControl("lblPayDescription");
        //                    TextBox Amount = (TextBox)row.FindControl("txtAmount");
        //                    Label Priority = (Label)row.FindControl("lblPriority");

        //                    if (Amount.Text == "")
        //                    {
        //                        Amount.Text = "0";
        //                    }
        //                    objServiceTimelinesBEL.demandID = Convert.ToInt32(DemandID.Trim());
        //                    objServiceTimelinesBEL.paymentID = Convert.ToInt32(PaymentID.Text.Trim());
        //                    objServiceTimelinesBEL.PayDesc = PayDesc.Text.Trim();
        //                    objServiceTimelinesBEL.Amount = Convert.ToDecimal(Amount.Text.Trim());
        //                    objServiceTimelinesBEL.Priority = Convert.ToInt32(Priority.Text.Trim());

        //                    retVal = objServiceTimelinesBLL.DemandNoteDetailEntry(objServiceTimelinesBEL);
        //                }
        //                if (retVal > 0)
        //                {
        //                    string message = "Dues Inserted Successfully";
        //                    MessageBox1.ShowSuccess(message);
        //                    bind();
        //                    bindPaymentDetailswithAmount();
        //                    allotteeID.Text = Session["AllotteeID"].ToString();
        //                    GetAllAllotteeDetailsFilledById(Convert.ToInt32(allotteeID.Text));

        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}
        //private void bindPaymentDetailswithAmount()
        //{
        //    objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
        //    objServiceTimelinesBEL.DemandID = lblDemandID.Text.Trim();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetPaymentDetailswithAmount(objServiceTimelinesBEL);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            lblDemandID.Text = ds.Tables[0].Rows[0]["DemandId"].ToString();
        //            txtDemandDate.Text = ds.Tables[0].Rows[0]["DueDate"].ToString();
        //            PaymentGridView.DataSource = ds;
        //            PaymentGridView.DataBind();
        //            btnsavedues.Text = "Update";

        //        }
        //        else
        //        {
        //            bind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured111 :" + ex.Message.ToString());
        //    }

        //}

        //private void bindPaymentRecivedwithAmount()
        //{

        //    objServiceTimelinesBEL.AlloteeId = Session["AllotteeID"].ToString();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetPaymentRecivedwithAmount(objServiceTimelinesBEL);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {

        //            txtPaymentRecived.Text = ds.Tables[0].Rows[0]["PaymentRecivedDate"].ToString();
        //            PaymentRecived.DataSource = ds;
        //            PaymentRecived.DataBind();

        //        }
        //        else
        //        {
        //            bind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured111 :" + ex.Message.ToString());
        //    }

        //}

        //private void bind()
        //{
        //    SqlCommand cmd = new SqlCommand("GetPaymentforDemandNote", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        PaymentGridView.DataSource = dt;
        //        PaymentGridView.DataBind();
        //        PaymentRecived.DataSource = dt;
        //        PaymentRecived.DataBind();
        //    }
        //}

        //private void bindPaymentRecivedInHeader(string DemandID, decimal PaymentRecivedAmount)
        //{
        //    objServiceTimelinesBEL.DemandID = DemandID;
        //    objServiceTimelinesBEL.PaymentRecivedAmount = PaymentRecivedAmount;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetAdjustedPaymentAgainstdDemand(objServiceTimelinesBEL);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            PaymentRecived.DataSource = ds;
        //            PaymentRecived.DataBind();
        //        }
        //        else
        //        {
        //            bind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured111 :" + ex.Message.ToString());
        //    }
        //}

        //#endregion

        //#region Dues Recived Details


        //protected void btnPaymentRecived_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int retVal = 0;
        //        con.Open();
        //        SqlCommand command = con.CreateCommand();
        //        SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
        //        command.Connection = con;
        //        command.Transaction = transaction;
        //        bool transactionResult = true;
        //        int DemandID = Convert.ToInt32(lblDemandID.Text);
        //        command = new SqlCommand(@"Delete from DuesPaymentRecivedDetail where PaymentRecivedId=" + DemandID + "", con, transaction);
        //        command.CommandTimeout = 200;
        //        transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
        //        //string PaymentRecivedID = "";
        //        //decimal totalPaymentRecivedAmount = 0;
        //        if (lblAllotteID.Text.Length <= 0)
        //        {
        //            MessageBox1.ShowError("Please select Allotee");
        //            return;
        //        }
        //        if (txtPaymentRecived.Text == "" || txtPaymentRecived.Text == null)
        //        {
        //            MessageBox1.ShowError("Please Enter Payment Recived Date");
        //            return;
        //        }
        //        if (txtPaymentRecivedAmount.Text == "" || txtPaymentRecivedAmount.Text == null)
        //        {
        //            MessageBox1.ShowError("Please Enter Payment Recived Amount");
        //            return;
        //        }
        //        foreach (GridViewRow row in PaymentRecived.Rows)
        //        {

        //            Label PaymentID = (Label)row.FindControl("lblPaymentID");
        //            Label PayRecivedDescription = (Label)row.FindControl("lblPayRecivedDescription");
        //            TextBox PaymentRecivedAmount = (TextBox)row.FindControl("txtPaymentRecivedAmount");
        //            if (PaymentRecivedAmount.Text == "")
        //            {
        //                PaymentRecivedAmount.Text = "0";
        //            }
        //            objServiceTimelinesBEL.PaymentRecivedID = Convert.ToInt32(lblDemandID.Text);
        //            objServiceTimelinesBEL.ID = Convert.ToInt32(PaymentID.Text.Trim());
        //            objServiceTimelinesBEL.PayRecivedDescription = PayRecivedDescription.Text.Trim();
        //            objServiceTimelinesBEL.PaymentRecivedAmount = Convert.ToDecimal(PaymentRecivedAmount.Text.Trim());
        //            if (txtPaymentRecived.Text.Trim().Length > 0)
        //            {
        //                string date_to_be = DateTime.ParseExact(txtPaymentRecived.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        //                objServiceTimelinesBEL.PaymentReciveddate = Convert.ToDateTime((date_to_be));
        //            }
        //            //objServiceTimelinesBEL.PaymentReciveddate = Convert.ToDecimal(txtPaymentRecived.Text.Trim());
        //            retVal = objServiceTimelinesBLL.DuesPaymentDetailEntry(objServiceTimelinesBEL);
        //        }
        //        if (transactionResult)
        //        {
        //            transaction.Commit();
        //            string message = "Payment Recived Details Inserted Successfully";
        //            MessageBox1.ShowSuccess(message);
        //            allotteeID.Text = Session["AllotteeID"].ToString();
        //            GetAllAllotteeDetailsFilledById(Convert.ToInt32(allotteeID.Text));
        //            //bind();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}


        //private void bindDemandHeader()
        //{
        //    SqlCommand cmd = new SqlCommand("GetPaymentforDemandNote", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        PaymentGridView.DataSource = dt;
        //        PaymentGridView.DataBind();
        //        PaymentRecived.DataSource = dt;
        //        PaymentRecived.DataBind();
        //    }
        //}


        //#endregion

        #endregion
        
        #region Installment

        protected void btnInstallmentSave_Click(object sender, EventArgs e)
        {


            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                int retVal = 0;
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                DataTable temp = (DataTable)ViewState["temp_installment_details"];

                int allotteeiD = Convert.ToInt32(Session["AllotteeID"].ToString());
                command = new SqlCommand(@"Delete from InstallmentPaymentRecivedDetails where AllotteeID=" + allotteeiD + "", con, transaction);
                transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));

                if (temp.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in temp.Rows)
                    {
                        string date_to_be = DateTime.ParseExact(dr1["DueDateofInstallment"].ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
                        objServiceTimelinesBEL.DueDateofInstallment = Convert.ToDateTime(date_to_be);
                        objServiceTimelinesBEL.InterestDue = Convert.ToDecimal(dr1["InterestDue"].ToString());
                        objServiceTimelinesBEL.InterestDuewithout = Convert.ToDecimal(dr1["InterestDuewithout"].ToString());
                        objServiceTimelinesBEL.PremiumDue = Convert.ToDecimal(dr1["PremiumDue"].ToString());
                        objServiceTimelinesBEL.TotalAmount = Convert.ToDecimal(dr1["TotalAmount"].ToString());
                        objServiceTimelinesBEL.TotalAmountRebate = Convert.ToDecimal(dr1["TotalAmountRebate"].ToString());
                        objServiceTimelinesBEL.AllotmentLetterno = lblAllotmentLetterNo.Text.Trim();
                        objServiceTimelinesBEL.IsActive = 1;
                        objServiceTimelinesBEL.CreatedBy = UserName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                        retVal = objServiceTimelinesBLL.InsertInstallmentPaymentDetails(objServiceTimelinesBEL);
                    }
                }
                if (retVal > 0)
                {
                    if (transactionResult)
                    {
                        transaction.Commit();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Payment detail Updated/Inserted Successfully.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Allottee details couldn't be saved');", true);
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
            ///////////////////////   End Of Insert   ///////////////////////////// 

        }
        #endregion

        #region Save Record
        protected void btn_second_Click(object sender, EventArgs e)
        {


            {
                if (btnSubmit.Text == "Save")
                {
                    objServiceTimelinesBEL.Action = 0;
                }
                else { objServiceTimelinesBEL.Action = 1; }
                objServiceTimelinesBEL.RegionalOffice = ddloffice.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.IAName = drpdwnIA.SelectedItem.Text.Trim();

                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedItem.Value);
                objServiceTimelinesBEL.Remarks = txtProductManufactured.Text;

                objServiceTimelinesBEL.ToatalPlotedArea = float.Parse(txtTotalArea.Text.ToString());

                objServiceTimelinesBEL.CreatedBy = UserName;
                objServiceTimelinesBEL.CreatedDate = DateTime.Now;

                try
                {
                    if (btnSubmit.Text == "Save")
                    {
                        int retVal = objServiceTimelinesBLL.InsertUpdateAllotteeDetails(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "Allottee detail saved successfully.";

                            MessageBox1.ShowSuccess(message);

                            GetNewAllotteeDetails();
                        }
                        else
                        {
                            string message = "Allottee details couldn't be saved";

                            MessageBox1.ShowWarning(message);

                        }
                    }

                    if (btnSubmit.Text == "Update")
                    {

                        int retVal = 0;
                        objServiceTimelinesBEL.dbId = Convert.ToInt32(ViewState["allotteeid"]);

                        retVal = objServiceTimelinesBLL.InsertUpdateAllotteeDetails(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "Allottee detail Updated successfully.";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);

                            GetNewAllotteeDetails();
                        }
                        else
                        {
                            string message = "Allottee details couldn't be Updated";

                            MessageBox1.ShowWarning(message);
                        }
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
        }
        #endregion

        public string ProcessMyDataItem(object myValue)
        {
            if (myValue == null)
            {
                return "";
            }

            return myValue.ToString();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {

            ResetControl1();
        }

        private void ResetControl()
        {

            txtProductManufactured.Text = "";
            txtTotalArea.Text = "";
            txtLeaseDeed.Text = "";
            txtExecLeaseDeed.Text = "";
            btnSubmit.Text = "Save";
            
        }

        protected void chkListPaymentDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";
            CheckBoxList ckbl1 = (gridviewpayment.FooterRow.FindControl("chkListPaymentDescription") as CheckBoxList);

            for (int i = 0; i < ckbl1.Items.Count; i++)
            {
                if (ckbl1.Items[i].Selected)
                {
                    name += ckbl1.Items[i].Text + ",";
                }
            }

            (gridviewpayment.FooterRow.FindControl("txtPaymentDescription") as TextBox).Text = name.TrimEnd(',');
        }

        protected void txtTotalArea_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text, @"^[-+]?\d*\.?\d*$"))
            {

            }
            else
            {
                Response.Write("Enter Only Numeric value for Alloted Area ");
            }
        }

        protected void Conform_CheckBox_multiview_1_CheckChanged(object sender, EventArgs e)
        {

            string value = Session["AllotteeID"] as string;

            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["AllotteeID"].ToString().Length < 1)
                {
                    if (Conform_CheckBox_multiview_1.Checked == true) { btn_first_save.Enabled = true; }
                    else { btn_first_save.Enabled = false; }
                }
                else
                {
                    if (Conform_CheckBox_multiview_1.Checked == true) { btn_first_save.Enabled = true; }
                    else { btn_first_save.Enabled = false; }
                }

            }
            else
            {
                if (Conform_CheckBox_multiview_1.Checked == true) { btn_first_save.Enabled = true; }
                else { btn_first_save.Enabled = false; }

            }

        }

        protected void Confirm_CheckBox_final(object sender, EventArgs e)
        {

            string value = Session["AllotteeID"] as string;

            if (!(String.IsNullOrEmpty(value)))
            {
                if (Session["AllotteeID"].ToString().Length < 1)
                {
                    if (CheckBox_Final.Checked == true) { Final_Submit.Enabled = true; }
                    else { Final_Submit.Enabled = false; }
                }
                else
                {
                    if (CheckBox_Final.Checked == true) { Final_Submit.Enabled = true; }
                    else { Final_Submit.Enabled = false; }

                }

            }
            else
            {
                if (CheckBox_Final.Checked == true) { Final_Submit.Enabled = true; }
                else { Final_Submit.Enabled = false; }

            }
        }

        public string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        protected void Final_Submit_Click(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.Parameter = Session["AllotteeID"].ToString();
            DataSet ds = new DataSet();
            objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntDetailsforCheck] " + Convert.ToInt32(Session["AllotteeID"].ToString()) + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                try
                {
                    int retVal = objServiceTimelinesBLL.UpdateIsCompletedstatus(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        try
                        {
                            //ds = objServiceTimelinesBLL.GetAllotteeloginDetails(objServiceTimelinesBEL);
                            //DataTable dt1 = ds.Tables[0];
                            //string uid = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                            //string Email = dt1.Rows[0]["SignatoryEmail"].ToString().Trim();
                            //string name = dt1.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                            //MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                            //MailAddress mailto = new MailAddress(Email.Trim());
                            //MailMessage newmsg = new MailMessage(mailfrom, mailto);
                            //string StrContent = "";
                            //StreamReader reader = new StreamReader(Server.MapPath("~/AcknowledgeMent1.html"));
                            //StrContent = reader.ReadToEnd();
                            //StrContent = StrContent.Replace("{UserName}", name);
                            //StrContent = StrContent.Replace("{Description}", "Your UPSIDC EServices Account Has Been Activated! </br>You Can Now Avail The Services By Below Credentials");
                            //StrContent = StrContent.Replace("{UserId}", uid);
                            //StrContent = StrContent.Replace("{Password}", "12345");
                            //StrContent = StrContent.Replace("{url}", "http://eservices.onlineupsidc.com/");
                            //newmsg.Subject = "UPSIDCeServe: Acknowledgement-Login Credentials for eService ";
                            //newmsg.Body = StrContent;
                            //newmsg.IsBodyHtml = true;
                            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            //smtp.UseDefaultCredentials = false;
                            //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                            //smtp.EnableSsl = true;
                            //smtp.Send(newmsg);

                            string message = "Allottee File Entry Completed Successfully";

                            MessageBox1.ShowSuccess(message);
                            Final_Submit.Text = "Submmited";
                            Final_Submit.Enabled = false;

                            GetNewAllotteeDetails();
                            MultiView1.ActiveViewIndex = 0;
                            ResetControl1();
                            Session["AllotteeID"] = "";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    else
                    {
                        string message = "Allottee details couldn't be updated";
                        MessageBox1.ShowWarning(message);
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
            else
            {
                string message = "Please Enter the Head wise Demand and Payment Made By Allottee  for June 2019";
                MessageBox1.ShowWarning(message);
                return;
            }
        }

        #region Priyanshu


        private void bindCompanytypeddl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompanyType();
                ddlcompanytype.DataSource = ds;
                ddlcompanytype.DataTextField = "company_type";
                ddlcompanytype.DataValueField = "id";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr88.Visible = false;
                txtCompanyname.Enabled = false;
                txtCinNo.Enabled = false;


            }

            if (ddlcompanytype.SelectedValue == "1")
            {
                txtCompanyname.Text = "";
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = true;
                tr6.Visible = true;
                tr7.Visible = true;
                tr8.Visible = false;
                tr88.Visible = false;
                txtCompanyname.Enabled = true;
                txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietorship firm name<br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                txtCompanyname.Enabled = true;
                txtCinNo.Enabled = true;
                tr88.Visible = false;
            }
            if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = true;
                tr88.Visible = false;
                txtCompanyname.Enabled = true;
                txtCinNo.Enabled = true;
            }
            if (ddlcompanytype.SelectedValue == "4")
            {

                tr2.Visible = false;
                tr4.Visible = true;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr88.Visible = false;

                txtCompanyname.Enabled = true;
                txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "5")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr88.Visible = true;
                txtCompanyname.Enabled = true;
                txtCinNo.Enabled = true;

            }
            chk2.Checked = false;
            checkbox2_checked_changed(null, null);
        }
        protected void checkbox2_checked_changed(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                txtAuthorisedSignatory.Text = txtCompanyname.Text;
                txtSignatoryAddress.Text = txtIndividualAddress.Text;
                txtSignatoryPhone.Text = txtIndividualPhone.Text;
                txtSignatoryEmail.Text = txtIndividualEmail.Text;
            }
            else
            {
                txtAuthorisedSignatory.Text = "";
                txtSignatoryAddress.Text = ""; ;
                txtSignatoryPhone.Text = "";
                txtSignatoryEmail.Text = "";
            }
        }
        public void temp_installment_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_installment_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridviewinstallment.DataSource = dt;
                gridviewinstallment.DataBind();
                gridviewinstallment.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridviewinstallment.DataSource = dt;
                gridviewinstallment.DataBind();
            }


        }

        public void temp_shareholder_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
                gridshareholder.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
            }


        }
        public void temp_trustee_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
                Trustee_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
            }


        }
        public void temp_director_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
                DirectorsGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
            }
        }

        #region  installment
        protected void insert_installment_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_installment_details"];


            string DueDateofInstallment = (gridviewinstallment.FooterRow.FindControl("txtDueDateofInstallment_insert") as TextBox).Text;
            string InterestDue = (gridviewinstallment.FooterRow.FindControl("txtInterestDue_insert") as TextBox).Text;
            string InterestDuewithout = (gridviewinstallment.FooterRow.FindControl("txtInterestDuewithout_insert") as TextBox).Text;
            string PremiumDue = (gridviewinstallment.FooterRow.FindControl("txtPremiumDue_insert") as TextBox).Text;
            string TotalAmount = (gridviewinstallment.FooterRow.FindControl("lblTotalAmount") as Label).Text;
            string TotalAmountRebate = (gridviewinstallment.FooterRow.FindControl("lblTotalAmountRebate") as Label).Text;



            if (DueDateofInstallment != "")
            {
                if (InterestDue != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide InterestDue");
                    return;
                }
                if (InterestDuewithout != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide InterestDuewithout");
                    return;
                }
                if (PremiumDue != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide PremiumDue");
                    return;
                }

                DataRow dr = dt.NewRow();
                dr["DueDateofInstallment"] = DueDateofInstallment;
                dr["InterestDue"] = InterestDue;
                dr["InterestDuewithout"] = InterestDuewithout;
                dr["PremiumDue"] = PremiumDue;
                dr["TotalAmount"] = (Convert.ToDecimal(InterestDue) + Convert.ToDecimal(PremiumDue)).ToString();
                dr["TotalAmountRebate"] = (Convert.ToDecimal(InterestDuewithout) + Convert.ToDecimal(PremiumDue)).ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_installment_details"] = dt;

                temp_installment_details_DataBind();
            }
            else
            {

                MessageBox1.ShowInfo("Please Provide Date of Installment");
                return;
            }

        }


        #endregion
        protected void insert_shareholder_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];


            string shareholdername = (gridshareholder.FooterRow.FindControl("txtShareholderName_insert") as TextBox).Text;
            string shareper = (gridshareholder.FooterRow.FindControl("txtShareper_insert") as TextBox).Text;
            string address = (gridshareholder.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string email = (gridshareholder.FooterRow.FindControl("txtEmail_insert") as TextBox).Text;
            string phone = (gridshareholder.FooterRow.FindControl("txtPhone_insert") as TextBox).Text;


            if (shareholdername != "")
            {
                if (shareper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ShareHolderName"] = shareholdername;
                    dr["SharePer"] = shareper;
                    dr["Address"] = address;
                    dr["EmailId"] = email;
                    dr["PhoneNo"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_shareholder_details"] = dt;

                    temp_shareholder_details_DataBind();
                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Share Percentage");
                    return;
                }

            }
            else
            {

                MessageBox1.ShowInfo("Please Provide ShareHolder Name");
                return;
            }

        }
        protected void insert_trustee_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];


            string trusteename = (Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert") as TextBox).Text;
            string address = (Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert") as TextBox).Text;
            string email = (Trustee_details_grid.FooterRow.FindControl("txtTEmail_insert") as TextBox).Text;
            string phone = (Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert") as TextBox).Text;


            if (trusteename != "")
            {


                DataRow dr = dt.NewRow();
                dr["TrusteeName"] = trusteename;
                dr["Address"] = address;
                dr["EmailId"] = email;
                dr["Phone"] = phone;

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_trustee_details"] = dt;

                temp_trustee_details_DataBind();

            }
            else
            {

                MessageBox1.ShowInfo("Please Provide Trustee Name");
                return;
            }

        }
        protected void insert_Director_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];


            string Directorname = (DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert") as TextBox).Text;
            string din_pan = (DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert") as TextBox).Text;
            string address = (DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert") as TextBox).Text;
            string phone = (DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert") as TextBox).Text;
            string email = (DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert") as TextBox).Text;


            if (Directorname != "")
            {
                if (din_pan != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["DirectorName"] = Directorname;
                    dr["Din_Pan"] = din_pan;
                    dr["Address"] = address;
                    dr["EmailId"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_directors_details"] = dt;

                    temp_director_details_DataBind();
                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Din/Pan");
                    return;
                }

            }
            else
            {

                MessageBox1.ShowInfo("Please Provide Director Name");
                return;
            }

        }
        protected void gridviewinstallment_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_installment_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_installment_details"] = dt;

            dt.AcceptChanges();


            temp_installment_details_DataBind();


        }
        protected void ShareHolderDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_shareholder_details"] = dt;

            dt.AcceptChanges();


            temp_shareholder_details_DataBind();


        }
        protected void TrusteeDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_trustee_details"] = dt;

            dt.AcceptChanges();


            temp_trustee_details_DataBind();


        }
        protected void DirectorDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_directors_details"] = dt;

            dt.AcceptChanges();


            temp_director_details_DataBind();


        }
        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                ddlArea.DataSource = ds;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void Reset_Click1(object sender, EventArgs e)
        {
            ResetControl1();
        }

        private void ResetControl1()
        {
            btn_first_save.Text = "Save";
            Conform_CheckBox_multiview_1.Checked = false;

            Final_Submit.Text = "Submit";
            Final_Submit.Enabled = true;

            ddlArea.SelectedIndex = 0;
            txtAllotment.Text = "";
            txtAllotment1.Text = "";
            txtPlotNo.Text = "";
            txtFileNo.Text = "";
            txtCompanyname.Text = "";
            drppollutionCategory.SelectedIndex = 0;

            ddlcompanytype.SelectedIndex = 0;
            txtAuthorisedSignatory.Text = "";
            txtSignatoryAddress.Text = "";
            txtSignatoryEmail.Text = "";
            txtSignatoryPhone.Text = "";

            txtIndividualName.Text = "";
            txtIndividualAddress.Text = "";
            txtIndividualPhone.Text = "";
            txtIndividualEmail.Text = "";
            txtPanNo.Text = "";
            txtCinNo.Text = "";
            tr2.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            tr8.Visible = false;
            Conform_CheckBox_multiview_1.Checked = false;
            Conform_CheckBox_multiview_1_CheckChanged(null, null);
            txtAllotmenttLetterApplicationDate.Text = "";
            chkfumes.Checked = false;
            chkfumes_CheckedChanged(null, null);
            chkpriority.Checked = false;
            chkpriority_CheckedChanged(null, null);
            CheckBox_Final.Checked = false;
            Confirm_CheckBox_final(null, null);
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            dt.Rows.Clear();
            ViewState["temp_trustee_details"] = dt;
            temp_trustee_details_DataBind();
            DataTable dt1 = (DataTable)ViewState["temp_shareholder_details"];
            dt1.Rows.Clear();
            ViewState["temp_shareholder_details"] = dt1;
            temp_shareholder_details_DataBind();

            DataTable dt2 = (DataTable)ViewState["temp_directors_details"];
            dt2.Rows.Clear();
            ViewState["temp_directors_details"] = dt2;
            temp_director_details_DataBind();
            DataTable dt3 = (DataTable)ViewState["temp_partnership_details"];
            dt3.Rows.Clear();
            ViewState["temp_partnership_details"] = dt3;
            temp_partnership_details_DataBind();

            DataTable dt10 = (DataTable)ViewState["temp_installment_details"];
            dt10.Rows.Clear();
            ViewState["temp_installment_details"] = dt10;
            temp_installment_details_DataBind();


            DataTable dt11 = (DataTable)ViewState["temp_TEF_details"];
            dt11.Rows.Clear();
            ViewState["temp_TEF_details"] = dt11;
            temp_TEF_details_DataBind();

            gridviewpayment_DataBind();

            ddlArea.Enabled = true;
            txtAllotment1.Enabled = true;

            DirectorsGrid.ShowFooter = true;
            txtCompanyname.Enabled = true;
            txtFileNo.Enabled = true;
            ddlcompanytype.Enabled = true;
            txtPanNo.Enabled = true;
            txtCinNo.Enabled = true;
            txtAuthorisedSignatory.Enabled = true;
            txtSignatoryAddress.Enabled = true;
            txtSignatoryEmail.Enabled = true;
            txtSignatoryPhone.Enabled = true;
            txtAuthorisedSignatory.Enabled = true;

            txtSector.Enabled = true;
            txtIndividualName.Enabled = true;
            txtIndividualAddress.Enabled = true;
            txtIndividualEmail.Enabled = true;
            txtIndividualPhone.Enabled = true;
            Trustee_details_grid.ShowFooter = true;
            gridshareholder.ShowFooter = true;
            PartnershipFirmGrid.ShowFooter = true;

            TEFGrid.ShowFooter = true;

            txtAllotmentRate.Enabled = true;
            txtlocationcharge.Enabled = true;
            txtAllotmentRate.Enabled = true;
            txtAllotmentRate.Enabled = true;


            txtProductManufactured.Text = "";
            txtTotalArea.Text = "";
            txttotalAreaPayment.Text = "";

            txtalltLetterIssueDate.Text = "";
            txtLeaseDeed.Text = "";
            txtExecLeaseDeed.Text = "";

            txtBuildingDate.Text = "";

            txtReloccertificate.Text = "";
            txtDateofAllottementNo.Text = "";
            txtDateCompletion.Text = "";
            txtcomcertificate.Text = "";


            lblAuthoriseduseremail.Text = "";
            lblAuthoriseduseraddress.Text = "";


            lbl_manufactured_product.Text = "";
            lbl_alloted_parea.Text = "";
            lbl_allotment_issue_date.Text = "";
            lbl_lease_date.Text = "";
            lbl_lease_agreement_date.Text = "";

            lbl_date_of_bps.Text = "";
            lbl_date_of_roc.Text = "";
            lbl_inspection_date_for_complition.Text = "";
            lbl_inspection_date.Text = "";


            lbl_date_of_rel_completion.Text = "";




            txtInspectionDate.Text = "";
            txtInspectioncompletion.Text = "";


            ///////////////////// Project Data Reset
            txttypeofindustry.Text = "";
            txtestimatedcost.Text = "";
            txtestimatedemployment.Text = "";
            txtProjectStartPeriod.Text = "";
            txtcoveredarea.Text = "";
            txtopenarearequired.Text = "";
            txtland.Text = "";
            txtbuilding.Text = "";
            txtmachinery.Text = "";
            txteffluentsolidqty.Text = "";
            txteffluentsolidcomposition.Text = "";
            txteffluentliquidqty.Text = "";
            txteffluentliquidcomposition.Text = "";
            txteffluentgaseousqty.Text = "";
            txteffluentgaseouscomposition.Text = "";
            txtfumeqty.Text = "";
            txtfumenature.Text = "";
            txteffluenttreatmentmeasure1.Text = "";
            txteffluenttreatmentmeasure2.Text = "";
            txteffluenttreatmentmeasure3.Text = "";
            txtpowerreq.Text = "";
            txttelephonefirstyearreq1.Text = "";
            txttelephonefirstyearreq2.Text = "";
            txttelephoneUltimateyearreq1.Text = "";
            txttelephoneUltimateyearreq2.Text = "";
            txtapplicantpriorityspecification.Text = "";
            chkfumes.Checked = false;
            chkpriority.Checked = false;

            //////////////////////////

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                int id = Convert.ToInt32(temp_allotteeid_lbl.Text);


                SqlCommand cmd2 = new SqlCommand("select * from AllotteeMaster where AllotmentLetterNo='" + lblAllotmentLetterNo.Text.Trim() + "' ", con, transaction);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adp1.Fill(dt);
                if (dt.Rows.Count <= 0)
                {

                    if (txtResponse.Text == "" || txtResponse.Text == null)
                    {


                        MessageBox1.ShowInfo("Please Enter Allottee Response");
                        return;
                    }
                    else
                    {
                        if (txtResponseDatetime.Text == "" || txtResponseDatetime.Text == null)
                        {

                            MessageBox1.ShowInfo("Please Enter Response Datetime");
                            return;


                        }
                        else
                        {
                            command.CommandText = ("UpdateResponseInAllotteeTempRegister '" + txtResponse.Text.Trim() + "','" + txtResponseDatetime.Text.Trim() + "'," + id + "");
                            command.ExecuteNonQuery();
                        }
                    }

                    if (transactionResult)
                    {
                        transaction.Commit();

                        MessageBox1.ShowSuccess("Allottee Response Updated Succesfully");
                        txtAllotment1.Text = lblAllotmentLetterNo.Text;
                        MultiView1.ActiveViewIndex = 1;
                    }
                    else
                    {

                        transaction.Rollback();


                        MessageBox1.ShowError("Some Error Occured");
                        return;
                    }
                }
                else
                {


                    MessageBox1.ShowError("Some Error Occured");
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        protected void btnComupdate_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                int id = Convert.ToInt32(temp_allotteeid_lbl.Text);

                if (CommunicationModeChk.SelectedValue == "Email")
                {
                    command.CommandText = ("UpdateCommunicationInAllotteeTempRegister '" + CommunicationModeChk.SelectedValue + "','" + txtmail.Text.Trim() + "','" + txtDatetime.Text.Trim() + "','" + System.DBNull.Value + "'," + id + "");
                    command.ExecuteNonQuery();
                }
                if (CommunicationModeChk.SelectedValue == "Phone")
                {
                    command.CommandText = ("UpdateCommunicationInAllotteeTempRegister '" + CommunicationModeChk.SelectedValue + "','" + txtphonec.Text.Trim() + "','" + txtpdatetime.Text.Trim() + "','" + System.DBNull.Value + "'," + id + "");
                    command.ExecuteNonQuery();
                }
                if (CommunicationModeChk.SelectedValue == "Registered Post")
                {
                    command.CommandText = ("UpdateCommunicationInAllotteeTempRegister '" + CommunicationModeChk.SelectedValue + "','" + txtcomaddress.Text.Trim() + "','" + txtaddressdatetime.Text.Trim() + "','" + txtspeedpost.Text.Trim() + "'," + id + "");
                    command.ExecuteNonQuery();
                }



                if (transactionResult)
                {
                    transaction.Commit();

                    MessageBox1.ShowSuccess("Communication Details Updated Succesfully");

                }
                else
                {

                    transaction.Rollback();


                    MessageBox1.ShowError("Some Error Occured");
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }



        }

        protected void btnResetCom_Click(object sender, EventArgs e)
        {
            resetcom();
        }

        protected void btnResetCom1_Click(object sender, EventArgs e)
        {

            txtmail.Text = "";
            txtDatetime.Text = "";
            txtphonec.Text = "";
            txtpdatetime.Text = "";
            txtcomaddress.Text = "";
            txtaddressdatetime.Text = "";
            txtspeedpost.Text = "";

        }

        private void resetcom()
        {
            txtmail.Text = "";
            txtDatetime.Text = "";
            txtphonec.Text = "";
            txtpdatetime.Text = "";
            txtcomaddress.Text = "";
            txtaddressdatetime.Text = "";
            txtspeedpost.Text = "";
            foreach (ListItem item in CommunicationModeChk.Items)
            {
                //check anything out here
                if (item.Selected)
                    item.Selected = false;
            }
            row1.Visible = false;
            row2.Visible = false;
            row3.Visible = false;
            row4.Visible = false;
        }

        private void getcommunicattiondetail()
        {
            int id = Convert.ToInt32(temp_allotteeid_lbl.Text);

            SqlCommand cmd = new SqlCommand("Select CommunicationMode,CommunicationSource,CommunicationDatetime,AllotteeResponse,ResponseDatetime,SpeedPostId from AllotteeTempRegister where AllotteeId = " + id + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CommunicationMode"].ToString() == "Email")
                {
                    CommunicationModeChk.SelectedIndex = 0;
                    row1.Visible = true;
                    txtmail.Text = dt.Rows[0]["CommunicationSource"].ToString();
                    txtDatetime.Text = dt.Rows[0]["CommunicationDatetime"].ToString();

                }
                else
                {
                    row1.Visible = false;
                }
                if (dt.Rows[0]["CommunicationMode"].ToString() == "Phone")
                {
                    CommunicationModeChk.SelectedIndex = 1;
                    row2.Visible = true;
                    txtphonec.Text = dt.Rows[0]["CommunicationSource"].ToString();
                    txtpdatetime.Text = dt.Rows[0]["CommunicationDatetime"].ToString();

                }
                else
                {
                    row2.Visible = false;
                }
                if (dt.Rows[0]["CommunicationMode"].ToString() == "Registered Post")
                {
                    CommunicationModeChk.SelectedIndex = 2;
                    row3.Visible = true;
                    txtcomaddress.Text = dt.Rows[0]["CommunicationSource"].ToString();
                    txtaddressdatetime.Text = dt.Rows[0]["CommunicationDatetime"].ToString();
                    txtspeedpost.Text = dt.Rows[0]["SpeedPostId"].ToString();

                }
                else
                {
                    row3.Visible = false;
                }

                if (dt.Rows[0]["AllotteeResponse"].ToString() != "" || dt.Rows[0]["AllotteeResponse"].ToString() != null)
                {
                    txtResponse.Text = dt.Rows[0]["AllotteeResponse"].ToString();
                }
                else
                {
                    txtResponse.Text = "";
                }
                if (dt.Rows[0]["ResponseDatetime"].ToString() != "" || dt.Rows[0]["ResponseDatetime"].ToString() != null)
                {
                    txtResponseDatetime.Text = dt.Rows[0]["ResponseDatetime"].ToString();
                }
                else
                {
                    txtResponseDatetime.Text = "";
                }
            }

        }

        protected void chkpriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpriority.Checked == true)
            {
                prioritydiv.Visible = true;
            }
            else
            {
                txtapplicantpriorityspecification.Text = "";
                prioritydiv.Visible = false;
            }
        }

        protected void chkfumes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfumes.Checked == true)
            {
                fumesdiv.Visible = true;
            }
            else
            {
                txtfumeqty.Text = "";
                txtfumenature.Text = "";
                fumesdiv.Visible = false;
            }
        }

        protected void ddl_ProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {



                ds = objServiceTimelinesBLL.GetProductSubCategory(ddl_ProductCategory.SelectedValue.Trim());
                ddl_ProductSubCategory.DataSource = ds;
                ddl_ProductSubCategory.DataTextField = "Product Sub Category";
                ddl_ProductSubCategory.DataValueField = "HSC_4";
                ddl_ProductSubCategory.DataBind();
                ddl_ProductSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void ddl_ProductSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                string SubCategory = "";
                foreach (ListItem ddl_ProductSubCategory in this.ddl_ProductSubCategory.Items)
                {
                    if (ddl_ProductSubCategory.Selected == true)
                    {
                        SubCategory = SubCategory + ddl_ProductSubCategory.Value + ",";
                    }
                }
                ds = objServiceTimelinesBLL.GetHSCProductName(SubCategory.TrimEnd(',').Trim());
                lst_ProductName.DataSource = ds;
                lst_ProductName.DataTextField = "Product";
                lst_ProductName.DataValueField = "HSC_8";
                lst_ProductName.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }

        }


        protected void btn_project_detail_submit_Click(object sender, EventArgs e)
        {
            try
            {
                    int retval = 0;
                    int fume_status = 0; int priority_status = 0;
                    string ProductName = "";
                    if (ddlTypeOfIndustry.SelectedIndex == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry');", true);
                        return;
                    }
                    //if (ddl_ProductCategory.SelectedIndex == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Product Category of industry');", true);
                    //    return;
                    //}
                    //if (ddl_ProductSubCategory.SelectedIndex == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Product Sub Category of industry');", true);
                    //    return;
                    //}
                    if (Drop1.SelectedIndex == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Export Oriented Industry');", true);
                        return;
                    }
                    if (drppollutionCategory.SelectedIndex == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Pollution Category');", true);
                        return;
                    }
                    //if (lst_ProductName.SelectedIndex == -1)
                    //{
                    //    MessageBox1.ShowWarning("Please Provide Product Name(HSN_8 Code) ");
                    //    return;
                    //}
                    foreach (ListItem drpIndustriesAllowed in this.lst_ProductName.Items)
                    {
                        if (drpIndustriesAllowed.Selected == true)
                        {
                            ProductName = ProductName + drpIndustriesAllowed.Value + ",";
                        }
                    }
                    string SubCategory = "";
                    foreach (ListItem ddl_ProductSubCategory in this.ddl_ProductSubCategory.Items)
                    {
                        if (ddl_ProductSubCategory.Selected == true)
                        {
                            SubCategory = SubCategory + ddl_ProductSubCategory.Value + ",";
                        }
                    }
                    if (chkfumes.Checked == true)
                    {
                        fume_status = 1;
                    }
                    else
                    {
                        fume_status = 0;
                    }
                    if (chkpriority.Checked == true)
                    {
                        priority_status = 1;
                    }
                    else
                    {
                        priority_status = 0;
                    }
                    objServiceTimelinesBEL.ID = Convert.ToInt32(Session["AllotteeID"].ToString()); ;
                    if (txttypeofindustry.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.IndustryType = txttypeofindustry.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.IndustryType = "";
                    }
                    if (txtestimatedcost.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.EstimatedCostOfProject = Convert.ToDecimal(txtestimatedcost.Text.Trim());
                    }
                    else
                    {
                        objServiceTimelinesBEL.EstimatedCostOfProject = Convert.ToDecimal((0).ToString());
                    }
                    if (txtestimatedemployment.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.EstimatedEmploymentGeneration = txtestimatedemployment.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.EstimatedEmploymentGeneration = (0).ToString();
                    }
                    if (txtcoveredarea.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.CoveredArea = txtcoveredarea.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.CoveredArea = (0).ToString();
                    }
                    if (txtcoveredarea.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.CoveredArea = txtcoveredarea.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.CoveredArea = (0).ToString();
                    }
                    if (txtopenarearequired.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.OpenAreaRequired = txtopenarearequired.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.OpenAreaRequired = (0).ToString();
                    }
                    if (txtland.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.LandDetails = txtland.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandDetails = (0).ToString();
                    }
                    if (txtbuilding.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.BuildingDetails = txtbuilding.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.BuildingDetails = (0).ToString();
                    }
                    if (txtmachinery.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.MachineryEquipmentsDetails = txtmachinery.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.MachineryEquipmentsDetails = (0).ToString();
                    }
                    objServiceTimelinesBEL.IndustrialEffluentSolidqty = txteffluentsolidqty.Text.Trim();
                    objServiceTimelinesBEL.IndustrialEffluentSolidComposition = txteffluentsolidcomposition.Text.Trim();
                    objServiceTimelinesBEL.IndustrialEffluentLiquidqty = txteffluentliquidqty.Text.Trim();
                    objServiceTimelinesBEL.IndustrialEffluentLiquidComposition = txteffluentliquidcomposition.Text.Trim();
                    objServiceTimelinesBEL.IndustrialEffluentGaseousqty = txteffluentgaseousqty.Text.Trim();
                    objServiceTimelinesBEL.IndustrialEffluentGaseousComposition = txteffluentgaseouscomposition.Text.Trim();
                    objServiceTimelinesBEL.FumeGenerationStatus = fume_status.ToString().Trim();
                    objServiceTimelinesBEL.FumeQuantity = txtfumeqty.Text.Trim();
                    objServiceTimelinesBEL.FumeNature = txtfumenature.Text.Trim();
                    objServiceTimelinesBEL.EffluentTreatmentMeasure1 = txteffluenttreatmentmeasure1.Text.Trim();
                    objServiceTimelinesBEL.EffluentTreatmentMeasure2 = txteffluenttreatmentmeasure2.Text.Trim();
                    objServiceTimelinesBEL.EffluentTreatmentMeasure3 = txteffluenttreatmentmeasure3.Text.Trim();
                    objServiceTimelinesBEL.PowerReqInKW = txtpowerreq.Text.Trim();
                    objServiceTimelinesBEL.TelephoneReqFirstYear1 = txttelephonefirstyearreq1.Text.Trim();
                    objServiceTimelinesBEL.TelephoneReqFirstYear2 = txttelephonefirstyearreq2.Text.Trim();
                    objServiceTimelinesBEL.TelephoneReqUltimate1 = txttelephoneUltimateyearreq1.Text.Trim();
                    objServiceTimelinesBEL.TelephoneReqUltimate2 = txttelephoneUltimateyearreq2.Text.Trim();
                    objServiceTimelinesBEL.ApplicantPriorityStatus = priority_status.ToString().Trim();
                    if (chkpriority.Checked == true)
                    {
                        objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                    }
                    objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();
                    if (txtOtherExpenses.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                    }
                    if (txtOwnResources.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.OwnResources = Convert.ToDecimal(txtOwnResources.Text.Trim());
                    }
                    else
                    {
                        objServiceTimelinesBEL.OwnResources = Convert.ToDecimal((0).ToString());
                    }
                    if (txtOwnResources.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.FI = Convert.ToDecimal(txtFI.Text.Trim());
                    }
                    else
                    {
                        objServiceTimelinesBEL.FI = Convert.ToDecimal((0).ToString());
                    }
                    if (txtTurnover.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.NetTurnOver = txtTurnover.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.NetTurnOver = ((0).ToString());
                    }
                    if (txtNetWorth.Text.Length > 0)
                    {
                        objServiceTimelinesBEL.Networth = txtNetWorth.Text.Trim();
                    }
                    else
                    {
                        objServiceTimelinesBEL.Networth = ((0).ToString());
                    }
                    objServiceTimelinesBEL.FAR = txtFAR.Text.Trim();
                    objServiceTimelinesBEL.pollutionCategory = Convert.ToInt32(drppollutionCategory.SelectedValue.Trim());
                    objServiceTimelinesBEL.projectstartmonths = txtProjectStartPeriod.Text.Trim();
                    objServiceTimelinesBEL.workexperience = txtWorkExperience.Text.Trim();
                    objServiceTimelinesBEL.HSProductCategory = ddl_ProductCategory.SelectedValue.Trim();
                    objServiceTimelinesBEL.HSProductSubCategory = SubCategory.TrimEnd(',').Trim();
                    objServiceTimelinesBEL.HSProductName = ProductName.TrimEnd(',').Trim();
                    objServiceTimelinesBEL.ExportOriented = Drop1.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.IAType = Convert.ToInt32(ddlTypeOfIndustry.SelectedValue.Trim());
                    retval = objServiceTimelinesBLL.UpdateAllotteeProjectDetails(objServiceTimelinesBEL);
                    if(retval>0)
                    {
                        string message = "Applicant Project Details Saved Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetAllAllotteeDetailsFilledById(int.Parse(Session["AllotteeID"].ToString()));
                        MultiView1.ActiveViewIndex = 2;
                    }
                    else
                    {
                    string message = "Applicant Project Details Not Updated";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                }
            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
            
        }

        protected void btn_project_details_reset_Click(object sender, EventArgs e)
        {
            txttypeofindustry.Text = "";
            txtestimatedcost.Text = "";
            txtestimatedemployment.Text = "";
            txtcoveredarea.Text = "";
            txtopenarearequired.Text = "";
            txtland.Text = "";
            txtbuilding.Text = "";
            txtmachinery.Text = "";
            txteffluentsolidqty.Text = "";
            txteffluentsolidcomposition.Text = "";
            txteffluentliquidqty.Text = "";
            txteffluentliquidcomposition.Text = "";
            txteffluentgaseousqty.Text = "";
            txteffluentgaseouscomposition.Text = "";
            txtfumeqty.Text = "";
            txtfumenature.Text = "";
            txteffluenttreatmentmeasure1.Text = "";
            txteffluenttreatmentmeasure2.Text = "";
            txteffluenttreatmentmeasure3.Text = "";
            txtpowerreq.Text = "";
            txttelephonefirstyearreq1.Text = "";
            txttelephonefirstyearreq2.Text = "";
            txttelephoneUltimateyearreq1.Text = "";
            txttelephoneUltimateyearreq2.Text = "";
            txtapplicantpriorityspecification.Text = "";
            chkfumes.Checked = false;
            chkpriority.Checked = false;
            txtOwnResources.Text = "";
            txtFI.Text = "";
            txtFAR.Text = "";
        }

        #endregion
        protected void drpdPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drpdPaymentMode = (gridviewpayment.FooterRow.FindControl("drpdPaymentMode") as DropDownList).SelectedValue.Trim();

            gridviewpayment.FooterRow.FindControl("txtDraftNo").Visible = false;
            gridviewpayment.FooterRow.FindControl("txtTransactionNo").Visible = false;
            gridviewpayment.FooterRow.FindControl("txtChequeNo").Visible = false;

            if (drpdPaymentMode == "Demand Draft")
            {
                gridviewpayment.FooterRow.FindControl("txtDraftNo").Visible = true;
            }
            else if (drpdPaymentMode == "Online Payment")
            {
                gridviewpayment.FooterRow.FindControl("txtTransactionNo").Visible = true;
            }
            else if (drpdPaymentMode == "Bank Guarantee")
            {

            }
            else if (drpdPaymentMode == "Cheque")
            {
                gridviewpayment.FooterRow.FindControl("txtChequeNo").Visible = true;
            }


        }
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
            ResetControl1();
            MultiView1.ActiveViewIndex = 0;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void NewAllottee_ServerClick(object sender, EventArgs e)
        {


            New_Allottee_Registration_btn_click(null, null);
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
            txtPlotNo.Enabled = false;
            Chooseplot.Visible = true;
            lblNewButton.Text = "1";
        }
        protected void Reset_ServerClick(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 9)
            {
                reset_legal();
            }
        }
        protected void HistoryAllottee_ServerClick(object sender, EventArgs e)
        {
            New_Allottee_Registration_btn_click(null, null);
            txtPlotNo.Enabled = false;
            Chooseplot.Visible = true;
            hrefPrint.Visible = false;
            hrefPrint1.Visible = false;
        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {
                if (Conform_CheckBox_multiview_1.Checked == true)
                {
                    btn_first_Click(null, null);
                }
                else
                {
                    MessageBox1.ShowWarning("Please Check Checkbox At the bottom");
                    return;


                }
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                btn_project_detail_submit_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                btnSubmit_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 4)
            {
                if (Final_Submit.Enabled == true)
                {
                    Final_Submit_Click(null, null);
                }
                else
                {
                    MessageBox1.ShowWarning("First Check The CheckBox at the bottom");
                    return;
                }
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                Next3_Click(null, null);
                installmentSave_Click(null, null);
            }
            //else if (MultiView1.ActiveViewIndex == 9)
            //{
            //    if (txtCaseNo.Text == "" || txtCaseNo.Text == null)
            //    { btnLegalNext_Click(null, null); }
            //    else
            //    {
            //        btnLegalSaveEntry_Click(null, null);
            //    }
            //}
        }
        protected void next_server_click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 1)
            {
                if (btnNext.Enabled == true)
                {
                    btnNext_Click(null, null);
                }
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                Next5_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                btnNext1_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                Next3_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 9)
            {
                btnLegalNext_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 10)
            {
                btnDuesNext_Click(null, null);
            }
        }
        protected void prev_server_click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 1)
            {
                Previous_home_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                Previous5_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                Previous_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                Previous1_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 4)
            {
                Previous3_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 8)
            {
                MultiView1.ActiveViewIndex = 0;
                hrefPrint.Visible = false;
                hrefPrint1.Visible = false;
            }
            else if (MultiView1.ActiveViewIndex == 7)
            {
                MultiView1.ActiveViewIndex = 0;
                hrefPrint.Visible = false;
                hrefPrint1.Visible = false;
            }
            else if (MultiView1.ActiveViewIndex == 9)
            {
                btnLegalPrevious_Click(null, null);
            }
            else if (MultiView1.ActiveViewIndex == 10)
            {
                btnDuesPre_Click(null, null);
            }
        }
        protected void txtNoOfStamp_TextChanged(object sender, EventArgs e)
        {
            if (txtNoOfStamp.Text == "" || txtNoOfStamp.Text == null)
            {
                txtNoOfStamp.Text = "0";
            }
            if (txtStampAmoount.Text == "" || txtStampAmoount.Text == null)
            {
                txtStampAmoount.Text = "0";
            }
            txtTotalStampDuty.Text = (Convert.ToDecimal(txtNoOfStamp.Text) * Convert.ToDecimal(txtStampAmoount.Text)).ToString("0.00");
        }
        protected void Allottee_master_grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int AllotteeId = Convert.ToInt32(e.CommandArgument);
            lblAllotteeID.Text = AllotteeId.ToString();
            if (e.CommandName == "ViewRow")
            {
                MultiView1.ActiveViewIndex = 4;
                hrefPrint.Visible = true;
                hrefPrint1.Visible = false;
                GetAllAllotteeDetailsFilledById(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "Unfinalized")
            {
                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    //SqlCommand cmd = new SqlCommand("select isnull(IsLock,0) from AllotteeMaster where AllotteeID=" + AllotteeId + " ", con, transaction);
                    //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //adp.Fill(dt);

                    //if (dt.Rows[0][0].ToString() == "True")
                    //{

                    //    MessageBox1.ShowWarning("Data Is Locked. Only CMI Can Unlock It");
                    //    return;

                    //}
                    command = new SqlCommand(@"[UnfinalizedAllotteeDetails_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AllotteeId", AllotteeId);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                    if (transactionResult)
                    {
                        transaction.Commit();
                        string message = "Allottee Revert Back Successfully";
                        MessageBox1.ShowSuccess(message);
                        GetNewAllotteeDetails();
                    }
                    else
                    {

                        transaction.Rollback();
                        MessageBox1.ShowError("Some Error Occured");
                        return;


                    }
                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }


            }
            if (e.CommandName == "lock")
            {
                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {


                    command = new SqlCommand(@"[LockAllotteeDetails_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AllotteeId", lblAllotteeID.Text.Trim());

                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        string message = "Allottee Data Locked Successfully";
                        MessageBox1.ShowSuccess(message);
                        GetNewAllotteeDetails();
                    }
                    else
                    {

                        transaction.Rollback();
                        MessageBox1.ShowError("Some Error Occured");
                        return;


                    }
                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }
            }

            if (e.CommandName == "Unlock")
            {
                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    command = new SqlCommand(@"[UnLockAllotteeDetails_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AllotteeId", lblAllotteeID.Text.Trim());

                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        string message = "Allottee Data UnLocked Successfully";
                        MessageBox1.ShowSuccess(message);
                        GetNewAllotteeDetails();
                    }
                    else
                    {

                        transaction.Rollback();
                        MessageBox1.ShowError("Some Error Occured");
                        return;


                    }
                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }
            }
        }
        protected void GridView1_pending_process_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1_pending_process.PageIndex = e.NewPageIndex;
            this.GetNewAllotteeDetails();
        }
        protected void btnLegalSaveEntry_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (txtCaseNo.Text == "" || txtCaseNo.Text == null)
                { MessageBox1.ShowInfo("Case No Is Must"); return; }

                if (radio1.SelectedIndex == -1)
                { MessageBox1.ShowInfo("Please select who You are"); return; }

                if (DdlJurisdiction.SelectedIndex == 0)
                { MessageBox1.ShowInfo("Please select Jurisdiction"); return; }

                if (DdlCaseStatus.SelectedIndex == 0)
                { MessageBox1.ShowInfo("Please Select Case Status"); return; }

                if (txtNextHearingDate.Text == "" || txtNextHearingDate.Text == null)
                { MessageBox1.ShowInfo("Please Provide Next Hearing Date"); return; }
                else
                {



                    if (ValidateDate(txtNextHearingDate.Text))
                    {

                    }
                    else
                    {
                        txtNextHearingDate.Focus();
                        MessageBox1.ShowError("Invalid Next Hearing Date");
                        return;
                    }

                }

                string date_to_be = DateTime.ParseExact(txtNextHearingDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                //  objServiceTimelinesBEL.DateOfExecutionAgreement = Convert.ToDateTime((date_to_be));

                command = new SqlCommand(@"[InsertPlotLegalHistory]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicantId", lblletterno.Text.Trim());
                command.Parameters.AddWithValue("@PlotNo", lblPlotno.Text.Trim());
                command.Parameters.AddWithValue("@CaseNo", txtCaseNo.Text.Trim());
                command.Parameters.AddWithValue("@WeAre", radio1.SelectedValue.Trim());
                command.Parameters.AddWithValue("@LTPartyName", txtLtPartyName.Text.Trim());
                command.Parameters.AddWithValue("@Jurisdiction", DdlJurisdiction.SelectedValue.Trim());
                command.Parameters.AddWithValue("@CourtDetails", txtCourtDetails.Text.Trim());
                command.Parameters.AddWithValue("@InCourtOf", txtInCourtof.Text.Trim());
                command.Parameters.AddWithValue("@MatterDetails", txtMatterDetails.Text.Trim());
                command.Parameters.AddWithValue("@CaseStatus", DdlCaseStatus.SelectedValue.Trim());
                command.Parameters.AddWithValue("@LitigatingParty", txtLitigatingParty.Text.Trim());
                command.Parameters.AddWithValue("@PetAdvocateName", txtPetAdvocateName.Text.Trim());
                command.Parameters.AddWithValue("@PetAdvocateAddress", txtPetAddress.Text.Trim());
                command.Parameters.AddWithValue("@PetAdvocateContact", txtPetContactNo.Text.Trim());
                command.Parameters.AddWithValue("@ResAdvocateName", txtResAdvocateName.Text.Trim());
                command.Parameters.AddWithValue("@ResAdvocateAddress", txtResAddress.Text.Trim());
                command.Parameters.AddWithValue("@ResAdvocateContact", txtResContact.Text);
                command.Parameters.AddWithValue("@CurrentStatus", txtCurrentStatus.Text.Trim());
                command.Parameters.AddWithValue("@NextHearingDate", Convert.ToDateTime((date_to_be)));

                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));




                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Plot Legal History Inserted/Updated Successfully");
                    reset_legal();
                    bindlegalhistory();
                    return;

                }
                else
                {

                    transaction.Rollback();
                    MessageBox1.ShowError("Some Error Ocurred");
                    return;

                }
            }


            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }


        }
        private void reset_legal()
        {
            txtCaseNo.Text = "";
            radio1.SelectedIndex = -1;
            DdlCaseStatus.SelectedIndex = 0;
            DdlJurisdiction.SelectedIndex = 0;
            txtLtPartyName.Text = "";
            txtCourtDetails.Text = "";
            txtInCourtof.Text = "";
            txtMatterDetails.Text = "";
            txtLitigatingParty.Text = "";
            txtPetAddress.Text = "";
            txtPetAdvocateName.Text = "";
            txtPetContactNo.Text = "";
            txtResAddress.Text = "";
            txtResAdvocateName.Text = "";
            txtResContact.Text = "";
            txtCurrentStatus.Text = "";
            txtNextHearingDate.Text = "";


        }
        private void bindlegalhistory()
        {

            SqlCommand cmd = new SqlCommand("[GetLegalhistory_sp] '" + lblletterno.Text.Trim() + "','" + lblPlotno.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            LegalGrid.DataSource = dt;
            LegalGrid.DataBind();
        }
        protected void LegalGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Allottee_master_grid.PageIndex = e.NewPageIndex;
            bindlegalhistory();
        }

        protected void LegalGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string caseNo = e.CommandArgument.ToString();

                SqlCommand cmd = new SqlCommand("[GetLegalhistoryCaseWise_sp] '" + lblletterno.Text.Trim() + "','" + lblPlotno.Text.Trim() + "','" + caseNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCaseNo.Text = dt.Rows[0]["CaseNo"].ToString();
                    radio1.SelectedValue = dt.Rows[0]["WeAre"].ToString().Trim();
                    txtLtPartyName.Text = dt.Rows[0]["LTPartyName"].ToString();
                    DdlJurisdiction.SelectedValue = dt.Rows[0]["Jurisdiction"].ToString().Trim();
                    txtCourtDetails.Text = dt.Rows[0]["CourtDetails"].ToString();
                    txtInCourtof.Text = dt.Rows[0]["InCourtOf"].ToString();
                    txtMatterDetails.Text = dt.Rows[0]["MatterDetails"].ToString();
                    DdlCaseStatus.SelectedValue = dt.Rows[0]["CaseStatus"].ToString().Trim();
                    txtLitigatingParty.Text = dt.Rows[0]["LitigatingParty"].ToString();
                    txtPetAdvocateName.Text = dt.Rows[0]["PetAdvocateName"].ToString();
                    txtPetAddress.Text = dt.Rows[0]["PetAdvocateAddress"].ToString();
                    txtPetContactNo.Text = dt.Rows[0]["PetAdvocateContact"].ToString();
                    txtResAdvocateName.Text = dt.Rows[0]["ResAdvocateName"].ToString();
                    txtResAddress.Text = dt.Rows[0]["ResAdvocateAddress"].ToString();
                    txtResContact.Text = dt.Rows[0]["ResAdvocateContact"].ToString();
                    txtCurrentStatus.Text = dt.Rows[0]["CurrentStatus"].ToString();
                    txtNextHearingDate.Text = dt.Rows[0]["NextHearingDate1"].ToString();

                }
                else
                {
                    reset_legal();
                }

            }
            if (e.CommandName == "DeleteCase")
            {
                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    string caseNo = e.CommandArgument.ToString();
                    command = new SqlCommand(@"[DeleteLegalhistoryCaseWise_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicantId", lblletterno.Text.Trim());
                    command.Parameters.AddWithValue("@PlotNo", lblPlotno.Text.Trim());
                    command.Parameters.AddWithValue("@CaseNo", caseNo.Trim());
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("Plot Legal History Deleted Successfully");
                        reset_legal();
                        bindlegalhistory();


                    }
                    else
                    {

                        transaction.Rollback();
                        MessageBox1.ShowError("Some Error Ocurred");
                        return;

                    }
                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }
            }

        }

        protected void DdlCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlCaseType.SelectedValue == "Transfer Case")
            {
                Case1.Visible = true;
                tccase.Visible = true;
                ChangeofPlot.Visible = false;
                bindTransfercase();
            }
            else if (DdlCaseType.SelectedValue == "Change of Plot")
            {
                Case1.Visible = false;
                ChangeofPlot.Visible = true;
                tccase.Visible = true;
                bindTransfercase();

            }
            else
            {
                Case1.Visible = false;
                ChangeofPlot.Visible = false;
                tccase.Visible = false;
            }
        }

        public void bindTransfercase()
        {
            DataSet dsR = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("[GetTransferLevyCaseType]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlTranserCase.DataSource = dt;
                ddlTranserCase.DataTextField = "Type";
                ddlTranserCase.DataValueField = "Id";
                ddlTranserCase.DataBind();
                ddlTranserCase.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void btnLock_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {


                command = new SqlCommand(@"[LockAllotteeDetails_sp]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AllotteeId", lblAllotteeID.Text.Trim());

                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Allottee Data Locked Successfully";
                    MessageBox1.ShowSuccess(message);
                    GetNewAllotteeDetails();
                }
                else
                {

                    transaction.Rollback();
                    MessageBox1.ShowError("Some Error Occured");
                    return;


                }
            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        protected void btnUnlock_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                command = new SqlCommand(@"[UnLockAllotteeDetails_sp]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AllotteeId", lblAllotteeID.Text.Trim());

                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Allottee Data UnLocked Successfully";
                    MessageBox1.ShowSuccess(message);
                    GetNewAllotteeDetails();
                }
                else
                {

                    transaction.Rollback();
                    MessageBox1.ShowError("Some Error Occured");
                    return;


                }
            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        protected void drpdwnSector_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                txtSector.Text = drpdwnSector.SelectedItem.Text.Trim();
            }
            catch (Exception ex)
            {
                Response.Write("Sector Not Provided :" + ex.Message.ToString());
            }
        }


        protected void PlotDDl_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPlotNo.Text = PlotDDl.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.IAId = Convert.ToInt32(ddlArea.SelectedValue.Trim());
            objServiceTimelinesBEL.PlotNumber = PlotDDl.SelectedItem.Text.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPlotArea(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    txtTotalArea.Text = dt.Rows[0]["PlotArea"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.IAIdParam = ddlArea.SelectedValue.Trim();
            DataSet ds = new DataSet();
            DataSet dsGisPlotMaster = new DataSet();
            DataSet dsSectorMaster = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetListOfAllotteedPlotsIAWise(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PlotDDl.DataSource = ds.Tables[0];
                        PlotDDl.DataTextField = "PlotNumber";
                        PlotDDl.DataValueField = "PlotMasterId";
                        PlotDDl.DataBind();
                        PlotDDl.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        PlotDDl.Items.Clear();
                        PlotDDl.Items.Insert(0, new ListItem("--No Plots Available--", "0"));
                    }

                }
                bindSector(Convert.ToInt32(ddlArea.SelectedValue.Trim()), null);

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void ddlReservationmoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReservationmoney.SelectedValue == "True")
            {
                ReservationMoney.Visible = true;
                //bindTransfercase();
            }
            else
            {
                ReservationMoney.Visible = false;
            }
        }

        protected void ddlLeaseDeedSigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeaseDeedSigned.SelectedValue == "True")
            {
                LeaseDeed.Visible = true;
                //bindTransfercase();
            }
            else
            {
                LeaseDeed.Visible = false;
            }
        }

        protected void PossessionLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPossessionLetter.SelectedValue == "True")
            {
                Possession.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Possession.Visible = false;
            }
        }

        protected void ddlPhysicalPossession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPhysicalPossession.SelectedValue == "True")
            {
                PhysicalPossession.Visible = true;
                //bindTransfercase();
            }
            else
            {
                PhysicalPossession.Visible = false;
            }
        }

        protected void ddlBuildingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuildingPlan.SelectedValue == "True")
            {
                BuildingPlan.Visible = true;
                //bindTransfercase();
            }
            else
            {
                BuildingPlan.Visible = false;
            }
        }

        protected void ddlRestoration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRestoration.SelectedValue == "True")
            {
                Restoration.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Restoration.Visible = false;
            }
        }

        //protected void ddlChangeofPlot_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlChangeofPlot.SelectedValue == "True")
        //    {
        //        ChangeofPlot.Visible = true;
        //        //bindTransfercase();
        //    }
        //    else
        //    {
        //        ChangeofPlot.Visible = false;
        //    }
        //}

        protected void ddlChangeofProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChangeofProject.SelectedValue == "True")
            {
                ChangeofProject.Visible = true;
                //bindTransfercase();
            }
            else
            {
                ChangeofProject.Visible = false;
            }
        }

        protected void ddlAmalgamation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAmalgamation.SelectedValue == "True")
            {
                Amalgamation.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Amalgamation.Visible = false;
            }
        }

        protected void ddlSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubDivision.SelectedValue == "True")
            {
                SubDivision.Visible = true;
                //bindTransfercase();
            }
            else
            {
                SubDivision.Visible = false;
            }
        }

        protected void ddlSubletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubletting.SelectedValue == "True")
            {
                Subletting.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Subletting.Visible = false;
            }
        }

        protected void ddlAgreement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAgreement.SelectedValue == "True")
            {
                Agreement.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Agreement.Visible = false;
            }
        }

        protected void ddlEStamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEStamp.SelectedValue == "True")
            {
                EStamp.Visible = true;
                //bindTransfercase();
            }
            else
            {
                EStamp.Visible = false;
            }
        }

        protected void ddlBankGuarantee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBankGuarantee.SelectedValue == "True")
            {
                BankGuarantee.Visible = true;
                //bindTransfercase();
            }
            else
            {
                BankGuarantee.Visible = false;
            }
        }

        protected void ddlMortgage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMortgage.SelectedValue == "True")
            {
                Mortgage.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Mortgage.Visible = false;
            }
        }

        protected void ddlGisPlotMaster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlInstalment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInstalment.SelectedValue == "False")
            {
                Instalmentpaid.Visible = true;
                //bindTransfercase();
            }
            else
            {
                Instalmentpaid.Visible = false;
            }
        }

        //protected void txtPaymentRecivedAmount_TextChanged(object sender, EventArgs e)
        //{
        //    string DemandID = lblDemandID.Text;
        //    decimal PaymentRecivedAmount = Convert.ToDecimal(txtPaymentRecivedAmount.Text.Trim());
        //    bindPaymentRecivedInHeader(DemandID, PaymentRecivedAmount);
        //}

        protected void ddlinterestWaiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlinterestWaiver.SelectedValue == "True")
            {
                interestWaiver.Visible = true;
                //bindTransfercase();
            }
            else
            {
                interestWaiver.Visible = false;
            }
        }

        protected void ddlincreaseinfar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlincreaseinfar.SelectedValue == "True")
            {
                increaseinfar.Visible = true;
                //bindTransfercase();
            }
            else
            {
                increaseinfar.Visible = false;
            }
        }

        protected void installmentSave_Click(object sender, EventArgs e)
        {
            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
                objServiceTimelinesBEL.installmentStatus = ddlInstalment.SelectedValue.Trim();

                int retVal = objServiceTimelinesBLL.UpdateInstallmentStatus(objServiceTimelinesBEL);
                if (retVal > 0)
                {

                    MessageBox1.ShowSuccess("Installment detail  Successfully");
                    GetAllAllotteeDetailsFilledById(int.Parse(Session["AllotteeID"].ToString()));
                    MultiView1.ActiveViewIndex = 2;

                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Allottee details couldn't be saved');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddltef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltef.SelectedValue == "True")
            {
                DivTEF.Visible = true;
                //bindTransfercase();
            }
            else
            {
                DivTEF.Visible = false;
            }
        }
    }
}



