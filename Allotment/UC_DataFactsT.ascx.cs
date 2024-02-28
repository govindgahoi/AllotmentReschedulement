using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
using System.Drawing;
using System.Globalization;

namespace Allotment
{
    public partial class UC_DataFactsT : System.Web.UI.UserControl
    {
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        string UserName = "";
        string ServiceId = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion

        public string strSender { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            strSender = "NewSystem";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            lblServiceReqNo.Text = ServiceRequestNo;
            string[] Arr = ServiceRequestNo.Split('/');
            ServiceId = Arr[1];
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;



                if (!IsPostBack)
                {

                }

                if (lblServiceReqNo.Text.Length > 0)
                {

                    if (ServiceId == "4")
                    {
                        TransferDiv.Visible = true;

                        GetAllotteeDetail();

                    }

                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }


        public void GetAllotteeDetail()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Transfer_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("GetTransferLetterNew '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];
                DataTable dt7 = ds.Tables[6];


                if (dt0.Rows.Count > 0)
                {

                    txtVerifiedPlot.Text          = dt0.Rows[0]["PlotNo"].ToString();
                    txtPlotSizeVerify.Text        = dt0.Rows[0]["PlotSize"].ToString();
                    txtRateOfPlotVerified.Text    = dt0.Rows[0]["RateofPlot"].ToString();
                    txtInterestRateVerified.Text  = dt0.Rows[0]["InterestRate"].ToString();
                    
                    txtTransferLevyVerified.Text       = dt0.Rows[0]["Transfer_Levy_Percentage"].ToString();
                    txtPremiumVerified.Text            = dt0.Rows[0]["Premium"].ToString();
                    txtIntOnPremiumVerified.Text       = dt0.Rows[0]["IntOnPremium"].ToString();
                    txtMaintenanceChargeVerified.Text  = dt0.Rows[0]["MaintenanceCharge"].ToString();
                    txtIntOnMaintenanceCharge.Text     = dt0.Rows[0]["IntOnMaintenanceCharge"].ToString();
                    txtLeaseRentVerified.Text          = dt0.Rows[0]["LeaseRent"].ToString();
                    txtGSTOnLeaseRentVerified.Text     = dt0.Rows[0]["GSTOnLeaseRent"].ToString();
                    txtTEFVerified.Text                = dt0.Rows[0]["TEF"].ToString();
                    txtIntOnTEFVerified.Text           = dt0.Rows[0]["IntOnTEF"].ToString();
                                 
                    lbblPlotNo.Text                    = dt0.Rows[0]["PlotNo"].ToString();
                    lbblPlotSize.Text                  = dt0.Rows[0]["PlotSize"].ToString();
                    lblRateOfPlot.Text                 = dt0.Rows[0]["RateofPlot"].ToString();
                    lblInterestRate.Text               = dt0.Rows[0]["InterestRate"].ToString();                  
                    lblTransferLevy.Text               = dt0.Rows[0]["Transfer_Levy_Percentage"].ToString();

                    txtAgreementDateVerified.Text = dt0.Rows[0]["AgreementDate"].ToString();
                    txtPossessionDateVerified.Text = dt0.Rows[0]["PossessionDate"].ToString();
                    txtLeaseDeedDateVerified.Text = dt0.Rows[0]["LeaseDeedDate"].ToString();
                    txtLeaseRent1.Text = dt0.Rows[0]["LeaseRent1"].ToString();
                    txtLeaseRent2.Text = dt0.Rows[0]["LeaseRent2"].ToString();
                    txtLeaseRent3.Text = dt0.Rows[0]["LeaseRent3"].ToString();
                    txtTreasuryNameVerified.Text = dt0.Rows[0]["TreasuryName"].ToString();
                    txtAllotmentDateVerified.Text = dt0.Rows[0]["AllotmentDate"].ToString();
                }

                if (dt4.Rows.Count > 0)
                {

                    lbblPlotNo.Text      = dt4.Rows[0]["PlotNo"].ToString();
                    lbblPlotSize.Text    = dt4.Rows[0]["PlotSize"].ToString();
                    lblRateOfPlot.Text   = dt4.Rows[0]["RateofPlot"].ToString();
                    lblInterestRate.Text = dt4.Rows[0]["InterestRate"].ToString();
                    
                    lblTransferLevy.Text = dt4.Rows[0]["Transfer_Levy_Percentage"].ToString();
                }

                if (dt1.Rows.Count > 0)
                {
                    string transfreeName            = dt1.Rows[0]["TransfreeName"].ToString();
                    string transfreeAddress         = dt1.Rows[0]["SignatoryAddress"].ToString();
                    string transferarAddress        = dt1.Rows[0]["TransferorAddress"].ToString();
                    string refno                    = dt1.Rows[0]["ServiceReqNo"].ToString();
                    string IANAme                   = dt1.Rows[0]["IndustrialArea"].ToString();
                    string IssueDate                = dt1.Rows[0]["IssueDate"].ToString();
                    string AppDate                  = dt1.Rows[0]["ApplicationDate"].ToString();
                    string IndustryType             = dt1.Rows[0]["IndustryType"].ToString();
                    string RMName                   = dt1.Rows[0]["RMName"].ToString();
                    string AllotmentLetter          = dt1.Rows[0]["AllotmentletterNo"].ToString();
                    string TransferrorAllotmentDate = dt1.Rows[0]["TransferrorAllotmentDate"].ToString();
                    string FirstAllotmentDate       = dt1.Rows[0]["FirstAllotmentDate"].ToString();
                    string TransferrorLeaseDeedDate = dt1.Rows[0]["TransferrorLeaseDeedDate"].ToString();
                    string TransferorName           = dt1.Rows[0]["TransferorName"].ToString();
                    string FirstInstallmentDate     = dt1.Rows[0]["FirstInstallmentDate"].ToString();
                    lblAllotmentDate.Text           = TransferrorAllotmentDate;
                    lblPossessionDate.Text          = dt1.Rows[0]["PossessionMemodated"].ToString();
                    lblLeaseDeedDate.Text           = dt1.Rows[0]["TransferrorLeaseDeedDate"].ToString();
                    lblAgreementDate.Text           = dt1.Rows[0]["Agreementdated"].ToString();
                    lblLeaseRent1.Text              = dt1.Rows[0]["LeaseRent1"].ToString();
                    lblLeaseRent2.Text              = dt1.Rows[0]["LeaseRent2"].ToString();
                    lblLeaseRent3.Text              = dt1.Rows[0]["LeaseRent3"].ToString();
                    lblTreasuryName.Text            = dt1.Rows[0]["Treasuryname"].ToString();


                    if (dt2.Rows.Count > 0)
                    {
                        string RegionalOffice = dt2.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt2.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt2.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone    = dt2.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId  = dt2.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }

                    if(dt5.Rows.Count>0)
                    {
                        lblPremium.Text = dt5.Rows[0]["PreviousInstallmentDue"].ToString();
                        lblIntOnPremium.Text = dt5.Rows[0]["IntOnPremium"].ToString();
                        lblMaintenanceCharge.Text = dt5.Rows[0]["MaintenanceCharge"].ToString();
                        lblIntOnMaintenanceCharge.Text = dt5.Rows[0]["IntOnMaintenanceCharge"].ToString();
                        lblLeaseRent.Text = dt5.Rows[0]["LeaseRent"].ToString();
                        lblGSTOnLeaseRent.Text = dt5.Rows[0]["GSTLeaseRent"].ToString();
                        lblTEF.Text = dt5.Rows[0]["TEF"].ToString();
                        lblIntOnTEF.Text = dt5.Rows[0]["IntTef"].ToString();
                    }

                    htmlContent = htmlContent.Replace("{{FirstInstallmentDate}}", FirstInstallmentDate);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{lblTransfereename}}", transfreeName);
                    htmlContent = htmlContent.Replace("{{lblTransferorname}}", TransferorName);
                    htmlContent = htmlContent.Replace("{{lblTransfereeAddress}}", transfreeAddress);

                    htmlContent = htmlContent.Replace("{{lblTransferarAddress}}", transferarAddress);
                    htmlContent = htmlContent.Replace("{{lblRefno}}", refno);
                    htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                    htmlContent = htmlContent.Replace("{{lblDocumentIssueDate}}", IssueDate);
                    htmlContent = htmlContent.Replace("{{lblRefDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                    htmlContent = htmlContent.Replace("{{lblIndustryType}}", IndustryType);
                    htmlContent = htmlContent.Replace("{{lblRMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{lblallotmentletterno}}", AllotmentLetter);
                    htmlContent = htmlContent.Replace("{{lbl_existing_allotment_transfer_dated}}", TransferrorAllotmentDate);
                    htmlContent = htmlContent.Replace("{{lbl_first_allotment_dated}}", FirstAllotmentDate);
                    htmlContent = htmlContent.Replace("{{lbl_Agreement_dated}}", lblAgreementDate.Text);
                    htmlContent = htmlContent.Replace("{{lbl_Possession_Memo_dated}}", lblPossessionDate.Text);
                    htmlContent = htmlContent.Replace("{{lbl_Lease_Deed_dated}}", TransferrorLeaseDeedDate);


                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|Transfree:" + transfreeName + "|IAName:" + IANAme + "|PlotNo:" + txtVerifiedPlot.Text + "|DocType:PlotTransfer";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            htmlContent = htmlContent.Replace("{{QRC}}", "data:image/png;base64," + Convert.ToBase64String(byteImage));
                        }
                    }
                }

                if (dt7.Rows.Count >= 0)
                {

                    if (ViewState["temp_annexre_details"] == null || ViewState["temp_annexre_details"].Equals(""))
                    {
                        DataTable temp_clause_details = new DataTable();
                        temp_clause_details.TableName = "temp_annexre_details";
                        temp_clause_details.Columns.Add(new DataColumn("Annexures", typeof(string)));
                        ViewState["temp_annexre_details"] = temp_clause_details;

                        ViewState["temp_annexre_details"] = dt7;
                        temp_bpannexre_details_DataBind();
                    }

                }
                if (dt7.Rows.Count > 0)
                {

                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);
                    string html = @"

<style>
.request-table tr{
    font-size: 12px;
    color: #2d2d2d;
    border: 1px solid #fff !important;
    text-align: left;
    font-weight:600;
    background: #e0e0e0;
    padding: 1px 6px !important;
}

.request-table tr th {
    font-size: 12px;
    background-color: #ffe600;
}

.request-table tr td a {
    color: #337ab7;
    font-weight: bold;
}
</style>
<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th width='10%'> S.NO </th><th> List Of Additional Clauses </th></tr>";
                    int i = 0;
                    foreach (DataRow dr in dt7.Rows)
                    {
                        i++;
                        html += "<tr><td> " + i.ToString() + " </td><td> " + dr["Annexures"].ToString() + " </ td></tr> ";
                    }
                    html += "</table>";

                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", html);
                }
                else
                {
                    htmlContent = htmlContent.Replace("{{ListofAnnexresBP}}", "");
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Preview_Litral.Text = htmlContent;

        }


        protected void ddlVerifyTransferLevy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyTransferLevy.SelectedValue.Trim() == "Yes")
            {

                txtTransferLevyVerified.Enabled = false;
                txtTransferLevyVerified.Text = lblTransferLevy.Text;
                I29.Visible = true;
                I19.Visible = false;
            }
            else if (ddlVerifyTransferLevy.SelectedValue.Trim() == "No")
            {

                txtTransferLevyVerified.Enabled = true;
                txtTransferLevyVerified.Text = "";
                I19.Visible = true;
                I29.Visible = false;

            }

        }


        protected void ddlVerifyNoOfInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyNoOfInstallment.SelectedValue.Trim() == "Yes")
            {
                txtTreasuryNameVerified.Enabled = false;
                txtTreasuryNameVerified.Text = lblTreasuryName.Text;
                I28.Visible = true;
                I18.Visible = false;
            }
            else if (ddlVerifyNoOfInstallment.SelectedValue.Trim() == "No")
            {
                txtTreasuryNameVerified.Enabled = true;
                txtTreasuryNameVerified.Text = "";
                I18.Visible = true;
                I28.Visible = false;
            }
            else
            {

            }
        }

        protected void ddlVerifyLocationCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyLocationCharge.SelectedValue.Trim() == "Yes")
            {
                txtPossessionDateVerified.Enabled = false;
                txtPossessionDateVerified.Text = lblPossessionDate.Text;
                I26.Visible = true;
                I16.Visible = false;
            }
            else if (ddlVerifyLocationCharge.SelectedValue.Trim() == "No")
            {
                txtPossessionDateVerified.Enabled = true;
                txtPossessionDateVerified.Text = "";
                I16.Visible = true;
                I26.Visible = false;
            }
            else
            {

            }
        }


        protected void ddlVerifyReservationMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyReservationMoney.SelectedValue.Trim() == "Yes")
            {
                txtAgreementDateVerified.Enabled = false;
                txtAgreementDateVerified.Text = lblAgreementDate.Text;
                I25.Visible = true;
                I15.Visible = false;
            }
            else if (ddlVerifyReservationMoney.SelectedValue.Trim() == "No")
            {
                txtAgreementDateVerified.Enabled = true;
                txtAgreementDateVerified.Text = "";
                I15.Visible = true;
                I25.Visible = false;
            }
            else
            {

            }
        }



        protected void ddlVeriFyEmdRates_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlVeriFyEmdRates.SelectedValue.Trim() == "Yes")
            {
                txtAllotmentDateVerified.Enabled = false;
                txtAllotmentDateVerified.Text = lblAllotmentDate.Text;
                I24.Visible = true;
                I14.Visible = false;

            }
            else if (ddlVeriFyEmdRates.SelectedValue.Trim() == "No")
            {
                txtAllotmentDateVerified.Enabled = true;
                txtAllotmentDateVerified.Text = "";
                I14.Visible = true;
                I24.Visible = false;
            }
            else
            {

            }
        }


        protected void ddlVerifyInterestRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyInterestRate.SelectedValue.Trim() == "Yes")
            {
                txtInterestRateVerified.Enabled = false;
                txtInterestRateVerified.Text = lblInterestRate.Text;
                I23.Visible = true;
                I13.Visible = false;
            }
            else if (ddlVerifyInterestRate.SelectedValue.Trim() == "No")
            {
                txtInterestRateVerified.Enabled = true;
                txtInterestRateVerified.Text = "";
                I13.Visible = true;
                I23.Visible = false;
            }
            else
            {


            }
        }


        protected void ddlVerifyRateOfPlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyRateOfPlot.SelectedValue.Trim() == "Yes")
            {
                txtRateOfPlotVerified.Enabled = false;
                txtRateOfPlotVerified.Text = lblRateOfPlot.Text;
                I22.Visible = true;
                I12.Visible = false;
            }
            else if (ddlVerifyRateOfPlot.SelectedValue.Trim() == "No")
            {
                txtRateOfPlotVerified.Enabled = true;
                txtRateOfPlotVerified.Text = "";
                I12.Visible = true;
                I22.Visible = false;
            }
            else
            {


            }
        }


        protected void ddlVerifyPlotSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyPlotSize.SelectedValue.Trim() == "Yes")
            {
                txtPlotSizeVerify.Enabled = false;
                txtPlotSizeVerify.Text = lbblPlotSize.Text;
                I21.Visible = true;
                I11.Visible = false;
            }
            else if (ddlVerifyPlotSize.SelectedValue.Trim() == "No")
            {
                txtPlotSizeVerify.Enabled = true;
                txtPlotSizeVerify.Text = "";
                I11.Visible = true;
                I21.Visible = false;
            }
            else
            {

            }
        }


        protected void ddlVerifyPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerifyPlotNo.SelectedValue.Trim() == "Yes")
            {
                txtVerifiedPlot.Text = lbblPlotNo.Text;
                txtVerifiedPlot.Enabled = false;
                I2.Visible = true;
                I1.Visible = false;
            }
            else if (ddlVerifyPlotNo.SelectedValue.Trim() == "No")
            {
                txtVerifiedPlot.Enabled = true;
                txtVerifiedPlot.Text = "";
                I1.Visible = true;
                I2.Visible = false;
            }
            else
            {

            }
        }

        protected void ddlRebateVerify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRebateVerify.SelectedValue.Trim() == "Yes")
            {
                txtLeaseDeedDateVerified.Text = lblLeaseDeedDate.Text;
                txtLeaseDeedDateVerified.Enabled = false;
                I27.Visible = true;
                I17.Visible = false;

            }
            else if (ddlRebateVerify.SelectedValue.Trim() == "No")
            {
                txtLeaseDeedDateVerified.Text = "";
                txtLeaseDeedDateVerified.Enabled = true;
                I27.Visible = false;
                I17.Visible = true;

            }
            else
            {

            }
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


        public void temp_bpannexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                BPClauseGrid.DataSource = dt;
                BPClauseGrid.DataBind();
                BPClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                BPClauseGrid.DataSource = dt;
                BPClauseGrid.DataBind();
            }
            GetAllotteeDetail();
        }
        protected void btnSaveBpClause_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (BPClauseGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


            if (Clause == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Annexures"] = Clause;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["temp_annexre_details"] = dt;
                temp_bpannexre_details_DataBind();
            }
        }

        protected void BPClauseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_bpannexre_details_DataBind();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
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
                string LevyType = "";

                


                if (Validate2())
                {


                    if (ValidateDate(txtLeaseDeedDateVerified.Text))
                    {

                    }
                    else
                    {
                        txtLeaseDeedDateVerified.Focus();
                        string message = "Invalid Date format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                    //if (ValidateDate(txtAgreementDateVerified.Text))
                    //{

                    //}
                    //else
                    //{
                    //    txtAgreementDateVerified.Focus();
                    //    string message = "Invalid Date format";
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    //    return;
                    //}

                    if (ValidateDate(txtPossessionDateVerified.Text))
                    {

                    }
                    else
                    {
                        txtPossessionDateVerified.Focus();
                        string message = "Invalid Date format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                    if (ValidateDate(txtAllotmentDateVerified.Text))
                    {

                    }
                    else
                    {
                        txtAllotmentDateVerified.Focus();
                        string message = "Invalid Date format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                    command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantDataForTransfer]", con, transaction); 
                  
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                    command.Parameters.AddWithValue("@PlotNo",       txtVerifiedPlot.Text);
                    command.Parameters.AddWithValue("@PlotSize",     txtPlotSizeVerify.Text);
                    command.Parameters.AddWithValue("@RateofPlot",   txtRateOfPlotVerified.Text);
                    command.Parameters.AddWithValue("@InterestRate", txtInterestRateVerified.Text);                   
                    command.Parameters.AddWithValue("@TransferLevyPercentage", txtTransferLevyVerified.Text);                 
                    command.Parameters.AddWithValue("@Premium",                txtPremiumVerified.Text);
                    command.Parameters.AddWithValue("@IntOnPremium",           txtIntOnPremiumVerified.Text);
                    command.Parameters.AddWithValue("@MaintenanceCharge", txtMaintenanceChargeVerified.Text);
                    command.Parameters.AddWithValue("@IntOnMaintenanceCharge", txtIntOnMaintenanceCharge.Text);
                    command.Parameters.AddWithValue("@LeaseRent", txtLeaseRentVerified.Text);
                    command.Parameters.AddWithValue("@GSTOnLeaseRent", txtGSTOnLeaseRentVerified.Text);
                    command.Parameters.AddWithValue("@TEF", txtTEFVerified.Text);
                    command.Parameters.AddWithValue("@IntOnTEF", txtIntOnTEFVerified.Text);
                    command.Parameters.AddWithValue("@LeaseRent1", txtLeaseRent1.Text);
                    command.Parameters.AddWithValue("@LeaseRent2", txtLeaseRent2.Text);
                    command.Parameters.AddWithValue("@LeaseRent3", txtLeaseRent3.Text);
                    command.Parameters.AddWithValue("@AllotmentDate", DateTime.ParseExact(txtAllotmentDateVerified.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@LeaseDeedDate", DateTime.ParseExact(txtLeaseDeedDateVerified.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@AgreementDate", txtAgreementDateVerified.Text);
                    command.Parameters.AddWithValue("@PossessionDate", DateTime.ParseExact(txtPossessionDateVerified.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@TreasuryName", txtTreasuryNameVerified.Text);



                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));


                    DataTable Annexures = (DataTable)ViewState["temp_annexre_details"];
                    command = new SqlCommand(@"sp_ClearAnnexures '" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));
                    if (Annexures.Rows.Count > 0)
                    {

                        foreach (DataRow dr2 in Annexures.Rows)
                        {
                            string Clause = dr2["Annexures"].ToString();
                            command = new SqlCommand(@"[Sp_AnnexuresInsert]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Clause", Clause);

                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }

                    }
                }
                else
                {
                    string message = "Please Verify All Data";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;

                }


                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Data Facts Captured Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }
                else
                {
                    transaction.Rollback();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

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
      

        #region selection
        protected void txtVerifiedPlot_TextChanged(object sender, EventArgs e)
        {
            if (txtVerifiedPlot.Text.Length <= 0)
            {
                I2.Visible = false;
                I1.Visible = true;
            }
            else
            {
                I2.Visible = true;
                I1.Visible = false;
            }
        }

        protected void txtPlotSizeVerify_TextChanged(object sender, EventArgs e)
        {
            if (txtPlotSizeVerify.Text.Length <= 0)
            {
                I21.Visible = false;
                I11.Visible = true;
            }
            else
            {
                I21.Visible = true;
                I11.Visible = false;
            }
        }

        protected void txtRateOfPlotVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtRateOfPlotVerified.Text.Length <= 0)
            {
                I22.Visible = false;
                I12.Visible = true;
            }
            else
            {
                I22.Visible = true;
                I12.Visible = false;
            }
        }

        protected void txtInterestRateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtInterestRateVerified.Text.Length <= 0)
            {
                I23.Visible = false;
                I13.Visible = true;
            }
            else
            {
                I23.Visible = true;
                I13.Visible = false;
            }
        }

        protected void txtRegistrationMoneyRateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtAgreementDateVerified.Text.Length <= 0)
            {
                I25.Visible = false;
                I15.Visible = true;
            }
            else
            {
                I25.Visible = true;
                I15.Visible = false;
            }
        }

        protected void txtLocationChargeVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtPossessionDateVerified.Text.Length <= 0)
            {
                I26.Visible = false;
                I16.Visible = true;
            }
            else
            {
                I26.Visible = true;
                I16.Visible = false;
            }
        }

        protected void txtRebateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseDeedDateVerified.Text.Length <= 0)
            {
                I27.Visible = false;
                I17.Visible = true;
            }
            else
            {
                I27.Visible = true;
                I17.Visible = false;
            }
        }

        protected void txtTransferLevyVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtTransferLevyVerified.Text.Length <= 0)
            {
                I29.Visible = false;
                I19.Visible = true;
            }
            else
            {
                I29.Visible = true;
                I19.Visible = false;
            }
        }

        protected void txtEMDRateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtAllotmentDateVerified.Text.Length <= 0)
            {
                I24.Visible = false;
                I14.Visible = true;
            }
            else
            {
                I24.Visible = true;
                I14.Visible = false;
            }
        }

        protected void txtNoOfInstallmentVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtTreasuryNameVerified.Text.Length <= 0)
            {
                I28.Visible = false;
                I18.Visible = true;
            }
            else
            {
                I28.Visible = true;
                I18.Visible = false;
            }
        }

        public bool Validate2()
        {
            try
            {
                bool remark = true;


                if (txtVerifiedPlot.Text.Length <= 0)
                {
                    txtVerifiedPlot.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtVerifiedPlot.Style.Clear();

                }
                if (txtPlotSizeVerify.Text.Length <= 0)
                {
                    txtPlotSizeVerify.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtPlotSizeVerify.Style.Clear();

                }
                if (txtRateOfPlotVerified.Text.Length <= 0)
                {
                    txtRateOfPlotVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtRateOfPlotVerified.Style.Clear();

                }
                if (txtInterestRateVerified.Text.Length <= 0)
                {
                    txtInterestRateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtInterestRateVerified.Style.Clear();

                }
             
                if (txtTransferLevyVerified.Text.Length <= 0)
                {
                    txtTransferLevyVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtTransferLevyVerified.Style.Clear();

                }
                if (txtAllotmentDateVerified.Text.Length <= 0)
                {
                    txtAllotmentDateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtAllotmentDateVerified.Style.Clear();

                }
                if (txtAgreementDateVerified.Text.Length <= 0)
                {
                    txtAgreementDateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtAgreementDateVerified.Style.Clear();

                }
                if (txtPossessionDateVerified.Text.Length <= 0)
                {
                    txtPossessionDateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtPossessionDateVerified.Style.Clear();

                }
                if (txtLeaseDeedDateVerified.Text.Length <= 0)
                {
                    txtLeaseDeedDateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseDeedDateVerified.Style.Clear();

                }
                if (txtTreasuryNameVerified.Text.Length <= 0)
                {
                    txtTreasuryNameVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtTreasuryNameVerified.Style.Clear();

                }

                if (txtLeaseRent1.Text.Length <= 0)
                {
                    txtLeaseRent1.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseRent1.Style.Clear();

                }

                if (txtLeaseRent2.Text.Length <= 0)
                {
                    txtLeaseRent2.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseRent2.Style.Clear();

                }
                if (txtLeaseRent3.Text.Length <= 0)
                {
                    txtLeaseRent3.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseRent3.Style.Clear();

                }
                if (txtLeaseRent3.Text.Length <= 0)
                {
                    txtLeaseRent3.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseRent3.Style.Clear();

                }
                if (txtPremiumVerified.Text.Length <= 0)
                {
                    txtPremiumVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtPremiumVerified.Style.Clear();

                }

                if (txtIntOnPremiumVerified.Text.Length <= 0)
                {
                    txtIntOnPremiumVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtIntOnPremiumVerified.Style.Clear();

                }

                if (txtMaintenanceChargeVerified.Text.Length <= 0)
                {
                    txtMaintenanceChargeVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtMaintenanceChargeVerified.Style.Clear();

                }
                if (txtIntOnMaintenanceCharge.Text.Length <= 0)
                {
                    txtIntOnMaintenanceCharge.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtIntOnMaintenanceCharge.Style.Clear();

                }

                if (txtLeaseRentVerified.Text.Length <= 0)
                {
                    txtLeaseRentVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLeaseRentVerified.Style.Clear();

                }

                if (txtGSTOnLeaseRentVerified.Text.Length <= 0)
                {
                    txtGSTOnLeaseRentVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtGSTOnLeaseRentVerified.Style.Clear();

                }
                if (txtTEFVerified.Text.Length <= 0)
                {
                    txtTEFVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtTEFVerified.Style.Clear();

                }

                if (txtIntOnTEFVerified.Text.Length <= 0)
                {
                    txtIntOnTEFVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtIntOnTEFVerified.Style.Clear();

                }



                if (remark == false)
                {


                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }

   
        protected void ddlPremium_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPremium.SelectedValue.Trim() == "Yes")
            {
                txtPremiumVerified.Text = lblPremium.Text;
                txtPremiumVerified.Enabled = false;
                I48.Visible = true;
                I47.Visible = false;

            }
            else if (ddlPremium.SelectedValue.Trim() == "No")
            {
                txtPremiumVerified.Text = "";
                txtPremiumVerified.Enabled = true;
                I48.Visible = false;
                I47.Visible = true;

            }
            else
            {

            }
        }

        protected void txtPremiumVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtTreasuryNameVerified.Text.Length <= 0)
            {
                I48.Visible = false;
                I47.Visible = true;
            }
            else
            {
                I47.Visible = false;
                I48.Visible = true;
            }
        }

        protected void ddlIntOnPremium_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIntOnPremium.SelectedValue.Trim() == "Yes")
            {
                txtIntOnPremiumVerified.Text = lblIntOnPremium.Text;
                txtIntOnPremiumVerified.Enabled = false;
                I50.Visible = true;
                I49.Visible = false;

            }
            else if (ddlIntOnPremium.SelectedValue.Trim() == "No")
            {
                txtIntOnPremiumVerified.Text = "";
                txtIntOnPremiumVerified.Enabled = true;
                I50.Visible = false;
                I49.Visible = true;

            }
            else
            {

            }
        }

        protected void txtIntOnPremiumVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtIntOnPremiumVerified.Text.Length <= 0)
            {
                I50.Visible = false;
                I49.Visible = true;
            }
            else
            {
                I50.Visible = true;
                I49.Visible = false;
            }
        }

        protected void ddlMaintenanceCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaintenanceCharge.SelectedValue.Trim() == "Yes")
            {
                txtMaintenanceChargeVerified.Text = lblMaintenanceCharge.Text;
                txtMaintenanceChargeVerified.Enabled = false;
                I52.Visible = true;
                I51.Visible = false;

            }
            else if (ddlMaintenanceCharge.SelectedValue.Trim() == "No")
            {
                txtMaintenanceChargeVerified.Text = "";
                txtMaintenanceChargeVerified.Enabled = true;
                I51.Visible = true;
                I52.Visible = false;

            }
            else
            {

            }
        }

        protected void txtMaintenanceChargeVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtMaintenanceChargeVerified.Text.Length <= 0)
            {
                I51.Visible = true;
                I52.Visible = false;
            }
            else
            {
                I52.Visible = true;
                I51.Visible = false;
            }
        }

        protected void ddlIntOnMaintenanceCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIntOnMaintenanceCharge.SelectedValue.Trim() == "Yes")
            {
                txtIntOnMaintenanceCharge.Text = lblIntOnMaintenanceCharge.Text;
                txtIntOnMaintenanceCharge.Enabled = false;
                I54.Visible = true;
                I53.Visible = false;

            }
            else if (ddlIntOnMaintenanceCharge.SelectedValue.Trim() == "No")
            {
                txtIntOnMaintenanceCharge.Text = "";
                txtIntOnMaintenanceCharge.Enabled = true;
                I53.Visible = false;
                I54.Visible = true;

            }
            else
            {

            }

        }

        protected void txtIntOnMaintenanceCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtMaintenanceChargeVerified.Text.Length <= 0)
            {
                I53.Visible = false;
                I54.Visible = true;
            }
            else
            {
                I54.Visible = true;
                I53.Visible = false;
            }
        }

        protected void ddlLeaseRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeaseRent.SelectedValue.Trim() == "Yes")
            {
                txtLeaseRentVerified.Text = lblLeaseRent.Text;
                txtLeaseRentVerified.Enabled = false;
                I41.Visible = false;
                I42.Visible = true;

            }
            else if (ddlLeaseRent.SelectedValue.Trim() == "No")
            {
                txtLeaseRentVerified.Text = "";
                txtLeaseRentVerified.Enabled = true;
                I41.Visible = true;
                I42.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLeaseRentVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseRentVerified.Text.Length <= 0)
            {
                I41.Visible = true;
                I42.Visible = false;
            }
            else
            {
                I41.Visible = false;
                I42.Visible = true;
            }
        }

        protected void ddlGSTOnLease_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGSTOnLease.SelectedValue.Trim() == "Yes")
            {
                txtGSTOnLeaseRentVerified.Text = lblIntOnPremium.Text;
                txtGSTOnLeaseRentVerified.Enabled = false;
                I43.Visible = false;
                I44.Visible = true;

            }
            else if (ddlGSTOnLease.SelectedValue.Trim() == "No")
            {
                txtGSTOnLeaseRentVerified.Text = "";
                txtGSTOnLeaseRentVerified.Enabled = true;
                I43.Visible = true;
                I44.Visible = false;

            }
            else
            {

            }
        }

        protected void txtGSTOnLeaseRentVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseRentVerified.Text.Length <= 0)
            {
                I43.Visible = true;
                I44.Visible = false;
            }
            else
            {
                I43.Visible = false;
                I44.Visible = true;
            }
        }

        protected void ddlTEF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTEF.SelectedValue.Trim() == "Yes")
            {
                txtTEFVerified.Text = lblTEF.Text;
                txtTEFVerified.Enabled = false;
                I45.Visible = false;
                I46.Visible = true;

            }
            else if (ddlTEF.SelectedValue.Trim() == "No")
            {
                txtTEFVerified.Text = "";
                txtTEFVerified.Enabled = true;
                I45.Visible = true;
                I46.Visible = false;

            }
            else
            {

            }

        }

        protected void txtTEFVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtTEFVerified.Text.Length <= 0)
            {
                I45.Visible = true;
                I46.Visible = false;
            }
            else
            {
                I45.Visible = false;
                I46.Visible = true;
            }
        }

        protected void ddlIntOnTEF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIntOnTEF.SelectedValue.Trim() == "Yes")
            {
                txtIntOnTEFVerified.Text = lblTEF.Text;
                txtIntOnTEFVerified.Enabled = false;
                I55.Visible = false;
                I56.Visible = true;

            }
            else if (ddlIntOnTEF.SelectedValue.Trim() == "No")
            {
                txtIntOnTEFVerified.Text = "";
                txtIntOnTEFVerified.Enabled = true;
                I55.Visible = true;
                I56.Visible = false;

            }
            else
            {

            }
        }

        protected void txtIntOnTEFVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtIntOnTEFVerified.Text.Length <= 0)
            {
                I55.Visible = true;
                I56.Visible = false;
            }
            else
            {
                I55.Visible = false;
                I56.Visible = true;
            }
        }

    
     


        protected void ddlLeaseRent1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeaseRent1.SelectedValue.Trim() == "Yes")
            {
                txtLeaseRent1.Text = lblLeaseRent1.Text;
                txtLeaseRent1.Enabled = false;
                IDis25.Visible = false;
                IApp25.Visible = true;

            }
            else if (ddlLeaseRent1.SelectedValue.Trim() == "No")
            {
                txtLeaseRent1.Text = "";
                txtLeaseRent1.Enabled = true;
                IDis25.Visible = true;
                IApp25.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLeaseRent1_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseRent1.Text.Length <= 0)
            {
                IDis25.Visible = true;
                IApp25.Visible = false;
            }
            else
            {
                IDis25.Visible = false;
                IApp25.Visible = true;
            }
        }

        protected void ddlLeaseRent2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeaseRent2.SelectedValue.Trim() == "Yes")
            {
                txtLeaseRent2.Text = lblLeaseRent2.Text;
                txtLeaseRent2.Enabled = false;
                IDis26.Visible = false;
                IApp26.Visible = true;

            }
            else if (ddlLeaseRent2.SelectedValue.Trim() == "No")
            {
                txtLeaseRent2.Text = "";
                txtLeaseRent2.Enabled = true;
                IDis26.Visible = true;
                IApp26.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLeaseRent2_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseRent2.Text.Length <= 0)
            {
                IDis26.Visible = true;
                IApp26.Visible = false;
            }
            else
            {
                IDis26.Visible = false;
                IApp26.Visible = true;
            }
        }

        protected void ddlLeaseRent3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeaseRent3.SelectedValue.Trim() == "Yes")
            {
                txtLeaseRent3.Text = lblLeaseRent3.Text;
                txtLeaseRent3.Enabled = false;
                IDis27.Visible = false;
                IApp27.Visible = true;

            }
            else if (ddlLeaseRent3.SelectedValue.Trim() == "No")
            {
                txtLeaseRent3.Text = "";
                txtLeaseRent3.Enabled = true;
                IDis27.Visible = true;
                IApp27.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLeaseRent3_TextChanged(object sender, EventArgs e)
        {
            if (txtLeaseRent3.Text.Length <= 0)
            {
                IDis27.Visible = true;
                IApp27.Visible = false;
            }
            else
            {
                IDis27.Visible = false;
                IApp27.Visible = true;
            }
        }



        #endregion











    }


}