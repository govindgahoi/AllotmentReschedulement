using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_MarkingsVerification : System.Web.UI.UserControl
    {
        SqlConnection con;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion


        public string ServiceReqNo { get; set; }
        int UserId = 0; string UserName = "";




        public void Page_Load(object sender, EventArgs e)
        {

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

            }
            catch { Response.Redirect("Default.aspx", false); }


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd;



            if (!string.IsNullOrEmpty(ServiceReqNo))
            {
                Get_EvaluationCheckListData_ForPacketApplicant();
                bindPriorityDdl();
            }


        }





        #region Allotment&Transfer_ProjectDetail

        private void bindPriorityDdl()
        {
            try
            {
                DataTable dt = new DataTable();
                GeneralMethod gm = new GeneralMethod();
                dt = gm.bind_IndustryPriorityCategoryMaster();
                ddlPriority.DataSource = dt;
                ddlPriority.DataTextField = "Category";
                ddlPriority.DataValueField = "Category";
                ddlPriority.Items.Insert(0, new ListItem("--Select--", "-"));
                ddlPriority.DataBind();

            }
            catch (Exception ex)
            {
                // Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }



        protected void drpPriorityCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpPriorityCategory.SelectedValue == "YES")
            {
                ddlPriority.Visible = true;
            }
            else
            {
                ddlPriority.Visible = false;

            }
        }



        protected void Get_Data_FromApplicantEntry()
        {

            SqlCommand cmd1 = new SqlCommand(@"Select a.* from AllotteeApplicationProjectDetails a, [dbo].[ApplicationRegister] b 
            where  b.ApplicationId = @ServiceRequestNo and a.ApplicantId = b.ApplicantID  ", con);


            cmd1.Parameters.Add("@ServiceRequestNo", SqlDbType.NVarChar);
            cmd1.Parameters["@ServiceRequestNo"].Value = ServiceReqNo;

            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);



            DataTable dt_project = new DataTable();
            adp1.Fill(dt_project);
            if (dt_project.Rows.Count > 0)
            {

                //radio2.Checked = true;
                //radio2.Enabled = true;
                //Multi.ActiveViewIndex = 1;
                //radio1.Checked = false;
                //radio3.Checked = false;
                //radio4.Checked = false;
                //radio5.Checked = false;
                //td3.Attributes.Add("style", "color:#ffc511");
                //txttypeofindustry.Text = dt_project.Rows[0]["IndustryType"].ToString();


                txtestimatedcost_lbl.Text = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                txtestimatedemployment_lbl.Text = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                txtcoveredarea_lbl.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                txtopenarearequired_lbl.Text = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                lblLand.Text = dt_project.Rows[0]["LandDetails"].ToString();
                txtbuilding_lbl.Text = dt_project.Rows[0]["BuildingDetails"].ToString();
                txtmachinery_lbl.Text = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                txtFixedAssets_lbl.Text = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                txtOtherExpenses_lbl.Text = dt_project.Rows[0]["OtherExpenses"].ToString();

                //txteffluentsolidqty.Text = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                //txteffluentsolidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                //txteffluentliquidqty.Text = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                //txteffluentliquidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                //txteffluentgaseousqty.Text = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                //txteffluentgaseouscomposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();


                txtProjectStartMonths_lbl.Text = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                txtWorkExperience_lbl.Text = dt_project.Rows[0]["WorkExperience"].ToString();


                //if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                //{
                //    chkfumes.Checked = true;
                //    fumesdiv.Visible = true;
                //    txtfumeqty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                //    txtfumenature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                //}
                //else
                //{
                //    chkfumes.Checked = false;
                //    fumesdiv.Visible = false;
                //    txtfumeqty.Text = "";
                //    txtfumenature.Text = "";
                //}
                //txteffluenttreatmentmeasure1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                //txteffluenttreatmentmeasure2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                //txteffluenttreatmentmeasure3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                //txtpowerreq.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();
                //txttelephonefirstyearreq1.Text = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                //txttelephonefirstyearreq2.Text = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                //txttelephoneUltimateyearreq1.Text = dt_project.Rows[0]["TelephoneReqUltimate1"].ToString();
                //txttelephoneUltimateyearreq2.Text = dt_project.Rows[0]["TelephoneReqUltimate2"].ToString();


                drpPriorityCategory_lbl.Text = dt_project.Rows[0]["ApplicantPriorityStatus"].ToString() + " / " + dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString();



                txtNetWorth_lbl.Text = dt_project.Rows[0]["NetWorth"].ToString().Trim();


                if (dt_project.Rows[0]["ExpansionOfLand"].ToString() == "" || dt_project.Rows[0]["ExpansionOfLand"].ToString() == null)
                { Ddl_Expansion_lbl.Text = ""; }
                else { Ddl_Expansion_lbl.Text = dt_project.Rows[0]["ExpansionOfLand"].ToString().Trim(); }
                if (dt_project.Rows[0]["ExportOriented"].ToString() == "" || dt_project.Rows[0]["ExportOriented"].ToString() == null) { Drop1_lbl.Text = ""; }
                else { Drop1_lbl.Text = dt_project.Rows[0]["ExportOriented"].ToString().Trim(); }

            }
        }



        protected void Get_EvaluationCheckListData_ForPacketApplicant()
        {
            Get_Data_FromApplicantEntry();

            try
            {

                SqlCommand cmd = new SqlCommand("Get_ServiceTicketChecklistAllotmentNew  '" + ServiceReqNo + "'  ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    txtestimatedcost.Text = dt.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text = dt.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtcoveredarea.Text = dt.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text = dt.Rows[0]["OpenAreaRequired"].ToString();
                    txtLand.Text = dt.Rows[0]["LandDetails"].ToString();
                    txtbuilding.Text = dt.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text = dt.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text = dt.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text = dt.Rows[0]["OtherExpenses"].ToString();
                    txtWorkExperience.Text = dt.Rows[0]["WorkExperience"].ToString();
                    txtProjectStartMonths.Text = dt.Rows[0]["ProjectStartMonths"].ToString();


                    try
                    {
                        drpPriorityCategory.SelectedValue = dt.Rows[0]["ApplicantPriorityStatus"].ToString();
                    }
                    catch
                    {
                        drpPriorityCategory.SelectedIndex = -1;
                    }




                    if (drpPriorityCategory.SelectedValue == "YES")
                    {
                        ddlPriority.Visible = true;

                        try
                        {

                            ddlPriority.SelectedValue = dt.Rows[0]["ApplicantPrioritySpecification"].ToString().Trim();
                        }
                        catch { ddlPriority.SelectedIndex = -1; }
                    }
                    else
                    {
                        ddlPriority.Visible = false;
                        ddlPriority.SelectedIndex = -1;
                    }


                    txtNetWorth.Text = dt.Rows[0]["NetTurnOver"].ToString().Trim();


                    if (dt.Rows[0]["ExpansionOfLand"].ToString() == "" || dt.Rows[0]["ExpansionOfLand"].ToString() == null)
                    { Ddl_Expansion.SelectedIndex = -1; }
                    else
                    {
                        Ddl_Expansion.SelectedValue = dt.Rows[0]["ExpansionOfLand"].ToString().Trim();
                    }
                    if (dt.Rows[0]["ExportOriented"].ToString() == "" || dt.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt.Rows[0]["ExportOriented"].ToString().Trim(); }


                }

            }
            catch (Exception ex)
            {
            }



        }


        protected void Set_EvaluationCheckListData_ForPacketApplicant(object sender, EventArgs e)
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


                if (txtestimatedemployment.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Employement");
                    return;
                }
                if (txtWorkExperience.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Work Experience");
                    return;
                }

                if (txtProjectStartMonths.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Start Periods");
                    return;
                }

                if (txtcoveredarea.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Covered Area");
                    return;
                }

                if (txtmachinery.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Investment Machinery");
                    return;
                }
                if (txtLand.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Estimated Investment in Land");
                    return;
                }
                if (drpPriorityCategory.SelectedValue == "")
                {
                    MessageBox1.ShowInfo("Please verify Priority Category");
                    return;
                }
                if (Ddl_Expansion.SelectedValue == "")
                {
                    MessageBox1.ShowInfo("Please verify Project Expansion");
                    return;
                }
                if (Drop1.SelectedValue == "")
                {
                    MessageBox1.ShowInfo("Please verify Export Oriented");
                    return;
                }
                if (txtNetWorth.Text == "")
                {
                    MessageBox1.ShowInfo("Please verify Net Worth");
                    return;
                }


                command = new SqlCommand(@"Set_ServiceTicketChecklistAllotmentNew", con, transaction);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@ServiceRequestNo", ServiceReqNo);


                //  Land Allotment & Plot Transfer
                {
                    if (txtestimatedcost.Text == "")
                    {
                        command.Parameters.Add("@EstimatedCostOfProject", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EstimatedCostOfProject", txtestimatedcost.Text.Trim());
                    }

                    if (txtestimatedemployment.Text == "")
                    {
                        command.Parameters.Add("@EstimatedEmploymentGeneration", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EstimatedEmploymentGeneration", txtestimatedemployment.Text.Trim());
                    }
                    if (txtcoveredarea.Text == "")
                    {
                        command.Parameters.Add("@CoveredArea", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CoveredArea", txtcoveredarea.Text.Trim());
                    }
                    if (txtopenarearequired.Text == "")
                    {
                        command.Parameters.Add("@OpenAreaRequired", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OpenAreaRequired", txtopenarearequired.Text.Trim());
                    }
                    if (txtLand.Text == "")
                    {
                        command.Parameters.Add("@LandDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LandDetails", txtLand.Text.Trim());
                    }
                    if (txtbuilding.Text == "")
                    {
                        command.Parameters.Add("@BuildingDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@BuildingDetails", txtbuilding.Text.Trim());
                    }
                    if (txtmachinery.Text == "")
                    {
                        command.Parameters.Add("@MachineryEquipmentsDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MachineryEquipmentsDetails", txtmachinery.Text.Trim());
                    }


                    command.Parameters.AddWithValue("@ApplicantPriorityStatus", drpPriorityCategory.SelectedValue);
                    if (drpPriorityCategory.SelectedValue == "YES")
                    {
                        command.Parameters.AddWithValue("@ApplicantPrioritySpecification", ddlPriority.SelectedItem.Text.Trim());
                    }
                    else
                    {
                        command.Parameters.Add("@ApplicantPrioritySpecification", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    if (txtFixedAssets.Text == "")
                    {
                        command.Parameters.Add("@OtherFixedAssets", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OtherFixedAssets", txtFixedAssets.Text.Trim());
                    }
                    if (txtOtherExpenses.Text == "")
                    {
                        command.Parameters.Add("@OtherExpenses", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OtherExpenses", txtOtherExpenses.Text.Trim());
                    }
                    command.Parameters.AddWithValue("@projectstartmonths", txtProjectStartMonths.Text.Trim());
                    command.Parameters.AddWithValue("@workexperience", txtWorkExperience.Text.Trim());
                    if (txtNetWorth.Text == "")
                    { command.Parameters.Add("@NetTurnOver", System.Data.SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@NetTurnOver", txtNetWorth.Text.Trim()); }

                    if (Ddl_Expansion.SelectedIndex == 0)
                    {
                        command.Parameters.Add("@ExpansionOfLand", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ExpansionOfLand", Ddl_Expansion.SelectedItem.Text.Trim());
                    }
                    if (Drop1.SelectedIndex == 0)
                    {
                        command.Parameters.Add("@ExportOriented", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    else { command.Parameters.AddWithValue("@ExportOriented", Drop1.SelectedItem.Text.Trim()); }

                }


                transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                if (transactionResult)
                {
                    transaction.Commit();
                    MessageBox1.ShowSuccess("Saved");


                    if (!string.IsNullOrEmpty(ServiceReqNo))
                    {
                        Get_EvaluationCheckListData_ForPacketApplicant();
                    }


                }
                else
                {
                    transaction.Rollback();
                    MessageBox1.ShowWarning("Error");
                    return;
                }

            }
            catch (Exception ex)
            {
                error = "";
                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;

                MessageBox1.ShowError(error);


                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;

                    MessageBox1.ShowError(error);

                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }


        }



        #endregion

    }
}