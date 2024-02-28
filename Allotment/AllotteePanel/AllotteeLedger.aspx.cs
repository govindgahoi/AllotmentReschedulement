using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment.AllotteePanel
{
    public partial class AllotteeLedger : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string Usertype = "", pwd = "", dypPwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    GetNewAllotteeDetails();
                }
            }
            else
            {
                Response.Redirect("AllotteeLogin.aspx");
            }
        }

        #region "Bind Allotment in GridViewn"
        public void GetNewAllotteeDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            string Parameter = Session["AID"].ToString().Trim();
            DataSet dsAllottee = new DataSet();
            try
            {
                dsAllottee = objServiceTimelinesBLL.GetAlloteeDetailwithAID(Parameter);
                DataTable dt = dsAllottee.Tables[0];
                // DataTable dt1 = dsAllottee.Tables[1];
                Allotmentgrid.DataSource = dt;
                Allotmentgrid.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #endregion
    }
}