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
    public partial class LegalCase : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";

        public void clearAll()
        {
            plotrelating.Visible = false;
            plotNumber.Visible = false;
            //divMessageError.Visible = false;
            divMessageSucess.Visible = false;

        }

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
                UserSpecificBinding();
                CaseTypeBinding();
                JurisdictionListBinding();
                clearAll();
            }
        }
        #region Bind DropDown

        #region office_ia_plot_binding

        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = UserName;

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }

            //   Refesh(true);
            //   ResetControl();

        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("-Select-", "0"));
                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
                //      GetNewAllotteeDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.IAName = drpdwnIA.SelectedItem.Text.Trim();
                dsR = objServiceTimelinesBLL.GetPlotDetails(objServiceTimelinesBEL);
                ddlPlotNumber.DataSource = dsR.Tables[0];
                ddlPlotNumber.DataTextField = "PlotNo";
                ddlPlotNumber.DataValueField = "PlotNo";
                ddlPlotNumber.DataBind();
                ddlPlotNumber.Items.Insert(0, new ListItem("Select Plot Number", "0"));
                ViewState["Filter"] = drpdwnIA.SelectedItem.Text;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured10 :" + ex.Message.ToString());
            }
        }

        protected void ddllegalcase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddllegalcase.SelectedIndex == 7)
            {
                plotrelating.Visible = true;
                plotNumber.Visible = true;
            }
            else
            {
                plotrelating.Visible = false;
                plotNumber.Visible = false;
            }
        }

        protected void ddlPlotNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet dsR = new DataSet();
                try
                {
                    objServiceTimelinesBEL.PlotNo = ddlPlotNumber.SelectedItem.Text.Trim();
                    dsR = objServiceTimelinesBLL.GetAlloteeID(objServiceTimelinesBEL);
                    ddllegalcase.DataSource = dsR.Tables[0];
                    DataTable dt = dsR.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lblletterno.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                    }
                    else
                    {
                        lblletterno.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occuredCase :" + ex.Message.ToString());
                }

            }
            catch
            {
                lblletterno.Text = "";
            }
        }

        protected void CaseTypeBinding()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetlegalcaseType();
                ddllegalcase.DataSource = dsR.Tables[0];
                ddllegalcase.DataTextField = "CaseType";
                ddllegalcase.DataValueField = "CaseID";
                ddllegalcase.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occuredCase :" + ex.Message.ToString());
            }
        }

        protected void JurisdictionListBinding()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetlJurisdictionListBinding();
                DdlJurisdiction.DataSource = dsR.Tables[0];
                DdlJurisdiction.DataTextField = "JurisdictioryName";
                DdlJurisdiction.DataValueField = "JurisdictioryID";
                DdlJurisdiction.DataBind();
                DdlJurisdiction.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occuredCase :" + ex.Message.ToString());
            }
        }

        #endregion
        public void Refesh(bool pIsOfficeCalled)
        {
            if (!pIsOfficeCalled)

                drpdwnIA.SelectedIndex = 0;

        }

        public bool Validate2()
        {
            try
            {
                bool remark = true;
                if (txtCaseNo.Text.Length <= 0)
                {
                    txtCaseNo.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtCaseNo.Style.Clear();

                }

                if (radio1.SelectedIndex == -1)
                {
                    radio1.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    radio1.Style.Clear();

                }
                //if (DdlJurisdiction.SelectedIndex == 0)
                //{
                //    DdlJurisdiction.Style["border-color"] = "red";
                //    remark = false;
                //}
                //else
                //{
                //    DdlJurisdiction.Style.Clear();

                //}
                //if (DdlCaseStatus.SelectedIndex == 0)
                //{
                //    DdlCaseStatus.Style["border-color"] = "red";
                //    remark = false;
                //}
                //else
                //{
                //    DdlCaseStatus.Style.Clear();

                //}
                if (txtLtPartyName.Text.Length <= 0)
                {
                    txtLtPartyName.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLtPartyName.Style.Clear();

                }
                if (txtCourtDetails.Text.Length <= 0)
                {
                    txtLtPartyName.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtCourtDetails.Style.Clear();

                }
                if (txtInCourtof.Text.Length <= 0)
                {
                    txtInCourtof.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtInCourtof.Style.Clear();

                }
                if (txtMatterDetails.Text.Length <= 0)
                {
                    txtMatterDetails.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtMatterDetails.Style.Clear();

                }
                //if (DdlCaseStatus.SelectedIndex == 0)
                //{
                //    DdlCaseStatus.Style["border-color"] = "red";
                //    remark = false;
                //}
                //else
                //{
                //    DdlCaseStatus.Style.Clear();

                //}
                if (txtLitigatingParty.Text.Length <= 0)
                {
                    txtLitigatingParty.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtLitigatingParty.Style.Clear();

                }
                if (remark == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
        #endregion
        protected void btnLegalSaveEntry_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validate2())
                {
                    if (ddlPlotNumber.SelectedIndex == 0)
                    {
                        objServiceTimelinesBEL.PlotNo = "";
                    }
                    if (drpdwnIA.SelectedIndex == 0)
                    {
                        objServiceTimelinesBEL.IAName = "";
                    }
                    if (txtNextHearingDate.Text == "" || txtNextHearingDate.Text == null)
                    { MessageBox1.ShowInfo("Please Provide Case Date"); return; }
                    else
                    {
                        if (ValidateDate(txtNextHearingDate.Text))
                        {

                        }
                        else
                        {
                            txtNextHearingDate.Focus();
                            MessageBox1.ShowError("Invalid Case Date");
                            return;
                        }
                    }
                    string date_to_be = DateTime.ParseExact(txtNextHearingDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.ApplicationID = lblletterno.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = ddlPlotNumber.SelectedValue.Trim();
                    objServiceTimelinesBEL.CaseID = txtCaseNo.Text.Trim();
                    objServiceTimelinesBEL.Weare = radio1.SelectedValue.Trim();
                    objServiceTimelinesBEL.LtPartyName = txtLtPartyName.Text.Trim();
                    objServiceTimelinesBEL.Jurisdiction = DdlJurisdiction.SelectedValue.Trim();
                    objServiceTimelinesBEL.CourtDetails = txtCourtDetails.Text.Trim();
                    objServiceTimelinesBEL.InCourtof = txtInCourtof.Text.Trim();
                    objServiceTimelinesBEL.MatterDetails = txtMatterDetails.Text.Trim();
                    objServiceTimelinesBEL.CaseStatus = DdlCaseStatus.SelectedValue.Trim();
                    objServiceTimelinesBEL.LitigatingParty = txtLitigatingParty.Text.Trim();
                    objServiceTimelinesBEL.PetAdvocateName = txtPetAdvocateName.Text.Trim();
                    objServiceTimelinesBEL.PetAddress = txtPetAddress.Text.Trim();
                    objServiceTimelinesBEL.PetContactNo = txtPetContactNo.Text.Trim();
                    objServiceTimelinesBEL.ResAdvocateName = txtResAdvocateName.Text.Trim();
                    objServiceTimelinesBEL.ResAddress = txtResAddress.Text.Trim();
                    objServiceTimelinesBEL.ResContact = txtResContact.Text;
                    objServiceTimelinesBEL.legalcase = ddllegalcase.SelectedValue.Trim();
                    objServiceTimelinesBEL.IAName = drpdwnIA.SelectedValue.Trim();
                    objServiceTimelinesBEL.CreatedBy = Convert.ToString(Session["UserName"]);
                    objServiceTimelinesBEL.DateOfExecutionAgreement = Convert.ToDateTime((date_to_be));
                    int retVal = objServiceTimelinesBLL.SaveNewCaseDetail(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        divMessageSucess.Visible = true;
                        lblSuccessMessage.Text = "View you Entered Records at Case History Section";
                        //MessageBox1.ShowSuccess(" Legal History Inserted/Updated Successfully");
                        bindlegalhistory();
                        reset_legal();
                    }
                    else
                    {
                        MessageBox1.ShowError("Some Error Ocurred");
                    }
                }
                else
                {
                    //divMessageError.Visible = true;
                    //lblMessageError.Text = "Please Fill All Field";
                    return;
                }

            }


            catch (Exception ex)
            {

            }
        }

        private void reset_legal()
        {
            txtCaseNo.Text = "";
            radio1.SelectedIndex = -1;
            DdlCaseStatus.SelectedIndex = 0;
            DdlJurisdiction.SelectedIndex = 0;
            txtLtPartyName.Text = "";
            txtCourtDetails.Text = "";
            txtInCourtof.Text = "";
            txtMatterDetails.Text = "";
            txtLitigatingParty.Text = "";
            txtPetAddress.Text = "";
            txtPetAdvocateName.Text = "";
            txtPetContactNo.Text = "";
            txtResAddress.Text = "";
            txtResAdvocateName.Text = "";
            txtResContact.Text = "";
            plotrelating.Visible = false;
            plotNumber.Visible = false;
            chbregional.Checked = false;
            //txtCurrentStatus.Text = "";
            txtNextHearingDate.Text = "";


        }

        private void bindlegalhistory()
        {
            DataSet dsR = new DataSet();
            try
            {
                objServiceTimelinesBEL.CaseID = txtCaseNo.Text.Trim();
                dsR = objServiceTimelinesBLL.GetLegalCasehistoryMaster(objServiceTimelinesBEL);
                LegalGrid.DataSource = dsR.Tables[0];
                LegalGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occuredCase :" + ex.Message.ToString());
            }
        }

        protected void LegalGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LegalGrid.PageIndex = e.NewPageIndex;
            bindlegalhistory();
        }

        protected void LegalGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Process")
            {
                DataSet dsR = new DataSet();
                string caseNo = e.CommandArgument.ToString();
                objServiceTimelinesBEL.CaseID = caseNo;
                dsR = objServiceTimelinesBLL.GetLegalCasehistoryMaster(objServiceTimelinesBEL);
                DataTable dt = dsR.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    txtCaseNo.Text = dt.Rows[0]["CaseNo"].ToString();
                    radio1.SelectedValue = dt.Rows[0]["RespondentorPetitioner"].ToString().Trim();
                    txtLtPartyName.Text = dt.Rows[0]["LTPartyName"].ToString();
                    DdlJurisdiction.SelectedValue = dt.Rows[0]["Jurisdiction"].ToString().Trim();
                    txtCourtDetails.Text = dt.Rows[0]["CourtDetails"].ToString();
                    txtInCourtof.Text = dt.Rows[0]["InCourtOf"].ToString();
                    txtMatterDetails.Text = dt.Rows[0]["MatterDetails"].ToString();
                    DdlCaseStatus.SelectedValue = dt.Rows[0]["CaseStatus"].ToString().Trim();
                    txtLitigatingParty.Text = dt.Rows[0]["LitigatingParty"].ToString();
                    txtPetAdvocateName.Text = dt.Rows[0]["PetAdvocateName"].ToString();
                    txtPetAddress.Text = dt.Rows[0]["PetAdvocateAddress"].ToString();
                    txtPetContactNo.Text = dt.Rows[0]["PetAdvocateContact"].ToString();
                    txtResAdvocateName.Text = dt.Rows[0]["ResAdvocateName"].ToString();
                    txtResAddress.Text = dt.Rows[0]["ResAdvocateAddress"].ToString();
                    txtResContact.Text = dt.Rows[0]["ResAdvocateContact"].ToString();
                    txtNextHearingDate.Text = dt.Rows[0]["CaseDate1"].ToString();
                }
                else
                {
                    reset_legal();
                }

            }
            //if (e.CommandName == "DeleteCase")
            //{
            //    string error = "";
            //    con.Open();
            //    SqlCommand command = con.CreateCommand();
            //    SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            //    command.Connection = con;
            //    command.Transaction = transaction;
            //    bool transactionResult = true;
            //    try
            //    {
            //        string caseNo = e.CommandArgument.ToString();
            //        command = new SqlCommand(@"[DeleteLegalhistoryCaseWise_sp]", con, transaction);
            //        command.CommandType = CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@ApplicantId", lblletterno.Text.Trim());
            //        command.Parameters.AddWithValue("@PlotNo", ddlPlotNumber.SelectedValue.Trim());
            //        command.Parameters.AddWithValue("@CaseNo", caseNo.Trim());
            //        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

            //        if (transactionResult)
            //        {
            //            transaction.Commit();
            //            MessageBox1.ShowSuccess("Plot Legal History Deleted Successfully");
            //            reset_legal();
            //            bindlegalhistory();


            //        }
            //        else
            //        {

            //            transaction.Rollback();
            //            MessageBox1.ShowError("Some Error Ocurred");
            //            return;

            //        }
            //    }



            //    catch (Exception ex)
            //    {

            //        error += "Commit Exception Type: " + ex.GetType();
            //        error += "  Message: " + ex.Message;
            //        Response.Write(error);

            //        try
            //        { transaction.Rollback(); }

            //        catch (Exception ex2)
            //        {
            //            error += "Rollback Exception Type:" + ex2.GetType();
            //            error += " Message: " + ex2.Message;
            //            Response.Write(error);
            //        }

            //    }

            //    finally
            //    {
            //        transaction.Dispose();
            //        con.Close();

            //    }
            //}

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

        protected void Home_ServerClick(object sender, EventArgs e)
        {
            hrefPrint.Visible = false;
        }
        protected void NewAllottee_ServerClick(object sender, EventArgs e)
        {
            //New_Allottee_Registration_btn_click(null, null);
            hrefPrint.Visible = false;
        }
        protected void Reset_ServerClick(object sender, EventArgs e)
        {

            reset_legal();
        }
        protected void HistoryAllottee_ServerClick(object sender, EventArgs e)
        {
            //New_Allottee_Registration_btn_click(null, null);

            hrefPrint.Visible = false;
        }
        protected void SaveEntry_ServerClick(object sender, EventArgs e)
        {
            btnLegalSaveEntry_Click(null, null);
        }

        protected void chbregional_CheckedChanged(object sender, EventArgs e)
        {
            if (chbregional.Checked == true)
                plotrelating.Visible = true;

            else
                plotrelating.Visible = false;


        }

        //protected void txtCaseNo_TextChanged(object sender, EventArgs e)
        //{

        //    if (txtCaseNo.Text.Length <= 0)
        //    {
        //        txtCaseNo.Style["border-color"] = "red";
        //        Validate2();
        //    }
        //    else
        //    {
        //        //bindlegalhistory();
        //        txtCaseNo.Style.Clear();

        //    }
        //}

        //protected void txtLtPartyName_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtLtPartyName.Text.Length <= 0)
        //    {
        //        txtLtPartyName.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        txtLtPartyName.Style.Clear();

        //    }
        //}

        //protected void txtCourtDetails_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtCourtDetails.Text.Length <= 0)
        //    {
        //        txtLtPartyName.Style["border-color"] = "red";

        //    }
        //    else
        //    {
        //        txtCourtDetails.Style.Clear();

        //    }
        //}

        //protected void txtInCourtof_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtInCourtof.Text.Length <= 0)
        //    {
        //        txtInCourtof.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        txtInCourtof.Style.Clear();

        //    }
        //}

        //protected void txtMatterDetails_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtMatterDetails.Text.Length <= 0)
        //    {
        //        txtMatterDetails.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        txtMatterDetails.Style.Clear();

        //    }
        //}

        //protected void txtLitigatingParty_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtLitigatingParty.Text.Length <= 0)
        //    {
        //        txtLitigatingParty.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        divMessageError.Visible = false;
        //        txtLitigatingParty.Style.Clear();

        //    }
        //}

        //protected void DdlJurisdiction_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DdlJurisdiction.SelectedIndex == 0)
        //    {
        //        DdlJurisdiction.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        DdlJurisdiction.Style.Clear();

        //    }
        //}

        //protected void DdlCaseStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DdlCaseStatus.SelectedIndex == 0)
        //    {
        //        DdlCaseStatus.Style["border-color"] = "red";
        //    }
        //    else
        //    {
        //        DdlCaseStatus.Style.Clear();

        //    }
        //}
    }
}