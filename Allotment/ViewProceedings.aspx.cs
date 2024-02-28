using System;
using System.Configuration;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class ViewProceedings : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string id;
        string Doctype;

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            id = Request.QueryString["ServiceRequestNo"];





            GetDetails();



        }


        private void GetDetails()
        {

            try
            {


                UC_Comments UC_Comments = LoadControl("~/UC_Comments.ascx") as UC_Comments;
                UC_Comments.ID = "UC_Comments";
                UC_Comments.ServiceReqNo = id;
                Placeholder.Controls.Add(UC_Comments);

            }
            catch (Exception)
            {

                throw;
            }
        }













    }




}
