using System;
using System.Configuration;
using System.Data.SqlClient;
using BEL_Allotment;
using BLL_Allotment;



namespace Allotment
{
    public partial class ViewMarking : System.Web.UI.Page
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


                EvaluationSheetAllottee EvaluationSheetAllottee = LoadControl("~/EvaluationSheetAllottee.ascx") as EvaluationSheetAllottee;
                EvaluationSheetAllottee.ID = "EvaluationSheetAllottee";

                EvaluationSheetAllottee.ServiceReqNo = id;
                Placeholder.Controls.Add(EvaluationSheetAllottee);

            }
            catch (Exception)
            {

                throw;
            }
        }













    }




}
