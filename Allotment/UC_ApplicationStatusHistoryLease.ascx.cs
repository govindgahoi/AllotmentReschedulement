using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_ApplicationStatusHistoryLease : System.Web.UI.UserControl
    {
        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        public string ServiceReqNo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            Get_Notesheet_of_service(ServiceReqNo);
        }


        public void Get_Notesheet_of_service(string ServiceReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {

                dsR = objServiceTimelinesBLL.Get_application_status_History(ServiceReqNo);
                DataTable dt = dsR.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
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
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }


    }
}