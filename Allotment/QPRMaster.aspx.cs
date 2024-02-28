using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class QPRMaster : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        #endregion

        string UserName = string.Empty;
        int UserID;
        string Level = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserID = _objLoginInfo.userid;
                GeneralMethod gm1 = new GeneralMethod();
                Level = gm1.GetUserDesignation(UserID);
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


        private void check_user_role()
        {

            bindregion1();
            bindgrid("", "");

        }

        private void bindgrid(string IAId, string p)
        {
            SqlCommand cmd = new SqlCommand("spGetQPRdetails '" + IAId + "','" + p + "','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            gridQPR.DataSource = dt;
            gridQPR.DataBind();




        }
        private void bindregion(string reg)
        {
            SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlregion.DataSource = dt;
            ddlregion.DataTextField = "a";
            ddlregion.DataValueField = "b";
            ddlregion.DataBind();
            ddlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        private void bindregion1()
        {
            SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlregion.DataSource = dt;
            ddlregion.DataTextField = "a";
            ddlregion.DataValueField = "b";
            ddlregion.DataBind();
            ddlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        public void clear()
        {
            try
            {
                ddlregion.SelectedValue = "0";
                ddlIA.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                ddlLandtype.SelectedValue = "0";
                ddlyear.SelectedValue = "0";
                ddlQuarterEndDate.SelectedValue = "0";
                txtBoxTotalLandAcquired.Text = string.Empty;
                txtIARatePerSqmt.Text = string.Empty;
                txtAllotedLandUnits.Text = string.Empty;
                txtAllotedLandPlots.Text = string.Empty;
                txtAllotedLandArea.Text = string.Empty;
                txtTotalLandforAllotmentplots.Text = string.Empty;
                txtTotalLandforAllotmentArea.Text = string.Empty;
                txtLandNotAvlDueToLitigationPlots.Text = string.Empty;
                txtLandNotAvlDueToLitigationArea.Text = string.Empty;
                txtBalLandForAllotmentPlots.Text = string.Empty;
                txtBalLandForAllotmentArea.Text = string.Empty;
                txtUnderConstructionUnits.Text = string.Empty;
                txtUnderConstructionArea.Text = string.Empty;
                txtConstructedFunctionalUnits.Text = string.Empty;
                txtConstructedFunctionalArea.Text = string.Empty;
                txtSickClosedUnits.Text = string.Empty;
                txtSickClosedArea.Text = string.Empty;
                txtNotStartedEvenconstructionunits.Text = string.Empty;
                txtNotStartedEvenconstructionArea.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                if (btnSubmit.Text == "Submit")
                {

                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    if (ddlregion.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Region office');", true);
                        //MessageBox1.ShowWarning("Please select Region office");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.RegionalOffice = (ddlregion.SelectedValue.Trim());
                    }
                    if (ddlIA.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select IA');", true);
                        //MessageBox1.ShowWarning("Please select IA");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.IAName = (ddlIA.SelectedValue.Trim());
                    }
                    if (ddlLandtype.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Land Type');", true);
                        //MessageBox1.ShowWarning("Please select Land Type");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRLandtype = Convert.ToInt32(ddlLandtype.SelectedValue.Trim());
                    }

                    if (ddlQuarterEndDate.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Quarter End Date');", true);
                        //MessageBox1.ShowWarning("Please Provide Quarter End Date");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QuarterEndDate = Convert.ToInt32(ddlQuarterEndDate.SelectedValue.Trim());
                    }
                    if (ddlyear.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide year');", true);
                        //MessageBox1.ShowWarning("Please Provide year");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRyear = Convert.ToInt32(ddlyear.SelectedValue.Trim());
                    }
                    if (ddlCategory.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Category');", true);
                        //MessageBox1.ShowWarning("Please select Category");
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRCategory = Convert.ToInt32(ddlCategory.SelectedValue.Trim());
                    }

                    if (txtBoxTotalLandAcquired.Text == "" || txtBoxTotalLandAcquired.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land Acquired Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land Acquired Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandAcquired = Convert.ToDecimal(txtBoxTotalLandAcquired.Text.Trim());
                    }

                    if (txtIARatePerSqmt.Text == "" || txtIARatePerSqmt.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Rate');", true);
                        //MessageBox1.ShowWarning("Please Provide Rate");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.IARatePerSqmt = Convert.ToDecimal(txtIARatePerSqmt.Text.Trim());
                    }
                    if (txtAllotedLandPlots.Text == "" || txtAllotedLandPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land plot');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandPlot = Convert.ToInt32(txtAllotedLandPlots.Text.Trim());
                    }
                    if (txtAllotedLandUnits.Text == "" || txtAllotedLandUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land Unit');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land Unit");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandunit = Convert.ToInt32(txtAllotedLandUnits.Text.Trim());
                    }

                    if (txtAllotedLandArea.Text == "" || txtAllotedLandArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandArea = Convert.ToDecimal(txtAllotedLandArea.Text.Trim());
                    }
                    if (txtTotalLandforAllotmentplots.Text == "" || txtTotalLandforAllotmentplots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land for Allotment plots');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land for Allotment plots");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandforAllotmentPlots = Convert.ToInt32(txtTotalLandforAllotmentplots.Text.Trim());
                    }
                    //if (txtTotalLandforAllotmentArea.Text == "" || txtTotalLandforAllotmentArea.Text == null)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide TotalLand for Allotment Area');", true);
                    //    //MessageBox1.ShowWarning("Please Provide TotalLand for Allotment Area");
                    //    return;
                    //}
                    //else
                    //{
                    //    objServiceTimelinesBEL.TotalLandforAllotmentArea = Convert.ToDecimal(txtTotalLandforAllotmentArea.Text.Trim());
                    //}

                    if (txtTotalLandforAllotmentArea.Text == "" || txtTotalLandforAllotmentArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land for Allotment Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land for Allotment Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandforAllotmentArea = Convert.ToDecimal(txtTotalLandforAllotmentArea.Text.Trim());
                    }
                    if (txtLandNotAvlDueToLitigationPlots.Text == "" || txtLandNotAvlDueToLitigationPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Land Not Avl. Due To Litigation Plot');", true);
                        //MessageBox1.ShowWarning("Please Provide Land Not Avl. Due To Litigation Plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNotAvlDueToLitigationPlot = Convert.ToInt32(txtLandNotAvlDueToLitigationPlots.Text.Trim());
                    }

                    if (txtLandNotAvlDueToLitigationArea.Text == "" || txtLandNotAvlDueToLitigationArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Land Not Avl. Due To Litigation Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Land Not Avl. Due To Litigation Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNotAvlDueToLitigationArea = Convert.ToDecimal(txtLandNotAvlDueToLitigationArea.Text.Trim());
                    }
                    if (txtBalLandForAllotmentPlots.Text == "" || txtBalLandForAllotmentPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Bal Land For Allotment Plots');", true);
                        //MessageBox1.ShowWarning("Please Provide  Bal Land For Allotment Plots");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.BalLandForAllotmentPlot = Convert.ToInt32(txtBalLandForAllotmentPlots.Text.Trim());
                    }
                    if (txtBalLandForAllotmentArea.Text == "" || txtBalLandForAllotmentArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Bal Land For Allotment Area');", true);
                        //MessageBox1.ShowWarning("Please Provide  Bal Land For Allotment Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.BalLandForAllotmentArea = Convert.ToDecimal(txtBalLandForAllotmentArea.Text.Trim());
                    }
                    if (txtUnderConstructionUnits.Text == "" || txtUnderConstructionUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Under Construction Unit');", true);
                        //MessageBox1.ShowWarning("Please Provide  Under Construction Unit");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.UnderConstructionUnit = Convert.ToInt32(txtUnderConstructionUnits.Text.Trim());
                    }
                    if (txtUnderConstructionArea.Text == "" || txtUnderConstructionArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Under Construction Area');", true);
                        //MessageBox1.ShowWarning("Please Provide  Under Construction Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.UnderConstructionArea = Convert.ToDecimal(txtUnderConstructionArea.Text.Trim());
                    }
                    if (txtConstructedFunctionalUnits.Text == "" || txtConstructedFunctionalUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Constructed Functional Units');", true);
                        //MessageBox1.ShowWarning("Please Provide Constructed Functional Units");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructedFunctionalUnit = Convert.ToInt32(txtConstructedFunctionalUnits.Text.Trim());
                    }
                    if (txtConstructedFunctionalArea.Text == "" || txtConstructedFunctionalArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Constructed Functional Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Constructed Functional Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructedFunctionalArea = Convert.ToDecimal(txtConstructedFunctionalArea.Text.Trim());
                    }
                    if (txtSickClosedUnits.Text == "" || txtSickClosedUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Sick Closed Units');", true);
                        //MessageBox1.ShowWarning("Please Provide Sick Closed Units");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.SickClosedUnit = Convert.ToInt32(txtSickClosedUnits.Text.Trim());
                    }
                    if (txtSickClosedArea.Text == "" || txtSickClosedArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Sick Closed Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Sick Closed Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.SickClosedArea = Convert.ToDecimal(txtSickClosedArea.Text.Trim());
                    }
                    if (txtNotStartedEvenconstructionunits.Text == "" || txtNotStartedEvenconstructionunits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide alloted but vacant plot');", true);
                        //MessageBox1.ShowWarning("Please Provide alloted but vacant plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.NotStartedEvenconstructionUnit = Convert.ToInt32(txtNotStartedEvenconstructionunits.Text.Trim());
                    }

                    if (txtNotStartedEvenconstructionArea.Text == "" || txtNotStartedEvenconstructionArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide alloted but vacant Area');", true);
                        //MessageBox1.ShowWarning("Please Provide alloted but vacant Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.NotStartedEvenconstructionArea = Convert.ToDecimal(txtNotStartedEvenconstructionArea.Text.Trim());
                    }

                    objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();



                    int Result = objServiceTimelinesBLL.insertQPR(objServiceTimelinesBEL);

                    if (Result > 0)
                    {
                        //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script> alert('QPR Details Inserted Successfully');window.open('QPRMaster.aspx');</script>", true);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('QPR Details inserted Successfully');", true);

                        clear();
                        gridFunc();
                        return;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error During The Process');", true);
                        return;
                    }
                }
                else
                {
                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    int ID = Convert.ToInt32(ViewState["id"].ToString());
                    objServiceTimelinesBEL.QPRID = Convert.ToInt32(ID);

                    if (ddlregion.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Region office');", true);
                        //MessageBox1.ShowWarning("Please select Region office");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.RegionalOffice = (ddlregion.SelectedValue.Trim());
                    }
                    if (ddlIA.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select IA');", true);
                        //MessageBox1.ShowWarning("Please select IA");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.IAName = (ddlIA.SelectedValue.Trim());
                    }
                    if (ddlLandtype.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Land Type');", true);
                        //MessageBox1.ShowWarning("Please select Land Type");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRLandtype = Convert.ToInt32(ddlLandtype.SelectedValue.Trim());
                    }

                    if (ddlQuarterEndDate.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Quarter End Date');", true);
                        //MessageBox1.ShowWarning("Please Provide Quarter End Date");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QuarterEndDate = Convert.ToInt32(ddlQuarterEndDate.SelectedValue.Trim());
                    }
                    if (ddlyear.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide year');", true);
                        //MessageBox1.ShowWarning("Please Provide year");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRyear = Convert.ToInt32(ddlyear.SelectedValue.Trim());
                    }
                    if (ddlCategory.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Category');", true);
                        //MessageBox1.ShowWarning("Please select Category");
                        return;

                    }
                    else
                    {
                        objServiceTimelinesBEL.QPRCategory = Convert.ToInt32(ddlCategory.SelectedValue.Trim());
                    }

                    if (txtBoxTotalLandAcquired.Text == "" || txtBoxTotalLandAcquired.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land Acquired Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land Acquired Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandAcquired = Convert.ToDecimal(txtBoxTotalLandAcquired.Text.Trim());
                    }

                    if (txtIARatePerSqmt.Text == "" || txtIARatePerSqmt.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Rate');", true);
                        //MessageBox1.ShowWarning("Please Provide Rate");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.IARatePerSqmt = Convert.ToDecimal(txtIARatePerSqmt.Text.Trim());
                    }
                    if (txtAllotedLandPlots.Text == "" || txtAllotedLandPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land plot');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandPlot = Convert.ToInt32(txtAllotedLandPlots.Text.Trim());
                    }
                    if (txtAllotedLandUnits.Text == "" || txtAllotedLandUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land Unit');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land Unit");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandunit = Convert.ToInt32(txtAllotedLandUnits.Text.Trim());
                    }

                    if (txtAllotedLandArea.Text == "" || txtAllotedLandArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Alloted Land Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Alloted Land Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.AllotedLandArea = Convert.ToDecimal(txtAllotedLandArea.Text.Trim());
                    }
                    if (txtTotalLandforAllotmentplots.Text == "" || txtTotalLandforAllotmentplots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land for Allotment plots');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land for Allotment plots");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandforAllotmentPlots = Convert.ToInt32(txtTotalLandforAllotmentplots.Text.Trim());
                    }
                    //if (txtTotalLandforAllotmentArea.Text == "" || txtTotalLandforAllotmentArea.Text == null)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide TotalLand for Allotment Area');", true);
                    //    //MessageBox1.ShowWarning("Please Provide TotalLand for Allotment Area");
                    //    return;
                    //}
                    //else
                    //{
                    //    objServiceTimelinesBEL.TotalLandforAllotmentArea = Convert.ToDecimal(txtTotalLandforAllotmentArea.Text.Trim());
                    //}

                    if (txtTotalLandforAllotmentArea.Text == "" || txtTotalLandforAllotmentArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Total Land for Allotment Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Total Land for Allotment Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.TotalLandforAllotmentArea = Convert.ToDecimal(txtTotalLandforAllotmentArea.Text.Trim());
                    }
                    if (txtLandNotAvlDueToLitigationPlots.Text == "" || txtLandNotAvlDueToLitigationPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Land Not Avl. Due To Litigation Plot');", true);
                        //MessageBox1.ShowWarning("Please Provide Land Not Avl. Due To Litigation Plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNotAvlDueToLitigationPlot = Convert.ToInt32(txtLandNotAvlDueToLitigationPlots.Text.Trim());
                    }

                    if (txtLandNotAvlDueToLitigationArea.Text == "" || txtLandNotAvlDueToLitigationArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Land Not Avl. Due To Litigation Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Land Not Avl. Due To Litigation Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandNotAvlDueToLitigationArea = Convert.ToDecimal(txtLandNotAvlDueToLitigationArea.Text.Trim());
                    }
                    if (txtBalLandForAllotmentPlots.Text == "" || txtBalLandForAllotmentPlots.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Bal Land For Allotment Plots');", true);
                        //MessageBox1.ShowWarning("Please Provide  Bal Land For Allotment Plots");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.BalLandForAllotmentPlot = Convert.ToInt32(txtBalLandForAllotmentPlots.Text.Trim());
                    }
                    if (txtBalLandForAllotmentArea.Text == "" || txtBalLandForAllotmentArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Bal Land For Allotment Area');", true);
                        //MessageBox1.ShowWarning("Please Provide  Bal Land For Allotment Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.BalLandForAllotmentArea = Convert.ToDecimal(txtBalLandForAllotmentArea.Text.Trim());
                    }
                    if (txtUnderConstructionUnits.Text == "" || txtUnderConstructionUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Under Construction Unit');", true);
                        //MessageBox1.ShowWarning("Please Provide  Under Construction Unit");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.UnderConstructionUnit = Convert.ToInt32(txtUnderConstructionUnits.Text.Trim());
                    }
                    if (txtUnderConstructionArea.Text == "" || txtUnderConstructionArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide  Under Construction Area');", true);
                        //MessageBox1.ShowWarning("Please Provide  Under Construction Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.UnderConstructionArea = Convert.ToDecimal(txtUnderConstructionArea.Text.Trim());
                    }
                    if (txtConstructedFunctionalUnits.Text == "" || txtConstructedFunctionalUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Constructed Functional Units');", true);
                        //MessageBox1.ShowWarning("Please Provide Constructed Functional Units");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructedFunctionalUnit = Convert.ToInt32(txtConstructedFunctionalUnits.Text.Trim());
                    }
                    if (txtConstructedFunctionalArea.Text == "" || txtConstructedFunctionalArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Constructed Functional Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Constructed Functional Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ConstructedFunctionalArea = Convert.ToDecimal(txtConstructedFunctionalArea.Text.Trim());
                    }
                    if (txtSickClosedUnits.Text == "" || txtSickClosedUnits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Sick Closed Units');", true);
                        //MessageBox1.ShowWarning("Please Provide Sick Closed Units");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.SickClosedUnit = Convert.ToInt32(txtSickClosedUnits.Text.Trim());
                    }
                    if (txtSickClosedArea.Text == "" || txtSickClosedArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Sick Closed Area');", true);
                        //MessageBox1.ShowWarning("Please Provide Sick Closed Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.SickClosedArea = Convert.ToDecimal(txtSickClosedArea.Text.Trim());
                    }
                    if (txtNotStartedEvenconstructionunits.Text == "" || txtNotStartedEvenconstructionunits.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide alloted but vacant plot');", true);
                        //MessageBox1.ShowWarning("Please Provide alloted but vacant plot");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.NotStartedEvenconstructionUnit = Convert.ToInt32(txtNotStartedEvenconstructionunits.Text.Trim());
                    }

                    if (txtNotStartedEvenconstructionArea.Text == "" || txtNotStartedEvenconstructionArea.Text == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide alloted but vacant Area');", true);
                        //MessageBox1.ShowWarning("Please Provide alloted but vacant Area");
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.NotStartedEvenconstructionArea = Convert.ToDecimal(txtNotStartedEvenconstructionArea.Text.Trim());
                    }

                    objServiceTimelinesBEL.ModifiedBy = _objLoginInfo.userName.ToString();



                    int Result = objServiceTimelinesBLL.UpdateQPR(objServiceTimelinesBEL);

                    if (Result > 0)
                    {


                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('QPR Details Updated Successfully');", true);


                        clear();
                        gridFunc();
                        return;

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error During The Process');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;
            }

        }





        protected void ddlregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.RegionalOffice = (ddlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords1(objServiceTimelinesBEL);
                ddlIA.DataSource = ds;
                ddlIA.DataTextField = "IAName";
                ddlIA.DataValueField = "Id";
                ddlIA.DataBind();
                ddlIA.Items.Insert(0, new ListItem("--Select--", "0"));



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


        private void gridFunc()
        {

            if (ddlIA.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand("spGetQPRdetails '" + ddlIA.SelectedValue.Trim() + "','S','" + UserName + "','" + txtSearch.Text.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                gridQPR.DataSource = dt;
                gridQPR.DataBind();
            }
            else
            {
                bindgrid("", "");
            }

        }

        protected void gridQPR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Process")
                {

                    string rowid = e.CommandArgument.ToString();
                    ViewState["id"] = rowid;
                    get_QPRdetals(rowid);
                    btnSubmit.Text = "Update";

                }
                if (e.CommandName == "Delete")
                {
                    string rowid = e.CommandArgument.ToString();
                    Delete_QPRdetals(rowid);
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
        private void get_QPRdetals(string id)
        {
            DataSet ds = new DataSet();
            ds = objServiceTimelinesBLL.GetEditQPRDetails(id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string regoffice = ds.Tables[0].Rows[0]["RegionID"].ToString().Trim();
                    ddlregion.SelectedValue = regoffice.Trim();
                    ddlregion_SelectedIndexChanged(null, null);
                    ddlIA.SelectedValue = ds.Tables[0].Rows[0]["IAID"].ToString();
                    ddlyear.SelectedValue = ds.Tables[0].Rows[0]["Year"].ToString();
                    ddlLandtype.SelectedValue = ds.Tables[0].Rows[0]["LandType"].ToString();
                    ddlQuarterEndDate.SelectedValue = ds.Tables[0].Rows[0]["QuarterEndDate"].ToString();
                    ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["Category"].ToString();
                    txtTotalLandforAllotmentplots.Text = ds.Tables[0].Rows[0]["TotlLandForAllotIncDevPlot"].ToString();
                    txtTotalLandforAllotmentArea.Text = ds.Tables[0].Rows[0]["TotlLandForAllotIncDevArea"].ToString();
                    txtBoxTotalLandAcquired.Text = ds.Tables[0].Rows[0]["TotalLandAcquired"].ToString();

                    txtAllotedLandUnits.Text = ds.Tables[0].Rows[0]["AllotteedLandIncUnDevUnit"].ToString();
                    txtAllotedLandPlots.Text = ds.Tables[0].Rows[0]["AllotteedLandIncUnDevPlot"].ToString();
                    txtAllotedLandArea.Text = ds.Tables[0].Rows[0]["AllotteedLandIncUnDevArea"].ToString();
                    // string AllotteedLandIncUnDevArea = Convert.ToString(txtAllotedLandArea.Text);

                    txtLandNotAvlDueToLitigationPlots.Text = ds.Tables[0].Rows[0]["LandNotAvlDueToLitigationPlot"].ToString();
                    txtLandNotAvlDueToLitigationArea.Text = ds.Tables[0].Rows[0]["LandNotAvlDueToLitigationArea"].ToString();
                    txtBalLandForAllotmentPlots.Text = ds.Tables[0].Rows[0]["BalLandForAllotmentPlot"].ToString();
                    txtBalLandForAllotmentArea.Text = ds.Tables[0].Rows[0]["BalLandForAllotmentArea"].ToString();
                    txtUnderConstructionUnits.Text = ds.Tables[0].Rows[0]["UnderConstructionUnit"].ToString();
                    txtUnderConstructionArea.Text = ds.Tables[0].Rows[0]["UnderConstructionArea"].ToString();
                    txtConstructedFunctionalUnits.Text = ds.Tables[0].Rows[0]["ConstructedFunctionalUnit"].ToString();
                    txtConstructedFunctionalArea.Text = ds.Tables[0].Rows[0]["ConstructedFunctionalArea"].ToString();
                    txtSickClosedUnits.Text = ds.Tables[0].Rows[0]["SickClosedUnit"].ToString();
                    txtSickClosedArea.Text = ds.Tables[0].Rows[0]["SickClosedArea"].ToString();
                    txtNotStartedEvenconstructionunits.Text = ds.Tables[0].Rows[0]["NotStartedEvenconstructionUnit"].ToString();
                    txtNotStartedEvenconstructionArea.Text = ds.Tables[0].Rows[0]["NotStartedEvenconstructionArea"].ToString();
                    txtIARatePerSqmt.Text = ds.Tables[0].Rows[0]["RatePerSqm"].ToString();


                    btnSubmit.Text = "Update";
                    gridFunc();
                }
                else
                {
                    clear();
                    btnSubmit.Text = "Submit";
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
        private void Delete_QPRdetals(string id)
        {
            try
            {
                int result = objServiceTimelinesBLL.Delete_QPRdetals(id);
                if (result > 0)
                {
                    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage",
                    //"alert('QPR Details Delete Successfully'); window.location='" +
                    //Request.ApplicationPath + "QPRMaster.aspx';", true);
                    //return;
                    //MessageBox1.ShowSuccess("QPR Delete successfully");
                    //Response.Redirect("/QPRMaster.aspx");
                    gridFunc();
                }
                else
                {
                    //MessageBox1.ShowError("Some Error Occured");
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gridFunc();
        }

        protected void gridQPR_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}
