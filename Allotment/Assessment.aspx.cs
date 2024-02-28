using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class Assessment : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;


        UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail;
        UC_Service_Applicant_Detail UC_Service_Applicant_Detail;
        UC_Assesment_Entry_Allotment UC_Assesment_Entry_Allotment;
        UC_Assesment_Entry_BP UC_Assesment_Entry_BP;
        UC_Assesment_Entry_Inspection UC_Assesment_Entry_Inspection;


        string UserName = "", ServiceReqNo = "";
        int UserId = 0, IAID = 0, ServiceID = 0, ApplicantId = 0,
            PacketId = 0;

        public string DataFactsModel_open = "";
        public string TicketStatus = "";
        public string TicketFor = "";
        public string TicketId = "";
        public string Level = "";

        #endregion


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        //      protected void Page_Init(object sender, EventArgs e)
        //{

        //	// Your Code Here
        //	//    load_UC();
        //}



        protected void Page_Load(object sender, EventArgs e)
        {


            this.RegisterPostBackControl();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;

                SqlCommand cmd = new SqlCommand("Select Level from UserAssociationMaster where UserID=" + UserId + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    if (Level == "RM")
                    {
                        fileupload.Visible = true;

                    }
                    else
                    {
                        fileupload.Visible = false;
                    }
                }

            }
            catch { Response.Redirect("Default.aspx", false); }



            if (!IsPostBack)
            {
                drpRemarks.Text = string.Empty;
                drp_Doc_Status_Save.SelectedIndex = 0;

                ServiceReqNo = (Request.QueryString["ServiceReqNo"]);
                ddlApplicant.Items.Insert(0, new ListItem(ServiceReqNo, ServiceReqNo));


                ServiceReqNo = ddlApplicant.SelectedValue;

                string[] SerArray = ServiceReqNo.Split('/');
                ServiceID = int.Parse(SerArray[1]);
                ApplicantId = int.Parse(SerArray[2]);

                ddlApplicant_SelectedIndexChanged(null, null);   // also call  MenuMaker();
                sub_menu_MenuItemClick(null, null);
            }






            ServiceReqNo = (Request.QueryString["ServiceReqNo"]);

            try { TicketId = (Request.QueryString["TicketId"]); } catch { }
            try { PacketId = int.Parse(Request.QueryString["PacketId"]); } catch { }




            try
            {
                if (TicketId.Length > 0)
                {
                    GeneralMethod gm1 = new GeneralMethod();
                    TicketFor = gm1.GetServiceTicketFor(TicketId);
                }
            }
            catch { }



            GeneralMethod gm = new GeneralMethod();
            TicketStatus = gm.GetServiceTicketStatusByUser(UserId, PacketId, ServiceReqNo);

            if (TicketStatus != "Open")
            {
                txtTicketComment.Enabled = false;
                ChangeTicketStatus.Enabled = false;
                drpOperate.Enabled = false;
            }



            ServiceReqNo = ddlApplicant.SelectedValue;
            string[] SerArray1 = ServiceReqNo.Split('/');
            ServiceID = int.Parse(SerArray1[1]);
            ApplicantId = int.Parse(SerArray1[2]);



            load_UC("ALL");
        }


        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(ChangeTicketStatus);


        }

        #region LeftMenu
        protected void MenuMaker()
        {
            sub_menu.Items.Clear();

            switch (ServiceID.ToString())
            {

                case "1000":
                    {
                        ////////  Plot Allotement 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Applicant Detail" });
                        CheklistBind(1000, ServiceReqNo);

                        sub_menu.DataBind();
                        break;
                    }


                case "4":
                    {
                        //////// Plot Transfer 
                        sub_menu.Items.Add(new MenuItem { Value = "page|Allottee_Detail", Text = "Transferor Detail" });
                        CheklistBind(4, ServiceReqNo);

                        sub_menu.Items.Add(new MenuItem { Value = "page|Applicant_Detail", Text = "Transfree Detail", NavigateUrl = "" });
                        CheklistBind(1000, ServiceReqNo);

                        sub_menu.DataBind();


                        break;
                    }

                default:
                    {
                        //////////////   Other 
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


            load_UC("First");

        }



        protected void CheklistBind(int ServiceID, string ServicereqNo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new GeneralMethod().EvaluationCheklistBind(ServiceID, ServicereqNo);

                int UniqueNo = ServiceID;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //   UniqueNo++;
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




        #region bottomTicketControl

        protected void ChangeTicketStatus_Click(object sender, EventArgs e)
        {

            try { con.Open(); } catch { }

            if (drpOperate.SelectedIndex > 0)
            {


                if (Level == "RM")
                {
                    int retval = 0;

                    if (fileupload.HasFile)
                    {
                        string filePath = fileupload.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fileupload.FileName.ToString());
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
                            case ".gif":
                                contenttype = "image/gif";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;

                        }
                        if (contenttype != String.Empty)
                        {
                            Stream fs = fileupload.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        }
                        else
                        {
                            MessageBox1.ShowError("Invalid File Format");
                            return;
                        }

                        retval = objServiceTimelinesBLL.UploadSignedCopyLetter(objServiceTimelinesBEL);
                        if (retval > 0)
                        {
                        }
                        else
                        {
                            MessageBox1.ShowSuccess("Error Occured !");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox1.ShowError("Please Upload Committee Minutes");
                        return;
                    }
                }



                SqlCommand command = con.CreateCommand();
                command.Connection = con;
                command.CommandText = ("update a set a.TicketStatus = '7' , Comment = '" + txtTicketComment.Text + "' , RecommendedStatus=" + drpOperate.SelectedValue.Trim() + "   from ServiceTicket a where a.PacketID = '" + PacketId + "'  and ServiceName = '" + ServiceReqNo + "' and TicketResponderId=" + UserId + " ");
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox1.ShowSuccess("Updated successfully");


                    GeneralMethod gm = new GeneralMethod();
                    TicketStatus = gm.GetServiceTicketStatusByUser(UserId, PacketId, ServiceReqNo);

                    if (TicketStatus != "Open")
                    {
                        txtTicketComment.Enabled = false;
                        ChangeTicketStatus.Enabled = false;
                        drpOperate.Enabled = false;
                    }
                }






            }
            else
            {
                MessageBox1.ShowSuccess("Please Select Ticket Status !");

            }




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

        protected void DocumentViewer(string DocumentID)
        {


            DataSet ds = new DataSet();
            objServiceTimelinesBEL.DocumentID = DocumentID;
            ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
            DataTable dtDoc = ds.Tables[0];

            if (dtDoc != null)
            {

                string contype = dtDoc.Rows[0]["contentType"].ToString().Trim();

                string embed = @"<object name='Viewer' data=""{0}"" type=" + contype + @" width =""100%""  height=""500px"">
										  If you are unable to view file, you can download from <a href = ""{0}&download=1"">here</a>
										  or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/\"">Adobe PDF Reader</a> to view the file.
										 </object>";

                Literal ltEmbed = new Literal();
                ltEmbed.Text = string.Format(string.Format(embed, ResolveUrl("/Viewer.ashx?ServiceRequestNO=&ServiceCheckListsID=&ServiceTimeLinesID=&DocId=" + DocumentID + "")));

                //    Placeholder.Controls.Clear();
                Placeholder.Controls.Add(ltEmbed);
            }


        }

        protected void btn_Doc_Status_Save_Click(object sender, EventArgs e)
        {
            string[] SerIdarray = ((string)ViewState["sub_menu"]).Split('|');
            string Menu_Type = "";
            string ServiceCheckListsID = "";
            string doc_id = "";

            try
            {
                Menu_Type = SerIdarray[0];
                ServiceCheckListsID = SerIdarray[1];
                doc_id = SerIdarray[2];

            }
            catch { }


            if (ServiceCheckListsID == "")
            {
                MessageBox1.ShowWarning("Error Not Found Correct Checklist Id");
                return;
            }


            if (Menu_Type == "doc" && ServiceCheckListsID.Length > 0)
            {

                if (drp_Doc_Status_Save.SelectedValue.Trim() == "2")
                {
                    MessageBox1.ShowInfo("Please Select Status Dropdown !");
                    return;
                }
                else
                {
                    //  Set_ServiceRequestProcessDoc       @ServiceRequestNO , 
                    //                                     @DocumentID ,
                    //                                     @UserBy  ,
                    //                                     @DocStatus , 
                    //                                     @DocRemark


                    try { con.Open(); } catch { }
                    try
                    {
                        SqlCommand command = con.CreateCommand();
                        command.Connection = con;
                        command.CommandText = ("Set_ServiceRequestProcessDocnew  '" + ServiceReqNo + "', " + ServiceCheckListsID + " ,  '" + doc_id + "' , " + UserId + ", " + drp_Doc_Status_Save.SelectedValue.Trim() + " ,  '" + drpRemarks.Text.Trim() + "'");
                        if (command.ExecuteNonQuery() > 0)
                        {
                            MessageBox1.ShowSuccess("Updated successfully");

                            GET_ServiceRequestDoc_Status(ServiceReqNo, ServiceCheckListsID);

                        }
                        else
                        {
                            MessageBox1.ShowSuccess("Error Occured !");
                            return;
                        }
                    }
                    catch (Exception ex) { MessageBox1.ShowError(ex.Message.ToString()); }
                    finally
                    {

                        drpRemarks.Text = string.Empty;
                        drp_Doc_Status_Save.SelectedIndex = 0;
                        con.Close();
                    }
                }
            }
            else
            {

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


            if (Menu_Type == "doc")
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
                    UC_ApplicationFinalViewInternal UC_ApplicationFinalViewInternal = LoadControl("~/UC_ApplicationFinalViewInternal.ascx") as UC_ApplicationFinalViewInternal;
                    UC_ApplicationFinalViewInternal.ID = "UC_ApplicationFinalViewInternalID";

                    UC_ApplicationFinalViewInternal.ServiceRequestNo = ServiceReqNo;
                    Placeholder.Controls.Add(UC_ApplicationFinalViewInternal);
                    ///div_doc_status.Visible = true;
                }
            }



            if (AllOrFirst == "ALL")
            {
                PH_AssesmentServiceSpecificEntry.Controls.Clear();
                switch (ServiceID.ToString())
                {


                    case "1000":
                    case "4":
                        {
                            ////////  Plot Allotement & Transfer Case
                            UC_Assesment_Entry_Allotment = LoadControl("~/UC_Assesment_Entry_Allotment.ascx") as UC_Assesment_Entry_Allotment;
                            PH_AssesmentServiceSpecificEntry.Controls.Add(UC_Assesment_Entry_Allotment);

                            UC_Assesment_Entry_Allotment.PacketId = PacketId;
                            UC_Assesment_Entry_Allotment.ServiceReqNo = ServiceReqNo;
                            UC_Assesment_Entry_Allotment.ID = "UC_Assesment_Entry_AllotmentID";
                            UC_Assesment_Entry_Allotment.EnableViewState = true;

                            UC_Assesment_Entry_Allotment.Page_Load(null, null);
                            // UC_Assesment_Entry_Allotment.EnableViewState = false;
                            break;
                        }


                    case "1":
                    case "2":
                        {

                            //////// Buildin Plan
                            if (TicketFor == "10")
                            {
                                UC_Assesment_Entry_Inspection = LoadControl("~/UC_Assesment_Entry_Inspection.ascx") as UC_Assesment_Entry_Inspection;
                                PH_AssesmentServiceSpecificEntry.Controls.Add(UC_Assesment_Entry_Inspection);
                                UC_Assesment_Entry_Inspection.PacketId = PacketId;
                                UC_Assesment_Entry_Inspection.ServiceReqNo = ServiceReqNo;
                                UC_Assesment_Entry_Inspection.TicketId = TicketId;
                                //    UC_Assesment_Entry_Inspection.ID = "UC_Assesment_Entry_InspectionID";

                                break;
                            }
                            else
                            {
                                UC_Assesment_Entry_BP = LoadControl("~/UC_Assesment_Entry_BP.ascx") as UC_Assesment_Entry_BP;
                                PH_AssesmentServiceSpecificEntry.Controls.Add(UC_Assesment_Entry_BP);
                                UC_Assesment_Entry_BP.PacketId = PacketId;
                                UC_Assesment_Entry_BP.ServiceReqNo = ServiceReqNo;

                                //   UC_Assesment_Entry_BP.ID = "UC_Assesment_Entry_BPID";
                                break;


                            }
                        }

                    default:
                        {
                            //////////////   Other 
                            break;
                        }
                }

            }


            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowTermsAndCondition()", true);
        }


        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            IAID = gm.Get_IAID_ByServiceRequstNonew(ddlApplicant.SelectedValue);

            ServiceReqNo = ddlApplicant.SelectedValue.Trim();
            MenuMaker();
            sub_menu.Items[0].Selected = true;
        }



    }
}