using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Net.Mail;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;


namespace Allotment
{
    public partial class NewAllootteeRegistration : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();
                bindCompanytypeddl();



                DataTable temp_shareholder_details = new DataTable();
                //      SELECT temp_no, dealer_code, doc_year, job_card_no, part_type, part_code, part_no, part_rev_no, part_desc, req_no, req_date, quantity, rate, sales_tax_pcnt, reason_for_warranty FROM temp_job_material_detail
                temp_shareholder_details.TableName = "temp_shareholder_details";
                temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("phone", typeof(string)));



                ViewState["temp_shareholder_details"] = temp_shareholder_details;
                temp_shareholder_details_DataBind();


                DataTable temp_trustee_details = new DataTable();
                //      SELECT temp_no, dealer_code, doc_year, job_card_no, part_type, part_code, part_no, part_rev_no, part_desc, req_no, req_date, quantity, rate, sales_tax_pcnt, reason_for_warranty FROM temp_job_material_detail
                temp_trustee_details.TableName = "temp_trustee_details";
                temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("TAddress", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("TEmail", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Tphone", typeof(string)));



                ViewState["temp_trustee_details"] = temp_trustee_details;
                temp_trustee_details_DataBind();


                DataTable temp_directors_details = new DataTable();
                //      SELECT temp_no, dealer_code, doc_year, job_card_no, part_type, part_code, part_no, part_rev_no, part_desc, req_no, req_date, quantity, rate, sales_tax_pcnt, reason_for_warranty FROM temp_job_material_detail
                temp_directors_details.TableName = "temp_directors_details";
                temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("DAddress", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("DEmail", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Dphone", typeof(string)));



                ViewState["temp_directors_details"] = temp_directors_details;
                temp_director_details_DataBind();


                DataTable temp_partnership_details = new DataTable();
                temp_partnership_details.TableName = "temp_partnership_details";
                temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                temp_partnership_details.Columns.Add(new DataColumn("ParAddress", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("ParEmail", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("ParPhone", typeof(string)));



                ViewState["temp_partnership_details"] = temp_partnership_details;
                temp_partnership_details_DataBind();

            }
        }

        public void temp_shareholder_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
                gridshareholder.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
            }


        }
        public void temp_partnership_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
                PartnershipFirmGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
            }


        }

        public void temp_trustee_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
                Trustee_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
            }


        }

        public void temp_director_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
                DirectorsGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
            }


        }


        protected void insert_shareholder_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];


            string shareholdername = (gridshareholder.FooterRow.FindControl("txtShareholderName_insert") as TextBox).Text;
            string shareper = (gridshareholder.FooterRow.FindControl("txtShareper_insert") as TextBox).Text;
            string address = (gridshareholder.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string email = (gridshareholder.FooterRow.FindControl("txtEmail_insert") as TextBox).Text;
            string phone = (gridshareholder.FooterRow.FindControl("txtPhone_insert") as TextBox).Text;


            if (shareholdername != "")
            {
                if (shareper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ShareHolderName"] = shareholdername;
                    dr["SharePer"] = shareper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_shareholder_details"] = dt;

                    temp_shareholder_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide ShareHolder Name');", true);
                return;
            }

        }

        protected void insert_Partnership_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];


            string Partnershipname = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert") as TextBox).Text;
            string partnershipper = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert") as TextBox).Text;
            string address = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert") as TextBox).Text;
            string email = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert") as TextBox).Text;
            string phone = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert") as TextBox).Text;


            if (Partnershipname != "")
            {
                if (partnershipper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["PartnerName"] = Partnershipname;
                    dr["PartnershipPer"] = partnershipper;
                    dr["ParAddress"] = address;
                    dr["ParEmail"] = email;
                    dr["ParPhone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_partnership_details"] = dt;

                    temp_partnership_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
                return;
            }

        }



        protected void insert_trustee_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];


            string trusteename = (Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert") as TextBox).Text;
            string address = (Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert") as TextBox).Text;
            string email = (Trustee_details_grid.FooterRow.FindControl("txtTEmail_insert") as TextBox).Text;
            string phone = (Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert") as TextBox).Text;


            if (trusteename != "")
            {


                DataRow dr = dt.NewRow();
                dr["TrusteeName"] = trusteename;
                dr["TAddress"] = address;
                dr["TEmail"] = email;
                dr["Tphone"] = phone;

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_trustee_details"] = dt;

                temp_trustee_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Trustee Name');", true);
                return;
            }

        }



        protected void insert_Director_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];


            string Directorname = (DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert") as TextBox).Text;
            string din_pan = (DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert") as TextBox).Text;
            string address = (DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert") as TextBox).Text;
            string phone = (DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert") as TextBox).Text;
            string email = (DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert") as TextBox).Text;


            if (Directorname != "")
            {
                if (din_pan != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["DirectorName"] = Directorname;
                    dr["Din_Pan"] = din_pan;
                    dr["DAddress"] = address;
                    dr["DEmail"] = email;
                    dr["Dphone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_directors_details"] = dt;

                    temp_director_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Din/Pan');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Director Name');", true);
                return;
            }

        }







        protected void ShareHolderDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_shareholder_details"] = dt;

            dt.AcceptChanges();


            temp_shareholder_details_DataBind();


        }
        protected void PartnershipDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_partnership_details"] = dt;

            dt.AcceptChanges();


            temp_partnership_details_DataBind();


        }
        protected void TrusteeDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_trustee_details"] = dt;

            dt.AcceptChanges();


            temp_trustee_details_DataBind();


        }

        protected void DirectorDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_directors_details"] = dt;

            dt.AcceptChanges();


            temp_director_details_DataBind();


        }

        private void bindIndustrialAreaDetail()
        {
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                ddlArea.DataSource = ds;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
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

        private void bindCompanytypeddl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompanyType();
                ddlcompanytype.DataSource = ds;
                ddlcompanytype.DataTextField = "company_type";
                ddlcompanytype.DataValueField = "id";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;

                txtCinNo.Enabled = false;


            }

            if (ddlcompanytype.SelectedValue == "1")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = true;
                tr6.Visible = true;
                tr7.Visible = true;
                tr8.Visible = false;
                tr9.Visible = false;


                txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietorship firm name<br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;

                txtCinNo.Enabled = true;
                tr9.Visible = false;

            }
            if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;

                txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "4")
            {

                tr2.Visible = false;
                tr4.Visible = true;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;



                txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "5")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = true;

                txtCinNo.Enabled = true;


            }

        }



        protected void checkbox2_checked_changed(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                txtAuthorisedSignatory.Text = txtIndividualName.Text;
                txtSignatoryAddress.Text = txtIndividualAddress.Text;
                txtSignatoryPhone.Text = txtIndividualPhone.Text;
                txtSignatoryEmail.Text = txtIndividualEmail.Text;
            }
            else
            {
                txtAuthorisedSignatory.Text = "";
                txtSignatoryAddress.Text = ""; ;
                txtSignatoryPhone.Text = "";
                txtSignatoryEmail.Text = "";
            }
        }



        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void ResetControl()
        {

            ddlArea.SelectedIndex = 0;
            txtAllotment.Text = "";
            txtPlotNo.Text = "";
            txtFileNo.Text = "";
            txtCompanyname.Text = "";
            ddlcompanytype.SelectedIndex = 0;
            txtAuthorisedSignatory.Text = "";
            txtSignatoryAddress.Text = "";
            txtSignatoryEmail.Text = "";
            txtSignatoryPhone.Text = "";
            txtIndividualName.Text = "";
            txtIndividualAddress.Text = "";
            txtIndividualPhone.Text = "";
            txtIndividualEmail.Text = "";
            txtPanNo.Text = "";
            txtCinNo.Text = "";
            tr2.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            tr9.Visible = false;

            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            dt.Rows.Clear();
            ViewState["temp_trustee_details"] = dt;
            temp_trustee_details_DataBind();
            DataTable dt1 = (DataTable)ViewState["temp_shareholder_details"];
            dt1.Rows.Clear();
            ViewState["temp_shareholder_details"] = dt1;
            temp_shareholder_details_DataBind();

            DataTable dt2 = (DataTable)ViewState["temp_directors_details"];
            dt2.Rows.Clear();
            ViewState["temp_directors_details"] = dt2;
            temp_director_details_DataBind();

            DataTable dt3 = (DataTable)ViewState["temp_partnership_details"];
            dt3.Rows.Clear();
            ViewState["temp_partnership_details"] = dt3;
            temp_partnership_details_DataBind();

        }
        #region Save Record




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

                if (ddlArea.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Select Industrial Area First');", true);
                    return;
                }
                if (ddlcompanytype.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Select Firm Constitution First');", true);
                    return;
                }



                SqlCommand cmd2 = new SqlCommand("select * from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adp1.Fill(dt);
                if (dt.Rows.Count <= 0)
                {

                    if (ddlcompanytype.SelectedIndex == 1)
                    {
                        command.CommandText = ("NewRegistrationRequestAllottee_sp '" + txtAllotment.Text.Trim() + "','" + txtIndividualName.Text.Trim() + "','" + txtIndividualEmail.Text.Trim() + "','" + txtIndividualPhone.Text.Trim() + "','" + txtPlotNo.Text.Trim() + "','" + ddlArea.SelectedItem.Text.Trim() + "','" + txtIndividualAddress.Text.Trim() + "','" + System.Environment.MachineName + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtCompanyname.Text.Trim() + "','" + ddlcompanytype.SelectedValue.Trim() + "','" + txtFileNo.Text.Trim() + "','" + txtPanNo.Text.Trim() + "','" + txtCinNo.Text.Trim() + "'");
                        command.ExecuteNonQuery();
                        SqlCommand cmd = new SqlCommand("select AllotteeID from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                        SqlDataAdapter adpp = new SqlDataAdapter(cmd);
                        DataTable prc = new DataTable();
                        adpp.Fill(prc);
                        lblAllotteeID.Text = prc.Rows[0][0].ToString();

                    }

                    if (ddlcompanytype.SelectedIndex == 2)
                    {
                        command.CommandText = ("NewRegistrationRequestAllottee_sp '" + txtAllotment.Text.Trim() + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtPlotNo.Text.Trim() + "','" + ddlArea.SelectedItem.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + System.Environment.MachineName + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtCompanyname.Text.Trim() + "','" + ddlcompanytype.SelectedValue.Trim() + "','" + txtFileNo.Text.Trim() + "','" + txtPanNo.Text.Trim() + "','" + txtCinNo.Text.Trim() + "'");
                        command.ExecuteNonQuery();



                        SqlCommand cmd = new SqlCommand("select AllotteeID from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                        SqlDataAdapter adpp = new SqlDataAdapter(cmd);
                        DataTable prc = new DataTable();
                        adpp.Fill(prc);
                        lblAllotteeID.Text = prc.Rows[0][0].ToString();
                        DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                        if (temp.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in temp.Rows)
                            {
                                int alloteeid = Convert.ToInt32(prc.Rows[0][0].ToString());
                                lblAllotteeID.Text = prc.Rows[0][0].ToString();
                                string ShareholderName = dr1["ShareHolderName"].ToString();
                                decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                string Address = dr1["Address"].ToString();
                                string phone = dr1["phone"].ToString();
                                string email = dr1["Email"].ToString();



                                command.CommandText = ("insert into AllotteeTempShareHoldersDetail(AllotteeID, ShareholderName, Address, SharePer, PhoneNo, EmailId) values(" + alloteeid + ",'" + ShareholderName.Trim() + "','" + Address.Trim() + "'," + shareper + ",'" + phone + "','" + email + "')");
                                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                            }

                        }
                    }

                    if (ddlcompanytype.SelectedIndex == 3)
                    {

                        command.CommandText = ("NewRegistrationRequestAllottee_sp '" + txtAllotment.Text.Trim() + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtPlotNo.Text.Trim() + "','" + ddlArea.SelectedItem.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + System.Environment.MachineName + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtCompanyname.Text.Trim() + "','" + ddlcompanytype.SelectedValue.Trim() + "','" + txtFileNo.Text.Trim() + "','" + txtPanNo.Text.Trim() + "','" + txtCinNo.Text.Trim() + "'");
                        command.ExecuteNonQuery();



                        SqlCommand cmd3 = new SqlCommand("select AllotteeID from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                        SqlDataAdapter adpp2 = new SqlDataAdapter(cmd3);
                        DataTable prc2 = new DataTable();
                        adpp2.Fill(prc2);
                        lblAllotteeID.Text = prc2.Rows[0][0].ToString();
                        DataTable temp3 = (DataTable)ViewState["temp_directors_details"];
                        if (temp3.Rows.Count > 0)
                        {
                            foreach (DataRow dr3 in temp3.Rows)
                            {
                                int alloteeid = Convert.ToInt32(prc2.Rows[0][0].ToString());
                                string DirectorName = dr3["DirectorName"].ToString();
                                string din_pan = dr3["Din_Pan"].ToString();
                                string Address = dr3["DAddress"].ToString();
                                string phone = dr3["Dphone"].ToString();
                                string email = dr3["DEmail"].ToString();



                                command.CommandText = ("insert into AllotteeTempDirectorsDetail(AllotteeID, DirectorName, Address, DIN_PAN, Phone, EmailId) values(" + alloteeid + ",'" + DirectorName.Trim() + "','" + Address.Trim() + "','" + din_pan + "','" + phone + "','" + email + "')");
                                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                            }

                        }

                    }

                    if (ddlcompanytype.SelectedIndex == 4)
                    {

                        command.CommandText = ("NewRegistrationRequestAllottee_sp '" + txtAllotment.Text.Trim() + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtPlotNo.Text.Trim() + "','" + ddlArea.SelectedItem.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + System.Environment.MachineName + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtCompanyname.Text.Trim() + "','" + ddlcompanytype.SelectedValue.Trim() + "','" + txtFileNo.Text.Trim() + "','" + txtPanNo.Text.Trim() + "','" + txtCinNo.Text.Trim() + "'");
                        command.ExecuteNonQuery();

                        SqlCommand cmd1 = new SqlCommand("select AllotteeID from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                        DataTable prc1 = new DataTable();
                        adp.Fill(prc1);
                        lblAllotteeID.Text = prc1.Rows[0][0].ToString();

                        DataTable temp1 = (DataTable)ViewState["temp_trustee_details"];
                        if (temp1.Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in temp1.Rows)
                            {
                                int alloteeid = Convert.ToInt32(prc1.Rows[0][0].ToString());
                                string TrusteeName = dr2["TrusteeName"].ToString();
                                string Address = dr2["TAddress"].ToString();
                                string phone = dr2["Tphone"].ToString();
                                string email = dr2["TEmail"].ToString();

                                command.CommandText = ("insert into AllotteeTempTrusteeDetail(AllotteeID, TrusteeName, Address,Phone, EmailId) values(" + alloteeid + ",'" + TrusteeName.Trim() + "','" + Address.Trim() + "','" + phone + "','" + email + "')");
                                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                            }
                        }
                    }
                    if (ddlcompanytype.SelectedIndex == 5)
                    {
                        command.CommandText = ("NewRegistrationRequestAllottee_sp '" + txtAllotment.Text.Trim() + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtPlotNo.Text.Trim() + "','" + ddlArea.SelectedItem.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + System.Environment.MachineName + "','" + txtAuthorisedSignatory.Text.Trim() + "','" + txtSignatoryAddress.Text.Trim() + "','" + txtSignatoryPhone.Text.Trim() + "','" + txtSignatoryEmail.Text.Trim() + "','" + txtCompanyname.Text.Trim() + "','" + ddlcompanytype.SelectedValue.Trim() + "','" + txtFileNo.Text.Trim() + "','" + txtPanNo.Text.Trim() + "','" + txtCinNo.Text.Trim() + "'");
                        command.ExecuteNonQuery();



                        SqlCommand cmd = new SqlCommand("select AllotteeID from AllotteeTempRegister where AllotmentLetterNo='" + txtAllotment.Text.Trim() + "' ", con, transaction);
                        SqlDataAdapter adpp = new SqlDataAdapter(cmd);
                        DataTable prc = new DataTable();
                        adpp.Fill(prc);
                        lblAllotteeID.Text = prc.Rows[0][0].ToString();
                        DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                        if (temp.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in temp.Rows)
                            {
                                int alloteeid = Convert.ToInt32(prc.Rows[0][0].ToString());
                                string PartnerName = dr1["PartnerName"].ToString();
                                decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                string Address = dr1["ParAddress"].ToString();
                                string phone = dr1["ParPhone"].ToString();
                                string email = dr1["ParEmail"].ToString();



                                command.CommandText = ("insert into AllotteeTempPartnershipDetail(AllotteeID, PartnerName, Address, PartnershipPer, PhoneNo, EmailId) values(" + alloteeid + ",'" + PartnerName.Trim() + "','" + Address.Trim() + "'," + Partnershipper + ",'" + phone + "','" + email + "')");
                                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                            }

                        }
                    }


                    if (transactionResult)
                    {
                        transaction.Commit();
                        //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Recorded Inserted Succesfully');", true);
                        send_mail(txtAuthorisedSignatory.Text.Trim(), txtSignatoryEmail.Text.Trim(), lblAllotteeID.Text.Trim());
                    }
                    else
                    {
                        transaction.Rollback();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Error');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Allottment Letter No Already Exist');", true);
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

        private void send_mail(string name, string mailid, string AllotteeId)
        {
            try
            {
              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(mailid);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);


                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/AcknowledgeMent.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", name);
                // StrContent = StrContent.Replace("{Title}", "UPSIDCeServe: Acknowledgement-Request to register for eService");
                StrContent = StrContent.Replace("{Description}", "Thank You for Signing with us! </br> We value your relationship with UPSIDC. Our team will verify your request and activate your eService account soon. You will shortly receive an email with the credentials to login to the system at your shared email with us.<br/>Please be informed that the shared email and phone no would be your registered email ID and Phone no for any further communication.<br/><br/>We respect your patronage with us. ");
                newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for eService ";
                //  newmsg.Body = "Thank You for Signing with us! </br> We value your relationship with UPSIDC. Our team will verify your request and a mail regarding your credentials will be shared to your email Address soon </br>This service comes to you FREE of cost and is yet another measure in our constant endeavour to enhance customer-convenience.";

                // newmsg.Body = "We value your relationship with UPSIDC and are pleased to inform you that now you can have your UPSIDC account information at your fingertips.</br>This service comes to you FREE of cost and is yet another measure in our constant endeavour to enhance customer-convenience.";
                newmsg.BodyHtml = StrContent;
               // newmsg.IsBodyHtml = true;
                //For File Attachment, more file can also be attached
                //Attachment att = new Attachment("");
                //newmsg.Attachments.Add(att);

                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                //smtp.EnableSsl = true;
                //smtp.Send(newmsg);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // string message = "Thank You for Signing with us. Our team will verify your request and a mail regarding your credentials will be shared to your email Address soon.";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage('" + AllotteeId + "');", true);



        }
        #endregion
    }




}
