using System;
using System.Data;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{
    public partial class LandAssessmentViewHO : System.Web.UI.Page
    {
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            UserName = _objLoginInfo.userName;
            if (!IsPostBack)
            {
                bindgrid();

            }
        }
        public void bindgrid()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.UserName = UserName.Trim();
                ds = objServiceTimelinesBLL.GetgridLAD(objServiceTimelinesBEL);
              
                if (ds != null)
                {
                    gridLAD.DataSource = ds;
                    gridLAD.DataBind();
                }
                else
                {
                    gridLAD.DataSource = null;
                    gridLAD.DataBind();
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

        protected void gridLAD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridLAD.PageIndex = e.NewPageIndex;
                bindgrid();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.UserName  = UserName.Trim();
                objServiceTimelinesBEL.searchText = txtSearch.Text.Trim();
                ds = objServiceTimelinesBLL.GetgridforLAD(objServiceTimelinesBEL);
                if (ds != null)
                {
                    gridLAD.DataSource = ds;
                    gridLAD.DataBind();
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

        protected void gridLAD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % gridLAD.PageSize;
                string ID  = gridLAD.DataKeys[index].Values[0].ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange('" + ID.Trim() + "');", true);

            }

            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % gridLAD.PageSize;
                string ID = gridLAD.DataKeys[index].Values[0].ToString();
                BindStatus(ID);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange2('" + ID.Trim() + "');", true);

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtRemarks.Text.Length<=0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChangeAlert('" + change_text.Text.Trim() + "','Please Enter Remarks');", true);
                    return;
                }


                belBookDetails objServiceTimelinesBEL   = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                int retVal = 0;
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.AlloteeId  = change_text.Text.Trim();
                objServiceTimelinesBEL.StatusID   = drpStatusType.SelectedValue.Trim();
                objServiceTimelinesBEL.StatusName = drpStatusType.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Remarks    = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.UserName   = UserName.Trim();
               
                retVal = objServiceTimelinesBLL.UpdateLAStatus(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    MessageBox1.ShowSuccess("Status Update Succesfully");
                    change_text.Text = "";
                    bindgrid();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindStatus(string ID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridStatus(ID);
                if (ds != null)
                {
                    AllGrid.DataSource = ds;
                    AllGrid.DataBind();
                }
                else
                {
                    AllGrid.DataSource = null;
                    AllGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
        }
    }
}