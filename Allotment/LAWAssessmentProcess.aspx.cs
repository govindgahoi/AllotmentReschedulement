
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

namespace Allotment
{
    public partial class LAWAssessmentProcess : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        string string_val = "";
        string string_text = "";


        delegate void USerControl();



        string UserName = "", ServiceReqNo = "";
        int UserId = 0;

        #endregion


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                ServiceReqNo      = (Request.QueryString["ServiceReqNo"]);
                con               = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and ActiveStatus=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {


                }
                if (!IsPostBack)
                {

                    MenuMaker();
                    string_val  = sub_menu.Items[0].Value;
                    string_text = sub_menu.Items[0].Text;
                    ViewState["sub_menu"]      = string_val;
                    ViewState["sub_menu_text"] = string_text;
                    //sub_menu.Items[0].Selected = true;
                    //sub_menu_MenuItemClick(null, null);
                }
                load_UC("ALL");

            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx", false);
            }













        }



        #region LeftMenu
        protected void MenuMaker()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetLAWDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ID = dt.Rows[0]["ApplicantId"].ToString();
                    string IsCompleted = dt.Rows[0]["isCompleted"].ToString();
                    string IsRejected = dt.Rows[0]["isRejected"].ToString();
                    sub_menu.Items.Clear();
                    sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                    CheklistBind(1, ServiceReqNo);

                    sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                    sub_menu.Items.Add(new MenuItem { Value = "page|Objections",      Text = "Objections"       });
                    sub_menu.Items.Add(new MenuItem { Value = "page|MeetingMinutes",  Text = "Meeting Minutes"  });
                    if (IsRejected == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Rejection", Text = "Rejection Letter" });
                    }
                    if (IsCompleted == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|LOA", Text = "LOA" });
                    }
                    sub_menu.DataBind();
                }
            }
            catch (Exception)
            {

            }

        }

        protected void sub_menu_MenuItemClick(object sender, MenuEventArgs e)
        {          
           
            try
            {
                try
                {

                    string_val = (e.Item.Value.ToString().Trim());
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

                foreach (MenuItem item in sub_menu.Items)
                {
                    if (string_text == item.Text)
                    {
                        item.Selected = true;
                    }
                }
                load_UC("ALL");
            }
            catch
            {

            }
        }



        protected void CheklistBind(int ServiceID, string ServicereqNo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new GeneralMethod().EvaluationCheklistBindLAW(ServicereqNo);

                int UniqueNo = ServiceID;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        string Menu_Text = dr["ServiceTimeLinesDocuments"].ToString().Trim();
                        string ServiceCheckListsID = (dr["ServiceCheckListsID"].ToString().Trim()).Trim();

                        string Menu_Val = "doc|" + ServiceCheckListsID + "|" + (dr["DocumentID"].ToString().Trim()).Trim();
                        sub_menu.Items.Add(new MenuItem { Value = Menu_Val, Text = Menu_Text });
                    }
                }
            }


            catch { }
        }

        #endregion

        #region DocumentReletedProcessing&View



        protected void DocumentViewer(string DocumentID)
        {

            DataSet ds = new DataSet();
            objServiceTimelinesBEL.DocumentID = DocumentID;
            ds = objServiceTimelinesBLL.GetLAWDocumentByID(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string Path = dtDoc.Rows[0]["Path"].ToString().Trim();
                string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"600px\">";
                embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                embed += "</object>";
                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl(Path.Trim())));
                Placeholder.Controls.Add(ltEmbed);
            }
        }


        #endregion



        protected void load_UC(string AllOrFirst)
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
                if (Menu_Type == "doc")
                {
                    
                    
                    Menu_Value2 = SerIdarray[2];
                    string ServiceCheckListsID = Menu_Value1;
                    string doc_id = Menu_Value2;

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

                if (Menu_Type == "page")
                {
                   

                    if (Menu_Value1 == "Applicant_Detail")
                    {
                        UC_ApplicationFinalViewLAW UC_ApplicationFinalViewLAW = LoadControl("~/UC_ApplicationFinalViewLAW.ascx") as UC_ApplicationFinalViewLAW;
                        UC_ApplicationFinalViewLAW.ID = "UC_ApplicationFinalViewLAW";
                        UC_ApplicationFinalViewLAW.ServiceRequestNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_ApplicationFinalViewLAW);
                    }

                    if (Menu_Value1 == "Correspondence_Detail")
                    {
                        UC_OutsideCorrespondenceLAW UC_OutsideCorrespondenceLAW = LoadControl("~/UC_OutsideCorrespondenceLAW.ascx") as UC_OutsideCorrespondenceLAW;
                        UC_OutsideCorrespondenceLAW.ID = "UC_OutsideCorrespondenceLAW";
                        UC_OutsideCorrespondenceLAW.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_OutsideCorrespondenceLAW);
                    }
                    if (Menu_Value1 == "Transfer_Application")
                    {
                        UC_TransferLAWApplication UC_TransferLAWApplication = LoadControl("~/UC_TransferLAWApplication.ascx") as UC_TransferLAWApplication;
                        UC_TransferLAWApplication.ID = "UC_TransferLAWApplication";
                        UC_TransferLAWApplication.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_TransferLAWApplication);
                    }
                    if (Menu_Value1 == "Comments_Detail")
                    {
                        UC_CommentsLaw UC_CommentsLaw = LoadControl("~/UC_CommentsLaw.ascx") as UC_CommentsLaw;
                        UC_CommentsLaw.ID = "UC_CommentsLaw";
                        UC_CommentsLaw.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_CommentsLaw);
                        
                    }
                    if (Menu_Value1 == "Comments")
                    {
                        UC_TransferLAWCommentsEntry UC_TransferLAWCommentsEntry = LoadControl("~/UC_TransferLAWCommentsEntry.ascx") as UC_TransferLAWCommentsEntry;
                        UC_TransferLAWCommentsEntry.ID = "UC_TransferLAWCommentsEntry";
                        UC_TransferLAWCommentsEntry.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_TransferLAWCommentsEntry);

                    }
                    if (Menu_Value1 == "Objections")
                    {
                        UC_ObjectionsLAW UC_ObjectionsLAW = LoadControl("~/UC_ObjectionsLAW.ascx") as UC_ObjectionsLAW;
                        UC_ObjectionsLAW.ID = "UC_ObjectionsLAW";
                        UC_ObjectionsLAW.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_ObjectionsLAW);

                    }
                    if (Menu_Value1 == "MeetingMinutes")
                    {
                        UC_MeetingMinutesLawDetails UC_MeetingMinutesLawDetails = LoadControl("~/UC_MeetingMinutesLawDetails.ascx") as UC_MeetingMinutesLawDetails;
                        UC_MeetingMinutesLawDetails.ID = "UC_MeetingMinutesLawDetails";
                        UC_MeetingMinutesLawDetails.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_MeetingMinutesLawDetails);

                    }

                    if (Menu_Value1 == "Rejection" || Menu_Value1 == "LOA")
                    {
                        DataSet ds = new DataSet();
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        ds = objServiceTimelinesBLL.GetLAWDetails(objServiceTimelinesBEL);
                        DataTable dtDoc = ds.Tables[0];

                        if (dtDoc != null)
                        {

                            string Path = dtDoc.Rows[0]["DocPath"].ToString().Trim();
                            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"600px\">";
                            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                            embed += "</object>";
                            Literal ltEmbed = new Literal();
                            ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl(Path.Trim())));
                            Placeholder.Controls.Add(ltEmbed);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}