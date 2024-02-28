using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class AllotteeLedgerEntry : System.Web.UI.Page
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
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            
            if (!IsPostBack)
            {
                bindregion1();
                bindPaymentHead();
                lblPaymentDateType.Visible = false;
                txtPaymentDate.Visible = false;

            }
        }


        private void bindregion1()
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

        private void bindIA(string IA)
        {
            SqlCommand cmd = new SqlCommand("GetIAUserRoleWise_sp '" + IA + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            IaDdl.DataSource = dt;
            IaDdl.DataTextField = "IAName";
            IaDdl.DataValueField = "Id";
            IaDdl.DataBind();
            IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void bindPaymentHead()
        {
            SqlCommand cmd = new SqlCommand("[GetPaymentforLedger]", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddl_PaymentHead.DataSource = dt;
            ddl_PaymentHead.DataTextField = "Description";
            ddl_PaymentHead.DataValueField = "PaymentID";
            ddl_PaymentHead.DataBind();
            ddl_PaymentHead.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void BindAllotteeJournal()
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteeJournal] " + drp_Allottee.SelectedValue.Trim() + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteeJournalGrid.DataSource = dt;
                AllotteeJournalGrid.DataBind();
            }
            else
            {
                AllotteeJournalGrid.DataSource = null;
                AllotteeJournalGrid.DataBind();
            }
        }

        private void BindAllotteePaymentSummary()
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + drp_Allottee.SelectedValue.Trim() + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteePaymentSummaruGrid.DataSource = dt;
                AllotteePaymentSummaruGrid.DataBind();
                decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("Demanded"));
                decimal tot_Paid = dt.AsEnumerable().Sum(row => row.Field<decimal>("Paid"));
                decimal tot_Outstanding = dt.AsEnumerable().Sum(row => row.Field<decimal>("Outstanding"));
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].Text = "Total";
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                AllotteePaymentSummaruGrid.FooterRow.Cells[2].Text = tot_Demanded.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[3].Text = tot_Paid.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[4].Text = tot_Outstanding.ToString("N2");
            }
            else
            {
                AllotteePaymentSummaruGrid.DataSource = null;
                AllotteePaymentSummaruGrid.DataBind();
            }
        }

        protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords1(objServiceTimelinesBEL);
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


        protected void drp_Allottee_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllotteeJournal();
            BindAllotteePaymentSummary();
            BindAllottee();
        }

        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.IndustrialArea = (IaDdl.SelectedItem.Text.Trim());

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotteeForLedgerEntry(objServiceTimelinesBEL);
                drp_Allottee.DataSource = ds;
                drp_Allottee.DataTextField = "AllotteeName";
                drp_Allottee.DataValueField = "AllotteeID";
                drp_Allottee.DataBind();
                drp_Allottee.Items.Insert(0, new ListItem("--Select--", "0"));


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

        protected void ddl_PayStatus_selectedindex_changed(object sender, EventArgs e)
        {

            if (ddl_PaymentHead.SelectedValue == "25")
            {
                lblPaymentDateType.Visible = true;
                txtPaymentDate.Visible = true;

                if (ddl_PayStatus.SelectedValue == "0")
                {
                    lblPaymentDateType.Text = "";
                }
                else if (ddl_PayStatus.SelectedValue == "1")
                {
                    lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Due Date";
                }
                else if (ddl_PayStatus.SelectedValue == "2")
                {
                    lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Payment Date";
                }
            }
            else if (ddl_PaymentHead.SelectedValue == "26")
            {
                lblPaymentDateType.Visible = true;
                txtPaymentDate.Visible = true;

                if (ddl_PayStatus.SelectedValue == "0")
                {
                    lblPaymentDateType.Text = "";
                }
                else if (ddl_PayStatus.SelectedValue == "1")
                {
                    lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Due Date";
                }
                else if (ddl_PayStatus.SelectedValue == "2")
                {
                    lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Payment Date";
                }
            }
            else
            {
                lblPaymentDateType.Visible = false;
                txtPaymentDate.Visible = false;
            }            
        }

        protected void ddl_PaymentHead_selectedindex_changed(object sender, EventArgs e)
        {
            
            if (ddl_PaymentHead.SelectedValue == "25")
            {
                lblPaymentDateType.Visible = true;
                txtPaymentDate.Visible = true;
                lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Due/Payment Date";
            }
            else if (ddl_PaymentHead.SelectedValue == "26")
            {
                lblPaymentDateType.Visible = true;
                txtPaymentDate.Visible = true;
                lblPaymentDateType.Text = "<span style ='color: Red'>*</span> Due/Payment Date";
            }
            else
            {
                lblPaymentDateType.Visible = false;
                txtPaymentDate.Visible = false;
            }
            ddl_PayStatus.SelectedValue = "0";
        }



        

        private void BindAllottee()
        {
            try
            {


                SqlCommand cmd = new SqlCommand("[sp_GetAllotteeDetailsByID] " + drp_Allottee.SelectedValue.Trim() + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbl_RegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lbl_IA.Text = dt.Rows[0]["IAName"].ToString();
                    lbl_Allottee.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblPlot.Text = dt.Rows[0]["PlotNo"].ToString();
                    lbl_RegionalOffice1.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lbl_IA1.Text = dt.Rows[0]["IAName"].ToString();
                    lbl_Allottee1.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lbl_PlotNo1.Text = dt.Rows[0]["PlotNo"].ToString();
                }
                else
                {
                    lbl_RegionalOffice.Text = "";
                    lbl_IA.Text = "";
                    lbl_Allottee.Text = "";
                    lblPlot.Text = "";
                    lbl_RegionalOffice1.Text = "";
                    lbl_IA1.Text = "";
                    lbl_Allottee1.Text = "";
                    lbl_PlotNo1.Text = "";
                }
            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                if (drp_Allottee.SelectedValue.Trim() == "")
                {
                    MessageBox1.ShowWarning("Please select Allottee Details");
                    return;
                }
                
                if (txtTransactionDate.Text == "")
                {
                    MessageBox1.ShowWarning("Transaction Date Is Required");
                    return;
                }
                if (ddl_PaymentHead.SelectedValue == "0")
                {
                    MessageBox1.ShowWarning("Please Select Payment Head");
                    return;
                }
                if (txtDescription.Text == "")
                {
                    MessageBox1.ShowWarning("Please enter some description");
                    return;
                }
                if (ddl_PayStatus.SelectedValue == "0")
                {
                    MessageBox1.ShowWarning("Please Select Payment type");
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox1.ShowWarning("Please enter amount");
                    return;
                }

                if (ddl_PaymentHead.SelectedValue == "0")
                {
                    MessageBox1.ShowWarning("Please Select Payment Head");
                    return;
                }

                if (ddl_PayStatus.SelectedValue == "2")
                {
                    SqlCommand cmd = new SqlCommand("sp_getAllotteeOutstandingAmount " + drp_Allottee.SelectedValue.Trim() + "," + ddl_PaymentHead.SelectedValue.Trim() + "," + txtAmount.Text.Trim() + "", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    string result = dt.Rows[0][0].ToString();
                    if (result == "NotAllowed")
                    {
                        MessageBox1.ShowWarning("Invalid Entry");
                        return;
                    }
                }


                string Date = DateTime.ParseExact(txtTransactionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                
                objServiceTimelinesBEL.PaymentTableID = lblID.Text.Trim();
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(drp_Allottee.SelectedValue.Trim());
                objServiceTimelinesBEL.PaymentID = ddl_PaymentHead.SelectedValue.Trim();
                objServiceTimelinesBEL.PaymentDescription = txtDescription.Text.Trim();
                objServiceTimelinesBEL.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();
                objServiceTimelinesBEL.Statusofwork = ddl_PayStatus.SelectedValue.Trim();
                objServiceTimelinesBEL.TransactionDate = Convert.ToDateTime(Date);


                if (txtPaymentDate.Text.Trim() != "")
                {
                    string PaymentDate = DateTime.ParseExact(txtPaymentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.PaymentDate = PaymentDate;
                }
                /*
                else
                {
                    //string PaymentDate = DateTime.ParseExact("12/12/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.PaymentDate = "";
                }
                */

                int Result = objServiceTimelinesBLL.InsertAllotteeLedgerEntry(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    MessageBox1.ShowSuccess("Inserted/Updated Successfully");
                    BindAllotteeJournal();
                    BindAllotteePaymentSummary();
                    txtAmount.Text = "";
                    txtDescription.Text = "";
                    txtTransactionDate.Text = "";
                    txtPaymentDate.Text = "";
                    lblPaymentDateType.Text = "";
                    lblID.Text = "";
                    ddl_PayStatus.SelectedValue = "0";
                    ddl_PaymentHead.SelectedValue = "0";
                    btnAdd.Text = "Add";

                }
                else
                {
                    MessageBox1.ShowError("Error During The Process");
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
                return;
            }
        }

        protected void AllotteeJournalGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '|' });

                string TransactionDate = commandArgs[0].Trim();
                string PaymentHeadID = commandArgs[1].Trim();
                string Description = commandArgs[2].Trim();
                string Debit = commandArgs[3].Trim();
                string Credit = commandArgs[4].Trim();
                string ID = commandArgs[5].Trim();
                string Paystatus = commandArgs[6].Trim();
                string Amount = commandArgs[7].Trim();
                txtTransactionDate.Text = TransactionDate;
                ddl_PaymentHead.SelectedValue = PaymentHeadID;
                txtDescription.Text = Description;
                ddl_PayStatus.SelectedValue = Paystatus;
                txtAmount.Text = Amount;

                if (Paystatus == "1")
                {
                    txtPaymentDate.Text = commandArgs[8].Trim();
                    lblPaymentDateType.Text = "Due Date";
                }
                else if (Paystatus == "2")
                {
                    txtPaymentDate.Text = commandArgs[9].Trim();
                    lblPaymentDateType.Text = "Payment Date";
                }
                
                lblID.Text = ID;
                btnAdd.Text = "Update";




            }
            if (e.CommandName == "DeleteRow")
            {

                string rowid = e.CommandArgument.ToString();

                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {
                    command.CommandText = ("sp_DeleteAllotteeJournalEntry '" + rowid + "'");
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));


                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("Record Deleted successfully");

                        BindAllotteeJournal();
                        BindAllotteePaymentSummary();

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

        protected void btnClar_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            txtTransactionDate.Text = "";
            txtPaymentDate.Text = "";
            lblID.Text = "";
            ddl_PayStatus.SelectedValue = "0";
            ddl_PaymentHead.SelectedValue = "0";
        }

        protected void AllotteePaymentSummaruGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteePaymentSummaruGrid.Rows.Count - 1; i++)
            {
                string Amount = AllotteePaymentSummaruGrid.Rows[i].Cells[4].Text;
                if (Convert.ToDecimal(Amount) > 0)
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                else
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Green;
                }

            }


        }

        protected void AllotteeJournalGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteeJournalGrid.Rows.Count - 1; i++)
            {
                string debit = AllotteeJournalGrid.Rows[i].Cells[4].Text;
                string credit = AllotteeJournalGrid.Rows[i].Cells[6].Text;

                if (Convert.ToDecimal(debit) > 0)
                {
                    AllotteeJournalGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                if (Convert.ToDecimal(credit) > 0)
                {
                    AllotteeJournalGrid.Rows[i].Cells[5].ForeColor = Color.Green;
                }
                

            }
        }
    }





}






