using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Sanctionedestimate : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion
        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                // objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            if (!IsPostBack)
            {
                ViewState["Filter"] = "ALL";
                GetEngineeringDetail();
                UserSpecificBinding();
            }
        }
        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            //checkuser();
            GetEngineeringDetail();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetEngineeringDetail();
        }
        #region Bind DropDown
        protected void UserSpecificBinding()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetConstructionDivisionsRecords(objServiceTimelinesBEL);
                ddlCD.DataSource = dsR;
                ddlCD.DataTextField = "CDName";
                ddlCD.DataValueField = "Id";
                ddlCD.DataBind();
                ddlCD.Items.Insert(0, new ListItem("-ALL-", "0"));
                Regional_Changed(null, null);
                // ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            // drpdwnIA.Items.Insert(0, new ListItem("--ALL--", "0"));
            bindDDLRegion(ddlCD.SelectedItem.Value, null);
            //if( ddlCD.SelectedValue.ToString().Trim() == "0" || ddlCD.SelectedValue.ToString().Trim() == "")
            // {
            //     GridView1.Columns[1].Visible = true;
            //     GridView1.Columns[2].Visible = true;
            // }
            // else
            // {
            //     GridView1.Columns[1].Visible = false;
            // }
            Refesh(true);
        }
        public void Refesh(bool pIsOfficeCalled)
        {
            if (!pIsOfficeCalled)
                //ddloffice.SelectedIndex = 0;
                drpdwnIA.SelectedIndex = 0;
            //  txtplotNo.Text = "";
        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaCDDetail(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--ALL--", "0"));
                if (pIAName != null)
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                GetEngineeringDetail();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Filter"] = drpdwnIA.SelectedItem.Text;
            GetEngineeringDetail();
        }
        #endregion
        public void GetEngineeringDetail()
        {
            try
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.SearchRecord = txtSearch.Text;
                if (ddlCD.SelectedValue.ToString().Trim() == "0" || ddlCD.SelectedValue.ToString().Trim() == "")
                {
                    objServiceTimelinesBEL.ConstructionName = null;
                    objServiceTimelinesBEL.IAName = null;
                }
                else
                {
                    if (drpdwnIA.SelectedValue.ToString().Trim() == "0")
                    {
                        objServiceTimelinesBEL.ConstructionName = ddlCD.SelectedItem.Text.Trim();
                        objServiceTimelinesBEL.IAName = null;

                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructionName = ddlCD.SelectedItem.Text.Trim();
                        objServiceTimelinesBEL.IAName = drpdwnIA.SelectedItem.Text.Trim();
                    }

                }

                ds = objServiceTimelinesBLL.GetEngineeringDetail(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    //DataTable firstTable = ds.Tables[0];
                    //ViewState["CurrentTable"] = firstTable;
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteEngineeringDetail")
            {

                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int ID = Convert.ToInt32(GridView1.DataKeys[index].Values[0]);
                    objServiceTimelinesBEL.ID = ID;
                    int retVal = objServiceTimelinesBLL.DeleteEngineeringDetail(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        MessageBox1.ShowSuccess("Delete Record Successfully");
                        GetEngineeringDetail();
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
            if (e.CommandName == "ADD")
            {

                try
                {
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    //index = index % GridView1.PageSize;
                    objServiceTimelinesBEL.IAId = Convert.ToInt32((GridView1.Rows[index].FindControl("lblId") as Label).Text);
                    objServiceTimelinesBEL.ConstructionName = ((GridView1.Rows[index].FindControl("lblCDName") as Label).Text);
                    //objServiceTimelinesBEL.Nameofwork = ((GridView1.Rows[index].FindControl("lblNameofwork") as Label).Text);
                    //objServiceTimelinesBEL.JobNo = ((GridView1.Rows[index].FindControl("lblJobNo") as Label).Text);
                    //objServiceTimelinesBEL.Amount = Convert.ToDecimal(((GridView1.Rows[index].FindControl("lblAmount") as Label).Text));
                    int retVal = objServiceTimelinesBLL.InsertEngineeringDetail(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        MessageBox1.ShowSuccess("Add Row Successfully");
                        GetEngineeringDetail();
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
            int i = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    i++;
                    string s = cell.Text;
                    if (cell.Text.Length > 25 && (i == 15))
                        cell.Text = cell.Text.Substring(0, 25) + "....";
                    cell.ToolTip = s;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {

                    e.Row.Cells[1].Attributes.Add("style", "width: 150px !important; ");
                    e.Row.Cells[2].CssClass = "Wrap";
                    e.Row.Cells[2].Attributes.Add("style", "width: 150px !important; ");
                    e.Row.Cells[3].CssClass = "Wrap";
                    e.Row.Cells[3].Attributes.Add("style", "width: 200px !important; ");
                    e.Row.Cells[5].CssClass = "Wrap";
                    e.Row.Cells[5].Attributes.Add("style", "width: 100px !important; ");
                    e.Row.Cells[6].CssClass = "Wrap";
                    e.Row.Cells[6].Attributes.Add("style", "width: 150px !important; ");
                    e.Row.Cells[7].CssClass = "Wrap";
                    e.Row.Cells[7].Attributes.Add("style", "width: 150px !important; ");
                    e.Row.Cells[11].CssClass = "Wrap";
                    e.Row.Cells[11].Attributes.Add("style", "width: 150px !important; ");
                    e.Row.Cells[13].CssClass = "Wrap";
                    e.Row.Cells[13].Attributes.Add("style", "width: 150px !important; ");
                }
                catch { }
                try
                {
                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                    lblUserId.Text = _objLoginInfo.userName;
                    DataSet ds = new DataSet();

                    ds = objServiceTimelinesBLL.GetIndustrialAreaEngineeringDetail(objServiceTimelinesBEL);
                    DataTable dt = ds.Tables[0];
                    //   string[] arrvalues = HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text).Split(',');
                    foreach (DataRow dr in dt.Rows)
                    {
                        string aks = dr["CDName"].ToString();
                        Label lblIAName = (Label)e.Row.FindControl("lblCDName");
                        if (lblIAName.Text.Trim() == aks.Trim())
                        {
                            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                            LinkButton lnkAdd = (LinkButton)e.Row.FindControl("lnkAdd");
                            LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                            lnkAdd.Visible = true;
                            lnkEdit.Visible = true;
                            //btnDelete.Visible = true;

                        }

                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                    }
                    //if (Group_lbl.Text == "Engineer")
                    //{
                    //    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    //    LinkButton lnkAdd = (LinkButton)e.Row.FindControl("lnkAdd");
                    //    LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                    //    lnkAdd.Visible = true;
                    //    lnkEdit.Visible = true;
                    //    btnDelete.Visible = true;
                    //}
                }
                catch (Exception ex)
                {

                }
                finally
                {
                }
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    DataRowView drv = (DataRowView)e.Row.DataItem;
            //    string status = drv["Id"].ToString();
            //    string Nameofwork= drv["Nameofwork"].ToString();
            //    string JobNo = drv["JobNo"].ToString();
            //    string Amount = drv["Amount"].ToString();
            //    if (Group_lbl.Text == "Engineer")
            //    {
            //        e.Row.Cells[7].Attributes.Add("onclick", "ShowPopup('" + status + "," + Nameofwork + "," + JobNo + "," + Amount + "'); return false;");
            //        e.Row.Cells[7].Attributes.Add("style", "background: antiquewhite !important;width: 100px !important; ");
            //    }
            //}
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            GetEngineeringDetail();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            GetEngineeringDetail();
        }
        //protected void GridView1_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        //{
        //    int i = e.NewSelectedIndex;
        //    GridViewRow gr = GridView1.Rows[i];
        //    GridViewRow row = new GridViewRow(i, i, DataControlRowType.DataRow, DataControlRowState.Insert);
        //    GridView1.Controls[0].Controls.AddAt(i + 2, row);
        //}
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //this code will Cancel the row edit  
            GridView1.EditIndex = -1;

            //Loading the Gridview again  
            GetEngineeringDetail();
        }

        protected void btnInsertAction_Click(object sender, EventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;

            //string Name = (row.FindControl("lblIAName") as Label).Text;

            //string Name = (grdSelRow.FindControl("lblIAName") as Label).Text;
            // string rowid= RowID.Value.Trim();
            // string Nameofwork = RowNameofwork.Value.Trim();
            // string JobNo = RowJobNo.Value.Trim();
            // string Amount = RowAmount.Value.Trim();
            // objServiceTimelinesBEL.CBNO = txtCBNO.Text.Trim();
            // objServiceTimelinesBEL.ExAmount = Convert.ToDecimal(txtTenderAmount.Text.Trim());
            //objServiceTimelinesBEL.AgencyName = txtNameofAgency.Text.Trim();
            //objServiceTimelinesBEL.CBNO = txtGrossWork.Text.Trim();
            //objServiceTimelinesBEL.Payment = Convert.ToDecimal(txtPayment1.Text.Trim());
            //objServiceTimelinesBEL.PaymentDate = DateTime.Parse(txtPaymentDate1.Text.Trim());
            //objServiceTimelinesBEL.AreaDeveloped = Convert.ToDecimal(txtAreaDeveloped1.Text.Trim());
            // objServiceTimelinesBEL.CBNO = txtRemark.Text.Trim();
            //Label lblIAID = (Label)grdSelRow.FindControl("lblId");
            //TextBox txtNameofwork = (TextBox)grdSelRow.FindControl("txtNameofworko");
            //TextBox txtJobNo = (TextBox)grdSelRow.FindControl("txtJobNo");
            //TextBox txtDate = (TextBox)grdSelRow.FindControl("txtDate");
            //TextBox txtAmount = (TextBox)grdSelRow.FindControl("txtAmount");


        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //retrieving the DataKey name here  
                string aks = GridView1.DataKeys[e.RowIndex].Value.ToString();
                if (aks == "")
                {
                    objServiceTimelinesBEL.ID = 0;
                }
                else
                {
                    objServiceTimelinesBEL.ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                }

                if ((GridView1.Rows[e.RowIndex].FindControl("txtNameofworko") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtNameofworko") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Name Of Work");
                    return;
                }
                else

                if ((GridView1.Rows[e.RowIndex].FindControl("txtJobNo") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtJobNo") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Job Number");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAmount") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtAmount") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Amount");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtCBNO") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtCBNO") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide CB Number");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtExAmount") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtExAmount") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Tender Amount");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAgencyName") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtAgencyName") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Name of Agency");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtGrossworkvalue") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtGrossworkvalue") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Gross Value of Work");
                    return;
                }
                else
                if ((GridView1.Rows[e.RowIndex].FindControl("txtFinancialyear") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtFinancialyear") as TextBox).Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Financial Year");
                    return;
                }
                //else
                //if ((GridView1.Rows[e.RowIndex].FindControl("txtPaymentDate") as TextBox).Text == "" || (GridView1.Rows[e.RowIndex].FindControl("txtPaymentDate") as TextBox).Text == null)
                //{
                //    MessageBox1.ShowWarning("Please Provide Date Of Payment");
                //    return;
                //}
                if ((GridView1.Rows[e.RowIndex].FindControl("ddlStatusofWork") as DropDownList).SelectedIndex == 0)
                {
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Select Industrial Area First');", true);
                    MessageBox1.ShowInfo("Select Status of Work");
                    return;
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("ddlStatusofWork1") as DropDownList).SelectedIndex == 0)
                {
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Select Industrial Area First');", true);
                    MessageBox1.ShowInfo("Select Status of Work");
                    return;
                }
                //ddlArea.SelectedItem.Text.Trim()
                objServiceTimelinesBEL.IAId = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("lblId") as Label).Text);
                //if ((GridView1.Rows[e.RowIndex].FindControl("lblCDName") as Label).Text.Length > 0)
                //{
                //    objServiceTimelinesBEL.ConstructionName = ((GridView1.Rows[e.RowIndex].FindControl("lblCDName") as Label).Text);
                //}
                objServiceTimelinesBEL.IndustrialArea = (GridView1.Rows[e.RowIndex].FindControl("lblIAName") as Label).Text;
                //objServiceTimelinesBEL.ConstructionName = (GridView1.Rows[e.RowIndex].FindControl("lblCDName") as Label).Text;
                if ((GridView1.Rows[e.RowIndex].FindControl("txtNameofworko") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.Nameofwork = (GridView1.Rows[e.RowIndex].FindControl("txtNameofworko") as TextBox).Text.Trim();
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtJobNo") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.JobNo = ((GridView1.Rows[e.RowIndex].FindControl("txtJobNo") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAmount") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.Amount = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtAmount") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtFinancialyear") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.Financialyear = ((GridView1.Rows[e.RowIndex].FindControl("txtFinancialyear") as TextBox).Text.Trim());
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtCBNO") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.CBNO = ((GridView1.Rows[e.RowIndex].FindControl("txtCBNO") as TextBox).Text);
                }
                //if ((GridView1.Rows[e.RowIndex].FindControl("txtExDate") as TextBox).Text.Length > 0)
                //{
                //    objServiceTimelinesBEL.ExDate = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("txtExDate") as TextBox).Text);
                //}
                if ((GridView1.Rows[e.RowIndex].FindControl("txtExAmount") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.ExAmount = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtExAmount") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAgencyName") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.AgencyName = ((GridView1.Rows[e.RowIndex].FindControl("txtAgencyName") as TextBox).Text);
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtGrossworkvalue") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.GrossWork = (GridView1.Rows[e.RowIndex].FindControl("txtGrossworkvalue") as TextBox).Text.Trim();
                }
                objServiceTimelinesBEL.Statusofwork = (GridView1.Rows[e.RowIndex].FindControl("ddlStatusofWork") as DropDownList).Text.Trim();
                objServiceTimelinesBEL.Statusofwork1 = (GridView1.Rows[e.RowIndex].FindControl("ddlStatusofWork1") as DropDownList).Text.Trim();
                //if ((GridView1.Rows[e.RowIndex].FindControl("txtPayment") as TextBox).Text.Length > 0)
                //{
                //    objServiceTimelinesBEL.Payment = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtPayment") as TextBox).Text.Trim());
                //}
                //if ((GridView1.Rows[e.RowIndex].FindControl("txtPaymentDate") as TextBox).Text.Length > 0)
                //{
                //    objServiceTimelinesBEL.PaymentDate = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("txtPaymentDate") as TextBox).Text.Trim());
                //}
                if ((GridView1.Rows[e.RowIndex].FindControl("txtAreaDeveloped") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.AreaDeveloped = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtAreaDeveloped") as TextBox).Text.Trim());
                }
                if ((GridView1.Rows[e.RowIndex].FindControl("txtRemark") as TextBox).Text.Length > 0)
                {
                    objServiceTimelinesBEL.Remark = (GridView1.Rows[e.RowIndex].FindControl("txtRemark") as TextBox).Text.Trim();
                }
                objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);

                int retVal = objServiceTimelinesBLL.UpdateEngineeringDetail(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    MessageBox1.ShowSuccess("Record Update Successfully");
                    GridView1.EditIndex = -1;// no row in edit mode
                    GetEngineeringDetail();


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
            try
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
                        //row.Cells[1].RowSpan = row.Cells[2].RowSpan;
                        //previousRow.Cells[1].Visible = false;
                    }
                    if (row.Cells[2].Text == previousRow.Cells[2].Text)
                    {
                        row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                        previousRow.Cells[2].Visible = false;
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
            catch (Exception ex)
            {
                //Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        protected void GridView1_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.ColumnSpan = 11;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Status Of Work";
                cell.CssClass = "text-center-imp";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.ColumnSpan = 5;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "";
                row.Cells.Add(cell);
                GridView1.Controls[0].Controls.AddAt(0, row);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                    lblUserId.Text = _objLoginInfo.userName;
                    DataSet ds = new DataSet();

                    ds = objServiceTimelinesBLL.GetIndustrialAreaEngineeringDetail(objServiceTimelinesBEL);
                    DataTable dt = ds.Tables[0];
                    //   string[] arrvalues = HttpContext.Current.Server.HtmlDecode(e.Row.Cells[2].Text).Split(',');
                    foreach (DataRow dr in dt.Rows)
                    {

                        string aks = dr["Id"].ToString();
                        DataRow row = ((DataRowView)e.Row.DataItem).Row;

                        Label Mylabel = (Label)e.Row.FindControl("lblId");
                        DropDownList drpdwnIA = (DropDownList)e.Row.FindControl("drpdwnIA");
                        //if (drpdwnIA.SelectedItem.Value == "0")
                        //{
                        //    e.row.Cells[1].Visible = false;
                        //}

                        //Label lblIAName = (Label)e.Row.FindControl("lblId");
                        if (Mylabel.Text.Trim() == aks.Trim())
                        {
                            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                            LinkButton lnkAdd = (LinkButton)e.Row.FindControl("lnkAdd");
                            LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                            lnkAdd.Visible = true;
                            lnkEdit.Visible = true;
                            btnDelete.Visible = true;

                        }

                    }

                    //if (Group_lbl.Text == "Engineer")
                    //{
                    //    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    //    LinkButton lnkAdd = (LinkButton)e.Row.FindControl("lnkAdd");
                    //    LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                    //    lnkAdd.Visible = true;                         
                    //    lnkEdit.Visible = true;
                    //    btnDelete.Visible = true;
                    //}
                }
                catch (Exception ex)
                {

                }
                finally
                {
                }
            }

        }
    }
}
