using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ViewOfficeOrdersPublic : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindServiceTimelinesGridView();
            }

        }

        #region "Bind ServiceTimelines Records in GridView"
        private void BindServiceTimelinesGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetOfficeOrdersPublic();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
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
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }
        #endregion


     

       
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "ViewDoc")
            {

                //int index = e.Row.RowIndex;
                string Path = (e.CommandArgument).ToString();
                //int index = Convert.ToInt32(e.CommandArgument);
               
                Response.Write("<script>window.open ('" + Path.Substring(2) + "','_blank');</script>");
            }
        }
    }
}