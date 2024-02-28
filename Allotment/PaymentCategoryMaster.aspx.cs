using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class PaymentCategoryMaster : System.Web.UI.Page
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
                bindPaymentCategoryForGrid();


            }
        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            PaymentCategoryDropdown.SelectedIndex = 0;
            txtTaxPercentage.Text = "";
            Idlbl.Text = "";
            TaxDiv.Visible = false;
            TaxDiv2.Visible = false;
            taxDiv3.Visible = false;

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

                command = new SqlCommand(@"[SP_InsertPaymentCategory]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;

                if (Idlbl.Text == "" || Idlbl.Text == null)
                {
                    command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = DBNull.Value;

                }
                else
                {
                    command.Parameters.AddWithValue("@ID", Idlbl.Text.Trim());
                }
                command.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                command.Parameters.AddWithValue("@PaymentID", PaymentCategoryDropdown.SelectedValue.Trim());
                command.Parameters.AddWithValue("@CreatedBy", UserName.Trim());
                if (TaxCheck.Checked == true)
                {
                    command.Parameters.AddWithValue("@TaxPaymentId", taxDropdown.SelectedValue.Trim());
                }
                else
                {
                    command.Parameters.Add("@TaxPaymentId", System.Data.SqlDbType.Int).Value = DBNull.Value;

                }
                if (PaymentCategoryDropdown.SelectedValue == "3")
                {
                    command.Parameters.AddWithValue("@TaxPercentage", txtTaxPercentage.Text.Trim());

                }
                else
                {
                    command.Parameters.Add("@TaxPercentage", System.Data.SqlDbType.Decimal).Value = DBNull.Value;

                }


                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Payment Category Inserted/Updated successfully");
                    reset();
                    bindPaymentCategoryForGridIDWise();

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
            txtTaxPercentage.Text = "";
            taxDiv3.Visible = false;
            TaxDiv2.Visible = false;
            TaxDiv.Visible = false;
            txtDescription.Text = "";




        }

        protected void IARateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                index = index % IARateGrid.PageSize;

                int id = Convert.ToInt32(IARateGrid.DataKeys[index].Values[0]);

                SqlCommand cmd = new SqlCommand("sp_GetPaymentCategoryById " + id + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Idlbl.Text = dt.Rows[0]["ID"].ToString();
                    PaymentCategoryDropdown.SelectedValue = dt.Rows[0]["Payment_Category"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    string TaxPaymentId = dt.Rows[0]["TaxPaymentId"].ToString();
                    string TaxPercentage = dt.Rows[0]["TaxPercentage"].ToString();
                    if (TaxPaymentId.Trim() == "" || TaxPaymentId.Trim() == null)
                    {
                        TaxCheck.Checked = false;
                        TaxDiv2.Visible = false;
                        taxDiv3.Visible = false;
                    }
                    else
                    {
                        TaxCheck.Checked = true;
                        bindTaxDropdown();
                        TaxDiv2.Visible = true;
                        taxDiv3.Visible = true;
                        taxDropdown.SelectedValue = dt.Rows[0]["TaxPaymentId"].ToString();

                    }
                    if (TaxPercentage.Trim() == "" || TaxPercentage.Trim() == null)
                    {
                        TaxDiv.Visible = false;
                        txtTaxPercentage.Text = "";

                    }
                    else
                    {
                        TaxDiv.Visible = true;
                        txtTaxPercentage.Text = dt.Rows[0]["TaxPercentage"].ToString();
                    }

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

                    command = new SqlCommand(@"[SP_DeletePaymentCategory]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);




                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("Payment Category Deleted successfully");
                        if (PaymentCategoryDropdown.SelectedIndex > 0)
                        {
                            bindPaymentCategoryForGridIDWise();
                        }
                        else
                        {
                            bindPaymentCategoryForGrid();
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
            if (PaymentCategoryDropdown.SelectedIndex > 0)
            {
                bindPaymentCategoryForGridIDWise();
            }
            else
            {
                bindPaymentCategoryForGrid();
            }

        }
        private void bindTaxDropdown()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_GetAllTaxPaymentCategoryForDropdown]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                taxDropdown.DataSource = dt;
                taxDropdown.DataTextField = "Description";
                taxDropdown.DataValueField = "ID";
                taxDropdown.DataBind();
                taxDropdown.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        protected void PaymentCategoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idlbl.Text = "";
            txtDescription.Text = "";
            TaxCheck.Checked = false;
            TaxDiv.Visible = false;
            TaxDiv2.Visible = false;
            taxDiv3.Visible = false;

            if (PaymentCategoryDropdown.SelectedValue == "3")
            {
                TaxDiv.Visible = true;
                TaxDiv2.Visible = false;

            }
            else
            {
                TaxDiv.Visible = false;
                txtTaxPercentage.Text = "";
                TaxDiv2.Visible = true;

            }
            if (PaymentCategoryDropdown.SelectedIndex > 0)
            {
                bindPaymentCategoryForGridIDWise();
            }
            else
            {
                bindPaymentCategoryForGrid();
            }
        }

        private void bindPaymentCategoryForGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllPaymentCategory", con);
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
        private void bindPaymentCategoryForGridIDWise()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllPaymentCategoryIDWise " + PaymentCategoryDropdown.SelectedValue.Trim() + "", con);
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

        protected void TaxCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TaxCheck.Checked == true)
            {
                bindTaxDropdown();
                taxDiv3.Visible = true;
            }
            else
            {
                taxDiv3.Visible = false;
            }
        }
    }





}






