using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class RejectionLetterGeneration : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion

        UC_RejectionLetterDataFacts UC_RejectionLetterDataFacts;
        UC_IssueRejectionLetter UC_IssueRejectionLetter;


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
                catch (Exception ex)
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
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "2":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "3":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "4":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1003":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Letter View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1004":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Letter View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1009":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Letter View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1010":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Letter View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1002":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1005":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1006":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1007":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1011":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;

                    }
                case "1023":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1014":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "1001":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                case "1008":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                //handoverofleasedeedtolease

                case "1017":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                //RecognitionoftheLegalHeir
                case "1021":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //WaterConnection
                case "1022":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                //PlotCancelation
                case "1013":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
             
                //Restorationofplot
                case "1012":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //SurrenderofPlot
                case "1024":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //AdditionalUnit
                case "1025":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //SublettingofPlot
                case "1026":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //Outstanding Dues Position
                case "1027":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //Amalgamation Post Allotment
                case "1029":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                //Subdivision Post Allotment
                case "1030":
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Data Facts & Preview" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {
                        //////////////   Other 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Applicant Detail" });

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


            }
            catch (Exception ex) { }





            if (Menu_Type == "page")
            {




                if (Menu_Value1 == "Data_Facts")
                {
                    UC_RejectionLetterDataFacts = LoadControl("~/UC_RejectionLetterDataFacts.ascx") as UC_RejectionLetterDataFacts;
                    UC_RejectionLetterDataFacts.ServiceRequestNo = ServiceReqNo;
                    UC_RejectionLetterDataFacts.ID = "UC_RejectionLetterDataFacts";

                    Placeholder.Controls.Add(UC_RejectionLetterDataFacts);
                }

                if (Menu_Value1 == "Report_View_Genrate")
                {

                    UC_IssueRejectionLetter = LoadControl("~/UC_IssueRejectionLetter.ascx") as UC_IssueRejectionLetter;
                    UC_IssueRejectionLetter.SerRequestNo = ServiceReqNo;
                    UC_IssueRejectionLetter.ID = "UC_IssueRejectionLetter";



                    Placeholder.Controls.Add(UC_IssueRejectionLetter);
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