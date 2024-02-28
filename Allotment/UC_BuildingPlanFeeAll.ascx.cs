using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_BuildingPlanFeeAll : System.Web.UI.UserControl
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
        public string CaseType { get; set; }

        public string MalbaPaid { get; set; }
        public string InfraPaid { get; set; }
        public string AreaStatus { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            BindApplicableFees();
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
            decimal subTotalApplicableFees1 = 0;
            decimal subTotalDeposits = 0;
            decimal subTotalDues = 0;
            decimal TotalCharges = 0;
            decimal TotalCharges1 = 0;
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




                if (choicearea > 0)
                {
                    objServiceTimelinesBEL.choicearea = choicearea;
                    objServiceTimelinesBEL.CoveredArea = CoveredArea;
                    objServiceTimelinesBEL.MalbaPaid = MalbaPaid;
                    objServiceTimelinesBEL.InfraPaid = InfraPaid;
                    objServiceTimelinesBEL.BPCaseType = CaseType;
                    objServiceTimelinesBEL.AreaStatus = AreaStatus;
                    //objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                    dschoicearea = objServiceTimelinesBLL.GetBuildingPlanChargesAll(objServiceTimelinesBEL);


                    string report_date = date_today.ToString("MMMM d, yyyy");
                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" >  Statement of Estimated Deposits</h2><br/>";




                    htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">                                    
                                      <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + gm.Get_IAName_ByID(IndustrialArea) + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th>Applied in the name of " + "" + "</th><th class='text-left'>" + ApplicantName + @"</th></tr>
                                     <tr style='background:#f7f7f7;'> <th> Address " + "" + "</th><th class='text-left'>" + applicantAddress + @"</th></tr>
                               </table></div><br/><br/>";

                    // for Option 1 : Based on Selected Plot Area              
                    if (dschoicearea.Tables.Count > 0)
                    {

                        if (dschoicearea.Tables[0].Rows.Count > 0)
                        {
                            if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                            if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }



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
                                    <tr style='background:#f7f7f7;'> <th>Plot Area " + "" + "</th><th class='text-left'>" + plotsize + @"</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Builtup/Covered Area " + "" + "</th><th class='text-left'>" + CoveredArea + @" SQmts</th></tr>


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
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

    }
}