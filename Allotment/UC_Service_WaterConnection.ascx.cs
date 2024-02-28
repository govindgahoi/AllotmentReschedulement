using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class UC_Service_WaterConnection : System.Web.UI.UserControl
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


        public string SerReqID { get; set; }
        public string SerID_in { get; set; }
        public string AllottementLetterNo { get; set; }
        public string UserBy { get; set; }


        public void Page_Load(object sender, EventArgs e)
        {

            // int userid = 0;
            //string SerReqID_in = Request.QueryString["serviceId"];
            //string SerID_in = Request.QueryString["id"];

            //string SerReqID = HttpUtility.HtmlDecode(SerReqID_in);

            if (string.IsNullOrEmpty(SerReqID))
            {
                lblserRequest.Text = SerID_in;
                MultiViewBuildingPlan.ActiveViewIndex = 0;
            }
            else
            {
                if (MultiViewBuildingPlan.ActiveViewIndex < 1)
                {
                    MultiViewBuildingPlan.ActiveViewIndex = 1;
                }
                lblserRequest.Text = SerReqID;
            }




            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

            string info = _objLoginInfo.userName;
            string cat = _objLoginInfo.Roll;
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

            //int userid = _objLoginInfo.userid;

            if (!IsPostBack)
            {

                if (MultiViewBuildingPlan.ActiveViewIndex > 0)
                {
                    GetServiceRequestBPDetail(lblserRequest.Text);
                }
                else
                {

                    GetAllotteeRecordComplete(info, cat);

                }
                BindApplicationType();
                BindServiceCheckListGridView();
                //BindRegionalOffice();
                disabledcontrols();
                //Temprorary work






                ListItemCollection collection = new ListItemCollection();


                if (lblserRequest.Text.Trim() == "3")
                {
                    collection.Add(new ListItem("Errect Water Connection"));
                    collection.Add(new ListItem("Re Errect Water Connection"));
                    collection.Add(new ListItem("Alteration and Modification"));
                }
                else
                {
                    collection.Add(new ListItem("Errect New Building"));
                    collection.Add(new ListItem("Re Errect Building"));
                    collection.Add(new ListItem("Alteration and Modification"));
                }



                //Pass ListItemCollection as datasource
                ddlCaseType.DataSource = collection;
                ddlCaseType.DataBind();

            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 1;
        }
        protected void Next1_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 2;
            BindServiceCheckListGridView();
            GetServiceRequestBPDetail(lblserRequest.Text);

        }
        protected void Next2_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 3;
            GetServiceRequestBPDetail(lblserRequest.Text);

        }
        protected void Next3_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 4;
            GetServiceRequestBPDetail(lblserRequest.Text);

        }

        protected void Previous1_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 0;
        }
        protected void Previous2_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 1;
        }
        protected void Previous3_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 2;
        }
        protected void Previous4_Click(object sender, EventArgs e)
        {
            MultiViewBuildingPlan.ActiveViewIndex = 3;
        }
        #region BindServiceCheckList
        public void BindServiceCheckListGridView()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



            // string SerReqID = Request.QueryString["id"];

            string[] SerIdarray = lblserRequest.Text.Split('/');



            objServiceTimelinesBEL.ServiceChecklistId = SerIdarray[1];
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetServiceChecklists(objServiceTimelinesBEL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    GridViewService.DataSource = ds;
                    GridViewService.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    GridViewService.DataSource = null;
                    GridViewService.DataBind();
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
        #endregion
        #region UploadCheckList Process

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];

            objServiceTimelinesBEL.UserName = AllottementLetterNo;
            int Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
            int Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());





            if (e.CommandName == "Upload")
            {
                LinkButton bts = e.CommandSource as LinkButton;
                // Response.Write(bts.Parent.Parent.GetType().ToString());
                FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                // Button bts = e.CommandSource.;
                // GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //  int index = gvr.RowIndex;
                //int index = Convert.ToInt32(e.CommandArgument.ToString());
                //  Response.Write(bts.Parent.Parent.GetType().ToString());

                //FileUpload fu = row.FindControl("FileUpload4") as FileUpload;//here 
                if (fu.HasFile)
                {
                    string filePath = fu.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(fu.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;
                    switch (fleUpload)
                    {
                        case ".doc":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".docx":
                            contenttype = "application/vnd.ms-word";
                            break;
                        case ".xls":
                            contenttype = "application/vnd.ms-excel";
                            break;
                        case ".xlsx":
                            contenttype = "application/vnd.ms-excel";
                            break;
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
                        Stream fs = fu.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                        objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                        objServiceTimelinesBEL.filename = filename;
                        objServiceTimelinesBEL.content = contenttype;
                        objServiceTimelinesBEL.Uploadfile = bytes;
                        objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                        objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                        try
                        {
                            if (btnSubmit.Text == "Save")
                            {
                                int retVal = objServiceTimelinesBLL.SaveServiceChecklistDocument(objServiceTimelinesBEL);
                                if (retVal > 0)
                                {
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }
                                else
                                {
                                    string message = "File couldn't be  uploaded ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                                }
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
                    else
                    {
                        string message = "File format not recognised." +
                          " Upload Image/Word/PDF/Excel formats";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
            }
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc1 = ds.Tables[0];

                    if (dtDoc1.Rows.Count > 0)
                    {
                        download(dtDoc1);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
            }
            if (e.CommandName == "Delete")
            {
                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeleteCheckListDocument(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "Checklist Document deleted successfully ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                    else
                    {
                        string message = "Checklist Document couldn't be deleted";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            try
            {
                DataSet ds1 = new DataSet();
                objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                ds1 = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                DataTable dtDoc = ds1.Tables[0];
                if (dtDoc.Rows.Count > 0)
                {
                    GridView2.Rows[index].FindControl("lbView").Visible = true;
                    GridView2.Rows[index].FindControl("lbDelete").Visible = true;
                }
                else
                {
                    GridView2.Rows[index].FindControl("lbView").Visible = false;
                    GridView2.Rows[index].FindControl("lbDelete").Visible = false;
                }
            }
            catch { }

            BindServiceCheckListGridView();

        }

        protected void GridViewService_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[Convert.ToInt32(e.CommandArgument)];

            objServiceTimelinesBEL.UserName = AllottementLetterNo;
            int Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
            int Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());
            if (e.CommandName == "selectDocument")
            {

                DataSet ds = new DataSet();
                try
                {
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    ds = objServiceTimelinesBLL.GetCheckListDocument(objServiceTimelinesBEL);
                    DataTable dtDoc = ds.Tables[0];
                    if (dtDoc != null)
                    {
                        download(dtDoc);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
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



        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            //this.BindServiceCheckListGridView();

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        #endregion

        public void disabledcontrols()
        {

        }


        #region "Save Service Request Record"
        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            objServiceTimelinesBEL.UserName = AllottementLetterNo;
            objServiceTimelinesBEL.ApplicationType = ddlApplication.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.CaseType = ddlCaseType.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.IndustrialArea = lblArea.Text;
            objServiceTimelinesBEL.ServiceRequest = String.Empty;
            objServiceTimelinesBEL.Remarks = String.Empty;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(lblserRequest.Text.Trim());
            objServiceTimelinesBEL.CreatedBy = UserBy;
            objServiceTimelinesBEL.CreatedDate = System.DateTime.Now;
            try
            {
                DataSet ds = new DataSet();
                if (btnSubmit.Text == "Save")
                {
                    ds = objServiceTimelinesBLL.SetServiceRequest(objServiceTimelinesBEL);
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

                            Response.Redirect("WaterConnection.aspx?ServiceID=" + lblServiceRequestID.Text.Trim(), false);

                        }
                    }
                    else
                    {
                        string message = "Record couldn't be  Save ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
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



        protected void btnSubmmited_Click(object sender, EventArgs e)
        {


            try
            {
                if (btnSubmit.Text == "Save")
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;

                    int retVal = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "Record Submited SucessFully ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                        btnSave.Enabled = false;
                        Response.Redirect("ServiceRequestSubmitted.aspx");

                    }
                    else
                    {
                        string message = "Record couldn't be  Submited ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
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
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            string info = _objLoginInfo.userName;
            string cat = _objLoginInfo.Roll;
            objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;
            objServiceTimelinesBEL.Far = float.Parse(txtFar.Text);
            objServiceTimelinesBEL.Groundcover = float.Parse(txtGroundcover.Text);
            objServiceTimelinesBEL.SetBackFront = float.Parse(txtSetBackFront.Text);
            objServiceTimelinesBEL.SetBackRear = float.Parse(txtSetBackRear.Text);
            objServiceTimelinesBEL.SetBackSide1 = float.Parse(txtSetBackSide1.Text);
            objServiceTimelinesBEL.SetBackSide2 = float.Parse(txtSetBackSide2.Text);
            objServiceTimelinesBEL.Height = float.Parse(txtHeight.Text);
            objServiceTimelinesBEL.Occupancy = float.Parse(txtOccupancy.Text);

            objServiceTimelinesBEL.NatureofOccupancy = ddlNature.SelectedItem.Text.Trim();
            objServiceTimelinesBEL.ModifiedBy = info;
            objServiceTimelinesBEL.ModifiedDate = System.DateTime.Now;
            try
            {
                if (btnSubmit.Text == "Save")
                {
                    int retVal = objServiceTimelinesBLL.SaveFARDetail(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "Record Save SucessFully ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                        GetServiceRequestBPDetail(lblserRequest.Text);

                    }
                    else
                    {
                        string message = "Record couldn't be  Save ";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

            try
            {
                if (btnSubmit.Text == "Save")
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    objServiceTimelinesBEL.ServiceRequest = lblserRequest.Text;

                    int retVal = objServiceTimelinesBLL.SetServiceRequestFinish(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {


                    }
                    else
                    {

                    }
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
        #endregion

        public void GetAllotteeRecordComplete(string username, string category)
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
                        txtLeaseDeed.Text = ds.Tables[0].Rows[0]["LeaseDeedDate"].ToString();

                        if (string.IsNullOrWhiteSpace(this.txtLeaseDeed.Text))
                        {
                            lableMessage.Visible = true;
                        }

                    }
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




        public void GetServiceRequestBPDetail(string servicereqid)
        {
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
                    try
                    {
                        ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfOccupancy"].ToString().Trim();
                    }
                    catch { }




                    //lblArea.Text = objServiceTimelinesBEL.IndustrialArea;
                    //    DataSet dsExecutive = new DataSet();
                    //    dsExecutive = objServiceTimelinesBLL.GetExecutiveauthority(objServiceTimelinesBEL);
                    //    lblEmail.Text = dsExecutive.Tables[0].Rows[0][0].ToString();
                    //    lblAuthority.Text = dsExecutive.Tables[0].Rows[0][1].ToString();
                    //    lblPhoneNumber.Text = dsExecutive.Tables[0].Rows[0][2].ToString();


                    //    if (string.IsNullOrWhiteSpace(this.txtLeaseDeed.Text))
                    //    {
                    //        lableMessage.Visible = true;
                    //    }

                    //BindServiceCheckListGridView();
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
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
                    //BindServiceCheckListGridView();
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
                string SerID_in = Request.QueryString["id"];
                if (SerID_in == "3")
                {
                    dsApplication = objServiceTimelinesBLL.GetApplicationType("Application for Water Connection");

                }
                else
                {
                    dsApplication = objServiceTimelinesBLL.GetApplicationType("");
                }

                dsApplication.Tables[0].DefaultView.ToTable(true, "ApplicationName");
                ddlApplication.DataSource = dsApplication;
                ddlApplication.DataTextField = "ApplicationName";
                ddlApplication.DataValueField = "ApplicationID";
                ddlApplication.DataBind();
                ddlApplication.Items.Insert(0, new ListItem("--Select--", "0"));
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
                        e.Row.FindControl("lbDelete").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lbView").Visible = false;
                        e.Row.FindControl("lbDelete").Visible = false;
                    }
                }
            }
            catch
            {

            }

        }
        protected void Save_ServerClick(object sender, EventArgs e)
        {
            string message = "Do you want to Submit?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("return confirm('");
            sb.Append(message);
            sb.Append("');");
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            btnSubmmited_Click(null, null);

        }
    }
}