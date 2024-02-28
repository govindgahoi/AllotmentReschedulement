using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class DocAck : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion



        UC_Doc_ack UC_Doc_ack;
        UC_Ack_Genrate_Slip UC_Ack_Genrate_Slip;
        UC_JEUploadPossession UC_JEUploadPossession;


        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0;

        string AppType = "", DocId = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            string Applicant = Request.QueryString["ServiceReqNo"];
            AppType = Request.QueryString["AppType"];
            DocId = Request.QueryString["DocID"];

            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Applicant))
                    {
                        ddlApplicant.Items.Add(new ListItem(Applicant, Applicant));
                        GeneralMethod gm = new GeneralMethod();

                        IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue);
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

            IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue);



            ServiceReqNo = ddlApplicant.SelectedValue.Trim();
            MenuMaker();

            sub_menu.Items[0].Selected = true;
            sub_menu_MenuItemClick(null, null);

        }


        protected void MenuMaker()
        {
            sub_menu.Items.Clear();

            switch (AppType.ToString())
            {

                case "1":
                    {

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Content" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Generate Slip" });
                        sub_menu.DataBind();
                        break;
                    }
                case "2":
                    {

                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "3":
                    {

                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
                case "4":
                    {

                        sub_menu.Items.Add(new MenuItem { Value = "page|Possession_Data", Text = "Possession Details" });
                        sub_menu.DataBind();
                        break;
                    }

                default:
                    {

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
                Menu_Value2 = SerIdarray[2];

            }
            catch { }





            if (Menu_Type == "page")
            {


                if (Menu_Value1 == "Data_Facts")
                {
                    UC_Doc_ack = LoadControl("~/UC_Doc_ack.ascx") as UC_Doc_ack;
                    UC_Doc_ack.ServiceRequestNo = ServiceReqNo;
                    UC_Doc_ack.AppTypeID = AppType;
                    UC_Doc_ack.ID = "UC_Doc_ack";

                    UC_Doc_ack.Page_Load(null, null);
                    Placeholder.Controls.Add(UC_Doc_ack);

                }

                if (Menu_Value1 == "Report_View_Genrate")
                {

                    UC_Ack_Genrate_Slip = LoadControl("~/UC_Ack_Genrate_Slip.ascx") as UC_Ack_Genrate_Slip;
                    UC_Ack_Genrate_Slip.SerRequestNo = ServiceReqNo;
                    UC_Ack_Genrate_Slip.AppTypeID = AppType;
                    UC_Ack_Genrate_Slip.DocID = DocId;
                    UC_Ack_Genrate_Slip.ID = "UC_Ack_Genrate_Slip";

                    Placeholder.Controls.Add(UC_Ack_Genrate_Slip);
                }

                if (Menu_Value1 == "Possession_Data")
                {

                    UC_JEUploadPossession = LoadControl("~/UC_JEUploadPossession.ascx") as UC_JEUploadPossession;
                    UC_JEUploadPossession.ServiceReqNo = ServiceReqNo;
                    UC_JEUploadPossession.DocID = DocId;
                    UC_JEUploadPossession.ID = "UC_JEUploadPossession";
                    Placeholder.Controls.Add(UC_JEUploadPossession);
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
        public void MessagePlusRedirectTransfer(string Par, string Par1)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessagePlusRedirectTransfer('" + Par + "','" + Par1 + "');", true);
        }
        public void MessagePlusRedirect(string Par, string Par1)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessagePlusRedirect('" + Par + "','" + Par1 + "');", true);
        }
        public void AllertRedirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessagePlusRedirect1('" + Par + "');", true);
        }
    }
}