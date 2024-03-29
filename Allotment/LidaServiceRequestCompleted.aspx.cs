﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class LidaServiceRequestCompleted : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0,
            PacketId = 0;

        public string DataFactsModel_open = "";
        public string TicketStatus = "";
        public string TicketFor = "";
        public string TicketId = "";
        public string Level = "";
        public string DataManager = "";
        public int PacketID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                string Department = gm.GetUserDepartment(UserId);
                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Building Plan - Approved" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan -Not Approved" });
                    sub_menu.DataBind();
                }
                else
                {
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Building Plan - Approved" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan -Not Approved" });
                    sub_menu.DataBind();
                }


                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 0;

                    }
                }
                else
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 0;

                    }
                }
            }

            SqlCommand cmd = new SqlCommand("Select Level,DataManager from tbl_lidaUserAssociationMaster where UserID=" + UserId + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Level = dt.Rows[0][0].ToString();
                DataManager = dt.Rows[0][1].ToString();
            }
            BindServiceRequestGridView();
            Bind_Announcement_List_GridView();
        }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }



        #region "Bind Lida ServiceRequest in GridView Building Plan Approved"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfLidaBuildingPlanCompleted(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // determine the value of the UnitsInStock field
            //    int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
            //    if (CategoryID == 2)
            //        // color the background of the row yellow
            //        e.Row.BackColor = System.Drawing.Color.White;

            //}

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % GridView1.PageSize;
            string SerReqNo = (GridView1.DataKeys[index].Values[0]).ToString();
            string[] Arr = SerReqNo.Split('/');
            if (e.CommandName == "Print")
            {


                if (Arr[1] == "1")
                {
                    SqlCommand cmd = new SqlCommand("GetAllotmentletterFormSerReqNo '" + SerReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script>window.open ('BuildingPlanLetterView.aspx?AllotteeId=" + dt.Rows[0][0].ToString().Trim() + "','_blank');</script>");
                    }

                }
                else if (Arr[1] == "1000")
                {
                    SqlCommand cmd = new SqlCommand("GetAllotmentletterFormSerReqNo1 '" + SerReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script>window.open('AllotmentLetterView.aspx?AllotteeId=" + dt.Rows[0][0].ToString().Trim() + "','_blank');</script>");
                    }

                }
                else if (Arr[1] == "4")
                {

                    Response.Write("<script>window.open('TransferLetterView.aspx?AllotteeId=" + SerReqNo.Trim() + "','_blank');</script>");


                }

            }
            if (e.CommandName == "Upload")
            {

                Response.Write("<script>window.open('UploadSignedCopy.aspx?ServiceReqNo=" + SerReqNo.Trim() + "','_blank');</script>");


            }


        }
        #endregion

        #region "Land Allotment Code"
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
         private DataTable Getdata2
        {
            get; set;
        }
        private void Bind_Announcement_List_GridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;


                ds = objServiceTimelinesBLL.GetLidaBPNotApprovedCompleted(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                { Getdata2 = ds.Tables[0]; }
                // if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private DataTable Getdata1
        {
            get; set;
        }
        //private DataTable Getdata4
        //{
        //    get; set;
        //}
        //private DataTable Getdata3
        //{
        //    get; set;
        //}

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
               }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        #endregion


    }
}