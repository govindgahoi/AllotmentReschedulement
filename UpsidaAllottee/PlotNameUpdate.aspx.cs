using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class PlotNameUpdate : System.Web.UI.Page
    {
        string ServiceReqNo;
        SqlConnection con;
        string UserName;
        int UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            //LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            //UserName = _objLoginInfo.userName;
            //UserId = _objLoginInfo.userid;

        }

        protected void UpdatePlotNo(object sender, EventArgs e)
        {
            string serNo = ServiceReqNo;
            string plotNo = txtPlotNo.Text.Trim();
            if (txtPlotNo.Text.Trim() == "")
            {
                Response.Write("<script>alert('Invalid Detail. Please mention correct information. ')</script>");
            }
            else
            {

                DateTime now = DateTime.Now;
                SqlCommand cmd = new SqlCommand("usp_UpdateAmalgmationPlotNo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServiceReqNo", serNo);
                cmd.Parameters.AddWithValue("@PlotNo", txtPlotNo.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                  
                    Response.Redirect("~/ReportGenrationIAService.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }
                else
                {
                   
                    Response.Redirect("~/IAServicesAssessment.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }

            }
        }

    }
}