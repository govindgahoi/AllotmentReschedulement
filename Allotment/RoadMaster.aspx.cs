using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class RoadMaster : System.Web.UI.Page
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

                ds = objServiceTimelinesBLL.BindlistRoadInListbox(objServiceTimelinesBEL);
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
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
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
                    txtRoadNo.Text = GridView2.DataKeys[rowIndex].Values["RoadName"].ToString();
                    txtRoadWidth.Text = GridView2.DataKeys[rowIndex].Values["RoadWidth"].ToString();
                    txtLength.Text = GridView2.DataKeys[rowIndex].Values["RoadLength"].ToString();
                    txtRow.Text = GridView2.DataKeys[rowIndex].Values["Row"].ToString();
                    txtBegPoint.Text = GridView2.DataKeys[rowIndex].Values["RoadBegPoint"].ToString();
                    txtEndPoint.Text = GridView2.DataKeys[rowIndex].Values["RoadEndPoint"].ToString();
                    txtNoOfStreetLights.Text = GridView2.DataKeys[rowIndex].Values["NoOfStreetLight"].ToString();
                    txtmedianWidth.Text = GridView2.DataKeys[rowIndex].Values["MedianWidth"].ToString();

                    if (GridView2.DataKeys[rowIndex].Values["Median"].ToString() == "Yes")
                    {
                        Div1.Visible = true;
                    }
                    else
                    {
                        Div1.Visible = false;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["StreetLight"].ToString() == "Yes")
                    {
                        StreetDiv.Visible = true;
                    }
                    else
                    {
                        StreetDiv.Visible = false;
                    }

                    drpMeadian.SelectedIndex = drpMeadian.Items.IndexOf(drpMeadian.Items.FindByText(GridView2.DataKeys[rowIndex].Values["Median"].ToString().Trim()));
                    drpGreenBelt.SelectedIndex = drpGreenBelt.Items.IndexOf(drpGreenBelt.Items.FindByText(GridView2.DataKeys[rowIndex].Values["GreenBelt"].ToString().Trim()));
                    drpStreetLight.SelectedIndex = drpStreetLight.Items.IndexOf(drpStreetLight.Items.FindByText(GridView2.DataKeys[rowIndex].Values["StreetLight"].ToString().Trim()));
                    drpStormWaterDrainage.SelectedIndex = drpStormWaterDrainage.Items.IndexOf(drpStormWaterDrainage.Items.FindByText(GridView2.DataKeys[rowIndex].Values["StormWaterDrainage"].ToString().Trim()));
                    drpFootpath.SelectedIndex = drpFootpath.Items.IndexOf(drpFootpath.Items.FindByText(GridView2.DataKeys[rowIndex].Values["FootPath"].ToString().Trim()));
                    drpCycleTrack.SelectedIndex = drpCycleTrack.Items.IndexOf(drpCycleTrack.Items.FindByText(GridView2.DataKeys[rowIndex].Values["CycleTrack"].ToString().Trim()));
                    drpIndustrialDrainage.SelectedIndex = drpIndustrialDrainage.Items.IndexOf(drpIndustrialDrainage.Items.FindByText(GridView2.DataKeys[rowIndex].Values["IndustrialDrainage"].ToString().Trim()));
                    drpRoadType.SelectedIndex = drpRoadType.Items.IndexOf(drpRoadType.Items.FindByText(GridView2.DataKeys[rowIndex].Values["RoadType"].ToString().Trim()));



                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());

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
            if (txtRoadNo.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Road Name');", true);
                return;
            }
            if (txtRow.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Right Of Way');", true);
                return;
            }
            if (txtRoadWidth.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Road Width');", true);
                return;
            }
            if (txtLength.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Road Length');", true);
                return;
            }
            if (txtBegPoint.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Road Beginning Point');", true);
                return;
            }
            if (txtEndPoint.Text.Length <= 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Road End Point');", true);
                return;
            }
            if (drpMeadian.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Median Status');", true);
                return;
            }
            if (drpGreenBelt.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Grren Belt Status');", true);
                return;
            }
            if (drpStreetLight.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Street Light Status');", true);
                return;
            }
            if (drpIndustrialDrainage.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Industrial Drainage Status');", true);
                return;
            }
            if (drpStormWaterDrainage.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Storm Water Drainage Status');", true);
                return;
            }
            if (drpFootpath.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select FootPath Status');", true);
                return;
            }
            if (drpCycleTrack.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Cycle Track Status');", true);
                return;
            }
            if (drpRoadType.SelectedIndex == -1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Road Type');", true);
                return;
            }

            SaveDetails();
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
                objServiceTimelinesBEL.RoadNo = txtRoadNo.Text.Trim();
                objServiceTimelinesBEL.RoadWidth = txtRoadWidth.Text.Trim();
                objServiceTimelinesBEL.RoadLength = txtLength.Text.Trim();
                objServiceTimelinesBEL.Row = txtRow.Text.Trim();
                objServiceTimelinesBEL.RoadType = drpRoadType.SelectedValue.Trim();
                objServiceTimelinesBEL.RoadBegPoint = txtBegPoint.Text.Trim();
                objServiceTimelinesBEL.RoadEndPoint = txtEndPoint.Text.Trim();
                objServiceTimelinesBEL.Median = drpMeadian.SelectedValue.Trim();
                objServiceTimelinesBEL.MedianWidth = (string.IsNullOrEmpty(txtmedianWidth.Text.Trim()) ? "0" : txtmedianWidth.Text.Trim());
                objServiceTimelinesBEL.GreenBelt = drpGreenBelt.SelectedValue.Trim();
                objServiceTimelinesBEL.StreetLight = drpStreetLight.SelectedValue.Trim();
                objServiceTimelinesBEL.NoOfStreetLight = (string.IsNullOrEmpty(txtNoOfStreetLights.Text.Trim()) ? "0" : txtNoOfStreetLights.Text.Trim());
                objServiceTimelinesBEL.IndustrialDrainage = drpIndustrialDrainage.SelectedValue.Trim();
                objServiceTimelinesBEL.StormWaterDrainage = drpStormWaterDrainage.SelectedValue.Trim();
                objServiceTimelinesBEL.FootPath = drpFootpath.SelectedValue.Trim();
                objServiceTimelinesBEL.CycleTrack = drpCycleTrack.SelectedValue.Trim();
                objServiceTimelinesBEL.ModifiedBy = UserName.Trim();
                objServiceTimelinesBEL.LockStatus = 0;


                int Result = objServiceTimelinesBLL.RoadEntryInRoadMasterNew(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Road Inserted/Updated Successfully');", true);
                    DisabledControls();
                    txtRoadNo.Text = "";
                    txtRoadWidth.Text = "";
                    txtLength.Text = "";
                    txtBegPoint.Text = "";
                    txtEndPoint.Text = "";
                    txtRow.Text = "";
                    drpFootpath.SelectedIndex = 0;
                    drpMeadian.SelectedIndex = 0;
                    txtmedianWidth.Text = "";
                    drpRoadType.SelectedIndex = 0;
                    drpStormWaterDrainage.SelectedIndex = 0;
                    drpStreetLight.SelectedIndex = 0;
                    txtNoOfStreetLights.Text = "";
                    drpIndustrialDrainage.SelectedIndex = 0;
                    drpCycleTrack.SelectedIndex = 0;
                    drpGreenBelt.SelectedIndex = 0;
                    txtmedianWidth.Text = "";
                    txtNoOfStreetLights.Text = "";

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
            txtRoadNo.Enabled = false;
            txtRoadWidth.Enabled = false;
            txtLength.Enabled = false;
            txtBegPoint.Enabled = false;
            txtEndPoint.Enabled = false;
            txtRow.Enabled = false;
            drpFootpath.Enabled = false;
            drpMeadian.Enabled = false;
            drpRoadType.Enabled = false;
            drpStormWaterDrainage.Enabled = false;
            drpStreetLight.Enabled = false;
            drpIndustrialDrainage.Enabled = false;
            drpCycleTrack.Enabled = false;
            drpGreenBelt.Enabled = false;
            txtmedianWidth.Enabled = false;
            txtNoOfStreetLights.Enabled = false;
        }


        protected void menuedit_ServerClick(object sender, EventArgs e)
        {

            if (txtRoadNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Road To Edit');", true);
                return;
            }
            else
            {

                txtRoadWidth.Enabled = true;
                txtLength.Enabled = true;
                txtBegPoint.Enabled = true;
                txtEndPoint.Enabled = true;
                txtRow.Enabled = true;
                drpFootpath.Enabled = true;
                drpMeadian.Enabled = true;
                drpRoadType.Enabled = true;
                drpStormWaterDrainage.Enabled = true;
                drpStreetLight.Enabled = true;
                drpIndustrialDrainage.Enabled = true;
                drpCycleTrack.Enabled = true;
                drpGreenBelt.Enabled = true;
                txtmedianWidth.Enabled = true;
                txtNoOfStreetLights.Enabled = true;

            }

        }

        protected void menunew_ServerClick(object sender, EventArgs e)
        {
            txtRoadNo.Enabled = true;
            txtRoadNo.Text = "";
            txtRoadWidth.Enabled = true;
            txtRoadWidth.Text = "";
            txtLength.Enabled = true;
            txtLength.Text = "";
            txtBegPoint.Enabled = true;
            txtBegPoint.Text = "";
            txtEndPoint.Enabled = true;
            txtEndPoint.Text = "";
            txtRow.Enabled = true;
            txtRow.Text = "";
            drpFootpath.Enabled = true;
            drpFootpath.SelectedIndex = 0;
            drpMeadian.Enabled = true;
            drpMeadian.SelectedIndex = 0;
            txtmedianWidth.Text = "";
            drpRoadType.Enabled = true;
            drpRoadType.SelectedIndex = 0;
            drpStormWaterDrainage.Enabled = true;
            drpStormWaterDrainage.SelectedIndex = 0;
            drpStreetLight.Enabled = true;
            drpStreetLight.SelectedIndex = 0;
            txtNoOfStreetLights.Text = "";
            drpIndustrialDrainage.Enabled = true;
            drpIndustrialDrainage.SelectedIndex = 0;
            drpCycleTrack.Enabled = true;
            drpCycleTrack.SelectedIndex = 0;
            drpGreenBelt.Enabled = true;
            drpGreenBelt.SelectedIndex = 0;
            txtmedianWidth.Text = "";
            txtmedianWidth.Enabled = true;
            txtNoOfStreetLights.Text = "";
            txtNoOfStreetLights.Enabled = true;

        }


        private void DeleteRoad()
        {

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];


                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.RoadNo = txtRoadNo.Text.Trim();
                objServiceTimelinesBEL.SectorID = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());



                int Result = objServiceTimelinesBLL.DeleteRoadFromMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Park Inactive Successfully');", true);
                    DisabledControls();
                    txtRoadNo.Text = "";
                    txtRoadWidth.Text = "";
                    txtLength.Text = "";
                    txtBegPoint.Text = "";
                    txtEndPoint.Text = "";
                    txtRow.Text = "";
                    drpFootpath.SelectedIndex = 0;
                    drpMeadian.SelectedIndex = 0;
                    txtmedianWidth.Text = "";
                    drpRoadType.SelectedIndex = 0;
                    drpStormWaterDrainage.SelectedIndex = 0;
                    drpStreetLight.SelectedIndex = 0;
                    txtNoOfStreetLights.Text = "";
                    drpIndustrialDrainage.SelectedIndex = 0;
                    drpCycleTrack.SelectedIndex = 0;
                    drpGreenBelt.SelectedIndex = 0;
                    txtmedianWidth.Text = "";
                    txtNoOfStreetLights.Text = "";
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

        protected void menudelete_ServerClick(object sender, EventArgs e)
        {
            if (txtRoadNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Choose Road To Delete');", true);
                return;
            }
            else
            {
                if (txtRoadNo.Enabled == false)
                {
                    DeleteRoad();

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

        }

        protected void drpStreetLight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpStreetLight.SelectedValue == "Yes")
            {
                StreetDiv.Visible = true;
            }
            else
            {
                StreetDiv.Visible = false;
            }

        }

        protected void drpMeadian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpMeadian.SelectedValue == "Yes")
            {
                Div1.Visible = true;
            }
            else
            {
                Div1.Visible = false;
            }
        }
    }
}