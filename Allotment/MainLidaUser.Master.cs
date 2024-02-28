using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class MainLidaUser : System.Web.UI.MasterPage
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
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {/// lblempname.Text = ds.Tables[0].Rows[0][2].ToString();
                    //lblempcode.Text = ds.Tables[0].Rows[0][3].ToString();
                    lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    //lblGrade.Text = ds.Tables[0].Rows[0][5].ToString();
                    //lblQualification.Text = ds.Tables[0].Rows[0][6].ToString();
                    //lblemail.Text = ds.Tables[0].Rows[0][7].ToString();
                    //lblPhone.Text = ds.Tables[0].Rows[0][8].ToString();
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


           // masterMenu(Session["Type"].ToString().Trim());
        }






        //public void masterMenu(string cat)
        //{

        //    DashboardA.Visible = false;
        //    DashboardI.Visible = false;
        //    Master.Visible = false;
        //    Process.Visible = false;
        //    //    Application.Visible = false;
        //    //   Quicklinks.Visible = false;
        //    //    QuicklinksA.Visible = false;
        //    //      ProjectManagement.Visible = false;
        //    //Inspector.Visible = false;


        //    if (cat == "1")
        //    {
        //        if (lbldesignationid.Trim() == "54")
        //        {
        //            Li20.Visible = true;
        //        }
        //        else
        //        {
        //            Li20.Visible = false;
        //        }

        //        if (lblDataManager.Text == "Accounts Manager")
        //        {
        //            LiAccounts.Visible = true;
        //            DashboardI.Visible = true;
        //            ProcessNew.Visible = false;

        //        }
        //        else
        //        {
        //            if (lbldesignationid.Trim() == "49" || lbldesignationid.Trim() == "50")
        //            {
        //                //   Inspector.Visible = true;
        //                DashboardI.Visible = true;
        //                RaiseIU.Visible = true;
        //                Process.Visible = true;
        //            }
        //            else if (lbldesignationid.Trim() == "43")
        //            {
        //                LiAccounts.Visible = false;
        //                Master.Visible = false;
        //                Mastermain.Visible = false;
        //                Process.Visible = false;
        //                ProcessNew.Visible = false;
        //                ProcessLeaseDeed.Visible = false;
        //                Li25.Visible = false;
        //                DashboardI.Visible = false;
        //                QuicklinksA.Visible = false;
        //                RaiseIU.Visible = false;
        //                Li39.Visible = false;
        //                Li40.Visible = false;
        //                Li41.Visible = false;
        //                Li43.Visible = false;
        //                Li42.Visible = false;
        //                LiLAW.Visible = true;
        //            }
        //            else if ((lbldesignationid.Trim() == "58" || lbldesignationid.Trim() == "54"))
        //            {
        //                // NewAllotment.Visible = true;
        //                ReportsIU.Visible = true;
        //                //    landacquisition.Visible = true;
        //                //  enginnering.Visible = true;
        //                LandAllotmentApplication.Visible = true;
        //                Master.Visible = true;
        //                Mastermain.Visible = true;
        //                Process.Visible = true;

        //                DashboardI.Visible = true;
        //                QuicklinksA.Visible = true;
        //                RaiseIU.Visible = true;
        //                //   others.Visible = true;
        //            }
        //            else
        //            {
        //                ReportsIU.Visible = true;
        //                //  landacquisition.Visible = true;
        //                //    enginnering.Visible = true;

        //                Master.Visible = true;
        //                Mastermain.Visible = true;
        //                Process.Visible = true;

        //                DashboardI.Visible = true;
        //                QuicklinksA.Visible = true;
        //                RaiseIU.Visible = true;
        //                //  others.Visible = true;
        //            }
        //        }

        //        if (lblname.Text == "Admin1")
        //        {
        //            service.Visible = true;
        //            //  ProjectManagement.Visible = true;
        //            Repositories.Visible = true;
        //            //     ApplicationEvaluation.Visible = true;
        //        }
        //        if (lblDataManager.Text == "Data Approver")
        //        {
        //            Repositories.Visible = true;
        //        }


        //        if (lbldesignationid == "71")
        //        {
        //            Master.Visible = false;
        //            Li40.Visible = false;
        //            Li39.Visible = false;
        //            Li41.Visible = false;
        //            Li42.Visible = false;
        //            Li43.Visible = false;
        //            Mastermain.Visible = false;
        //            ProcessLeaseDeed.Visible = false;
        //            Li25.Visible = false;
        //            RaiseIU.Visible = false;
        //            Li28.Visible = false;
        //        }



        //    }
        //    if (cat == "2")
        //    {
        //        DashboardA.Visible = true;
        //        //  Application.Visible = true;
        //        //  Quicklinks.Visible = true;
        //        //  Quicklinks.Visible = true;
        //    }
        //}




        ////   public void masterMenu(string cat)
        //   {

        //       DashboardA.Visible = false;
        //       DashboardI.Visible = false;
        //       Master.Visible = false;
        //       Process.Visible = false;
        //       Application.Visible = false;
        //       Quicklinks.Visible = false;
        //       QuicklinksA.Visible = false;
        //       ProjectManagement.Visible = false;
        //       Inspector.Visible = false;


        //       if (cat == "1")
        //       {
        //           if(lbldesignationid.Trim()=="58")
        //           {
        //               Master.Visible = true;
        //               Process.Visible = true;

        //               DashboardMD.Visible = true;
        //               QuicklinksA.Visible = true;

        //           }
        //           else
        //           {

        //          if (lbldesignationid.Trim()=="49"  || lbldesignationid.Trim() =="50")
        //           {
        //               Inspector.Visible = true;   
        //               DashboardI.Visible = true;
        //           }
        //           else
        //           {
        //               Master.Visible = true;
        //               Process.Visible = true;

        //               DashboardI.Visible = true;
        //               QuicklinksA.Visible = true;
        //           }
        //           }

        //           if (lblname.Text=="Admin1" ||lbldesignationid.Trim()=="58")
        //           {
        //               service.Visible = true;
        //               ProjectManagement.Visible = true;
        //              // ApplicationEvaluation.Visible = true;
        //           }


        //       }
        //       if (cat == "2")
        //       {
        //           DashboardA.Visible = true;
        //           Application.Visible = true;
        //           Quicklinks.Visible = true;
        //           Quicklinks.Visible = true;
        //       }
        //   }


    }
}