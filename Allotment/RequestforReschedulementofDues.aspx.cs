
//using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Collections.Specialized;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace Allotment
{
    public partial class RequestforReschedulementofDues : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        string UPSIDAFee;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;
        string TypeID;
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string checklistid { get; set; }
        GeneralMethod gm = new GeneralMethod();
        SqlConnection con;

        #endregion

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        //    int i = 1;
        //    foreach (string key in keys)
        //    {
        //        this.CreateTextBox("txtDynamic" + i);
        //        i++;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {


            //Session["litTotalSaleableArea"] = litTotalSaleableArea.Text;
            //Session["litTotalMortgagedArea"] = litTotalMortgagedArea.Text;
            //List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
            //int i = 1;
            //foreach (string key in keys)
            //{
            //    this.CreateTextBox("txtDynamic" + i);
            //    i++;
            //}
            try
            {
                //Session["litTotalSaleableArea"] = litTotalSaleableArea.Text;
                //Session["litTotalMortgagedArea"] = litTotalMortgagedArea.Text;
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                //ServiceReqNo = Request.QueryString["ServiceReqNo"];
                ServiceReqNo = "SER20230912/1000/1654/83069";
                Session["ServiceReqNo"] = ServiceReqNo;

                string[] SerIdarray = ServiceReqNo.Split('/');
                TypeID = SerIdarray[1].ToString();

                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();
                if (SWCControlID.Length > 0)
                {
                    CheckNMSWPFeePaid();
                }

                PH_AllotteeDetails.Controls.Clear();
                RegisterPostBackControl();
                UC_Service_Allotteee_Details_IA_ServicesRescheduelment UC_Service_Allotteee_Details_IA_ServicesRescheduelment = LoadControl("~/UC_Service_Allotteee_Details_IA_ServicesRescheduelment.ascx") as UC_Service_Allotteee_Details_IA_ServicesRescheduelment;
                UC_Service_Allotteee_Details_IA_ServicesRescheduelment.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Service_Allotteee_Details_IA_ServicesRescheduelment.AllotteeId = SerIdarray[2];
                PH_AllotteeDetails.Controls.Add(UC_Service_Allotteee_Details_IA_ServicesRescheduelment);
                if (Request.Form["__EVENTTARGET"] == "GetServiceChecklists_SP_BY_Condtion_Function")
                {
                    string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                    GetServiceChecklists_SP_BY_Condtion_Function(passedArgument);
                }

                firstCondition = (string)ViewState["firstCondition"];
                BY_Condtion_Function = (string)ViewState["BY_Condtion_Function"];

                if (string.IsNullOrEmpty(BY_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                else { BY_SET_Condtion_Function = BY_Condtion_Function; }

                if (checklistid == "" || checklistid == null)
                { view_asdf(ServiceReqNo); }
                else { view_asdf1(checklistid); }

                if (TypeID == "1030")
                {
                    if (Session["rtype"] != null)
                    {
                        lblrbtnFamilySelection.Text = Session["rtype"].ToString();
                    }
                    else {
                        lblrbtnFamilySelection.Text = Request.QueryString["rtype"].ToString();
                        Session["rtype"] = lblrbtnFamilySelection.Text;
                    }
                    //lblFormName.Text = "Request for Subdivision of Plots : post allotment";
                    // lblrbtnFamilySelection.Text = Request.QueryString["rtype"].ToString();
                    // bindSubdivided();
                }
                if (!IsPostBack)
                {
                    lblFormName.Text = "Request for Reschedulement of Dues";
                    if (TypeID == "1003")
                    {
                        lblFormName.Text = "Application For Change Of Project";
                    }
                    if (TypeID == "1004")
                    {
                        lblFormName.Text = "Application For Addition Of Product";
                    }
                    if (TypeID == "1009")
                    {
                        lblFormName.Text = "Application For Completion Certificate";
                    }
                    if (TypeID == "1010")
                    {
                        lblFormName.Text = "Application For Occupancy Certificate";
                    }
                    if (TypeID == "1023")
                    {
                        lblFormName.Text = "Application For No Dues Certificate";
                    }
                    if (TypeID == "1027")
                    {
                        lblFormName.Text = "Request for outstanding dues position";
                    }
                    if (TypeID == "1029")
                    {
                        lblFormName.Text = "Request for Amalgamation of Plots : post allotment";
                        btn_Submit.Text = "Pay Now";
                    }
                    if (TypeID == "1030")
                    {
                        lblFormName.Text = "Request for Subdivision of Plots : post allotment";
                        if (Session["rtype"] != null)
                        {
                            lblrbtnFamilySelection.Text = Session["rtype"].ToString();
                        }
                        else {
                            lblrbtnFamilySelection.Text = Request.QueryString["rtype"].ToString();
                            Session["rtype"] = lblrbtnFamilySelection.Text;
                        }
                        //lblrbtnFamilySelection.Text = Request.QueryString["rtype"].ToString();
                        if (lblrbtnFamilySelection.Text == "Family")
                        {
                            if (txtmem1.Text.Trim() == string.Empty)
                            {
                                ismenmberexist = true;
                            }
                            if (txtmem2.Text.Trim() == string.Empty)
                            {
                                ismenmberexist = true;
                            }
                            if (txtmem3.Text.Trim() == string.Empty)
                            {
                                ismenmberexist = true;
                            }
                            if (txtmem4.Text.Trim() == string.Empty)
                            {
                                ismenmberexist = true;
                            }
                        }
                        bindSubdivided();
                    }
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;
                    }
                    BindServiceCheckListGridViewDocument(hfName.Value);
                    if (TypeID == "1003")
                    {
                        bindPriorityDdl();
                        bindIACategory();
                        bindTypeOfIndustry();
                        GetChangeOfProjectDetails();
                        bindReschedulementDues();


                        GetGridData("");





                    }
                    if (TypeID == "1004")
                    {
                        GetAdditionalProduct();
                    }
                    if (TypeID == "1009")
                    {
                        BindHazardDdl();
                        GetServiceRequestBPDetail();
                    }
                    if (TypeID == "1029")
                    {
                        BindPlotForAmalgamation();
                        AmalgamatePlots();
                    }
                    if (TypeID == "1030")
                    {

                        //BindSubdividedPlots();
                    }
                    GetApplicationDetails();
                    GetPaymentDetails();
                }
                if (SWCControlID.Length > 0)
                {
                    if (TypeID == "1029")
                    {
                        GetApplicationDetails();
                        //GetPaymentDetails();
                        if (UPSIDAFee != "Paid")
                        {
                            btn_Submit.Visible = false;
                            btnPay.Visible = true;
                        }
                        else
                        {
                            btn_Submit.Text = "Print";
                            btn_Submit.Visible = true;
                            btnPay.Visible = false;
                        }
                    }
                    else
                    {
                        btn_Submit.Visible = true;
                        btnPay.Visible = false;
                    }
                }
                else
                {
                    btn_Submit.Visible = false;
                    btnPay.Visible = true;
                }
                // BindObjection();
                if (true)
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    // menuItems.Remove(menuItem);


                    MenuItemCollection menuItems1 = sub_menu.Items;
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems1)
                    {
                        if (item.Text == "Final Submission")
                            menuItem1 = item;
                    }
                    // menuItems1.Remove(menuItem1);

                    MenuItemCollection menuItems2 = sub_menu.Items;
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems2)
                    {
                        if (item.Text == "Accounts Details")
                            menuItem2 = item;
                    }
                    // menuItems2.Remove(menuItem2);
                }







                //if (TypeID == "1023" || TypeID == "1027")
                //{



                //    MenuItemCollection menuItems = sub_menu.Items;
                //    MenuItem menuItem = new MenuItem();
                //    foreach (MenuItem item in menuItems)
                //    {
                //        if (item.Text == "New Product Details")
                //            menuItem = item;
                //    }
                //    menuItems.Remove(menuItem);

                //    MenuItemCollection menuItems1 = sub_menu.Items;
                //    MenuItem menuItem1 = new MenuItem();
                //    foreach (MenuItem item in menuItems1)
                //    {
                //        if (item.Text == "Project Details")
                //            menuItem1 = item;
                //    }
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems2 = sub_menu.Items;
                //    MenuItem menuItem2 = new MenuItem();
                //    foreach (MenuItem item in menuItems2)
                //    {
                //        if (item.Text == "Building Specification")
                //            menuItem2 = item;
                //    }
                //    menuItems2.Remove(menuItem2);
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems3 = sub_menu.Items;
                //    MenuItem menuItem3 = new MenuItem();
                //    foreach (MenuItem item in menuItems3)
                //    {
                //        if (item.Text == "Sanction Plan Details")
                //            menuItem3 = item;
                //    }
                //    menuItems3.Remove(menuItem3);
                //    MenuItemCollection menuItems4 = sub_menu.Items;
                //    MenuItem menuItem4 = new MenuItem();
                //    foreach (MenuItem item in menuItems4)
                //    {
                //        if (item.Text == "Documents Upload")
                //            menuItem4 = item;
                //    }
                //    menuItems4.Remove(menuItem4);

                //    MenuItemCollection menuItems5 = sub_menu.Items;
                //    MenuItem menuItem5 = new MenuItem();
                //    foreach (MenuItem item in menuItems5)
                //    {
                //        if (item.Text == "Fee Details")
                //            menuItem5 = item;
                //    }
                //    menuItems5.Remove(menuItem5);

                //    MenuItemCollection menuItems6 = sub_menu.Items;
                //    MenuItem menuItem6 = new MenuItem();
                //    foreach (MenuItem item in menuItems6)
                //    {
                //        if (item.Text == "Amalgamation Details")
                //            menuItem6 = item;
                //    }
                //    menuItems6.Remove(menuItem6);



                //    MenuItemCollection menuItems7 = sub_menu.Items;
                //    MenuItem menuItem7 = new MenuItem();
                //    foreach (MenuItem item in menuItems7)
                //    {
                //        if (item.Text == "Subdivision Details")
                //            menuItem7 = item;
                //    }
                //    menuItems7.Remove(menuItem7);
                //}


                //if (TypeID == "1029")
                //{


                //    MenuItemCollection menuItems = sub_menu.Items;
                //    MenuItem menuItem = new MenuItem();
                //    foreach (MenuItem item in menuItems)
                //    {
                //        if (item.Text == "New Product Details")
                //            menuItem = item;
                //    }
                //    menuItems.Remove(menuItem);

                //    MenuItemCollection menuItems1 = sub_menu.Items;
                //    MenuItem menuItem1 = new MenuItem();
                //    foreach (MenuItem item in menuItems1)
                //    {
                //        if (item.Text == "Project Details")
                //            menuItem1 = item;
                //    }
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems2 = sub_menu.Items;
                //    MenuItem menuItem2 = new MenuItem();
                //    foreach (MenuItem item in menuItems2)
                //    {
                //        if (item.Text == "Building Specification")
                //            menuItem2 = item;
                //    }
                //    menuItems2.Remove(menuItem2);
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems3 = sub_menu.Items;
                //    MenuItem menuItem3 = new MenuItem();
                //    foreach (MenuItem item in menuItems3)
                //    {
                //        if (item.Text == "Sanction Plan Details")
                //            menuItem3 = item;
                //    }
                //    menuItems3.Remove(menuItem3);

                //    MenuItemCollection menuItems4 = sub_menu.Items;
                //    MenuItem menuItem4 = new MenuItem();
                //    foreach (MenuItem item in menuItems4)
                //    {
                //        if (item.Text == "Final Submission")
                //            menuItem4 = item;
                //    }
                //    menuItems4.Remove(menuItem4);

                //    MenuItemCollection menuItems5 = sub_menu.Items;
                //    MenuItem menuItem5 = new MenuItem();
                //    foreach (MenuItem item in menuItems5)
                //    {
                //        if (item.Text == "Accounts Details")
                //            menuItem5 = item;
                //    }
                //    menuItems5.Remove(menuItem5);

                //    MenuItemCollection menuItems6 = sub_menu.Items;
                //    MenuItem menuItem6 = new MenuItem();
                //    foreach (MenuItem item in menuItems6)
                //    {
                //        if (item.Text == "Subdivision Details")
                //            menuItem6 = item;
                //    }
                //    menuItems6.Remove(menuItem6);

                //}

                //if (TypeID == "1030")
                //{


                //    MenuItemCollection menuItems = sub_menu.Items;
                //    MenuItem menuItem = new MenuItem();
                //    foreach (MenuItem item in menuItems)
                //    {
                //        if (item.Text == "New Product Details")
                //            menuItem = item;
                //    }
                //    menuItems.Remove(menuItem);

                //    MenuItemCollection menuItems1 = sub_menu.Items;
                //    MenuItem menuItem1 = new MenuItem();
                //    foreach (MenuItem item in menuItems1)
                //    {
                //        if (item.Text == "Project Details")
                //            menuItem1 = item;
                //    }
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems2 = sub_menu.Items;
                //    MenuItem menuItem2 = new MenuItem();
                //    foreach (MenuItem item in menuItems2)
                //    {
                //        if (item.Text == "Building Specification")
                //            menuItem2 = item;
                //    }
                //    menuItems2.Remove(menuItem2);
                //    menuItems1.Remove(menuItem1);
                //    MenuItemCollection menuItems3 = sub_menu.Items;
                //    MenuItem menuItem3 = new MenuItem();
                //    foreach (MenuItem item in menuItems3)
                //    {
                //        if (item.Text == "Sanction Plan Details")
                //            menuItem3 = item;
                //    }
                //    menuItems3.Remove(menuItem3);

                //    MenuItemCollection menuItems4 = sub_menu.Items;
                //    MenuItem menuItem4 = new MenuItem();
                //    foreach (MenuItem item in menuItems4)
                //    {
                //        if (item.Text == "Final Submission")
                //            menuItem4 = item;
                //    }
                //    menuItems4.Remove(menuItem4);

                //    MenuItemCollection menuItems5 = sub_menu.Items;
                //    MenuItem menuItem5 = new MenuItem();
                //    foreach (MenuItem item in menuItems5)
                //    {
                //        if (item.Text == "Accounts Details")
                //            menuItem5 = item;
                //    }
                //    menuItems5.Remove(menuItem5);
                //    MenuItemCollection menuItems6 = sub_menu.Items;
                //    MenuItem menuItem6 = new MenuItem();
                //    foreach (MenuItem item in menuItems6)
                //    {

                //            if (item.Text == "Amalgamation Details")
                //                menuItem6 = item;
                //    }
                //    menuItems6.Remove(menuItem6);
                //}

                //if (Session["JMethod"] != null)
                //{
                //    if (Session["JMethod"].ToString() == "1")
                //    {
                //        bindSubdivided();
                //        Allotment.ActiveViewIndex = 13;
                //    }
                //}


            }
            catch (Exception ex)
            {
                //   Response.Write("Oops! error occured :" + ex.Message.ToString());

                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the column number
                int col = frame.GetFileColumnNumber();
                Response.Write(ex.StackTrace);
                // Response.Write("Oops! error occured : Line :" + line + "|Col :" + col + "|Method : " + methodName + "|File : " + fileName);

            }

        }

    
        string query = "";
        string PaymentHeadID = "";
        protected void GetGridData(string SerReqNo)
        {
            //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            //  SqlConnection con = new SqlConnection(constring);
            ////SqlConnection con = new SqlConnection();
            //SqlCommand cmd = new SqlCommand("[sp_GetAllotteeReschedulement_test2] " , con);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    AccountsDetailsGrid.DataSource = dt;
            //    AccountsDetailsGrid.DataBind();
            //}
            //else
            //{
            //    AccountsDetailsGrid.DataSource = null;
            //    AccountsDetailsGrid.DataBind();
            //}
            try
            {

                if (PaymentHeadID == "")
                {
                    // 
                    //query = " select(select top 2 PaymentHeadID, Debit, Credit, DueDate, PaymentDate FROM tbl_AllotteePaymentJournal where PaymentHeadID = '25' or PaymentHeadID = '26'";
                    // query = "select top 5 PaymentHeadID, Debit, Credit, DueDate, PaymentDate FROM tbl_AllotteePaymentJournal where PaymentHeadID='25' ";
                    query = "select top 2 PaymentHeadID, Debit , Credit  ,(Debit - Credit) 'OutStanding' , DueDate, PaymentDate   from tbl_AllotteePaymentJournal where PaymentHeadID = '25' ";

                }
                else
                {


                    query = "select top 2 PaymentHeadID, Debit , Credit  ,(Debit - Credit) 'OutStanding' , DueDate, PaymentDate   from tbl_AllotteePaymentJournal where PaymentHeadID = '26' ";

                }


                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(query, con);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    AccountsDetailsGrid.DataSource = dt;
                    AccountsDetailsGrid.DataBind();

                }
                else
                {
                    this.AccountsDetailsGrid.DataSource = null;
                    AccountsDetailsGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }

        protected void AccountsDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AccountsDetailsGrid.PageIndex = e.NewPageIndex;
            //    //grdViewNews.PageSize = 5;
            GetGridData("");

        }


        Classes.Class1 c1 = new Classes.Class1();
        DataTable dt = new DataTable();

        private void bindSubdivided()
        {
            try
            {
                c1.str = "select count(*) from SubdivisionChild  where ServiceReqNo='" + Request.QueryString["ServiceReqNo"].ToString() + "'";
                int counts = Convert.ToInt32(c1.ExecuteScaler(c1.str));
                if (counts > 0)
                {
                    c1.str = "select SubdividedArea from AlloteeSubDivisionDetails where SubDivisionRequestID='" + Request.QueryString["ServiceReqNo"].ToString() + "'";
                    string subArea = Convert.ToString(c1.ExecuteScaler(c1.str));
                    txtNoofPlots.Text = subArea;
                    c1.str = "select id,Plot_name, Plot_Area, Sal_mort from SubdivisionChild  where ServiceReqNo='" + Request.QueryString["ServiceReqNo"].ToString() + "'";
                    dt = c1.GetDataTable(c1.str);
                    if (dt.Rows.Count > 0)
                    {
                        decimal hdnSal = 0, hdnMort = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Sal_mort"].ToString() == "Saleable")
                            {
                                if (hdnSal == 0)
                                {
                                    hdnSal = Convert.ToDecimal(dt.Rows[i]["Plot_Area"].ToString());
                                }
                                else
                                {
                                    hdnSal = hdnSal + Convert.ToDecimal(dt.Rows[i]["Plot_Area"].ToString());
                                }
                                hdnTotalSaleableArea.Value = (hdnSal).ToString();
                                lblTotalSaleableArea.InnerText = (hdnSal).ToString();
                            }
                            else
                            {
                                hdnTotalSaleableArea.Value = "0";
                                lblTotalSaleableArea.InnerText = "0";
                            }
                            if (dt.Rows[i]["Sal_mort"].ToString() == "Mortgaged")
                            {
                                if (hdnMort == 0)
                                {
                                    hdnMort = Convert.ToDecimal(dt.Rows[i]["Plot_Area"].ToString());
                                }
                                else
                                {
                                    hdnMort = hdnMort + Convert.ToDecimal(dt.Rows[i]["Plot_Area"].ToString());
                                }
                                hdnTotalMortgagedArea.Value = (hdnMort).ToString();
                                lblTotalMortgagedArea.InnerText = (hdnMort).ToString();
                            }
                            else
                            {
                                hdnTotalMortgagedArea.Value = "0";
                                lblTotalMortgagedArea.InnerText = "0";
                            }


                        }
                        GridView5.DataSource = dt;
                        GridView5.DataBind();

                    }
                    else
                    {
                        GridView5.DataSource = null;
                        GridView5.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void bindTypeOfIndustry()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetTypeoFIndustry();
                ddlTypeOfIndustry.DataSource = ds;
                ddlTypeOfIndustry.DataTextField = "IndustrialClassificationName";
                ddlTypeOfIndustry.DataValueField = "ClassificationID";
                ddlTypeOfIndustry.DataBind();
                ddlTypeOfIndustry.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void BindPlotForAmalgamation()
        {

            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPlotsForAmalgamationPostAllotment(objServiceTimelinesBEL);
                ListPlotsForAmalgamation.DataSource = ds;
                ListPlotsForAmalgamation.DataTextField = "PlotNumber";
                ListPlotsForAmalgamation.DataValueField = "PlotMasterID";
                ListPlotsForAmalgamation.DataBind();
                ListPlotsForAmalgamation.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                //Response.Write("Oops! error occured :" + ex.Message.ToString());
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }
        }

        protected void ListPlotsForAmalgamation_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("Select * from [tbl_ApplicationRegisterAmalgamationSubdivisionPostAllotment] where ApplicationID='" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adp.Fill(data);
                string IAIDIn = data.Rows[0]["IndustrialArea"].ToString();
                string str = string.Empty;
                string str1 = string.Empty;
                decimal totalArea = 0;


                foreach (ListItem ListPlotsForAmalgamation in this.ListPlotsForAmalgamation.Items)
                {
                    if (ListPlotsForAmalgamation.Selected == true)
                    {
                        str = str + ListPlotsForAmalgamation.Text.Trim();
                        str += ",";
                    }
                }


                lblAmalgamatedPlots.Text = str.TrimEnd(',');
                lblTotalArea.Text = totalArea.ToString();
                lblAmalgamatedArea.Text = totalArea.ToString();




                objServiceTimelinesBEL.IAIdParam = IAIDIn.Trim();
                objServiceTimelinesBEL.PlotNo = str.TrimEnd(',');
                DataSet ds = new DataSet();


                ds = objServiceTimelinesBLL.GetPlotAdjacencyDetailsPostAmalgamation(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("PlotArea"));
                        lblTotalArea.Text = tot_Demanded.ToString();
                        lblAmalgamatedArea.Text = tot_Demanded.ToString();

                    }
                    else
                    {
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                    }
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }

        }
        //New Changes for Reschedulement
        private void bindReschedulementDues()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PaymentHead, Debit, Credit, DueDate, PaymentDate FROM tbl_AllotteePaymentJournal"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GrdReschedulement.DataSource = dt;
                            GrdReschedulement.DataBind();
                        }
                    }
                }
            }
        }

        private void AmalgamatePlots()
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_ApplicationRegisterAmalgamationSubdivisionPostAllotment] where ApplicationID='" + ServiceReqNo.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                string PlotNo = data.Rows[0]["PlotNo"].ToString();
                string PlotArea = data.Rows[0]["PlotSize"].ToString();

                string[] ArrPlots = PlotNo.Split(',');
                //if (PlotNo == "B-17,B-18")
                //{

                //    ListPlotsForAmalgamation.Items.FindByText(PlotNo).Selected = true;
                //}
                //else
                //{
                if (PlotNo == "")
                {
                    ListPlotsForAmalgamation.ClearSelection();
                }
                else
                {
                    for (int j = 0; j < ArrPlots.Length; j++)
                    {

                        ListPlotsForAmalgamation.Items.FindByText(ArrPlots[j].Trim()).Selected = true;
                    }
                }
                //}
                ListPlotsForAmalgamation_SelectedIndexChanged(null, null);
            }

        }

        protected void btnAmalgamationSave_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;
                int rows = 0;
                //if (lblAmalgamatedPlots.Text == "B-17,B-18")
                //{ }
                //else {
                foreach (ListItem ListPlotsForAmalgamation in this.ListPlotsForAmalgamation.Items)
                {
                    if (ListPlotsForAmalgamation.Selected == true)
                    {
                        rows = rows + 1;

                    }
                }

                if (rows <= 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Kindly choose plots to amalgamate');", true);
                    return;
                }
                //}
                objServiceTimelinesBEL.PlotNo = lblAmalgamatedPlots.Text;
                objServiceTimelinesBEL.AmalgamatedArea = Convert.ToDecimal(lblAmalgamatedArea.Text);
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                retval = objServiceTimelinesBLL.InsertAmalgamationDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {

                    //string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Additional Product Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                    string message = "Amalagation Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 2;

                }

            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }
        bool ismenmberexist = false;
        bool iscorrectsubdivedsize = true;
        double TotalPlotSize1 = 0;
        string allottedarea = string.Empty;
        bool isbtnselected = false;
        string plotnoo, RegionalOffice, IndustrialArea, PlotNo, AlloteeName, AuthorizedUser, AlloteeArea, FirmName, FirmConstitution, CINNo, PANNO, EmailId, PhoneNo, AllotmentNo, AllotmentDate, ApplicationLetter, LeaseDeedDate, LeaseDeedExecutionDate, ServiceRequestID, DateOfAllotment, SubDivisionRequestID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Subdivide_Click(object sender, EventArgs e)
        {
            if (txtNoofPlots.Text == "")
            {
                btnSubmit.Visible = false;
                string message = "Please Enter The Area To Subdivided";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
            }
            else
            {
                c1.str = " select count(*) from SubdivisionChild  where ServiceReqNo='" + Session["ServiceReqNo"].ToString() + "'";
                int counts = Convert.ToInt32(c1.ExecuteScaler(c1.str));
                if (counts > 0)
                {

                    try
                    {


                        string v1 = hdnTotalSaleableArea.Value;
                        string v2 = hdnTotalMortgagedArea.Value;

                        decimal salAreaVal = Convert.ToDecimal(v1);
                        decimal mortareaVal = Convert.ToDecimal(v2);

                        decimal subdividVal = Convert.ToDecimal(txtNoofPlots.Text);



                        if (subdividVal >= salAreaVal)
                        {
                            if (subdividVal >= mortareaVal)
                            {
                                if (subdividVal >= (salAreaVal + mortareaVal))
                                {

                                    GetApplicationDetails();

                                    allottedarea = Regex.Match(allottedarea, @"\d+").Value;
                                    // allottedarea = Request.Cookies["TotalAllottedplotArea"].Value;
                                    TotalPlotSize1 = Convert.ToDouble(allottedarea);
                                    //if (rbtnFamilySelection.SelectedIndex != -1)
                                    //{


                                    //if (rbtnFamilySelection.SelectedIndex == 0)
                                    if (lblrbtnFamilySelection.Text == "Family")
                                    {
                                        //if (txtmem1.Text.Trim() != string.Empty)
                                        //{
                                        //    ismenmberexist = true;
                                        //}
                                        //if (txtmem2.Text.Trim() != string.Empty)
                                        //{
                                        //    ismenmberexist = true;
                                        //}
                                        //if (txtmem3.Text.Trim() != string.Empty)
                                        //{
                                        //    ismenmberexist = true;
                                        //}
                                        //if (txtmem4.Text.Trim() != string.Empty)
                                        //{
                                        //    ismenmberexist = true;
                                        //}
                                        // getallotteeDetails();
                                        if (txtNoofPlots.Text.Trim() != string.Empty)
                                        {
                                            if (Convert.ToDouble(txtNoofPlots.Text) > TotalPlotSize1)
                                            {
                                                iscorrectsubdivedsize = false;
                                                string message = "Subdivided Plot Size Should Not Be Larger Then Total Area";
                                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                                txtNoofPlots.Focus();
                                                return;
                                            }

                                            if (Convert.ToDouble(txtNoofPlots.Text) <= TotalPlotSize1)
                                            {
                                                iscorrectsubdivedsize = true;
                                                //string message = "Subdivided Area Should be Less then Or Equal to 50% Of Total Area";
                                                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                            }
                                        }

                                    }

                                    //else if (rbtnFamilySelection.SelectedIndex == 0)
                                    else
                                    {
                                        // getallotteeDetails();
                                        if (txtNoofPlots.Text.Trim() != string.Empty)
                                        {
                                            if (Convert.ToDouble(txtNoofPlots.Text) > TotalPlotSize1 / 2)
                                            {
                                                iscorrectsubdivedsize = false;
                                                string message = "Subdivided Plot Size Should be Larger then to 50% Of Total Area";
                                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                                txtNoofPlots.Focus();
                                                return;
                                            }
                                            else
                                             if (Convert.ToDouble(txtNoofPlots.Text) <= TotalPlotSize1 / 2)
                                            {
                                                iscorrectsubdivedsize = true;
                                                //string message = "Subdivided Area Should be Less then Or Equal to 50% Of Total Area";
                                                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);



                                            }
                                        }
                                    }
                                    if (lblrbtnFamilySelection.Text == "Family")
                                    {
                                        familymemarea.Visible = true;
                                        isbtnselected = true;

                                    }
                                    //else if (lblrbtnFamilySelection.Text == "1")
                                    else
                                    {
                                        familymemarea.Visible = false;
                                        isbtnselected = true;
                                    }

                                    if ((iscorrectsubdivedsize == true && ismenmberexist == false) || (iscorrectsubdivedsize == true && ismenmberexist == true))
                                    {
                                        //string message = "All Right";
                                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AlloteeSubDivisionDetails]([RegionalOffice],[IndustrialArea],[PlotNo],[AlloteeName],[AuthorizedUser],[AlloteeArea],[FirmName],[FirmConstitution],[EmailId],[PhoneNo],[AllotmentNo],[AllotmentDate],[CreatedDate],[SubdividedArea],[FamilyMember1],[FamilyMember2],[FamilyMember3],[FamilyMember4],[SubDivisionRequestID],[ServiceRequestID],[status])VALUES('" + lblRegionalOffice.Text + "','" + lblIndustrialArea.Text + "' ,'" + PlotNo + "','" + lblAllotteeName.Text + "','" + lblAllotteeName.Text + "','" + allottedarea + "','" + lblFirmCompanyName.Text + "','" + lblAddress.Text + "','" + lblSIgnatoryEmail.Text + "','" + lblSignatoryMobile.Text + "','" + lblAllotmentLetterNo.Text + "','" + DateOfAllotment + "','" + DateTime.Now.ToShortDateString() + "','" + txtNoofPlots.Text + "','" + txtmem1.Text + "','" + txtmem2.Text + "','" + txtmem3.Text + "','" + txtmem4.Text + "','" + SubDivisionRequestID + "','" + ServiceRequestID + "',1)", con);

                                        con.Open();
                                        int i = cmd.ExecuteNonQuery();
                                        if (i != 0)
                                        {

                                            string message = "Your Details Have Been Saved SuccessFully";
                                            bindSubdivided();
                                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                            Allotment.ActiveViewIndex = 2;
                                        }
                                        con.Close();
                                    }

                                    //}
                                    //else
                                    //{
                                    //SqlCommand cmd = new SqlCommand("GetAllotteeDetailsIAService '" + ServiceReqNo + "'", con);
                                    //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                    //DataSet ds = new DataSet();
                                    //adp.Fill(ds);
                                    //if (ds.Tables.Count > 0)
                                    //{
                                    //    lblPlotSize.Text = "";
                                    //    DataTable dtt = ds.Tables[0];
                                    //    //(ViewState["dt"] as DataTable).Rows.Clear();
                                    //    string SubPlotNo = dtt.Rows[0]["PlotNo"].ToString();
                                    //    decimal SubPlotSize = Convert.ToDecimal(dtt.Rows[0]["TotalAllottedPlotArea"].ToString());
                                    //    lblPlotSize.Text = dtt.Rows[0]["TotalAllottedPlotArea"].ToString();
                                    //    int value = Convert.ToInt32(txtNoofPlots.Text.Trim());
                                    //    for (int i = 1; i <= value; i++)
                                    //    {
                                    //        DataTable dt = ViewState["dt"] as DataTable;
                                    //        dt.Rows.Add(i.ToString(), SubPlotNo.Trim() + '/' + i.ToString(), (SubPlotSize / value).ToString("0.00").Trim());
                                    //        ViewState["dt"] = dt;
                                    //    }
                                    //    BindGrid();
                                    //    btnSubmit.Visible = true;
                                    // }
                                    //}
                                }
                                else
                                {
                                    string message = "Total of Saleable and Mortgaged Area can not be more than area to be subdivided";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                }
                            }
                            else
                            {
                                string message = "Total of Mortgaged can not be more than area to be subdivided";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            }
                        }
                        else
                        {
                            string message = "Total of Saleable can not be more than area to be subdivided";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("" + ex);
                    }
                }
                else
                {
                    string message = "First save subdivided plot";
                    c1.AlertBox(message, this);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "func", " tableRowCreate();", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "func", "tableRowCreate();");
                    //Page.ClientScript.RegisterStartupScript()              





                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {




            try
            {
                int retval = 0, retVal2 = 0;
                decimal tot_Area = (ViewState["dt"] as DataTable).AsEnumerable().Sum(row => row.Field<decimal>("PlotSize"));
                if (tot_Area == Convert.ToDecimal(lblPlotSize.Text))
                {
                    DataTable Dt = (DataTable)ViewState["dt"];
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    retVal2 = objServiceTimelinesBLL.ClearPreviousSubdividedPlotDetails(objServiceTimelinesBEL);
                    if (Dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in Dt.Rows)
                        {
                            string PlotNo = dr1["PlotNo"].ToString();
                            string PlotSize = dr1["PlotSize"].ToString();



                            objServiceTimelinesBEL.PlotNo = PlotNo.Trim();
                            objServiceTimelinesBEL.plotSize = PlotSize;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                            retval += objServiceTimelinesBLL.SaveSubdividedPlots(objServiceTimelinesBEL);

                        }

                        if (retval > 0)
                        {
                            string message = "Subdivided Plot Details Saved Successfully";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            Allotment.ActiveViewIndex = 2;
                        }

                    }
                }
                else
                {
                    string message = "Total area of subdivided plots must be equal to the existing plot area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
                Allotment.ActiveViewIndex = 2;
            }

        }
        protected void BindGrid()
        {
            GridView4.DataSource = ViewState["dt"] as DataTable;
            GridView4.DataBind();
            if ((ViewState["dt"] as DataTable).Rows.Count > 0)
            {
                decimal tot_Area = (ViewState["dt"] as DataTable).AsEnumerable().Sum(row => row.Field<decimal>("PlotSize"));
                GridView4.FooterRow.Cells[0].Text = "Total";
                GridView4.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                GridView4.FooterRow.Cells[2].Text = tot_Area.ToString("N2");

            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            this.BindGrid();
            //bindSubdivided();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {

            decimal SubPlotSize;
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsIAService '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables.Count > 0)
            {

                SubPlotSize = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAllottedPlotArea"].ToString());
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                string PlotSize = (row.Cells[2].Controls[0] as TextBox).Text;
                if (PlotSize.Length > 0)
                {

                    if (Convert.ToDecimal(PlotSize) > 1000)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Subdivided Plot Area Cannot be Greater than 1000 sqr mtr');", true);
                        return;
                    }
                    if (Convert.ToDecimal(PlotSize) <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Subdivided Plot Area Cannot be less than or equal to 0 sqr mtr');", true);
                        return;
                    }

                    DataTable dt = ViewState["dt"] as DataTable;


                    dt.Rows[row.RowIndex]["PlotSize"] = PlotSize;
                    decimal total1 = Convert.ToDecimal(dt.Compute("Sum(PlotSize)", string.Empty).ToString());
                    if (total1 > SubPlotSize)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Total Subdivided Plot area cannot be greater or less than the parent plot area');", true);
                        return;
                    }
                    ViewState["dt"] = dt;
                    GridView4.EditIndex = -1;
                    this.BindGrid();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details');", true);
                    return;
                }
            }
        }
        protected void OnCancel(object sender, EventArgs e)
        {
            GridView4.EditIndex = -1;
            this.BindGrid();
        }


        //----------------------------------------Gridview5---------------------------------------------

        //protected void GridView5_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        //{
        //    //NewEditIndex property used to determine the index of the row being edited.
        //    GridView1.EditIndex = e.NewEditIndex;
        //    bindSubdivided();
        //}
        protected void GridView5_RowEditing1(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            GridView5.EditIndex = e.NewEditIndex;
            bindSubdivided();
        }

        protected void GridView5_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //int userid = Convert.ToInt32(GridView5.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView5.Rows[e.RowIndex];
            //Finding the controls from Gridview for the row which is going to update
            //Label lblid = GridView1.Rows[e.RowIndex].FindControl("lblId") as Label;
            //TextBox txtPlot = GridView1.Rows[e.RowIndex].FindControl("txtPlot") as TextBox;
            //TextBox txtArea = GridView1.Rows[e.RowIndex].FindControl("txtArea") as TextBox;
            Label lblid = (Label)row.FindControl("lblID");
            TextBox txtPlot = (TextBox)row.FindControl("txtPlot");
            TextBox txtArea = (TextBox)row.FindControl("txtArea");
            DropDownList ddlsal = (DropDownList)row.FindControl("ddlSalMord");
            //con = new SqlConnection(cs);
            //con.Open();
            //updating the record
            //c1.str="update ";Plot_Area, Sal_mort
            c1.str = "Update SubdivisionChild set Plot_name='" + txtPlot.Text + "',Plot_Area='" + txtArea.Text + "',Sal_mort='" + ddlsal.SelectedItem.Text + "' where ID='" + lblid.Text + "'";
            c1.ExecuteSql(c1.str);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record update successfully');", true);

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView5.EditIndex = -1;
            //Call ShowData method for displaying updated data
            bindSubdivided();
        }
        protected void GridView5_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView5.EditIndex = -1;
            bindSubdivided();
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridViewRow row = (GridViewRow)GridView5.Rows[e.RowIndex];
            Label lblid = (Label)row.FindControl("lblID");
            c1.str = "delete from SubdivisionChild  where ID='" + lblid.Text + "'";
            c1.ExecuteSql(c1.str);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record delete successfully');", true);
            GridView5.EditIndex = -1;
            bindSubdivided();
        }
        private void BindSubdividedPlots()
        {


        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            //   BindServiceCheckListGridViewDocument(hfName.Value);
            if (index == 0)
            {

            }
            if (index == 2)
            {
                BindServiceCheckListGridViewDocument("SubDivision");
            }

            if (index == 3 || index == 4 || index == 10)
            {
                GetPaymentDetails();

            }

            if (index == 6)
            {
                BindObjection();

            }


            Allotment.ActiveViewIndex = index;

            if (index == 8)
            {

                GetDetails();

            }
        }

        private void GetDetails()
        {

            try
            {
                string DocType = "";
                GeneralMethod gm = new GeneralMethod();
                string Status = gm.Get_Approval_Rejection_Status(ServiceReqNo);

                if (Status == "Completed")
                {
                    if (TypeID == "1003")
                    {
                        DocType = "ChangeOfProject";
                    }
                    if (TypeID == "1004")
                    {
                        DocType = "AdditionOfProduct";
                    }
                    if (TypeID == "1009")
                    {
                        DocType = "CompletionCertificate";
                    }
                    if (TypeID == "1010")
                    {
                        DocType = "OccupancyCertificate";
                    }
                    if (TypeID == "1023")
                    {
                        DocType = "NoDues";
                    }
                    if (TypeID == "1027")
                    {
                        DocType = "OutstandingDues";
                    }
                    if (TypeID == "4")
                    {
                        DocType = "Transfer";
                    }
                }
                else
                {
                    DocType = "Rejection";
                }

                SqlCommand cmd = new SqlCommand("GetSignedLetters '" + DocType + "','" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    this.RegisterPostBackControl();
                }
                else
                {

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DocumentViewer(string ServiceRequestNo, string DocType, string type)
        {


            SqlCommand cmd = new SqlCommand();
            if (type == "Letter")
            {
                cmd = new SqlCommand(@"select Id , SignedDocumentContent , SignedDocument from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);

            }
            if (type == "Map")
            {
                cmd = new SqlCommand(@"select Id ,SignedMapContent 'SignedDocumentContent' , SignedMap 'SignedDocument' from 
                                              [dbo].[Repository] where ServiceRequestNo = '" + ServiceRequestNo + "' and DocType='" + DocType + "'", con);

            }

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SignedDocument"].ToString().Length > 0)
                    {

                        byte[] Document = (byte[])dt.Rows[0]["SignedDocument"];
                        String base64EncodedPdf = System.Convert.ToBase64String(Document);
                        string embed = @"<object name='Viewer' data=""data:application/pdf;base64,{0}"" type=""application/pdf"" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";


                        ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerIAService.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "&DocType=" + DocType + "&ServiceID=" + TypeID + "")));

                    }
                }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % GridView1.PageSize;
                string DocType = "";
                GeneralMethod gm = new GeneralMethod();
                string Status = gm.Get_Approval_Rejection_Status(ServiceReqNo);

                if (Status == "Completed")
                {
                    if (TypeID == "1003")
                    {
                        DocType = "ChangeOfProject";
                    }
                    if (TypeID == "1004")
                    {
                        DocType = "AdditionOfProduct";
                    }
                    if (TypeID == "1009")
                    {
                        DocType = "CompletionCertificate";
                    }
                    if (TypeID == "1010")
                    {
                        DocType = "OccupancyCertificate";
                    }
                    if (TypeID == "1023")
                    {
                        DocType = "NoDues";
                    }
                    if (TypeID == "1027")
                    {
                        DocType = "OustandingDues";
                    }
                }
                else
                {
                    DocType = "Rejection";
                }
                string SerReqNo = GridView1.DataKeys[index].Values[0].ToString();
                string Service = GridView1.DataKeys[index].Values[1].ToString();

                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        if (Service == "Letter")
                        {
                            cmd = new SqlCommand("select AllotmentLetterNo,SignedDocument 'Letter', SignedDocumentContent 'ContentType',DocType from Repository where ServiceRequestNo='" + ServiceReqNo + "' and DocType='" + DocType + "' ", con);
                        }
                        if (Service == "Map")
                        {
                            cmd = new SqlCommand("select AllotmentLetterNo,SignedMap 'Letter',SignedMapContent 'ContentType',DocType from Repository where ServiceRequestNo='" + ServiceReqNo + "'and DocType='" + DocType + "' ", con);
                        }

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download1(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {
                    DocumentViewer(ServiceReqNo, DocType, Service);

                }





            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

        public void GetServiceRequestBPDetail()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.ServiceRequest = ServiceReqNo;
            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetServiceRequestBPDetail(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {



                    txtFar.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = ds.Tables[0].Rows[0]["GroundCoverage"].ToString().Trim();
                    txtSetBackFront.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();
                    txtHeight.Text = ds.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtOccupancy.Text = ds.Tables[0].Rows[0]["Occupancy"].ToString().Trim();


                    ///////////////  Updated by Mr. Manish
                    txtBaseMent1.Text = ds.Tables[0].Rows[0]["ExistingBasement"].ToString().Trim();
                    txtBaseMent2.Text = ds.Tables[0].Rows[0]["ProposedBasement"].ToString().Trim();
                    txtGround1.Text = ds.Tables[0].Rows[0]["ExistingGroundFloor"].ToString().Trim();
                    txtGround2.Text = ds.Tables[0].Rows[0]["ProposedGroundFloor"].ToString().Trim();
                    txtFirstfloor1.Text = ds.Tables[0].Rows[0]["ExistingFirstFloor"].ToString().Trim();
                    txtFirstfloor2.Text = ds.Tables[0].Rows[0]["ProposedFirstFloor"].ToString().Trim();
                    txtSecondFloor1.Text = ds.Tables[0].Rows[0]["ExistingSecondFloor"].ToString().Trim();
                    txtSecondFloor2.Text = ds.Tables[0].Rows[0]["ProposedSecondFloor"].ToString().Trim();
                    txtMezzanine1.Text = ds.Tables[0].Rows[0]["ExistingMezzanineFloor"].ToString().Trim();
                    txtMezzanine2.Text = ds.Tables[0].Rows[0]["ProposedMezzanineFloor"].ToString().Trim();
                    txtFoundation.Text = ds.Tables[0].Rows[0]["Foundation"].ToString().Trim();
                    txtWalls.Text = ds.Tables[0].Rows[0]["Walls"].ToString().Trim();
                    txtFloors.Text = ds.Tables[0].Rows[0]["Floors"].ToString().Trim();
                    txtRoofs.Text = ds.Tables[0].Rows[0]["Roofs"].ToString().Trim();
                    txtStories.Text = ds.Tables[0].Rows[0]["NoofStories"].ToString().Trim();
                    txtLatrines.Text = ds.Tables[0].Rows[0]["NoofLatrines"].ToString().Trim();
                    txtCoveredAreaA.Text = ds.Tables[0].Rows[0]["CoveredArea"].ToString().Trim();

                    txtStealth.Text = ds.Tables[0].Rows[0]["StiltFloor"].ToString().Trim();
                    txtMumti.Text = ds.Tables[0].Rows[0]["Mumti"].ToString().Trim();


                    txtbuildingPurpose.Text = ds.Tables[0].Rows[0]["PurposeofBuildingUse"].ToString().Trim();
                    txtPreviousConstruction.Text = ds.Tables[0].Rows[0]["PreviousConstruction"].ToString().Trim();
                    txtWaterSource.Text = ds.Tables[0].Rows[0]["SourceofWater"].ToString().Trim();

                    try
                    {
                        ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                    }
                    catch
                    { }

                }
                if (ds.Tables[1].Rows.Count > 0)
                {

                    lblFarByelaws.Text = ds.Tables[1].Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = ds.Tables[1].Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = ds.Tables[1].Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = ds.Tables[1].Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = ds.Tables[1].Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = ds.Tables[1].Rows[0]["side2"].ToString().Trim();

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
        protected void BindHazardDdl()
        {

            SqlCommand cmd = new SqlCommand("spGetBuildingTypeDetail", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            ddlNature.DataSource = dt;
            ddlNature.DataTextField = "Classification";
            ddlNature.DataValueField = "ID";


            ddlNature.DataBind();
            ddlNature.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void chkpriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpriority.Checked == true)
            {
                prioritydiv.Visible = true;
                bindPriorityDdl();
            }
            else
            {
                txtapplicantpriorityspecification.Text = "";
                prioritydiv.Visible = false;
            }


        }

        private void bindPriorityDdl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPriorityCategory();
                ddlPriority.DataSource = ds;
                ddlPriority.DataTextField = "Category";
                ddlPriority.DataValueField = "Category";
                ddlPriority.DataBind();
                ddlPriority.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void bindIACategory()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIACategory();
                drpIACategory.DataSource = ds;
                drpIACategory.DataTextField = "PollutionCategory";
                drpIACategory.DataValueField = "ID";
                drpIACategory.DataBind();
                drpIACategory.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        protected void chkfumes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfumes.Checked == true)
            {
                fumesdiv.Visible = true;
            }
            else
            {
                txtfumeqty.Text = "";
                txtfumenature.Text = "";
                fumesdiv.Visible = false;
            }


        }

        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                LinkButton imgdocuments = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(imgdocuments);

                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

                LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("lbView13") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);
            }
        }

        public void BindServiceCheckListGridViewDocument(string condition)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                string[] SerIdarray = ServiceReqNo.Split('/');
                objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1];
                objServiceTimelinesBEL.ServiceChecklistCondition = condition;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                if (App == "Resubmit")
                {
                    objServiceTimelinesBEL.Status = 0;
                }
                else
                {
                    objServiceTimelinesBEL.Status = 1;
                }

                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllServiceChecklistsIAServices(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                    this.RegisterPostBackControl();
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                    string[] SerIdarray = ServiceReqNo.Split('/');
                    string AllottementLetterNo = SerIdarray[2];
                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;

                        e.Row.FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                        e.Row.FindControl("lbDelete").Visible = false;
                    }

                    LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

                    if (DocDisable.Text == "Lock")
                    {

                        e.Row.FindControl("lbDelete").Visible = false;
                        lnk2.Visible = false;

                    }

                }
            }
            catch
            {

            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.RegisterPostBackControl();
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string AllottementLetterNo = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                string[] SerIdarray = ServiceReqNo.Split('/');

                AllottementLetterNo = SerIdarray[2];
                objServiceTimelinesBEL.UserName = AllottementLetterNo;
                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();
                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        int fileSize = fu.PostedFile.ContentLength;
                        if (fileSize > (3 * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                            return;
                        }
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".gif":
                                contenttype = "image/gif";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {

                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);

                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();

                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            objServiceTimelinesBEL.UserName = AllottementLetterNo;
                            try
                            {
                                int retVal;

                                retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Documents Uploaded and Application has been saved as draft|Applicant", SWCRequest_ID, "Applicant", "");
                                    string message = "PDF File Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                    BindServiceCheckListGridViewDocument(hfName.Value);

                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }

                            }
                            catch (Exception ex)
                            {
                                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                            }
                            finally
                            {
                                objServiceTimelinesBEL = null;
                                objServiceTimelinesBLL = null;
                            }

                        }
                        else
                        {
                            string message = "Invalid File Format.Please Upload Only pdf/Jpeg/Jpg/Png files Only";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        string message = "Please Select file Then Upload";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }



                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;


                        objServiceTimelinesBEL.DocumentID = DocumentID;



                        ds = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
                        DataTable dtDoc1 = ds.Tables[0];

                        if (dtDoc1.Rows.Count > 0)
                        {
                            download(dtDoc1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {
                    Response.Write("<script>window.open ('DocViewer.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&ServiceId=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocumentID=" + DocumentID + "','_blank');</script>");
                }

                if (e.CommandName == "Delete")
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.DocumentID = DocumentID;

                    try
                    {
                        int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            string message = "Checklist Document deleted successfully ";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                        else
                        {
                            string message = "Checklist Document couldn't be deleted";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }

        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
        }
        private void download1(DataTable dt)
        {
            try
            {
                if (dt.Rows[0]["Letter"].ToString().Length > 0)
                {
                    Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = dt.Rows[0]["contentType"].ToString();
                    Response.AddHeader("content-disposition", "attachment;filename="
                    + dt.Rows[0]["DocType"].ToString() + ".pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void download(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["contentType"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ColName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }
        private void View(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "inline;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;

                int fume_status = 0; int priority_status = 0;

                if (ddlTypeOfIndustry.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry');", true);
                    return;
                }
                if (drpIACategory.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select type of industry category');", true);
                    return;
                }

                if (Drop1.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Select wether company is 100% export oriented');", true);
                    return;
                }


                if (chkfumes.Checked == true)
                {
                    fume_status = 1;
                }
                else
                {
                    fume_status = 0;
                }
                if (chkpriority.Checked == true)
                {
                    if (ddlPriority.SelectedItem.Text.Trim() == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select priority category');", true);
                        return;
                    }
                    else
                    {
                        priority_status = 1;
                    }
                }
                else
                {
                    priority_status = 0;
                }
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.IndustryType = txttypeofindustry.Text.Trim();
                objServiceTimelinesBEL.EstimatedCostOfProject = Convert.ToDecimal(txtestimatedcost.Text.Trim());
                objServiceTimelinesBEL.EstimatedEmploymentGeneration = txtestimatedemployment.Text.Trim();
                objServiceTimelinesBEL.CoveredArea = txtcoveredarea.Text.Trim();
                objServiceTimelinesBEL.OpenAreaRequired = txtopenarearequired.Text.Trim();
                objServiceTimelinesBEL.LandDetails = txtland.Text.Trim();
                objServiceTimelinesBEL.BuildingDetails = txtbuilding.Text.Trim();
                objServiceTimelinesBEL.MachineryEquipmentsDetails = txtmachinery.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidqty = txteffluentsolidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentSolidComposition = txteffluentsolidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidqty = txteffluentliquidqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentLiquidComposition = txteffluentliquidcomposition.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousqty = txteffluentgaseousqty.Text.Trim();
                objServiceTimelinesBEL.IndustrialEffluentGaseousComposition = txteffluentgaseouscomposition.Text.Trim();
                objServiceTimelinesBEL.FumeGenerationStatus = fume_status.ToString().Trim();
                objServiceTimelinesBEL.FumeQuantity = txtfumeqty.Text.Trim();
                objServiceTimelinesBEL.FumeNature = txtfumenature.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure1 = txteffluenttreatmentmeasure1.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure2 = txteffluenttreatmentmeasure2.Text.Trim();
                objServiceTimelinesBEL.EffluentTreatmentMeasure3 = txteffluenttreatmentmeasure3.Text.Trim();
                objServiceTimelinesBEL.PowerReqInKW = txtpowerreq.Text.Trim();
                objServiceTimelinesBEL.ApplicantPriorityStatus = priority_status.ToString().Trim();

                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();
                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver = txtNetWorth.Text.Trim();
                objServiceTimelinesBEL.ExportOriented = Drop1.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.IAcategory = Convert.ToInt32(drpIACategory.SelectedValue.Trim());
                objServiceTimelinesBEL.IAType = Convert.ToInt32(ddlTypeOfIndustry.SelectedValue.Trim());

                objServiceTimelinesBEL.EtpRequired = drpreqETp.SelectedValue.Trim();
                if (chkpriority.Checked == true)
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = ddlPriority.SelectedItem.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.ApplicantPrioritySpecification = "";
                }

                if (txtOtherExpenses.Text.Length > 0)
                {
                    objServiceTimelinesBEL.OtherExpenses = txtOtherExpenses.Text.Trim();
                }
                else
                {
                    objServiceTimelinesBEL.OtherExpenses = (0).ToString();
                }
                objServiceTimelinesBEL.OtherFixedAssets = txtFixedAssets.Text.Trim();
                objServiceTimelinesBEL.projectstartmonths = txtProjectStartMonths.Text.Trim();
                objServiceTimelinesBEL.workexperience = txtWorkExperience.Text.Trim();
                objServiceTimelinesBEL.NetTurnOver = txtTurnover.Text.Trim();
                objServiceTimelinesBEL.ExportOriented = Drop1.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.Networth = txtNetWorth.Text.Trim();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                retval = objServiceTimelinesBLL.InsertChangeOfProjectDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {
                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Project Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                    string message = "Applicant Project Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 2;

                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }
        public bool ValidateDate(string dateInput)
        {
            try
            {
                DateTime dt3;
                if (DateTime.TryParseExact(dateInput,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void DisableAllControl()
        {
            txttypeofindustry.Enabled = false;
            txtWorkExperience.Enabled = false;

            txtProjectStartMonths.Enabled = false;
            txtpowerreq.Enabled = false;
            txtOtherExpenses.Enabled = false;
            txtland.Enabled = false;
            txtmachinery.Enabled = false;
            txtopenarearequired.Enabled = false;
            txtcoveredarea.Enabled = false;
            txteffluentgaseouscomposition.Enabled = false;
            txteffluentgaseousqty.Enabled = false;
            txteffluentliquidqty.Enabled = false;
            txteffluentsolidcomposition.Enabled = false;
            txteffluentsolidqty.Enabled = false;
            txteffluentliquidcomposition.Enabled = false;
            txtestimatedcost.Enabled = false;
            txtFixedAssets.Enabled = false;
            txtfumeqty.Enabled = false;
            txtfumenature.Enabled = false;
            txtbuilding.Enabled = false;
            txtapplicantpriorityspecification.Enabled = false;
            ddlPriority.Enabled = false;

            Drop1.Enabled = false;
            txteffluenttreatmentmeasure1.Enabled = false;
            txteffluenttreatmentmeasure2.Enabled = false;
            txteffluenttreatmentmeasure3.Enabled = false;
            BtnProjectInsert.Enabled = false;
            btnSave.Enabled = false;

        }

        //protected void txtNoofPlots_TextChanged(object sender, EventArgs e)
        //{
        //    string Message = "";
        //    if (Convert.ToDecimal(txtNoofPlots.Text) > 0)
        //    {
        //        string orignalArea = lblOriginalPlotArea.Text;
        //        string[] orgArea = orignalArea.Split(' ');
        //        string getOrgArea = orgArea[0];
        //        decimal TotSubdividedArea = Convert.ToDecimal(txtNoofPlots.Text);
        //        //string TotMortgagedArea = data.TotalMortgagedArea;
        //        decimal getOrgAreas = (Convert.ToDecimal(orgArea[0]) * 75) / 100;
        //        if (TotSubdividedArea <= getOrgAreas)
        //        {

        //        }
        //        else
        //        {
        //            txtNoofPlots.Text = "0";
        //             Message = "The Area to subdivided can't more than  75% of Original Plot Area";
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
        //        }
        //    }
        //}

        private void GetAdditionalProduct()
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_AdditionalProducts where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtAdditionalProduct.Text = dt.Rows[0]["AdditionalProduct"].ToString();
                txtProductdescription.Text = dt.Rows[0]["ProductDescription"].ToString();
            }
        }
        //tbl_allottee
        protected void AccountsDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("select * from tbl_AllotteePaymentJournal_test", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            AccountsDetailsGrid.DataSource = ds;
            AccountsDetailsGrid.DataBind();


        }

        private void GetChangeOfProjectDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetChangeOfProjectDetails(objServiceTimelinesBEL);

                DataTable dt_project = ds.Tables[0];

                if (dt_project.Rows.Count > 0)
                {
                    if (dt_project.Rows[0]["IAType"].ToString().Length > 0)
                    {
                        ddlTypeOfIndustry.SelectedValue = dt_project.Rows[0]["IAType"].ToString();
                    }
                    txttypeofindustry.Text = dt_project.Rows[0]["IndustryType"].ToString();
                    txtestimatedcost.Text = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtcoveredarea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    txtland.Text = dt_project.Rows[0]["LandDetails"].ToString();
                    txtbuilding.Text = dt_project.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text = dt_project.Rows[0]["OtherExpenses"].ToString();
                    txteffluentsolidqty.Text = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    txteffluentsolidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    txteffluentliquidqty.Text = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    txteffluentliquidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    txteffluentgaseousqty.Text = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    txteffluentgaseouscomposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    txtProjectStartMonths.Text = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    txtWorkExperience.Text = dt_project.Rows[0]["WorkExperience"].ToString();
                    if (dt_project.Rows[0]["IAcategory"].ToString().Trim().Length > 0)
                    {
                        drpIACategory.SelectedValue = dt_project.Rows[0]["IAcategory"].ToString().Trim();
                    }
                    if (dt_project.Rows[0]["EtpRequired"].ToString().Trim().Length > 0)
                    {
                        drpreqETp.SelectedValue = dt_project.Rows[0]["EtpRequired"].ToString().Trim();
                    }
                    if (drpreqETp.SelectedValue == "Yes")
                    {
                        MeasureDiv.Visible = true;
                    }
                    else
                    {
                        MeasureDiv.Visible = false;
                    }
                    if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
                    {
                        ETP.Visible = true;
                    }
                    else
                    {
                        ETP.Visible = false;
                    }
                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        chkfumes.Checked = true;
                        fumesdiv.Visible = true;
                        txtfumeqty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                        txtfumenature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        chkfumes.Checked = false;
                        fumesdiv.Visible = false;
                        txtfumeqty.Text = "";
                        txtfumenature.Text = "";
                    }
                    txteffluenttreatmentmeasure1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    txteffluenttreatmentmeasure2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    txteffluenttreatmentmeasure3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    txtpowerreq.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();

                    if (dt_project.Rows[0]["ApplicantPriorityStatus"].ToString() == "True")
                    {
                        chkpriority.Checked = true;
                        prioritydiv.Visible = true;
                        bindPriorityDdl();
                        ddlPriority.SelectedValue = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString().Trim();
                    }
                    else
                    {
                        chkpriority.Checked = false;
                        prioritydiv.Visible = false;
                        ddlPriority.SelectedIndex = -1;
                    }
                    txtNetWorth.Text = dt_project.Rows[0]["NetWorth"].ToString().Trim();

                    txtTurnover.Text = dt_project.Rows[0]["NetTurnOver"].ToString().Trim();

                    if (dt_project.Rows[0]["ExportOriented"].ToString() == "" || dt_project.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt_project.Rows[0]["ExportOriented"].ToString().Trim(); }




                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void drpIACategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIACategory.SelectedValue == "1" || drpIACategory.SelectedValue == "2")
            {
                ETP.Visible = true;
            }
            else
            {
                drpreqETp.SelectedIndex = 0;
                txteffluentgaseouscomposition.Text = "";
                txteffluentgaseousqty.Text = "";
                txteffluentliquidqty.Text = "";
                txteffluentliquidcomposition.Text = "";
                txteffluentsolidcomposition.Text = "";
                txteffluentsolidqty.Text = "";
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                ETP.Visible = false;
            }
        }

        protected void drpreqETp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpreqETp.SelectedValue == "Yes")
            {
                MeasureDiv.Visible = true;
            }
            else
            {
                txteffluenttreatmentmeasure1.Text = "";
                txteffluenttreatmentmeasure2.Text = "";
                txteffluenttreatmentmeasure3.Text = "";
                MeasureDiv.Visible = false;
            }
        }

        private void GetPaymentDetails()
        {

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

            try
            {

                GeneralMethod gm = new GeneralMethod();
                SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllotteeIAService '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string Applicantname = dt.Rows[0]["ApplicantName"].ToString();
                string Address = dt.Rows[0]["Address"].ToString();
                string IAID = dt.Rows[0]["IAID"].ToString();
                string PlotArea = dt.Rows[0]["PlotArea"].ToString();
                string CoveredArea = dt.Rows[0]["CoveredArea"].ToString();
                string AllottmentNo = dt.Rows[0]["Allotmentletterno"].ToString();
                string ControlID = dt.Rows[0]["NMControlId"].ToString();
                string UnitID = dt.Rows[0]["NMUnitId"].ToString();
                string ServiceID = dt.Rows[0]["NMServiceId"].ToString();
                string TraID = dt.Rows[0]["TraID"].ToString();
                string PlotNo = dt.Rows[0]["PlotNo"].ToString();


                if (ControlID.Length > 0)
                {
                    UC_IAServiceProcessFeeNMSWP UC_IAServiceProcessFeeNMSWP = LoadControl("~/UC_IAServiceProcessFeeNMSWP.ascx") as UC_IAServiceProcessFeeNMSWP;
                    UC_IAServiceProcessFeeNMSWP.IndustrialArea = Convert.ToInt32(IAID);
                    UC_IAServiceProcessFeeNMSWP.SWCControlID = ControlID;
                    UC_IAServiceProcessFeeNMSWP.SWCUnitID = UnitID;
                    UC_IAServiceProcessFeeNMSWP.SWCServiceID = ServiceID;
                    UC_IAServiceProcessFeeNMSWP.ServiceRequestNo = ServiceReqNo;
                    UC_IAServiceProcessFeeNMSWP.ApplicantName = Applicantname;
                    UC_IAServiceProcessFeeNMSWP.applicantAddress = Address;
                    UC_IAServiceProcessFeeNMSWP.choicearea = Convert.ToDouble(PlotArea);
                    UC_IAServiceProcessFeeNMSWP.PlotNo = PlotNo;
                    UC_IAServiceProcessFeeNMSWP.PlotArea = Convert.ToDecimal(PlotArea);
                    UC_IAServiceProcessFeeNMSWP.CoveredArea = PlotArea;
                    UC_IAServiceProcessFeeNMSWP.TranID = TraID;
                    PlaceHolder1.Controls.Add(UC_IAServiceProcessFeeNMSWP);

                }
                else
                {
                    UC_IAServiceProcessFee UC_IAServiceProcessFee = LoadControl("~/UC_IAServiceProcessFee.ascx") as UC_IAServiceProcessFee;
                    UC_IAServiceProcessFee.IndustrialArea = Convert.ToInt32(IAID);
                    if (TypeID == "1029")
                    {
                        UC_IAServiceProcessFee.choicearea = Convert.ToDouble(lblAmalgamatedArea.Text.Trim());
                    }
                    else
                    {
                        UC_IAServiceProcessFee.choicearea = Convert.ToDouble(PlotArea);
                    }
                    UC_IAServiceProcessFee.CoveredArea = CoveredArea;
                    UC_IAServiceProcessFee.AllotmentLetterNo = AllottmentNo;
                    UC_IAServiceProcessFee.SWCControlID = ControlID;
                    UC_IAServiceProcessFee.SWCUnitID = UnitID;
                    UC_IAServiceProcessFee.SWCServiceID = ServiceID;
                    UC_IAServiceProcessFee.ServiceRequestNo = ServiceReqNo;
                    UC_IAServiceProcessFee.TranID = TraID;
                    UC_IAServiceProcessFee.ApplicantName = Applicantname;
                    UC_IAServiceProcessFee.applicantAddress = Address;
                    PlaceHolder1.Controls.Add(UC_IAServiceProcessFee);
                }
                PH_FinalView.Controls.Clear();
                UC_ApplicationFinalViewIAService UC_ApplicationFinalViewIAService = LoadControl("~/UC_ApplicationFinalViewIAService.ascx") as UC_ApplicationFinalViewIAService;
                UC_ApplicationFinalViewIAService.ID = "UC_ApplicationFinalViewIAService";
                UC_ApplicationFinalViewIAService.TranID = TraID;
                UC_ApplicationFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                UC_ApplicationFinalViewIAService.ControlID = UnitID;


                PH_FinalView.Controls.Add(UC_ApplicationFinalViewIAService);

                UC_Allottee_Ledger_View UC_Allottee_Ledger_View = LoadControl("~/UC_Allottee_Ledger_View.ascx") as UC_Allottee_Ledger_View;
                UC_Allottee_Ledger_View.ID = "UC_Allottee_Ledger_View";

                UC_Allottee_Ledger_View.ServiceReqNo = ServiceReqNo;

                ph_AllotteeLeger.Controls.Add(UC_Allottee_Ledger_View);

            }
            catch (Exception ex)
            { }

        }

        private void GetApplicationDetails()
        {
            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsIAService '" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    string Payment = dt.Rows[0]["PaymentStatus"].ToString();
                    string Objection = dt.Rows[0]["Objection"].ToString();
                    string Rejected = dt.Rows[0]["Rejected"].ToString();
                    string Completed = dt.Rows[0]["Completed"].ToString();
                    string NMSWPFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
                    UPSIDAFee = dt.Rows[0]["PaymentStatus"].ToString();
                    string Status = dt.Rows[0]["FinalSubmission"].ToString();

                    allottedarea = dt.Rows[0]["PlotSize"].ToString();
                    lblAlootedtotalarea.Text = allottedarea;
                    lblOriginalPlotArea.Text = allottedarea;
                    PlotNo = dt.Rows[0]["PlotNo"].ToString();

                    //  PANNO= dt.Rows[0]["PlotNo"].ToString();
                    AllotmentNo = dt.Rows[0]["Allotmentletterno"].ToString();
                    AllotmentDate = dt.Rows[0]["DateOfAllotment"].ToString();
                    ApplicationLetter = dt.Rows[0]["PlotNo"].ToString();
                    SubDivisionRequestID = ServiceReqNo;
                    ServiceRequestID = dt.Rows[0]["AllotteeID"].ToString();
                    DateOfAllotment = dt.Rows[0]["DateOfAllotment"].ToString();

                    if (Objection == "True")
                    {
                        Allotment.ActiveViewIndex = 6;
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);

                    }
                    else
                    {
                        if (NMSWPFee == "Paid")
                        {
                            DocDisable.Text = "Lock";
                            DisableAllControl();
                        }
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Value == "6")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }

                    if (SWCControlID.Length > 0)
                    {
                        if (NMSWPFee == "Paid")
                        {
                            btn_Submit.Text = "Print";
                        }
                        else if (NMSWPFee == "Pending")
                        {
                            btn_Submit.Text = "Print";
                            DocDisable.Text = "Lock";
                            DisableAllControl();
                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                if (item.Text == "Final Form")
                                    menuItem = item;
                            }
                            menuItems.Remove(menuItem);
                            #region Faizan
                            if (TypeID == "1029")
                            {
                                if (UPSIDAFee == "Paid")
                                {
                                    btn_Submit.Text = "Print";
                                }

                            }
                            #endregion
                        }
                        else
                        {

                            if (Objection == "True")
                            {
                                Allotment.ActiveViewIndex = 6;
                                MenuItemCollection menuItems = sub_menu.Items;
                                MenuItem menuItem = new MenuItem();
                                foreach (MenuItem item in menuItems)
                                {
                                    if (item.Text == "Final Form")
                                        menuItem = item;
                                }
                                menuItems.Remove(menuItem);

                                MenuItemCollection menuItems1 = sub_menu.Items;
                                MenuItem menuItem1 = new MenuItem();
                                foreach (MenuItem item in menuItems1)
                                {
                                    if (item.Text == "Final Submission")
                                        menuItem1 = item;
                                }
                                menuItems1.Remove(menuItem1);

                            }
                            else
                            {
                                if (Status == "True")
                                {
                                    MenuItemCollection menuItems1 = sub_menu.Items;
                                    MenuItem menuItem1 = new MenuItem();
                                    foreach (MenuItem item in menuItems1)
                                    {
                                        if (item.Text == "Final Submission")
                                            menuItem1 = item;
                                    }
                                    menuItems1.Remove(menuItem1);
                                }
                                else
                                {
                                    DocDisable.Text = "UnLock";
                                    MenuItemCollection menuItems = sub_menu.Items;
                                    MenuItem menuItem = new MenuItem();
                                    foreach (MenuItem item in menuItems)
                                    {
                                        if (item.Text == "Final Form")
                                            menuItem = item;
                                    }
                                    menuItems.Remove(menuItem);
                                }
                            }
                        }

                    }
                    else
                    {
                        if (Payment == "Paid")
                        {
                            btnPay.Text = "Print";
                        }
                        else
                        {
                            DocDisable.Text = "UnLock";
                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                if (item.Text == "Final Form")
                                    menuItem = item;
                            }
                            menuItems.Remove(menuItem);
                        }
                    }

                    if (Rejected == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "8", Text = "Rejection Letter" });
                    }
                    if (Completed == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "8", Text = "Approval Letter" });
                    }


                }

            }

        }

        //------------------------------For Payment--------------------------------
        protected void btnPay_Click(object sender, EventArgs e)
        {

            if (btnPay.Text == "Print")
            {
                GetPaymentDetails();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

            }
            else
            {

                int Count1 = 0;
                SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocuments '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                adp.Fill(dss);
                if (dss.Tables.Count > 0)
                {
                    DataTable dt1 = dss.Tables[0];
                    DataTable dt2 = dss.Tables[1];
                    string Message = "";


                    if (dt1.Rows.Count <= 0)
                    {

                        if (TypeID == "1003")
                        {
                            Message = "Project Details are Mandatory";
                        }
                        if (TypeID == "1004")
                        {
                            Message = "Product details are Mandatory";
                        }
                        if (TypeID == "1009")
                        {
                            Message = "Building Specifications are Mandatory";
                        }
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                    else
                    {
                        string Project = dt1.Rows[0][0].ToString();
                        if (Project == "Pending")
                        {

                            if (TypeID == "1003")
                            {
                                Message = "Project Details are Mandatory";
                            }
                            if (TypeID == "1004")
                            {
                                Message = "Product details are Mandatory";
                            }
                            if (TypeID == "1009")
                            {
                                Message = "Building Specifications are Mandatory";
                            }
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }

                    }
                    if (dt2.Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dt2.Rows[0][0].ToString());
                        string firmType = dt2.Rows[0][1].ToString();

                        switch (firmType)
                        {
                            case "1003":
                                Count1 = 2;
                                break;
                            case "1004":
                                Count1 = 2;
                                break;
                            case "1009":
                                Count1 = 7;
                                break;
                            case "1010":
                                Count1 = 7;
                                break;
                        }

                        if (count < Count1)
                        {
                            Message = "Please upload all mandatory documents";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                    }
                    else
                    {
                        Message = "There is Problem with server please try again after sometime";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                }

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(ServiceReqNo, "UPSIDC");

                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    dsR = objServiceTimelinesBLL.GetApplicableChargesIAServices(objServiceTimelinesBEL);

                    if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                    if (dt_Fee.Rows.Count > 0)
                    {

                        try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }
                        //Test Amalgamation Validation
                        //if (TypeID == "1029" && TotalCharges>2360)
                        //{
                        //    TotalCharges = TotalCharges - 2360;
                        //}
                        GetApplicationDetails();
                        gm = new GeneralMethod();
                        string NewString = Regex.Replace(lblAllotteeName.Text, @"[^0-9a-zA-Z]+", "");
                        string PaymentGetwayURL = gm.SendToPaymentGetwayHDFCNew(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Change Of Plot", NewString.Trim(), lblSIgnatoryEmail.Text, lblSignatoryMobile.Text, "One");

                        if (PaymentGetwayURL == "Failed")
                        {
                            string Message = "Errro Ocured In Processing !";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        }
                        else
                        {
                            Response.Redirect(PaymentGetwayURL);
                        }
                    }
                }
            }

        }

        protected void btnFar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtFar.Text.Length <= 0)
                {
                    string Message = "Far is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (txtGroundcover.Text.Length <= 0)
                {
                    string Message = "Ground coverage is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                    return;
                }
                if (txtHeight.Text.Length <= 0)
                {
                    string Message = "Height is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (txtSetBackFront.Text.Length <= 0)
                {
                    string Message = "Set Back front is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (txtSetBackRear.Text.Length <= 0)
                {
                    string Message = "Set Back rear is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

                if (txtSetBackSide1.Text.Length <= 0)
                {
                    string Message = "Set Back side1 is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

                if (txtSetBackSide2.Text.Length <= 0)
                {
                    string Message = "Set Back side2 is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (ddlNature.SelectedIndex == 0)
                {
                    string Message = "Please select classification of hazard";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }
                if (txtOccupancy.Text.Length <= 0)
                {
                    string Message = "Occupancy is required field";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }


                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.ServiceRequest = ServiceReqNo;

                try { objServiceTimelinesBEL.Far = float.Parse(txtFar.Text); } catch { }
                try { objServiceTimelinesBEL.Groundcover = float.Parse(txtGroundcover.Text); } catch { }
                try { objServiceTimelinesBEL.SetBackFront = float.Parse(txtSetBackFront.Text); } catch { }
                try { objServiceTimelinesBEL.SetBackRear = float.Parse(txtSetBackRear.Text); } catch { }
                try { objServiceTimelinesBEL.SetBackSide1 = float.Parse(txtSetBackSide1.Text); } catch { }
                try { objServiceTimelinesBEL.SetBackSide2 = float.Parse(txtSetBackSide2.Text); } catch { }
                try { objServiceTimelinesBEL.Height = float.Parse(txtHeight.Text); } catch { }
                try { objServiceTimelinesBEL.Occupancy = float.Parse(txtOccupancy.Text); } catch { }


                objServiceTimelinesBEL.NatureofOccupancy = ddlNature.SelectedValue.Trim();
                objServiceTimelinesBEL.ModifiedBy = "Allottee";
                objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;
                objServiceTimelinesBEL.ExistingBasement = (txtBaseMent1.Text);
                objServiceTimelinesBEL.ExistingGroundFloor = (txtGround1.Text.Trim());
                objServiceTimelinesBEL.ExistingFirstFloor = (txtFirstfloor1.Text.Trim());
                objServiceTimelinesBEL.ExistingSecondFloor = (txtSecondFloor1.Text.Trim());
                objServiceTimelinesBEL.ExistingMezzanineFloor = (txtMezzanine1.Text.Trim());
                objServiceTimelinesBEL.ProposedBasement = (txtBaseMent2.Text.Trim());
                objServiceTimelinesBEL.ProposedGroundFloor = (txtGround2.Text.Trim());
                objServiceTimelinesBEL.ProposedFirstFloor = (txtFirstfloor2.Text.Trim());
                objServiceTimelinesBEL.ProposedSecondFloor = (txtSecondFloor2.Text.Trim());
                objServiceTimelinesBEL.ProposedMezzanineFloor = (txtMezzanine2.Text.Trim());
                objServiceTimelinesBEL.Foundation = (txtFoundation.Text.Trim());
                objServiceTimelinesBEL.Floors = (txtFloors.Text.Trim());
                objServiceTimelinesBEL.Walls = (txtWalls.Text.Trim());
                objServiceTimelinesBEL.Roofs = (txtRoofs.Text.Trim());
                objServiceTimelinesBEL.NoofLatrines = (txtLatrines.Text.Trim());
                objServiceTimelinesBEL.NoofStories = (txtStories.Text.Trim());
                objServiceTimelinesBEL.PurposeofBuildingUse = (txtbuildingPurpose.Text.Trim());
                objServiceTimelinesBEL.PreviousConstruction = (txtPreviousConstruction.Text.Trim());
                objServiceTimelinesBEL.SourceofWater = (txtWaterSource.Text.Trim());
                objServiceTimelinesBEL.CoveredArea = (txtCoveredAreaA.Text.Trim());
                objServiceTimelinesBEL.StiltFloor = (txtStealth.Text.Trim());
                objServiceTimelinesBEL.Mumti = (txtMumti.Text.Trim());



                int retVal = objServiceTimelinesBLL.InsertBuildingSpecification(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    string Message = "Building Specification Save Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    Allotment.ActiveViewIndex = 2;
                }
                else
                {
                    string message = "Record couldnt be  Save ";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }


        }

        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveDemandPlusObjection UC_ResolveDemandPlusObjection = LoadControl("~/UC_ResolveDemandPlusObjection.ascx") as UC_ResolveDemandPlusObjection;
            UC_ResolveDemandPlusObjection.ID = "UC_ResolveDemandPlusObjection";
            UC_ResolveDemandPlusObjection.ServiceReqNo = ServiceReqNo;
            PH_Objection.Controls.Add(UC_ResolveDemandPlusObjection);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int retval = 0;

                if (txtAdditionalProduct.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter product to add');", true);
                    return;
                }
                if (txtProductdescription.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Enter Product Description');", true);
                    return;
                }

                objServiceTimelinesBEL.AdditionalProduct = txtAdditionalProduct.Text;
                objServiceTimelinesBEL.ProductDescription = txtProductdescription.Text;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                retval = objServiceTimelinesBLL.InsertAdditionalProductDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {

                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Additional Product Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                    string message = "Additional Product Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 2;

                }

            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)

        {

            hfName.Value = asdf;

            ViewState["BY_Condtion_Function"] = hfName.Value;
            BY_SET_Condtion_Function = hfName.Value;

            BindServiceCheckListGridViewDocument(hfName.Value);
        }
        protected void view_asdf(string serviceid)
        {

            //   checklisttabs.Text = "";


            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = ServiceReqNo.Split('/');

                objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {
                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            htmldata += @"<a id='KK' class='font-bold' StaticSelectedStyle-CssClass='sub_menu_active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";
                        }

                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit);
                        ViewState["firstCondition"] = firstCondition;
                        hfName.Value = firstCondition;
                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                        BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
        }
        protected void view_asdf1(string ChecklistId)
        {

            //   checklisttabs.Text = "";
            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                string[] SerIdarray = ServiceReqNo.Split('/');

                objServiceTimelinesBEL.ServiceChecklistId = ChecklistId;


                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {
                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            htmldata += @"<a id='KK' class='font-bold'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";



                        }
                        Literal loLit = new Literal();
                        loLit.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit);
                        ViewState["firstCondition"] = firstCondition;
                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
                        BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
        }




        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (btn_Submit.Text == "Print")
            {
                GetPaymentDetails();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);
            }
            else
            {

                int Count1 = 0;
                SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocuments '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                adp.Fill(dss);
                if (dss.Tables.Count > 0)
                {
                    DataTable dt1 = dss.Tables[0];
                    DataTable dt2 = dss.Tables[1];
                    string Message = "";


                    if (dt1.Rows.Count <= 0)
                    {
                        if (TypeID == "1003")
                        {
                            Message = "Project Details are Mandatory";
                        }
                        if (TypeID == "1004")
                        {
                            Message = "Product details are Mandatory";
                        }
                        if (TypeID == "1009")
                        {
                            Message = "Building Specifications are Mandatory";
                        }
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                    else
                    {
                        string Project = dt1.Rows[0][0].ToString();
                        if (Project == "Pending")
                        {

                            if (TypeID == "1003")
                            {
                                Message = "Project Details are Mandatory";
                            }
                            if (TypeID == "1004")
                            {
                                Message = "Product details are Mandatory";
                            }
                            if (TypeID == "1009")
                            {
                                Message = "Building Specifications are Mandatory";
                            }
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }

                    }
                    if (dt2.Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dt2.Rows[0][0].ToString());
                        string firmType = dt2.Rows[0][1].ToString();

                        switch (firmType)
                        {
                            case "1003":
                                Count1 = 2;
                                break;
                            case "1004":
                                Count1 = 2;
                                break;
                            case "1009":
                                Count1 = 7;
                                break;
                            case "1010":
                                Count1 = 7;
                                break;

                        }

                        if (count < Count1)
                        {
                            Message = "Please upload all mandatory documents";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                            GetPaymentDetails();
                            return;
                        }
                    }
                    else
                    {
                        Message = "There is Problem with server please try again after sometime";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                }

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();
                GeneralMethod gm = new GeneralMethod();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                dsR = objServiceTimelinesBLL.GetApplicableChargesIAServices(objServiceTimelinesBEL);
                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {
                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }
                    if (TotalCharges > 0)
                    {
                        string ReturnMsg = gm.CreateTransactionDataBeforeNMSWP(ServiceReqNo);
                        if (ReturnMsg.Trim() == "Success")
                        {
                            string NMSWP_Result = gm.UpdateFeeAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "12", "Applicant Request Submitted, Fee Payment is Pending kindly pay fees for the final submission | Applicant", (TotalCharges).ToString(), SWCRequest_ID, "Applicant");

                            if (NMSWP_Result.Trim() == "SUCCESS")
                            {
                                string ReturnMsg1 = gm.UpdateTraStatusNMSWP(ServiceReqNo);
                                if (ReturnMsg1 == "Success")
                                {
                                    string Message = "Request is submitted successfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetPaymentDetails();
                                    GetApplicationDetails();
                                    return;
                                }
                                else
                                {
                                    string Message = "Request is submitted successfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetPaymentDetails();
                                    GetApplicationDetails();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        string Message = "Amount is null";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        GetPaymentDetails();
                        return;
                    }
                }

            }
        }
        private void CheckNMSWPFeePaid()
        {

            SqlCommand cmd = new SqlCommand("Select * from [tbl_NMSWPTransactionDetails] where ControlID='" + SWCControlID.Trim() + "' and UnitID='" + SWCUnitID.Trim() + "' and ServiceID='" + SWCServiceID.Trim() + "' and RequestID='" + SWCRequest_ID + "' and isnull(Fee_Status,'') in ('Pending')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {



                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID, SWCRequest_ID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "11")
                {
                    string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                    string Dt = gm.UpdateNMSWPFeePaid(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                    if (Dt == "Success")
                    {
                        string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "05", "Application Forwarded to Concern Regional Office | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                        if (Result == "SUCCESS")
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        protected void btn_WithoutFeeSubmit_Click(object sender, EventArgs e)
        {
            if (Conform_CheckBox_multiview_1.Checked)
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                int retval = objServiceTimelinesBLL.FinalSubmissionWithoutFee(objServiceTimelinesBEL);

                if (retval > 0)
                {
                    string Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "13", "Applicant Submits the form to | DA " + lblIndustrialArea.Text, SWCRequest_ID, "DA " + lblIndustrialArea.Text, "");
                    //string Message = "Form Submitted Successfully";
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    //GetApplicationDetails();
                    //Allotment.ActiveViewIndex = 4;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "FinalMsg('" + ServiceReqNo + "');", true);
                }
            }
            else
            {
                string Message = "Kindly acknowledge before final submission";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

            }
        }
        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx");

            //try
            //{
            //    string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
            //    string UnitID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
            //    string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
            //    string DeptID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
            //    string PassSalt = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
            //    NameValueCollection collections = new NameValueCollection();
            //    collections.Add("Dept_Code", DeptID.Trim());
            //    collections.Add("ControlID", ControlID.Trim());
            //    collections.Add("UnitID", UnitID.Trim());
            //    collections.Add("ServiceID", ServiceID.Trim());
            //    collections.Add("PassSalt", PassSalt.Trim());
            //    //string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";//http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx
            //    string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx";//

            //    string html = "<html><head>";
            //    html += "</head><body onload='document.forms[0].submit()'>";
            //    html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
            //    foreach (string key in collections.Keys)
            //    {
            //        html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
            //    }
            //    html += "</form></body></html>";
            //    Response.Clear();
            //    Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
            //    Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
            //    Response.Charset = "ISO-8859-1";
            //    Response.Write(html);
            //    Response.End();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        //protected void rbtnFamilySelection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rbtnFamilySelection.SelectedIndex == 0)
        //    {
        //        familymemarea.Visible = true;
        //        isbtnselected = true;

        //    }
        //    else if (rbtnFamilySelection.SelectedIndex == 1)
        //    {
        //        familymemarea.Visible = false;
        //        isbtnselected = true;
        //    }

        //} 

        [WebMethod]
        public string getSubdivisionDetails(string ServiceReqNo)
        {
            Classes.Class1 cs = new Classes.Class1();
            DataTable dts = new DataTable();
            //List<getSubdivDATA> details = new List<getSubdivDATA>();
            cs.str = "select id,Plot_name, Plot_Area, Sal_mort from  SubdivisionChild where ServiceReqNo='" + ServiceReqNo + "' ";
            dts = cs.GetDataTable(cs.str);
            if (dts.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dts);
            }
            return JsonConvert.SerializeObject(dts);
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetData()
        {
            return "ok";
        }
        [WebMethod(EnableSession = true)]

        public static string saveData(subDIVISION data)
        {
            Classes.Class1 cs = new Classes.Class1();
            DataTable dts = new DataTable(); string ret = "";
            //var serializeData = JsonConvert.DeserializeObject<List<subDIVISION>>(subDivdata);
            //using (var con = new SqlConnection(Constr))
            //{
            //foreach (var data in subDivdata)
            //{
            //using (var cmd = new SqlCommand("INSERT INTO SubdivisionChild VALUES(@ID, @ServiceReqNo,@Plot_name,@Plot_Area,@Sal_mort,@CreateDate,@Status)"))
            //{
            string orignalArea = data.OrgPloatarea;
            if (orignalArea != "")
            {
                //string[] orgArea = orignalArea.Split(' ');
                //decimal getOrgArea = Convert.ToDecimal(orgArea[0]);
                decimal getOrgArea = Convert.ToDecimal(orignalArea);
                string TotSaleableArea = data.TotalSaleableArea;
                string TotMortgagedArea = data.TotalMortgagedArea;
                //decimal getOrgAreas = (Convert.ToDecimal(orgArea[0]) * 75) / 100;
                //decimal getSaleableArea = (Convert.ToDecimal(TotSaleableArea) * 20) / 100;
                if ((Convert.ToDecimal(data.Plot_Area) <= getOrgArea && data.Sal_mort == "Saleable") || data.Sal_mort == "Mortgaged")
                {
                    //if (Convert.ToDecimal(TotMortgagedArea) >= getSaleableArea)
                    //{
                    cs.str = "select PlotNo from AllotteeMAster a inner join ServiceRequests s on a.AllotteeID=s.AllotteeID  where s.ServiceRequestNO='" + data.ServiceReqNo + "'";
                    string PloatNo = Convert.ToString(cs.ExecuteScaler(cs.str));
                    if (PloatNo != data.Plot_Name)
                    {
                        if ((Convert.ToDecimal(data.Plot_Area) >= 450 && data.Sal_mort == "Saleable" && Convert.ToDecimal(data.Plot_Area) > 0) || data.Sal_mort == "Mortgaged")
                        // if (Convert.ToDecimal(data.Plot_Area) >= 450)
                        {
                            if ((data.Sal_mort == "Saleable") || (data.Sal_mort == "Mortgaged" && Convert.ToDecimal(data.Plot_Area) > 0))
                            {
                                cs.str = "SELECT isnull(max(ID),0)+ 1 FROM SubdivisionChild";
                                string Id = Convert.ToString(cs.ExecuteScaler(cs.str));
                                // cs.str = "INSERT INTO SubdivisionChild VALUES(@ID, @ServiceReqNo,@Plot_name,@Plot_Area,@Sal_mort,@CreateDate,@Status) ";
                                cs.str = "INSERT INTO SubdivisionChild (ID, ServiceReqNo,Plot_name,Plot_Area,Sal_mort,CreateDate,Status) ";
                                cs.str += "values('" + Id + "',N'" + data.ServiceReqNo + "',N'" + data.Plot_Name + "','" + data.Plot_Area + "',N'" + data.Sal_mort + "','" + DateTime.Now + "','1')";
                                int ns = cs.ExecuteSql1(cs.str);
                                if (ns >= 1)
                                {
                                    //HttpContext.Current.Session["JMethod"] = "1";
                                    ret = "Success";
                                }
                                //{ ret = "1"; }
                            }
                            else
                            {
                                ret = "AreaMortMini";
                            }
                        }
                        else
                        {
                            //-------------Mini Area 450sqm--------------
                            ret = "AreaMini";
                        }
                    }
                    else
                    {//--------------For Plot Name check Error
                     //ret = "2";
                        ret = "Errors";
                    }
                    //}
                    //else
                    //{
                    //    ret = "MortgagedArea";
                    //}
                }
                else
                {
                    ret = "SaleableArea";
                }
            }
            else
            {
                ret = "AreaToSubdivided";
            }

            return ret;
        }

        public class subDIVISION
        {
            public string Plot_Name { get; set; }
            public string ServiceReqNo { get; set; }
            public string Plot_Area { get; set; }
            public string Sal_mort { get; set; }
            public string OrgPloatarea { get; set; }

            public string TotalMortgagedArea { get; set; }

            public string TotalSaleableArea { get; set; }
            // public DateTime CreatedDate { get; set; }
        }
    }

    //[System.Web.Services.WebMethod]

}   


