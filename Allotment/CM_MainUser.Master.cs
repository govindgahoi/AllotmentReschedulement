using System;
using System.Data;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class CM_MainUser : System.Web.UI.MasterPage
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
                Response.Redirect("/IDADashboard.aspx");
            }

            if (lblname.Text == "")
            {
                Response.Redirect("/IDADashboard.aspx");
            }
            else
            {

                //   lblname.Text = _objLoginInfo.userName;
                //  Roll = _objLoginInfo.Roll;

                lblname.Text = Convert.ToString(Session["UserName"]);

                // masterMenu(Roll);

                if (!IsPostBack)
                {       // GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());


                    //lblname.Text = Convert.ToString(ViewState["UserName"]);

                    //string strReq = "";
                    //strReq = Request.RawUrl;
                    //strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                    //if (!strReq.Equals(""))
                    //{
                    //    strReq = DecryptQueryString(strReq);

                    //    //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                    //    string[] arrMsgs = strReq.Split('&');
                    //    string[] arrIndMsg;
                    //    string strName = "", strType = "";
                    //    arrIndMsg = arrMsgs[0].Split('='); //Get the Name
                    //    strName = arrIndMsg[1].ToString().Trim();
                    //    arrIndMsg = arrMsgs[1].Split('='); //Get the Age
                    //    strType = arrIndMsg[1].ToString().Trim();

                    //    lblname.Text = strName;

                    //}
                    //else
                    //{
                    //   // Response.Redirect("Page1.aspx");
                    //}

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
                    //lblGrade.Text = ds.Tables[0].Rows[0][5].ToString();
                    //lblQualification.Text = ds.Tables[0].Rows[0][6].ToString();
                    //lblemail.Text = ds.Tables[0].Rows[0][7].ToString();
                    //lblPhone.Text = ds.Tables[0].Rows[0][8].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category);
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

            DashboardI.Visible = false;
            Master.Visible = false;

        }
    }
}