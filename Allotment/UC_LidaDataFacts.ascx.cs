using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QRCoder;
namespace Allotment
{
    public partial class UC_LidaDataFacts : System.Web.UI.UserControl
    {
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        string UserName = "";
        string ServiceId = "";
        string buildingType = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion

        public string strSender { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            strSender = "NewSystem";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            lblServiceReqNo.Text = ServiceRequestNo;
            string[] Arr = ServiceRequestNo.Split('/');
            ServiceId = Arr[1];
            buildingType = Arr[2];
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
                if (ServiceId == "3001" || ServiceId == "4002" || ServiceId == "5003")
                {
                    TransferDiv.Visible = false;
                    AllotmentDiv.Visible = false;
                    BuildingDiv.Visible = true;
                    if (buildingType == "1")
                    {
                        GetAllotteeDetailForBuilding();
                    }
                    else if (buildingType == "2")
                    {
                        GetAllotteeDetailForNonApprovedBuilding();
                    }

                }
                else if (ServiceId == "1001")
                {
                    TransferDiv.Visible = false;
                    AllotmentDiv.Visible = false;
                    BuildingDiv.Visible = false;
                    CancelDiv.Visible = true;
                    GetPlotCancelDetails();
                }
            }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }

        public void GetAllotteeDetailForNonApprovedBuilding()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/LidaBuilding_PlanNotApproved_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForLidaBuildingPlanLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString(); // For temp
                    string BlockNo = dt0.Rows[0]["block_no"].ToString();
                    string PlotArea = dt0.Rows[0]["plot_no"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string project_name = dt0.Rows[0]["project_name"].ToString();
                    string POName = dt0.Rows[0]["POName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{BlockNo}}", BlockNo);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{project_name}}", project_name);
                    htmlContent = htmlContent.Replace("{{POName}}", POName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|Project Name:" + project_name + "|DocType:BuildingPlan";
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

            Literal2.Text = htmlContent;

        }
        public void GetAllotteeDetail()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Transfer_Letter_T.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("GetTransferLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];
                DataTable dt6 = ds.Tables[6];


                if (dt3.Rows.Count > 0)
                {
                    txtVerifiedPlot.Text = dt3.Rows[0]["PlotNo"].ToString();
                    txtPlotSizeVerify.Text = dt3.Rows[0]["PlotSize"].ToString();
                    txtRateOfPlotVerified.Text = dt3.Rows[0]["RateofPlot"].ToString();
                    txtInterestRateVerified.Text = dt3.Rows[0]["InterestRate"].ToString();
                    txtEMDRateVerified.Text = dt3.Rows[0]["EMDRate"].ToString();
                    txtRegistrationMoneyRateVerified.Text = dt3.Rows[0]["RegistrationMoneyRate"].ToString();
                    txtRebateVerified.Text = dt3.Rows[0]["Rebate"].ToString();

                    txtLocationChargeVerified.Text = dt3.Rows[0]["LocationChage"].ToString();

                    txtNoOfInstallmentVerified.Text = dt3.Rows[0]["NoofInstallments"].ToString();
                    txtTransferLevyVerified.Text = dt3.Rows[0]["Transfer_Levy_Percentage"].ToString();
                    txtPremiumVerified.Text = dt3.Rows[0]["Premium"].ToString();
                    txtIntOnPremiumVerified.Text = dt3.Rows[0]["IntOnPremium"].ToString();
                    txtMaintenanceChargeVerified.Text = dt3.Rows[0]["MaintenanceCharge"].ToString();
                    txtIntOnMaintenanceCharge.Text = dt3.Rows[0]["IntOnMaintenanceCharge"].ToString();
                    txtLeaseRentVerified.Text = dt3.Rows[0]["LeaseRent"].ToString();
                    txtGSTOnLeaseRentVerified.Text = dt3.Rows[0]["GSTOnLeaseRent"].ToString();
                    txtTEFVerified.Text = dt3.Rows[0]["TEF"].ToString();
                    txtIntOnTEFVerified.Text = dt3.Rows[0]["IntOnTEF"].ToString();
                    txtLeasePeriodVerified.Text = dt3.Rows[0]["LeasePeriod"].ToString();
                    string LevyType = dt3.Rows[0]["LeavyType"].ToString();
                    if (LevyType == "LumpSum")
                    {
                        LumpSumRad.Checked = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowLumpSum();", true);
                    }
                    else if (LevyType == "Installment")
                    {
                        InstallmentRad.Checked = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowInstallment();", true);
                    }

                }
                if (dt0.Rows.Count > 0)
                {
                    lbblPlotNo.Text = dt0.Rows[0]["PlotNo"].ToString();
                    lbblPlotSize.Text = dt0.Rows[0]["PlotSize"].ToString();
                    lblRateOfPlot.Text = dt0.Rows[0]["RateofPlot"].ToString();
                    lblInterestRate.Text = dt0.Rows[0]["InterestRate"].ToString();
                    lblEMDRates.Text = dt0.Rows[0]["EMDRate"].ToString();
                    lblRegistrationMoneyRate.Text = dt0.Rows[0]["RegistrationMoneyRate"].ToString();
                    lblRebate.Text = dt0.Rows[0]["Rebate"].ToString();
                    lblLocationCharge.Text = dt0.Rows[0]["LocationChage"].ToString();
                    lblNoOfInstallments.Text = dt0.Rows[0]["NoofInstallments"].ToString();
                    lblTransferLevy.Text = dt0.Rows[0]["Transfer_Levy_Percentage"].ToString();
                }


                if (dt5.Rows.Count > 0)
                {
                    string transfreeName = dt5.Rows[0]["TransfreeName"].ToString();
                    string transfreeAddress = dt5.Rows[0]["SignatoryAddress"].ToString();
                    string refno = dt5.Rows[0]["ServiceReqNo"].ToString();
                    string IANAme = dt5.Rows[0]["IndustrialArea"].ToString();
                    string IssueDate = dt5.Rows[0]["IssueDate"].ToString();
                    string AppDate = dt5.Rows[0]["ApplicationDate"].ToString();
                    string IndustryType = dt5.Rows[0]["IndustryType"].ToString();
                    string RMName = dt5.Rows[0]["RMName"].ToString();
                    string AllotmentLetter = dt5.Rows[0]["AllotmentletterNo"].ToString();
                    string TransferrorAllotmentDate = dt5.Rows[0]["TransferrorAllotmentDate"].ToString();
                    string TransferrorLeaseDeedDate = dt5.Rows[0]["TransferrorLeaseDeedDate"].ToString();
                    string TransferorName = dt5.Rows[0]["TransferorName"].ToString();
                    string FirstInstallmentDate = dt5.Rows[0]["FirstInstallmentDate"].ToString();

                    if (dt6.Rows.Count > 0)
                    {
                        string RegionalOffice = dt6.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt6.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt6.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt6.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt6.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }

                    htmlContent = htmlContent.Replace("{{FirstInstallmentDate}}", FirstInstallmentDate);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{Transfreename}}", transfreeName);
                    htmlContent = htmlContent.Replace("{{lblTransferorname}}", TransferorName);
                    htmlContent = htmlContent.Replace("{{lblTransfereeAddress}}", transfreeAddress);
                    htmlContent = htmlContent.Replace("{{lblRefno}}", refno);
                    htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                    htmlContent = htmlContent.Replace("{{lblDocumentIssueDate}}", IssueDate);
                    htmlContent = htmlContent.Replace("{{lblRefDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{lblIAName}}", IANAme);
                    htmlContent = htmlContent.Replace("{{lblIndustryType}}", IndustryType);
                    htmlContent = htmlContent.Replace("{{lblRMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{lblallotmentletterno}}", AllotmentLetter);
                    htmlContent = htmlContent.Replace("{{lbl_existing_allotment_transfer_dated}}", TransferrorAllotmentDate);

                    htmlContent = htmlContent.Replace("{{lbl_Lease_Deed_dated}}", TransferrorLeaseDeedDate);


                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|Transfree:" + transfreeName + "|IAName:" + IANAme + "|PlotNo:" + lblPlotNo.Text + "|DocType:PlotTransfer";
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
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Preview_Litral.Text = htmlContent;

        }


        public void GetAllotteeDetailForAllotment()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Allotment_Letter_View.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand();
                if (strSender == "NewSystem")
                { cmd = new SqlCommand("GetAllotmentLetterNew'" + lblServiceReqNo.Text + "'", con); }
                else { cmd = new SqlCommand("GetAllotmentLetter'" + lblServiceReqNo.Text + "'", con); }


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt4 = ds.Tables[4];
                DataTable dt3 = ds.Tables[3];
                DataTable dt5 = ds.Tables[5];
                DataTable dt6 = ds.Tables[6];
                DataTable dt7 = ds.Tables[7];


                if (dt3.Rows.Count > 0)
                {
                    DataTable rate1 = dt3.Select("MinPeriod=1 and MaxPeriod=30").CopyToDataTable();
                    lblLeaseRent1.Text = rate1.Rows[0]["Rate"].ToString();
                    txtLeaseRent1.Text = rate1.Rows[0]["Rate"].ToString();
                    DataTable rate2 = dt3.Select("MinPeriod=31 and MaxPeriod=60").CopyToDataTable();
                    txtLeaseRent2.Text = rate2.Rows[0]["Rate"].ToString();
                    lblLeaseRent2.Text = rate2.Rows[0]["Rate"].ToString();
                    DataTable rate3 = dt3.Select("MinPeriod=61 and MaxPeriod=90").CopyToDataTable();
                    txtLeaseRent3.Text = rate3.Rows[0]["Rate"].ToString();
                    lblLeaseRent3.Text = rate3.Rows[0]["Rate"].ToString();
                }




                if (dt0.Rows.Count > 0)
                {
                    string RegionalOffice = dt0.Rows[0]["RegionalOffice"].ToString();
                    string RefNo = dt0.Rows[0]["ServiceReqNo"].ToString();
                    string AllotmentDate = dt0.Rows[0]["AllotmentDate"].ToString();
                    string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string product = dt0.Rows[0]["IndustryType"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotSize"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["SignatoryAddress"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string FirstDemandDate = dt0.Rows[0]["FirstDemandDate"].ToString();
                    string PlotRate = dt0.Rows[0]["RateOfPlot"].ToString();
                    string ReservationMoneyPer = dt0.Rows[0]["ReservationMoney"].ToString();
                    string EMDRate = dt0.Rows[0]["EMDRAte"].ToString();
                    string EMDDepositDays = dt0.Rows[0]["EMDDepositDays"].ToString();
                    string RemPremiumPercent = dt0.Rows[0]["RemainingPercentPremium"].ToString();
                    string NoOfInstallment = dt0.Rows[0]["NoOfInstallment"].ToString();
                    string InterestRate = dt0.Rows[0]["InterestRate"].ToString();
                    string Rebate = dt0.Rows[0]["Rebate"].ToString();
                    string LocationchargePer = dt0.Rows[0]["Locationchage"].ToString();


                    htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{AllotmentDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{Product}}", product);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);


                    lblPlotArea.Text = PlotArea;
                    lblFirstInstallmentDate.Text = FirstDemandDate;
                    txtFirstInstallmentDate.Text = FirstDemandDate;
                    lblPlotRate.Text = PlotRate;
                    txtPlotRateVerified.Text = PlotRate;
                    lblReservationMoney.Text = ReservationMoneyPer;
                    lblEmdRate.Text = EMDRate;
                    lblEMDDepositDays.Text = EMDDepositDays;
                    lblRemPremiumPer.Text = RemPremiumPercent;
                    lblNoOfInstallment.Text = NoOfInstallment;
                    lblInterest.Text = InterestRate;
                    lblRebatePer.Text = Rebate;
                    lblChargePer.Text = LocationchargePer;
                    txtpref1.Text = dt0.Rows[0]["PlotPreference1"].ToString();
                    txtpref2.Text = dt0.Rows[0]["PlotPreference2"].ToString();
                    txtpref3.Text = dt0.Rows[0]["PlotPreference3"].ToString();
                    txtprefarea.Text = dt0.Rows[0]["PlotSize"].ToString();

                    txtConstructionValueVerified.Text = "";
                    txtReservationMoneyVerified.Text = ReservationMoneyPer;
                    txtEmdRatePerVerified.Text = EMDRate;
                    txtEmdDepositDaysVerified.Text = EMDDepositDays;
                    txtLocationChargeRateVerified.Text = "";
                    txtChargePerVerified.Text = LocationchargePer;
                    txtRemPremiumPerVerified.Text = RemPremiumPercent;
                    txtInstallment.Text = NoOfInstallment;
                    txtRebate.Text = Rebate;
                    txtInterestRate.Text = InterestRate;
                    txtDepreciation.Text = "";
                    txtCoveredArea.Text = "";

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOfficee = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOfficee);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }

                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|IAName:" + IAName + "|DocType:Allotment";
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

                if (dt2.Rows.Count > 0)
                {
                    GridPlot.DataSource = dt2;
                    GridPlot.DataBind();


                }
                else
                {
                    GridPlot.DataSource = null;
                    GridPlot.DataBind();
                }
                if (dt4.Rows.Count > 0)
                {
                    txtPoductionStartPeriod.Text = dt4.Rows[0]["ProductionStarPeriod"].ToString();
                    txtChooseplot.Text = dt4.Rows[0]["PlotNo"].ToString();
                    txtChoosePlotArea.Text = dt4.Rows[0]["PlotSize"].ToString();
                    txtPlotRateVerified.Text = dt4.Rows[0]["RateOfPlot"].ToString();
                    txtFirstInstallmentDate.Text = dt4.Rows[0]["FirstInstallmentDate"].ToString();
                    txtConstructionValueVerified.Text = dt4.Rows[0]["ConstructionValue"].ToString();
                    txtReservationMoneyVerified.Text = dt4.Rows[0]["RegistrationMoneyRate"].ToString();
                    txtEmdRatePerVerified.Text = dt4.Rows[0]["EMDRate"].ToString();
                    txtEmdDepositDaysVerified.Text = dt4.Rows[0]["EMDDepositDays"].ToString();
                    txtLocationChargeRateVerified.Text = dt4.Rows[0]["LocationChargeRs"].ToString();
                    txtChargePerVerified.Text = dt4.Rows[0]["LocationChage"].ToString();
                    txtRemPremiumPerVerified.Text = dt4.Rows[0]["RemPremiumPer"].ToString();
                    txtInstallment.Text = dt4.Rows[0]["NoofInstallments"].ToString();
                    txtRebate.Text = dt4.Rows[0]["Rebate"].ToString();
                    txtInterestRate.Text = dt4.Rows[0]["InterestRate"].ToString();
                    txtDepreciation.Text = dt4.Rows[0]["DepreciationonShed"].ToString();
                    txtCoveredArea.Text = dt4.Rows[0]["CoveredArea"].ToString();
                    txtLeaseRent1.Text = dt4.Rows[0]["LeaseRent1"].ToString();
                    txtLeaseRent2.Text = dt4.Rows[0]["LeaseRent2"].ToString();
                    txtLeaseRent3.Text = dt4.Rows[0]["LeaseRent3"].ToString();

                }
                string html1 = "";

                if (dt6.Rows.Count > 0)
                {

                    html1 = @"<table   Class='table table-hover table-bordered' style='width:100%;'>
                                <tr style='border-bottom:1px solid #000;'><th align='center' style='border-bottom:1px solid #000;'>Installment No.</th><th align='center' style='border-bottom:1px solid #000;'> Due Date Of Installment </th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Interest Due (Without Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Premium Due</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (With Rebate)</th><th align='center' style='border-bottom:1px solid #000;'>Total Amount (Without Rebate)</th></tr>";
                    foreach (DataRow dr in dt6.Rows)
                    {

                        html1 += "<tr><td align='center'>" + dr["S_no"].ToString() + "</td><td align='center'>" + dr["Duedate"].ToString() + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["intrestDueWithoutRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["PremiumDue"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithRebate"]).ToString("N2") + "</td><td align='center'>&#x20B9;" + Convert.ToDouble(dr["TotalAmountWithoutRebate"]).ToString("N2") + "</td></tr>";
                    }


                    html1 += "</table>";
                    htmlContent = htmlContent.Replace("{{Installments}}", html1);
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
                        temp_annexre_details_DataBind();
                    }

                }
                if (dt7.Rows.Count > 0)
                {
                    string Clause = "<li style='text - align:justify; line - height:25px'><span>Additional clauses as mentioned below are also remain part of the terms of allotment and binding on you.";
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", Clause);

                }
                else
                {
                    htmlContent = htmlContent.Replace("{{AdditionalClause}}", "");
                }







            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal1.Text = htmlContent;

        }

        public void GetAllotteeDetailForBuilding()
        {
            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/LidaBuilding_Plan_Letter.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForLidaBuildingPlanLetter '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt7 = ds.Tables[2];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ref_BuildingPlan"].ToString();
                    string AllotmentDate = dt0.Rows[0]["DateOfBuldingPlanApproval"].ToString();
                    string AppDate = dt0.Rows[0]["DateOfBuldingPlanRequest"].ToString(); // For temp
                    string BlockNo = dt0.Rows[0]["block_no"].ToString();
                    string PlotArea = dt0.Rows[0]["plot_no"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string project_name = dt0.Rows[0]["project_name"].ToString();
                    string POName = dt0.Rows[0]["POName"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", AllotmentDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{BlockNo}}", BlockNo);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{project_name}}", project_name);
                    htmlContent = htmlContent.Replace("{{POName}}", POName);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }
                    string code = "ApplicationNo:" + lblServiceReqNo.Text + "|ApplicantName:" + AllotteeName + "|Project Name:" + project_name + "|DocType:BuildingPlan";
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

            Literal2.Text = htmlContent;

        }

        private void BindPrimaryGridTEF()
        {

            SqlCommand cmd = new SqlCommand("GetTransferLetter '" + lblServiceReqNo.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[1];
            gvAll.DataSource = dt;

            gvAll.DataBind();

        }
        private void BindPrimaryGridLeaseRent()
        {

            SqlCommand cmd = new SqlCommand("GetTransferLetter '" + lblServiceReqNo.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[2];
            gvAll1.DataSource = dt;

            gvAll1.DataBind();

        }
        protected void CheckPlot_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GetTEF();
            gvAll.PageIndex = e.NewPageIndex;
            BindPrimaryGridTEF();
            SetTEF();
        }
        protected void OnPaging1(object sender, GridViewPageEventArgs e)
        {
            GetLeaseRent();
            gvAll1.PageIndex = e.NewPageIndex;
            BindPrimaryGridLeaseRent();
            SetLeaseRent();
        }

        protected void OnPaging2(object sender, GridViewPageEventArgs e)
        {
            GetLeaseRentAllotment();
            LeaseRentGrid.PageIndex = e.NewPageIndex;
            BindPrimaryGridLeaseRentAllotment();
            SetLeaseRentAllotement();
        }
        private void GetTEF()
        {
            DataTable dt;
            if (ViewState["SelectedRecords"] != null)
                dt = (DataTable)ViewState["SelectedRecords"];
            else
                dt = CreateDataTableForTEF();
            CheckBox chkAll = (CheckBox)gvAll.HeaderRow
                                .Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dt = AddRowInTEF(gvAll.Rows[i], dt);
                }
                else
                {
                    CheckBox chk = (CheckBox)gvAll.Rows[i]
                                    .Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRowInTEF(gvAll.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRowFromTEF(gvAll.Rows[i], dt);
                    }
                }
            }
            ViewState["SelectedRecords"] = dt;
        }
        private void GetLeaseRent()
        {
            DataTable dt;
            if (ViewState["SelectedRecords1"] != null)
                dt = (DataTable)ViewState["SelectedRecords1"];
            else
                dt = CreateDataTableForLeaseRent();
            CheckBox chkAll = (CheckBox)gvAll1.HeaderRow
                                .Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvAll1.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dt = AddRowInLeaseRent(gvAll1.Rows[i], dt);
                }
                else
                {
                    CheckBox chk = (CheckBox)gvAll1.Rows[i]
                                    .Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRowInLeaseRent(gvAll1.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRowFromLeaseRent(gvAll1.Rows[i], dt);
                    }
                }
            }
            ViewState["SelectedRecords1"] = dt;
        }
        private void GetLeaseRentAllotment()
        {
            DataTable dt;
            if (ViewState["SelectedLeaseForAllotement"] != null)
                dt = (DataTable)ViewState["SelectedLeaseForAllotement"];
            else
                dt = CreateDataTableForLeaseRentAllotment();
            for (int i = 0; i < LeaseRentGrid.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)LeaseRentGrid.Rows[i]
                                .Cells[0].FindControl("chk1");
                if (chk.Checked)
                {
                    dt = AddRowInLeaseRentAllotment(LeaseRentGrid.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRowFromLeaseRentAllotment(LeaseRentGrid.Rows[i], dt);
                }

            }
            ViewState["SelectedLeaseForAllotement"] = dt;
        }
        private void SetTEF()
        {
            CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
            chkAll.Checked = true;
            if (ViewState["SelectedRecords"] != null)
            {
                DataTable dt = (DataTable)ViewState["SelectedRecords"];
                for (int i = 0; i < gvAll.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                    Label lbl = (Label)gvAll.Rows[i].Cells[1].FindControl("lblRateId");
                    if (chk != null)
                    {
                        DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
                        chk.Checked = dr.Length > 0;
                        if (!chk.Checked)
                        {
                            chkAll.Checked = false;
                        }
                    }
                }
            }
        }
        private void SetLeaseRent()
        {
            CheckBox chkAll = (CheckBox)gvAll1.HeaderRow.Cells[0].FindControl("chkAll");
            chkAll.Checked = true;
            if (ViewState["SelectedRecords1"] != null)
            {
                DataTable dt = (DataTable)ViewState["SelectedRecords1"];
                for (int i = 0; i < gvAll1.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gvAll1.Rows[i].Cells[0].FindControl("chk");
                    Label lbl = (Label)gvAll1.Rows[i].Cells[1].FindControl("lblRateId");
                    if (chk != null)
                    {
                        DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
                        chk.Checked = dr.Length > 0;
                        if (!chk.Checked)
                        {
                            chkAll.Checked = false;
                        }
                    }
                }
            }
        }

        private void SetLeaseRentAllotement()
        {

            if (ViewState["SelectedLeaseForAllotement"] != null)
            {
                DataTable dt = (DataTable)ViewState["SelectedLeaseForAllotement"];
                for (int i = 0; i < LeaseRentGrid.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)LeaseRentGrid.Rows[i].Cells[0].FindControl("chk1");
                    Label lbl = (Label)LeaseRentGrid.Rows[i].Cells[1].FindControl("lblRateId");
                    if (chk != null)
                    {
                        DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
                        chk.Checked = dr.Length > 0;

                    }
                }
            }
        }
        private DataTable CreateDataTableForTEF()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Rate");
            dt.Columns.Add("MinPeriod");
            dt.Columns.Add("MaxPeriod");
            dt.AcceptChanges();
            return dt;
        }
        private DataTable CreateDataTableForLeaseRent()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Rate");
            dt.Columns.Add("MinPeriod");
            dt.Columns.Add("MaxPeriod");
            dt.AcceptChanges();
            return dt;
        }
        private DataTable CreateDataTableForLeaseRentAllotment()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Rate");
            dt.Columns.Add("MinPeriod");
            dt.Columns.Add("MaxPeriod");
            dt.AcceptChanges();
            return dt;
        }
        private DataTable AddRowInTEF(GridViewRow gvRow, DataTable dt)
        {
            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["Id"] = lbl.Text;
                dt.Rows[dt.Rows.Count - 1]["Rate"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["MinPeriod"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["MaxPeriod"] = gvRow.Cells[4].Text;
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable AddRowInLeaseRent(GridViewRow gvRow, DataTable dt)
        {

            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["Id"] = lbl.Text;
                dt.Rows[dt.Rows.Count - 1]["Rate"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["MinPeriod"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["MaxPeriod"] = gvRow.Cells[4].Text;
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable AddRowInLeaseRentAllotment(GridViewRow gvRow, DataTable dt)
        {

            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["Id"] = lbl.Text;
                dt.Rows[dt.Rows.Count - 1]["Rate"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["MinPeriod"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["MaxPeriod"] = gvRow.Cells[4].Text;
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable RemoveRowFromTEF(GridViewRow gvRow, DataTable dt)
        {
            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable RemoveRowFromLeaseRent(GridViewRow gvRow, DataTable dt)
        {
            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable RemoveRowFromLeaseRentAllotment(GridViewRow gvRow, DataTable dt)
        {
            Label lbl = (Label)gvRow.Cells[1].FindControl("lblRateId");
            DataRow[] dr = dt.Select("Id = '" + lbl.Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }


        protected void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            GetTEF();
            SetTEF();
            BindSecondaryGridTEF();
        }
        protected void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
            GetLeaseRent();
            SetLeaseRent();
            BindSecondaryGridLeaseRent();
        }

        protected void CheckBox2_CheckChanged(object sender, EventArgs e)
        {

            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("chk1");

            int index = Convert.ToInt32(row.RowIndex);

            string Rate = LeaseRentGrid.DataKeys[index].Values[0].ToString();

            if (ddl2.Checked == true)
            {

                if (index == 0)
                {
                    txtLeaseRent1.Text = Rate;
                }
                if (index == 1)
                {
                    txtLeaseRent2.Text = Rate;
                }
                if (index == 2)
                {
                    txtLeaseRent3.Text = Rate;
                }

            }
            else if (ddl2.Checked == false)
            {

                if (index == 0)
                {
                    txtLeaseRent1.Text = "";
                }
                if (index == 1)
                {
                    txtLeaseRent2.Text = "";
                }
                if (index == 2)
                {
                    txtLeaseRent3.Text = "";
                }
            }






            GetLeaseRentAllotment();
            SetLeaseRentAllotement();
            BindSecondaryGridLeaseRentAllotment();
        }


        private void BindSecondaryGridTEF()
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            gvSelected.DataSource = dt;
            gvSelected.DataBind();
        }
        private void BindSecondaryGridLeaseRent()
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords1"];
            gvSelected1.DataSource = dt;
            gvSelected1.DataBind();
        }

        private void BindSecondaryGridLeaseRentAllotment()
        {
            DataTable dt = (DataTable)ViewState["SelectedLeaseForAllotement"];
            gvSelectedLeaseAllotment.DataSource = dt;
            gvSelectedLeaseAllotment.DataBind();
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
                txtNoOfInstallmentVerified.Enabled = false;
                txtNoOfInstallmentVerified.Text = lblNoOfInstallments.Text;
                I28.Visible = true;
                I18.Visible = false;
            }
            else if (ddlVerifyNoOfInstallment.SelectedValue.Trim() == "No")
            {
                txtNoOfInstallmentVerified.Enabled = true;
                txtNoOfInstallmentVerified.Text = "";
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
                txtLocationChargeVerified.Enabled = false;
                txtLocationChargeVerified.Text = lblLocationCharge.Text;
                I26.Visible = true;
                I16.Visible = false;
            }
            else if (ddlVerifyLocationCharge.SelectedValue.Trim() == "No")
            {
                txtLocationChargeVerified.Enabled = true;
                txtLocationChargeVerified.Text = "";
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
                txtRegistrationMoneyRateVerified.Enabled = false;
                txtRegistrationMoneyRateVerified.Text = lblRegistrationMoneyRate.Text;
                I25.Visible = true;
                I15.Visible = false;
            }
            else if (ddlVerifyReservationMoney.SelectedValue.Trim() == "No")
            {
                txtRegistrationMoneyRateVerified.Enabled = true;
                txtRegistrationMoneyRateVerified.Text = "";
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
                txtEMDRateVerified.Enabled = false;
                txtEMDRateVerified.Text = lblEMDRates.Text;
                I24.Visible = true;
                I14.Visible = false;

            }
            else if (ddlVeriFyEmdRates.SelectedValue.Trim() == "No")
            {
                txtEMDRateVerified.Enabled = true;
                txtEMDRateVerified.Text = "";
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
                txtRebateVerified.Text = lblRebate.Text;
                txtRebateVerified.Enabled = false;
                I27.Visible = true;
                I17.Visible = false;

            }
            else if (ddlRebateVerify.SelectedValue.Trim() == "No")
            {
                txtRebateVerified.Text = "";
                txtRebateVerified.Enabled = true;
                I27.Visible = false;
                I17.Visible = true;

            }
            else
            {

            }
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

                if (LumpSumRad.Checked == true)
                {
                    LevyType = "LumpSum";
                }
                if (InstallmentRad.Checked == true)
                {
                    LevyType = "Installment";
                }


                if (Validate2())
                {
                    if (strSender == "NewSystem")
                    { command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantDataNew]", con, transaction); }
                    else { command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantData]", con, transaction); }
                    //command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantData]", con, transaction);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                    command.Parameters.AddWithValue("@PlotNo", txtVerifiedPlot.Text);
                    command.Parameters.AddWithValue("@PlotSize", txtPlotSizeVerify.Text);
                    command.Parameters.AddWithValue("@RateofPlot", txtRateOfPlotVerified.Text);
                    command.Parameters.AddWithValue("@InterestRate", txtInterestRateVerified.Text);
                    command.Parameters.AddWithValue("@NoofInstallments", txtNoOfInstallmentVerified.Text);
                    command.Parameters.AddWithValue("@EMDRate", txtEMDRateVerified.Text);
                    command.Parameters.AddWithValue("@LocationChage", txtLocationChargeVerified.Text);
                    command.Parameters.AddWithValue("@TransferLevyPercentage", txtTransferLevyVerified.Text);
                    command.Parameters.AddWithValue("@Rebate", txtRebateVerified.Text);
                    command.Parameters.AddWithValue("@RegistrationMoneyRate", txtRegistrationMoneyRateVerified.Text);
                    command.Parameters.AddWithValue("@Premium", txtPremiumVerified.Text);
                    command.Parameters.AddWithValue("@IntOnPremium", txtIntOnPremiumVerified.Text);
                    command.Parameters.AddWithValue("@MaintenanceCharge", txtMaintenanceChargeVerified.Text);
                    command.Parameters.AddWithValue("@IntOnMaintenanceCharge", txtIntOnMaintenanceCharge.Text);
                    command.Parameters.AddWithValue("@LeaseRent", txtLeaseRentVerified.Text);
                    command.Parameters.AddWithValue("@GSTOnLeaseRent", txtGSTOnLeaseRentVerified.Text);
                    command.Parameters.AddWithValue("@TEF", txtTEFVerified.Text);
                    command.Parameters.AddWithValue("@IntOnTEF", txtIntOnTEFVerified.Text);
                    command.Parameters.AddWithValue("@LeasePeriod", txtLeasePeriodVerified.Text);
                    command.Parameters.AddWithValue("@LevyType", LevyType.Trim());



                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                }
                else
                {
                    string message = "Please Verify All Data";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;

                }

                DataTable temp = (DataTable)ViewState["SelectedRecords"];

                if (temp != null)
                {

                    command = new SqlCommand(@"Delete from ServiceCustomSetApplicantData_TEF where ServiceRequestNo='" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));



                    foreach (DataRow dr in temp.Rows)
                    {
                        string Rate = dr["Rate"].ToString();
                        string MinPeriod = dr["MinPeriod"].ToString();
                        string MaxPeriod = dr["MaxPeriod"].ToString();
                        string Id = dr["Id"].ToString();

                        command = new SqlCommand(@"[Sp_InsertServiceCustomTEFData]", con, transaction);

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                        command.Parameters.AddWithValue("@Rate", Rate);
                        command.Parameters.AddWithValue("@MinPeriod", MinPeriod);
                        command.Parameters.AddWithValue("@MaxPeriod", MaxPeriod);
                        command.Parameters.AddWithValue("@CreatedBy", UserName);
                        command.Parameters.AddWithValue("@MasterId", Id);
                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                    }
                }

                DataTable temp1 = (DataTable)ViewState["SelectedRecords1"];
                if (temp1 != null)
                {
                    command = new SqlCommand(@"Delete from [ServiceCustomSetApplicantData_Lease_Rate] where ServiceRequestNo='" + lblServiceReqNo.Text + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));


                    foreach (DataRow dr in temp1.Rows)
                    {
                        string Rate = dr["Rate"].ToString();
                        string MinPeriod = dr["MinPeriod"].ToString();
                        string MaxPeriod = dr["MaxPeriod"].ToString();
                        string Id = dr["Id"].ToString();


                        command = new SqlCommand(@"[Sp_InsertServiceCustomTrasferLeaseData]", con, transaction);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                        command.Parameters.AddWithValue("@Rate", Rate);
                        command.Parameters.AddWithValue("@MinPeriod", MinPeriod);
                        command.Parameters.AddWithValue("@MaxPeriod", MaxPeriod);
                        command.Parameters.AddWithValue("@CreatedBy", UserName);
                        command.Parameters.AddWithValue("@MasterId", Id);
                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                    }
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
        protected void check_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("check");

            string str = string.Empty;
            string str1 = string.Empty;
            decimal totalArea = 0;

            int index = Convert.ToInt32(row.RowIndex);


            string PlotNumber = GridPlot.DataKeys[index].Values[0].ToString();
            string PlotArea = GridPlot.DataKeys[index].Values[1].ToString();

            foreach (GridViewRow rw in GridPlot.Rows)
            {
                CheckBox chkBx = (CheckBox)rw.FindControl("check");
                if (chkBx != null && chkBx.Checked)
                {

                    str = str + rw.Cells[1].Text.Trim();
                    str += ",";
                    totalArea += Convert.ToDecimal(rw.Cells[2].Text.Trim());

                }
            }
            if (ddl2.Checked == true)
            {

                txtChooseplot.Text = str.TrimEnd(',');
                txtChoosePlotArea.Text = totalArea.ToString();
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", false);
        }

        private void BindPrimaryGridLeaseRentAllotment()
        {

            SqlCommand cmd = new SqlCommand("GetAllotmentLetter '" + lblServiceReqNo.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[3];
            LeaseRentGrid.DataSource = dt;
            LeaseRentGrid.DataBind();

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
            if (txtRegistrationMoneyRateVerified.Text.Length <= 0)
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
            if (txtLocationChargeVerified.Text.Length <= 0)
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
            if (txtRebateVerified.Text.Length <= 0)
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
            if (txtEMDRateVerified.Text.Length <= 0)
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
            if (txtNoOfInstallmentVerified.Text.Length <= 0)
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
                if (txtEMDRateVerified.Text.Length <= 0)
                {
                    txtEMDRateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtEMDRateVerified.Style.Clear();

                }
                if (txtRegistrationMoneyRateVerified.Text.Length <= 0)
                {
                    txtRegistrationMoneyRateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtRegistrationMoneyRateVerified.Style.Clear();

                }
                if (txtLocationChargeVerified.Text.Length <= 0)
                {
                    txtLocationChargeVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLocationChargeVerified.Style.Clear();

                }
                if (txtRebateVerified.Text.Length <= 0)
                {
                    txtRebateVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtRebateVerified.Style.Clear();

                }
                if (txtNoOfInstallmentVerified.Text.Length <= 0)
                {
                    txtNoOfInstallmentVerified.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtNoOfInstallmentVerified.Style.Clear();

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

        protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox chkbox = (CheckBox)e.Row.FindControl("chk");
                Label lblCheck = (Label)e.Row.FindControl("lblCheckbox");
                if (lblCheck.Text == "1")
                {
                    chkbox.Checked = true;

                }
                else
                {
                    chkbox.Checked = false;
                }

            }
        }

        protected void gvAll1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox chkbox = (CheckBox)e.Row.FindControl("chk");
                Label lblCheck = (Label)e.Row.FindControl("lblCheckbox");
                if (lblCheck.Text == "1")
                {
                    chkbox.Checked = true;
                }
                else
                {
                    chkbox.Checked = false;
                }

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
            if (txtNoOfInstallmentVerified.Text.Length <= 0)
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

        protected void ddlLeasePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeasePeriod.SelectedValue.Trim() == "Yes")
            {
                txtLeasePeriodVerified.Text = lblLeasePeriod.Text;
                txtLeasePeriodVerified.Enabled = false;
                I57.Visible = false;
                I58.Visible = true;

            }
            else if (ddlLeasePeriod.SelectedValue.Trim() == "No")
            {
                txtLeasePeriodVerified.Text = "";
                txtLeasePeriodVerified.Enabled = true;
                I57.Visible = true;
                I58.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLeasePeriodVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtLeasePeriodVerified.Text.Length <= 0)
            {
                I57.Visible = true;
                I58.Visible = false;
            }
            else
            {
                I57.Visible = false;
                I58.Visible = true;
            }
        }

        protected void ddlPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlotNo.SelectedValue.Trim() == "Yes")
            {
                txtPlotNoVerified.Text = lblPlotNo.Text;
                txtPlotNoVerified.Enabled = false;
                IDis11.Visible = false;
                IApp11.Visible = true;

            }
            else if (ddlPlotNo.SelectedValue.Trim() == "No")
            {
                txtPlotNoVerified.Text = "";
                txtPlotNoVerified.Enabled = true;
                IDis11.Visible = true;
                IApp11.Visible = false;

            }
            else
            {

            }
        }

        protected void txtPlotNoVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtPlotNoVerified.Text.Length <= 0)
            {
                IDis11.Visible = true;
                IApp11.Visible = false;
            }
            else
            {
                IDis11.Visible = false;
                IApp11.Visible = true;
            }
        }

        protected void ddlPlotArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlotArea.SelectedValue.Trim() == "Yes")
            {
                txtPlotAreaVerified.Text = lblPlotArea.Text;
                txtPlotAreaVerified.Enabled = false;
                IDis12.Visible = false;
                IApp12.Visible = true;

            }
            else if (ddlPlotArea.SelectedValue.Trim() == "No")
            {
                txtPlotAreaVerified.Text = "";
                txtPlotAreaVerified.Enabled = true;
                IDis12.Visible = true;
                IApp12.Visible = false;

            }
            else
            {

            }
        }

        protected void txtPlotAreaVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtPlotAreaVerified.Text.Length <= 0)
            {
                IDis12.Visible = true;
                IApp12.Visible = false;
            }
            else
            {
                IDis12.Visible = false;
                IApp12.Visible = true;
            }

        }

        protected void ddlInstallmentDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInstallmentDate.SelectedValue.Trim() == "Yes")
            {
                txtFirstInstallmentDate.Text = lblFirstInstallmentDate.Text;
                txtFirstInstallmentDate.Enabled = false;
                IDis13.Visible = false;
                IApp13.Visible = true;

            }
            else if (ddlInstallmentDate.SelectedValue.Trim() == "No")
            {
                txtFirstInstallmentDate.Text = "";
                txtFirstInstallmentDate.Enabled = true;
                IDis13.Visible = true;
                IApp13.Visible = false;

            }
            else
            {

            }

        }

        protected void txtFirstInstallmentDate_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstInstallmentDate.Text.Length <= 0)
            {
                IDis13.Visible = true;
                IApp13.Visible = false;
            }
            else
            {
                IDis13.Visible = false;
                IApp13.Visible = true;
            }
        }

        protected void ddlConstructionValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlConstructionValue.SelectedValue.Trim() == "Yes")
            {
                txtConstructionValueVerified.Text = lblExistingConstructionValue.Text;
                txtConstructionValueVerified.Enabled = false;
                IDis14.Visible = false;
                IApp14.Visible = true;

            }
            else if (ddlConstructionValue.SelectedValue.Trim() == "No")
            {
                txtConstructionValueVerified.Text = "";
                txtConstructionValueVerified.Enabled = true;
                IDis14.Visible = true;
                IApp14.Visible = false;

            }
            else
            {

            }
        }

        protected void txtConstructionValueVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtConstructionValueVerified.Text.Length <= 0)
            {
                IDis14.Visible = true;
                IApp14.Visible = false;
            }
            else
            {
                IDis14.Visible = false;
                IApp14.Visible = true;
            }
        }

        protected void ddlRateOfPlot_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddlRateOfPlot.SelectedValue.Trim() == "Yes")
            {
                txtPlotRateVerified.Text = lblPlotRate.Text;
                txtPlotRateVerified.Enabled = false;
                IDis15.Visible = false;
                IApp15.Visible = true;

            }
            else if (ddlRateOfPlot.SelectedValue.Trim() == "No")
            {
                txtPlotRateVerified.Text = "";
                txtPlotRateVerified.Enabled = true;
                IDis15.Visible = true;
                IApp15.Visible = false;

            }
            else
            {

            }

        }

        protected void txtPlotRateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtPlotRateVerified.Text.Length <= 0)
            {
                IDis15.Visible = true;
                IApp15.Visible = false;
            }
            else
            {
                IDis15.Visible = false;
                IApp15.Visible = true;
            }
        }

        protected void ddlReservationMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReservationMoney.SelectedValue.Trim() == "Yes")
            {
                txtReservationMoneyVerified.Text = lblReservationMoney.Text;
                txtReservationMoneyVerified.Enabled = false;
                IDis16.Visible = false;
                IApp16.Visible = true;

            }
            else if (ddlReservationMoney.SelectedValue.Trim() == "No")
            {
                txtReservationMoneyVerified.Text = "";
                txtReservationMoneyVerified.Enabled = true;
                IDis16.Visible = true;
                IApp16.Visible = false;

            }
            else
            {

            }

        }

        protected void txtReservationMoneyVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtReservationMoneyVerified.Text.Length <= 0)
            {
                IDis16.Visible = true;
                IApp16.Visible = false;
            }
            else
            {
                IDis16.Visible = false;
                IApp16.Visible = true;
            }
        }

        protected void ddlEmdRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmdRate.SelectedValue.Trim() == "Yes")
            {
                txtEmdRatePerVerified.Text = lblEmdRate.Text;
                txtEmdRatePerVerified.Enabled = false;
                IDis17.Visible = false;
                IApp17.Visible = true;

            }
            else if (ddlEmdRate.SelectedValue.Trim() == "No")
            {
                txtEmdRatePerVerified.Text = "";
                txtEmdRatePerVerified.Enabled = true;
                IDis17.Visible = true;
                IApp17.Visible = false;

            }
            else
            {

            }

        }

        protected void txtEmdRatePerVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtEmdRatePerVerified.Text.Length <= 0)
            {
                IDis17.Visible = true;
                IApp17.Visible = false;
            }
            else
            {
                IDis17.Visible = false;
                IApp17.Visible = true;
            }

        }

        protected void ddlEmdDepositDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmdDepositDays.SelectedValue.Trim() == "Yes")
            {
                txtEmdDepositDaysVerified.Text = lblEMDDepositDays.Text;
                txtEmdDepositDaysVerified.Enabled = false;
                IDis18.Visible = false;
                IApp18.Visible = true;

            }
            else if (ddlEmdDepositDays.SelectedValue.Trim() == "No")
            {
                txtEmdDepositDaysVerified.Text = "";
                txtEmdDepositDaysVerified.Enabled = true;
                IDis18.Visible = true;
                IApp18.Visible = false;

            }
            else
            {

            }
        }

        protected void txtEmdDepositDaysVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtEmdDepositDaysVerified.Text.Length <= 0)
            {
                IDis18.Visible = true;
                IApp18.Visible = false;
            }
            else
            {
                IDis18.Visible = false;
                IApp18.Visible = true;
            }
        }

        protected void ddlLocationChargeRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocationChargeRate.SelectedValue.Trim() == "Yes")
            {
                txtLocationChargeRateVerified.Text = lblLocationChargeRate.Text;
                txtLocationChargeRateVerified.Enabled = false;
                IDis19.Visible = false;
                IApp19.Visible = true;

            }
            else if (ddlLocationChargeRate.SelectedValue.Trim() == "No")
            {
                txtLocationChargeRateVerified.Text = "";
                txtLocationChargeRateVerified.Enabled = true;
                IDis19.Visible = true;
                IApp19.Visible = false;

            }
            else
            {

            }
        }

        protected void txtLocationChargeRateVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtLocationChargeRateVerified.Text.Length <= 0)
            {
                IDis19.Visible = true;
                IApp19.Visible = false;
            }
            else
            {
                IDis19.Visible = false;
                IApp19.Visible = true;
            }
        }

        protected void ddlChargePer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChargePer.SelectedValue.Trim() == "Yes")
            {
                txtChargePerVerified.Text = lblChargePer.Text;
                txtChargePerVerified.Enabled = false;
                IDis20.Visible = false;
                IApp20.Visible = true;

            }
            else if (ddlChargePer.SelectedValue.Trim() == "No")
            {
                txtChargePerVerified.Text = "";
                txtChargePerVerified.Enabled = true;
                IDis20.Visible = true;
                IApp20.Visible = false;

            }
            else
            {

            }
        }

        protected void txtChargePerVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtChargePerVerified.Text.Length <= 0)
            {
                IDis20.Visible = true;
                IApp20.Visible = false;
            }
            else
            {
                IDis20.Visible = false;
                IApp20.Visible = true;
            }
        }

        protected void ddlRemPremiumPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRemPremiumPer.SelectedValue.Trim() == "Yes")
            {
                txtRemPremiumPerVerified.Text = lblRemPremiumPer.Text;
                txtRemPremiumPerVerified.Enabled = false;
                IDis21.Visible = false;
                IApp21.Visible = true;

            }
            else if (ddlRemPremiumPer.SelectedValue.Trim() == "No")
            {
                txtRemPremiumPerVerified.Text = "";
                txtRemPremiumPerVerified.Enabled = true;
                IDis21.Visible = true;
                IApp21.Visible = false;

            }
            else
            {

            }
        }

        protected void txtRemPremiumPerVerified_TextChanged(object sender, EventArgs e)
        {
            if (txtRemPremiumPerVerified.Text.Length <= 0)
            {
                IDis21.Visible = true;
                IApp21.Visible = false;
            }
            else
            {
                IDis21.Visible = false;
                IApp21.Visible = true;
            }
        }

        protected void ddlInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInstallment.SelectedValue.Trim() == "Yes")
            {
                txtInstallment.Text = lblNoOfInstallment.Text;
                txtInstallment.Enabled = false;
                IDis22.Visible = false;
                IApp22.Visible = true;

            }
            else if (ddlInstallment.SelectedValue.Trim() == "No")
            {
                txtInstallment.Text = "";
                txtInstallment.Enabled = true;
                IDis22.Visible = true;
                IApp22.Visible = false;

            }
            else
            {

            }
        }

        protected void txtInstallment_TextChanged(object sender, EventArgs e)
        {
            if (txtInstallment.Text.Length <= 0)
            {
                IDis22.Visible = true;
                IApp22.Visible = false;
            }
            else
            {
                IDis22.Visible = false;
                IApp22.Visible = true;
            }
        }

        protected void ddlInterest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInterest.SelectedValue.Trim() == "Yes")
            {
                txtInterestRate.Text = lblInterest.Text;
                txtInterestRate.Enabled = false;
                IDis23.Visible = false;
                IApp23.Visible = true;

            }
            else if (ddlInterest.SelectedValue.Trim() == "No")
            {
                txtInterestRate.Text = "";
                txtInterestRate.Enabled = true;
                IDis23.Visible = true;
                IApp23.Visible = false;

            }
            else
            {

            }
        }

        protected void txtInterestRate_TextChanged(object sender, EventArgs e)
        {
            if (txtInterestRate.Text.Length <= 0)
            {
                IDis23.Visible = true;
                IApp23.Visible = false;
            }
            else
            {
                IDis23.Visible = false;
                IApp23.Visible = true;
            }
        }

        protected void ddlDepreciation_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlDepreciation.SelectedValue.Trim() == "Yes")
            {
                txtDepreciation.Text = lblDepreciation.Text;
                txtDepreciation.Enabled = false;
                IDis24.Visible = false;
                IApp24.Visible = true;

            }
            else if (ddlDepreciation.SelectedValue.Trim() == "No")
            {
                txtDepreciation.Text = "";
                txtDepreciation.Enabled = true;
                IDis24.Visible = true;
                IApp24.Visible = false;

            }
            else
            {

            }
        }

        protected void txtDepreciation_TextChanged(object sender, EventArgs e)
        {
            if (txtDepreciation.Text.Length <= 0)
            {
                IDis24.Visible = true;
                IApp24.Visible = false;
            }
            else
            {
                IDis24.Visible = false;
                IApp24.Visible = true;
            }
        }

        protected void ddlRebate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRebate.SelectedValue.Trim() == "Yes")
            {
                txtRebate.Text = lblRebatePer.Text;
                txtRebate.Enabled = false;
                IDis221.Visible = false;
                IApp221.Visible = true;

            }
            else if (ddlRebate.SelectedValue.Trim() == "No")
            {
                txtRebate.Text = "";
                txtRebate.Enabled = true;
                IDis221.Visible = true;
                IApp221.Visible = false;

            }
            else
            {

            }
        }

        protected void txtRebate_TextChanged(object sender, EventArgs e)
        {
            if (txtRebate.Text.Length <= 0)
            {
                IDis221.Visible = true;
                IApp221.Visible = false;
            }
            else
            {
                IDis221.Visible = false;
                IApp221.Visible = true;
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

        protected void ddlCoveredArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCoveredArea.SelectedValue.Trim() == "Yes")
            {
                txtCoveredArea.Text = lblCoveredArea.Text;
                txtCoveredArea.Enabled = false;
                IDis28.Visible = false;
                IApp28.Visible = true;

            }
            else if (ddlCoveredArea.SelectedValue.Trim() == "No")
            {
                txtCoveredArea.Text = "";
                txtCoveredArea.Enabled = true;
                IDis28.Visible = true;
                IApp28.Visible = false;

            }
            else
            {

            }
        }

        protected void txtCoveredArea_TextChanged(object sender, EventArgs e)
        {
            if (txtCoveredArea.Text.Length <= 0)
            {
                IDis28.Visible = true;
                IApp28.Visible = false;
            }
            else
            {
                IDis28.Visible = false;
                IApp28.Visible = true;
            }
        }

        #endregion

        protected void LeaseRentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox chkbox = (CheckBox)e.Row.FindControl("chk1");
                Label lblCheck = (Label)e.Row.FindControl("lblCheckbox");
                if (lblCheck.Text == "1")
                {
                    chkbox.Checked = true;
                }
                else
                {
                    chkbox.Checked = false;
                }

            }
        }

        protected void LockAllotmentData_Click(object sender, EventArgs e)
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


                if (ValidateAllotmnetDataFacts())
                {

                    decimal result1 = Convert.ToDecimal(lblResultSet1.Value);
                    decimal result2 = Convert.ToDecimal(lblResultSet2.Value);
                    decimal difference = Convert.ToDecimal(lblResultSet3.Value);
                    string EmdType = "";
                    if (result1 > result2)
                    {
                        EmdType = "Refund";
                    }
                    else
                    {
                        EmdType = "Payable";
                    }

                    if (txtFirstInstallmentDate.Text == "")
                    {
                        string message = "Please Verify first Installment Date";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }

                    if (strSender == "NewSystem")
                    { command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantDataAllottmentNew]", con, transaction); }
                    else { command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantDataAllottment]", con, transaction); }
                    //command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantData]", con, transaction);


                    //command = new SqlCommand(@"[Sp_InsertServiceCustomSetApplicantDataAllottment]", con, transaction);
                    string date_to_be = DateTime.ParseExact(txtFirstInstallmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                    command.Parameters.AddWithValue("@PlotNo", txtChooseplot.Text);
                    command.Parameters.AddWithValue("@PlotSize", txtChoosePlotArea.Text);
                    command.Parameters.AddWithValue("@RateofPlot", txtPlotRateVerified.Text);
                    command.Parameters.AddWithValue("@InterestRate", txtInterestRate.Text);
                    command.Parameters.AddWithValue("@NoofInstallments", txtInstallment.Text);
                    command.Parameters.AddWithValue("@EMDRate", txtEmdRatePerVerified.Text);
                    command.Parameters.AddWithValue("@LocationChargePer", txtChargePerVerified.Text);
                    command.Parameters.AddWithValue("@FirstInstallmentDate", date_to_be);
                    command.Parameters.AddWithValue("@Rebate", txtRebate.Text);
                    command.Parameters.AddWithValue("@RegistrationMoneyRate", txtReservationMoneyVerified.Text);
                    command.Parameters.AddWithValue("@ConstructionValue", txtConstructionValueVerified.Text);
                    command.Parameters.AddWithValue("@EMDDepositdays", txtEmdDepositDaysVerified.Text);
                    command.Parameters.AddWithValue("@LocationChargeRs", txtLocationChargeRateVerified.Text);
                    command.Parameters.AddWithValue("@RemPremiumPer", txtRemPremiumPerVerified.Text);
                    command.Parameters.AddWithValue("@DepreciationOnShed", txtDepreciation.Text);
                    command.Parameters.AddWithValue("@CoveredArea", txtCoveredArea.Text);
                    command.Parameters.AddWithValue("@LeaseRent1", txtLeaseRent1.Text);
                    command.Parameters.AddWithValue("@LeaseRent2", txtLeaseRent2.Text);
                    command.Parameters.AddWithValue("@LeaseRent3", txtLeaseRent3.Text);
                    command.Parameters.AddWithValue("@EMDDifference", difference);
                    command.Parameters.AddWithValue("@EMDNature", EmdType.Trim());
                    command.Parameters.AddWithValue("@ProductionStart", txtPoductionStartPeriod.Text.Trim());




                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));



                    DataTable temp1 = (DataTable)ViewState["SelectedLeaseForAllotement"];
                    if (temp1 != null)
                    {
                        command = new SqlCommand(@"Delete from [ServiceCustomSetApplicantData_Lease_Rate] where ServiceRequestNo='" + lblServiceReqNo.Text + "'", con, transaction);
                        transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));


                        foreach (DataRow dr in temp1.Rows)
                        {
                            string Rate = dr["Rate"].ToString();
                            string MinPeriod = dr["MinPeriod"].ToString();
                            string MaxPeriod = dr["MaxPeriod"].ToString();
                            string Id = dr["Id"].ToString();


                            command = new SqlCommand(@"[Sp_InsertServiceCustomTrasferLeaseData]", con, transaction);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ServiceReqNo", lblServiceReqNo.Text);
                            command.Parameters.AddWithValue("@Rate", Rate);
                            command.Parameters.AddWithValue("@MinPeriod", MinPeriod);
                            command.Parameters.AddWithValue("@MaxPeriod", MaxPeriod);
                            command.Parameters.AddWithValue("@CreatedBy", UserName);
                            command.Parameters.AddWithValue("@MasterId", Id);
                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                        }
                    }
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
                    string message = "Data Facts Locked Successfully";
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



        public bool ValidateAllotmnetDataFacts()
        {
            try
            {
                bool remark = true;


                if (txtChooseplot.Text.Length <= 0)
                {
                    txtChooseplot.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtChooseplot.Style.Clear();

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

        public void temp_clause_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                ClauseGrid.DataSource = dt;
                ClauseGrid.DataBind();
                ClauseGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                ClauseGrid.DataSource = dt;
                ClauseGrid.DataBind();
            }

        }

        protected void insert_clause_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];

            string Clause = (ClauseGrid.FooterRow.FindControl("txtClause_insert1") as TextBox).Text.Replace(",", ""); ;


            if (Clause != "")
            {

                DataRow dr = dt.NewRow();
                dr["Clause"] = Clause;


                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_clause_details"] = dt;
                temp_clause_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Clause');", true);
                return;
            }

        }

        protected void ClauseDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_clause_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_clause_details"] = dt;

            dt.AcceptChanges();


            temp_clause_details_DataBind();


        }


        protected void btnLockPlotCancel_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                int retVal1 = 0;
                int retVal2 = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                DataTable temp1 = (DataTable)ViewState["temp_clause_details"];
                retVal1 = objServiceTimelinesBLL.ClearPlotCancelNotices(objServiceTimelinesBEL);
                if (retVal1 >= 0)
                {

                    if (temp1.Rows.Count > 0)
                    {


                        foreach (DataRow dr2 in temp1.Rows)
                        {
                            string Clause = dr2["Clause"].ToString();


                            objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo.Trim();
                            objServiceTimelinesBEL.Clause = Clause.Trim();


                            retVal2 = objServiceTimelinesBLL.SaveClauseNoticesDetails(objServiceTimelinesBEL);

                        }


                        if (retVal2 > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Facts Saved Successfully');", true);
                            return;
                        }


                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Clauses Entered');", true);
                        return;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetPlotCancelDetails()
        {

            string htmlContent = "";

            StreamReader reader = new StreamReader(Server.MapPath("/html/Plot_Cancelation.html"));
            htmlContent = reader.ReadToEnd();
            reader.Close();


            try
            {

                SqlCommand cmd = new SqlCommand("DetailsForPlotCancellation '" + lblServiceReqNo.Text + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];



                if (dt0.Rows.Count > 0)
                {
                    string RefNo = dt0.Rows[0]["ServiceRequestNO"].ToString();
                    string IssueDate = dt0.Rows[0]["IssueDate"].ToString();
                    string AppDate = dt0.Rows[0]["ApplicationDate"].ToString();
                    string IAName = dt0.Rows[0]["IndustrialArea"].ToString();
                    string PlotArea = dt0.Rows[0]["PlotNo"].ToString();
                    string AllotteeName = dt0.Rows[0]["AllotteeName"].ToString();
                    string Address = dt0.Rows[0]["Address"].ToString();
                    string RMName = dt0.Rows[0]["RMName"].ToString();
                    string AllotmentLetterNo = dt0.Rows[0]["AllotmentLetterNo"].ToString();

                    htmlContent = htmlContent.Replace("{{RefNo}}", RefNo);
                    htmlContent = htmlContent.Replace("{{IssueDate}}", IssueDate);
                    htmlContent = htmlContent.Replace("{{ApplicationDate}}", AppDate);
                    htmlContent = htmlContent.Replace("{{IAName}}", IAName);
                    htmlContent = htmlContent.Replace("{{PlotNo}}", PlotArea);
                    htmlContent = htmlContent.Replace("{{AllotteeName}}", AllotteeName);
                    htmlContent = htmlContent.Replace("{{Address}}", Address);
                    htmlContent = htmlContent.Replace("{{RMName}}", RMName);
                    htmlContent = htmlContent.Replace("{{AllotmentLetterNo}}", AllotmentLetterNo);

                    if (dt1.Rows.Count > 0)
                    {
                        string RegionalOffice = dt1.Rows[0]["OfficeName"].ToString();
                        string OfficeAddress1 = dt1.Rows[0]["OfficeAddress1"].ToString();
                        string OfficeAddress2 = dt1.Rows[0]["OfficeAddress2"].ToString();
                        string OfficePhone = dt1.Rows[0]["OfficePhoneNo"].ToString();
                        string OfficeEmailId = dt1.Rows[0]["OfficeEmailId"].ToString();
                        htmlContent = htmlContent.Replace("{{RegionalOffice}}", RegionalOffice);
                        htmlContent = htmlContent.Replace("{{OfficeAddress1}}", OfficeAddress1);
                        htmlContent = htmlContent.Replace("{{OfficeAddress2}}", OfficeAddress2);
                        htmlContent = htmlContent.Replace("{{TelNo}}", OfficePhone);
                        htmlContent = htmlContent.Replace("{{EmailId}}", OfficeEmailId);
                    }










                    if (dt2.Rows.Count >= 0)
                    {

                        gridNotices.DataSource = dt2;
                        gridNotices.DataBind();




                    }


                    if (dt3.Rows.Count >= 0)
                    {

                        if (ViewState["temp_clause_details"] == null || ViewState["temp_clause_details"].Equals(""))
                        {
                            DataTable temp_clause_details = new DataTable();
                            temp_clause_details.TableName = "temp_clause_details";
                            temp_clause_details.Columns.Add(new DataColumn("Clause", typeof(string)));
                            ViewState["temp_clause_details"] = temp_clause_details;

                            ViewState["temp_clause_details"] = dt3;
                            temp_clause_details_DataBind();
                        }


                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

            Literal3.Text = htmlContent;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtFirstInstallmentDate.Enabled = true;
            txtConstructionValueVerified.Enabled = true;
            txtPlotRateVerified.Enabled = true;
            txtReservationMoneyVerified.Enabled = true;
            txtEmdRatePerVerified.Enabled = true;
            txtEmdDepositDaysVerified.Enabled = true;
            txtLocationChargeRateVerified.Enabled = true;
            txtChargePerVerified.Enabled = true;
            txtRemPremiumPerVerified.Enabled = true;
            txtInstallment.Enabled = true;
            txtRebate.Enabled = true;
            txtInterestRate.Enabled = true;
            txtDepreciation.Enabled = true;
            txtCoveredArea.Enabled = true;
            txtLeaseRent1.Enabled = true;
            txtLeaseRent2.Enabled = true;
            txtLeaseRent3.Enabled = true;
            txtPoductionStartPeriod.Enabled = true;
        }


        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string str1 = string.Empty;
            decimal totalArea = 0;
            foreach (GridViewRow rw in GridPlot.Rows)
            {
                CheckBox chkBx = (CheckBox)rw.FindControl("check");
                if (chkBx != null && chkBx.Checked)
                {

                    str = str + rw.Cells[1].Text.Trim();
                    str += ",";
                    totalArea += Convert.ToDecimal(rw.Cells[2].Text.Trim());

                }
            }
            txtChooseplot.Text = str.TrimEnd(',');
            txtChoosePlotArea.Text = totalArea.ToString();
        }

        protected void txtPoductionStartPeriod_TextChanged(object sender, EventArgs e)
        {
            if (txtPoductionStartPeriod.Text.Length <= 0)
            {
                I3.Visible = true;
                I4.Visible = false;
            }
            else
            {
                I3.Visible = false;
                I4.Visible = true;
            }
        }

         public void temp_annexre_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                AnnexreGrid.DataSource = dt;
                AnnexreGrid.DataBind();
                AnnexreGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                AnnexreGrid.DataSource = dt;
                AnnexreGrid.DataBind();
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
            GetAllotteeDetailForBuilding();
        }
        protected void insert_annexre_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];

            string Clause = (AnnexreGrid.FooterRow.FindControl("txtReasonRej") as TextBox).Text.Replace(",", "");


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
                temp_annexre_details_DataBind();
            }

        }
        protected void AnnexreDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_annexre_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_annexre_details"] = dt;
            dt.AcceptChanges();
            temp_annexre_details_DataBind();
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

        protected void LockBPData_Click(object sender, EventArgs e)
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



                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Data Facts Locked Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                    GetAllotteeDetailForBuilding();

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


    }


}