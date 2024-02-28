using System;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class IDALogin : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        SqlConnection con = new SqlConnection();
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
            objServiceTimelinesBEL.Password = txtPwd.Text.Trim();

            if (!string.IsNullOrEmpty(txtPwd.Text.Trim()) && !string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                int retVal = objServiceTimelinesBLL.CM_CheckLogin(objServiceTimelinesBEL);

                if ((retVal == 0) & (objServiceTimelinesBEL.responseMessage.ToString() == "User successfully logged in"))
                {

                    DataSet dsR = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.UserName = txtUserName.Text.Trim();
                        dsR = objServiceTimelinesBLL.GetCMUserCompany(objServiceTimelinesBEL);
                        DataTable dt = dsR.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            string UserName = dt.Rows[0]["UserName"].ToString();
                            string Companyid = dt.Rows[0]["CorporationID"].ToString();
                            string CompanyName = dt.Rows[0]["AuthortyName"].ToString();
                            LoginInfo _objLoginInfo = new LoginInfo(UserName, Companyid);
                            Session["objLoginInfo"] = _objLoginInfo;

                            Session["UserName"] = UserName;
                            Session["Companyid"] = Companyid;
                            Session["CompanyName"] = CompanyName;


                            Response.Redirect("IDADashboard.aspx", false);

                        }



                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }

                }
                else
                {


                    if (objServiceTimelinesBEL.responseMessage.ToString() == "Invalid Credentials")
                    {
                        Response.Write("<script>alert('The username or password is not valid')</script>");
                    }
                    // lblMessage.Text = objServiceTimelinesBEL.responseMessage.ToString();
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                }

            }

        }
    }
}