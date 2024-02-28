using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class ReportGenration : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail;
        UC_Service_Applicant_Detail UC_Service_Applicant_Detail;
        UC_Assesment_Entry_Allotment UC_Assesment_Entry_Allotment;
        UC_Assesment_Entry_BP UC_Assesment_Entry_BP;
        UC_DataFacts UC_DataFacts;
        UC_Document_Report_VG UC_Document_Report_VG;


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
                case "1000":
                    {
                        ////////  Plot Allotement 
                        //sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Choose Plot" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Issue Allotment Letter" });
                        sub_menu.DataBind();
                        break;
                    }


                case "1001":
                    {
                        ////////  Plot Cancelation 

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }




                case "4":
                    {
                        //////// Plot Transfer 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Transferor Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Transfree Detail", NavigateUrl = "" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });

                        sub_menu.DataBind();
                        break;
                    }

                case "1":
                case "2":
                    {
                        //////////   Building Plan Construction / Complition 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "3001":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "4002":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "5003":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {
                        //////////////   Other 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Applicant Detail" });
                        //    sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Allottee Detail" });
                        //  CheklistBind(ServiceID, ServiceReqNo);

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

                if (Menu_Value1 == "Applicant_Detail")
                {
                    UC_Service_Applicant_Detail = LoadControl("~/UC_Service_Applicant_Detail.ascx") as UC_Service_Applicant_Detail;
                    UC_Service_Applicant_Detail.ServiceReqNo = ServiceReqNo;

                    UC_Service_Applicant_Detail.ID = "UC_Service_Applicant_DetailID";
                    Placeholder.Controls.Add(UC_Service_Applicant_Detail);
                }


                if (Menu_Value1 == "Data_Facts")
                {
                    UC_DataFacts = LoadControl("~/UC_DataFacts.ascx") as UC_DataFacts;
                    UC_DataFacts.ServiceRequestNo = ServiceReqNo;

                    UC_DataFacts.ID = "UC_DataFactsId";

                    Placeholder.Controls.Add(UC_DataFacts);

                }

                if (Menu_Value1 == "Report_View_Genrate")
                {

                    UC_Document_Report_VG = LoadControl("~/UC_Document_Report_VG.ascx") as UC_Document_Report_VG;
                    UC_Document_Report_VG.SerRequestNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_Document_Report_VG);
                }


            }

        }


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