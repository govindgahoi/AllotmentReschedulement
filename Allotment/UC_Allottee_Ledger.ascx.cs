using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_Allottee_Ledger : System.Web.UI.UserControl
    {
        SqlConnection con;
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        public string IAID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        public string ApplicantID { get; set; }
        public string ButtonStatus { get; set; }
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string[] SerIdarray = ServiceReqNo.Split('/');


                if (ServiceReqNo.Length > 0)
                {
                    AllotteeID = SerIdarray[2].Trim();
                }
                else
                {
                    AllotteeID = ApplicantID;
                }
                if (ButtonStatus == "Hide")
                {
                    btnBack.Visible = false;
                }
                Page.Form.Enctype = "multipart/form-data";

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }



                BindAllotteePaymentSummary(AllotteeID);
                BindAllotteeJournal(AllotteeID);
                bindPaymentHead();

            }
            catch (Exception ex)
            {
            }

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

        private void BindAllotteeJournal(string AllotteeID)
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteeJournal] " + Convert.ToInt32(AllotteeID) + "", con);
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

        private void BindAllotteePaymentSummary(string AllotteeID)
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + Convert.ToInt32(AllotteeID) + "", con);
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];


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

                //if (ddl_PayStatus.SelectedValue == "2")
                //{
                //    SqlCommand cmd = new SqlCommand("sp_getAllotteeOutstandingAmount " + drp_Allottee.SelectedValue.Trim() + "," + ddl_PaymentHead.SelectedValue.Trim() + "," + txtAmount.Text.Trim() + "", con);
                //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //    DataTable dt = new DataTable();
                //    adp.Fill(dt);
                //    string result = dt.Rows[0][0].ToString();
                //    if(result=="NotAllowed")
                //    {
                //        MessageBox1.ShowWarning("Invalid Entry");
                //        return;
                //    }
                //}


                string Date = DateTime.ParseExact(txtTransactionDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                objServiceTimelinesBEL.PaymentTableID = txtID.Text;
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(AllotteeID);
                objServiceTimelinesBEL.PaymentID = ddl_PaymentHead.SelectedValue.Trim();
                objServiceTimelinesBEL.PaymentDescription = txtDescription.Text.Trim();
                objServiceTimelinesBEL.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();
                objServiceTimelinesBEL.Statusofwork = ddl_PayStatus.SelectedValue.Trim();
                objServiceTimelinesBEL.TransactionDate = Convert.ToDateTime(Date);



                int Result = objServiceTimelinesBLL.InsertAllotteeLedgerEntry(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    MessageBox1.ShowSuccess("Inserted/Updated Successfully");
                    BindAllotteeJournal(AllotteeID);
                    BindAllotteePaymentSummary(AllotteeID);
                    txtAmount.Text = "";
                    txtDescription.Text = "";
                    txtTransactionDate.Text = "";
                    lblID.Text = "";

                    txtID.Text = "";

                    ddl_PayStatus.SelectedValue = "0";
                    ddl_PaymentHead.SelectedValue = "0";


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
                lblID.Text = ID;
                ViewState["Temppayid"] = ID;
                txtID.Text = ID;
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

                        BindAllotteeJournal(AllotteeID);
                        BindAllotteePaymentSummary(AllotteeID);

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
                string credit = AllotteeJournalGrid.Rows[i].Cells[5].Text;
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Page.GetType().InvokeMember("View_Objection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { "Ledger" });

        }
    }
}