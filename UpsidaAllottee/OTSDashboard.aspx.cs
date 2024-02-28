using BEL_Allotment;
using BLL_Allotment;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpsidaAllottee
{
    public partial class OTSDashboard : System.Web.UI.Page
    {
        #region
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string level = "";
        string IndustrialArea = "";
    #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
                level = Convert.ToString(Session["Level"]);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                if (level == "Admin1" || level == "MD" || level == "JMD")
                {
                    //dlRO.Enabled = true;
                }
                else
                {
                    //dlRO.Enabled = false;
                }
            }
            catch
            {
                Response.Redirect("/loginpage.aspx");
            }
            if (lblname.Text == "")
            {
                Response.Redirect("/loginpage.aspx");
            }
            else
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());
                BindPaidAmount(lblname.Text, Session["Type"].ToString().Trim());
                GeTTransactionDetail(lblname.Text, Session["Type"].ToString().Trim());

                //if (level == "RM")
                //{
                //    btnTransactionReport.Visible = false;
                //    Grid_OTSscheme1.Visible = false;
                //    GetUserRecord(lblname.Text, Session["Type"].ToString().Trim());
                //    GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
                //    GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                //}
                //else
                //{
                //    btnTransactionReport.Visible = true;
                //    Grid_OTSscheme.Visible = false;
                //    DlIA.Enabled = false;
                //    TextBox1.Enabled = false;
                //    bindRegionalOffice();
                //    GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
                //    GerTransactionDetail();
                //}

            }
        }
        public void GetUserRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            // LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetUserRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    //lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString(); ///
                    //lblDataManager.Text = ds.Tables[0].Rows[0]["DataManager"].ToString();
                    int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    LoginInfo _objLoginInfo = new LoginInfo(username, category, userID);
                    Session["objLoginInfo"] = _objLoginInfo;

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void BindPaidAmount(string username, string category)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Dashboard_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count>1)
                        {
                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["PaidAmount"].ToString()) == false)
                            {
                                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["BalanceAmount"].ToString()) == false)
                                {
                                    lblOneTimePayment.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"])+ Convert.ToDecimal(ds.Tables[0].Rows[0]["BalanceAmount"])).ToString("0.00");
                                }
                                else
                                {
                                    lblOneTimePayment.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"]).ToString("0.00");
                                }
                                    
                            }
                            else
                            {
                                lblOneTimePayment.Text = "0.00";
                            }
                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[1]["PaidAmount"].ToString()) == false)
                            {
                                decimal inst1 = string.IsNullOrEmpty(ds.Tables[0].Rows[1]["Inst1"].ToString()) ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[1]["Inst1"]);
                                decimal inst2 = string.IsNullOrEmpty(ds.Tables[0].Rows[1]["Inst2"].ToString()) ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[1]["Inst2"]);
                                decimal inst3 = string.IsNullOrEmpty(ds.Tables[0].Rows[1]["Inst3"].ToString()) ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[1]["Inst3"]);
                                lblInstalment.Text = ((Convert.ToDecimal(ds.Tables[0].Rows[1]["PaidAmount"]))+ inst1+ inst2 + inst3).ToString("0.00");
                            }
                            else
                            {
                                lblInstalment.Text = "0.00";
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["Schemetype"].ToString() == "0")
                            {
                                lblOneTimePayment.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"]).ToString("0.00");
                                lblInstalment.Text = "0.00";
                            }
                            {
                                lblInstalment.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"])).ToString("0.00");
                                lblOneTimePayment.Text= "0.00";
                            }
                        }
                        
                        
                    }
                    else
                    {
                        lblOneTimePayment.Text = "0.00";
                        lblInstalment.Text = "0.00";
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows.Count > 1)
                        {
                            lblAppliedOneTime.Text = ds.Tables[1].Rows[0]["NumberOFAllottees"].ToString();
                            lblAppliedInstalment.Text = ds.Tables[1].Rows[1]["NumberOFAllottees"].ToString();
                        }
                        else
                        {
                            if (ds.Tables[1].Rows[0]["Schemetype"].ToString() == "0")
                            {
                                lblAppliedOneTime.Text = ds.Tables[1].Rows[0]["NumberOFAllottees"].ToString();
                                lblAppliedInstalment.Text = "N/A";
                            }
                            else
                            {
                                lblAppliedInstalment.Text = ds.Tables[1].Rows[0]["NumberOFAllottees"].ToString();
                                lblAppliedOneTime.Text = "N/A";
                            }
                        }
                    }
                    else
                    {
                        lblAppliedOneTime.Text = "N/A";
                        lblAppliedInstalment.Text = "N/A";
                    }
                    if(ds.Tables[2].Rows.Count > 0)
                    {
                        //lblTotalGrievance.Text = ds.Tables[2].Rows[0][0].ToString();
                    }
                    else
                    {
                        //lblTotalGrievance.Text = "N/A";
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        lblOffline.Text = ds.Tables[3].Rows[0]["Offline"].ToString();
                        lblOnline.Text = ds.Tables[3].Rows[0]["Online"].ToString();
                    }

                    //lblAppliedInstalment.Text = ds.Tables[2].Rows[0]["NumberOFAllottees"].ToString();

                }
                }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal Server Error');", true);
            }
            }

        protected void GeTTransactionDetail(string username, string category)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Transaction_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView_TransactionReport.DataSource = ds;
                    GridView_TransactionReport.DataBind();
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Internal Server Error');", true);
            }
        }

        protected void Grid_TransactionReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void OnPageIndexChanging_TransactionReport(object sender, GridViewPageEventArgs e)
        {
            GridView_TransactionReport.PageIndex = e.NewPageIndex;
            GeTTransactionDetail(lblname.Text, Session["Type"].ToString().Trim());
            //GetApplicationOfOTSscheme(UserName, Session["Type"].ToString().Trim());
        }
        protected void Click_TransactionExport(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_OTS_TransactionExport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@role", Session["Type"].ToString());
                    cmd.Parameters.AddWithValue("@userID", UserName);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Transactions");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=OTSTransactionReport'" + DateTime.Now.ToString("dd/MM/yyyy") + "'.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void OnDateChange(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = "0";
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Transaction_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);
                
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDate.Text));
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView_TransactionReport.DataSource = ds;
                    GridView_TransactionReport.DataBind();
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                GeTTransactionDetail(lblname.Text, Session["Type"].ToString().Trim());
            }
        }
        protected void Click_PayOffline(object sender, EventArgs e)
        {

            //Response.Redirect("http://localhost:49691/OfflinePayment.aspx");
            //Response.Redirect("http://services.stagingupsida.com/OfflinePayment.aspx");
            Response.Redirect("https://eservices.onlineupsidc.com/OfflinePayment.aspx");
        }
        protected void Onddl_Changed(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Transaction_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", Session["Type"].ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", UserName);

                cmd.Parameters.AddWithValue("@TransType", DropDownList1.SelectedValue.ToString().Trim());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView_TransactionReport.DataSource = ds;
                    GridView_TransactionReport.DataBind();
                }
                else
                {
                    GridView_TransactionReport.DataSource = null;
                    GridView_TransactionReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                GeTTransactionDetail(lblname.Text, Session["Type"].ToString().Trim());
            }
        }
    }
}