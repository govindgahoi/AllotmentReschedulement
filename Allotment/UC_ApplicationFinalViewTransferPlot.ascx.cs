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
    public partial class UC_ApplicationFinalViewTransferPlot : System.Web.UI.UserControl
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
            if (ControlID.Length > 0)
            {
                BindApplicableFeesNMSWP(ServiceRequestNo);
            }
            else
            {
                BindApplicableFees(ServiceRequestNo);
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
                ds = objServiceTimelinesBLL.GetTransfreeBasicDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable  dt_transferar = ds.Tables[4];
                DataTable dt_transferar_Firm = ds.Tables[5];
                DataTable dt_transferar_Doc = ds.Tables[6];
                DataTable dtAck = ds.Tables[7];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID         = dt.Rows[0]["ApplicantId"].ToString();
                    lblApplicantId.Text       = dt.Rows[0]["FormNo"].ToString();
                    lblDate.Text              = dt.Rows[0]["ApplicationDate"].ToString();
                    lblDistrict.Text          = dt.Rows[0]["District"].ToString();
                    lblIA.Text                = dt.Rows[0]["IndustrialAreaName"].ToString();                 
                    lblPlotArea.Text          = dt.Rows[0]["PlotSize"].ToString();
                    lblName.Text              = dt.Rows[0]["AuthorisedSignatory"].ToString();
                    lblTelephone.Text         = dt.Rows[0]["PhoneNo"].ToString();
                    //-----------------------------------------------------------------------
                    lblFirmConstitution.Text  = dt.Rows[0]["company_type"].ToString();
                    lblCompanyName.Text       = dt.Rows[0]["CompanyName"].ToString();
                    lblPanNo.Text             = dt.Rows[0]["PanNo"].ToString();
                    lblCINNo.Text             = dt.Rows[0]["CinNo"].ToString();
                    lblEmailInd.Text          = dt.Rows[0]["emailID"].ToString();
                    lblAddress.Text           = dt.Rows[0]["Address1"].ToString();
                    lblPreferredPlot.Text     = dt.Rows[0]["PlotNo"].ToString();
                    lblPayeeName.Text         = dt.Rows[0]["PayeeName"].ToString();
                    lblBankName.Text          = dt.Rows[0]["BankName"].ToString();
                    lblAcctNo.Text            = dt.Rows[0]["AccountNumber"].ToString();
                    lblIFSCCode.Text          = dt.Rows[0]["IFSCCode"].ToString();
                    lblBranchName.Text        = dt.Rows[0]["BranchName"].ToString();
                    lblBranchAddress.Text     = dt.Rows[0]["BranchAddress"].ToString();                   
                    provLbl.Text              = ID;
                    TLExemption               = dt.Rows[0]["TLExempted"].ToString();
                    TLExemptionCase   = dt.Rows[0]["TLCaseTypeName"].ToString();

                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        html  = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                        foreach (DataRow dr in dt1.Rows)
                        {
                            i++;
                            html += "<tr><td>"+i.ToString()+"</td><td>"+dr["ApplicantName"].ToString()+"</td><td>"+dr["Address1"]+ "</td><td>" + dr["PhoneNo"] + "</td><td>" + dr["emailID"] + "</td></tr>";
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
                   

                    string Imagetype  = dt.Rows[0]["ApplicantImageType"].ToString().Trim();                   
                    string ImageName  = dt.Rows[0]["ApplicantImageName"].ToString().Trim();
                    string img        = dt.Rows[0]["ApplicantImage"].ToString();
                    string signimg    = dt.Rows[0]["ApplicantSign"].ToString();
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
                        Img1.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }

                }
                if (dt_project.Rows.Count > 0)
                {
                    lblIndustrytype.Text                     = dt_project.Rows[0]["IndustryType"].ToString();
                    lblPlotRequiredExpansion.Text            = dt_project.Rows[0]["ExpansionOfLand"].ToString();
                    lblExportOrientedIndustry.Text           = dt_project.Rows[0]["ExportOriented"].ToString();
                    lblRelevantExperience.Text               = dt_project.Rows[0]["WorkExperience"].ToString();
                    lblTimelimitSetup.Text                   = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    lblLandCost.Text                         = dt_project.Rows[0]["LandDetails"].ToString();
                    lblBuildingCost.Text                     = dt_project.Rows[0]["BuildingDetails"].ToString();
                    lblPlantMachineryCost.Text               = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    lblTotalProjectCost.Text                 = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    lblCoveredarea.Text                      = dt_project.Rows[0]["CoveredArea"].ToString();
                    lblOpenArea.Text                         = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    lblSolidQuantity.Text                    = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    lblSolidComposition.Text                 = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    lblLiquidQuantity.Text                   = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    lblLiquidComposition.Text                = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    lblGasQuantity.Text                      = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    lblGasComposition.Text                   = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    lblEstimatedEmployment.Text              = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    lblInvestmentOtherAssets.Text            = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    lblInvestmentOtherExpenses.Text          = dt_project.Rows[0]["OtherExpenses"].ToString();
                    lblProposedEffluents1.Text               = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    lblProposedEffluents2.Text               = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    lblProposedEffluents3.Text               = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    lblPowerrequirement.Text                 = dt_project.Rows[0]["PowerReqInKW"].ToString();
                    lblTelephoneFirstYear.Text               = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    lblTelephoneSecondYear.Text              = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    lblNetWorthTurnover.Text                 = dt_project.Rows[0]["NetWorth"].ToString();
                    lblpriorityCategory.Text                 = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString();
                    lblTypeOfIndustryy.Text                   = dt_project.Rows[0]["IAClasification"].ToString();
                    lblIndustrialCategory.Text               = dt_project.Rows[0]["PollutionCategory"].ToString();
                    lblEtp.Text                              = dt_project.Rows[0]["EtpRequired"].ToString();
                    string IACategory                        = dt_project.Rows[0]["IACategory"].ToString();
                    lblIAname.Text                           = lblIA.Text;
                    lblExisPlotNo.Text                       = dt_project.Rows[0]["ExistingPlotNo"].ToString();
                    lblAllotmentDate.Text                    = dt_project.Rows[0]["AllotmentDateS"].ToString();
                    lblAllotmentNo.Text                      = dt_project.Rows[0]["AllotmentNo"].ToString().Trim();
                    lblAllotteeName.Text                     = dt_project.Rows[0]["AllotteeName"].ToString().Trim();
                    lblProductManufatured.Text               = dt_project.Rows[0]["ProductManufactured"].ToString().Trim();
                    lblTurnOver.Text                         = dt_project.Rows[0]["NetTurnover"].ToString().Trim();

                    if (lblPlotRequiredExpansion.Text.Trim()=="YES")
                    {
                        ExistingUnit.Visible = true;
                    }else
                    {
                        ExistingUnit.Visible = false;
                    }
                    if(lblEtp.Text=="Yes")
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


                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString()=="True")
                    {
                        lblFumesGenerated.Text = "Yes";
                        DivFume.Visible = true;
                        lblFumeQty.Text                      = dt_project.Rows[0]["FumeQuantity"].ToString();
                        lblFumeNature.Text                   = dt_project.Rows[0]["FumeNature"].ToString();
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

                if (dt_transferar.Rows.Count > 0)
                {
                    lbl_TransferarAuthorisedName.Text  = dt_transferar.Rows[0]["AllotteeName"].ToString();
                    lbl_TransferCompanyName.Text       = dt_transferar.Rows[0]["CompanyName"].ToString();
                    lblTransferarPan.Text              = dt_transferar.Rows[0]["PanNo"].ToString();
                    lblTransferarCin.Text              = dt_transferar.Rows[0]["CinNo"].ToString();
                    lblTransferarEmailID.Text          = dt_transferar.Rows[0]["EmailID"].ToString();
                    lblTransferarAddress.Text          = dt_transferar.Rows[0]["Address"].ToString();
                    lblTransferarPhoneNo.Text          = dt_transferar.Rows[0]["PhoneNo"].ToString();
                    lbl_TransfrerFirm.Text             = dt_transferar.Rows[0]["CompanyType"].ToString();
                    string Imagetype                   = dt_transferar.Rows[0]["AllotteeImageType"].ToString().Trim();
                    string ImageName                   = dt_transferar.Rows[0]["AllotteeImageName"].ToString().Trim();
                    string img                         = dt_transferar.Rows[0]["AllotteeImage"].ToString();
                    string signimg                     = dt_transferar.Rows[0]["AllotteeSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt_transferar.Rows[0]["AllotteeImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageSrc1.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }
                    if (signimg.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt_transferar.Rows[0]["AllotteeSign"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Img2.Src = Page.ResolveUrl("data:" + Imagetype + ";base64," + base64String);


                    }



                    if (dt_transferar.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                        {

                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt_transferar_Firm.Rows)
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

                        if (dt_transferar.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                        {

                            Headerlbl.Text = "Directors Details";

                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Din/Pan</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt_transferar_Firm.Rows)
                            {
                                i++;
                                html += "<tr><td>" + i.ToString() + "</td><td>" + dr["ApplicantName"].ToString() + "</td><td>" + dr["DIN_PAN"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Phone"] + "</td><td>" + dr["Email"] + "</td></tr>";
                            }

                            PHH2.Controls.Clear();
                            html += "</table>";
                            Literal loLit = new Literal();
                            loLit.Text = (html);
                            PHH2.Controls.Add(loLit);
                        }

                        if (dt_transferar.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                        {

                            Headerlbl.Text = "ShareHolders Details";


                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Shares (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt_transferar_Firm.Rows)
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

                        if (dt_transferar.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                        {

                            Headerlbl.Text = "Partners Details";
                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Partnership (In %)</th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt_transferar_Firm.Rows)
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

                        if (dt_transferar.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                        {

                            Headerlbl.Text = "Trustee Details";


                            html = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th> Name </th><th>Address</th><th>Phone No</th><th>Email Id</th></tr>";
                            foreach (DataRow dr in dt_transferar_Firm.Rows)
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

                    
                }

                if (dt_transferar_Doc.Rows.Count > 0)
                {

                    html1 = @"<table Class='table table-hover table-bordered request-table' style='width:100%;'>
                                <tr><th> S.NO </th><th>CheckList </th><th>Checklist Description</th><th>Document uploaded</th></tr>";
                    foreach (DataRow dr in dt_transferar_Doc.Rows)
                    {
                        j++;
                        html1 += "<tr><td>" + j.ToString() + "</td><td>" + dr["ServiceTimeLinesCondition"].ToString() + "</td><td>" + dr["ServiceTimeLinesDocuments"] + "</td><td>" + dr["Name"] + "</td></tr>";
                    }

                    PHH21.Controls.Clear();
                    html1 += "</table>";
                    Literal loLit1 = new Literal();
                    loLit1.Text = (html1);
                    PHH21.Controls.Add(loLit1);
                }

                if(dtAck.Rows.Count>0)
                {
                    string TLExemptionCase = dtAck.Rows[0]["TLCaseType"].ToString();
                    string UP2 = dtAck.Rows[0]["UnitUProductionMoreThanTwoYear"].ToString();
                    string SubDate = dtAck.Rows[0]["SubDivisionDate"].ToString();
                    string DeathDate = dtAck.Rows[0]["DeathDate"].ToString();

                    if (TLExemptionCase == "1")
                    {
                        DeathDetailsDiv.Visible = true;
                        SubdivisionDiv.Visible = false;
                        AckDiv.Visible = false;


                    }
                    if (TLExemptionCase == "2")
                    {
                        DeathDetailsDiv.Visible = false;
                        SubdivisionDiv.Visible = true;
                        AckDiv.Visible = false;
                    }
                    if (TLExemptionCase == "3")
                    {
                        DeathDetailsDiv.Visible = false;
                        SubdivisionDiv.Visible = false;
                        AckDiv.Visible = true;
                    }

                    if (UP2 == "Yes")
                    {
                        ProRataDiv.Visible = true;
                       
                    }
                    else
                    {
                        ProRataDiv.Visible = false;
                        
                    }
                    drp_TransferApplicableCase.Text = dtAck.Rows[0]["TLCaseTypeName"].ToString();
                    lblCoveredAreaT.Text = dtAck.Rows[0]["CoveredAreaCurrent"].ToString();
                    lblUnitUnderProductionMoreThan2.Text = dtAck.Rows[0]["UnitUProductionMoreThanTwoYear"].ToString();
                    lblLevyType.Text = dtAck.Rows[0]["Levy"].ToString();
                    lblDateofDeath.Text = DeathDate.Trim();
                    lblSubdivisionDate.Text = SubDate.Trim();
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

                if (TranID == "" || TranID == null)
                {

                }
                else
                {
                    Pay_Ds = objServiceTimelinesBLL.GetPaymentDetailTransactionWise(objServiceTimelinesBEL);
                    Paymentdt = Pay_Ds.Tables[0];
                }

                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                dsR = objServiceTimelinesBLL.GetapplicableChargesforTransferPlotAmount(objServiceTimelinesBEL);


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
                    subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));


                    TotalCharges = subTotalApplicableFees + subTotalDeposits;

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
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + lblIA.Text + @"</td></tr>
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
                        htmldata += @"
                               <tr><td colspan=""3"">" + "B. Deposits" + @"</td></tr>";
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
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
            decimal subTotalDeposits = 0;
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


               

                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                if (Paymentdt.Rows.Count > 0)
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTransferPlotNMSWPPaid(objServiceTimelinesBEL);

                    if (TLExemption == "True")
                    {
                        htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""100%"" style=""Font-Size:12px;"">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'>" + ServiceRequestNo + @"</td>
                                     <th style='background:#f7f7f7;'>NM Unit ID" + "" + "</th><td class='text-left'>" + ControlID + @"</td></tr></tr>
                                     <tr><th style='background:#f7f7f7;'>Transfer Levy </th><td class='text-left'>Exempted</td>
                                     <th style='background:#f7f7f7;'>Applicable Case Type </th><td class='text-left'>" + TLExemptionCase+@"</td></tr>                                    
                                     <tr> <th>Applied in the name of " + "" + "</th><td class='text-left'>" + lblName.Text + @"</td>
                                     <th style='background:#f7f7f7;'> Address " + "" + "</th><td class='text-left'>" + lblAddress.Text + @"</td></tr>
                                     <tr> <th> Payment Mode " + "" + "</th><td class='text-left'>" + PayMode + @"</td>
                                     <th style='background:#f7f7f7;'> Transaction Ref No " + "" + "</th><td class='text-left'>" + TranRefNo + @"</td></tr>
                                     <tr> <th> Payment Received Date " + "" + "</th><td class='text-left'>" + TranDate + @"</td>
                                     <th style='background:#f7f7f7;'> Payment Status " + "" + "</th><td class='text-left'>" + PayStatus + @"</td></tr>
                               </table></div><br/>";
                    }else
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
                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTransferPlotNMSWP(objServiceTimelinesBEL);

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
                        if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }
                        // if (dschoicearea.Tables[2].Rows.Count > 0) { Getdata3 = dschoicearea.Tables[2]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                        TotalCharges = subTotalApplicableFees + subTotalDeposits;
                        //industrialarea = IndustrialArea;
                        plotsize = lblPlotArea.Text + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = lblPlotArea.Text + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/><br/>
                                 
                                   <div class='row'> <table class=""table table-bordered table-hover request-table"">
                                        <tbody>
                                        <tr style = 'background:#f7f7f7;'>
                                            <td colspan=""2"" style='text-align:center'>  —————— ✂ Option : Based on Entered Plot Size  ✂ ——————  </td>
                                        </tr>
                                        </tbody>
                                       </table>
                                    </div>
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";



                                htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                    <tr style='background:#f7f7f7;'> <th>Required Plot Size " + "" + "</th><th class='text-left'>" + plotsize + @"</th></tr>


                               </table></div>";


                                htmldata += @"
                                    <div class='col- md-6'><table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">                                 
                                    <tr style = 'background:#f7f7f7;'>
                                    <th> A. Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";

                                htmldata += @"
                                    <tr style = 'background:#f7f7f7;'> <th> B. Applicable Deposits" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";

                                htmldata += @"

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges(A+B) " + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + TotalCharges + @"</th>
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
                              <tr><td colspan=""2"" class='text-center'> Sub Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</td></tr>";


                                //Building the Data rows for deposits.

                                htmldata += @"
                               <tr><td colspan=""3"">" + "B. Deposits" + @"</td></tr>";
                                foreach (DataRow row in Getdata2.Rows)
                                {
                                    htmldata += @"<tr> ";
                                    foreach (DataColumn column in Getdata2.Columns)
                                    {
                                        htmldata += @"<td> ";
                                        htmldata += @row[column.ColumnName];
                                        // html.Append(row[column.ColumnName]);
                                        htmldata += @"</td> ";
                                    }
                                    htmldata += @"</tr> ";
                                }
                                htmldata += @"
                              <tr><td colspan=""2"" class='text-center'> Sub Total Deposits</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</td></tr>";



                                htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable ( A+B)</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";




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
    }
}