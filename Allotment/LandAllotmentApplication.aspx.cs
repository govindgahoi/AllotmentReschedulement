using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;


namespace Allotment
{
    public partial class LandAllotmentApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;

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
        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                Status = Request.QueryString["Status"];
                TranID = Request.QueryString["TranID"];
                App    = Request.QueryString["App"];


                this.RegisterPostBackControl();
                PH_FinalView.Controls.Clear();
                UC_ApplicationFinalView UC_ApplicationFinalView = LoadControl("~/UC_ApplicationFinalView.ascx") as UC_ApplicationFinalView;
                UC_ApplicationFinalView.ID = "UC_ApplicationFinalViewID";
                UC_ApplicationFinalView.TranID = TranID;
                UC_ApplicationFinalView.ServiceRequestNo = ServiceReqNo;

                PH_FinalView.Controls.Add(UC_ApplicationFinalView);

                if (!IsPostBack)
                {

                    if (Status == "F")
                    {
                        Allotment.ActiveViewIndex = 5;
                        btnPay.Enabled = false;
                        BtnFinal.Enabled = true;

                    }
                    if (Status == "C")
                    {
                        // Allotment.ActiveViewIndex = 5;
                        btnPay.Enabled = true;
                        BtnFinal.Enabled = false;
                    }
                    if (App == "Resubmit")
                    {
                        Allotment.ActiveViewIndex = 6;
                        btnFinalResubmit.Visible = true;
                        BtnFinal.Visible = false;
                    }
                    else
                    {
                        btnFinalResubmit.Visible = false;
                        BtnFinal.Visible = true;
                        CheckFinalSubmit();
                    }
                    DataTable temp_shareholder_details = new DataTable();
                    temp_shareholder_details.TableName = "temp_shareholder_details";
                    temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_shareholder_details"] = temp_shareholder_details;
                    temp_shareholder_details_DataBind();


                    DataTable temp_trustee_details = new DataTable();
                    temp_trustee_details.TableName = "temp_trustee_details";
                    temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_trustee_details"] = temp_trustee_details;
                    temp_trustee_details_DataBind();


                    DataTable temp_directors_details = new DataTable();
                    temp_directors_details.TableName = "temp_directors_details";
                    temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_directors_details"] = temp_directors_details;
                    temp_director_details_DataBind();


                    DataTable temp_partnership_details = new DataTable();
                    temp_partnership_details.TableName = "temp_partnership_details";
                    temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                    temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_partnership_details"] = temp_partnership_details;
                    temp_partnership_details_DataBind();

                    bindCompanytypeddl();
                    bindPriorityDdl();
                    bindTypeOfIndustry();
                    bindIACategory();
                    GetApplicantDetails(ServiceReqNo);
                    BindServiceCheckListGridViewDocument();

                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;

                    }

                    UpdateDistrict();

                }

                if (App == "Resubmit")
                {
                     BindObjection();
                    //bindObjection();
                    Screen12.Visible = true;
                    Screen11.Visible = false;
                }
                else
                {
                    Screen12.Visible = false;
                    Screen11.Visible = true;
                }






            }
            catch (Exception ex)
            {

            }

        }

        #region ShareHolderPattern
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
                    dr["Phone"] = phone;

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
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

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
                dr["Address"] = address;
                dr["Email"] = email;
                dr["Phone"] = phone;

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
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

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
        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            ddlcompanytype.Style.Clear();
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                //   txtCompanyname.Enabled = false;
                // txtCinNo.Enabled = false;


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
                //  txtCompanyname.Enabled = false;
                //  txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
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
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
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

                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

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
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

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


        #endregion

        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
        }
        private void bindObjection()
        {
            SqlCommand cmd = new SqlCommand("GetObjection '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtclarification.Text = dt.Rows[0]["Objection"].ToString();
            }
            else
            {
                txtclarification.Text = "";

            }

        }

        private void CheckFinalSubmit()
        {
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.CheckFinalSubmission(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DocDisable.Text = "Lock";

                    BtnFinal.Enabled = false;
                    BtnFinal.Text = "Form Already Submitted";
                    DisableAllControl();
                    BindServiceCheckListGridViewDocument();
                }
                else
                {
                    DocDisable.Text = "";
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            BindServiceCheckListGridViewDocument();
            if (index == 0)
            {
                GetApplicantDetails(ServiceReqNo);
            }

            if (index == 4)
            {
                GetPaymentDetails();

            }
            if (index == 5)
            {
                UC_ApplicationFinalView UC_ApplicationFinalView = LoadControl("~/UC_ApplicationFinalView.ascx") as UC_ApplicationFinalView;
                UC_ApplicationFinalView.ID = "UC_ApplicationFinalViewID";
                UC_ApplicationFinalView.ServiceRequestNo = ServiceReqNo;

                PH_FinalView.Controls.Add(UC_ApplicationFinalView);

            }
            //if(!string.IsNullOrEmpty(ServiceReqNo))
            //{ 
            Allotment.ActiveViewIndex = index;
            Page_Load(null, null);
            //}

        }
        protected void chkpriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpriority.Checked == true)
            {
                prioritydiv.Visible = true;
                bindPriorityDdl();
            }
            else
            {
                txtapplicantpriorityspecification.Text = "";
                prioritydiv.Visible = false;
            }


        }
        private void bindPriorityDdl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPriorityCategory();
                ddlPriority.DataSource = ds;
                ddlPriority.DataTextField = "Category";
                ddlPriority.DataValueField = "Category";
                ddlPriority.DataBind();
                ddlPriority.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void bindTypeOfIndustry()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTypeoFIndustry();
                ddlTypeOfIndustry.DataSource = ds;
                ddlTypeOfIndustry.DataTextField = "IndustrialClassificationName";
                ddlTypeOfIndustry.DataValueField = "ClassificationID";
                ddlTypeOfIndustry.DataBind();
                ddlTypeOfIndustry.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void bindIACategory()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIACategory();
                drpIACategory.DataSource = ds;
                drpIACategory.DataTextField = "PollutionCategory";
                drpIACategory.DataValueField = "ID";
                drpIACategory.DataBind();
                drpIACategory.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void chkfumes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfumes.Checked == true)
            {
                fumesdiv.Visible = true;
            }
            else
            {
                txtfumeqty.Text = "";
                txtfumenature.Text = "";
                fumesdiv.Visible = false;
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
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(BtnSaveApplicant);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveImage);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveSign);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpload);

            foreach (GridViewRow row in GridView2.Rows)
            {

                LinkButton imgdocuments = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(imgdocuments);


                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

                LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);

            }

        }
        public void BindServiceCheckListGridViewDocument()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = ServiceReqNo.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1];

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                if (App == "Resubmit")
                {
                    objServiceTimelinesBEL.Status = 0;
                }
                else
                {
                    objServiceTimelinesBEL.Status = 1;
                }



                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllServiceChecklists(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                    this.RegisterPostBackControl();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string[] SerIdarray = ServiceReqNo.Split('/');
                    string AllottementLetterNo = SerIdarray[2];
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;


                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();



                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetTempCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;

                        e.Row.FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                        e.Row.FindControl("lbDelete").Visible = false;
                    }

                    LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

                    if (DocDisable.Text == "Lock")
                    {

                        e.Row.FindControl("lbDelete").Visible = false;
                        lnk2.Visible = false;

                    }

                }
            }
            catch
            {

            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);


                string[] SerIdarray = ServiceReqNo.Split('/');

                AllottementLetterNo = SerIdarray[2];



                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();




                int maxFileSize = 3;

                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        int fileSize = fu.PostedFile.ContentLength;
                        if (fileSize > (maxFileSize * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                         
                            return;
                        }
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".jpeg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                          
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {



                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);


                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();

                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            try
                            {
                                int retVal;
                                if (App == "Resubmit")
                                {
                                    retVal = objServiceTimelinesBLL.SaveTempServiceChecklistDocumentResubmit(objServiceTimelinesBEL);
                                }
                                else
                                {
                                    retVal = objServiceTimelinesBLL.SaveTempServiceChecklistDocument(objServiceTimelinesBEL);
                                }

                                if (retVal > 0)
                                {
                                    if (App != "Resubmit")
                                    {
                                        if (ViewState["ControlID"].ToString().Length > 0)
                                        {
                                            ControlID = ViewState["ControlID"].ToString();
                                            UnitID = ViewState["UnitID"].ToString();
                                            ServiceID = ViewState["ServiceID"].ToString();
                                            Request_ID = ViewState["Request_ID"].ToString();
                                            Status_Code = "10";
                                            Remarks = "Documents Uploaded & Application has been saved as draft | Applicant";
                                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                            string Update_Result = webService.WReturn_CUSID_STATUS(
                                             ControlID,
                                             UnitID,
                                             ServiceID,
                                             ProcessIndustryID,
                                             ApplicationID,
                                             Status_Code,
                                             Remarks,
                                             "Applicant",
                                             Fee_Amount,
                                             Fee_Status,
                                             Transaction_ID,
                                             Transaction_Date,
                                             Transaction_Date_Time,
                                             NOC_Certificate_Number,
                                             NOC_URL,
                                             ISNOC_URL_ActiveYesNO,
                                             passsalt,
                                             Request_ID,
                                             Objection_Rejection_Code,
                                             Is_Certificate_Valid_Life_Time,
                                             Certificate_EXP_Date_DDMMYYYY,
                                             D1,
                                             D2,
                                             D3,
                                             D4,
                                             D5,
                                             D6,
                                             D7

                                           );
                                        }
                                    }
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                                    BindServiceCheckListGridViewDocument();

                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }

                            }
                            catch (Exception ex)
                            {
                                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                            }
                            finally
                            {
                                objServiceTimelinesBEL = null;
                                objServiceTimelinesBLL = null;
                            }

                        }
                        else
                        {
                            string message = "Invalid File Format.Please Upload Only pdf/Jpeg/Jpg/Png files Only";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        string message = "Please Select file Then Upload";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }



                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;


                        objServiceTimelinesBEL.DocumentID = DocumentID;



                        ds = objServiceTimelinesBLL.GetTempCheckListDocument(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {


                    Response.Write("<script>window.open ('DocViewer.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&ServiceId=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocumentID=" + DocumentID + "','_blank');</script>");



                }




                if (e.CommandName == "Delete")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "Checklist Document deleted successfully ";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                        else
                        {
                            string message = "Checklist Document couldn't be deleted";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }



        private void UpdateDistrict()
        {
            try
            {
                string NMSWUnitID = ViewState["UnitID"].ToString();

                SqlCommand cmmd;
                cmmd = new SqlCommand("sp_GetDistrictByServiceReqID '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string DistrictID = dt.Rows[0][0].ToString();
                    string Status = dt.Rows[0][1].ToString();

                    if (Status == "NotUpdated")
                    {
                        NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient webService = new NMSWP_DistrictUpdate.Dist_updation_after_land_allotmt_By_DptSoapClient();

                        string Update_Result = webService.Unit_Industry_District_Location_Updation("21", NMSWUnitID, DistrictID, "", "", "p5632aa8a5c915ba4b896325bc5baz8k");
                        if (Update_Result == "TRUE")
                        {
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            int retVal = objServiceTimelinesBLL.UpdateDistrictInNMSWPInDB(objServiceTimelinesBEL);
                            if (retVal > 0)
                            {
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                string message = "Server Not Responding";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
        }
        private void download(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];


            HttpResponse Response = Context.Response;
            Response.Clear();

            Response.ClearContent();    // Add this line
            Response.ClearHeaders();

            Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();

            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        private void View(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "inline;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetApplicantDetails(String ID)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["ApplicantId"].ToString();

                    controlid  = dt.Rows[0]["SWCControlId"].ToString();
                    ControlID  = dt.Rows[0]["SWCControlId"].ToString();
                    UnitID     = dt.Rows[0]["SWCUnitId"].ToString();
                    ServiceID  = dt.Rows[0]["SWCServiceId"].ToString();
                    Request_ID = dt.Rows[0]["SWCRequestId"].ToString();
                    lblControlId.Text = dt.Rows[0]["SWCControlId"].ToString();
                    ViewState["ControlID"] = dt.Rows[0]["SWCControlId"].ToString();
                    ViewState["UnitID"] = dt.Rows[0]["SWCUnitId"].ToString();
                    ViewState["ServiceID"] = dt.Rows[0]["SWCServiceId"].ToString();
                    ViewState["Request_ID"] = dt.Rows[0]["SWCRequestId"].ToString();
                    if (controlid == "")
                    {

                        if (App == "Resubmit")
                        {
                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                if (item.Text == "Payment")
                                    menuItem = item;
                            }
                            menuItems.Remove(menuItem);
                        }
                        else
                        {
                            MenuItemCollection menuItems1 = sub_menu.Items;
                            MenuItem menuItem1 = new MenuItem();
                            foreach (MenuItem item in menuItems1)
                            {
                                if (item.Text == "Action At Your End")
                                    menuItem1 = item;
                            }
                            menuItems1.Remove(menuItem1);

                            if (Status == "F")
                            {

                            }
                            else
                            {
                                MenuItemCollection menuItems = sub_menu.Items;
                                MenuItem menuItem = new MenuItem();
                                foreach (MenuItem item in menuItems)
                                {
                                    if (item.Text == "Final Submission")
                                        menuItem = item;
                                }
                                menuItems.Remove(menuItem);

                            }
                        }
                    }
                    else
                    {

                        if (App == "Resubmit")
                        {
                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                if (item.Text == "Payment")
                                    menuItem = item;
                            }
                            menuItems.Remove(menuItem);
                        }
                        else
                        {
                            MenuItemCollection menuItems1 = sub_menu.Items;
                            MenuItem menuItem1 = new MenuItem();
                            foreach (MenuItem item in menuItems1)
                            {
                                if (item.Text == "Action At Your End")
                                    menuItem1 = item;
                            }
                            menuItems1.Remove(menuItem1);

                            if (Status == "F" || Status == "C")
                            {

                            }
                            else
                            {
                                MenuItemCollection menuItems = sub_menu.Items;
                                MenuItem menuItem = new MenuItem();
                                foreach (MenuItem item in menuItems)
                                {
                                    if (item.Text == "Final Submission")
                                        menuItem = item;
                                }
                                menuItems.Remove(menuItem);

                            }
                        }

                        BannerDiv.Visible = true;
                    }
                    LblAllotteeId.Text = dt.Rows[0]["ApplicantId"].ToString();
                    LblAllotteeIdMain.Text = dt.Rows[0]["MainID"].ToString();

                    if (dt.Rows[0]["FirmConstitution"].ToString() == "" || dt.Rows[0]["FirmConstitution"].ToString() == null)
                    {
                        ddlcompanytype.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcompanytype.SelectedValue = dt.Rows[0]["FirmConstitution"].ToString().Trim();
                    }
                    lblRegionalOffice.Text = dt.Rows[0]["District"].ToString().Trim();
                    lblIAID.Text = dt.Rows[0]["IndustrialArea"].ToString().Trim();
                    lblIndustrialArea.Text = dt.Rows[0]["IndustrialAreaName"].ToString().Trim();
                    lblIAName.Text = dt.Rows[0]["IndustrialAreaName"].ToString().Trim();
                    lblRefNo.Text = dt.Rows[0]["ApplicationId"].ToString().Trim();
                    lblRequiredArea.Text = dt.Rows[0]["PlotSize"].ToString().Trim();
                    txtCompanyname.Text = dt.Rows[0]["CompanyName"].ToString().Trim();
                    txtPayeeName.Text = dt.Rows[0]["CompanyName"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                    lblFormNo.Text = dt.Rows[0]["FormNo"].ToString().Trim();
                    txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();
                    txtGSTNo.Text = dt.Rows[0]["GSTNo"].ToString().Trim();
                    lblChosePlot.Text = dt.Rows[0]["PlotNo"].ToString().Trim();
                    txtPayeeBank.Text = dt.Rows[0]["BankName"].ToString().Trim();
                    txtaccntNo.Text = dt.Rows[0]["AccountNumber"].ToString().Trim();
                    txtConfirmAccNo.Text = dt.Rows[0]["AccountNumber"].ToString().Trim();
                    txtIFSCCode.Text = dt.Rows[0]["IFSCCode"].ToString().Trim();
                    txtBranchName.Text = dt.Rows[0]["BranchName"].ToString().Trim();
                    txtBranchAddress.Text = dt.Rows[0]["BranchAddress"].ToString().Trim();
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {

                        tr2.Visible = true;
                        ViewState["temp_shareholder_details"] = dt1;
                        temp_shareholder_details_DataBind();
                    }
                    else
                    {
                        tr2.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {

                        tr9.Visible = true;
                        ViewState["temp_partnership_details"] = dt1;
                        temp_partnership_details_DataBind();
                    }
                    else
                    {
                        tr9.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {

                        tr4.Visible = true;
                        ViewState["temp_trustee_details"] = dt1;
                        temp_trustee_details_DataBind();
                    }
                    else
                    {
                        tr4.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {

                        tr8.Visible = true;

                        ViewState["temp_directors_details"] = dt1;
                        temp_director_details_DataBind();
                    }
                    else
                    {
                        tr8.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        tr5.Visible = true;
                        tr6.Visible = true;
                        tr7.Visible = false;

                        txtIndividualName.Text = dt.Rows[0]["ApplicantName"].ToString().Trim();
                        txtPayeeName.Text = dt.Rows[0]["ApplicantName"].ToString().Trim();
                        txtIndividualAddress.Text = dt.Rows[0]["Address1"].ToString().Trim();
                        txtIndividualEmail.Text = dt.Rows[0]["emailID"].ToString().Trim();
                        txtIndividualPhone.Text = dt.Rows[0]["PhoneNo"].ToString().Trim();

                        lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";
                    }
                    else
                    {
                        txtIndividualName.Text = "";
                        txtIndividualAddress.Text = "";
                        txtIndividualEmail.Text = "";
                        txtIndividualPhone.Text = "";
                        chk2.Checked = false;
                        tr5.Visible = false;
                        tr6.Visible = false;
                        tr7.Visible = false;

                    }
                    txtAuthorisedSignatory.Text = dt.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                    txtSignatoryAddress.Text = dt.Rows[0]["SignatoryAddress"].ToString().Trim();
                    txtSignatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString().Trim();
                    txtSignatoryPhone.Text = dt.Rows[0]["SignatoryPhone"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                    txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();
                    string Imagetype = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    lblImagetype.Text = dt.Rows[0]["ApplicantImageType"].ToString().Trim();
                    lblImageName.Text = dt.Rows[0]["ApplicantImageName"].ToString().Trim();

                    string img = dt.Rows[0]["ApplicantImage"].ToString();

                    string imgSign = dt.Rows[0]["ApplicantSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantImage"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrv.Attributes.Add("class", "hide");
                        Image1.Visible = true;
                        Image1.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }

                    if (imgSign.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["ApplicantSign"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrvSign.Attributes.Add("class", "hide");
                        Image2.Visible = true;
                        Image2.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                    return;
                }
                if (dt_project.Rows.Count > 0)
                {
                    if (dt_project.Rows[0]["IAType"].ToString().Length > 0)
                    {
                        ddlTypeOfIndustry.SelectedValue = dt_project.Rows[0]["IAType"].ToString();
                    }
                    txttypeofindustry.Text = dt_project.Rows[0]["IndustryType"].ToString();
                    txtestimatedcost.Text = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtcoveredarea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    txtland.Text = dt_project.Rows[0]["LAIN"].ToString();
                    txtbuilding.Text = dt_project.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text = dt_project.Rows[0]["OtherExpenses"].ToString();
                    txteffluentsolidqty.Text = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    txteffluentsolidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    txteffluentliquidqty.Text = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    txteffluentliquidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    txteffluentgaseousqty.Text = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    txteffluentgaseouscomposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    txtProjectStartMonths.Text = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    txtWorkExperience.Text = dt_project.Rows[0]["WorkExperience"].ToString();
                    if (dt_project.Rows[0]["IAcategory"].ToString().Trim().Length > 0)
                    {
                        drpIACategory.SelectedValue = dt_project.Rows[0]["IAcategory"].ToString().Trim();
                    }
                    if (dt_project.Rows[0]["EtpRequired"].ToString().Trim().Length > 0)
                    {
                        drpreqETp.SelectedValue = dt_project.Rows[0]["EtpRequired"].ToString().Trim();
                    }
                    if (drpreqETp.SelectedValue == "Yes")
                    {
                        MeasureDiv.Visible = true;
                    }
                    else
                    {
                        MeasureDiv.Visible = false;
                    }
                    txtExistingPlotNo.Text = dt_project.Rows[0]["ExistingPlotNo"].ToString().Trim();
                    txtAllotmentNo.Text = dt_project.Rows[0]["AllotmentNo"].ToString().Trim();
                    txtAllotmentDate.Text = dt_project.Rows[0]["AllotmentDateS"].ToString().Trim();
                    txtAllotteeExisName.Text = dt_project.Rows[0]["AllotteeName"].ToString().Trim();
                    txtManufacturedProduct.Text = dt_project.Rows[0]["ProductManufactured"].ToString().Trim();
                    if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
                    {
                        ETP.Visible = true;
                    }
                    else
                    {
                        ETP.Visible = false;
                    }
                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        chkfumes.Checked = true;
                        fumesdiv.Visible = true;
                        txtfumeqty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                        txtfumenature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        chkfumes.Checked = false;
                        fumesdiv.Visible = false;
                        txtfumeqty.Text = "";
                        txtfumenature.Text = "";
                    }
                    txteffluenttreatmentmeasure1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    txteffluenttreatmentmeasure2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    txteffluenttreatmentmeasure3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    txtpowerreq.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();
                    txttelephonefirstyearreq1.Text = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    txttelephonefirstyearreq2.Text = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    txttelephoneUltimateyearreq1.Text = dt_project.Rows[0]["TelephoneReqUltimate1"].ToString();
                    txttelephoneUltimateyearreq2.Text = dt_project.Rows[0]["TelephoneReqUltimate2"].ToString();

                    if (dt_project.Rows[0]["ApplicantPriorityStatus"].ToString() == "True")
                    {
                        chkpriority.Checked = true;
                        prioritydiv.Visible = true;
                        bindPriorityDdl();
                        ddlPriority.SelectedValue = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString().Trim();
                    }
                    else
                    {
                        chkpriority.Checked = false;
                        prioritydiv.Visible = false;
                        ddlPriority.SelectedIndex = -1;
                    }
                    txtNetWorth.Text = dt_project.Rows[0]["NetWorth"].ToString().Trim();

                    txtTurnover.Text = dt_project.Rows[0]["NetTurnOver"].ToString().Trim();

                    if (dt_project.Rows[0]["ExpansionOfLand"].ToString() == "" || dt_project.Rows[0]["ExpansionOfLand"].ToString() == null)
                    { Ddl_Expansion.SelectedIndex = -1; }
                    else { Ddl_Expansion.SelectedValue = dt_project.Rows[0]["ExpansionOfLand"].ToString().Trim(); }
                    Ddl_Expansion_SelectedIndexChanged(null, null);
                    if (dt_project.Rows[0]["ExportOriented"].ToString() == "" || dt_project.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt_project.Rows[0]["ExportOriented"].ToString().Trim(); }




                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveDemandPlusObjection UC_ResolveDemandPlusObjection = LoadControl("~/UC_ResolveDemandPlusObjection.ascx") as UC_ResolveDemandPlusObjection;
            UC_ResolveDemandPlusObjection.ID = "UC_ResolveDemandPlusObjection";
            UC_ResolveDemandPlusObjection.ServiceReqNo = ServiceReqNo;
            PH_Objection.Controls.Add(UC_ResolveDemandPlusObjection);
        }
        protected void BtnSaveApplicant_Click(object sender, EventArgs e)
        {

            try
            {
                int retval = 0, retVal2 = 0;

                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Add Shareholder Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.GSTNo = txtGSTNo.Text.Trim();


                ds = objServiceTimelinesBLL.UpdateApplicantDetails(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());



                        retVal2 = objServiceTimelinesBLL.ClearShareHolder(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedIndex == 1)
                            {
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                Allotment.ActiveViewIndex = 1;
                            }

                            if (ddlcompanytype.SelectedIndex == 2)
                            {
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.ShareHolderName = ShareholderName.Trim();
                                        objServiceTimelinesBEL.ShareHolderAddress = Address.Trim();
                                        objServiceTimelinesBEL.ShareHolderPhone = phone.Trim();
                                        objServiceTimelinesBEL.ShareHolderEmail = email.Trim();
                                        objServiceTimelinesBEL.ShareHolderPer = shareper;

                                        retval = objServiceTimelinesBLL.SaveShareHolderDetails(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedIndex == 3)

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;

                                        retval = objServiceTimelinesBLL.SaveDirectorsDetails(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();



                                        objServiceTimelinesBEL.TrusteeName = TrusteeName.Trim();
                                        objServiceTimelinesBEL.TrusteeAddress = Address.Trim();
                                        objServiceTimelinesBEL.TrusteePhone = phone.Trim();
                                        objServiceTimelinesBEL.TrusteeEmail = email.Trim();

                                        retval = objServiceTimelinesBLL.SaveTrusteeDetails(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.PartnerName = PartnerName.Trim();
                                        objServiceTimelinesBEL.PartnerAddress = Address.Trim();
                                        objServiceTimelinesBEL.PartnerPhone = phone.Trim();
                                        objServiceTimelinesBEL.PartnerEmail = email.Trim();
                                        objServiceTimelinesBEL.PartnerPer = Partnershipper;

                                        retval = objServiceTimelinesBLL.SavePatnersDetails(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }

                            if (ViewState["ControlID"].ToString().Length > 0)
                            {
                                ControlID = ViewState["ControlID"].ToString();
                                UnitID = ViewState["UnitID"].ToString();
                                ServiceID = ViewState["ServiceID"].ToString();
                                Request_ID = ViewState["Request_ID"].ToString();
                                Status_Code = "10";
                                Remarks = "Applicant Details Saved & Application has been saved as draft | Applicant";
                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                 ControlID,
                                 UnitID,
                                 ServiceID,
                                 ProcessIndustryID,
                                 ApplicationID,
                                 Status_Code,
                                 Remarks,
                                 "Applicant",
                                 Fee_Amount,
                                 Fee_Status,
                                 Transaction_ID,
                                 Transaction_Date,
                                 Transaction_Date_Time,
                                 NOC_Certificate_Number,
                                 NOC_URL,
                                 ISNOC_URL_ActiveYesNO,
                                 passsalt,
                                 Request_ID,
                                 Objection_Rejection_Code,
                                 Is_Certificate_Valid_Life_Time,
                                 Certificate_EXP_Date_DDMMYYYY,
                                 D1,
                                 D2,
                                 D3,
                                 D4,
                                 D5,
                                 D6,
                                 D7
                               );
                            }
                        }


                    }
                }
                else
                {
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }



            catch (Exception ex)
            {


                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }
        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string AllotmentDate = "";
                int retval = 0, retVal2 = 0;

                int fume_status = 0; int priority_status = 0;

                if (ddlTypeOfIndustry.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry');", true);
                    return;
                }
                if (drpIACategory.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry category');", true);
                    return;
                }
                if (Ddl_Expansion.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select wether company require expansion of unit');", true);
                    return;
                }
                if (Drop1.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select wether company is 100% export oriented');", true);
                    return;
                }
                if (Ddl_Expansion.SelectedValue == "YES")
                {
                    if (ValidateDate(txtAllotmentDate.Text.Trim()))
                    {
                        AllotmentDate = DateTime.ParseExact(txtAllotmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        txtAllotmentDate.Focus();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Date');", true);
                        return;
                    }
                }
                else
                {

                }


                if (chkfumes.Checked == true)
                {

                    fume_status = 1;

                }
                else
                {
                    fume_status = 0;
                }
                if (chkpriority.Checked == true)
                {
                    if (ddlPriority.SelectedItem.Text.Trim() == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select priority category');", true);
                        return;
                    }
                    else
                    {
                        priority_status = 1;
                    }
                }
                else
                {
                    priority_status = 0;
                }

                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());
                if (App == "Resubmit")
                { objServiceTimelinesBEL.MainAllotteeID = Convert.ToInt32(LblAllotteeIdMain.Text.Trim()); }


                objServiceTimelinesBEL.IndustryType = txttypeofindustry.Text.Trim();
                objServiceTimelinesBEL.EstimatedCostOfProject = Convert.ToDecimal(txtestimatedcost.Text.Trim());
                objServiceTimelinesBEL.EstimatedEmploymentGeneration = txtestimatedemployment.Text.Trim();
                objServiceTimelinesBEL.CoveredArea = txtcoveredarea.Text.Trim();
                objServiceTimelinesBEL.OpenAreaRequired = txtopenarearequired.Text.Trim();
                objServiceTimelinesBEL.LandDetails = txtland.Text.Trim();
                objServiceTimelinesBEL.BuildingDetails = txtbuilding.Text.Trim();
                objServiceTimelinesBEL.MachineryEquipmentsDetails = txtmachinery.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidqty = txteffluentsolidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidComposition = txteffluentsolidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidqty = txteffluentliquidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidComposition = txteffluentliquidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousqty = txteffluentgaseousqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousComposition = txteffluentgaseouscomposition.Text.Trim();
                objServiceTimelinesBEL.FumeGenerationStatus = fume_status.ToString().Trim();
                objServiceTimelinesBEL.FumeQuantity = txtfumeqty.Text.Trim();
                objServiceTimelinesBEL.FumeNature = txtfumenature.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure1 = txteffluenttreatmentmeasure1.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure2 = txteffluenttreatmentmeasure2.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure3 = txteffluenttreatmentmeasure3.Text.Trim();
                objServiceTimelinesBEL.PowerReqInKW = txtpowerreq.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqFirstYear1 = txttelephonefirstyearreq1.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqFirstYear2 = txttelephonefirstyearreq2.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqUltimate1 = txttelephoneUltimateyearreq1.Text.Trim();
                objServiceTimelinesBEL.TelephoneReqUltimate2 = txttelephoneUltimateyearreq2.Text.Trim();
                objServiceTimelinesBEL.ApplicantPriorityStatus = priority_status.ToString().Trim();
                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();

                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver = txtNetWorth.Text.Trim();
                objServiceTimelinesBEL.ExpansionOfLand = Ddl_Expansion.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ExportOriented = Drop1.SelectedItem.Text.Trim();

                if (Ddl_Expansion.SelectedValue == "YES")
                {
                    objServiceTimelinesBEL.AllotmentDate = Convert.ToDateTime(DateTime.ParseExact(txtAllotmentDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                }

                objServiceTimelinesBEL.AllotmentNo = txtAllotmentNo.Text.Trim();
                objServiceTimelinesBEL.ExistingAllotteeName = txtAllotteeExisName.Text.Trim();
                objServiceTimelinesBEL.ExistingPlotNo = txtExistingPlotNo.Text.Trim();
                objServiceTimelinesBEL.IAcategory = Convert.ToInt32(drpIACategory.SelectedValue.Trim());
                objServiceTimelinesBEL.IAType = Convert.ToInt32(ddlTypeOfIndustry.SelectedValue.Trim());
                objServiceTimelinesBEL.ProductManufactured = txtManufacturedProduct.Text;
                objServiceTimelinesBEL.EtpRequired = drpreqETp.SelectedValue.Trim();
                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();

                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver = txtTurnover.Text.Trim();
                objServiceTimelinesBEL.ExpansionOfLand = Ddl_Expansion.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.ExportOriented = Drop1.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Networth = txtNetWorth.Text.Trim();



                if (App == "Resubmit")
                {
                    retval = objServiceTimelinesBLL.UpdateApplicantProjectDetailsResubmit(objServiceTimelinesBEL);

                }
                else
                {

                    retval = objServiceTimelinesBLL.UpdateApplicantProjectDetails(objServiceTimelinesBEL);
                }
                if (retval > 0)
                {
                    if (App != "Resubmit")
                    {
                        if (ViewState["ControlID"].ToString().Length > 0)
                        {
                            ControlID = ViewState["ControlID"].ToString();
                            UnitID = ViewState["UnitID"].ToString();
                            ServiceID = ViewState["ServiceID"].ToString();
                            Request_ID = ViewState["Request_ID"].ToString();
                            Status_Code = "10";
                            Remarks = "Applicant Project Details Saved & Application has been saved as draft | Applicant";
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                             ControlID,
                             UnitID,
                             ServiceID,
                             ProcessIndustryID,
                             ApplicationID,
                             Status_Code,
                             Remarks,
                             "Applicant",
                             Fee_Amount,
                             Fee_Status,
                             Transaction_ID,
                             Transaction_Date,
                             Transaction_Date_Time,
                             NOC_Certificate_Number,
                             NOC_URL,
                             ISNOC_URL_ActiveYesNO,
                             passsalt,
                             Request_ID,
                             Objection_Rejection_Code,
                             Is_Certificate_Valid_Life_Time,
                             Certificate_EXP_Date_DDMMYYYY,
                             D1,
                             D2,
                             D3,
                             D4,
                             D5,
                             D6,
                             D7
                           );
                        }
                    }
                    string message = "Applicant Project Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 7;
                }





            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
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
        private void GetPaymentDetails()
        {
            double choicearea = 0.00;
            double choiceareap1 = 0.00;
            double choiceareap2 = 0.00;
            double choiceareap3 = 0.00;
            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;
            string companyName = string.Empty;
            string ApplicantName = string.Empty;
            string applicantAddress = string.Empty;
            string SWCControlID = String.Empty;
            string SWCUnitID = String.Empty;
            string SWCServiceID = String.Empty;
            string SWCStatus = String.Empty;
            string SWCPayMode = String.Empty;

            try
            {

                GeneralMethod gm = new GeneralMethod();

                ucAllotmentDepositsInternal ucAllotmentDeposits1 = LoadControl("~/ucAllotmentDepositsInternal.ascx") as ucAllotmentDepositsInternal;
                ucAllotmentDeposits1.IndustrialArea = Convert.ToInt32(lblIAID.Text.Trim());
                ucAllotmentDeposits1.choicearea = double.Parse(lblRequiredArea.Text.Trim());
                ucAllotmentDeposits1.ApplicantName = txtCompanyname.Text;
                ucAllotmentDeposits1.applicantAddress = txtSignatoryAddress.Text;
                ucAllotmentDeposits1.IAName = gm.Get_IAName_ByServiceRequstNo(ServiceReqNo);
                ucAllotmentDeposits1.SWCControlID = ServiceReqNo;
                ucAllotmentDeposits1.TranID = TranID;
                ucAllotmentDeposits1.PlotNumber = lblChosePlot.Text.Trim();
                PlaceHolder1.Controls.Add(ucAllotmentDeposits1);



            }
            catch (Exception ex)
            { }

        }
        private void PaymentLabel()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            decimal subTotalApplicableFees, subTotalDeposits, TotalCharges;
            objServiceTimelinesBEL.industrialAreaID = Convert.ToInt32(lblIAID.Text.Trim());
            objServiceTimelinesBEL.choicearea = double.Parse(lblRequiredArea.Text.Trim());
            DataSet dschoicearea = new DataSet();
            DataTable Getdata1 = new DataTable();
            DataTable Getdata2 = new DataTable();
            dschoicearea = objServiceTimelinesBLL.GetapplicableChargesnDataforAllotment(objServiceTimelinesBEL);
            if (dschoicearea.Tables.Count > 0)
            {
                if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }

                subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                TotalCharges = subTotalApplicableFees + subTotalDeposits;
                lblAmt.Text = TotalCharges.ToString();
            }

        }
        public static class SequentialNumber
        {
            private static int _currentNumber = 0;
            public static string GetNextNumber()
            {
                _currentNumber++;
                return _currentNumber.ToString();
            }
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {

            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Gateway is Under Maintenance. Sorry For Inconvinience');", true);
            //return;
            int Count1 = 0;
            SqlCommand cmd = new SqlCommand("ValidateProjectDetailsAndDocuments '" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dss = new DataSet();
            adp.Fill(dss);
            if (dss.Tables.Count > 0)
            {
                DataTable dt1 = dss.Tables[0];
                DataTable dt2 = dss.Tables[1];
                DataTable dt3 = dss.Tables[2];

                string Project = dt1.Rows[0][0].ToString();
                int Days = Convert.ToInt32(dt3.Rows[0][0].ToString());

                if (Days < 0)
                {
                    string Message = "Last Day of payment for this plot is over.";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    GetPaymentDetails();
                    return;
                }
                if (Project == "Pending")
                {
                    string Message = "Project Details are Mandatory";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    GetPaymentDetails();
                    return;
                }
                if (Project == "PendingA")
                {
                    string Message = "Payee Account Details are Mandatory";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    GetPaymentDetails();
                    return;
                }

                int count = Convert.ToInt32(dt2.Rows[0][0].ToString());
                string firmType = dt2.Rows[0][1].ToString();

                switch (firmType)
                {
                    case "1":
                        Count1 = 4;
                        break;
                    case "2":
                        Count1 = 11;
                        break;
                    case "3":
                        Count1 = 11;
                        break;
                    case "4":
                        Count1 = 7;
                        break;
                    case "5":
                        Count1 = 5;
                        break;
                }

                if (count < Count1)
                {
                    string Message = "Please upload all mandatory documnets";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    GetPaymentDetails();
                    return;
                }

            }



            decimal TotalCharges;
            DataSet dsR = new DataSet();
            DataTable dt_Fee = new DataTable();


            GeneralMethod gm = new GeneralMethod();
            string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(ServiceReqNo, "UPSIDC");


            if (TransactionId_UPSIDC == "Failed")
            {
                string Message = "Failed In Processing";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                GetPaymentDetails();
            }
            else
            {
                dsR = objServiceTimelinesBLL.GetapplicableChargesnDataNew(ServiceReqNo);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {

                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                    gm = new GeneralMethod();
                    //string PaymentGetwayURL = gm.SendToPaymentGetway(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Land Allotment", txtCompanyname.Text);
                    string PaymentGetwayURL = gm.SendToPaymentGetwayHDFC(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Land Allotment", txtCompanyname.Text, txtIndividualEmail.Text, txtIndividualPhone.Text);

                    if (PaymentGetwayURL == "Failed")
                    {

                        string Message = "Errro Ocured In Processing !";

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    }
                    else
                    {
                        Response.Redirect(PaymentGetwayURL);
                    }
                }
            }
        }
        public static string encryptFile(string textToEncrypt, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.ECB;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) { len = keyBytes.Length; }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }
        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {




            GetPaymentDetails();
            Allotment.ActiveViewIndex = 4;

            //if (lblControlId.Text.Length > 0)
            //{

            //    Allotment.ActiveViewIndex = 5;
            //}
            //else
            //{
            //    GetPaymentDetails();
            //    Allotment.ActiveViewIndex = 4;
            //}

        }



        protected void btnIAccept_Click(object sender, EventArgs e)
        {
            DisableAllControl();
            BtnFinal.Enabled = false;
        }


        private void SendMail(string FileName)
        {

            try
            {

              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(txtSignatoryEmail.Text.Trim());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);


                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/ServiceReqNoMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", txtAuthorisedSignatory.Text);
                StrContent = StrContent.Replace("{Description}", "Your Service Request No is " + ServiceReqNo.Trim() + "<br/><br/>Complete Your Payment Process For The Final Submission Of The Application<br/><br/>We respect your patronage with us. ");



                newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for Land Allotment ";
                newmsg.BodyHtml = StrContent;
                //newmsg.IsBodyHtml = true;
                //For File Attachment, more file can also be attached
                Attachment att = new Attachment(Server.MapPath("TempPdf/" + FileName.Trim()));
                newmsg.Attachments.Add(att);

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

            }
        }

        private void SendMailUPSIDC(string FileName)
        {

            try
            {

              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(txtSignatoryEmail.Text.Trim());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);


                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/ServiceReqNoMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", txtAuthorisedSignatory.Text);
                StrContent = StrContent.Replace("{Description}", "Your Service Request No is " + ServiceReqNo.Trim() + "<br/><br/>Keep This Service Request Number Save For Tracking Your Application Status");



                newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for Land Allotment ";
                newmsg.BodyHtml = StrContent;
                //newmsg.IsBodyHtml = true;
                //For File Attachment, more file can also be attached
                Attachment att = new Attachment(Server.MapPath("TempPdf/" + FileName.Trim()));
                newmsg.Attachments.Add(att);

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

            }
        }

        protected void BtnFinal_Click(object sender, EventArgs e)
        {
            try
            {


                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {


                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                    int result = objServiceTimelinesBLL.MoveTemppplicationDataToMainTable(objServiceTimelinesBEL);
                    if (result > 0)
                    {
                        if (ViewState["ControlID"].ToString().Length > 0)
                        {
                            ControlID = ViewState["ControlID"].ToString();
                            UnitID = ViewState["UnitID"].ToString();
                            ServiceID = ViewState["ServiceID"].ToString();
                            Request_ID = ViewState["Request_ID"].ToString();
                            Status_Code = "13";
                            Remarks = "Form Finally Submitted";
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                            ControlID,
                            UnitID,
                            ServiceID,
                            ProcessIndustryID,
                            ApplicationID,
                            Status_Code,
                            Remarks,
                            Pendancy_level,
                            Fee_Amount,
                            Fee_Status,
                            Transaction_ID,
                            Transaction_Date,
                            Transaction_Date_Time,
                            NOC_Certificate_Number,
                            NOC_URL,
                            ISNOC_URL_ActiveYesNO,
                            passsalt,
                            Request_ID,
                            Objection_Rejection_Code,
                            Is_Certificate_Valid_Life_Time,
                            Certificate_EXP_Date_DDMMYYYY,
                            D1,
                            D2,
                            D3,
                            D4,
                            D5,
                            D6,
                            D7
                          );
                        }

                        PaymentLabel();
                        BtnFinal.Enabled = false;
                        BtnFinal.Text = "Form Already Submitted";
                        DisableAllControl();
                        if (lblControlId.Text.Length > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowFinalMsg();", true);
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowFinalMsgUPSIDC();", true);
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error In Saving Request');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }



        private void DisableAllControl()
        {
            ddlcompanytype.Enabled = false;
            txtCompanyname.Enabled = false;
            txtPanNo.Enabled = false;
            txtCinNo.Enabled = false;
            txtIndividualName.Enabled = false;
            txtIndividualPhone.Enabled = false;
            txtIndividualEmail.Enabled = false;
            txtIndividualAddress.Enabled = false;
            txtAuthorisedSignatory.Enabled = false;
            txtSignatoryAddress.Enabled = false;
            txtSignatoryPhone.Enabled = false;
            txtSignatoryEmail.Enabled = false;
            txttypeofindustry.Enabled = false;
            txtWorkExperience.Enabled = false;
            txttelephonefirstyearreq1.Enabled = false;
            txttelephonefirstyearreq2.Enabled = false;
            txtProjectStartMonths.Enabled = false;
            txtpowerreq.Enabled = false;
            txtOtherExpenses.Enabled = false;
            txtland.Enabled = false;
            txtmachinery.Enabled = false;
            txtopenarearequired.Enabled = false;
            txtcoveredarea.Enabled = false;
            txteffluentgaseouscomposition.Enabled = false;
            txteffluentgaseousqty.Enabled = false;
            txteffluentliquidqty.Enabled = false;
            txteffluentsolidcomposition.Enabled = false;
            txteffluentsolidqty.Enabled = false;
            txteffluentliquidcomposition.Enabled = false;
            txtestimatedcost.Enabled = false;
            txtFixedAssets.Enabled = false;
            txtfumeqty.Enabled = false;
            txtfumenature.Enabled = false;
            txtbuilding.Enabled = false;
            txtapplicantpriorityspecification.Enabled = false;
            ddlPriority.Enabled = false;
            Ddl_Expansion.Enabled = false;
            Drop1.Enabled = false;
            txteffluenttreatmentmeasure1.Enabled = false;
            txteffluenttreatmentmeasure2.Enabled = false;
            txteffluenttreatmentmeasure3.Enabled = false;
            BtnSaveApplicant.Enabled = false;
            BtnProjectInsert.Enabled = false;
            btnFinalSubmit.Enabled = false;
            btnmySave.Enabled = false;
            btnSaveSign.Disabled = true;
            btnSaveImage.Disabled = true;
            btnUpload.Enabled = false;
            BtnSaveApplicant1.Enabled = false;
            btnFinalResubmit.Enabled = false;

        }

        protected void btnSaveImage_ServerClick(object sender, EventArgs e)
        {

            if (FuplodApplicantImage.HasFile)
            {
                string filePath = FuplodApplicantImage.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantImage.FileName.ToString());
                string filename = Path.GetFileName(filePath);
                string contenttype = String.Empty;
                switch (fleUpload)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantImage.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;


                    int result;

                    if (App == "Resubmit")
                    { result = objServiceTimelinesBLL.SaveApplicantImageResubmit(objServiceTimelinesBEL); }
                    else { result = objServiceTimelinesBLL.SaveApplicantImage(objServiceTimelinesBEL); }

                    if (result > 0)
                    {
                        if (ViewState["ControlID"].ToString().Length > 0)
                        {
                            ControlID = ViewState["ControlID"].ToString();
                            UnitID = ViewState["UnitID"].ToString();
                            ServiceID = ViewState["ServiceID"].ToString();
                            Request_ID = ViewState["Request_ID"].ToString();
                            Status_Code = "10";
                            Remarks = "Applicant Image Uploaded & Application has been saved as draft | Applicant";
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                             ControlID,
                             UnitID,
                             ServiceID,
                             ProcessIndustryID,
                             ApplicationID,
                             Status_Code,
                             Remarks,
                             "Applicant",
                             Fee_Amount,
                             Fee_Status,
                             Transaction_ID,
                             Transaction_Date,
                             Transaction_Date_Time,
                             NOC_Certificate_Number,
                             NOC_URL,
                             ISNOC_URL_ActiveYesNO,
                             passsalt,
                             Request_ID,
                             Objection_Rejection_Code,
                             Is_Certificate_Valid_Life_Time,
                             Certificate_EXP_Date_DDMMYYYY,
                             D1,
                             D2,
                             D3,
                             D4,
                             D5,
                             D6,
                             D7
                           );
                        }

                        string message = "Image Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }

        protected void btnSaveSign_ServerClick(object sender, EventArgs e)
        {
            if (FuplodApplicantSign.HasFile)
            {
                string filePath = FuplodApplicantSign.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantSign.FileName.ToString());
                string filename = Path.GetFileName(filePath);
                string contenttype = String.Empty;
                switch (fleUpload)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantSign.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;


                    int result;
                    if (App == "Resubmit")
                    {
                        result = objServiceTimelinesBLL.SaveApplicantSignResubmit(objServiceTimelinesBEL);
                    }
                    else
                    { result = objServiceTimelinesBLL.SaveApplicantSign(objServiceTimelinesBEL); }


                    if (result > 0)
                    {
                        if (ViewState["ControlID"].ToString().Length > 0)
                        {
                            ControlID = ViewState["ControlID"].ToString();
                            UnitID = ViewState["UnitID"].ToString();
                            ServiceID = ViewState["ServiceID"].ToString();
                            Request_ID = ViewState["Request_ID"].ToString();
                            Status_Code = "10";
                            Remarks = "Applicant Signature Uploaded & Application has been saved as draft | Applicant";
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                             ControlID,
                             UnitID,
                             ServiceID,
                             ProcessIndustryID,
                             ApplicationID,
                             Status_Code,
                             Remarks,
                             "Applicant",
                             Fee_Amount,
                             Fee_Status,
                             Transaction_ID,
                             Transaction_Date,
                             Transaction_Date_Time,
                             NOC_Certificate_Number,
                             NOC_URL,
                             ISNOC_URL_ActiveYesNO,
                             passsalt,
                             Request_ID,
                             Objection_Rejection_Code,
                             Is_Certificate_Valid_Life_Time,
                             Certificate_EXP_Date_DDMMYYYY,
                             D1,
                             D2,
                             D3,
                             D4,
                             D5,
                             D6,
                             D7
                           );
                        }

                        string message = "Signature Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }

        protected void btnFinaliseUPSIDC_Click(object sender, EventArgs e)
        {
            DisableAllControl();
            BtnFinal.Enabled = false;
            BtnFinal.Text = "Form Already Submitted";
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if (lblControlId.Text.Length > 0)
            {

                try
                {



                    String FileName = lblFormNo.Text.Trim() + ".pdf";
                    String ContentType = "application/pdf";


                    UC_ApplicationFinalView UC_ApplicationFinalView = LoadControl("~/UC_ApplicationFinalView.ascx") as UC_ApplicationFinalView;
                    UC_ApplicationFinalView.ID = "UC_ApplicationFinalViewID";
                    UC_ApplicationFinalView.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalView.TranID = TranID;
                    UC_ApplicationFinalView.Page_Load(null, null);
                    TextWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);

                    UC_ApplicationFinalView.RenderControl(hw);



                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    byte[] pdfBytes = htmlToPdf.GeneratePdf(tw.ToString());
                    hw.Close();
                    tw.Close();

                    BinaryWriter Writer = null;
                    string Name = Server.MapPath("TempPdf/" + FileName);
                    Writer = new BinaryWriter(File.OpenWrite(Name));

                    // Writer raw data                
                    Writer.Write(pdfBytes);
                    Writer.Flush();
                    Writer.Close();


                    DataSet ds = new DataSet();

                    objServiceTimelinesBEL.ApplicationForm = pdfBytes;
                    objServiceTimelinesBEL.FormName = FileName;
                    objServiceTimelinesBEL.FormContent = ContentType;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                    int result = objServiceTimelinesBLL.SaveApplicationForm(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        SendMail(FileName.Trim());


                    }

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application Form Send To Your Registered Email Id')", true);
                    chkSendMail.Checked = false;
                    DisableAllControl();

                }
                catch (Exception ex)
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Sending Mail')", true);
                    return;

                }
            }
            else
            {
                try
                {



                    String FileName = lblFormNo.Text.Trim() + ".pdf";
                    String ContentType = "application/pdf";


                    UC_ApplicationFinalView UC_ApplicationFinalView = LoadControl("~/UC_ApplicationFinalView.ascx") as UC_ApplicationFinalView;
                    UC_ApplicationFinalView.ID = "UC_ApplicationFinalViewID";
                    UC_ApplicationFinalView.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalView.TranID = TranID;
                    UC_ApplicationFinalView.Page_Load(null, null);
                    TextWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);

                    UC_ApplicationFinalView.RenderControl(hw);



                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    byte[] pdfBytes = htmlToPdf.GeneratePdf(tw.ToString());
                    hw.Close();
                    tw.Close();

                    BinaryWriter Writer = null;
                    string Name = Server.MapPath("TempPdf/" + FileName);
                    Writer = new BinaryWriter(File.OpenWrite(Name));

                    // Writer raw data                
                    Writer.Write(pdfBytes);
                    Writer.Flush();
                    Writer.Close();


                    DataSet ds = new DataSet();

                    objServiceTimelinesBEL.ApplicationForm = pdfBytes;
                    objServiceTimelinesBEL.FormName = FileName;
                    objServiceTimelinesBEL.FormContent = ContentType;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                    int result = objServiceTimelinesBLL.SaveApplicationForm(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        SendMailUPSIDC(FileName.Trim());

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application Form Send To Your Registered Email Id')", true);
                        chkSendMail.Checked = false;
                        DisableAllControl();


                    }



                }
                catch (Exception ex)
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Sending Mail')", true);
                    return;

                }
            }
        }

        protected void BtnSaveApplicant1_Click(object sender, EventArgs e)
        {
            try
            {
                int retval = 0, retVal2 = 0;

                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];

                if (ddlcompanytype.SelectedValue == "0")
                {
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Select Firm Constitution";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Add Shareholder Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();


                ds = objServiceTimelinesBLL.UpdateApplicantDetailsResubmit(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                        LblAllotteeIdMain.Text = ds.Tables[1].Rows[0][0].ToString();
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());
                        objServiceTimelinesBEL.MainAllotteeID = Convert.ToInt32(LblAllotteeIdMain.Text.Trim());



                        retVal2 = objServiceTimelinesBLL.ClearShareHolderResubmit(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedIndex == 1)
                            {
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                Allotment.ActiveViewIndex = 1;
                            }

                            if (ddlcompanytype.SelectedIndex == 2)
                            {
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.ShareHolderName = ShareholderName.Trim();
                                        objServiceTimelinesBEL.ShareHolderAddress = Address.Trim();
                                        objServiceTimelinesBEL.ShareHolderPhone = phone.Trim();
                                        objServiceTimelinesBEL.ShareHolderEmail = email.Trim();
                                        objServiceTimelinesBEL.ShareHolderPer = shareper;

                                        retval = objServiceTimelinesBLL.SaveShareHolderDetailsResubmit(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedIndex == 3)

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();


                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;

                                        retval = objServiceTimelinesBLL.SaveDirectorsDetailsResubmit(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();



                                        objServiceTimelinesBEL.TrusteeName = TrusteeName.Trim();
                                        objServiceTimelinesBEL.TrusteeAddress = Address.Trim();
                                        objServiceTimelinesBEL.TrusteePhone = phone.Trim();
                                        objServiceTimelinesBEL.TrusteeEmail = email.Trim();

                                        retval = objServiceTimelinesBLL.SaveTrusteeDetailsResubmit(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.PartnerName = PartnerName.Trim();
                                        objServiceTimelinesBEL.PartnerAddress = Address.Trim();
                                        objServiceTimelinesBEL.PartnerPhone = phone.Trim();
                                        objServiceTimelinesBEL.PartnerEmail = email.Trim();
                                        objServiceTimelinesBEL.PartnerPer = Partnershipper;

                                        retval = objServiceTimelinesBLL.SavePatnersDetailsResubmit(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                        }


                    }
                }
                else
                {
                    string message = "Record couldnt be  Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }



            catch (Exception ex)
            {


                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }

        protected void btnFinalResubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from [ApplicationObjectionLookUp] where ServiceReqNo='" + ServiceReqNo + "' and IsActive=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Your Response Against Clarification To Close');", true);
                    return;
                }
                else
                {

                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Yes")
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                        int result = objServiceTimelinesBLL.FinalSResubmission(objServiceTimelinesBEL);
                        if (result > 0)
                        {
                            if (ViewState["ControlID"].ToString().Length > 0)
                            {
                                ControlID = ViewState["ControlID"].ToString();
                                UnitID = ViewState["UnitID"].ToString();
                                ServiceID = ViewState["ServiceID"].ToString();
                                Status_Code = "14";
                                Remarks = "Form Re-Submitted";
                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                 ControlID,
                                 UnitID,
                                 ServiceID,
                                 ProcessIndustryID,
                                 ApplicationID,
                                 Status_Code,
                                 Remarks,
                                 Pendancy_level,
                                 Fee_Amount,
                                 Fee_Status,
                                 Transaction_ID,
                                 Transaction_Date,
                                 Transaction_Date_Time,
                                 NOC_Certificate_Number,
                                 NOC_URL,
                                 ISNOC_URL_ActiveYesNO,
                                 passsalt,
                                 Request_ID,
                                 Objection_Rejection_Code,
                                 Is_Certificate_Valid_Life_Time,
                                 Certificate_EXP_Date_DDMMYYYY,
                                 D1,
                                 D2,
                                 D3,
                                 D4,
                                 D5,
                                 D6,
                                 D7
                               );
                            }

                            PaymentLabel();
                            BtnFinal.Enabled = false;
                            btnFinalResubmit.Text = "Form Already Submitted";
                            DisableAllControl();
                            if (lblControlId.Text.Length > 0)
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowFinalMsg();", true);
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowFinalMsgUPSIDC();", true);
                            }
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error In Saving Request');", true);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (fileupload.HasFile)
                {
                    string filePath = fileupload.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fileupload.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".gif":
                            contenttype = "image/gif";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;
                        case ".PDF":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = fileupload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;



                    }
                }
                else
                {
                    objServiceTimelinesBEL.filename = String.Empty;
                    objServiceTimelinesBEL.content = String.Empty;
                    objServiceTimelinesBEL.Uploadfile = null;
                }
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text);
                objServiceTimelinesBEL.MainAllotteeID = Convert.ToInt32(LblAllotteeIdMain.Text);
                objServiceTimelinesBEL.responseMessage = txtResponse.Text.Trim();
                retval = objServiceTimelinesBLL.SaveObjectionResponse(objServiceTimelinesBEL);
                if (retval > 0)
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Saved Successfully !');", true);
                    return;
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                    return;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void drpIACategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
            {
                ETP.Visible = true;
            }
            else
            {
                drpreqETp.SelectedIndex = 0;
                txteffluentgaseouscomposition.Text = "";
                txteffluentgaseousqty.Text = "";
                txteffluentliquidqty.Text = "";
                txteffluentliquidcomposition.Text = "";
                txteffluentsolidcomposition.Text = "";
                txteffluentsolidqty.Text = "";
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                ETP.Visible = false;
            }
        }

        protected void Ddl_Expansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddl_Expansion.SelectedValue == "YES")
            {
                DivExpansion.Visible = true;
            }
            else
            {
                txtAllotmentDate.Text = "";
                txtAllotmentNo.Text = "";
                txtAllotteeExisName.Text = "";
                txtManufacturedProduct.Text = "";
                txtExistingPlotNo.Text = "";
                DivExpansion.Visible = false;
            }
        }

        protected void drpreqETp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpreqETp.SelectedValue == "Yes")
            {
                MeasureDiv.Visible = true;
            }
            else
            {
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                MeasureDiv.Visible = false;
            }
        }

        protected void btnmySave_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0, retVal2 = 0;

                if (txtPayeeName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee name');", true);
                    return;
                }

                if (txtPayeeBank.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee bank name');", true);
                    return;
                }
                if (txtaccntNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee account number');", true);
                    return;
                }
                if (txtConfirmAccNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter payee confirm account number');", true);
                    return;
                }

                if (txtIFSCCode.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter ifsc code');", true);
                    return;
                }

                if (txtBranchName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter branch name');", true);
                    return;
                }

                if (txtBranchAddress.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter branch address');", true);
                    return;
                }



                if (txtaccntNo.Text == txtConfirmAccNo.Text)
                {

                    objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());
                    if (App == "Resubmit")
                    { objServiceTimelinesBEL.MainAllotteeID = Convert.ToInt32(LblAllotteeIdMain.Text.Trim()); }


                    objServiceTimelinesBEL.PayeeName = txtPayeeName.Text.Trim();
                    objServiceTimelinesBEL.PayeeBankName = txtPayeeBank.Text.Trim();
                    objServiceTimelinesBEL.AccountNo = txtConfirmAccNo.Text.Trim();
                    objServiceTimelinesBEL.IFSCCode = txtIFSCCode.Text.Trim();
                    objServiceTimelinesBEL.BranchName = txtBranchName.Text.Trim();
                    objServiceTimelinesBEL.BranchAddress = txtBranchAddress.Text.Trim();



                    if (App == "Resubmit")
                    {
                        retval = objServiceTimelinesBLL.UpdateApplicantAccountsDetailsResubmit(objServiceTimelinesBEL);

                    }
                    else
                    {

                        retval = objServiceTimelinesBLL.UpdateApplicantAccountsDetails(objServiceTimelinesBEL);
                    }
                    if (retval > 0)
                    {
                        if (ViewState["ControlID"].ToString().Length > 0)
                        {
                            ControlID = ViewState["ControlID"].ToString();
                            UnitID = ViewState["UnitID"].ToString();
                            ServiceID = ViewState["ServiceID"].ToString();
                            Request_ID = ViewState["Request_ID"].ToString();
                            Status_Code = "10";
                            Remarks = "Applicant Accounts Details Saved & Application has been saved as draft | Applicant";
                            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                            string Update_Result = webService.WReturn_CUSID_STATUS(
                             ControlID,
                             UnitID,
                             ServiceID,
                             ProcessIndustryID,
                             ApplicationID,
                             Status_Code,
                             Remarks,
                             "Applicant",
                             Fee_Amount,
                             Fee_Status,
                             Transaction_ID,
                             Transaction_Date,
                             Transaction_Date_Time,
                             NOC_Certificate_Number,
                             NOC_URL,
                             ISNOC_URL_ActiveYesNO,
                             passsalt,
                             Request_ID,
                             Objection_Rejection_Code,
                             Is_Certificate_Valid_Life_Time,
                             Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
                           );
                        }
                        string message = "Applicant Accounts Details Saved Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        Allotment.ActiveViewIndex = 3;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Account No and Confirm Account Does not Matched');", true);
                    return;
                }






            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                DataSet ds = new DataSet();
              
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                    DataTable dt = ds.Tables[0];
                   
                if (dt.Rows.Count > 0)
                {
                    
                    ControlID = dt.Rows[0]["SWCControlId"].ToString();
                    UnitID = dt.Rows[0]["SWCUnitId"].ToString();
                    ServiceID = dt.Rows[0]["SWCServiceId"].ToString();
                }

                string SWCControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", ControlID);
                string SWCUnitID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", UnitID);
                string SWCServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", ServiceID);
                string DeptID       = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt     = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
                NameValueCollection collections = new NameValueCollection();
                collections.Add("Dept_Code", DeptID.Trim());
                collections.Add("ControlID", SWCControlID.Trim());
                collections.Add("UnitID", SWCUnitID.Trim());
                collections.Add("ServiceID", SWCServiceID.Trim());
                collections.Add("PassSalt", PassSalt.Trim());

                string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}