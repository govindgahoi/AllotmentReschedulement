using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class UC_Service_Payment_Detail : System.Web.UI.UserControl
    {

        SqlConnection con = new SqlConnection();

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";

        public Label AllotmentNo
        {
            get
            {
                return lblAllotmentNo;
            }
            set
            {
                lblAllotmentNo = value;
            }
        }




        public string AllotteeId { get; set; }
        public string SerReqID { get; set; }



        string ControlID = "";
        string SWCRequest_ID = "";
        string UnitID = "";
        string ServiceID = "";
        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";






        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                //   LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                //   UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }


            if (string.IsNullOrEmpty(AllotteeId)) { AllotteeId = ""; }

            if (AllotmentNo.Text.Length > 0 || AllotteeId.Length > 0)
            {
                uc_alloottee_details.Visible = true;
                bindUserData(AllotmentNo.Text, AllotteeId);





                /////////////////////////////////////////////////////////////////////////////////////////
                string[] SerIdarray = SerReqID.Split('/');
                string service_id = SerIdarray[1];

                SqlCommand cmd = new SqlCommand("select Allotmentletterno, ControlId, UnitId,ServiceId  from [dbo].[AllotteeMaster] where [AllotteeID] = '" + AllotteeId + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                NOC_Certificate_Number = dt.Rows[0]["Allotmentletterno"].ToString().Trim();
                ControlID = dt.Rows[0]["ControlId"].ToString();
                UnitID = dt.Rows[0]["UnitId"].ToString();

                if (service_id.Trim() == "1" || service_id.Trim() == "2")
                {
                    if (ControlID == "" || ControlID == null)
                    {
                        PayTr.Visible = true;
                        PayTr1.Visible = false;
                        PaymentStatus(SerReqID);
                    }
                    else
                    {
                        ServiceID = "SC21002";
                        PayTr.Visible = false;
                        PayTr1.Visible = true;
                        PaymentStatus(SerReqID);
                    }
                }
                else
                {
                    PayTr.Visible = true;
                    PayTr1.Visible = false;
                    ServiceID = dt.Rows[0]["ServiceId"].ToString();
                }
                /////////////////////////////////////////////////////////////////////////






                //if (ControlID.Length > 0)
                //{

                //    if (ServiceID.Trim() == "SC21001")
                //    {
                //        Status_Code = "05";
                //        Remarks = "Request is Forwarded by " + lblRole.Text.Trim() + " To " + ddlTransfer.SelectedValue.Trim();

                //    }


                //    if (ServiceID.Trim() == "SC21002")
                //    {
                //        Status_Code = "05";
                //        Remarks = "Request is Forwarded by " + lblRole.Text.Trim() + " To " + ddlTransfer.SelectedValue.Trim();
                //    }


                //    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                //    string Update_Result = webService.WReturn_CUSID_STATUS(
                //     ControlID,
                //     UnitID,
                //     ServiceID,
                //     ProcessIndustryID,
                //     ApplicationID,
                //     Status_Code,
                //     Remarks,
                //     Fee_Amount,
                //     Fee_Status,
                //     Transaction_ID,
                //     Transaction_Date,
                //     Transaction_Date_Time,
                //     NOC_Certificate_Number,
                //     NOC_URL,
                //     ISNOC_URL_ActiveYesNO,
                //     passsalt
                //     );

                //}







            }
            else
            {
                uc_alloottee_details.Visible = false;
            }
        }

        public void PaymentStatus(string SerReqNo)
        {
            SqlCommand cmd = new SqlCommand("Select PaymentMode From ServiceRequests Where ServiceRequestNo='" + SerReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string PaymentMode = dt.Rows[0]["PaymentMode"].ToString().Trim();
                if (PaymentMode == "SWP")
                {
                    try
                    {
                        ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                        DataSet dss = webService.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt,SWCRequest_ID);

                        DataTable dtt = dss.Tables[0];
                        if (dtt.Rows.Count > 0)
                        {
                            Status_lbl.Attributes.Add("style", "color:#ffc511");
                            string status_code = dtt.Rows[0]["Status_Code"].ToString();
                            if (status_code == "11")
                            {
                                Status_lbl.Text = "Payment Received By Single Window Portal";
                                btnPayNow.Visible = false;

                            }
                            if (status_code == "12")
                            {
                                Status_lbl.Text = "Payment Pending To Single Window Portal";
                                btnPayNow.Visible = false;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured -A.A :" + ex.Message.ToString());
                    }
                }
            }

        }


        public void bindUserData(string allottee, string allotteeId)
        {
            decimal tt_total = 0;
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                objServiceTimelinesBEL.AllotmentNo = lblAllotmentNo.Text;


                if (!string.IsNullOrEmpty(AllotteeId))
                {
                    objServiceTimelinesBEL.AllotteeID = int.Parse(AllotteeId);

                }


                string serviceId = "";

                if (!string.IsNullOrEmpty(SerReqID))
                {
                    string[] SerIdarray = SerReqID.Split('/');
                    serviceId = SerIdarray[1];

                }

                SqlCommand cmd1;
                if (serviceId.Length > 0)
                {
                    cmd1 = new SqlCommand("service_charges_and_dues '" + serviceId + "', '" + lblAllotmentNo.Text + "' ,'" + SerReqID + "' ", con);
                }
                else
                {
                    cmd1 = new SqlCommand("service_charges_and_dues  NULL, '" + lblAllotmentNo.Text + "', '" + SerReqID + "' ", con);
                }

                SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                DataSet dss = new DataSet();
                DataTable prc1 = new DataTable();
                DataTable prc2 = new DataTable();
                adp.Fill(dss);
                prc1 = dss.Tables[1];
                prc2 = dss.Tables[0];

                GridView1.DataSource = prc1;
                GridView1.DataBind();
                GridView2.DataSource = prc2;
                GridView2.DataBind();

                if (prc1.Rows.Count > 0)
                {
                    //Calculate Sum and display in Footer Row
                    decimal total = prc1.AsEnumerable().Sum(row => row.Field<decimal>("Ammount"));
                    GridView1.FooterRow.Cells[0].Text = "Total";
                    GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[1].Text = total.ToString("N2");
                    tt_total += total;
                }
                if (prc2.Rows.Count > 0)
                {
                    DemandNoteDiv.Visible = true;
                    //Calculate Sum and display in Footer Row
                    decimal total = prc2.AsEnumerable().Sum(row => row.Field<decimal>("Ammount"));
                    GridView2.FooterRow.Cells[0].Text = "Total";
                    GridView2.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    GridView2.FooterRow.Cells[1].Text = total.ToString("N2");
                    tt_total += total;
                }
                else
                {
                    DemandNoteDiv.Visible = false;
                }
                lblTotalAmount.Text = tt_total.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-p :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void btnPayNow_Click(object sender, EventArgs e)
        {
            if (ControlID.Length > 0)
            {
                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    command = new SqlCommand(@"update ServiceRequests set PaymentMode='SWP' where ServiceRequestNO=@SerReqNo", con, transaction);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@SerReqNo", SerReqID.Trim());





                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));





                    if (transactionResult)
                    {
                        transaction.Commit();
                        ProcessIndustryID = AllotteeId;
                        ApplicationID = AllotteeId;

                        Status_Code = "12";
                        Fee_Amount = lblTotalAmount.Text;
                        Fee_Status = "UB";


                        if (ControlID.Length > 0)
                        {
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                             ControlID,
                             UnitID,
                             ServiceID,
                             ProcessIndustryID,
                             ApplicationID,
                             Status_Code,
                             Remarks,
                             Pendancy_level,
                             Fee_Amount,
                             Fee_Status,
                             Transaction_ID,
                             Transaction_Date,
                             Transaction_Date_Time,
                             NOC_Certificate_Number,
                             NOC_URL,
                             ISNOC_URL_ActiveYesNO,
                             passsalt,
                             Request_ID, 
                             Objection_Rejection_Code, 
                             Is_Certificate_Valid_Life_Time, 
                             Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
                             );
                        }
                        PaymentStatus(SerReqID);

                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Error";

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                        return;
                    }

                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }







            }
            else
            {
                if (PayTypeRadio.SelectedValue == "Offline")
                {
                    string error = "";
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                    command.Connection = con;
                    command.Transaction = transaction;
                    bool transactionResult = true;
                    try
                    {
                        command = new SqlCommand(@"update ServiceRequests set PaymentMode='Offline' where ServiceRequestNO=@SerReqNo", con, transaction);
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@SerReqNo", SerReqID.Trim());





                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));





                        if (transactionResult)
                        {
                            transaction.Commit();
                            PaymentStatus(SerReqID);
                            string message = "Complete Your Payment Through Offline Mode And Continue";

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                        }
                        else
                        {
                            transaction.Rollback();
                            string message = "Error";

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        error += "Commit Exception Type: " + ex.GetType();
                        error += "  Message: " + ex.Message;
                        Response.Write(error);

                        try
                        { transaction.Rollback(); }

                        catch (Exception ex2)
                        {
                            error += "Rollback Exception Type:" + ex2.GetType();
                            error += " Message: " + ex2.Message;
                            Response.Write(error);
                        }

                    }

                    finally
                    {
                        transaction.Dispose();
                        con.Close();

                    }


                }
                else if (PayTypeRadio.SelectedValue == "Online")
                {
                    string redirecturl = "";
                    string encryptredirecturl = "";
                    string ASEKEY = "1362881115605021";
                    string Reference_no = "", sub_merchant_id = ""; decimal pgamount = 0;



                    if (lblTotalAmount.Text == "" || lblTotalAmount.Text == null)
                    {
                        pgamount = 0;
                    }
                    else
                    {
                        pgamount = Convert.ToDecimal(lblTotalAmount.Text);
                    }

                    Reference_no = "BuildingPlanApproval" + "/" + SerReqID.Trim();


                    sub_merchant_id = "1";



                    redirecturl += "https://eazypay.icicibank.com/EazyPG?";
                    redirecturl += "merchantid=131561";
                    redirecturl += "&mandatory fields=" + Reference_no + "|" + sub_merchant_id + "|" + pgamount;
                    redirecturl += "&optional fields=" + Reference_no;
                    redirecturl += "&returnurl=http://eservices.onlineupsidc.com/response.aspx";
                    redirecturl += "&Reference No=" + Reference_no;
                    redirecturl += "&submerchantid=" + sub_merchant_id;
                    redirecturl += "&transaction amount=" + pgamount;
                    redirecturl += "&paymode=9";


                    encryptredirecturl += "https://eazypay.icicibank.com/EazyPG?";
                    encryptredirecturl += "merchantid=131561";
                    encryptredirecturl += "&mandatory fields=" + encryptFile(Reference_no + "|" + sub_merchant_id + "|" + pgamount, ASEKEY);
                    encryptredirecturl += "&optional fields=" + encryptFile(Reference_no, ASEKEY);
                    encryptredirecturl += "&returnurl=" + encryptFile("http://eservices.onlineupsidc.com/response.aspx", ASEKEY);
                    encryptredirecturl += "&Reference No=" + encryptFile(Reference_no, ASEKEY);
                    encryptredirecturl += "&submerchantid=" + encryptFile(sub_merchant_id, ASEKEY);
                    encryptredirecturl += "&transaction amount=" + encryptFile(pgamount.ToString(), ASEKEY);
                    encryptredirecturl += "&paymode=" + encryptFile("9", ASEKEY);

                    Response.Redirect(encryptredirecturl);
                }
            }
        }
        public static string encryptFile(string textToEncrypt, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.ECB;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) { len = keyBytes.Length; }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }
    }
}