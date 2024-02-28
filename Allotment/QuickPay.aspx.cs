using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;



namespace Allotment
{
    public partial class QuickPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            lblResponse.Text = string.Empty;
            if (txtAllotmentLetterNo.Text.Length < 4)
            {
                lblResponse.Text = "Please Enter Allotment Letter No.";
                return;
            }
            var dsR = new DataSet();
            try
            {
                var objBal = new BLL_Allotment.BooksDetails_BLL();
                dsR = objBal.GetAllotteeDueAmount(txtAllotmentLetterNo.Text);
                gdvDue.DataSource = dsR;
                gdvDue.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void gdvDue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblResponse.Text = string.Empty;
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string tranId = gdvDue.DataKeys[rowIndex]["TransactionId"].ToString();
                string allotmentLetterNo = (string)this.gdvDue.DataKeys[rowIndex]["Allotmentletterno"];
                GridViewRow row = gdvDue.Rows[rowIndex];

                string amount = row.Cells[3].Text;
                string mobile = row.Cells[4].Text;
                if (Convert.ToDecimal(amount) < 1)
                {
                    lblResponse.Text = "Minimum Acceptable amount is Rs. 1.00/-";
                    return;
                }


                string redirecturl = "";
                string encryptredirecturl = "";
                string ASEKEY = "1362881115605021";
                string Reference_no, sub_merchant_id, pgamount, Mobile_No, city, name;

                Reference_no = tranId;
                sub_merchant_id = "1";
                pgamount = amount.ToString();
                Mobile_No = mobile; ;
                city = "your value";
                name = "your value";



                redirecturl += "https://eazypay.icicibank.com/EazyPG?";
                redirecturl += "merchantid=131561";
                redirecturl += "&mandatory fields=" + Reference_no + "|" + sub_merchant_id + "|" + pgamount;
                redirecturl += "&optional fields=" + allotmentLetterNo;
                redirecturl += "&returnurl=http://eservices.onlineupsidc.com/response.aspx";
                redirecturl += "&Reference No=" + Reference_no;
                redirecturl += "&submerchantid=" + sub_merchant_id;
                redirecturl += "&transaction amount=" + pgamount;
                redirecturl += "&paymode=9";


                encryptredirecturl += "https://eazypay.icicibank.com/EazyPG?";
                encryptredirecturl += "merchantid=131561";
                encryptredirecturl += "&mandatory fields=" + encryptFile(Reference_no + "|" + sub_merchant_id + "|" + pgamount, ASEKEY);
                encryptredirecturl += "&optional fields=" + encryptFile(allotmentLetterNo, ASEKEY);
                encryptredirecturl += "&returnurl=" + encryptFile("http://eservices.onlineupsidc.com/response.aspx", ASEKEY);
                encryptredirecturl += "&Reference No=" + encryptFile(Reference_no, ASEKEY);
                encryptredirecturl += "&submerchantid=" + encryptFile(sub_merchant_id, ASEKEY);
                encryptredirecturl += "&transaction amount=" + encryptFile(pgamount, ASEKEY);
                encryptredirecturl += "&paymode=" + encryptFile("9", ASEKEY);

                Response.Redirect(encryptredirecturl);

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