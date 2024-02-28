using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PaymentResponse : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();




            if (!IsPostBack)
            {
                //foreach (string key in HttpContext.Current.Request.Form.AllKeys)
                //{
                //    string value = HttpContext.Current.Request.Form[key];

                //    msg.Text = msg.Text + key + "-->" + value + "<br/>";
                //}




                {
                    try
                    {
                        objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC = HttpContext.Current.Request.Form["ReferenceNo"];
                        lblUPSIDCTran.Text = HttpContext.Current.Request.Form["ReferenceNo"];
                    }
                    catch { }
                    objServiceTimelinesBEL.PayTrans_unique_ref = HttpContext.Current.Request.Form["Unique Ref Number"];


                    try
                    {
                        objServiceTimelinesBEL.PayTrans_response_code = HttpContext.Current.Request.Form["Response Code"];
                        lblResponseCode.Text = HttpContext.Current.Request.Form["Response Code"];
                    }
                    catch { }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Service Tax  Amount"]))
                    {
                        objServiceTimelinesBEL.PayTrans_service_tax = HttpContext.Current.Request.Form["Service Tax  Amount"];
                    }



                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Processing  Fee Amount"]))
                    {
                        objServiceTimelinesBEL.PayTrans_processing_fee_amt = HttpContext.Current.Request.Form["Processing  Fee Amount"];
                    }


                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Total Amount"]))
                    {
                        objServiceTimelinesBEL.PayTrans_total_amt = HttpContext.Current.Request.Form["Total Amount"];
                    }


                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Transaction Amount"]))
                    {
                        objServiceTimelinesBEL.PayTrans_trn_amt = HttpContext.Current.Request.Form["Transaction Amount"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Transaction Date"]))
                    {

                        //objServiceTimelinesBEL.PayTrans_trn_date =  Convert.ToDateTime(HttpContext.Current.Request.Form["Transaction Date"]);
                        objServiceTimelinesBEL.PayTrans_trn_date = HttpContext.Current.Request.Form["Transaction Date"];

                        //Response.Write(HttpContext.Current.Request.Form["Transaction Date"]);


                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Interchange Value"]))
                    {
                        objServiceTimelinesBEL.PayTrans_interchange_val = HttpContext.Current.Request.Form["Interchange Value"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["TDR"]))
                    {
                        objServiceTimelinesBEL.PayTrans_tdr = HttpContext.Current.Request.Form["TDR"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Payment Mode"]))
                    {
                        objServiceTimelinesBEL.PaymentMode = HttpContext.Current.Request.Form["Payment Mode"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["SubMer - chantId"]))
                    {
                        objServiceTimelinesBEL.PayTrans_submer = HttpContext.Current.Request.Form["SubMer - chantId"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["Referen - ceNo"]))
                    {
                        objServiceTimelinesBEL.PayTrans_ref_no = HttpContext.Current.Request.Form["Referen - ceNo"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["TPS"]))
                    {
                        objServiceTimelinesBEL.PayTrans_tps = HttpContext.Current.Request.Form["TPS"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["ID"]))
                    {
                        objServiceTimelinesBEL.PayTrans_id = HttpContext.Current.Request.Form["ID"];
                    }

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["RS"]))
                    {
                        objServiceTimelinesBEL.PayTrans_rs = HttpContext.Current.Request.Form["RS"];
                    }

                    string GatewayResponse = "";
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E000") { GatewayResponse = "Success"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E001") { GatewayResponse = "Unauthorized Payment Mode"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E002") { GatewayResponse = "Unauthorized Key"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E003") { GatewayResponse = "Unauthorized Packet"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E004") { GatewayResponse = "Unauthorized Merchant"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E005") { GatewayResponse = "Unauthorized Return URL"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E006") { GatewayResponse = "Transaction Already Paid"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E007") { GatewayResponse = "Transaction Failed"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E008") { GatewayResponse = "Failure from Third Party due to Technical Error or Funds Shortage"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0031") { GatewayResponse = "Mandatory fields coming from merchant are empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0032") { GatewayResponse = "Mandatory fields coming from database are empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0033") { GatewayResponse = "Payment mode coming from merchant is empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0034") { GatewayResponse = "PG Reference number coming from merchant is empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0035") { GatewayResponse = "Sub merchant id coming from merchant is empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0036") { GatewayResponse = "Transaction amount coming from merchant is empty"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0037") { GatewayResponse = "Payment mode coming from merchant is other than 0 to 9"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0038") { GatewayResponse = "Transaction amount coming from merchant is more than 9 digit length"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E0039") { GatewayResponse = "Mandatory value Email in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00310") { GatewayResponse = "Mandatory value mobile number in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00311") { GatewayResponse = "Mandatory value amount in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00312") { GatewayResponse = "Mandatory value Pan card in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00313") { GatewayResponse = "Mandatory value Date in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00314") { GatewayResponse = "Mandatory value String in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00315") { GatewayResponse = "Optional value Email in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00316") { GatewayResponse = "Optional value mobile number in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00317") { GatewayResponse = "Optional value amount in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00318") { GatewayResponse = "Optional value pan card number in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00319") { GatewayResponse = "Optional value date in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00320") { GatewayResponse = "Optional value string in wrong format"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00321") { GatewayResponse = "Request packet mandatory columns is not equal to mandatory columns set in enrolment or optional columns are not equal to optional columns length set in enrolment"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00324") { GatewayResponse = "Merchant Reference Number and Mandatory Columns are Null"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00325") { GatewayResponse = "Merchant Reference Number Duplicate"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00326") { GatewayResponse = "Sub merchant id coming from merchant is non numeric"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00327") { GatewayResponse = "Cash Challan Generated"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00328") { GatewayResponse = "Cheque Challan Generated"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00329") { GatewayResponse = "NEFT Challan Generated"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00330") { GatewayResponse = "Transaction Amount and Mandatory Transaction Amount mismatch in Request URL"; }
                    if (objServiceTimelinesBEL.PayTrans_response_code == "E00331") { GatewayResponse = "UPI Transaction Initiated Please Accept or Reject the Transaction"; }




                    if (!string.IsNullOrEmpty(objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC))
                    {
                        if (objServiceTimelinesBEL.PayTrans_response_code == "E000" || objServiceTimelinesBEL.PayTrans_response_code == "E00327" || objServiceTimelinesBEL.PayTrans_response_code == "E00328" || objServiceTimelinesBEL.PayTrans_response_code == "E00329")
                        {
                            if (objServiceTimelinesBEL.PayTrans_response_code == "E000")
                            {
                                lt.Text = "<div class='payment-success'><i class='fa fa-check-square-o' aria-hidden='true'></i> <span>Payment Successful</span></div>";
                            }
                            else
                            {
                                lt.Text = "<div class='payment-success'><i class='fa fa-check-square-o' aria-hidden='true'></i> <span>" + GatewayResponse + "</span></div>";
                            }
                        }
                        else
                        {
                            lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + GatewayResponse + " </span></div>";
                        }

                        objServiceTimelinesBEL.GatewayResponse = GatewayResponse;
                        string retVal = objServiceTimelinesBLL.UpdateAllotteTransaction(objServiceTimelinesBEL);

                        if (retVal == "Failed")
                        {
                            lt.Text = "<div class='payment-fail'><i class='fa fa-times-circle-o' aria-hidden='true'></i> <span>" + GatewayResponse + " </span></div>";
                        }
                        else
                        {
                            if (objServiceTimelinesBEL.PayTrans_response_code == "E000" || objServiceTimelinesBEL.PayTrans_response_code == "E00329")
                            {
                                btnContinue.Enabled = true;
                            }


                            UPSIDCRefrence.Text = objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC;
                            banktransactionNo.Text = objServiceTimelinesBEL.PayTrans_unique_ref;
                            tranjectionDate.Text = objServiceTimelinesBEL.PayTrans_trn_date.ToString();
                            lblAmmount.Text = objServiceTimelinesBEL.PayTrans_trn_amt;
                            lblPayStatus.Text = objServiceTimelinesBEL.GatewayResponse;
                            lblPaymode.Text = objServiceTimelinesBEL.PaymentMode;

                        }



                        //lt.Text+= "@ref_no_upsidc " + objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC;
                        //lt.Text += "<br/>@unique_ref_gateway " + objServiceTimelinesBEL.PayTrans_unique_ref;

                        //lt.Text += "<br/>@response_code " + objServiceTimelinesBEL.PayTrans_response_code;
                        //lt.Text += "<br/>@service_tax " + objServiceTimelinesBEL.PayTrans_service_tax;
                        //lt.Text += "<br/>@processing_fee_amt " + objServiceTimelinesBEL.PayTrans_processing_fee_amt;
                        //lt.Text += "<br/>@total_amt " + objServiceTimelinesBEL.PayTrans_total_amt;
                        //lt.Text += "<br/>@trn_amt " + objServiceTimelinesBEL.PayTrans_trn_amt;
                        //lt.Text += "<br/>@trn_date " + objServiceTimelinesBEL.PayTrans_trn_date;
                        //lt.Text += "<br/>@interchange_val " + objServiceTimelinesBEL.PayTrans_interchange_val;
                        //lt.Text += "<br/>@tdr " + objServiceTimelinesBEL.PayTrans_tdr;
                        //lt.Text += "<br/>@PaymentMode " + objServiceTimelinesBEL.PaymentMode;
                        //lt.Text += "<br/>@subme " + objServiceTimelinesBEL.PayTrans_submer;
                        //lt.Text += "<br/>@tps " + objServiceTimelinesBEL.PayTrans_tps;
                        //lt.Text += "<br/>@PayTrans_id " + objServiceTimelinesBEL.PayTrans_id;
                        //lt.Text += "<br/>@rs " + objServiceTimelinesBEL.PayTrans_rs;
                        //lt.Text += "<br/>@GatewayResponse " + objServiceTimelinesBEL.GatewayResponse;


                    }




                }





                if (!string.IsNullOrEmpty(objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC))
                {
                    BindApplicableFees(objServiceTimelinesBEL.PayTrans_unique_ref_UPSIDC);
                }

            }





        }


        public void BindApplicableFees(string PayTrans_unique_ref_UPSIDC)
        {


            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            DataSet dsR = new DataSet();
            DataSet dsoper = new DataSet();
            DataSet dst = new DataSet();


            try
            {
                DataTable dt_Fee = new DataTable();
                DataTable dt_Fee_other = new DataTable();

                DataTable Getdata1 = new DataTable();
                DataTable Getdata2 = new DataTable();




                // dst = objServiceTimelinesBLL.GetNivishMitraBasicDetail(ServiceReqNo);
                // if (dst.Tables[0].Rows.Count > 0) { Getdata3 = dst.Tables[0]; }


                dsR = objServiceTimelinesBLL.GetApplicableFeesFromTransaction(PayTrans_unique_ref_UPSIDC);




                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }



                string ServiceRequestNo = "";
                try
                {
                    ServiceRequestNo = dsR.Tables[1].Rows[0]["ServiceRequestNo"].ToString();
                    lblServiceReqNo.Text = ServiceRequestNo;
                }
                catch { ServiceRequestNo = ""; }
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
                string[] tokens = ServiceRequestNo.Split('/');
                string Serviceid = tokens[1].ToString();
                lblServiceID.Text = Serviceid;
                string SWCControlID = String.Empty;
                string SWCUnitID = String.Empty;
                string SWCServiceID = String.Empty;
                string SWCStatus = String.Empty;
                string SWCPayMode = String.Empty;
                //  string SWCPassSalt = System.Configuration.ConfigurationManager.AppSettings["passsalt"];

                if (Getdata1.Rows.Count > 0)
                {

                    subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                    subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                    TotalCharges = subTotalApplicableFees + subTotalDeposits + subTotalDues;




                    //Applicantname = Getdata3.Rows[0][0].ToString();
                    //industrialarea = Getdata3.Rows[0][1].ToString();
                    //plotsize = Getdata3.Rows[0][2].ToString() + " SQmts.";
                    //if ((Getdata3.Rows[0][3].ToString() != string.Empty) || (Getdata3.Rows[0][3].ToString() != null))
                    //{
                    //    appliedthrough = "Nivesh Mitra Single Window Clearence";

                    //}
                    //else { appliedthrough = "UPSIDC-Internals"; }
                    //btnAppliedthrough.Text = appliedthrough;



                    if (Getdata1.Rows.Count > 0)
                    {

                        string report_date = date_today.ToString("MMMM d, yyyy");
                        htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";

                        //if ((Getdata3.Rows.Count > 0))
                        //{
                        //    htmldata += @"
                        //      <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                        //            <tr style='background:#f7f7f7;'> 
                        //            <th>Service Reference Number</th><th class='text-left'>" + objServiceTimelinesBEL.ServiceRequestNO + @"</th></tr>
                        //           <tr style='background:#f7f7f7;'> <th>Applicant Name " + "" + "</th><th class='text-left'>" + Applicantname + @"</th></tr>
                        //            <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + industrialarea + @"</th></tr>
                        //            <tr style='background:#f7f7f7;'> <th>Required Plot Size " + "" + "</th><th class='text-left'>" + plotsize + @"</th></tr>
                        //            <tr style='background:#f7f7f7;'> <th>Applied Through" + "" + "</th><th class='text-left'>" + appliedthrough + @"</th></tr>

                        //       </table></div>";
                        //}

                        htmldata += @"
                        <div class='col- md-6'><table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style = 'background:#f7f7f7;'>
                                    <th> A. Applicable Fees</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";

                        if (Serviceid == "1000")
                        {
                            htmldata += @"
                                   <tr style = 'background:#f7f7f7;'> <th> B. Applicable Deposits" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";
                        }
                        else
                        {
                            htmldata += @"
                                 <tr style = 'background:#f7f7f7;'><th> B. Pending Dues Clearence" + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + subTotalDues + @"</th>
                                    </tr>";
                        }
                        htmldata += @"

                                 <tr style = 'background:#f7f7f7;'><th> Total Applicable Charges(A+B) " + "" + "</th><th class='text-center'><i class='fa fa-inr'></i>" + TotalCharges + @"</th>
                                    </tr>
                                </table></div><br /><br/><br/><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";
                        htmldata += @"
                               <tr><th colspan=""3"">" + "A. Applicable Fees" + @"</th></tr>";



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

                        htmldata += @"<tr><th colspan=""2"" class='text-center'> Sub Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";




                        //Building the Data rows for deposits.
                        if (Serviceid == "1000")
                        {
                            htmldata += @"
                               <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";
                            foreach (DataRow row in Getdata2.Rows)
                            {
                                htmldata += @"<tr> ";


                                htmldata += @"<td class='text-center'>" + @row["sno"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["paydescription"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["applicablecharge"].ToString() + @"</td>";

                                htmldata += @"</tr> ";
                            }
                            htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Sub Total Deposits</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalDeposits + @"</th></tr>";

                        }
                        else
                        {

                            htmldata += @"
                               <tr><th colspan=""3"">" + "B. Dues" + @"</th></tr>";
                            //Building the Data rows for dues.
                            htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Sub Total Dues</th><th class='text-left'> <i class='fa fa-inr'></i>" + subTotalDues + @"</th></tr>";

                        }

                        htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable ( A+B)</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";


                        //Building the Data rows for deposits.
                        //htmldata += @"
                        //       <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";

                        //Table end.
                        //
                        htmldata += " </table>";

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);

                        ph.Controls.Add(loLit);

                        DataSet dsSWC = new DataSet();




                        //if (Getdata3.Rows.Count > 0)
                        //{
                        //    SWCControlID = Getdata3.Rows[0]["ControlId"].ToString();
                        //    SWCUnitID = Getdata3.Rows[0]["UNITid"].ToString();
                        //    SWCServiceID = Getdata3.Rows[0]["ServiceId"].ToString();
                        //    SWCStatus = Getdata3.Rows[0]["SWCstatus"].ToString();
                        //    //   SWCPayMode = Getdata3.Rows[0]["status"].ToString();
                        //    if (SWCControlID.Length > 0)
                        //    {

                        //        //http://72.167.225.87/nivesh/upswp_niveshmitraservices.asmx?op=WGetUBPaymentDetails

                        //        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        //        dsSWC = webService.WGetUBPaymentDetails(SWCControlID, SWCUnitID, SWCServiceID, SWCPassSalt);

                        //        if (dsSWC.Tables[0].Rows.Count > 0)
                        //        {

                        //            lblControlId.Text = dsSWC.Tables[0].Rows[0]["Control_ID"].ToString();
                        //            lblUnitId.Text = dsSWC.Tables[0].Rows[0]["Unit_Id"].ToString();
                        //            lblServiceId.Text = dsSWC.Tables[0].Rows[0]["Service_ID"].ToString();
                        //            lblProcessIndustryId.Text = dsSWC.Tables[0].Rows[0]["ProcessIndustryID"].ToString();
                        //            lblApplicationId.Text = dsSWC.Tables[0].Rows[0]["ApplicationID"].ToString();
                        //            lblFeeAmount.Text = dsSWC.Tables[0].Rows[0]["Fee_Amount"].ToString();
                        //            lblFeeStatus.Text = dsSWC.Tables[0].Rows[0]["Fee_Status"].ToString();
                        //            lblTransactionId.Text = dsSWC.Tables[0].Rows[0]["Transaction_ID"].ToString();
                        //            lblTransactionDate.Text = dsSWC.Tables[0].Rows[0]["Transaction_Date"].ToString();
                        //            lblTransactionTime.Text = dsSWC.Tables[0].Rows[0]["Transaction_Time"].ToString();
                        //            lblTransactionDatetime.Text = dsSWC.Tables[0].Rows[0]["Transaction_DateTime"].ToString();
                        //            //lblStatusCode.Text = dsSWC.Tables[0].Rows[0]["Status_Code"].ToString();
                        //            lblRemarks.Text = dsSWC.Tables[0].Rows[0]["Remarks"].ToString();

                        //            string strSWCStatus = string.Empty;
                        //            strSWCStatus = dsSWC.Tables[0].Rows[0]["Status_Code"].ToString();
                        //            if (strSWCStatus == "01") { lblStatusCode.Text = "INPROCESS"; }
                        //            if (strSWCStatus == "02") { lblStatusCode.Text = "PENDING"; }
                        //            if (strSWCStatus == "03") { lblStatusCode.Text = "VIEWED"; }
                        //            if (strSWCStatus == "04") { lblStatusCode.Text = "VERIFIED"; }
                        //            if (strSWCStatus == "05") { lblStatusCode.Text = "FORWARDED"; }
                        //            if (strSWCStatus == "06") { lblStatusCode.Text = "APPROVED"; }
                        //            if (strSWCStatus == "07") { lblStatusCode.Text = "REJECTED"; }
                        //            if (strSWCStatus == "08") { lblStatusCode.Text = "QUERY/OBJECTION"; }
                        //            if (strSWCStatus == "09") { lblStatusCode.Text = "PUT FOR FURTHER REVIEW"; }
                        //            if (strSWCStatus == "10") { lblStatusCode.Text = "SAVE AS DRAFT"; }
                        //            if (strSWCStatus == "11") { lblStatusCode.Text = "FEE PAID"; }
                        //            if (strSWCStatus == "12") { lblStatusCode.Text = "FEE PENDING"; }
                        //            if (strSWCStatus == "13") { lblStatusCode.Text = "FORM SUBMITTED"; }
                        //            if (strSWCStatus == "14") { lblStatusCode.Text = "FORM RE-SUBMITTED"; }
                        //            if (strSWCStatus == "15") { lblStatusCode.Text = "CERTIFICATE/NOC ISSUED"; }

                        //        }
                        //    }

                        //}

                    }


                }

                // textbox1.text = dsR.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured 0001 :" + ex.Message.ToString() + " " + PayTrans_unique_ref_UPSIDC);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (lblServiceID.Text == "1000")
            {
                if (lblResponseCode.Text == "E00329")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirectC('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }
                if (lblResponseCode.Text == "E000")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirect('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }
            }
            if (lblServiceID.Text == "100")
            {

                if (lblResponseCode.Text == "E00329")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirectC('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }
                if (lblResponseCode.Text == "E000")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "redirectDemand('" + lblServiceReqNo.Text.Trim() + "','" + lblUPSIDCTran.Text.Trim() + "');", true);
                }
            }
        }
    }
}