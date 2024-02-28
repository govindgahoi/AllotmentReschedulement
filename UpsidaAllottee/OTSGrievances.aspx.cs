using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class OTSGrievances : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string level;
        string IndustrialArea = "";
        string createdDate;
        string ComplaintID;
        #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");
        public decimal MC;
        public decimal INTEREST;
        public decimal INTERESTONMC;
        public decimal TotDues;
        public decimal TotInt;
        public decimal InstallmentValue;
        public decimal TotalOneTimeDues;
        public decimal rebate;
        public decimal amount;
        string ControlID = "";
        string Request_ID = "";
        string UnitID = "";
        string ServiceID = "";
        string NM_DistrictID = "";
        string ProcessIndustryID = "";
        string ApplicationID = "";
        string Pendancy_level = "";
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
        string Objection_Rejection_Code = "";
        string Is_Certificate_Valid_Life_Time = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                ComplaintID = Request.QueryString["ComplaintID"];
                Get_RaisedGrievance(ComplaintID);
                if(level == "Admin1")
                {
                    PanelHideForAdmin.Visible = false;
                }
                else
                {
                    PanelHideForAdmin.Visible = true;
                    RM.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("/loginpage.aspx");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/loginpage.aspx");
            }
            else
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                
            }
        }

        protected void Get_RaisedGrievance(string Com)
        {

            DataSet ds = new DataSet();
            string Paid = "";
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetRaisedGrievanceDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ComplaintID", Com);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];
                    
                    //AllotteeDiv.Visible = true;
                    lblregion.Text = dt1.Rows[0]["RegionalOffice"].ToString();
                    lblIA.Text = dt1.Rows[0]["IAName"].ToString();
                    LblPlot.Text = dt1.Rows[0]["PlotNo"].ToString();
                    lblAllotteeName.Text = dt1.Rows[0]["AllotteeName"].ToString();
                    lblComplaint.Text = dt1.Rows[0]["ComplaintID"].ToString();
                    lblDesc.Text = dt1.Rows[0]["ComplaintDescription"].ToString();
                    lblAllotteeComment.Text = dt1.Rows[0]["AllotteeComment"].ToString();
                    lblRMComment.Text = dt1.Rows[0]["RMComment"].ToString();

                    lblGrievanceIssue.Text = "Do you want to update (" + dt1.Rows[0]["ComplaintDescription"].ToString() + ") :";
                    createdDate = dt1.Rows[0]["DateOfComplaint"].ToString();
                    Label6.Text = "Interest on Maintenance Charge upto "+ createdDate + " :";
                    lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                    double TotInt = Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"]);
                    TotInt = Math.Round((Double)TotInt, 2);
                    lblInterest.Text = TotInt.ToString() + " /-";

                    double TotDues = Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"]) + Convert.ToDouble(dt2.Rows[0]["Dues"]);
                    TotDues = Math.Round((Double)TotDues, 2);
                    lblTotalDues.Text = TotDues.ToString() + " /-";

                    double rebate = (Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"])) / 2;
                    rebate = Math.Round((Double)rebate, 2);
                    lblRebate.Text = rebate.ToString() + " /-";
                    lblPayAmount.Text = (TotDues - rebate).ToString() + " /-";
                    switch (dt1.Rows[0]["ComplaintDescription"].ToString().Trim())
                    {
                        case "Incorrect Maintenance Charge":
                            MaintenanceInstruction.Visible = true;
                            OptionCourt.Visible = false;
                            OptionRadio.Visible = false;
                            break;
                        case "Incorrect Maintenance Charge due to difference in Plot Area":
                            MaintenanceInstruction.Visible = true;
                            OptionRadio.Visible = false;
                            OptionCourt.Visible = false;
                            break;
                        case "Incorrect Interest on Maintenance Charge":
                            MaintenanceInstruction.Visible = true;
                            OptionRadio.Visible = false;
                            OptionCourt.Visible = false;
                            break;
                        case "Incorrect Maintenance Charge and Interest on Maintenance Charge":
                            MaintenanceInstruction.Visible = true;
                            OptionRadio.Visible = false;
                            OptionCourt.Visible = false;
                            break;
                        case "Maintenance Charge Not Applicable":
                            lblGrievanceIssue.Text = "Is Maintenance Charge not Applicable? :";
                            OptionRadio.Visible = true;
                            
                            OptionCourt.Visible = false;
                            break;
                        case "Already Deposited":
                            MaintenanceInstruction.Visible = true;
                            OptionCourt.Visible = false;
                            break;
                        case "Disputed due to Court Case":
                            OptionCourt.Visible = true;
                            OptionRadio.Visible = false;
                            break;
                        default:
                            // code block
                            break;
                    }

                    //FilterDiv.Visible = false;

                }
                else
                {
                    //AllotteeDiv.Visible = false;
                    string msg = "Invalid Details";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void BindAllotteePaymentDetail(object sender, EventArgs e)
        {
            
        }
        protected void RadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            if (RadioOneTime.Checked)
            {
                MaintenanceInstruction.Visible = true;
            }
            else if (RadioButton1.Checked)
            {
                //panelYes.Visible = false;
                //panelNo.Visible = true;
            }
            else
            {
                //panelYes.Visible = false;
                //panelNo.Visible = false;
            }
        }
        protected void RadioButton1_CheckedChanged(Object sender, EventArgs e)
        {
            //if (RadioButton6.Checked)
            //{
            //    panel1.Visible = true;
            //}
            //else
            //{
            //    panel1.Visible = false;
            //}
        }
        protected void btn_Back(Object sender, EventArgs e)
        {
            Response.Redirect("/OTSGrievancesMIS.aspx");
        }

       protected void btn_Click(Object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                

                if (FileUpload2.HasFile)
                {

                    string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    string contentType = FileUpload2.PostedFile.ContentType;
                    using (Stream fs = FileUpload2.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_SetOTSRMResponse", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@ComplaintID", ComplaintID);
                                    cmd.Parameters.AddWithValue("@RMComment", txtComment.Text);
                                    cmd.Parameters.AddWithValue("@RMResponse", RadioButtonList1.SelectedValue);
                                    cmd.Parameters.AddWithValue("@RMDoc", bytes);
                                    cmd.Parameters.AddWithValue("@Doctype", contentType);
                                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    adp.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        GetApplicantDetails(dt,bytes);
                                        //Response.Redirect("~/OTSGrievancesMIS.aspx");
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "alert('Please fill all fields');", true);
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "call_show", "alert('Please upload pdf file.');", true);
                    //Mention Alert msg for File not uploaded
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void MailToAllottee(DataTable data,Byte[] Data)
        {
            string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = data.Rows[0]["AllotteeName"].ToString();
            string DateOFComplaint = data.Rows[0]["DateOFComplaint"].ToString();
            string allotteeID = data.Rows[0]["AllotteeID"].ToString();
            string CurrentDate = DateTime.Now.ToString();
            DataSet ds = detailOfAllotteeForMail(complaintId);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];
            if (ds.Tables.Count > 0)
            {
                string MaintenanceCharge = dt2.Rows[0]["Dues"].ToString() + " /-";

                double TotInt = Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"]);
                TotInt = Math.Round((Double)TotInt, 2);
                string InterestOnMC = TotInt.ToString() + " /-";

                double TotDues = Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"]) + Convert.ToDouble(dt2.Rows[0]["Dues"]);
                TotDues = Math.Round((Double)TotDues, 2);
                string TotalDues = TotDues.ToString() + " /-";

                double rebate = (Convert.ToDouble(dt2.Rows[1]["Dues"]) + Convert.ToDouble(dt2.Rows[0]["TotalInterest"])) / 2;
                rebate = Math.Round((Double)rebate, 2);
                string Rebate = rebate.ToString() + " /-";
                string PayAmount = (TotDues - rebate).ToString() + " /-";


                MemoryStream stream = new MemoryStream(Data);
                Attachment attach = new Attachment(stream, "Attachment.pdf", "application/pdf");
                string emailID = dt1.Rows[0]["emailID"].ToString();
                MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                MailAddress mailto = new MailAddress(emailID);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);
                newmsg.Attachments.Add(attach);
                newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/OTSDisposedOffMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
                StrContent = StrContent.Replace("{ComplaintID}", complaintId);
                StrContent = StrContent.Replace("{DateOFComplaint}", DateOFComplaint);
                StrContent = StrContent.Replace("{CurrentDate}", CurrentDate);
                StrContent = StrContent.Replace("{MaintenanceCharge}", MaintenanceCharge);
                StrContent = StrContent.Replace("{InterestOnMC}", InterestOnMC);
                StrContent = StrContent.Replace("{TotalDues}", TotalDues);
                StrContent = StrContent.Replace("{Waiver}", Rebate);
                StrContent = StrContent.Replace("{PayableAmount}", PayAmount);


                newmsg.Subject = "Complaint ID '" + complaintId + "' is resolved.";
                newmsg.Body = StrContent;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");

                smtp.EnableSsl = true;
                smtp.Send(newmsg);
            }
            else
            {

            }
        }
        protected void MailToAllotteeAlreadyApplied(DataTable data, DataTable dta)
        {
            string complaintId = data.Rows[0]["ComplaintID"].ToString();
            string allotteeName = data.Rows[0]["AllotteeName"].ToString();
            string DateOFComplaint = data.Rows[0]["DateOFComplaint"].ToString();
            string allotteeID = data.Rows[0]["AllotteeID"].ToString();
            string CurrentDate = DateTime.Now.ToString();
            DataSet ds = detailOfAllotteeForMail(complaintId);
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            if (ds.Tables.Count > 0)
            {
                string MaintenanceCharge = dta.Rows[0]["Dues"].ToString() + " /-";

                double TotInt = Convert.ToDouble(dta.Rows[1]["Dues"]) + Convert.ToDouble(dta.Rows[0]["TotalInterest"]);
                TotInt = Math.Round((Double)TotInt, 2);
                string InterestOnMC = TotInt.ToString() + " /-";

                double TotDues = Convert.ToDouble(dta.Rows[1]["Dues"]) + Convert.ToDouble(dta.Rows[0]["TotalInterest"]) + Convert.ToDouble(dta.Rows[0]["Dues"]);
                TotDues = Math.Round((Double)TotDues, 2);
                string TotalDues = TotDues.ToString() + " /-";

                double rebate = (Convert.ToDouble(dta.Rows[1]["Dues"]) + Convert.ToDouble(dta.Rows[0]["TotalInterest"])) / 2;
                rebate = Math.Round((Double)rebate, 2);
                string Rebate = rebate.ToString() + " /-";
                string PayAmount = (TotDues - rebate).ToString() + " /-";



                string emailID = dt1.Rows[0]["emailID"].ToString();
                MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                MailAddress mailto = new MailAddress(emailID);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);
                newmsg.IsBodyHtml = true;

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/OTSDisposedOffMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
                StrContent = StrContent.Replace("{ComplaintID}", complaintId);
                StrContent = StrContent.Replace("{DateOFComplaint}", DateOFComplaint);
                StrContent = StrContent.Replace("{CurrentDate}", CurrentDate);
                StrContent = StrContent.Replace("{MaintenanceCharge}", MaintenanceCharge);
                StrContent = StrContent.Replace("{InterestOnMC}", InterestOnMC);
                StrContent = StrContent.Replace("{TotalDues}", TotalDues);
                StrContent = StrContent.Replace("{Waiver}", Rebate);
                StrContent = StrContent.Replace("{PayableAmount}", PayAmount);


                newmsg.Subject = "Complaint ID '" + complaintId + "' is resolved.";
                newmsg.Body = StrContent;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");

                smtp.EnableSsl = true;
                smtp.Send(newmsg);
            }
            else
            {

            }
        }

        protected DataSet detailOfAllotteeForMail(string ID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetRaisedGrievanceDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ComplaintID", ID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                    return ds;
            }
            catch (Exception ex)
            {
                throw;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Detail');", true);
            }

        }

        protected void GetApplicantDetails(DataTable dt, Byte[] byt)
        {
            DataSet ds1 = new DataSet();
            try
            {
                ds1 = GetAllotteeRecordToBindForOTSScheme(LblPlot.Text.Trim(), lblIA.Text.Trim());
                if (ds1.Tables.Count > 0)
                {
                    DataTable dt1 = ds1.Tables[0];
                    DataTable dt2 = ds1.Tables[1];
                    //AllotteeDiv.Visible = true;
                    string allotteeID = dt1.Rows[0]["AllotteeID"].ToString();

                    //If allottee Already Applied
                    DataTable dt7 = new DataTable();
                    SqlCommand cmd = new SqlCommand("select * from OTS_NMSWPTransactionDetail where AllotteeID='"+ allotteeID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt7);
                    if (dt7.Rows.Count > 0)
                    {
                        int sType = Convert.ToInt32(dt7.Rows[0]["SchemeType"]);
                        ControlID = dt7.Rows[0]["ControlID"].ToString();
                        UnitID = dt7.Rows[0]["UnitID"].ToString();
                        ServiceID = dt7.Rows[0]["ServiceID"].ToString();
                        Request_ID = dt7.Rows[0]["RequestID"].ToString();
                        if (sType == 0)
                        {
                            MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);
                            INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                            string IntDues = (Convert.ToDouble(INTEREST) < 0) ? "0.00" : INTEREST.ToString();

                            INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                            string IntOnMCDues = (Convert.ToDouble(INTERESTONMC) < 0) ? "0.00" : INTERESTONMC.ToString();
                            //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                            TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                            TotInt = Math.Round((decimal)TotInt, 2);

                            TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(MC);
                            TotDues = Math.Round((decimal)TotDues, 2);

                            rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                            rebate = Math.Round((decimal)rebate, 2);
                            TotalOneTimeDues = (TotDues - rebate);
                            InstallmentValue = (TotDues - rebate) / 4;
                            InstallmentValue = Math.Round((decimal)InstallmentValue, 2);
                            DataTable dst1 = UpdateServiceRequestForOTS(allotteeID, MC, INTEREST, TotInt, InstallmentValue, TotalOneTimeDues);
                            if (dst1.Rows.Count > 0)
                            {
                                btnclick.Enabled = false;
                                string type = "success";
                               // MailToAllotteeAlreadyApplied();
                                MailToAllottee(dt,byt);
                                //Test
                             //string updt_NMSWP1=  FeeStatusNM_Click(ControlID, UnitID, ServiceID, TotalOneTimeDues.ToString(), "UB", "OTS Fee Pending", "Applicant", Request_ID);
                             string updt_NMSWP1= OTSScheme_AppliedStatus_OnNM(ControlID, UnitID, ServiceID, Request_ID); 
                                if (updt_NMSWP1 == "Success")
                                {
                                    //var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                    //var script = string.Format("alert({0});window.location ='http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Dashboard.aspx';", message);
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", script, true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + type + "');", true);
                                }
                            }
                            else
                            {
                                btnclick.Enabled = true;
                                string type = "Not Submitted";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + type + "');", true);
                            }
                        }
                        else
                        {
                            MC = (String.IsNullOrEmpty(dt2.Rows[0]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["Dues"]);
                            INTEREST = (String.IsNullOrEmpty(dt2.Rows[1]["Dues"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[1]["Dues"]);
                            string IntDues = (Convert.ToDouble(INTEREST) < 0) ? "0.00" : INTEREST.ToString();

                            INTERESTONMC = (String.IsNullOrEmpty(dt2.Rows[0]["TotalInterest"].ToString())) ? 0 : Convert.ToDecimal(dt2.Rows[0]["TotalInterest"]);
                            string IntOnMCDues = (Convert.ToDouble(INTERESTONMC) < 0) ? "0.00" : INTERESTONMC.ToString();
                            //lblMaintenanceCharge.Text = dt2.Rows[0]["Dues"].ToString() + " /-";

                            TotInt = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues);
                            TotInt = Math.Round((decimal)TotInt, 2);

                            TotDues = Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues) + Convert.ToDecimal(MC);
                            TotDues = Math.Round((decimal)TotDues, 2);

                            rebate = (Convert.ToDecimal(IntDues) + Convert.ToDecimal(IntOnMCDues)) / 2;
                            rebate = Math.Round((decimal)rebate, 2);
                            TotalOneTimeDues = (TotDues - rebate);
                            InstallmentValue = (TotDues - rebate) / 4;
                            InstallmentValue = Math.Round((decimal)InstallmentValue, 2);
                            
                            DataTable dst1 = UpdateServiceRequestForOTS(allotteeID, MC, INTEREST, TotInt, InstallmentValue, InstallmentValue);
                            if (dst1.Rows.Count > 0)
                            {
                                btnclick.Enabled = false;
                                string type = "Success";
                                
                                MailToAllottee(dt, byt);
                                //Test
                               string updt_NMSWP= OTSScheme_AppliedStatus_OnNM(ControlID, UnitID, ServiceID, Request_ID);
                                if (updt_NMSWP == "Success")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + type + "');", true);
                                }
                            }
                            else
                            {
                                btnclick.Enabled = true;
                                string type = "Not Submitted";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + type + "');", true);
                            }
                        }
                    }
                    else
                    {
                        btnclick.Enabled = false;
                        string type = "Success";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "javascript:showSwal('" + type + "');", true);
                        MailToAllottee(dt, byt);
                    }
                }
                
                //FilterDiv.Visible = false;

            }catch(Exception ex)
            {

            }
        }
        protected DataTable UpdateServiceRequestForOTS(string allotteeID, decimal MC, decimal INTEREST, decimal TotInt, decimal InstallmentValue, decimal amount)
        {
            DataTable ds11 = new DataTable();
            SqlCommand cmd = new SqlCommand("[usp_UpdateServiceRequestForOTS_NMSWP]", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@AllotteeID", allotteeID);
            cmd.Parameters.AddWithValue("@MaintenanceCharge", MC);
            cmd.Parameters.AddWithValue("@InterestOnMaintenanceUpTo30621 ", INTEREST);
            cmd.Parameters.AddWithValue("@InterestOnMCUpto", TotInt);
            cmd.Parameters.AddWithValue("@Installment1", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment2", InstallmentValue);
            cmd.Parameters.AddWithValue("@Installment3", InstallmentValue);
            cmd.Parameters.AddWithValue("@downpayment", amount);
            cmd.Parameters.AddWithValue("@service", 2000);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds11);
            return ds11;
        }
        protected DataSet GetAllotteeRecordToBindForOTSScheme(string plotNo, string IndustrialArea)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Plot_OTSDetail_OnRMResolved", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlotNo", plotNo);
                cmd.Parameters.AddWithValue("@IndustrialArea", IndustrialArea);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        protected string FeeStatusNM_Click(string ControlID, string UnitID, string ServiceID, string Fee_Amount, string Fee_Status, string Remarks, string Pendancy_level, string Request_ID)
        {
            string Update_Result = "";
            Status_Code = "12";
            try
            {
                if (ControlID.Length > 0)
                {
                    UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    Update_Result = webService.WReturn_CUSID_STATUS(
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
                return Update_Result;
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        //Test
        protected string OTSScheme_AppliedStatus_OnNM(string controlid, string unitid, string serviceid, string requestid)
        {
            ControlID = controlid;
            UnitID = unitid;
            ServiceID = serviceid;
            Request_ID = requestid;
            Status_Code = "10";
            Remarks = "OTS Fee Pending | Applicant";
            Pendancy_level = "Applicant";

            UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new UpsidaAllottee.ServiceReference1.upswp_niveshmitraservicesSoapClient();
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
            Request_ID
, Objection_Rejection_Code, Is_Certificate_Valid_Life_Time, Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
            );
            return Update_Result;
        }


    }
}