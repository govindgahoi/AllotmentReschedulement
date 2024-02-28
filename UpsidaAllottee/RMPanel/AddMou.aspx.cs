using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace UpsidaAllottee.RMPanel
{
    
    public partial class AddMou : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        

        //SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {
                    bindRegionalOffice_RM(Convert.ToString(Session["UserName"]));
                    if (Request.QueryString["MOU"] != null)
                    {
                        string MID = Request.QueryString["MOU"].ToString();
                        FillMOU(MID);
                        btnSubmit.Text = "Update";

                    }
                    else
                    {
                        btnSubmit.Text = "Submit";
                    }
                   
                }
                else
                {
                    Response.Redirect("RMLogin.aspx");
                }

            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList2.SelectedItem.Text=="Yes")
            { ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:show2(); ", true); }
            else if (RadioButtonList2.SelectedItem.Text == "No")
            { ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:show1(); ", true); }
        }

        private void bindRegionalOffice_RM(string userName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("usp_Regional_Office", con);
            SqlCommand cmd = new SqlCommand("usp_Regional_Office_RM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userName);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlRO.DataSource = dt;
            dlRO.DataTextField = "RegionalOffice";
            dlRO.DataValueField = "RegionalOffice";
            dlRO.DataBind();

            ddlRO2.DataSource = dt;
            ddlRO2.DataTextField = "RegionalOffice";
            ddlRO2.DataValueField = "RegionalOffice";
            ddlRO2.DataBind();


            //System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            //dlRO.Items.Insert(-1, "--Select--");

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Submit")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString); ;
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.Connection = con;
                    command.CommandText = ("INSERT INTO dbo.MOUTracker (IntentID, CompanyName, Address, OfficeLocation, Email, InvestorName, Desination, InvestorMobile, ProjectName,ProjectType, ProjectDetails, Sector, Investment, Employment, PreferredLocation, Regionaloffice,LandAvailability,CurrentStage,SupportRequired,DetailsSupportRequired,IsLandIdentified,cdate,CreateBy) values( '" + txtIntentId.Text + "','" + txtCompany.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + ddlLocation.SelectedValue.Trim() + "','" + txtInvestorEmail.Text + "','" + txtInvestorName.Text + "','" + txtInvestorDesignation.Text + "','" + txtInvestorMobile.Text + "','" + txtProjectName.Text + "','" + ddlProjectType.SelectedItem.Text + "','" + txtProjectDetails.Text + "','" + txtSector.Text + "','" + txtInvestment.Text + "','" + txtEmployment.Text + "','" + ddlLocation.SelectedValue + "','" + dlRO.SelectedItem.Text + "','" + ddlLandAvail.SelectedItem.Text + "','" + ddlCurrentStage.SelectedItem.Text + "','" + RadioButtonList1.SelectedValue + "','" + txtSupportReq.Text + "','" + RadioButtonList2.SelectedValue + "', getdate(),'" + Session["UserName"].ToString() + "' )");
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('MOU Added Successfully');", true);
                        con.Close();
                        reset();
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);

                }
            }
            else if (btnSubmit.Text == "Update")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString); ;
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.Connection = con;
                    command.CommandText = ("Update dbo.MOUTracker set IntentID='" + txtIntentId.Text + "', CompanyName='" + txtCompany.Text.Trim() + "', Address='" + txtAddress.Text.Trim() + "', OfficeLocation='" + ddlLocation.SelectedValue.Trim() + "', Email='" + txtInvestorEmail.Text + "', InvestorName='" + txtInvestorName.Text + "', Desination='" + txtInvestorDesignation.Text + "', InvestorMobile='" + txtInvestorMobile.Text + "', ProjectName='" + txtProjectName.Text + "',ProjectType='" + ddlProjectType.SelectedItem.Text + "', ProjectDetails='" + txtProjectDetails.Text + "', Sector='" + txtSector.Text + "', Investment='" + txtInvestment.Text + "', Employment='" + txtEmployment.Text + "', PreferredLocation='" + ddlLocation.SelectedValue + "', Regionaloffice='" + dlRO.SelectedItem.Text + "',LandAvailability='" + ddlLandAvail.SelectedItem.Text + "',CurrentStage='" + ddlCurrentStage.SelectedItem.Text + "',SupportRequired='" + RadioButtonList1.SelectedValue + "',DetailsSupportRequired='" + txtSupportReq.Text + "',IsLandIdentified='" + RadioButtonList2.SelectedValue + "' where MID='"+ Request.QueryString["MOU"].ToString() + "'");
                     if (command.ExecuteNonQuery() > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('MOU Updated Successfully');", true);
                        con.Close();
                        //reset();
                        bindRegionalOffice_RM(Convert.ToString(Session["UserName"]));
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);

                }
            }
        }

        protected DataSet FillMOU(string MOU)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString); ;
                con.Open();
                SqlCommand command = con.CreateCommand();
                //command.Connection = con;
                //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,B.IANAme,A.PlotNo,A.AllotteeID,case when isnull(A.AllotteeName,'')>'' then A.AllotteeName else A.CompanyName end 'AllotteeName', sum(isnull(Debit,0.00)) 'Demanded',Sum(ISNULL(Credit,0.00)) 'Paid', (sum(isnull(Debit,0.00))-sum(ISnull(Credit,0.00))) 'Outstanding',  (select top 1 ModifiedOn from tbl_AllotteePaymentJournal where AllotteeID=A.AllotteeID order by id desc )as ModifiedOn from tbl_AllotteePaymentJournal T inner join AllotteeMaster A on t.AllotteeID=a.AllotteeID inner join IndustrialArea B on A.IndustrialArea=B.IAName WHERE  B.RegionalOffice='" + RegOff + "' group by B.RegionalOffice,B.IANAme,AllotteeName ,CompanyName,A.AllotteeID,A.PlotNo order by B.RegionalOffice,B.IANAme,AllotteeName,A.AllotteeID,A.PlotNo  ", con);
                //SqlCommand cmd = new SqlCommand("select  B.RegionalOffice,(select count(p.PlotNumber) as PlotNumber  FROM PlotMaster P Left join  IndustrialArea I on P.IAId=I.ID  WHERE P.status IN ('3','4','5','6','7') and P.landuseCode='2'  AND I.RegionalOffice='" + RegOff + "') AS PlotNo, (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') AS Allottee, (select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN(SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS Modified,  (select count(A.AllotteeID) from AllotteeMaster A  inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE A.isActive = '0' AND B.RegionalOffice = '" + RegOff + "') -(select  count(*) from AllotteeMaster A inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' AND A.allotteeID IN (SELECT  t.AllotteeID FROM  tbl_AllotteePaymentJournal t INNER join AllotteeMaster A  ON t.AllotteeID = a.AllotteeID inner join IndustrialArea B on A.IndustrialArea = B.IAName where B.RegionalOffice = '" + RegOff + "' and ModifiedOn  BETWEEN '1/1/2022' and '12/31/2022' GROUP BY t.AllotteeID)) AS ModifiedREmain from AllotteeMaster A   inner join IndustrialArea B on A.IndustrialArea = B.IAName WHERE  B.RegionalOffice = '" + RegOff + "' GROUP BY B.RegionalOffice", con);
                SqlCommand cmd = new SqlCommand(" select  * from MOUTracker  WHERE MID = '" + MOU + "'",con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

                 
                 
                DataTable dtDoc3 = ds.Tables[0];

               
                txtAddress.Text = dtDoc3.Rows[0]["Address"].ToString();
                txtCompany.Text = dtDoc3.Rows[0]["CompanyName"].ToString();
                txtEmployment.Text = dtDoc3.Rows[0]["Employment"].ToString();
                txtGovLand.Text = dtDoc3.Rows[0]["Employment"].ToString();
                txtIntentId.Text = dtDoc3.Rows[0]["IntentID"].ToString();
                txtInvestment.Text = dtDoc3.Rows[0]["Investment"].ToString();
                txtInvestorDesignation.Text = dtDoc3.Rows[0]["Desination"].ToString();
                txtInvestorEmail.Text = dtDoc3.Rows[0]["Email"].ToString();
                txtInvestorMobile.Text = dtDoc3.Rows[0]["InvestorMobile"].ToString();
                txtInvestorName.Text = dtDoc3.Rows[0]["InvestorName"].ToString();
                txtPreferredLocation.Text = dtDoc3.Rows[0]["PreferredLocation"].ToString();
                txtProjectDetails.Text = dtDoc3.Rows[0]["ProjectDetails"].ToString();
                txtProjectName.Text = dtDoc3.Rows[0]["ProjectName"].ToString();
                txtSector.Text = dtDoc3.Rows[0]["Sector"].ToString();
                txtSupportReq.Text = dtDoc3.Rows[0]["DetailsSupportRequired"].ToString();
                ddlCurrentStage.SelectedItem.Text= dtDoc3.Rows[0]["CurrentStage"].ToString();
                ddlIndustrialArea.SelectedIndex = 0;
                ddlLandAvail.SelectedItem.Text = dtDoc3.Rows[0]["LandAvailability"].ToString();
                ddlLandIdentify.SelectedItem.Text = dtDoc3.Rows[0]["IsLandIdentified"].ToString();
                ddlLocation.SelectedItem.Text = dtDoc3.Rows[0]["OfficeLocation"].ToString();
                dlRO.SelectedItem.Text = dtDoc3.Rows[0]["Regionaloffice"].ToString();
                ddlPlot.SelectedIndex = 0;
                ddlProjectType.SelectedItem.Text = dtDoc3.Rows[0]["ProjectType"].ToString();
                RadioButtonList1.SelectedItem.Text = dtDoc3.Rows[0]["SupportRequired"].ToString();
                RadioButtonList2.SelectedItem.Text =  dtDoc3.Rows[0]["IsLandIdentified"].ToString();
            }
            catch (Exception ex)
            {
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+ex.StackTrace+"');", true);
            }
            return ds;
        }
        private void reset()
        {
            txtAddress.Text = "";
            txtCompany.Text = "";
            txtEmployment.Text = "";
            txtGovLand.Text = "";
            txtIntentId.Text = "";
            txtInvestment.Text = "";
            txtInvestorDesignation.Text = "";
            txtInvestorEmail.Text = "";
            txtInvestorMobile.Text = "";
            txtInvestorName.Text = "";
            txtPreferredLocation.Text = "";
            txtProjectDetails.Text = "";
            txtProjectName.Text = "";
            txtSector.Text = "";
            txtSupportReq.Text = "";
            ddlCurrentStage.SelectedIndex = 0;
            ddlIndustrialArea.SelectedIndex = 0;
            ddlLandAvail.SelectedIndex = 0;
            ddlLandIdentify.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            ddlPlot.SelectedIndex = 0;
            ddlProjectType.SelectedIndex = 0;
            RadioButtonList1.SelectedIndex = -1;
            RadioButtonList2.SelectedIndex = -1;

        }
    }
}
