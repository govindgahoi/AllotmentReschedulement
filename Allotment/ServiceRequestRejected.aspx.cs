using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ServiceRequestRejected : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        public string Level = "";
        public string DataManager = "";
        string UserName = "";
        int UserId = 0;
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
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                    sub_menu.DataBind();
                }
                else
                {
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "New Allotments" });
                    sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Building Plan" });
                    sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Plot Transfer" });
                    sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Amalgamation Post Allotment" });
                    sub_menu.Items.Add(new MenuItem { Value = "4", Text = "SubDivision Post Allotment" });
                    sub_menu.DataBind();
                }
                BindServiceRequestGridView();
                Bind_Announcement_List_GridView();
                BindServiceRequestGridViewTransfer();
                BindServiceRequestGridViewAmalgamation();
                BindServiceRequestGridViewSubdividion();

                if (UserName == "Nimisha.Sharma" || Department == "ATP")
                {
                    if (ApplicationView.ActiveViewIndex <= 0)
                    {
                        ApplicationView.ActiveViewIndex = 1;

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

            SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Level = dt.Rows[0][0].ToString();
                DataManager = dt.Rows[0][1].ToString();
            }
        }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ApplicationView.ActiveViewIndex = index;
        }



        #region "Bind ServiceRequest in GridView Building Plan"
        private void BindServiceRequestGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfBuildingPlanRejected(objServiceTimelinesBEL);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                if (CategoryID == 2)
                    // color the background of the row yellow
                    e.Row.BackColor = System.Drawing.Color.White;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[8].Attributes.Add("onclick", "ShowPopupChange('" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text) + "','Refund Details','" + HttpContext.Current.Server.HtmlDecode(e.Row.Cells[4].Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblRefundDate") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblRefundMode") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblRefundAmount") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblRefundTraRefNo") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblAccountNumber") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblIFSCCode") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblBankName") as Label).Text) + "','" + HttpContext.Current.Server.HtmlDecode((e.Row.FindControl("lblBranchName") as Label).Text) + "'); return false;");
                e.Row.Cells[8].Attributes.Add("style", "background: antiquewhite !important;width: 200px !important;cursor:pointer;");
            }


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


                ds = objServiceTimelinesBLL.GetApplicationRejected(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
               
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
        private DataTable Getdata4
        {
            get; set;
        }

        private DataTable Getdata3
        {
            get; set;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {



                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    int index = e.Row.RowIndex;

                    // determine the value of the UnitsInStock field
                    int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceRequestID"));
                    if (CategoryID == 2)
                        // color the background of the row yellow
                        e.Row.BackColor = System.Drawing.Color.White;



                }

          

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        #endregion


        #region "Transfer Of Plot"

        private void BindServiceRequestGridViewTransfer()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationTransferRejected(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = GridView3.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string NM = GridView3.DataKeys[e.Row.RowIndex].Values[1].ToString();
                if (NM.Length > 0)
                {
                    lnkd.NavigateUrl = "~/IAServicesAssessmentView.aspx?ServiceReqNo=" + ReqNo + "";

                }
                else
                {
                    lnkd.NavigateUrl = "~/BPServiceRequestInbox.aspx?ServiceID=" + ReqNo + "";
                }
            }
        }
        #endregion

        #region "Amalgamation Post Allotment"
        private void BindServiceRequestGridViewAmalgamation()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationAmalgamationRejected(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
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

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = GridView3.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string NM = GridView3.DataKeys[e.Row.RowIndex].Values[1].ToString();
                if (NM.Length > 0)
                {
                    lnkd.NavigateUrl = "~/IAServicesAssessmentView.aspx?ServiceReqNo=" + ReqNo + "";

                }
                else
                {
                    lnkd.NavigateUrl = "~/BPServiceRequestInbox.aspx?ServiceID=" + ReqNo + "";
                }
            }
        }

        #endregion


        #region "SubDivision Post Allotment"

        private void BindServiceRequestGridViewSubdividion()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;

                ds = objServiceTimelinesBLL.GetApplicationOfSubDivisionPostAllotmentRejected(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grid_PostSubDivision.DataSource = ds;
                    Grid_PostSubDivision.DataBind();
                }
                else
                {
                    Grid_PostSubDivision.DataSource = null;
                    Grid_PostSubDivision.DataBind();
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

        protected void Grid_PostSubDivision_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink lnkd = e.Row.FindControl("hlnkView") as HyperLink;
                string ReqNo = Grid_PostSubDivision.DataKeys[e.Row.RowIndex].Values[0].ToString();


                lnkd.NavigateUrl = "~/IAServicesAssessment.aspx?ServiceReqNo=" + ReqNo + "";


            }
        }

        #endregion

    }
}