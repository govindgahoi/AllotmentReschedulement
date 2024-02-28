
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
    public partial class PIPFINAssessment : System.Web.UI.Page
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
                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

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
                    string_val = sub_menu.Items[0].Value;
                    string_text = sub_menu.Items[0].Text;
                    ViewState["sub_menu"] = string_val;
                    ViewState["sub_menu_text"] = string_text;
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
                ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    string ID = dt.Rows[0]["AllotteeId"].ToString();
                    string IsCompleted = dt.Rows[0]["isCompleted"].ToString();
                    string IsRejected = dt.Rows[0]["isRejected"].ToString();
                    sub_menu.Items.Clear();

                    string MMCount = "";
                    string IDCount = "";
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select * from tbl_MeetingMinutesPIP where statusMOM = '1' and ServiceRequestNo ='" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dtM = new DataTable();
                    adp.Fill(dtM);
                    if (dtM.Rows.Count > 0)
                    {
                        MMCount = "1";
                    }
                    else
                    {
                        MMCount = "0";
                    }

                    SqlCommand cmd1 = new SqlCommand("select * from ServiceRequest_Track_PIP where Transfer_From ='MD@UPSIDC' and FromUser ='MD@UPSIDC' and Status = 'Approve' and ServiceId ='" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                    DataTable dtM1 = new DataTable();
                    adp1.Fill(dtM1);
                    if (dtM1.Rows.Count > 0)
                    {
                        IDCount = "1";
                    }
                    else
                    {
                        IDCount = "0";
                    }


                    if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Document_Detail", Text = "Documents" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Meeting_Minutes", Text = "Meeting Minutes" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Objection", Text = "Raise Objection" });

                        if (IDCount == "1")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Issue_Letter", Text = "Issue Letter" });
                        }

                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transfer_Application", Text = "Transfer Application" });
                        /*
                        if (IsRejected == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Rejection", Text = "Rejection Letter" });
                        }
                        if (IsCompleted == "True")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|LOA", Text = "LOA" });
                        }
                        */
                    }
                    else if (Convert.ToString(Session["UserName"]) == "aceo_a")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Document_Detail", Text = "Documents" });
                        if (MMCount == "1")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Meeting_Minutes", Text = "Meeting Minutes" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Objection", Text = "Raise Objection" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transfer_Application", Text = "Transfer Application" });
                    }
                    else if (Convert.ToString(Session["UserName"]) == "MD@UPSIDC")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Document_Detail", Text = "Documents" });
                        if (MMCount == "1")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Meeting_Minutes", Text = "Meeting Minutes" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Objection", Text = "Raise Objection" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transfer_Application", Text = "Transfer Application" });
                    }
                    else
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        sub_menu.Items.Add(new MenuItem { Value = "page|Document_Detail", Text = "Documents" });
                        if (MMCount == "1")
                        {
                            sub_menu.Items.Add(new MenuItem { Value = "page|Meeting_Minutes", Text = "Meeting Minutes" });
                        }
                        sub_menu.Items.Add(new MenuItem { Value = "page|Transfer_Application", Text = "Transfer Application" });
                    }

                    /*
                    sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });

                    sub_menu.Items.Add(new MenuItem { Value = "page|Document_Detail", Text = "Documents" });

                    sub_menu.Items.Add(new MenuItem { Value = "page|Meeting_Minutes", Text = "Meeting Minutes" });

                    
                    sub_menu.Items.Add(new MenuItem { Value = "page|Objection", Text = "Raise Objection" });
                    if (Convert.ToString(Session["UserName"]) == "KN_Srivastava")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Issue_Letter", Text = "Issue Letter" });
                    }
                    sub_menu.Items.Add(new MenuItem { Value = "page|Comments_Detail", Text = "View Preceedings" });
                    sub_menu.Items.Add(new MenuItem { Value = "page|Transfer_Application", Text = "Transfer Application" });
                    if (IsRejected == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|Rejection", Text = "Rejection Letter" });
                    }
                    if (IsCompleted == "True")
                    {
                        sub_menu.Items.Add(new MenuItem { Value = "page|LOA", Text = "LOA" });
                    }
                    */

                    //CheklistBind(1, ServiceReqNo);
                    /* Sunil
                     sub_menu.Items.Add(new MenuItem { Value = "page|Correspondence_Detail", Text = "Correspondence Detail Entry" });
                     */
                    /* Sunil
                    sub_menu.Items.Add(new MenuItem { Value = "page|Evaluation", Text = "Evaluation" });
                    */


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
                dt = new GeneralMethod().EvaluationCheklistBindPIP(ServicereqNo);

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
            ds = objServiceTimelinesBLL.GetPIPDocumentByID(objServiceTimelinesBEL);
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
                        UC_ApplicationFinalViewPIP_AFA UC_ApplicationFinalViewPIP_AFA = LoadControl("~/UC_ApplicationFinalViewPIP_AFA.ascx") as UC_ApplicationFinalViewPIP_AFA;
                        UC_ApplicationFinalViewPIP_AFA.ID = "UC_ApplicationFinalViewPIP_AFA";
                        UC_ApplicationFinalViewPIP_AFA.ServiceRequestNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_ApplicationFinalViewPIP_AFA);

                    }

                    if (Menu_Value1 == "Document_Detail")
                    {
                        UC_DocumentFinalViewPIPFIN UC_DocumentFinalViewPIPFIN = LoadControl("~/UC_DocumentFinalViewPIPFIN.ascx") as UC_DocumentFinalViewPIPFIN;
                        UC_DocumentFinalViewPIPFIN.ID = "UC_DocumentFinalViewPIPFIN";
                        UC_DocumentFinalViewPIPFIN.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_DocumentFinalViewPIPFIN);
                    }

                    if (Menu_Value1 == "Correspondence_Detail")
                    {
                        UC_OutsideCorrespondencePIP UC_OutsideCorrespondencePIP = LoadControl("~/UC_OutsideCorrespondencePIP.ascx") as UC_OutsideCorrespondencePIP;
                        UC_OutsideCorrespondencePIP.ID = "UC_OutsideCorrespondencePIP";
                        UC_OutsideCorrespondencePIP.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_OutsideCorrespondencePIP);
                    }
                    if (Menu_Value1 == "Transfer_Application")
                    {
                        UC_TransferPIPApplication UC_TransferPIPApplication = LoadControl("~/UC_TransferPIPApplication.ascx") as UC_TransferPIPApplication;
                        UC_TransferPIPApplication.ID = "UC_TransferPIPApplication";
                        UC_TransferPIPApplication.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_TransferPIPApplication);
                    }
                    if (Menu_Value1 == "Comments_Detail")
                    {
                        UC_CommentsPIP UC_CommentsPIP = LoadControl("~/UC_CommentsPIP.ascx") as UC_CommentsPIP;
                        UC_CommentsPIP.ID = "UC_CommentsPIP";
                        UC_CommentsPIP.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_CommentsPIP);

                    }
                    if (Menu_Value1 == "Objection")
                    {
                        UC_RaiseObjectionPIP UC_RaiseObjectionPIP = LoadControl("~/UC_RaiseObjectionPIP.ascx") as UC_RaiseObjectionPIP;
                        UC_RaiseObjectionPIP.ID = "UC_RaiseObjectionPIP";
                        UC_RaiseObjectionPIP.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_RaiseObjectionPIP);
                    }
                    if (Menu_Value1 == "Meeting_Minutes")
                    {
                        UC_MeetingMinutesPIP UC_MeetingMinutesPIP = LoadControl("~/UC_MeetingMinutesPIP.ascx") as UC_MeetingMinutesPIP;
                        UC_MeetingMinutesPIP.ID = "UC_RaiseObjectionPIP";
                        UC_MeetingMinutesPIP.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_MeetingMinutesPIP);
                    }
                    if (Menu_Value1 == "Issue_Letter")
                    {
                        UC_UploadLOAPIP UC_UploadLOAPIP = LoadControl("~/UC_UploadLOAPIP.ascx") as UC_UploadLOAPIP;
                        UC_UploadLOAPIP.ID = "UC_UploadLOAPIP";
                        UC_UploadLOAPIP.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_UploadLOAPIP);
                    }
                    if (Menu_Value1 == "Evaluation")
                    {
                        UC_PIPEvaluation UC_PIPEvaluation = LoadControl("~/UC_PIPEvaluation.ascx") as UC_PIPEvaluation;
                        UC_PIPEvaluation.ID = "UC_PIPEvaluation";
                        UC_PIPEvaluation.ServiceReqNo = ServiceReqNo;
                        Placeholder.Controls.Add(UC_PIPEvaluation);
                    }
                    if (Menu_Value1 == "Rejection" || Menu_Value1 == "LOA")
                    {
                        DataSet ds = new DataSet();
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);
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