﻿
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace UpsidaAllottee
{
    public partial class IAServicesAssessment : System.Web.UI.Page
    {
        #region "Create and Initialize objects"
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod  gm = new GeneralMethod();
       

        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;


      
        public string Level = "";
        public string DataManager = "";
  


        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
       
        #endregion
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Form.Enctype = "multipart/form-data";
            try
            {
                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);

                string[] SerArray1 = ServiceReqNo.Split('/');
                ServiceID = int.Parse(SerArray1[1]);
                ApplicantId = int.Parse(SerArray1[2]);
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID = NMSWP.Rows[0][0].ToString();
                SWCUnitID = NMSWP.Rows[0][1].ToString();
                SWCServiceID = NMSWP.Rows[0][2].ToString();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();



                    if (Level == "RM")
                    {
                        if (ServiceID == 1003 || ServiceID == 1004 || ServiceID == 1005 || ServiceID == 1011 || ServiceID == 1012 || ServiceID == 1007 || ServiceID == 1009 || ServiceID == 1010|| ServiceID == 1023 || ServiceID == 1008 || ServiceID == 1017 || ServiceID == 1021 || ServiceID == 1022 || ServiceID == 1014 || ServiceID == 1024||ServiceID==1027 || ServiceID==1029)
                        {
                            btnRejectM.Visible = true;
                            btnApprove.Visible = true;
                        }
                        else if (ServiceID == 1002 || ServiceID == 1006 || ServiceID == 1013)
                        {
                            SqlCommand cmd1 = new SqlCommand("GetStatusForApprovalIAService '" + ServiceReqNo + "'", con);
                            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                string Show = dt1.Rows[0][0].ToString();
                                if (Show == "Show Reject")
                                {
                                    btnRejectM.Visible = true;
                                }
                                else if (Show == "Show Approve")
                                {
                                    btnApprove.Visible = true;
                                }
                                else if (Show == "ShowAll")
                                {
                                    btnApprove.Visible = true;
                                    btnRejectM.Visible = true;
                                }


                            }
                            else
                            {
                                btnApprove.Visible = false;
                                btnRejectM.Visible = false;
                            }
                        }
                        else if (ServiceID == 4)
                        {
                            SqlCommand cmd1 = new SqlCommand("GetStatusForApprovalIAService '" + ServiceReqNo + "'", con);
                            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                string Show = dt1.Rows[0][0].ToString();
                                if (Show == "Show Reject")
                                {
                                    btnRejectM.Visible = true;
                                }
                                else if (Show == "Show Approve")
                                {
                                    btnApprove.Visible = true;
                                }
                                else if (Show == "ShowAll")
                                {
                                    btnApprove.Visible = true;
                                    btnRejectM.Visible = true;
                                }


                            }
                        }
                        else if (ServiceID == 1006 || ServiceID == 1026 || ServiceID == 1012 || ServiceID == 1025)
                        {
                            SqlCommand cmd1 = new SqlCommand("GetStatusForApprovalIAService '" + ServiceReqNo + "'", con);
                            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                string Show = dt1.Rows[0][0].ToString();
                                if (Show == "Show Reject")
                                {
                                    btnRejectM.Visible = true;
                                }
                                else if (Show == "Show Approve")
                                {
                                    btnApprove.Visible = true;
                                }
                                else if (Show == "ShowAll")
                                {
                                    btnApprove.Visible = true;
                                    btnRejectM.Visible = true;
                                }


                            }
                        }
                        else
                        {

                            btnRejectM.Visible = false;

                            btnApprove.Visible = false;
                        }
                    }
                    if (Level == "ATP")
                    {
                        SqlCommand cmd1 = new SqlCommand("GetStatusForApprovalIAService '" + ServiceReqNo + "'", con);
                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        adp1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            string Show = dt1.Rows[0][0].ToString();
                            if (Show == "Show Reject")
                            {
                                btnRejectM.Visible = true;
                            }
                            else if (Show == "Show Approve")
                            {
                                btnApprove.Visible = true;
                            }


                        }
                        else
                        {
                            btnApprove.Visible = false;
                            btnRejectM.Visible = false;
                        }
                    }



                }
                string[] SerIdarray = ServiceReqNo.Split('/');


            }
            catch (Exception ex) { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {
                drpRemarks.Text = string.Empty;
                drp_Doc_Status_Save.SelectedIndex = 0;


                ddlApplicant.Items.Insert(0, new ListItem(ServiceReqNo, ServiceReqNo));


                ServiceReqNo = ddlApplicant.SelectedValue;

                string[] SerArray = ServiceReqNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);
                ApplicantId = int.Parse(SerArray[2]);

                ddlApplicant_SelectedIndexChanged(null, null);   // also call  MenuMaker();
                sub_menu_MenuItemClick(null, null);


            }



            load_UC("ALL");
        }



        #region LeftMenu
        protected void MenuMaker()
        {

            SqlCommand cmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNo='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string SiteInspection = dt.Rows[0]["Documents"].ToString();

            sub_menu.Items.Clear();

            switch (ServiceID.ToString())
            {

                case "1003":
                    {

                      

                        //////// Change Of Project //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Fee Details" });
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA" || Level == "Accountant")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA" || Level != "Accountant")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        break;
                    }
                case "1004":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1029":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1030":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1009":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Building_Details|", Text = "Building Specification" });

                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }

                case "1010":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1005":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|NocMortgageApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1006":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|MortgageApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1007":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|SecondchargeApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1011":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|transferofleasedeed_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1002":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Timeextension_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });

                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1023":
                    {                     
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        if (Level == "DA")
                        {                           
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        break;
                    }
                case "1027":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Application Form" });
                        //if (Level == "DA")
                        //{
                        //    sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        //}
                        //if (Level != "DA")
                        //{
                        //    sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        //}
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });
                        break;
                    }
                case "4":
                    {
                        //////// Transfer Of Plot //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail_Transfer", Text = "Application Form" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transferar_Doc|", Text = "Transferar Documents" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transferee_Doc|", Text = "Transferee Documents" });
                        if (Level == "RM" || Level == "JE")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Appointment_Detail", Text = "Appointment Detail" });
                        }
                        if (Level == "DA")
                        {

                            sub_menu.Items.Add(new MenuItem { Value = "page|Appointment", Text = "Setup Appointment" });
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }

                #region Manish Rastogi
                case "1008":
                    {
                        //////// Reconstitution Service //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|ReconstitutionApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1017":
                    {
                        //////// handover of leasedeed to lease Service //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|handoverofleasedeedtoleaseApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1021":
                    {
                        //////// Reconstitution for legalheir Service //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|ReconstitutionforlegalheirApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1022":
                    {
                        //////// Water Connection Service//////
                        sub_menu.Items.Add(new MenuItem { Value = "page|WaterConnectionApplicant_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();

                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }

                #endregion

                #region NewService BY Manish Shukla
                case "1014":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|startofproduction_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        if (SiteInspection.Length > 0)
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "doc|InspectionReport", Text = "Site Inspection Report" });
                        }
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1013":
                    {
                        //////// Addition Of Product //////
                        //CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail",   Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|CreateNotice",      Text = "Create Notice" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Notice_Detail",     Text = "Applicant Notice Reply Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }

                #endregion

                #region NewServiceManishShukla
                case "1012":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|NewServiceCommon_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1024":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|NewServiceCommon_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1025":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|NewServiceCommon_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                case "1026":
                    {
                        //////// Addition Of Product //////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|NewServiceCommon_Detail", Text = "Application Form" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        sub_menu.Items.Add(new MenuItem { Value = "page|Payment_Details|", Text = "Payment Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_DetailBT", Text = "View Preceedings" });
                        if (Level == "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Raise_Objection", Text = "Raise Objection" });
                        }
                        if (Level != "DA")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Objection_View", Text = "Objection Details" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Process_Application|", Text = "Process Application -->" });

                        break;
                    }
                #endregion

                default:
                    {
                        //////////////   Other ////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        CheklistBind(ServiceID, ServiceReqNo);
                        sub_menu.DataBind();
                        break;
                    }

            }


        }


        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            gridRequestDoc_Status.DataBind();
            string string_val = "";
            string string_text = "";

            try
            {


                string_val = (e.Item.Value.Trim());
                string_text = (e.Item.Text);
            }
            catch
            {
                string_val = sub_menu.Items[0].Value;
                string_text = sub_menu.Items[0].Text;
            }


            ViewState["sub_menu"] = string_val;
            ViewState["sub_menu_text"] = string_text;


            string[] SerIdarray = string_val.Split('|');
            if ((string)ViewState["sub_menu"] != string_val)
            {
                drpRemarks.Text = "";
            }

            foreach (MenuItem item in sub_menu.Items)
            {
                if (string_text == item.Text)
                {
                    item.Selected = true;
                }
            }


            load_UC("ALL");




        }



        protected void CheklistBind(int ServiceID, string ServicereqNo)
        {
            try
            {
                string Menu_Val = "";
                DataTable dt = new DataTable();
                dt = new GeneralMethod().EvaluationCheklistBuildingPlan(ServiceID, ServicereqNo);

                int UniqueNo = ServiceID;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //   UniqueNo++;
                        string Menu_Text = dr["ServiceTimeLinesDocuments"].ToString().Trim();
                        string ServiceCheckListsID = (dr["ServiceCheckListsID"].ToString().Trim()).Trim();

                        Menu_Val = "doc|" + ServiceCheckListsID + "|" + (dr["DocumentID"].ToString().Trim()).Trim();


                        sub_menu.Items.Add(new MenuItem { Value = Menu_Val, Text = Menu_Text });

                    }
                }
            }


            catch { }
        }



        #endregion

        #region DocumentReletedProcessing&View

        protected void GET_ServiceRequestDoc_Status(string ServiceReqNo, string ServiceCheckListsID)
        {
            gridRequestDoc_Status.DataBind();

            SqlCommand cmd = new SqlCommand("GET_ServiceRequestProcessDoc  '" + ServiceReqNo + "'," + ServiceCheckListsID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridRequestDoc_Status.DataSource = dt;
                gridRequestDoc_Status.DataBind();

            }
            else
            {
                gridRequestDoc_Status.DataSource = null;
                gridRequestDoc_Status.DataBind();
            }

        }

        //protected void btnApprove_Click(object sender, EventArgs e)
        //{

        //    if (ServiceID == 4)
        //    {
        //        Response.Redirect("~/ReportGenrationT.aspx?ServiceReqNo=" + ServiceReqNo, false);
        //    }
        //    else
        //    {
        //        Response.Redirect("~/ReportGenrationIAService.aspx?ServiceReqNo=" + ServiceReqNo, false);
        //    }
        //}
        protected void btnApprove_Click(object sender, EventArgs e)
        {

            if (ServiceID == 4)
            {
                Response.Redirect("~/ReportGenrationT.aspx?ServiceReqNo=" + ServiceReqNo, false);
            }

            else if (ServiceID == 1029)
            {
                //popup.Show();
                Response.Redirect("~/PlotNameUpdate.aspx?ServiceReqNo=" + ServiceReqNo, false);

            }
            else
            {
                Response.Redirect("~/ReportGenrationIAService.aspx?ServiceReqNo=" + ServiceReqNo, false);
            }

        }


        protected void DocumentViewer(string DocumentID)
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.DocumentID = DocumentID;
            ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=&ServiceCheckListsID=&ServiceTimeLinesID=&DocId=" + DocumentID + "")));

                //    Placeholder.Controls.Clear();
                Placeholder.Controls.Add(ltEmbed);
            }
        }

        public void Redirect(string Par, string ID)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Redirect('" + Par + "','" + ServiceReqNo + "','" + ID + "');", true);
        }
        public void AllertRedirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + Par + "');", true);

            // MessageBox1.ShowSuccess("Hello");
        }

        protected void btnRejectM_Click(object sender, EventArgs e)
        {
            SqlCommand cmmd = new SqlCommand("GetResubmissionTimelineBuildingPlan '" + ServiceReqNo + "'", con);
            SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            adpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][1].ToString() == "Close")
                {

                    Response.Redirect("~/RejectionLetterGeneration.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }
                else if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 7)
                {

                    Response.Redirect("~/RejectionLetterGeneration.aspx?ServiceReqNo=" + ServiceReqNo, false);
                }
                else
                {
                    MessageBox1.ShowWarning("Kindly Mark Objection before rejection as objection is still open for this application");
                    return;
                }
            }

        }



        #endregion



        protected void load_UC(string AllOrFirst)
        {

            Placeholder.Controls.Clear();
            div_doc_status.Visible = false;


            string string_val = (string)ViewState["sub_menu"];
            string[] SerIdarray = string_val.Split('|');
            string Menu_Type = "";
            string Menu_Value1 = "";
            string Menu_Value2 = "";
            try
            {

                Menu_Type = SerIdarray[0];
                Menu_Value1 = SerIdarray[1];
                Menu_Value2 = SerIdarray[2];

            }
            catch (Exception ex)
            {

            }

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



            if (Menu_Type == "doc")
            {

                if (Menu_Value1 == "InspectionReport")
                {
                    InspectionfreportViewer();
                }
                else
                {
                    string ServiceCheckListsID = Menu_Value1;
                    string doc_id = Menu_Value2;

                    if (ServiceCheckListsID.Length > 0)
                    {
                        GET_ServiceRequestDoc_Status(ServiceReqNo, ServiceCheckListsID);
                        div_doc_status.Visible = true;
                    }

                    if (doc_id.Length > 0)
                    {
                        DocumentViewer(doc_id);
                    }
                    else
                    {
                        Literal ltEmbed = new Literal();
                        ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                        Placeholder.Controls.Add(ltEmbed);
                    }
                }
            }

            if (Menu_Type == "page")
            {
                if (Menu_Value1 == "Applicant_Detail")
                {
                    UC_ApplicationFinalViewIAService UC_ApplicationFinalViewIAService = LoadControl("~/UC_ApplicationFinalViewIAService.ascx") as UC_ApplicationFinalViewIAService;
                    UC_ApplicationFinalViewIAService.ID = "UC_ApplicationFinalViewIAService";
                    UC_ApplicationFinalViewIAService.TranID = TraID;
                    UC_ApplicationFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewIAService.ControlID = SWCUnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewIAService);
                }
                if (Menu_Value1 == "Allottee_Detail")
                {
                    UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = LoadControl("~/UC_Service_Allotteee_Detail.ascx") as UC_Service_Allotteee_Detail;
                    UC_Service_Allotteee_Detail.AllotteeId = ApplicantId.ToString();
                    UC_Service_Allotteee_Detail.ID = "UC_Service_Allotteee_DetailID";
                    UC_Service_Allotteee_Detail.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Service_Allotteee_Detail);
                }
                if (Menu_Value1 == "SecondchargeApplicant_Detail")
                {
                    UC_ApplicationFinalViewSecondchargeService UC_ApplicationFinalViewSecondchargeService = LoadControl("~/UC_ApplicationFinalViewSecondchargeService.ascx") as UC_ApplicationFinalViewSecondchargeService;
                    UC_ApplicationFinalViewSecondchargeService.ID = "UC_ApplicationFinalViewSecondchargeService";
                    UC_ApplicationFinalViewSecondchargeService.TranID = TraID;
                    UC_ApplicationFinalViewSecondchargeService.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewSecondchargeService.ControlID = SWCControlID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewSecondchargeService);
                }
                if (Menu_Value1 == "NocMortgageApplicant_Detail")
                {
                    UC_ApplicationFinalViewNocMortgageService UC_ApplicationFinalViewNocMortgageService = LoadControl("~/UC_ApplicationFinalViewNocMortgageService.ascx") as UC_ApplicationFinalViewNocMortgageService;
                    UC_ApplicationFinalViewNocMortgageService.ID = "UC_ApplicationFinalViewNocMortgageService";
                    UC_ApplicationFinalViewNocMortgageService.TranID = TraID;
                    UC_ApplicationFinalViewNocMortgageService.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewNocMortgageService.ControlID = SWCUnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewNocMortgageService);
                }
                if (Menu_Value1 == "MortgageApplicant_Detail")
                {
                    UC_ApplicationFinalViewJointMortgageService UC_ApplicationFinalViewJointMortgageService = LoadControl("~/UC_ApplicationFinalViewJointMortgageService.ascx") as UC_ApplicationFinalViewJointMortgageService;
                    UC_ApplicationFinalViewJointMortgageService.ID = "UC_ApplicationFinalViewJointMortgageService";
                    UC_ApplicationFinalViewJointMortgageService.TranID = TraID;
                    UC_ApplicationFinalViewJointMortgageService.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewJointMortgageService.ControlID = SWCUnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewJointMortgageService);
                }
                if (Menu_Value1 == "transferofleasedeed_Detail")
                {
                    UC_ApplicationFinalViewtransferofleasedeedService UC_ApplicationFinalViewtransferofleasedeedService = LoadControl("~/UC_ApplicationFinalViewtransferofleasedeedService.ascx") as UC_ApplicationFinalViewtransferofleasedeedService;
                    UC_ApplicationFinalViewtransferofleasedeedService.ID = "UC_ApplicationFinalViewtransferofleasedeedService";
                    UC_ApplicationFinalViewtransferofleasedeedService.TranID = TraID;
                    UC_ApplicationFinalViewtransferofleasedeedService.ControlID = SWCUnitID;
                    UC_ApplicationFinalViewtransferofleasedeedService.ServiceRequestNo = ServiceReqNo;

                    Placeholder.Controls.Add(UC_ApplicationFinalViewtransferofleasedeedService);
                }
                if (Menu_Value1 == "Timeextension_Detail")
                {
                    UC_ApplicationFinalViewTimeextensionService UC_ApplicationFinalViewTimeextensionService = LoadControl("~/UC_ApplicationFinalViewTimeextensionService.ascx") as UC_ApplicationFinalViewTimeextensionService;
                    UC_ApplicationFinalViewTimeextensionService.ID = "UC_ApplicationFinalViewtransferofleasedeedService";
                    UC_ApplicationFinalViewTimeextensionService.IndustrialArea = Convert.ToInt32(IAID);
                    UC_ApplicationFinalViewTimeextensionService.PlotSize = decimal.Parse(PlotArea);
                    UC_ApplicationFinalViewTimeextensionService.TranID = TraID;
                    UC_ApplicationFinalViewTimeextensionService.ServiceRequestNo = ServiceReqNo;

                    Placeholder.Controls.Add(UC_ApplicationFinalViewTimeextensionService);
                }
                if (Menu_Value1 == "Applicant_Detail_Transfer")
                {
                    UC_ApplicationFinalViewTransferPlot UC_ApplicationFinalViewTransferPlot = LoadControl("~/UC_ApplicationFinalViewTransferPlot.ascx") as UC_ApplicationFinalViewTransferPlot;
                    UC_ApplicationFinalViewTransferPlot.ID = "UC_ApplicationFinalViewTransferPlot";
                    UC_ApplicationFinalViewTransferPlot.TranID = TraID;
                    UC_ApplicationFinalViewTransferPlot.ControlID = SWCUnitID;
                    UC_ApplicationFinalViewTransferPlot.ServiceRequestNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewTransferPlot);
                }
                if (Menu_Value1 == "Transferar_Doc")
                {
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferar UC_Service_Transfer_Of_Plot_Doc_View_Transferar = LoadControl("~/UC_Service_Transfer_Of_Plot_Doc_View_Transferar.ascx") as UC_Service_Transfer_Of_Plot_Doc_View_Transferar;
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferar.ID = "UC_Service_Transfer_Of_Plot_Doc_View_Transferar";
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferar.SerReqID = ServiceReqNo;
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferar.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Service_Transfer_Of_Plot_Doc_View_Transferar);
                }
                if (Menu_Value1 == "Transferee_Doc")
                {
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferee UC_Service_Transfer_Of_Plot_Doc_View_Transferee = LoadControl("~/UC_Service_Transfer_Of_Plot_Doc_View_Transferee.ascx") as UC_Service_Transfer_Of_Plot_Doc_View_Transferee;
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferee.ID = "UC_Service_Transfer_Of_Plot_Doc_View_Transferee";
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferee.SerReqID = ServiceReqNo;
                    UC_Service_Transfer_Of_Plot_Doc_View_Transferee.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Service_Transfer_Of_Plot_Doc_View_Transferee);
                }
                if (Menu_Value1 == "Comments_DetailBT")
                {
                    UC_CommentsBT UC_CommentsBT = LoadControl("~/UC_CommentsBT.ascx") as UC_CommentsBT;
                    UC_CommentsBT.ID = "UC_CommentsBT";
                    UC_CommentsBT.ServiceReqNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_CommentsBT);

                }
                if (Menu_Value1 == "Appointment_Detail")
                {
                    UC_Appontments UC_Appontments = LoadControl("~/UC_Appontments.ascx") as UC_Appontments;
                    UC_Appontments.ID = "UC_Appontments";
                    UC_Appontments.ServiceReqNo = ServiceReqNo;
                    //UC_Appontments.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Appontments);
                }

                if (Menu_Value1 == "Process_Application")
                {
                    UC_ProcessApplicationIAServices UC_ProcessApplicationIAServices = LoadControl("~/UC_ProcessApplicationIAServices.ascx") as UC_ProcessApplicationIAServices;
                    UC_ProcessApplicationIAServices.ID = "UC_ProcessApplicationIAServices";
                    UC_ProcessApplicationIAServices.ServiceReqNo = ServiceReqNo;
                    UC_ProcessApplicationIAServices.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_ProcessApplicationIAServices);

                }
                if (Menu_Value1 == "Raise_Objection")
                {
                    UC_RaiseDemandPlusObjection UC_RaiseDemandPlusObjection = LoadControl("~/UC_RaiseDemandPlusObjection.ascx") as UC_RaiseDemandPlusObjection;
                    UC_RaiseDemandPlusObjection.ID = "UC_RaiseDemandPlusObjection";
                    UC_RaiseDemandPlusObjection.ServiceReqNo = ServiceReqNo;
                    UC_RaiseDemandPlusObjection.Page_Load(null, null);
                    UC_RaiseDemandPlusObjection.EnableViewState = false;
                    Placeholder.Controls.Add(UC_RaiseDemandPlusObjection);
                }
                if (Menu_Value1 == "Allottee_Ledger")
                {
                    UC_Allottee_Ledger UC_Allottee_Ledger = LoadControl("~/UC_Allottee_Ledger.ascx") as UC_Allottee_Ledger;
                    UC_Allottee_Ledger.ID = "UC_Allottee_Ledger";
                    UC_Allottee_Ledger.ServiceReqNo = ServiceReqNo;
                    UC_Allottee_Ledger.Page_Load(null, null);
                    UC_Allottee_Ledger.EnableViewState = false;
                    Placeholder.Controls.Add(UC_Allottee_Ledger);
                }
                if (Menu_Value1 == "Building_Details")
                {
                    UC_BuildingDetails_Completion UC_BuildingDetails_Completion = LoadControl("~/UC_BuildingDetails_Completion.ascx") as UC_BuildingDetails_Completion;
                    UC_BuildingDetails_Completion.ID = "UC_BuildingDetails_Completion";
                    UC_BuildingDetails_Completion.SerReqID = ServiceReqNo;
                    Placeholder.Controls.Add(UC_BuildingDetails_Completion);
                }
                if (Menu_Value1 == "Objection_View")
                {
                    UC_DemandPlusObjectionView UC_DemandPlusObjectionView = LoadControl("~/UC_DemandPlusObjectionView.ascx") as UC_DemandPlusObjectionView;
                    UC_DemandPlusObjectionView.ID = "UC_RaiseDemandPlusObjection";
                    UC_DemandPlusObjectionView.ServiceReqNo = ServiceReqNo;
                    UC_DemandPlusObjectionView.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_DemandPlusObjectionView);
                }

                if (Menu_Value1 == "Appointment")
                {
                    UC_CreateAppointments UC_CreateAppointments = LoadControl("~/UC_CreateAppointments.ascx") as UC_CreateAppointments;
                    UC_CreateAppointments.ID = "UC_CreateAppointments";
                    UC_CreateAppointments.ServiceReqNo = ServiceReqNo;

                    UC_CreateAppointments.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_CreateAppointments);
                }
                if (Menu_Value1 == "Payment_Details")
                {
                    ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
                    string[] SerArray2 = ServiceReqNo.Split('/');
                    ServiceID = ((SerArray2[1]));
                    ApplicantId = int.Parse(SerArray2[2]);



                    if (ControlID.Length > 0)
                    {
                        if (ServiceID == "1002")
                        {
                            UC_IAServiceProcessFee_TEF UC_IAServiceProcessFee_TEF = LoadControl("~/UC_IAServiceProcessFee_TEF.ascx") as UC_IAServiceProcessFee_TEF;
                            UC_IAServiceProcessFee_TEF.IndustrialArea = Convert.ToInt32(IAID);
                            UC_IAServiceProcessFee_TEF.PlotSize = decimal.Parse(PlotArea);
                            UC_IAServiceProcessFee_TEF.ServiceRequestNo = ServiceReqNo;
                            UC_IAServiceProcessFee_TEF.ApplicantName = Applicantname;
                            UC_IAServiceProcessFee_TEF.applicantAddress = Address;
                            Placeholder.Controls.Add(UC_IAServiceProcessFee_TEF);

                        }
                        else
                        {
                            UC_IAServiceProcessFeeNMSWP UC_IAServiceProcessFeeNMSWP = LoadControl("~/UC_IAServiceProcessFeeNMSWP.ascx") as UC_IAServiceProcessFeeNMSWP;
                            UC_IAServiceProcessFeeNMSWP.IndustrialArea = Convert.ToInt32(IAID);
                            UC_IAServiceProcessFeeNMSWP.choicearea = Convert.ToDouble(PlotArea);
                            UC_IAServiceProcessFeeNMSWP.AllotmentLetterNo = AllottmentNo;
                            UC_IAServiceProcessFeeNMSWP.SWCControlID = SWCControlID;
                            UC_IAServiceProcessFeeNMSWP.SWCUnitID = SWCUnitID;
                            UC_IAServiceProcessFeeNMSWP.SWCServiceID = SWCServiceID;
                            UC_IAServiceProcessFeeNMSWP.ServiceRequestNo = ServiceReqNo;
                            UC_IAServiceProcessFeeNMSWP.TranID = TraID;
                            UC_IAServiceProcessFeeNMSWP.ApplicantName = Applicantname;
                            UC_IAServiceProcessFeeNMSWP.applicantAddress = Address;
                            Placeholder.Controls.Add(UC_IAServiceProcessFeeNMSWP);
                        }
                    }

                    else if (ServiceID == "1002")
                    {
                        UC_IAServiceProcessFee_TEF UC_IAServiceProcessFee_TEF = LoadControl("~/UC_IAServiceProcessFee_TEF.ascx") as UC_IAServiceProcessFee_TEF;
                        UC_IAServiceProcessFee_TEF.IndustrialArea = Convert.ToInt32(IAID);
                        UC_IAServiceProcessFee_TEF.PlotSize = decimal.Parse(PlotArea);
                        UC_IAServiceProcessFee_TEF.ServiceRequestNo = ServiceReqNo;
                        UC_IAServiceProcessFee_TEF.ApplicantName = Applicantname;
                        UC_IAServiceProcessFee_TEF.applicantAddress = Address;
                        Placeholder.Controls.Add(UC_IAServiceProcessFee_TEF);

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
                        Placeholder.Controls.Add(UC_IAServiceProcessFee);
                    }

                    //if (ServiceID == "1002")
                    //{
                    //    UC_IAServiceProcessFee_TEF UC_IAServiceProcessFee_TEF = LoadControl("~/UC_IAServiceProcessFee_TEF.ascx") as UC_IAServiceProcessFee_TEF;
                    //    UC_IAServiceProcessFee_TEF.IndustrialArea = Convert.ToInt32(IAID);
                    //    UC_IAServiceProcessFee_TEF.PlotSize = decimal.Parse(PlotArea);
                    //    UC_IAServiceProcessFee_TEF.ServiceRequestNo = ServiceReqNo;
                    //    UC_IAServiceProcessFee_TEF.ApplicantName = Applicantname;
                    //    UC_IAServiceProcessFee_TEF.applicantAddress = Address;
                    //    Placeholder.Controls.Add(UC_IAServiceProcessFee_TEF);

                    //}
                    //else 
                    //{

                    //    UC_IAServiceProcessFeeNMSWP UC_IAServiceProcessFeeNMSWP = LoadControl("~/UC_IAServiceProcessFeeNMSWP.ascx") as UC_IAServiceProcessFeeNMSWP;
                    //    UC_IAServiceProcessFeeNMSWP.IndustrialArea = Convert.ToInt32(IAID);
                    //    UC_IAServiceProcessFeeNMSWP.choicearea = Convert.ToDouble(PlotArea);
                    //    UC_IAServiceProcessFeeNMSWP.AllotmentLetterNo = AllottmentNo;
                    //    UC_IAServiceProcessFeeNMSWP.SWCControlID = SWCControlID;
                    //    UC_IAServiceProcessFeeNMSWP.SWCUnitID    =    SWCUnitID;
                    //    UC_IAServiceProcessFeeNMSWP.SWCServiceID = SWCServiceID;
                    //    UC_IAServiceProcessFeeNMSWP.ServiceRequestNo = ServiceReqNo;
                    //    UC_IAServiceProcessFeeNMSWP.TranID = TraID;
                    //    UC_IAServiceProcessFeeNMSWP.ApplicantName = Applicantname;
                    //    UC_IAServiceProcessFeeNMSWP.applicantAddress = Address;
                    //    Placeholder.Controls.Add(UC_IAServiceProcessFeeNMSWP);


                    //}


                }

                #region By Manish Rastogi Services
                if (Menu_Value1 == "ReconstitutionApplicant_Detail")
                {
                    UC_ReconstitutionFinalViewIAService UC_ReconstitutionFinalViewIAService = LoadControl("~/UC_ReconstitutionFinalViewIAService.ascx") as UC_ReconstitutionFinalViewIAService;
                    UC_ReconstitutionFinalViewIAService.ID = "UC_ReconstitutionFinalViewIAService";
                    UC_ReconstitutionFinalViewIAService.TranID = TraID;
                    UC_ReconstitutionFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                   
                    Placeholder.Controls.Add(UC_ReconstitutionFinalViewIAService);
                }
                if (Menu_Value1 == "handoverofleasedeedtoleaseApplicant_Detail")
                {
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService = LoadControl("~/UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ascx") as UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ID = "UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService";
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.TranID = TraID;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService.ControlID = SWCUnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewJointhandoverofleasedeedtoleaseService);
                }
                if (Menu_Value1 == "ReconstitutionforlegalheirApplicant_Detail")
                {
                    UC_ReconstitutionforlegalheirFinalViewIAService UC_ReconstitutionforlegalheirFinalViewIAService = LoadControl("~/UC_ReconstitutionforlegalheirFinalViewIAService.ascx") as UC_ReconstitutionforlegalheirFinalViewIAService;
                    UC_ReconstitutionforlegalheirFinalViewIAService.ID = "UC_ReconstitutionFinalViewIAService";
                    UC_ReconstitutionforlegalheirFinalViewIAService.TranID = TraID;
                    UC_ReconstitutionforlegalheirFinalViewIAService.ServiceRequestNo = ServiceReqNo;
                    
                    Placeholder.Controls.Add(UC_ReconstitutionforlegalheirFinalViewIAService);
                }
              
                #endregion
                #region NewServiceByManish
                if (Menu_Value1 == "startofproduction_Detail")
                {
                    UC_ApplicationFinalViewStartofProductionCertificate UC_ApplicationFinalViewStartofProductionCertificate = LoadControl("~/UC_ApplicationFinalViewStartofProductionCertificate.ascx") as UC_ApplicationFinalViewStartofProductionCertificate;
                    UC_ApplicationFinalViewStartofProductionCertificate.ID = "UC_ApplicationFinalViewStartofProductionCertificate";
                    UC_ApplicationFinalViewStartofProductionCertificate.TranID = TraID;
                    UC_ApplicationFinalViewStartofProductionCertificate.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewStartofProductionCertificate.ControlID = SWCUnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewStartofProductionCertificate);
                }

                #region PlotCancelation

                if (Menu_Value1 == "Notice_Detail")
                {
                    UC_NoticeDetails UC_NoticeDetails = LoadControl("~/UC_NoticeDetails.ascx") as UC_NoticeDetails;
                    UC_NoticeDetails.ID = "UC_NoticeDetails";
                    UC_NoticeDetails.ServiceReqNo = ServiceReqNo;
                    //UC_Appontments.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_NoticeDetails);
                }
                if (Menu_Value1 == "CreateNotice")
                {
                    UC_CreateNoticeforCancelation UC_CreateNoticeforCancelation = LoadControl("~/UC_CreateNoticeforCancelation.ascx") as UC_CreateNoticeforCancelation;
                    UC_CreateNoticeforCancelation.ID = "UC_CreateNoticeforCancelation";
                    UC_CreateNoticeforCancelation.ServiceReqNo = ServiceReqNo;

                    UC_CreateNoticeforCancelation.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_CreateNoticeforCancelation);
                }
                #endregion
                #endregion

                #region NewServiceManishShukla
                if (Menu_Value1 == "NewServiceCommon_Detail")
                {
                    UC_ApplicationFinalViewIAServiceModule1 UC_ApplicationFinalViewIAServiceModule1 = LoadControl("~/UC_ApplicationFinalViewIAServiceModule1.ascx") as UC_ApplicationFinalViewIAServiceModule1;
                    UC_ApplicationFinalViewIAServiceModule1.ID = "UC_ApplicationFinalViewIAServiceModule1";
                    UC_ApplicationFinalViewIAServiceModule1.TranID = TraID;
                    UC_ApplicationFinalViewIAServiceModule1.ServiceRequestNo = ServiceReqNo;
                    UC_ApplicationFinalViewIAServiceModule1.ControlID = UnitID;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewIAServiceModule1);
                }
                #endregion
            }
        }


        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue);
            ServiceReqNo = ddlApplicant.SelectedValue.Trim();
            MenuMaker();
            sub_menu.Items[0].Selected = true;
        }




        protected void btnPrint_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);

        }


        private void SendMailUPSIDC()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("select * from ApplicationRegister where ApplicationId='" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string TempID = dt.Rows[0]["TempApplicationID"].ToString();


                    MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    newmsg.IsBodyHtml = true;
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application is marked for clarification.Kindly check and resubmit your application with proper documents and information");
                    StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/LandAllotmentApplication.aspx?ServiceReqNo=" + TempID + "&App=Resubmit");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Land Allotment ";
                    newmsg.Body = StrContent;


                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    smtp.EnableSsl = true;
                    smtp.Send(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Application has been sent to you for resubmission kindly resubmit your application with proper documents and information.Link has been send to your registered mailid");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , "7275379286"},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SendMailUPSIDCBuildingPlan()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('|');
                SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where AllotteeID='" + SerIdarray[2] + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["emailID"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();



                    MailAddress mailfrom = new MailAddress("eodbupsidc@gmail.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    newmsg.IsBodyHtml = true;
                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ApplicantResubmissionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Description}", "Dear Applicant<br/>Your Application for building plan approval is marked for clarification.Kindly check and resubmit your application with proper documents and information");
                    StrContent = StrContent.Replace("{Link}", "");



                    newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to resubmit application for Land Allotment ";
                    newmsg.Body = StrContent;


                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                    smtp.EnableSsl = true;
                    smtp.Send(newmsg);


                    string resultmsg = "";

                    String message = HttpUtility.UrlEncode("Dear Applicant Your Application for building plan has been sent to you for resubmission kindly resubmit your application with proper documents and information");
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                        {
                                        {"apikey" , "TbIdfHxlcnI-v4mZxxaxr3NG9H79eLuf0Fe0PRUhfF"},
                                        {"numbers" , "7275379286"},
                                        {"message" , message}
                        //              {"sender" , "UPSIDC"}
                                        });
                        resultmsg = System.Text.Encoding.UTF8.GetString(response);

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void InspectionfreportViewer()
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
            ds = objServiceTimelinesBLL.GetInspectionReport(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {
                if (dtDoc.Rows[0]["Documents"].ToString().Length > 0)
                {

                    string contype = dtDoc.Rows[0]["ContentType"].ToString().Trim();

                    string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""600px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/DocViewerMinutes.ashx?ServiceRequestNO=" + ServiceReqNo.Trim() + "")));

                    //    Placeholder.Controls.Clear();
                    Placeholder.Controls.Add(ltEmbed);
                }
                else
                {
                    Literal ltEmbed = new Literal();
                    ltEmbed.Text = "<h3>No Supporting Document Available</h3>";
                    Placeholder.Controls.Add(ltEmbed);
                }
            }
        }

        public void View_Ledger(string Par)
        {

            Placeholder.Controls.Clear();
            UC_Allottee_Ledger UC_Allottee_Ledger = LoadControl("~/UC_Allottee_Ledger.ascx") as UC_Allottee_Ledger;
            UC_Allottee_Ledger.ID = "UC_Allottee_Ledger";
            UC_Allottee_Ledger.ServiceReqNo = ServiceReqNo;
            UC_Allottee_Ledger.Page_Load(null, null);
            UC_Allottee_Ledger.EnableViewState = false;
            Placeholder.Controls.Add(UC_Allottee_Ledger);
            ViewState["sub_menu"] = "page|Allottee_Ledger";
        }
        public void View_Objection(string Par)
        {

            Placeholder.Controls.Clear();
            UC_RaiseDemandPlusObjection UC_RaiseDemandPlusObjection = LoadControl("~/UC_RaiseDemandPlusObjection.ascx") as UC_RaiseDemandPlusObjection;
            UC_RaiseDemandPlusObjection.ID = "UC_RaiseDemandPlusObjection";
            UC_RaiseDemandPlusObjection.ServiceReqNo = ServiceReqNo;
            UC_RaiseDemandPlusObjection.Page_Load(null, null);
            UC_RaiseDemandPlusObjection.EnableViewState = false;
            Placeholder.Controls.Add(UC_RaiseDemandPlusObjection);
            ViewState["sub_menu"] = "page|Raise_Objection";

        }
    }
}