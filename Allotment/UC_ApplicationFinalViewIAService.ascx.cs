using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewIAService : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        public string ServiceRequestNo { get; set; }
        public string Parameter { get; set; }
        public string TranID { get; set; }
        public int ServiceID { get; set; }
        public string ControlID { get; set; }
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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            string[] SerArray = ServiceRequestNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);
            if (ServiceID == 1003)
            {
                lblFormName.Text = "Application Form For Change Of Project";
                lblServiceName.Text = "Change Of Project";
            }
            else if (ServiceID == 1004)
            {
                lblFormName.Text = "Application Form For Addition Of Product";
                lblServiceName.Text = "Addition Of Product";
            }

            else if (ServiceID == 1009)
            {
                lblFormName.Text = "Application Form For Completion Certificate";
                lblServiceName.Text = "Completion Certificate";
            }
            else if (ServiceID == 1010)
            {
                lblFormName.Text = "Application Form For Occupancy Certificate";
                lblServiceName.Text = "Occupancy Certificate";
            }
            else if (ServiceID == 1023)
            {
                lblFormName.Text = "Application Form For No Dues Certificate";
                lblServiceName.Text = "No Dues Certificate";
            }
            else if (ServiceID == 1027)
            {
                lblFormName.Text = "Request for Outstanding Dues position";
                lblServiceName.Text = "Request for Outstanding Dues position";
            }
            else if (ServiceID == 1029)
            {
                lblFormName.Text = "Request for Amalgamation of plots : post allotment";
                lblServiceName.Text = "Request for Amalgamation of plots : post allotment";
            }
            else if (ServiceID == 1030)
            {
                lblFormName.Text = "Request for Subdivision of plots : post allotment";
                lblServiceName.Text = "Request for Subdivision of plots : post allotment";
            }
            GetApplicantDetails(ServiceRequestNo);
            if(ControlID.Length>0)
            {
                if (ServiceID == 1023|| ServiceID == 1027)
                {
                    Doc_Div.Visible = false;
                    Payment_Div.Visible = false;
                }
                else
                {
                    Doc_Div.Visible = true;
                    Payment_Div.Visible = true;
                    BindApplicableFeesNMSWP(ServiceRequestNo);
                }
            }
            else
            {
                BindApplicableFees(ServiceRequestNo);
            }
            if (ServiceID == 1029)
            {
                Div_PostAmalgamation.Visible = true;
                AmalgamatePlots();
            }
            if (ServiceID == 1030)
            {
                Div_SubdivisionDetails.Visible = true;
                SubdividedPlots();
            }

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
                ds = objServiceTimelinesBLL.GetAllotteeDetailsIAService(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable dt_dues = ds.Tables[4];
                DataTable dt_objection = ds.Tables[5];
                DataTable dt_AOP = ds.Tables[6];
                DataTable dt_7 = ds.Tables[7];
                DataTable dt_8 = ds.Tables[8];
                if (dt.Rows.Count > 0)
                {
                    lblServiceReqno.Text = ServiceRequestNo;
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblPlotSize.Text = dt.Rows[0]["TotalAllottedplotArea"].ToString();
                    lblApplicationDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lblApplicationReDate.Text = dt.Rows[0]["ApplicationReDate"].ToString();
                    lblName.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    lblTelephone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblFirmConstitution.Text = dt.Rows[0]["company_type"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    lblCINNo.Text = dt.Rows[0]["CinNo"].ToString();
                    lblEmailInd.Text = dt.Rows[0]["emailID"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address1"].ToString();
                    lblIAName.Text = dt.Rows[0]["IndustrialAreaName"].ToString();
                    lblOfficeName.Text = dt.Rows[0]["OfficeName"].ToString();
                    lblAddressOffice.Text = dt.Rows[0]["OAddress"].ToString() + " " + dt.Rows[0]["OAddress1"].ToString();
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
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["DirectorName"].ToString() + "</td><td>" + dr["DIN_PAN"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["Email"] + "</td></tr>";
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
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ShareholderName"].ToString() + "</td><td>" + dr["SharePer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["Email"] + "</td></tr>";
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
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["PartnerName"].ToString() + "</td><td>" + dr["PartnershipPer"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["Email"] + "</td></tr>";
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
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["TrusteeName"].ToString() + "</td><td>" + dr["Address"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["Email"] + "</td></tr>";
                        }

                        PH1.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PH1.Controls.Add(loLit);
                    }




                }
                if (dt_project.Rows.Count > 0)
                {
                    COPDetails.Visible = true;
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


                    lblTurnOver.Text = dt_project.Rows[0]["NetTurnover"].ToString().Trim();


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
                else
                {
                    COPDetails.Visible = false;
                }

                if (dt_AOP.Rows.Count > 0)
                {
                    AOPDetails.Visible = true;
                    lblProductName.Text = dt_AOP.Rows[0]["AdditionalProduct"].ToString();
                    lblProductDescription.Text = dt_AOP.Rows[0]["ProductDescription"].ToString();
                }
                else
                {
                    AOPDetails.Visible = false;
                }

                if (dt_7.Rows.Count > 0)
                {


                    txtFar.Text = dt_7.Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = dt_7.Rows[0]["GroundCoverage"].ToString().Trim();

                    if (txtGroundcover.Text.Length > 0)
                    { BPSpecification_Div.Visible = true; }
                    else { BPSpecification_Div.Visible = false; }
                    txtSetBackFront.Text = dt_7.Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = dt_7.Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = dt_7.Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = dt_7.Rows[0]["side2"].ToString().Trim();
                    txtHeight.Text = dt_7.Rows[0]["Height"].ToString().Trim();
                    txtOccupancy.Text = dt_7.Rows[0]["Occupancy"].ToString().Trim();


                    ///////////////  Updated by Mr. Manish
                    txtBaseMent1.Text = dt_7.Rows[0]["ExistingBasement"].ToString().Trim();
                    txtBaseMent2.Text = dt_7.Rows[0]["ProposedBasement"].ToString().Trim();
                    txtGround1.Text = dt_7.Rows[0]["ExistingGroundFloor"].ToString().Trim();
                    txtGround2.Text = dt_7.Rows[0]["ProposedGroundFloor"].ToString().Trim();
                    txtFirstfloor1.Text = dt_7.Rows[0]["ExistingFirstFloor"].ToString().Trim();
                    txtFirstfloor2.Text = dt_7.Rows[0]["ProposedFirstFloor"].ToString().Trim();
                    txtSecondFloor1.Text = dt_7.Rows[0]["ExistingSecondFloor"].ToString().Trim();
                    txtSecondFloor2.Text = dt_7.Rows[0]["ProposedSecondFloor"].ToString().Trim();
                    txtMezzanine1.Text = dt_7.Rows[0]["ExistingMezzanineFloor"].ToString().Trim();
                    txtMezzanine2.Text = dt_7.Rows[0]["ProposedMezzanineFloor"].ToString().Trim();
                    txtFoundation.Text = dt_7.Rows[0]["Foundation"].ToString().Trim();
                    txtWalls.Text = dt_7.Rows[0]["Walls"].ToString().Trim();
                    txtFloors.Text = dt_7.Rows[0]["Floors"].ToString().Trim();
                    txtRoofs.Text = dt_7.Rows[0]["Roofs"].ToString().Trim();
                    txtStories.Text = dt_7.Rows[0]["NoofStories"].ToString().Trim();
                    txtLatrines.Text = dt_7.Rows[0]["NoofLatrines"].ToString().Trim();
                    txtCoveredAreaA.Text = dt_7.Rows[0]["CoveredArea"].ToString().Trim();

                    txtStealth.Text = dt_7.Rows[0]["StiltFloor"].ToString().Trim();
                    txtMumti.Text = dt_7.Rows[0]["Mumti"].ToString().Trim();


                    txtbuildingPurpose.Text = dt_7.Rows[0]["PurposeofBuildingUse"].ToString().Trim();
                    txtPreviousConstruction.Text = dt_7.Rows[0]["PreviousConstruction"].ToString().Trim();
                    txtWaterSource.Text = dt_7.Rows[0]["SourceofWater"].ToString().Trim();

                    ddlNature.Text = dt_7.Rows[0]["NatureOfOccupancy"].ToString().Trim();



                    lblFarByelaws.Text = dt_8.Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = dt_8.Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = dt_8.Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = dt_8.Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = dt_8.Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = dt_8.Rows[0]["side2"].ToString().Trim();


                }
                else
                {
                    BPSpecification_Div.Visible = false;
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

                string Dues_html = "";
                int k = 0;
                if (dt_dues.Rows.Count > 0)
                {

                    Dues_Div.Visible = true;
                    Dues_html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>Demand Ref No </th><th>Demand Amount</th><th>Date of Demand</th><th>Status</th><th>Paid On</th></tr>";
                    foreach (DataRow dr in dt_dues.Rows)
                    {
                        k++;
                        Dues_html += "<tr><td>" + k.ToString() + "</td><td>" + dr["DemandNo"].ToString() + "</td><td>" + dr["DueAmount"] + "</td><td>" + dr["DemandDate"] + "</td><td>" + dr["Status"] + "</td><td>" + dr["PaidOn"] + "</td></tr>";
                    }

                    PH_Dues.Controls.Clear();
                    Dues_html += "</table>";
                    Literal loLit1 = new Literal();
                    loLit1.Text = (Dues_html);
                    PH_Dues.Controls.Add(loLit1);
                }
                int l = 0;
                string Objection_html = "";
                if (dt_objection.Rows.Count > 0)
                {
                    Objection_Div.Visible = true;
                    Objection_html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>Objection Raised</th><th>Raised On</th><th>Response By You</th><th>Responsed On</th></tr>";
                    foreach (DataRow dr in dt_objection.Rows)
                    {
                        l++;
                        Objection_html += "<tr><td>" + l.ToString() + "</td><td>" + dr["Objection"].ToString() + "</td><td>" + dr["RaisedOnDate"] + "</td><td>" + dr["Response"] + "</td><td>" + dr["ResponseOnDate"] + "</td></tr>";
                    }

                    ph_Objection.Controls.Clear();
                    Objection_html += "</table>";
                    Literal loLit1 = new Literal();
                    loLit1.Text = (Objection_html);
                    ph_Objection.Controls.Add(loLit1);
                }

            }
            catch (Exception ex)
            {
                //Response.Write("Oops! error occured :" + ex.Message.ToString());
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();

                Response.Write("Oops! error occured : Line :" + line + "|Col :" + col + "|Method : " + methodName + "|File : " + fileName);

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

                if (TranID == "" || TranID == null)
                {

                }
                else
                {
                    Pay_Ds = objServiceTimelinesBLL.GetPaymentDetailTransactionWise(objServiceTimelinesBEL);
                    Paymentdt = Pay_Ds.Tables[0];
                }

                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                dsR = objServiceTimelinesBLL.GetApplicableChargesIAServicesView(objServiceTimelinesBEL);


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



                if (Paymentdt.Rows.Count > 0)
                {
                    PayMode = Paymentdt.Rows[0]["PaymentMode"].ToString();
                    TranRefNo = Paymentdt.Rows[0]["EazypayRefNo"].ToString();
                    TranDate = Paymentdt.Rows[0]["TransactionDate"].ToString();
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
                    //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));


                    TotalCharges = subTotalApplicableFees + subTotalDues;

                    appliedthrough = "UPSIDC-Internals";



                    if (Getdata1.Rows.Count > 0)
                    {


                        string report_date = date_today.ToString("MMMM d, yyyy");
                        htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";


                        if (Paymentdt.Rows.Count > 0)
                        {
                            htmldata += @"
                              <div class='col- md-6'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
                                    <tr style='background:#f7f7f7;'> 
                                    <td>Service Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + lblName.Text + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + lblIAName.Text + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Applied Through" + "" + "</td><td style='text-align:left;'>" + appliedthrough + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Mode" + "" + "</td><td style='text-align:left;'>" + PayMode + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Ref No" + "" + "</td><td style='text-align:left;'>" + TranRefNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Date" + "" + "</td><td style='text-align:left;'>" + TranDate + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Status" + "" + "</td><td style='text-align:left;'>" + PayStatus + @"</td></tr>

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


                            htmldata += @"</tr> ";
                        }

                        htmldata += @"<tr><td colspan=""2"" style='text-align:center;'> Sub Total Applicable Fees</td><td style='text-align:left;'>&#x20B9;" + subTotalApplicableFees + @"</td></tr>";


                        ////Building the Data rows for deposits.
                        //if (Serviceid == "1003"||Serviceid=="1004")
                        //{
                        //    htmldata += @"
                        //       <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";
                        //    foreach (DataRow row in Getdata2.Rows)
                        //    {
                        //        htmldata += @"<tr> ";


                        //        htmldata += @"<td style='text-align:left;'>" + @row["sno"].ToString() + @"</td>
                        //                  <td style='text-align:left;'>" + @row["paydescription"].ToString() + @"</td>
                        //                  <td style='text-align:left;'>" + @row["applicablecharge"].ToString() + @"</td>";

                        //        htmldata += @"</tr> ";
                        //    }
                        //    htmldata += @"
                        //      <tr><td colspan=""2"" style='text-align:center;'> Sub Total Deposits</td><td style='text-align:left;'>&#x20B9;</i>" + subTotalDeposits + @"</td></tr>";

                        //}
                        //else
                        //{

                        //    htmldata += @"
                        //       <tr><th colspan=""3"">" + "B. Dues" + @"</th></tr>";
                        //    //Building the Data rows for dues.
                        //    htmldata += @"
                        //      <tr><th colspan=""2"" class='text-center'> Sub Total Dues</th><th class='text-left'>&#x20B9;</i>" + subTotalDues + @"</th></tr>";

                        //}

                        htmldata += @"
                              <tr><td colspan=""2"" style='text-align:center;'> Total Payable ( A+B)</td><td style='text-align:left;'>&#x20B9;</i>" + TotalCharges + @"</td></tr>";

                        htmldata += " </table>";
                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        PH3.Controls.Add(loLit);

                    }


                }

            }
            catch (Exception ex)
            {
                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();

                Response.Write("Oops! error occured : Line :" + line + "|Col :" + col + "|Method : " + methodName + "|File : " + fileName);

            }
        }


        public void BindApplicableFeesNMSWP(string serviceNO)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dschoicearea = new DataSet();
            DataSet dschoiceP1 = new DataSet();
            DataSet dschoiceP2 = new DataSet();
            DataSet dschoiceP3 = new DataSet();
            DataSet Pay_Ds = new DataSet();
            DataTable Paymentdt = new DataTable();
            string htmldata = "";
            DateTime date_today = DateTime.Now;
            decimal subTotalApplicableFees = 0;
            decimal TotalCharges = 0;
            string appliedthrough = string.Empty;
            string industrialarea = string.Empty;
            string plotsize = string.Empty;
            string PayMode = "Nivesh Mitra Payment Gateway";
            string TranRefNo = string.Empty;
            string TranDate = string.Empty;
            string PayStatus = string.Empty;

            try
            {
                GeneralMethod gm = new GeneralMethod();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;


                Pay_Ds = objServiceTimelinesBLL.GetTransactionDetailsNMSWP(objServiceTimelinesBEL);
                Paymentdt = Pay_Ds.Tables[0];


                if (Paymentdt.Rows.Count > 0)
                {
                    PayMode = "Nivesh Mitra Payment Gateway";
                    TranRefNo = Paymentdt.Rows[0]["Transaction_ID"].ToString();
                    TranDate = Paymentdt.Rows[0]["Transaction_Date"].ToString();
                    string Pay = Paymentdt.Rows[0]["Fee_Status"].ToString();
                    if (Pay.Trim() == "Paid")
                    {
                        PayStatus = "Payment Completed";
                    }
                    else
                    {
                        PayStatus = "Payment Pending At NMSWP";
                    }
                }


                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                dschoicearea = objServiceTimelinesBLL.GetApplicableChargesIAServices(objServiceTimelinesBEL);


                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                if (Paymentdt.Rows.Count > 0)
                {
                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""100%"" style=""Font-Size:12px;"">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'>" + ServiceRequestNo + @"</td>
                                     <th style='background:#f7f7f7;'>NM Unit ID" + "" + "</th><td class='text-left'>" + ControlID + @"</td></tr>
                                     <tr> <th>Applied in the name of " + "" + "</th><td class='text-left'>" + lblName.Text + @"</td>
                                     <th style='background:#f7f7f7;'> Address " + "" + "</th><td class='text-left'>" + lblAddress.Text + @"</td></tr>
                                     <tr> <th> Payment Mode " + "" + "</th><td class='text-left'>" + PayMode + @"</td>
                                     <th style='background:#f7f7f7;'> Transaction Ref No " + "" + "</th><td class='text-left'>" + TranRefNo + @"</td></tr>
                                     <tr> <th> Payment Received Date " + "" + "</th><td class='text-left'>" + TranDate + @"</td>
                                     <th style='background:#f7f7f7;'> Payment Status " + "" + "</th><td class='text-left'>" + PayStatus + @"</td></tr>
                               </table></div><br/>";
                }
                else
                {
                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                          </table></div>";
                }
                // for Option 1 : Based on Selected Plot Area              
                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));

                        TotalCharges = subTotalApplicableFees;
                        plotsize = lblPlotSize.Text + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = lblPlotSize.Text + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/>
                                 
                                  
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";



                                htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                    <tr style='background:#f7f7f7;'> <th>Plot No " + "" + "</th><th class='text-left'>" + lblPlotNo.Text + @"</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Plot Area " + "" + "</th><th class='text-left'>" + plotsize + @"</th></tr>
                                  

                               </table></div>";


                                htmldata += @"
                        <div class='col- md-6'><table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">                                 
                                    <tr style = 'background:#f7f7f7;'>
                                    <th>Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";

                                // htmldata += @"
                                //<tr style = 'background:#f7f7f7;'> <th> B. Applicable Deposits" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";

                                htmldata += @"

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges " + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + TotalCharges + @"</th>
                                    </tr>
                                </table></div><br /><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                                htmldata += @"
                               <tr><td colspan=""3"">" + "A. Applicable Fees" + @"</td></tr>";

                                //Building the Data rows for Applicable fees.
                                foreach (DataRow row in Getdata1.Rows)
                                {
                                    htmldata += @" <tr> ";
                                    foreach (DataColumn column in Getdata1.Columns)
                                    {
                                        htmldata += @"<td class='text-center'> ";
                                        htmldata += @row[column.ColumnName];
                                        // html.Append(row[column.ColumnName]);
                                        htmldata += @"</td> ";
                                    }
                                    htmldata += @"</tr> ";
                                }

                                htmldata += @"
                              <tr><td colspan=""2"" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</td></tr>";



                                htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";



                                htmldata += " </table>";

                            }

                        }

                    }



                }
                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                PH3.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        private void AmalgamatePlots()
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_ApplicationRegisterAmalgamationSubdivisionPostAllotment] where ApplicationID='" + ServiceRequestNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                string PlotNo = data.Rows[0]["PlotNo"].ToString();
                string PlotArea = data.Rows[0]["PlotSize"].ToString();
                string IAIDIn = data.Rows[0]["IndustrialArea"].ToString();

                lblAmalgamatedPlots.Text = PlotNo.Trim();
                lblTotalArea.Text = PlotArea.Trim();
                lblAmalgamatedArea.Text = PlotArea.Trim();




                objServiceTimelinesBEL.IAIdParam = IAIDIn.Trim();
                objServiceTimelinesBEL.PlotNo = PlotNo.Trim();
                DataSet ds = new DataSet();


                ds = objServiceTimelinesBLL.GetPlotAdjacencyDetailsPostAmalgamation(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("PlotArea"));
                        lblTotalArea.Text = tot_Demanded.ToString();
                        lblAmalgamatedArea.Text = tot_Demanded.ToString();

                    }
                    else
                    {
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                    }
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }

            }

        }

        private void SubdividedPlots()
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeSubdividedPlotDetails '" + ServiceRequestNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                //decimal tot_Area = data.AsEnumerable().Sum(row => row.Field<decimal>("PlotSize"));
                GridView1.DataSource = data;
                GridView1.DataBind();
                //GridView1.FooterRow.Cells[0].Text = "Total";
                //GridView1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //GridView1.FooterRow.Cells[2].Text = tot_Area.ToString("N2");
            }

        }

    }
}