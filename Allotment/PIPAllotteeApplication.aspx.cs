using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
    public partial class PIPAllotteeApplication : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

        String ServiceReqNo = "";
        String TraID = "";

        string ControlID = "";
        string Request_ID = "";
        string UnitID = "";
        string ServiceID = "";
        string NM_DistrictID = "";
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
        string Objection_Rejection_Code = "";
        string Is_Certificate_Valid_Life_Time = "";
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "";
        string D2 = "";
        string D3 = "";
        string D4 = "";
        string D5 = "";
        string D6 = "";
        string D7 = "";

        public string ViewID;
        public string App = "";
        SqlConnection con;

        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Enctype = "multipart/form-data";
            UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = new UC_Service_Allotteee_Detail();
            UC_Service_Building_Plan UC_Service_Building_Plan = new UC_Service_Building_Plan();
         
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            }
            catch
            {

            }
            try
            {

                ServiceReqNo = Request.QueryString["ServiceID"];
                TraID = Request.QueryString["TraID"];
                ViewID = Request.QueryString["ViewID"];
                App = Request.QueryString["App"];
                lblReqV.Text = App;
                if (Request.Form["TxtControlID"] != null)
                {
                    ViewState["ControlID"] = Request.Form["TxtControlID"];
                    ViewState["UnitID"] = Request.Form["TxtUnitID"];
                    ViewState["ServiceID"] = Request.Form["TxtServiceID"];
                    ViewState["ProcessIndustryID"] = Request.Form["TxtProcessIndustryID"];
                    ViewState["ApplicationID"] = Request.Form["TxtApplicationID"];
                    ViewState["Request_ID"] = Request.Form["TxtRequestID"];
                    ViewState["Allotmentletterno"] = "";
                   // lblReqV.Text= Request.Form["TxtRequestID"]; 
                }

                if (ViewState["ControlID"] != null)
                {
                    ControlID = ViewState["ControlID"].ToString().Trim();
                    UnitID = ViewState["UnitID"].ToString().Trim();
                    ServiceID = ViewState["ServiceID"].ToString().Trim();
                    ProcessIndustryID = ViewState["ProcessIndustryID"].ToString().Trim();
                    ApplicationID = ViewState["ApplicationID"].ToString().Trim();
                    Request_ID = ViewState["Request_ID"].ToString().Trim();
                    //  lblReqV.Text = Request_ID;
                }

                //Response.Redirect("" + ControlID + "," + UnitID + "," + ServiceID + "");
                if (!string.IsNullOrEmpty(ViewID))
                {
                    
                    BLPUpdate(ViewID);
                    BindBPDetails();
                    Allotment.ActiveViewIndex = 7;
                    return;
                }
                if (!IsPostBack)
                {
                    //ControlID = "UPSWP202024827";
                    //UnitID = "UPSWP20202482702";
                    //ServiceID = "SC21003";
                    //Request_ID = "20202482702210030002";

                    BindIADistictWise();

                //ControlID = "UPSWP202024827";
                //UnitID = "UPSWP20202482702";
                //ServiceID = "SC21003";
                //Request_ID = "20202482702210030002";

                    try
                    {

                        //-----------------------------------Building--Plan---------------------------------------------------------------------------
                        if (ServiceID == "SC21002" || ServiceID == "SC21003")
                        {
                            SqlCommand cmd = new SqlCommand("select *  from tbl_NMSWP_RejectionTrack where ControlId='" + ControlID + "' and UnitId='" + UnitID + "' and ServiceID='" + ServiceID + "' and IsRejected=1 and RequestID='" + Request_ID + "'", con);
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt1 = new DataTable();
                            adp.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Application has been rejected.Kindly re-apply using resubmission service of niveshmitra');", true);
                                return;
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert(" + ex.ToString() + ");", true);
                        return;
                    }

                }

                if (ServiceID == "SC21002")
                {
                    NiveshMitra();
                    PageHeadingLbl.Text = "Application For Building Plan";

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select B.ServiceRequestNO,B.Status,IsNull(A.BPFeePaid,'False') 'BPFeePaid',BuildingTraID,isnull(B.IsClarificationReq,0) 'BuildingPlanObjection',isnull(B.IsRejected,0) 'IsRejected',DATEDIFF(DAY,B.CreatedDate,GETDATE()) 'YearsCheck',B.CreatedDate  from AllotteeMaster A, ServiceRequests B where A.ControlId='" + ControlID + "' and A.UnitId='" + UnitID + "' and A.ServiceID='" + ServiceID + "' and A.NMRequestID='" + Request_ID + "' and A.AllotteeID = B.AllotteeID and B.ServiceTimelinesID in (1,2,3) and isnull(B.IsActive,0)=1", con);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        adp.Fill(dt1);

                        if (dt1.Rows.Count > 0)
                        {
                            DateTime ServiceDate = Convert.ToDateTime(dt1.Rows[0]["CreatedDate"].ToString());
                            int Days = Convert.ToInt32(dt1.Rows[0]["YearsCheck"].ToString());
                            string Rej = dt1.Rows[0]["IsRejected"].ToString();
                            string Req = dt1.Rows[0]["ServiceRequestNO"].ToString();
                            string Red = dt1.Rows[0]["Status"].ToString();
                            string FeePAid = dt1.Rows[0]["BPFeePaid"].ToString();
                            string TraID = dt1.Rows[0]["BuildingTraID"].ToString();
                            string Objection = dt1.Rows[0]["BuildingPlanObjection"].ToString();


                            if (Days > 365)
                            {
                                if (Red == "True" || Objection == "True")
                                {
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The one year time period from the date of first application is over.You are requested to re apply through a new application.');", true);

                                    return;
                                }
                                else
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }
                            }
                            else
                            {
                                if (Rej == "True")
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }

                                if (Objection == "True")
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }
                                if (Red == "True")
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }
                                else
                                {

                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;


                                }

                            }
                           
                        }
                        else
                        {
                            if (Allotment.ActiveViewIndex == 3)
                            {

                                ExistingAllottee();
                            }
                            else
                            {
                                GeneralMethod gm = new GeneralMethod();

                                if (gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows.Count > 0)
                                {
                                    string Plot = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["PlotNo"].ToString();
                                    string Letter = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["AllotmentletterNo"].ToString();
                                    string regionalofice = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["RegionalOffice"].ToString();
                                    string IAID = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["INDUID"].ToString();
                                    txtPlotNo.Text = Plot;
                                    txtLetterNo.Text = Letter;
                                }
                                Allotment.ActiveViewIndex = 5;
                            }
                        }


                    }


                    catch (Exception ex) { }
                    finally { con.Close(); }

                }
                else if (ServiceID == "SC21003")
                {
                    SqlCommand cmd = new SqlCommand("select B.ServiceRequestNO,B.Status,IsNull(A.BPFeePaid,'False') 'BPFeePaid',BuildingTraID,isnull(B.IsClarificationReq,0) 'BuildingPlanObjection',isnull(B.IsRejected,0) 'IsRejected',DATEDIFF(DAY,B.CreatedDate,GETDATE()) 'YearsCheck'  from AllotteeMaster A, ServiceRequests B where A.ControlId='" + ControlID + "' and A.UnitId='" + UnitID + "' and A.ServiceID='" + ServiceID + "' and A.NMRequestID='" + Request_ID + "' and A.AllotteeID = B.AllotteeID and B.ServiceTimelinesID in (1,2,3) and isnull(B.IsActive,0)=1", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        int Days = Convert.ToInt32(dt1.Rows[0]["YearsCheck"].ToString());
                        string Rej = dt1.Rows[0]["IsRejected"].ToString();
                        string Req = dt1.Rows[0]["ServiceRequestNO"].ToString();
                        string Red = dt1.Rows[0]["Status"].ToString();
                        string FeePAid = dt1.Rows[0]["BPFeePaid"].ToString();
                        string TraID = dt1.Rows[0]["BuildingTraID"].ToString();
                        string Objection = dt1.Rows[0]["BuildingPlanObjection"].ToString();


                        if (Days > 365)
                        {
                            if (Red == "True" || Objection == "True")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The one year time period from the date of first application is over.You are requested to re apply through a new application.');", true);

                                return;
                            }
                            else
                            {
                                Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                return;
                            }
                        }
                        else
                        {

                            if (Rej == "True")
                            {
                                Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                return;
                            }

                            if (Objection == "True")
                            {
                                Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                return;
                            }
                            if (Red == "True")
                            {
                                Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                return;
                            }
                            else
                            {
                                if (FeePAid == "False")
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }
                                else
                                {
                                    Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + Req.Trim(), false);
                                    return;
                                }

                            }
                        }
                    }
                    else
                    {
                        PageHeadingLbl.Text = "Re Application For Building Plan Approval";
                        Allotment.ActiveViewIndex = 8;
                    }

                }
                else if (ServiceID == "SC21012")
                {
                    PageHeadingLbl.Text = "Application For Addition of Product";
                    lblServiceName.Text = "Addition of Product";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }






                }
                else if (ServiceID == "SC21013")
                {
                    PageHeadingLbl.Text = "Application For Change of Project";
                    lblServiceName.Text = "Change of Project";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();

                        Response.Redirect(string.Format("~/IAServicesApplication.aspx?ServiceReqNo={0}", ServiceReqNo));

                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }





                }
                else if (ServiceID == "SC21014")
                {
                    PageHeadingLbl.Text = "Application For Execution and Registration of Lease Deed";
                    lblServiceName.Text = "Execution and Registration Of Lease Deed";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/LeaseDeedApplication.aspx?ViewID={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }





                }
                else if (ServiceID == "SC21022")
                {
                    PageHeadingLbl.Text = "Online Payment of Reservation Money";
                    lblServiceName.Text = "Online Payment of Reservation Money";

                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/AllotteeReservationMoneyPayNMSWP.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }
                else if (ServiceID == "SC21025")
                {
                    PageHeadingLbl.Text = "Online Request for transfer of plot";
                    lblServiceName.Text = "Online Request for transfer of plot";

                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IATransferOfPlotApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }
                else if (ServiceID == "SC21029")
                {
                    PageHeadingLbl.Text = "Application For No Dues Certificate";
                    lblServiceName.Text = "No Dues Certificate";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }


                }
                else if (ServiceID == "SC21028")
                {
                    PageHeadingLbl.Text = "Request for oustanding dues position";
                    lblServiceName.Text = "Request for oustanding dues position";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }





                }
                else if (ServiceID == "SC21027")
                {
                    PageHeadingLbl.Text = "Online Payment Of Oustanding Dues";
                    lblServiceName.Text = "Online Payment Of Oustanding Dues";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IACurrentDues.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }





                }

                #region  ManishShuklaCode
                else if (ServiceID == "SC21015")
                {
                    PageHeadingLbl.Text = "Request for time extension for setting up of Project";
                    lblServiceName.Text = "time extension for setting up of Project";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21016")
                {
                    PageHeadingLbl.Text = "Request for Noc for permission to mortgage in favour of Financial Institution";
                    lblServiceName.Text = "Noc for permission to mortgage in favour of Financial Institution";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21017")
                {
                    PageHeadingLbl.Text = "Request For Permission For Creation Of Second Charge";
                    lblServiceName.Text = "Noc for Permission For Creation Of Second Charge";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21018")
                {
                    PageHeadingLbl.Text = "Request for permission for joint mortgage";
                    lblServiceName.Text = "permission for joint mortgage";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21019")
                {
                    PageHeadingLbl.Text = "Request for transfer of lease deed to financial institution";
                    lblServiceName.Text = "transfer of lease deed to financial institution";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21020")
                {
                    PageHeadingLbl.Text = "Request for issuance of certificate for start of production";
                    lblServiceName.Text = "issuance of certificate for start of production";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21021")
                {
                    PageHeadingLbl.Text = "Request for restoration of plot after cancelation";
                    lblServiceName.Text = "restoration of plot after cancelation";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module1.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21026")
                {
                    PageHeadingLbl.Text = "Request for surrender of plot and refund of refundable amount";
                    lblServiceName.Text = "surrender of plot";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module1.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21030")
                {
                    PageHeadingLbl.Text = "Request for establishment of additional unit within same premises use";
                    lblServiceName.Text = "establishment of additional unit within same premises use";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module1.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                else if (ServiceID == "SC21031")
                {
                    PageHeadingLbl.Text = "Request for subletting of Plot";
                    lblServiceName.Text = "subletting of Plot";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication_Module1.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }

                #endregion

                #region Manish Rastogi
                else if (ServiceID == "SC21032")
                {
                    PageHeadingLbl.Text = "Request for Hand over of lease deed to lease";
                    lblServiceName.Text = "Hand over of lease deed to lease";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAReconstitutionApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }
                else if (ServiceID == "SC21024")
                {
                    PageHeadingLbl.Text = "Request for Reconstitution of allotte firm  company";
                    lblServiceName.Text = "Reconstitution of allotte firm  company";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAReconstitutionApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }
                else if (ServiceID == "SC21023")
                {
                    PageHeadingLbl.Text = "Request for Recognition of legal heir after death";
                    lblServiceName.Text = "Recognition of legal heir after death";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAReconstitutionApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }
                #endregion


                else if (ServiceID == "SC21034")
                {
                    PageHeadingLbl.Text = "Request for Amalgamation";
                    lblServiceName.Text = "Request for Amalgamation";
                    SqlCommand cmd = new SqlCommand("sp_GetServiceAgainstNMID '" + ControlID + "','" + UnitID + "','" + ServiceID + "','" + Request_ID + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ServiceReqNo = dt.Rows[0][0].ToString();
                        Response.Redirect(string.Format("~/IAServicesApplication.aspx?ServiceReqNo={0}", ServiceReqNo));
                    }
                    else
                    {
                        if (ControlID.Length > 0)
                        {
                            NiveshMitra();
                        }

                        if (Allotment.ActiveViewIndex <= 0)
                        {
                            if (ControlID.Length > 0)
                            {
                                Allotment.ActiveViewIndex = 0;
                            }
                            else
                            {
                                Allotment.ActiveViewIndex = 1;
                            }
                        }
                        else
                        {

                            Allotment.ActiveViewIndex = 3;

                        }
                    }
                }


                else if (ServiceID.Trim() == "SC21036")
                {
                    PageHeadingLbl.Text = "Application for Issuance of Unique Id for Private Industrial Parks ";
                    lblServiceName.Text = "Application for Issuance of Unique Id for Private Industrial Parks ";

                    if (ControlID.Length > 0)
                    {
                        NiveshMitra();
                        divwarehouse.Visible = true;
                        btnDiv.Visible = false;
                    }
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        if (ControlID.Length > 0)
                        {
                            Allotment.ActiveViewIndex = 0;
                        }
                        else
                        {
                            Allotment.ActiveViewIndex = 1;
                        }
                    }
                    else
                    {

                        Allotment.ActiveViewIndex = 3;

                    }
                }
            

                else
                {
                    PageHeadingLbl.Text = "Application For Land Allottment";

                    if (ServiceReqNo == "" || ServiceReqNo == null)
                    {
                        if (!IsPostBack)
                        {
                            UserSpecificBinding();
                            CheckNMSWPStatus();

                            if (multi.ActiveViewIndex <= 0)
                            {
                                multi.ActiveViewIndex = 0;

                            }

                            if (ControlID.Length > 0)
                            {
                                NiveshMitra();
                            }

                            if (Allotment.ActiveViewIndex <= 0)
                            {
                                if (ControlID.Length > 0)
                                {
                                    Allotment.ActiveViewIndex = 0;
                                }
                                else
                                {
                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            else
                            {

                                Allotment.ActiveViewIndex = 3;

                            }

                        }

                    }
                    else
                    {
                        PageHeadingLbl.Text = "Application For Building Plan";
                        try
                        {
                            string[] SerIdarray = ServiceReqNo.Split('/');
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where  AllotteeID=" + SerIdarray[2] + "   ", con);
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt1 = new DataTable();
                            adp.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                string Allotmentletterno = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                                string RecControlID = dt1.Rows[0]["ControlID"].ToString().Trim();
                                string RecUnitID = dt1.Rows[0]["UnitId"].ToString().Trim();
                                string RecServiceID = dt1.Rows[0]["ServiceID"].ToString().Trim();
                                string RecRequestID = dt1.Rows[0]["NMRequestID"].ToString().Trim();
                                ViewState["Allotmentletterno"] = Allotmentletterno.Trim();
                                Allotment.ActiveViewIndex = 3;
                                PlaceHolder2.Controls.Clear();
                                UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                                UC_Service_Building_Plan.ID = "Service_Building_Plan";

                                UC_Service_Building_Plan.SerReqID = ServiceReqNo;
                                UC_Service_Building_Plan.ControlID = RecControlID;
                                UC_Service_Building_Plan.UnitID = RecUnitID;
                                UC_Service_Building_Plan.ServiceID = RecServiceID;
                                UC_Service_Building_Plan.RequestID = RecRequestID;
                                UC_Service_Building_Plan.SerID_in = "1";
                                UC_Service_Building_Plan.UserBy = ViewState["Allotmentletterno"].ToString().Trim();
                                UC_Service_Building_Plan.page_type = "ENTRY";
                                UC_Service_Building_Plan.AllottementLetterNo = ViewState["Allotmentletterno"].ToString().Trim();
                                UC_Service_Building_Plan.TraID = TraID;
                                UC_Service_Building_Plan.App = App;
                                UC_Service_Building_Plan.Page_Load(null, null);
                                PlaceHolder2.Controls.Add(UC_Service_Building_Plan);

                            }
                            else
                            {

                                if (Allotment.ActiveViewIndex == 3)
                                {
                                    //GeneralMethod gm = new GeneralMethod();

                                    //string Plot = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["PlotNo"].ToString();
                                    //string Letter = gm.GetPlotAndLetterNoUsingControlID(ControlID, UnitID).Rows[0]["AllotmentletterNo"].ToString();

                                    Allotment.ActiveViewIndex = 3;
                                    ExistingAllottee();
                                }
                                else
                                {
                                    Allotment.ActiveViewIndex = 5;
                                }

                            }
                        }

                        catch { }
                        finally { con.Close(); }





                    }
                }


            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Alert('" + ex.ToString() + "');", true);
                return;
            }
        }

        private void BindBPDetails()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("getDetailsOfApplicantBP '" + ViewID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblProcessing.Text = dt.Rows[0]["ProcessingFee"].ToString();
                    lblBPFee.Text = dt.Rows[0]["BPFeePaid"].ToString();
                    lblForm.Text = dt.Rows[0]["Form"].ToString();
                    lblAppDate.Text = dt.Rows[0]["ApplicationDate"].ToString();
                    lblIAName.Text = dt.Rows[0]["IndustrialArea"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        private void bindIA(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drdIA.DataSource = ds;
                drdIA.DataTextField = "IAName";
                drdIA.DataValueField = "Id";
                drdIA.DataBind();
                drdIA.Items.Insert(0, new ListItem("--Select--", "0"));

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




        private void NiveshMitra()
        {

            if (ControlID.Length > 0)
            {
                try
                {

                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet ds = webService.WGetBasicDetails(ControlID, UnitID, ServiceID, "", passsalt);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        lblControlId.Text = ControlID;
                        lblUnitId.Text = UnitID;
                        lblCompanyName.Text = dt.Rows[0]["Company_Name"].ToString();
                        lblIndustryDistrict.Text = dt.Rows[0]["Industry_District"].ToString();
                        lblIndustryAddress.Text = dt.Rows[0]["Industry_Address"].ToString();
                        lblIndustryPincode.Text = dt.Rows[0]["Pin_Code"].ToString();
                        lblOccupierName.Text = dt.Rows[0]["Occupier_Name"].ToString();
                        lblOccupierEmail.Text = dt.Rows[0]["Occupier_Email_ID"].ToString();
                        lblOccupierPhone.Text = dt.Rows[0]["Occupier_Mobile_No"].ToString();
                        lblOccupierPAN.Text = dt.Rows[0]["Occupier_PAN"].ToString();
                        lblOccupierAddress.Text = dt.Rows[0]["Occupier_Address"].ToString();
                        lblOccupierDistrictName.Text = dt.Rows[0]["Occupier_District_Name"].ToString();
                        lblNatureofActivity.Text = dt.Rows[0]["Nature_of_Activity"].ToString();
                        lblInstalledCapacity.Text = dt.Rows[0]["Installed_Capacity"].ToString();
                        lblNoOfEmployee.Text = dt.Rows[0]["Employees"].ToString();
                        lblNature_of_Operation.Text = dt.Rows[0]["Nature_of_Operation"].ToString();
                        lblProject_Cost.Text = dt.Rows[0]["Project_Cost"].ToString();
                        lblOrganization_Type.Text = dt.Rows[0]["Organization_Type"].ToString();
                        lblIndustry_Type_Name.Text = dt.Rows[0]["Industry_Type_Name"].ToString();
                        lblItems_Manufactured.Text = dt.Rows[0]["Items_Manufactured"].ToString();
                        lblAnnual_Turnover.Text = dt.Rows[0]["Annual_Turnover"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Something Went Wrong With Nivesh Mitra Server');", true);
                    return;
                }

            }

        }

        protected void UserSpecificBinding()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.UserName = "Admin1";

            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                ddloffice.Items.Insert(0, new ListItem("--Select--", "ALL"));

                bindDDLRegion(ddloffice.SelectedItem.Value, null);
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


        private void bindDDLRegion(string pOffice, string pIAName)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));

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

        protected void Regional_Changed(object sender, EventArgs e)
        {

            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }



        }

        private void BindPlotsInModal()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfVacantPlotsIAWise(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridPlot.DataSource = ds.Tables[0];
                        //GridPlot.DataSource = null;
                        GridPlot.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no plots available for allotment at this time. You can explore other industrial areas for the availability of plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('" + message + "');", true);
                        btnSave.Enabled = false;
                        GridPlot.DataSource = null;
                        GridPlot.DataBind();
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

        private void BindPlotsForAmalgamation()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfVacantPlotsIAWise(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridAmalgamation.DataSource = ds.Tables[0];
                        GridAmalgamation.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no plots available for allotment at this time. You can explore other industrial areas for the availability of plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('" + message + "');", true);
                        btnSave.Enabled = false;
                        GridAmalgamation.DataSource = null;
                        GridAmalgamation.DataBind();
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

        private void BindSubdivisionPlots()
        {
            objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetListOfVacantPlotsForSubdivisionIAWise(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                        GridSubDivision.DataSource = ds.Tables[0];
                        GridSubDivision.DataBind();
                    }
                    else
                    {
                        string message = "Please note that for the industrial area you selected there are no subdivision plots available for allotment at this time. You can explore other industrial areas for the availability of subdivision plots.";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayMultiLineAlert('" + message + "');", true);
                        btnSave.Enabled = false;
                        GridSubDivision.DataSource = null;
                        GridSubDivision.DataBind();
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
        protected void check_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("check");
            foreach (GridViewRow gvrow in GridPlot.Rows)
            {
                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("check");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }
            }
            int index = Convert.ToInt32(row.RowIndex);
            string PlotNumber = GridPlot.DataKeys[index].Values[0].ToString() + "|" + GridPlot.DataKeys[index].Values[1].ToString() + "|" + "SQmts.";

            if (ddl2.Checked == true)
            {

                if (count > 1)
                {
                    string message = "Please Select Only Single Plot";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    ddl2.Checked = false;
                    return;
                }
                else
                {
                    lblmsgSpan.Visible = false;
                    lblmsgSpan.InnerHtml = "";
                }

                if (txtp1.Text == "")
                { txtp1.Text = PlotNumber; }
                else if (txtp2.Text == "")
                { txtp2.Text = PlotNumber; }
                else if (txtp3.Text == "")
                { txtp3.Text = PlotNumber; }

            }
            else if (ddl2.Checked == false)
            {
                if (txtp1.Text == PlotNumber)
                {
                    txtp1.Text = "";
                }
                if (txtp2.Text == PlotNumber)
                {
                    txtp2.Text = "";
                }
                if (txtp3.Text == PlotNumber)
                {
                    txtp3.Text = "";
                }
            }
        }

        protected void checkSubdivision_CheckedChanged(object sender, EventArgs e)
        {

            int count = 0;
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            CheckBox ddl2 = (CheckBox)row.FindControl("checkSubdivision");


            foreach (GridViewRow gvrow in GridSubDivision.Rows)
            {


                CheckBox myCheckBox = (CheckBox)gvrow.FindControl("checkSubdivision");
                if (myCheckBox.Checked == true)
                {
                    count = count + 1;
                }

            }

            int index = Convert.ToInt32(row.RowIndex);

            string PlotNumber = GridSubDivision.DataKeys[index].Values[0].ToString() + "|" + GridSubDivision.DataKeys[index].Values[1].ToString() + "|" + "SQmts.";

            if (ddl2.Checked == true)
            {

                if (count > 1)
                {
                    string message = "You can select only one plot for subdivision";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    ddl2.Checked = false;
                    return;
                }
                else
                {
                    lblmsgSpan.Visible = false;
                    lblmsgSpan.InnerHtml = "";
                }

                if (txtSubPlot.Text == "")
                { txtSubPlot.Text = PlotNumber; }


            }
            else if (ddl2.Checked == false)
            {
                if (txtSubPlot.Text == PlotNumber)
                {
                    txtSubPlot.Text = "";
                }


            }
        }

        protected void checkAmalgamation_CheckedChanged(object sender, EventArgs e)
        {

            try
            {


                CheckBox chk = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chk.NamingContainer;
                CheckBox ddl2 = (CheckBox)row.FindControl("checkSubdivision");



                int index = Convert.ToInt32(row.RowIndex);






                string str = string.Empty;
                string str1 = string.Empty;
                decimal totalArea = 0;
                foreach (GridViewRow rw in GridAmalgamation.Rows)
                {
                    CheckBox chkBx = (CheckBox)rw.FindControl("checkAmalgamation");
                    if (chkBx != null && chkBx.Checked)
                    {

                        str = str + rw.Cells[1].Text.Trim();
                        str += ",";
                        totalArea += Convert.ToDecimal(rw.Cells[2].Text.Trim());

                    }
                }
                lblAmalgamatedPlots.Text = str.TrimEnd(',');
                lblTotalArea.Text = totalArea.ToString() + " " + "SqrMts";
                lblAmalgamatedArea.Text = totalArea.ToString() + " " + "SqrMts";



                string PlotNumber = GridAmalgamation.DataKeys[index].Values[0].ToString();

                objServiceTimelinesBEL.IAIdParam = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.PlotNo = str.TrimEnd(',');
                DataSet ds = new DataSet();


                ds = objServiceTimelinesBLL.GetPlotAdjacencyDetails(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        private double Max(double a, double b, double c)
        {
            double MaxValue = 0;
            if (a > b)
            {
                if (a > c)
                {
                    MaxValue = a;
                }
                else
                {
                    MaxValue = c;
                }
            }
            else
            {
                if (b > c)
                {
                    MaxValue = b;
                }
                else
                {
                    MaxValue = c;
                }
            }
            return MaxValue;
        }

        protected void btnIAccept_Click(object sender, EventArgs e)
        {
            Allotment.ActiveViewIndex = 2;
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwnIA.SelectedValue == "39")
            {
               string msg= "Note : The Plot in the selected industrial area are reserved for only units manufacturing of Plastic and Allied products. Application for land allotment for any other sector will be summarily REJECTED.";
            
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+ msg.Trim() + "');", true);

            }
            txtEnterRequiredArea.Text = "";
            txtp1.Text = "";
            txtp2.Text = "";
            txtp3.Text = "";
            if (multi.ActiveViewIndex == 0)
            {
                BindPlotsInModal();
                GridPlot.Visible = true;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = false;
            }
            if (multi.ActiveViewIndex == 1)
            {
                BindSubdivisionPlots();
                GridPlot.Visible = false;
                GridSubDivision.Visible = true;
                GridAmalgamation.Visible = false;
            }
            if (multi.ActiveViewIndex == 2)
            {
                BindPlotsForAmalgamation();
                GridPlot.Visible = false;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = true;
            }
        }

        private void GetDeposites()
        {
            double choicearea = 0.00;
            string ChoosedPlot = "";
            double choiceareap1 = 0.00;
            double choiceareap2 = 0.00;
            double choiceareap3 = 0.00;
            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;
            string companyName = string.Empty;
            string ApplicantName = string.Empty;
            string applicantAddress = string.Empty;
            string SWCControlID = String.Empty;
            string SWCUnitID = String.Empty;
            string SWCServiceID = String.Empty;
            string SWCStatus = String.Empty;
            string SWCPayMode = String.Empty;

            try
            {
                ucAllotmentDeposits ucAllotmentDeposits1 = LoadControl("~/ucAllotmentDeposits.ascx") as ucAllotmentDeposits;

                //if (txtEnterRequiredArea.Text != string.Empty)
                //{
                //    choicearea = double.Parse(txtEnterRequiredArea.Text);
                //}


                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text != string.Empty)
                    {
                        string[] tokens = txtp1.Text.Split('|');
                        choiceareap1 = double.Parse(tokens[1].ToString());
                        choiceP1 = tokens[0].ToString();
                    }
                    if (txtp2.Text != string.Empty)
                    {
                        string[] tokens = txtp2.Text.Split('|');
                        choiceareap2 = double.Parse(tokens[1].ToString());
                        choiceP2 = tokens[0].ToString();
                    }
                    if (txtp3.Text != string.Empty)
                    {
                        string[] tokens = txtp3.Text.Split('|');
                        choiceareap3 = double.Parse(tokens[1].ToString());
                        choiceP3 = tokens[0].ToString();
                    }

                    choicearea = Max(choiceareap1, choiceareap2, choiceareap3);

                    if (choicearea == choiceareap1)
                    {
                        ChoosedPlot = choiceP1;
                    }
                    if (choicearea == choiceareap2)
                    {
                        ChoosedPlot = choiceP2;
                    }
                    if (choicearea == choiceareap3)
                    {
                        ChoosedPlot = choiceP3;
                    }
                }
                if (multi.ActiveViewIndex == 1)
                {

                    choicearea = double.Parse(txtEnterRequiredArea.Text);
                }
                if (multi.ActiveViewIndex == 2)
                {

                    choicearea = double.Parse(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7));
                }


                ucAllotmentDeposits1.IndustrialArea = Int32.Parse(drpdwnIA.SelectedValue.ToString());
                ucAllotmentDeposits1.choicearea = choicearea;
                ucAllotmentDeposits1.PlotNo = ChoosedPlot;
                //ucAllotmentDeposits1.choiceareap1 = choiceareap1;
                //ucAllotmentDeposits1.choiceareap2 = choiceareap2;
                //ucAllotmentDeposits1.choiceareap3 = choiceareap3;
                //ucAllotmentDeposits1.choiceP1 = choiceP1;
                //ucAllotmentDeposits1.choiceP2 = choiceP2;
                //ucAllotmentDeposits1.choiceP3 = choiceP3;
                ucAllotmentDeposits1.companyName = lblCompanyName.Text;
                ucAllotmentDeposits1.ApplicantName = lblOccupierName.Text;
                ucAllotmentDeposits1.applicantAddress = lblOccupierAddress.Text;
                ucAllotmentDeposits1.SWCControlID = lblControlId.Text;
                ucAllotmentDeposits1.SWCUnitID = lblUnitId.Text;
                //ucAllotmentDeposits1.SWCServiceID = lblser;
                //ucAllotmentDeposits1.SWCStatus = choiceP1;
                //ucAllotmentDeposits1.SWCPayMode = choiceP2;

                PlaceHolder1.Controls.Add(ucAllotmentDeposits1);



            }
            catch (Exception ex)
            { }
        }
        protected void btngetdata_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();

                string Contact = "";
                string Email = "";


                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                        return;
                    }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Required plot Size');", true);
                        return;
                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                }


                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());


                ds = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
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
                        GetDeposites();

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                         Phone No : " + Contact + " EmailId : " + Email;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        btnproceed.Enabled = false;
                        return;
                    }

                }
                else
                {
                    string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                      Phone No : " + Contact + " EmailId : " + Email;
                    btnproceed.Enabled = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }


            }
            catch (Exception ex)
            {

                string msg = "Exception Occurred";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                return;

            }


        }
        protected void btnproceed_Click(object sender, EventArgs e)
        {
            if (RadioNivesh.Checked == true)
            {
                Response.Redirect("http://niveshmitra.up.nic.in/");
            }
            else if (RadioUpsidc.Checked == true)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);

            }
            else if (RadioExisting.Checked == true)
            {
                Allotment.ActiveViewIndex = 4;
            }
            else if (RadioURN.Checked == true)
            {
                Allotment.ActiveViewIndex = 6;
            }
            else if (RadioTrackApp.Checked == true)
            {
                Response.Redirect("~/ApplicationTracker.aspx");
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose One Option');", true);
            }
        }
        public void AllertRedirect(string Par, string Par1)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirectBuilding('" + Par + "','" + Par1 + "');", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string str = string.Empty;

            double choicearea = 0.00;
            double choiceareap1 = 0.00;
            double choiceareap2 = 0.00;
            double choiceareap3 = 0.00;
            string choiceP1 = string.Empty;
            string choiceP2 = string.Empty;
            string choiceP3 = string.Empty;

            if (ControlID.Length > 0)
            {
                try
                {
                    string Contact = "";
                    string Email = "";
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                    string PreferredPlotSize = "";
                    decimal subTotalApplicableFees, subTotalDeposits, TotalCharges;

                    if (multi.ActiveViewIndex == 0)
                    {
                        if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                            return;
                        }
                        else
                        {
                            if (txtp1.Text != string.Empty)
                            {
                                string[] tokens = txtp1.Text.Split('|');
                                choiceareap1 = double.Parse(tokens[1].ToString());
                                choiceP1 = tokens[0].ToString();
                            }
                            if (txtp2.Text != string.Empty)
                            {
                                string[] tokens = txtp2.Text.Split('|');
                                choiceareap2 = double.Parse(tokens[1].ToString());
                                choiceP2 = tokens[0].ToString();
                            }
                            if (txtp3.Text != string.Empty)
                            {
                                string[] tokens = txtp3.Text.Split('|');
                                choiceareap3 = double.Parse(tokens[1].ToString());
                                choiceP3 = tokens[0].ToString();
                            }


                            PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();


                        }
                    }
                    if (multi.ActiveViewIndex == 1)
                    {
                        if (txtEnterRequiredArea.Text == "")
                        {

                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                            return;
                        }
                        else
                        {
                            PreferredPlotSize = txtEnterRequiredArea.Text;
                        }

                    }
                    if (multi.ActiveViewIndex == 2)
                    {
                        if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                            return;
                        }
                        else
                        {
                            PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                        }
                    }

                    objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());


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
                            string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :- Phone No : " + Contact + " EmailId : " + Email;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            btnproceed.Enabled = false;
                            return;
                        }

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :- Phone No : " + Contact + " EmailId : " + Email;
                        btnproceed.Enabled = false;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }


                    objServiceTimelinesBEL.industrialAreaID = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());
                    objServiceTimelinesBEL.choicearea = double.Parse(PreferredPlotSize.Trim());
                    DataSet dschoicearea = new DataSet();
                    DataTable Getdata1 = new DataTable();
                    DataTable Getdata2 = new DataTable();
                    dschoicearea = objServiceTimelinesBLL.GetapplicableFormFeeforAllotment(objServiceTimelinesBEL);
                    if (dschoicearea.Tables.Count > 0)
                    {


                        if (dschoicearea.Tables[0].Rows.Count > 0) { Getdata1 = dschoicearea.Tables[0]; }

                        subTotalApplicableFees = Convert.ToDecimal(Getdata1.Compute("SUM(applicablecharge)", string.Empty));

                        TotalCharges = subTotalApplicableFees;
                        hidAmt.Value = TotalCharges.ToString();

                        Status_Code = "12";
                        Fee_Amount = TotalCharges.ToString();
                        Fee_Status = "UB";

                        try
                        {


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
                                "NMSWP Fee Pending",
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
                                //  ControlID = "testFail";
                                try
                                {

                                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService1 = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                    DataSet dss = webService1.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt,Request_ID);

                                    DataTable dtt = dss.Tables[0];
                                    if (dtt.Rows.Count > 0)
                                    {

                                        string status_code = dtt.Rows[0]["Status_Code"].ToString();
                                        string Fee_Status = dtt.Rows[0]["Fee_Status"].ToString();

                                        if (status_code == "12")
                                        {

                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                    HidStatus.Value = "FAILED";
                                    str = "Page Under Upgaradation. Please Check After 24 Hours.";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                                    return;

                                }
                            }
                            else if ((HidStatus.Value == "FAILED"))
                            {
                                HidStatus.Value = "FAILED";
                                str = "Page Under Upgaradation. Please Check After 24 Hours.";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                                return;
                            }

                        }


                        catch (Exception ex)
                        {
                            HidStatus.Value = "FAILED";
                            str = "exception occureded in connecting Nivesh Mitra service.Please Contact Nivesh mitra Team";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + str + "');", true);
                            return;
                        }


                        //if No exception then check where payment requirement data is catured by Nivesh Mitra

                    }

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "AKS();", true);


                }
                catch (Exception ex)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                    return;

                }



            }
            else
            {
                SaveInHouseEntry();
            }

        }
        private void SaveInHouseEntry()
        {
            try
            {

                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                {
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                }

                string Contact = "";
                string Email = "";

                string choicearea = "";
                double choiceareap1 = 0.00;
                double choiceareap2 = 0.00;
                double choiceareap3 = 0.00;
                string choiceP1 = string.Empty;
                string choiceP2 = string.Empty;
                string choiceP3 = string.Empty;

                string PreferredPlotSize = "";

                string PreferencePlot1 = "", PreferencePlot2 = "", PreferencePlot3 = "";

                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                        return;
                    }
                    else
                    {
                        if (txtp1.Text != string.Empty)
                        {
                            string[] tokens = txtp1.Text.Split('|');
                            choiceareap1 = double.Parse(tokens[1].ToString());
                            PreferencePlot1 = tokens[0].ToString();
                        }
                        if (txtp2.Text != string.Empty)
                        {
                            string[] tokens = txtp2.Text.Split('|');
                            choiceareap2 = double.Parse(tokens[1].ToString());
                            PreferencePlot2 = tokens[0].ToString();
                        }
                        if (txtp3.Text != string.Empty)
                        {
                            string[] tokens = txtp3.Text.Split('|');
                            choiceareap3 = double.Parse(tokens[1].ToString());
                            PreferencePlot3 = tokens[0].ToString();
                        }


                        PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();

                        if (choiceareap1.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot1;
                        }
                        if (choiceareap2.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot2;
                        }
                        if (choiceareap3.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot3;
                        }



                    }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text == "")
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                        return;
                    }
                    else
                    {
                        string[] tokens = txtSubPlot.Text.Split('|');
                        PreferredPlotSize = txtEnterRequiredArea.Text;
                        choicearea = tokens[0].ToString();

                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (lblAmalgamatedArea.Text.Length > 0)
                    {
                        if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                            return;
                        }
                        else
                        {
                            PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                            choicearea = lblAmalgamatedPlots.Text;
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                }


                objServiceTimelinesBEL.IAId = Convert.ToInt32(drpdwnIA.SelectedValue.Trim());


                DataSet ds2 = objServiceTimelinesBLL.CheckIARatesExistOrNot(objServiceTimelinesBEL);
                DataSet ds1 = objServiceTimelinesBLL.GetIAContact(objServiceTimelinesBEL);
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Contact = ds1.Tables[0].Rows[0]["OfficePhoneNo"].ToString();
                        Email = ds1.Tables[0].Rows[0]["OfficeEMAILID"].ToString();
                    }

                }


                if (ds2.Tables.Count > 0)
                {


                    if (ds2.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                         Phone No : " + Contact + " EmailId : " + Email;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        btnproceed.Enabled = false;
                        return;
                    }

                }
                else
                {
                    string msg = "Please Note: The Current Plot Rates at this industrial area is either not updated or has not been finilized yet. Please Contact UPSIDC Administrator On Below Mentioned Details :-                      Phone No : " + Contact + " EmailId : " + Email;
                    btnproceed.Enabled = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }




                DataSet ds = new DataSet();
                objServiceTimelinesBEL.plotSize = PreferredPlotSize.Trim();
                objServiceTimelinesBEL.PlotNo = choicearea.Trim();
                objServiceTimelinesBEL.IndustrialArea = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.CreatedBy = ipaddress;
                objServiceTimelinesBEL.Preference1 = PreferencePlot1.Trim();
                objServiceTimelinesBEL.Preference2 = PreferencePlot2.Trim();
                objServiceTimelinesBEL.Preference3 = PreferencePlot3.Trim();

                ds = objServiceTimelinesBLL.ApplicationLandAllotmentInHouse(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblServiceRequestID.Text = ds.Tables[0].Rows[0]["ServiceRequestNO"].ToString();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayNdRedirect('" + lblServiceRequestID.Text + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }
        private void SaveNiveshMitraEntry()
        {
            try
            {
                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                {
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                }
                string choicearea = "";
                double choiceareap1 = 0.00;
                double choiceareap2 = 0.00;
                double choiceareap3 = 0.00;
                string choiceP1 = string.Empty;
                string choiceP2 = string.Empty;
                string choiceP3 = string.Empty;

                string PreferredPlotSize = "";

                string PreferencePlot1 = "", PreferencePlot2 = "", PreferencePlot3 = "";
                if (multi.ActiveViewIndex == 0)
                {
                    if (txtp1.Text.Length <= 0 && txtp2.Text.Length <= 0 && txtp3.Text.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Any Preference To calculate Deposites');", true);
                        return;
                    }
                    else
                    {
                        if (txtp1.Text != string.Empty)
                        {
                            string[] tokens = txtp1.Text.Split('|');
                            choiceareap1 = double.Parse(tokens[1].ToString());
                            PreferencePlot1 = tokens[0].ToString();
                        }
                        if (txtp2.Text != string.Empty)
                        {
                            string[] tokens = txtp2.Text.Split('|');
                            choiceareap2 = double.Parse(tokens[1].ToString());
                            PreferencePlot2 = tokens[0].ToString();
                        }
                        if (txtp3.Text != string.Empty)
                        {
                            string[] tokens = txtp3.Text.Split('|');
                            choiceareap3 = double.Parse(tokens[1].ToString());
                            PreferencePlot3 = tokens[0].ToString();
                        }


                        PreferredPlotSize = Max(choiceareap1, choiceareap2, choiceareap3).ToString();

                        if (choiceareap1.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot1;
                        }
                        if (choiceareap2.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot2;
                        }
                        if (choiceareap3.ToString() == PreferredPlotSize)
                        {
                            choicearea = PreferencePlot3;
                        }


                        if (choiceareap1 == choiceareap2)
                        {
                            if (choiceareap2 == choiceareap3)
                            {
                                if (choiceareap1 == choiceareap3)
                                {
                                    choicearea = PreferencePlot1;
                                }

                            }

                        }


                    }
                }
                if (multi.ActiveViewIndex == 1)
                {
                    if (txtEnterRequiredArea.Text == "")
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Required Area');", true);
                        return;
                    }
                    else
                    {
                        string[] tokens = txtSubPlot.Text.Split('|');
                        PreferredPlotSize = txtEnterRequiredArea.Text;
                        choicearea = tokens[0].ToString();

                    }
                }
                if (multi.ActiveViewIndex == 2)
                {
                    if (Convert.ToDecimal(lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7)) <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Choose Any Plot For Amalgamation');", true);
                        return;
                    }
                    else
                    {
                        PreferredPlotSize = lblAmalgamatedArea.Text.Substring(0, lblAmalgamatedArea.Text.Length - 7);
                        choicearea = lblAmalgamatedPlots.Text;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.plotSize = PreferredPlotSize.Trim();
                objServiceTimelinesBEL.PlotNo = choicearea.Trim();
                objServiceTimelinesBEL.IndustrialArea = drpdwnIA.SelectedValue.Trim();
                objServiceTimelinesBEL.CreatedBy = ipaddress;
                objServiceTimelinesBEL.Preference1 = PreferencePlot1.Trim();
                objServiceTimelinesBEL.Preference2 = PreferencePlot2.Trim();
                objServiceTimelinesBEL.Preference3 = PreferencePlot3.Trim();
                objServiceTimelinesBEL.ControlId = ControlID.Trim();
                objServiceTimelinesBEL.UnitId = UnitID.Trim();
                objServiceTimelinesBEL.ServiceId = ServiceID.Trim();
                objServiceTimelinesBEL.SWCRequestID = Request_ID.Trim();
                objServiceTimelinesBEL.Allotteename = lblOccupierName.Text.Trim();
                objServiceTimelinesBEL.Email = lblOccupierEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = lblOccupierPhone.Text.Trim();
                objServiceTimelinesBEL.applicantAddress = lblOccupierAddress.Text.Trim();
                objServiceTimelinesBEL.PanNo = lblOccupierPAN.Text.Trim();
                objServiceTimelinesBEL.companyName = lblCompanyName.Text.Trim();
                objServiceTimelinesBEL.NiveshMitraAmt = Convert.ToDecimal(hidAmt.Value);

                ds = objServiceTimelinesBLL.ApplicationLandAllotmentNiveshMitra(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblServiceRequestID.Text = ds.Tables[0].Rows[0]["ServiceRequestNO"].ToString();

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "DisplayNdRedirect('" + lblServiceRequestID.Text + "');", true);

                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }
        protected void hidbtn_Click(object sender, EventArgs e)
        {
            SaveNiveshMitraEntry();
            Allotment.ActiveViewIndex = 0;
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



        

        private void CheckNMSWPStatus()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                if (ControlID.Length > 0)
                {
                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ControlId = ControlID.Trim();
                    objServiceTimelinesBEL.UnitId = UnitID.Trim();
                    objServiceTimelinesBEL.ServiceId = ServiceID.Trim();
                    objServiceTimelinesBEL.SWCRequestID = Request_ID.Trim();

                    ds = objServiceTimelinesBLL.CheckControlIdAlreadyExist(objServiceTimelinesBEL);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string ServiceReqNo = ds.Tables[0].Rows[0]["ApplicationId"].ToString();
                            string FeePaid = ds.Tables[0].Rows[0]["AppFeePaid"].ToString();
                            if (FeePaid == "True")
                            {
                                btnDiv.Visible = true;
                                btnDiv1.Visible = false;
                            }
                            else
                            {
                                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                DataSet dss = webService.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt, Request_ID);
                                if (dss != null)
                                {
                                   
                                    DataTable dt = dss.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        btnDiv.Visible = true;
                                        btnDiv1.Visible = false;
                                    }
                                }
                                else
                                {
                                    btnDiv.Visible = false;
                                    btnDiv1.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            btnDiv.Visible = false;
                            btnDiv1.Visible = true;
                        }
                    }
                    else
                    {
                        btnDiv.Visible = false;
                        btnDiv1.Visible = true;
                    }
                }
                else
                {
                    btnDiv.Visible = false;
                    btnDiv1.Visible = true;
                }

            }

            catch (Exception)
            {

                throw;
            }
        }


        protected void proceedAnchor_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (ServiceID == "SC21012" || ServiceID == "SC21013" || ServiceID == "SC21014" || ServiceID == "SC21015" || ServiceID == "SC21016" || ServiceID == "SC21017" || ServiceID == "SC21018" || ServiceID == "SC21019" || ServiceID == "SC21020" || ServiceID == "SC21021" || ServiceID == "SC21022" || ServiceID == "SC21023" || ServiceID == "SC21024" || ServiceID == "SC21025" || ServiceID == "SC21026" || ServiceID == "SC21027" || ServiceID == "SC21028" || ServiceID == "SC21029" || ServiceID == "SC21030" || ServiceID == "SC21031" || ServiceID == "SC21032" || ServiceID == "SC21027" )
                {
                    
                    string NMControlID = HttpUtility.UrlEncode(Encrypt(ControlID.Trim()));
                    string NMUnitID    = HttpUtility.UrlEncode(Encrypt(UnitID.Trim()));
                    string NMServiceID = HttpUtility.UrlEncode(Encrypt(ServiceID.Trim()));
                    string NMRequestID = HttpUtility.UrlEncode(Encrypt(Request_ID.Trim()));
                    Response.Redirect(string.Format("~/IAServicesNew.aspx?NMControlID={0}&NMUnitID={1}&NMServiceID={2}&NMRequestID={3}", NMControlID, NMUnitID, NMServiceID, NMRequestID));
                }
                else if (ServiceID == "SC21034")
                {

                    string NMControlID = HttpUtility.UrlEncode(Encrypt(ControlID.Trim()));
                    string NMUnitID = HttpUtility.UrlEncode(Encrypt(UnitID.Trim()));
                    string NMServiceID = HttpUtility.UrlEncode(Encrypt(ServiceID.Trim()));
                    string NMRequestID = HttpUtility.UrlEncode(Encrypt(Request_ID.Trim()));
                    Response.Redirect(string.Format("~/IAServicesNew.aspx?NMControlID={0}&NMUnitID={1}&NMServiceID={2}&NMRequestID={3}", NMControlID, NMUnitID, NMServiceID, NMRequestID));
                }

                else if (ServiceID == "SC21036")
                {

                    string NMControlID = HttpUtility.UrlEncode(Encrypt(ControlID.Trim()));
                    string NMUnitID = HttpUtility.UrlEncode(Encrypt(UnitID.Trim()));
                    string NMServiceID = HttpUtility.UrlEncode(Encrypt(ServiceID.Trim()));
                    string NMRequestID = HttpUtility.UrlEncode(Encrypt(Request_ID.Trim()));

                    string AppName = HttpUtility.UrlEncode(Encrypt(lblOccupierName.Text.Trim()));
                    string AppEmail = HttpUtility.UrlEncode(Encrypt(lblOccupierEmail.Text.Trim()));
                    string AppMobNo = HttpUtility.UrlEncode(Encrypt(lblOccupierPhone.Text.Trim()));

                    Response.Redirect(string.Format("~/RegistrationLogistics.aspx?NMControlID={0}&NMUnitID={1}&NMServiceID={2}&NMRequestID={3}&AppName={4}&AppEmail={5}&AppMobNo=(6}", NMControlID, NMUnitID, NMServiceID, NMRequestID, AppName, AppEmail, AppMobNo));
                }

                else
                {
                    DataSet ds = new DataSet();

                    if (ControlID.Length > 0)
                    {
                        objServiceTimelinesBEL.ControlId    = ControlID.Trim();
                        objServiceTimelinesBEL.UnitId       = UnitID.Trim();
                        objServiceTimelinesBEL.ServiceId    = ServiceID.Trim();
                        objServiceTimelinesBEL.SWCRequestID = Request_ID.Trim();

                        ds = objServiceTimelinesBLL.CheckControlIdAlreadyExist(objServiceTimelinesBEL);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string ServiceReqNo = ds.Tables[0].Rows[0]["ApplicationId"].ToString();
                                string FeePaid = ds.Tables[0].Rows[0]["AppFeePaid"].ToString();
                                if (FeePaid == "True")
                                {
                                    
                                    Navigation(ServiceReqNo); 
                                }
                                else
                                {
                                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                    DataSet dss = webService.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt, Request_ID);
                                    if (dss != null)
                                    {
                                        
                                        DataTable dt = dss.Tables[0];
                                        if (dt.Rows.Count > 0)
                                        {
                                            string status = dt.Rows[0]["status_code"].ToString();
                                            if (status == "11")
                                            {
                                                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                                                int retval = objServiceTimelinesBLL.UpdateFeePaidStatus(objServiceTimelinesBEL);
                                                if (retval > 0)
                                                {
                                                    GeneralMethod gm = new GeneralMethod();
                                                    string NMSWP_Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "10", "Application Fee Paid at Nivesh Mitra and Application has been saved as draft | Applicant", Request_ID, "Applicant", "");

                                                    Navigation(ServiceReqNo);
                                                }
                                                else
                                                {
                                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Error Occured');", true);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please First Pay Application Fee.And then Proceed further');", true);
                                                return;
                                            }
                                        }
                                    }else
                                    {
                                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                                    }
                                }
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                            }
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void btnTrack_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = txtServiceReqNo.Text.Trim();
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);

                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    string TraID = dt.Rows[0]["ApplicationTraID"].ToString();
                    string Paid = dt.Rows[0]["Paid"].ToString();
                    string PayType = dt.Rows[0]["ResponseCode"].ToString();
                    string Clarification = dt.Rows[0]["IsClarificationReq"].ToString();
                    string status = "";

                    if (Clarification == "True")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectC('" + txtServiceReqNo.Text + "');", true);
                    }

                    if (Paid == "True")
                    {
                        status = "F";
                    }
                    else
                    {
                        status = "C";
                    }

                    if (TraID == "" || TraID == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirect('" + txtServiceReqNo.Text + "');", true);
                    }
                    else
                    {

                        if (PayType == "E00329")
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + txtServiceReqNo.Text + "','" + TraID + "');", true);

                            }
                        }
                        else
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + txtServiceReqNo.Text + "','" + TraID + "');", true);
                            }
                        }
                    }


                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void btngotoware_Click(object sender, EventArgs e)
        {

            if (ServiceID.Trim() == "SC21036")
            {

                //PageHeadingLbl.Text = "Application for Issuance of Unique Id for Private Industrial Parks ";
                //lblServiceName.Text = "Application for Issuance of Unique Id for Private Industrial Parks ";

                string NMControlID = HttpUtility.UrlEncode(Encrypt(ControlID.Trim()));
                string NMUnitID = HttpUtility.UrlEncode(Encrypt(UnitID.Trim()));
                string NMServiceID = HttpUtility.UrlEncode(Encrypt(ServiceID.Trim()));
                string NMRequestID = HttpUtility.UrlEncode(Encrypt(Request_ID.Trim()));

                string AppName = HttpUtility.UrlEncode(Encrypt(lblOccupierName.Text.Trim()));
                string AppEmail = HttpUtility.UrlEncode(Encrypt(lblOccupierEmail.Text.Trim()));
                string AppMobNo = HttpUtility.UrlEncode(Encrypt(lblOccupierPhone.Text.Trim()));
                Response.Redirect(string.Format("~/RegistrationLogistics.aspx?NMControlID={0}&NMUnitID={1}&NMServiceID={2}&NMRequestID={3}", NMControlID, NMUnitID, NMServiceID, NMRequestID));
              //Response.Redirect(string.Format("~/RegistrationLogistics.aspx?NMControlID={0}&NMUnitID={1}&NMServiceID={2}&NMRequestID={3}&AppName={4}&AppEmail={5}&AppMobNo=(6}", NMControlID, NMUnitID, NMServiceID, NMRequestID, AppName, AppEmail, AppMobNo));
            }
        }
        private void Navigation(string ReqNo)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ReqNo;
                ds = objServiceTimelinesBLL.GetNewApplicantDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    string TraID   = dt.Rows[0]["ApplicationTraID"].ToString();
                    string Paid    = dt.Rows[0]["Paid"].ToString();
                    string PayType = dt.Rows[0]["ResponseCode"].ToString();

                    string Clarification = dt.Rows[0]["IsClarificationReq"].ToString();
                    string status = "";

                    if (Clarification.Trim() == "True" || Clarification.Trim() == "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectC('" + ReqNo + "');", true);
                        return;
                    }



                    if (Paid == "True")
                    {
                        status = "F";
                    }
                    else
                    {
                        status = "C";
                    }



                    if (TraID == "" || TraID == null)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirect('" + ReqNo + "');", true);
                        return;
                    }
                    else
                    {

                        if (PayType == "E00329")
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + ReqNo + "','" + TraID + "');", true);
                                return;
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + ReqNo + "','" + TraID + "');", true);
                                return;
                            }
                        }
                        else
                        {
                            if (status == "F")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentF('" + ReqNo + "','" + TraID + "');", true);
                                return;
                            }
                            if (status == "C")
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "OnlyRedirectPaymentC('" + ReqNo + "','" + TraID + "');", true);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            ClearTextBoxes();
            int index = Int32.Parse(e.Item.Value);
            multi.ActiveViewIndex = index;
            if (index == 0)
            {
                BindPlotsInModal();
                GridPlot.Visible = true;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = false;
            }
            if (index == 1)
            {
                BindSubdivisionPlots();
                GridPlot.Visible = false;
                GridSubDivision.Visible = true;
                GridAmalgamation.Visible = false;
            }
            if (index == 2)
            {
                BindPlotsForAmalgamation();
                GridPlot.Visible = false;
                GridSubDivision.Visible = false;
                GridAmalgamation.Visible = true;
            }

        }
        private void ClearTextBoxes()
        {
            txtp1.Text = "";
            txtp2.Text = "";
            txtp3.Text = "";
            txtSubPlot.Text = "";
            txtEnterRequiredArea.Text = "";
            lblAmalgamatedArea.Text = "";
            lblAmalgamatedPlots.Text = "";
            lblTotalArea.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        private void ExistingAllottee()
        {
            try
            {
                UC_Service_Allotteee_Detail UC_Service_Allotteee_Detail = new UC_Service_Allotteee_Detail();
                UC_Service_Building_Plan UC_Service_Building_Plan = new UC_Service_Building_Plan();


                SqlCommand cmd = new SqlCommand("select * from AllotteeMaster where IndustrialArea='" + drdIA.SelectedItem.Text.Trim() + "' and PlotNo='" + txtPlotNo.Text + "' and Allotmentletterno='" + txtLetterNo.Text.Trim() + "'  ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();


                    string NMRequestID = dt1.Rows[0]["NMRequestID"].ToString().Trim();
                    if (NMRequestID.Length > 0)
                    {
                        if (NMRequestID == Request_ID)
                        {

                            string Allotmentletterno = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                            ViewState["Allotmentletterno"] = Allotmentletterno.Trim();
                            Allotment.ActiveViewIndex = 3;
                            PlaceHolder2.Controls.Clear();
                            UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                            UC_Service_Building_Plan.ID = "Service_Building_Plan";
                            UC_Service_Building_Plan.SerReqID = ServiceReqNo;
                            UC_Service_Building_Plan.ControlID = ControlID;
                            UC_Service_Building_Plan.UnitID = UnitID;
                            UC_Service_Building_Plan.ServiceID = ServiceID;
                            UC_Service_Building_Plan.RequestID = Request_ID;
                            UC_Service_Building_Plan.SerID_in = "1";
                            UC_Service_Building_Plan.UserBy = ViewState["Allotmentletterno"].ToString().Trim();
                            UC_Service_Building_Plan.page_type = "ENTRY";
                            UC_Service_Building_Plan.App = App;
                            UC_Service_Building_Plan.AllottementLetterNo = ViewState["Allotmentletterno"].ToString().Trim();
                            UC_Service_Building_Plan.Page_Load(null, null);
                            PlaceHolder2.Controls.Add(UC_Service_Building_Plan);
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Kindly Apply through same nivesh mitra ID "+ Request_ID + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        string Allotmentletterno = dt1.Rows[0]["Allotmentletterno"].ToString().Trim();
                        ViewState["Allotmentletterno"] = Allotmentletterno.Trim();
                        Allotment.ActiveViewIndex = 3;
                        PlaceHolder2.Controls.Clear();
                        UC_Service_Building_Plan = LoadControl("~/UC_Service_Building_Plan.ascx") as UC_Service_Building_Plan;
                        UC_Service_Building_Plan.ID = "Service_Building_Plan";
                        UC_Service_Building_Plan.SerReqID = ServiceReqNo;
                        UC_Service_Building_Plan.ControlID = ControlID;
                        UC_Service_Building_Plan.UnitID = UnitID;
                        UC_Service_Building_Plan.ServiceID = ServiceID;
                        UC_Service_Building_Plan.RequestID = Request_ID;
                        UC_Service_Building_Plan.SerID_in = "1";
                        UC_Service_Building_Plan.UserBy = ViewState["Allotmentletterno"].ToString().Trim();
                        UC_Service_Building_Plan.page_type = "ENTRY";
                        UC_Service_Building_Plan.App = App;
                        UC_Service_Building_Plan.AllottementLetterNo = ViewState["Allotmentletterno"].ToString().Trim();
                        UC_Service_Building_Plan.Page_Load(null, null);
                        PlaceHolder2.Controls.Add(UC_Service_Building_Plan);
                    }
                }
                else
                {
                    SendMailToRM();

                }
            }

            catch (Exception ex) { }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            DateTime dates1 = DateTime.Now;
            DateTime dates2 = Convert.ToDateTime("01/28/2023");
            if (dates1 < dates2)
            {
                ExistingAllottee();
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Go Nivesh Mitra, Request for New Sanction Building Plan Application');", true);
                return;
            }
        }
        protected void txtServieReqNo_TextChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = txtServieReqNo.Text.Trim();
                ds = objServiceTimelinesBLL.GetTransactionDetailsByServiceReqNo(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    btnUpdateURN.Enabled = true;
                    lblTransactionId.Text = dt.Rows[0]["TransactionRefNo"].ToString();
                    lblBankRefNo.Text = dt.Rows[0]["EazypayRefNo"].ToString();
                    lblTransactionDate.Text = dt.Rows[0]["TransactionDate"].ToString();
                    lblTransactionAmt.Text = dt.Rows[0]["TransactionAmount"].ToString();

                    if (dt1.Rows.Count > 0)
                    {
                        txtURNNo.Text = dt1.Rows[0]["URNNumber"].ToString();
                        txtPayDate.Text = dt1.Rows[0]["PaymentDate"].ToString();
                        txtBankName.Text = dt1.Rows[0]["BankName"].ToString();
                        txtURNNo.Enabled = false;
                        txtPayDate.Enabled = false;
                        txtBankName.Enabled = false;
                        btnUpdateURN.Enabled = false;
                        btnUpdateURN.Text = "Already Updated";

                    }


                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Challan Not Generated Yet');", true);
                    txtURNNo.Text = "";
                    txtPayDate.Text = "";
                    txtBankName.Text = "";
                    lblTransactionId.Text = "";
                    lblBankRefNo.Text = "";
                    lblTransactionDate.Text = "";
                    lblTransactionAmt.Text = "";
                    btnUpdateURN.Enabled = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        protected void btnUpdateURN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtURNNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide URN No');", true);
                    return;
                }
                if (txtBankName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Provide Bank Name');", true);
                    return;
                }

                GeneralMethod gm = new GeneralMethod();
                if (gm.ValidateDate(txtPayDate.Text))
                {




                    objServiceTimelinesBEL.ServiceRequestNO = txtServieReqNo.Text.Trim();
                    objServiceTimelinesBEL.TranID = lblTransactionId.Text.Trim();
                    objServiceTimelinesBEL.ChallanDate = Convert.ToDateTime(lblTransactionDate.Text);

                    objServiceTimelinesBEL.PayTrans_trn_amt = lblTransactionAmt.Text;
                    objServiceTimelinesBEL.URNNo = txtURNNo.Text;
                    string date_to_be = DateTime.ParseExact(txtPayDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.PayDate = Convert.ToDateTime(date_to_be);
                    objServiceTimelinesBEL.BankName = txtBankName.Text;

                    int result = objServiceTimelinesBLL.UpdateURN(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "AlertRedirectPaymentF('" + txtServieReqNo.Text + "','" + lblTransactionId.Text + "');", true);

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Not Updated');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Payment Date Format');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.ToString().Trim() + "');", true);
                return;

            }
        }
        protected void btnClickViewForm_Click(object sender, EventArgs e)
        {
            GeneralMethod gm = new GeneralMethod();
            SqlCommand cmd = new SqlCommand("select B.ServiceRequestNO,B.Status,IsNull(A.BPFeePaid,'False') 'BPFeePaid',BuildingTraID,isNull(B.IsClarificationReq,0) 'BuildingPlanObjection',isnull(B.IsRejected,0) 'IsRejected' from AllotteeMaster A, ServiceRequests B where A.AllotteeID = B.AllotteeID  and B.ServiceRequestNO='" + ViewID + "' and isnull(B.IsActive,0)=1", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            adp.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                string Rej = dt1.Rows[0]["IsRejected"].ToString();
                string Req = dt1.Rows[0]["ServiceRequestNO"].ToString();
                string Red = dt1.Rows[0]["Status"].ToString();
                string FeePAid = dt1.Rows[0]["BPFeePaid"].ToString();
                string TraID = dt1.Rows[0]["BuildingTraID"].ToString();
                string Objection = dt1.Rows[0]["BuildingPlanObjection"].ToString();

                if (Rej == "True")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirectObjection('" + Req.Trim() + "','" + TraID + "');", true);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Application is rejected. Due to some reasons Nivesh Mitra is not allowing resubmission of rejected application. Soon the alternative solution will be made available. Sorry for the inconvinience');", true);
                    return;
                }

                else if (Objection == "True")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirectObjection('" + Req.Trim() + "','" + TraID + "');", true);
                    return;
                }
                else if (Convert.ToDateTime(gm.GetServiceDate(ViewID)) < DateTime.ParseExact("25/08/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    if (FeePAid == "False")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirectWithMessage('" + Req.Trim() + "','" + TraID + "');", true);
                        return;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirect('" + Req.Trim() + "','" + TraID + "');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirect('" + Req.Trim() + "','" + TraID + "');", true);
                    return;
                }
            }
        }
        private void SendMailToRM()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_DetailsForDataDigitization " + drdIA.SelectedValue.Trim() + "", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string UserName = dt.Rows[0]["EMPLOYEENAME"].ToString();
                    string EmailID = dt.Rows[0]["emailID"].ToString();
                    if (EmailID.Length > 0)
                    {
                        MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                        MailAddress mailto = new MailAddress(EmailID.Trim());
                        //MailAddress addressBCC = new MailAddress("manish.ims08@gmail.com");
                        //MailAddress addressBCC1 = new MailAddress("gopal.j.singh@gmail.com");
                        //MailAddress addressBCC2 = new MailAddress("anurag9449@gmail.com");
                       // MailAddress addressBCC3 = new MailAddress("priyu.7nov@gmail.com");
                        MailMessage newmsg = new MailMessage(mailfrom, mailto);
                        //newmsg.Bcc.Add(addressBCC);
                        //newmsg.Bcc.Add(addressBCC1);
                        //newmsg.Bcc.Add(addressBCC2);
                       // newmsg.Bcc.Add(addressBCC3);

                        string StrContent = "";
                        StreamReader reader = new StreamReader(Server.MapPath("~/DataDigitizeIntimationMail.html"));
                        StrContent = reader.ReadToEnd();

                        StrContent = StrContent.Replace("{UserName}", UserName.Trim());
                        StrContent = StrContent.Replace("{ApplicantName}", lblOccupierName.Text.Trim());
                        StrContent = StrContent.Replace("{CompanyName}", lblCompanyName.Text.Trim());
                        StrContent = StrContent.Replace("{ApplicantPhone}", lblOccupierPhone.Text.Trim());
                        StrContent = StrContent.Replace("{PlotNo}", txtPlotNo.Text.Trim());
                        StrContent = StrContent.Replace("{IndustrialArea}", drdIA.SelectedItem.Text.Trim());


                        newmsg.Subject = "UPSIDCeServe: Intimation to digitize allottee record in master ";
                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.outlook.com";
                        client.Port = 587;
                        client.Username = mailfrom.Address;
                        client.Password = "upsida12345";
                        client.ConnectionProtocols = ConnectionProtocols.Ssl;
                        client.SendOne(newmsg);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The data digitization of your record has been initiated. Please come back after 3 working days to re-initiate your application process');", true);
                        return;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Record Not Found.Kindly Contact Respected Regional Office To Update Your Record.');", true);
                        return;
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Something Went Wrong.');", true);
                return;
            }


        }
        private void BindIADistictWise()
        {

            try
            {

                if (ControlID.Length > 0)
                {
                    ControlID = Request.Form["TxtControlID"];
                    UnitID = Request.Form["TxtUnitID"];
                    ServiceID = Request.Form["TxtServiceID"];
                    ProcessIndustryID = Request.Form["TxtProcessIndustryID"];
                    ApplicationID = Request.Form["TxtApplicationID"];

                    //ControlID = "UPSWP202024827";
                    //UnitID = "UPSWP20202482702";
                    //ServiceID = "SC21003";
                    //Request_ID = "20202482702210030002";

                    //passsalt = "p5632aa8a5c915ba4b896325bc5baz8k";
                    //ControlID = "UPSWP222151317";
                    //UnitID = "UPSWP22215131702";
                    //ServiceID = "SC21001";
                    //Request_ID = "22215131702210010001";
                    //ControlID = "UPSWP210235546";
                    //UnitID = "UPSWP21023554601";
                    //ServiceID = "SC21002";
                    //ProcessIndustryID = "";
                    //ApplicationID = "";
                    // Request_ID = "210235546012101";

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
                    //--------------Test------------------------------------
                    //ControlID = "UPSWP190840615";
                    //UnitID = "UPSWP19084061503";
                    //ServiceID = "SC21001";
                    //Request_ID = "19084061503210020001";

                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet ds = webService.WGetBasicDetails(ControlID, UnitID, ServiceID, "", passsalt);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        lblDistrictName.Text = dt.Rows[0]["Industry_District"].ToString();
                        NM_DistrictID = dt.Rows[0]["Industry_District_ID"].ToString();
                        lblDistictN.Text = dt.Rows[0]["Industry_District"].ToString();
                       
                    }
                }
               // lblReqV.Text = NM_DistrictID + ' ' + lblDistrictName.Text + ' ' + lblDistictN.Text;
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
                objServiceTimelinesBEL.districtID = NM_DistrictID;
                 
                DataSet dsR = new DataSet();
                dsR = objServiceTimelinesBLL.GetIADistrictWise(objServiceTimelinesBEL);
                drdIA.DataSource = dsR.Tables[0];
                drdIA.DataTextField = "IAName";
                drdIA.DataValueField = "ID";
                drdIA.DataBind();
                drdIA.Items.Insert(0, new ListItem("--Select--", "ALL"));
                drdiaN.DataSource = dsR.Tables[0];
                drdiaN.DataTextField = "IAName";
                drdiaN.DataValueField = "ID";
                drdiaN.DataBind();
                drdiaN.Items.Insert(0, new ListItem("--Select--", "ALL"));
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ControlID = "UPSWP202024827";
            //UnitID = "UPSWP20202482702";
            //ServiceID = "SC21003";
            //Request_ID = "20202482702210030002";
            try
            {


                if (drdiaN.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtSerNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your previous service request number');", true);
                    return;
                }
                SqlCommand cmd = new SqlCommand("select B.BuildingTraID , DATEDIFF(DAY,A.CreatedDate,GETDATE()) 'YearsCheck',B.EmailID,case when isnull(B.AllotteeName,'')>'' then B.AllotteeName else B.CompanyName end 'AllotteeName',B.AllotteeID from Servicerequests A , AllotteeMaster B where A.ServiceRequestNo='" + txtSerNo.Text.Trim() + "' and B.IndustrialArea='" + drdiaN.SelectedItem.Text.Trim() + "' and A.AllotteeID=B.AllotteeID and A.IsRejected=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int Days = Convert.ToInt32(dt.Rows[0]["YearsCheck"].ToString());
                    string TraID = dt.Rows[0][0].ToString().Trim();
                    string EmailID = dt.Rows[0][2].ToString().Trim();
                    string AllotteeName = dt.Rows[0][3].ToString().Trim();
                    string AllotteeID = dt.Rows[0][4].ToString().Trim();

                    if (Days > 365)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The one year time period from the date of first application is over.You are requested to re apply through a new application.');", true);
                        return;
                    }
                    if (EmailID.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID is not updated. Kindly ask Rm office to update your email id');", true);
                        return;
                    }

                    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
                    string numbers = "1234567890";

                    string characters = numbers;
                    int length = 5;
                    string otp = string.Empty;
                    for (int i = 0; i < length; i++)
                    {
                        string character = string.Empty;
                        do
                        {
                            int index = new Random().Next(0, characters.Length);
                            character = characters.ToCharArray()[index].ToString();
                        } while (otp.IndexOf(character) != -1);
                        otp += character;
                    }

                    MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(EmailID);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);
                    //newmsg.IsBodyHtml = true;

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/BPResubmissionOTPMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", AllotteeName.Trim());
                    StrContent = StrContent.Replace("{OTP}", otp.Trim());

                    newmsg.Subject = "UPSIDAeService: OTP verification for building plan resubmission ";
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    objServiceTimelinesBEL.UserId = Convert.ToInt32(AllotteeID);
                    objServiceTimelinesBEL.emailID = EmailID;
                    objServiceTimelinesBEL.OTP = otp;
                    objServiceTimelinesBEL.ReferenceNumber = txtSerNo.Text;
                    objServiceTimelinesBEL.OTPFor = "BPResubmission";

                    int result = objServiceTimelinesBLL.SaveOTPBPResubmission(objServiceTimelinesBEL);
                    if (result > 0)
                    {

                        string message1 = "OTP Send To Your Registered Email ID which is " + EmailID.Trim() + ". Kindly verify OTP for the Resubmission of your application";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                        DivOTP.Visible = true;
                        Button2.Visible = true;
                        Button1.Text = "Resend OTP";
                        return;

                    }
                    else
                    {
                        string message1 = "Unable To send OTP Kindly Update your EmailID";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                        DivOTP.Visible = false;
                        Button2.Visible = false;
                        return;
                    }
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                    DivOTP.Visible = false;
                    Button2.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured Exception :" + ex.Message.ToString());
                DivOTP.Visible = false;
                Button2.Visible = false;
                return;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ControlID = "UPSWP202024827";
            UnitID = "UPSWP20202482702";
            ServiceID = "SC21003";
            Request_ID = "20202482702210030002";
            try
            {
                if (drdiaN.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtSerNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your previous service request number');", true);
                    return;
                }
                if (txtOTP.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your OTP');", true);
                    return;
                }
                SqlCommand cmd = new SqlCommand("select B.BuildingTraID , DATEDIFF(DAY,A.CreatedDate,GETDATE()) 'YearsCheck',B.EmailID,case when isnull(B.AllotteeName,'')>'' then B.AllotteeName else B.CompanyName end 'AllotteeName',B.AllotteeID from Servicerequests A , AllotteeMaster B where A.ServiceRequestNo='" + txtSerNo.Text.Trim() + "' and B.IndustrialArea='" + drdiaN.SelectedItem.Text.Trim() + "' and A.AllotteeID=B.AllotteeID and A.IsRejected=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int Days = Convert.ToInt32(dt.Rows[0]["YearsCheck"].ToString());
                    string TraID = dt.Rows[0][0].ToString().Trim();
                    string EmailID = dt.Rows[0][2].ToString().Trim();
                    string AllotteeName = dt.Rows[0][3].ToString().Trim();
                    string AllotteeID = dt.Rows[0][4].ToString().Trim();

                    if (Days > 365)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The one year time period from the date of first application is over.You are requested to re apply through a new application.');", true);
                        return;
                    }

                    if (EmailID.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID is not updated. Kindly ask Rm office to update your email id');", true);
                        return;
                    }


                    objServiceTimelinesBEL.UserID = Convert.ToInt32(AllotteeID);
                    objServiceTimelinesBEL.OTP = txtOTP.Text.Trim();
                    objServiceTimelinesBEL.OTPFor = "BPResubmission";

                    DataSet dsR = new DataSet();


                    dsR = objServiceTimelinesBLL.VerifyOTPBPResubmission(objServiceTimelinesBEL);
                    DataTable dtt = new DataTable();
                    dtt = dsR.Tables[0];

                    if (dtt.Rows.Count > 0)
                    {
                        string message = dtt.Rows[0]["message"].ToString();
                        string status = dtt.Rows[0]["status"].ToString();

                        if (status == "2")
                        {
                            objServiceTimelinesBEL.SWCControlID = ControlID;
                            objServiceTimelinesBEL.SWCUnitID = UnitID;
                            objServiceTimelinesBEL.SWCServiceID = ServiceID;
                            objServiceTimelinesBEL.SWCRequestID = Request_ID.Trim();
                            objServiceTimelinesBEL.ServiceRequestNO = txtSerNo.Text.Trim();
                            int result = objServiceTimelinesBLL.UpdateBPResubmission(objServiceTimelinesBEL);
                            if (result > 0)
                            {

                                  ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                                  string Update_Result = webService.WReturn_CUSID_STATUS(
                                  ControlID,
                                  UnitID,
                                  ServiceID,
                                  ProcessIndustryID,
                                  ApplicationID,
                                  "10",
                                  "Resubmission For Building Plan Initiated.Pending For Resubmission",
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
                                if (Update_Result == "SUCCESS")
                                {
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "BPRedirectObjectionMessage('" + txtSerNo.Text.Trim() + "','" + TraID + "');", true);
                                    return;
                                }
                                else
                                {
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Server Not Responding');", true);
                                    return;
                                }
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Server Not Responding');", true);
                                return;
                            }
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid OTP. Kindly Recheck It');", true);
                            return;
                        }

                    }

                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Service Request No');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }

        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://niveshmitra.up.nic.in/Testing_NMSWP/nmmasters/Entrepreneur_Dashboard.aspx");
            //try
            //{
            //    if (ViewID != null)
            //    {
            //        GeneralMethod gm = new GeneralMethod();
            //        DataTable NMSWP = gm.GetNMSWPIDForBP(ViewID);
            //        if (NMSWP.Rows.Count > 0)
            //        {
            //            ControlID = NMSWP.Rows[0][0].ToString();
            //            UnitID = NMSWP.Rows[0][1].ToString();
            //            ServiceID = NMSWP.Rows[0][2].ToString();
            //        }
            //    }
            //    if (ServiceReqNo != null)
            //    {
            //        GeneralMethod gm = new GeneralMethod();
            //        DataTable NMSWP = gm.GetNMSWPIDForBP(ServiceReqNo);
            //        if (NMSWP.Rows.Count > 0)
            //        {
            //            ControlID = NMSWP.Rows[0][0].ToString();
            //            UnitID = NMSWP.Rows[0][1].ToString();
            //            ServiceID = NMSWP.Rows[0][2].ToString();
            //        }
            //    }


            //    string SWCControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", ControlID);
            //    string SWCUnitID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", UnitID);
            //    string SWCServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", ServiceID);
            //    string DeptID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
            //    string PassSalt = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
            //    NameValueCollection collections = new NameValueCollection();
            //    collections.Add("Dept_Code", DeptID.Trim());
            //    collections.Add("ControlID", SWCControlID.Trim());
            //    collections.Add("UnitID",    SWCUnitID.Trim());
            //    collections.Add("ServiceID", SWCServiceID.Trim());
            //    collections.Add("PassSalt",  PassSalt.Trim());
            //    string remoteUrl = "http://niveshmitra.up.nic.in/nmmasters/Entrepreneur_Bck_page.aspx";

            //    string html = "<html><head>";
            //    html += "</head><body onload='document.forms[0].submit()'>";
            //    html += string.Format("<form name='PostForm' style='display:none;' method='POST' action='{0}'>", remoteUrl);
            //    foreach (string key in collections.Keys)
            //    {
            //        html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
            //    }
            //    html += "</form></body></html>";
            //    Response.Clear();
            //    Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
            //    Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
            //    Response.Charset = "ISO-8859-1";
            //    Response.Write(html);
            //    Response.End();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void BLPUpdate(string ServiceReqNo)
        {
            Classes.Class1 cs = new Classes.Class1();
            try
            {
                cs.str = "SELECT TOP 10 NMControlID,NMUnitID,NMServiceID,NMRequestID,* FROM ServiceRequests WHERE ServiceRequestNO='" + ServiceReqNo + "' ";
                DataTable dt1 = new DataTable();
                dt1 = cs.GetDataTable(cs.str);
                if (dt1.Rows.Count > 0)
                {
                    ControlID = dt1.Rows[0]["NMControlID"].ToString();
                    UnitID = dt1.Rows[0]["NMUnitID"].ToString();
                    ServiceID = dt1.Rows[0]["NMServiceID"].ToString();
                    Request_ID = dt1.Rows[0]["NMRequestID"].ToString();
 
                    ServiceReference1.upswp_niveshmitraservicesSoapClient webService1 = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                    DataSet dss = webService1.WGetUBPaymentDetails(ControlID, UnitID, ServiceID, passsalt, Request_ID);

                    DataTable dtt = dss.Tables[0];
                    if (dtt.Rows.Count > 0)
                    {

                        string status_code = dtt.Rows[0]["Status_Code"].ToString();
                        string Fee_Status = dtt.Rows[0]["Fee_Status"].ToString();
                        
                        try
                        {
                            if (status_code == "11")
                            {
                                //if (ServiceID == "1")
                                //{
                                string[] SerIdarray = ServiceReqNo.Split('/');
                                string service_id = SerIdarray[1];
                                string AllotteeId = SerIdarray[2];

                                SqlCommand cmd = new SqlCommand("select Allotmentletterno, ControlId, UnitId ,ServiceId, IndustrialArea  from [dbo].[AllotteeMaster]  where [AllotteeID] = '" + AllotteeId + "' ", con);
                                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                adp.Fill(dt);

                                ControlID = dt.Rows[0]["ControlId"].ToString();
                                UnitID = dt.Rows[0]["UnitId"].ToString();
                                string IANAME = dt.Rows[0]["IndustrialArea"].ToString();
                                ServiceID = dt.Rows[0]["ServiceId"].ToString();


                                if (ServiceID == "SC21002")
                                {
                                    Status_Code = "13";
                                    Remarks = "Form Submitted To | DA(" + IANAME + ")";
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
                                        {
                                            belBookDetails objServiceTimelinesBEL = new belBookDetails();
                                            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                                            objServiceTimelinesBEL.ServiceRequest = ServiceReqNo;
                                            int retVal = objServiceTimelinesBLL.SetBPResubmit(objServiceTimelinesBEL);
                                            if (retVal > 0)
                                            {
                                                //MessageBox1.ShowSuccess("Application submitted");
                                                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Application submitted');", true);
                                                //Response.Redirect(Path.GetFileName(Request.Path) + "?ViewID=" + lblserRequest.Text.Trim(), false);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            // MessageBox1.ShowWarning("Your Application is rejected kindly re-apply by using Resubmission service of nivesh mitra");
                                            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Some technical error');", true);
                                            return;
                                        }
                                    }

                                }
                            }
                        //}
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
                }
            }
            catch (Exception ex)
            {

                //HidStatus.Value = "FAILED";
                //cs.str = "Page Under Upgaradation. Please Check After 24 Hours.";
               // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + cs.str + "');", true);
               // return;

            }
        }
    }
}