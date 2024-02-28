using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class UC_RaiseDemandPlusObjection : System.Web.UI.UserControl
    {
        SqlConnection con;
        
        public string IAID = "";
        string SWCControlID = "";
        string SWCUnitID = "";
        string SWCServiceID = "";
        string SWCRequest_ID = "";
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        private System.Delegate _delPageMethod;
        GeneralMethod gm = new GeneralMethod();
        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }

        public string ServiceReqNo { get; set; }
        
        string UserName = "";
        string AllotteeID = "";
        int UserId = 0;
        public string Level = "";
        public string DataManager = "";

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.RegisterPostBackControl();
                string[] SerIdarray = ServiceReqNo.Split('/');
                AllotteeID = SerIdarray[2].Trim();
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
                UserId = _objLoginInfo.userid;
                DataTable NMSWP = gm.GetNMSWPIDNews(ServiceReqNo);
                SWCControlID    = NMSWP.Rows[0][0].ToString();
                SWCUnitID       = NMSWP.Rows[0][1].ToString();
                SWCServiceID    = NMSWP.Rows[0][2].ToString();
                SWCRequest_ID   = NMSWP.Rows[0][3].ToString();
                SqlCommand cmd = new SqlCommand("Select Level,DataManager from UserAssociationMaster where UserID=" + UserId + " and isNull(ActiveStatus,0)=1", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0][0].ToString();
                    DataManager = dt.Rows[0][1].ToString();
                }


                if (!IsPostBack)
                {
                    BindAllotteePaymentSummary();
                    
                }
                BindObjectionType();
                BindNMObjectionType();
                PreviousDues();
                checkObjection();
            }
            catch (Exception ex)
            {
            }

        }
        protected void AllotteePaymentSummaruGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= AllotteePaymentSummaruGrid.Rows.Count - 1; i++)
            {
                string Amount = AllotteePaymentSummaruGrid.Rows[i].Cells[4].Text;
                if (Convert.ToDecimal(Amount) > 0)
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Red;
                }
                else
                {
                    AllotteePaymentSummaruGrid.Rows[i].Cells[4].ForeColor = Color.Green;
                }

            }


        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpload);
        }

        private void BindAllotteePaymentSummary()
        {
            SqlCommand cmd = new SqlCommand("[sp_GetAllotteePaymntSummary] " + AllotteeID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AllotteePaymentSummaruGrid.DataSource = dt;
                AllotteePaymentSummaruGrid.DataBind();
                decimal tot_Demanded = dt.AsEnumerable().Sum(row => row.Field<decimal>("Demanded"));
                decimal tot_Paid = dt.AsEnumerable().Sum(row => row.Field<decimal>("Paid"));
                decimal tot_Outstanding = dt.AsEnumerable().Sum(row => row.Field<decimal>("Outstanding"));
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].Text = "Total";
                AllotteePaymentSummaruGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                AllotteePaymentSummaruGrid.FooterRow.Cells[2].Text = tot_Demanded.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[3].Text = tot_Paid.ToString("N2");
                AllotteePaymentSummaruGrid.FooterRow.Cells[4].Text = tot_Outstanding.ToString("N2");
            }
            else
            {
                AllotteePaymentSummaruGrid.DataSource = null;
                AllotteePaymentSummaruGrid.DataBind();
            }
        }


        private DataSet GetData(string query)
        {
            SqlCommand cmd = new SqlCommand(query);

            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }

        }

        protected void drpObjection_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllotteePaymentSummary();
            if (drpObjection.SelectedValue == "1")
            {
                DuesDiv.Visible = true;
                OthrsDiv.Visible = false;
                docdiv.Visible = true;
            }
            else if (drpObjection.SelectedValue == "2")
            {
                DuesDiv.Visible = false;
                OthrsDiv.Visible = true;
                docdiv.Visible = true;
            }
            else
            {
                DuesDiv.Visible = false;
                OthrsDiv.Visible = false;
                docdiv.Visible = false;
            }
        }


        private void BindNMObjectionType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_GetNMobjectionType] '" + SWCServiceID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    drp_NMObjectionType.DataSource = dt;
                    drp_NMObjectionType.DataTextField = "Reason_Details";
                    drp_NMObjectionType.DataValueField = "Reson_ID";
                    drp_NMObjectionType.DataBind();
                    drp_NMObjectionType.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void BindObjectionType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_GetobjectionType] '" + SWCServiceID + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    drpObjection.DataSource = dt;
                    drpObjection.DataTextField = "Type";
                    drpObjection.DataValueField = "ID";
                    drpObjection.DataBind();
                    drpObjection.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string[] List = ServiceReqNo.Split('/');
                string Service = List[1].ToString();
                int retVal = 0, retVal1 = 0;

                if (drp_NMObjectionType.SelectedValue == "0")
                {
                    MessageBox1.ShowError("Please Select Nivesh Mitra Objection Type");
                    return;
                }
                if (drpObjection.SelectedValue == "0")
                {
                    MessageBox1.ShowError("Please Slelect Objection Type");
                    return;
                }



                if (drpObjection.SelectedValue.Trim() == "1")
                {

                    SqlCommand cmd = new SqlCommand("Sp_getpaymentOutstanding '" + ServiceReqNo + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string due = dt.Rows[0][0].ToString();
                        if (due.Length > 0)
                        {
                            decimal Oustanding = Convert.ToDecimal(dt.Rows[0][0].ToString());

                            if (Oustanding <= 0)
                            {
                                MessageBox1.ShowError("There is no pending dues against this allottee");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox1.ShowError("There is no pending dues against this allottee");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox1.ShowError("No payment details found against this allottee");
                        return;
                    }


                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.UserName = UserName;

                    retVal = objServiceTimelinesBLL.RaisePaymentObjection(objServiceTimelinesBEL);


                    if (retVal > 0)
                    {
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.ObjectionType = drpObjection.SelectedValue;
                        objServiceTimelinesBEL.UserName = UserName;
                        objServiceTimelinesBEL.ObjectionDesc = TextBox1.Text;
                        objServiceTimelinesBEL.LAName = Convert.ToString(Session["LAFileName"]);
                        objServiceTimelinesBEL.LAContentType = Convert.ToString(Session["LAFileExt"]);
                        objServiceTimelinesBEL.LADocumentsMap = Session["LAFile"] as byte[];
                        objServiceTimelinesBEL.NMObjectionRejectionType = drp_NMObjectionType.SelectedValue.Trim();
                        retVal1 = objServiceTimelinesBLL.RaiseObjectionIAService(objServiceTimelinesBEL);
                        SendDuesObjectionMail();
                    }


                }
                else
                {
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.ObjectionType = drpObjection.SelectedValue;
                    objServiceTimelinesBEL.UserName = UserName;
                    objServiceTimelinesBEL.ObjectionDesc = txtObjectionDesc.Text;
                    objServiceTimelinesBEL.LAName = Convert.ToString(Session["LAFileName"]);
                    objServiceTimelinesBEL.LAContentType = Convert.ToString(Session["LAFileExt"]);
                    objServiceTimelinesBEL.LADocumentsMap = Session["LAFile"] as byte[];
                    objServiceTimelinesBEL.NMObjectionRejectionType = drp_NMObjectionType.SelectedValue.Trim();
                    retVal1 = objServiceTimelinesBLL.RaiseObjectionIAService(objServiceTimelinesBEL);
                    if (retVal1 > 0)
                    {
                        SendDuesObjectionMailGeneral();
                    }
                }
                if (retVal1 > 0)
                {
                    if (SWCControlID.Length > 0)
                    {
                        string Status = "08";
                        string Remarks = objServiceTimelinesBEL.ObjectionDesc.ToString() + " | DA " + gm.Get_IAName_ByServiceRequstNo(ServiceReqNo) + " raises query and objection to Applicant";
                        string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, Status, Remarks, SWCRequest_ID, "Applicant", drp_NMObjectionType.SelectedValue.Trim());
                        if (Service == "4" || Service == "1000")
                        {
                            Response.Redirect("~/ServiceRequestInboxNew.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("~/ServiceRequestInboxIA.aspx", false);
                        }
                    }
                    else if (Service == "4" || Service == "1000")
                    {
                        Response.Redirect("~/ServiceRequestInboxNew.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/ServiceRequestInboxIA.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private DataTable Getdata1
        {
            get; set;
        }
        private DataTable Getdata2
        {
            get; set;
        }
        private DataTable Getdata3
        {
            get; set;
        }


        private void PreviousDues()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetPreviousDemandDues '" + ServiceReqNo + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) { Getdata1 = ds.Tables[0]; }
                if (ds.Tables[1].Rows.Count > 0) { Getdata2 = ds.Tables[1]; }
                if (ds.Tables[2].Rows.Count > 0) { Getdata3 = ds.Tables[2]; }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    GridView1.DataSource = Getdata3;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void checkObjection()
        {
            try
            {

                SqlCommand cmmd = new SqlCommand("[GetObjectionTimelineIAService] '" + ServiceReqNo + "'", con);
                SqlDataAdapter adpp = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                adpp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][1].ToString() == "Close")
                    {

                        btnSend.Enabled = false;
                        Button1.Enabled = false;
                    }
                   else  if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 7)
                    {

                        btnSend.Enabled = false;
                        Button1.Enabled = false;
                    }
                    else
                    {
                        btnSend.Enabled = true;
                        Button1.Enabled = true;
                    }


                }
            

                
               
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string IAID = GridView2.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataRow[] dr = Getdata2.Select("DemandId = '" + IAID + "'");
                    DataTable dt1 = dr.CopyToDataTable();
                    GridView grdview = e.Row.FindControl("GridViewAllotmentRequest") as GridView;
                    grdview.DataSource = dt1;
                    grdview.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }


        private void SendDuesObjectionMail()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('/');
                string Service = SerIdarray[1].ToString();
                string ServiceName = "";
                switch (Service)
                {
                    case "1003":
                        ServiceName = "Change Of Project";
                        break;
                    case "1004":
                        ServiceName = "Addition Of Product";
                        break;
                    case "1009":
                        ServiceName = "Completion Certificate";
                        break;
                    case "1010":
                        ServiceName = "Occupancy Certificate";
                        break;
                    case "1002":
                        ServiceName = "Time Extension";
                        break;
                    case "1005":
                        ServiceName = "NOC For Mortgage";
                        break;
                    case "1006":
                        ServiceName = "Permission For Joint Mortgage";
                        break;
                    case "1007":
                        ServiceName = "Creation Of Second Charge";
                        break;
                    case "1008":
                        ServiceName = "Request For Reconctitution of Allottee";
                        break;
                    case "1012":
                        ServiceName = "Restoration of Plot";
                        break;
                    case "1013":
                        ServiceName = "Cancellation of Plot";
                        break;
                    case "1014":
                        ServiceName = "Start of Production Certificate";
                        break;
                    case "1017":
                        ServiceName = "Handover of Lease Deed to Lessee";
                        break;
                    case "1021":
                        ServiceName = "Request for Reconstitution of Legal Heir after death";
                        break;
                    case "1022":
                        ServiceName = "Request for Water Connection";
                        break;
                    case "1023":
                        ServiceName = "Request for No Dues Certificate";
                        break;
                    case "1024":
                        ServiceName = "Request for Surrender of Plot";
                        break;
                    case "1025":
                        ServiceName = "Request for Additional Unit Under Same Premises";
                        break;
                    case "1026":
                        ServiceName = "Request for Subletting of Plot";
                        break;
                    case "1027":
                        ServiceName = "Request for Outstanding Dues Position";
                        break;
                    case "1011":
                        ServiceName = "Transfer Of Lease Deed";
                        break;
                    case "1001":
                        ServiceName = "Lease Deed Execution";
                        break;
                    case "4":
                        ServiceName = "Transfer Of Plot";
                        break;


                }


                decimal totalAmount = 0;
                SqlCommand cmdd = new SqlCommand("Sp_getpaymentOutstanding '" + ServiceReqNo + "'", con);
                SqlDataAdapter adpp = new SqlDataAdapter(cmdd);
                DataTable dtt = new DataTable();
                adpp.Fill(dtt);
                totalAmount = Convert.ToDecimal(dtt.Rows[0][0].ToString());

                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunicationMail '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string ApplicationDate = dt.Rows[0]["ApplicationDate"].ToString();


                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;
                    if (Session["LAFile"] != null)
                    {
                        newmsg.Attachments.Add(new Attachment(new MemoryStream(Session["LAFile"] as byte[]), "ObjectionDoc.pdf"));
                    }

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/DuesObjectionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Amount}", totalAmount.ToString());
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo.Trim());
                    StrContent = StrContent.Replace("{ServiceName}", ServiceName.Trim());

                    if (Service == "1001")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);
                    }
                    else if (Service == "1002" || Service == "1005" || Service == "1006" || Service == "1007" || Service == "1011" || Service == "1013" || Service == "1014")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication_Module.aspx?ServiceReqNo=" + ServiceReqNo);

                    }
                    else if (Service == "1012" || Service == "1024" || Service == "1025" || Service == "1026")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication_Module1.aspx?ServiceReqNo=" + ServiceReqNo);

                    }
                    else if (Service == "1017" || Service == "1021" || Service == "1008")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAReconstitutionApplication.aspx?ServiceReqNo=" + ServiceReqNo);

                    }
                    else if(Service=="4")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IATransferOfPlotApplication.aspx?ServiceReqNo=" + ServiceReqNo);

                    }
                    else 
                    {
                        StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/IAServicesApplication.aspx?ServiceReqNo=" + ServiceReqNo);

                    }

                    newmsg.Subject = "UPSIDAeService: Intimation for objection of pending dues against application for " + ServiceName;
                    newmsg.BodyHtml = StrContent;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string s = gm.SendOTP("OTP", PhoneNo, ApplicantName, "Dear Applicant please pay amount of Rs." + totalAmount + " to be paid to UPSIDA for further processing of your application");

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SendDuesObjectionMailGeneral()
        {

            try
            {
                string[] SerIdarray = ServiceReqNo.Split('/');
                string Service = SerIdarray[1].ToString();
                string ServiceName = "";
                switch (Service)
                {
                    case "1003":
                        ServiceName = "Change Of Project";
                        break;
                    case "1004":
                        ServiceName = "Addition Of Product";
                        break;
                    case "1009":
                        ServiceName = "Completion Certificate";
                        break;
                    case "1010":
                        ServiceName = "Occupancy Certificate";
                        break;
                    case "1002":
                        ServiceName = "Time Extension";
                        break;
                    case "1005":
                        ServiceName = "NOC For Mortgage";
                        break;
                    case "1006":
                        ServiceName = "Permission For Joint Mortgage";
                        break;
                    case "1007":
                        ServiceName = "Creation Of Second Charge";
                        break;
                    case "1008":
                        ServiceName = "Request For Reconctitution of Allottee";
                        break;
                    case "1012":
                        ServiceName = "Restoration of Plot";
                        break;
                    case "1013":
                        ServiceName = "Cancellation of Plot";
                        break;
                    case "1014":
                        ServiceName = "Start of Production Certificate";
                        break;
                    case "1017":
                        ServiceName = "Handover of Lease Deed to Lessee";
                        break;
                    case "1021":
                        ServiceName = "Request for Reconstitution of Legal Heir after death";
                        break;
                    case "1022":
                        ServiceName = "Request for Water Connection";
                        break;
                    case "1023":
                        ServiceName = "Request for No Dues Certificate";
                        break;
                    case "1024":
                        ServiceName = "Request for Surrender of Plot";
                        break;
                    case "1025":
                        ServiceName = "Request for Additional Unit Under Same Premises";
                        break;
                    case "1026":
                        ServiceName = "Request for Subletting of Plot";
                        break;
                    case "1027":
                        ServiceName = "Request for Outstanding Dues Position";
                        break;
                    case "1011":
                        ServiceName = "Transfer Of Lease Deed";
                        break;
                    case "1001":
                        ServiceName = "Lease Deed Execution";
                        break;
                    case "4":
                        ServiceName = "Transfer Of Plot";
                        break;
                }


                string Objection = "";
                SqlCommand cmdd = new SqlCommand("Sp_GetClarificationRaisedByRO '" + ServiceReqNo + "'", con);
                SqlDataAdapter adpp = new SqlDataAdapter(cmdd);
                DataTable dtt = new DataTable();
                adpp.Fill(dtt);
                Objection = dtt.Rows[0]["Objection"].ToString();

                SqlCommand cmd = new SqlCommand("GetAllotteeDetailsForCommunicationMail '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    string ApplicantName = dt.Rows[0]["AllotteeName"].ToString();
                    string ApplicantEmail = dt.Rows[0]["Email"].ToString();
                    string PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    string DAName = dt.Rows[0]["DAName"].ToString();
                    string RegionalOffice = dt.Rows[0]["RegionalOffice"].ToString();
                    string DAPhone = dt.Rows[0]["DANO"].ToString();
                    string OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    string Date = dt.Rows[0]["Date"].ToString();
                    string PlotNo = dt.Rows[0]["PlotNo"].ToString();
                    string IAName = dt.Rows[0]["IAName"].ToString();
                    string ApplicationDate = dt.Rows[0]["ApplicationDate"].ToString();


                  MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                    MailAddress mailto = new MailAddress(ApplicantEmail);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    //newmsg.IsBodyHtml = true;

                    if (Session["LAFile"] != null)
                    {
                        newmsg.Attachments.Add(new Attachment(new MemoryStream(Session["LAFile"] as byte[]), "ObjectionDoc.pdf"));
                    }

                    string StrContent = "";
                    StreamReader reader = new StreamReader(Server.MapPath("~/ObjectionMail.html"));
                    StrContent = reader.ReadToEnd();

                    StrContent = StrContent.Replace("{UserName}", ApplicantName.Trim());
                    StrContent = StrContent.Replace("{Objection}", Objection.Trim());
                    StrContent = StrContent.Replace("{SerNo}", ServiceReqNo.Trim());
                    StrContent = StrContent.Replace("{ServiceName}", ServiceName.Trim());

                    if (Service == "1001")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/LeaseDeedApplication.aspx?ViewID=" + ServiceReqNo);
                    }
                    else if (Service == "1002" || Service == "1005" || Service == "1006" || Service == "1007" || Service == "1011" || Service == "1013" || Service == "1014")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication_Module.aspx?ServiceReqNo=" + ServiceReqNo);
                    }
                    else if (Service == "1012" || Service == "1024" || Service == "1025" || Service == "1026")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAServicesApplication_Module1.aspx?ServiceReqNo=" + ServiceReqNo);
                    }
                    else if (Service == "1017" || Service == "1021" || Service == "1008")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IAReconstitutionApplication.aspx?ServiceReqNo=" + ServiceReqNo);
                    }
                    else if (Service == "4")
                    {
                        StrContent = StrContent.Replace("{Link}", "https://eservices.onlineupsidc.com/IATransferOfPlotApplication.aspx?ServiceReqNo=" + ServiceReqNo);
                    }
                    else
                    {
                        StrContent = StrContent.Replace("{Link}", "http://eservices.onlineupsidc.com/IAServicesApplication.aspx?ServiceReqNo=" + ServiceReqNo);
                    }

                    newmsg.Subject = "UPSIDAeService: Intimation for objection of pending dues against application for " + ServiceName;
                    newmsg.BodyHtml = StrContent;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.outlook.com";
                    client.Port = 587;
                    client.Username = mailfrom.Address;
                    client.Password = "upsida12345";
                    client.ConnectionProtocols = ConnectionProtocols.Ssl;
                    client.SendOne(newmsg);


                    string s = gm.SendOTP("OTP", PhoneNo, ApplicantName, "Dear Applicant please clear the objection raised by UPSIDA against your application ref no " + ServiceReqNo + ".");


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Page.GetType().InvokeMember("View_Ledger", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { "Ledger" });

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int maxFileSize = 3;

            if (FileUploadLoaction.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = FileUploadLoaction.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;
                int fileSize = FileUploadLoaction.PostedFile.ContentLength;
                if (fileSize > (maxFileSize * 1024 * 1024))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 3 mb');", true);
                    return;
                }

                //Set the contenttype based on File Extension
                switch (ext)
                {

                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                    case ".PDF":
                        contenttype = "application/pdf";
                        break;

                }

                if (contenttype != String.Empty && ext == ".pdf")
                {

                    Stream fs = FileUploadLoaction.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    objServiceTimelinesBEL.LAName = filename;
                    objServiceTimelinesBEL.content = contenttype;
                    objServiceTimelinesBEL.Uploadfile = bytes;

                    Session["LAFileName"] = objServiceTimelinesBEL.LAName;
                    Session["LAFileExt"] = objServiceTimelinesBEL.content;
                    Session["LAFile"] = objServiceTimelinesBEL.Uploadfile;
                    lbluploadingMsg.Text = "File uploaded Successfully";
                    lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsg.Visible = true;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                    return;

                }

            }
            else
            {

            }
        }
    }
}