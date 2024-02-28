using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using NReco.PdfGenerator;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using QRCoder;
using System.Drawing;

namespace Allotment
{
	public partial class ReportGenrationIANotice : System.Web.UI.Page
	{
		
		#region "Create and Initialize objects "
		belBookDetails objServiceTimelinesBEL = new belBookDetails();
		BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
		SqlConnection con;
        #endregion


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail;
        UC_DataFactsIANotice UC_DataFactsIANotice;
        UC_Document_Report_VG_IA_Notice UC_Document_Report_VG_IA_Notice;


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
                        if ((PacketID==string.Empty)||(PacketID==null))
                            { 
						IAID = gm.Get_IAID_ByServiceRequstNo(ddlApplicant.SelectedValue);
                        }else { IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue); }
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
			sub_menu_MenuItemClick(null,null);

		}

		
		protected void MenuMaker()
		{
			sub_menu.Items.Clear();

            switch (ServiceID.ToString())
			{
                
                case "1013":
                    {
                        //////////   Plot Cancelation Notice

                        sub_menu.Items.Add(new MenuItem { Value = "page|Data_Facts", Text = "Add Clauses" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Report_View_Genrate", Text = "Report View & Generate" });
                        sub_menu.DataBind();
                        break;
                    }
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
                    UC_DataFactsIANotice = LoadControl("~/UC_DataFactsIANotice.ascx") as UC_DataFactsIANotice;
                    UC_DataFactsIANotice.ServiceRequestNo = ServiceReqNo;

                    UC_DataFactsIANotice.ID = "UC_DataFactsIANotice";

                    Placeholder.Controls.Add(UC_DataFactsIANotice);
			   
				}
				
				if (Menu_Value1 == "Report_View_Genrate")
				{

                    UC_Document_Report_VG_IA_Notice = LoadControl("~/UC_Document_Report_VG_IA_Notice.ascx") as UC_Document_Report_VG_IA_Notice;
                    UC_Document_Report_VG_IA_Notice.SerRequestNo = ServiceReqNo;
                    UC_Document_Report_VG_IA_Notice.ID = "UC_Document_Report_VG_IA_Notice";
                    Placeholder.Controls.Add(UC_Document_Report_VG_IA_Notice);
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