using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ObjectionsLAW : System.Web.UI.UserControl
    {
        SqlConnection con;
        
        
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;
        GeneralMethod gm = new GeneralMethod();
        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        
        string UserName = "";

        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId   = _objLoginInfo.userid;
               
                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level       = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
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
                SqlCommand cmd = new SqlCommand("GetPreviousDuesLAW '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = Getdata1;
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
      
    }
}