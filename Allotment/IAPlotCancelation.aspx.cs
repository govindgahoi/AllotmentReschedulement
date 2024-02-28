
using System.IO;
using BEL_Allotment;
using BLL_Allotment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Allotment.ServiceReference1;
using System.Collections;
using System.Web.UI.HtmlControls;

namespace Allotment
{
    public partial class IAPlotCancelation : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con;
        #endregion

        string UserName = string.Empty;
        ArrayList ar1 = new ArrayList();
        ArrayList ar2 = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            }
            catch
            {
            }
            try
            {
                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];
                UserName = _objLoginInfo.userName;
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                UserSpecificBinding();
            }
        }

        protected void UserSpecificBinding()
        {
            objServiceTimelinesBEL.UserName = UserName;
            DataSet dsR = new DataSet();
            try
            {
                dsR = objServiceTimelinesBLL.GetregionalOfficeRecords(objServiceTimelinesBEL);
                ddloffice.DataSource = dsR.Tables[0];
                ddloffice.DataTextField = "a";
                ddloffice.DataValueField = "b";
                ddloffice.DataBind();
                Regional_Changed(null, null);
                if (dsR.Tables[1].Rows[0][0].ToString() == "View")
                {
                    //         Allottee_master_grid.Columns[9].Visible = true;
                }
                else
                {
                    //       Allottee_master_grid.Columns[9].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {
            drpdwnIA.Items.Clear();
            drpdwnIA.Items.Insert(0, new ListItem("Select RegionName", "0"));
            try { bindDDLRegion(ddloffice.SelectedItem.Value, null); } catch { }
        }

        private void bindDDLRegion(string pOffice, string pIAName)
        {
            objServiceTimelinesBEL.RegionalOffice = (pOffice);
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecords(objServiceTimelinesBEL);
                drpdwnIA.DataSource = ds;
                drpdwnIA.DataTextField = "IAName";
                drpdwnIA.DataValueField = "Id";
                drpdwnIA.DataBind();



                if (!string.IsNullOrEmpty(pIAName))
                {
                    drpdwnIA.SelectedIndex = drpdwnIA.Items.IndexOf(drpdwnIA.Items.FindByText(pIAName));
                }

                try { drpdwnIA_SelectedIndexChanged(null, null); } catch { }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured111 :" + ex.Message.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
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


        protected void drpPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetApplicantDetails();
            PreviousServices();
        }


        private void GetApplicantDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            string Paid = "";
            try
            {

                    objServiceTimelinesBEL.AllotmentLetterno = "";
                    objServiceTimelinesBEL.IAName = drpdwnIA.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.PlotNo = drpPlotNo.SelectedItem.Text.Trim();
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
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                    lblSIgnatoryEmail.Text = dt.Rows[0]["Email"].ToString();
                    lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                    lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                    lblplotarea.Text = dt.Rows[0]["PlotSize"].ToString();
                    lblCompanyConstitution.Text = dt.Rows[0]["FirmConstitution"].ToString();
                    lblIAID.Text = dt.Rows[0]["IAID"].ToString();
                    lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                    if (lblSIgnatoryEmail.Text.Length > 0)
                    {
                        EmailDiv.Visible = false;
                    }
                    else
                    {
                        EmailDiv.Visible = true;
                    }
                    if (lblSignatoryMobile.Text.Length > 0)
                    {
                        MobileDiv.Visible = false;
                    }
                    else
                    {
                        MobileDiv.Visible = true;
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

        protected void btnRaiseReqestforPlotCancelation_Click(object sender, EventArgs e)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            if (lblSIgnatoryEmail.Text == "")
            {
                if (txtemail.Text == "")
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Email ID is not with us kindly enter email id before proceeding.");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }

            }
            if (lblSignatoryMobile.Text == "")
            {
                if (txtmobile.Text == "")
                {
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Mobile No is not with us kindly enter mobile no before proceeding.");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
            }
            objServiceTimelinesBEL.IndustrialArea = lblIAID.Text;
            objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text;
            objServiceTimelinesBEL.ServiceTimeLinesID = Convert.ToInt32("1013");
            objServiceTimelinesBEL.CreatedBy = lblAllotmentLetterNo.Text;
            objServiceTimelinesBEL.Email = txtemail.Text;
            objServiceTimelinesBEL.PhoneNumber = txtmobile.Text;
            try
            {
                DataSet ds = new DataSet();

                ds = objServiceTimelinesBLL.SetRequestIAPlotCancelation(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int result = 0;
                        string RefNo = ds.Tables[0].Rows[0][0].ToString().Trim();

                        string[] SerArray = RefNo.Split('/');
                        int Service = int.Parse(SerArray[1]);
                        objServiceTimelinesBEL.ServiceRequestNO = RefNo;
                        result = objServiceTimelinesBLL.SetServiceRequestFinishCancelationofplot(objServiceTimelinesBEL);
                        if(result>0)
                        { 
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Dear Applicant \r\n Your Service Request Number Is " + RefNo + " \r\n Kindly Note Down This No For Future Reference.");
                            var script = string.Format("alert({0});window.location ='ServiceRequestInboxIA.aspx?ServiceReqNo=" + RefNo + "';", message);
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

        private void PreviousServices()
        {
            SqlCommand cmd = new SqlCommand("GetPreviouslyAppliedServicesPlotCancelation '" + lblAllotmentLetterNo.Text.Trim() + "','" + drpdwnIA.SelectedItem.Text.Trim() + "','" + drpPlotNo.SelectedValue.Trim() + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                PreviousServiceGrid.DataSource = dt;
                PreviousServiceGrid.DataBind();
                PreviousServiceDiv.Visible = true;
                btnRaise.Visible = false;
            }
            else
            {
                PreviousServiceGrid.DataSource = null;
                PreviousServiceGrid.DataBind();
                PreviousServiceDiv.Visible = false;
                btnRaise.Visible = true;
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
                    if (Service == 1013)
                    {
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Redirecting to application page");
                        var script = string.Format("alert({0});window.location ='ServiceRequestInboxIA.aspx?ServiceReqNo=" + ServiceID + "';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}