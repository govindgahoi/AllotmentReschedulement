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
    public partial class Landassessmentdetails : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        #endregion
        string UserName = string.Empty;
        string ID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindDistrict();
                BindCountry();
                ID = Request.QueryString["ID"];
                ViewState["ID"] = Convert.ToInt32(ID);
                if (ViewState["ID"] != null)
                {

                    GetDetails(Convert.ToString(ViewState["ID"]));
                }


            }
        }

        private void BindCountry()
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[GetCountry]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        private void bindDistrict()
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[GetCensus_District]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataTextField = "Census_District";
                ddlDistrict.DataValueField = "Census_District_code";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        public void GetDetails(string ID)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetgridLASforviewmore(ID);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["DistrictID"].ToString().Trim();
                    ddlDistrict_SelectedIndexChanged(null, null);
                    ddlSubDistrict.SelectedValue = ds.Tables[0].Rows[0]["Census_SubDistrict_code"].ToString().Trim();
                    txtInvestorName.Text = ds.Tables[0].Rows[0]["NameofInvestor"].ToString().Trim();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
                    ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString().Trim();
                    ddlCountry_SelectedIndexChanged(null, null);
                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString().Trim();
                    txtcity.Text = ds.Tables[0].Rows[0]["City"].ToString().Trim();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString().Trim();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString().Trim();
                    txtAddressofPresentunit.Text = ds.Tables[0].Rows[0]["AddressofPresentunit"].ToString().Trim();
                    txtAnnualTurnover.Text = ds.Tables[0].Rows[0]["AnnualTurnover"].ToString().Trim();
                    txtPlotareaofunit.Text = ds.Tables[0].Rows[0]["Plotareaofunit"].ToString().Trim();
                    txtFSIConsumed.Text = ds.Tables[0].Rows[0]["FSIConsumed"].ToString().Trim();
                    txtWaterConsumed.Text = ds.Tables[0].Rows[0]["WaterConsumed"].ToString().Trim();
                    txtEmploymentGenerated.Text = ds.Tables[0].Rows[0]["EmploymentGenerated"].ToString().Trim();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString().Trim();
                    txtNatureofProject.Text = ds.Tables[0].Rows[0]["NatureofProject"].ToString().Trim();
                    txtRawMaterial.Text = ds.Tables[0].Rows[0]["RawMaterial"].ToString().Trim();
                    txtParposedProduct1.Text = ds.Tables[0].Rows[0]["ParposedProduct"].ToString().Trim();
                    txtFinanceAgreement.Text = ds.Tables[0].Rows[0]["FinanceAgreement"].ToString().Trim();
                    txtTotalProjectCost.Text = ds.Tables[0].Rows[0]["TotalProjectCost"].ToString().Trim();
                    txtBuiltupArea.Text = ds.Tables[0].Rows[0]["BuiltupArea"].ToString().Trim();
                    txtWaterrequirement.Text = ds.Tables[0].Rows[0]["Waterrequirement"].ToString().Trim();
                    txtTotalNoofEmployees.Text = ds.Tables[0].Rows[0]["TotalNoofEmployees"].ToString().Trim();
                    txtIndustryType.Text = ds.Tables[0].Rows[0]["IndustryType"].ToString().Trim();
                    txtManufacturingActivity.Text = ds.Tables[0].Rows[0]["ManufacturingActivity"].ToString().Trim();
                    txtPreferredLocation.Text = ds.Tables[0].Rows[0]["PreferredLocation"].ToString().Trim();
                    txtRequiredLandSizeinSqMtr.Text = ds.Tables[0].Rows[0]["RequiredLandSize"].ToString().Trim();
                    ddlDistrict.Enabled = false;
                    ddlSubDistrict.Enabled = false;
                    txtAddress.Enabled = false;
                    ddlCountry.Enabled = false;
                    ddlState.Enabled = false;
                    txtInvestorName.Enabled = false;
                    txtcity.Enabled = false;
                    txtMobileNo.Enabled = false;
                    txtEmail.Enabled = false;
                    txtAddressofPresentunit.Enabled = false;
                    txtAnnualTurnover.Enabled = false;
                    txtPlotareaofunit.Enabled = false;
                    txtFSIConsumed.Enabled = false;
                    txtWaterConsumed.Enabled = false;
                    txtEmploymentGenerated.Enabled = false;
                    txtRemarks.Enabled = false;
                    txtNatureofProject.Enabled = false;
                    txtRawMaterial.Enabled = false;
                    txtParposedProduct1.Enabled = false;
                    txtFinanceAgreement.Enabled = false;
                    txtTotalProjectCost.Enabled = false;
                    txtBuiltupArea.Enabled = false;
                    txtWaterrequirement.Enabled = false;
                    txtTotalNoofEmployees.Enabled = false;
                    txtIndustryType.Enabled = false;
                    txtManufacturingActivity.Enabled = false;
                    txtPreferredLocation.Enabled = false;
                    txtRequiredLandSizeinSqMtr.Enabled = false;
                    btnReset.Visible = false;
                    btnSubmit.Visible = false;
                    mandatory.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            int DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue.Trim());

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.getSubDistrictRecords(DistrictID);
                ddlSubDistrict.DataSource = ds;
                ddlSubDistrict.DataTextField = "Census_SubDistrictName";
                ddlSubDistrict.DataValueField = "Census_SubDistrict_code";
                ddlSubDistrict.DataBind();
                ddlSubDistrict.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            //finally
            //{
            //    objServiceTimelinesBEL = null;
            //    objServiceTimelinesBLL = null;
            //}
        }
        private void SendMailUPSIDC()
        {

            try
            {

                string Mail = Convert.ToString(ViewState["Mail"]);
                // string RefNo = Convert.ToString(ViewState["RefNo"]);

              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(Mail);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;
                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/LandAssessmentReferenceNo.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{Description}", "<br/>We appreciate that you have shown intrest in Investing in UPSIDA Industrial Area. After analysing your requirement we will contact you within next 15 working days. ");

                newmsg.Subject = "Intimation of Submission of Request/Proposal at UPSIDA";
                newmsg.BodyHtml = StrContent;


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




                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnSubmit.Text == "Save")
                {

                    if (ddlDistrict.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select District');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandDistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
                    }
                    if (ddlSubDistrict.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Sub District');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandSubDistrict = ddlSubDistrict.SelectedValue;
                    }
                    if (txtInvestorName.Text == "" || txtInvestorName.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Investor Name');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNameofInvestor = txtInvestorName.Text;
                    }
                    if (txtAddress.Text == "" || txtAddress.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Address');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandAddressDetails = txtAddress.Text;
                    }
                    if (ddlCountry.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Country Name');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandCountry = Convert.ToInt32(ddlCountry.SelectedValue);
                    }
                    if (ddlState.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select State Name');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandState = Convert.ToInt32(ddlState.SelectedValue);
                    }
                    if (txtcity.Text == "" || txtcity.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter City Name');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandCity = txtcity.Text;
                    }
                    if (txtMobileNo.Text == "" || txtMobileNo.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Mobile No.');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandMobileNo = txtMobileNo.Text;
                    }
                    if (txtEmail.Text == "" || txtEmail.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Email');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandMail = txtEmail.Text;
                        ViewState["Mail"] = Convert.ToString(txtEmail.Text);
                    }
                    if (txtAddressofPresentunit.Text == "" || txtAddressofPresentunit.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Address of Present unit');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandAddressofPresentunit = txtAddressofPresentunit.Text;
                    }
                    if (txtAnnualTurnover.Text == "" || txtAnnualTurnover.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Annual Turnover');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandAnnualTurnover = txtAnnualTurnover.Text;
                    }
                    if (txtPlotareaofunit.Text == "" || txtPlotareaofunit.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Plot area of unit');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandPlotareaofunit = txtPlotareaofunit.Text;
                    }
                    if (txtFSIConsumed.Text == "" || txtFSIConsumed.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter FSI Consumed');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandFSIConsumed = txtFSIConsumed.Text;
                    }
                    if (txtWaterConsumed.Text == "" || txtWaterConsumed.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Water Consumed');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandWaterConsumed = txtWaterConsumed.Text;
                    }
                    if (txtEmploymentGenerated.Text == "" || txtEmploymentGenerated.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Employment Generated');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandEmploymentGenerated = txtEmploymentGenerated.Text;
                    }
                    if (txtEmploymentGenerated.Text == "" || txtEmploymentGenerated.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Water Consumed');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandEmploymentGenerated = txtEmploymentGenerated.Text;
                    }
                    if (txtNatureofProject.Text == "" || txtNatureofProject.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Nature of Project');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNatureofProject = txtNatureofProject.Text;
                    }
                    if (txtRawMaterial.Text == "" || txtRawMaterial.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Raw Material');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandRawMaterial = txtRawMaterial.Text;
                    }
                    if (txtParposedProduct1.Text == "" || txtParposedProduct1.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Parposed Product');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandParposedProduct = txtParposedProduct1.Text;
                    }
                    if (txtFinanceAgreement.Text == "" || txtFinanceAgreement.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Finance Agreement');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandFinanceAgreement = txtFinanceAgreement.Text;
                    }
                    if (txtTotalProjectCost.Text == "" || txtTotalProjectCost.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Total Project Cost');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandTotalProjectCost = txtTotalProjectCost.Text;
                    }

                    if (txtBuiltupArea.Text == "" || txtBuiltupArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Built up Area');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandBuiltupArea = txtBuiltupArea.Text;
                    }
                    if (txtWaterrequirement.Text == "" || txtWaterrequirement.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Water requirement');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandWaterrequirement = txtWaterrequirement.Text;
                    }

                    if (txtTotalNoofEmployees.Text == "" || txtTotalNoofEmployees.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please EnterTotal No of Employees');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandTotalNoofEmployees = txtTotalNoofEmployees.Text;
                    }
                    if (txtIndustryType.Text == "" || txtIndustryType.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Industry Type');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandIndustryType = txtIndustryType.Text;
                    }

                    if (txtManufacturingActivity.Text == "" || txtManufacturingActivity.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Manufacturing Activity');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandManufacturingActivity = txtManufacturingActivity.Text;
                    }
                    if (txtPreferredLocation.Text == "" || txtPreferredLocation.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Preferred Location');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandPreferredLocation = txtPreferredLocation.Text;
                    }
                    if (txtRequiredLandSizeinSqMtr.Text == "" || txtRequiredLandSizeinSqMtr.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Land Size in SqMtr');", true);
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.LandRequiredLandSize = txtRequiredLandSizeinSqMtr.Text;
                    }



                    objServiceTimelinesBEL.LandRemarks = txtRemarks.Text;
                    DataSet result = objServiceTimelinesBLL.InsertLandAssessmentDetails(objServiceTimelinesBEL);

                    if (result.Tables.Count > 0)
                    {

                        // String RefNo = result.Tables[0].Rows[0][0].ToString();
                        //ViewState["RefNo"] = RefNo;                       
                        SendMailUPSIDC();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your  request has been submitted successfully, our representative will contact you soon.. ');", true);


                        clear();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        public void clear()
        {
            ddlDistrict.SelectedValue = "0";
            ddlSubDistrict.SelectedValue = "0";
            txtInvestorName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlCountry.SelectedValue = "0";
            ddlState.SelectedValue = "0";
            txtcity.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddressofPresentunit.Text = string.Empty;
            txtAnnualTurnover.Text = string.Empty;
            txtParposedProduct1.Text = string.Empty;
            txtFSIConsumed.Text = string.Empty;
            txtWaterConsumed.Text = string.Empty;
            txtEmploymentGenerated.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtNatureofProject.Text = string.Empty;
            txtRawMaterial.Text = string.Empty;
            txtPlotareaofunit.Text = string.Empty;
            txtFinanceAgreement.Text = string.Empty;
            txtTotalProjectCost.Text = string.Empty;
            txtBuiltupArea.Text = string.Empty;
            txtWaterrequirement.Text = string.Empty;
            txtTotalNoofEmployees.Text = string.Empty;
            txtIndustryType.Text = string.Empty;
            txtManufacturingActivity.Text = string.Empty;
            txtPreferredLocation.Text = string.Empty;
            txtRequiredLandSizeinSqMtr.Text = string.Empty;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandAssessmentDetails.aspx");
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[GetState]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlState.DataSource = dt;
                ddlState.DataTextField = "State";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}