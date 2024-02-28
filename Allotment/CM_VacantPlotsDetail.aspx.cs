using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class VacantPlotsDetail : System.Web.UI.Page
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
                Response.Redirect("/Default.aspx");
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

            GetVacantPlotsDetail();

        }
        #region Bind DropDown
        private void bindregion(string reg)
        {


            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dlregion.DataSource = dt;
                dlregion.DataTextField = "a";
                dlregion.DataValueField = "b";
                dlregion.DataBind();
                dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
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
        private void bindLandType()
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[spGetLandType]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlPlotType.DataSource = dt;
                ddlPlotType.DataTextField = "TypeofVacentArea";
                ddlPlotType.DataValueField = "Id";
                ddlPlotType.DataBind();
                ddlPlotType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindIA(string IA)
        {

            DataSet dsR = new DataSet();
            try
            {

                dsR = objServiceTimelinesBLL.GetIAUserRoleWise(IA);
                IaDdl.DataSource = dsR;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                //IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        protected void ddlAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.CorporationName = (ddlAuthority.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCMregionalNameRecords(objServiceTimelinesBEL);
                dlregion.DataSource = ds;
                dlregion.DataTextField = "a";
                dlregion.DataValueField = "b";
                dlregion.DataBind();
                dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
                reset1();
                if (ddlAuthority.SelectedIndex > 0)
                {
                    bindGridDetail("", "", ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
                }
                else
                {
                    GetVacantPlotsDetail();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCM_RegionNameIndustrialDetail(objServiceTimelinesBEL);
                IaDdl.DataSource = ds;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
                if (dlregion.SelectedIndex > 0)
                {
                    bindGridDetail("", dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
                }
                else
                {
                    bindGridDetail("", "", ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IaDdl.SelectedIndex > 0)
            {
                bindGridDetail(IaDdl.SelectedValue.Trim(), dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
            }
            else
            {
                bindGridDetail("", dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
            }
        }
        private void check_user_role()
        {


            bindregion("");
            bindCompanyName();
            bindLandType();
            GetVacantPlotsDetail();


        }
        private void bindGridDetail(string IAId, string RegionalOffice, string CompanyId, string Search)
        {
            SqlCommand cmd = new SqlCommand("sp_CM_GetVacentPlotDetailTemp '" + IAId + "','" + RegionalOffice + "','" + CompanyId + "','" + Search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            try
            {
                lblArea.Text = "0";
                lblTotal.Text = "0";
                if (dt.Rows.Count > 0)
                {
                    lblTotal.Text = dt.Rows[0]["Total"].ToString().Trim();
                    lblArea.Text = dt.Rows[0]["TotalArea_sum"].ToString().Trim();
                    //GridView1.FooterRow.Cells[1].Text = dt.Compute("sum(" + dt.Columns[1].ColumnName + ")", null).ToString();
                    decimal total = Convert.ToDecimal(dt.Rows[0]["TotalArea_InSqrmtr"].ToString().Trim());
                    lblArea.Text = dt.Rows[0]["TotalArea_sum"].ToString().Trim();
                    GridView1.FooterRow.Cells[0].Text = "Total";
                    GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[6].Text = total.ToString("N2");
                    //GridView1.FooterRow.Cells[5].Text = (GridView1.Rows.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        #endregion
        public void GetVacantPlotsDetail()
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
                lblArea.Text = "0";
                lblTotal.Text = "0";
                ds = objServiceTimelinesBLL.GetCM_VacentPlotDetail(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    lblTotal.Text = dt.Rows[0]["Total"].ToString().Trim();
                    decimal total = Convert.ToDecimal(dt.Rows[0]["TotalArea_InSqrmtr"].ToString().Trim());
                    lblArea.Text = dt.Rows[0]["TotalArea_sum"].ToString().Trim();
                    //lblArea.Text = dt.Rows[0]["TotalArea_sum"].ToString().Trim();
                    //GridView1.FooterRow.Cells[1].Text = dt.Compute("sum(" + dt.Columns[1].ColumnName + ")", null).ToString();
                    //decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalArea"));
                    GridView1.FooterRow.Cells[0].Text = "Total";
                    GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[6].Text = total.ToString("N2");
                    //GridView1.FooterRow.Cells[5].Text=(GridView1.Rows.Count.ToString());
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
                if (IaDdl.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Please Select Industrial Area");
                    return;
                }
                if (ddlAuthority.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Please Select Corporation/Authority");
                    return;
                }
                if (dlregion.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Please Select Industrial Area");
                    return;
                }
                if (ddlPlotType.SelectedIndex == 0)
                {

                    MessageBox1.ShowInfo("Please Select Type of Vacant Area");
                    return;
                }
                if (txtPlotNo.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide Plot No");
                    return;
                }
                if (txtPlotSize.Text == "")
                {
                    MessageBox1.ShowInfo("Please Provide  Plot Area In Sqmts");
                    return;
                }
                //objServiceTimelinesBEL.IAId = Convert.ToInt32(IaDdl.SelectedItem.Value);

                objServiceTimelinesBEL.IAName = IaDdl.SelectedItem.Value;
                objServiceTimelinesBEL.VacantType = ddlPlotType.SelectedItem.Value;
                objServiceTimelinesBEL.CorporationName = ddlAuthority.SelectedItem.Value;
                //objServiceTimelinesBEL.TotalVacantPlots = Convert.ToInt32(txtVacantPlots.Text.Trim());
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                if (ddlSqrmtr.SelectedItem.Value == "0")
                {
                    objServiceTimelinesBEL.plotSize = txtPlotSize.Text.Trim();
                }
                else
                {
                    double plotArea = Convert.ToDouble(txtPlotSize.Text.Trim());
                    double plotSize = (plotArea / 4046.856);
                    objServiceTimelinesBEL.plotSize = Convert.ToString(plotSize);
                }


                objServiceTimelinesBEL.Remark = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);

                try
                {
                    if (btnSubmit.Text == "Save")
                    {

                        int retVal = objServiceTimelinesBLL.SaveCM_VacentPlotDetail(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Inserted successfully");
                            bindGridDetail(IaDdl.SelectedValue.Trim(), dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
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
                        int retVal = objServiceTimelinesBLL.UpdateCM_VacentPlotDetail(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Record Update Successfully");
                            bindGridDetail(IaDdl.SelectedValue.Trim(), dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
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
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });
                    int rowid = Convert.ToInt32(commandArgs[0]);
                    string iaID = commandArgs[1];
                    string regoffice = commandArgs[2].Trim();
                    //dlregion_SelectedIndexChanged(null, null);
                    //IaDdl.SelectedValue = iaID.Trim();
                    get_prev_rate(rowid);
                }
                if (e.CommandName == "DeleteVacant")
                {
                    int rowid = Convert.ToInt32(e.CommandArgument.ToString());
                    objServiceTimelinesBEL.ID = rowid;
                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteCM_VacentPlotDetail(objServiceTimelinesBEL);

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
            if (ddlAuthority.SelectedIndex == 0 && dlregion.SelectedIndex == 0)
            {
                GetVacantPlotsDetail();
            }
            else if (ddlAuthority.SelectedIndex == 0)
            {
                bindGridDetail(IaDdl.SelectedValue.Trim(), dlregion.SelectedValue.Trim(), " ", txtSearch.Text.Trim());
            }
            else if (dlregion.SelectedIndex == 0)
            {
                bindGridDetail("", "", ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
            }
            else if (IaDdl.SelectedIndex == 0)
            {
                bindGridDetail("", dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
            }
            else
            {
                bindGridDetail(IaDdl.SelectedValue.Trim(), dlregion.SelectedValue.Trim(), ddlAuthority.SelectedValue.Trim(), txtSearch.Text.Trim());
            }
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
                ds = objServiceTimelinesBLL.GetCM_PreVacentPlot(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ddlAuthority.SelectedValue = dt.Rows[0]["CorporationName"].ToString().Trim();
                    ddlAuthority_SelectedIndexChanged(null, null);
                    string regoffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();
                    dlregion.SelectedValue = regoffice.Trim();
                    dlregion_SelectedIndexChanged(null, null);
                    RateIdlbl.Text = dt.Rows[0]["VacantID"].ToString();
                    IaDdl.SelectedValue = dt.Rows[0]["IAID"].ToString().Trim();
                    ddlPlotType.SelectedValue = dt.Rows[0]["VacantType"].ToString().Trim();
                    //txtVacantPlots.Text = dt.Rows[0]["TotalVacantPlots"].ToString().Trim();
                    txtPlotNo.Text = dt.Rows[0]["PlotNumber"].ToString().Trim();
                    txtPlotSize.Text = dt.Rows[0]["TotalArea"].ToString().Trim();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();
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
            Response.Redirect("CM_Dashboard.aspx");
        }
        private void reset1()
        {

            dlregion.SelectedIndex = 0;
            ddlPlotType.SelectedIndex = 0;
            IaDdl.Items.Clear();
        }
        private void reset()
        {
            btnSubmit.Text = "Save";
            //dlregion.SelectedIndex = 0;
            //ddlAuthority.SelectedIndex = 0;
            //ddlPlotType.SelectedIndex = 0;
            RateIdlbl.Text = "";
            //IaDdl.Items.Clear();
            txtPlotNo.Text = "";
            txtPlotSize.Text = "";
            txtRemarks.Text = "";
        }
    }
}