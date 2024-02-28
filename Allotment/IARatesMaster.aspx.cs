using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class IARatesMaster : System.Web.UI.Page
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
                UserName                = _objLoginInfo.userName;
                if (!IsPostBack)
                {
                    check_user_role();
                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }

            
        }

        private void bindSector(string IAID, string Sector)
        {
            objServiceTimelinesBEL.IAId =  Convert.ToInt32(IAID);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSectorsIAWise(objServiceTimelinesBEL);
                ddlSector.DataSource = ds;
                ddlSector.DataTextField = "Sector_Name";
                ddlSector.DataValueField = "SectorID";
                ddlSector.DataBind();

                if (!string.IsNullOrEmpty(Sector))
                {
                    ddlSector.SelectedIndex = ddlSector.Items.IndexOf(ddlSector.Items.FindByText(Sector));
                }

                try { ddlSector_SelectedIndexChanged(null, null); } catch { }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
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

        protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                IaDdl.DataSource = ds;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));
                reset1();
                bindRateGrid("", "","");

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

                if (ddlRateType.SelectedValue == "0")
                {
                    MessageBox1.ShowWarning("Please Select Rate Type");
                    return;
                }
                if (ddlRateType.SelectedValue == "T")
                {
                    if (txtMinRange.Text == "")
                    {
                        MessageBox1.ShowWarning("Please Select Min Range");
                        return;
                    }

                }

                string effectivefrom = "", effectiveto = "";
                if (dlregion.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Regional Office");
                    return;
                }
                else
                {
                    if (IaDdl.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select Industrial Area");
                        return;
                    }
                    else
                    {
                        if (txtRateOfPlot.Text == "" || txtRateOfPlot.Text == null)
                        {
                            MessageBox1.ShowWarning("Please Provide Rate Of Plot");
                            return;
                        }
                        else
                        {
                            if (txtInterestRate.Text == "" || txtInterestRate.Text == null)
                            {
                                MessageBox1.ShowWarning("Please Provide Interest Rate");
                                return;
                            }
                            else
                            {
                                if (txtRebate.Text == "" || txtRebate.Text == null)
                                {
                                    MessageBox1.ShowWarning("Please Provide Rebate");
                                    return;
                                }
                                else
                                {
                                    if (txtNoOfInstallments.Text == "" || txtNoOfInstallments.Text == null)
                                    {
                                        MessageBox1.ShowWarning("Please Provide No Of Installments");
                                        return;
                                    }
                                    else
                                    {
                                        if (txtEMDRates.Text == "" || txtEMDRates.Text == null)
                                        {
                                            MessageBox1.ShowWarning("Please Provide EMD Rate");
                                            return;
                                        }
                                        else
                                        {
                                            if (txtRegistrationMoneyRate.Text == "" || txtRegistrationMoneyRate.Text == null)
                                            {
                                                MessageBox1.ShowWarning("Please Provide Reservation Money Rate");
                                                return;
                                            }
                                            else
                                            {

                                              
                                                if (txtEffectiveFromDate.Text == "" || txtEffectiveFromDate.Text == null)
                                                {
                                                    MessageBox1.ShowWarning("Please Provide Effective From Date");
                                                    effectivefrom = "";
                                                    return;
                                                }
                                                else
                                                {
                                                    if (ValidateDate(txtEffectiveFromDate.Text.Trim()))
                                                    {
                                                        effectivefrom = DateTime.ParseExact(txtEffectiveFromDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                                                    }
                                                    else
                                                    {
                                                        txtEffectiveFromDate.Focus();
                                                        MessageBox1.ShowError("Invalid Effective From Date");
                                                        return;
                                                    }
                                                    if (DropDownList1.SelectedValue == "0")
                                                    {
                                                        MessageBox1.ShowWarning("Please Select IA Classification");
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        

                                                        if (txtEffectiveToDate.Text.Trim() != "")
                                                        {
                                                            if (ValidateDate(txtEffectiveToDate.Text.Trim()))
                                                            {
                                                            }
                                                            else
                                                            {
                                                                txtEffectiveToDate.Focus();
                                                                MessageBox1.ShowError("Invalid Effective To Date");
                                                                return;
                                                            }
                                                        }
                                                        if (btnSubmit.Text == "Submit")
                                                        {
                                                            RateIdlbl.Text = "0";
                                                            command = new SqlCommand(@"InsertIARateMaster_sp", con, transaction);
                                                            command.CommandType = CommandType.StoredProcedure;
                                                            command.Parameters.AddWithValue("@p", 'I');
                                                            command.Parameters.AddWithValue("@RateID", Convert.ToInt32(RateIdlbl.Text.Trim()));
                                                            command.Parameters.AddWithValue("@IAId", IaDdl.SelectedValue.Trim());
                                                            command.Parameters.AddWithValue("@RateofPlot", Convert.ToDecimal(txtRateOfPlot.Text.Trim()));
                                                            command.Parameters.AddWithValue("@InterestRate", Convert.ToDecimal(txtInterestRate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@Rebate", Convert.ToDecimal(txtRebate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@NoofInstallments", txtNoOfInstallments.Text.Trim());
                                                            command.Parameters.AddWithValue("@EMDRate", Convert.ToDecimal(txtEMDRates.Text.Trim()));
                                                            command.Parameters.AddWithValue("@RegistrationMoneyRate", Convert.ToDecimal(txtRegistrationMoneyRate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@DepricationRate", txtDepreciationRate.Text.Trim());
                                                            command.Parameters.AddWithValue("@LocationChage", 0);                                                             command.Parameters.AddWithValue("@EffectiveFromDate", effectivefrom.Trim());
                                                            command.Parameters.AddWithValue("@SecID", ddlSector.SelectedValue.Trim());
                                                            if (txtMinRange.Text == "" || txtMinRange.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@MinRange", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                command.Parameters.AddWithValue("@MinRange", txtMinRange.Text.Trim());
                                                            }
                                                            if (txtMaxRange.Text == "" || txtMaxRange.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@MaxRange", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                command.Parameters.AddWithValue("@MaxRange", txtMaxRange.Text.Trim());
                                                            }


                                                            command.Parameters.AddWithValue("@Ratetype", ddlRateType.SelectedValue.Trim());
                                                            if (txtEffectiveToDate.Text == "" || txtEffectiveToDate.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@EffectiveToDate", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                effectiveto = DateTime.ParseExact(txtEffectiveToDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                                                                command.Parameters.AddWithValue("@EffectiveToDate", effectiveto.Trim());
                                                            }
                                                            command.Parameters.AddWithValue("@CreatedBy", UserName);
                                                            command.Parameters.AddWithValue("@ModifiedBy", UserName);
                                                            command.Parameters.AddWithValue("@IAStatus", DropDownList1.SelectedValue.Trim());
                                                            command.Parameters.AddWithValue("@CircleRate", 0);
                                                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));



                                                        }
                                                        else if (btnSubmit.Text == "Update")
                                                        {
                                                           
                                                            command = new SqlCommand(@"InsertIARateMaster_sp", con, transaction);
                                                            command.CommandType = CommandType.StoredProcedure;
                                                            command.Parameters.AddWithValue("@p", 'U');
                                                            command.Parameters.AddWithValue("@RateID", Convert.ToInt32(RateIdlbl.Text.Trim()));
                                                            command.Parameters.AddWithValue("@IAId", IaDdl.SelectedValue.Trim());
                                                            command.Parameters.AddWithValue("@RateofPlot", Convert.ToDecimal(txtRateOfPlot.Text.Trim()));
                                                            command.Parameters.AddWithValue("@InterestRate", Convert.ToDecimal(txtInterestRate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@Rebate", Convert.ToDecimal(txtRebate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@NoofInstallments", txtNoOfInstallments.Text.Trim());
                                                            command.Parameters.AddWithValue("@EMDRate", Convert.ToDecimal(txtEMDRates.Text.Trim()));
                                                            command.Parameters.AddWithValue("@RegistrationMoneyRate", Convert.ToDecimal(txtRegistrationMoneyRate.Text.Trim()));
                                                            command.Parameters.AddWithValue("@DepricationRate", txtDepreciationRate.Text.Trim());
                                                            command.Parameters.AddWithValue("@LocationChage", 0);// Convert.ToDecimal(txtLocationCharge.Text.Trim()));
                                                            command.Parameters.AddWithValue("@EffectiveFromDate", effectivefrom.Trim());
                                                            if (txtEffectiveToDate.Text == "" || txtEffectiveToDate.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@EffectiveToDate", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                effectiveto = DateTime.ParseExact(txtEffectiveToDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                                                                command.Parameters.AddWithValue("@EffectiveToDate", effectiveto.Trim());
                                                            }
                                                            if (txtMinRange.Text == "" || txtMinRange.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@MinRange", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                command.Parameters.AddWithValue("@MinRange", txtMinRange.Text.Trim());
                                                            }
                                                            if (txtMaxRange.Text == "" || txtMaxRange.Text == null)
                                                            {
                                                                command.Parameters.AddWithValue("@MaxRange", DBNull.Value);
                                                            }
                                                            else
                                                            {
                                                                command.Parameters.AddWithValue("@MaxRange", txtMaxRange.Text.Trim());
                                                            }
                                                            command.Parameters.AddWithValue("@Ratetype", ddlRateType.SelectedValue.Trim());
                                                            command.Parameters.AddWithValue("@CreatedBy", UserName);
                                                            command.Parameters.AddWithValue("@ModifiedBy", UserName);
                                                            command.Parameters.AddWithValue("@IAStatus", DropDownList1.SelectedValue.Trim());
                                                            command.Parameters.AddWithValue("@CircleRate", 0); //txtCircleRate.Text.Trim());

                                                            transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                                                        }
                                                    }
                                                }
                                                if (transactionResult)
                                                {
                                                    transaction.Commit();
                                                    MessageBox1.ShowSuccess("Rate Inserted/Updated successfully");
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
                                        }
                                    }
                                }
                            }
                        }
                    }
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

            bindregion1();
            bindRateGrid("", "","");

        }

        private void bindRateGrid(string IAId, string p,string SecID)
        {
            try
            {
           
            SqlCommand cmd = new SqlCommand("GetIARatesDetail_sp1 '" + IAId + "','" + p + "','" + UserName + "','" + txtSearch.Text.Trim() + "','"+ SecID.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            IARateGrid.DataSource = dt;
            IARateGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gridFunc()
        {

            if (IaDdl.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand("GetIARatesDetail_sp1 '" + IaDdl.SelectedValue.Trim() + "','S','" + UserName + "','" + txtSearch.Text.Trim() + "','"+ddlSector.SelectedValue.Trim()+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                IARateGrid.DataSource = dt;
                IARateGrid.DataBind();
            }
            else
            {
                bindRateGrid("", "","");
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
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

                string rowid     = commandArgs[0];
                string iaID      = commandArgs[1];
                string regoffice = commandArgs[2].Trim();             
                dlregion.SelectedValue = regoffice;
                dlregion_SelectedIndexChanged(null, null);
                IaDdl.SelectedValue = iaID.Trim();              
                get_prev_rate(Convert.ToInt32(rowid));



            }
            if (e.CommandName == "DeleteRate")
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
                    command.CommandText = ("delete From Master_IARates where RateID='" + rowid + "'");
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("Rate Deleted successfully");

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
        }

        private void reset()
        {
            dlregion.SelectedIndex = 0;
            txtRateOfPlot.Text = "";
            txtRebate.Text = "";
            txtRegistrationMoneyRate.Text = "";
            txtNoOfInstallments.Text = "";
            txtEMDRates.Text = "";
            txtDepreciationRate.Text = "";
            txtLocationCharge.Text = "0";
            txtEffectiveFromDate.Text = "";
            txtEffectiveToDate.Text = "";
            txtInterestRate.Text = "";
            btnSubmit.Text = "Submit";
            RateIdlbl.Text = "0";
            IaDdl.Items.Clear();
            txtCircleRate.Text = "0";
            DropDownList1.SelectedValue = "0";
            ddlRateType.SelectedValue = "0";
            txtMinRange.Text = "";
            txtMaxRange.Text = "";
            Div_Telescopic.Visible = false;
            gridFunc();

        }
        private void reset1()
        {

            txtRateOfPlot.Text = "";
            txtRebate.Text = "";
            txtRegistrationMoneyRate.Text = "";
            txtNoOfInstallments.Text = "";
            txtEMDRates.Text = "";
            txtDepreciationRate.Text = "";
            txtLocationCharge.Text = "0";
            txtEffectiveFromDate.Text = "";
            txtEffectiveToDate.Text = "";
            txtInterestRate.Text = "";
            btnSubmit.Text = "Submit";
            RateIdlbl.Text = "";
            ddlRateType.SelectedValue = "0";
            txtMinRange.Text = "";
            txtMaxRange.Text = "";
            Div_Telescopic.Visible = false;
            txtCircleRate.Text = "0";
            DropDownList1.SelectedValue = "0";

        }



        private void get_prev_rate(int id)
        {
            RateIdlbl.Text = "0";
            SqlCommand cmd = new SqlCommand("Select a.*,convert(varchar(10),a.EffectiveFromDate,103) as 'EffectiveFrom',convert(varchar(10),a.EffectiveToDate,103) as 'EffectiveTo' from Master_IARates a where IAId='" + IaDdl.SelectedValue.Trim() + "' and RateID=" + id + "   and Active=1", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                RateIdlbl.Text                = dt.Rows[0]["RateID"].ToString();
                txtRateOfPlot.Text            = dt.Rows[0]["RateofPlot"].ToString();
                txtInterestRate.Text          = dt.Rows[0]["InterestRate"].ToString();
                txtRebate.Text                = dt.Rows[0]["Rebate"].ToString();
                txtNoOfInstallments.Text      = dt.Rows[0]["NoofInstallments"].ToString();
                txtEMDRates.Text              = dt.Rows[0]["EMDRate"].ToString();
                txtRegistrationMoneyRate.Text = dt.Rows[0]["RegistrationMoneyRate"].ToString();
                txtDepreciationRate.Text      = dt.Rows[0]["DepricationRate"].ToString();             
                DropDownList1.SelectedValue   = dt.Rows[0]["IAStatus"].ToString().Trim();
                string date                   = dt.Rows[0]["EffectiveFrom"].ToString();
                string date1                  = dt.Rows[0]["EffectiveTo"].ToString();
            

                txtEffectiveFromDate.Text = date;
                txtEffectiveToDate.Text = date1;
                btnSubmit.Text = "Update";

                bindRateGrid(IaDdl.SelectedValue.Trim(), "S",ddlSector.SelectedValue.Trim());
                if (dt.Rows[0]["RateType"].ToString().Trim().Length > 0)
                {
                    ddlRateType.SelectedValue = dt.Rows[0]["RateType"].ToString().Trim();
                }
                else
                {
                    ddlRateType.SelectedValue = "0";
                }
                if (dt.Rows[0]["RateType"].ToString().Trim() == "T")
                {
                    Div_Telescopic.Visible = true;
                    txtMinRange.Text = dt.Rows[0]["MinArea"].ToString().Trim();
                    txtMaxRange.Text = dt.Rows[0]["MaxArea"].ToString().Trim();
                }
                else

                {
                    Div_Telescopic.Visible = false;
                }
            }
            else
            {
                txtRateOfPlot.Text            = "";
                txtRebate.Text                = "";
                txtRegistrationMoneyRate.Text = "";
                txtNoOfInstallments.Text      = "";
                txtEMDRates.Text              = "";
                txtDepreciationRate.Text      = "";
                txtLocationCharge.Text        = "0";
                txtEffectiveFromDate.Text     = "";
                txtEffectiveToDate.Text       = "";
                txtCircleRate.Text            = "0";
                txtInterestRate.Text          = "";
                btnSubmit.Text                = "Submit";
                RateIdlbl.Text                = "0";
            }

        }
        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }
            catch
            {
                return false;
            }
        }
        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindSector(IaDdl.SelectedValue.Trim(),null);
        }



        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            reset();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindRateGrid("", "","");
        }

        protected void Home_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DashboardI.aspx");
        }
        protected void ddlRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRateType.SelectedValue == "T")
            {
                Div_Telescopic.Visible = true;
            }
            else
            {
                Div_Telescopic.Visible = false;
            }
        }
        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindRateGrid(IaDdl.SelectedValue.Trim(), "S",ddlSector.SelectedValue.Trim());
        }
    }
}






