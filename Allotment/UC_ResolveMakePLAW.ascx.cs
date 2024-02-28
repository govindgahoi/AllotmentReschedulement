using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_ResolveMakePLAW : System.Web.UI.UserControl
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
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

        //public int TEFTimeperiod { get; set; }
        public decimal PlotSize { get; set; }
        //public int AllotteeID { get; set; }
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




        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable NMSWP = gm.GetNMSWPIDNews(ServiceRequestNo);
            //SWCControlID = NMSWP.Rows[0][0].ToString();
            //SWCUnitID = NMSWP.Rows[0][1].ToString();
            //SWCServiceID = NMSWP.Rows[0][2].ToString();
            //if (SWCControlID.Length > 0)
            //{
                BindApplicableFeesNMSWP();
            //}

        }


        public void BindApplicableFeesNMSWP()
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


                Pay_Ds = objServiceTimelinesBLL.GetTransactionDetailsNMSWPLAW(objServiceTimelinesBEL);
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
                else
                {
                    PayStatus = "Payment Pending At NMSWP";
                }

                //objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                //dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);


                string report_date = date_today.ToString("MMMM d, yyyy");
                htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";
                //if (Paymentdt.Rows.Count > 0)
                //{
                    //objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    //dschoicearea = objServiceTimelinesBLL.GetapplicableChargesforTimeExtenstionNMSWPPaid(objServiceTimelinesBEL);

                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""100%"" style=""Font-Size:12px;"">
                                    <tr> 
                                     <th style='background:#f7f7f7;'>Application Reference Number</th><td class='text-left'>" + ServiceRequestNo + @"</td>
                                     <th style='background:#f7f7f7;'>  </th><td class='text-left'> </td></tr>
                                     <tr> <th>Applied in the name of " + "" + "</th><td class='text-left'>" + ApplicantName + @"</td>
                                     <th style='background:#f7f7f7;'> Address " + "" + "</th><td class='text-left'>" + applicantAddress + @"</td></tr>
                                     <tr> <th> Payment Mode " + "" + "</th><td class='text-left'>" + PayMode + @"</td>
                                     <th style='background:#f7f7f7;'> Transaction Ref No " + "" + "</th><td class='text-left'>" + TranRefNo + @"</td></tr>
                                     <tr> <th> Payment Received Date " + "" + "</th><td class='text-left'>" + TranDate + @"</td>
                                     <th style='background:#f7f7f7;'> Payment Status " + "" + "</th><td class='text-left'>" + PayStatus + @"</td></tr>
                               </table></div><br/>";
               // }
                
                // for Option 1 : Based on Selected Plot Area              
                //if (dschoicearea.Tables.Count > 0)
                //{

                    //if (dschoicearea.Tables[0].Rows.Count > 0)
                    //{
                        //if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        subTotalApplicableFees = 10000;

                        TotalCharges = 11800;
                        plotsize = PlotSize + " SQmts.";
                        //if (Getdata1.Rows.Count > 0)
                        //{

                            subTotalApplicableFees = 10000;
                            // subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                            //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                            TotalCharges = 11800;
                            //industrialarea = Convert.ToString(industrialarea);
                            plotsize = choicearea + " SQmts.";

                            htmldata += @"<br/><br/>";

                            //if (Getdata1.Rows.Count > 0)
                            //{

                                htmldata += @"<br/>
                                 
                                  
                                     <div class='row'><label class=""col-md-12 col-sm-12 col-xs-12 text-center"" style='border-top:dashed'> </label></div>
                                    <br/>";
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
                                //foreach (DataRow row in Getdata1.Rows)
                                //{
                                    htmldata += @" <tr> ";
                            //foreach (DataColumn column in Getdata1.Columns)
                            //{
                            htmldata += @"<td class='text-center'> ";
                            htmldata += @"1 ";
                            // html.Append(row[column.ColumnName]);
                            htmldata += @"</td> ";

                            htmldata += @"<td class='text-center'> ";
                                        htmldata += @"Processing Fess Against Application Under Warehousing & Logistic ";
                                        // html.Append(row[column.ColumnName]);
                                        htmldata += @"</td> ";
                            htmldata += @"<td class='text-center'> ";
                            htmldata += @"10000";
                            // html.Append(row[column.ColumnName]);
                            htmldata += @"</td> ";
                            //}
                            htmldata += @"</tr> ";
                        //}
                        htmldata += @" <tr> ";
                        //foreach (DataColumn column in Getdata1.Columns)
                        //{
                        htmldata += @"<td class='text-center'> ";
                        htmldata += @"2 ";
                        // html.Append(row[column.ColumnName]);
                        htmldata += @"</td> ";

                        htmldata += @"<td class='text-center'> ";
                        htmldata += @"GST 18% ";
                        // html.Append(row[column.ColumnName]);
                        htmldata += @"</td> ";
                        htmldata += @"<td class='text-center'> ";
                        htmldata += @"1800";
                        // html.Append(row[column.ColumnName]);
                        htmldata += @"</td> ";
                        //}
                        htmldata += @"</tr> ";


                        htmldata += @"

                              <tr><td colspan=""2"" class='text-center'>Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</td></tr>";



                                htmldata += @"
                              <tr><th colspan=""2"" class='text-center'> Total Payable</th><th class='text-left'><i class='fa fa-inr'></i>" + TotalCharges + @"</th></tr>";



                                htmldata += " </table>";

                            //}

                        //}

                    //}



                //}
                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                ph1.Controls.Add(loLit);
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        
    }
}