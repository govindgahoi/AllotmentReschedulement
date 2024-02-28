using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace UpsidaAllottee
{
    public partial class UpdateAllotmentDetails : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        string UserName = "";
        string IndustrialArea = "";
        #endregion
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexPhoneNo = new Regex(@"^[0-9]{10}$");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblname.Text = Convert.ToString(Session["UserName"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                warningmsg.Visible = false;

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
                GetIAAssociatedWithRM(UserName, Session["Type"].ToString().Trim());
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
                    //lbldesignationid = ds.Tables[0].Rows[0]["DesignationID"].ToString();
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
            finally
            {
                //objServiceTimelinesBEL = null;
                //objServiceTimelinesBLL = null;
            }


            //masterMenu(Session["Type"].ToString().Trim());
        }
        private void GetIAAssociatedWithRM(string userName, string category)
        {
            //objServiceTimelinesBEL.Roll = category;
            //objServiceTimelinesBEL.UserName = userName;
            
            DataSet ds = new DataSet();
            try
            {
                //ds = objServiceTimelinesBLL.GetIAAssociatedWithRM(objServiceTimelinesBEL);
                SqlCommand cmd = new SqlCommand("usp_GetIAAssociatedWithRM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", category);
                cmd.Parameters.AddWithValue("@userID", userName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                DlIA.DataSource = ds;
                DlIA.DataTextField = "IAName";
                DlIA.DataValueField = "IAName";
                DlIA.DataBind();
                ListItem liIArea = new ListItem("--Select All--", "-1");
                DlIA.Items.Insert(0, liIArea);
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

     
        protected void DlIA_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (DlIA.SelectedIndex == 0)
            {
                txtSearch.Text = "";
                txtSearch.Enabled = false;
                gridView.Visible = false;
                warningmsg.Visible = false;


            }
            else
            {
                txtSearch.Enabled = true;
                txtSearch.Text = "";
                gridView.Visible = false;
                warningmsg.Visible = false;
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DlIA.SelectedIndex == 0)
            {
                txtSearch.Text = "";
                txtSearch.Enabled = false;
            }
            else
            {
                txtSearch.Enabled = true;
                //Label2.Visible = false;
            }
        }

        //[WebMethod]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public  List<string> GetAutoCompleteData(string txtSearch)
        //{
        //    List<string> result = new List<string>();
        //   string IndustrialArea = DlIA.SelectedValue;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("usp_getAllotteeName", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    cmd.Parameters.AddWithValue("@IAName", IndustrialArea);
        //    cmd.Parameters.AddWithValue("@AllotteeName", txtSearch);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                result.Add(dr["AllotteeName"].ToString());
        //            }
        //            return result;
        //}

        protected void GridView_Load(object sender, EventArgs e)
        {
            warningmsg.Visible = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_getAllotteDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IAName", DlIA.SelectedValue);
            cmd.Parameters.AddWithValue("@PlotNo", txtSearch.Text);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            gridView.Visible = true;
            gridView.DataSource = dt;
            gridView.DataBind();
            if (dt.Rows.Count > 0)
            {
                gridView.Visible = true;
            }
            else
            {
                gridView.Visible = true;
            }
        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            //GridView_Load();
        }
        
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            //GridView_Load();
        }
       
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Match match;
                Match match1;
                //Match match2;
               
                string e1 = e.Row.Cells[6].Text.Trim();
                string p1 = e.Row.Cells[7].Text.Trim();
                string inrst =e.Row.Cells[8].Text.Trim() == "&nbsp;" ? "0" : e.Row.Cells[8].Text;
                decimal intrstRate = decimal.Parse(inrst);
                match = regex.Match(e1);
                match1 = regexPhoneNo.Match(p1);
                //if (match.Success && match1.Success && intrstRate > 0 && intrstRate <= 18)
                //{
                //    e.Row.Cells[10].Text = "";
                //}
                
                
            }
        }
       

        protected void Edit(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            
            using (GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent)
            {
                txtIAName.Text = row.Cells[1].Text.Replace("&amp;", " ");

                txtIAName.Text = row.Cells[1].Text.Replace("&#160;", " ");
                //ia.Replace("&amp;", "&");
                //txtIAName.Text = ia;

                txtAllottee.ReadOnly = true;
                txtAllottee.Text = row.Cells[2].Text.Trim() == "&nbsp;" ? "" : row.Cells[2].Text.Trim();

                txtAllotmentletterno.ReadOnly = true;
                txtAllotmentletterno.Text = row.Cells[3].Text.Trim() == "&nbsp;" ? "" : row.Cells[3].Text.Trim();


                txtPlotNo.ReadOnly = true;
                txtPlotNo.Text = row.Cells[5].Text.Trim();

                txtEmailID.Text = row.Cells[6].Text.Trim() == "&nbsp;"? "": row.Cells[6].Text.Trim();
                txtEmailID.ReadOnly = false;
                #region 
                //Match match = regex.Match(txtEmailID.Text);
                //if (match.Success)
                //{
                //    txtEmailID.ReadOnly = true;
                //    //txtEmailID.Cursor = Cursors.Arrow;
                //}
                //else
                //{
                //    txtEmailID.ReadOnly = false;
                //}
                #endregion

                txtPhoneNo.Text = row.Cells[7].Text.Trim() == "&nbsp;" ? "" : row.Cells[7].Text.Trim();
                txtPhoneNo.ReadOnly = false;
                #region
                //Match match1 = regexPhoneNo.Match(txtPhoneNo.Text);
                //if (match1.Success)
                //{
                //    txtPhoneNo.ReadOnly = true;
                //}
                //else
                //{
                //    txtPhoneNo.ReadOnly = false;
                //}
                #endregion
                string inrst = row.Cells[8].Text.Trim() == "&nbsp;" ? "0" : row.Cells[8].Text.Trim();

                decimal intrstRate = decimal.Parse(inrst);
                txtInterestRate.Text = row.Cells[8].Text.Trim() == "&nbsp;" ? "" : row.Cells[8].Text.Trim();
                txtInterestRate.ReadOnly = false;
                #region
                //if (intrstRate <= 0 || intrstRate >= 18 || intrstRate == null)
                //{ 
                //    txtInterestRate.ReadOnly = false;
                //}
                //else
                //{
                //    txtInterestRate.ReadOnly = true;
                //}
                #endregion

                txtestimatedcost.Text = row.Cells[10].Text.Trim() == "&nbsp;" ? "" : row.Cells[10].Text.Trim();
                txtestimatedcost.ReadOnly = false;

                txtestimatedemployment.Text = row.Cells[11].Text.Trim() == "&nbsp;" ? "" : row.Cells[11].Text.Trim();
                txtestimatedemployment.ReadOnly = false;


                if (txtInterestRate.ReadOnly == true && txtPhoneNo.ReadOnly == true && txtEmailID.ReadOnly == true)
                {
                    btnSave.Enabled = false;
                }
                popup.Show();
            }
        }

        protected void Demand(object sender, EventArgs e)
        {

        }
        protected void Save(object sender, EventArgs e)
        {
            string email = txtEmailID.Text.Trim();
            string Phone = txtPhoneNo.Text.Trim();
            string Allotmentletterno = txtAllotmentletterno.Text.Trim();
            string estimatedcost = txtestimatedcost.Text.Trim();
            string estimatedemployment = txtestimatedemployment.Text.Trim();
            
            string interest = txtInterestRate.Text;
            if (email == "" || Phone == "" || interest =="")
            {
                Response.Write("<script>alert('Invalid Detail. Please mention correct information. ')</script>");
            }
            else
            {
                DateTime now = DateTime.Now;
                SqlCommand cmd = new SqlCommand("usp_update_AllotteDetail_New", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@updatedBy", UserName);
                cmd.Parameters.AddWithValue("@updatedOn", now);
                cmd.Parameters.AddWithValue("@IAName", txtIAName.Text);
                cmd.Parameters.AddWithValue("@AllotteeName", txtAllottee.Text);
                cmd.Parameters.AddWithValue("@PlotNo", txtPlotNo.Text);
                cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Allotmentletterno", Allotmentletterno);
                cmd.Parameters.AddWithValue("@estimatedcost", estimatedcost);
                cmd.Parameters.AddWithValue("@estimatedemployment", estimatedemployment);
                cmd.Parameters.AddWithValue("@InterestRate", txtInterestRate.Text);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataTable flag = EmailPhoneVerification(email, Phone);
                if (flag.Rows.Count <= 0)
                {
                    gridView.DataSource = dt;
                    gridView.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        gridView.Visible = true;
                    }
                    else
                    {
                        gridView.Visible = true;
                    }
                }
                else
                {
                    warningmsg.Visible = true;
                    gridView.DataSource = dt;
                    gridView.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        gridView.Visible = true;
                    }
                    else
                    {
                        gridView.Visible = true;
                    }
                    //warningmsg.Visible = true;
                   // Response.Write("<script>alert('Duplicate EmailID or Phone Number. Please mention correct information. ')</script>");
                }
            }
        }

        protected DataTable EmailPhoneVerification(string email, string Phone)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("usp_EmailPhone_Verification", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@phone", Phone);
            cmd1.Parameters.AddWithValue("@email", email);
            SqlDataAdapter adp = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //protected void Demand(object sender, EventArgs e)
        //{
        //    string email = txtEmailID.Text.Trim();
        //    string Phone = txtPhoneNo.Text.Trim();
        //    string interest = txtInterestRate.Text;
        //    //string CostPlot = txtTotPCost.Text.Trim();
        //    //string paids = txtTotPaid.Text.Trim();
        //    //string Defaults = txtDAmount.Text.Trim();
        //    //string Rebates = ddlRebate.SelectedItem.Text;
        //    //string RebateInt = txtReBateInt.Text.Trim();
        //    //string Outstanding = txtOutstanding.Text.Trim();
        //    //string OutstandingInt = txtDefaultInt.Text.Trim();
        //    //string Installment = txtBalInstall.Text.Trim();
        //    if (email == "" || Phone == "" || interest == "")
        //    {
        //        Response.Write("<script>alert('Invalid Detail. Please mention correct information. ')</script>");
        //    }
        //    else
        //    {
        //         //string                 
        //         //warningmsg.Visible = true;
        //         // Response.Write("<script>alert('Duplicate EmailID or Phone Number. Please mention correct information. ')</script>");              
        //    }
        //}

        //protected void txtTotPCost_TextChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToDecimal(txtTotPCost.Text.Trim()) > 0)
        //    {
        //        txtOutstanding.Text = Convert.ToDecimal(txtTotPCost.Text.Trim()).ToString();
        //        if (Convert.ToDecimal(txtTotPaid.Text.Trim()) > 0)
        //        {
        //            txtOutstanding.Text= (Convert.ToDecimal(txtOutstanding.Text) - Convert.ToDecimal(txtTotPaid.Text.Trim())).ToString();
        //        }
        //        if (Convert.ToDecimal(txtDAmount.Text.Trim()) > 0)
        //        {
        //            txtOutstanding.Text = (Convert.ToDecimal(txtOutstanding.Text) - Convert.ToDecimal(txtDAmount.Text.Trim())).ToString();
        //        }
        //    }
        //}

        //protected void txtTotPaid_TextChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToDecimal(txtTotPaid.Text.Trim()) > 0)
        //    {
        //        txtOutstanding.Text = (-Convert.ToDecimal(txtTotPaid.Text.Trim())).ToString();
        //        if (Convert.ToDecimal(txtTotPCost.Text.Trim()) > 0)
        //        {                                     
        //            txtOutstanding.Text = (Convert.ToDecimal(txtOutstanding.Text) + Convert.ToDecimal(txtTotPCost.Text.Trim())).ToString();
                    
        //            if (Convert.ToDecimal(txtDAmount.Text.Trim()) > 0)
        //            {
        //                txtOutstanding.Text = (Convert.ToDecimal(txtOutstanding.Text) - Convert.ToDecimal(txtDAmount.Text.Trim())).ToString();
        //            }
        //        }
        //    }
        //}

        //protected void txtDAmount_TextChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToDecimal(txtDAmount.Text.Trim()) > 0)
        //    {
        //        txtOutstanding.Text = (-Convert.ToDecimal(txtDAmount.Text.Trim())).ToString();
        //        if (Convert.ToDecimal(txtTotPCost.Text.Trim()) > 0)
        //        {
        //            txtOutstanding.Text = (Convert.ToDecimal(txtOutstanding.Text) + Convert.ToDecimal(txtTotPCost.Text.Trim())).ToString();
        //            if (Convert.ToDecimal(txtTotPaid.Text.Trim()) > 0)
        //            {
        //                txtOutstanding.Text = (Convert.ToDecimal(txtOutstanding.Text) - Convert.ToDecimal(txtTotPaid.Text.Trim())).ToString();
        //            }
        //        }
        //    }
        //}

    }
}