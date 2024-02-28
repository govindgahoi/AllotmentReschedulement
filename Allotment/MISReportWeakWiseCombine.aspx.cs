using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BEL_Allotment;
using BLL_Allotment;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Allotment
{
    public partial class MISReportWeakWiseCombine : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "",IAName="",Weakstart="",WeakEnd="";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
            IAName = Request.QueryString["IAName"];
            Weakstart = Request.QueryString["Weakstart"];
            WeakEnd = Request.QueryString["WeakEnd"];
            if (!IsPostBack)
            {

                BindServiceRequestGrid(); 

            }
        }
   
        protected void AllGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = e.Row.Cells[3].Text.Trim();
              
                
            }
        }
   
        private void BindServiceRequestGrid()
        {
            try
            {
               
                string html = "";
                //lblStartDate.Text = Weakstart;
                //lblEndDate.Text = WeakEnd;
                //DateTime WeakStartDate = Convert.ToDateTime(Weakstart).AddDays(0);
                //DateTime WeakEndDate = Convert.ToDateTime(WeakEnd).AddDays(0);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("[GetAllLAMISWeakWise] '" + UserName + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];

                html += "<table style=' border-collapse: collapse;width: 100%;border:1px solid #ccc;'>";
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string ROffice         = dt1.Rows[i][0].ToString();
                    string IAName          = dt1.Rows[i][1].ToString();               
                    DateTime WeakStartDate = Convert.ToDateTime(dt1.Rows[i][2].ToString()).AddDays(0);
                    DateTime WeakEndDate   = Convert.ToDateTime(dt1.Rows[i][3].ToString()).AddDays(0);

                    html += "<tr style='background-color: cyan;'><th colspan=6 style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Regional Office : " + ROffice.Trim() + "</th><th colspan=6 style='text-align: center;padding: 0 5px;border:1px solid #797979;'>IA Name : " + IAName + "</th></tr>";
                    html += "<tr style='background-color: beige;'><th colspan=6 style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Weak Start Date : "+WeakStartDate.ToString("dd-MM-yyyy")+"</th><th colspan=6 style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Weak End Date : "+WeakEndDate.ToString("dd-MM-yyyy")+"</th></tr>";
                    html += "<tr style='background-color: #ccc;'><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'> SNO </th><th style='text-align: center;padding:  0 5px;border:1px solid #797979;'> IA Name </th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Application ID</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Applicant Name</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Submission Date</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Plot No</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Accounts Clearance</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Data Verification</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>RM Approval</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>CMIA Approval</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>MD Approval</th><th style='text-align: center;padding: 0 5px;border:1px solid #797979;'>Final Status</th></tr>";
                    DataRow[] dr = dt2.Select("IAName = '" + IAName + "' and FinalSubmitDate>='" + WeakStartDate + "' and FinalSubmitDate<='" + WeakEndDate + "'");
                    if (dr.Length > 0)
                    {
                        dt3 = dr.CopyToDataTable();
                    }
                    if (dt3.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            
                            string IAName1       = dt3.Rows[j][0].ToString();
                            string ID            = dt3.Rows[j][1].ToString();
                            string ApplicantName = dt3.Rows[j][2].ToString();
                            string FinalDate     = dt3.Rows[j][3].ToString();
                            string PlotNo        = dt3.Rows[j][4].ToString();
                            string Account       = dt3.Rows[j][6].ToString();
                            string DA            = dt3.Rows[j][7].ToString();
                            string RM            = dt3.Rows[j][8].ToString();
                            string CMIA          = dt3.Rows[j][9].ToString();
                            string MD            = dt3.Rows[j][10].ToString();
                            string Final         = dt3.Rows[j][11].ToString();
                            DateTime FinalSubDate   = Convert.ToDateTime(FinalDate);
                            html += "<tr><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + (j+1).ToString() + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + IAName1 + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ID + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + ApplicantName + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + FinalSubDate.ToString("dd-MM-yyyy") + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + PlotNo + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + Account + "</td><td style='text-align: left;padding: 0 5px;border:1px solid #ccc;'>" + DA + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + RM + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + CMIA + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + MD + "</td><td style='text-align: left;padding:  0 5px;border:1px solid #ccc;'>" + Final + "</td></tr>";
                        }
                    }
                }


                html += "</table>";
                Literal loLit = new Literal();
                loLit.Text = (html);
                ph.Controls.Add(loLit);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}