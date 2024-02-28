using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ParkMaster : System.Web.UI.Page
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
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                UserSpecificBinding();

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
                Response.Write("Oops! error occured3 :" + ex.Message.ToString());
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
                Response.Write("Oops! error occured4 :" + ex.Message.ToString());
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



                ds = objServiceTimelinesBLL.BindlstParksInListbox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    GridView2.DataSource = Getdata1;
                    GridView2.DataBind();



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
                Response.Write("Oops! error occured1 :" + ex.Message.ToString());
            }
        }


        private void BindDirectivePlots()
        {
            objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
            objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
            objServiceTimelinesBEL.PlotNo = txtParkNo.Text.Trim();
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
                   
                    DisabledControls();
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    txtParkNo.Text = GridView2.DataKeys[rowIndex].Values["ParkName"].ToString();
                    txtArea.Text = GridView2.DataKeys[rowIndex].Values["ParkArea"].ToString();
                    BindDirectivePlots();

                    drpNorth.SelectedIndex = drpNorth.Items.IndexOf(drpNorth.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["NORTH"].ToString().Trim()));
                    drpSouth.SelectedIndex = drpSouth.Items.IndexOf(drpSouth.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["SOUTH"].ToString().Trim()));
                    drpeast.SelectedIndex  = drpeast.Items.IndexOf(drpeast.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["EAST"].ToString().Trim()));
                    drpWest.SelectedIndex  = drpWest.Items.IndexOf(drpWest.Items.FindByValue(GridView2.DataKeys[rowIndex].Values["WEST"].ToString().Trim()));
                    drpParkdeveloped.SelectedIndex = drpParkdeveloped.Items.IndexOf(drpParkdeveloped.Items.FindByText(GridView2.DataKeys[rowIndex].Values["ParkDeveloped"].ToString().Trim()));
                    txtFrontSide.Text              = GridView2.DataKeys[rowIndex].Values["NORTH"].ToString();
                    txtBackSide.Text = GridView2.DataKeys[rowIndex].Values["SOUTH"].ToString();
                    txtSide1.Text = GridView2.DataKeys[rowIndex].Values["EAST"].ToString();
                    txtSide2.Text = GridView2.DataKeys[rowIndex].Values["WEST"].ToString();
                    txtRemarks.Text = GridView2.DataKeys[rowIndex].Values["Remarks"].ToString();

                    txtMaintainedBy.Text = GridView2.DataKeys[rowIndex].Values["MaintainedBy"].ToString();
                    txtNoOfTrees.Text = GridView2.DataKeys[rowIndex].Values["NoofTrees"].ToString();

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
                   
                    lblLockStatus.Text = GridView2.DataKeys[rowIndex].Values["ISLOCKED"].ToString();

                    
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

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void Save_menu_ServerClick(object sender, EventArgs e)
        {
            if (txtParkNo.Text == "")
            {
                if (txtParkNo.Enabled == true)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Park Number');", true); return;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Operation Cannot Be Performed');", true); return;
                }
            }
            else
            {
                if (txtArea.Enabled == true)
                {
                    if (txtParkNo.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Park Number');", true); return; }
                    if (txtArea.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Park Area');", true); return; }
                    if (drpParkdeveloped.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Park is developed or not');", true); return; }
                    if (drpSouth.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in South');", true); return; }
                    if (drpNorth.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in North');", true); return; }
                    if (drpeast.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in East');", true); return; }
                    if (drpWest.SelectedIndex == 0)
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select what is in West');", true); return; }
                    if (txtMaintainedBy.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Park is maintained by');", true); return; }
                    if (txtNoOfTrees.Text == "")
                    { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide No of trees');", true); return; }
                    SaveDetails();

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
                objServiceTimelinesBEL.PlotNo = txtParkNo.Text.Trim();
                objServiceTimelinesBEL.PlotArea = Convert.ToDecimal(txtArea.Text.Trim());
                objServiceTimelinesBEL.parkDeveloped = drpParkdeveloped.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.North = drpNorth.SelectedValue.Trim();
                objServiceTimelinesBEL.South = drpSouth.SelectedValue.Trim();
                objServiceTimelinesBEL.East = drpeast.SelectedValue.Trim();
                objServiceTimelinesBEL.West = drpWest.SelectedValue.Trim();
                objServiceTimelinesBEL.Nooftrees = Convert.ToInt32(txtNoOfTrees.Text.Trim());
                objServiceTimelinesBEL.MaintainedBy = txtMaintainedBy.Text.Trim();
                objServiceTimelinesBEL.PlotRemark = txtRemarks.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();


                int Result = objServiceTimelinesBLL.ParkEntryInParkMasterNew(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Park Inserted/Updated Successfully');", true);
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
            txtParkNo.Enabled = false;
            txtArea.Enabled = false;

            txtFrontSide.Enabled = false;
            txtBackSide.Enabled = false;
            txtSide1.Enabled = false;
            txtSide2.Enabled = false;
            drpeast.Enabled = false;
            drpWest.Enabled = false;
            drpNorth.Enabled = false;
            drpSouth.Enabled = false;
            drplock.Enabled = false;
            txtRemarks.Enabled = false;
            txtNoOfTrees.Enabled = false;
            drpParkdeveloped.Enabled = false;
            txtMaintainedBy.Enabled = false;
        }


        protected void menuedit_ServerClick(object sender, EventArgs e)
        {
            if (Level == "RM")
            {
                if (txtParkNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot To Edit');", true);
                    return;
                }
                else
                {
                    txtArea.Enabled = true;

                    txtFrontSide.Enabled = true;
                    txtBackSide.Enabled = true;
                    txtSide1.Enabled = true;
                    txtSide2.Enabled = true;
                    drpeast.Enabled = true;
                    drpWest.Enabled = true;
                    drpSouth.Enabled = true;
                    drpNorth.Enabled = true;
                    txtNoOfTrees.Enabled = true;
                    drpParkdeveloped.Enabled = true;
                    txtMaintainedBy.Enabled = true;

                    if (Level == "RM")
                    {
                        drplock.Enabled = true;
                    }

                    txtRemarks.Enabled = true;
                }
            }
            else
            {

                if (lblLockStatus.Text == "False")
                {
                    if (txtParkNo.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Plot To Edit');", true);
                        return;
                    }
                    else
                    {
                        txtArea.Enabled = true;

                        txtFrontSide.Enabled = true;
                        txtBackSide.Enabled = true;
                        txtSide1.Enabled = true;
                        txtSide2.Enabled = true;
                        drpeast.Enabled = true;
                        drpWest.Enabled = true;
                        drpSouth.Enabled = true;
                        drpNorth.Enabled = true;
                        txtNoOfTrees.Enabled = true;
                        drpParkdeveloped.Enabled = true;
                        txtMaintainedBy.Enabled = true;

                        if (Level == "RM")
                        {
                            drplock.Enabled = true;
                        }

                        txtRemarks.Enabled = true;
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
            txtParkNo.Enabled = true;
            txtParkNo.Text = "";
            txtArea.Enabled = true;
            txtArea.Text = "";

            txtFrontSide.Enabled = true;
            txtFrontSide.Text = "";
            txtBackSide.Enabled = true;
            txtBackSide.Text = "";
            txtSide1.Enabled = true;
            txtSide1.Text = "";
            txtSide2.Enabled = true;
            txtSide2.Text = "";

            if (Level == "RM")
            {
                drplock.Enabled = true;
            }

            txtRemarks.Enabled = true;
            drpeast.Enabled = true;
            drpWest.Enabled = true;
            drpSouth.Enabled = true;
            drpNorth.Enabled = true;
            txtNoOfTrees.Text = "";
            txtNoOfTrees.Enabled = true;
            drpParkdeveloped.Enabled = true;
            drpParkdeveloped.SelectedIndex = 0;
            txtMaintainedBy.Text = "";
            txtMaintainedBy.Enabled = true;
            txtRemarks.Text = "";
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
                objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo = txtParkNo.Text.Trim();


                int Result = objServiceTimelinesBLL.DeleteParkFromMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Park deleted Successfully');", true);
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
            if (txtParkNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Choose Plot To Inactive');", true);
                return;
            }
            else
            {
                if (txtParkNo.Enabled == false)
                {
                    DeletePlot();
                    BindlstPlotsListbox();
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

        protected void drpdwnSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindlstPlotsListbox();
            BindDirectivePlots();
            lbl_ModalIA.Text = drpdwnIA.SelectedItem.Text;
            lbl_ModalRegionalOffice.Text = ddloffice.SelectedItem.Text;
            lbl_ModalSector.Text = drpdwnSector.SelectedItem.Text;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (txt_ModalParkNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange('Park No is must');", true);
                    return;
                }
                if (txt_ModalParkARea.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopupChange('Park Area is must');", true);
                    return;
                }


                SqlCommand cmd = new SqlCommand("Select * from Park_Master where ParkName='" + txt_ModalParkNo.Text.Trim() + "' and IAID='" + drpdwnIA.SelectedValue.Trim() + "' and SectorID='" + drpdwnSector.SelectedValue.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Park Number already exist');", true);
                    return;
                }



                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.PlotNo = txt_ModalParkNo.Text.Trim();
                objServiceTimelinesBEL.PlotArea = Convert.ToDecimal(txt_ModalParkARea.Text.Trim());
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();
                int Result = objServiceTimelinesBLL.ParkEntryInParkMasterInstant(objServiceTimelinesBEL);
                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Park added Successfully');", true);
                    txt_ModalParkNo.Text = "";
                    txt_ModalParkARea.Text = "";

                    BindlstPlotsListbox();
                    BindDirectivePlots();


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

    }
}