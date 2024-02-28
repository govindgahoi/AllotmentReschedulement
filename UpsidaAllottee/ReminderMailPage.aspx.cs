using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class ReminderMailPage : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
           //MailToAllotteeAfterPaid("UPSWP19038875702", "SC21033", 1);
            get_AllotteeForReminder();
        }
        protected void get_AllotteeForReminder()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select ONT.UnitID,ONT.SchemeType from OTS_NMSWPTransactionDetail ONT join OTS_NMSWPInstalmentTransactionDetail OT on ONT.UnitID=OT.UnitID where (Fee_Amount_Paid = 'Paid' and Balance_Amount is not null) or(SchemeType = 1) ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dtRow in dt.Rows)
                {
                    string unitID = dtRow["UnitID"].ToString();
                    int schemeType = Convert.ToInt32(dtRow["SchemeType"]);
                    MailToAllotteeAfterPaid(unitID, "SC21033", schemeType);
                    
                }
            }
        }
        protected void MailToAllotteeAfterPaid(string unitid, string serviceid, int schemeType)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select AM.AllotteeName, AM.AllotteeID,AM.PhoneNo, ONT.* from OTS_NMSWPTransactionDetail ONT join AllotteeMaster AM on AM.AllotteeID = Try_Cast(ONT.AllotteeID as int) join OTS_NMSWPInstalmentTransactionDetail OT on ONT.UnitID=OT.UnitID where  ONT.UnitID='" + unitid + "' and ONT.ServiceID='" + serviceid + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string remainingAmount;
                string paidAmount;
                string allotteeName = dt.Rows[0]["AllotteeName"].ToString();
                string allotteeID = dt.Rows[0]["AllotteeID"].ToString();
                string contactNo = dt.Rows[0]["PhoneNo"].ToString();
                string applicationDate = (Convert.ToDateTime(dt.Rows[0]["ApplicationDate"])).ToString("dd/MM/yyyy");
                string totalDues = (Convert.ToDouble(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDouble(dt.Rows[0]["InterestOnMCUpto"])).ToString();
                string PayableAmount = (Convert.ToDouble(dt.Rows[0]["MaintenanceCharge"]) + Convert.ToDouble(dt.Rows[0]["InterestOnMCUpto"]) - Convert.ToDouble(dt.Rows[0]["Waive_Off"])).ToString();
                string waiver = dt.Rows[0]["Waive_Off"].ToString();
                int flg = Convert.ToInt32(dt.Rows[0]["Flag"]);
                string downpayment = dt.Rows[0]["DownPayment"].ToString();
                string lblFirstInstalmentAmount = dt.Rows[0]["Installment-1"].ToString();
                string lblSecInstalmentAmount = dt.Rows[0]["Installment-2"].ToString();
                string lblThirdInstalmentAmount = dt.Rows[0]["Installment-3"].ToString();
                string lblDownPaymentStatus;
                string lblDownPaymentDate = "";
                string lblFirstStatus;
                string lblFirstInstDate = "";
                string lblSecStatus;
                string lblSecInstDate = "";
                string lblThirdStatus;
                string lblThirdInstDate = "";
                string dueDate="";
                #region schemeType=0
               
                    paidAmount = dt.Rows[0]["Fee_Amount"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["Balance_Amount"].ToString()) == false)
                    {
                        remainingAmount = dt.Rows[0]["Balance_Amount"].ToString();
                    }
                    else
                    {
                        remainingAmount = "Nil";
                    }

                #endregion
                #region schemeType=1
                switch (flg)
                {
                    case 1:
                        dueDate = Convert.ToDateTime(dt.Rows[0]["DueDate-1"]).ToString("dd/MM/yyyy");
                        break;
                    case 2:
                        dueDate = Convert.ToDateTime(dt.Rows[0]["DueDate-2"]).ToString("dd/MM/yyyy");
                        break;
                    case 3:
                        dueDate = Convert.ToDateTime(dt.Rows[0]["DueDate-3"]).ToString("dd/MM/yyyy");
                        break;
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["Transaction_ID"].ToString()) == false)
                {
                    lblDownPaymentStatus = "Paid";
                    lblDownPaymentDate = Convert.ToDateTime(dt.Rows[0]["Transaction_Date"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblDownPaymentStatus = "Pending";

                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-1"].ToString()) == false)
                {
                    lblFirstStatus = "Paid";
                    lblFirstInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date1"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblFirstStatus = "Pending";
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-2"].ToString()) == false)
                {
                    lblSecStatus = "Paid";
                    lblSecInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date2"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblSecStatus = "Pending";
                }
                if (string.IsNullOrEmpty(dt.Rows[0]["TransactionDate-3"].ToString()) == false)
                {
                    lblThirdStatus = "Paid";
                    lblThirdInstDate = Convert.ToDateTime(dt.Rows[0]["Inst_Trans_Date3"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblThirdStatus = "Pending";
                }

                #endregion



                string emailID = detailOfAllotteeForMail1(allotteeID);
                MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                MailAddress mailto = new MailAddress(emailID);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                newmsg.IsBodyHtml = true;

                string StrContent = "";
                //StreamReader reader = new StreamReader(Server.MapPath("~/OTSPaidStatusMail.html"));
                StreamReader reader;
                if (schemeType == 0)
                {
                    reader = new StreamReader(Server.MapPath("~/OTSReminderMail.html"));
                    StrContent = reader.ReadToEnd();
                }
                else if (schemeType == 1)
                {
                    reader = new StreamReader(Server.MapPath("~/OTS_InstalmentReminderMail.html"));
                    StrContent = reader.ReadToEnd();
                }

                StrContent = StrContent.Replace("{AllotteeName}", allotteeName.Trim());
                StrContent = StrContent.Replace("{emailID}", emailID.Trim());
                StrContent = StrContent.Replace("{contactNo}", contactNo.Trim());
                StrContent = StrContent.Replace("{TotalDues}", totalDues.Trim());
                StrContent = StrContent.Replace("{Waiver}", waiver.Trim());
                StrContent = StrContent.Replace("{PayableAmount}", PayableAmount.Trim());
                StrContent = StrContent.Replace("{downpayment}", downpayment.Trim());
                StrContent = StrContent.Replace("{AmountPaid}", paidAmount.Trim());
                StrContent = StrContent.Replace("{RemainingAmount}", remainingAmount.Trim());
                StrContent = StrContent.Replace("{DownPaymentAmount}", downpayment.Trim());
                StrContent = StrContent.Replace("{lblFirstInstalmentAmount}", lblFirstInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblSecInstalmentAmount}", lblSecInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblThirdInstalmentAmount}", lblThirdInstalmentAmount.Trim());
                StrContent = StrContent.Replace("{lblDownPaymentStatus}", lblDownPaymentStatus.Trim());
                StrContent = StrContent.Replace("{lblFirstStatus}", lblFirstStatus.Trim());
                StrContent = StrContent.Replace("{lblSecStatus}", lblSecStatus.Trim());
                StrContent = StrContent.Replace("{lblThirdStatus}", lblThirdStatus.Trim());
                StrContent = StrContent.Replace("{lblDownPaymentDate}", lblDownPaymentDate);
                StrContent = StrContent.Replace("{lblFirstInstDate}", lblFirstInstDate.Trim());
                StrContent = StrContent.Replace("{lblSecInstDate}", lblSecInstDate.Trim());
                StrContent = StrContent.Replace("{lblThirdInstDate}", lblThirdInstDate.Trim());
                StrContent = StrContent.Replace("{DueDate}", dueDate);


                newmsg.Subject = "Reminder: Payment Due in OTS Scheme.";
                newmsg.Body = StrContent;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");

                smtp.EnableSsl = true;
                smtp.Send(newmsg);
                WriteToFile("Reminder Mail To " + allotteeName + "/" + schemeType + "/" + DateTime.Now);
            }
        }
        protected string detailOfAllotteeForMail1(string AllotteeID)
        {
            DataTable dt;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end from AllotteeMaster  where AllotteeID='" + AllotteeID + "' and IsCompleted=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

                return dt.Rows[0][0].ToString().Trim();
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\NiveshMitraOTSServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }


    }
}