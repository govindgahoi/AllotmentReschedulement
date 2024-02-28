using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;



namespace Allotment
{

    public partial class AllotteeDashBoard : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        SqlConnection con = new SqlConnection();
        public int FromServer;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Percentage.Value = "80";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string allotmentNo = Session["UserName"].ToString();
            GetAllotteeDetails(allotmentNo);

        }

        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }

        public void GetAllotteeDetails(string allotementNo)
        {

            SqlCommand cmd = new SqlCommand("spc_GetAlloteeedashboardDetails '" + allotementNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            DataTable dt3 = ds.Tables[3];
            DataTable dt4 = ds.Tables[4];
            DataTable dt5 = ds.Tables[5];
            DataTable dt6 = ds.Tables[6];
            DataTable dt7 = ds.Tables[7];

            if (dt.Rows.Count > 0)
            {
                lblAuthorisedSignatory.Text = dt.Rows[0]["AuthorisedSignatory"].ToString();
                lblSignatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString();
                lblSignatoryPhone.Text = dt.Rows[0]["SignatoryPhone"].ToString();

                lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                lblPlotArea.Text = dt.Rows[0]["TotalAllottedplotArea"].ToString();
                lblIndArea.Text = dt.Rows[0]["IndustrialArea"].ToString();

                if (string.IsNullOrEmpty(dt.Rows[0]["CompanyName"].ToString().Trim()))
                {
                    lblCompanyName.Text = dt.Rows[0]["AllotteeName"].ToString();
                }
                else
                {
                    lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                }
                lblCompanyAddress.Text = dt.Rows[0]["Address"].ToString();
            }
            if (dt1.Rows.Count > 0) { AllotteePaymentGrid.DataSource = dt5; AllotteePaymentGrid.DataBind(); }
            { PlotHistoryGrid.DataSource = dt6; PlotHistoryGrid.DataBind(); }
            { AllotteePremiumGrid.DataSource = dt2; AllotteePremiumGrid.DataBind(); }
            { LeaseGrid.DataSource = dt3; LeaseGrid.DataBind(); }
            { MaintenanceGrid.DataSource = dt4; MaintenanceGrid.DataBind(); }
            { PScheduleGrid.DataSource = dt1; PScheduleGrid.DataBind(); }

            if (dt7.Rows.Count > 0)
            {
                if (dt7.Rows[0][1].ToString().Trim() == "0.00")
                {
                    duedatelbl.Visible = false;
                    Pay_Now.Attributes.Add("class", "btn btn-sm pay-now-btn disabled");
                }
                else
                {
                    lbl_DueDate.Text = dt7.Rows[0][0].ToString();
                    duedatelbl.Visible = true; ;
                    Pay_Now.Attributes.Add("class", "btn btn-sm pay-now-btn");
                }
                lbl_DueAmount.Text = dt7.Rows[0][1].ToString();
                Percentage.Value = dt7.Rows[0][2].ToString();
            }


        }



        protected void PaymentDue_Click(object sender, EventArgs e)
        {

            string redirecturl = "";
            string encryptredirecturl = "";
            string ASEKEY = "1362881115605021";
            string Reference_no = "", sub_merchant_id = "", pgamount = "0";

            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            string AllottementLetterNo = _objLoginInfo.userName;

            SqlCommand cmd1 = new SqlCommand(@"select top 1 [DueDate] ,[DemandNo], [GeneratedDate], ROUND(RTRIM(LTRIM([DueAmount])) ,2) DueAmount  from [dbo].[DemandNoteHeader]
                                                where  [AllotteeId] = '" + AllottementLetterNo + "'  and isnull(isActive, 'false') = 'true' order by DueDate desc ", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Reference_no = dt1.Rows[0]["DemandNo"].ToString().Trim();
                pgamount = dt1.Rows[0]["DueAmount"].ToString().Trim();


            }


            sub_merchant_id = "1";
            //    Mobile_No = ""; ;
            //    city = "your value";
            //    name = "your value";



            redirecturl += "https://eazypay.icicibank.com/EazyPG?";
            redirecturl += "merchantid=131561";
            redirecturl += "&mandatory fields=" + Reference_no + "|" + sub_merchant_id + "|" + pgamount;
            redirecturl += "&optional fields=" + AllottementLetterNo;
            redirecturl += "&returnurl=http://eservices.onlineupsidc.com/response.aspx";
            redirecturl += "&Reference No=" + Reference_no;
            redirecturl += "&submerchantid=" + sub_merchant_id;
            redirecturl += "&transaction amount=" + pgamount;
            redirecturl += "&paymode=9";


            encryptredirecturl += "https://eazypay.icicibank.com/EazyPG?";
            encryptredirecturl += "merchantid=131561";
            encryptredirecturl += "&mandatory fields=" + encryptFile(Reference_no + "|" + sub_merchant_id + "|" + pgamount, ASEKEY);
            encryptredirecturl += "&optional fields=" + encryptFile(AllottementLetterNo, ASEKEY);
            encryptredirecturl += "&returnurl=" + encryptFile("http://eservices.onlineupsidc.com/response.aspx", ASEKEY);
            encryptredirecturl += "&Reference No=" + encryptFile(Reference_no, ASEKEY);
            encryptredirecturl += "&submerchantid=" + encryptFile(sub_merchant_id, ASEKEY);
            encryptredirecturl += "&transaction amount=" + encryptFile(pgamount, ASEKEY);
            encryptredirecturl += "&paymode=" + encryptFile("9", ASEKEY);

            Response.Redirect(encryptredirecturl);


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