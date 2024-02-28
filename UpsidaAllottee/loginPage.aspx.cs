using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace UpsidaAllottee
{
    public partial class loginPage : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;


        protected void Page_Load(object sender, EventArgs e)
        {

            string logout_info = Request.QueryString["logout"];
            string SerReqID = HttpUtility.HtmlDecode(logout_info);
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            if (!string.IsNullOrEmpty(SerReqID))
            {
                if (SerReqID == "true") { Session.Clear(); Response.Redirect("/loginPage.aspx"); }
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

                if (!string.IsNullOrEmpty(Session["Captcha"] as string))
                {
                    if (Session["Captcha"].ToString() == txtCode.Text.Trim())
                    {
                        string designation = "";
                        string sIPAddress = GetUserIP();
                        objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
                        objServiceTimelinesBEL.Password = txtPwd.Text.Trim();
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
                                string level = string.Empty;

                                if (strType == "1")
                                {
                                    //SqlCommand cmd = new SqlCommand("Select A.DesignationID , A.userId , B.[Designation] from UPSIDCUser A LEFT JOIN[dbo].[EmpDesignation] B ON A.[DesignationID] = B.[DesignationID] where UserName ='" + txtUserName.Text.Trim() + "'", con);
                                    SqlCommand cmd = new SqlCommand("Select A.DesignationID , A.userId ,A.UserName, B.Level from UPSIDCUser A JOIN [dbo].[UserAssociationMaster] B ON A.UserID = B.userId where B.ActiveStatus =1 and A.UserName ='" + txtUserName.Text.Trim() + "'", con);
                                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    adp.Fill(dt);

                                    if (dt.Rows.Count > 0)
                                    {
                                        designation = dt.Rows[0][0].ToString().Trim();
                                        Designationname = dt.Rows[0][2].ToString().Trim();
                                        level = dt.Rows[0][3].ToString().Trim();

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
                                Session["Level"] = level;


                                if (strType == "1" && (level == "RM" || level == "Admin1" || level== "MD" || level == "JMD"))
                                {
                                    Response.Redirect("/UpdateallotmentDetails.aspx");
                                }
                                else
                                {
                                    string logout_info = Request.QueryString["logout"];
                                    string SerReqID = HttpUtility.HtmlDecode(logout_info);
                                    if (!string.IsNullOrEmpty(SerReqID))
                                    {
                                        if (SerReqID == "true") { Session.Clear(); Response.Redirect("/loginPage.aspx"); }
                                    }
                                }

                            }
                            else
                            {
                                lblMessage.Text = objServiceTimelinesBEL.responseMessage.ToString();
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                UpdateCaptchaText();
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
            catch (Exception ex)
            {

                throw ex;
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
    }
}