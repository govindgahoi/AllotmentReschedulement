using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidcApi
{
    public partial class IAServiceReports : System.Web.UI.Page
    {
        SqlConnection con;
        string token = string.Empty;
        string ModeType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            token = Request.QueryString["token"];
            ModeType = Request.QueryString["ModeType"];
            if (token != string.Empty && ModeType != string.Empty)
            {
                if (!IsPostBack)
                {
                    Bind_Announcement_List_GridView();
                }
            }

        }
      
        private void Bind_Announcement_List_GridView()
        {
                try
            {

                String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

                SqlConnection con = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetPendencyReportIAServiceLevelWise";

                cmd.Connection = con;

                try

                {

                    con.Open();

                    GridView2.EmptyDataText = "No Records Found";

                    GridView2.DataSource = cmd.ExecuteReader();

                    GridView2.DataBind();

                }

                catch (Exception ex)

                {

                    throw ex;

                }

                finally

                {

                    con.Close();

                    con.Dispose();

                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        private DataTable dtReginaloffice
        {
            get; set;
        }

        public DataSet Get_IAService_ReginalofficeList(string serviceID)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetPendencyReportReginalofficeWise", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceTimelinesID", serviceID);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
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

                        string ServiceID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                        string ServiceName = GridView2.DataKeys[e.Row.RowIndex].Values[1].ToString();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        dsReginaloffice = Get_IAService_ReginalofficeList(ServiceID);


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




    }
}