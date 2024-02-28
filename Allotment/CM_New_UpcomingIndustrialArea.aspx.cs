using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class CM_New_UpcomingIndustrialArea : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        SqlConnection con = new SqlConnection();
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string UserName = "";
        string CompanyId = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                CompanyId = Session["Companyid"].ToString();
            }
            catch
            {
                Response.Redirect("/IDADashboard.aspx");
            }
            if (!IsPostBack)
            {
                check_user_role();
                //bindIndustrialAreaDetail();
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gridFunc();
        }
        private void gridFunc()
        {

            GetNew_UpcomingIndustrialAreaDetail();
        }
        #region Bind DropDown
        //private void bindregion(string reg)
        //{


        //    DataSet dsR = new DataSet();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "' ", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        dlregion.DataSource = dt;
        //        dlregion.DataTextField = "a";
        //        dlregion.DataValueField = "b";
        //        dlregion.DataBind();
        //        dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }

        //}
        private void bindCompanyName()
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetAuthorityDetail] '" + UserName + "' , " + CompanyId + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlAuthority.DataSource = dt;
                ddlAuthority.DataTextField = "AuthortyName";
                ddlAuthority.DataValueField = "id";
                ddlAuthority.DataBind();
                ddlAuthority.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        //private void bindLandType()
        //{
        //    DataSet dsR = new DataSet();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[spGetLandType]", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        ddlPlotType.DataSource = dt;
        //        ddlPlotType.DataTextField = "TypeofVacentArea";
        //        ddlPlotType.DataValueField = "Id";
        //        ddlPlotType.DataBind();
        //        ddlPlotType.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }

        //}
        //private void bindIA(string IA)
        //{

        //    DataSet dsR = new DataSet();
        //    try
        //    {

        //        dsR = objServiceTimelinesBLL.GetIAUserRoleWise(IA);
        //        IaDdl.DataSource = dsR;
        //        IaDdl.DataTextField = "IAName";
        //        IaDdl.DataValueField = "Id";
        //        IaDdl.DataBind();
        //        IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }

        //}
        protected void ddlAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAuthority.SelectedIndex > 0)
            {
                bindGridDetail(ddlAuthority.SelectedValue.Trim());
            }

            //objServiceTimelinesBEL.CorporationName = (ddlAuthority.SelectedValue.Trim());
            //objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            //try
            //{
            //    ds = objServiceTimelinesBLL.GetCMregionalNameRecords(objServiceTimelinesBEL);
            //    dlregion.DataSource = ds;
            //    dlregion.DataTextField = "a";
            //    dlregion.DataValueField = "b";
            //    dlregion.DataBind();
            //    dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //reset1();
            //    //if (dlregion.SelectedIndex > 0)
            //    //{
            //    // bindRateGrid1(dlregion.SelectedValue.Trim(), ""); } else { bindRateGrid("", ""); }


            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Oops! error occured :" + ex.Message.ToString());
            //}
        }
        private void bindGridDetail(string CompanyId)
        {
            SqlCommand cmd = new SqlCommand("sp_CM_GetUpcomingIndustrialDetailTemp '" + CompanyId + "','" + txtSearch.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                //lblTotal.Text = dt.Rows[0]["Total"].ToString().Trim();
                lblArea.Text = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea")).ToString();
                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea"));
                GridView1.FooterRow.Cells[0].Text = "Total";
                GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                GridView1.FooterRow.Cells[7].Text = total.ToString("N2");
            }
        }
        //protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
        //    objServiceTimelinesBEL.UserName = UserName;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetCM_RegionNameIndustrialDetail(objServiceTimelinesBEL);
        //        IaDdl.DataSource = ds;
        //        IaDdl.DataTextField = "IAName";
        //        IaDdl.DataValueField = "Id";
        //        IaDdl.DataBind();
        //        IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
        //        //reset1();
        //        //if (dlregion.SelectedIndex > 0)
        //        //{
        //        // bindRateGrid1(dlregion.SelectedValue.Trim(), ""); } else { bindRateGrid("", ""); }


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}
        private void check_user_role()
        {


            //bindregion("");
            bindCompanyName();
            //bindLandType();
            GetNew_UpcomingIndustrialAreaDetail();


        }

        #endregion
        public void GetNew_UpcomingIndustrialAreaDetail()
        {
            try
            {
                DataSet ds = new DataSet();
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                CompanyId = Session["Companyid"].ToString();
                objServiceTimelinesBEL.UserName = UserName;
                objServiceTimelinesBEL.Companyid = CompanyId;
                objServiceTimelinesBEL.SearchRecord = txtSearch.Text;
                //objServiceTimelinesBEL.IAName = IaDdl.SelectedItem.Text.Trim();
                ds = objServiceTimelinesBLL.GetCM_New_UpcomingIndustrialDetail(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    //lblTotal.Text = dt.Rows[0]["Total"].ToString().Trim();
                    lblArea.Text = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea")).ToString();
                    //GridView1.FooterRow.Cells[1].Text = dt.Compute("sum(" + dt.Columns[1].ColumnName + ")", null).ToString();
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea"));
                    GridView1.FooterRow.Cells[0].Text = "Total";
                    GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[7].Text = total.ToString("N2");
                    //GridView1.FooterRow.Cells[5].Text = (GridView1.Rows.Count.ToString());
                    //DataTable firstTable = ds.Tables[0];
                    //ViewState["CurrentTable"] = firstTable;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (IaDdl.SelectedIndex == 0)
                //{

                //    MessageBox1.ShowWarning("Please Select Industrial Area");
                //    return;
                //}
                if (ddlAuthority.SelectedIndex == 0)
                {

                    MessageBox1.ShowWarning("Please Select Corporation/Authority");
                    return;
                }
                if (ddlStatus.SelectedIndex == 0)
                {

                    MessageBox1.ShowWarning("Please Select Currunt Status");
                    return;
                }

                objServiceTimelinesBEL.CorporationName = ddlAuthority.SelectedItem.Value;
                objServiceTimelinesBEL.NameofScheme = txtNameofScheme.Text.Trim();
                objServiceTimelinesBEL.Location = txtLocation.Text.Trim();
                objServiceTimelinesBEL.SponsorAgency = ddlStatusofWork.SelectedItem.Value;
                objServiceTimelinesBEL.NumberofArea = txtNumberofArea.Text.Trim();
                //objServiceTimelinesBEL.ProjectDetail = txtProjectDetail.Text.Trim();
                objServiceTimelinesBEL.Developed = txtDeveloped.Text.Trim();

                objServiceTimelinesBEL.plotSize = txtPlotSize.Text.Trim();
                objServiceTimelinesBEL.LandStatus = ddlStatus.SelectedItem.Text;
                objServiceTimelinesBEL.Remark = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.WebURL = txtWebUrl.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);
                try
                {
                    if (btnSubmit.Text == "Save")
                    {

                        int retVal = objServiceTimelinesBLL.SaveCM_New_UpcomingIndustrialDetail(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Inserted successfully");
                            gridFunc();
                            reset();

                            //BindServiceCheckListGridView();
                            //BindCategory();
                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                    if (btnSubmit.Text == "Update")
                    {
                        objServiceTimelinesBEL.ID = Convert.ToInt32(RateIdlbl.Text.Trim());
                        int retVal = objServiceTimelinesBLL.UpdateCM_New_UpcomingIndustrialDetail(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Update Successfully");
                            gridFunc();
                            reset();

                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Process")
                {
                    //string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                    int rowid = Convert.ToInt32(e.CommandArgument.ToString());
                    bindGridDetail("");

                    get_prev_rate(rowid);
                }

                if (e.CommandName == "DeleteVacant")
                {
                    int rowid = Convert.ToInt32(e.CommandArgument.ToString());
                    objServiceTimelinesBEL.ID = rowid;
                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteCM_New_UpcomingIndustrialDetail(objServiceTimelinesBEL);

                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Delete Record Successfully");
                            gridFunc();
                        }
                        else
                        {
                            MessageBox1.ShowError("Some Error Occured");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured :" + ex.Message.ToString());
                    }
                    finally
                    {

                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridFunc();
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["GridView1"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }

                GridView1.DataSource = dtrslt;
                GridView1.DataBind();
            }
        }
        private void get_prev_rate(int rowid)
        {
            objServiceTimelinesBEL.ID = rowid;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPreCM_New_UpcomingIndustrialDetail(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    ddlAuthority.SelectedValue = dt.Rows[0]["CorporationName"].ToString().Trim();
                    //string regoffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();
                    //dlregion.SelectedValue = regoffice.Trim();
                    //dlregion_SelectedIndexChanged(null, null);
                    RateIdlbl.Text = dt.Rows[0]["AreaID"].ToString();
                    //IaDdl.SelectedValue = dt.Rows[0]["IAID"].ToString().Trim();
                    //ddlPlotType.SelectedValue = dt.Rows[0]["VacantType"].ToString().Trim();
                    txtNameofScheme.Text = dt.Rows[0]["NameofScheme"].ToString().Trim();
                    txtLocation.Text = dt.Rows[0]["Location"].ToString().Trim();
                    ddlStatusofWork.SelectedValue = dt.Rows[0]["SponsorAgency"].ToString().Trim();
                    txtNumberofArea.Text = dt.Rows[0]["NumberofArea"].ToString().Trim();
                    //txtProjectDetail.Text = dt.Rows[0]["ProjectDetail"].ToString().Trim();
                    txtDeveloped.Text = dt.Rows[0]["Developed"].ToString().Trim();
                    txtPlotSize.Text = dt.Rows[0]["TotalArea"].ToString().Trim();
                    ddlStatus.SelectedValue = dt.Rows[0]["LandStatus"].ToString().Trim();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();
                    txtWebUrl.Text = dt.Rows[0]["WebURL"].ToString().Trim();
                    btnSubmit.Text = "Update";
                }
                else
                {
                    btnSubmit.Text = "Submit";
                    RateIdlbl.Text = "0";
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }



        }
        protected void save_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        protected void reset_ServerClick(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
        }
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            //Response.Redirect("DashboardI.aspx");
        }
        private void reset()
        {
            btnSubmit.Text = "Save";
            //dlregion.SelectedIndex = 0;
            ddlAuthority.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            //ddlPlotType.SelectedIndex = 0;
            RateIdlbl.Text = "";
            //IaDdl.Items.Clear();
            //txtPlotNo.Text = "";
            txtDeveloped.Text = "";
            txtNameofScheme.Text = "";
            txtNumberofArea.Text = "";
            //txtProjectDetail.Text = "";
            txtPlotSize.Text = "";
            txtLocation.Text = "";
            txtRemarks.Text = "";
            txtWebUrl.Text = "";
            GetNew_UpcomingIndustrialAreaDetail();
        }
    }
}