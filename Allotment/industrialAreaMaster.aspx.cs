using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
namespace Allotment
{
    public partial class industrialAreaMaster : System.Web.UI.Page
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
                Page.Form.Enctype = "multipart/form-data";
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

                ds = objServiceTimelinesBLL.GetIndustrialAreaStatus();
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }
                if (ds.Tables[3].Rows.Count > 0) { Getdata4 = ds.Tables[3]; }
                //if (ds.Tables[4].Rows.Count > 0) { Getdata5 = ds.Tables[4]; }
                //if (ds.Tables[5].Rows.Count > 0) { Getdata6 = ds.Tables[5]; }
                //  if (ds.Tables[6].Rows.Count > 0) { Getdata7 = ds.Tables[6]; }
                if (Getdata1.Rows.Count > 0)
                {
                    IACategory.DataSource = Getdata1;
                    IACategory.DataTextField = "IndustrialAreaCategory";
                    IACategory.DataValueField = "ID";
                    IACategory.DataBind();
                    IACategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

                if (Getdata2.Rows.Count > 0)
                {

                    List1.DataSource = Getdata2;
                    List1.DataTextField = "FacilitiesAvailable";
                    List1.DataValueField = "ID";
                    List1.DataBind();

                }
                if (Getdata3.Rows.Count > 0)
                {
                    drpIndustriesAllowed.DataSource = Getdata3;
                    drpIndustriesAllowed.DataTextField = "IndustrialClassificationName";
                    drpIndustriesAllowed.DataValueField = "ClassificationID";
                    drpIndustriesAllowed.DataBind();

                }
                if (Getdata4.Rows.Count > 0)
                {
                    drppollutionCategory.DataSource = Getdata4;
                    drppollutionCategory.DataTextField = "PollutionCategory";
                    drppollutionCategory.DataValueField = "ID";
                    drppollutionCategory.DataBind();
                    drppollutionCategory.Items.Insert(0, new ListItem("--Select--", "0"));
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
                dsR = objServiceTimelinesBLL.GetregionalOfficeList(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "a";
                ddloffice.DataBind();

                Regional_Changed(null, null);
                drpDistict_SelectedIndexChanged(null, null);
                ddlSubDistict_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        protected void Regional_Changed(object sender, EventArgs e)
        {

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }
            try { bindDDLDistict(ddloffice.SelectedItem.Value, null); } catch { }
        }
        protected void drpDistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { bindDDLSubDistict(drpDistict.SelectedValue, null); } catch { }
        }

        protected void ddlSubDistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { bindDDLVillage(ddlSubDistict.SelectedValue, null); } catch { }
        }
        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaRecords(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    GridView2.DataSource = dt;
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
        private void bindDDLDistict(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetNGOCdistictRecords(objServiceTimelinesBEL);
                drpDistict.DataSource = ds;
                drpDistict.DataTextField = "District";
                drpDistict.DataValueField = "DistrictCode";
                drpDistict.DataBind();
                drpDistict.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            { Response.Write("Oops! error occured :" + ex.Message.ToString()); }


        }

        private void bindDDLSubDistict(string pdistict, string pIAName)
        {
            objServiceTimelinesBEL.Distict = Convert.ToInt32(pdistict);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetSubDistict(objServiceTimelinesBEL);
                ddlSubDistict.DataSource = ds;
                ddlSubDistict.DataTextField = "SubDistrict";
                ddlSubDistict.DataValueField = "SubDistrictCode";
                ddlSubDistict.DataBind();
                //--------------
                ddlSubDistict.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlSubDistict.Enabled = true;
                ddlUsezone.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void bindDDLVillage(string pVillage, string pIAName)
        {
            objServiceTimelinesBEL.SubDistict = Convert.ToInt32(pVillage);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetVillage(objServiceTimelinesBEL);
                ddlVillage.DataSource = ds;
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataValueField = "Census_Village_code";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private DataTable Getdata1
        {
            get; set;
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    //txtBoxDefaulter.Text = String.Empty;
                    DisabledControls();
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    txtIndustrialArea.Text = GridView2.DataKeys[rowIndex].Values["IAName"].ToString();

                    lblIAID.Text = GridView2.DataKeys[rowIndex].Values["Id"].ToString();
                    txtBoxTotalLandAcquired.Text = GridView2.DataKeys[rowIndex].Values["TotalLandAcquired"].ToString();
                    textBoxTotIALandForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotIALandForAllotment"].ToString();
                    textBoxTotIAPlotsForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotIAPlotsForAllotment"].ToString();
                    txtIARatePerSqmt.Text = GridView2.DataKeys[rowIndex].Values["IARatePerSqmt"].ToString();
                    txtBackTotResLandForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotResLandForAllotment"].ToString();
                    txtTotResPlotForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotResPlotForAllotment"].ToString();
                    txtResRatePerSqmt.Text = GridView2.DataKeys[rowIndex].Values["ResRatePerSqmt"].ToString();

                    txtTotCommLandForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotCommLandForAllotment"].ToString();

                    txtTotCommPlotsForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotCommPlotsForAllotment"].ToString();
                    txtCommRatePerSqmt.Text = GridView2.DataKeys[rowIndex].Values["CommRatePerSqmt"].ToString();
                    txtTotInstLandForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotInstLandForAllotment"].ToString();
                    txtTotInstPlotsForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotInstPlotsForAllotment"].ToString();
                    txtInstRatePerSqmt.Text = GridView2.DataKeys[rowIndex].Values["InstRatePerSqmt"].ToString();
                    txtLandForFacilities.Text = GridView2.DataKeys[rowIndex].Values["LandForFacilities"].ToString();
                    txtLandForRoad.Text = GridView2.DataKeys[rowIndex].Values["LandForRoad"].ToString();
                    txtLandUnderGreenBelt.Text = GridView2.DataKeys[rowIndex].Values["LandUnderGreenBelt"].ToString();
                    txtLandForPark.Text = GridView2.DataKeys[rowIndex].Values["LandForPark"].ToString();
                    txtBulkLand.Text = GridView2.DataKeys[rowIndex].Values["BulkLand"].ToString();
                    txtOtherLandArea.Text = GridView2.DataKeys[rowIndex].Values["OtherLandArea"].ToString();
                    txtOtherLandDesc.Text = GridView2.DataKeys[rowIndex].Values["OtherLandDesc"].ToString();
                    txtTotInstLandForAllotment.Text = GridView2.DataKeys[rowIndex].Values["TotInstLandForAllotment"].ToString();
                    string Facility = GridView2.DataKeys[rowIndex].Values["FacilitiesAvailable"].ToString();
                    string village = GridView2.DataKeys[rowIndex].Values["VillageID"].ToString();
                    if (GridView2.DataKeys[rowIndex].Values["PollutionCategory"].ToString().Length > 0)
                    {
                        drppollutionCategory.SelectedValue = GridView2.DataKeys[rowIndex].Values["PollutionCategory"].ToString();
                    }
                    else
                    {
                        drppollutionCategory.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["DistrictID"].ToString().Length > 0)
                    {
                        drpDistict.SelectedValue = GridView2.DataKeys[rowIndex].Values["DistrictID"].ToString();
                        try { bindDDLSubDistict(drpDistict.SelectedValue, null); } catch { }
                    }
                    else
                    {
                        drpDistict.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["SubDistictID"].ToString().Length > 0)
                    {
                         ddlSubDistict.SelectedValue = GridView2.DataKeys[rowIndex].Values["SubDistictID"].ToString();
                        //ddlSubDistict.SelectedValue = SubDistict;
                        try { bindDDLVillage(ddlSubDistict.SelectedValue, null); } catch { }
                    }
                    else
                    {
                        ddlSubDistict.SelectedIndex = 0;
                    }

                    string IndustriesAllowed = GridView2.DataKeys[rowIndex].Values["IndustriesAllowed"].ToString();

                    //string pollutioncategoryStatus = GridView2.DataKeys[rowIndex].Values["pollutioncategoryStatus"].ToString();

                    if (GridView2.DataKeys[rowIndex].Values["UseZone"].ToString().Length > 0)
                    {
                        ddlUsezone.SelectedValue = GridView2.DataKeys[rowIndex].Values["UseZone"].ToString();
                    }
                    else
                    {
                        ddlUsezone.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["pollutioncategoryStatus"].ToString().Length > 0)
                    {
                        ddlpollutionCategorystatus.SelectedValue = GridView2.DataKeys[rowIndex].Values["pollutioncategoryStatus"].ToString();
                    }
                    else
                    {
                        ddlpollutionCategorystatus.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["InstantAllotmentAvailable"].ToString().Length > 0)
                    {
                        ddlInstantAllotment.SelectedValue = GridView2.DataKeys[rowIndex].Values["InstantAllotmentAvailable"].ToString();
                    }
                    else
                    {
                        ddlInstantAllotment.SelectedIndex = 0;
                    }



                    string[] ArrIndustriesAllowed = IndustriesAllowed.Split(',');
                    if (IndustriesAllowed == "")
                    {
                        drpIndustriesAllowed.ClearSelection();
                    }
                    else
                    {
                        for (int j = 0; j < ArrIndustriesAllowed.Length; j++)
                        {
                            drpIndustriesAllowed.Items.FindByValue(ArrIndustriesAllowed[j]).Selected = true;
                        }
                    }

                    if (GridView2.DataKeys[rowIndex].Values["IACategory"].ToString().Length > 0)
                    { IACategory.SelectedValue = GridView2.DataKeys[rowIndex].Values["IACategory"].ToString(); }
                    else { IACategory.SelectedIndex = 0; }

                    string[] Arr = Facility.Split(',');
                    if (Facility == "")
                    {
                        List1.ClearSelection();
                    }
                    else
                    {
                        for (int i = 0; i < Arr.Length; i++)
                        {
                            List1.Items.FindByValue(Arr[i]).Selected = true;
                        }
                    }
                    string[] ArrVillage = village.Split(',');
                    if (village == "")
                    {
                        ddlVillage.ClearSelection();
                    }
                    else
                    {
                        for (int i = 0; i < ArrVillage.Length; i++)
                        {
                            ddlVillage.Items.FindByValue(ArrVillage[i]).Selected = true;
                        }
                    }
                    #region NewGISCode
                    txtparksd.Text = GridView2.DataKeys[rowIndex].Values["ParkSD"].ToString();
                    txtMixedSector.Text = GridView2.DataKeys[rowIndex].Values["MixedSector"].ToString();
                    txtSubSector.Text = GridView2.DataKeys[rowIndex].Values["SubSector"].ToString();
                    txtNHighway.Text = GridView2.DataKeys[rowIndex].Values["NHighway"].ToString();
                    txtDistNH.Text = GridView2.DataKeys[rowIndex].Values["DistNH"].ToString();
                    txtSHighway.Text = GridView2.DataKeys[rowIndex].Values["SHighway"].ToString();
                    txtDistSH.Text = GridView2.DataKeys[rowIndex].Values["DistSH"].ToString();
                    txtRStation.Text = GridView2.DataKeys[rowIndex].Values["RStation"].ToString();
                    txtDistRS.Text = GridView2.DataKeys[rowIndex].Values["DistRS"].ToString();
                    txtAirport.Text = GridView2.DataKeys[rowIndex].Values["Airport"].ToString();
                    txtDistAir.Text = GridView2.DataKeys[rowIndex].Values["DistAir"].ToString();
                    txtSeaport.Text = GridView2.DataKeys[rowIndex].Values["Seaport"].ToString();
                    txtDistport.Text = GridView2.DataKeys[rowIndex].Values["Distport"].ToString();
                    txtDryPort.Text = GridView2.DataKeys[rowIndex].Values["DryPort"].ToString();
                    txtDistdryport.Text = GridView2.DataKeys[rowIndex].Values["Distdryport"].ToString();
                    txtDistRailS.Text = GridView2.DataKeys[rowIndex].Values["DistRailS"].ToString();
                    txtDistZonal.Text = GridView2.DataKeys[rowIndex].Values["DistZonal"].ToString();
                    txtPoliceSt.Text = GridView2.DataKeys[rowIndex].Values["PoliceSt"].ToString();
                    txtDistPolice.Text = GridView2.DataKeys[rowIndex].Values["DistPolice"].ToString();
                    txtFireSt.Text = GridView2.DataKeys[rowIndex].Values["FireSt"].ToString();
                    txtDistFire.Text = GridView2.DataKeys[rowIndex].Values["DistFire"].ToString();
                    txtBank.Text = GridView2.DataKeys[rowIndex].Values["Bank"].ToString();
                    txtDistBank.Text = GridView2.DataKeys[rowIndex].Values["DistBank"].ToString();
                    txtHospital.Text = GridView2.DataKeys[rowIndex].Values["Hospital"].ToString();
                    txtDistHosp.Text = GridView2.DataKeys[rowIndex].Values["DistHosp"].ToString();
                    txtElectU.Text = GridView2.DataKeys[rowIndex].Values["ElectU"].ToString();
                    txtElectC.Text = GridView2.DataKeys[rowIndex].Values["ElectC"].ToString();
                    txtWaterC.Text = GridView2.DataKeys[rowIndex].Values["WaterC"].ToString();
                    txtWaterU.Text = GridView2.DataKeys[rowIndex].Values["WaterU"].ToString();
                    txtGasC.Text = GridView2.DataKeys[rowIndex].Values["GasC"].ToString();
                    txtGasU.Text = GridView2.DataKeys[rowIndex].Values["GasU"].ToString();
                    txtSTPC.Text = GridView2.DataKeys[rowIndex].Values["STPC"].ToString();
                    txtSTPU.Text = GridView2.DataKeys[rowIndex].Values["STPU"].ToString();
                    txtPowerSSC.Text = GridView2.DataKeys[rowIndex].Values["PowerSSC"].ToString();
                    txtPowerSSU.Text = GridView2.DataKeys[rowIndex].Values["PowerSSU"].ToString();
                    txtWTPC.Text = GridView2.DataKeys[rowIndex].Values["WTPC"].ToString();
                    txtWTPU.Text = GridView2.DataKeys[rowIndex].Values["WTPU"].ToString();
                    txtICTS.Text = GridView2.DataKeys[rowIndex].Values["ICTS"].ToString();
                    txtSWDC.Text = GridView2.DataKeys[rowIndex].Values["SWDC"].ToString();
                    txtSWDU.Text = GridView2.DataKeys[rowIndex].Values["SWDU"].ToString();
                    txtOtherInformation.Text = GridView2.DataKeys[rowIndex].Values["OtherInformation"].ToString();
                    txtApprovalReffno.Text = GridView2.DataKeys[rowIndex].Values["EVMApprovalReffno"].ToString();
                    txtDormitoriesCapecity.Text = GridView2.DataKeys[rowIndex].Values["DormitoriesCapecity"].ToString();
                    txtTruckparkingCapecity.Text = GridView2.DataKeys[rowIndex].Values["TruckparkingCapecity"].ToString();

                    if (GridView2.DataKeys[rowIndex].Values["IAType"].ToString().Length > 0)
                    {
                        ddlIAType.SelectedValue = GridView2.DataKeys[rowIndex].Values["IAType"].ToString();
                    }
                    else
                    {
                        ddlIAType.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["Zonal"].ToString().Length > 0)
                    {
                        ddlZonal.SelectedValue = GridView2.DataKeys[rowIndex].Values["Zonal"].ToString();
                    }
                    else
                    {
                        ddlZonal.SelectedIndex = 0;
                    }

                    if (GridView2.DataKeys[rowIndex].Values["ElectA"].ToString().Length > 0)
                    {
                        ddlElectA.SelectedValue = GridView2.DataKeys[rowIndex].Values["ElectA"].ToString();
                        if (ddlElectA.SelectedValue == "Yes")
                        {
                            divElectU.Visible = true;

                        }
                        else
                        {
                            divElectU.Visible = false;

                        }

                    }
                    else
                    {
                        ddlElectA.SelectedIndex = 0;
                    }

                    if (GridView2.DataKeys[rowIndex].Values["WaterA"].ToString().Length > 0)
                    {
                        ddlWaterA.SelectedValue = GridView2.DataKeys[rowIndex].Values["WaterA"].ToString();
                        if (ddlWaterA.SelectedValue == "Yes")
                        {
                            divWaterC.Visible = true;

                        }
                        else
                        {
                            divWaterC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlWaterA.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["GasA"].ToString().Length > 0)
                    {
                        ddlGasLine.SelectedValue = GridView2.DataKeys[rowIndex].Values["GasA"].ToString();
                        if (ddlGasLine.SelectedValue == "Yes")
                        {
                            divGasC.Visible = true;

                        }
                        else
                        {
                            divGasC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlGasLine.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["STPA"].ToString().Length > 0)
                    {
                        ddlSTP.SelectedValue = GridView2.DataKeys[rowIndex].Values["STPA"].ToString();
                        if (ddlSTP.SelectedValue == "Yes")
                        {
                            divSTPC.Visible = true;

                        }
                        else
                        {
                            divSTPC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlSTP.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["EPoleA"].ToString().Length > 0)
                    {
                        ddlEPoleA.SelectedValue = GridView2.DataKeys[rowIndex].Values["EPoleA"].ToString();
                    }
                    else
                    {
                        ddlEPoleA.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["PowerSSA"].ToString().Length > 0)
                    {
                        ddlPowerSSA.SelectedValue = GridView2.DataKeys[rowIndex].Values["PowerSSA"].ToString();
                        if (ddlPowerSSA.SelectedValue == "Yes")
                        {
                            divPowerSSC.Visible = true;

                        }
                        else
                        {
                            divPowerSSC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlPowerSSA.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["WTPA"].ToString().Length > 0)
                    {
                        ddlWTP.SelectedValue = GridView2.DataKeys[rowIndex].Values["WTPA"].ToString();
                        if (ddlWTP.SelectedValue == "Yes")
                        {
                            divWTPC.Visible = true;

                        }
                        else
                        {
                            divWTPC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlWTP.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["ICTA"].ToString().Length > 0)
                    {
                        ddlICT.SelectedValue = GridView2.DataKeys[rowIndex].Values["ICTA"].ToString();
                        if (ddlICT.SelectedValue == "Yes")
                        {
                            divICTS.Visible = true;

                        }
                        else
                        {
                            divICTS.Visible = false;

                        }
                    }
                    else
                    {
                        ddlICT.SelectedIndex = 0;
                    }
                    if (GridView2.DataKeys[rowIndex].Values["SWDA"].ToString().Length > 0)
                    {
                        ddlSWDA.SelectedValue = GridView2.DataKeys[rowIndex].Values["SWDA"].ToString();
                        if (ddlSWDA.SelectedValue == "Yes")
                        {
                            divSWDC.Visible = true;

                        }
                        else
                        {
                            divSWDC.Visible = false;

                        }
                    }
                    else
                    {
                        ddlSWDA.SelectedIndex = 0;

                    }
                    if (GridView2.DataKeys[rowIndex].Values["DhA"].ToString().Length > 0)
                    {
                        ddlDhA.SelectedValue = GridView2.DataKeys[rowIndex].Values["DhA"].ToString();
                        if (ddlDhA.SelectedValue == "Yes")
                        {
                            divDormitoriesCapecity.Visible = true;

                        }
                        else
                        {
                            divDormitoriesCapecity.Visible = false;

                        }

                    }
                    else
                    {
                        ddlDhA.SelectedIndex = 0;

                    }
                    if (GridView2.DataKeys[rowIndex].Values["PtA"].ToString().Length > 0)
                    {
                        ddlPtA.SelectedValue = GridView2.DataKeys[rowIndex].Values["PtA"].ToString();
                        if (ddlPtA.SelectedValue == "Yes")
                        {
                            divTruckparkingCapecity.Visible = true;

                        }
                        else
                        {
                            divTruckparkingCapecity.Visible = false;

                        }
                    }
                    else
                    {
                        ddlPtA.SelectedIndex = 0;

                    }
                    if (GridView2.DataKeys[rowIndex].Values["EnvtClOb"].ToString().Length > 0)
                    {
                        ddlEnvtClOb.SelectedValue = GridView2.DataKeys[rowIndex].Values["EnvtClOb"].ToString();
                        if (ddlEnvtClOb.SelectedValue == "Yes")
                        {
                            divApprovalreffno.Visible = true;

                        }
                        else
                        {
                            divApprovalreffno.Visible = false;

                        }
                    }
                    else
                    {
                        ddlEnvtClOb.SelectedIndex = 0;

                    }

                    #endregion
                }

                DisabledControls();

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

        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void Save_menu_ServerClick(object sender, EventArgs e)
        {
            if (txtIndustrialArea.Text == "")
            {
                if (txtIndustrialArea.Enabled == true)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide New Industrial Area');", true); return;
                }
                else
                { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Operation Cannot Be Performed');", true); return; }
            }
            else
            {
                if (txtIndustrialArea.Enabled == true)
                {
                    if (txtIndustrialArea.Text == "" || txtIndustrialArea.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Industrial Area Name");
                        return;
                    }
                     if (drpDistict.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Distict Name");
                        return;
                    }
                     if (ddlSubDistict.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Sub Distict Name");
                        return;
                    }
                     if (ddlVillage.SelectedIndex == -1)
                    {
                        MessageBox1.ShowWarning("Please Provide Village Details");
                        return;
                    }
                     if (IACategory.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select Industrial Area Category");
                        return;
                    }
                     if (ddlUsezone.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select Use Zone");
                        return;
                    }
                     if (ddlIAType.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select Type of Industrial Category");
                        return;
                    }
                     if (drpIndustriesAllowed.SelectedIndex == -1)
                    {
                        MessageBox1.ShowWarning("Please Provide Industries Sector Allowed Details");
                        return;
                    }
                     if (drpIndustriesAllowed.SelectedValue == "9")
                    {
                        if (txtMixedSector.Text != "")
                        {

                        }
                        else
                        {
                            txtMixedSector.Focus();
                            MessageBox1.ShowError("Please Enter Mixed Sector Details");
                            return;
                        }

                    }
                   
                    if (txtSubSector.Text == "" || txtSubSector.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Sub Sector");
                        return;
                    }
                     if (txtparksd.Text == "" || txtparksd.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Short Description of Industrial Area");
                        return;
                    }
                     if (ddlInstantAllotment.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select is Instant Allotment");
                        return;
                    }
                     if (txtBoxTotalLandAcquired.Text == "" || txtBoxTotalLandAcquired.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land Acquired");
                        return;
                    }
                     if (textBoxTotIALandForAllotment.Text == "" || textBoxTotIALandForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land For Allotment");
                        return;
                    }
                     if (textBoxTotIAPlotsForAllotment.Text == "" || textBoxTotIAPlotsForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Plots For Allotment");
                        return;
                    }
                     if (txtIARatePerSqmt.Text == "" || txtIARatePerSqmt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Industrial Area Rate PerSqmt");
                        return;
                    }
                     if (txtBackTotResLandForAllotment.Text == "" || txtBackTotResLandForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total ResidentialLand For Allotmen");
                        return;
                    }
                     if (txtTotResPlotForAllotment.Text == "" || txtTotResPlotForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Residential Plot For Allotment");
                        return;
                    }
                     if (txtResRatePerSqmt.Text == "" || txtResRatePerSqmt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Residential Rate (Sqmt)");
                        return;
                    }
                     if (txtTotCommLandForAllotment.Text == "" || txtTotCommLandForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Commercial Land For Allotment");
                        return;
                    }
                     if (txtTotCommPlotsForAllotment.Text == "" || txtTotCommPlotsForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Commercial Plots For Allotment");
                        return;
                    }
                     if (txtCommRatePerSqmt.Text == "" || txtCommRatePerSqmt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Commercial Rate (Sqmt)");
                        return;
                    }
                     if (txtTotInstLandForAllotment.Text == "" || txtTotInstLandForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Inst Land For Allotment");
                        return;
                    }
                     if (txtTotInstPlotsForAllotment.Text == "" || txtTotInstPlotsForAllotment.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Inst Plots For Allotment");
                        return;
                    }
                     if (txtInstRatePerSqmt.Text == "" || txtInstRatePerSqmt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Inst Rate(Sqmt)");
                        return;
                    }
                     if (txtLandForFacilities.Text == "" || txtLandForFacilities.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land For Facilities");
                        return;
                    }
                     if (txtLandForRoad.Text == "" || txtLandForRoad.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land For Road");
                        return;
                    }
                     if (txtLandUnderGreenBelt.Text == "" || txtLandUnderGreenBelt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land Under GreenBelt");
                        return;
                    }
                     if (txtLandForPark.Text == "" || txtLandForPark.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Land For Park");
                        return;
                    }
                     if (txtBulkLand.Text == "" || txtBulkLand.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total BulkLand");
                        return;
                    }
                     if (txtOtherLandArea.Text == "" || txtOtherLandArea.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Total Other LandArea");
                        return;
                    }
                     if (List1.SelectedIndex == -1)
                    {
                        MessageBox1.ShowWarning("Please Provide Facilities Available");
                        return;
                    }

                    
                    
                     if (txtNHighway.Text == "" || txtNHighway.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide National Highway Details");
                        return;
                    }
                     if (txtDistNH.Text == "" || txtDistNH.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from NH(in Km)");
                        return;
                    }
                     if (txtSHighway.Text == "" || txtSHighway.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide State Highway Details");
                        return;
                    }
                     if (txtDistSH.Text == "" || txtDistSH.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance in Km");
                        return;
                    }
                     if (txtRStation.Text == "" || txtRStation.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Railway Station Details");
                        return;
                    }
                     if (txtDistRS.Text == "" || txtDistRS.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance in Km");
                        return;
                    }
                     if (txtAirport.Text == "" || txtAirport.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Airport Details");
                        return;
                    }
                     if (txtDistAir.Text == "" || txtDistAir.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide  Distance from Airport(in km)");
                        return;
                    }
                     if (txtSeaport.Text == "" || txtSeaport.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Sea Port Details");
                        return;
                    }
                     if (txtDistport.Text == "" || txtDistport.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from seaport(in Km)");
                        return;
                    }
                     if (txtDryPort.Text == "" || txtDryPort.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide ICD/Dry port Details");
                        return;
                    }
                     if (txtDistdryport.Text == "" || txtDistdryport.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Dry Port/ICD(in Km)");
                        return;
                    }
                     if (txtDistRailS.Text == "" || txtDistRailS.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Railway Silding Details");
                        return;
                    }
                     if (ddlZonal.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select is Zonal Name");
                        return;
                    }
                     if (txtDistZonal.Text == "" || txtDistZonal.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Dist Zonal Details");
                        return;
                    }
                     if (txtPoliceSt.Text == "" || txtPoliceSt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Police Station Details");
                        return;
                    }
                     if (txtDistPolice.Text == "" || txtDistPolice.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Police Station(in Km)");
                        return;
                    }
                     if (txtFireSt.Text == "" || txtFireSt.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Fire Station Details");
                        return;
                    }
                     if (txtDistFire.Text == "" || txtDistFire.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Fire Station(in Km)");
                        return;
                    }
                     if (txtBank.Text == "" || txtBank.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Bank Details");
                        return;
                    }
                     if (txtDistBank.Text == "" || txtDistBank.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Bank(in Km)");
                        return;
                    }
                     if (txtHospital.Text == "" || txtHospital.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Hospital Details");
                        return;
                    }
                     if (txtDistHosp.Text == "" || txtDistHosp.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Hospital(in Km)");
                        return;
                    }
                     if (txtHospital.Text == "" || txtHospital.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Hospital Details");
                        return;
                    }
                     if (txtDistHosp.Text == "" || txtDistHosp.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Distance from Hospital(in Km)");
                        return;
                    }
                     if (ddlElectA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Electricity/Power availability");
                        return;
                    }
                    if (ddlElectA.SelectedValue == "Yes")
                    {
                        if (txtElectC.Text == "" || txtElectC.Text == null)
                        {
                            MessageBox1.ShowError("Please Enter Electricity/Power Capacity(KVA)");
                            return;
                        }

                        else if (txtElectU.Text == "" || txtElectU.Text == null)
                        {
                            MessageBox1.ShowError("Please Enter Electricity/Power (Utilization (in %))");
                            return;
                        }

                    }
                    if (ddlWaterA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Water availability");
                        return;
                    }
                    if (ddlWaterA.SelectedValue == "Yes")
                    {

                        if (txtWaterC.Text == "" || txtWaterC.Text == null)
                        {
                            txtWaterC.Focus();
                            MessageBox1.ShowError("Please Enter Water Capacity(MLD)");
                            return;
                        }
                        else if (txtWaterU.Text == "" || txtWaterU.Text == null)
                        {
                            txtWaterU.Focus();
                            MessageBox1.ShowError("Please Enter Water (Utilization (in %))");
                            return;
                        }
                    }
                    if (ddlGasLine.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Gas Line availability");
                        return;
                    }
                    if (ddlGasLine.SelectedValue == "Yes")
                    {

                        if (txtGasC.Text == "" || txtGasC.Text == null)
                        {
                            MessageBox1.ShowError("Please Enter Gas Capacity(MLD)");
                            return;
                        }

                        else if (txtGasU.Text == "" || txtGasU.Text == null)
                        {
                            MessageBox1.ShowError("Please Enter Gas (Utilization (in %))");
                            return;
                        }
                    }
                    if (ddlGasLine.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Gas Line availability");
                        return;
                    }
                     if (ddlSTP.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  STP ");
                        return;
                    }
                    if (ddlSTP.SelectedValue == "Yes")
                    {
                        if (txtSTPC.Text == "" || txtSTPC.Text == null)
                        {
                            txtSTPC.Focus();
                            MessageBox1.ShowError("Please Enter STP  Capacity (MLD)");
                            return;
                        }

                        else if (txtSTPU.Text == "" || txtSTPU.Text == null)
                        {
                            txtSTPU.Focus();
                            MessageBox1.ShowError("Please Enter STP Utilization (in %)");
                            return;
                        }
                    }
                    if (ddlPowerSSA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Power Sub Station");
                        return;
                    }
                    if (ddlPowerSSA.SelectedValue == "Yes")
                    {
                        if (txtPowerSSC.Text == "" || txtPowerSSC.Text == null)
                        {
                            txtPowerSSC.Focus();
                            MessageBox1.ShowError("Please Enter Power Sub Station Capacity (KVA)");
                            return;
                        }
                        else if (txtPowerSSU.Text == "" || txtPowerSSU.Text == null)
                        {
                            txtPowerSSU.Focus();
                            MessageBox1.ShowError("Please Enter Power Sub Station Utilization (in %)");
                            return;
                        }
                    }
                    if (ddlWTP.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  WTP");
                        return;
                    }
                    if (ddlWTP.SelectedValue == "Yes")
                    {
                        if (txtWTPC.Text == "" || txtWTPC.Text == null)
                        {
                            txtWTPC.Focus();
                            MessageBox1.ShowError("Please Enter WTP Capacity (MLD)");
                            return;
                        }
                        else if (txtWTPU.Text == "" || txtWTPU.Text == null)
                        {
                            txtWTPU.Focus();
                            MessageBox1.ShowError("Please Enter WTP Utilization (in %)");
                            return;
                        }
                    }
                    if (ddlICT.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  ICT");
                        return;
                    }
                    if (ddlICT.SelectedValue == "Yes")
                    {
                        if (txtICTS.Text == "" || txtICTS.Text == null)
                        {
                            txtICTS.Focus();
                            MessageBox1.ShowError("Please Enter ICTS Speed (Mbps)");
                            return;
                        }

                    }
                    if (ddlSWDA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Solid Waste Disposal Facility");
                        return;
                    }
                    if (ddlSWDA.SelectedValue == "Yes")
                    {
                        if (txtSWDC.Text == "" || txtSWDC.Text == null)
                        {
                            txtSWDC.Focus();
                            MessageBox1.ShowError("Please Enter Solid Waste Disposal Capacity (TDP)");
                            return;
                        }
                        else if (txtSWDU.Text == "" || txtSWDU.Text == null)
                        {
                            txtSWDU.Focus();
                            MessageBox1.ShowError("Please Enter Solid Waste Disposal Utilization (in %)");
                            return;
                        }

                    }
                    if (ddlDhA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Dormitories/Hostels for workers available");
                        return;
                    }
                    if (ddlDhA.SelectedValue == "Yes")
                    {

                        if (txtDormitoriesCapecity.Text == "" || txtDormitoriesCapecity.Text == null)
                        {
                            txtDormitoriesCapecity.Focus();
                            MessageBox1.ShowError("Please Enter Dormitories Capecity");
                            return;
                        }
                    }
                    if (ddlPtA.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Designated Truck parking available inside the park");
                        return;
                    }
                    if (ddlPtA.SelectedValue == "Yes")
                    {

                        if (txtTruckparkingCapecity.Text == "" || txtTruckparkingCapecity.Text == null)
                        {
                            txtTruckparkingCapecity.Focus();
                            MessageBox1.ShowError("Please Enter Designated Truck parking Capecity");
                            return;
                        }
                    }
                    if (ddlEnvtClOb.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  Environmental Clearance Obtained");
                        return;
                    }
                    if (ddlEnvtClOb.SelectedValue == "Yes")
                    {
                        if (txtApprovalReffno.Text == "" || txtApprovalReffno.Text == null)
                        {
                            txtApprovalReffno.Focus();
                            MessageBox1.ShowError("Please Enter Designated Truck parking Capecity");
                            return;
                        }
                    }
                    if (txtOtherInformation.Text == "" || txtOtherInformation.Text == null)
                    {
                        MessageBox1.ShowWarning("Please Provide Other Information if Any");
                        return;
                    }
                     if (ddlpollutionCategorystatus.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  any pollution category Restriction");
                        return;
                    }
                     if (drppollutionCategory.SelectedIndex == 0)
                    {
                        MessageBox1.ShowWarning("Please Select  any pollution category ");
                        return;
                    }
                    
                        SaveDetails();
                    
                    
                }
                
            }
        }
        private void SaveDetails()
        {

            try
            {
                string listboxvalue1 = "";
                string IndustriesAllowed = "";
                string listVillage = "";
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());
                objServiceTimelinesBEL.Distict = Convert.ToInt32((drpDistict.SelectedValue.Trim()));
                objServiceTimelinesBEL.SubDistict = Convert.ToInt32(ddlSubDistict.SelectedValue.Trim());
                if (lblIAID.Text == "" || lblIAID.Text == null)
                {
                    objServiceTimelinesBEL.IAId = 0;
                }
                else
                {
                    objServiceTimelinesBEL.IAId = Convert.ToInt32(lblIAID.Text);
                }

                foreach (ListItem List1 in this.List1.Items)
                {
                    if (List1.Selected == true)
                    {
                        listboxvalue1 = listboxvalue1 + List1.Value + ",";
                    }
                }
                foreach (ListItem drpIndustriesAllowed in this.drpIndustriesAllowed.Items)
                {
                    if (drpIndustriesAllowed.Selected == true)
                    {
                        IndustriesAllowed = IndustriesAllowed + drpIndustriesAllowed.Value + ",";
                    }
                }
                foreach (ListItem ddlVillage in this.ddlVillage.Items)
                {
                    if (ddlVillage.Selected == true)
                    {
                        listVillage = listVillage + ddlVillage.Value + ",";
                    }
                }
                objServiceTimelinesBEL.IAName = txtIndustrialArea.Text.Trim();
                objServiceTimelinesBEL.IACategory = (IACategory.SelectedValue.Trim());

                objServiceTimelinesBEL.TotalLandAcquired = Convert.ToDecimal(txtBoxTotalLandAcquired.Text.Trim());
                objServiceTimelinesBEL.TotIALandForAllotment = Convert.ToDecimal(textBoxTotIALandForAllotment.Text.Trim());
                objServiceTimelinesBEL.TotIAPlotsForAllotment = Convert.ToInt32(textBoxTotIAPlotsForAllotment.Text.Trim());
                objServiceTimelinesBEL.IARatePerSqmt = Convert.ToDecimal(txtIARatePerSqmt.Text.Trim());
                objServiceTimelinesBEL.TotResLandForAllotment = Convert.ToDecimal(txtBackTotResLandForAllotment.Text.Trim());
                objServiceTimelinesBEL.TotResPlotForAllotment = Convert.ToInt32(txtTotResPlotForAllotment.Text.Trim());
                objServiceTimelinesBEL.ResRatePerSqmt = Convert.ToDecimal(txtResRatePerSqmt.Text.Trim());
                objServiceTimelinesBEL.TotCommLandForAllotment = Convert.ToDecimal(txtTotCommLandForAllotment.Text.Trim());
                objServiceTimelinesBEL.TotCommPlotsForAllotment = Convert.ToInt32(txtTotCommPlotsForAllotment.Text.Trim());
                objServiceTimelinesBEL.CommRatePerSqmt = Convert.ToDecimal(txtCommRatePerSqmt.Text.Trim());
                objServiceTimelinesBEL.TotInstLandForAllotment = Convert.ToDecimal(txtTotInstLandForAllotment.Text.Trim());
                objServiceTimelinesBEL.TotInstPlotsForAllotment = Convert.ToInt32(txtTotInstPlotsForAllotment.Text.Trim());
                objServiceTimelinesBEL.InstRatePerSqmt = Convert.ToDecimal(txtInstRatePerSqmt.Text.Trim());
                objServiceTimelinesBEL.LandForFacilities = Convert.ToDecimal(txtLandForFacilities.Text.Trim());
                objServiceTimelinesBEL.LandForRoad = Convert.ToDecimal(txtLandForRoad.Text.Trim());
                objServiceTimelinesBEL.LandUnderGreenBelt = Convert.ToDecimal(txtLandUnderGreenBelt.Text.Trim());
                objServiceTimelinesBEL.LandForPark = Convert.ToDecimal(txtLandForPark.Text.Trim());
                objServiceTimelinesBEL.BulkLand = Convert.ToDecimal(txtBulkLand.Text.Trim());
                objServiceTimelinesBEL.OtherLandArea = Convert.ToDecimal(txtOtherLandArea.Text.Trim());
                objServiceTimelinesBEL.IndustriesAllowed = IndustriesAllowed.TrimEnd(',').Trim();
                objServiceTimelinesBEL.FacilitiesAvailable = listboxvalue1.TrimEnd(',').Trim();
                objServiceTimelinesBEL.OtherLandDesc = txtOtherLandDesc.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = _objLoginInfo.userName.ToString();
                objServiceTimelinesBEL.pollutionCategorystatus = Convert.ToInt32(ddlpollutionCategorystatus.SelectedValue.Trim());
                objServiceTimelinesBEL.PollutionCategory = Convert.ToInt32(drppollutionCategory.SelectedValue.Trim());
                objServiceTimelinesBEL.UseZone = (ddlUsezone.SelectedValue.Trim());
                objServiceTimelinesBEL.InstantAllotment = Convert.ToInt32(ddlInstantAllotment.SelectedValue.Trim());

                #region NewGISCode

                objServiceTimelinesBEL.parksd = txtparksd.Text.Trim();
                objServiceTimelinesBEL.TypeofindustrialArea = (ddlIAType.SelectedValue.Trim().ToString());
                objServiceTimelinesBEL.MixedSector = txtMixedSector.Text.Trim();
                objServiceTimelinesBEL.SubSector = txtSubSector.Text.Trim();
                objServiceTimelinesBEL.NHighway = txtNHighway.Text.Trim();
                objServiceTimelinesBEL.DistNH = txtDistNH.Text.Trim();
                objServiceTimelinesBEL.SHighway = txtSHighway.Text.Trim();
                objServiceTimelinesBEL.DistSH = txtDistSH.Text.Trim();
                objServiceTimelinesBEL.RStation = txtRStation.Text.Trim();
                objServiceTimelinesBEL.DistRS = txtDistRS.Text.Trim();
                objServiceTimelinesBEL.Airport = txtAirport.Text.Trim();
                objServiceTimelinesBEL.DistAir = txtDistAir.Text.Trim();
                objServiceTimelinesBEL.Seaport = txtSeaport.Text.Trim();
                objServiceTimelinesBEL.Distport = txtDistport.Text.Trim();
                objServiceTimelinesBEL.DryPort = txtDryPort.Text.Trim();
                objServiceTimelinesBEL.Distdryport = txtDistdryport.Text.Trim();
                objServiceTimelinesBEL.DistRailS = txtDistRailS.Text.Trim();
                objServiceTimelinesBEL.Zonal = (ddlZonal.SelectedValue.Trim());
                objServiceTimelinesBEL.DistZonal = txtDistZonal.Text.Trim();
                objServiceTimelinesBEL.PoliceSt = txtPoliceSt.Text.Trim();
                objServiceTimelinesBEL.DistPolice = txtDistPolice.Text.Trim();
                objServiceTimelinesBEL.FireSt = txtFireSt.Text.Trim();
                objServiceTimelinesBEL.DistFire = txtDistFire.Text.Trim();
                objServiceTimelinesBEL.Bank = txtBank.Text.Trim();
                objServiceTimelinesBEL.DistBank = txtDistBank.Text.Trim();
                objServiceTimelinesBEL.Hospital = txtHospital.Text.Trim();
                objServiceTimelinesBEL.DistHosp = txtDistHosp.Text.Trim();
                objServiceTimelinesBEL.ElectA = (ddlElectA.SelectedValue.Trim());
                objServiceTimelinesBEL.ElectC = txtElectC.Text.Trim();
                objServiceTimelinesBEL.ElectU = txtElectU.Text.Trim();
                objServiceTimelinesBEL.WaterA = (ddlWaterA.SelectedValue.Trim());
                objServiceTimelinesBEL.WaterC = txtWaterC.Text.Trim();
                objServiceTimelinesBEL.WaterU = txtWaterU.Text.Trim();
                objServiceTimelinesBEL.GasLine = (ddlGasLine.SelectedValue.Trim());
                objServiceTimelinesBEL.GasC = txtGasC.Text.Trim();
                objServiceTimelinesBEL.GasU = txtGasU.Text.Trim();
                objServiceTimelinesBEL.STP = (ddlSTP.SelectedValue.Trim());
                objServiceTimelinesBEL.STPC = txtSTPC.Text.Trim();
                objServiceTimelinesBEL.STPU = txtSTPU.Text.Trim();
                objServiceTimelinesBEL.EPoleA = (ddlEPoleA.SelectedValue.Trim());
                objServiceTimelinesBEL.PowerSSA = (ddlPowerSSA.SelectedValue.Trim());
                objServiceTimelinesBEL.PowerSSC = txtPowerSSC.Text.Trim();
                objServiceTimelinesBEL.PowerSSU = txtPowerSSU.Text.Trim();
                objServiceTimelinesBEL.WTP = (ddlWTP.SelectedValue.Trim());
                objServiceTimelinesBEL.WTPC = txtWTPC.Text.Trim();
                objServiceTimelinesBEL.WTPU = txtWTPU.Text.Trim();
                objServiceTimelinesBEL.ICT = (ddlICT.SelectedValue.Trim());
                objServiceTimelinesBEL.ICTS = txtICTS.Text.Trim();
                objServiceTimelinesBEL.SWDA = (ddlSWDA.SelectedValue.Trim());
                objServiceTimelinesBEL.SWDC = txtSWDC.Text.Trim();
                objServiceTimelinesBEL.SWDU = txtSWDU.Text.Trim();
                objServiceTimelinesBEL.DhA = (ddlDhA.SelectedValue.Trim());
                objServiceTimelinesBEL.PtA = (ddlPtA.SelectedValue.Trim());
                objServiceTimelinesBEL.OtherInformation = txtOtherInformation.Text.Trim();
                objServiceTimelinesBEL.EnvtClOb = (ddlEnvtClOb.SelectedValue.Trim());
                objServiceTimelinesBEL.TruckparkingCapecity = txtTruckparkingCapecity.Text.Trim();
                objServiceTimelinesBEL.DormitoriesCapecity = txtDormitoriesCapecity.Text.Trim();
                objServiceTimelinesBEL.Village = listVillage.TrimEnd(',').Trim();
                objServiceTimelinesBEL.ApprovalReffno = txtApprovalReffno.Text.Trim();




                #endregion

                int Result = objServiceTimelinesBLL.IndustrialAreaEntryMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('IA Inserted/Updated Successfully');", true);
                    DisabledControls();
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
            txtIndustrialArea.Enabled = false;
            IACategory.Enabled = false;
            txtBoxTotalLandAcquired.Enabled = false;
            textBoxTotIALandForAllotment.Enabled = false;
            textBoxTotIAPlotsForAllotment.Enabled = false;
            txtIARatePerSqmt.Enabled = false;
            txtBackTotResLandForAllotment.Enabled = false;
            txtTotResPlotForAllotment.Enabled = false;
            txtResRatePerSqmt.Enabled = false;
            txtTotCommLandForAllotment.Enabled = false;
            txtTotCommPlotsForAllotment.Enabled = false;
            txtCommRatePerSqmt.Enabled = false;

            txtTotInstPlotsForAllotment.Enabled = false;

            txtInstRatePerSqmt.Enabled = false;
            txtLandForFacilities.Enabled = false;
            txtLandForRoad.Enabled = false;

            txtLandUnderGreenBelt.Enabled = false;
            txtLandForPark.Enabled = false;
            txtBulkLand.Enabled = false;

            txtLandUnderGreenBelt.Enabled = false;
            txtLandForPark.Enabled = false;
            txtBulkLand.Enabled = false;
            txtOtherLandArea.Enabled = false;
            drppollutionCategory.Enabled = false;
            ddlUsezone.Enabled = false;
            ddlInstantAllotment.Enabled = false;
            txtOtherLandDesc.Enabled = false;
            txtTotInstLandForAllotment.Enabled = false;
            this.List1.Attributes.Add("disabled", "");
            this.drpIndustriesAllowed.Attributes.Add("disabled", "");
            ddlIAType.Enabled = false;
            ddlEnvtClOb.Enabled = false;

            txtparksd.Enabled = false;
            ddlIAType.Enabled = false;
            txtMixedSector.Enabled = false;
            txtSubSector.Enabled = false;
            txtNHighway.Enabled = false;
            txtDistNH.Enabled = false;
            txtSHighway.Enabled = false;
            txtDistSH.Enabled = false;
            txtRStation.Enabled = false;
            txtDistRS.Enabled = false;
            txtAirport.Enabled = false;
            txtDistAir.Enabled = false;
            txtSeaport.Enabled = false;
            txtDistport.Enabled = false;
            txtDryPort.Enabled = false;
            txtDistdryport.Enabled = false;
            txtDistRailS.Enabled = false;
            ddlZonal.Enabled = false;
            txtDistZonal.Enabled = false;
            txtPoliceSt.Enabled = false;
            txtDistPolice.Enabled = false;
            txtFireSt.Enabled = false;
            txtDistFire.Enabled = false;
            txtBank.Enabled = false;
            txtHospital.Enabled = false;
            txtDistHosp.Enabled = false;
            txtDistBank.Enabled = false;
            ddlElectA.Enabled = false;
            txtElectC.Enabled = false;
            txtElectU.Enabled = false;
            ddlWaterA.Enabled = false;
            txtWaterC.Enabled = false;
            txtWaterU.Enabled = false;
            ddlGasLine.Enabled = false;
            txtGasC.Enabled = false;
            txtGasU.Enabled = false;
            ddlSTP.Enabled = false;
            txtSTPC.Enabled = false;
            txtSTPU.Enabled = false;
            ddlPowerSSA.Enabled = false;
            ddlEPoleA.Enabled = false;
            txtPowerSSC.Enabled = false;
            txtPowerSSU.Enabled = false;
            ddlWTP.Enabled = false;
            txtWTPC.Enabled = false;
            txtWTPU.Enabled = false;
            ddlICT.Enabled = false;
            txtICTS.Enabled = false;
            ddlSWDA.Enabled = false;
            txtSWDC.Enabled = false;
            txtSWDU.Enabled = false;
            ddlDhA.Enabled = false;
            ddlPtA.Enabled = false;
            txtOtherInformation.Enabled = false;
            ddlEnvtClOb.Enabled = false;
            ddlSubDistict.Enabled = false;
            txtTruckparkingCapecity.Enabled = false;
            txtDormitoriesCapecity.Enabled = false;
            txtApprovalReffno.Enabled = false;
            this.ddlVillage.Attributes.Add("disabled", "");
        }


        protected void menuedit_ServerClick(object sender, EventArgs e)
        {
            if (Level == "RM")
            {
                if (txtIndustrialArea.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Industrial Area to Edit');", true);
                    return;
                }
                else
                {
                    Regional_Changed(null, null);
                    drpDistict_SelectedIndexChanged(null, null);
                    ddlSubDistict_SelectedIndexChanged(null, null);
                    drpDistict.Enabled = true;
                    txtIndustrialArea.Enabled = true;
                    txtOtherLandDesc.Enabled = true;
                    this.List1.Attributes.Remove("disabled");
                    this.drpIndustriesAllowed.Attributes.Remove("disabled");
                    IACategory.Enabled = true;
                    txtBoxTotalLandAcquired.Enabled = true;
                    textBoxTotIALandForAllotment.Enabled = true;
                    textBoxTotIAPlotsForAllotment.Enabled = true;
                    txtIARatePerSqmt.Enabled = true;
                    txtBackTotResLandForAllotment.Enabled = true;
                    txtTotResPlotForAllotment.Enabled = true;
                    txtResRatePerSqmt.Enabled = true;
                    txtTotCommLandForAllotment.Enabled = true;
                    txtTotCommPlotsForAllotment.Enabled = true;
                    txtCommRatePerSqmt.Enabled = true;
                    txtTotInstLandForAllotment.Enabled = true;
                    txtTotInstPlotsForAllotment.Enabled = true;
                    txtInstRatePerSqmt.Enabled = true;
                    txtLandForFacilities.Enabled = true;
                    txtLandForRoad.Enabled = true;
                    txtLandUnderGreenBelt.Enabled = true;
                    txtLandForPark.Enabled = true;
                    txtBulkLand.Enabled = true;
                    txtLandUnderGreenBelt.Enabled = true;
                    txtLandForPark.Enabled = true;
                    txtBulkLand.Enabled = true;
                    txtOtherLandArea.Enabled = true;
                    drppollutionCategory.Enabled = true;
                    ddlpollutionCategorystatus.Enabled = true;
                    drppollutionCategory.Enabled = true;
                    ddlUsezone.Enabled = true;
                    btnupload.Enabled = true;
                    btnView.Enabled = true;
                    ddlInstantAllotment.Enabled = true;
                    ddlIAType.Enabled = true;
                    ddlEnvtClOb.Enabled = true;

                    txtparksd.Enabled = true;
                    ddlIAType.Enabled = true;
                    txtMixedSector.Enabled = true;
                    txtSubSector.Enabled = true;
                    txtNHighway.Enabled = true;
                    txtDistNH.Enabled = true;
                    txtSHighway.Enabled = true;
                    txtDistSH.Enabled = true;
                    txtRStation.Enabled = true;
                    txtDistRS.Enabled = true;
                    txtAirport.Enabled = true;
                    txtDistAir.Enabled = true;
                    txtSeaport.Enabled = true;
                    txtDistport.Enabled = true;
                    txtDryPort.Enabled = true;
                    txtDistdryport.Enabled = true;
                    txtDistRailS.Enabled = true;
                    ddlZonal.Enabled = true;
                    txtDistZonal.Enabled = true;
                    txtPoliceSt.Enabled = true;
                    txtDistPolice.Enabled = true;
                    txtFireSt.Enabled = true;
                    txtDistFire.Enabled = true;
                    txtBank.Enabled = true;
                    txtDistBank.Enabled = true;
                    txtHospital.Enabled = true;
                    txtDistHosp.Enabled = true;
                    ddlElectA.Enabled = true;
                    txtElectC.Enabled = true;
                    txtElectU.Enabled = true;
                    ddlWaterA.Enabled = true;
                    txtWaterC.Enabled = true;
                    txtWaterU.Enabled = true;
                    ddlGasLine.Enabled = true;
                    txtGasC.Enabled = true;
                    txtGasU.Enabled = true;
                    ddlSTP.Enabled = true;
                    txtSTPC.Enabled = true;
                    txtSTPU.Enabled = true;
                    ddlPowerSSA.Enabled = true;
                    ddlEPoleA.Enabled = true;
                    txtPowerSSC.Enabled = true;
                    txtPowerSSU.Enabled = true;
                    ddlWTP.Enabled = true;
                    txtWTPC.Enabled = true;
                    txtWTPU.Enabled = true;
                    ddlICT.Enabled = true;
                    txtICTS.Enabled = true;
                    ddlSWDA.Enabled = true;
                    txtSWDC.Enabled = true;
                    txtSWDU.Enabled = true;
                    ddlDhA.Enabled = true;
                    ddlPtA.Enabled = true;
                    txtOtherInformation.Enabled = true;
                    ddlEnvtClOb.Enabled = true;
                    ddlSubDistict.Enabled = true;
                    txtTruckparkingCapecity.Enabled = true;
                    txtDormitoriesCapecity.Enabled = true;
                    txtApprovalReffno.Enabled = true;
                    this.ddlVillage.Attributes.Remove("disabled");
                }
            }
            else
            {
                if (txtIndustrialArea.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select Industrial Area to Edit');", true);
                    return;
                }
                else
                {
                    drpDistict.Enabled = true;
                    txtIndustrialArea.Enabled = true;
                    txtOtherLandDesc.Enabled = true;
                    IACategory.Enabled = true;
                    txtBoxTotalLandAcquired.Enabled = true;
                    textBoxTotIALandForAllotment.Enabled = true;
                    textBoxTotIAPlotsForAllotment.Enabled = true;
                    txtIARatePerSqmt.Enabled = true;
                    txtBackTotResLandForAllotment.Enabled = true;
                    txtTotResPlotForAllotment.Enabled = true;
                    txtResRatePerSqmt.Enabled = true;
                    txtTotCommLandForAllotment.Enabled = true;
                    txtTotCommPlotsForAllotment.Enabled = true;
                    txtCommRatePerSqmt.Enabled = true;
                    txtTotInstLandForAllotment.Enabled = true;
                    txtTotInstPlotsForAllotment.Enabled = true;
                    txtInstRatePerSqmt.Enabled = true;
                    txtLandForFacilities.Enabled = true;
                    txtLandForRoad.Enabled = true;
                    txtLandUnderGreenBelt.Enabled = true;
                    txtLandForPark.Enabled = true;
                    txtBulkLand.Enabled = true;
                    txtLandUnderGreenBelt.Enabled = true;
                    txtLandForPark.Enabled = true;
                    txtBulkLand.Enabled = true;
                    txtOtherLandArea.Enabled = true;
                    drppollutionCategory.Enabled = true;
                    ddlpollutionCategorystatus.Enabled = true;
                    this.List1.Attributes.Remove("disabled");
                    this.drpIndustriesAllowed.Attributes.Remove("disabled");
                    drppollutionCategory.Enabled = true;
                    ddlUsezone.Enabled = true;
                    btnupload.Enabled = true;
                    btnView.Enabled = true;
                    ddlInstantAllotment.Enabled = true;
                    ddlIAType.Enabled = true;
                    ddlEnvtClOb.Enabled = true;
                    txtparksd.Enabled = true;
                    ddlIAType.Enabled = true;
                    txtMixedSector.Enabled = true;
                    txtSubSector.Enabled = true;
                    txtNHighway.Enabled = true;
                    txtDistNH.Enabled = true;
                    txtSHighway.Enabled = true;
                    txtDistSH.Enabled = true;
                    txtRStation.Enabled = true;
                    txtDistRS.Enabled = true;
                    txtAirport.Enabled = true;
                    txtDistAir.Enabled = true;
                    txtSeaport.Enabled = true;
                    txtDistport.Enabled = true;
                    txtDryPort.Enabled = true;
                    txtDistdryport.Enabled = true;
                    txtDistRailS.Enabled = true;
                    ddlZonal.Enabled = true;
                    txtDistZonal.Enabled = true;
                    txtPoliceSt.Enabled = true;
                    txtDistPolice.Enabled = true;
                    txtFireSt.Enabled = true;
                    txtDistFire.Enabled = true;
                    txtBank.Enabled = true;
                    txtDistBank.Enabled = true;
                    txtHospital.Enabled = true;
                    txtDistHosp.Enabled = true;
                    ddlElectA.Enabled = true;
                    txtElectC.Enabled = true;
                    txtElectU.Enabled = true;
                    ddlWaterA.Enabled = true;
                    txtWaterC.Enabled = true;
                    txtWaterU.Enabled = true;
                    ddlGasLine.Enabled = true;
                    txtGasC.Enabled = true;
                    txtGasU.Enabled = true;
                    ddlSTP.Enabled = true;
                    txtSTPC.Enabled = true;
                    txtSTPU.Enabled = true;
                    ddlPowerSSA.Enabled = true;
                    ddlEPoleA.Enabled = true;
                    txtPowerSSC.Enabled = true;
                    txtPowerSSU.Enabled = true;
                    ddlWTP.Enabled = true;
                    txtWTPC.Enabled = true;
                    txtWTPU.Enabled = true;
                    ddlICT.Enabled = true;
                    txtICTS.Enabled = true;
                    ddlSWDA.Enabled = true;
                    txtSWDC.Enabled = true;
                    txtSWDU.Enabled = true;
                    ddlDhA.Enabled = true;
                    ddlPtA.Enabled = true;
                    txtOtherInformation.Enabled = true;
                    ddlEnvtClOb.Enabled = true;
                    ddlSubDistict.Enabled = true;
                    this.ddlVillage.Attributes.Remove("disabled");
                    txtTruckparkingCapecity.Enabled = true;
                    txtDormitoriesCapecity.Enabled = true;
                    txtApprovalReffno.Enabled = true;
                }
            }
        }

        protected void menunew_ServerClick(object sender, EventArgs e)
        {
            txtOtherLandDesc.Enabled = true;
            txtOtherLandDesc.Text = "";
            drpDistict.Enabled = true;
            drpDistict.SelectedIndex = 0;
            txtIndustrialArea.Enabled = true;
            txtIndustrialArea.Text = "";
            IACategory.Enabled = true;
            IACategory.SelectedIndex = 0;
            txtBoxTotalLandAcquired.Enabled = true;
            txtBoxTotalLandAcquired.Text = "";
            textBoxTotIALandForAllotment.Enabled = true;
            textBoxTotIALandForAllotment.Text = "";

            textBoxTotIAPlotsForAllotment.Enabled = true;
            textBoxTotIAPlotsForAllotment.Text = "";

            txtIARatePerSqmt.Enabled = true;
            txtIARatePerSqmt.Text = "";

            txtBackTotResLandForAllotment.Enabled = true;
            txtBackTotResLandForAllotment.Text = "";

            txtTotResPlotForAllotment.Enabled = true;
            txtTotResPlotForAllotment.Text = "";

            txtResRatePerSqmt.Enabled = true;
            txtResRatePerSqmt.Text = "";

            txtTotCommLandForAllotment.Enabled = true;
            txtTotCommLandForAllotment.Text = "";

            txtTotCommPlotsForAllotment.Enabled = true;
            txtTotCommPlotsForAllotment.Text = "";

            txtCommRatePerSqmt.Enabled = true;

            txtCommRatePerSqmt.Text = "";

            txtTotInstLandForAllotment.Enabled = true;
            txtTotInstLandForAllotment.Text = "";

            txtTotInstPlotsForAllotment.Enabled = true;

            txtTotInstPlotsForAllotment.Text = "";
            txtInstRatePerSqmt.Enabled = true;
            txtInstRatePerSqmt.Text = "";
            txtLandForFacilities.Enabled = true;
            txtLandForFacilities.Text = "";
            txtLandForRoad.Enabled = true;
            txtLandForRoad.Text = "";
            txtLandUnderGreenBelt.Enabled = true;
            txtLandUnderGreenBelt.Text = "";
            txtLandForPark.Enabled = true;
            txtLandForPark.Text = "";
            txtBulkLand.Enabled = true;
            txtBulkLand.Text = "";
            txtLandUnderGreenBelt.Enabled = true;
            txtLandUnderGreenBelt.Text = "";
            txtLandForPark.Enabled = true;
            txtLandForPark.Text = "";
            txtOtherLandArea.Enabled = true;
            txtOtherLandArea.Text = "";
            drppollutionCategory.Enabled = true;
            drppollutionCategory.SelectedIndex = 0;
            drpIndustriesAllowed.ClearSelection();
            drpIndustriesAllowed.Attributes.Remove("disabled");
            List1.ClearSelection();
            List1.Attributes.Remove("disabled");
            lblIAID.Text = "";
            ddlpollutionCategorystatus.Enabled = true;
            ddlInstantAllotment.Enabled = true;
            ddlIAType.Enabled = true;
            ddlEnvtClOb.Enabled = true;
            txtparksd.Enabled = true;
            ddlIAType.Enabled = true;
            txtMixedSector.Enabled = true;
            txtSubSector.Enabled = true;
            txtNHighway.Enabled = true;
            txtDistNH.Enabled = true;
            txtSHighway.Enabled = true;
            txtDistSH.Enabled = true;
            txtRStation.Enabled = true;
            txtDistRS.Enabled = true;
            txtAirport.Enabled = true;
            txtDistAir.Enabled = true;
            txtSeaport.Enabled = true;
            txtDistport.Enabled = true;
            txtDryPort.Enabled = true;
            txtDistdryport.Enabled = true;
            txtDistRailS.Enabled = true;
            ddlZonal.Enabled = true;
            txtDistZonal.Enabled = true;
            txtPoliceSt.Enabled = true;
            txtDistPolice.Enabled = true;
            txtFireSt.Enabled = true;
            txtDistFire.Enabled = true;
            txtBank.Enabled = true;
            txtDistBank.Enabled = true;
            txtHospital.Enabled = true;
            txtDistHosp.Enabled = true;
            ddlElectA.Enabled = true;
            txtElectC.Enabled = true;
            txtElectU.Enabled = true;
            ddlWaterA.Enabled = true;
            txtWaterC.Enabled = true;
            txtWaterU.Enabled = true;
            ddlGasLine.Enabled = true;
            txtGasC.Enabled = true;
            txtGasU.Enabled = true;
            ddlSTP.Enabled = true;
            txtSTPC.Enabled = true;
            txtSTPU.Enabled = true;
            ddlPowerSSA.Enabled = true;
            ddlEPoleA.Enabled = true;
            txtPowerSSC.Enabled = true;
            txtPowerSSU.Enabled = true;
            ddlWTP.Enabled = true;
            txtWTPC.Enabled = true;
            txtWTPU.Enabled = true;
            ddlICT.Enabled = true;
            txtICTS.Enabled = true;
            ddlSWDA.Enabled = true;
            txtSWDC.Enabled = true;
            txtSWDU.Enabled = true;
            ddlDhA.Enabled = true;
            ddlPtA.Enabled = true;
            txtOtherInformation.Enabled = true;
            ddlEnvtClOb.Enabled = true;
            ddlVillage.ClearSelection();
            this.ddlVillage.Attributes.Remove("disabled");
        }


        private void DeleteIndustrialArea()
        {

            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                objServiceTimelinesBEL.RegionalOffice = (ddloffice.SelectedValue.Trim());

                objServiceTimelinesBEL.IAId = Convert.ToInt32(lblIAID.Text);


                int Result = objServiceTimelinesBLL.DeleteIndustrialAreaMaster(objServiceTimelinesBEL);

                if (Result > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('IA Inactive Successfully');", true);
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
            if (txtIndustrialArea.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Choose IA To Inactive');", true);
                return;
            }
            else
            {
                if (txtIndustrialArea.Enabled == false)
                {
                    DeleteIndustrialArea();
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
            SaveDetails();
        }

        protected void ddlpollutionCategorystatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpollutionCategorystatus.SelectedValue == "1")
            {
                Tracing.Visible = true;
            }
            else
            {
                Tracing.Visible = false;
            }
        }


        protected void btnView_Click(object sender, EventArgs e)
        {

            if (txtIndustrialArea.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select any Plot !');", true);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ID = Convert.ToInt32(lblIAID.Text.Trim());
                ds = objServiceTimelinesBLL.GetReleventDocView(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];
                string Name = dtDoc.Rows[0]["DocName"].ToString();
                if (Name.Length > 0)
                {
                    String js = "window.open('RelevantOrderViewer.aspx?ID=" + lblIAID.Text.Trim() + "', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RelevantOrderViewer.aspx", js, true);
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

        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIAID.Text.Length > 0)
                {
                    this.RegisterPostBackControl();
                    int retval = 0;
                    if (fileupload1.HasFile)
                    {
                        string filePath = fileupload1.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fileupload1.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;

                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fileupload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.ID = Convert.ToInt32(lblIAID.Text.Trim());
                            retval = objServiceTimelinesBLL.UploadReleventDocument(objServiceTimelinesBEL);
                            if (retval > 0)
                            {

                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('pollutionCategory Relevent Uploaded Successfully !');", true);
                                return;
                            }


                        }

                    }
                    else
                    {
                        objServiceTimelinesBEL.filename = String.Empty;
                        objServiceTimelinesBEL.content = String.Empty;
                        objServiceTimelinesBEL.Uploadfile = null;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured !');", true);
                        return;
                    }
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('choose Industrial Area first');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void drpIndustriesAllowed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIndustriesAllowed.SelectedValue == "9")
            {
                divMixedSector.Visible = true;

            }
            else
            {
                divMixedSector.Visible = false;

            }
        }

        protected void ddlElectA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlElectA.SelectedValue == "Yes")
            {
                divElectU.Visible = true;

            }
            else
            {
                divElectU.Visible = false;

            }
        }

        protected void ddlWaterA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWaterA.SelectedValue == "Yes")
            {
                divWaterC.Visible = true;

            }
            else
            {
                divWaterC.Visible = false;

            }
        }

        protected void ddlGasLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGasLine.SelectedValue == "Yes")
            {
                divGasC.Visible = true;

            }
            else
            {
                divGasC.Visible = false;

            }
        }

        protected void ddlSTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSTP.SelectedValue == "Yes")
            {
                divSTPC.Visible = true;

            }
            else
            {
                divSTPC.Visible = false;

            }
        }

        protected void ddlPowerSSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPowerSSA.SelectedValue == "Yes")
            {
                divPowerSSC.Visible = true;

            }
            else
            {
                divPowerSSC.Visible = false;

            }
        }

        protected void ddlWTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWTP.SelectedValue == "Yes")
            {
                divWTPC.Visible = true;

            }
            else
            {
                divWTPC.Visible = false;

            }
        }

        protected void ddlICT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlICT.SelectedValue == "Yes")
            {
                divICTS.Visible = true;

            }
            else
            {
                divICTS.Visible = false;

            }
        }

        protected void ddlSWDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSWDA.SelectedValue == "Yes")
            {
                divSWDC.Visible = true;

            }
            else
            {
                divSWDC.Visible = false;

            }
        }



        protected void ddlEnvtClOb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEnvtClOb.SelectedValue == "Yes")
            {
                divApprovalreffno.Visible = true;

            }
            else
            {
                divApprovalreffno.Visible = false;

            }
        }

        protected void ddlDhA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDhA.SelectedValue == "Yes")
            {
                divDormitoriesCapecity.Visible = true;

            }
            else
            {
                divDormitoriesCapecity.Visible = false;

            }
        }

        protected void ddlPtA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPtA.SelectedValue == "Yes")
            {
                divTruckparkingCapecity.Visible = true;

            }
            else
            {
                divTruckparkingCapecity.Visible = false;

            }
        }
    }
}