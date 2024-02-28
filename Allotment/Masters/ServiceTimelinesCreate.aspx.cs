using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using QueryStringEncryption;

namespace Allotment.Masters
{
    public partial class ServiceTimelinesCreate : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ClearAll();
                BindCategory();
                BindServiceTimelinesGridView();
            }
        }

        #region "Bind ServiceTimelines Records in GridView"
        private void BindServiceTimelinesGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceTimelinesRecords();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
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
        #endregion
        #region "Save Service Timeline Record"
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.ServiceTimeLinesDepartMent = drplanduse.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesActivity = txtActivity.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLines = txtTimelines.Text.Trim();
            objServiceTimelinesBEL.ServiceTimeLinesApprovingLevel = txtApprover.Text.Trim();
            objServiceTimelinesBEL.CreatedBy = "System";
            objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
            objServiceTimelinesBEL.ModifiedBy = "System";
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(lblServiceID.Text.Trim());


            try
            {
                if (btnSubmit.Text == "Save")
                {
                    int retVal = objServiceTimelinesBLL.SaveServiceTimelinesDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        lblStatus.Text = "Service Timelines detail saved successfully";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        ClearAll();
                        BindServiceTimelinesGridView();
                        BindCategory();
                    }
                    else
                    {
                        lblStatus.Text = "Service Timelines details couldn't be saved";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }

                if (btnSubmit.Text == "Update")
                {
                    int retVal = objServiceTimelinesBLL.UpdateServiceTimelinesDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        lblStatus.Text = "Service Timelines detail Updated successfully";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        ClearAll();
                        BindServiceTimelinesGridView();
                        BindCategory();
                    }
                    else
                    {
                        lblStatus.Text = "Service Timelines details couldn't be Updated";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
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
        #endregion
        #region "Common Operations"
        public void ClearAll()
        {
            txtActivity.Text = string.Empty;
            txtTimelines.Text = string.Empty;
            txtApprover.Text = string.Empty;
            lblStatus.Text = string.Empty;
            drplanduse.Items.Clear();
            pnlCheckList.Enabled = false;
            btnSubmit.Text = "Save";
            lblServiceID.Text = "0";
            lnkChecklist.Visible = false;
        }
        public void BindCategory()
        {
            drplanduse.Items.Clear();
            drplanduse.Items.Add("---Select Category---");
            drplanduse.Items.Add("Industrial");
            drplanduse.Items.Add("Institutional");
            drplanduse.Items.Add("Commercial");
            drplanduse.Items.Add("Residential");
            drplanduse.Items.Add("Group Housing");
            drplanduse.Items.Add("Builders");
        }

        #endregion
        #region GridView2 (BoundFields with Paging and Sorting)
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindServiceTimelinesGridView();
            BindCategory();
        }
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression.Trim() == this.SortField)
                this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
            else
                this.SortDirection = "A";

            this.SortField = e.SortExpression;
            BindServiceTimelinesGridView();
            BindCategory();
        }
        #endregion  
        #region Properties for Sorting and DataTable
        string SortField
        {
            get
            {
                object o = ViewState["SortField"];
                if (o == null)
                    return String.Empty;
                else
                    return (string)o;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        string SortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                    return String.Empty;
                else
                    return (string)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        public DataTable Temp
        {
            get
            {
                object o = ViewState["Temp"];
                if (o == null)
                {
                    DataTable dt = new DataTable();
                    return dt;
                }
                else
                    return (DataTable)o;
            }
            set
            {
                ViewState["Temp"] = value;
            }
        }
        #endregion
        #region "GridView Operations"
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            var a = GridView2.SelectedRow.Cells[1].Text;
            var b = GridView2.SelectedRow.Cells[2].Text;

            //drplanduse.SelectedItem.Text = row.Cells[1].Text;
            //txtActivity.Text = row.Cells[0].Text;
            //txtTimelines.Text = row.Cells[2].Text;
            //txtApprover.Text = row.Cells[3].Text;
            ////txtApprover.Text = (row.FindControl("lblCountry") as Label).Text;
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ServiceTimeLinesID"));
                if (CategoryID == 2)
                    // color the background of the row yellow
                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {

                //  pnlChecklist.Enabled = true;
                GridViewRow row = GridView2.SelectedRow;
                //  int index = e.Row.RowIndex;

                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                var a = GridView2.Rows[index].Cells[0].Text;
                var b = GridView2.Rows[index].Cells[1].Text;
                drplanduse.SelectedIndex = drplanduse.Items.IndexOf(drplanduse.Items.FindByText(b));
                txtActivity.Text = GridView2.Rows[index].Cells[2].Text;
                txtTimelines.Text = GridView2.Rows[index].Cells[3].Text;
                txtApprover.Text = GridView2.Rows[index].Cells[4].Text;
                lblServiceID.Text = a;
                pnlCheckList.Enabled = true;
                lnkChecklist.Visible = true;
                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "DeleteRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView2.PageSize;
                int Service_Id = Convert.ToInt32(GridView2.Rows[index].Cells[0].Text);
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_Id;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteServiceRecord(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {
                        lblStatus.Text = "ServiceTimelines deleted successfully";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        ClearAll();
                        BindServiceTimelinesGridView();
                        BindCategory();
                    }
                    else
                    {
                        lblStatus.Text = "ServiceTimelines couldn't be deleted";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
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

        }

        #endregion
        #region "Delete Service Record"
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Service_Id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            objServiceTimelinesBEL.ServiceTimeLinesID = Service_Id;
            try
            {
                int retVal = objServiceTimelinesBLL.DeleteServiceRecord(objServiceTimelinesBEL);

                if (retVal > 0)
                {
                    lblStatus.Text = "ServiceTimelines deleted successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    ClearAll();
                    BindServiceTimelinesGridView();
                }
                else
                {
                    lblStatus.Text = "ServiceTimelines couldn't be deleted";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
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
        #endregion



        protected void lnkChecklist_Click(object sender, EventArgs e)
        {

            string strLandUse = drplanduse.SelectedItem.Text.Trim();
            string strActivity = txtActivity.Text.Trim();
            string strTimeLines = txtTimelines.Text.Trim();
            string strApprover = txtApprover.Text.Trim();
            string strid = lblServiceID.Text.Trim();

            string strURL = "../Masters/CreateServiceChecklist.aspx?";
            if (HttpContext.Current != null)
            {
                string strURLWithData = strURL + EncryptQueryString(string.Format("id={0}&landuse={1}&activity={2}&timeline={3}&approver={4}", strid, strLandUse, strActivity, strTimeLines, strApprover));
                HttpContext.Current.Response.Redirect(strURLWithData);
            }
            else
            { }


            Response.Redirect("../Masters/CreateServiceChecklist.aspx?id=" + lblServiceID.Text);
        }
        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }



    }
}