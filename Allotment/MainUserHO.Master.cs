using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class MainUserHO : System.Web.UI.MasterPage
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string lbldesignationid = "";
        string lblDataManager = "";
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

                lblname.Text = Convert.ToString(Session["UserName"]);



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

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    lblDataManager = ds.Tables[0].Rows[0]["DataManager"].ToString();

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

            DashboardA.Visible = false;
            DashboardI.Visible = false;



            if (cat == "1")
            {

                if ((lbldesignationid.Trim() == "22" || lbldesignationid.Trim() == "58" || lbldesignationid.Trim() == "69" || lbldesignationid.Trim() == "64") || lbldesignationid.Trim() == "66" || lbldesignationid.Trim() == "68")
                {

                    Repositories.Visible = true;
                    DashboardI.Visible = true;
                    LandBank.Visible = true;
                    PlotBank.Visible = true;
                    Approvals.Visible = true;
                    LandApprovals.Visible = true;
                    ReportsIU.Visible = true;
                    ApplicationReportsHOMaster.Visible = true;

                }
                else
                {

                    DashboardI.Visible = true;

                }


                if (lblname.Text == "Admin1")
                {
                    Repositories.Visible = true;
                    ApplicationReportsHOMaster.Visible = true;

                }

                if (lblDataManager == "Data Approver" || lblDataManager == "CMIA" || lblDataManager == "JMD" || lblDataManager == "Final Approver")
                {
                    Repositories.Visible = true;
                }
            }
            if (cat == "2")
            {
                DashboardA.Visible = true;

            }
        }





    }
}