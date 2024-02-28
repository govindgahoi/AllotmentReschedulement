using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using ClosedXML.Excel;

namespace Allotment
{
    public partial class PlotBank : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion

        string UserName = string.Empty;
        int UserID;

        string Level = string.Empty;



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserID = _objLoginInfo.userid;
                GeneralMethod gm1 = new GeneralMethod();
                Level = gm1.GetUserDesignation(UserID);
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                this.RegisterPostBackControl();
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

                ds = objServiceTimelinesBLL.GetPlotStatus();
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
                //ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));
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
                //drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));
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

        }
        protected void drpdwnSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_ModalIA.Text = drpdwnIA.SelectedItem.Text;
            lbl_ModalRegionalOffice.Text = ddloffice.SelectedItem.Text;
            lbl_ModalSector.Text = drpdwnSector.SelectedItem.Text;
            BindlstPlotsListbox();
            

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
                objServiceTimelinesBEL.Parameter = DropDownList1.SelectedValue.Trim();
                ds = objServiceTimelinesBLL.BindlstPlotsListbox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    lblNo.Text = Getdata1.Rows.Count.ToString();
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();

                    DataRow[] rows = Getdata1.Select("ForColor='" + 1 + "'");

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                Response.Write("Oops! error occured2 :" + ex.Message.ToString());
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {


                if (e.CommandName == "Select")
                {
                    txtBoxDefaulter.Text = String.Empty;
                    DisabledControls();
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    lblPlotID.Text = GridView2.DataKeys[rowIndex].Values[0].ToString();
                    txtPlotNo.Text = GridView2.DataKeys[rowIndex].Values[1].ToString();
                    BindDirectivePlots();

                    drpNorth.SelectedIndex = drpNorth.Items.IndexOf(drpNorth.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["NorthID"].ToString().Trim()));
                    drpSouth.SelectedIndex = drpSouth.Items.IndexOf(drpSouth.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["SouthID"].ToString().Trim()));
                    drpeast.SelectedIndex = drpeast.Items.IndexOf(drpeast.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["EastID"].ToString().Trim()));
                    drpWest.SelectedIndex = drpWest.Items.IndexOf(drpWest.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["WestID"].ToString().Trim()));
                    txtArea.Text = GridView2.DataKeys[rowIndex].Values["PlotArea"].ToString();
                    txtFrontSide.Text = GridView2.DataKeys[rowIndex].Values["NORTH"].ToString();
                    txtBackSide.Text = GridView2.DataKeys[rowIndex].Values["SOUTH"].ToString();
                    txtSide1.Text = GridView2.DataKeys[rowIndex].Values["EAST"].ToString();
                    txtSide2.Text = GridView2.DataKeys[rowIndex].Values["WEST"].ToString();
                    txtRemarks.Text = GridView2.DataKeys[rowIndex].Values["Remarks"].ToString();
                    string Traciing = GridView2.DataKeys[rowIndex].Values["TracingName"].ToString();
                    string JC      = GridView2.DataKeys[rowIndex].Values["JoinCertificateName"].ToString();

                    if(Traciing.Length>0)
                    {
                        btnView.Visible = true;
                    }
                    else
                    {
                        btnView.Visible = false;
                    }

                    if(JC.Length>0)
                    {
                        jc_Div.Visible = true;
                    }
                    else
                    {
                        jc_Div.Visible = false;
                    }

                    if (GridView2.DataKeys[rowIndex].Values["LandUse"].ToString().Length > 0)
                    {
                        drpLandUse.SelectedValue = GridView2.DataKeys[rowIndex].Values["landuseCode"].ToString();
                    }
                    else
                    {
                        drpLandUse.SelectedIndex = 0;
                    }

                    txtBoxDefaulter.Text = GridView2.DataKeys[rowIndex].Values["ReservedCategory"].ToString();

                    if (GridView2.DataKeys[rowIndex].Values["Status"].ToString().Length > 0)
                    {
                        drpStatus.SelectedValue = GridView2.DataKeys[rowIndex].Values["Status"].ToString();
                    }
                    else
                    {
                        drpStatus.SelectedIndex = 0;
                    }

                    drpStatus_SelectedIndexChanged(null, null);

                    if (GridView2.DataKeys[rowIndex].Values["plotSubstatus"].ToString().Length > 0)
                    {
                        drpSubStatus.SelectedValue = GridView2.DataKeys[rowIndex].Values["SUBSTATUS"].ToString();
                    }
                    else
                    {
                        drpSubStatus.SelectedIndex = -1;
                    }
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
                    {
                        drppermisesUse.SelectedValue = GridView2.DataKeys[rowIndex].Values["permisesUse"].ToString();
                    }
                    else
                    {
                        drppermisesUse.SelectedIndex = 0;
                    }

                    if (GridView2.DataKeys[rowIndex].Values["ApplicableLocationCharge"].ToString().Length > 0)
                    {
                        drpApplicableLocation.SelectedValue = GridView2.DataKeys[rowIndex].Values["ApplicableLocationCharge"].ToString();
                    }
                    else
                    {
                        drpApplicableLocation.SelectedIndex = 0;
                    }

                    lblLockStatus.Text = GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString();
                    txtAssetValue.Text = GridView2.DataKeys[rowIndex].Values["AssetValue"].ToString();
                    txtAssetDesc.Text = GridView2.DataKeys[rowIndex].Values["AssetDescription"].ToString();

                    string Asset = GridView2.DataKeys[rowIndex].Values["AssetStatus"].ToString();
                    if (Asset == "True")
                    {
                        DdlAssetStatus.SelectedValue = "1";
                        AssetDiv.Visible = true;
                    }
                    else
                    {
                        DdlAssetStatus.SelectedValue = "0";
                        AssetDiv.Visible = false;
                    }
                    Tracing.Visible = true;
                    
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
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand'";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                if (row.RowIndex == GridView2.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

      
        protected void Save_menu_ServerClick(object sender, EventArgs e)
        {
            if (txtPlotNo.Text == "")
            {
                if (txtPlotNo.Enabled == true)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Plot Number');", true);
                    return;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Operation Cannot Be Performed');", true);
                    return;
                }
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
                    if (drpStatus.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Status');", true); return; }
                    if (drpSubStatus.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Sub Status');", true); return; }
                    if (drpSubStatus.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot Sub Status');", true); return; }
                    if (drpSouth.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in South');", true); return; }
                    if (drpNorth.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in North');", true); return; }
                    if (drpeast.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in East');", true); return; }
                    if (drpWest.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in West');", true); return; }

                    if (drppermisesUse.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Premises Use');", true); return; }
                    if (drpApplicableLocation.SelectedIndex == 0 || drpSubStatus.SelectedIndex == -1)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Application Location Charge');", true); return; }
                    SaveDetails();

                }
            }


        }



        private void SaveDetails()
        {

            try
            {
                if (drpStatus.SelectedValue.Trim() == "1")
                {
                    SqlCommand cmd = new SqlCommand("Select * from AllotteeMaster where PlotNo='" + txtPlotNo.Text.Trim() + "' and IndustrialArea='" + drpdwnIA.SelectedItem.Text.Trim() + "' and isnull(isCompleted,0)=1", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot is still Allocated to an allotee. Cannot Set Available for Allotment');", true);
                        return;
                    }
                }


                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.IAId                = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.SectorID            = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo              = txtPlotNo.Text.Trim();
                objServiceTimelinesBEL.PlotArea            = Convert.ToDecimal(txtArea.Text.Trim());
                objServiceTimelinesBEL.LandUse             = Convert.ToInt32(drpLandUse.SelectedValue.Trim());
                objServiceTimelinesBEL.Category            = 0;
                objServiceTimelinesBEL.PlotStatus          = Convert.ToInt32(drpStatus.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotSubStatus       = Convert.ToInt32(drpSubStatus.SelectedValue.Trim());
                objServiceTimelinesBEL.PremisesUse         = Convert.ToInt32(drppermisesUse.SelectedValue.Trim());
                objServiceTimelinesBEL.ApplicableLocCharge = Convert.ToInt32(drpApplicableLocation.SelectedValue.Trim());
                objServiceTimelinesBEL.LockStatus          = Convert.ToInt32(drplock.SelectedValue.Trim());
                objServiceTimelinesBEL.FrontSide           = drpNorth.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.BackSide            = drpSouth.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Side1               = drpeast.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Side2               = drpWest.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.PlotRemark          = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.CreatedBy           = _objLoginInfo.userName.ToString();
                objServiceTimelinesBEL.AssetStatus         = DdlAssetStatus.SelectedValue.Trim();
                objServiceTimelinesBEL.AssetDesc           = txtAssetDesc.Text.Trim();
                objServiceTimelinesBEL.AssetValue          = txtAssetValue.Text.Trim();
                objServiceTimelinesBEL.NorthID             = drpNorth.SelectedValue.Trim();
                objServiceTimelinesBEL.EastID              = drpeast.SelectedValue.Trim();
                objServiceTimelinesBEL.WestID              = drpWest.SelectedValue.Trim();
                objServiceTimelinesBEL.SouthID             = drpSouth.SelectedValue.Trim();
                objServiceTimelinesBEL.LAName              = Convert.ToString(Session["TracingName"]);
                objServiceTimelinesBEL.LAContentType       = Convert.ToString(Session["TracingExt"]);
                objServiceTimelinesBEL.LADocumentsMap      = Session["Tracing"] as byte[];


                int Result = objServiceTimelinesBLL.PlotEntryInPlotMaster(objServiceTimelinesBEL);
                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot Inserted/Updated Successfully');", true);
                    Clear();
                    DisabledControls();
                    BindlstPlotsListbox();
                    Tracing.Visible = true;
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
            txtFrontSide.Enabled = false;
            txtBackSide.Enabled = false;
            txtSide1.Enabled = false;
            txtSide2.Enabled = false;
            drppermisesUse.Enabled = false;
            drplock.Enabled = false;
            drpApplicableLocation.Enabled = false;
            txtRemarks.Enabled = false;
            DdlAssetStatus.Enabled = false;
            txtAssetDesc.Enabled = false;
            txtAssetValue.Enabled = false;
            btnupload.Enabled = false;
            drpSouth.Enabled = false;
            drpNorth.Enabled = false;
            drpeast.Enabled = false;
            drpWest.Enabled = false;

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
                    txtFrontSide.Enabled = true;
                    txtBackSide.Enabled = true;
                    txtSide1.Enabled = true;
                    txtSide2.Enabled = true;
                    drppermisesUse.Enabled = true;
                    txtAssetValue.Enabled = true;
                    txtAssetDesc.Enabled = true;
                    DdlAssetStatus.Enabled = true;
                    if (Level == "RM")
                    {
                        drplock.Enabled = true;
                    }
                    drpApplicableLocation.Enabled = true;
                    txtRemarks.Enabled = true;
                    btnupload.Enabled = true;
                    btnView.Enabled = true;
                    Tracing.Visible = true;
                    drpNorth.Enabled = true;
                    drpSouth.Enabled = true;
                    drpeast.Enabled = true;
                    drpWest.Enabled = true;
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
                        //drpCategory.Enabled = true;
                        drpStatus.Enabled = true;
                        drpSubStatus.Enabled = true;
                        txtFrontSide.Enabled = true;
                        txtBackSide.Enabled = true;
                        txtSide1.Enabled = true;
                        txtSide2.Enabled = true;
                        drppermisesUse.Enabled = true;
                        txtAssetDesc.Enabled = true;
                        txtAssetValue.Enabled = true;
                        DdlAssetStatus.Enabled = true;
                        if (Level == "RM")
                        {
                            drplock.Enabled = true;
                        }
                        drpApplicableLocation.Enabled = true;
                        txtRemarks.Enabled = true;
                        btnupload.Enabled = true;
                        btnView.Enabled = true;
                        Tracing.Visible = true;
                        drpNorth.Enabled = true;
                        drpSouth.Enabled = true;
                        drpeast.Enabled = true;
                        drpWest.Enabled = true;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Data Is Locked Cannot Be Edited');", true);
                    return;
                }


            }
        }


        private void Clear()
        {
            lblMessageError.Text = "";
            lblMessageError.Visible = false;
            txtPlotNo.Text = "";
            txtArea.Text = "";
            drpLandUse.SelectedIndex = 0;
            txtBoxDefaulter.Text = "";
            drpStatus.SelectedIndex = 0;
            drpSubStatus.SelectedIndex = -1;
            txtFrontSide.Text = "";
            txtBackSide.Text = "";
            txtSide1.Text = "";
            txtSide2.Text = "";
            drppermisesUse.SelectedIndex = 0;
            drpApplicableLocation.SelectedIndex = 0;
            drpNorth.SelectedIndex = 0;
            drpSouth.SelectedIndex = 0;
            drpeast.SelectedIndex = 0;
            drpWest.SelectedIndex = 0;
            btnView.Visible = false;
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
            //drpCategory.SelectedIndex = 0;
            //drpCategory.Enabled = true;
            drpStatus.SelectedIndex = 0;
            drpStatus.Enabled = true;
            drpSubStatus.SelectedIndex = -1;
            drpSubStatus.Enabled = true;
            txtFrontSide.Enabled = true;
            txtFrontSide.Text = "";
            txtBackSide.Enabled = true;
            txtBackSide.Text = "";
            txtSide1.Enabled = true;
            txtSide1.Text = "";
            txtSide2.Enabled = true;
            txtSide2.Text = "";
            drppermisesUse.SelectedIndex = 0;
            drppermisesUse.Enabled = true;
            if (Level == "RM")
            {
                drplock.Enabled = true;
            }
            drpApplicableLocation.SelectedIndex = 0;
            drpApplicableLocation.Enabled = true;
            txtRemarks.Enabled = true;
            txtAssetValue.Enabled = true;
            txtAssetDesc.Enabled = true;
            DdlAssetStatus.Enabled = true;
            btnupload.Enabled = true;
            drpNorth.Enabled = true;
            drpSouth.Enabled = true;
            drpeast.Enabled = true;
            drpWest.Enabled = true;
            Tracing.Visible = true;
            btnView.Visible = false;
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
                objServiceTimelinesBEL.SectorID = drpdwnSector.SelectedValue.Trim();



                int Result = objServiceTimelinesBLL.DeletePlotPlotMaster(objServiceTimelinesBEL);

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
                SqlCommand cmd = new SqlCommand("Select * from AllotteeMaster where PlotNo='" + txtPlotNo.Text.Trim() + "' and IndustrialArea='" + drpdwnIA.SelectedItem.Text.Trim() + "' and isnull(isCompleted,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot is still Allocated to an allotee. Cannot delete');", true);
                    return;
                }
                else
                {
                    DeletePlot();
                    BindlstPlotsListbox();
                    Clear();
                }

            }

        }

        protected void refresh_menu_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveDetails();
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

        protected void DdlAssetStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAssetStatus.SelectedItem.Text.Trim() == "YES")
            {
                AssetDiv.Visible = true;
            }
            else
            {
                AssetDiv.Visible = false;
            }
        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                objServiceTimelinesBEL.SectorID         = Int32.Parse(drpdwnSector.SelectedValue.ToString());
                objServiceTimelinesBEL.searchText       = txtSearch.Text;
                objServiceTimelinesBEL.Parameter        = DropDownList1.SelectedValue.Trim();

                ds = objServiceTimelinesBLL.BindlstPlotsListboxSearch(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();
                    lblNo.Text = Getdata1.Rows.Count.ToString();
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

        protected void btnView_Click(object sender, EventArgs e)
        {

            if (txtPlotNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select any Plot !');", true);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.PlotID = Convert.ToInt32(lblPlotID.Text.Trim());
                objServiceTimelinesBEL.Doctype = "T";

                ds = objServiceTimelinesBLL.GetTracingDocView(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Name = dtDoc.Rows[0]["TracingName"].ToString();
                if (Name.Length > 0)
                {
                    String js = "window.open('TracingDocViewer.aspx?PlotID=" + lblPlotID.Text.Trim() + "&DocType=T', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TracingDocViewer.aspx", js, true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Tracing Uploaded yet !');", true);
                    return;
                }
            }
        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnupload);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(excel_export);
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                int maxFileSize = 1;

                if (fileupload1.HasFile)
                {

                    // Read the file and convert it to Byte Array
                    string filePath = fileupload1.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = fileupload1.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                        return;
                    }

                    //Set the contenttype based on File Extension
                    switch (ext)
                    {

                        case ".pdf":
                            contenttype = "application/pdf";
                            break;
                        case ".PDF":
                            contenttype = "application/pdf";
                            break;

                    }

                    if (contenttype != String.Empty && ext == ".pdf")
                    {

                        Stream fs = fileupload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        objServiceTimelinesBEL.LAName = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;

                        Session["TracingName"] = objServiceTimelinesBEL.LAName;
                        Session["TracingExt"] = objServiceTimelinesBEL.content;
                        Session["Tracing"] = objServiceTimelinesBEL.Uploadfile;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        lbluploadingMsg.Visible = true;
                        return;

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                    lbluploadingMsg.Visible = true;
                    return;
                }

                //if (lblPlotID.Text.Length > 0)
                //{
                //    this.RegisterPostBackControl();
                //    int retval = 0;
                //    if (fileupload1.HasFile)
                //    {
                //        string filePath = fileupload1.PostedFile.FileName;
                //        string fleUpload = Path.GetExtension(fileupload1.FileName.ToString());
                //        string filename = Path.GetFileName(filePath);
                //        string contenttype = String.Empty;
                //        int fileSize = fileupload1.PostedFile.ContentLength;
                //        if (fileSize > (1 * 1024 * 1024))
                //        {
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                //            return;
                //        }
                //        switch (fleUpload)
                //        {
                //            case ".jpg":
                //                contenttype = "image/jpg";
                //                break;
                //            case ".pdf":
                //                contenttype = "application/pdf";
                //                break;
                //            case ".PDF":
                //                contenttype = "application/pdf";
                //                break;

                //        }
                //        if (contenttype != String.Empty)
                //        {
                //            Stream fs = fileupload1.PostedFile.InputStream;
                //            BinaryReader br = new BinaryReader(fs);
                //            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                //            objServiceTimelinesBEL.filename = filename;
                //            objServiceTimelinesBEL.content = contenttype;
                //            objServiceTimelinesBEL.Uploadfile = bytes;



                //        }
                //    }
                //    else
                //    {
                //        objServiceTimelinesBEL.filename = String.Empty;
                //        objServiceTimelinesBEL.content = String.Empty;
                //        objServiceTimelinesBEL.Uploadfile = null;
                //    }
                //    objServiceTimelinesBEL.PlotID = Convert.ToInt32(lblPlotID.Text.Trim());

                //    retval = objServiceTimelinesBLL.UploadTracing(objServiceTimelinesBEL);
                //    if (retval > 0)
                //    {

                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Tracing Uploaded Successfully !');", true);
                //        return;
                //    }
                //    else
                //    {

                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                //        return;
                //    }

                //}
                //else
                //{

                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('choose plot first');", true);
                //    return;
                //}

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btn_JCView_Click(object sender, EventArgs e)
        {
            if (txtPlotNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select any Plot !');", true);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.PlotID = Convert.ToInt32(lblPlotID.Text.Trim());
                objServiceTimelinesBEL.Doctype = "JC";

                ds = objServiceTimelinesBLL.GetTracingDocView(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Name = dtDoc.Rows[0]["JoinCertificateName"].ToString();
                if (Name.Length > 0)
                {
                    String js = "window.open('TracingDocViewer.aspx?PlotID=" + lblPlotID.Text.Trim() + "&DocType=JC', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TracingDocViewer.aspx", js, true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Joint Ceritficate Uploaded yet !');", true);
                    return;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txt_ModalPlotNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange('Plot No is must');", true);
                    return;
                }
                if (txt_ModalPlotARea.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange('Plot Area is must');", true);
                    return;
                }


                SqlCommand cmd = new SqlCommand("Select * from PlotMaster where PlotNumber='" + txt_ModalPlotNo.Text.Trim() + "' and IAID='" + drpdwnIA.SelectedValue.Trim() + "' and SectorID='"+drpdwnSector.SelectedValue.Trim()+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot Number already exist');", true);
                    return;
                }
               


                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.IAId      = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.SectorID  = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo    = txt_ModalPlotNo.Text.Trim();
                objServiceTimelinesBEL.PlotArea  = Convert.ToDecimal(txt_ModalPlotARea.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();
                int Result = objServiceTimelinesBLL.PlotEntryInPlotMasterInstant(objServiceTimelinesBEL);
                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Plot added Successfully');", true);
                    txt_ModalPlotNo.Text   = "";
                    txt_ModalPlotARea.Text = "";

                    BindlstPlotsListbox();
                    BindDirectivePlots();                 

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error During The Process');", true);
                    return;
                }
            }
            catch(Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;
            }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindlstPlotsListbox();
        }

        protected void excel_export_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllPlots '" + drpdwnIA.SelectedValue.Trim() + "','" + drpdwnSector.SelectedValue.Trim() + "','" + DropDownList1.SelectedValue.Trim() + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                using (XLWorkbook wb = new XLWorkbook())
                                {
                                    wb.Worksheets.Add(dt, "PendingRefunds");
                                    Response.Clear();
                                    Response.Buffer = true;
                                    Response.Charset = "";
                                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    Response.AddHeader("content-disposition", "attachment;filename=Plots" + DateTime.Now.ToString("dd-MMM-yyyy") + ".xlsx");
                                    using (MemoryStream MyMemoryStream = new MemoryStream())
                                    {
                                        wb.SaveAs(MyMemoryStream);
                                        MyMemoryStream.WriteTo(Response.OutputStream);
                                        Response.Flush();
                                        Response.End();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}