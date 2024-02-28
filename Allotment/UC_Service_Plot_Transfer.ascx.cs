using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;


namespace Allotment
{
    public partial class UC_Service_Plot_Transfer : System.Web.UI.UserControl
    {
        public string HiddenClassRM { get; private set; }
        public string HiddenClassAssistence { get; private set; }
        public string HiddenClassDraftMan { get; private set; }
        public string HiddenClassAssistenceManager { get; private set; }
        public string HiddenClassManager { get; private set; }

        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        #endregion
        SqlConnection con;

        public string SerReqID { get; set; }
        public string SerID_in { get; set; }
        public string AllottementLetterNo { get; set; }
        public string UserBy { get; set; }

        // "ENTRY", "VIEW"
        public string page_type { get; set; }


        string cat = "";


        public void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(page_type)) { page_type = "VIEW"; } else { page_type = "ENTRY"; }
            if (page_type == "View")
            {
                lisave.Style.Add("pointer-events", "none");

                Readonly();
            }
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            // int userid = 0;
            string SerReqID_in = Request.QueryString["serviceId"];
            string SerID_in = Request.QueryString["id"];
            string SerReqID = HttpUtility.HtmlDecode(SerReqID_in);


            if (string.IsNullOrEmpty(SerReqID))
            {
                linext.Style.Add("pointer-events", "none");
                checkcon.Text = "";
                lblserRequest.Text = SerID_in;
                MultiViewBuildingPlan.ActiveViewIndex = 0;



                UC_Service_Allotteee_Detail.AllotmentNo.Text = AllottementLetterNo;
                UC_Service_Allotteee_Detail.Page_Load(null, null);

                service_app_type.Visible = true;


            }
            else
            {
                lblServiceReqNo.Text = SerReqID;
                lblserRequest.Text = SerReqID;
                checkcon.Text = SerReqID;
                string[] SerIdarray = lblserRequest.Text.Split('/');




                UC_Service_Doc_Upload_View.SerReqID = SerReqID;
                UC_Service_Doc_Upload_View.page_type = page_type;

                UC_Service_Doc_Upload_View1.SerReqID = SerReqID;
                UC_Service_Doc_Upload_View1.page_type = page_type;
                UC_Service_Doc_Upload_View1.checklistid = (1000).ToString();

                UC_Service_Allotteee_Detail.AllotmentNo.Text = AllottementLetterNo;
                UC_Service_Allotteee_Detail.AllotteeId = SerIdarray[2];
                UC_Service_Allotteee_Detail.Page_Load(null, null);

                UC_Service_Payment_Detail.AllotmentNo.Text = AllottementLetterNo;
                UC_Service_Payment_Detail.AllotteeId = SerIdarray[2];
                UC_Service_Payment_Detail.SerReqID = SerReqID;
                UC_Service_Payment_Detail.Page_Load(null, null);




                //if (SerIdarray[1] == "3")
                //{
                //    Response.Redirect("WaterConnection.aspx?ServiceID=" + lblserRequest.Text.Trim(), false);
                //}
                //if (SerIdarray[1] == "4")
                //{
                //    Response.Redirect("AllotteePlotTransfer.aspx?ServiceID=" + lblserRequest.Text.Trim(), false);
                //}
                //if (MultiViewBuildingPlan.ActiveViewIndex < 1)
                //{
                //    MultiViewBuildingPlan.ActiveViewIndex = 1;
                //}




            }



            int DesignationId = Convert.ToInt32(Session["DesignationID"]);



            string strRoll = Convert.ToString((Session["Roll"]));
            if (strRoll == "RM")
            {
                HiddenClassRM = "display:show";
            }
            if (cat == "2")
            {
                HiddenClassRM = "display:show";

            }
            else
            {
            }



            if (!IsPostBack)
            {
                LblAllotteeId.Text = "0";
                BindApplicationType();
                bindIndustrialAreaDetail();
                bindCompanytypeddl();


                ListItemCollection collection = new ListItemCollection();




                if (lblserRequest.Text.Trim() == "4")
                {
                    collection.Add(new ListItem("Transfer Of Vacant Plot"));
                    collection.Add(new ListItem("Transfer Of Non Vacant Plot"));
                    collection.Add(new ListItem("Transfer amongst family member"));
                    collection.Add(new ListItem("Transfer amongst Holding/group Companies"));
                    collection.Add(new ListItem("Transfer By Opration of law"));
                    collection.Add(new ListItem("Transfer to 100% Export Oriented Unit"));
                    collection.Add(new ListItem("Transfer of death or disablement of Allottee"));

                }




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


                ddlCaseType.DataSource = collection;
                ddlCaseType.DataBind();



                DataTable temp_shareholder_details = new DataTable();
                temp_shareholder_details.TableName = "temp_shareholder_details";
                temp_shareholder_details.Columns.Add(new DataColumn("ShareHolderName", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("SharePer", typeof(decimal)));
                temp_shareholder_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_shareholder_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_shareholder_details"] = temp_shareholder_details;
                temp_shareholder_details_DataBind();


                DataTable temp_trustee_details = new DataTable();
                temp_trustee_details.TableName = "temp_trustee_details";
                temp_trustee_details.Columns.Add(new DataColumn("TrusteeName", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_trustee_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_trustee_details"] = temp_trustee_details;
                temp_trustee_details_DataBind();


                DataTable temp_directors_details = new DataTable();
                temp_directors_details.TableName = "temp_directors_details";
                temp_directors_details.Columns.Add(new DataColumn("DirectorName", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Din_Pan", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_directors_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_directors_details"] = temp_directors_details;
                temp_director_details_DataBind();


                DataTable temp_partnership_details = new DataTable();
                temp_partnership_details.TableName = "temp_partnership_details";
                temp_partnership_details.Columns.Add(new DataColumn("PartnerName", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("PartnershipPer", typeof(decimal)));
                temp_partnership_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("Email", typeof(string)));
                temp_partnership_details.Columns.Add(new DataColumn("Phone", typeof(string)));



                ViewState["temp_partnership_details"] = temp_partnership_details;
                temp_partnership_details_DataBind();






            }




            if (MultiViewBuildingPlan.ActiveViewIndex < 0)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 0;
            }


            if (MultiViewBuildingPlan.ActiveViewIndex > 0)
            {
                GetServiceRequestBPDetail(lblserRequest.Text);
                //  bindIndustrialAreaDetail();
                GetAllotteeDetail(lblserRequest.Text);
            }
            else
            {
                GetAllotteeRecordComplete(AllottementLetterNo, cat);
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SerReqID))
                {
                    view(SerReqID);
                }
            }

        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiViewBuildingPlan.ActiveViewIndex = index;
            if (index == 6)
            {
                checkid.Text = (1000).ToString();
            }
            else
            {
                checkid.Text = "";
            }
            Page_Load(null, null);

        }




        public void GetServiceChecklists(string text)
        {
            MessageBox1.ShowError(text);
        }


        public void GetAllotteeDetail(string req)
        {
            try
            {


                lblallotteName.Text = "";
                lblAllotteeAddress.Text = "";
                LblallotteeIA.Text = "";
                LblallotteeReg.Text = "";
                LblallotteePlotNo.Text = "";

                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForMail '" + req + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblallotteName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblAllotteeAddress.Text = dt.Rows[0]["Address"].ToString();
                    LblallotteeIA.Text = dt.Rows[0]["IndustrialArea"].ToString();
                    LblallotteeReg.Text = dt.Rows[0]["RegionName"].ToString();
                    LblallotteePlotNo.Text = dt.Rows[0]["PlotNo"].ToString();




                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblAreaName.Text = dt.Rows[0]["IndustrialArea"].ToString();
                    ddlArea.SelectedValue = dt.Rows[0]["INDUSID"].ToString();
                    txtPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    txtPlotSize.Text = dt.Rows[0]["TotalAllottedplotArea"].ToString();


                    // lblTelNo

                    lblNameofAllottee.Text = dt.Rows[0]["AllotteeName"].ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.ToString());
            }
        }


        private void send_mail(string name, string mailid)
        {
            try
            {
              MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(mailid);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/Mail_Transfer_of_Plot.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{Description}", "Follow The Link To Fill Transfree Details");

                StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/AllotteeApplication.aspx?ServiceReqNo=" + lblserRequest.Text.Trim() + "");

                newmsg.Subject = "UPSIDCeServe: Acknowledgement-Request to register for Transfer Of Plot ";
                newmsg.BodyHtml = StrContent;
                //newmsg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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
            }

            objServiceTimelinesBEL.IndustrialArea = ddlArea.SelectedValue.Trim();
            objServiceTimelinesBEL.ServiceRequest = String.Empty;
            objServiceTimelinesBEL.Remarks = String.Empty;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(lblserRequest.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserBy;
            objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
            objServiceTimelinesBEL.CoveredArea = "0";
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
                            string message = "Record Save SucessFully ";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                            Response.Redirect(Path.GetFileName(Request.Path) + "?ServiceID=" + lblServiceRequestID.Text.Trim(), false);


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
                    //if (retVal > 0)
                    //{
                    //    string message = "Record Save SucessFully ";
                    //    string script = "window.onload = function(){ alert('";
                    //    script += message;
                    //    script += "')};";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                    //}
                    //else
                    //{
                    //    string message = "Record couldn't be  Save ";
                    //    string script = "window.onload = function(){ alert('";
                    //    script += message;
                    //    script += "')};";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    //}
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }







        protected void btnFar_Click(object sender, EventArgs e)
        {

            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (txtTransfereeEmail.Text.Trim().Length > 0)
                {
                    command.CommandText = ("[AllotteeApplicationTransferDetails_sp] '" + lblserRequest.Text + "','" + lblPlotNo.Text.Trim() + "','" + lblNameofAllottee.Text.Trim() + "','" + lblAreaName.Text.Trim() + "','" + lblTelNo.Text.Trim() + "','" + lblPanNo.Text.Trim() + "','" + txtProposedTransfereeName.Text.Trim() + "','" + txtProposedTransfereeAddress.Text.Trim() + "','" + txtTransfereeTelNo.Text.Trim() + "','" + txtTransfereePan.Text.Trim() + "','" + txtReasonofTransfer.Text.Trim() + "',  '" + txtTransfereeEmail.Text.Trim() + "' ");
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                    if (transactionResult)
                    {
                        transaction.Commit();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record Inserted Succesfully');", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "alert('Please Give Email Address !')", true);
                }
            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;

            }





            //objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;
            //objServiceTimelinesBEL.Far = float.Parse(txtFar.Text);
            //objServiceTimelinesBEL.Groundcover = float.Parse(txtGroundcover.Text);
            //objServiceTimelinesBEL.SetBackFront = float.Parse(txtSetBackFront.Text);
            //objServiceTimelinesBEL.SetBackRear = float.Parse(txtSetBackRear.Text);
            //objServiceTimelinesBEL.SetBackSide1 = float.Parse(txtSetBackSide1.Text);
            //objServiceTimelinesBEL.SetBackSide2 = float.Parse(txtSetBackSide2.Text);
            //objServiceTimelinesBEL.Height = float.Parse(txtHeight.Text);
            //objServiceTimelinesBEL.Occupancy = float.Parse(txtOccupancy.Text);

            //objServiceTimelinesBEL.NatureofOccupancy = ddlNature.SelectedValue.Trim();
            //objServiceTimelinesBEL.ModifiedBy = UserBy;
            //objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;


            ///////////////////  Update By Mr Manish
            //objServiceTimelinesBEL.ExistingBasement = (txtBaseMent1.Text);
            //objServiceTimelinesBEL.ExistingGroundFloor = (txtGround1.Text.Trim());
            //objServiceTimelinesBEL.ExistingFirstFloor = (txtFirstfloor1.Text.Trim());
            //objServiceTimelinesBEL.ExistingSecondFloor = (txtSecondFloor1.Text.Trim());
            //objServiceTimelinesBEL.ExistingMezzanineFloor = (txtMezzanine1.Text.Trim());
            //objServiceTimelinesBEL.ProposedBasement = (txtBaseMent2.Text.Trim());
            //objServiceTimelinesBEL.ProposedGroundFloor = (txtGround2.Text.Trim());
            //objServiceTimelinesBEL.ProposedFirstFloor = (txtFirstfloor2.Text.Trim());
            //objServiceTimelinesBEL.ProposedSecondFloor = (txtSecondFloor2.Text.Trim());
            //objServiceTimelinesBEL.ProposedMezzanineFloor = (txtMezzanine2.Text.Trim());
            //objServiceTimelinesBEL.Foundation = (txtFoundation.Text.Trim());
            //objServiceTimelinesBEL.Floors = (txtFloors.Text.Trim());
            //objServiceTimelinesBEL.Walls = (txtWalls.Text.Trim());
            //objServiceTimelinesBEL.Roofs = (txtRoofs.Text.Trim());
            //objServiceTimelinesBEL.NoofLatrines = (txtLatrines.Text.Trim());
            //objServiceTimelinesBEL.NoofStories = (txtStories.Text.Trim());
            //objServiceTimelinesBEL.PurposeofBuildingUse = (txtbuildingPurpose.Text.Trim());
            //objServiceTimelinesBEL.PreviousConstruction = (txtPreviousConstruction.Text.Trim());
            //objServiceTimelinesBEL.SourceofWater = (txtWaterSource.Text.Trim());
            ////////////////////////////////


            //try
            //{
            //    if (btnSubmit.Text == "Save")
            //    {




            //        int retVal = objServiceTimelinesBLL.SaveFARDetail(objServiceTimelinesBEL);
            //        if (retVal > 0)
            //        {
            //            GetServiceRequestBPDetail(lblserRequest.Text);


            //        }
            //        else
            //        {
            //            string message = "Record couldnt be  Save ";
            //            string script = "window.onload = function(){ alert('";
            //            script += message;
            //            script += "')};";
            //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Oops! error occured :" + ex.Message.ToString());
            //}


            //try
            //{
            //    if (btnSubmit.Text == "Save")
            //    {
            //        belBookDetails objServiceTimelinesBEL = new belBookDetails();
            //        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            //        objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;

            //        int retVal = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
            //        if (retVal > 0)
            //        {
            //            send_mail("", "gopal.j.singh@gmail.com ");
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage()", true);
            //        }
            //        else
            //        {

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Oops! error occured :" + ex.Message.ToString());
            //}
            //finally
            //{
            //    objServiceTimelinesBEL = null;
            //    objServiceTimelinesBLL = null;
            //}
        }
        #endregion






        public void GetServiceRequestBPDetail(string servicereqid)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("select * from PlotTransferDetails  where ServiceRequestNo = '" + servicereqid + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    //  lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    //  lblAreaName.Text = dt.Rows[0]["IAName"].ToString();
                    //  lblNameofAllottee.Text = dt.Rows[0]["AllotteeName"].ToString();


                    lblTelNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblPanNo.Text = dt.Rows[0]["Pan"].ToString();
                    txtProposedTransfereeName.Text = dt.Rows[0]["TransfereeName"].ToString();
                    txtProposedTransfereeAddress.Text = dt.Rows[0]["AddressTransferee"].ToString();
                    txtTransfereeTelNo.Text = dt.Rows[0]["TransferreePhone"].ToString();
                    txtTransfereePan.Text = dt.Rows[0]["TransfereePanNo"].ToString();
                    txtReasonofTransfer.Text = dt.Rows[0]["TransferReason"].ToString();
                    txtTransfereeEmail.Text = dt.Rows[0]["TransfreeEmail"].ToString();

                }
            }
            catch
            {


            }
        }





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


                            service_app_type.Visible = true;

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
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                string SerID_in = "";


                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string[] SerIdarray = lblserRequest.Text.Split('/');
                    SerID_in = SerIdarray[2];
                }
                else
                {
                    SerID_in = Request.QueryString["id"];
                }



                dsApplication = objServiceTimelinesBLL.GetApplicationType(SerID_in);
                dsApplication.Tables[0].DefaultView.ToTable(true, "ApplicationName");
                ddlApplication.DataSource = dsApplication;
                ddlApplication.DataTextField = "ApplicationName";
                ddlApplication.DataValueField = "ApplicationID";
                ddlApplication.DataBind();
                //    ddlApplication.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured1 :" + ex.Message.ToString());
            }
            finally
            {
                //objServiceTimelinesBEL = null;
                //objServiceTimelinesBLL = null;
            }

        }




        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                //ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                //drpdwnIA.DataSource = ds;
                //drpdwnIA.DataTextField = "IAName";
                //drpdwnIA.DataValueField = "Id";
                //drpdwnIA.DataBind();
                //drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));
                //if (pIAName != null)
                //    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }



        protected void GridViewService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    objServiceTimelinesBEL.UserName = AllottementLetterNo;


                    //  int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    //  int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());


                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());




                    //   Service_Id = Convert.ToInt32(e.Row.DataKeys[e.Row.RowIndex][0].ToString());
                    //   Service_TimeLine_ID = Convert.ToInt32(e.Row.DataKeys[e.Row.RowIndex][1].ToString());


                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds1.Tables[0];
                    if (dtDoc.Rows.Count > 0)
                    {
                        e.Row.FindControl("lbView").Visible = true;
                        e.Row.FindControl("lbView1").Visible = true;
                        // e.Row.FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbView1").Visible = false;
                        // e.Row.FindControl("lbDelete").Visible = false;
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
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 1)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
                GetAllotteeDetail(lblserRequest.Text);
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 2)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
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
            }
            else if (MultiViewBuildingPlan.ActiveViewIndex == 3)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 4)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
            }

        }



        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            // request genratetion page
            if (MultiViewBuildingPlan.ActiveViewIndex == 0)
            {
                btnSubmit_Click(this, null);
            }
            // Payment page
            else if (MultiViewBuildingPlan.ActiveViewIndex == 1)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 2;
            }
            // Document page
            else if (MultiViewBuildingPlan.ActiveViewIndex == 2)
            {
                MultiViewBuildingPlan.ActiveViewIndex = 3;
            }

            else if (MultiViewBuildingPlan.ActiveViewIndex == 3)
            {

                btnFar_Click(this, null);

            }
            else if (MultiViewBuildingPlan.ActiveViewIndex == 4)
            {
                btnSubmit1_Click(null, null);
            }
            else if (MultiViewBuildingPlan.ActiveViewIndex == 5)
            {
                BtnProjectInsert_Click(null, null);
            }
            else if (MultiViewBuildingPlan.ActiveViewIndex == 6)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowGroups();", true);
            }
        }



        protected void pop_Click(object sender, EventArgs e)
        {
            //  btnFar_Click(this, null);

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.ServiceRequestNO = lblserRequest.Text;

            int retVal = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
            if (retVal > 0)
            {


                //  send_mail(txtProposedTransfereeName.Text.Trim(), txtTransfereeEmail.Text.Trim());



                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                string role = _objLoginInfo.Roll;

                if (role == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('ServiceTimelines-IU.aspx')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('ServiceRequestSubmitted.aspx')", true);

                }


            }
        }

        //public void view(string ServiceReqNo)
        //{


        //    SqlCommand cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByServiceReqNo", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ServiceReqNo", ServiceReqNo);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);

        //    DataTable dt1 = ds.Tables[0];
        //    DataTable dt2 = ds.Tables[1];
        //    DataTable dt3 = ds.Tables[2];

        //    if (dt1.Rows.Count > 0)
        //    {

        //        lblAuthorisedSignatory.Text = dt1.Rows[0]["AuthorisedSignatory"].ToString();
        //        lblFirmCompanyName.Text = dt1.Rows[0]["CompanyName"].ToString();
        //        lblCompanyConstitution.Text = dt1.Rows[0]["FirmConstitution"].ToString();
        //        lblSIgnatoryEmail.Text = dt1.Rows[0]["SignatoryEmail"].ToString();
        //        lblSignatoryMobile.Text = dt1.Rows[0]["SignatoryPhone"].ToString();
        //        lblAddress.Text = dt1.Rows[0]["SignatoryAddress"].ToString();
        //        lblPanNo.Text = dt1.Rows[0]["PanNo"].ToString();
        //        lblCinNo.Text = dt1.Rows[0]["CinNo"].ToString();
        //        lblRequiredplot.Text = dt1.Rows[0]["PlotSize"].ToString();
        //        lblIndustrialArea.Text = dt1.Rows[0]["IndustrialArea"].ToString();
        //        lblStatusAsonDate.Text = dt1.Rows[0]["Status_Name"].ToString();
        //        lblDateofApplication.Text = dt1.Rows[0]["DateofAllotmentNo"].ToString();
        //        lblRegionalOffice.Text = dt1.Rows[0]["RegionalOffice"].ToString();
        //        lblApplicationNo.Text = dt1.Rows[0]["AllotteeID"].ToString();




        //        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Individual/Sole Proprietorship firm")
        //        {
        //            GridView6.Visible = true;
        //            P2.InnerText = "Individual/Sole Proprietorship firm Details";
        //            GridView6.DataSource = dt2; GridView6.DataBind();
        //        }
        //        else
        //        {
        //            GridView6.Visible = false;
        //        }
        //        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Public Limited")
        //        {
        //            GridView7.Visible = true;
        //            P2.InnerText = "Directors Details";
        //            GridView7.DataSource = dt2; GridView7.DataBind();
        //        }
        //        else
        //        {
        //            GridView7.Visible = false;
        //        }
        //        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Private Limited")
        //        {
        //            GridView8.Visible = true;
        //            P2.InnerText = "ShareHolders Details";
        //            GridView8.DataSource = dt2; GridView8.DataBind();
        //        }
        //        else
        //        {
        //            GridView8.Visible = false;
        //        }
        //        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Partnership Firm")
        //        {
        //            GridView9.Visible = true;
        //            P2.InnerText = "Partners Details";
        //            GridView9.DataSource = dt2; GridView9.DataBind();
        //        }
        //        else
        //        {
        //            GridView9.Visible = false;
        //        }
        //        if (dt1.Rows[0]["FirmConstitution"].ToString().Trim() == "Society & Trust")
        //        {
        //            GridView10.Visible = true;
        //            P2.InnerText = "Trustee Details";
        //            GridView10.DataSource = dt2; GridView10.DataBind();
        //        }
        //        else
        //        {
        //            GridView10.Visible = false;
        //        }




        //        lblDescription.Text = dt3.Rows[0]["IndustryType"].ToString();
        //        lblEstimatedCost.Text = dt3.Rows[0]["EstimatedCostOfProject"].ToString();
        //        LabelblEstimatedEmployment.Text = dt3.Rows[0]["EstimatedEmploymentGeneration"].ToString();
        //        lblCoveredArea.Text = dt3.Rows[0]["CoveredArea"].ToString();
        //        lblOpenArea.Text = dt3.Rows[0]["OpenAreaRequired"].ToString();
        //        lblLand.Text = dt3.Rows[0]["LandDetails"].ToString();
        //        lblBuilding.Text = dt3.Rows[0]["BuildingDetails"].ToString();
        //        lblMachineryEquipment.Text = dt3.Rows[0]["MachineryEquipmentsDetails"].ToString();
        //        lblOtherAssets.Text = dt3.Rows[0]["OtherFixedAssets"].ToString();
        //        lblOtherExpenses.Text = dt3.Rows[0]["OtherExpenses"].ToString();
        //        lblQtySolid.Text = dt3.Rows[0]["IndustrialEffluentSolidqty"].ToString();
        //        lblChemicalSolid.Text = dt3.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
        //        lblQtyLiquid.Text = dt3.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
        //        lblChemicalLiquid.Text = dt3.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
        //        lblQtyGaseous.Text = dt3.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
        //        lblChemicalGaseous.Text = dt3.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
        //        if (dt3.Rows[0]["FumeGenerationStatus"].ToString() == "True")
        //        {
        //            Span1.InnerText = "Yes";
        //            Div1.Visible = true;
        //            lblQuantity.Text = dt3.Rows[0]["FumeQuantity"].ToString();
        //            lblNature.Text = dt3.Rows[0]["FumeNature"].ToString();
        //        }
        //        else
        //        {
        //            Span1.InnerText = "No";
        //            Div1.Visible = false;
        //            lblNature.Text = "";
        //            lblQuantity.Text = "";
        //        }
        //        lblmeasure1.Text = dt3.Rows[0]["EffluentTreatmentMeasure1"].ToString();
        //        lblmeasure2.Text = dt3.Rows[0]["EffluentTreatmentMeasure2"].ToString();
        //        lblmeasure3.Text = dt3.Rows[0]["EffluentTreatmentMeasure3"].ToString();
        //        lblUnits.Text = dt3.Rows[0]["PowerReqInKW"].ToString();
        //        lblFirstYear1.Text = dt3.Rows[0]["TelephoneReqFirstYear1"].ToString();
        //        lblFirstYear2.Text = dt3.Rows[0]["TelephoneReqFirstYear2"].ToString();
        //        lblUltimateRequirement1.Text = dt3.Rows[0]["TelephoneReqUltimate1"].ToString();
        //        lblUltimateRequirement2.Text = dt3.Rows[0]["TelephoneReqUltimate2"].ToString();
        //        if (dt3.Rows[0]["ApplicantPrioritySpecification"].ToString() == "True")
        //        {
        //            Span2.InnerText = "Yes";
        //            Div2.Visible = true;
        //            lblSpecification.Text = dt3.Rows[0]["ApplicantPrioritySpecification"].ToString();
        //        }
        //        else
        //        {
        //            Span2.InnerText = "No";
        //            Div2.Visible = false;
        //            lblSpecification.Text = "";
        //        }

        //        lblNetworth.Text = dt3.Rows[0]["NetTurnOver"].ToString();
        //        lblExpansionland.Text = dt3.Rows[0]["ExpansionOfLand"].ToString();
        //        lblExportOriented.Text = dt3.Rows[0]["ExportOriented"].ToString();
        //    }


        //    cmd.Dispose();




        //}


        public void view(string ServiceReqNo)
        {


            SqlCommand cmd = new SqlCommand("spc_GetAllAllotteeApplicationDetailsByServiceReqNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceReqNo", ServiceReqNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt_project = ds.Tables[2];

            if (dt.Rows.Count > 0)
            {

                LblAllotteeId.Text = dt.Rows[0]["AllotteeID"].ToString();
                ddlArea.SelectedValue = dt.Rows[0]["IndustrialArea"].ToString();
                lblServiceRequestID.Text = dt.Rows[0]["ApplicationID"].ToString();

                txtPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();

                txtPlotSize.Text = dt.Rows[0]["PlotSize"].ToString();


                txtCompanyname.Text = dt.Rows[0]["CompanyName"].ToString();


                ddlcompanytype.SelectedValue = dt.Rows[0]["FirmConstitution"].ToString().Trim();
                if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "2")
                {

                    tr2.Visible = true;
                    ViewState["temp_shareholder_details"] = dt1;
                    temp_shareholder_details_DataBind();
                }
                else
                {
                    tr2.Visible = false;
                }
                if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "5")
                {

                    tr9.Visible = true;
                    ViewState["temp_partnership_details"] = dt1;
                    temp_partnership_details_DataBind();
                }
                else
                {
                    tr9.Visible = false;
                }
                if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "4")
                {

                    tr4.Visible = true;
                    ViewState["temp_trustee_details"] = dt1;
                    temp_trustee_details_DataBind();
                }
                else
                {
                    tr4.Visible = false;
                }
                if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "3")
                {

                    tr8.Visible = true;

                    ViewState["temp_directors_details"] = dt1;
                    temp_director_details_DataBind();
                }
                else
                {
                    tr8.Visible = false;
                }
                if (dt.Rows[0]["FirmConstitution"].ToString().Trim() == "1")
                {

                    tr5.Visible = true;
                    tr6.Visible = true;
                    tr7.Visible = true;

                    txtIndividualName.Text = dt.Rows[0]["AllotteeName"].ToString().Trim();
                    txtIndividualAddress.Text = dt.Rows[0]["Address"].ToString().Trim();
                    txtIndividualEmail.Text = dt.Rows[0]["emailID"].ToString().Trim();
                    txtIndividualPhone.Text = dt.Rows[0]["PhoneNo"].ToString().Trim();

                }
                else
                {
                    txtIndividualName.Text = "";
                    txtIndividualAddress.Text = "";
                    txtIndividualEmail.Text = "";
                    txtIndividualPhone.Text = "";
                    chk2.Checked = false;
                    tr5.Visible = false;
                    tr6.Visible = false;
                    tr7.Visible = false;

                }
                txtAuthorisedSignatory.Text = dt.Rows[0]["AuthorisedSignatory"].ToString().Trim();
                txtSignatoryAddress.Text = dt.Rows[0]["SignatoryAddress"].ToString().Trim();
                txtSignatoryEmail.Text = dt.Rows[0]["SignatoryEmail"].ToString().Trim();
                txtSignatoryPhone.Text = dt.Rows[0]["SignatoryPhone"].ToString().Trim();
                txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                txtCinNo.Text = dt.Rows[0]["CinNo"].ToString().Trim();

                if (dt_project.Rows.Count > 0)
                {


                    txttypeofindustry.Text = dt_project.Rows[0]["IndustryType"].ToString();
                    txtestimatedcost.Text = dt_project.Rows[0]["EstimatedCostOfProject"].ToString();
                    txtestimatedemployment.Text = dt_project.Rows[0]["EstimatedEmploymentGeneration"].ToString();
                    txtcoveredarea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                    txtopenarearequired.Text = dt_project.Rows[0]["OpenAreaRequired"].ToString();
                    txtland.Text = dt_project.Rows[0]["LandDetails"].ToString();
                    txtbuilding.Text = dt_project.Rows[0]["BuildingDetails"].ToString();
                    txtmachinery.Text = dt_project.Rows[0]["MachineryEquipmentsDetails"].ToString();
                    txtFixedAssets.Text = dt_project.Rows[0]["OtherFixedAssets"].ToString();
                    txtOtherExpenses.Text = dt_project.Rows[0]["OtherExpenses"].ToString();
                    txteffluentsolidqty.Text = dt_project.Rows[0]["IndustrialEffluentSolidqty"].ToString();
                    txteffluentsolidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentSolidComposition"].ToString();
                    txteffluentliquidqty.Text = dt_project.Rows[0]["IndustrialEffluentLiquidqty"].ToString();
                    txteffluentliquidcomposition.Text = dt_project.Rows[0]["IndustrialEffluentLiquidComposition"].ToString();
                    txteffluentgaseousqty.Text = dt_project.Rows[0]["IndustrialEffluentGaseousqty"].ToString();
                    txteffluentgaseouscomposition.Text = dt_project.Rows[0]["IndustrialEffluentGaseousComposition"].ToString();
                    txtProjectStartMonths.Text = dt_project.Rows[0]["ProjectStartMonths"].ToString();
                    txtWorkExperience.Text = dt_project.Rows[0]["WorkExperience"].ToString();
                    if (dt_project.Rows[0]["FumeGenerationStatus"].ToString() == "True")
                    {
                        chkfumes.Checked = true;
                        fumesdiv.Visible = true;
                        txtfumeqty.Text = dt_project.Rows[0]["FumeQuantity"].ToString();
                        txtfumenature.Text = dt_project.Rows[0]["FumeNature"].ToString();
                    }
                    else
                    {
                        chkfumes.Checked = false;
                        fumesdiv.Visible = false;
                        txtfumeqty.Text = "";
                        txtfumenature.Text = "";
                    }
                    txteffluenttreatmentmeasure1.Text = dt_project.Rows[0]["EffluentTreatmentMeasure1"].ToString();
                    txteffluenttreatmentmeasure2.Text = dt_project.Rows[0]["EffluentTreatmentMeasure2"].ToString();
                    txteffluenttreatmentmeasure3.Text = dt_project.Rows[0]["EffluentTreatmentMeasure3"].ToString();
                    txtpowerreq.Text = dt_project.Rows[0]["PowerReqInKW"].ToString();
                    txttelephonefirstyearreq1.Text = dt_project.Rows[0]["TelephoneReqFirstYear1"].ToString();
                    txttelephonefirstyearreq2.Text = dt_project.Rows[0]["TelephoneReqFirstYear2"].ToString();
                    txttelephoneUltimateyearreq1.Text = dt_project.Rows[0]["TelephoneReqUltimate1"].ToString();
                    txttelephoneUltimateyearreq2.Text = dt_project.Rows[0]["TelephoneReqUltimate2"].ToString();

                    if (dt_project.Rows[0]["ApplicantPriorityStatus"].ToString() == "True")
                    {
                        chkpriority.Checked = true;
                        prioritydiv.Visible = true;
                        bindPriorityDdl();
                        try
                        {
                            ddlPriority.SelectedValue = dt_project.Rows[0]["ApplicantPrioritySpecification"].ToString().Trim();
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        chkpriority.Checked = false;
                        prioritydiv.Visible = false;
                        ddlPriority.SelectedIndex = -1;
                    }
                    txtNetWorth.Text = dt_project.Rows[0]["NetTurnOver"].ToString().Trim();
                    if (dt_project.Rows[0]["ExpansionOfLand"].ToString() == "" || dt_project.Rows[0]["ExpansionOfLand"].ToString() == null)
                    { Ddl_Expansion.SelectedIndex = -1; }
                    else { Ddl_Expansion.SelectedValue = dt_project.Rows[0]["ExpansionOfLand"].ToString().Trim(); }
                    if (dt_project.Rows[0]["ExportOriented"].ToString() == "" || dt_project.Rows[0]["ExportOriented"].ToString() == null) { Drop1.SelectedIndex = -1; }
                    else { Drop1.SelectedValue = dt_project.Rows[0]["ExportOriented"].ToString().Trim(); }

                }


            }
            cmd.Dispose();




        }

        #region "Transfree Entry Code"
        public void temp_shareholder_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
                gridshareholder.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                gridshareholder.DataSource = dt;
                gridshareholder.DataBind();
            }


        }
        public void temp_partnership_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
                PartnershipFirmGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                PartnershipFirmGrid.DataSource = dt;
                PartnershipFirmGrid.DataBind();
            }


        }

        public void temp_trustee_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
                Trustee_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Trustee_details_grid.DataSource = dt;
                Trustee_details_grid.DataBind();
            }


        }

        public void temp_director_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
                DirectorsGrid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                DirectorsGrid.DataSource = dt;
                DirectorsGrid.DataBind();
            }


        }


        protected void insert_shareholder_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];

            string shareholdername = (gridshareholder.FooterRow.FindControl("txtShareholderName_insert") as TextBox).Text;
            string shareper = (gridshareholder.FooterRow.FindControl("txtShareper_insert") as TextBox).Text;
            string address = (gridshareholder.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string email = (gridshareholder.FooterRow.FindControl("txtEmail_insert") as TextBox).Text;
            string phone = (gridshareholder.FooterRow.FindControl("txtPhone_insert") as TextBox).Text;


            if (shareholdername != "")
            {
                if (shareper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["ShareHolderName"] = shareholdername;
                    dr["SharePer"] = shareper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_shareholder_details"] = dt;

                    temp_shareholder_details_DataBind();

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide ShareHolder Name');", true);
                return;
            }

        }

        protected void insert_Partnership_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];


            string Partnershipname = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerName_insert") as TextBox).Text;
            string partnershipper = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnershipPer_insert") as TextBox).Text;
            string address = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerAddress_insert") as TextBox).Text;
            string email = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerEmail_insert") as TextBox).Text;
            string phone = (PartnershipFirmGrid.FooterRow.FindControl("txtPartnerPhone_insert") as TextBox).Text;


            if (Partnershipname != "")
            {
                if (partnershipper != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["PartnerName"] = Partnershipname;
                    dr["PartnershipPer"] = partnershipper;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_partnership_details"] = dt;

                    temp_partnership_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Partner Name');", true);
                return;
            }

        }



        protected void insert_trustee_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];


            string trusteename = (Trustee_details_grid.FooterRow.FindControl("txtTrusteeName_insert") as TextBox).Text;
            string address = (Trustee_details_grid.FooterRow.FindControl("txtTAddress_insert") as TextBox).Text;
            string email = (Trustee_details_grid.FooterRow.FindControl("txtTEmail_insert") as TextBox).Text;
            string phone = (Trustee_details_grid.FooterRow.FindControl("txtTPhone_insert") as TextBox).Text;


            if (trusteename != "")
            {


                DataRow dr = dt.NewRow();
                dr["TrusteeName"] = trusteename;
                dr["Address"] = address;
                dr["Email"] = email;
                dr["Phone"] = phone;

                dt.Rows.Add(dr);
                dt.AcceptChanges();


                ViewState["temp_trustee_details"] = dt;

                temp_trustee_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Trustee Name');", true);
                return;
            }

        }



        protected void insert_Director_details(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];


            string Directorname = (DirectorsGrid.FooterRow.FindControl("txtDirectorName_insert") as TextBox).Text;
            string din_pan = (DirectorsGrid.FooterRow.FindControl("txtDIN_PAN_insert") as TextBox).Text;
            string address = (DirectorsGrid.FooterRow.FindControl("txtDirectorAddress_insert") as TextBox).Text;
            string phone = (DirectorsGrid.FooterRow.FindControl("txtDirectorPhone_insert") as TextBox).Text;
            string email = (DirectorsGrid.FooterRow.FindControl("txtDirectorEmail_insert") as TextBox).Text;


            if (Directorname != "")
            {
                if (din_pan != "")
                {

                    DataRow dr = dt.NewRow();
                    dr["DirectorName"] = Directorname;
                    dr["Din_Pan"] = din_pan;
                    dr["Address"] = address;
                    dr["Email"] = email;
                    dr["Phone"] = phone;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                    ViewState["temp_directors_details"] = dt;

                    temp_director_details_DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Din/Pan');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Director Name');", true);
                return;
            }

        }







        protected void ShareHolderDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_shareholder_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_shareholder_details"] = dt;

            dt.AcceptChanges();


            temp_shareholder_details_DataBind();


        }
        protected void PartnershipDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_partnership_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_partnership_details"] = dt;

            dt.AcceptChanges();


            temp_partnership_details_DataBind();


        }
        protected void TrusteeDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_trustee_details"] = dt;

            dt.AcceptChanges();


            temp_trustee_details_DataBind();


        }

        protected void DirectorDelete_Click(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_directors_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_directors_details"] = dt;

            dt.AcceptChanges();


            temp_director_details_DataBind();


        }

        private void bindIndustrialAreaDetail()
        {

            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetail(objServiceTimelinesBEL);
                ddlArea.DataSource = ds;
                ddlArea.DataTextField = "IAName";
                ddlArea.DataValueField = "Id";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        private void bindCompanytypeddl()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetCompanyType();
                ddlcompanytype.DataSource = ds;
                ddlcompanytype.DataTextField = "company_type";
                ddlcompanytype.DataValueField = "id";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            if (ddlcompanytype.SelectedValue == "0")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                //   txtCompanyname.Enabled = false;
                // txtCinNo.Enabled = false;


            }

            if (ddlcompanytype.SelectedValue == "1")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = true;
                tr6.Visible = true;
                tr7.Visible = true;
                tr8.Visible = false;
                tr9.Visible = false;
                //  txtCompanyname.Enabled = false;
                //  txtCinNo.Enabled = false;


                lblnameremark.Text = "Individual/Sole Proprietory Name <br/><sm>(along with father name)";

            }
            if (ddlcompanytype.SelectedValue == "2")
            {


                tr2.Visible = true;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
                tr9.Visible = false;
            }
            if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;
                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;
            }
            if (ddlcompanytype.SelectedValue == "4")
            {

                tr2.Visible = false;
                tr4.Visible = true;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;

                //txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }
            if (ddlcompanytype.SelectedValue == "5")
            {

                tr2.Visible = false;

                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = true;
                // txtCompanyname.Enabled = true;
                //txtCinNo.Enabled = true;

            }

        }



        protected void checkbox2_checked_changed(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                txtAuthorisedSignatory.Text = txtIndividualName.Text;
                txtSignatoryAddress.Text = txtIndividualAddress.Text;
                txtSignatoryPhone.Text = txtIndividualPhone.Text;
                txtSignatoryEmail.Text = txtIndividualEmail.Text;
            }
            else
            {
                txtAuthorisedSignatory.Text = "";
                txtSignatoryAddress.Text = ""; ;
                txtSignatoryPhone.Text = "";
                txtSignatoryEmail.Text = "";
            }
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {

            int alloteeid = 0;
            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {


                //if (ddlArea.SelectedIndex == 0)
                // {
                //     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Select Industrial Area First');", true);
                //     ddlArea.Focus();

                //    return;
                // }
                // if (ddlcompanytype.SelectedIndex == 0)
                // {
                //     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Select Firm Constitution First');", true);
                //     return;
                // }

                // if(txtPlotNo.Text==""||txtPlotNo.Text==null)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Plot Size');", true);
                //    return;
                //}


                //if (ddlcompanytype.SelectedValue == "2" || ddlcompanytype.SelectedValue == "3" || ddlcompanytype.SelectedValue == "4" || ddlcompanytype.SelectedValue == "5")
                //{
                //if (txtCompanyname.Text == "" || txtCompanyname.Text == null)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Company Name');", true);
                //    return;
                //}

                //}



                //if (ddlcompanytype.SelectedValue == "1" )
                //{
                //    if (txtIndividualName.Text == "" || txtIndividualName.Text == null || txtIndividualAddress.Text == "" || txtIndividualAddress.Text == null)
                //    {
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Name and Address of the Allottee');", true);
                //        return;
                //    }
                //    if (txtIndividualPhone.Text == "" || txtIndividualPhone.Text == null || txtIndividualEmail.Text == "" || txtIndividualEmail.Text == null)
                //    {
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Phone and Email of the Allottee');", true);
                //        return;
                //    }

                //}

                // if (txtAuthorisedSignatory.Text == "" || txtAuthorisedSignatory.Text == null || txtSignatoryAddress.Text == "" || txtSignatoryAddress.Text == null)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Name and Address of the person who will operate the application');", true);
                //    return;
                //}
                //if (txtSignatoryPhone.Text == "" || txtSignatoryPhone.Text == null || txtSignatoryEmail.Text == "" || txtSignatoryEmail.Text == null)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('Please Provide Phone and Email of the person who will operate the application');", true);
                //    return;
                //}
                if (Validate1())
                {
                    command = new SqlCommand(@"Delete from AllotteeApplicationShareHoldersDetail where AllotteeID=" + LblAllotteeId.Text + "", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));

                    command = new SqlCommand(@"Delete from AllotteeApplicationDirectorsDetail where AllotteeID=" + LblAllotteeId.Text + "", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));

                    command = new SqlCommand(@"Delete from AllotteeApplicationTrusteeDetail where AllotteeID=" + LblAllotteeId.Text + "", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));

                    command = new SqlCommand(@"Delete from AllotteeApplicationPartnershipDetail where AllotteeID=" + LblAllotteeId.Text + "", con, transaction);
                    transactionResult = (transactionResult && (command.ExecuteNonQuery() >= 0));


                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = lblServiceReqNo.Text;
                    objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text);
                    objServiceTimelinesBEL.Allotteename = txtIndividualName.Text.Trim();
                    objServiceTimelinesBEL.Email = txtIndividualEmail.Text.Trim();
                    objServiceTimelinesBEL.PhoneNumber = txtIndividualPhone.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
                    objServiceTimelinesBEL.plotSize = txtPlotSize.Text.Trim();
                    objServiceTimelinesBEL.IndustrialArea = ddlArea.SelectedValue.Trim();
                    objServiceTimelinesBEL.ApplicationAdress1 = txtIndividualAddress.Text.Trim();
                    objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                    objServiceTimelinesBEL.AuthorisedSignatory = txtAuthorisedSignatory.Text.Trim();
                    objServiceTimelinesBEL.SignatoryAddress = txtSignatoryAddress.Text.Trim();
                    objServiceTimelinesBEL.SignatoryPhone = txtSignatoryPhone.Text.Trim();
                    objServiceTimelinesBEL.SignatoryEmail = txtSignatoryEmail.Text.Trim();
                    objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                    objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                    objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim();
                    objServiceTimelinesBEL.CinNo = txtCinNo.Text.Trim();
                    objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                    objServiceTimelinesBEL.ControlId = "";
                    objServiceTimelinesBEL.UnitId = "";
                    objServiceTimelinesBEL.ServiceId = "";

                    objServiceTimelinesBEL.Preference1 = "";
                    objServiceTimelinesBEL.Preference2 = "";
                    objServiceTimelinesBEL.Preference3 = "";


                    objServiceTimelinesBEL.Status = 13;




                    if (ddlcompanytype.SelectedIndex == 1)
                    {
                        ds = objServiceTimelinesBLL.SetApplicationRequestService(objServiceTimelinesBEL);

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblServiceRequestID.Text = ds.Tables[0].Rows[0][1].ToString();
                                LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();

                            }
                        }
                        else
                        {
                            string message = "Record couldnt be  Save ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                            return;
                        }
                    }

                    if (ddlcompanytype.SelectedIndex == 2)
                    {



                        ds = objServiceTimelinesBLL.SetApplicationRequestService(objServiceTimelinesBEL);


                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblServiceRequestID.Text = ds.Tables[0].Rows[0][1].ToString();
                                LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                                DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        alloteeid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                                        string ShareholderName = dr1["ShareHolderName"].ToString();
                                        decimal shareper = Convert.ToDecimal(dr1["SharePer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        command = new SqlCommand(@"insert into AllotteeApplicationShareHoldersDetail(AllotteeID, ShareholderName, Address, SharePer, Phone, Email) 
                                                           values(@alloteeid,@ShareholderName, @Address, @shareper,@phone, @email)", con, transaction);

                                        command.CommandType = CommandType.Text;
                                        command.Parameters.AddWithValue("@alloteeid", alloteeid);
                                        command.Parameters.AddWithValue("@ShareholderName", ShareholderName);
                                        command.Parameters.AddWithValue("@Address", Address);
                                        command.Parameters.AddWithValue("@shareper", shareper);
                                        command.Parameters.AddWithValue("@phone", phone);
                                        command.Parameters.AddWithValue("@email", email);

                                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                                    }

                                }
                            }
                        }
                        else
                        {
                            string message = "Record couldnt be  Save ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                            return;
                        }
                    }

                    if (ddlcompanytype.SelectedIndex == 3)
                    {


                        ds = objServiceTimelinesBLL.SetApplicationRequestService(objServiceTimelinesBEL);


                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblServiceRequestID.Text = ds.Tables[0].Rows[0][1].ToString();

                                LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();


                                DataTable temp3 = (DataTable)ViewState["temp_directors_details"];
                                if (temp3.Rows.Count > 0)
                                {
                                    foreach (DataRow dr3 in temp3.Rows)
                                    {
                                        alloteeid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                                        string DirectorName = dr3["DirectorName"].ToString();
                                        string din_pan = dr3["Din_Pan"].ToString();
                                        string Address = dr3["Address"].ToString();
                                        string phone = dr3["Phone"].ToString();
                                        string email = dr3["Email"].ToString();


                                        command = new SqlCommand(@"insert into AllotteeApplicationDirectorsDetail(AllotteeID, DirectorName, Address, DIN_PAN, Phone, Email) 
                                                           values(@AllotteeID,@DirectorName, @Address, @DIN_PAN,@Phone, @EmailId)", con, transaction);

                                        command.CommandType = CommandType.Text;
                                        command.Parameters.AddWithValue("@AllotteeID", alloteeid);
                                        command.Parameters.AddWithValue("@DirectorName", DirectorName);
                                        command.Parameters.AddWithValue("@Address", Address);
                                        command.Parameters.AddWithValue("@DIN_PAN", din_pan);
                                        command.Parameters.AddWithValue("@Phone", phone);
                                        command.Parameters.AddWithValue("@EmailId", email);

                                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                                    }

                                }
                            }
                        }
                        else
                        {
                            string message = "Record couldnt be  Save ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                            return;
                        }
                    }

                    if (ddlcompanytype.SelectedIndex == 4)
                    {

                        ds = objServiceTimelinesBLL.SetApplicationRequestService(objServiceTimelinesBEL);


                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblServiceRequestID.Text = ds.Tables[0].Rows[0][1].ToString();
                                LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                                DataTable temp1 = (DataTable)ViewState["temp_trustee_details"];
                                if (temp1.Rows.Count > 0)
                                {
                                    foreach (DataRow dr2 in temp1.Rows)
                                    {
                                        alloteeid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                                        string TrusteeName = dr2["TrusteeName"].ToString();
                                        string Address = dr2["Address"].ToString();
                                        string phone = dr2["Phone"].ToString();
                                        string email = dr2["Email"].ToString();

                                        command = new SqlCommand(@"insert into AllotteeApplicationTrusteeDetail(AllotteeID, TrusteeName, Address,Phone, Email) 
                                                             values(@AllotteeID,@TrusteeName, @Address,@Phone, @EmailId)", con, transaction);

                                        command.CommandType = CommandType.Text;
                                        command.Parameters.AddWithValue("@AllotteeID", alloteeid);
                                        command.Parameters.AddWithValue("@TrusteeName", TrusteeName);
                                        command.Parameters.AddWithValue("@Address", Address);
                                        command.Parameters.AddWithValue("@Phone", phone);
                                        command.Parameters.AddWithValue("@EmailId", email);

                                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));
                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "Record couldnt be  Save ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                            return;
                        }
                    }
                    if (ddlcompanytype.SelectedIndex == 5)
                    {

                        ds = objServiceTimelinesBLL.SetApplicationRequestService(objServiceTimelinesBEL);

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblServiceRequestID.Text = ds.Tables[0].Rows[0][1].ToString();
                                LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        alloteeid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        command = new SqlCommand(@"insert into AllotteeApplicationPartnershipDetail(AllotteeID, PartnerName, Address,PartnershipPer,Phone, Email) 
                                                     values(@AllotteeID,@PartnerName, @Address,@PartnershipPer,@Phone, @EmailId)", con, transaction);

                                        command.CommandType = CommandType.Text;
                                        command.Parameters.AddWithValue("@AllotteeID", alloteeid);
                                        command.Parameters.AddWithValue("@PartnerName", PartnerName);
                                        command.Parameters.AddWithValue("@Address", Address);
                                        command.Parameters.AddWithValue("@PartnershipPer", Partnershipper);
                                        command.Parameters.AddWithValue("@Phone", phone);
                                        command.Parameters.AddWithValue("@EmailId", email);

                                        transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));

                                    }

                                }
                            }
                        }
                        else
                        {
                            string message = "Record couldnt be  Save ";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage1('" + message + "');", true);
                            return;
                        }
                    }





                    if (transactionResult)
                    {
                        transaction.Commit();
                        string message = "Transfree Details Saved Successfully. Proceed to Fill Project Details";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                    }
                    else
                    {
                        transaction.Rollback();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error');", true);
                        return;
                    }
                }
                else
                {
                    string message = "Fill All Required Value";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                {
                    transaction.Rollback();
                }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }


        }
        public bool Validate1()
        {
            try
            {
                bool remark = true;

                if (ddlArea.SelectedIndex == 0)
                {
                    ddlArea.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    ddlArea.Style.Clear();

                }
                if (txtPlotNo.Text.Length <= 0)
                {
                    txtPlotNo.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtPlotNo.Style.Clear();

                }
                if (ddlcompanytype.SelectedIndex == 0)
                {
                    ddlcompanytype.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    ddlcompanytype.Style.Clear();

                }
                if (txtCompanyname.Text.Length <= 0)
                {
                    txtCompanyname.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtCompanyname.Style.Clear();

                }
                if (txtPanNo.Text.Length <= 0)
                {
                    txtPanNo.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtPanNo.Style.Clear();

                }
                //if (txtCinNo.Text.Length <= 0)
                //{
                //    txtCinNo.Style["border-color"] = "red";
                //    remark = false;
                //}
                //else
                //{
                //    txtCinNo.Style.Clear();

                //}
                if (ddlcompanytype.SelectedIndex == 1)
                {
                    if (txtIndividualName.Text.Length <= 0)
                    {
                        txtIndividualName.Style["border-color"] = "red";
                        remark = false;
                    }
                    else
                    {
                        txtIndividualName.Style.Clear();

                    }
                    if (txtIndividualAddress.Text.Length <= 0)
                    {
                        txtIndividualAddress.Style["border-color"] = "red";
                        remark = false;
                    }
                    else
                    {
                        txtIndividualAddress.Style.Clear();

                    }
                    if (txtIndividualPhone.Text.Length <= 0)
                    {
                        txtIndividualPhone.Style["border-color"] = "red";
                        remark = false;
                    }
                    else
                    {
                        txtIndividualPhone.Style.Clear();

                    }
                    if (txtIndividualEmail.Text.Length <= 0)
                    {
                        txtIndividualEmail.Style["border-color"] = "red";
                        remark = false;
                    }
                    else
                    {
                        txtIndividualEmail.Style.Clear();

                    }
                }
                if (txtAuthorisedSignatory.Text.Length <= 0)
                {
                    txtAuthorisedSignatory.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtAuthorisedSignatory.Style.Clear();

                }
                if (txtSignatoryAddress.Text.Length <= 0)
                {
                    txtSignatoryAddress.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtSignatoryAddress.Style.Clear();

                }
                if (txtSignatoryPhone.Text.Length <= 0)
                {
                    txtSignatoryPhone.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtSignatoryPhone.Style.Clear();

                }
                if (txtSignatoryEmail.Text.Length <= 0)
                {
                    txtSignatoryEmail.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtSignatoryEmail.Style.Clear();

                }

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    DataTable temp = (DataTable)ViewState["temp_shareholder_details"];
                    if (temp.Rows.Count <= 0)
                    {


                        gridshareholder.CssClass = gridshareholder.CssClass.Replace("table-bordered", "");
                        gridshareholder.Attributes.Add("Style", "border:1px solid #FF0000 !important");




                        remark = false;
                    }
                    else
                    {
                        gridshareholder.Attributes.Add("Style", "border:1px solid #ddd !important");
                        gridshareholder.CssClass = "table-bordered";
                    }
                }
                if (ddlcompanytype.SelectedIndex == 3)
                {
                    DataTable temp = (DataTable)ViewState["temp_directors_details"];
                    if (temp.Rows.Count <= 0)
                    {


                        DirectorsGrid.CssClass = DirectorsGrid.CssClass.Replace("table-bordered", "");
                        DirectorsGrid.Attributes.Add("Style", "border:1px solid #FF0000 !important");




                        remark = false;
                    }
                    else
                    {
                        DirectorsGrid.Style.Clear();


                    }
                }
                if (ddlcompanytype.SelectedIndex == 4)
                {
                    DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                    if (temp.Rows.Count <= 0)
                    {


                        Trustee_details_grid.CssClass = Trustee_details_grid.CssClass.Replace("table-bordered", "");
                        Trustee_details_grid.Attributes.Add("Style", "border:1px solid #FF0000 !important");




                        remark = false;
                    }
                    else
                    {
                        Trustee_details_grid.Style.Clear();


                    }
                }
                if (ddlcompanytype.SelectedIndex == 5)
                {
                    DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                    if (temp.Rows.Count <= 0)
                    {
                        PartnershipFirmGrid.CssClass = PartnershipFirmGrid.CssClass.Replace("table-bordered", "");
                        PartnershipFirmGrid.Attributes.Add("Style", "border:1px solid #FF0000 !important");
                        remark = false;
                    }
                    else
                    {
                        PartnershipFirmGrid.Style.Clear();
                    }
                }



                if (remark == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
        protected void chkpriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpriority.Checked == true)
            {
                prioritydiv.Visible = true;
                bindPriorityDdl();
            }
            else
            {
                txtapplicantpriorityspecification.Text = "";
                prioritydiv.Visible = false;
            }


        }

        protected void chkfumes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfumes.Checked == true)
            {
                fumesdiv.Visible = true;
            }
            else
            {
                txtfumeqty.Text = "";
                txtfumenature.Text = "";
                fumesdiv.Visible = false;
            }


        }

        private void bindPriorityDdl()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from IndustryPriorityCategoryMaster", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlPriority.DataSource = dt;
                ddlPriority.DataTextField = "Category";
                ddlPriority.DataValueField = "Category";
                ddlPriority.DataBind();
                ddlPriority.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {

            string error = "";
            con.Open();
            SqlCommand command = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
            command.Connection = con;
            command.Transaction = transaction;
            bool transactionResult = true;
            try
            {
                if (Validate2())
                {
                    int fume_status = 0; int priority_status = 0;
                    if (chkfumes.Checked == true)
                    {
                        fume_status = 1;
                    }
                    else
                    {
                        fume_status = 0;
                    }
                    if (chkpriority.Checked == true)
                    {
                        priority_status = 1;
                    }
                    else
                    {
                        priority_status = 0;
                    }

                    command = new SqlCommand(@"AllotteeApplicationProjectDetails_sp2", con, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicantId", Convert.ToInt32(LblAllotteeId.Text));
                    command.Parameters.AddWithValue("@IndustryType", txttypeofindustry.Text.Trim());
                    if (txtestimatedcost.Text == "")
                    {
                        command.Parameters.Add("@EstimatedCostOfProject", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EstimatedCostOfProject", txtestimatedcost.Text.Trim());
                    }
                    if (txtestimatedemployment.Text == "")
                    {
                        command.Parameters.Add("@EstimatedEmploymentGeneration", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EstimatedEmploymentGeneration", txtestimatedemployment.Text.Trim());
                    }
                    if (txtcoveredarea.Text == "")
                    {
                        command.Parameters.Add("@CoveredArea", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CoveredArea", txtcoveredarea.Text.Trim());
                    }
                    if (txtopenarearequired.Text == "")
                    {
                        command.Parameters.Add("@OpenAreaRequired", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OpenAreaRequired", txtopenarearequired.Text.Trim());
                    }
                    if (txtland.Text == "")
                    {
                        command.Parameters.Add("@LandDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LandDetails", txtland.Text.Trim());
                    }
                    if (txtbuilding.Text == "")
                    {
                        command.Parameters.Add("@BuildingDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@BuildingDetails", txtbuilding.Text.Trim());
                    }
                    if (txtmachinery.Text == "")
                    {
                        command.Parameters.Add("@MachineryEquipmentsDetails", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MachineryEquipmentsDetails", txtmachinery.Text.Trim());
                    }
                    command.Parameters.AddWithValue("@IndustrialEffluentSolidqty", txteffluentsolidqty.Text.Trim());
                    command.Parameters.AddWithValue("@IndustrialEffluentSolidComposition", txteffluentsolidcomposition.Text.Trim());
                    command.Parameters.AddWithValue("@IndustrialEffluentLiquidqty", txteffluentliquidqty.Text.Trim());
                    command.Parameters.AddWithValue("@IndustrialEffluentLiquidComposition", txteffluentliquidcomposition.Text.Trim());
                    command.Parameters.AddWithValue("@IndustrialEffluentGaseousqty", txteffluentgaseousqty.Text.Trim());
                    command.Parameters.AddWithValue("@IndustrialEffluentGaseousComposition", txteffluentgaseouscomposition.Text.Trim());
                    command.Parameters.AddWithValue("@FumeGenerationStatus", fume_status);
                    command.Parameters.AddWithValue("@FumeQuantity", txtfumeqty.Text.Trim());
                    command.Parameters.AddWithValue("@FumeNature", txtfumenature.Text.Trim());
                    command.Parameters.AddWithValue("@EffluentTreatmentMeasure1", txteffluenttreatmentmeasure1.Text.Trim());
                    command.Parameters.AddWithValue("@EffluentTreatmentMeasure2", txteffluenttreatmentmeasure2.Text.Trim());
                    command.Parameters.AddWithValue("@EffluentTreatmentMeasure3", txteffluenttreatmentmeasure3.Text.Trim());
                    command.Parameters.AddWithValue("@PowerReqInKW", txtpowerreq.Text.Trim());
                    command.Parameters.AddWithValue("@TelephoneReqFirstYear1", txttelephonefirstyearreq1.Text.Trim());
                    command.Parameters.AddWithValue("@TelephoneReqFirstYear2", txttelephonefirstyearreq2.Text.Trim());
                    command.Parameters.AddWithValue("@TelephoneReqUltimate1", txttelephoneUltimateyearreq1.Text.Trim());
                    command.Parameters.AddWithValue("@TelephoneReqUltimate2", txttelephoneUltimateyearreq2.Text.Trim());
                    command.Parameters.AddWithValue("@ApplicantPriorityStatus", priority_status);
                    if (chkpriority.Checked == true)
                    {
                        command.Parameters.AddWithValue("@ApplicantPrioritySpecification", ddlPriority.SelectedItem.Text.Trim());
                    }
                    else
                    {
                        command.Parameters.Add("@ApplicantPrioritySpecification", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    if (txtFixedAssets.Text == "")
                    {
                        command.Parameters.Add("@OtherFixedAssets", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OtherFixedAssets", txtFixedAssets.Text.Trim());
                    }
                    if (txtOtherExpenses.Text == "")
                    {
                        command.Parameters.Add("@OtherExpenses", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OtherExpenses", txtOtherExpenses.Text.Trim());
                    }
                    command.Parameters.AddWithValue("@projectstartmonths", txtProjectStartMonths.Text.Trim());
                    command.Parameters.AddWithValue("@workexperience", txtWorkExperience.Text.Trim());
                    if (txtNetWorth.Text == "")
                    { command.Parameters.Add("@NetTurnOver", System.Data.SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@NetTurnOver", txtNetWorth.Text.Trim()); }

                    if (Ddl_Expansion.SelectedIndex == 0)
                    {
                        command.Parameters.Add("@ExpansionOfLand", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ExpansionOfLand", Ddl_Expansion.SelectedItem.Text.Trim());
                    }
                    if (Drop1.SelectedIndex == 0)
                    {
                        command.Parameters.Add("@ExportOriented", System.Data.SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    else { command.Parameters.AddWithValue("@ExportOriented", Drop1.SelectedItem.Text.Trim()); }




                    transactionResult = (transactionResult && (command.ExecuteNonQuery() > 0));


                    if (transactionResult)
                    {
                        transaction.Commit();

                        string message = "Project Details Submitteed Successfully.Proceed To Upload Neccessary Document";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                    }
                    else
                    {
                        transaction.Rollback();
                        string message = "Error";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                else
                {
                    string message = "Please Fill All Required Values";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                error += "Commit Exception Type: " + ex.GetType();
                error += "  Message: " + ex.Message;
                Response.Write(error);

                try
                { transaction.Rollback(); }

                catch (Exception ex2)
                {
                    error += "Rollback Exception Type:" + ex2.GetType();
                    error += " Message: " + ex2.Message;
                    Response.Write(error);
                }

            }

            finally
            {
                transaction.Dispose();
                con.Close();

            }


        }
        public bool Validate2()
        {
            try
            {
                bool remark = true;


                if (txttypeofindustry.Text.Length <= 0)
                {
                    txttypeofindustry.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txttypeofindustry.Style.Clear();

                }

                if (txtestimatedcost.Text.Length <= 0)
                {
                    txtestimatedcost.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtestimatedcost.Style.Clear();

                }
                if (txtestimatedemployment.Text.Length <= 0)
                {
                    txtestimatedemployment.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtestimatedemployment.Style.Clear();

                }
                if (txtProjectStartMonths.Text.Length <= 0)
                {
                    txtProjectStartMonths.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtProjectStartMonths.Style.Clear();

                }

                if (txtWorkExperience.Text.Length <= 0)
                {
                    txtWorkExperience.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtWorkExperience.Style.Clear();

                }
                if (txtcoveredarea.Text.Length <= 0)
                {
                    txtcoveredarea.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtcoveredarea.Style.Clear();

                }
                if (txtopenarearequired.Text.Length <= 0)
                {
                    txtopenarearequired.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtopenarearequired.Style.Clear();

                }
                if (txtland.Text.Length <= 0)
                {
                    txtland.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtland.Style.Clear();

                }

                if (txtbuilding.Text.Length <= 0)
                {
                    txtbuilding.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtbuilding.Style.Clear();

                }
                if (txtmachinery.Text.Length <= 0)
                {
                    txtmachinery.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtmachinery.Style.Clear();

                }
                if (txtFixedAssets.Text.Length <= 0)
                {
                    txtFixedAssets.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtFixedAssets.Style.Clear();

                }
                if (txtOtherExpenses.Text.Length <= 0)
                {
                    txtOtherExpenses.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtOtherExpenses.Style.Clear();

                }
                if (txtpowerreq.Text.Length <= 0)
                {
                    txtpowerreq.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtpowerreq.Style.Clear();

                }
                if (txtNetWorth.Text.Length <= 0)
                {
                    txtNetWorth.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    txtNetWorth.Style.Clear();

                }
                if (Ddl_Expansion.SelectedIndex == 0)
                {
                    Ddl_Expansion.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    Ddl_Expansion.Style.Clear();

                }
                if (Drop1.SelectedIndex == 0)
                {
                    Drop1.Style["border-color"] = "red";
                    remark = false;
                }
                else
                {
                    Drop1.Style.Clear();

                }
                if (remark == false)
                {


                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetControl();
            //string message = "1234";
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowMessage('" + message + "');", true);

        }
        private void ResetControl()
        {

            ddlArea.SelectedIndex = 0;

            txtPlotNo.Text = "";

            txtCompanyname.Text = "";
            ddlcompanytype.SelectedIndex = 0;
            txtAuthorisedSignatory.Text = "";
            txtSignatoryAddress.Text = "";
            txtSignatoryEmail.Text = "";
            txtSignatoryPhone.Text = "";
            txtIndividualName.Text = "";
            txtIndividualAddress.Text = "";
            txtIndividualPhone.Text = "";
            txtIndividualEmail.Text = "";

            txtPanNo.Text = "";
            txtCinNo.Text = "";
            tr2.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            tr9.Visible = false;

            DataTable dt = (DataTable)ViewState["temp_trustee_details"];
            dt.Rows.Clear();
            ViewState["temp_trustee_details"] = dt;
            temp_trustee_details_DataBind();

            DataTable dt1 = (DataTable)ViewState["temp_shareholder_details"];
            dt1.Rows.Clear();
            ViewState["temp_shareholder_details"] = dt1;
            temp_shareholder_details_DataBind();

            DataTable dt2 = (DataTable)ViewState["temp_directors_details"];
            dt2.Rows.Clear();
            ViewState["temp_directors_details"] = dt2;
            temp_director_details_DataBind();

            DataTable dt3 = (DataTable)ViewState["temp_partnership_details"];
            dt3.Rows.Clear();
            ViewState["temp_partnership_details"] = dt3;
            temp_partnership_details_DataBind();

        }

        public void Readonly()
        {
            txtProposedTransfereeName.Enabled = false;
            txtProposedTransfereeAddress.Enabled = false;
            txtTransfereeTelNo.Enabled = false;
            txtTransfereeEmail.Enabled = false;
            txtTransfereePan.Enabled = false;
            txtReasonofTransfer.Enabled = false;
            ddlArea.Enabled = false;
            txtPlotNo.Enabled = false;
            ddlcompanytype.Enabled = false;
            txtCompanyname.Enabled = false;
            txtPanNo.Enabled = false;
            txtCinNo.Enabled = false;
            txtIndividualName.Enabled = false;
            txtIndividualAddress.Enabled = false;
            txtIndividualPhone.Enabled = false;
            txtIndividualEmail.Enabled = false;
            txtAuthorisedSignatory.Enabled = false;
            txtSignatoryPhone.Enabled = false;
            txtSignatoryEmail.Enabled = false;
            txtSignatoryAddress.Enabled = false;
            gridshareholder.ShowFooter = false;
            PartnershipFirmGrid.ShowFooter = false;
            Trustee_details_grid.ShowFooter = false;
            DirectorsGrid.ShowFooter = false;
            gridshareholder.Columns[6].Visible = false;
            DirectorsGrid.Columns[6].Visible = false;
            Trustee_details_grid.Columns[5].Visible = false;
            PartnershipFirmGrid.Columns[6].Visible = false;
            txttypeofindustry.Enabled = false;
            txtestimatedcost.Enabled = false;
            txtestimatedemployment.Enabled = false;
            txtProjectStartMonths.Enabled = false;
            txtWorkExperience.Enabled = false;
            txtcoveredarea.Enabled = false;
            txtopenarearequired.Enabled = false;
            txtland.Enabled = false;
            txtbuilding.Enabled = false;
            txtmachinery.Enabled = false;
            txtFixedAssets.Enabled = false;
            txtOtherExpenses.Enabled = false;
            txtfumenature.Enabled = false;
            txtfumeqty.Enabled = false;
            txteffluentsolidqty.Enabled = false;
            txteffluentsolidcomposition.Enabled = false;
            txteffluentliquidqty.Enabled = false;
            txteffluentliquidcomposition.Enabled = false;
            txteffluentgaseousqty.Enabled = false;
            txteffluentgaseouscomposition.Enabled = false;
            txtpowerreq.Enabled = false;
            txttelephonefirstyearreq1.Enabled = false;
            txttelephonefirstyearreq2.Enabled = false;

            txttelephoneUltimateyearreq1.Enabled = false;
            txttelephoneUltimateyearreq2.Enabled = false;
            txtNetWorth.Enabled = false;
            Ddl_Expansion.Enabled = false;
            Drop1.Enabled = false;
            txtapplicantpriorityspecification.Enabled = false;














        }

        #endregion

    }
}