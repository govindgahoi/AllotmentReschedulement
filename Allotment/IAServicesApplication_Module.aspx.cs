
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Collections.Specialized;
using System.Text;
using System.Security.Cryptography;


namespace Allotment
{
    public partial class IAServicesApplication_Module : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        string App;
        string TypeID;
        SqlConnection con;
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";

        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string checklistid { get; set; }
        GeneralMethod gm = new GeneralMethod();


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                string[] SerIdarray = ServiceReqNo.Split('/');
                TypeID = SerIdarray[1].ToString();

                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID = NMSWP.Rows[0][3].ToString();

                PH_AllotteeDetails.Controls.Clear();
                RegisterPostBackControl();
                UC_Service_Allotteee_Details_IA_Services UC_Service_Allotteee_Details_IA_Services = LoadControl("~/UC_Service_Allotteee_Details_IA_Services.ascx") as UC_Service_Allotteee_Details_IA_Services;
                UC_Service_Allotteee_Details_IA_Services.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Service_Allotteee_Details_IA_Services.AllotteeId = SerIdarray[2];
                PH_AllotteeDetails.Controls.Add(UC_Service_Allotteee_Details_IA_Services);

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


                if (!IsPostBack)
                {

                    DataTable temp_Bank_details = new DataTable();
                    temp_Bank_details.TableName = "temp_Bank_details";
                    temp_Bank_details.Columns.Add(new DataColumn("BankName", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("BranchName", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("MobileNumber", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("email", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("Percentage", typeof(string)));
                    temp_Bank_details.Columns.Add(new DataColumn("Bankstatus", typeof(string)));



                    ViewState["temp_Bank_details"] = temp_Bank_details;
                    temp_Bank_details_DataBind();
                    DataTable temp_TEF_details = new DataTable();
                    temp_TEF_details.Columns.Add(new DataColumn("Id", typeof(string)));
                    temp_TEF_details.Columns.Add(new DataColumn("TEFRefferenceNumber", typeof(string)));
                    temp_TEF_details.Columns.Add(new DataColumn("TEFApprovalDate", typeof(string)));
                    temp_TEF_details.Columns.Add(new DataColumn("TEFPeriod", typeof(string)));
                    temp_TEF_details.Columns.Add(new DataColumn("TEFFees", typeof(string)));


                    ViewState["temp_TEF_details"] = temp_TEF_details;
                    temp_TEF_details_DataBind();

                    if (TypeID == "1003")
                    {
                        lblFormName.Text = "Application Form Of Change Of Project";
                    }
                    if (TypeID == "1004")
                    {
                        lblFormName.Text = "Application Form Of Addition Of Product";
                    }

                    #region Codebymanish
                    if (TypeID == "1005")
                    {
                        lblFormName.Text = "Application Form Of Noc for permission to mortgage in favour of Financial Institution ";
                    }
                    if (TypeID == "1006")
                    {
                        lblFormName.Text = "Application for Joint Mortgage";
                    }
                    if (TypeID == "1007")
                    {
                        lblFormName.Text = "Application for creation  of Second Charge";
                    }
                    if (TypeID == "1011")
                    {
                        lblFormName.Text = "Application for Transfer of Lease deed to Financial Institution";
                    }
                    if (TypeID == "1002")
                    {
                        lblFormName.Text = "Application for Time Extension ";
                    }
                    if (TypeID == "1014")
                    {
                        lblFormName.Text = "Application for Start of Production Certificate ";
                    }
                    if (TypeID == "1013")
                    {
                        lblFormName.Text = "Plot Cancelation ";
                    }
                    #endregion

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
                        GetPaymentDetails();
                        CheckNMSWPFeePaid();
                    }
                    if (TypeID == "1004")
                    {
                        GetPaymentDetails();
                        CheckNMSWPFeePaid();
                    }
                    if (TypeID == "1005")
                    {
                        if (CheckBox_Final.Checked == true)
                        {
                            btn_Submit.Enabled = true;
                        }
                        else
                        {
                            btn_Submit.Enabled = false;
                        }
                        GetFinalViewNocMortgageDetails();
                        GetNocMortgageDetails();
                    }
                    if (TypeID == "1006")
                    {
                        if (CheckBox_Final.Checked == true)
                        {
                            btn_Submit.Enabled = true;
                        }
                        else
                        {
                            btn_Submit.Enabled = false;
                        }
                        GetJointMortgageDetails();
                        GetFinalViewJointMortgageDetails();
                    }
                    if (TypeID == "1007")
                    {
                        if (CheckBox_Final.Checked == true)
                        {
                            btn_Submit.Enabled = true;
                        }
                        else
                        {
                            btn_Submit.Enabled = false;
                        }
                        GetFinalViewDetails();
                        GetSecondchargeDetails();
                    }
                    if (TypeID == "1011")
                    {
                        if (CheckBox_Final.Checked == true)
                        {
                            btn_Submit.Enabled = true;
                        }
                        else
                        {
                            btn_Submit.Enabled = false;
                        }
                        GetFinalViewtransferofleasedeedDetails();
                        GettransferofleasedeedDetails();
                    }
                    if (TypeID == "1002")
                    {                       
                        GetTimeextensionDetails();
                        GetPaymentDetails();
                        TEFPeriodBinding();
                        if (ddlCovid19.SelectedValue == "True")
                        {
                            ddlSelectTimePeriod.Items.Remove(ddlSelectTimePeriod.Items.FindByValue("3"));
                        }
                        BindDocumentChecklistTimeextenstion();
                        ViewTEFApprovalLetter();
                        GetFinalViewtimeextensionDetails();
                    }
                    if (TypeID == "1014")
                    {
                        GetFinalViewStartofProductionCertificateDetails();
                        GetStartofProductionDetails();
                    }
                    if (!IsPostBack)
                    {
                        if (TypeID == "1013")
                        {
                            bindNoticeManu();
                        }
                    }

                    if (TypeID == "1013")
                    {
                        Get_Notice_of_service();
                    }

                    GetApplicationDetails();
                }


                if (SWCControlID.Length > 0)
                {
                    if(TypeID == "1002")
                    {
                        btnPay.Visible = true;
                    }
                    else
                    {
                        btn_Submit.Visible = true;
                    }
                    
                }
                else
                {
                    btn_Submit.Visible = false;
                    btnPay.Visible = true;
                }
                BindObjection();
             
                #region codebymanish
                if (TypeID == "1005")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);

                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);

                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Make Payment")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);

                }
                if (TypeID == "1006")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);
                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);

                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Make Payment")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);
                }
                if (TypeID == "1007")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);

                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);

                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Make Payment")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);
                }
                if (TypeID == "1011")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);
                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);

                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Make Payment")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);

                }
                if (TypeID == "1002")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);
                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);

                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Final Submission")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);

                }

                #endregion

                #region NewService
                if (TypeID == "1014")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);

                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);
                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Make Payment")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);
                }

                if (TypeID == "1013")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Project Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "New Product Details")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Joint Mortgage Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Noc Mortgage Details")
                            menuItem3 = item;
                    }
                    menuItems.Remove(menuItem3);
                    MenuItem menuItem4 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Second Charge Details")
                            menuItem4 = item;
                    }
                    menuItems.Remove(menuItem4);
                    MenuItem menuItem5 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Transfer of lease deed")
                            menuItem5 = item;
                    }
                    menuItems.Remove(menuItem5);

                    MenuItem menuItem6 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Time extension fee")
                            menuItem6 = item;
                    }
                    menuItems.Remove(menuItem6);
                    MenuItem menuItem7 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Start of Production Certificate")
                            menuItem7 = item;
                    }
                    menuItems.Remove(menuItem7);
                }

                #endregion
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }

        #region Time Extenstion

        private void GetTimeextensionDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetTimeextensionDetails(objServiceTimelinesBEL);

                DataTable dt_timeextensionfee = ds.Tables[0];
                DataTable dt_applicanttefdetails = ds.Tables[1];

                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    txtApplicationDescription.Text = dt_timeextensionfee.Rows[0]["description"].ToString();
                    ddlSelectTimePeriod.SelectedValue = dt_timeextensionfee.Rows[0]["TEFTimeperiod"].ToString();
                    ddltef.SelectedValue = dt_timeextensionfee.Rows[0]["TEFStatus"].ToString();
                    ddlCovid19.SelectedValue = dt_timeextensionfee.Rows[0]["freetimeextension"].ToString();
                    ddlapplicableonAllotmentletter.SelectedValue = dt_timeextensionfee.Rows[0]["applicableonAllotmentletter"].ToString();
                    if (ddltef.SelectedValue == "True")
                    {
                        DivTEF.Visible = true;
                       
                    }
                    else
                    {
                        DivTEF.Visible = false;
                    }
                }
                if (dt_applicanttefdetails.Rows.Count > 0)
                {
                    ViewState["temp_TEF_details"] = dt_applicanttefdetails;
                    temp_TEF_details_DataBind();

                    //TEFGrid.DataSource = dt_applicanttefdetails;
                    //TEFGrid.DataBind();

                }
                else
                {
                    temp_TEF_details_DataBind();
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void GetFinalViewtimeextensionDetails()
        {
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
                string ControlID = dt.Rows[0]["ControlId"].ToString();
                string UnitID = dt.Rows[0]["UnitId"].ToString();
                string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                string TraID = dt.Rows[0]["TraID"].ToString();
                string TEFTimeperiod = dt.Rows[0]["TEFTimeperiod"].ToString();
                UC_ApplicationFinalViewTimeextensionService UC_ApplicationFinalViewTimeextensionService = LoadControl("~/UC_ApplicationFinalViewTimeextensionService.ascx") as UC_ApplicationFinalViewTimeextensionService;
                UC_ApplicationFinalViewTimeextensionService.ID = "UC_ApplicationFinalViewTimeextensionService";
                UC_ApplicationFinalViewTimeextensionService.TranID = TraID;
                UC_ApplicationFinalViewTimeextensionService.ServiceRequestNo = ServiceReqNo;
                UC_ApplicationFinalViewTimeextensionService.IndustrialArea = Convert.ToInt32(IAID);
                UC_ApplicationFinalViewTimeextensionService.PlotSize = decimal.Parse(PlotArea);
                //UC_ApplicationFinalViewTimeextensionService.TEFTimeperiod = Int32.Parse(TEFTimeperiod);
                //UC_ApplicationFinalViewTimeextensionService.AllotteeID = Int32.Parse(lblAllotteeID.Text);

                PH_FinalView.Controls.Add(UC_ApplicationFinalViewTimeextensionService);
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }
        private void Bind_Provisionalletter()
        {
            PH_Provisionalletter.Controls.Clear();
            UC_Document_Report_VG_TEF_Provisional UC_Document_Report_VG_TEF_Provisional = LoadControl("~/UC_Document_Report_VG_TEF_Provisional.ascx") as UC_Document_Report_VG_TEF_Provisional;
            UC_Document_Report_VG_TEF_Provisional.ID = "UC_Document_Report_VG_TEF_Provisional";
            UC_Document_Report_VG_TEF_Provisional.SerRequestNo = ServiceReqNo;
            PH_Provisionalletter.Controls.Add(UC_Document_Report_VG_TEF_Provisional);
        }
        public void BindDocumentChecklistTimeextenstion()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.ServiceTimeLines = "1002";
                objServiceTimelinesBEL.FirmType = "1";

                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetDocumentChecklistTimeextenstion(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView_timeextension.DataSource = ds;
                        GridView_timeextension.DataBind();
                    }
                    else
                    {
                        GridView_timeextension.DataSource = null;
                        GridView_timeextension.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
                }



            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }
        public void temp_TEF_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                TEFGrid.DataSource = dt;
                TEFGrid.DataBind();
                TEFGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                TEFGrid.DataSource = dt;
                TEFGrid.DataBind();
            }


        }
        protected void insert_TEF_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];
            string TEFReffrence = (TEFGrid.FooterRow.FindControl("txtTEFReff_insert") as TextBox).Text;
            string TEFApprovalDate_insert = (TEFGrid.FooterRow.FindControl("txtTEFApprovalDate_insert") as TextBox).Text;
            string TEFPeriod_insert = (TEFGrid.FooterRow.FindControl("drpdTEFPeriod") as DropDownList).SelectedValue.Trim();
            string TEFFees_insert = (TEFGrid.FooterRow.FindControl("txtTEFFees_insert") as TextBox).Text;
            string TEFApprovalDatee_str = DateTime.ParseExact(TEFApprovalDate_insert.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

            try
            {
                if (TEFReffrence != "")
                {
                    if (TEFApprovalDate_insert != "")
                    {

                        DataRow dr = dt.NewRow();
                        dr["TEFRefferenceNumber"] = TEFReffrence;
                        dr["TEFApprovalDate"] = TEFApprovalDatee_str;
                        dr["TEFPeriod"] = TEFPeriod_insert;
                        dr["TEFFees"] = TEFFees_insert;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                        ViewState["temp_TEF_details"] = dt;
                        temp_TEF_details_DataBind();

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Privious Time Extension Details');", true);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured11 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }



        }
        protected void TEFDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_TEF_details"];
            int index = Convert.ToInt32(e.RowIndex);
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["temp_TEF_details"] = dt;
            dt.AcceptChanges();
            temp_TEF_details_DataBind();


        }

        //private void GetApplicantTEFDetails()
        //{
        //    objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = objServiceTimelinesBLL.GetApplicantTEFDetails(objServiceTimelinesBEL);
        //        if (ds.Tables.Count > 0)
        //        {
        //            DataTable dt = ds.Tables[0];
        //            if (dt.Rows.Count > 0)
        //            {

        //                TEFGrid.DataSource = dt;
        //                TEFGrid.DataBind();

        //            }
        //            else
        //            {
        //                temp_TEF_details_DataBind();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured :" + ex.Message.ToString());
        //    }


        //}
        protected void TEFPeriodBinding()
        {
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.TEFPeriodBinding(objServiceTimelinesBEL);
                ddlSelectTimePeriod.DataSource = dsR.Tables[0];
                ddlSelectTimePeriod.DataTextField = "Perioddescription";
                ddlSelectTimePeriod.DataValueField = "Period";
                ddlSelectTimePeriod.DataBind();
                ddlSelectTimePeriod.Items.Insert(0, new ListItem("--Select--", "ALL"));
                if (ddlCovid19.SelectedValue == "True")
                {
                    ddlSelectTimePeriod.Items.Remove(ddlSelectTimePeriod.Items.FindByValue("3"));
                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }


        }
        protected void ddltef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltef.SelectedValue == "True")
            {
                DivTEF.Visible = true;
                //bindTransfercase();
            }
            else
            {
                DivTEF.Visible = false;
            }
        }
        protected void ddlCovid19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCovid19.SelectedValue == "True")
            {
                ddlSelectTimePeriod.Items.Remove(ddlSelectTimePeriod.Items.FindByValue("3"));
            }
        }
        //protected void btnPay_Click(object sender, EventArgs e)
        //{


        //    decimal TotalCharges;
        //    DataSet dsR = new DataSet();
        //    DataTable dt_Fee = new DataTable();


        //    GeneralMethod gm = new GeneralMethod();
        //    string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(ServiceReqNo, "UPSIDC");


        //    if (TransactionId_UPSIDC == "Failed")
        //    {
        //        string Message = "Failed In Processing";

        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
        //        return;
        //    }
        //    else
        //    {
        //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        //        //objServiceTimelinesBEL.TEFTimeperiod = Int32.Parse(ddlSelectTimePeriod.SelectedValue.ToString());
        //        //objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
        //        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

        //        dsR = objServiceTimelinesBLL.GetChargesforTEF(objServiceTimelinesBEL);

        //        if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
        //        if (dt_Fee.Rows.Count > 0)
        //        {

        //            try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

        //            gm = new GeneralMethod();
        //            string PaymentGetwayURL = gm.SendToPaymentGetwayHDFC(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Time Extension Fee", lblAllotteeName.Text, lblEmaildID.Text, lblMobileNumber.Text);

        //            if (PaymentGetwayURL == "Failed")
        //            {

        //                string Message = "Errro Ocured In Processing !";

        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
        //            }
        //            else
        //            {
        //                Response.Redirect(PaymentGetwayURL);
        //            }
        //        }
        //    }
        //}
        protected void btntimeextension_Click(object sender, EventArgs e)
        {
            DataTable Dt1 = (DataTable)ViewState["temp_TEF_details"];
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            if (ddltef.SelectedValue == "True")
            {
                if (Dt1.Rows.Count <= 0)
                {
                    string message = "Please Add Time extension Details Availd in past.By Clicking Add button at the Below Section";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            if (ddlCovid19.SelectedIndex == 0)
            {

                MessageBox1.ShowInfo("Please Select Do You want to avail free 6 Month Time Extension due to  Covid 19 Pandemic-Lockdown:");
                return;
            }
            if (ddlapplicableonAllotmentletter.SelectedIndex == 0)
            {
                MessageBox1.ShowInfo("Please Select  Time extension applicable as per Allotmentletter/transferletter/leesedeed(TEF Applicable on )");
                return;
            }
            if (ddltef.SelectedIndex == 0)
            {

                MessageBox1.ShowInfo("Please Select Time extension Availd in past");
                return;
            }
            if (ddlSelectTimePeriod.SelectedIndex == 0)
            {

                MessageBox1.ShowInfo("Select Time Period");
                return;
            }
            
            if (txtApplicationDescription.Text.Length <= 0)
            {
                MessageBox1.ShowError("Please Enter Application Description");
                return;
            }
            int count = 0;
            foreach (GridViewRow gvrow in GridView_timeextension.Rows)
            {
                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkAck");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }

            }
            if (count < 2)
            {
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n You have to acknowledge all the documents before applying.");
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                return;
            }
            try
            {
                int retval = 0, retVal2 = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                string str = txtApplicationDescription.Text.Trim();
                string str2 = Server.HtmlDecode(str);
                objServiceTimelinesBEL.ApplicationDescription = str2;
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                objServiceTimelinesBEL.TEFTimeperiod = Int32.Parse(ddlSelectTimePeriod.SelectedValue.ToString());
                objServiceTimelinesBEL.TEFStatus = (ddltef.SelectedValue.ToString());
                objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
                objServiceTimelinesBEL.FreeStatus = (ddlCovid19.SelectedValue.ToString());
                objServiceTimelinesBEL.applicableonAllotmentletter = (ddlapplicableonAllotmentletter.SelectedValue.ToString());
                retval = objServiceTimelinesBLL.InsertTimeextensionfeeDetails(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text);
                    retVal2 = objServiceTimelinesBLL.ClearTimeExtensionDetails(objServiceTimelinesBEL);
                    if (retVal2 >= 0)
                    {
                        if (ddltef.SelectedValue == "True")
                        {
                            DataTable temp = (DataTable)ViewState["temp_TEF_details"];
                            if (temp.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in temp.Rows)
                                {
                                    string TEFReffrence = dr1["TEFRefferenceNumber"].ToString();
                                    string TEFApprovalDatee_str = dr1["TEFApprovalDate"].ToString();
                                    string TEFPeriod_insert = dr1["TEFPeriod"].ToString();
                                    string TEFFees_insert = dr1["TEFFees"].ToString();
                                    objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text);
                                    objServiceTimelinesBEL.TEFRefferenceNumber = TEFReffrence;
                                    objServiceTimelinesBEL.TEFApprovalDate = Convert.ToDateTime(TEFApprovalDatee_str);
                                    objServiceTimelinesBEL.TEFPeriod = Convert.ToInt32(TEFPeriod_insert);
                                    objServiceTimelinesBEL.TEFFees = Convert.ToDecimal(TEFFees_insert);
                                    objServiceTimelinesBEL.IsActive = 1;
                                    objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                                    int retVal = objServiceTimelinesBLL.InsertAllotteeTEFDetails(objServiceTimelinesBEL);
                                }
                            }
                        }
                    }
                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Time Extensition Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                    string message = "Applicant Time Extensition  Details Saved Successfully";
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


        private void ViewTEFApprovalLetter()
        {

            objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ViewTEFApprovalLetter(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        int TEFTimeperiod = Convert.ToInt32(dt.Rows[0]["TEFTimeperiod"].ToString());
                        if (TEFTimeperiod > 0)
                        {
                            if (TEFTimeperiod <= 12)
                            {
                                if (dt1.Rows.Count > 0)
                                {
                                    string Payment = dt1.Rows[0]["PaymentStatus"].ToString();
                                    if (Payment == "Payment Completed")
                                    {
                                        Bind_Provisionalletter();
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    //MenuItemCollection menuItems = sub_menu.Items;
                                    //MenuItem menuItem = new MenuItem();
                                    //foreach (MenuItem item in menuItems)
                                    //{
                                    //    if (item.Value == "12")
                                    //        menuItem = item;
                                    //}
                                    //menuItems.Remove(menuItem);
                                }
                            }
                            else
                            {

                                //MenuItemCollection menuItems = sub_menu.Items;
                                //MenuItem menuItem = new MenuItem();
                                //foreach (MenuItem item in menuItems)
                                //{
                                //    if (item.Value == "12")
                                //        menuItem = item;
                                //}
                                //menuItems.Remove(menuItem);

                            }

                        }
                        else
                        {
                            //MenuItemCollection menuItems = sub_menu.Items;
                            //MenuItem menuItem = new MenuItem();
                            //foreach (MenuItem item in menuItems)
                            //{
                            //    if (item.Value == "12")
                            //        menuItem = item;
                            //}
                            //menuItems.Remove(menuItem);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }
        }
        #endregion

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
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            // BindServiceCheckListGridViewDocument(hfName.Value);
            if (index == 0)
            {

            }
            if (index == 3)
            {
                GetPaymentDetails();

            }
            if (index == 10)
            {
                BindObjection();
            }
            if (TypeID == "1005")
            {
                if (index == 4)
                {
                    GetFinalViewNocMortgageDetails();

                }
            }
            if (TypeID == "1007")
            {
                if (index == 4)
                {
                    GetFinalViewDetails();
                }
            }
            if (TypeID == "1006")
            {
                if (index == 4)
                {
                    GetFinalViewJointMortgageDetails();
                }
            }
            if (TypeID == "1011")
            {
                if (index == 4)
                {
                    GetFinalViewtransferofleasedeedDetails();
                }
            }
            if (TypeID == "1002")
            {
                if (index == 4)
                {
                    GetFinalViewtimeextensionDetails();
                }

            }
            if (TypeID == "1014")
            {
                if (index == 4)
                {
                    GetFinalViewStartofProductionCertificateDetails();
                }
            }
            if (index == 12)
            {
                Bind_Provisionalletter();
            }
            if (index == 13)
            {
                GetDetails();
            }

            Allotment.ActiveViewIndex = index;
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
                    if (TypeID == "1010")
                    {
                        DocType = "OccupancyCertificate";
                    }
                    if (TypeID == "1002")
                    {
                        DocType = "Timeextensionfee";
                    }
                    if (TypeID == "1005")
                    {
                        DocType = "nocmortgage";
                    }
                    if (TypeID == "1006")
                    {
                        DocType = "Jointmortgage";
                    }
                    if (TypeID == "1007")
                    {
                        DocType = "secondcharge";
                    }
                    if (TypeID == "1011")
                    {
                        DocType = "transferofleasedeed";
                    }
                    if (TypeID == "1014")
                    {
                        DocType = "startofproduction";
                    }
                    if (TypeID == "1013")
                    {
                        DocType = "plotcancelation";
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
                    if (TypeID == "1002")
                    {
                        DocType = "Timeextensionfee";
                    }
                    if (TypeID == "1005")
                    {
                        DocType = "nocmortgage";
                    }
                    if (TypeID == "1006")
                    {
                        DocType = "Jointmortgage";
                    }
                    if (TypeID == "1007")
                    {
                        DocType = "secondcharge";
                    }
                    if (TypeID == "1011")
                    {
                        DocType = "transferofleasedeed";
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
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Documents Uploaded and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");


                                    string message = "PDF File  Uploaded SucessFully ";
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

        //public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)

        //{

        //    hfName.Value = asdf;

        //    ViewState["BY_Condtion_Function"] = hfName.Value;
        //    BY_SET_Condtion_Function = hfName.Value;

        //    BindServiceCheckListGridViewDocument(hfName.Value);
        //}
        //protected void view_asdf(string serviceid)
        //{

        //    //   checklisttabs.Text = "";


        //    string htmldata = "";
        //    try
        //    {

        //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        //        string[] SerIdarray = ServiceReqNo.Split('/');

        //        objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
        //        DataSet ds0 = new DataSet();
        //        try
        //        {
        //            ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
        //            if (ds0.Tables[0].Rows.Count > 0)
        //            {

        //                foreach (DataRow dr in ds0.Tables[0].Rows)
        //                {
        //                    firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
        //                    htmldata += @"<a id='KK' class='font-bold' StaticSelectedStyle-CssClass='sub_menu_active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";
        //                }

        //                Literal loLit = new Literal();
        //                loLit.Text = (htmldata);
        //                pnlDemo.Controls.Add(loLit);
        //                ViewState["firstCondition"] = firstCondition;
        //                if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }
        //                BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //        }

        //    }
        //    catch { }
        //}
        //protected void view_asdf1(string ChecklistId)
        //{

        //    //   checklisttabs.Text = "";
        //    string htmldata = "";
        //    try
        //    {

        //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


        //        string[] SerIdarray = ServiceReqNo.Split('/');

        //        objServiceTimelinesBEL.ServiceChecklistId = ChecklistId;


        //        DataSet ds0 = new DataSet();
        //        try
        //        {
        //            ds0 = objServiceTimelinesBLL.GetServiceChecklists_SP_BY_Condtion(objServiceTimelinesBEL);
        //            if (ds0.Tables[0].Rows.Count > 0)
        //            {

        //                foreach (DataRow dr in ds0.Tables[0].Rows)
        //                {

        //                    firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
        //                    htmldata += @"<a id='KK' class='font-bold'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";



        //                }

        //                Literal loLit = new Literal();
        //                loLit.Text = (htmldata);
        //                pnlDemo.Controls.Add(loLit);



        //                ViewState["firstCondition"] = firstCondition;

        //                if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }

        //                BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);




        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //        }

        //    }
        //    catch { }
        //}
        //public void BindServiceCheckListGridViewDocument(string condition)
        //{
        //    try
        //    {
        //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        //        string[] SerIdarray = ServiceReqNo.Split('/');
        //        objServiceTimelinesBEL.ServiceTimeLines = SerIdarray[1];
        //        objServiceTimelinesBEL.ServiceChecklistCondition = condition;
        //        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
        //        if (App == "Resubmit")
        //        {
        //            objServiceTimelinesBEL.Status = 0;
        //        }
        //        else
        //        {
        //            objServiceTimelinesBEL.Status = 1;
        //        }

        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            ds = objServiceTimelinesBLL.GetAllServiceChecklistsIAServices(objServiceTimelinesBEL);
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                GridView2.DataSource = ds;
        //                GridView2.DataBind();
        //            }
        //            else
        //            {
        //                GridView2.DataSource = null;
        //                GridView2.DataBind();
        //            }
        //            this.RegisterPostBackControl();
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //        }
        //        finally
        //        {
        //            objServiceTimelinesBEL = null;
        //            objServiceTimelinesBLL = null;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //    }
        //}

        //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}
        //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {


        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
        //            string[] SerIdarray = ServiceReqNo.Split('/');
        //            string AllottementLetterNo = SerIdarray[2];
        //            objServiceTimelinesBEL.UserName = AllottementLetterNo;


        //            int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
        //            int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
        //            string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();



        //            DataSet ds1 = new DataSet();
        //            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

        //            objServiceTimelinesBEL.DocumentID = DocumentID;



        //            ds1 = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
        //            DataTable dtDoc = ds1.Tables[0];
        //            if (dtDoc.Rows.Count > 0)
        //            {
        //                e.Row.FindControl("lbView").Visible = true;
        //                e.Row.FindControl("lbView1").Visible = true;

        //                e.Row.FindControl("lbDelete").Visible = true;
        //            }
        //            else
        //            {
        //                e.Row.FindControl("lbView").Visible = false;
        //                e.Row.FindControl("lbView1").Visible = false;
        //                e.Row.FindControl("lbDelete").Visible = false;
        //            }

        //            LinkButton lnk2 = (LinkButton)e.Row.FindControl("imgdocuments");

        //            if (DocDisable.Text == "Lock")
        //            {

        //                e.Row.FindControl("lbDelete").Visible = false;
        //                lnk2.Visible = false;

        //            }

        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    this.RegisterPostBackControl();
        //    int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
        //    string AllottementLetterNo = "";
        //    try
        //    {
        //        index = Convert.ToInt32(e.CommandArgument);


        //        string[] SerIdarray = ServiceReqNo.Split('/');

        //        AllottementLetterNo = SerIdarray[2];



        //        objServiceTimelinesBEL.UserName = AllottementLetterNo;
        //        Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
        //        Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

        //        string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();






        //        if (e.CommandName == "Upload")
        //        {
        //            LinkButton bts = e.CommandSource as LinkButton;
        //            FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

        //            if (fu.HasFile)
        //            {
        //                string filePath = fu.PostedFile.FileName;
        //                string fleUpload = Path.GetExtension(fu.FileName.ToString());
        //                string filename = Path.GetFileName(filePath);
        //                string contenttype = String.Empty;
        //                switch (fleUpload)
        //                {
        //                    case ".jpg":
        //                        contenttype = "image/jpg";
        //                        break;
        //                    case ".png":
        //                        contenttype = "image/png";
        //                        break;
        //                    case ".gif":
        //                        contenttype = "image/gif";
        //                        break;
        //                    case ".pdf":
        //                        contenttype = "application/pdf";
        //                        break;
        //                }
        //                if (contenttype != String.Empty)
        //                {



        //                    Stream fs = fu.PostedFile.InputStream;
        //                    BinaryReader br = new BinaryReader(fs);


        //                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //                    br.Close();

        //                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //                    objServiceTimelinesBEL.filename = filename;
        //                    objServiceTimelinesBEL.content = contenttype;
        //                    objServiceTimelinesBEL.Uploadfile = bytes;
        //                    objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
        //                    objServiceTimelinesBEL.CreatedDate = DateTime.Now;
        //                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
        //                    objServiceTimelinesBEL.UserName = AllottementLetterNo;
        //                    try
        //                    {
        //                        int retVal;

        //                        retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);


        //                        if (retVal > 0)
        //                        {
        //                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Documents Uploaded");
        //                            if (NMSWP_Result == "SUCCESS")
        //                            {

        //                                string message = "File  Uploaded SucessFully ";
        //                                string script = "window.onload = function(){ alert('";
        //                                script += message;
        //                                script += "')};";
        //                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


        //                                BindServiceCheckListGridViewDocument(hfName.Value);
        //                            }
        //                            else
        //                            {
        //                                string message = "Error Occured while updating status at NMSWP";
        //                                string script = "window.onload = function(){ alert('";
        //                                script += message;
        //                                script += "')};";
        //                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //                                return;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            string message = "File couldn't be  uploaded ";
        //                            string script = "window.onload = function(){ alert('";
        //                            script += message;
        //                            script += "')};";
        //                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //                        }

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //                    }
        //                    finally
        //                    {
        //                        objServiceTimelinesBEL = null;
        //                        objServiceTimelinesBLL = null;
        //                    }

        //                }
        //                else
        //                {
        //                    string message = "Invalid File Format.Please Upload Only pdf/Jpeg/Jpg/Png files Only";
        //                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                string message = "Please Select file Then Upload";
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
        //                return;
        //            }



        //        }
        //        if (e.CommandName == "selectDocument")
        //        {

        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
        //                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;


        //                objServiceTimelinesBEL.DocumentID = DocumentID;



        //                ds = objServiceTimelinesBLL.GetCheckListDocumentAllIAServices(objServiceTimelinesBEL);
        //                DataTable dtDoc1 = ds.Tables[0];

        //                if (dtDoc1.Rows.Count > 0)
        //                {
        //                    download(dtDoc1);
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //            }
        //        }

        //        if (e.CommandName == "ViewDocument")
        //        {
        //            Response.Write("<script>window.open ('DocViewer.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&ServiceId=" + Service_Id + "&ServiceTimeLinesID=" + Service_TimeLine_ID + "&DocumentID=" + DocumentID + "','_blank');</script>");
        //        }

        //        if (e.CommandName == "Delete")
        //        {
        //            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
        //            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
        //            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
        //            objServiceTimelinesBEL.DocumentID = DocumentID;

        //            try
        //            {
        //                int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
        //                if (retVal > 0)
        //                {
        //                    string message = "Checklist Document deleted successfully ";
        //                    string script = "window.onload = function(){ alert('";
        //                    script += message;
        //                    script += "')};";
        //                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //                }
        //                else
        //                {
        //                    string message = "Checklist Document couldn't be deleted";
        //                    string script = "window.onload = function(){ alert('";
        //                    script += message;
        //                    script += "')};";
        //                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
        //    }
        //}
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
                    string message = "Applicant Project Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
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
            #region CodebyManish


            #region Joint Mortgage
            txtSanctionletternumber.Enabled = false;
            txtletterDate.Enabled = false;
            txtAmount.Enabled = false;
            btnBankSave.Enabled = false;
            #endregion
            #region Time extension fees
            ddltef.Enabled = false;
            ddlSelectTimePeriod.Enabled = false;
            txtApplicationDescription.Enabled = false;
            btntimeextension.Enabled = false;
            ddlCovid19.Enabled = false;
            #endregion

            #region Second Charge
            txtSanctionletterno.Enabled = false;
            txtSanctionletterDate.Enabled = false;
            txtPremimAmount.Enabled = false;

            txtInterestAmount.Enabled = false;
            txtAmountFinance.Enabled = false;
            txtBankName.Enabled = false;
            txtBranchName.Enabled = false;
            txtAddress.Enabled = false;
            txtMobileNumber.Enabled = false;
            txtemailID.Enabled = false;
            txtSanctionletternoSecond.Enabled = false;
            txtSanctionletterDatesecond.Enabled = false;

            txtPremimAmountSecond.Enabled = false;
            txtInterestSecond.Enabled = false;
            txtAmountsecond.Enabled = false;
            txtName.Enabled = false;
            txtBranchNamesecond.Enabled = false;
            txtAddresssecond.Enabled = false;
            txtMobileNumbersecond.Enabled = false;

            txtemailIDsecond.Enabled = false;
            Secondcharge.Enabled = false;

            #endregion

            #region Noc mortgage
            txtPremiumAmounts.Enabled = false;
            txtInterestAmounts.Enabled = false;
            txtLetterNo.Enabled = false;

            txtDate.Enabled = false;
            txtLetterFrom.Enabled = false;
            txtAddressBank.Enabled = false;
            txtMobileNumbers.Enabled = false;
            txtemailids.Enabled = false;
            NocMortgage.Enabled = false;

            #endregion

            #region Transfer of Leasedeed

            txtPremiumAmountbank.Enabled = false;
            txtInterestonpremium.Enabled = false;
            txtLeasedeedletter.Enabled = false;

            textletterdate.Enabled = false;
            txtLetterFromleasedeed.Enabled = false;
            txtAddressleasedeed.Enabled = false;
            txtMobileno.Enabled = false;
            txtemailidleasedeed.Enabled = false;

            transferofleasedeed.Enabled = false;

            #endregion

            #region   StartofProduction

            txtProductionStartDate.Enabled = false;
            txtApplicationstartofproductionDescription.Enabled = false;
            btnStartofProduction.Enabled = false;
            #endregion




            #endregion




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

        //private void GetApplicationDetails()
        //{
        //    SqlCommand cmd = new SqlCommand("GetAllotteeDetailsIAService '" + ServiceReqNo + "'", con);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    if (ds.Tables.Count > 0)
        //    {
        //        DataTable dt = ds.Tables[0];

        //        if (dt.Rows.Count > 0)
        //        {

        //            lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
        //            lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
        //            lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
        //            lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
        //            lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
        //            lblAddress.Text = dt.Rows[0]["Address"].ToString();
        //            lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
        //            lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
        //            string Payment = dt.Rows[0]["PaymentStatus"].ToString();
        //            string Objection = dt.Rows[0]["Objection"].ToString();
        //            string Rejected = dt.Rows[0]["Rejected"].ToString();
        //            string Completed = dt.Rows[0]["Completed"].ToString();
        //            string NMSWPFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
        //            string Status = dt.Rows[0]["FinalSubmission"].ToString();



        //            if (Objection == "True")
        //            {
        //                Allotment.ActiveViewIndex = 6;
        //                MenuItemCollection menuItems = sub_menu.Items;
        //                MenuItem menuItem = new MenuItem();
        //                foreach (MenuItem item in menuItems)
        //                {
        //                    if (item.Text == "Final Form")
        //                        menuItem = item;
        //                }
        //                menuItems.Remove(menuItem);

        //            }
        //            else
        //            {
        //                if (NMSWPFee == "Paid")
        //                {
        //                    DocDisable.Text = "Lock";
        //                    DisableAllControl();
        //                }
        //                MenuItemCollection menuItems = sub_menu.Items;
        //                MenuItem menuItem = new MenuItem();
        //                foreach (MenuItem item in menuItems)
        //                {
        //                    if (item.Value == "6")
        //                        menuItem = item;
        //                }
        //                menuItems.Remove(menuItem);
        //            }

        //            if (SWCControlID.Length > 0)
        //            {
        //                if (NMSWPFee == "Paid")
        //                {
        //                    btn_Submit.Text = "Print";
        //                }
        //                else if (NMSWPFee == "Pending")
        //                {
        //                    btn_Submit.Text = "Print";
        //                    DocDisable.Text = "Lock";
        //                    DisableAllControl();
        //                    MenuItemCollection menuItems = sub_menu.Items;
        //                    MenuItem menuItem = new MenuItem();
        //                    foreach (MenuItem item in menuItems)
        //                    {
        //                        if (item.Text == "Final Form")
        //                            menuItem = item;
        //                    }
        //                    menuItems.Remove(menuItem);
        //                }
        //                else
        //                {

        //                    if (Objection == "True")
        //                    {
        //                        Allotment.ActiveViewIndex = 6;
        //                        MenuItemCollection menuItems = sub_menu.Items;
        //                        MenuItem menuItem = new MenuItem();
        //                        foreach (MenuItem item in menuItems)
        //                        {
        //                            if (item.Text == "Final Form")
        //                                menuItem = item;
        //                        }
        //                        menuItems.Remove(menuItem);

        //                        MenuItemCollection menuItems1 = sub_menu.Items;
        //                        MenuItem menuItem1 = new MenuItem();
        //                        foreach (MenuItem item in menuItems1)
        //                        {
        //                            if (item.Text == "Final Submission")
        //                                menuItem1 = item;
        //                        }
        //                        menuItems1.Remove(menuItem1);

        //                    }
        //                    else
        //                    {
        //                        if (Status == "True")
        //                        {
        //                            MenuItemCollection menuItems1 = sub_menu.Items;
        //                            MenuItem menuItem1 = new MenuItem();
        //                            foreach (MenuItem item in menuItems1)
        //                            {
        //                                if (item.Text == "Final Submission")
        //                                    menuItem1 = item;
        //                            }
        //                            menuItems1.Remove(menuItem1);
        //                        }
        //                        else
        //                        {
        //                            DocDisable.Text = "UnLock";
        //                            MenuItemCollection menuItems = sub_menu.Items;
        //                            MenuItem menuItem = new MenuItem();
        //                            foreach (MenuItem item in menuItems)
        //                            {
        //                                if (item.Text == "Final Form")
        //                                    menuItem = item;
        //                            }
        //                            menuItems.Remove(menuItem);
        //                        }
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                if (Payment == "Paid")
        //                {
        //                    btnPay.Text = "Print";
        //                }
        //                else
        //                {
        //                    DocDisable.Text = "UnLock";
        //                    MenuItemCollection menuItems = sub_menu.Items;
        //                    MenuItem menuItem = new MenuItem();
        //                    foreach (MenuItem item in menuItems)
        //                    {
        //                        if (item.Text == "Final Form")
        //                            menuItem = item;
        //                    }
        //                    menuItems.Remove(menuItem);
        //                }
        //            }

        //            if (Rejected == "True")
        //            {
        //                sub_menu.Items.Add(new MenuItem { Value = "8", Text = "Rejection Letter" });
        //            }
        //            if (Completed == "True")
        //            {
        //                sub_menu.Items.Add(new MenuItem { Value = "8", Text = "Approval Letter" });
        //            }


        //        }

        //    }

        //}

        private void GetApplicationDetails()
        {
            try
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
                        lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                        lblindustrialid.Text = dt.Rows[0]["IAID"].ToString();
                        lblplotno.Text = dt.Rows[0]["PlotNo"].ToString();
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
                        string AutoApprovalRejected = dt.Rows[0]["AutoApprovalRejected"].ToString();
                        string AutoApprovalApproved = dt.Rows[0]["AutoApprovalApproved"].ToString();
                        string NMSWPFee = dt.Rows[0]["NMSWPPaymentStatus"].ToString();
                        string Status = dt.Rows[0]["Status"].ToString();
                   
                        if (Objection == "True")
                        {
                            ddltef.Enabled = false;
                            ddlSelectTimePeriod.Enabled = false;
                            txtApplicationDescription.Enabled = false;
                            btntimeextension.Enabled = false;
                            Allotment.ActiveViewIndex = 10;
                            DocDisable.Text = "UnLock";
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
                                if (item.Value == "15")
                                    menuItem1 = item;
                            }
                            menuItems.Remove(menuItem1);

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
                                if (item.Value == "10")
                                    menuItem = item;
                            }
                            menuItems.Remove(menuItem);
                        }

                        if (SWCControlID.Length > 0)
                        {
                            if (NMSWPFee == "Paid")
                            {
                                btn_Submit.Text = "Print";
                                btnPay.Text = "Print";
                                DocDisable.Text = "Lock";
                                DisableAllControl();
                            }
                            else if (NMSWPFee == "Pending")
                            {
                                btn_Submit.Text = "Print";
                                btnPay.Text = "Print";
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
                            }
                            else
                            {

                                if (Objection == "True")
                                {
                                    Allotment.ActiveViewIndex = 10;
                                    MenuItemCollection menuItems = sub_menu.Items;
                                    MenuItem menuItem = new MenuItem();
                                    foreach (MenuItem item in menuItems)
                                    {
                                        if (item.Text == "Final Form")
                                            menuItem = item;
                                    }
                                    menuItems.Remove(menuItem);

                                    MenuItem menuItem1 = new MenuItem();
                                    foreach (MenuItem item in menuItems)
                                    {
                                        if (item.Value == "15")
                                            menuItem1 = item;
                                    }
                                    menuItems.Remove(menuItem1);

                                }
                                else
                                {
                                    if (Status == "True")
                                    {
                                        btnPay.Text = "Print";
                                        MenuItemCollection menuItems = sub_menu.Items;
                                        MenuItem menuItem1 = new MenuItem();
                                        foreach (MenuItem item in menuItems)
                                        {
                                            if (item.Value == "15")
                                                menuItem1 = item;
                                        }
                                        menuItems.Remove(menuItem1);
                                        DocDisable.Text = "Lock";
                                        DisableAllControl();
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
                            sub_menu.Items.Add(new MenuItem { Value = "13", Text = "Rejection Letter" });
                        }
                        if (Completed == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "13", Text = "Approval Letter" });
                        }
                        if (AutoApprovalRejected == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "12", Text = "Rejection Letter" });
                        }
                        if (AutoApprovalApproved == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "12", Text = "Approval Letter" });
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
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

        #region codebymanish

        #region Joint Mortgage

        #region  Bank
        protected void insert_Bank_details(object sender, EventArgs e)
        {


            DataTable dt = (DataTable)ViewState["temp_Bank_details"];

            string BankName = (gridviewBank.FooterRow.FindControl("txtBankName_insert") as TextBox).Text;
            string BranchName = (gridviewBank.FooterRow.FindControl("txtBranchName_insert") as TextBox).Text;
            string Address = (gridviewBank.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string MobileNumber = (gridviewBank.FooterRow.FindControl("txtMobileNumber_insert") as TextBox).Text;
            string email = (gridviewBank.FooterRow.FindControl("txtemail_insert") as TextBox).Text;
            string Percentage = (gridviewBank.FooterRow.FindControl("txtPercentage_insert") as TextBox).Text;
            string Bankstatus = (gridviewBank.FooterRow.FindControl("ddlbankstatus") as DropDownList).SelectedValue.Trim();

            if (Bankstatus == "Lead Bank")
            {


                DataRow[] Row = dt.Select("Bankstatus='Lead Bank'");
                if (Row.Length > 0)
                {
                    MessageBox1.ShowWarning("There should be only one lead bank");
                    return;
                }
            }

            if (BankName != "")
            {
                if (BankName != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Bank Name");
                    return;
                }
                if (BranchName != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide BranchName");
                    return;
                }
                if (Address != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Address");
                    return;
                }
                if (MobileNumber != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide MobileNumber");
                    return;
                }
                if (email != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide email");
                    return;
                }
                if (Percentage != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Percentage");
                    return;
                }
                if (Bankstatus != "")
                {

                }
                else
                {

                    MessageBox1.ShowInfo("Please Provide Lead/Other Bank ");
                    return;
                }


                DataRow dr = dt.NewRow();
                dr["BankName"] = BankName;
                dr["BranchName"] = BranchName;
                dr["Address"] = Address;
                dr["MobileNumber"] = MobileNumber;
                dr["email"] = email;
                dr["Percentage"] = Percentage;
                dr["Bankstatus"] = Bankstatus;

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_Bank_details"] = dt;

                temp_Bank_details_DataBind();
            }
            else
            {

                MessageBox1.ShowInfo("Please Provide  Bank Name");
                return;
            }

        }

        protected void gridviewBank_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Bank_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_Bank_details"] = dt;

            dt.AcceptChanges();


            temp_Bank_details_DataBind();


        }

        #endregion
        public void temp_Bank_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_Bank_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridviewBank.DataSource = dt;
                gridviewBank.DataBind();
                gridviewBank.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridviewBank.DataSource = dt;
                gridviewBank.DataBind();
            }


        }



        protected void btnBankSave_Click(object sender, EventArgs e)
        {
            int retval = 0;

            ///////////////////////   Starting Of Insert   ///////////////////////////// 
            try
            {
                if (ddlpaymentstatus.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please Select outstanding balance is Paid Full or not");
                    return;
                }
                if (ddlpaymentstatus.SelectedValue == "False")
                {
                    MessageBox1.ShowInfo("Please clear outstanding Amount to apply for Joint Mortgage Request");
                    return;
                }
                objServiceTimelinesBEL.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.LetterNo = txtSanctionletternumber.Text.Trim();
                string Date = DateTime.ParseExact(txtletterDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.LetterDate = Date;
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.paidStatus = (ddlpaymentstatus.SelectedValue.ToString());
                retval = objServiceTimelinesBLL.InsertJointMortgageDetails(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    string ServiceRequestNO = ServiceReqNo.Trim();
                    int retVal = 0;
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                    command.Connection = con;
                    command.Transaction = transaction;
                    bool transactionResult = true;
                    DataTable temp = (DataTable)ViewState["temp_Bank_details"];
                    command = new SqlCommand(@"Delete from tbl_JointMortgageBankDetails where ServiceRequestNo='" + ServiceRequestNO + "'", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));

                    if (temp.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in temp.Rows)
                        {
                            //objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(Session["AllotteeID"].ToString());
                            objServiceTimelinesBEL.BankName = (dr1["BankName"].ToString());
                            objServiceTimelinesBEL.BranchName = (dr1["BranchName"].ToString());
                            objServiceTimelinesBEL.Address = (dr1["Address"].ToString());
                            objServiceTimelinesBEL.MobileNumber = (dr1["MobileNumber"].ToString());
                            objServiceTimelinesBEL.Email = (dr1["email"].ToString());
                            objServiceTimelinesBEL.Percentage = Convert.ToInt32(dr1["Percentage"].ToString());
                            objServiceTimelinesBEL.paidStatus = (dr1["Bankstatus"].ToString());
                            objServiceTimelinesBEL.AllotmentLetterno = lblAllotmentLetterNo.Text.Trim();
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                            objServiceTimelinesBEL.MortgageID = "";

                            objServiceTimelinesBEL.IsActive = 1;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            retVal = objServiceTimelinesBLL.InsertBankDetails(objServiceTimelinesBEL);
                        }
                    }
                    if (retVal > 0)
                    {
                        if (transactionResult)
                        {


                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Joint Mortgage Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                            string message = "Joint Mortgage Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                Allotment.ActiveViewIndex = 2;
                            

                            transaction.Commit();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bank detail Updated/Inserted Successfully.');", true);
                            Allotment.ActiveViewIndex = 2;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bank details couldn't be saved');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bank detail Updated/Inserted Successfully.');", true);
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




            ///////////////////////   End Of Insert   ///////////////////////////// 

        }


        private void GetFinalViewJointMortgageDetails()
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
            string ControlID = dt.Rows[0]["ControlId"].ToString();
            string UnitID = dt.Rows[0]["UnitId"].ToString();
            string ServiceID = dt.Rows[0]["ServiceId"].ToString();
            string TraID = dt.Rows[0]["TraID"].ToString();
            UC_ApplicationFinalViewJointMortgageService UC_ApplicationFinalViewJointMortgageService = LoadControl("~/UC_ApplicationFinalViewJointMortgageService.ascx") as UC_ApplicationFinalViewJointMortgageService;
            UC_ApplicationFinalViewJointMortgageService.ID = "UC_ApplicationFinalViewJointMortgageService";
            UC_ApplicationFinalViewJointMortgageService.TranID = TraID;
            UC_ApplicationFinalViewJointMortgageService.ServiceRequestNo = ServiceReqNo;
            UC_ApplicationFinalViewJointMortgageService.ControlID = ControlID;

            PH_FinalView.Controls.Add(UC_ApplicationFinalViewJointMortgageService);

        }

        private void GetJointMortgageDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetJointMortgageDetails(objServiceTimelinesBEL);

                DataTable dt_JointMortgage = ds.Tables[0];
                DataTable dt_JointMortgageBankDetails = ds.Tables[1];

                if (dt_JointMortgage.Rows.Count > 0)
                {
                    ddlpaymentstatus.SelectedValue = dt_JointMortgage.Rows[0]["PaidStatus"].ToString();
                    txtSanctionletternumber.Text = dt_JointMortgage.Rows[0]["Sanctionletterno"].ToString();
                    txtletterDate.Text = dt_JointMortgage.Rows[0]["SanctionletterDate"].ToString();
                    txtAmount.Text = dt_JointMortgage.Rows[0]["Amount"].ToString();

                }
                if (dt_JointMortgageBankDetails.Rows.Count > 0)
                {
                    gridviewBank.DataSource = dt_JointMortgageBankDetails;
                    gridviewBank.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        #endregion

        #region Secondcharge

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
                string ControlID = dt.Rows[0]["ControlId"].ToString();
                string UnitID = dt.Rows[0]["UnitId"].ToString();
                string ServiceID = dt.Rows[0]["ServiceId"].ToString();
                string TraID = dt.Rows[0]["TraID"].ToString();
                string TEFTimeperiod = dt.Rows[0]["TEFTimeperiod"].ToString();
                string PlotNo = dt.Rows[0]["PlotNo"].ToString();

                if (ControlID.Length > 0)
                {
                    if (TypeID == "1002")
                    {
                        UC_IAServiceProcessFee_TEF UC_IAServiceProcessFee_TEF = LoadControl("~/UC_IAServiceProcessFee_TEF.ascx") as UC_IAServiceProcessFee_TEF;
                        UC_IAServiceProcessFee_TEF.IndustrialArea = Convert.ToInt32(IAID);
                        UC_IAServiceProcessFee_TEF.CoveredArea = CoveredArea;
                        UC_IAServiceProcessFee_TEF.AllotmentLetterNo = AllottmentNo;
                        UC_IAServiceProcessFee_TEF.SWCControlID = ControlID;
                        UC_IAServiceProcessFee_TEF.SWCUnitID = UnitID;
                        UC_IAServiceProcessFee_TEF.SWCServiceID = ServiceID;
                        UC_IAServiceProcessFee_TEF.ServiceRequestNo = ServiceReqNo;
                        UC_IAServiceProcessFee_TEF.TranID = TraID;
                        UC_IAServiceProcessFee_TEF.ApplicantName = Applicantname;
                        UC_IAServiceProcessFee_TEF.applicantAddress = Address;
                        UC_IAServiceProcessFee_TEF.PlotSize = decimal.Parse(PlotArea);
                        //UC_IAServiceProcessFee_TEF.TEFTimeperiod = Int32.Parse(TEFTimeperiod);
                        //UC_IAServiceProcessFee_TEF.AllotteeID = Int32.Parse(lblAllotteeID.Text);
                        PlaceHolder1.Controls.Add(UC_IAServiceProcessFee_TEF);
                        PH_FinalView.Controls.Clear();
                    }
                    else
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
                        PlaceHolder1.Controls.Add(UC_IAServiceProcessFeeNMSWP);
                    }
                    

                }
                 else if (TypeID == "1002")
                {
                    UC_IAServiceProcessFee_TEF UC_IAServiceProcessFee_TEF = LoadControl("~/UC_IAServiceProcessFee_TEF.ascx") as UC_IAServiceProcessFee_TEF;
                    UC_IAServiceProcessFee_TEF.IndustrialArea = Convert.ToInt32(IAID);
                    UC_IAServiceProcessFee_TEF.CoveredArea = CoveredArea;
                    UC_IAServiceProcessFee_TEF.AllotmentLetterNo = AllottmentNo;
                    UC_IAServiceProcessFee_TEF.SWCControlID = ControlID;
                    UC_IAServiceProcessFee_TEF.SWCUnitID = UnitID;
                    UC_IAServiceProcessFee_TEF.SWCServiceID = ServiceID;
                    UC_IAServiceProcessFee_TEF.ServiceRequestNo = ServiceReqNo;
                    UC_IAServiceProcessFee_TEF.TranID = TraID;
                    UC_IAServiceProcessFee_TEF.ApplicantName = Applicantname;
                    UC_IAServiceProcessFee_TEF.applicantAddress = Address;
                    UC_IAServiceProcessFee_TEF.PlotSize = decimal.Parse(PlotArea);
                    //UC_IAServiceProcessFee_TEF.TEFTimeperiod = Int32.Parse(TEFTimeperiod);
                    //UC_IAServiceProcessFee_TEF.AllotteeID = Int32.Parse(lblAllotteeID.Text);
                    PlaceHolder1.Controls.Add(UC_IAServiceProcessFee_TEF);
                    PH_FinalView.Controls.Clear();
                }
                else 
                {
                    UC_IAServiceProcessFee UC_IAServiceProcessFee = LoadControl("~/UC_IAServiceProcessFee.ascx") as UC_IAServiceProcessFee;
                    UC_IAServiceProcessFee.IndustrialArea = Convert.ToInt32(IAID);
                    UC_IAServiceProcessFee.choicearea = Convert.ToDouble(PlotArea);
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
                    PH_FinalView.Controls.Clear();
                }




            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
            }

        }
        private void GetFinalViewDetails()
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
            string ControlID = dt.Rows[0]["ControlId"].ToString();
            string UnitID = dt.Rows[0]["UnitId"].ToString();
            string ServiceID = dt.Rows[0]["ServiceId"].ToString();
            string TraID = dt.Rows[0]["TraID"].ToString();
            UC_ApplicationFinalViewSecondchargeService UC_ApplicationFinalViewSecondchargeService = LoadControl("~/UC_ApplicationFinalViewSecondchargeService.ascx") as UC_ApplicationFinalViewSecondchargeService;
            UC_ApplicationFinalViewSecondchargeService.ID = "UC_ApplicationFinalViewSecondchargeService";
            UC_ApplicationFinalViewSecondchargeService.TranID = TraID;
            UC_ApplicationFinalViewSecondchargeService.ServiceRequestNo = ServiceReqNo;
            UC_ApplicationFinalViewSecondchargeService.ControlID = ControlID;

            PH_FinalView.Controls.Add(UC_ApplicationFinalViewSecondchargeService);

        }
        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
        }
        protected void BtnSecondchargeInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int retval = 0;
                if (ddlispaidfull.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please Select outstanding balance is Paid Full or not");
                    return;
                }
                if (ddlispaidfull.SelectedValue == "False")
                {
                    MessageBox1.ShowInfo("Please clear outstanding Amount to apply for Second Charge Request");
                    return;
                }
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.paidStatus = (ddlispaidfull.SelectedValue.ToString());
                objServiceTimelinesBEL.PremimAmount = Convert.ToDecimal(txtPremimAmount.Text.Trim());
                objServiceTimelinesBEL.InterestAmount = Convert.ToDecimal(txtInterestAmount.Text.Trim());
                objServiceTimelinesBEL.PremimAmountSecond = Convert.ToDecimal(txtPremimAmountSecond.Text.Trim());
                objServiceTimelinesBEL.InterestSecond = Convert.ToDecimal(txtInterestSecond.Text.Trim());

                string SanctionletterDatesecond1 = DateTime.ParseExact(txtSanctionletterDatesecond.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                string SanctionletterDate1 = DateTime.ParseExact(txtSanctionletterDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.Sanctionletterno = txtSanctionletterno.Text.Trim();
                objServiceTimelinesBEL.SanctionletternoSecond = txtSanctionletternoSecond.Text.Trim();

                objServiceTimelinesBEL.SanctionletterDatesecond = SanctionletterDatesecond1;
                objServiceTimelinesBEL.SanctionletterDate = SanctionletterDate1;

                objServiceTimelinesBEL.BankNamefirstcharge = txtSanctionletterno.Text.Trim();
                objServiceTimelinesBEL.BankNamefirstcharge = txtSanctionletternoSecond.Text.Trim();
                objServiceTimelinesBEL.Amountfirstcharge = Convert.ToDecimal(txtAmountFinance.Text.Trim());
                objServiceTimelinesBEL.BankNamefirstcharge = txtBankName.Text.Trim();
                objServiceTimelinesBEL.BranchName = txtBranchName.Text.Trim();
                objServiceTimelinesBEL.Address = txtAddress.Text.Trim();
                objServiceTimelinesBEL.AuthorizedSignatoryfirstcharge = txtAuthorizedSignatory1.Text.Trim();
                objServiceTimelinesBEL.MobileNumber = txtMobileNumber.Text.Trim();
                objServiceTimelinesBEL.emailID = txtemailID.Text.Trim();
                objServiceTimelinesBEL.Amountsecond = Convert.ToDecimal(txtAmountsecond.Text.Trim());
                objServiceTimelinesBEL.BankName = txtName.Text.Trim();
                objServiceTimelinesBEL.BranchNamesecond = txtBranchNamesecond.Text.Trim();
                objServiceTimelinesBEL.AuthorizedSignatorysecond = txtAuthorizedSignatory.Text.Trim();
                objServiceTimelinesBEL.Addresssecond = txtAddresssecond.Text.Trim();
                objServiceTimelinesBEL.MobileNumbersecond = txtMobileNumbersecond.Text.Trim();
                objServiceTimelinesBEL.emailIDsecond = txtemailIDsecond.Text.Trim();
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;

                retval = objServiceTimelinesBLL.InsertSecondchargeDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {

                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Second Charge Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                    string message = "Applicant Second Charge Details Saved Successfully";
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

        private void GetSecondchargeDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetSecondchargeDetails(objServiceTimelinesBEL);

                DataTable dt_secondcharge = ds.Tables[0];

                if (dt_secondcharge.Rows.Count > 0)
                {
                    ddlispaidfull.SelectedValue = dt_secondcharge.Rows[0]["PaidStatus"].ToString();
                    txtAmountFinance.Text = dt_secondcharge.Rows[0]["firstAmount"].ToString();
                    txtBankName.Text = dt_secondcharge.Rows[0]["firstNameofbank"].ToString();
                    txtBranchName.Text = dt_secondcharge.Rows[0]["firstBranch"].ToString();
                    txtAuthorizedSignatory1.Text = dt_secondcharge.Rows[0]["AuthorisedSignatory1"].ToString();
                    txtAddress.Text = dt_secondcharge.Rows[0]["firstAddress"].ToString();
                    txtMobileNumber.Text = dt_secondcharge.Rows[0]["firstMobileNo"].ToString();
                    txtemailID.Text = dt_secondcharge.Rows[0]["firstemailid"].ToString();
                    txtAmountsecond.Text = dt_secondcharge.Rows[0]["secondAmount"].ToString();
                    txtName.Text = dt_secondcharge.Rows[0]["secondNameofbank"].ToString();
                    txtBranchNamesecond.Text = dt_secondcharge.Rows[0]["secondBranch"].ToString();
                    txtAuthorizedSignatory.Text = dt_secondcharge.Rows[0]["AuthorisedSignatory"].ToString();
                    txtAddresssecond.Text = dt_secondcharge.Rows[0]["secondAddress"].ToString();
                    txtMobileNumbersecond.Text = dt_secondcharge.Rows[0]["secondMobileNo"].ToString();
                    txtemailIDsecond.Text = dt_secondcharge.Rows[0]["secondemailid"].ToString();
                    txtPremimAmount.Text = dt_secondcharge.Rows[0]["PremimAmount"].ToString();
                    txtInterestAmount.Text = dt_secondcharge.Rows[0]["InterestAmount"].ToString();
                    txtPremimAmountSecond.Text = dt_secondcharge.Rows[0]["PremimAmountSecond"].ToString();
                    txtInterestSecond.Text = dt_secondcharge.Rows[0]["InterestSecond"].ToString();

                    txtSanctionletterno.Text = dt_secondcharge.Rows[0]["Sanctionletterno"].ToString();
                    txtSanctionletterDate.Text = dt_secondcharge.Rows[0]["SanctionletterDate"].ToString();
                    txtSanctionletterDatesecond.Text = dt_secondcharge.Rows[0]["SanctionletterDatesecond"].ToString();
                    txtSanctionletternoSecond.Text = dt_secondcharge.Rows[0]["SanctionletternoSecond"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        #endregion

        #region Noc for Mortgage
        private void GetFinalViewNocMortgageDetails()
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
            string ControlID = dt.Rows[0]["ControlId"].ToString();
            string UnitID = dt.Rows[0]["UnitId"].ToString();
            string ServiceID = dt.Rows[0]["ServiceId"].ToString();
            string TraID = dt.Rows[0]["TraID"].ToString();
            UC_ApplicationFinalViewNocMortgageService UC_ApplicationFinalViewNocMortgageService = LoadControl("~/UC_ApplicationFinalViewNocMortgageService.ascx") as UC_ApplicationFinalViewNocMortgageService;
            UC_ApplicationFinalViewNocMortgageService.ID = "UC_ApplicationFinalViewNocMortgageService";
            UC_ApplicationFinalViewNocMortgageService.TranID = TraID;
            UC_ApplicationFinalViewNocMortgageService.ServiceRequestNo = ServiceReqNo;
            UC_ApplicationFinalViewNocMortgageService.ControlID = ControlID;

            PH_FinalView.Controls.Add(UC_ApplicationFinalViewNocMortgageService);

        }
        protected void BtnNocMortgageInsert_Click(object sender, EventArgs e)
        {
            if (ddlpaidnocmortgage.SelectedIndex == 0)
            {
                MessageBox1.ShowInfo("Please Select outstanding balance is Paid Full or not");
                return;
            }
            if (ddlpaidnocmortgage.SelectedValue == "False")
            {
                MessageBox1.ShowInfo("Please clear outstanding Amount to apply for NOC Mortgage Request");
                return;
            }
            if (txtPremiumAmounts.Text.Length <= 0)
            {
                MessageBox1.ShowError("Please Enter Premium Amount bank agreed to pay");
                return;
            }
            try
            {

                int retval = 0;
                objServiceTimelinesBEL.PremimAmount = Convert.ToDecimal(txtPremiumAmounts.Text.Trim());
                objServiceTimelinesBEL.InterestAmount = Convert.ToDecimal(txtInterestAmounts.Text.Trim());
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.LetterNo = txtLetterNo.Text.Trim();
                string LetterDate = DateTime.ParseExact(txtDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.LetterDate = LetterDate;
                objServiceTimelinesBEL.LetterFrom = txtLetterFrom.Text.Trim();
                objServiceTimelinesBEL.AddressBank = txtAddressBank.Text.Trim();
                objServiceTimelinesBEL.MobileNumbers = txtMobileNumbers.Text.Trim();
                objServiceTimelinesBEL.emailids = txtemailids.Text.Trim();
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                objServiceTimelinesBEL.NocBankName = txtNocBankName.Text.Trim();
                objServiceTimelinesBEL.NocBranchName = txtNocBranchName.Text.Trim();
                objServiceTimelinesBEL.paidStatus = (ddlpaidnocmortgage.SelectedValue.ToString());
                retval = objServiceTimelinesBLL.InsertNocMortgageDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Noc Mortgage Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                        string message = "Applicant Noc Mortgage Details Saved Successfully";
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

        private void GetNocMortgageDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetNocMortgageDetails(objServiceTimelinesBEL);

                DataTable dt_NocMortgage = ds.Tables[0];

                if (dt_NocMortgage.Rows.Count > 0)
                {
                    txtLetterNo.Text = dt_NocMortgage.Rows[0]["LetterNo"].ToString();
                    txtDate.Text = dt_NocMortgage.Rows[0]["LetterDate"].ToString();
                    txtLetterFrom.Text = dt_NocMortgage.Rows[0]["LetterFrom"].ToString();
                    txtAddressBank.Text = dt_NocMortgage.Rows[0]["LetterAddress"].ToString();
                    txtMobileNumbers.Text = dt_NocMortgage.Rows[0]["MobileNo"].ToString();
                    txtemailids.Text = dt_NocMortgage.Rows[0]["emailid"].ToString();
                    txtPremiumAmounts.Text = dt_NocMortgage.Rows[0]["PremimAmount"].ToString();
                    txtInterestAmounts.Text = dt_NocMortgage.Rows[0]["InterestAmount"].ToString();
                    ddlpaidnocmortgage.SelectedValue = dt_NocMortgage.Rows[0]["PaidStatus"].ToString();
                    txtNocBankName.Text = dt_NocMortgage.Rows[0]["BankName"].ToString();
                    txtNocBranchName.Text = dt_NocMortgage.Rows[0]["BranchName"].ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        #endregion

        #region Transfer of Lease deed to Financial Institution

        private void GetFinalViewtransferofleasedeedDetails()
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
            string ControlID = dt.Rows[0]["ControlId"].ToString();
            string UnitID = dt.Rows[0]["UnitId"].ToString();
            string ServiceID = dt.Rows[0]["ServiceId"].ToString();
            string TraID = dt.Rows[0]["TraID"].ToString();
            UC_ApplicationFinalViewtransferofleasedeedService UC_ApplicationFinalViewtransferofleasedeedService = LoadControl("~/UC_ApplicationFinalViewtransferofleasedeedService.ascx") as UC_ApplicationFinalViewtransferofleasedeedService;
            UC_ApplicationFinalViewtransferofleasedeedService.ID = "UC_ApplicationFinalViewtransferofleasedeedService";
            UC_ApplicationFinalViewtransferofleasedeedService.TranID = TraID;
            UC_ApplicationFinalViewtransferofleasedeedService.ServiceRequestNo = ServiceReqNo;
            UC_ApplicationFinalViewtransferofleasedeedService.ControlID = ControlID;

            PH_FinalView.Controls.Add(UC_ApplicationFinalViewtransferofleasedeedService);

        }

        protected void BtntransferofleasedeedInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlispaidTransferofLeasedeed.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("Please Select outstanding balance is Paid Full or not");
                    return;
                }
                if (ddlispaidTransferofLeasedeed.SelectedValue == "False")
                {
                    MessageBox1.ShowInfo("Please clear outstanding Amount to apply for Transfer of Leasedeed Request");
                    return;
                }
                int retval = 0;
                objServiceTimelinesBEL.paidStatus = (ddlispaidTransferofLeasedeed.SelectedValue.ToString());
                objServiceTimelinesBEL.BankName = txtBankNameFI.Text.Trim();
                objServiceTimelinesBEL.BranchName = txtBranchNameFI.Text.Trim();
                objServiceTimelinesBEL.PremimAmount = Convert.ToDecimal(txtPremiumAmountbank.Text.Trim());
                objServiceTimelinesBEL.InterestAmount = Convert.ToDecimal(txtInterestonpremium.Text.Trim());
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.LetterNo = txtLeasedeedletter.Text.Trim();
                string LetterDate = DateTime.ParseExact(textletterdate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.LetterDate = LetterDate;
                objServiceTimelinesBEL.LetterFromleasedeed = txtLetterFromleasedeed.Text.Trim();
                objServiceTimelinesBEL.BankAddress = txtAddressleasedeed.Text.Trim();
                objServiceTimelinesBEL.MobileNo = txtMobileno.Text.Trim();
                objServiceTimelinesBEL.emailids = txtemailidleasedeed.Text.Trim();
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;

                retval = objServiceTimelinesBLL.InserttransferofleasedeedDetails(objServiceTimelinesBEL);
                if (retval > 0)
                {

                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Transfer of lease deed Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                    string message = "Applicant transfer of lease deed Details Saved Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                  
                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        private void GettransferofleasedeedDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GettransferofleasedeedDetails(objServiceTimelinesBEL);

                DataTable dt_transferofleasedeed = ds.Tables[0];

                if (dt_transferofleasedeed.Rows.Count > 0)
                {
                    ddlispaidTransferofLeasedeed.SelectedValue = dt_transferofleasedeed.Rows[0]["PaidStatus"].ToString();
                    txtLeasedeedletter.Text = dt_transferofleasedeed.Rows[0]["leasedeedLetterNo"].ToString();
                    textletterdate.Text = dt_transferofleasedeed.Rows[0]["leasedeedLetterDate"].ToString();
                    txtBankNameFI.Text = dt_transferofleasedeed.Rows[0]["BankName"].ToString();
                    txtBranchNameFI.Text = dt_transferofleasedeed.Rows[0]["BranchName"].ToString();
                    txtLetterFromleasedeed.Text = dt_transferofleasedeed.Rows[0]["leasedeedLetterFrom"].ToString();
                    txtAddressleasedeed.Text = dt_transferofleasedeed.Rows[0]["leasedeedLetterAddress"].ToString();
                    txtMobileno.Text = dt_transferofleasedeed.Rows[0]["MobileNo"].ToString();
                    txtemailidleasedeed.Text = dt_transferofleasedeed.Rows[0]["emailid"].ToString();
                    txtPremiumAmountbank.Text = dt_transferofleasedeed.Rows[0]["PremimAmount"].ToString();
                    txtInterestonpremium.Text = dt_transferofleasedeed.Rows[0]["InterestAmount"].ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        #endregion

        #region NewService
        private void downloadApplicantDoc(DataTable dt)
        {

            Byte[] bytes = (Byte[])dt.Rows[0]["ApplicantDoc"];

            HttpResponse Response = Context.Response;
            Response.Clear();
            Response.ClearContent();    // Add this line
            Response.ClearHeaders();
            Response.ContentType = dt.Rows[0]["ApplicantDocContent"].ToString().Trim();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["ApplicantDocName"].ToString());
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1000);
            Response.Flush();


        }

        #region Start of Production Certificate 
        private void GetFinalViewStartofProductionCertificateDetails()
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
            string ControlID = dt.Rows[0]["ControlId"].ToString();
            string UnitID = dt.Rows[0]["UnitId"].ToString();
            string ServiceID = dt.Rows[0]["ServiceId"].ToString();
            string TraID = dt.Rows[0]["TraID"].ToString();
            UC_ApplicationFinalViewStartofProductionCertificate UC_ApplicationFinalViewStartofProductionCertificate = LoadControl("~/UC_ApplicationFinalViewStartofProductionCertificate.ascx") as UC_ApplicationFinalViewStartofProductionCertificate;
            UC_ApplicationFinalViewStartofProductionCertificate.ID = "UC_ApplicationFinalViewStartofProductionCertificate";
            UC_ApplicationFinalViewStartofProductionCertificate.TranID = TraID;
            UC_ApplicationFinalViewStartofProductionCertificate.ServiceRequestNo = ServiceReqNo;
            UC_ApplicationFinalViewStartofProductionCertificate.ControlID = ControlID;
            PH_FinalView.Controls.Add(UC_ApplicationFinalViewStartofProductionCertificate);

        }
        protected void BtnStartofProductiondInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtApplicationstartofproductionDescription.Text.Length <= 0)
                {
                    MessageBox1.ShowError("Please Enter Application Description");
                    return;
                }
                int retval = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                string str = txtApplicationstartofproductionDescription.Text.Trim();
                string str2 = Server.HtmlDecode(str);
                objServiceTimelinesBEL.ApplicationPlotCancelationDescription = str2;
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                string ProductionStartDate = DateTime.ParseExact(txtProductionStartDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                objServiceTimelinesBEL.ProductionstartDate = ProductionStartDate;
                objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
                retval = objServiceTimelinesBLL.InsertStartofProductionDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {

                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Start of Production Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");

                    string message = "Applicant Start of Production Details Saved Successfully";
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

        private void GetStartofProductionDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetStartofProductionDetails(objServiceTimelinesBEL);

                DataTable dt_timeextensionfee = ds.Tables[0];
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    txtApplicationstartofproductionDescription.Text = dt_timeextensionfee.Rows[0]["description"].ToString();
                    txtProductionStartDate.Text = dt_timeextensionfee.Rows[0]["ProductionstartDate"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }
        #endregion


        #region Plot Cancelation
        public void bindNoticeManu()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.Get_NoticeWithAllottee(ServiceReqNo);
                if (dsR.Tables.Count > 0)
                {
                    sub_menu.Items.Add(new MenuItem { Value = "15", Text = "<span style='color:red'>View Notice&Reply</span>" });
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Value == "3")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItemCollection menuItems1 = sub_menu.Items;
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Value == "2")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    //MenuItemCollection menuItems1 = sub_menu.Items;
                    //MenuItem menuItem1 = new MenuItem();
                    //foreach (MenuItem item in menuItems)
                    //{
                    //    if (item.Value == "2")
                    //        menuItem1 = item;
                    //}
                    //menuItems.Remove(menuItem1);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }

        public void Get_Notice_of_service()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.Get_NoticeWithAllottee(ServiceReqNo);
                DataTable dt_timeextensionfee = dsR.Tables[0];
                DataTable dt_PriviousNotice = dsR.Tables[1];
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    divreply.Visible = true;
                    CKEditorControl_PlotCancelation.Text = dt_timeextensionfee.Rows[0]["NoticeReplyDetails"].ToString();
                    txtNoticeID.Text = dt_timeextensionfee.Rows[0]["NoticeID"].ToString();
                    txtServiceRequestNO.Text = dt_timeextensionfee.Rows[0]["ServiceRequestNo"].ToString();
                    txtNoticeDescription.Text = dt_timeextensionfee.Rows[0]["AppointmentDesc"].ToString();
                    txtNoticeType.Text = dt_timeextensionfee.Rows[0]["Noticetype"].ToString();
                }
                if (dt_PriviousNotice.Rows.Count > 0)
                {
                    gvNotice.DataSource = dt_PriviousNotice;
                    gvNotice.DataBind();

                }
                else
                {
                    gvNotice.DataSource = null;
                    gvNotice.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured -A :" + ex.Message.ToString());
            }
        }

        protected void gvNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = ((Label)e.Row.FindControl("lblNoticeID")).Text.ToString();
                    ds1 = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        if (dtDoc.Rows[0]["ApplicantDocName"].ToString() == "" || dtDoc.Rows[0]["ApplicantDocName"].ToString() == null)
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = false;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lblApplicantDoc").Visible = true;
                            e.Row.FindControl("lbApplicantDocdownload").Visible = true;
                        }

                        if (dtDoc.Rows[0]["DocName"].ToString() == "" || dtDoc.Rows[0]["DocName"].ToString() == null)
                        {
                            e.Row.FindControl("lbView").Visible = false;
                            e.Row.FindControl("lbView1").Visible = false;
                        }
                        else
                        {
                            e.Row.FindControl("lbView").Visible = true;
                            e.Row.FindControl("lbView1").Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }


        }

        protected void gvNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int index = Convert.ToInt32(e.CommandArgument);
            index = index % gvNotice.PageSize;
            string SerReqNo = gvNotice.DataKeys[index].Values[0].ToString();
            string NoticeID = gvNotice.DataKeys[index].Values[1].ToString();
            if (e.CommandName == "ViewDocument")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_Notice.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
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
            if (e.CommandName == "ViewDocumentApplicant")
            {
                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);

                DataTable dtDoc = ds.Tables[0];

                if (dtDoc.Rows.Count > 0)
                {

                    string contype = dtDoc.Rows[0]["ApplicantDocContent"].ToString().Trim();

                    string embed = @"<br/><object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%"" height=""500px"">
                If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
                 or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
                </object><br/>";

                    ltviewer.Text = string.Format(embed, ResolveUrl("/Viewer_NoticeApplicantDoc.ashx?ServiceRequestNO=" + SerReqNo.Trim() + "&NoticeID=" + NoticeID.Trim() + ""));
                }
            }
            if (e.CommandName == "selectDocumentApplicant")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceRequestNO = SerReqNo.Trim();
                    objServiceTimelinesBEL.NoticeID = NoticeID.Trim();
                    ds = objServiceTimelinesBLL.ViewSignedCopyNotice(objServiceTimelinesBEL);
                    DataTable dtDoc1 = ds.Tables[0];

                    if (dtDoc1.Rows.Count > 0)
                    {
                        downloadApplicantDoc(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
            }
        }

        protected void BtnPlotCancelationInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (CKEditorControl_PlotCancelation.Text.Length <= 0)
                {
                    MessageBox1.ShowError("Please Enter Application Description");
                    return;
                }
                int retval = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                string str = CKEditorControl_PlotCancelation.Text.Trim();
                string str2 = Server.HtmlDecode(str);
                objServiceTimelinesBEL.ApplicationPlotCancelationDescription = str2;
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;
                objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
                objServiceTimelinesBEL.Uploadfile = (Session["File"]) as byte[];
                objServiceTimelinesBEL.content = Convert.ToString(Session["FileExt"]);
                objServiceTimelinesBEL.filename = Convert.ToString(Session["FileName"]);
                objServiceTimelinesBEL.NoticeID = txtNoticeID.Text;

                retval = objServiceTimelinesBLL.InsertPlotCancelationDetails(objServiceTimelinesBEL);
                if (retval > 0)
                {
                    Session["File"] = "";
                    Session["FileExt"] = "";
                    Session["FileName"] = "";
                    lbluploadingMsg.Visible = false;
                    string message = "Applicant Plot Cancelation  Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Get_Notice_of_service();
                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        private void GetPlotCancelationDetails()
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.PlotCancelationApplicantDetails(objServiceTimelinesBEL);

                DataTable dt_timeextensionfee = ds.Tables[0];
                if (dt_timeextensionfee.Rows.Count > 0)
                {
                    CKEditorControl_PlotCancelation.Text = dt_timeextensionfee.Rows[0]["description"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void imgdocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                int retval = 0;
                if (FileUpload4.HasFile)
                {
                    string filePath = FileUpload4.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUpload4.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                        case ".pdf":
                            contenttype = "application/pdf";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = FileUpload4.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        Session["File"] = objServiceTimelinesBEL.Uploadfile;
                        Session["FileName"] = objServiceTimelinesBEL.filename;
                        Session["FileExt"] = objServiceTimelinesBEL.content;
                        lbluploadingMsg.Text = "File uploaded Successfully";
                        lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                        lbluploadingMsg.Visible = true;
                    }
                    else
                    {
                        MessageBox1.ShowError("Invalid File Format");
                        return;
                    }
                }
                else
                {
                    MessageBox1.ShowError("Please Upload Plot Tracing");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }

        protected void bttnTracing_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from [tbl_NoticeStatusMaster] where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dtDoc = new DataTable();
            adp.Fill(dtDoc);

            if (dtDoc.Rows.Count > 0)
            {
                if (dtDoc.Rows[0]["PlotTracing"].ToString().Length > 0)
                {

                    String js = "window.open('DocViewerLease.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "&Type=1', '_blank');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerLease.aspx", js, true);
                }
                else
                {
                    MessageBox1.ShowError("Plot Tracing Not Uploaded Yet");
                }
            }
        }
        #endregion



        #endregion

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
                SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocumentsforIAModule '" + ServiceReqNo.Trim() + "'", con);
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

                        if (TypeID == "1005")
                        {
                            Message = "Noc for Mortgage details are Mandatory";
                        }
                        if (TypeID == "1006")
                        {
                            Message = "Joint Mortgage details are Mandatory";
                        }
                        if (TypeID == "1007")
                        {
                            Message = "Second Charges are Mandatory";
                        }
                        if (TypeID == "1011")
                        {
                            Message = "Transfer of leasedeed are Mandatory";
                        }
                        if (TypeID == "1002")
                        {
                            Message = "Time extenstion fees are Mandatory";
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

                            if (TypeID == "1005")
                            {
                                Message = "Noc for Mortgage details are Mandatory";
                            }
                            if (TypeID == "1006")
                            {
                                Message = "Joint Mortgage details are Mandatory";
                            }
                            if (TypeID == "1007")
                            {
                                Message = "Second Charges are Mandatory";
                            }
                            if (TypeID == "1011")
                            {
                                Message = "Transfer of leasedeed are Mandatory";
                            }
                            if (TypeID == "1002")
                            {
                                Message = "Time extenstion fees are Mandatory";
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
                            case "1005":
                                Count1 = 1;
                                break;
                            case "1006":
                                Count1 = 1;
                                break;
                            case "1007":
                                Count1 = 1;
                                break;
                            case "1011":
                                Count1 = 1;
                                break;
                            case "1002":
                                Count1 = 2;
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
                dsR = objServiceTimelinesBLL.GetapplicableChargesforTEF(objServiceTimelinesBEL);

                if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                if (dt_Fee.Rows.Count > 0)
                {
                    try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }
                    gm = new GeneralMethod();
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
                                    string Message = "Request is submitted successfully. Kindly pay amount from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetApplicationDetails();
                                    GetPaymentDetails();
                                    return;
                                }
                                else
                                {
                                    string Message = "Request is submitted successfully. Kindly pay amount from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetApplicationDetails();
                                    GetPaymentDetails();
                                    return;
                                }

                            }
                            else
                            {
                                string Message = "Error At NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                                return;
                            }
                        }
                        else
                        {
                            string Message = "Error Occurred";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);

                            return;
                        }

                    }
                    else
                    {
                        string Message = "Amount is null";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                        return;
                    }
                }
            }
            

        }
        #endregion

        #region NiveshMitra
        protected void Confirm_CheckBox_final(object sender, EventArgs e)
        {
            if (CheckBox_Final.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
            {
                btn_Submit.Enabled = false;
            }


        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            if (CheckBox_Final.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
            {
                MessageBox1.ShowWarning("First Check The CheckBox at the bottom");
                return;
            }
            int Count1 = 0;
            SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocumentsforIAModule '" + ServiceReqNo.Trim() + "'", con);
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

                    if (TypeID == "1005")
                    {
                        Message = "Noc for Mortgage details are Mandatory";
                    }
                    if (TypeID == "1006")
                    {
                        Message = "Joint Mortgage details are Mandatory";
                    }
                    if (TypeID == "1007")
                    {
                        Message = "Second Charges are Mandatory";
                    }
                    if (TypeID == "1011")
                    {
                        Message = "Transfer of leasedeed are Mandatory";
                    }
                    if (TypeID == "1002")
                    {
                        Message = "Time extenstion fees are Mandatory";
                    }
                    if (TypeID == "1014")
                    {
                        Message = "Start of Production fees are Mandatory";
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

                        if (TypeID == "1005")
                        {
                            Message = "Noc for Mortgage details are Mandatory";
                        }
                        if (TypeID == "1006")
                        {
                            Message = "Joint Mortgage details are Mandatory";
                        }
                        if (TypeID == "1007")
                        {
                            Message = "Second Charges are Mandatory";
                        }
                        if (TypeID == "1011")
                        {
                            Message = "Transfer of leasedeed are Mandatory";
                        }
                        if (TypeID == "1002")
                        {
                            Message = "Time extenstion fees are Mandatory";
                        }
                        if (TypeID == "1014")
                        {
                            Message = "Start of Production Details are Mandatory";
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
                        case "1005":
                            Count1 = 1;
                            break;
                        case "1006":
                            //SUNIL KUMAR - Initiall it is 4 but change it to 3 because no of documents required are 3
                            Count1 = 3;
                            //SUNIL KUMAR
                            break;
                        case "1007":
                            Count1 = 3;
                            break;
                        case "1011":
                            Count1 = 2;
                            break;
                        case "1002":
                            Count1 = 2;
                            break;
                        case "1014":
                            Count1 = 5;
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
            int result = 0;
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
            result = objServiceTimelinesBLL.SetServiceRequestFinish_IAService(objServiceTimelinesBEL);
            if (result > 0)
            {
                string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "13", "Applicant Submits the Form to | DA " + lblIndustrialArea.Text, SWCRequest_ID, "DA " + lblIndustrialArea.Text, "");
                if (NMSWP_Result == "SUCCESS")
                {
                    //string message = "Application Submitted  Successfully";
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    //if (TypeID == "1005")
                    //{
                    //    GetFinalViewNocMortgageDetails();
                    //}
                    //if (TypeID == "1007")
                    //{
                    //    GetFinalViewDetails();
                    //}
                    //if (TypeID == "1006")
                    //{
                    //    GetFinalViewJointMortgageDetails();
                    //}
                    //if (TypeID == "1011")
                    //{
                    //    GetFinalViewtransferofleasedeedDetails();
                    //}
                    //if (TypeID == "1002")
                    //{
                    //    GetFinalViewtimeextensionDetails();
                    //}
                    //if (TypeID == "1014")
                    //{
                    //    GetFinalViewStartofProductionCertificateDetails();
                    //}

                    //GetApplicationDetails();
                    //Page_Load(null,null);
                    //Allotment.ActiveViewIndex = 4;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "FinalMsg('" + ServiceReqNo + "');", true);
                }
                else
                {
                    string message = "Error occured while updtiong status at NMSWP";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            else
            {
                string message = "Error occured while updtiong status at NMSWP";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                return;
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


        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            try
            {


                string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
                string UnitID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
                string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
                string DeptID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
                string PassSalt = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
                NameValueCollection collections = new NameValueCollection();
                collections.Add("Dept_Code", DeptID.Trim());
                collections.Add("ControlID", ControlID.Trim());
                collections.Add("UnitID", UnitID.Trim());
                collections.Add("ServiceID", ServiceID.Trim());
                collections.Add("PassSalt", PassSalt.Trim());

                string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

      
    }
}