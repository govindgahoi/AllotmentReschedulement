using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Default : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string Usertype = "", pwd = "", dypPwd;

        protected void Page_Load(object sender, EventArgs e)
        {
            string logout_info = Request.QueryString["logout"];
            string SerReqID = HttpUtility.HtmlDecode(logout_info);
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            if (!string.IsNullOrEmpty(SerReqID))
            {
                if (SerReqID == "true") { Session.Clear(); Response.Redirect("/Default.aspx"); }
            }

            if (!IsPostBack)
            {
                ClearAll();
                UpdateCaptchaText();
            }
        }
        public void ClearAll()
        {
            lblMessage.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }
        private void UpdateCaptchaText()
        {
            txtCode.Text = string.Empty;
            Random randNum = new Random();

            //Store the captcha text in session to validate  
            Session["Captcha"] = randNum.Next(10000, 99999).ToString();
            imgCaptcha.ImageUrl = "~/ghCaptcha.ashx?" + Session["Captcha"];
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string dypPwd = Decrypto(pwd.ToString());
                Usertype = RadioButtonList1.SelectedValue;
                InvalidLogincheck();
                if (message.Trim() == "NO Blocked")
                {
                    if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                    {
                        if (Session["Captcha"].ToString() == txtCode.Text.Trim())
                        {
                            string designation = "";

                            string sIPAddress = GetUserIP();
                            objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
                            objServiceTimelinesBEL.Password = txtPwd.Text.Trim();
                            //objServiceTimelinesBEL.Password = dypPwd.Trim();
                            objServiceTimelinesBEL.IPAddress = sIPAddress;
                            objServiceTimelinesBEL.Roll = RadioButtonList1.SelectedValue;
                            if (!string.IsNullOrEmpty(txtPwd.Text.Trim()) && !string.IsNullOrEmpty(txtPwd.Text.Trim()))
                            {
                                int retVal = objServiceTimelinesBLL.CheckLogin(objServiceTimelinesBEL);
                                if ((retVal == 0) & (objServiceTimelinesBEL.responseMessage.ToString() == "User successfully logged in"))
                                {
                                    string strName = txtUserName.Text.Trim();
                                    string strType = RadioButtonList1.SelectedValue;
                                    int userId = 0;
                                    string Designationname = string.Empty;

                                    if (strType == "1")
                                    {
                                        SqlCommand cmd = new SqlCommand("Select A.DesignationID , A.userId , B.[Designation] from UPSIDCUser A LEFT JOIN[dbo].[EmpDesignation] B ON A.[DesignationID] = B.[DesignationID] where UserName ='" + txtUserName.Text.Trim() + "'", con);
                                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);

                                        if (dt.Rows.Count > 0)
                                        {
                                            designation = dt.Rows[0][0].ToString().Trim();
                                            Designationname = dt.Rows[0][2].ToString().Trim();

                                            try { userId = int.Parse(dt.Rows[0][1].ToString().Trim()); } catch { }
                                        }

                                    }
                                    else if (strType == "5")
                                    {
                                        SqlCommand cmd = new SqlCommand("Select A.DesignationID , A.userId , B.[Designation] from tbl_LidaUser A LEFT JOIN[dbo].[EmpDesignation] B ON A.[DesignationID] = B.[DesignationID] where UserName ='" + txtUserName.Text.Trim() + "'", con);
                                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);

                                        if (dt.Rows.Count > 0)
                                        {
                                            designation = dt.Rows[0][0].ToString().Trim();
                                            Designationname = dt.Rows[0][2].ToString().Trim();

                                            try { userId = int.Parse(dt.Rows[0][1].ToString().Trim()); } catch { }
                                        }
                                    }
                                    else
                                    {
                                        SqlCommand cmd = new SqlCommand("Select A.DesignationID , A.userId  from OtherDeptUser A where A.UserName ='" + txtUserName.Text.Trim() + "'", con);
                                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);

                                        if (dt.Rows.Count > 0)
                                        {
                                            designation = dt.Rows[0][0].ToString().Trim();

                                            try { userId = int.Parse(dt.Rows[0][1].ToString().Trim()); } catch { }
                                        }
                                    }



                                    LoginInfo _objLoginInfo = new LoginInfo(strName, strType, userId);


                                    Session["objLoginInfo"] = _objLoginInfo;
                                    Session["UserName"] = strName;
                                    Session["Type"] = strType;

                                    if (strType == "1")
                                    {
                                        //  Response.Redirect("AdminDashBoard.aspx");
                                        if ((Designationname == "Managing Director") || (Designationname == "Joint Managing Director") || (Designationname == "Chief Manager(IA)" || Designationname == "Nodal EODB"))
                                        {
                                            Response.Redirect("DashboardNew.aspx");

                                        }
                                        else if (Designationname == "Land Acquisition")
                                        {
                                            Response.Redirect("LandAcquisitionRegistration.aspx");
                                        }
                                        else
                                        {

                                            Response.Redirect("DashboardI.aspx");
                                            //Response.Redirect("DashboardO.aspx");
                                        }
                                    }
                                    else if (strType == "4")
                                    {
                                        //Chnage By SUNIL Response.Redirect("DashboardO.aspx");
                                        Response.Redirect("DashboardI.aspx");
                                    }
                                    else if (strType == "5")
                                    {
                                        Response.Redirect("LidaServiceRequestNew.aspx");
                                    }

                                    else
                                    {
                                        Response.Redirect("AllotteeDashBoard.aspx");
                                    }

                                }
                                else
                                {
                                    lblMessage.Text = objServiceTimelinesBEL.responseMessage.ToString();
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                    UpdateCaptchaText();
                                    InvalidLogin();
                                }

                            }

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Captcha');", true);
                            UpdateCaptchaText();
                            return;
                        }
                    }
                }
                else if (message.Trim() == "Blocked")
                {
                    lblMessage.Text = "Your Are Blocked for 24 Hours Please Contact Admin";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    UpdateCaptchaText();
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string message = string.Empty;
        public string result = string.Empty;
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }

        public void InvalidLogincheck()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspInvalidPassword_Check"; // Store procediure name
            cmd.Parameters.Add("@UserType", SqlDbType.VarChar).Value = Usertype;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text.Trim();

            cmd.Parameters.Add("@Result", SqlDbType.Char, 500);
            cmd.Parameters.Add("@msg", SqlDbType.Char, 500);
            cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
            cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                message = (string)cmd.Parameters["@msg"].Value;
                result = (string)cmd.Parameters["@Result"].Value;


                //lboutput.Text = "Record inserted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InvalidLogin()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspInvalidPassword_Add"; // Store procediure name
            cmd.Parameters.Add("@UserType", SqlDbType.VarChar).Value = Usertype;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text.Trim();
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //lboutput.Text = "Record inserted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string Encrypt(string clearText)
        {
            string encryptionKey = "0123456789abcdefghijklmnopqrstuvwxyz";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypto(string cipherText)
        {
            string encryptionKey = "0123456789abcdefghijklmnopqrstuvwxyz";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        //protected void txtCode_TextChanged(object sender, EventArgs e)
        //{
        //    pwd = Encrypt(txtPwd.Text);
        //    txtPwd.Text = pwd;
        //}

    }
}