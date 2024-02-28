using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationFinalViewTimeextensionService : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        //public int TEFTimeperiod { get; set; }
        public decimal PlotSize { get; set; }
        //public int AllotteeID { get; set; }
        public int IndustrialArea { get; set; }



        public string IAName { get; set; }
        public string RefNo { get; set; }
        public double choicearea { get; set; }
        public double choiceareap1 { get; set; }
        public double choiceareap2 { get; set; }
        public double choiceareap3 { get; set; }
        public string choiceP1 { get; set; }
        public string choiceP2 { get; set; }
        public string choiceP3 { get; set; }
        public string companyName { get; set; }
        public string ApplicantName { get; set; }
        public string applicantAddress { get; set; }
        public string SWCControlID { get; set; }
        public string SWCUnitID { get; set; }
        public string SWCServiceID { get; set; }
        public string SWCStatus { get; set; }
        public string SWCPayMode { get; set; }
        public string TranID { get; set; }
        public string AllotmentLetterNo { get; set; }
        public double PlotArea { get; set; }
        public string ServiceRequestNO { get; set; }
        public string ServiceRequestNo { get; internal set; }

        #endregion
        DataTable Paymentdt1 = new DataTable();
        GeneralMethod gm = new GeneralMethod();
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

            DataTable NMSWP = gm.GetNMSWPIDNews(ServiceRequestNo);
            SWCControlID = NMSWP.Rows[0][0].ToString();
            SWCUnitID    = NMSWP.Rows[0][1].ToString();
            SWCServiceID = NMSWP.Rows[0][2].ToString();
            GetApplicantDetails(ServiceRequestNo);

            if (SWCControlID.Length > 0)
            {
                BindApplicableFeesNMSWP(ServiceRequestNo);
            }
            else
            {
                BindApplicableFees();
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
                ds = objServiceTimelinesBLL.GetAllotteeDetailsIATimeextensionService(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_timeextensionfee = ds.Tables[2];
                DataTable dt_doc = ds.Tables[3];
                DataTable dt_dues = ds.Tables[4];
                DataTable dt_objection = ds.Tables[5];
                DataTable dt_applicanttef = ds.Tables[6];
                DataTable dt_allotteetef = ds.Tables[7];
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

                    if (dt_applicanttef.Rows.Count > 0)
                    {

                        TEFViewDetails.DataSource = dt_applicanttef;
                        TEFViewDetails.DataBind();
                    }
                    if (dt_allotteetef.Rows.Count > 0)
                    {
                        ApplicantTEFDetails.DataSource = dt_allotteetef;
                        ApplicantTEFDetails.DataBind();
                    }


                }
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    lbltefperiod.Text = dt_timeextensionfee.Rows[0]["TEFTimeperiod"].ToString();
                    string str = dt_timeextensionfee.Rows[0]["description"].ToString();
                    lblApplicationDetails.Text = Server.HtmlDecode(str);
                    lblCovid19.Text = dt_timeextensionfee.Rows[0]["freetimeextension"].ToString();
                    lblapplicableonAllotmentletter.Text = dt_timeextensionfee.Rows[0]["applicableonAllotmentletter"].ToString();
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

        public void BindApplicableFees()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet dsTEF = new DataSet();
            DataSet dschoicearea = new DataSet();
            DataSet dschoiceP1 = new DataSet();
            DataSet dschoiceP2 = new DataSet();
            DataSet dschoiceP3 = new DataSet();
            DataSet Pay_Ds = new DataSet();
            DataTable Paymentdt = new DataTable();
            string htmldata = "";
            DateTime date_today = DateTime.Now;
            decimal subTotalApplicableFees = 0;
            decimal subTotalDeposits = 0;
            decimal subTotalDues = 0;
            decimal TotalCharges = 0;
            decimal AmountPaid = 0;

            string appliedthrough = string.Empty;
            string industrialarea = string.Empty;
            string plotsize = string.Empty;
            string PayMode = string.Empty;
            string TranRefNo = string.Empty;
            string TranDate = string.Empty;
            string PayStatus = string.Empty;

            try
            {
                GeneralMethod gm = new GeneralMethod();
                objServiceTimelinesBEL.industrialAreaID = IndustrialArea;
                //objServiceTimelinesBEL.TEFTimeperiod = TEFTimeperiod;
                //objServiceTimelinesBEL.AllotteeID = AllotteeID;
                objServiceTimelinesBEL.PlotArea = (PlotSize);
                objServiceTimelinesBEL.companyName = companyName;
                objServiceTimelinesBEL.swcApplicantName = ApplicantName;
                objServiceTimelinesBEL.applicantAddress = applicantAddress;
                objServiceTimelinesBEL.SWCControlID = SWCControlID;
                objServiceTimelinesBEL.SWCUnitID = SWCUnitID;
                objServiceTimelinesBEL.SWCServiceID = SWCServiceID;
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
                //dsTEF = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);
                //dsTEF = objServiceTimelinesBLL.GetApplicableChargesIAServicesView(objServiceTimelinesBEL);


                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";

                if (Paymentdt.Rows.Count > 0)
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dsTEF = objServiceTimelinesBLL.GetapplicableChargesforTimeExtenstionView(objServiceTimelinesBEL);
                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""100%"" style=""Font-Size:12px;"">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'>" + ServiceRequestNo + @"</td>
                                     <th style='background:#f7f7f7;'>Industrial Area " + "" + "</th><td class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</td></tr>
                                     <tr> <th>Applied in the name of " + "" + "</th><td class='text-left'>" + ApplicantName + @"</td>
                                     <th style='background:#f7f7f7;'> Address " + "" + "</th><td class='text-left'>" + applicantAddress + @"</td></tr>
                                     <tr> <th> Payment Mode " + "" + "</th><td class='text-left'>" + PayMode + @"</td>
                                     <th style='background:#f7f7f7;'> Transaction Ref No " + "" + "</th><td class='text-left'>" + TranRefNo + @"</td></tr>
                                     <tr> <th> Payment Received Date " + "" + "</th><td class='text-left'>" + TranDate + @"</td>
                                     <th style='background:#f7f7f7;'> Payment Status " + "" + "</th><td class='text-left'>" + PayStatus + @"</td></tr>
                               </table></div><br/>";
                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dsTEF = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);
                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                               </table></div>";
                }
                // for Option 1 : Based on Selected Plot Area              
                if (dsTEF.Tables.Count > 0)
                {

                    if (dsTEF.Tables[0].Rows.Count > 0)
                    {
                        if (dsTEF.Tables[0].Rows.Count > 0) { Getdata1 = dsTEF.Tables[0]; }
                        //if (dsTEF.Tables[1].Rows.Count > 0) { Getdata2 = dsTEF.Tables[1]; }
                        // if (dsTEF.Tables[2].Rows.Count > 0) { Getdata3 = dsTEF.Tables[2]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                        TotalCharges = subTotalApplicableFees ;
                        //industrialarea = IndustrialArea;
                        plotsize = PlotSize + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees + subTotalDeposits;
                            industrialarea = Convert.ToString(industrialarea);
                            //plotsize = choicearea + " SQmts.";

                            htmldata += @"";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"
                                 
                        <table class=""table table-bordered table-hover request-table"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                                htmldata += @"
                               <tr><td colspan=""3"">" + "A. Time Extension Fees" + @"</td></tr>";

                                //Building the Data rows for Applicable fees.
                                foreach (DataRow row in Getdata1.Rows)
                                {
                                    htmldata += @" <tr> ";
                                    htmldata += @"<td class='text-center'>" + @row["sno"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["paydescription"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["applicablecharge"].ToString() + @"</td>";

                                    htmldata += @"</tr> ";
                                }

                              //  htmldata += @"
                              //<tr><td colspan=""2"" class='text-center'> Sub Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</td></tr>";


                                //Building the Data rows for deposits.

                              //  htmldata += @"
                              // <tr><td colspan=""3"">" + "B. Deposits" + @"</td></tr>";
                              //  foreach (DataRow row in Getdata2.Rows)
                              //  {
                              //      htmldata += @"<tr> ";
                              //      foreach (DataColumn column in Getdata2.Columns)
                              //      {
                              //          htmldata += @"<td> ";
                              //          htmldata += @row[column.ColumnName];
                              //          htmldata += @"</td> ";
                              //      }
                              //      htmldata += @"</tr> ";
                              //  }
                              //  htmldata += @"
                              //<tr><td colspan=""2"" class='text-center'> Sub Total Deposits</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</td></tr>";



                                htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable </th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";


                                //Building the Data rows for deposits.
                                //htmldata += @"
                                //       <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";

                                //Table end.
                                //
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


                //objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                //dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);


                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                if (Paymentdt.Rows.Count > 0)
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTimeExtenstionNMSWPPaid(objServiceTimelinesBEL);
                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""100%"" style=""Font-Size:12px;"">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'>" + ServiceRequestNo + @"</td>
                                     <th style='background:#f7f7f7;'>NM Unit ID" + "" + "</th><td class='text-left'>" + SWCControlID + @"</td></tr>
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
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);
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


        //public void BindApplicableFees(string serviceNO)
        //{
        //    belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        //    //conenction path for database
        //    //int Parameter = Int32.Parse();
        //    DataSet dsR = new DataSet();
        //    DataSet dsoper = new DataSet();
        //    DataSet dst = new DataSet();
        //    DataSet Pay_Ds = new DataSet();
        //    try
        //    {
        //        DataTable dt_Fee = new DataTable();
        //        DataTable dt_Fee_other = new DataTable();
        //        DataTable Paymentdt = new DataTable();
        //        objServiceTimelinesBEL.industrialAreaID = IndustrialArea;
        //        objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
        //        objServiceTimelinesBEL.TranID = TranID;

        //        if (TranID == "" || TranID == null)
        //        {

        //        }
        //        else
        //        {
        //            Pay_Ds = objServiceTimelinesBLL.GetPaymentDetailTransactionWise(objServiceTimelinesBEL);
        //            Paymentdt = Pay_Ds.Tables[0];
        //        }

        //        objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
        //        dsR = objServiceTimelinesBLL.GetPaymentDetailTransactionWiseTEF(objServiceTimelinesBEL);




        //        string htmldata = "";
        //        DateTime date_today = DateTime.Now;
        //        decimal subTotalApplicableFees = 0;
        //        decimal subTotalDeposits = 0;
        //        decimal subTotalDues = 0;
        //        decimal TotalCharges = 0;
        //        string Applicantname = string.Empty;
        //        string appliedthrough = string.Empty;
        //        string industrialarea = string.Empty;
        //        string plotsize = string.Empty;
        //        string PayMode = string.Empty;
        //        string TranRefNo = string.Empty;
        //        string TranDate = string.Empty;
        //        string PayStatus = string.Empty;
        //        string[] tokens = ServiceRequestNo.Split('/');
        //        string Serviceid = tokens[1].ToString();
        //        string SWCControlID = String.Empty;
        //        string SWCUnitID = String.Empty;
        //        string SWCServiceID = String.Empty;
        //        string SWCStatus = String.Empty;
        //        string SWCPayMode = String.Empty;
        //        string SWCPassSalt = System.Configuration.ConfigurationManager.AppSettings["passsalt"];

        //        if (dsR.Tables[0].Rows.Count > 0)
        //        {
        //            Getdata1 = dsR.Tables[0];
        //        }
        //        if (dsR.Tables[1].Rows.Count > 0)
        //        {
        //            Paymentdt1 = dsR.Tables[1];
        //        }
        //        try { Getdata1 = dt_Fee.Select("type  = 'A'", "sno").CopyToDataTable(); } catch { }
        //        try { Paymentdt1 = dt_Fee.Select("type  = 'B'", "sno").CopyToDataTable(); } catch { }
        //        if (Paymentdt.Rows.Count > 0)
        //        {
        //            PayMode = Paymentdt.Rows[0]["PaymentMode"].ToString();
        //            TranRefNo = Paymentdt.Rows[0]["EazypayRefNo"].ToString();
        //            TranDate = Paymentdt.Rows[0]["TransactionDate"].ToString();
        //            if (Paymentdt.Rows[0]["Paid"].ToString() == "True")
        //            {
        //                PayStatus = "Payment Completed";
        //            }
        //            else
        //            {
        //                PayStatus = "Payment Pending";
        //            }


        //        }


        //        if (Getdata1.Rows.Count > 0)
        //        {

        //            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
        //            subTotalDeposits = Convert.ToDecimal(Paymentdt1.Compute("SUM(applicablecharge)", string.Empty));


        //            TotalCharges = subTotalApplicableFees + subTotalDeposits + subTotalDues;

        //            appliedthrough = "UPSIDC-Internals";
        //            if (Getdata1.Rows.Count > 0)
        //            {


        //                string report_date = date_today.ToString("MMMM d, yyyy");
        //                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";


        //                if (Paymentdt.Rows.Count > 0)
        //                {
        //                    htmldata += @"
        //                      <div class='col- md-6'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
        //                            <tr style='background:#f7f7f7;'> 
        //                            <td>Service Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + lblName.Text + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + lblIAName.Text + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Applied Through" + "" + "</td><td style='text-align:left;'>" + appliedthrough + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Payment Mode" + "" + "</td><td style='text-align:left;'>" + PayMode + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Transaction Ref No" + "" + "</td><td style='text-align:left;'>" + TranRefNo + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Transaction Date" + "" + "</td><td style='text-align:left;'>" + TranDate + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Payment Status" + "" + "</td><td style='text-align:left;'>" + PayStatus + @"</td></tr>

        //                       </table></div>";
        //                }
        //                else
        //                {
        //                    htmldata += @"
        //                      <div class='col- md-6'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
        //                            <tr style='background:#f7f7f7;'> 
        //                            <td>Service Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
        //                           <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + Applicantname + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + industrialarea + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Required Plot Size " + "" + "</td><td style='text-align:left;'>" + plotsize + @"</td></tr>
        //                            <tr style='background:#f7f7f7;'> <td>Applied Through" + "" + "</td><td style='text-align:left;'>" + appliedthrough + @"</td></tr>

        //                       </table></div>";
        //                }



        //                htmldata += @"

        //                         <br /><br/><br/><br/><br/>

        //                <table class=""table table-bordered table-hover request-table"" width=""100%"">

        //                    <tr style = 'background:#f7f7f7;'>
        //                        <th> S.NO </th>
        //                        <th> Description </th>
        //                        <th class=""text-center"">Amount</th>
        //                    </tr>";
        //                htmldata += @"
        //                       <tr><td colspan=""3"">" + "A. Applicable Fees" + @"</td></tr>";



        //                foreach (DataRow row in Getdata1.Rows)
        //                {
        //                    htmldata += @" <tr> ";


        //                    htmldata += @"<td class='text-center'>" + @row["sno"].ToString() + @"</td>
        //                                  <td class='text-center'>" + @row["paydescription"].ToString() + @"</td>
        //                                  <td class='text-center'>" + @row["applicablecharge"].ToString() + @"</td>";

        //                    htmldata += @"</tr> ";
        //                }

        //                htmldata += @"<tr><td colspan=""2"" style='text-align:center;'> Sub Total Applicable Fees</td><td style='text-align:left;'>&#x20B9;" + subTotalApplicableFees + @"</td></tr>";


        //                //Building the Data rows for deposits.
        //                if (Serviceid == "1002")
        //                {
        //                    htmldata += @"
        //                       <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";
        //                    foreach (DataRow row in Paymentdt1.Rows)
        //                    {
        //                        htmldata += @"<tr> ";


        //                        htmldata += @"<td style='text-align:left;'>" + @row["sno"].ToString() + @"</td>
        //                                  <td style='text-align:left;'>" + @row["paydescription"].ToString() + @"</td>
        //                                  <td style='text-align:left;'>" + @row["applicablecharge"].ToString() + @"</td>";

        //                        htmldata += @"</tr> ";
        //                    }
        //                    htmldata += @"
        //                      <tr><td colspan=""2"" style='text-align:center;'> Sub Total Deposits</td><td style='text-align:left;'>&#x20B9;</i>" + subTotalDeposits + @"</td></tr>";

        //                }
        //                else
        //                {

        //                    htmldata += @"
        //                       <tr><th colspan=""3"">" + "B. Dues" + @"</th></tr>";
        //                    //Building the Data rows for dues.
        //                    htmldata += @"
        //                      <tr><th colspan=""2"" class='text-center'> Sub Total Dues</th><th class='text-left'>&#x20B9;</i>" + subTotalDues + @"</th></tr>";

        //                }

        //                htmldata += @"
        //                      <tr><td colspan=""2"" style='text-align:center;'> Total Payable ( A+B)</td><td style='text-align:left;'>&#x20B9;</i>" + TotalCharges + @"</td></tr>";



        //                htmldata += " </table>";

        //                Literal loLit = new Literal();
        //                loLit.Text = (htmldata);
        //                PH3.Controls.Add(loLit);

        //            }


        //        }

        //        // textbox1.text = dsR.Tables[0].Rows[0][0].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}




    }
}