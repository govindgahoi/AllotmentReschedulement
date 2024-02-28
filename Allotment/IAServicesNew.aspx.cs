using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;
//using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;

namespace Allotment
{
    public partial class IAServicesNew : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        GeneralMethod gm = new GeneralMethod();
        public string ServiceReqNo;
        public string SWCControlID;
        public string SWCUnitID;
        public string SWCServiceID;
        public string SWCRequest_ID;
        string TypeID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con           = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = "SER20230912/1000/1654/83069";
                Session["ServiceReqNo"] = ServiceReqNo;

                string[] SerIdarray = ServiceReqNo.Split('/');
                TypeID = SerIdarray[1].ToString();
                SWCControlID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMControlID"]));
                SWCUnitID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMUnitID"]));
                SWCServiceID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMServiceID"]));
                SWCRequest_ID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["NMRequestID"]));
                //SWCControlID = "UPSWP210002975";
                //SWCUnitID = "UPSWP21000297507";
                //SWCServiceID = "SC21034";
                //SWCRequest_ID = "21000297507210340001";

                switch (SWCServiceID.ToString())
                {
                    case "SC21012":
                        {
                            lblservicename.Text = "Application For Addition of Product";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    /*case "SC1029":
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('For New Application ,Please Select Amagmation (OBPS) service on NIVESH MITRA');", true);
                            Response.Redirect("http://72.167.225.87/nivesh/");
                            break;
                        }
                        */
                    case "SC21013":
                        {
                            lblservicename.Text = "Application For Change of Project";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21014":
                        {
                            lblservicename.Text = "Application For Execution & Registration of Lease Deed";
                            LeaseDeedDiv.Visible = true;
                            BindServiceCheckListGridViewDocument();
                            break;
                        }
                    case "SC21022":
                        {
                            lblservicename.Text = "Online Payment of Reservation Money";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21025":
                        {
                            lblservicename.Text = "Online Request for Transfer of Plot";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21029":
                        {
                            lblservicename.Text = "Application For No Dues Certificate";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21028":
                        {
                            lblservicename.Text = "Request for oustanding dues position";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21027":
                        {
                            lblservicename.Text = "Online Payment of Outstanding Dues";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }

                    #region Manish Shukla

                    case "SC21015":
                        {
                            lblservicename.Text = "Request for Time Extension";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }

                    case "SC21016":
                        {
                            lblservicename.Text = "Request for Noc for permission to mortgage in favour of Financial Institution";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21017":
                        {
                            lblservicename.Text = "Request for Second Charge";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21018":
                        {
                            lblservicename.Text = "Request for permission for Joint Mortgage";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21019":
                        {
                            lblservicename.Text = "Request for Transfer of Lease deed to Financial Institution";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21020":
                        {
                            lblservicename.Text = "Request for Start of Production Certificate";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21021":
                        {
                            lblservicename.Text = "Request for Restoration of plot";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }

                    case "SC21026":
                        {
                            lblservicename.Text = "Request for Surrender of Plot";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21030":
                        {
                            lblservicename.Text = "Request for Establishment of Additional Unit";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21031":
                        {
                            lblservicename.Text = "Request for Subletting of Plot";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    #endregion
                    #region Faizan
                    #region Faizan
                   case "SC21034":
                       {
                           lblservicename.Text = "Request for Amalgamation Post Allotment";
                           LeaseDeedDiv.Visible = false;
                           break;
                       }


                   #endregion
                        /*
                    case "SC21034":
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('For New Application ,Please Select Amagmation (OBPS) service on Nivesh Mitra');", true);
                            //Response.Redirect("http://72.167.225.87/nivesh/");
                            //Response.Redirect("http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx");
                            lblservicename.Text = "<h1 style='color:#fff;' > For New Application ,Please Select Amagmation (OBPS) service on Nivesh Mitra,Please Press GoBack Button to redirect Nivesh Mitra </h1>";

                            btnfind.Visible = false;
                            FilterDiv.Visible = false;
                            break;
                        }
                        */


                    #endregion

                    #region Manish Rastogi

                    case "SC21032":
                        {
                            lblservicename.Text = "Request for handover of lease deed to the lessee";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }

                    case "SC21023":
                        {
                            lblservicename.Text = "Request for legal heir after death";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    case "SC21024":
                        {
                            lblservicename.Text = "Request for reconstitution allottee firm / company";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }
                    #endregion

                    default:
                        {
                            lblservicename.Text = "";
                            LeaseDeedDiv.Visible = false;
                            break;
                        }

                }
            }
            catch
            {
            }

           
            if (!IsPostBack)
            {

                bindIndustrialAreaDetail();
                BindLandUse();
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

        private void BindLandUse()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPlotStatus();
                drpPlotType.DataSource = ds.Tables[4];
                drpPlotType.DataTextField = "UseZone";
                drpPlotType.DataValueField = "Id";
                drpPlotType.DataBind();
                drpPlotType.SelectedValue = "2";
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



        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {
              
                
               objServiceTimelinesBEL.IAName = drpIndusrialArea.SelectedItem.Text.Trim();
               objServiceTimelinesBEL.PlotNo = txtPlotNo.Text.Trim();
              
                ds = objServiceTimelinesBLL.GetAllotteeRecordToBindForLeaseDeed(objServiceTimelinesBEL);
                
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    switch (SWCServiceID.ToString())
                    {
                        case "SC21012":
                            {
                                ddlServices.SelectedValue = "1004";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21013":
                            {
                                ddlServices.SelectedValue = "1003";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21014":
                            {
                                ddlServices.SelectedValue = "1001";
                                LeaseDeedDiv.Visible = true;
                                break;
                            }
                        case "SC21022":
                            {
                                ddlServices.SelectedValue = "200";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21025":
                            {
                                ddlServices.SelectedValue = "4";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21029":
                            {
                                ddlServices.SelectedValue = "1023";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21028":
                            {
                                ddlServices.SelectedValue = "1027";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21027":
                            {
                                ddlServices.SelectedValue = "1028";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }

                        #region Manish Shukla

                        case "SC21015":
                            {
                                ddlServices.SelectedValue = "1002";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }

                        case "SC21016":
                            {
                                ddlServices.SelectedValue = "1005";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21017":
                            {
                                ddlServices.SelectedValue = "1007";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21018":
                            {
                                ddlServices.SelectedValue = "1006";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21019":
                            {
                                ddlServices.SelectedValue = "1011";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21020":
                            {
                                ddlServices.SelectedValue = "1014";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21021":
                            {
                                ddlServices.SelectedValue = "1012";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }

                        case "SC21026":
                            {
                                ddlServices.SelectedValue = "1024";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21030":
                            {
                                ddlServices.SelectedValue = "1025";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21031":
                            {
                                ddlServices.SelectedValue = "1026";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        #endregion
                        #region Faizan
                        case "SC21034":
                            {
                                ddlServices.SelectedValue = "1029";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        #endregion

                        #region Manish Rastogi

                        case "SC21032":
                            {
                                ddlServices.SelectedValue = "1017";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }

                        case "SC21023":
                            {
                                ddlServices.SelectedValue = "1021";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        case "SC21024":
                            {
                                ddlServices.SelectedValue = "1008";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                        #endregion

                        default:
                            {
                                ddlServices.SelectedValue = "0";
                                LeaseDeedDiv.Visible = false;
                                break;
                            }
                      
                    }

                    AllotteeDiv.Visible = true;
                    lblAllotmentLetterNo.Text   = dt.Rows[0]["AllotmentletterNo"].ToString();
                    lblRegionalOffice.Text      = dt.Rows[0]["RegionalOffice"].ToString();
                    lblIndustrialArea.Text      = dt.Rows[0]["IAName"].ToString();
                    lblAllotteeName.Text        = dt.Rows[0]["AllotteeName"].ToString();
                    lblFirmCompanyName.Text     = dt.Rows[0]["CompanyName"].ToString();
                    lblAddress.Text             = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text     = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text      = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text   = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text              = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text            = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text                = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text          = dt.Rows[0]["AllotteeID"].ToString();
                    FilterDiv.Visible           = false;

                }
                else
                {
                    AllotteeDiv.Visible = false;
                    string msg = "Invalid Details";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
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
            objServiceTimelinesBEL.IndustrialArea     = lblIAID.Text;
            objServiceTimelinesBEL.AlloteeId          = lblAllotteeID.Text;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32(ddlServices.SelectedValue.Trim());
            objServiceTimelinesBEL.CreatedBy          = lblAllotmentLetterNo.Text;
                objServiceTimelinesBEL.SWCControlID       = SWCControlID.Trim();
            objServiceTimelinesBEL.SWCUnitID          = SWCUnitID.Trim();
            objServiceTimelinesBEL.SWCServiceID       = SWCServiceID.Trim();
            objServiceTimelinesBEL.SWCRequestID       = SWCRequest_ID.Trim();
            if (StampChk1s.Checked == true)
            {
                objServiceTimelinesBEL.EligibleRebate = "1";
            }
            else
            {
                objServiceTimelinesBEL.EligibleRebate = "0";
            }
            if (AvailChk.Checked == true)
            {
                objServiceTimelinesBEL.AvailRebate = "1";
            }

            else
            {
                objServiceTimelinesBEL.AvailRebate = "0";
            }
            objServiceTimelinesBEL.TransferCondition = ViewState["Transfer"].ToString();
            objServiceTimelinesBEL.GSTNo = txtGstNo.Text.Trim();
            try
            {
                DataSet ds = new DataSet();
                ds = objServiceTimelinesBLL.SetServiceRequestIAServiceNMSWP(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnRaise.Enabled = false;
                        string RefNo = ds.Tables[0].Rows[0][0].ToString().Trim();

                        string[] SerArray = RefNo.Split('/');
                        int Service = int.Parse(SerArray[1]);
                        if (Service == 1003 || Service == 1004 || Service == 1023 || Service == 1027)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        else if(Service == 1001)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='LeaseDeedApplication.aspx?ViewID=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        else if(Service == 200)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='AllotteeReservationMoneyPayNMSWP.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        else if (Service == 4)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IATransferOfPlotApplication.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        #region Faizan
                        else if (Service == 1029)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {

                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAServicesApplication.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }

                        #endregion
                        else if (Service == 1028)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IACurrentDues.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }

                        #region Manish Shukla
                        else if (Service == 1002 || Service == 1005 || Service == 1006 || Service == 1011 || Service == 1007 || Service == 1014)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAServicesApplication_Module.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }

                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }

                        else if (Service == 1012 || Service == 1024 || Service == 1025 || Service == 1026)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAServicesApplication_Module1.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }

                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        #endregion

                        #region Manish Rastogi
                        else if (Service == 1008 || Service == 1021 || Service == 1017)
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAReconstitutionApplication.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }

                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
                        }
                        #endregion
                        else
                        {
                            string NMSWP_Result = gm.UpdateStatusAtNMSWP(SWCControlID, SWCUnitID, SWCServiceID, "10", "Application Process Initiated and Application has been saved as draft | Applicant", SWCRequest_ID, "Applicant", "");
                            if (NMSWP_Result == "SUCCESS")
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                                var script = string.Format("alert({0});window.location ='IAServicesApplication_Module.aspx?ServiceReqNo=" + RefNo + "';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                            else
                            {
                                string message1 = "Error Occured while updating status at NMSWP";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            }
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

        protected void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpIndusrialArea.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtPlotNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your plot number');", true);
                    return;
                }
                /* Comment By Sunil
                if (drpPlotType.SelectedValue != "2")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('The Service for selected plot type will be available soon.');", true);
                    return;
                }
                Comment By Sunil */

                if (SWCServiceID.Trim() == "SC21025")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowTermsAndCondition();", true);

                }
                else
                {
                    ViewState["Transfer"] = "";


                    string Service = "";
                    switch (SWCServiceID.ToString())
                    {
                        case "SC21012":
                            {
                                Service = "Application For Addition of Product";
                                break;
                            }
                        case "SC21013":
                            {
                                Service = "Application For Change of Project";
                                break;
                            }
                        case "SC21014":
                            {
                                Service = "Application For Execution and Registration of Lease Deed";
                                break;
                            }
                        case "SC21022":
                            {
                                Service = "Online Payment of Reservation Money";
                                break;
                            }
                        case "SC21029":
                            {
                                Service = "Application for Amalgamation Post Allotment";
                                break;
                            }
                        case "SC21027":
                            {
                                Service = "Online Payment Of Outstanding Dues";
                                break;
                            }
                        default:
                            {
                                Service = "Application For UPSIDA Service";
                                break;
                            }

                    }



                    SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end ,case when isnull(AllotteeName,'')>'' then AllotteeName else CompanyName end,AllotteeID,case when isnull(PhoneNo,'')>'' then PhoneNo else SignatoryPhone end from AllotteeMaster  where IndustrialArea='" + drpIndusrialArea.SelectedItem.Text.Trim() + "' and PlotNo='" + txtPlotNo.Text.Trim().Replace("'", "''") + "' and IsCompleted=1 and exists(select * from PlotMaster where IAID='" + drpIndusrialArea.SelectedValue.Trim() + "' and PlotNumber='" + txtPlotNo.Text.Trim().Replace("'", "''") + "' and landuseCode='" + drpPlotType.SelectedValue.Trim() + "')", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string EmailID = dt.Rows[0][0].ToString().Trim();
                        string AllotteeName = dt.Rows[0][1].ToString().Trim();
                        string AllotteeID = dt.Rows[0][2].ToString().Trim();
                        string PhoneNo = dt.Rows[0][3].ToString().Trim();

                        if (EmailID.Length <= 0 && PhoneNo.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID & Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        if (EmailID.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        if (PhoneNo.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                            return;
                        }
                        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match = regex.Match(EmailID);
                        if (match.Success)
                        {

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid email id found on your record. Kindly contact concern regional office.');", true);
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



                        //MailAddress mailfrom = new MailAddress("eodbtestingupsidc@gmail.com");
                      MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                        MailAddress mailto = new MailAddress(EmailID);
                        MailMessage newmsg = new MailMessage(mailfrom, mailto);

                       // newmsg.IsBodyHtml = true;

                        string StrContent = "";
                        StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                        StrContent = reader.ReadToEnd();

                        StrContent = StrContent.Replace("{UserName}", AllotteeName.Trim());
                        StrContent = StrContent.Replace("{OTP}", otp.Trim());
                        StrContent = StrContent.Replace("{Service}", Service);


                        newmsg.Subject = "UPSIDAeService: OTP verification for applying UPSIDA services";
                        newmsg.BodyHtml = StrContent;


                        //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        ////SmtpClient smtp = new SmtpClient("smtp.upsidc.com", 25);
                        //smtp.UseDefaultCredentials = false;
                        ////smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc@123");
                        //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                        //smtp.EnableSsl = true;
                        //smtp.Send(newmsg);

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.outlook.com";
                        client.Port = 587;
                        client.Username = mailfrom.Address;
                        client.Password = "upsida12345";
                        client.ConnectionProtocols = ConnectionProtocols.Ssl;
                        client.SendOne(newmsg);


                        String message = HttpUtility.UrlEncode("Dear " + AllotteeName + " OTP for " + Service + " is " + otp + "");
                        string s = gm.SendOTP("OTP", PhoneNo, AllotteeName, message);

                        objServiceTimelinesBEL.UserId = Convert.ToInt32(AllotteeID);
                        objServiceTimelinesBEL.emailID = EmailID;
                        objServiceTimelinesBEL.OTP = otp;
                        objServiceTimelinesBEL.SWCControlID = SWCControlID.Trim();
                        objServiceTimelinesBEL.SWCUnitID = SWCUnitID.Trim();
                        objServiceTimelinesBEL.SWCServiceID = SWCServiceID.Trim();


                        int result = objServiceTimelinesBLL.SaveOTPIAServicesNMSWP(objServiceTimelinesBEL);
                        if (result > 0)
                        {

                            string input = EmailID.Trim();
                            string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                            string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                            string Output2 = Regex.Replace(PhoneNo, @"\d(?!\d{0,3}$)", "X");
                            string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            DivOTP.Visible = true;
                            btnfind.Text = "Resend OTP";
                            return;
                        }
                        else
                        {
                            string message1 = "Unable To send OTP Kindly Update your EmailID";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                            DivOTP.Visible = false;
                            btnfind.Text = "Find";
                            return;
                        }
                    }
                    else
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details');", true);
                        DivOTP.Visible = false;
                        btnfind.Text = "Find";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("Oops! error occured Exception :" + ex.Message.ToString());
                DivOTP.Visible = false;
                btnfind.Text = "Find";
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpIndusrialArea.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select your industrial area');", true);
                    return;
                }
                if (txtPlotNo.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your Plot Number');", true);
                    return;
                }
                if (txtOTP.Text.Trim().Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your OTP');", true);
                    return;
                }
        

                    objServiceTimelinesBEL.OTP          = txtOTP.Text.Trim();
                    objServiceTimelinesBEL.SWCControlID = SWCControlID;
                    objServiceTimelinesBEL.SWCUnitID    = SWCUnitID;
                    objServiceTimelinesBEL.SWCServiceID = SWCServiceID;

                    DataSet dsR = new DataSet();


                    dsR = objServiceTimelinesBLL.VerifyOTPIAService(objServiceTimelinesBEL);
                    DataTable dtt = new DataTable();
                    dtt = dsR.Tables[0];

                if (dtt.Rows.Count > 0)
                {
                    string message = dtt.Rows[0]["message"].ToString();
                    string status  = dtt.Rows[0]["status"].ToString();

                    if (status == "2")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+message+"');", true);
                        GetApplicantDetails();
                        return;
                    }
                    
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('"+message+"');", true);
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid OTP. Kindly Recheck It');", true);
                    return;
                }

                    

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
        }
        protected void StampChk1s_CheckedChanged(object sender, EventArgs e)
        {
            if (StampChk1s.Checked == true)
            {
                RebateDiv.Visible = true;
            }
            else
            {
                RebateDiv.Visible = false;
            }
        }
        public void BindServiceCheckListGridViewDocument()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();



                objServiceTimelinesBEL.ServiceTimeLines = "1001";
                objServiceTimelinesBEL.FirmType = "1";




                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetDocumentChecklistLeaseDeed(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }
                finally
                {
                    objServiceTimelinesBEL = null;
                    objServiceTimelinesBLL = null;
                }


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx");

            //try
            //{
            //    string ControlID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCControlID);
            //    string UnitID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCUnitID);
            //    string ServiceID = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", SWCServiceID);
            //    string DeptID    = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", (21).ToString());
            //    string PassSalt  = NMSWPEncryption.Class1.EncryptString("ABCDEFGHIJKLMNOP", "p5632aa8a5c915ba4b896325bc5baz8k");
            //    NameValueCollection collections = new NameValueCollection();
            //    collections.Add("Dept_Code", DeptID.Trim());
            //    collections.Add("ControlID", ControlID.Trim());
            //    collections.Add("UnitID",    UnitID.Trim());
            //    collections.Add("ServiceID", ServiceID.Trim());
            //    collections.Add("PassSalt",  PassSalt.Trim());
            //    string remoteUrl = "http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Bck_page.aspx";

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



        protected void btnIAccept_Click(object sender, EventArgs e)
        {
            ViewState["Transfer"] = DropDown.SelectedItem.Text.Trim();
            if (DropDown.SelectedValue == "1")
            {
                FindRecord();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end ,case when isnull(AllotteeName,'')>'' then AllotteeName else CompanyName end,AllotteeID,case when isnull(PhoneNo,'')>'' then PhoneNo else SignatoryPhone end from AllotteeMaster  where IndustrialArea='" + drpIndusrialArea.SelectedItem.Text.Trim() + "' and PlotNo='" + txtPlotNo.Text.Trim() + "' and IsCompleted=1 and exists(select * from PlotMaster where IAID='" + drpIndusrialArea.SelectedValue.Trim() + "' and PlotNumber='" + txtPlotNo.Text.Trim() + "' and landuseCode='" + drpPlotType.SelectedValue.Trim() + "')", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GetApplicantDetails();

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details');", true);


                }
            }
        }

        private void FindRecord()
        {


            string Service = "";
            switch (SWCServiceID.ToString())
            {
                case "SC21012":
                    {
                        Service = "Application For Addition of Product";
                        break;
                    }
                case "SC21013":
                    {
                        Service = "Application For Change of Project";
                        break;
                    }
                case "SC21014":
                    {
                        Service = "Application For Execution and Registration of Lease Deed";
                        break;
                    }
                case "SC21022":
                    {
                        Service = "Online Payment of Reservation Money";
                        break;
                    }
                case "SC21029":
                    {
                        Service = "Application for No Dues Certificate";
                        break;
                    }
                case "SC21027":
                    {
                        Service = "Online Payment Of Outstanding Dues";
                        break;
                    }
                default:
                    {
                        Service = "Application For UPSIDA Service";
                        break;
                    }

            }



            SqlCommand cmd = new SqlCommand("select case when isnull(EmailID,'')>'' then EmailID else SignatoryEmail end ,case when isnull(AllotteeName,'')>'' then AllotteeName else CompanyName end,AllotteeID,case when isnull(PhoneNo,'')>'' then PhoneNo else SignatoryPhone end from AllotteeMaster  where IndustrialArea='" + drpIndusrialArea.SelectedItem.Text.Trim() + "' and PlotNo='" + txtPlotNo.Text.Trim().Replace("'", "''") + "' and IsCompleted=1 and exists(select * from PlotMaster where IAID='" + drpIndusrialArea.SelectedValue.Trim() + "' and PlotNumber='" + txtPlotNo.Text.Trim().Replace("'", "''") + "' and landuseCode='" + drpPlotType.SelectedValue.Trim() + "')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string EmailID = dt.Rows[0][0].ToString().Trim();
                string AllotteeName = dt.Rows[0][1].ToString().Trim();
                string AllotteeID = dt.Rows[0][2].ToString().Trim();
                string PhoneNo = dt.Rows[0][3].ToString().Trim();

                if (EmailID.Length <= 0 && PhoneNo.Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID & Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                    return;
                }
                if (EmailID.Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your EmailID is not updated. Kindly ask Rm office to update your email id');", true);
                    return;
                }
                if (PhoneNo.Length <= 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Mobile No is not updated. Kindly ask Rm office to update your email id');", true);
                    return;
                }
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(EmailID);
                if (match.Success)
                {

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid email id found on your record. Kindly contact concern regional office.');", true);
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
                StreamReader reader = new StreamReader(Server.MapPath("~/IAServiceOTPMail.html"));
                StrContent = reader.ReadToEnd();

                StrContent = StrContent.Replace("{UserName}", AllotteeName.Trim());
                StrContent = StrContent.Replace("{OTP}", otp.Trim());
                StrContent = StrContent.Replace("{Service}", Service);


                newmsg.Subject = "UPSIDAeService: OTP verification for applying UPSIDA services";
                newmsg.BodyHtml = StrContent;


                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("eodbupsidc@gmail.com", "upsidc12345");
                //smtp.EnableSsl = true;
                //smtp.Send(newmsg);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.Username = mailfrom.Address;
                client.Password = "upsida12345";
                client.ConnectionProtocols = ConnectionProtocols.Ssl;
                client.SendOne(newmsg);


                String message = HttpUtility.UrlEncode("Dear " + AllotteeName + " OTP for " + Service + " is " + otp + "");
                string s = gm.SendOTP("OTP", PhoneNo, AllotteeName, message);

                objServiceTimelinesBEL.UserId = Convert.ToInt32(AllotteeID);
                objServiceTimelinesBEL.emailID = EmailID;
                objServiceTimelinesBEL.OTP = otp;
                objServiceTimelinesBEL.SWCControlID = SWCControlID.Trim();
                objServiceTimelinesBEL.SWCUnitID = SWCUnitID.Trim();
                objServiceTimelinesBEL.SWCServiceID = SWCServiceID.Trim();


                int result = objServiceTimelinesBLL.SaveOTPIAServicesNMSWP(objServiceTimelinesBEL);
                if (result > 0)
                {

                    string input = EmailID.Trim();
                    string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                    string Output = Regex.Replace(input, pattern, m => new string('*', m.Length));
                    string Output2 = Regex.Replace(PhoneNo, @"\d(?!\d{0,3}$)", "X");
                    string message1 = "OTP Send To Your Registered Email ID i.e. " + Output.Trim() + " and Phone No i.e. " + Output2 + ". Kindly verify OTP for the submission of your application";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    DivOTP.Visible = true;
                    btnfind.Text = "Resend OTP";
                    return;

                }
                else
                {
                    string message1 = "Unable To send OTP Kindly Update your EmailID";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message1 + "');", true);
                    DivOTP.Visible = false;
                    btnfind.Text = "Find";
                    return;
                }
            }
            else
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Invalid Details');", true);
                DivOTP.Visible = false;
                btnfind.Text = "Find";
                return;
            }

        }
    }
}