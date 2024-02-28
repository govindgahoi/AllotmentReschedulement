using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ucAccountClearence : System.Web.UI.UserControl
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



        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0,
            PacketId = 0;
        SqlConnection con;
        public string DataFactsModel_open = "";
        public string TicketStatus = "";
        public string TicketFor = "";
        public string TicketId = "";








        protected void Page_Load(object sender, EventArgs e)
        {

            string ServicesId = (Request.QueryString["ServicesId"]);
            string ticketDescription = (Request.QueryString["TicketDescription"]);
            string TicketId = (Request.QueryString["TicketID"]);
            int PacketId = int.Parse(Request.QueryString["PacketID"]);




            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;
            }
            catch { Response.Redirect("Default.aspx", false); }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!Page.IsPostBack)
            {
                DefaultSettings();
                BindApplicableFees(Request.QueryString["ServicesId"]);
                GetServiceAccountClearenceRecords(Int32.Parse(TicketId));
                //drpReportName.Items.Insert(0, new ListItem("--Select Ticket--", "0"));
                drpReportName.Items.Insert(0, new ListItem(ServicesId, "0"));
            }

            // kachra work to be corrected




            //if (!IsPostBack)
            //{

            ServiceReqNo = ServicesId;
            //    BindApplicableFees(Request.QueryString["ServicesId"]);ServicesId

            //}

            //ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
            try { TicketId = (Request.QueryString["TicketID"]); } catch (Exception ex) { Response.Write("Oops! error occured :" + ex.Message.ToString()); }
            try { TicketId = (Request.QueryString["TicketID"]); } catch (Exception ex) { Response.Write("Oops! error occured :" + ex.Message.ToString()); }
            try { PacketId = int.Parse(Request.QueryString["PacketID"]); } catch (Exception ex) { Response.Write("Oops! error occured :" + ex.Message.ToString()); }

            try
            {
                if (TicketId.Length > 0)
                {
                    GeneralMethod gm1 = new GeneralMethod();
                    TicketFor = gm1.GetServiceTicketFor(TicketId);
                }
            }
            catch { }

            GeneralMethod gm = new GeneralMethod();
            TicketStatus = gm.GetServiceTicketStatusByUser(UserId, PacketId, ServiceReqNo);

            if (TicketStatus != "Open")
            {
                //txtTicketComment.Enabled = false;
                //ChangeTicketStatus.Enabled = false;
                DefaultSettings();
                DefaultSettingsDisabled();

            }
        }

        public void DefaultSettings()
        {
            drpReportName.SelectedIndex = 0;
            drpOperate.SelectedIndex = -1;
            txtAmtCredited.Text = string.Empty;
            rdOnline.Checked = true;
            rdOffline.Checked = false;
            txtamtreceived.Text = string.Empty;
            txtGateway.Text = string.Empty;
            txtOnAmt.Text = string.Empty;
            txtpayDate.Text = string.Empty;
            txtPayMethod.Text = string.Empty;
            txtrefno.Text = string.Empty;
            txtTransDate.Text = string.Empty;
            txtTransID.Text = string.Empty;
            btnSave.Enabled = false;

            txtamtreceived.Enabled = false;
            txtpayDate.Enabled = false;
            txtPayMethod.Enabled = false;
            txtrefno.Enabled = false;

            txtTransDate.Enabled = true;
            txtTransID.Enabled = true;
            txtGateway.Enabled = true;
            txtOnAmt.Enabled = true;

            txtamtreceived.Text = string.Empty;
            txtpayDate.Text = string.Empty;
            txtPayMethod.Text = string.Empty;
            txtrefno.Text = string.Empty;

            txtTransDate.Text = string.Empty;
            txtTransID.Text = string.Empty;
            txtGateway.Text = string.Empty;
            txtOnAmt.Text = string.Empty;
            chkAgree.Checked = false;


        }

        public void DefaultSettingsDisabled()
        {
            drpReportName.SelectedIndex = 0;
            drpReportName.Enabled = false;
            drpOperate.SelectedIndex = -1;
            drpOperate.Enabled = false;
            txtAmtCredited.Enabled = false;
            rdOnline.Checked = true;
            rdOffline.Checked = false;
            txtamtreceived.Enabled = false;
            txtGateway.Enabled = false;
            txtOnAmt.Enabled = false;
            txtpayDate.Enabled = false;
            txtPayMethod.Enabled = false;
            txtrefno.Enabled = false;
            txtTransDate.Enabled = false;
            txtTransID.Enabled = false;
            btnSave.Enabled = false;

            txtamtreceived.Enabled = false;
            txtpayDate.Enabled = false;
            txtPayMethod.Enabled = false;
            txtrefno.Enabled = false;

            txtTransDate.Enabled = false;
            txtTransID.Enabled = false;
            txtGateway.Enabled = false;
            txtOnAmt.Enabled = false;

            txtamtreceived.Enabled = false;
            txtpayDate.Enabled = false;
            txtPayMethod.Enabled = false;
            txtrefno.Enabled = false;

            txtTransDate.Enabled = false;
            txtTransID.Enabled = false;
            txtGateway.Enabled = false;
            txtOnAmt.Enabled = false;
            chkAgree.Enabled = false;


        }


        public void GetServiceAccountClearenceRecords(int tickitID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            //conenction path for database
            //int Parameter = Int32.Parse();
            DataSet ds = new DataSet();

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserId = _objLoginInfo.userid;
                objServiceTimelinesBEL.ticketID = Int32.Parse(Request.QueryString["TicketID"]);

                ds = objServiceTimelinesBLL.GetServiceAccountClearenceRecords(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblControlId.Text = dt.Rows[0]["SWCControlId"].ToString();
                    lblUnitId.Text = dt.Rows[0]["SWCUnitId"].ToString();
                    lblServiceId.Text = dt.Rows[0]["SWCServiceId"].ToString();
                    lblProcessIndustryId.Text = dt.Rows[0]["SWCProcessIndustryId"].ToString();
                    lblApplicationId.Text = dt.Rows[0]["SWCApplicationId"].ToString();
                    lblFeeStatus.Text = dt.Rows[0]["SWCFeeAmount"].ToString();
                    lblTransactionId.Text = dt.Rows[0]["SWCFeeStatus"].ToString();
                    lblTransactionDate.Text = dt.Rows[0]["SWCTransactionId"].ToString();
                    lblTransactionTime.Text = dt.Rows[0]["SWCTransactionDate"].ToString();
                    lblTransactionDatetime.Text = dt.Rows[0]["SWCTransactionTime"].ToString();
                    lblStatusCode.Text = dt.Rows[0]["SWCTransactionDatetime"].ToString();
                    lblRemarks.Text = dt.Rows[0]["SWCStatusCode"].ToString();
                    txtAmtCredited.Text = dt.Rows[0]["SWCRemarks"].ToString();
                    // online.Text = dt.Rows[0]["SWCControlId"].ToString();
                    txtTransDate.Text = dt.Rows[0]["upsidcAmtCreditConfirmation"].ToString();
                    txtGateway.Text = dt.Rows[0]["modeofPaymentConfirmation"].ToString();
                    txtTransID.Text = dt.Rows[0]["TransIDConfirmation"].ToString();
                    txtOnAmt.Text = dt.Rows[0]["TransAmountConfirmation"].ToString();
                    if (dt.Rows[0]["OnlineOffline"].ToString() == "Online") { rdOffline.Checked = true; } else { rdOnline.Checked = true; }
                    txtpayDate.Text = dt.Rows[0]["TransAmountConfirmation"].ToString();
                    txtPayMethod.Text = dt.Rows[0]["PaymethodConfirmation"].ToString();
                    txtrefno.Text = dt.Rows[0]["TransrefnoConfirmation"].ToString();
                    txtamtreceived.Text = dt.Rows[0]["amtreceivedConfirmation"].ToString();

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
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserId = _objLoginInfo.userid;
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                objServiceTimelinesBEL.ServiceRequestNO = (Request.QueryString["ServicesId"]);
                objServiceTimelinesBEL.ticketDescription = (Request.QueryString["TicketDescription"]);

                dsoper = objServiceTimelinesBLL.GetServiceTicketTags();
                if (dsoper.Tables[0].Rows.Count > 0)
                {
                    drpOperate.DataSource = dsoper.Tables[0];
                    drpOperate.DataTextField = "TagDescription";
                    drpOperate.DataValueField = "Tagid";
                    drpOperate.DataBind();
                    drpOperate.Items.Insert(0, new ListItem("- Please Select -", "0"));

                }

                dsR = objServiceTimelinesBLL.GetapplicableChargesnDataAC(serviceNO);
                if (dsR.Tables[0].Rows.Count > 0) { Getdata1 = dsR.Tables[0]; }
                if (dsR.Tables[1].Rows.Count > 0) { Getdata2 = dsR.Tables[1]; }
                if (dsR.Tables[2].Rows.Count > 0) { Getdata3 = dsR.Tables[2]; }
                //if (dsR.Tables[3].Rows.Count > 0) { Getdata4 = dsR.Tables[3]; }

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
                string[] tokens = objServiceTimelinesBEL.ServiceRequestNO.Split('/');
                string Serviceid = tokens[1].ToString();
                string SWCControlID = String.Empty;
                string SWCUnitID = String.Empty;
                string SWCServiceID = String.Empty;
                string SWCStatus = String.Empty;
                string SWCPayMode = String.Empty;
                string Request_ID_In = String.Empty;
                string SWCPassSalt = System.Configuration.ConfigurationManager.AppSettings["passsalt"];

                if (Getdata1.Rows.Count > 0)
                {

                    subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                    subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));
                    //subTotalDues = Convert.ToDecimal(Getdata4.Compute("SUM(applicablecharge)", string.Empty));
                    TotalCharges = subTotalApplicableFees + subTotalDeposits + subTotalDues;
                    Applicantname = Getdata3.Rows[0][0].ToString();
                    industrialarea = Getdata3.Rows[0][1].ToString();
                    plotsize = Getdata3.Rows[0][2].ToString() + " SQmts.";
                    if ((Getdata3.Rows[0][3].ToString() != string.Empty) || (Getdata3.Rows[0][3].ToString() != null))
                    {
                        appliedthrough = "UPSIDC-Internals";

                    }
                    else { appliedthrough = "Nivesh Mitra Single Window Clearence"; }
                    btnAppliedthrough.Text = appliedthrough;

                    if (Getdata1.Rows.Count > 0)
                    {


                        string report_date = date_today.ToString("MMMM d, yyyy");
                        htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br/><h2 style = ""text-decoration:underline;"" > Accounts  Statement </h2><br />";

                        if ((Getdata3.Rows.Count > 0))
                        {
                            htmldata += @"
                              <div class='col- md-6'><table class=""table-bordered pull-left"" width=""41%"" style=""Font-Size:12px;"">
                                    <tr style='background:#f7f7f7;'> 
                                    <th>Service Reference Number</th><th class='text-left'>" + objServiceTimelinesBEL.ServiceRequestNO + @"</th></tr>
                                   <tr style='background:#f7f7f7;'> <th>Applicant Name " + "" + "</th><th class='text-left'>" + Applicantname + @"</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Industrial Area " + "" + "</th><th class='text-left'>" + industrialarea + @"</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Required Plot Size " + "" + "</th><th class='text-left'>" + plotsize + @"</th></tr>
                                    <tr style='background:#f7f7f7;'> <th>Applied Through" + "" + "</th><th class='text-left'>" + appliedthrough + @"</th></tr>
                           
                               </table></div>";
                        }

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
                              <tr><th colspan=""2"" class='text-center'> Sub Total Applicable Fees</th><th class='text-left'><i class='fa fa-inr'></i>" + subTotalApplicableFees + @"</th></tr>";


                        //Building the Data rows for deposits.
                        if (Serviceid == "1000")
                        {
                            htmldata += @"
                               <tr><th colspan=""3"">" + "B. Deposits" + @"</th></tr>";
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

                        if (Getdata3.Rows.Count > 0)
                        {
                            SWCControlID = Getdata3.Rows[0]["ControlId"].ToString();
                            SWCUnitID = Getdata3.Rows[0]["UNITid"].ToString();
                            SWCServiceID = Getdata3.Rows[0]["ServiceId"].ToString();
                            SWCStatus = Getdata3.Rows[0]["SWCstatus"].ToString();
                            //    SWCPayMode = Getdata3.Rows[0]["status"].ToString();
                            if (SWCControlID.Length > 0)
                            {

                                //http://72.167.225.87/nivesh/upswp_niveshmitraservices.asmx?op=WGetUBPaymentDetails

                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                dsSWC = webService.WGetUBPaymentDetails(SWCControlID, SWCUnitID, SWCServiceID, SWCPassSalt, Request_ID_In);

                                if (dsSWC.Tables[0].Rows.Count > 0)
                                {

                                    lblControlId.Text = dsSWC.Tables[0].Rows[0]["Control_ID"].ToString();
                                    lblUnitId.Text = dsSWC.Tables[0].Rows[0]["Unit_Id"].ToString();
                                    lblServiceId.Text = dsSWC.Tables[0].Rows[0]["Service_ID"].ToString();
                                    lblProcessIndustryId.Text = dsSWC.Tables[0].Rows[0]["ProcessIndustryID"].ToString();
                                    lblApplicationId.Text = dsSWC.Tables[0].Rows[0]["ApplicationID"].ToString();
                                    lblFeeAmount.Text = dsSWC.Tables[0].Rows[0]["Fee_Amount"].ToString();
                                    lblFeeStatus.Text = dsSWC.Tables[0].Rows[0]["Fee_Status"].ToString();
                                    lblTransactionId.Text = dsSWC.Tables[0].Rows[0]["Transaction_ID"].ToString();
                                    lblTransactionDate.Text = dsSWC.Tables[0].Rows[0]["Transaction_Date"].ToString();
                                    lblTransactionTime.Text = dsSWC.Tables[0].Rows[0]["Transaction_Time"].ToString();
                                    lblTransactionDatetime.Text = dsSWC.Tables[0].Rows[0]["Transaction_DateTime"].ToString();
                                    //lblStatusCode.Text = dsSWC.Tables[0].Rows[0]["Status_Code"].ToString();
                                    lblRemarks.Text = dsSWC.Tables[0].Rows[0]["Remarks"].ToString();

                                    string strSWCStatus = string.Empty;
                                    strSWCStatus = dsSWC.Tables[0].Rows[0]["Status_Code"].ToString();
                                    if (strSWCStatus == "01") { lblStatusCode.Text = "INPROCESS"; }
                                    if (strSWCStatus == "02") { lblStatusCode.Text = "PENDING"; }
                                    if (strSWCStatus == "03") { lblStatusCode.Text = "VIEWED"; }
                                    if (strSWCStatus == "04") { lblStatusCode.Text = "VERIFIED"; }
                                    if (strSWCStatus == "05") { lblStatusCode.Text = "FORWARDED"; }
                                    if (strSWCStatus == "06") { lblStatusCode.Text = "APPROVED"; }
                                    if (strSWCStatus == "07") { lblStatusCode.Text = "REJECTED"; }
                                    if (strSWCStatus == "08") { lblStatusCode.Text = "QUERY/OBJECTION"; }
                                    if (strSWCStatus == "09") { lblStatusCode.Text = "PUT FOR FURTHER REVIEW"; }
                                    if (strSWCStatus == "10") { lblStatusCode.Text = "SAVE AS DRAFT"; }
                                    if (strSWCStatus == "11") { lblStatusCode.Text = "FEE PAID"; }
                                    if (strSWCStatus == "12") { lblStatusCode.Text = "FEE PENDING"; }
                                    if (strSWCStatus == "13") { lblStatusCode.Text = "FORM SUBMITTED"; }
                                    if (strSWCStatus == "14") { lblStatusCode.Text = "FORM RE-SUBMITTED"; }
                                    if (strSWCStatus == "15") { lblStatusCode.Text = "CERTIFICATE/NOC ISSUED"; }

                                }
                            }

                        }

                    }


                }
                // textbox1.text = dsR.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }






        protected void drpReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpReportName.SelectedValue.ToString().Trim().Length > 0)
            {
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (chkAgree.Checked)
            {


                try
                {


                    try { TicketId = (Request.QueryString["TicketID"]); } catch (Exception ex) { Response.Write("Oops! error occured :" + ex.Message.ToString()); }
                    try { PacketId = int.Parse(Request.QueryString["PacketID"]); } catch (Exception ex) { Response.Write("Oops! error occured :" + ex.Message.ToString()); }
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserId = _objLoginInfo.userid;
                    //DateTime dt1 = DateTime.ParseExact(lblTransactionDate.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    //DateTime dt2 = DateTime.ParseExact(lblTransactionDatetime.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    //DateTime dt3 = DateTime.ParseExact(txtTransDate.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    //DateTime dt4 = DateTime.ParseExact(lblTransactionDate.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    //DateTime dt5 = DateTime.ParseExact(lblTransactionDate.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.ServiceRequestNO = Request.QueryString["ServicesId"];
                    string[] tokens = objServiceTimelinesBEL.ServiceRequestNO.Split('/');
                    string Serviceid = tokens[1].ToString();

                    objServiceTimelinesBEL.packetID = PacketId;
                    objServiceTimelinesBEL.ticketID = Int32.Parse(TicketId);
                    if ((lblFeeAmount.Text == string.Empty) || (lblFeeAmount.Text == null)) { lblFeeAmount.Text = "0"; }
                    if ((txtOnAmt.Text == string.Empty) || (txtOnAmt.Text == null)) { txtOnAmt.Text = "0"; }
                    if ((txtamtreceived.Text == string.Empty) || (txtamtreceived.Text == null)) { txtamtreceived.Text = "0"; }


                    objServiceTimelinesBEL.serviceID = Serviceid;

                    objServiceTimelinesBEL.SWCControlId = lblControlId.Text;
                    objServiceTimelinesBEL.SWCUnitId = lblUnitId.Text;
                    objServiceTimelinesBEL.SWCServiceId = lblServiceId.Text;
                    objServiceTimelinesBEL.SWCProcessIndustryId = lblProcessIndustryId.Text;
                    objServiceTimelinesBEL.SWCApplicationId = lblApplicationId.Text;
                    objServiceTimelinesBEL.SWCFeeAmount = decimal.Parse(lblFeeAmount.Text);
                    objServiceTimelinesBEL.SWCFeeStatus = lblFeeStatus.Text;
                    objServiceTimelinesBEL.SWCTransactionId = lblTransactionId.Text;
                    objServiceTimelinesBEL.SWCTransactionDate = lblTransactionDate.Text;
                    objServiceTimelinesBEL.SWCTransactionTime = lblTransactionTime.Text;
                    objServiceTimelinesBEL.SWCTransactionDatetime = lblTransactionDatetime.Text;
                    objServiceTimelinesBEL.SWCStatusCode = lblStatusCode.Text;
                    objServiceTimelinesBEL.SWCRemarks = lblRemarks.Text;
                    objServiceTimelinesBEL.upsidcAmtCreditConfirmation = txtAmtCredited.Text;
                    if (rdOnline.Checked) { objServiceTimelinesBEL.OnlineOffline = "Online"; }
                    if (rdOffline.Checked) { objServiceTimelinesBEL.OnlineOffline = "Offline"; }
                    objServiceTimelinesBEL.modeofPaymentConfirmation = txtGateway.Text;
                    objServiceTimelinesBEL.gateway = txtGateway.Text;
                    objServiceTimelinesBEL.TransDateConfirmation = txtTransDate.Text;
                    objServiceTimelinesBEL.PaymethodConfirmation = txtPayMethod.Text;
                    objServiceTimelinesBEL.TransID = txtTransID.Text;
                    objServiceTimelinesBEL.TransAmountConfirmation = decimal.Parse(txtOnAmt.Text);
                    objServiceTimelinesBEL.TransrefnoConfirmation = txtrefno.Text;
                    objServiceTimelinesBEL.amtreceivedConfirmation = decimal.Parse(txtamtreceived.Text);
                    if (Int32.Parse(drpOperate.SelectedValue.ToString()) > 2)
                    {
                        objServiceTimelinesBEL.CurrentStatus = Int32.Parse(drpOperate.SelectedValue.ToString());
                    }

                    Int32 retVal = objServiceTimelinesBLL.SetAccountClearenceRecords(objServiceTimelinesBEL);
                    // Int32 retVal = objServiceTimelinesBLL.ServicePacketCreationforaAllotment(objServiceTimelinesBEL);
                    if (retVal >= 0)
                    {
                        string str = string.Empty;
                        if (retVal >= 1) { str = "Data Saved Successfully"; }
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('" + str + "');", true);
                        //Bind_Announcement_List_GridView();
                        //BindGridInprocess();

                    }
                    else
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('Unable to create packet. Please Contact Administrator');", true);
                        return;
                    }


                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());


                }






            }
            else
            {

                string str = string.Empty;
                str = "Please check the I agree Check!";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "alert('" + str + "');", true);


            }
        }

        protected void btnAppliedthrough_Click(object sender, EventArgs e)
        {
            BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
        }

        protected void rdOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOnline.Checked)
            {

                txtTransDate.Text = string.Empty;
                txtTransID.Text = string.Empty;
                txtGateway.Text = string.Empty;
                txtOnAmt.Text = string.Empty;

                txtTransDate.Enabled = true;
                txtTransID.Enabled = true;
                txtGateway.Enabled = true;
                txtOnAmt.Enabled = true;

                txtamtreceived.Text = string.Empty;
                txtpayDate.Text = string.Empty;
                txtPayMethod.Text = string.Empty;
                txtrefno.Text = string.Empty;

                txtamtreceived.Enabled = false;
                txtpayDate.Enabled = false;
                txtPayMethod.Enabled = false;
                txtrefno.Enabled = false;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            }

            else
            {

                txtamtreceived.Text = string.Empty;
                txtpayDate.Text = string.Empty;
                txtPayMethod.Text = string.Empty;
                txtrefno.Text = string.Empty;

                txtamtreceived.Enabled = false;
                txtpayDate.Enabled = false;
                txtPayMethod.Enabled = false;
                txtrefno.Enabled = false;

                txtTransDate.Text = string.Empty;
                txtTransID.Text = string.Empty;
                txtGateway.Text = string.Empty;
                txtOnAmt.Text = string.Empty;

                txtTransDate.Enabled = true;
                txtTransID.Enabled = true;
                txtGateway.Enabled = true;
                txtOnAmt.Enabled = true;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());


            }

        }

        protected void rdOffline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOffline.Checked)
            {

                txtamtreceived.Text = string.Empty;
                txtpayDate.Text = string.Empty;
                txtPayMethod.Text = string.Empty;
                txtrefno.Text = string.Empty;

                txtamtreceived.Enabled = true;
                txtpayDate.Enabled = true;
                txtPayMethod.Enabled = true;
                txtrefno.Enabled = true;

                txtTransDate.Text = string.Empty;
                txtTransID.Text = string.Empty;
                txtGateway.Text = string.Empty;
                txtOnAmt.Text = string.Empty;

                txtTransDate.Enabled = false;
                txtTransID.Enabled = false;
                txtGateway.Enabled = false;
                txtOnAmt.Enabled = false;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());

            }

            else
            {
                txtTransDate.Text = string.Empty;
                txtTransID.Text = string.Empty;
                txtGateway.Text = string.Empty;
                txtOnAmt.Text = string.Empty;

                txtTransDate.Enabled = false;
                txtTransID.Enabled = false;
                txtGateway.Enabled = false;
                txtOnAmt.Enabled = false;


                txtamtreceived.Text = string.Empty;
                txtpayDate.Text = string.Empty;
                txtPayMethod.Text = string.Empty;
                txtrefno.Text = string.Empty;

                txtamtreceived.Enabled = true;
                txtpayDate.Enabled = true;
                txtPayMethod.Enabled = true;
                txtrefno.Enabled = true;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            }
        }

        protected void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgree.Checked)
            {
                btnSave.Enabled = true;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            }
            else
            {
                btnSave.Enabled = false;
                BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            }
        }

        protected void drpOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            //try
            //{

            //    if (int.Parse(drpOperate.SelectedValue) > 0)
            //    {


            //        SqlCommand command = con.CreateCommand();
            //        command.Connection = con;
            //        command.CommandText = ("update a set a.TicketStatus = '" + drpOperate.SelectedValue + "'   from ServiceTicket a where a.PacketID = '" + PacketId + "'  and ServiceName = '" + ServiceReqNo + "'  ");
            //        if (command.ExecuteNonQuery() > 0)
            //        {

            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);


            //            GeneralMethod gm = new GeneralMethod();
            //            TicketStatus = gm.GetServiceTicketStatusByUser(UserId, PacketId, ServiceReqNo);

            //            if (TicketStatus != "Open")
            //            {
            //                //txtTicketComment.Enabled = false;
            //                //ChangeTicketStatus.Enabled = false;
            //                DefaultSettingsDisabled();
            //            }


            //        }
            //        else
            //        {
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Some Issues occured. Please contact administrator')", true);
            //            //MessageBox1.ShowSuccess("Error Occured !");
            //            return;
            //        }





            //    }
            //    else
            //    {

            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Ticket Status')", true);

            //    }

            //    BindApplicableFees(drpReportName.SelectedItem.Text.ToString().Trim());
            //}
            //catch (Exception ex)
            //{ Response.Write("Oops! error occured :" + ex.Message.ToString()); }
        }




        //protected void call_function(string report_name)
        //{
        //    SqlCommand cmd2 = new SqlCommand("GetAllotteeMigrationCount_SP  NULL", con);
        //    SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
        //    DataSet ds = new DataSet();

        //    adp1.Fill(ds);


        //    DataTable dt = new DataTable();
        //    DataTable dt1 = new DataTable();

        //    try
        //    {
        //        dt = ds.Tables[0];
        //        dt1 = ds.Tables[1];
        //    }
        //    catch { }



        //    int i = 0;
        //    int comment1 = 6, comment2 = 6;
        //    string region_prev = "", region_cur = "";
        //    string comment_strDate1 = "", comment_strDate2 = "";
        //    string htmldata = "";

        //    ph.Controls.Clear();





        //    decimal total_count = 0, pre_sum = 0, sum_yesterday = 0, sum_today = 0, total_count_today = 0, total_count_yesterday = 0;
        //    htmldata = "";
        //    DateTime date_today = DateTime.Now;
        //    if (report_name == "Regional_Office")
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            total_count = Convert.ToDecimal(dt.Compute("SUM(completed)", string.Empty));
        //            string report_date = date_today.ToString("MMMM d, yyyy");


        //            htmldata = @"<span class=""pull-right font-bold"">Dated:  " + report_date + @"</span><br /><br /><h2 style = ""text-decoration:underline;"" > Accounts Clearence Statement </h2><br /><br />
        //              <span class=""pull-right font-bold""> Applicable Charges:  " + total_count + @"</span><br /><br />
        //                 <table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
        //                        <tr style='background:#f7f7f7;'> 
        //                        <th>Total Allottee Migrated As On Date</th><th class='text-center'>" + total_count + @"</th></tr>
        //                       <tr style='background:#f7f7f7;'> <th>Total Allottee Migrate On " + "to be changed" + "</th><th class='text-center'>" + total_count_today + @"</th></tr>
        //                     <tr style='background:#f7f7f7;'>   <th>Total Allottee Migrated As On " + "to be changed" + "</th><th class='text-center'>" + total_count_yesterday + @"</th>
        //                        </tr></table><br /><br /><br /><br />

        //              <table class=""table table-bordered table-hover request-table"">
        //                <tr style='background:#f7f7f7;'>
        //                    <th>S.NO</th>
        //                    <th>Industrial Area</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on Date( in Numbers)</th>
        //                </tr>";

        //            i = 0;
        //            foreach (DataRow dr in dt.Rows)
        //            {


        //                region_cur = dr["RegionalOffice"].ToString();

        //                comment_strDate1 = ""; comment_strDate2 = "";



        //                i++;


        //                if (region_cur == region_prev)
        //                {
        //                    htmldata += @"<tr> <td>" + i.ToString() + "</td>  <td style='width:70%'>" + dr["IAName"].ToString() + @"</td> <td class='text-center-imp'>" + dr["completed"].ToString() + @"</td> </tr>";
        //                }
        //                else
        //                {
        //                    if (i == 1)
        //                    {
        //                        htmldata += @"<tr><th colspan=""3"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  

        //                  <tr> 
        //                  <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["completed"].ToString() + @" </td> 
        //                 </tr>";

        //                    }
        //                    else
        //                    {
        //                        htmldata += @"<tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""2""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>



        //                                  <tr style='background:#f7f7f7;'><th colspan=""3"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + " </td >  <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td  class='text-center-imp'> " + dr["completed"].ToString() + @" </td> 
        //                 </tr>";
        //                        pre_sum = 0;



        //                    }

        //                }


        //                pre_sum = pre_sum + Convert.ToDecimal(dr["completed"].ToString());
        //                region_prev = region_cur;
        //            }
        //            htmldata += @"<tr style='background:#f7f7f7;'>
        //                                  <th colspan=""2""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>";

        //            htmldata += " </table>";

        //            Literal loLit = new Literal();
        //            loLit.Text = (htmldata);
        //            ph.Controls.Add(loLit);


        //        }
        //    }



        //    total_count = 0; pre_sum = 0; sum_yesterday = 0; sum_today = 0; total_count_today = 0; total_count_yesterday = 0;
        //    htmldata = "";

        //    if (report_name == "Employee_Wise")
        //    {
        //        if (dt1.Rows.Count > 0)
        //        {
        //            total_count = Convert.ToDecimal(dt1.Compute("SUM(CumTotal)", string.Empty));
        //            total_count_today = Convert.ToDecimal(dt1.Compute("SUM(Today)", string.Empty));
        //            total_count_yesterday = Convert.ToDecimal(dt1.Compute("SUM(CumYesterday)", string.Empty));
        //            string report_date = date_today.ToString("MMMM d, yyyy hh:mm:ss tt");
        //            string prev_report_date = DateTime.Now.AddDays(-1).ToString("MMM d");
        //            string report_date_f1 = date_today.ToString("MMM d");

        //            //htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><br /><h2 style = ""text-decoration:underline;"" > Daily Employee Wise Report: Allottee Migration</h2><br /><br />                
        //            //             <span class=""pull-right font-bold""><b>&nbsp;Total Allottee Migrated As On Date :  " + total_count + @"</b></span><br />
        //            //             <span class=""pull-right font-bold""><b>Total Allottee Migrated As On " + report_date_f1 +" :  " + total_count_today + @" </b></span><br />
        //            //             <span class=""pull-right font-bold""><b>&nbsp;&nbsp;Total Allottee Migrated As On " + prev_report_date + " :  " + total_count_yesterday + @" </b></span><br />

        //            htmldata = @"<span class=""pull-right font-bold""><b>Dated:  " + report_date + @"</b></span><br /><br /><h2 style = ""text-decoration:underline;"" > Daily Employee Wise Report: Allottee Migration</h2><br /><br /> 
        //                        <table class=""table-bordered pull-right"" width=""41%"" style=""Font-Size:12px;"">
        //                        <tr style='background:#f7f7f7;'> 
        //                        <th>Total Allottee Migrated As On Date</th><th class='text-center'>" + total_count + @"</th></tr>
        //                       <tr style='background:#f7f7f7;'> <th>Total Allottee Migrate On " + report_date_f1 + "</th><th class='text-center'>" + total_count_today + @"</th></tr>
        //                     <tr style='background:#f7f7f7;'>   <th>Total Allottee Migrated As On " + prev_report_date + "</th><th class='text-center'>" + total_count_yesterday + @"</th>
        //                        </tr></table><br /><br /><br /><br />



        //              <table class=""table table-bordered table-hover request-table"">
        //                <tr style='background:#f7f7f7;'>
        //                    <th>S.NO</th>
        //                    <th>Regional Office</th>
        //                    <th>Employee</th>
        //                    <th>Industrial Area</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on " + prev_report_date + @"</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on " + report_date_f1 + @"</th>
        //                    <th class=""text-center"">No of Allottees Migrated as on Date</th>
        //                </tr>";

        //            i = 0;
        //            foreach (DataRow dr in dt1.Rows)
        //            {


        //                region_cur = dr["RegionalOffice"].ToString();

        //                comment_strDate1 = ""; comment_strDate2 = "";

        //                i++;
        //                if (region_cur == region_prev)
        //                {
        //                    htmldata += @"
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td style='width:17%;'> " + dr["RegionalOffice"].ToString() + @" </td> <td style='width:17%;'> " + dr["CreatedBy"].ToString() + @" </td> <td style='width:17%;'> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                }
        //                else
        //                {

        //                    if (i == 1)
        //                    {
        //                        htmldata += @"
        //                   <tr><th colspan=""7"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td style='width:17%;'> " + dr["RegionalOffice"].ToString() + @" </td> <td style='width:17%;'> " + dr["CreatedBy"].ToString() + @" </td> <td style='width:17%;'> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                    }
        //                    else
        //                    {
        //                        htmldata += @"

        //                                <tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th><th  class='text-center-imp'>" + sum_yesterday + @"</th><th  class='text-center-imp'>" + sum_today + @"</th>
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>

        //                  <tr><th colspan=""7"">" + dr["RegionalOffice"].ToString() + @"</th></tr>  
        //                  <tr> 
        //                  <td> " + i.ToString() + "</td > <td> " + dr["RegionalOffice"].ToString() + @" </td> <td> " + dr["CreatedBy"].ToString() + @" </td> <td> " + dr["IAName"].ToString() + @" </td> 
        //                  <td class='text-center-imp'> " + dr["CumYesterday"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["Today"].ToString() + @" </td>
        //                  <td class='text-center-imp'> " + dr["CumTotal"].ToString() + @" </td>
        //                 </tr>";

        //                        pre_sum = 0; sum_yesterday = 0; sum_today = 0;

        //                    }




        //                }









        //                pre_sum = pre_sum + Convert.ToDecimal(dr["CumTotal"].ToString());
        //                sum_yesterday = sum_yesterday + Convert.ToDecimal(dr["CumYesterday"].ToString());
        //                sum_today = sum_today + Convert.ToDecimal(dr["Today"].ToString());
        //                region_prev = region_cur;
        //            }


        //            htmldata += @"<tr  style='background:#f7f7f7;'>
        //                                  <th colspan=""4""><span class=""pull-right"">Total " + region_prev + @"</span></th>
        //                                  <th class='text-center-imp'>" + sum_yesterday + @"</th> 
        //                                  <th class='text-center-imp'>" + sum_today + @"</th> 
        //                                  <th class='text-center-imp'>" + pre_sum + @"</th> 
        //                                  </tr>";

        //            htmldata += " </table>";

        //            Literal loLit = new Literal();
        //            loLit.Text = (htmldata);
        //            ph.Controls.Add(loLit);


        //        }
        //    }







        //}
    }
}