using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace Allotment
{
    public partial class UC_IAServiceProcessFeeNMSWP : System.Web.UI.UserControl
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
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

        public int IndustrialArea { get; set; }
        public string IAName { get; set; }
        public string RefNo { get; set; }
        public double choicearea { get; set; }
        public string CoveredArea { get; set; }
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
        public string ServiceRequestNo { get; set; }
       
        public string ApplicationStatus { get; set; }
        public string PlotNo { get; set; }
        public decimal PlotArea { get; set; }




        protected void Page_Load(object sender, EventArgs e)
        {
           string[] SerIdarray = ServiceRequestNo.Split('/');
           string TypeID = SerIdarray[1].ToString();
            if (TypeID == "4")
            {
                BindApplicableFeesTransfer();
            }
            else if (TypeID == "1008")
            {
                BindApplicableFeesReconstitution();
            }
            else if (TypeID == "1021")
            {
                BindApplicableFeesRecognition();
            }
            else if (TypeID == "1029")
            {
               // BindApplicableFeesS();
                BindApplicableFees123();
                //BindApplicableFeesAmalgamation();
            }
            else
            {
                BindApplicableFees();
            }
           
            
        }

        public void BindApplicableFees123()
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
            decimal subTotalApplicableFees1 = 0;
            decimal subTotalDeposits = 0;
            decimal subTotalDues = 0;
            decimal TotalCharges = 0;
            decimal TotalCharges1 = 0;
            decimal AmountPaid = 0;

            string appliedthrough = string.Empty;
            string industrialarea = string.Empty;
            string plotsize = string.Empty;
            string plotno = string.Empty;
            string PayMode = string.Empty;
            string TranRefNo = string.Empty;
            string TranDate = string.Empty;
            string PayStatus = string.Empty;

            try
            {
                GeneralMethod gm = new GeneralMethod();

                objServiceTimelinesBEL.industrialAreaID = IndustrialArea;
                objServiceTimelinesBEL.choicearea = choicearea;
                objServiceTimelinesBEL.choiceP1 = choiceP1;
                objServiceTimelinesBEL.choiceP2 = choiceP2;
                objServiceTimelinesBEL.choiceP3 = choiceP3;
                objServiceTimelinesBEL.choiceareap1 = choiceareap1;
                objServiceTimelinesBEL.choiceareap2 = choiceareap2;
                objServiceTimelinesBEL.choiceareap3 = choiceareap3;
                objServiceTimelinesBEL.companyName = companyName;
                objServiceTimelinesBEL.swcApplicantName = ApplicantName;
                objServiceTimelinesBEL.applicantAddress = applicantAddress;
                objServiceTimelinesBEL.SWCControlID = SWCControlID;
                objServiceTimelinesBEL.SWCUnitID = SWCUnitID;
                objServiceTimelinesBEL.SWCServiceID = SWCServiceID;
                objServiceTimelinesBEL.TranID = TranID;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
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

                DataTable dtAmalgamatedPlotDetail = getAmalgamatedPlotDetail(ServiceRequestNo);
                if (dtAmalgamatedPlotDetail.Rows.Count > 0)
                {
                    plotsize = dtAmalgamatedPlotDetail.Rows[0]["PlotSize"].ToString().Trim();
                    plotno = dtAmalgamatedPlotDetail.Rows[0]["PlotNo"].ToString().Trim();
                }


                if (choicearea > 0)
                {
                    objServiceTimelinesBEL.choicearea = choicearea;
                    objServiceTimelinesBEL.CoveredArea = CoveredArea;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetApplicableChargesIAServices(objServiceTimelinesBEL);


                    string report_date = date_today.ToString("MMMM d, yyyy");
                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";

                    if (Paymentdt.Rows.Count > 0)
                    {
                        htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + SWCControlID + @"</th></tr>
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + IAName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Payment Mode " + "" + "</th><th class='text-left'>" + PayMode + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Transaction Ref No " + "" + "</th><th class='text-left'>" + TranRefNo + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Transaction Date " + "" + "</th><th class='text-left'>" + TranDate + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Payment Status " + "" + "</th><th class='text-left'>" + PayStatus + @"</th></tr>
                               </table></div><br/><br/>";
                    }
                    else
                    {
                        htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + SWCControlID + @"</th></tr>
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                               </table></div><br/><br/>";
                    }
                    // for Option 1 : Based on Selected Plot Area              
                    if (dschoicearea.Tables.Count > 0)
                    {
                        if (dschoicearea.Tables[1].Rows.Count > 0)
                        {
                            if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[1]; }
                            if (dschoicearea.Tables[2].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[2]; }
                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            //plotsize = choicearea + " SQmts.";



                            if (Getdata1.Rows.Count > 0)
                            {

                                subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                                // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                                //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                                TotalCharges = subTotalApplicableFees;
                                industrialarea = Convert.ToString(industrialarea);
                                //plotsize = choicearea + " SQmts.";

                                htmldata += @"<br/><br/>";

                                if (Getdata1.Rows.Count > 0)
                                {

                                    htmldata += @"<br/><br/>
                                 
                                   <div class='row'> <table class=""table table-bordered table-hover request-table"">
                                        <tbody>
                                        <tr style = 'background:#f7f7f7;'>
                                            <td colspan=""2"" style='text-align:center'>  —————— ✂ Option : Payment To Be Made in UPSIDA Portal  ✂ ——————  </td>
                                        </tr>
                                        </tbody>
                                       </table>
                                    </div>
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";



                                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                    <tr style='background:#f7f7f7;'> <th>Plot No " + "" + "</th><th class='text-left'>" + plotno + @" </th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Plot Area " + "" + "</th><th class='text-left'>" + plotsize + @" SQmts</th></tr>
                                    


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
                               <tr><td colspan=""3"">" + "A. Applicable Fees In UPSIDA" + @"</td></tr>";

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
                            if (Getdata2.Rows.Count > 0)
                            {

                                subTotalApplicableFees1 = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                                TotalCharges1 = subTotalApplicableFees1;
                                industrialarea = Convert.ToString(industrialarea);
                                plotsize = choicearea + " SQmts.";

                                htmldata += @"<br/><br/>";

                                if (Getdata2.Rows.Count > 0)
                                {

                                    htmldata += @"<br/><br/>
                                 
                                   <div class='row'> <table class=""table table-bordered table-hover request-table"">
                                        <tbody>
                                        <tr style = 'background:#f7f7f7;'>
                                            <td colspan=""2"" style='text-align:center'>  —————— ✂ Option : Payment To Be Made In Nivesh Mitra Portal  ✂ ——————  </td>
                                        </tr>
                                        </tbody>
                                       </table>
                                    </div>
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";




                                    htmldata += @"
                        <div class='col- md-6'><table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">                                 
                                    <tr style = 'background:#f7f7f7;'>
                                    <th>Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalApplicableFees1 + @"</th></tr>";

                                    // htmldata += @"
                                    //<tr style = 'background:#f7f7f7;'> <th> B. Applicable Deposits" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";

                                    htmldata += @"

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges " + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + TotalCharges1 + @"</th>
                                    </tr>
                                </table></div><br /><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                                    htmldata += @"
                               <tr><td colspan=""3"">" + "A. Applicable Fees In Nivesh Mitra" + @"</td></tr>";

                                    //Building the Data rows for Applicable fees.
                                    foreach (DataRow row in Getdata2.Rows)
                                    {
                                        htmldata += @" <tr> ";
                                        foreach (DataColumn column in Getdata2.Columns)
                                        {
                                            htmldata += @"<td class='text-center'> ";
                                            htmldata += @row[column.ColumnName];

                                            htmldata += @"</td> ";
                                        }
                                        htmldata += @"</tr> ";
                                    }

                                    htmldata += @"
                              <tr><td colspan=""2"" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees1 + @"</td></tr>";



                                    htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges1 + @"</th></tr>";



                                    htmldata += " </table>";

                                }

                            }

                        }
                    }

                }

                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                ph.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                //Response.Write("Oops! error occured :" + ex.Message.ToString());
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }
        }

        public void BindApplicableFeesS()
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
                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }



                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                        TotalCharges = subTotalApplicableFees;
                        //industrialarea = IndustrialArea;
                        plotsize = choicearea + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/>
                                 
                                  
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";



                                htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
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
                ph.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        public void BindApplicableFeesAmalgamation()
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
            //string PlotArea = string.Empty;

            try
            {
                GeneralMethod gm = new GeneralMethod();

                objServiceTimelinesBEL.industrialAreaID = IndustrialArea;
                objServiceTimelinesBEL.choicearea = choicearea;
                objServiceTimelinesBEL.choiceP1 = choiceP1;
                objServiceTimelinesBEL.choiceP2 = choiceP2;
                objServiceTimelinesBEL.choiceP3 = choiceP3;
                objServiceTimelinesBEL.choiceareap1 = choiceareap1;
                objServiceTimelinesBEL.choiceareap2 = choiceareap2;
                objServiceTimelinesBEL.choiceareap3 = choiceareap3;
                objServiceTimelinesBEL.companyName = companyName;
                objServiceTimelinesBEL.swcApplicantName = ApplicantName;
                objServiceTimelinesBEL.applicantAddress = applicantAddress;
                objServiceTimelinesBEL.SWCControlID = SWCControlID;
                objServiceTimelinesBEL.SWCUnitID = SWCUnitID;
                objServiceTimelinesBEL.SWCServiceID = SWCServiceID;
                objServiceTimelinesBEL.TranID = TranID;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;

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



                if (PlotArea > 0)
                {
                    objServiceTimelinesBEL.plotSize = PlotArea.ToString();
                    //objServiceTimelinesBEL.CoveredArea = CoveredArea.ToString();
                   // objServiceTimelinesBEL.CoveredArea = CoveredArea.ToString();
                    dschoicearea = objServiceTimelinesBLL.GetProcessingForNiveshMitraBuildingPlan(objServiceTimelinesBEL);


                    string report_date = date_today.ToString("MMMM d, yyyy");
                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                    if (Paymentdt.Rows.Count > 0)
                    {
                        htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + SWCControlID + @"</th></tr>
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + IAName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Payment Mode " + "" + "</th><th class='text-left'>" + PayMode + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Transaction Ref No " + "" + "</th><th class='text-left'>" + TranRefNo + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Transaction Date " + "" + "</th><th class='text-left'>" + TranDate + @"</th></tr>
<tr style='background:#f7f7f7;'> <th> Payment Status " + "" + "</th><th class='text-left'>" + PayStatus + @"</th></tr>
                               </table></div><br/><br/>";
                    }
                    else
                    {
                        htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + SWCControlID + @"</th></tr>
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                               </table></div><br/><br/>";
                    }
                    // for Option 1 : Based on Selected Plot Area              
                    if (dschoicearea.Tables.Count > 0)
                    {

                        if (dschoicearea.Tables[0].Rows.Count > 0)
                        {
                            if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }



                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            //industrialarea = IndustrialArea;
                            plotsize = choicearea + " SQmts.";



                            if (Getdata1.Rows.Count > 0)
                            {

                                subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                                // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                                //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                                TotalCharges = subTotalApplicableFees;
                                industrialarea = Convert.ToString(industrialarea);
                                plotsize = choicearea + " SQmts.";

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
                                    <tr style='background:#f7f7f7;'> <th>Plot Area " + "" + "</th><th class='text-left'>" + PlotArea + @" SqrMts</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Builtup/Covered Area " + "" + "</th><th class='text-left'>" + CoveredArea + @" SqrMts</th></tr>


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


                                    //Building the Data rows for deposits.

                                    //      htmldata += @"
                                    // <tr><td colspan=""3"">" + "B. Deposits" + @"</td></tr>";
                                    //      foreach (DataRow row in Getdata2.Rows)
                                    //      {
                                    //          htmldata += @"<tr> ";
                                    //          foreach (DataColumn column in Getdata2.Columns)
                                    //          {
                                    //              htmldata += @"<td> ";
                                    //              htmldata += @row[column.ColumnName];
                                    //              // html.Append(row[column.ColumnName]);
                                    //              htmldata += @"</td> ";
                                    //          }
                                    //          htmldata += @"</tr> ";
                                    //      }
                                    //      htmldata += @"
                                    //<tr><td colspan=""2"" class='text-center'> Sub Total Deposits</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</td></tr>";



                                    htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";


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

                }
                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                ph.Controls.Add(loLit);
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
            string PayMode = string.Empty;
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
                    PayMode   = "Nivesh Mitra Payment Gateway";
                    TranRefNo = Paymentdt.Rows[0]["Transaction_ID"].ToString();
                    TranDate  = Paymentdt.Rows[0]["Transaction_Date"].ToString(); 
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
                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        
                        TotalCharges = subTotalApplicableFees;
                        plotsize = choicearea + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = subTotalApplicableFees;
                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/>
                                 
                                  
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";



                                htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                    <tr style='background:#f7f7f7;'> <th>Plot No " + "" + "</th><th class='text-left'>" + PlotNo + @"</th></tr>
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
                ph.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        public void BindApplicableFeesTransfer()
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
                    

                    
                    htmldata += @"
                                     <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                     <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Mode " + "" + "</th><th class='text-left'>" + PayMode + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Ref No " + "" + "</th><th class='text-left'>" + TranRefNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Date " + "" + "</th><th class='text-left'>" + TranDate + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Status " + "" + "</th><th class='text-left'>" + PayStatus + @"</th></tr>
                                     </table></div><br/><br/>";
                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTransferPlotNMSWP(objServiceTimelinesBEL);

                    htmldata += @"
                                       <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                       <tr style='background:#f7f7f7;'> 
                                       <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                       </table></div><br/><br/>";
                }

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
                        plotsize = choicearea + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

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
                ph.Controls.Add(loLit);


            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Response.Write("Oops! error occured :" + line.ToString());
            }
        }

        public void BindApplicableFeesReconstitution()
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
                dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforReconstitutionNMSWP(objServiceTimelinesBEL);




                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                if (Paymentdt.Rows.Count > 0)
                {
                    htmldata += @"
                                     <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                     <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Mode " + "" + "</th><th class='text-left'>" + PayMode + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Ref No " + "" + "</th><th class='text-left'>" + TranRefNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Date " + "" + "</th><th class='text-left'>" + TranDate + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Status " + "" + "</th><th class='text-left'>" + PayStatus + @"</th></tr>
                                     </table></div><br/><br/>";
                }
                else
                {
                    htmldata += @"
                                       <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                       <tr style='background:#f7f7f7;'> 
                                       <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                       </table></div><br/><br/>";
                }

                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        //if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }
                        // if (dschoicearea.Tables[2].Rows.Count > 0) { Getdata3 = dschoicearea.Tables[2]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                        // TotalCharges = subTotalApplicableFees + subTotalDeposits;
                        TotalCharges = subTotalApplicableFees;
                        //industrialarea = IndustrialArea;
                        plotsize = choicearea + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/><br/>
                                 
                                   <div class='row'> <table class=""table table-bordered table-hover request-table"">
                                        <tbody>
                                        <tr style = 'background:#f7f7f7;'>
                                            <td colspan=""2"" style='text-align:center'>  —————— ? Option : Based on Entered Plot Size  ? ——————  </td>
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
                              <tr><th colspan=""2"" class='text-center'> Total Payable ( A+B)</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";




                                htmldata += " </table>";

                            }

                        }

                    }
                }


                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                ph.Controls.Add(loLit);


            }
            catch (Exception ex)
            {
                //var st = new StackTrace(ex, true);
                // Get the top stack frame
                // var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                // var line = frame.GetFileLineNumber();
                // Response.Write("Oops! error occured :" + line.ToString());
            }
        }

        public void BindApplicableFeesRecognition()
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
                dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforRecognitionNMSWP(objServiceTimelinesBEL);




                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";



                if (Paymentdt.Rows.Count > 0)
                {
                    htmldata += @"
                                     <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                     <tr style='background:#f7f7f7;'> 
                                     <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Mode " + "" + "</th><th class='text-left'>" + PayMode + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Ref No " + "" + "</th><th class='text-left'>" + TranRefNo + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Transaction Date " + "" + "</th><th class='text-left'>" + TranDate + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Payment Status " + "" + "</th><th class='text-left'>" + PayStatus + @"</th></tr>
                                     </table></div><br/><br/>";
                }
                else
                {
                    htmldata += @"
                                       <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                       <tr style='background:#f7f7f7;'> 
                                       <th>Application Reference Number</th><th class='text-left'>" + ServiceRequestNo + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                       <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                                       </table></div><br/><br/>";
                }

                if (dschoicearea.Tables.Count > 0)
                {

                    if (dschoicearea.Tables[0].Rows.Count > 0)
                    {
                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        //if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }
                        // if (dschoicearea.Tables[2].Rows.Count > 0) { Getdata3 = dschoicearea.Tables[2]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                        //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                        // TotalCharges = subTotalApplicableFees + subTotalDeposits;
                        TotalCharges = subTotalApplicableFees;
                        //industrialarea = IndustrialArea;
                        plotsize = choicearea + " SQmts.";



                        if (Getdata1.Rows.Count > 0)
                        {

                            subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                            industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

                            htmldata += @"<br/><br/>";

                            if (Getdata1.Rows.Count > 0)
                            {

                                htmldata += @"<br/><br/>
                                 
                                   <div class='row'> <table class=""table table-bordered table-hover request-table"">
                                        <tbody>
                                        <tr style = 'background:#f7f7f7;'>
                                            <td colspan=""2"" style='text-align:center'>  —————— ? Option : Based on Entered Plot Size  ? ——————  </td>
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
                              <tr><th colspan=""2"" class='text-center'> Total Payable ( A+B)</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";




                                htmldata += " </table>";

                            }

                        }

                    }
                }


                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                ph.Controls.Add(loLit);


            }
            catch (Exception ex)
            {
                //var st = new StackTrace(ex, true);
                // Get the top stack frame
                // var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                // var line = frame.GetFileLineNumber();
                // Response.Write("Oops! error occured :" + line.ToString());
            }
        }
        protected DataTable getAmalgamatedPlotDetail(string SerNo)
        {
            DataTable dt = new DataTable();
            try { 
            
            SqlConnection con =new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from tbl_ApplicationRegisterAmalgamationSubdivisionPostAllotment where ApplicationID='" + SerNo + "'",con);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            dp.Fill(dt);
            }
            catch
            {

            }
            return dt;
        }
    }
}