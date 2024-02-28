
using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;

namespace Allotment
{
    public partial class InstantAllotteeApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        String ServiceReqNo = "";
        string OfficePhone = "";
        string OfficeEmail = "";

        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "fcf18dfd1405fbe78ff459e85e7b96";
        string Status_Code = "";
        string Remarks = "";
        string Fee_Amount = "";
        string Fee_Status = "";
        string Transaction_ID = "";
        string Transaction_Date = "";
        string Transaction_Date_Time = "";
        string NOC_Certificate_Number = "";
        string NOC_URL = "";
        string ISNOC_URL_ActiveYesNO = "";
        string GISIAID;
        string PlotNo = "";

        SqlConnection con;


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = new UC_Service_Allotteee_Detail();
            UC_Service_Building_Plan UC_Service_Building_Plan = new UC_Service_Building_Plan();

            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                GISIAID = Request.QueryString["IAID"];
                PlotNo = Request.QueryString["PlotNo"];
                ServiceReqNo = Request.QueryString["ServiceID"];

                PageHeadingLbl.Text = "Application For Land Allottment";


                if (!IsPostBack)
                {
                    UserSpecificBinding();

                    if (GISIAID != null)
                    {
                        SqlCommand cmd = new SqlCommand("select A.* , (Select PlotArea from PlotMaster where IAID=A.ID and PlotNumber='" + PlotNo + "') 'PlotArea' from IndustrialArea A where A.GISIAID='" + GISIAID.Trim() + "'", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string IAName = dt.Rows[0]["ID"].ToString();
                            string ReagionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                            string Area = dt.Rows[0]["PlotArea"].ToString();

                            ddloffice.SelectedValue = ReagionalOffice.Trim();
                            drpdwnIA.SelectedValue = IAName.Trim();
                            string PlotNumber = PlotNo.Trim() + "|" + Area.Trim() + "|" + "SQmts.";
                            txtp1.Text = PlotNumber;

                            Allotment.ActiveViewIndex = 2;
                            Div_Plot.Visible = false;
                        }

                        else
                        {
                            Div_Plot.Visible = true;
                            if (Allotment.ActiveViewIndex <= 0)
                            {

                                Allotment.ActiveViewIndex = 1;

                            }
                            else
                            {

                                Allotment.ActiveViewIndex = 3;

                            }

                        }

                    }else
                    {
                        Div_Plot.Visible = true;
                        if (Allotment.ActiveViewIndex <= 0)
                        {

                            Allotment.ActiveViewIndex = 1;

                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }

                    multi.ActiveViewIndex = 0;

                }






            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Alert('" + ex.ToString() + "');", true);
                return;
            }
        }

        private void bindIA(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drdIA.DataSource = ds;
                drdIA.DataTextField = "IAName";
                drdIA.DataValueField = "Id";
                drdIA.DataBind();
                drdIA.Items.Insert(0, new ListItem("--Select--", "0"));

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

        protected void Regionaloffice_Changed(object sender, EventArgs e)
        {

            try { bindIA(drdRegionaoffice.SelectedItem.Value, null); } catch { }


        }


        private void NiveshMitra()
        {

            if (ControlID.Length > 0)
            {
                ControlID = Request.Form["TxtControlID"];
                UnitID = Request.Form["TxtUnitID"];
                ServiceID = Request.Form["TxtServiceID"];
                ProcessIndustryID = Request.Form["TxtProcessIndustryID"];
                ApplicationID = Request.Form["TxtApplicationID"];
                passsalt = "fcf18dfd1405fbe78ff459e85e7b96";


                Status_Code = "";
                Remarks = "";
                Fee_Amount = "";
                Fee_Status = "";
                Transaction_ID = "";
                Transaction_Date = "";
                Transaction_Date_Time = "";
                NOC_Certificate_Number = "";
                NOC_URL = "";
                ISNOC_URL_ActiveYesNO = "";

                try
                {


                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet ds = webService.WGetBasicDetails(ControlID, UnitID, ServiceID, "", passsalt);

                    DataTable dt = ds.Tables[0];


                    if (dt.Rows.Count > 0)
                    {


                        lblControlId.Text = ControlID;
                        lblUnitId.Text = UnitID;
                        lblCompanyName.Text = dt.Rows[0]["Company_Name"].ToString();
                        lblIndustryDistrict.Text = dt.Rows[0]["Industry_District"].ToString();
                        lblIndustryAddress.Text = dt.Rows[0]["Industry_Address"].ToString();
                        lblIndustryPincode.Text = dt.Rows[0]["Pin_Code"].ToString();
                        lblOccupierName.Text = dt.Rows[0]["Occupier_Name"].ToString();
                        lblOccupierEmail.Text = dt.Rows[0]["Occupier_Email_ID"].ToString();
                        lblOccupierPhone.Text = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                        lblOccupierPAN.Text = dt.Rows[0]["Occupier_PAN"].ToString();
                        lblOccupierAddress.Text = dt.Rows[0]["Occupier_Address"].ToString();
                        lblOccupierDistrictName.Text = dt.Rows[0]["Occupier_District_Name"].ToString();
                        lblNatureofActivity.Text = dt.Rows[0]["Nature_of_Activity"].ToString();
                        lblInstalledCapacity.Text = dt.Rows[0]["Installed_Capacity"].ToString();
                        lblNoOfEmployee.Text = dt.Rows[0]["Employees"].ToString();
                        lblNature_of_Operation.Text = dt.Rows[0]["Nature_of_Operation"].ToString();
                        lblProject_Cost.Text = dt.Rows[0]["Project_Cost"].ToString();
                        lblOrganization_Type.Text = dt.Rows[0]["Organization_Type"].ToString();
                        lblIndustry_Type_Name.Text = dt.Rows[0]["Industry_Type_Name"].ToString();
                        lblItems_Manufactured.Text = dt.Rows[0]["Items_Manufactured"].ToString();
                        lblAnnual_Turnover.Text = dt.Rows[0]["Annual_Turnover"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Alert('Something Went Wrong With Nivesh Mitra Server');", true);
                    return;
                }

            }


        }

        protected void UserSpecificBinding()
        {

            objServiceTimelinesBEL.UserName = "Admin1";

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecordsInstant(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--Select--", "ALL"));

                drdRegionaoffice.DataSource = dsR.Tables[0];
                drdRegionaoffice.DataTextField = "a";
                drdRegionaoffice.DataValueField = "b";
                drdRegionaoffice.DataBind();
                drdRegionaoffice.Items.Insert(0, new ListItem("--Select--", "ALL"));
                bindDDLRegion(ddloffice.SelectedItem.Value, null);
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


        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecordsInstant(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));

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

        protected void Regional_Changed(object sender, EventArgs e)
        {

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }



        }

        private void BindPlotsInModal()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
               
                ds = objServiceTimelinesBLL.GetListOfVacantPlotsIAWise(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridPlot.DataSource = ds.Tables[0];
                        GridPlot.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no plots available for allotment at this time. You can explore other industrial areas for the availability of plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('"+message+"');", true);
                        btnSave.Enabled = false;
                        GridPlot.DataSource = null;
                        GridPlot.DataBind();
                    }


                }



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


        private void BindPlotsForAmalgamation()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
               

                ds = objServiceTimelinesBLL.GetListOfVacantPlotsIAWise(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridAmalgamation.DataSource = ds.Tables[0];
                        GridAmalgamation.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no plots available for allotment at this time. You can explore other industrial areas for the availability of plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('" + message + "');", true);
                        btnSave.Enabled = false;
                        GridAmalgamation.DataSource = null;
                        GridAmalgamation.DataBind();
                    }


                }



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





        private void BindSubdivisionPlots()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
                
                ds = objServiceTimelinesBLL.GetListOfVacantPlotsForSubdivisionIAWise(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridSubDivision.DataSource = ds.Tables[0];
                        GridSubDivision.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no subdivision plots available for allotment at this time. You can explore other industrial areas for the availability of subdivision plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('" + message + "');", true);
                        btnSave.Enabled = false;
                        GridSubDivision.DataSource = null;
                        GridSubDivision.DataBind();
                    }


                }



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




        protected void check_CheckedChanged(object sender, EventArgs e)
        {

            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("check");


            foreach (GridViewRow gvrow in GridPlot.Rows)
            {


                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("check");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }

            }

            int index = Convert.ToInt32(row.RowIndex);

            string PlotNumber = GridPlot.DataKeys[index].Values[0].ToString() + "|" + GridPlot.DataKeys[index].Values[1].ToString() + "|" + "SQmts.";

            if (ddl2.Checked == true)
            {

                if (count > 1)
                {
                    string message = "Please Select Only One Plot";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    ddl2.Checked = false;
                    return;
                }
                else
                {
                    lblmsgSpan.Visible = false;
                    lblmsgSpan.InnerHtml = "";
                }

                if (txtp1.Text == "")
                { txtp1.Text = PlotNumber; }
                else if (txtp2.Text == "")
                { txtp2.Text = PlotNumber; }
                else if (txtp3.Text == "")
                { txtp3.Text = PlotNumber; }

            }
            else if (ddl2.Checked == false)
            {
                if (txtp1.Text == PlotNumber)
                {
                    txtp1.Text = "";
                }
                if (txtp2.Text == PlotNumber)
                {
                    txtp2.Text = "";
                }
                if (txtp3.Text == PlotNumber)
                {
                    txtp3.Text = "";
                }

            }
        }



        protected void checkSubdivision_CheckedChanged(object sender, EventArgs e)
        {

            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("checkSubdivision");


            foreach (GridViewRow gvrow in GridSubDivision.Rows)
            {


                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("checkSubdivision");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }

            }

            int index = Convert.ToInt32(row.RowIndex);

            string PlotNumber = GridSubDivision.DataKeys[index].Values[0].ToString() + "|" + GridSubDivision.DataKeys[index].Values[1].ToString() + "|" + "SQmts.";

            if (ddl2.Checked == true)
            {

                if (count > 1)
                {
                    string message = "You can select only one plot for subdivision";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    ddl2.Checked = false;
                    return;
                }
                else
                {
                    lblmsgSpan.Visible = false;
                    lblmsgSpan.InnerHtml = "";
                }

                if (txtSubPlot.Text == "")
                { txtSubPlot.Text = PlotNumber; }
               

            }
            else if (ddl2.Checked == false)
            {
                if (txtSubPlot.Text == PlotNumber)
                {
                    txtSubPlot.Text = "";
                }
               

            }
        }

        protected void checkAmalgamation_CheckedChanged(object sender, EventArgs e)
        {

            try
            {


                CheckBox chk = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chk.NamingContainer;
                CheckBox ddl2 = (CheckBox)row.FindControl("checkSubdivision");



                int index = Convert.ToInt32(row.RowIndex);

               
                

                

                string str = string.Empty;
                string str1 = string.Empty;
                decimal totalArea = 0;
                foreach (GridViewRow rw in GridAmalgamation.Rows)
                {
                    CheckBox chkBx = (CheckBox)rw.FindControl("checkAmalgamation");
                    if (chkBx != null && chkBx.Checked)
                    {
                        
                       str = str + rw.Cells[1].Text.Trim();
                        str += ",";
                        totalArea += Convert.ToDecimal(rw.Cells[2].Text.Trim());

                    }
                }
                lblAmalgamatedPlots.Text = str.TrimEnd(',');
                lblTotalArea.Text = totalArea.ToString() + " " + "SqrMts";
                lblAmalgamatedArea.Text = totalArea.ToString() + " " + "SqrMts";



                    string PlotNumber = GridAmalgamation.DataKeys[index].Values[0].ToString();

                    objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
                    objServiceTimelinesBEL.PlotNo = str.TrimEnd(',');
                    DataSet ds = new DataSet();


                    ds = objServiceTimelinesBLL.GetPlotAdjacencyDetails(objServiceTimelinesBEL);

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }

                
            }
            catch (Exception)
            {

                throw;
            }
        }



        private double Max(double a, double b, double c)
        {
            double MaxValue = 0;
            if (a > b)
            {
                if (a > c)
                {
                    MaxValue = a;
                }
                else
                {
                    MaxValue = c;
                }
            }
            else
            {
                if (b > c)
                {
                    MaxValue = b;
                }
                else
                {
                    MaxValue = c;
                }
            }
            return MaxValue;
        }

        protected void btnIAccept_Click(object sender, EventArgs e)
        {
            Allotment.ActiveViewIndex = 2;
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnterRequiredArea.Text = "";
            txtp1.Text = "";
            txtp2.Text = "";
            txtp3.Text = "";
            if (multi.ActiveViewIndex == 0)
            {
                BindPlotsInModal();
                GridPlot.Visible = true;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = false;
            }
            if (multi.ActiveViewIndex == 1)
            {
                BindSubdivisionPlots();
                GridPlot.Visible = false;
                GridSubDivision.Visible = true;
                GridAmalgamation.Visible = false;
            }
            if (multi.ActiveViewIndex == 2)
            {
                BindPlotsForAmalgamation();
                GridPlot.Visible = false;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = true;
            }
        }


        private void GetDeposites()
        {
            double choicearea = 0.00;
            double choiceareap1 = 0.00;
            double choiceareap2 = 0.00;
            double choiceareap3 = 0.00;
            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;
            string companyName = string.Empty;
            string ApplicantName = string.Empty;
            string applicantAddress = string.Empty;
            string SWCControlID = String.Empty;
            string SWCUnitID = String.Empty;
            string SWCServiceID = String.Empty;
            string SWCStatus = String.Empty;
            string SWCPayMode = String.Empty;
            string ChoosedPlot = "";
            try
            {
                ucAllotmentDeposits ucAllotmentDeposits1 = LoadControl("~/ucAllotmentDeposits.ascx") as ucAllotmentDeposits;

                if(multi.ActiveViewIndex==0)
                {
                    if (txtp1.Text != string.Empty)
                    {
                        string[] tokens = txtp1.Text.Split('|');
                        choiceareap1 = double.Parse(tokens[1].ToString());
                        choiceP1 = tokens[0].ToString();
                    }
                    if (txtp2.Text != string.Empty)
                    {
                        string[] tokens = txtp2.Text.Split('|');
                        choiceareap2 = double.Parse(tokens[1].ToString());
                        choiceP2 = tokens[0].ToString();
                    }
                    if (txtp3.Text != string.Empty)
                    {
                        string[] tokens = txtp3.Text.Split('|');
                        choiceareap3 = double.Parse(tokens[1].ToString());
                        choiceP3 = tokens[0].ToString();
                    }

                    choicearea = Max(choiceareap1, choiceareap2, choiceareap3);
                }
                if (multi.ActiveViewIndex==1)
                {

                    choicearea = double.Parse(txtEnterRequiredArea.Text);
                }
                if (multi.ActiveViewIndex == 2)
                {

                    choicearea = double.Parse(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7));
                }
                choicearea = Max(choiceareap1, choiceareap2, choiceareap3);

                if (choicearea == choiceareap1)
                {
                    ChoosedPlot = choiceP1;
                }
                if (choicearea == choiceareap2)
                {
                    ChoosedPlot = choiceP2;
                }
                if (choicearea == choiceareap3)
                {
                    ChoosedPlot = choiceP3;
                }







                ucAllotmentDeposits1.IndustrialArea = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                ucAllotmentDeposits1.choicearea = choicearea;

                ucAllotmentDeposits1.PlotNo = ChoosedPlot;
                //ucAllotmentDeposits1.choiceareap1 = choiceareap1;
                //ucAllotmentDeposits1.choiceareap2 = choiceareap2;
                //ucAllotmentDeposits1.choiceareap3 = choiceareap3;
                //ucAllotmentDeposits1.choiceP1 = choiceP1;
                //ucAllotmentDeposits1.choiceP2 = choiceP2;
                //ucAllotmentDeposits1.choiceP3 = choiceP3;
                ucAllotmentDeposits1.companyName = lblCompanyName.Text;
                ucAllotmentDeposits1.ApplicantName = lblOccupierName.Text;
                ucAllotmentDeposits1.applicantAddress = lblOccupierAddress.Text;
                ucAllotmentDeposits1.SWCControlID = lblControlId.Text;
                ucAllotmentDeposits1.SWCUnitID = lblUnitId.Text;
                //ucAllotmentDeposits1.SWCServiceID = lblser;
                //ucAllotmentDeposits1.SWCStatus = choiceP1;
                //ucAllotmentDeposits1.SWCPayMode = choiceP2;

                PlaceHolder1.Controls.Add(ucAllotmentDeposits1);



            }
            catch (Exception ex)
            { }
        }


        protected void btngetdata_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();

                string Contact = "";
                string Email = "";


                if (multi.ActiveViewIndex == 0) { 
                if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                    return;
                }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Required plot Size');", true);
                        return;
                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                }


                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());


                ds = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Contact = ds1.Tables[0].Rows[0]["OfficePhoneNo"].ToString();
                        Email = ds1.Tables[0].Rows[0]["OfficeEMAILID"].ToString();
                    }

                }


                if (ds.Tables.Count > 0)
                {


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GetDeposites();

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                         Phone No : " + Contact + " EmailId : " + Email;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        btnproceed.Enabled = false;
                        return;
                    }

                }
                else
                {
                    string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                      Phone No : " + Contact + " EmailId : " + Email;
                    btnproceed.Enabled = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }


            }
            catch (Exception ex)
            {

                string msg = "Exception Occurred";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                return;

            }


        }

        protected void btnproceed_Click(object sender, EventArgs e)
        {
            if (RadioNivesh.Checked == true)
            {
                Response.Redirect("http://niveshmitra.up.nic.in/");
            }
            else if (RadioUpsidc.Checked == true)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);

            }
            else if (RadioExisting.Checked == true)
            {
                Allotment.ActiveViewIndex = 4;
            }
            else if (RadioURN.Checked == true)
            {
                Allotment.ActiveViewIndex = 6;
            }else if(RadioTrackApp.Checked==true)
            {
                Response.Redirect("~/ApplicationTracker.aspx");
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose One Option');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string str = string.Empty;

            double choicearea = 0.00;
            double choiceareap1 = 0.00;
            double choiceareap2 = 0.00;
            double choiceareap3 = 0.00;
            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;

            if (ControlID.Length > 0)
            {
                try
                {
                    string Contact="";
                    string Email="";
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    string PreferredPlotSize = "";
                    decimal subTotalApplicableFees, subTotalDeposits, TotalCharges;
               
                    if (multi.ActiveViewIndex == 0)
                    {
                        if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                            return;
                        }else
                        {
                            if (txtp1.Text != string.Empty)
                            {
                                string[] tokens = txtp1.Text.Split('|');
                                choiceareap1 = double.Parse(tokens[1].ToString());
                                choiceP1 = tokens[0].ToString();
                            }
                            if (txtp2.Text != string.Empty)
                            {
                                string[] tokens = txtp2.Text.Split('|');
                                choiceareap2 = double.Parse(tokens[1].ToString());
                                choiceP2 = tokens[0].ToString();
                            }
                            if (txtp3.Text != string.Empty)
                            {
                                string[] tokens = txtp3.Text.Split('|');
                                choiceareap3 = double.Parse(tokens[1].ToString());
                                choiceP3 = tokens[0].ToString();
                            }


                            PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();


                        }
                    }
                    if (multi.ActiveViewIndex == 1)
                    {
                        if (txtEnterRequiredArea.Text == "")
                        {

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                            return;
                        }
                        else
                        {
                            PreferredPlotSize = txtEnterRequiredArea.Text;
                        }

                    }
                    if (multi.ActiveViewIndex == 2)
                    {
                        if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                            return;
                        }else
                        {
                            PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                        }
                    }

                    objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                   

                    DataSet ds = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                    DataSet ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
                    if (ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            Contact = ds1.Tables[0].Rows[0]["OfficePhoneNo"].ToString();
                            Email   = ds1.Tables[0].Rows[0]["OfficeEMAILID"].ToString();
                        }

                    }


                    if (ds.Tables.Count > 0)
                    {


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            
                        }
                        else
                        {
                            string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                         Phone No : " + Contact + " EmailId : " + Email;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            btnproceed.Enabled = false;
                            return;
                        }

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                      Phone No : " + Contact + " EmailId : " + Email;
                        btnproceed.Enabled = false;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }


                    objServiceTimelinesBEL.industrialAreaID = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                    objServiceTimelinesBEL.choicearea = double.Parse(PreferredPlotSize.Trim());
                    DataSet dschoicearea = new DataSet();
                    DataTable Getdata1 = new DataTable();
                    DataTable Getdata2 = new DataTable();
                    dschoicearea = objServiceTimelinesBLL.GetapplicableChargesnDataforAllotment(objServiceTimelinesBEL);
                    if (dschoicearea.Tables.Count > 0)
                    {


                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }
                        if (dschoicearea.Tables[1].Rows.Count > 0) { Getdata2 = dschoicearea.Tables[1]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));
                        subTotalDeposits = Convert.ToDecimal(Getdata2.Compute("SUM(applicablecharge)", string.Empty));

                        TotalCharges = subTotalApplicableFees + subTotalDeposits;
                        hidAmt.Value = TotalCharges.ToString();

                        Status_Code = "12";
                        Fee_Amount = TotalCharges.ToString();
                        Fee_Status = "UB";

                        try
                        {
                            //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowSleepModal();", true);

                            if (ControlID.Length > 0)
                            {
                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                string Update_Result = webService.WReturn_CUSID_STATUS(
                                ControlID,
                                UnitID,
                                ServiceID,
                                ProcessIndustryID,
                                ApplicationID,
                                Status_Code,
                                Remarks,
                                Fee_Amount,
                                Fee_Status,
                                Transaction_ID,
                                Transaction_Date,
                                Transaction_Date_Time,
                                NOC_Certificate_Number,
                                NOC_URL,
                                ISNOC_URL_ActiveYesNO,
                                passsalt
                                );

                                HidStatus.Value = Update_Result;
                            }

                            if (HidStatus.Value == "SUCCESS")
                            {
                                //  ControlID = "testFail";
                                try
                                {

                                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService1 = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                    DataSet dss = webService1.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt);

                                    DataTable dtt = dss.Tables[0];
                                    if (dtt.Rows.Count > 0)
                                    {

                                        string status_code = dtt.Rows[0]["Status_Code"].ToString();
                                        string Fee_Status = dtt.Rows[0]["Fee_Status"].ToString();

                                        if (status_code == "12")
                                        {

                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                    HidStatus.Value = "FAILED";
                                    str = "exception occureded in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                                    return;

                                }






                            }
                            else if ((HidStatus.Value == "FAILED"))
                            {


                                HidStatus.Value = "FAILED";
                                str = "exception occureded in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                                return;



                            }

                        }

                        //Thread.Sleep(10000);


                        catch (Exception ex)
                        {

                            HidStatus.Value = "FAILED";
                            str = "exception occureded in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                            return;

                        }


                        //if No exception then check where payment requirement data is catured by Nivesh Mitra




                    }

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "AKS();", true);


                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                    return;

                }



            }
            else
            {
                SaveInHouseEntry();
            }

        }










        private void SaveInHouseEntry()
        {
            try
            {

                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                { 
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                }

                string Contact = "";
                string Email = "";

                string choicearea = "";
                double choiceareap1 = 0.00;
                double choiceareap2 = 0.00;
                double choiceareap3 = 0.00;
                string choiceP1 = string.Empty;
                string choiceP2 = string.Empty;
                string choiceP3 = string.Empty;

                string PreferredPlotSize = "";

                string PreferencePlot1 = "", PreferencePlot2 = "", PreferencePlot3 = "";

                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                        return;
                    }
                    else
                    {
                        if (txtp1.Text != string.Empty)
                        {
                            string[] tokens = txtp1.Text.Split('|');
                            choiceareap1 = double.Parse(tokens[1].ToString());
                            PreferencePlot1 = tokens[0].ToString();
                        }
                        if (txtp2.Text != string.Empty)
                        {
                            string[] tokens = txtp2.Text.Split('|');
                            choiceareap2 = double.Parse(tokens[1].ToString());
                            PreferencePlot2 = tokens[0].ToString();
                        }
                        if (txtp3.Text != string.Empty)
                        {
                            string[] tokens = txtp3.Text.Split('|');
                            choiceareap3 = double.Parse(tokens[1].ToString());
                            PreferencePlot3 = tokens[0].ToString();
                        }


                        PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();

                        if (choiceareap1.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot1;
                        }
                        if (choiceareap2.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot2;
                        }
                        if (choiceareap3.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot3;
                        }



                    }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text == "")
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                        return;
                    }
                    else
                    {
                        string[] tokens = txtSubPlot.Text.Split('|');
                        PreferredPlotSize = txtEnterRequiredArea.Text;
                        choicearea = tokens[0].ToString();

                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (lblAmalgamatedArea.Text.Length > 0)
                    {
                        if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                            return;
                        }
                        else
                        {
                            PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                            choicearea = lblAmalgamatedPlots.Text;
                        }
                    }else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                }


                    objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());


                    DataSet ds2 = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                    DataSet ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
                    if (ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            Contact = ds1.Tables[0].Rows[0]["OfficePhoneNo"].ToString();
                            Email = ds1.Tables[0].Rows[0]["OfficeEMAILID"].ToString();
                        }

                    }


                    if (ds2.Tables.Count > 0)
                    {


                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                         Phone No : " + Contact + " EmailId : " + Email;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            btnproceed.Enabled = false;
                            return;
                        }

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                      Phone No : " + Contact + " EmailId : " + Email;
                        btnproceed.Enabled = false;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }




                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.plotSize = PreferredPlotSize.Trim();
                    objServiceTimelinesBEL.PlotNo = choicearea.Trim();
                    objServiceTimelinesBEL.IndustrialArea = drpdwnIA.SelectedValue.Trim();
                    objServiceTimelinesBEL.CreatedBy = ipaddress;
                    objServiceTimelinesBEL.Preference1 = PreferencePlot1.Trim();
                    objServiceTimelinesBEL.Preference2 = PreferencePlot2.Trim();
                    objServiceTimelinesBEL.Preference3 = PreferencePlot3.Trim();
                objServiceTimelinesBEL.Parameter = "Instant";

                ds = objServiceTimelinesBLL.ApplicationLandAllotmentInHouse(objServiceTimelinesBEL);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblServiceRequestID.Text = ds.Tables[0].Rows[0]["ServiceRequestNO"].ToString();
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayNdRedirect('" + lblServiceRequestID.Text + "');", true);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }


        private void SaveNiveshMitraEntry()
        {
            try
            {
                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                {
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                }
                string choicearea ="";
                double choiceareap1 = 0.00;
                double choiceareap2 = 0.00;
                double choiceareap3 = 0.00;
                string choiceP1 = string.Empty;
                string choiceP2 = string.Empty;
                string choiceP3 = string.Empty;

                string PreferredPlotSize = "";

                string PreferencePlot1 = "", PreferencePlot2 = "", PreferencePlot3 = "";
                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                        return;
                    }
                    else
                    {
                        if (txtp1.Text != string.Empty)
                        {
                            string[] tokens = txtp1.Text.Split('|');
                            choiceareap1 = double.Parse(tokens[1].ToString());
                            PreferencePlot1 = tokens[0].ToString();
                        }
                        if (txtp2.Text != string.Empty)
                        {
                            string[] tokens = txtp2.Text.Split('|');
                            choiceareap2 = double.Parse(tokens[1].ToString());
                            PreferencePlot2 = tokens[0].ToString();
                        }
                        if (txtp3.Text != string.Empty)
                        {
                            string[] tokens = txtp3.Text.Split('|');
                            choiceareap3 = double.Parse(tokens[1].ToString());
                            PreferencePlot3 = tokens[0].ToString();
                        }


                        PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();

                        if (choiceareap1.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot1;
                        }
                        if (choiceareap2.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot2;
                        }
                        if (choiceareap3.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot3;
                        }



                    }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text == "")
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                        return;
                    }
                    else
                    {
                        string[] tokens = txtSubPlot.Text.Split('|');
                        PreferredPlotSize = txtEnterRequiredArea.Text;
                        choicearea = tokens[0].ToString();

                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                    else
                    {
                        PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                        choicearea = lblAmalgamatedPlots.Text;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.plotSize = PreferredPlotSize.Trim();
                objServiceTimelinesBEL.PlotNo = choicearea.Trim();
                objServiceTimelinesBEL.IndustrialArea = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.CreatedBy = ipaddress;
                objServiceTimelinesBEL.Preference1 = PreferencePlot1.Trim();
                objServiceTimelinesBEL.Preference2 = PreferencePlot2.Trim();
                objServiceTimelinesBEL.Preference3 = PreferencePlot3.Trim();
                objServiceTimelinesBEL.ControlId = ControlID.Trim();
                objServiceTimelinesBEL.UnitId = UnitID.Trim();
                objServiceTimelinesBEL.ServiceId = ServiceID.Trim();
                objServiceTimelinesBEL.Allotteename = lblOccupierName.Text.Trim();
                objServiceTimelinesBEL.Email = lblOccupierEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = lblOccupierPhone.Text.Trim();
                objServiceTimelinesBEL.applicantAddress = lblOccupierAddress.Text.Trim();
                objServiceTimelinesBEL.PanNo = lblOccupierPAN.Text.Trim();
                objServiceTimelinesBEL.companyName = lblCompanyName.Text.Trim();
                objServiceTimelinesBEL.NiveshMitraAmt = Convert.ToDecimal(hidAmt.Value);

                ds = objServiceTimelinesBLL.ApplicationLandAllotmentNiveshMitra(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblServiceRequestID.Text = ds.Tables[0].Rows[0]["ServiceRequestNO"].ToString();

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayNdRedirect('" + lblServiceRequestID.Text + "');", true);

                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }




        protected void hidbtn_Click(object sender, EventArgs e)
        {
            SaveNiveshMitraEntry();


        }

        protected void proceedAnchor_ServerClick(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();

                if (ControlID.Length > 0)
                {
                    objServiceTimelinesBEL.ControlId = ControlID.Trim();
                    objServiceTimelinesBEL.UnitId = UnitID.Trim();
                    objServiceTimelinesBEL.ServiceId = ServiceID.Trim();


                    ds = objServiceTimelinesBLL.CheckControlIdAlreadyExist(objServiceTimelinesBEL);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string ServiceReqNo = ds.Tables[0].Rows[0]["ApplicationId"].ToString();

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Redirect('" + ServiceReqNo.Trim() + "');", true);
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                        }

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnTrack_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = txtServiceReqNo.Text.Trim();
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    string TraID = dt.Rows[0]["ApplicationTraID"].ToString();
                    string Paid = dt.Rows[0]["Paid"].ToString();
                    string PayType = dt.Rows[0]["ResponseCode"].ToString();

                    string Clarification = dt.Rows[0]["IsClarificationReq"].ToString();
                    string status = "";

                    if(Clarification=="True")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectC('" + txtServiceReqNo.Text + "');", true);
                    }



                    if(Paid=="True")
                    {
                        status = "F";
                    }
                    else
                    {
                        status = "C";
                    }

                    


                    if (TraID==""||TraID==null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirect('" + txtServiceReqNo.Text + "');", true);
                    }
                    else
                    {

                        if (PayType == "E00329")
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + txtServiceReqNo.Text + "','" + TraID + "');", true);

                            }
                        }
                        else
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                        }
                    }


                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }



      


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            ClearTextBoxes();
            int index = Int32.Parse(e.Item.Value);          
            multi.ActiveViewIndex = index;  
            if(index==0)
            {
                BindPlotsInModal();
                GridPlot.Visible = true;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = false;
            }
            if (index == 1)
            {
                BindSubdivisionPlots();
                GridPlot.Visible = false;
                GridSubDivision.Visible = true;
                GridAmalgamation.Visible = false;
            }
            if (index == 2)
            {
                BindPlotsForAmalgamation();
                GridPlot.Visible = false;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = true;
            }


        }
        private void ClearTextBoxes()
        {
            txtp1.Text = "";
            txtp2.Text = "";
            txtp3.Text = "";
            txtSubPlot.Text = "";
            txtEnterRequiredArea.Text = "";
            lblAmalgamatedArea.Text = "";
            lblAmalgamatedPlots.Text = "";
            lblTotalArea.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }


        private void ExistingAllottee()
        {
            try
            {
                UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = new UC_Service_Allotteee_Detail();
                UC_Service_Building_Plan UC_Service_Building_Plan = new UC_Service_Building_Plan();


                SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where IndustrialArea='" + drdIA.SelectedItem.Text.Trim() + "' and PlotNo='" + txtPlotNo.Text + "' and Allotmentletterno='" + txtLetterNo.Text.Trim() + "'  ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    string Allotmentletterno = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                    ViewState["Allotmentletterno"] = Allotmentletterno.Trim();
                    Allotment.ActiveViewIndex = 3;
                    PlaceHolder2.Controls.Clear();
                    UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                    UC_Service_Building_Plan.ID = "Service_Building_Plan";

                    UC_Service_Building_Plan.SerReqID = ServiceReqNo;
                    UC_Service_Building_Plan.ControlID = ControlID;
                    UC_Service_Building_Plan.UnitID = UnitID;
                    UC_Service_Building_Plan.ServiceID = ServiceID;
                    UC_Service_Building_Plan.SerID_in = "1";
                    UC_Service_Building_Plan.UserBy = ViewState["Allotmentletterno"].ToString().Trim();
                    UC_Service_Building_Plan.page_type = "ENTRY";
                    UC_Service_Building_Plan.AllottementLetterNo = ViewState["Allotmentletterno"].ToString().Trim();
                    UC_Service_Building_Plan.Page_Load(null, null);
                    PlaceHolder2.Controls.Add(UC_Service_Building_Plan);

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('This Unit has not occupied land');", true);
                    return;



                }
            }

            catch (Exception ex) { }



        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            ExistingAllottee();
        }

        
        
    }
}