using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{

    public partial class LandAcquisitions : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                checkuser();
                GetLandAcquistionDetail();

                //bind_group_ddl();
                // bind_user_ddl();
                //bindGroupdetails();
            }
        }

        //private void reset()
        //{
        //    txtTotalAreaNew.Enabled = false;
        //    ddlIANameNew.SelectedValue == "Enable";
        //    txtLocationAddress.Text = "";
        //    txtPlotNo.Text = "";
        //    txtPlotSize.Text = "";
        //    txtSpeciesofTrees.Text = "";
        //    txtNoofTrees.Text = "";
        //    lbluploadingMsg.Text = "";

        //}
        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            checkuser();
            GetLandAcquistionDetail();
        }
        public void checkuser()
        {
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                lblUserId.Text = _objLoginInfo.userName;
                SqlCommand cmd = new SqlCommand("select * from GroupMaster where UserID='" + lblUserId.Text.Trim() + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //MessageBox1.ShowSuccess("Welcome " + dt.Rows[0]["GroupName"].ToString());
                    Group_lbl.Text = dt.Rows[0]["GroupName"].ToString();
                    lblUserId.Text = dt.Rows[0]["UserID"].ToString();


                    Session["GroupName"] = Group_lbl.Text;
                    //login_check();
                    GetLandAcquistionDetail();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "gridviewScroll();", true);
                }
            }
            catch
            {

            }

        }
        //public void login_check()
        //{
        //    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
        //    objServiceTimelinesBEL.UserName = _objLoginInfo.userName;


        //    string value = Session["GroupName"] as string;

        //    if (!(String.IsNullOrEmpty(value)))
        //    {
        //        if (Session["GroupName"].ToString().Length > 0)
        //        {
        //            Group_lbl.Text = Session["GroupName"].ToString();
        //            signin.Visible = false; signout.Visible = true;
        //            if (Group_lbl.Text == "LandAcquisition")

        //            { activity_add.Visible = true; group_add.Visible = true; Group_View.Visible = true; }

        //        }
        //        else
        //        {
        //            Group_lbl.Text = ""; Session["GroupName"] = "";
        //            signin.Visible = true; signout.Visible = false; 
        //            activity_add.Visible = false; group_add.Visible = false; Group_View.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        Group_lbl.Text = ""; Session["GroupName"] = "";
        //        signin.Visible = true; signout.Visible = false; 
        //        activity_add.Visible = false; group_add.Visible = false; Group_View.Visible = false;
        //    }
        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "gridviewScroll();", true);
        //}
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetLandAcquistionDetail();
        }
        public void GetLandAcquistionDetail()
        {
            try
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.SearchRecord = txtSearch.Text;
                ds = objServiceTimelinesBLL.GetLandAcquistionDetail(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                        int columncount = GridView1.Rows[0].Cells.Count;
                        GridView1.Rows[0].Cells.Clear();
                        GridView1.Rows[0].Cells.Add(new TableCell());
                        GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                        GridView1.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        //else
        //{
        //    try
        //    {
        //        objServiceTimelinesBEL.UserName = Session["UserName"].ToString().Trim();
        //        ds = objServiceTimelinesBLL.GetGetUserRoleDetail(objServiceTimelinesBEL);
        //        SqlCommand cmd = new SqlCommand("GetUserRole_sp '" + Session["UserName"].ToString().Trim() + "'", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        objServiceTimelinesBEL.IndustrialArea = dt.Rows[0]["IndustrialArea"].ToString().Trim();
        //        string Level = dt.Rows[0]["Level"].ToString().Trim();
        //        if (Level == "RM")
        //        {
        //            objServiceTimelinesBEL.Parameter = "S";
        //            ds = objServiceTimelinesBLL.GetLandAcquistionDetail(objServiceTimelinesBEL);
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                GridView1.DataSource = ds;
        //                GridView1.DataBind();
        //            }
        //            else
        //            {
        //                if (ds.Tables[0].Rows.Count == 0)
        //                {
        //                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //                    GridView1.DataSource = ds;
        //                    GridView1.DataBind();
        //                    int columncount = GridView1.Rows[0].Cells.Count;
        //                    GridView1.Rows[0].Cells.Clear();
        //                    GridView1.Rows[0].Cells.Add(new TableCell());
        //                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
        //                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }
        //}
        //string value = Session["GroupName"] as string;
        //if (!(String.IsNullOrEmpty(value)))
        //{
        //    if (Session["GroupName"].ToString().Length > 0)
        //    {
        //        SqlCommand cmd2 = new SqlCommand("GetLandacquiredDetail  ", con);
        //        SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
        //        DataTable dt = new DataTable();
        //        adp1.Fill(dt);
        //        if (dt.Rows.Count == 0)
        //        {
        //            DataRow dr = dt.NewRow();

        //            dt.Rows.Add(dr);
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //            GridView1.Rows[0].Visible = false;
        //            dt.Rows.Clear();
        //            dt.AcceptChanges();
        //        }
        //        else
        //        {
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //    }
        //}



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName.Equals("Insert"))
            //{
            //    try
            //    {
            //        TextBox txtTotalAreaNew = (TextBox)GridView1.FooterRow.FindControl("txtTotalAreaNew");
            //        TextBox txtGSLandNew = (TextBox)GridView1.FooterRow.FindControl("txtGSLandNew");
            //        TextBox txtGovtLandNew = (TextBox)GridView1.FooterRow.FindControl("txtGovtLandNew");
            //        TextBox txtPrivateacquisitionLandNew = (TextBox)GridView1.FooterRow.FindControl("txtPrivateacquisitionLandNew");
            //        TextBox txtNotificationDateNew = (TextBox)GridView1.FooterRow.FindControl("txtNotificationDateNew");
            //        TextBox txtAwardAreaNew = (TextBox)GridView1.FooterRow.FindControl("txtAwardAreaNew");
            //        TextBox txtAwardDateNew = (TextBox)GridView1.FooterRow.FindControl("txtAwardDateNew");
            //        TextBox txtPossessionArea = (TextBox)GridView1.FooterRow.FindControl("txtPossessionAreaNew");
            //        TextBox txtPossessionDate = (TextBox)GridView1.FooterRow.FindControl("txtPossessionDateNew");
            //        DropDownList ddlIANameNew = (DropDownList)GridView1.FooterRow.FindControl("ddlIANameNew");
            //        objServiceTimelinesBEL.IndustrialArea = ddlIANameNew.SelectedItem.Text.Trim();
            //        objServiceTimelinesBEL.IAId = Convert.ToInt32(ddlIANameNew.SelectedItem.Value);
            //        objServiceTimelinesBEL.TotalAreaNew = txtTotalAreaNew.Text.Trim();
            //        objServiceTimelinesBEL.GSLandNew = txtGSLandNew.Text.Trim();
            //        objServiceTimelinesBEL.GovtLandNew = txtGovtLandNew.Text.Trim();
            //        objServiceTimelinesBEL.NotificationDate = DateTime.Parse(txtNotificationDateNew.Text.Trim());
            //        objServiceTimelinesBEL.PrivateacquisitionLand = txtPrivateacquisitionLandNew.Text.Trim();
            //        objServiceTimelinesBEL.AwardArea = txtAwardAreaNew.Text.Trim();
            //        objServiceTimelinesBEL.AwardDate = DateTime.Parse(txtAwardDateNew.Text.Trim());
            //        objServiceTimelinesBEL.PossessionArea = txtPossessionArea.Text.Trim();
            //        objServiceTimelinesBEL.PossessionDate = DateTime.Parse(txtPossessionDate.Text.Trim());
            //        objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);
            //        int retVal = objServiceTimelinesBLL.SaveLandAcquistionDetail(objServiceTimelinesBEL);
            //        if (retVal > 0)
            //        {
            //            MessageBox1.ShowSuccess("Record Inserted successfully");
            //            GetLandAcquistionDetail();
            //            //BindVanVibhagGridView();
            //            // reset();
            //            //BindServiceCheckListGridView();
            //            //BindCategory();
            //        }

            //    }
            //    catch (Exception Exc)
            //    {

            //    }

            //}
            if (e.CommandName == "DeleteLandAcquistion")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView1.PageSize;
                int ID = Convert.ToInt32(GridView1.DataKeys[index].Values[0]);
                objServiceTimelinesBEL.ID = ID;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteLandAcquistionDetail(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        MessageBox1.ShowSuccess("Delete Record Successfully");
                        GetLandAcquistionDetail();
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
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        DataSet ds = new DataSet();
            //        ds = objServiceTimelinesBLL.GetIndustrialAreaDetailforLandAcquist();
            //        DropDownList ddlIANameNew = (DropDownList)e.Row.FindControl("ddlIAName");
            //        ddlIANameNew.DataSource = ds;
            //        ddlIANameNew.DataTextField = "IAName";
            //        ddlIANameNew.DataValueField = "Id";
            //        ddlIANameNew.DataBind();
            //        string aks = (e.Row.FindControl("lblId") as Label).Text.Trim();
            //        ddlIANameNew.Items.FindByValue(aks).Selected = true;
            //    }

            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        ds = objServiceTimelinesBLL.GetIndustrialAreaDetailforLandAcquist();
            //        try
            //        {
            //            DropDownList ddlIANameNew = (DropDownList)e.Row.FindControl("ddlIANameNew");
            //            ddlIANameNew.DataSource = ds;
            //            ddlIANameNew.DataTextField = "IAName";
            //            ddlIANameNew.DataValueField = "Id";
            //            ddlIANameNew.DataBind();
            //        }
            //        catch (Exception ex)
            //        {
            //            Response.Write("Oops! error occured :" + ex.Message.ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Oops! error occured :" + ex.Message.ToString());
            //}
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            GetLandAcquistionDetail();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            GetLandAcquistionDetail();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //this code will Cancel the row edit  
            GridView1.EditIndex = -1;

            //Loading the Gridview again  
            GetLandAcquistionDetail();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //retrieving the DataKey name here  
                //objServiceTimelinesBEL.ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                objServiceTimelinesBEL.IAId = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("lblId") as Label).Text);
                objServiceTimelinesBEL.IndustrialArea = (GridView1.Rows[e.RowIndex].FindControl("lblIAName") as Label).Text;
                if ((GridView1.Rows[e.RowIndex].FindControl("txtGSLand") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.GSLandNew = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtGSLand") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtGovtLand") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.GovtLandNew = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtGovtLand") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtPrivateacquisitionLand") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.PrivateacquisitionLand = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtPrivateacquisitionLand") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAwardArea") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.AwardArea = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtAwardArea") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtPossessionArea") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.PossessionArea = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtPossessionArea") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtExpenditureofLA") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.ExpenditureofLA = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtExpenditureofLA") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtNotificationDate") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.NotificationDate = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("txtNotificationDate") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAwardDate") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.AwardDate = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("txtAwardDate") as TextBox).Text.Trim());
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtPossessionDate") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.PossessionDate = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("txtPossessionDate") as TextBox).Text.Trim());
                }

                objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);

                int retVal = objServiceTimelinesBLL.UpdateLandAcquistionDetail(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    MessageBox1.ShowSuccess("Record Update Successfully");
                    GridView1.EditIndex = -1;// no row in edit mode
                    GetLandAcquistionDetail();


                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
                    return;
                }
                // ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;  

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void PlantationGrid_PreRender(object sender, EventArgs e)
        {
            MergeRows(GridView1);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clentscript", "gridviewScroll();", true);


        }
        public static void MergeRows(GridView GridView1)
        {
            int K = 0;

            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                GridViewRow previousRow = GridView1.Rows[rowIndex + 1];
                if (row.Cells[1].Text == previousRow.Cells[1].Text)
                {
                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;
                }

            }

            string prev_hi = "EEE";
            for (int rowIndex = 0; rowIndex < GridView1.Rows.Count; rowIndex++)
            {

                GridViewRow row = GridView1.Rows[rowIndex];
                if (row.Cells[3].Visible == true)
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                        prev_hi = "FFF";
                    }
                    else
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");
                        prev_hi = "EEE";
                    }
                    K++;
                    //  row.Cells[0].Text = K.ToString();
                }
                else
                {
                    if (prev_hi == "EEE")
                    {
                        row.Attributes.Add("style", "background: rgba(238, 238, 238, 0.27) !important;");

                    }
                    else
                    {
                        row.Attributes.Add("style", "background: #FFFFFF !important;");
                    }
                }

            }


        }
        protected void GridView1_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.ColumnSpan = 6;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Private Acquired Land";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Award";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Possession";
                row.Cells.Add(cell);
                GridView1.Controls[0].Controls.AddAt(0, row);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (Group_lbl.Text == "LandAcquisition")
                    {
                        LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                        LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                        lnkEdit.Visible = true;
                        btnDelete.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                }
            }

            //LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            //objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
            //DataSet ds = new DataSet();
            //ds = objServiceTimelinesBLL.GetGetUserRoleDetail(objServiceTimelinesBEL);
            //DataTable dt = ds.Tables[0];


            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    try
            //    {
            //        TextBox txtTotalAreaNew = (TextBox)e.Row.FindControl("txtTotalAreaNew");
            //        TextBox txtGSLandNew = (TextBox)e.Row.FindControl("txtGSLandNew");
            //        TextBox txtGovtLandNew = (TextBox)e.Row.FindControl("txtGovtLandNew");
            //        TextBox txtPrivateacquisitionLandNew = (TextBox)e.Row.FindControl("txtPrivateacquisitionLandNew");
            //        TextBox txtNotificationDateNew = (TextBox)e.Row.FindControl("txtNotificationDateNew");
            //        TextBox txtAwardAreaNew = (TextBox)e.Row.FindControl("txtAwardAreaNew");
            //        TextBox txtAwardDateNew = (TextBox)e.Row.FindControl("txtAwardDateNew");
            //        TextBox txtPossessionArea = (TextBox)e.Row.FindControl("txtPossessionAreaNew");
            //        TextBox txtPossessionDate = (TextBox)e.Row.FindControl("txtPossessionDateNew");
            //        DropDownList ddlIANameNew = (DropDownList)e.Row.FindControl("ddlIANameNew");
            //        LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnkAdd");
            //        string Level = dt.Rows[0]["Level"].ToString().Trim();
            //        if (Level == "RM")
            //        {
            //            ddlIANameNew.Enabled = true;
            //            txtTotalAreaNew.Enabled = true;
            //            txtGSLandNew.Enabled = true;
            //            txtGovtLandNew.Enabled = true;
            //            txtPrivateacquisitionLandNew.Enabled = true;
            //            txtNotificationDateNew.Enabled = true;
            //            txtAwardAreaNew.Enabled = true;
            //            txtAwardDateNew.Enabled = true;
            //            txtPossessionArea.Enabled = true;
            //            txtPossessionDate.Enabled = true;
            //            lnkBtn.Visible = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("Oops! error occured :" + ex.Message.ToString());
            //    }
            //    finally
            //    {
            //    }

            //}

        }
    }
}