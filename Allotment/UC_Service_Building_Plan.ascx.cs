using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;


namespace Allotment
{
    public partial class UC_Service_Building_Plan : System.Web.UI.UserControl
    {
        public string HiddenClassRM { get; private set; }
        public string HiddenClassAssistence { get; private set; }
        public string HiddenClassDraftMan { get; private set; }
        public string HiddenClassAssistenceManager { get; private set; }
        public string HiddenClassManager { get; private set; }
        private System.Delegate _delPageMethod;
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion
        SqlConnection con;

        public string SerReqID { get; set; }
        public string SerID_in { get; set; }
        public string AllottementLetterNo { get; set; }
        public string UserBy { get; set; }

        public string SerReq_C_SubTab { get; set; }
        public string SerReq_C_Tab { get; set; }
        public string ControlID { get; set; }
        public string UnitID { get; set; }
        public string ServiceID { get; set; }
        public string RequestID { get; set; }
        public string TraID { get; set; }
        public string App { get; set; }
        public string OccupierEmail { get; set; }
        public string OccupierPhone { get; set; }
        public string OccupierPan { get; set; }
        // "ENTRY", "VIEW"
        public string page_type { get; set; }

        string cat = "";

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

        string Request_ID = "";
        string Pendancy_level = "";
        string Objection_Rejection_Code = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string Is_Certificate_Valid_Life_Time = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";
        public string HiddenClassNameEx { get; private set; }
        public string HiddenClassNamePr { get; private set; }
        public string ChangeStatus { get; private set; }

        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }


        public void Page_Load(object sender, EventArgs e)
        {


            Page.Form.Enctype = "multipart/form-data";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            Request_ID = RequestID;
            MenuMaker();
            if (ServiceID == "SC21002")
            {
                NiveshMitra();
            }


            if (!string.IsNullOrEmpty(Request.QueryString["ServiceReqNo"]))
            {
                SerReqID = Request.QueryString["ServiceReqNo"];
            }


            if (!string.IsNullOrEmpty(Request.QueryString["ServiceID"]))
            {
                SerReqID = Request.QueryString["ServiceID"];
            }

            SqlCommand cmd = new SqlCommand("Select Status,IsRejected,IsClarificationReq from ServiceRequests  where ServiceRequestNo='" + SerReqID + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string status = dt.Rows[0][0].ToString();
                string Rej = dt.Rows[0][1].ToString();
                string IsClarification = dt.Rows[0][2].ToString();

                if (Rej == "True")
                {
                    if(ServiceID=="SC21003")
                    {
                        page_type = "ENTRY";

                    }
                    else
                    {
                        page_type = "ENTRY";
                        page_type = "VIEW";
                        btnSaveF.Text = "Submitted";
                        btnSaveF.Enabled = false;
                        btnSaveArchitect.Text = "Submitted";
                        btnSaveArchitect.Enabled = false;
                        //Building Plan Testing
                        //btnPay.Text = "Paid";
                        //btnPay.Enabled = false;

                    }



                }
                else if(IsClarification=="True")
                {
                    page_type = "ENTRY";

                }
                else
                {
                    if (status == "True")
                    {
                        page_type = "VIEW";
                        btnSaveF.Text = "Submitted";
                        btnSaveF.Enabled = false;
                        btnSaveArchitect.Text = "Submitted";
                        btnSaveArchitect.Enabled = false;
                        //Building Plan Testing
                        //btnPay.Text = "Paid";
                        //btnPay.Enabled = false;

                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("Select isnull(Paid,0) from ApplicantTransaction  where TransactionRefNo='" + TraID + "'", con);
                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        adp1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            string Fee = dt1.Rows[0][0].ToString();
                            if (Fee == "True")
                            {

                                btnPay.Text = "Paid";
                                btnPay.Enabled = false;
                                page_type = "VIEW";
                                btnSaveF.Text = "Submitted";
                                btnSaveF.Enabled = false;
                                btnSaveArchitect.Text = "Submitted";
                                btnSaveArchitect.Enabled = false;
                            }

                        }
                        else
                        {
                            page_type = "ENTRY";
                        }
                        
                    }
                }

            }



            if (App == "View")
            {
                btnPay.Visible = false;

                page_type = "VIEW";
                btnSaveF.Visible = false;

                btnSaveArchitect.Text = "Submitted";
                btnSaveArchitect.Enabled = false;
            }


            if (string.IsNullOrEmpty(SerReqID))
            {
                checkcon.Text = "";
                lblserRequest.Text = SerID_in;
                MultiViewBuildingPlan.ActiveViewIndex = 0;
                hideDiv.Visible = false;
                UC_Service_Allotteee_Detail.AllotmentNo.Text = AllottementLetterNo;
                UC_Service_Allotteee_Detail.Page_Load(null, null);
                service_app_type.Visible = true;
            }
            else
            {

                service_app_type.Visible = false;
                lblserRequest.Text = SerReqID;
                checkcon.Text = SerReqID;
                string[] SerIdarray = lblserRequest.Text.Split('/');

                UC_Service_Doc_Upload_View.SerReqID = SerReqID;
                UC_Service_Doc_Upload_View.page_type = page_type;

                UC_Service_Allotteee_Detail.AllotmentNo.Text = AllottementLetterNo;
                UC_Service_Allotteee_Detail.AllotteeId = SerIdarray[2];
                UC_Service_Allotteee_Detail.ServiceReqNo = SerReqID;
                UC_Service_Allotteee_Detail.Page_Load(null, null);


                hideDiv.Visible = true;
                btnSubmit.Visible = false;
                btnSaveApplicant.Visible = true;


                if (SerIdarray[1] == "3")
                {
                    Response.Redirect("WaterConnection.aspx?ServiceID=" + lblserRequest.Text.Trim(), false);
                }
                if (SerIdarray[1] == "4")
                {
                    Response.Redirect("AllotteePlotTransfer.aspx?ServiceID=" + lblserRequest.Text.Trim(), false);
                }
                if (SerIdarray[1] == "1")
                {
                    HiddenClassNameEx = "display:none;";
                }
                else
                {
                    HiddenClassNamePr = "display:none;";
                }



            }






            int DesignationId = Convert.ToInt32(Session["DesignationID"]);

            string strRoll = Convert.ToString((Session["Roll"]));
            if (strRoll == "RM")
            {
                HiddenClassRM = "display:show";
            }
            if (cat == "2")
            {
                btnRisk.Enabled = false;
                btnInspection.Enabled = false;
                HiddenClassRM = "display:show";
                lblHead.Text = "Proposed Specification";
            }
            else
            {
                btnRisk.Enabled = true;
                btnInspection.Enabled = true;
                lblHead.Text = "Scrutinized Specification";
            }

            BindApplicationType();
            BindHazardDdl();

            ListItemCollection collection = new ListItemCollection();

            if (lblserRequest.Text.Trim() == "3")
            {
                collection.Add(new ListItem("Apply For Water Connection"));
            }

            if (lblserRequest.Text.Trim() == "2")
            {
                collection.Add(new ListItem("Apply For Complition/Occupency certificate"));
            }

            if (lblserRequest.Text.Trim() == "1")
            {
                collection.Add(new ListItem("Errect New Building"));
                collection.Add(new ListItem("Re Errect Building"));
                collection.Add(new ListItem("Alteration and Modification"));
            }
            if (lblserRequest.Text.Trim() == "4")
            {
                MultiViewBuildingPlan.ActiveViewIndex = 5;
            }

            //ddlCaseType.DataSource = collection;
            //ddlCaseType.DataBind();

            if (MultiViewBuildingPlan.ActiveViewIndex < 0)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 0;
            }

            if (MultiViewBuildingPlan.ActiveViewIndex > 0)
            {
                GetServiceRequestBPDetail(lblserRequest.Text);


            }
            else
            {
                GetAllotteeRecordComplete(AllottementLetterNo, cat);
            }


            if (!string.IsNullOrEmpty(AllottementLetterNo) || lblserRequest.Text.Length > 0)
            {
                sub_menu.Visible = true;
            }
            else
            {
                sub_menu.Visible = false;
            }

            GetAllotteeDetail(AllottementLetterNo);



            if (App == "Resubmit")
            {

                btnPay.Visible = false;

            }
           

        }

        protected void MenuMaker()
        {
            sub_menu.Items.Clear();

            SqlCommand cmd = new SqlCommand("GetHideShowPayment '" + lblserRequest.Text + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string View = dt.Rows[0][0].ToString();
                if (View.Trim() == "Show")
                {
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Allotee Detail" });
                    sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Documents Checklist" });
                    sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Architect/Structural Engineer" });
                    sub_menu.Items.Add(new MenuItem { Value = "4", Text = "Building Specification" });
                    sub_menu.Items.Add(new MenuItem { Value = "5", Text = "Pay BP Charges" });
                }
                else
                {
                    sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Allotee Detail" });
                    sub_menu.Items.Add(new MenuItem { Value = "2", Text = "Documents Checklist" });
                    sub_menu.Items.Add(new MenuItem { Value = "3", Text = "Architect/Structural Engineer" });
                    sub_menu.Items.Add(new MenuItem { Value = "4", Text = "Building Specification" });
                }

            }
            else
            {

                sub_menu.Items.Add(new MenuItem { Value = "0", Text = "Allotee Detail" });
                sub_menu.Items.Add(new MenuItem { Value = "1", Text = "Payment Checklist" });

            }
            sub_menu.DataBind();
        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);

            SerReq_C_SubTab = "1";
            SerReq_C_Tab = index.ToString();
            GetServiceRequestBPDetail(lblserRequest.Text);
            if (index == 5)
            {
                if (App == "Resubmit")
                {
                    SqlCommand cmmd = new SqlCommand("GetPaymentCheck '" + lblserRequest.Text + "'", con);
                    SqlDataAdapter addp = new SqlDataAdapter(cmmd);
                    DataSet ds = new DataSet();
                    addp.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        decimal count = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());

                        if (count > 0)
                        {

                            GetDepositesInternal("Revised");

                            btnRePayment.Visible = true;
                            BtnResubmit.Visible = false;
                        }
                        else if (count < 0)
                        {

                            btnRePayment.Visible = false;
                            BtnResubmit.Visible = true;
                            GetDepositesInternal("Less");
                        }
                        else
                        {
                            btnRePayment.Visible = false;
                            BtnResubmit.Visible = true;
                            GetDepositesInternal("Same");
                        }

                    }
                }
                else
                {
                    SqlCommand cmmd = new SqlCommand("Select * from ServiceRequests where ServiceRequestNo='" + lblserRequest.Text + "'", con);
                    SqlDataAdapter addp = new SqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    addp.Fill(dt);
                    string IsCompleted = dt.Rows[0]["IsCompleted"].ToString();
                    string IsRejected = dt.Rows[0]["IsRejected"].ToString();
                    string Status = dt.Rows[0]["Status"].ToString();

                    if (IsCompleted == "True")
                    {
                        GetDepositesPaid();
                    }
                    else if (IsRejected == "True")
                    {
                       
                            GetDepositesPaid();
                       
                    }
                    else if (Status == "True")
                    {
                        GetDepositesPaid();
                    }
                    else
                    {
                        GetDepositesInternal("Same");
                    }
                }
            }
            MultiViewBuildingPlan.ActiveViewIndex = index;
        }
        private void GetDeposites()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Select isnull(AllotteeName,CompanyName) 'ApplicantName',isnull(Address,SignatoryAddress) 'Address' from AllotteeMaster where AllotmentLetterNo='" + AllottementLetterNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string Applicantname = dt.Rows[0]["ApplicantName"].ToString();
                string Address = dt.Rows[0]["Address"].ToString();
                //UC_BuildingPlanFee UC_BuildingPlanFee = LoadControl("~/UC_BuildingPlanFee.ascx") as UC_BuildingPlanFee;

                //UC_BuildingPlanFee.IndustrialArea = Convert.ToInt32(lblIAID.Text);
                //UC_BuildingPlanFee.PlotArea = Convert.ToDouble(lblPlotArea.Text);
                //UC_BuildingPlanFee.CoveredArea = Convert.ToDouble(txtBuiltUpArea.Text);
                //UC_BuildingPlanFee.AllotmentLetterNo = AllottementLetterNo;
                //UC_BuildingPlanFee.SWCControlID = ControlID;
                //UC_BuildingPlanFee.SWCUnitID = UnitID;
                //UC_BuildingPlanFee.SWCServiceID = ServiceID;
                //UC_BuildingPlanFee.ApplicantName = Applicantname;
                //UC_BuildingPlanFee.applicantAddress = Address;

                //PlaceHolder1.Controls.Add(UC_BuildingPlanFee);

                UC_BuildingPlanFeeAll UC_BuildingPlanFeeAll = LoadControl("~/UC_BuildingPlanFeeAll.ascx") as UC_BuildingPlanFeeAll;

                UC_BuildingPlanFeeAll.IndustrialArea = Convert.ToInt32(lblIAID.Text);
                UC_BuildingPlanFeeAll.choicearea = Convert.ToDouble(lblPlotArea.Text);
                if (ddlCaseType.SelectedValue == "3")
                {
                    UC_BuildingPlanFeeAll.CoveredArea = txtRevBuiltUpArea.Text;
                }
                else
                {
                    UC_BuildingPlanFeeAll.CoveredArea = txtBuiltUpArea.Text;
                }
                UC_BuildingPlanFeeAll.AllotmentLetterNo = AllottementLetterNo;
                UC_BuildingPlanFeeAll.SWCControlID = ControlID;
                UC_BuildingPlanFeeAll.SWCUnitID = UnitID;
                UC_BuildingPlanFeeAll.SWCServiceID = ServiceID;
                UC_BuildingPlanFeeAll.ServiceRequestNo = lblserRequest.Text;
                UC_BuildingPlanFeeAll.TranID = TraID;
                UC_BuildingPlanFeeAll.ApplicantName = Applicantname;
                UC_BuildingPlanFeeAll.applicantAddress = Address;
                UC_BuildingPlanFeeAll.ApplicationStatus = "";
                UC_BuildingPlanFeeAll.CaseType = ddlCaseType.SelectedValue.Trim();

                if (ddlCaseType.SelectedValue == "3")
                {
                    if (Convert.ToDecimal(txtRevBuiltUpArea.Text) <= Convert.ToDecimal(txtPrevBuiltUpArea.Text))
                    {
                        UC_BuildingPlanFeeAll.AreaStatus = "Less";
                    }
                    else
                    {
                        UC_BuildingPlanFeeAll.AreaStatus = "More";
                    }
                }
                else
                {
                    UC_BuildingPlanFeeAll.AreaStatus = "More";
                }
                if (chk_MalbaPaid.Checked == true)
                {
                    UC_BuildingPlanFeeAll.MalbaPaid = "YES";
                }
                else
                {
                    UC_BuildingPlanFeeAll.MalbaPaid = "NO";
                }
                if (chk_InfraPaid.Checked == true)
                {
                    UC_BuildingPlanFeeAll.InfraPaid = "YES";
                }
                else
                {
                    UC_BuildingPlanFeeAll.InfraPaid = "NO";
                }
                PlaceHolder1.Controls.Add(UC_BuildingPlanFeeAll);

                MultiViewBuildingPlan.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetDepositesInternal(string Condition)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select isnull(AllotteeName,CompanyName) 'ApplicantName',isnull(Address,SignatoryAddress) 'Address' from AllotteeMaster where AllotmentLetterNo='" + AllottementLetterNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                string Applicantname = dt.Rows[0]["ApplicantName"].ToString();
                string Address = dt.Rows[0]["Address"].ToString();
                UC_BuildingPlanFeeInternal UC_BuildingPlanFeeInternal = LoadControl("~/UC_BuildingPlanFeeInternal.ascx") as UC_BuildingPlanFeeInternal;

                UC_BuildingPlanFeeInternal.IndustrialArea = Convert.ToInt32(lblIAID.Text);
                UC_BuildingPlanFeeInternal.choicearea = Convert.ToDouble(lblPlotArea.Text);
                UC_BuildingPlanFeeInternal.CoveredArea = txtCoveredArea.Text;
                UC_BuildingPlanFeeInternal.AllotmentLetterNo = AllottementLetterNo;
                UC_BuildingPlanFeeInternal.SWCControlID = ControlID;
                UC_BuildingPlanFeeInternal.SWCUnitID = UnitID;
                UC_BuildingPlanFeeInternal.SWCServiceID = ServiceID;
                UC_BuildingPlanFeeInternal.ServiceRequestNo = lblserRequest.Text;
                UC_BuildingPlanFeeInternal.TranID = TraID;
                UC_BuildingPlanFeeInternal.ApplicantName = Applicantname;
                UC_BuildingPlanFeeInternal.applicantAddress = Address;
                UC_BuildingPlanFeeInternal.ApplicationStatus = Condition;
                PlaceHolder2.Controls.Add(UC_BuildingPlanFeeInternal);



            }
            catch (Exception ex)
            {

            }
        }


        private void GetDepositesPaid()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("GetPaymentDetailsAllottee '" + lblserRequest.Text + "'", con);
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
                string TraID = dt.Rows[0]["BuildingTraID"].ToString();
                UC_BuildingPlanFeeInternalOffice UC_BuildingPlanFeeInternalOffice = LoadControl("~/UC_BuildingPlanFeeInternalOffice.ascx") as UC_BuildingPlanFeeInternalOffice;

                UC_BuildingPlanFeeInternalOffice.IndustrialArea = Convert.ToInt32(IAID);
                UC_BuildingPlanFeeInternalOffice.choicearea = Convert.ToDouble(PlotArea);
                UC_BuildingPlanFeeInternalOffice.CoveredArea = CoveredArea;
                UC_BuildingPlanFeeInternalOffice.AllotmentLetterNo = AllottmentNo;
                UC_BuildingPlanFeeInternalOffice.SWCControlID = ControlID;
                UC_BuildingPlanFeeInternalOffice.SWCUnitID = UnitID;
                UC_BuildingPlanFeeInternalOffice.SWCServiceID = ServiceID;
                UC_BuildingPlanFeeInternalOffice.ServiceRequestNo = lblserRequest.Text;
                UC_BuildingPlanFeeInternalOffice.TranID = TraID;
                UC_BuildingPlanFeeInternalOffice.ApplicantName = Applicantname;
                UC_BuildingPlanFeeInternalOffice.applicantAddress = Address;
                PlaceHolder2.Controls.Add(UC_BuildingPlanFeeInternalOffice);



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }





        public void GetServiceChecklists(string text)
        {
            MessageBox1.ShowError(text);
        }


        public void GetAllotteeDetail(string req)
        {
            lblallotteName.Text = "";
            lblAllotteeAddress.Text = "";
            LblallotteeIA.Text = "";
            LblallotteeReg.Text = "";
            LblallotteePlotNo.Text = "";

            SqlCommand cmd = new SqlCommand("GetAllotteeDetailsFor_Sp '" + AllottementLetterNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblallotteName.Text = dt.Rows[0]["ApplicantName"].ToString();
                lblAllotteeAddress.Text = dt.Rows[0]["Address"].ToString();
                LblallotteeIA.Text = dt.Rows[0]["IndustrialArea"].ToString();
                LblallotteeReg.Text = dt.Rows[0]["RegionName"].ToString();
                LblallotteePlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                lblIAID.Text = dt.Rows[0]["INDID"].ToString();
                lblPlotArea.Text = dt.Rows[0]["TotalAllottedplotArea"].ToString();
                lblAllotteePhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                lblAllotteeEmail.Text = dt.Rows[0]["EmailID"].ToString();
            }
        }


        private void send_mail(string name, string mailid)
        {
            //try
            //{
            //  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
            //    MailAddress mailto = new MailAddress(mailid);
            //    MailMessage newmsg = new MailMessage(mailfrom, mailto);


            //    string StrContent = "";
            //    StreamReader reader = new StreamReader(Server.MapPath("~/BuildingRequestMail.html"));
            //    StrContent = reader.ReadToEnd();

            //    StrContent = StrContent.Replace("[Date]", DateTime.Now.ToString("dd MMM yyyy"));
            //    StrContent = StrContent.Replace("[Allottee Name]", lblallotteName.Text);
            //    StrContent = StrContent.Replace("[Reg office]", LblallotteeReg.Text.Trim());
            //    StrContent = StrContent.Replace("[IA Name]", LblallotteeIA.Text.Trim());
            //    StrContent = StrContent.Replace("[Plot No]", LblallotteePlotNo.Text.Trim());
            //    StrContent = StrContent.Replace("[Address Of Apllicant]", lblAllotteeAddress.Text.Trim());



            //    newmsg.Subject = "Inspection of Site for Construction Permit/ Occupancy/Completion";
            //    newmsg.Body = StrContent;
            //    // newmsg.Attachments.Add(new Attachment(Server.MapPath("doc/Inspection_Procedure.pdf")));

            //    newmsg.IsBodyHtml = true;
            //    //For File Attachment, more file can also be attached
            //    //Attachment att = new Attachment("");
            //    //newmsg.Attachments.Add(att);

            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
            //    smtp.EnableSsl = true;
            //    smtp.Send(newmsg);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
        private void download(DataTable dt)
        {
            try
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["contentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["ColName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        #region "Save Service Request Record"



        private void NiveshMitra()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
            
            Status_Code = "";
            Remarks = "";
            Fee_Amount = "";
            Fee_Status = "";
            Transaction_ID = "";
            Transaction_Date = "";
            Transaction_Date_Time = "";
            NOC_Certificate_Number = "";
            NOC_URL = "";
            ISNOC_URL_ActiveYesNO = "";

            try
            {


                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                DataSet ds = webService.WGetBasicDetails(ControlID, UnitID, ServiceID, "", passsalt);

                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {


                    string Name = dt.Rows[0]["Occupier_Name"].ToString();
                    OccupierEmail = dt.Rows[0]["Occupier_Email_ID"].ToString();
                    OccupierPhone = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                    OccupierPan = dt.Rows[0]["Occupier_PAN"].ToString();
                    //string status_code = dt.Rows[0]["Status_Code"].ToString();
                    objServiceTimelinesBEL.NameofOwner = Name;
                    objServiceTimelinesBEL.AllotmentLetterno = AllottementLetterNo;
                    objServiceTimelinesBEL.Email = OccupierEmail;
                    objServiceTimelinesBEL.PhoneNumber = OccupierPhone;
                    objServiceTimelinesBEL.PanNo = OccupierPan;
                    int retVal = objServiceTimelinesBLL.UpdateEmailFromNiveshMitra(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Alert('Something Went Wrong With Nivesh Mitra Server');", true);
                return;
            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.UserName = AllottementLetterNo;
            if (lblserRequest.Text == "4") { objServiceTimelinesBEL.ApplicationType = "Transfer Of Plot"; objServiceTimelinesBEL.CaseType = "Transfer Of Plot"; }
            else
            {
                objServiceTimelinesBEL.ApplicationType = ddlApplication.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.CaseType = ddlCaseType.SelectedItem.Text.Trim();
                objServiceTimelinesBEL.BPType = Convert.ToInt32(ddlCaseType.SelectedValue.Trim());
            }

            objServiceTimelinesBEL.IndustrialArea = lblArea.Text;
            objServiceTimelinesBEL.ServiceRequest = String.Empty;
            objServiceTimelinesBEL.Remarks = String.Empty;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(lblserRequest.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserBy;
            objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
            objServiceTimelinesBEL.SWCControlID = ControlID;
            objServiceTimelinesBEL.SWCUnitID = UnitID;
            objServiceTimelinesBEL.SWCServiceID = ServiceID;
            objServiceTimelinesBEL.SWCRequestID = RequestID;
            objServiceTimelinesBEL.GSTNo = txtGstNo.Text.Trim();
            if (ddlCaseType.SelectedValue == "3")
            { objServiceTimelinesBEL.CoveredArea = txtRevBuiltUpArea.Text; }
            else
            {
                objServiceTimelinesBEL.CoveredArea = txtBuiltUpArea.Text;
            }
            if (txtPrevBuiltUpArea.Text.Length > 0)
            {
                objServiceTimelinesBEL.PrevAppCoveredArea = txtPrevBuiltUpArea.Text;
            }
            else
            {
                objServiceTimelinesBEL.PrevAppCoveredArea = "0";
            }
            if (chk_MalbaPaid.Checked)
            {
                objServiceTimelinesBEL.MalbaPaid = "YES";
            }
            else
            {
                objServiceTimelinesBEL.MalbaPaid = "NO";

            }
            if (chk_InfraPaid.Checked)
            {
                objServiceTimelinesBEL.InfraPaid = "YES";
            }
            else
            {
                objServiceTimelinesBEL.InfraPaid = "NO";

            }

            if (ddlCaseType.SelectedValue == "3")
            {
                if (Convert.ToDecimal(txtRevBuiltUpArea.Text) <= Convert.ToDecimal(txtPrevBuiltUpArea.Text))
                {
                    objServiceTimelinesBEL.AreaStatus = "Less";
                }
                else
                {
                    objServiceTimelinesBEL.AreaStatus = "More";
                }

            }
            try
            {
                DataSet ds = new DataSet();
                if (btnSubmit.Text == "Save")
                {
                    if (objServiceTimelinesBEL.ApplicationType.Length == 0)
                    {
                        MessageBox1.ShowWarning("Please Select Application type");
                        return;
                    }
                    else
                    {
                        ds = objServiceTimelinesBLL.SetServiceRequest(objServiceTimelinesBEL);
                    }
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblServiceRequestID.Text = ds.Tables[0].Rows[0][0].ToString();

                            // Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=0", false);
                            this.Page.GetType().InvokeMember("AllertRedirect", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { "Your Service Request No is " + lblServiceRequestID.Text.Trim() + ". Kindly Pay processing fee to nivesh mitra for further processing.", lblServiceRequestID.Text });
                        }
                    }
                    else
                    {
                        string message = "Record couldnt be  Save ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void btnSaveBuildingSpec_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            if (txtNameTechnical.Text == "")
            {
                string Message = "Architect Name is required";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtLicensedPerson.Text == "")
            {
                string Message = "Architect License No is required";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtRegistration.Text == "")
            {
                string Message = "Architect Registration No is required";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtAddressPerson.Text == "")
            {
                string Message = "Architect Address is required";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtStructuralEngineer.Text == "")
            {
                string Message = "Structural Engineer Name is required";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                return;
            }
            if (txtStructuralEngineerLicensedNo.Text == "")
            {
                string Message = "Structural Engineer license no is required";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                return;
            }

            if (txtStructuralEngineerRegistratinNo.Text == "")
            {
                string Message = "Structural Engineer Registration No is required";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                return;
            }
            if (txtStructuralEngineerAddress.Text == "")
            {
                string Message = "Structural Engineer Address is required";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                return;
            }

            objServiceTimelinesBEL.ServiceRequestNO = SerReqID;

            objServiceTimelinesBEL.NameofArchitect = txtNameTechnical.Text.Trim();
            objServiceTimelinesBEL.ArchitectLicenseNo = txtLicensedPerson.Text.Trim();
            objServiceTimelinesBEL.ArchitectRegistrationNo = txtRegistration.Text.Trim();
            objServiceTimelinesBEL.ArchitectAddress = txtAddressPerson.Text.Trim();

            objServiceTimelinesBEL.StructuralEngineer = txtStructuralEngineer.Text.Trim();
            objServiceTimelinesBEL.StructuralEngineerLicensedNo = txtStructuralEngineerLicensedNo.Text.Trim();
            objServiceTimelinesBEL.StructuralEngineerRegistratinNo = txtStructuralEngineerRegistratinNo.Text.Trim();
            objServiceTimelinesBEL.StructuralEngineerAddress = txtStructuralEngineerAddress.Text.Trim();
            objServiceTimelinesBEL.ModifiedBy = UserBy;
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;


            try
            {
                if (btnSubmit.Text == "Save")
                {
                    int retVal = objServiceTimelinesBLL.SaveArchitectDetail(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "Record Submitted SucessFully ";

                        MessageBox1.ShowSuccess(message);

                        GetServiceRequestBPDetail(lblserRequest.Text);

                    }
                    else
                    {
                        string message = "Record couldn't be  Save ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        MessageBox1.ShowError(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
            finally
            {

                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void btnFar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ValidateBPDetails '" + SerReqID.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dss = new DataSet();
            adp.Fill(dss);
            if (dss.Tables.Count > 0)
            {
                DataTable dt1 = dss.Tables[0];
                DataTable dt2 = dss.Tables[1];


                string Architect = dt1.Rows[0][0].ToString();
                if (Architect == "Pending")
                {
                    string Message = "Architect Details are Mandatory";
                    MessageBox1.ShowWarning(Message);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

                string Doc = dt2.Rows[0][0].ToString();
                if (Doc == "Pending")
                {
                    string Message = "Upload all mandatory documents";
                    MessageBox1.ShowWarning(Message);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                    return;
                }

            }

            if (txtFar.Text.Length <= 0)
            {
                string Message = "Far is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtGroundcover.Text.Length <= 0)
            {
                string Message = "Ground coverage is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtHeight.Text.Length <= 0)
            {
                string Message = "Height is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtSetBackFront.Text.Length <= 0)
            {
                string Message = "Set Back front is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtSetBackRear.Text.Length <= 0)
            {
                string Message = "Set Back rear is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }

            if (txtSetBackSide1.Text.Length <= 0)
            {
                string Message = "Set Back side1 is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }

            if (txtSetBackSide2.Text.Length <= 0)
            {
                string Message = "Set Back side2 is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (ddlNature.SelectedIndex == 0)
            {
                string Message = "Please select classification of hazard";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (txtOccupancy.Text.Length <= 0)
            {
                string Message = "Occupancy is required field";
                MessageBox1.ShowWarning(Message);
                return;
            }

            if (((string.IsNullOrEmpty(txtBaseMent2.Text) ? 0 : decimal.Parse(txtBaseMent2.Text)) + (string.IsNullOrEmpty(txtGround2.Text) ? 0 : decimal.Parse(txtGround2.Text)) + (string.IsNullOrEmpty(txtFirstfloor2.Text) ? 0 : decimal.Parse(txtFirstfloor2.Text)) + (string.IsNullOrEmpty(txtSecondFloor2.Text) ? 0 : decimal.Parse(txtSecondFloor2.Text)) + (string.IsNullOrEmpty(txtMezzanine2.Text) ? 0 : decimal.Parse(txtMezzanine2.Text)) + (string.IsNullOrEmpty(txtStealth.Text) ? 0 : decimal.Parse(txtStealth.Text)) + (string.IsNullOrEmpty(txtMumti.Text) ? 0 : decimal.Parse(txtMumti.Text))) > ((string.IsNullOrEmpty(txtCoveredArea.Text) ? 0 : decimal.Parse(txtCoveredArea.Text))))
            {
                string Message = "Covered Area Exceeding Total Covered Area";
                MessageBox1.ShowWarning(Message);
                return;
            }

            if (drpTemoraryStructure.SelectedValue == "2")
            {
                string Message = "Please select any temporary structure exists or not";
                MessageBox1.ShowWarning(Message);
                return;
            }
            if (drpTemoraryStructure.SelectedValue == "1")
            {
                if (txtHutment.Text.Length <= 0)
                {
                    string Message = "Please enter covered area for use of labour hutment";
                    MessageBox1.ShowWarning(Message);
                    return;
                }
                if (txtOtherCharges.Text.Length <= 0)
                {
                    string Message = "Please enter covered area for other use";
                    MessageBox1.ShowWarning(Message);
                    return;
                }

            }


            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



            objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;

            try { objServiceTimelinesBEL.Far          = float.Parse(txtFar.Text); } catch { }
            try { objServiceTimelinesBEL.Groundcover  = float.Parse(txtGroundcover.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackFront = float.Parse(txtSetBackFront.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackRear  = float.Parse(txtSetBackRear.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackSide1 = float.Parse(txtSetBackSide1.Text); } catch { }
            try { objServiceTimelinesBEL.SetBackSide2 = float.Parse(txtSetBackSide2.Text); } catch { }
            try { objServiceTimelinesBEL.Height       = float.Parse(txtHeight.Text); } catch { }
            try { objServiceTimelinesBEL.Occupancy    = float.Parse(txtOccupancy.Text); } catch { }


            objServiceTimelinesBEL.NatureofOccupancy = ddlNature.SelectedValue.Trim();
            objServiceTimelinesBEL.ModifiedBy = UserBy;
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;


            /////////////////  Update By Mr Manish
            objServiceTimelinesBEL.ExistingBasement = (txtBaseMent1.Text);
            objServiceTimelinesBEL.ExistingGroundFloor = (txtGround1.Text.Trim());
            objServiceTimelinesBEL.ExistingFirstFloor = (txtFirstfloor1.Text.Trim());
            objServiceTimelinesBEL.ExistingSecondFloor = (txtSecondFloor1.Text.Trim());
            objServiceTimelinesBEL.ExistingMezzanineFloor = (txtMezzanine1.Text.Trim());
            objServiceTimelinesBEL.ProposedBasement = (txtBaseMent2.Text.Trim());
            objServiceTimelinesBEL.ProposedGroundFloor = (txtGround2.Text.Trim());
            objServiceTimelinesBEL.ProposedFirstFloor = (txtFirstfloor2.Text.Trim());
            objServiceTimelinesBEL.ProposedSecondFloor = (txtSecondFloor2.Text.Trim());
            objServiceTimelinesBEL.ProposedMezzanineFloor = (txtMezzanine2.Text.Trim());
            objServiceTimelinesBEL.Foundation = (txtFoundation.Text.Trim());
            objServiceTimelinesBEL.Floors = (txtFloors.Text.Trim());
            objServiceTimelinesBEL.Walls = (txtWalls.Text.Trim());
            objServiceTimelinesBEL.Roofs = (txtRoofs.Text.Trim());
            objServiceTimelinesBEL.NoofLatrines = (txtLatrines.Text.Trim());
            objServiceTimelinesBEL.NoofStories = (txtStories.Text.Trim());
            objServiceTimelinesBEL.PurposeofBuildingUse = (txtbuildingPurpose.Text.Trim());
            objServiceTimelinesBEL.PreviousConstruction = (txtPreviousConstruction.Text.Trim());
            objServiceTimelinesBEL.SourceofWater = (txtWaterSource.Text.Trim());
            objServiceTimelinesBEL.CoveredArea = (txtCoveredArea.Text.Trim());
            objServiceTimelinesBEL.StiltFloor = (txtStealth.Text.Trim());
            objServiceTimelinesBEL.Mumti = (txtMumti.Text.Trim());
            objServiceTimelinesBEL.TemporaryStructExists = (drpTemoraryStructure.SelectedValue.Trim());
            objServiceTimelinesBEL.LabourHutmentArea = (txtHutment.Text.Trim());
            objServiceTimelinesBEL.AreaOtherUse = (txtOtherCharges.Text.Trim());


            try
            {
                if (btnSubmit.Text == "Save")
                {


                    int retVal = objServiceTimelinesBLL.SaveFARDetail(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        GetServiceRequestBPDetail(lblserRequest.Text);
                        if (App == "Resubmit")
                        {

                            SqlCommand cmmd = new SqlCommand("GetPaymentCheck '" + lblserRequest.Text + "'", con);
                            SqlDataAdapter addp = new SqlDataAdapter(cmmd);
                            DataSet ds = new DataSet();
                            addp.Fill(ds);
                            if (ds.Tables.Count > 0)
                            {
                                decimal count = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());

                                if (count > 0)
                                {
                                    MessageBox1.ShowSuccess("Your Payment has been revised due to change in covered area. Kindly make Payment");
                                    GetDepositesInternal("Revised");
                                    MultiViewBuildingPlan.ActiveViewIndex = 5;
                                    btnRePayment.Visible = true;
                                    BtnResubmit.Visible = false;
                                }
                                else if (count < 0)
                                {
                                    MessageBox1.ShowSuccess("Your Payment has been revised due to change in covered area.");
                                    MultiViewBuildingPlan.ActiveViewIndex = 5;
                                    btnRePayment.Visible = false;
                                    BtnResubmit.Visible = true;
                                    GetDepositesInternal("Less");
                                }
                                else
                                {
                                    MessageBox1.ShowSuccess("Building Details saved Successfully");
                                    MultiViewBuildingPlan.ActiveViewIndex = 5;
                                    btnRePayment.Visible = false;
                                    BtnResubmit.Visible = true;
                                    GetDepositesInternal("");
                                }
                            }



                            MenuMaker();

                        }
                        else
                        {
                            MessageBox1.ShowSuccess("Details Saved Successfully.Kindly Proceed To make payment");
                            MultiViewBuildingPlan.ActiveViewIndex = 5;
                            GetDepositesInternal("Same");
                            MenuMaker();

                        }

                    }
                    else
                    {
                        string message = "Record couldnt be  Save ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }

        }
        #endregion

        public void GetAllotteeRecordComplete(string username, string category)
        {

            //   objServiceTimelinesBEL.Roll = category;

            DataSet ds = new DataSet();
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                if (!string.IsNullOrEmpty(username))
                {
                    objServiceTimelinesBEL.AllotmentNo = username;


                    ds = objServiceTimelinesBLL.GetAllAllotteeDetailsFilledById(objServiceTimelinesBEL);

                    DataTable dt2 = ds.Tables[1];

                    if (ds.Tables.Count > 0)
                    {
                        if (dt2.Rows.Count > 0)
                        {
                            txtLeaseDeed.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();
                            LeaseDeedLbl.Text = dt2.Rows[0]["LeaseDeedDate"].ToString();
                            PendinDuesLbl.Text = "0";

                            UC_Service_Allotteee_Detail.AllotmentNo.Text = username;
                            UC_Service_Allotteee_Detail.Page_Load(null, null);


                            //    service_app_type.Visible = true;

                            //objServiceTimelinesBEL.IndustrialArea = ds.Tables[0].Rows[0][2].ToString();
                            //txtNameTechnical.Text = ds.Tables[0].Rows[0][36].ToString();
                            //txtLicensedPerson.Text = ds.Tables[0].Rows[0][34].ToString();
                            //txtRegistration.Text = ds.Tables[0].Rows[0][35].ToString();
                            //txtAddressPerson.Text = ds.Tables[0].Rows[0][33].ToString();
                            //lblPlotSize.Text = ds.Tables[0].Rows[0][9].ToString();
                            //txtStructuralEngineer.Text=ds.Tables[0].Rows[0][40].ToString();
                            //txtStructuralEngineerLicensedNo.Text=ds.Tables[0].Rows[0][38].ToString();
                            //txtStructuralEngineerRegistratinNo.Text=ds.Tables[0].Rows[0][39].ToString();
                            //txtStructuralEngineerAddress.Text = ds.Tables[0].Rows[0][37].ToString();
                            //lblArea.Text = objServiceTimelinesBEL.IndustrialArea;
                            //DataSet dsExecutive = new DataSet();
                            //dsExecutive = objServiceTimelinesBLL.GetExecutiveauthority(objServiceTimelinesBEL);
                            //lblEmail.Text = dsExecutive.Tables[0].Rows[0][0].ToString();
                            //lblAuthority.Text = dsExecutive.Tables[0].Rows[0][1].ToString();
                            //lblPhoneNumber.Text = dsExecutive.Tables[0].Rows[0][2].ToString();

                            if (LeaseDeedLbl.Text == "" || LeaseDeedLbl.Text == null)
                            {
                                cross1.Visible = true;
                            }
                            else
                            {
                                check1.Visible = true;
                            }
                            if (PendinDuesLbl.Text == "" || PendinDuesLbl.Text == null)
                            {
                                cross2.Visible = true;
                            }
                            else
                            {
                                check2.Visible = true;
                            }

                            if ((PendinDuesLbl.Text == "" || PendinDuesLbl.Text == null || PendinDuesLbl.Text == "0") && (LeaseDeedLbl.Text != "" || LeaseDeedLbl.Text != null))
                            {
                                msg1.Visible = true;
                                // lisave.Style.Add("pointer-events", "none");
                                msg2.Visible = false;
                                linext.Disabled = false;
                            }
                            else
                            {
                                lisave.Style.Add("pointer-events", "none");
                                linext.Disabled = true;
                                msg1.Visible = false;
                                msg2.Visible = true;
                            }

                            if (string.IsNullOrWhiteSpace(this.txtLeaseDeed.Text))
                            {
                                lableMessage.Visible = true;
                            }

                        }
                        else
                        {
                            service_app_type.Visible = false;
                        }
                    }


                }
                else
                {
                    service_app_type.Visible = false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }


        protected void drpTemoraryStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpTemoraryStructure.SelectedValue == "1")
            {
                TemporaryStructureUse.Visible = true;
            }
            else
            {
                TemporaryStructureUse.Visible = false;
            }
        }
        public void GetServiceRequestBPDetail(string servicereqid)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            objServiceTimelinesBEL.ServiceRequest = servicereqid;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceRequestBPDetail(objServiceTimelinesBEL);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtNameTechnical.Text = ds.Tables[0].Rows[0]["NameofArchitect"].ToString();
                    txtLicensedPerson.Text = ds.Tables[0].Rows[0]["ArchitectLicenseNo"].ToString();
                    txtRegistration.Text = ds.Tables[0].Rows[0]["ArchitectRegistrationNo"].ToString();
                    txtAddressPerson.Text = ds.Tables[0].Rows[0]["ArchitectAddress"].ToString();
                    lblPlotSize.Text = ds.Tables[0].Rows[0]["totalPlotArea"].ToString();


                    txtStructuralEngineer.Text = ds.Tables[0].Rows[0]["NameofStructuralEngineer"].ToString();
                    txtStructuralEngineerLicensedNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerLicensedNo"].ToString();
                    txtStructuralEngineerRegistratinNo.Text = ds.Tables[0].Rows[0]["StructuralEngineerRegistratinNo"].ToString();
                    txtStructuralEngineerAddress.Text = ds.Tables[0].Rows[0]["StructuralEngineerAddress"].ToString();


                    txtFar.Text = ds.Tables[0].Rows[0]["far"].ToString().Trim();
                    txtGroundcover.Text = ds.Tables[0].Rows[0]["GroundCoverage"].ToString().Trim();
                    txtSetBackFront.Text = ds.Tables[0].Rows[0]["front"].ToString().Trim();
                    txtSetBackRear.Text = ds.Tables[0].Rows[0]["rear"].ToString().Trim();
                    txtSetBackSide1.Text = ds.Tables[0].Rows[0]["side1"].ToString().Trim();
                    txtSetBackSide2.Text = ds.Tables[0].Rows[0]["side2"].ToString().Trim();
                    txtHeight.Text = ds.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtOccupancy.Text = ds.Tables[0].Rows[0]["Occupancy"].ToString().Trim();


                    ///////////////  Updated by Mr. Manish
                    txtBaseMent1.Text = ds.Tables[0].Rows[0]["ExistingBasement"].ToString().Trim();
                    txtBaseMent2.Text = ds.Tables[0].Rows[0]["ProposedBasement"].ToString().Trim();
                    txtGround1.Text = ds.Tables[0].Rows[0]["ExistingGroundFloor"].ToString().Trim();
                    txtGround2.Text = ds.Tables[0].Rows[0]["ProposedGroundFloor"].ToString().Trim();
                    txtFirstfloor1.Text = ds.Tables[0].Rows[0]["ExistingFirstFloor"].ToString().Trim();
                    txtFirstfloor2.Text = ds.Tables[0].Rows[0]["ProposedFirstFloor"].ToString().Trim();
                    txtSecondFloor1.Text = ds.Tables[0].Rows[0]["ExistingSecondFloor"].ToString().Trim();
                    txtSecondFloor2.Text = ds.Tables[0].Rows[0]["ProposedSecondFloor"].ToString().Trim();
                    txtMezzanine1.Text = ds.Tables[0].Rows[0]["ExistingMezzanineFloor"].ToString().Trim();
                    txtMezzanine2.Text = ds.Tables[0].Rows[0]["ProposedMezzanineFloor"].ToString().Trim();
                    txtFoundation.Text = ds.Tables[0].Rows[0]["Foundation"].ToString().Trim();
                    txtWalls.Text = ds.Tables[0].Rows[0]["Walls"].ToString().Trim();
                    txtFloors.Text = ds.Tables[0].Rows[0]["Floors"].ToString().Trim();
                    txtRoofs.Text = ds.Tables[0].Rows[0]["Roofs"].ToString().Trim();
                    txtStories.Text = ds.Tables[0].Rows[0]["NoofStories"].ToString().Trim();
                    txtLatrines.Text = ds.Tables[0].Rows[0]["NoofLatrines"].ToString().Trim();
                    txtCoveredArea.Text = ds.Tables[0].Rows[0]["CoveredArea"].ToString().Trim();
                    txtStealth.Text = ds.Tables[0].Rows[0]["StiltFloor"].ToString().Trim();
                    txtMumti.Text = ds.Tables[0].Rows[0]["Mumti"].ToString().Trim();


                    txtbuildingPurpose.Text = ds.Tables[0].Rows[0]["PurposeofBuildingUse"].ToString().Trim();
                    txtPreviousConstruction.Text = ds.Tables[0].Rows[0]["PreviousConstruction"].ToString().Trim();
                    txtWaterSource.Text = ds.Tables[0].Rows[0]["SourceofWater"].ToString().Trim();
                    string TemporaryStructExist = ds.Tables[0].Rows[0]["TemporaryStructExists"].ToString().Trim();
                    if (TemporaryStructExist.Trim() == "True")
                    {
                        drpTemoraryStructure.SelectedValue = "1";
                        TemporaryStructureUse.Visible = true;
                    }
                    else
                    {
                        drpTemoraryStructure.SelectedValue = "0";
                        TemporaryStructureUse.Visible = false;
                    }
                    txtHutment.Text = ds.Tables[0].Rows[0]["LabourHutmentArea"].ToString().Trim();
                    txtOtherCharges.Text = ds.Tables[0].Rows[0]["AreaOtherUse"].ToString().Trim();

                    try
                    {
                        ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                    }
                    catch
                    { }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        string Type = ds.Tables[2].Rows[0]["BPType"].ToString();
                        if (Type == "3")
                        {
                            RevisionDetailsTbl.Visible = true;
                            txtCoveredArea.Enabled = false;
                            MalbaPaid_lbl.Text = ds.Tables[0].Rows[0]["MalbachargesPaid"].ToString().Trim();
                            InfraPaid_lbl.Text = ds.Tables[0].Rows[0]["InfraChargesPaid"].ToString().Trim();
                            prevAppBPArea_lbl.Text = ds.Tables[0].Rows[0]["PrevAppBuiltUpArea"].ToString().Trim();
                        }
                    }

                }
                if (ds.Tables[1].Rows.Count > 0)
                {

                    lblFarByelaws.Text = ds.Tables[1].Rows[0]["far"].ToString().Trim();
                    lblGroundBylo.Text = ds.Tables[1].Rows[0]["ground_coverage_percentage"].ToString().Trim();
                    lblSetBackFront.Text = ds.Tables[1].Rows[0]["front"].ToString().Trim();
                    lblSetBackRear.Text = ds.Tables[1].Rows[0]["rear"].ToString().Trim();
                    lblSetBackSide1.Text = ds.Tables[1].Rows[0]["side1"].ToString().Trim();
                    lblSetBackSide2.Text = ds.Tables[1].Rows[0]["side2"].ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        public void GetArchitectRecord(string username, string category)
        {
            objServiceTimelinesBEL.Roll = category;
            objServiceTimelinesBEL.UserName = username;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetAllotteeRecordComplete(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtLeaseDeed.Text = ds.Tables[0].Rows[0][10].ToString();
                        objServiceTimelinesBEL.IndustrialArea = ds.Tables[0].Rows[0][2].ToString();
                        txtNameTechnical.Text = ds.Tables[0].Rows[0][36].ToString();
                        txtLicensedPerson.Text = ds.Tables[0].Rows[0][34].ToString();
                        txtRegistration.Text = ds.Tables[0].Rows[0][35].ToString();
                        txtAddressPerson.Text = ds.Tables[0].Rows[0][33].ToString();
                        lblPlotSize.Text = ds.Tables[0].Rows[0][9].ToString();
                        txtStructuralEngineer.Text = ds.Tables[0].Rows[0][40].ToString();
                        txtStructuralEngineerLicensedNo.Text = ds.Tables[0].Rows[0][38].ToString();
                        txtStructuralEngineerRegistratinNo.Text = ds.Tables[0].Rows[0][39].ToString();
                        txtStructuralEngineerAddress.Text = ds.Tables[0].Rows[0][37].ToString();
                        lblArea.Text = objServiceTimelinesBEL.IndustrialArea;
                        DataSet dsExecutive = new DataSet();
                        dsExecutive = objServiceTimelinesBLL.GetExecutiveauthority(objServiceTimelinesBEL);
                        lblEmail.Text = dsExecutive.Tables[0].Rows[0][0].ToString();
                        lblAuthority.Text = dsExecutive.Tables[0].Rows[0][1].ToString();
                        lblPhoneNumber.Text = dsExecutive.Tables[0].Rows[0][2].ToString();


                        if (string.IsNullOrWhiteSpace(this.txtLeaseDeed.Text))
                        {
                            lableMessage.Visible = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }


        protected void BindApplicationType()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            DataSet dsApplication = new DataSet();
            try
            {
                //  string SerID_in = "";


                if (string.IsNullOrEmpty(SerID_in))
                {
                    string[] SerIdarray = lblserRequest.Text.Split('/');
                    SerID_in = SerIdarray[2];
                }
                else
                {
                    //  SerID_in = Request.QueryString["id"];
                }




                dsApplication = objServiceTimelinesBLL.GetApplicationType(SerID_in);

                dsApplication.Tables[0].DefaultView.ToTable(true, "ApplicationName");
                ddlApplication.DataSource = dsApplication;
                ddlApplication.DataTextField = "ApplicationName";
                ddlApplication.DataValueField = "ApplicationID";
                ddlApplication.DataBind();
                //ddlApplication.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b1 :" + ex.Message.ToString());
            }
            finally
            {
                //objServiceTimelinesBEL = null;
                //objServiceTimelinesBLL = null;
            }

        }
        protected void BindHazardDdl()
        {


            SqlCommand cmd = new SqlCommand("spGetBuildingTypeDetail", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            ddlNature.DataSource = dt;
            ddlNature.DataTextField = "Classification";
            ddlNature.DataValueField = "ID";


            ddlNature.DataBind();
            ddlNature.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        protected void GridViewService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());

                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;

                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;

                    }
                }
            }
            catch
            {

            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    objServiceTimelinesBEL.UserName = AllottementLetterNo;

                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());


                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
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
                }
            }
            catch
            {

            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (MultiViewBuildingPlan.ActiveViewIndex == 0)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 1;
                GetServiceRequestBPDetail(lblserRequest.Text);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 1)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
                GetServiceRequestBPDetail(lblserRequest.Text);
                GetAllotteeDetail(lblserRequest.Text);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 2)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
                GetServiceRequestBPDetail(lblserRequest.Text);
                GetAllotteeDetail(lblserRequest.Text);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 3)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 4;
                GetServiceRequestBPDetail(lblserRequest.Text);
                GetAllotteeDetail(lblserRequest.Text);
            }

        }

        protected void btnprev_Click(object sender, EventArgs e)
        {
            if (MultiViewBuildingPlan.ActiveViewIndex == 1)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 0;
                Page_Load(null, null);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 2)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 1;
                GetServiceRequestBPDetail(lblserRequest.Text);
            }
            else if (MultiViewBuildingPlan.ActiveViewIndex == 3)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
                GetServiceRequestBPDetail(lblserRequest.Text);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 4)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
                GetServiceRequestBPDetail(lblserRequest.Text);
            }

        }

        protected void btnSaveAll_Click(object sender, EventArgs e)
        {

            if (MultiViewBuildingPlan.ActiveViewIndex == 0)
            {
                btnSubmit_Click(this, null);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 1)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 2)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
            }


            else if (MultiViewBuildingPlan.ActiveViewIndex == 3)
            {
                btnSaveBuildingSpec_Click(null, null);
            }


            else if (MultiViewBuildingPlan.ActiveViewIndex == 4)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowGroups();", true);
            }
        }



        protected void Pop_Click(object sender, EventArgs e)
        {
            btnFar_Click(this, null);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                


                if (ControlID.Length > 0)
                {
                    Status_Code = "10";
                    Remarks = "Applied For Building Plan. Form Filling and Building Plan Fee Pending | Applicant";

                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    string Update_Result = webService.WReturn_CUSID_STATUS(
                    ControlID,
                    UnitID,
                    ServiceID,
                    ProcessIndustryID,
                    ApplicationID,
                    Status_Code,
                    Remarks,
                    "Applicant",
                    Fee_Amount,
                    Fee_Status,
                    Transaction_ID,
                    Transaction_Date,
                    Transaction_Date_Time,
                    NOC_Certificate_Number,
                    NOC_URL,
                    ISNOC_URL_ActiveYesNO,
                    passsalt,
                    Request_ID,
                    Objection_Rejection_Code,
                    Is_Certificate_Valid_Life_Time,
                    Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7
                    );

                    HidStatus.Value = Update_Result;
                }

                if (HidStatus.Value == "SUCCESS")
                {

                    btnSubmit_Click(this, null);

                }
                else if ((HidStatus.Value == "FAILED"))
                {


                    HidStatus.Value = "FAILED";
                    string str = "Exception occured in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                    return;



                }
                else
                {
                   
                    string str = "Exception occured in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + HidStatus.Value + "');", true);
                    return;
                }

            }


            catch (Exception ex)
            {

                HidStatus.Value = "FAILED";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString() + "');", true);
                return;

            }

        }

        protected void btnSaveArchitect_Click(object sender, EventArgs e)
        {
            btnSaveBuildingSpec_Click(null, null);
        }

        protected void btnSaveF_Click(object sender, EventArgs e)
        {
            btnFar_Click(this, null);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowGroups();", true);
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            try
            {

                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Gateway is Under Maintenance. Sorry For Inconvinience');", true);
                //return;

                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFC(lblserRequest.Text, "UPSIDC");


                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                }
                else
                {

                    objServiceTimelinesBEL.industrialAreaID = Convert.ToInt32(lblIAID.Text);
                    objServiceTimelinesBEL.choicearea = double.Parse(lblPlotArea.Text);
                    objServiceTimelinesBEL.CoveredArea = txtCoveredArea.Text;
                    objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text;
                    dsR = objServiceTimelinesBLL.GetBuildingPlanCharges(objServiceTimelinesBEL);

                    if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[0]; }
                    if (dt_Fee.Rows.Count > 0)
                    {

                        try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                        gm = new GeneralMethod();
                        //string PaymentGetwayURL = gm.SendToPaymentGetway(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Land Allotment", txtCompanyname.Text);
                        string PaymentGetwayURL = gm.SendToPaymentGetwayHDFC(TotalCharges, TransactionId_UPSIDC, lblserRequest.Text, "Building Plan", lblallotteName.Text, lblAllotteeEmail.Text, lblAllotteePhone.Text);

                        if (PaymentGetwayURL == "Failed")
                        {
                            string MSG = "Errro Ocured In Processing !";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + MSG + "');", true);
                        }
                        else
                        {
                            Response.Redirect(PaymentGetwayURL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.ToString());
            }
        }



        protected void Btn_FirstP_Click(object sender, EventArgs e)
        {

            if (ddlCaseType.SelectedValue == "0")
            {

                string str = "Please select case type";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                MultiViewBuildingPlan.ActiveViewIndex = 1;
                return;
            }
            if (ddlCaseType.SelectedValue == "1")
            {
                if (txtBuiltUpArea.Text.Length <= 0)
                {
                    string str = "Please enter total builtup area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                    MultiViewBuildingPlan.ActiveViewIndex = 1;
                    return;
                }
            }
            if (ddlCaseType.SelectedValue == "2")
            {
                if (txtBuiltUpArea.Text.Length <= 0)
                {
                    string str = "Please enter total builtup area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                    MultiViewBuildingPlan.ActiveViewIndex = 1;
                    return;
                }
            }
            if (ddlCaseType.SelectedValue == "3")
            {
                if (txtPrevBuiltUpArea.Text.Length <= 0)
                {
                    string str = "Please enter previously approved builtup area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                    MultiViewBuildingPlan.ActiveViewIndex = 1;
                    return;
                }
                if (txtRevBuiltUpArea.Text.Length <= 0)
                {
                    string str = "Please enter revised builtup area";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                    MultiViewBuildingPlan.ActiveViewIndex = 1;
                    return;
                }

                //if(Convert.ToDecimal(txtPrevBuiltUpArea.Text)<Convert.ToDecimal(txtRevBuiltUpArea.Text))
                //{
                //    string str = "Revised builtup area is more then previously approved area. Kindly choose Re-Erect Building Case Type";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                //    MultiViewBuildingPlan.ActiveViewIndex = 1;
                //    return;
                //}
            }


            GetDeposites();
            btnGenerate.Visible = true;
            Btn_FirstP.Visible = false;
            btnResetChoice.Visible = true;
            ddlCaseType.Enabled = false;
            txtPrevBuiltUpArea.Enabled = false;
            txtRevBuiltUpArea.Enabled = false;
            chk_InfraPaid.Enabled = false;
            chk_MalbaPaid.Enabled = false;
            txtBuiltUpArea.Enabled = false;

        }


        protected void BntResubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string[] SerIdarray = SerReqID.Split('/');
                string service_id = SerIdarray[1];
                string AllotteeId = SerIdarray[2];

                SqlCommand cmd = new SqlCommand("select Allotmentletterno, ControlId, UnitId ,ServiceId, IndustrialArea  from [dbo].[AllotteeMaster]  where [AllotteeID] = '" + AllotteeId + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                ControlID     = dt.Rows[0]["ControlId"].ToString();
                UnitID        = dt.Rows[0]["UnitId"].ToString();
                string IANAME = dt.Rows[0]["IndustrialArea"].ToString();
                ServiceID     = dt.Rows[0]["ServiceId"].ToString();


                if (ServiceID == "SC21003")
                {
                    Status_Code = "13";
                    Remarks = "Building Plan Application Resubmitted.";
                }
                else
                {
                    Status_Code = "14";
                    Remarks = "Form Re-Submitted To | DA(" + IANAME + ")";
                }
                if (ControlID.Length > 0)
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    string Update_Result = webService.WReturn_CUSID_STATUS(
                    ControlID,
                    UnitID,
                    ServiceID,
                    ProcessIndustryID,
                    ApplicationID,
                    Status_Code,
                    Remarks,
                    "DA " + IANAME,
                    Fee_Amount,
                    Fee_Status,
                    Transaction_ID,
                    Transaction_Date,
                    Transaction_Date_Time,
                    NOC_Certificate_Number,
                    NOC_URL,
                    ISNOC_URL_ActiveYesNO,
                    passsalt,
Request_ID,
Objection_Rejection_Code,
Is_Certificate_Valid_Life_Time,
Certificate_EXP_Date_DDMMYYYY,
D1,
D2,
D3,
D4,
D5,
D6,
D7

                    );

                    if (Update_Result == "SUCCESS")
                    //if ("SUCCESS" == "SUCCESS")
                    {
                        belBookDetails objServiceTimelinesBEL = new belBookDetails();
                        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                        objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;
                        int retVal = objServiceTimelinesBLL.SetBPResubmit(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            MessageBox1.ShowSuccess("Application Resubmitted");
                            Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + lblserRequest.Text.Trim(), false);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox1.ShowWarning("Your Application is rejected kindly re-apply by using Resubmission service of nivesh mitra");
                        return;
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void btnRePayment_Click(object sender, EventArgs e)
        {
            try
            {

                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Payment Gateway is Under Maintenance. Sorry For Inconvinience');", true);
                //return;

                string[] SerIdarray = SerReqID.Split('/');
                string service_id = SerIdarray[1];
                string AllotteeId = SerIdarray[2];
                SqlCommand cmd = new SqlCommand("select Allotmentletterno, ControlId, UnitId ,ServiceId, IndustrialArea,NMRequestID  from [dbo].[AllotteeMaster]  where [AllotteeID] = '" + AllotteeId + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string SWCControlID  = dt.Rows[0]["ControlId"].ToString();
                string SWCUnitID     = dt.Rows[0]["UnitId"].ToString();
                string SWCServiceID  = dt.Rows[0]["ServiceID"].ToString();
                string SWCRequest_ID = dt.Rows[0]["NMRequestID"].ToString();
                if (SWCServiceID == "SC21002")
                {
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet dss = webService.WGetUBPaymentDetails(SWCControlID, SWCUnitID, SWCServiceID, passsalt, SWCRequest_ID);
                    if (dss.Tables.Count > 0)
                    {
                        DataTable datat = dss.Tables[0];

                        if (datat.Rows.Count > 0)
                        {
                            string status = datat.Rows[0]["status_code"].ToString();
                            if (status == "07")
                            {
                                MessageBox1.ShowWarning("Your Application is rejected kindly re-apply by using Resubmission service of nivesh mitra");
                                return;
                            }
                        }
                    }

                }
                else
                {
                    SqlCommand cmmd = new SqlCommand("select * from tbl_NMSWP_RejectionTrack where ControlID='"+SWCControlID+"' and UnitID='"+SWCUnitID+"' and ServiceID='"+SWCServiceID+"' and RequestID='"+ SWCRequest_ID + "' and IsRejected=1 ", con);
                    SqlDataAdapter aadp = new SqlDataAdapter(cmmd);
                    DataTable dtt = new DataTable();
                    aadp.Fill(dtt);
                    if(dtt.Rows.Count>0)
                    {
                        MessageBox1.ShowWarning("Your Application is rejected kindly re-apply by using Resubmission service of nivesh mitra");
                        return;
                    }
                }
                decimal TotalCharges;
                DataSet dsR = new DataSet();
                DataTable dt_Fee = new DataTable();
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                GeneralMethod gm = new GeneralMethod();
                string TransactionId_UPSIDC = gm.CreateTransactionDataBeforePaymentGetewayHDFCrevisedBp(lblserRequest.Text, "UPSIDC");
                if (TransactionId_UPSIDC == "Failed")
                {
                    string Message = "Failed In Processing";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + Message + "');", true);
                }
                else
                {

                    objServiceTimelinesBEL.industrialAreaID  = Convert.ToInt32(lblIAID.Text);
                    objServiceTimelinesBEL.choicearea        = double.Parse(lblPlotArea.Text);
                    objServiceTimelinesBEL.CoveredArea       = txtCoveredArea.Text;
                    objServiceTimelinesBEL.ServiceRequestNO  = lblserRequest.Text;
                    dsR = objServiceTimelinesBLL.GetBuildingPlanChargesRevised(objServiceTimelinesBEL);

                    if (dsR.Tables[0].Rows.Count > 0) { dt_Fee = dsR.Tables[2]; }
                    if (dt_Fee.Rows.Count > 0)
                    {

                        try { TotalCharges = Convert.ToDecimal(dt_Fee.Compute("SUM(applicablecharge)", string.Empty)); } catch { TotalCharges = 0; }

                        gm = new GeneralMethod();
                        //string PaymentGetwayURL = gm.SendToPaymentGetway(TotalCharges, TransactionId_UPSIDC, ServiceReqNo, "Land Allotment", txtCompanyname.Text);
                        string PaymentGetwayURL = gm.SendToPaymentGetwayHDFC(TotalCharges, TransactionId_UPSIDC, lblserRequest.Text, "Building Plan", lblallotteName.Text, lblAllotteeEmail.Text, lblAllotteePhone.Text);

                        if (PaymentGetwayURL == "Failed")
                        {
                            string MSG = "Errro Ocured In Processing !";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + MSG + "');", true);
                        }
                        else
                        {
                            Response.Redirect(PaymentGetwayURL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.ToString());
            }
        }




        protected void ddlCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCaseType.SelectedValue == "3")
            {
                Div_Revision.Visible = true;
                Div_NewBuilding.Visible = false;
                MultiViewBuildingPlan.ActiveViewIndex = 1;

            }
            else if (ddlCaseType.SelectedValue == "1")
            {
                Div_Revision.Visible = false;
                Div_NewBuilding.Visible = true;
                MultiViewBuildingPlan.ActiveViewIndex = 1;
            }
            else if (ddlCaseType.SelectedValue == "2")
            {
                Div_Revision.Visible = false;
                Div_NewBuilding.Visible = true;
                MultiViewBuildingPlan.ActiveViewIndex = 1;
            }
            else
            {
                Div_Revision.Visible = false;
                Div_NewBuilding.Visible = false;
                MultiViewBuildingPlan.ActiveViewIndex = 1;
            }
        }

        protected void btnResetChoice_Click(object sender, EventArgs e)
        {
            ddlCaseType.SelectedValue = "0";
            Div_NewBuilding.Visible = false;
            Div_Revision.Visible = false;
            chk_InfraPaid.Checked = false;
            chk_MalbaPaid.Checked = false;
            txtBuiltUpArea.Text = "";
            txtPrevBuiltUpArea.Text = "";
            txtRevBuiltUpArea.Text = "";
            MultiViewBuildingPlan.ActiveViewIndex = 1;
            btnGenerate.Visible = false;
            btnResetChoice.Visible = false;
            Btn_FirstP.Visible = true;
            ddlCaseType.Enabled = true;
            txtPrevBuiltUpArea.Enabled = true;
            txtRevBuiltUpArea.Enabled = true;
            chk_InfraPaid.Enabled = true;
            chk_MalbaPaid.Enabled = true;
            txtBuiltUpArea.Enabled = true;

        }

        protected void chk_MalbaPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MalbaPaid.Checked)
            {
                string str = "Please Remember to upload the payment receipt failing which your application may be rejected";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                MultiViewBuildingPlan.ActiveViewIndex = 1;
                return;
            }

        }

        protected void chk_InfraPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_InfraPaid.Checked)
            {
                string str = "Please Remember to upload the payment receipt failing which your application may be rejected";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                MultiViewBuildingPlan.ActiveViewIndex = 1;
                return;
            }
        }
    }

}