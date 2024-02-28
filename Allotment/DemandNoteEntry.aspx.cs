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
    public partial class DemandNoteEntry : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion

        string UserName = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            try
            {


                LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                UserName = _objLoginInfo.userName;

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            this.RegisterPostBackControl();

            if (!IsPostBack)
            {
                bind();
                UserSpecificBinding(UserName);

            }
        }
        protected void UserSpecificBinding(string UserName)
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
                ddloffice.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsavedues);

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
                drpdwnIA.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void Regional_Changed(object sender, EventArgs e)
        {

            try
            {

                bindDDLRegion(ddloffice.SelectedItem.Value, null);

            }
            catch
            {

            }



        }

        protected void drpdwnIA_SelectedIndexChanged(object sender, EventArgs e)
        {



            objServiceTimelinesBEL.IAID = (drpdwnIA.SelectedValue.Trim());
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.ListOfPlotForNotices(objServiceTimelinesBEL);
                ddlPlotNo.DataSource = ds;
                ddlPlotNo.DataTextField = "PlotNumber";
                ddlPlotNo.DataValueField = "PlotNumber";
                ddlPlotNo.DataBind();
                ddlPlotNo.Items.Insert(0, new ListItem("--Select--", ""));
                GetAllotteeDetails();


            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void btnsavedues_Click(object sender, EventArgs e)
        {
            try
            {
                string DemandID = "";
                decimal totalAmount = 0;
                int retVal = 0;

                if (lblAllotteeID.Text.Length <= 0)
                {
                    MessageBox1.ShowError("Please select Allotee");
                    return;
                }

                if (fileupload.HasFile)
                {


                    string fleUpload1 = Path.GetExtension(fileupload.FileName.ToString());

                    string contenttype1 = String.Empty;
                    switch (fleUpload1)
                    {
                        case ".jpg":
                            contenttype1 = "image/jpg";
                            break;
                        case ".png":
                            contenttype1 = "image/png";
                            break;
                        case ".pdf":
                            contenttype1 = "application/pdf";
                            break;
                    }
                    if (contenttype1 == String.Empty)
                    {
                        MessageBox1.ShowSuccess("Invalid File Format");
                        return;
                    }


                    foreach (GridViewRow row in GridView1.Rows)
                    {

                        TextBox Amount = (TextBox)row.FindControl("txtAmount");

                        if (Amount.Text == "")
                        {
                            Amount.Text = "0";
                        }

                        totalAmount += Convert.ToDecimal(Amount.Text);


                    }


                    if (totalAmount <= 0)
                    {
                        MessageBox1.ShowInfo("Please Enter Dues Under Demand");
                        return;
                    }

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.AlloteeId = lblAllotteeID.Text.Trim();
                    objServiceTimelinesBEL.AllotmentLetterno = lblAllotmentLetterNo.Text.Trim();
                    objServiceTimelinesBEL.DueAmount = totalAmount;
                    objServiceTimelinesBEL.DemandDate = Convert.ToDateTime(txtDemandDate.Text);
                    objServiceTimelinesBEL.UserName = UserName;


                    ds = objServiceTimelinesBLL.DemandNoteEntry(objServiceTimelinesBEL);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DemandID = ds.Tables[0].Rows[0][0].ToString();

                            foreach (GridViewRow row in GridView1.Rows)
                            {

                                Label PaymentID = (Label)row.FindControl("lblID");
                                Label PayDesc = (Label)row.FindControl("lblPayDescription");
                                TextBox Amount = (TextBox)row.FindControl("txtAmount");
                                if (Amount.Text == "")
                                {
                                    Amount.Text = "0";
                                }

                                if (Convert.ToDecimal(Amount.Text) > 0)
                                {
                                    objServiceTimelinesBEL.demandID = Convert.ToInt32(DemandID.Trim());
                                    objServiceTimelinesBEL.paymentID = Convert.ToInt32(PaymentID.Text.Trim());
                                    objServiceTimelinesBEL.PayDesc = PayDesc.Text.Trim();
                                    objServiceTimelinesBEL.Amount = Convert.ToDecimal(Amount.Text.Trim());

                                    retVal = objServiceTimelinesBLL.DemandNoteDetailEntry(objServiceTimelinesBEL);
                                }


                            }

                            if (retVal > 0)
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
                                    case ".pdf":
                                        contenttype = "application/pdf";
                                        break;
                                }
                                if (contenttype != String.Empty)
                                {
                                    Stream fs = fileupload.PostedFile.InputStream;
                                    BinaryReader br = new BinaryReader(fs);
                                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                                    objServiceTimelinesBEL.demandID = Convert.ToInt32(DemandID.Trim());
                                    objServiceTimelinesBEL.ApplicantImageName = filename;
                                    objServiceTimelinesBEL.ImageContent = contenttype;
                                    objServiceTimelinesBEL.UserName = UserName;

                                    int result = objServiceTimelinesBLL.UploadDemandNoticeDoc(objServiceTimelinesBEL);
                                    if (result > 0)
                                    {

                                        string message = "Demand Note Inserted Successfully";
                                        MessageBox1.ShowSuccess(message);
                                        GetAllotteeDetails();
                                        bind();
                                        txtDemandDate.Text = "";

                                    }
                                }
                                else
                                {
                                    string message = "Invalid File Format";
                                    MessageBox1.ShowInfo(message);


                                }



                            }
                        }
                    }



                }

                else
                {
                    string message = "Please Select Demand Note To Upload ";
                    MessageBox1.ShowInfo(message);


                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }


        }

        protected void ddlPlotNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetAllotteeDetails();
            bind();
            txtDemandDate.Text = "";
        }


        private void GetAllotteeDetails()
        {
            objServiceTimelinesBEL.PlotNo = (ddlPlotNo.SelectedValue.Trim());
            objServiceTimelinesBEL.IAName = (drpdwnIA.SelectedItem.Text.Trim());
            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.GetAllotteeDetailsAgainstPlot(objServiceTimelinesBEL);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataTable dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        lblAllotteeID.Text = dt.Rows[0]["AllotteeID"].ToString();
                        lblAllotmentLetterNo.Text = dt.Rows[0]["Allotmentletterno"].ToString();
                        lblRegionalOffice.Text = dt.Rows[0]["RegionaOffice"].ToString();
                        lblIndustrialArea.Text = dt.Rows[0]["IndustrialArea"].ToString();
                        lblDateofApplication.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                        lblPlotNo.Text = dt.Rows[0]["PlotNo"].ToString();
                        lblApplicationDate.Text = dt.Rows[0]["DateOfAllotment"].ToString();
                        lblDateofApplication.Text = dt.Rows[0]["AllotmentApplicationDate"].ToString();
                        lblplotarea.Text = dt.Rows[0]["TotalAllottedplotArea"].ToString();
                        lblFirmCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                        lblAuthorisedSignatory.Text = dt.Rows[0]["CompanyName"].ToString();
                        lblAddress.Text = dt.Rows[0]["Address"].ToString();
                        lblSIgnatoryEmail.Text = dt.Rows[0]["emailID"].ToString();
                        lblSignatoryMobile.Text = dt.Rows[0]["PhoneNo"].ToString();
                        lblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                        lblCinNo.Text = dt.Rows[0]["CinNo"].ToString();
                        lblCompanyConstitution.Text = dt.Rows[0]["FirmType"].ToString();

                    }
                    else
                    {
                        lblCompanyConstitution.Text = "";
                        lblAllotteeID.Text = "";
                        lblAllotmentLetterNo.Text = "";
                        lblRegionalOffice.Text = "";
                        lblIndustrialArea.Text = "";
                        lblDateofApplication.Text = "";
                        lblPlotNo.Text = "";
                        lblApplicationDate.Text = "";
                        lblDateofApplication.Text = "";
                        lblplotarea.Text = "";
                        lblFirmCompanyName.Text = "";
                        lblAuthorisedSignatory.Text = "";
                        lblAddress.Text = "";
                        lblSIgnatoryEmail.Text = "";
                        lblSignatoryMobile.Text = "";
                        lblPanNo.Text = "";
                        lblCinNo.Text = "";
                    }

                    if (dt1.Rows.Count > 0)
                    {
                        ApplicationGrid.DataSource = dt1;
                        ApplicationGrid.DataBind();

                    }
                    else
                    {
                        ApplicationGrid.DataSource = "";
                        ApplicationGrid.DataBind();
                    }



                }



            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        private void bind()
        {
            SqlCommand cmd = new SqlCommand("GetPaymentforDemandNote", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ApplicationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string reqid = ApplicationGrid.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("GridViewPayment") as GridView;

                objServiceTimelinesBEL.demandID = Convert.ToInt32(reqid);
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetBifircatedDemandDetails(objServiceTimelinesBEL);
                    gvOrders.DataSource = ds;
                    gvOrders.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }
        }

        protected void ApplicationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteDemand")
            {

                try
                {

                    string ID = (e.CommandArgument).ToString();
                    objServiceTimelinesBEL.demandID = Convert.ToInt32(ID);
                    int retVal = objServiceTimelinesBLL.DeleteDemandNote(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string message = "Demand Notice deleted successfully ";
                        MessageBox1.ShowSuccess(message);
                        GetAllotteeDetails();

                    }
                    else
                    {
                        string message = "Demand Notice couldn't be deleted";
                        MessageBox1.ShowError(message);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (e.CommandName == "ViewDemand")
            {

                string ID = (e.CommandArgument).ToString();
                //Response.Write("<script>window.open ('DocViewerMinutes.aspx?ServiceReqNo=" + ServiceReqNo.Trim() + "','_blank');</script>");
                String js = "window.open('DocViewerDemand.aspx?DemandID=" + ID.Trim() + "', '_blank');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DocViewerDemand.aspx", js, true);

            }
        }
    }
}