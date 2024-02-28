using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class AdminUser : System.Web.UI.MasterPage
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string lbldesignationid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {

                //   lblname.Text = _objLoginInfo.userName;
                //  Roll = _objLoginInfo.Roll;

                lblname.Text = Convert.ToString(Session["UserName"]);

                // masterMenu(Roll);

                if (!IsPostBack)
                {
                    GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());
                }
            }
        }

        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;
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


            masterMenu(Session["Type"].ToString().Trim());
        }
        public void masterMenu(string cat)
        {
            UpdatePlotAllotteeMaster.Visible = false;
            if (cat == "1")
            {
                if ((lbldesignationid.Trim() == "67"))
                {
                    UpdatePlotAllotteeMaster.Visible = true;
                }
            }
        }
    }
}