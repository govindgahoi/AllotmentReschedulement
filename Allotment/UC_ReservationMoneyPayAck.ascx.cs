using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ReservationMoneyPayAck : System.Web.UI.UserControl
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        GeneralMethod gm = new GeneralMethod();
       
        public string ServiceReqNo;
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        public string ServiceRequestNo { get; set; }
        public string Parameter { get; set; }
        public string TranID { get; set; }
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

            DataTable NMSWP = gm.GetNMSWPIDNews(ServiceRequestNo);
            SWCControlID = NMSWP.Rows[0][0].ToString();
            SWCUnitID    = NMSWP.Rows[0][1].ToString();
            SWCServiceID = NMSWP.Rows[0][2].ToString();
            BindApplicableFees(ServiceRequestNo);

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

                DataTable Datadt = new DataTable();
                DataTable Paymentdt = new DataTable();
                DataTable URNDT = new DataTable();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceRequestNo;
                objServiceTimelinesBEL.TranID = TranID;


                if (TranID == "" || TranID == null)
                {

                }
                else
                {
                    if(SWCControlID.Length>0)
                    {
                        Pay_Ds = objServiceTimelinesBLL.GetReservationPaymentDetailAfterTransactionNMSWP(objServiceTimelinesBEL);
                    }
                    else
                    {
                        Pay_Ds = objServiceTimelinesBLL.GetReservationPaymentDetailAfterTransaction(objServiceTimelinesBEL);
                    }
                   
                    Datadt = Pay_Ds.Tables[0];
                    Paymentdt = Pay_Ds.Tables[1];

                }

                string htmldata = "";


                if (Datadt.Rows.Count > 0)
                {


                    string report_date = DateTime.Now.ToString("MMMM d, yyyy");
                    htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";


                    if (Datadt.Rows.Count > 0)
                    {
                        string Applicantname = Datadt.Rows[0]["AllotteeName"].ToString();
                        string industrialarea = Datadt.Rows[0]["IndustrialArea"].ToString();
                        string PlotNo = Datadt.Rows[0]["PlotNo"].ToString();
                        string PayMode = Datadt.Rows[0]["PayMode"].ToString();
                        string TranRefNo = Datadt.Rows[0]["TranRefNo"].ToString();
                        string TranDate = Datadt.Rows[0]["TranDate"].ToString();
                        string PayStatus = Datadt.Rows[0]["PayStatus"].ToString();

                        if (Datadt.Rows[0]["Paid"].ToString() == "True")
                        {

                            htmldata += @"
                              <div style='position:relative;'><div style='position: absolute;right:30px;top:20px;z-index:2;'><img class='img-responsive' src='images/paid1.png' style='width:150px;' /></div><div class='col-md-12' style='position:relative;z-index:1;'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
                                    <tr style='background:#f7f7f7;'> 
                                    <td>Demand Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
                                   <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + Applicantname + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + industrialarea + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Plot No " + "" + "</td><td style='text-align:left;'>" + PlotNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Mode" + "" + "</td><td style='text-align:left;'>" + PayMode + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Ref No" + "" + "</td><td style='text-align:left;'>" + TranRefNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Date" + "" + "</td><td style='text-align:left;'>" + TranDate + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Status" + "" + "</td><td style='text-align:left;'>" + PayStatus + @"</td></tr>

                                </table></div></div>";
                        }
                        else
                        {
                            htmldata += @"
                              <div class='col-md-12' style='position:relative;z-index:1;'><table class=""table table-bordered table-hover request-table pull-left"" width='41%' style='Font-Size:12px;'>
                                    <tr style='background:#f7f7f7;'> 
                                    <td>Demand Reference Number</td><td style='text-align:left;'>" + ServiceRequestNo + @"</td></tr>
                                   <tr style='background:#f7f7f7;'> <td>Applicant Name " + "" + "</td><td style='text-align:left;'>" + Applicantname + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Industrial Area " + "" + "</td><td style='text-align:left;'>" + industrialarea + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Plot No " + "" + "</td><td style='text-align:left;'>" + PlotNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Mode" + "" + "</td><td style='text-align:left;'>" + PayMode + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Ref No" + "" + "</td><td style='text-align:left;'>" + TranRefNo + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Transaction Date" + "" + "</td><td style='text-align:left;'>" + TranDate + @"</td></tr>
                                    <tr style='background:#f7f7f7;'> <td>Payment Status" + "" + "</td><td style='text-align:left;'>" + PayStatus + @"</td></tr>

                                </table></div>";
                        }
                    }

                }

                if (Paymentdt.Rows.Count > 0)
                {

                    decimal subTotalApplicableFees = Convert.ToDecimal(Paymentdt.Compute("SUM(applicablecharge)", string.Empty));


                    htmldata += @"

                                 <br /><br/><br/><br/><br/>
                    
                        <table class=""table table-bordered table-hover request-table"" width=""100%"">
                        
                            <tr style = 'background:#f7f7f7;'>
                                <th> S.NO </th>
                                <th> Description </th>
                                <th class=""text-center"">Amount</th>
                            </tr>";



                    foreach (DataRow row in Paymentdt.Rows)
                    {
                        htmldata += @" <tr> ";


                        htmldata += @"<td class='text-center'>" + @row["sno"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["paydescription"].ToString() + @"</td>
                                          <td class='text-center'>" + @row["applicablecharge"].ToString() + @"</td>";
                        htmldata += @"</tr> ";
                    }

                    htmldata += @"<tr><td colspan=""2"" style='text-align:center;'>Total Amount</td><td style='text-align:left;'>&#x20B9;" + subTotalApplicableFees.ToString("0.00") + @"</td></tr>";
                }
                htmldata += " </table>";

                //if(Datadt.Rows[0]["Paid"].ToString()=="True")
                //{
                //    htmldata += @"<div class='clearfix'></div><div class='clearfix'></div>";
                //}

                Literal loLit = new Literal();
                loLit.Text = (htmldata);
                PH3.Controls.Add(loLit);



                // textbox1.text = dsR.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

    }
}