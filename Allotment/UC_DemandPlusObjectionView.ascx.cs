using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_DemandPlusObjectionView : System.Web.UI.UserControl
    {
        SqlConnection con;
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        public string IAID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string[] SerIdarray = ServiceReqNo.Split('/');

                AllotteeID = SerIdarray[2].Trim();

                Page.Form.Enctype = "multipart/form-data";

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }


                if (!IsPostBack)
                {

                }
                PreviousDues();
            }
            catch (Exception ex)
            {
            }

        }

        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }


        private void PreviousDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetPreviousDemandDues '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }
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
                if (Getdata3.Rows.Count > 0)
                {
                    GridView1.DataSource = Getdata3;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string IAID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata2.Select("DemandId = '" + IAID + "'");
                    DataTable dt1 = dr.CopyToDataTable();
                    GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                    grdview.DataSource = dt1;
                    grdview.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}