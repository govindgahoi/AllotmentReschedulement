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
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Allotment
{
    public partial class IAReconstitutionApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string ServiceReqNo;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;
        string TypeID;
        SqlConnection con;

        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";

        string ProcessIndustryID = "";
        string ApplicationID = "";
        string passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
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


        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        public string checklistid { get; set; }

        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";

        GeneralMethod gm = new GeneralMethod();
        //public string h { get; set; }
       

        string AllotteeId = "";
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Enctype = "multipart/form-data";
            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(sub_menu);
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Request.QueryString["ServiceReqNo"];
                string[] SerIdarray = ServiceReqNo.Split('/');
                TypeID = SerIdarray[1].ToString();

                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID    = NMSWP.Rows[0][0].ToString();
                SWCUnitID       = NMSWP.Rows[0][1].ToString();
                SWCServiceID    = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID   = NMSWP.Rows[0][3].ToString();
                if (SWCControlID.Length > 0)
                {
                    if (TypeID == "1008" || TypeID == "1021")
                    {
                        CheckNMSWPFeePaid();
                    }
                }


                PH_AllotteeDetails.Controls.Clear();
                RegisterPostBackControl();
                UC_Service_Allotteee_Details_IA_Services UC_Service_Allotteee_Details_IA_Services = LoadControl("~/UC_Service_Allotteee_Details_IA_Services.ascx") as UC_Service_Allotteee_Details_IA_Services;
                UC_Service_Allotteee_Details_IA_Services.ID = "UC_Service_Allotteee_Details_IA_Services";
                UC_Service_Allotteee_Details_IA_Services.AllotteeId = SerIdarray[2];
                PH_AllotteeDetails.Controls.Add(UC_Service_Allotteee_Details_IA_Services);
                AllotteeId = SerIdarray[2];
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

                    DataTable temp_shareholder_details = new DataTable();
                    temp_shareholder_details.TableName = "temp_shareholder_details";
                    temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_shareholder_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_shareholder_details"] = temp_shareholder_details;
                    temp_shareholder_details_DataBind();


                    DataTable temp_trustee_details = new DataTable();
                    temp_trustee_details.TableName = "temp_trustee_details";
                    temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_trustee_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_trustee_details"] = temp_trustee_details;
                    temp_trustee_details_DataBind();


                    DataTable temp_directors_details = new DataTable();
                    temp_directors_details.TableName = "temp_directors_details";
                    temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_directors_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_directors_details"] = temp_directors_details;
                    temp_director_details_DataBind();


                    DataTable temp_partnership_details = new DataTable();
                    temp_partnership_details.TableName = "temp_partnership_details";
                    temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                    temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Email", typeof(string)));
                    temp_partnership_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                    ViewState["temp_partnership_details"] = temp_partnership_details;
                    temp_partnership_details_DataBind();
                    temp_partnership_details_DataBind();
                    bindCompanytypeddl();
                   
                    if (TypeID == "1017")
                    {
                        lblFormName.Text = "Request for hand over of lease deed to lease";
                        HandoverDetails();
                    }
                    if (TypeID == "1021")
                    {
                        lblFormName.Text = "Request Recognition  of legal heir after death";
                        GetReconsitiutionApplicationDetails();
                    }
                    if (TypeID == "1008")
                    {                           
                           lblFormName.Text = "Application Form Reconstitution allotte firm / company";
                        GetReconsitiutionApplicationDetails();
                    }
                    //if (TypeID == "1022")
                    //{
                    //    lblFormName.Text = "Request for Water Connection";
                    //}
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;

                    }

                    BindServiceCheckListGridViewDocument(hfName.Value);

                    if (TypeID == "1017")
                    {
                        if (CheckBox_Final.Checked == true)
                        {
                            btn_Submit.Enabled = true;
                        }
                        else
                        {
                            btn_Submit.Enabled = false;
                        }
                      //  GetPaymentDetails();
                      
                    }
                    if (TypeID == "1008")
                    {
                        GetPaymentDetails();
                        

                    }
                    if (TypeID == "1021")
                    {
                        GetPaymentDetails();
                      

                    }
                   
                    GetApplicationDetails();
                    GetPaymentDetails();


                }
                if (SWCControlID.Length > 0)
                {
                    btn_SubmitWithoutFees.Visible = true;
                    btn_Submit.Visible = true;
                    btnPay.Visible = false;
                }
                else
                {
                    btn_SubmitWithoutFees.Visible = true;
                    btn_Submit.Visible = false;
                    btnPay.Visible = true;
                }
                BindObjection();
                if (TypeID == "1008")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Application of leasse deed")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        
                           if (item.Text == "Recognition for legal heir")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);

                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Final Submission")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);


                }
                if (TypeID == "1017")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Reconstitution Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Recognition for legal heir")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Payment Details")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();


                }
                if (TypeID == "1021")
                {
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Reconstitution Details")
                            menuItem = item;
                    }
                    menuItems.Remove(menuItem);
                    MenuItem menuItem1 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Application of leasse deed")
                            menuItem1 = item;
                    }
                    menuItems.Remove(menuItem1);
                    MenuItem menuItem2 = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text == "Final Submission")
                            menuItem2 = item;
                    }
                    menuItems.Remove(menuItem2);
                    MenuItem menuItem3 = new MenuItem();


                }
               
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                Response.Write("Oops! error occured-v :" + line.ToString());
            }
        }
        private void GetFinalViewhandoverofleasedeedtoleaseDetails()
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
            UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService = LoadControl("~/UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ascx") as UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService;
            UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ID = "UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService";
            UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.TranID = TraID;
            UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ControlID = UnitID;
            UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ServiceRequestNo = ServiceReqNo;

            PH_FinalView.Controls.Add(UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService);

        }
        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveDemandPlusObjection UC_ResolveDemandPlusObjection = LoadControl("~/UC_ResolveDemandPlusObjection.ascx") as UC_ResolveDemandPlusObjection;
            UC_ResolveDemandPlusObjection.ID = "UC_ResolveDemandPlusObjection";
            UC_ResolveDemandPlusObjection.ServiceReqNo = ServiceReqNo;
          PH_Objection.Controls.Add(UC_ResolveDemandPlusObjection);
        }
        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)
        {

            hfName.Value = asdf;

            ViewState["BY_Condtion_Function"] = hfName.Value;
            BY_SET_Condtion_Function = hfName.Value;

            BindServiceCheckListGridViewDocument(hfName.Value);
        }
        public void temp_shareholder_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
                gridshareholder.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
            }


        }
        public void temp_partnership_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
                PartnershipFirmGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
            }


        }

        public void temp_trustee_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
                Trustee_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
            }


        }

        public void temp_director_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
                DirectorsGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
            }


        }


        protected void insert_shareholder_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];


            string shareholdername = (gridshareholder.FooterRow.FindControl("txtShareholderName_insert") as TextBox).Text;
            string shareper = (gridshareholder.FooterRow.FindControl("txtShareper_insert") as TextBox).Text;
            string address = (gridshareholder.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string email = (gridshareholder.FooterRow.FindControl("txtEmail_insert") as TextBox).Text;
            string phone = (gridshareholder.FooterRow.FindControl("txtPhone_insert") as TextBox).Text;


            if (shareholdername != "")
            {
                if (shareper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ShareHolderName"] = shareholdername;
                    dr["SharePer"] = shareper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_shareholder_details"] = dt;

                    temp_shareholder_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide ShareHolder Name');", true);
                return;
            }

        }

        protected void insert_Partnership_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];


            string Partnershipname = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert") as TextBox).Text;
            string partnershipper = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert") as TextBox).Text;
            string address = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert") as TextBox).Text;
            string email = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert") as TextBox).Text;
            string phone = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert") as TextBox).Text;


            if (Partnershipname != "")
            {
                

                    DataRow dr = dt.NewRow();
                    dr["PartnerName"] = Partnershipname;
                    dr["PartnershipPer"] = partnershipper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_partnership_details"] = dt;

                    temp_partnership_details_DataBind();
                }
                

            
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
                return;
            }

        }

        protected void insert_trustee_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];


            string trusteename = (Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert") as TextBox).Text;
            string address = (Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert") as TextBox).Text;
            string email = (Trustee_details_grid.FooterRow.FindControl("txtTEmail_insert") as TextBox).Text;
            string phone = (Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert") as TextBox).Text;


            if (trusteename != "")
            {
                DataRow dr = dt.NewRow();
                dr["TrusteeName"] = trusteename;
                dr["Address"] = address;
                dr["Email"] = email;
                dr["phone"] = phone;

                dt.Rows.Add(dr);
                dt.AcceptChanges();

                ViewState["temp_trustee_details"] = dt;
                temp_trustee_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Trustee Name');", true);
                return;
            }

        }

        protected void insert_Director_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            string Directorname = (DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert") as TextBox).Text;
            string din_pan = (DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert") as TextBox).Text;
            string address = (DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert") as TextBox).Text;
            string phone = (DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert") as TextBox).Text;
            string email = (DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert") as TextBox).Text;

            if (Directorname != "")
            {
                if (din_pan != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["DirectorName"] = Directorname;
                    dr["Din_Pan"] = din_pan;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_directors_details"] = dt;

                    temp_director_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Din/Pan');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Director Name');", true);
                return;
            }

        }

        protected void ShareHolderDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_shareholder_details"] = dt;

            dt.AcceptChanges();


            temp_shareholder_details_DataBind();


        }
        protected void PartnershipDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_partnership_details"] = dt;

            dt.AcceptChanges();


            temp_partnership_details_DataBind();


        }
        protected void TrusteeDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_trustee_details"] = dt;

            dt.AcceptChanges();


            temp_trustee_details_DataBind();


        }
        protected void DirectorDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_directors_details"] = dt;

            dt.AcceptChanges();


            temp_director_details_DataBind();


        }
        private void bindCompanytypeddl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                if(ds!= null)
                { 
                ds = objServiceTimelinesBLL.GetCompanyType();
                ddlcompanytype.DataSource = ds;
                ddlcompanytype.DataTextField = "company_type";
                ddlcompanytype.DataValueField = "id";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            
            BindServiceCheckListGridViewDocument(hfName.Value);
            if (index == 0)
            {

            }
            if (index == 3 || index == 4)
            {
                GetPaymentDetails();

            }
                       

            if (TypeID == "1008")
            {
                if (index == 1)
                {                   
                    GetReconsitiutionApplicationDetails();
                }
                if (index == 6)
                {
                    BindObjection();
                }
            }
            if (TypeID == "1021")
            {
                if (index == 1)
                {
                    GetReconsitiutionApplicationDetails();
                }
                if (index == 6)
                {
                    BindObjection();
                }
            }
            if (TypeID == "1017")
            {
                if (index == 5 || index == 8)
                {
                    GetFinalViewhandoverofleasedeedtoleaseDetails();
                }
                if (index == 6)
                {
                    BindObjection();
                }

            }
            //if (TypeID == "1022")
            //{
            //    if (index == 8)
            //    {
            //        GetFinalViewhandoverofleasedeedtoleaseDetails();
            //    }
            //    if (index == 6)
            //    {
            //        BindObjection();
            //    }

            //}
            if (index == 7)
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


                    if (TypeID == "1008")
                    {
                        DocType = "Requestforreconstitutionallotte";
                    }
                    if (TypeID == "1017")
                    {
                        DocType = "Requestforhandoverofleasedeedtolease";
                    }
                    if (TypeID == "1021")
                    {
                        DocType = "Requestforreconstitutionoflegalheirafterdeath";
                    }
                    //if (TypeID == "1022")
                    //{
                    //    DocType = "RequestforWaterConnection";
                    //}
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

                                    string message = "File  Uploaded SucessFully";
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
                    PlaceHolder1.Controls.Add(UC_IAServiceProcessFeeNMSWP);

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
                }
                PH_FinalView.Controls.Clear();
                #region manish Rastogi Services
                if (TypeID == "1008")
                {
                    UC_ReconstitutionFinalViewIAService UC_ReconstitutionFinalViewIAService = LoadControl("~/UC_ReconstitutionFinalViewIAService.ascx") as UC_ReconstitutionFinalViewIAService;
                    UC_ReconstitutionFinalViewIAService.ID = "UC_ReconstitutionFinalViewIAService";
                    UC_ReconstitutionFinalViewIAService.TranID = TraID;
                    UC_ReconstitutionFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                    PH_FinalView.Controls.Add(UC_ReconstitutionFinalViewIAService);
                }
                else if (TypeID == "1017")
                {
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService = LoadControl("~/UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ascx") as UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ID = "UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService";
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.TranID = TraID;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ControlID = UnitID;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ServiceRequestNo = ServiceReqNo;

                    PH_FinalView.Controls.Add(UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService);
                }
                else if (TypeID == "1021")
                {
                    UC_ReconstitutionforlegalheirFinalViewIAService UC_ReconstitutionforlegalheirFinalViewIAService = LoadControl("~/UC_ReconstitutionforlegalheirFinalViewIAService.ascx") as UC_ReconstitutionforlegalheirFinalViewIAService;
                    UC_ReconstitutionforlegalheirFinalViewIAService.ID = "UC_ReconstitutionforlegalheirFinalViewIAService";
                    UC_ReconstitutionforlegalheirFinalViewIAService.TranID = TraID;
                    UC_ReconstitutionforlegalheirFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                    PH_FinalView.Controls.Add(UC_ReconstitutionforlegalheirFinalViewIAService);
                }
                //else if (TypeID == "1022")
                //{
                //    UC_ApplicationFinalWaterConnection UC_ApplicationFinalWaterConnection = LoadControl("~/UC_ApplicationFinalWaterConnection.ascx") as UC_ApplicationFinalWaterConnection;
                //    UC_ApplicationFinalWaterConnection.ID = "UC_Service_WaterConnection";
                //    UC_ApplicationFinalWaterConnection.TranID = TraID;
                //    UC_ApplicationFinalWaterConnection.ServiceRequestNo = ServiceReqNo;

                //    PH_FinalView.Controls.Add(UC_ApplicationFinalWaterConnection);
                //}
                #endregion



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
                    string Status = dt.Rows[0]["FinalSubmission"].ToString();
                    //lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    //lblindustrialid.Text = dt.Rows[0]["IAID"].ToString();
                    //lblplotno.Text = dt.Rows[0]["PlotNo"].ToString();
                    //lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    //lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    //lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    //lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    //lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    //lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    //lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    //lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    //string Payment = dt.Rows[0]["PaymentStatus"].ToString();
                    //string Objection = dt.Rows[0]["Objection"].ToString();
                    //string Rejected = dt.Rows[0]["Rejected"].ToString();
                    //string Completed = dt.Rows[0]["Completed"].ToString();


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
                            btn_Submit.Text = "Pay Now";
                            //btn_Submit.Text = "Print";
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
                        sub_menu.Items.Add(new MenuItem { Value = "7", Text = "Rejection Letter" });
                    }
                    if (Completed == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "7", Text = "Approval Letter" });
                    }


                }

            }

        }
        private void DisableAllControl()
        {
            ddlcompanytype.Enabled = false;
            txtCompanyname.Enabled = false;
            txtPanNo.Enabled = false;
            txtCinNo.Enabled = false;
            txtIndividualName.Enabled = false;
            txtIndividualAddress.Enabled = false;
            txtIndividualPhone.Enabled = false;
            txtIndividualEmail.Enabled = false;
            chk2.Enabled = false;
            txtAuthorisedSignatory.Enabled = false;
            txtSignatoryAddress.Enabled = false;
            txtSignatoryPhone.Enabled = false;
            txtSignatoryEmail.Enabled = false;
            txtApplicationDescription.Enabled = false;
            BtnSaveApplicant.Enabled = false;
            btn_SubmitWithoutFees.Enabled = false;
            btnSubmitnew.Enabled = false;

        }
        public void GetReconsitiutionApplicationDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetNewReconstitutionDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
             
                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["ApplicantId"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["ApplicantId"].ToString();
                    LblAllotteeIdMain.Text = dt.Rows[0]["MainID"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["ApplicantName"].ToString();
                    string Objection = dt.Rows[0]["Objection"].ToString();

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
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Value == "11")
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                    }




                    if (dt.Rows[0]["FirmConstitution"].ToString() == "" || dt.Rows[0]["FirmConstitution"].ToString() == null)
                    {
                        ddlcompanytype.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcompanytype.SelectedValue = dt.Rows[0]["FirmConstitution"].ToString().Trim();
                    }
                    lblRegionalOffice.Text = dt.Rows[0]["District"].ToString().Trim();
                    lblIAID.Text = dt.Rows[0]["IndustrialArea"].ToString().Trim();
                    lblIndustrialArea.Text = dt.Rows[0]["IndustrialAreaName"].ToString().Trim();
                   
                    txtCompanyname.Text = dt.Rows[0]["CompanyName"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                   
                    txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();
                   
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                    {

                        tr2.Visible = true;
                        ViewState["temp_shareholder_details"] = dt1;
                        temp_shareholder_details_DataBind();
                    }
                    else
                    {
                        tr2.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                    {

                        tr9.Visible = true;
                        ViewState["temp_partnership_details"] = dt1;
                        temp_partnership_details_DataBind();
                    }
                    else
                    {
                        tr9.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                    {

                        tr4.Visible = true;
                        ViewState["temp_trustee_details"] = dt1;
                        temp_trustee_details_DataBind();
                    }
                    else
                    {
                        tr4.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                    {

                        tr8.Visible = true;

                        ViewState["temp_directors_details"] = dt1;
                        temp_director_details_DataBind();
                    }
                    else
                    {
                        tr8.Visible = false;
                    }
                    if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                    {

                        tr5.Visible = true;
                        tr6.Visible = true;
                        tr7.Visible = false;

                        txtIndividualName.Text = dt.Rows[0]["ApplicantName"].ToString().Trim();
                     
                        txtIndividualAddress.Text = dt.Rows[0]["Address1"].ToString().Trim();
                        txtIndividualEmail.Text = dt.Rows[0]["emailID"].ToString().Trim();
                        txtIndividualPhone.Text = dt.Rows[0]["PhoneNo"].ToString().Trim();

                        lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";
                    }
                    else
                    {
                        txtIndividualName.Text = "";
                        txtIndividualAddress.Text = "";
                        txtIndividualEmail.Text = "";
                        txtIndividualPhone.Text = "";
                        chk2.Checked = false;
                        tr5.Visible = false;
                        tr6.Visible = false;
                        tr7.Visible = false;

                    }
                    txtAuthorisedSignatory.Text = dt.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                    txtSignatoryAddress.Text = dt.Rows[0]["SignatoryAddress"].ToString().Trim();
                    txtSignatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString().Trim();
                    txtSignatoryPhone.Text = dt.Rows[0]["SignatoryPhone"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                    txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();

                    lblSignatoryMobile.Text = dt.Rows[0]["SignatoryPhone"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString();
                                

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                    return;
                }
              


                
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        

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
                SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocumentsfor3Services '" + ServiceReqNo.Trim() + "'", con);
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

                        if (TypeID == "1008")
                        {
                            Message = "Reconstitution Details are Mandatory";
                        }
                        
                        if (TypeID == "1021")
                        {
                            Message = "Recognition  of legal heir are Mandatory";
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

                            if (TypeID == "1008")
                            {
                                Message = "Reconstitution Details are Mandatory";
                            }
                            
                            if (TypeID == "1021")
                            {
                                Message = "Recognition  of legal heir are Mandatory";
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
                            case "1008":
                                Count1 = 4;
                                break;
                            
                            case "1021":
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


        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            ddlcompanytype.Style.Clear();
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                //   txtCompanyname.Enabled = false;
                // txtCinNo.Enabled = false;


            }

            if (ddlcompanytype.SelectedValue == "1")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = true;
                tr6.Visible = true;
                tr7.Visible = true;
                tr8.Visible = false;
                tr9.Visible = false;
                //  txtCompanyname.Enabled = false;
                //  txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
                tr9.Visible = false;
            }
            if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
            }
            if (ddlcompanytype.SelectedValue == "4")
            {

                tr2.Visible = false;
                tr4.Visible = true;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;

                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "5")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = true;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }

        }
        protected void checkbox2_checked_changed(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                txtAuthorisedSignatory.Text = txtIndividualName.Text;
                txtSignatoryAddress.Text = txtIndividualAddress.Text;
                txtSignatoryPhone.Text = txtIndividualPhone.Text;
                txtSignatoryEmail.Text = txtIndividualEmail.Text;
            }
            else
            {
                txtAuthorisedSignatory.Text = "";
                txtSignatoryAddress.Text = ""; ;
                txtSignatoryPhone.Text = "";
                txtSignatoryEmail.Text = "";
            }
        }


        protected void BtnSaveApplicant_Click(object sender, EventArgs e)
        {

            try
            {
                int retval = 0, retVal2 = 0;

                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (Dt1.Rows.Count <= 0)
                    {
                        string message = "Please Add Shareholder Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();


                ds = objServiceTimelinesBLL.UpdateReconstitutionDetailsNew(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblAllotteeID.Text = ds.Tables[0].Rows[0][0].ToString();
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(lblAllotteeID.Text.Trim());



                        retVal2 = objServiceTimelinesBLL.ClearFirmConstitutionOfReconstitution(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedIndex == 1)
                            {
                                string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Details Uploaded and Application has been savd as draft | Applicant", SWCRequest_ID, "Applicant", "");
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                Allotment.ActiveViewIndex = 2;
                            }

                            if (ddlcompanytype.SelectedIndex == 2)
                            {
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        retval = objServiceTimelinesBLL.Insertshareholderdetails(lblAllotteeID.Text, ShareholderName, shareper, Address, phone, email);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Details Uploaded and Application has been savd as draft | Applicant", SWCRequest_ID, "Applicant", "");
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 2;
                                }
                            }
                            if (ddlcompanytype.SelectedIndex == 3)

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        retval = objServiceTimelinesBLL.InsertDirectordetails(lblAllotteeID.Text, DirectorName, din_pan, Address, phone, email);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Details Uploaded and Application has been savd as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 2;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        retval = objServiceTimelinesBLL.InsertTrusteedetails(lblAllotteeID.Text, TrusteeName, Address, phone, email);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Details Uploaded and Application has been savd as draft | Applicant", SWCRequest_ID, "Applicant", "");
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 2;
                                }
                            }
                            if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        retval = objServiceTimelinesBLL.InsertPartnerdetails(lblAllotteeID.Text, PartnerName, Partnershipper, Address, phone, email);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Details Uploaded and Application has been savd as draft | Applicant", SWCRequest_ID, "Applicant", "");

                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                                    Allotment.ActiveViewIndex = 2;
                                }
                            }


                        }


                    }
                }
                else
                {
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }



            catch (Exception ex)
            {


                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }
        public void clear()
        {
            string id = ViewState["Company"].ToString();
            txtIndividualName.Text = string.Empty;
            txtIndividualEmail.Text = string.Empty;
            txtIndividualPhone.Text = string.Empty;
            txtIndividualAddress.Text = string.Empty;
            txtAuthorisedSignatory.Text = string.Empty;
            txtSignatoryAddress.Text = string.Empty;
            txtSignatoryPhone.Text = string.Empty;
            txtSignatoryEmail.Text = string.Empty;
            txtCompanyname.Text = string.Empty;
            ddlcompanytype.SelectedValue = "0";
            txtPanNo.Text = string.Empty;
            txtCinNo.Text = string.Empty;
            if(id == "2")
            {
                ViewState["temp_shareholder_details"] = null;
                DataTable temp_shareholder_details = new DataTable();
                temp_shareholder_details.TableName = "temp_shareholder_details";
                temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("phone", typeof(string)));
                ViewState["temp_shareholder_details"] = temp_shareholder_details;
                temp_shareholder_details_DataBind();
            }
            else
            {

            }
           if(id=="3")
            {
                ViewState["temp_directors_details"] = null;
                DataTable temp_directors_details = new DataTable();
                temp_directors_details.TableName = "temp_directors_details";
                temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("phone", typeof(string)));
                ViewState["temp_directors_details"] = temp_directors_details;
                temp_director_details_DataBind();
               
            }
            else
            {

            }
            if(id=="4")
            {
                ViewState["temp_trustee_details"] = null;
                DataTable temp_trustee_details = new DataTable();
                temp_trustee_details.TableName = "temp_trustee_details";
                temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("phone", typeof(string)));
                ViewState["temp_trustee_details"] = temp_trustee_details;
                temp_trustee_details_DataBind();
            }
            else
            {

            }
           if(id=="5")
            {
                ViewState["temp_partnership_details"] = null;
                DataTable temp_partnership_details = new DataTable();
                temp_partnership_details.TableName = "temp_partnership_details";
                temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("Phone", typeof(string)));
                ViewState["temp_partnership_details"] = temp_partnership_details;
                temp_partnership_details_DataBind();
            }
            else
            {

            }
           
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

        private void HandoverDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                string html = "";
                string html1 = "";
                int i = 0;
                int j = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;

                ds = objServiceTimelinesBLL.GethandoverofleasedeedDetailsIAService(objServiceTimelinesBEL);
       
                DataTable dt2 = ds.Tables[3];

                if (dt2.Rows.Count > 0)
                {
                    txtApplicationDescription.Text = dt2.Rows[0]["description"].ToString();
                }
                 


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        protected void btnSubmitnew_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                int retval = 0;
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                if (txtApplicationDescription.Text.Length <= 0)
                {
                    MessageBox1.ShowError("Please Enter Application Description");
                    return;
                }
                string str = txtApplicationDescription.Text.Trim();
                string str2 = Server.HtmlDecode(str);
                objServiceTimelinesBEL.ApplicationDescription = str2;
                objServiceTimelinesBEL.UserName = System.Environment.MachineName;                
                objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
                retval = objServiceTimelinesBLL.InserthandoverofleasedeedtoleaseDetails(objServiceTimelinesBEL);

                if (retval > 0)
                {
                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Applicant Project Details Updated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                    if (NMSWP_Result == "SUCCESS")
                    {
                        string message = "Lease deed to lease  Details Saved Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        Allotment.ActiveViewIndex = 2;
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        

        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + ServiceReqNo + "');", true);
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
                    
                   
                    
                    if (TypeID == "1008")
                    {
                        DocType = "ReconstitutionOfCompany";
                    }
                    if (TypeID == "1017")
                    {
                        DocType = "HandOverleasedeed";
                    }
                    if (TypeID == "1021")
                    {
                        DocType = "transferofleasedeed";
                    }
                    //if (TypeID == "1022")
                    //{
                    //    DocType = "waterconnection";
                    //}
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

        private void download1(DataTable dt)
        {
            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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


        #region NiveshMitra
        protected void Confirm_CheckBox_final(object sender, EventArgs e)
        {
            if (CheckBox_Final.Checked == true)
            {
                btn_SubmitWithoutFees.Enabled = true;
            }
            else
            {
                btn_SubmitWithoutFees.Enabled = false;
            }


        }

        protected void btn_SubmitWithoutFees_Click(object sender, EventArgs e)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            if (CheckBox_Final.Checked == true)
            {
                btn_SubmitWithoutFees.Enabled = true;
            }
            else
            {
                MessageBox1.ShowWarning("First Check The CheckBox at the bottom");
                return;
            }
            int Count1 = 0;
            SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocumentsfor3Services '" + ServiceReqNo.Trim() + "'", con);
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

                    if (TypeID == "1017")
                    {
                        Message = "Hand over of lease deed to lease details are Mandatory";
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

                        if (TypeID == "1017")
                        {
                            Message = "Hand over of lease deed to lease details are Mandatory";
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
                        case "1017":
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
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            int result = 0;
            result = objServiceTimelinesBLL.SetServiceRequestFinish_IAService(objServiceTimelinesBEL);
            if (result > 0)
            {
                string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "13", "Applicant Submits the Form to | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), SWCRequest_ID, "DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo), "");
                if (NMSWP_Result == "SUCCESS")
                {
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
                SqlCommand cmd = new SqlCommand("ValidateDetailsAndDocumentsfor3Services '" + ServiceReqNo.Trim() + "'", con);
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

                        if (TypeID == "1008")
                        {
                            Message = "Reconstitution Details are Mandatory";
                        }
                        
                        if (TypeID == "1021")
                        {
                            Message = "Recognition  of legal heir are Mandatory";
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

                            if (TypeID == "1008")
                            {
                                Message = "Reconstitution Details are Mandatory";
                            }

                            if (TypeID == "1021")
                            {
                                Message = "Recognition  of legal heir are Mandatory";
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
                            case "1008":
                                Count1 = 4;
                                break;
                           
                            case "1021":
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
                                    string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                                    GetPaymentDetails();
                                    GetApplicationDetails();
                                    return;
                                }
                                else
                                {
                                    string Message = "Request is submitted succesfully. Kindly pay processing fees from nivesh mitra portal for the final submission of your application.";
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



                DataTable dt = gm.GetNMSWP_Details(SWCControlID, SWCUnitID, SWCServiceID,SWCRequest_ID);
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
        #endregion     

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

    }
}

        
        


            
            
    
