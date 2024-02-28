using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UserRoleMapping : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Wizard1.PreRender += new EventHandler(Wizard1_PreRender);   

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            txteffectiveFrom.Attributes.Add("readonly", "readonly");
            txteffectiveTo.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                check_user();
                rowidlbl.Text = "0";
                bind_region_list();
                // Listbox1.SelectedIndex = 0;
                // Listbox1_SelectedIndexChanged(null, null);
                bind_user_list();
                bind_servicetimeline_list();
                bind_User_Role_list();
                BindUserAssociationGrid();
                txteffectiveFrom.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            }



        }

        private void check_user()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            SqlCommand cmd = new SqlCommand("Select level from UserAssociationMaster where UserName='" + _objLoginInfo.userName.Trim() + "' ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string asdf_role = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Level"].ToString().Trim() == "RM" || dt.Rows[i]["Level"].ToString().Trim() == "Admin1")
                    {
                        asdf_role = "RM";
                    }
                }

                if (asdf_role != "RM")
                {
                    Response.Redirect("DashboardI.aspx");
                }

            }
            else
            {
                Response.Redirect("DashboardI.aspx");

            }


        }


        private void bind_region_list()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.Parameter = "";
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                dsR = objServiceTimelinesBLL.GetRegionalOffice(objServiceTimelinesBEL);
                Listbox1.DataSource = dsR;
                Listbox1.DataTextField = "a";
                Listbox1.DataValueField = "b";
                Listbox1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



                SqlCommand cmd = new SqlCommand("Select distinct Id,IAName from IndustrialArea where RegionalOffice='" + Listbox1.SelectedValue.Trim() + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                Listbox2.DataSource = dt;
                Listbox2.DataTextField = "IAName";
                Listbox2.DataValueField = "Id";

                Listbox2.DataBind();
                if (dt.Rows.Count > 0)
                {
                    Listbox2.Items.Insert(0, new ListItem("--All--", "0"));
                }

                Listbox5.SelectedIndex = -1;

                lblSelectedRole.Text = "";
                Selection();
                get_prev_service();
            }
            catch (Exception ex)
            {

                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();

                Response.Write("Oops! error occured : Line :" + line + "|Col :" + col + "|Method : " + methodName + "|File : " + fileName);

            }

        }

        private void bind_user_list()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];


            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.Parameter = txtSearchh.Text.Trim();
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                dsR = objServiceTimelinesBLL.SearchInternalUser(objServiceTimelinesBEL);
                Listbox3.DataSource = dsR;
                Listbox3.DataTextField = "UserName";
                Listbox3.DataValueField = "UserID";
                Listbox3.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }



        }

        private void BindIA()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Select distinct Id,IAName from IndustrialArea where RegionalOffice='" + Listbox1.SelectedValue.Trim() + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                Listbox2.DataSource = dt;
                Listbox2.DataTextField = "IAName";
                Listbox2.DataValueField = "Id";

                Listbox2.DataBind();
                if (dt.Rows.Count > 0)
                {
                    Listbox2.Items.Insert(0, new ListItem("--All--", "0"));
                }
              
            }

            catch (Exception ex)
            {

                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();

                Response.Write("Oops! error occured : Line :" + line + "|Col :" + col + "|Method : " + methodName + "|File : " + fileName);

            }
        }



        protected void Listbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (Listbox2.SelectedIndex == 0)
                {
                    for (int i = 1; i < Listbox2.Items.Count; i++)
                    {

                        ListItem li = Listbox2.Items[i];
                        li.Selected = true;

                    }
                    ListItem lii = Listbox2.Items[0];
                    lii.Selected = false;
                }
                Selection();

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void bind_servicetimeline_list()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetUserServiceTimelineList", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                Listbox5.DataSource = dt;
                Listbox5.DataTextField = "ServiceTimeLinesActivity";
                Listbox5.DataValueField = "ServiceTimeLinesID";
                Listbox5.DataBind();
                Listbox5.Items.Insert(0, new ListItem("--All--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bind_User_Role_list()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[GetUserRoleList]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                Listbox4.DataSource = dt;
                Listbox4.DataTextField = "Name";
                Listbox4.DataValueField = "Role";
                Listbox4.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void Listbox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (Listbox5.SelectedIndex == 0)
                {
                    for (int i = 1; i < Listbox5.Items.Count; i++)
                    {

                        ListItem li = Listbox5.Items[i];
                        li.Selected = true;

                    }
                    ListItem lii = Listbox5.Items[0];
                    lii.Selected = false;
                }
                Selection();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        private void Selection()
        {
            try
            {



                lblSelectedRegOffice.Text = "";
                lblSelectedUser.Text = "";
                lblSelectedIA.Text = "";
                lblSelectedServices.Text = "";
                for (int i = 0; i < Listbox1.Items.Count; i++)
                {
                    if (Listbox1.Items[i].Selected)
                    {
                        lblSelectedRegOffice.Text += ">" + Listbox1.Items[i].Text + "<br/>";
                    }
                }
                for (int j = 0; j < Listbox3.Items.Count; j++)
                {
                    if (Listbox3.Items[j].Selected)
                    {
                        lblSelectedUser.Text += ">" + Listbox3.Items[j].Text + "<br/>";
                    }
                }
                for (int k = 0; k < Listbox2.Items.Count; k++)
                {
                    if (Listbox2.Items[k].Selected)
                    {
                        lblSelectedIA.Text += ">" + Listbox2.Items[k].Text + "<br/>";
                    }
                }
                for (int l = 0; l < Listbox5.Items.Count; l++)
                {
                    if (Listbox5.Items[l].Selected)
                    {
                        lblSelectedServices.Text += ">" + Listbox5.Items[l].Text + "<br/>";
                    }
                }
                for (int m = 0; m < Listbox4.Items.Count; m++)
                {
                    if (Listbox4.Items[m].Selected)
                    {

                        lblSelectedRole.Text = ">" + Listbox4.SelectedItem.Text.Trim();
                    }
                }
                for (int n = 0; n < Listbox9.Items.Count; n++)
                {
                    if (Listbox9.Items[n].Selected)
                    {

                        lblselectedtype.Text = "--->" + Listbox9.SelectedItem.Text.Trim();
                    }
                }
                for (int o = 0; o < Listbox6.Items.Count; o++)
                {
                    if (Listbox6.Items[o].Selected)
                    {

                        lblDataManager.Text = "--->" + Listbox6.SelectedItem.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void Listbox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Listbox5.SelectedIndex = -1;

                lblSelectedRole.Text = "";
                Listbox1.SelectedIndex = -1;
                Listbox1_SelectedIndexChanged(null, null);
                Listbox4.SelectedIndex = -1;
                Listbox9.SelectedIndex = -1;

                Selection();
                get_prev_service();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }



        protected void btnNewAss_Click(object sender, EventArgs e)
        {




            string column1 = string.Empty;
            string level = string.Empty;
            string role = string.Empty;
            string listBox1Values = string.Empty;
            string listBox2Values = string.Empty;
            string column2 = string.Empty;
            string column3 = string.Empty;

            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {

                foreach (ListItem item in this.Listbox2.Items)
                {
                    if (item.Selected)
                    {
                        listBox1Values = listBox1Values + item.Value + ",";
                    }

                }

                if (!string.IsNullOrEmpty(listBox1Values))
                {
                    column2 = listBox1Values.Remove(listBox1Values.LastIndexOf(","));
                }
                foreach (ListItem item1 in this.Listbox5.Items)
                {
                    if (item1.Selected)
                    {
                        listBox2Values = listBox2Values + item1.Value + ",";
                    }

                }

                if (!string.IsNullOrEmpty(listBox2Values))
                {
                    column3 = listBox2Values.Remove(listBox2Values.LastIndexOf(","));
                }





                if (Listbox3.SelectedIndex == -1)
                {
                    MessageBox1.ShowWarning("Please Select User");
                    return;
                }
                else
                {

                    if (Listbox2.SelectedIndex == -1)
                    {
                        MessageBox1.ShowWarning("Please Select Industrial Area");
                        return;
                    }
                    else
                    {

                        if (Listbox4.SelectedIndex == -1)
                        {
                            MessageBox1.ShowWarning("Please Select Role");
                            return;
                        }
                        else
                        {
                            if (Listbox9.SelectedIndex == -1)
                            {
                                MessageBox1.ShowWarning("Please Select Type");
                                return;
                            }
                            else
                            {
                                if (btnSet.Text == "Submit")
                                {

                                    command.CommandText = ("InsertUserAssociation_sp " + Listbox3.SelectedValue.Trim() + ",'" + Listbox3.SelectedItem.Text.Trim() + "','" + Listbox1.SelectedValue.Trim() + "','" + column2.Trim() + "','" + column3.Trim() + "','" + Listbox4.SelectedValue.Trim() + "','" + Listbox9.SelectedValue.Trim() + "','" + txteffectiveFrom.Text.Trim() + "','" + txteffectiveTo.Text.Trim() + "'," + Convert.ToInt32(rowidlbl.Text.Trim()) + ",'I','" + Listbox6.SelectedValue.Trim() + "'");
                                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));


                                }
                                else if (btnSet.Text == "Update")
                                {
                                    command.CommandText = ("InsertUserAssociation_sp " + Listbox3.SelectedValue.Trim() + ",'" + Listbox3.SelectedItem.Text.Trim() + "','" + Listbox1.SelectedValue.Trim() + "','" + column2.Trim() + "','" + column3.Trim() + "','" + Listbox4.SelectedValue.Trim() + "','" + Listbox9.SelectedValue.Trim() + "','" + txteffectiveFrom.Text.Trim() + "','" + txteffectiveTo.Text.Trim() + "'," + Convert.ToInt32(rowidlbl.Text.Trim()) + ",'U','" + Listbox6.SelectedValue.Trim() + "'");
                                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                                }
                            }
                        }
                    }
                }





                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Services Associated successfully");
                    reset();
                    BindUserAssociationGrid();

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


        private void BindUserAssociationGrid()
        {
            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                string SearchString = txtSearch.Text;
                SqlCommand cmd = new SqlCommand("GetUserAssociationDetail_sp '" + _objLoginInfo.userName + "','" + SearchString + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                userAssociationGrid.DataSource = dt;
                userAssociationGrid.DataBind();

                ViewState["userAssociation"] = dt; ViewState["sortdr"] = "Asc";  //con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void userAssociationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rowidlbl.Text = "0";
            if (e.CommandName == "Process")
            {
                txtSearchh.Text = "";
                bind_user_list();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

                int rowid = Convert.ToInt32(commandArgs[0]);





                string userid = commandArgs[1];
                rowidlbl.Text = rowid.ToString();
                string region = commandArgs[2].Trim();

                Listbox3.SelectedValue = userid;
                Listbox3_SelectedIndexChanged(null, null);
                Listbox1.SelectedIndex = -1;


                Listbox1.Items.FindByValue(region).Selected = true;


                get_prev_service();



                //string iaID = commandArgs[3];


                //string[] strArr1 = iaID.Split(',');
                //Listbox2.SelectedIndex = -1;
                //for (int i = 0; i < strArr1.Length; i++)
                //{
                //    Listbox2.Items.FindByValue(strArr1[i].Trim()).Selected = true;
                //}
                ////  Listbox2_SelectedIndexChanged(null, null);
                //string ServicesId = commandArgs[4];
                //string[] strArr = ServicesId.Split(',');
                //Listbox5.SelectedIndex = -1;
                //if (ServicesId == "")
                //{

                //}
                //else
                //{

                //    for (int i = 0; i < strArr.Length; i++)
                //    {
                //        Listbox5.Items.FindByValue(strArr[i]).Selected = true;
                //    }
                //}
                ////  Listbox5_SelectedIndexChanged(null, null);
                //string Level = commandArgs[5];
                //string Role = commandArgs[6];
                //string DataManager = commandArgs[7];
                //Listbox4.SelectedIndex = -1;
                //Listbox4.Items.FindByValue(Level).Selected = true;
                //Listbox9.SelectedIndex = -1;
                //Listbox9.Items.FindByValue(Role).Selected = true;
                //if (DataManager == "" || DataManager == null)
                //{
                //    Listbox6.SelectedIndex = -1;
                //}
                //else
                //{
                //    Listbox6.Items.FindByValue(DataManager).Selected = true;
                //}
                //Selection();
                btnSet.Text = "Update";
                prev1.Visible = true;
                prev2.Visible = true;
                txteffectiveTo.Text = DateTime.Now.AddMinutes(-1).ToString("dd-MMM-yyyy hh:mm:ss tt");


            }
            if (e.CommandName == "DeleteUser")
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
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '/' });

                    int rowid = Convert.ToInt32(commandArgs[0]);


                    command.CommandText = ("[DeleteUserAssociation_sp] " + rowid + "");
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                    if (transactionResult)
                    {
                        transaction.Commit();
                        MessageBox1.ShowSuccess("User Deleted successfully");
                        reset();
                        BindUserAssociationGrid();

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
        private void RegisterPostBackControl()
        {

            foreach (GridViewRow row in userAssociationGrid.Rows)
            {
                LinkButton lnkFull = row.FindControl("btnEdit") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);


            }
        }
        private void get_prev_service()
        {
            try
            {


                string column1 = string.Empty;
                string level = string.Empty;
                string role = string.Empty;
                string listBox1Values = string.Empty;
                string listBox2Values = string.Empty;
                string column2 = string.Empty;
                string column3 = string.Empty;

                if (Listbox3.SelectedIndex == -1)
                {
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Select *,rtrim(ltrim(RegionalOffice)) 'RegionalOffice1' from UserAssociationMaster where userId='" + Listbox3.SelectedValue.Trim() + "' and RegionalOffice='" + Listbox1.SelectedValue.Trim() + "'   and ActiveStatus=1", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        rowidlbl.Text = "0";
                        rowidlbl.Text = dt.Rows[0]["id"].ToString();
                        MessageBox1.ShowInfo("Previous Services Exist");
                        prev1.Visible = true;
                        prev2.Visible = true;
                        txteffectiveTo.Text = DateTime.Now.AddMinutes(-1).ToString("dd-MMM-yyyy hh:mm:ss tt");
                        string region1 = dt.Rows[0]["RegionalOffice1"].ToString().Trim();
                        Listbox1.SelectedIndex = -1;
                        if (region1 == "FAIZABAD REGION")
                        {
                            Listbox1.SelectedIndex = 4;
                        }
                        else
                        {
                            Listbox1.Items.FindByValue(region1).Selected = true;
                        }
                        BindIA();
                        string ia = dt.Rows[0]["IndustrialArea"].ToString();
                        string[] strArr1 = ia.Split(',');
                        Listbox2.SelectedIndex = -1;

                        for (int i = 0; i < strArr1.Length; i++)
                        {
                            Listbox2.Items.FindByValue(strArr1[i].Trim()).Selected = true;
                        }

                        Listbox2_SelectedIndexChanged(null, null);
                        string services = dt.Rows[0]["Services"].ToString();
                        string[] strArr = services.Split(',');
                        Listbox5.SelectedIndex = -1;
                        if (services == "")
                        {

                        }
                        else
                        {
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                Listbox5.Items.FindByValue(strArr[i]).Selected = true;
                            }
                        }
                        // Listbox5_SelectedIndexChanged(null, null);
                        string Level = dt.Rows[0]["Level"].ToString();
                        string Role = dt.Rows[0]["Role"].ToString();
                        string DataManager = dt.Rows[0]["DataManager"].ToString();
                        Listbox4.SelectedIndex = -1;
                        Listbox4.Items.FindByValue(Level).Selected = true;
                        Listbox9.SelectedIndex = -1;
                        Listbox9.Items.FindByValue(Role).Selected = true;
                        if (DataManager == "" || DataManager == null)
                        {
                            Listbox6.SelectedIndex = -1;
                        }
                        else
                        {
                            Listbox6.Items.FindByValue(DataManager).Selected = true;
                        }
                        Selection();
                        btnSet.Text = "Update";


                    }
                    else
                    {
                        Listbox5.SelectedIndex = -1;

                        lblSelectedRole.Text = "";
                        rowidlbl.Text = "0";
                        btnSet.Text = "Submit";
                        prev1.Visible = false;
                        prev2.Visible = false;

                        Selection();
                    }



                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void reset()
        {
            Listbox3.SelectedIndex = -1;
            Listbox1.SelectedIndex = -1;
            Listbox2.SelectedIndex = -1;
            Listbox5.SelectedIndex = -1;
            Listbox4.SelectedIndex = -1;
            Listbox9.SelectedIndex = -1;
            Listbox6.SelectedIndex = -1;

            lblSelectedRole.Text = "";
            lblselectedtype.Text = "";
            Listbox1_SelectedIndexChanged(null, null);
            lblDataManager.Text = "";
            prev1.Visible = false;
            prev2.Visible = false;
            txteffectiveTo.Text = "";
            rowidlbl.Text = "0";
            btnSet.Text = "Submit";



        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void txteffectiveFrom_TextChanged(object sender, EventArgs e)
        {
            txteffectiveFrom.Text = txteffectiveFrom.Text.Trim() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }
        protected void txteffectiveTo_TextChanged(object sender, EventArgs e)
        {
            txteffectiveTo.Text = txteffectiveTo.Text.Trim() + " " + DateTime.Now.AddMinutes(-1).ToString("hh:mm:ss tt");
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            userAssociationGrid.PageIndex = e.NewPageIndex;
            BindUserAssociationGrid();

        }


        protected void userAssociationGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["userAssociation"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }

                userAssociationGrid.DataSource = dtrslt;
                userAssociationGrid.DataBind();
            }
        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindUserAssociationGrid();
        }

        protected void txtSearchh_TextChanged(object sender, EventArgs e)
        {

            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.Parameter = txtSearchh.Text.Trim();
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                dsR = objServiceTimelinesBLL.SearchInternalUser(objServiceTimelinesBEL);
                Listbox3.DataSource = dsR;
                Listbox3.DataTextField = "UserName";
                Listbox3.DataValueField = "UserID";
                Listbox3.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void txtSearchRegion_TextChanged(object sender, EventArgs e)
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.Parameter = txtSearchRegion.Text.Trim();
                objServiceTimelinesBEL.UserName = _objLoginInfo.userName;
                dsR = objServiceTimelinesBLL.GetRegionalOffice(objServiceTimelinesBEL);
                Listbox1.DataSource = dsR;
                Listbox1.DataTextField = "a";
                Listbox1.DataValueField = "b";
                Listbox1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void txtSearchIA_TextChanged(object sender, EventArgs e)
        {
            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.Region = Listbox1.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Parameter = txtSearchIA.Text.Trim();
                dsR = objServiceTimelinesBLL.GetIndustrialAreaDetailRegWise(objServiceTimelinesBEL);
                Listbox2.DataSource = dsR;
                Listbox2.DataTextField = "IAName";
                Listbox2.DataValueField = "Id";
                Listbox2.DataBind();
                if (dsR.Tables.Count > 0)
                {
                    Listbox2.Items.Insert(0, new ListItem("--All--", "0"));
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Listbox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selection();
        }

        protected void Listbox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selection();
        }

        protected void save_ServerClick(object sender, EventArgs e)
        {
            btnNewAss_Click(null, null);
        }
        protected void reset_ServerClick(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
        }

        protected void Listbox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selection();
        }
    }





}






