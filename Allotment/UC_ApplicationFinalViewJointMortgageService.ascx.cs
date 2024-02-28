using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewJointMortgageService : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

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

            GetApplicantDetails(ServiceRequestNo);
            if (ControlID.Length > 0)
            {
                Paymentdiv.Visible = false;
            }
            else
            {
                Paymentdiv.Visible = true;
                BindApplicableFees(ServiceRequestNo);
            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

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
                ds = objServiceTimelinesBLL.GetAllotteeDetailsIAJointMortgageService(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_JointMortgage = ds.Tables[2];
                DataTable dt_JointMortgageBankDetails = ds.Tables[3];
                DataTable dt_doc = ds.Tables[4];
                DataTable dt_dues = ds.Tables[5];
                DataTable dt_objection = ds.Tables[6];
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
                if (dt_JointMortgage.Rows.Count > 0)
                {
                    lblPaidoutstanding.Text = dt_JointMortgage.Rows[0]["PaidStatus"].ToString();
                    lblSanctionletternumber.Text = dt_JointMortgage.Rows[0]["Sanctionletterno"].ToString();
                    lblletterDate.Text = dt_JointMortgage.Rows[0]["SanctionletterDate"].ToString();
                    lblAmount.Text = dt_JointMortgage.Rows[0]["Amount"].ToString();
                }
                if (dt_JointMortgageBankDetails.Rows.Count > 0)
                {
                    gridJointMortgage.DataSource = dt_JointMortgageBankDetails;
                    gridJointMortgage.DataBind();

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


                    TotalCharges = subTotalApplicableFees + subTotalDeposits + subTotalDues;

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