using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class IAMaintenanceChargeMaster : System.Web.UI.Page
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


                check_user_role();
            }
        }

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
        private void bindregion1()
        {
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

                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
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
                ds = objServiceTimelinesBLL.GetregionalNameRecords1(objServiceTimelinesBEL);
                IaDdl.DataSource = ds;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
                //reset1();
                if (dlregion.SelectedIndex > 0) { bindRateGrid1(dlregion.SelectedValue.Trim(), ""); } else { bindRateGrid("", ""); }


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
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (dlregion.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Regional Office");
                    return;
                }
                if (IaDdl.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Industrial Area");
                    return;
                }

                if (txtRate.Text == "" || txtRate.Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Maintenance Charge");
                    return;
                }
                if (txtEffectiveFromDate.Text == "" || txtEffectiveFromDate.Text == null)
                {
                    MessageBox1.ShowWarning("Please Provide Effective From Date");
                    return;
                }



                command = new SqlCommand(@"[InsertIAMaintenanceCharge_sp]", con, transaction);
                command.CommandType = CommandType.StoredProcedure;


                if (RateIdlbl.Text == "" || RateIdlbl.Text == null)
                { RateIdlbl.Text = "0"; command.Parameters.AddWithValue("@ParamType", 'I'); }
                else { command.Parameters.AddWithValue("@ParamType", 'U'); }
                command.Parameters.AddWithValue("@RateID", Convert.ToInt32(RateIdlbl.Text.Trim()));
                command.Parameters.AddWithValue("@IndustrialArea", IaDdl.SelectedValue.Trim());
                command.Parameters.AddWithValue("@Rate", Convert.ToDecimal(txtRate.Text.Trim()));
                command.Parameters.AddWithValue("@Effective_From", txtEffectiveFromDate.Text.Trim());
                if (txtEffectiveToDate.Text == "" || txtEffectiveToDate.Text == null)
                {
                    command.Parameters.AddWithValue("@Effective_To", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Effective_To", txtEffectiveToDate.Text.Trim());
                }


                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));



                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Maintenance Charge detail Updated/Inserted Successfully.";
                    MessageBox1.ShowSuccess(message);
                    reset1();
                    gridFunc();

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

        private void check_user_role()
        {

            bindregion("");
            bindRateGrid("", "");

        }

        private void bindRateGrid(string IAId, string p)
        {
            objServiceTimelinesBEL.IAIdParam = IAId;
            objServiceTimelinesBEL.ParamType = p;
            objServiceTimelinesBEL.UserName = UserName;
            objServiceTimelinesBEL.searchText = txtSearch.Text.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAMaintenanceChargeDetails(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IARateGrid.DataSource = dt;
                        IARateGrid.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindRateGrid1(string reg, string ia)
        {
            SqlCommand cmd = new SqlCommand("[GetIAMaintenanceChargeDetail_sp1] '" + reg + "','" + ia + "','" + txtSearch.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            IARateGrid.DataSource = dt;
            IARateGrid.DataBind();
        }
        private void gridFunc()
        {
            if (dlregion.SelectedIndex > 0 && IaDdl.SelectedIndex <= 0)
            {
                bindRateGrid1(dlregion.SelectedValue.Trim(), "");
            }
            else if (dlregion.SelectedIndex > 0 && IaDdl.SelectedIndex > 0)
            {
                bindRateGrid1("", IaDdl.SelectedValue.Trim());
            }
            else
            {
                bindRateGrid("", "");
            }

        }


        protected void IARateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IARateGrid.PageIndex = e.NewPageIndex;
            gridFunc();
        }
        protected void IARateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                int rowid = Convert.ToInt32(e.CommandArgument.ToString());
                RateIdlbl.Text = e.CommandArgument.ToString();
                get_prev_rate(rowid);

            }

            if (e.CommandName == "DeleteRate")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });


                string rowid = commandArgs[0];
                string IA = commandArgs[1];

                objServiceTimelinesBEL.LeaseRateId = Convert.ToInt32(rowid);
                objServiceTimelinesBEL.IAName = IA;

                int retVal = objServiceTimelinesBLL.DeleteIAMaintenanceCharge(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    MessageBox1.ShowSuccess("Maintenance Charge Deleted Successfully");
                    gridFunc();
                }
                else
                {
                    MessageBox1.ShowError("There Are Some Error In deleting Maintenance Charge");
                }


            }
        }

        private void reset()
        {
            dlregion.SelectedIndex = 0;

            btnSubmit.Text = "Submit";
            RateIdlbl.Text = "";
            IaDdl.Items.Clear();
            txtEffectiveFromDate.Text = "";

            txtRate.Text = "";
            txtEffectiveToDate.Text = "";
            bindRateGrid("", "");
        }
        private void reset1()
        {


            btnSubmit.Text = "Submit";
            RateIdlbl.Text = "";

            txtEffectiveFromDate.Text = "";
            txtEffectiveToDate.Text = "";

            txtRate.Text = "";

        }

        private void get_prev_rate(int rowid)
        {

            objServiceTimelinesBEL.LeaseRateIdParam = rowid;

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIAMaintenanceChargePrev(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    string regoffice = dt.Rows[0]["RegionalOffice"].ToString().Trim();
                    if (regoffice == "FAIZABAD REGION")
                    {
                        dlregion.SelectedIndex = 5;
                    }
                    else
                    {
                        dlregion.SelectedValue = regoffice.Trim();
                    }
                    dlregion_SelectedIndexChanged(null, null);
                    IaDdl.SelectedValue = dt.Rows[0]["IndustrialArea"].ToString().Trim();

                    txtRate.Text = dt.Rows[0]["Rate"].ToString().Trim();
                    if (dt.Rows[0]["effective_from"].ToString().Trim() == "" || dt.Rows[0]["effective_from"].ToString().Trim() == null)
                    {
                    }
                    else
                    {
                        txtEffectiveFromDate.Text = Convert.ToDateTime(dt.Rows[0]["effective_from"].ToString().Trim()).ToString("dd MMM yyyy");

                    }
                    if (dt.Rows[0]["effective_to"].ToString().Trim() == "" || dt.Rows[0]["effective_to"].ToString().Trim() == null)
                    {
                    }
                    else
                    {
                        txtEffectiveToDate.Text = Convert.ToDateTime(dt.Rows[0]["effective_to"].ToString().Trim()).ToString("dd MMM yyyy");

                    }
                    btnSubmit.Text = "Update";
                }
                else
                {
                    btnSubmit.Text = "Submit";

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }



        }



        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IaDdl.SelectedIndex == 0)
            { bindRateGrid1(dlregion.SelectedValue.Trim(), ""); }
            else { bindRateGrid1("", IaDdl.SelectedValue.Trim()); }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();

        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gridFunc();

        }





        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            reset();
        }



        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }


    }





}






