using Allotment;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Allotment
{
    public partial class UC_Service_Lida_Fee_Calculation_Details1 : System.Web.UI.UserControl
    {
        string service_num ;
        
        string alottee_id, alotte_name, allotee_email, allotee_mob, service_type;

        string service_id = string.Empty;
        string desc = string.Empty;
        string trans_id, unique_id, cust_id, describe;
        bool isdatainserted = false;
        public string ServiceReqNo { get; set; }

        connectionstring obj = new connectionstring();
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                   
                    paymentinfo(ServiceReqNo);
                    bindfeecalculation(ServiceReqNo);
                    bindfeecalculation1(ServiceReqNo);

                }



            }

            catch (Exception ex)

            {

            }

        }
        public void paymentinfo(string service_num)
        {
            SqlConnection ConnectionName = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConnectionName;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_LIDA_ApplicantTransactionDetails";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            ConnectionName.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblapprefno.Text = dr["ServiceNo"].ToString();
                //   Session["Newg_total"] = dr["CreatedTransactionAmount"].ToString();
                //     .Text =dr["clnt_txn_ref"].ToString();
                //.Text = dr["rqst_amnt"].ToString();
                //   Session["NewTransId"] = dr["TransactionRefNo"].ToString();
                lbldt.Text = DateTime.Parse(dr["TransactioncreateDate"].ToString()).ToString("dd-MM-yyyy");
                // lblnameof.Text = dr["cust_name"].ToString();
                //.Text = dr["cust_mobno"].ToString();
                //.Text = dr["customer_unique_id"].ToString();
                //.Text = dr["checksum"].ToString();
                //string mercode = dr["merchantcode"].ToString();
                lblpaystatus.Text = dr["Paid"].ToString()=="1"?" Payment Completed":" Fee Pending";
                // .Text = dr["desc_error"].ToString();
                lbltxnrefno.Text = dr["EazypayRefNo"].ToString();
                string bankcode = dr["PayMode"].ToString();

                string paidamt = dr["TotalAmount"].ToString();
                lbltxndt.Text = dr["TransactionDate"].ToString();
            }
        }
        public void bindfeecalculation(string service_num)
        {
            //ReInspectionFee
            SqlConnection ConnectionName = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConnectionName;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Lida_FeeCalculationDetails";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            ConnectionName.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblpermitfee.Text = dr["ReInspectionFee"].ToString();

                lblpermitfeefortemp.Text = dr["PermissiveFee"].ToString();
                lbllabourfree.Text = dr["LabourAccomatdationFee"].ToString();


                lblfeeoncoveredarea.Text = dr["InspectionFee"].ToString();

            }

        }
        public void bindfeecalculation1(string service_num)
        {
            //ReInspectionFee
            SqlConnection ConnectionName = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConnectionName;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Lida_FeeCalculationDetails1";
            comm.Parameters.AddWithValue("@service_num", service_num);


            SqlDataReader dr;
            ConnectionName.Open();

            dr = comm.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                lblplotarea.Text = dr["TotalArea"].ToString();

                lblcoveredarea.Text = dr["CoveredArea"].ToString();
                lbltotalfee.Text = dr["TotalFeeWithoutGST"].ToString();


                lblgstwithfee.Text = dr["TotalFeeWithGST"].ToString();
                Session["Newg_total"] = dr["TotalFeeWithGST"].ToString();
            }

        }
        bool process_result_data;
        public void get_application_status()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_Lida_ApplicationProcessHistoryCheck";
            cmd.Parameters.AddWithValue("@service_num", service_num);
            // cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtID.Text.Trim();

            cmd.Connection = con;

            try

            {

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        process_result_data = Convert.ToBoolean(dr["FeeCalculationStatus"].ToString());
                        //Label1.Text = dr["FirstName"].ToString();
                        //Label2.Text = dr["LastName"].ToString();
                        //Label3.Text = dr[3].ToString();
                        //Label4.Text = dr["Email"].ToString();
                    }
                }
                // GridView1.EmptyDataText = "No Records Found";

                // GridView1.DataSource = cmd.ExecuteReader();

                //  GridView1.DataBind();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

                con.Dispose();

            }
        }
        public void getallotteedata()
        {
            try
            {

                string constrr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                // string query = "Select MAX(id) as id from [lida_allotee_registration] ;";
                // query += "SELECT Top1 allotee_info.lida_allotee_id,allotee_info.cust_id,allotee_info.allottee_name,allotee_info.allottee_email,allotee_info.allotee_mobno,lida_allotee_registration.service_type FROM allotee_info INNER JOIN lida_allotee_registration ON allotee_info.lida_allotee_id=lida_allotee_registration.lida_allotee_idwhere[lida_allotee_registration].[lida_allotee_id]='LiDaRe20220307/3000/9701/908670'";
                using (SqlConnection con = new SqlConnection(constrr))
                {
                    // SqlCommand command = new SqlCommand(query);

                    SqlCommand command = new SqlCommand("SELECT Top 1 allotee_info.lida_allotee_id, allotee_info.cust_id, allotee_info.allottee_name, allotee_info.allottee_email, allotee_info.allotee_mobno, lida_allotee_registration.service_type FROM allotee_info INNER JOIN lida_allotee_registration ON allotee_info.lida_allotee_id = lida_allotee_registration.lida_allotee_id where [lida_allotee_registration].[lida_allotee_id] = '" + Request.Cookies["service_num"].Value + "'", con);
                    // command.Parameters.AddWithValue("@RemaninhNumbers", txtid.Text);
                    con.Open();
                    SqlDataReader sdrr = command.ExecuteReader();
                    if (sdrr.Read())
                    {

                        alottee_id = sdrr["lida_allotee_id"].ToString();
                        alotte_name = sdrr["allottee_name"].ToString();
                        allotee_email = sdrr["allottee_email"].ToString();
                        allotee_mob = sdrr["allotee_mobno"].ToString();
                        service_type = sdrr["service_type"].ToString();




                        // max_id = Convert.ToInt64(sdrr["id"]);
                        //  my_id = sdrr["id"].ToString();
                    }


                }



                //using (SqlConnection con = new SqlConnection(constrr))
                //{
                //    using (SqlCommand cmd = new SqlCommand("Select MAX(id) as id from lida_allotee_registration", con))
                //    {
                //        con.Open();
                //        using (SqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            // Handle second resultset here
                //            allotee_Maxid = Convert.ToInt64(reader["id"]);
                //        }
                //    }

                //    //  Response.Write("Oops!Your Id :" + max_id.ToString());
                //}
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        long maxTrans_id = 0;
        public void get_transaction_id()
        {
            DataTable dt = obj.g_fetch_data("select max(TransactionId) as TransactionNo from ApplicantTransaction ");
            foreach (DataRow row in dt.Rows)
            {
                //string name = row["name"].ToString();
                //string description = row["description"].ToString();
                //string icoFileName = row["iconFile"].ToString();
                //string installScript = row["installScript"].ToString();
                maxTrans_id = Convert.ToInt64(row["TransactionNo"].ToString());
                maxTrans_id++;
            }
        }
        protected void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                getallotteedata();
                Random rnd = new Random();

                if (service_type == "New Map Sanction")
                {
                    service_id = "3001";
                }
                else if (service_type == "Revalidation of Sanctioned Map")
                {
                    service_id = "4002";
                }
                else if (service_type == "Revision of Sanctioned Map")
                {
                    service_id = "5003";
                }
                get_transaction_id();
                trans_id = "TRANSR" + service_id + "/" + maxTrans_id;
                // alottee_id = alottee_id.Substring(alottee_id.LastIndexOf("/") + 1);
                alottee_id = alottee_id.Remove(0, 3);
                unique_id = "SeR" + alottee_id + "/" + maxTrans_id;
                cust_id = "Cust_id" + rnd.Next(10, 456321).ToString();
                describe = service_type;
                double d = Convert.ToDouble(Session["Newg_total"].ToString());
                decimal amt = Convert.ToDecimal(d);
                amt = Math.Round((decimal)amt, 2);
                Session["TransactionID"] = maxTrans_id;
                Session["allottee_id"] = Request.Cookies["service_num"].Value;


                insertintodb();




                if (isdatainserted == true)

                {

                    string geturl = SendToPaymentGetwayHDFCNew(amt, trans_id, cust_id, unique_id, alotte_name, allotee_email, allotee_mob, "T");
                    callonpost(geturl);
                }


                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert(\"Please select All Fields.\");</script>", false);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert(\"Incomplete Information Received.\");</script>", false);
            }



        }
        public void insertintodb()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {


                SqlCommand cmd = new SqlCommand("sp_Lida_Allotee_transaction_details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CreatedTransactionAmount", Session["Newg_total"].ToString());
                cmd.Parameters.AddWithValue("ServiceNo", Request.Cookies["service_num"].Value);
                cmd.Parameters.AddWithValue("StatementType", "Insert");

                //cmd.Parameters.AddWithValue("education", TextBox3.Text);
                //cmd.Parameters.AddWithValue("phoneno", TextBox4.Text);
                //cmd.Parameters.AddWithValue("city", TextBox5.Text);
                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    isdatainserted = true;
                    // lblmsg.Text = "Record Inserted Succesfully into the Database";
                    // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
                con.Close();
                //  lblmessage.Text = "Error while saving data.";
            }

        }

        string db_checksum = "";
        public string SendToPaymentGetwayHDFCNew(decimal AmountPayble, string CustUnique_Id, string ServicesRequestNumber, string Shopping_CartDetails, string Cust_Name, string Cust_Emailid, string Cust_Mobno, string Type)
        {

           // string rtrn_url = "http://services.stagingupsida.com/thank_you.aspx";

            //Staging Redirect URL

            //       string rtrn_url = "http://services.stagingupsida.com/thank_you.aspx";



            //Live Server Redirect URL

               string rtrn_url = "http://eservices.onlineupsidc.com/thank_you.aspx";

            //  string rtrn_url = "http://services.stagingupsida.com/HDFCresponse.aspx";

            string rqst_type = "T";
            //test URL
            //string instId = "4042";
            //string merchant_id = "4042";
            // string instId = "4038";
            // string merchant_id = "4038";

            //Live URL
            string instId = "UPLK";
            string merchant_id = "UPLK";
            string clnt_txn_ref = CustUnique_Id;
            // string rqst_amnt = "5000";
            string rqst_amnt = AmountPayble.ToString();
            string rqst_crncy = "INR";
            string itc = "Test";
            //string cart_dtls = "Other Fee" + rqst_amnt + "_0.00";
            string cart_dtls = "TOTAL FEES_" + rqst_amnt + "_0.00";

            //string clnt_dt_tm = "30-08-2018";
            string clnt_dt_tm = DateTime.Now.ToString("dd-MM-yyyy");
            string pymt_mode = "";
            if (Type == "One")
            {
                pymt_mode = "";
            }
            else
            {
                pymt_mode = "";
            }
            string tpsl_bank_cd = "";
            string cust_name = Cust_Name;
            string cust_emailid = Cust_Emailid;
            string cust_mobno = Cust_Mobno;
            string cust_unique_id = ServicesRequestNumber;
            string tran_id = "";

            string Key = "1989083233a696819f2623039a9f8adf";

            string message;
            message = "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" + "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                   + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                   + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                   + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id;

            //message = "rqst_type=T|merchant_id=4042|clnt_txn_ref=BIMCA1014424211|rqst_amnt=1|rqst_crncy=INR|itc=Test|rtrn_url=http://localhost:6611/response.aspx|cart_dtls=Totalfees_1.00_0.00|clnt_dt_tm=24-08-2018 12:56:15|pymt_mode=|tpsl_bank_cd=|cust_name=Manish Shukla|cust_emailid=manish.ims08@gmail.com|cust_mobno=9650425760|cust_unique_id=TRAA1000/1878|tran_id=";//plain string before the encryption;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(Key);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            string finalstr = ByteToString(hashmessage);
            string Checksum = finalstr.ToLower();
            db_checksum = Checksum;

            Session["req_checksum"] = db_checksum;
            Session["req_trans_id"] = trans_id;
            Session["req_cust_unique_id"] = cust_unique_id;
            string encryptredirecturl = "";
            // string Reference_no = IN_Reference;


            //  string pgamount = 1.ToString();



            try
            {
                encryptredirecturl += "https://smarthubgovernment.hdfcbank.com/SmartHubGovt/InstituteURL.action?";
                // encryptredirecturl += "https://smarthubgovernment.hdfcbank.com/SmartHubGovt/InstituteURL.action?";
                // encryptredirecturl += "https://www.tecprocesssolution.com/SmartHubGovt_UAT/InstituteURL.action?";
                encryptredirecturl += "instId=" + instId;
                encryptredirecturl += "&data=" + "rqst_type=" + rqst_type + "|" + "merchant_id=" + merchant_id + "|" +
                                    "clnt_txn_ref=" + clnt_txn_ref + "|" + "rqst_amnt=" + rqst_amnt + "|" + "rqst_crncy=" + rqst_crncy + "|" + "itc=" + itc + "|"
                                    + "rtrn_url=" + rtrn_url + "|" + "cart_dtls=" + cart_dtls + "|" + "clnt_dt_tm=" + clnt_dt_tm + "|" + "pymt_mode=" + pymt_mode + "|"
                                    + "tpsl_bank_cd=" + tpsl_bank_cd + "|" + "cust_name=" + cust_name + "|" + "cust_emailid=" + cust_emailid + "|" + "cust_mobno=" + cust_mobno + "|"
                                    + "cust_unique_id=" + cust_unique_id + "|" + "tran_id=" + tran_id + "|" + "Checksum=" + Checksum;

                return encryptredirecturl;
            }
            catch
            {
                return "Failed";
            }

            // Response.Redirect(encryptredirecturl);

        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }


        public void callonpost(string getmetod)
        {
            NameValueCollection collections = new NameValueCollection();
            //  collections.Add("FirstName", txtFirstName.Text.Trim());
            // collections.Add("LastName", txtLastName.Text.Trim());
            //   string remoteUrl = "http://localhost:5075/Post_Redirect_Website/Page2_CS.aspx";
            string remoteUrl = getmetod;

            string html = "<html><head>";
            html += "</head><body onload='document.forms[0].submit()'>";
            html += string.Format("<form name='PostForm' method='POST' action='{0}'>", remoteUrl);
            //foreach (string key in collections.Keys)
            //{
            //    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
            //}
            html += "</form></body></html>";
            Response.Clear();
            Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
            Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
            Response.Charset = "ISO-8859-1";
            Response.Write(html);
            Response.End();
        }
    }
}