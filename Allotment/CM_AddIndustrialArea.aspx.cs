using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class CM_AddIndustrialArea : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";
        int CompanyId;



        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                CompanyId = Convert.ToInt32(Session["CompanyId"]);
            }
            catch
            {
                Response.Redirect("/IDADashboard.aspx");
            }

            if (!IsPostBack)
            {
                bindIAGrid(CompanyId, "");
                Div1.Visible = true;
                bindddl();
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

                if (dlAuthority.SelectedIndex == 0)
                {
                    MessageBox1.ShowWarning("Please Select Authority");
                    return;
                }
                if (Div2.Visible == true)
                {
                    if (txtRegionalOffice.Text == "")
                    {
                        MessageBox1.ShowWarning("Regional Office Is A Required Field");
                        return;
                    }
                }
                if (dropdownDiv.Visible == true)
                {
                    if (dlregion.SelectedIndex == -1)
                    {
                        MessageBox1.ShowWarning("Please Select Regional Office");
                        return;
                    }
                }


                if (txtIAName.Text == "")
                {
                    MessageBox1.ShowWarning("Industrial Area Name Is A Required Field");
                    return;
                }
                if (txtTotalArea.Text == "")
                {
                    MessageBox1.ShowWarning("Total Area Is A Required Field");
                    return;
                }
                if (txtResidentialArea.Text == "")
                {
                    MessageBox1.ShowWarning("Total Residential Area Is A Required Field");
                    return;
                }
                if (txtIndustrialArea.Text == "")
                {
                    MessageBox1.ShowWarning("Total Industrial Area Is A Required Field");
                    return;
                }
                if (txtFacilities.Text == "")
                {
                    MessageBox1.ShowWarning("Total Facilities Area Is A Required Field");
                    return;
                }
                if (txtGreenZone.Text == "")
                {
                    MessageBox1.ShowWarning("Total GrrenZone Area Is A Required Field");
                    return;
                }
                if (txtCommercial.Text == "")
                {
                    MessageBox1.ShowWarning("Total Commercial Area Is A Required Field");
                    return;
                }
                if (txtMixLand.Text == "")
                {
                    MessageBox1.ShowWarning("Total Mix  Area Is A Required Field");
                    return;
                }
                if (txtRate.Text == "")
                {
                    MessageBox1.ShowWarning("Rate  Is A Required Field");
                    return;
                }

                if (Label10.Text == "")
                {
                    command = new SqlCommand(@"[InsertIAForCM_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;

                    if (UserName == "Admin")
                    {
                        command.Parameters.AddWithValue("@CompanyId", dlAuthority.SelectedValue.Trim());
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CompanyId", CompanyId);
                    }
                    if (dropdownDiv.Visible == true)
                    { command.Parameters.AddWithValue("@RegionOffice", dlregion.SelectedValue.Trim()); }
                    else if (Div2.Visible == true) { command.Parameters.AddWithValue("@RegionOffice", txtRegionalOffice.Text.Trim()); }

                    command.Parameters.AddWithValue("@IndustrialArea", txtIAName.Text.Trim());
                    command.Parameters.AddWithValue("@UserName", UserName.Trim());
                    command.Parameters.AddWithValue("@TotalArea", txtTotalArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalResidentialArea", txtResidentialArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalIndustrialArea", txtIndustrialArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalFacilitiesArea", txtFacilities.Text.Trim());
                    command.Parameters.AddWithValue("@TotalGreenZoneArea", txtGreenZone.Text.Trim());
                    command.Parameters.AddWithValue("@TotalCommercialArea", txtCommercial.Text.Trim());
                    command.Parameters.AddWithValue("@TotalInstitutional", txtInstitutional.Text.Trim());
                    command.Parameters.AddWithValue("@TotalMixLand", txtMixLand.Text.Trim());
                    command.Parameters.AddWithValue("@Rate", txtRate.Text.Trim());

                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                }
                else
                {
                    command = new SqlCommand(@"[UpdateIAForCM_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", Convert.ToInt32(Label10.Text));

                    if (UserName == "Admin")
                    {
                        command.Parameters.AddWithValue("@CompanyId", dlAuthority.SelectedValue.Trim());
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CompanyId", CompanyId);
                    }
                    if (dropdownDiv.Visible == true)
                    { command.Parameters.AddWithValue("@RegionOffice", dlregion.SelectedValue.Trim()); }
                    else if (Div2.Visible == true) { command.Parameters.AddWithValue("@RegionOffice", txtRegionalOffice.Text.Trim()); }
                    command.Parameters.AddWithValue("@IndustrialArea", txtIAName.Text.Trim());
                    command.Parameters.AddWithValue("@UserName", UserName.Trim());
                    command.Parameters.AddWithValue("@TotalArea", txtTotalArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalResidentialArea", txtResidentialArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalIndustrialArea", txtIndustrialArea.Text.Trim());
                    command.Parameters.AddWithValue("@TotalFacilitiesArea", txtFacilities.Text.Trim());
                    command.Parameters.AddWithValue("@TotalGreenZoneArea", txtGreenZone.Text.Trim());
                    command.Parameters.AddWithValue("@TotalCommercialArea", txtCommercial.Text.Trim());
                    command.Parameters.AddWithValue("@TotalInstitutional", txtInstitutional.Text.Trim());
                    command.Parameters.AddWithValue("@TotalMixLand", txtMixLand.Text.Trim());
                    command.Parameters.AddWithValue("@Rate", txtRate.Text.Trim());
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                }
                if (transactionResult)
                {
                    transaction.Commit();
                    string message = "Industrial Area Updated/Inserted Successfully.";
                    MessageBox1.ShowSuccess(message);

                    if (UserName == "Admin")
                    {
                        if (Div2.Visible == true)
                        { dlAuthority_SelectedIndexChanged(null, null); }
                        else
                        {
                            bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim(), dlregion.SelectedValue.Trim());
                        }
                    }
                    else
                    {
                        if (Div2.Visible == true)
                        {
                            dlAuthority_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            bindIAGrid(CompanyId, txtSearch.Text.Trim());
                        }
                    }
                    reset();
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
        private void bindIAGrid(int CompanyId, string search)
        {
            SqlCommand cmd = new SqlCommand("[GetIACm] '" + UserName + "'," + CompanyId + ",'" + search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dsr = new DataSet();
            DataTable dt = new DataTable();
            adp.Fill(dsr);
            dt = dsr.Tables[0];
            IAGrid.DataSource = dt;
            IAGrid.DataBind();

            DataTable dtt = dsr.Tables[1];
            if (dtt.Rows.Count > 0)
            {
                LbltotalCount.Text = dtt.Rows[0][0].ToString();

            }
            else
            {
                LbltotalCount.Text = "0";
            }

        }
        private void bindIAGridAdmin(int CompanyId, string search, string Reg)
        {
            SqlCommand cmd = new SqlCommand("[GetIACmAll] " + CompanyId + ",'" + Reg + "','" + search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dsr = new DataSet();
            DataTable dt = new DataTable();
            adp.Fill(dsr);
            dt = dsr.Tables[0];
            IAGrid.DataSource = dt;
            IAGrid.DataBind();

            DataTable dtt = dsr.Tables[1];
            if (dtt.Rows.Count > 0)
            {
                LbltotalCount.Text = dtt.Rows[0][0].ToString();

            }
            else
            { LbltotalCount.Text = "0"; }
        }
        private void bindIAGridSingle(int CompanyId, string search)
        {
            SqlCommand cmd = new SqlCommand("[GetIACmSingle] " + CompanyId + ",'" + search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dsr = new DataSet();
            DataTable dt = new DataTable();
            adp.Fill(dsr);
            dt = dsr.Tables[0];
            IAGrid.DataSource = dt;
            IAGrid.DataBind();

            DataTable dtt = dsr.Tables[1];
            if (dtt.Rows.Count > 0)
            {
                LbltotalCount.Text = dtt.Rows[0][0].ToString();

            }
            else
            { LbltotalCount.Text = "0"; }
        }
        private void bindIAGridZero(int CompanyId, string search)
        {
            SqlCommand cmd = new SqlCommand("[GetIACmZero] " + CompanyId + ",'" + search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dsr = new DataSet();
            DataTable dt = new DataTable();
            adp.Fill(dsr);
            dt = dsr.Tables[0];
            IAGrid.DataSource = dt;
            IAGrid.DataBind();

            DataTable dtt = dsr.Tables[1];
            if (dtt.Rows.Count > 0)
            {
                LbltotalCount.Text = dtt.Rows[0][0].ToString();

            }
            else
            { LbltotalCount.Text = "0"; }
        }
        private void bindIAGridSearch(string search)
        {
            SqlCommand cmd = new SqlCommand("[GetIACmSearch] '" + search + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dsr = new DataSet();
            DataTable dt = new DataTable();
            adp.Fill(dsr);
            dt = dsr.Tables[0];
            IAGrid.DataSource = dt;
            IAGrid.DataBind();

            DataTable dtt = dsr.Tables[1];
            if (dtt.Rows.Count > 0)
            {
                LbltotalCount.Text = dtt.Rows[0][0].ToString();

            }
            else
            { LbltotalCount.Text = "0"; }
        }

        private void bindddl()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("[GetCorporation] '" + UserName + "'," + CompanyId + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dlAuthority.DataSource = dt;
                dlAuthority.DataTextField = "AuthortyName";
                dlAuthority.DataValueField = "id";
                dlAuthority.DataBind();
                dlAuthority.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void bindlregion(int id)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("[GetRegion] " + id + "", con);
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


        protected void IARateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IAGrid.PageIndex = e.NewPageIndex;
            if (UserName == "Admin")
            {
                if (dlAuthority.SelectedIndex == 0)
                {
                    bindIAGridSingle(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim());
                }
                else
                {
                    bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim(), dlregion.SelectedValue.Trim());
                }
            }
            else
            {
                bindIAGrid(CompanyId, txtSearch.Text.Trim());
            }
        }
        protected void IARateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                int rowid = Convert.ToInt32(e.CommandArgument);
                SqlCommand cmd = new SqlCommand("[GetExistingIA] " + rowid + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    Div2.Visible = false;
                    dropdownDiv.Visible = true;
                    dlAuthority.SelectedValue = dt.Rows[0]["CorporationID"].ToString();
                    dlAuthority_SelectedIndexChanged(null, null);
                    dlregion.SelectedValue = dt.Rows[0]["RegionalOffice"].ToString().Trim();
                    dlregion_SelectedIndexChanged(null, null);
                    txtTotalArea.Text = dt.Rows[0]["TotalIASize"].ToString();
                    Label10.Text = dt.Rows[0]["Id"].ToString();
                    txtIAName.Text = dt.Rows[0]["IAName"].ToString();
                    txtResidentialArea.Text = dt.Rows[0]["TotalResidentialArea"].ToString();
                    txtIndustrialArea.Text = dt.Rows[0]["TotalIndustrialArea"].ToString();
                    txtFacilities.Text = dt.Rows[0]["TotalFacilitiesArea"].ToString();
                    txtGreenZone.Text = dt.Rows[0]["TotalGreenZoneArea"].ToString();
                    txtCommercial.Text = dt.Rows[0]["TotalCommercialArea"].ToString();
                    txtInstitutional.Text = dt.Rows[0]["TotalInstitutionalArea"].ToString();
                    txtRate.Text = dt.Rows[0]["Rate"].ToString();
                    txtMixLand.Text = dt.Rows[0]["TotalMixArea"].ToString();
                }
                else
                {
                    Label10.Text = "";
                    txtIAName.Text = "";
                    txtRegionalOffice.Text = ""; txtTotalArea.Text = "";
                    txtResidentialArea.Text = "";
                    txtIndustrialArea.Text = "";
                    txtFacilities.Text = "";
                    txtGreenZone.Text = "";
                    txtCommercial.Text = "";
                    txtRate.Text = "";
                    txtMixLand.Text = "";

                }

            }

            if (e.CommandName == "DeleteRate")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });


                string rowid = commandArgs[0];


                string error = "";
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                command.Connection = con;
                command.Transaction = transaction;
                bool transactionResult = true;
                try
                {




                    command = new SqlCommand(@"[DeleteIAForCM_sp]", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", rowid);

                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));



                    if (transactionResult)
                    {
                        transaction.Commit();
                        string message = "Industrial Area Deleted Successfully.";
                        MessageBox1.ShowSuccess(message);

                        if (UserName == "Admin")
                        {
                            //if (Div2.Visible == true)
                            //{ dlAuthority_SelectedIndexChanged(null, null); }
                            //else
                            //{
                            //    bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim(), dlregion.SelectedValue.Trim());
                            //}
                            dlAuthority_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            //if (Div2.Visible == true)
                            //{
                            //    dlAuthority_SelectedIndexChanged(null, null);
                            //}
                            //else
                            //{
                            //    bindIAGrid(CompanyId, txtSearch.Text.Trim());
                            //}
                            dlAuthority_SelectedIndexChanged(null, null);
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


        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnSubmit_Click(null, null);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (UserName == "Admin")
            {
                //if(dlAuthority.SelectedIndex==0)
                //{
                //    bindIAGridSingle(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim());
                //}
                //else {
                //    bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), txtSearch.Text.Trim(),dlregion.SelectedValue.Trim());
                //}
                bindIAGridSearch(txtSearch.Text.Trim());
            }
            else { bindIAGrid(CompanyId, txtSearch.Text.Trim()); }

        }


        public void reset()
        {
            txtIAName.Text = "";
            txtRegionalOffice.Text = "";
            Label10.Text = "";
            txtTotalArea.Text = "";
            Div2.Visible = false;
            dropdownDiv.Visible = true;
            txtResidentialArea.Text = "";
            txtIndustrialArea.Text = "";
            txtFacilities.Text = "";
            txtGreenZone.Text = "";
            txtCommercial.Text = "";
            txtSearch.Text = "";
            txtInstitutional.Text = "";
            txtRate.Text = "";
            txtMixLand.Text = "";


        }

        protected void dlAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();

            bindlregion(Convert.ToInt32(dlAuthority.SelectedValue.Trim()));
            if (dlregion.SelectedIndex == 0)
            { bindIAGridZero(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), ""); }
            else { bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), "", dlregion.SelectedValue.Trim()); }


        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            reset();
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            Div2.Visible = true;
            dropdownDiv.Visible = false;
            Label10.Text = "";
            txtTotalArea.Text = "";
            txtIAName.Text = "";
            txtResidentialArea.Text = "";
            txtIndustrialArea.Text = "";
            txtFacilities.Text = "";
            txtGreenZone.Text = "";
            txtInstitutional.Text = "";
            txtCommercial.Text = "";
            txtRate.Text = "";
            txtMixLand.Text = "";
        }

        protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();

            bindIAGridAdmin(Convert.ToInt32(dlAuthority.SelectedValue.Trim()), "", dlregion.SelectedValue.Trim());
        }


    }

}






