using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class DashboardO : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
     
                try
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string UserName = _objLoginInfo.userName;


                GetUserRecord(UserName, "4");
                }
                catch
                {
                    Response.Redirect("/default.aspx");
                }

            
        }

        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    lblName.Text        = ds.Tables[0].Rows[0]["EMPLOYEENAME"].ToString();
                    lbldesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                    lblGrade.Text       = ds.Tables[0].Rows[0]["Designation"].ToString();
                    lblEmail.Text       = ds.Tables[0].Rows[0]["emailID"].ToString();
                    lblPhoneNo.Text     = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }


            
        }

    }
}




