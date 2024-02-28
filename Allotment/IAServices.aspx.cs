using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace Allotment
{
    public partial class IAServices : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;

        public string ServiceReqNo;
        #endregion

        int reqid = 0;
        string s = "";
        string rt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
            }
            //if(Request.QueryString["ViewID"].ToString()!="")
            //{ 
            ServiceReqNo = Request.QueryString["ViewID"];
            //}
            Session["ServiceReqNo"] = ServiceReqNo;
            s = Request.QueryString["reqid"] as string;
            if (!IsPostBack)
            {
                if (s == null)
                {
                    bindIndustrialAreaDetail();
                }
                //else
                //{
                //    divfamilyinfo.Visible = true;
                //}

            }

            if (ServiceReqNo != null)
            {
                if (ServiceReqNo.Length > 0)
                {
                    divSearch.Visible = false;

                }

            }
            else
            {
              //  divSearch.Visible = true;
              if(s==null)
                {
                    divSearch.Visible = true;
                }
              else
                {
                    divfamilyinfo.Visible = true;
                }
            }
            try
            {
                if(Request.QueryString.ToString().Length > 0)
                {
                    

                    if (s != null)
                    {
                        reqid = 1030;
                    }
                    else
                    {
                        reqid = 0;
                    }
                }

                for (int i = 0; i < chkinfo.Items.Count; i++)
                {
                    chkinfo.Items[i].Attributes.Add("onclick", "MutExChkList(this)");
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void bindIndustrialAreaDetail()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            objServiceTimelinesBEL.UserName = "Admin1";
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetIndustrialAreaDetailSelected(objServiceTimelinesBEL);
                drpIndusrialArea.DataSource = ds;
                drpIndusrialArea.DataTextField = "IAName";
                drpIndusrialArea.DataValueField = "Id";
                drpIndusrialArea.DataBind();
                drpIndusrialArea.Items.Insert(0, new ListItem("--Select--", "0"));
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




        protected void txtServiceReqNo_TextChanged(object sender, EventArgs e)
        {

        }


        protected void radioByPlotNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = true;
            DivFilterLetter.Visible = false;

        }

        protected void radioByAllotmentNo_CheckedChanged(object sender, EventArgs e)
        {
            DivFilterIA.Visible = false;
            DivFilterLetter.Visible = true;
        }
        string SubdivionId = string.Empty;
        int AllottteID = 0;
        protected void drpIndusrialArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string authors = ServiceReqNo;
            //string[] authorsList = authors.Split('/');
            //foreach (string author in authorsList)
            //{
            //    subdivisionid = Convert.ToInt32(authorsList[1]);
            //}
            ////  LID20220506/3001/2/20071  SER20220505/1030/23837/21345
            //if(subdivisionid==1030)
            //{                
            //}
            //string ServiceReqNo = "";
            //if (Request.QueryString["ViewID"].ToString() != "")
            //{
            //    ServiceReqNo = Request.QueryString["ViewID"];
            //}
            
           
            
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpIndusrialArea.SelectedValue.Trim());
            objServiceTimelinesBEL.subdivision_serviceid = reqid;
            if (reqid == 1030)
            {
                objServiceTimelinesBEL.subdivision_TypeOfApplication = ViewState["relationtype"].ToString(); 
            }
            else
            {
                objServiceTimelinesBEL.subdivision_TypeOfApplication = rt;
            }
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForIAServices(objServiceTimelinesBEL);
                drpPlotNo.DataSource = ds;
                drpPlotNo.DataTextField = "PlotNumber";
                drpPlotNo.DataValueField = "PlotNumber";
                drpPlotNo.DataBind();
                drpPlotNo.Items.Insert(0, new ListItem("--Select--", ""));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        bool checkalreadyappliedornot = false;
        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();
            PreviousServices();
            if (s=="1030")
            {
                ddlServices.SelectedIndex = 4;
                ddlServices.Enabled = false;
                if(checkalreadyappliedornot==true)
                {
                    //btnRaise.Enabled = false;
                    btnRaise.Enabled = true;
                }
                
                
            }
            

        }
        string aloteeReq = string.Empty;

        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {
                if (radioByAllotmentNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = txtServiceReqNo.Text;
                    objServiceTimelinesBEL.IAName = "";
                    objServiceTimelinesBEL.PlotNo = "";

                }

                if (radioByPlotNo.Checked)
                {
                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
                }

                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindForLeaseDeed(objServiceTimelinesBEL);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    AllotteeDiv.Visible = true;
                    lblAllotmentLetterNo.Text = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    string GSTNo = dt.Rows[0]["GSTNo"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    if (GSTNo.Length > 0)
                    {
                        GSTDiv.Visible = false;
                    }
                    else
                    {
                        GSTDiv.Visible = true;
                    }
                    aloteeReq= dt.Rows[0]["ServiceRefNo"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ServiceRefNo"].ToString()))
                    {
                        string[] SerArray = dt.Rows[0]["ServiceRefNo"].ToString().Split('/');
                        int Service = int.Parse(SerArray[1]);
                        if (Service == 1029)
                        {
                            ddlServices.SelectedIndex = 3;
                            ddlServices.Enabled = false;
                        }
                        
                        else if(Service==1030)
                        {
                            ddlServices.SelectedIndex = 4;
                            ddlServices.Enabled = false;
                        }
                    }
                }
                else
                {
                    AllotteeDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        private void PreviousServices()
        {
            SqlCommand cmd = new SqlCommand("GetPreviouslyAppliedServices '" + txtServiceReqNo.Text.Trim() + "','" + drpIndusrialArea.SelectedItem.Text.Trim() + "','" + drpPlotNo.SelectedValue.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                checkalreadyappliedornot = true;
                PreviousServiceGrid.DataSource = dt;
                PreviousServiceGrid.DataBind();
                PreviousServiceDiv.Visible = true;
            }
            else
            {
                checkalreadyappliedornot = false;
                PreviousServiceGrid.DataSource = null;
                PreviousServiceGrid.DataBind();
                PreviousServiceDiv.Visible = false;
            }
        }
       
        protected void btnRaise_Click(object sender, EventArgs e)
        {
            string Contact = "";
            string Email = "";

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

            if (ddlServices.SelectedValue.Trim() == "1002")
            {

                objServiceTimelinesBEL.IAId = Convert.ToInt32(lblIAID.Text.Trim());
                DataSet ds = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                DataSet ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Contact = ds1.Tables[0].Rows[0]["OfficePhoneNo"].ToString();
                        Email = ds1.Tables[0].Rows[0]["OfficeEMAILID"].ToString();
                    }

                }
                if (ds.Tables.Count > 0)
                {


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        string msg = "Please Note: The Current Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDA Administrator On Below Mentioned Details :- Phone No : " + Contact + " EmailId : " + Email;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }

                }
                else
                {
                    string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDA Administrator On Below Mentioned Details :- Phone No : " + Contact + " EmailId : " + Email;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }

            }

            if (ddlServices.SelectedValue.Trim() == "1030")
            {
                // string authors = aloteeReq;
                try
                {
                    if (!string.IsNullOrEmpty(aloteeReq))
                    { 
                        string[] authorsList = aloteeReq.Split('/');
                    foreach (string author in authorsList)
                    {
                        AllottteID = Convert.ToInt32(authorsList[2]);
                    }
                }

                }
                catch (Exception ex)
                {

                }
                //SER20220504/1030/5473/21341
                //  LID20220506/3001/2/20071  SER20220505/1030/23837/21345   SER20220510/1030/18779/21357



            }



            objServiceTimelinesBEL.IndustrialArea = lblIAID.Text;
            objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(ddlServices.SelectedValue.Trim());
            objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
            objServiceTimelinesBEL.GSTNo = txtGstNo.Text;
            

            try
            {
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.SetServiceRequestIAServiceInHouse(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string RefNo = ds.Tables[0].Rows[0][0].ToString().Trim();

                        string[] SerArray = RefNo.Split('/');
                        int Service = int.Parse(SerArray[1]);
                        if (Service == 1003 || Service == 1004 || Service == 1009 || Service == 1010 || Service == 1029)
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                            var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + RefNo + "';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                        else if(Service==1030)
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                            var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + RefNo + "&rtype=" + ViewState["relationtype"].ToString() + "';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                        else
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                            var script = string.Format("alert({0});window.location ='IAServicesApplication_Module.aspx?ServiceReqNo=" + RefNo + "';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
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
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-b :" + ex.Message.ToString());
            }
        }

        protected void PreviousServiceGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                if (e.CommandName == "Select")
                {

                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    string ServiceID = PreviousServiceGrid.DataKeys[rowIndex].Values[0].ToString();
                    string[] SerArray = ServiceID.Split('/');
                    int Service = int.Parse(SerArray[1]);
                    if (Service == 1003 || Service == 1004 || Service == 1009 || Service == 1010 || Service == 1029 )
                    {
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Redirecting to application page");
                        var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + ServiceID + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    else if (Service == 1030)
                    {
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Redirecting to application page");
                        var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + ServiceID + "&rtype=" + ViewState["relationtype"].ToString() + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    else
                    {
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Redirecting to application page");
                        var script = string.Format("alert({0});window.location ='IAServicesApplication_Module.aspx?ServiceReqNo=" + ServiceID + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        string relationtype = string.Empty;
        protected void drpPlotNo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Response.Write("<script>alert('HI');</script>");
            bindIndustrialAreaDetail();
            if (chkinfo.SelectedIndex==0)
            {
                divSearch.Visible = true;
                relationtype = "Family";
                ViewState["relationtype"] = relationtype;
                partnerinfo.Visible = false;


            }
          else if(chkinfo.SelectedIndex==1)
            {
                partnerinfo.Visible = true;
                relationtype = "Partners";
                ViewState["relationtype"] = relationtype;
                divSearch.Visible = true;

            }
          else if(chkinfo.SelectedIndex == 2)
            {
                relationtype = "Mega";
                ViewState["relationtype"] = relationtype;
                divSearch.Visible = true;
                partnerinfo.Visible = false;
            }
            else if (chkinfo.SelectedIndex == 3)
            {
                relationtype = "Other";
                ViewState["relationtype"] = relationtype;
                divSearch.Visible = true;
                partnerinfo.Visible = false;
            }
          else
            {
                relationtype = "";
                ViewState["relationtype"] = relationtype;
                divSearch.Visible = false;
                partnerinfo.Visible = false;
            }


        }

        protected void drpIndusrialArea1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtServiceReqNo1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}