using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class PlotMaster : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
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
                UserSpecificBinding();
                BindDropdowns();
            }
            if (!IsPostBack)
            {
                DisabledControls();
            }
        }


        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }
        private DataTable Getdata4
        {
            get; set;
        }
        private DataTable Getdata5
        {
            get; set;
        }
        private DataTable Getdata6
        {
            get; set;
        }
        private DataTable Getdata7
        {
            get; set;
        }

        protected void BindDropdowns()
        {
            DataSet ds = new DataSet();
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            try
            {

                ds = objServiceTimelinesBLL.GetPlotStatusNew();
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }
                if (ds.Tables[3].Rows.Count > 0) { Getdata4 = ds.Tables[3]; }
                if (ds.Tables[4].Rows.Count > 0) { Getdata5 = ds.Tables[4]; }
                if (ds.Tables[5].Rows.Count > 0) { Getdata6 = ds.Tables[5]; }
                //  if (ds.Tables[6].Rows.Count > 0) { Getdata7 = ds.Tables[6]; }
                if (Getdata1.Rows.Count > 0)
                {
                    drpStatus.DataSource = Getdata1;
                    drpStatus.DataTextField = "PlotStatusDesc";
                    drpStatus.DataValueField = "PlotStatusID";
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, new ListItem("--Select--", "0"));
                }


                if (Getdata4.Rows.Count > 0)
                {
                    drpApplicableLocation.DataSource = Getdata4;
                    drpApplicableLocation.DataTextField = "locationchargedescription";
                    drpApplicableLocation.DataValueField = "ID";
                    drpApplicableLocation.DataBind();
                    drpApplicableLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                if (Getdata5.Rows.Count > 0)
                {
                    drpLandUse.DataSource = Getdata5;
                    drpLandUse.DataTextField = "UseZone";
                    drpLandUse.DataValueField = "ID";
                    drpLandUse.DataBind();
                    drpLandUse.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                if (Getdata6.Rows.Count > 0)
                {
                    drppermisesUse.DataSource = Getdata6;
                    drppermisesUse.DataTextField = "PermisesUse";
                    drppermisesUse.DataValueField = "ID";
                    drppermisesUse.DataBind();
                    drppermisesUse.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured111 :" + ex.Message.ToString()); }
        }

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
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        protected void Regional_Changed(object sender, EventArgs e)

        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }



        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIANew(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();

                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }

        }

        private DataTable Getdata1
        {
            get; set;
        }

        public void BindlstPlotsListbox()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                objServiceTimelinesBEL.SectorID = Int32.Parse(drpdwnSector.SelectedValue.ToString());



                ds = objServiceTimelinesBLL.BindlstPlotsInListbox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();

                    // color based on values
                    DataRow[] rows = Getdata1.Select("ForColor='" + 1 + "'");

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }

        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {

            bindSector(Convert.ToInt32(drpdwnIA.SelectedValue.Trim()), null);

        }



        private void bindSector(int IAID, string Sector)
        {
            objServiceTimelinesBEL.IAId = IAID;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSectorsIAWise(objServiceTimelinesBEL);
                drpdwnSector.DataSource = ds;
                drpdwnSector.DataTextField = "Sector_Name";
                drpdwnSector.DataValueField = "SectorID";
                drpdwnSector.DataBind();

                if (!string.IsNullOrEmpty(Sector))
                {
                    drpdwnSector.SelectedIndex = drpdwnSector.Items.IndexOf(drpdwnSector.Items.FindByText(Sector));
                }

                try { drpdwnSector_SelectedIndexChanged(null, null); } catch { }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }


        private void BindDirectivePlots()
        {
            objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
            objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllLandBank(objServiceTimelinesBEL);
                drpeast.DataSource = ds;
                drpeast.DataTextField = "PlotNo";
                drpeast.DataValueField = "PlotUniqueID";
                drpeast.DataBind();
                drpeast.Items.Insert(0, new ListItem("--Select--", "0"));

                drpWest.DataSource = ds;
                drpWest.DataTextField = "PlotNo";
                drpWest.DataValueField = "PlotUniqueID";
                drpWest.DataBind();
                drpWest.Items.Insert(0, new ListItem("--Select--", "0"));

                drpNorth.DataSource = ds;
                drpNorth.DataTextField = "PlotNo";
                drpNorth.DataValueField = "PlotUniqueID";
                drpNorth.DataBind();
                drpNorth.Items.Insert(0, new ListItem("--Select--", "0"));

                drpSouth.DataSource = ds;
                drpSouth.DataTextField = "PlotNo";
                drpSouth.DataValueField = "PlotUniqueID";
                drpSouth.DataBind();
                drpSouth.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }



        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {


                if (e.CommandName == "Select")
                {
                    txtNorth.Visible = true;
                    drpNorth.Visible = false;

                    txtSouth.Visible = true;
                    drpSouth.Visible = false;

                    txtEast.Visible = true;
                    drpeast.Visible = false;

                    txtWest.Visible = true;
                    drpWest.Visible = false;
                    txtBoxDefaulter.Text = String.Empty;
                    DisabledControls();
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    txtPlotNo.Text = GridView2.DataKeys[rowIndex].Values[0].ToString();
                    txtArea.Text = GridView2.DataKeys[rowIndex].Values["PlotArea"].ToString();
                    drpNorth.ClearSelection();
                    drpSouth.ClearSelection();
                    drpeast.ClearSelection();
                    drpWest.ClearSelection();

                    //  drpNorth.SelectedIndex = drpNorth.Items.IndexOf(drpNorth.Items.FindByText(GridView2.DataKeys[rowIndex].Values["NORTH"].ToString().Trim()));
                    //  drpSouth.SelectedIndex = drpSouth.Items.IndexOf(drpSouth.Items.FindByText(GridView2.DataKeys[rowIndex].Values["SOUTH"].ToString().Trim()));
                    // drpeast.SelectedIndex = drpeast.Items.IndexOf(drpeast.Items.FindByText(GridView2.DataKeys[rowIndex].Values["EAST"].ToString().Trim()));
                    // drpWest.SelectedIndex = drpWest.Items.IndexOf(drpWest.Items.FindByText(GridView2.DataKeys[rowIndex].Values["WEST"].ToString().Trim()));

                    txtNorth.Text = GridView2.DataKeys[rowIndex].Values["NORTH"].ToString();
                    txtSouth.Text = GridView2.DataKeys[rowIndex].Values["SOUTH"].ToString();
                    txtEast.Text = GridView2.DataKeys[rowIndex].Values["EAST"].ToString();
                    txtWest.Text = GridView2.DataKeys[rowIndex].Values["WEST"].ToString();
                    txtRemarks.Text = GridView2.DataKeys[rowIndex].Values["Remarks"].ToString();
                    if (GridView2.DataKeys[rowIndex].Values["LandUse"].ToString().Length > 0)
                    { drpLandUse.SelectedValue = GridView2.DataKeys[rowIndex].Values["landuseCode"].ToString(); }
                    else { drpLandUse.SelectedIndex = 0; }

                    txtBoxDefaulter.Text = GridView2.DataKeys[rowIndex].Values["ReservedCategory"].ToString();

                    if (GridView2.DataKeys[rowIndex].Values["Status"].ToString().Length > 0)
                    { drpStatus.SelectedValue = GridView2.DataKeys[rowIndex].Values["Status"].ToString(); }
                    else { drpStatus.SelectedIndex = 0; }
                    drpStatus_SelectedIndexChanged(null, null);

                    if (GridView2.DataKeys[rowIndex].Values["plotSubstatus"].ToString().Length > 0)
                    { drpSubStatus.SelectedValue = GridView2.DataKeys[rowIndex].Values["SUBSTATUS"].ToString(); }
                    else { drpSubStatus.SelectedIndex = -1; }
                    if (GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString().Length > 0)
                    {
                        if (GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString() == "True")
                        {
                            drplock.SelectedValue = "1";
                        }
                        else if (GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString() == "False")
                        {
                            drplock.SelectedValue = "0";
                        }
                    }

                    if (GridView2.DataKeys[rowIndex].Values["permisesUse"].ToString().Length > 0)
                    { drppermisesUse.SelectedValue = GridView2.DataKeys[rowIndex].Values["permisesUse"].ToString(); }
                    else { drppermisesUse.SelectedIndex = 0; }

                    if (GridView2.DataKeys[rowIndex].Values["ApplicableLocationCharge"].ToString().Length > 0)
                    { drpApplicableLocation.SelectedValue = GridView2.DataKeys[rowIndex].Values["ApplicableLocationCharge"].ToString(); }
                    else { drpApplicableLocation.SelectedIndex = 0; }

                    lblLockStatus.Text = GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString();
                    BindDirectivePlots();

                }
            }
            catch (Exception ex)
            {


            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    string Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ForColor"));
                    e.Row.Attributes["style"] = "background-color:" + Status;


                }


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);

                    e.Row.ToolTip = "Click to select this row.";


                }













            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Exception Message", "alert('You have an exception,please consult IT Team')", true);
            }

        }


        protected void Save_menu_ServerClick(object sender, EventArgs e)
        {
            if (txtPlotNo.Text == "")
            {
                if (txtPlotNo.Enabled == true)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Plot Number');", true); return;
                }
                else
                { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Operation Cannot Be Performed');", true); return; }
            }
            else
            {
                if (txtArea.Enabled == true)
                {
                    if (txtPlotNo.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Plot Number');", true); return; }
                    if (txtArea.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Plot Area');", true); return; }
                    if (drpLandUse.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Land Use');", true); return; }
                    if (drpSouth.SelectedValue == "Other")
                    {
                        if (txtSouth.Text.Length == 0)
                        { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in South');", true); return; }
                    }
                    else
                    {
                        if (drpSouth.SelectedIndex == 0)
                        { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in South');", true); return; }
                    }
                    if (drpNorth.SelectedValue == "Other")
                    {
                        if (txtNorth.Text.Length == 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in North');", true); return;
                        }
                    }
                    else
                    {
                        if (drpNorth.SelectedIndex == 0)
                        { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in North');", true); return; }
                    }
                    if (drpeast.SelectedValue == "Other")
                    {
                        if (txtEast.Text.Length == 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in East');", true); return;
                        }
                    }
                    else
                    {
                        if (drpeast.SelectedIndex == 0)
                        { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in East');", true); return; }
                    }
                    if (drpWest.SelectedValue == "Other")
                    {
                        if (txtWest.Text.Length == 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in West');", true); return;
                        }
                    }
                    else
                    {
                        if (drpWest.SelectedIndex == 0)
                        { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in West');", true); return; }
                    }
                    if (drpStatus.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Status');", true); return; }
                    if (drpSubStatus.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Sub Status');", true); return; }
                    if (drpSubStatus.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Sub Status');", true); return; }
                    if (drppermisesUse.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Premises Use');", true); return; }
                    if (drpApplicableLocation.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Application Location Charge');", true); return; }
                    btnSave_Click(null, null);

                }
            }


        }



        private void SaveDetails()
        {

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                objServiceTimelinesBEL.PlotArea = Convert.ToDecimal(txtArea.Text.Trim());
                objServiceTimelinesBEL.LandUse = Convert.ToInt32(drpLandUse.SelectedValue.Trim());
                objServiceTimelinesBEL.Category = 0;
                objServiceTimelinesBEL.PlotStatus = Convert.ToInt32(drpStatus.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotSubStatus = Convert.ToInt32(drpSubStatus.SelectedValue.Trim());
                objServiceTimelinesBEL.PremisesUse = Convert.ToInt32(drppermisesUse.SelectedValue.Trim());
                objServiceTimelinesBEL.ApplicableLocCharge = Convert.ToInt32(drpApplicableLocation.SelectedValue.Trim());
                objServiceTimelinesBEL.LockStatus = Convert.ToInt32(drplock.SelectedValue.Trim());

                if (drpNorth.SelectedValue == "Other")
                {
                    objServiceTimelinesBEL.FrontSide = txtNorth.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.FrontSide = drpNorth.SelectedItem.Text.Trim();
                }

                if (drpSouth.SelectedValue == "Other")
                {
                    objServiceTimelinesBEL.BackSide = txtSouth.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.BackSide = drpSouth.SelectedItem.Text.Trim();
                }
                if (drpeast.SelectedValue == "Other")
                {
                    objServiceTimelinesBEL.Side1 = txtEast.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.Side1 = drpeast.SelectedItem.Text.Trim();
                }
                if (drpWest.SelectedValue == "Other")
                {
                    objServiceTimelinesBEL.Side2 = txtWest.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.Side2 = drpWest.SelectedItem.Text.Trim();
                }

                objServiceTimelinesBEL.PlotRemark = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();


                int Result = objServiceTimelinesBLL.PlotEntryInPlotMasterNew(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot Inserted/Updated Successfully');", true);
                    DisabledControls();
                    BindlstPlotsListbox();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error During The Process');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;
            }

        }

        private void DisabledControls()
        {
            txtPlotNo.Enabled = false;
            txtArea.Enabled = false;
            drpLandUse.Enabled = false;
            txtBoxDefaulter.Enabled = false;
            drpStatus.Enabled = false;
            drpSubStatus.Enabled = false;
            txtNorth.Enabled = false;
            txtSouth.Enabled = false;
            txtEast.Enabled = false;
            txtWest.Enabled = false;
            drpeast.Enabled = false;
            drpWest.Enabled = false;
            drpNorth.Enabled = false;
            drpSouth.Enabled = false;
            drppermisesUse.Enabled = false;
            drplock.Enabled = false;
            drpApplicableLocation.Enabled = false;
            txtRemarks.Enabled = false;
        }


        protected void menuedit_ServerClick(object sender, EventArgs e)
        {
            if (Level == "RM")
            {
                if (txtPlotNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot To Edit');", true);
                    return;
                }
                else
                {
                    txtArea.Enabled = true;
                    drpLandUse.Enabled = true;
                    txtBoxDefaulter.Enabled = false;
                    drpStatus.Enabled = true;
                    drpSubStatus.Enabled = true;
                    txtNorth.Enabled = true;
                    txtSouth.Enabled = true;
                    txtEast.Enabled = true;
                    txtWest.Enabled = true;
                    drpeast.Enabled = true;
                    drpWest.Enabled = true;
                    drpSouth.Enabled = true;
                    drpNorth.Enabled = true;
                    drppermisesUse.Enabled = true;
                    if (Level == "RM")
                    {
                        drplock.Enabled = true;
                    }
                    drpApplicableLocation.Enabled = true;
                    txtRemarks.Enabled = true;
                    txtRemarks.Text = "";
                    drpNorth.Visible = true;
                    txtNorth.Visible = false;
                    drpSouth.Visible = true;
                    txtSouth.Visible = false;
                    drpeast.Visible = true;
                    txtEast.Visible = false;
                    drpWest.Visible = true;
                    txtWest.Visible = false;


                }
            }
            else
            {

                if (lblLockStatus.Text == "False")
                {
                    if (txtPlotNo.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot To Edit');", true);
                        return;
                    }
                    else
                    {
                        txtArea.Enabled = true;
                        drpLandUse.Enabled = true;

                        drpStatus.Enabled = true;
                        drpSubStatus.Enabled = true;
                        txtNorth.Enabled = true;
                        txtSouth.Enabled = true;
                        txtEast.Enabled = true;
                        txtWest.Enabled = true;
                        drpeast.Enabled = true;
                        drpWest.Enabled = true;
                        drpSouth.Enabled = true;
                        drpNorth.Enabled = true;
                        drppermisesUse.Enabled = true;
                        if (Level == "RM")
                        {
                            drplock.Enabled = true;
                        }
                        drpApplicableLocation.Enabled = true;
                        txtRemarks.Enabled = true;
                        drpNorth.Visible = true;
                        txtNorth.Visible = false;

                        drpSouth.Visible = true;
                        txtSouth.Visible = false;
                        drpeast.Visible = true;
                        txtEast.Visible = false;
                        drpWest.Visible = true;
                        txtWest.Visible = false;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Data Is Locked Cannot Be Edited');", true);
                    return;
                }


            }
        }

        protected void menunew_ServerClick(object sender, EventArgs e)
        {
            txtPlotNo.Enabled = true;
            txtPlotNo.Text = "";
            txtArea.Enabled = true;
            txtArea.Text = "";
            drpLandUse.SelectedIndex = 0;
            drpLandUse.Enabled = true;
            txtBoxDefaulter.Enabled = false;
            txtBoxDefaulter.Text = "";

            drpStatus.SelectedIndex = 0;
            drpStatus.Enabled = true;
            drpSubStatus.SelectedIndex = -1;
            drpSubStatus.Enabled = true;
            txtNorth.Enabled = true;
            txtNorth.Text = "";
            txtSouth.Enabled = true;
            txtSouth.Text = "";
            txtEast.Enabled = true;
            txtEast.Text = "";
            txtWest.Enabled = true;
            txtWest.Text = "";
            drppermisesUse.SelectedIndex = 0;
            drppermisesUse.Enabled = true;
            if (Level == "RM")
            {
                drplock.Enabled = true;
            }
            drpApplicableLocation.SelectedIndex = 0;
            drpApplicableLocation.Enabled = true;
            txtRemarks.Enabled = true;
            drpeast.Enabled = true;
            drpWest.Enabled = true;
            drpSouth.Enabled = true;
            drpNorth.Enabled = true;


            drpNorth.Visible = true;
            txtNorth.Visible = false;
            drpSouth.Visible = true;
            txtSouth.Visible = false;
            drpeast.Visible = true;
            txtEast.Visible = false;
            drpWest.Visible = true;
            txtWest.Visible = false;
            BindDirectivePlots();

        }


        private void DeletePlot()
        {

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];


                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());


                int Result = objServiceTimelinesBLL.DeletePlotInPlotMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot Inactive Successfully');", true);
                    DisabledControls();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error During The Process');", true);
                    return;
                }




            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;
            }

        }

        protected void menudelete_ServerClick(object sender, EventArgs e)
        {
            if (txtPlotNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Choose Plot To Inactive');", true);
                return;
            }
            else
            {
                if (txtPlotNo.Enabled == false)
                {
                    DeletePlot();
                    Response.Redirect(Request.RawUrl);
                }

            }

        }

        protected void refresh_menu_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (drpLandUse.SelectedValue == "1" || drpLandUse.SelectedValue == "2" || drpLandUse.SelectedValue == "3")
            {

                objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.LandUse = Convert.ToInt32(drpLandUse.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotArea = Convert.ToDecimal(txtArea.Text.Trim());
                objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                DataSet ds1 = new DataSet();

                ds1 = objServiceTimelinesBLL.GetIALandLimits(objServiceTimelinesBEL);

                DataTable dt = ds1.Tables[0];

                decimal Max_value = Convert.ToDecimal(dt.Rows[0]["MaxValue"].ToString());
                decimal value = Convert.ToDecimal(dt.Rows[0]["Value"].ToString());
                decimal currentVal = value + Convert.ToDecimal(txtArea.Text.Trim());

                if (currentVal > Max_value)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Land Area Exceeding Industrial Area Limit');", true);
                    return;
                }
                else
                {
                    SaveDetails();
                }


            }
            else
            {
                SaveDetails();
            }




        }

        protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objServiceTimelinesBEL.PlotStatus = Convert.ToInt32(drpStatus.SelectedValue.Trim());
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.GetPlotSubStatus(objServiceTimelinesBEL);
                drpSubStatus.DataSource = ds;
                drpSubStatus.DataTextField = "PlotStatusName";
                drpSubStatus.DataValueField = "PlotSubStatusID";
                drpSubStatus.DataBind();
                drpSubStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void drpdwnSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindlstPlotsListbox();
            BindDirectivePlots();
        }

        protected void drpLandUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtArea.Text.Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Plot Area');", true);
                    drpLandUse.ClearSelection();
                    return;
                }
                objServiceTimelinesBEL.Parameter = drpLandUse.SelectedItem.Text.Trim();
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.GetPlotcategoryLandUseWise(objServiceTimelinesBEL);
                drppermisesUse.DataSource = ds;
                drppermisesUse.DataTextField = "PermisesUse";
                drppermisesUse.DataValueField = "ID";
                drppermisesUse.DataBind();
                drppermisesUse.Items.Insert(0, new ListItem("--Select--", "0"));

                if (drpLandUse.SelectedValue == "1" || drpLandUse.SelectedValue == "2" || drpLandUse.SelectedValue == "3")
                {

                    objServiceTimelinesBEL.IAID = drpdwnIA.SelectedValue.Trim();
                    objServiceTimelinesBEL.LandUse = Convert.ToInt32(drpLandUse.SelectedValue.Trim());
                    objServiceTimelinesBEL.PlotArea = Convert.ToDecimal(txtArea.Text.Trim());
                    objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                    DataSet ds1 = new DataSet();

                    ds1 = objServiceTimelinesBLL.GetIALandLimits(objServiceTimelinesBEL);

                    DataTable dt = ds1.Tables[0];

                    decimal Max_value = Convert.ToDecimal(dt.Rows[0]["MaxValue"].ToString());
                    decimal value = Convert.ToDecimal(dt.Rows[0]["Value"].ToString());


                    if (value > Max_value)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Land Area Exceeding Industrial Area Limit');", true);
                        return;
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void drpNorth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpNorth.SelectedValue == "Other")
            {
                drpNorth.Visible = false;
                txtNorth.Visible = true;
            }
            else
            {
                drpNorth.Visible = true;
                txtNorth.Visible = false;
            }
        }

        protected void drpSouth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSouth.SelectedValue == "Other")
            {
                drpSouth.Visible = false;
                txtSouth.Visible = true;
            }
            else
            {
                drpSouth.Visible = true;
                txtSouth.Visible = false;
            }
        }

        protected void drpeast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpeast.SelectedValue == "Other")
            {
                drpeast.Visible = false;
                txtEast.Visible = true;
            }
            else
            {
                drpeast.Visible = true;
                txtEast.Visible = false;
            }
        }

        protected void drpWest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpWest.SelectedValue == "Other")
            {
                drpWest.Visible = false;
                txtWest.Visible = true;
            }
            else
            {
                drpWest.Visible = true;
                txtWest.Visible = false;
            }
        }
    }
}