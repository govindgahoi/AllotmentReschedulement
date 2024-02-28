using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class NewUserCreation : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string JoiningDate1 = "";
        string RetirementDate1 = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgridforUsercreation();
                bindDesignation();
            }
        }
        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            clear();
        }

        private void bindDesignation()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                if (ds != null)
                {
                    ds = objServiceTimelinesBLL.GetDesignationDetails();
                    ddlDesignation.DataSource = ds;
                    ddlDesignation.DataTextField = "Designation";
                    ddlDesignation.DataValueField = "DesignationID";
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, new ListItem("--Select--", "0"));
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

        private void bindgridforUsercreation()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridforUsercreation();
                if (ds != null)
                {
                    gridUsercreationdetails.DataSource = ds;
                    gridUsercreationdetails.DataBind();
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    objServiceTimelinesBEL.Designation = Int32.Parse(ddlDesignation.SelectedValue.Trim());
                    objServiceTimelinesBEL.username = txtusername.Text.Trim();
                    objServiceTimelinesBEL.Qualification = txtQualification.Text.Trim();
                    objServiceTimelinesBEL.phoneNo = txtphoneNo.Text.Trim();
                    objServiceTimelinesBEL.Password = txtPassword.Text.Trim();
                    JoiningDate1 = DateTime.ParseExact(txtJoiningDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.JoiningDate = Convert.ToDateTime(JoiningDate1);
                    RetirementDate1 = DateTime.ParseExact(txtRetirementDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.RetirementDate = Convert.ToDateTime(RetirementDate1);
                    objServiceTimelinesBEL.Employee = txtEmployee.Text.Trim();
                    objServiceTimelinesBEL.Empcode = Int32.Parse(txtEmpcode.Text.Trim());
                    objServiceTimelinesBEL.Email = txtEmail.Text.Trim();
                    objServiceTimelinesBEL.ContractType = txtContractType.Text.Trim();


                    DataSet result = objServiceTimelinesBLL.InsertUserDetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        bindgridforUsercreation();
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(ViewState["id"].ToString());
                    objServiceTimelinesBEL.UserID = ID;
                    objServiceTimelinesBEL.Designation = Int32.Parse(ddlDesignation.SelectedValue.Trim());
                    objServiceTimelinesBEL.username = txtusername.Text.Trim();
                    objServiceTimelinesBEL.Qualification = txtQualification.Text.Trim();
                    objServiceTimelinesBEL.phoneNo = txtphoneNo.Text.Trim();
                    objServiceTimelinesBEL.Password = txtPassword.Text.Trim();
                    JoiningDate1 = DateTime.ParseExact(txtJoiningDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.JoiningDate = Convert.ToDateTime(JoiningDate1);
                    RetirementDate1 = DateTime.ParseExact(txtRetirementDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.RetirementDate = Convert.ToDateTime(RetirementDate1);
                    objServiceTimelinesBEL.Employee = txtEmployee.Text.Trim();
                    objServiceTimelinesBEL.Empcode = Int32.Parse(txtEmpcode.Text.Trim());
                    objServiceTimelinesBEL.Email = txtEmail.Text.Trim();
                    objServiceTimelinesBEL.ContractType = txtContractType.Text.Trim();


                    DataSet result = objServiceTimelinesBLL.UpdateUserDetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {
                        MessageBox1.ShowSuccess(result.Tables[0].Rows[0][0].ToString());
                        clear();
                        bindgridforUsercreation();
                    }
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
        public void clear()
        {
            try
            {
                ddlDesignation.SelectedValue = "0";
                txtusername.Text = string.Empty;
                txtQualification.Text = string.Empty;
                txtphoneNo.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtJoiningDate.Text = string.Empty;
                txtRetirementDate.Text = string.Empty;
                txtEmployee.Text = string.Empty;
                txtEmpcode.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtContractType.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }


        private void get_Userdetals(string id)
        {
            DataSet ds = new DataSet();
            ds = objServiceTimelinesBLL.GetUserDetails(id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtusername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["DesignationID"].ToString();
                    txtQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
                    txtEmpcode.Text = ds.Tables[0].Rows[0]["Empcode"].ToString();
                    txtContractType.Text = ds.Tables[0].Rows[0]["ContractType"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["emailID"].ToString();
                    txtphoneNo.Text = ds.Tables[0].Rows[0]["phoneNo"].ToString();
                    txtEmployee.Text = ds.Tables[0].Rows[0]["EMPLOYEENAME"].ToString();
                    string JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    string RetirementDate = ds.Tables[0].Rows[0]["RetirementDate"].ToString();
                    txtJoiningDate.Text = JoiningDate;
                    txtRetirementDate.Text = RetirementDate;
                    btnSubmit.Text = "Update";
                    bindgridforUsercreation();
                }
                else
                {
                    clear();
                    btnSubmit.Text = "Submit";
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

        private void Delete_Userdetals(string id)
        {
            try
            {
                int result = objServiceTimelinesBLL.Delete_Userdetals(id);
                if (result > 0)
                {
                    MessageBox1.ShowSuccess("User Delete successfully");
                    Response.Redirect("/NewUserCreation.aspx");
                }
                else
                {
                    MessageBox1.ShowError("Some Error Occured");
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
        protected void gridUsercreationdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Process")
                {

                    string rowid = e.CommandArgument.ToString();
                    ViewState["id"] = rowid;
                    get_Userdetals(rowid);
                    passworddiv.Visible = false;
                    btnSubmit.Text = "Update";

                }
                if (e.CommandName == "Delete")
                {
                    string rowid = e.CommandArgument.ToString();
                    Delete_Userdetals(rowid);
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

        protected void gridUsercreationdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridUsercreationdetails.PageIndex = e.NewPageIndex;
                gridFunc();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        public void gridFunc()
        {
            try
            {
                bindgridforUsercreation();
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
                ds = objServiceTimelinesBLL.GetgridforSearchUsercreation(txtSearch.Text);
                if (ds != null)
                {
                    gridUsercreationdetails.DataSource = ds;
                    gridUsercreationdetails.DataBind();
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

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            clear();
        }
    }
}