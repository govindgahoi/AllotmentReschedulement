using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Net.Mail;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class ChangeStatusNiveshPaid : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string ControlID = "";
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
        string SerReqNo;
        string Type = "";
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
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        }


        protected void btnSample_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                SqlCommand cmmd = new SqlCommand("GetNiveshMitraApp", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
                    string ControlIDIn = dt.Rows[i][0].ToString();
                    string UnitIDIn = dt.Rows[i][1].ToString();
                    string ServiceIDIn = dt.Rows[i][2].ToString();
                    string Request_ID_IN = "";
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet dss = webService.WGetUBPaymentDetails(ControlIDIn, UnitIDIn, ServiceIDIn, passsalt, Request_ID_IN);
                    
                    string Status_Code = "10";
                    string Remarks = "";

                     Remarks = "nivesh Mitra Fee Paid.Kindly Proceed to fill rest of the form";
                     string Update_Result = webService.WReturn_CUSID_STATUS(
                     ControlIDIn,
                     UnitIDIn,
                     ServiceIDIn,
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

            }
            catch (Exception ex)
            {
              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress("priyu.7nov@gmail.com");
                MailMessage newmsg = new MailMessage(mailfrom, mailto);


                string StrContent = ex.ToString();

                newmsg.Subject = "UPSIDCeServe: Payment Acknowledgement-Request for Land Allotment";
                newmsg.BodyHtml = StrContent;
                //newmsg.IsBodyHtml = true;

                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                //smtp.EnableSsl = true;
                //smtp.Send(newmsg);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);

            }
            finally
            {

                con.Close();

            }
        }


    }
}