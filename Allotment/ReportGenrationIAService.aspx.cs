using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using System.Data;

namespace Allotment
{
    public partial class ReportGenrationIAService : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail;
        UC_DataFactsIAService UC_DataFactsIAService;
        UC_Document_Report_VG_IA_Service UC_Document_Report_VG_IA_Service;


        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            string Applicant = Request.QueryString["ServiceReqNo"];
            string PacketID = Request.QueryString["PacketId"];

            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Applicant))
                    {
                        ddlApplicant.Items.Add(new ListItem(Applicant, Applicant));
                        GeneralMethod gm = new GeneralMethod();
                        if ((PacketID == string.Empty) || (PacketID == null))
                        {
                            IAID = gm.Get_IAID_ByServiceRequstNo(ddlApplicant.SelectedValue);
                        }
                        else { IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue); }
                    }
                }
                catch
                {


                }
            }


            ServiceReqNo = ddlApplicant.SelectedValue.Trim();


            string[] SerArray = ServiceReqNo.Split('/');
            ServiceID = int.Parse(SerArray[1]);
            ApplicantId = int.Parse(SerArray[2]);


            if (!IsPostBack)
            {
                ViewState["sub_menu"] = "";
                ViewState["sub_menu_text"] = "";

                ddlApplicant_SelectedIndexChanged(null, null);   // also call  MenuMaker();

                sub_menu_MenuItemClick(null, null);

            }


            load_UC();

        }

        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            string PacketID = Request.QueryString["PacketId"];

            if ((PacketID == string.Empty) || (PacketID == null))
            {
                IAID = gm.Get_IAID_ByServiceRequstNo(ddlApplicant.SelectedValue);
            }
            else { IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue); }



            ServiceReqNo = ddlApplicant.SelectedValue.Trim();
            MenuMaker();

            sub_menu.Items[0].Selected = true;
            sub_menu_MenuItemClick(null, null);

        }


        protected void MenuMaker()
        {
            sub_menu.Items.Clear();

            switch (ServiceID.ToString())
            {
                case "1003":
                    {
                        //////////   Change Of Project ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1004":
                    {
                        //////////   Change Of Project ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1009":
                    {
                        //////////   Change Of Project ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1010":
                    {
                        //////////   Change Of Project ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1005":
                    {
                        //////////   Noc Mortgage 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1006":
                    {
                        //////////   Joint Mortgage 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1007":
                    {
                        //////////   Second Charge 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                case "1011":
                    {
                        //////////   Second Charge 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1029":
                    {
                        //////////   Second Charge 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate1", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1030":
                    {
                        //////////   Second Charge 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1002":
                    {
                        //////////   Time Extension Fees 


                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "TEF Data Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Issue TEF Letter" });

                        sub_menu.DataBind();
                        break;
                    }
                #region services Add by manish Rastogi
                case "1008":
                    {
                        //////////  Reconstruction   ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1017":
                    {
                        //////////   Hand over Lease deed ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1021":
                    {
                        //////////   Reconstruction for legal hier ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1022":
                    {
                        //////////   water Connection ////////
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                #endregion
                case "1014":
                    {
                        //////////   Start of Production Certificate 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1013":
                    {
                        //////////   Plot Cancelation 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                #region services Add by ManishShukla NewService
                case "1012":
                    {
                        //////////   Second Charge 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1024":
                    {
                        //////////   Time Extension Fees 


                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "TEF Data Details" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Issue TEF Letter" });

                        sub_menu.DataBind();
                        break;
                    }
                case "1025":
                    {
                        //////////   Start of Production Certificate 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1026":
                    {
                        //////////   Plot Cancelation 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1023":
                    {
                        //////////   No Dues Certificate 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Issue No Dues Certificate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1027":
                    {
                        ////////  Outstanding Dues Certificate 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Issue Oustanding Dues Certificate" });
                        sub_menu.DataBind();
                        break;
                    }


                #endregion

                default:
                    {

                        sub_menu.DataBind();
                        break;
                    }
            }
        }


        protected void load_UC()
        {

            Placeholder.Controls.Clear();



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
            catch { }


            if (Menu_Type == "doc")
            {

                if (Menu_Value2.Length > 0)
                {
                    //    DocumentViewer(Menu_Value2);
                    //    GET_ServiceRequestDoc_Status(ServiceReqNo, Menu_Value2);
                    //     div_doc_status.Visible = true;
                }
                else
                {
                }
            }



            if (Menu_Type == "page")
            {

                if (Menu_Value1 == "Allottee_Detail")
                {
                    UC_Service_Allotteee_Detail = LoadControl("~/UC_Service_Allotteee_Detail.ascx") as UC_Service_Allotteee_Detail;
                    UC_Service_Allotteee_Detail.AllotteeId = ApplicantId.ToString();
                    UC_Service_Allotteee_Detail.ID = "UC_Service_Allotteee_DetailID";
                    Placeholder.Controls.Add(UC_Service_Allotteee_Detail);
                }

                if (Menu_Value1 == "Data_Facts")
                {
                    UC_DataFactsIAService = LoadControl("~/UC_DataFactsIAService.ascx") as UC_DataFactsIAService;
                    UC_DataFactsIAService.ServiceRequestNo = ServiceReqNo;

                    UC_DataFactsIAService.ID = "UC_DataFactsIAService";

                    Placeholder.Controls.Add(UC_DataFactsIAService);

                }

                if (Menu_Value1 == "Report_View_Genrate")
                {

                    UC_Document_Report_VG_IA_Service = LoadControl("~/UC_Document_Report_VG_IA_Service.ascx") as UC_Document_Report_VG_IA_Service;
                    UC_Document_Report_VG_IA_Service.SerRequestNo = ServiceReqNo;
                    UC_Document_Report_VG_IA_Service.ID = "UC_Document_Report_VG_IA_Service";
                    Placeholder.Controls.Add(UC_Document_Report_VG_IA_Service);
                }
                if (Menu_Value1 == "Report_View_Genrate1")
                {
                    
                    UC_Document_Report_VG_IA_Service = LoadControl("~/UC_Document_Report_VG_IA_Service.ascx") as UC_Document_Report_VG_IA_Service;
                    UC_Document_Report_VG_IA_Service.SerRequestNo = ServiceReqNo;
                    UC_Document_Report_VG_IA_Service.ID = "UC_Document_Report_VG_IA_Service";
                    Placeholder.Controls.Add(UC_Document_Report_VG_IA_Service);
                }


            }

        }


        //protected void UpdatePlotNo(object sender, EventArgs e)
        //{
        //    string serNo = ServiceReqNo;
        //    string plotNo = txtPlotNo.Text.Trim();
        //    if (txtPlotNo.Text.Trim() == "")
        //    {
        //        Response.Write("<script>alert('Invalid Detail. Please mention correct information. ')</script>");
        //    }
        //    else
        //    {

        //        DateTime now = DateTime.Now;
        //        SqlCommand cmd = new SqlCommand("usp_UpdateAmalgmationPlotNo", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ServiceReqNo", serNo);
        //        cmd.Parameters.AddWithValue("@PlotNo", txtPlotNo.Text);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        popup.Hide();
        //        UC_Document_Report_VG_IA_Service = LoadControl("~/UC_Document_Report_VG_IA_Service.ascx") as UC_Document_Report_VG_IA_Service;
        //        UC_Document_Report_VG_IA_Service.SerRequestNo = ServiceReqNo;
        //        UC_Document_Report_VG_IA_Service.ID = "UC_Document_Report_VG_IA_Service";
        //        Placeholder.Controls.Add(UC_Document_Report_VG_IA_Service);
        //    }
        //    }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {
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
                //     drpRemarks.Text = "";
            }



            foreach (MenuItem item in sub_menu.Items)
            {
                if (string_text == item.Text)
                {
                    item.Selected = true;
                }
            }


            load_UC();

        }



    }
}