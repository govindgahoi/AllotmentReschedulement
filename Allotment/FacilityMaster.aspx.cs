using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class FacilityMaster : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    UserSpecificBinding();
                    BindDropdowns();
                    DisabledControls();

                }
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
           
          
            
        }
        protected void BindDropdowns()
        {
            DataSet ds = new DataSet();
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            try
            {

                ds = objServiceTimelinesBLL.GetIndustrialAreaStatus();
                
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
              
                if (Getdata2.Rows.Count > 0)
                {
                    ddl_FacilityType.DataSource     = Getdata2;
                    ddl_FacilityType.DataTextField  = "FacilitiesAvailable";
                    ddl_FacilityType.DataValueField = "ID";
                    ddl_FacilityType.DataBind();
                    ddl_FacilityType.Items.Insert(0, new ListItem("--Select Facility Type--", "0"));
                }
            }
            catch (Exception ex)
            { 
                Response.Write("Oops! error occured111 :" + ex.Message.ToString()); 
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
        protected void drpdwnSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListFacilityListbox();
            
        }


        public void BindListFacilityListbox()
        {
            DataSet ds = new DataSet();
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo                 = (LoginInfo)Session["objLoginInfo"];
                objServiceTimelinesBEL.industrialAreaID = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                objServiceTimelinesBEL.SectorID         = Int32.Parse(drpdwnSector.SelectedValue.ToString());

                ds = objServiceTimelinesBLL.BindFacilityInListbox(objServiceTimelinesBEL);
                if(ds.Tables[0].Rows.Count > 0)
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
            { 
                Response.Write("Oops! error occured :" + ex.Message.ToString()); 
            }

        }

        protected void Save_menu_ServerClick(object sender, EventArgs e)
        {
            if (txt_FacilityName.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Facility Name');", true);
                return;
            }

            if (ddl_FacilityType.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Facility Type');", true);
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

                objServiceTimelinesBEL.SectorID          = Convert.ToInt32(drpdwnSector.SelectedValue.Trim());
                objServiceTimelinesBEL.IAId              = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                objServiceTimelinesBEL.MaintainedBy      = txt_MaintainedBy.Text.Trim();
                objServiceTimelinesBEL.PlotRemark        = txt_Remarks.Text.Trim();
                objServiceTimelinesBEL.FacilityName      = txt_FacilityName.Text.Trim();
                objServiceTimelinesBEL.FacilityPlotNo    = txt_FacilityPlotNo.Text.Trim();
                objServiceTimelinesBEL.FacilityDesc      = txt_FacilityDesc.Text.Trim();
                objServiceTimelinesBEL.CreatedBy         = _objLoginInfo.userName.ToString();
                objServiceTimelinesBEL.LockStatus        = Convert.ToInt32(ddl_Lock.SelectedValue.Trim());
                objServiceTimelinesBEL.FacilityType      = Convert.ToInt32(ddl_FacilityType.SelectedValue.Trim());
                objServiceTimelinesBEL.FacilityUniqueID  = lbl_FacilityUniqueID.Text.Trim();
                objServiceTimelinesBEL.FacilityCapacity  = txt_Capicity.Text.Trim();

                int Result = objServiceTimelinesBLL.FacilityEntryInFacilityMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Facility Inserted/Updated Successfully');", true);
                    ClearRecords();
                    DisabledControls();
                    BindListFacilityListbox();
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

        private void ClearRecords()
        {
            txt_Capicity.Text = "";
            txt_FacilityDesc.Text = "";
            txt_FacilityName.Text = "";
            txt_FacilityPlotNo.Text = "";
            txt_MaintainedBy.Text = "";
            txt_Remarks.Text = "";
            ddl_FacilityType.SelectedIndex = 0;
            ddl_Lock.SelectedIndex = 0;
            lbl_FacilityID.Text = "";
            lbl_FacilityUniqueID.Text = "";
        }
        private void DisabledControls()
        {
            txt_Capicity.Enabled       = false;
            txt_FacilityDesc.Enabled   = false;
            txt_FacilityName.Enabled   = false;
            txt_FacilityPlotNo.Enabled = false;
            txt_MaintainedBy.Enabled   = false;
            txt_Remarks.Enabled        = false;
            ddl_FacilityType.Enabled   = false;
            ddl_Lock.Enabled           = false;          
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {


                if (e.CommandName == "Select")
                {
                   
                    DisabledControls();
                    int rowIndex = int.Parse(e.CommandArgument.ToString());               
                    string val = GridView2.DataKeys[rowIndex].Values["ID"].ToString();
                    BindRecords(val);
  
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

        private void BindRecords(string ID)
        {
            
            try
            {
                DataSet ds = new DataSet();
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.FacilityID = ID;
                ds = objServiceTimelinesBLL.BindFacilityInTextBox(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Getdata1 = ds.Tables[0];
                    ddl_FacilityType.SelectedValue = Getdata1.Rows[0]["FacilityType"].ToString();
                    txt_FacilityName.Text          = Getdata1.Rows[0]["FacilityName"].ToString();
                    txt_FacilityDesc.Text          = Getdata1.Rows[0]["FacilityDesc"].ToString();
                    txt_FacilityPlotNo.Text        = Getdata1.Rows[0]["FacilityPlotNo"].ToString();
                    txt_Remarks.Text               = Getdata1.Rows[0]["Remarks"].ToString();
                    txt_MaintainedBy.Text          = Getdata1.Rows[0]["OperatedBy"].ToString();
                    txt_Capicity.Text              = Getdata1.Rows[0]["Capacity"].ToString();
                    lbl_FacilityID.Text            = Getdata1.Rows[0]["ID"].ToString();
                    lbl_FacilityUniqueID.Text      = Getdata1.Rows[0]["FacilityUniqueID"].ToString();
                    lblLockStatus.Text             = Getdata1.Rows[0]["ISLOCKED"].ToString();
                    if (Getdata1.Rows[0]["ISLOCKED"].ToString() == "True")
                    {
                        ddl_Lock.SelectedValue = "1";
                    }
                    else
                    {
                        ddl_Lock.SelectedValue = "0";
                    }                  

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('No Record Found');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void menuedit_ServerClick(object sender, EventArgs e)
        {
            if (Level == "RM")
            {
                if (lbl_FacilityID.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Facility To Edit');", true);
                    return;
                }
                else
                {
                    txt_FacilityName.Enabled = true;
                    ddl_FacilityType.Enabled = true;
                    txt_FacilityDesc.Enabled = true;
                    txt_FacilityPlotNo.Enabled = true;
                    txt_Remarks.Enabled = true;
                    txt_MaintainedBy.Enabled = true;
                    txt_Capicity.Enabled = true;
                   
                    if (Level == "RM")
                    {
                        ddl_Lock.Enabled = true;
                    }

                  
                }
            }
            else
            {
                if (lbl_FacilityID.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Facility To Edit');", true);
                    return;
                }
                if (lblLockStatus.Text == "False")
                {
                    if (lbl_FacilityID.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Facility To Edit');", true);
                        return;
                    }
                    else
                    {
                        txt_FacilityName.Enabled = true;

                        txt_FacilityDesc.Enabled = true;
                        txt_FacilityPlotNo.Enabled = true;
                        txt_Remarks.Enabled = true;
                        txt_MaintainedBy.Enabled = true;
                        txt_Capicity.Enabled = true;
                        ddl_FacilityType.Enabled = true;
                        if (Level == "RM")
                        {
                            ddl_Lock.Enabled = true;
                        }
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
            txt_FacilityName.Enabled = true;

            txt_FacilityDesc.Enabled = true;
            txt_FacilityPlotNo.Enabled = true;
            txt_Remarks.Enabled = true;
            txt_MaintainedBy.Enabled = true;
            txt_Capicity.Enabled = true;
            ddl_FacilityType.Enabled = true;
            if (Level == "RM")
            {
                ddl_Lock.Enabled = true;
            }
            ClearRecords();
            BindListFacilityListbox();
        }

        protected void menudelete_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (lbl_FacilityID.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Facility To Delete');", true);
                    return;
                }

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];


                objServiceTimelinesBEL.FacilityID = lbl_FacilityID.Text;
           

                int Result = objServiceTimelinesBLL.DeleteFacilityFromMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Facility deleted Successfully');", true);
                    DisabledControls();
                    ClearRecords();
                    BindListFacilityListbox();
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

        protected void refresh_menu_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
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
    }
}