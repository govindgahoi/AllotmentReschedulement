using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationFinalView : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        public string ServiceRequestNo { get; set; }
        public string Parameter { get; set; }
        public string TranID { get; set; }
        #endregion


        private DataTable Getdata1
        {
            get; set;
        }

        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }


        public void Page_Load(object sender, EventArgs e)
        {

            GetApplicantDetails(ServiceRequestNo);
            BindApplicableFees(ServiceRequestNo);

        }


        private void GetApplicantDetails(String ID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                string html = "";
                string html1 = "";
                int i = 0;
                int j = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ID;
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["ApplicantId"].ToString();
                    lblApplicantId.Text = dt.Rows[0]["FormNo"].ToString();
                    lblDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lblDistrict.Text = dt.Rows[0]["District"].ToString();
                    lblIA.Text = dt.Rows[0]["IndustrialAreaName"].ToString();
                    lblPlotRange.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblPlotArea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblName.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    lblTelephone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblPlotpreference1.Text = dt.Rows[0]["PlotPreference1"].ToString();
                    lblPlotpreference2.Text = dt.Rows[0]["PlotPreference2"].ToString();
                    lblPlotpreference3.Text = dt.Rows[0]["PlotPreference3"].ToString();
                    lblFirmConstitution.Text = dt.Rows[0]["company_type"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    lblCINNo.Text = dt.Rows[0]["CinNo"].ToString();
                    lblEmailInd.Text = dt.Rows[0]["emailID"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address1"].ToString();
                    lblPreferredPlot.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblPayeeName.Text = dt.Rows[0]["PayeeName"].ToString();
                    lblBankName.Text = dt.Rows[0]["BankName"].ToString();
                    lblAcctNo.Text = dt.Rows[0]["AccountNumber"].ToString();
                    lblIFSCCode.Text = dt.Rows[0]["IFSCCode"].ToString();
                    lblBranchName.Text = dt.Rows[0]["BranchName"].ToString();
                    lblBranchAddress.Text = dt.Rows[0]["BranchAddress"].ToString();
                    PermLbl.Text = dt.Rows[0]["MainSerID"].ToString();
                    provLbl.Text = ID;


                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ApplicantName"].ToString() + "</td><td>" + dr["Address1"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["emailID"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);

                        Headerlbl.Text = "Individual/Sole Proprietorship firm Details";

                    }

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {

                        Headerlbl.Text = "Directors Details";

                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Din/Pan</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["DirectorName"].ToString() + "</td><td>" + dr["DIN_PAN"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);
                    }

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {

                        Headerlbl.Text = "ShareHolders Details";


                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Shares (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ShareholderName"].ToString() + "</td><td>" + dr["SharePer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);
                    }

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {

                        Headerlbl.Text = "Partners Details";
                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Partnership (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["PartnerName"].ToString() + "</td><td>" + dr["PartnershipPer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);
                    }

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {

                        Headerlbl.Text = "Trustee Details";


                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["TrusteeName"].ToString() + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);
                    }


                    string Imagetype = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    string ImageName = dt.Rows[0]["ApplicantImageName"].ToString().Trim();
                    string img = dt.Rows[0]["ApplicantImage"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }

                }
                if (dt_project.Rows.Count > 0)
                {
                    lblIndustrytype.Text = dt_project.Rows[0]["IndustryType"].ToString();
                    lblPlotRequiredExpansion.Text = dt_project.Rows[0]["ExpansionOfLand"].ToString();
                    lblExportOrientedIndustry.Text = dt_project.Rows[0]["ExportOriented"].ToString();
                    lblRelevantExperience.Text = dt_project.Rows[0]["WorkExperience"].ToString();
                    lblTimelimitSetup.Text = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    lblLandCost.Text = dt_project.Rows[0]["LandDetails"].ToString();
                    lblBuildingCost.Text = dt_project.Rows[0]["BuildingDetails"].ToString();
                    lblPlantMachineryCost.Text = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    lblTotalProjectCost.Text = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    lblCoveredarea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                    lblOpenArea.Text = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    lblSolidQuantity.Text = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    lblSolidComposition.Text = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    lblLiquidQuantity.Text = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    lblLiquidComposition.Text = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    lblGasQuantity.Text = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    lblGasComposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    lblEstimatedEmployment.Text = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    lblInvestmentOtherAssets.Text = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    lblInvestmentOtherExpenses.Text = dt_project.Rows[0]["OtherExpenses"].ToString();
                    lblProposedEffluents1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    lblProposedEffluents2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    lblProposedEffluents3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    lblPowerrequirement.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();
                    lblTelephoneFirstYear.Text = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    lblTelephoneSecondYear.Text = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    lblNetWorthTurnover.Text = dt_project.Rows[0]["NetWorth"].ToString();
                    lblpriorityCategory.Text = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString();
                    lblTypeOfIndustryy.Text = dt_project.Rows[0]["IAClasification"].ToString();
                    lblIndustrialCategory.Text = dt_project.Rows[0]["PollutionCategory"].ToString();
                    lblEtp.Text = dt_project.Rows[0]["EtpRequired"].ToString();
                    string IACategory = dt_project.Rows[0]["IACategory"].ToString();
                    lblIAname.Text = lblIA.Text;
                    lblExisPlotNo.Text = dt_project.Rows[0]["ExistingPlotNo"].ToString();
                    lblAllotmentDate.Text = dt_project.Rows[0]["AllotmentDateS"].ToString();
                    lblAllotmentNo.Text = dt_project.Rows[0]["AllotmentNo"].ToString().Trim();
                    lblAllotteeName.Text = dt_project.Rows[0]["AllotteeName"].ToString().Trim();
                    lblProductManufatured.Text = dt_project.Rows[0]["ProductManufactured"].ToString().Trim();
                    lblTurnOver.Text = dt_project.Rows[0]["NetTurnover"].ToString().Trim();

                    if (lblPlotRequiredExpansion.Text.Trim() == "YES")
                    {
                        ExistingUnit.Visible = true;
                    }
                    else
                    {
                        ExistingUnit.Visible = false;
                    }
                    if (lblEtp.Text == "Yes")
                    {
                        MeasureDiv.Visible = true;
                    }
                    else
                    {
                        MeasureDiv.Visible = false;
                    }

                    if (IACategory.Trim() == "1" || IACategory.Trim() == "2")
                    {
                        DivPollution.Visible = true;
                    }
                    else
                    {
                        DivPollution.Visible = false;
                    }


                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        lblFumesGenerated.Text = "Yes";
                        DivFume.Visible = true;
                        lblFumeQty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                        lblFumeNature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        lblFumesGenerated.Text = "No";
                        DivFume.Visible = false;
                        lblFumeQty.Text = "";
                        lblFumeNature.Text = "";

                    }




                }


                if (dt_doc.Rows.Count > 0)
                {

                    html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>CheckList </th><th>Checklist Description</th><th>Document uploaded</th></tr>";
                    foreach (DataRow dr in dt_doc.Rows)
                    {
                        j++;
                        html1 += "<tr><td>" + j.ToString() + "</td><td>" + dr["ServiceTimeLinesCondition"].ToString() + "</td><td>" + dr["ServiceTimeLinesDocuments"] + "</td><td>" + dr["Name"] + "</td></tr>";
                    }

                    PH2.Controls.Clear();
                    html1 += "</table>";
                    Literal loLit1 = new Literal();
                    loLit1.Text = (html1);
                    PH2.Controls.Add(loLit1);
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        public void BindApplicableFees(string serviceNO)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dsR = new DataSet();
            DataSet dsoper = new DataSet();
            DataSet dst = new DataSet();
            DataSet Pay_Ds = new DataSet();
            try
            {
                DataTable dt_Fee = new DataTable();
                DataTable dt_Fee_other = new DataTable();
                DataTable Paymentdt = new DataTable();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                objServiceTimelinesBEL.TranID = TranID;

                dst = objServiceTimelinesBLL.GetNivishMitraBasicDetail(ServiceRequestNo);
                if (dst.Tables[0].Rows.Count > 0) { Getdata3 = dst.Tables[0]; }

                if (TranID == "" || TranID == null)
                {

                }
                else
                {
                    Pay_Ds = objServiceTimelinesBLL.GetPaymentDetailTransactionWise(objServiceTimelinesBEL);
                    Paymentdt = Pay_Ds.Tables[0];
                }

                dsR = objServiceTimelinesBLL.GetapplicableChargesnDataNew(ServiceRequestNo);


                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                try { Getdata1 = dt_Fee.Select("type  = 'A'", "sno").CopyToDataTable(); } catch { }
                try { Getdata2 = dt_Fee.Select("type  = 'B'", "sno").CopyToDataTable(); } catch { }


                string htmldata = "";
                DateTime date_today = DateTime.Now;
                decimal subTotalApplicableFees = 0;
                decimal subTotalDeposits = 0;
                decimal subTotalDues = 0;
                decimal TotalCharges = 0;
                string Applicantname = string.Empty;
                string appliedthrough = string.Empty;
                string industrialarea = string.Empty;
                string plotsize = string.Empty;
                string PayMode = string.Empty;
                string TranRefNo = string.Empty;
                string TranDate = string.Empty;
                string PayStatus = string.Empty;
                string[] tokens = ServiceRequestNo.Split('/');
                string Serviceid = tokens[1].ToString();
                string SWCControlID = String.Empty;
                string SWCUnitID = String.Empty;
                string SWCServiceID = String.Empty;
                string SWCStatus = String.Empty;
                string SWCPayMode = String.Empty;
                string SWCPassSalt = System.Configuration.ConfigurationManager.AppSettings["passsalt"];

                string ConfirmDate = string.Empty;

                if (Paymentdt.Rows.Count > 0)
                {
                    PayMode = Paymentdt.Rows[0]["PaymentMode"].ToString();
                    TranRefNo = Paymentdt.Rows[0]["EazypayRefNo"].ToString();
                    TranDate = Paymentdt.Rows[0]["TransactionDate"].ToString();
                    ConfirmDate = Paymentdt.Rows[0]["ReconcileDate"].ToString();
                    if (Paymentdt.Rows[0]["Paid"].ToString() == "True")
                    {
                        PayStatus = "Payment Completed";
                    }
                    else
                    {
                        PayStatus = "Payment Pending";
                    }


                }

                if (Getdata1.Rows.Count > 0)
                {

                    subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                    subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));


                    TotalCharges = subTotalApplicableFees + subTotalDeposits + subTotalDues;
                    Applicantname = Getdata3.Rows[0][0].ToString();
                    industrialarea = Getdata3.Rows[0][1].ToString();
                    plotsize = Getdata3.Rows[0][2].ToString() + " SQmts.";
                    if ((Getdata3.Rows[0][3].ToString() == string.Empty) || (Getdata3.Rows[0][3].ToString() == null))
                    {
                        appliedthrough = "UPSIDC-Internals";

                    }
                    else { appliedthrough = "Nivesh Mitra Single Window Clearence"; }

                    if (Getdata1.Rows.Count > 0)
                    {


                        string report_date = date_today.ToString("MMMM d, yyyy");
                        htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";

                        if ((Getdata3.Rows.Count > 0))
                        {

                            if (Paymentdt.Rows.Count > 0)
                            {
                                htmldata += @"
                              <div class='col- md-6'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
                                    <tr style='background:#f7f7f7;'> 
                                    <td>Service Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + Applicantname + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + industrialarea + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Required Plot Size " + "" + "</td><td style='text-align:left;'>" + plotsize + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Applied Through" + "" + "</td><td style='text-align:left;'>" + appliedthrough + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Mode" + "" + "</td><td style='text-align:left;'>" + PayMode + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Ref No" + "" + "</td><td style='text-align:left;'>" + TranRefNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Date" + "" + "</td><td style='text-align:left;'>" + TranDate + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Status" + "" + "</td><td style='text-align:left;'>" + PayStatus + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Confirmation Date" + "" + "</td><td style='text-align:left;'>" + ConfirmDate + @"</td></tr>


                               </table></div>";
                            }
                            else
                            {
                                htmldata += @"
                              <div class='col- md-6'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
                                    <tr style='background:#f7f7f7;'> 
                                    <td>Service Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
                                   <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + Applicantname + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + industrialarea + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Required Plot Size " + "" + "</td><td style='text-align:left;'>" + plotsize + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Applied Through" + "" + "</td><td style='text-align:left;'>" + appliedthrough + @"</td></tr>
                           
                               </table></div>";
                            }
                        }


                        htmldata += @"

                                 <br /><br/><br/><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"" width=""100%"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                        htmldata += @"
                               <tr><td colspan=""3"">" + "A. Applicable Fees" + @"</td></tr>";



                        foreach (DataRow row in Getdata1.Rows)
                        {
                            htmldata += @" <tr> ";


                            htmldata += @"<td class='text-center'>" + @row["sno"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["paydescription"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["applicablecharge"].ToString() + @"</td>";

                            //foreach (DataColumn column in Getdata1.Columns)
                            //{
                            //    htmldata += @"<td class='text-center'> ";
                            //    htmldata += @row[column.ColumnName];
                            //    htmldata += @"</td> ";
                            //}
                            htmldata += @"</tr> ";
                        }

                        htmldata += @"<tr><td colspan=""2"" style='text-align:center;'> Sub Total Applicable Fees</td><td style='text-align:left;'>&#x20B9;" + subTotalApplicableFees + @"</td></tr>";


                        //Building the Data rows for deposits.
                        if (Serviceid == "1000")
                        {
                            htmldata += @"
                               <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";
                            foreach (DataRow row in Getdata2.Rows)
                            {
                                htmldata += @"<tr> ";


                                htmldata += @"<td style='text-align:left;'>" + @row["sno"].ToString() + @"</td>
                                          <td style='text-align:left;'>" + @row["paydescription"].ToString() + @"</td>
                                          <td style='text-align:left;'>" + @row["applicablecharge"].ToString() + @"</td>";

                                htmldata += @"</tr> ";
                            }
                            htmldata += @"
                              <tr><td colspan=""2"" style='text-align:center;'> Sub Total Deposits</td><td style='text-align:left;'>&#x20B9;</i>" + subTotalDeposits + @"</td></tr>";

                        }
                        else
                        {

                            htmldata += @"
                               <tr><th colspan=""3"">" + "B. Dues" + @"</th></tr>";
                            //Building the Data rows for dues.
                            htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Sub Total Dues</th><th class='text-left'>&#x20B9;</i>" + subTotalDues + @"</th></tr>";

                        }

                        htmldata += @"
                              <tr><td colspan=""2"" style='text-align:center;'> Total Payable ( A+B)</td><td style='text-align:left;'>&#x20B9;</i>" + TotalCharges + @"</td></tr>";



                        htmldata += " </table>";

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        PH3.Controls.Add(loLit);

                    }


                }
                // textbox1.text = dsR.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }




    }
}