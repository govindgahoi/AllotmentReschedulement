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
    public partial class LandAcquisitionProposal : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        string ID;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RegisterPostBackControl();
                bindDistrict();
                ID = Request.QueryString["ID"];
                ViewState["ID"] = Convert.ToInt32(ID);

                if (ID != null)
                {

                    GetDetails(Convert.ToString(ViewState["ID"]));
                    bindgrid(Convert.ToString(ViewState["ID"]));
                }
                else
                {
                    tr4.Visible = true;
                }



                DataTable temp_Land_details = new DataTable();

                temp_Land_details.TableName = "temp_Land_details";
                temp_Land_details.Columns.Add(new DataColumn("Village", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("KhataNo", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("KhatedarName", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("FatherHusbandName", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("Address", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("GataNo", typeof(string)));
                temp_Land_details.Columns.Add(new DataColumn("GataArea", typeof(string)));



                ViewState["temp_Land_details"] = temp_Land_details;
                temp_Land_details_DataBind();

            }
        }
        private void RegisterPostBackControl()
        {
            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null)
                scriptManager.RegisterPostBackControl(btnUpload);
            scriptManager.RegisterPostBackControl(btnuploadfile);
        }
        public void temp_Land_details_DataBind()
        {
            DataTable dt = (DataTable)ViewState["temp_Land_details"];

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
                Land_details_grid.DataSource = dt;
                Land_details_grid.DataBind();
                Land_details_grid.Rows[0].Visible = false;
                dt.Rows.Clear();
                dt.AcceptChanges();
            }
            else
            {
                Land_details_grid.DataSource = dt;
                Land_details_grid.DataBind();
            }


        }


        protected void ButtonAdd_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Land_details"];


            string Village = (Land_details_grid.FooterRow.FindControl("txtVillage_insert") as TextBox).Text;
            string KhataNo = (Land_details_grid.FooterRow.FindControl("txtKhataNo_insert") as TextBox).Text;
            string KhatedarName = (Land_details_grid.FooterRow.FindControl("txtKhatedarName_insert") as TextBox).Text;
            string FatherName = (Land_details_grid.FooterRow.FindControl("txtFatherHusbandName_insert") as TextBox).Text;
            string Address = (Land_details_grid.FooterRow.FindControl("txtAddress_insert") as TextBox).Text;
            string GataNo = (Land_details_grid.FooterRow.FindControl("txtGataNo_insert") as TextBox).Text;
            string GataArea = (Land_details_grid.FooterRow.FindControl("txtGataArea_insert") as TextBox).Text;


            if (KhataNo != "")
            {
                DataRow dr = dt.NewRow();
                dr["Village"] = Village;
                dr["KhataNo"] = KhataNo;
                dr["KhatedarName"] = KhatedarName;
                dr["FatherHusbandName"] = FatherName;
                dr["Address"] = Address;
                dr["GataNo"] = GataNo;
                dr["GataArea"] = GataArea;


                dt.Rows.Add(dr);
                dt.AcceptChanges();

                ViewState["temp_Land_details"] = dt;
                temp_Land_details_DataBind();

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Survey No');", true);
                return;
            }
        }

        protected void Land_details_grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["temp_Land_details"];
            int index = Convert.ToInt32(e.RowIndex);

            dt.Rows[index].Delete();
            dt.AcceptChanges();

            ViewState["temp_Land_details"] = dt;

            dt.AcceptChanges();


            temp_Land_details_DataBind();
        }

        private void bindDistrict()
        {
            DataSet dsR = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[GetCensus_District]", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataTextField = "Census_District";
                ddlDistrict.DataValueField = "Census_District_code";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue.Trim());

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.getSubDistrictRecords(DistrictID);
                ddlSubDistrict.DataSource = ds;
                ddlSubDistrict.DataTextField = "Census_SubDistrictName";
                ddlSubDistrict.DataValueField = "Census_SubDistrict_code";
                ddlSubDistrict.DataBind();
                ddlSubDistrict.Items.Insert(0, new ListItem("--Select--", "0"));

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
        public void bindgrid(string ID)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetgridForView(ID);
                if (ds != null)
                {
                    Land_details_grid1.DataSource = ds;
                    Land_details_grid1.DataBind();
                    trnew.Visible = true;
                    tr4.Visible = false;
                }
                else
                {
                    Land_details_grid1.DataSource = null;
                    Land_details_grid1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        public void GetDetails(string ID)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


            DataSet ds = new DataSet();
            try
            {

                ds = objServiceTimelinesBLL.Getgridforviewmore(ID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtNameofLandOwner.Text = ds.Tables[0].Rows[0]["NameOfLandOwner"].ToString().Trim();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString().Trim();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString().Trim();
                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["DistrictID"].ToString().Trim();
                    ddlDistrict_SelectedIndexChanged(null, null);
                    ddlSubDistrict.SelectedValue = ds.Tables[0].Rows[0]["Census_SubDistrict_code"].ToString().Trim();
                    ddllandownerType.SelectedValue = ds.Tables[0].Rows[0]["LandownerType"].ToString().Trim();
                    ddllandType.Text = ds.Tables[0].Rows[0]["LandType"].ToString().Trim();
                    txtTotalland.Text = ds.Tables[0].Rows[0]["TotalLand"].ToString().Trim();
                    ddlRoadConnectivity.SelectedValue = ds.Tables[0].Rows[0]["RoadConnectivity"].ToString().Trim();
                    txtRoadwidth.Text = ds.Tables[0].Rows[0]["Roadwidth"].ToString().Trim();
                    txtDistancefromnearestexpressway.Text = ds.Tables[0].Rows[0]["Distancefromnearestexpressway"].ToString().Trim();
                    txtNearestRailwayStationName.Text = ds.Tables[0].Rows[0]["DistancefromnearestRailwayStation"].ToString().Trim();
                    txtDistancefromnearestRailwayStation.Text = ds.Tables[0].Rows[0]["NearestRailwayStationName"].ToString().Trim();
                    ddlsurcefreshwater.SelectedValue = ds.Tables[0].Rows[0]["surcefreshwater"].ToString().Trim();
                    txtdepthofsourcewater.Text = ds.Tables[0].Rows[0]["Depthofsourcewater"].ToString().Trim();
                    txtCirclerateperhectare.Text = ds.Tables[0].Rows[0]["Circlerateperhectare"].ToString().Trim();
                    txtProposeofferedrateperhectare.Text = ds.Tables[0].Rows[0]["Proposeofferedrateperhectare"].ToString().Trim();
                    ddlalllandowners.SelectedValue = ds.Tables[0].Rows[0]["Alllandowners"].ToString().Trim();
                    txtNameofLandOwner.Enabled = false;
                    txtMobileNo.Enabled = false;
                    txtEmail.Enabled = false;
                    ddlDistrict.Enabled = false;
                    ddlSubDistrict.Enabled = false;
                    ddllandownerType.Enabled = false;
                    ddllandType.Enabled = false;
                    txtTotalland.Enabled = false;
                    ddlRoadConnectivity.Enabled = false;
                    txtRoadwidth.Enabled = false;
                    txtDistancefromnearestexpressway.Enabled = false;
                    txtNearestRailwayStationName.Enabled = false;
                    txtDistancefromnearestRailwayStation.Enabled = false;
                    ddlsurcefreshwater.Enabled = false;
                    txtdepthofsourcewater.Enabled = false;
                    txtdepthofsourcewater.Enabled = false;
                    txtCirclerateperhectare.Enabled = false;
                    txtProposeofferedrateperhectare.Enabled = false;
                    ddlalllandowners.Enabled = false;
                    btnReset.Visible = false;
                    btnSubmit.Visible = false;
                    mandatoryfield.Visible = false;
                    div_hide.Visible = false;
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
        private void download(DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Letter"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["contentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["ColName"].ToString() + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNameofLandOwner.Text == "" || txtNameofLandOwner.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Land Owner Name');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LANameOfLandOwner = txtNameofLandOwner.Text;
                }
                if (txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Mobile No');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAMobileNo = txtMobileNo.Text;
                }

                if (txtEmail.Text == "" || txtEmail.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Email');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAEmail = txtEmail.Text;
                    ViewState["Mail"] = Convert.ToString(txtEmail.Text);
                }
                if (ddlDistrict.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select District');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LADistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
                }
                if (ddlSubDistrict.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Sub District');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LASubDistrict = ddlSubDistrict.SelectedValue;
                }
                if (ddllandownerType.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Land owner Type');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAlandownerType = Convert.ToInt32(ddllandownerType.SelectedValue);
                }
                if (ddllandType.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Land  Type');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAlandType = Convert.ToInt32(ddllandType.SelectedValue);
                }
                if (txtTotalland.Text == "" || txtTotalland.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Total Land');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LATotalLand = txtTotalland.Text.Trim();
                }


                objServiceTimelinesBEL.LAName = Convert.ToString(Session["LAFileName"]);

                objServiceTimelinesBEL.LAContentType = Convert.ToString(Session["LAFileExt"]);

                objServiceTimelinesBEL.LADocumentsMap = Session["LAFile"] as byte[];



                objServiceTimelinesBEL.LASignedConsentlatterName = Convert.ToString(Session["SignedFileName"]);
                objServiceTimelinesBEL.LASignedConsentlatterContentType = Convert.ToString(Session["SignedFileExt"]); ;

                objServiceTimelinesBEL.LASignedConsentlatterDocumentsMap = Session["SignedFile"] as byte[];

                if (ddlRoadConnectivity.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Road Connectivity');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LARoadConnectivity = Convert.ToInt32(ddlRoadConnectivity.SelectedValue);
                }
                if (txtRoadwidth.Text == "" || txtRoadwidth.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Road width');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LARoadwidth = txtRoadwidth.Text.Trim();
                }
                if (txtDistancefromnearestexpressway.Text == "" || txtDistancefromnearestexpressway.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Road width');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LADistancefromnearestexpressway = txtDistancefromnearestexpressway.Text.Trim();
                }

                if (txtNearestRailwayStationName.Text == "" || txtNearestRailwayStationName.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Nearest Railway Station Name');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LANearestRailwayStationName = txtNearestRailwayStationName.Text.Trim();
                }
                if (txtDistancefromnearestRailwayStation.Text == "" || txtDistancefromnearestRailwayStation.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Distance from nearest Railway Station');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LADistancefromnearestRailwayStation = txtDistancefromnearestRailwayStation.Text.Trim();
                }
                if (ddlsurcefreshwater.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter surce fresh water');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAsurcefreshwater = Convert.ToInt32(ddlsurcefreshwater.SelectedValue);
                }
                if (txtdepthofsourcewater.Text == "" || txtdepthofsourcewater.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter depth of source water');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAdepthofsourcewater = txtdepthofsourcewater.Text.Trim();
                }
                if (txtCirclerateperhectare.Text == "" || txtCirclerateperhectare.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Circle rate per hectare');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LACirclerateperhectare = txtCirclerateperhectare.Text.Trim();
                }
                if (txtProposeofferedrateperhectare.Text == "" || txtProposeofferedrateperhectare.Text == null)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Propose offered rate per hectare');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAProposeofferedrateperhectare = txtProposeofferedrateperhectare.Text.Trim();
                }
                if (ddlalllandowners.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Propose offered rate per hectare');", true);
                    return;

                }
                else
                {
                    objServiceTimelinesBEL.LAalllandowners = Convert.ToInt32(ddlalllandowners.SelectedValue);
                }


                DataSet result = objServiceTimelinesBLL.InsertLandAcquisitionDetails(objServiceTimelinesBEL);

                if (result.Tables.Count > 0)
                {
                    int RefNo = Convert.ToInt32(result.Tables[0].Rows[0][0]);
                    ViewState["refID"] = Convert.ToInt32(result.Tables[0].Rows[0][0]);
                    DataTable temp3 = (DataTable)ViewState["temp_Land_details"];
                    if (temp3.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in temp3.Rows)
                        {

                            string Village = dr2["Village"].ToString();
                            string KhataNo = dr2["KhataNo"].ToString();
                            string KhatedarName = dr2["KhatedarName"].ToString();
                            string FatherHusbandName = dr2["FatherHusbandName"].ToString();
                            string Address = dr2["Address"].ToString();
                            string GataNo = dr2["GataNo"].ToString();
                            string GataArea = dr2["GataArea"].ToString();

                            int result1 = objServiceTimelinesBLL.InsertLanddetails(RefNo, Village, KhataNo, KhatedarName, FatherHusbandName, Address, GataNo, GataArea);
                            if (result1 > 0)
                            {
                                // SendMailUPSIDC(); 
                                clear();
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your  request has been submitted successfully, our representative will contact you soon.. ');", true);


                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        private void SendMailUPSIDC()
        {

            try
            {


                string Mail = Convert.ToString(ViewState["Mail"]);
                // string RefNo = Convert.ToString(ViewState["refID"]);




                MailAddress mailfrom = new MailAddress("eservicesotp@outlook.com");
                MailAddress mailto = new MailAddress(Mail);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //newmsg.IsBodyHtml = true;
                string StrContent = "";
                StreamReader reader = new StreamReader(Server.MapPath("~/LandAssessmentReferenceNo.html"));
                StrContent = reader.ReadToEnd();
                StrContent = StrContent.Replace("{Description}", "<br/>We appreciate that you have shown intrest in Investing in UPSIDA Industrial Area. After analysing your requirement we will contact you within next 15 working days ");

                newmsg.Subject = "Intimation of Submission of Request/Proposal at UPSIDA";
                newmsg.BodyHtml = StrContent;

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

            }
        }
        public void clear()
        {
            ddlDistrict.SelectedValue = "0";
            ddlSubDistrict.SelectedValue = "0";
            txtNameofLandOwner.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddllandownerType.SelectedValue = "0";
            ddllandType.SelectedValue = "0";
            txtTotalland.Text = string.Empty;
            ddlRoadConnectivity.SelectedValue = "0";
            txtRoadwidth.Text = string.Empty;
            txtDistancefromnearestexpressway.Text = string.Empty;
            txtNearestRailwayStationName.Text = string.Empty;
            txtDistancefromnearestRailwayStation.Text = string.Empty;
            ddlsurcefreshwater.SelectedValue = "0";
            txtdepthofsourcewater.Text = string.Empty;
            txtCirclerateperhectare.Text = string.Empty;
            txtProposeofferedrateperhectare.Text = string.Empty;
            ddlalllandowners.SelectedValue = "0";
            lbluploadingMsg.Visible = false;
            lbluploadingMsgs.Visible = false;
            ViewState["temp_Land_details"] = null;
            DataTable temp_Land_details = new DataTable();
            temp_Land_details.TableName = "temp_Land_details";
            temp_Land_details.Columns.Add(new DataColumn("Village", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("KhataNo", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("KhatedarName", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("FatherHusbandName", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("Address", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("GataNo", typeof(string)));
            temp_Land_details.Columns.Add(new DataColumn("GataArea", typeof(string)));
            ViewState["temp_Land_details"] = temp_Land_details;
            temp_Land_details_DataBind();


        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandAcquisitionProposal.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadLoaction.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = FileUploadLoaction.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;


                //Set the contenttype based on File Extension
                switch (ext)
                {
                    //case ".doc":
                    //    contenttype = "application/vnd.ms-word";
                    //    break;
                    //case ".docx":
                    //    contenttype = "application/vnd.ms-word";
                    //    break;
                    //case ".xls":
                    //    contenttype = "application/vnd.ms-excel";
                    //    break;
                    //case ".xlsx":
                    //    contenttype = "application/vnd.ms-excel";
                    //    break;
                    //case ".jpg":
                    //    contenttype = "image/jpg";
                    //    break;
                    //case ".png":
                    //    contenttype = "image/png";
                    //    break;
                    //case ".gif":
                    //    contenttype = "image/gif";
                    // break;
                    case ".pdf":
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
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "File format not recognised." +
                      " Upload PDF formats";

                }

            }
        }

        protected void btnuploadfile_Click(object sender, EventArgs e)
        {
            if (FileSignedConsentlatter.HasFile)
            {

                // Read the file and convert it to Byte Array
                string filePath = FileSignedConsentlatter.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

                //Set the contenttype based on File Extension
                switch (ext)
                {
                    //case ".doc":
                    //    contenttype = "application/vnd.ms-word";
                    //    break;
                    //case ".docx":
                    //    contenttype = "application/vnd.ms-word";
                    //    break;
                    //case ".xls":
                    //    contenttype = "application/vnd.ms-excel";
                    //    break;
                    //case ".xlsx":
                    //    contenttype = "application/vnd.ms-excel";
                    //    break;
                    //case ".jpg":
                    //    contenttype = "image/jpg";
                    //    break;
                    //case ".png":
                    //    contenttype = "image/png";
                    //    break;
                    //case ".gif":
                    //    contenttype = "image/gif";
                    //    break;
                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                }
                if (contenttype != String.Empty && ext == ".pdf")
                {

                    Stream fs = FileSignedConsentlatter.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    objServiceTimelinesBEL.LASignedConsentlatterName = filename;
                    objServiceTimelinesBEL.LASignedConsentlatterContentType = contenttype;
                    objServiceTimelinesBEL.LASignedConsentlatterDocumentsMap = bytes;

                    Session["SignedFileName"] = objServiceTimelinesBEL.LASignedConsentlatterName;
                    Session["SignedFileExt"] = objServiceTimelinesBEL.LASignedConsentlatterContentType;
                    Session["SignedFile"] = objServiceTimelinesBEL.LASignedConsentlatterDocumentsMap;
                    lbluploadingMsgs.Text = "File uploaded Successfully";
                    lbluploadingMsgs.ForeColor = System.Drawing.Color.Green;
                    lbluploadingMsgs.Visible = true;


                }
                else
                {
                    lblStatus1.ForeColor = System.Drawing.Color.Red;
                    lblStatus1.Text = "File format not recognised." +
                      " Upload PDF formats";

                }
            }
        }
    }
}