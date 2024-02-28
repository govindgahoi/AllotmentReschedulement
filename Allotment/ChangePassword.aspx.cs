using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        string UserId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserId = _objLoginInfo.userName;

            if (!IsPostBack)
            {
                txtExistingPassword.Attributes["type"] = "Password";
                txtConfirmPassword.Attributes["type"] = "Password";
                txtNewPassword.Attributes["type"] = "Password";
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtExistingPassword.Text == "" || txtExistingPassword.Text == null)
            {
                MessageBox1.ShowWarning("Please Enter Existing Password");
                return;
            }
            else
            {
                if (txtNewPassword.Text == "" || txtNewPassword.Text == null)
                {
                    MessageBox1.ShowWarning("Please Enter New Password");

                    return;
                }
                else
                {
                    if (txtConfirmPassword.Text == "" || txtConfirmPassword.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Enter Confirm Password");

                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.UserName = UserId;
                        objServiceTimelinesBEL.Password = txtExistingPassword.Text.Trim();

                        DataSet ds = new DataSet();
                        try
                        {
                            ds = objServiceTimelinesBLL.GetLoginDetailCheck(objServiceTimelinesBEL);


                            if (ds.Tables.Count > 0)
                            {
                                if (txtNewPassword.Text == txtConfirmPassword.Text)
                                {
                                    objServiceTimelinesBEL.UserName = UserId;
                                    objServiceTimelinesBEL.Password = txtConfirmPassword.Text.Trim();
                                    int retVal = objServiceTimelinesBLL.UpdatePassword(objServiceTimelinesBEL);
                                    if (retVal > 0)
                                    {
                                        string message = "Your Password Changed Successfully";
                                        Session.Clear();
                                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage();", true);

                                    }
                                    else
                                    {
                                        string message = "Your Password couldn't be changed";
                                        MessageBox1.ShowError(message);
                                    }
                                }
                                else
                                {
                                    string message = "New Password & Confirm Password Not Matched";
                                    MessageBox1.ShowError(message);


                                    return;
                                }

                            }
                            else
                            {
                                string message = "Please Check Your Existing Password";

                                MessageBox1.ShowError(message);
                                return;
                            }

                        }
                        catch (Exception ex)
                        {
                            Response.Write("Oops! error occured :" + ex.Message.ToString());
                        }


                    }

                }

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtExistingPassword.Text = "";

        }
    }
}