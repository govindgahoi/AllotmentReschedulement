using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class IAServiceReports : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Bind_Announcement_List_GridView();
            }
        }

       
        #region "IA Service Report"
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


                ds = objServiceTimelinesBLL.Get_IAService_ListNew(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0) { Getdata2 = ds.Tables[0]; }
                //if (ds.Tables[1].Rows.Count > 0) { Getdata1 = ds.Tables[1]; }
                //if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }


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
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    Getdata1 = ds.Tables[1];
                //}




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
        private DataTable dtReginaloffice
        {
            get; set;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet dsReginaloffice = new DataSet();
                    try
                    {
                        belBookDetails objServiceTimelinesBEL = new belBookDetails();
                        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                        objServiceTimelinesBEL.serviceID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                        string ServiceName= GridView2.DataKeys[e.Row.RowIndex].Values[1].ToString();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        dsReginaloffice = objServiceTimelinesBLL.Get_IAService_ReginalofficeList(objServiceTimelinesBEL);
                        if (dsReginaloffice.Tables[0].Rows.Count > 0) { dtReginaloffice = dsReginaloffice.Tables[0]; }
                        if (dsReginaloffice.Tables[0].Rows.Count > 0)
                        {
                            GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                            grdview.DataSource = dtReginaloffice;
                            grdview.DataBind();
                            Label service = e.Row.FindControl("ServiceName") as Label;
                            service.Text = ServiceName;
                            Label Date = e.Row.FindControl("lblDate") as Label;
                            Date.Text = (dateTime.ToString("dd/MM/yyyy"));
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        #endregion



        

    }
}