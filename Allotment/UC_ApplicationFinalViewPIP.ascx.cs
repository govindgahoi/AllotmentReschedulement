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
    public partial class UC_ApplicationFinalViewPIP : System.Web.UI.UserControl
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
            GetPIPApplicantDetails(ServiceRequestNo);
        }
        

        private void GetPIPApplicantDetails(String ID)
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
                ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable dt_Obj = ds.Tables[4];
                DataTable dt_Land = ds.Tables[5];
                DataTable dt_Pay = ds.Tables[6];
                DataTable dt_serviceRequest = ds.Tables[7];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["AllotteeId"].ToString();
                    lblApplicantId.Text = dt.Rows[0]["FormNo"].ToString();
                    lblDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lbl_AuthorisedName.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lbl_Firm.Text = dt.Rows[0]["company_type"].ToString();
                    lbl_CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblPan.Text = dt.Rows[0]["PanNo"].ToString();
                    lblProposedPIP.Text = dt.Rows[0]["ProposedPIP"].ToString();
                    lblEmailID.Text = dt.Rows[0]["emailID"].ToString();
                    provLbl.Text = ID;
                    lblAddress.Text = dt.Rows[0]["Address1"].ToString();
                    lblProjectLocation.Text = dt.Rows[0]["Address"].ToString();
                    lblUdyogAadhar.Text = dt.Rows[0]["UdyogAadharNo"].ToString();
                    lblGSTNo.Text = dt.Rows[0]["GSTNo"].ToString();
                    lblApplicantaadhar.Text = dt.Rows[0]["adharCardNo"].ToString();
                    lblFirmAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
                    lblSPV.Text = dt.Rows[0]["IsSPV"].ToString();

                    //-Added by Sunil - PIP 
                    lblIsRegionPIP.Text = dt.Rows[0]["IsRegionPIP"].ToString();

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>" + i.ToString() + "</td><td>" + dr["AllotteeName"].ToString() + "</td><td>" + dr["Address1"] + "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["emailID"] + "</td></tr>";
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

                    string Imagetype = dt.Rows[0]["AllotteeImageType"].ToString().Trim();
                    string ImageName = dt.Rows[0]["AllotteeImageName"].ToString().Trim();
                    string img = dt.Rows[0]["AllotteeImage"].ToString();
                    string signimg = dt.Rows[0]["AllotteeSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }
                    if (signimg.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeSign"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Img2.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }

                    if (dt_project.Rows.Count > 0)
                    {
                        lblTypeProject.Text = dt_project.Rows[0]["TypeOfProject"].ToString().Trim();

                        if (dt_project.Rows[0]["CategoryOfProject"].ToString().Trim() != "--Select--")
                        {
                            lblCategoryProject.Text = dt_project.Rows[0]["CategoryOfProject"].ToString().Trim();                            
                        }
                        else
                        {
                            lblCategoryProject.Text = "";
                        }

                        lblDateofCompletion.Text = dt_project.Rows[0]["DateofCompletion"].ToString();
                        lblDateCapitalInvestment.Text = dt_project.Rows[0]["datewhencapitalinvestmentstarted"].ToString();
                        lblProposedInvestment.Text = dt_project.Rows[0]["ProposedInvestment"].ToString();

                        

                        if (dt_project.Rows[0]["ProjectDetail"].ToString().Trim() == "Any Other")
                        {
                            lblProjectDetail.Text = dt_project.Rows[0]["ProjectDetail"].ToString().Trim() + " (" + dt_project.Rows[0]["anyOthers"].ToString().Trim() + ")";
                        }
                        else
                        {
                            lblProjectDetail.Text = dt_project.Rows[0]["ProjectDetail"].ToString();
                        }


                        lblDistanceFromRailway.Text = dt_project.Rows[0]["DistanceFromRailway"].ToString();
                        lblProposedDirectEmployment.Text = dt_project.Rows[0]["ProposedDirectEmployment"].ToString();
                        lblDistanceFromBus.Text = dt_project.Rows[0]["DistanceFromBus"].ToString();
                        lblProposedIndirectEmployment.Text = dt_project.Rows[0]["ProposedIndirectEmployment"].ToString();
                        lblDistanceFromAirport.Text = dt_project.Rows[0]["DistanceFromAirport"].ToString();
                        lblTotalAmountRequested.Text = dt_project.Rows[0]["TotalAmountrequestedbyApplicant"].ToString();
                        lblExemptionOnStamp.Text = dt_project.Rows[0]["ExemptionOnStamp"].ToString();
                        lblSubsidyFixedCapitalInvestment.Text = dt_project.Rows[0]["SubsidyFixedCapitalInvestment"].ToString();
                        lblSubsidyHostelDormitory.Text = dt_project.Rows[0]["SubsidyHostelDormitory"].ToString();




                        /*
                        lblAdditionalSubsidyFixedCapitalInvestment.Text = dt_project.Rows[0]["AdditionalSubsidyFixedCapitalInvestment"].ToString();
                        lblCapitalInterestSubsidy.Text        = dt_project.Rows[0]["CapitalInterestSubsidy"].ToString();
                        lblInfrastructureInterestSubsidy.Text = dt_project.Rows[0]["InfrastructureInterestSubsidy"].ToString();
                        lblRebateLandUseConversion.Text       = dt_project.Rows[0]["RebateonLanduseconversioncharges"].ToString();
                        lblExemptionDevelopmentCharges.Text   = dt_project.Rows[0]["Exemptionfromdevelopmentcharges"].ToString();
                        lblElectricityRebate.Text             = dt_project.Rows[0]["ElectricityRebate"].ToString();
                        lblWarehousingCertification.Text      = dt_project.Rows[0]["Warehousingqualitycertificationreimbursement"].ToString();
                        lblAssistanceForPayroll.Text          = dt_project.Rows[0]["assistanceforpayrollofdisabledworkers"].ToString();
                        lblSkillDevelopmentPromotion.Text     = dt_project.Rows[0]["Skilldevelopmentpromotion"].ToString();
                        lblIntelligentLogisticIncentives.Text = dt_project.Rows[0]["IntelligentLogisticIncentives"].ToString();
                        */
                        lblTotalArea.Text = dt_project.Rows[0]["TotalArea"].ToString();
                        lblCoveredArea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                        lblPIPRegistrationNo.Text = dt_project.Rows[0]["PIPRegistrationNo"].ToString();
                        /*
                        lblCapitalSubsidy.Text                = dt_project.Rows[0]["CapitalSubsidy"].ToString();
                        */
                    }

                    if (dt_doc.Rows.Count > 0)
                    {

                        html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>CheckList </th><th>Checklist Description</th><th>Document uploaded</th></tr>";
                        foreach (DataRow dr in dt_doc.Rows)
                        {
                            j++;
                            string founder = dr["Path"].ToString();
                            // Remove all characters after first 25 chars
                            string first25 = founder.Remove(0,1);
                            html1 += "<tr><td>" + j.ToString() + "</td><td>" + dr["ServiceTimeLinesCondition"].ToString() + "</td><td>" + dr["ServiceTimeLinesDocuments"] + "</td><td><a href='" + first25 + "' target='_blank'>View Document</a></td></tr>";
                        }

                        PH2.Controls.Clear();
                        html1 += "</table>";
                        Literal loLit1 = new Literal();
                        loLit1.Text = (html1);
                        PH2.Controls.Add(loLit1);
                    }



                    if (dt_Pay.Rows.Count > 0)
                    {
                        lblSERviceNo.Text = dt_Pay.Rows[0]["ServiceRequestNo"].ToString().Trim();
                        lblAName.Text = dt_Pay.Rows[0]["CompanyName"].ToString().Trim();
                        lblPAddress.Text = dt_Pay.Rows[0]["address1"].ToString();
                        //lblPMode.Text = dt_Pay.Rows[0]["datewhencapitalinvestmentstarted"].ToString();
                        lblTransactionNo.Text = dt_Pay.Rows[0]["Transaction_ID"].ToString();
                        lblPayDate.Text = dt_Pay.Rows[0]["Transaction_Time"].ToString();
                        lblPaystatus.Text = dt_Pay.Rows[0]["Fee_Status"].ToString();
                    }

                    if (dt_Land.Rows.Count > 0)
                    {

                        html3 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr>          
<th> S.NO </th>
<th>Area Details (District, Tehsil, Village)</th>
<th>Land Details (Deed Date), Khasra Number</th>
<th>Land Area (In Hectare)</th>
<th>Value of land (inr cr)</th>
<th>Stamp Duty Paid (inr cr)</th>
<th>Existing Project area land Use</th>
<th>Project area land contiguous</th>
<th>Gram sabha/ government land Involvement</th>
<th>Requirement of Land Exchange</th>
<th>Other Details</th>


                       </tr>";
                        foreach (DataRow dr in dt_Land.Rows)
                        {
                            l++;
                            html3 += "<tr><td>" + l.ToString() + "</td><td>" + dr["District"].ToString() + ", " + dr["Tehsil"].ToString() + ", " + dr["Village"].ToString() + "</td><td>" + dr["LandDeedDate"].ToString() + ", " + dr["KhasraNumber"] + "</td><td>" + dr["LandArea"] + "</td><td>" + dr["LandValue"] + "</td><td>" + dr["StampDutyPaid"] + "</td><td>" + dr["ExistingLand"] + "<br>" + dr["anyOtherExistingProject"] + "</td><td>" + dr["LandContiguousStatus"] + "<br>" + dr["LandContiguous"] + "</td><td>" + dr["GramGovStatus"] + "<br>" + dr["GramGov"] + "</td><td>" + dr["LandExchangeStatus"] + "<br>" + dr["LandExchange"] + "</td><td>" + dr["PIPOtherDetails"] + "</td></tr>"; 
                        }
                        string LandArea = dt_Land.Compute("Sum(LandArea)", string.Empty).ToString();
                        string LandValue = dt_Land.Compute("Sum(LandValue)", string.Empty).ToString();
                        string StampDutyPaid = dt_Land.Compute("Sum(StampDutyPaid)", string.Empty).ToString();
                        html3 += "<tr style='background-color: #ccc;'><td colspan='3' style='text-align: left;padding:  0 5px;border:1px solid #797979;'>Total</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandArea + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + LandValue + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #797979;'>" + StampDutyPaid + "</td><td colspan='5' style='text-align: left;padding:  0 5px;border:1px solid #797979;'></td></tr>";

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