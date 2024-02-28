using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class ServiceApplicableChargeMaster : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";



        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();
                bindServiceDropdown();
                bindPaymentCategoryDropdown();
                bindApplicableChargeForGrid(UserName);
            }
        }
        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                IaDdl.DataSource = ds;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
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
        private void bindServiceDropdown()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllServicesForDropdown", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ServiceDropDown.DataSource = dt;
                ServiceDropDown.DataTextField = "ServiceDescription";
                ServiceDropDown.DataValueField = "ID";
                ServiceDropDown.DataBind();
                ServiceDropDown.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindPaymentCategoryDropdown()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllPaymentCategoryForDropdown", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                PaymentCategoryDropDown.DataSource = dt;
                PaymentCategoryDropDown.DataTextField = "Description";
                PaymentCategoryDropDown.DataValueField = "ID";
                PaymentCategoryDropDown.DataBind();
                PaymentCategoryDropDown.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bindApplicableChargeForGrid(String UserName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllApplicableChargesForGrid1 '" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                IARateGrid.DataSource = dt;
                IARateGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindApplicableChargeForGridIAWise(String IAId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllApplicableChargesForGridIAWise " + IAId + ",'" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                IARateGrid.DataSource = dt;
                IARateGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindApplicableChargeForGridServiceWise(String ServiceId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllApplicableChargesForGridServiceWise '" + UserName + "'," + IaDdl.SelectedValue.Trim() + "," + ServiceId + ",'" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                IARateGrid.DataSource = dt;
                IARateGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindApplicableChargeForGridAfterSave()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllApplicableChargesForGridAftersave '" + UserName + "'," + IaDdl.SelectedValue.Trim() + "," + ServiceDropDown.SelectedValue.Trim() + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                IARateGrid.DataSource = dt;
                IARateGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            IaDdl.SelectedIndex = 0;
            ServiceDropDown.SelectedIndex = 0;
            PaymentCategoryDropDown.SelectedIndex = 0;
            txtApplicableCharge.Text = "";
            txtEffectiveFromDate.Text = "";
            txtSearch.Text = "";
            bindApplicableChargeForGrid(UserName);


        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
        }



        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (IaDdl.SelectedIndex == 0)
                {
                    MessageBox1.ShowError("Please Select Industrial Area");
                    return;
                }
                if (ServiceDropDown.SelectedIndex == 0)
                {
                    MessageBox1.ShowError("Please Select Service");
                    return;
                }
                if (PaymentCategoryDropDown.SelectedIndex == 0)
                {
                    MessageBox1.ShowError("Please Select Payment Category");
                    return;
                }
                if (txtApplicableCharge.Text == "")
                {
                    MessageBox1.ShowError("Applicable Charge Is Required Field");
                    return;
                }
                if (txtEffectiveFromDate.Text == "")
                {
                    MessageBox1.ShowError("Effective From Date Is Required Field");
                    return;
                }

                command = new SqlCommand(@"[SP_InsertApplicableCharges]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IAId", IaDdl.SelectedValue.Trim());
                command.Parameters.AddWithValue("@ServiceID", ServiceDropDown.SelectedValue.Trim());
                command.Parameters.AddWithValue("@PaymentID", PaymentCategoryDropDown.SelectedValue.Trim());
                command.Parameters.AddWithValue("@ApplicableCharge", Convert.ToDecimal(txtApplicableCharge.Text.Trim()));
                command.Parameters.AddWithValue("@CreatedBy", UserName.Trim());
                command.Parameters.AddWithValue("@FromDate", txtEffectiveFromDate.Text.Trim());



                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Applicable Charges Inserted/Updated successfully");
                    reset();
                    bindApplicableChargeForGridAfterSave();


                }
                else
                {

                    transaction.Rollback();
                    MessageBox1.ShowError("Some Error Occured");
                    return;


                }

            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }
        }

        private void reset()
        {
            PaymentCategoryDropDown.SelectedIndex = 0;
            txtApplicableCharge.Text = "";
            txtSearch.Text = "";
            txtEffectiveFromDate.Text = "";




        }

        protected void IARateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                index = index % IARateGrid.PageSize;

                int id = Convert.ToInt32(IARateGrid.DataKeys[index].Values[0]);
                SqlCommand cmd = new SqlCommand("Sp_GetApplicableChargesById " + id + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    IaDdl.SelectedValue = dt.Rows[0]["IAId"].ToString();
                    ServiceDropDown.SelectedValue = dt.Rows[0]["ServiceId"].ToString();
                    PaymentCategoryDropDown.SelectedValue = dt.Rows[0]["PaymentId"].ToString();
                    txtApplicableCharge.Text = dt.Rows[0]["ApplicableCharge"].ToString();

                    txtEffectiveFromDate.Text = dt.Rows[0]["EffectiveFromDate"].ToString();


                }


            }
            if (e.CommandName == "DeleteCharge")
            {




                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    index = index % IARateGrid.PageSize;

                    int id = Convert.ToInt32(IARateGrid.DataKeys[index].Values[0]);

                    command = new SqlCommand(@"[SP_DeleteApplicableCharges]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);




                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("Applicable Charges Deleted successfully");
                        if (IaDdl.SelectedIndex > 0)
                        {
                            if (ServiceDropDown.SelectedIndex > 0)
                            {
                                bindApplicableChargeForGridServiceWise(ServiceDropDown.SelectedValue.Trim());
                            }
                            else
                            {
                                bindApplicableChargeForGridIAWise(IaDdl.SelectedValue.Trim());
                            }
                        }
                        else
                        {
                            bindApplicableChargeForGrid(UserName);
                        }

                    }
                    else
                    {

                        transaction.Rollback();
                        MessageBox1.ShowError("Some Error Occured");
                        return;


                    }

                }
                catch (Exception ex)
                {

                    error += "Commit Exception Type: " + ex.GetType();
                    error += "  Message: " + ex.Message;
                    Response.Write(error);

                    try
                    { transaction.Rollback(); }

                    catch (Exception ex2)
                    {
                        error += "Rollback Exception Type:" + ex2.GetType();
                        error += " Message: " + ex2.Message;
                        Response.Write(error);
                    }

                }

                finally
                {
                    transaction.Dispose();
                    con.Close();

                }
            }
        }

        protected void IARateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IARateGrid.PageIndex = e.NewPageIndex;
            if (IaDdl.SelectedIndex > 0)
            {
                if (ServiceDropDown.SelectedIndex > 0)
                {
                    bindApplicableChargeForGridServiceWise(ServiceDropDown.SelectedValue.Trim());
                }
                else
                {
                    bindApplicableChargeForGridIAWise(IaDdl.SelectedValue.Trim());
                }
            }
            else
            {
                bindApplicableChargeForGrid(UserName);
            }
        }

        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceDropDown.SelectedIndex = 0;
            txtSearch.Text = "";
            txtApplicableCharge.Text = "";
            txtEffectiveFromDate.Text = "";

            if (IaDdl.SelectedIndex == 0)
            {
                bindApplicableChargeForGrid(UserName);
            }
            else
            {
                bindApplicableChargeForGridIAWise(IaDdl.SelectedValue.Trim());
            }
        }

        protected void ServiceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentCategoryDropDown.SelectedIndex = 0;
            txtSearch.Text = "";
            txtApplicableCharge.Text = "";
            txtEffectiveFromDate.Text = "";

            if (ServiceDropDown.SelectedIndex == 0)
            {
                bindApplicableChargeForGridIAWise(IaDdl.SelectedValue.Trim());
            }
            else
            {
                bindApplicableChargeForGridServiceWise(ServiceDropDown.SelectedValue.Trim());
            }
        }

        protected void txtSearch_TextChanged1(object sender, EventArgs e)
        {
            if (IaDdl.SelectedIndex > 0)
            {
                if (ServiceDropDown.SelectedIndex > 0)
                {
                    bindApplicableChargeForGridServiceWise(ServiceDropDown.SelectedValue.Trim());
                }
                else
                {
                    bindApplicableChargeForGridIAWise(IaDdl.SelectedValue.Trim());
                }
            }
            else
            {
                bindApplicableChargeForGrid(UserName);
            }
        }

        protected void PaymentCategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtApplicableCharge.Text = "";
            txtEffectiveFromDate.Text = "";
        }


    }





}






