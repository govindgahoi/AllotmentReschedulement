using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewLAW : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        public string ServiceRequestNo { get; set; }

        public string ControlID { get; set; }
        public string Parameter { get; set; }
        public string TranID { get; set; }
        public string TLExemption { get; set; }
        public string TLExemptionCase { get; set; }
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
                string html3 = "";
                int i = 0;
                int j = 0;
                int k = 0;
                int l = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ID;
                ds = objServiceTimelinesBLL.GetLAWDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable dt_Obj = ds.Tables[4];
                DataTable dt_Land = ds.Tables[5];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["ApplicantId"].ToString();
                    lblApplicantId.Text = dt.Rows[0]["FormNo"].ToString();
                    lblDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lbl_AuthorisedName.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lbl_Firm.Text = dt.Rows[0]["company_type"].ToString();
                    lbl_CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblPan.Text = dt.Rows[0]["PanNo"].ToString();
                    lblCin.Text = dt.Rows[0]["CinNo"].ToString();
                    lblEmailID.Text = dt.Rows[0]["emailID"].ToString();
                    provLbl.Text = ID;
                    lblAddress.Text = dt.Rows[0]["Address1"].ToString();
                    lblProjectLocation.Text = dt.Rows[0]["Address2"].ToString();
                    lblUdyogAadhar.Text = dt.Rows[0]["UdyogAadhaar"].ToString();
                    lblGSTNo.Text = dt.Rows[0]["GSTNo"].ToString();
                    lblApplicantaadhar.Text = dt.Rows[0]["AadharCardNo"].ToString();
                    lblFirmAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
                    lblSPV.Text = dt.Rows[0]["IsSPV"].ToString();

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ApplicantName"].ToString() + "</td><td>" + dr["Address1"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["emailID"] + "</td></tr>";
                        }

                        PHH2.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PHH2.Controls.Add(loLit);

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

                        PHH2.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PHH2.Controls.Add(loLit);
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

                        PHH2.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PHH2.Controls.Add(loLit);
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

                        PHH2.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PHH2.Controls.Add(loLit);
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

                        PHH2.Controls.Clear();
                        html += "</table>";
                        Literal loLit = new Literal();
                        loLit.Text = (html);
                        PHH2.Controls.Add(loLit);
                    }

                    string Imagetype = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    string ImageName = dt.Rows[0]["ApplicantImageName"].ToString().Trim();
                    string img = dt.Rows[0]["ApplicantImage"].ToString();
                    string signimg = dt.Rows[0]["ApplicantSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }
                    if (signimg.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantSign"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Img2.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }

                    if (dt_project.Rows.Count > 0)
                    {
                        lblTypeProject.Text = dt_project.Rows[0]["TypeOfProject"].ToString().Trim();
                        lblCategoryProject.Text = dt_project.Rows[0]["CategoryOfProject"].ToString().Trim();
                        lblDateofSettingUnit.Text = dt_project.Rows[0]["Proposeddateforsettinguplogisticunit"].ToString();
                        lblDateCapitalInvestment.Text = dt_project.Rows[0]["datewhencapitalinvestmentstarted"].ToString();
                        lblProposedInvestment.Text = dt_project.Rows[0]["ProposedInvestment"].ToString();
                        lblCostofland.Text = dt_project.Rows[0]["CostoftheLand"].ToString();
                        lblCostofinfrastructure.Text = dt_project.Rows[0]["CostofInfrastructures"].ToString();
                        lblcostofPlantMachinery.Text = dt_project.Rows[0]["CostofthePlantMachinery"].ToString();
                        lblothercost.Text = dt_project.Rows[0]["OtherCost"].ToString();
                        lblBuildingCost.Text = dt_project.Rows[0]["BuildingCostforConstruction"].ToString();
                        lblTotalAmountRequested.Text = dt_project.Rows[0]["TotalAmountrequestedbyApplicant"].ToString();
                        lblRebateOnStamp.Text = dt_project.Rows[0]["RebateonStampDuty"].ToString();
                        lblEPFReimbursement.Text = dt_project.Rows[0]["EPFReimbursement"].ToString();
                        lblAdditionalEPFReimbursement.Text = dt_project.Rows[0]["AdditionalEPFReimbursement"].ToString();
                        lblCapitalInterestSubsidy.Text = dt_project.Rows[0]["CapitalInterestSubsidy"].ToString();
                        lblInfrastructureInterestSubsidy.Text = dt_project.Rows[0]["InfrastructureInterestSubsidy"].ToString();
                        lblRebateLandUseConversion.Text = dt_project.Rows[0]["RebateonLanduseconversioncharges"].ToString();
                        lblExemptionDevelopmentCharges.Text = dt_project.Rows[0]["Exemptionfromdevelopmentcharges"].ToString();
                        lblElectricityRebate.Text = dt_project.Rows[0]["ElectricityRebate"].ToString();
                        lblWarehousingCertification.Text = dt_project.Rows[0]["Warehousingqualitycertificationreimbursement"].ToString();
                        lblAssistanceForPayroll.Text = dt_project.Rows[0]["assistanceforpayrollofdisabledworkers"].ToString();
                        lblSkillDevelopmentPromotion.Text = dt_project.Rows[0]["Skilldevelopmentpromotion"].ToString();
                        lblIntelligentLogisticIncentives.Text = dt_project.Rows[0]["IntelligentLogisticIncentives"].ToString();
                        lblTotalArea.Text = dt_project.Rows[0]["TotalArea"].ToString();
                        lblCoveredArea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                        lblLAWRegistrationNo.Text = dt_project.Rows[0]["LAWRegistrationNo"].ToString();
                        lblCapitalSubsidy.Text = dt_project.Rows[0]["CapitalSubsidy"].ToString();
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

                    if (dt_Land.Rows.Count > 0)
                    {

                        html3 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>District</th><th>Tehsil</th><th>Village</th><th>Land Deed Date </th><th>Land Area (In Hectare)</th><th>Khasra Number</th><th>Value of land as per lease /purchase deed agreement (inr cr)</th><th>Stamp Duty Paid as per lease/purchase agreement (inr cr)</th><th>Existing Project area land Use and required change with status of land</th><th>Is Project area land contiguous</th><th>Is there involvement of any gram sabha/ government land</th><th>Requirement of Land Exchange</th></tr>";
                        foreach (DataRow dr in dt_Land.Rows)
                        {
                            l++;
                            html3 += "<tr><td>" + l.ToString() + "</td><td>" + dr["District"].ToString() + "</td><td>" + dr["Tehsil"].ToString() + "</td><td>" + dr["Village"].ToString() + "</td><td>" + dr["LandDeedDate"].ToString() + "</td><td>" + dr["LandArea"] + "</td><td>" + dr["KhasraNumber"] + "</td><td>" + dr["LandValue"] + "</td><td>" + dr["StampDutyPaid"] + "</td><td>" + dr["ExistingLand"] + "</td><td>" + dr["LandContiguousStatus"] + "</td><td>" + dr["GramGovStatus"] + "</td><td>" + dr["LandExchangeStatus"] + "</td></tr>";
                        }
                        string LandArea = dt_Land.Compute("Sum(LandArea)", string.Empty).ToString();
                        string LandValue = dt_Land.Compute("Sum(LandValue)", string.Empty).ToString();
                        string StampDutyPaid = dt_Land.Compute("Sum(StampDutyPaid)", string.Empty).ToString();
                        html3 += "<tr style='background-color: #ccc;'><td colspan='5' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandArea + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'></td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandValue + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + StampDutyPaid + "</td></tr>";

                        PH3.Controls.Clear();
                        html3 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html3);
                        PH3.Controls.Add(loLit1);
                    }


                    if (dt_Obj.Rows.Count > 0)
                    {
                        ObjectionDiv.Visible = true;
                        string html2 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>Objection</th><th>Objection Date</th><th>Response</th><th>Response Date</th></tr>";
                        foreach (DataRow dr in dt_Obj.Rows)
                        {
                            k++;
                            html2 += "<tr><td>" + k.ToString() + "</td><td>" + dr["Objection"].ToString() + "</td><td>" + dr["RaisedOnDate"] + "</td><td>" + dr["Response"] + "</td><td>" + dr["ResponseOnDate"] + "</td></tr>";
                        }

                        PHObjection.Controls.Clear();
                        html2 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html2);
                        PHObjection.Controls.Add(loLit1);
                    }
                    else
                    {
                        ObjectionDiv.Visible = false;
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }

        }


    }
}